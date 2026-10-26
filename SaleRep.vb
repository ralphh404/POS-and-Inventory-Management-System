Imports MySql.Data.MySqlClient
Imports QuestPDF.Fluent
Imports QuestPDF.Helpers
Imports QuestPDF.Infrastructure
Imports System.Globalization
Imports System.IO
Imports System.Diagnostics


Public Class SaleRep
    Private Sub SaleRep(sender As Object, e As EventArgs) Handles MyBase.Load

        Me.Opacity = 0

        Dim fadeTimer As New Timer With {.Interval = 10}
        AddHandler fadeTimer.Tick,
            Sub()
                If Me.Opacity < 1 Then
                    Me.Opacity += 0.1
                Else
                    fadeTimer.Stop()
                End If
            End Sub
        fadeTimer.Start()

        LoadSales()

        For Each column As DataGridViewColumn In dbSales.Columns
            column.SortMode = DataGridViewColumnSortMode.NotSortable
        Next

        Try
            PictureBox3.Image = My.Resources.silver_membership_icon_default_avatar_profile_icon_membership_icon_social_media_user_image_illustration_vector
            MakePictureRound(PictureBox3)
        Catch ex As Exception
            MessageBox.Show("Failed to load profile picture: " & ex.Message,
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End Try

    End Sub

    Private Sub MakePictureRound(pic As PictureBox)
        If pic.Image Is Nothing Then Exit Sub
        Dim diameter As Integer = Math.Min(pic.Width, pic.Height)
        Dim bmp As New Bitmap(diameter, diameter)

        Using g As Graphics = Graphics.FromImage(bmp)
            g.SmoothingMode = Drawing2D.SmoothingMode.AntiAlias
            Dim gp As New Drawing2D.GraphicsPath()
            gp.AddEllipse(0, 0, diameter, diameter)
            g.SetClip(gp)
            g.Clear(System.Drawing.Color.Transparent)
            g.DrawImage(pic.Image, New Rectangle(0, 0, diameter, diameter),
                            New Rectangle(0, 0, pic.Image.Width, pic.Image.Height), GraphicsUnit.Pixel)
        End Using

        pic.Image = bmp
        Dim regionPath As New Drawing2D.GraphicsPath()
        regionPath.AddEllipse(0, 0, diameter, diameter)
        pic.Region = New Region(regionPath)
    End Sub

    Private Sub dtFrom_ValueChanged(sender As Object, e As EventArgs) Handles dtFrom.ValueChanged
        If dtFrom.Value > dtTo.Value Then
            dtTo.Value = dtFrom.Value
        End If
        LoadSales()
    End Sub

    Private Sub dtTo_ValueChanged(sender As Object, e As EventArgs) Handles dtTo.ValueChanged
        If dtTo.Value < dtFrom.Value Then
            dtFrom.Value = dtTo.Value
        End If
        LoadSales()
    End Sub

    Private Sub LoadSales()
        Try
            If conn.State = ConnectionState.Closed Then conn.Open()

            Dim sql As String = "
            SELECT 
                s.TransactionNo,
                p.ProductCode,
                p.ProductName,
                si.Quantity,
                si.Price,
                si.SubTotal,
                p.DefaultUnit,
                p.PiecesPerBox,
                s.SaleDate
            FROM sales_items si
            INNER JOIN sales2 s ON si.SaleID = s.SaleID
            INNER JOIN products1 p ON si.ProductID = p.ProductID
            WHERE DATE(s.SaleDate) BETWEEN @from AND @to
              AND si.IsVoided = 0
              AND p.IsArchived = 0
            ORDER BY s.SaleDate DESC"

            Using cmd As New MySqlCommand(sql, conn)
                cmd.Parameters.AddWithValue("@from", dtFrom.Value.Date)
                cmd.Parameters.AddWithValue("@to", dtTo.Value.Date)

                Dim adapter As New MySqlDataAdapter(cmd)
                Dim table As New DataTable()
                adapter.Fill(table)

                ' ✅ Add readable display quantity
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

                ' ✅ Show DisplayQty instead of raw Quantity
                dbSales.DataSource = table

                ' Hide internal columns
                If dbSales.Columns.Contains("Quantity") Then dbSales.Columns("Quantity").Visible = False
                If dbSales.Columns.Contains("DefaultUnit") Then dbSales.Columns("DefaultUnit").Visible = False
                If dbSales.Columns.Contains("PiecesPerBox") Then dbSales.Columns("PiecesPerBox").Visible = False

                ' Headers & formats
                If dbSales.Columns.Contains("DisplayQty") Then
                    dbSales.Columns("DisplayQty").HeaderText = "Quantity"
                End If
                If dbSales.Columns.Contains("SubTotal") Then
                    dbSales.Columns("SubTotal").HeaderText = "Total Sales"
                    dbSales.Columns("SubTotal").DefaultCellStyle.Format = "C2"
                    dbSales.Columns("SubTotal").DefaultCellStyle.FormatProvider = New CultureInfo("en-PH")
                End If
                If dbSales.Columns.Contains("Price") Then
                    dbSales.Columns("Price").DefaultCellStyle.Format = "C2"
                    dbSales.Columns("Price").DefaultCellStyle.FormatProvider = New CultureInfo("en-PH")
                End If
                If dbSales.Columns.Contains("SaleDate") Then
                    dbSales.Columns("SaleDate").DefaultCellStyle.Format = "yyyy-MM-dd hh:mm tt"
                End If

                ' ✅ Calculate total safely
                Dim total As Decimal = 0D
                For Each r As DataRow In table.Rows
                    If Not IsDBNull(r("SubTotal")) Then
                        total += Convert.ToDecimal(r("SubTotal"))
                    End If
                Next
                lblTotalS.Text = FormatCurrency(total, 2)
            End Using

        Catch ex As Exception
            MessageBox.Show("Error loading sales: " & ex.Message,
                        "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            If conn.State = ConnectionState.Open Then conn.Close()
        End Try
    End Sub

    Private Sub btnPrint_Click(sender As Object, e As EventArgs) Handles btnPrint.Click
        Try
            QuestPDF.Settings.License = LicenseType.Community

            If dbSales.Rows.Count = 0 Then
                MessageBox.Show("No sales data to print.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Return
            End If

            ' === Collect data from DataGridView ===
            Dim salesData As New List(Of Dictionary(Of String, Object))
            For Each row As DataGridViewRow In dbSales.Rows
                If row.IsNewRow Then Continue For
                Dim rec As New Dictionary(Of String, Object)
                For Each col As DataGridViewColumn In dbSales.Columns
                    rec(col.Name) = If(row.Cells(col.Index).Value, "")
                Next
                salesData.Add(rec)
            Next

            ' === Header info ===
            Dim fromDateStr As String = dtFrom.Value.ToString("MMMM dd, yyyy")
            Dim toDateStr As String = dtTo.Value.ToString("MMMM dd, yyyy")
            Dim totalSalesText As String = lblTotalS.Text

            ' === Build PDF ===
            Dim pdfDoc = Document.Create(Sub(container)
                                             container.Page(Sub(page)
                                                                page.Size(PageSizes.A4.Landscape())
                                                                page.Margin(40)
                                                                page.DefaultTextStyle(Function(t) t.FontSize(10).FontFamily("Arial"))

                                                                ' === HEADER ===
                                                                page.Header().Column(Sub(h)
                                                                                         h.Item().AlignCenter().Text("MEDENT+ SALES REPORT").FontSize(16).Bold()
                                                                                         h.Item().AlignCenter().Text($"({fromDateStr} - {toDateStr})").FontSize(11)
                                                                                         h.Item().PaddingVertical(6).LineHorizontal(1)
                                                                                     End Sub)

                                                                ' === CONTENT ===
                                                                page.Content().Column(Sub(c)
                                                                                          ' Table
                                                                                          c.Item().Table(Sub(table)
                                                                                                             ' --- Columns ---
                                                                                                             table.ColumnsDefinition(Sub(cols)
                                                                                                                                         cols.ConstantColumn(120)  ' Trans No
                                                                                                                                         cols.ConstantColumn(100)  ' Code
                                                                                                                                         cols.RelativeColumn(2)    ' Product
                                                                                                                                         cols.RelativeColumn(1.3F) ' Quantity (Unit)
                                                                                                                                         cols.ConstantColumn(90)   ' Price
                                                                                                                                         cols.ConstantColumn(100)  ' Total
                                                                                                                                         cols.ConstantColumn(150)  ' Date
                                                                                                                                     End Sub)

                                                                                                             ' --- Header Row ---
                                                                                                             Dim headers = {"Trans No", "Code", "Product", "Quantity (Unit)", "Price", "Total", "Date"}
                                                                                                             table.Header(Sub(hd)
                                                                                                                              For Each head In headers
                                                                                                                                  hd.Cell().Background(Colors.Grey.Lighten3).Padding(5).AlignCenter().Text(head).Bold()
                                                                                                                              Next
                                                                                                                          End Sub)

                                                                                                             ' --- Data Rows ---
                                                                                                             Dim rowIndex As Integer = 0
                                                                                                             For Each r In salesData
                                                                                                                 Dim bg = If(rowIndex Mod 2 = 0, Colors.White, Colors.Grey.Lighten5)

                                                                                                                 table.Cell().Background(bg).Padding(5).AlignLeft().Text(SafeVal(r, "TransactionNo"))
                                                                                                                 table.Cell().Background(bg).Padding(5).AlignLeft().Text(SafeVal(r, "ProductCode"))
                                                                                                                 table.Cell().Background(bg).Padding(5).AlignLeft().Text(SafeVal(r, "ProductName"))

                                                                                                                 ' ✅ show formatted quantity w/ unit info
                                                                                                                 table.Cell().Background(bg).Padding(5).AlignCenter().Text(SafeVal(r, "DisplayQty"))

                                                                                                                 ' ✅ Currency formatting aligned to right
                                                                                                                 Dim price As Decimal
                                                                                                                 Decimal.TryParse(SafeVal(r, "Price"), price)
                                                                                                                 table.Cell().Background(bg).Padding(5).AlignRight().Text(price.ToString("C2", New CultureInfo("en-PH")))

                                                                                                                 Dim total As Decimal
                                                                                                                 Decimal.TryParse(SafeVal(r, "SubTotal"), total)
                                                                                                                 table.Cell().Background(bg).Padding(5).AlignRight().Text(total.ToString("C2", New CultureInfo("en-PH")))

                                                                                                                 ' ✅ formatted sale date
                                                                                                                 Dim dateStr As String = SafeVal(r, "SaleDate")
                                                                                                                 Dim saleDate As DateTime
                                                                                                                 If DateTime.TryParse(dateStr, saleDate) Then
                                                                                                                     dateStr = saleDate.ToString("yyyy-MM-dd hh:mm tt")
                                                                                                                 End If
                                                                                                                 table.Cell().Background(bg).Padding(5).AlignCenter().Text(dateStr)

                                                                                                                 rowIndex += 1
                                                                                                             Next
                                                                                                         End Sub)

                                                                                          c.Item().PaddingVertical(6).LineHorizontal(1)
                                                                                          c.Item().AlignRight().Text($"Total Sales: {totalSalesText}").FontSize(12).Bold()
                                                                                      End Sub)

                                                                ' === FOOTER ===
                                                                page.Footer().AlignCenter().Text($"Generated on {DateTime.Now:MMMM dd, yyyy hh:mm tt}") _
                                                            .FontSize(9).FontColor(Colors.Grey.Darken1)
                                                            End Sub)
                                         End Sub)

            ' === Save & open PDF ===
            Dim tempPath As String = Path.Combine(Path.GetTempPath(), $"SalesReport_{DateTime.Now:yyyyMMdd_HHmmss}.pdf")
            pdfDoc.GeneratePdf(tempPath)
            Process.Start(New ProcessStartInfo(tempPath) With {.UseShellExecute = True})

        Catch ex As Exception
            MessageBox.Show("Error generating report: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub


    Private Function SafeVal(dict As Dictionary(Of String, Object), key As String) As String
        If dict.ContainsKey(key) AndAlso dict(key) IsNot Nothing Then Return dict(key).ToString()
        Return ""
    End Function

    Private Sub SaleRep_FormClosed(sender As Object, e As FormClosedEventArgs) Handles Me.FormClosed
        For Each frm As Form In Application.OpenForms
            If TypeOf frm Is Dashboard Then
                Dim dash As Dashboard = CType(frm, Dashboard)
                dash.RefreshDashboard()
            End If
        Next
    End Sub


    Private Sub btnClose_Click(sender As Object, e As EventArgs) Handles btnClose.Click
        Me.Close()
    End Sub


End Class