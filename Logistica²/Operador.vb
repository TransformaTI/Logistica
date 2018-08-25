Imports System
Imports System.Data
Imports System.Data.SqlClient
Imports System.IO
Imports Logistica
Imports RTGMGateway
Imports RTGMCore




Public Class frmOperador
    Inherits System.Windows.Forms.Form

#Region " Windows Form Designer generated code "

    Public Sub New()
        MyBase.New()

        'This call is required by the Windows Form Designer.
        InitializeComponent()

        'Add any initialization after the InitializeComponent() call
        Dim cmdLogistica As New SqlCommand("Select C.Celula as Celula, ltrim(rtrim(C.Descripcion)) as Descripcion from Celula C inner join UsuarioCelula UC " _
                & " on C.Celula = UC.Celula and UC.Usuario = @Usuario and C.Comercial = 1", cnSigamet)
        Dim daLogistica As New SqlDataAdapter(cmdLogistica)
        'Tabla para combo de células
        Dim dtCelula As New DataTable()
        cmdLogistica.Parameters.Add("@Usuario", SqlDbType.Char).Value = _Usuario
        Try
            'Llenado de tabla
            daLogistica.Fill(dtCelula)
        Catch ex As Exception
            ExMessage(ex)
        End Try
        'Llenado de combos
        cboCelula.ValueMember = "Celula"
        cboCelula.DisplayMember = "Descripcion"
        cboCelula.DataSource = dtCelula
        cboCelula.SelectedValue = _Celula
        'Eliminación de objetos
        cmdLogistica.Dispose()
        daLogistica.Dispose()
        'Carga de información
        CargaInformacion()
        CargaDatosAdicionales()
        If OperacionLogistica(5).Habilitada Then
            mniEliminar.Enabled = True
            mniEliminar.Visible = True
            btnEliminar.Visible = True
        End If
        mniAgregar.Enabled = OperacionLogistica(4).Habilitada
        btnAgregar.Enabled = OperacionLogistica(4).Habilitada
        btnInactivar.Enabled = OperacionLogistica(4).Habilitada
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
    Friend WithEvents mnuCatalogo As System.Windows.Forms.MainMenu
    Friend WithEvents mniCatalogo As System.Windows.Forms.MenuItem
    Friend WithEvents imgHerramientas As System.Windows.Forms.ImageList
    Friend WithEvents tbOperador As System.Windows.Forms.ToolBar
    Friend WithEvents btnAgregar As System.Windows.Forms.ToolBarButton
    Friend WithEvents btnEliminar As System.Windows.Forms.ToolBarButton
    Friend WithEvents btnModificar As System.Windows.Forms.ToolBarButton
    Friend WithEvents btnInactivar As System.Windows.Forms.ToolBarButton
    Friend WithEvents btnBuscar As System.Windows.Forms.ToolBarButton
    Friend WithEvents btnCerrar As System.Windows.Forms.ToolBarButton
    Friend WithEvents lblCelula As System.Windows.Forms.Label
    Friend WithEvents cboCelula As System.Windows.Forms.ComboBox
    Friend WithEvents txtDiasCredito As System.Windows.Forms.TextBox
    Friend WithEvents txtNotasBlancas As System.Windows.Forms.TextBox
    Friend WithEvents txtCliente As System.Windows.Forms.TextBox
    Friend WithEvents lblCliente As System.Windows.Forms.Label
    Friend WithEvents lblNotas As System.Windows.Forms.Label
    Friend WithEvents lblMaximolitroscredito As System.Windows.Forms.Label
    Friend WithEvents pnlDatosAdicionales As System.Windows.Forms.Panel
    Friend WithEvents Sep0 As System.Windows.Forms.ToolBarButton
    Friend WithEvents Sep1 As System.Windows.Forms.ToolBarButton
    Friend WithEvents Sep2 As System.Windows.Forms.ToolBarButton
    Friend WithEvents Sep3 As System.Windows.Forms.ToolBarButton
    Friend WithEvents Sep4 As System.Windows.Forms.ToolBarButton
    Friend WithEvents vgrdCatalogo As Logistica.ViewGrid
    Friend WithEvents btnFiltro As System.Windows.Forms.ToolBarButton
    Friend WithEvents mnuFiltro As System.Windows.Forms.ContextMenu
    Friend WithEvents mniTodos As System.Windows.Forms.MenuItem
    Friend WithEvents mniActivos As System.Windows.Forms.MenuItem
    Friend WithEvents mniInactivos As System.Windows.Forms.MenuItem
    Friend WithEvents pnlTitulo As System.Windows.Forms.Panel
    Friend WithEvents rlblTitulo As Logistica.RotatableLabel
    Friend WithEvents MenuItem6 As System.Windows.Forms.MenuItem
    Friend WithEvents mniOperador As System.Windows.Forms.MenuItem
    Friend WithEvents mniAgregar As System.Windows.Forms.MenuItem
    Friend WithEvents mniEliminar As System.Windows.Forms.MenuItem
    Friend WithEvents mniModificar As System.Windows.Forms.MenuItem
    Friend WithEvents Sepm0 As System.Windows.Forms.MenuItem
    Friend WithEvents Sepm1 As System.Windows.Forms.MenuItem
    Friend WithEvents mniCerrar As System.Windows.Forms.MenuItem
    Friend WithEvents mniBuscar As System.Windows.Forms.MenuItem
    Friend WithEvents Sepm1_1 As System.Windows.Forms.MenuItem
    Friend WithEvents mniActualizar As System.Windows.Forms.MenuItem
    Friend WithEvents btnActualizar As System.Windows.Forms.ToolBarButton
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmOperador))
        Me.imgHerramientas = New System.Windows.Forms.ImageList(Me.components)
        Me.mnuCatalogo = New System.Windows.Forms.MainMenu(Me.components)
        Me.mniCatalogo = New System.Windows.Forms.MenuItem()
        Me.mniOperador = New System.Windows.Forms.MenuItem()
        Me.mniAgregar = New System.Windows.Forms.MenuItem()
        Me.mniModificar = New System.Windows.Forms.MenuItem()
        Me.mniEliminar = New System.Windows.Forms.MenuItem()
        Me.Sepm0 = New System.Windows.Forms.MenuItem()
        Me.mniBuscar = New System.Windows.Forms.MenuItem()
        Me.Sepm1_1 = New System.Windows.Forms.MenuItem()
        Me.mniActualizar = New System.Windows.Forms.MenuItem()
        Me.Sepm1 = New System.Windows.Forms.MenuItem()
        Me.mniCerrar = New System.Windows.Forms.MenuItem()
        Me.tbOperador = New System.Windows.Forms.ToolBar()
        Me.Sep0 = New System.Windows.Forms.ToolBarButton()
        Me.btnAgregar = New System.Windows.Forms.ToolBarButton()
        Me.btnEliminar = New System.Windows.Forms.ToolBarButton()
        Me.btnModificar = New System.Windows.Forms.ToolBarButton()
        Me.btnInactivar = New System.Windows.Forms.ToolBarButton()
        Me.Sep1 = New System.Windows.Forms.ToolBarButton()
        Me.btnFiltro = New System.Windows.Forms.ToolBarButton()
        Me.mnuFiltro = New System.Windows.Forms.ContextMenu()
        Me.mniTodos = New System.Windows.Forms.MenuItem()
        Me.mniActivos = New System.Windows.Forms.MenuItem()
        Me.mniInactivos = New System.Windows.Forms.MenuItem()
        Me.btnBuscar = New System.Windows.Forms.ToolBarButton()
        Me.Sep2 = New System.Windows.Forms.ToolBarButton()
        Me.btnActualizar = New System.Windows.Forms.ToolBarButton()
        Me.Sep3 = New System.Windows.Forms.ToolBarButton()
        Me.btnCerrar = New System.Windows.Forms.ToolBarButton()
        Me.Sep4 = New System.Windows.Forms.ToolBarButton()
        Me.lblCelula = New System.Windows.Forms.Label()
        Me.cboCelula = New System.Windows.Forms.ComboBox()
        Me.pnlDatosAdicionales = New System.Windows.Forms.Panel()
        Me.txtDiasCredito = New System.Windows.Forms.TextBox()
        Me.txtNotasBlancas = New System.Windows.Forms.TextBox()
        Me.txtCliente = New System.Windows.Forms.TextBox()
        Me.lblCliente = New System.Windows.Forms.Label()
        Me.lblNotas = New System.Windows.Forms.Label()
        Me.lblMaximolitroscredito = New System.Windows.Forms.Label()
        Me.vgrdCatalogo = New Logistica.ViewGrid()
        Me.pnlTitulo = New System.Windows.Forms.Panel()
        Me.rlblTitulo = New Logistica.RotatableLabel()
        Me.MenuItem6 = New System.Windows.Forms.MenuItem()
        Me.pnlDatosAdicionales.SuspendLayout()
        Me.pnlTitulo.SuspendLayout()
        Me.SuspendLayout()
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
        '
        'mnuCatalogo
        '
        Me.mnuCatalogo.MenuItems.AddRange(New System.Windows.Forms.MenuItem() {Me.mniCatalogo})
        '
        'mniCatalogo
        '
        Me.mniCatalogo.Index = 0
        Me.mniCatalogo.MenuItems.AddRange(New System.Windows.Forms.MenuItem() {Me.mniOperador})
        Me.mniCatalogo.MergeOrder = 2
        Me.mniCatalogo.MergeType = System.Windows.Forms.MenuMerge.MergeItems
        Me.mniCatalogo.Text = "&Catálogos"
        '
        'mniOperador
        '
        Me.mniOperador.Index = 0
        Me.mniOperador.MenuItems.AddRange(New System.Windows.Forms.MenuItem() {Me.mniAgregar, Me.mniModificar, Me.mniEliminar, Me.Sepm0, Me.mniBuscar, Me.Sepm1_1, Me.mniActualizar, Me.Sepm1, Me.mniCerrar})
        Me.mniOperador.MergeOrder = 1
        Me.mniOperador.MergeType = System.Windows.Forms.MenuMerge.MergeItems
        Me.mniOperador.Text = "&Operador"
        '
        'mniAgregar
        '
        Me.mniAgregar.Index = 0
        Me.mniAgregar.Shortcut = System.Windows.Forms.Shortcut.Ins
        Me.mniAgregar.Text = "&Agregar"
        '
        'mniModificar
        '
        Me.mniModificar.Index = 1
        Me.mniModificar.Shortcut = System.Windows.Forms.Shortcut.CtrlIns
        Me.mniModificar.Text = "&Modificar"
        '
        'mniEliminar
        '
        Me.mniEliminar.Enabled = False
        Me.mniEliminar.Index = 2
        Me.mniEliminar.Shortcut = System.Windows.Forms.Shortcut.Del
        Me.mniEliminar.Text = "&Eliminar"
        Me.mniEliminar.Visible = False
        '
        'Sepm0
        '
        Me.Sepm0.Index = 3
        Me.Sepm0.Text = "-"
        '
        'mniBuscar
        '
        Me.mniBuscar.Index = 4
        Me.mniBuscar.Shortcut = System.Windows.Forms.Shortcut.CtrlB
        Me.mniBuscar.Text = "&Buscar"
        '
        'Sepm1_1
        '
        Me.Sepm1_1.Index = 5
        Me.Sepm1_1.Text = "-"
        '
        'mniActualizar
        '
        Me.mniActualizar.Index = 6
        Me.mniActualizar.Shortcut = System.Windows.Forms.Shortcut.F5
        Me.mniActualizar.Text = "Ac&tualizar"
        '
        'Sepm1
        '
        Me.Sepm1.Index = 7
        Me.Sepm1.Text = "-"
        '
        'mniCerrar
        '
        Me.mniCerrar.Index = 8
        Me.mniCerrar.Text = "&Cerrar"
        '
        'tbOperador
        '
        Me.tbOperador.Appearance = System.Windows.Forms.ToolBarAppearance.Flat
        Me.tbOperador.Buttons.AddRange(New System.Windows.Forms.ToolBarButton() {Me.Sep0, Me.btnAgregar, Me.btnEliminar, Me.btnModificar, Me.btnInactivar, Me.Sep1, Me.btnFiltro, Me.btnBuscar, Me.Sep2, Me.btnActualizar, Me.Sep3, Me.btnCerrar, Me.Sep4})
        Me.tbOperador.DropDownArrows = True
        Me.tbOperador.ImageList = Me.imgHerramientas
        Me.tbOperador.Location = New System.Drawing.Point(0, 0)
        Me.tbOperador.Name = "tbOperador"
        Me.tbOperador.ShowToolTips = True
        Me.tbOperador.Size = New System.Drawing.Size(676, 50)
        Me.tbOperador.TabIndex = 3
        '
        'Sep0
        '
        Me.Sep0.Name = "Sep0"
        Me.Sep0.Style = System.Windows.Forms.ToolBarButtonStyle.Separator
        '
        'btnAgregar
        '
        Me.btnAgregar.ImageIndex = 0
        Me.btnAgregar.Name = "btnAgregar"
        Me.btnAgregar.Text = "Agregar"
        '
        'btnEliminar
        '
        Me.btnEliminar.ImageIndex = 1
        Me.btnEliminar.Name = "btnEliminar"
        Me.btnEliminar.Text = "Eliminar"
        Me.btnEliminar.Visible = False
        '
        'btnModificar
        '
        Me.btnModificar.ImageIndex = 2
        Me.btnModificar.Name = "btnModificar"
        Me.btnModificar.Text = "Modificar"
        '
        'btnInactivar
        '
        Me.btnInactivar.ImageIndex = 3
        Me.btnInactivar.Name = "btnInactivar"
        Me.btnInactivar.Text = "Inactivar"
        '
        'Sep1
        '
        Me.Sep1.Name = "Sep1"
        Me.Sep1.Style = System.Windows.Forms.ToolBarButtonStyle.Separator
        '
        'btnFiltro
        '
        Me.btnFiltro.DropDownMenu = Me.mnuFiltro
        Me.btnFiltro.ImageIndex = 7
        Me.btnFiltro.Name = "btnFiltro"
        Me.btnFiltro.Style = System.Windows.Forms.ToolBarButtonStyle.DropDownButton
        Me.btnFiltro.Text = "Filtro"
        '
        'mnuFiltro
        '
        Me.mnuFiltro.MenuItems.AddRange(New System.Windows.Forms.MenuItem() {Me.mniTodos, Me.mniActivos, Me.mniInactivos})
        '
        'mniTodos
        '
        Me.mniTodos.Checked = True
        Me.mniTodos.DefaultItem = True
        Me.mniTodos.Index = 0
        Me.mniTodos.RadioCheck = True
        Me.mniTodos.Text = "&Todos"
        '
        'mniActivos
        '
        Me.mniActivos.Index = 1
        Me.mniActivos.Text = "&Activos"
        '
        'mniInactivos
        '
        Me.mniInactivos.Index = 2
        Me.mniInactivos.Text = "&Inactivos"
        '
        'btnBuscar
        '
        Me.btnBuscar.ImageIndex = 4
        Me.btnBuscar.Name = "btnBuscar"
        Me.btnBuscar.Text = "Buscar"
        '
        'Sep2
        '
        Me.Sep2.Name = "Sep2"
        Me.Sep2.Style = System.Windows.Forms.ToolBarButtonStyle.Separator
        '
        'btnActualizar
        '
        Me.btnActualizar.ImageIndex = 5
        Me.btnActualizar.Name = "btnActualizar"
        Me.btnActualizar.Text = "Actualizar"
        '
        'Sep3
        '
        Me.Sep3.Name = "Sep3"
        Me.Sep3.Style = System.Windows.Forms.ToolBarButtonStyle.Separator
        '
        'btnCerrar
        '
        Me.btnCerrar.ImageIndex = 6
        Me.btnCerrar.Name = "btnCerrar"
        Me.btnCerrar.Text = "Cerrar"
        '
        'Sep4
        '
        Me.Sep4.Name = "Sep4"
        Me.Sep4.Style = System.Windows.Forms.ToolBarButtonStyle.Separator
        '
        'lblCelula
        '
        Me.lblCelula.AutoSize = True
        Me.lblCelula.ForeColor = System.Drawing.Color.Black
        Me.lblCelula.Location = New System.Drawing.Point(447, 12)
        Me.lblCelula.Name = "lblCelula"
        Me.lblCelula.Size = New System.Drawing.Size(40, 13)
        Me.lblCelula.TabIndex = 0
        Me.lblCelula.Text = "&Célula:"
        '
        'cboCelula
        '
        Me.cboCelula.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboCelula.Location = New System.Drawing.Point(488, 9)
        Me.cboCelula.Name = "cboCelula"
        Me.cboCelula.Size = New System.Drawing.Size(121, 21)
        Me.cboCelula.TabIndex = 1
        '
        'pnlDatosAdicionales
        '
        Me.pnlDatosAdicionales.Controls.Add(Me.txtDiasCredito)
        Me.pnlDatosAdicionales.Controls.Add(Me.txtNotasBlancas)
        Me.pnlDatosAdicionales.Controls.Add(Me.txtCliente)
        Me.pnlDatosAdicionales.Controls.Add(Me.lblCliente)
        Me.pnlDatosAdicionales.Controls.Add(Me.lblNotas)
        Me.pnlDatosAdicionales.Controls.Add(Me.lblMaximolitroscredito)
        Me.pnlDatosAdicionales.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.pnlDatosAdicionales.Location = New System.Drawing.Point(0, 371)
        Me.pnlDatosAdicionales.Name = "pnlDatosAdicionales"
        Me.pnlDatosAdicionales.Size = New System.Drawing.Size(676, 144)
        Me.pnlDatosAdicionales.TabIndex = 2
        '
        'txtDiasCredito
        '
        Me.txtDiasCredito.BackColor = System.Drawing.Color.White
        Me.txtDiasCredito.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtDiasCredito.Location = New System.Drawing.Point(162, 81)
        Me.txtDiasCredito.Name = "txtDiasCredito"
        Me.txtDiasCredito.ReadOnly = True
        Me.txtDiasCredito.Size = New System.Drawing.Size(49, 21)
        Me.txtDiasCredito.TabIndex = 6
        Me.txtDiasCredito.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtNotasBlancas
        '
        Me.txtNotasBlancas.BackColor = System.Drawing.Color.White
        Me.txtNotasBlancas.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtNotasBlancas.Location = New System.Drawing.Point(162, 45)
        Me.txtNotasBlancas.Name = "txtNotasBlancas"
        Me.txtNotasBlancas.ReadOnly = True
        Me.txtNotasBlancas.Size = New System.Drawing.Size(49, 21)
        Me.txtNotasBlancas.TabIndex = 5
        Me.txtNotasBlancas.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtCliente
        '
        Me.txtCliente.BackColor = System.Drawing.Color.White
        Me.txtCliente.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtCliente.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtCliente.Location = New System.Drawing.Point(162, 9)
        Me.txtCliente.Name = "txtCliente"
        Me.txtCliente.ReadOnly = True
        Me.txtCliente.Size = New System.Drawing.Size(122, 21)
        Me.txtCliente.TabIndex = 4
        Me.txtCliente.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'lblCliente
        '
        Me.lblCliente.AutoSize = True
        Me.lblCliente.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCliente.Location = New System.Drawing.Point(18, 12)
        Me.lblCliente.Name = "lblCliente"
        Me.lblCliente.Size = New System.Drawing.Size(44, 13)
        Me.lblCliente.TabIndex = 36
        Me.lblCliente.Text = "Cliente:"
        '
        'lblNotas
        '
        Me.lblNotas.AutoSize = True
        Me.lblNotas.Location = New System.Drawing.Point(18, 48)
        Me.lblNotas.Name = "lblNotas"
        Me.lblNotas.Size = New System.Drawing.Size(133, 13)
        Me.lblNotas.TabIndex = 38
        Me.lblNotas.Text = "Número de Notas Blancas:"
        '
        'lblMaximolitroscredito
        '
        Me.lblMaximolitroscredito.AutoSize = True
        Me.lblMaximolitroscredito.Location = New System.Drawing.Point(18, 84)
        Me.lblMaximolitroscredito.Name = "lblMaximolitroscredito"
        Me.lblMaximolitroscredito.Size = New System.Drawing.Size(76, 13)
        Me.lblMaximolitroscredito.TabIndex = 37
        Me.lblMaximolitroscredito.Text = "Días a crédito:"
        '
        'vgrdCatalogo
        '
        Me.vgrdCatalogo.AlternativeBackColor = System.Drawing.Color.Gainsboro
        Me.vgrdCatalogo.AutoArrange = False
        Me.vgrdCatalogo.CheckCondition = Nothing
        Me.vgrdCatalogo.DataSource = Nothing
        Me.vgrdCatalogo.Dock = System.Windows.Forms.DockStyle.Fill
        Me.vgrdCatalogo.FullRowSelect = True
        Me.vgrdCatalogo.GridLines = True
        Me.vgrdCatalogo.HidedColumnNames = New String() {"Célula", "CCelula", "Licencia", "Radio", "Pager", "Cliente", "MaxNotasBlancas", "MaxDiasCredito", "IDClasificacion", "IDCategoria", "IDTipo"}
        Me.vgrdCatalogo.HideSelection = False
        Me.vgrdCatalogo.Location = New System.Drawing.Point(24, 50)
        Me.vgrdCatalogo.MultiSelect = False
        Me.vgrdCatalogo.Name = "vgrdCatalogo"
        Me.vgrdCatalogo.NullText = ""
        Me.vgrdCatalogo.PKColumnNames = New String() {"Empleado"}
        Me.vgrdCatalogo.Size = New System.Drawing.Size(652, 321)
        Me.vgrdCatalogo.TabIndex = 4
        Me.vgrdCatalogo.UseCompatibleStateImageBehavior = False
        Me.vgrdCatalogo.View = System.Windows.Forms.View.Details
        '
        'pnlTitulo
        '
        Me.pnlTitulo.Controls.Add(Me.rlblTitulo)
        Me.pnlTitulo.Dock = System.Windows.Forms.DockStyle.Left
        Me.pnlTitulo.Location = New System.Drawing.Point(0, 50)
        Me.pnlTitulo.Name = "pnlTitulo"
        Me.pnlTitulo.Size = New System.Drawing.Size(24, 321)
        Me.pnlTitulo.TabIndex = 5
        '
        'rlblTitulo
        '
        Me.rlblTitulo.Border = False
        Me.rlblTitulo.Caption = "Operadores de célula x"
        Me.rlblTitulo.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.rlblTitulo.Font = New System.Drawing.Font("Tahoma", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rlblTitulo.ForeColor = System.Drawing.Color.DarkSlateBlue
        Me.rlblTitulo.Location = New System.Drawing.Point(0, 65)
        Me.rlblTitulo.Name = "rlblTitulo"
        Me.rlblTitulo.RotationAngle = 270
        Me.rlblTitulo.Size = New System.Drawing.Size(25, 256)
        Me.rlblTitulo.TabIndex = 6
        '
        'MenuItem6
        '
        Me.MenuItem6.Index = -1
        Me.MenuItem6.Text = ""
        '
        'frmOperador
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 14)
        Me.BackColor = System.Drawing.Color.Gainsboro
        Me.ClientSize = New System.Drawing.Size(676, 515)
        Me.Controls.Add(Me.vgrdCatalogo)
        Me.Controls.Add(Me.pnlTitulo)
        Me.Controls.Add(Me.cboCelula)
        Me.Controls.Add(Me.lblCelula)
        Me.Controls.Add(Me.tbOperador)
        Me.Controls.Add(Me.pnlDatosAdicionales)
        Me.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Menu = Me.mnuCatalogo
        Me.Name = "frmOperador"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Catálogo de operadores"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.pnlDatosAdicionales.ResumeLayout(False)
        Me.pnlDatosAdicionales.PerformLayout()
        Me.pnlTitulo.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

