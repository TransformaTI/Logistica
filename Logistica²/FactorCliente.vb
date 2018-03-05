Imports System.Data.SqlClient
Public Class frmFactorCliente
    Inherits System.Windows.Forms.Form

#Region " Windows Form Designer generated code "

    Public Sub New()
        MyBase.New()

        'This call is required by the Windows Form Designer.
        InitializeComponent()

        'Add any initialization after the InitializeComponent() call

        CargaFactorClientePrincipal()

        Dim cmdCelula As New SqlCommand("Select C.Celula as Celula, ltrim(rtrim(C.Descripcion)) as Descripcion From Celula C Where C.Celula = 0 Union " _
                    & "Select C.Celula as Celula, ltrim(rtrim(C.Descripcion)) as Descripcion from Celula C inner join UsuarioCelula UC " _
                      & " on C.Celula = UC.Celula and UC.Usuario = @Usuario and C.Comercial = 1", cnSigamet)
        Dim daCelula As New SqlDataAdapter(cmdCelula)
        Dim dtCelula As New DataTable()
        cmdCelula.Parameters.Add("@Usuario", SqlDbType.Char).Value = _Usuario
        Try            
            daCelula.Fill(dtCelula)
        Catch ex As Exception
            ExMessage(ex)
        End Try

        cboCelula.ValueMember = "Celula"
        cboCelula.DisplayMember = "Descripcion"
        cboCelula.DataSource = dtCelula        
        cboCelula.SelectedValue = 0
        cmdCelula.Dispose()
        daCelula.Dispose()

        If OperacionLogistica(19).Habilitada Then
            btnAgregar.Enabled = True
            btnModificar.Enabled = True
            btnInactivar.Enabled = True
            mniAgregar.Enabled = True
            mniModificar.Enabled = True
            mniInactivar.Enabled = True
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
    Friend WithEvents tabDetalles As System.Windows.Forms.TabControl
    Friend WithEvents tabHistorico As System.Windows.Forms.TabPage
    Friend WithEvents sptDescuentos As System.Windows.Forms.Splitter
    Friend WithEvents tbFactor As System.Windows.Forms.ToolBar
    Friend WithEvents btnBuscar As System.Windows.Forms.ToolBarButton
    Friend WithEvents Sep1 As System.Windows.Forms.ToolBarButton
    Friend WithEvents btnActualizar As System.Windows.Forms.ToolBarButton
    Friend WithEvents Sep2 As System.Windows.Forms.ToolBarButton
    Friend WithEvents btnCerrar As System.Windows.Forms.ToolBarButton
    Friend WithEvents lblTituloH As System.Windows.Forms.Label
    Friend WithEvents vgFactorCliente As Logistica.ViewGrid
    Friend WithEvents vgFactorClienteHistorico As Logistica.ViewGrid
    Friend WithEvents btnAgregar As System.Windows.Forms.ToolBarButton
    Friend WithEvents btnModificar As System.Windows.Forms.ToolBarButton    
    Friend WithEvents Sep0 As System.Windows.Forms.ToolBarButton
    Friend WithEvents btn1 As System.Windows.Forms.ToolBarButton
    Friend WithEvents rlblTituloFC As Logistica.RotatableLabel
    Friend WithEvents pnlTituloD As System.Windows.Forms.Panel
    Friend WithEvents cboCelula As System.Windows.Forms.ComboBox
    Friend WithEvents lblCelula As System.Windows.Forms.Label
    Friend WithEvents cboRuta As System.Windows.Forms.ComboBox
    Friend WithEvents imgFactor As System.Windows.Forms.ImageList
    Friend WithEvents mniAgregar As System.Windows.Forms.MenuItem
    Friend WithEvents mniModificar As System.Windows.Forms.MenuItem
    Friend WithEvents mniInactivar As System.Windows.Forms.MenuItem
    Friend WithEvents Sepm2 As System.Windows.Forms.MenuItem
    Friend WithEvents mniBuscar As System.Windows.Forms.MenuItem
    Friend WithEvents Sepm0 As System.Windows.Forms.MenuItem
    Friend WithEvents mniActualizar As System.Windows.Forms.MenuItem
    Friend WithEvents Sepm1 As System.Windows.Forms.MenuItem
    Friend WithEvents mniCerrar As System.Windows.Forms.MenuItem
    Friend WithEvents mniCatFactorCliente As System.Windows.Forms.MenuItem
    Friend WithEvents mniFactorCliente As System.Windows.Forms.MenuItem
    Friend WithEvents mnuFactorCliente As System.Windows.Forms.MainMenu        
    Friend WithEvents btnInactivar As System.Windows.Forms.ToolBarButton
    Friend WithEvents lblRuta As System.Windows.Forms.Label
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmFactorCliente))
        Me.tabDetalles = New System.Windows.Forms.TabControl()
        Me.tabHistorico = New System.Windows.Forms.TabPage()
        Me.vgFactorClienteHistorico = New Logistica.ViewGrid()
        Me.lblTituloH = New System.Windows.Forms.Label()
        Me.sptDescuentos = New System.Windows.Forms.Splitter()
        Me.tbFactor = New System.Windows.Forms.ToolBar()
        Me.btnAgregar = New System.Windows.Forms.ToolBarButton()
        Me.btnModificar = New System.Windows.Forms.ToolBarButton()
        Me.btnInactivar = New System.Windows.Forms.ToolBarButton()
        Me.Sep0 = New System.Windows.Forms.ToolBarButton()
        Me.btnBuscar = New System.Windows.Forms.ToolBarButton()
        Me.Sep1 = New System.Windows.Forms.ToolBarButton()
        Me.btnActualizar = New System.Windows.Forms.ToolBarButton()
        Me.Sep2 = New System.Windows.Forms.ToolBarButton()
        Me.btnCerrar = New System.Windows.Forms.ToolBarButton()
        Me.imgFactor = New System.Windows.Forms.ImageList(Me.components)
        Me.vgFactorCliente = New Logistica.ViewGrid()
        Me.rlblTituloFC = New Logistica.RotatableLabel()
        Me.pnlTituloD = New System.Windows.Forms.Panel()
        Me.cboCelula = New System.Windows.Forms.ComboBox()
        Me.lblCelula = New System.Windows.Forms.Label()
        Me.cboRuta = New System.Windows.Forms.ComboBox()
        Me.lblRuta = New System.Windows.Forms.Label()
        Me.mniAgregar = New System.Windows.Forms.MenuItem()
        Me.mniModificar = New System.Windows.Forms.MenuItem()
        Me.mniInactivar = New System.Windows.Forms.MenuItem()
        Me.Sepm2 = New System.Windows.Forms.MenuItem()
        Me.mniBuscar = New System.Windows.Forms.MenuItem()
        Me.Sepm0 = New System.Windows.Forms.MenuItem()
        Me.mniActualizar = New System.Windows.Forms.MenuItem()
        Me.Sepm1 = New System.Windows.Forms.MenuItem()
        Me.mniCerrar = New System.Windows.Forms.MenuItem()
        Me.mniCatFactorCliente = New System.Windows.Forms.MenuItem()
        Me.mniFactorCliente = New System.Windows.Forms.MenuItem()
        Me.mnuFactorCliente = New System.Windows.Forms.MainMenu(Me.components)
        Me.tabDetalles.SuspendLayout()
        Me.tabHistorico.SuspendLayout()
        Me.pnlTituloD.SuspendLayout()
        Me.SuspendLayout()
        '
        'tabDetalles
        '
        Me.tabDetalles.Appearance = System.Windows.Forms.TabAppearance.FlatButtons
        Me.tabDetalles.Controls.Add(Me.tabHistorico)
        Me.tabDetalles.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.tabDetalles.Location = New System.Drawing.Point(0, 400)
        Me.tabDetalles.Name = "tabDetalles"
        Me.tabDetalles.SelectedIndex = 0
        Me.tabDetalles.ShowToolTips = True
        Me.tabDetalles.Size = New System.Drawing.Size(816, 152)
        Me.tabDetalles.TabIndex = 0
        '
        'tabHistorico
        '
        Me.tabHistorico.BackColor = System.Drawing.Color.Gainsboro
        Me.tabHistorico.Controls.Add(Me.vgFactorClienteHistorico)
        Me.tabHistorico.Controls.Add(Me.lblTituloH)
        Me.tabHistorico.ImageIndex = 2
        Me.tabHistorico.Location = New System.Drawing.Point(4, 25)
        Me.tabHistorico.Name = "tabHistorico"
        Me.tabHistorico.Size = New System.Drawing.Size(808, 123)
        Me.tabHistorico.TabIndex = 2
        Me.tabHistorico.Text = "Histórico"
        Me.tabHistorico.ToolTipText = "Histórico de descuentos"
        '
        'vgFactorClienteHistorico
        '
        Me.vgFactorClienteHistorico.AlternativeBackColor = System.Drawing.Color.Gainsboro        
        Me.vgFactorClienteHistorico.CheckCondition = Nothing
        Me.vgFactorClienteHistorico.DataSource = Nothing
        Me.vgFactorClienteHistorico.Dock = System.Windows.Forms.DockStyle.Fill
        Me.vgFactorClienteHistorico.FullRowSelect = True
        Me.vgFactorClienteHistorico.GridLines = True
        Me.vgFactorClienteHistorico.HidedColumnNames = New String() {"Consecutivo", "UsuarioSolicito", "StatusCliente", "StatusFactor"}
        Me.vgFactorClienteHistorico.Location = New System.Drawing.Point(0, 23)
        Me.vgFactorClienteHistorico.MultiSelect = False
        Me.vgFactorClienteHistorico.Name = "vgFactorClienteHistorico"
        Me.vgFactorClienteHistorico.PKColumnNames = Nothing
        Me.vgFactorClienteHistorico.Size = New System.Drawing.Size(808, 100)
        Me.vgFactorClienteHistorico.TabIndex = 2
        Me.vgFactorClienteHistorico.UseCompatibleStateImageBehavior = False
        Me.vgFactorClienteHistorico.View = System.Windows.Forms.View.Details
        '
        'lblTituloH
        '
        Me.lblTituloH.Dock = System.Windows.Forms.DockStyle.Top
        Me.lblTituloH.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTituloH.Location = New System.Drawing.Point(0, 0)
        Me.lblTituloH.Name = "lblTituloH"
        Me.lblTituloH.Size = New System.Drawing.Size(808, 23)
        Me.lblTituloH.TabIndex = 1
        Me.lblTituloH.Text = "Historico de cambios"
        Me.lblTituloH.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'sptDescuentos
        '
        Me.sptDescuentos.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.sptDescuentos.Location = New System.Drawing.Point(0, 397)
        Me.sptDescuentos.Name = "sptDescuentos"
        Me.sptDescuentos.Size = New System.Drawing.Size(816, 3)
        Me.sptDescuentos.TabIndex = 1
        Me.sptDescuentos.TabStop = False
        '
        'tbFactor
        '
        Me.tbFactor.Appearance = System.Windows.Forms.ToolBarAppearance.Flat
        Me.tbFactor.Buttons.AddRange(New System.Windows.Forms.ToolBarButton() {Me.btnAgregar, Me.btnModificar, Me.btnInactivar, Me.Sep0, Me.btnBuscar, Me.Sep1, Me.btnActualizar, Me.Sep2, Me.btnCerrar})
        Me.tbFactor.DropDownArrows = True
        Me.tbFactor.ImageList = Me.imgFactor
        Me.tbFactor.Location = New System.Drawing.Point(0, 0)
        Me.tbFactor.Name = "tbFactor"
        Me.tbFactor.ShowToolTips = True
        Me.tbFactor.Size = New System.Drawing.Size(816, 42)
        Me.tbFactor.TabIndex = 4
        '
        'btnAgregar
        '
        Me.btnAgregar.Enabled = False
        Me.btnAgregar.ImageIndex = 3
        Me.btnAgregar.Name = "btnAgregar"
        Me.btnAgregar.Text = "Agregar"
        Me.btnAgregar.ToolTipText = "Nuevo Factor Cliente"
        '
        'btnModificar
        '
        Me.btnModificar.Enabled = False
        Me.btnModificar.ImageIndex = 4
        Me.btnModificar.Name = "btnModificar"
        Me.btnModificar.Text = "Modificar"
        Me.btnModificar.ToolTipText = "Editar Factor Cliente"
        '
        'btnInactivar
        '
        Me.btnInactivar.Enabled = False
        Me.btnInactivar.ImageIndex = 6
        Me.btnInactivar.Name = "btnInactivar"
        Me.btnInactivar.Text = "Inactivar"
        Me.btnInactivar.ToolTipText = "Inactivar Factor Cliente"
        '
        'Sep0
        '
        Me.Sep0.Name = "Sep0"
        Me.Sep0.Style = System.Windows.Forms.ToolBarButtonStyle.Separator
        '
        'btnBuscar
        '
        Me.btnBuscar.ImageIndex = 8
        Me.btnBuscar.Name = "btnBuscar"
        Me.btnBuscar.Text = "Buscar"
        Me.btnBuscar.ToolTipText = "Buscar cliente"
        '
        'Sep1
        '
        Me.Sep1.Name = "Sep1"
        Me.Sep1.Style = System.Windows.Forms.ToolBarButtonStyle.Separator
        '
        'btnActualizar
        '
        Me.btnActualizar.ImageIndex = 9
        Me.btnActualizar.Name = "btnActualizar"
        Me.btnActualizar.Text = "Actualizar"
        Me.btnActualizar.ToolTipText = "Cargar la información más reciente"
        '
        'Sep2
        '
        Me.Sep2.Name = "Sep2"
        Me.Sep2.Style = System.Windows.Forms.ToolBarButtonStyle.Separator
        '
        'btnCerrar
        '
        Me.btnCerrar.ImageIndex = 10
        Me.btnCerrar.Name = "btnCerrar"
        Me.btnCerrar.Text = "Cerrar"
        Me.btnCerrar.ToolTipText = "Cerrar la pantalla de factor cliente"
        '
        'imgFactor
        '
        Me.imgFactor.ImageStream = CType(resources.GetObject("imgFactor.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.imgFactor.TransparentColor = System.Drawing.Color.Transparent
        Me.imgFactor.Images.SetKeyName(0, "")
        Me.imgFactor.Images.SetKeyName(1, "")
        Me.imgFactor.Images.SetKeyName(2, "")
        Me.imgFactor.Images.SetKeyName(3, "")
        Me.imgFactor.Images.SetKeyName(4, "")
        Me.imgFactor.Images.SetKeyName(5, "")
        Me.imgFactor.Images.SetKeyName(6, "")
        Me.imgFactor.Images.SetKeyName(7, "")
        Me.imgFactor.Images.SetKeyName(8, "")
        Me.imgFactor.Images.SetKeyName(9, "")
        Me.imgFactor.Images.SetKeyName(10, "")
        '
        'vgFactorCliente
        '
        Me.vgFactorCliente.AlternativeBackColor = System.Drawing.Color.Gainsboro        
        Me.vgFactorCliente.CheckCondition = Nothing
        Me.vgFactorCliente.DataSource = Nothing
        Me.vgFactorCliente.Dock = System.Windows.Forms.DockStyle.Fill
        Me.vgFactorCliente.FullRowSelect = True
        Me.vgFactorCliente.GridLines = True
        Me.vgFactorCliente.HidedColumnNames = New String() {"Consecutivo", "UsuarioSolicito", "UsuarioModificó", "FModificación", "StatusFactor"}
        Me.vgFactorCliente.HideSelection = False
        Me.vgFactorCliente.Location = New System.Drawing.Point(24, 42)
        Me.vgFactorCliente.MultiSelect = False
        Me.vgFactorCliente.Name = "vgFactorCliente"
        Me.vgFactorCliente.NullText = ""
        Me.vgFactorCliente.PKColumnNames = Nothing
        Me.vgFactorCliente.Size = New System.Drawing.Size(792, 355)
        Me.vgFactorCliente.TabIndex = 6
        Me.vgFactorCliente.UseCompatibleStateImageBehavior = False
        Me.vgFactorCliente.View = System.Windows.Forms.View.Details
        '
        'rlblTituloFC
        '
        Me.rlblTituloFC.Border = False
        Me.rlblTituloFC.Caption = "Factor cliente"
        Me.rlblTituloFC.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.rlblTituloFC.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rlblTituloFC.ForeColor = System.Drawing.Color.MidnightBlue
        Me.rlblTituloFC.Location = New System.Drawing.Point(0, 216)
        Me.rlblTituloFC.Name = "rlblTituloFC"
        Me.rlblTituloFC.RotationAngle = 270
        Me.rlblTituloFC.Size = New System.Drawing.Size(21, 139)
        Me.rlblTituloFC.TabIndex = 0
        '
        'pnlTituloD
        '
        Me.pnlTituloD.Controls.Add(Me.rlblTituloFC)
        Me.pnlTituloD.Dock = System.Windows.Forms.DockStyle.Left
        Me.pnlTituloD.Location = New System.Drawing.Point(0, 42)
        Me.pnlTituloD.Name = "pnlTituloD"
        Me.pnlTituloD.Size = New System.Drawing.Size(24, 355)
        Me.pnlTituloD.TabIndex = 5
        '
        'cboCelula
        '
        Me.cboCelula.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboCelula.Location = New System.Drawing.Point(444, 12)
        Me.cboCelula.Name = "cboCelula"
        Me.cboCelula.Size = New System.Drawing.Size(121, 21)
        Me.cboCelula.TabIndex = 8
        '
        'lblCelula
        '
        Me.lblCelula.AutoSize = True
        Me.lblCelula.ForeColor = System.Drawing.Color.Black
        Me.lblCelula.Location = New System.Drawing.Point(404, 12)
        Me.lblCelula.Name = "lblCelula"
        Me.lblCelula.Size = New System.Drawing.Size(40, 13)
        Me.lblCelula.TabIndex = 7
        Me.lblCelula.Text = "&Célula:"
        '
        'cboRuta
        '
        Me.cboRuta.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboRuta.Location = New System.Drawing.Point(611, 12)
        Me.cboRuta.Name = "cboRuta"
        Me.cboRuta.Size = New System.Drawing.Size(121, 21)
        Me.cboRuta.TabIndex = 10
        '
        'lblRuta
        '
        Me.lblRuta.AutoSize = True
        Me.lblRuta.ForeColor = System.Drawing.Color.Black
        Me.lblRuta.Location = New System.Drawing.Point(571, 12)
        Me.lblRuta.Name = "lblRuta"
        Me.lblRuta.Size = New System.Drawing.Size(34, 13)
        Me.lblRuta.TabIndex = 9
        Me.lblRuta.Text = "&Ruta:"
        '
        'mniAgregar
        '
        Me.mniAgregar.Enabled = False
        Me.mniAgregar.Index = 0
        Me.mniAgregar.Shortcut = System.Windows.Forms.Shortcut.Ins
        Me.mniAgregar.Text = "&Agregar"
        '
        'mniModificar
        '
        Me.mniModificar.Enabled = False
        Me.mniModificar.Index = 1
        Me.mniModificar.Shortcut = System.Windows.Forms.Shortcut.CtrlIns
        Me.mniModificar.Text = "&Modificar"
        '
        'mniInactivar
        '
        Me.mniInactivar.Enabled = False
        Me.mniInactivar.Index = 2
        Me.mniInactivar.Shortcut = System.Windows.Forms.Shortcut.CtrlI
        Me.mniInactivar.Text = "&Inactivar"
        '
        'Sepm2
        '
        Me.Sepm2.Index = 3
        Me.Sepm2.Text = "-"
        '
        'mniBuscar
        '
        Me.mniBuscar.Index = 4
        Me.mniBuscar.Shortcut = System.Windows.Forms.Shortcut.CtrlB
        Me.mniBuscar.Text = "&Buscar"
        '
        'Sepm0
        '
        Me.Sepm0.Index = 5
        Me.Sepm0.Text = "-"
        '
        'mniActualizar
        '
        Me.mniActualizar.Index = 6
        Me.mniActualizar.Shortcut = System.Windows.Forms.Shortcut.F5
        Me.mniActualizar.Text = "&Actualizar"
        '
        'Sepm1
        '
        Me.Sepm1.Index = 7
        Me.Sepm1.Text = "-"
        '
        'mniCerrar
        '
        Me.mniCerrar.Index = 8
        Me.mniCerrar.Text = "Cerrar"
        '
        'mniCatFactorCliente
        '
        Me.mniCatFactorCliente.Index = 0
        Me.mniCatFactorCliente.MenuItems.AddRange(New System.Windows.Forms.MenuItem() {Me.mniAgregar, Me.mniModificar, Me.mniInactivar, Me.Sepm2, Me.mniBuscar, Me.Sepm0, Me.mniActualizar, Me.Sepm1, Me.mniCerrar})
        Me.mniCatFactorCliente.MergeType = System.Windows.Forms.MenuMerge.MergeItems
        Me.mniCatFactorCliente.Text = "&Factor"
        '
        'mniFactorCliente
        '
        Me.mniFactorCliente.Index = 0
        Me.mniFactorCliente.MenuItems.AddRange(New System.Windows.Forms.MenuItem() {Me.mniCatFactorCliente})
        Me.mniFactorCliente.MergeType = System.Windows.Forms.MenuMerge.MergeItems
        Me.mniFactorCliente.Text = "&Factor"
        '
        'mnuFactorCliente
        '
        Me.mnuFactorCliente.MenuItems.AddRange(New System.Windows.Forms.MenuItem() {Me.mniFactorCliente})
        '
        'frmFactorCliente
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 14)
        Me.BackColor = System.Drawing.Color.LightSteelBlue
        Me.ClientSize = New System.Drawing.Size(816, 552)
        Me.Controls.Add(Me.cboRuta)
        Me.Controls.Add(Me.lblRuta)
        Me.Controls.Add(Me.cboCelula)
        Me.Controls.Add(Me.lblCelula)
        Me.Controls.Add(Me.vgFactorCliente)
        Me.Controls.Add(Me.pnlTituloD)
        Me.Controls.Add(Me.tbFactor)
        Me.Controls.Add(Me.sptDescuentos)
        Me.Controls.Add(Me.tabDetalles)
        Me.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ForeColor = System.Drawing.Color.Black
        Me.Menu = Me.mnuFactorCliente
        Me.Name = "frmFactorCliente"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Factor"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.tabDetalles.ResumeLayout(False)
        Me.tabHistorico.ResumeLayout(False)
        Me.pnlTituloD.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

#End Region

#Region "Variables globales"
    Private dtFactorCliente As New DataTable()
#End Region


#Region "Rutinas de actualización"


#End Region

#Region "Manejo del grid principal"

#End Region
#Region "Menus y barras de herramientas"
    Private Sub tbFactor_ButtonClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.ToolBarButtonClickEventArgs) Handles tbFactor.ButtonClick
        Select Case e.Button.Text
            Case "Agregar"
                AgregarFactorCliente()
            Case "Modificar"
                ModificarFactorCliente()
            Case "Inactivar"
                InactivaFactorClienteCalibracion()
            Case "Buscar"
                Buscar()
            Case "Actualizar"
                Actualizar()
            Case "Cerrar"
                Me.Close()
                Me.Dispose()
        End Select
    End Sub

    Private Sub mniCerrar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mniCerrar.Click
        Me.Close()
        Me.Dispose()
    End Sub
