Imports MySql.Data.MySqlClient

Public Class IntArch

    Private Sub IntArch_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        LoadArchivedAccounts()
    End Sub

    Private Sub ArchAccounts_Shown(sender As Object, e As EventArgs) Handles MyBase.Shown

        lblActiveDate3.Text = DateTime.Now.ToString("dddd, MMMM dd yyyy")
        lblActiveTime3.Text = DateTime.Now.ToString("hh:mm:ss tt")
        lblUsername3.Text = "User: " & frmInterface.loggedInUsername

        TimerDateTime3.Start()

        LoadArchivedAccounts()
    End Sub

    Private Sub TimerDateTime3_Tick(sender As Object, e As EventArgs) Handles TimerDateTime3.Tick
        lblActiveDate3.Text = DateTime.Now.ToString("dddd, MMMM d, yyyy")
        lblActiveTime3.Text = DateTime.Now.ToString("hh:mm:ss tt")
    End Sub

    ' Load all archived accounts
    Public Sub LoadArchivedAccounts()
        Try
            Connect()

            Dim query As String = "SELECT id, Username, AccountType, Password FROM usersPOS WHERE is_Archived = 1"
            Dim adapter As New MySqlDataAdapter(query, conn)
            Dim dt As New DataTable()
            adapter.Fill(dt)

            ' Mask password column for display
            For Each row As DataRow In dt.Rows
                row("Password") = "•••••••"
            Next

            dbArch.DataSource = dt

            If dbArch.Columns.Contains("id") Then
                dbArch.Columns("id").Visible = False
            End If

        Catch ex As Exception
            MessageBox.Show("Error loading archived accounts: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            Disconnect()
        End Try
    End Sub

    ' Restore selected account
    Private Sub btnRestore_Click(sender As Object, e As EventArgs) Handles btnRestore.Click
        If dbArch.SelectedRows.Count = 0 Then
            MessageBox.Show("Please select an account to restore.", "No Selection", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If

        Dim selectedID As Integer = Convert.ToInt32(dbArch.SelectedRows(0).Cells("id").Value)

        Dim result As DialogResult = MessageBox.Show("Are you sure you want to restore this account?", "Confirm Restore", MessageBoxButtons.YesNo, MessageBoxIcon.Question)

        If result = DialogResult.Yes Then
            Try
                Connect()

                Dim query As String = "UPDATE usersPOS SET is_Archived = 0 WHERE id = @id"
                Using cmd As New MySqlCommand(query, conn)
                    cmd.Parameters.AddWithValue("@id", selectedID)
                    cmd.ExecuteNonQuery()
                End Using

                MessageBox.Show("Account restored successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)

                ' Refresh archive list immediately
                LoadArchivedAccounts()

                ' OPTIONAL: also refresh frmAccounts if it’s open
                If Application.OpenForms().OfType(Of frmAccounts).Any() Then
                    Dim accForm As frmAccounts = Application.OpenForms().OfType(Of frmAccounts).First()
                    accForm.LoadAccounts() ' make sure frmAccounts has a public LoadAccounts()
                End If

            Catch ex As Exception
                MessageBox.Show("Error restoring account: " & ex.Message, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Finally
                Disconnect()
            End Try
        End If
    End Sub

End Class