<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Categories
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
        Panel1 = New Panel()
        lblActiveDate22 = New Label()
        lblUsername22 = New Label()
        lblActiveTime22 = New Label()
        btnDeleteC = New Button()
        btnAddC = New Button()
        btnEditC = New Button()
        Label1 = New Label()
        Panel2 = New Panel()
        panelCategories = New Panel()
        dbCategories = New DataGridView()
        Tick2 = New Timer(components)
        Panel1.SuspendLayout()
        panelCategories.SuspendLayout()
        CType(dbCategories, ComponentModel.ISupportInitialize).BeginInit()
        SuspendLayout()
        ' 
        ' Panel1
        ' 
        Panel1.BackColor = Color.LightSlateGray
        Panel1.Controls.Add(lblActiveDate22)
        Panel1.Controls.Add(lblUsername22)
        Panel1.Controls.Add(lblActiveTime22)
        Panel1.Controls.Add(btnDeleteC)
        Panel1.Controls.Add(btnAddC)
        Panel1.Controls.Add(btnEditC)
        Panel1.Controls.Add(Label1)
        Panel1.Dock = DockStyle.Top
        Panel1.Location = New Point(0, 0)
        Panel1.Name = "Panel1"
        Panel1.Size = New Size(1545, 164)
        Panel1.TabIndex = 7
        ' 
        ' lblActiveDate22
        ' 
        lblActiveDate22.AutoSize = True
        lblActiveDate22.Font = New Font("Century Gothic", 10F)
        lblActiveDate22.ForeColor = SystemColors.ControlLightLight
        lblActiveDate22.Location = New Point(1315, 16)
        lblActiveDate22.Name = "lblActiveDate22"
        lblActiveDate22.Size = New Size(76, 23)
        lblActiveDate22.TabIndex = 12
        lblActiveDate22.Text = "Label1"
        ' 
        ' lblUsername22
        ' 
        lblUsername22.AutoSize = True
        lblUsername22.Font = New Font("Century Gothic", 10F)
        lblUsername22.ForeColor = SystemColors.ControlLightLight
        lblUsername22.Location = New Point(1315, 82)
        lblUsername22.Name = "lblUsername22"
        lblUsername22.Size = New Size(76, 23)
        lblUsername22.TabIndex = 13
        lblUsername22.Text = "Label1"
        ' 
        ' lblActiveTime22
        ' 
        lblActiveTime22.AutoSize = True
        lblActiveTime22.Font = New Font("Century Gothic", 10F)
        lblActiveTime22.ForeColor = SystemColors.ControlLightLight
        lblActiveTime22.Location = New Point(1315, 50)
        lblActiveTime22.Name = "lblActiveTime22"
        lblActiveTime22.Size = New Size(76, 23)
        lblActiveTime22.TabIndex = 14
        lblActiveTime22.Text = "Label1"
        ' 
        ' btnDeleteC
        ' 
        btnDeleteC.BackColor = Color.Firebrick
        btnDeleteC.FlatAppearance.BorderColor = Color.Silver
        btnDeleteC.FlatStyle = FlatStyle.Flat
        btnDeleteC.Font = New Font("Century Gothic", 9F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        btnDeleteC.ForeColor = SystemColors.ControlLightLight
        btnDeleteC.Location = New Point(526, 102)
        btnDeleteC.Name = "btnDeleteC"
        btnDeleteC.Size = New Size(114, 39)
        btnDeleteC.TabIndex = 9
        btnDeleteC.Text = "DELETE"
        btnDeleteC.UseVisualStyleBackColor = False
        ' 
        ' btnAddC
        ' 
        btnAddC.BackColor = Color.DarkSeaGreen
        btnAddC.FlatAppearance.BorderColor = Color.Silver
        btnAddC.FlatStyle = FlatStyle.Flat
        btnAddC.Font = New Font("Century Gothic", 9F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        btnAddC.ForeColor = SystemColors.ControlLightLight
        btnAddC.Location = New Point(286, 102)
        btnAddC.Name = "btnAddC"
        btnAddC.Size = New Size(114, 39)
        btnAddC.TabIndex = 8
        btnAddC.Text = "ADD"
        btnAddC.UseVisualStyleBackColor = False
        ' 
        ' btnEditC
        ' 
        btnEditC.BackColor = Color.Teal
        btnEditC.FlatAppearance.BorderColor = Color.Silver
        btnEditC.FlatStyle = FlatStyle.Flat
        btnEditC.Font = New Font("Century Gothic", 9F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        btnEditC.ForeColor = SystemColors.ControlLightLight
        btnEditC.Location = New Point(406, 102)
        btnEditC.Name = "btnEditC"
        btnEditC.Size = New Size(114, 39)
        btnEditC.TabIndex = 8
        btnEditC.Text = "EDIT"
        btnEditC.UseVisualStyleBackColor = False
        ' 
        ' Label1
        ' 
        Label1.AutoSize = True
        Label1.Font = New Font("Century Gothic", 16F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        Label1.ForeColor = SystemColors.ControlLightLight
        Label1.Location = New Point(588, 9)
        Label1.Name = "Label1"
        Label1.Size = New Size(192, 38)
        Label1.TabIndex = 7
        Label1.Text = "INVENTORY"
        ' 
        ' Panel2
        ' 
        Panel2.BackColor = Color.LightSlateGray
        Panel2.Dock = DockStyle.Bottom
        Panel2.Location = New Point(0, 864)
        Panel2.Name = "Panel2"
        Panel2.Size = New Size(1545, 70)
        Panel2.TabIndex = 8
        ' 
        ' panelCategories
        ' 
        panelCategories.BackColor = Color.White
        panelCategories.Controls.Add(dbCategories)
        panelCategories.Dock = DockStyle.Fill
        panelCategories.Location = New Point(0, 164)
        panelCategories.Name = "panelCategories"
        panelCategories.Size = New Size(1545, 700)
        panelCategories.TabIndex = 9
        ' 
        ' dbCategories
        ' 
        dbCategories.AllowUserToAddRows = False
        dbCategories.AllowUserToDeleteRows = False
        dbCategories.AllowUserToResizeColumns = False
        dbCategories.AllowUserToResizeRows = False
        dbCategories.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
        dbCategories.BackgroundColor = Color.LightSteelBlue
        dbCategories.BorderStyle = BorderStyle.None
        dbCategories.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single
        DataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle1.BackColor = Color.LightSlateGray
        DataGridViewCellStyle1.Font = New Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        DataGridViewCellStyle1.ForeColor = SystemColors.ControlLightLight
        DataGridViewCellStyle1.SelectionBackColor = Color.SlateGray
        DataGridViewCellStyle1.SelectionForeColor = SystemColors.HighlightText
        DataGridViewCellStyle1.WrapMode = DataGridViewTriState.True
        dbCategories.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        dbCategories.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = SystemColors.Window
        DataGridViewCellStyle2.Font = New Font("Century Gothic", 9F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        DataGridViewCellStyle2.ForeColor = SystemColors.ControlText
        DataGridViewCellStyle2.SelectionBackColor = Color.LightGray
        DataGridViewCellStyle2.SelectionForeColor = Color.Black
        DataGridViewCellStyle2.WrapMode = DataGridViewTriState.False
        dbCategories.DefaultCellStyle = DataGridViewCellStyle2
        dbCategories.Dock = DockStyle.Fill
        dbCategories.EnableHeadersVisualStyles = False
        dbCategories.GridColor = Color.Gainsboro
        dbCategories.Location = New Point(0, 0)
        dbCategories.MultiSelect = False
        dbCategories.Name = "dbCategories"
        dbCategories.ReadOnly = True
        dbCategories.RowHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single
        dbCategories.RowHeadersVisible = False
        dbCategories.RowHeadersWidth = 62
        dbCategories.ScrollBars = ScrollBars.Vertical
        dbCategories.SelectionMode = DataGridViewSelectionMode.FullRowSelect
        dbCategories.Size = New Size(1545, 700)
        dbCategories.TabIndex = 0
        ' 
        ' Tick2
        ' 
        Tick2.Enabled = True
        Tick2.Interval = 1000
        ' 
        ' Categories
        ' 
        AutoScaleDimensions = New SizeF(10F, 25F)
        AutoScaleMode = AutoScaleMode.Font
        ClientSize = New Size(1545, 934)
        Controls.Add(panelCategories)
        Controls.Add(Panel2)
        Controls.Add(Panel1)
        FormBorderStyle = FormBorderStyle.None
        Name = "Categories"
        Text = "Categories"
        Panel1.ResumeLayout(False)
        Panel1.PerformLayout()
        panelCategories.ResumeLayout(False)
        CType(dbCategories, ComponentModel.ISupportInitialize).EndInit()
        ResumeLayout(False)
    End Sub

    Friend WithEvents Panel1 As Panel
    Friend WithEvents Panel2 As Panel
    Friend WithEvents panelCategories As Panel
    Friend WithEvents dbCategories As DataGridView
    Friend WithEvents Label1 As Label
    Friend WithEvents btnAddC As Button
    Friend WithEvents btnEditC As Button
    Friend WithEvents btnDeleteC As Button
    Friend WithEvents lblActiveDate22 As Label
    Friend WithEvents lblUsername22 As Label
    Friend WithEvents lblActiveTime22 As Label
    Friend WithEvents Tick2 As Timer
End Class
