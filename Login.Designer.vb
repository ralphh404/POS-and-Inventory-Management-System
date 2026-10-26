<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmLogin
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
    Protected Overrides Sub Dispose(disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmLogin))
        Panel1 = New Panel()
        PictureBox2 = New PictureBox()
        txtUsername = New TextBox()
        Panel2 = New Panel()
        PicSleep = New PictureBox()
        PicBlind = New PictureBox()
        PictureBox3 = New PictureBox()
        txtPassword = New TextBox()
        btnLogin = New Button()
        PictureBox4 = New PictureBox()
        Panel1.SuspendLayout()
        CType(PictureBox2, ComponentModel.ISupportInitialize).BeginInit()
        Panel2.SuspendLayout()
        CType(PicSleep, ComponentModel.ISupportInitialize).BeginInit()
        CType(PicBlind, ComponentModel.ISupportInitialize).BeginInit()
        CType(PictureBox3, ComponentModel.ISupportInitialize).BeginInit()
        CType(PictureBox4, ComponentModel.ISupportInitialize).BeginInit()
        SuspendLayout()
        ' 
        ' Panel1
        ' 
        Panel1.BackColor = Color.White
        Panel1.Controls.Add(PictureBox2)
        Panel1.Controls.Add(txtUsername)
        Panel1.Location = New Point(85, 244)
        Panel1.Name = "Panel1"
        Panel1.Size = New Size(323, 58)
        Panel1.TabIndex = 0
        ' 
        ' PictureBox2
        ' 
        PictureBox2.Image = My.Resources.Resources.user
        PictureBox2.Location = New Point(10, 8)
        PictureBox2.Name = "PictureBox2"
        PictureBox2.Size = New Size(40, 40)
        PictureBox2.SizeMode = PictureBoxSizeMode.StretchImage
        PictureBox2.TabIndex = 8
        PictureBox2.TabStop = False
        ' 
        ' txtUsername
        ' 
        txtUsername.BorderStyle = BorderStyle.None
        txtUsername.Font = New Font("Segoe UI", 10F)
        txtUsername.ForeColor = Color.Black
        txtUsername.Location = New Point(65, 17)
        txtUsername.Name = "txtUsername"
        txtUsername.Size = New Size(243, 27)
        txtUsername.TabIndex = 9
        ' 
        ' Panel2
        ' 
        Panel2.BackColor = Color.White
        Panel2.Controls.Add(PicSleep)
        Panel2.Controls.Add(PicBlind)
        Panel2.Controls.Add(PictureBox3)
        Panel2.Controls.Add(txtPassword)
        Panel2.Location = New Point(85, 308)
        Panel2.Name = "Panel2"
        Panel2.Size = New Size(323, 58)
        Panel2.TabIndex = 0
        ' 
        ' PicSleep
        ' 
        PicSleep.BackColor = Color.Transparent
        PicSleep.Cursor = Cursors.Hand
        PicSleep.Image = CType(resources.GetObject("PicSleep.Image"), Image)
        PicSleep.Location = New Point(286, 13)
        PicSleep.Name = "PicSleep"
        PicSleep.Size = New Size(30, 30)
        PicSleep.SizeMode = PictureBoxSizeMode.StretchImage
        PicSleep.TabIndex = 8
        PicSleep.TabStop = False
        ' 
        ' PicBlind
        ' 
        PicBlind.BackColor = Color.Transparent
        PicBlind.Cursor = Cursors.Hand
        PicBlind.Image = CType(resources.GetObject("PicBlind.Image"), Image)
        PicBlind.Location = New Point(286, 13)
        PicBlind.Name = "PicBlind"
        PicBlind.Size = New Size(30, 30)
        PicBlind.SizeMode = PictureBoxSizeMode.StretchImage
        PicBlind.TabIndex = 7
        PicBlind.TabStop = False
        ' 
        ' PictureBox3
        ' 
        PictureBox3.Image = My.Resources.Resources.lock
        PictureBox3.Location = New Point(10, 8)
        PictureBox3.Name = "PictureBox3"
        PictureBox3.Size = New Size(40, 40)
        PictureBox3.SizeMode = PictureBoxSizeMode.StretchImage
        PictureBox3.TabIndex = 7
        PictureBox3.TabStop = False
        ' 
        ' txtPassword
        ' 
        txtPassword.BorderStyle = BorderStyle.None
        txtPassword.Font = New Font("Segoe UI", 10F)
        txtPassword.ForeColor = Color.Black
        txtPassword.Location = New Point(64, 15)
        txtPassword.Name = "txtPassword"
        txtPassword.Size = New Size(243, 27)
        txtPassword.TabIndex = 7
        ' 
        ' btnLogin
        ' 
        btnLogin.BackColor = Color.CornflowerBlue
        btnLogin.Font = New Font("Segoe UI", 8F)
        btnLogin.ForeColor = Color.White
        btnLogin.Location = New Point(94, 485)
        btnLogin.Name = "btnLogin"
        btnLogin.Size = New Size(309, 58)
        btnLogin.TabIndex = 6
        btnLogin.Text = "Login"
        btnLogin.UseVisualStyleBackColor = False
        ' 
        ' PictureBox4
        ' 
        PictureBox4.Image = My.Resources.Resources.silver_membership_icon_default_avatar_profile_icon_membership_icon_social_media_user_image_illustration_vector
        PictureBox4.Location = New Point(147, 20)
        PictureBox4.Name = "PictureBox4"
        PictureBox4.Size = New Size(200, 200)
        PictureBox4.SizeMode = PictureBoxSizeMode.StretchImage
        PictureBox4.TabIndex = 7
        PictureBox4.TabStop = False
        ' 
        ' frmLogin
        ' 
        AutoScaleDimensions = New SizeF(10F, 25F)
        AutoScaleMode = AutoScaleMode.Font
        BackColor = Color.Gainsboro
        ClientSize = New Size(488, 639)
        Controls.Add(PictureBox4)
        Controls.Add(btnLogin)
        Controls.Add(Panel2)
        Controls.Add(Panel1)
        FormBorderStyle = FormBorderStyle.FixedSingle
        MaximizeBox = False
        MinimizeBox = False
        Name = "frmLogin"
        StartPosition = FormStartPosition.CenterScreen
        Text = "Login"
        Panel1.ResumeLayout(False)
        Panel1.PerformLayout()
        CType(PictureBox2, ComponentModel.ISupportInitialize).EndInit()
        Panel2.ResumeLayout(False)
        Panel2.PerformLayout()
        CType(PicSleep, ComponentModel.ISupportInitialize).EndInit()
        CType(PicBlind, ComponentModel.ISupportInitialize).EndInit()
        CType(PictureBox3, ComponentModel.ISupportInitialize).EndInit()
        CType(PictureBox4, ComponentModel.ISupportInitialize).EndInit()
        ResumeLayout(False)
    End Sub

    Friend WithEvents Panel1 As Panel
    Friend WithEvents Panel2 As Panel
    Friend WithEvents btnLogin As Button
    Friend WithEvents txtPassword As TextBox
    Friend WithEvents PictureBox2 As PictureBox
    Friend WithEvents txtUsername As TextBox
    Friend WithEvents PictureBox3 As PictureBox
    Friend WithEvents PicBlind As PictureBox
    Friend WithEvents PicSleep As PictureBox
    Friend WithEvents PictureBox4 As PictureBox

End Class
