Imports System
Imports System.Data
Imports System.Data.SqlClient
Imports System.IO
Imports Logistica

Public Class frmAutotanque
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
        Dim dtCelula As New DataTable()
        cmdLogistica.Parameters.Add("@Usuario", SqlDbType.Char).Value = _Usuario
        Try
            daLogistica.Fill(dtCelula)
        Catch ex As Exception
            ExMessage(ex)
        End Try
        cboCelula.ValueMember = "Celula"
        cboCelula.DisplayMember = "Descripcion"
        cboCelula.DataSource = dtCelula
        cboCelula.SelectedValue = _Celula
        cmdLogistica.Dispose()
        daLogistica.Dispose()
        CargaInformacion()
        CargaDatosAdicionales()
        mniEliminar.Enabled = OperacionLogistica(5).Habilitada
        mniEliminar.Visible = OperacionLogistica(5).Habilitada
        btnEliminar.Visible = OperacionLogistica(5).Habilitada

        btnAbreCiclo.Visible = OperacionLogistica(11).Habilitada
        mniAbrirCiclo.Visible = OperacionLogistica(11).Habilitada
        mniAbrirCiclo.Enabled = OperacionLogistica(11).Habilitada


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
    Friend WithEvents mnuCatalogo As System.Windows.Forms.MenuItem
    Friend WithEvents pnlDatosAdicionales As System.Windows.Forms.Panel
    Friend WithEvents txtMarca As System.Windows.Forms.TextBox
    Friend WithEvents lblMarca As System.Windows.Forms.Label
    Friend WithEvents txtStatus As System.Windows.Forms.TextBox
    Friend WithEvents txtProducto As System.Windows.Forms.TextBox
    Friend WithEvents txtPropietario As System.Windows.Forms.TextBox
    Friend WithEvents txtTipo As System.Windows.Forms.TextBox
    Friend WithEvents lblStatus As System.Windows.Forms.Label
    Friend WithEvents lblProducto As System.Windows.Forms.Label
    Friend WithEvents lblPropietario As System.Windows.Forms.Label
    Friend WithEvents lblTipo As System.Windows.Forms.Label
    Friend WithEvents mnuAutotanque As System.Windows.Forms.MainMenu
    Friend WithEvents cboCelula As System.Windows.Forms.ComboBox
    Friend WithEvents lblCelula As System.Windows.Forms.Label
    Friend WithEvents vgrdCatalogo As Logistica.ViewGrid
    Friend WithEvents pnlTitulo As System.Windows.Forms.Panel
    Friend WithEvents rlblTitulo As Logistica.RotatableLabel
    Friend WithEvents tbOperador As System.Windows.Forms.ToolBar
    Friend WithEvents Sep0 As System.Windows.Forms.ToolBarButton
    Friend WithEvents btnAgregar As System.Windows.Forms.ToolBarButton
    Friend WithEvents btnEliminar As System.Windows.Forms.ToolBarButton
    Friend WithEvents btnModificar As System.Windows.Forms.ToolBarButton
    Friend WithEvents Sep1 As System.Windows.Forms.ToolBarButton
    Friend WithEvents btnFiltro As System.Windows.Forms.ToolBarButton
    Friend WithEvents mnuFiltro As System.Windows.Forms.ContextMenu
    Friend WithEvents btnBuscar As System.Windows.Forms.ToolBarButton
    Friend WithEvents Sep2 As System.Windows.Forms.ToolBarButton
    Friend WithEvents Sep3 As System.Windows.Forms.ToolBarButton
    Friend WithEvents btnCerrar As System.Windows.Forms.ToolBarButton
    Friend WithEvents Sep4 As System.Windows.Forms.ToolBarButton
    Friend WithEvents imgHerramientas As System.Windows.Forms.ImageList
    Friend WithEvents btnStatus As System.Windows.Forms.ToolBarButton
    Friend WithEvents mniTodos As System.Windows.Forms.MenuItem
    Friend WithEvents mniActivos As System.Windows.Forms.MenuItem
    Friend WithEvents mniInactivos As System.Windows.Forms.MenuItem
    Friend WithEvents mniAutotanque As System.Windows.Forms.MenuItem
    Friend WithEvents mniAgregar As System.Windows.Forms.MenuItem
    Friend WithEvents mniEliminar As System.Windows.Forms.MenuItem
    Friend WithEvents mniModificar As System.Windows.Forms.MenuItem
    Friend WithEvents Sepm0 As System.Windows.Forms.MenuItem
    Friend WithEvents mniBuscar As System.Windows.Forms.MenuItem
    Friend WithEvents Sepm2 As System.Windows.Forms.MenuItem
    Friend WithEvents mniActualizar As System.Windows.Forms.MenuItem
    Friend WithEvents Sepm3 As System.Windows.Forms.MenuItem
    Friend WithEvents mniCerrar As System.Windows.Forms.MenuItem
    Friend WithEvents btnActualizar As System.Windows.Forms.ToolBarButton
    Friend WithEvents btnAbreCiclo As System.Windows.Forms.ToolBarButton
    Friend WithEvents mniAbrirCiclo As System.Windows.Forms.MenuItem
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmAutotanque))
        Me.mnuAutotanque = New System.Windows.Forms.MainMenu(Me.components)
        Me.mnuCatalogo = New System.Windows.Forms.MenuItem()
        Me.mniAutotanque = New System.Windows.Forms.MenuItem()
        Me.mniAgregar = New System.Windows.Forms.MenuItem()
        Me.mniModificar = New System.Windows.Forms.MenuItem()
        Me.mniAbrirCiclo = New System.Windows.Forms.MenuItem()
        Me.mniEliminar = New System.Windows.Forms.MenuItem()
        Me.Sepm0 = New System.Windows.Forms.MenuItem()
        Me.mniBuscar = New System.Windows.Forms.MenuItem()
        Me.Sepm2 = New System.Windows.Forms.MenuItem()
        Me.mniActualizar = New System.Windows.Forms.MenuItem()
        Me.Sepm3 = New System.Windows.Forms.MenuItem()
        Me.mniCerrar = New System.Windows.Forms.MenuItem()
        Me.pnlDatosAdicionales = New System.Windows.Forms.Panel()
        Me.txtMarca = New System.Windows.Forms.TextBox()
        Me.lblMarca = New System.Windows.Forms.Label()
        Me.txtStatus = New System.Windows.Forms.TextBox()
        Me.txtProducto = New System.Windows.Forms.TextBox()
        Me.txtPropietario = New System.Windows.Forms.TextBox()
        Me.txtTipo = New System.Windows.Forms.TextBox()
        Me.lblStatus = New System.Windows.Forms.Label()
        Me.lblProducto = New System.Windows.Forms.Label()
        Me.lblPropietario = New System.Windows.Forms.Label()
        Me.lblTipo = New System.Windows.Forms.Label()
        Me.cboCelula = New System.Windows.Forms.ComboBox()
        Me.lblCelula = New System.Windows.Forms.Label()
        Me.pnlTitulo = New System.Windows.Forms.Panel()
        Me.rlblTitulo = New Logistica.RotatableLabel()
        Me.tbOperador = New System.Windows.Forms.ToolBar()
        Me.Sep0 = New System.Windows.Forms.ToolBarButton()
        Me.btnAgregar = New System.Windows.Forms.ToolBarButton()
        Me.btnEliminar = New System.Windows.Forms.ToolBarButton()
        Me.btnModificar = New System.Windows.Forms.ToolBarButton()
        Me.btnAbreCiclo = New System.Windows.Forms.ToolBarButton()
        Me.btnStatus = New System.Windows.Forms.ToolBarButton()
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
        Me.imgHerramientas = New System.Windows.Forms.ImageList(Me.components)
        Me.vgrdCatalogo = New Logistica.ViewGrid()
        Me.pnlDatosAdicionales.SuspendLayout()
        Me.pnlTitulo.SuspendLayout()
        Me.SuspendLayout()
        '
        'mnuAutotanque
        '
        Me.mnuAutotanque.MenuItems.AddRange(New System.Windows.Forms.MenuItem() {Me.mnuCatalogo})
        '
        'mnuCatalogo
        '
        Me.mnuCatalogo.Index = 0
        Me.mnuCatalogo.MenuItems.AddRange(New System.Windows.Forms.MenuItem() {Me.mniAutotanque})
        Me.mnuCatalogo.MergeOrder = 2
        Me.mnuCatalogo.MergeType = System.Windows.Forms.MenuMerge.MergeItems
        Me.mnuCatalogo.Text = "&Catálogos"
        '
        'mniAutotanque
        '
        Me.mniAutotanque.Index = 0
        Me.mniAutotanque.MenuItems.AddRange(New System.Windows.Forms.MenuItem() {Me.mniAgregar, Me.mniModificar, Me.mniAbrirCiclo, Me.mniEliminar, Me.Sepm0, Me.mniBuscar, Me.Sepm2, Me.mniActualizar, Me.Sepm3, Me.mniCerrar})
        Me.mniAutotanque.MergeType = System.Windows.Forms.MenuMerge.MergeItems
        Me.mniAutotanque.Text = "Au&totanque"
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
        'mniAbrirCiclo
        '
        Me.mniAbrirCiclo.Enabled = False
        Me.mniAbrirCiclo.Index = 2
        Me.mniAbrirCiclo.Shortcut = System.Windows.Forms.Shortcut.CtrlB
        Me.mniAbrirCiclo.Text = "A&brir ciclo"
        Me.mniAbrirCiclo.Visible = False
        '
        'mniEliminar
        '
        Me.mniEliminar.Enabled = False
        Me.mniEliminar.Index = 3
        Me.mniEliminar.Shortcut = System.Windows.Forms.Shortcut.Del
        Me.mniEliminar.Text = "&Eliminar"
        Me.mniEliminar.Visible = False
        '
        'Sepm0
        '
        Me.Sepm0.Index = 4
        Me.Sepm0.Text = "-"
        '
        'mniBuscar
        '
        Me.mniBuscar.Index = 5
        Me.mniBuscar.Text = "&Buscar"
        '
        'Sepm2
        '
        Me.Sepm2.Index = 6
        Me.Sepm2.Text = "-"
        '
        'mniActualizar
        '
        Me.mniActualizar.Index = 7
        Me.mniActualizar.Shortcut = System.Windows.Forms.Shortcut.F5
        Me.mniActualizar.Text = "Ac&tualizar"
        '
        'Sepm3
        '
        Me.Sepm3.Index = 8
        Me.Sepm3.Text = "-"
        '
        'mniCerrar
        '
        Me.mniCerrar.Index = 9
        Me.mniCerrar.Text = "&Cerrar"
        '
        'pnlDatosAdicionales
        '
        Me.pnlDatosAdicionales.BackColor = System.Drawing.Color.AntiqueWhite
        Me.pnlDatosAdicionales.Controls.Add(Me.txtMarca)
        Me.pnlDatosAdicionales.Controls.Add(Me.lblMarca)
        Me.pnlDatosAdicionales.Controls.Add(Me.txtStatus)
        Me.pnlDatosAdicionales.Controls.Add(Me.txtProducto)
        Me.pnlDatosAdicionales.Controls.Add(Me.txtPropietario)
        Me.pnlDatosAdicionales.Controls.Add(Me.txtTipo)
        Me.pnlDatosAdicionales.Controls.Add(Me.lblStatus)
        Me.pnlDatosAdicionales.Controls.Add(Me.lblProducto)
        Me.pnlDatosAdicionales.Controls.Add(Me.lblPropietario)
        Me.pnlDatosAdicionales.Controls.Add(Me.lblTipo)
        Me.pnlDatosAdicionales.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.pnlDatosAdicionales.Location = New System.Drawing.Point(0, 381)
        Me.pnlDatosAdicionales.Name = "pnlDatosAdicionales"
        Me.pnlDatosAdicionales.Size = New System.Drawing.Size(768, 112)
        Me.pnlDatosAdicionales.TabIndex = 2
        '
        'txtMarca
        '
        Me.txtMarca.BackColor = System.Drawing.SystemColors.Window
        Me.txtMarca.Location = New System.Drawing.Point(421, 10)
        Me.txtMarca.Name = "txtMarca"
        Me.txtMarca.ReadOnly = True
        Me.txtMarca.Size = New System.Drawing.Size(216, 21)
        Me.txtMarca.TabIndex = 23
        '
        'lblMarca
        '
        Me.lblMarca.AutoSize = True
        Me.lblMarca.ForeColor = System.Drawing.Color.Black
        Me.lblMarca.Location = New System.Drawing.Point(370, 13)
        Me.lblMarca.Name = "lblMarca"
        Me.lblMarca.Size = New System.Drawing.Size(40, 13)
        Me.lblMarca.TabIndex = 22
        Me.lblMarca.Text = "Marca:"
        '
        'txtStatus
        '
        Me.txtStatus.BackColor = System.Drawing.SystemColors.Window
        Me.txtStatus.Location = New System.Drawing.Point(421, 46)
        Me.txtStatus.Name = "txtStatus"
        Me.txtStatus.ReadOnly = True
        Me.txtStatus.Size = New System.Drawing.Size(78, 21)
        Me.txtStatus.TabIndex = 21
        '
        'txtProducto
        '
        Me.txtProducto.BackColor = System.Drawing.SystemColors.Window
        Me.txtProducto.Location = New System.Drawing.Point(104, 82)
        Me.txtProducto.Name = "txtProducto"
        Me.txtProducto.ReadOnly = True
        Me.txtProducto.Size = New System.Drawing.Size(204, 21)
        Me.txtProducto.TabIndex = 20
        '
        'txtPropietario
        '
        Me.txtPropietario.BackColor = System.Drawing.SystemColors.Window
        Me.txtPropietario.Location = New System.Drawing.Point(104, 46)
        Me.txtPropietario.Name = "txtPropietario"
        Me.txtPropietario.ReadOnly = True
        Me.txtPropietario.Size = New System.Drawing.Size(204, 21)
        Me.txtPropietario.TabIndex = 19
        '
        'txtTipo
        '
        Me.txtTipo.BackColor = System.Drawing.SystemColors.Window
        Me.txtTipo.Location = New System.Drawing.Point(104, 10)
        Me.txtTipo.Name = "txtTipo"
        Me.txtTipo.ReadOnly = True
        Me.txtTipo.Size = New System.Drawing.Size(204, 21)
        Me.txtTipo.TabIndex = 18
        '
        'lblStatus
        '
        Me.lblStatus.AutoSize = True
        Me.lblStatus.ForeColor = System.Drawing.Color.Black
        Me.lblStatus.Location = New System.Drawing.Point(370, 49)
        Me.lblStatus.Name = "lblStatus"
        Me.lblStatus.Size = New System.Drawing.Size(42, 13)
        Me.lblStatus.TabIndex = 17
        Me.lblStatus.Text = "Status:"
        '
        'lblProducto
        '
        Me.lblProducto.AutoSize = True
        Me.lblProducto.ForeColor = System.Drawing.Color.Black
        Me.lblProducto.Location = New System.Drawing.Point(12, 85)
        Me.lblProducto.Name = "lblProducto"
        Me.lblProducto.Size = New System.Drawing.Size(54, 13)
        Me.lblProducto.TabIndex = 16
        Me.lblProducto.Text = "Producto:"
        '
        'lblPropietario
        '
        Me.lblPropietario.AutoSize = True
        Me.lblPropietario.ForeColor = System.Drawing.Color.Black
        Me.lblPropietario.Location = New System.Drawing.Point(12, 49)
        Me.lblPropietario.Name = "lblPropietario"
        Me.lblPropietario.Size = New System.Drawing.Size(63, 13)
        Me.lblPropietario.TabIndex = 15
        Me.lblPropietario.Text = "Propietario:"
        '
        'lblTipo
        '
        Me.lblTipo.AutoSize = True
        Me.lblTipo.ForeColor = System.Drawing.Color.Black
        Me.lblTipo.Location = New System.Drawing.Point(12, 13)
        Me.lblTipo.Name = "lblTipo"
        Me.lblTipo.Size = New System.Drawing.Size(88, 13)
        Me.lblTipo.TabIndex = 14
        Me.lblTipo.Text = "Tipo de vehículo:"
        '
        'cboCelula
        '
        Me.cboCelula.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboCelula.Location = New System.Drawing.Point(556, 11)
        Me.cboCelula.Name = "cboCelula"
        Me.cboCelula.Size = New System.Drawing.Size(121, 21)
        Me.cboCelula.TabIndex = 5
        '
        'lblCelula
        '
        Me.lblCelula.AutoSize = True
        Me.lblCelula.ForeColor = System.Drawing.Color.Black
        Me.lblCelula.Location = New System.Drawing.Point(516, 11)
        Me.lblCelula.Name = "lblCelula"
        Me.lblCelula.Size = New System.Drawing.Size(40, 13)
        Me.lblCelula.TabIndex = 4
        Me.lblCelula.Text = "&Célula:"
        '
        'pnlTitulo
        '
        Me.pnlTitulo.Controls.Add(Me.rlblTitulo)
        Me.pnlTitulo.Dock = System.Windows.Forms.DockStyle.Left
        Me.pnlTitulo.Location = New System.Drawing.Point(0, 50)
        Me.pnlTitulo.Name = "pnlTitulo"
        Me.pnlTitulo.Size = New System.Drawing.Size(24, 331)
        Me.pnlTitulo.TabIndex = 7
        '
        'rlblTitulo
        '
        Me.rlblTitulo.Border = False
        Me.rlblTitulo.Caption = "Autotanques de célula x"
        Me.rlblTitulo.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.rlblTitulo.Font = New System.Drawing.Font("Tahoma", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rlblTitulo.ForeColor = System.Drawing.Color.DarkSlateBlue
        Me.rlblTitulo.Location = New System.Drawing.Point(0, 63)
        Me.rlblTitulo.Name = "rlblTitulo"
        Me.rlblTitulo.RotationAngle = 270
        Me.rlblTitulo.Size = New System.Drawing.Size(25, 268)
        Me.rlblTitulo.TabIndex = 6
        '
        'tbOperador
        '
        Me.tbOperador.Appearance = System.Windows.Forms.ToolBarAppearance.Flat
        Me.tbOperador.Buttons.AddRange(New System.Windows.Forms.ToolBarButton() {Me.Sep0, Me.btnAgregar, Me.btnEliminar, Me.btnModificar, Me.btnAbreCiclo, Me.btnStatus, Me.Sep1, Me.btnFiltro, Me.btnBuscar, Me.Sep2, Me.btnActualizar, Me.Sep3, Me.btnCerrar, Me.Sep4})
        Me.tbOperador.DropDownArrows = True
        Me.tbOperador.ImageList = Me.imgHerramientas
        Me.tbOperador.Location = New System.Drawing.Point(0, 0)
        Me.tbOperador.Name = "tbOperador"
        Me.tbOperador.ShowToolTips = True
        Me.tbOperador.Size = New System.Drawing.Size(768, 50)
        Me.tbOperador.TabIndex = 8
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
        'btnAbreCiclo
        '
        Me.btnAbreCiclo.ImageIndex = 9
        Me.btnAbreCiclo.Name = "btnAbreCiclo"
        Me.btnAbreCiclo.Text = "Abrir ciclo"
        Me.btnAbreCiclo.ToolTipText = "Crear una salida automáticamente"
        Me.btnAbreCiclo.Visible = False
        '
        'btnStatus
        '
        Me.btnStatus.ImageIndex = 3
        Me.btnStatus.Name = "btnStatus"
        Me.btnStatus.Text = "Inactivar"
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
        '
        'vgrdCatalogo
        '
        Me.vgrdCatalogo.AlternativeBackColor = System.Drawing.Color.Cornsilk        
        Me.vgrdCatalogo.BackColor = System.Drawing.Color.FloralWhite
        Me.vgrdCatalogo.CheckCondition = Nothing
        Me.vgrdCatalogo.DataSource = Nothing
        Me.vgrdCatalogo.Dock = System.Windows.Forms.DockStyle.Fill
        Me.vgrdCatalogo.FullRowSelect = True
        Me.vgrdCatalogo.GridLines = True
        Me.vgrdCatalogo.HidedColumnNames = New String() {"Celula", "Marca", "Status", "Tipo", "Propietario", "Producto"}
        Me.vgrdCatalogo.Location = New System.Drawing.Point(24, 50)
        Me.vgrdCatalogo.MultiSelect = False
        Me.vgrdCatalogo.Name = "vgrdCatalogo"
        Me.vgrdCatalogo.NullText = ""
        Me.vgrdCatalogo.PKColumnNames = New String() {"Autotanque"}
        Me.vgrdCatalogo.Size = New System.Drawing.Size(744, 331)
        Me.vgrdCatalogo.TabIndex = 6
        Me.vgrdCatalogo.UseCompatibleStateImageBehavior = False
        Me.vgrdCatalogo.View = System.Windows.Forms.View.Details
        '
        'frmAutotanque
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 14)
        Me.BackColor = System.Drawing.Color.OldLace
        Me.ClientSize = New System.Drawing.Size(768, 493)
        Me.Controls.Add(Me.vgrdCatalogo)
        Me.Controls.Add(Me.pnlTitulo)
        Me.Controls.Add(Me.cboCelula)
        Me.Controls.Add(Me.lblCelula)
        Me.Controls.Add(Me.pnlDatosAdicionales)
        Me.Controls.Add(Me.tbOperador)
        Me.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ForeColor = System.Drawing.Color.Black
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Menu = Me.mnuAutotanque
        Me.Name = "frmAutotanque"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Catálogo de autotanques"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.pnlDatosAdicionales.ResumeLayout(False)
        Me.pnlDatosAdicionales.PerformLayout()
        Me.pnlTitulo.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

