Imports System
Imports System.Data
Imports System.Data.SqlClient
Imports System.IO
Imports Logistica
Imports System.Collections.Generic

Public Class frmUsuarioMovil
    Inherits System.Windows.Forms.Form

#Region " Windows Form Designer generated code "

    Public Sub New()
        MyBase.New()

        'This call is required by the Windows Form Designer.
        InitializeComponent()

        'Add any initialization after the InitializeComponent() call
        'Dim cmdLogistica As New SqlCommand("Select C.Celula as Celula, ltrim(rtrim(C.Descripcion)) as Descripcion from Celula C inner join UsuarioCelula UC " _
        '              & " on C.Celula = UC.Celula and UC.Usuario = @Usuario and C.Comercial = 1", cnSigamet)
        'Dim daLogistica As New SqlDataAdapter(cmdLogistica)
        'Dim dtCelula As New DataTable()
        'cmdLogistica.Parameters.Add("@Usuario", SqlDbType.Char).Value = _Usuario
        'Try
        '    daLogistica.Fill(dtCelula)
        'Catch ex As Exception
        '    ExMessage(ex)
        'End Try
        'cboCelula.ValueMember = "Celula"
        'cboCelula.DisplayMember = "Descripcion"
        'cboCelula.DataSource = dtCelula
        'cboCelula.SelectedValue = _Celula
        'cmdLogistica.Dispose()
        'daLogistica.Dispose()
        CargaInformacion()
        chkSoporteMovilanterior.Visible = _soporteMovilAnterior
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
    Friend WithEvents mnuAutotanque As System.Windows.Forms.MainMenu
    Friend WithEvents vgrdCatalogo As Logistica.ViewGrid
    Friend WithEvents pnlTitulo As System.Windows.Forms.Panel
    Friend WithEvents rlblTitulo As Logistica.RotatableLabel
    Friend WithEvents tbOperador As System.Windows.Forms.ToolBar
    Friend WithEvents Sep0 As System.Windows.Forms.ToolBarButton
    Friend WithEvents btnAgregar As System.Windows.Forms.ToolBarButton
    Friend WithEvents btnModificar As System.Windows.Forms.ToolBarButton
    Friend WithEvents Sep1 As System.Windows.Forms.ToolBarButton
    Friend WithEvents mnuFiltro As System.Windows.Forms.ContextMenu
    Friend WithEvents btnBuscar As System.Windows.Forms.ToolBarButton
    Friend WithEvents Sep2 As System.Windows.Forms.ToolBarButton
    Friend WithEvents Sep3 As System.Windows.Forms.ToolBarButton
    Friend WithEvents btnCerrar As System.Windows.Forms.ToolBarButton
    Friend WithEvents Sep4 As System.Windows.Forms.ToolBarButton
    Friend WithEvents imgHerramientas As System.Windows.Forms.ImageList
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
    Friend WithEvents Sep5 As System.Windows.Forms.ToolBarButton
    Friend WithEvents btnEliminarFinDeDia As System.Windows.Forms.ToolBarButton
    Friend WithEvents btnVenta As System.Windows.Forms.ToolBarButton
    Friend WithEvents cmbFiltro As System.Windows.Forms.ToolBarButton
    Friend WithEvents cmbCelulas As System.Windows.Forms.ComboBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents chkSoporteMovilanterior As System.Windows.Forms.CheckBox
    Friend WithEvents mniAbrirCiclo As System.Windows.Forms.MenuItem
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmUsuarioMovil))
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
        Me.pnlTitulo = New System.Windows.Forms.Panel()
        Me.rlblTitulo = New Logistica.RotatableLabel()
        Me.tbOperador = New System.Windows.Forms.ToolBar()
        Me.Sep0 = New System.Windows.Forms.ToolBarButton()
        Me.btnAgregar = New System.Windows.Forms.ToolBarButton()
        Me.btnModificar = New System.Windows.Forms.ToolBarButton()
        Me.Sep1 = New System.Windows.Forms.ToolBarButton()
        Me.btnBuscar = New System.Windows.Forms.ToolBarButton()
        Me.Sep2 = New System.Windows.Forms.ToolBarButton()
        Me.btnActualizar = New System.Windows.Forms.ToolBarButton()
        Me.Sep5 = New System.Windows.Forms.ToolBarButton()
        Me.btnVenta = New System.Windows.Forms.ToolBarButton()
        Me.btnEliminarFinDeDia = New System.Windows.Forms.ToolBarButton()
        Me.Sep3 = New System.Windows.Forms.ToolBarButton()
        Me.btnCerrar = New System.Windows.Forms.ToolBarButton()
        Me.Sep4 = New System.Windows.Forms.ToolBarButton()
        Me.imgHerramientas = New System.Windows.Forms.ImageList(Me.components)
        Me.mnuFiltro = New System.Windows.Forms.ContextMenu()
        Me.mniTodos = New System.Windows.Forms.MenuItem()
        Me.mniActivos = New System.Windows.Forms.MenuItem()
        Me.mniInactivos = New System.Windows.Forms.MenuItem()
        Me.cmbCelulas = New System.Windows.Forms.ComboBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.vgrdCatalogo = New Logistica.ViewGrid()
        Me.chkSoporteMovilanterior = New System.Windows.Forms.CheckBox()
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
        'pnlTitulo
        '
        Me.pnlTitulo.Controls.Add(Me.rlblTitulo)
        Me.pnlTitulo.Dock = System.Windows.Forms.DockStyle.Left
        Me.pnlTitulo.Location = New System.Drawing.Point(0, 42)
        Me.pnlTitulo.Name = "pnlTitulo"
        Me.pnlTitulo.Size = New System.Drawing.Size(24, 409)
        Me.pnlTitulo.TabIndex = 7
        '
        'rlblTitulo
        '
        Me.rlblTitulo.Border = False
        Me.rlblTitulo.Caption = "Usuarios Móvil"
        Me.rlblTitulo.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.rlblTitulo.Font = New System.Drawing.Font("Tahoma", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rlblTitulo.ForeColor = System.Drawing.Color.DarkSlateBlue
        Me.rlblTitulo.Location = New System.Drawing.Point(0, 234)
        Me.rlblTitulo.Name = "rlblTitulo"
        Me.rlblTitulo.RotationAngle = 270
        Me.rlblTitulo.Size = New System.Drawing.Size(25, 175)
        Me.rlblTitulo.TabIndex = 6
        '
        'tbOperador
        '
        Me.tbOperador.Appearance = System.Windows.Forms.ToolBarAppearance.Flat
        Me.tbOperador.Buttons.AddRange(New System.Windows.Forms.ToolBarButton() {Me.Sep0, Me.btnAgregar, Me.btnModificar, Me.Sep1, Me.btnBuscar, Me.Sep2, Me.btnActualizar, Me.Sep5, Me.btnVenta, Me.btnEliminarFinDeDia, Me.Sep3, Me.btnCerrar, Me.Sep4})
        Me.tbOperador.DropDownArrows = True
        Me.tbOperador.ImageList = Me.imgHerramientas
        Me.tbOperador.Location = New System.Drawing.Point(0, 0)
        Me.tbOperador.Name = "tbOperador"
        Me.tbOperador.ShowToolTips = True
        Me.tbOperador.Size = New System.Drawing.Size(768, 42)
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
        Me.btnAgregar.ToolTipText = "Nuevo usuario móvil"
        '
        'btnModificar
        '
        Me.btnModificar.ImageIndex = 2
        Me.btnModificar.Name = "btnModificar"
        Me.btnModificar.Text = "Modificar"
        Me.btnModificar.ToolTipText = "Modificar usuario móvil"
        '
        'Sep1
        '
        Me.Sep1.Name = "Sep1"
        Me.Sep1.Style = System.Windows.Forms.ToolBarButtonStyle.Separator
        '
        'btnBuscar
        '
        Me.btnBuscar.ImageIndex = 4
        Me.btnBuscar.Name = "btnBuscar"
        Me.btnBuscar.Text = "Buscar"
        Me.btnBuscar.ToolTipText = "Buscar usuario móvil"
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
        Me.btnActualizar.ToolTipText = "Actualizar"
        '
        'Sep5
        '
        Me.Sep5.Name = "Sep5"
        Me.Sep5.Style = System.Windows.Forms.ToolBarButtonStyle.Separator
        '
        'btnVenta
        '
        Me.btnVenta.ImageIndex = 11
        Me.btnVenta.Name = "btnVenta"
        Me.btnVenta.Text = "Ventas"
        Me.btnVenta.ToolTipText = "Ventas del día"
        '
        'btnEliminarFinDeDia
        '
        Me.btnEliminarFinDeDia.ImageIndex = 10
        Me.btnEliminarFinDeDia.Name = "btnEliminarFinDeDia"
        Me.btnEliminarFinDeDia.Text = "Fin de día"
        Me.btnEliminarFinDeDia.ToolTipText = "Eliminar fin de día"
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
        Me.imgHerramientas.Images.SetKeyName(10, "Basura.png")
        Me.imgHerramientas.Images.SetKeyName(11, "f1207829.ico")
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
        'cmbCelulas
        '
        Me.cmbCelulas.FormattingEnabled = True
        Me.cmbCelulas.Location = New System.Drawing.Point(468, 11)
        Me.cmbCelulas.Name = "cmbCelulas"
        Me.cmbCelulas.Size = New System.Drawing.Size(178, 21)
        Me.cmbCelulas.TabIndex = 9
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(412, 15)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(40, 13)
        Me.Label1.TabIndex = 10
        Me.Label1.Text = "Celula:"
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
        Me.vgrdCatalogo.HidedColumnNames = New String() {"Password", "PasswordTitular", "IdPoPrecio", "IdSucursal"}
        Me.vgrdCatalogo.Location = New System.Drawing.Point(24, 42)
        Me.vgrdCatalogo.MultiSelect = False
        Me.vgrdCatalogo.Name = "vgrdCatalogo"
        Me.vgrdCatalogo.NullText = ""
        Me.vgrdCatalogo.PKColumnNames = New String() {"IdUsuario"}
        Me.vgrdCatalogo.Size = New System.Drawing.Size(744, 409)
        Me.vgrdCatalogo.TabIndex = 6
        Me.vgrdCatalogo.UseCompatibleStateImageBehavior = False
        Me.vgrdCatalogo.View = System.Windows.Forms.View.Details
        '
        'chkSoporteMovilanterior
        '
        Me.chkSoporteMovilanterior.AutoSize = True
        Me.chkSoporteMovilanterior.Location = New System.Drawing.Point(669, 11)
        Me.chkSoporteMovilanterior.Name = "chkSoporteMovilanterior"
        Me.chkSoporteMovilanterior.Size = New System.Drawing.Size(96, 17)
        Me.chkSoporteMovilanterior.TabIndex = 11
        Me.chkSoporteMovilanterior.Text = "Versió anterior"
        Me.chkSoporteMovilanterior.UseVisualStyleBackColor = True
        Me.chkSoporteMovilanterior.Visible = False
        '
        'frmUsuarioMovil
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 14)
        Me.BackColor = System.Drawing.Color.OldLace
        Me.ClientSize = New System.Drawing.Size(768, 451)
        Me.Controls.Add(Me.chkSoporteMovilanterior)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.cmbCelulas)
        Me.Controls.Add(Me.vgrdCatalogo)
        Me.Controls.Add(Me.pnlTitulo)
        Me.Controls.Add(Me.tbOperador)
        Me.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ForeColor = System.Drawing.Color.Black
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Menu = Me.mnuAutotanque
        Me.Name = "frmUsuarioMovil"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Catálogo de usuarios movil"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.pnlTitulo.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

