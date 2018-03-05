Imports System
Imports System.Data.SqlClient
Imports System.IO
Imports Logistica


Public Class frmAsignacion
    Inherits System.Windows.Forms.Form


#Region " Windows Form Designer generated code "

    Public Sub New()
        MyBase.New()

        'This call is required by the Windows Form Designer.
        InitializeComponent()

        'Add any initialization after the InitializeComponent() call
        Dim cmdLogistica As New SqlClient.SqlCommand("Select TipoAsignacionAutotanque, Descripcion from TipoAsignacionAutotanque", cnSigamet)
        Dim daLogistica As New SqlClient.SqlDataAdapter(cmdLogistica)
        Dim dtCelula As New DataTable()
        Dim dtTipoASignacion As New DataTable()
        Dim dtProducto As New DataTable()
        Dim dtClaseRuta As New DataTable()
        'Asignación de fecha actual
        dtpFAsignacion.Value = Now.Date
        dsAsignacionInicial.Tables.Add("Folios")
        dsAsignacionInicial.Tables.Add("Operadores")
        dsDatosExtra.Tables.Add("empleadosSinAsignar")
        cmdLogistica.Parameters.Add("@Usuario", SqlDbType.Char).Value = _Usuario
        Try
            daLogistica.Fill(dtTipoASignacion)
            cmdLogistica.CommandText = "Select Celula, Descripcion from Celula where Comercial = 1 and Celula in (Select Celula from UsuarioCelula " _
                    & " where Usuario = @Usuario)"
            daLogistica.Fill(dtCelula)
            cmdLogistica.CommandText = "Select TipoProducto, Descripcion from TipoProducto where TipoProducto in (1,3)"
            daLogistica.Fill(dtProducto)

            cmdLogistica.CommandText = "exec spLogClaseRuta"
            daLogistica.Fill(dtClaseRuta)
        Catch ex As Exception
            ExMessage(ex)
        Finally
            cmdLogistica.Dispose()
            daLogistica.Dispose()
        End Try

        'Combo de tipo asignación (para captura en grid)
        cboTipoAsignacion.ValueMember = "TipoAsignacionAutotanque"
        cboTipoAsignacion.DisplayMember = "Descripcion"
        cboTipoAsignacion.DataSource = dtTipoASignacion

        'Combo de célula
        cboCelula.ValueMember = "Celula"
        cboCelula.DisplayMember = "Descripcion"
        cboCelula.DataSource = dtCelula
        cboCelula.SelectedValue = _Celula

        'Combo de producto
        cboProducto.ValueMember = "TipoProducto"
        cboProducto.DisplayMember = "Descripcion"
        cboProducto.DataSource = dtProducto

        'Cierres automáticos
        btnCerrarCiclo.Visible = OperacionLogistica(11).Habilitada
        mniCerrarCiclo.Visible = OperacionLogistica(11).Habilitada
        mniCerrarCiclo.Enabled = OperacionLogistica(11).Habilitada

        'Cancelación de ciclos
        btnCancelar.Visible = OperacionLogistica(15).Habilitada
        mniCancelar.Visible = OperacionLogistica(15).Habilitada
        mniCancelar.Enabled = OperacionLogistica(15).Habilitada
        Sep4.Visible = OperacionLogistica(15).Habilitada

        'Combo Clase ruta
        cboClaseRuta.ValueMember = "ClaseRuta"
        cboClaseRuta.DisplayMember = "Descripcion"
        cboClaseRuta.DataSource = dtClaseRuta        

        'Parametrizaciones
        If Not _MuestraAsistencia Then
            ReDim Preserve vgrdOperadores.HidedColumnNames(vgrdOperadores.HidedColumnNames.Length)
            ReDim Preserve vgrdEmpleadosSinAsignar.HidedColumnNames(vgrdEmpleadosSinAsignar.HidedColumnNames.Length)
            ReDim Preserve vgrdEmpleadosEnPrestamo.HidedColumnNames(vgrdEmpleadosEnPrestamo.HidedColumnNames.Length)
            ReDim Preserve vgrdEmpleadosPrestados.HidedColumnNames(vgrdEmpleadosPrestados.HidedColumnNames.Length)

            vgrdOperadores.HidedColumnNames(vgrdOperadores.HidedColumnNames.Length - 1) = "EnPlanta"
            vgrdEmpleadosSinAsignar.HidedColumnNames(vgrdEmpleadosSinAsignar.HidedColumnNames.Length - 1) = "EnPlanta"
            vgrdEmpleadosEnPrestamo.HidedColumnNames(vgrdEmpleadosEnPrestamo.HidedColumnNames.Length - 1) = "EnPlanta"
            vgrdEmpleadosPrestados.HidedColumnNames(vgrdEmpleadosPrestados.HidedColumnNames.Length - 1) = "EnPlanta"

        End If

        Me.ForeColor = Color.Black
        Loaded = True
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

    Friend WithEvents mnuAsignacion As System.Windows.Forms.MainMenu
    Friend WithEvents btnGenerar As System.Windows.Forms.ToolBarButton
    Friend WithEvents btnAsignar As System.Windows.Forms.ToolBarButton
    Friend WithEvents btnPrestamoOperador As System.Windows.Forms.ToolBarButton
    Friend WithEvents btnPrestamoAutotanque As System.Windows.Forms.ToolBarButton
    Friend WithEvents btnCancelar As System.Windows.Forms.ToolBarButton
    Friend WithEvents btnRuta As System.Windows.Forms.ToolBarButton
    Friend WithEvents btnBuscar As System.Windows.Forms.ToolBarButton
    Friend WithEvents btnCerrar As System.Windows.Forms.ToolBarButton
    Friend WithEvents imgHerramientas As System.Windows.Forms.ImageList
    Friend WithEvents Sep0 As System.Windows.Forms.ToolBarButton
    Friend WithEvents Sep1 As System.Windows.Forms.ToolBarButton
    Friend WithEvents Sep2 As System.Windows.Forms.ToolBarButton
    Friend WithEvents Sep3 As System.Windows.Forms.ToolBarButton
    Friend WithEvents Sep4 As System.Windows.Forms.ToolBarButton
    Friend WithEvents Sep5 As System.Windows.Forms.ToolBarButton
    Friend WithEvents Sep6 As System.Windows.Forms.ToolBarButton
    Friend WithEvents Sep7 As System.Windows.Forms.ToolBarButton
    Friend WithEvents lblFAsignacion As System.Windows.Forms.Label
    Friend WithEvents dtpFAsignacion As System.Windows.Forms.DateTimePicker
    Friend WithEvents lblCelula As System.Windows.Forms.Label
    Friend WithEvents cboCelula As System.Windows.Forms.ComboBox
    Friend WithEvents pnlOpciones As System.Windows.Forms.Panel
    Friend WithEvents pnlBase As System.Windows.Forms.Panel
    Friend WithEvents splGrids As System.Windows.Forms.Splitter
    Friend WithEvents mniAsignacion As System.Windows.Forms.MenuItem
    Friend WithEvents mniGenerar As System.Windows.Forms.MenuItem
    Friend WithEvents mniAsignar As System.Windows.Forms.MenuItem
    Friend WithEvents mniPrestamoOperador As System.Windows.Forms.MenuItem
    Friend WithEvents mniPrestamoAutotanque As System.Windows.Forms.MenuItem
    Friend WithEvents mniCancelar As System.Windows.Forms.MenuItem
    Friend WithEvents mniBuscar As System.Windows.Forms.MenuItem
    Friend WithEvents mniCerrar As System.Windows.Forms.MenuItem
    Friend WithEvents mniAsignacionR As System.Windows.Forms.MenuItem
    Friend WithEvents tbInicioRuta As System.Windows.Forms.ToolBar
    Friend WithEvents btnEditar As System.Windows.Forms.Button
    Friend WithEvents grpAttSinAsignar As System.Windows.Forms.GroupBox
    Friend WithEvents splDatosExtra As System.Windows.Forms.Splitter
    Friend WithEvents pnlDatosExtra As System.Windows.Forms.Panel
    Friend WithEvents rgpDatosExtra As Logistica.RoundedGroupBox
    Friend WithEvents pnlContenedor1 As System.Windows.Forms.Panel
    Friend WithEvents tabInformacion As System.Windows.Forms.TabControl
    Friend WithEvents tabAutotanquesSinAsignar As System.Windows.Forms.TabPage
    Friend WithEvents vgrdAutotanquesSinAsignar As Logistica.ViewGrid
    Friend WithEvents tabEmpleadosEnPrestamo As System.Windows.Forms.TabPage
    Friend WithEvents vgrdEmpleadosEnPrestamo As Logistica.ViewGrid
    Friend WithEvents tabAutotanquesEnPrestamo As System.Windows.Forms.TabPage
    Friend WithEvents vgrdAutotanquesEnPrestamo As Logistica.ViewGrid
    Friend WithEvents tabEmpleadosPrestados As System.Windows.Forms.TabPage
    Friend WithEvents vgrdEmpleadosPrestados As Logistica.ViewGrid
    Friend WithEvents tabAutotanquesPrestados As System.Windows.Forms.TabPage
    Friend WithEvents vgrdAutotanquesPrestados As Logistica.ViewGrid
    Friend WithEvents pnlOperadores As System.Windows.Forms.Panel
    Friend WithEvents vgrdOperadores As Logistica.ViewGrid
    Friend WithEvents lblOperadores As System.Windows.Forms.Label
    Friend WithEvents pnlEditarAutotanqueNA As System.Windows.Forms.Panel
    Friend WithEvents rgrpAutotanqueNA As Logistica.RoundedGroupBox
    Friend WithEvents btnEditarAutotanqueNA As System.Windows.Forms.Button
    Friend WithEvents grdFolios As System.Windows.Forms.DataGrid
    Friend WithEvents tabEmpleadosSinAsignar As System.Windows.Forms.TabPage
    Friend WithEvents vgrdEmpleadosSinAsignar As Logistica.ViewGrid
    Friend WithEvents btnEditarEmpleadosNA As System.Windows.Forms.Button
    Friend WithEvents rgrpEditarEmpleadorNA As Logistica.RoundedGroupBox
    Friend WithEvents pnlEditarEmpleadosNA As System.Windows.Forms.Panel
    Friend WithEvents btnEditaEmpleadoSinAsignar As System.Windows.Forms.Button
    Friend WithEvents rgrpEmpleadoSA As Logistica.RoundedGroupBox
    Friend WithEvents pnlDevuelveEmpleado As System.Windows.Forms.Panel
    Friend WithEvents rgrpDevuelveEmpleado As Logistica.RoundedGroupBox
    Friend WithEvents btnDevuelveEmpleado As System.Windows.Forms.Button
    Friend WithEvents pnlDevuelveOperador As System.Windows.Forms.Panel
    Friend WithEvents rgrpDevuelveAutotanque As Logistica.RoundedGroupBox
    Friend WithEvents btnDevuelveAutotanque As System.Windows.Forms.Button
    Friend WithEvents tbsFolio As System.Windows.Forms.DataGridTableStyle
    Friend WithEvents Folio As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents Autotanque As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents RutaAsignada As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents TipoAsignacion As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents RutaOriginal As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents Placas As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents StatusLogistica As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents FAsignacion As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents TipoVehiculo As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents cboTipoAsignacion As System.Windows.Forms.ComboBox
    Friend WithEvents mniActualizar As System.Windows.Forms.MenuItem
    Friend WithEvents btnActualizar As System.Windows.Forms.ToolBarButton
    Friend WithEvents ClaseRuta As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents cboProducto As System.Windows.Forms.ComboBox
    Friend WithEvents Producto As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents btnCerrarCiclo As System.Windows.Forms.ToolBarButton
    Friend WithEvents lblClaseRuta As System.Windows.Forms.Label
    Friend WithEvents cboClaseRuta As System.Windows.Forms.ComboBox
    Friend WithEvents DescripcionRutaAsignada As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents DescripcionRutaOriginal As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents mniCerrarCiclo As System.Windows.Forms.MenuItem
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmAsignacion))
        Me.mnuAsignacion = New System.Windows.Forms.MainMenu(Me.components)
        Me.mniAsignacion = New System.Windows.Forms.MenuItem()
        Me.mniAsignacionR = New System.Windows.Forms.MenuItem()
        Me.mniGenerar = New System.Windows.Forms.MenuItem()
        Me.mniAsignar = New System.Windows.Forms.MenuItem()
        Me.mniPrestamoOperador = New System.Windows.Forms.MenuItem()
        Me.mniPrestamoAutotanque = New System.Windows.Forms.MenuItem()
        Me.mniCerrarCiclo = New System.Windows.Forms.MenuItem()
        Me.mniBuscar = New System.Windows.Forms.MenuItem()
        Me.mniCancelar = New System.Windows.Forms.MenuItem()
        Me.mniActualizar = New System.Windows.Forms.MenuItem()
        Me.mniCerrar = New System.Windows.Forms.MenuItem()
        Me.tbInicioRuta = New System.Windows.Forms.ToolBar()
        Me.Sep0 = New System.Windows.Forms.ToolBarButton()
        Me.btnGenerar = New System.Windows.Forms.ToolBarButton()
        Me.btnAsignar = New System.Windows.Forms.ToolBarButton()
        Me.Sep1 = New System.Windows.Forms.ToolBarButton()
        Me.btnPrestamoOperador = New System.Windows.Forms.ToolBarButton()
        Me.btnPrestamoAutotanque = New System.Windows.Forms.ToolBarButton()
        Me.Sep2 = New System.Windows.Forms.ToolBarButton()
        Me.btnCerrarCiclo = New System.Windows.Forms.ToolBarButton()
        Me.btnRuta = New System.Windows.Forms.ToolBarButton()
        Me.Sep3 = New System.Windows.Forms.ToolBarButton()
        Me.btnCancelar = New System.Windows.Forms.ToolBarButton()
        Me.Sep4 = New System.Windows.Forms.ToolBarButton()
        Me.btnBuscar = New System.Windows.Forms.ToolBarButton()
        Me.Sep5 = New System.Windows.Forms.ToolBarButton()
        Me.btnActualizar = New System.Windows.Forms.ToolBarButton()
        Me.Sep6 = New System.Windows.Forms.ToolBarButton()
        Me.btnCerrar = New System.Windows.Forms.ToolBarButton()
        Me.Sep7 = New System.Windows.Forms.ToolBarButton()
        Me.imgHerramientas = New System.Windows.Forms.ImageList(Me.components)
        Me.lblFAsignacion = New System.Windows.Forms.Label()
        Me.dtpFAsignacion = New System.Windows.Forms.DateTimePicker()
        Me.lblCelula = New System.Windows.Forms.Label()
        Me.cboCelula = New System.Windows.Forms.ComboBox()
        Me.pnlOpciones = New System.Windows.Forms.Panel()
        Me.lblClaseRuta = New System.Windows.Forms.Label()
        Me.cboClaseRuta = New System.Windows.Forms.ComboBox()
        Me.cboTipoAsignacion = New System.Windows.Forms.ComboBox()
        Me.pnlBase = New System.Windows.Forms.Panel()
        Me.splGrids = New System.Windows.Forms.Splitter()
        Me.btnEditar = New System.Windows.Forms.Button()
        Me.grpAttSinAsignar = New System.Windows.Forms.GroupBox()
        Me.splDatosExtra = New System.Windows.Forms.Splitter()
        Me.pnlDatosExtra = New System.Windows.Forms.Panel()
        Me.rgpDatosExtra = New Logistica.RoundedGroupBox()
        Me.pnlContenedor1 = New System.Windows.Forms.Panel()
        Me.tabInformacion = New System.Windows.Forms.TabControl()
        Me.tabEmpleadosSinAsignar = New System.Windows.Forms.TabPage()
        Me.vgrdEmpleadosSinAsignar = New Logistica.ViewGrid()
        Me.pnlEditarEmpleadosNA = New System.Windows.Forms.Panel()
        Me.rgrpEmpleadoSA = New Logistica.RoundedGroupBox()
        Me.btnEditaEmpleadoSinAsignar = New System.Windows.Forms.Button()
        Me.tabAutotanquesSinAsignar = New System.Windows.Forms.TabPage()
        Me.vgrdAutotanquesSinAsignar = New Logistica.ViewGrid()
        Me.pnlEditarAutotanqueNA = New System.Windows.Forms.Panel()
        Me.rgrpAutotanqueNA = New Logistica.RoundedGroupBox()
        Me.btnEditarAutotanqueNA = New System.Windows.Forms.Button()
        Me.tabEmpleadosEnPrestamo = New System.Windows.Forms.TabPage()
        Me.vgrdEmpleadosEnPrestamo = New Logistica.ViewGrid()
        Me.tabAutotanquesEnPrestamo = New System.Windows.Forms.TabPage()
        Me.vgrdAutotanquesEnPrestamo = New Logistica.ViewGrid()
        Me.tabEmpleadosPrestados = New System.Windows.Forms.TabPage()
        Me.vgrdEmpleadosPrestados = New Logistica.ViewGrid()
        Me.pnlDevuelveEmpleado = New System.Windows.Forms.Panel()
        Me.rgrpDevuelveEmpleado = New Logistica.RoundedGroupBox()
        Me.btnDevuelveEmpleado = New System.Windows.Forms.Button()
        Me.tabAutotanquesPrestados = New System.Windows.Forms.TabPage()
        Me.vgrdAutotanquesPrestados = New Logistica.ViewGrid()
        Me.pnlDevuelveOperador = New System.Windows.Forms.Panel()
        Me.rgrpDevuelveAutotanque = New Logistica.RoundedGroupBox()
        Me.btnDevuelveAutotanque = New System.Windows.Forms.Button()
        Me.pnlOperadores = New System.Windows.Forms.Panel()
        Me.vgrdOperadores = New Logistica.ViewGrid()
        Me.lblOperadores = New System.Windows.Forms.Label()
        Me.grdFolios = New System.Windows.Forms.DataGrid()
        Me.tbsFolio = New System.Windows.Forms.DataGridTableStyle()
        Me.Folio = New System.Windows.Forms.DataGridTextBoxColumn()
        Me.Autotanque = New System.Windows.Forms.DataGridTextBoxColumn()
        Me.RutaAsignada = New System.Windows.Forms.DataGridTextBoxColumn()
        Me.DescripcionRutaAsignada = New System.Windows.Forms.DataGridTextBoxColumn()
        Me.ClaseRuta = New System.Windows.Forms.DataGridTextBoxColumn()
        Me.TipoAsignacion = New System.Windows.Forms.DataGridTextBoxColumn()
        Me.Producto = New System.Windows.Forms.DataGridTextBoxColumn()
        Me.RutaOriginal = New System.Windows.Forms.DataGridTextBoxColumn()
        Me.DescripcionRutaOriginal = New System.Windows.Forms.DataGridTextBoxColumn()
        Me.Placas = New System.Windows.Forms.DataGridTextBoxColumn()
        Me.StatusLogistica = New System.Windows.Forms.DataGridTextBoxColumn()
        Me.FAsignacion = New System.Windows.Forms.DataGridTextBoxColumn()
        Me.TipoVehiculo = New System.Windows.Forms.DataGridTextBoxColumn()
        Me.btnEditarEmpleadosNA = New System.Windows.Forms.Button()
        Me.rgrpEditarEmpleadorNA = New Logistica.RoundedGroupBox()
        Me.cboProducto = New System.Windows.Forms.ComboBox()
        Me.pnlOpciones.SuspendLayout()
        Me.pnlDatosExtra.SuspendLayout()
        Me.rgpDatosExtra.SuspendLayout()
        Me.pnlContenedor1.SuspendLayout()
        Me.tabInformacion.SuspendLayout()
        Me.tabEmpleadosSinAsignar.SuspendLayout()
        Me.pnlEditarEmpleadosNA.SuspendLayout()
        Me.rgrpEmpleadoSA.SuspendLayout()
        Me.tabAutotanquesSinAsignar.SuspendLayout()
        Me.pnlEditarAutotanqueNA.SuspendLayout()
        Me.rgrpAutotanqueNA.SuspendLayout()
        Me.tabEmpleadosEnPrestamo.SuspendLayout()
        Me.tabAutotanquesEnPrestamo.SuspendLayout()
        Me.tabEmpleadosPrestados.SuspendLayout()
        Me.pnlDevuelveEmpleado.SuspendLayout()
        Me.rgrpDevuelveEmpleado.SuspendLayout()
        Me.tabAutotanquesPrestados.SuspendLayout()
        Me.pnlDevuelveOperador.SuspendLayout()
        Me.rgrpDevuelveAutotanque.SuspendLayout()
        Me.pnlOperadores.SuspendLayout()
        CType(Me.grdFolios, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'mnuAsignacion
        '
        Me.mnuAsignacion.MenuItems.AddRange(New System.Windows.Forms.MenuItem() {Me.mniAsignacion})
        '
        'mniAsignacion
        '
        Me.mniAsignacion.Index = 0
        Me.mniAsignacion.MenuItems.AddRange(New System.Windows.Forms.MenuItem() {Me.mniAsignacionR})
        Me.mniAsignacion.MergeOrder = 1
        Me.mniAsignacion.MergeType = System.Windows.Forms.MenuMerge.MergeItems
        Me.mniAsignacion.Text = "&Asignación"
        '
        'mniAsignacionR
        '
        Me.mniAsignacionR.Index = 0
        Me.mniAsignacionR.MenuItems.AddRange(New System.Windows.Forms.MenuItem() {Me.mniGenerar, Me.mniAsignar, Me.mniPrestamoOperador, Me.mniPrestamoAutotanque, Me.mniCerrarCiclo, Me.mniBuscar, Me.mniCancelar, Me.mniActualizar, Me.mniCerrar})
        Me.mniAsignacionR.MergeType = System.Windows.Forms.MenuMerge.MergeItems
        Me.mniAsignacionR.Text = "&Asignación"
        '
        'mniGenerar
        '
        Me.mniGenerar.Index = 0
        Me.mniGenerar.Shortcut = System.Windows.Forms.Shortcut.CtrlG
        Me.mniGenerar.Text = "&Generar"
        '
        'mniAsignar
        '
        Me.mniAsignar.Index = 1
        Me.mniAsignar.Shortcut = System.Windows.Forms.Shortcut.Ins
        Me.mniAsignar.Text = "&Asignar"
        '
        'mniPrestamoOperador
        '
        Me.mniPrestamoOperador.Index = 2
        Me.mniPrestamoOperador.Text = "Prestamo de &operadores"
        '
        'mniPrestamoAutotanque
        '
        Me.mniPrestamoAutotanque.Index = 3
        Me.mniPrestamoAutotanque.Text = "Prestamo de au&totanques"
        '
        'mniCerrarCiclo
        '
        Me.mniCerrarCiclo.Enabled = False
        Me.mniCerrarCiclo.Index = 4
        Me.mniCerrarCiclo.Text = "Ce&rrar ciclo"
        Me.mniCerrarCiclo.Visible = False
        '
        'mniBuscar
        '
        Me.mniBuscar.Index = 5
        Me.mniBuscar.Shortcut = System.Windows.Forms.Shortcut.CtrlB
        Me.mniBuscar.Text = "&Buscar"
        '
        'mniCancelar
        '
        Me.mniCancelar.Index = 6
        Me.mniCancelar.Text = "Cancela&r"
        '
        'mniActualizar
        '
        Me.mniActualizar.Index = 7
        Me.mniActualizar.Shortcut = System.Windows.Forms.Shortcut.F5
        Me.mniActualizar.Text = "Ac&tualizar"
        '
        'mniCerrar
        '
        Me.mniCerrar.Index = 8
        Me.mniCerrar.Text = "&Cerrar"
        '
        'tbInicioRuta
        '
        Me.tbInicioRuta.Appearance = System.Windows.Forms.ToolBarAppearance.Flat
        Me.tbInicioRuta.Buttons.AddRange(New System.Windows.Forms.ToolBarButton() {Me.Sep0, Me.btnGenerar, Me.btnAsignar, Me.Sep1, Me.btnPrestamoOperador, Me.btnPrestamoAutotanque, Me.Sep2, Me.btnCerrarCiclo, Me.btnRuta, Me.Sep3, Me.btnCancelar, Me.Sep4, Me.btnBuscar, Me.Sep5, Me.btnActualizar, Me.Sep6, Me.btnCerrar, Me.Sep7})
        Me.tbInicioRuta.ButtonSize = New System.Drawing.Size(64, 36)
        Me.tbInicioRuta.DropDownArrows = True
        Me.tbInicioRuta.ImageList = Me.imgHerramientas
        Me.tbInicioRuta.Location = New System.Drawing.Point(0, 0)
        Me.tbInicioRuta.Name = "tbInicioRuta"
        Me.tbInicioRuta.ShowToolTips = True
        Me.tbInicioRuta.Size = New System.Drawing.Size(1176, 42)
        Me.tbInicioRuta.TabIndex = 0
        '
        'Sep0
        '
        Me.Sep0.Name = "Sep0"
        Me.Sep0.Style = System.Windows.Forms.ToolBarButtonStyle.Separator
        '
        'btnGenerar
        '
        Me.btnGenerar.ImageIndex = 0
        Me.btnGenerar.Name = "btnGenerar"
        Me.btnGenerar.Text = "Generar"
        Me.btnGenerar.ToolTipText = "Copia la asignación de alguna fecha anterior"
        '
        'btnAsignar
        '
        Me.btnAsignar.ImageIndex = 1
        Me.btnAsignar.Name = "btnAsignar"
        Me.btnAsignar.Text = "Asignar"
        Me.btnAsignar.ToolTipText = "Modifica la asignación"
        '
        'Sep1
        '
        Me.Sep1.Name = "Sep1"
        Me.Sep1.Style = System.Windows.Forms.ToolBarButtonStyle.Separator
        '
        'btnPrestamoOperador
        '
        Me.btnPrestamoOperador.ImageIndex = 2
        Me.btnPrestamoOperador.Name = "btnPrestamoOperador"
        Me.btnPrestamoOperador.Text = "Prestamo op"
        Me.btnPrestamoOperador.ToolTipText = "Reasigna empleados a célula"
        '
        'btnPrestamoAutotanque
        '
        Me.btnPrestamoAutotanque.ImageIndex = 3
        Me.btnPrestamoAutotanque.Name = "btnPrestamoAutotanque"
        Me.btnPrestamoAutotanque.Text = "Prestamo att"
        Me.btnPrestamoAutotanque.ToolTipText = "Reasigna autotanques a célula"
        '
        'Sep2
        '
        Me.Sep2.Name = "Sep2"
        Me.Sep2.Style = System.Windows.Forms.ToolBarButtonStyle.Separator
        '
        'btnCerrarCiclo
        '
        Me.btnCerrarCiclo.ImageIndex = 11
        Me.btnCerrarCiclo.Name = "btnCerrarCiclo"
        Me.btnCerrarCiclo.Text = "Cerrar ciclo"
        Me.btnCerrarCiclo.ToolTipText = "Cerrar el cilco automáticamente"
        Me.btnCerrarCiclo.Visible = False
        '
        'btnRuta
        '
        Me.btnRuta.ImageIndex = 5
        Me.btnRuta.Name = "btnRuta"
        Me.btnRuta.Text = "Ruta"
        Me.btnRuta.ToolTipText = "Cambio y asignación de ruta"
        '
        'Sep3
        '
        Me.Sep3.Name = "Sep3"
        Me.Sep3.Style = System.Windows.Forms.ToolBarButtonStyle.Separator
        '
        'btnCancelar
        '
        Me.btnCancelar.ImageIndex = 6
        Me.btnCancelar.Name = "btnCancelar"
        Me.btnCancelar.Text = "Cancelar"
        Me.btnCancelar.ToolTipText = "Cancelar la salida del autotanque"
        '
        'Sep4
        '
        Me.Sep4.Name = "Sep4"
        Me.Sep4.Style = System.Windows.Forms.ToolBarButtonStyle.Separator
        '
        'btnBuscar
        '
        Me.btnBuscar.ImageIndex = 7
        Me.btnBuscar.Name = "btnBuscar"
        Me.btnBuscar.Text = "Buscar"
        Me.btnBuscar.ToolTipText = "Busca un registro"
        '
        'Sep5
        '
        Me.Sep5.Name = "Sep5"
        Me.Sep5.Style = System.Windows.Forms.ToolBarButtonStyle.Separator
        '
        'btnActualizar
        '
        Me.btnActualizar.ImageIndex = 8
        Me.btnActualizar.Name = "btnActualizar"
        Me.btnActualizar.Text = "Actualizar"
        Me.btnActualizar.ToolTipText = "Actualiza los datos"
        '
        'Sep6
        '
        Me.Sep6.Name = "Sep6"
        Me.Sep6.Style = System.Windows.Forms.ToolBarButtonStyle.Separator
        '
        'btnCerrar
        '
        Me.btnCerrar.ImageIndex = 9
        Me.btnCerrar.Name = "btnCerrar"
        Me.btnCerrar.Text = "Cerrar"
        Me.btnCerrar.ToolTipText = "Cerrar la ventana de asignación"
        '
        'Sep7
        '
        Me.Sep7.Name = "Sep7"
        Me.Sep7.Style = System.Windows.Forms.ToolBarButtonStyle.Separator
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
        Me.imgHerramientas.Images.SetKeyName(9, "")
        Me.imgHerramientas.Images.SetKeyName(10, "")
        Me.imgHerramientas.Images.SetKeyName(11, "")
        '
        'lblFAsignacion
        '
        Me.lblFAsignacion.AutoSize = True
        Me.lblFAsignacion.Location = New System.Drawing.Point(200, 8)
        Me.lblFAsignacion.Name = "lblFAsignacion"
        Me.lblFAsignacion.Size = New System.Drawing.Size(40, 13)
        Me.lblFAsignacion.TabIndex = 1
        Me.lblFAsignacion.Text = "&Fecha:"
        '
        'dtpFAsignacion
        '
        Me.dtpFAsignacion.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpFAsignacion.Location = New System.Drawing.Point(244, 5)
        Me.dtpFAsignacion.MinDate = New Date(1999, 1, 1, 0, 0, 0, 0)
        Me.dtpFAsignacion.Name = "dtpFAsignacion"
        Me.dtpFAsignacion.Size = New System.Drawing.Size(121, 21)
        Me.dtpFAsignacion.TabIndex = 2
        '
        'lblCelula
        '
        Me.lblCelula.AutoSize = True
        Me.lblCelula.Location = New System.Drawing.Point(8, 8)
        Me.lblCelula.Name = "lblCelula"
        Me.lblCelula.Size = New System.Drawing.Size(40, 13)
        Me.lblCelula.TabIndex = 105
        Me.lblCelula.Text = "&Célula:"
        '
        'cboCelula
        '
        Me.cboCelula.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboCelula.Location = New System.Drawing.Point(56, 5)
        Me.cboCelula.Name = "cboCelula"
        Me.cboCelula.Size = New System.Drawing.Size(120, 21)
        Me.cboCelula.TabIndex = 106
        '
        'pnlOpciones
        '
        Me.pnlOpciones.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.pnlOpciones.Controls.Add(Me.lblClaseRuta)
        Me.pnlOpciones.Controls.Add(Me.cboClaseRuta)
        Me.pnlOpciones.Controls.Add(Me.lblCelula)
        Me.pnlOpciones.Controls.Add(Me.lblFAsignacion)
        Me.pnlOpciones.Controls.Add(Me.cboCelula)
        Me.pnlOpciones.Controls.Add(Me.dtpFAsignacion)
        Me.pnlOpciones.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnlOpciones.Location = New System.Drawing.Point(0, 42)
        Me.pnlOpciones.Name = "pnlOpciones"
        Me.pnlOpciones.Size = New System.Drawing.Size(1176, 33)
        Me.pnlOpciones.TabIndex = 107
        '
        'lblClaseRuta
        '
        Me.lblClaseRuta.AutoSize = True
        Me.lblClaseRuta.Location = New System.Drawing.Point(404, 8)
        Me.lblClaseRuta.Name = "lblClaseRuta"
        Me.lblClaseRuta.Size = New System.Drawing.Size(63, 13)
        Me.lblClaseRuta.TabIndex = 108
        Me.lblClaseRuta.Text = "Cla&se Ruta:"
        '
        'cboClaseRuta
        '
        Me.cboClaseRuta.Enabled = False
        Me.cboClaseRuta.FormattingEnabled = True
        Me.cboClaseRuta.Location = New System.Drawing.Point(473, 5)
        Me.cboClaseRuta.Name = "cboClaseRuta"
        Me.cboClaseRuta.Size = New System.Drawing.Size(121, 21)
        Me.cboClaseRuta.TabIndex = 107
        '
        'cboTipoAsignacion
        '
        Me.cboTipoAsignacion.BackColor = System.Drawing.Color.WhiteSmoke
        Me.cboTipoAsignacion.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboTipoAsignacion.Location = New System.Drawing.Point(1048, 80)
        Me.cboTipoAsignacion.Name = "cboTipoAsignacion"
        Me.cboTipoAsignacion.Size = New System.Drawing.Size(121, 21)
        Me.cboTipoAsignacion.TabIndex = 107
        Me.cboTipoAsignacion.Visible = False
        '
        'pnlBase
        '
        Me.pnlBase.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.pnlBase.Location = New System.Drawing.Point(0, 669)
        Me.pnlBase.Name = "pnlBase"
        Me.pnlBase.Size = New System.Drawing.Size(1176, 8)
        Me.pnlBase.TabIndex = 108
        '
        'splGrids
        '
        Me.splGrids.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.splGrids.Location = New System.Drawing.Point(0, 387)
        Me.splGrids.Name = "splGrids"
        Me.splGrids.Size = New System.Drawing.Size(1176, 3)
        Me.splGrids.TabIndex = 111
        Me.splGrids.TabStop = False
        '
        'btnEditar
        '
        Me.btnEditar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnEditar.ImageList = Me.imgHerramientas
        Me.btnEditar.Location = New System.Drawing.Point(5, 14)
        Me.btnEditar.Name = "btnEditar"
        Me.btnEditar.Size = New System.Drawing.Size(75, 23)
        Me.btnEditar.TabIndex = 0
        Me.btnEditar.Text = "Editar"
        Me.btnEditar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'grpAttSinAsignar
        '
        Me.grpAttSinAsignar.Dock = System.Windows.Forms.DockStyle.Right
        Me.grpAttSinAsignar.Location = New System.Drawing.Point(962, 0)
        Me.grpAttSinAsignar.Name = "grpAttSinAsignar"
        Me.grpAttSinAsignar.Size = New System.Drawing.Size(200, 151)
        Me.grpAttSinAsignar.TabIndex = 2
        Me.grpAttSinAsignar.TabStop = False
        '
        'splDatosExtra
        '
        Me.splDatosExtra.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.splDatosExtra.Location = New System.Drawing.Point(0, 490)
        Me.splDatosExtra.Name = "splDatosExtra"
        Me.splDatosExtra.Size = New System.Drawing.Size(1176, 3)
        Me.splDatosExtra.TabIndex = 112
        Me.splDatosExtra.TabStop = False
        '
        'pnlDatosExtra
        '
        Me.pnlDatosExtra.Controls.Add(Me.rgpDatosExtra)
        Me.pnlDatosExtra.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.pnlDatosExtra.Location = New System.Drawing.Point(0, 493)
        Me.pnlDatosExtra.Name = "pnlDatosExtra"
        Me.pnlDatosExtra.Padding = New System.Windows.Forms.Padding(5)
        Me.pnlDatosExtra.Size = New System.Drawing.Size(1176, 176)
        Me.pnlDatosExtra.TabIndex = 113
        '
        'rgpDatosExtra
        '
        Me.rgpDatosExtra.BorderColor = System.Drawing.Color.Gray
        Me.rgpDatosExtra.Controls.Add(Me.pnlContenedor1)
        Me.rgpDatosExtra.Dock = System.Windows.Forms.DockStyle.Fill
        Me.rgpDatosExtra.Location = New System.Drawing.Point(5, 5)
        Me.rgpDatosExtra.Name = "rgpDatosExtra"
        Me.rgpDatosExtra.Size = New System.Drawing.Size(1166, 166)
        Me.rgpDatosExtra.TabIndex = 108
        Me.rgpDatosExtra.TabStop = False
        '
        'pnlContenedor1
        '
        Me.pnlContenedor1.Controls.Add(Me.tabInformacion)
        Me.pnlContenedor1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pnlContenedor1.Location = New System.Drawing.Point(3, 17)
        Me.pnlContenedor1.Name = "pnlContenedor1"
        Me.pnlContenedor1.Padding = New System.Windows.Forms.Padding(5)
        Me.pnlContenedor1.Size = New System.Drawing.Size(1160, 146)
        Me.pnlContenedor1.TabIndex = 113
        '
        'tabInformacion
        '
        Me.tabInformacion.Appearance = System.Windows.Forms.TabAppearance.FlatButtons
        Me.tabInformacion.Controls.Add(Me.tabEmpleadosSinAsignar)
        Me.tabInformacion.Controls.Add(Me.tabAutotanquesSinAsignar)
        Me.tabInformacion.Controls.Add(Me.tabEmpleadosEnPrestamo)
        Me.tabInformacion.Controls.Add(Me.tabAutotanquesEnPrestamo)
        Me.tabInformacion.Controls.Add(Me.tabEmpleadosPrestados)
        Me.tabInformacion.Controls.Add(Me.tabAutotanquesPrestados)
        Me.tabInformacion.Dock = System.Windows.Forms.DockStyle.Fill
        Me.tabInformacion.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tabInformacion.ItemSize = New System.Drawing.Size(117, 21)
        Me.tabInformacion.Location = New System.Drawing.Point(5, 5)
        Me.tabInformacion.Multiline = True
        Me.tabInformacion.Name = "tabInformacion"
        Me.tabInformacion.SelectedIndex = 0
        Me.tabInformacion.ShowToolTips = True
        Me.tabInformacion.Size = New System.Drawing.Size(1150, 136)
        Me.tabInformacion.TabIndex = 99
        '
        'tabEmpleadosSinAsignar
        '
        Me.tabEmpleadosSinAsignar.BackColor = System.Drawing.Color.Gainsboro
        Me.tabEmpleadosSinAsignar.Controls.Add(Me.vgrdEmpleadosSinAsignar)
        Me.tabEmpleadosSinAsignar.Controls.Add(Me.pnlEditarEmpleadosNA)
        Me.tabEmpleadosSinAsignar.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tabEmpleadosSinAsignar.ForeColor = System.Drawing.Color.Black
        Me.tabEmpleadosSinAsignar.Location = New System.Drawing.Point(4, 25)
        Me.tabEmpleadosSinAsignar.Name = "tabEmpleadosSinAsignar"
        Me.tabEmpleadosSinAsignar.Size = New System.Drawing.Size(1142, 107)
        Me.tabEmpleadosSinAsignar.TabIndex = 6
        Me.tabEmpleadosSinAsignar.Text = "Empleados sin asignar"
        Me.tabEmpleadosSinAsignar.ToolTipText = "Empleados sin asignar a ruta"
        '
        'vgrdEmpleadosSinAsignar
        '
        Me.vgrdEmpleadosSinAsignar.AlternativeBackColor = System.Drawing.Color.Gainsboro        
        Me.vgrdEmpleadosSinAsignar.CheckCondition = Nothing
        Me.vgrdEmpleadosSinAsignar.DataSource = Nothing
        Me.vgrdEmpleadosSinAsignar.Dock = System.Windows.Forms.DockStyle.Fill
        Me.vgrdEmpleadosSinAsignar.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.vgrdEmpleadosSinAsignar.FullRowSelect = True
        Me.vgrdEmpleadosSinAsignar.GridLines = True
        Me.vgrdEmpleadosSinAsignar.HidedColumnNames = New String(-1) {}
        Me.vgrdEmpleadosSinAsignar.Location = New System.Drawing.Point(0, 0)
        Me.vgrdEmpleadosSinAsignar.MultiSelect = False
        Me.vgrdEmpleadosSinAsignar.Name = "vgrdEmpleadosSinAsignar"
        Me.vgrdEmpleadosSinAsignar.PKColumnNames = Nothing
        Me.vgrdEmpleadosSinAsignar.Size = New System.Drawing.Size(1038, 107)
        Me.vgrdEmpleadosSinAsignar.TabIndex = 1
        Me.vgrdEmpleadosSinAsignar.UseCompatibleStateImageBehavior = False
        Me.vgrdEmpleadosSinAsignar.View = System.Windows.Forms.View.Details
        '
        'pnlEditarEmpleadosNA
        '
        Me.pnlEditarEmpleadosNA.BackColor = System.Drawing.Color.Gainsboro
        Me.pnlEditarEmpleadosNA.Controls.Add(Me.rgrpEmpleadoSA)
        Me.pnlEditarEmpleadosNA.Dock = System.Windows.Forms.DockStyle.Right
        Me.pnlEditarEmpleadosNA.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.pnlEditarEmpleadosNA.ForeColor = System.Drawing.SystemColors.ControlText
        Me.pnlEditarEmpleadosNA.Location = New System.Drawing.Point(1038, 0)
        Me.pnlEditarEmpleadosNA.Name = "pnlEditarEmpleadosNA"
        Me.pnlEditarEmpleadosNA.Padding = New System.Windows.Forms.Padding(5)
        Me.pnlEditarEmpleadosNA.Size = New System.Drawing.Size(104, 107)
        Me.pnlEditarEmpleadosNA.TabIndex = 2
        '
        'rgrpEmpleadoSA
        '
        Me.rgrpEmpleadoSA.BorderColor = System.Drawing.Color.Gainsboro
        Me.rgrpEmpleadoSA.Controls.Add(Me.btnEditaEmpleadoSinAsignar)
        Me.rgrpEmpleadoSA.Dock = System.Windows.Forms.DockStyle.Fill
        Me.rgrpEmpleadoSA.FlatStyle = Logistica.RoundedGroupBox.Style.Road
        Me.rgrpEmpleadoSA.Location = New System.Drawing.Point(5, 5)
        Me.rgrpEmpleadoSA.Name = "rgrpEmpleadoSA"
        Me.rgrpEmpleadoSA.Size = New System.Drawing.Size(94, 97)
        Me.rgrpEmpleadoSA.TabIndex = 1
        Me.rgrpEmpleadoSA.TabStop = False
        '
        'btnEditaEmpleadoSinAsignar
        '
        Me.btnEditaEmpleadoSinAsignar.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnEditaEmpleadoSinAsignar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnEditaEmpleadoSinAsignar.ImageIndex = 10
        Me.btnEditaEmpleadoSinAsignar.ImageList = Me.imgHerramientas
        Me.btnEditaEmpleadoSinAsignar.Location = New System.Drawing.Point(8, 24)
        Me.btnEditaEmpleadoSinAsignar.Name = "btnEditaEmpleadoSinAsignar"
        Me.btnEditaEmpleadoSinAsignar.Size = New System.Drawing.Size(75, 23)
        Me.btnEditaEmpleadoSinAsignar.TabIndex = 114
        Me.btnEditaEmpleadoSinAsignar.Text = "Editar"
        Me.btnEditaEmpleadoSinAsignar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'tabAutotanquesSinAsignar
        '
        Me.tabAutotanquesSinAsignar.BackColor = System.Drawing.Color.Gainsboro
        Me.tabAutotanquesSinAsignar.Controls.Add(Me.vgrdAutotanquesSinAsignar)
        Me.tabAutotanquesSinAsignar.Controls.Add(Me.pnlEditarAutotanqueNA)
        Me.tabAutotanquesSinAsignar.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tabAutotanquesSinAsignar.Location = New System.Drawing.Point(4, 25)
        Me.tabAutotanquesSinAsignar.Name = "tabAutotanquesSinAsignar"
        Me.tabAutotanquesSinAsignar.Size = New System.Drawing.Size(1142, 108)
        Me.tabAutotanquesSinAsignar.TabIndex = 7
        Me.tabAutotanquesSinAsignar.Text = "Autotanques sin asignar"
        Me.tabAutotanquesSinAsignar.ToolTipText = "Autotanques sin asignar a ruta"
        Me.tabAutotanquesSinAsignar.Visible = False
        '
        'vgrdAutotanquesSinAsignar
        '
        Me.vgrdAutotanquesSinAsignar.AlternativeBackColor = System.Drawing.Color.Gainsboro        
        Me.vgrdAutotanquesSinAsignar.CheckCondition = Nothing
        Me.vgrdAutotanquesSinAsignar.DataSource = Nothing
        Me.vgrdAutotanquesSinAsignar.Dock = System.Windows.Forms.DockStyle.Fill
        Me.vgrdAutotanquesSinAsignar.FullRowSelect = True
        Me.vgrdAutotanquesSinAsignar.GridLines = True
        Me.vgrdAutotanquesSinAsignar.HidedColumnNames = New String(-1) {}
        Me.vgrdAutotanquesSinAsignar.Location = New System.Drawing.Point(0, 0)
        Me.vgrdAutotanquesSinAsignar.MultiSelect = False
        Me.vgrdAutotanquesSinAsignar.Name = "vgrdAutotanquesSinAsignar"
        Me.vgrdAutotanquesSinAsignar.PKColumnNames = Nothing
        Me.vgrdAutotanquesSinAsignar.Size = New System.Drawing.Size(1038, 108)
        Me.vgrdAutotanquesSinAsignar.TabIndex = 4
        Me.vgrdAutotanquesSinAsignar.UseCompatibleStateImageBehavior = False
        Me.vgrdAutotanquesSinAsignar.View = System.Windows.Forms.View.Details
        '
        'pnlEditarAutotanqueNA
        '
        Me.pnlEditarAutotanqueNA.Controls.Add(Me.rgrpAutotanqueNA)
        Me.pnlEditarAutotanqueNA.Dock = System.Windows.Forms.DockStyle.Right
        Me.pnlEditarAutotanqueNA.Location = New System.Drawing.Point(1038, 0)
        Me.pnlEditarAutotanqueNA.Name = "pnlEditarAutotanqueNA"
        Me.pnlEditarAutotanqueNA.Padding = New System.Windows.Forms.Padding(5)
        Me.pnlEditarAutotanqueNA.Size = New System.Drawing.Size(104, 108)
        Me.pnlEditarAutotanqueNA.TabIndex = 5
        '
        'rgrpAutotanqueNA
        '
        Me.rgrpAutotanqueNA.BorderColor = System.Drawing.Color.Gainsboro
        Me.rgrpAutotanqueNA.Controls.Add(Me.btnEditarAutotanqueNA)
        Me.rgrpAutotanqueNA.Dock = System.Windows.Forms.DockStyle.Fill
        Me.rgrpAutotanqueNA.FlatStyle = Logistica.RoundedGroupBox.Style.Road
        Me.rgrpAutotanqueNA.Location = New System.Drawing.Point(5, 5)
        Me.rgrpAutotanqueNA.Name = "rgrpAutotanqueNA"
        Me.rgrpAutotanqueNA.Size = New System.Drawing.Size(94, 98)
        Me.rgrpAutotanqueNA.TabIndex = 0
        Me.rgrpAutotanqueNA.TabStop = False
        '
        'btnEditarAutotanqueNA
        '
        Me.btnEditarAutotanqueNA.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnEditarAutotanqueNA.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnEditarAutotanqueNA.ImageIndex = 10
        Me.btnEditarAutotanqueNA.ImageList = Me.imgHerramientas
        Me.btnEditarAutotanqueNA.Location = New System.Drawing.Point(8, 24)
        Me.btnEditarAutotanqueNA.Name = "btnEditarAutotanqueNA"
        Me.btnEditarAutotanqueNA.Size = New System.Drawing.Size(75, 23)
        Me.btnEditarAutotanqueNA.TabIndex = 114
        Me.btnEditarAutotanqueNA.Text = "Editar"
        Me.btnEditarAutotanqueNA.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'tabEmpleadosEnPrestamo
        '
        Me.tabEmpleadosEnPrestamo.BackColor = System.Drawing.Color.Gainsboro
        Me.tabEmpleadosEnPrestamo.Controls.Add(Me.vgrdEmpleadosEnPrestamo)
        Me.tabEmpleadosEnPrestamo.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tabEmpleadosEnPrestamo.Location = New System.Drawing.Point(4, 25)
        Me.tabEmpleadosEnPrestamo.Name = "tabEmpleadosEnPrestamo"
        Me.tabEmpleadosEnPrestamo.Size = New System.Drawing.Size(1142, 108)
        Me.tabEmpleadosEnPrestamo.TabIndex = 4
        Me.tabEmpleadosEnPrestamo.Text = "Empleados en prestamo"
        Me.tabEmpleadosEnPrestamo.ToolTipText = "Empleados prestados a otra célula"
        Me.tabEmpleadosEnPrestamo.Visible = False
        '
        'vgrdEmpleadosEnPrestamo
        '
        Me.vgrdEmpleadosEnPrestamo.AlternativeBackColor = System.Drawing.Color.Gainsboro        
        Me.vgrdEmpleadosEnPrestamo.CheckCondition = Nothing
        Me.vgrdEmpleadosEnPrestamo.DataSource = Nothing
        Me.vgrdEmpleadosEnPrestamo.Dock = System.Windows.Forms.DockStyle.Fill
        Me.vgrdEmpleadosEnPrestamo.FullRowSelect = True
        Me.vgrdEmpleadosEnPrestamo.GridLines = True
        Me.vgrdEmpleadosEnPrestamo.HidedColumnNames = New String(-1) {}
        Me.vgrdEmpleadosEnPrestamo.Location = New System.Drawing.Point(0, 0)
        Me.vgrdEmpleadosEnPrestamo.Name = "vgrdEmpleadosEnPrestamo"
        Me.vgrdEmpleadosEnPrestamo.PKColumnNames = Nothing
        Me.vgrdEmpleadosEnPrestamo.Size = New System.Drawing.Size(1142, 108)
        Me.vgrdEmpleadosEnPrestamo.TabIndex = 1
        Me.vgrdEmpleadosEnPrestamo.UseCompatibleStateImageBehavior = False
        Me.vgrdEmpleadosEnPrestamo.View = System.Windows.Forms.View.Details
        '
        'tabAutotanquesEnPrestamo
        '
        Me.tabAutotanquesEnPrestamo.BackColor = System.Drawing.Color.Gainsboro
        Me.tabAutotanquesEnPrestamo.Controls.Add(Me.vgrdAutotanquesEnPrestamo)
        Me.tabAutotanquesEnPrestamo.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tabAutotanquesEnPrestamo.Location = New System.Drawing.Point(4, 25)
        Me.tabAutotanquesEnPrestamo.Name = "tabAutotanquesEnPrestamo"
        Me.tabAutotanquesEnPrestamo.Size = New System.Drawing.Size(1142, 108)
        Me.tabAutotanquesEnPrestamo.TabIndex = 5
        Me.tabAutotanquesEnPrestamo.Text = "Autotanques en prestamo"
        Me.tabAutotanquesEnPrestamo.ToolTipText = "Autotanques prestados a otra célula"
        Me.tabAutotanquesEnPrestamo.Visible = False
        '
        'vgrdAutotanquesEnPrestamo
        '
        Me.vgrdAutotanquesEnPrestamo.AlternativeBackColor = System.Drawing.Color.Gainsboro        
        Me.vgrdAutotanquesEnPrestamo.CheckCondition = Nothing
        Me.vgrdAutotanquesEnPrestamo.DataSource = Nothing
        Me.vgrdAutotanquesEnPrestamo.Dock = System.Windows.Forms.DockStyle.Fill
        Me.vgrdAutotanquesEnPrestamo.FullRowSelect = True
        Me.vgrdAutotanquesEnPrestamo.GridLines = True
        Me.vgrdAutotanquesEnPrestamo.HidedColumnNames = New String(-1) {}
        Me.vgrdAutotanquesEnPrestamo.Location = New System.Drawing.Point(0, 0)
        Me.vgrdAutotanquesEnPrestamo.Name = "vgrdAutotanquesEnPrestamo"
        Me.vgrdAutotanquesEnPrestamo.PKColumnNames = Nothing
        Me.vgrdAutotanquesEnPrestamo.Size = New System.Drawing.Size(1142, 108)
        Me.vgrdAutotanquesEnPrestamo.TabIndex = 1
        Me.vgrdAutotanquesEnPrestamo.UseCompatibleStateImageBehavior = False
        Me.vgrdAutotanquesEnPrestamo.View = System.Windows.Forms.View.Details
        '
        'tabEmpleadosPrestados
        '
        Me.tabEmpleadosPrestados.BackColor = System.Drawing.Color.Gainsboro
        Me.tabEmpleadosPrestados.Controls.Add(Me.vgrdEmpleadosPrestados)
        Me.tabEmpleadosPrestados.Controls.Add(Me.pnlDevuelveEmpleado)
        Me.tabEmpleadosPrestados.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tabEmpleadosPrestados.Location = New System.Drawing.Point(4, 25)
        Me.tabEmpleadosPrestados.Name = "tabEmpleadosPrestados"
        Me.tabEmpleadosPrestados.Size = New System.Drawing.Size(1142, 108)
        Me.tabEmpleadosPrestados.TabIndex = 2
        Me.tabEmpleadosPrestados.Text = "Empleados prestados"
        Me.tabEmpleadosPrestados.ToolTipText = "Empleados provenientes de otra célula"
        Me.tabEmpleadosPrestados.Visible = False
        '
        'vgrdEmpleadosPrestados
        '
        Me.vgrdEmpleadosPrestados.AlternativeBackColor = System.Drawing.Color.Gainsboro        
        Me.vgrdEmpleadosPrestados.CheckCondition = Nothing
        Me.vgrdEmpleadosPrestados.DataSource = Nothing
        Me.vgrdEmpleadosPrestados.Dock = System.Windows.Forms.DockStyle.Fill
        Me.vgrdEmpleadosPrestados.FullRowSelect = True
        Me.vgrdEmpleadosPrestados.GridLines = True
        Me.vgrdEmpleadosPrestados.HidedColumnNames = New String(-1) {}
        Me.vgrdEmpleadosPrestados.Location = New System.Drawing.Point(0, 0)
        Me.vgrdEmpleadosPrestados.Name = "vgrdEmpleadosPrestados"
        Me.vgrdEmpleadosPrestados.PKColumnNames = Nothing
        Me.vgrdEmpleadosPrestados.Size = New System.Drawing.Size(1038, 108)
        Me.vgrdEmpleadosPrestados.TabIndex = 1
        Me.vgrdEmpleadosPrestados.UseCompatibleStateImageBehavior = False
        Me.vgrdEmpleadosPrestados.View = System.Windows.Forms.View.Details
        '
        'pnlDevuelveEmpleado
        '
        Me.pnlDevuelveEmpleado.Controls.Add(Me.rgrpDevuelveEmpleado)
        Me.pnlDevuelveEmpleado.Dock = System.Windows.Forms.DockStyle.Right
        Me.pnlDevuelveEmpleado.Location = New System.Drawing.Point(1038, 0)
        Me.pnlDevuelveEmpleado.Name = "pnlDevuelveEmpleado"
        Me.pnlDevuelveEmpleado.Padding = New System.Windows.Forms.Padding(5)
        Me.pnlDevuelveEmpleado.Size = New System.Drawing.Size(104, 108)
        Me.pnlDevuelveEmpleado.TabIndex = 6
        '
        'rgrpDevuelveEmpleado
        '
        Me.rgrpDevuelveEmpleado.BorderColor = System.Drawing.Color.Gainsboro
        Me.rgrpDevuelveEmpleado.Controls.Add(Me.btnDevuelveEmpleado)
        Me.rgrpDevuelveEmpleado.Dock = System.Windows.Forms.DockStyle.Fill
        Me.rgrpDevuelveEmpleado.FlatStyle = Logistica.RoundedGroupBox.Style.Road
        Me.rgrpDevuelveEmpleado.Location = New System.Drawing.Point(5, 5)
        Me.rgrpDevuelveEmpleado.Name = "rgrpDevuelveEmpleado"
        Me.rgrpDevuelveEmpleado.Size = New System.Drawing.Size(94, 98)
        Me.rgrpDevuelveEmpleado.TabIndex = 0
        Me.rgrpDevuelveEmpleado.TabStop = False
        '
        'btnDevuelveEmpleado
        '
        Me.btnDevuelveEmpleado.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnDevuelveEmpleado.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnDevuelveEmpleado.ImageIndex = 4
        Me.btnDevuelveEmpleado.ImageList = Me.imgHerramientas
        Me.btnDevuelveEmpleado.Location = New System.Drawing.Point(8, 24)
        Me.btnDevuelveEmpleado.Name = "btnDevuelveEmpleado"
        Me.btnDevuelveEmpleado.Size = New System.Drawing.Size(75, 23)
        Me.btnDevuelveEmpleado.TabIndex = 114
        Me.btnDevuelveEmpleado.Text = "Devolver"
        Me.btnDevuelveEmpleado.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'tabAutotanquesPrestados
        '
        Me.tabAutotanquesPrestados.BackColor = System.Drawing.Color.Gainsboro
        Me.tabAutotanquesPrestados.Controls.Add(Me.vgrdAutotanquesPrestados)
        Me.tabAutotanquesPrestados.Controls.Add(Me.pnlDevuelveOperador)
        Me.tabAutotanquesPrestados.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tabAutotanquesPrestados.Location = New System.Drawing.Point(4, 25)
        Me.tabAutotanquesPrestados.Name = "tabAutotanquesPrestados"
        Me.tabAutotanquesPrestados.Size = New System.Drawing.Size(1142, 108)
        Me.tabAutotanquesPrestados.TabIndex = 3
        Me.tabAutotanquesPrestados.Text = "Autotanques prestados"
        Me.tabAutotanquesPrestados.ToolTipText = "Autotanques provenientes de otra célula"
        Me.tabAutotanquesPrestados.Visible = False
        '
        'vgrdAutotanquesPrestados
        '
        Me.vgrdAutotanquesPrestados.AlternativeBackColor = System.Drawing.Color.Gainsboro        
        Me.vgrdAutotanquesPrestados.CheckCondition = Nothing
        Me.vgrdAutotanquesPrestados.DataSource = Nothing
        Me.vgrdAutotanquesPrestados.Dock = System.Windows.Forms.DockStyle.Fill
        Me.vgrdAutotanquesPrestados.FullRowSelect = True
        Me.vgrdAutotanquesPrestados.GridLines = True
        Me.vgrdAutotanquesPrestados.HidedColumnNames = New String(-1) {}
        Me.vgrdAutotanquesPrestados.Location = New System.Drawing.Point(0, 0)
        Me.vgrdAutotanquesPrestados.Name = "vgrdAutotanquesPrestados"
        Me.vgrdAutotanquesPrestados.PKColumnNames = Nothing
        Me.vgrdAutotanquesPrestados.Size = New System.Drawing.Size(1038, 108)
        Me.vgrdAutotanquesPrestados.TabIndex = 1
        Me.vgrdAutotanquesPrestados.UseCompatibleStateImageBehavior = False
        Me.vgrdAutotanquesPrestados.View = System.Windows.Forms.View.Details
        '
        'pnlDevuelveOperador
        '
        Me.pnlDevuelveOperador.Controls.Add(Me.rgrpDevuelveAutotanque)
        Me.pnlDevuelveOperador.Dock = System.Windows.Forms.DockStyle.Right
        Me.pnlDevuelveOperador.Location = New System.Drawing.Point(1038, 0)
        Me.pnlDevuelveOperador.Name = "pnlDevuelveOperador"
        Me.pnlDevuelveOperador.Padding = New System.Windows.Forms.Padding(5)
        Me.pnlDevuelveOperador.Size = New System.Drawing.Size(104, 108)
        Me.pnlDevuelveOperador.TabIndex = 6
        '
        'rgrpDevuelveAutotanque
        '
        Me.rgrpDevuelveAutotanque.BorderColor = System.Drawing.Color.Gainsboro
        Me.rgrpDevuelveAutotanque.Controls.Add(Me.btnDevuelveAutotanque)
        Me.rgrpDevuelveAutotanque.Dock = System.Windows.Forms.DockStyle.Fill
        Me.rgrpDevuelveAutotanque.FlatStyle = Logistica.RoundedGroupBox.Style.Road
        Me.rgrpDevuelveAutotanque.Location = New System.Drawing.Point(5, 5)
        Me.rgrpDevuelveAutotanque.Name = "rgrpDevuelveAutotanque"
        Me.rgrpDevuelveAutotanque.Size = New System.Drawing.Size(94, 98)
        Me.rgrpDevuelveAutotanque.TabIndex = 0
        Me.rgrpDevuelveAutotanque.TabStop = False
        '
        'btnDevuelveAutotanque
        '
        Me.btnDevuelveAutotanque.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnDevuelveAutotanque.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnDevuelveAutotanque.ImageIndex = 4
        Me.btnDevuelveAutotanque.ImageList = Me.imgHerramientas
        Me.btnDevuelveAutotanque.Location = New System.Drawing.Point(8, 24)
        Me.btnDevuelveAutotanque.Name = "btnDevuelveAutotanque"
        Me.btnDevuelveAutotanque.Size = New System.Drawing.Size(75, 23)
        Me.btnDevuelveAutotanque.TabIndex = 114
        Me.btnDevuelveAutotanque.Text = "Devolver"
        Me.btnDevuelveAutotanque.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'pnlOperadores
        '
        Me.pnlOperadores.Controls.Add(Me.vgrdOperadores)
        Me.pnlOperadores.Controls.Add(Me.lblOperadores)
        Me.pnlOperadores.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.pnlOperadores.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.pnlOperadores.Location = New System.Drawing.Point(0, 390)
        Me.pnlOperadores.Name = "pnlOperadores"
        Me.pnlOperadores.Size = New System.Drawing.Size(1176, 100)
        Me.pnlOperadores.TabIndex = 114
        '
        'vgrdOperadores
        '
        Me.vgrdOperadores.AlternativeBackColor = System.Drawing.Color.Gainsboro        
        Me.vgrdOperadores.CheckCondition = Nothing
        Me.vgrdOperadores.DataSource = Nothing
        Me.vgrdOperadores.Dock = System.Windows.Forms.DockStyle.Fill
        Me.vgrdOperadores.FullRowSelect = True
        Me.vgrdOperadores.GridLines = True
        Me.vgrdOperadores.HidedColumnNames = New String() {"AñoATT", "Folio"}
        Me.vgrdOperadores.Location = New System.Drawing.Point(0, 16)
        Me.vgrdOperadores.Name = "vgrdOperadores"
        Me.vgrdOperadores.PKColumnNames = Nothing
        Me.vgrdOperadores.Size = New System.Drawing.Size(1176, 84)
        Me.vgrdOperadores.TabIndex = 111
        Me.vgrdOperadores.UseCompatibleStateImageBehavior = False
        Me.vgrdOperadores.View = System.Windows.Forms.View.Details
        '
        'lblOperadores
        '
        Me.lblOperadores.BackColor = System.Drawing.Color.Maroon
        Me.lblOperadores.Dock = System.Windows.Forms.DockStyle.Top
        Me.lblOperadores.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblOperadores.ForeColor = System.Drawing.Color.White
        Me.lblOperadores.Location = New System.Drawing.Point(0, 0)
        Me.lblOperadores.Name = "lblOperadores"
        Me.lblOperadores.Size = New System.Drawing.Size(1176, 16)
        Me.lblOperadores.TabIndex = 112
        Me.lblOperadores.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'grdFolios
        '
        Me.grdFolios.AlternatingBackColor = System.Drawing.Color.Gainsboro
        Me.grdFolios.BackColor = System.Drawing.Color.White
        Me.grdFolios.BackgroundColor = System.Drawing.Color.White
        Me.grdFolios.CaptionBackColor = System.Drawing.Color.DarkBlue
        Me.grdFolios.DataMember = ""
        Me.grdFolios.Dock = System.Windows.Forms.DockStyle.Fill
        Me.grdFolios.GridLineColor = System.Drawing.Color.Gainsboro
        Me.grdFolios.HeaderBackColor = System.Drawing.Color.Gainsboro
        Me.grdFolios.HeaderForeColor = System.Drawing.SystemColors.ControlText
        Me.grdFolios.Location = New System.Drawing.Point(0, 75)
        Me.grdFolios.Name = "grdFolios"
        Me.grdFolios.ParentRowsBackColor = System.Drawing.Color.Gainsboro
        Me.grdFolios.ReadOnly = True
        Me.grdFolios.RowHeaderWidth = 5
        Me.grdFolios.Size = New System.Drawing.Size(1176, 312)
        Me.grdFolios.TabIndex = 115
        Me.grdFolios.TableStyles.AddRange(New System.Windows.Forms.DataGridTableStyle() {Me.tbsFolio})
        '
        'tbsFolio
        '
        Me.tbsFolio.AlternatingBackColor = System.Drawing.Color.Gainsboro
        Me.tbsFolio.BackColor = System.Drawing.Color.White
        Me.tbsFolio.DataGrid = Me.grdFolios
        Me.tbsFolio.GridColumnStyles.AddRange(New System.Windows.Forms.DataGridColumnStyle() {Me.Folio, Me.Autotanque, Me.RutaAsignada, Me.DescripcionRutaAsignada, Me.ClaseRuta, Me.TipoAsignacion, Me.Producto, Me.RutaOriginal, Me.DescripcionRutaOriginal, Me.Placas, Me.StatusLogistica, Me.FAsignacion, Me.TipoVehiculo})
        Me.tbsFolio.GridLineColor = System.Drawing.Color.Gainsboro
        Me.tbsFolio.HeaderBackColor = System.Drawing.Color.Gainsboro
        Me.tbsFolio.HeaderForeColor = System.Drawing.SystemColors.ControlText
        Me.tbsFolio.MappingName = "Folios"
        Me.tbsFolio.SelectionBackColor = System.Drawing.Color.LightSteelBlue
        Me.tbsFolio.SelectionForeColor = System.Drawing.Color.DarkBlue
        '
        'Folio
        '
        Me.Folio.Format = ""
        Me.Folio.FormatInfo = Nothing
        Me.Folio.HeaderText = "Folio"
        Me.Folio.MappingName = "Folio"
        Me.Folio.NullText = "--"
        Me.Folio.Width = 40
        '
        'Autotanque
        '
        Me.Autotanque.Alignment = System.Windows.Forms.HorizontalAlignment.Center
        Me.Autotanque.Format = ""
        Me.Autotanque.FormatInfo = Nothing
        Me.Autotanque.HeaderText = "Autotanque"
        Me.Autotanque.MappingName = "Autotanque"
        Me.Autotanque.NullText = "--"
        Me.Autotanque.Width = 40
        '
        'RutaAsignada
        '
        Me.RutaAsignada.Format = ""
        Me.RutaAsignada.FormatInfo = Nothing
        Me.RutaAsignada.HeaderText = "Ruta asignada"
        Me.RutaAsignada.MappingName = "RutaAsignada"
        Me.RutaAsignada.NullText = "--"
        Me.RutaAsignada.Width = 70
        '
        'DescripcionRutaAsignada
        '
        Me.DescripcionRutaAsignada.Format = ""
        Me.DescripcionRutaAsignada.FormatInfo = Nothing
        Me.DescripcionRutaAsignada.HeaderText = "Nombre ruta asignada "
        Me.DescripcionRutaAsignada.MappingName = "DescripcionRutaAsignada"
        Me.DescripcionRutaAsignada.Width = 95
        '
        'ClaseRuta
        '
        Me.ClaseRuta.Format = ""
        Me.ClaseRuta.FormatInfo = Nothing
        Me.ClaseRuta.HeaderText = "Clase"
        Me.ClaseRuta.MappingName = "ClaseRuta"
        Me.ClaseRuta.Width = 75
        '
        'TipoAsignacion
        '
        Me.TipoAsignacion.Format = ""
        Me.TipoAsignacion.FormatInfo = Nothing
        Me.TipoAsignacion.HeaderText = "Tipo asignación"
        Me.TipoAsignacion.MappingName = "TipoAsignacion"
        Me.TipoAsignacion.NullText = "--"
        Me.TipoAsignacion.Width = 75
        '
        'Producto
        '
        Me.Producto.Format = ""
        Me.Producto.FormatInfo = Nothing
        Me.Producto.HeaderText = "Producto"
        Me.Producto.MappingName = "Producto"
        Me.Producto.NullText = "--"
        Me.Producto.Width = 75
        '
        'RutaOriginal
        '
        Me.RutaOriginal.Format = ""
        Me.RutaOriginal.FormatInfo = Nothing
        Me.RutaOriginal.HeaderText = "Ruta original"
        Me.RutaOriginal.MappingName = "RutaOriginal"
        Me.RutaOriginal.NullText = "--"
        Me.RutaOriginal.Width = 70
        '
        'DescripcionRutaOriginal
        '
        Me.DescripcionRutaOriginal.Format = ""
        Me.DescripcionRutaOriginal.FormatInfo = Nothing
        Me.DescripcionRutaOriginal.HeaderText = "Nombre ruta original"
        Me.DescripcionRutaOriginal.MappingName = "DescripcionRutaOriginal"
        Me.DescripcionRutaOriginal.Width = 95
        '
        'Placas
        '
        Me.Placas.Format = ""
        Me.Placas.FormatInfo = Nothing
        Me.Placas.HeaderText = "Placas"
        Me.Placas.MappingName = "Placas"
        Me.Placas.NullText = "--"
        Me.Placas.Width = 60
        '
        'StatusLogistica
        '
        Me.StatusLogistica.Alignment = System.Windows.Forms.HorizontalAlignment.Center
        Me.StatusLogistica.Format = ""
        Me.StatusLogistica.FormatInfo = Nothing
        Me.StatusLogistica.HeaderText = "Status"
        Me.StatusLogistica.MappingName = "StatusLogistica"
        Me.StatusLogistica.NullText = "--"
        Me.StatusLogistica.Width = 75
        '
        'FAsignacion
        '
        Me.FAsignacion.Alignment = System.Windows.Forms.HorizontalAlignment.Right
        Me.FAsignacion.Format = ""
        Me.FAsignacion.FormatInfo = Nothing
        Me.FAsignacion.HeaderText = "Asignación"
        Me.FAsignacion.MappingName = "FAsignacion"
        Me.FAsignacion.NullText = "--"
        Me.FAsignacion.Width = 75
        '
        'TipoVehiculo
        '
        Me.TipoVehiculo.Format = ""
        Me.TipoVehiculo.FormatInfo = Nothing
        Me.TipoVehiculo.HeaderText = "Vehículo"
        Me.TipoVehiculo.MappingName = "TipoVehiculo"
        Me.TipoVehiculo.NullText = "--"
        Me.TipoVehiculo.Width = 75
        '
        'btnEditarEmpleadosNA
        '
        Me.btnEditarEmpleadosNA.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnEditarEmpleadosNA.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnEditarEmpleadosNA.ImageList = Me.imgHerramientas
        Me.btnEditarEmpleadosNA.Location = New System.Drawing.Point(9, 24)
        Me.btnEditarEmpleadosNA.Name = "btnEditarEmpleadosNA"
        Me.btnEditarEmpleadosNA.Size = New System.Drawing.Size(75, 23)
        Me.btnEditarEmpleadosNA.TabIndex = 114
        Me.btnEditarEmpleadosNA.Text = "Editar"
        Me.btnEditarEmpleadosNA.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'rgrpEditarEmpleadorNA
        '
        Me.rgrpEditarEmpleadorNA.BorderColor = System.Drawing.Color.Gainsboro
        Me.rgrpEditarEmpleadorNA.Dock = System.Windows.Forms.DockStyle.Fill
        Me.rgrpEditarEmpleadorNA.FlatStyle = Logistica.RoundedGroupBox.Style.Road
        Me.rgrpEditarEmpleadorNA.Location = New System.Drawing.Point(5, 5)
        Me.rgrpEditarEmpleadorNA.Name = "rgrpEditarEmpleadorNA"
        Me.rgrpEditarEmpleadorNA.Size = New System.Drawing.Size(94, 97)
        Me.rgrpEditarEmpleadorNA.TabIndex = 0
        Me.rgrpEditarEmpleadorNA.TabStop = False
        '
        'cboProducto
        '
        Me.cboProducto.BackColor = System.Drawing.Color.WhiteSmoke
        Me.cboProducto.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboProducto.Location = New System.Drawing.Point(920, 80)
        Me.cboProducto.Name = "cboProducto"
        Me.cboProducto.Size = New System.Drawing.Size(121, 21)
        Me.cboProducto.TabIndex = 116
        Me.cboProducto.Visible = False
        '
        'frmAsignacion
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 14)
        Me.BackColor = System.Drawing.Color.Gainsboro
        Me.ClientSize = New System.Drawing.Size(1176, 677)
        Me.Controls.Add(Me.cboProducto)
        Me.Controls.Add(Me.cboTipoAsignacion)
        Me.Controls.Add(Me.grdFolios)
        Me.Controls.Add(Me.splGrids)
        Me.Controls.Add(Me.pnlOperadores)
        Me.Controls.Add(Me.pnlOpciones)
        Me.Controls.Add(Me.tbInicioRuta)
        Me.Controls.Add(Me.splDatosExtra)
        Me.Controls.Add(Me.pnlDatosExtra)
        Me.Controls.Add(Me.pnlBase)
        Me.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Menu = Me.mnuAsignacion
        Me.Name = "frmAsignacion"
        Me.Text = "Asignaciones"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.pnlOpciones.ResumeLayout(False)
        Me.pnlOpciones.PerformLayout()
        Me.pnlDatosExtra.ResumeLayout(False)
        Me.rgpDatosExtra.ResumeLayout(False)
        Me.pnlContenedor1.ResumeLayout(False)
        Me.tabInformacion.ResumeLayout(False)
        Me.tabEmpleadosSinAsignar.ResumeLayout(False)
        Me.pnlEditarEmpleadosNA.ResumeLayout(False)
        Me.rgrpEmpleadoSA.ResumeLayout(False)
        Me.tabAutotanquesSinAsignar.ResumeLayout(False)
        Me.pnlEditarAutotanqueNA.ResumeLayout(False)
        Me.rgrpAutotanqueNA.ResumeLayout(False)
        Me.tabEmpleadosEnPrestamo.ResumeLayout(False)
        Me.tabAutotanquesEnPrestamo.ResumeLayout(False)
        Me.tabEmpleadosPrestados.ResumeLayout(False)
        Me.pnlDevuelveEmpleado.ResumeLayout(False)
        Me.rgrpDevuelveEmpleado.ResumeLayout(False)
        Me.tabAutotanquesPrestados.ResumeLayout(False)
        Me.pnlDevuelveOperador.ResumeLayout(False)
        Me.rgrpDevuelveAutotanque.ResumeLayout(False)
        Me.pnlOperadores.ResumeLayout(False)
        CType(Me.grdFolios, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

#End Region

    Private dsAsignacionInicial As New DataSet()
    Private PermiteCambioTipoAsignacion As Boolean
    Private PermiteCambioProducto As Boolean
    Private Loaded As Boolean
    Private Celula As Integer
    Private dsDatosExtra As New DataSet()

#Region "Rutinas de actualizacion"
    Private Sub CargaInformacion()
        grdFolios.DataSource = Nothing
        grdFolios.CaptionText = ""
        vgrdOperadores.DataSource = Nothing
        If Not cboCelula.SelectedValue Is Nothing Then
            Dim cmdLogistica As New SqlCommand("exec spLOGInformacionFolios @Celula, @FAsignacion", cnSigamet)
            Dim daLogistica As New SqlDataAdapter(cmdLogistica)
            Dim PKColumns(0) As DataColumn
            Me.Cursor = Cursors.WaitCursor
            cmdLogistica.Parameters.Add("@Celula", SqlDbType.SmallInt).Value = cboCelula.SelectedValue
            cmdLogistica.Parameters.Add("@FAsignacion", SqlDbType.DateTime).Value = dtpFAsignacion.Value.Date
            Try
                dsAsignacionInicial.Tables("Folios").Clear()
                daLogistica.Fill(dsAsignacionInicial.Tables("Folios"))
                PKColumns(0) = dsAsignacionInicial.Tables("Folios").Columns("Folio")
                dsAsignacionInicial.Tables("Folios").PrimaryKey = PKColumns                
                GridData(grdFolios, dsAsignacionInicial.Tables("Folios"), 0, 10)
                grdFolios.CaptionText = "Folios de la célula " & CStr(cboCelula.SelectedValue) & " del " & dtpFAsignacion.Value.ToShortDateString
                CargaTripulacion()
            Catch ex As Exception
                ExMessage(ex)
            Finally
                cmdLogistica.Dispose()
                daLogistica.Dispose()
                Me.Cursor = Cursors.Default
            End Try
        End If
    End Sub
    Private Sub CargaTripulacion()
        If Not cboCelula.SelectedValue Is Nothing Then
            Dim cmdLogistica As New SqlCommand("exec spLOGInformacionTripulacion @Celula, @FAsignacion", cnSigamet)
            Dim daLogistica As New SqlDataAdapter(cmdLogistica)
            Me.Cursor = Cursors.WaitCursor
            cmdLogistica.Parameters.Add("@Celula", SqlDbType.SmallInt).Value = cboCelula.SelectedValue
            cmdLogistica.Parameters.Add("@FAsignacion", SqlDbType.DateTime).Value = dtpFAsignacion.Value.Date
            Try
                dsAsignacionInicial.Tables("Operadores").Clear()
                daLogistica.Fill(dsAsignacionInicial.Tables("Operadores"))
            Catch ex As Exception
                ExMessage(ex)
            Finally
                cmdLogistica.Dispose()
                daLogistica.Dispose()
                Me.Cursor = Cursors.Default
            End Try
        End If
    End Sub
    Private Sub CargaDatosExtra()
        If Not cboCelula.SelectedValue Is Nothing Then
            Me.Cursor = Cursors.WaitCursor

            CargaAutotanquesSinAsignar()
            CargaEmpleadosPrestados()
            CargaEmpleadosSinAsignar()
            CargaEmpleadoEnPrestamo()
            CargaAutotanquesPrestados()
            CargaAutotanquesEnPrestamo()

            Me.Cursor = Cursors.Default
        End If
    End Sub

    Private Sub CargaAutotanquesSinAsignar()
        Dim daLogistica As New SqlDataAdapter("exec spLOGAutotanqueSinAsignar @Celula, @FAsignacion", cnSigamet)
        Dim dtAttSinAsignar As New DataTable()
        vgrdAutotanquesSinAsignar.DataSource = Nothing
        daLogistica.SelectCommand.Parameters.Add("@Celula", SqlDbType.SmallInt).Value = cboCelula.SelectedValue
        daLogistica.SelectCommand.Parameters.Add("@FAsignacion", SqlDbType.DateTime).Value = dtpFAsignacion.Value.Date
        Try
            daLogistica.Fill(dtAttSinAsignar)
        Catch ex As Exception
            ExMessage(ex)
        Finally
            daLogistica.Dispose()
            cnSigamet.Close()
        End Try
        vgrdAutotanquesSinAsignar.DataSource = dtAttSinAsignar
    End Sub
    Private Sub CargaEmpleadosPrestados()
        Dim daLogistica As New SqlDataAdapter("exec spLOGEmpleadosPrestados @Celula, @FAsignacion", cnSigamet)
        Dim dtEmpleadosPrestados As New DataTable()
        daLogistica.SelectCommand.Parameters.Add("@Celula", SqlDbType.TinyInt).Value = cboCelula.SelectedValue
        daLogistica.SelectCommand.Parameters.Add("@FAsignacion", SqlDbType.DateTime).Value = dtpFAsignacion.Value.Date
        vgrdEmpleadosPrestados.DataSource = Nothing
        Try
            daLogistica.Fill(dtEmpleadosPrestados)
        Catch ex As Exception
            ExMessage(ex)
        Finally
            daLogistica.Dispose()
            cnSigamet.Close()
        End Try
        vgrdEmpleadosPrestados.DataSource = dtEmpleadosPrestados
    End Sub
    Private Sub CargaEmpleadosSinAsignar()
        Dim daLogistica As New SqlDataAdapter("exec spLOGEmpleadoSinAsignar @Celula, @FAsignacion", cnSigamet)
        'Dim dtEmpleadosSinAsignar As New DataTable()

        dsDatosExtra.Tables("EmpleadosSinAsignar").Clear()
        vgrdEmpleadosSinAsignar.DataSource = Nothing
        daLogistica.SelectCommand.Parameters.Add("@Celula", SqlDbType.SmallInt).Value = cboCelula.SelectedValue
        daLogistica.SelectCommand.Parameters.Add("@FAsignacion", SqlDbType.DateTime).Value = dtpFAsignacion.Value.Date
        Try
            'daLogistica.Fill(dtEmpleadosSinAsignar)            
            daLogistica.Fill(dsDatosExtra.Tables("EmpleadosSinAsignar"))
        Catch ex As Exception
            ExMessage(ex)
        Finally
            daLogistica.Dispose()
            cnSigamet.Close()
        End Try

        'vgrdEmpleadosSinAsignar.DataSource = dtEmpleadosSinAsignar
        vgrdEmpleadosSinAsignar.DataSource = dsDatosExtra.Tables("EmpleadosSinAsignar")


        If cboClaseRuta.Enabled And cboCelula.SelectedIndex <> -1 Then
            Dim dtEmpleadosSinAsignar As DataTable = dsDatosExtra.Tables("EmpleadosSinAsignar")
            Dim vwEmpleadosSinAsignar As New DataView(dtEmpleadosSinAsignar)
            vwEmpleadosSinAsignar.RowFilter = "Clasificacion In(" + FiltroClasfificacionOperador(cboClaseRuta.SelectedValue, True) + ")"
            vgrdEmpleadosSinAsignar.DataSource = vwEmpleadosSinAsignar
        Else
            vgrdEmpleadosSinAsignar.DataSource = dsDatosExtra.Tables("EmpleadosSinAsignar")
        End If


        

    End Sub
    Private Sub CargaEmpleadoEnPrestamo()
        Dim daLogistica As New SqlDataAdapter("exec spLOGEmpleadosEnPrestamo @Celula, @FPrestamo", cnSigamet)
        Dim dtEmpleadoEnPrestamo As New DataTable()
        vgrdEmpleadosEnPrestamo.DataSource = Nothing
        daLogistica.SelectCommand.Parameters.Add("@Celula", SqlDbType.SmallInt).Value = cboCelula.SelectedValue
        daLogistica.SelectCommand.Parameters.Add("@FPrestamo", SqlDbType.DateTime).Value = dtpFAsignacion.Value.Date
        Try
            daLogistica.Fill(dtEmpleadoEnPrestamo)
        Catch ex As Exception
            ExMessage(ex)
        Finally
            daLogistica.Dispose()
            cnSigamet.Close()
        End Try
        vgrdEmpleadosEnPrestamo.DataSource = dtEmpleadoEnPrestamo
    End Sub
    Private Sub CargaAutotanquesEnPrestamo()
        Dim daLogistica As New SqlDataAdapter("exec spLOGAutotanquesEnPrestamo @Celula, @FPrestamo", cnSigamet)
        Dim dtAutotanquesEnPrestamo As New DataTable()
        vgrdAutotanquesEnPrestamo.DataSource = Nothing
        daLogistica.SelectCommand.Parameters.Add("@Celula", SqlDbType.SmallInt).Value = cboCelula.SelectedValue
        daLogistica.SelectCommand.Parameters.Add("@FPrestamo", SqlDbType.DateTime).Value = dtpFAsignacion.Value.Date
        Try
            daLogistica.Fill(dtAutotanquesEnPrestamo)
        Catch ex As Exception
            ExMessage(ex)
        Finally
            daLogistica.Dispose()
            cnSigamet.Close()
        End Try
        vgrdAutotanquesEnPrestamo.DataSource = dtAutotanquesEnPrestamo
    End Sub
    Private Sub CargaAutotanquesPrestados()
        Dim daLogistica As New SqlDataAdapter("exec spLOGAutotanquesPrestados @Celula, @FPrestamo", cnSigamet)
        Dim dtAutotanquesPrestados As New DataTable()
        vgrdAutotanquesPrestados.DataSource = Nothing
        daLogistica.SelectCommand.Parameters.Add("@Celula", SqlDbType.SmallInt).Value = cboCelula.SelectedValue
        daLogistica.SelectCommand.Parameters.Add("@FPrestamo", SqlDbType.DateTime).Value = dtpFAsignacion.Value.Date
        Try
            daLogistica.Fill(dtAutotanquesPrestados)
        Catch ex As Exception
            ExMessage(ex)
        Finally
            daLogistica.Dispose()
            cnSigamet.Close()
        End Try
        vgrdAutotanquesPrestados.DataSource = dtAutotanquesPrestados
    End Sub

    Private Sub dtpFAsignacion_ValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles dtpFAsignacion.ValueChanged        
        If Loaded Then                  
            CargaDatosExtra()
            CargaInformacion()
            FiltraclaseRuta()
        End If
    End Sub
    Private Sub cboCelula_SelectedValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboCelula.SelectedValueChanged
        If Loaded AndAlso Not cboCelula.SelectedValue Is Nothing AndAlso CInt(cboCelula.SelectedValue) <> Celula Then
            cboClaseRuta.Enabled = True            
            CargaDatosExtra()
            Celula = CInt(cboCelula.SelectedValue)
            CargaInformacion()
            FiltraclaseRuta()
        End If
    End Sub
#End Region

#Region "Rutinas de manejo del grid de folios"
    Private Sub grdFolios_CurrentCellChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles grdFolios.CurrentCellChanged
        grdFolios.Select(grdFolios.CurrentRowIndex)
        cboTipoAsignacion.Visible = False
        cboProducto.Visible = False
        PermiteCambioTipoAsignacion = False
        lblOperadores.Text = ""

        btnCerrarCiclo.Enabled = CStr(CampoFolio("StatusLogistica")).Trim.ToUpper = "INICIO" OrElse CStr(CampoFolio("StatusLogistica")).Trim.ToUpper = "ASIGNADO"
        mniCerrarCiclo.Enabled = CStr(CampoFolio("StatusLogistica")).Trim.ToUpper = "INICIO" OrElse CStr(CampoFolio("StatusLogistica")).Trim.ToUpper = "ASIGNADO"

        If Not grdFolios.CurrentRowIndex < 0 AndAlso dsAsignacionInicial.Tables("Operadores").Rows.Count > 0 Then
            lblOperadores.Text = "Operadores asignados a la ruta " & CStr(CampoFolio("RutaAsignada")) & " autotanque " _
                        & CStr(CampoFolio("Autotanque")) & " con folio " & CStr(CampoFolio("Folio"))
            dsAsignacionInicial.Tables("Operadores").DefaultView.RowFilter = "Folio=" & CStr(CampoFolio("Folio"))
            vgrdOperadores.DataSource = dsAsignacionInicial.Tables("Operadores").DefaultView
            vgrdOperadores.Columns(1).Width = 220
            vgrdOperadores.Columns(6).Width = 50
            vgrdOperadores.Columns(7).Width = 50
        End If
        If grdFolios.TableStyles(0).GridColumnStyles(grdFolios.CurrentCell.ColumnNumber).MappingName = "TipoAsignacion" AndAlso ValidaCambio() Then
            cboTipoAsignacion.Top = grdFolios.GetCurrentCellBounds.Top + grdFolios.Top
            cboTipoAsignacion.Left = grdFolios.GetCurrentCellBounds.Left
            cboTipoAsignacion.Width = grdFolios.GetCurrentCellBounds.Width
            cboTipoAsignacion.Height = grdFolios.GetCurrentCellBounds.Height
            cboTipoAsignacion.SelectedValue = CampoFolio("IDTipoAsignacion")
            cboTipoAsignacion.Visible = True
            cboTipoAsignacion.Refresh()
            cboTipoAsignacion.Focus()
            PermiteCambioTipoAsignacion = True
        End If
        If _CambiarTipoProducto AndAlso grdFolios.TableStyles(0).GridColumnStyles(grdFolios.CurrentCell.ColumnNumber).MappingName = "Producto" AndAlso ValidaCambio() Then
            cboProducto.Top = grdFolios.GetCurrentCellBounds.Top + grdFolios.Top
            cboProducto.Left = grdFolios.GetCurrentCellBounds.Left
            cboProducto.Width = grdFolios.GetCurrentCellBounds.Width
            cboProducto.Height = grdFolios.GetCurrentCellBounds.Height
            cboProducto.SelectedValue = CampoFolio("IDProducto")
            cboProducto.Visible = True
            cboProducto.Refresh()
            cboProducto.Focus()
            PermiteCambioProducto = True
        End If
    End Sub
    Public Sub GridData(ByRef Grid As DataGrid, ByVal Table As DataTable, Optional ByVal TableStyleIndex As Integer = -1, Optional ByVal Columns As Integer = 0)
        If CInt(Grid.Width / Table.Columns.Count) - 10 > 0 Then
            If TableStyleIndex = -1 Then
                Grid.PreferredColumnWidth = CInt(Grid.Width / Table.Columns.Count) - 20 + Table.Columns.Count
            Else
                Grid.TableStyles(TableStyleIndex).MappingName = Table.TableName
                Dim Index As Byte
                If Columns = 0 Then
                    Columns = Table.Columns.Count - 1
                End If
                For Index = 0 To CByte(Columns - 1)
                    Grid.TableStyles(TableStyleIndex).GridColumnStyles(Index).Width = CInt(Grid.Width / Columns) - 20 + Columns
                Next Index
            End If
        End If
        Grid.DataSource = Table
    End Sub
    Public Function EncuentraRegistro(ByRef Grid As DataGrid, ByVal Busqueda As String, Optional ByVal Columna As Integer = 0) As Boolean
        Dim Index As Integer
        For Index = 0 To CuentaFilas(Grid)
            If Not Microsoft.VisualBasic.IsDBNull(Grid.Item(Index, Columna)) Then
                If Trim(CStr(Grid.Item(Index, Columna))).ToUpper = Trim(Busqueda).ToUpper Then
                    Grid.UnSelect(Grid.CurrentRowIndex)
                    Grid.Select(Index)
                    Grid.CurrentRowIndex = Index
                    Return True
                End If
            End If
        Next
        Return False
    End Function
#End Region

#Region "Rutinas de manejo de datos"
    Private Function ValidaCambio() As Boolean
        Dim cmdLogistica As New SqlCommand("Select FFinal from SemanaVenta where @FAsignacion between FInicial and FFinal", cnSigamet)
        Dim FMinima As Date
        Dim FMaxima As Date
        If CStr(CampoFolio("Folio")) = "" Then
            Return False
        End If
        cmdLogistica.Parameters.Add("@Fasignacion", SqlDbType.DateTime).Value = Now.Date
        Try
            cnSigamet.Open()
            FMaxima = CDate(cmdLogistica.ExecuteScalar).Date
            cmdLogistica.CommandText = "Select FInicial from SemanaVenta where @FAsignacion between FInicial and FFinal"
            FMinima = CDate(cmdLogistica.ExecuteScalar).Date
        Catch ex As Exception
            ExMessage(ex)
        Finally
            cnSigamet.Close()
            cmdLogistica.Dispose()
        End Try
        If OperacionLogistica(2).Habilitada OrElse CDate(CampoFolio("FInicioRuta")).Date = Now.Date Then
            Return True
        ElseIf CDate(CampoFolio("FInicioRuta")).Date.AddDays(_DiasCorreccion) >= Now.Date Then
            If CDate(CampoFolio("FInicioRuta")).Date < FMinima Then
                If Now.Date = FMinima Then
                    Return True
                Else
                    Return False
                End If
            Else
                Return True
            End If
        Else
            Return False
        End If
    End Function
    Private Function CampoFolio(ByVal Campo As String) As Object
        If dsAsignacionInicial.Tables("Folios").Rows.Count > 0 Then
            Dim FoundRow As DataRow = dsAsignacionInicial.Tables("Folios").Rows.Find(grdFolios.Item(grdFolios.CurrentRowIndex, 0))
            If Not FoundRow Is Nothing Then
                Return FoundRow(Campo)
            Else
                Return ""
            End If
        Else
            Return ""
        End If
    End Function
    Private Sub cboTipoAsignacion_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboTipoAsignacion.SelectedIndexChanged
        If PermiteCambioTipoAsignacion AndAlso grdFolios.CurrentRowIndex >= 0 AndAlso ValidaCambio() Then
            Dim cmdLogistica As New SqlCommand("Update AutotanqueTurno set TipoAsignacionAutotanque = @TipoAsignacion where AñoAtt = @Año and Folio = @Folio", cnSigamet)
            Dim Key As Object() = {CampoFolio("Folio")}
            Dim FoundRow As DataRow = dsAsignacionInicial.Tables("Folios").Rows.Find(Key)
            cmdLogistica.Parameters.Add("@Año", SqlDbType.Int).Value = CInt(CampoFolio("Año"))
            cmdLogistica.Parameters.Add("@Folio", SqlDbType.Int).Value = CInt(CampoFolio("Folio"))
            cmdLogistica.Parameters.Add("@TipoAsignacion", SqlDbType.TinyInt).Value = CByte(cboTipoAsignacion.SelectedValue)
            Try
                cnSigamet.Open()
                cmdLogistica.ExecuteNonQuery()
                FoundRow("TipoAsignacion") = cboTipoAsignacion.Text
                FoundRow("IDTipoAsignacion") = cboTipoAsignacion.SelectedValue
            Catch ex As Exception
                ExMessage(ex)
            Finally
                cmdLogistica.Dispose()
                cnSigamet.Close()
            End Try
        End If
    End Sub
    Private Sub cboProducto_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboProducto.SelectedIndexChanged
        If PermiteCambioProducto AndAlso grdFolios.CurrentRowIndex >= 0 AndAlso ValidaCambio() Then
            Dim cmdLogistica As New SqlCommand("Update AutotanqueTurno set TipoAsignacion = @Producto where AñoAtt = @Año and Folio = @Folio", cnSigamet)
            Dim Key As Object() = {CampoFolio("Folio")}
            Dim FoundRow As DataRow = dsAsignacionInicial.Tables("Folios").Rows.Find(Key)
            cmdLogistica.Parameters.Add("@Año", SqlDbType.Int).Value = CInt(CampoFolio("Año"))
            cmdLogistica.Parameters.Add("@Folio", SqlDbType.Int).Value = CInt(CampoFolio("Folio"))
            cmdLogistica.Parameters.Add("@Producto", SqlDbType.TinyInt).Value = CByte(cboProducto.SelectedValue)
            Try
                cnSigamet.Open()
                cmdLogistica.ExecuteNonQuery()
                FoundRow("Producto") = cboProducto.Text
                FoundRow("IDProducto") = cboProducto.SelectedValue
            Catch ex As Exception
                ExMessage(ex)
            Finally
                cmdLogistica.Dispose()
                cnSigamet.Close()
            End Try
        End If
    End Sub
    Private Sub cboClaseRuta_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles cboClaseRuta.SelectedIndexChanged
        If Loaded AndAlso Not cboClaseRuta.SelectedValue Is Nothing Then
            FiltraclaseRuta()
            FiltraDatosExtra()
        End If
    End Sub
#End Region

#Region "Rutinas de configuración"
    Private Sub CargaConfiguracion()
        Dim Settings As AppSettings
        Dim ctrl As Control = Nothing
        'Validaciíon de archivo de configuración
        If File.Exists(Application.StartupPath & "\" & System.Environment.UserName & ".Logistica.exe.config") Then
            Settings = New AppSettings(Application.StartupPath & "\" & System.Environment.UserName & ".Logistica.exe.config")
        Else
            Settings = New AppSettings(Application.StartupPath & "\" & "Default.Logistica.exe.config")
        End If
        'Carga de parámetros
        Me.BackColor = Color.FromArgb(CInt(Settings.GetSetting("frmAsignacion", "BackColor")))

        grdFolios.CaptionBackColor = Color.FromArgb(CInt(Settings.GetSetting("frmAsignacion", "FoliosCaptionBackColor")))
        grdFolios.CaptionForeColor = Color.FromArgb(CInt(Settings.GetSetting("frmAsignacion", "FoliosCaptionForeColor")))
        grdFolios.TableStyles(0).BackColor = Color.FromArgb(CInt(Settings.GetSetting("frmAsignacion", "FoliosBackColor")))
        grdFolios.TableStyles(0).AlternatingBackColor = Color.FromArgb(CInt(Settings.GetSetting("frmAsignacion", "FoliosAltBackColor")))
        grdFolios.TableStyles(0).ForeColor = Color.FromArgb(CInt(Settings.GetSetting("frmAsignacion", "FoliosForeColor")))
        grdFolios.TableStyles(0).SelectionBackColor = Color.FromArgb(CInt(Settings.GetSetting("frmAsignacion", "FoliosSelectionColor")))

        lblOperadores.BackColor = Color.FromArgb(CInt(Settings.GetSetting("frmAsignacion", "OperadoresCaptionBackColor")))
        lblOperadores.ForeColor = Color.FromArgb(CInt(Settings.GetSetting("frmAsignacion", "OperadoresCaptionForeColor")))
        vgrdOperadores.BackColor = Color.FromArgb(CInt(Settings.GetSetting("frmAsignacion", "OperadoresBackColor")))
        vgrdOperadores.AlternativeBackColor = Color.FromArgb(CInt(Settings.GetSetting("frmAsignacion", "OperadoresAltBackColor")))
        vgrdOperadores.ForeColor = Color.FromArgb(CInt(Settings.GetSetting("frmAsignacion", "OperadoresForeColor")))

        vgrdEmpleadosSinAsignar.BackColor = Color.FromArgb(CInt(Settings.GetSetting("frmAsignacion", "EmpleadosSABackColor")))
        vgrdEmpleadosSinAsignar.AlternativeBackColor = Color.FromArgb(CInt(Settings.GetSetting("frmAsignacion", "EmpleadosSAAltBackColor")))
        vgrdEmpleadosSinAsignar.ForeColor = Color.FromArgb(CInt(Settings.GetSetting("frmAsignacion", "EmpleadosSAForeColor")))

        vgrdAutotanquesSinAsignar.BackColor = Color.FromArgb(CInt(Settings.GetSetting("frmAsignacion", "AutotanquesSABackColor")))
        vgrdAutotanquesSinAsignar.AlternativeBackColor = Color.FromArgb(CInt(Settings.GetSetting("frmAsignacion", "AutotanquesSAAltBackColor")))
        vgrdAutotanquesSinAsignar.ForeColor = Color.FromArgb(CInt(Settings.GetSetting("frmAsignacion", "AutotanquesSAForeColor")))

        vgrdEmpleadosEnPrestamo.BackColor = Color.FromArgb(CInt(Settings.GetSetting("frmAsignacion", "EmpleadosPrestamoBackColor")))
        vgrdEmpleadosEnPrestamo.AlternativeBackColor = Color.FromArgb(CInt(Settings.GetSetting("frmAsignacion", "EmpleadosPrestamoAltBackColor")))
        vgrdEmpleadosEnPrestamo.ForeColor = Color.FromArgb(CInt(Settings.GetSetting("frmAsignacion", "EmpleadosPrestamoForeColor")))

        vgrdAutotanquesEnPrestamo.BackColor = Color.FromArgb(CInt(Settings.GetSetting("frmAsignacion", "AutotanquesPrestamoBackColor")))
        vgrdAutotanquesEnPrestamo.AlternativeBackColor = Color.FromArgb(CInt(Settings.GetSetting("frmAsignacion", "AutotanquesPrestamoAltBackColor")))
        vgrdAutotanquesEnPrestamo.ForeColor = Color.FromArgb(CInt(Settings.GetSetting("frmAsignacion", "AutotanquesPrestamoForeColor")))

        vgrdEmpleadosPrestados.BackColor = Color.FromArgb(CInt(Settings.GetSetting("frmAsignacion", "EmpleadosPrestadosBackColor")))
        vgrdEmpleadosPrestados.AlternativeBackColor = Color.FromArgb(CInt(Settings.GetSetting("frmAsignacion", "EmpleadosPrestadosAltBackColor")))
        vgrdEmpleadosPrestados.ForeColor = Color.FromArgb(CInt(Settings.GetSetting("frmAsignacion", "EmpleadosPrestadosForeColor")))

        vgrdAutotanquesPrestados.BackColor = Color.FromArgb(CInt(Settings.GetSetting("frmAsignacion", "AutotanquesPrestadosBackColor")))
        vgrdAutotanquesPrestados.AlternativeBackColor = Color.FromArgb(CInt(Settings.GetSetting("frmAsignacion", "AutotanquesPrestadosAltBackColor")))
        vgrdAutotanquesPrestados.ForeColor = Color.FromArgb(CInt(Settings.GetSetting("frmAsignacion", "AutotanquesPrestadosForeColor")))

    End Sub
    Private Sub frmOperador_Paint(ByVal sender As Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles MyBase.Paint
        CargaConfiguracion()
    End Sub
    Private Sub frmAsignacion_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Activated
        CargaConfiguracion()
    End Sub
#End Region

#Region "Rutinas de menus y herramientas"
    Private Sub tbInicioRuta_ButtonClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.ToolBarButtonClickEventArgs) Handles tbInicioRuta.ButtonClick
        Select Case e.Button.Text
            Case "Generar"
                Generar()
            Case "Asignar"
                Asignar()
            Case "Prestamo op"
                PrestamoOperador()
            Case "Prestamo att"
                PrestamoAutotanque()
            Case "Cerrar ciclo"
                CerrarCiclo()
            Case "Ruta"
                AsignacionRuta()
            Case "Cancelar"
                CancelacionFolio()
            Case "Buscar"
                Buscar()
            Case "Actualizar"
                CargaInformacion()
                CargaDatosExtra()
                FiltraclaseRuta()
            Case "Cerrar"
                Me.Close()
        End Select
    End Sub
    Private Sub mniGenerar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mniGenerar.Click
        Generar()
    End Sub
    Private Sub mniAsignar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mniAsignar.Click
        Asignar()
    End Sub
    Private Sub mniPrestamoOperador_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mniPrestamoOperador.Click
        PrestamoOperador()
    End Sub
    Private Sub mniPrestamoAutotanque_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mniPrestamoAutotanque.Click
        PrestamoAutotanque()
    End Sub
    Private Sub mniBuscar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mniBuscar.Click
        Buscar()
    End Sub
    Private Sub mniCancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mniCancelar.Click
        CancelacionFolio()
    End Sub
    Private Sub mniActualizar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mniActualizar.Click
        CargaInformacion()
        CargaDatosExtra()
        FiltraclaseRuta()
    End Sub
    Private Sub mniCerrarCiclo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mniCerrarCiclo.Click
        CerrarCiclo()
    End Sub
    Private Sub mniCerrar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mniCerrar.Click
        Me.Close()
    End Sub
#End Region

#Region "Rutinas de acciones especiales"
    Private Sub Generar()
        Dim frmGeneraAsignacion As New frmGeneraAsignacion(CInt(cboCelula.SelectedValue), dtpFAsignacion.Value.Date)
        If frmGeneraAsignacion.ShowDialog = DialogResult.OK Then
            frmGeneraAsignacion.Dispose()
            CargaInformacion()
            CargaDatosExtra()
            FiltraclaseRuta()
        End If
    End Sub
    Private Sub Asignar()
        If ValidaCambio() Then
            Dim frmAsignacionOperador As New frmAsignacionOperador(CInt(CampoFolio("Año")), CInt(CampoFolio("Folio")), CInt(cboCelula.SelectedValue), dtpFAsignacion.Value.Date, cboClaseRuta.SelectedValue)
            Dim Folio As String = CStr(CampoFolio("Folio"))
            frmAsignacionOperador.ShowDialog()
            CargaInformacion()
            CargaDatosExtra()
            FiltraclaseRuta()
            EncuentraRegistro(grdFolios, Folio, 0)
        End If
    End Sub
    Private Sub PrestamoOperador()
        Dim frmPrestamoOperador As New frmPrestamoOperador(CInt(cboCelula.SelectedValue), dtpFAsignacion.Value.Date)
        Dim Folio As String = CStr(CampoFolio("Folio"))
        If frmPrestamoOperador.ShowDialog = DialogResult.OK Then
            frmPrestamoOperador.Dispose()
            CargaInformacion()
            CargaDatosExtra()
            FiltraclaseRuta()
            EncuentraRegistro(grdFolios, Folio, 0)
        End If
    End Sub
    Private Sub PrestamoAutotanque()
        Dim frmPrestamoAutotanque As New frmPrestamoAutotanque(CInt(cboCelula.SelectedValue), dtpFAsignacion.Value.Date)
        Dim Folio As String = CStr(CampoFolio("Folio"))
        If frmPrestamoAutotanque.ShowDialog = DialogResult.OK Then
            frmPrestamoAutotanque.Dispose()
            CargaInformacion()
            CargaDatosExtra()
            EncuentraRegistro(grdFolios, Folio, 0)
        End If
    End Sub
    Private Sub AsignacionRuta()
        If ValidaCambio() Then
            Dim frmAsignacionRuta As New frmAsignacionRuta(CInt(cboCelula.SelectedValue), CInt(CampoFolio("Año")), CInt(CampoFolio("Folio")), CInt(CampoFolio("Autotanque")), CInt(CampoFolio("RutaAsignada")), CInt(cboClaseRuta.SelectedValue))
            Dim Folio As String = CStr(CampoFolio("Folio"))
            If frmAsignacionRuta.ShowDialog() = DialogResult.OK Then
                CargaInformacion()
                CargaDatosExtra()
                FiltraclaseRuta()
                EncuentraRegistro(grdFolios, Folio, 0)
            End If
        End If
    End Sub
    Private Sub CancelacionFolio()
        If ValidaCambio() Then
            Dim frmCancelacionFolio As New frmCancelacionFolio(CInt(CampoFolio("Año")), CInt(CampoFolio("Folio")), CInt(CampoFolio("Autotanque")), CInt(CampoFolio("RutaAsignada")), dtpFAsignacion.Value.Date)
            Dim Folio As String = CStr(CampoFolio("Folio"))
            If frmCancelacionFolio.ShowDialog() = DialogResult.OK Then
                CargaInformacion()
                CargaDatosExtra()
                FiltraclaseRuta()
                EncuentraRegistro(grdFolios, Folio, 0)
            End If
        End If
    End Sub
    Private Sub Buscar()
        Dim frmBusquedaFolios As New frmBusquedaFolios()
        Dim Result As DialogResult = frmBusquedaFolios.ShowDialog
        Select Case Result
            Case DialogResult.Abort
                frmBusquedaFolios.Dispose()
            Case DialogResult.OK
                FiltroBusqueda(frmBusquedaFolios)
                frmBusquedaFolios.Dispose()
        End Select
    End Sub
    Private Sub FiltroBusqueda(ByVal frmFiltro As frmBusquedaFolios)
        Dim dtBusquedaFolio As New DataTable()
        Dim TextoFiltro As String = "   "
        Dim DatosFiltrados As DataView
        dtBusquedaFolio = dsAsignacionInicial.Tables("Folios").Copy
        With frmFiltro
            If .rdoTodos.Checked Then
                If .txtFolio.Text.Trim <> "" Then
                    TextoFiltro &= "Folio = " & .txtFolio.Text.Trim & " AND"
                End If
                If .txtAutotanque.Text.Trim <> "" Then
                    TextoFiltro &= " Autotanque = " & .txtAutotanque.Text.Trim & " AND"
                End If
                If .txtRuta.Text.Trim <> "" Then
                    TextoFiltro &= " RutaAsignada = " & .txtRuta.Text.Trim & " AND"
                End If
                If .txtPlacas.Text.Trim <> "" Then
                    TextoFiltro &= " Placas = " & .txtPlacas.Text.Trim & " AND"
                End If
                TextoFiltro = TextoFiltro.Substring(0, TextoFiltro.Length - 3)
            Else
                If .txtFolio.Text.Trim <> "" Then
                    TextoFiltro &= "Folio = " & .txtFolio.Text.Trim & " OR"
                End If
                If .txtAutotanque.Text.Trim <> "" Then
                    TextoFiltro &= " Autotanque = " & .txtAutotanque.Text.Trim & " OR"
                End If
                If .txtRuta.Text.Trim <> "" Then
                    TextoFiltro &= " RutaAsignada = " & .txtRuta.Text.Trim & " OR"
                End If
                If .txtPlacas.Text.Trim <> "" Then
                    TextoFiltro &= " Placas = " & .txtPlacas.Text.Trim & " OR"
                End If
                TextoFiltro = TextoFiltro.Substring(0, TextoFiltro.Length - 2)
            End If
        End With
        dtBusquedaFolio.DefaultView.RowFilter = TextoFiltro
        DatosFiltrados = dtBusquedaFolio.DefaultView
        If DatosFiltrados.Count > 0 Then
            dtBusquedaFolio = View2Table(DatosFiltrados)
            EncuentraRegistro(grdFolios, CStr(dtBusquedaFolio.Rows(0)("Folio")))
        End If
    End Sub
    Private Function View2Table(ByVal view As DataView) As DataTable
        Dim dtResult As New DataTable()
        Dim RowIndex, ColumnIndex As Integer
        Dim IArray(view.Table.Columns.Count - 1) As Object
        dtResult = view.Table.Clone
        For RowIndex = 0 To view.Count - 1
            For ColumnIndex = 0 To view.Table.Columns.Count - 1
                IArray(ColumnIndex) = view.Item(RowIndex)(ColumnIndex)
            Next
            dtResult.Rows.Add(IArray)
        Next
        Return dtResult
    End Function
    Private Sub btnEditarAutotanqueNA_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnEditarAutotanqueNA.Click
        If Not vgrdAutotanquesSinAsignar.CurrentRow Is Nothing Then
            Dim frmEditaMotivoAutotanqueNA As New frmEditaMotivoAutotanqueNA(dtpFAsignacion.Value.Date, CInt(vgrdAutotanquesSinAsignar.CurrentRow("Autotanque")))
            frmEditaMotivoAutotanqueNA.ShowDialog()
            If frmEditaMotivoAutotanqueNA.DialogResult = DialogResult.OK Then
                CargaAutotanquesSinAsignar()
            End If
        End If
    End Sub
    Private Sub btnDevuelveEmpleado_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDevuelveEmpleado.Click
        If dtpFAsignacion.Value.Date < Now.Date Then
            ErrMessage("Las devoluciones son permitidas únicamente el día de la asignación.")
        ElseIf Not vgrdEmpleadosPrestados.CurrentRow Is Nothing Then
            If MessageBox.Show("¿Desea devolver al operador " & CStr(vgrdEmpleadosPrestados.CurrentRow("Operador")) & " " & CStr(vgrdEmpleadosPrestados.CurrentRow("Nombre")) & "?", Application.ProductName & _
                        " v." & Application.ProductVersion, MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
                Dim cmdLogistica As New SqlCommand("exec spLOGDevuelveOperador @Operador, @FPrestamo, @Celula", cnSigamet)
                cmdLogistica.Parameters.Add("@Operador", SqlDbType.Int).Value = CInt(vgrdEmpleadosPrestados.CurrentRow("Operador"))
                cmdLogistica.Parameters.Add("@FPrestamo", SqlDbType.DateTime).Value = dtpFAsignacion.Value.Date
                cmdLogistica.Parameters.Add("@Celula", SqlDbType.TinyInt).Value = CInt(cboCelula.SelectedValue)
                Try
                    Me.Cursor = Cursors.WaitCursor
                    cnSigamet.Open()
                    cmdLogistica.ExecuteNonQuery()
                    CargaEmpleadosPrestados()
                Catch ex As Exception
                    ExMessage(ex)
                Finally
                    cnSigamet.Close()
                    cmdLogistica.Dispose()
                    Me.Cursor = Cursors.Default
                End Try
            End If
        End If
    End Sub
    Private Sub btnDevuelveAutotanque_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDevuelveAutotanque.Click
        If dtpFAsignacion.Value.Date < Now.Date Then
            ErrMessage("Las devoluciones son permitidas únicamente el día de la asignación.")
        ElseIf Not vgrdAutotanquesPrestados.CurrentRow Is Nothing Then
            If MessageBox.Show("¿Desea devolver al autotanque No. " & CStr(vgrdAutotanquesPrestados.CurrentRow("Autotanque")) & "?", Application.ProductName & _
                                " v." & Application.ProductVersion, MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
                Dim cmdLogistica As New SqlCommand("exec spLOGDevuelveAutotanque @Autotanque,@FPrestamo", cnSigamet)
                cmdLogistica.Parameters.Add("@Autotanque", SqlDbType.Int).Value = CInt(vgrdAutotanquesPrestados.CurrentRow("Autotanque"))
                cmdLogistica.Parameters.Add("@FPrestamo", SqlDbType.DateTime).Value = dtpFAsignacion.Value.Date
                Try
                    Me.Cursor = Cursors.WaitCursor
                    cnSigamet.Open()
                    cmdLogistica.ExecuteNonQuery()
                    CargaAutotanquesPrestados()
                Catch ex As Exception
                    ExMessage(ex)
                Finally
                    cnSigamet.Close()
                    cmdLogistica.Dispose()
                    Me.Cursor = Cursors.Default
                End Try
            End If
        End If
    End Sub
    Private Sub btnEditaEmpleadoSinAsignar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnEditaEmpleadoSinAsignar.Click
        MessageBox.Show("Esta función no ha sido implementada", Application.ProductName & " v." & Application.ProductVersion, MessageBoxButtons.OK, MessageBoxIcon.Information)
    End Sub
#End Region

#Region "Recordatorios al cierre de la ventana"
    Private Sub frmAsignacion_Closing(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles MyBase.Closing
        Dim daLogistica As New SqlClient.SqlDataAdapter("exec spLogApoyosFaltantes @FInicial, @Celula", cnSigamet)
        Dim dtRutas As New DataTable()
        daLogistica.SelectCommand.Parameters.Add("@Celula", SqlDbType.TinyInt).Value = CInt(cboCelula.SelectedValue)
        daLogistica.SelectCommand.Parameters.Add("@FInicial", SqlDbType.DateTime).Value = dtpFAsignacion.Value.Date
        Try
            daLogistica.Fill(dtRutas)
            If dtRutas.Rows.Count > 0 AndAlso ValidaCambio() Then
                Dim frmRutasDuplicadas As New frmRutasDuplicadas(dtRutas)
                If frmRutasDuplicadas.ShowDialog = DialogResult.OK Then
                    frmRutasDuplicadas.Dispose()
                    e.Cancel = True
                    EncuentraRegistro(grdFolios, CStr(dtRutas.Rows(0)("Ruta")), 2)
                Else
                    Me.Dispose()
                End If
            End If
        Catch ex As Exception
            ExMessage(ex)
        Finally
            daLogistica.Dispose()
        End Try
    End Sub
#End Region




    

    Private Sub CerrarCiclo()
        Dim cmdLogistica As New SqlClient.SqlCommand("Update AutoTanqueTurno set StatusBascula='CERRADO', StatusLogistica='CIERRE', FTerminoRuta = getdate(), LitrosLiquidados = 1" & _
                                                                    "where AñoAtt=@Año and Folio = @Folio", cnSigamet)
        Dim rdrInsert As SqlClient.SqlDataReader = Nothing
        If CStr(CampoFolio("Folio")) <> "" Then
            If MessageBox.Show("¿Desea cerrar el ciclo del autotanque " & CStr(CampoFolio("Autotanque")) & " del día " & dtpFAsignacion.Value.ToShortDateString & "?", _
                        Application.ProductName & " v." & Application.ProductVersion, MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) = DialogResult.Yes Then

                cmdLogistica.Parameters.Add("@Año", SqlDbType.SmallInt).Value = CInt(CampoFolio("Año"))
                cmdLogistica.Parameters.Add("@Folio", SqlDbType.Int).Value = CInt(CampoFolio("Folio"))
                Try
                    cnSigamet.Open()
                    cmdLogistica.ExecuteNonQuery()
                    MessageBox.Show("Se ha cerrado el ciclo.", Application.ProductName & " v." & Application.ProductVersion, MessageBoxButtons.OK, MessageBoxIcon.Information)
                    CargaInformacion()
                    FiltraclaseRuta()
                Catch ex As Exception
                    ExMessage(ex)
                Finally
                    cnSigamet.Close()
                End Try

            End If
        End If
    End Sub


    Private Sub cboCelula_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles cboCelula.SelectedIndexChanged
        'If Loaded AndAlso Not cboCelula.SelectedValue Is Nothing Then
        '    cboClaseRuta.Enabled = True
        '    FiltraclaseRuta()
        'End If
    End Sub
    Private Sub FiltraclaseRuta()
        If Not String.IsNullOrEmpty(cboClaseRuta.Text) And cboClaseRuta.Enabled = True Then
            Dim dtFolios As DataTable = dsAsignacionInicial.Tables("Folios")
            Dim vwFolios As New DataView(dtFolios)
            vwFolios.RowFilter = "ClaseRuta='" & cboClaseRuta.Text & "'"
            grdFolios.DataSource = vwFolios
        End If
    End Sub
    Private Sub FiltraDatosExtra()
        If cboClaseRuta.Enabled And cboCelula.SelectedIndex <> -1 Then
            vgrdEmpleadosSinAsignar.DataSource = Nothing
            Dim dtEmpleadosSinAsignar As DataTable = dsDatosExtra.Tables("EmpleadosSinAsignar")
            Dim vwEmpleadosSinAsignar As New DataView(dtEmpleadosSinAsignar)
            vwEmpleadosSinAsignar.RowFilter = "Clasificacion In(" + FiltroClasfificacionOperador(cboClaseRuta.SelectedValue, True) + ")"
            vgrdEmpleadosSinAsignar.DataSource = vwEmpleadosSinAsignar
        Else
            vgrdEmpleadosSinAsignar.DataSource = dsDatosExtra.Tables("EmpleadosSinAsignar")
        End If
    End Sub

    Public Function FiltroClasfificacionOperador(ByVal claseRuta As Integer, ByVal porDescripcion As Boolean) As String
        Dim filtro As String = ""
        Dim cmdFiltro As New SqlCommand("spLogClasificacionOperadorClaseRuta @ClaseRuta", cnSigamet)
        Dim daFiltro As New SqlDataAdapter(cmdFiltro)
        Dim drfiltro As SqlDataReader

        If cnSigamet.State = ConnectionState.Closed Then
            cnSigamet.Open()
        End If        
        cmdFiltro.Parameters.Add("@Claseruta", SqlDbType.SmallInt).Value = claseRuta
        drfiltro = cmdFiltro.ExecuteReader

        While drfiltro.Read
            If porDescripcion Then
                filtro += "'" + drfiltro.Item("Descripcion").ToString() + "',"
            Else
                filtro += drfiltro.Item("Descripcion").ToString() + ","
            End If
        End While

        If cnSigamet.State = ConnectionState.Open Then
            cnSigamet.Close()
        End If

        filtro = Strings.Left(filtro, Strings.Len(filtro) - 1)

        Return filtro
    End Function

    Private Sub frmAsignacion_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        If Loaded AndAlso Not cboCelula.SelectedValue Is Nothing Then
            cboClaseRuta.Enabled = True
            CargaInformacion()
            CargaDatosExtra()
            FiltraclaseRuta()
        End If
    End Sub
End Class



