<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmLogs
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
        panelLogs = New Panel()
        dbLogs = New DataGridView()
        Panel1 = New Panel()
        lblActiveDate4 = New Label()
        lblUsername4 = New Label()
        lblActiveTime4 = New Label()
        Panel2 = New Panel()
        TimerDateTime4 = New Timer(components)
        Label4 = New Label()
        panelLogs.SuspendLayout()
        CType(dbLogs, ComponentModel.ISupportInitialize).BeginInit()
        Panel1.SuspendLayout()
        SuspendLayout()
        ' 
        ' panelLogs
        ' 
        panelLogs.BackColor = Color.White
        panelLogs.Controls.Add(dbLogs)
        panelLogs.Controls.Add(Panel1)
        panelLogs.Controls.Add(Panel2)
        panelLogs.Dock = DockStyle.Fill
        panelLogs.Font = New Font("Segoe UI", 72F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        panelLogs.Location = New Point(0, 0)
        panelLogs.Name = "panelLogs"
        panelLogs.Size = New Size(1378, 934)
        panelLogs.TabIndex = 0
        ' 
        ' dbLogs
        ' 
        dbLogs.AllowUserToAddRows = False
        dbLogs.AllowUserToDeleteRows = False
        dbLogs.AllowUserToResizeColumns = False
        dbLogs.AllowUserToResizeRows = False
        DataGridViewCellStyle1.BackColor = Color.WhiteSmoke
        dbLogs.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
        dbLogs.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
        dbLogs.BackgroundColor = Color.LightSteelBlue
        dbLogs.BorderStyle = BorderStyle.None
        dbLogs.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal
        dbLogs.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single
        DataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle2.BackColor = Color.LightSlateGray
        DataGridViewCellStyle2.Font = New Font("Segoe UI", 10F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        DataGridViewCellStyle2.ForeColor = SystemColors.ControlLightLight
        DataGridViewCellStyle2.SelectionBackColor = Color.SlateGray
        DataGridViewCellStyle2.SelectionForeColor = SystemColors.ControlLightLight
        DataGridViewCellStyle2.WrapMode = DataGridViewTriState.True
        dbLogs.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle2
        dbLogs.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DataGridViewCellStyle3.Alignment = DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle3.BackColor = SystemColors.Window
        DataGridViewCellStyle3.Font = New Font("Century Gothic", 8F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        DataGridViewCellStyle3.ForeColor = SystemColors.ControlText
        DataGridViewCellStyle3.SelectionBackColor = Color.LightGray
        DataGridViewCellStyle3.SelectionForeColor = Color.Black
        DataGridViewCellStyle3.WrapMode = DataGridViewTriState.False
        dbLogs.DefaultCellStyle = DataGridViewCellStyle3
        dbLogs.Dock = DockStyle.Fill
        dbLogs.EnableHeadersVisualStyles = False
        dbLogs.GridColor = Color.Gainsboro
        dbLogs.Location = New Point(0, 164)
        dbLogs.MultiSelect = False
        dbLogs.Name = "dbLogs"
        dbLogs.ReadOnly = True
        DataGridViewCellStyle4.Alignment = DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle4.BackColor = SystemColors.Control
        DataGridViewCellStyle4.Font = New Font("Segoe UI", 72F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        DataGridViewCellStyle4.ForeColor = SystemColors.WindowText
        DataGridViewCellStyle4.SelectionBackColor = SystemColors.Highlight
        DataGridViewCellStyle4.SelectionForeColor = SystemColors.HighlightText
        DataGridViewCellStyle4.WrapMode = DataGridViewTriState.True
        dbLogs.RowHeadersDefaultCellStyle = DataGridViewCellStyle4
        dbLogs.RowHeadersVisible = False
        dbLogs.RowHeadersWidth = 62
        dbLogs.ScrollBars = ScrollBars.Vertical
        dbLogs.SelectionMode = DataGridViewSelectionMode.FullRowSelect
        dbLogs.Size = New Size(1378, 700)
        dbLogs.TabIndex = 7
        ' 
        ' Panel1
        ' 
        Panel1.BackColor = Color.LightSlateGray
        Panel1.Controls.Add(Label4)
        Panel1.Controls.Add(lblActiveDate4)
        Panel1.Controls.Add(lblUsername4)
        Panel1.Controls.Add(lblActiveTime4)
        Panel1.Dock = DockStyle.Top
        Panel1.Location = New Point(0, 0)
        Panel1.Name = "Panel1"
        Panel1.Size = New Size(1378, 164)
        Panel1.TabIndex = 6
        ' 
        ' lblActiveDate4
        ' 
        lblActiveDate4.AutoSize = True
        lblActiveDate4.Font = New Font("Century Gothic", 10F)
        lblActiveDate4.ForeColor = SystemColors.ControlLightLight
        lblActiveDate4.Location = New Point(1264, 16)
        lblActiveDate4.Name = "lblActiveDate4"
        lblActiveDate4.Size = New Size(76, 23)
        lblActiveDate4.TabIndex = 12
        lblActiveDate4.Text = "Label1"
        ' 
        ' lblUsername4
        ' 
        lblUsername4.AutoSize = True
        lblUsername4.Font = New Font("Century Gothic", 10F)
        lblUsername4.ForeColor = SystemColors.ControlLightLight
        lblUsername4.Location = New Point(1264, 84)
        lblUsername4.Name = "lblUsername4"
        lblUsername4.Size = New Size(76, 23)
        lblUsername4.TabIndex = 13
        lblUsername4.Text = "Label1"
        ' 
        ' lblActiveTime4
        ' 
        lblActiveTime4.AutoSize = True
        lblActiveTime4.Font = New Font("Century Gothic", 10F)
        lblActiveTime4.ForeColor = SystemColors.ControlLightLight
        lblActiveTime4.Location = New Point(1264, 49)
        lblActiveTime4.Name = "lblActiveTime4"
        lblActiveTime4.Size = New Size(76, 23)
        lblActiveTime4.TabIndex = 14
        lblActiveTime4.Text = "Label1"
        ' 
        ' Panel2
        ' 
        Panel2.BackColor = Color.LightSlateGray
        Panel2.Dock = DockStyle.Bottom
        Panel2.Location = New Point(0, 864)
        Panel2.Name = "Panel2"
        Panel2.Size = New Size(1378, 70)
        Panel2.TabIndex = 4
        ' 
        ' TimerDateTime4
        ' 
        TimerDateTime4.Enabled = True
        TimerDateTime4.Interval = 1000
        ' 
        ' Label4
        ' 
        Label4.AutoSize = True
        Label4.Font = New Font("Century Gothic", 16F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        Label4.ForeColor = Color.White
        Label4.Location = New Point(592, 20)
        Label4.Name = "Label4"
        Label4.Size = New Size(102, 38)
        Label4.TabIndex = 15
        Label4.Text = "LOGS"
        ' 
        ' frmLogs
        ' 
        AutoScaleDimensions = New SizeF(10F, 25F)
        AutoScaleMode = AutoScaleMode.Font
        ClientSize = New Size(1378, 934)
        Controls.Add(panelLogs)
        FormBorderStyle = FormBorderStyle.None
        Name = "frmLogs"
        Text = "Logs"
        panelLogs.ResumeLayout(False)
        CType(dbLogs, ComponentModel.ISupportInitialize).EndInit()
        Panel1.ResumeLayout(False)
        Panel1.PerformLayout()
        ResumeLayout(False)
    End Sub

    Friend WithEvents panelLogs As Panel
    Friend WithEvents Panel2 As Panel
    Friend WithEvents Panel1 As Panel
    Friend WithEvents dbLogs As DataGridView
    Friend WithEvents lblActiveDate4 As Label
    Friend WithEvents lblUsername4 As Label
    Friend WithEvents lblActiveTime4 As Label
    Friend WithEvents TimerDateTime4 As Timer
    Friend WithEvents Label4 As Label
End Class
