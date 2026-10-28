<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class AddCategory
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
        txtCn = New TextBox()
        txtDesc = New TextBox()
        btnSaveC = New Button()
        btnCancelC = New Button()
        Label1 = New Label()
        Label2 = New Label()
        btnUpdateC = New Button()
        Panel1 = New Panel()
        Panel2 = New Panel()
        Panel1.SuspendLayout()
        Panel2.SuspendLayout()
        SuspendLayout()
        ' 
        ' txtCn
        ' 
        txtCn.BorderStyle = BorderStyle.None
        txtCn.Location = New Point(11, 11)
        txtCn.Name = "txtCn"
        txtCn.Size = New Size(288, 24)
        txtCn.TabIndex = 0
        ' 
        ' txtDesc
        ' 
        txtDesc.BorderStyle = BorderStyle.None
        txtDesc.Location = New Point(11, 15)
        txtDesc.Multiline = True
        txtDesc.Name = "txtDesc"
        txtDesc.Size = New Size(288, 164)
        txtDesc.TabIndex = 1
        ' 
        ' btnSaveC
        ' 
        btnSaveC.BackColor = Color.MediumSeaGreen
        btnSaveC.FlatAppearance.BorderColor = Color.Silver
        btnSaveC.FlatStyle = FlatStyle.Flat
        btnSaveC.Font = New Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        btnSaveC.ForeColor = SystemColors.ControlLightLight
        btnSaveC.Location = New Point(29, 337)
        btnSaveC.Name = "btnSaveC"
        btnSaveC.Size = New Size(125, 42)
        btnSaveC.TabIndex = 2
        btnSaveC.Text = "Save"
        btnSaveC.UseVisualStyleBackColor = False
        ' 
        ' btnCancelC
        ' 
        btnCancelC.BackColor = Color.Firebrick
        btnCancelC.FlatAppearance.BorderColor = Color.Silver
        btnCancelC.FlatStyle = FlatStyle.Flat
        btnCancelC.Font = New Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        btnCancelC.ForeColor = SystemColors.ControlLightLight
        btnCancelC.Location = New Point(212, 337)
        btnCancelC.Name = "btnCancelC"
        btnCancelC.Size = New Size(125, 42)
        btnCancelC.TabIndex = 3
        btnCancelC.Text = "Cancel"
        btnCancelC.UseVisualStyleBackColor = False
        ' 
        ' Label1
        ' 
        Label1.AutoSize = True
        Label1.Font = New Font("Century Gothic", 10F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        Label1.Location = New Point(29, 18)
        Label1.Name = "Label1"
        Label1.Size = New Size(175, 23)
        Label1.TabIndex = 4
        Label1.Text = "Category Name:"
        ' 
        ' Label2
        ' 
        Label2.AutoSize = True
        Label2.Font = New Font("Century Gothic", 10F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        Label2.Location = New Point(29, 100)
        Label2.Name = "Label2"
        Label2.Size = New Size(122, 23)
        Label2.TabIndex = 5
        Label2.Text = "Description:" & vbCrLf
        ' 
        ' btnUpdateC
        ' 
        btnUpdateC.BackColor = Color.Teal
        btnUpdateC.FlatAppearance.BorderColor = Color.Silver
        btnUpdateC.FlatStyle = FlatStyle.Flat
        btnUpdateC.Font = New Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        btnUpdateC.ForeColor = SystemColors.ControlLightLight
        btnUpdateC.Location = New Point(29, 337)
        btnUpdateC.Name = "btnUpdateC"
        btnUpdateC.Size = New Size(125, 42)
        btnUpdateC.TabIndex = 6
        btnUpdateC.Text = "Update"
        btnUpdateC.UseVisualStyleBackColor = False
        ' 
        ' Panel1
        ' 
        Panel1.BackColor = SystemColors.Window
        Panel1.Controls.Add(txtCn)
        Panel1.Location = New Point(29, 44)
        Panel1.Name = "Panel1"
        Panel1.Size = New Size(308, 47)
        Panel1.TabIndex = 7
        ' 
        ' Panel2
        ' 
        Panel2.BackColor = SystemColors.Window
        Panel2.Controls.Add(txtDesc)
        Panel2.Location = New Point(29, 126)
        Panel2.Name = "Panel2"
        Panel2.Size = New Size(308, 194)
        Panel2.TabIndex = 8
        ' 
        ' AddCategory
        ' 
        AutoScaleDimensions = New SizeF(10F, 25F)
        AutoScaleMode = AutoScaleMode.Font
        BackColor = Color.LightSteelBlue
        ClientSize = New Size(370, 404)
        Controls.Add(Panel2)
        Controls.Add(Panel1)
        Controls.Add(btnUpdateC)
        Controls.Add(Label2)
        Controls.Add(Label1)
        Controls.Add(btnCancelC)
        Controls.Add(btnSaveC)
        FormBorderStyle = FormBorderStyle.FixedSingle
        MaximizeBox = False
        MinimizeBox = False
        Name = "AddCategory"
        StartPosition = FormStartPosition.CenterScreen
        Text = "User"
        Panel1.ResumeLayout(False)
        Panel1.PerformLayout()
        Panel2.ResumeLayout(False)
        Panel2.PerformLayout()
        ResumeLayout(False)
        PerformLayout()
    End Sub

    Friend WithEvents txtCn As TextBox
    Friend WithEvents txtDesc As TextBox
    Friend WithEvents btnSaveC As Button
    Friend WithEvents btnCancelC As Button
    Friend WithEvents Label1 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents btnUpdateC As Button
    Friend WithEvents Panel1 As Panel
    Friend WithEvents Panel2 As Panel
End Class
