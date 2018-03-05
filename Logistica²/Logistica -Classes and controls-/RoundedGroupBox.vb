'''''''''''''''''''''''''''''''''''''''''''''
'           GroupBox redondeada             '
'Autor: Manuel Ruiz                         '
'Fecha: 30 de marzo de 2004                 '
'Descripción: Este control permite dar un   '
'             aspecto diferente a la clásica'
'             GroupBox                      '
'                                           '
'''''''''''''''''''''''''''''''''''''''''''''


Imports System.Drawing
Imports System.Drawing.Drawing2D
Imports System.ComponentModel

'Licenciamiento en tiempo de diseño
<LicenseProvider(GetType(ECRALicenseProvider))> _
Public Class RoundedGroupBox
    Inherits System.Windows.Forms.GroupBox


#Region " Windows Form Designer generated code "

    Private license As license = Nothing

    Public Sub New()
        MyBase.New()
        license = LicenseManager.Validate(GetType(RoundedGroupBox), Me)


        'This call is required by the Windows Form Designer.
        InitializeComponent()

        'Add any initialization after the InitializeComponent() call

    End Sub

    'UserControl1 overrides dispose to clean up the component list.
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
    Private _TextAlignment As HorizontalAlignment = HorizontalAlignment.Left
    Private _FlatStyle As Style
    Private _BorderColor As Color = Color.Gray
#End Region

#Region "Public enum's"
    Public Enum Style As Byte
        Pipe = 0
        Road = 1
        Flat = 2
    End Enum
#End Region

#Region "Properties"
    <Description("Determines the border style of the component"), Category("Appearence"), _
        DefaultValue(Style.Pipe)> _
    Shadows Property FlatStyle() As Style
        Get
            Return _FlatStyle
        End Get
        Set(ByVal Value As Style)
            _FlatStyle = Value
            Refresh()
        End Set
    End Property
    <Description("Determines the color of the border"), Category("Appearence"), _
        DefaultValue(Style.Pipe)> _
    Shadows Property BorderColor() As Color
        Get
            Return _BorderColor
        End Get
        Set(ByVal Value As Color)
            _BorderColor = Value
            Refresh()
        End Set
    End Property
    <Description("Determines the alignment of the title"), Category("Appearence"), _
        DefaultValue(HorizontalAlignment.Left)> _
    Property TextAlignment() As HorizontalAlignment
        Get
            Return _TextAlignment
        End Get
        Set(ByVal Value As HorizontalAlignment)
            _TextAlignment = Value
            Refresh()
        End Set
    End Property
#End Region

#Region "Privated functions"
    Protected Overrides Sub OnPaint(ByVal e As PaintEventArgs)
        Dim Drawer As Graphics = e.Graphics
        Dim Path As New GraphicsPath()
        Dim xTextPos As Integer = 15
        Drawer.Clear(CType(Me.GetContainerControl, Control).BackColor)
        Drawer.InterpolationMode = InterpolationMode.HighQualityBilinear
        Drawer.SmoothingMode = SmoothingMode.AntiAlias
        Path.AddArc(New Rectangle(0, CInt(Me.Font.Height / 2), 30, 30), 180, 90)
        Path.AddLine(15, CInt(Me.Font.Height / 2), Me.Width - 15, CInt(Me.Font.Height / 2))
        Path.AddArc(New Rectangle(Me.Width - 31, CInt(Me.Font.Height / 2), 30, 30), 270, 90)
        Path.AddLine(Me.Width - 1, CInt(Me.Font.Height / 2) + 15, Me.Width - 1, Me.Height - 15)
        Path.AddArc(New Rectangle(Me.Width - 31, Me.Height - 31, 30, 30), 0, 90)
        Path.AddLine(Me.Width - 15, Me.Height - 1, 15, Me.Height - 1)
        Path.AddArc(New Rectangle(0, Me.Height - 31, 30, 30), 90, 90)
        Path.AddLine(0, Me.Height - 15, 0, CInt(Me.Font.Height / 2) + 15)
        Select Case _FlatStyle
            Case Style.Flat
                Drawer.DrawPath(New Pen(_BorderColor, 1), Path)
            Case Style.Pipe
                Drawer.DrawPath(New Pen(_BorderColor, 3), Path)
                Drawer.DrawPath(New Pen(Color.White), Path)
            Case Style.Road
                Drawer.DrawPath(New Pen(Color.White, 3), Path)
                Drawer.DrawPath(New Pen(_BorderColor, 1), Path)
        End Select
        Select Case _TextAlignment
            Case HorizontalAlignment.Right
                xTextPos = Me.Width - CInt(Drawer.MeasureString(Me.Text, Me.Font).Width) - 15
            Case HorizontalAlignment.Center
                xTextPos = CInt((Me.Width - Drawer.MeasureString(Me.Text, Me.Font).Width) / 2)
        End Select
        Drawer.FillRectangle(New SolidBrush(CType(Me.GetContainerControl, Control).BackColor), New Rectangle(xTextPos, 0, CInt(Fix(Drawer.MeasureString(Me.Text, Me.Font).Width)), Me.Font.Height))
        Drawer.DrawString(Me.Text, Me.Font, New SolidBrush(Me.ForeColor), xTextPos, 0)
    End Sub
#End Region
End Class

