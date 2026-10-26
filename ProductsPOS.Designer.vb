<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ProductsPOS
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
        Dim DataGridViewCellStyle1 As DataGridViewCellStyle = New DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As DataGridViewCellStyle = New DataGridViewCellStyle()
        panelp1 = New Panel()
        lblActiveDate11 = New Label()
        lblUsername11 = New Label()
        lblActiveTime11 = New Label()
        btnNotif = New Button()
        btnArchivePr = New Button()
        btnEditPr = New Button()
        btnAddProducts = New Button()
        Label1 = New Label()
        Panel3 = New Panel()
        txtSearch = New TextBox()
        panelp2 = New Panel()
        panelProducts = New Panel()
        dbProducts = New DataGridView()
        Tick1 = New Timer(components)
        panelp1.SuspendLayout()
        Panel3.SuspendLayout()
        panelProducts.SuspendLayout()
        CType(dbProducts, ComponentModel.ISupportInitialize).BeginInit()
        SuspendLayout()
        ' 
        ' panelp1
        ' 
        panelp1.BackColor = Color.LightSlateGray
        panelp1.Controls.Add(lblActiveDate11)
        panelp1.Controls.Add(lblUsername11)
        panelp1.Controls.Add(lblActiveTime11)
        panelp1.Controls.Add(btnNotif)
        panelp1.Controls.Add(btnArchivePr)
        panelp1.Controls.Add(btnEditPr)
        panelp1.Controls.Add(btnAddProducts)
        panelp1.Controls.Add(Label1)
        panelp1.Controls.Add(Panel3)
        panelp1.Dock = DockStyle.Top
        panelp1.Location = New Point(0, 0)
        panelp1.Name = "panelp1"
        panelp1.Size = New Size(1509, 164)
        panelp1.TabIndex = 3
        ' 
        ' lblActiveDate11
        ' 
        lblActiveDate11.AutoSize = True
        lblActiveDate11.Font = New Font("Century Gothic", 10F)
        lblActiveDate11.ForeColor = SystemColors.ControlLightLight
        lblActiveDate11.Location = New Point(1315, 16)
        lblActiveDate11.Name = "lblActiveDate11"
        lblActiveDate11.Size = New Size(76, 23)
        lblActiveDate11.TabIndex = 9
        lblActiveDate11.Text = "Label1"
        ' 
        ' lblUsername11
        ' 
        lblUsername11.AutoSize = True
        lblUsername11.Font = New Font("Century Gothic", 10F)
        lblUsername11.ForeColor = SystemColors.ControlLightLight
        lblUsername11.Location = New Point(1315, 82)
        lblUsername11.Name = "lblUsername11"
        lblUsername11.Size = New Size(76, 23)
        lblUsername11.TabIndex = 10
        lblUsername11.Text = "Label1"
        ' 
        ' lblActiveTime11
        ' 
        lblActiveTime11.AutoSize = True
        lblActiveTime11.Font = New Font("Century Gothic", 10F)
        lblActiveTime11.ForeColor = SystemColors.ControlLightLight
        lblActiveTime11.Location = New Point(1315, 50)
        lblActiveTime11.Name = "lblActiveTime11"
        lblActiveTime11.Size = New Size(76, 23)
        lblActiveTime11.TabIndex = 11
        lblActiveTime11.Text = "Label1"
        ' 
        ' btnNotif
        ' 
        btnNotif.BackColor = Color.Transparent
        btnNotif.FlatAppearance.BorderSize = 0
        btnNotif.FlatStyle = FlatStyle.Flat
        btnNotif.ForeColor = Color.Transparent
        btnNotif.Image = My.Resources.Resources.notification_bell
        btnNotif.Location = New Point(1215, 84)
        btnNotif.Name = "btnNotif"
        btnNotif.Size = New Size(60, 60)
        btnNotif.TabIndex = 7
        btnNotif.TabStop = False
        btnNotif.UseVisualStyleBackColor = False
        ' 
        ' btnArchivePr
        ' 
        btnArchivePr.BackColor = Color.Firebrick
        btnArchivePr.FlatAppearance.BorderColor = Color.Silver
        btnArchivePr.FlatStyle = FlatStyle.Flat
        btnArchivePr.Font = New Font("Century Gothic", 9F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        btnArchivePr.ForeColor = SystemColors.ControlLightLight
        btnArchivePr.Location = New Point(539, 102)
        btnArchivePr.Margin = New Padding(0)
        btnArchivePr.Name = "btnArchivePr"
        btnArchivePr.Size = New Size(114, 39)
        btnArchivePr.TabIndex = 5
        btnArchivePr.TabStop = False
        btnArchivePr.Text = "ARCHIVE"
        btnArchivePr.UseVisualStyleBackColor = False
        ' 
        ' btnEditPr
        ' 
        btnEditPr.BackColor = Color.Teal
        btnEditPr.FlatAppearance.BorderColor = Color.Silver
        btnEditPr.FlatStyle = FlatStyle.Flat
        btnEditPr.Font = New Font("Century Gothic", 9F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        btnEditPr.ForeColor = SystemColors.ControlLightLight
        btnEditPr.Location = New Point(413, 102)
        btnEditPr.Margin = New Padding(0)
        btnEditPr.Name = "btnEditPr"
        btnEditPr.Size = New Size(114, 39)
        btnEditPr.TabIndex = 2
        btnEditPr.TabStop = False
        btnEditPr.Text = "EDIT"
        btnEditPr.UseVisualStyleBackColor = False
        ' 
        ' btnAddProducts
        ' 
        btnAddProducts.BackColor = Color.DarkSeaGreen
        btnAddProducts.FlatAppearance.BorderColor = Color.Silver
        btnAddProducts.FlatStyle = FlatStyle.Flat
        btnAddProducts.Font = New Font("Century Gothic", 9F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        btnAddProducts.ForeColor = SystemColors.ControlLightLight
        btnAddProducts.Location = New Point(286, 102)
        btnAddProducts.Margin = New Padding(0)
        btnAddProducts.Name = "btnAddProducts"
        btnAddProducts.Size = New Size(114, 39)
        btnAddProducts.TabIndex = 1
        btnAddProducts.TabStop = False
        btnAddProducts.Text = "ADD"
        btnAddProducts.UseVisualStyleBackColor = False
        ' 
        ' Label1
        ' 
        Label1.AutoSize = True
        Label1.Font = New Font("Century Gothic", 16F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        Label1.ForeColor = SystemColors.ControlLightLight
        Label1.Location = New Point(588, 9)
        Label1.Name = "Label1"
        Label1.Size = New Size(192, 38)
        Label1.TabIndex = 6
        Label1.Text = "INVENTORY"
        ' 
        ' Panel3
        ' 
        Panel3.BackColor = SystemColors.Window
        Panel3.Controls.Add(txtSearch)
        Panel3.Location = New Point(831, 87)
        Panel3.Name = "Panel3"
        Panel3.Size = New Size(378, 54)
        Panel3.TabIndex = 4
        ' 
        ' txtSearch
        ' 
        txtSearch.BorderStyle = BorderStyle.None
        txtSearch.Location = New Point(13, 15)
        txtSearch.Name = "txtSearch"
        txtSearch.Size = New Size(353, 24)
        txtSearch.TabIndex = 3
        ' 
        ' panelp2
        ' 
        panelp2.BackColor = Color.LightSlateGray
        panelp2.Dock = DockStyle.Bottom
        panelp2.Location = New Point(0, 808)
        panelp2.Name = "panelp2"
        panelp2.Size = New Size(1509, 70)
        panelp2.TabIndex = 5
        ' 
        ' panelProducts
        ' 
        panelProducts.BackColor = Color.White
        panelProducts.Controls.Add(dbProducts)
        panelProducts.Dock = DockStyle.Fill
        panelProducts.Location = New Point(0, 164)
        panelProducts.Name = "panelProducts"
        panelProducts.Size = New Size(1509, 644)
        panelProducts.TabIndex = 6
        ' 
        ' dbProducts
        ' 
        dbProducts.AllowUserToAddRows = False
        dbProducts.AllowUserToDeleteRows = False
        dbProducts.AllowUserToResizeColumns = False
        dbProducts.AllowUserToResizeRows = False
        dbProducts.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
        dbProducts.BackgroundColor = Color.LightSteelBlue
        dbProducts.BorderStyle = BorderStyle.None
        dbProducts.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single
        DataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle1.BackColor = Color.LightSlateGray
        DataGridViewCellStyle1.Font = New Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        DataGridViewCellStyle1.ForeColor = Color.WhiteSmoke
        DataGridViewCellStyle1.SelectionBackColor = Color.SlateGray
        DataGridViewCellStyle1.SelectionForeColor = SystemColors.HighlightText
        DataGridViewCellStyle1.WrapMode = DataGridViewTriState.True
        dbProducts.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        dbProducts.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = SystemColors.Window
        DataGridViewCellStyle2.Font = New Font("Century Gothic", 9F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        DataGridViewCellStyle2.ForeColor = SystemColors.ControlText
        DataGridViewCellStyle2.SelectionBackColor = Color.LightGray
        DataGridViewCellStyle2.SelectionForeColor = Color.Black
        DataGridViewCellStyle2.WrapMode = DataGridViewTriState.False
        dbProducts.DefaultCellStyle = DataGridViewCellStyle2
        dbProducts.Dock = DockStyle.Fill
        dbProducts.EnableHeadersVisualStyles = False
        dbProducts.GridColor = Color.Gainsboro
        dbProducts.Location = New Point(0, 0)
        dbProducts.MultiSelect = False
        dbProducts.Name = "dbProducts"
        dbProducts.ReadOnly = True
        dbProducts.RowHeadersVisible = False
        dbProducts.RowHeadersWidth = 62
        dbProducts.ScrollBars = ScrollBars.Vertical
        dbProducts.SelectionMode = DataGridViewSelectionMode.FullRowSelect
        dbProducts.Size = New Size(1509, 644)
        dbProducts.TabIndex = 7
        ' 
        ' Tick1
        ' 
        Tick1.Enabled = True
        Tick1.Interval = 1000
        ' 
        ' ProductsPOS
        ' 
        AutoScaleDimensions = New SizeF(10F, 25F)
        AutoScaleMode = AutoScaleMode.Font
        ClientSize = New Size(1509, 878)
        ControlBox = False
        Controls.Add(panelProducts)
        Controls.Add(panelp2)
        Controls.Add(panelp1)
        FormBorderStyle = FormBorderStyle.None
        MaximizeBox = False
        MinimizeBox = False
        Name = "ProductsPOS"
        Text = "ProductsPOS"
        panelp1.ResumeLayout(False)
        panelp1.PerformLayout()
        Panel3.ResumeLayout(False)
        Panel3.PerformLayout()
        panelProducts.ResumeLayout(False)
        CType(dbProducts, ComponentModel.ISupportInitialize).EndInit()
        ResumeLayout(False)
    End Sub

    Friend WithEvents panelp1 As Panel
    Friend WithEvents panelp2 As Panel
    Friend WithEvents panelProducts As Panel
    Friend WithEvents dbProducts As DataGridView
    Friend WithEvents btnAddProducts As Button
    Friend WithEvents btnEditPr As Button
    Friend WithEvents Panel3 As Panel
    Friend WithEvents txtSearch As TextBox
    Friend WithEvents btnArchivePr As Button
    Friend WithEvents Label1 As Label
    Friend WithEvents btnNotif As Button
    Friend WithEvents lblActiveDate11 As Label
    Friend WithEvents lblUsername11 As Label
    Friend WithEvents lblActiveTime11 As Label
    Friend WithEvents Tick1 As Timer
End Class
