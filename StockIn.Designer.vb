<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class StockIn
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
        Panel2 = New Panel()
        panelStockIn = New Panel()
        dbStockIn = New DataGridView()
        btnAddStock = New Button()
        btnEditStock = New Button()
        Label1 = New Label()
        btnHistory = New Button()
        Panel3 = New Panel()
        lblClx = New Label()
        txtSearchStock = New TextBox()
        Panel1 = New Panel()
        lblActiveDate44 = New Label()
        lblUsername44 = New Label()
        lblActiveTime44 = New Label()
        Label2 = New Label()
        btnPrint = New Button()
        Tick4 = New Timer(components)
        panelStockIn.SuspendLayout()
        CType(dbStockIn, ComponentModel.ISupportInitialize).BeginInit()
        Panel3.SuspendLayout()
        Panel1.SuspendLayout()
        SuspendLayout()
        ' 
        ' Panel2
        ' 
        Panel2.BackColor = Color.LightSlateGray
        Panel2.Dock = DockStyle.Bottom
        Panel2.Location = New Point(0, 864)
        Panel2.Name = "Panel2"
        Panel2.Size = New Size(1585, 70)
        Panel2.TabIndex = 9
        ' 
        ' panelStockIn
        ' 
        panelStockIn.BackColor = Color.White
        panelStockIn.Controls.Add(dbStockIn)
        panelStockIn.Dock = DockStyle.Fill
        panelStockIn.Location = New Point(0, 164)
        panelStockIn.Name = "panelStockIn"
        panelStockIn.Size = New Size(1585, 700)
        panelStockIn.TabIndex = 10
        ' 
        ' dbStockIn
        ' 
        dbStockIn.AllowUserToAddRows = False
        dbStockIn.AllowUserToDeleteRows = False
        dbStockIn.AllowUserToResizeColumns = False
        dbStockIn.AllowUserToResizeRows = False
        dbStockIn.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
        dbStockIn.BackgroundColor = Color.LightSteelBlue
        dbStockIn.BorderStyle = BorderStyle.None
        dbStockIn.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single
        DataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle1.BackColor = Color.LightSlateGray
        DataGridViewCellStyle1.Font = New Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        DataGridViewCellStyle1.ForeColor = SystemColors.ControlLightLight
        DataGridViewCellStyle1.SelectionBackColor = Color.SlateGray
        DataGridViewCellStyle1.SelectionForeColor = SystemColors.HighlightText
        DataGridViewCellStyle1.WrapMode = DataGridViewTriState.True
        dbStockIn.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        dbStockIn.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = SystemColors.Window
        DataGridViewCellStyle2.Font = New Font("Century Gothic", 9F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        DataGridViewCellStyle2.ForeColor = SystemColors.ControlText
        DataGridViewCellStyle2.SelectionBackColor = Color.LightGray
        DataGridViewCellStyle2.SelectionForeColor = Color.Black
        DataGridViewCellStyle2.WrapMode = DataGridViewTriState.False
        dbStockIn.DefaultCellStyle = DataGridViewCellStyle2
        dbStockIn.Dock = DockStyle.Fill
        dbStockIn.EnableHeadersVisualStyles = False
        dbStockIn.GridColor = Color.Gainsboro
        dbStockIn.Location = New Point(0, 0)
        dbStockIn.MultiSelect = False
        dbStockIn.Name = "dbStockIn"
        dbStockIn.ReadOnly = True
        dbStockIn.RowHeadersVisible = False
        dbStockIn.RowHeadersWidth = 62
        dbStockIn.SelectionMode = DataGridViewSelectionMode.FullRowSelect
        dbStockIn.Size = New Size(1585, 700)
        dbStockIn.TabIndex = 0
        ' 
        ' btnAddStock
        ' 
        btnAddStock.BackColor = Color.DarkSeaGreen
        btnAddStock.FlatAppearance.BorderColor = Color.Silver
        btnAddStock.FlatStyle = FlatStyle.Flat
        btnAddStock.Font = New Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        btnAddStock.ForeColor = SystemColors.ControlLightLight
        btnAddStock.Location = New Point(245, 98)
        btnAddStock.Name = "btnAddStock"
        btnAddStock.Size = New Size(140, 39)
        btnAddStock.TabIndex = 0
        btnAddStock.Text = "ADD STOCK"
        btnAddStock.UseVisualStyleBackColor = False
        ' 
        ' btnEditStock
        ' 
        btnEditStock.BackColor = Color.Teal
        btnEditStock.FlatAppearance.BorderColor = Color.Silver
        btnEditStock.FlatStyle = FlatStyle.Flat
        btnEditStock.Font = New Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        btnEditStock.ForeColor = SystemColors.ControlLightLight
        btnEditStock.Location = New Point(391, 98)
        btnEditStock.Name = "btnEditStock"
        btnEditStock.Size = New Size(140, 39)
        btnEditStock.TabIndex = 0
        btnEditStock.Text = "EDIT STOCK"
        btnEditStock.UseVisualStyleBackColor = False
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
        ' btnHistory
        ' 
        btnHistory.BackColor = Color.SkyBlue
        btnHistory.FlatAppearance.BorderColor = Color.Silver
        btnHistory.FlatStyle = FlatStyle.Flat
        btnHistory.Font = New Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        btnHistory.ForeColor = SystemColors.ControlLightLight
        btnHistory.Location = New Point(537, 98)
        btnHistory.Name = "btnHistory"
        btnHistory.Size = New Size(140, 39)
        btnHistory.TabIndex = 9
        btnHistory.Text = "HISTORY"
        btnHistory.UseVisualStyleBackColor = False
        ' 
        ' Panel3
        ' 
        Panel3.BackColor = SystemColors.Window
        Panel3.Controls.Add(lblClx)
        Panel3.Controls.Add(txtSearchStock)
        Panel3.Location = New Point(843, 83)
        Panel3.Name = "Panel3"
        Panel3.Size = New Size(378, 54)
        Panel3.TabIndex = 10
        ' 
        ' lblClx
        ' 
        lblClx.AutoSize = True
        lblClx.BackColor = SystemColors.Window
        lblClx.Cursor = Cursors.Hand
        lblClx.Font = New Font("Century Gothic", 9F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        lblClx.ForeColor = Color.Gray
        lblClx.Location = New Point(348, 15)
        lblClx.Name = "lblClx"
        lblClx.Size = New Size(20, 22)
        lblClx.TabIndex = 6
        lblClx.Text = "x"
        ' 
        ' txtSearchStock
        ' 
        txtSearchStock.BorderStyle = BorderStyle.None
        txtSearchStock.Location = New Point(12, 16)
        txtSearchStock.Name = "txtSearchStock"
        txtSearchStock.Size = New Size(330, 24)
        txtSearchStock.TabIndex = 3
        ' 
        ' Panel1
        ' 
        Panel1.BackColor = Color.LightSlateGray
        Panel1.Controls.Add(lblActiveDate44)
        Panel1.Controls.Add(lblUsername44)
        Panel1.Controls.Add(lblActiveTime44)
        Panel1.Controls.Add(Label2)
        Panel1.Controls.Add(Panel3)
        Panel1.Controls.Add(btnPrint)
        Panel1.Controls.Add(btnHistory)
        Panel1.Controls.Add(Label1)
        Panel1.Controls.Add(btnEditStock)
        Panel1.Controls.Add(btnAddStock)
        Panel1.Dock = DockStyle.Top
        Panel1.Location = New Point(0, 0)
        Panel1.Name = "Panel1"
        Panel1.Size = New Size(1585, 164)
        Panel1.TabIndex = 8
        ' 
        ' lblActiveDate44
        ' 
        lblActiveDate44.AutoSize = True
        lblActiveDate44.Font = New Font("Century Gothic", 10F)
        lblActiveDate44.ForeColor = SystemColors.ControlLightLight
        lblActiveDate44.Location = New Point(1315, 16)
        lblActiveDate44.Name = "lblActiveDate44"
        lblActiveDate44.Size = New Size(76, 23)
        lblActiveDate44.TabIndex = 12
        lblActiveDate44.Text = "Label1"
        ' 
        ' lblUsername44
        ' 
        lblUsername44.AutoSize = True
        lblUsername44.Font = New Font("Century Gothic", 10F)
        lblUsername44.ForeColor = SystemColors.ControlLightLight
        lblUsername44.Location = New Point(1315, 82)
        lblUsername44.Name = "lblUsername44"
        lblUsername44.Size = New Size(76, 23)
        lblUsername44.TabIndex = 13
        lblUsername44.Text = "Label1"
        ' 
        ' lblActiveTime44
        ' 
        lblActiveTime44.AutoSize = True
        lblActiveTime44.Font = New Font("Century Gothic", 10F)
        lblActiveTime44.ForeColor = SystemColors.ControlLightLight
        lblActiveTime44.Location = New Point(1315, 50)
        lblActiveTime44.Name = "lblActiveTime44"
        lblActiveTime44.Size = New Size(76, 23)
        lblActiveTime44.TabIndex = 14
        lblActiveTime44.Text = "Label1"
        ' 
        ' Label2
        ' 
        Label2.AutoSize = True
        Label2.Font = New Font("Century Gothic", 16F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        Label2.ForeColor = SystemColors.ControlLightLight
        Label2.Location = New Point(25, 114)
        Label2.Name = "Label2"
        Label2.Size = New Size(161, 38)
        Label2.TabIndex = 11
        Label2.Text = "STOCK IN"
        ' 
        ' btnPrint
        ' 
        btnPrint.BackColor = Color.SteelBlue
        btnPrint.FlatAppearance.BorderColor = Color.Silver
        btnPrint.FlatStyle = FlatStyle.Flat
        btnPrint.Font = New Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        btnPrint.ForeColor = SystemColors.ControlLightLight
        btnPrint.Location = New Point(684, 98)
        btnPrint.Name = "btnPrint"
        btnPrint.Size = New Size(140, 39)
        btnPrint.TabIndex = 9
        btnPrint.Text = "PRINT"
        btnPrint.UseVisualStyleBackColor = False
        ' 
        ' Tick4
        ' 
        Tick4.Enabled = True
        Tick4.Interval = 1000
        ' 
        ' StockIn
        ' 
        AutoScaleDimensions = New SizeF(10F, 25F)
        AutoScaleMode = AutoScaleMode.Font
        ClientSize = New Size(1585, 934)
        Controls.Add(panelStockIn)
        Controls.Add(Panel2)
        Controls.Add(Panel1)
        FormBorderStyle = FormBorderStyle.None
        Name = "StockIn"
        Text = "StockIn"
        panelStockIn.ResumeLayout(False)
        CType(dbStockIn, ComponentModel.ISupportInitialize).EndInit()
        Panel3.ResumeLayout(False)
        Panel3.PerformLayout()
        Panel1.ResumeLayout(False)
        Panel1.PerformLayout()
        ResumeLayout(False)
    End Sub
    Friend WithEvents Panel2 As Panel
    Friend WithEvents panelStockIn As Panel
    Friend WithEvents dbStockIn As DataGridView
    Friend WithEvents btnAddStock As Button
    Friend WithEvents btnEditStock As Button
    Friend WithEvents Label1 As Label
    Friend WithEvents btnHistory As Button
    Friend WithEvents Panel3 As Panel
    Friend WithEvents lblClx As Label
    Friend WithEvents txtSearchStock As TextBox
    Friend WithEvents Panel1 As Panel
    Friend WithEvents Label2 As Label
    Friend WithEvents lblActiveDate44 As Label
    Friend WithEvents lblUsername44 As Label
    Friend WithEvents lblActiveTime44 As Label
    Friend WithEvents Tick4 As Timer
    Friend WithEvents btnPrint As Button
End Class
