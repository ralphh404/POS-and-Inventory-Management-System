<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Transhist
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
        Panel1 = New Panel()
        Label2 = New Label()
        Panel2 = New Panel()
        btnClose = New Button()
        dbThis = New DataGridView()
        Label4 = New Label()
        Label1 = New Label()
        txtHist = New TextBox()
        cmbT = New ComboBox()
        Panel1.SuspendLayout()
        Panel2.SuspendLayout()
        CType(dbThis, ComponentModel.ISupportInitialize).BeginInit()
        SuspendLayout()
        ' 
        ' Panel1
        ' 
        Panel1.BackColor = Color.LightSlateGray
        Panel1.Controls.Add(Label2)
        Panel1.Dock = DockStyle.Top
        Panel1.Location = New Point(0, 0)
        Panel1.Name = "Panel1"
        Panel1.Size = New Size(1218, 90)
        Panel1.TabIndex = 0
        ' 
        ' Label2
        ' 
        Label2.AutoSize = True
        Label2.Font = New Font("Century Gothic", 16F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        Label2.ForeColor = Color.White
        Label2.Location = New Point(417, 26)
        Label2.Name = "Label2"
        Label2.Size = New Size(372, 38)
        Label2.TabIndex = 1
        Label2.Text = "TRANSACTION HISTORY"
        ' 
        ' Panel2
        ' 
        Panel2.BackColor = Color.LightSlateGray
        Panel2.Controls.Add(btnClose)
        Panel2.Dock = DockStyle.Bottom
        Panel2.Location = New Point(0, 719)
        Panel2.Name = "Panel2"
        Panel2.Size = New Size(1218, 90)
        Panel2.TabIndex = 1
        ' 
        ' btnClose
        ' 
        btnClose.BackColor = Color.Firebrick
        btnClose.FlatAppearance.BorderColor = Color.Silver
        btnClose.FlatStyle = FlatStyle.Flat
        btnClose.Font = New Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        btnClose.ForeColor = Color.White
        btnClose.Location = New Point(1042, 21)
        btnClose.Name = "btnClose"
        btnClose.Size = New Size(160, 50)
        btnClose.TabIndex = 1
        btnClose.Text = "Close"
        btnClose.UseVisualStyleBackColor = False
        ' 
        ' dbThis
        ' 
        dbThis.AllowUserToAddRows = False
        dbThis.AllowUserToDeleteRows = False
        dbThis.AllowUserToResizeColumns = False
        dbThis.AllowUserToResizeRows = False
        dbThis.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
        dbThis.BackgroundColor = Color.WhiteSmoke
        dbThis.BorderStyle = BorderStyle.None
        dbThis.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal
        dbThis.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single
        DataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle1.BackColor = Color.LightSlateGray
        DataGridViewCellStyle1.Font = New Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        DataGridViewCellStyle1.ForeColor = SystemColors.HighlightText
        DataGridViewCellStyle1.SelectionBackColor = Color.SlateGray
        DataGridViewCellStyle1.SelectionForeColor = SystemColors.HighlightText
        DataGridViewCellStyle1.WrapMode = DataGridViewTriState.True
        dbThis.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        dbThis.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = SystemColors.Window
        DataGridViewCellStyle2.Font = New Font("Century Gothic", 9F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        DataGridViewCellStyle2.ForeColor = SystemColors.ControlText
        DataGridViewCellStyle2.SelectionBackColor = Color.LightGray
        DataGridViewCellStyle2.SelectionForeColor = Color.Black
        DataGridViewCellStyle2.WrapMode = DataGridViewTriState.False
        dbThis.DefaultCellStyle = DataGridViewCellStyle2
        dbThis.EnableHeadersVisualStyles = False
        dbThis.GridColor = Color.Gainsboro
        dbThis.Location = New Point(12, 178)
        dbThis.MultiSelect = False
        dbThis.Name = "dbThis"
        dbThis.ReadOnly = True
        dbThis.RowHeadersVisible = False
        dbThis.RowHeadersWidth = 62
        dbThis.SelectionMode = DataGridViewSelectionMode.FullRowSelect
        dbThis.Size = New Size(1194, 522)
        dbThis.TabIndex = 2
        ' 
        ' Label4
        ' 
        Label4.AutoSize = True
        Label4.Font = New Font("Century Gothic", 10F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        Label4.ForeColor = Color.DimGray
        Label4.Location = New Point(12, 123)
        Label4.Name = "Label4"
        Label4.Size = New Size(210, 23)
        Label4.TabIndex = 5
        Label4.Text = "Transaction Number:"
        ' 
        ' Label1
        ' 
        Label1.AutoSize = True
        Label1.Font = New Font("Century Gothic", 10F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        Label1.ForeColor = Color.DimGray
        Label1.Location = New Point(658, 123)
        Label1.Name = "Label1"
        Label1.Size = New Size(62, 23)
        Label1.TabIndex = 5
        Label1.Text = "Date:"
        ' 
        ' txtHist
        ' 
        txtHist.BorderStyle = BorderStyle.None
        txtHist.Location = New Point(722, 122)
        txtHist.Name = "txtHist"
        txtHist.ReadOnly = True
        txtHist.Size = New Size(279, 24)
        txtHist.TabIndex = 6
        ' 
        ' cmbT
        ' 
        cmbT.DropDownStyle = ComboBoxStyle.DropDownList
        cmbT.FormattingEnabled = True
        cmbT.Location = New Point(226, 119)
        cmbT.Name = "cmbT"
        cmbT.Size = New Size(292, 33)
        cmbT.TabIndex = 7
        ' 
        ' Transhist
        ' 
        AutoScaleDimensions = New SizeF(10F, 25F)
        AutoScaleMode = AutoScaleMode.Font
        BackColor = Color.LightSteelBlue
        ClientSize = New Size(1218, 809)
        ControlBox = False
        Controls.Add(cmbT)
        Controls.Add(txtHist)
        Controls.Add(Label1)
        Controls.Add(Label4)
        Controls.Add(dbThis)
        Controls.Add(Panel2)
        Controls.Add(Panel1)
        FormBorderStyle = FormBorderStyle.FixedSingle
        MaximizeBox = False
        MinimizeBox = False
        Name = "Transhist"
        StartPosition = FormStartPosition.CenterScreen
        Panel1.ResumeLayout(False)
        Panel1.PerformLayout()
        Panel2.ResumeLayout(False)
        CType(dbThis, ComponentModel.ISupportInitialize).EndInit()
        ResumeLayout(False)
        PerformLayout()
    End Sub

    Friend WithEvents Panel1 As Panel
    Friend WithEvents Panel2 As Panel
    Friend WithEvents dbThis As DataGridView
    Friend WithEvents Label4 As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents txtHist As TextBox
    Friend WithEvents cmbT As ComboBox
    Friend WithEvents btnClose As Button
    Friend WithEvents Label2 As Label
End Class
