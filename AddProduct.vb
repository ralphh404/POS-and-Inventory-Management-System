Imports CrystalDecisions.CrystalReports.ViewerObjectModel
Imports MySql.Data.MySqlClient

Public Class AddProduct
    Public callingForm As Form
    Public isEditMode As Boolean = False
    Public ProductID As Integer
    Public BarcodeValue As String

    Private Sub AddProduct_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ' Autofocus
        Me.BeginInvoke(New MethodInvoker(Sub() txtPrCode.Focus()))

        ' Populate Unit ComboBox
        cmbUnt.Items.Clear()
        cmbUnt.Items.AddRange(New String() {"Piece/s", "Box"})
        If cmbUnt.SelectedIndex = -1 Then cmbUnt.SelectedIndex = 0

        ' === Make Expiry Date optional ===
        dtExp.Format = DateTimePickerFormat.Custom
        dtExp.CustomFormat = " " ' Blank initially

        Me.BeginInvoke(New MethodInvoker(Sub()

                                             txtPrCode.Focus()

                                             If Not String.IsNullOrWhiteSpace(BarcodeValue) Then
                                                 txtPrCode.Text = BarcodeValue
                                             End If

                                         End Sub))
    End Sub

    Private Function ValidatePriceLogic() As Boolean
        Dim selling As Decimal
        Dim purchase As Decimal

        If Not Decimal.TryParse(txtPrPrice.Text.Replace("₱", "").Trim(), selling) Then
            MessageBox.Show("Invalid selling price.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return False
        End If

        If Not Decimal.TryParse(txtPPrice.Text.Replace("₱", "").Trim(), purchase) Then
            MessageBox.Show("Invalid purchase price.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return False
        End If

        If purchase > selling Then
            MessageBox.Show("Purchase price cannot be higher than selling price.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return False
        End If

        Return True
    End Function

    Private Sub dtExp_ValueChanged(sender As Object, e As EventArgs) Handles dtExp.ValueChanged
        ' ✅ When a date is selected, make sure it’s shown properly again
        If dtExp.CustomFormat = " " Then
            dtExp.CustomFormat = "yyyy-MM-dd" ' or use "MM/dd/yyyy" if you prefer
        End If
    End Sub

    ' --- Quantity numeric only ---
    Private Sub txtQuant_TextChanged(sender As Object, e As EventArgs) Handles txtQuant.TextChanged
        Dim cleanText As String = New String(txtQuant.Text.Where(AddressOf Char.IsDigit).ToArray())
        If txtQuant.Text <> cleanText Then
            Dim cursorPos = txtQuant.SelectionStart
            txtQuant.Text = cleanText
            txtQuant.SelectionStart = Math.Min(cursorPos, txtQuant.Text.Length)
        End If
    End Sub

    Private Sub txtQuant_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtQuant.KeyPress
        If Not Char.IsControl(e.KeyChar) AndAlso Not Char.IsDigit(e.KeyChar) Then e.Handled = True
    End Sub

    ' --- Price numeric + decimal ---
    Private Sub txtPrPrice_TextChanged(sender As Object, e As EventArgs) Handles txtPrPrice.TextChanged, txtPPrice.TextChanged
        Dim cleanText = New String(txtPrPrice.Text.Where(Function(c) Char.IsDigit(c) OrElse c = "."c).ToArray)
        If txtPrPrice.Text <> cleanText Then
            Dim cursorPos = txtPrPrice.SelectionStart
            txtPrPrice.Text = cleanText
            txtPrPrice.SelectionStart = Math.Min(cursorPos, txtPrPrice.Text.Length)
        End If
    End Sub

    Private Sub txtPrPrice_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtPrPrice.KeyPress, txtPPrice.KeyPress
        If Not Char.IsControl(e.KeyChar) AndAlso Not Char.IsDigit(e.KeyChar) AndAlso e.KeyChar <> "."c Then e.Handled = True
        If e.KeyChar = "."c AndAlso txtPrPrice.Text.Contains(".") Then e.Handled = True
    End Sub

    ' --- PRICE DISPLAY FORMAT ---
    Private Sub txtPrPrice_Leave(sender As Object, e As EventArgs) Handles txtPrPrice.Leave, txtPPrice.Leave
        Dim value As Decimal
        If Decimal.TryParse(txtPrPrice.Text.Replace("₱", "").Trim, value) Then
            txtPrPrice.Text = "₱" & value.ToString("N2")
        End If
    End Sub

    Private Function CleanPrice(value As String) As Decimal
        Dim result As Decimal = 0
        Decimal.TryParse(value.Replace("₱", "").Trim(), result)
        Return result
    End Function

    ' --- SAVE NEW PRODUCT ---
    Private Sub btnSavePr_Click(sender As Object, e As EventArgs) Handles btnSavePr.Click
        ' Validation
        If txtPrCode.Text.Trim() = "" OrElse txtPrName.Text.Trim() = "" OrElse
       cmbCat.SelectedIndex = -1 OrElse cmbUnt.SelectedIndex = -1 OrElse txtPrPrice.Text.Trim() = "" Then
            MessageBox.Show("Please fill all required fields.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If

        If Not ValidatePriceLogic() Then Return

        ' Clean price
        Dim cleanPrice As Decimal
        If Not Decimal.TryParse(txtPrPrice.Text.Replace("₱", "").Trim(), cleanPrice) OrElse cleanPrice < 0 Then
            MessageBox.Show("Invalid or negative price.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return
        End If

        Dim cleanPurchasePrice As Decimal
        If Not Decimal.TryParse(txtPPrice.Text.Replace("₱", "").Trim(), cleanPurchasePrice) OrElse cleanPurchasePrice < 0 Then
            MessageBox.Show("Invalid or negative purchase price.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return
        End If


        ' Determine suffix for ProductCode
        Dim selectedUnit As String = cmbUnt.SelectedItem.ToString()
        Dim codeSuffix As String = If(selectedUnit = "Box", "-B", "-P")

        ' Avoid double suffix
        Dim baseCode As String = txtPrCode.Text.Trim()
        If baseCode.EndsWith("-P") OrElse baseCode.EndsWith("-B") Then
            baseCode = baseCode.Substring(0, baseCode.Length - 2)
        End If
        Dim finalCode As String = baseCode & codeSuffix

        Try
            Connect()

            ' Check duplicate ProductCode
            Dim checkQuery As String = "SELECT COUNT(*) FROM products1 WHERE ProductCode=@code;"
            Using cmdCheck As New MySqlCommand(checkQuery, conn)
                cmdCheck.Parameters.AddWithValue("@code", finalCode)
                If Convert.ToInt32(cmdCheck.ExecuteScalar()) > 0 Then
                    MessageBox.Show("Product code already exists: " & finalCode, "Duplicate", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    Return
                End If
            End Using

            ' Insert product (always store as Piece/s)
            Dim query As String =
            "INSERT INTO products1 (ProductCode, ProductName, Description, Category, Price, PurchasePrice, Unit, StockQty, ExpiryDate, DateAdded)
             VALUES (@code, @name, @desc, @cat, @price, @purchase, 'Piece/s', 0, @expiry, NOW());
             SELECT LAST_INSERT_ID();"

            Dim newProductID As Integer
            Using cmd As New MySqlCommand(query, conn)
                cmd.Parameters.AddWithValue("@code", finalCode)
                cmd.Parameters.AddWithValue("@name", txtPrName.Text.Trim())
                cmd.Parameters.AddWithValue("@desc", txtDscrpt.Text.Trim())
                cmd.Parameters.AddWithValue("@cat", cmbCat.SelectedItem.ToString())
                cmd.Parameters.AddWithValue("@price", cleanPrice)
                cmd.Parameters.AddWithValue("@purchase", cleanPurchasePrice)
                If dtExp.CustomFormat = " " Then
                    cmd.Parameters.AddWithValue("@expiry", DBNull.Value)
                Else
                    cmd.Parameters.AddWithValue("@expiry", dtExp.Value.ToString("yyyy-MM-dd"))
                End If
                newProductID = Convert.ToInt32(cmd.ExecuteScalar())
            End Using

            ' Ensure conversion exists
            Dim insertConvQuery As String =
            "INSERT INTO unit_conversion1 (ProductID, UnitName, ConversionQty)
             VALUES (@pid, 'Piece/s', 1)
             ON DUPLICATE KEY UPDATE ConversionQty = 1;"
            Using cmdConv As New MySqlCommand(insertConvQuery, conn)
                cmdConv.Parameters.AddWithValue("@pid", newProductID)
                cmdConv.ExecuteNonQuery()
            End Using

            MessageBox.Show($"Product added successfully!" & vbCrLf &
                        $"Code: {finalCode}" & vbCrLf &
                        $"Unit Type: {selectedUnit}", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)

            ' Refresh product list
            If TypeOf callingForm Is ProductsPOS Then
                CType(callingForm, ProductsPOS).LoadProducts()
            End If

            ' Reset to default view
            cmbUnt.SelectedIndex = 0

            Me.Close()

        Catch ex As Exception
            MessageBox.Show("Error saving product: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            Disconnect()
        End Try
    End Sub


    ' --- UPDATE EXISTING PRODUCT ---
    Private Sub btnPrUpdate_Click(sender As Object, e As EventArgs) Handles btnPrUpdate.Click
        Dim price As Decimal = CleanPrice(txtPrPrice.Text)
        If price < 0 Then
            MessageBox.Show("Price cannot be negative.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return
        End If

        Dim purchasePrice As Decimal = CleanPrice(txtPPrice.Text)
        If purchasePrice < 0 Then
            MessageBox.Show("Purchase price cannot be negative.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return
        End If

        If Not ValidatePriceLogic() Then Return

        Try
            Connect()

            Dim selectedUnit As String = cmbUnt.SelectedItem.ToString()
            Dim codeSuffix As String = If(selectedUnit = "Box", "-B", "-P")

            ' Avoid double suffix
            Dim baseCode As String = txtPrCode.Text.Trim()
            If baseCode.EndsWith("-P") OrElse baseCode.EndsWith("-B") Then
                baseCode = baseCode.Substring(0, baseCode.Length - 2)
            End If
            Dim finalCode As String = baseCode & codeSuffix

            Dim query As String =
            "UPDATE products1 
             SET ProductCode=@code, ProductName=@name, Description=@desc, 
                 Category=@cat, Price=@price, PurchasePrice=@purchase, Unit='Piece/s', ExpiryDate=@exp
             WHERE ProductID=@id"

            Using cmd As New MySqlCommand(query, conn)
                cmd.Parameters.AddWithValue("@code", finalCode)
                cmd.Parameters.AddWithValue("@name", txtPrName.Text.Trim())
                cmd.Parameters.AddWithValue("@desc", txtDscrpt.Text.Trim())
                cmd.Parameters.AddWithValue("@cat", cmbCat.Text)
                cmd.Parameters.AddWithValue("@price", price)
                cmd.Parameters.AddWithValue("@purchase", purchasePrice)
                If dtExp.CustomFormat = " " Then
                    cmd.Parameters.AddWithValue("@exp", DBNull.Value)
                Else
                    cmd.Parameters.AddWithValue("@exp", dtExp.Value)
                End If
                cmd.Parameters.AddWithValue("@id", ProductID)
                cmd.ExecuteNonQuery()
            End Using

            ' Ensure conversion record exists
            Dim checkQuery As String =
            "SELECT COUNT(*) FROM unit_conversion1 WHERE ProductID=@pid AND UnitName='Piece/s';"
            Using cmdCheck As New MySqlCommand(checkQuery, conn)
                cmdCheck.Parameters.AddWithValue("@pid", ProductID)
                If Convert.ToInt32(cmdCheck.ExecuteScalar()) = 0 Then
                    Dim insertConv As String =
                    "INSERT INTO unit_conversion1 (ProductID, UnitName, ConversionQty) VALUES (@pid, 'Piece/s', 1);"
                    Using cmdIns As New MySqlCommand(insertConv, conn)
                        cmdIns.Parameters.AddWithValue("@pid", ProductID)
                        cmdIns.ExecuteNonQuery()
                    End Using
                End If
            End Using

            MessageBox.Show($"Product updated successfully!" & vbCrLf &
                        $"New Code: {finalCode}" & vbCrLf &
                        $"Unit Type: {selectedUnit}", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)

            ' Reset combo box to Piece/s
            cmbUnt.SelectedIndex = 0

            Me.Close()

        Catch ex As Exception
            MessageBox.Show("Error updating product: " & ex.Message)
        Finally
            Disconnect()
        End Try
    End Sub

    Private Sub btnCancelProducts_Click(sender As Object, e As EventArgs) Handles btnCancelProducts.Click
        Me.Close()
    End Sub

End Class
