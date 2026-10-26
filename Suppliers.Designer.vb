<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Suppliers
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
        Dim DataGridViewCellStyle3 As DataGridViewCellStyle = New DataGridViewCellStyle()
        Panel1 = New Panel()
        lblActiveDate33 = New Label()
        lblUsername33 = New Label()
        lblActiveTime33 = New Label()
        Panel3 = New Panel()
        lblCls = New Label()
        txtSearchSupp = New TextBox()
        Label1 = New Label()
        btnArchiveSp = New Button()
        btnEditSp = New Button()
        btnAddSupp = New Button()
        Panel2 = New Panel()
        panelSuppliers = New Panel()
        dbSuppliers = New DataGridView()
        Tick3 = New Timer(components)
        Panel1.SuspendLayout()
        Panel3.SuspendLayout()
        panelSuppliers.SuspendLayout()
        CType(dbSuppliers, ComponentModel.ISupportInitialize).BeginInit()
        SuspendLayout()
        ' 
        ' Panel1
        ' 
        Panel1.BackColor = Color.LightSlateGray
        Panel1.Controls.Add(lblActiveDate33)
        Panel1.Controls.Add(lblUsername33)
        Panel1.Controls.Add(lblActiveTime33)
        Panel1.Controls.Add(Panel3)
        Panel1.Controls.Add(Label1)
        Panel1.Controls.Add(btnArchiveSp)
        Panel1.Controls.Add(btnEditSp)
        Panel1.Controls.Add(btnAddSupp)
        Panel1.Dock = DockStyle.Top
        Panel1.Location = New Point(0, 0)
        Panel1.Name = "Panel1"
        Panel1.Size = New Size(1523, 164)
        Panel1.TabIndex = 8
        ' 
        ' lblActiveDate33
        ' 
        lblActiveDate33.AutoSize = True
        lblActiveDate33.Font = New Font("Century Gothic", 10F)
        lblActiveDate33.ForeColor = SystemColors.ControlLightLight
        lblActiveDate33.Location = New Point(1315, 16)
        lblActiveDate33.Name = "lblActiveDate33"
        lblActiveDate33.Size = New Size(76, 23)
        lblActiveDate33.TabIndex = 12
        lblActiveDate33.Text = "Label1"
        ' 
        ' lblUsername33
        ' 
        lblUsername33.AutoSize = True
        lblUsername33.Font = New Font("Century Gothic", 10F)
        lblUsername33.ForeColor = SystemColors.ControlLightLight
        lblUsername33.Location = New Point(1315, 82)
        lblUsername33.Name = "lblUsername33"
        lblUsername33.Size = New Size(76, 23)
        lblUsername33.TabIndex = 13
        lblUsername33.Text = "Label1"
        ' 
        ' lblActiveTime33
        ' 
        lblActiveTime33.AutoSize = True
        lblActiveTime33.Font = New Font("Century Gothic", 10F)
        lblActiveTime33.ForeColor = SystemColors.ControlLightLight
        lblActiveTime33.Location = New Point(1315, 50)
        lblActiveTime33.Name = "lblActiveTime33"
        lblActiveTime33.Size = New Size(76, 23)
        lblActiveTime33.TabIndex = 14
        lblActiveTime33.Text = "Label1"
        ' 
        ' Panel3
        ' 
        Panel3.BackColor = SystemColors.Window
        Panel3.Controls.Add(lblCls)
        Panel3.Controls.Add(txtSearchSupp)
        Panel3.Location = New Point(791, 93)
        Panel3.Name = "Panel3"
        Panel3.Size = New Size(378, 54)
        Panel3.TabIndex = 9
        ' 
        ' lblCls
        ' 
        lblCls.AutoSize = True
        lblCls.BackColor = SystemColors.Window
        lblCls.Cursor = Cursors.Hand
        lblCls.Font = New Font("Century Gothic", 9F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        lblCls.ForeColor = Color.Gray
        lblCls.Location = New Point(348, 15)
        lblCls.Name = "lblCls"
        lblCls.Size = New Size(20, 22)
        lblCls.TabIndex = 6
        lblCls.Text = "x"
        ' 
        ' txtSearchSupp
        ' 
        txtSearchSupp.BorderStyle = BorderStyle.None
        txtSearchSupp.Location = New Point(12, 16)
        txtSearchSupp.Name = "txtSearchSupp"
        txtSearchSupp.Size = New Size(330, 24)
        txtSearchSupp.TabIndex = 3
        ' 
        ' Label1
        ' 
        Label1.AutoSize = True
        Label1.Font = New Font("Century Gothic", 16F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        Label1.ForeColor = SystemColors.ControlLightLight
        Label1.Location = New Point(588, 9)
        Label1.Name = "Label1"
        Label1.Size = New Size(192, 38)
        Label1.TabIndex = 8
        Label1.Text = "INVENTORY"
        ' 
        ' btnArchiveSp
        ' 
        btnArchiveSp.BackColor = Color.Firebrick
        btnArchiveSp.FlatAppearance.BorderColor = Color.Silver
        btnArchiveSp.FlatStyle = FlatStyle.Flat
        btnArchiveSp.Font = New Font("Century Gothic", 9F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        btnArchiveSp.ForeColor = SystemColors.ControlLightLight
        btnArchiveSp.Location = New Point(651, 108)
        btnArchiveSp.Margin = New Padding(0)
        btnArchiveSp.Name = "btnArchiveSp"
        btnArchiveSp.Size = New Size(114, 39)
        btnArchiveSp.TabIndex = 6
        btnArchiveSp.Text = "ARCHIVE"
        btnArchiveSp.UseVisualStyleBackColor = False
        ' 
        ' btnEditSp
        ' 
        btnEditSp.BackColor = Color.Teal
        btnEditSp.FlatAppearance.BorderColor = Color.Silver
        btnEditSp.FlatStyle = FlatStyle.Flat
        btnEditSp.Font = New Font("Century Gothic", 9F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        btnEditSp.ForeColor = SystemColors.ControlLightLight
        btnEditSp.Location = New Point(525, 108)
        btnEditSp.Margin = New Padding(0)
        btnEditSp.Name = "btnEditSp"
        btnEditSp.Size = New Size(114, 39)
        btnEditSp.TabIndex = 3
        btnEditSp.Text = "EDIT"
        btnEditSp.UseVisualStyleBackColor = False
        ' 
        ' btnAddSupp
        ' 
        btnAddSupp.BackColor = Color.DarkSeaGreen
        btnAddSupp.FlatAppearance.BorderColor = Color.Silver
        btnAddSupp.FlatStyle = FlatStyle.Flat
        btnAddSupp.Font = New Font("Century Gothic", 9F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        btnAddSupp.ForeColor = SystemColors.ControlLightLight
        btnAddSupp.Location = New Point(399, 108)
        btnAddSupp.Margin = New Padding(0)
        btnAddSupp.Name = "btnAddSupp"
        btnAddSupp.Size = New Size(114, 39)
        btnAddSupp.TabIndex = 2
        btnAddSupp.Text = "ADD"
        btnAddSupp.UseVisualStyleBackColor = False
        ' 
        ' Panel2
        ' 
        Panel2.BackColor = Color.LightSlateGray
        Panel2.Dock = DockStyle.Bottom
        Panel2.Location = New Point(0, 864)
        Panel2.Name = "Panel2"
        Panel2.Size = New Size(1523, 70)
        Panel2.TabIndex = 9
        ' 
        ' panelSuppliers
        ' 
        panelSuppliers.BackColor = Color.White
        panelSuppliers.Controls.Add(dbSuppliers)
        panelSuppliers.Dock = DockStyle.Fill
        panelSuppliers.Location = New Point(0, 164)
        panelSuppliers.Name = "panelSuppliers"
        panelSuppliers.Size = New Size(1523, 700)
        panelSuppliers.TabIndex = 10
        ' 
        ' dbSuppliers
        ' 
        dbSuppliers.AllowUserToAddRows = False
        dbSuppliers.AllowUserToDeleteRows = False
        dbSuppliers.AllowUserToResizeColumns = False
        dbSuppliers.AllowUserToResizeRows = False
        DataGridViewCellStyle1.BackColor = Color.WhiteSmoke
        dbSuppliers.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
        dbSuppliers.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
        dbSuppliers.BackgroundColor = Color.LightSteelBlue
        dbSuppliers.BorderStyle = BorderStyle.None
        dbSuppliers.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal
        dbSuppliers.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single
        DataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle2.BackColor = Color.LightSlateGray
        DataGridViewCellStyle2.Font = New Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        DataGridViewCellStyle2.ForeColor = SystemColors.ControlLightLight
        DataGridViewCellStyle2.SelectionBackColor = Color.SlateGray
        DataGridViewCellStyle2.SelectionForeColor = SystemColors.HighlightText
        DataGridViewCellStyle2.WrapMode = DataGridViewTriState.True
        dbSuppliers.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle2
        dbSuppliers.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DataGridViewCellStyle3.Alignment = DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle3.BackColor = SystemColors.Window
        DataGridViewCellStyle3.Font = New Font("Century Gothic", 9F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        DataGridViewCellStyle3.ForeColor = SystemColors.ControlText
        DataGridViewCellStyle3.SelectionBackColor = Color.LightGray
        DataGridViewCellStyle3.SelectionForeColor = Color.Black
        DataGridViewCellStyle3.WrapMode = DataGridViewTriState.False
        dbSuppliers.DefaultCellStyle = DataGridViewCellStyle3
        dbSuppliers.Dock = DockStyle.Fill
        dbSuppliers.EnableHeadersVisualStyles = False
        dbSuppliers.GridColor = Color.Gainsboro
        dbSuppliers.Location = New Point(0, 0)
        dbSuppliers.MultiSelect = False
        dbSuppliers.Name = "dbSuppliers"
        dbSuppliers.ReadOnly = True
        dbSuppliers.RowHeadersVisible = False
        dbSuppliers.RowHeadersWidth = 62
        dbSuppliers.SelectionMode = DataGridViewSelectionMode.FullRowSelect
        dbSuppliers.Size = New Size(1523, 700)
        dbSuppliers.TabIndex = 0
        ' 
        ' Tick3
        ' 
        Tick3.Enabled = True
        Tick3.Interval = 1000
        ' 
        ' Suppliers
        ' 
        AutoScaleDimensions = New SizeF(10F, 25F)
        AutoScaleMode = AutoScaleMode.Font
        ClientSize = New Size(1523, 934)
        Controls.Add(panelSuppliers)
        Controls.Add(Panel2)
        Controls.Add(Panel1)
        FormBorderStyle = FormBorderStyle.None
        Name = "Suppliers"
        Text = "Suppliers"
        Panel1.ResumeLayout(False)
        Panel1.PerformLayout()
        Panel3.ResumeLayout(False)
        Panel3.PerformLayout()
        panelSuppliers.ResumeLayout(False)
        CType(dbSuppliers, ComponentModel.ISupportInitialize).EndInit()
        ResumeLayout(False)
    End Sub

    Friend WithEvents Panel1 As Panel
    Friend WithEvents Panel2 As Panel
    Friend WithEvents panelSuppliers As Panel
    Friend WithEvents dbSuppliers As DataGridView
    Friend WithEvents btnAddSupp As Button
    Friend WithEvents btnEditSp As Button
    Friend WithEvents btnArchiveSp As Button
    Friend WithEvents Label1 As Label
    Friend WithEvents Panel3 As Panel
    Friend WithEvents lblCls As Label
    Friend WithEvents txtSearchSupp As TextBox
    Friend WithEvents lblActiveDate33 As Label
    Friend WithEvents lblUsername33 As Label
    Friend WithEvents lblActiveTime33 As Label
    Friend WithEvents Tick3 As Timer
End Class
