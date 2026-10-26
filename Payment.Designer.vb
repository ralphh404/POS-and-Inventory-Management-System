<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Payment
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
        txtDue = New TextBox()
        Panel1 = New Panel()
        Panel2 = New Panel()
        txtCash = New TextBox()
        Panel3 = New Panel()
        txtChange = New TextBox()
        Label4 = New Label()
        Label1 = New Label()
        Label2 = New Label()
        btnConfirm = New Button()
        btnCancel = New Button()
        Panel1.SuspendLayout()
        Panel2.SuspendLayout()
        Panel3.SuspendLayout()
        SuspendLayout()
        ' 
        ' txtDue
        ' 
        txtDue.BorderStyle = BorderStyle.None
        txtDue.Location = New Point(11, 8)
        txtDue.Name = "txtDue"
        txtDue.ReadOnly = True
        txtDue.Size = New Size(299, 24)
        txtDue.TabIndex = 0
        ' 
        ' Panel1
        ' 
        Panel1.BackColor = SystemColors.Control
        Panel1.Controls.Add(txtDue)
        Panel1.Location = New Point(12, 56)
        Panel1.Name = "Panel1"
        Panel1.Size = New Size(321, 40)
        Panel1.TabIndex = 1
        ' 
        ' Panel2
        ' 
        Panel2.BackColor = SystemColors.Window
        Panel2.Controls.Add(txtCash)
        Panel2.Location = New Point(12, 140)
        Panel2.Name = "Panel2"
        Panel2.Size = New Size(321, 40)
        Panel2.TabIndex = 1
        ' 
        ' txtCash
        ' 
        txtCash.BorderStyle = BorderStyle.None
        txtCash.Location = New Point(11, 8)
        txtCash.Name = "txtCash"
        txtCash.Size = New Size(299, 24)
        txtCash.TabIndex = 0
        ' 
        ' Panel3
        ' 
        Panel3.BackColor = SystemColors.Control
        Panel3.Controls.Add(txtChange)
        Panel3.Location = New Point(12, 229)
        Panel3.Name = "Panel3"
        Panel3.Size = New Size(321, 40)
        Panel3.TabIndex = 1
        ' 
        ' txtChange
        ' 
        txtChange.BorderStyle = BorderStyle.None
        txtChange.Location = New Point(11, 8)
        txtChange.Name = "txtChange"
        txtChange.ReadOnly = True
        txtChange.Size = New Size(299, 24)
        txtChange.TabIndex = 0
        ' 
        ' Label4
        ' 
        Label4.AutoSize = True
        Label4.Font = New Font("Century Gothic", 10F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        Label4.ForeColor = SystemColors.HighlightText
        Label4.Location = New Point(12, 30)
        Label4.Name = "Label4"
        Label4.Size = New Size(139, 23)
        Label4.TabIndex = 5
        Label4.Text = "Amount Due:"
        ' 
        ' Label1
        ' 
        Label1.AutoSize = True
        Label1.Font = New Font("Century Gothic", 10F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        Label1.ForeColor = SystemColors.HighlightText
        Label1.Location = New Point(12, 114)
        Label1.Name = "Label1"
        Label1.Size = New Size(65, 23)
        Label1.TabIndex = 5
        Label1.Text = "Cash:"
        ' 
        ' Label2
        ' 
        Label2.AutoSize = True
        Label2.Font = New Font("Century Gothic", 10F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        Label2.ForeColor = SystemColors.HighlightText
        Label2.Location = New Point(12, 203)
        Label2.Name = "Label2"
        Label2.Size = New Size(95, 23)
        Label2.TabIndex = 6
        Label2.Text = "Change:"
        ' 
        ' btnConfirm
        ' 
        btnConfirm.BackColor = Color.DarkSeaGreen
        btnConfirm.FlatAppearance.BorderColor = Color.Silver
        btnConfirm.FlatStyle = FlatStyle.Flat
        btnConfirm.Font = New Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        btnConfirm.ForeColor = SystemColors.ControlLightLight
        btnConfirm.Location = New Point(12, 357)
        btnConfirm.Name = "btnConfirm"
        btnConfirm.Size = New Size(130, 45)
        btnConfirm.TabIndex = 7
        btnConfirm.Text = "Confirm"
        btnConfirm.UseVisualStyleBackColor = False
        ' 
        ' btnCancel
        ' 
        btnCancel.BackColor = Color.Firebrick
        btnCancel.FlatAppearance.BorderColor = Color.Silver
        btnCancel.FlatStyle = FlatStyle.Flat
        btnCancel.Font = New Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        btnCancel.ForeColor = SystemColors.ControlLightLight
        btnCancel.Location = New Point(203, 357)
        btnCancel.Name = "btnCancel"
        btnCancel.Size = New Size(130, 45)
        btnCancel.TabIndex = 7
        btnCancel.Text = "Cancel"
        btnCancel.UseVisualStyleBackColor = False
        ' 
        ' Payment
        ' 
        AutoScaleDimensions = New SizeF(10F, 25F)
        AutoScaleMode = AutoScaleMode.Font
        BackColor = Color.LightSlateGray
        ClientSize = New Size(349, 450)
        ControlBox = False
        Controls.Add(btnCancel)
        Controls.Add(btnConfirm)
        Controls.Add(Label2)
        Controls.Add(Label1)
        Controls.Add(Label4)
        Controls.Add(Panel3)
        Controls.Add(Panel2)
        Controls.Add(Panel1)
        FormBorderStyle = FormBorderStyle.FixedSingle
        MaximizeBox = False
        MinimizeBox = False
        Name = "Payment"
        StartPosition = FormStartPosition.CenterScreen
        Text = "Medent+"
        Panel1.ResumeLayout(False)
        Panel1.PerformLayout()
        Panel2.ResumeLayout(False)
        Panel2.PerformLayout()
        Panel3.ResumeLayout(False)
        Panel3.PerformLayout()
        ResumeLayout(False)
        PerformLayout()
    End Sub

    Friend WithEvents txtDue As TextBox
    Friend WithEvents Panel1 As Panel
    Friend WithEvents Panel2 As Panel
    Friend WithEvents txtCash As TextBox
    Friend WithEvents Panel3 As Panel
    Friend WithEvents txtChange As TextBox
    Friend WithEvents Label4 As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents btnConfirm As Button
    Friend WithEvents btnCancel As Button
End Class
