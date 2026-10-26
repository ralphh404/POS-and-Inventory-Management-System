Imports MySql.Data.MySqlClient

Public Class AddCategory
    Private editMode As Boolean = False
    Private categoryID As Integer

    Public Sub New()
        InitializeComponent()
        editMode = False
        Me.Text = "Add Category"

        btnSaveC.Visible = True
        btnUpdateC.Visible = False
    End Sub

    Public Sub New(id As Integer, name As String, desc As String)
        InitializeComponent()
        editMode = True
        categoryID = id

        txtCn.Text = name
        txtDesc.Text = desc

        Me.Text = "Edit Category"
        btnSaveC.Visible = False
        btnUpdateC.Visible = True
    End Sub

    Private Sub btnSaveC_Click(sender As Object, e As EventArgs) Handles btnSaveC.Click
        Dim categoryName As String = txtCn.Text.Trim()
        Dim description As String = txtDesc.Text.Trim()

        ' Validation
        If categoryName = "" Or description = "" Then
            MessageBox.Show("Please fill in all fields.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If

        Try
            conn.Open()

            Dim query As String = "INSERT INTO category1 (CategoryName, Description) VALUES (@name, @desc)"
            Using cmd As New MySqlCommand(query, conn)
                cmd.Parameters.AddWithValue("@name", categoryName)
                cmd.Parameters.AddWithValue("@desc", description)
                cmd.ExecuteNonQuery()
            End Using

            MessageBox.Show("Category added successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)

            ' Close popup and return OK result
            Me.DialogResult = DialogResult.OK
            Me.Close()

        Catch ex As Exception
            MessageBox.Show("Error: " & ex.Message, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            conn.Close()
        End Try
    End Sub

    Private Sub btnUpdateC_Click(sender As Object, e As EventArgs) Handles btnUpdateC.Click
        If txtCn.Text.Trim() = "" Then
            MessageBox.Show("Category Name is required.", "Validation",
                            MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If

        Try
            Connect()
            Dim query As String = "UPDATE category1 SET CategoryName = @name, Description = @desc WHERE CategoryID = @id"
            Using cmd As New MySqlCommand(query, conn)
                cmd.Parameters.AddWithValue("@name", txtCn.Text.Trim())
                cmd.Parameters.AddWithValue("@desc", txtDesc.Text.Trim())
                cmd.Parameters.AddWithValue("@id", categoryID)
                cmd.ExecuteNonQuery()
            End Using

            MessageBox.Show("Category updated successfully.", "Success",
                            MessageBoxButtons.OK, MessageBoxIcon.Information)
            Me.DialogResult = DialogResult.OK
            Me.Close()

        Catch ex As Exception
            MessageBox.Show("Error updating category: " & ex.Message, "Error",
                            MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            Disconnect()
        End Try
    End Sub

    Private Sub btnCancelC_Click(sender As Object, e As EventArgs) Handles btnCancelC.Click
        Me.Close()
    End Sub
End Class
