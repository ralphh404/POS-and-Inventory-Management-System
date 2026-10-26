Imports System.Globalization
Imports System.Windows.Forms.VisualStyles.VisualStyleElement.TrackBar
Imports MySql.Data.MySqlClient
Imports Mysqlx.XDevAPI

Public Class InvArchive

    Dim defaultColor As Color = Color.LightSteelBlue
    Dim activeColor As Color = Color.SteelBlue

    Private Sub InvArchives_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        LoadArchivedProducts()
        LoadArchivedSuppliers()

        panelArcProducts.Visible = True
        panelSuppAC.Visible = False

        btnRestorePr.Visible = True
        btnRestoreSp.Visible = False

        txtSearchProd.Text = "Search archived products..."
        txtSearchProd.ForeColor = Color.Gray
        lblClp.Visible = False

        txtSupp.ForeColor = Color.Gray
        txtSupp.Text = "Search archived suppliers..."
        lblCls.Visible = False

        PanelSu.Visible = False

        For Each column As DataGridViewColumn In dbArcProducts.Columns
            column.SortMode = DataGridViewColumnSortMode.NotSortable
        Next

        For Each column As DataGridViewColumn In dbSupplierArc.Columns
            column.SortMode = DataGridViewColumnSortMode.NotSortable
        Next

        With dbArcProducts
            .BackgroundColor = Color.LightSteelBlue

            .EnableHeadersVisualStyles = False
            .ColumnHeadersDefaultCellStyle.BackColor = Color.LightSlateGray
            .ColumnHeadersDefaultCellStyle.ForeColor = Color.White
            .ColumnHeadersDefaultCellStyle.SelectionBackColor = Color.SlateGray

            .DefaultCellStyle.SelectionBackColor = Color.LightGray
            .DefaultCellStyle.SelectionForeColor = Color.Black

            .CellBorderStyle = DataGridViewCellBorderStyle.Single
            .GridColor = Color.Gainsboro
            .ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single

            .AllowUserToOrderColumns = False
            .DefaultCellStyle.Font = New Font("Century Gothic", 9, FontStyle.Regular)
        End With
    End Sub

    Private Sub Products_Shown(sender As Object, e As EventArgs) Handles MyBase.Shown
        lblActiveDate66.Text = DateTime.Now.ToString("dddd, MMMM dd yyyy")
        lblActiveTime66.Text = DateTime.Now.ToString("hh:mm:ss tt")
        lblUsername66.Text = "User: " & frmInterface.loggedInUsername

        Tick6.Start()

        LoadArchivedProducts()
        LoadArchivedSuppliers()
    End Sub

    Private Sub Tick6_Tick(sender As Object, e As EventArgs) Handles Tick6.Tick
        lblActiveDate66.Text = DateTime.Now.ToString("dddd, MMMM d, yyyy")
        lblActiveTime66.Text = DateTime.Now.ToString("hh:mm:ss tt")
    End Sub

    Public Sub LoadArchivedProducts()
        Try
            Dim dt As New DataTable()

            Dim query As String = "
        SELECT 
            ProductID, 
            ProductCode, 
            ProductName, 
            Description, 
            Category, 
            Price, 
            Unit, 
            DefaultUnit,
            StockQty, 
            PiecesPerBox,
            ExpiryDate, 
            DateAdded 
        FROM products1 
        WHERE IsArchived = TRUE"

            Dim da As New MySqlDataAdapter(query, conn)
            da.Fill(dt)

            dt.Columns.Add("StockDisplay", GetType(String))

            For Each row As DataRow In dt.Rows

                Dim stockQty As Integer = Convert.ToInt32(row("StockQty"))
                Dim pcsPerBox As Integer = 0
                Integer.TryParse(row("PiecesPerBox").ToString(), pcsPerBox)

                Dim defaultUnit As String = row("DefaultUnit").ToString().ToLower()


                If defaultUnit.Contains("piece") OrElse pcsPerBox = 0 Then

                    row("StockDisplay") = $"{stockQty} Piece(s)"

                ElseIf defaultUnit.Contains("box") AndAlso pcsPerBox > 0 Then


                    Dim boxes As Integer = stockQty \ pcsPerBox
                    Dim pieces As Integer = stockQty Mod pcsPerBox

                    row("StockDisplay") = $"{boxes} Box(es) ({pcsPerBox} pcs)"

                    If pieces > 0 Then
                        row("StockDisplay") &= $" + {pieces} pcs"
                    End If

                Else

                    ' fallback safety
                    row("StockDisplay") = $"{stockQty} Piece(s)"

                End If

            Next

            dbArcProducts.DataSource = dt
            dbArcProducts.MultiSelect = False
            ResizeArcProductColumns()

            dbArcProducts.Columns("StockDisplay").HeaderText = "Stock Info"

            dbArcProducts.Columns("ProductID").Visible = False
            dbArcProducts.Columns("StockQty").Visible = False
            dbArcProducts.Columns("PiecesPerBox").Visible = False
            dbArcProducts.Columns("Unit").Visible = False
            dbArcProducts.Columns("DefaultUnit").Visible = False

            dbArcProducts.Columns("Price").DefaultCellStyle.Format = "C2"
            dbArcProducts.Columns("Price").DefaultCellStyle.FormatProvider =
            CultureInfo.CreateSpecificCulture("en-PH")

        Catch ex As Exception
            MessageBox.Show("⚠ Error loading archived products: " & ex.Message)
        End Try
    End Sub

    Private Sub SearchArchivedProducts()

        If dbArcProducts.DataSource Is Nothing Then Exit Sub

        Dim dt As DataTable = CType(dbArcProducts.DataSource, DataTable)
        Dim dv As DataView = dt.DefaultView

        Dim keyword As String = txtSearchProd.Text.Trim

        ' Ignore the watermark
        If keyword = "Search archived products..." Then
            keyword = ""
        End If

        keyword = keyword.Replace("'", "''")

        If keyword = "" Then
            dv.RowFilter = ""
        Else
            dv.RowFilter =
            $"ProductCode LIKE '%{keyword}%' OR " &
            $"ProductName LIKE '%{keyword}%' OR " &
            $"Description LIKE '%{keyword}%' OR " &
            $"Category LIKE '%{keyword}%' OR " &
            $"StockDisplay LIKE '%{keyword}%'"
        End If

    End Sub

    Private Sub txtSearchProd_TextChanged(sender As Object, e As EventArgs) Handles txtSearchProd.TextChanged
        SearchArchivedProducts()
        lblClp.Visible = (txtSearchProd.ForeColor = Color.Black AndAlso txtSearchProd.Text.Trim <> "")

    End Sub

    Private Sub txtSearchProd_Enter(sender As Object, e As EventArgs) Handles txtSearchProd.Enter

        If txtSearchProd.ForeColor = Color.Gray Then
            txtSearchProd.Clear()
            txtSearchProd.ForeColor = Color.Black
        End If

    End Sub

    Private Sub txtSearchProd_Leave(sender As Object, e As EventArgs) Handles txtSearchProd.Leave

        If txtSearchProd.Text.Trim = "" Then
            txtSearchProd.Text = "Search archived products..."
            txtSearchProd.ForeColor = Color.Gray

            lblClp.Visible = False
        End If

    End Sub

    Private Sub lblClp_Click(sender As Object, e As EventArgs) Handles lblClp.Click

        txtSearchProd.Clear()
        txtSearchProd.Focus()

    End Sub

    Public Sub LoadArchivedSuppliers()
        Try
            If conn.State = ConnectionState.Open Then conn.Close()
            conn.Open()

            Dim query As String = "SELECT SupplierID, SupplierName, ContactName, Email, Phone, Address FROM suppliers1 WHERE is_Archived = TRUE"
            Dim cmd As New MySqlCommand(query, conn)
            Dim da As New MySqlDataAdapter(cmd)
            Dim dt As New DataTable()
            da.Fill(dt)

            dbSupplierArc.DataSource = dt

            If dbSupplierArc.Columns.Contains("SupplierID") Then
                dbSupplierArc.Columns("SupplierID").Visible = False
            End If

            conn.Close()

        Catch ex As Exception
            MessageBox.Show("Error loading archived suppliers: " & ex.Message, "Load Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            If conn.State = ConnectionState.Open Then conn.Close()
        End Try
    End Sub

    Private Sub SearchArchivedSuppliers()

        If dbSupplierArc.DataSource Is Nothing Then Exit Sub

        Dim dt As DataTable = CType(dbSupplierArc.DataSource, DataTable)
        Dim dv As DataView = dt.DefaultView

        Dim keyword As String = txtSupp.Text.Trim

        ' Ignore the watermark
        If keyword = "Search archived suppliers..." Then
            keyword = ""
        End If

        keyword = keyword.Replace("'", "''")

        If keyword = "" Then
            dv.RowFilter = ""
        Else
            dv.RowFilter =
            $"SupplierName LIKE '%{keyword}%' OR " &
            $"ContactName LIKE '%{keyword}%' OR " &
            $"Email LIKE '%{keyword}%' OR " &
            $"Phone LIKE '%{keyword}%' OR " &
            $"Address LIKE '%{keyword}%'"
        End If

    End Sub

    Private Sub txtSupp_TextChanged(sender As Object, e As EventArgs) Handles txtSupp.TextChanged

        SearchArchivedSuppliers()

        lblCls.Visible = (txtSupp.ForeColor = Color.Black AndAlso txtSupp.Text.Trim <> "")

    End Sub

    Private Sub txtSupp_Enter(sender As Object, e As EventArgs) Handles txtSupp.Enter

        If txtSupp.ForeColor = Color.Gray Then
            txtSupp.Clear()
            txtSupp.ForeColor = Color.Black
        End If

    End Sub

    Private Sub txtSupp_Leave(sender As Object, e As EventArgs) Handles txtSupp.Leave

        If txtSupp.Text.Trim = "" Then
            txtSupp.Text = "Search archived suppliers..."
            txtSupp.ForeColor = Color.Gray

            lblCls.Visible = False
        End If

    End Sub

    Private Sub lblCls_Click(sender As Object, e As EventArgs) Handles lblCls.Click

        txtSupp.Clear()
        txtSupp.Focus()

    End Sub

    Private Sub ResizeArcProductColumns()
        With dbArcProducts
            .Columns("ProductCode").Width = 180
            .Columns("ProductName").Width = 175
            .Columns("Description").Width = 300
            .Columns("Category").Width = 180
            .Columns("Price").Width = 160
            .Columns("Unit").Width = 70
            .Columns("StockDisplay").Width = 100
            .Columns("ExpiryDate").Width = 140
            .Columns("DateAdded").Width = 160
        End With
    End Sub

    Private Sub btnRestorePr_Click(sender As Object, e As EventArgs) Handles btnRestorePr.Click
        If dbArcProducts.SelectedRows.Count = 0 Then
            MessageBox.Show("Please select at least one product to restore.", "No Selection", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Exit Sub
        End If

        If MessageBox.Show("Are you sure you want to restore the selected product(s)?",
                           "Confirm Restore",
                           MessageBoxButtons.YesNo,
                           MessageBoxIcon.Question) = DialogResult.Yes Then

            Try
                If conn.State = ConnectionState.Closed Then conn.Open()

                For Each row As DataGridViewRow In dbArcProducts.SelectedRows
                    Dim productId As Integer = Convert.ToInt32(row.Cells("ProductID").Value)

                    Dim query As String = "UPDATE products1 SET IsArchived = FALSE WHERE ProductID = @ProductID"
                    Dim cmd As New MySqlCommand(query, conn)
                    cmd.Parameters.AddWithValue("@ProductID", productId)
                    cmd.ExecuteNonQuery()
                Next

                MessageBox.Show("Selected products restored successfully!", "Restored", MessageBoxButtons.OK, MessageBoxIcon.Information)
                LoadArchivedProducts()

            Catch ex As Exception
                MessageBox.Show("⚠ Error restoring product: " & ex.Message)
            End Try
        End If
    End Sub

    Private Sub btnProdAc_Click(sender As Object, e As EventArgs) Handles btnProdAc.Click
        panelArcProducts.Visible = True
        panelSuppAC.Visible = False

        btnProdAc.BackColor = activeColor
        btnSupAc.BackColor = defaultColor

        btnRestorePr.Visible = True
        btnRestoreSp.Visible = False

        PanelPo.Visible = True
        PanelSu.Visible = False
    End Sub

    Private Sub btnSupAc_Click(sender As Object, e As EventArgs) Handles btnSupAc.Click
        panelArcProducts.Visible = False
        panelSuppAC.Visible = True

        btnSupAc.BackColor = activeColor
        btnProdAc.BackColor = defaultColor

        btnRestoreSp.Visible = True
        btnRestorePr.Visible = False

        PanelSu.Visible = True
        PanelPo.Visible = False
    End Sub

    Private Sub btnRestoreSp_Click(sender As Object, e As EventArgs) Handles btnRestoreSp.Click
        If dbSupplierArc.SelectedRows.Count = 0 Then
            MessageBox.Show("Please select at least one supplier to restore.", "No Selection", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Exit Sub
        End If

        If MessageBox.Show("Are you sure you want to restore the selected supplier(s)?",
                           "Confirm Restore",
                           MessageBoxButtons.YesNo,
                           MessageBoxIcon.Question) = DialogResult.Yes Then

            Try
                If conn.State = ConnectionState.Closed Then conn.Open()

                For Each row As DataGridViewRow In dbSupplierArc.SelectedRows
                    Dim supplierId As Integer = Convert.ToInt32(row.Cells("SupplierID").Value)

                    Dim query As String = "UPDATE suppliers1 SET is_Archived = FALSE WHERE SupplierID = @SupplierID"
                    Using cmd As New MySqlCommand(query, conn)
                        cmd.Parameters.AddWithValue("@SupplierID", supplierId)
                        cmd.ExecuteNonQuery()
                    End Using
                Next

                MessageBox.Show("Selected supplier(s) restored successfully!", "Restored", MessageBoxButtons.OK, MessageBoxIcon.Information)
                LoadArchivedSuppliers()

            Catch ex As Exception
                MessageBox.Show("⚠ Error restoring suppliers: " & ex.Message)
            Finally
                If conn.State = ConnectionState.Open Then conn.Close()
            End Try
        End If
    End Sub

End Class