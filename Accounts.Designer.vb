<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmAccounts
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
        Dim DataGridViewCellStyle6 As DataGridViewCellStyle = New DataGridViewCellStyle()
        Dim DataGridViewCellStyle7 As DataGridViewCellStyle = New DataGridViewCellStyle()
        Dim DataGridViewCellStyle8 As DataGridViewCellStyle = New DataGridViewCellStyle()
        Dim DataGridViewCellStyle9 As DataGridViewCellStyle = New DataGridViewCellStyle()
        Dim DataGridViewCellStyle10 As DataGridViewCellStyle = New DataGridViewCellStyle()
        panelAccounts = New Panel()
        dbAccounts = New DataGridView()
        Panel2 = New Panel()
        Panel1 = New Panel()
        lblActiveDate2 = New Label()
        lblUsername2 = New Label()
        lblActiveTime2 = New Label()
        Panel3 = New Panel()
        lblClr = New Label()
        txtSearchAcc = New TextBox()
        btnArch = New Button()
        btnChPass = New Button()
        Add = New Button()
        TimerDateTime2 = New Timer(components)
        Label4 = New Label()
        panelAccounts.SuspendLayout()
        CType(dbAccounts, ComponentModel.ISupportInitialize).BeginInit()
        Panel1.SuspendLayout()
        Panel3.SuspendLayout()
        SuspendLayout()
        ' 
        ' panelAccounts
        ' 
        panelAccounts.BackColor = Color.White
        panelAccounts.Controls.Add(dbAccounts)
        panelAccounts.Controls.Add(Panel2)
        panelAccounts.Controls.Add(Panel1)
        panelAccounts.Dock = DockStyle.Fill
        panelAccounts.Location = New Point(0, 0)
        panelAccounts.Name = "panelAccounts"
        panelAccounts.Size = New Size(1356, 878)
        panelAccounts.TabIndex = 0
        ' 
        ' dbAccounts
        ' 
        dbAccounts.AllowUserToAddRows = False
        dbAccounts.AllowUserToDeleteRows = False
        dbAccounts.AllowUserToResizeColumns = False
        dbAccounts.AllowUserToResizeRows = False
        DataGridViewCellStyle6.BackColor = Color.WhiteSmoke
        DataGridViewCellStyle6.Font = New Font("Century Gothic", 9F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        DataGridViewCellStyle6.ForeColor = Color.Black
        DataGridViewCellStyle6.SelectionBackColor = Color.LightGray
        DataGridViewCellStyle6.SelectionForeColor = Color.Black
        dbAccounts.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle6
        dbAccounts.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
        dbAccounts.BackgroundColor = Color.LightSteelBlue
        dbAccounts.BorderStyle = BorderStyle.None
        dbAccounts.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal
        dbAccounts.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single
        DataGridViewCellStyle7.Alignment = DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle7.BackColor = Color.LightSlateGray
        DataGridViewCellStyle7.Font = New Font("Segoe UI", 10F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        DataGridViewCellStyle7.ForeColor = SystemColors.ControlLightLight
        DataGridViewCellStyle7.SelectionBackColor = Color.SlateGray
        DataGridViewCellStyle7.SelectionForeColor = SystemColors.HighlightText
        DataGridViewCellStyle7.WrapMode = DataGridViewTriState.True
        dbAccounts.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle7
        dbAccounts.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DataGridViewCellStyle8.Alignment = DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle8.BackColor = SystemColors.Window
        DataGridViewCellStyle8.Font = New Font("Century Gothic", 9F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        DataGridViewCellStyle8.ForeColor = SystemColors.ControlText
        DataGridViewCellStyle8.SelectionBackColor = SystemColors.Highlight
        DataGridViewCellStyle8.SelectionForeColor = SystemColors.HighlightText
        DataGridViewCellStyle8.WrapMode = DataGridViewTriState.False
        dbAccounts.DefaultCellStyle = DataGridViewCellStyle8
        dbAccounts.Dock = DockStyle.Fill
        dbAccounts.EnableHeadersVisualStyles = False
        dbAccounts.GridColor = Color.Gainsboro
        dbAccounts.Location = New Point(0, 164)
        dbAccounts.MultiSelect = False
        dbAccounts.Name = "dbAccounts"
        dbAccounts.ReadOnly = True
        DataGridViewCellStyle9.Alignment = DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle9.BackColor = SystemColors.Control
        DataGridViewCellStyle9.Font = New Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        DataGridViewCellStyle9.ForeColor = SystemColors.WindowText
        DataGridViewCellStyle9.SelectionBackColor = SystemColors.Highlight
        DataGridViewCellStyle9.SelectionForeColor = SystemColors.HighlightText
        DataGridViewCellStyle9.WrapMode = DataGridViewTriState.True
        dbAccounts.RowHeadersDefaultCellStyle = DataGridViewCellStyle9
        dbAccounts.RowHeadersVisible = False
        dbAccounts.RowHeadersWidth = 62
        DataGridViewCellStyle10.BackColor = Color.White
        DataGridViewCellStyle10.Font = New Font("Century Gothic", 9F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        DataGridViewCellStyle10.SelectionBackColor = Color.LightGray
        DataGridViewCellStyle10.SelectionForeColor = Color.Black
        dbAccounts.RowsDefaultCellStyle = DataGridViewCellStyle10
        dbAccounts.ScrollBars = ScrollBars.Vertical
        dbAccounts.SelectionMode = DataGridViewSelectionMode.FullRowSelect
        dbAccounts.Size = New Size(1356, 644)
        dbAccounts.TabIndex = 4
        ' 
        ' Panel2
        ' 
        Panel2.BackColor = Color.LightSlateGray
        Panel2.Dock = DockStyle.Bottom
        Panel2.Location = New Point(0, 808)
        Panel2.Name = "Panel2"
        Panel2.Size = New Size(1356, 70)
        Panel2.TabIndex = 3
        ' 
        ' Panel1
        ' 
        Panel1.BackColor = Color.LightSlateGray
        Panel1.Controls.Add(Label4)
        Panel1.Controls.Add(lblActiveDate2)
        Panel1.Controls.Add(lblUsername2)
        Panel1.Controls.Add(lblActiveTime2)
        Panel1.Controls.Add(Panel3)
        Panel1.Controls.Add(btnArch)
        Panel1.Controls.Add(btnChPass)
        Panel1.Controls.Add(Add)
        Panel1.Dock = DockStyle.Top
        Panel1.Location = New Point(0, 0)
        Panel1.Name = "Panel1"
        Panel1.Size = New Size(1356, 164)
        Panel1.TabIndex = 1
        ' 
        ' lblActiveDate2
        ' 
        lblActiveDate2.AutoSize = True
        lblActiveDate2.Font = New Font("Century Gothic", 10F)
        lblActiveDate2.ForeColor = SystemColors.ControlLightLight
        lblActiveDate2.Location = New Point(1264, 16)
        lblActiveDate2.Name = "lblActiveDate2"
        lblActiveDate2.Size = New Size(76, 23)
        lblActiveDate2.TabIndex = 6
        lblActiveDate2.Text = "Label1"
        ' 
        ' lblUsername2
        ' 
        lblUsername2.AutoSize = True
        lblUsername2.Font = New Font("Century Gothic", 10F)
        lblUsername2.ForeColor = SystemColors.ControlLightLight
        lblUsername2.Location = New Point(1264, 84)
        lblUsername2.Name = "lblUsername2"
        lblUsername2.Size = New Size(76, 23)
        lblUsername2.TabIndex = 7
        lblUsername2.Text = "Label1"
        ' 
        ' lblActiveTime2
        ' 
        lblActiveTime2.AutoSize = True
        lblActiveTime2.Font = New Font("Century Gothic", 10F)
        lblActiveTime2.ForeColor = SystemColors.ControlLightLight
        lblActiveTime2.Location = New Point(1264, 49)
        lblActiveTime2.Name = "lblActiveTime2"
        lblActiveTime2.Size = New Size(76, 23)
        lblActiveTime2.TabIndex = 8
        lblActiveTime2.Text = "Label1"
        ' 
        ' Panel3
        ' 
        Panel3.BackColor = SystemColors.Window
        Panel3.Controls.Add(lblClr)
        Panel3.Controls.Add(txtSearchAcc)
        Panel3.Location = New Point(788, 93)
        Panel3.Name = "Panel3"
        Panel3.Size = New Size(378, 54)
        Panel3.TabIndex = 5
        ' 
        ' lblClr
        ' 
        lblClr.AutoSize = True
        lblClr.BackColor = SystemColors.Window
        lblClr.Cursor = Cursors.Hand
        lblClr.Font = New Font("Century Gothic", 9F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        lblClr.ForeColor = Color.Gray
        lblClr.Location = New Point(348, 15)
        lblClr.Name = "lblClr"
        lblClr.Size = New Size(20, 22)
        lblClr.TabIndex = 6
        lblClr.Text = "x"
        ' 
        ' txtSearchAcc
        ' 
        txtSearchAcc.BorderStyle = BorderStyle.None
        txtSearchAcc.Location = New Point(12, 16)
        txtSearchAcc.Name = "txtSearchAcc"
        txtSearchAcc.Size = New Size(330, 24)
        txtSearchAcc.TabIndex = 3
        ' 
        ' btnArch
        ' 
        btnArch.BackColor = Color.Firebrick
        btnArch.FlatAppearance.BorderColor = Color.Silver
        btnArch.FlatStyle = FlatStyle.Flat
        btnArch.Font = New Font("Century Gothic", 9F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        btnArch.ForeColor = SystemColors.ControlLightLight
        btnArch.Location = New Point(641, 103)
        btnArch.Margin = New Padding(0)
        btnArch.Name = "btnArch"
        btnArch.Size = New Size(114, 39)
        btnArch.TabIndex = 1
        btnArch.Text = "ARCHIVE"
        btnArch.UseVisualStyleBackColor = False
        ' 
        ' btnChPass
        ' 
        btnChPass.BackColor = SystemColors.ActiveCaption
        btnChPass.FlatAppearance.BorderColor = Color.Silver
        btnChPass.FlatStyle = FlatStyle.Flat
        btnChPass.Font = New Font("Century Gothic", 9F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        btnChPass.ForeColor = SystemColors.ControlLightLight
        btnChPass.Location = New Point(397, 103)
        btnChPass.Margin = New Padding(0)
        btnChPass.Name = "btnChPass"
        btnChPass.Size = New Size(232, 39)
        btnChPass.TabIndex = 0
        btnChPass.Text = "Change Password"
        btnChPass.UseVisualStyleBackColor = False
        ' 
        ' Add
        ' 
        Add.BackColor = Color.DarkSeaGreen
        Add.FlatAppearance.BorderColor = Color.Silver
        Add.FlatStyle = FlatStyle.Flat
        Add.Font = New Font("Century Gothic", 9F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        Add.ForeColor = SystemColors.ControlLightLight
        Add.Location = New Point(267, 103)
        Add.Margin = New Padding(0)
        Add.Name = "Add"
        Add.Size = New Size(114, 39)
        Add.TabIndex = 0
        Add.Text = "ADD"
        Add.UseVisualStyleBackColor = False
        ' 
        ' TimerDateTime2
        ' 
        TimerDateTime2.Enabled = True
        TimerDateTime2.Interval = 1000
        ' 
        ' Label4
        ' 
        Label4.AutoSize = True
        Label4.Font = New Font("Century Gothic", 16F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        Label4.ForeColor = Color.White
        Label4.Location = New Point(592, 20)
        Label4.Name = "Label4"
        Label4.Size = New Size(192, 38)
        Label4.TabIndex = 13
        Label4.Text = "ACCOUNTS"
        ' 
        ' frmAccounts
        ' 
        AutoScaleDimensions = New SizeF(10F, 25F)
        AutoScaleMode = AutoScaleMode.Font
        ClientSize = New Size(1356, 878)
        Controls.Add(panelAccounts)
        FormBorderStyle = FormBorderStyle.None
        Name = "frmAccounts"
        Text = "Accounts"
        panelAccounts.ResumeLayout(False)
        CType(dbAccounts, ComponentModel.ISupportInitialize).EndInit()
        Panel1.ResumeLayout(False)
        Panel1.PerformLayout()
        Panel3.ResumeLayout(False)
        Panel3.PerformLayout()
        ResumeLayout(False)
    End Sub

    Friend WithEvents panelAccounts As Panel
    Friend WithEvents Panel2 As Panel
    Friend WithEvents Panel1 As Panel
    Friend WithEvents Add As Button
    Friend WithEvents dbAccounts As DataGridView
    Friend WithEvents btnChPass As Button
    Friend WithEvents btnArch As Button
    Friend WithEvents Panel3 As Panel
    Friend WithEvents txtSearchAcc As TextBox
    Friend WithEvents lblClr As Label
    Friend WithEvents lblActiveDate2 As Label
    Friend WithEvents lblUsername2 As Label
    Friend WithEvents lblActiveTime2 As Label
    Friend WithEvents TimerDateTime2 As Timer
    Friend WithEvents Label4 As Label
End Class
