<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class StockHistory
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
        Dim DataGridViewCellStyle1 As DataGridViewCellStyle = New DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As DataGridViewCellStyle = New DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As DataGridViewCellStyle = New DataGridViewCellStyle()
        Panel1 = New Panel()
        Label1 = New Label()
        Panel2 = New Panel()
        Label3 = New Label()
        Label2 = New Label()
        dtpTo = New DateTimePicker()
        dtpFrom = New DateTimePicker()
        btnClose = New Button()
        panelhistory = New Panel()
        dbhistory = New DataGridView()
        Panel1.SuspendLayout()
        Panel2.SuspendLayout()
        panelhistory.SuspendLayout()
        CType(dbhistory, ComponentModel.ISupportInitialize).BeginInit()
        SuspendLayout()
        ' 
        ' Panel1
        ' 
        Panel1.BackColor = Color.LightSlateGray
        Panel1.Controls.Add(Label1)
        Panel1.Dock = DockStyle.Top
        Panel1.Location = New Point(0, 0)
        Panel1.Name = "Panel1"
        Panel1.Size = New Size(1491, 76)
        Panel1.TabIndex = 0
        ' 
        ' Label1
        ' 
        Label1.AutoSize = True
        Label1.Font = New Font("Century Gothic", 16F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        Label1.ForeColor = Color.White
        Label1.Location = New Point(599, 20)
        Label1.Name = "Label1"
        Label1.Size = New Size(215, 38)
        Label1.TabIndex = 0
        Label1.Text = "Stock History"
        ' 
        ' Panel2
        ' 
        Panel2.BackColor = Color.LightSlateGray
        Panel2.Controls.Add(Label3)
        Panel2.Controls.Add(Label2)
        Panel2.Controls.Add(dtpTo)
        Panel2.Controls.Add(dtpFrom)
        Panel2.Controls.Add(btnClose)
        Panel2.Dock = DockStyle.Bottom
        Panel2.Location = New Point(0, 660)
        Panel2.Name = "Panel2"
        Panel2.Size = New Size(1491, 93)
        Panel2.TabIndex = 0
        ' 
        ' Label3
        ' 
        Label3.AutoSize = True
        Label3.Font = New Font("Segoe UI", 11F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        Label3.ForeColor = SystemColors.HighlightText
        Label3.Location = New Point(434, 32)
        Label3.Name = "Label3"
        Label3.Size = New Size(41, 30)
        Label3.TabIndex = 2
        Label3.Text = "To:"
        ' 
        ' Label2
        ' 
        Label2.AutoSize = True
        Label2.Font = New Font("Segoe UI", 11F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        Label2.ForeColor = SystemColors.HighlightText
        Label2.Location = New Point(24, 32)
        Label2.Name = "Label2"
        Label2.Size = New Size(69, 30)
        Label2.TabIndex = 2
        Label2.Text = "From:"
        ' 
        ' dtpTo
        ' 
        dtpTo.Location = New Point(481, 32)
        dtpTo.Name = "dtpTo"
        dtpTo.Size = New Size(313, 31)
        dtpTo.TabIndex = 1
        ' 
        ' dtpFrom
        ' 
        dtpFrom.Location = New Point(99, 32)
        dtpFrom.Name = "dtpFrom"
        dtpFrom.Size = New Size(313, 31)
        dtpFrom.TabIndex = 1
        ' 
        ' btnClose
        ' 
        btnClose.BackColor = Color.Firebrick
        btnClose.FlatAppearance.BorderColor = Color.Silver
        btnClose.FlatStyle = FlatStyle.Flat
        btnClose.Font = New Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        btnClose.ForeColor = SystemColors.HighlightText
        btnClose.Location = New Point(1304, 26)
        btnClose.Name = "btnClose"
        btnClose.Size = New Size(148, 44)
        btnClose.TabIndex = 0
        btnClose.Text = "Close"
        btnClose.UseVisualStyleBackColor = False
        ' 
        ' panelhistory
        ' 
        panelhistory.BackColor = Color.White
        panelhistory.Controls.Add(dbhistory)
        panelhistory.Dock = DockStyle.Fill
        panelhistory.Location = New Point(0, 76)
        panelhistory.Name = "panelhistory"
        panelhistory.Size = New Size(1491, 584)
        panelhistory.TabIndex = 1
        ' 
        ' dbhistory
        ' 
        dbhistory.AllowUserToAddRows = False
        dbhistory.AllowUserToDeleteRows = False
        dbhistory.AllowUserToResizeColumns = False
        dbhistory.AllowUserToResizeRows = False
        DataGridViewCellStyle1.BackColor = Color.WhiteSmoke
        dbhistory.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
        dbhistory.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
        dbhistory.BackgroundColor = Color.LightSteelBlue
        dbhistory.BorderStyle = BorderStyle.None
        dbhistory.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal
        dbhistory.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single
        DataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle2.BackColor = Color.LightSlateGray
        DataGridViewCellStyle2.Font = New Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        DataGridViewCellStyle2.ForeColor = SystemColors.HighlightText
        DataGridViewCellStyle2.SelectionBackColor = Color.SlateGray
        DataGridViewCellStyle2.SelectionForeColor = SystemColors.HighlightText
        DataGridViewCellStyle2.WrapMode = DataGridViewTriState.True
        dbhistory.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle2
        dbhistory.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DataGridViewCellStyle3.Alignment = DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle3.BackColor = SystemColors.Window
        DataGridViewCellStyle3.Font = New Font("Century Gothic", 9F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        DataGridViewCellStyle3.ForeColor = SystemColors.ControlText
        DataGridViewCellStyle3.SelectionBackColor = Color.LightGray
        DataGridViewCellStyle3.SelectionForeColor = Color.Black
        DataGridViewCellStyle3.WrapMode = DataGridViewTriState.False
        dbhistory.DefaultCellStyle = DataGridViewCellStyle3
        dbhistory.Dock = DockStyle.Fill
        dbhistory.EnableHeadersVisualStyles = False
        dbhistory.GridColor = Color.Gainsboro
        dbhistory.Location = New Point(0, 0)
        dbhistory.Name = "dbhistory"
        dbhistory.ReadOnly = True
        dbhistory.RowHeadersVisible = False
        dbhistory.RowHeadersWidth = 62
        dbhistory.SelectionMode = DataGridViewSelectionMode.FullRowSelect
        dbhistory.Size = New Size(1491, 584)
        dbhistory.TabIndex = 1
        ' 
        ' StockHistory
        ' 
        AutoScaleDimensions = New SizeF(10F, 25F)
        AutoScaleMode = AutoScaleMode.Font
        ClientSize = New Size(1491, 753)
        ControlBox = False
        Controls.Add(panelhistory)
        Controls.Add(Panel2)
        Controls.Add(Panel1)
        FormBorderStyle = FormBorderStyle.FixedSingle
        MaximizeBox = False
        MinimizeBox = False
        Name = "StockHistory"
        StartPosition = FormStartPosition.CenterScreen
        Text = "Medent+"
        Panel1.ResumeLayout(False)
        Panel1.PerformLayout()
        Panel2.ResumeLayout(False)
        Panel2.PerformLayout()
        panelhistory.ResumeLayout(False)
        CType(dbhistory, ComponentModel.ISupportInitialize).EndInit()
        ResumeLayout(False)
    End Sub

    Friend WithEvents Panel1 As Panel
    Friend WithEvents Panel2 As Panel
    Friend WithEvents panelhistory As Panel
    Friend WithEvents dbhistory As DataGridView
    Friend WithEvents btnClose As Button
    Friend WithEvents Label1 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents dtpTo As DateTimePicker
    Friend WithEvents dtpFrom As DateTimePicker
End Class