#End Region
   
#Region "Personalización"    
#End Region

    Private Sub vgFactorCliente_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles vgFactorCliente.SelectedIndexChanged                        
        CargaHistoricoFactorCliente()        
    End Sub

    Private Sub frmFactorCliente_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load        
        CargarFactorCliente(CInt(cboCelula.SelectedValue), CInt(cboRuta.SelectedValue))
    End Sub

    Private Sub cboCelula_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles cboCelula.SelectedIndexChanged        
        If Not cboCelula.SelectedValue Is Nothing Then
            If cboCelula.SelectedValue.ToString() <> "0" Then
                CargaCboRutas(CInt(cboCelula.SelectedValue))
            Else
                cboRuta.DataSource = Nothing
                'cboRuta.Items.Clear()
                CargarFactorCliente(CInt(cboCelula.SelectedValue), 0)
            End If
        End If
    End Sub
    Private Sub CargaCboRutas(ByVal Celula As Integer)
        Dim cmdRuta As New SqlCommand("Select Ruta, ltrim(rtrim(Descripcion)) as Descripcion from Ruta " _
                      & " Where Status = 'ACTIVA' and Celula = @Celula", cnSigamet)
        Dim daRuta As New SqlDataAdapter(cmdRuta)
        Dim dtRuta As New DataTable()
        cmdRuta.Parameters.Add("@Celula", SqlDbType.Char).Value = Celula
        Try
            daRuta.Fill(dtRuta)
        Catch ex As Exception
            ExMessage(ex)
        End Try
        cboRuta.ValueMember = "Ruta"
        cboRuta.DisplayMember = "Descripcion"
        cboRuta.DataSource = dtRuta        
        cmdRuta.Dispose()
        daRuta.Dispose()
    End Sub

    Private Sub cboRuta_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles cboRuta.SelectedIndexChanged               
        If Not cboRuta.SelectedValue Is Nothing Then
            CargarFactorCliente(CInt(cboCelula.SelectedValue), CInt(cboRuta.SelectedValue))
        End If
    End Sub
