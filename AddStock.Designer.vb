<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class AddStock
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
        txtQuant = New TextBox()
        Panel1 = New Panel()
        lblQuant = New Label()
        Panel5 = New Panel()
        txtPN = New TextBox()
        Label5 = New Label()
        btnSaveAS = New Button()
        btnCancel = New Button()
        Panel2 = New Panel()
        cmbUnit = New ComboBox()
        Label2 = New Label()
        Panel3 = New Panel()
        txtNBox = New TextBox()
        lblNBox = New Label()
        Panel1.SuspendLayout()
        Panel5.SuspendLayout()
        Panel2.SuspendLayout()
        Panel3.SuspendLayout()
        SuspendLayout()
        ' 
        ' txtQuant
        ' 
        txtQuant.BorderStyle = BorderStyle.None
        txtQuant.Location = New Point(11, 12)
        txtQuant.Name = "txtQuant"
        txtQuant.Size = New Size(288, 24)
        txtQuant.TabIndex = 0
        ' 
        ' Panel1
        ' 
        Panel1.BackColor = SystemColors.Window
        Panel1.Controls.Add(txtQuant)
        Panel1.Location = New Point(26, 146)
        Panel1.Name = "Panel1"
        Panel1.Size = New Size(309, 48)
        Panel1.TabIndex = 1
        ' 
        ' lblQuant
        ' 
        lblQuant.AutoSize = True
        lblQuant.Font = New Font("Century Gothic", 10F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        lblQuant.Location = New Point(112, 120)
        lblQuant.Name = "lblQuant"
        lblQuant.Size = New Size(142, 23)
        lblQuant.TabIndex = 2
        lblQuant.Text = "Quantity(pcs)"
        ' 
        ' Panel5
        ' 
        Panel5.BackColor = SystemColors.Control
        Panel5.Controls.Add(txtPN)
        Panel5.Location = New Point(26, 54)
        Panel5.Name = "Panel5"
        Panel5.Size = New Size(309, 48)
        Panel5.TabIndex = 1
        ' 
        ' txtPN
        ' 
        txtPN.BorderStyle = BorderStyle.None
        txtPN.Location = New Point(11, 12)
        txtPN.Name = "txtPN"
        txtPN.ReadOnly = True
        txtPN.Size = New Size(288, 24)
        txtPN.TabIndex = 0
        ' 
        ' Label5
        ' 
        Label5.AutoSize = True
        Label5.Font = New Font("Century Gothic", 10F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        Label5.Location = New Point(98, 28)
        Label5.Name = "Label5"
        Label5.Size = New Size(154, 23)
        Label5.TabIndex = 2
        Label5.Text = "Product Name"
        ' 
        ' btnSaveAS
        ' 
        btnSaveAS.BackColor = Color.MediumSeaGreen
        btnSaveAS.FlatAppearance.BorderColor = Color.Silver
        btnSaveAS.FlatStyle = FlatStyle.Flat
        btnSaveAS.Font = New Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        btnSaveAS.ForeColor = SystemColors.ControlLightLight
        btnSaveAS.Location = New Point(26, 438)
        btnSaveAS.Name = "btnSaveAS"
        btnSaveAS.Size = New Size(125, 42)
        btnSaveAS.TabIndex = 3
        btnSaveAS.Text = "Save"
        btnSaveAS.UseVisualStyleBackColor = False
        ' 
        ' btnCancel
        ' 
        btnCancel.BackColor = Color.Firebrick
        btnCancel.FlatAppearance.BorderColor = Color.Silver
        btnCancel.FlatStyle = FlatStyle.Flat
        btnCancel.Font = New Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        btnCancel.ForeColor = SystemColors.ControlLightLight
        btnCancel.Location = New Point(210, 438)
        btnCancel.Name = "btnCancel"
        btnCancel.Size = New Size(125, 42)
        btnCancel.TabIndex = 3
        btnCancel.Text = "Cancel"
        btnCancel.UseVisualStyleBackColor = False
        ' 
        ' Panel2
        ' 
        Panel2.BackColor = SystemColors.Window
        Panel2.Controls.Add(cmbUnit)
        Panel2.Location = New Point(26, 337)
        Panel2.Name = "Panel2"
        Panel2.Size = New Size(309, 48)
        Panel2.TabIndex = 1
        ' 
        ' cmbUnit
        ' 
        cmbUnit.DropDownStyle = ComboBoxStyle.DropDownList
        cmbUnit.FormattingEnabled = True
        cmbUnit.Location = New Point(11, 8)
        cmbUnit.Name = "cmbUnit"
        cmbUnit.Size = New Size(288, 33)
        cmbUnit.TabIndex = 0
        ' 
        ' Label2
        ' 
        Label2.AutoSize = True
        Label2.Font = New Font("Century Gothic", 10F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        Label2.Location = New Point(152, 311)
        Label2.Name = "Label2"
        Label2.Size = New Size(45, 23)
        Label2.TabIndex = 2
        Label2.Text = "Unit"
        ' 
        ' Panel3
        ' 
        Panel3.BackColor = SystemColors.Window
        Panel3.Controls.Add(txtNBox)
        Panel3.Location = New Point(26, 242)
        Panel3.Name = "Panel3"
        Panel3.Size = New Size(309, 48)
        Panel3.TabIndex = 1
        ' 
        ' txtNBox
        ' 
        txtNBox.BorderStyle = BorderStyle.None
        txtNBox.Location = New Point(11, 12)
        txtNBox.Name = "txtNBox"
        txtNBox.Size = New Size(288, 24)
        txtNBox.TabIndex = 0
        ' 
        ' lblNBox
        ' 
        lblNBox.AutoSize = True
        lblNBox.Font = New Font("Century Gothic", 10F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        lblNBox.Location = New Point(123, 216)
        lblNBox.Name = "lblNBox"
        lblNBox.Size = New Size(129, 23)
        lblNBox.TabIndex = 2
        lblNBox.Text = "No. of Boxes"
        ' 
        ' AddStock
        ' 
        AutoScaleDimensions = New SizeF(10F, 25F)
        AutoScaleMode = AutoScaleMode.Font
        BackColor = Color.LightSteelBlue
        ClientSize = New Size(369, 512)
        ControlBox = False
        Controls.Add(btnCancel)
        Controls.Add(Panel3)
        Controls.Add(btnSaveAS)
        Controls.Add(Label5)
        Controls.Add(lblNBox)
        Controls.Add(Label2)
        Controls.Add(lblQuant)
        Controls.Add(Panel5)
        Controls.Add(Panel2)
        Controls.Add(Panel1)
        FormBorderStyle = FormBorderStyle.FixedSingle
        MaximizeBox = False
        MinimizeBox = False
        Name = "AddStock"
        StartPosition = FormStartPosition.CenterScreen
        Text = "User"
        Panel1.ResumeLayout(False)
        Panel1.PerformLayout()
        Panel5.ResumeLayout(False)
        Panel5.PerformLayout()
        Panel2.ResumeLayout(False)
        Panel3.ResumeLayout(False)
        Panel3.PerformLayout()
        ResumeLayout(False)
        PerformLayout()
    End Sub

    Friend WithEvents txtQuant As TextBox
    Friend WithEvents Panel1 As Panel
    Friend WithEvents lblQuant As Label
    Friend WithEvents Panel5 As Panel
    Friend WithEvents txtPN As TextBox
    Friend WithEvents Label5 As Label
    Friend WithEvents btnSaveAS As Button
    Friend WithEvents btnCancel As Button
    Friend WithEvents Panel2 As Panel
    Friend WithEvents cmbUnit As ComboBox
    Friend WithEvents Label2 As Label
    Friend WithEvents Panel3 As Panel
    Friend WithEvents txtNBox As TextBox
    Friend WithEvents lblNBox As Label
End Class
