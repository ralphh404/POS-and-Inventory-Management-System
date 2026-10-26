Imports System.Windows.Forms.DataVisualization.Charting
Imports MySql.Data.MySqlClient

Public Class Dashboard
    Private chartAnimTimer As New Timer()
    Private chartTargetValues As New List(Of Double)
    Private chartCurrentStep As Integer = 0
    Private bestsellTimer As New Timer()
    Private bestsellTargets As New List(Of Double)
    Private bestsellIndex As Integer = 0

    Protected Overrides ReadOnly Property CreateParams As CreateParams
        Get
            Dim cp As CreateParams = MyBase.CreateParams
            cp.ExStyle = cp.ExStyle Or &H2000000
            Return cp
        End Get
    End Property

    Private Sub EnableChartDoubleBuffering(ctrl As Control)
        Dim prop = GetType(Control).GetProperty("DoubleBuffered",
        Reflection.BindingFlags.NonPublic Or Reflection.BindingFlags.Instance)

        prop.SetValue(ctrl, True, Nothing)
    End Sub

    Public Sub DashboardLoad()
        Try
            If conn.State = ConnectionState.Closed Then conn.Open()

            Dim totalstkPieces As Integer = 0
            Dim totalstkBoxes As Integer = 0

            Using cmd As New MySqlCommand("
            SELECT DefaultUnit, StockQty, PiecesPerBox
            FROM products1
            WHERE IsArchived = 0", conn)

                Using reader = cmd.ExecuteReader()
                    While reader.Read()
                        Dim unit As String = reader("DefaultUnit").ToString().Trim().ToLower()
                        Dim stockQty As Integer = If(IsDBNull(reader("StockQty")), 0, Convert.ToInt32(reader("StockQty")))
                        Dim pcsPerBox As Integer = 1
                        Integer.TryParse(If(reader("PiecesPerBox") Is DBNull.Value, "1", reader("PiecesPerBox").ToString()), pcsPerBox)

                        If unit = "box" AndAlso pcsPerBox > 0 Then
                            ' StockQty is stored as pieces → convert to boxes + leftover pieces
                            Dim boxes As Integer = stockQty \ pcsPerBox
                            Dim loosePieces As Integer = stockQty Mod pcsPerBox

                            totalstkBoxes += boxes
                            totalstkPieces += loosePieces
                        Else
                            ' unit = "piece" (or fallback) — count as pieces directly
                            totalstkPieces += stockQty
                        End If
                    End While
                End Using
            End Using

            lblPiece.Text = $"{totalstkPieces:N0} pcs"
            lblBox.Text = $"{totalstkBoxes:N0} box(es)"

            Using cmd As New MySqlCommand("
            SELECT SUM(si.SubTotal)
            FROM sales_items si
            INNER JOIN sales2 s ON si.SaleID = s.SaleID
            INNER JOIN products1 p ON si.ProductID = p.ProductID
            WHERE DATE(s.SaleDate) = CURDATE()
              AND si.IsVoided = 0
              AND p.IsArchived = 0", conn)

                Dim result = cmd.ExecuteScalar()
                lblSalesValue.Text = If(IsDBNull(result), "₱0.00",
                FormatCurrency(result, 2, TriState.True, TriState.True, TriState.True))
            End Using

        Catch ex As Exception
            MessageBox.Show("Dashboard load error: " & ex.Message, "Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            If conn.State = ConnectionState.Open Then conn.Close()
        End Try
    End Sub

    Private Sub LoadStockStatusChart()
        Try
            If conn.State = ConnectionState.Closed Then conn.Open()

            Dim lowStockThreshold As Integer = 30
            Dim inStockCount As Integer = 0
            Dim lowStockCount As Integer = 0
            Dim outOfStockCount As Integer = 0

            Using cmd As New MySqlCommand("
            SELECT StockQty, DefaultUnit, PiecesPerBox
            FROM products1 
            WHERE IsArchived = 0", conn)

                Using reader = cmd.ExecuteReader()
                    While reader.Read()

                        Dim qty As Integer = If(IsDBNull(reader("StockQty")), 0, Convert.ToInt32(reader("StockQty")))

                        Dim defaultUnit As String = ""
                        If Not IsDBNull(reader("DefaultUnit")) Then
                            defaultUnit = reader("DefaultUnit").ToString().ToLower()
                        End If

                        Dim pcsPerBox As Integer = 0
                        If Not IsDBNull(reader("PiecesPerBox")) Then
                            Integer.TryParse(reader("PiecesPerBox").ToString(), pcsPerBox)
                        End If


                        If qty = 0 Then
                            outOfStockCount += 1


                        ElseIf defaultUnit.Contains("box") AndAlso pcsPerBox > 0 Then

                            Dim boxes As Double = qty / pcsPerBox

                            If boxes <= lowStockThreshold Then
                                lowStockCount += 1
                            Else
                                inStockCount += 1
                            End If


                        Else

                            If qty <= lowStockThreshold Then
                                lowStockCount += 1
                            Else
                                inStockCount += 1
                            End If

                        End If

                    End While
                End Using
            End Using

            ChartStock.Series.Clear()
            ChartStock.ChartAreas.Clear()
            ChartStock.Titles.Clear()
            ChartStock.Legends.Clear()


            Dim area As New DataVisualization.Charting.ChartArea("MainArea")
            With area
                .AxisX.MajorGrid.Enabled = False
                .AxisY.MajorGrid.Enabled = False
                .AxisX.LabelStyle.Enabled = False
                .AxisY.LabelStyle.Enabled = False
                .AxisX.MajorTickMark.Enabled = False
                .AxisY.MajorTickMark.Enabled = False
                .AxisX.LineWidth = 0
                .AxisY.LineWidth = 0
                .BorderWidth = 0
                .BackColor = Color.GhostWhite
            End With
            ChartStock.ChartAreas.Add(area)


            Dim createSeries = Function(name As String, color As Color, value As Integer) As DataVisualization.Charting.Series
                                   Dim s As New DataVisualization.Charting.Series(name)
                                   s.ChartType = DataVisualization.Charting.SeriesChartType.Column
                                   s.Points.AddXY(name, value)
                                   s.Points(0).Color = color
                                   s.IsValueShownAsLabel = True
                                   s.LabelForeColor = Color.FromArgb(45, 45, 45)
                                   s.Font = New Font("Century Gothic", 11, FontStyle.Bold)
                                   s("PointWidth") = "0.7" ' 🔹 thicker bars
                                   s.LegendText = name
                                   Return s
                               End Function


            Dim sInStock = createSeries("In Stock", Color.CornflowerBlue, inStockCount)
            Dim sLowStock = createSeries("Low Stock", Color.FromArgb(241, 196, 15), lowStockCount)
            Dim sOutStock = createSeries("Out of Stock", Color.FromArgb(231, 76, 60), outOfStockCount)

            ChartStock.Series.Add(sInStock)
            ChartStock.Series.Add(sLowStock)
            ChartStock.Series.Add(sOutStock)


            Dim legend As New DataVisualization.Charting.Legend("Legend1")
            With legend
                .Docking = DataVisualization.Charting.Docking.Bottom
                .Alignment = StringAlignment.Center
                .Font = New Font("Century Gothic", 6, FontStyle.Regular)
                .BackColor = Color.Gainsboro
                .ForeColor = Color.FromArgb(60, 60, 60)
                .IsTextAutoFit = False
            End With
            ChartStock.Legends.Add(legend)


            ChartStock.Titles.Add(New DataVisualization.Charting.Title(
            "Stock Overview",
            DataVisualization.Charting.Docking.Top,
            New Font("Century Gothic", 9, FontStyle.Bold),
            Color.FromArgb(60, 60, 60)
        ))


            ChartStock.BackColor = Color.Gainsboro
            ChartStock.BorderlineWidth = 0
            ChartStock.ChartAreas("MainArea").Area3DStyle.Enable3D = False
            ChartStock.ChartAreas("MainArea").InnerPlotPosition = New DataVisualization.Charting.ElementPosition(12, 5, 75, 85)


            ChartStock.ApplyPaletteColors()

        Catch ex As Exception
            MessageBox.Show("Error loading stock chart: " & ex.Message)
        Finally
            If conn.State = ConnectionState.Open Then conn.Close()
        End Try
    End Sub

    Private Sub SoldChart()
        chartTargetValues.Clear()
        Try
            If conn.State = ConnectionState.Closed Then conn.Open()

            Dim cmd As New MySqlCommand("
                SELECT
                    p.ProductName,
                    SUM(si.Quantity) AS QtySold,
                    MAX(p.DefaultUnit) AS DefaultUnit,
                    MAX(p.PiecesPerBox) AS PiecesPerBox,

                    SUM(
                        CASE
                            WHEN LOWER(p.DefaultUnit) = 'box' AND p.PiecesPerBox > 0
                                THEN si.Quantity * p.PiecesPerBox
                            ELSE
                                si.Quantity
                        END
                    ) AS TotalSold

                FROM sales_items si
                INNER JOIN sales2 s ON si.SaleID = s.SaleID
                INNER JOIN products1 p ON si.ProductID = p.ProductID

                WHERE DATE(s.SaleDate) = CURDATE()
                AND si.IsVoided = 0
                AND p.IsArchived = 0

                GROUP BY p.ProductID, p.ProductName

                ORDER BY TotalSold DESC

                LIMIT 5;
                ", conn)

            Dim reader As MySqlDataReader = cmd.ExecuteReader()


            With chartsold
                .Series.Clear()
                .Titles.Clear()
                .Legends.Clear()

                .BackColor = Color.FromArgb(235, 236, 240) ' soft neutral gray
                .BorderlineColor = Color.FromArgb(210, 212, 218)
                .BorderlineDashStyle = ChartDashStyle.Solid

                .AntiAliasing = AntiAliasingStyles.All
                .TextAntiAliasingQuality = TextAntiAliasingQuality.High
            End With


            Dim series As New Series("Top Products")
            series.ChartType = SeriesChartType.Bar
            series.IsValueShownAsLabel = True

            series("PointWidth") = "0.65"

            series.Font = New Font("Segoe UI", 9, FontStyle.Regular)
            series.LabelForeColor = Color.FromArgb(60, 60, 60)

            Dim index As Integer = 1

            While reader.Read()
                Dim pt As New DataPoint()

                pt.XValue = index
                pt.AxisLabel = reader("ProductName").ToString()
                Dim unit As String = reader("DefaultUnit").ToString().ToLower()
                Dim qtySold As Integer = Convert.ToInt32(reader("QtySold"))
                Dim totalPieces As Integer = Convert.ToInt32(reader("TotalSold"))

                chartTargetValues.Add(totalPieces)

                pt.YValues = New Double() {0}

                If unit = "box" Then
                    pt.Label = $"{qtySold:N0} box(es) ({totalPieces:N0} pcs)"
                Else
                    pt.Label = $"{qtySold:N0} piece(s)"
                End If

                series.Points.Add(pt)
                index += 1
            End While

            reader.Close()

            chartsold.Series.Add(series)

            chartsold.SuppressExceptions = True

            ' ✅ Fix chart scaling so bars can grow
            If chartTargetValues.Count > 0 Then
                chartsold.ChartAreas(0).AxisY.Minimum = 0
                chartsold.ChartAreas(0).AxisY.Maximum = chartTargetValues.Max() * 1.2
            End If


            chartCurrentStep = 0
            chartAnimTimer.Interval = 15 ' speed (lower = faster)

            AddHandler chartAnimTimer.Tick, AddressOf AnimateChart
            chartAnimTimer.Start()


            Dim title As New Title()
            title.Text = "Items Sold Today"
            title.Font = New Font("Segoe UI Semibold", 14, FontStyle.Regular)
            title.ForeColor = Color.FromArgb(40, 40, 40)
            chartsold.Titles.Add(title)


            With chartsold.ChartAreas(0)

                ' darker neutral surface (THIS fixes “too white” issue)
                .BackColor = Color.FromArgb(225, 227, 232)

                .BackSecondaryColor = Color.FromArgb(215, 218, 225)
                .BackGradientStyle = GradientStyle.TopBottom

                .AxisX.MajorGrid.Enabled = False
                .AxisY.MajorGrid.LineColor = Color.FromArgb(200, 203, 210)

                .AxisX.LineColor = Color.FromArgb(185, 188, 195)
                .AxisY.LineColor = Color.FromArgb(185, 188, 195)

                .AxisX.LabelStyle.Font = New Font("Segoe UI", 9)
                .AxisX.LabelStyle.ForeColor = Color.FromArgb(70, 70, 75)

                .AxisY.LabelStyle.Font = New Font("Segoe UI", 9)
                .AxisY.LabelStyle.ForeColor = Color.FromArgb(90, 90, 95)

                .AxisX.Interval = 1
                .AxisY.IsStartedFromZero = True

            End With


            Dim colors() As Color = {
            Color.FromArgb(64, 124, 214),  ' muted blue
            Color.FromArgb(72, 160, 120),  ' muted green
            Color.FromArgb(220, 165, 60),  ' muted amber
            Color.FromArgb(200, 90, 90),   ' muted red
            Color.FromArgb(130, 110, 180)  ' muted purple
        }

            For i As Integer = 0 To series.Points.Count - 1

                Dim c As Color = colors(i Mod colors.Length)

                With series.Points(i)
                    .Color = c

                    ' soft separation (no white pop)
                    .BorderColor = Color.FromArgb(225, 227, 232)
                    .BorderWidth = 1


                    .LabelForeColor = Color.FromArgb(50, 50, 50)
                End With

            Next

        Catch ex As Exception
            MessageBox.Show(ex.Message)
        Finally
            If conn.State = ConnectionState.Open Then conn.Close()
        End Try
    End Sub

    Private Sub AnimateChart(sender As Object, e As EventArgs)
        If chartsold.Series.Count = 0 OrElse chartTargetValues.Count = 0 Then
            chartAnimTimer.Stop()
            Exit Sub
        End If

        Try
            Dim series = chartsold.Series(0)

            Dim done As Boolean = True

            For i As Integer = 0 To series.Points.Count - 1
                Dim current = series.Points(i).YValues(0)
                Dim target = chartTargetValues(i)

                Dim stepValue = Math.Max(target / 35, 0.3)

                If current < target Then
                    current += stepValue
                    If current > target Then current = target

                    series.Points(i).YValues(0) = current
                    done = False
                End If
            Next

            chartsold.Series(0).Points.Invalidate()

            If done Then
                chartAnimTimer.Stop()
                RemoveHandler chartAnimTimer.Tick, AddressOf AnimateChart
            End If

        Catch ex As Exception
            chartAnimTimer.Stop()
        End Try
    End Sub

    Private Sub BestSellChart()
        bestsellTargets.Clear()
        Try
            If conn.State = ConnectionState.Closed Then conn.Open()

            Dim cmd As New MySqlCommand("
        SELECT 
            p.ProductName,
            SUM(si.SubTotal) AS TotalRevenue
        FROM sales_items si
        INNER JOIN sales2 s ON si.SaleID = s.SaleID
        INNER JOIN products1 p ON si.ProductID = p.ProductID
        WHERE DATE(s.SaleDate) = CURDATE()
          AND si.IsVoided = 0
          AND p.IsArchived = 0
        GROUP BY p.ProductID, p.ProductName
        ORDER BY TotalRevenue DESC
        LIMIT 5
        ", conn)

            Dim reader As MySqlDataReader = cmd.ExecuteReader()


            bestsell.Series.Clear()
            bestsell.ChartAreas.Clear()
            bestsell.Titles.Clear()
            bestsell.Legends.Clear()


            bestsell.BackColor = Color.FromArgb(235, 236, 240)
            bestsell.BorderlineColor = Color.FromArgb(210, 212, 218)
            bestsell.BorderlineWidth = 1


            Dim area As New ChartArea("PieArea")
            With area
                .BackColor = Color.FromArgb(225, 227, 232)
                .BackSecondaryColor = Color.FromArgb(215, 218, 225)
                .BackGradientStyle = GradientStyle.TopBottom
            End With
            bestsell.ChartAreas.Add(area)


            Dim series As New Series("BestSelling")
            series.ChartType = SeriesChartType.Doughnut
            series("DoughnutRadius") = "67"

            series.Label = "#PERCENT{P0}"
            series.IsValueShownAsLabel = True
            series.Font = New Font("Segoe UI", 9, FontStyle.Regular)
            series.LabelForeColor = Color.FromArgb(60, 60, 60)

            series("PieLabelStyle") = "Outside"
            series("PieLineColor") = "Silver"

            series.BorderColor = Color.FromArgb(225, 227, 232)
            series.BorderWidth = 1


            While reader.Read()
                Dim name As String = reader("ProductName").ToString()
                Dim total As Decimal = Convert.ToDecimal(reader("TotalRevenue"))

                Dim idx = series.Points.AddXY(name, 0) ' start at 0
                bestsellTargets.Add(total)

                series.Points(idx).ToolTip = name & " - ₱" & total.ToString("N2")
                series.Points(idx).LegendText = name
            End While

            reader.Close()
            bestsell.Series.Add(series)


            Dim colors() As Color = {
            Color.FromArgb(64, 124, 214),  ' muted blue
            Color.FromArgb(72, 160, 120),  ' muted green
            Color.FromArgb(220, 165, 60),  ' muted amber
            Color.FromArgb(200, 90, 90),   ' muted red
            Color.FromArgb(130, 110, 180)  ' muted purple
        }

            For i As Integer = 0 To series.Points.Count - 1
                With series.Points(i)
                    .Color = colors(i Mod colors.Length)
                    .BorderColor = Color.FromArgb(235, 236, 240)
                    .BorderWidth = 2
                End With
            Next


            Dim legend As New Legend()
            With legend
                .Docking = Docking.Right
                .Alignment = StringAlignment.Center
                .Font = New Font("Segoe UI", 9, FontStyle.Regular)

                .BackColor = Color.White
                .BorderColor = Color.FromArgb(210, 212, 218)
                .BorderWidth = 1
            End With
            bestsell.Legends.Add(legend)


            Dim title As New Title()
            title.Text = "Best Selling Products Today"
            title.Font = New Font("Segoe UI Semibold", 12, FontStyle.Bold)
            title.ForeColor = Color.FromArgb(40, 40, 40)
            bestsell.Titles.Add(title)


            bestsell.AntiAliasing = AntiAliasingStyles.All
            bestsell.TextAntiAliasingQuality = TextAntiAliasingQuality.High

        Catch ex As Exception
            MessageBox.Show("Error loading best seller chart: " & ex.Message)
        Finally
            If conn.State = ConnectionState.Open Then conn.Close()
        End Try

        bestsellIndex = 0
        bestsellTimer.Interval = 10 ' smoother feel

        RemoveHandler bestsellTimer.Tick, AddressOf AnimateBestSell
        AddHandler bestsellTimer.Tick, AddressOf AnimateBestSell

        bestsellTimer.Start()
    End Sub

    Private Sub AnimateBestSell(sender As Object, e As EventArgs)

        If bestsell.Series.Count = 0 OrElse bestsellTargets.Count = 0 Then
            bestsellTimer.Stop()
            Exit Sub
        End If

        Dim series = bestsell.Series(0)

        If bestsellIndex >= series.Points.Count Then
            bestsellTimer.Stop()
            RemoveHandler bestsellTimer.Tick, AddressOf AnimateBestSell
            Exit Sub
        End If

        Dim current = series.Points(bestsellIndex).YValues(0)
        Dim target = bestsellTargets(bestsellIndex)

        ' 🔥 SMOOTH EASING (instead of fixed step)
        Dim diff = target - current
        Dim stepValue = diff * 0.3 ' speed factor

        ' prevent super slow finish
        If stepValue < 0.8 Then stepValue = 0.8

        If current < target Then
            current += stepValue
            If current > target Then current = target

            series.Points(bestsellIndex).YValues(0) = current
        Else
            ' move to next slice when done
            bestsellIndex += 1
        End If

        bestsell.Invalidate()

    End Sub

    Private Sub Dashboard_Shown(sender As Object, e As EventArgs) Handles MyBase.Shown
        lblActiveDate.Text = DateTime.Now.ToString("dddd, MMMM dd yyyy")
        lblActiveTime.Text = DateTime.Now.ToString("hh:mm:ss tt")
        lblUsername.Text = "User: " & frmInterface.loggedInUsername

        TimerDateTime.Start()
    End Sub


    Private Sub TimerDateTime_Tick(sender As Object, e As EventArgs) Handles TimerDateTime.Tick
        lblActiveDate.Text = DateTime.Now.ToString("dddd, MMMM d, yyyy")
        lblActiveTime.Text = DateTime.Now.ToString("hh:mm:ss tt")
    End Sub

    Private Sub Dashboard(sender As Object, e As EventArgs) Handles MyBase.Load
        EnableChartDoubleBuffering(chartsold)
        EnableChartDoubleBuffering(ChartStock)

        RefreshDashboard()
    End Sub

    Public Sub RefreshDashboard()
        DashboardLoad()
        LoadStockStatusChart()
        SoldChart()
        BestSellChart()
    End Sub

End Class
