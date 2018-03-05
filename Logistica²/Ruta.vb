Imports System
Imports System.Data
Imports System.Data.SqlClient
Imports System.IO
Imports Logistica

Public Class frmRuta
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
        Dim KeyColumn(0) As DataColumn
        Dim row As DataRow

        cmdLogistica.Parameters.Add("@Usuario", SqlDbType.Char).Value = _Usuario
        Try
            daLogistica.Fill(dtCelula)

            cmdLogistica.CommandText = "Select ClaseRuta, Descripcion from ClaseRuta order by Descripcion"
            daLogistica.Fill(dtClaseRuta)
            KeyColumn(0) = dtClaseRuta.Columns("Descripcion")
            dtClaseRuta.PrimaryKey = KeyColumn
        Catch ex As Exception
            ExMessage(ex)
        End Try
        cmdLogistica.Dispose()
        daLogistica.Dispose()
        CargaInformacion()
        If OperacionLogistica(5).Habilitada Then
            mniEliminar.Enabled = True
            mniEliminar.Visible = True
            btnEliminar.Visible = True
        End If

        If OperacionLogistica(21).Habilitada Then
            btnComision.Visible = True
        Else
            Dim array(3) As String
            array(0) = "Comision"
            array(1) = "IDClase"
            array(2) = "IDCelula"
            vgrdCatalogo.HidedColumnNames = array

        End If

        For Each row In dtClaseRuta.Rows
            mnuFiltro.MenuItems.Add(CStr(row("Descripcion")), New EventHandler(AddressOf mniFiltro_Click))
        Next

        cboCelula.ValueMember = "Celula"
        cboCelula.DisplayMember = "Descripcion"
        cboCelula.DataSource = dtCelula
        cboCelula.SelectedValue = _Celula
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
    Friend WithEvents mniAgregar As System.Windows.Forms.MenuItem
    Friend WithEvents mniEliminar As System.Windows.Forms.MenuItem
    Friend WithEvents mniModificar As System.Windows.Forms.MenuItem
    Friend WithEvents mniBuscar As System.Windows.Forms.MenuItem
    Friend WithEvents mniCerrar As System.Windows.Forms.MenuItem
    Friend WithEvents mnuAutotanque As System.Windows.Forms.MainMenu
    Friend WithEvents cboCelula As System.Windows.Forms.ComboBox
    Friend WithEvents lblCelula As System.Windows.Forms.Label
    Friend WithEvents MSep0 As System.Windows.Forms.MenuItem
    Friend WithEvents MSep1 As System.Windows.Forms.MenuItem
    Friend WithEvents MSep2 As System.Windows.Forms.MenuItem
    Friend WithEvents vgrdCatalogo As Logistica.ViewGrid
    Friend WithEvents pnlTitulo As System.Windows.Forms.Panel
    Friend WithEvents rlblTitulo As Logistica.RotatableLabel
    Friend WithEvents tbOperador As System.Windows.Forms.ToolBar
    Friend WithEvents Sep0 As System.Windows.Forms.ToolBarButton
    Friend WithEvents btnAgregar As System.Windows.Forms.ToolBarButton
    Friend WithEvents btnEliminar As System.Windows.Forms.ToolBarButton
    Friend WithEvents btnModificar As System.Windows.Forms.ToolBarButton
    Friend WithEvents Sep1 As System.Windows.Forms.ToolBarButton
    Friend WithEvents mnuFiltro As System.Windows.Forms.ContextMenu
    Friend WithEvents btnBuscar As System.Windows.Forms.ToolBarButton
    Friend WithEvents Sep3 As System.Windows.Forms.ToolBarButton
    Friend WithEvents btnCerrar As System.Windows.Forms.ToolBarButton
    Friend WithEvents Sep4 As System.Windows.Forms.ToolBarButton
    Friend WithEvents imgHerramientas As System.Windows.Forms.ImageList
    Friend WithEvents btnFiltro As System.Windows.Forms.ToolBarButton
    Friend WithEvents Sep2 As System.Windows.Forms.ToolBarButton
    Friend WithEvents mniTodos As System.Windows.Forms.MenuItem
    Friend WithEvents mniRuta As System.Windows.Forms.MenuItem
    Friend WithEvents btnActualizar As System.Windows.Forms.ToolBarButton
    Friend WithEvents btnComisionRuta As System.Windows.Forms.ToolBarButton
    Friend WithEvents btnComision As System.Windows.Forms.ToolBarButton
    Friend WithEvents mniActualizar As System.Windows.Forms.MenuItem
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmRuta))
        Me.mnuAutotanque = New System.Windows.Forms.MainMenu(Me.components)
        Me.mnuCatalogo = New System.Windows.Forms.MenuItem()
        Me.mniRuta = New System.Windows.Forms.MenuItem()
        Me.mniAgregar = New System.Windows.Forms.MenuItem()
        Me.mniModificar = New System.Windows.Forms.MenuItem()
        Me.mniEliminar = New System.Windows.Forms.MenuItem()
        Me.MSep0 = New System.Windows.Forms.MenuItem()
        Me.mniBuscar = New System.Windows.Forms.MenuItem()
        Me.MSep1 = New System.Windows.Forms.MenuItem()
        Me.mniActualizar = New System.Windows.Forms.MenuItem()
        Me.MSep2 = New System.Windows.Forms.MenuItem()
        Me.mniCerrar = New System.Windows.Forms.MenuItem()
        Me.cboCelula = New System.Windows.Forms.ComboBox()
        Me.lblCelula = New System.Windows.Forms.Label()
        Me.pnlTitulo = New System.Windows.Forms.Panel()
        Me.rlblTitulo = New Logistica.RotatableLabel()
        Me.tbOperador = New System.Windows.Forms.ToolBar()
        Me.Sep0 = New System.Windows.Forms.ToolBarButton()
        Me.btnAgregar = New System.Windows.Forms.ToolBarButton()
        Me.btnEliminar = New System.Windows.Forms.ToolBarButton()
        Me.btnComision = New System.Windows.Forms.ToolBarButton()
        Me.btnModificar = New System.Windows.Forms.ToolBarButton()
        Me.Sep1 = New System.Windows.Forms.ToolBarButton()
        Me.btnFiltro = New System.Windows.Forms.ToolBarButton()
        Me.mnuFiltro = New System.Windows.Forms.ContextMenu()
        Me.mniTodos = New System.Windows.Forms.MenuItem()
        Me.btnBuscar = New System.Windows.Forms.ToolBarButton()
        Me.Sep2 = New System.Windows.Forms.ToolBarButton()
        Me.btnActualizar = New System.Windows.Forms.ToolBarButton()
        Me.Sep3 = New System.Windows.Forms.ToolBarButton()
        Me.btnCerrar = New System.Windows.Forms.ToolBarButton()
        Me.Sep4 = New System.Windows.Forms.ToolBarButton()
        Me.imgHerramientas = New System.Windows.Forms.ImageList(Me.components)
        Me.vgrdCatalogo = New Logistica.ViewGrid()
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
        Me.mnuCatalogo.MenuItems.AddRange(New System.Windows.Forms.MenuItem() {Me.mniRuta})
        Me.mnuCatalogo.MergeOrder = 2
        Me.mnuCatalogo.MergeType = System.Windows.Forms.MenuMerge.MergeItems
        Me.mnuCatalogo.Text = "&Catálogos"
        '
        'mniRuta
        '
        Me.mniRuta.Index = 0
        Me.mniRuta.MenuItems.AddRange(New System.Windows.Forms.MenuItem() {Me.mniAgregar, Me.mniModificar, Me.mniEliminar, Me.MSep0, Me.mniBuscar, Me.MSep1, Me.mniActualizar, Me.MSep2, Me.mniCerrar})
        Me.mniRuta.MergeOrder = 3
        Me.mniRuta.MergeType = System.Windows.Forms.MenuMerge.MergeItems
        Me.mniRuta.Text = "&Ruta"
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
        Me.mniActualizar.Text = "Ac&tualizar"
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
        'cboCelula
        '
        Me.cboCelula.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboCelula.Location = New System.Drawing.Point(508, 9)
        Me.cboCelula.Name = "cboCelula"
        Me.cboCelula.Size = New System.Drawing.Size(202, 21)
        Me.cboCelula.TabIndex = 5
        '
        'lblCelula
        '
        Me.lblCelula.AutoSize = True
        Me.lblCelula.ForeColor = System.Drawing.Color.Black
        Me.lblCelula.Location = New System.Drawing.Point(468, 12)
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
        Me.pnlTitulo.Size = New System.Drawing.Size(24, 506)
        Me.pnlTitulo.TabIndex = 7
        '
        'rlblTitulo
        '
        Me.rlblTitulo.Border = False
        Me.rlblTitulo.Caption = "Rutas de célula x"
        Me.rlblTitulo.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.rlblTitulo.Font = New System.Drawing.Font("Tahoma", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rlblTitulo.ForeColor = System.Drawing.Color.DarkSlateBlue
        Me.rlblTitulo.Location = New System.Drawing.Point(0, 307)
        Me.rlblTitulo.Name = "rlblTitulo"
        Me.rlblTitulo.RotationAngle = 270
        Me.rlblTitulo.Size = New System.Drawing.Size(25, 199)
        Me.rlblTitulo.TabIndex = 6
        '
        'tbOperador
        '
        Me.tbOperador.Appearance = System.Windows.Forms.ToolBarAppearance.Flat
        Me.tbOperador.Buttons.AddRange(New System.Windows.Forms.ToolBarButton() {Me.Sep0, Me.btnAgregar, Me.btnEliminar, Me.btnComision, Me.btnModificar, Me.Sep1, Me.btnFiltro, Me.btnBuscar, Me.Sep2, Me.btnActualizar, Me.Sep3, Me.btnCerrar, Me.Sep4})
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
        'btnComision
        '
        Me.btnComision.ImageIndex = 9
        Me.btnComision.Name = "btnComision"
        Me.btnComision.Text = "Comision"
        Me.btnComision.Visible = False
        '
        'btnModificar
        '
        Me.btnModificar.ImageIndex = 2
        Me.btnModificar.Name = "btnModificar"
        Me.btnModificar.Text = "Modificar"
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
        Me.mnuFiltro.MenuItems.AddRange(New System.Windows.Forms.MenuItem() {Me.mniTodos})
        '
        'mniTodos
        '
        Me.mniTodos.Checked = True
        Me.mniTodos.DefaultItem = True
        Me.mniTodos.Index = 0
        Me.mniTodos.RadioCheck = True
        Me.mniTodos.Text = "&Todos"
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
        Me.imgHerramientas.Images.SetKeyName(9, "Comision.png")
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
        Me.vgrdCatalogo.HidedColumnNames = New String() {"IDClase", "IDCelula"}
        Me.vgrdCatalogo.Location = New System.Drawing.Point(24, 50)
        Me.vgrdCatalogo.MultiSelect = False
        Me.vgrdCatalogo.Name = "vgrdCatalogo"
        Me.vgrdCatalogo.NullText = ""
        Me.vgrdCatalogo.PKColumnNames = New String(-1) {}
        Me.vgrdCatalogo.Size = New System.Drawing.Size(744, 506)
        Me.vgrdCatalogo.TabIndex = 6
        Me.vgrdCatalogo.UseCompatibleStateImageBehavior = False
        Me.vgrdCatalogo.View = System.Windows.Forms.View.Details
        '
        'frmRuta
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 14)
        Me.BackColor = System.Drawing.Color.OldLace
        Me.ClientSize = New System.Drawing.Size(768, 556)
        Me.Controls.Add(Me.vgrdCatalogo)
        Me.Controls.Add(Me.pnlTitulo)
        Me.Controls.Add(Me.cboCelula)
        Me.Controls.Add(Me.lblCelula)
        Me.Controls.Add(Me.tbOperador)
        Me.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ForeColor = System.Drawing.Color.Black
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Menu = Me.mnuAutotanque
        Me.Name = "frmRuta"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Catálogo de rutas"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.pnlTitulo.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

