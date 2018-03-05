Imports System.ComponentModel

<Serializable()> _
Public Class ViewGridCheckCondition
    Private _ColumnName As String
    Private _Value As String
    Private _Comparison As ViewGridCheckConditionComparison

    Public Sub New(Optional ByVal ColumnName As String = "", Optional ByVal Comparison As ViewGridCheckConditionComparison = ViewGridCheckConditionComparison.Equal, Optional ByVal Value As String = "")
        Me._ColumnName = ColumnName
        Me._Comparison = Comparison
        Me._Value = Value
    End Sub

    Public Enum ViewGridCheckConditionComparison As Byte
        Equal = 0
        Lower = 1
        Higher = 2
        Diferent = 3
        StartsWith = 4
        EndsWith = 5
        Contains = 6
    End Enum

    <Description("The name of the column that will define the check condition")> _
    Property ColumnName() As String
        Get
            Return _ColumnName
        End Get
        Set(ByVal Value As String)
            _ColumnName = Value
        End Set
    End Property
    <Description("The value to compare with the selected column")> _
    Property Value() As String
        Get
            Return _Value
        End Get
        Set(ByVal Value As String)
            _Value = Value
        End Set
    End Property
    <Description("The comparison the be executed to determine the cheked state")> _
    Property Comparison() As ViewGridCheckConditionComparison
        Get
            Return _Comparison
        End Get
        Set(ByVal Value As ViewGridCheckConditionComparison)
            _Comparison = Value
        End Set
    End Property

End Class
