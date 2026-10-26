<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class AddSuppliers
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
        txtspName = New TextBox()
        Panel2 = New Panel()
        Panel3 = New Panel()
        txtCName = New TextBox()
        Panel4 = New Panel()
        txtEml = New TextBox()
        Panel5 = New Panel()
        txtPhn = New TextBox()
        Panel6 = New Panel()
        txtAdress = New TextBox()
        Label1 = New Label()
        Label2 = New Label()
        Label3 = New Label()
        Label4 = New Label()
        Label5 = New Label()
        btnSavesp = New Button()
        btnCancelsp = New Button()
        btnspUp = New Button()
        Panel2.SuspendLayout()
        Panel3.SuspendLayout()
        Panel4.SuspendLayout()
        Panel5.SuspendLayout()
        Panel6.SuspendLayout()
        SuspendLayout()
        ' 
        ' txtspName
        ' 
        txtspName.BorderStyle = BorderStyle.None
        txtspName.Location = New Point(5, 12)
        txtspName.Name = "txtspName"
        txtspName.Size = New Size(284, 24)
        txtspName.TabIndex = 1
        ' 
        ' Panel2
        ' 
        Panel2.BackColor = SystemColors.Window
        Panel2.Controls.Add(txtspName)
        Panel2.Location = New Point(39, 58)
        Panel2.Name = "Panel2"
        Panel2.Size = New Size(294, 47)
        Panel2.TabIndex = 2
        ' 
        ' Panel3
        ' 
        Panel3.BackColor = SystemColors.Window
        Panel3.Controls.Add(txtCName)
        Panel3.Location = New Point(39, 140)
        Panel3.Name = "Panel3"
        Panel3.Size = New Size(294, 47)
        Panel3.TabIndex = 2
        ' 
        ' txtCName
        ' 
        txtCName.BorderStyle = BorderStyle.None
        txtCName.Location = New Point(5, 12)
        txtCName.Name = "txtCName"
        txtCName.Size = New Size(284, 24)
        txtCName.TabIndex = 1
        ' 
        ' Panel4
        ' 
        Panel4.BackColor = SystemColors.Window
        Panel4.Controls.Add(txtEml)
        Panel4.Location = New Point(39, 226)
        Panel4.Name = "Panel4"
        Panel4.Size = New Size(294, 47)
        Panel4.TabIndex = 2
        ' 
        ' txtEml
        ' 
        txtEml.BorderStyle = BorderStyle.None
        txtEml.Location = New Point(5, 12)
        txtEml.Name = "txtEml"
        txtEml.Size = New Size(284, 24)
        txtEml.TabIndex = 1
        ' 
        ' Panel5
        ' 
        Panel5.BackColor = SystemColors.Window
        Panel5.Controls.Add(txtPhn)
        Panel5.Location = New Point(39, 312)
        Panel5.Name = "Panel5"
        Panel5.Size = New Size(294, 47)
        Panel5.TabIndex = 2
        ' 
        ' txtPhn
        ' 
        txtPhn.BorderStyle = BorderStyle.None
        txtPhn.Location = New Point(5, 12)
        txtPhn.Name = "txtPhn"
        txtPhn.Size = New Size(284, 24)
        txtPhn.TabIndex = 1
        ' 
        ' Panel6
        ' 
        Panel6.BackColor = SystemColors.Window
        Panel6.Controls.Add(txtAdress)
        Panel6.Location = New Point(39, 396)
        Panel6.Name = "Panel6"
        Panel6.Size = New Size(294, 47)
        Panel6.TabIndex = 2
        ' 
        ' txtAdress
        ' 
        txtAdress.BorderStyle = BorderStyle.None
        txtAdress.Location = New Point(5, 12)
        txtAdress.Name = "txtAdress"
        txtAdress.Size = New Size(284, 24)
        txtAdress.TabIndex = 1
        ' 
        ' Label1
        ' 
        Label1.AutoSize = True
        Label1.Font = New Font("Century Gothic", 10F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        Label1.Location = New Point(44, 32)
        Label1.Name = "Label1"
        Label1.Size = New Size(154, 23)
        Label1.TabIndex = 3
        Label1.Text = "Supplier Name"
        ' 
        ' Label2
        ' 
        Label2.AutoSize = True
        Label2.Font = New Font("Century Gothic", 10F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        Label2.Location = New Point(44, 114)
        Label2.Name = "Label2"
        Label2.Size = New Size(159, 23)
        Label2.TabIndex = 3
        Label2.Text = "Contact Name"
        ' 
        ' Label3
        ' 
        Label3.AutoSize = True
        Label3.Font = New Font("Century Gothic", 10F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        Label3.Location = New Point(44, 200)
        Label3.Name = "Label3"
        Label3.Size = New Size(62, 23)
        Label3.TabIndex = 3
        Label3.Text = "Email"
        ' 
        ' Label4
        ' 
        Label4.AutoSize = True
        Label4.Font = New Font("Century Gothic", 10F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        Label4.Location = New Point(44, 286)
        Label4.Name = "Label4"
        Label4.Size = New Size(72, 23)
        Label4.TabIndex = 3
        Label4.Text = "Phone"
        ' 
        ' Label5
        ' 
        Label5.AutoSize = True
        Label5.Font = New Font("Century Gothic", 10F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        Label5.Location = New Point(44, 370)
        Label5.Name = "Label5"
        Label5.Size = New Size(88, 23)
        Label5.TabIndex = 3
        Label5.Text = "Address"
        ' 
        ' btnSavesp
        ' 
        btnSavesp.BackColor = Color.CadetBlue
        btnSavesp.FlatAppearance.BorderColor = Color.Silver
        btnSavesp.FlatStyle = FlatStyle.Flat
        btnSavesp.Font = New Font("Century Gothic", 9F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        btnSavesp.ForeColor = SystemColors.ControlLightLight
        btnSavesp.Location = New Point(73, 471)
        btnSavesp.Name = "btnSavesp"
        btnSavesp.Size = New Size(125, 42)
        btnSavesp.TabIndex = 4
        btnSavesp.Text = "Save"
        btnSavesp.UseVisualStyleBackColor = False
        ' 
        ' btnCancelsp
        ' 
        btnCancelsp.BackColor = Color.Firebrick
        btnCancelsp.FlatAppearance.BorderColor = Color.Silver
        btnCancelsp.FlatStyle = FlatStyle.Flat
        btnCancelsp.Font = New Font("Century Gothic", 9F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        btnCancelsp.ForeColor = SystemColors.ControlLightLight
        btnCancelsp.Location = New Point(208, 471)
        btnCancelsp.Name = "btnCancelsp"
        btnCancelsp.Size = New Size(125, 42)
        btnCancelsp.TabIndex = 4
        btnCancelsp.Text = "Cancel"
        btnCancelsp.UseVisualStyleBackColor = False
        ' 
        ' btnspUp
        ' 
        btnspUp.BackColor = Color.MediumSeaGreen
        btnspUp.FlatAppearance.BorderColor = Color.Silver
        btnspUp.FlatStyle = FlatStyle.Flat
        btnspUp.Font = New Font("Century Gothic", 9F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        btnspUp.ForeColor = SystemColors.ControlLightLight
        btnspUp.Location = New Point(73, 471)
        btnspUp.Name = "btnspUp"
        btnspUp.Size = New Size(125, 42)
        btnspUp.TabIndex = 4
        btnspUp.Text = "Update"
        btnspUp.UseVisualStyleBackColor = False
        ' 
        ' AddSuppliers
        ' 
        AutoScaleDimensions = New SizeF(10F, 25F)
        AutoScaleMode = AutoScaleMode.Font
        BackColor = SystemColors.GradientActiveCaption
        ClientSize = New Size(364, 542)
        Controls.Add(btnCancelsp)
        Controls.Add(btnSavesp)
        Controls.Add(btnspUp)
        Controls.Add(Label5)
        Controls.Add(Label4)
        Controls.Add(Label3)
        Controls.Add(Label2)
        Controls.Add(Label1)
        Controls.Add(Panel6)
        Controls.Add(Panel5)
        Controls.Add(Panel4)
        Controls.Add(Panel3)
        Controls.Add(Panel2)
        FormBorderStyle = FormBorderStyle.FixedDialog
        MaximizeBox = False
        MinimizeBox = False
        Name = "AddSuppliers"
        StartPosition = FormStartPosition.CenterScreen
        Text = "Medent+"
        Panel2.ResumeLayout(False)
        Panel2.PerformLayout()
        Panel3.ResumeLayout(False)
        Panel3.PerformLayout()
        Panel4.ResumeLayout(False)
        Panel4.PerformLayout()
        Panel5.ResumeLayout(False)
        Panel5.PerformLayout()
        Panel6.ResumeLayout(False)
        Panel6.PerformLayout()
        ResumeLayout(False)
        PerformLayout()
    End Sub
    Friend WithEvents txtspName As TextBox
    Friend WithEvents Panel2 As Panel
    Friend WithEvents Panel3 As Panel
    Friend WithEvents txtCName As TextBox
    Friend WithEvents Panel4 As Panel
    Friend WithEvents txtEml As TextBox
    Friend WithEvents Panel5 As Panel
    Friend WithEvents txtPhn As TextBox
    Friend WithEvents Panel6 As Panel
    Friend WithEvents txtAdress As TextBox
    Friend WithEvents Label1 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents Label5 As Label
    Friend WithEvents btnSavesp As Button
    Friend WithEvents btnCancelsp As Button
    Friend WithEvents btnspUp As Button
End Class
