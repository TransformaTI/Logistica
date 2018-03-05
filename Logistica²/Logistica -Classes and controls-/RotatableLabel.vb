'''''''''''''''''''''''''''''''''''''''''''''
'   Etiqueta rotable                        '
'Autor: Manuel Ruiz                         '
'Fecha: 29 de marzo de 2004                 '
'Descripción: Este control permite crear    '
'             una etiqueta que rota         '
'                                           '
'''''''''''''''''''''''''''''''''''''''''''''

Imports System.ComponentModel
Imports System.Drawing
Imports System.Math

<DefaultEvent("Rotate"), LicenseProvider(GetType(ECRALicenseProvider))> _
Public Class RotatableLabel
    Inherits System.Windows.Forms.UserControl

#Region " Windows Form Designer generated code "

    Private license As license = Nothing

    Public Sub New()
        MyBase.New()
        license = LicenseManager.Validate(GetType(RotatableLabel), Me)
        'This call is required by the Windows Form Designer.
        InitializeComponent()

        'Add any initialization after the InitializeComponent() call

        Me.Refresh()
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
        '
        'RotatableLabel
        '
        Me.Name = "RotatableLabel"
        Me.Size = New System.Drawing.Size(8, 8)

    End Sub

#End Region

#Region "Private variables"
    Private _Text As String = "RotatableLabel"
    Private _Border As Boolean = False
    Private _RotationAngle As Integer = 90
#End Region

#Region "Properties"
    <Description("The text to be displayed"), Category("Appearence"), _
      DefaultValue("RotatableLabel")> _
    Property Caption() As String
        Get
            Return _Text
        End Get
        Set(ByVal Value As String)
            _Text = Value
            Me.Refresh()
        End Set
    End Property
    <Description("Defines if the border will be drwan"), Category("Appearence")> _
    Property Border() As Boolean
        Get
            Return _Border
        End Get
        Set(ByVal Value As Boolean)
            _Border = Value
            Me.Refresh()
        End Set
    End Property
    <Description("The angle the lable will be rotated"), Category("Appearence"), _
       DefaultValue(90)> _
       Property RotationAngle() As Integer
        Get
            Return _RotationAngle
        End Get
        Set(ByVal Value As Integer)
            _RotationAngle = Value
            Me.Refresh()
            RaiseEvent Rotate()
        End Set
    End Property
#End Region

#Region "Events"
    <Description("Indicates that the rotation angle as changend")> Event Rotate()
#End Region

#Region "Privated sub's and functions"

    Protected Overrides Sub OnPaint(ByVal e As PaintEventArgs)
        Try
            Dim Drawer As Graphics = Me.CreateGraphics
            Dim txtSize As SizeF
            Dim SFormat As New StringFormat(StringFormatFlags.NoClip)
            Drawer.TextRenderingHint = Drawing.Text.TextRenderingHint.AntiAlias
            SFormat.HotkeyPrefix = Drawing.Text.HotkeyPrefix.Show
            txtSize = Drawer.MeasureString(_Text, Me.Font)
            Drawer.Clear(Me.BackColor)
            Me.Height = CInt(Abs(txtSize.Width * Sin(PI * _RotationAngle / 180)) + txtSize.Height)
            Me.Width = CInt(Abs(txtSize.Width * Cos(PI * _RotationAngle / 180)) + txtSize.Height)
            SFormat.Alignment = StringAlignment.Center
            SFormat.LineAlignment = StringAlignment.Center
            If _Border Then
                Drawer.DrawRectangle(New Pen(Me.ForeColor), New Rectangle(0, 0, Me.Width - 1, Me.Height - 1))
            End If
            Drawer.TranslateTransform(CType(Me.Width / 2, Single), CType(Me.Height / 2, Single))
            Drawer.RotateTransform(_RotationAngle)
            Drawer.DrawString(_Text, Me.Font, New SolidBrush(Me.ForeColor), 0, 0, SFormat)
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub
    Private Sub VerticalLabel_ForeColorChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.ForeColorChanged
        Me.Refresh()
    End Sub
    Private Sub RotatableLabel_Resize(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Resize
        Me.Refresh()
    End Sub
#End Region



End Class