#End Region

#Region "Variables globales"
    Private dtOperador As New DataTable()
    Private Filtro As String
#End Region

#Region "Rutinas de actualización"
    Private Sub CargaInformacion()
        If Not cboCelula.SelectedValue Is Nothing Then
            'texis cambio en el select para mostrar en orden celular'
            Dim cmdLogistica As New SqlCommand("Select Empleado,Celular,Nombre,Categoria,Tipo,Ruta,Clasificacion,Célula,Status,MaxNotasBlancas,MaxDiasCredito,MaxLitrosCredito,Preasignacion,Licencia,cliente from vwLOGOperador where CCelula = @Celula ", cnSigamet)
            Dim daLogistica As New SqlDataAdapter(cmdLogistica)
            'Limpiado de grid
            vgrdCatalogo.DataSource = Nothing
            'Carga de parámetros
            cmdLogistica.Parameters.Add("@Celula", SqlDbType.TinyInt).Value = cboCelula.SelectedValue
            'Filtrado de datos
            If Filtro <> "" Then
                cmdLogistica.CommandText &= Filtro
            End If
            cmdLogistica.CommandText &= " order by Empleado"
            Try
                'Limpiado de tabla
                dtOperador.Clear()
                'Llenado de tabla
                daLogistica.Fill(dtOperador)
            Catch ex As Exception
                ExMessage(ex)
            End Try
            'Llenado de grid
            Dim objGateway = New RTGMGateway.RTGMGateway(1, "Server=192.168.1.30;Database=sigametdevtb;User Id=ROPIMA;Password = ROPIMA9999;")
            objGateway.URLServicio = "http://192.168.1.30:88/GasMetropolitanoRuntimeService.svc"

            Dim ConsultaCRM As DataTable = dtOperador
            For Each row As DataRow In ConsultaCRM.Rows
                Dim objRequest As RTGMGateway.SolicitudGateway
                objRequest.IDCliente = CStr(row("Cliente"))
                Dim objDireccionEntega = New RTGMCore.DireccionEntrega
                objDireccionEntega = objGateway.buscarDireccionEntrega(objRequest)
                row("Nombre") = objDireccionEntega.Nombre
                row("celular") = objDireccionEntega.TelefonoCelular
                row("Tipo") = objDireccionEntega.TipoCliente
                If objDireccionEntega.Ruta IsNot Nothing Then
                    row("Ruta") = objDireccionEntega.Ruta.IDRuta
                End If
                row("Status") = objDireccionEntega.STATUS

            Next

            vgrdCatalogo.DataSource = dtOperador
            vgrdCatalogo.DataSource = ConsultaCRM
            If dtOperador.Rows.Count > 0 Then
                vgrdCatalogo.Items(0).Selected = True
            End If
            'Eliminación de objetos
            cmdLogistica.Dispose()
            daLogistica.Dispose()
        End If
    End Sub
    Private Sub CargaDatosAdicionales()
        If Not vgrdCatalogo.CurrentRow Is Nothing Then
            Dim FoundRow As DataRow = vgrdCatalogo.CurrentRow
            If Not FoundRow Is Nothing Then
                txtCliente.Text = CStr(FoundRow("Cliente"))
                txtNotasBlancas.Text = CStr(FoundRow("MaxNotasBlancas"))
                txtDiasCredito.Text = CStr(FoundRow("MaxDiasCredito"))
                If FoundRow("Status") IsNot DBNull.Value Then
                    If CStr(FoundRow("Status")).Trim = "INACTIVO" Then
                        btnInactivar.Enabled = False
                    Else
                        btnInactivar.Enabled = True AndAlso OperacionLogistica(4).Habilitada
                    End If
                End If
            Else
                    txtCliente.Clear()
                txtNotasBlancas.Clear()
                txtDiasCredito.Clear()
            End If
        Else
            txtCliente.Clear()
            txtNotasBlancas.Clear()
            txtDiasCredito.Clear()
        End If
    End Sub
    Private Sub mniFiltro_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles mniTodos.Click, mniActivos.Click, mniInactivos.Click
        'Manejo de menú
        mniTodos.Checked = False
        mniActivos.Checked = False
        mniInactivos.Checked = False
        CType(sender, MenuItem).Checked = True
        'Manejo de  filtro
        Select Case CType(sender, MenuItem).Text
            Case "&Todos"
                Filtro = ""
                rlblTitulo.Caption = "Operadores de célula " & CStr(cboCelula.SelectedValue)
            Case "&Activos"
                Filtro = " and Status = 'ACTIVO'"
                rlblTitulo.Caption = "Operadores activos de célula " & CStr(cboCelula.SelectedValue)
            Case "&Inactivos"
                Filtro = " and Status = 'INACTIVO'"
                rlblTitulo.Caption = "Operadores inactivos de célula " & CStr(cboCelula.SelectedValue)
        End Select
        'Carga de información
        CargaInformacion()
        CargaDatosAdicionales()
    End Sub
    Private Sub cboCelula_SelectedValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboCelula.SelectedValueChanged
        If Not cboCelula.SelectedValue Is Nothing Then
            'Carga de información
            CargaInformacion()
            CargaDatosAdicionales()
            'Actualización de título
            If mniTodos.Checked Then
                rlblTitulo.Caption = "Operadores de célula " & CStr(cboCelula.SelectedValue)
            ElseIf mniActivos.Checked Then
                rlblTitulo.Caption = "Operadores activos de célula " & CStr(cboCelula.SelectedValue)
            Else
                rlblTitulo.Caption = "Operadores inactivos de célula " & CStr(cboCelula.SelectedValue)
            End If
        End If
    End Sub
    Private Sub vgrdCatalogo_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles vgrdCatalogo.SelectedIndexChanged
        If Not vgrdCatalogo.CurrentRow Is Nothing Then
            'Carga de detalles
            CargaDatosAdicionales()
        End If
    End Sub
