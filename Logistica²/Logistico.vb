Imports System
Imports System.Data
Imports System.Data.SqlClient
Imports System.IO
Imports Logistica


Public Class frmLogistico
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
        If OperacionLogistica(5).Habilitada Then
            mniEliminar.Enabled = True
            mniEliminar.Visible = True
            btnEliminar.Visible = True
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
    Friend WithEvents mnuCatalogo As System.Windows.Forms.MainMenu
    Friend WithEvents mniAgregar As System.Windows.Forms.MenuItem
    Friend WithEvents mniCatalogo As System.Windows.Forms.MenuItem
    Friend WithEvents mniEliminar As System.Windows.Forms.MenuItem
    Friend WithEvents mniModificar As System.Windows.Forms.MenuItem
    Friend WithEvents imgHerramientas As System.Windows.Forms.ImageList
    Friend WithEvents btnAgregar As System.Windows.Forms.ToolBarButton
    Friend WithEvents btnEliminar As System.Windows.Forms.ToolBarButton
    Friend WithEvents btnModificar As System.Windows.Forms.ToolBarButton
    Friend WithEvents btnInactivar As System.Windows.Forms.ToolBarButton
    Friend WithEvents btnBuscar As System.Windows.Forms.ToolBarButton
    Friend WithEvents btnCerrar As System.Windows.Forms.ToolBarButton
    Friend WithEvents lblCelula As System.Windows.Forms.Label
    Friend WithEvents cboCelula As System.Windows.Forms.ComboBox
    Friend WithEvents mniCerrar As System.Windows.Forms.MenuItem
    Friend WithEvents mniBuscar As System.Windows.Forms.MenuItem
    Friend WithEvents Sep0 As System.Windows.Forms.ToolBarButton
    Friend WithEvents Sep1 As System.Windows.Forms.ToolBarButton
    Friend WithEvents Sep2 As System.Windows.Forms.ToolBarButton
    Friend WithEvents Sep3 As System.Windows.Forms.ToolBarButton
    Friend WithEvents Sep4 As System.Windows.Forms.ToolBarButton
    Friend WithEvents MSep0 As System.Windows.Forms.MenuItem
    Friend WithEvents MSep1 As System.Windows.Forms.MenuItem
    Friend WithEvents MSep2 As System.Windows.Forms.MenuItem
    Friend WithEvents vgrdCatalogo As Logistica.ViewGrid
    Friend WithEvents btnFiltro As System.Windows.Forms.ToolBarButton
    Friend WithEvents mnuFiltro As System.Windows.Forms.ContextMenu
    Friend WithEvents mniTodos As System.Windows.Forms.MenuItem
    Friend WithEvents mniActivos As System.Windows.Forms.MenuItem
    Friend WithEvents mniInactivos As System.Windows.Forms.MenuItem
    Friend WithEvents pnlTitulo As System.Windows.Forms.Panel
    Friend WithEvents rlblTitulo As Logistica.RotatableLabel
    Friend WithEvents tbLogistico As System.Windows.Forms.ToolBar
    Friend WithEvents mniLogistico As System.Windows.Forms.MenuItem
    Friend WithEvents mniActualizar As System.Windows.Forms.MenuItem
    Friend WithEvents btnActualizar As System.Windows.Forms.ToolBarButton
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(frmLogistico))
        Me.imgHerramientas = New System.Windows.Forms.ImageList(Me.components)
        Me.mnuCatalogo = New System.Windows.Forms.MainMenu()
        Me.mniCatalogo = New System.Windows.Forms.MenuItem()
        Me.mniLogistico = New System.Windows.Forms.MenuItem()
        Me.mniAgregar = New System.Windows.Forms.MenuItem()
        Me.mniModificar = New System.Windows.Forms.MenuItem()
        Me.mniEliminar = New System.Windows.Forms.MenuItem()
        Me.MSep0 = New System.Windows.Forms.MenuItem()
        Me.mniBuscar = New System.Windows.Forms.MenuItem()
        Me.MSep1 = New System.Windows.Forms.MenuItem()
        Me.mniActualizar = New System.Windows.Forms.MenuItem()
        Me.MSep2 = New System.Windows.Forms.MenuItem()
        Me.mniCerrar = New System.Windows.Forms.MenuItem()
        Me.tbLogistico = New System.Windows.Forms.ToolBar()
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
        Me.vgrdCatalogo = New Logistica.ViewGrid()
        Me.pnlTitulo = New System.Windows.Forms.Panel()
        Me.rlblTitulo = New Logistica.RotatableLabel()
        Me.pnlTitulo.SuspendLayout()
        Me.SuspendLayout()
        '
        'imgHerramientas
        '
        Me.imgHerramientas.ColorDepth = System.Windows.Forms.ColorDepth.Depth8Bit
        Me.imgHerramientas.ImageSize = New System.Drawing.Size(16, 16)
        Me.imgHerramientas.ImageStream = CType(resources.GetObject("imgHerramientas.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.imgHerramientas.TransparentColor = System.Drawing.Color.Transparent
        '
        'mnuCatalogo
        '
        Me.mnuCatalogo.MenuItems.AddRange(New System.Windows.Forms.MenuItem() {Me.mniCatalogo})
        '
        'mniCatalogo
        '
        Me.mniCatalogo.Index = 0
        Me.mniCatalogo.MenuItems.AddRange(New System.Windows.Forms.MenuItem() {Me.mniLogistico})
        Me.mniCatalogo.MergeOrder = 2
        Me.mniCatalogo.MergeType = System.Windows.Forms.MenuMerge.MergeItems
        Me.mniCatalogo.Text = "&Catálogos"
        '
        'mniLogistico
        '
        Me.mniLogistico.Index = 0
        Me.mniLogistico.MenuItems.AddRange(New System.Windows.Forms.MenuItem() {Me.mniAgregar, Me.mniModificar, Me.mniEliminar, Me.MSep0, Me.mniBuscar, Me.MSep1, Me.mniActualizar, Me.MSep2, Me.mniCerrar})
        Me.mniLogistico.MergeOrder = 2
        Me.mniLogistico.MergeType = System.Windows.Forms.MenuMerge.MergeItems
        Me.mniLogistico.Text = "&Logistico"
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
        'MSep0
        '
        Me.MSep0.Index = 3
        Me.MSep0.Text = "-"
        '
        'mniBuscar
        '
        Me.mniBuscar.Index = 4
        Me.mniBuscar.Shortcut = System.Windows.Forms.Shortcut.CtrlB
        Me.mniBuscar.Text = "&Buscar"
        '
        'MSep1
        '
        Me.MSep1.Index = 5
        Me.MSep1.Text = "-"
        '
        'mniActualizar
        '
        Me.mniActualizar.Index = 6
        Me.mniActualizar.Shortcut = System.Windows.Forms.Shortcut.F5
        Me.mniActualizar.Text = "&Actualizar"
        '
        'MSep2
        '
        Me.MSep2.Index = 7
        Me.MSep2.Text = "-"
        '
        'mniCerrar
        '
        Me.mniCerrar.Index = 8
        Me.mniCerrar.Text = "&Cerrar"
        '
        'tbLogistico
        '
        Me.tbLogistico.Appearance = System.Windows.Forms.ToolBarAppearance.Flat
        Me.tbLogistico.Buttons.AddRange(New System.Windows.Forms.ToolBarButton() {Me.Sep0, Me.btnAgregar, Me.btnEliminar, Me.btnModificar, Me.btnInactivar, Me.Sep1, Me.btnFiltro, Me.btnBuscar, Me.Sep2, Me.btnActualizar, Me.Sep3, Me.btnCerrar, Me.Sep4})
        Me.tbLogistico.DropDownArrows = True
        Me.tbLogistico.ImageList = Me.imgHerramientas
        Me.tbLogistico.Name = "tbLogistico"
        Me.tbLogistico.ShowToolTips = True
        Me.tbLogistico.Size = New System.Drawing.Size(676, 39)
        Me.tbLogistico.TabIndex = 3
        '
        'Sep0
        '
        Me.Sep0.Style = System.Windows.Forms.ToolBarButtonStyle.Separator
        '
        'btnAgregar
        '
        Me.btnAgregar.ImageIndex = 0
        Me.btnAgregar.Text = "Agregar"
        '
        'btnEliminar
        '
        Me.btnEliminar.ImageIndex = 1
        Me.btnEliminar.Text = "Eliminar"
        Me.btnEliminar.Visible = False
        '
        'btnModificar
        '
        Me.btnModificar.ImageIndex = 2
        Me.btnModificar.Text = "Modificar"
        '
        'btnInactivar
        '
        Me.btnInactivar.ImageIndex = 3
        Me.btnInactivar.Text = "Inactivar"
        '
        'Sep1
        '
        Me.Sep1.Style = System.Windows.Forms.ToolBarButtonStyle.Separator
        '
        'btnFiltro
        '
        Me.btnFiltro.DropDownMenu = Me.mnuFiltro
        Me.btnFiltro.ImageIndex = 7
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
        Me.btnBuscar.Text = "Buscar"
        '
        'Sep2
        '
        Me.Sep2.Style = System.Windows.Forms.ToolBarButtonStyle.Separator
        '
        'btnActualizar
        '
        Me.btnActualizar.ImageIndex = 5
        Me.btnActualizar.Text = "Actualizar"
        '
        'Sep3
        '
        Me.Sep3.Style = System.Windows.Forms.ToolBarButtonStyle.Separator
        '
        'btnCerrar
        '
        Me.btnCerrar.ImageIndex = 6
        Me.btnCerrar.Text = "Cerrar"
        '
        'Sep4
        '
        Me.Sep4.Style = System.Windows.Forms.ToolBarButtonStyle.Separator
        '
        'lblCelula
        '
        Me.lblCelula.AutoSize = True
        Me.lblCelula.ForeColor = System.Drawing.Color.Black
        Me.lblCelula.Location = New System.Drawing.Point(447, 12)
        Me.lblCelula.Name = "lblCelula"
        Me.lblCelula.Size = New System.Drawing.Size(38, 14)
        Me.lblCelula.TabIndex = 0
        Me.lblCelula.Text = "&Célula:"
        '
        'cboCelula
        '
        Me.cboCelula.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboCelula.Location = New System.Drawing.Point(488, 9)
        Me.cboCelula.Name = "cboCelula"
        Me.cboCelula.TabIndex = 1
        '
        'vgrdCatalogo
        '
        Me.vgrdCatalogo.AlternativeBackColor = System.Drawing.Color.Gainsboro
        Me.vgrdCatalogo.CheckCondition = Nothing
        Me.vgrdCatalogo.DataSource = Nothing
        Me.vgrdCatalogo.Dock = System.Windows.Forms.DockStyle.Fill
        Me.vgrdCatalogo.FullRowSelect = True
        Me.vgrdCatalogo.GridLines = True
        Me.vgrdCatalogo.HidedColumnNames = New String() {"Célula", "CCelula", "Celular"}
        Me.vgrdCatalogo.HideSelection = False
        Me.vgrdCatalogo.Location = New System.Drawing.Point(24, 39)
        Me.vgrdCatalogo.MultiSelect = False
        Me.vgrdCatalogo.Name = "vgrdCatalogo"
        Me.vgrdCatalogo.NullText = ""
        Me.vgrdCatalogo.PKColumnNames = New String() {"Empleado"}
        Me.vgrdCatalogo.Size = New System.Drawing.Size(652, 476)
        Me.vgrdCatalogo.TabIndex = 4
        Me.vgrdCatalogo.View = System.Windows.Forms.View.Details
        '
        'pnlTitulo
        '
        Me.pnlTitulo.Controls.AddRange(New System.Windows.Forms.Control() {Me.rlblTitulo})
        Me.pnlTitulo.Dock = System.Windows.Forms.DockStyle.Left
        Me.pnlTitulo.Location = New System.Drawing.Point(0, 39)
        Me.pnlTitulo.Name = "pnlTitulo"
        Me.pnlTitulo.Size = New System.Drawing.Size(24, 476)
        Me.pnlTitulo.TabIndex = 5
        '
        'rlblTitulo
        '
        Me.rlblTitulo.Border = False
        Me.rlblTitulo.Caption = "Logísticos de la célula x"
        Me.rlblTitulo.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.rlblTitulo.Font = New System.Drawing.Font("Tahoma", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rlblTitulo.ForeColor = System.Drawing.Color.DarkSlateBlue
        Me.rlblTitulo.Location = New System.Drawing.Point(0, 212)
        Me.rlblTitulo.Name = "rlblTitulo"
        Me.rlblTitulo.RotationAngle = 270
        Me.rlblTitulo.Size = New System.Drawing.Size(25, 264)
        Me.rlblTitulo.TabIndex = 6
        '
        'frmLogistico
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 14)
        Me.BackColor = System.Drawing.Color.Gainsboro
        Me.ClientSize = New System.Drawing.Size(676, 515)
        Me.Controls.AddRange(New System.Windows.Forms.Control() {Me.vgrdCatalogo, Me.pnlTitulo, Me.cboCelula, Me.lblCelula, Me.tbLogistico})
        Me.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Menu = Me.mnuCatalogo
        Me.Name = "frmLogistico"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Catálogo de logísticos"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.pnlTitulo.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

#End Region

#Region "Variables globales"
    Private dtLogistico As New DataTable()
    Private Filtro As String
#End Region

#Region "Rutinas de actualización"
    Private Sub CargaInformacion()
        If Not cboCelula.SelectedValue Is Nothing Then
            Dim cmdLogistica As New SqlCommand("Select * from vwLOGLogistico where CCelula = @Celula ", cnSigamet)
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
                dtLogistico.Clear()
                'Llenado de tabla
                daLogistica.Fill(dtLogistico)
            Catch ex As Exception
                ExMessage(ex)
            End Try
            'Llenado de grid
            vgrdCatalogo.DataSource = dtLogistico
            If dtLogistico.Rows.Count > 0 Then
                vgrdCatalogo.Items(0).Selected = True
            End If
            'Eliminación de objetos
            cmdLogistica.Dispose()
            daLogistica.Dispose()
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
    End Sub
    Private Sub cboCelula_SelectedValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboCelula.SelectedValueChanged
        If Not cboCelula.SelectedValue Is Nothing Then
            'Carga de información
            CargaInformacion()
            'Actualización de título
            If mniTodos.Checked Then
                rlblTitulo.Caption = "Logísticos de célula " & CStr(cboCelula.SelectedValue)
            ElseIf mniActivos.Checked Then
                rlblTitulo.Caption = "Logísticos activos de célula " & CStr(cboCelula.SelectedValue)
            Else
                rlblTitulo.Caption = "Logísticos inactivos de célula " & CStr(cboCelula.SelectedValue)
            End If
        End If
    End Sub
    Private Sub vgrdCatalogo_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles vgrdCatalogo.SelectedIndexChanged
        If Not vgrdCatalogo.CurrentRow Is Nothing AndAlso CStr(vgrdCatalogo.CurrentRow("Status")).Trim = "ACTIVO" Then
            btnInactivar.Enabled = True
        Else
            btnInactivar.Enabled = False
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
    End Sub
    Private Sub tbOperador_ButtonClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.ToolBarButtonClickEventArgs) Handles tbLogistico.ButtonClick
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
            Case "Cerrar"
                Me.Close()
                Me.Dispose()
        End Select
    End Sub
#End Region

#Region "Rutina de manejo de datos"
    Private Sub Agregar()
        'Creación y carga de formulario de captura
        Dim frmCapturaLogistico As New frmCapturaLogistico(CInt(cboCelula.SelectedValue))
        frmCapturaLogistico.ShowDialog()
        'Validación de resultados
        If frmCapturaLogistico.DialogResult = DialogResult.OK Then
            'Carga de información
            CargaInformacion()
            'Recuperación de posición en grid
            vgrdCatalogo.FindFirst("Empleado", frmCapturaLogistico.txtEmpleado.Text)
            vgrdCatalogo.Focus()
        End If
        'Eliminado de objetos
        frmCapturaLogistico.Dispose()
    End Sub
    Private Sub Eliminar()
        'Validación de selección en grid
        If Not vgrdCatalogo.CurrentRow Is Nothing Then
            'Confirmación de acción
            If MessageBox.Show("¿Desea eliminar al logístico " & CStr(vgrdCatalogo.CurrentRow("Empleado")) & " " _
                    & CStr(vgrdCatalogo.CurrentRow("Nombre")) & "?", Application.ProductName & "v." & Application.ProductVersion, _
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
            End If
        End If
    End Sub
    Private Sub Inactivar()
        'Validación de selección en grid
        If Not vgrdCatalogo.CurrentRow Is Nothing Then
            'Confirmación de acción
            If MessageBox.Show("¿Desea inactivar al logístico " & CStr(vgrdCatalogo.CurrentRow("Empleado")) & " " _
                  & CStr(vgrdCatalogo.CurrentRow("Nombre")) & "?", Application.ProductName & "v." & Application.ProductVersion, _
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
                'Recuperación de posición en grid
                vgrdCatalogo.FindFirst("Empleado", CStr(cmdLogistica.Parameters("@Operador").Value))
                vgrdCatalogo.Focus()
            End If
        End If
    End Sub
    Private Sub Modificar()
        'Validación de selección en grid
        If Not vgrdCatalogo.CurrentRow Is Nothing Then
            'Creación y carga de formulario
            Dim frmCapturaLogistico As New frmCapturaLogistico(CInt(cboCelula.SelectedValue), CInt(CType(vgrdCatalogo.CurrentPK, Object())(0)))
            frmCapturaLogistico.ShowDialog()
            'Validación de resultados
            If frmCapturaLogistico.DialogResult = DialogResult.OK Then
                'Carga de información
                CargaInformacion()
                'Recuperación de posición en grid
                vgrdCatalogo.FindFirst("Empleado", frmCapturaLogistico.txtEmpleado.Text)
                vgrdCatalogo.Focus()
            End If
            'Eliminación de objetos
            frmCapturaLogistico.Dispose()
        End If
    End Sub
    Private Sub Buscar()
        'Petición de busqueda
        Dim Operador As String = InputBox("No. de empleado:")
        'Validación de texto de busqueda
        If Trim(Operador) <> "" Then
            'Busqueda
            If vgrdCatalogo.FindFirst("Empleado", Trim(Operador)) < 0 Then
                MessageBox.Show("No se ha encontrado al logístico no. " & Trim(Operador), Application.ProductName & " v." & Application.ProductVersion, MessageBoxButtons.OK, MessageBoxIcon.Information)
            Else
                vgrdCatalogo.Focus()
            End If
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
        Me.BackColor = Color.FromArgb(CInt(Settings.GetSetting("frmLogistico", "BackColor")))
        vgrdCatalogo.BackColor = Color.FromArgb(CInt(Settings.GetSetting("frmLogistico", "CatalogoBackColor")))
        vgrdCatalogo.AlternativeBackColor = Color.FromArgb(CInt(Settings.GetSetting("frmLogistico", "CatalogoAltBackColor")))
        vgrdCatalogo.ForeColor = Color.FromArgb(CInt(Settings.GetSetting("frmLogistico", "CatalogoForeColor")))
    End Sub
    Protected Overrides Sub OnPaint(ByVal e As PaintEventArgs)
        CargaConfiguracion()
    End Sub
    Private Sub frmLogistico_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Activated
        CargaConfiguracion()
    End Sub
#End Region



   
End Class
