<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class IntArch
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
        lblActiveDate3 = New Label()
        lblUsername3 = New Label()
        lblActiveTime3 = New Label()
        btnRestore = New Button()
        Panel2 = New Panel()
        panelArch = New Panel()
        dbArch = New DataGridView()
        TimerDateTime3 = New Timer(components)
        Label4 = New Label()
        Panel1.SuspendLayout()
        panelArch.SuspendLayout()
        CType(dbArch, ComponentModel.ISupportInitialize).BeginInit()
        SuspendLayout()
        ' 
        ' Panel1
        ' 
        Panel1.BackColor = Color.LightSlateGray
        Panel1.Controls.Add(Label4)
        Panel1.Controls.Add(lblActiveDate3)
        Panel1.Controls.Add(lblUsername3)
        Panel1.Controls.Add(lblActiveTime3)
        Panel1.Controls.Add(btnRestore)
        Panel1.Dock = DockStyle.Top
        Panel1.Location = New Point(0, 0)
        Panel1.Name = "Panel1"
        Panel1.Size = New Size(1378, 164)
        Panel1.TabIndex = 7
        ' 
        ' lblActiveDate3
        ' 
        lblActiveDate3.AutoSize = True
        lblActiveDate3.Font = New Font("Century Gothic", 10F)
        lblActiveDate3.ForeColor = SystemColors.ControlLightLight
        lblActiveDate3.Location = New Point(1264, 16)
        lblActiveDate3.Name = "lblActiveDate3"
        lblActiveDate3.Size = New Size(76, 23)
        lblActiveDate3.TabIndex = 9
        lblActiveDate3.Text = "Label1"
        ' 
        ' lblUsername3
        ' 
        lblUsername3.AutoSize = True
        lblUsername3.Font = New Font("Century Gothic", 10F)
        lblUsername3.ForeColor = SystemColors.ControlLightLight
        lblUsername3.Location = New Point(1264, 84)
        lblUsername3.Name = "lblUsername3"
        lblUsername3.Size = New Size(76, 23)
        lblUsername3.TabIndex = 10
        lblUsername3.Text = "Label1"
        ' 
        ' lblActiveTime3
        ' 
        lblActiveTime3.AutoSize = True
        lblActiveTime3.Font = New Font("Century Gothic", 10F)
        lblActiveTime3.ForeColor = SystemColors.ControlLightLight
        lblActiveTime3.Location = New Point(1264, 49)
        lblActiveTime3.Name = "lblActiveTime3"
        lblActiveTime3.Size = New Size(76, 23)
        lblActiveTime3.TabIndex = 11
        lblActiveTime3.Text = "Label1"
        ' 
        ' btnRestore
        ' 
        btnRestore.BackColor = Color.DarkSeaGreen
        btnRestore.FlatAppearance.BorderColor = Color.Silver
        btnRestore.FlatStyle = FlatStyle.Flat
        btnRestore.Font = New Font("Century Gothic", 9F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        btnRestore.ForeColor = SystemColors.ControlLightLight
        btnRestore.Location = New Point(345, 103)
        btnRestore.Margin = New Padding(0)
        btnRestore.Name = "btnRestore"
        btnRestore.Size = New Size(114, 39)
        btnRestore.TabIndex = 1
        btnRestore.Text = "RESTORE"
        btnRestore.UseVisualStyleBackColor = False
        ' 
        ' Panel2
        ' 
        Panel2.BackColor = Color.LightSlateGray
        Panel2.Dock = DockStyle.Bottom
        Panel2.Location = New Point(0, 864)
        Panel2.Name = "Panel2"
        Panel2.Size = New Size(1378, 70)
        Panel2.TabIndex = 8
        ' 
        ' panelArch
        ' 
        panelArch.BackColor = Color.White
        panelArch.Controls.Add(dbArch)
        panelArch.Dock = DockStyle.Fill
        panelArch.Location = New Point(0, 164)
        panelArch.Name = "panelArch"
        panelArch.Size = New Size(1378, 700)
        panelArch.TabIndex = 9
        ' 
        ' dbArch
        ' 
        dbArch.AllowUserToAddRows = False
        dbArch.AllowUserToDeleteRows = False
        dbArch.AllowUserToResizeColumns = False
        dbArch.AllowUserToResizeRows = False
        DataGridViewCellStyle4.BackColor = Color.WhiteSmoke
        dbArch.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle4
        dbArch.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
        dbArch.BackgroundColor = Color.LightSteelBlue
        dbArch.BorderStyle = BorderStyle.None
        dbArch.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal
        dbArch.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single
        DataGridViewCellStyle5.Alignment = DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle5.BackColor = Color.LightSlateGray
        DataGridViewCellStyle5.Font = New Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        DataGridViewCellStyle5.ForeColor = Color.WhiteSmoke
        DataGridViewCellStyle5.SelectionBackColor = Color.SlateGray
        DataGridViewCellStyle5.SelectionForeColor = SystemColors.HighlightText
        DataGridViewCellStyle5.WrapMode = DataGridViewTriState.True
        dbArch.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle5
        dbArch.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DataGridViewCellStyle6.Alignment = DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle6.BackColor = SystemColors.Window
        DataGridViewCellStyle6.Font = New Font("Century Gothic", 9F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        DataGridViewCellStyle6.ForeColor = SystemColors.ControlText
        DataGridViewCellStyle6.SelectionBackColor = Color.LightGray
        DataGridViewCellStyle6.SelectionForeColor = Color.Black
        DataGridViewCellStyle6.WrapMode = DataGridViewTriState.False
        dbArch.DefaultCellStyle = DataGridViewCellStyle6
        dbArch.Dock = DockStyle.Fill
        dbArch.EnableHeadersVisualStyles = False
        dbArch.GridColor = Color.Gainsboro
        dbArch.Location = New Point(0, 0)
        dbArch.MultiSelect = False
        dbArch.Name = "dbArch"
        dbArch.ReadOnly = True
        dbArch.RowHeadersVisible = False
        dbArch.RowHeadersWidth = 62
        dbArch.SelectionMode = DataGridViewSelectionMode.FullRowSelect
        dbArch.Size = New Size(1378, 700)
        dbArch.TabIndex = 0
        ' 
        ' TimerDateTime3
        ' 
        TimerDateTime3.Enabled = True
        TimerDateTime3.Interval = 1000
        ' 
        ' Label4
        ' 
        Label4.AutoSize = True
        Label4.Font = New Font("Century Gothic", 16F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        Label4.ForeColor = Color.White
        Label4.Location = New Point(592, 20)
        Label4.Name = "Label4"
        Label4.Size = New Size(155, 38)
        Label4.TabIndex = 12
        Label4.Text = "ARCHIVE"
        ' 
        ' IntArch
        ' 
        AutoScaleDimensions = New SizeF(10F, 25F)
        AutoScaleMode = AutoScaleMode.Font
        ClientSize = New Size(1378, 934)
        Controls.Add(panelArch)
        Controls.Add(Panel2)
        Controls.Add(Panel1)
        FormBorderStyle = FormBorderStyle.None
        Name = "IntArch"
        Text = "IntArch"
        Panel1.ResumeLayout(False)
        Panel1.PerformLayout()
        panelArch.ResumeLayout(False)
        CType(dbArch, ComponentModel.ISupportInitialize).EndInit()
        ResumeLayout(False)
    End Sub

    Friend WithEvents Panel1 As Panel
    Friend WithEvents Panel2 As Panel
    Friend WithEvents panelArch As Panel
    Friend WithEvents dbArch As DataGridView
    Friend WithEvents btnRestore As Button
    Friend WithEvents lblActiveDate3 As Label
    Friend WithEvents lblUsername3 As Label
    Friend WithEvents lblActiveTime3 As Label
    Friend WithEvents TimerDateTime3 As Timer
    Friend WithEvents Label4 As Label
End Class