#End Region

#Region "Variables globales"
    Dim dtAutotanque As New DataTable()
    Dim Filtro As String
#End Region

#Region "Rutinas de actualización"
    Public Sub CargaInformacion()
        If Not cboCelula.SelectedValue Is Nothing Then
            Dim daLogistica As New SqlDataAdapter("Select * from vwLOGAutotanque Where Celula = @Celula", cnSigamet)
            Dim PKColumn(0) As DataColumn
            vgrdCatalogo.DataSource = Nothing
            daLogistica.SelectCommand.Parameters.Add("@Celula", SqlDbType.TinyInt).Value = CInt(cboCelula.SelectedValue)
            If Filtro <> "" Then
                daLogistica.SelectCommand.CommandText &= Filtro
            End If
            daLogistica.SelectCommand.CommandText &= " order by Autotanque"
            Try
                dtAutotanque.Clear()
                daLogistica.Fill(dtAutotanque)
                PKColumn(0) = dtAutotanque.Columns(0)
                dtAutotanque.PrimaryKey = PKColumn
                vgrdCatalogo.DataSource = dtAutotanque
                CargaDatosAdicionales()
            Catch ex As Exception
                ExMessage(ex)
            End Try
        End If
    End Sub
    Public Sub CargaDatosAdicionales()
        If Not vgrdCatalogo.CurrentRow Is Nothing Then
            Dim FoundRow As DataRow = vgrdCatalogo.CurrentRow
            If Not FoundRow Is Nothing Then
                txtTipo.Text = CStr(FoundRow("Tipo"))
                txtPropietario.Text = CStr(FoundRow("Propietario"))
                txtProducto.Text = CStr(FoundRow("Producto"))
                txtMarca.Text = CStr(FoundRow("Marca"))
                txtStatus.Text = CStr(FoundRow("Status"))
                If txtStatus.Text.Trim = "ACTIVO" Then
                    btnStatus.Text = "Inactivar"
                    btnStatus.ImageIndex = 3
                Else
                    btnStatus.Text = "Activar"
                    btnStatus.ImageIndex = 8
                End If
            Else
                txtTipo.Clear()
                txtPropietario.Clear()
                txtProducto.Clear()
                txtMarca.Clear()
                txtStatus.Clear()
            End If
        Else
            txtTipo.Clear()
            txtPropietario.Clear()
            txtProducto.Clear()
            txtMarca.Clear()
            txtStatus.Clear()
        End If
    End Sub
    Private Sub mniFiltro_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mniTodos.Click, mniActivos.Click, mniInactivos.Click
        mniTodos.Checked = False
        mniActivos.Checked = False
        mniInactivos.Checked = False
        CType(sender, MenuItem).Checked = True
        Select Case CType(sender, MenuItem).Text
            Case "&Todos"
                Filtro = ""
                rlblTitulo.Caption = "Autotanques de célula " & CStr(cboCelula.SelectedValue)
            Case "&Activos"
                Filtro = " and Status = 'ACTIVO'"
                rlblTitulo.Caption = "Autotanques activos de célula " & CStr(cboCelula.SelectedValue)
            Case "&Inactivos"
                Filtro = " and Status = 'INACTIVO'"
                rlblTitulo.Caption = "Autotanques inactivos de célula " & CStr(cboCelula.SelectedValue)
        End Select
        CargaInformacion()
    End Sub
    Private Sub cboCelula_SelectedValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboCelula.SelectedValueChanged
        If Not cboCelula.SelectedValue Is Nothing Then
            CargaInformacion()
            If mniTodos.Checked Then
                rlblTitulo.Caption = "Autotanques de célula " & CStr(cboCelula.SelectedValue)
            ElseIf mniActivos.Checked Then
                rlblTitulo.Caption = "Autotanques activos de célula " & CStr(cboCelula.SelectedValue)
            Else
                rlblTitulo.Caption = "Autotanques inactivos de célula " & CStr(cboCelula.SelectedValue)
            End If
        End If
    End Sub
    Private Sub vgrdCatalogo_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles vgrdCatalogo.SelectedIndexChanged
        CargaDatosAdicionales()
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
    Private Sub mniAbrirCiclo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mniAbrirCiclo.Click
        AbrirCiclo()
    End Sub
    Private Sub tbOperador_ButtonClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.ToolBarButtonClickEventArgs) Handles tbOperador.ButtonClick
        Select Case e.Button.Text
            Case "Agregar"
                Agregar()
            Case "Eliminar"
                Eliminar()
            Case "Abrir ciclo"
                AbrirCiclo()
            Case "Inactivar"
                Inactivar()
            Case "Activar"
                Activar()
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
        If OperacionLogistica(3).Habilitada Then
            'Creación y carga de formulario de captura
            Dim frmCapturaAutotanque As New frmCapturaAutotanque(CInt(cboCelula.SelectedValue))
            frmCapturaAutotanque.ShowDialog()
            'Validación de resultados
            If frmCapturaAutotanque.DialogResult = DialogResult.OK Then
                'Carga de información
                CargaInformacion()
                CargaDatosAdicionales()
                'Recuperación de posición en grid
                vgrdCatalogo.FindFirst("Autotanque", frmCapturaAutotanque.txtAutotanque.Text)
                vgrdCatalogo.Focus()
            End If
            'Eliminado de objetos
            frmCapturaAutotanque.Dispose()
        Else
            ErrMessage("No tiene privilegios para realizar esta operación")
        End If
    End Sub
    Private Sub Eliminar()
        'Validación de privilegios
        If OperacionLogistica(3).Habilitada Then
            'Validación de selección en grid
            If Not vgrdCatalogo.CurrentRow Is Nothing Then
                'Confirmación de acción
                If MessageBox.Show("¿Desea eliminar al autotanque " & CStr(vgrdCatalogo.CurrentRow("Autotanque")) & "?", _
                        Application.ProductName & "v." & Application.ProductVersion, MessageBoxButtons.YesNo, MessageBoxIcon.Question, _
                        MessageBoxDefaultButton.Button2) = DialogResult.Yes Then
                    Dim cmdLogistica As New SqlCommand("Delete from Autotanque where Autotanque = @Autotanque", cnSigamet)
                    Me.Cursor = Cursors.WaitCursor
                    'Carga de parametros
                    cmdLogistica.Parameters.Add("@Autotanque", SqlDbType.Int).Value = CInt(CType(vgrdCatalogo.CurrentPK, Object())(0))
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
        If OperacionLogistica(3).Habilitada Then
            'Validación de selección en grid
            If Not vgrdCatalogo.CurrentRow Is Nothing Then
                'Confirmación de acción
                If MessageBox.Show("¿Desea inactivar al autotanque " & CStr(vgrdCatalogo.CurrentRow("Autotanque")) & "?", _
                        Application.ProductName & "v." & Application.ProductVersion, MessageBoxButtons.YesNo, MessageBoxIcon.Question, _
                        MessageBoxDefaultButton.Button2) = DialogResult.Yes Then
                    Dim cmdLogistica As New SqlClient.SqlCommand("Update Autotanque set Status = 'INACTIVO', FBaja = getdate() where Autotanque = @Autotanque", cnSigamet)
                    'Carga de parámetros
                    cmdLogistica.Parameters.Add("@Autotanque", SqlDbType.Int).Value = CInt(CType(vgrdCatalogo.CurrentPK, Object())(0))
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
                    vgrdCatalogo.FindFirst("Autotanque", CStr(cmdLogistica.Parameters("@Autotanque").Value))
                    vgrdCatalogo.Focus()
                End If
            End If
        Else
            ErrMessage("No tiene privilegios para realizar esta operación.")
        End If
    End Sub
    Private Sub Activar()
        'Validación de privilegios
        If OperacionLogistica(3).Habilitada Then
            'Validación de selección en grid
            If Not vgrdCatalogo.CurrentRow Is Nothing Then
                'Confirmación de acción
                If MessageBox.Show("¿Desea activar al autotanque " & CStr(vgrdCatalogo.CurrentRow("Autotanque")) & "?", _
                        Application.ProductName & "v." & Application.ProductVersion, MessageBoxButtons.YesNo, MessageBoxIcon.Question, _
                        MessageBoxDefaultButton.Button2) = DialogResult.Yes Then
                    Dim cmdLogistica As New SqlClient.SqlCommand("Update Autotanque set Status = 'ACTIVO' where Autotanque = @Autotanque", cnSigamet)
                    'Carga de parámetros
                    cmdLogistica.Parameters.Add("@Autotanque", SqlDbType.Int).Value = CInt(CType(vgrdCatalogo.CurrentPK, Object())(0))
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
                    vgrdCatalogo.FindFirst("Autotanque", CStr(cmdLogistica.Parameters("@Autotanque").Value))
                    vgrdCatalogo.Focus()
                End If
            End If
        Else
            ErrMessage("No tiene privilegios para realizar esta operación.")
        End If
    End Sub
    Private Sub Modificar()
        'Validación de priviliegios
        If OperacionLogistica(3).Habilitada Then
            'Validación de selección en grid
            If Not vgrdCatalogo.CurrentRow Is Nothing Then
                'Creación y carga de formulario
                Dim frmCapturaAutotanque As New frmCapturaAutotanque(CInt(cboCelula.SelectedValue), CInt(CType(vgrdCatalogo.CurrentPK, Object())(0)))
                frmCapturaAutotanque.ShowDialog()
                'Validación de resultados
                If frmCapturaAutotanque.DialogResult = DialogResult.OK Then
                    'Carga de información
                    CargaInformacion()
                    CargaDatosAdicionales()
                    'Recuperación de posición en grid
                    vgrdCatalogo.FindFirst("Autotanque", frmCapturaAutotanque.txtAutotanque.Text)
                    vgrdCatalogo.Focus()
                End If
                'Eliminación de objetos
                frmCapturaAutotanque.Dispose()
            End If
        Else
            ErrMessage("No tiene privilegios para realizar esta operación.")
        End If
    End Sub
    Private Sub Buscar()
        'Petición de busqueda
        Dim Operador As String = InputBox("No. de autotanque:")
        'Validación de texto de busqueda
        If Trim(Operador) <> "" Then
            'Busqueda
            If vgrdCatalogo.FindFirst("Autotanque", Trim(Operador)) < 0 Then
                MessageBox.Show("No se ha encontrado el autotanque no. " & Trim(Operador), Application.ProductName & " v." & Application.ProductVersion, MessageBoxButtons.OK, MessageBoxIcon.Information)
            Else
                vgrdCatalogo.Focus()
            End If
        End If
    End Sub
    Private Sub AbrirCiclo()
        Dim frmAbrirCiclo As frmAbrirCiclo
        Dim crow As DataRow
        If Not vgrdCatalogo.CurrentRow Is Nothing Then
            crow = vgrdCatalogo.CurrentRow
            frmAbrirCiclo = New frmAbrirCiclo(CInt(crow("Celula")), CInt(crow("Ruta")), CInt(crow("Autotanque")))
            frmAbrirCiclo.ShowDialog()
        End If
    End Sub
