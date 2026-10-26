Imports MySql.Data.MySqlClient

Public Class StockAlert
    Private FadeTimer As New Timer()
    Private FadeDirection As Integer = 1
    Private NotifiedOnce As Boolean = False

    Private Sub StockAlert_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        LoadStockAlerts()

        ' Disable sorting
        For Each column As DataGridViewColumn In dbLow.Columns
            column.SortMode = DataGridViewColumnSortMode.NotSortable
        Next
        For Each column As DataGridViewColumn In dbOut.Columns
            column.SortMode = DataGridViewColumnSortMode.NotSortable
        Next

        ' Fade-in effect
        Me.Opacity = 0
        FadeTimer.Interval = 20
        AddHandler FadeTimer.Tick, AddressOf FadeEffect
        FadeTimer.Start()
    End Sub

    Private Sub FadeEffect(sender As Object, e As EventArgs)
        If FadeDirection = 1 Then
            If Me.Opacity < 1 Then
                Me.Opacity += 0.1
            Else
                FadeTimer.Stop()
            End If
        Else
            If Me.Opacity > 0 Then
                Me.Opacity -= 0.1
            Else
                FadeTimer.Stop()
                Me.Close()
            End If
        End If
    End Sub

    Private Sub LoadStockAlerts()
        Try
            If conn.State = ConnectionState.Closed Then conn.Open()

            Dim query As String = "
        SELECT 
            ProductID,
            ProductName,
            StockQty,
            PiecesPerBox,
            IsArchived
        FROM products1
        WHERE IsArchived = 0;"

            Dim dt As New DataTable()
            Using cmd As New MySqlCommand(query, conn)
                Dim da As New MySqlDataAdapter(cmd)
                da.Fill(dt)
            End Using

            ' === Create new tables for Low & Out of Stock ===
            Dim dtLow As New DataTable()
            dtLow.Columns.Add("ProductName", GetType(String))
            dtLow.Columns.Add("Quantity", GetType(Double))
            dtLow.Columns.Add("UnitType", GetType(String))

            Dim dtOut As New DataTable()
            dtOut.Columns.Add("ProductName", GetType(String))
            dtOut.Columns.Add("Quantity", GetType(Double))
            dtOut.Columns.Add("UnitType", GetType(String))

            For Each row As DataRow In dt.Rows
                Dim stockQty As Double = Convert.ToDouble(row("StockQty"))
                Dim ppb As Double = If(IsDBNull(row("PiecesPerBox")), 0, Convert.ToDouble(row("PiecesPerBox")))

                Dim unitType As String
                Dim displayQty As Double

                ' ✅ Identify whether product is per box or per piece
                If ppb > 1 Then
                    ' Product uses boxes
                    displayQty = Math.Floor(stockQty / ppb)
                    unitType = "Box"
                Else
                    ' Product is sold per piece (or PiecesPerBox = 0/1)
                    displayQty = stockQty
                    unitType = "Piece"
                End If

                ' ✅ Categorize
                If stockQty = 0 Then
                    dtOut.Rows.Add(row("ProductName").ToString(), 0, unitType)
                ElseIf displayQty <= 30 Then
                    dtLow.Rows.Add(row("ProductName").ToString(), displayQty, unitType)
                End If
            Next

            dbLow.DataSource = dtLow
            dbOut.DataSource = dtOut

            With dbLow
                .Columns("ProductName").HeaderText = "Product"
                .Columns("Quantity").HeaderText = "Quantity Left"
                .Columns("UnitType").HeaderText = "Unit"
                .AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
            End With

            With dbOut
                .Columns("ProductName").HeaderText = "Product"
                .Columns("Quantity").HeaderText = "Quantity Left"
                .Columns("UnitType").HeaderText = "Unit"
                .AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
            End With

            ' === Notify only once ===
            If Not NotifiedOnce Then
                If dtLow.Rows.Count > 0 Then
                    MessageBox.Show("Some products are running low.", "Low Stock", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                End If
                If dtOut.Rows.Count > 0 Then
                    MessageBox.Show("Some products are out of stock!", "Out of Stock", MessageBoxButtons.OK, MessageBoxIcon.Error)
                End If
                NotifiedOnce = True
            End If

        Catch ex As Exception
            MessageBox.Show("Error loading stock alerts: " & ex.Message)
        Finally
            If conn.State = ConnectionState.Open Then conn.Close()
        End Try
    End Sub

    Private Sub btnClose_Click(sender As Object, e As EventArgs) Handles btnClose.Click
        FadeDirection = -1
        FadeTimer.Start()
    End Sub
End Class

