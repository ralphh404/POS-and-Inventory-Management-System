Imports MySql.Data.MySqlClient

Public Class AddPopUp
    Private showPassword As Boolean = False

    Private Sub AddPopUP_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.BeginInvoke(New MethodInvoker(Sub()
                                             txtUsername.Focus()
                                         End Sub))

        txtPassword.UseSystemPasswordChar = True
        txtConfirmPass.UseSystemPasswordChar = True
    End Sub

    Private Sub picShow2_Click(sender As Object, e As EventArgs) Handles picShow2.Click
        showPassword = Not showPassword

        txtPassword.UseSystemPasswordChar = Not showPassword
        txtConfirmPass.UseSystemPasswordChar = Not showPassword

        Dim imgPath As String = IO.Path.Combine(Application.StartupPath, "Images", "eye_open.png")

        If Not showPassword Then
            imgPath = IO.Path.Combine(Application.StartupPath, "Images", "eye_closed.png")
        End If

        If IO.File.Exists(imgPath) Then
            picShow2.Image = Image.FromFile(imgPath)
        End If
    End Sub

    Private Sub btnAddUser_Click(sender As Object, e As EventArgs) Handles btnAddUser.Click
        If txtUsername.Text = "" Or txtPassword.Text = "" Or txtConfirmPass.Text = "" Or cmbType.Text = "" Then
            MessageBox.Show("Please complete all fields.", "Missing Info", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Exit Sub
        End If

        ' Confirm password match
        If txtPassword.Text <> txtConfirmPass.Text Then
            MessageBox.Show("Passwords do not match!", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        End If

        Try
            Connect()
            Dim query As String = "INSERT INTO usersPOS (Username, Password, AccountType) VALUES (@user, @pass, @type)"
            Dim cmd As New MySqlCommand(query, conn)
            cmd.Parameters.AddWithValue("@user", txtUsername.Text)
            cmd.Parameters.AddWithValue("@pass", txtPassword.Text) ' Consider encrypting in production
            cmd.Parameters.AddWithValue("@type", cmbType.Text)
            cmd.ExecuteNonQuery()
            Disconnect()

            MessageBox.Show("User added successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Me.DialogResult = DialogResult.OK
            Me.Close()
        Catch ex As Exception
            MessageBox.Show("Error: " & ex.Message)
        End Try

        Me.DialogResult = DialogResult.OK
        Me.Close()

    End Sub
    Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        Me.Close()
    End Sub

End Class