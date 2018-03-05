Imports System.ComponentModel

<LicenseProvider(GetType(ECRALicenseProvider))> _
Public Class Figure
    Inherits System.Windows.Forms.UserControl

#Region " Windows Form Designer generated code "
    Private license As License

    Public Sub New()
        MyBase.New()
        license = LicenseManager.Validate(GetType(Figure), Me)
        'This call is required by the Windows Form Designer.
        InitializeComponent()

        'Add any initialization after the InitializeComponent() call
        Me.ResizeRedraw = True
    End Sub

    'UserControl overrides dispose to clean up the component list.
    Protected Overloads Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing Then
            If Not (components Is Nothing) Then
                components.Dispose()
            End If
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

#Region "Variables globales"
    Private _FillColor As Color = Color.LightSteelBlue
    Private _Fill As Boolean = True
    Private _LineColor As Color = Color.RoyalBlue
    Private _Style As FigureStyle = FigureStyle.Line
    Private _LineWidth As Single = 2
#End Region
#Region "Enumaraciones y estructuras"
    Public Enum FigureStyle As Byte
        Line = 0
        Circle = 1
        Rectangle = 2
        Triangle = 3
    End Enum
#End Region
#Region "Propiedades"
    <Description("Indicates if the figure will be filled"), Category("Appearence"), DefaultValue(True)> _
    Property Fill() As Boolean
        Get
            Return _Fill
        End Get
        Set(ByVal Value As Boolean)
            _Fill = Value
            Refresh()
        End Set
    End Property
    <Description("The color the figure will be fill with"), Category("Appearence")> _
    Property FillColor() As Color
        Get
            Return _FillColor
        End Get
        Set(ByVal Value As Color)
            _FillColor = Value
            Refresh()
        End Set
    End Property
    <Description("The color of the figure's line"), Category("Appearence")> _
    Property LineColor() As Color
        Get
            Return _LineColor
        End Get
        Set(ByVal Value As Color)
            _LineColor = Value
            Refresh()
        End Set
    End Property
    <Description("The shape of the figure"), Category("Appearence"), DefaultValue(FigureStyle.Line)> _
    Property Style() As FigureStyle
        Get
            Return _Style
        End Get
        Set(ByVal Value As FigureStyle)
            _Style = Value
            Refresh()
        End Set
    End Property
    <Description("The width of the figure's line"), Category("Appearence"), DefaultValue(2)> _
    Property LineWidth() As Single
        Get
            Return _LineWidth
        End Get
        Set(ByVal Value As Single)
            _LineWidth = Value
            Refresh()
        End Set
    End Property
#End Region

#Region "Funciones y subrutinas reemplazadas"
    Protected Overrides Sub OnPaint(ByVal e As PaintEventArgs)
        Dim Drawer As Graphics = e.Graphics
        Dim DPen As New Pen(_LineColor, _LineWidth)
        Dim DBrush As New SolidBrush(_FillColor)
        Drawer.Clear(Me.ParentForm.BackColor)
        Drawer.SmoothingMode = Drawing.Drawing2D.SmoothingMode.AntiAlias
        Select Case _Style
            Case FigureStyle.Line
                Drawer.DrawLine(DPen, 0, CType((Me.Height - 1) / 2, Single), Me.Width, CType((Me.Height - 1) / 2, Single))
            Case FigureStyle.Circle
                Drawer.DrawEllipse(DPen, New Rectangle(0, 0, Me.Width - 1, Me.Height - 1))
                If _Fill Then
                    Drawer.FillEllipse(DBrush, New Rectangle(0, 0, Me.Width - 1, Me.Height - 1))
                End If
            Case FigureStyle.Rectangle
                Drawer.DrawRectangle(DPen, New Rectangle(0, 0, Me.Width - 1, Me.Height - 1))
                If _Fill Then
                    Drawer.FillRectangle(DBrush, New Rectangle(0, 0, Me.Width - 1, Me.Height - 1))
                End If
            Case FigureStyle.Triangle
                Dim TPoints As Drawing.PointF() = {New PointF(CType((Me.Width - 1) / 2, Single), 0), _
                            New PointF(0, CType(Me.Height - 1, Single)), New PointF(CType(Me.Width - 1, Single), CType(Me.Height - 1, Single))}
                Drawer.DrawPolygon(DPen, TPoints)
                If _Fill Then
                    Drawer.FillPolygon(DBrush, TPoints)
                End If
        End Select

    End Sub
#End Region


End Class