#End Region

#Region "Rutinas de menus y herramientas"
    Private Sub mniAgregar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mniAgregar.Click
        Agregar()
    End Sub
    Private Sub mniCerrar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mniCerrar.Click
        Me.Close()
        Me.Dispose()
    End Sub
    Private Sub mniModificar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mniModificar.Click
        Modificar()
    End Sub
    Private Sub mniEliminar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mniEliminar.Click
        Eliminar()
    End Sub
    Private Sub mniBuscar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mniBuscar.Click
        Buscar()
    End Sub
    Private Sub mniActualizar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mniActualizar.Click
        CargaInformacion()
        CargaDatosAdicionales()
    End Sub
    Private Sub tbOperador_ButtonClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.ToolBarButtonClickEventArgs) Handles tbOperador.ButtonClick
        Select Case e.Button.Text
            Case "Agregar"
                Agregar()
            Case "Eliminar"
                Eliminar()
            Case "Inactivar"
                Inactivar()
            Case "Modificar"
                Modificar()
            Case "Buscar"
                Buscar()
            Case "Actualizar"
                CargaInformacion()
                CargaDatosAdicionales()
            Case "Cerrar"
                Me.Close()
                Me.Dispose()
        End Select
    End Sub
#End Region

#Region "Rutina de manejo de datos"
    Private Sub Agregar()
        'Validación de privilegios
        If OperacionLogistica(4).Habilitada Then
            'Creación y carga de formulario de captura
            Dim frmCapturaOperador As New frmCapturaOperador(CInt(cboCelula.SelectedValue))
            frmCapturaOperador.ShowDialog()
            'Validación de resultados
            If frmCapturaOperador.DialogResult = DialogResult.OK Then
                'Carga de información
                CargaInformacion()
                CargaDatosAdicionales()
                'Recuperación de posición en grid
                vgrdCatalogo.FindFirst("Empleado", frmCapturaOperador.txtEmpleado.Text)
                vgrdCatalogo.Focus()
            End If
            'Eliminado de objetos
            frmCapturaOperador.Dispose()
        Else
            ErrMessage("No tiene privilegios para realizar esta operación")
        End If
    End Sub
    Private Sub Eliminar()
        'Validación de privilegios
        If OperacionLogistica(4).Habilitada Then
            'Validación de selección en grid
            If Not vgrdCatalogo.CurrentRow Is Nothing Then
                'Confirmación de acción
                If MessageBox.Show("¿Desea eliminar al operador " & CStr(vgrdCatalogo.CurrentRow("Empleado")) & " " _
                        & CStr(vgrdCatalogo.CurrentRow("Nombre")) & "?", Application.ProductName & "v." & Application.ProductVersion,
                        MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) = DialogResult.Yes Then
                    Dim cmdLogistica As New SqlCommand("Delete from Operador Where Operador = @Operador", cnSigamet)
                    Me.Cursor = Cursors.WaitCursor
                    'Carga de parametros
                    cmdLogistica.Parameters.Add("@Operador", SqlDbType.Int).Value = CInt(CType(vgrdCatalogo.CurrentPK, Object())(0))
                    cmdLogistica.CommandTimeout = 360
                    Try
                        'Apertura de conexión y ejecución de la acción
                        cnSigamet.Open()
                        cmdLogistica.ExecuteNonQuery()
                    Catch ex As Exception
                        ExMessage(ex)
                    Finally
                        'Cerrado de conexión
                        cnSigamet.Close()
                        'Eliminado de objetos
                        cmdLogistica.Dispose()
                        Me.Cursor = Cursors.Default
                    End Try
                    'Carga de información
                    CargaInformacion()
                    CargaDatosAdicionales()
                End If
            End If
        Else
            ErrMessage("No tiene privilegios para realizar esta operación.")
        End If
    End Sub
    Private Sub Inactivar()
        'Validación de privilegios
        If OperacionLogistica(4).Habilitada Then
            'Validación de selección en grid
            If Not vgrdCatalogo.CurrentRow Is Nothing Then
                'Confirmación de acción
                If MessageBox.Show("¿Desea inactivar al operador " & CStr(vgrdCatalogo.CurrentRow("Empleado")) & " " _
                      & CStr(vgrdCatalogo.CurrentRow("Nombre")) & "?", Application.ProductName & "v." & Application.ProductVersion,
                      MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) = DialogResult.Yes Then
                    Dim cmdLogistica As New SqlClient.SqlCommand("Update Operador set Status = 'INACTIVO' where Operador = @Operador", cnSigamet)
                    'Carga de parámetros
                    cmdLogistica.Parameters.Add("@Operador", SqlDbType.Int).Value = CInt(CType(vgrdCatalogo.CurrentPK, Object())(0))
                    Try
                        Me.Cursor = Cursors.WaitCursor
                        'Apertura de conexión y ejecución de la acción
                        cnSigamet.Open()
                        cmdLogistica.ExecuteNonQuery()
                    Catch ex As Exception
                        ExMessage(ex)
                    Finally
                        'Cerrado de conexión
                        cnSigamet.Close()
                        'Eliminación de objetos
                        cmdLogistica.Dispose()
                        Me.Cursor = Cursors.Default
                    End Try
                    'Carga de información
                    CargaInformacion()
                    CargaDatosAdicionales()
                    'Recuperación de posición en grid
                    vgrdCatalogo.FindFirst("Empleado", CStr(cmdLogistica.Parameters("@Operador").Value))
                    vgrdCatalogo.Focus()
                End If
            End If
        Else
            ErrMessage("No tiene privilegios para realizar esta operación.")
        End If
    End Sub
    Private Sub Modificar()
        'Validación de selección en grid
        If Not vgrdCatalogo.CurrentRow Is Nothing Then
            'Creación y carga de formulario
            Dim frmCapturaOperador As New frmCapturaOperador(CInt(cboCelula.SelectedValue), CInt(CType(vgrdCatalogo.CurrentPK, Object())(0)))
            frmCapturaOperador.ShowDialog()
            'Validación de resultados
            If frmCapturaOperador.DialogResult = DialogResult.OK Then
                'Carga de información
                CargaInformacion()
                CargaDatosAdicionales()
                'Recuperación de posición en grid
                vgrdCatalogo.FindFirst("Empleado", frmCapturaOperador.txtEmpleado.Text)
                vgrdCatalogo.Focus()
            End If
            'Eliminación de objetos
            frmCapturaOperador.Dispose()
        End If
    End Sub
    Private Sub Buscar()
        'Petición de busqueda
        Dim Operador As String = InputBox("No. de operador:")
        'Validación de texto de busqueda
        If Trim(Operador) <> "" Then
            'Busqueda
            If vgrdCatalogo.FindFirst("Empleado", Trim(Operador)) < 0 Then
                MessageBox.Show("No se ha encontrado al operador no. " & Trim(Operador), Application.ProductName & " v." & Application.ProductVersion, MessageBoxButtons.OK, MessageBoxIcon.Information)
            Else
                vgrdCatalogo.Focus()
            End If
        End If
    End Sub
