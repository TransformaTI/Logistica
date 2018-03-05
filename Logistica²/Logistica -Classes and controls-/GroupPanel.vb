'''''''''''''''''''''''''''''''''''''''''''''
'   Panel expandible en modo de texto       '
'Autor: Manuel Ruiz                         '
'Fecha: 29 de marzo de 2004                 '
'Descripción: Este control permite agrupar  '
'             controles dentro de un panel  '
'             y expandirlo o contraerlo     '
'            `para ahorrar espacio          '
'                                           '
'''''''''''''''''''''''''''''''''''''''''''''

Imports System.ComponentModel

'Licenciamiento en tiempo de diseño
<LicenseProvider(GetType(ECRALicenseProvider)), DefaultEvent("GroupPanelStateChange"), _
 DefaultProperty("GroupPanelState")> _
Public Class GroupPanel
    Inherits System.Windows.Forms.Panel


#Region " Windows Form Designer generated code "

    Private license As license = Nothing

    Public Sub New()
        MyBase.New()
        license = LicenseManager.Validate(GetType(GroupPanel), Me)

        'This call is required by the Windows Form Designer.
        InitializeComponent()

        'Add any initialization after the InitializeComponent() call
        Me.Controls.Add(pnlControl)
        Me.Controls.Add(pnlDivider)
        Me.Show()
        Application.DoEvents()
        pnlDivider.BringToFront()
        pnlControl.Controls.Add(btnExpander)
        pnlControl.Controls.Add(lblTitle)
        lblTitle.BringToFront()
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
    Friend WithEvents pnlDivider As System.Windows.Forms.Panel
    Friend WithEvents lblTitle As System.Windows.Forms.Label
    Friend WithEvents btnExpander As System.Windows.Forms.Button
    Friend WithEvents pnlControl As System.Windows.Forms.Panel
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.pnlDivider = New System.Windows.Forms.Panel()
        Me.lblTitle = New System.Windows.Forms.Label()
        Me.btnExpander = New System.Windows.Forms.Button()
        Me.pnlControl = New System.Windows.Forms.Panel()
        Me.pnlControl.SuspendLayout()
        '
        'pnlDivider
        '
        Me.pnlDivider.BackColor = System.Drawing.SystemColors.Control
        Me.pnlDivider.Dock = System.Windows.Forms.DockStyle.Left
        Me.pnlDivider.Location = New System.Drawing.Point(339, 287)
        Me.pnlDivider.Name = "pnlDivider"
        Me.pnlDivider.Size = New System.Drawing.Size(16, 134)
        Me.pnlDivider.TabIndex = 0
        '
        'lblTitle
        '
        Me.lblTitle.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lblTitle.Location = New System.Drawing.Point(17, 17)
        Me.lblTitle.Name = "lblTitle"
        Me.lblTitle.Size = New System.Drawing.Size(464, 16)
        Me.lblTitle.TabIndex = 0
        Me.lblTitle.Text = "  Title"
        '
        'btnExpander
        '
        Me.btnExpander.Dock = System.Windows.Forms.DockStyle.Left
        Me.btnExpander.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnExpander.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnExpander.Location = New System.Drawing.Point(444, 268)
        Me.btnExpander.Name = "btnExpander"
        Me.btnExpander.Size = New System.Drawing.Size(16, 16)
        Me.btnExpander.TabIndex = 1
        Me.btnExpander.Text = "-"
        '
        'pnlControl
        '
        Me.pnlControl.Controls.AddRange(New System.Windows.Forms.Control() {Me.lblTitle})
        Me.pnlControl.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnlControl.Location = New System.Drawing.Point(409, 336)
        Me.pnlControl.Name = "pnlControl"
        Me.pnlControl.Size = New System.Drawing.Size(480, 16)
        Me.pnlControl.TabIndex = 0
        '
        'GroupPanel
        '
        Me.Size = New System.Drawing.Size(120, 120)
        Me.pnlControl.ResumeLayout(False)

    End Sub

#End Region

#Region "Global variables"
    Private _PanelState As PanelState = PanelState.Expanded
    Private _ExpandedHeight As Integer = Me.Height
    Private _PanelStateEffect As MovementEffect = MovementEffect.MoveAlignedControls
#End Region


#Region "Enumerators"
    Public Enum PanelState As Byte
        Expanded = 0
        Collapsed = 1
    End Enum
    Public Enum MovementEffect As Byte
        MoveAlignedControls = 0
        MoveNextControl = 1
        None = 3
    End Enum

