Imports System.Text.RegularExpressions

Public Module PasswordHelper

    Public Function HashPassword(password As String) As String
        Return BCrypt.Net.BCrypt.HashPassword(password)
    End Function

    Public Function IsBCryptHash(storedPassword As String) As Boolean
        If String.IsNullOrEmpty(storedPassword) Then Return False

        Return Regex.IsMatch(storedPassword, "^\$2[aby]\$\d{2}\$")
    End Function

    Public Function VerifyPassword(enteredPassword As String,
                                   storedPassword As String) As Boolean

        If String.IsNullOrEmpty(storedPassword) Then Return False

        If IsBCryptHash(storedPassword) Then
            Try
                Return BCrypt.Net.BCrypt.Verify(
                    enteredPassword, storedPassword)
            Catch
                Return False
            End Try
        End If

        ' Temporary support for existing plaintext accounts
        Return String.Equals(
            enteredPassword,
            storedPassword,
            StringComparison.Ordinal)

    End Function

End Module