#End Region

#Region "Variables globales"
    Dim dtRuta As New DataTable()
    Dim Filtro As Integer
    Dim dtClaseRuta As New DataTable()
#End Region

#Region "Rutinas de actualización"
    Public Sub CargaInformacion()
        If Not cboCelula.SelectedValue Is Nothing Then
            Dim daLogistica As New SqlDataAdapter("Select * from vwLOGRuta Where IDCelula = @Celula", cnSigamet)
            vgrdCatalogo.DataSource = Nothing
            daLogistica.SelectCommand.Parameters.Add("@Celula", SqlDbType.TinyInt).Value = CInt(cboCelula.SelectedValue)
            If Filtro > 0 Then
                daLogistica.SelectCommand.CommandText &= " and IDClase = " & Filtro.ToString
            End If
            daLogistica.SelectCommand.CommandText &= " order by Ruta"
            Try
                dtRuta.Clear()
                daLogistica.Fill(dtRuta)
                vgrdCatalogo.DataSource = dtRuta
            Catch ex As Exception
                ExMessage(ex)
            End Try
        End If
    End Sub
    Private Sub mniFiltro_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mniTodos.Click
        Dim item As MenuItem
        For Each item In mnuFiltro.MenuItems
            item.Checked = False
        Next
        CType(sender, MenuItem).Checked = True
        If CType(sender, MenuItem).Text = "&Todos" Then
            Filtro = 0
            rlblTitulo.Caption = "Rutas de célula " & CStr(cboCelula.SelectedValue)
        Else
            Filtro = CInt(dtClaseRuta.Rows.Find(CType(sender, MenuItem).Text)("ClaseRuta"))
            rlblTitulo.Caption = "Rutas " & CType(sender, MenuItem).Text & " de célula " & CStr(cboCelula.SelectedValue)
        End If
        CargaInformacion()
    End Sub
    Private Sub cboCelula_SelectedValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboCelula.SelectedValueChanged
        Dim item As MenuItem
        If Not cboCelula.SelectedValue Is Nothing Then
            CargaInformacion()
            If mniTodos.Checked Then
                rlblTitulo.Caption = "Rutas de célula " & CStr(cboCelula.SelectedValue)
            Else
                For Each item In mnuFiltro.MenuItems
                    If item.Checked Then
                        rlblTitulo.Caption = "Rutas " & item.Text & " de célula " & CStr(cboCelula.SelectedValue)
                        Exit For
                    End If
                Next
            End If
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
    Private Sub tbOperador_ButtonClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.ToolBarButtonClickEventArgs) Handles tbOperador.ButtonClick
        Select Case e.Button.Text
            Case "Comision"
                Comision()
            Case "Agregar"
                Agregar()
            Case "Eliminar"
                Eliminar()
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
    Private Sub Comision()
        If Not vgrdCatalogo.CurrentRow Is Nothing Then
            Dim frmNuevoRuta As New frmNuevoRuta(CInt(vgrdCatalogo.CurrentRow("Ruta")), cnSigamet)
            frmNuevoRuta.ShowDialog()
        Else
            MessageBox.Show("Seleccione un elemento de la lista", "Mensaje del sistema.", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End If

    End Sub
    Private Sub Agregar()
        'Creación y carga de formulario de captura
        Dim frmCapturaRuta As New frmCapturaRuta(CInt(cboCelula.SelectedValue))
        frmCapturaRuta.ShowDialog()
        'Validación de resultados
        If frmCapturaRuta.DialogResult = DialogResult.OK Then
            'Carga de información
            CargaInformacion()
            'Recuperación de posición en grid
            vgrdCatalogo.FindFirst("Ruta", frmCapturaRuta.txtRuta.Text)
            vgrdCatalogo.Focus()
        End If
        'Eliminado de objetos
        frmCapturaRuta.Dispose()
    End Sub
    Private Sub Eliminar()
        'Validación de privilegios
        If OperacionLogistica(3).Habilitada Then
            'Validación de selección en grid
            If Not vgrdCatalogo.CurrentRow Is Nothing Then
                'Confirmación de acción
                If MessageBox.Show("¿Desea eliminar la ruta " & CStr(vgrdCatalogo.CurrentRow("Ruta")) & "?", _
                        Application.ProductName & "v." & Application.ProductVersion, MessageBoxButtons.YesNo, MessageBoxIcon.Question, _
                        MessageBoxDefaultButton.Button2) = DialogResult.Yes Then
                    Dim cmdLogistica As New SqlCommand("Delete from Ruta where Ruta = @Ruta", cnSigamet)
                    Me.Cursor = Cursors.WaitCursor
                    'Carga de parametros
                    cmdLogistica.Parameters.Add("@Ruta", SqlDbType.Int).Value = CInt(vgrdCatalogo.CurrentRow("Ruta"))
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
        Else
            ErrMessage("No tiene privilegios para realizar esta operación.")
        End If
    End Sub

    Private Sub Modificar()
        'Validación de selección en grid
        If Not vgrdCatalogo.CurrentRow Is Nothing Then
            'Creación y carga de formulario
            Dim frmCapturaRuta As New frmCapturaRuta(CInt(cboCelula.SelectedValue), CInt(vgrdCatalogo.CurrentRow("Ruta")), CInt(vgrdCatalogo.CurrentRow("IDClase")), CStr(vgrdCatalogo.CurrentRow("UsuarioMovil")), CStr(vgrdCatalogo.CurrentRow("Descripcion")))
            frmCapturaRuta.ShowDialog()
            'Validación de resultados
            If frmCapturaRuta.DialogResult = DialogResult.OK Then
                'Carga de información
                CargaInformacion()
                'Recuperación de posición en grid
                vgrdCatalogo.FindFirst("Ruta", frmCapturaRuta.txtRuta.Text)
                vgrdCatalogo.Focus()
            End If
            'Eliminación de objetos
            frmCapturaRuta.Dispose()
        End If
    End Sub
    Private Sub Buscar()
        'Petición de busqueda
        Dim Operador As String = InputBox("Ruta:")
        'Validación de texto de busqueda
        If Trim(Operador) <> "" Then
            'Busqueda
            If vgrdCatalogo.FindFirst("Ruta", Trim(Operador)) < 0 Then
                MessageBox.Show("No se ha encontrado la ruta " & Trim(Operador), Application.ProductName & " v." & Application.ProductVersion, MessageBoxButtons.OK, MessageBoxIcon.Information)
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
        Me.BackColor = Color.FromArgb(CInt(Settings.GetSetting("frmRuta", "BackColor")))
        vgrdCatalogo.BackColor = Color.FromArgb(CInt(Settings.GetSetting("frmRuta", "CatalogoBackColor")))
        vgrdCatalogo.AlternativeBackColor = Color.FromArgb(CInt(Settings.GetSetting("frmRuta", "CatalogoAltBackColor")))
        vgrdCatalogo.ForeColor = Color.FromArgb(CInt(Settings.GetSetting("frmRuta", "CatalogoForeColor")))
    End Sub
    Private Sub frmOperador_Paint(ByVal sender As Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles MyBase.Paint
        CargaConfiguracion()
    End Sub
    Private Sub frmAutotanque_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Activated
        CargaConfiguracion()
    End Sub
#End Region

End Class
