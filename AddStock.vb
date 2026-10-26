Imports MySql.Data.MySqlClient

Public Class AddStock
    Private _productId As Integer
    Private _productName As String
    Private _piecesPerBox As Integer = 0
    Private _defaultUnit As String = "Piece"
    Private _isFirstStock As Boolean = False

    Public Sub New(productId As Integer, productName As String)
        InitializeComponent()
        _productId = productId
        _productName = productName
        txtPN.Text = _productName
    End Sub

    Private Sub AddStock_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            If conn.State <> ConnectionState.Open Then conn.Open()

            ' Check if product already has stock or unit info
            Dim q As String = "
                SELECT DefaultUnit, PiecesPerBox, IsInitialized  
                FROM products1 
                WHERE ProductID = @pid LIMIT 1;"
            Using cmd As New MySqlCommand(q, conn)
                cmd.Parameters.AddWithValue("@pid", _productId)
                Using r = cmd.ExecuteReader()
                    If r.Read() Then
                        _defaultUnit = If(IsDBNull(r("DefaultUnit")), "Piece", r("DefaultUnit").ToString())
                        Integer.TryParse(r("PiecesPerBox").ToString(), _piecesPerBox)
                        Dim isInit As Boolean = If(IsDBNull(r("IsInitialized")), False, Convert.ToBoolean(r("IsInitialized")))
                        _isFirstStock = Not isInit
                    End If
                End Using
            End Using
        Catch ex As Exception
            MessageBox.Show("Error loading product info: " & ex.Message)
        Finally
            If conn.State = ConnectionState.Open Then conn.Close()
        End Try

        ' ✅ Setup unit dropdown
        cmbUnit.Items.Clear()
        cmbUnit.Items.AddRange(New String() {"Piece", "Box"})

        If _isFirstStock Then
            ' Allow the user to choose for first-time stock-in
            cmbUnit.Enabled = True
            txtQuant.Enabled = True
            txtNBox.Enabled = False
        Else
            ' Follow existing product default unit
            cmbUnit.Enabled = False
            If _defaultUnit.ToLower() = "box" Then
                cmbUnit.SelectedIndex = 1
                txtQuant.Enabled = True       ' pieces per box
                txtNBox.Enabled = True        ' number of boxes
            Else
                cmbUnit.SelectedIndex = 0
                txtQuant.Enabled = True       ' number of pieces
                txtNBox.Enabled = False
            End If
        End If

        txtQuant.Clear()
        txtNBox.Clear()

        If cmbUnit.SelectedIndex = -1 Then
            cmbUnit.SelectedIndex = 0 ' default to Piece
        End If
    End Sub

    Private Sub cmbUnit_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbUnit.SelectedIndexChanged
        ' Adjust input fields when user changes unit
        If cmbUnit.SelectedItem Is Nothing Then Exit Sub
        Dim unit As String = cmbUnit.SelectedItem.ToString().ToLower()

        If unit = "box" Then
            txtNBox.Enabled = True
            txtQuant.Enabled = True
        Else
            txtNBox.Enabled = False
            txtQuant.Enabled = True
        End If
    End Sub

    Private Sub NumericOnly(sender As Object, e As KeyPressEventArgs) Handles txtQuant.KeyPress, txtNBox.KeyPress
        If Not Char.IsControl(e.KeyChar) AndAlso Not Char.IsDigit(e.KeyChar) Then e.Handled = True
    End Sub

    Private Sub btnSaveAS_Click(sender As Object, e As EventArgs) Handles btnSaveAS.Click
        Try
            ' ✅ PREVENT NULL DROPDOWN ERROR
            If cmbUnit.SelectedItem Is Nothing Then
                MessageBox.Show("Please select a unit (Piece or Box).", "Missing Input", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Exit Sub
            End If

            Dim unit As String = cmbUnit.SelectedItem.ToString().ToLower()
            Dim totalPieces As Integer = 0
            Dim remarks As String = ""

            If unit = "piece" Then
                Dim qty As Integer
                If Not Integer.TryParse(txtQuant.Text, qty) OrElse qty <= 0 Then
                    MessageBox.Show("Enter a valid number of pieces.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    Exit Sub
                End If
                totalPieces = qty
                remarks = $"{qty} Piece(s) added."

            ElseIf unit = "box" Then
                Dim boxes As Integer
                Dim pcsPerBox As Integer

                If Not Integer.TryParse(txtNBox.Text, boxes) OrElse boxes <= 0 Then
                    MessageBox.Show("Enter how many boxes.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    Exit Sub
                End If

                If Not Integer.TryParse(txtQuant.Text, pcsPerBox) OrElse pcsPerBox <= 0 Then
                    MessageBox.Show("Enter pieces per box.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    Exit Sub
                End If

                totalPieces = boxes * pcsPerBox
                _piecesPerBox = pcsPerBox
                remarks = $"{boxes} Box(es) × {pcsPerBox} pcs = {totalPieces} pcs total."
            End If

            If conn.State <> ConnectionState.Open Then conn.Open()

            ' ✅ Update product stock & unit info
            Dim updateQuery As String = "
                UPDATE products1 
                SET StockQty = StockQty + @addQty,
                    PiecesPerBox = @ppb,
                    DefaultUnit = @unit,
                    IsInitialized = 1
                WHERE ProductID = @pid;"

            Using cmd As New MySqlCommand(updateQuery, conn)
                cmd.Parameters.AddWithValue("@addQty", totalPieces)
                cmd.Parameters.AddWithValue("@ppb", _piecesPerBox)
                cmd.Parameters.AddWithValue("@unit", cmbUnit.SelectedItem.ToString())
                cmd.Parameters.AddWithValue("@pid", _productId)
                cmd.ExecuteNonQuery()
            End Using

            ' ✅ Insert into stockin_history1
            Dim insertHistory As String = "
                INSERT INTO stockin_history1 
                    (ProductName, Quantity, Unit, TotalPieces, Remarks, DateAdded)
                VALUES 
                    (@pname, @qty, @unit, @total, @remarks, NOW());"

            Using cmdH As New MySqlCommand(insertHistory, conn)
                Dim qtyValue As Integer = If(unit = "box", Val(txtNBox.Text), Val(txtQuant.Text))
                cmdH.Parameters.AddWithValue("@pname", txtPN.Text.Trim())
                cmdH.Parameters.AddWithValue("@qty", qtyValue)
                cmdH.Parameters.AddWithValue("@unit", If(unit = "box", "Box", "Piece"))
                cmdH.Parameters.AddWithValue("@total", totalPieces)
                cmdH.Parameters.AddWithValue("@remarks", remarks)
                cmdH.ExecuteNonQuery()
            End Using

            MessageBox.Show("Stock successfully added!" & vbCrLf & remarks, "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
            DialogResult = DialogResult.OK
            Me.Close()

        Catch ex As Exception
            MessageBox.Show("Error: " & ex.Message)
        Finally
            If conn.State = ConnectionState.Open Then conn.Close()
        End Try
    End Sub

    Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        Me.Close()
    End Sub
End Class






