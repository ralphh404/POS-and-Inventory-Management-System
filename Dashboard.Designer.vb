<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Dashboard
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
        Dim ChartArea1 As System.Windows.Forms.DataVisualization.Charting.ChartArea = New DataVisualization.Charting.ChartArea()
        Dim Legend1 As System.Windows.Forms.DataVisualization.Charting.Legend = New DataVisualization.Charting.Legend()
        Dim Series1 As System.Windows.Forms.DataVisualization.Charting.Series = New DataVisualization.Charting.Series()
        Dim ChartArea2 As System.Windows.Forms.DataVisualization.Charting.ChartArea = New DataVisualization.Charting.ChartArea()
        Dim Legend2 As System.Windows.Forms.DataVisualization.Charting.Legend = New DataVisualization.Charting.Legend()
        Dim Series2 As System.Windows.Forms.DataVisualization.Charting.Series = New DataVisualization.Charting.Series()
        Dim ChartArea3 As System.Windows.Forms.DataVisualization.Charting.ChartArea = New DataVisualization.Charting.ChartArea()
        Dim Legend3 As System.Windows.Forms.DataVisualization.Charting.Legend = New DataVisualization.Charting.Legend()
        Dim Series3 As System.Windows.Forms.DataVisualization.Charting.Series = New DataVisualization.Charting.Series()
        Panel1 = New Panel()
        Label4 = New Label()
        lblActiveDate = New Label()
        lblUsername = New Label()
        lblActiveTime = New Label()
        Panel2 = New Panel()
        TimerDateTime = New Timer(components)
        Panel3 = New Panel()
        Label2 = New Label()
        Panel4 = New Panel()
        PictureBox1 = New PictureBox()
        lblStockTitle = New Label()
        Label1 = New Label()
        lblBox = New Label()
        lblPiece = New Label()
        Panel5 = New Panel()
        Panel6 = New Panel()
        PictureBox2 = New PictureBox()
        lblSalesTitle = New Label()
        lblSalesValue = New Label()
        ChartStock = New DataVisualization.Charting.Chart()
        chartsold = New DataVisualization.Charting.Chart()
        bestsell = New DataVisualization.Charting.Chart()
        panelDashboard = New Panel()
        Panel1.SuspendLayout()
        Panel3.SuspendLayout()
        Panel4.SuspendLayout()
        CType(PictureBox1, ComponentModel.ISupportInitialize).BeginInit()
        Panel5.SuspendLayout()
        Panel6.SuspendLayout()
        CType(PictureBox2, ComponentModel.ISupportInitialize).BeginInit()
        CType(ChartStock, ComponentModel.ISupportInitialize).BeginInit()
        CType(chartsold, ComponentModel.ISupportInitialize).BeginInit()
        CType(bestsell, ComponentModel.ISupportInitialize).BeginInit()
        panelDashboard.SuspendLayout()
        SuspendLayout()
        ' 
        ' Panel1
        ' 
        Panel1.BackColor = Color.LightSlateGray
        Panel1.Controls.Add(Label4)
        Panel1.Controls.Add(lblActiveDate)
        Panel1.Controls.Add(lblUsername)
        Panel1.Controls.Add(lblActiveTime)
        Panel1.Dock = DockStyle.Top
        Panel1.Location = New Point(0, 0)
        Panel1.Name = "Panel1"
        Panel1.Size = New Size(1657, 164)
        Panel1.TabIndex = 2
        ' 
        ' Label4
        ' 
        Label4.AutoSize = True
        Label4.Font = New Font("Century Gothic", 16F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        Label4.ForeColor = Color.White
        Label4.Location = New Point(592, 72)
        Label4.Name = "Label4"
        Label4.Size = New Size(213, 38)
        Label4.TabIndex = 3
        Label4.Text = "DASHBOARD"
        ' 
        ' lblActiveDate
        ' 
        lblActiveDate.AutoSize = True
        lblActiveDate.Font = New Font("Century Gothic", 10F)
        lblActiveDate.ForeColor = SystemColors.ControlLightLight
        lblActiveDate.Location = New Point(1264, 16)
        lblActiveDate.Name = "lblActiveDate"
        lblActiveDate.Size = New Size(76, 23)
        lblActiveDate.TabIndex = 0
        lblActiveDate.Text = "Label1"
        ' 
        ' lblUsername
        ' 
        lblUsername.AutoSize = True
        lblUsername.Font = New Font("Century Gothic", 10F)
        lblUsername.ForeColor = SystemColors.ControlLightLight
        lblUsername.Location = New Point(1264, 84)
        lblUsername.Name = "lblUsername"
        lblUsername.Size = New Size(76, 23)
        lblUsername.TabIndex = 0
        lblUsername.Text = "Label1"
        ' 
        ' lblActiveTime
        ' 
        lblActiveTime.AutoSize = True
        lblActiveTime.Font = New Font("Century Gothic", 10F)
        lblActiveTime.ForeColor = SystemColors.ControlLightLight
        lblActiveTime.Location = New Point(1264, 49)
        lblActiveTime.Name = "lblActiveTime"
        lblActiveTime.Size = New Size(76, 23)
        lblActiveTime.TabIndex = 0
        lblActiveTime.Text = "Label1"
        ' 
        ' Panel2
        ' 
        Panel2.BackColor = Color.LightSlateGray
        Panel2.Dock = DockStyle.Bottom
        Panel2.Location = New Point(0, 1036)
        Panel2.Name = "Panel2"
        Panel2.Size = New Size(1657, 70)
        Panel2.TabIndex = 4
        ' 
        ' TimerDateTime
        ' 
        TimerDateTime.Enabled = True
        TimerDateTime.Interval = 1000
        ' 
        ' Panel3
        ' 
        Panel3.BackColor = Color.PowderBlue
        Panel3.Controls.Add(Label2)
        Panel3.Controls.Add(Panel4)
        Panel3.Controls.Add(Label1)
        Panel3.Controls.Add(lblBox)
        Panel3.Controls.Add(lblPiece)
        Panel3.Location = New Point(31, 601)
        Panel3.Name = "Panel3"
        Panel3.Size = New Size(462, 192)
        Panel3.TabIndex = 3
        ' 
        ' Label2
        ' 
        Label2.AutoSize = True
        Label2.FlatStyle = FlatStyle.Flat
        Label2.Font = New Font("Century Gothic", 12F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        Label2.ForeColor = Color.GhostWhite
        Label2.Location = New Point(16, 107)
        Label2.Name = "Label2"
        Label2.Size = New Size(105, 28)
        Label2.TabIndex = 1
        Label2.Text = "Box(es):"
        ' 
        ' Panel4
        ' 
        Panel4.BackColor = Color.CadetBlue
        Panel4.Controls.Add(PictureBox1)
        Panel4.Controls.Add(lblStockTitle)
        Panel4.Location = New Point(16, 13)
        Panel4.Name = "Panel4"
        Panel4.Size = New Size(430, 73)
        Panel4.TabIndex = 3
        ' 
        ' PictureBox1
        ' 
        PictureBox1.Image = My.Resources.Resources.packages
        PictureBox1.Location = New Point(22, 12)
        PictureBox1.Name = "PictureBox1"
        PictureBox1.Size = New Size(50, 50)
        PictureBox1.SizeMode = PictureBoxSizeMode.StretchImage
        PictureBox1.TabIndex = 2
        PictureBox1.TabStop = False
        ' 
        ' lblStockTitle
        ' 
        lblStockTitle.AutoSize = True
        lblStockTitle.Font = New Font("Century Gothic", 14F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        lblStockTitle.ForeColor = Color.GhostWhite
        lblStockTitle.Location = New Point(78, 19)
        lblStockTitle.Name = "lblStockTitle"
        lblStockTitle.Size = New Size(161, 34)
        lblStockTitle.TabIndex = 0
        lblStockTitle.Text = "Total Stock"
        ' 
        ' Label1
        ' 
        Label1.AutoSize = True
        Label1.FlatStyle = FlatStyle.Flat
        Label1.Font = New Font("Century Gothic", 12F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        Label1.ForeColor = Color.GhostWhite
        Label1.Location = New Point(16, 135)
        Label1.Name = "Label1"
        Label1.Size = New Size(112, 28)
        Label1.TabIndex = 1
        Label1.Text = "Piece(s):"
        ' 
        ' lblBox
        ' 
        lblBox.AutoSize = True
        lblBox.FlatStyle = FlatStyle.Flat
        lblBox.Font = New Font("Century Gothic", 12F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        lblBox.ForeColor = Color.DimGray
        lblBox.Location = New Point(127, 103)
        lblBox.Name = "lblBox"
        lblBox.Size = New Size(91, 30)
        lblBox.TabIndex = 1
        lblBox.Text = "Label5"
        ' 
        ' lblPiece
        ' 
        lblPiece.AutoSize = True
        lblPiece.FlatStyle = FlatStyle.Flat
        lblPiece.Font = New Font("Century Gothic", 12F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        lblPiece.ForeColor = Color.DimGray
        lblPiece.Location = New Point(127, 133)
        lblPiece.Name = "lblPiece"
        lblPiece.Size = New Size(91, 30)
        lblPiece.TabIndex = 1
        lblPiece.Text = "Label5"
        ' 
        ' Panel5
        ' 
        Panel5.BackColor = Color.SteelBlue
        Panel5.Controls.Add(Panel6)
        Panel5.Controls.Add(lblSalesValue)
        Panel5.Location = New Point(576, 601)
        Panel5.Name = "Panel5"
        Panel5.Size = New Size(462, 192)
        Panel5.TabIndex = 3
        ' 
        ' Panel6
        ' 
        Panel6.BackColor = Color.LightSlateGray
        Panel6.Controls.Add(PictureBox2)
        Panel6.Controls.Add(lblSalesTitle)
        Panel6.Location = New Point(16, 13)
        Panel6.Name = "Panel6"
        Panel6.Size = New Size(430, 73)
        Panel6.TabIndex = 3
        ' 
        ' PictureBox2
        ' 
        PictureBox2.Image = My.Resources.Resources.sale_bag
        PictureBox2.Location = New Point(22, 12)
        PictureBox2.Name = "PictureBox2"
        PictureBox2.Size = New Size(50, 50)
        PictureBox2.SizeMode = PictureBoxSizeMode.StretchImage
        PictureBox2.TabIndex = 2
        PictureBox2.TabStop = False
        ' 
        ' lblSalesTitle
        ' 
        lblSalesTitle.AutoSize = True
        lblSalesTitle.Font = New Font("Century Gothic", 14F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        lblSalesTitle.ForeColor = Color.GhostWhite
        lblSalesTitle.Location = New Point(78, 19)
        lblSalesTitle.Name = "lblSalesTitle"
        lblSalesTitle.Size = New Size(156, 34)
        lblSalesTitle.TabIndex = 0
        lblSalesTitle.Text = "Total Sales"
        ' 
        ' lblSalesValue
        ' 
        lblSalesValue.AutoSize = True
        lblSalesValue.FlatStyle = FlatStyle.Flat
        lblSalesValue.Font = New Font("Century Gothic", 20F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        lblSalesValue.ForeColor = Color.GhostWhite
        lblSalesValue.Location = New Point(133, 108)
        lblSalesValue.Name = "lblSalesValue"
        lblSalesValue.Size = New Size(151, 49)
        lblSalesValue.TabIndex = 1
        lblSalesValue.Text = "Label5"
        ' 
        ' ChartStock
        ' 
        ChartStock.BackColor = Color.Gainsboro
        ChartStock.BackSecondaryColor = Color.WhiteSmoke
        ChartStock.BorderlineColor = Color.WhiteSmoke
        ChartArea1.Name = "ChartArea1"
        ChartStock.ChartAreas.Add(ChartArea1)
        Legend1.Name = "Legend1"
        ChartStock.Legends.Add(Legend1)
        ChartStock.Location = New Point(1129, 601)
        ChartStock.Name = "ChartStock"
        Series1.ChartArea = "ChartArea1"
        Series1.Legend = "Legend1"
        Series1.Name = "Series1"
        ChartStock.Series.Add(Series1)
        ChartStock.Size = New Size(462, 192)
        ChartStock.TabIndex = 4
        ChartStock.Text = "Chart1"
        ' 
        ' chartsold
        ' 
        ChartArea2.Name = "ChartArea1"
        chartsold.ChartAreas.Add(ChartArea2)
        Legend2.Name = "Legend1"
        chartsold.Legends.Add(Legend2)
        chartsold.Location = New Point(31, 28)
        chartsold.Name = "chartsold"
        Series2.ChartArea = "ChartArea1"
        Series2.Legend = "Legend1"
        Series2.Name = "Series1"
        chartsold.Series.Add(Series2)
        chartsold.Size = New Size(760, 520)
        chartsold.TabIndex = 5
        chartsold.Text = "Chart1"
        ' 
        ' bestsell
        ' 
        ChartArea3.Name = "ChartArea1"
        bestsell.ChartAreas.Add(ChartArea3)
        Legend3.Name = "Legend1"
        bestsell.Legends.Add(Legend3)
        bestsell.Location = New Point(831, 28)
        bestsell.Name = "bestsell"
        Series3.ChartArea = "ChartArea1"
        Series3.Legend = "Legend1"
        Series3.Name = "Series1"
        bestsell.Series.Add(Series3)
        bestsell.Size = New Size(760, 520)
        bestsell.TabIndex = 5
        bestsell.Text = "Chart1"
        ' 
        ' panelDashboard
        ' 
        panelDashboard.BackColor = Color.LightSteelBlue
        panelDashboard.Controls.Add(bestsell)
        panelDashboard.Controls.Add(chartsold)
        panelDashboard.Controls.Add(ChartStock)
        panelDashboard.Controls.Add(Panel5)
        panelDashboard.Controls.Add(Panel3)
        panelDashboard.Dock = DockStyle.Fill
        panelDashboard.Location = New Point(0, 164)
        panelDashboard.Name = "panelDashboard"
        panelDashboard.Size = New Size(1657, 872)
        panelDashboard.TabIndex = 5
        ' 
        ' Dashboard
        ' 
        AutoScaleDimensions = New SizeF(10F, 25F)
        AutoScaleMode = AutoScaleMode.Font
        ClientSize = New Size(1657, 1106)
        Controls.Add(panelDashboard)
        Controls.Add(Panel2)
        Controls.Add(Panel1)
        FormBorderStyle = FormBorderStyle.None
        Name = "Dashboard"
        StartPosition = FormStartPosition.CenterScreen
        WindowState = FormWindowState.Maximized
        Panel1.ResumeLayout(False)
        Panel1.PerformLayout()
        Panel3.ResumeLayout(False)
        Panel3.PerformLayout()
        Panel4.ResumeLayout(False)
        Panel4.PerformLayout()
        CType(PictureBox1, ComponentModel.ISupportInitialize).EndInit()
        Panel5.ResumeLayout(False)
        Panel5.PerformLayout()
        Panel6.ResumeLayout(False)
        Panel6.PerformLayout()
        CType(PictureBox2, ComponentModel.ISupportInitialize).EndInit()
        CType(ChartStock, ComponentModel.ISupportInitialize).EndInit()
        CType(chartsold, ComponentModel.ISupportInitialize).EndInit()
        CType(bestsell, ComponentModel.ISupportInitialize).EndInit()
        panelDashboard.ResumeLayout(False)
        ResumeLayout(False)
    End Sub

    Friend WithEvents Panel1 As Panel
    Friend WithEvents Panel2 As Panel
    Friend WithEvents lblActiveTime As Label
    Friend WithEvents lblActiveDate As Label
    Friend WithEvents TimerDateTime As Timer
    Friend WithEvents lblUsername As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents Panel3 As Panel
    Friend WithEvents Label2 As Label
    Friend WithEvents Panel4 As Panel
    Friend WithEvents PictureBox1 As PictureBox
    Friend WithEvents lblStockTitle As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents lblBox As Label
    Friend WithEvents lblPiece As Label
    Friend WithEvents Panel5 As Panel
    Friend WithEvents Panel6 As Panel
    Friend WithEvents PictureBox2 As PictureBox
    Friend WithEvents lblSalesTitle As Label
    Friend WithEvents lblSalesValue As Label
    Friend WithEvents ChartStock As DataVisualization.Charting.Chart
    Friend WithEvents chartsold As DataVisualization.Charting.Chart
    Friend WithEvents bestsell As DataVisualization.Charting.Chart
    Friend WithEvents panelDashboard As Panel
End Class
