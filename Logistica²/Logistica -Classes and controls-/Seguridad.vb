Imports System.Math
Imports Microsoft.VisualBasic
Imports System.IO
Public Class Secure

#Region "Enumeradores"
    Public Enum FileEncriptationType As Byte
        Implicit = 0
        Drive = 1
    End Enum
#End Region

    Public Sub New()
        If Application.ProductName <> "Logística²" Then
            Application.Exit()
        End If
    End Sub

#Region "Funciones y subrutinas privadas"

#Region "Encriptado de datos"
    Public Function ImplicitEncript(ByVal Text As String) As String
        Try
            Dim Key, Adder, index As Integer
            Dim temp As Integer = Nothing
            Dim Auxiliar() As Char = Text.ToCharArray
            Adder = Len(Text)
            Adder = Compact(Adder)
            Randomize()
            Key = CInt(Int((9) * Rnd() + 1))
            For index = 0 To Len(Text) - 1
                Auxiliar(index) = Chr(Asc(Auxiliar(index)) + Key + Adder)
            Next
            Array.Reverse(Auxiliar)
            Return Asc(CStr(Key)).ToString & Auxiliar
        Catch ex As Exception
            Throw ex
        End Try
    End Function
    Public Function DriveEncript(ByVal Text As String, ByVal Drive As String) As String
        Try
            Dim SDrive As New Scripting.FileSystemObject()
            Dim Auxiliar() As Char = Text.ToCharArray
            Dim SNumber As String = SDrive.Drives(Drive).SerialNumber.ToString
            Dim index As Integer
            Dim key As Integer = Compact(CInt(Val(SNumber)))
            For index = 0 To Len(Text) - 1
                Auxiliar(index) = Chr(Asc(Auxiliar(index)) + key)
            Next
            SNumber = ImplicitEncript(SNumber)
            If SNumber.Length > 9 Then
                SNumber = Asc(SNumber.Length.ToString.Substring(0, 1)) & Asc(SNumber.Length.ToString.Substring(1, 1)) & SNumber
            Else
                SNumber = Asc("0") & Asc(SNumber.Length.ToString.Substring(1, 1)) & SNumber
            End If
            Text = Auxiliar
            Return SNumber & Auxiliar
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Sub FileEncript(ByVal OrigenFileName As String, ByVal DestinyFileName As String, ByVal Type As FileEncriptationType)
        Try
            Dim rdr As New StreamReader(OrigenFileName)
            Dim wrt As New StreamWriter(DestinyFileName)

            While True
                Select Case Type
                    Case FileEncriptationType.Drive
                        wrt.WriteLine(DriveEncript(rdr.ReadLine, "C:"))
                    Case FileEncriptationType.Implicit
                End Select
            End While
        Catch ex As Exception
        End Try
    End Sub

#End Region

#Region "Desencriptado de datos"
    Public Function ImplicitUnencript(ByVal Text As String) As String
        Try
            Dim Key, Adder, index As Integer
            Dim temp As String = Nothing
            Dim Auxiliar() As Char = Text.ToCharArray(2, Len(Text) - 2)
            Array.Reverse(Auxiliar)
            Adder = Len(Text) - 2
            Adder = Compact(Adder)
            Key = Val(Chr(CInt(Text.Substring(0, 2))))
            For index = 0 To Len(Text) - 3
                Auxiliar(index) = Chr(Asc(Auxiliar(index)) - Key - Adder)
            Next
            Return Auxiliar
        Catch ex As Exception
            Throw ex
        End Try
    End Function
    Public Function DriveUnencript(ByVal Text As String, ByVal Drive As String) As String
        Try
            Dim SDrive As New Scripting.FileSystemObject()
            Dim Auxiliar() As Char = Text.ToCharArray
            Dim SNumber As String = SDrive.Drives(Drive).SerialNumber.ToString
            Dim index As Integer
            Dim key As Integer = Compact(CInt(Val(SNumber)))
            index = CInt(10 * Val(Chr(CInt(Text.Substring(0, 2)))) + Val(Chr(CInt(Text.Substring(2, 2)))))
            If ImplicitUnencript(Text.Substring(4, index)) = SNumber Then
                Auxiliar = Text.Substring(index + 4).ToCharArray
                For index = 0 To Auxiliar.Length - 1
                    Auxiliar(index) = Chr(Asc(Auxiliar(index)) - key)
                Next
                Return Auxiliar
            Else
                Dim ex As New Exception("Not a valid key.")
                Throw ex
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Function
#End Region

#Region "Funciones generales"
    Public Function Compact(ByVal Number As Integer) As Byte
        Dim temp As Integer
        Number = Abs(Number)
        While Number > 9
            temp = Number - 10 * CInt(Fix(Number / 10))
            Number = CInt(Fix(Number / 10)) + temp
        End While
        Return CByte(Number)

    End Function
#End Region
#End Region


End Class
