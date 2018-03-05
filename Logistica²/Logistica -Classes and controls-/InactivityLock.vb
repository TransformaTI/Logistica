Public Class InactivityLock
    Public InactivityTime As Integer
    Dim _LockTime As Integer = 300000
    Dim _TimeParameter As Integer = 6000
    Dim _Units As TimeUnit = TimeUnit.Minutes

    Dim WithEvents tmrInactivityDetector As System.Timers.Timer

    Public Sub New()
        If Application.ProductName <> "Logística²" Then
            Application.Exit()
        End If
        tmrInactivityDetector = New Timers.Timer()
        tmrInactivityDetector.Interval = 1
        tmrInactivityDetector.Enabled = True
    End Sub

    Public Enum TimeUnit As Byte
        Seconds = 0
        Minutes = 1
    End Enum

    Property LockTime() As Integer
        Get
            Return CInt(_LockTime / _TimeParameter)
        End Get
        Set(ByVal Value As Integer)
            _LockTime = Value * _TimeParameter
        End Set
    End Property

    Property TimeUnits() As TimeUnit
        Get
            Return _Units
        End Get
        Set(ByVal Value As TimeUnit)
            _Units = Value
            Select Case Value
                Case TimeUnit.Minutes
                    _TimeParameter = 6000
                Case TimeUnit.Seconds
                    _TimeParameter = 100
            End Select
        End Set
    End Property

    Property Enabled() As Boolean
        Get
            Return (tmrInactivityDetector.Enabled)
        End Get
        Set(ByVal Value As Boolean)
            tmrInactivityDetector.Enabled = Value
        End Set
    End Property

    Public Event Lock()

    Private Sub tmrInactivityDetector_Elapsed(ByVal sender As Object, ByVal e As System.Timers.ElapsedEventArgs) Handles tmrInactivityDetector.Elapsed
        If Not InputCheck() Then
            InactivityTime += 1
        Else
            InactivityTime = 0
        End If
        If InactivityTime = _LockTime Then
            RaiseEvent Lock()
        End If
    End Sub
    Private Structure POINTAPI
        Dim x As Short
        Dim y As Short
    End Structure

    Private Declare Sub GetCursorPos Lib "User32" (ByRef lpPoint As POINTAPI)
    Private Declare Function GetAsyncKeyState Lib "User32" (ByVal vKey As Integer) As Short

    Private posOld As POINTAPI
    Private posNew As POINTAPI

    Public Function InputCheck() As Boolean
        Dim i As Short
        Call GetCursorPos(posNew)
        If ((posNew.x <> posOld.x) Or (posNew.y <> posOld.y)) Then
            posOld = posNew
            InputCheck = True
            Exit Function
        End If
        For i = 0 To 255
            If (GetAsyncKeyState(i) And &H8001S) <> 0 Then
                InputCheck = True
                Exit Function
            End If
        Next i
        InputCheck = False
    End Function

End Class