#End Region

#Region "Rutinas de configuración"
    Private Sub CargaConfiguracion()
        Dim Settings As AppSettings
        Dim ctrl As Control
        'Validaciíon de archivo de configuración
        If File.Exists(Application.StartupPath & "\" & System.Environment.UserName & ".Logistica.exe.config") Then
            Settings = New AppSettings(Application.StartupPath & "\" & System.Environment.UserName & ".Logistica.exe.config")
        Else
            Settings = New AppSettings(Application.StartupPath & "\" & "Default.Logistica.exe.config")
        End If
        Carga de parámetros
        Me.BackColor = Color.FromArgb(CInt(Settings.GetSetting("frmOperador", "BackColor")))
        vgrdCatalogo.BackColor = Color.FromArgb(CInt(Settings.GetSetting("frmOperador", "CatalogoBackColor")))
        vgrdCatalogo.AlternativeBackColor = Color.FromArgb(CInt(Settings.GetSetting("frmOperador", "CatalogoAltBackColor")))
        vgrdCatalogo.ForeColor = Color.FromArgb(CInt(Settings.GetSetting("frmOperador", "CatalogoForeColor")))
        pnlDatosAdicionales.BackColor = Color.FromArgb(CInt(Settings.GetSetting("frmOperador", "DExtraBackColor")))
        pnlDatosAdicionales.ForeColor = Color.FromArgb(CInt(Settings.GetSetting("frmOperador", "DExtraForeColor")))
        For Each ctrl In pnlDatosAdicionales.Controls
            If ctrl.GetType.Name = "TextBox" Then
                ctrl.BackColor = Color.FromArgb(CInt(Settings.GetSetting("frmOperador", "DExtraTBackColor")))
                ctrl.ForeColor = Color.FromArgb(CInt(Settings.GetSetting("frmOperador", "DExtraTForeColor")))
            End If
        Next
    End Sub
    Protected Overrides Sub OnPaint(ByVal e As PaintEventArgs)
        CargaConfiguracion()
    End Sub
    Private Sub frmOperador_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Activated
        CargaConfiguracion()
    End Sub
#End Region

End Class
