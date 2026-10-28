<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class POSmain
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
        lblTime = New Label()
        lblDate = New Label()
        Label8 = New Label()
        PictureBox2 = New PictureBox()
        lblTransactionNo = New Label()
        Label5 = New Label()
        lblChange = New Label()
        lblCash = New Label()
        lblVTotal = New Label()
        lblTotal = New Label()
        txtBarcode = New TextBox()
        Label4 = New Label()
        Label3 = New Label()
        Label1 = New Label()
        Label6 = New Label()
        Label2 = New Label()
        Panel2 = New Panel()
        btnSave = New Button()
        btnPedro = New Button()
        btnVoid = New Button()
        btnHist = New Button()
        btnTransact = New Button()
        btnEdit = New Button()
        btnSettle = New Button()
        btnClose = New Button()
        Panel3 = New Panel()
        Panel4 = New Panel()
        dbPOS = New DataGridView()
        postime = New Timer(components)
        Panel1.SuspendLayout()
        CType(PictureBox2, ComponentModel.ISupportInitialize).BeginInit()
        Panel2.SuspendLayout()
        CType(dbPOS, ComponentModel.ISupportInitialize).BeginInit()
        SuspendLayout()
        ' 
        ' Panel1
        ' 
        Panel1.BackColor = Color.LightSlateGray
        Panel1.Controls.Add(lblTime)
        Panel1.Controls.Add(lblDate)
        Panel1.Controls.Add(Label8)
        Panel1.Controls.Add(PictureBox2)
        Panel1.Controls.Add(lblTransactionNo)
        Panel1.Controls.Add(Label5)
        Panel1.Controls.Add(lblChange)
        Panel1.Controls.Add(lblCash)
        Panel1.Controls.Add(lblVTotal)
        Panel1.Controls.Add(lblTotal)
        Panel1.Controls.Add(txtBarcode)
        Panel1.Controls.Add(Label4)
        Panel1.Controls.Add(Label3)
        Panel1.Controls.Add(Label1)
        Panel1.Controls.Add(Label6)
        Panel1.Controls.Add(Label2)
        Panel1.Dock = DockStyle.Top
        Panel1.Location = New Point(0, 0)
        Panel1.Name = "Panel1"
        Panel1.Size = New Size(1850, 180)
        Panel1.TabIndex = 0
        ' 
        ' lblTime
        ' 
        lblTime.AutoSize = True
        lblTime.BackColor = Color.Transparent
        lblTime.FlatStyle = FlatStyle.Flat
        lblTime.Font = New Font("Century Gothic", 16F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        lblTime.ForeColor = Color.White
        lblTime.Location = New Point(1591, 75)
        lblTime.Name = "lblTime"
        lblTime.Size = New Size(119, 38)
        lblTime.TabIndex = 14
        lblTime.Text = "Label3"
        ' 
        ' lblDate
        ' 
        lblDate.AutoSize = True
        lblDate.BackColor = Color.Transparent
        lblDate.FlatStyle = FlatStyle.Flat
        lblDate.Font = New Font("Century Gothic", 16F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        lblDate.ForeColor = Color.White
        lblDate.Location = New Point(1591, 27)
        lblDate.Name = "lblDate"
        lblDate.Size = New Size(119, 38)
        lblDate.TabIndex = 12
        lblDate.Text = "Label3"
        ' 
        ' Label8
        ' 
        Label8.AutoSize = True
        Label8.Font = New Font("Century Gothic", 14F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        Label8.ForeColor = SystemColors.HighlightText
        Label8.Location = New Point(126, 27)
        Label8.Name = "Label8"
        Label8.Size = New Size(184, 34)
        Label8.TabIndex = 11
        Label8.Text = "Point of Sale"
        ' 
        ' PictureBox2
        ' 
        PictureBox2.Image = My.Resources.Resources.silver_membership_icon_default_avatar_profile_icon_membership_icon_social_media_user_image_illustration_vector
        PictureBox2.Location = New Point(60, 13)
        PictureBox2.Name = "PictureBox2"
        PictureBox2.Size = New Size(60, 60)
        PictureBox2.SizeMode = PictureBoxSizeMode.StretchImage
        PictureBox2.TabIndex = 8
        PictureBox2.TabStop = False
        ' 
        ' lblTransactionNo
        ' 
        lblTransactionNo.AutoSize = True
        lblTransactionNo.Font = New Font("Century Gothic", 10F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        lblTransactionNo.ForeColor = SystemColors.HighlightText
        lblTransactionNo.Location = New Point(787, 94)
        lblTransactionNo.Name = "lblTransactionNo"
        lblTransactionNo.Size = New Size(21, 23)
        lblTransactionNo.TabIndex = 7
        lblTransactionNo.Text = "0"
        ' 
        ' Label5
        ' 
        Label5.AutoSize = True
        Label5.Font = New Font("Century Gothic", 10F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        Label5.ForeColor = SystemColors.HighlightText
        Label5.Location = New Point(581, 94)
        Label5.Name = "Label5"
        Label5.Size = New Size(210, 23)
        Label5.TabIndex = 7
        Label5.Text = "Transaction Number:"
        ' 
        ' lblChange
        ' 
        lblChange.AutoSize = True
        lblChange.Font = New Font("Century Gothic", 14F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        lblChange.ForeColor = SystemColors.HighlightText
        lblChange.Location = New Point(473, 129)
        lblChange.Name = "lblChange"
        lblChange.Size = New Size(89, 34)
        lblChange.TabIndex = 6
        lblChange.Text = "₱0.00" & vbLf
        ' 
        ' lblCash
        ' 
        lblCash.AutoSize = True
        lblCash.Font = New Font("Century Gothic", 14F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        lblCash.ForeColor = SystemColors.HighlightText
        lblCash.Location = New Point(148, 129)
        lblCash.Name = "lblCash"
        lblCash.Size = New Size(89, 34)
        lblCash.TabIndex = 6
        lblCash.Text = "₱0.00" & vbLf
        ' 
        ' lblVTotal
        ' 
        lblVTotal.AutoSize = True
        lblVTotal.Font = New Font("Century Gothic", 14F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        lblVTotal.ForeColor = SystemColors.HighlightText
        lblVTotal.Location = New Point(1246, 130)
        lblVTotal.Name = "lblVTotal"
        lblVTotal.Size = New Size(91, 34)
        lblVTotal.TabIndex = 6
        lblVTotal.Text = "₱0.00" & vbLf
        ' 
        ' lblTotal
        ' 
        lblTotal.AutoSize = True
        lblTotal.Font = New Font("Century Gothic", 14F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        lblTotal.ForeColor = SystemColors.HighlightText
        lblTotal.Location = New Point(918, 130)
        lblTotal.Name = "lblTotal"
        lblTotal.Size = New Size(91, 34)
        lblTotal.TabIndex = 6
        lblTotal.Text = "₱0.00" & vbLf
        ' 
        ' txtBarcode
        ' 
        txtBarcode.BorderStyle = BorderStyle.None
        txtBarcode.Location = New Point(159, 94)
        txtBarcode.Name = "txtBarcode"
        txtBarcode.Size = New Size(335, 24)
        txtBarcode.TabIndex = 5
        ' 
        ' Label4
        ' 
        Label4.AutoSize = True
        Label4.Font = New Font("Century Gothic", 10F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        Label4.ForeColor = SystemColors.HighlightText
        Label4.Location = New Point(60, 94)
        Label4.Name = "Label4"
        Label4.Size = New Size(99, 23)
        Label4.TabIndex = 4
        Label4.Text = "Barcode:"
        ' 
        ' Label3
        ' 
        Label3.AutoSize = True
        Label3.Font = New Font("Century Gothic", 14F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        Label3.ForeColor = SystemColors.HighlightText
        Label3.Location = New Point(344, 129)
        Label3.Name = "Label3"
        Label3.Size = New Size(135, 34)
        Label3.TabIndex = 3
        Label3.Text = "Change:"
        ' 
        ' Label1
        ' 
        Label1.AutoSize = True
        Label1.Font = New Font("Century Gothic", 14F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        Label1.ForeColor = SystemColors.HighlightText
        Label1.Location = New Point(60, 129)
        Label1.Name = "Label1"
        Label1.Size = New Size(92, 34)
        Label1.TabIndex = 3
        Label1.Text = "Cash:"
        ' 
        ' Label6
        ' 
        Label6.AutoSize = True
        Label6.Font = New Font("Century Gothic", 14F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        Label6.ForeColor = SystemColors.HighlightText
        Label6.Location = New Point(1093, 130)
        Label6.Name = "Label6"
        Label6.Size = New Size(147, 34)
        Label6.TabIndex = 3
        Label6.Text = "VAT Total:"
        ' 
        ' Label2
        ' 
        Label2.AutoSize = True
        Label2.Font = New Font("Century Gothic", 14F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        Label2.ForeColor = SystemColors.HighlightText
        Label2.Location = New Point(740, 130)
        Label2.Name = "Label2"
        Label2.Size = New Size(178, 34)
        Label2.TabIndex = 3
        Label2.Text = "Total to Pay:"
        ' 
        ' Panel2
        ' 
        Panel2.BackColor = Color.LightSlateGray
        Panel2.Controls.Add(btnSave)
        Panel2.Controls.Add(btnPedro)
        Panel2.Controls.Add(btnVoid)
        Panel2.Controls.Add(btnHist)
        Panel2.Controls.Add(btnTransact)
        Panel2.Controls.Add(btnEdit)
        Panel2.Controls.Add(btnSettle)
        Panel2.Controls.Add(btnClose)
        Panel2.Dock = DockStyle.Bottom
        Panel2.Location = New Point(0, 744)
        Panel2.Name = "Panel2"
        Panel2.Size = New Size(1850, 190)
        Panel2.TabIndex = 1
        ' 
        ' btnSave
        ' 
        btnSave.BackColor = Color.MediumSeaGreen
        btnSave.FlatAppearance.BorderColor = Color.Silver
        btnSave.FlatAppearance.BorderSize = 3
        btnSave.FlatStyle = FlatStyle.Flat
        btnSave.Font = New Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        btnSave.ForeColor = SystemColors.ControlLightLight
        btnSave.Location = New Point(949, 48)
        btnSave.Name = "btnSave"
        btnSave.Size = New Size(112, 103)
        btnSave.TabIndex = 0
        btnSave.Text = "Save (F7)"
        btnSave.UseVisualStyleBackColor = False
        ' 
        ' btnPedro
        ' 
        btnPedro.BackColor = Color.Teal
        btnPedro.FlatAppearance.BorderColor = Color.Silver
        btnPedro.FlatAppearance.BorderSize = 3
        btnPedro.FlatStyle = FlatStyle.Flat
        btnPedro.Font = New Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        btnPedro.ForeColor = SystemColors.ControlLightLight
        btnPedro.Location = New Point(713, 50)
        btnPedro.Name = "btnPedro"
        btnPedro.Size = New Size(112, 103)
        btnPedro.TabIndex = 0
        btnPedro.Text = "Pending (F6)"
        btnPedro.UseVisualStyleBackColor = False
        ' 
        ' btnVoid
        ' 
        btnVoid.BackColor = Color.DimGray
        btnVoid.FlatAppearance.BorderColor = Color.Silver
        btnVoid.FlatAppearance.BorderSize = 3
        btnVoid.FlatStyle = FlatStyle.Flat
        btnVoid.Font = New Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        btnVoid.ForeColor = SystemColors.ControlLightLight
        btnVoid.Location = New Point(581, 49)
        btnVoid.Name = "btnVoid"
        btnVoid.Size = New Size(112, 103)
        btnVoid.TabIndex = 0
        btnVoid.Text = "Void (F5)"
        btnVoid.UseVisualStyleBackColor = False
        ' 
        ' btnHist
        ' 
        btnHist.BackColor = Color.SteelBlue
        btnHist.FlatAppearance.BorderColor = Color.Silver
        btnHist.FlatAppearance.BorderSize = 3
        btnHist.FlatStyle = FlatStyle.Flat
        btnHist.Font = New Font("Segoe UI", 8F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        btnHist.ForeColor = SystemColors.ControlLightLight
        btnHist.Location = New Point(450, 49)
        btnHist.Name = "btnHist"
        btnHist.Size = New Size(112, 103)
        btnHist.TabIndex = 0
        btnHist.Text = "Transaction History (F4)"
        btnHist.UseVisualStyleBackColor = False
        ' 
        ' btnTransact
        ' 
        btnTransact.BackColor = Color.CadetBlue
        btnTransact.FlatAppearance.BorderColor = Color.Silver
        btnTransact.FlatAppearance.BorderSize = 3
        btnTransact.FlatStyle = FlatStyle.Flat
        btnTransact.Font = New Font("Segoe UI", 8F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        btnTransact.ForeColor = SystemColors.ControlLightLight
        btnTransact.Location = New Point(320, 49)
        btnTransact.Name = "btnTransact"
        btnTransact.Size = New Size(112, 103)
        btnTransact.TabIndex = 0
        btnTransact.Text = "New Transaction (F3)"
        btnTransact.UseVisualStyleBackColor = False
        ' 
        ' btnEdit
        ' 
        btnEdit.BackColor = Color.DarkSeaGreen
        btnEdit.FlatAppearance.BorderColor = Color.Silver
        btnEdit.FlatAppearance.BorderSize = 3
        btnEdit.FlatStyle = FlatStyle.Flat
        btnEdit.Font = New Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        btnEdit.ForeColor = SystemColors.ControlLightLight
        btnEdit.Location = New Point(191, 49)
        btnEdit.Name = "btnEdit"
        btnEdit.Size = New Size(112, 103)
        btnEdit.TabIndex = 0
        btnEdit.Text = "Enter Quantity (F2)"
        btnEdit.UseVisualStyleBackColor = False
        ' 
        ' btnSettle
        ' 
        btnSettle.BackColor = Color.DarkSeaGreen
        btnSettle.FlatAppearance.BorderColor = Color.Silver
        btnSettle.FlatAppearance.BorderSize = 3
        btnSettle.FlatStyle = FlatStyle.Flat
        btnSettle.Font = New Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        btnSettle.ForeColor = SystemColors.ControlLightLight
        btnSettle.Location = New Point(60, 49)
        btnSettle.Name = "btnSettle"
        btnSettle.Size = New Size(112, 103)
        btnSettle.TabIndex = 0
        btnSettle.Text = "Settle Payment (F1)"
        btnSettle.UseVisualStyleBackColor = False
        ' 
        ' btnClose
        ' 
        btnClose.BackColor = Color.Firebrick
        btnClose.FlatAppearance.BorderColor = Color.Silver
        btnClose.FlatAppearance.BorderSize = 3
        btnClose.FlatStyle = FlatStyle.Flat
        btnClose.Font = New Font("Segoe UI", 10F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        btnClose.ForeColor = SystemColors.ControlLightLight
        btnClose.Location = New Point(1506, 49)
        btnClose.Name = "btnClose"
        btnClose.Size = New Size(112, 103)
        btnClose.TabIndex = 0
        btnClose.Text = "Close (F8)"
        btnClose.UseVisualStyleBackColor = False
        ' 
        ' Panel3
        ' 
        Panel3.BackColor = Color.LightSlateGray
        Panel3.Dock = DockStyle.Left
        Panel3.Location = New Point(0, 180)
        Panel3.Name = "Panel3"
        Panel3.Size = New Size(60, 564)
        Panel3.TabIndex = 2
        ' 
        ' Panel4
        ' 
        Panel4.BackColor = Color.LightSlateGray
        Panel4.Dock = DockStyle.Right
        Panel4.Location = New Point(1790, 180)
        Panel4.Name = "Panel4"
        Panel4.Size = New Size(60, 564)
        Panel4.TabIndex = 3
        ' 
        ' dbPOS
        ' 
        dbPOS.AllowUserToAddRows = False
        dbPOS.AllowUserToDeleteRows = False
        dbPOS.AllowUserToResizeColumns = False
        dbPOS.AllowUserToResizeRows = False
        dbPOS.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
        dbPOS.BackgroundColor = Color.LightSteelBlue
        dbPOS.BorderStyle = BorderStyle.None
        dbPOS.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal
        dbPOS.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single
        DataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle1.BackColor = Color.LightSlateGray
        DataGridViewCellStyle1.Font = New Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        DataGridViewCellStyle1.ForeColor = SystemColors.HighlightText
        DataGridViewCellStyle1.SelectionBackColor = Color.SlateGray
        DataGridViewCellStyle1.SelectionForeColor = SystemColors.HighlightText
        DataGridViewCellStyle1.WrapMode = DataGridViewTriState.True
        dbPOS.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        dbPOS.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = SystemColors.Window
        DataGridViewCellStyle2.Font = New Font("Century Gothic", 9F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        DataGridViewCellStyle2.ForeColor = SystemColors.ControlText
        DataGridViewCellStyle2.SelectionBackColor = Color.LightGray
        DataGridViewCellStyle2.SelectionForeColor = Color.Black
        DataGridViewCellStyle2.WrapMode = DataGridViewTriState.False
        dbPOS.DefaultCellStyle = DataGridViewCellStyle2
        dbPOS.Dock = DockStyle.Fill
        dbPOS.EnableHeadersVisualStyles = False
        dbPOS.GridColor = Color.Gainsboro
        dbPOS.Location = New Point(60, 180)
        dbPOS.MultiSelect = False
        dbPOS.Name = "dbPOS"
        dbPOS.ReadOnly = True
        dbPOS.RowHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single
        dbPOS.RowHeadersVisible = False
        dbPOS.RowHeadersWidth = 62
        dbPOS.SelectionMode = DataGridViewSelectionMode.FullRowSelect
        dbPOS.Size = New Size(1730, 564)
        dbPOS.TabIndex = 4
        ' 
        ' postime
        ' 
        postime.Enabled = True
        postime.Interval = 1000
        ' 
        ' POSmain
        ' 
        AutoScaleDimensions = New SizeF(10F, 25F)
        AutoScaleMode = AutoScaleMode.Font
        ClientSize = New Size(1850, 934)
        Controls.Add(dbPOS)
        Controls.Add(Panel4)
        Controls.Add(Panel3)
        Controls.Add(Panel2)
        Controls.Add(Panel1)
        FormBorderStyle = FormBorderStyle.None
        Name = "POSmain"
        Text = "User"
        WindowState = FormWindowState.Maximized
        Panel1.ResumeLayout(False)
        Panel1.PerformLayout()
        CType(PictureBox2, ComponentModel.ISupportInitialize).EndInit()
        Panel2.ResumeLayout(False)
        CType(dbPOS, ComponentModel.ISupportInitialize).EndInit()
        ResumeLayout(False)
    End Sub

    Friend WithEvents Panel1 As Panel
    Friend WithEvents Panel2 As Panel
    Friend WithEvents btnClose As Button
    Friend WithEvents Panel3 As Panel
    Friend WithEvents Panel4 As Panel
    Friend WithEvents dbPOS As DataGridView
    Friend WithEvents Label3 As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents btnSettle As Button
    Friend WithEvents btnEdit As Button
    Friend WithEvents txtBarcode As TextBox
    Friend WithEvents Label4 As Label
    Friend WithEvents lblTotal As Label
    Friend WithEvents lblChange As Label
    Friend WithEvents lblCash As Label
    Friend WithEvents btnSave As Button
    Friend WithEvents btnVoid As Button
    Friend WithEvents btnHist As Button
    Friend WithEvents btnTransact As Button
    Friend WithEvents btnPedro As Button
    Friend WithEvents Label5 As Label
    Friend WithEvents lblTransactionNo As Label
    Friend WithEvents PictureBox2 As PictureBox
    Friend WithEvents Label8 As Label
    Friend WithEvents lblTime As Label
    Friend WithEvents lblDate As Label
    Friend WithEvents postime As Timer
    Friend WithEvents lblVTotal As Label
    Friend WithEvents Label6 As Label
End Class
