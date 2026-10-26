<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Pending
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
        btnCancel = New Button()
        btnProcess = New Button()
        dbPending = New DataGridView()
        Label4 = New Label()
        cmbPending = New ComboBox()
        lblAmount = New Label()
        Panel1.SuspendLayout()
        Panel2.SuspendLayout()
        CType(dbPending, ComponentModel.ISupportInitialize).BeginInit()
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
        Panel1.TabIndex = 2
        ' 
        ' Label2
        ' 
        Label2.AutoSize = True
        Label2.Font = New Font("Century Gothic", 16F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        Label2.ForeColor = Color.White
        Label2.Location = New Point(430, 26)
        Label2.Name = "Label2"
        Label2.Size = New Size(328, 38)
        Label2.TabIndex = 1
        Label2.Text = "PENDING PRODUCTS"
        ' 
        ' Panel2
        ' 
        Panel2.BackColor = Color.LightSlateGray
        Panel2.Controls.Add(btnCancel)
        Panel2.Controls.Add(btnProcess)
        Panel2.Dock = DockStyle.Bottom
        Panel2.Location = New Point(0, 696)
        Panel2.Name = "Panel2"
        Panel2.Size = New Size(1218, 113)
        Panel2.TabIndex = 3
        ' 
        ' btnCancel
        ' 
        btnCancel.BackColor = Color.Firebrick
        btnCancel.FlatAppearance.BorderColor = Color.Silver
        btnCancel.FlatAppearance.BorderSize = 3
        btnCancel.FlatStyle = FlatStyle.Flat
        btnCancel.Font = New Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        btnCancel.ForeColor = Color.White
        btnCancel.Location = New Point(150, 17)
        btnCancel.Name = "btnCancel"
        btnCancel.Size = New Size(110, 80)
        btnCancel.TabIndex = 4
        btnCancel.Text = "Cancel"
        btnCancel.UseVisualStyleBackColor = False
        ' 
        ' btnProcess
        ' 
        btnProcess.BackColor = Color.Teal
        btnProcess.FlatAppearance.BorderColor = Color.Silver
        btnProcess.FlatAppearance.BorderSize = 3
        btnProcess.FlatStyle = FlatStyle.Flat
        btnProcess.Font = New Font("Segoe UI", 8F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        btnProcess.ForeColor = Color.White
        btnProcess.Location = New Point(25, 18)
        btnProcess.Name = "btnProcess"
        btnProcess.Size = New Size(110, 80)
        btnProcess.TabIndex = 4
        btnProcess.Text = "PROCESS [Ctrl + P]"
        btnProcess.UseVisualStyleBackColor = False
        ' 
        ' dbPending
        ' 
        dbPending.AllowUserToAddRows = False
        dbPending.AllowUserToDeleteRows = False
        dbPending.AllowUserToResizeColumns = False
        dbPending.AllowUserToResizeRows = False
        dbPending.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
        dbPending.BackgroundColor = Color.WhiteSmoke
        dbPending.BorderStyle = BorderStyle.None
        dbPending.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal
        dbPending.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single
        DataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle1.BackColor = Color.LightSlateGray
        DataGridViewCellStyle1.Font = New Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        DataGridViewCellStyle1.ForeColor = SystemColors.HighlightText
        DataGridViewCellStyle1.SelectionBackColor = Color.SlateGray
        DataGridViewCellStyle1.SelectionForeColor = SystemColors.HighlightText
        DataGridViewCellStyle1.WrapMode = DataGridViewTriState.True
        dbPending.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        dbPending.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = SystemColors.Window
        DataGridViewCellStyle2.Font = New Font("Century Gothic", 9F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        DataGridViewCellStyle2.ForeColor = SystemColors.ControlText
        DataGridViewCellStyle2.SelectionBackColor = Color.LightGray
        DataGridViewCellStyle2.SelectionForeColor = Color.Black
        DataGridViewCellStyle2.WrapMode = DataGridViewTriState.False
        dbPending.DefaultCellStyle = DataGridViewCellStyle2
        dbPending.EnableHeadersVisualStyles = False
        dbPending.GridColor = Color.Gainsboro
        dbPending.Location = New Point(12, 160)
        dbPending.MultiSelect = False
        dbPending.Name = "dbPending"
        dbPending.ReadOnly = True
        dbPending.RowHeadersVisible = False
        dbPending.RowHeadersWidth = 62
        dbPending.SelectionMode = DataGridViewSelectionMode.FullRowSelect
        dbPending.Size = New Size(1194, 522)
        dbPending.TabIndex = 4
        ' 
        ' Label4
        ' 
        Label4.AutoSize = True
        Label4.Font = New Font("Century Gothic", 10F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        Label4.ForeColor = Color.DimGray
        Label4.Location = New Point(698, 113)
        Label4.Name = "Label4"
        Label4.Size = New Size(210, 23)
        Label4.TabIndex = 6
        Label4.Text = "Transaction Number:"
        ' 
        ' cmbPending
        ' 
        cmbPending.DropDownStyle = ComboBoxStyle.DropDownList
        cmbPending.FormattingEnabled = True
        cmbPending.Location = New Point(914, 109)
        cmbPending.Name = "cmbPending"
        cmbPending.Size = New Size(292, 33)
        cmbPending.TabIndex = 7
        ' 
        ' lblAmount
        ' 
        lblAmount.AutoSize = True
        lblAmount.Font = New Font("Century Gothic", 12F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        lblAmount.ForeColor = Color.DimGray
        lblAmount.Location = New Point(534, 109)
        lblAmount.Name = "lblAmount"
        lblAmount.Size = New Size(58, 28)
        lblAmount.TabIndex = 6
        lblAmount.Text = "0.00"
        ' 
        ' Pending
        ' 
        AutoScaleDimensions = New SizeF(10F, 25F)
        AutoScaleMode = AutoScaleMode.Font
        BackColor = Color.LightSteelBlue
        ClientSize = New Size(1218, 809)
        ControlBox = False
        Controls.Add(cmbPending)
        Controls.Add(lblAmount)
        Controls.Add(Label4)
        Controls.Add(dbPending)
        Controls.Add(Panel2)
        Controls.Add(Panel1)
        FormBorderStyle = FormBorderStyle.FixedSingle
        MaximizeBox = False
        MinimizeBox = False
        Name = "Pending"
        StartPosition = FormStartPosition.CenterScreen
        Panel1.ResumeLayout(False)
        Panel1.PerformLayout()
        Panel2.ResumeLayout(False)
        CType(dbPending, ComponentModel.ISupportInitialize).EndInit()
        ResumeLayout(False)
        PerformLayout()
    End Sub

    Friend WithEvents Panel1 As Panel
    Friend WithEvents Label2 As Label
    Friend WithEvents Panel2 As Panel
    Friend WithEvents dbPending As DataGridView
    Friend WithEvents btnCancel As Button
    Friend WithEvents btnProcess As Button
    Friend WithEvents Label4 As Label
    Friend WithEvents cmbPending As ComboBox
    Friend WithEvents lblAmount As Label
End Class
