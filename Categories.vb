Imports System.Windows.Forms.VisualStyles.VisualStyleElement.TrackBar
Imports MySql.Data.MySqlClient

Public Class Categories
    Private Sub Categories_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        LoadCategories()
        For Each column As DataGridViewColumn In dbCategories.Columns
            column.SortMode = DataGridViewColumnSortMode.NotSortable
        Next
        ResizeProductColumns()
    End Sub

    Private Sub ResizeProductColumns()
        With dbCategories
            .Columns("CategoryName").Width = 250
        End With
    End Sub

    Private Sub Categories_Shown(sender As Object, e As EventArgs) Handles MyBase.Shown

        lblActiveDate22.Text = DateTime.Now.ToString("dddd, MMMM dd yyyy")
        lblActiveTime22.Text = DateTime.Now.ToString("hh:mm:ss tt")
        lblUsername22.Text = "User: " & frmInterface.loggedInUsername

        Tick2.Start()

        LoadCategories()
    End Sub

    Private Sub Tick2_Tick(sender As Object, e As EventArgs) Handles Tick2.Tick
        lblActiveDate22.Text = DateTime.Now.ToString("dddd, MMMM d, yyyy")
        lblActiveTime22.Text = DateTime.Now.ToString("hh:mm:ss tt")
    End Sub

    Private Sub LoadCategories()
        Try
            Connect()
            Dim query As String = "SELECT CategoryID, CategoryName, Description FROM category1"

            Dim da As New MySqlDataAdapter(query, conn)
            Dim dt As New DataTable()

            da.Fill(dt)
            dbCategories.DataSource = dt
            dbCategories.Columns("CategoryID").Visible = False

        Catch ex As Exception
            MessageBox.Show("Failed to load categories: " & ex.Message)
        Finally
            Disconnect()
        End Try
    End Sub

    Private Sub btnAddC_Click(sender As Object, e As EventArgs) Handles btnAddC.Click

        Dim addForm As New AddCategory()
        If addForm.ShowDialog() = DialogResult.OK Then
            LoadCategories()
        End If

    End Sub

    Private Sub btnEditC_Click(sender As Object, e As EventArgs) Handles btnEditC.Click

        If dbCategories.SelectedRows.Count = 0 Then
            MessageBox.Show("Please select a category to edit.", "No Selection", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If

        Dim categoryID As Integer = dbCategories.SelectedRows(0).Cells("CategoryID").Value
        Dim categoryName = dbCategories.SelectedRows(0).Cells("CategoryName").Value.ToString
        Dim description = dbCategories.SelectedRows(0).Cells("Description").Value.ToString

        Dim editForm As New AddCategory(categoryID, categoryName, description)

        If editForm.ShowDialog = DialogResult.OK Then
            LoadCategories()
        End If
    End Sub

    Private Sub btnDeleteC_Click(sender As Object, e As EventArgs) Handles btnDeleteC.Click

        If dbCategories.CurrentRow Is Nothing Then
            MessageBox.Show("Please select a category to delete.", "No Selection",
                            MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If

        Dim drv As DataRowView = TryCast(dbCategories.CurrentRow.DataBoundItem, DataRowView)
        If drv Is Nothing Then
            MessageBox.Show("Unable to read the selected row.", "Error",
                            MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return
        End If

        Dim categoryID As Integer = CInt(drv("CategoryID"))
        Dim categoryName As String = drv("CategoryName").ToString()

        Dim result As DialogResult = MessageBox.Show(
            $"Are you sure you want to delete the category '{categoryName}'?",
            "Confirm Delete",
            MessageBoxButtons.YesNo,
            MessageBoxIcon.Question
        )

        If result = DialogResult.Yes Then
            Try
                Connect()
                Dim query As String = "DELETE FROM category1 WHERE CategoryID = @CategoryID"

                Using cmd As New MySqlCommand(query, conn)
                    cmd.Parameters.AddWithValue("@CategoryID", categoryID)
                    cmd.ExecuteNonQuery()
                End Using

                MessageBox.Show("Category deleted successfully.", "Deleted",
                                MessageBoxButtons.OK, MessageBoxIcon.Information)

                LoadCategories()
            Catch ex As Exception
                MessageBox.Show("Failed to delete category: " & ex.Message)
            Finally
                Disconnect()
            End Try
        End If
    End Sub

End Class