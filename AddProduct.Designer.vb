<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class AddProduct
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
        txtPrCode = New TextBox()
        Panel2 = New Panel()
        Panel3 = New Panel()
        txtDscrpt = New TextBox()
        Panel4 = New Panel()
        txtPrName = New TextBox()
        Panel5 = New Panel()
        txtQuant = New TextBox()
        Panel6 = New Panel()
        cmbCat = New ComboBox()
        Panel7 = New Panel()
        txtPrPrice = New TextBox()
        Label1 = New Label()
        Label2 = New Label()
        Label3 = New Label()
        Label5 = New Label()
        Label6 = New Label()
        dtExp = New DateTimePicker()
        Panel8 = New Panel()
        Label7 = New Label()
        btnCancelProducts = New Button()
        btnSavePr = New Button()
        btnPrUpdate = New Button()
        Panel1 = New Panel()
        cmbUnt = New ComboBox()
        Label8 = New Label()
        Panel9 = New Panel()
        txtPPrice = New TextBox()
        Label9 = New Label()
        Panel2.SuspendLayout()
        Panel3.SuspendLayout()
        Panel4.SuspendLayout()
        Panel5.SuspendLayout()
        Panel6.SuspendLayout()
        Panel7.SuspendLayout()
        Panel8.SuspendLayout()
        Panel1.SuspendLayout()
        Panel9.SuspendLayout()
        SuspendLayout()
        ' 
        ' txtPrCode
        ' 
        txtPrCode.BorderStyle = BorderStyle.None
        txtPrCode.Location = New Point(14, 15)
        txtPrCode.Name = "txtPrCode"
        txtPrCode.Size = New Size(347, 24)
        txtPrCode.TabIndex = 2
        ' 
        ' Panel2
        ' 
        Panel2.BackColor = SystemColors.Window
        Panel2.Controls.Add(txtPrCode)
        Panel2.Location = New Point(188, 51)
        Panel2.Name = "Panel2"
        Panel2.Size = New Size(375, 53)
        Panel2.TabIndex = 3
        ' 
        ' Panel3
        ' 
        Panel3.BackColor = SystemColors.Window
        Panel3.Controls.Add(txtDscrpt)
        Panel3.Location = New Point(188, 196)
        Panel3.Name = "Panel3"
        Panel3.Size = New Size(375, 196)
        Panel3.TabIndex = 3
        ' 
        ' txtDscrpt
        ' 
        txtDscrpt.BorderStyle = BorderStyle.None
        txtDscrpt.Location = New Point(14, 20)
        txtDscrpt.Multiline = True
        txtDscrpt.Name = "txtDscrpt"
        txtDscrpt.Size = New Size(347, 156)
        txtDscrpt.TabIndex = 2
        ' 
        ' Panel4
        ' 
        Panel4.BackColor = SystemColors.Window
        Panel4.Controls.Add(txtPrName)
        Panel4.Location = New Point(188, 123)
        Panel4.Name = "Panel4"
        Panel4.Size = New Size(375, 53)
        Panel4.TabIndex = 3
        ' 
        ' txtPrName
        ' 
        txtPrName.BorderStyle = BorderStyle.None
        txtPrName.Location = New Point(14, 15)
        txtPrName.Name = "txtPrName"
        txtPrName.Size = New Size(347, 24)
        txtPrName.TabIndex = 2
        ' 
        ' Panel5
        ' 
        Panel5.BackColor = SystemColors.Control
        Panel5.Controls.Add(txtQuant)
        Panel5.Location = New Point(188, 413)
        Panel5.Name = "Panel5"
        Panel5.Size = New Size(375, 53)
        Panel5.TabIndex = 3
        Panel5.Visible = False
        ' 
        ' txtQuant
        ' 
        txtQuant.BorderStyle = BorderStyle.None
        txtQuant.Location = New Point(14, 15)
        txtQuant.Name = "txtQuant"
        txtQuant.ReadOnly = True
        txtQuant.Size = New Size(347, 24)
        txtQuant.TabIndex = 2
        ' 
        ' Panel6
        ' 
        Panel6.BackColor = SystemColors.Window
        Panel6.Controls.Add(cmbCat)
        Panel6.Location = New Point(188, 543)
        Panel6.Name = "Panel6"
        Panel6.Size = New Size(375, 53)
        Panel6.TabIndex = 3
        ' 
        ' cmbCat
        ' 
        cmbCat.DropDownStyle = ComboBoxStyle.DropDownList
        cmbCat.FormattingEnabled = True
        cmbCat.Items.AddRange(New Object() {"Medicine", "Medicine(for Dental)", "Medical Supply", "Medical Supply(for Dental)"})
        cmbCat.Location = New Point(14, 11)
        cmbCat.Name = "cmbCat"
        cmbCat.Size = New Size(347, 33)
        cmbCat.TabIndex = 4
        ' 
        ' Panel7
        ' 
        Panel7.BackColor = SystemColors.Window
        Panel7.Controls.Add(txtPrPrice)
        Panel7.Location = New Point(188, 611)
        Panel7.Name = "Panel7"
        Panel7.Size = New Size(375, 53)
        Panel7.TabIndex = 3
        ' 
        ' txtPrPrice
        ' 
        txtPrPrice.BorderStyle = BorderStyle.None
        txtPrPrice.Location = New Point(14, 15)
        txtPrPrice.Name = "txtPrPrice"
        txtPrPrice.Size = New Size(347, 24)
        txtPrPrice.TabIndex = 2
        ' 
        ' Label1
        ' 
        Label1.AutoSize = True
        Label1.Font = New Font("Century Gothic", 10F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        Label1.Location = New Point(33, 66)
        Label1.Name = "Label1"
        Label1.Size = New Size(149, 23)
        Label1.TabIndex = 4
        Label1.Text = "Product Code"
        ' 
        ' Label2
        ' 
        Label2.AutoSize = True
        Label2.Font = New Font("Century Gothic", 10F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        Label2.Location = New Point(28, 139)
        Label2.Name = "Label2"
        Label2.Size = New Size(154, 23)
        Label2.TabIndex = 4
        Label2.Text = "Product Name"
        ' 
        ' Label3
        ' 
        Label3.AutoSize = True
        Label3.Font = New Font("Century Gothic", 10F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        Label3.Location = New Point(65, 206)
        Label3.Name = "Label3"
        Label3.Size = New Size(117, 23)
        Label3.TabIndex = 4
        Label3.Text = "Description"
        ' 
        ' Label5
        ' 
        Label5.AutoSize = True
        Label5.Font = New Font("Century Gothic", 10F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        Label5.Location = New Point(79, 560)
        Label5.Name = "Label5"
        Label5.Size = New Size(103, 23)
        Label5.TabIndex = 4
        Label5.Text = "Category"
        ' 
        ' Label6
        ' 
        Label6.AutoSize = True
        Label6.Font = New Font("Century Gothic", 10F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        Label6.Location = New Point(58, 626)
        Label6.Name = "Label6"
        Label6.Size = New Size(124, 23)
        Label6.TabIndex = 4
        Label6.Text = "Selling Price"
        ' 
        ' dtExp
        ' 
        dtExp.Location = New Point(14, 11)
        dtExp.Name = "dtExp"
        dtExp.Size = New Size(347, 31)
        dtExp.TabIndex = 5
        ' 
        ' Panel8
        ' 
        Panel8.BackColor = SystemColors.Window
        Panel8.Controls.Add(dtExp)
        Panel8.Location = New Point(188, 751)
        Panel8.Name = "Panel8"
        Panel8.Size = New Size(375, 53)
        Panel8.TabIndex = 3
        ' 
        ' Label7
        ' 
        Label7.AutoSize = True
        Label7.Font = New Font("Century Gothic", 10F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        Label7.Location = New Point(62, 767)
        Label7.Name = "Label7"
        Label7.Size = New Size(120, 23)
        Label7.TabIndex = 4
        Label7.Text = "Expiry Date"
        ' 
        ' btnCancelProducts
        ' 
        btnCancelProducts.BackColor = Color.Firebrick
        btnCancelProducts.FlatAppearance.BorderColor = Color.Silver
        btnCancelProducts.FlatStyle = FlatStyle.Flat
        btnCancelProducts.Font = New Font("Century Gothic", 9F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        btnCancelProducts.ForeColor = SystemColors.ControlLightLight
        btnCancelProducts.Location = New Point(438, 835)
        btnCancelProducts.Margin = New Padding(0)
        btnCancelProducts.Name = "btnCancelProducts"
        btnCancelProducts.Size = New Size(125, 42)
        btnCancelProducts.TabIndex = 5
        btnCancelProducts.Text = "Cancel"
        btnCancelProducts.UseVisualStyleBackColor = False
        ' 
        ' btnSavePr
        ' 
        btnSavePr.BackColor = Color.CadetBlue
        btnSavePr.FlatAppearance.BorderColor = Color.Silver
        btnSavePr.FlatStyle = FlatStyle.Flat
        btnSavePr.Font = New Font("Century Gothic", 9F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        btnSavePr.ForeColor = SystemColors.ControlLightLight
        btnSavePr.Location = New Point(303, 835)
        btnSavePr.Margin = New Padding(0)
        btnSavePr.Name = "btnSavePr"
        btnSavePr.Size = New Size(125, 42)
        btnSavePr.TabIndex = 5
        btnSavePr.Text = "Save"
        btnSavePr.UseVisualStyleBackColor = False
        ' 
        ' btnPrUpdate
        ' 
        btnPrUpdate.BackColor = Color.MediumSeaGreen
        btnPrUpdate.FlatAppearance.BorderColor = Color.FromArgb(CByte(224), CByte(224), CByte(224))
        btnPrUpdate.FlatStyle = FlatStyle.Flat
        btnPrUpdate.Font = New Font("Century Gothic", 9F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        btnPrUpdate.ForeColor = SystemColors.ControlLightLight
        btnPrUpdate.Location = New Point(303, 835)
        btnPrUpdate.Name = "btnPrUpdate"
        btnPrUpdate.Size = New Size(125, 42)
        btnPrUpdate.TabIndex = 6
        btnPrUpdate.Text = "Update"
        btnPrUpdate.UseVisualStyleBackColor = False
        btnPrUpdate.Visible = False
        ' 
        ' Panel1
        ' 
        Panel1.BackColor = SystemColors.Window
        Panel1.Controls.Add(cmbUnt)
        Panel1.Location = New Point(189, 477)
        Panel1.Name = "Panel1"
        Panel1.Size = New Size(375, 53)
        Panel1.TabIndex = 3
        ' 
        ' cmbUnt
        ' 
        cmbUnt.DropDownStyle = ComboBoxStyle.DropDownList
        cmbUnt.FormattingEnabled = True
        cmbUnt.Items.AddRange(New Object() {"Medicine", "Medicine(for Dental)", "Medical Supply", "Medical Supply(for Dental)"})
        cmbUnt.Location = New Point(14, 11)
        cmbUnt.Name = "cmbUnt"
        cmbUnt.Size = New Size(347, 33)
        cmbUnt.TabIndex = 4
        ' 
        ' Label8
        ' 
        Label8.AutoSize = True
        Label8.Font = New Font("Century Gothic", 10F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        Label8.Location = New Point(138, 494)
        Label8.Name = "Label8"
        Label8.Size = New Size(45, 23)
        Label8.TabIndex = 4
        Label8.Text = "Unit"
        ' 
        ' Panel9
        ' 
        Panel9.BackColor = SystemColors.Window
        Panel9.Controls.Add(txtPPrice)
        Panel9.Location = New Point(189, 681)
        Panel9.Name = "Panel9"
        Panel9.Size = New Size(375, 53)
        Panel9.TabIndex = 3
        ' 
        ' txtPPrice
        ' 
        txtPPrice.BorderStyle = BorderStyle.None
        txtPPrice.Location = New Point(14, 15)
        txtPPrice.Name = "txtPPrice"
        txtPPrice.Size = New Size(347, 24)
        txtPPrice.TabIndex = 2
        ' 
        ' Label9
        ' 
        Label9.AutoSize = True
        Label9.Font = New Font("Century Gothic", 10F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        Label9.Location = New Point(30, 696)
        Label9.Name = "Label9"
        Label9.Size = New Size(153, 23)
        Label9.TabIndex = 4
        Label9.Text = "Purchase Price"
        ' 
        ' AddProduct
        ' 
        AutoScaleDimensions = New SizeF(10F, 25F)
        AutoScaleMode = AutoScaleMode.Font
        BackColor = Color.LightSteelBlue
        ClientSize = New Size(576, 934)
        Controls.Add(btnPrUpdate)
        Controls.Add(btnSavePr)
        Controls.Add(btnCancelProducts)
        Controls.Add(Label7)
        Controls.Add(Label8)
        Controls.Add(Label9)
        Controls.Add(Label6)
        Controls.Add(Label5)
        Controls.Add(Label3)
        Controls.Add(Label2)
        Controls.Add(Label1)
        Controls.Add(Panel3)
        Controls.Add(Panel1)
        Controls.Add(Panel6)
        Controls.Add(Panel8)
        Controls.Add(Panel9)
        Controls.Add(Panel7)
        Controls.Add(Panel5)
        Controls.Add(Panel4)
        Controls.Add(Panel2)
        FormBorderStyle = FormBorderStyle.FixedDialog
        MaximizeBox = False
        MinimizeBox = False
        Name = "AddProduct"
        StartPosition = FormStartPosition.CenterScreen
        Text = "User"
        Panel2.ResumeLayout(False)
        Panel2.PerformLayout()
        Panel3.ResumeLayout(False)
        Panel3.PerformLayout()
        Panel4.ResumeLayout(False)
        Panel4.PerformLayout()
        Panel5.ResumeLayout(False)
        Panel5.PerformLayout()
        Panel6.ResumeLayout(False)
        Panel7.ResumeLayout(False)
        Panel7.PerformLayout()
        Panel8.ResumeLayout(False)
        Panel1.ResumeLayout(False)
        Panel9.ResumeLayout(False)
        Panel9.PerformLayout()
        ResumeLayout(False)
        PerformLayout()
    End Sub
    Friend WithEvents txtPrCode As TextBox
    Friend WithEvents Panel2 As Panel
    Friend WithEvents Panel3 As Panel
    Friend WithEvents txtDscrpt As TextBox
    Friend WithEvents Panel4 As Panel
    Friend WithEvents txtPrName As TextBox
    Friend WithEvents Panel5 As Panel
    Friend WithEvents txtQuant As TextBox
    Friend WithEvents Panel6 As Panel
    Friend WithEvents cmbCat As ComboBox
    Friend WithEvents Panel7 As Panel
    Friend WithEvents txtPrPrice As TextBox
    Friend WithEvents Label1 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents Label5 As Label
    Friend WithEvents Label6 As Label
    Friend WithEvents dtExp As DateTimePicker
    Friend WithEvents Panel8 As Panel
    Friend WithEvents Label7 As Label
    Friend WithEvents btnCancelProducts As Button
    Friend WithEvents btnSavePr As Button
    Friend WithEvents btnPrUpdate As Button
    Friend WithEvents Panel1 As Panel
    Friend WithEvents cmbUnt As ComboBox
    Friend WithEvents Label8 As Label
    Friend WithEvents Panel9 As Panel
    Friend WithEvents txtPPrice As TextBox
    Friend WithEvents Label9 As Label
End Class