#End Region

#Region "Properties"
    <Description("Sets color of the control's left area"), _
     Category("Appearance"), DefaultValue("White")> _
     Property DividerColor() As Color
        Get
            Return pnlDivider.BackColor
        End Get
        Set(ByVal Value As Color)
            pnlDivider.BackColor = Value
        End Set
    End Property
    <Description("Changes the color of the GroupPanel title"), _
        Category("Appearance"), DefaultValue("SteelBlue")> _
    Property TitleBackColor() As Color
        Get
            Return pnlControl.BackColor
        End Get
        Set(ByVal Value As Color)
            pnlControl.BackColor = Value
        End Set
    End Property
    <Description("Sets the GroupPanel's title"), _
        Category("Appearance"), DefaultValue("Title")> _
    Property Title() As String
        Get
            Return LTrim(lblTitle.Text)
        End Get
        Set(ByVal Value As String)
            lblTitle.Text = "  " & Trim(Value)
        End Set
    End Property
    <Description("Sets GroupPanel's title font color"), _
       Category("Appearance"), DefaultValue("White")> _
       Property TitleForeColor() As Color
        Get
            Return lblTitle.ForeColor
        End Get
        Set(ByVal Value As Color)
            lblTitle.ForeColor = Value
        End Set
    End Property
    <Description("Sets GroupPanel's title font"), _
       Category("Appearance"), DefaultValue("Microsoft Sans Serif, 8.25pt")> _
       Property TitleFont() As Font
        Get
            Return lblTitle.Font
        End Get
        Set(ByVal Value As Font)
            lblTitle.Font = Value
        End Set
    End Property
    <Description("Indicates the GroupPanel's appearance")> _
    Property GroupPanelState() As PanelState
        Get
            Return _PanelState
        End Get
        Set(ByVal Value As PanelState)
            _PanelState = Value
            If Value = PanelState.Expanded Then
                Expand()
            Else
                Collapse()
            End If
        End Set
    End Property
    <Description("The height the control will have when expanded"), Category("Appearence"), DefaultValue(120)> _
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
    Public Event GroupPanelStateChange()
#End Region

#Region "Privated functions"
    Private Sub btnExpander_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnExpander.Click
        If _PanelState = PanelState.Collapsed Then
            Expand()
        Else
            Collapse()
        End If
    End Sub
    Private Sub GroupPanel_Resize(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Resize
        If _PanelState = PanelState.Expanded Then
            _ExpandedHeight = Me.Height
        End If
    End Sub
#End Region

#Region "Public functions"
    Public Sub Expand()
        Dim NControl As Control
        _PanelState = PanelState.Expanded
        btnExpander.Text = "-"
        Me.Height = _ExpandedHeight
        If Not Me.GetContainerControl Is Nothing Then
            Select Case _PanelStateEffect
                Case MovementEffect.MoveAlignedControls
                    For Each NControl In CType(Me.GetContainerControl, Control).Controls
                        If Not NControl Is Me And NControl.Left = Me.Left And NControl.Top > Me.Top Then
                            NControl.Top += _ExpandedHeight - pnlControl.Height
                        End If
                    Next
                Case MovementEffect.MoveNextControl
                    If Not Me.GetContainerControl Is Nothing Then
                        NControl = CType(Me.GetContainerControl, Control).Controls(Me.TabIndex + 1)
                        NControl.Top += _ExpandedHeight - pnlControl.Height
                    End If
            End Select
        End If
        RaiseEvent GroupPanelStateChange()
    End Sub
    Public Sub Collapse()
        Dim NControl As Control
        _PanelState = PanelState.Collapsed
        btnExpander.Text = "+"
        Me.Height = pnlControl.Height
        If Not Me.GetContainerControl Is Nothing Then
            Select Case _PanelStateEffect
                Case MovementEffect.MoveAlignedControls
                    For Each NControl In CType(Me.GetContainerControl, Control).Controls
                        If Not NControl Is Me And NControl.Left = Me.Left And NControl.Top > Me.Top Then
                            NControl.Top -= _ExpandedHeight - pnlControl.Height
                        End If
                    Next
                Case MovementEffect.MoveNextControl
                    If Not Me.GetContainerControl Is Nothing Then
                        NControl = CType(Me.GetContainerControl, Control).Controls(Me.TabIndex + 1)
                        NControl.Top -= _ExpandedHeight - pnlControl.Height
                    End If
            End Select
        End If
        RaiseEvent GroupPanelStateChange()
    End Sub
#End Region


End Class