#End Region

#Region "Variables globales"
    Dim dtUsuarioMovil As New DataTable()
    Dim Filtro As String
    Dim _UsuarioMovil As Integer
#End Region

#Region "Rutinas de actualización"
    Public Sub CargaInformacion()
        vgrdCatalogo.Clear()
        If (cmbCelulas.Items.Count > 0) Then
            vgrdCatalogo.DataSource = CargaDatosUsuarioMovil(CType(cmbCelulas.SelectedItem, Combo).IdCombo)
        End If
    End Sub
#End Region

    Private Function CargaDatosUsuarioMovil(ByVal Celula As Integer) As DataTable        
        Dim cmdLogistica As New SqlCommand("spLOGConsultaUsuarioMovil", cnSigamet)
        cmdLogistica.CommandType = CommandType.StoredProcedure
        Dim dtDatos As New DataTable

        If chkSoporteMovilanterior.Checked Then
            cmdLogistica.CommandText = "spLOGConsultaUsuarioMovilV2"
        Else
            'Carga de parámetros
            cmdLogistica.Parameters.Add("@Celula", SqlDbType.Int).Value = Celula
        End If

        Try
            cnSigamet.Open()
            Dim daDatos As New SqlDataAdapter
            daDatos.SelectCommand = cmdLogistica
            daDatos.Fill(dtDatos)
        Catch ex As Exception
            ExMessage(ex)
        Finally
            cnSigamet.Close()
            cmdLogistica.Dispose()
        End Try
        Return dtDatos
    End Function

   

    Function ConsultarSucursales(ByVal Usuario As String) As List(Of Combo)
        Dim lista As List(Of Combo)
        lista = New List(Of Combo)

        Try
            Dim command As SqlCommand
            command = New SqlCommand("spConsultaCelulasPorUsuario", cnSigamet)
            command.CommandType = CommandType.StoredProcedure
            command.Parameters.Add("@Usuario", SqlDbType.VarChar).Value = Usuario
            cnSigamet.Open()

            Dim reader As SqlDataReader
            reader = command.ExecuteReader()

            While (reader.Read())
                Dim grupo As New Combo()
                grupo.IdCombo = Convert.ToInt32(reader("Celula").ToString())
                grupo.DescripcionCombo = reader("Descripcion").ToString()
                lista.Add(grupo)
            End While
        Catch ex As Exception
            MsgBox(ex)
            Throw
        Finally
            If (cnSigamet.State = ConnectionState.Open) Then
                cnSigamet.Close()
            End If
        End Try
        Return lista
    End Function


    Public Class Combo

        Private id As Integer
        Public Property IdCombo() As Integer
            Get
                Return id
            End Get
            Set(ByVal value As Integer)
                id = value
            End Set
        End Property

        Private descripcion As String
        Public Property DescripcionCombo() As String
            Get
                Return descripcion
            End Get
            Set(ByVal value As String)
                descripcion = value
            End Set
        End Property


    End Class

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
    Private Sub mniBuscar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mniBuscar.Click
        Buscar()
    End Sub
    Private Sub mniActualizar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mniActualizar.Click
        CargaInformacion()
    End Sub
    Private Sub tbOperador_ButtonClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.ToolBarButtonClickEventArgs) Handles tbOperador.ButtonClick
        Select Case e.Button.Text
            Case "Agregar"
                Agregar()
            Case "Modificar"
                Modificar()
            Case "Buscar"
                Buscar()
            Case "Actualizar"
                CargaInformacion()
            Case "Fin de día"
                EliminarFinDia()
            Case "Ventas"
                Ventas()
            Case "Cerrar"
                Me.Close()
                Me.Dispose()
        End Select
    End Sub
