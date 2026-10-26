Imports System.Globalization

Public Class Payment
    Public Property AmountDue As Decimal
    Public Property CashGiven As Decimal
    Public Property ChangeAmount As Decimal

    Private Sub Payment_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.DialogResult = DialogResult.None
        ' Show amount due in peso format
        txtDue.Text = AmountDue.ToString("C2", New CultureInfo("en-PH"))
        txtChange.Text = "₱0.00"
    End Sub

    Private Sub txtCash_TextChanged(sender As Object, e As EventArgs) Handles txtCash.TextChanged
        Dim cash As Decimal
        ' Support ₱, commas, decimals
        If Decimal.TryParse(txtCash.Text, NumberStyles.Currency, New CultureInfo("en-PH"), cash) Then
            Dim change As Decimal = cash - AmountDue
            txtChange.Text = change.ToString("C2", New CultureInfo("en-PH"))
        Else
            txtChange.Text = "₱0.00"
        End If
    End Sub

    Private Sub btnConfirm_Click(sender As Object, e As EventArgs) Handles btnConfirm.Click
        Dim cash As Decimal
        If Decimal.TryParse(txtCash.Text, NumberStyles.Currency, New CultureInfo("en-PH"), cash) Then
            If cash < AmountDue Then
                MessageBox.Show("Insufficient cash entered!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Exit Sub
            End If

            ' Update payment properties
            CashGiven = cash
            ChangeAmount = cash - AmountDue

            ' ✅ Close the payment form
            Me.DialogResult = DialogResult.OK
            Me.Close()
        Else
            MessageBox.Show("Please enter a valid cash amount!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If
    End Sub

    Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        Me.DialogResult = DialogResult.Cancel
        Me.Close()
    End Sub

    ' 🔹 Shortcut keys for speed
    Protected Overrides Function ProcessCmdKey(ByRef msg As Message, keyData As Keys) As Boolean
        If keyData = Keys.Enter Then
            btnConfirm.PerformClick()
            Return True
        ElseIf keyData = Keys.Escape Then
            btnCancel.PerformClick()
            Return True
        End If
        Return MyBase.ProcessCmdKey(msg, keyData)
    End Function
End Class

