<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class InventoryPOS
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
        components = New ComponentModel.Container()
        Panel1 = New Panel()
        btnArchive = New Button()
        btnDefects = New Button()
        submenupanel = New Panel()
        btnStockOut = New Button()
        btnStockIn = New Button()
        btnStocks = New Button()
        btnSuppliers = New Button()
        btnCategories = New Button()
        btnProducts = New Button()
        btnHome = New Button()
        Panel2 = New Panel()
        Label1 = New Label()
        PictureBox2 = New PictureBox()
        InvPanel = New Panel()
        Boom = New Timer(components)
        Panel1.SuspendLayout()
        submenupanel.SuspendLayout()
        Panel2.SuspendLayout()
        CType(PictureBox2, ComponentModel.ISupportInitialize).BeginInit()
        SuspendLayout()
        ' 
        ' Panel1
        ' 
        Panel1.BackColor = Color.LightSlateGray
        Panel1.Controls.Add(btnArchive)
        Panel1.Controls.Add(btnDefects)
        Panel1.Controls.Add(submenupanel)
        Panel1.Controls.Add(btnStocks)
        Panel1.Controls.Add(btnSuppliers)
        Panel1.Controls.Add(btnCategories)
        Panel1.Controls.Add(btnProducts)
        Panel1.Controls.Add(btnHome)
        Panel1.Controls.Add(Panel2)
        Panel1.Dock = DockStyle.Left
        Panel1.Location = New Point(0, 0)
        Panel1.Name = "Panel1"
        Panel1.Size = New Size(300, 934)
        Panel1.TabIndex = 0
        ' 
        ' btnArchive
        ' 
        btnArchive.BackColor = Color.LightSlateGray
        btnArchive.Dock = DockStyle.Top
        btnArchive.FlatAppearance.BorderSize = 0
        btnArchive.FlatStyle = FlatStyle.Flat
        btnArchive.Font = New Font("Century Gothic", 11F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        btnArchive.ForeColor = Color.White
        btnArchive.Image = My.Resources.Resources.no_order
        btnArchive.Location = New Point(0, 696)
        btnArchive.Name = "btnArchive"
        btnArchive.Padding = New Padding(60, 0, 0, 0)
        btnArchive.Size = New Size(300, 60)
        btnArchive.TabIndex = 8
        btnArchive.Text = "Archives"
        btnArchive.TextAlign = ContentAlignment.MiddleLeft
        btnArchive.UseVisualStyleBackColor = False
        ' 
        ' btnDefects
        ' 
        btnDefects.BackColor = Color.LightSlateGray
        btnDefects.Dock = DockStyle.Top
        btnDefects.FlatAppearance.BorderSize = 0
        btnDefects.FlatStyle = FlatStyle.Flat
        btnDefects.Font = New Font("Century Gothic", 11F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        btnDefects.ForeColor = Color.White
        btnDefects.Location = New Point(0, 636)
        btnDefects.Name = "btnDefects"
        btnDefects.Padding = New Padding(60, 0, 0, 0)
        btnDefects.Size = New Size(300, 60)
        btnDefects.TabIndex = 7
        btnDefects.Text = "Defects"
        btnDefects.TextAlign = ContentAlignment.MiddleLeft
        btnDefects.UseVisualStyleBackColor = False
        ' 
        ' submenupanel
        ' 
        submenupanel.BackColor = Color.LightSteelBlue
        submenupanel.Controls.Add(btnStockOut)
        submenupanel.Controls.Add(btnStockIn)
        submenupanel.Dock = DockStyle.Top
        submenupanel.Location = New Point(0, 516)
        submenupanel.Name = "submenupanel"
        submenupanel.Size = New Size(300, 120)
        submenupanel.TabIndex = 9
        ' 
        ' btnStockOut
        ' 
        btnStockOut.BackColor = Color.LightSteelBlue
        btnStockOut.Dock = DockStyle.Top
        btnStockOut.FlatAppearance.BorderSize = 0
        btnStockOut.FlatStyle = FlatStyle.Flat
        btnStockOut.Font = New Font("Century Gothic", 11F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        btnStockOut.ForeColor = Color.White
        btnStockOut.Image = My.Resources.Resources.sold_out
        btnStockOut.Location = New Point(0, 60)
        btnStockOut.Name = "btnStockOut"
        btnStockOut.Padding = New Padding(85, 0, 0, 0)
        btnStockOut.Size = New Size(300, 60)
        btnStockOut.TabIndex = 8
        btnStockOut.Text = "Stock Out"
        btnStockOut.TextAlign = ContentAlignment.MiddleLeft
        btnStockOut.UseVisualStyleBackColor = False
        ' 
        ' btnStockIn
        ' 
        btnStockIn.BackColor = Color.LightSteelBlue
        btnStockIn.Dock = DockStyle.Top
        btnStockIn.FlatAppearance.BorderSize = 0
        btnStockIn.FlatStyle = FlatStyle.Flat
        btnStockIn.Font = New Font("Century Gothic", 11F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        btnStockIn.ForeColor = Color.White
        btnStockIn.Image = My.Resources.Resources.now_in_stock
        btnStockIn.Location = New Point(0, 0)
        btnStockIn.Name = "btnStockIn"
        btnStockIn.Padding = New Padding(85, 0, 0, 0)
        btnStockIn.Size = New Size(300, 60)
        btnStockIn.TabIndex = 7
        btnStockIn.Text = "Stock In"
        btnStockIn.TextAlign = ContentAlignment.MiddleLeft
        btnStockIn.UseVisualStyleBackColor = False
        ' 
        ' btnStocks
        ' 
        btnStocks.BackColor = Color.LightSlateGray
        btnStocks.Dock = DockStyle.Top
        btnStocks.FlatAppearance.BorderSize = 0
        btnStocks.FlatStyle = FlatStyle.Flat
        btnStocks.Font = New Font("Century Gothic", 11F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        btnStocks.ForeColor = Color.White
        btnStocks.Image = My.Resources.Resources.food
        btnStocks.Location = New Point(0, 456)
        btnStocks.Name = "btnStocks"
        btnStocks.Padding = New Padding(60, 0, 0, 0)
        btnStocks.Size = New Size(300, 60)
        btnStocks.TabIndex = 6
        btnStocks.Text = "Stocks"
        btnStocks.TextAlign = ContentAlignment.MiddleLeft
        btnStocks.UseVisualStyleBackColor = False
        ' 
        ' btnSuppliers
        ' 
        btnSuppliers.BackColor = Color.LightSlateGray
        btnSuppliers.Dock = DockStyle.Top
        btnSuppliers.FlatAppearance.BorderSize = 0
        btnSuppliers.FlatStyle = FlatStyle.Flat
        btnSuppliers.Font = New Font("Century Gothic", 11F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        btnSuppliers.ForeColor = Color.White
        btnSuppliers.Image = My.Resources.Resources.supplier
        btnSuppliers.Location = New Point(0, 396)
        btnSuppliers.Name = "btnSuppliers"
        btnSuppliers.Padding = New Padding(60, 0, 0, 0)
        btnSuppliers.Size = New Size(300, 60)
        btnSuppliers.TabIndex = 5
        btnSuppliers.Text = "Suppliers"
        btnSuppliers.TextAlign = ContentAlignment.MiddleLeft
        btnSuppliers.UseVisualStyleBackColor = False
        ' 
        ' btnCategories
        ' 
        btnCategories.BackColor = Color.LightSlateGray
        btnCategories.Dock = DockStyle.Top
        btnCategories.FlatAppearance.BorderSize = 0
        btnCategories.FlatStyle = FlatStyle.Flat
        btnCategories.Font = New Font("Century Gothic", 11F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        btnCategories.ForeColor = Color.White
        btnCategories.Image = My.Resources.Resources.list
        btnCategories.Location = New Point(0, 336)
        btnCategories.Name = "btnCategories"
        btnCategories.Padding = New Padding(60, 0, 0, 0)
        btnCategories.Size = New Size(300, 60)
        btnCategories.TabIndex = 4
        btnCategories.Text = "Categories"
        btnCategories.TextAlign = ContentAlignment.MiddleLeft
        btnCategories.UseVisualStyleBackColor = False
        ' 
        ' btnProducts
        ' 
        btnProducts.BackColor = Color.LightSlateGray
        btnProducts.Dock = DockStyle.Top
        btnProducts.FlatAppearance.BorderSize = 0
        btnProducts.FlatStyle = FlatStyle.Flat
        btnProducts.Font = New Font("Century Gothic", 11F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        btnProducts.ForeColor = Color.White
        btnProducts.Image = My.Resources.Resources.box
        btnProducts.Location = New Point(0, 276)
        btnProducts.Name = "btnProducts"
        btnProducts.Padding = New Padding(60, 0, 0, 0)
        btnProducts.Size = New Size(300, 60)
        btnProducts.TabIndex = 3
        btnProducts.Text = "Products"
        btnProducts.TextAlign = ContentAlignment.MiddleLeft
        btnProducts.UseVisualStyleBackColor = False
        ' 
        ' btnHome
        ' 
        btnHome.BackColor = Color.LightSlateGray
        btnHome.Dock = DockStyle.Top
        btnHome.FlatAppearance.BorderSize = 0
        btnHome.FlatStyle = FlatStyle.Flat
        btnHome.Font = New Font("Century Gothic", 11F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        btnHome.ForeColor = Color.White
        btnHome.Image = My.Resources.Resources.home_1_
        btnHome.Location = New Point(0, 216)
        btnHome.Name = "btnHome"
        btnHome.Padding = New Padding(60, 0, 0, 0)
        btnHome.Size = New Size(300, 60)
        btnHome.TabIndex = 2
        btnHome.Text = "Home"
        btnHome.TextAlign = ContentAlignment.MiddleLeft
        btnHome.UseVisualStyleBackColor = False
        ' 
        ' Panel2
        ' 
        Panel2.Controls.Add(Label1)
        Panel2.Controls.Add(PictureBox2)
        Panel2.Dock = DockStyle.Top
        Panel2.Location = New Point(0, 0)
        Panel2.Name = "Panel2"
        Panel2.Size = New Size(300, 216)
        Panel2.TabIndex = 0
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
        Label1.TabIndex = 3
        Label1.Text = "USER"
        ' 
        ' PictureBox2
        ' 
        PictureBox2.Image = My.Resources.Resources.silver_membership_icon_default_avatar_profile_icon_membership_icon_social_media_user_image_illustration_vector
        PictureBox2.Location = New Point(43, 41)
        PictureBox2.Name = "PictureBox2"
        PictureBox2.Size = New Size(100, 100)
        PictureBox2.SizeMode = PictureBoxSizeMode.StretchImage
        PictureBox2.TabIndex = 2
        PictureBox2.TabStop = False
        ' 
        ' InvPanel
        ' 
        InvPanel.BackColor = Color.White
        InvPanel.Dock = DockStyle.Fill
        InvPanel.Location = New Point(300, 0)
        InvPanel.Name = "InvPanel"
        InvPanel.Size = New Size(1378, 934)
        InvPanel.TabIndex = 1
        ' 
        ' Boom
        ' 
        Boom.Interval = 15
        ' 
        ' InventoryPOS
        ' 
        AutoScaleDimensions = New SizeF(10F, 25F)
        AutoScaleMode = AutoScaleMode.Font
        ClientSize = New Size(1678, 934)
        Controls.Add(InvPanel)
        Controls.Add(Panel1)
        FormBorderStyle = FormBorderStyle.None
        MaximizeBox = False
        MinimizeBox = False
        Name = "InventoryPOS"
        StartPosition = FormStartPosition.CenterScreen
        Text = "User"
        WindowState = FormWindowState.Maximized
        Panel1.ResumeLayout(False)
        submenupanel.ResumeLayout(False)
        Panel2.ResumeLayout(False)
        Panel2.PerformLayout()
        CType(PictureBox2, ComponentModel.ISupportInitialize).EndInit()
        ResumeLayout(False)
    End Sub

    Friend WithEvents Panel1 As Panel
    Friend WithEvents Panel2 As Panel
    Friend WithEvents InvPanel As Panel
    Friend WithEvents btnDefects As Button
    Friend WithEvents btnStocks As Button
    Friend WithEvents btnSuppliers As Button
    Friend WithEvents btnCategories As Button
    Friend WithEvents btnProducts As Button
    Friend WithEvents btnHome As Button
    Friend WithEvents btnArchive As Button
    Friend WithEvents submenupanel As Panel
    Friend WithEvents btnStockOut As Button
    Friend WithEvents btnStockIn As Button
    Friend WithEvents Boom As Timer
    Friend WithEvents PictureBox2 As PictureBox
    Friend WithEvents Label1 As Label
End Class
