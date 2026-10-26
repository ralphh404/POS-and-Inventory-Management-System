Imports System.Globalization
Imports MySql.Data.MySqlClient
Imports System.Drawing.Printing
Imports System.Management

Public Class POSmain
    Private isTransactionActive As Boolean = True
    Private WithEvents pd As New PrintDocument
    Private Const VOID_TAG As String = "Voided"
    Private isPaymentCompleted As Boolean = False

    Private Sub POSmain_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        dbPOS.Rows.Clear()
        dbPOS.Columns.Clear()

        Try
            PictureBox2.Image = My.Resources.silver_membership_icon_default_avatar_profile_icon_membership_icon_social_media_user_image_illustration_vector
            MakePictureRound(PictureBox2)
        Catch ex As Exception
            MessageBox.Show("Failed to load profile picture: " & ex.Message,
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End Try

        With dbPOS.Columns
            Dim colProductID As New DataGridViewTextBoxColumn()
            colProductID.HeaderText = "ProductID"
            colProductID.Name = "ProductID"
            colProductID.Visible = False
            .Add(colProductID)

            .Add("ProductCode", "Product Code")
            .Add("ProductName", "Product Name")
            .Add("Description", "Description")
            .Add("Unit", "Unit")
            .Add("Quantity", "Quantity")
            .Add("Price", "Price")
            .Add("TotalPrice", "Total Price")
        End With

        With dbPOS
            .Columns("Unit").Width = 120
            .Columns("Quantity").Width = 120
            .Columns("Price").Width = 120
            .Columns("TotalPrice").Width = 180
        End With


        Dim phCulture As CultureInfo = New CultureInfo("en-PH")
        dbPOS.Columns("Price").DefaultCellStyle.FormatProvider = phCulture
        dbPOS.Columns("Price").DefaultCellStyle.Format = "C2"

        dbPOS.Columns("TotalPrice").DefaultCellStyle.FormatProvider = phCulture
        dbPOS.Columns("TotalPrice").DefaultCellStyle.Format = "C2"


        For Each column As DataGridViewColumn In dbPOS.Columns
            column.SortMode = DataGridViewColumnSortMode.NotSortable
        Next

        Me.BeginInvoke(Sub()
                           txtBarcode.Select()
                           txtBarcode.Focus()
                       End Sub)


        Me.Opacity = 0
        Dim fadeTimer As New Timer With {.Interval = 10}
        AddHandler fadeTimer.Tick,
        Sub()
            If Me.Opacity < 1 Then
                Me.Opacity += 0.1
            Else
                fadeTimer.Stop()
            End If
        End Sub
        fadeTimer.Start()

        Me.KeyPreview = True

        AddHandler Me.ControlAdded, AddressOf Control_FocusGuard

        ApplyFocusGuard(Me)
    End Sub

    Private Sub MakePictureRound(pic As PictureBox)
        If pic.Image Is Nothing Then Exit Sub
        Dim diameter As Integer = Math.Min(pic.Width, pic.Height)
        Dim bmp As New Bitmap(diameter, diameter)

        Using g As Graphics = Graphics.FromImage(bmp)
            g.SmoothingMode = Drawing2D.SmoothingMode.AntiAlias
            Dim gp As New Drawing2D.GraphicsPath()
            gp.AddEllipse(0, 0, diameter, diameter)
            g.SetClip(gp)
            g.Clear(System.Drawing.Color.Transparent)
            g.DrawImage(pic.Image, New Rectangle(0, 0, diameter, diameter),
                            New Rectangle(0, 0, pic.Image.Width, pic.Image.Height), GraphicsUnit.Pixel)
        End Using

        pic.Image = bmp
        Dim regionPath As New Drawing2D.GraphicsPath()
        regionPath.AddEllipse(0, 0, diameter, diameter)
        pic.Region = New Region(regionPath)
    End Sub

    Private Sub ApplyFocusGuard(parent As Control)
        For Each ctrl As Control In parent.Controls
            AddHandler ctrl.Enter, AddressOf ForceBarcodeFocus

            ' 🔁 recurse for child controls
            If ctrl.HasChildren Then
                ApplyFocusGuard(ctrl)
            End If
        Next
    End Sub

    Private Sub Control_FocusGuard(sender As Object, e As ControlEventArgs)
        AddHandler e.Control.Enter, AddressOf ForceBarcodeFocus

        For Each ctrl As Control In e.Control.Controls
            AddHandler ctrl.Enter, AddressOf ForceBarcodeFocus
        Next
    End Sub

    Private Sub ForceBarcodeFocus(sender As Object, e As EventArgs)
        If Not txtBarcode.Focused Then
            txtBarcode.Focus()
        End If
    End Sub

    Private Sub UpdateTotals()
        Dim subtotal As Decimal = 0D

        For Each row As DataGridViewRow In dbPOS.Rows
            If Not row.IsNewRow AndAlso row.Cells("TotalPrice").Value IsNot Nothing Then

                If Convert.ToString(row.Tag) = VOID_TAG Then Continue For

                Dim value As Decimal
                If Decimal.TryParse(row.Cells("TotalPrice").Value.ToString(), value) Then
                    subtotal += value
                End If
            End If
        Next

        ' 🔹 Compute VAT (12%)
        Dim vatRate As Decimal = 0.12D
        Dim vatAmount As Decimal = subtotal * vatRate
        Dim totalWithVat As Decimal = subtotal + vatAmount


        Dim phCulture As New CultureInfo("en-PH")
        lblVTotal.Text = vatAmount.ToString("C2", phCulture)
        lblTotal.Text = totalWithVat.ToString("C2", phCulture)
    End Sub

    Private Sub txtBarcode_KeyDown(sender As Object, e As KeyEventArgs) Handles txtBarcode.KeyDown

        If Not isTransactionActive Then
            txtBarcode.Clear()
            Return
        End If

        If e.KeyCode <> Keys.Enter Then Exit Sub
        e.SuppressKeyPress = True

        Dim code As String = txtBarcode.Text.Trim().ToUpper()

        If code = "" Then Exit Sub

        ' 🔥 AUTO CREATE TRANSACTION ON FIRST SCAN
        If String.IsNullOrWhiteSpace(lblTransactionNo.Text) OrElse lblTransactionNo.Text = "0" Then
            Dim newTransNo As String = DateTime.Now.ToString("yyyyMMddHHmmss") & "-" & New Random().Next(1000, 9999)
            lblTransactionNo.Text = newTransNo

            btnSettle.Enabled = True
            btnEdit.Enabled = True
        End If

        ' 🔥 Normalize barcode (remove P/B suffix variations)
        If code.EndsWith("-P") OrElse code.EndsWith("-B") Then
            code = code.Substring(0, code.Length - 2)
        ElseIf code.EndsWith("P") OrElse code.EndsWith("B") Then
            code = code.Substring(0, code.Length - 1)
        End If

        Try
            If conn.State = ConnectionState.Closed Then conn.Open()

            Dim query As String = "
                SELECT ProductID, ProductCode, ProductName, Description,
                Price, StockQty, DefaultUnit, PiecesPerBox
                FROM products1
                WHERE
                (
                    ProductCode LIKE @barcode
                    OR ProductName LIKE @name
                )
                AND IsArchived = 0
                ORDER BY
                CASE
                    WHEN ProductCode LIKE @barcode THEN 0
                    ELSE 1
                END
                LIMIT 1"

            Using cmd As New MySqlCommand(query, conn)

                cmd.Parameters.AddWithValue("@barcode", code & "%")
                cmd.Parameters.AddWithValue("@name", code & "%")

                Using reader = cmd.ExecuteReader()

                    If Not reader.Read() Then
                        MessageBox.Show("Product not found!")
                        Exit Sub
                    End If

                    Dim productID As Integer = reader("ProductID")
                    Dim productCode As String = reader("ProductCode").ToString()
                    Dim name As String = reader("ProductName").ToString()
                    Dim desc As String = reader("Description").ToString()
                    Dim price As Decimal = Convert.ToDecimal(reader("Price"))
                    Dim stock As Integer = Convert.ToInt32(reader("StockQty"))
                    Dim unit As String = reader("DefaultUnit").ToString()
                    Dim piecesPerBox As Integer = 1

                    If Not IsDBNull(reader("PiecesPerBox")) Then
                        piecesPerBox = CInt(reader("PiecesPerBox"))
                    End If

                    'Reflect available stock in Quantity column
                    Dim displayQty As Integer = stock

                    If unit.ToLower.Contains("box") AndAlso piecesPerBox > 0 Then
                        displayQty = stock \ piecesPerBox
                    End If

                    Dim found As Boolean = False

                    For Each row As DataGridViewRow In dbPOS.Rows

                        If row.Cells("ProductCode").Value.ToString() = productCode Then

                            If Convert.ToString(row.Tag) = VOID_TAG Then
                                MessageBox.Show(
                                    "This item has been voided and cannot be re-added in the same transaction.",
                                    "Scan Blocked",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Warning)
                            Else
                                MessageBox.Show("Item already added.")
                            End If

                            found = True
                            Exit For

                        End If

                    Next

                    ' add new row
                    If Not found Then
                        dbPOS.Rows.Add(productID, productCode, name, desc, unit, displayQty, price, price)
                    End If

                End Using
            End Using

            txtBarcode.Clear()
            UpdateTotals()

        Catch ex As Exception
            MessageBox.Show(ex.Message)
        Finally
            conn.Close()
        End Try
    End Sub

    Protected Overrides Function ProcessCmdKey(ByRef msg As Message, keyData As Keys) As Boolean
        If keyData = Keys.F1 Then
            If btnSettle.Enabled Then
                btnSettle.PerformClick()
            End If
            Return True

        ElseIf keyData = Keys.F2 Then
            If btnEdit.Enabled Then
                btnEdit.PerformClick()
            End If
            Return True

        ElseIf keyData = Keys.F3 Then
            If btnTransact.Enabled Then
                btnTransact.PerformClick()
            End If
            Return True

        ElseIf keyData = Keys.F4 Then
            If btnHist.Enabled Then
                btnHist.PerformClick()
            End If
            Return True

        ElseIf keyData = Keys.F5 Then
            If btnVoid.Enabled Then
                btnVoid.PerformClick()
            End If
            Return True

        ElseIf keyData = Keys.F6 Then
            If btnPedro.Enabled Then
                btnPedro.PerformClick()
            End If
            Return True

        ElseIf keyData = Keys.F7 Then
            If btnSave.Enabled Then
                btnSave.PerformClick()
            End If
            Return True

        ElseIf keyData = Keys.F8 Then
            If btnClose.Enabled Then
                btnClose.PerformClick()
            End If
            Return True
        End If

        Return MyBase.ProcessCmdKey(msg, keyData)
    End Function

    Private Sub pd_PrintPage(sender As Object, e As PrintPageEventArgs) Handles pd.PrintPage

        Dim font As New Font("Consolas", 8, FontStyle.Regular)
        Dim bold As New Font("Consolas", 9, FontStyle.Bold)
        Dim title As New Font("Consolas", 11, FontStyle.Bold)

        Dim y As Integer = 10
        Dim leftX As Integer = 10
        Dim rightX As Integer = 180
        Dim centerX As Integer = e.PageBounds.Width / 2

        Dim centerFormat As New StringFormat() With {.Alignment = StringAlignment.Center}
        Dim rightFormat As New StringFormat() With {.Alignment = StringAlignment.Far}

        ' ===== HEADER =====
        e.Graphics.DrawString("MEDENT+", title, Brushes.Black, centerX, y, centerFormat)
        y += 18

        e.Graphics.DrawString("OFFICIAL RECEIPT", bold, Brushes.Black, centerX, y, centerFormat)
        y += 18

        e.Graphics.DrawString("--------------------------------", font, Brushes.Black, leftX, y)
        y += 12

        ' ===== TRANSACTION INFO =====
        e.Graphics.DrawString("Trans #: " & lblTransactionNo.Text, font, Brushes.Black, leftX, y)
        y += 12

        e.Graphics.DrawString("Date: " & Date.Now.ToString("MM/dd/yyyy hh:mm tt"), font, Brushes.Black, leftX, y)
        y += 15

        e.Graphics.DrawString("--------------------------------", font, Brushes.Black, leftX, y)
        y += 12

        ' ===== COLUMN HEADER =====
        e.Graphics.DrawString("ITEM", bold, Brushes.Black, leftX, y)
        e.Graphics.DrawString("TOTAL", bold, Brushes.Black, rightX, y, rightFormat)
        y += 12

        e.Graphics.DrawString("--------------------------------", font, Brushes.Black, leftX, y)
        y += 10

        ' ===== ITEMS =====
        For Each row As DataGridViewRow In dbPOS.Rows
            If row.IsNewRow Then Continue For
            If Convert.ToString(row.Tag) = VOID_TAG Then Continue For

            Dim name As String = row.Cells("ProductName").Value.ToString()
            Dim qty As String = row.Cells("Quantity").Value.ToString()
            Dim total As Decimal = Convert.ToDecimal(row.Cells("TotalPrice").Value)

            ' ITEM NAME (with qty inline)
            e.Graphics.DrawString($"{name} x{qty}", font, Brushes.Black, leftX, y)
            y += 12

            ' TOTAL PRICE aligned right
            e.Graphics.DrawString("₱" & total.ToString("N2"), font, Brushes.Black, rightX, y, rightFormat)
            y += 14
        Next

        e.Graphics.DrawString("--------------------------------", font, Brushes.Black, leftX, y)
        y += 12

        ' ===== TOTALS =====
        e.Graphics.DrawString("VAT:", font, Brushes.Black, leftX, y)
        e.Graphics.DrawString(lblVTotal.Text, font, Brushes.Black, rightX, y, rightFormat)
        y += 12

        e.Graphics.DrawString("TOTAL:", bold, Brushes.Black, leftX, y)
        e.Graphics.DrawString(lblTotal.Text, bold, Brushes.Black, rightX, y, rightFormat)
        y += 18

        e.Graphics.DrawString("CASH:", font, Brushes.Black, leftX, y)
        e.Graphics.DrawString(lblCash.Text, font, Brushes.Black, rightX, y, rightFormat)
        y += 12

        e.Graphics.DrawString("CHANGE:", font, Brushes.Black, leftX, y)
        e.Graphics.DrawString(lblChange.Text, font, Brushes.Black, rightX, y, rightFormat)
        y += 18

        ' ===== FOOTER =====
        e.Graphics.DrawString("================================", font, Brushes.Black, leftX, y)
        y += 12

        e.Graphics.DrawString("Thank you for your purchase!", bold, Brushes.Black, centerX, y, centerFormat)
        y += 12

        e.Graphics.DrawString("Please come again.", font, Brushes.Black, centerX, y, centerFormat)

    End Sub

    ' 🔹 Shared method for opening the payment form
    Private Sub OpenSettlePayment()
        ' 🔹 Prevent checkout if cart is empty OR all items are voided
        Dim hasValidItem As Boolean = False

        For Each row As DataGridViewRow In dbPOS.Rows
            If row.IsNewRow Then Continue For

            If row.Tag Is Nothing OrElse row.Tag.ToString() <> "Voided" Then
                hasValidItem = True
                Exit For
            End If
        Next

        If Not hasValidItem Then
            MessageBox.Show("No valid items to process. All items are voided.",
                    "Cannot Proceed", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If

        ' 🚫 Prevent settlement if quantities are still reflective stock
        For Each row As DataGridViewRow In dbPOS.Rows
            If row.IsNewRow Then Continue For
            If Convert.ToString(row.Tag) = VOID_TAG Then Continue For

            Dim code As String = row.Cells("ProductCode").Value.ToString()
            Dim qtyInPOS As Integer = CInt(row.Cells("Quantity").Value)

            Dim actualStock As Integer = 0
            Dim piecesPerBox As Integer = 1
            Dim unit As String = ""

            Using cmd As New MySqlCommand("
            SELECT StockQty, DefaultUnit, PiecesPerBox
            FROM products1
            WHERE ProductCode=@code", conn)

                If conn.State = ConnectionState.Closed Then conn.Open()

                cmd.Parameters.AddWithValue("@code", code)

                Using r = cmd.ExecuteReader()
                    If r.Read() Then
                        actualStock = CInt(r("StockQty"))
                        unit = r("DefaultUnit").ToString()

                        If Not IsDBNull(r("PiecesPerBox")) Then
                            piecesPerBox = CInt(r("PiecesPerBox"))
                        End If
                    End If
                End Using
            End Using

            Dim reflectiveQty As Integer = actualStock

            If unit.ToLower.Contains("box") AndAlso piecesPerBox > 0 Then
                reflectiveQty = actualStock \ piecesPerBox
            End If

            ' If unchanged, user has not edited quantity yet
            If qtyInPOS = reflectiveQty Then
                MessageBox.Show(
            "Please edit purchase quantity before settling for item: " &
            row.Cells("ProductName").Value.ToString(),
            "Quantity Not Set",
            MessageBoxButtons.OK,
            MessageBoxIcon.Warning)
                Return
            End If
        Next

        ' 🔹 Parse total amount
        Dim amountDue As Decimal
        If Not Decimal.TryParse(lblTotal.Text, NumberStyles.Currency, New CultureInfo("en-PH"), amountDue) Then
            MessageBox.Show("Invalid amount format.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return
        End If

        ' 🔹 Open payment form
        Dim frm As New Payment() With {.AmountDue = amountDue}

        If frm.ShowDialog() = DialogResult.OK Then
            If frm.CashGiven <= 0 Then Exit Sub

            lblCash.Text = frm.CashGiven.ToString("C2", New CultureInfo("en-PH"))
            lblChange.Text = frm.ChangeAmount.ToString("C2", New CultureInfo("en-PH"))

            isPaymentCompleted = True

            Dim transactionNo As String = lblTransactionNo.Text

            Try
                If conn.State = ConnectionState.Closed Then conn.Open()
                Using trans As MySqlTransaction = conn.BeginTransaction()
                    Try
                        ' 🔹 Insert sale header
                        Using cmdSale As New MySqlCommand("
                        INSERT INTO sales2 (TransactionNo, SaleDate, TotalAmount)
                        VALUES (@tno, NOW(), @total)", conn, trans)
                            cmdSale.Parameters.AddWithValue("@tno", transactionNo)
                            cmdSale.Parameters.AddWithValue("@total", amountDue)
                            cmdSale.ExecuteNonQuery()
                        End Using

                        ' 🔹 Get SaleID
                        Dim saleId As Integer
                        Using cmdId As New MySqlCommand("SELECT LAST_INSERT_ID()", conn, trans)
                            saleId = Convert.ToInt32(cmdId.ExecuteScalar())
                        End Using

                        ' 🔹 Loop through cart items
                        For Each row As DataGridViewRow In dbPOS.Rows
                            If row.IsNewRow Then Continue For

                            Dim isVoided As Integer = If(row.Tag IsNot Nothing AndAlso row.Tag.ToString() = "Voided", 1, 0)
                            Dim code As String = row.Cells("ProductCode").Value.ToString()
                            Dim qty As Integer = Convert.ToInt32(row.Cells("Quantity").Value)
                            Dim price As Decimal = Convert.ToDecimal(row.Cells("Price").Value)
                            Dim total As Decimal = Convert.ToDecimal(row.Cells("TotalPrice").Value)

                            ' 🔹 Get selected unit from POS grid (if any)
                            Dim selectedUnit As String = "Piece"
                            If dbPOS.Columns.Contains("Unit") AndAlso row.Cells("Unit").Value IsNot Nothing Then
                                selectedUnit = row.Cells("Unit").Value.ToString()
                            End If

                            ' 🔹 Fetch product details
                            Dim productId As Integer = 0
                            Dim piecesPerBox As Integer = 1
                            Dim currentStock As Integer = 0

                            Using cmdGet As New MySqlCommand("
                            SELECT ProductID, PiecesPerBox, StockQty
                            FROM products1
                            WHERE ProductCode = @code", conn, trans)
                                cmdGet.Parameters.AddWithValue("@code", code)
                                Using r = cmdGet.ExecuteReader()
                                    If r.Read() Then
                                        productId = Convert.ToInt32(r("ProductID"))
                                        Integer.TryParse(r("PiecesPerBox").ToString(), piecesPerBox)
                                        Integer.TryParse(r("StockQty").ToString(), currentStock)
                                    End If
                                End Using
                            End Using

                            ' 🔹 Compute deduction quantity (convert if Box)
                            Dim deductQty As Integer = qty
                            If selectedUnit.ToLower().Contains("box") AndAlso piecesPerBox > 0 Then
                                deductQty = qty * piecesPerBox
                            End If

                            ' 🚫 Prevent negative stock
                            If currentStock < deductQty Then
                                MessageBox.Show($"Insufficient stock for {code}." & vbCrLf &
                                            $"Available: {currentStock} pcs" & vbCrLf &
                                            $"Required: {deductQty} pcs",
                                            "Stock Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                                trans.Rollback()
                                conn.Close()
                                Return
                            End If

                            ' 🔹 Insert sale item
                            Using cmdItem As New MySqlCommand("
                            INSERT INTO sales_items (SaleID, ProductID, Quantity, Price, SubTotal, IsVoided)
                            VALUES (@saleid, @pid, @qty, @price, @total, @isvoid)", conn, trans)
                                cmdItem.Parameters.AddWithValue("@saleid", saleId)
                                cmdItem.Parameters.AddWithValue("@pid", productId)
                                cmdItem.Parameters.AddWithValue("@qty", qty)
                                cmdItem.Parameters.AddWithValue("@price", price)
                                cmdItem.Parameters.AddWithValue("@total", total)
                                cmdItem.Parameters.AddWithValue("@isvoid", isVoided)
                                cmdItem.ExecuteNonQuery()
                            End Using

                            ' 🔹 Deduct stock
                            If isVoided = 0 Then
                                Using cmdStock As New MySqlCommand("
                            UPDATE products1
                            SET StockQty = StockQty - @qty
                            WHERE ProductID = @pid", conn, trans)
                                    cmdStock.Parameters.AddWithValue("@qty", deductQty)
                                    cmdStock.Parameters.AddWithValue("@pid", productId)
                                    cmdStock.ExecuteNonQuery()
                                End Using
                            End If

                        Next

                        ' ✅ Commit transaction
                        trans.Commit()

                        MessageBox.Show("Transaction Complete." & vbCrLf &
                                    "Transaction No: " & transactionNo,
                                    "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)


                    Catch ex As Exception
                        trans.Rollback()
                        MessageBox.Show("Error saving sale: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    End Try
                End Using
            Catch ex As Exception
                MessageBox.Show("Database error: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Finally
                conn.Close()
            End Try

            PrintReceipt()

            ' 🔹 Disable controls after successful sale
            btnEdit.Enabled = False
            btnSettle.Enabled = False
            isTransactionActive = False
            txtBarcode.Clear()
        End If
    End Sub

    Public Sub LoadPendingTransaction(pendingID As Integer)
        Try
            If conn.State = ConnectionState.Closed Then conn.Open()

            ' STEP 1: Get the Transaction Number from pending_sales
            Dim getTransNoQuery As String = "SELECT TransactionNo FROM pending_sales WHERE PendingID = @PendingID"
            Dim transNo As String = ""

            Using cmdGetTrans As New MySqlCommand(getTransNoQuery, conn)
                cmdGetTrans.Parameters.AddWithValue("@PendingID", pendingID)
                Dim result = cmdGetTrans.ExecuteScalar()
                If result IsNot Nothing Then
                    transNo = result.ToString()
                End If
            End Using

            ' STEP 2: Load pending items
            Dim sql As String = "
                SELECT 
                    p.ProductID,
                    p.ProductCode,
                    p.ProductName,
                    pi.Description,
                    CASE 
                        WHEN p.DefaultUnit = 'Box' THEN CONCAT('Box (', p.PiecesPerBox, ' pcs)')
                        ELSE 'Piece'
                    END AS UnitDisplay,
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

                Using reader As MySqlDataReader = cmd.ExecuteReader()
                    ' 🧹 Clear POS table before loading
                    dbPOS.Rows.Clear()

                    ' 🪙 Currency formatting
                    Dim phCulture As New CultureInfo("en-PH")
                    dbPOS.Columns("Price").DefaultCellStyle.FormatProvider = phCulture
                    dbPOS.Columns("Price").DefaultCellStyle.Format = "C2"
                    dbPOS.Columns("TotalPrice").DefaultCellStyle.FormatProvider = phCulture
                    dbPOS.Columns("TotalPrice").DefaultCellStyle.Format = "C2"

                    ' 🧾 Add rows one by one
                    While reader.Read()
                        Dim productId As Integer = Convert.ToInt32(reader("ProductID"))
                        Dim code As String = reader("ProductCode").ToString()
                        Dim name As String = reader("ProductName").ToString()
                        Dim unitDisplay As String = reader("UnitDisplay").ToString()
                        Dim qty As Decimal = Convert.ToDecimal(reader("Quantity"))
                        Dim price As Decimal = Convert.ToDecimal(reader("Price"))
                        Dim totalPrice As Decimal = qty * price
                        Dim desc As String = reader("Description").ToString()

                        Dim idx As Integer = dbPOS.Rows.Add(
                            productId,
                            code,
                            name,
                            desc,
                            unitDisplay,
                            qty,
                            price,
                            totalPrice
                        )

                        If Convert.ToInt32(reader("IsVoided")) = 1 Then
                            dbPOS.Rows(idx).Tag = VOID_TAG
                            dbPOS.Rows(idx).DefaultCellStyle.ForeColor = Color.Red
                            dbPOS.Rows(idx).DefaultCellStyle.Font =
                            New Font(dbPOS.Font, FontStyle.Strikeout)
                        End If

                    End While
                End Using
            End Using

            ' STEP 3: Restore Transaction Number (if found)
            If Not String.IsNullOrEmpty(transNo) Then
                lblTransactionNo.Text = transNo
            End If

            ' STEP 4: Reset VAT, Cash, and Change display
            lblVTotal.Text = "₱0.00"
            lblCash.Text = "₱0.00"
            lblChange.Text = "₱0.00"

            ' STEP 5: Recalculate totals
            UpdateTotals()

        Catch ex As Exception
            MessageBox.Show("Error loading pending transaction: " & ex.Message,
                        "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            If conn.State = ConnectionState.Open Then conn.Close()
        End Try
    End Sub

    Private Sub btnSettle_Click(sender As Object, e As EventArgs) Handles btnSettle.Click
        OpenSettlePayment()
        txtBarcode.Focus()
    End Sub

    Private Sub btnEdit_Click(sender As Object, e As EventArgs) Handles btnEdit.Click
        If dbPOS.CurrentRow Is Nothing Then
            MessageBox.Show("Please select an item to edit.", "Warning",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If

        Dim row As DataGridViewRow = dbPOS.CurrentRow
        If Convert.ToString(row.Tag) = VOID_TAG Then
            MessageBox.Show("Voided items cannot be edited.",
                    "Edit Blocked",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning)
            Return
        End If
        Dim productCode As String = row.Cells("ProductCode").Value.ToString()
        Dim unitDisplay As String = row.Cells("Unit").Value.ToString()
        Dim price As Decimal = Convert.ToDecimal(row.Cells("Price").Value)
        Dim productID As Integer = Convert.ToInt32(row.Cells("ProductID").Value)

        ' Open edit quantity form
        Dim frm As New EditQty()
        frm.ProductID = productID
        frm.SelectedUnit = unitDisplay  ' Pass the current unit text to EditQty

        If frm.ShowDialog() = DialogResult.OK Then
            ' Update the DataGridView row with new quantity and total
            row.Cells("Quantity").Value = frm.NewQuantity
            row.Cells("TotalPrice").Value = frm.NewQuantity * price

            ' Refresh total computation
            UpdateTotals()
        End If
        txtBarcode.Focus()
    End Sub

    Private Sub btnTransact_Click(sender As Object, e As EventArgs) Handles btnTransact.Click
        ' Clear the cart
        dbPOS.Rows.Clear()

        ' Reset totals and payment labels
        lblVTotal.Text = "₱0.00"
        lblTotal.Text = "₱0.00"
        lblCash.Text = "₱0.00"
        lblChange.Text = "₱0.00"

        ' Generate a new Transaction Number (used for both Pending & Finalized Sales)
        Dim newTransNo As String = DateTime.Now.ToString("yyyyMMddHHmmss") & "-" & New Random().Next(1000, 9999)
        lblTransactionNo.Text = newTransNo

        ' Re-enable buttons for the next transaction
        btnSettle.Enabled = True
        btnEdit.Enabled = True

        ' Focus the barcode textbox for the next scan
        isTransactionActive = True
        txtBarcode.Enabled = True
        txtBarcode.Clear()
        txtBarcode.Focus()

        isPaymentCompleted = False
    End Sub

    Private Sub btnHist_Click(sender As Object, e As EventArgs) Handles btnHist.Click
        Dim frm As New Transhist()
        frm.ShowDialog()
    End Sub

    Private Sub btnVoid_Click(sender As Object, e As EventArgs) Handles btnVoid.Click

        If Not isTransactionActive Then
            MessageBox.Show("Cannot void items after transaction is completed. Start a new transaction first.",
                        "Action Not Allowed", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If

        If dbPOS.CurrentRow Is Nothing Then
            MessageBox.Show("Please select an item to void.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If

        Dim row As DataGridViewRow = dbPOS.CurrentRow

        If Convert.ToString(row.Tag) = VOID_TAG Then
            MessageBox.Show("Item is already voided.",
                    "Already Voided",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning)
            Return
        End If

        Dim productName As String = row.Cells("ProductName").Value.ToString()
        Dim qty As Integer = Convert.ToInt32(row.Cells("Quantity").Value)

        ' 🚫 Prevent voiding if quantity is still reflective stock
        Dim code As String = row.Cells("ProductCode").Value.ToString()

        Dim actualStock As Integer = 0
        Dim piecesPerBox As Integer = 1
        Dim unit As String = ""

        Using cmd As New MySqlCommand("
            SELECT StockQty, DefaultUnit, PiecesPerBox
            FROM products1
            WHERE ProductCode=@code", conn)

            If conn.State = ConnectionState.Closed Then conn.Open()

            cmd.Parameters.AddWithValue("@code", code)

            Using r = cmd.ExecuteReader()
                If r.Read() Then
                    actualStock = CInt(r("StockQty"))
                    unit = r("DefaultUnit").ToString()

                    If Not IsDBNull(r("PiecesPerBox")) Then
                        piecesPerBox = CInt(r("PiecesPerBox"))
                    End If
                End If
            End Using
        End Using

        Dim reflectiveQty As Integer = actualStock

        If unit.ToLower.Contains("box") AndAlso piecesPerBox > 0 Then
            reflectiveQty = actualStock \ piecesPerBox
        End If

        If qty = reflectiveQty Then
            MessageBox.Show(
        "Please edit purchase quantity before voiding this item.",
        "Quantity Not Set",
        MessageBoxButtons.OK,
        MessageBoxIcon.Warning)
            Return
        End If

        Dim confirm = MessageBox.Show(
        $"Are you sure you want to void this item?" & vbCrLf &
        $"{productName} x {qty}",
        "Confirm Void",
        MessageBoxButtons.YesNo,
        MessageBoxIcon.Question
    )

        If confirm = DialogResult.No Then Exit Sub

        ' Mark visually
        row.DefaultCellStyle.ForeColor = System.Drawing.Color.Red
        row.DefaultCellStyle.Font = New Font(dbPOS.Font, FontStyle.Strikeout)

        ' Mark logically (NO DATABASE YET)
        row.Tag = VOID_TAG

        MessageBox.Show($"{productName} marked as voided.", "Item Voided", MessageBoxButtons.OK, MessageBoxIcon.Information)
        UpdateTotals()
    End Sub

    Private Sub btnPedro_Click(sender As Object, e As EventArgs) Handles btnPedro.Click
        Dim pendingForm As New Pending()
        pendingForm.ShowDialog()
        txtBarcode.Focus()
    End Sub

    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        ' Prevent saving if there’s nothing in the POS grid
        If dbPOS.Rows.Count = 0 Then
            MessageBox.Show("No items to save as pending.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Exit Sub
        End If

        ' Prevent saving if transaction already settled (finished)
        If isPaymentCompleted Then
            MessageBox.Show("This transaction has already been settled and cannot be saved as pending.",
                        "Invalid Operation", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Exit Sub
        End If

        ' Ensure a valid Transaction Number exists
        If String.IsNullOrWhiteSpace(lblTransactionNo.Text) Or lblTransactionNo.Text = "0" Then
            MessageBox.Show("No Transaction Number found. Please start a new transaction first.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        End If

        Try
            If conn.State = ConnectionState.Closed Then conn.Open()

            Using trans As MySqlTransaction = conn.BeginTransaction()
                ' Save main pending transaction
                Dim insertPendingSql As String = "
                INSERT INTO pending_sales (TransactionNo, TotalAmount)
                VALUES (@TransactionNo, @TotalAmount);
                SELECT LAST_INSERT_ID();"
                Dim pendingID As Integer

                Using cmd As New MySqlCommand(insertPendingSql, conn, trans)
                    Dim totalValue As Decimal = 0
                    Decimal.TryParse(lblTotal.Text.Replace("₱", "").Replace(",", "").Trim(), totalValue)
                    cmd.Parameters.AddWithValue("@TransactionNo", lblTransactionNo.Text)
                    cmd.Parameters.AddWithValue("@TotalAmount", totalValue)
                    pendingID = Convert.ToInt32(cmd.ExecuteScalar())
                End Using

                ' Save each POS item correctly
                For Each row As DataGridViewRow In dbPOS.Rows
                    If row.IsNewRow Then Continue For

                    Dim productCode As String = row.Cells("ProductCode").Value.ToString().Trim()
                    Dim productID As Integer

                    ' Lookup ProductID from ProductCode
                    Using lookupCmd As New MySqlCommand("SELECT ProductID FROM products1 WHERE ProductCode = @code", conn, trans)
                        lookupCmd.Parameters.AddWithValue("@code", productCode)
                        Dim result = lookupCmd.ExecuteScalar()
                        If result Is Nothing Then
                            Throw New Exception($"Product '{productCode}' not found in products1 table.")
                        End If
                        productID = Convert.ToInt32(result)
                    End Using

                    ' Parse Quantity & Price safely
                    Dim qtyValue As Decimal = 0
                    Decimal.TryParse(row.Cells("Quantity").Value.ToString().Replace(",", "").Trim(), qtyValue)

                    Dim priceValue As Decimal = 0
                    Decimal.TryParse(row.Cells("Price").Value.ToString().Replace("₱", "").Replace(",", "").Trim(), priceValue)

                    Dim isVoided As Integer =
                    If(row.Tag IsNot Nothing AndAlso row.Tag.ToString() = VOID_TAG, 1, 0)

                    ' Insert pending item
                    Dim insertItemSql As String = "
                    INSERT INTO pending_items
                    (PendingID, ProductID, Description, Quantity, Price, IsVoided)
                    VALUES
                    (@PendingID, @ProductID, @Description, @Quantity, @Price, @IsVoided)"
                    Using cmd As New MySqlCommand(insertItemSql, conn, trans)
                        cmd.Parameters.AddWithValue("@PendingID", pendingID)
                        cmd.Parameters.AddWithValue("@ProductID", productID)
                        cmd.Parameters.AddWithValue("@Description", row.Cells("Description").Value?.ToString().Trim())
                        cmd.Parameters.AddWithValue("@Quantity", qtyValue)
                        cmd.Parameters.AddWithValue("@Price", priceValue)
                        cmd.Parameters.AddWithValue("@IsVoided", isVoided)
                        cmd.ExecuteNonQuery()
                    End Using
                Next

                trans.Commit()
            End Using

            MessageBox.Show("Transaction saved as pending.", "Pending Saved", MessageBoxButtons.OK, MessageBoxIcon.Information)

            ' Clear POS and reset for next transaction
            dbPOS.Rows.Clear()
            lblTotal.Text = "₱0.00"
            lblVTotal.Text = "₱0.00"   ' Clear VAT label
            lblCash.Text = "₱0.00"     ' Reset cash label
            lblChange.Text = "₱0.00"   ' Reset change label
            lblTransactionNo.Text = DateTime.Now.ToString("yyyyMMddHHmmss") & "-" & New Random().Next(1000, 9999)
            txtBarcode.Focus()

        Catch ex As Exception
            MessageBox.Show("Error saving pending transaction: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            If conn.State = ConnectionState.Open Then conn.Close()
        End Try
        txtBarcode.Focus()
    End Sub

    Private Sub btnClose_Click(sender As Object, e As EventArgs) Handles btnClose.Click
        ' 🔥 Refresh Dashboard FIRST (same logic as your SalesRep)
        For Each frm As Form In Application.OpenForms
            If TypeOf frm Is Dashboard Then
                Dim dash As Dashboard = CType(frm, Dashboard)
                dash.RefreshDashboard()
            End If
        Next

        ' Use the already open Interface instead of creating a new one
        If Application.OpenForms().OfType(Of frmInterface).Any() Then
            Dim mainForm As frmInterface = Application.OpenForms().OfType(Of frmInterface).First()
            mainForm.Show()
            mainForm.FadeInForm(mainForm)
            mainForm.ReturnToDashboard()
        End If

        Me.Hide() ' keep POS alive
    End Sub
    Private Sub frmPOS_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        pd.PrinterSettings.PrinterName = "POS-58"
        ' Set initial values
        lblDate.Text = DateTime.Now.ToString("MMMM dd, yyyy")
        lblTime.Text = DateTime.Now.ToString("hh:mm:ss tt")

        ' Start timer for live update
        postime.Start()
    End Sub

    Private Function IsPrinterOffline(printerName As String) As Boolean

        Try
            Dim query As String =
            "SELECT * FROM Win32_Printer WHERE Name = '" &
            printerName.Replace("\", "\\") & "'"

            Using searcher As New ManagementObjectSearcher(query)

                For Each printer As ManagementObject In searcher.Get()

                    Dim workOffline As Boolean = False

                    If printer("WorkOffline") IsNot Nothing Then
                        workOffline = CBool(printer("WorkOffline"))
                    End If

                    Dim status As String = ""

                    If printer("PrinterStatus") IsNot Nothing Then
                        status = printer("PrinterStatus").ToString()
                    End If

                    ' Offline or unavailable
                    If workOffline OrElse status = "7" Then
                        Return True
                    End If

                    Return False

                Next

            End Using

        Catch
            ' If we can't determine the status,
            ' let Windows handle the print normally.
        End Try

        Return False

    End Function

    Private Sub PrintReceipt()

        If MessageBox.Show("Do you want to print a receipt?",
                       "Print Receipt",
                       MessageBoxButtons.YesNo,
                       MessageBoxIcon.Question) = DialogResult.No Then
            Exit Sub
        End If

        Try
            If PrinterSettings.InstalledPrinters.Count = 0 OrElse Not pd.PrinterSettings.IsValid Then
                MessageBox.Show("No printer was detected.",
                            "Printer",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Warning)
                Exit Sub
            End If

            If IsPrinterOffline(pd.PrinterSettings.PrinterName) Then
                MessageBox.Show("The selected printer is offline or unavailable.",
                            "Printer",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Warning)
                Exit Sub
            End If

            pd.Print()

        Catch ex As Exception
            MessageBox.Show("Unable to print the receipt. The printer may be offline, disconnected, or unavailable.",
                        "Printing Failed",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning)
        End Try

    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles postime.Tick
        lblDate.Text = DateTime.Now.ToString("MMMM dd, yyyy")
        lblTime.Text = DateTime.Now.ToString("hh:mm:ss tt")
    End Sub

End Class