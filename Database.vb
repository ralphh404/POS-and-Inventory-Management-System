Imports MySql.Data.MySqlClient

Module Database

    Public conn As MySqlConnection
    Public LoggedInUsername As String


    Public Sub InitializeDatabase()

        Dim currentDir As IO.DirectoryInfo =
        New IO.DirectoryInfo(AppDomain.CurrentDomain.BaseDirectory)

        Dim envPath As String = Nothing

        While currentDir IsNot Nothing
            Dim candidate As String =
        IO.Path.Combine(currentDir.FullName, ".env")

            If IO.File.Exists(candidate) Then
                envPath = candidate
                Exit While
            End If

            currentDir = currentDir.Parent
        End While

        If envPath Is Nothing Then
            Throw New IO.FileNotFoundException(
        "Could not find .env. Make sure it is saved beside your .vbproj file."
    )
        End If

        DotNetEnv.Env.Load(envPath)

        Dim server = Environment.GetEnvironmentVariable("DB_SERVER")
        Dim port = Environment.GetEnvironmentVariable("DB_PORT")
        Dim dbName = Environment.GetEnvironmentVariable("DB_NAME")
        Dim dbUser = Environment.GetEnvironmentVariable("DB_USER")
        Dim dbPassword = Environment.GetEnvironmentVariable("DB_PASSWORD")

        If String.IsNullOrWhiteSpace(server) OrElse
       String.IsNullOrWhiteSpace(port) OrElse
       String.IsNullOrWhiteSpace(dbName) OrElse
       String.IsNullOrWhiteSpace(dbUser) OrElse
       dbPassword Is Nothing Then

            Throw New InvalidOperationException(
            "One or more DB settings are missing from .env."
        )
        End If

        Dim builder As New MySqlConnectionStringBuilder With {
        .Server = server,
        .Port = UInteger.Parse(port),
        .Database = dbName,
        .UserID = dbUser,
        .Password = dbPassword
    }

        conn = New MySqlConnection(builder.ConnectionString)
    End Sub


    Public Sub Connect()
        If conn.State = ConnectionState.Closed Then
            conn.Open()
        End If
    End Sub

    Public Sub Disconnect()
        If conn.State = ConnectionState.Open Then
            conn.Close()
        End If
    End Sub

    Public Sub InsertLog(username As String, action As String, details As String)
        Try
            conn.Open()
            Dim cmd As New MySqlCommand("INSERT INTO log_historyPOS (Username, Action, Details, LogTime) VALUES (@username, @action, @details, @logtime)", conn)
            cmd.Parameters.AddWithValue("@username", username)
            cmd.Parameters.AddWithValue("@action", action)
            cmd.Parameters.AddWithValue("@details", details)
            cmd.Parameters.AddWithValue("@logtime", DateTime.Now) ' use current date and time
            cmd.ExecuteNonQuery()
            conn.Close()
        Catch ex As Exception
            MessageBox.Show("Log insert failed: " & ex.Message)
            conn.Close()
        End Try
    End Sub

End Module

