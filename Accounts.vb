Imports MySql.Data.MySqlClient

Public Class frmAccounts

    Private Sub frmAccounts_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.TopLevel = False
        Me.FormBorderStyle = FormBorderStyle.None
        Me.Dock = DockStyle.Fill

        LoadAccounts()

        If String.IsNullOrWhiteSpace(txtSearchAcc.Text) Then
            txtSearchAcc.Text = "Search"
            txtSearchAcc.ForeColor = Color.Gray
        End If

        lblClr.Visible = False  ' hide clear label at start

        ' Disable sorting for all columns
        For Each column As DataGridViewColumn In dbAccounts.Columns
            column.SortMode = DataGridViewColumnSortMode.NotSortable
        Next
    End Sub

    Private Sub Accounts_Shown(sender As Object, e As EventArgs) Handles MyBase.Shown

        lblActiveDate2.Text = DateTime.Now.ToString("dddd, MMMM dd yyyy")
        lblActiveTime2.Text = DateTime.Now.ToString("hh:mm:ss tt")
        lblUsername2.Text = "User: " & frmInterface.loggedInUsername

        TimerDateTime2.Start()

        LoadAccounts()
    End Sub

    Private Sub TimerDateTime2_Tick(sender As Object, e As EventArgs) Handles TimerDateTime2.Tick
        lblActiveDate2.Text = DateTime.Now.ToString("dddd, MMMM d, yyyy")
        lblActiveTime2.Text = DateTime.Now.ToString("hh:mm:ss tt")
    End Sub

    Public Sub LoadAccounts()
        Try
            Connect()

            Dim query As String = "SELECT id, Username, AccountType, Password FROM usersPOS WHERE is_Archived = 0"
            Dim adapter As New MySqlDataAdapter(query, conn)
            Dim dt As New DataTable()
            adapter.Fill(dt)

            ' Mask password column
            For Each row As DataRow In dt.Rows
                If row("Password") IsNot Nothing AndAlso row("Password").ToString() <> "" Then
                    row("Password") = "•••••••"
                End If
            Next

            dbAccounts.DataSource = dt
            If dbAccounts.Columns.Contains("id") Then
                dbAccounts.Columns("id").Visible = False
            End If

        Catch ex As Exception
            MessageBox.Show("Error loading accounts: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            Disconnect()
        End Try
    End Sub

    Public Sub SearchAccounts(keyword As String)
        Try
            Connect()

            Dim query As String = "SELECT id, Username, AccountType, Password 
                               FROM usersPOS 
                               WHERE is_Archived = 0 
                               AND (Username LIKE @search OR AccountType LIKE @search)"

            Dim cmd As New MySqlCommand(query, conn)
            cmd.Parameters.AddWithValue("@search", "%" & keyword & "%")

            Dim adapter As New MySqlDataAdapter(cmd)
            Dim dt As New DataTable()
            adapter.Fill(dt)

            For Each row As DataRow In dt.Rows
                If row("Password") IsNot Nothing AndAlso row("Password").ToString() <> "" Then
                    row("Password") = "•••••••"
                End If
            Next

            dbAccounts.DataSource = dt
            If dbAccounts.Columns.Contains("id") Then
                dbAccounts.Columns("id").Visible = False
            End If

        Catch ex As Exception
            MessageBox.Show("Error searching accounts: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            Disconnect()
        End Try
    End Sub

    Private Sub txtSearchAcc_TextChanged(sender As Object, e As EventArgs) Handles txtSearchAcc.TextChanged
        If txtSearchAcc.Text = "Search" OrElse String.IsNullOrWhiteSpace(txtSearchAcc.Text) Then
            lblClr.Visible = False
        Else
            lblClr.Visible = True
        End If

        ' Search logic
        If txtSearchAcc.Text = "Search" Then
            LoadAccounts()
        ElseIf String.IsNullOrWhiteSpace(txtSearchAcc.Text) Then
            LoadAccounts()
        Else
            SearchAccounts(txtSearchAcc.Text.Trim())
        End If
    End Sub

    Private Sub txtSearch_Enter(sender As Object, e As EventArgs) Handles txtSearchAcc.Enter
        If txtSearchAcc.Text = "Search" Then
            txtSearchAcc.Text = ""
            txtSearchAcc.ForeColor = Color.Black
        End If
    End Sub

    Private Sub txtSearch_Leave(sender As Object, e As EventArgs) Handles txtSearchAcc.Leave
        If String.IsNullOrWhiteSpace(txtSearchAcc.Text) Then
            txtSearchAcc.Text = "Search"
            txtSearchAcc.ForeColor = Color.Gray
        End If
    End Sub

    Private Sub btnClr_Click(sender As Object, e As EventArgs) Handles lblClr.Click
        ' Clear search input
        txtSearchAcc.Clear()
        LoadAccounts() ' reset accounts

        ' If the box is not focused, reapply watermark immediately
        If Not txtSearchAcc.Focused Then
            txtSearchAcc.Text = "Search"
            txtSearchAcc.ForeColor = Color.Gray
        End If
    End Sub


    Private Sub dbAccounts_CellFormatting(sender As Object, e As DataGridViewCellFormattingEventArgs) Handles dbAccounts.CellFormatting
        If dbAccounts.Columns(e.ColumnIndex).Name = "Password" AndAlso e.Value IsNot Nothing Then
            e.CellStyle.ForeColor = Color.LightSlateGray
        End If
    End Sub

    Private Sub AddAcc_Click(sender As Object, e As EventArgs) Handles Add.Click
        Dim addForm As New AddPopUp()
        If addForm.ShowDialog() = DialogResult.OK Then
            LoadAccounts()
        End If
    End Sub

    Private Sub btnChPass_Click(sender As Object, e As EventArgs) Handles btnChPass.Click
        If dbAccounts.SelectedRows.Count > 0 Then
            Dim selectedUser As String = dbAccounts.SelectedRows(0).Cells("Username").Value?.ToString()
            If Not String.IsNullOrEmpty(selectedUser) Then
                Dim frm As New PasswordCh()
                frm.txtUsername.Text = selectedUser
                frm.ShowDialog()
            End If
        Else
            MessageBox.Show("Please select a user first.", "Notice", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End If
    End Sub

    Private Sub btnArch_Click(sender As Object, e As EventArgs) Handles btnArch.Click
        If dbAccounts.SelectedRows.Count = 0 Then
            MessageBox.Show("Please select an account first.", "No Selection", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If

        ' Get selected account ID safely
        Dim selectedID As Integer
        If Not Integer.TryParse(dbAccounts.SelectedRows(0).Cells("id").Value?.ToString(), selectedID) Then
            MessageBox.Show("Invalid account selected.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return
        End If

        Dim result As DialogResult = MessageBox.Show("Are you sure you want to archive this account?", "Confirm Archive", MessageBoxButtons.YesNo, MessageBoxIcon.Question)

        If result = DialogResult.Yes Then
            Try
                Connect()

                Dim query As String = "UPDATE usersPOS SET is_Archived = 1 WHERE id = @id"
                Using cmd As New MySqlCommand(query, conn)
                    cmd.Parameters.AddWithValue("@id", selectedID)
                    cmd.ExecuteNonQuery()
                End Using

                MessageBox.Show("Account archived successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)

                ' Refresh active accounts
                LoadAccounts()

                ' 🔄 Refresh archive form if open
                If Application.OpenForms().OfType(Of IntArch).Any() Then
                    Application.OpenForms().OfType(Of IntArch).First().LoadArchivedAccounts()
                End If

            Catch ex As Exception
                MessageBox.Show("Error archiving account: " & ex.Message, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Finally
                Disconnect()
            End Try
        End If
    End Sub

End Class
