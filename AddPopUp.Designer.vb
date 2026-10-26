<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class AddPopUp
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(AddPopUp))
        txtUsername = New TextBox()
        Panel2 = New Panel()
        Panel3 = New Panel()
        picShow2 = New PictureBox()
        txtPassword = New TextBox()
        Panel4 = New Panel()
        txtConfirmPass = New TextBox()
        Panel5 = New Panel()
        cmbType = New ComboBox()
        Label1 = New Label()
        Label2 = New Label()
        Label3 = New Label()
        Label4 = New Label()
        btnCancel = New Button()
        btnAddUser = New Button()
        Panel2.SuspendLayout()
        Panel3.SuspendLayout()
        CType(picShow2, ComponentModel.ISupportInitialize).BeginInit()
        Panel4.SuspendLayout()
        Panel5.SuspendLayout()
        SuspendLayout()
        ' 
        ' txtUsername
        ' 
        txtUsername.BorderStyle = BorderStyle.None
        txtUsername.Location = New Point(18, 17)
        txtUsername.Name = "txtUsername"
        txtUsername.Size = New Size(306, 24)
        txtUsername.TabIndex = 1
        ' 
        ' Panel2
        ' 
        Panel2.BackColor = SystemColors.Window
        Panel2.Controls.Add(txtUsername)
        Panel2.Location = New Point(18, 44)
        Panel2.Name = "Panel2"
        Panel2.Size = New Size(340, 58)
        Panel2.TabIndex = 2
        ' 
        ' Panel3
        ' 
        Panel3.BackColor = SystemColors.Window
        Panel3.Controls.Add(picShow2)
        Panel3.Controls.Add(txtPassword)
        Panel3.Location = New Point(18, 142)
        Panel3.Name = "Panel3"
        Panel3.Size = New Size(340, 58)
        Panel3.TabIndex = 2
        ' 
        ' picShow2
        ' 
        picShow2.Image = CType(resources.GetObject("picShow2.Image"), Image)
        picShow2.Location = New Point(296, 14)
        picShow2.Name = "picShow2"
        picShow2.Size = New Size(30, 30)
        picShow2.SizeMode = PictureBoxSizeMode.Zoom
        picShow2.TabIndex = 5
        picShow2.TabStop = False
        ' 
        ' txtPassword
        ' 
        txtPassword.BorderStyle = BorderStyle.None
        txtPassword.Location = New Point(18, 17)
        txtPassword.Name = "txtPassword"
        txtPassword.Size = New Size(268, 24)
        txtPassword.TabIndex = 1
        ' 
        ' Panel4
        ' 
        Panel4.BackColor = SystemColors.Window
        Panel4.Controls.Add(txtConfirmPass)
        Panel4.Location = New Point(18, 237)
        Panel4.Name = "Panel4"
        Panel4.Size = New Size(340, 58)
        Panel4.TabIndex = 2
        ' 
        ' txtConfirmPass
        ' 
        txtConfirmPass.BorderStyle = BorderStyle.None
        txtConfirmPass.Location = New Point(18, 17)
        txtConfirmPass.Name = "txtConfirmPass"
        txtConfirmPass.Size = New Size(268, 24)
        txtConfirmPass.TabIndex = 1
        ' 
        ' Panel5
        ' 
        Panel5.BackColor = SystemColors.Window
        Panel5.Controls.Add(cmbType)
        Panel5.Location = New Point(18, 336)
        Panel5.Name = "Panel5"
        Panel5.Size = New Size(340, 58)
        Panel5.TabIndex = 2
        ' 
        ' cmbType
        ' 
        cmbType.DropDownStyle = ComboBoxStyle.DropDownList
        cmbType.FormattingEnabled = True
        cmbType.Items.AddRange(New Object() {"Admin", "Staff"})
        cmbType.Location = New Point(16, 12)
        cmbType.Name = "cmbType"
        cmbType.Size = New Size(306, 33)
        cmbType.TabIndex = 0
        ' 
        ' Label1
        ' 
        Label1.AutoSize = True
        Label1.Font = New Font("Century Gothic", 10F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        Label1.Location = New Point(130, 18)
        Label1.Name = "Label1"
        Label1.Size = New Size(108, 23)
        Label1.TabIndex = 3
        Label1.Text = "Username"
        ' 
        ' Label2
        ' 
        Label2.AutoSize = True
        Label2.Font = New Font("Century Gothic", 10F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        Label2.Location = New Point(130, 116)
        Label2.Name = "Label2"
        Label2.Size = New Size(103, 23)
        Label2.TabIndex = 3
        Label2.Text = "Password"
        ' 
        ' Label3
        ' 
        Label3.AutoSize = True
        Label3.Font = New Font("Century Gothic", 10F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        Label3.Location = New Point(92, 211)
        Label3.Name = "Label3"
        Label3.Size = New Size(184, 23)
        Label3.TabIndex = 3
        Label3.Text = "Confirm Password"
        ' 
        ' Label4
        ' 
        Label4.AutoSize = True
        Label4.Font = New Font("Century Gothic", 10F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        Label4.Location = New Point(153, 310)
        Label4.Name = "Label4"
        Label4.Size = New Size(56, 23)
        Label4.TabIndex = 3
        Label4.Text = "Type"
        ' 
        ' btnCancel
        ' 
        btnCancel.BackColor = Color.Firebrick
        btnCancel.FlatStyle = FlatStyle.Flat
        btnCancel.Font = New Font("Century Gothic", 9F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        btnCancel.ForeColor = SystemColors.ControlLightLight
        btnCancel.Location = New Point(154, 439)
        btnCancel.Name = "btnCancel"
        btnCancel.Size = New Size(130, 45)
        btnCancel.TabIndex = 4
        btnCancel.Text = "Cancel"
        btnCancel.UseVisualStyleBackColor = False
        ' 
        ' btnAddUser
        ' 
        btnAddUser.BackColor = Color.SlateGray
        btnAddUser.FlatAppearance.BorderColor = Color.Silver
        btnAddUser.FlatStyle = FlatStyle.Flat
        btnAddUser.Font = New Font("Century Gothic", 9F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        btnAddUser.ForeColor = SystemColors.ControlLightLight
        btnAddUser.Location = New Point(18, 439)
        btnAddUser.Name = "btnAddUser"
        btnAddUser.Size = New Size(130, 45)
        btnAddUser.TabIndex = 4
        btnAddUser.Text = "Add User"
        btnAddUser.UseVisualStyleBackColor = False
        ' 
        ' AddPopUp
        ' 
        AutoScaleDimensions = New SizeF(10F, 25F)
        AutoScaleMode = AutoScaleMode.Font
        BackColor = Color.LightSteelBlue
        ClientSize = New Size(375, 512)
        ControlBox = False
        Controls.Add(btnAddUser)
        Controls.Add(btnCancel)
        Controls.Add(Label4)
        Controls.Add(Label3)
        Controls.Add(Label2)
        Controls.Add(Label1)
        Controls.Add(Panel5)
        Controls.Add(Panel4)
        Controls.Add(Panel3)
        Controls.Add(Panel2)
        FormBorderStyle = FormBorderStyle.FixedSingle
        MaximizeBox = False
        MdiChildrenMinimizedAnchorBottom = False
        Name = "AddPopUp"
        StartPosition = FormStartPosition.CenterScreen
        Text = "Medent+"
        Panel2.ResumeLayout(False)
        Panel2.PerformLayout()
        Panel3.ResumeLayout(False)
        Panel3.PerformLayout()
        CType(picShow2, ComponentModel.ISupportInitialize).EndInit()
        Panel4.ResumeLayout(False)
        Panel4.PerformLayout()
        Panel5.ResumeLayout(False)
        ResumeLayout(False)
        PerformLayout()
    End Sub
    Friend WithEvents txtUsername As TextBox
    Friend WithEvents Panel2 As Panel
    Friend WithEvents Panel3 As Panel
    Friend WithEvents txtPassword As TextBox
    Friend WithEvents Panel4 As Panel
    Friend WithEvents txtConfirmPass As TextBox
    Friend WithEvents Panel5 As Panel
    Friend WithEvents Label1 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents btnCancel As Button
    Friend WithEvents btnAddUser As Button
    Friend WithEvents cmbType As ComboBox
    Friend WithEvents picShow2 As PictureBox
End Class
