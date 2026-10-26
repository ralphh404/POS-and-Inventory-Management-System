Imports MySql.Data.MySqlClient

Public Class AddSuppliers
    Public isEdit As Boolean = False
    Public SupplierID As Integer
    Public callingForm As Suppliers

    Private Sub AddSuppliers(sender As Object, e As EventArgs) Handles MyBase.Load
        If isEdit Then
            btnSavesp.Visible = False
            btnspUp.Visible = True
        Else
            btnSavesp.Visible = True
            btnspUp.Visible = False
        End If

        Me.BeginInvoke(New MethodInvoker(Sub()
                                             txtspName.Focus()
                                         End Sub))

    End Sub

    Public Sub LoadSupplierData(id As Integer)
        Try
            Dim query As String = "SELECT * FROM suppliers1 WHERE SupplierID = @id"
            Using cmd As New MySqlCommand(query, conn)
                cmd.Parameters.AddWithValue("@id", id)
                conn.Open()
                Using dr As MySqlDataReader = cmd.ExecuteReader()
                    If dr.Read() Then
                        txtPhn.Text = dr("SupplierName").ToString()
                        txtCName.Text = dr("ContactName").ToString()
                        txtEml.Text = dr("Email").ToString()
                        txtPhn.Text = dr("Phone").ToString()
                        txtAdress.Text = dr("Address").ToString()
                    End If
                End Using
                conn.Close()
            End Using
        Catch ex As Exception
            MessageBox.Show("Error loading supplier data: " & ex.Message)
            If conn.State = ConnectionState.Open Then conn.Close()
        End Try
    End Sub

    Private Sub btnSavesp_Click(sender As Object, e As EventArgs) Handles btnSavesp.Click
        If txtspName.Text = "" Or txtCName.Text = "" Or txtEml.Text = "" Or txtPhn.Text = "" Or txtAdress.Text = "" Then
            MessageBox.Show("Please fill in all fields.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If

        Try
            Dim query As String = "INSERT INTO suppliers1 (SupplierName, ContactName, Email, Phone, Address) " &
                              "VALUES (@name, @contact, @email, @phone, @address)"

            Using cmd As New MySqlCommand(query, conn)
                cmd.Parameters.AddWithValue("@name", txtspName.Text)
                cmd.Parameters.AddWithValue("@contact", txtCName.Text)
                cmd.Parameters.AddWithValue("@email", txtEml.Text)
                cmd.Parameters.AddWithValue("@phone", txtPhn.Text)
                cmd.Parameters.AddWithValue("@address", txtAdress.Text)

                conn.Open()
                cmd.ExecuteNonQuery()
                conn.Close()

                MessageBox.Show("Supplier added successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)

                ' Refresh main supplier list if called from frmSuppliers
                If TypeOf callingForm Is Suppliers Then
                    CType(callingForm, Suppliers).LoadSuppliers()
                End If

                Me.Close()
            End Using

        Catch ex As Exception
            MessageBox.Show("Error adding supplier: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            If conn.State = ConnectionState.Open Then conn.Close()
        End Try
    End Sub

    Private Sub btnspUp_Click(sender As Object, e As EventArgs) Handles btnspUp.Click
        If txtspName.Text = "" Or txtCName.Text = "" Or txtEml.Text = "" Or txtPhn.Text = "" Or txtAdress.Text = "" Then
            MessageBox.Show("Please fill all required fields.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If

        Try
            Dim query As String = "UPDATE suppliers1 SET SupplierName = @name, ContactName = @contact, Email = @email, Phone = @phone, Address = @address WHERE SupplierID = @id"

            Using cmd As New MySqlCommand(query, conn)
                cmd.Parameters.AddWithValue("@name", txtspName.Text)
                cmd.Parameters.AddWithValue("@contact", txtCName.Text)
                cmd.Parameters.AddWithValue("@email", txtEml.Text)
                cmd.Parameters.AddWithValue("@phone", txtPhn.Text)
                cmd.Parameters.AddWithValue("@address", txtAdress.Text)
                cmd.Parameters.AddWithValue("@id", SupplierID)

                conn.Open()
                cmd.ExecuteNonQuery()
                conn.Close()

                MessageBox.Show("Supplier updated successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)

                If TypeOf callingForm Is Suppliers Then
                    CType(callingForm, Suppliers).LoadSuppliers()
                End If

                Me.Close()
            End Using

        Catch ex As Exception
            MessageBox.Show("Error updating supplier: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            If conn.State = ConnectionState.Open Then conn.Close()
        End Try
    End Sub

    Private Sub btnCancelsp_Click(sender As Object, e As EventArgs) Handles btnCancelsp.Click
        Me.Close()
    End Sub

End Class