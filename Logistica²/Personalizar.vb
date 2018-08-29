Imports System.IO
Imports Logistica

Public Class frmPersonalizar
    Inherits System.Windows.Forms.Form

#Region " Windows Form Designer generated code "

    Public Sub New(ByVal Pantalla As String)
        MyBase.New()

        'This call is required by the Windows Form Designer.
        InitializeComponent()

        'Add any initialization after the InitializeComponent() call
        If OperacionLogistica(6).Habilitada Then
            mniLogisticos.Visible = True
        End If
        If OperacionLogistica(7).Habilitada Then
            mniRutas.Visible = True
        End If

        CargaElementosConfiguracion(Pantalla)
        CargaConfiguracion()
    End Sub

    'Form overrides dispose to clean up the component list.
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
    Friend WithEvents pnlBotones As System.Windows.Forms.Panel
    Friend WithEvents btnAceptar As System.Windows.Forms.Button
    Friend WithEvents btnCancelar As System.Windows.Forms.Button
    Friend WithEvents imgPerzonalizar As System.Windows.Forms.ImageList
    Friend WithEvents dlgColor As System.Windows.Forms.ColorDialog
    Friend WithEvents tpnlPrincipal As Logistica.ToolPanel
    Friend WithEvents lblBarraPrincipal As System.Windows.Forms.Label
    Friend WithEvents btnBarraPrincipal As System.Windows.Forms.Button
    Friend WithEvents btnDefault As System.Windows.Forms.Button
    Friend WithEvents tpnlOperador As Logistica.ToolPanel
    Friend WithEvents lblBarraOperador As System.Windows.Forms.Label
    Friend WithEvents btnBarraOperador As System.Windows.Forms.Button
    Friend WithEvents btnATablaOperador As System.Windows.Forms.Button
    Friend WithEvents lblATablaOperador As System.Windows.Forms.Label
    Friend WithEvents lblFTablaOperador As System.Windows.Forms.Label
    Friend WithEvents btnFTablaOperador As System.Windows.Forms.Button
    Friend WithEvents btnTTablaOperador As System.Windows.Forms.Button
    Friend WithEvents lblTTablaOperador As System.Windows.Forms.Label
    Friend WithEvents lblFInfoOperador As System.Windows.Forms.Label
    Friend WithEvents btnFInfoOperador As System.Windows.Forms.Button
    Friend WithEvents btnTInfoOperador As System.Windows.Forms.Button
    Friend WithEvents lblTBFOperador As System.Windows.Forms.Label
    Friend WithEvents lblTInfoOperador As System.Windows.Forms.Label
    Friend WithEvents btnTBFOperador As System.Windows.Forms.Button
    Friend WithEvents lblTBTOperador As System.Windows.Forms.Label
    Friend WithEvents btnTBTOperador As System.Windows.Forms.Button
    Friend WithEvents tpnlAutotanque As Logistica.ToolPanel
    Friend WithEvents btnFInfoAutotanque As System.Windows.Forms.Button
    Friend WithEvents btnATablaAutotanque As System.Windows.Forms.Button
    Friend WithEvents lblATablaAutotanque As System.Windows.Forms.Label
    Friend WithEvents lblBarraAutotanque As System.Windows.Forms.Label
    Friend WithEvents btnBarraAutotanque As System.Windows.Forms.Button
    Friend WithEvents lblFTablaAutotanque As System.Windows.Forms.Label
    Friend WithEvents btnFTablaAutotanque As System.Windows.Forms.Button
    Friend WithEvents btnTTablaAutotanque As System.Windows.Forms.Button
    Friend WithEvents lblTTablaAutotanque As System.Windows.Forms.Label
    Friend WithEvents btnTInfoAutotanque As System.Windows.Forms.Button
    Friend WithEvents btnTBFAutotanque As System.Windows.Forms.Button
    Friend WithEvents lblTBFAutotanque As System.Windows.Forms.Label
    Friend WithEvents lblFInfoAutotanque As System.Windows.Forms.Label
    Friend WithEvents lblTInfoAutotanque As System.Windows.Forms.Label
    Friend WithEvents lblTBTAutotanque As System.Windows.Forms.Label
    Friend WithEvents btnTBTAutotanque As System.Windows.Forms.Button
    Friend WithEvents tpnlAsignacion As Logistica.ToolPanel
    Friend WithEvents mnuMas As System.Windows.Forms.MainMenu
    Friend WithEvents mniMas As System.Windows.Forms.MenuItem
    Friend WithEvents mniPrincipal As System.Windows.Forms.MenuItem
    Friend WithEvents mniOperadores As System.Windows.Forms.MenuItem
    Friend WithEvents mniAutotanques As System.Windows.Forms.MenuItem
    Friend WithEvents mniAsignaciones As System.Windows.Forms.MenuItem
    Friend WithEvents pnlGrupos As System.Windows.Forms.Panel
    Friend WithEvents gpnlEmpleadosPrestamo As Logistica.GroupPanel
    Friend WithEvents lblTextoEmpleadosPrestamo As System.Windows.Forms.Label
    Friend WithEvents btnTextoEmpleadosPrestamo As System.Windows.Forms.Button
    Friend WithEvents lblAlternoEmpleadosPrestamo As System.Windows.Forms.Label
    Friend WithEvents btnAlternoEmpleadosPrestamo As System.Windows.Forms.Button
    Friend WithEvents lblFondoEmpleadosPrestamo As System.Windows.Forms.Label
    Friend WithEvents btnFondoEmpleadosPrestamo As System.Windows.Forms.Button
    Friend WithEvents gpnlAutotanquesSA As Logistica.GroupPanel
    Friend WithEvents lblTextAutotanquesSA As System.Windows.Forms.Label
    Friend WithEvents btnTextoAutotanquesSA As System.Windows.Forms.Button
    Friend WithEvents lblAlternoAutotanquesSA As System.Windows.Forms.Label
    Friend WithEvents btnAlternoAutotanquesSA As System.Windows.Forms.Button
    Friend WithEvents lblFondoAutotanquesSA As System.Windows.Forms.Label
    Friend WithEvents btnFondoAutotanquesSA As System.Windows.Forms.Button
    Friend WithEvents gpnlEmpleadosSA As Logistica.GroupPanel
    Friend WithEvents lblTextoEmpleadosSA As System.Windows.Forms.Label
    Friend WithEvents btnTextoEmpleadosSA As System.Windows.Forms.Button
    Friend WithEvents lblAlternoEmpleadosSA As System.Windows.Forms.Label
    Friend WithEvents lblFondoEmpleadosSA As System.Windows.Forms.Label
    Friend WithEvents btnFondoEmpleadosSA As System.Windows.Forms.Button
    Friend WithEvents gpnlOperadores As Logistica.GroupPanel
    Friend WithEvents lblTextoTituloOperadores As System.Windows.Forms.Label
    Friend WithEvents btnTextoTituloOperadores As System.Windows.Forms.Button
    Friend WithEvents lblFondoTituloOperadores As System.Windows.Forms.Label
    Friend WithEvents btnFondoTituloOperadores As System.Windows.Forms.Button
    Friend WithEvents lblTextoOperadores As System.Windows.Forms.Label
    Friend WithEvents btnTextoOperadores As System.Windows.Forms.Button
    Friend WithEvents lblAlternoOperadores As System.Windows.Forms.Label
    Friend WithEvents btnAlternoOperadores As System.Windows.Forms.Button
    Friend WithEvents lblFondoOperadores As System.Windows.Forms.Label
    Friend WithEvents btnFondoOperadores As System.Windows.Forms.Button
    Friend WithEvents gpnlFolios As Logistica.GroupPanel
    Friend WithEvents lblTextoTituloFolios As System.Windows.Forms.Label
    Friend WithEvents btnTextoTituloFolios As System.Windows.Forms.Button
    Friend WithEvents lblFonfoTituloFolios As System.Windows.Forms.Label
    Friend WithEvents btnFondoTituloFolios As System.Windows.Forms.Button
    Friend WithEvents lblSeleccionFolios As System.Windows.Forms.Label
    Friend WithEvents btnSeleccionFolios As System.Windows.Forms.Button
    Friend WithEvents lblTextoFolios As System.Windows.Forms.Label
    Friend WithEvents btnTextoFolios As System.Windows.Forms.Button
    Friend WithEvents lblAlternoFolios As System.Windows.Forms.Label
    Friend WithEvents btnAlternoFolios As System.Windows.Forms.Button
    Friend WithEvents lblFondoFolios As System.Windows.Forms.Label
    Friend WithEvents btnFondoFolios As System.Windows.Forms.Button
    Friend WithEvents gpnlAutotanquesPrestamo As Logistica.GroupPanel
    Friend WithEvents lblTextoAutotanquesPrestamo As System.Windows.Forms.Label
    Friend WithEvents btnTextoAutotanquesPrestamo As System.Windows.Forms.Button
    Friend WithEvents lblAlternoAutotanquesPrestamo As System.Windows.Forms.Label
    Friend WithEvents btnAlternoAutotanquesPrestamo As System.Windows.Forms.Button
    Friend WithEvents lblFondoAutotanquesPrestamo As System.Windows.Forms.Label
    Friend WithEvents btnFondoAutotanquesPrestamo As System.Windows.Forms.Button
    Friend WithEvents gpnlEmpleadosPrestados As Logistica.GroupPanel
    Friend WithEvents lblTextoEmpleadosPrestados As System.Windows.Forms.Label
    Friend WithEvents btnTextoEmpleadosPrestados As System.Windows.Forms.Button
    Friend WithEvents lblAlternoEmpleadosPrestados As System.Windows.Forms.Label
    Friend WithEvents btnAlternoEmpleadosPrestados As System.Windows.Forms.Button
    Friend WithEvents lblFondoEmpleadosPrestados As System.Windows.Forms.Label
    Friend WithEvents btnFondoEmpleadosPrestados As System.Windows.Forms.Button
    Friend WithEvents gpnlAutotanquesPrestados As Logistica.GroupPanel
    Friend WithEvents lblTextoAutotanquesPrestados As System.Windows.Forms.Label
    Friend WithEvents btnTextoAutotanquesPrestados As System.Windows.Forms.Button
    Friend WithEvents lblAlternoAutotanquesPrestados As System.Windows.Forms.Label
    Friend WithEvents btnAlternoAutotanquesPrestados As System.Windows.Forms.Button
    Friend WithEvents lblFondoAutotanquesPrestados As System.Windows.Forms.Label
    Friend WithEvents btnFondoAutotanquesPrestados As System.Windows.Forms.Button
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents lblBarraAsignacion As System.Windows.Forms.Label
    Friend WithEvents btnBarraAsignacion As System.Windows.Forms.Button
    Friend WithEvents btnAlternoEmpleadosSA As System.Windows.Forms.Button
    Friend WithEvents lblBloquear As System.Windows.Forms.Label
    Friend WithEvents nudBloqueo As System.Windows.Forms.NumericUpDown
    Friend WithEvents btnATablaLogistico As System.Windows.Forms.Button
    Friend WithEvents lblATablaLogistico As System.Windows.Forms.Label
    Friend WithEvents lblBarraLogistico As System.Windows.Forms.Label
    Friend WithEvents btnBarraLogistico As System.Windows.Forms.Button
    Friend WithEvents lblFTablaLogistico As System.Windows.Forms.Label
    Friend WithEvents btnFTablaLogistico As System.Windows.Forms.Button
    Friend WithEvents btnTTablaLogistico As System.Windows.Forms.Button
    Friend WithEvents lblTTablaLogistico As System.Windows.Forms.Label
    Friend WithEvents tpnlLogistico As Logistica.ToolPanel
    Friend WithEvents mniLogisticos As System.Windows.Forms.MenuItem
    Friend WithEvents tpnlRuta As Logistica.ToolPanel
    Friend WithEvents btnATablaRuta As System.Windows.Forms.Button
    Friend WithEvents lblATablaRuta As System.Windows.Forms.Label
    Friend WithEvents lblBarraRuta As System.Windows.Forms.Label
    Friend WithEvents btnBarraRuta As System.Windows.Forms.Button
    Friend WithEvents lblFTablaRuta As System.Windows.Forms.Label
    Friend WithEvents btnFTablaRuta As System.Windows.Forms.Button
    Friend WithEvents btnTTablaRuta As System.Windows.Forms.Button
    Friend WithEvents lblTTablaRuta As System.Windows.Forms.Label
    Friend WithEvents mniRutas As System.Windows.Forms.MenuItem
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(frmPersonalizar))
        Me.pnlBotones = New System.Windows.Forms.Panel()
        Me.btnCancelar = New System.Windows.Forms.Button()
        Me.imgPerzonalizar = New System.Windows.Forms.ImageList(Me.components)
        Me.btnAceptar = New System.Windows.Forms.Button()
        Me.btnDefault = New System.Windows.Forms.Button()
        Me.dlgColor = New System.Windows.Forms.ColorDialog()
        Me.tpnlPrincipal = New Logistica.ToolPanel()
        Me.nudBloqueo = New System.Windows.Forms.NumericUpDown()
        Me.lblBloquear = New System.Windows.Forms.Label()
        Me.btnBarraPrincipal = New System.Windows.Forms.Button()
        Me.lblBarraPrincipal = New System.Windows.Forms.Label()
        Me.tpnlOperador = New Logistica.ToolPanel()
        Me.btnFInfoOperador = New System.Windows.Forms.Button()
        Me.btnATablaOperador = New System.Windows.Forms.Button()
        Me.lblATablaOperador = New System.Windows.Forms.Label()
        Me.lblBarraOperador = New System.Windows.Forms.Label()
        Me.btnBarraOperador = New System.Windows.Forms.Button()
        Me.lblFTablaOperador = New System.Windows.Forms.Label()
        Me.btnFTablaOperador = New System.Windows.Forms.Button()
        Me.btnTTablaOperador = New System.Windows.Forms.Button()
        Me.lblTTablaOperador = New System.Windows.Forms.Label()
        Me.btnTInfoOperador = New System.Windows.Forms.Button()
        Me.btnTBFOperador = New System.Windows.Forms.Button()
        Me.lblTBFOperador = New System.Windows.Forms.Label()
        Me.lblFInfoOperador = New System.Windows.Forms.Label()
        Me.lblTInfoOperador = New System.Windows.Forms.Label()
        Me.lblTBTOperador = New System.Windows.Forms.Label()
        Me.btnTBTOperador = New System.Windows.Forms.Button()
        Me.tpnlAutotanque = New Logistica.ToolPanel()
        Me.btnFInfoAutotanque = New System.Windows.Forms.Button()
        Me.btnATablaAutotanque = New System.Windows.Forms.Button()
        Me.lblATablaAutotanque = New System.Windows.Forms.Label()
        Me.lblBarraAutotanque = New System.Windows.Forms.Label()
        Me.btnBarraAutotanque = New System.Windows.Forms.Button()
        Me.lblFTablaAutotanque = New System.Windows.Forms.Label()
        Me.btnFTablaAutotanque = New System.Windows.Forms.Button()
        Me.btnTTablaAutotanque = New System.Windows.Forms.Button()
        Me.lblTTablaAutotanque = New System.Windows.Forms.Label()
        Me.btnTInfoAutotanque = New System.Windows.Forms.Button()
        Me.btnTBFAutotanque = New System.Windows.Forms.Button()
        Me.lblTBFAutotanque = New System.Windows.Forms.Label()
        Me.lblFInfoAutotanque = New System.Windows.Forms.Label()
        Me.lblTInfoAutotanque = New System.Windows.Forms.Label()
        Me.lblTBTAutotanque = New System.Windows.Forms.Label()
        Me.btnTBTAutotanque = New System.Windows.Forms.Button()
        Me.tpnlAsignacion = New Logistica.ToolPanel()
        Me.pnlGrupos = New System.Windows.Forms.Panel()
        Me.gpnlAutotanquesPrestados = New Logistica.GroupPanel()
        Me.lblTextoAutotanquesPrestados = New System.Windows.Forms.Label()
        Me.btnTextoAutotanquesPrestados = New System.Windows.Forms.Button()
        Me.lblAlternoAutotanquesPrestados = New System.Windows.Forms.Label()
        Me.btnAlternoAutotanquesPrestados = New System.Windows.Forms.Button()
        Me.lblFondoAutotanquesPrestados = New System.Windows.Forms.Label()
        Me.btnFondoAutotanquesPrestados = New System.Windows.Forms.Button()
        Me.gpnlEmpleadosPrestados = New Logistica.GroupPanel()
        Me.lblTextoEmpleadosPrestados = New System.Windows.Forms.Label()
        Me.btnTextoEmpleadosPrestados = New System.Windows.Forms.Button()
        Me.lblAlternoEmpleadosPrestados = New System.Windows.Forms.Label()
        Me.btnAlternoEmpleadosPrestados = New System.Windows.Forms.Button()
        Me.lblFondoEmpleadosPrestados = New System.Windows.Forms.Label()
        Me.btnFondoEmpleadosPrestados = New System.Windows.Forms.Button()
        Me.gpnlAutotanquesPrestamo = New Logistica.GroupPanel()
        Me.lblTextoAutotanquesPrestamo = New System.Windows.Forms.Label()
        Me.btnTextoAutotanquesPrestamo = New System.Windows.Forms.Button()
        Me.lblAlternoAutotanquesPrestamo = New System.Windows.Forms.Label()
        Me.btnAlternoAutotanquesPrestamo = New System.Windows.Forms.Button()
        Me.lblFondoAutotanquesPrestamo = New System.Windows.Forms.Label()
        Me.btnFondoAutotanquesPrestamo = New System.Windows.Forms.Button()
        Me.gpnlEmpleadosPrestamo = New Logistica.GroupPanel()
        Me.lblTextoEmpleadosPrestamo = New System.Windows.Forms.Label()
        Me.btnTextoEmpleadosPrestamo = New System.Windows.Forms.Button()
        Me.lblAlternoEmpleadosPrestamo = New System.Windows.Forms.Label()
        Me.btnAlternoEmpleadosPrestamo = New System.Windows.Forms.Button()
        Me.lblFondoEmpleadosPrestamo = New System.Windows.Forms.Label()
        Me.btnFondoEmpleadosPrestamo = New System.Windows.Forms.Button()
        Me.gpnlAutotanquesSA = New Logistica.GroupPanel()
        Me.lblTextAutotanquesSA = New System.Windows.Forms.Label()
        Me.btnTextoAutotanquesSA = New System.Windows.Forms.Button()
        Me.lblAlternoAutotanquesSA = New System.Windows.Forms.Label()
        Me.btnAlternoAutotanquesSA = New System.Windows.Forms.Button()
        Me.lblFondoAutotanquesSA = New System.Windows.Forms.Label()
        Me.btnFondoAutotanquesSA = New System.Windows.Forms.Button()
        Me.gpnlEmpleadosSA = New Logistica.GroupPanel()
        Me.lblTextoEmpleadosSA = New System.Windows.Forms.Label()
        Me.btnTextoEmpleadosSA = New System.Windows.Forms.Button()
        Me.lblAlternoEmpleadosSA = New System.Windows.Forms.Label()
        Me.btnAlternoEmpleadosSA = New System.Windows.Forms.Button()
        Me.lblFondoEmpleadosSA = New System.Windows.Forms.Label()
        Me.btnFondoEmpleadosSA = New System.Windows.Forms.Button()
        Me.gpnlOperadores = New Logistica.GroupPanel()
        Me.lblTextoTituloOperadores = New System.Windows.Forms.Label()
        Me.btnTextoTituloOperadores = New System.Windows.Forms.Button()
        Me.lblFondoTituloOperadores = New System.Windows.Forms.Label()
        Me.btnFondoTituloOperadores = New System.Windows.Forms.Button()
        Me.lblTextoOperadores = New System.Windows.Forms.Label()
        Me.btnTextoOperadores = New System.Windows.Forms.Button()
        Me.lblAlternoOperadores = New System.Windows.Forms.Label()
        Me.btnAlternoOperadores = New System.Windows.Forms.Button()
        Me.lblFondoOperadores = New System.Windows.Forms.Label()
        Me.btnFondoOperadores = New System.Windows.Forms.Button()
        Me.gpnlFolios = New Logistica.GroupPanel()
        Me.lblTextoTituloFolios = New System.Windows.Forms.Label()
        Me.btnTextoTituloFolios = New System.Windows.Forms.Button()
        Me.lblFonfoTituloFolios = New System.Windows.Forms.Label()
        Me.btnFondoTituloFolios = New System.Windows.Forms.Button()
        Me.lblSeleccionFolios = New System.Windows.Forms.Label()
        Me.btnSeleccionFolios = New System.Windows.Forms.Button()
        Me.lblTextoFolios = New System.Windows.Forms.Label()
        Me.btnTextoFolios = New System.Windows.Forms.Button()
        Me.lblAlternoFolios = New System.Windows.Forms.Label()
        Me.btnAlternoFolios = New System.Windows.Forms.Button()
        Me.lblFondoFolios = New System.Windows.Forms.Label()
        Me.btnFondoFolios = New System.Windows.Forms.Button()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.lblBarraAsignacion = New System.Windows.Forms.Label()
        Me.btnBarraAsignacion = New System.Windows.Forms.Button()
        Me.mnuMas = New System.Windows.Forms.MainMenu()
        Me.mniMas = New System.Windows.Forms.MenuItem()
        Me.mniPrincipal = New System.Windows.Forms.MenuItem()
        Me.mniOperadores = New System.Windows.Forms.MenuItem()
        Me.mniAutotanques = New System.Windows.Forms.MenuItem()
        Me.mniLogisticos = New System.Windows.Forms.MenuItem()
        Me.mniRutas = New System.Windows.Forms.MenuItem()
        Me.mniAsignaciones = New System.Windows.Forms.MenuItem()
        Me.tpnlLogistico = New Logistica.ToolPanel()
        Me.btnATablaLogistico = New System.Windows.Forms.Button()
        Me.lblATablaLogistico = New System.Windows.Forms.Label()
        Me.lblBarraLogistico = New System.Windows.Forms.Label()
        Me.btnBarraLogistico = New System.Windows.Forms.Button()
        Me.lblFTablaLogistico = New System.Windows.Forms.Label()
        Me.btnFTablaLogistico = New System.Windows.Forms.Button()
        Me.btnTTablaLogistico = New System.Windows.Forms.Button()
        Me.lblTTablaLogistico = New System.Windows.Forms.Label()
        Me.tpnlRuta = New Logistica.ToolPanel()
        Me.btnATablaRuta = New System.Windows.Forms.Button()
        Me.lblATablaRuta = New System.Windows.Forms.Label()
        Me.lblBarraRuta = New System.Windows.Forms.Label()
        Me.btnBarraRuta = New System.Windows.Forms.Button()
        Me.lblFTablaRuta = New System.Windows.Forms.Label()
        Me.btnFTablaRuta = New System.Windows.Forms.Button()
        Me.btnTTablaRuta = New System.Windows.Forms.Button()
        Me.lblTTablaRuta = New System.Windows.Forms.Label()
        Me.pnlBotones.SuspendLayout()
        Me.tpnlPrincipal.SuspendLayout()
        CType(Me.nudBloqueo, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tpnlOperador.SuspendLayout()
        Me.tpnlAutotanque.SuspendLayout()
        Me.tpnlAsignacion.SuspendLayout()
        Me.pnlGrupos.SuspendLayout()
        Me.gpnlAutotanquesPrestados.SuspendLayout()
        Me.gpnlEmpleadosPrestados.SuspendLayout()
        Me.gpnlAutotanquesPrestamo.SuspendLayout()
        Me.gpnlEmpleadosPrestamo.SuspendLayout()
        Me.gpnlAutotanquesSA.SuspendLayout()
        Me.gpnlEmpleadosSA.SuspendLayout()
        Me.gpnlOperadores.SuspendLayout()
        Me.gpnlFolios.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.tpnlLogistico.SuspendLayout()
        Me.tpnlRuta.SuspendLayout()
        Me.SuspendLayout()
        '
        'pnlBotones
        '
        Me.pnlBotones.Controls.AddRange(New System.Windows.Forms.Control() {Me.btnCancelar, Me.btnAceptar, Me.btnDefault})
        Me.pnlBotones.Dock = System.Windows.Forms.DockStyle.Right
        Me.pnlBotones.Location = New System.Drawing.Point(198, 0)
        Me.pnlBotones.Name = "pnlBotones"
        Me.pnlBotones.Size = New System.Drawing.Size(88, 543)
        Me.pnlBotones.TabIndex = 1
        '
        'btnCancelar
        '
        Me.btnCancelar.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnCancelar.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnCancelar.Image = CType(resources.GetObject("btnCancelar.Image"), System.Drawing.Bitmap)
        Me.btnCancelar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnCancelar.ImageIndex = 1
        Me.btnCancelar.ImageList = Me.imgPerzonalizar
        Me.btnCancelar.Location = New System.Drawing.Point(8, 66)
        Me.btnCancelar.Name = "btnCancelar"
        Me.btnCancelar.TabIndex = 1
        Me.btnCancelar.Text = "&Cancelar"
        Me.btnCancelar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'imgPerzonalizar
        '
        Me.imgPerzonalizar.ColorDepth = System.Windows.Forms.ColorDepth.Depth8Bit
        Me.imgPerzonalizar.ImageSize = New System.Drawing.Size(16, 16)
        Me.imgPerzonalizar.ImageStream = CType(resources.GetObject("imgPerzonalizar.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.imgPerzonalizar.TransparentColor = System.Drawing.Color.Transparent
        '
        'btnAceptar
        '
        Me.btnAceptar.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnAceptar.Image = CType(resources.GetObject("btnAceptar.Image"), System.Drawing.Bitmap)
        Me.btnAceptar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnAceptar.ImageIndex = 0
        Me.btnAceptar.ImageList = Me.imgPerzonalizar
        Me.btnAceptar.Location = New System.Drawing.Point(8, 6)
        Me.btnAceptar.Name = "btnAceptar"
        Me.btnAceptar.TabIndex = 0
        Me.btnAceptar.Text = "&Aceptar"
        Me.btnAceptar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'btnDefault
        '
        Me.btnDefault.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnDefault.Image = CType(resources.GetObject("btnDefault.Image"), System.Drawing.Bitmap)
        Me.btnDefault.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnDefault.ImageIndex = 2
        Me.btnDefault.ImageList = Me.imgPerzonalizar
        Me.btnDefault.Location = New System.Drawing.Point(8, 36)
        Me.btnDefault.Name = "btnDefault"
        Me.btnDefault.TabIndex = 1
        Me.btnDefault.Text = "&Default"
        Me.btnDefault.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'dlgColor
        '
        Me.dlgColor.AnyColor = True
        Me.dlgColor.FullOpen = True
        Me.dlgColor.ShowHelp = True
        '
        'tpnlPrincipal
        '
        Me.tpnlPrincipal.BackColor = System.Drawing.Color.WhiteSmoke
        Me.tpnlPrincipal.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.tpnlPrincipal.Controls.AddRange(New System.Windows.Forms.Control() {Me.nudBloqueo, Me.lblBloquear, Me.btnBarraPrincipal, Me.lblBarraPrincipal})
        Me.tpnlPrincipal.Dock = System.Windows.Forms.DockStyle.Top
        Me.tpnlPrincipal.ExpandedHeight = 88
        Me.tpnlPrincipal.Name = "tpnlPrincipal"
        Me.tpnlPrincipal.PanelStateEffect = Logistica.ToolPanel.MovementEffect.MoveAlignedControls
        Me.tpnlPrincipal.PanelToolState = Logistica.ToolPanel.PanelState.Collapsed
        Me.tpnlPrincipal.Size = New System.Drawing.Size(198, 21)
        Me.tpnlPrincipal.Style = Logistica.ToolPanel.PanelStyle.Rectangle
        Me.tpnlPrincipal.TabIndex = 2
        Me.tpnlPrincipal.Title = "Pantalla principal"
        Me.tpnlPrincipal.TitleAlignment = System.Windows.Forms.HorizontalAlignment.Left
        Me.tpnlPrincipal.TitleBackColor = System.Drawing.Color.DarkBlue
        Me.tpnlPrincipal.TitleFont = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tpnlPrincipal.TitleForeColor = System.Drawing.Color.White
        Me.tpnlPrincipal.Visible = False
        '
        'nudBloqueo
        '
        Me.nudBloqueo.Location = New System.Drawing.Point(144, 57)
        Me.nudBloqueo.Name = "nudBloqueo"
        Me.nudBloqueo.Size = New System.Drawing.Size(40, 21)
        Me.nudBloqueo.TabIndex = 9
        '
        'lblBloquear
        '
        Me.lblBloquear.AutoSize = True
        Me.lblBloquear.Location = New System.Drawing.Point(8, 60)
        Me.lblBloquear.Name = "lblBloquear"
        Me.lblBloquear.Size = New System.Drawing.Size(118, 14)
        Me.lblBloquear.TabIndex = 8
        Me.lblBloquear.Text = "Tiempo de inactividad:"
        '
        'btnBarraPrincipal
        '
        Me.btnBarraPrincipal.Anchor = (System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right)
        Me.btnBarraPrincipal.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnBarraPrincipal.Location = New System.Drawing.Point(152, 28)
        Me.btnBarraPrincipal.Name = "btnBarraPrincipal"
        Me.btnBarraPrincipal.Size = New System.Drawing.Size(24, 23)
        Me.btnBarraPrincipal.TabIndex = 7
        '
        'lblBarraPrincipal
        '
        Me.lblBarraPrincipal.AutoSize = True
        Me.lblBarraPrincipal.Location = New System.Drawing.Point(8, 32)
        Me.lblBarraPrincipal.Name = "lblBarraPrincipal"
        Me.lblBarraPrincipal.Size = New System.Drawing.Size(120, 14)
        Me.lblBarraPrincipal.TabIndex = 5
        Me.lblBarraPrincipal.Text = "Barra de herramientas:"
        '
        'tpnlOperador
        '
        Me.tpnlOperador.BackColor = System.Drawing.Color.WhiteSmoke
        Me.tpnlOperador.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.tpnlOperador.Controls.AddRange(New System.Windows.Forms.Control() {Me.btnFInfoOperador, Me.btnATablaOperador, Me.lblATablaOperador, Me.lblBarraOperador, Me.btnBarraOperador, Me.lblFTablaOperador, Me.btnFTablaOperador, Me.btnTTablaOperador, Me.lblTTablaOperador, Me.btnTInfoOperador, Me.btnTBFOperador, Me.lblTBFOperador, Me.lblFInfoOperador, Me.lblTInfoOperador, Me.lblTBTOperador, Me.btnTBTOperador})
        Me.tpnlOperador.Dock = System.Windows.Forms.DockStyle.Top
        Me.tpnlOperador.ExpandedHeight = 272
        Me.tpnlOperador.Location = New System.Drawing.Point(0, 21)
        Me.tpnlOperador.Name = "tpnlOperador"
        Me.tpnlOperador.PanelStateEffect = Logistica.ToolPanel.MovementEffect.None
        Me.tpnlOperador.PanelToolState = Logistica.ToolPanel.PanelState.Collapsed
        Me.tpnlOperador.Size = New System.Drawing.Size(198, 21)
        Me.tpnlOperador.Style = Logistica.ToolPanel.PanelStyle.Rectangle
        Me.tpnlOperador.TabIndex = 3
        Me.tpnlOperador.Title = "Catálogo de operadores"
        Me.tpnlOperador.TitleAlignment = System.Windows.Forms.HorizontalAlignment.Left
        Me.tpnlOperador.TitleBackColor = System.Drawing.Color.DarkBlue
        Me.tpnlOperador.TitleFont = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tpnlOperador.TitleForeColor = System.Drawing.Color.White
        Me.tpnlOperador.Visible = False
        '
        'btnFInfoOperador
        '
        Me.btnFInfoOperador.Anchor = (System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right)
        Me.btnFInfoOperador.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnFInfoOperador.Location = New System.Drawing.Point(152, 148)
        Me.btnFInfoOperador.Name = "btnFInfoOperador"
        Me.btnFInfoOperador.Size = New System.Drawing.Size(24, 23)
        Me.btnFInfoOperador.TabIndex = 9
        '
        'btnATablaOperador
        '
        Me.btnATablaOperador.Anchor = (System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right)
        Me.btnATablaOperador.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnATablaOperador.Location = New System.Drawing.Point(152, 88)
        Me.btnATablaOperador.Name = "btnATablaOperador"
        Me.btnATablaOperador.Size = New System.Drawing.Size(24, 23)
        Me.btnATablaOperador.TabIndex = 9
        '
        'lblATablaOperador
        '
        Me.lblATablaOperador.AutoSize = True
        Me.lblATablaOperador.Location = New System.Drawing.Point(8, 92)
        Me.lblATablaOperador.Name = "lblATablaOperador"
        Me.lblATablaOperador.Size = New System.Drawing.Size(116, 14)
        Me.lblATablaOperador.TabIndex = 8
        Me.lblATablaOperador.Text = "Color alterno de tabla:"
        '
        'lblBarraOperador
        '
        Me.lblBarraOperador.AutoSize = True
        Me.lblBarraOperador.Location = New System.Drawing.Point(8, 32)
        Me.lblBarraOperador.Name = "lblBarraOperador"
        Me.lblBarraOperador.Size = New System.Drawing.Size(120, 14)
        Me.lblBarraOperador.TabIndex = 8
        Me.lblBarraOperador.Text = "Barra de herramientas:"
        '
        'btnBarraOperador
        '
        Me.btnBarraOperador.Anchor = (System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right)
        Me.btnBarraOperador.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnBarraOperador.Location = New System.Drawing.Point(152, 28)
        Me.btnBarraOperador.Name = "btnBarraOperador"
        Me.btnBarraOperador.Size = New System.Drawing.Size(24, 23)
        Me.btnBarraOperador.TabIndex = 9
        '
        'lblFTablaOperador
        '
        Me.lblFTablaOperador.AutoSize = True
        Me.lblFTablaOperador.Location = New System.Drawing.Point(8, 62)
        Me.lblFTablaOperador.Name = "lblFTablaOperador"
        Me.lblFTablaOperador.Size = New System.Drawing.Size(95, 14)
        Me.lblFTablaOperador.TabIndex = 8
        Me.lblFTablaOperador.Text = "Fondo de la tabla:"
        '
        'btnFTablaOperador
        '
        Me.btnFTablaOperador.Anchor = (System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right)
        Me.btnFTablaOperador.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnFTablaOperador.Location = New System.Drawing.Point(152, 58)
        Me.btnFTablaOperador.Name = "btnFTablaOperador"
        Me.btnFTablaOperador.Size = New System.Drawing.Size(24, 23)
        Me.btnFTablaOperador.TabIndex = 9
        '
        'btnTTablaOperador
        '
        Me.btnTTablaOperador.Anchor = (System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right)
        Me.btnTTablaOperador.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnTTablaOperador.Location = New System.Drawing.Point(152, 118)
        Me.btnTTablaOperador.Name = "btnTTablaOperador"
        Me.btnTTablaOperador.Size = New System.Drawing.Size(24, 23)
        Me.btnTTablaOperador.TabIndex = 9
        '
        'lblTTablaOperador
        '
        Me.lblTTablaOperador.AutoSize = True
        Me.lblTTablaOperador.Location = New System.Drawing.Point(8, 122)
        Me.lblTTablaOperador.Name = "lblTTablaOperador"
        Me.lblTTablaOperador.Size = New System.Drawing.Size(92, 14)
        Me.lblTTablaOperador.TabIndex = 8
        Me.lblTTablaOperador.Text = "Texto de la tabla:"
        '
        'btnTInfoOperador
        '
        Me.btnTInfoOperador.Anchor = (System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right)
        Me.btnTInfoOperador.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnTInfoOperador.Location = New System.Drawing.Point(152, 178)
        Me.btnTInfoOperador.Name = "btnTInfoOperador"
        Me.btnTInfoOperador.Size = New System.Drawing.Size(24, 23)
        Me.btnTInfoOperador.TabIndex = 9
        '
        'btnTBFOperador
        '
        Me.btnTBFOperador.Anchor = (System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right)
        Me.btnTBFOperador.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnTBFOperador.Location = New System.Drawing.Point(152, 208)
        Me.btnTBFOperador.Name = "btnTBFOperador"
        Me.btnTBFOperador.Size = New System.Drawing.Size(24, 23)
        Me.btnTBFOperador.TabIndex = 9
        '
        'lblTBFOperador
        '
        Me.lblTBFOperador.AutoSize = True
        Me.lblTBFOperador.Location = New System.Drawing.Point(8, 212)
        Me.lblTBFOperador.Name = "lblTBFOperador"
        Me.lblTBFOperador.Size = New System.Drawing.Size(112, 14)
        Me.lblTBFOperador.TabIndex = 8
        Me.lblTBFOperador.Text = "Fondo cajas de texto:"
        '
        'lblFInfoOperador
        '
        Me.lblFInfoOperador.AutoSize = True
        Me.lblFInfoOperador.Location = New System.Drawing.Point(8, 152)
        Me.lblFInfoOperador.Name = "lblFInfoOperador"
        Me.lblFInfoOperador.Size = New System.Drawing.Size(129, 14)
        Me.lblFInfoOperador.TabIndex = 8
        Me.lblFInfoOperador.Text = "Fondo de la información:"
        '
        'lblTInfoOperador
        '
        Me.lblTInfoOperador.AutoSize = True
        Me.lblTInfoOperador.Location = New System.Drawing.Point(8, 182)
        Me.lblTInfoOperador.Name = "lblTInfoOperador"
        Me.lblTInfoOperador.Size = New System.Drawing.Size(126, 14)
        Me.lblTInfoOperador.TabIndex = 8
        Me.lblTInfoOperador.Text = "Texto de la información:"
        '
        'lblTBTOperador
        '
        Me.lblTBTOperador.AutoSize = True
        Me.lblTBTOperador.Location = New System.Drawing.Point(8, 242)
        Me.lblTBTOperador.Name = "lblTBTOperador"
        Me.lblTBTOperador.Size = New System.Drawing.Size(110, 14)
        Me.lblTBTOperador.TabIndex = 8
        Me.lblTBTOperador.Text = "Texto cajas de texto:"
        '
        'btnTBTOperador
        '
        Me.btnTBTOperador.Anchor = (System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right)
        Me.btnTBTOperador.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnTBTOperador.Location = New System.Drawing.Point(152, 238)
        Me.btnTBTOperador.Name = "btnTBTOperador"
        Me.btnTBTOperador.Size = New System.Drawing.Size(24, 23)
        Me.btnTBTOperador.TabIndex = 9
        '
        'tpnlAutotanque
        '
        Me.tpnlAutotanque.BackColor = System.Drawing.Color.WhiteSmoke
        Me.tpnlAutotanque.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.tpnlAutotanque.Controls.AddRange(New System.Windows.Forms.Control() {Me.btnFInfoAutotanque, Me.btnATablaAutotanque, Me.lblATablaAutotanque, Me.lblBarraAutotanque, Me.btnBarraAutotanque, Me.lblFTablaAutotanque, Me.btnFTablaAutotanque, Me.btnTTablaAutotanque, Me.lblTTablaAutotanque, Me.btnTInfoAutotanque, Me.btnTBFAutotanque, Me.lblTBFAutotanque, Me.lblFInfoAutotanque, Me.lblTInfoAutotanque, Me.lblTBTAutotanque, Me.btnTBTAutotanque})
        Me.tpnlAutotanque.Dock = System.Windows.Forms.DockStyle.Top
        Me.tpnlAutotanque.ExpandedHeight = 272
        Me.tpnlAutotanque.Location = New System.Drawing.Point(0, 42)
        Me.tpnlAutotanque.Name = "tpnlAutotanque"
        Me.tpnlAutotanque.PanelStateEffect = Logistica.ToolPanel.MovementEffect.None
        Me.tpnlAutotanque.PanelToolState = Logistica.ToolPanel.PanelState.Collapsed
        Me.tpnlAutotanque.Size = New System.Drawing.Size(198, 21)
        Me.tpnlAutotanque.Style = Logistica.ToolPanel.PanelStyle.Rectangle
        Me.tpnlAutotanque.TabIndex = 4
        Me.tpnlAutotanque.Title = "Catálogo de autotanques"
        Me.tpnlAutotanque.TitleAlignment = System.Windows.Forms.HorizontalAlignment.Left
        Me.tpnlAutotanque.TitleBackColor = System.Drawing.Color.DarkBlue
        Me.tpnlAutotanque.TitleFont = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tpnlAutotanque.TitleForeColor = System.Drawing.Color.White
        Me.tpnlAutotanque.Visible = False
        '
        'btnFInfoAutotanque
        '
        Me.btnFInfoAutotanque.Anchor = (System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right)
        Me.btnFInfoAutotanque.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnFInfoAutotanque.Location = New System.Drawing.Point(152, 148)
        Me.btnFInfoAutotanque.Name = "btnFInfoAutotanque"
        Me.btnFInfoAutotanque.Size = New System.Drawing.Size(24, 23)
        Me.btnFInfoAutotanque.TabIndex = 9
        '
        'btnATablaAutotanque
        '
        Me.btnATablaAutotanque.Anchor = (System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right)
        Me.btnATablaAutotanque.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnATablaAutotanque.Location = New System.Drawing.Point(152, 88)
        Me.btnATablaAutotanque.Name = "btnATablaAutotanque"
        Me.btnATablaAutotanque.Size = New System.Drawing.Size(24, 23)
        Me.btnATablaAutotanque.TabIndex = 9
        '
        'lblATablaAutotanque
        '
        Me.lblATablaAutotanque.AutoSize = True
        Me.lblATablaAutotanque.Location = New System.Drawing.Point(8, 92)
        Me.lblATablaAutotanque.Name = "lblATablaAutotanque"
        Me.lblATablaAutotanque.Size = New System.Drawing.Size(116, 14)
        Me.lblATablaAutotanque.TabIndex = 8
        Me.lblATablaAutotanque.Text = "Color alterno de tabla:"
        '
        'lblBarraAutotanque
        '
        Me.lblBarraAutotanque.AutoSize = True
        Me.lblBarraAutotanque.Location = New System.Drawing.Point(8, 32)
        Me.lblBarraAutotanque.Name = "lblBarraAutotanque"
        Me.lblBarraAutotanque.Size = New System.Drawing.Size(120, 14)
        Me.lblBarraAutotanque.TabIndex = 8
        Me.lblBarraAutotanque.Text = "Barra de herramientas:"
        '
        'btnBarraAutotanque
        '
        Me.btnBarraAutotanque.Anchor = (System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right)
        Me.btnBarraAutotanque.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnBarraAutotanque.Location = New System.Drawing.Point(152, 28)
        Me.btnBarraAutotanque.Name = "btnBarraAutotanque"
        Me.btnBarraAutotanque.Size = New System.Drawing.Size(24, 23)
        Me.btnBarraAutotanque.TabIndex = 9
        '
        'lblFTablaAutotanque
        '
        Me.lblFTablaAutotanque.AutoSize = True
        Me.lblFTablaAutotanque.Location = New System.Drawing.Point(8, 62)
        Me.lblFTablaAutotanque.Name = "lblFTablaAutotanque"
        Me.lblFTablaAutotanque.Size = New System.Drawing.Size(95, 14)
        Me.lblFTablaAutotanque.TabIndex = 8
        Me.lblFTablaAutotanque.Text = "Fondo de la tabla:"
        '
        'btnFTablaAutotanque
        '
        Me.btnFTablaAutotanque.Anchor = (System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right)
        Me.btnFTablaAutotanque.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnFTablaAutotanque.Location = New System.Drawing.Point(152, 58)
        Me.btnFTablaAutotanque.Name = "btnFTablaAutotanque"
        Me.btnFTablaAutotanque.Size = New System.Drawing.Size(24, 23)
        Me.btnFTablaAutotanque.TabIndex = 9
        '
        'btnTTablaAutotanque
        '
        Me.btnTTablaAutotanque.Anchor = (System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right)
        Me.btnTTablaAutotanque.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnTTablaAutotanque.Location = New System.Drawing.Point(152, 118)
        Me.btnTTablaAutotanque.Name = "btnTTablaAutotanque"
        Me.btnTTablaAutotanque.Size = New System.Drawing.Size(24, 23)
        Me.btnTTablaAutotanque.TabIndex = 9
        '
        'lblTTablaAutotanque
        '
        Me.lblTTablaAutotanque.AutoSize = True
        Me.lblTTablaAutotanque.Location = New System.Drawing.Point(8, 122)
        Me.lblTTablaAutotanque.Name = "lblTTablaAutotanque"
        Me.lblTTablaAutotanque.Size = New System.Drawing.Size(92, 14)
        Me.lblTTablaAutotanque.TabIndex = 8
        Me.lblTTablaAutotanque.Text = "Texto de la tabla:"
        '
        'btnTInfoAutotanque
        '
        Me.btnTInfoAutotanque.Anchor = (System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right)
        Me.btnTInfoAutotanque.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnTInfoAutotanque.Location = New System.Drawing.Point(152, 178)
        Me.btnTInfoAutotanque.Name = "btnTInfoAutotanque"
        Me.btnTInfoAutotanque.Size = New System.Drawing.Size(24, 23)
        Me.btnTInfoAutotanque.TabIndex = 9
        '
        'btnTBFAutotanque
        '
        Me.btnTBFAutotanque.Anchor = (System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right)
        Me.btnTBFAutotanque.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnTBFAutotanque.Location = New System.Drawing.Point(152, 208)
        Me.btnTBFAutotanque.Name = "btnTBFAutotanque"
        Me.btnTBFAutotanque.Size = New System.Drawing.Size(24, 23)
        Me.btnTBFAutotanque.TabIndex = 9
        '
        'lblTBFAutotanque
        '
        Me.lblTBFAutotanque.AutoSize = True
        Me.lblTBFAutotanque.Location = New System.Drawing.Point(8, 212)
        Me.lblTBFAutotanque.Name = "lblTBFAutotanque"
        Me.lblTBFAutotanque.Size = New System.Drawing.Size(112, 14)
        Me.lblTBFAutotanque.TabIndex = 8
        Me.lblTBFAutotanque.Text = "Fondo cajas de texto:"
        '
        'lblFInfoAutotanque
        '
        Me.lblFInfoAutotanque.AutoSize = True
        Me.lblFInfoAutotanque.Location = New System.Drawing.Point(8, 152)
        Me.lblFInfoAutotanque.Name = "lblFInfoAutotanque"
        Me.lblFInfoAutotanque.Size = New System.Drawing.Size(129, 14)
        Me.lblFInfoAutotanque.TabIndex = 8
        Me.lblFInfoAutotanque.Text = "Fondo de la información:"
        '
        'lblTInfoAutotanque
        '
        Me.lblTInfoAutotanque.AutoSize = True
        Me.lblTInfoAutotanque.Location = New System.Drawing.Point(8, 182)
        Me.lblTInfoAutotanque.Name = "lblTInfoAutotanque"
        Me.lblTInfoAutotanque.Size = New System.Drawing.Size(126, 14)
        Me.lblTInfoAutotanque.TabIndex = 8
        Me.lblTInfoAutotanque.Text = "Texto de la información:"
        '
        'lblTBTAutotanque
        '
        Me.lblTBTAutotanque.AutoSize = True
        Me.lblTBTAutotanque.Location = New System.Drawing.Point(8, 242)
        Me.lblTBTAutotanque.Name = "lblTBTAutotanque"
        Me.lblTBTAutotanque.Size = New System.Drawing.Size(110, 14)
        Me.lblTBTAutotanque.TabIndex = 8
        Me.lblTBTAutotanque.Text = "Texto cajas de texto:"
        '
        'btnTBTAutotanque
        '
        Me.btnTBTAutotanque.Anchor = (System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right)
        Me.btnTBTAutotanque.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnTBTAutotanque.Location = New System.Drawing.Point(152, 238)
        Me.btnTBTAutotanque.Name = "btnTBTAutotanque"
        Me.btnTBTAutotanque.Size = New System.Drawing.Size(24, 23)
        Me.btnTBTAutotanque.TabIndex = 9
        '
        'tpnlAsignacion
        '
        Me.tpnlAsignacion.BackColor = System.Drawing.Color.WhiteSmoke
        Me.tpnlAsignacion.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.tpnlAsignacion.Controls.AddRange(New System.Windows.Forms.Control() {Me.pnlGrupos, Me.Panel1})
        Me.tpnlAsignacion.Dock = System.Windows.Forms.DockStyle.Top
        Me.tpnlAsignacion.DockPadding.Top = 20
        Me.tpnlAsignacion.ExpandedHeight = 193
        Me.tpnlAsignacion.Location = New System.Drawing.Point(0, 63)
        Me.tpnlAsignacion.Name = "tpnlAsignacion"
        Me.tpnlAsignacion.PanelStateEffect = Logistica.ToolPanel.MovementEffect.None
        Me.tpnlAsignacion.PanelToolState = Logistica.ToolPanel.PanelState.Collapsed
        Me.tpnlAsignacion.Size = New System.Drawing.Size(198, 21)
        Me.tpnlAsignacion.Style = Logistica.ToolPanel.PanelStyle.Rectangle
        Me.tpnlAsignacion.TabIndex = 5
        Me.tpnlAsignacion.Title = "Asignaciones"
        Me.tpnlAsignacion.TitleAlignment = System.Windows.Forms.HorizontalAlignment.Left
        Me.tpnlAsignacion.TitleBackColor = System.Drawing.Color.DarkBlue
        Me.tpnlAsignacion.TitleFont = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tpnlAsignacion.TitleForeColor = System.Drawing.Color.White
        Me.tpnlAsignacion.Visible = False
        '
        'pnlGrupos
        '
        Me.pnlGrupos.Controls.AddRange(New System.Windows.Forms.Control() {Me.gpnlAutotanquesPrestados, Me.gpnlEmpleadosPrestados, Me.gpnlAutotanquesPrestamo, Me.gpnlEmpleadosPrestamo, Me.gpnlAutotanquesSA, Me.gpnlEmpleadosSA, Me.gpnlOperadores, Me.gpnlFolios})
        Me.pnlGrupos.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pnlGrupos.Location = New System.Drawing.Point(0, 56)
        Me.pnlGrupos.Name = "pnlGrupos"
        Me.pnlGrupos.Size = New System.Drawing.Size(196, 0)
        Me.pnlGrupos.TabIndex = 10
        '
        'gpnlAutotanquesPrestados
        '
        Me.gpnlAutotanquesPrestados.Controls.AddRange(New System.Windows.Forms.Control() {Me.lblTextoAutotanquesPrestados, Me.btnTextoAutotanquesPrestados, Me.lblAlternoAutotanquesPrestados, Me.btnAlternoAutotanquesPrestados, Me.lblFondoAutotanquesPrestados, Me.btnFondoAutotanquesPrestados})
        Me.gpnlAutotanquesPrestados.DividerColor = System.Drawing.Color.Gainsboro
        Me.gpnlAutotanquesPrestados.Dock = System.Windows.Forms.DockStyle.Top
        Me.gpnlAutotanquesPrestados.GroupPanelState = Logistica.GroupPanel.PanelState.Collapsed
        Me.gpnlAutotanquesPrestados.Location = New System.Drawing.Point(0, 112)
        Me.gpnlAutotanquesPrestados.Name = "gpnlAutotanquesPrestados"
        Me.gpnlAutotanquesPrestados.PanelStateEffect = Logistica.GroupPanel.MovementEffect.MoveAlignedControls
        Me.gpnlAutotanquesPrestados.Size = New System.Drawing.Size(196, 16)
        Me.gpnlAutotanquesPrestados.TabIndex = 22
        Me.gpnlAutotanquesPrestados.Title = "Autotanques prestados"
        Me.gpnlAutotanquesPrestados.TitleBackColor = System.Drawing.Color.Gainsboro
        Me.gpnlAutotanquesPrestados.TitleFont = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gpnlAutotanquesPrestados.TitleForeColor = System.Drawing.SystemColors.ControlText
        '
        'lblTextoAutotanquesPrestados
        '
        Me.lblTextoAutotanquesPrestados.AutoSize = True
        Me.lblTextoAutotanquesPrestados.Location = New System.Drawing.Point(24, 83)
        Me.lblTextoAutotanquesPrestados.Name = "lblTextoAutotanquesPrestados"
        Me.lblTextoAutotanquesPrestados.Size = New System.Drawing.Size(36, 14)
        Me.lblTextoAutotanquesPrestados.TabIndex = 16
        Me.lblTextoAutotanquesPrestados.Text = "Texto:"
        '
        'btnTextoAutotanquesPrestados
        '
        Me.btnTextoAutotanquesPrestados.Anchor = (System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right)
        Me.btnTextoAutotanquesPrestados.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnTextoAutotanquesPrestados.Location = New System.Drawing.Point(162, 79)
        Me.btnTextoAutotanquesPrestados.Name = "btnTextoAutotanquesPrestados"
        Me.btnTextoAutotanquesPrestados.Size = New System.Drawing.Size(24, 23)
        Me.btnTextoAutotanquesPrestados.TabIndex = 17
        '
        'lblAlternoAutotanquesPrestados
        '
        Me.lblAlternoAutotanquesPrestados.AutoSize = True
        Me.lblAlternoAutotanquesPrestados.Location = New System.Drawing.Point(24, 54)
        Me.lblAlternoAutotanquesPrestados.Name = "lblAlternoAutotanquesPrestados"
        Me.lblAlternoAutotanquesPrestados.Size = New System.Drawing.Size(72, 14)
        Me.lblAlternoAutotanquesPrestados.TabIndex = 14
        Me.lblAlternoAutotanquesPrestados.Text = "Color alterno:"
        '
        'btnAlternoAutotanquesPrestados
        '
        Me.btnAlternoAutotanquesPrestados.Anchor = (System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right)
        Me.btnAlternoAutotanquesPrestados.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnAlternoAutotanquesPrestados.Location = New System.Drawing.Point(162, 50)
        Me.btnAlternoAutotanquesPrestados.Name = "btnAlternoAutotanquesPrestados"
        Me.btnAlternoAutotanquesPrestados.Size = New System.Drawing.Size(24, 23)
        Me.btnAlternoAutotanquesPrestados.TabIndex = 15
        '
        'lblFondoAutotanquesPrestados
        '
        Me.lblFondoAutotanquesPrestados.AutoSize = True
        Me.lblFondoAutotanquesPrestados.Location = New System.Drawing.Point(24, 25)
        Me.lblFondoAutotanquesPrestados.Name = "lblFondoAutotanquesPrestados"
        Me.lblFondoAutotanquesPrestados.Size = New System.Drawing.Size(39, 14)
        Me.lblFondoAutotanquesPrestados.TabIndex = 12
        Me.lblFondoAutotanquesPrestados.Text = "Fondo:"
        '
        'btnFondoAutotanquesPrestados
        '
        Me.btnFondoAutotanquesPrestados.Anchor = (System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right)
        Me.btnFondoAutotanquesPrestados.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnFondoAutotanquesPrestados.Location = New System.Drawing.Point(162, 21)
        Me.btnFondoAutotanquesPrestados.Name = "btnFondoAutotanquesPrestados"
        Me.btnFondoAutotanquesPrestados.Size = New System.Drawing.Size(24, 23)
        Me.btnFondoAutotanquesPrestados.TabIndex = 13
        '
        'gpnlEmpleadosPrestados
        '
        Me.gpnlEmpleadosPrestados.Controls.AddRange(New System.Windows.Forms.Control() {Me.lblTextoEmpleadosPrestados, Me.btnTextoEmpleadosPrestados, Me.lblAlternoEmpleadosPrestados, Me.btnAlternoEmpleadosPrestados, Me.lblFondoEmpleadosPrestados, Me.btnFondoEmpleadosPrestados})
        Me.gpnlEmpleadosPrestados.DividerColor = System.Drawing.Color.Gainsboro
        Me.gpnlEmpleadosPrestados.Dock = System.Windows.Forms.DockStyle.Top
        Me.gpnlEmpleadosPrestados.GroupPanelState = Logistica.GroupPanel.PanelState.Collapsed
        Me.gpnlEmpleadosPrestados.Location = New System.Drawing.Point(0, 96)
        Me.gpnlEmpleadosPrestados.Name = "gpnlEmpleadosPrestados"
        Me.gpnlEmpleadosPrestados.PanelStateEffect = Logistica.GroupPanel.MovementEffect.MoveAlignedControls
        Me.gpnlEmpleadosPrestados.Size = New System.Drawing.Size(196, 16)
        Me.gpnlEmpleadosPrestados.TabIndex = 21
        Me.gpnlEmpleadosPrestados.Title = "Empleados prestados"
        Me.gpnlEmpleadosPrestados.TitleBackColor = System.Drawing.Color.Gainsboro
        Me.gpnlEmpleadosPrestados.TitleFont = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gpnlEmpleadosPrestados.TitleForeColor = System.Drawing.SystemColors.ControlText
        '
        'lblTextoEmpleadosPrestados
        '
        Me.lblTextoEmpleadosPrestados.AutoSize = True
        Me.lblTextoEmpleadosPrestados.Location = New System.Drawing.Point(24, 83)
        Me.lblTextoEmpleadosPrestados.Name = "lblTextoEmpleadosPrestados"
        Me.lblTextoEmpleadosPrestados.Size = New System.Drawing.Size(36, 14)
        Me.lblTextoEmpleadosPrestados.TabIndex = 16
        Me.lblTextoEmpleadosPrestados.Text = "Texto:"
        '
        'btnTextoEmpleadosPrestados
        '
        Me.btnTextoEmpleadosPrestados.Anchor = (System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right)
        Me.btnTextoEmpleadosPrestados.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnTextoEmpleadosPrestados.Location = New System.Drawing.Point(162, 79)
        Me.btnTextoEmpleadosPrestados.Name = "btnTextoEmpleadosPrestados"
        Me.btnTextoEmpleadosPrestados.Size = New System.Drawing.Size(24, 23)
        Me.btnTextoEmpleadosPrestados.TabIndex = 17
        '
        'lblAlternoEmpleadosPrestados
        '
        Me.lblAlternoEmpleadosPrestados.AutoSize = True
        Me.lblAlternoEmpleadosPrestados.Location = New System.Drawing.Point(24, 54)
        Me.lblAlternoEmpleadosPrestados.Name = "lblAlternoEmpleadosPrestados"
        Me.lblAlternoEmpleadosPrestados.Size = New System.Drawing.Size(72, 14)
        Me.lblAlternoEmpleadosPrestados.TabIndex = 14
        Me.lblAlternoEmpleadosPrestados.Text = "Color alterno:"
        '
        'btnAlternoEmpleadosPrestados
        '
        Me.btnAlternoEmpleadosPrestados.Anchor = (System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right)
        Me.btnAlternoEmpleadosPrestados.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnAlternoEmpleadosPrestados.Location = New System.Drawing.Point(162, 50)
        Me.btnAlternoEmpleadosPrestados.Name = "btnAlternoEmpleadosPrestados"
        Me.btnAlternoEmpleadosPrestados.Size = New System.Drawing.Size(24, 23)
        Me.btnAlternoEmpleadosPrestados.TabIndex = 15
        '
        'lblFondoEmpleadosPrestados
        '
        Me.lblFondoEmpleadosPrestados.AutoSize = True
        Me.lblFondoEmpleadosPrestados.Location = New System.Drawing.Point(24, 25)
        Me.lblFondoEmpleadosPrestados.Name = "lblFondoEmpleadosPrestados"
        Me.lblFondoEmpleadosPrestados.Size = New System.Drawing.Size(39, 14)
        Me.lblFondoEmpleadosPrestados.TabIndex = 12
        Me.lblFondoEmpleadosPrestados.Text = "Fondo:"
        '
        'btnFondoEmpleadosPrestados
        '
        Me.btnFondoEmpleadosPrestados.Anchor = (System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right)
        Me.btnFondoEmpleadosPrestados.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnFondoEmpleadosPrestados.Location = New System.Drawing.Point(162, 21)
        Me.btnFondoEmpleadosPrestados.Name = "btnFondoEmpleadosPrestados"
        Me.btnFondoEmpleadosPrestados.Size = New System.Drawing.Size(24, 23)
        Me.btnFondoEmpleadosPrestados.TabIndex = 13
        '
        'gpnlAutotanquesPrestamo
        '
        Me.gpnlAutotanquesPrestamo.Controls.AddRange(New System.Windows.Forms.Control() {Me.lblTextoAutotanquesPrestamo, Me.btnTextoAutotanquesPrestamo, Me.lblAlternoAutotanquesPrestamo, Me.btnAlternoAutotanquesPrestamo, Me.lblFondoAutotanquesPrestamo, Me.btnFondoAutotanquesPrestamo})
        Me.gpnlAutotanquesPrestamo.DividerColor = System.Drawing.Color.Gainsboro
        Me.gpnlAutotanquesPrestamo.Dock = System.Windows.Forms.DockStyle.Top
        Me.gpnlAutotanquesPrestamo.GroupPanelState = Logistica.GroupPanel.PanelState.Collapsed
        Me.gpnlAutotanquesPrestamo.Location = New System.Drawing.Point(0, 80)
        Me.gpnlAutotanquesPrestamo.Name = "gpnlAutotanquesPrestamo"
        Me.gpnlAutotanquesPrestamo.PanelStateEffect = Logistica.GroupPanel.MovementEffect.MoveAlignedControls
        Me.gpnlAutotanquesPrestamo.Size = New System.Drawing.Size(196, 16)
        Me.gpnlAutotanquesPrestamo.TabIndex = 20
        Me.gpnlAutotanquesPrestamo.Title = "Autotanques en prestamo"
        Me.gpnlAutotanquesPrestamo.TitleBackColor = System.Drawing.Color.Gainsboro
        Me.gpnlAutotanquesPrestamo.TitleFont = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gpnlAutotanquesPrestamo.TitleForeColor = System.Drawing.SystemColors.ControlText
        '
        'lblTextoAutotanquesPrestamo
        '
        Me.lblTextoAutotanquesPrestamo.AutoSize = True
        Me.lblTextoAutotanquesPrestamo.Location = New System.Drawing.Point(24, 83)
        Me.lblTextoAutotanquesPrestamo.Name = "lblTextoAutotanquesPrestamo"
        Me.lblTextoAutotanquesPrestamo.Size = New System.Drawing.Size(36, 14)
        Me.lblTextoAutotanquesPrestamo.TabIndex = 16
        Me.lblTextoAutotanquesPrestamo.Text = "Texto:"
        '
        'btnTextoAutotanquesPrestamo
        '
        Me.btnTextoAutotanquesPrestamo.Anchor = (System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right)
        Me.btnTextoAutotanquesPrestamo.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnTextoAutotanquesPrestamo.Location = New System.Drawing.Point(162, 79)
        Me.btnTextoAutotanquesPrestamo.Name = "btnTextoAutotanquesPrestamo"
        Me.btnTextoAutotanquesPrestamo.Size = New System.Drawing.Size(24, 23)
        Me.btnTextoAutotanquesPrestamo.TabIndex = 17
        '
        'lblAlternoAutotanquesPrestamo
        '
        Me.lblAlternoAutotanquesPrestamo.AutoSize = True
        Me.lblAlternoAutotanquesPrestamo.Location = New System.Drawing.Point(24, 54)
        Me.lblAlternoAutotanquesPrestamo.Name = "lblAlternoAutotanquesPrestamo"
        Me.lblAlternoAutotanquesPrestamo.Size = New System.Drawing.Size(72, 14)
        Me.lblAlternoAutotanquesPrestamo.TabIndex = 14
        Me.lblAlternoAutotanquesPrestamo.Text = "Color alterno:"
        '
        'btnAlternoAutotanquesPrestamo
        '
        Me.btnAlternoAutotanquesPrestamo.Anchor = (System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right)
        Me.btnAlternoAutotanquesPrestamo.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnAlternoAutotanquesPrestamo.Location = New System.Drawing.Point(162, 50)
        Me.btnAlternoAutotanquesPrestamo.Name = "btnAlternoAutotanquesPrestamo"
        Me.btnAlternoAutotanquesPrestamo.Size = New System.Drawing.Size(24, 23)
        Me.btnAlternoAutotanquesPrestamo.TabIndex = 15
        '
        'lblFondoAutotanquesPrestamo
        '
        Me.lblFondoAutotanquesPrestamo.AutoSize = True
        Me.lblFondoAutotanquesPrestamo.Location = New System.Drawing.Point(24, 25)
        Me.lblFondoAutotanquesPrestamo.Name = "lblFondoAutotanquesPrestamo"
        Me.lblFondoAutotanquesPrestamo.Size = New System.Drawing.Size(39, 14)
        Me.lblFondoAutotanquesPrestamo.TabIndex = 12
        Me.lblFondoAutotanquesPrestamo.Text = "Fondo:"
        '
        'btnFondoAutotanquesPrestamo
        '
        Me.btnFondoAutotanquesPrestamo.Anchor = (System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right)
        Me.btnFondoAutotanquesPrestamo.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnFondoAutotanquesPrestamo.Location = New System.Drawing.Point(162, 21)
        Me.btnFondoAutotanquesPrestamo.Name = "btnFondoAutotanquesPrestamo"
        Me.btnFondoAutotanquesPrestamo.Size = New System.Drawing.Size(24, 23)
        Me.btnFondoAutotanquesPrestamo.TabIndex = 13
        '
        'gpnlEmpleadosPrestamo
        '
        Me.gpnlEmpleadosPrestamo.Controls.AddRange(New System.Windows.Forms.Control() {Me.lblTextoEmpleadosPrestamo, Me.btnTextoEmpleadosPrestamo, Me.lblAlternoEmpleadosPrestamo, Me.btnAlternoEmpleadosPrestamo, Me.lblFondoEmpleadosPrestamo, Me.btnFondoEmpleadosPrestamo})
        Me.gpnlEmpleadosPrestamo.DividerColor = System.Drawing.Color.Gainsboro
        Me.gpnlEmpleadosPrestamo.Dock = System.Windows.Forms.DockStyle.Top
        Me.gpnlEmpleadosPrestamo.GroupPanelState = Logistica.GroupPanel.PanelState.Collapsed
        Me.gpnlEmpleadosPrestamo.Location = New System.Drawing.Point(0, 64)
        Me.gpnlEmpleadosPrestamo.Name = "gpnlEmpleadosPrestamo"
        Me.gpnlEmpleadosPrestamo.PanelStateEffect = Logistica.GroupPanel.MovementEffect.MoveAlignedControls
        Me.gpnlEmpleadosPrestamo.Size = New System.Drawing.Size(196, 16)
        Me.gpnlEmpleadosPrestamo.TabIndex = 19
        Me.gpnlEmpleadosPrestamo.Title = "Empleados en prestamo"
        Me.gpnlEmpleadosPrestamo.TitleBackColor = System.Drawing.Color.Gainsboro
        Me.gpnlEmpleadosPrestamo.TitleFont = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gpnlEmpleadosPrestamo.TitleForeColor = System.Drawing.SystemColors.ControlText
        '
        'lblTextoEmpleadosPrestamo
        '
        Me.lblTextoEmpleadosPrestamo.AutoSize = True
        Me.lblTextoEmpleadosPrestamo.Location = New System.Drawing.Point(24, 83)
        Me.lblTextoEmpleadosPrestamo.Name = "lblTextoEmpleadosPrestamo"
        Me.lblTextoEmpleadosPrestamo.Size = New System.Drawing.Size(36, 14)
        Me.lblTextoEmpleadosPrestamo.TabIndex = 16
        Me.lblTextoEmpleadosPrestamo.Text = "Texto:"
        '
        'btnTextoEmpleadosPrestamo
        '
        Me.btnTextoEmpleadosPrestamo.Anchor = (System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right)
        Me.btnTextoEmpleadosPrestamo.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnTextoEmpleadosPrestamo.Location = New System.Drawing.Point(162, 79)
        Me.btnTextoEmpleadosPrestamo.Name = "btnTextoEmpleadosPrestamo"
        Me.btnTextoEmpleadosPrestamo.Size = New System.Drawing.Size(24, 23)
        Me.btnTextoEmpleadosPrestamo.TabIndex = 17
        '
        'lblAlternoEmpleadosPrestamo
        '
        Me.lblAlternoEmpleadosPrestamo.AutoSize = True
        Me.lblAlternoEmpleadosPrestamo.Location = New System.Drawing.Point(24, 54)
        Me.lblAlternoEmpleadosPrestamo.Name = "lblAlternoEmpleadosPrestamo"
        Me.lblAlternoEmpleadosPrestamo.Size = New System.Drawing.Size(72, 14)
        Me.lblAlternoEmpleadosPrestamo.TabIndex = 14
        Me.lblAlternoEmpleadosPrestamo.Text = "Color alterno:"
        '
        'btnAlternoEmpleadosPrestamo
        '
        Me.btnAlternoEmpleadosPrestamo.Anchor = (System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right)
        Me.btnAlternoEmpleadosPrestamo.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnAlternoEmpleadosPrestamo.Location = New System.Drawing.Point(162, 50)
        Me.btnAlternoEmpleadosPrestamo.Name = "btnAlternoEmpleadosPrestamo"
        Me.btnAlternoEmpleadosPrestamo.Size = New System.Drawing.Size(24, 23)
        Me.btnAlternoEmpleadosPrestamo.TabIndex = 15
        '
        'lblFondoEmpleadosPrestamo
        '
        Me.lblFondoEmpleadosPrestamo.AutoSize = True
        Me.lblFondoEmpleadosPrestamo.Location = New System.Drawing.Point(24, 25)
        Me.lblFondoEmpleadosPrestamo.Name = "lblFondoEmpleadosPrestamo"
        Me.lblFondoEmpleadosPrestamo.Size = New System.Drawing.Size(39, 14)
        Me.lblFondoEmpleadosPrestamo.TabIndex = 12
        Me.lblFondoEmpleadosPrestamo.Text = "Fondo:"
        '
        'btnFondoEmpleadosPrestamo
        '
        Me.btnFondoEmpleadosPrestamo.Anchor = (System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right)
        Me.btnFondoEmpleadosPrestamo.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnFondoEmpleadosPrestamo.Location = New System.Drawing.Point(162, 21)
        Me.btnFondoEmpleadosPrestamo.Name = "btnFondoEmpleadosPrestamo"
        Me.btnFondoEmpleadosPrestamo.Size = New System.Drawing.Size(24, 23)
        Me.btnFondoEmpleadosPrestamo.TabIndex = 13
        '
        'gpnlAutotanquesSA
        '
        Me.gpnlAutotanquesSA.Controls.AddRange(New System.Windows.Forms.Control() {Me.lblTextAutotanquesSA, Me.btnTextoAutotanquesSA, Me.lblAlternoAutotanquesSA, Me.btnAlternoAutotanquesSA, Me.lblFondoAutotanquesSA, Me.btnFondoAutotanquesSA})
        Me.gpnlAutotanquesSA.DividerColor = System.Drawing.Color.Gainsboro
        Me.gpnlAutotanquesSA.Dock = System.Windows.Forms.DockStyle.Top
        Me.gpnlAutotanquesSA.GroupPanelState = Logistica.GroupPanel.PanelState.Collapsed
        Me.gpnlAutotanquesSA.Location = New System.Drawing.Point(0, 48)
        Me.gpnlAutotanquesSA.Name = "gpnlAutotanquesSA"
        Me.gpnlAutotanquesSA.PanelStateEffect = Logistica.GroupPanel.MovementEffect.MoveAlignedControls
        Me.gpnlAutotanquesSA.Size = New System.Drawing.Size(196, 16)
        Me.gpnlAutotanquesSA.TabIndex = 18
        Me.gpnlAutotanquesSA.Title = "Autotanques sin asignar"
        Me.gpnlAutotanquesSA.TitleBackColor = System.Drawing.Color.Gainsboro
        Me.gpnlAutotanquesSA.TitleFont = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gpnlAutotanquesSA.TitleForeColor = System.Drawing.SystemColors.ControlText
        '
        'lblTextAutotanquesSA
        '
        Me.lblTextAutotanquesSA.AutoSize = True
        Me.lblTextAutotanquesSA.Location = New System.Drawing.Point(24, 83)
        Me.lblTextAutotanquesSA.Name = "lblTextAutotanquesSA"
        Me.lblTextAutotanquesSA.Size = New System.Drawing.Size(36, 14)
        Me.lblTextAutotanquesSA.TabIndex = 16
        Me.lblTextAutotanquesSA.Text = "Texto:"
        '
        'btnTextoAutotanquesSA
        '
        Me.btnTextoAutotanquesSA.Anchor = (System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right)
        Me.btnTextoAutotanquesSA.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnTextoAutotanquesSA.Location = New System.Drawing.Point(162, 79)
        Me.btnTextoAutotanquesSA.Name = "btnTextoAutotanquesSA"
        Me.btnTextoAutotanquesSA.Size = New System.Drawing.Size(24, 23)
        Me.btnTextoAutotanquesSA.TabIndex = 17
        '
        'lblAlternoAutotanquesSA
        '
        Me.lblAlternoAutotanquesSA.AutoSize = True
        Me.lblAlternoAutotanquesSA.Location = New System.Drawing.Point(24, 54)
        Me.lblAlternoAutotanquesSA.Name = "lblAlternoAutotanquesSA"
        Me.lblAlternoAutotanquesSA.Size = New System.Drawing.Size(72, 14)
        Me.lblAlternoAutotanquesSA.TabIndex = 14
        Me.lblAlternoAutotanquesSA.Text = "Color alterno:"
        '
        'btnAlternoAutotanquesSA
        '
        Me.btnAlternoAutotanquesSA.Anchor = (System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right)
        Me.btnAlternoAutotanquesSA.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnAlternoAutotanquesSA.Location = New System.Drawing.Point(162, 50)
        Me.btnAlternoAutotanquesSA.Name = "btnAlternoAutotanquesSA"
        Me.btnAlternoAutotanquesSA.Size = New System.Drawing.Size(24, 23)
        Me.btnAlternoAutotanquesSA.TabIndex = 15
        '
        'lblFondoAutotanquesSA
        '
        Me.lblFondoAutotanquesSA.AutoSize = True
        Me.lblFondoAutotanquesSA.Location = New System.Drawing.Point(24, 25)
        Me.lblFondoAutotanquesSA.Name = "lblFondoAutotanquesSA"
        Me.lblFondoAutotanquesSA.Size = New System.Drawing.Size(39, 14)
        Me.lblFondoAutotanquesSA.TabIndex = 12
        Me.lblFondoAutotanquesSA.Text = "Fondo:"
        '
        'btnFondoAutotanquesSA
        '
        Me.btnFondoAutotanquesSA.Anchor = (System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right)
        Me.btnFondoAutotanquesSA.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnFondoAutotanquesSA.Location = New System.Drawing.Point(162, 21)
        Me.btnFondoAutotanquesSA.Name = "btnFondoAutotanquesSA"
        Me.btnFondoAutotanquesSA.Size = New System.Drawing.Size(24, 23)
        Me.btnFondoAutotanquesSA.TabIndex = 13
        '
        'gpnlEmpleadosSA
        '
        Me.gpnlEmpleadosSA.Controls.AddRange(New System.Windows.Forms.Control() {Me.lblTextoEmpleadosSA, Me.btnTextoEmpleadosSA, Me.lblAlternoEmpleadosSA, Me.btnAlternoEmpleadosSA, Me.lblFondoEmpleadosSA, Me.btnFondoEmpleadosSA})
        Me.gpnlEmpleadosSA.DividerColor = System.Drawing.Color.Gainsboro
        Me.gpnlEmpleadosSA.Dock = System.Windows.Forms.DockStyle.Top
        Me.gpnlEmpleadosSA.GroupPanelState = Logistica.GroupPanel.PanelState.Collapsed
        Me.gpnlEmpleadosSA.Location = New System.Drawing.Point(0, 32)
        Me.gpnlEmpleadosSA.Name = "gpnlEmpleadosSA"
        Me.gpnlEmpleadosSA.PanelStateEffect = Logistica.GroupPanel.MovementEffect.MoveAlignedControls
        Me.gpnlEmpleadosSA.Size = New System.Drawing.Size(196, 16)
        Me.gpnlEmpleadosSA.TabIndex = 17
        Me.gpnlEmpleadosSA.Title = "Empleados sin asignar"
        Me.gpnlEmpleadosSA.TitleBackColor = System.Drawing.Color.Gainsboro
        Me.gpnlEmpleadosSA.TitleFont = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gpnlEmpleadosSA.TitleForeColor = System.Drawing.SystemColors.ControlText
        '
        'lblTextoEmpleadosSA
        '
        Me.lblTextoEmpleadosSA.AutoSize = True
        Me.lblTextoEmpleadosSA.Location = New System.Drawing.Point(24, 83)
        Me.lblTextoEmpleadosSA.Name = "lblTextoEmpleadosSA"
        Me.lblTextoEmpleadosSA.Size = New System.Drawing.Size(36, 14)
        Me.lblTextoEmpleadosSA.TabIndex = 16
        Me.lblTextoEmpleadosSA.Text = "Texto:"
        '
        'btnTextoEmpleadosSA
        '
        Me.btnTextoEmpleadosSA.Anchor = (System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right)
        Me.btnTextoEmpleadosSA.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnTextoEmpleadosSA.Location = New System.Drawing.Point(162, 79)
        Me.btnTextoEmpleadosSA.Name = "btnTextoEmpleadosSA"
        Me.btnTextoEmpleadosSA.Size = New System.Drawing.Size(24, 23)
        Me.btnTextoEmpleadosSA.TabIndex = 17
        '
        'lblAlternoEmpleadosSA
        '
        Me.lblAlternoEmpleadosSA.AutoSize = True
        Me.lblAlternoEmpleadosSA.Location = New System.Drawing.Point(24, 54)
        Me.lblAlternoEmpleadosSA.Name = "lblAlternoEmpleadosSA"
        Me.lblAlternoEmpleadosSA.Size = New System.Drawing.Size(72, 14)
        Me.lblAlternoEmpleadosSA.TabIndex = 14
        Me.lblAlternoEmpleadosSA.Text = "Color alterno:"
        '
        'btnAlternoEmpleadosSA
        '
        Me.btnAlternoEmpleadosSA.Anchor = (System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right)
        Me.btnAlternoEmpleadosSA.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnAlternoEmpleadosSA.Location = New System.Drawing.Point(162, 50)
        Me.btnAlternoEmpleadosSA.Name = "btnAlternoEmpleadosSA"
        Me.btnAlternoEmpleadosSA.Size = New System.Drawing.Size(24, 23)
        Me.btnAlternoEmpleadosSA.TabIndex = 15
        '
        'lblFondoEmpleadosSA
        '
        Me.lblFondoEmpleadosSA.AutoSize = True
        Me.lblFondoEmpleadosSA.Location = New System.Drawing.Point(24, 25)
        Me.lblFondoEmpleadosSA.Name = "lblFondoEmpleadosSA"
        Me.lblFondoEmpleadosSA.Size = New System.Drawing.Size(39, 14)
        Me.lblFondoEmpleadosSA.TabIndex = 12
        Me.lblFondoEmpleadosSA.Text = "Fondo:"
        '
        'btnFondoEmpleadosSA
        '
        Me.btnFondoEmpleadosSA.Anchor = (System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right)
        Me.btnFondoEmpleadosSA.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnFondoEmpleadosSA.Location = New System.Drawing.Point(162, 21)
        Me.btnFondoEmpleadosSA.Name = "btnFondoEmpleadosSA"
        Me.btnFondoEmpleadosSA.Size = New System.Drawing.Size(24, 23)
        Me.btnFondoEmpleadosSA.TabIndex = 13
        '
        'gpnlOperadores
        '
        Me.gpnlOperadores.Controls.AddRange(New System.Windows.Forms.Control() {Me.lblTextoTituloOperadores, Me.btnTextoTituloOperadores, Me.lblFondoTituloOperadores, Me.btnFondoTituloOperadores, Me.lblTextoOperadores, Me.btnTextoOperadores, Me.lblAlternoOperadores, Me.btnAlternoOperadores, Me.lblFondoOperadores, Me.btnFondoOperadores})
        Me.gpnlOperadores.DividerColor = System.Drawing.Color.Gainsboro
        Me.gpnlOperadores.Dock = System.Windows.Forms.DockStyle.Top
        Me.gpnlOperadores.ExpandedHeight = 176
        Me.gpnlOperadores.GroupPanelState = Logistica.GroupPanel.PanelState.Collapsed
        Me.gpnlOperadores.Location = New System.Drawing.Point(0, 16)
        Me.gpnlOperadores.Name = "gpnlOperadores"
        Me.gpnlOperadores.PanelStateEffect = Logistica.GroupPanel.MovementEffect.MoveAlignedControls
        Me.gpnlOperadores.Size = New System.Drawing.Size(196, 16)
        Me.gpnlOperadores.TabIndex = 16
        Me.gpnlOperadores.Title = "Tabla de operadores"
        Me.gpnlOperadores.TitleBackColor = System.Drawing.Color.Gainsboro
        Me.gpnlOperadores.TitleFont = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gpnlOperadores.TitleForeColor = System.Drawing.SystemColors.ControlText
        '
        'lblTextoTituloOperadores
        '
        Me.lblTextoTituloOperadores.AutoSize = True
        Me.lblTextoTituloOperadores.Location = New System.Drawing.Point(24, 54)
        Me.lblTextoTituloOperadores.Name = "lblTextoTituloOperadores"
        Me.lblTextoTituloOperadores.Size = New System.Drawing.Size(83, 14)
        Me.lblTextoTituloOperadores.TabIndex = 22
        Me.lblTextoTituloOperadores.Text = "Texto del título:"
        '
        'btnTextoTituloOperadores
        '
        Me.btnTextoTituloOperadores.Anchor = (System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right)
        Me.btnTextoTituloOperadores.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnTextoTituloOperadores.Location = New System.Drawing.Point(162, 50)
        Me.btnTextoTituloOperadores.Name = "btnTextoTituloOperadores"
        Me.btnTextoTituloOperadores.Size = New System.Drawing.Size(24, 23)
        Me.btnTextoTituloOperadores.TabIndex = 23
        '
        'lblFondoTituloOperadores
        '
        Me.lblFondoTituloOperadores.AutoSize = True
        Me.lblFondoTituloOperadores.Location = New System.Drawing.Point(24, 25)
        Me.lblFondoTituloOperadores.Name = "lblFondoTituloOperadores"
        Me.lblFondoTituloOperadores.Size = New System.Drawing.Size(86, 14)
        Me.lblFondoTituloOperadores.TabIndex = 20
        Me.lblFondoTituloOperadores.Text = "Fondo del título:"
        '
        'btnFondoTituloOperadores
        '
        Me.btnFondoTituloOperadores.Anchor = (System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right)
        Me.btnFondoTituloOperadores.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnFondoTituloOperadores.Location = New System.Drawing.Point(162, 21)
        Me.btnFondoTituloOperadores.Name = "btnFondoTituloOperadores"
        Me.btnFondoTituloOperadores.Size = New System.Drawing.Size(24, 23)
        Me.btnFondoTituloOperadores.TabIndex = 21
        '
        'lblTextoOperadores
        '
        Me.lblTextoOperadores.AutoSize = True
        Me.lblTextoOperadores.Location = New System.Drawing.Point(24, 141)
        Me.lblTextoOperadores.Name = "lblTextoOperadores"
        Me.lblTextoOperadores.Size = New System.Drawing.Size(36, 14)
        Me.lblTextoOperadores.TabIndex = 16
        Me.lblTextoOperadores.Text = "Texto:"
        '
        'btnTextoOperadores
        '
        Me.btnTextoOperadores.Anchor = (System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right)
        Me.btnTextoOperadores.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnTextoOperadores.Location = New System.Drawing.Point(162, 137)
        Me.btnTextoOperadores.Name = "btnTextoOperadores"
        Me.btnTextoOperadores.Size = New System.Drawing.Size(24, 23)
        Me.btnTextoOperadores.TabIndex = 17
        '
        'lblAlternoOperadores
        '
        Me.lblAlternoOperadores.AutoSize = True
        Me.lblAlternoOperadores.Location = New System.Drawing.Point(24, 112)
        Me.lblAlternoOperadores.Name = "lblAlternoOperadores"
        Me.lblAlternoOperadores.Size = New System.Drawing.Size(72, 14)
        Me.lblAlternoOperadores.TabIndex = 14
        Me.lblAlternoOperadores.Text = "Color alterno:"
        '
        'btnAlternoOperadores
        '
        Me.btnAlternoOperadores.Anchor = (System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right)
        Me.btnAlternoOperadores.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnAlternoOperadores.Location = New System.Drawing.Point(162, 108)
        Me.btnAlternoOperadores.Name = "btnAlternoOperadores"
        Me.btnAlternoOperadores.Size = New System.Drawing.Size(24, 23)
        Me.btnAlternoOperadores.TabIndex = 15
        '
        'lblFondoOperadores
        '
        Me.lblFondoOperadores.AutoSize = True
        Me.lblFondoOperadores.Location = New System.Drawing.Point(24, 83)
        Me.lblFondoOperadores.Name = "lblFondoOperadores"
        Me.lblFondoOperadores.Size = New System.Drawing.Size(39, 14)
        Me.lblFondoOperadores.TabIndex = 12
        Me.lblFondoOperadores.Text = "Fondo:"
        '
        'btnFondoOperadores
        '
        Me.btnFondoOperadores.Anchor = (System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right)
        Me.btnFondoOperadores.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnFondoOperadores.Location = New System.Drawing.Point(162, 79)
        Me.btnFondoOperadores.Name = "btnFondoOperadores"
        Me.btnFondoOperadores.Size = New System.Drawing.Size(24, 23)
        Me.btnFondoOperadores.TabIndex = 13
        '
        'gpnlFolios
        '
        Me.gpnlFolios.Controls.AddRange(New System.Windows.Forms.Control() {Me.lblTextoTituloFolios, Me.btnTextoTituloFolios, Me.lblFonfoTituloFolios, Me.btnFondoTituloFolios, Me.lblSeleccionFolios, Me.btnSeleccionFolios, Me.lblTextoFolios, Me.btnTextoFolios, Me.lblAlternoFolios, Me.btnAlternoFolios, Me.lblFondoFolios, Me.btnFondoFolios})
        Me.gpnlFolios.DividerColor = System.Drawing.Color.Gainsboro
        Me.gpnlFolios.Dock = System.Windows.Forms.DockStyle.Top
        Me.gpnlFolios.ExpandedHeight = 208
        Me.gpnlFolios.GroupPanelState = Logistica.GroupPanel.PanelState.Collapsed
        Me.gpnlFolios.Name = "gpnlFolios"
        Me.gpnlFolios.PanelStateEffect = Logistica.GroupPanel.MovementEffect.MoveAlignedControls
        Me.gpnlFolios.Size = New System.Drawing.Size(196, 16)
        Me.gpnlFolios.TabIndex = 15
        Me.gpnlFolios.Title = "Tabla de folios"
        Me.gpnlFolios.TitleBackColor = System.Drawing.Color.Gainsboro
        Me.gpnlFolios.TitleFont = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gpnlFolios.TitleForeColor = System.Drawing.SystemColors.ControlText
        '
        'lblTextoTituloFolios
        '
        Me.lblTextoTituloFolios.AutoSize = True
        Me.lblTextoTituloFolios.Location = New System.Drawing.Point(24, 54)
        Me.lblTextoTituloFolios.Name = "lblTextoTituloFolios"
        Me.lblTextoTituloFolios.Size = New System.Drawing.Size(83, 14)
        Me.lblTextoTituloFolios.TabIndex = 22
        Me.lblTextoTituloFolios.Text = "Texto del título:"
        '
        'btnTextoTituloFolios
        '
        Me.btnTextoTituloFolios.Anchor = (System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right)
        Me.btnTextoTituloFolios.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnTextoTituloFolios.Location = New System.Drawing.Point(162, 50)
        Me.btnTextoTituloFolios.Name = "btnTextoTituloFolios"
        Me.btnTextoTituloFolios.Size = New System.Drawing.Size(24, 23)
        Me.btnTextoTituloFolios.TabIndex = 23
        '
        'lblFonfoTituloFolios
        '
        Me.lblFonfoTituloFolios.AutoSize = True
        Me.lblFonfoTituloFolios.Location = New System.Drawing.Point(24, 25)
        Me.lblFonfoTituloFolios.Name = "lblFonfoTituloFolios"
        Me.lblFonfoTituloFolios.Size = New System.Drawing.Size(86, 14)
        Me.lblFonfoTituloFolios.TabIndex = 20
        Me.lblFonfoTituloFolios.Text = "Fondo del título:"
        '
        'btnFondoTituloFolios
        '
        Me.btnFondoTituloFolios.Anchor = (System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right)
        Me.btnFondoTituloFolios.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnFondoTituloFolios.Location = New System.Drawing.Point(162, 21)
        Me.btnFondoTituloFolios.Name = "btnFondoTituloFolios"
        Me.btnFondoTituloFolios.Size = New System.Drawing.Size(24, 23)
        Me.btnFondoTituloFolios.TabIndex = 21
        '
        'lblSeleccionFolios
        '
        Me.lblSeleccionFolios.AutoSize = True
        Me.lblSeleccionFolios.Location = New System.Drawing.Point(24, 170)
        Me.lblSeleccionFolios.Name = "lblSeleccionFolios"
        Me.lblSeleccionFolios.Size = New System.Drawing.Size(122, 14)
        Me.lblSeleccionFolios.TabIndex = 18
        Me.lblSeleccionFolios.Text = "Elemento seleccionado:"
        '
        'btnSeleccionFolios
        '
        Me.btnSeleccionFolios.Anchor = (System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right)
        Me.btnSeleccionFolios.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnSeleccionFolios.Location = New System.Drawing.Point(162, 166)
        Me.btnSeleccionFolios.Name = "btnSeleccionFolios"
        Me.btnSeleccionFolios.Size = New System.Drawing.Size(24, 23)
        Me.btnSeleccionFolios.TabIndex = 19
        '
        'lblTextoFolios
        '
        Me.lblTextoFolios.AutoSize = True
        Me.lblTextoFolios.Location = New System.Drawing.Point(24, 141)
        Me.lblTextoFolios.Name = "lblTextoFolios"
        Me.lblTextoFolios.Size = New System.Drawing.Size(36, 14)
        Me.lblTextoFolios.TabIndex = 16
        Me.lblTextoFolios.Text = "Texto:"
        '
        'btnTextoFolios
        '
        Me.btnTextoFolios.Anchor = (System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right)
        Me.btnTextoFolios.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnTextoFolios.Location = New System.Drawing.Point(162, 137)
        Me.btnTextoFolios.Name = "btnTextoFolios"
        Me.btnTextoFolios.Size = New System.Drawing.Size(24, 23)
        Me.btnTextoFolios.TabIndex = 17
        '
        'lblAlternoFolios
        '
        Me.lblAlternoFolios.AutoSize = True
        Me.lblAlternoFolios.Location = New System.Drawing.Point(24, 112)
        Me.lblAlternoFolios.Name = "lblAlternoFolios"
        Me.lblAlternoFolios.Size = New System.Drawing.Size(72, 14)
        Me.lblAlternoFolios.TabIndex = 14
        Me.lblAlternoFolios.Text = "Color alterno:"
        '
        'btnAlternoFolios
        '
        Me.btnAlternoFolios.Anchor = (System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right)
        Me.btnAlternoFolios.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnAlternoFolios.Location = New System.Drawing.Point(162, 108)
        Me.btnAlternoFolios.Name = "btnAlternoFolios"
        Me.btnAlternoFolios.Size = New System.Drawing.Size(24, 23)
        Me.btnAlternoFolios.TabIndex = 15
        '
        'lblFondoFolios
        '
        Me.lblFondoFolios.AutoSize = True
        Me.lblFondoFolios.Location = New System.Drawing.Point(24, 83)
        Me.lblFondoFolios.Name = "lblFondoFolios"
        Me.lblFondoFolios.Size = New System.Drawing.Size(39, 14)
        Me.lblFondoFolios.TabIndex = 12
        Me.lblFondoFolios.Text = "Fondo:"
        '
        'btnFondoFolios
        '
        Me.btnFondoFolios.Anchor = (System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right)
        Me.btnFondoFolios.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnFondoFolios.Location = New System.Drawing.Point(162, 79)
        Me.btnFondoFolios.Name = "btnFondoFolios"
        Me.btnFondoFolios.Size = New System.Drawing.Size(24, 23)
        Me.btnFondoFolios.TabIndex = 13
        '
        'Panel1
        '
        Me.Panel1.Controls.AddRange(New System.Windows.Forms.Control() {Me.lblBarraAsignacion, Me.btnBarraAsignacion})
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel1.Location = New System.Drawing.Point(0, 20)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(196, 36)
        Me.Panel1.TabIndex = 11
        '
        'lblBarraAsignacion
        '
        Me.lblBarraAsignacion.AutoSize = True
        Me.lblBarraAsignacion.Location = New System.Drawing.Point(25, 11)
        Me.lblBarraAsignacion.Name = "lblBarraAsignacion"
        Me.lblBarraAsignacion.Size = New System.Drawing.Size(76, 14)
        Me.lblBarraAsignacion.TabIndex = 10
        Me.lblBarraAsignacion.Text = "Barra y fondo:"
        '
        'btnBarraAsignacion
        '
        Me.btnBarraAsignacion.Anchor = (System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right)
        Me.btnBarraAsignacion.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnBarraAsignacion.Location = New System.Drawing.Point(158, 7)
        Me.btnBarraAsignacion.Name = "btnBarraAsignacion"
        Me.btnBarraAsignacion.Size = New System.Drawing.Size(24, 23)
        Me.btnBarraAsignacion.TabIndex = 11
        '
        'mnuMas
        '
        Me.mnuMas.MenuItems.AddRange(New System.Windows.Forms.MenuItem() {Me.mniMas})
        '
        'mniMas
        '
        Me.mniMas.Index = 0
        Me.mniMas.MenuItems.AddRange(New System.Windows.Forms.MenuItem() {Me.mniPrincipal, Me.mniOperadores, Me.mniAutotanques, Me.mniLogisticos, Me.mniRutas, Me.mniAsignaciones})
        Me.mniMas.Text = "&+"
        '
        'mniPrincipal
        '
        Me.mniPrincipal.Index = 0
        Me.mniPrincipal.Text = "Pantalla &principal"
        '
        'mniOperadores
        '
        Me.mniOperadores.Index = 1
        Me.mniOperadores.Text = "Catálogo de &operadores"
        '
        'mniAutotanques
        '
        Me.mniAutotanques.Index = 2
        Me.mniAutotanques.Text = "Catálogo de au&totanques"
        '
        'mniLogisticos
        '
        Me.mniLogisticos.Index = 3
        Me.mniLogisticos.Text = "Catálogo de &logísticos"
        Me.mniLogisticos.Visible = False
        '
        'mniRutas
        '
        Me.mniRutas.Index = 4
        Me.mniRutas.Text = "Catálogo de &rutas"
        Me.mniRutas.Visible = False
        '
        'mniAsignaciones
        '
        Me.mniAsignaciones.Index = 5
        Me.mniAsignaciones.Text = "&Asignaciones"
        '
        'tpnlLogistico
        '
        Me.tpnlLogistico.BackColor = System.Drawing.Color.WhiteSmoke
        Me.tpnlLogistico.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.tpnlLogistico.Controls.AddRange(New System.Windows.Forms.Control() {Me.btnATablaLogistico, Me.lblATablaLogistico, Me.lblBarraLogistico, Me.btnBarraLogistico, Me.lblFTablaLogistico, Me.btnFTablaLogistico, Me.btnTTablaLogistico, Me.lblTTablaLogistico})
        Me.tpnlLogistico.Dock = System.Windows.Forms.DockStyle.Top
        Me.tpnlLogistico.ExpandedHeight = 153
        Me.tpnlLogistico.Location = New System.Drawing.Point(0, 84)
        Me.tpnlLogistico.Name = "tpnlLogistico"
        Me.tpnlLogistico.PanelStateEffect = Logistica.ToolPanel.MovementEffect.MoveAlignedControls
        Me.tpnlLogistico.PanelToolState = Logistica.ToolPanel.PanelState.Collapsed
        Me.tpnlLogistico.Size = New System.Drawing.Size(198, 21)
        Me.tpnlLogistico.Style = Logistica.ToolPanel.PanelStyle.Rectangle
        Me.tpnlLogistico.TabIndex = 6
        Me.tpnlLogistico.Title = "Catálogo de logísticos"
        Me.tpnlLogistico.TitleAlignment = System.Windows.Forms.HorizontalAlignment.Left
        Me.tpnlLogistico.TitleBackColor = System.Drawing.Color.DarkBlue
        Me.tpnlLogistico.TitleFont = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tpnlLogistico.TitleForeColor = System.Drawing.Color.White
        Me.tpnlLogistico.Visible = False
        '
        'btnATablaLogistico
        '
        Me.btnATablaLogistico.Anchor = (System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right)
        Me.btnATablaLogistico.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnATablaLogistico.Location = New System.Drawing.Point(153, 88)
        Me.btnATablaLogistico.Name = "btnATablaLogistico"
        Me.btnATablaLogistico.Size = New System.Drawing.Size(24, 23)
        Me.btnATablaLogistico.TabIndex = 16
        '
        'lblATablaLogistico
        '
        Me.lblATablaLogistico.AutoSize = True
        Me.lblATablaLogistico.Location = New System.Drawing.Point(9, 92)
        Me.lblATablaLogistico.Name = "lblATablaLogistico"
        Me.lblATablaLogistico.Size = New System.Drawing.Size(116, 14)
        Me.lblATablaLogistico.TabIndex = 13
        Me.lblATablaLogistico.Text = "Color alterno de tabla:"
        '
        'lblBarraLogistico
        '
        Me.lblBarraLogistico.AutoSize = True
        Me.lblBarraLogistico.Location = New System.Drawing.Point(9, 32)
        Me.lblBarraLogistico.Name = "lblBarraLogistico"
        Me.lblBarraLogistico.Size = New System.Drawing.Size(120, 14)
        Me.lblBarraLogistico.TabIndex = 10
        Me.lblBarraLogistico.Text = "Barra de herramientas:"
        '
        'btnBarraLogistico
        '
        Me.btnBarraLogistico.Anchor = (System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right)
        Me.btnBarraLogistico.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnBarraLogistico.Location = New System.Drawing.Point(153, 28)
        Me.btnBarraLogistico.Name = "btnBarraLogistico"
        Me.btnBarraLogistico.Size = New System.Drawing.Size(24, 23)
        Me.btnBarraLogistico.TabIndex = 17
        '
        'lblFTablaLogistico
        '
        Me.lblFTablaLogistico.AutoSize = True
        Me.lblFTablaLogistico.Location = New System.Drawing.Point(9, 62)
        Me.lblFTablaLogistico.Name = "lblFTablaLogistico"
        Me.lblFTablaLogistico.Size = New System.Drawing.Size(95, 14)
        Me.lblFTablaLogistico.TabIndex = 11
        Me.lblFTablaLogistico.Text = "Fondo de la tabla:"
        '
        'btnFTablaLogistico
        '
        Me.btnFTablaLogistico.Anchor = (System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right)
        Me.btnFTablaLogistico.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnFTablaLogistico.Location = New System.Drawing.Point(153, 58)
        Me.btnFTablaLogistico.Name = "btnFTablaLogistico"
        Me.btnFTablaLogistico.Size = New System.Drawing.Size(24, 23)
        Me.btnFTablaLogistico.TabIndex = 15
        '
        'btnTTablaLogistico
        '
        Me.btnTTablaLogistico.Anchor = (System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right)
        Me.btnTTablaLogistico.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnTTablaLogistico.Location = New System.Drawing.Point(153, 118)
        Me.btnTTablaLogistico.Name = "btnTTablaLogistico"
        Me.btnTTablaLogistico.Size = New System.Drawing.Size(24, 23)
        Me.btnTTablaLogistico.TabIndex = 14
        '
        'lblTTablaLogistico
        '
        Me.lblTTablaLogistico.AutoSize = True
        Me.lblTTablaLogistico.Location = New System.Drawing.Point(9, 122)
        Me.lblTTablaLogistico.Name = "lblTTablaLogistico"
        Me.lblTTablaLogistico.Size = New System.Drawing.Size(92, 14)
        Me.lblTTablaLogistico.TabIndex = 12
        Me.lblTTablaLogistico.Text = "Texto de la tabla:"
        '
        'tpnlRuta
        '
        Me.tpnlRuta.BackColor = System.Drawing.Color.WhiteSmoke
        Me.tpnlRuta.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.tpnlRuta.Controls.AddRange(New System.Windows.Forms.Control() {Me.btnATablaRuta, Me.lblATablaRuta, Me.lblBarraRuta, Me.btnBarraRuta, Me.lblFTablaRuta, Me.btnFTablaRuta, Me.btnTTablaRuta, Me.lblTTablaRuta})
        Me.tpnlRuta.Dock = System.Windows.Forms.DockStyle.Top
        Me.tpnlRuta.ExpandedHeight = 171
        Me.tpnlRuta.Location = New System.Drawing.Point(0, 105)
        Me.tpnlRuta.Name = "tpnlRuta"
        Me.tpnlRuta.PanelStateEffect = Logistica.ToolPanel.MovementEffect.MoveAlignedControls
        Me.tpnlRuta.PanelToolState = Logistica.ToolPanel.PanelState.Collapsed
        Me.tpnlRuta.Size = New System.Drawing.Size(198, 21)
        Me.tpnlRuta.Style = Logistica.ToolPanel.PanelStyle.Rectangle
        Me.tpnlRuta.TabIndex = 7
        Me.tpnlRuta.Title = "Catálogo de rutas"
        Me.tpnlRuta.TitleAlignment = System.Windows.Forms.HorizontalAlignment.Left
        Me.tpnlRuta.TitleBackColor = System.Drawing.Color.DarkBlue
        Me.tpnlRuta.TitleFont = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tpnlRuta.TitleForeColor = System.Drawing.Color.White
        Me.tpnlRuta.Visible = False
        '
        'btnATablaRuta
        '
        Me.btnATablaRuta.Anchor = (System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right)
        Me.btnATablaRuta.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnATablaRuta.Location = New System.Drawing.Point(155, 95)
        Me.btnATablaRuta.Name = "btnATablaRuta"
        Me.btnATablaRuta.Size = New System.Drawing.Size(24, 23)
        Me.btnATablaRuta.TabIndex = 24
        '
        'lblATablaRuta
        '
        Me.lblATablaRuta.AutoSize = True
        Me.lblATablaRuta.Location = New System.Drawing.Point(11, 99)
        Me.lblATablaRuta.Name = "lblATablaRuta"
        Me.lblATablaRuta.Size = New System.Drawing.Size(116, 14)
        Me.lblATablaRuta.TabIndex = 21
        Me.lblATablaRuta.Text = "Color alterno de tabla:"
        '
        'lblBarraRuta
        '
        Me.lblBarraRuta.AutoSize = True
        Me.lblBarraRuta.Location = New System.Drawing.Point(11, 39)
        Me.lblBarraRuta.Name = "lblBarraRuta"
        Me.lblBarraRuta.Size = New System.Drawing.Size(120, 14)
        Me.lblBarraRuta.TabIndex = 18
        Me.lblBarraRuta.Text = "Barra de herramientas:"
        '
        'btnBarraRuta
        '
        Me.btnBarraRuta.Anchor = (System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right)
        Me.btnBarraRuta.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnBarraRuta.Location = New System.Drawing.Point(155, 35)
        Me.btnBarraRuta.Name = "btnBarraRuta"
        Me.btnBarraRuta.Size = New System.Drawing.Size(24, 23)
        Me.btnBarraRuta.TabIndex = 25
        '
        'lblFTablaRuta
        '
        Me.lblFTablaRuta.AutoSize = True
        Me.lblFTablaRuta.Location = New System.Drawing.Point(11, 69)
        Me.lblFTablaRuta.Name = "lblFTablaRuta"
        Me.lblFTablaRuta.Size = New System.Drawing.Size(95, 14)
        Me.lblFTablaRuta.TabIndex = 19
        Me.lblFTablaRuta.Text = "Fondo de la tabla:"
        '
        'btnFTablaRuta
        '
        Me.btnFTablaRuta.Anchor = (System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right)
        Me.btnFTablaRuta.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnFTablaRuta.Location = New System.Drawing.Point(155, 65)
        Me.btnFTablaRuta.Name = "btnFTablaRuta"
        Me.btnFTablaRuta.Size = New System.Drawing.Size(24, 23)
        Me.btnFTablaRuta.TabIndex = 23
        '
        'btnTTablaRuta
        '
        Me.btnTTablaRuta.Anchor = (System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right)
        Me.btnTTablaRuta.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnTTablaRuta.Location = New System.Drawing.Point(155, 125)
        Me.btnTTablaRuta.Name = "btnTTablaRuta"
        Me.btnTTablaRuta.Size = New System.Drawing.Size(24, 23)
        Me.btnTTablaRuta.TabIndex = 22
        '
        'lblTTablaRuta
        '
        Me.lblTTablaRuta.AutoSize = True
        Me.lblTTablaRuta.Location = New System.Drawing.Point(11, 129)
        Me.lblTTablaRuta.Name = "lblTTablaRuta"
        Me.lblTTablaRuta.Size = New System.Drawing.Size(92, 14)
        Me.lblTTablaRuta.TabIndex = 20
        Me.lblTTablaRuta.Text = "Texto de la tabla:"
        '
        'frmPersonalizar
        '
        Me.AcceptButton = Me.btnAceptar
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 14)
        Me.BackColor = System.Drawing.Color.Gainsboro
        Me.CancelButton = Me.btnCancelar
        Me.ClientSize = New System.Drawing.Size(286, 543)
        Me.Controls.AddRange(New System.Windows.Forms.Control() {Me.tpnlRuta, Me.tpnlLogistico, Me.tpnlAsignacion, Me.tpnlAutotanque, Me.tpnlOperador, Me.tpnlPrincipal, Me.pnlBotones})
        Me.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.Menu = Me.mnuMas
        Me.MinimizeBox = False
        Me.Name = "frmPersonalizar"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Personalizar"
        Me.pnlBotones.ResumeLayout(False)
        Me.tpnlPrincipal.ResumeLayout(False)
        CType(Me.nudBloqueo, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tpnlOperador.ResumeLayout(False)
        Me.tpnlAutotanque.ResumeLayout(False)
        Me.tpnlAsignacion.ResumeLayout(False)
        Me.pnlGrupos.ResumeLayout(False)
        Me.gpnlAutotanquesPrestados.ResumeLayout(False)
        Me.gpnlEmpleadosPrestados.ResumeLayout(False)
        Me.gpnlAutotanquesPrestamo.ResumeLayout(False)
        Me.gpnlEmpleadosPrestamo.ResumeLayout(False)
        Me.gpnlAutotanquesSA.ResumeLayout(False)
        Me.gpnlEmpleadosSA.ResumeLayout(False)
        Me.gpnlOperadores.ResumeLayout(False)
        Me.gpnlFolios.ResumeLayout(False)
        Me.Panel1.ResumeLayout(False)
        Me.tpnlLogistico.ResumeLayout(False)
        Me.tpnlRuta.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

#End Region

    Private Pantalla As String

    Private Sub CargaConfiguracion()
        Try
            Dim Settings As AppSettings
            If File.Exists(Application.StartupPath & "\" & System.Environment.UserName & ".Logistica.exe.config") Then
                Settings = New AppSettings(Application.StartupPath & "\" & System.Environment.UserName & ".Logistica.exe.config")
            Else
                Settings = New AppSettings(Application.StartupPath & "\" & "Default.Logistica.exe.config")
            End If
            'Pantalla principal
            btnBarraPrincipal.BackColor = Color.FromArgb(CInt(Settings.GetSetting("frmPrincipal", "BackColor")))
            nudBloqueo.Value = CInt(Settings.GetSetting("frmPrincipal", "LockTime"))
            'Catalogo de operadores
            btnBarraOperador.BackColor = Color.FromArgb(CInt(Settings.GetSetting("frmOperador", "BackColor")))
            btnFTablaOperador.BackColor = Color.FromArgb(CInt(Settings.GetSetting("frmOperador", "CatalogoBackColor")))
            btnATablaOperador.BackColor = Color.FromArgb(CInt(Settings.GetSetting("frmOperador", "CatalogoAltBackColor")))
            btnTTablaOperador.BackColor = Color.FromArgb(CInt(Settings.GetSetting("frmOperador", "CatalogoForeColor")))
            btnFInfoOperador.BackColor = Color.FromArgb(CInt(Settings.GetSetting("frmOperador", "DExtraBackColor")))
            btnTInfoOperador.BackColor = Color.FromArgb(CInt(Settings.GetSetting("frmOperador", "DExtraForeColor")))
            btnTBFOperador.BackColor = Color.FromArgb(CInt(Settings.GetSetting("frmOperador", "DExtraTBackColor")))
            btnTBTOperador.BackColor = Color.FromArgb(CInt(Settings.GetSetting("frmOperador", "DExtraForeColor")))
            'Catalogo de autotanques
            btnBarraAutotanque.BackColor = Color.FromArgb(CInt(Settings.GetSetting("frmAutotanque", "BackColor")))
            btnFTablaAutotanque.BackColor = Color.FromArgb(CInt(Settings.GetSetting("frmAutotanque", "CatalogoBackColor")))
            btnATablaAutotanque.BackColor = Color.FromArgb(CInt(Settings.GetSetting("frmAutotanque", "CatalogoAltBackColor")))
            btnTTablaAutotanque.BackColor = Color.FromArgb(CInt(Settings.GetSetting("frmAutotanque", "CatalogoForeColor")))
            btnFInfoAutotanque.BackColor = Color.FromArgb(CInt(Settings.GetSetting("frmAutotanque", "DExtraBackColor")))
            btnTInfoAutotanque.BackColor = Color.FromArgb(CInt(Settings.GetSetting("frmAutotanque", "DExtraForeColor")))
            btnTBFAutotanque.BackColor = Color.FromArgb(CInt(Settings.GetSetting("frmAutotanque", "DExtraTBackColor")))
            btnTBTAutotanque.BackColor = Color.FromArgb(CInt(Settings.GetSetting("frmAutotanque", "DExtraForeColor")))
            'Pantalla de asignación
            btnBarraAsignacion.BackColor = Color.FromArgb(CInt(Settings.GetSetting("frmAsignacion", "BackColor")))
            btnFondoTituloFolios.BackColor = Color.FromArgb(CInt(Settings.GetSetting("frmAsignacion", "FoliosCaptionBackColor")))
            btnTextoTituloFolios.BackColor = Color.FromArgb(CInt(Settings.GetSetting("frmAsignacion", "FoliosCaptionForeColor")))
            btnFondoFolios.BackColor = Color.FromArgb(CInt(Settings.GetSetting("frmAsignacion", "FoliosBackColor")))
            btnAlternoFolios.BackColor = Color.FromArgb(CInt(Settings.GetSetting("frmAsignacion", "FoliosAltBackColor")))
            btnTextoFolios.BackColor = Color.FromArgb(CInt(Settings.GetSetting("frmAsignacion", "FoliosForeColor")))
            btnSeleccionFolios.BackColor = Color.FromArgb(CInt(Settings.GetSetting("frmAsignacion", "FoliosSelectionColor")))
            btnFondoTituloOperadores.BackColor = Color.FromArgb(CInt(Settings.GetSetting("frmAsignacion", "OperadoresCaptionBackColor")))
            btnTextoTituloOperadores.BackColor = Color.FromArgb(CInt(Settings.GetSetting("frmAsignacion", "OperadoresCaptionForeColor")))
            btnFondoOperadores.BackColor = Color.FromArgb(CInt(Settings.GetSetting("frmAsignacion", "OperadoresBackColor")))
            btnAlternoOperadores.BackColor = Color.FromArgb(CInt(Settings.GetSetting("frmAsignacion", "OperadoresAltBackColor")))
            btnTextoOperadores.BackColor = Color.FromArgb(CInt(Settings.GetSetting("frmAsignacion", "OperadoresForeColor")))
            btnFondoEmpleadosSA.BackColor = Color.FromArgb(CInt(Settings.GetSetting("frmAsignacion", "EmpleadosSABackColor")))
            btnAlternoEmpleadosSA.BackColor = Color.FromArgb(CInt(Settings.GetSetting("frmAsignacion", "EmpleadosSAAltBackColor")))
            btnTextoEmpleadosSA.BackColor = Color.FromArgb(CInt(Settings.GetSetting("frmAsignacion", "EmpleadosSAForeColor")))
            btnFondoAutotanquesSA.BackColor = Color.FromArgb(CInt(Settings.GetSetting("frmAsignacion", "AutotanquesSABackColor")))
            btnAlternoAutotanquesSA.BackColor = Color.FromArgb(CInt(Settings.GetSetting("frmAsignacion", "AutotanquesSAAltBackColor")))
            btnTextoAutotanquesSA.BackColor = Color.FromArgb(CInt(Settings.GetSetting("frmAsignacion", "AutotanquesSAForeColor")))
            btnFondoEmpleadosPrestamo.BackColor = Color.FromArgb(CInt(Settings.GetSetting("frmAsignacion", "EmpleadosPrestamoBackColor")))
            btnAlternoEmpleadosPrestamo.BackColor = Color.FromArgb(CInt(Settings.GetSetting("frmAsignacion", "EmpleadosPrestamoAltBackColor")))
            btnTextoEmpleadosPrestamo.BackColor = Color.FromArgb(CInt(Settings.GetSetting("frmAsignacion", "EmpleadosPrestamoForeColor")))
            btnFondoAutotanquesPrestamo.BackColor = Color.FromArgb(CInt(Settings.GetSetting("frmAsignacion", "AutotanquesPrestamoBackColor")))
            btnAlternoAutotanquesPrestamo.BackColor = Color.FromArgb(CInt(Settings.GetSetting("frmAsignacion", "AutotanquesPrestamoAltBackColor")))
            btnTextoAutotanquesPrestamo.BackColor = Color.FromArgb(CInt(Settings.GetSetting("frmAsignacion", "AutotanquesPrestamoForeColor")))
            btnFondoEmpleadosPrestados.BackColor = Color.FromArgb(CInt(Settings.GetSetting("frmAsignacion", "EmpleadosPrestadosBackColor")))
            btnAlternoEmpleadosPrestados.BackColor = Color.FromArgb(CInt(Settings.GetSetting("frmAsignacion", "EmpleadosPrestadosAltBackColor")))
            btnTextoEmpleadosPrestados.BackColor = Color.FromArgb(CInt(Settings.GetSetting("frmAsignacion", "EmpleadosPrestadosForeColor")))
            btnFondoAutotanquesPrestados.BackColor = Color.FromArgb(CInt(Settings.GetSetting("frmAsignacion", "AutotanquesPrestadosBackColor")))
            btnAlternoAutotanquesPrestados.BackColor = Color.FromArgb(CInt(Settings.GetSetting("frmAsignacion", "AutotanquesPrestadosAltBackColor")))
            btnTextoAutotanquesPrestados.BackColor = Color.FromArgb(CInt(Settings.GetSetting("frmAsignacion", "AutotanquesPrestadosForeColor")))
            'Catalogo de logisticos
            btnBarraLogistico.BackColor = Color.FromArgb(CInt(Settings.GetSetting("frmLogistico", "BackColor")))
            btnFTablaLogistico.BackColor = Color.FromArgb(CInt(Settings.GetSetting("frmLogistico", "CatalogoBackColor")))
            btnATablaLogistico.BackColor = Color.FromArgb(CInt(Settings.GetSetting("frmLogistico", "CatalogoAltBackColor")))
            btnTTablaLogistico.BackColor = Color.FromArgb(CInt(Settings.GetSetting("frmLogistico", "CatalogoForeColor")))
            'Catalogo de rutas
            btnBarraRuta.BackColor = Color.FromArgb(CInt(Settings.GetSetting("frmRuta", "BackColor")))
            btnFTablaRuta.BackColor = Color.FromArgb(CInt(Settings.GetSetting("frmRuta", "CatalogoBackColor")))
            btnATablaRuta.BackColor = Color.FromArgb(CInt(Settings.GetSetting("frmRuta", "CatalogoAltBackColor")))
            btnTTablaRuta.BackColor = Color.FromArgb(CInt(Settings.GetSetting("frmRuta", "CatalogoForeColor")))
        Catch ex As Exception
            ErrMessage("No existe el archivo " + Application.StartupPath & "\" & "Default.Logistica.exe.config" + " ó al mismo le hace falta alguna de las configuraciones. LLame a soporte. Detalles: " + ex.Message)
        End Try
    End Sub
    Private Sub btnConfig_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBarraPrincipal.Click, btnATablaOperador.Click, btnBarraOperador.Click, btnFInfoOperador.Click, btnFTablaOperador.Click, btnTBFOperador.Click, btnTBTOperador.Click, btnTInfoOperador.Click, btnTTablaOperador.Click, btnATablaAutotanque.Click, btnBarraAutotanque.Click, btnFInfoAutotanque.Click, btnFTablaAutotanque.Click, btnTBFAutotanque.Click, btnTBTAutotanque.Click, btnTInfoAutotanque.Click, btnTTablaAutotanque.Click, btnBarraAsignacion.Click, btnFondoTituloFolios.Click, btnTextoTituloFolios.Click, btnFondoFolios.Click, btnAlternoFolios.Click, btnSeleccionFolios.Click, btnFondoTituloOperadores.Click, btnTextoTituloOperadores.Click, btnFondoOperadores.Click, btnAlternoOperadores.Click, btnFondoEmpleadosSA.Click, btnAlternoEmpleadosSA.Click, btnFondoAutotanquesSA.Click, btnAlternoAutotanquesSA.Click, btnTextoAutotanquesSA.Click, btnFondoEmpleadosPrestamo.Click, btnAlternoEmpleadosPrestamo.Click, btnTextoEmpleadosPrestamo.Click, btnFondoAutotanquesPrestamo.Click, btnAlternoAutotanquesPrestamo.Click, btnTextoAutotanquesPrestamo.Click, btnFondoEmpleadosPrestados.Click, btnAlternoEmpleadosPrestados.Click, btnTextoEmpleadosPrestados.Click, btnFondoAutotanquesPrestados.Click, btnAlternoAutotanquesPrestados.Click, btnTextoAutotanquesPrestados.Click, btnTextoFolios.Click, btnTextoOperadores.Click, btnTextoEmpleadosSA.Click, btnBarraLogistico.Click, btnFTablaLogistico.Click, btnATablaLogistico.Click, btnTTablaLogistico.Click, btnBarraRuta.Click, btnFTablaRuta.Click, btnATablaRuta.Click, btnTTablaRuta.Click
        dlgColor.Color = CType(sender, Button).BackColor
        GuardaCambios()
        If dlgColor.ShowDialog() = DialogResult.OK Then
            CType(sender, Button).BackColor = dlgColor.Color
        End If
    End Sub
    Private Sub btnAceptar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAceptar.Click
        GuardaCambios()
        Me.Close()
        Me.Dispose()
    End Sub
    Private Sub GuardaCambios()
        Dim Settings As New AppSettings(Application.StartupPath & "\" & System.Environment.UserName & ".Logistica.exe.config")
        'Pantalla principal
        Settings.SaveSetting("frmPrincipal", "BackColor", btnBarraPrincipal.BackColor.ToArgb.ToString)
        Settings.SaveSetting("frmPrincipal", "LockTime", nudBloqueo.Value.ToString)
        'Catalogo de operadores
        Settings.SaveSetting("frmOperador", "BackColor", btnBarraOperador.BackColor.ToArgb.ToString)
        Settings.SaveSetting("frmOperador", "CatalogoBackColor", btnFTablaOperador.BackColor.ToArgb.ToString)
        Settings.SaveSetting("frmOperador", "CatalogoAltBackColor", btnATablaOperador.BackColor.ToArgb.ToString)
        Settings.SaveSetting("frmOperador", "CatalogoForeColor", btnTTablaOperador.BackColor.ToArgb.ToString)
        Settings.SaveSetting("frmOperador", "DExtraBackColor", btnFInfoOperador.BackColor.ToArgb.ToString)
        Settings.SaveSetting("frmOperador", "DExtraForeColor", btnTInfoOperador.BackColor.ToArgb.ToString)
        Settings.SaveSetting("frmOperador", "DExtraTBackColor", btnTBFOperador.BackColor.ToArgb.ToString)
        Settings.SaveSetting("frmOperador", "DExtraTForeColor", btnTBTOperador.BackColor.ToArgb.ToString)
        'Catalogo de autotanques
        Settings.SaveSetting("frmAutotanque", "BackColor", btnBarraAutotanque.BackColor.ToArgb.ToString)
        Settings.SaveSetting("frmAutotanque", "CatalogoBackColor", btnFTablaAutotanque.BackColor.ToArgb.ToString)
        Settings.SaveSetting("frmAutotanque", "CatalogoAltBackColor", btnATablaAutotanque.BackColor.ToArgb.ToString)
        Settings.SaveSetting("frmAutotanque", "CatalogoForeColor", btnTTablaAutotanque.BackColor.ToArgb.ToString)
        Settings.SaveSetting("frmAutotanque", "DExtraBackColor", btnFInfoAutotanque.BackColor.ToArgb.ToString)
        Settings.SaveSetting("frmAutotanque", "DExtraForeColor", btnTInfoAutotanque.BackColor.ToArgb.ToString)
        Settings.SaveSetting("frmAutotanque", "DExtraTBackColor", btnTBFAutotanque.BackColor.ToArgb.ToString)
        Settings.SaveSetting("frmAutotanque", "DExtraTForeColor", btnTBTAutotanque.BackColor.ToArgb.ToString)
        'Pantalla de asignación
        Settings.SaveSetting("frmAsignacion", "BackColor", btnBarraAsignacion.BackColor.ToArgb.ToString)
        Settings.SaveSetting("frmAsignacion", "FoliosCaptionBackColor", btnFondoTituloFolios.BackColor.ToArgb.ToString)
        Settings.SaveSetting("frmAsignacion", "FoliosCaptionForeColor", btnTextoTituloFolios.BackColor.ToArgb.ToString)
        Settings.SaveSetting("frmAsignacion", "FoliosBackColor", btnFondoFolios.BackColor.ToArgb.ToString)
        Settings.SaveSetting("frmAsignacion", "FoliosAltBackColor", btnAlternoFolios.BackColor.ToArgb.ToString)
        Settings.SaveSetting("frmAsignacion", "FoliosForeColor", btnTextoFolios.BackColor.ToArgb.ToString)
        Settings.SaveSetting("frmAsignacion", "FoliosSelectionColor", btnSeleccionFolios.BackColor.ToArgb.ToString)
        Settings.SaveSetting("frmAsignacion", "OperadoresCaptionBackColor", btnFondoTituloOperadores.BackColor.ToArgb.ToString)
        Settings.SaveSetting("frmAsignacion", "OperadoresCaptionForeColor", btnTextoTituloOperadores.BackColor.ToArgb.ToString)
        Settings.SaveSetting("frmAsignacion", "OperadoresBackColor", btnFondoOperadores.BackColor.ToArgb.ToString)
        Settings.SaveSetting("frmAsignacion", "OperadoresAltBackColor", btnAlternoOperadores.BackColor.ToArgb.ToString)
        Settings.SaveSetting("frmAsignacion", "OperadoresForeColor", btnTextoOperadores.BackColor.ToArgb.ToString)
        Settings.SaveSetting("frmAsignacion", "EmpleadosSABackColor", btnFondoEmpleadosSA.BackColor.ToArgb.ToString)
        Settings.SaveSetting("frmAsignacion", "EmpleadosSAAltBackColor", btnAlternoEmpleadosSA.BackColor.ToArgb.ToString)
        Settings.SaveSetting("frmAsignacion", "EmpleadosSAForeColor", btnTextoEmpleadosSA.BackColor.ToArgb.ToString)
        Settings.SaveSetting("frmAsignacion", "AutotanquesSABackColor", btnFondoAutotanquesSA.BackColor.ToArgb.ToString)
        Settings.SaveSetting("frmAsignacion", "AutotanquesSAAltBackColor", btnAlternoAutotanquesSA.BackColor.ToArgb.ToString)
        Settings.SaveSetting("frmAsignacion", "AutotanquesSAForeColor", btnTextoAutotanquesSA.BackColor.ToArgb.ToString)
        Settings.SaveSetting("frmAsignacion", "EmpleadosPrestamoBackColor", btnFondoEmpleadosPrestamo.BackColor.ToArgb.ToString)
        Settings.SaveSetting("frmAsignacion", "EmpleadosPrestamoAltBackColor", btnAlternoEmpleadosPrestamo.BackColor.ToArgb.ToString)
        Settings.SaveSetting("frmAsignacion", "EmpleadosPrestamoForeColor", btnTextoEmpleadosPrestamo.BackColor.ToArgb.ToString)
        Settings.SaveSetting("frmAsignacion", "AutotanquesPrestamoBackColor", btnFondoAutotanquesPrestamo.BackColor.ToArgb.ToString)
        Settings.SaveSetting("frmAsignacion", "AutotanquesPrestamoAltBackColor", btnAlternoAutotanquesPrestamo.BackColor.ToArgb.ToString)
        Settings.SaveSetting("frmAsignacion", "AutotanquesPrestamoForeColor", btnTextoAutotanquesPrestamo.BackColor.ToArgb.ToString)
        Settings.SaveSetting("frmAsignacion", "EmpleadosPrestadosBackColor", btnFondoEmpleadosPrestados.BackColor.ToArgb.ToString)
        Settings.SaveSetting("frmAsignacion", "EmpleadosPrestadosAltBackColor", btnAlternoEmpleadosPrestados.BackColor.ToArgb.ToString)
        Settings.SaveSetting("frmAsignacion", "EmpleadosPrestadosForeColor", btnTextoEmpleadosPrestados.BackColor.ToArgb.ToString)
        Settings.SaveSetting("frmAsignacion", "AutotanquesPrestadosBackColor", btnFondoAutotanquesPrestados.BackColor.ToArgb.ToString)
        Settings.SaveSetting("frmAsignacion", "AutotanquesPrestadosAltBackColor", btnAlternoAutotanquesPrestados.BackColor.ToArgb.ToString)
        Settings.SaveSetting("frmAsignacion", "AutotanquesPrestadosForeColor", btnTextoAutotanquesPrestados.BackColor.ToArgb.ToString)
        'Catalogo de logisticos
        Settings.SaveSetting("frmLogistico", "BackColor", btnBarraLogistico.BackColor.ToArgb.ToString)
        Settings.SaveSetting("frmLogistico", "CatalogoBackColor", btnFTablaLogistico.BackColor.ToArgb.ToString)
        Settings.SaveSetting("frmLogistico", "CatalogoAltBackColor", btnATablaLogistico.BackColor.ToArgb.ToString)
        Settings.SaveSetting("frmLogistico", "CatalogoForeColor", btnTTablaLogistico.BackColor.ToArgb.ToString)
        'Catalogo de rutas
        Settings.SaveSetting("frmRuta", "BackColor", btnBarraRuta.BackColor.ToArgb.ToString)
        Settings.SaveSetting("frmRuta", "CatalogoBackColor", btnFTablaRuta.BackColor.ToArgb.ToString)
        Settings.SaveSetting("frmRuta", "CatalogoAltBackColor", btnATablaRuta.BackColor.ToArgb.ToString)
        Settings.SaveSetting("frmRuta", "CatalogoForeColor", btnTTablaRuta.BackColor.ToArgb.ToString)
    End Sub
    Private Sub btnCancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancelar.Click
        Me.Close()
        Me.Dispose()
    End Sub
    Private Sub btnDefault_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDefault.Click
        Dim Settings As New AppSettings(Application.StartupPath & "\" & "Default.Logistica.exe.config")
        Select Case Pantalla
            Case "frmPrincipal"
                'Pantalla principal
                btnBarraPrincipal.BackColor = Color.FromArgb(CInt(Settings.GetSetting("frmPrincipal", "BackColor")))
                nudBloqueo.Value = 10
            Case "frmOperador"
                'Catalogo de operadores
                btnBarraOperador.BackColor = Color.FromArgb(CInt(Settings.GetSetting("frmOperador", "BackColor")))
                btnFTablaOperador.BackColor = Color.FromArgb(CInt(Settings.GetSetting("frmOperador", "CatalogoBackColor")))
                btnATablaOperador.BackColor = Color.FromArgb(CInt(Settings.GetSetting("frmOperador", "CatalogoAltBackColor")))
                btnTTablaOperador.BackColor = Color.FromArgb(CInt(Settings.GetSetting("frmOperador", "CatalogoForeColor")))
                btnFInfoOperador.BackColor = Color.FromArgb(CInt(Settings.GetSetting("frmOperador", "DExtraBackColor")))
                btnTInfoOperador.BackColor = Color.FromArgb(CInt(Settings.GetSetting("frmOperador", "DExtraForeColor")))
                btnTBFOperador.BackColor = Color.FromArgb(CInt(Settings.GetSetting("frmOperador", "DExtraTBackColor")))
                btnTBTOperador.BackColor = Color.FromArgb(CInt(Settings.GetSetting("frmOperador", "DExtraForeColor")))
            Case "frmAutotanque"
                'Catalogo de autotanques
                btnBarraAutotanque.BackColor = Color.FromArgb(CInt(Settings.GetSetting("frmAutotanque", "BackColor")))
                btnFTablaAutotanque.BackColor = Color.FromArgb(CInt(Settings.GetSetting("frmAutotanque", "CatalogoBackColor")))
                btnATablaAutotanque.BackColor = Color.FromArgb(CInt(Settings.GetSetting("frmAutotanque", "CatalogoAltBackColor")))
                btnTTablaAutotanque.BackColor = Color.FromArgb(CInt(Settings.GetSetting("frmAutotanque", "CatalogoForeColor")))
                btnFInfoAutotanque.BackColor = Color.FromArgb(CInt(Settings.GetSetting("frmAutotanque", "DExtraBackColor")))
                btnTInfoAutotanque.BackColor = Color.FromArgb(CInt(Settings.GetSetting("frmAutotanque", "DExtraForeColor")))
                btnTBFAutotanque.BackColor = Color.FromArgb(CInt(Settings.GetSetting("frmAutotanque", "DExtraTBackColor")))
                btnTBTAutotanque.BackColor = Color.FromArgb(CInt(Settings.GetSetting("frmAutotanque", "DExtraForeColor")))
            Case "frmAsignacion"
                'Pantalla de asignación
                btnBarraAsignacion.BackColor = Color.FromArgb(CInt(Settings.GetSetting("frmAsignacion", "BackColor")))
                btnFondoTituloFolios.BackColor = Color.FromArgb(CInt(Settings.GetSetting("frmAsignacion", "FoliosCaptionBackColor")))
                btnTextoTituloFolios.BackColor = Color.FromArgb(CInt(Settings.GetSetting("frmAsignacion", "FoliosCaptionForeColor")))
                btnFondoFolios.BackColor = Color.FromArgb(CInt(Settings.GetSetting("frmAsignacion", "FoliosBackColor")))
                btnAlternoFolios.BackColor = Color.FromArgb(CInt(Settings.GetSetting("frmAsignacion", "FoliosAltBackColor")))
                btnTextoFolios.BackColor = Color.FromArgb(CInt(Settings.GetSetting("frmAsignacion", "FoliosForeColor")))
                btnSeleccionFolios.BackColor = Color.FromArgb(CInt(Settings.GetSetting("frmAsignacion", "FoliosSelectionColor")))
                btnFondoTituloOperadores.BackColor = Color.FromArgb(CInt(Settings.GetSetting("frmAsignacion", "OperadoresCaptionBackColor")))
                btnTextoTituloOperadores.BackColor = Color.FromArgb(CInt(Settings.GetSetting("frmAsignacion", "OperadoresCaptionForeColor")))
                btnFondoOperadores.BackColor = Color.FromArgb(CInt(Settings.GetSetting("frmAsignacion", "OperadoresBackColor")))
                btnAlternoOperadores.BackColor = Color.FromArgb(CInt(Settings.GetSetting("frmAsignacion", "OperadoresAltBackColor")))
                btnTextoOperadores.BackColor = Color.FromArgb(CInt(Settings.GetSetting("frmAsignacion", "OperadoresForeColor")))
                btnFondoEmpleadosSA.BackColor = Color.FromArgb(CInt(Settings.GetSetting("frmAsignacion", "EmpleadosSABackColor")))
                btnAlternoEmpleadosSA.BackColor = Color.FromArgb(CInt(Settings.GetSetting("frmAsignacion", "EmpleadosSAAltBackColor")))
                btnTextoEmpleadosSA.BackColor = Color.FromArgb(CInt(Settings.GetSetting("frmAsignacion", "EmpleadosSAForeColor")))
                btnFondoAutotanquesSA.BackColor = Color.FromArgb(CInt(Settings.GetSetting("frmAsignacion", "AutotanquesSABackColor")))
                btnAlternoAutotanquesSA.BackColor = Color.FromArgb(CInt(Settings.GetSetting("frmAsignacion", "AutotanquesSAAltBackColor")))
                btnTextoAutotanquesSA.BackColor = Color.FromArgb(CInt(Settings.GetSetting("frmAsignacion", "AutotanquesSAForeColor")))
                btnFondoEmpleadosPrestamo.BackColor = Color.FromArgb(CInt(Settings.GetSetting("frmAsignacion", "EmpleadosPrestamoBackColor")))
                btnAlternoEmpleadosPrestamo.BackColor = Color.FromArgb(CInt(Settings.GetSetting("frmAsignacion", "EmpleadosPrestamoAltBackColor")))
                btnTextoEmpleadosPrestamo.BackColor = Color.FromArgb(CInt(Settings.GetSetting("frmAsignacion", "EmpleadosPrestamoForeColor")))
                btnFondoAutotanquesPrestamo.BackColor = Color.FromArgb(CInt(Settings.GetSetting("frmAsignacion", "AutotanquesPrestamoBackColor")))
                btnAlternoAutotanquesPrestamo.BackColor = Color.FromArgb(CInt(Settings.GetSetting("frmAsignacion", "AutotanquesPrestamoAltBackColor")))
                btnTextoAutotanquesPrestamo.BackColor = Color.FromArgb(CInt(Settings.GetSetting("frmAsignacion", "AutotanquesPrestamoForeColor")))
                btnFondoEmpleadosPrestados.BackColor = Color.FromArgb(CInt(Settings.GetSetting("frmAsignacion", "EmpleadosPrestadosBackColor")))
                btnAlternoEmpleadosPrestados.BackColor = Color.FromArgb(CInt(Settings.GetSetting("frmAsignacion", "EmpleadosPrestadosAltBackColor")))
                btnTextoEmpleadosPrestados.BackColor = Color.FromArgb(CInt(Settings.GetSetting("frmAsignacion", "EmpleadosPrestadosForeColor")))
                btnFondoAutotanquesPrestados.BackColor = Color.FromArgb(CInt(Settings.GetSetting("frmAsignacion", "AutotanquesPrestadosBackColor")))
                btnAlternoAutotanquesPrestados.BackColor = Color.FromArgb(CInt(Settings.GetSetting("frmAsignacion", "AutotanquesPrestadosAltBackColor")))
                btnTextoAutotanquesPrestados.BackColor = Color.FromArgb(CInt(Settings.GetSetting("frmAsignacion", "AutotanquesPrestadosForeColor")))
            Case "frmLogistico"
                'Catalogo de Logisticoes
                btnBarraLogistico.BackColor = Color.FromArgb(CInt(Settings.GetSetting("frmLogistico", "BackColor")))
                btnFTablaLogistico.BackColor = Color.FromArgb(CInt(Settings.GetSetting("frmLogistico", "CatalogoBackColor")))
                btnATablaLogistico.BackColor = Color.FromArgb(CInt(Settings.GetSetting("frmLogistico", "CatalogoAltBackColor")))
                btnTTablaLogistico.BackColor = Color.FromArgb(CInt(Settings.GetSetting("frmLogistico", "CatalogoForeColor")))
            Case "frmRuta"
                'Catalogo de rutas
                btnBarraRuta.BackColor = Color.FromArgb(CInt(Settings.GetSetting("frmRuta", "BackColor")))
                btnFTablaRuta.BackColor = Color.FromArgb(CInt(Settings.GetSetting("frmRuta", "CatalogoBackColor")))
                btnATablaRuta.BackColor = Color.FromArgb(CInt(Settings.GetSetting("frmRuta", "CatalogoAltBackColor")))
                btnTTablaRuta.BackColor = Color.FromArgb(CInt(Settings.GetSetting("frmRuta", "CatalogoForeColor")))
        End Select
    End Sub
    Private Sub CargaElementosConfiguracion(ByVal Pantalla As String)
        Me.Pantalla = Pantalla
        Select Case Pantalla
            Case "frmPrincipal"
                tpnlPrincipal.Visible = True
                tpnlPrincipal.Expand()
                tpnlPrincipal.Refresh()
                mniPrincipal.Visible = False
                Me.Height = tpnlPrincipal.Height + 90
            Case "frmOperador"
                tpnlOperador.Visible = True
                tpnlOperador.Expand()
                tpnlOperador.Refresh()
                mniOperadores.Visible = False
                Me.Height = tpnlOperador.Height + 50
            Case "frmAutotanque"
                tpnlAutotanque.Visible = True
                tpnlAutotanque.Expand()
                tpnlAutotanque.Refresh()
                mniAutotanques.Visible = False
                Me.Height = tpnlAutotanque.Height + 50
            Case "frmAsignacion"
                tpnlAsignacion.Visible = True
                tpnlAsignacion.Expand()
                tpnlAsignacion.Refresh()
                mniAsignaciones.Visible = False
                Me.Height = tpnlAsignacion.Height + 50
            Case "frmLogistico"
                tpnlLogistico.Visible = True
                tpnlLogistico.Expand()
                tpnlLogistico.Refresh()
                mniLogisticos.Visible = False
                Me.Height = tpnlLogistico.Height + 50
            Case "frmRuta"
                tpnlRuta.Visible = True
                tpnlRuta.Expand()
                tpnlRuta.Refresh()
                mniRutas.Visible = False
                Me.Height = tpnlRuta.Height + 50
        End Select
    End Sub
    Private Sub mniMas_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mniPrincipal.Click, mniAsignaciones.Click, mniAutotanques.Click, mniOperadores.Click, mniLogisticos.Click, mniRutas.Click
        Dim mni As MenuItem
        For Each mni In mniMas.MenuItems
            mni.Visible = True
        Next
        Select Case Pantalla
            Case "frmPrincipal"
                tpnlPrincipal.Visible = False
            Case "frmOperador"
                tpnlOperador.Visible = False
            Case "frmAutotanque"
                tpnlAutotanque.Visible = False
            Case "frmAsignacion"
                tpnlAsignacion.Visible = False
            Case "frmLogistico"
                tpnlLogistico.Visible = False
            Case "frmRuta"
                tpnlRuta.Visible = False
        End Select
        Select Case CType(sender, MenuItem).Text
            Case "Pantalla &principal"
                CargaElementosConfiguracion("frmPrincipal")
            Case "Catálogo de &operadores"
                CargaElementosConfiguracion("frmOperador")
            Case "Catálogo de au&totanques"
                CargaElementosConfiguracion("frmAutotanque")
            Case "&Asignaciones"
                CargaElementosConfiguracion("frmAsignacion")
            Case "Catálogo de &logísticos"
                CargaElementosConfiguracion("frmLogistico")
            Case "Catálogo de &rutas"
                CargaElementosConfiguracion("frmRuta")
        End Select
    End Sub
    Private Sub Asignacion_GroupPanelStateChange() Handles gpnlFolios.GroupPanelStateChange, gpnlAutotanquesSA.GroupPanelStateChange, gpnlEmpleadosPrestamo.GroupPanelStateChange, gpnlEmpleadosPrestados.GroupPanelStateChange, gpnlAutotanquesPrestamo.GroupPanelStateChange, gpnlEmpleadosSA.GroupPanelStateChange, gpnlOperadores.GroupPanelStateChange, gpnlAutotanquesPrestados.GroupPanelStateChange
        tpnlAsignacion.Height = gpnlFolios.Height + gpnlOperadores.Height + gpnlEmpleadosSA.Height + gpnlAutotanquesSA.Height + _
                                gpnlEmpleadosPrestamo.Height + gpnlAutotanquesPrestamo.Height + gpnlEmpleadosPrestados.Height + _
                                gpnlAutotanquesPrestados.Height + 80
        Me.Height = tpnlAsignacion.Height + 50
    End Sub


End Class
