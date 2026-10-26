<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class StockAlert
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
        Dim DataGridViewCellStyle5 As DataGridViewCellStyle = New DataGridViewCellStyle()
        Dim DataGridViewCellStyle6 As DataGridViewCellStyle = New DataGridViewCellStyle()
        Panel1 = New Panel()
        Label2 = New Label()
        Panel2 = New Panel()
        btnClose = New Button()
        panelAlert = New Panel()
        Label1 = New Label()
        dbLow = New DataGridView()
        dbOut = New DataGridView()
        Notif = New Timer(components)
        Panel1.SuspendLayout()
        Panel2.SuspendLayout()
        panelAlert.SuspendLayout()
        CType(dbLow, ComponentModel.ISupportInitialize).BeginInit()
        CType(dbOut, ComponentModel.ISupportInitialize).BeginInit()
        SuspendLayout()
        ' 
        ' Panel1
        ' 
        Panel1.BackColor = Color.DarkRed
        Panel1.Controls.Add(Label2)
        Panel1.Dock = DockStyle.Top
        Panel1.Location = New Point(0, 0)
        Panel1.Name = "Panel1"
        Panel1.Size = New Size(900, 70)
        Panel1.TabIndex = 0
        ' 
        ' Label2
        ' 
        Label2.AutoSize = True
        Label2.Font = New Font("Century Gothic", 14F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        Label2.ForeColor = SystemColors.HighlightText
        Label2.Location = New Point(12, 19)
        Label2.Name = "Label2"
        Label2.Size = New Size(212, 34)
        Label2.TabIndex = 2
        Label2.Text = "OUT OF STOCK"
        ' 
        ' Panel2
        ' 
        Panel2.BackColor = Color.WhiteSmoke
        Panel2.Controls.Add(btnClose)
        Panel2.Dock = DockStyle.Bottom
        Panel2.Location = New Point(0, 830)
        Panel2.Name = "Panel2"
        Panel2.Size = New Size(900, 70)
        Panel2.TabIndex = 1
        ' 
        ' btnClose
        ' 
        btnClose.BackColor = Color.Firebrick
        btnClose.FlatAppearance.BorderColor = Color.Silver
        btnClose.FlatStyle = FlatStyle.Flat
        btnClose.Font = New Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        btnClose.ForeColor = SystemColors.HighlightText
        btnClose.Location = New Point(738, 16)
        btnClose.Name = "btnClose"
        btnClose.Size = New Size(117, 40)
        btnClose.TabIndex = 1
        btnClose.Text = "Close"
        btnClose.UseVisualStyleBackColor = False
        ' 
        ' panelAlert
        ' 
        panelAlert.BackColor = Color.Gold
        panelAlert.Controls.Add(Label1)
        panelAlert.Controls.Add(dbLow)
        panelAlert.Controls.Add(dbOut)
        panelAlert.Dock = DockStyle.Fill
        panelAlert.Location = New Point(0, 70)
        panelAlert.Name = "panelAlert"
        panelAlert.Size = New Size(900, 760)
        panelAlert.TabIndex = 2
        ' 
        ' Label1
        ' 
        Label1.AutoSize = True
        Label1.Font = New Font("Century Gothic", 14F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        Label1.ForeColor = SystemColors.HighlightText
        Label1.Location = New Point(12, 364)
        Label1.Name = "Label1"
        Label1.Size = New Size(174, 34)
        Label1.TabIndex = 2
        Label1.Text = "LOW STOCK"
        ' 
        ' dbLow
        ' 
        dbLow.AllowUserToAddRows = False
        dbLow.AllowUserToDeleteRows = False
        dbLow.AllowUserToResizeColumns = False
        dbLow.AllowUserToResizeRows = False
        DataGridViewCellStyle1.BackColor = Color.WhiteSmoke
        dbLow.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
        dbLow.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
        dbLow.BackgroundColor = Color.White
        dbLow.BorderStyle = BorderStyle.None
        dbLow.CellBorderStyle = DataGridViewCellBorderStyle.None
        dbLow.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single
        DataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle2.BackColor = Color.LightSlateGray
        DataGridViewCellStyle2.Font = New Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        DataGridViewCellStyle2.ForeColor = SystemColors.HighlightText
        DataGridViewCellStyle2.SelectionBackColor = Color.SlateGray
        DataGridViewCellStyle2.SelectionForeColor = SystemColors.HighlightText
        DataGridViewCellStyle2.WrapMode = DataGridViewTriState.True
        dbLow.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle2
        dbLow.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DataGridViewCellStyle3.Alignment = DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle3.BackColor = SystemColors.Window
        DataGridViewCellStyle3.Font = New Font("Century Gothic", 9F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        DataGridViewCellStyle3.ForeColor = SystemColors.ControlText
        DataGridViewCellStyle3.SelectionBackColor = Color.LightGray
        DataGridViewCellStyle3.SelectionForeColor = SystemColors.Desktop
        DataGridViewCellStyle3.WrapMode = DataGridViewTriState.False
        dbLow.DefaultCellStyle = DataGridViewCellStyle3
        dbLow.EnableHeadersVisualStyles = False
        dbLow.GridColor = Color.Gainsboro
        dbLow.Location = New Point(0, 415)
        dbLow.MultiSelect = False
        dbLow.Name = "dbLow"
        dbLow.ReadOnly = True
        dbLow.RowHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single
        dbLow.RowHeadersVisible = False
        dbLow.RowHeadersWidth = 62
        dbLow.SelectionMode = DataGridViewSelectionMode.FullRowSelect
        dbLow.Size = New Size(900, 345)
        dbLow.TabIndex = 1
        ' 
        ' dbOut
        ' 
        dbOut.AllowUserToAddRows = False
        dbOut.AllowUserToDeleteRows = False
        dbOut.AllowUserToResizeColumns = False
        dbOut.AllowUserToResizeRows = False
        DataGridViewCellStyle4.BackColor = Color.WhiteSmoke
        dbOut.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle4
        dbOut.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
        dbOut.BackgroundColor = Color.White
        dbOut.BorderStyle = BorderStyle.None
        dbOut.CellBorderStyle = DataGridViewCellBorderStyle.None
        dbOut.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single
        DataGridViewCellStyle5.Alignment = DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle5.BackColor = Color.LightSlateGray
        DataGridViewCellStyle5.Font = New Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        DataGridViewCellStyle5.ForeColor = SystemColors.HighlightText
        DataGridViewCellStyle5.SelectionBackColor = Color.SlateGray
        DataGridViewCellStyle5.SelectionForeColor = SystemColors.HighlightText
        DataGridViewCellStyle5.WrapMode = DataGridViewTriState.True
        dbOut.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle5
        dbOut.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DataGridViewCellStyle6.Alignment = DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle6.BackColor = Color.WhiteSmoke
        DataGridViewCellStyle6.Font = New Font("Century Gothic", 9F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        DataGridViewCellStyle6.ForeColor = SystemColors.ControlText
        DataGridViewCellStyle6.SelectionBackColor = Color.LightGray
        DataGridViewCellStyle6.SelectionForeColor = Color.Black
        DataGridViewCellStyle6.WrapMode = DataGridViewTriState.False
        dbOut.DefaultCellStyle = DataGridViewCellStyle6
        dbOut.Dock = DockStyle.Top
        dbOut.EnableHeadersVisualStyles = False
        dbOut.GridColor = Color.Gainsboro
        dbOut.Location = New Point(0, 0)
        dbOut.MultiSelect = False
        dbOut.Name = "dbOut"
        dbOut.ReadOnly = True
        dbOut.RowHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single
        dbOut.RowHeadersVisible = False
        dbOut.RowHeadersWidth = 62
        dbOut.SelectionMode = DataGridViewSelectionMode.FullRowSelect
        dbOut.Size = New Size(900, 345)
        dbOut.TabIndex = 0
        ' 
        ' Notif
        ' 
        Notif.Interval = 20
        ' 
        ' StockAlert
        ' 
        AutoScaleDimensions = New SizeF(10F, 25F)
        AutoScaleMode = AutoScaleMode.Font
        BackColor = Color.LightGray
        ClientSize = New Size(900, 900)
        ControlBox = False
        Controls.Add(panelAlert)
        Controls.Add(Panel2)
        Controls.Add(Panel1)
        FormBorderStyle = FormBorderStyle.FixedSingle
        MaximizeBox = False
        MinimizeBox = False
        Name = "StockAlert"
        StartPosition = FormStartPosition.CenterScreen
        Panel1.ResumeLayout(False)
        Panel1.PerformLayout()
        Panel2.ResumeLayout(False)
        panelAlert.ResumeLayout(False)
        panelAlert.PerformLayout()
        CType(dbLow, ComponentModel.ISupportInitialize).EndInit()
        CType(dbOut, ComponentModel.ISupportInitialize).EndInit()
        ResumeLayout(False)
    End Sub

    Friend WithEvents Panel1 As Panel
    Friend WithEvents Panel2 As Panel
    Friend WithEvents panelAlert As Panel
    Friend WithEvents dbLow As DataGridView
    Friend WithEvents dbOut As DataGridView
    Friend WithEvents btnClose As Button
    Friend WithEvents Label1 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents Notif As Timer
End Class
