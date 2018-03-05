'''''''''''''''''''''''''''''''''''''''''''''
'       Combo especial para captuta         '
'Autor: Manuel Ruiz                         '
'Fecha: 30 de marzo de 2004                 '
'Descripción: Este control facilita la      '
'             manejo del contenido de una   '
'             combo y de sus cambios        '
'                                           '
'''''''''''''''''''''''''''''''''''''''''''''

Imports System.ComponentModel

<LicenseProvider(GetType(ECRALicenseProvider))> _
Public Class SelfCompletitionComboBox
    Inherits System.Windows.Forms.ComboBox

#Region " Windows Form Designer generated code "

    Private license As license = Nothing

    Public Sub New()
        MyBase.New()
        license = LicenseManager.Validate(GetType(SelfCompletitionComboBox), Me)


        'This call is required by the Windows Form Designer.
        InitializeComponent()

        'Add any initialization after the InitializeComponent() call
    End Sub

    'UserControl overrides dispose to clean up the component list.
    Protected Overloads Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing Then
            If Not (components Is Nothing) Then
                components.Dispose()
            End If
        End If
        If Not (license Is Nothing) Then
            license.Dispose()
            license = Nothing
        End If
        MyBase.Dispose(disposing)
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        components = New System.ComponentModel.Container()
    End Sub

#End Region

#Region "Global variables"
    Private OldText As String
    Private _SelfComplete As Boolean = True
    Private _MustExist As Boolean = True
    Private _CompleteOnLeave As Boolean = True
    Private _ForceCompleteOnLeave As Boolean = False
    Private _TrySimilarOnLeave As Boolean = False
    Private _CorrectOnWriting As Boolean = False
#End Region

    '#Region "Overloaded Properties"
    '    <Browsable(False)> Shadows ReadOnly Property DropDownStyle() As ComboBoxStyle
    '        Get
    '        End Get
    '    End Property
    '#End Region

#Region "Properties"
    <Description("Indecates if the autocompletition is activated"), Category("Behavior"), _
     DefaultValue(True)> _
     Property SelfComplete() As Boolean
        Get
            Return _SelfComplete
        End Get
        Set(ByVal Value As Boolean)
            _SelfComplete = Value
        End Set
    End Property
    <Description("Indicates that the control will complete the text when focus is loost"), _
     Category("Behavior"), DefaultValue(True)> _
     Property CompleteOnLeave() As Boolean
        Get
            Return _CompleteOnLeave
        End Get
        Set(ByVal Value As Boolean)
            _CompleteOnLeave = Value
        End Set
    End Property
    <Description("Indecates that the control will choose the first item starting whit the controls text"), _
    Category("Behavior"), DefaultValue(False)> _
    Property ForceCompleteOnLeave() As Boolean
        Get
            Return _ForceCompleteOnLeave
        End Get
        Set(ByVal Value As Boolean)
            _ForceCompleteOnLeave = Value
        End Set
    End Property
    <Description("Indicates that the control will correct the spelling on leaving"), _
    Category("Behavior"), DefaultValue(False)> _
    Property TrySimilarOnLeave() As Boolean
        Get
            Return _TrySimilarOnLeave
        End Get
        Set(ByVal Value As Boolean)
            _TrySimilarOnLeave = Value
        End Set
    End Property
    <Description("Indicates that the control will reject incorrect spelling acording to items"), _
     Category("Behavior"), DefaultValue(False)> _
    Property CorrectOnWriting() As Boolean
        Get
            Return _CorrectOnWriting
        End Get
        Set(ByVal Value As Boolean)
            _CorrectOnWriting = Value
        End Set
    End Property
#End Region

#Region "Public functions"
    Public Sub Complete(Optional ByVal TrySimilar As Boolean = False, Optional ByVal Force As Boolean = False)
        If TrySimilar Then
            If Me.FindString(Me.Text) >= 0 Then
                Me.SelectedIndex = Me.FindString(Me.Text)
            Else
                Dim TextToFind As String = Me.Text
                While Me.FindString(TextToFind) < 0
                    If TextToFind.Length = 0 And Force Then
                        If Me.Items.Count > 0 Then
                            Me.SelectedIndex = 0
                        Else
                            Me.Text = ""
                        End If
                        Exit While
                    End If
                    If TextToFind.Length - 1 > 0 Then
                        TextToFind = TextToFind.Substring(0, TextToFind.Length - 1)
                    End If
                    If Me.FindString(TextToFind) >= 0 Then
                        Me.SelectedIndex = Me.FindString(TextToFind)
                        Exit While
                    End If
                End While
            End If
        Else
            Me.SelectedIndex = Me.FindString(Me.Text)
        End If
    End Sub
#End Region

#Region "Funciones privadas"
    Private Sub Validate(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyUp
        If Not _SelfComplete Then
            Exit Sub
        End If
        Dim index As Integer = Me.Text.Length
        If index = 0 Then
            Exit Sub
        End If
        If Me.FindString(Me.Text) < 0 And _CorrectOnWriting And Not e.Alt And Not e.Control And Not e.Shift Then
            Me.Text = OldText
            If Me.Text.Length > 0 Then
                Me.Select(Me.Text.Length - 1, 1)
                Me.Select(Me.Text.Length, 0)
            End If
        Else
            If Not e.Alt And Not e.Control And Not e.Shift And Not e.KeyValue = 8 And Not e.KeyValue = 46 And Not e.KeyValue = 36 _
                    And Not (e.KeyValue >= 37 And e.KeyValue <= 40) Then
                Me.SelectedIndex = Me.FindString(Me.Text)
                Me.Select(index, Me.Text.Length)
            End If
        End If
        Me.Enabled = True
    End Sub
    Private Sub SelfCompletitionComboBox_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown
        OldText = Me.Text.Substring(0, Me.SelectionStart)
    End Sub
    Private Sub SelfCompletitionComboBox_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Leave
        If _CompleteOnLeave And Me.Text <> "" Then
            Complete(_TrySimilarOnLeave, _ForceCompleteOnLeave)
        End If
    End Sub
#End Region



End Class
