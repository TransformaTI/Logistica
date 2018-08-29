Imports System
Imports System.Data.SqlClient
Imports System.IO
Imports Logistica



Public Class frmAsignacionPostureros
    Inherits System.Windows.Forms.Form


#Region " Windows Form Designer generated code "

    Public Sub New()
        MyBase.New()

        'This call is required by the Windows Form Designer.
        InitializeComponent()

        'Add any initialization after the InitializeComponent() call
        Dim cmdLogistica As New SqlClient.SqlCommand("Select TipoAsignacionAutotanque, Descripcion from TipoAsignacionAutotanque", cnSigamet)
        Dim daLogistica As New SqlClient.SqlDataAdapter(cmdLogistica)
        Dim dtAsignacion As New DataTable()
        Dim dtCelula As New DataTable()
        Dim dtTipoASignacion As New DataTable()
        LoadCompleted = False
        'Asignación de fecha actual
        dtpFAsignacion.Value = Now.Date
        dsAsignacionInicial.Tables.Add("Folios")
        dsAsignacionInicial.Tables.Add("Operadores")
        cmdLogistica.Parameters.Add("@Usuario", SqlDbType.Char).Value = _Usuario
        Try
            daLogistica.Fill(dtAsignacion)
            
            cmdLogistica.CommandText = "Select TipoAsignacionAutotanque, Descripcion from TipoAsignacionAutotanque"
            daLogistica.Fill(dtTipoASignacion)
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
        

        'Parametrizaciones
        If Not _MuestraAsistencia Then
            ReDim Preserve vgrdOperadores.HidedColumnNames(vgrdOperadores.HidedColumnNames.Length)
            ReDim Preserve vgrdEmpleadosSinAsignar.HidedColumnNames(vgrdEmpleadosSinAsignar.HidedColumnNames.Length)
           
            vgrdOperadores.HidedColumnNames(vgrdOperadores.HidedColumnNames.Length - 1) = "EnPlanta"
            vgrdEmpleadosSinAsignar.HidedColumnNames(vgrdEmpleadosSinAsignar.HidedColumnNames.Length - 1) = "EnPlanta"
          

        End If

        Me.ForeColor = Color.Black
        LoadCompleted = True
        CargaInformacion()
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
    Friend WithEvents btnAsignar As System.Windows.Forms.ToolBarButton
    Friend WithEvents btnCancelar As System.Windows.Forms.ToolBarButton
    Friend WithEvents btnRuta As System.Windows.Forms.ToolBarButton
    Friend WithEvents btnBuscar As System.Windows.Forms.ToolBarButton
    Friend WithEvents btnRefrescar As System.Windows.Forms.ToolBarButton
    Friend WithEvents btnCerrar As System.Windows.Forms.ToolBarButton
    Friend WithEvents imgHerramientas As System.Windows.Forms.ImageList
    Friend WithEvents Sep1 As System.Windows.Forms.ToolBarButton
    Friend WithEvents Sep3 As System.Windows.Forms.ToolBarButton
    Friend WithEvents Sep4 As System.Windows.Forms.ToolBarButton
    Friend WithEvents Sep5 As System.Windows.Forms.ToolBarButton
    Friend WithEvents Sep6 As System.Windows.Forms.ToolBarButton
    Friend WithEvents Sep7 As System.Windows.Forms.ToolBarButton
    Friend WithEvents lblFAsignacion As System.Windows.Forms.Label
    Friend WithEvents dtpFAsignacion As System.Windows.Forms.DateTimePicker
    Friend WithEvents pnlOpciones As System.Windows.Forms.Panel
    Friend WithEvents pnlBase As System.Windows.Forms.Panel
    Friend WithEvents splGrids As System.Windows.Forms.Splitter
    Friend WithEvents mniAsignacion As System.Windows.Forms.MenuItem
    Friend WithEvents mniAsignar As System.Windows.Forms.MenuItem
    Friend WithEvents mniCancelar As System.Windows.Forms.MenuItem
    Friend WithEvents mniBuscar As System.Windows.Forms.MenuItem
    Friend WithEvents mniRefrescar As System.Windows.Forms.MenuItem
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
    Friend WithEvents Celula As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents Producto As System.Windows.Forms.DataGridTextBoxColumn
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(frmAsignacionPostureros))
        Me.mnuAsignacion = New System.Windows.Forms.MainMenu()
        Me.mniAsignacion = New System.Windows.Forms.MenuItem()
        Me.mniAsignacionR = New System.Windows.Forms.MenuItem()
        Me.mniAsignar = New System.Windows.Forms.MenuItem()
        Me.mniBuscar = New System.Windows.Forms.MenuItem()
        Me.mniCancelar = New System.Windows.Forms.MenuItem()
        Me.mniRefrescar = New System.Windows.Forms.MenuItem()
        Me.mniCerrar = New System.Windows.Forms.MenuItem()
        Me.tbInicioRuta = New System.Windows.Forms.ToolBar()
        Me.btnAsignar = New System.Windows.Forms.ToolBarButton()
        Me.Sep1 = New System.Windows.Forms.ToolBarButton()
        Me.btnRuta = New System.Windows.Forms.ToolBarButton()
        Me.Sep3 = New System.Windows.Forms.ToolBarButton()
        Me.btnCancelar = New System.Windows.Forms.ToolBarButton()
        Me.Sep4 = New System.Windows.Forms.ToolBarButton()
        Me.btnBuscar = New System.Windows.Forms.ToolBarButton()
        Me.Sep5 = New System.Windows.Forms.ToolBarButton()
        Me.btnRefrescar = New System.Windows.Forms.ToolBarButton()
        Me.Sep6 = New System.Windows.Forms.ToolBarButton()
        Me.btnCerrar = New System.Windows.Forms.ToolBarButton()
        Me.Sep7 = New System.Windows.Forms.ToolBarButton()
        Me.imgHerramientas = New System.Windows.Forms.ImageList(Me.components)
        Me.lblFAsignacion = New System.Windows.Forms.Label()
        Me.dtpFAsignacion = New System.Windows.Forms.DateTimePicker()
        Me.pnlOpciones = New System.Windows.Forms.Panel()
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
        Me.pnlOperadores = New System.Windows.Forms.Panel()
        Me.vgrdOperadores = New Logistica.ViewGrid()
        Me.lblOperadores = New System.Windows.Forms.Label()
        Me.grdFolios = New System.Windows.Forms.DataGrid()
        Me.tbsFolio = New System.Windows.Forms.DataGridTableStyle()
        Me.Folio = New System.Windows.Forms.DataGridTextBoxColumn()
        Me.Celula = New System.Windows.Forms.DataGridTextBoxColumn()
        Me.Autotanque = New System.Windows.Forms.DataGridTextBoxColumn()
        Me.RutaAsignada = New System.Windows.Forms.DataGridTextBoxColumn()
        Me.TipoAsignacion = New System.Windows.Forms.DataGridTextBoxColumn()
        Me.RutaOriginal = New System.Windows.Forms.DataGridTextBoxColumn()
        Me.Placas = New System.Windows.Forms.DataGridTextBoxColumn()
        Me.StatusLogistica = New System.Windows.Forms.DataGridTextBoxColumn()
        Me.FAsignacion = New System.Windows.Forms.DataGridTextBoxColumn()
        Me.TipoVehiculo = New System.Windows.Forms.DataGridTextBoxColumn()
        Me.Producto = New System.Windows.Forms.DataGridTextBoxColumn()
        Me.btnEditarEmpleadosNA = New System.Windows.Forms.Button()
        Me.rgrpEditarEmpleadorNA = New Logistica.RoundedGroupBox()
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
        Me.mniAsignacion.MergeType = System.Windows.Forms.MenuMerge.MergeItems
        Me.mniAsignacion.Text = "&Asignación"
        '
        'mniAsignacionR
        '
        Me.mniAsignacionR.Index = 0
        Me.mniAsignacionR.MenuItems.AddRange(New System.Windows.Forms.MenuItem() {Me.mniAsignar, Me.mniBuscar, Me.mniCancelar, Me.mniRefrescar, Me.mniCerrar})
        Me.mniAsignacionR.MergeOrder = 1
        Me.mniAsignacionR.Text = "&Asignación de postureros"
        '
        'mniAsignar
        '
        Me.mniAsignar.Index = 0
        Me.mniAsignar.Shortcut = System.Windows.Forms.Shortcut.Ins
        Me.mniAsignar.Text = "&Asignar"
        '
        'mniBuscar
        '
        Me.mniBuscar.Index = 1
        Me.mniBuscar.Shortcut = System.Windows.Forms.Shortcut.CtrlB
        Me.mniBuscar.Text = "&Buscar"
        '
        'mniCancelar
        '
        Me.mniCancelar.Index = 2
        Me.mniCancelar.Text = "Cancela&r"
        '
        'mniRefrescar
        '
        Me.mniRefrescar.Index = 3
        Me.mniRefrescar.Shortcut = System.Windows.Forms.Shortcut.F5
        Me.mniRefrescar.Text = "&Refrescar"
        '
        'mniCerrar
        '
        Me.mniCerrar.Index = 4
        Me.mniCerrar.Text = "&Cerrar"
        '
        'tbInicioRuta
        '
        Me.tbInicioRuta.Appearance = System.Windows.Forms.ToolBarAppearance.Flat
        Me.tbInicioRuta.Buttons.AddRange(New System.Windows.Forms.ToolBarButton() {Me.btnAsignar, Me.Sep1, Me.btnRuta, Me.Sep3, Me.btnCancelar, Me.Sep4, Me.btnBuscar, Me.Sep5, Me.btnRefrescar, Me.Sep6, Me.btnCerrar, Me.Sep7})
        Me.tbInicioRuta.ButtonSize = New System.Drawing.Size(64, 36)
        Me.tbInicioRuta.DropDownArrows = True
        Me.tbInicioRuta.ImageList = Me.imgHerramientas
        Me.tbInicioRuta.Name = "tbInicioRuta"
        Me.tbInicioRuta.ShowToolTips = True
        Me.tbInicioRuta.Size = New System.Drawing.Size(1176, 39)
        Me.tbInicioRuta.TabIndex = 0
        '
        'btnAsignar
        '
        Me.btnAsignar.ImageIndex = 1
        Me.btnAsignar.Text = "Asignar"
        Me.btnAsignar.ToolTipText = "Modifica la asignación"
        '
        'Sep1
        '
        Me.Sep1.Style = System.Windows.Forms.ToolBarButtonStyle.Separator
        '
        'btnRuta
        '
        Me.btnRuta.ImageIndex = 5
        Me.btnRuta.Text = "Ruta"
        Me.btnRuta.ToolTipText = "Cambio y asignación de ruta"
        '
        'Sep3
        '
        Me.Sep3.Style = System.Windows.Forms.ToolBarButtonStyle.Separator
        '
        'btnCancelar
        '
        Me.btnCancelar.ImageIndex = 6
        Me.btnCancelar.Text = "Cancelar"
        Me.btnCancelar.ToolTipText = "Cancelar la salida del autotanque"
        '
        'Sep4
        '
        Me.Sep4.Style = System.Windows.Forms.ToolBarButtonStyle.Separator
        '
        'btnBuscar
        '
        Me.btnBuscar.ImageIndex = 7
        Me.btnBuscar.Text = "Buscar"
        Me.btnBuscar.ToolTipText = "Busca un registro"
        '
        'Sep5
        '
        Me.Sep5.Style = System.Windows.Forms.ToolBarButtonStyle.Separator
        '
        'btnRefrescar
        '
        Me.btnRefrescar.ImageIndex = 8
        Me.btnRefrescar.Text = "Refrescar"
        Me.btnRefrescar.ToolTipText = "Actualiza los datos"
        '
        'Sep6
        '
        Me.Sep6.Style = System.Windows.Forms.ToolBarButtonStyle.Separator
        '
        'btnCerrar
        '
        Me.btnCerrar.ImageIndex = 9
        Me.btnCerrar.Text = "Cerrar"
        Me.btnCerrar.ToolTipText = "Cerrar la ventana de asignación"
        '
        'Sep7
        '
        Me.Sep7.Style = System.Windows.Forms.ToolBarButtonStyle.Separator
        '
        'imgHerramientas
        '
        Me.imgHerramientas.ColorDepth = System.Windows.Forms.ColorDepth.Depth8Bit
        Me.imgHerramientas.ImageSize = New System.Drawing.Size(16, 16)
        Me.imgHerramientas.ImageStream = CType(resources.GetObject("imgHerramientas.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.imgHerramientas.TransparentColor = System.Drawing.Color.Transparent
        '
        'lblFAsignacion
        '
        Me.lblFAsignacion.AutoSize = True
        Me.lblFAsignacion.Location = New System.Drawing.Point(12, 8)
        Me.lblFAsignacion.Name = "lblFAsignacion"
        Me.lblFAsignacion.Size = New System.Drawing.Size(38, 14)
        Me.lblFAsignacion.TabIndex = 1
        Me.lblFAsignacion.Text = "&Fecha:"
        '
        'dtpFAsignacion
        '
        Me.dtpFAsignacion.Format = System.Windows.Forms.DateTimePickerFormat.Short
        Me.dtpFAsignacion.Location = New System.Drawing.Point(56, 5)
        Me.dtpFAsignacion.MinDate = New Date(1999, 1, 1, 0, 0, 0, 0)
        Me.dtpFAsignacion.Name = "dtpFAsignacion"
        Me.dtpFAsignacion.Size = New System.Drawing.Size(121, 21)
        Me.dtpFAsignacion.TabIndex = 2
        '
        'pnlOpciones
        '
        Me.pnlOpciones.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.pnlOpciones.Controls.AddRange(New System.Windows.Forms.Control() {Me.lblFAsignacion, Me.dtpFAsignacion})
        Me.pnlOpciones.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnlOpciones.Location = New System.Drawing.Point(0, 39)
        Me.pnlOpciones.Name = "pnlOpciones"
        Me.pnlOpciones.Size = New System.Drawing.Size(1176, 33)
        Me.pnlOpciones.TabIndex = 107
        '
        'cboTipoAsignacion
        '
        Me.cboTipoAsignacion.BackColor = System.Drawing.Color.WhiteSmoke
        Me.cboTipoAsignacion.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboTipoAsignacion.Location = New System.Drawing.Point(1048, 80)
        Me.cboTipoAsignacion.Name = "cboTipoAsignacion"
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
        Me.pnlDatosExtra.Controls.AddRange(New System.Windows.Forms.Control() {Me.rgpDatosExtra})
        Me.pnlDatosExtra.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.pnlDatosExtra.DockPadding.All = 5
        Me.pnlDatosExtra.Location = New System.Drawing.Point(0, 493)
        Me.pnlDatosExtra.Name = "pnlDatosExtra"
        Me.pnlDatosExtra.Size = New System.Drawing.Size(1176, 176)
        Me.pnlDatosExtra.TabIndex = 113
        '
        'rgpDatosExtra
        '
        Me.rgpDatosExtra.BorderColor = System.Drawing.Color.Gray
        Me.rgpDatosExtra.Controls.AddRange(New System.Windows.Forms.Control() {Me.pnlContenedor1})
        Me.rgpDatosExtra.Dock = System.Windows.Forms.DockStyle.Fill
        Me.rgpDatosExtra.FlatStyle = Logistica.RoundedGroupBox.Style.Pipe
        Me.rgpDatosExtra.Location = New System.Drawing.Point(5, 5)
        Me.rgpDatosExtra.Name = "rgpDatosExtra"
        Me.rgpDatosExtra.Size = New System.Drawing.Size(1166, 166)
        Me.rgpDatosExtra.TabIndex = 108
        Me.rgpDatosExtra.TabStop = False
        Me.rgpDatosExtra.TextAlignment = System.Windows.Forms.HorizontalAlignment.Left
        '
        'pnlContenedor1
        '
        Me.pnlContenedor1.Controls.AddRange(New System.Windows.Forms.Control() {Me.tabInformacion})
        Me.pnlContenedor1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pnlContenedor1.DockPadding.All = 5
        Me.pnlContenedor1.Location = New System.Drawing.Point(3, 17)
        Me.pnlContenedor1.Name = "pnlContenedor1"
        Me.pnlContenedor1.Size = New System.Drawing.Size(1160, 146)
        Me.pnlContenedor1.TabIndex = 113
        '
        'tabInformacion
        '
        Me.tabInformacion.Appearance = System.Windows.Forms.TabAppearance.FlatButtons
        Me.tabInformacion.Controls.AddRange(New System.Windows.Forms.Control() {Me.tabEmpleadosSinAsignar, Me.tabAutotanquesSinAsignar})
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
        Me.tabEmpleadosSinAsignar.Controls.AddRange(New System.Windows.Forms.Control() {Me.vgrdEmpleadosSinAsignar, Me.pnlEditarEmpleadosNA})
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
        Me.vgrdEmpleadosSinAsignar.MultiSelect = False
        Me.vgrdEmpleadosSinAsignar.Name = "vgrdEmpleadosSinAsignar"
        Me.vgrdEmpleadosSinAsignar.PKColumnNames = Nothing
        Me.vgrdEmpleadosSinAsignar.Size = New System.Drawing.Size(1038, 107)
        Me.vgrdEmpleadosSinAsignar.TabIndex = 1
        Me.vgrdEmpleadosSinAsignar.View = System.Windows.Forms.View.Details
        '
        'pnlEditarEmpleadosNA
        '
        Me.pnlEditarEmpleadosNA.BackColor = System.Drawing.Color.Gainsboro
        Me.pnlEditarEmpleadosNA.Controls.AddRange(New System.Windows.Forms.Control() {Me.rgrpEmpleadoSA})
        Me.pnlEditarEmpleadosNA.Dock = System.Windows.Forms.DockStyle.Right
        Me.pnlEditarEmpleadosNA.DockPadding.All = 5
        Me.pnlEditarEmpleadosNA.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.pnlEditarEmpleadosNA.ForeColor = System.Drawing.SystemColors.ControlText
        Me.pnlEditarEmpleadosNA.Location = New System.Drawing.Point(1038, 0)
        Me.pnlEditarEmpleadosNA.Name = "pnlEditarEmpleadosNA"
        Me.pnlEditarEmpleadosNA.Size = New System.Drawing.Size(104, 107)
        Me.pnlEditarEmpleadosNA.TabIndex = 2
        '
        'rgrpEmpleadoSA
        '
        Me.rgrpEmpleadoSA.BorderColor = System.Drawing.Color.Gainsboro
        Me.rgrpEmpleadoSA.Controls.AddRange(New System.Windows.Forms.Control() {Me.btnEditaEmpleadoSinAsignar})
        Me.rgrpEmpleadoSA.Dock = System.Windows.Forms.DockStyle.Fill
        Me.rgrpEmpleadoSA.FlatStyle = Logistica.RoundedGroupBox.Style.Road
        Me.rgrpEmpleadoSA.Location = New System.Drawing.Point(5, 5)
        Me.rgrpEmpleadoSA.Name = "rgrpEmpleadoSA"
        Me.rgrpEmpleadoSA.Size = New System.Drawing.Size(94, 97)
        Me.rgrpEmpleadoSA.TabIndex = 1
        Me.rgrpEmpleadoSA.TabStop = False
        Me.rgrpEmpleadoSA.TextAlignment = System.Windows.Forms.HorizontalAlignment.Left
        '
        'btnEditaEmpleadoSinAsignar
        '
        Me.btnEditaEmpleadoSinAsignar.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnEditaEmpleadoSinAsignar.Image = CType(resources.GetObject("btnEditaEmpleadoSinAsignar.Image"), System.Drawing.Bitmap)
        Me.btnEditaEmpleadoSinAsignar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnEditaEmpleadoSinAsignar.ImageIndex = 10
        Me.btnEditaEmpleadoSinAsignar.ImageList = Me.imgHerramientas
        Me.btnEditaEmpleadoSinAsignar.Location = New System.Drawing.Point(8, 24)
        Me.btnEditaEmpleadoSinAsignar.Name = "btnEditaEmpleadoSinAsignar"
        Me.btnEditaEmpleadoSinAsignar.TabIndex = 114
        Me.btnEditaEmpleadoSinAsignar.Text = "Editar"
        Me.btnEditaEmpleadoSinAsignar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'tabAutotanquesSinAsignar
        '
        Me.tabAutotanquesSinAsignar.BackColor = System.Drawing.Color.Gainsboro
        Me.tabAutotanquesSinAsignar.Controls.AddRange(New System.Windows.Forms.Control() {Me.vgrdAutotanquesSinAsignar, Me.pnlEditarAutotanqueNA})
        Me.tabAutotanquesSinAsignar.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tabAutotanquesSinAsignar.Location = New System.Drawing.Point(4, 25)
        Me.tabAutotanquesSinAsignar.Name = "tabAutotanquesSinAsignar"
        Me.tabAutotanquesSinAsignar.Size = New System.Drawing.Size(1142, 107)
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
        Me.vgrdAutotanquesSinAsignar.MultiSelect = False
        Me.vgrdAutotanquesSinAsignar.Name = "vgrdAutotanquesSinAsignar"
        Me.vgrdAutotanquesSinAsignar.PKColumnNames = Nothing
        Me.vgrdAutotanquesSinAsignar.Size = New System.Drawing.Size(1038, 107)
        Me.vgrdAutotanquesSinAsignar.TabIndex = 4
        Me.vgrdAutotanquesSinAsignar.View = System.Windows.Forms.View.Details
        '
        'pnlEditarAutotanqueNA
        '
        Me.pnlEditarAutotanqueNA.Controls.AddRange(New System.Windows.Forms.Control() {Me.rgrpAutotanqueNA})
        Me.pnlEditarAutotanqueNA.Dock = System.Windows.Forms.DockStyle.Right
        Me.pnlEditarAutotanqueNA.DockPadding.All = 5
        Me.pnlEditarAutotanqueNA.Location = New System.Drawing.Point(1038, 0)
        Me.pnlEditarAutotanqueNA.Name = "pnlEditarAutotanqueNA"
        Me.pnlEditarAutotanqueNA.Size = New System.Drawing.Size(104, 107)
        Me.pnlEditarAutotanqueNA.TabIndex = 5
        '
        'rgrpAutotanqueNA
        '
        Me.rgrpAutotanqueNA.BorderColor = System.Drawing.Color.Gainsboro
        Me.rgrpAutotanqueNA.Controls.AddRange(New System.Windows.Forms.Control() {Me.btnEditarAutotanqueNA})
        Me.rgrpAutotanqueNA.Dock = System.Windows.Forms.DockStyle.Fill
        Me.rgrpAutotanqueNA.FlatStyle = Logistica.RoundedGroupBox.Style.Road
        Me.rgrpAutotanqueNA.Location = New System.Drawing.Point(5, 5)
        Me.rgrpAutotanqueNA.Name = "rgrpAutotanqueNA"
        Me.rgrpAutotanqueNA.Size = New System.Drawing.Size(94, 97)
        Me.rgrpAutotanqueNA.TabIndex = 0
        Me.rgrpAutotanqueNA.TabStop = False
        Me.rgrpAutotanqueNA.TextAlignment = System.Windows.Forms.HorizontalAlignment.Left
        '
        'btnEditarAutotanqueNA
        '
        Me.btnEditarAutotanqueNA.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnEditarAutotanqueNA.Image = CType(resources.GetObject("btnEditarAutotanqueNA.Image"), System.Drawing.Bitmap)
        Me.btnEditarAutotanqueNA.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnEditarAutotanqueNA.ImageIndex = 10
        Me.btnEditarAutotanqueNA.ImageList = Me.imgHerramientas
        Me.btnEditarAutotanqueNA.Location = New System.Drawing.Point(8, 24)
        Me.btnEditarAutotanqueNA.Name = "btnEditarAutotanqueNA"
        Me.btnEditarAutotanqueNA.TabIndex = 114
        Me.btnEditarAutotanqueNA.Text = "Editar"
        Me.btnEditarAutotanqueNA.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'pnlOperadores
        '
        Me.pnlOperadores.Controls.AddRange(New System.Windows.Forms.Control() {Me.vgrdOperadores, Me.lblOperadores})
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
        Me.vgrdOperadores.View = System.Windows.Forms.View.Details
        '
        'lblOperadores
        '
        Me.lblOperadores.BackColor = System.Drawing.Color.Maroon
        Me.lblOperadores.Dock = System.Windows.Forms.DockStyle.Top
        Me.lblOperadores.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblOperadores.ForeColor = System.Drawing.Color.White
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
        Me.grdFolios.Location = New System.Drawing.Point(0, 72)
        Me.grdFolios.Name = "grdFolios"
        Me.grdFolios.ParentRowsBackColor = System.Drawing.Color.Gainsboro
        Me.grdFolios.ReadOnly = True
        Me.grdFolios.RowHeaderWidth = 5
        Me.grdFolios.Size = New System.Drawing.Size(1176, 315)
        Me.grdFolios.TabIndex = 115
        Me.grdFolios.TableStyles.AddRange(New System.Windows.Forms.DataGridTableStyle() {Me.tbsFolio})
        '
        'tbsFolio
        '
        Me.tbsFolio.AlternatingBackColor = System.Drawing.Color.Gainsboro
        Me.tbsFolio.BackColor = System.Drawing.Color.White
        Me.tbsFolio.DataGrid = Me.grdFolios
        Me.tbsFolio.GridColumnStyles.AddRange(New System.Windows.Forms.DataGridColumnStyle() {Me.Folio, Me.Celula, Me.Autotanque, Me.RutaAsignada, Me.TipoAsignacion, Me.RutaOriginal, Me.Placas, Me.StatusLogistica, Me.FAsignacion, Me.TipoVehiculo, Me.Producto})
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
        Me.Folio.Width = 75
        '
        'Celula
        '
        Me.Celula.Format = ""
        Me.Celula.FormatInfo = Nothing
        Me.Celula.HeaderText = "Célula"
        Me.Celula.MappingName = "Celula"
        Me.Celula.Width = 75
        '
        'Autotanque
        '
        Me.Autotanque.Alignment = System.Windows.Forms.HorizontalAlignment.Center
        Me.Autotanque.Format = ""
        Me.Autotanque.FormatInfo = Nothing
        Me.Autotanque.HeaderText = "Autotanque"
        Me.Autotanque.MappingName = "Autotanque"
        Me.Autotanque.NullText = "--"
        Me.Autotanque.Width = 75
        '
        'RutaAsignada
        '
        Me.RutaAsignada.Format = ""
        Me.RutaAsignada.FormatInfo = Nothing
        Me.RutaAsignada.HeaderText = "Ruta asignada"
        Me.RutaAsignada.MappingName = "RutaAsignada"
        Me.RutaAsignada.NullText = "--"
        Me.RutaAsignada.Width = 75
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
        'RutaOriginal
        '
        Me.RutaOriginal.Format = ""
        Me.RutaOriginal.FormatInfo = Nothing
        Me.RutaOriginal.HeaderText = "Ruta original"
        Me.RutaOriginal.MappingName = "RutaOriginal"
        Me.RutaOriginal.NullText = "--"
        Me.RutaOriginal.Width = 75
        '
        'Placas
        '
        Me.Placas.Format = ""
        Me.Placas.FormatInfo = Nothing
        Me.Placas.HeaderText = "Placas"
        Me.Placas.MappingName = "Placas"
        Me.Placas.NullText = "--"
        Me.Placas.Width = 75
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
        'Producto
        '
        Me.Producto.Format = ""
        Me.Producto.FormatInfo = Nothing
        Me.Producto.HeaderText = "Producto"
        Me.Producto.MappingName = "Producto"
        Me.Producto.NullText = "--"
        Me.Producto.Width = 75
        '
        'btnEditarEmpleadosNA
        '
        Me.btnEditarEmpleadosNA.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnEditarEmpleadosNA.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnEditarEmpleadosNA.ImageList = Me.imgHerramientas
        Me.btnEditarEmpleadosNA.Location = New System.Drawing.Point(9, 24)
        Me.btnEditarEmpleadosNA.Name = "btnEditarEmpleadosNA"
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
        Me.rgrpEditarEmpleadorNA.TextAlignment = System.Windows.Forms.HorizontalAlignment.Left
        '
        'frmAsignacionPostureros
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 14)
        Me.BackColor = System.Drawing.Color.Gainsboro
        Me.ClientSize = New System.Drawing.Size(1176, 677)
        Me.Controls.AddRange(New System.Windows.Forms.Control() {Me.cboTipoAsignacion, Me.grdFolios, Me.splGrids, Me.pnlOperadores, Me.pnlOpciones, Me.tbInicioRuta, Me.splDatosExtra, Me.pnlDatosExtra, Me.pnlBase})
        Me.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Menu = Me.mnuAsignacion
        Me.Name = "frmAsignacionPostureros"
        Me.Text = "Asignacion de personal posturero"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.pnlOpciones.ResumeLayout(False)
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
        Me.pnlOperadores.ResumeLayout(False)
        CType(Me.grdFolios, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

#End Region

    Private dsAsignacionInicial As New DataSet()
    Private PermiteCambioTipoAsignacion, LoadCompleted As Boolean


#Region "Rutinas de actualizacion"
    Private Sub CargaInformacion()
        If LoadCompleted Then
            grdFolios.DataSource = Nothing
            grdFolios.CaptionText = ""
            vgrdOperadores.DataSource = Nothing
            Dim cmdLogistica As New SqlCommand("exec spLOGInformacionFoliosTotal @FAsignacion", cnSigamet)
            Dim daLogistica As New SqlDataAdapter(cmdLogistica)
            Dim PKColumns(0) As DataColumn
            Me.Cursor = Cursors.WaitCursor
            cmdLogistica.Parameters.Add("@FAsignacion", SqlDbType.DateTime).Value = dtpFAsignacion.Value.Date
            Try
                dsAsignacionInicial.Tables("Folios").Clear()
                daLogistica.Fill(dsAsignacionInicial.Tables("Folios"))
                PKColumns(0) = dsAsignacionInicial.Tables("Folios").Columns("Folio")
                dsAsignacionInicial.Tables("Folios").PrimaryKey = PKColumns
                cmdLogistica.CommandText = "exec spLOGInformacionTripulacionTotal @FAsignacion"
                dsAsignacionInicial.Tables("Operadores").Clear()
                daLogistica.Fill(dsAsignacionInicial.Tables("Operadores"))
                GridData(grdFolios, dsAsignacionInicial.Tables("Folios"), 0, 10)
                grdFolios.CaptionText = "Folios del " & dtpFAsignacion.Value.ToShortDateString
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
        If LoadCompleted Then
            Me.Cursor = Cursors.WaitCursor
            CargaAutotanquesSinAsignar()
            CargaEmpleadosSinAsignar()
            Me.Cursor = Cursors.Default
        End If
    End Sub
    Private Sub CargaAutotanquesSinAsignar()
        Dim daLogistica As New SqlDataAdapter("exec spLOGAutotanqueSinAsignarTotal @FAsignacion", cnSigamet)
        Dim dtAttSinAsignar As New DataTable()
        vgrdAutotanquesSinAsignar.DataSource = Nothing
        daLogistica.SelectCommand.Parameters.Add("@FAsignacion", SqlDbType.DateTime).Value = dtpFAsignacion.Value.Date
        Try
            daLogistica.Fill(dtAttSinAsignar)
        Catch ex As Exception
            ExMessage(ex)
        Finally
            daLogistica.Dispose()
        End Try
        vgrdAutotanquesSinAsignar.DataSource = dtAttSinAsignar
    End Sub
    Private Sub CargaEmpleadosSinAsignar()
        Dim daLogistica As New SqlDataAdapter("exec spLOGEmpleadoSinAsignarTotal @FAsignacion", cnSigamet)
        Dim dtEmpleadosSinAsignar As New DataTable()
        vgrdEmpleadosSinAsignar.DataSource = Nothing
        daLogistica.SelectCommand.Parameters.Add("@FAsignacion", SqlDbType.DateTime).Value = dtpFAsignacion.Value.Date
        Try
            daLogistica.Fill(dtEmpleadosSinAsignar)
        Catch ex As Exception
            ExMessage(ex)
        Finally
            daLogistica.Dispose()
        End Try
        vgrdEmpleadosSinAsignar.DataSource = dtEmpleadosSinAsignar
    End Sub
    Private Sub dtpFAsignacion_ValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles dtpFAsignacion.ValueChanged
        CargaInformacion()
        CargaDatosExtra()
    End Sub

#End Region

#Region "Rutinas de manejo del grid de folios"
    Private Sub grdFolios_CurrentCellChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles grdFolios.CurrentCellChanged
        grdFolios.Select(grdFolios.CurrentRowIndex)
        cboTipoAsignacion.Visible = False
        PermiteCambioTipoAsignacion = False
        lblOperadores.Text = ""
        If Not grdFolios.CurrentRowIndex < 0 Then
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
        cmdLogistica.Parameters.Add("@Fasignacion", SqlDbType.DateTime).Value = Now.Date 'CDate(CampoFolio("FAsignacion")).Date
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
        If OperacionLogistica(2).Habilitada OrElse CDate(CampoFolio("FAsignacion")).Date = Now.Date Then
            Return True
        ElseIf CDate(CampoFolio("FAsignacion")).Date.AddDays(_DiasCorreccion) >= Now.Date Then
            If CDate(CampoFolio("FAsignacion")).Date < FMinima Then
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
#End Region

#Region "Rutinas de configuración"
    Private Sub CargaConfiguracion()
        Try
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

        Catch ex As Exception
            ErrMessage("No existe el archivo " + Application.StartupPath & "\" & "Default.Logistica.exe.config" + " ó al mismo le hace falta alguna de las configuraciones. LLame a soporte. Detalles: " + ex.Message)
        End Try


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
            Case "Asignar"
                Asignar()
            Case "Ruta"
                AsignacionRuta()
            Case "Cancelar"
                CancelacionFolio()
            Case "Buscar"
                Buscar()
            Case "Refrescar"
                CargaInformacion()
                CargaDatosExtra()
            Case "Cerrar"
                Me.Close()
        End Select
    End Sub
    Private Sub mniAsignar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mniAsignar.Click
        Asignar()
    End Sub
    Private Sub mniBuscar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mniBuscar.Click
        Buscar()
    End Sub
    Private Sub mniCancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mniCancelar.Click
        CancelacionFolio()
    End Sub
    Private Sub mniRefrescar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mniRefrescar.Click
        CargaInformacion()
        CargaDatosExtra()
    End Sub
    Private Sub mniCerrar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mniCerrar.Click
        Me.Close()
    End Sub
#End Region

#Region "Rutinas de acciones especiales"
    Private Sub Asignar()
        If ValidaCambio() Then
            Dim frmAsignacionOperador As New frmAsignacionOperadorPosturero(CInt(CampoFolio("Año")), CInt(CampoFolio("Folio")), dtpFAsignacion.Value.Date)
            Dim Folio As String = CStr(CampoFolio("Folio"))
            frmAsignacionOperador.ShowDialog()
            CargaInformacion()
            CargaDatosExtra()
            EncuentraRegistro(grdFolios, Folio, 0)
        End If
    End Sub

    Private Sub AsignacionRuta()
        If ValidaCambio() Then
            Dim frmAsignacionRuta As New frmAsignacionRutaGeneral(CInt(CampoFolio("Celula")), CInt(CampoFolio("Año")), CInt(CampoFolio("Folio")), CInt(CampoFolio("Autotanque")), CInt(CampoFolio("RutaAsignada")))
            Dim Folio As String = CStr(CampoFolio("Folio"))
            If frmAsignacionRuta.ShowDialog() = DialogResult.OK Then
                CargaInformacion()
                CargaDatosExtra()
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
    Private Sub btnEditaEmpleadoSinAsignar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnEditaEmpleadoSinAsignar.Click
        MessageBox.Show("Esta función no ha sido implementada", Application.ProductName & " v." & Application.ProductVersion, MessageBoxButtons.OK, MessageBoxIcon.Information)
    End Sub
#End Region



    Private Sub frmAsignacionPostureros_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

    End Sub
End Class



