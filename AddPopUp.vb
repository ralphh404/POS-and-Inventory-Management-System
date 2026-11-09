Imports MySql.Data.MySqlClient

Public Class AddPopUp
    Private showPassword As Boolean = False
    Public Property IsFirstAccountSetup As Boolean = False

    Private Sub AddPopUP_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Me.BeginInvoke(New MethodInvoker(Sub()
                                             txtUsername.Focus()
                                         End Sub))

        txtPassword.UseSystemPasswordChar = True
        txtConfirmPass.UseSystemPasswordChar = True

        If IsFirstAccountSetup Then
            cmbType.Text = "Admin"
            cmbType.Enabled = False
        End If

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

        If String.IsNullOrWhiteSpace(txtUsername.Text) OrElse
       String.IsNullOrWhiteSpace(txtPassword.Text) OrElse
       String.IsNullOrWhiteSpace(txtConfirmPass.Text) OrElse
       (Not IsFirstAccountSetup AndAlso String.IsNullOrWhiteSpace(cmbType.Text)) Then

            MessageBox.Show("Please complete all fields.",
                        "Missing Info",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning)
            Exit Sub
        End If

        If txtPassword.Text.Length < 8 Then
            MessageBox.Show("Password must be at least 8 characters long.",
                        "Weak Password",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning)
            txtPassword.Focus()
            Exit Sub
        End If

        If txtPassword.Text <> txtConfirmPass.Text Then
            MessageBox.Show("Passwords do not match!")
            Exit Sub
        End If

        Dim lockAcquired As Boolean = False

        Try
            Connect()

            ' Protect first-account registration
            If IsFirstAccountSetup Then

                Using lockCmd As New MySqlCommand(
                "SELECT GET_LOCK('usersPOS_first_account', 10)", conn)

                    lockAcquired = (Convert.ToInt32(lockCmd.ExecuteScalar()) = 1)

                End Using

                If Not lockAcquired Then
                    MessageBox.Show("Unable to start account setup. Please try again.")
                    Exit Sub
                End If

                ' Recheck the database before creating the first account
                Using countCmd As New MySqlCommand(
                "SELECT COUNT(*) FROM usersPOS", conn)

                    Dim accountCount As Integer =
                    Convert.ToInt32(countCmd.ExecuteScalar())

                    If accountCount > 0 Then
                        MessageBox.Show(
                        "An account already exists. First-time registration is no longer available.",
                        "Registration Unavailable",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning)

                        Exit Sub
                    End If

                End Using

            End If

            Dim accountType As String

            If IsFirstAccountSetup Then
                accountType = "Admin"
            Else
                accountType = cmbType.Text
            End If

            Dim query As String =
            "INSERT INTO usersPOS (Username, Password, AccountType) " &
            "VALUES (@user, @pass, @type)"

            Using cmd As New MySqlCommand(query, conn)

                cmd.Parameters.AddWithValue("@user", txtUsername.Text.Trim())

                cmd.Parameters.AddWithValue("@pass",
                PasswordHelper.HashPassword(txtPassword.Text))

                cmd.Parameters.AddWithValue("@type", accountType)

                cmd.ExecuteNonQuery()

            End Using

            MessageBox.Show("User added successfully!",
                        "Success",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information)

            Me.DialogResult = DialogResult.OK
            Me.Close()

        Catch ex As Exception

            MessageBox.Show("Error: " & ex.Message)

        Finally

            If lockAcquired AndAlso conn.State = ConnectionState.Open Then
                Try
                    Using releaseCmd As New MySqlCommand(
                    "SELECT RELEASE_LOCK('usersPOS_first_account')", conn)

                        releaseCmd.ExecuteScalar()

                    End Using
                Catch
                End Try
            End If

            Disconnect()

        End Try

    End Sub

    Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        Me.Close()
    End Sub

End Class