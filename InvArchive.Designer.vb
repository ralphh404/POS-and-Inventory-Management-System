<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class InvArchive
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
        Dim DataGridViewCellStyle4 As DataGridViewCellStyle = New DataGridViewCellStyle()
        Panel1 = New Panel()
        PanelSu = New Panel()
        lblCls = New Label()
        txtSupp = New TextBox()
        PanelPo = New Panel()
        lblClp = New Label()
        txtSearchProd = New TextBox()
        lblActiveDate66 = New Label()
        lblUsername66 = New Label()
        lblActiveTime66 = New Label()
        Label1 = New Label()
        btnRestoreSp = New Button()
        btnRestorePr = New Button()
        btnSupAc = New Button()
        btnProdAc = New Button()
        Panel2 = New Panel()
        panelArcProducts = New Panel()
        dbArcProducts = New DataGridView()
        panelSuppAC = New Panel()
        dbSupplierArc = New DataGridView()
        Tick6 = New Timer(components)
        Panel1.SuspendLayout()
        PanelSu.SuspendLayout()
        PanelPo.SuspendLayout()
        panelArcProducts.SuspendLayout()
        CType(dbArcProducts, ComponentModel.ISupportInitialize).BeginInit()
        panelSuppAC.SuspendLayout()
        CType(dbSupplierArc, ComponentModel.ISupportInitialize).BeginInit()
        SuspendLayout()
        ' 
        ' Panel1
        ' 
        Panel1.BackColor = Color.LightSlateGray
        Panel1.Controls.Add(PanelSu)
        Panel1.Controls.Add(PanelPo)
        Panel1.Controls.Add(lblActiveDate66)
        Panel1.Controls.Add(lblUsername66)
        Panel1.Controls.Add(lblActiveTime66)
        Panel1.Controls.Add(Label1)
        Panel1.Controls.Add(btnRestoreSp)
        Panel1.Controls.Add(btnRestorePr)
        Panel1.Controls.Add(btnSupAc)
        Panel1.Controls.Add(btnProdAc)
        Panel1.Dock = DockStyle.Top
        Panel1.Location = New Point(0, 0)
        Panel1.Name = "Panel1"
        Panel1.Size = New Size(1519, 231)
        Panel1.TabIndex = 8
        ' 
        ' PanelSu
        ' 
        PanelSu.BackColor = SystemColors.Window
        PanelSu.Controls.Add(lblCls)
        PanelSu.Controls.Add(txtSupp)
        PanelSu.Location = New Point(903, 148)
        PanelSu.Name = "PanelSu"
        PanelSu.Size = New Size(378, 54)
        PanelSu.TabIndex = 15
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
        ' txtSupp
        ' 
        txtSupp.BorderStyle = BorderStyle.None
        txtSupp.Location = New Point(12, 16)
        txtSupp.Name = "txtSupp"
        txtSupp.Size = New Size(330, 24)
        txtSupp.TabIndex = 3
        ' 
        ' PanelPo
        ' 
        PanelPo.BackColor = SystemColors.Window
        PanelPo.Controls.Add(lblClp)
        PanelPo.Controls.Add(txtSearchProd)
        PanelPo.Location = New Point(903, 148)
        PanelPo.Name = "PanelPo"
        PanelPo.Size = New Size(378, 54)
        PanelPo.TabIndex = 15
        ' 
        ' lblClp
        ' 
        lblClp.AutoSize = True
        lblClp.BackColor = SystemColors.Window
        lblClp.Cursor = Cursors.Hand
        lblClp.Font = New Font("Century Gothic", 9F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        lblClp.ForeColor = Color.Gray
        lblClp.Location = New Point(348, 15)
        lblClp.Name = "lblClp"
        lblClp.Size = New Size(20, 22)
        lblClp.TabIndex = 6
        lblClp.Text = "x"
        ' 
        ' txtSearchProd
        ' 
        txtSearchProd.BorderStyle = BorderStyle.None
        txtSearchProd.Location = New Point(12, 16)
        txtSearchProd.Name = "txtSearchProd"
        txtSearchProd.Size = New Size(330, 24)
        txtSearchProd.TabIndex = 3
        ' 
        ' lblActiveDate66
        ' 
        lblActiveDate66.AutoSize = True
        lblActiveDate66.Font = New Font("Century Gothic", 10F)
        lblActiveDate66.ForeColor = SystemColors.ControlLightLight
        lblActiveDate66.Location = New Point(1315, 16)
        lblActiveDate66.Name = "lblActiveDate66"
        lblActiveDate66.Size = New Size(76, 23)
        lblActiveDate66.TabIndex = 12
        lblActiveDate66.Text = "Label1"
        ' 
        ' lblUsername66
        ' 
        lblUsername66.AutoSize = True
        lblUsername66.Font = New Font("Century Gothic", 10F)
        lblUsername66.ForeColor = SystemColors.ControlLightLight
        lblUsername66.Location = New Point(1315, 82)
        lblUsername66.Name = "lblUsername66"
        lblUsername66.Size = New Size(76, 23)
        lblUsername66.TabIndex = 13
        lblUsername66.Text = "Label1"
        ' 
        ' lblActiveTime66
        ' 
        lblActiveTime66.AutoSize = True
        lblActiveTime66.Font = New Font("Century Gothic", 10F)
        lblActiveTime66.ForeColor = SystemColors.ControlLightLight
        lblActiveTime66.Location = New Point(1315, 50)
        lblActiveTime66.Name = "lblActiveTime66"
        lblActiveTime66.Size = New Size(76, 23)
        lblActiveTime66.TabIndex = 14
        lblActiveTime66.Text = "Label1"
        ' 
        ' Label1
        ' 
        Label1.AutoSize = True
        Label1.Font = New Font("Century Gothic", 16F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        Label1.ForeColor = SystemColors.ControlLightLight
        Label1.Location = New Point(588, 9)
        Label1.Name = "Label1"
        Label1.Size = New Size(155, 38)
        Label1.TabIndex = 8
        Label1.Text = "ARCHIVE"
        ' 
        ' btnRestoreSp
        ' 
        btnRestoreSp.BackColor = Color.DarkSeaGreen
        btnRestoreSp.FlatAppearance.BorderColor = Color.Silver
        btnRestoreSp.FlatStyle = FlatStyle.Flat
        btnRestoreSp.Font = New Font("Century Gothic", 9F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        btnRestoreSp.ForeColor = SystemColors.ControlLightLight
        btnRestoreSp.Location = New Point(712, 163)
        btnRestoreSp.Margin = New Padding(0)
        btnRestoreSp.Name = "btnRestoreSp"
        btnRestoreSp.Size = New Size(114, 39)
        btnRestoreSp.TabIndex = 6
        btnRestoreSp.Text = "RESTORE"
        btnRestoreSp.UseVisualStyleBackColor = False
        ' 
        ' btnRestorePr
        ' 
        btnRestorePr.BackColor = Color.YellowGreen
        btnRestorePr.FlatAppearance.BorderColor = Color.Silver
        btnRestorePr.FlatStyle = FlatStyle.Flat
        btnRestorePr.Font = New Font("Century Gothic", 9F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        btnRestorePr.ForeColor = SystemColors.ControlLightLight
        btnRestorePr.Location = New Point(712, 163)
        btnRestorePr.Margin = New Padding(0)
        btnRestorePr.Name = "btnRestorePr"
        btnRestorePr.Size = New Size(114, 39)
        btnRestorePr.TabIndex = 6
        btnRestorePr.Text = "RESTORE"
        btnRestorePr.UseVisualStyleBackColor = False
        ' 
        ' btnSupAc
        ' 
        btnSupAc.BackColor = Color.LightSteelBlue
        btnSupAc.FlatAppearance.BorderSize = 0
        btnSupAc.FlatStyle = FlatStyle.Flat
        btnSupAc.Font = New Font("Century Gothic", 10F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        btnSupAc.ForeColor = Color.WhiteSmoke
        btnSupAc.Location = New Point(3, 153)
        btnSupAc.Name = "btnSupAc"
        btnSupAc.Size = New Size(688, 49)
        btnSupAc.TabIndex = 0
        btnSupAc.Text = "Suppliers"
        btnSupAc.UseVisualStyleBackColor = False
        ' 
        ' btnProdAc
        ' 
        btnProdAc.BackColor = Color.LightSteelBlue
        btnProdAc.FlatAppearance.BorderSize = 0
        btnProdAc.FlatStyle = FlatStyle.Flat
        btnProdAc.Font = New Font("Century Gothic", 10F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        btnProdAc.ForeColor = Color.WhiteSmoke
        btnProdAc.Location = New Point(3, 98)
        btnProdAc.Name = "btnProdAc"
        btnProdAc.Size = New Size(688, 49)
        btnProdAc.TabIndex = 0
        btnProdAc.Text = "Products"
        btnProdAc.UseVisualStyleBackColor = False
        ' 
        ' Panel2
        ' 
        Panel2.BackColor = Color.LightSlateGray
        Panel2.Dock = DockStyle.Bottom
        Panel2.Location = New Point(0, 864)
        Panel2.Name = "Panel2"
        Panel2.Size = New Size(1519, 70)
        Panel2.TabIndex = 9
        ' 
        ' panelArcProducts
        ' 
        panelArcProducts.BackColor = Color.White
        panelArcProducts.Controls.Add(dbArcProducts)
        panelArcProducts.Dock = DockStyle.Fill
        panelArcProducts.Location = New Point(0, 231)
        panelArcProducts.Name = "panelArcProducts"
        panelArcProducts.Size = New Size(1519, 633)
        panelArcProducts.TabIndex = 10
        ' 
        ' dbArcProducts
        ' 
        dbArcProducts.AllowUserToAddRows = False
        dbArcProducts.AllowUserToDeleteRows = False
        dbArcProducts.AllowUserToOrderColumns = True
        dbArcProducts.AllowUserToResizeColumns = False
        dbArcProducts.AllowUserToResizeRows = False
        dbArcProducts.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
        dbArcProducts.BackgroundColor = Color.Gainsboro
        dbArcProducts.BorderStyle = BorderStyle.None
        dbArcProducts.CellBorderStyle = DataGridViewCellBorderStyle.None
        DataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle1.BackColor = SystemColors.Control
        DataGridViewCellStyle1.Font = New Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        DataGridViewCellStyle1.ForeColor = SystemColors.WindowText
        DataGridViewCellStyle1.SelectionBackColor = SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = SystemColors.HighlightText
        DataGridViewCellStyle1.WrapMode = DataGridViewTriState.True
        dbArcProducts.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        dbArcProducts.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize
        dbArcProducts.Dock = DockStyle.Fill
        dbArcProducts.Location = New Point(0, 0)
        dbArcProducts.Name = "dbArcProducts"
        dbArcProducts.ReadOnly = True
        dbArcProducts.RowHeadersVisible = False
        dbArcProducts.RowHeadersWidth = 62
        dbArcProducts.SelectionMode = DataGridViewSelectionMode.FullRowSelect
        dbArcProducts.Size = New Size(1519, 633)
        dbArcProducts.TabIndex = 0
        ' 
        ' panelSuppAC
        ' 
        panelSuppAC.Controls.Add(dbSupplierArc)
        panelSuppAC.Dock = DockStyle.Fill
        panelSuppAC.Location = New Point(0, 231)
        panelSuppAC.Name = "panelSuppAC"
        panelSuppAC.Size = New Size(1519, 633)
        panelSuppAC.TabIndex = 11
        ' 
        ' dbSupplierArc
        ' 
        dbSupplierArc.AllowUserToAddRows = False
        dbSupplierArc.AllowUserToDeleteRows = False
        dbSupplierArc.AllowUserToResizeColumns = False
        dbSupplierArc.AllowUserToResizeRows = False
        DataGridViewCellStyle2.BackColor = Color.WhiteSmoke
        dbSupplierArc.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle2
        dbSupplierArc.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
        dbSupplierArc.BackgroundColor = Color.LightSteelBlue
        dbSupplierArc.BorderStyle = BorderStyle.None
        dbSupplierArc.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal
        dbSupplierArc.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single
        DataGridViewCellStyle3.Alignment = DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle3.BackColor = Color.LightSlateGray
        DataGridViewCellStyle3.Font = New Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        DataGridViewCellStyle3.ForeColor = Color.White
        DataGridViewCellStyle3.SelectionBackColor = Color.SlateGray
        DataGridViewCellStyle3.SelectionForeColor = SystemColors.HighlightText
        DataGridViewCellStyle3.WrapMode = DataGridViewTriState.True
        dbSupplierArc.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle3
        dbSupplierArc.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DataGridViewCellStyle4.Alignment = DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle4.BackColor = SystemColors.Window
        DataGridViewCellStyle4.Font = New Font("Century Gothic", 9F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        DataGridViewCellStyle4.ForeColor = SystemColors.ControlText
        DataGridViewCellStyle4.SelectionBackColor = Color.LightGray
        DataGridViewCellStyle4.SelectionForeColor = Color.Black
        DataGridViewCellStyle4.WrapMode = DataGridViewTriState.False
        dbSupplierArc.DefaultCellStyle = DataGridViewCellStyle4
        dbSupplierArc.Dock = DockStyle.Fill
        dbSupplierArc.EnableHeadersVisualStyles = False
        dbSupplierArc.GridColor = Color.Gainsboro
        dbSupplierArc.Location = New Point(0, 0)
        dbSupplierArc.MultiSelect = False
        dbSupplierArc.Name = "dbSupplierArc"
        dbSupplierArc.ReadOnly = True
        dbSupplierArc.RowHeadersVisible = False
        dbSupplierArc.RowHeadersWidth = 62
        dbSupplierArc.SelectionMode = DataGridViewSelectionMode.FullRowSelect
        dbSupplierArc.Size = New Size(1519, 633)
        dbSupplierArc.TabIndex = 6
        ' 
        ' Tick6
        ' 
        Tick6.Enabled = True
        Tick6.Interval = 1000
        ' 
        ' InvArchive
        ' 
        AutoScaleDimensions = New SizeF(10F, 25F)
        AutoScaleMode = AutoScaleMode.Font
        ClientSize = New Size(1519, 934)
        Controls.Add(panelSuppAC)
        Controls.Add(panelArcProducts)
        Controls.Add(Panel2)
        Controls.Add(Panel1)
        FormBorderStyle = FormBorderStyle.None
        Name = "InvArchive"
        Text = "InvArchive"
        Panel1.ResumeLayout(False)
        Panel1.PerformLayout()
        PanelSu.ResumeLayout(False)
        PanelSu.PerformLayout()
        PanelPo.ResumeLayout(False)
        PanelPo.PerformLayout()
        panelArcProducts.ResumeLayout(False)
        CType(dbArcProducts, ComponentModel.ISupportInitialize).EndInit()
        panelSuppAC.ResumeLayout(False)
        CType(dbSupplierArc, ComponentModel.ISupportInitialize).EndInit()
        ResumeLayout(False)
    End Sub

    Friend WithEvents Panel1 As Panel
    Friend WithEvents Panel2 As Panel
    Friend WithEvents btnProdAc As Button
    Friend WithEvents btnSupAc As Button
    Friend WithEvents btnRestorePr As Button
    Friend WithEvents panelArcProducts As Panel
    Friend WithEvents dbArcProducts As DataGridView
    Friend WithEvents panelSuppAC As Panel
    Friend WithEvents dbSupplierArc As DataGridView
    Friend WithEvents btnRestoreSp As Button
    Friend WithEvents Label1 As Label
    Friend WithEvents lblActiveDate66 As Label
    Friend WithEvents lblUsername66 As Label
    Friend WithEvents lblActiveTime66 As Label
    Friend WithEvents Tick6 As Timer
    Friend WithEvents PanelPo As Panel
    Friend WithEvents lblClp As Label
    Friend WithEvents txtSearchProd As TextBox
    Friend WithEvents PanelSu As Panel
    Friend WithEvents lblCls As Label
    Friend WithEvents txtSupp As TextBox
End Class
