Imports System.Globalization
Imports System.IO
Imports System.Windows.Forms.VisualStyles.VisualStyleElement.TrackBar
Imports Microsoft.VisualBasic.Devices
Imports MySql.Data.MySqlClient
Imports QuestPDF.Companion
Imports QuestPDF.Fluent
Imports QuestPDF.Helpers
Imports QuestPDF.Infrastructure
Imports QuestPDF.Previewer
Imports Windows.Win32.System

Public Class StockIn
    Private Sub StockIn(sender As Object, e As EventArgs) Handles MyBase.Load
        LoadStockIn()

        If String.IsNullOrWhiteSpace(txtSearchStock.Text) Then
            txtSearchStock.Text = "Search"
            txtSearchStock.ForeColor = System.Drawing.Color.Gray
        End If

        lblClx.Visible = False

        For Each column As DataGridViewColumn In dbStockIn.Columns
            column.SortMode = DataGridViewColumnSortMode.NotSortable
        Next
    End Sub

    Private Sub StockIn_Shown(sender As Object, e As EventArgs) Handles MyBase.Shown

        lblActiveDate44.Text = DateTime.Now.ToString("dddd, MMMM dd yyyy")
        lblActiveTime44.Text = DateTime.Now.ToString("hh:mm:ss tt")
        lblUsername44.Text = "User: " & frmInterface.loggedInUsername

        Tick4.Start()

        LoadStockIn()
    End Sub

    Private Sub Tick4_Tick(sender As Object, e As EventArgs) Handles Tick4.Tick
        lblActiveDate44.Text = DateTime.Now.ToString("dddd, MMMM d, yyyy")
        lblActiveTime44.Text = DateTime.Now.ToString("hh:mm:ss tt")
    End Sub

    Private Sub txtSearchStock_TextChanged(sender As Object, e As EventArgs) Handles txtSearchStock.TextChanged

        Dim keyword As String = txtSearchStock.Text.Trim

        If keyword = "Search" Then
            keyword = ""
        End If

        lblClx.Visible = (txtSearchStock.ForeColor = System.Drawing.Color.Black AndAlso keyword <> "")

        LoadStockIn(keyword)

    End Sub

    Private Sub txtSearch_Enter(sender As Object, e As EventArgs) Handles txtSearchStock.Enter
        If txtSearchStock.Text = "Search" Then
            txtSearchStock.Text = ""
            txtSearchStock.ForeColor = System.Drawing.Color.Black
        End If
    End Sub

    ' 🔎 When textbox loses focus
    Private Sub txtSearch_Leave(sender As Object, e As EventArgs) Handles txtSearchStock.Leave

        If txtSearchStock.Text.Trim = "" Then
            txtSearchStock.Text = "Search"
            txtSearchStock.ForeColor = System.Drawing.Color.Gray
            lblClx.Visible = False
        End If

    End Sub

    Private Sub lblClx_Click(sender As Object, e As EventArgs) Handles lblClx.Click
        ' Clear search input
        txtSearchStock.Clear()
        LoadStockIn() ' reset accounts

        ' If the box is not focused, reapply watermark immediately
        If Not txtSearchStock.Focused Then
            txtSearchStock.Text = "Search"
            txtSearchStock.ForeColor = System.Drawing.Color.Gray
        End If
    End Sub

    Public Sub LoadStockIn(Optional keyword As String = "")
        Try
            Dim query As String = "
        SELECT 
            p.ProductID,
            p.ProductCode,
            p.ProductName,
            p.Category,
            p.Price,
            p.PurchasePrice,
            p.StockQty,
            p.DefaultUnit,
            p.PiecesPerBox,
            CASE 
                WHEN s.is_Archived = 1 THEN CONCAT(s.SupplierName, ' (Archived)')
                ELSE IFNULL(s.SupplierName, '')
            END AS Supplier,
            IFNULL(si.SupplierID, 0) AS SupplierID
        FROM products1 p
        LEFT JOIN stock_in1 si ON si.ProductID = p.ProductID
        LEFT JOIN suppliers1 s ON si.SupplierID = s.SupplierID
        WHERE p.IsArchived = 0"

            If keyword <> "" Then
                query &= " AND (p.ProductName LIKE @kw OR p.Category LIKE @kw)"
            End If

            query &= " ORDER BY p.ProductName ASC;"

            Using cmd As New MySqlCommand(query, conn)
                If keyword <> "" Then cmd.Parameters.AddWithValue("@kw", "%" & keyword & "%")
                Dim da As New MySqlDataAdapter(cmd)
                Dim dt As New DataTable()
                da.Fill(dt)

                ' Create Stock Info Display Column
                dt.Columns.Add("StockDisplay", GetType(String))

                For Each row As DataRow In dt.Rows
                    Dim stockQty As Integer = Convert.ToInt32(row("StockQty"))
                    Dim defaultUnit As String = row("DefaultUnit").ToString().Trim().ToLower()
                    Dim pcsPerBox As Integer = 0
                    Integer.TryParse(row("PiecesPerBox").ToString(), pcsPerBox)

                    ' If default unit is piece → show only pieces
                    If defaultUnit = "piece" Then
                        row("StockDisplay") = $"{stockQty} Piece(s)"

                        ' If default unit is box → compute conversion
                    ElseIf defaultUnit = "box" AndAlso pcsPerBox > 0 AndAlso stockQty >= pcsPerBox Then
                        Dim boxes As Integer = stockQty \ pcsPerBox
                        Dim pieces As Integer = stockQty Mod pcsPerBox
                        row("StockDisplay") = $"{boxes} Box(es) - {pcsPerBox} pcs each" &
                                          If(pieces > 0, $" + {pieces} loose", "")

                        ' Fallback (no conversion)
                    Else
                        row("StockDisplay") = $"{stockQty} Piece(s)"
                    End If
                Next

                dbStockIn.DataSource = dt

                ' === Highlight rows based on the same logic as stock alert ===
                For Each row As DataGridViewRow In dbStockIn.Rows
                    If row.IsNewRow Then Continue For

                    Dim stockQty As Integer = Convert.ToInt32(row.Cells("StockQty").Value)
                    Dim piecesPerBox As Integer = 0
                    Integer.TryParse(row.Cells("PiecesPerBox").Value.ToString(), piecesPerBox)

                    ' === Compute boxes if possible ===
                    Dim boxes As Double = 0
                    If piecesPerBox > 0 Then
                        boxes = stockQty / piecesPerBox
                    End If

                    ' === Apply color logic ===
                    If stockQty = 0 Then
                        ' 🔴 Out of stock
                        row.DefaultCellStyle.BackColor = System.Drawing.Color.FromArgb(255, 102, 102)

                    ElseIf (piecesPerBox > 0 AndAlso boxes <= 30) _
        OrElse (piecesPerBox = 0 AndAlso stockQty <= 30) Then
                        ' 🟡 Low stock (aligned with alert logic)
                        row.DefaultCellStyle.BackColor = System.Drawing.Color.FromArgb(255, 255, 153)

                    End If
                Next

                ' Format columns
                dbStockIn.Columns("Price").DefaultCellStyle.Format = "C2"
                dbStockIn.Columns("Price").DefaultCellStyle.FormatProvider = CultureInfo.CreateSpecificCulture("en-PH")

                dbStockIn.Columns("PurchasePrice").DefaultCellStyle.Format = "C2"
                dbStockIn.Columns("PurchasePrice").DefaultCellStyle.FormatProvider = CultureInfo.CreateSpecificCulture("en-PH")

                With dbStockIn
                    .Columns("ProductCode").HeaderText = "Product Code"
                    .Columns("ProductName").HeaderText = "Product Name"
                    .Columns("Category").HeaderText = "Category"
                    .Columns("Price").HeaderText = "Price"
                    .Columns("PurchasePrice").HeaderText = "Purchase Price"
                    .Columns("StockQty").HeaderText = "Total (pcs)"
                    .Columns("StockDisplay").HeaderText = "Stock Info"
                    .Columns("Supplier").HeaderText = "Supplier"
                End With

                ' Hide internal fields
                dbStockIn.Columns("ProductID").Visible = False
                dbStockIn.Columns("SupplierID").Visible = False
                dbStockIn.Columns("Price").Visible = False
                dbStockIn.Columns("DefaultUnit").Visible = False
                dbStockIn.Columns("PiecesPerBox").Visible = False
                dbStockIn.Columns("StockQty").Visible = False

                ResizeStocksColumns()
            End Using

        Catch ex As Exception
            MessageBox.Show("Error loading stock-in data: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub


    Private Sub ResizeStocksColumns()
        With dbStockIn
            .AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill

            ' set proportional widths
            .Columns("ProductCode").FillWeight = 100
            .Columns("ProductName").FillWeight = 100
            .Columns("Category").FillWeight = 80
            .Columns("Price").FillWeight = 80
            .Columns("PurchasePrice").FillWeight = 55
            .Columns("StockQty").FillWeight = 70
            .Columns("Supplier").FillWeight = 110
        End With
    End Sub


    Private Sub btnAddStock_Click(sender As Object, e As EventArgs) Handles btnAddStock.Click
        If dbStockIn.SelectedRows.Count = 0 Then
            MessageBox.Show("Please select a product first.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Exit Sub
        End If

        Dim row As DataGridViewRow = dbStockIn.SelectedRows(0)
        Dim productId As Integer = CInt(row.Cells("ProductID").Value)
        Dim productName As String = row.Cells("ProductName").Value.ToString()

        Dim popup As New AddStock(productId, productName)
        popup.Owner = Me                                ' <-- important
        If popup.ShowDialog() = DialogResult.OK Then    ' <-- waits until popup closes
            LoadStockIn()                               ' <-- refresh grid
        End If
    End Sub

    Private Sub btnEditStock_Click(sender As Object, e As EventArgs) Handles btnEditStock.Click
        If dbStockIn.SelectedRows.Count > 0 Then
            Dim selectedRow As DataGridViewRow = dbStockIn.SelectedRows(0)

            ' --- Required fields ---
            Dim productId As Integer = Convert.ToInt32(selectedRow.Cells("ProductID").Value)
            Dim productName As String = selectedRow.Cells("ProductName").Value.ToString()
            Dim currentQty As Integer = Convert.ToInt32(selectedRow.Cells("StockQty").Value)

            ' --- Optional: StockInID ---
            Dim stockInId As Integer = 0
            If dbStockIn.Columns.Contains("StockInID") Then
                If selectedRow.Cells("StockInID").Value IsNot Nothing AndAlso Not IsDBNull(selectedRow.Cells("StockInID").Value) Then
                    stockInId = Convert.ToInt32(selectedRow.Cells("StockInID").Value)
                End If
            End If

            ' --- Optional: SupplierID ---
            Dim supplierId As Integer = 0
            If dbStockIn.Columns.Contains("SupplierID") Then
                If selectedRow.Cells("SupplierID").Value IsNot Nothing AndAlso Not IsDBNull(selectedRow.Cells("SupplierID").Value) Then
                    supplierId = Convert.ToInt32(selectedRow.Cells("SupplierID").Value)
                End If
            End If

            ' --- Open EditStock popup ---
            Dim popup As New EditStock(stockInId, productId, productName, currentQty, supplierId)
            If popup.ShowDialog() = DialogResult.OK Then
                LoadStockIn()
            End If
        Else
            MessageBox.Show("Please select a product first.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End If
    End Sub

    Private Sub btnHistory_Click(sender As Object, e As EventArgs) Handles btnHistory.Click
        Dim historyForm As New StockHistory()
        historyForm.LoadStockHistory()
        historyForm.ShowDialog()
    End Sub

    Private Sub btnPrint_Click(sender As Object, e As EventArgs) Handles btnPrint.Click
        Try
            Dim dt As DataTable = TryCast(dbStockIn.DataSource, DataTable)
            If dt Is Nothing OrElse dt.Rows.Count = 0 Then
                MessageBox.Show("No data available to print.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Exit Sub
            End If

            ' Create and show preview (Companion)
            Dim doc = GenerateStockInReport(dt)
            ' Save PDF to a temp file and open it in default PDF viewer
            Dim tempPath As String = Path.Combine(Path.GetTempPath(), "StockInReport_" & DateTime.Now.ToString("yyyyMMdd_HHmmss") & ".pdf")
            doc.GeneratePdf(tempPath)
            Process.Start(New ProcessStartInfo(tempPath) With {.UseShellExecute = True})

        Catch ex As Exception
            MessageBox.Show("Error generating report: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Function GenerateStockInReport(dt As DataTable) As IDocument
        QuestPDF.Settings.License = LicenseType.Community

        Return Document.Create(Sub(container)
                                   container.Page(Sub(page)
                                                      ' PAGE SETTINGS
                                                      page.Size(PageSizes.A4.Landscape())
                                                      page.Margin(30)
                                                      page.DefaultTextStyle(Function(x) x.FontSize(10))

                                                      ' HEADER
                                                      page.Header().Element(Sub(header)
                                                                                header.Column(Sub(col)
                                                                                                  col.Item().Text("📦 STOCK-IN REPORT").FontSize(22).Bold().AlignCenter()
                                                                                                  col.Item().Text("Generated on " &
                                                                                                              DateTime.Now.ToString("MMMM dd, yyyy hh:mm tt")) _
                                                                                                  .FontSize(10).AlignCenter().FontColor(Colors.Grey.Darken1)
                                                                                                  col.Item().PaddingVertical(8)
                                                                                              End Sub)
                                                                            End Sub)

                                                      ' CONTENT
                                                      page.Content().PaddingVertical(10).Element(Sub(content)
                                                                                                     content.Table(Sub(table)
                                                                                                                       ' Define columns
                                                                                                                       table.ColumnsDefinition(Sub(columns)
                                                                                                                                                   columns.ConstantColumn(80)   ' Code
                                                                                                                                                   columns.RelativeColumn(2)    ' Name
                                                                                                                                                   columns.RelativeColumn(1.3F) ' Category
                                                                                                                                                   columns.RelativeColumn(1.3F) ' Supplier
                                                                                                                                                   columns.ConstantColumn(90)   ' Stock
                                                                                                                                                   columns.ConstantColumn(90)   ' Price
                                                                                                                                                   columns.ConstantColumn(90)   ' Purchase
                                                                                                                                               End Sub)

                                                                                                                       ' Header
                                                                                                                       table.Header(Sub(header)
                                                                                                                                        For Each title In {"Code", "Product Name", "Category", "Supplier", "Stock", "Price", "Purchase"}
                                                                                                                                            header.Cell().Element(AddressOf CellStyleHeader).Text(title)
                                                                                                                                        Next
                                                                                                                                    End Sub)

                                                                                                                       ' Rows
                                                                                                                       Dim rowIndex As Integer = 0
                                                                                                                       For Each row As DataRow In dt.Rows
                                                                                                                           Dim bgColor = If(rowIndex Mod 2 = 0, Colors.White, Colors.Grey.Lighten4)

                                                                                                                           table.Cell().Element(Function(c) CellStyleBody(c, bgColor)).Text(row("ProductCode").ToString())
                                                                                                                           table.Cell().Element(Function(c) CellStyleBody(c, bgColor)).Text(row("ProductName").ToString())
                                                                                                                           table.Cell().Element(Function(c) CellStyleBody(c, bgColor)).Text(row("Category").ToString())
                                                                                                                           table.Cell().Element(Function(c) CellStyleBody(c, bgColor)).Text(row("Supplier").ToString())

                                                                                                                           Dim stock As String = If(row.Table.Columns.Contains("StockDisplay"), row("StockDisplay").ToString(), row("StockQty").ToString())
                                                                                                                           Dim price As Decimal = If(row.Table.Columns.Contains("Price") AndAlso Not IsDBNull(row("Price")), Convert.ToDecimal(row("Price")), 0D)
                                                                                                                           Dim purchase As Decimal = If(row.Table.Columns.Contains("PurchasePrice") AndAlso Not IsDBNull(row("PurchasePrice")), Convert.ToDecimal(row("PurchasePrice")), 0D)

                                                                                                                           table.Cell().Element(Function(c) CellStyleBody(c, bgColor)).Text(stock)
                                                                                                                           table.Cell().Element(Function(c) CellStyleBody(c, bgColor)).Text(price.ToString("C2", CultureInfo.CreateSpecificCulture("en-PH")))
                                                                                                                           table.Cell().Element(Function(c) CellStyleBody(c, bgColor)).Text(purchase.ToString("C2", CultureInfo.CreateSpecificCulture("en-PH")))

                                                                                                                           rowIndex += 1
                                                                                                                       Next
                                                                                                                   End Sub)
                                                                                                 End Sub)

                                                      ' FOOTER
                                                      page.Footer().AlignRight().Text(Sub(t)
                                                                                          t.Span("Page ").FontSize(10)
                                                                                          t.CurrentPageNumber().FontSize(10)
                                                                                      End Sub)
                                                  End Sub)
                               End Sub)
    End Function

    Private Function CellStyleHeader(c As IContainer) As IContainer
        Return c.PaddingVertical(6) _
                .Background(Colors.Grey.Darken1) _
                .Border(0.5F) _
                .BorderColor(Colors.Grey.Darken2) _
                .DefaultTextStyle(Function(t) t.Bold().FontColor(Colors.White)) _
                .AlignCenter()
    End Function

    Private Function CellStyleBody(c As IContainer, bgColor As String) As IContainer
        Return c.Background(bgColor) _
                .PaddingVertical(4) _
                .PaddingHorizontal(4) _
                .Border(0.3F) _
                .BorderColor(Colors.Grey.Lighten2) _
                .AlignMiddle()
    End Function


End Class