#End Region

#Region "Rutinas de configuración"
    Private Sub CargaConfiguracion()
        Try
            Dim Settings As AppSettings
            Dim ctrl As Control
            'Validaciíon de archivo de configuración
            If File.Exists(Application.StartupPath & "\" & System.Environment.UserName & ".Logistica.exe.config") Then
                Settings = New AppSettings(Application.StartupPath & "\" & System.Environment.UserName & ".Logistica.exe.config")
            Else
                Settings = New AppSettings(Application.StartupPath & "\" & "Default.Logistica.exe.config")
            End If
            'Carga de parámetros
            Me.BackColor = Color.FromArgb(CInt(Settings.GetSetting("frmAutotanque", "BackColor")))
            vgrdCatalogo.BackColor = Color.FromArgb(CInt(Settings.GetSetting("frmAutotanque", "CatalogoBackColor")))
            vgrdCatalogo.AlternativeBackColor = Color.FromArgb(CInt(Settings.GetSetting("frmAutotanque", "CatalogoAltBackColor")))
            vgrdCatalogo.ForeColor = Color.FromArgb(CInt(Settings.GetSetting("frmAutotanque", "CatalogoForeColor")))
            pnlDatosAdicionales.BackColor = Color.FromArgb(CInt(Settings.GetSetting("frmAutotanque", "DExtraBackColor")))
            pnlDatosAdicionales.ForeColor = Color.FromArgb(CInt(Settings.GetSetting("frmAutotanque", "DExtraForeColor")))
            For Each ctrl In pnlDatosAdicionales.Controls
                If ctrl.GetType.Name = "TextBox" Then
                    ctrl.BackColor = Color.FromArgb(CInt(Settings.GetSetting("frmAutotanque", "DExtraTBackColor")))
                    ctrl.ForeColor = Color.FromArgb(CInt(Settings.GetSetting("frmAutotanque", "DExtraTForeColor")))
                End If
            Next
        Catch ex As Exception
            ErrMessage("No existe el archivo " + Application.StartupPath & "\" & "Default.Logistica.exe.config" + " ó al mismo le hace falta alguna de las configuraciones. LLame a soporte. Detalles: " + ex.Message)
        End Try
    End Sub
    Private Sub frmOperador_Paint(ByVal sender As Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles MyBase.Paint
        CargaConfiguracion()
    End Sub
    Private Sub frmAutotanque_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Activated
        CargaConfiguracion()
    End Sub
#End Region


    
        
    Private Sub frmAutotanque_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load

    End Sub
End Class
