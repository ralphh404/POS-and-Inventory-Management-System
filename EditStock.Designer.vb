<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class EditStock
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
        Panel1 = New Panel()
        txtEQuant = New TextBox()
        Panel2 = New Panel()
        txtEProduct = New TextBox()
        Label1 = New Label()
        Label2 = New Label()
        Panel3 = New Panel()
        cmbSupp = New ComboBox()
        Label3 = New Label()
        btnUpdateES = New Button()
        btnCancel = New Button()
        Panel1.SuspendLayout()
        Panel2.SuspendLayout()
        Panel3.SuspendLayout()
        SuspendLayout()
        ' 
        ' Panel1
        ' 
        Panel1.BackColor = SystemColors.Window
        Panel1.Controls.Add(txtEQuant)
        Panel1.Location = New Point(30, 144)
        Panel1.Name = "Panel1"
        Panel1.Size = New Size(309, 48)
        Panel1.TabIndex = 2
        ' 
        ' txtEQuant
        ' 
        txtEQuant.BorderStyle = BorderStyle.None
        txtEQuant.Location = New Point(11, 12)
        txtEQuant.Name = "txtEQuant"
        txtEQuant.Size = New Size(288, 24)
        txtEQuant.TabIndex = 0
        ' 
        ' Panel2
        ' 
        Panel2.BackColor = SystemColors.Control
        Panel2.Controls.Add(txtEProduct)
        Panel2.Location = New Point(30, 54)
        Panel2.Name = "Panel2"
        Panel2.Size = New Size(309, 48)
        Panel2.TabIndex = 2
        ' 
        ' txtEProduct
        ' 
        txtEProduct.BorderStyle = BorderStyle.None
        txtEProduct.Location = New Point(11, 12)
        txtEProduct.Name = "txtEProduct"
        txtEProduct.ReadOnly = True
        txtEProduct.Size = New Size(288, 24)
        txtEProduct.TabIndex = 0
        ' 
        ' Label1
        ' 
        Label1.AutoSize = True
        Label1.Font = New Font("Century Gothic", 10F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        Label1.Location = New Point(30, 118)
        Label1.Name = "Label1"
        Label1.Size = New Size(93, 23)
        Label1.TabIndex = 3
        Label1.Text = "Quantity"
        ' 
        ' Label2
        ' 
        Label2.AutoSize = True
        Label2.Font = New Font("Century Gothic", 10F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        Label2.Location = New Point(30, 28)
        Label2.Name = "Label2"
        Label2.Size = New Size(154, 23)
        Label2.TabIndex = 3
        Label2.Text = "Product Name"
        ' 
        ' Panel3
        ' 
        Panel3.BackColor = SystemColors.Window
        Panel3.Controls.Add(cmbSupp)
        Panel3.Location = New Point(30, 240)
        Panel3.Name = "Panel3"
        Panel3.Size = New Size(309, 48)
        Panel3.TabIndex = 2
        ' 
        ' cmbSupp
        ' 
        cmbSupp.DropDownStyle = ComboBoxStyle.DropDownList
        cmbSupp.FormattingEnabled = True
        cmbSupp.Location = New Point(11, 7)
        cmbSupp.Name = "cmbSupp"
        cmbSupp.Size = New Size(288, 33)
        cmbSupp.TabIndex = 4
        ' 
        ' Label3
        ' 
        Label3.AutoSize = True
        Label3.Font = New Font("Century Gothic", 10F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        Label3.Location = New Point(30, 214)
        Label3.Name = "Label3"
        Label3.Size = New Size(87, 23)
        Label3.TabIndex = 3
        Label3.Text = "Supplier"
        ' 
        ' btnUpdateES
        ' 
        btnUpdateES.BackColor = Color.MediumSeaGreen
        btnUpdateES.FlatAppearance.BorderColor = Color.Silver
        btnUpdateES.FlatStyle = FlatStyle.Flat
        btnUpdateES.Font = New Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        btnUpdateES.ForeColor = SystemColors.ControlLightLight
        btnUpdateES.Location = New Point(30, 347)
        btnUpdateES.Name = "btnUpdateES"
        btnUpdateES.Size = New Size(125, 42)
        btnUpdateES.TabIndex = 4
        btnUpdateES.Text = "Update"
        btnUpdateES.UseVisualStyleBackColor = False
        ' 
        ' btnCancel
        ' 
        btnCancel.BackColor = Color.Firebrick
        btnCancel.FlatAppearance.BorderColor = Color.Silver
        btnCancel.FlatStyle = FlatStyle.Flat
        btnCancel.Font = New Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        btnCancel.ForeColor = SystemColors.ControlLightLight
        btnCancel.Location = New Point(214, 347)
        btnCancel.Name = "btnCancel"
        btnCancel.Size = New Size(125, 42)
        btnCancel.TabIndex = 4
        btnCancel.Text = "Cancel"
        btnCancel.UseVisualStyleBackColor = False
        ' 
        ' EditStock
        ' 
        AutoScaleDimensions = New SizeF(10F, 25F)
        AutoScaleMode = AutoScaleMode.Font
        BackColor = Color.LightSteelBlue
        ClientSize = New Size(377, 405)
        ControlBox = False
        Controls.Add(btnCancel)
        Controls.Add(btnUpdateES)
        Controls.Add(Label3)
        Controls.Add(Label2)
        Controls.Add(Label1)
        Controls.Add(Panel2)
        Controls.Add(Panel3)
        Controls.Add(Panel1)
        FormBorderStyle = FormBorderStyle.FixedSingle
        MaximizeBox = False
        MinimizeBox = False
        Name = "EditStock"
        StartPosition = FormStartPosition.CenterScreen
        Text = "Medent+"
        Panel1.ResumeLayout(False)
        Panel1.PerformLayout()
        Panel2.ResumeLayout(False)
        Panel2.PerformLayout()
        Panel3.ResumeLayout(False)
        ResumeLayout(False)
        PerformLayout()
    End Sub

    Friend WithEvents Panel1 As Panel
    Friend WithEvents txtEQuant As TextBox
    Friend WithEvents Panel2 As Panel
    Friend WithEvents txtEProduct As TextBox
    Friend WithEvents Label1 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents Panel3 As Panel
    Friend WithEvents cmbSupp As ComboBox
    Friend WithEvents Label3 As Label
    Friend WithEvents btnUpdateES As Button
    Friend WithEvents btnCancel As Button
End Class
