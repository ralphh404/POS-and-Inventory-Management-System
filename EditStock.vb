Imports MySql.Data.MySqlClient

Public Class EditStock

    Private StockInId As Integer
    Private ProductId As Integer
    Private ProductNm As String
    Private CurrentQty As Integer
    Private SupplierId As Integer

    ' Internal working fields
    Private _productDefaultUnit As String = "Piece"
    Private _piecesPerBox As Integer = 1
    Private _currentTotalPieces As Integer = 0

    ' Constructor
    Public Sub New(stockInId As Integer, productId As Integer, productName As String, currentQty As Integer, supplierId As Integer)
        InitializeComponent()
        Me.StockInId = stockInId
        Me.ProductId = productId
        Me.ProductNm = productName
        Me.CurrentQty = currentQty
        Me.SupplierId = supplierId
    End Sub

    ' 🔹 Load Form
    Private Sub EditStock_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        txtEProduct.Text = Me.ProductNm
        LoadSuppliers()

        ' Fetch default unit and pieces per box
        Try
            If conn.State = ConnectionState.Closed Then conn.Open()

            Using cmd As New MySqlCommand("SELECT DefaultUnit, PiecesPerBox, StockQty FROM products1 WHERE ProductID = @pid LIMIT 1;", conn)
                cmd.Parameters.AddWithValue("@pid", ProductId)
                Using r = cmd.ExecuteReader()
                    If r.Read() Then
                        _productDefaultUnit = If(IsDBNull(r("DefaultUnit")), "Piece", r("DefaultUnit").ToString())
                        _piecesPerBox = If(IsDBNull(r("PiecesPerBox")), 1, Convert.ToInt32(r("PiecesPerBox")))
                        _currentTotalPieces = If(IsDBNull(r("StockQty")), 0, Convert.ToInt32(r("StockQty")))
                    End If
                End Using
            End Using

            ' Convert total pieces into display unit
            Dim displayQty As Integer
            If _productDefaultUnit.ToLower() = "box" AndAlso _piecesPerBox > 0 Then
                displayQty = _currentTotalPieces \ _piecesPerBox
            Else
                displayQty = _currentTotalPieces
            End If

            txtEQuant.Text = displayQty.ToString()

        Catch ex As Exception
            MessageBox.Show("Error loading product info: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            If conn.State = ConnectionState.Open Then conn.Close()
        End Try

        ' Preselect supplier if available
        If Me.SupplierId > 0 Then
            cmbSupp.SelectedValue = Me.SupplierId
        End If
    End Sub

    ' 🔹 Allow only digits
    Private Sub txtEQuant_TextChanged(sender As Object, e As EventArgs) Handles txtEQuant.TextChanged
        Dim cleanText As String = New String(txtEQuant.Text.Where(AddressOf Char.IsDigit).ToArray())
        If txtEQuant.Text <> cleanText Then
            Dim cursorPos = txtEQuant.SelectionStart
            txtEQuant.Text = cleanText
            txtEQuant.SelectionStart = Math.Min(cursorPos, txtEQuant.Text.Length)
        End If
    End Sub

    Private Sub txtEQuant_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtEQuant.KeyPress
        If Not Char.IsControl(e.KeyChar) AndAlso Not Char.IsDigit(e.KeyChar) Then
            e.Handled = True
        End If
    End Sub

    ' 🔹 Load supplier dropdown
    Private Sub LoadSuppliers()
        Try
            Dim query As String = "SELECT SupplierID, SupplierName FROM suppliers1 WHERE is_Archived = 0;"
            Using cmd As New MySqlCommand(query, conn)
                Dim da As New MySqlDataAdapter(cmd)
                Dim dt As New DataTable()
                da.Fill(dt)

                Dim blank As DataRow = dt.NewRow()
                blank("SupplierID") = DBNull.Value
                blank("SupplierName") = ""
                dt.Rows.InsertAt(blank, 0)

                cmbSupp.DataSource = dt
                cmbSupp.DisplayMember = "SupplierName"
                cmbSupp.ValueMember = "SupplierID"
                cmbSupp.SelectedIndex = 0
            End Using
        Catch ex As Exception
            MessageBox.Show("Error loading suppliers: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    ' 🔹 Update button logic
    Private Sub btnUpdateES_Click(sender As Object, e As EventArgs) Handles btnUpdateES.Click
        Try
            ' Validate new quantity
            Dim newQtyUnits As Integer
            If Not Integer.TryParse(txtEQuant.Text.Trim(), newQtyUnits) OrElse newQtyUnits < 0 Then
                MessageBox.Show("Enter a valid quantity (0 or more).", "Invalid", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Exit Sub
            End If

            ' Supplier ID (nullable)
            Dim supplierId As Object = DBNull.Value
            If cmbSupp.SelectedValue IsNot Nothing AndAlso Not IsDBNull(cmbSupp.SelectedValue) Then
                Dim tempId As Integer
                If Integer.TryParse(cmbSupp.SelectedValue.ToString(), tempId) AndAlso tempId > 0 Then
                    supplierId = tempId
                End If
            End If

            ' Convert to total pieces
            Dim newTotalPieces As Integer
            If _productDefaultUnit.ToLower() = "box" AndAlso _piecesPerBox > 0 Then
                newTotalPieces = newQtyUnits * _piecesPerBox
            Else
                newTotalPieces = newQtyUnits
            End If

            ' Compute delta pieces
            Dim deltaPieces As Integer = newTotalPieces - _currentTotalPieces

            If conn.State = ConnectionState.Closed Then conn.Open()

            Using tx = conn.BeginTransaction()
                ' 🔸 Update product stock in pieces
                Using cmd As New MySqlCommand("
                    UPDATE products1 
                       SET StockQty = StockQty + @delta
                     WHERE ProductID = @pid;", conn, tx)
                    cmd.Parameters.AddWithValue("@delta", deltaPieces)
                    cmd.Parameters.AddWithValue("@pid", ProductId)
                    cmd.ExecuteNonQuery()
                End Using

                ' 🔸 Update or insert into stock_in1
                Dim existingId As Object = Nothing
                Using checkCmd As New MySqlCommand("SELECT StockInID FROM stock_in1 WHERE ProductID = @pid LIMIT 1;", conn, tx)
                    checkCmd.Parameters.AddWithValue("@pid", ProductId)
                    existingId = checkCmd.ExecuteScalar()
                End Using

                If existingId IsNot Nothing AndAlso Not IsDBNull(existingId) Then
                    Using cmd As New MySqlCommand("
                        UPDATE stock_in1 
                           SET Quantity = @q,
                               SupplierID = @sid
                         WHERE StockInID = @id;", conn, tx)
                        cmd.Parameters.AddWithValue("@q", newQtyUnits)
                        cmd.Parameters.AddWithValue("@sid", supplierId)
                        cmd.Parameters.AddWithValue("@id", Convert.ToInt32(existingId))
                        cmd.ExecuteNonQuery()
                    End Using
                Else
                    Using cmd As New MySqlCommand("
                        INSERT INTO stock_in1 (ProductID, SupplierID, Quantity)
                        VALUES (@pid, @sid, @q);", conn, tx)
                        cmd.Parameters.AddWithValue("@pid", ProductId)
                        cmd.Parameters.AddWithValue("@sid", supplierId)
                        cmd.Parameters.AddWithValue("@q", newQtyUnits)
                        cmd.ExecuteNonQuery()
                    End Using
                End If

                ' 🔸 Build remarks
                Dim remarks As String
                If deltaPieces > 0 Then
                    If _productDefaultUnit.ToLower() = "box" Then
                        remarks = $"Added {deltaPieces \ _piecesPerBox} box(es) ({deltaPieces} pcs)"
                    Else
                        remarks = $"Added {deltaPieces} piece(s)"
                    End If
                ElseIf deltaPieces < 0 Then
                    If _productDefaultUnit.ToLower() = "box" Then
                        remarks = $"Removed {Math.Abs(deltaPieces) \ _piecesPerBox} box(es) ({Math.Abs(deltaPieces)} pcs)"
                    Else
                        remarks = $"Removed {Math.Abs(deltaPieces)} piece(s)"
                    End If
                Else
                    remarks = "No change in stock"
                End If

                ' 🔸 Insert stock history
                Using cmd As New MySqlCommand("
                    INSERT INTO stockin_history1 
                        (ProductName, Quantity, Unit, TotalPieces, Remarks, DateAdded)
                    VALUES
                        (@pname, @q, @unit, @total, @remarks, NOW());", conn, tx)
                    cmd.Parameters.AddWithValue("@pname", ProductNm)
                    cmd.Parameters.AddWithValue("@q", newQtyUnits)
                    cmd.Parameters.AddWithValue("@unit", _productDefaultUnit)
                    cmd.Parameters.AddWithValue("@total", newTotalPieces)
                    cmd.Parameters.AddWithValue("@remarks", remarks)
                    cmd.ExecuteNonQuery()
                End Using

                tx.Commit()
            End Using

            MessageBox.Show("Stock updated successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
            DialogResult = DialogResult.OK
            Close()

        Catch ex As Exception
            MessageBox.Show("Update failed: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            If conn.State = ConnectionState.Open Then conn.Close()
        End Try
    End Sub

    Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        Me.Close()
    End Sub

End Class

