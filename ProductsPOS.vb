Imports System.Globalization
Imports MySql.Data.MySqlClient

Public Class ProductsPOS
    Private isEditing As Boolean = False
    Private _reportData As DataTable
    Private barcodeBuffer As String = ""
    Private scanTimer As New Timer()

    Private Sub ProductsPOS(sender As Object, e As EventArgs) Handles MyBase.Load
        If String.IsNullOrWhiteSpace(txtSearch.Text) Then
            txtSearch.Text = "Search"
            txtSearch.ForeColor = System.Drawing.Color.Gray
        End If

        If frmInterface.loggedInType = "Staff" Then
            ' Hide the top action buttons (only keep Search visible)
            btnAddProducts.Visible = False
            btnEditPr.Visible = False
            btnArchivePr.Visible = False

        End If

        LoadProducts()
        AddHandler panelp1.Click, AddressOf FormClicked
        AddHandler panelp2.Click, AddressOf FormClicked
        For Each column As DataGridViewColumn In dbProducts.Columns
            column.SortMode = DataGridViewColumnSortMode.NotSortable
        Next

        ResizeButtonImages()
        Task.Run(Sub()
                     Me.Invoke(New MethodInvoker(AddressOf CheckAndShowStockAlert))
                 End Sub)

        With btnNotif
            .FlatStyle = FlatStyle.Flat
            .FlatAppearance.BorderSize = 0
            .FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent
            .FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent
            .BackColor = System.Drawing.Color.Transparent
            .TabStop = False
        End With

        Me.KeyPreview = True

        scanTimer.Interval = 600
        AddHandler scanTimer.Tick, AddressOf ResetBarcodeBuffer

        Me.KeyPreview = True

    End Sub

    Private Sub ProductsPOS_Activated(sender As Object, e As EventArgs) Handles MyBase.Activated
        Me.Focus()
    End Sub

    Private Sub ProductsPOS_KeyPress(sender As Object, e As KeyPressEventArgs) Handles MyBase.KeyPress
        If TypeOf Me.ActiveControl Is TextBox Then Exit Sub

        barcodeBuffer &= e.KeyChar
        scanTimer.Stop()
        scanTimer.Start()

    End Sub

    Protected Overrides Function ProcessCmdKey(ByRef msg As Message, keyData As Keys) As Boolean

        ' ENTER = finalize scan
        If keyData = Keys.Enter AndAlso barcodeBuffer <> "" Then
            scanTimer.Stop()

            Dim code As String = barcodeBuffer
            barcodeBuffer = ""

            OpenAddProductWithBarcode(code)
            Return True
        End If

        ' 🚫 Do not interfere when typing in textbox (search, inputs, etc.)
        If TypeOf Me.ActiveControl Is TextBox Then
            Return MyBase.ProcessCmdKey(msg, keyData)
        End If

        ' ✔ Accept scanner input (letters + numbers only)
        If (keyData >= Keys.A AndAlso keyData <= Keys.Z) OrElse
       (keyData >= Keys.D0 AndAlso keyData <= Keys.D9) Then

            barcodeBuffer &= ChrW(keyData)
            scanTimer.Stop()
            scanTimer.Start()
            Return True
        End If

        ' 🔥 IMPORTANT: fallback return (fixes warning)
        Return MyBase.ProcessCmdKey(msg, keyData)

    End Function

    Private Sub ResetBarcodeBuffer(sender As Object, e As EventArgs)
        barcodeBuffer = ""
        scanTimer.Stop()
    End Sub

    Private Sub OpenAddProductWithBarcode(code As String)

        Dim frm As New AddProduct()

        frm.callingForm = Me
        frm.isEditMode = False

        ' pass barcode BEFORE showing
        frm.BarcodeValue = code

        frm.ShowDialog()

    End Sub

    Private Sub Products_Shown(sender As Object, e As EventArgs) Handles MyBase.Shown

        lblActiveDate11.Text = DateTime.Now.ToString("dddd, MMMM dd yyyy")
        lblActiveTime11.Text = DateTime.Now.ToString("hh:mm:ss tt")
        lblUsername11.Text = "User: " & frmInterface.loggedInUsername

        Tick1.Start()

        LoadProducts()

        Me.BeginInvoke(New MethodInvoker(Sub()

                                         End Sub))
    End Sub

    Private Sub Tick1_Tick(sender As Object, e As EventArgs) Handles Tick1.Tick
        lblActiveDate11.Text = DateTime.Now.ToString("dddd, MMMM d, yyyy")
        lblActiveTime11.Text = DateTime.Now.ToString("hh:mm:ss tt")
    End Sub

    Private Sub CheckAndShowStockAlert()
        Try
            If conn.State = ConnectionState.Closed Then conn.Open()

            ' --- Count products that are low or out of stock ---
            Dim query As String = "
            SELECT COUNT(*) 
            FROM products1
            WHERE IsArchived = 0
            AND (
                StockQty = 0
                OR (
                    PiecesPerBox > 0 
                    AND (StockQty / PiecesPerBox) <= 30
                )
                OR (
                    (PiecesPerBox = 0 OR PiecesPerBox IS NULL)
                    AND StockQty <= 30
                )
            );"

            Using cmd As New MySqlCommand(query, conn)
                Dim count As Integer = Convert.ToInt32(cmd.ExecuteScalar())

                If count > 0 Then
                    Dim alertForm As New StockAlert()
                    alertForm.TopMost = True
                    alertForm.Show()
                End If
            End Using

        Catch ex As Exception
            MessageBox.Show("Error checking stock alerts: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            If conn.State = ConnectionState.Open Then conn.Close()
        End Try
    End Sub

    Private Sub ResizeButtonImages()
        Dim sidebarButtons As Button() = {btnNotif}

        For Each btn As Button In sidebarButtons
            If btn.Image IsNot Nothing Then

                Dim resizedImage As New Bitmap(btn.Image, 27, 27)
                btn.Image = resizedImage

                ' --- Center image exactly ---
                btn.Text = "" ' ensure no text affects centering
                btn.ImageAlign = ContentAlignment.MiddleCenter
                btn.TextImageRelation = TextImageRelation.Overlay
                btn.Padding = New Padding(0)
                btn.Margin = New Padding(0)
            End If
        Next
    End Sub

    Private Sub ResetSearchWatermark()
        If String.IsNullOrWhiteSpace(txtSearch.Text) Then
            txtSearch.Text = "Search"
            txtSearch.ForeColor = System.Drawing.Color.Gray
        End If
    End Sub

    Private Sub panelTop_MouseDown(sender As Object, e As MouseEventArgs) Handles panelp1.MouseDown
        ResetSearchWatermark()
        Me.ActiveControl = Nothing
    End Sub

    Private Sub panelBottom_MouseDown(sender As Object, e As MouseEventArgs) Handles panelp2.MouseDown
        ResetSearchWatermark()
        Me.ActiveControl = Nothing
    End Sub

    Private Sub FormClicked(sender As Object, e As EventArgs)
        ClearSearch()
    End Sub

    Private Sub ClearSearch()
        If txtSearch.Text <> "Search" Then
            txtSearch.Text = "Search"
            txtSearch.ForeColor = System.Drawing.Color.Gray
            LoadProducts()
        End If
    End Sub

    Private Sub AttachClickEvents(ctrl As Control)

        ' Only attach to containers that are safe (Panels, GroupBoxes, etc.)
        If TypeOf ctrl Is Panel OrElse TypeOf ctrl Is GroupBox Then
            AddHandler ctrl.MouseDown, AddressOf Control_MouseDown
        End If

        ' IMPORTANT: do NOT attach to everything blindly
        ' Skip input controls to avoid focus stealing issues
        If Not TypeOf ctrl Is TextBox AndAlso
       Not TypeOf ctrl Is DataGridView AndAlso
       Not TypeOf ctrl Is ComboBox AndAlso
       Not TypeOf ctrl Is Button Then

            For Each child As Control In ctrl.Controls
                AttachClickEvents(child)
            Next

        End If

    End Sub

    Private Sub Control_MouseDown(sender As Object, e As MouseEventArgs)
        ClearSearch()
    End Sub


    Public Sub LoadProducts()
        Try
            Dim dt As New DataTable()
            Dim query As String = "SELECT ProductID, ProductCode, ProductName, Description, Category, Price, PurchasePrice, Unit, StockQty, ExpiryDate, DateAdded FROM products1 WHERE IsArchived = FALSE"
            Dim da As New MySqlDataAdapter(query, conn)
            da.Fill(dt)

            dbProducts.DataSource = dt

            If dbProducts.Columns.Contains("ExpiryDate") Then
                dbProducts.Columns("ExpiryDate").DefaultCellStyle.NullValue = "No Expiry"
                dbProducts.Columns("ExpiryDate").DefaultCellStyle.Format = "yyyy-MM-dd" ' optional date format
            End If


            dbProducts.Columns("ProductID").Visible = False
            dbProducts.Columns("Unit").Visible = False
            dbProducts.Columns("StockQty").Visible = False
            dbProducts.Columns("DateAdded").Visible = False

            ResizeProductColumns()

            dbProducts.Columns("Price").DefaultCellStyle.Format = "C2"
            dbProducts.Columns("Price").DefaultCellStyle.FormatProvider = Globalization.CultureInfo.CreateSpecificCulture("en-PH")

            dbProducts.Columns("PurchasePrice").DefaultCellStyle.Format = "C2"
            dbProducts.Columns("PurchasePrice").DefaultCellStyle.FormatProvider = Globalization.CultureInfo.CreateSpecificCulture("en-PH")

            With dbProducts
                .Columns("PurchasePrice").HeaderText = "Purchase Price"
            End With

        Catch ex As Exception
            MessageBox.Show("❌ Error loading products: " & ex.Message)
        End Try
    End Sub

    Private Sub SearchProducts(keyword As String)
        Try
            If conn.State = ConnectionState.Closed Then
                conn.Open()
            End If

            Dim query As String = "SELECT ProductId, ProductCode, ProductName, Description, Category, Price, PurchasePrice, Unit, StockQty, ExpiryDate, DateAdded " &
                              "FROM products1 " &
                              "WHERE IsArchived = 0 AND (ProductName LIKE @keyword OR Description LIKE @keyword OR Category LIKE @keyword)"

            Using cmd As New MySqlCommand(query, conn)
                cmd.Parameters.AddWithValue("@keyword", "%" & keyword & "%")

                Using da As New MySqlDataAdapter(cmd)
                    Dim dt As New DataTable()
                    da.Fill(dt)
                    dbProducts.DataSource = dt
                End Using
            End Using

        Catch ex As Exception
            MessageBox.Show("Error searching products: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)

        Finally
            If conn.State = ConnectionState.Open Then
                conn.Close()
            End If
        End Try

    End Sub

    Private Sub ResizeProductColumns()
        With dbProducts
            .Columns("ProductCode").Width = 110
            .Columns("ProductName").Width = 100
            .Columns("Description").Width = 160
            .Columns("Category").Width = 110
            .Columns("Price").Width = 60
            .Columns("PurchasePrice").Width = 85
            .Columns("Unit").Width = 70
            .Columns("StockQty").Width = 70
            .Columns("ExpiryDate").Width = 140
            .Columns("DateAdded").Width = 140
        End With
    End Sub

    Private Sub btnAddProducts_Click(sender As Object, e As EventArgs) Handles btnAddProducts.Click
        Dim addForm As New AddProduct
        addForm.callingForm = Me
        addForm.ShowDialog()
    End Sub

    Private Sub btnEditPr_Click(sender As Object, e As EventArgs) Handles btnEditPr.Click

        If dbProducts.SelectedRows.Count > 0 Then
            Dim editForm As New AddProduct()

            With dbProducts.CurrentRow
                editForm.ProductID = .Cells("ProductID").Value
                editForm.txtPrCode.Text = .Cells("ProductCode").Value.ToString()
                editForm.txtPrName.Text = .Cells("ProductName").Value.ToString()
                editForm.txtDscrpt.Text = .Cells("Description").Value.ToString()
                editForm.cmbCat.Text = .Cells("Category").Value.ToString()
                editForm.txtPrPrice.Text = .Cells("Price").Value.ToString()
                editForm.txtPPrice.Text = .Cells("PurchasePrice").Value.ToString()
                editForm.txtQuant.Text = .Cells("StockQty").Value.ToString()
                If IsDBNull(.Cells("ExpiryDate").Value) OrElse .Cells("ExpiryDate").Value Is Nothing Then
                    editForm.dtExp.CustomFormat = " " ' Show blank
                Else
                    editForm.dtExp.Value = Convert.ToDateTime(.Cells("ExpiryDate").Value)
                    editForm.dtExp.CustomFormat = "yyyy-MM-dd" ' or your preferred format
                End If
            End With

            editForm.btnSavePr.Visible = False
            editForm.btnPrUpdate.Visible = True
            editForm.ShowDialog()

            LoadProducts()
        Else
            MessageBox.Show("Please select a product to edit.")
        End If

    End Sub

    Private Sub txtSearch_TextChanged(sender As Object, e As EventArgs) Handles txtSearch.TextChanged
        If txtSearch.Text = "Search" Or txtSearch.Text.Trim() = "" Then
            LoadProducts()
        Else
            SearchProducts(txtSearch.Text)
        End If
    End Sub

    Private Sub txtSearch_Enter(sender As Object, e As EventArgs) Handles txtSearch.Enter
        If txtSearch.Text = "Search" Then
            txtSearch.Text = ""
            txtSearch.ForeColor = System.Drawing.Color.Black
        End If
    End Sub

    Private Sub txtSearch_Leave(sender As Object, e As EventArgs) Handles txtSearch.Leave
        ResetSearchWatermark()
    End Sub

    Private Sub btnArchivePr_Click(sender As Object, e As EventArgs) Handles btnArchivePr.Click
        If dbProducts.SelectedRows.Count = 0 Then
            MessageBox.Show("Please select a product to archive.")
            Exit Sub
        End If

        Dim result As DialogResult = MessageBox.Show("Are you sure you want to archive this product?", "Confirm Archive", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
        If result = DialogResult.No Then Exit Sub

        Dim selectedRow As DataGridViewRow = dbProducts.SelectedRows(0)
        Dim productId As Integer = Convert.ToInt32(selectedRow.Cells("ProductID").Value)

        Try
            If conn.State = ConnectionState.Closed Then conn.Open()

            Dim query As String = "UPDATE products1 SET IsArchived = TRUE WHERE ProductID = @ProductID"
            Using cmd As New MySqlCommand(query, conn)
                cmd.Parameters.AddWithValue("@ProductID", productId)
                cmd.ExecuteNonQuery()
            End Using

            MessageBox.Show("Product archived successfully!", "Archived", MessageBoxButtons.OK, MessageBoxIcon.Information)
            LoadProducts()
        Catch ex As Exception
            MessageBox.Show("Error archiving product: " & ex.Message)
        End Try

    End Sub

    Private Sub btnNotif_Click(sender As Object, e As EventArgs) Handles btnNotif.Click
        CheckAndShowStockAlert()
    End Sub

End Class