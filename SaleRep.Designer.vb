<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class SaleRep
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
        Label5 = New Label()
        PictureBox3 = New PictureBox()
        Panel5 = New Panel()
        Label4 = New Label()
        Label3 = New Label()
        lblTotalS = New Label()
        Panel2 = New Panel()
        Label1 = New Label()
        Label2 = New Label()
        dtTo = New DateTimePicker()
        dtFrom = New DateTimePicker()
        btnPrint = New Button()
        btnClose = New Button()
        Panel3 = New Panel()
        Panel4 = New Panel()
        dbSales = New DataGridView()
        Panel1.SuspendLayout()
        CType(PictureBox3, ComponentModel.ISupportInitialize).BeginInit()
        Panel5.SuspendLayout()
        Panel2.SuspendLayout()
        CType(dbSales, ComponentModel.ISupportInitialize).BeginInit()
        SuspendLayout()
        ' 
        ' Panel1
        ' 
        Panel1.BackColor = Color.LightSlateGray
        Panel1.Controls.Add(Label5)
        Panel1.Controls.Add(PictureBox3)
        Panel1.Controls.Add(Panel5)
        Panel1.Controls.Add(Label3)
        Panel1.Controls.Add(lblTotalS)
        Panel1.Dock = DockStyle.Top
        Panel1.Location = New Point(0, 0)
        Panel1.Name = "Panel1"
        Panel1.Size = New Size(1893, 200)
        Panel1.TabIndex = 0
        ' 
        ' Label5
        ' 
        Label5.AutoSize = True
        Label5.BackColor = Color.LightSlateGray
        Label5.Font = New Font("Century Gothic", 11F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        Label5.ForeColor = Color.White
        Label5.Location = New Point(214, 124)
        Label5.Name = "Label5"
        Label5.Size = New Size(61, 26)
        Label5.TabIndex = 4
        Label5.Text = "USER"
        ' 
        ' PictureBox3
        ' 
        PictureBox3.Image = My.Resources.Resources.silver_membership_icon_default_avatar_profile_icon_membership_icon_social_media_user_image_illustration_vector
        PictureBox3.Location = New Point(108, 87)
        PictureBox3.Name = "PictureBox3"
        PictureBox3.Size = New Size(100, 100)
        PictureBox3.SizeMode = PictureBoxSizeMode.StretchImage
        PictureBox3.TabIndex = 3
        PictureBox3.TabStop = False
        ' 
        ' Panel5
        ' 
        Panel5.BackColor = Color.SlateGray
        Panel5.Controls.Add(Label4)
        Panel5.Dock = DockStyle.Top
        Panel5.Location = New Point(0, 0)
        Panel5.Name = "Panel5"
        Panel5.Size = New Size(1893, 75)
        Panel5.TabIndex = 2
        ' 
        ' Label4
        ' 
        Label4.AutoSize = True
        Label4.Font = New Font("Century Gothic", 16F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        Label4.ForeColor = Color.White
        Label4.Location = New Point(853, 18)
        Label4.Name = "Label4"
        Label4.Size = New Size(228, 38)
        Label4.TabIndex = 2
        Label4.Text = "SALES REPORT"
        ' 
        ' Label3
        ' 
        Label3.AutoSize = True
        Label3.Font = New Font("Century Gothic", 16F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        Label3.ForeColor = Color.White
        Label3.Location = New Point(1456, 140)
        Label3.Name = "Label3"
        Label3.Size = New Size(187, 38)
        Label3.TabIndex = 1
        Label3.Text = "Total Sales:"
        ' 
        ' lblTotalS
        ' 
        lblTotalS.AutoSize = True
        lblTotalS.BackColor = SystemColors.Control
        lblTotalS.BorderStyle = BorderStyle.FixedSingle
        lblTotalS.FlatStyle = FlatStyle.Flat
        lblTotalS.Font = New Font("Century Gothic", 16F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        lblTotalS.ForeColor = Color.Gray
        lblTotalS.Location = New Point(1649, 140)
        lblTotalS.Name = "lblTotalS"
        lblTotalS.Size = New Size(121, 40)
        lblTotalS.TabIndex = 0
        lblTotalS.Text = "Label3"
        ' 
        ' Panel2
        ' 
        Panel2.BackColor = Color.LightSlateGray
        Panel2.Controls.Add(Label1)
        Panel2.Controls.Add(Label2)
        Panel2.Controls.Add(dtTo)
        Panel2.Controls.Add(dtFrom)
        Panel2.Controls.Add(btnPrint)
        Panel2.Controls.Add(btnClose)
        Panel2.Dock = DockStyle.Bottom
        Panel2.Location = New Point(0, 829)
        Panel2.Name = "Panel2"
        Panel2.Size = New Size(1893, 105)
        Panel2.TabIndex = 1
        ' 
        ' Label1
        ' 
        Label1.AutoSize = True
        Label1.Font = New Font("Segoe UI", 11F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        Label1.ForeColor = SystemColors.HighlightText
        Label1.Location = New Point(539, 27)
        Label1.Name = "Label1"
        Label1.Size = New Size(41, 30)
        Label1.TabIndex = 3
        Label1.Text = "To:"
        ' 
        ' Label2
        ' 
        Label2.AutoSize = True
        Label2.Font = New Font("Segoe UI", 11F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        Label2.ForeColor = SystemColors.HighlightText
        Label2.Location = New Point(108, 27)
        Label2.Name = "Label2"
        Label2.Size = New Size(69, 30)
        Label2.TabIndex = 3
        Label2.Text = "From:"
        ' 
        ' dtTo
        ' 
        dtTo.Location = New Point(586, 26)
        dtTo.Name = "dtTo"
        dtTo.Size = New Size(322, 31)
        dtTo.TabIndex = 1
        ' 
        ' dtFrom
        ' 
        dtFrom.Location = New Point(183, 26)
        dtFrom.Name = "dtFrom"
        dtFrom.Size = New Size(322, 31)
        dtFrom.TabIndex = 1
        ' 
        ' btnPrint
        ' 
        btnPrint.BackColor = Color.SteelBlue
        btnPrint.FlatAppearance.BorderColor = Color.Silver
        btnPrint.FlatStyle = FlatStyle.Flat
        btnPrint.Font = New Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        btnPrint.ForeColor = Color.White
        btnPrint.Location = New Point(1544, 27)
        btnPrint.Name = "btnPrint"
        btnPrint.Size = New Size(160, 50)
        btnPrint.TabIndex = 0
        btnPrint.Text = "Print"
        btnPrint.UseVisualStyleBackColor = False
        ' 
        ' btnClose
        ' 
        btnClose.BackColor = Color.Firebrick
        btnClose.FlatAppearance.BorderColor = Color.Silver
        btnClose.FlatStyle = FlatStyle.Flat
        btnClose.Font = New Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        btnClose.ForeColor = Color.White
        btnClose.Location = New Point(1728, 27)
        btnClose.Name = "btnClose"
        btnClose.Size = New Size(160, 50)
        btnClose.TabIndex = 0
        btnClose.Text = "Close"
        btnClose.UseVisualStyleBackColor = False
        ' 
        ' Panel3
        ' 
        Panel3.BackColor = Color.LightSlateGray
        Panel3.Dock = DockStyle.Right
        Panel3.Location = New Point(1877, 200)
        Panel3.Name = "Panel3"
        Panel3.Size = New Size(16, 629)
        Panel3.TabIndex = 2
        ' 
        ' Panel4
        ' 
        Panel4.BackColor = Color.LightSlateGray
        Panel4.Dock = DockStyle.Left
        Panel4.Location = New Point(0, 200)
        Panel4.Name = "Panel4"
        Panel4.Size = New Size(108, 629)
        Panel4.TabIndex = 3
        ' 
        ' dbSales
        ' 
        dbSales.AllowUserToAddRows = False
        dbSales.AllowUserToDeleteRows = False
        dbSales.AllowUserToResizeColumns = False
        dbSales.AllowUserToResizeRows = False
        DataGridViewCellStyle1.BackColor = Color.WhiteSmoke
        dbSales.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
        dbSales.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
        dbSales.BackgroundColor = Color.LightSteelBlue
        dbSales.BorderStyle = BorderStyle.None
        dbSales.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal
        dbSales.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single
        DataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle2.BackColor = Color.SteelBlue
        DataGridViewCellStyle2.Font = New Font("Segoe UI", 10F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        DataGridViewCellStyle2.ForeColor = Color.White
        DataGridViewCellStyle2.SelectionBackColor = Color.LightSteelBlue
        DataGridViewCellStyle2.SelectionForeColor = SystemColors.HighlightText
        DataGridViewCellStyle2.WrapMode = DataGridViewTriState.True
        dbSales.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle2
        dbSales.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DataGridViewCellStyle3.Alignment = DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle3.BackColor = SystemColors.Window
        DataGridViewCellStyle3.Font = New Font("Century Gothic", 9F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        DataGridViewCellStyle3.ForeColor = SystemColors.ControlText
        DataGridViewCellStyle3.SelectionBackColor = Color.LightGray
        DataGridViewCellStyle3.SelectionForeColor = SystemColors.ControlText
        DataGridViewCellStyle3.WrapMode = DataGridViewTriState.False
        dbSales.DefaultCellStyle = DataGridViewCellStyle3
        dbSales.Dock = DockStyle.Fill
        dbSales.EnableHeadersVisualStyles = False
        dbSales.GridColor = Color.Gainsboro
        dbSales.Location = New Point(108, 200)
        dbSales.MultiSelect = False
        dbSales.Name = "dbSales"
        dbSales.ReadOnly = True
        dbSales.RowHeadersVisible = False
        dbSales.RowHeadersWidth = 62
        dbSales.SelectionMode = DataGridViewSelectionMode.FullRowSelect
        dbSales.Size = New Size(1769, 629)
        dbSales.TabIndex = 4
        ' 
        ' SaleRep
        ' 
        AutoScaleDimensions = New SizeF(10F, 25F)
        AutoScaleMode = AutoScaleMode.Font
        ClientSize = New Size(1893, 934)
        Controls.Add(dbSales)
        Controls.Add(Panel4)
        Controls.Add(Panel3)
        Controls.Add(Panel2)
        Controls.Add(Panel1)
        FormBorderStyle = FormBorderStyle.None
        Name = "SaleRep"
        Text = "User"
        WindowState = FormWindowState.Maximized
        Panel1.ResumeLayout(False)
        Panel1.PerformLayout()
        CType(PictureBox3, ComponentModel.ISupportInitialize).EndInit()
        Panel5.ResumeLayout(False)
        Panel5.PerformLayout()
        Panel2.ResumeLayout(False)
        Panel2.PerformLayout()
        CType(dbSales, ComponentModel.ISupportInitialize).EndInit()
        ResumeLayout(False)
    End Sub

    Friend WithEvents Panel1 As Panel
    Friend WithEvents Panel2 As Panel
    Friend WithEvents Panel3 As Panel
    Friend WithEvents btnClose As Button
    Friend WithEvents Panel4 As Panel
    Friend WithEvents dbSales As DataGridView
    Friend WithEvents btnPrint As Button
    Friend WithEvents dtTo As DateTimePicker
    Friend WithEvents dtFrom As DateTimePicker
    Friend WithEvents Label1 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents lblTotalS As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents Panel5 As Panel
    Friend WithEvents Label4 As Label
    Friend WithEvents PictureBox3 As PictureBox
    Friend WithEvents Label5 As Label
End Class