#Region "CargaInfoGrids"
    Public Sub CargaHistoricoFactorCliente()

        If Not vgFactorCliente.CurrentRow Is Nothing Then
            Dim FoundRow As DataRow = vgFactorCliente.CurrentRow
            If Not FoundRow Is Nothing Then
                Dim dtFactorClienteHistorico As New DataTable()
                Dim Rows As DataRow()
                Dim Objetos(14) As Object
                Dim filtro As String = "Consecutivo <> 0 and cliente = " & CStr(FoundRow("Cliente"))
                dtFactorClienteHistorico = dtFactorCliente.Clone
                dtFactorClienteHistorico.Clear()


                Rows = dtFactorCliente.Select(filtro, "Consecutivo")
                For Each dr2 As DataRow In Rows
                    Objetos(0) = dr2.Item("Cliente")
                    Objetos(1) = dr2.Item("Nombre")
                    Objetos(2) = dr2.Item("DirecciónCompleta")
                    Objetos(3) = dr2.Item("Célula")
                    Objetos(4) = dr2.Item("Ruta")
                    Objetos(5) = dr2.Item("Consecutivo")
                    Objetos(6) = dr2.Item("PorcentajeCalibración")
                    Objetos(7) = dr2.Item("Calibración")
                    Objetos(8) = dr2.Item("UsuarioAlta")
                    Objetos(9) = dr2.Item("UsuarioSolicito")
                    Objetos(10) = dr2.Item("FAlta")
                    Objetos(11) = dr2.Item("UsuarioModificó")
                    Objetos(12) = dr2.Item("FModificación")
                    Objetos(13) = dr2.Item("StatusFactor")
                    Objetos(14) = dr2.Item("StatusCliente")
                    dtFactorClienteHistorico.Rows.Add(Objetos)
                Next
                vgFactorClienteHistorico.DataSource = dtFactorClienteHistorico
            End If
        Else
            vgFactorClienteHistorico.Clear()
        End If

    End Sub

    Public Sub CargarFactorCliente(ByVal Celula As Integer, ByVal Ruta As Integer)
        vgFactorCliente.Clear()
        vgFactorClienteHistorico.Clear()
        Dim dtFactorClienteActual As DataTable
        Dim Rows As DataRow()
        Dim objetos(14) As Object
        Dim Filtro As String

        If Celula <> 0 Then
            Filtro = "Consecutivo = 0 and Célula = " & Celula & " and Ruta = " & Ruta
        Else
            Filtro = "Consecutivo = 0"
        End If

        Try
            dtFactorClienteActual = dtFactorCliente.Clone()
            'dtFactorClienteActual.Clear()

            Rows = dtFactorCliente.Select(Filtro, "Célula, Ruta, Cliente")

            For Each dr As DataRow In Rows
                objetos(0) = dr.Item("Cliente")
                objetos(1) = dr.Item("Nombre")
                objetos(2) = dr.Item("DirecciónCompleta")
                objetos(3) = dr.Item("Célula")
                objetos(4) = dr.Item("Ruta")
                objetos(5) = dr.Item("Consecutivo")
                objetos(6) = dr.Item("PorcentajeCalibración")
                objetos(7) = dr.Item("Calibración")
                objetos(8) = dr.Item("UsuarioAlta")
                objetos(9) = dr.Item("UsuarioSolicito")
                objetos(10) = dr.Item("FAlta")
                objetos(11) = dr.Item("UsuarioModificó")
                objetos(12) = dr.Item("FModificación")
                objetos(13) = dr.Item("StatusFactor")
                objetos(14) = dr.Item("StatusCliente")
                dtFactorClienteActual.Rows.Add(objetos)
            Next

            If vgFactorCliente.Width < 800 Then
                vgFactorCliente.Width = vgFactorCliente.Width * 2
            End If
            vgFactorCliente.DataSource = dtFactorClienteActual

        Catch ex As Exception
            ExMessage(ex)
        End Try
    End Sub
