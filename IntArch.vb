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

        Dim selectedID = Convert.ToInt32(dbArch.SelectedRows(0).Cells("id").Value)

        Dim result = MessageBox.Show("Are you sure you want to restore this account?", "Confirm Restore", MessageBoxButtons.YesNo, MessageBoxIcon.Question)

        If result = DialogResult.Yes Then
            Try
                Connect()

                Dim query = "UPDATE usersPOS SET is_Archived = 0 WHERE id = @id"
                Using cmd As New MySqlCommand(query, conn)
                    cmd.Parameters.AddWithValue("@id", selectedID)
                    cmd.ExecuteNonQuery()
                End Using

                MessageBox.Show("Account restored successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)

                ' Refresh archive list immediately
                LoadArchivedAccounts()

                ' OPTIONAL: also refresh frmAccounts if it’s open
                If Application.OpenForms.OfType(Of frmAccounts).Any Then
                    Dim accForm = Application.OpenForms.OfType(Of frmAccounts).First
                    accForm.LoadAccounts() ' make sure frmAccounts has a public LoadAccounts()
                End If

            Catch ex As Exception
                MessageBox.Show("Error restoring account: " & ex.Message, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Finally
                Disconnect()
            End Try
        End If
    End Sub

    Private Sub btnJohn_Click(sender As Object, e As EventArgs) Handles btnJohn.Click
        ' 1. Check if an account is selected
        If dbArch.SelectedRows.Count = 0 Then
            MessageBox.Show("Please select an account to permanently delete.",
                            "No Selection",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Information)
            Exit Sub
        End If

        ' 2. Get selected account information
        Dim row As DataGridViewRow = dbArch.SelectedRows(0)

        Dim selectedID As Integer =
            Convert.ToInt32(row.Cells("id").Value)

        Dim selectedUsername As String =
            row.Cells("Username").Value.ToString()

        ' 3. Prevent deletion of the currently logged-in account
        If String.Equals(selectedUsername,
                         frmInterface.loggedInUsername,
                         StringComparison.OrdinalIgnoreCase) Then

            MessageBox.Show(
                "You cannot permanently delete the account currently logged in.",
                "Action Not Allowed",
                MessageBoxButtons.OK,
                MessageBoxIcon.Warning)

            Exit Sub
        End If

        ' 4. Confirm permanent deletion
        If MessageBox.Show(
            "Are you sure you want to permanently delete '" &
            selectedUsername & "'?" & Environment.NewLine & Environment.NewLine &
            "This action cannot be undone.",
            "Confirm Permanent Deletion",
            MessageBoxButtons.YesNo,
            MessageBoxIcon.Warning) <> DialogResult.Yes Then

            Exit Sub
        End If

        Try
            Connect()

            ' 5. Delete only if the account is still archived
            Dim query As String = "
            DELETE FROM usersPOS
            WHERE id = @id
            AND is_Archived = 1
        "

            Using cmd As New MySqlCommand(query, conn)

                cmd.Parameters.AddWithValue("@id", selectedID)

                Dim affectedRows As Integer = cmd.ExecuteNonQuery()

                If affectedRows = 0 Then
                    Throw New Exception(
                        "Account could not be deleted. It may no longer be archived.")
                End If

            End Using

            ' 6. Display success message
            MessageBox.Show(
                "Account '" & selectedUsername &
                "' has been permanently deleted.",
                "Deletion Successful",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information)

            ' 7. Refresh archived accounts
            LoadArchivedAccounts()

            ' 8. Refresh active accounts if open
            If Application.OpenForms().OfType(Of frmAccounts).Any() Then
                Application.OpenForms().OfType(Of frmAccounts).First().LoadAccounts()
            End If

        Catch ex As Exception

            MessageBox.Show(
                "Unable to permanently delete account:" &
                Environment.NewLine & Environment.NewLine &
                ex.Message,
                "Deletion Error",
                MessageBoxButtons.OK,
                MessageBoxIcon.Error)

        Finally
            Disconnect()
        End Try
    End Sub
End Class