Imports MySql.Data.MySqlClient

Public Class frmLogs
    Private Sub frmLogs_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.TopLevel = False
        Me.FormBorderStyle = FormBorderStyle.None
        Me.Dock = DockStyle.Fill
        LoadLogs()
        For Each column As DataGridViewColumn In dbLogs.Columns
            column.SortMode = DataGridViewColumnSortMode.NotSortable
        Next
    End Sub

    Private Sub Logs_Shown(sender As Object, e As EventArgs) Handles MyBase.Shown

        lblActiveDate4.Text = DateTime.Now.ToString("dddd, MMMM dd yyyy")
        lblActiveTime4.Text = DateTime.Now.ToString("hh:mm:ss tt")
        lblUsername4.Text = "User: " & frmInterface.loggedInUsername

        TimerDateTime4.Start()

        LoadLogs()
    End Sub

    Private Sub TimerDateTime4_Tick(sender As Object, e As EventArgs) Handles TimerDateTime4.Tick
        lblActiveDate4.Text = DateTime.Now.ToString("dddd, MMMM d, yyyy")
        lblActiveTime4.Text = DateTime.Now.ToString("hh:mm:ss tt")
    End Sub

    Public Sub LoadLogs()

        Try
            conn.Open()
            Dim query As String = "SELECT Username, Action, Details, LogTime FROM log_historyPOS ORDER BY LogTime DESC"
            Dim cmd As New MySqlCommand(query, conn)
            Dim adapter As New MySqlDataAdapter(cmd)
            Dim table As New DataTable()
            adapter.Fill(table)
            dbLogs.DataSource = table
            conn.Close()
        Catch ex As Exception
            MessageBox.Show("Failed to load logs: " & ex.Message)
            conn.Close()
        End Try

    End Sub

End Class