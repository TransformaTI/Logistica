Imports System
Imports System.IO
Imports System.Data
Imports System.Data.SqlClient
Imports Logistica


Public Class frmPrincipal
    Inherits System.Windows.Forms.Form

#Region " Windows Form Designer generated code "

    Public Sub New()
        MyBase.New()

        'This call is required by the Windows Form Designer.
        InitializeComponent()

        'Add any initialization after the InitializeComponent() call
        Me.Text = Application.ProductName & " v." & Application.ProductVersion
        Inactivity.TimeUnits = Logistica.InactivityLock.TimeUnit.Minutes
        Inactivity.LockTime = 10

        stsFecha.Text = Format(Now, "dd/MM/yyyy")
        stsArea.Text = Globales._DesCelula
        stsNombre.Text = Globales._Nombre
        stsUsuario.Text = Globales._Usuario
        sbpServidor.Text = _Servidor
        sbpBaseDeDatos.Text = _Database

        mniOperador.Enabled = OperacionLogistica(4).Habilitada Or OperacionLogistica(13).Habilitada
        btnOperador.Enabled = OperacionLogistica(4).Habilitada Or OperacionLogistica(13).Habilitada
        mniAutotanque.Enabled = OperacionLogistica(3).Habilitada
        btnAutotanque.Enabled = OperacionLogistica(3).Habilitada
        mniAsignacion.Enabled = OperacionLogistica(14).Habilitada
        btnAsignacion.Enabled = OperacionLogistica(14).Habilitada

        If OperacionLogistica(6).Habilitada Then
            Sep3_1.Visible = True
            btnLogisticos.Visible = True
            MSep2.Visible = True
            mniLogistico.Visible = True
            mniLogistico.Enabled = True
        End If
        If OperacionLogistica(7).Habilitada Then
            Sep3_2.Visible = True
            btnRuta.Visible = True
            MSep3.Visible = True
            mniRuta.Visible = True
            mniRuta.Enabled = True
        End If
        If OperacionLogistica(8).Habilitada Then
            btnPullPostureros.Visible = True
            mniAsignacionPostureros.Visible = True
            mniAsignacionPostureros.Enabled = True
        End If
        If OperacionLogistica(9).Habilitada Then
            mniOperadorPortatil.Visible = True
            mniOperadorPortatil.Enabled = True
        End If
        If OperacionLogistica(10).Habilitada Then
            btnAsignPortatil.Visible = True
            mniAsignacionPortatil.Visible = True
            mniAsignacionPortatil.Enabled = True
        End If

        If OperacionLogistica(18).Habilitada Or OperacionLogistica(19).Habilitada Then
            MSep4.Visible = True
            mniFactor.Visible = True
            mniFactor.Enabled = True
        End If

        'LUSATE Seguimiento RAF

        If OperacionLogistica(22).Habilitada Then
            mnuAuxilioFallas.Visible = True
            mnuAuxilioFallas.Enabled = True
            MSep5.Visible = True
            MSep5.Enabled = True
            btnRAF.Visible = True
            btnRAF.Enabled = True
            Sep6.Visible = True
            Sep6.Enabled = True

        End If

        PortatilClasses.Globals.GetInstance.ConfiguraModulo(_Usuario, _Password, cnSigamet.ConnectionString, _Corporativo, _Sucursal)

        'LUSATE Habilita Soporte Móvil
        If OperacionLogistica(23).Habilitada Or OperacionLogistica(24).Habilitada Then
            mniSoporteMovil.Enabled = True
            mniSoporteMovil.Visible = True
        End If

        'TEXIS habilita Tablero Monitor
        If OperacionLogistica(25).Habilitada Then
            mniTablero.Enabled = True
        End If

        If OperacionLogistica(26).Habilitada Then
            mniMapas.Enabled = True
        End If

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
    Friend WithEvents stsUsuario As System.Windows.Forms.StatusBarPanel
    Friend WithEvents mnuMain As System.Windows.Forms.MainMenu
    Friend WithEvents mniSistema As System.Windows.Forms.MenuItem
    Friend WithEvents mniSalir As System.Windows.Forms.MenuItem
    Friend WithEvents mniCatalogos As System.Windows.Forms.MenuItem
    Friend WithEvents mniAutotanque As System.Windows.Forms.MenuItem
    Friend WithEvents mniOperador As System.Windows.Forms.MenuItem
    Friend WithEvents mniAyuda As System.Windows.Forms.MenuItem
    Friend WithEvents mniAcercaDe As System.Windows.Forms.MenuItem
    Friend WithEvents sbpServidor As System.Windows.Forms.StatusBarPanel
    Friend WithEvents sbpBaseDeDatos As System.Windows.Forms.StatusBarPanel
    Friend WithEvents stbPrincipal As System.Windows.Forms.StatusBar
    Friend WithEvents stsNombre As System.Windows.Forms.StatusBarPanel
    Friend WithEvents stsArea As System.Windows.Forms.StatusBarPanel
    Friend WithEvents stsFecha As System.Windows.Forms.StatusBarPanel
    Friend WithEvents mniReportesU1 As System.Windows.Forms.MenuItem
    Friend WithEvents mniReportes As System.Windows.Forms.MenuItem
    Friend WithEvents imgHerramientas As System.Windows.Forms.ImageList
    Friend WithEvents tbHerramientas As System.Windows.Forms.ToolBar
    Friend WithEvents btnAsignacion As System.Windows.Forms.ToolBarButton
    Friend WithEvents btnAutotanque As System.Windows.Forms.ToolBarButton
    Friend WithEvents btnOperador As System.Windows.Forms.ToolBarButton
    Friend WithEvents btnSalir As System.Windows.Forms.ToolBarButton
    Friend WithEvents Sep0 As System.Windows.Forms.ToolBarButton
    Friend WithEvents Sep1 As System.Windows.Forms.ToolBarButton
    Friend WithEvents Sep2 As System.Windows.Forms.ToolBarButton
    Friend WithEvents Sep3 As System.Windows.Forms.ToolBarButton
    Friend WithEvents Sep4 As System.Windows.Forms.ToolBarButton
    Friend WithEvents MSep1 As System.Windows.Forms.MenuItem
    Friend WithEvents mniOpciones As System.Windows.Forms.MenuItem
    Friend WithEvents mniPersonalizar As System.Windows.Forms.MenuItem
    Friend WithEvents btnPersonalizar As System.Windows.Forms.ToolBarButton
    Friend WithEvents Sep5 As System.Windows.Forms.ToolBarButton
    Friend WithEvents mniAsignacion As System.Windows.Forms.MenuItem
    Friend WithEvents mniAsignacionR As System.Windows.Forms.MenuItem
    Friend WithEvents btnLogisticos As System.Windows.Forms.ToolBarButton
    Friend WithEvents Sep3_1 As System.Windows.Forms.ToolBarButton
    Friend WithEvents MSep2 As System.Windows.Forms.MenuItem
    Friend WithEvents mniLogistico As System.Windows.Forms.MenuItem
    Friend WithEvents btnRuta As System.Windows.Forms.ToolBarButton
    Friend WithEvents Sep3_2 As System.Windows.Forms.ToolBarButton
    Friend WithEvents MSep3 As System.Windows.Forms.MenuItem
    Friend WithEvents mniRuta As System.Windows.Forms.MenuItem
    Friend WithEvents mniOperadorPortatil As System.Windows.Forms.MenuItem
    Friend WithEvents btnAsignPortatil As System.Windows.Forms.ToolBarButton
    Friend WithEvents btnPullPostureros As System.Windows.Forms.ToolBarButton
    Friend WithEvents mniAsignacionPostureros As System.Windows.Forms.MenuItem
    Friend WithEvents MSep4 As System.Windows.Forms.MenuItem
    Friend WithEvents mniFactor As System.Windows.Forms.MenuItem
    Friend WithEvents mnuAuxilioFallas As System.Windows.Forms.MenuItem
    Friend WithEvents MSep5 As System.Windows.Forms.MenuItem
    Friend WithEvents btnRAF As System.Windows.Forms.ToolBarButton
    Friend WithEvents Sep6 As System.Windows.Forms.ToolBarButton
    Friend WithEvents mniSoporteMovil As System.Windows.Forms.MenuItem
    Friend WithEvents mniTablero As System.Windows.Forms.MenuItem
    Friend WithEvents MenuItem1 As System.Windows.Forms.MenuItem
    Friend WithEvents mniMapas As System.Windows.Forms.MenuItem
    Friend WithEvents mniAsignacionPortatil As System.Windows.Forms.MenuItem
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmPrincipal))
        Me.mnuMain = New System.Windows.Forms.MainMenu(Me.components)
        Me.mniSistema = New System.Windows.Forms.MenuItem()
        Me.mniSalir = New System.Windows.Forms.MenuItem()
        Me.mniAsignacion = New System.Windows.Forms.MenuItem()
        Me.mniAsignacionR = New System.Windows.Forms.MenuItem()
        Me.mniAsignacionPostureros = New System.Windows.Forms.MenuItem()
        Me.mniAsignacionPortatil = New System.Windows.Forms.MenuItem()
        Me.mniCatalogos = New System.Windows.Forms.MenuItem()
        Me.mniAutotanque = New System.Windows.Forms.MenuItem()
        Me.MSep1 = New System.Windows.Forms.MenuItem()
        Me.mnuAuxilioFallas = New System.Windows.Forms.MenuItem()
        Me.MSep5 = New System.Windows.Forms.MenuItem()
        Me.mniOperador = New System.Windows.Forms.MenuItem()
        Me.mniOperadorPortatil = New System.Windows.Forms.MenuItem()
        Me.MSep2 = New System.Windows.Forms.MenuItem()
        Me.mniLogistico = New System.Windows.Forms.MenuItem()
        Me.MSep3 = New System.Windows.Forms.MenuItem()
        Me.mniRuta = New System.Windows.Forms.MenuItem()
        Me.MSep4 = New System.Windows.Forms.MenuItem()
        Me.mniFactor = New System.Windows.Forms.MenuItem()
        Me.mniTablero = New System.Windows.Forms.MenuItem()
        Me.mniMapas = New System.Windows.Forms.MenuItem()
        Me.mniReportesU1 = New System.Windows.Forms.MenuItem()
        Me.mniReportes = New System.Windows.Forms.MenuItem()
        Me.mniSoporteMovil = New System.Windows.Forms.MenuItem()
        Me.mniOpciones = New System.Windows.Forms.MenuItem()
        Me.mniPersonalizar = New System.Windows.Forms.MenuItem()
        Me.mniAyuda = New System.Windows.Forms.MenuItem()
        Me.mniAcercaDe = New System.Windows.Forms.MenuItem()
        Me.stbPrincipal = New System.Windows.Forms.StatusBar()
        Me.stsUsuario = New System.Windows.Forms.StatusBarPanel()
        Me.stsNombre = New System.Windows.Forms.StatusBarPanel()
        Me.stsArea = New System.Windows.Forms.StatusBarPanel()
        Me.stsFecha = New System.Windows.Forms.StatusBarPanel()
        Me.sbpServidor = New System.Windows.Forms.StatusBarPanel()
        Me.sbpBaseDeDatos = New System.Windows.Forms.StatusBarPanel()
        Me.imgHerramientas = New System.Windows.Forms.ImageList(Me.components)
        Me.tbHerramientas = New System.Windows.Forms.ToolBar()
        Me.Sep0 = New System.Windows.Forms.ToolBarButton()
        Me.btnAsignacion = New System.Windows.Forms.ToolBarButton()
        Me.btnAsignPortatil = New System.Windows.Forms.ToolBarButton()
        Me.btnPullPostureros = New System.Windows.Forms.ToolBarButton()
        Me.Sep1 = New System.Windows.Forms.ToolBarButton()
        Me.btnAutotanque = New System.Windows.Forms.ToolBarButton()
        Me.Sep2 = New System.Windows.Forms.ToolBarButton()
        Me.btnRAF = New System.Windows.Forms.ToolBarButton()
        Me.Sep6 = New System.Windows.Forms.ToolBarButton()
        Me.btnOperador = New System.Windows.Forms.ToolBarButton()
        Me.Sep3 = New System.Windows.Forms.ToolBarButton()
        Me.btnLogisticos = New System.Windows.Forms.ToolBarButton()
        Me.Sep3_1 = New System.Windows.Forms.ToolBarButton()
        Me.btnRuta = New System.Windows.Forms.ToolBarButton()
        Me.Sep3_2 = New System.Windows.Forms.ToolBarButton()
        Me.btnPersonalizar = New System.Windows.Forms.ToolBarButton()
        Me.Sep4 = New System.Windows.Forms.ToolBarButton()
        Me.btnSalir = New System.Windows.Forms.ToolBarButton()
        Me.Sep5 = New System.Windows.Forms.ToolBarButton()
        Me.MenuItem1 = New System.Windows.Forms.MenuItem()
        CType(Me.stsUsuario, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.stsNombre, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.stsArea, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.stsFecha, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.sbpServidor, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.sbpBaseDeDatos, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'mnuMain
        '
        Me.mnuMain.MenuItems.AddRange(New System.Windows.Forms.MenuItem() {Me.mniSistema, Me.mniAsignacion, Me.mniCatalogos, Me.mniReportesU1, Me.mniSoporteMovil, Me.mniOpciones, Me.mniAyuda})
        '
        'mniSistema
        '
        Me.mniSistema.Index = 0
        Me.mniSistema.MenuItems.AddRange(New System.Windows.Forms.MenuItem() {Me.mniSalir})
        Me.mniSistema.Text = "&Sistema"
        '
        'mniSalir
        '
        Me.mniSalir.Index = 0
        Me.mniSalir.Text = "Salir"
        '
        'mniAsignacion
        '
        Me.mniAsignacion.Index = 1
        Me.mniAsignacion.MenuItems.AddRange(New System.Windows.Forms.MenuItem() {Me.mniAsignacionR, Me.mniAsignacionPostureros, Me.mniAsignacionPortatil})
        Me.mniAsignacion.MergeOrder = 1
        Me.mniAsignacion.MergeType = System.Windows.Forms.MenuMerge.MergeItems
        Me.mniAsignacion.Text = "&Asignación"
        '
        'mniAsignacionR
        '
        Me.mniAsignacionR.Index = 0
        Me.mniAsignacionR.MergeType = System.Windows.Forms.MenuMerge.MergeItems
        Me.mniAsignacionR.Shortcut = System.Windows.Forms.Shortcut.CtrlA
        Me.mniAsignacionR.Text = "Asignación"
        '
        'mniAsignacionPostureros
        '
        Me.mniAsignacionPostureros.Enabled = False
        Me.mniAsignacionPostureros.Index = 1
        Me.mniAsignacionPostureros.Shortcut = System.Windows.Forms.Shortcut.CtrlS
        Me.mniAsignacionPostureros.Text = "Asignación de postureros"
        Me.mniAsignacionPostureros.Visible = False
        '
        'mniAsignacionPortatil
        '
        Me.mniAsignacionPortatil.Enabled = False
        Me.mniAsignacionPortatil.Index = 2
        Me.mniAsignacionPortatil.Shortcut = System.Windows.Forms.Shortcut.CtrlT
        Me.mniAsignacionPortatil.Text = "Asignación de portatil"
        Me.mniAsignacionPortatil.Visible = False
        '
        'mniCatalogos
        '
        Me.mniCatalogos.Index = 2
        Me.mniCatalogos.MenuItems.AddRange(New System.Windows.Forms.MenuItem() {Me.mniAutotanque, Me.MSep1, Me.mnuAuxilioFallas, Me.MSep5, Me.mniOperador, Me.mniOperadorPortatil, Me.MSep2, Me.mniLogistico, Me.MSep3, Me.mniRuta, Me.MSep4, Me.mniFactor, Me.mniTablero, Me.mniMapas})
        Me.mniCatalogos.MergeOrder = 2
        Me.mniCatalogos.MergeType = System.Windows.Forms.MenuMerge.MergeItems
        Me.mniCatalogos.Text = "&Catálogos"
        '
        'mniAutotanque
        '
        Me.mniAutotanque.Index = 0
        Me.mniAutotanque.MergeType = System.Windows.Forms.MenuMerge.MergeItems
        Me.mniAutotanque.Shortcut = System.Windows.Forms.Shortcut.CtrlT
        Me.mniAutotanque.Text = "Au&totanque"
        '
        'MSep1
        '
        Me.MSep1.Index = 1
        Me.MSep1.Text = "-"
        '
        'mnuAuxilioFallas
        '
        Me.mnuAuxilioFallas.Enabled = False
        Me.mnuAuxilioFallas.Index = 2
        Me.mnuAuxilioFallas.Shortcut = System.Windows.Forms.Shortcut.CtrlX
        Me.mnuAuxilioFallas.Text = "Au&xilio y fallas"
        Me.mnuAuxilioFallas.Visible = False
        '
        'MSep5
        '
        Me.MSep5.Enabled = False
        Me.MSep5.Index = 3
        Me.MSep5.Text = "-"
        Me.MSep5.Visible = False
        '
        'mniOperador
        '
        Me.mniOperador.Index = 4
        Me.mniOperador.MergeOrder = 1
        Me.mniOperador.MergeType = System.Windows.Forms.MenuMerge.MergeItems
        Me.mniOperador.Shortcut = System.Windows.Forms.Shortcut.CtrlO
        Me.mniOperador.Text = "&Operador"
        '
        'mniOperadorPortatil
        '
        Me.mniOperadorPortatil.Enabled = False
        Me.mniOperadorPortatil.Index = 5
        Me.mniOperadorPortatil.MergeOrder = 2
        Me.mniOperadorPortatil.Shortcut = System.Windows.Forms.Shortcut.CtrlP
        Me.mniOperadorPortatil.Text = "&Tripulacion portatil"
        Me.mniOperadorPortatil.Visible = False
        '
        'MSep2
        '
        Me.MSep2.Index = 6
        Me.MSep2.MergeOrder = 1
        Me.MSep2.Text = "-"
        Me.MSep2.Visible = False
        '
        'mniLogistico
        '
        Me.mniLogistico.Enabled = False
        Me.mniLogistico.Index = 7
        Me.mniLogistico.MergeOrder = 3
        Me.mniLogistico.MergeType = System.Windows.Forms.MenuMerge.MergeItems
        Me.mniLogistico.Shortcut = System.Windows.Forms.Shortcut.CtrlL
        Me.mniLogistico.Text = "&Logistico"
        Me.mniLogistico.Visible = False
        '
        'MSep3
        '
        Me.MSep3.Index = 8
        Me.MSep3.MergeOrder = 2
        Me.MSep3.Text = "-"
        Me.MSep3.Visible = False
        '
        'mniRuta
        '
        Me.mniRuta.Enabled = False
        Me.mniRuta.Index = 9
        Me.mniRuta.MergeOrder = 4
        Me.mniRuta.MergeType = System.Windows.Forms.MenuMerge.MergeItems
        Me.mniRuta.Shortcut = System.Windows.Forms.Shortcut.CtrlR
        Me.mniRuta.Text = "&Ruta"
        Me.mniRuta.Visible = False
        '
        'MSep4
        '
        Me.MSep4.Index = 10
        Me.MSep4.Text = "-"
        Me.MSep4.Visible = False
        '
        'mniFactor
        '
        Me.mniFactor.Enabled = False
        Me.mniFactor.Index = 11
        Me.mniFactor.MergeOrder = 5
        Me.mniFactor.MergeType = System.Windows.Forms.MenuMerge.MergeItems
        Me.mniFactor.Shortcut = System.Windows.Forms.Shortcut.CtrlF
        Me.mniFactor.Text = "&Factor"
        Me.mniFactor.Visible = False
        '
        'mniTablero
        '
        Me.mniTablero.Enabled = False
        Me.mniTablero.Index = 12
        Me.mniTablero.Shortcut = System.Windows.Forms.Shortcut.CtrlN
        Me.mniTablero.Text = "Tablero pa&nico"
        '
        'mniMapas
        '
        Me.mniMapas.Enabled = False
        Me.mniMapas.Index = 13
        Me.mniMapas.Text = "Geocercas"
        '
        'mniReportesU1
        '
        Me.mniReportesU1.Index = 3
        Me.mniReportesU1.MenuItems.AddRange(New System.Windows.Forms.MenuItem() {Me.mniReportes})
        Me.mniReportesU1.MergeOrder = 4
        Me.mniReportesU1.Text = "&Reportes"
        '
        'mniReportes
        '
        Me.mniReportes.Index = 0
        Me.mniReportes.Shortcut = System.Windows.Forms.Shortcut.CtrlP
        Me.mniReportes.Text = "&Reportes..."
        '
        'mniSoporteMovil
        '
        Me.mniSoporteMovil.Enabled = False
        Me.mniSoporteMovil.Index = 4
        Me.mniSoporteMovil.Text = "Soporte &Móvil"
        Me.mniSoporteMovil.Visible = False
        '
        'mniOpciones
        '
        Me.mniOpciones.Index = 5
        Me.mniOpciones.MenuItems.AddRange(New System.Windows.Forms.MenuItem() {Me.mniPersonalizar})
        Me.mniOpciones.MergeOrder = 5
        Me.mniOpciones.Text = "&Opciones"
        '
        'mniPersonalizar
        '
        Me.mniPersonalizar.Index = 0
        Me.mniPersonalizar.Shortcut = System.Windows.Forms.Shortcut.F2
        Me.mniPersonalizar.Text = "&Personalizar"
        '
        'mniAyuda
        '
        Me.mniAyuda.Index = 6
        Me.mniAyuda.MenuItems.AddRange(New System.Windows.Forms.MenuItem() {Me.mniAcercaDe})
        Me.mniAyuda.MergeOrder = 6
        Me.mniAyuda.Text = "?"
        '
        'mniAcercaDe
        '
        Me.mniAcercaDe.Index = 0
        Me.mniAcercaDe.Shortcut = System.Windows.Forms.Shortcut.F1
        Me.mniAcercaDe.Text = "Ace&rca de Logística² y Logistica.dll"
        '
        'stbPrincipal
        '
        Me.stbPrincipal.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.stbPrincipal.Location = New System.Drawing.Point(0, 523)
        Me.stbPrincipal.Name = "stbPrincipal"
        Me.stbPrincipal.Panels.AddRange(New System.Windows.Forms.StatusBarPanel() {Me.stsUsuario, Me.stsNombre, Me.stsArea, Me.stsFecha, Me.sbpServidor, Me.sbpBaseDeDatos})
        Me.stbPrincipal.ShowPanels = True
        Me.stbPrincipal.Size = New System.Drawing.Size(892, 24)
        Me.stbPrincipal.SizingGrip = False
        Me.stbPrincipal.TabIndex = 0
        '
        'stsUsuario
        '
        Me.stsUsuario.AutoSize = System.Windows.Forms.StatusBarPanelAutoSize.Spring
        Me.stsUsuario.Name = "stsUsuario"
        Me.stsUsuario.Text = "Usuario"
        Me.stsUsuario.ToolTipText = "Login de Usuario"
        Me.stsUsuario.Width = 244
        '
        'stsNombre
        '
        Me.stsNombre.Alignment = System.Windows.Forms.HorizontalAlignment.Center
        Me.stsNombre.AutoSize = System.Windows.Forms.StatusBarPanelAutoSize.Contents
        Me.stsNombre.Name = "stsNombre"
        Me.stsNombre.Text = "Nombre"
        Me.stsNombre.Width = 54
        '
        'stsArea
        '
        Me.stsArea.Alignment = System.Windows.Forms.HorizontalAlignment.Center
        Me.stsArea.AutoSize = System.Windows.Forms.StatusBarPanelAutoSize.Spring
        Me.stsArea.Name = "stsArea"
        Me.stsArea.Text = "Área"
        Me.stsArea.Width = 244
        '
        'stsFecha
        '
        Me.stsFecha.Alignment = System.Windows.Forms.HorizontalAlignment.Center
        Me.stsFecha.Name = "stsFecha"
        Me.stsFecha.Text = "Fecha"
        '
        'sbpServidor
        '
        Me.sbpServidor.Alignment = System.Windows.Forms.HorizontalAlignment.Center
        Me.sbpServidor.Icon = CType(resources.GetObject("sbpServidor.Icon"), System.Drawing.Icon)
        Me.sbpServidor.Name = "sbpServidor"
        Me.sbpServidor.Text = "Servidor"
        Me.sbpServidor.ToolTipText = "Nombre del servidor"
        Me.sbpServidor.Width = 150
        '
        'sbpBaseDeDatos
        '
        Me.sbpBaseDeDatos.Alignment = System.Windows.Forms.HorizontalAlignment.Center
        Me.sbpBaseDeDatos.Name = "sbpBaseDeDatos"
        Me.sbpBaseDeDatos.Text = "Base"
        Me.sbpBaseDeDatos.ToolTipText = "Nombre de la base de datos"
        '
        'imgHerramientas
        '
        Me.imgHerramientas.ImageStream = CType(resources.GetObject("imgHerramientas.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.imgHerramientas.TransparentColor = System.Drawing.Color.Transparent
        Me.imgHerramientas.Images.SetKeyName(0, "")
        Me.imgHerramientas.Images.SetKeyName(1, "")
        Me.imgHerramientas.Images.SetKeyName(2, "")
        Me.imgHerramientas.Images.SetKeyName(3, "")
        Me.imgHerramientas.Images.SetKeyName(4, "")
        Me.imgHerramientas.Images.SetKeyName(5, "")
        Me.imgHerramientas.Images.SetKeyName(6, "")
        Me.imgHerramientas.Images.SetKeyName(7, "")
        Me.imgHerramientas.Images.SetKeyName(8, "")
        Me.imgHerramientas.Images.SetKeyName(9, "setting_tools.png")
        '
        'tbHerramientas
        '
        Me.tbHerramientas.Appearance = System.Windows.Forms.ToolBarAppearance.Flat
        Me.tbHerramientas.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.tbHerramientas.Buttons.AddRange(New System.Windows.Forms.ToolBarButton() {Me.Sep0, Me.btnAsignacion, Me.btnAsignPortatil, Me.btnPullPostureros, Me.Sep1, Me.btnAutotanque, Me.Sep2, Me.btnRAF, Me.Sep6, Me.btnOperador, Me.Sep3, Me.btnLogisticos, Me.Sep3_1, Me.btnRuta, Me.Sep3_2, Me.btnPersonalizar, Me.Sep4, Me.btnSalir, Me.Sep5})
        Me.tbHerramientas.DropDownArrows = True
        Me.tbHerramientas.ImageList = Me.imgHerramientas
        Me.tbHerramientas.Location = New System.Drawing.Point(0, 0)
        Me.tbHerramientas.Name = "tbHerramientas"
        Me.tbHerramientas.ShowToolTips = True
        Me.tbHerramientas.Size = New System.Drawing.Size(892, 43)
        Me.tbHerramientas.TabIndex = 2
        '
        'Sep0
        '
        Me.Sep0.Name = "Sep0"
        Me.Sep0.Style = System.Windows.Forms.ToolBarButtonStyle.Separator
        '
        'btnAsignacion
        '
        Me.btnAsignacion.ImageIndex = 0
        Me.btnAsignacion.Name = "btnAsignacion"
        Me.btnAsignacion.Text = "Asignaciones"
        Me.btnAsignacion.ToolTipText = "Asignación diaria de autotanques."
        '
        'btnAsignPortatil
        '
        Me.btnAsignPortatil.ImageIndex = 7
        Me.btnAsignPortatil.Name = "btnAsignPortatil"
        Me.btnAsignPortatil.Tag = "AsignacionesPortatil"
        Me.btnAsignPortatil.Text = "Asign. Portatil"
        Me.btnAsignPortatil.Visible = False
        '
        'btnPullPostureros
        '
        Me.btnPullPostureros.ImageIndex = 8
        Me.btnPullPostureros.Name = "btnPullPostureros"
        Me.btnPullPostureros.Text = "Postureros"
        Me.btnPullPostureros.ToolTipText = "Asignacion de postureros"
        Me.btnPullPostureros.Visible = False
        '
        'Sep1
        '
        Me.Sep1.Name = "Sep1"
        Me.Sep1.Style = System.Windows.Forms.ToolBarButtonStyle.Separator
        '
        'btnAutotanque
        '
        Me.btnAutotanque.ImageIndex = 1
        Me.btnAutotanque.Name = "btnAutotanque"
        Me.btnAutotanque.Text = "Autotanques"
        Me.btnAutotanque.ToolTipText = "Catálogo de autotanques."
        '
        'Sep2
        '
        Me.Sep2.Name = "Sep2"
        Me.Sep2.Style = System.Windows.Forms.ToolBarButtonStyle.Separator
        '
        'btnRAF
        '
        Me.btnRAF.Enabled = False
        Me.btnRAF.ImageIndex = 9
        Me.btnRAF.Name = "btnRAF"
        Me.btnRAF.Text = "Auxilio y fallas"
        Me.btnRAF.ToolTipText = "Seguimiento de Auxilio y fallas"
        Me.btnRAF.Visible = False
        '
        'Sep6
        '
        Me.Sep6.Enabled = False
        Me.Sep6.Name = "Sep6"
        Me.Sep6.Style = System.Windows.Forms.ToolBarButtonStyle.Separator
        Me.Sep6.Visible = False
        '
        'btnOperador
        '
        Me.btnOperador.ImageIndex = 2
        Me.btnOperador.Name = "btnOperador"
        Me.btnOperador.Text = "Operadores"
        Me.btnOperador.ToolTipText = "Catalogo de operadores."
        '
        'Sep3
        '
        Me.Sep3.Name = "Sep3"
        Me.Sep3.Style = System.Windows.Forms.ToolBarButtonStyle.Separator
        '
        'btnLogisticos
        '
        Me.btnLogisticos.ImageIndex = 5
        Me.btnLogisticos.Name = "btnLogisticos"
        Me.btnLogisticos.Text = "Logísticos"
        Me.btnLogisticos.ToolTipText = "Catálogo de logísticos"
        Me.btnLogisticos.Visible = False
        '
        'Sep3_1
        '
        Me.Sep3_1.Name = "Sep3_1"
        Me.Sep3_1.Style = System.Windows.Forms.ToolBarButtonStyle.Separator
        Me.Sep3_1.Visible = False
        '
        'btnRuta
        '
        Me.btnRuta.ImageIndex = 6
        Me.btnRuta.Name = "btnRuta"
        Me.btnRuta.Text = "Rutas"
        Me.btnRuta.ToolTipText = "Catálogo de rutas"
        Me.btnRuta.Visible = False
        '
        'Sep3_2
        '
        Me.Sep3_2.Name = "Sep3_2"
        Me.Sep3_2.Style = System.Windows.Forms.ToolBarButtonStyle.Separator
        Me.Sep3_2.Visible = False
        '
        'btnPersonalizar
        '
        Me.btnPersonalizar.ImageIndex = 4
        Me.btnPersonalizar.Name = "btnPersonalizar"
        Me.btnPersonalizar.Text = "Personalizar"
        Me.btnPersonalizar.ToolTipText = "Ajustar colores y preferencias."
        '
        'Sep4
        '
        Me.Sep4.Name = "Sep4"
        Me.Sep4.Style = System.Windows.Forms.ToolBarButtonStyle.Separator
        '
        'btnSalir
        '
        Me.btnSalir.ImageIndex = 3
        Me.btnSalir.Name = "btnSalir"
        Me.btnSalir.Text = "Salir"
        Me.btnSalir.ToolTipText = "Salir del módulo de Logistica."
        '
        'Sep5
        '
        Me.Sep5.Name = "Sep5"
        Me.Sep5.Style = System.Windows.Forms.ToolBarButtonStyle.Separator
        '
        'MenuItem1
        '
        Me.MenuItem1.Index = -1
        Me.MenuItem1.Shortcut = System.Windows.Forms.Shortcut.CtrlN
        Me.MenuItem1.Text = "Tablero pa&nico"
        '
        'frmPrincipal
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 14)
        Me.BackColor = System.Drawing.Color.LightSteelBlue
        Me.ClientSize = New System.Drawing.Size(892, 547)
        Me.Controls.Add(Me.tbHerramientas)
        Me.Controls.Add(Me.stbPrincipal)
        Me.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ForeColor = System.Drawing.Color.DarkGoldenrod
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.IsMdiContainer = True
        Me.Menu = Me.mnuMain
        Me.Name = "frmPrincipal"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Modulo de Logística"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        CType(Me.stsUsuario, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.stsNombre, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.stsArea, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.stsFecha, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.sbpServidor, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.sbpBaseDeDatos, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

#End Region


    Dim WithEvents Inactivity As New Logistica.InactivityLock()


#Region "Activación de formularios"
    Private Sub CargaFormulario(ByVal NombreFormulario As String)
        Dim frm As Form
        Me.Cursor = Cursors.WaitCursor
        For Each frm In Me.MdiChildren
            If frm.Name = NombreFormulario Then
                frm.Focus()
                Me.Cursor = Cursors.Default
                Exit Sub
            End If
        Next
        Select Case NombreFormulario
            Case "frmAutotanque"
                frm = New frmAutotanque()
            Case "frmOperador"
                frm = New frmOperador()
            Case "frmAsignacion"
                frm = New frmAsignacion()
            Case "frmAsignacionPostureros"
                frm = New frmAsignacionPostureros()
            Case "frmLogistico"
                frm = New frmLogistico()
            Case "frmRuta"
                frm = New frmRuta()
            Case "frmFactorCliente"
                frm = New frmFactorCliente()
            Case "frmCatTripulacion"
                frm = New ComisionPortatil.frmCatTripulacion(_Usuario, _RutaReportes, _Servidor, _Database, _Password)
            Case "frmAsignacionPortatil"
                frm = New ComisionPortatil.frmComisionPortatilAsignacion(_Usuario)
            Case "frmFactorCliente"
                frm = New frmFactorCliente()
            Case "frmBitacoraAuxilios"
                BitacoraAutotanqueAuxilio.Public.Global.ConfiguraLibrary(SigametSeguridad.Seguridad.Conexion.ConnectionString, SigametSeguridad.Seguridad.Conexion, Globales._Usuario, 6, True)
                frm = New BitacoraAutotanqueAuxilio.Formas.frmBitacoraAuxilios()
                'frm.WindowState = FormWindowState.Maximized
            Case "frmUsuarioMovil"
                frm = New frmUsuarioMovil()
            Case Else
                ErrMessage("Esta acción no ha sido implementada.")
                Exit Sub
        End Select
        frm.MdiParent = Me
        Me.Cursor = Cursors.Default
        frm.Show()
    End Sub
    Private Sub mniAsignacionR_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mniAsignacionR.Click
        CargaFormulario("frmAsignacion")
    End Sub
    Private Sub mniAsignacionPortatil_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mniAsignacionPortatil.Click
        CargaFormulario("frmAsignacionPortatil")
    End Sub
    Private Sub mniAsignacionPostureros_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mniAsignacionPostureros.Click
        CargaFormulario("frmAsignacionPostureros")
    End Sub
    Private Sub mniAutotanque_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mniAutotanque.Click
        CargaFormulario("frmAutotanque")
    End Sub
    Private Sub mniOperador_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mniOperador.Click
        CargaFormulario("frmOperador")
    End Sub
    Private Sub mniLogistico_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mniLogistico.Click
        CargaFormulario("frmLogistico")
    End Sub
    Private Sub mniRuta_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mniRuta.Click
        CargaFormulario("frmRuta")
    End Sub
    Private Sub mniOperadorPortatil_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mniOperadorPortatil.Click
        CargaFormulario("frmCatTripulacion")
    End Sub
    Private Sub mniFactor_Click(sender As System.Object, e As System.EventArgs) Handles mniFactor.Click
        CargaFormulario("frmFactorCliente")
    End Sub
    Private Sub mnuAuxilioFallas_Click(sender As System.Object, e As System.EventArgs) Handles mnuAuxilioFallas.Click
        CargaFormulario("frmBitacoraAuxilios")
    End Sub
    Private Sub mniPersonalizar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mniPersonalizar.Click
        Personalizar()
    End Sub
    Private Sub mniAcercaDe_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mniAcercaDe.Click
        Dim frmAcerca As New frmAcerca()
        frmAcerca.ShowDialog()
    End Sub
    Private Sub tbHerramientas_ButtonClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.ToolBarButtonClickEventArgs) Handles tbHerramientas.ButtonClick
        Select Case e.Button.Text
            Case "Asignaciones"
                CargaFormulario("frmAsignacion")
            Case "Asign. Portatil"
                CargaFormulario("frmAsignacionPortatil")
            Case "Postureros"
                CargaFormulario("frmAsignacionPostureros")
            Case "Autotanques"
                CargaFormulario("frmAutotanque")
            Case "Operadores"
                CargaFormulario("frmOperador")
            Case "Logísticos"
                CargaFormulario("frmLogistico")
            Case "Rutas"
                CargaFormulario("frmRuta")
            Case "Personalizar"
                Personalizar()
            Case "Auxilio y fallas"
                CargaFormulario("frmBitacoraAuxilios")
            Case "Salir"
                Me.Close()
        End Select
    End Sub
#End Region

#Region "Reportes"
    Private Sub mnuReportes_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mniReportes.Click
        CargaReportes()
    End Sub
    Private Sub CargaReportes()
        Cursor = Cursors.WaitCursor

        Try
            'Dim oReportes As New ReporteDinamico.frmListaReporte(6, _RutaReportes, _Servidor, _Database, "", SigametSeguridad.Seguridad.Conexion, _Corporativo, _Sucursal, False)            
            Dim oReportes As New ReporteDinamico.frmListaReporte(6, _RutaReportes, _Servidor, _Database, _Usuario, SigametSeguridad.Seguridad.Conexion, _Corporativo, _Sucursal, _SeguridadReportes)
            oReportes.MdiParent = Me
            oReportes.WindowState = FormWindowState.Maximized
            oReportes.Show()
            Cursor = Cursors.Default

        Catch ex As Exception
            Throw ex
        End Try



    End Sub
#End Region

#Region "Inactividad"
    Private Sub Inactivity_Lock() Handles Inactivity.Lock
        Dim frmModuloBloqueado As New frmModuloBloqueado()
        Inactivity.Enabled = False
        Me.Enabled = False
        frmModuloBloqueado.ShowDialog()
        Inactivity.Enabled = True
        Me.Enabled = True
    End Sub
#End Region

#Region "Cerrado"
    Private Sub frmPrincipal_Closing(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles MyBase.Closing
        Application.DoEvents()
        If Me.MdiChildren.Length > 0 Then
            Dim frmOpen As Form
            If MessageBox.Show("Existen ventanas abiertas. " & Chr(13) & "¿Desea continuar cerrando el módulo?", Application.ProductName & " versión " & Application.ProductVersion, MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) = DialogResult.No Then
                e.Cancel = True
                Exit Sub
            End If
            For Each frmOpen In Me.MdiChildren
                frmOpen.Close()
            Next
            If Me.MdiChildren.Length > 0 Then
                e.Cancel = True
            Else
                Application.Exit()
            End If
        Else
            Application.Exit()
        End If
    End Sub
    Private Sub mniSalir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mniSalir.Click
        Me.Close()
    End Sub
#End Region

#Region "Personalización"
    Private Sub frmPrincipal_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Activated
        CargaConfiguracion()
    End Sub
    Public Sub CargaConfiguracion()
        Dim Settings As AppSettings
        If File.Exists(Application.StartupPath & "\" & System.Environment.UserName & ".Logistica.exe.config") Then
            Settings = New AppSettings(Application.StartupPath & "\" & System.Environment.UserName & ".Logistica.exe.config")
        Else
            Settings = New AppSettings(Application.StartupPath & "\" & "Default.Logistica.exe.config")
        End If
        'Me.BackColor = Color.FromArgb(CInt(Settings.GetSetting("frmPrincipal", "BackColor")))
        'Me.ForeColor = Color.FromArgb(CInt(Settings.GetSetting("frmPrincipal", "tbForeColor")))
        If CInt(Settings.GetSetting("frmPrincipal", "LockTime")) = 0 Then
            Inactivity.Enabled = False
        Else
            Inactivity.LockTime = CInt(Settings.GetSetting("frmPrincipal", "LockTime"))
            Inactivity.InactivityTime = 0
        End If
    End Sub
    Private Sub Personalizar()
        If Not Me.ActiveMdiChild Is Nothing Then
            Dim frmPersonalizar As New frmPersonalizar(Me.ActiveMdiChild.Name())
            frmPersonalizar.ShowDialog()
        Else
            Dim frmPersonalizar As New frmPersonalizar("frmPrincipal")
            frmPersonalizar.ShowDialog()
            CargaConfiguracion()
        End If
    End Sub
#End Region

    Private Sub frmPrincipal_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load

    End Sub

    Private Sub mniSoporteMovil_Click(sender As System.Object, e As System.EventArgs) Handles mniSoporteMovil.Click
        CargaFormulario("frmUsuarioMovil")
    End Sub

    Private Sub MenuItem1_Click(sender As System.Object, e As System.EventArgs) Handles mniTablero.Click, MenuItem1.Click
        Dim form As New TableroMonitorPanico
        form.ShowDialog()
    End Sub

    Private Sub mniMapas_Click(sender As System.Object, e As System.EventArgs) Handles mniMapas.Click
        Dim mapa As New MapaSoft.Runtime.Formularios.frmImportarGeocerca
        mapa.conexionGPS = Globales._ConexionGPS
        mapa.ShowDialog()
    End Sub
End Class
