<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class PasswordCh
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
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
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(PasswordCh))
        txtUsername = New TextBox()
        Panel1 = New Panel()
        Panel3 = New Panel()
        picShowPass = New PictureBox()
        txtNewPass = New TextBox()
        Panel4 = New Panel()
        txtConfirmPass = New TextBox()
        Label1 = New Label()
        Label3 = New Label()
        Label4 = New Label()
        btnCancel = New Button()
        btnUpdate = New Button()
        Panel1.SuspendLayout()
        Panel3.SuspendLayout()
        CType(picShowPass, ComponentModel.ISupportInitialize).BeginInit()
        Panel4.SuspendLayout()
        SuspendLayout()
        ' 
        ' txtUsername
        ' 
        txtUsername.BorderStyle = BorderStyle.None
        txtUsername.Location = New Point(13, 10)
        txtUsername.Name = "txtUsername"
        txtUsername.ReadOnly = True
        txtUsername.Size = New Size(315, 24)
        txtUsername.TabIndex = 0
        ' 
        ' Panel1
        ' 
        Panel1.BackColor = SystemColors.Control
        Panel1.Controls.Add(txtUsername)
        Panel1.Location = New Point(24, 52)
        Panel1.Name = "Panel1"
        Panel1.Size = New Size(340, 45)
        Panel1.TabIndex = 1
        ' 
        ' Panel3
        ' 
        Panel3.BackColor = SystemColors.Window
        Panel3.Controls.Add(picShowPass)
        Panel3.Controls.Add(txtNewPass)
        Panel3.Location = New Point(24, 216)
        Panel3.Name = "Panel3"
        Panel3.Size = New Size(340, 45)
        Panel3.TabIndex = 1
        ' 
        ' picShowPass
        ' 
        picShowPass.Image = CType(resources.GetObject("picShowPass.Image"), Image)
        picShowPass.Location = New Point(303, 7)
        picShowPass.Name = "picShowPass"
        picShowPass.Size = New Size(30, 30)
        picShowPass.SizeMode = PictureBoxSizeMode.Zoom
        picShowPass.TabIndex = 4
        picShowPass.TabStop = False
        ' 
        ' txtNewPass
        ' 
        txtNewPass.BorderStyle = BorderStyle.None
        txtNewPass.Location = New Point(13, 10)
        txtNewPass.Name = "txtNewPass"
        txtNewPass.Size = New Size(284, 24)
        txtNewPass.TabIndex = 0
        ' 
        ' Panel4
        ' 
        Panel4.BackColor = SystemColors.Window
        Panel4.Controls.Add(txtConfirmPass)
        Panel4.Location = New Point(24, 303)
        Panel4.Name = "Panel4"
        Panel4.Size = New Size(340, 45)
        Panel4.TabIndex = 1
        ' 
        ' txtConfirmPass
        ' 
        txtConfirmPass.BorderStyle = BorderStyle.None
        txtConfirmPass.Location = New Point(13, 11)
        txtConfirmPass.Name = "txtConfirmPass"
        txtConfirmPass.Size = New Size(284, 24)
        txtConfirmPass.TabIndex = 0
        ' 
        ' Label1
        ' 
        Label1.AutoSize = True
        Label1.Font = New Font("Century Gothic", 10F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        Label1.Location = New Point(24, 26)
        Label1.Name = "Label1"
        Label1.Size = New Size(108, 23)
        Label1.TabIndex = 2
        Label1.Text = "Username"
        ' 
        ' Label3
        ' 
        Label3.AutoSize = True
        Label3.Font = New Font("Century Gothic", 10F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        Label3.Location = New Point(24, 190)
        Label3.Name = "Label3"
        Label3.Size = New Size(155, 23)
        Label3.TabIndex = 2
        Label3.Text = "New Password"
        ' 
        ' Label4
        ' 
        Label4.AutoSize = True
        Label4.Font = New Font("Century Gothic", 10F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        Label4.Location = New Point(24, 277)
        Label4.Name = "Label4"
        Label4.Size = New Size(184, 23)
        Label4.TabIndex = 2
        Label4.Text = "Confirm Password"
        ' 
        ' btnCancel
        ' 
        btnCancel.BackColor = Color.Firebrick
        btnCancel.FlatAppearance.BorderColor = Color.Silver
        btnCancel.FlatStyle = FlatStyle.Flat
        btnCancel.Font = New Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        btnCancel.ForeColor = SystemColors.ControlLightLight
        btnCancel.Location = New Point(160, 389)
        btnCancel.Name = "btnCancel"
        btnCancel.Size = New Size(130, 45)
        btnCancel.TabIndex = 3
        btnCancel.Text = "Cancel"
        btnCancel.UseVisualStyleBackColor = False
        ' 
        ' btnUpdate
        ' 
        btnUpdate.BackColor = Color.Gray
        btnUpdate.FlatAppearance.BorderColor = Color.Silver
        btnUpdate.FlatStyle = FlatStyle.Flat
        btnUpdate.Font = New Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        btnUpdate.ForeColor = SystemColors.ControlLightLight
        btnUpdate.Location = New Point(24, 389)
        btnUpdate.Name = "btnUpdate"
        btnUpdate.Size = New Size(130, 45)
        btnUpdate.TabIndex = 3
        btnUpdate.Text = "Update"
        btnUpdate.UseVisualStyleBackColor = False
        ' 
        ' PasswordCh
        ' 
        AutoScaleDimensions = New SizeF(10F, 25F)
        AutoScaleMode = AutoScaleMode.Font
        BackColor = Color.LightSteelBlue
        ClientSize = New Size(390, 473)
        ControlBox = False
        Controls.Add(btnUpdate)
        Controls.Add(btnCancel)
        Controls.Add(Label4)
        Controls.Add(Label3)
        Controls.Add(Label1)
        Controls.Add(Panel4)
        Controls.Add(Panel3)
        Controls.Add(Panel1)
        FormBorderStyle = FormBorderStyle.FixedSingle
        MaximizeBox = False
        MinimizeBox = False
        Name = "PasswordCh"
        StartPosition = FormStartPosition.CenterScreen
        Text = "Medent+"
        Panel1.ResumeLayout(False)
        Panel1.PerformLayout()
        Panel3.ResumeLayout(False)
        Panel3.PerformLayout()
        CType(picShowPass, ComponentModel.ISupportInitialize).EndInit()
        Panel4.ResumeLayout(False)
        Panel4.PerformLayout()
        ResumeLayout(False)
        PerformLayout()
    End Sub

    Friend WithEvents txtUsername As TextBox
    Friend WithEvents Panel1 As Panel
    Friend WithEvents Panel3 As Panel
    Friend WithEvents txtNewPass As TextBox
    Friend WithEvents Panel4 As Panel
    Friend WithEvents txtConfirmPass As TextBox
    Friend WithEvents Label1 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents btnCancel As Button
    Friend WithEvents btnUpdate As Button
    Friend WithEvents picShowPass As PictureBox
End Class
