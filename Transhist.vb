Imports System.Data.Common
Imports System.Globalization
Imports System.Runtime.InteropServices.JavaScript.JSType
Imports MySql.Data.MySqlClient

Public Class Transhist
    Private fadeInTimer As Timer
    Private fadeOutTimer As Timer
    Private allowClose As Boolean = False

    Private Sub Transhist_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        LoadTransactionNumbers()

        ' Disable sorting for all columns
        For Each column As DataGridViewColumn In dbThis.Columns
            column.SortMode = DataGridViewColumnSortMode.NotSortable
        Next

        Me.Opacity = 0
        Me.Visible = False
    End Sub

    Private Sub TransHist_Shown(sender As Object, e As EventArgs) Handles MyBase.Shown
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

    Private Sub TransHist_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
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

    ' 🔹 Load transaction numbers into ComboBox
    Private Sub LoadTransactionNumbers()
        Try
            If conn.State = ConnectionState.Closed Then conn.Open()

            Dim sql As String = "
                SELECT 
                    s.TransactionNo, 
                    s.SaleDate,
                    SUM(CASE WHEN si.IsVoided = 1 THEN 1 ELSE 0 END) AS VoidedCount,
                    COUNT(*) AS TotalCount
                FROM sales2 s
                INNER JOIN sales_items si ON s.SaleID = si.SaleID
                GROUP BY s.TransactionNo, s.SaleDate
                ORDER BY s.SaleDate DESC;
            "

            Using cmd As New MySqlCommand(sql, conn)
                Using reader As MySqlDataReader = cmd.ExecuteReader()
                    cmbT.Items.Clear()
                    While reader.Read()
                        Dim transNo As String = reader("TransactionNo").ToString()
                        Dim displayText As String = transNo

                        ' Append "(VOIDED)" if all items are voided
                        If Convert.ToInt32(reader("VoidedCount")) = Convert.ToInt32(reader("TotalCount")) Then
                            displayText &= " (VOIDED)"
                        End If

                        cmbT.Items.Add(displayText)
                    End While
                End Using
            End Using

        Catch ex As Exception
            MessageBox.Show("Error loading transactions: " & ex.Message,
                            "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            conn.Close()
        End Try
    End Sub

    ' 🔹 Load transaction date
    Private Sub LoadTransactionDate(transactionNo As String)
        Try
            If conn.State = ConnectionState.Closed Then conn.Open()

            Dim sql As String = "SELECT SaleDate FROM sales2 WHERE TransactionNo = @transNo"
            Using cmd As New MySqlCommand(sql, conn)
                cmd.Parameters.AddWithValue("@transNo", transactionNo)
                Dim result = cmd.ExecuteScalar()
                If result IsNot Nothing Then
                    txtHist.Text = Convert.ToDateTime(result).ToString("yyyy-MM-dd HH:mm:ss")
                End If
            End Using

        Catch ex As Exception
            MessageBox.Show("Error loading date: " & ex.Message,
                            "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            conn.Close()
        End Try
    End Sub

    ' 🔹 Load transaction items
    Private Sub LoadTransactionItems(transactionNo As String)
        Try
            If conn.State = ConnectionState.Closed Then conn.Open()

            Dim sql As String = "
                SELECT 
                    p.ProductCode, 
                    p.ProductName, 
                    p.DefaultUnit,
                    p.PiecesPerBox,
                    si.Quantity, 
                    si.Price, 
                    si.SubTotal, 
                    si.IsVoided
                FROM sales2 s
                INNER JOIN sales_items si ON s.SaleID = si.SaleID
                INNER JOIN products1 p ON si.ProductID = p.ProductID
                WHERE s.TransactionNo = @transNo;
            "

            Using cmd As New MySqlCommand(sql, conn)
                cmd.Parameters.AddWithValue("@transNo", transactionNo)
                Dim adapter As New MySqlDataAdapter(cmd)
                Dim table As New DataTable()
                adapter.Fill(table)

                ' Add readable "Unit" display
                table.Columns.Add("UnitDisplay", GetType(String))
                For Each row As DataRow In table.Rows
                    Dim defUnit As String = row("DefaultUnit").ToString()
                    Dim pcsPerBox As Integer = If(IsDBNull(row("PiecesPerBox")), 0, Convert.ToInt32(row("PiecesPerBox")))

                    If defUnit = "Box" Then
                        row("UnitDisplay") = $"Box ({pcsPerBox} pcs)"
                    Else
                        row("UnitDisplay") = "Piece"
                    End If
                Next

                dbThis.DataSource = table

                ' Hide unnecessary columns
                dbThis.Columns("DefaultUnit").Visible = False
                dbThis.Columns("PiecesPerBox").Visible = False

                ' Format numbers
                Dim phCulture As New CultureInfo("en-PH")
                dbThis.Columns("Price").DefaultCellStyle.Format = "C2"
                dbThis.Columns("Price").DefaultCellStyle.FormatProvider = phCulture
                dbThis.Columns("SubTotal").HeaderText = "Total Sales"
                dbThis.Columns("SubTotal").DefaultCellStyle.Format = "C2"
                dbThis.Columns("SubTotal").DefaultCellStyle.FormatProvider = phCulture

                ' Rename headers
                dbThis.Columns("UnitDisplay").HeaderText = "Unit"
                dbThis.Columns("IsVoided").HeaderText = "Void"

                ' Format Yes/No and color
                RemoveHandler dbThis.CellFormatting, AddressOf dbThis_CellFormatting
                AddHandler dbThis.CellFormatting, AddressOf dbThis_CellFormatting

                ' Highlight voided rows
                For Each row As DataGridViewRow In dbThis.Rows
                    Dim isVoided As Boolean = Convert.ToBoolean(row.Cells("IsVoided").Value)
                    If isVoided Then
                        row.DefaultCellStyle.ForeColor = Color.Red
                        row.DefaultCellStyle.Font = New Font(dbThis.Font, FontStyle.Strikeout)
                    Else
                        row.DefaultCellStyle.ForeColor = Color.Black
                        row.DefaultCellStyle.Font = New Font(dbThis.Font, FontStyle.Regular)
                    End If
                Next
            End Using

        Catch ex As Exception
            MessageBox.Show("Error loading transaction items: " & ex.Message,
                            "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            conn.Close()
        End Try
    End Sub

    Private Sub dbThis_CellFormatting(sender As Object, e As DataGridViewCellFormattingEventArgs)
        If dbThis.Columns(e.ColumnIndex).Name = "IsVoided" AndAlso e.Value IsNot Nothing Then
            e.Value = If(e.Value.ToString() = "1", "Yes", "No")
            e.FormattingApplied = True
        End If
    End Sub

    Private Sub cmbT_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbT.SelectedIndexChanged
        If cmbT.SelectedItem IsNot Nothing Then
            Dim transactionNo As String = cmbT.SelectedItem.ToString().Replace(" (VOIDED)", "")
            LoadTransactionDate(transactionNo)
            LoadTransactionItems(transactionNo)
        End If
    End Sub

    Private Sub btnClose_Click(sender As Object, e As EventArgs) Handles btnClose.Click
        Me.Close()
    End Sub
End Class