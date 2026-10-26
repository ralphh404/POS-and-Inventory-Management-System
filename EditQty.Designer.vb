<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class EditQty
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
        Label4 = New Label()
        Panel1 = New Panel()
        txtQuantity = New TextBox()
        btnConfirm2 = New Button()
        btnCancel = New Button()
        Panel1.SuspendLayout()
        SuspendLayout()
        ' 
        ' Label4
        ' 
        Label4.AutoSize = True
        Label4.Font = New Font("Century Gothic", 10F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        Label4.ForeColor = SystemColors.HighlightText
        Label4.Location = New Point(134, 50)
        Label4.Name = "Label4"
        Label4.Size = New Size(93, 23)
        Label4.TabIndex = 5
        Label4.Text = "Quantity"
        ' 
        ' Panel1
        ' 
        Panel1.BackColor = SystemColors.Window
        Panel1.Controls.Add(txtQuantity)
        Panel1.Location = New Point(32, 84)
        Panel1.Name = "Panel1"
        Panel1.Size = New Size(309, 48)
        Panel1.TabIndex = 6
        ' 
        ' txtQuantity
        ' 
        txtQuantity.BorderStyle = BorderStyle.None
        txtQuantity.Location = New Point(11, 12)
        txtQuantity.Name = "txtQuantity"
        txtQuantity.Size = New Size(288, 24)
        txtQuantity.TabIndex = 0
        ' 
        ' btnConfirm2
        ' 
        btnConfirm2.BackColor = Color.Teal
        btnConfirm2.FlatAppearance.BorderColor = Color.Silver
        btnConfirm2.FlatStyle = FlatStyle.Flat
        btnConfirm2.Font = New Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        btnConfirm2.ForeColor = SystemColors.ControlLightLight
        btnConfirm2.Location = New Point(32, 234)
        btnConfirm2.Name = "btnConfirm2"
        btnConfirm2.Size = New Size(130, 45)
        btnConfirm2.TabIndex = 8
        btnConfirm2.Text = "Confirm"
        btnConfirm2.UseVisualStyleBackColor = False
        ' 
        ' btnCancel
        ' 
        btnCancel.BackColor = Color.Firebrick
        btnCancel.FlatAppearance.BorderColor = Color.Silver
        btnCancel.FlatStyle = FlatStyle.Flat
        btnCancel.Font = New Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        btnCancel.ForeColor = SystemColors.ControlLightLight
        btnCancel.Location = New Point(211, 234)
        btnCancel.Name = "btnCancel"
        btnCancel.Size = New Size(130, 45)
        btnCancel.TabIndex = 9
        btnCancel.Text = "Cancel"
        btnCancel.UseVisualStyleBackColor = False
        ' 
        ' EditQty
        ' 
        AutoScaleDimensions = New SizeF(10F, 25F)
        AutoScaleMode = AutoScaleMode.Font
        BackColor = Color.SlateGray
        ClientSize = New Size(377, 304)
        ControlBox = False
        Controls.Add(btnCancel)
        Controls.Add(btnConfirm2)
        Controls.Add(Panel1)
        Controls.Add(Label4)
        FormBorderStyle = FormBorderStyle.FixedSingle
        MaximizeBox = False
        MinimizeBox = False
        Name = "EditQty"
        StartPosition = FormStartPosition.CenterScreen
        Text = "Medent+"
        Panel1.ResumeLayout(False)
        Panel1.PerformLayout()
        ResumeLayout(False)
        PerformLayout()
    End Sub

    Friend WithEvents Label4 As Label
    Friend WithEvents Panel1 As Panel
    Friend WithEvents txtQuantity As TextBox
    Friend WithEvents btnConfirm2 As Button
    Friend WithEvents btnCancel As Button
End Class
