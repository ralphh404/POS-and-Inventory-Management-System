Imports MySql.Data.MySqlClient
Imports Windows.Win32.System

Public Class StockHistory

    Private Sub StockHistory_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ' Disable sorting for consistent view
        For Each col As DataGridViewColumn In dbhistory.Columns
            col.SortMode = DataGridViewColumnSortMode.NotSortable
        Next

        ' Load history when form opens
        LoadStockHistory()
    End Sub

    ' ✅ Load and filter stock-in history (joined by ProductName + Unit)
    Public Sub LoadStockHistory(Optional fromDate As Date? = Nothing, Optional toDate As Date? = Nothing)
        Try
            If conn.State <> ConnectionState.Open Then conn.Open()

            Dim query As String = "
            SELECT 
                p.ProductCode,
                si.ProductName,
                si.Quantity,
                si.Unit,
                si.TotalPieces,
                si.Remarks,
                si.DateAdded
            FROM stockin_history1 si
            LEFT JOIN products1 p 
                ON si.ProductName = p.ProductName 
                AND si.Unit = p.DefaultUnit
            WHERE 1=1"

            ' 🔹 Optional date filter
            If fromDate.HasValue AndAlso toDate.HasValue Then
                query &= " AND si.DateAdded BETWEEN @from AND @to"
            End If

            query &= " ORDER BY si.DateAdded DESC;"

            Using cmd As New MySqlCommand(query, conn)
                If fromDate.HasValue AndAlso toDate.HasValue Then
                    cmd.Parameters.AddWithValue("@from", fromDate.Value.Date)
                    cmd.Parameters.AddWithValue("@to", toDate.Value.Date.AddDays(1).AddSeconds(-1))
                End If

                Dim da As New MySqlDataAdapter(cmd)
                Dim dt As New DataTable()
                da.Fill(dt)

                ' ✅ Transform display (Box/Piece text)
                For Each row As DataRow In dt.Rows
                    Dim unit As String = row("Unit").ToString().ToLower()
                    Dim qty As Integer = Convert.ToInt32(row("Quantity"))
                    If unit = "box" Then
                        row("Unit") = $"{qty} Box(es)"
                    Else
                        row("Unit") = $"{qty} Piece(s)"
                    End If
                Next

                dbhistory.DataSource = dt

                ' ✅ Column formatting
                With dbhistory
                    .Columns("ProductCode").HeaderText = "Product Code"
                    .Columns("ProductName").HeaderText = "Product"
                    .Columns("Quantity").Visible = False ' hide raw qty
                    .Columns("Unit").HeaderText = "Added"
                    .Columns("TotalPieces").HeaderText = "Total Pieces"
                    .Columns("Remarks").HeaderText = "Remarks"
                    .Columns("DateAdded").HeaderText = "Date"
                    .Columns("DateAdded").DefaultCellStyle.Format = "MM/dd/yyyy hh:mm tt"
                End With
            End Using

        Catch ex As Exception
            MessageBox.Show("Error loading stock history: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            If conn.State = ConnectionState.Open Then conn.Close()
        End Try
    End Sub

    ' ✅ Filter by date range
    Private Sub dtpFrom_ValueChanged(sender As Object, e As EventArgs) Handles dtpFrom.ValueChanged
        If dtpFrom.Value > dtpTo.Value Then
            dtpTo.Value = dtpFrom.Value
        End If
        LoadStockHistory(dtpFrom.Value, dtpTo.Value)
    End Sub

    Private Sub dtpTo_ValueChanged(sender As Object, e As EventArgs) Handles dtpTo.ValueChanged
        If dtpTo.Value < dtpFrom.Value Then
            dtpFrom.Value = dtpTo.Value
        End If
        LoadStockHistory(dtpFrom.Value, dtpTo.Value)
    End Sub

    ' ✅ Close button
    Private Sub btnClose_Click(sender As Object, e As EventArgs) Handles btnClose.Click
        Me.Close()
    End Sub

End Class


