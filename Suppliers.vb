Imports System.Windows.Forms.VisualStyles.VisualStyleElement.TrackBar
Imports MySql.Data.MySqlClient

Public Class Suppliers

    Private Sub Suppliers_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        LoadSuppliers()

        If String.IsNullOrWhiteSpace(txtSearchSupp.Text) Then
            txtSearchSupp.Text = "Search"
            txtSearchSupp.ForeColor = Color.Gray
        End If

        lblCls.Visible = False  ' hide clear label at start

        For Each column As DataGridViewColumn In dbSuppliers.Columns
            column.SortMode = DataGridViewColumnSortMode.NotSortable
        Next
    End Sub

    Private Sub Categories_Shown(sender As Object, e As EventArgs) Handles MyBase.Shown

        lblActiveDate33.Text = DateTime.Now.ToString("dddd, MMMM dd yyyy")
        lblActiveTime33.Text = DateTime.Now.ToString("hh:mm:ss tt")
        lblUsername33.Text = "User: " & frmInterface.loggedInUsername

        Tick3.Start()

        LoadSuppliers()
    End Sub

    Private Sub Tick3_Tick(sender As Object, e As EventArgs) Handles Tick3.Tick
        lblActiveDate33.Text = DateTime.Now.ToString("dddd, MMMM d, yyyy")
        lblActiveTime33.Text = DateTime.Now.ToString("hh:mm:ss tt")
    End Sub

    Public Sub LoadSuppliers()
        Try
            If conn.State = ConnectionState.Closed Then
                conn.Open()
            End If

            Dim query As String = "SELECT SupplierID, SupplierName, ContactName, Email, Phone, Address FROM suppliers1 WHERE is_Archived = FALSE"
            Dim cmd As New MySqlCommand(query, conn)
            Dim da As New MySqlDataAdapter(cmd)
            Dim dt As New DataTable()

            da.Fill(dt)
            dbSuppliers.DataSource = dt
            dbSuppliers.Columns("SupplierID").Visible = False

            conn.Close()
        Catch ex As Exception
            MessageBox.Show("Error loading suppliers: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            If conn.State = ConnectionState.Open Then conn.Close()
        End Try
    End Sub

    Public Sub SearchSuppliers(keyword As String)
        Try
            Connect()

            Dim query As String = "SELECT SupplierID, SupplierName, ContactName, Email, Phone, Address 
                               FROM suppliers1 
                               WHERE is_Archived = 0 
                               AND (SupplierName LIKE @search 
                                    OR ContactName LIKE @search 
                                    OR Email LIKE @search)"

            Dim cmd As New MySqlCommand(query, conn)
            cmd.Parameters.AddWithValue("@search", "%" & keyword & "%")

            Dim adapter As New MySqlDataAdapter(cmd)
            Dim dt As New DataTable()
            adapter.Fill(dt)

            dbSuppliers.DataSource = dt

        Catch ex As Exception
            MessageBox.Show("Error searching suppliers: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            Disconnect()
        End Try
    End Sub

    Private Sub txtSearchSupp_TextChanged(sender As Object, e As EventArgs) Handles txtSearchSupp.TextChanged
        If txtSearchSupp.Text = "Search" OrElse String.IsNullOrWhiteSpace(txtSearchSupp.Text) Then
            lblCls.Visible = False
        Else
            lblCls.Visible = True
        End If

        ' Search logic
        If txtSearchSupp.Text = "Search" Then
            LoadSuppliers()
        ElseIf String.IsNullOrWhiteSpace(txtSearchSupp.Text) Then
            LoadSuppliers()
        Else
            SearchSuppliers(txtSearchSupp.Text.Trim())
        End If
    End Sub

    Private Sub txtSearch_Enter(sender As Object, e As EventArgs) Handles txtSearchSupp.Enter
        If txtSearchSupp.Text = "Search" Then
            txtSearchSupp.Text = ""
            txtSearchSupp.ForeColor = Color.Black
        End If
    End Sub

    Private Sub txtSearch_Leave(sender As Object, e As EventArgs) Handles txtSearchSupp.Leave
        If String.IsNullOrWhiteSpace(txtSearchSupp.Text) Then
            txtSearchSupp.Text = "Search"
            txtSearchSupp.ForeColor = Color.Gray
        End If
    End Sub

    Private Sub lblCls_Click(sender As Object, e As EventArgs) Handles lblCls.Click
        ' Clear search input
        txtSearchSupp.Clear()
        LoadSuppliers() ' reset accounts

        ' If the box is not focused, reapply watermark immediately
        If Not txtSearchSupp.Focused Then
            txtSearchSupp.Text = "Search"
            txtSearchSupp.ForeColor = Color.Gray
        End If
    End Sub

    Private Sub btnAddSupp_Click(sender As Object, e As EventArgs) Handles btnAddSupp.Click
        Dim addForm As New AddSuppliers()
        addForm.isEdit = False
        addForm.ShowDialog()

        LoadSuppliers()
    End Sub

    Private Sub btnEditSp_Click(sender As Object, e As EventArgs) Handles btnEditSp.Click
        If dbSuppliers.SelectedRows.Count > 0 Then
            Dim editForm As New AddSuppliers()
            editForm.isEdit = True

            ' Get hidden SupplierID
            editForm.supplierId = CInt(dbSuppliers.SelectedRows(0).Cells("SupplierID").Value)

            ' Fill fields with selected supplier data
            editForm.txtspName.Text = dbSuppliers.SelectedRows(0).Cells("SupplierName").Value.ToString()
            editForm.txtCName.Text = dbSuppliers.SelectedRows(0).Cells("ContactName").Value.ToString()
            editForm.txtEml.Text = dbSuppliers.SelectedRows(0).Cells("Email").Value.ToString()
            editForm.txtPhn.Text = dbSuppliers.SelectedRows(0).Cells("Phone").Value.ToString()
            editForm.txtAdress.Text = dbSuppliers.SelectedRows(0).Cells("Address").Value.ToString()

            editForm.callingForm = Me
            editForm.btnspUp.Visible = True
            editForm.btnSavesp.Visible = False

            editForm.ShowDialog()
        Else
            MessageBox.Show("Please select a supplier to edit.", "Notice", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End If
    End Sub

    Private Sub btnArchiveSp_Click(sender As Object, e As EventArgs) Handles btnArchiveSp.Click
        If dbSuppliers.SelectedRows.Count = 0 Then
            MessageBox.Show("Please select a supplier to archive.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If

        Dim selectedRow As DataGridViewRow = dbSuppliers.SelectedRows(0)
        Dim supplierId As Integer = Convert.ToInt32(selectedRow.Cells("SupplierID").Value)

        Dim confirm As DialogResult = MessageBox.Show("Are you sure you want to archive this supplier?", "Confirm Archive", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
        If confirm = DialogResult.Yes Then
            Try
                If conn.State = ConnectionState.Closed Then conn.Open()

                Dim query As String = "UPDATE suppliers1 SET is_Archived = TRUE WHERE SupplierID = @id"
                Using cmd As New MySqlCommand(query, conn)
                    cmd.Parameters.AddWithValue("@id", supplierId)
                    cmd.ExecuteNonQuery()
                End Using

                MessageBox.Show("Supplier archived successfully!", "Archived", MessageBoxButtons.OK, MessageBoxIcon.Information)
                LoadSuppliers() ' Refresh main supplier list

            Catch ex As Exception
                MessageBox.Show("Error archiving supplier: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Finally
                If conn.State = ConnectionState.Open Then conn.Close()
            End Try
        End If
    End Sub

End Class