#End Region

    Private Sub AgregarFactorCliente()
        Dim frmCapturaFactorCliente As New frmCapturaFactorCliente()
        frmCapturaFactorCliente.ShowDialog()

        If frmCapturaFactorCliente.DialogResult = DialogResult.OK Then
            If Not cboRuta.SelectedValue Is Nothing And Not cboCelula.SelectedValue Is Nothing Then                                                
                CargaFactorClientePrincipal()
                CargarFactorCliente(CInt(cboCelula.SelectedValue), CInt(cboRuta.SelectedValue))
            Else
                CargaFactorClientePrincipal()
                CargarFactorCliente(0, 0)
            End If
        End If

        frmCapturaFactorCliente.Dispose()
    End Sub

    Private Sub ModificarFactorCliente()
        If Not vgFactorCliente.CurrentRow Is Nothing Then
            Dim frmCapturaFactorCliente As New frmCapturaFactorCliente(CInt(vgFactorCliente.CurrentRow("Cliente")))
            frmCapturaFactorCliente.ShowDialog()

            If frmCapturaFactorCliente.DialogResult = DialogResult.OK Then
                If Not cboRuta.SelectedValue Is Nothing And Not cboCelula.SelectedValue Is Nothing Then                                       
                    CargaFactorClientePrincipal()
                    CargarFactorCliente(CInt(cboCelula.SelectedValue), CInt(cboRuta.SelectedValue))
                Else
                    CargaFactorClientePrincipal()
                    CargarFactorCliente(0, 0)
                End If
            End If

            frmCapturaFactorCliente.Dispose()
        End If
    End Sub

    Private Sub CargaFactorClientePrincipal()        
        dtFactorCliente.Clear()        
        Dim cmdFactorCliente As New SqlCommand("spLOGConsultaClienteCalibracion", cnSigamet)
        cmdFactorCliente.CommandType = CommandType.StoredProcedure
        Dim daFactorCliente As New SqlDataAdapter(cmdFactorCliente)
        daFactorCliente.Fill(dtFactorCliente)
        daFactorCliente.Dispose()
    End Sub

    Private Sub frmFactorCliente_FormClosed(sender As System.Object, e As System.Windows.Forms.FormClosedEventArgs) Handles MyBase.FormClosed

    End Sub

    Private Sub InactivaFactorClienteCalibracion()        
        If Not vgFactorCliente.CurrentRow Is Nothing Then
            Dim cmdFactorCliente As SqlCommand

            Me.Cursor = Cursors.WaitCursor
            cmdFactorCliente = New SqlCommand("spLOGInactivaClienteCalibracion", cnSigamet)

            ' Asignación de parámetros
            cmdFactorCliente.CommandType = CommandType.StoredProcedure
            cmdFactorCliente.Parameters.Add("@Cliente", SqlDbType.Int).Value = CInt(vgFactorCliente.CurrentRow("Cliente"))
            cmdFactorCliente.Parameters.Add("@UsuarioInactiva", SqlDbType.VarChar).Value = _Usuario

            Try
                If cnSigamet.State = ConnectionState.Closed Then
                    cnSigamet.Open()
                End If
                cmdFactorCliente.ExecuteNonQuery()
                If Not cboRuta.SelectedValue Is Nothing And Not cboCelula.SelectedValue Is Nothing Then
                    CargaFactorClientePrincipal()
                    CargarFactorCliente(CInt(cboCelula.SelectedValue), CInt(cboRuta.SelectedValue))
                Else                     
                    CargaFactorClientePrincipal()
                    CargarFactorCliente(0, 0)
                End If
            Catch ex As Exception
                ExMessage(ex)
            Finally                
                Me.Cursor = Cursors.Default
                cnSigamet.Close()
                cmdFactorCliente.Dispose()
            End Try
        End If
    End Sub

    Private Sub Actualizar()
        If Not cboRuta.SelectedValue Is Nothing And Not cboCelula.SelectedValue Is Nothing Then
            CargaFactorClientePrincipal()
            CargarFactorCliente(CInt(cboCelula.SelectedValue), CInt(cboRuta.SelectedValue))
        End If
    End Sub

    Private Sub Buscar()
        'Petición de busqueda
        Dim Cliente As String = InputBox("No. de cliente:")
        'Validación de texto de busqueda
        If Trim(Cliente) <> "" Then
            'Busqueda
            If vgFactorCliente.FindFirst("Cliente", Trim(Cliente)) < 0 Then
                MessageBox.Show("No se ha encontrado el cliente no. " & Trim(Cliente), Application.ProductName & " v." & Application.ProductVersion, MessageBoxButtons.OK, MessageBoxIcon.Information)
            Else
                vgFactorCliente.Focus()
            End If
        End If
    End Sub

    Private Sub mniAgregar_Click(sender As System.Object, e As System.EventArgs) Handles mniAgregar.Click          
        AgregarFactorCliente()               
    End Sub

    Private Sub mniModificar_Click(sender As System.Object, e As System.EventArgs) Handles mniModificar.Click        
        ModificarFactorCliente()        
    End Sub

    Private Sub mniInactivar_Click(sender As System.Object, e As System.EventArgs) Handles mniInactivar.Click
        InactivaFactorClienteCalibracion()           
    End Sub

    Private Sub mniBuscar_Click(sender As System.Object, e As System.EventArgs) Handles mniBuscar.Click
        Buscar()         
    End Sub

    Private Sub mniActualizar_Click(sender As System.Object, e As System.EventArgs) Handles mniActualizar.Click
        Actualizar()          
    End Sub
End Class

