Imports MySql.Data.MySqlClient


Public Class PasswordCh
    Public callingForm As frmAccounts
    Private showPassword As Boolean = False

    Private Sub PasswordCh_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.BeginInvoke(New MethodInvoker(Sub()
                                             txtNewPass.Focus()
                                         End Sub))

        txtNewPass.UseSystemPasswordChar = True
        txtConfirmPass.UseSystemPasswordChar = True
    End Sub

    Private Sub picShowPass_Click(sender As Object, e As EventArgs) Handles picShowPass.Click
        showPassword = Not showPassword

        txtNewPass.UseSystemPasswordChar = Not showPassword
        txtConfirmPass.UseSystemPasswordChar = Not showPassword

        Dim imgPath As String

        If showPassword Then
            imgPath = Application.StartupPath & "\Images\eye_open.png"
        Else
            imgPath = Application.StartupPath & "\Images\eye_closed.png"
        End If

        ' Prevent crash if file missing
        If IO.File.Exists(imgPath) Then
            picShowPass.Image = Image.FromFile(imgPath)
        End If
    End Sub

    Private Sub btnUpdate_Click(sender As Object, e As EventArgs) Handles btnUpdate.Click
        If MessageBox.Show("Reset this user's password?", "Confirm",
                   MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.No Then
            Exit Sub
        End If

        If txtNewPass.Text <> txtConfirmPass.Text Then
            MessageBox.Show("New passwords do not match.")
            Exit Sub
        End If

        If String.IsNullOrWhiteSpace(txtNewPass.Text) Then
            MessageBox.Show("Password cannot be empty.")
            Exit Sub
        End If

        Try
            Connect()

            Dim cmd As New MySqlCommand("
            UPDATE usersPOS 
            SET Password = @newpass 
            WHERE Username = @user", conn)

            cmd.Parameters.AddWithValue("@newpass", txtNewPass.Text)
            cmd.Parameters.AddWithValue("@user", txtUsername.Text)

            Dim rowsAffected As Integer = cmd.ExecuteNonQuery()

            If rowsAffected > 0 Then
                MessageBox.Show("Password reset successfully.")
            Else
                MessageBox.Show("User not found.")
            End If

        Catch ex As Exception
            MessageBox.Show("Error: " & ex.Message)
        Finally
            Disconnect()
        End Try

        If callingForm IsNot Nothing Then
            callingForm.LoadAccounts()
        End If

        Me.Close()
    End Sub

    Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        Me.Close()
    End Sub

End Class