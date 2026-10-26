Imports System.Windows.Forms.VisualStyles.VisualStyleElement.TrackBar
Imports MySql.Data.MySqlClient

Public Class StockOut

    Private Sub StockOut_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        LoadTodayStockOut()

        For Each column As DataGridViewColumn In dbStockOut.Columns
            column.SortMode = DataGridViewColumnSortMode.NotSortable
        Next
    End Sub

    Private Sub StockOut_Shown(sender As Object, e As EventArgs) Handles MyBase.Shown

        lblActiveDate55.Text = DateTime.Now.ToString("dddd, MMMM dd yyyy")
        lblActiveTime55.Text = DateTime.Now.ToString("hh:mm:ss tt")
        lblUsername55.Text = "User: " & frmInterface.loggedInUsername

        Tick5.Start()

        LoadTodayStockOut()
    End Sub

    Private Sub Tick5_Tick(sender As Object, e As EventArgs) Handles Tick5.Tick
        lblActiveDate55.Text = DateTime.Now.ToString("dddd, MMMM d, yyyy")
        lblActiveTime55.Text = DateTime.Now.ToString("hh:mm:ss tt")
    End Sub

    Private Sub LoadTodayStockOut()
        Try
            If conn.State = ConnectionState.Closed Then conn.Open()

            ' ✅ Include DefaultUnit and PiecesPerBox for accurate stock-out display
            Dim sql As String = "
            SELECT 
                s.TransactionNo,
                p.ProductCode,
                p.ProductName,
                si.Quantity,
                p.DefaultUnit,
                p.PiecesPerBox,
                s.SaleDate
            FROM sales_items si
            INNER JOIN sales2 s ON si.SaleID = s.SaleID
            INNER JOIN products1 p ON si.ProductID = p.ProductID
            WHERE DATE(s.SaleDate) = CURDATE()
              AND si.IsVoided = 0
              AND p.IsArchived = 0
            ORDER BY s.SaleDate DESC;
        "

            Using cmd As New MySqlCommand(sql, conn)
                Dim adapter As New MySqlDataAdapter(cmd)
                Dim table As New DataTable()
                adapter.Fill(table)

                ' ✅ Add a computed readable column
                table.Columns.Add("DisplayQty", GetType(String))

                For Each row As DataRow In table.Rows
                    Dim qty As Integer = Convert.ToInt32(row("Quantity"))
                    Dim unit As String = row("DefaultUnit").ToString().ToLower()
                    Dim ppb As Integer = If(IsDBNull(row("PiecesPerBox")), 0, Convert.ToInt32(row("PiecesPerBox")))

                    If unit = "box" AndAlso ppb > 0 Then
                        Dim totalPieces As Integer = qty * ppb
                        row("DisplayQty") = $"{qty} box(es) ({totalPieces} pcs)"
                    Else
                        row("DisplayQty") = $"{qty} pcs"
                    End If
                Next

                ' ✅ Bind to DataGridView
                dbStockOut.DataSource = table

                ' ✅ Hide raw columns
                If dbStockOut.Columns.Contains("Quantity") Then dbStockOut.Columns("Quantity").Visible = False
                If dbStockOut.Columns.Contains("DefaultUnit") Then dbStockOut.Columns("DefaultUnit").Visible = False
                If dbStockOut.Columns.Contains("PiecesPerBox") Then dbStockOut.Columns("PiecesPerBox").Visible = False

                ' ✅ Set headers and formatting
                With dbStockOut
                    .Columns("TransactionNo").HeaderText = "Transaction No"
                    .Columns("ProductCode").HeaderText = "Product Code"
                    .Columns("ProductName").HeaderText = "Product Name"
                    .Columns("DisplayQty").HeaderText = "Stock Out"
                    .Columns("SaleDate").HeaderText = "Date"
                    .Columns("SaleDate").DefaultCellStyle.Format = "yyyy-MM-dd hh:mm tt"
                End With

            End Using

        Catch ex As Exception
            MessageBox.Show("Error loading Stock Out data: " & ex.Message,
                            "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            If conn.State = ConnectionState.Open Then conn.Close()
        End Try
    End Sub

End Class