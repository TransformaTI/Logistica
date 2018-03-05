'''''''''''''''''''''''''''''''''''''''''''''
'   Panel expandible en modo gráfico        '
'Autor: Manuel Ruiz                         '
'Fecha: 30 de marzo de 2004                 '
'Descripción: Este control permite agrupar  '
'             controles dentro de un panel  '
'             y expandirlo o contraerlo     '
'             para ahorrar espacio          '
'                                           '
'''''''''''''''''''''''''''''''''''''''''''''

Imports System.ComponentModel

'Licenciamiento en tiempo de diseño

<LicenseProvider(GetType(ECRALicenseProvider))> _
Public Class ToolPanel
    Inherits System.Windows.Forms.Panel

#Region " Windows Form Designer generated code "

    Private license As license = Nothing

    Public Sub New()
        MyBase.New()
        license = LicenseManager.Validate(GetType(ToolPanel), Me)

        'This call is required by the Windows Form Designer.
        InitializeComponent()

        'Add any initialization after the InitializeComponent() call
        Me.Controls.Add(btnExpander)
        btnExpander.Top = 0
        btnExpander.Left = Me.Width - 21
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
    Friend WithEvents btnExpander As System.Windows.Forms.Button
    Friend WithEvents imgBottonArrows As System.Windows.Forms.ImageList
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(ToolPanel))
        Me.btnExpander = New System.Windows.Forms.Button()
        Me.imgBottonArrows = New System.Windows.Forms.ImageList(Me.components)
        '
        'btnExpander
        '
        Me.btnExpander.BackColor = System.Drawing.Color.DarkBlue
        Me.btnExpander.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnExpander.Image = CType(resources.GetObject("btnExpander.Image"), System.Drawing.Bitmap)
        Me.btnExpander.ImageIndex = 0
        Me.btnExpander.ImageList = Me.imgBottonArrows
        Me.btnExpander.Location = New System.Drawing.Point(515, 299)
        Me.btnExpander.Name = "btnExpander"
        Me.btnExpander.Size = New System.Drawing.Size(20, 20)
        Me.btnExpander.TabIndex = 4
        '
        'imgBottonArrows
        '
        Me.imgBottonArrows.ColorDepth = System.Windows.Forms.ColorDepth.Depth32Bit
        Me.imgBottonArrows.ImageSize = New System.Drawing.Size(16, 16)
        Me.imgBottonArrows.ImageStream = CType(resources.GetObject("imgBottonArrows.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.imgBottonArrows.TransparentColor = System.Drawing.Color.Transparent
        '
        'ToolPanel
        '
        Me.BackColor = System.Drawing.Color.WhiteSmoke
        Me.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Size = New System.Drawing.Size(150, 200)

    End Sub

#End Region

#Region "Global variables"
    Private _PanelState As PanelState = PanelState.Expanded
    Private _PanelStateEffect As MovementEffect = MovementEffect.MoveAlignedControls
    Private _ExpandedHeight As Integer = Me.Height
    Private _Title As String = "ToolPanel"
    Private _TitleFont As Font = Me.font
    Private _TitleForeColor As Color = Color.White
    Private _TitleBackColor As Color = Color.DarkBlue
    Private _Style As PanelStyle = PanelStyle.Rectangle
    Private _TitleAlignment As HorizontalAlignment = HorizontalAlignment.Left
    Private Moving As Boolean = False
    Private xPos As Integer
    Private yPos As Integer
    Private _Movable As Boolean = False

#End Region

#Region "Enum's"
    Public Enum PanelState As Byte
        Expanded = 0
        Collapsed = 1
    End Enum
    Public Enum PanelStyle As Byte
        Rectangle = 0
        Rounded = 1
    End Enum
    Public Enum MovementEffect As Byte
        MoveAlignedControls = 0
        MoveNextControl = 1
        None = 3
    End Enum

#End Region

#Region "Properties"
    <Description("Indicates the ToolPanel's state")> _
    Property PanelToolState() As PanelState
        Get
            Return _PanelState
        End Get
        Set(ByVal Value As PanelState)
            _PanelState = Value
            If Value = PanelState.Collapsed Then
                Collapse()
            Else
                Expand()
            End If
        End Set
    End Property
    <Description("Changes the color of the ToolPanel title"), _
        Category("Appearence"), DefaultValue("SteelBlue")> _
            Property TitleBackColor() As Color
        Get
            Return _TitleBackColor
        End Get
        Set(ByVal Value As Color)
            _TitleBackColor = Value
            btnExpander.BackColor = Value
            Me.Refresh()
        End Set
    End Property
    <Description("Sets the ToolPanel's title"), _
        Category("Appearence"), DefaultValue("Title")> _
    Property Title() As String
        Get
            Return _Title
        End Get
        Set(ByVal Value As String)
            _Title = Value
            Refresh()
        End Set
    End Property
    <Description("Sets ToolPanel's title font color"), _
       Category("Appearence"), DefaultValue("White")> _
       Property TitleForeColor() As Color
        Get
            Return _TitleForeColor
        End Get
        Set(ByVal Value As Color)
            _TitleForeColor = Value
            Refresh()
        End Set
    End Property
    <Description("Sets ToolPanel's title font"), _
       Category("Appeareence"), DefaultValue("Microsoft Sans Serif, 8.25pt")> _
       Property TitleFont() As Font
        Get
            Return _TitleFont
        End Get
        Set(ByVal Value As Font)
            If Value.SizeInPoints > 19 Then
                _TitleFont = New Font(Value.FontFamily, 19, Value.Style, GraphicsUnit.Point)
            Else
                _TitleFont = Value
            End If
            Refresh()
        End Set
    End Property
    <Description("Indicates the title's alignment of the control"), Category("Appearence"), _
     DefaultValue(HorizontalAlignment.Left)> _
     Property TitleAlignment() As HorizontalAlignment
        Get
            Return _TitleAlignment
        End Get
        Set(ByVal Value As HorizontalAlignment)
            _TitleAlignment = Value
            Refresh()
        End Set
    End Property
    <Description("Set the style of the control's"), Category("Appearence"), _
     DefaultValue(PanelStyle.Rectangle)> _
     Property Style() As PanelStyle
        Get
            Return _Style
        End Get
        Set(ByVal Value As PanelStyle)
            _Style = Value
            Refresh()
        End Set
    End Property

    <Description("The control's height when it's expanded"), _
     Category("Appearence"), DefaultValue(200)> _
    Property ExpandedHeight() As Integer
        Get
            Return _ExpandedHeight
        End Get
        Set(ByVal Value As Integer)
            _ExpandedHeight = Value
            If _PanelState = PanelState.Expanded Then
                Me.Height = Value
            End If
        End Set
    End Property
    <Description("Indicates if the control can be moved"), Category("Behavior"), _
     DefaultValue(False)> _
     Property Movable() As Boolean
        Get
            Return _Movable
        End Get
        Set(ByVal Value As Boolean)
            _Movable = Value
        End Set
    End Property
    <Description("Indicates how other control will be affected whe the control's state changes"), _
Category("Behavior"), DefaultValue(MovementEffect.MoveAlignedControls)> _
Property PanelStateEffect() As MovementEffect
        Get
            Return _PanelStateEffect
        End Get
        Set(ByVal Value As MovementEffect)
            _PanelStateEffect = Value
        End Set
    End Property
#End Region

#Region "Events"
    Public Event ToolPanelStateChange(ByVal sender As Object, ByVal e As System.EventArgs)
#End Region


#Region "Privated functions"
    Private Sub btnExpander_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnExpander.Click
        Dim NextCtrl As Control = Nothing
        If _PanelState = PanelState.Expanded Then
            _PanelState = PanelState.Collapsed
            Collapse()
        Else
            _PanelState = PanelState.Expanded
            Expand()
        End If

    End Sub

    Private Sub ToolPanel_Resize(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Resize
        btnExpander.Left = Me.Width - 21
        If _PanelState = PanelState.Expanded Then
            _ExpandedHeight = Me.Height
        End If
    End Sub
    Protected Overrides Sub OnPaint(ByVal e As PaintEventArgs)
        Dim Drawer As Graphics = e.Graphics
        Dim txtSize As SizeF
        Dim LPos As Integer
        txtSize = Drawer.MeasureString(_Title, _TitleFont)
        Select Case _TitleAlignment
            Case HorizontalAlignment.Center
                LPos = CInt((Me.Width - txtSize.Width - 20) / 2)
            Case HorizontalAlignment.Left
                LPos = 0
            Case HorizontalAlignment.Right
                LPos = CInt(Me.Width - txtSize.Width - 20)
        End Select
        Drawer.TextRenderingHint = Drawing.Text.TextRenderingHint.AntiAlias
        Drawer.Clear(Me.BackColor)
        If _Style = PanelStyle.Rectangle Then
            Drawer.FillRectangle(New SolidBrush(_TitleBackColor), New Rectangle(0, 0, Me.Width, 20))
            Drawer.DrawString(_Title, _TitleFont, New SolidBrush(_TitleForeColor), LPos, (20 - txtSize.Height) / 2)
        End If
        btnExpander.BringToFront()
    End Sub
#End Region

#Region "Public functions"
    Public Sub Expand()
        Dim NControl As Control
        btnExpander.ImageIndex = 0
        _PanelState = PanelState.Expanded
        Me.Height = _ExpandedHeight
        If Not Me.GetContainerControl Is Nothing Then
            Select Case _PanelStateEffect
                Case MovementEffect.MoveAlignedControls
                    For Each NControl In CType(Me.GetContainerControl, Control).Controls
                        If Not NControl Is Me And NControl.Left = Me.Left And NControl.Top > Me.Top Then
                            NControl.Top += _ExpandedHeight - 20
                        End If
                    Next
                Case MovementEffect.MoveNextControl
                    If Not Me.GetContainerControl Is Nothing Then
                        NControl = CType(Me.GetContainerControl, Control).Controls(Me.TabIndex + 1)
                        NControl.Top += _ExpandedHeight - 20
                    End If
            End Select
            RaiseEvent ToolPanelStateChange(Me, New System.EventArgs())
        End If
    End Sub
    Public Sub Collapse()
        Dim NControl As Control
        btnExpander.ImageIndex = 1
        _PanelState = PanelState.Collapsed
        Me.Height = 21
        If Not Me.GetContainerControl Is Nothing Then
            Select Case _PanelStateEffect
                Case MovementEffect.MoveAlignedControls
                    For Each NControl In CType(Me.GetContainerControl, Control).Controls
                        If Not NControl Is Me And NControl.Left = Me.Left And NControl.Top > Me.Top Then
                            NControl.Top -= _ExpandedHeight - 20
                        End If
                    Next
                Case MovementEffect.MoveNextControl
                    If Not Me.GetContainerControl Is Nothing Then
                        NControl = CType(Me.GetContainerControl, Control).Controls(Me.TabIndex + 1)
                        NControl.Top -= _ExpandedHeight - 20
                    End If
            End Select
        End If
        RaiseEvent ToolPanelStateChange(Me, New System.EventArgs())
    End Sub
#End Region


    Private Sub ToolPanel_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles MyBase.MouseDown
        If _Movable Then
            xPos = e.X
            yPos = e.Y
            If e.Button = MouseButtons.Left And xPos - Me.Left < 21 And yPos - Me.Top < Me.Width - 21 Then
                Moving = True
            End If
        End If
    End Sub


    Private Sub ToolPanel_MouseUp(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles MyBase.MouseUp
        If Moving And _Movable Then
            Moving = False
            Dim NewLocation As New System.Drawing.Point(Me.Left + e.X - xPos, Me.Top + e.Y - yPos)
            Me.Location = NewLocation
            If Me.Top < 0 Then
                Me.Top = 0
            End If
            If Me.Left < 0 Then
                Me.Left = 0
            End If

        End If
    End Sub

End Class

