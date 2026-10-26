Imports MySql.Data.MySqlClient
Public Class frmLogin
    Private Sub frmLogin_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        InitializeDatabase()
        ' Placeholder defaults
        txtUsername.Text = "Username"
        txtUsername.ForeColor = Color.DarkGray

        txtPassword.Text = "Password"
        txtPassword.ForeColor = Color.DarkGray

        ' Auto focus on Username after load
        Me.BeginInvoke(New MethodInvoker(Sub() txtUsername.Focus()))

        ' Pressing Enter = Login
        Me.AcceptButton = btnLogin

        Try
            PictureBox4.Image = My.Resources.silver_membership_icon_default_avatar_profile_icon_membership_icon_social_media_user_image_illustration_vector
            MakePictureRound(PictureBox4)
        Catch ex As Exception
            MessageBox.Show("Failed to load profile picture: " & ex.Message,
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End Try
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

    ' --- Username placeholder handling ---
    Private Sub txtUsername_GotFocus(sender As Object, e As EventArgs) Handles txtUsername.GotFocus
        If txtUsername.Text = "Username" Then
            txtUsername.Text = ""
            txtUsername.ForeColor = Color.Black
        End If
    End Sub

    Private Sub txtUsername_LostFocus(sender As Object, e As EventArgs) Handles txtUsername.LostFocus
        If txtUsername.Text = "" Then
            txtUsername.Text = "Username"
            txtUsername.ForeColor = Color.DarkGray
        End If
    End Sub

    ' --- Password placeholder handling ---
    Private Sub txtPassword_GotFocus(sender As Object, e As EventArgs) Handles txtPassword.GotFocus
        If txtPassword.Text = "Password" Then
            txtPassword.Text = ""
            txtPassword.PasswordChar = "•"
            txtPassword.ForeColor = Color.Black
        End If
    End Sub

    Private Sub txtPassword_LostFocus(sender As Object, e As EventArgs) Handles txtPassword.LostFocus
        If txtPassword.Text = "" Then
            txtPassword.Text = "Password"
            txtPassword.PasswordChar = ""
            txtPassword.ForeColor = Color.DarkGray
        End If
    End Sub

    Private Sub PicSleep_Click(sender As Object, e As EventArgs) Handles PicSleep.Click
        ' Only toggle if not placeholder text
        If txtPassword.Text <> "Password" Then
            txtPassword.PasswordChar = ""       ' Show password
            PicSleep.Visible = False             ' Hide closed eye
            PicBlind.Visible = True               ' Show open eye
        End If
    End Sub

    Private Sub PicBlind_Click(sender As Object, e As EventArgs) Handles PicBlind.Click
        ' Only toggle if not placeholder text
        If txtPassword.Text <> "Password" Then
            txtPassword.PasswordChar = "•"       ' Hide password
            PicBlind.Visible = False              ' Hide open eye
            PicSleep.Visible = True              ' Show closed eye
        End If
    End Sub

    ' --- Block copy/paste ---
    Private Sub TxtUsername_KeyDown(sender As Object, e As KeyEventArgs) Handles txtUsername.KeyDown
        If e.Control AndAlso (e.KeyCode = Keys.C OrElse e.KeyCode = Keys.X OrElse e.KeyCode = Keys.V) Then
            e.SuppressKeyPress = True
        End If
    End Sub

    Private Sub TxtUsername_MouseDown(sender As Object, e As MouseEventArgs) Handles txtUsername.MouseDown
        If e.Button = MouseButtons.Right Then
            MessageBox.Show("Copy/Paste is not allowed.", "Action Blocked", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End If
    End Sub

    Private Sub TxtPassword_KeyDown(sender As Object, e As KeyEventArgs) Handles txtPassword.KeyDown
        If e.Control AndAlso e.KeyCode = Keys.V Then
            e.SuppressKeyPress = True
        End If
    End Sub

    Private Sub TxtPassword_MouseDown(sender As Object, e As MouseEventArgs) Handles txtPassword.MouseDown
        If e.Button = MouseButtons.Right Then
            MessageBox.Show("Can't paste in Password.", "Action Blocked", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End If
    End Sub

    ' --- Login logic ---
    Private Sub btnLogin_Click(sender As Object, e As EventArgs) Handles btnLogin.Click
        Try
            ' Validate before querying database
            If txtUsername.Text = "" OrElse txtUsername.Text = "Username" Then
                MessageBox.Show("Please enter a valid username.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                txtUsername.Focus()
                Exit Sub
            End If

            If txtPassword.Text = "" OrElse txtPassword.Text = "Password" Then
                MessageBox.Show("Please enter a valid password.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                txtPassword.Focus()
                Exit Sub
            End If

            conn.Open()
            Dim cmd As New MySqlCommand("SELECT * FROM usersPOS WHERE Username=@username AND Password=@password AND is_Archived=0", conn)
            cmd.Parameters.AddWithValue("@username", txtUsername.Text)
            cmd.Parameters.AddWithValue("@password", txtPassword.Text)

            Dim dr As MySqlDataReader = cmd.ExecuteReader()

            If dr.Read() Then
                ' Get user info
                frmInterface.loggedInUsername = dr("Username").ToString()
                frmInterface.loggedInType = dr("AccountType").ToString()
                dr.Close()

                ' Log successful login
                Dim logCmd As New MySqlCommand("INSERT INTO log_historyPOS (Username, Action, LogTime, Details) VALUES (@username, @action, NOW(), @details)", conn)
                logCmd.Parameters.AddWithValue("@username", frmInterface.loggedInUsername)
                logCmd.Parameters.AddWithValue("@action", "Login")
                logCmd.Parameters.AddWithValue("@details", "Login: " & frmInterface.loggedInType)
                logCmd.ExecuteNonQuery()

                ' Open interface
                Dim interfaceForm As New frmInterface()
                interfaceForm.Show()
                interfaceForm.LoadFormIntoPanel(New Dashboard())
                Me.Hide()
            Else
                MessageBox.Show("Invalid username or password.", "Login Failed", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If

        Catch ex As Exception
            MessageBox.Show("Error: " & ex.Message)
        Finally
            conn.Close()
        End Try
    End Sub

End Class
