Imports System.Data.Common
Imports System.Globalization
Imports MySql.Data.MySqlClient

Public Class Pending

    Private fadeInTimer As Timer
    Private fadeOutTimer As Timer
    Private allowClose As Boolean = False

    ' 🔹 Form load
    Private Sub Pending_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        LoadPendingTransactions()
        Me.Opacity = 0
        Me.Visible = False
    End Sub

    ' 🔹 Fade in effect when shown
    Private Sub Pending_Shown(sender As Object, e As EventArgs) Handles MyBase.Shown
        Me.Visible = True
        fadeInTimer = New Timer With {.Interval = 10}
        AddHandler fadeInTimer.Tick, AddressOf FadeInEffect
        fadeInTimer.Start()
    End Sub

    Private Sub FadeInEffect(sender As Object, e As EventArgs)
        If Me.Opacity < 1 Then
            Me.Opacity += 0.1
        Else
            fadeInTimer.Stop()
            fadeInTimer.Dispose()
        End If
    End Sub

    ' 🔹 Fade out effect when closing
    Private Sub Pending_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
        If Not allowClose Then
            e.Cancel = True
            fadeOutTimer = New Timer With {.Interval = 10}
            AddHandler fadeOutTimer.Tick,
                Sub()
                    If Me.Opacity > 0 Then
                        Me.Opacity -= 0.1
                    Else
                        fadeOutTimer.Stop()
                        fadeOutTimer.Dispose()
                        allowClose = True
                        Me.Close()
                    End If
                End Sub
            fadeOutTimer.Start()
        End If
    End Sub

    ' 🔹 Load all pending transactions into combo box
    Private Sub LoadPendingTransactions()
        Try
            If conn.State = ConnectionState.Closed Then conn.Open()

            Dim sql As String = "SELECT PendingID, TransactionNo FROM pending_sales ORDER BY PendingID DESC"
            Using cmd As New MySqlCommand(sql, conn)
                Using reader As MySqlDataReader = cmd.ExecuteReader()
                    cmbPending.Items.Clear()
                    While reader.Read()
                        cmbPending.Items.Add(New KeyValuePair(Of Integer, String)(
                            Convert.ToInt32(reader("PendingID")),
                            reader("TransactionNo").ToString()
                        ))
                    End While
                End Using
            End Using

            cmbPending.DisplayMember = "Value"
            cmbPending.ValueMember = "Key"

        Catch ex As Exception
            MessageBox.Show("Error loading pending transactions: " & ex.Message, "Error",
                            MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            If conn.State = ConnectionState.Open Then conn.Close()
        End Try
    End Sub

    ' 🔹 When selecting a pending record
    Private Sub cmbPending_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbPending.SelectedIndexChanged
        If cmbPending.SelectedItem Is Nothing Then Exit Sub
        Dim selectedPair As KeyValuePair(Of Integer, String) =
            DirectCast(cmbPending.SelectedItem, KeyValuePair(Of Integer, String))
        LoadPendingItems(selectedPair.Key)
    End Sub

    ' 🔹 Display pending items in DataGridView
    Private Sub LoadPendingItems(pendingID As Integer)
        Try
            If conn.State = ConnectionState.Closed Then conn.Open()

            Dim sql As String = "
                SELECT 
                    p.ProductCode,
                    p.ProductName,
                    pi.Description,
                    CASE 
                        WHEN p.DefaultUnit = 'Box' THEN CONCAT('Box (', p.PiecesPerBox, ' pcs)')
                        ELSE 'Piece'
                    END AS Unit,
                    pi.Quantity,
                    pi.Price,
                    (pi.Quantity * pi.Price) AS TotalPrice, pi.IsVoided
                FROM pending_items pi
                INNER JOIN products1 p ON pi.ProductID = p.ProductID
                WHERE pi.PendingID = @PendingID
                ORDER BY pi.PendingItemID ASC
            "

            Using cmd As New MySqlCommand(sql, conn)
                cmd.Parameters.AddWithValue("@PendingID", pendingID)

                Dim adapter As New MySqlDataAdapter(cmd)
                Dim table As New DataTable()
                adapter.Fill(table)
                dbPending.DataSource = table

                ' Show voided items visually in Pending preview
                If dbPending.Columns.Contains("IsVoided") Then

                    ' optional hide helper column
                    dbPending.Columns("IsVoided").Visible = False

                    For Each row As DataGridViewRow In dbPending.Rows
                        If row.IsNewRow Then Continue For

                        If Convert.ToInt32(row.Cells("IsVoided").Value) = 1 Then
                            row.DefaultCellStyle.ForeColor = Color.Red
                            row.DefaultCellStyle.Font =
                                New Font(dbPending.Font, FontStyle.Strikeout)
                        End If
                    Next

                End If
            End Using

            ' 🔹 Apply PH currency formatting
            Dim phCulture As New CultureInfo("en-PH")
            If dbPending.Columns.Contains("Price") Then
                dbPending.Columns("Price").DefaultCellStyle.FormatProvider = phCulture
                dbPending.Columns("Price").DefaultCellStyle.Format = "C2"
            End If
            If dbPending.Columns.Contains("TotalPrice") Then
                dbPending.Columns("TotalPrice").DefaultCellStyle.FormatProvider = phCulture
                dbPending.Columns("TotalPrice").DefaultCellStyle.Format = "C2"
            End If

            ' 🔹 Compute total correctly
            Dim total As Decimal = 0D
            If dbPending.Columns.Contains("TotalPrice") Then
                For Each row As DataGridViewRow In dbPending.Rows
                    If row.Cells("TotalPrice").Value IsNot Nothing Then
                        If Not dbPending.Columns.Contains("IsVoided") _
                        OrElse Convert.ToInt32(row.Cells("IsVoided").Value) = 0 Then

                            total += Convert.ToDecimal(row.Cells("TotalPrice").Value)

                        End If
                    End If
                Next
            End If

            lblAmount.Text = total.ToString("C2", phCulture)

        Catch ex As Exception
            MessageBox.Show("Error loading pending transaction: " & ex.Message, "Error",
                            MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            If conn.State = ConnectionState.Open Then conn.Close()
        End Try
    End Sub

    ' 🔹 Restore pending transaction into POSmain
    Private Sub btnProcess_Click(sender As Object, e As EventArgs) Handles btnProcess.Click
        If cmbPending.SelectedItem Is Nothing Then
            MessageBox.Show("Please select a pending transaction first.", "Warning",
                            MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Exit Sub
        End If

        Dim selectedPair As KeyValuePair(Of Integer, String) =
            DirectCast(cmbPending.SelectedItem, KeyValuePair(Of Integer, String))
        Dim pendingID As Integer = selectedPair.Key
        Dim transactionNo As String = selectedPair.Value  ' ✅ Capture TransactionNo

        Try
            Dim existingPOS As POSmain = Application.OpenForms().OfType(Of POSmain).FirstOrDefault()
            If existingPOS Is Nothing Then
                MessageBox.Show("POS form is not open. Please open the POS first.", "Warning",
                                MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Exit Sub
            End If

            ' ✅ Load pending items into POS and carry over TransactionNo
            existingPOS.LoadPendingTransaction(pendingID)

            ' ✅ Delete restored pending transaction
            If conn.State = ConnectionState.Closed Then conn.Open()
            Using trans As MySqlTransaction = conn.BeginTransaction()
                Try
                    Using cmd As New MySqlCommand("DELETE FROM pending_items WHERE PendingID = @PendingID", conn, trans)
                        cmd.Parameters.AddWithValue("@PendingID", pendingID)
                        cmd.ExecuteNonQuery()
                    End Using

                    Using cmd As New MySqlCommand("DELETE FROM pending_sales WHERE PendingID = @PendingID", conn, trans)
                        cmd.Parameters.AddWithValue("@PendingID", pendingID)
                        cmd.ExecuteNonQuery()
                    End Using

                    trans.Commit()
                    MessageBox.Show("Pending transaction restored successfully!",
                                    "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)

                    existingPOS.Show()
                    existingPOS.BringToFront()
                    Me.Close()

                Catch ex As Exception
                    trans.Rollback()
                    MessageBox.Show("Error restoring transaction: " & ex.Message, "Error",
                                    MessageBoxButtons.OK, MessageBoxIcon.Error)
                End Try
            End Using

        Catch ex As Exception
            MessageBox.Show("Unexpected error: " & ex.Message, "Error",
                            MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            If conn.State = ConnectionState.Open Then conn.Close()
        End Try
    End Sub

    ' 🔹 Cancel button
    Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        Me.Close()
    End Sub

End Class