Imports MySql.Data.MySqlClient

Public Class EditQty
    Public Property NewQuantity As Integer
    Public Property ProductID As Integer
    Public Property SelectedUnit As String  ' e.g. "Box (12 pcs)" or "Piece"

    Private Sub btnConfirm2_Click(sender As Object, e As EventArgs) Handles btnConfirm2.Click
        Dim qty As Integer

        If Not Integer.TryParse(txtQuantity.Text, qty) OrElse qty <= 0 Then
            MessageBox.Show("Please enter a valid quantity greater than 0.",
                            "Invalid Input", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Exit Sub
        End If

        ' 🧩 Get the available stock and product info
        Dim stockQty As Integer = 0
        Dim piecesPerBox As Integer = 1

        Try
            If conn.State = ConnectionState.Closed Then conn.Open()

            Dim query As String = "
                SELECT StockQty, 
                       IFNULL(PiecesPerBox, 1) AS PiecesPerBox
                FROM products1
                WHERE ProductID = @ProductID"
            Using cmd As New MySqlCommand(query, conn)
                cmd.Parameters.AddWithValue("@ProductID", ProductID)
                Using reader As MySqlDataReader = cmd.ExecuteReader()
                    If reader.Read() Then
                        stockQty = Convert.ToInt32(reader("StockQty"))
                        piecesPerBox = Convert.ToInt32(reader("PiecesPerBox"))
                    End If
                End Using
            End Using
        Catch ex As Exception
            MessageBox.Show("Error checking stock: " & ex.Message,
                            "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        Finally
            If conn.State = ConnectionState.Open Then conn.Close()
        End Try

        ' 🧩 Compute allowed quantity based on unit
        Dim availableQty As Decimal
        If SelectedUnit.ToLower().Contains("box") Then
            availableQty = Math.Floor(stockQty / piecesPerBox)
        Else
            availableQty = stockQty
        End If

        ' 🧩 Check if entered quantity exceeds available
        If qty > availableQty Then
            MessageBox.Show($"Not enough stock available. Only {availableQty} {SelectedUnit}(s) left.",
                            "Insufficient Stock", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Exit Sub
        End If

        ' ✅ All good — confirm
        NewQuantity = qty
        Me.DialogResult = DialogResult.OK
        Me.Close()
    End Sub

    Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        Me.Close()
    End Sub
End Class