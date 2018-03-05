Public Class Encripter

    Structure CharEncriptation
        Dim Text As String
        Dim KeyChar As Integer
    End Structure

    Public Sub New()
        If Application.ProductName <> "Logística²" Then
            Application.Exit()
        End If
    End Sub

    Function Reduce(ByVal Number As Integer) As Integer
        Dim index As Integer
        Dim Result As Integer = Number
        While CStr(Number).Length > 1
            Result = 0
            For index = 0 To CStr(Number).Length - 1
                Result += CInt(CStr(Number).Substring(index, 1))
            Next
            Number = Result
        End While
        Return Result
    End Function

    Function Count(ByVal Text As String, ByVal KeyChar As Char) As Integer
        Dim index As Integer
        Dim Result As Integer
        For index = 0 To Text.Length - 1
            If Text.Substring(index, 1) = KeyChar Then
                Result += 1
            End If
        Next
        Return Result
    End Function

    Public Function SizeEncript(ByVal Text As String) As String
        Dim TextArray(Text.Length - 1) As Char
        Dim Key As Integer
        Dim index As Integer
        Key = Reduce(Text.Length)
        TextArray = Text.ToCharArray
        For index = 0 To Text.Length - 1
            TextArray(index) = Chr(Asc(TextArray(index)) + Key)
        Next
        Return CStr(TextArray)
    End Function

    Public Function SizeUnencript(ByVal Text As String) As String
        Dim TextArray(Text.Length - 1) As Char
        Dim Key As Integer
        Dim index As Integer
        Key = Reduce(Text.Length)
        TextArray = Text.ToCharArray
        For index = 0 To Text.Length - 1
            TextArray(index) = Chr(Asc(TextArray(index)) - Key)
        Next
        Return CStr(TextArray)
    End Function

    Public Function KeyCharEncript(ByVal Text As String, ByVal KeyChar As Char) As CharEncriptation
        Dim TextArray(Text.Length - 1) As Char
        Dim Key As Integer = Reduce(Count(Text, KeyChar))
        Dim index As Integer
        TextArray = Text.ToCharArray
        For index = 0 To Text.Length - 1
            TextArray(index) = Chr(Asc(TextArray(index)) + Key)
        Next
        KeyCharEncript.Text = TextArray
        KeyCharEncript.KeyChar = Key
    End Function

    Public Function KeyCharUnencript(ByVal Text As String, ByVal KeyChar As Char) As String
        Dim TextArray(Text.Length - 1) As Char
        Dim index As Integer
        TextArray = Text.ToCharArray
        For index = 0 To Text.Length - 1
            TextArray(index) = Chr(Asc(TextArray(index)) - Asc(KeyChar))
        Next
        Return TextArray
    End Function

    Public Function AddEncript(ByVal Text As String, ByVal Adder As Integer) As String
        Dim TextArray(Text.Length - 1) As Char
        Dim index As Integer
        TextArray = Text.ToCharArray
        For index = 0 To Text.Length - 1
            TextArray(index) = Chr(Asc(TextArray(index)) + Adder)
        Next
        Return TextArray
    End Function

    Public Function AddUnencript(ByVal Text As String, ByVal Adder As Integer) As String
        Dim TextArray(Text.Length - 1) As Char
        Dim index As Integer
        TextArray = Text.ToCharArray
        For index = 0 To Text.Length - 1
            TextArray(index) = Chr(Asc(TextArray(index)) - Adder)
        Next
        Return TextArray
    End Function
End Class
