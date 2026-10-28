<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmInterface
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
        Panel1 = New Panel()
        btnExit = New Button()
        btnLogOut = New Button()
        Panel3 = New Panel()
        btnSales = New Button()
        btnLogs = New Button()
        btnData = New Button()
        btnArch = New Button()
        btnAccounts = New Button()
        btnPOS = New Button()
        btnInventory = New Button()
        btnDashboard = New Button()
        Panel2 = New Panel()
        PictureBox1 = New PictureBox()
        Label1 = New Label()
        mainPanel = New Panel()
        Panel1.SuspendLayout()
        Panel2.SuspendLayout()
        CType(PictureBox1, ComponentModel.ISupportInitialize).BeginInit()
        SuspendLayout()
        ' 
        ' Panel1
        ' 
        Panel1.BackColor = Color.LightSlateGray
        Panel1.Controls.Add(btnExit)
        Panel1.Controls.Add(btnLogOut)
        Panel1.Controls.Add(Panel3)
        Panel1.Controls.Add(btnSales)
        Panel1.Controls.Add(btnLogs)
        Panel1.Controls.Add(btnData)
        Panel1.Controls.Add(btnArch)
        Panel1.Controls.Add(btnAccounts)
        Panel1.Controls.Add(btnPOS)
        Panel1.Controls.Add(btnInventory)
        Panel1.Controls.Add(btnDashboard)
        Panel1.Controls.Add(Panel2)
        Panel1.Dock = DockStyle.Left
        Panel1.Location = New Point(0, 0)
        Panel1.Name = "Panel1"
        Panel1.Size = New Size(300, 934)
        Panel1.TabIndex = 0
        ' 
        ' btnExit
        ' 
        btnExit.BackColor = Color.LightSteelBlue
        btnExit.Dock = DockStyle.Top
        btnExit.FlatAppearance.BorderSize = 0
        btnExit.FlatStyle = FlatStyle.Flat
        btnExit.Font = New Font("Century Gothic", 11F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        btnExit.ForeColor = Color.White
        btnExit.Image = My.Resources.Resources.logout
        btnExit.Location = New Point(0, 835)
        btnExit.Name = "btnExit"
        btnExit.Padding = New Padding(85, 0, 0, 0)
        btnExit.Size = New Size(300, 60)
        btnExit.TabIndex = 11
        btnExit.Text = "Exit"
        btnExit.TextAlign = ContentAlignment.MiddleLeft
        btnExit.UseVisualStyleBackColor = False
        ' 
        ' btnLogOut
        ' 
        btnLogOut.BackColor = Color.CornflowerBlue
        btnLogOut.Dock = DockStyle.Top
        btnLogOut.FlatAppearance.BorderSize = 0
        btnLogOut.FlatStyle = FlatStyle.Flat
        btnLogOut.Font = New Font("Century Gothic", 11F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        btnLogOut.ForeColor = Color.White
        btnLogOut.Image = My.Resources.Resources.exit_1_
        btnLogOut.Location = New Point(0, 775)
        btnLogOut.Name = "btnLogOut"
        btnLogOut.Padding = New Padding(85, 0, 0, 0)
        btnLogOut.Size = New Size(300, 60)
        btnLogOut.TabIndex = 10
        btnLogOut.Text = "Log Out"
        btnLogOut.TextAlign = ContentAlignment.MiddleLeft
        btnLogOut.UseVisualStyleBackColor = False
        ' 
        ' Panel3
        ' 
        Panel3.Dock = DockStyle.Top
        Panel3.Location = New Point(0, 697)
        Panel3.Name = "Panel3"
        Panel3.Size = New Size(300, 78)
        Panel3.TabIndex = 9
        ' 
        ' btnSales
        ' 
        btnSales.BackColor = Color.LightSlateGray
        btnSales.Dock = DockStyle.Top
        btnSales.FlatAppearance.BorderColor = Color.White
        btnSales.FlatAppearance.BorderSize = 0
        btnSales.FlatStyle = FlatStyle.Flat
        btnSales.Font = New Font("Century Gothic", 11F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        btnSales.ForeColor = Color.White
        btnSales.Image = My.Resources.Resources.app
        btnSales.Location = New Point(0, 637)
        btnSales.Name = "btnSales"
        btnSales.Padding = New Padding(60, 0, 0, 0)
        btnSales.Size = New Size(300, 60)
        btnSales.TabIndex = 8
        btnSales.Text = "Sales Report"
        btnSales.TextAlign = ContentAlignment.MiddleLeft
        btnSales.UseVisualStyleBackColor = False
        ' 
        ' btnLogs
        ' 
        btnLogs.BackColor = Color.LightSlateGray
        btnLogs.Dock = DockStyle.Top
        btnLogs.FlatAppearance.BorderColor = Color.White
        btnLogs.FlatAppearance.BorderSize = 0
        btnLogs.FlatStyle = FlatStyle.Flat
        btnLogs.Font = New Font("Century Gothic", 11F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        btnLogs.ForeColor = Color.White
        btnLogs.Image = My.Resources.Resources.beam
        btnLogs.Location = New Point(0, 577)
        btnLogs.Name = "btnLogs"
        btnLogs.Padding = New Padding(60, 0, 0, 0)
        btnLogs.Size = New Size(300, 60)
        btnLogs.TabIndex = 7
        btnLogs.Text = "Logs"
        btnLogs.TextAlign = ContentAlignment.MiddleLeft
        btnLogs.UseVisualStyleBackColor = False
        ' 
        ' btnData
        ' 
        btnData.BackColor = Color.LightSlateGray
        btnData.Dock = DockStyle.Top
        btnData.FlatAppearance.BorderColor = Color.White
        btnData.FlatAppearance.BorderSize = 0
        btnData.FlatStyle = FlatStyle.Flat
        btnData.Font = New Font("Century Gothic", 11F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        btnData.ForeColor = Color.White
        btnData.Location = New Point(0, 517)
        btnData.Name = "btnData"
        btnData.Padding = New Padding(60, 0, 0, 0)
        btnData.Size = New Size(300, 60)
        btnData.TabIndex = 6
        btnData.Text = "Backup Data"
        btnData.TextAlign = ContentAlignment.MiddleLeft
        btnData.UseVisualStyleBackColor = False
        ' 
        ' btnArch
        ' 
        btnArch.BackColor = Color.LightSlateGray
        btnArch.Dock = DockStyle.Top
        btnArch.FlatAppearance.BorderColor = Color.White
        btnArch.FlatAppearance.BorderSize = 0
        btnArch.FlatStyle = FlatStyle.Flat
        btnArch.Font = New Font("Century Gothic", 11F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        btnArch.ForeColor = Color.White
        btnArch.Image = My.Resources.Resources.rar_file
        btnArch.Location = New Point(0, 457)
        btnArch.Name = "btnArch"
        btnArch.Padding = New Padding(60, 0, 0, 0)
        btnArch.Size = New Size(300, 60)
        btnArch.TabIndex = 5
        btnArch.Text = "Archives"
        btnArch.TextAlign = ContentAlignment.MiddleLeft
        btnArch.UseVisualStyleBackColor = False
        ' 
        ' btnAccounts
        ' 
        btnAccounts.BackColor = Color.LightSlateGray
        btnAccounts.Dock = DockStyle.Top
        btnAccounts.FlatAppearance.BorderColor = Color.White
        btnAccounts.FlatAppearance.BorderSize = 0
        btnAccounts.FlatStyle = FlatStyle.Flat
        btnAccounts.Font = New Font("Century Gothic", 11F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        btnAccounts.ForeColor = Color.White
        btnAccounts.Image = My.Resources.Resources.user_circle
        btnAccounts.Location = New Point(0, 397)
        btnAccounts.Name = "btnAccounts"
        btnAccounts.Padding = New Padding(60, 0, 0, 0)
        btnAccounts.Size = New Size(300, 60)
        btnAccounts.TabIndex = 4
        btnAccounts.Text = "Accounts"
        btnAccounts.TextAlign = ContentAlignment.MiddleLeft
        btnAccounts.UseVisualStyleBackColor = False
        ' 
        ' btnPOS
        ' 
        btnPOS.BackColor = Color.LightSlateGray
        btnPOS.Dock = DockStyle.Top
        btnPOS.FlatAppearance.BorderColor = Color.White
        btnPOS.FlatAppearance.BorderSize = 0
        btnPOS.FlatStyle = FlatStyle.Flat
        btnPOS.Font = New Font("Century Gothic", 11F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        btnPOS.ForeColor = Color.White
        btnPOS.Image = My.Resources.Resources.pos_terminal_1_
        btnPOS.Location = New Point(0, 337)
        btnPOS.Name = "btnPOS"
        btnPOS.Padding = New Padding(60, 0, 0, 0)
        btnPOS.Size = New Size(300, 60)
        btnPOS.TabIndex = 3
        btnPOS.Text = "POS"
        btnPOS.TextAlign = ContentAlignment.MiddleLeft
        btnPOS.UseVisualStyleBackColor = False
        ' 
        ' btnInventory
        ' 
        btnInventory.BackColor = Color.LightSlateGray
        btnInventory.Dock = DockStyle.Top
        btnInventory.FlatAppearance.BorderColor = Color.White
        btnInventory.FlatAppearance.BorderSize = 0
        btnInventory.FlatStyle = FlatStyle.Flat
        btnInventory.Font = New Font("Century Gothic", 11F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        btnInventory.ForeColor = Color.White
        btnInventory.Image = My.Resources.Resources.productivity
        btnInventory.Location = New Point(0, 277)
        btnInventory.Name = "btnInventory"
        btnInventory.Padding = New Padding(60, 0, 0, 0)
        btnInventory.Size = New Size(300, 60)
        btnInventory.TabIndex = 2
        btnInventory.Text = "Inventory"
        btnInventory.TextAlign = ContentAlignment.MiddleLeft
        btnInventory.UseVisualStyleBackColor = False
        ' 
        ' btnDashboard
        ' 
        btnDashboard.BackColor = Color.LightSlateGray
        btnDashboard.Dock = DockStyle.Top
        btnDashboard.FlatAppearance.BorderColor = Color.White
        btnDashboard.FlatAppearance.BorderSize = 0
        btnDashboard.FlatStyle = FlatStyle.Flat
        btnDashboard.Font = New Font("Century Gothic", 11F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        btnDashboard.ForeColor = Color.White
        btnDashboard.Image = My.Resources.Resources.dashboard_1_
        btnDashboard.Location = New Point(0, 217)
        btnDashboard.Name = "btnDashboard"
        btnDashboard.Padding = New Padding(60, 0, 0, 0)
        btnDashboard.Size = New Size(300, 60)
        btnDashboard.TabIndex = 1
        btnDashboard.Text = "Dashboard"
        btnDashboard.TextAlign = ContentAlignment.MiddleLeft
        btnDashboard.UseVisualStyleBackColor = False
        ' 
        ' Panel2
        ' 
        Panel2.BackColor = Color.LightSlateGray
        Panel2.Controls.Add(PictureBox1)
        Panel2.Controls.Add(Label1)
        Panel2.Dock = DockStyle.Top
        Panel2.Location = New Point(0, 0)
        Panel2.Name = "Panel2"
        Panel2.Size = New Size(300, 217)
        Panel2.TabIndex = 0
        ' 
        ' PictureBox1
        ' 
        PictureBox1.Image = My.Resources.Resources.silver_membership_icon_default_avatar_profile_icon_membership_icon_social_media_user_image_illustration_vector
        PictureBox1.Location = New Point(43, 41)
        PictureBox1.Name = "PictureBox1"
        PictureBox1.Size = New Size(100, 100)
        PictureBox1.SizeMode = PictureBoxSizeMode.StretchImage
        PictureBox1.TabIndex = 1
        PictureBox1.TabStop = False
        ' 
        ' Label1
        ' 
        Label1.AutoSize = True
        Label1.BackColor = Color.LightSlateGray
        Label1.Font = New Font("Century Gothic", 11F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        Label1.ForeColor = Color.White
        Label1.Location = New Point(149, 79)
        Label1.Name = "Label1"
        Label1.Size = New Size(61, 26)
        Label1.TabIndex = 0
        Label1.Text = "USER"
        ' 
        ' mainPanel
        ' 
        mainPanel.BackColor = Color.White
        mainPanel.Dock = DockStyle.Fill
        mainPanel.Location = New Point(300, 0)
        mainPanel.Name = "mainPanel"
        mainPanel.Size = New Size(1378, 934)
        mainPanel.TabIndex = 1
        ' 
        ' frmInterface
        ' 
        AutoScaleMode = AutoScaleMode.None
        ClientSize = New Size(1678, 934)
        ControlBox = False
        Controls.Add(mainPanel)
        Controls.Add(Panel1)
        FormBorderStyle = FormBorderStyle.None
        MaximizeBox = False
        MinimizeBox = False
        Name = "frmInterface"
        StartPosition = FormStartPosition.CenterScreen
        Text = "User"
        WindowState = FormWindowState.Maximized
        Panel1.ResumeLayout(False)
        Panel2.ResumeLayout(False)
        Panel2.PerformLayout()
        CType(PictureBox1, ComponentModel.ISupportInitialize).EndInit()
        ResumeLayout(False)
    End Sub

    Friend WithEvents Panel1 As Panel
    Friend WithEvents Panel2 As Panel
    Friend WithEvents mainPanel As Panel
    Friend WithEvents btnDashboard As Button
    Friend WithEvents btnSales As Button
    Friend WithEvents btnLogs As Button
    Friend WithEvents btnData As Button
    Friend WithEvents btnArch As Button
    Friend WithEvents btnAccounts As Button
    Friend WithEvents btnPOS As Button
    Friend WithEvents btnInventory As Button
    Friend WithEvents btnExit As Button
    Friend WithEvents btnLogOut As Button
    Friend WithEvents Panel3 As Panel
    Friend WithEvents Label1 As Label
    Friend WithEvents PictureBox1 As PictureBox
End Class