#End Region

#Region "Rutina de manejo de datos"
    Private Sub Agregar()
        If _versionMovilGas = 3 Then
            MessageBox.Show("Operación no disponible.", "MovilGas", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Return
        End If


        'Validación de privilegios        
        'Creación y carga de formulario de captura
        Dim frmCapturaUsuarioMovil As New frmCapturaUsuarioMovil()
        frmCapturaUsuarioMovil.ShowDialog()
        'Validación de resultados
        If frmCapturaUsuarioMovil.DialogResult = DialogResult.OK Then
            MessageBox.Show("Se dio de alta al usuario.", "Alta de usuario móvil", MessageBoxButtons.OK, MessageBoxIcon.Information)
            'Carga de información
            CargaInformacion()
            'Recuperación de posición en grid
            vgrdCatalogo.FindFirst("IdUsuario", frmCapturaUsuarioMovil.txtIdUsuario.Text)
            vgrdCatalogo.Focus()
        End If
        'Eliminado de objetos
        frmCapturaUsuarioMovil.Dispose()
    End Sub

    Private Sub Modificar()
        'Validación de priviliegios        
        'Validación de selección en grid
        If Not vgrdCatalogo.CurrentRow Is Nothing Then
            'Creación y carga de formulario

            Dim frmCapturaUsuarioMovil As New Form()

            Select Case _versionMovilGas
                Case 2
                    frmCapturaUsuarioMovil = New frmCapturaUsuarioMovil(_UsuarioMovil)
                Case 3
                    Dim _sesion As Integer = 0,
                        _estadoSesion As String = String.Empty,
                        _estadoLiquidacion As String = String.Empty

                    Int32.TryParse(vgrdCatalogo.CurrentRow.Item(5).ToString(), _sesion)
                    _estadoSesion = vgrdCatalogo.CurrentRow.Item(10).ToString()
                    _estadoLiquidacion = vgrdCatalogo.CurrentRow.Item(15).ToString()

                    If ((_estadoLiquidacion = "LIQUIDADO") OrElse (_estadoLiquidacion = "LIQCAJA") OrElse (_estadoSesion = "SIN SESION")) Then
                        MessageBox.Show("No puede modificar esta sesión.", "MovilGas", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                        Return
                    Else
                        frmCapturaUsuarioMovil = New ActualizacionSesion()

                        CType(frmCapturaUsuarioMovil, ActualizacionSesion).Usuario = vgrdCatalogo.CurrentRow.Item(1).ToString()
                        CType(frmCapturaUsuarioMovil, ActualizacionSesion).Nombre = vgrdCatalogo.CurrentRow.Item(4).ToString()
                        CType(frmCapturaUsuarioMovil, ActualizacionSesion).Sesion = _sesion
                        CType(frmCapturaUsuarioMovil, ActualizacionSesion).Ruta = vgrdCatalogo.CurrentRow.Item(7).ToString()
                        CType(frmCapturaUsuarioMovil, ActualizacionSesion).IMEI = vgrdCatalogo.CurrentRow.Item(9).ToString()
                        CType(frmCapturaUsuarioMovil, ActualizacionSesion).Camion = vgrdCatalogo.CurrentRow.Item(11).ToString()
                        CType(frmCapturaUsuarioMovil, ActualizacionSesion).EstadoSesion = vgrdCatalogo.CurrentRow.Item(10).ToString()
                        CType(frmCapturaUsuarioMovil, ActualizacionSesion).EstadoLiquidacion = vgrdCatalogo.CurrentRow.Item(15).ToString()

                        CType(frmCapturaUsuarioMovil, ActualizacionSesion).EstadoRecuperacion = vgrdCatalogo.CurrentRow.Item(16).ToString()
                    End If
            End Select

            frmCapturaUsuarioMovil.ShowDialog()
            'Validación de resultados
            If frmCapturaUsuarioMovil.DialogResult = DialogResult.OK Then
                MessageBox.Show("Los datos del usuario fueron modificados.", "Soporte móvil", MessageBoxButtons.OK, MessageBoxIcon.Information)
                'Carga de información
                CargaInformacion()
                'Recuperación de posición en grid
                vgrdCatalogo.FindFirst("IdUsuario", _UsuarioMovil)
                vgrdCatalogo.Focus()
            End If
            'Eliminación de objetos
            frmCapturaUsuarioMovil.Dispose()
        End If
    End Sub
    Private Sub EliminarFinDia()
        If _versionMovilGas = 3 Then
            MessageBox.Show("Operación no disponible.", "MovilGas", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Return
        End If

        'Validación de selección en grid
        If Not vgrdCatalogo.CurrentRow Is Nothing Then
            'Creación y carga de formulario
            Dim frmEliminaFinDeDia As New frmEliminaFinDia(_UsuarioMovil, vgrdCatalogo.CurrentRow("Nombre").ToString())
            frmEliminaFinDeDia.ShowDialog()
            'Validación de resultados
            If frmEliminaFinDeDia.DialogResult = DialogResult.OK Then
                MessageBox.Show("Se eliminó el fin de día", "Soporte móvil", MessageBoxButtons.OK, MessageBoxIcon.Information)
                'Carga de información
                CargaInformacion()
                'Recuperación de posición en grid
                vgrdCatalogo.FindFirst("IdUsuario", _UsuarioMovil)
                vgrdCatalogo.Focus()
            End If
            'Eliminación de objetos
            frmEliminaFinDeDia.Dispose()
        End If
    End Sub
    Private Sub Ventas()
        'Validación de selección en grid
        If Not vgrdCatalogo.CurrentRow Is Nothing Then
            'Creación y carga de formulario
            Dim frmVentas As New Form()

            If _versionMovilGas = 3 And chkSoporteMovilanterior.Checked = False Then
                'frmVentas = New frmVentasPortatil(vgrdCatalogo.CurrentRow.Item(4).ToString(), Int32.Parse(vgrdCatalogo.CurrentRow.Item(11).ToString()))
                frmVentas = New frmVentasPortatil(vgrdCatalogo.CurrentRow.Item(1).ToString(), vgrdCatalogo.CurrentRow.Item(4).ToString(), False)
            Else
                frmVentas = New frmVentasPortatil(_UsuarioMovil, CStr(vgrdCatalogo.CurrentRow("Nombre")), chkSoporteMovilanterior.Checked)
            End If


            frmVentas.ShowDialog()
            'Validación de resultados
            If frmVentas.DialogResult = DialogResult.OK Then
                'Carga de información
                CargaInformacion()
                'Recuperación de posición en grid
                vgrdCatalogo.FindFirst("IdUsuario", _UsuarioMovil)
                vgrdCatalogo.Focus()
            End If
            'Eliminación de objetos
            frmVentas.Dispose()
        End If
    End Sub
    Private Sub Buscar()
        'Petición de busqueda
        Dim UsuarioMovil As String = InputBox("Usuario Móvil:")
        'Validación de texto de busqueda
        If Trim(UsuarioMovil) <> "" Then
            'Busqueda
            If vgrdCatalogo.FindFirst("Nombre", Trim(UsuarioMovil)) < 0 Then
                MessageBox.Show("No se ha encontrado el usuario móvil" & Trim(UsuarioMovil), Application.ProductName & " v." & Application.ProductVersion, MessageBoxButtons.OK, MessageBoxIcon.Information)
            Else
                vgrdCatalogo.Focus()
            End If
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
        Catch ex As Exception
            ErrMessage("No existe el archivo " + Application.StartupPath & "\" & "Default.Logistica.exe.config" + " ó al mismo le hace falta alguna de las configuraciones. LLame a soporte. Detalles: " + ex.Message)
        End Try
    End Sub
    Private Sub frmOperador_Paint(ByVal sender As Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles MyBase.Paint
        CargaConfiguracion()
    End Sub
    Private Sub frmUsuarioMovil_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Activated
        CargaConfiguracion()
    End Sub
#End Region

    Private Sub frmUsuarioMovil_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load

        Dim listaSucursales As List(Of Combo) = ConsultarSucursales(_Usuario)
        cmbCelulas.Items.Clear()

        For Each g As Combo In listaSucursales
            cmbCelulas.Items.Add(g)
        Next

        cmbCelulas.ValueMember = "IdCombo"
        cmbCelulas.DisplayMember = "DescripcionCombo"

        If (cmbCelulas.Items.Count > 0) Then
            cmbCelulas.SelectedIndex = 0
        End If

        If OperacionLogistica(23).Habilitada = False And OperacionLogistica(24).Habilitada Then
            btnAgregar.Enabled = False
            btnAgregar.Visible = False
        End If

    End Sub

    Private Sub vgrdCatalogo_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles vgrdCatalogo.SelectedIndexChanged
        If Not vgrdCatalogo.CurrentRow Is Nothing Then
            _UsuarioMovil = CInt(vgrdCatalogo.CurrentRow("IdUsuario"))
        End If
    End Sub

    Private Sub cmbCelulas_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles cmbCelulas.SelectedIndexChanged
        vgrdCatalogo.Clear()
        vgrdCatalogo.DataSource = CargaDatosUsuarioMovil(CType(cmbCelulas.SelectedItem, Combo).IdCombo)
    End Sub

    Private Sub chkSoporteMovilanterior_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles chkSoporteMovilanterior.CheckedChanged
        CargaInformacion()
    End Sub
End Class
