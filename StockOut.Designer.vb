<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class StockOut
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
        Dim DataGridViewCellStyle4 As DataGridViewCellStyle = New DataGridViewCellStyle()
        Dim DataGridViewCellStyle5 As DataGridViewCellStyle = New DataGridViewCellStyle()
        Dim DataGridViewCellStyle6 As DataGridViewCellStyle = New DataGridViewCellStyle()
        Panel1 = New Panel()
        Label2 = New Label()
        Label1 = New Label()
        Panel2 = New Panel()
        dbStockOut = New DataGridView()
        Tick5 = New Timer(components)
        lblActiveDate55 = New Label()
        lblUsername55 = New Label()
        lblActiveTime55 = New Label()
        Panel1.SuspendLayout()
        CType(dbStockOut, ComponentModel.ISupportInitialize).BeginInit()
        SuspendLayout()
        ' 
        ' Panel1
        ' 
        Panel1.BackColor = Color.LightSlateGray
        Panel1.Controls.Add(lblActiveDate55)
        Panel1.Controls.Add(lblUsername55)
        Panel1.Controls.Add(lblActiveTime55)
        Panel1.Controls.Add(Label2)
        Panel1.Controls.Add(Label1)
        Panel1.Dock = DockStyle.Top
        Panel1.Location = New Point(0, 0)
        Panel1.Name = "Panel1"
        Panel1.Size = New Size(1509, 164)
        Panel1.TabIndex = 9
        ' 
        ' Label2
        ' 
        Label2.AutoSize = True
        Label2.Font = New Font("Century Gothic", 16F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        Label2.ForeColor = SystemColors.ControlLightLight
        Label2.Location = New Point(25, 114)
        Label2.Name = "Label2"
        Label2.Size = New Size(188, 38)
        Label2.TabIndex = 9
        Label2.Text = "STOCK OUT"
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
        ' Panel2
        ' 
        Panel2.BackColor = Color.LightSlateGray
        Panel2.Dock = DockStyle.Bottom
        Panel2.Location = New Point(0, 864)
        Panel2.Name = "Panel2"
        Panel2.Size = New Size(1509, 70)
        Panel2.TabIndex = 10
        ' 
        ' dbStockOut
        ' 
        dbStockOut.AllowUserToAddRows = False
        dbStockOut.AllowUserToDeleteRows = False
        dbStockOut.AllowUserToResizeColumns = False
        dbStockOut.AllowUserToResizeRows = False
        DataGridViewCellStyle4.BackColor = Color.WhiteSmoke
        dbStockOut.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle4
        dbStockOut.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
        dbStockOut.BackgroundColor = Color.LightSteelBlue
        dbStockOut.BorderStyle = BorderStyle.None
        dbStockOut.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal
        dbStockOut.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single
        DataGridViewCellStyle5.Alignment = DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle5.BackColor = Color.LightSlateGray
        DataGridViewCellStyle5.Font = New Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        DataGridViewCellStyle5.ForeColor = SystemColors.ControlLightLight
        DataGridViewCellStyle5.SelectionBackColor = Color.SlateGray
        DataGridViewCellStyle5.SelectionForeColor = SystemColors.HighlightText
        DataGridViewCellStyle5.WrapMode = DataGridViewTriState.True
        dbStockOut.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle5
        dbStockOut.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DataGridViewCellStyle6.Alignment = DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle6.BackColor = SystemColors.Window
        DataGridViewCellStyle6.Font = New Font("Century Gothic", 9F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        DataGridViewCellStyle6.ForeColor = SystemColors.ControlText
        DataGridViewCellStyle6.SelectionBackColor = Color.LightGray
        DataGridViewCellStyle6.SelectionForeColor = Color.Black
        DataGridViewCellStyle6.WrapMode = DataGridViewTriState.False
        dbStockOut.DefaultCellStyle = DataGridViewCellStyle6
        dbStockOut.Dock = DockStyle.Fill
        dbStockOut.EnableHeadersVisualStyles = False
        dbStockOut.GridColor = Color.Gainsboro
        dbStockOut.Location = New Point(0, 164)
        dbStockOut.MultiSelect = False
        dbStockOut.Name = "dbStockOut"
        dbStockOut.ReadOnly = True
        dbStockOut.RowHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single
        dbStockOut.RowHeadersVisible = False
        dbStockOut.RowHeadersWidth = 62
        dbStockOut.SelectionMode = DataGridViewSelectionMode.FullRowSelect
        dbStockOut.Size = New Size(1509, 700)
        dbStockOut.TabIndex = 11
        ' 
        ' Tick5
        ' 
        Tick5.Enabled = True
        Tick5.Interval = 1000
        ' 
        ' lblActiveDate55
        ' 
        lblActiveDate55.AutoSize = True
        lblActiveDate55.Font = New Font("Century Gothic", 10F)
        lblActiveDate55.ForeColor = SystemColors.ControlLightLight
        lblActiveDate55.Location = New Point(1315, 16)
        lblActiveDate55.Name = "lblActiveDate55"
        lblActiveDate55.Size = New Size(76, 23)
        lblActiveDate55.TabIndex = 12
        lblActiveDate55.Text = "Label1"
        ' 
        ' lblUsername55
        ' 
        lblUsername55.AutoSize = True
        lblUsername55.Font = New Font("Century Gothic", 10F)
        lblUsername55.ForeColor = SystemColors.ControlLightLight
        lblUsername55.Location = New Point(1315, 82)
        lblUsername55.Name = "lblUsername55"
        lblUsername55.Size = New Size(76, 23)
        lblUsername55.TabIndex = 13
        lblUsername55.Text = "Label1"
        ' 
        ' lblActiveTime55
        ' 
        lblActiveTime55.AutoSize = True
        lblActiveTime55.Font = New Font("Century Gothic", 10F)
        lblActiveTime55.ForeColor = SystemColors.ControlLightLight
        lblActiveTime55.Location = New Point(1315, 50)
        lblActiveTime55.Name = "lblActiveTime55"
        lblActiveTime55.Size = New Size(76, 23)
        lblActiveTime55.TabIndex = 14
        lblActiveTime55.Text = "Label1"
        ' 
        ' StockOut
        ' 
        AutoScaleDimensions = New SizeF(10F, 25F)
        AutoScaleMode = AutoScaleMode.Font
        ClientSize = New Size(1509, 934)
        Controls.Add(dbStockOut)
        Controls.Add(Panel2)
        Controls.Add(Panel1)
        FormBorderStyle = FormBorderStyle.None
        Name = "StockOut"
        Text = "StockOut"
        Panel1.ResumeLayout(False)
        Panel1.PerformLayout()
        CType(dbStockOut, ComponentModel.ISupportInitialize).EndInit()
        ResumeLayout(False)
    End Sub

    Friend WithEvents Panel1 As Panel
    Friend WithEvents Label1 As Label
    Friend WithEvents Panel2 As Panel
    Friend WithEvents dbStockOut As DataGridView
    Friend WithEvents Label2 As Label
    Friend WithEvents Tick5 As Timer
    Friend WithEvents lblActiveDate55 As Label
    Friend WithEvents lblUsername55 As Label
    Friend WithEvents lblActiveTime55 As Label
End Class
