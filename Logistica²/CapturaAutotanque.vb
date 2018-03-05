Imports System.Data.SqlClient

Public Class frmCapturaAutotanque
    Inherits System.Windows.Forms.Form

#Region " Windows Form Designer generated code "

    Public Sub New(ByVal Celula As Integer, Optional ByVal Autotanque As Integer = 0)
        MyBase.New()

        'This call is required by the Windows Form Designer.
        InitializeComponent()

        'Add any initialization after the InitializeComponent() call
        Dim cmdLogistica As New SqlCommand("Select TipoVehiculo, Descripcion from TipoVehiculo order by Descripcion", cnSigamet)
        Dim daLogistica As New SqlDataAdapter(cmdLogistica)
        'Tablas para llenado de combos
        Dim dtTipo As New DataTable()
        Dim dtMarca As New DataTable()
        Dim dtProducto As New DataTable()
        Dim dtPropietario As New DataTable()
        Dim dtCelula As New DataTable()
        cmdLogistica.Parameters.Add("@Usuario", SqlDbType.Char).Value = _Usuario
        Try
            daLogistica.Fill(dtTipo)
            cmdLogistica.CommandText = "Select MarcaAutotanque, Descripcion from MarcaAutotanque order by Descripcion"
            daLogistica.Fill(dtMarca)
            cmdLogistica.CommandText = "Select TipoProducto, Descripcion from TipoProducto order by Descripcion"
            daLogistica.Fill(dtProducto)
            cmdLogistica.CommandText = "Select Propietario, Nombre from Propietario order by Nombre"
            daLogistica.Fill(dtPropietario)
            cmdLogistica.CommandText = "Select Celula, Descripcion from Celula where Comercial = 1 and Celula in (Select Celula from UsuarioCelula " _
                                & " where Usuario = @Usuario)"
            daLogistica.Fill(dtCelula)
        Catch ex As Exception
            ExMessage(ex)
        End Try

        'Llenado de combos
        cboTipo.ValueMember = "TipoVehiculo"
        cboTipo.DisplayMember = "Descripcion"
        cboTipo.DataSource = dtTipo

        cboMarca.ValueMember = "MarcaAutotanque"
        cboMarca.DisplayMember = "Descripcion"
        cboMarca.DataSource = dtMarca

        cboProducto.ValueMember = "TipoProducto"
        cboProducto.DisplayMember = "Descripcion"
        cboProducto.DataSource = dtProducto

        cboPropietario.ValueMember = "Propietario"
        cboPropietario.DisplayMember = "Nombre"
        cboPropietario.DataSource = dtPropietario

        cboCelula.ValueMember = "Celula"
        cboCelula.DisplayMember = "Descripcion"
        cboCelula.DataSource = dtCelula

        'Parametros de default
        Application.DoEvents()
        cboCelula.SelectedValue = Celula

        'Limpiado de memoria
        cmdLogistica.Dispose()
        daLogistica.Dispose()

        'Nuevo/Modificación
        Me.Text = "Nuevo autotanque"
        If Autotanque > 0 Then
            Me.Text = "Modificación de autotanque"
            txtAutotanque.Text = Autotanque.ToString
            txtAutotanque.ReadOnly = True
            cboStatus.Enabled = True
            CargaDatosAutotanque()
        Else
            cboStatus.SelectedIndex = 0
            txtCalibracion.Text = _CalibracionPrdeterminada.ToString()
            txtCalibracionPorcentaje.Text = _CalibracionPrdeterminada.ToString()
        End If



        If OperacionLogistica(16).Habilitada Or OperacionLogistica(17).Habilitada Then
            txtCalibracion.Visible = True
            lblCalibracion.Visible = True
            txtCalibracionPorcentaje.Visible = True
            lblCalibracionPorcentaje.Visible = True

            txtPorcentajeInventario.Visible = True
            lblPorcentajeinventario.Visible = True
            txtUmbralRelleno.Visible = True
            lblUmbralRelleno.Visible = True
            chkPesadoAutomatico.Visible = True
            lblPesadoAutomatico.Visible = True
            lblFactorDensidadMasico.Visible = True
            chkFactorDensidadMasico.Visible = True

            lblFactor.Visible = True
            lblFactorP.Visible = True
            txtFactor.Visible = True
            txtFactorPorcentaje.Visible = True

        End If
       

        If Not OperacionLogistica(16).Habilitada And Not OperacionLogistica(17).Habilitada Then
            'Me.Height = 424
            'LUSATE Tamaño para que se visualice el campo Boletín en Línea y Usuario Móvil
            Me.Height = 500
            'LUSATE
        End If

        If OperacionLogistica(17).Habilitada Then
            txtFactor.ReadOnly = False

        End If
        'LUSATE Tamaño para que se visualice el campo Boletín en Línea y Usuario Móvil
        If OperacionLogistica(20).Habilitada Then
            chkBoletinenLinea.Enabled = True
            txtUsuarioMovil.ReadOnly = False
        End If
        'LUSATE

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
    Friend WithEvents btnCancelar As System.Windows.Forms.Button
    Friend WithEvents btnAceptar As System.Windows.Forms.Button
    Friend WithEvents rgrpDatos As Logistica.RoundedGroupBox
    Friend WithEvents lblCelula As System.Windows.Forms.Label
    Friend WithEvents lblAutotanque As System.Windows.Forms.Label
    Friend WithEvents txtAutotanque As System.Windows.Forms.TextBox
    Friend WithEvents lblRuta As System.Windows.Forms.Label
    Friend WithEvents lblCapacidad As System.Windows.Forms.Label
    Friend WithEvents lblPlacas As System.Windows.Forms.Label
    Friend WithEvents lblTipo As System.Windows.Forms.Label
    Friend WithEvents lblMarca As System.Windows.Forms.Label
    Friend WithEvents lblTransponder As System.Windows.Forms.Label
    Friend WithEvents lblGPS As System.Windows.Forms.Label
    Friend WithEvents lblStatus As System.Windows.Forms.Label
    Friend WithEvents cboCelula As System.Windows.Forms.ComboBox
    Friend WithEvents txtCapacidad As System.Windows.Forms.TextBox
    Friend WithEvents txtPlacas As System.Windows.Forms.TextBox
    Friend WithEvents cboTipo As System.Windows.Forms.ComboBox
    Friend WithEvents cboMarca As System.Windows.Forms.ComboBox
    Friend WithEvents cboProducto As System.Windows.Forms.ComboBox
    Friend WithEvents cboPropietario As System.Windows.Forms.ComboBox
    Friend WithEvents txtTransponder As System.Windows.Forms.TextBox
    Friend WithEvents txtGPS As System.Windows.Forms.TextBox
    Friend WithEvents cboStatus As System.Windows.Forms.ComboBox
    Friend WithEvents cboRuta As System.Windows.Forms.ComboBox
    Friend WithEvents lblProducto As System.Windows.Forms.Label
    Friend WithEvents lblPropietario As System.Windows.Forms.Label
    Friend WithEvents lblCalibracion As System.Windows.Forms.Label
    Friend WithEvents txtCalibracion As System.Windows.Forms.TextBox
    Friend WithEvents cboTipoMedidor As System.Windows.Forms.ComboBox
    Friend WithEvents txtCalibracionPorcentaje As System.Windows.Forms.TextBox
    Friend WithEvents lblTipoMedidor As System.Windows.Forms.Label
    Friend WithEvents lblCalibracionPorcentaje As System.Windows.Forms.Label
    Friend WithEvents txtPorcentajeInventario As System.Windows.Forms.TextBox
    Friend WithEvents txtUmbralRelleno As System.Windows.Forms.TextBox
    Friend WithEvents chkPesadoAutomatico As System.Windows.Forms.CheckBox
    Friend WithEvents lblPorcentajeinventario As System.Windows.Forms.Label
    Friend WithEvents lblUmbralRelleno As System.Windows.Forms.Label
    Friend WithEvents chkFactorDensidadMasico As System.Windows.Forms.CheckBox
    Friend WithEvents lblFactorDensidadMasico As System.Windows.Forms.Label
    Friend WithEvents lblPesadoAutomatico As System.Windows.Forms.Label
    Friend WithEvents chkBoletinenLinea As System.Windows.Forms.CheckBox
    Friend WithEvents lblFactor As System.Windows.Forms.Label
    Friend WithEvents txtFactor As System.Windows.Forms.TextBox
    Friend WithEvents lblUsuarioMovil As System.Windows.Forms.Label
    Friend WithEvents txtUsuarioMovil As System.Windows.Forms.TextBox
    Friend WithEvents chxVerificaDescargaRI As System.Windows.Forms.CheckBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents lblFactorP As System.Windows.Forms.Label
    Friend WithEvents txtFactorPorcentaje As System.Windows.Forms.TextBox
    Friend WithEvents lblBoletinEnLinea As System.Windows.Forms.Label
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmCapturaAutotanque))
        Me.btnCancelar = New System.Windows.Forms.Button()
        Me.btnAceptar = New System.Windows.Forms.Button()
        Me.rgrpDatos = New Logistica.RoundedGroupBox()
        Me.lblFactorP = New System.Windows.Forms.Label()
        Me.txtFactorPorcentaje = New System.Windows.Forms.TextBox()
        Me.chxVerificaDescargaRI = New System.Windows.Forms.CheckBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.lblUsuarioMovil = New System.Windows.Forms.Label()
        Me.txtUsuarioMovil = New System.Windows.Forms.TextBox()
        Me.lblFactor = New System.Windows.Forms.Label()
        Me.txtFactor = New System.Windows.Forms.TextBox()
        Me.chkBoletinenLinea = New System.Windows.Forms.CheckBox()
        Me.lblBoletinEnLinea = New System.Windows.Forms.Label()
        Me.chkFactorDensidadMasico = New System.Windows.Forms.CheckBox()
        Me.lblFactorDensidadMasico = New System.Windows.Forms.Label()
        Me.lblUmbralRelleno = New System.Windows.Forms.Label()
        Me.lblPorcentajeinventario = New System.Windows.Forms.Label()
        Me.chkPesadoAutomatico = New System.Windows.Forms.CheckBox()
        Me.txtUmbralRelleno = New System.Windows.Forms.TextBox()
        Me.txtPorcentajeInventario = New System.Windows.Forms.TextBox()
        Me.lblCalibracionPorcentaje = New System.Windows.Forms.Label()
        Me.txtCalibracionPorcentaje = New System.Windows.Forms.TextBox()
        Me.lblTipoMedidor = New System.Windows.Forms.Label()
        Me.cboTipoMedidor = New System.Windows.Forms.ComboBox()
        Me.lblCalibracion = New System.Windows.Forms.Label()
        Me.txtCalibracion = New System.Windows.Forms.TextBox()
        Me.cboCelula = New System.Windows.Forms.ComboBox()
        Me.lblCelula = New System.Windows.Forms.Label()
        Me.lblAutotanque = New System.Windows.Forms.Label()
        Me.txtAutotanque = New System.Windows.Forms.TextBox()
        Me.lblRuta = New System.Windows.Forms.Label()
        Me.lblCapacidad = New System.Windows.Forms.Label()
        Me.lblPlacas = New System.Windows.Forms.Label()
        Me.lblTipo = New System.Windows.Forms.Label()
        Me.lblMarca = New System.Windows.Forms.Label()
        Me.lblProducto = New System.Windows.Forms.Label()
        Me.lblPropietario = New System.Windows.Forms.Label()
        Me.lblTransponder = New System.Windows.Forms.Label()
        Me.lblGPS = New System.Windows.Forms.Label()
        Me.lblStatus = New System.Windows.Forms.Label()
        Me.txtCapacidad = New System.Windows.Forms.TextBox()
        Me.txtPlacas = New System.Windows.Forms.TextBox()
        Me.cboTipo = New System.Windows.Forms.ComboBox()
        Me.cboMarca = New System.Windows.Forms.ComboBox()
        Me.cboProducto = New System.Windows.Forms.ComboBox()
        Me.cboPropietario = New System.Windows.Forms.ComboBox()
        Me.txtTransponder = New System.Windows.Forms.TextBox()
        Me.txtGPS = New System.Windows.Forms.TextBox()
        Me.cboStatus = New System.Windows.Forms.ComboBox()
        Me.cboRuta = New System.Windows.Forms.ComboBox()
        Me.lblPesadoAutomatico = New System.Windows.Forms.Label()
        Me.rgrpDatos.SuspendLayout()
        Me.SuspendLayout()
        '
        'btnCancelar
        '
        Me.btnCancelar.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnCancelar.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnCancelar.Image = CType(resources.GetObject("btnCancelar.Image"), System.Drawing.Image)
        Me.btnCancelar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnCancelar.Location = New System.Drawing.Point(268, 49)
        Me.btnCancelar.Name = "btnCancelar"
        Me.btnCancelar.Size = New System.Drawing.Size(80, 24)
        Me.btnCancelar.TabIndex = 27
        Me.btnCancelar.Text = "&Cancelar"
        Me.btnCancelar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'btnAceptar
        '
        Me.btnAceptar.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnAceptar.Image = CType(resources.GetObject("btnAceptar.Image"), System.Drawing.Image)
        Me.btnAceptar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnAceptar.Location = New System.Drawing.Point(268, 13)
        Me.btnAceptar.Name = "btnAceptar"
        Me.btnAceptar.Size = New System.Drawing.Size(80, 24)
        Me.btnAceptar.TabIndex = 26
        Me.btnAceptar.Text = "&Aceptar"
        Me.btnAceptar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'rgrpDatos
        '
        Me.rgrpDatos.BorderColor = System.Drawing.Color.SteelBlue
        Me.rgrpDatos.Controls.Add(Me.lblFactorP)
        Me.rgrpDatos.Controls.Add(Me.txtFactorPorcentaje)
        Me.rgrpDatos.Controls.Add(Me.chxVerificaDescargaRI)
        Me.rgrpDatos.Controls.Add(Me.Label1)
        Me.rgrpDatos.Controls.Add(Me.lblUsuarioMovil)
        Me.rgrpDatos.Controls.Add(Me.txtUsuarioMovil)
        Me.rgrpDatos.Controls.Add(Me.lblFactor)
        Me.rgrpDatos.Controls.Add(Me.txtFactor)
        Me.rgrpDatos.Controls.Add(Me.chkBoletinenLinea)
        Me.rgrpDatos.Controls.Add(Me.lblBoletinEnLinea)
        Me.rgrpDatos.Controls.Add(Me.chkFactorDensidadMasico)
        Me.rgrpDatos.Controls.Add(Me.lblFactorDensidadMasico)
        Me.rgrpDatos.Controls.Add(Me.lblUmbralRelleno)
        Me.rgrpDatos.Controls.Add(Me.lblPorcentajeinventario)
        Me.rgrpDatos.Controls.Add(Me.chkPesadoAutomatico)
        Me.rgrpDatos.Controls.Add(Me.txtUmbralRelleno)
        Me.rgrpDatos.Controls.Add(Me.txtPorcentajeInventario)
        Me.rgrpDatos.Controls.Add(Me.lblCalibracionPorcentaje)
        Me.rgrpDatos.Controls.Add(Me.txtCalibracionPorcentaje)
        Me.rgrpDatos.Controls.Add(Me.lblTipoMedidor)
        Me.rgrpDatos.Controls.Add(Me.cboTipoMedidor)
        Me.rgrpDatos.Controls.Add(Me.lblCalibracion)
        Me.rgrpDatos.Controls.Add(Me.txtCalibracion)
        Me.rgrpDatos.Controls.Add(Me.cboCelula)
        Me.rgrpDatos.Controls.Add(Me.lblCelula)
        Me.rgrpDatos.Controls.Add(Me.lblAutotanque)
        Me.rgrpDatos.Controls.Add(Me.txtAutotanque)
        Me.rgrpDatos.Controls.Add(Me.lblRuta)
        Me.rgrpDatos.Controls.Add(Me.lblCapacidad)
        Me.rgrpDatos.Controls.Add(Me.lblPlacas)
        Me.rgrpDatos.Controls.Add(Me.lblTipo)
        Me.rgrpDatos.Controls.Add(Me.lblMarca)
        Me.rgrpDatos.Controls.Add(Me.lblProducto)
        Me.rgrpDatos.Controls.Add(Me.lblPropietario)
        Me.rgrpDatos.Controls.Add(Me.lblTransponder)
        Me.rgrpDatos.Controls.Add(Me.lblGPS)
        Me.rgrpDatos.Controls.Add(Me.lblStatus)
        Me.rgrpDatos.Controls.Add(Me.txtCapacidad)
        Me.rgrpDatos.Controls.Add(Me.txtPlacas)
        Me.rgrpDatos.Controls.Add(Me.cboTipo)
        Me.rgrpDatos.Controls.Add(Me.cboMarca)
        Me.rgrpDatos.Controls.Add(Me.cboProducto)
        Me.rgrpDatos.Controls.Add(Me.cboPropietario)
        Me.rgrpDatos.Controls.Add(Me.txtTransponder)
        Me.rgrpDatos.Controls.Add(Me.txtGPS)
        Me.rgrpDatos.Controls.Add(Me.cboStatus)
        Me.rgrpDatos.Controls.Add(Me.cboRuta)
        Me.rgrpDatos.Controls.Add(Me.lblPesadoAutomatico)
        Me.rgrpDatos.Dock = System.Windows.Forms.DockStyle.Left
        Me.rgrpDatos.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rgrpDatos.ForeColor = System.Drawing.Color.DarkBlue
        Me.rgrpDatos.Location = New System.Drawing.Point(3, 3)
        Me.rgrpDatos.Name = "rgrpDatos"
        Me.rgrpDatos.Size = New System.Drawing.Size(252, 687)
        Me.rgrpDatos.TabIndex = 0
        Me.rgrpDatos.TabStop = False
        Me.rgrpDatos.Text = "Datos del autotanque"
        Me.rgrpDatos.TextAlignment = System.Windows.Forms.HorizontalAlignment.Center
        '
        'lblFactorP
        '
        Me.lblFactorP.AutoSize = True
        Me.lblFactorP.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblFactorP.ForeColor = System.Drawing.Color.Black
        Me.lblFactorP.Location = New System.Drawing.Point(15, 654)
        Me.lblFactorP.Name = "lblFactorP"
        Me.lblFactorP.Size = New System.Drawing.Size(56, 13)
        Me.lblFactorP.TabIndex = 34
        Me.lblFactorP.Text = "Factor %:"
        Me.lblFactorP.Visible = False
        '
        'txtFactorPorcentaje
        '
        Me.txtFactorPorcentaje.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtFactorPorcentaje.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtFactorPorcentaje.ForeColor = System.Drawing.Color.Black
        Me.txtFactorPorcentaje.Location = New System.Drawing.Point(104, 650)
        Me.txtFactorPorcentaje.MaxLength = 20
        Me.txtFactorPorcentaje.Name = "txtFactorPorcentaje"
        Me.txtFactorPorcentaje.Size = New System.Drawing.Size(136, 21)
        Me.txtFactorPorcentaje.TabIndex = 24
        Me.txtFactorPorcentaje.Visible = False
        '
        'chxVerificaDescargaRI
        '
        Me.chxVerificaDescargaRI.Location = New System.Drawing.Point(149, 434)
        Me.chxVerificaDescargaRI.Name = "chxVerificaDescargaRI"
        Me.chxVerificaDescargaRI.Size = New System.Drawing.Size(16, 24)
        Me.chxVerificaDescargaRI.TabIndex = 16
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.Black
        Me.Label1.Location = New System.Drawing.Point(13, 442)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(107, 13)
        Me.Label1.TabIndex = 32
        Me.Label1.Text = "Verifica descarga RI:"
        '
        'lblUsuarioMovil
        '
        Me.lblUsuarioMovil.AutoSize = True
        Me.lblUsuarioMovil.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblUsuarioMovil.ForeColor = System.Drawing.Color.Black
        Me.lblUsuarioMovil.Location = New System.Drawing.Point(13, 413)
        Me.lblUsuarioMovil.Name = "lblUsuarioMovil"
        Me.lblUsuarioMovil.Size = New System.Drawing.Size(74, 13)
        Me.lblUsuarioMovil.TabIndex = 30
        Me.lblUsuarioMovil.Text = "Usuario Móvil:"
        '
        'txtUsuarioMovil
        '
        Me.txtUsuarioMovil.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtUsuarioMovil.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtUsuarioMovil.ForeColor = System.Drawing.Color.Black
        Me.txtUsuarioMovil.Location = New System.Drawing.Point(104, 409)
        Me.txtUsuarioMovil.MaxLength = 20
        Me.txtUsuarioMovil.Name = "txtUsuarioMovil"
        Me.txtUsuarioMovil.ReadOnly = True
        Me.txtUsuarioMovil.Size = New System.Drawing.Size(136, 21)
        Me.txtUsuarioMovil.TabIndex = 15
        '
        'lblFactor
        '
        Me.lblFactor.AutoSize = True
        Me.lblFactor.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblFactor.ForeColor = System.Drawing.Color.Black
        Me.lblFactor.Location = New System.Drawing.Point(15, 625)
        Me.lblFactor.Name = "lblFactor"
        Me.lblFactor.Size = New System.Drawing.Size(42, 13)
        Me.lblFactor.TabIndex = 29
        Me.lblFactor.Text = "Factor:"
        Me.lblFactor.Visible = False
        '
        'txtFactor
        '
        Me.txtFactor.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtFactor.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtFactor.ForeColor = System.Drawing.Color.Black
        Me.txtFactor.Location = New System.Drawing.Point(104, 623)
        Me.txtFactor.MaxLength = 32
        Me.txtFactor.Name = "txtFactor"
        Me.txtFactor.ReadOnly = True
        Me.txtFactor.Size = New System.Drawing.Size(136, 21)
        Me.txtFactor.TabIndex = 23
        Me.txtFactor.Visible = False
        '
        'chkBoletinenLinea
        '
        Me.chkBoletinenLinea.Enabled = False
        Me.chkBoletinenLinea.Location = New System.Drawing.Point(149, 381)
        Me.chkBoletinenLinea.Name = "chkBoletinenLinea"
        Me.chkBoletinenLinea.Size = New System.Drawing.Size(16, 24)
        Me.chkBoletinenLinea.TabIndex = 14
        '
        'lblBoletinEnLinea
        '
        Me.lblBoletinEnLinea.AutoSize = True
        Me.lblBoletinEnLinea.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblBoletinEnLinea.ForeColor = System.Drawing.Color.Black
        Me.lblBoletinEnLinea.Location = New System.Drawing.Point(13, 389)
        Me.lblBoletinEnLinea.Name = "lblBoletinEnLinea"
        Me.lblBoletinEnLinea.Size = New System.Drawing.Size(83, 13)
        Me.lblBoletinEnLinea.TabIndex = 27
        Me.lblBoletinEnLinea.Text = "Boletin en línea:"
        '
        'chkFactorDensidadMasico
        '
        Me.chkFactorDensidadMasico.Location = New System.Drawing.Point(152, 593)
        Me.chkFactorDensidadMasico.Name = "chkFactorDensidadMasico"
        Me.chkFactorDensidadMasico.Size = New System.Drawing.Size(16, 24)
        Me.chkFactorDensidadMasico.TabIndex = 22
        Me.chkFactorDensidadMasico.Visible = False
        '
        'lblFactorDensidadMasico
        '
        Me.lblFactorDensidadMasico.AutoSize = True
        Me.lblFactorDensidadMasico.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblFactorDensidadMasico.ForeColor = System.Drawing.Color.Black
        Me.lblFactorDensidadMasico.Location = New System.Drawing.Point(14, 600)
        Me.lblFactorDensidadMasico.Name = "lblFactorDensidadMasico"
        Me.lblFactorDensidadMasico.Size = New System.Drawing.Size(124, 13)
        Me.lblFactorDensidadMasico.TabIndex = 25
        Me.lblFactorDensidadMasico.Text = "Factor Densidad Másico:"
        Me.lblFactorDensidadMasico.Visible = False
        '
        'lblUmbralRelleno
        '
        Me.lblUmbralRelleno.AutoSize = True
        Me.lblUmbralRelleno.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblUmbralRelleno.ForeColor = System.Drawing.Color.Black
        Me.lblUmbralRelleno.Location = New System.Drawing.Point(15, 551)
        Me.lblUmbralRelleno.Name = "lblUmbralRelleno"
        Me.lblUmbralRelleno.Size = New System.Drawing.Size(61, 13)
        Me.lblUmbralRelleno.TabIndex = 22
        Me.lblUmbralRelleno.Text = "Umbral  %:"
        Me.lblUmbralRelleno.Visible = False
        '
        'lblPorcentajeinventario
        '
        Me.lblPorcentajeinventario.AutoSize = True
        Me.lblPorcentajeinventario.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblPorcentajeinventario.ForeColor = System.Drawing.Color.Black
        Me.lblPorcentajeinventario.Location = New System.Drawing.Point(14, 525)
        Me.lblPorcentajeinventario.Name = "lblPorcentajeinventario"
        Me.lblPorcentajeinventario.Size = New System.Drawing.Size(75, 13)
        Me.lblPorcentajeinventario.TabIndex = 21
        Me.lblPorcentajeinventario.Text = "Inventario %:"
        Me.lblPorcentajeinventario.Visible = False
        '
        'chkPesadoAutomatico
        '
        Me.chkPesadoAutomatico.Location = New System.Drawing.Point(152, 572)
        Me.chkPesadoAutomatico.Name = "chkPesadoAutomatico"
        Me.chkPesadoAutomatico.Size = New System.Drawing.Size(16, 24)
        Me.chkPesadoAutomatico.TabIndex = 21
        Me.chkPesadoAutomatico.Visible = False
        '
        'txtUmbralRelleno
        '
        Me.txtUmbralRelleno.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtUmbralRelleno.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtUmbralRelleno.ForeColor = System.Drawing.Color.Black
        Me.txtUmbralRelleno.Location = New System.Drawing.Point(104, 547)
        Me.txtUmbralRelleno.MaxLength = 20
        Me.txtUmbralRelleno.Name = "txtUmbralRelleno"
        Me.txtUmbralRelleno.Size = New System.Drawing.Size(136, 21)
        Me.txtUmbralRelleno.TabIndex = 20
        Me.txtUmbralRelleno.Visible = False
        '
        'txtPorcentajeInventario
        '
        Me.txtPorcentajeInventario.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtPorcentajeInventario.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtPorcentajeInventario.ForeColor = System.Drawing.Color.Black
        Me.txtPorcentajeInventario.Location = New System.Drawing.Point(104, 521)
        Me.txtPorcentajeInventario.MaxLength = 20
        Me.txtPorcentajeInventario.Name = "txtPorcentajeInventario"
        Me.txtPorcentajeInventario.Size = New System.Drawing.Size(136, 21)
        Me.txtPorcentajeInventario.TabIndex = 19
        Me.txtPorcentajeInventario.Visible = False
        '
        'lblCalibracionPorcentaje
        '
        Me.lblCalibracionPorcentaje.AutoSize = True
        Me.lblCalibracionPorcentaje.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCalibracionPorcentaje.ForeColor = System.Drawing.Color.Black
        Me.lblCalibracionPorcentaje.Location = New System.Drawing.Point(13, 497)
        Me.lblCalibracionPorcentaje.Name = "lblCalibracionPorcentaje"
        Me.lblCalibracionPorcentaje.Size = New System.Drawing.Size(77, 13)
        Me.lblCalibracionPorcentaje.TabIndex = 17
        Me.lblCalibracionPorcentaje.Text = "Ca&libración %:"
        Me.lblCalibracionPorcentaje.Visible = False
        '
        'txtCalibracionPorcentaje
        '
        Me.txtCalibracionPorcentaje.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtCalibracionPorcentaje.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtCalibracionPorcentaje.ForeColor = System.Drawing.Color.Black
        Me.txtCalibracionPorcentaje.Location = New System.Drawing.Point(104, 493)
        Me.txtCalibracionPorcentaje.MaxLength = 20
        Me.txtCalibracionPorcentaje.Name = "txtCalibracionPorcentaje"
        Me.txtCalibracionPorcentaje.Size = New System.Drawing.Size(136, 21)
        Me.txtCalibracionPorcentaje.TabIndex = 18
        Me.txtCalibracionPorcentaje.Visible = False
        '
        'lblTipoMedidor
        '
        Me.lblTipoMedidor.AutoSize = True
        Me.lblTipoMedidor.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTipoMedidor.ForeColor = System.Drawing.Color.Black
        Me.lblTipoMedidor.Location = New System.Drawing.Point(13, 360)
        Me.lblTipoMedidor.Name = "lblTipoMedidor"
        Me.lblTipoMedidor.Size = New System.Drawing.Size(72, 13)
        Me.lblTipoMedidor.TabIndex = 16
        Me.lblTipoMedidor.Text = "Tipo medidor:"
        '
        'cboTipoMedidor
        '
        Me.cboTipoMedidor.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboTipoMedidor.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboTipoMedidor.Items.AddRange(New Object() {"ROTOGAGE", "MAGNATEL"})
        Me.cboTipoMedidor.Location = New System.Drawing.Point(104, 356)
        Me.cboTipoMedidor.Name = "cboTipoMedidor"
        Me.cboTipoMedidor.Size = New System.Drawing.Size(136, 21)
        Me.cboTipoMedidor.TabIndex = 13
        '
        'lblCalibracion
        '
        Me.lblCalibracion.AutoSize = True
        Me.lblCalibracion.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCalibracion.ForeColor = System.Drawing.Color.Black
        Me.lblCalibracion.Location = New System.Drawing.Point(13, 469)
        Me.lblCalibracion.Name = "lblCalibracion"
        Me.lblCalibracion.Size = New System.Drawing.Size(89, 13)
        Me.lblCalibracion.TabIndex = 13
        Me.lblCalibracion.Text = "Ca&libración peso:"
        Me.lblCalibracion.Visible = False
        '
        'txtCalibracion
        '
        Me.txtCalibracion.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtCalibracion.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtCalibracion.ForeColor = System.Drawing.Color.Black
        Me.txtCalibracion.Location = New System.Drawing.Point(104, 465)
        Me.txtCalibracion.MaxLength = 20
        Me.txtCalibracion.Name = "txtCalibracion"
        Me.txtCalibracion.Size = New System.Drawing.Size(136, 21)
        Me.txtCalibracion.TabIndex = 17
        Me.txtCalibracion.Visible = False
        '
        'cboCelula
        '
        Me.cboCelula.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboCelula.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboCelula.Location = New System.Drawing.Point(104, 48)
        Me.cboCelula.Name = "cboCelula"
        Me.cboCelula.Size = New System.Drawing.Size(136, 21)
        Me.cboCelula.TabIndex = 2
        '
        'lblCelula
        '
        Me.lblCelula.AutoSize = True
        Me.lblCelula.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCelula.ForeColor = System.Drawing.Color.Black
        Me.lblCelula.Location = New System.Drawing.Point(13, 52)
        Me.lblCelula.Name = "lblCelula"
        Me.lblCelula.Size = New System.Drawing.Size(40, 13)
        Me.lblCelula.TabIndex = 1
        Me.lblCelula.Text = "Cé&lula:"
        '
        'lblAutotanque
        '
        Me.lblAutotanque.AutoSize = True
        Me.lblAutotanque.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblAutotanque.ForeColor = System.Drawing.Color.Black
        Me.lblAutotanque.Location = New System.Drawing.Point(13, 24)
        Me.lblAutotanque.Name = "lblAutotanque"
        Me.lblAutotanque.Size = New System.Drawing.Size(77, 13)
        Me.lblAutotanque.TabIndex = 0
        Me.lblAutotanque.Text = "Au&totanque:"
        '
        'txtAutotanque
        '
        Me.txtAutotanque.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtAutotanque.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtAutotanque.ForeColor = System.Drawing.Color.Black
        Me.txtAutotanque.Location = New System.Drawing.Point(104, 20)
        Me.txtAutotanque.MaxLength = 10
        Me.txtAutotanque.Name = "txtAutotanque"
        Me.txtAutotanque.Size = New System.Drawing.Size(136, 21)
        Me.txtAutotanque.TabIndex = 1
        '
        'lblRuta
        '
        Me.lblRuta.AutoSize = True
        Me.lblRuta.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblRuta.ForeColor = System.Drawing.Color.Black
        Me.lblRuta.Location = New System.Drawing.Point(13, 80)
        Me.lblRuta.Name = "lblRuta"
        Me.lblRuta.Size = New System.Drawing.Size(34, 13)
        Me.lblRuta.TabIndex = 2
        Me.lblRuta.Text = "&Ruta:"
        '
        'lblCapacidad
        '
        Me.lblCapacidad.AutoSize = True
        Me.lblCapacidad.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCapacidad.ForeColor = System.Drawing.Color.Black
        Me.lblCapacidad.Location = New System.Drawing.Point(13, 108)
        Me.lblCapacidad.Name = "lblCapacidad"
        Me.lblCapacidad.Size = New System.Drawing.Size(61, 13)
        Me.lblCapacidad.TabIndex = 3
        Me.lblCapacidad.Text = "Ca&pacidad:"
        '
        'lblPlacas
        '
        Me.lblPlacas.AutoSize = True
        Me.lblPlacas.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblPlacas.ForeColor = System.Drawing.Color.Black
        Me.lblPlacas.Location = New System.Drawing.Point(13, 136)
        Me.lblPlacas.Name = "lblPlacas"
        Me.lblPlacas.Size = New System.Drawing.Size(41, 13)
        Me.lblPlacas.TabIndex = 4
        Me.lblPlacas.Text = "Placa&s:"
        '
        'lblTipo
        '
        Me.lblTipo.AutoSize = True
        Me.lblTipo.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTipo.ForeColor = System.Drawing.Color.Black
        Me.lblTipo.Location = New System.Drawing.Point(13, 164)
        Me.lblTipo.Name = "lblTipo"
        Me.lblTipo.Size = New System.Drawing.Size(31, 13)
        Me.lblTipo.TabIndex = 5
        Me.lblTipo.Text = "T&ipo:"
        '
        'lblMarca
        '
        Me.lblMarca.AutoSize = True
        Me.lblMarca.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblMarca.ForeColor = System.Drawing.Color.Black
        Me.lblMarca.Location = New System.Drawing.Point(13, 192)
        Me.lblMarca.Name = "lblMarca"
        Me.lblMarca.Size = New System.Drawing.Size(40, 13)
        Me.lblMarca.TabIndex = 6
        Me.lblMarca.Text = "&Marca:"
        '
        'lblProducto
        '
        Me.lblProducto.AutoSize = True
        Me.lblProducto.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblProducto.ForeColor = System.Drawing.Color.Black
        Me.lblProducto.Location = New System.Drawing.Point(13, 220)
        Me.lblProducto.Name = "lblProducto"
        Me.lblProducto.Size = New System.Drawing.Size(54, 13)
        Me.lblProducto.TabIndex = 7
        Me.lblProducto.Text = "Pro&ducto:"
        '
        'lblPropietario
        '
        Me.lblPropietario.AutoSize = True
        Me.lblPropietario.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblPropietario.ForeColor = System.Drawing.Color.Black
        Me.lblPropietario.Location = New System.Drawing.Point(13, 248)
        Me.lblPropietario.Name = "lblPropietario"
        Me.lblPropietario.Size = New System.Drawing.Size(63, 13)
        Me.lblPropietario.TabIndex = 8
        Me.lblPropietario.Text = "Propietari&o:"
        '
        'lblTransponder
        '
        Me.lblTransponder.AutoSize = True
        Me.lblTransponder.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTransponder.ForeColor = System.Drawing.Color.Black
        Me.lblTransponder.Location = New System.Drawing.Point(13, 276)
        Me.lblTransponder.Name = "lblTransponder"
        Me.lblTransponder.Size = New System.Drawing.Size(72, 13)
        Me.lblTransponder.TabIndex = 9
        Me.lblTransponder.Text = "Tra&nsponder:"
        '
        'lblGPS
        '
        Me.lblGPS.AutoSize = True
        Me.lblGPS.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblGPS.ForeColor = System.Drawing.Color.Black
        Me.lblGPS.Location = New System.Drawing.Point(13, 304)
        Me.lblGPS.Name = "lblGPS"
        Me.lblGPS.Size = New System.Drawing.Size(30, 13)
        Me.lblGPS.TabIndex = 10
        Me.lblGPS.Text = "&GPS:"
        '
        'lblStatus
        '
        Me.lblStatus.AutoSize = True
        Me.lblStatus.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblStatus.ForeColor = System.Drawing.Color.Black
        Me.lblStatus.Location = New System.Drawing.Point(13, 332)
        Me.lblStatus.Name = "lblStatus"
        Me.lblStatus.Size = New System.Drawing.Size(42, 13)
        Me.lblStatus.TabIndex = 11
        Me.lblStatus.Text = "Stat&us:"
        '
        'txtCapacidad
        '
        Me.txtCapacidad.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtCapacidad.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtCapacidad.ForeColor = System.Drawing.Color.Black
        Me.txtCapacidad.Location = New System.Drawing.Point(104, 104)
        Me.txtCapacidad.MaxLength = 10
        Me.txtCapacidad.Name = "txtCapacidad"
        Me.txtCapacidad.Size = New System.Drawing.Size(136, 21)
        Me.txtCapacidad.TabIndex = 4
        '
        'txtPlacas
        '
        Me.txtPlacas.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtPlacas.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtPlacas.ForeColor = System.Drawing.Color.Black
        Me.txtPlacas.Location = New System.Drawing.Point(104, 132)
        Me.txtPlacas.MaxLength = 20
        Me.txtPlacas.Name = "txtPlacas"
        Me.txtPlacas.Size = New System.Drawing.Size(136, 21)
        Me.txtPlacas.TabIndex = 5
        '
        'cboTipo
        '
        Me.cboTipo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboTipo.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboTipo.Location = New System.Drawing.Point(104, 160)
        Me.cboTipo.Name = "cboTipo"
        Me.cboTipo.Size = New System.Drawing.Size(136, 21)
        Me.cboTipo.TabIndex = 6
        '
        'cboMarca
        '
        Me.cboMarca.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboMarca.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboMarca.Location = New System.Drawing.Point(104, 188)
        Me.cboMarca.Name = "cboMarca"
        Me.cboMarca.Size = New System.Drawing.Size(136, 21)
        Me.cboMarca.TabIndex = 7
        '
        'cboProducto
        '
        Me.cboProducto.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboProducto.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboProducto.Location = New System.Drawing.Point(104, 216)
        Me.cboProducto.Name = "cboProducto"
        Me.cboProducto.Size = New System.Drawing.Size(136, 21)
        Me.cboProducto.TabIndex = 8
        '
        'cboPropietario
        '
        Me.cboPropietario.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboPropietario.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboPropietario.Location = New System.Drawing.Point(104, 244)
        Me.cboPropietario.Name = "cboPropietario"
        Me.cboPropietario.Size = New System.Drawing.Size(136, 21)
        Me.cboPropietario.TabIndex = 9
        '
        'txtTransponder
        '
        Me.txtTransponder.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtTransponder.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtTransponder.ForeColor = System.Drawing.Color.Black
        Me.txtTransponder.Location = New System.Drawing.Point(104, 272)
        Me.txtTransponder.MaxLength = 20
        Me.txtTransponder.Name = "txtTransponder"
        Me.txtTransponder.Size = New System.Drawing.Size(136, 21)
        Me.txtTransponder.TabIndex = 10
        '
        'txtGPS
        '
        Me.txtGPS.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtGPS.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtGPS.ForeColor = System.Drawing.Color.Black
        Me.txtGPS.Location = New System.Drawing.Point(104, 300)
        Me.txtGPS.MaxLength = 3
        Me.txtGPS.Name = "txtGPS"
        Me.txtGPS.Size = New System.Drawing.Size(136, 21)
        Me.txtGPS.TabIndex = 11
        '
        'cboStatus
        '
        Me.cboStatus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboStatus.Enabled = False
        Me.cboStatus.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboStatus.Items.AddRange(New Object() {"ACTIVO", "INACTIVO"})
        Me.cboStatus.Location = New System.Drawing.Point(104, 328)
        Me.cboStatus.Name = "cboStatus"
        Me.cboStatus.Size = New System.Drawing.Size(136, 21)
        Me.cboStatus.TabIndex = 12
        '
        'cboRuta
        '
        Me.cboRuta.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboRuta.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboRuta.Location = New System.Drawing.Point(104, 76)
        Me.cboRuta.Name = "cboRuta"
        Me.cboRuta.Size = New System.Drawing.Size(136, 21)
        Me.cboRuta.TabIndex = 3
        '
        'lblPesadoAutomatico
        '
        Me.lblPesadoAutomatico.AutoSize = True
        Me.lblPesadoAutomatico.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblPesadoAutomatico.ForeColor = System.Drawing.Color.Black
        Me.lblPesadoAutomatico.Location = New System.Drawing.Point(14, 577)
        Me.lblPesadoAutomatico.Name = "lblPesadoAutomatico"
        Me.lblPesadoAutomatico.Size = New System.Drawing.Size(103, 13)
        Me.lblPesadoAutomatico.TabIndex = 23
        Me.lblPesadoAutomatico.Text = "Pesado Automatico:"
        Me.lblPesadoAutomatico.Visible = False
        '
        'frmCapturaAutotanque
        '
        Me.AcceptButton = Me.btnAceptar
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 14)
        Me.BackColor = System.Drawing.Color.Gainsboro
        Me.CancelButton = Me.btnCancelar
        Me.ClientSize = New System.Drawing.Size(354, 693)
        Me.Controls.Add(Me.rgrpDatos)
        Me.Controls.Add(Me.btnCancelar)
        Me.Controls.Add(Me.btnAceptar)
        Me.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmCapturaAutotanque"
        Me.Padding = New System.Windows.Forms.Padding(3)
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.rgrpDatos.ResumeLayout(False)
        Me.rgrpDatos.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

#End Region

#Region "Variables globales"
    Private Ruta As Integer
#End Region

#Region "Manejo de datos"
    Private Sub CargaDatosAutotanque()
        Dim cmdLogistica As New SqlCommand("Select * from vwDatosAutotanque where Autotanque = @Autotanque", cnSigamet)
        Dim rdrLogistica As SqlDataReader
        'Carga de parámetros
        cmdLogistica.Parameters.Add("@Autotanque", SqlDbType.Int).Value = CInt(txtAutotanque.Text)
        Try
            cnSigamet.Open()
            rdrLogistica = cmdLogistica.ExecuteReader
            If rdrLogistica.Read Then
                Ruta = CInt(rdrLogistica("Ruta"))
                'TEXIS() 
                If Ruta = 0 Then
                    cboRuta.SelectedIndex = -1
                    cboRuta.SelectedIndex = -1
                Else
                    cboRuta.SelectedValue = Ruta
                End If

                txtCapacidad.Text = CStr(rdrLogistica("Capacidad"))
                txtPlacas.Text = CStr(rdrLogistica("Placas"))
                cboTipo.SelectedValue = rdrLogistica("TipoVehiculo")
                cboMarca.SelectedValue = rdrLogistica("MarcaAutotanque")
                cboProducto.SelectedValue = rdrLogistica("TipoProducto")
                cboPropietario.SelectedValue = rdrLogistica("Propietario")
                txtTransponder.Text = CStr(rdrLogistica("Transponder"))
                txtGPS.Text = CStr(rdrLogistica("GPS"))

                chkPesadoAutomatico.Checked = Convert.ToBoolean(rdrLogistica("PesoAutomatico"))                
                chkFactorDensidadMasico.Checked = Convert.ToBoolean(rdrLogistica("FactorDensidadMasico"))
                chkBoletinenLinea.Checked = Convert.ToBoolean(rdrLogistica("BoletinEnLinea"))



                If IsDBNull(rdrLogistica("PorcentajeInventario")) Then
                    txtPorcentajeInventario.Text = ""
                Else
                    txtPorcentajeInventario.Text = CStr(rdrLogistica("PorcentajeInventario"))
                End If

                If IsDBNull(rdrLogistica("UmbralRelleno")) Then
                    txtUmbralRelleno.Text = ""
                Else
                    txtUmbralRelleno.Text = CStr(rdrLogistica("UmbralRelleno"))
                End If


                If CStr(rdrLogistica("Status")).Trim.ToUpper = "ACTIVO" Then
                    cboStatus.SelectedIndex = 0
                Else
                    cboStatus.SelectedIndex = 1
                End If
                txtCalibracion.Text = CStr(rdrLogistica("Calibracion"))
                txtCalibracionPorcentaje.Text = CStr(rdrLogistica("CalibracionPorcentaje"))

                If CType(rdrLogistica("TipoMedidor"), String).Trim.ToUpper = "" Then
                    cboTipoMedidor.SelectedIndex = -1
                    cboTipoMedidor.SelectedIndex = -1
                ElseIf CType(rdrLogistica("TipoMedidor"), String).Trim.ToUpper = "R" Then
                    cboTipoMedidor.SelectedIndex = 0
                ElseIf CType(rdrLogistica("TipoMedidor"), String).Trim.ToUpper = "M" Then
                    cboTipoMedidor.SelectedIndex = 1
                End If

                txtFactor.Text = CStr(rdrLogistica("Factor"))                
                txtUsuarioMovil.Text = CStr(rdrLogistica("UsuarioMovil"))
                If (IsDBNull(rdrLogistica("VerificaDescarga"))) Then
                    ''no hacer nada
                Else
                    chxVerificaDescargaRI.Checked = Boolean.Parse(CStr(rdrLogistica("VerificaDescarga")))
                End If

                If (IsDBNull(rdrLogistica("FactorPorcentaje"))) Then
                    ''no hacer nada
                Else
                    txtFactorPorcentaje.Text = CStr(rdrLogistica("FactorPorcentaje"))
                End If


            End If
            rdrLogistica.Close()
        Catch ex As Exception
            ExMessage(ex)
        Finally
            cnSigamet.Close()
            cmdLogistica.Dispose()
        End Try
    End Sub
    Private Sub cboCelula_SelectedValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboCelula.SelectedValueChanged
        If Not cboCelula.SelectedValue Is Nothing Then
            Dim cmdRuta As New SqlCommand("spLogCat_Rutas", cnSigamet)
            'Dim daLogistica As New SqlDataAdapter("Select Ruta, Descripcion from Ruta where Celula = @Celula", cnSigamet)
            cmdRuta.CommandType = CommandType.StoredProcedure
            cmdRuta.Parameters.Add("@Celula", SqlDbType.TinyInt).Value = CInt(cboCelula.SelectedValue)
            Dim daLogistica As New SqlDataAdapter(cmdRuta)            
            Dim dtRuta As New DataTable()
            'daLogistica.SelectCommand.Parameters.Add("@Celula", SqlDbType.TinyInt).Value = CInt(cboCelula.SelectedValue)
            Try
                daLogistica.Fill(dtRuta)
                cboRuta.ValueMember = "Ruta"
                cboRuta.DisplayMember = "Descripcion"
                cboRuta.DataSource = dtRuta

                If Ruta = 0 Then
                    cboRuta.SelectedIndex = -1
                    cboRuta.SelectedIndex = -1
                Else
                    cboRuta.SelectedValue = Ruta
                End If
            Catch ex As Exception
                ExMessage(ex)
            Finally
                daLogistica.Dispose()
            End Try
        End If
    End Sub
#End Region

#Region "Botones"
    Private Sub btnCancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancelar.Click
        Me.Close()
        Me.Dispose()
    End Sub
    Private Sub btnAceptar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAceptar.Click
        Dim cmdLogistica As SqlCommand
        'Validaciones
        If Trim(txtAutotanque.Text) = "" Then
            ErrMessage("No ha proporcionado el número de autotanque.")
            txtAutotanque.Focus()
            Exit Sub
        End If
        If Trim(txtCapacidad.Text) = "" Then
            txtCapacidad.Text = "0"
        End If
        If Trim(txtGPS.Text) = "" Then
            txtGPS.Text = "0"
        End If
        If Trim(txtCapacidad.Text) = "" Then
            txtCapacidad.Text = "0"
        End If
        If Val(txtCapacidad.Text) > 2147483647 Then
            ErrMessage("La capacidad del autotanque debe ser menor a 2147483648.")
            txtCapacidad.Clear()
            txtCapacidad.Focus()
            Exit Sub
        End If
        If Val(txtGPS.Text) > 255 Then
            ErrMessage("El número de GPS debe ser menor a 256.")
            txtGPS.Clear()
            txtGPS.Focus()
            Exit Sub
        End If

        If RTrim(cboTipo.Text) = "AUTOTANQUE" Or RTrim(cboProducto.Text = "GAS LP") Then
            If Val(txtCalibracion.Text) < _CalibracionMinima OrElse Val(txtCalibracion.Text) > _CalibracionMaxima Then
                ErrMessage("La calibración está fuera del intervalo (" & _CalibracionMinima.ToString() & ", " & _CalibracionMaxima.ToString() & ")")
                txtCalibracion.Clear()
                txtCalibracion.Focus()
                Exit Sub
            End If
            If Val(txtCalibracionPorcentaje.Text) < _CalibracionMinima OrElse Val(txtCalibracionPorcentaje.Text) > _CalibracionMaxima Then
                ErrMessage("La calibración está fuera del intervalo (" & _CalibracionMinima.ToString() & ", " & _CalibracionMaxima.ToString() & ")")
                txtCalibracionPorcentaje.Clear()
                txtCalibracionPorcentaje.Focus()
                Exit Sub
            End If

            If OperacionLogistica(16).Habilitada Then
                If Trim(txtPorcentajeInventario.Text) = "" OrElse Val(txtPorcentajeInventario.Text) < 20 OrElse Val(txtPorcentajeInventario.Text) > 95 Then
                    ErrMessage("El porcentaje está fuera del intervalo (20, 95)")
                    txtPorcentajeInventario.Clear()
                    txtPorcentajeInventario.Focus()
                    Exit Sub
                End If

                If Trim(txtUmbralRelleno.Text) = "" OrElse Val(txtUmbralRelleno.Text) < 0 OrElse Val(txtUmbralRelleno.Text) > 10 Then
                    ErrMessage("El umbral de relleno está fuera del intervalo (0, 10)")
                    txtUmbralRelleno.Clear()
                    txtUmbralRelleno.Focus()
                    Exit Sub
                End If

                If Trim(txtUmbralRelleno.Text) > Trim(txtPorcentajeInventario.Text) Then
                    ErrMessage("El umbral de relleno debe ser menor al porcentaje de inventario.")
                    txtUmbralRelleno.Clear()
                    txtUmbralRelleno.Focus()
                    Exit Sub
                End If
            End If
        End If

        If (txtFactorPorcentaje.Text.Length > 0) Then
            If (Decimal.Parse(txtFactorPorcentaje.Text) > 100) Then
                ErrMessage("El factor de porcentaje no puede ser mayor a 100%.")
                txtFactorPorcentaje.Clear()
                txtFactorPorcentaje.Focus()
                Exit Sub
            End If
        End If

        Me.Cursor = Cursors.WaitCursor
        cmdLogistica = New SqlCommand("spLOGAutotanque", cnSigamet)

        ' Asignación de parámetros
        cmdLogistica.CommandType = CommandType.StoredProcedure
        cmdLogistica.Parameters.Add("@Autotanque", SqlDbType.SmallInt).Value = CInt(txtAutotanque.Text)
        cmdLogistica.Parameters.Add("@Capacidad", SqlDbType.Int).Value = CInt(txtCapacidad.Text)

        'TEXIS'
        If IsNothing(cboRuta.SelectedValue) Then
            cmdLogistica.Parameters.Add("@Ruta", SqlDbType.SmallInt).Value = 0
        Else
            cmdLogistica.Parameters.Add("@Ruta", SqlDbType.SmallInt).Value = CInt(cboRuta.SelectedValue)
        End If
        ''
        cmdLogistica.Parameters.Add("@GPS", SqlDbType.TinyInt).Value = IIf(txtGPS.Text.Length > 0, CInt(txtGPS.Text), 0)
        cmdLogistica.Parameters.Add("@Placas", SqlDbType.Char).Value = txtPlacas.Text
        cmdLogistica.Parameters.Add("@Marca", SqlDbType.TinyInt).Value = CInt(cboMarca.SelectedValue)
        cmdLogistica.Parameters.Add("@Tipo", SqlDbType.TinyInt).Value = CInt(cboTipo.SelectedValue)
        cmdLogistica.Parameters.Add("@Propietario", SqlDbType.SmallInt).Value = CInt(cboPropietario.SelectedValue)
        cmdLogistica.Parameters.Add("@Producto", SqlDbType.TinyInt).Value = CInt(cboProducto.SelectedValue)
        cmdLogistica.Parameters.Add("@Transponder", SqlDbType.Char).Value = txtTransponder.Text
        cmdLogistica.Parameters.Add("@Celula", SqlDbType.TinyInt).Value = CInt(cboCelula.SelectedValue)
        cmdLogistica.Parameters.Add("@Status", SqlDbType.Char).Value = cboStatus.Text
        cmdLogistica.Parameters.Add("@Nuevo", SqlDbType.Bit).Value = (Me.Text = "Nuevo autotanque")
        cmdLogistica.Parameters.Add("@BoletinEnLinea", SqlDbType.Bit).Value = Val(chkBoletinenLinea.Checked)
        cmdLogistica.Parameters.Add("@UsuarioModificacion", SqlDbType.VarChar).Value = Globales._Usuario


        If (txtCalibracion.Text.ToString().Trim.Length) > 0 Then
            cmdLogistica.Parameters.Add("@Calibracion", SqlDbType.Decimal).Value = Val(txtCalibracion.Text)
        Else
            cmdLogistica.Parameters.Add("@Calibracion", SqlDbType.Decimal).Value = System.DBNull.Value
        End If


        If (txtCalibracionPorcentaje.Text.ToString().Trim.Length) > 0 Then
            cmdLogistica.Parameters.Add("@CalibracionPorcentaje", SqlDbType.Decimal).Value = Val(txtCalibracionPorcentaje.Text)
        Else
            cmdLogistica.Parameters.Add("@CalibracionPorcentaje", SqlDbType.Decimal).Value = System.DBNull.Value
        End If


        If (txtPorcentajeInventario.Text.ToString().Trim.Length) > 0 Then
            cmdLogistica.Parameters.Add("@PorcentajeInventario", SqlDbType.TinyInt).Value = Val(txtPorcentajeInventario.Text)
        Else
            cmdLogistica.Parameters.Add("@PorcentajeInventario", SqlDbType.TinyInt).Value = System.DBNull.Value
        End If


        If (txtUmbralRelleno.Text.ToString().Trim.Length) > 0 Then
            cmdLogistica.Parameters.Add("@UmbralRelleno", SqlDbType.TinyInt).Value = Val(txtUmbralRelleno.Text)
        Else
            cmdLogistica.Parameters.Add("@UmbralRelleno", SqlDbType.TinyInt).Value = System.DBNull.Value
        End If


        If (chkPesadoAutomatico.Visible = True) Then
            cmdLogistica.Parameters.Add("@PesoAutomatico", SqlDbType.Bit).Value = Val(chkPesadoAutomatico.Checked)
        Else
            cmdLogistica.Parameters.Add("@PesoAutomatico", SqlDbType.Bit).Value = System.DBNull.Value
        End If


        If (chkFactorDensidadMasico.Visible = True) Then
            cmdLogistica.Parameters.Add("@FactorDensidadMasico", SqlDbType.Bit).Value = Val(chkFactorDensidadMasico.Checked)
        Else
            cmdLogistica.Parameters.Add("@FactorDensidadMasico", SqlDbType.Bit).Value = System.DBNull.Value
        End If


        cmdLogistica.Parameters.Add("@Factor", SqlDbType.Char).Value = txtFactor.Text


        If (txtFactorPorcentaje.Text.ToString().Trim.Length) > 0 Then
            cmdLogistica.Parameters.Add("@FactorPorcentaje", SqlDbType.Decimal).Value = Decimal.Parse(txtFactorPorcentaje.Text)
        Else
            cmdLogistica.Parameters.Add("@FactorPorcentaje", SqlDbType.Decimal).Value = System.DBNull.Value
        End If





        If cboTipoMedidor.SelectedIndex < 0 Then
            cmdLogistica.Parameters.Add("@TipoMedidor", SqlDbType.Char).Value = System.DBNull.Value
        ElseIf cboTipoMedidor.SelectedIndex = 0 Then
            cmdLogistica.Parameters.Add("@TipoMedidor", SqlDbType.Char).Value = "R"
        ElseIf cboTipoMedidor.SelectedIndex = 1 Then
            cmdLogistica.Parameters.Add("@TipoMedidor", SqlDbType.Char).Value = "M"
        End If

        'LUSATE Registrar UsuarioMovil
        cmdLogistica.Parameters.Add("@UsuarioMovil", SqlDbType.VarChar).Value = txtUsuarioMovil.Text
        cmdLogistica.Parameters.Add("@VerificaDescarga", SqlDbType.Bit).Value = Boolean.Parse(chxVerificaDescargaRI.Checked.ToString())


        Try
            cnSigamet.Open()
            cmdLogistica.ExecuteNonQuery()
            Me.DialogResult = DialogResult.OK
            Me.Close()
        Catch ex As Exception
            ExMessage(ex)
        Finally
            Me.Cursor = Cursors.Default
            cnSigamet.Close()
            cmdLogistica.Dispose()
        End Try
    End Sub
#End Region

#Region "Manejo de cajas de texto"
    Private Sub TextBox_Enter(ByVal sender As Object, ByVal e As EventArgs) Handles txtCapacidad.Enter, txtPlacas.Enter, txtAutotanque.Enter, txtGPS.Enter, txtTransponder.Enter, txtCalibracion.Enter, txtCalibracionPorcentaje.Enter, txtFactor.Enter
        CType(sender, TextBox).BackColor = Color.LightGoldenrodYellow
    End Sub
    Private Sub TextBox_Leave(ByVal sender As Object, ByVal e As EventArgs) Handles txtCapacidad.Leave, txtPlacas.Leave, txtAutotanque.Leave, txtGPS.Leave, txtTransponder.Leave, txtCalibracion.Leave, txtCalibracionPorcentaje.Leave, txtFactor.Leave
        CType(sender, TextBox).BackColor = Color.White
    End Sub
    Private Sub TextBox_KeyPress(ByVal sender As Object, ByVal e As KeyPressEventArgs) Handles txtAutotanque.KeyPress, txtCapacidad.KeyPress, txtGPS.KeyPress, txtTransponder.KeyPress
        If Not (Char.IsDigit(e.KeyChar) Or Asc(e.KeyChar) = 8 Or Char.IsControl(e.KeyChar)) Then
            e.Handled = True
        Else
            e.Handled = False
        End If
    End Sub
    Private Sub TextBoxDecimal_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtCalibracion.KeyPress, txtCalibracionPorcentaje.KeyPress, txtPorcentajeInventario.KeyPress, txtUmbralRelleno.KeyPress
        If Not (Char.IsDigit(e.KeyChar) OrElse Char.IsControl(e.KeyChar) OrElse Asc(e.KeyChar) = 8 OrElse _
                    (e.KeyChar = CChar(".") AndAlso CType(sender, TextBox).Text.IndexOf(".") < 0)) Then
            e.Handled = True
        Else
            e.Handled = False
        End If
    End Sub
#End Region

    'Texis '
    Private Sub frmCapturaAutotanque_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        If IsNothing(cboRuta.DataSource) = False Then
            If Ruta = 0 Then
                cboRuta.SelectedIndex = -1
                cboRuta.SelectedIndex = -1
            Else
                cboRuta.SelectedValue = Ruta
            End If
        End If
    End Sub

    'TEXIS'
    Private Sub cboRuta_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cboRuta.KeyUp
        If e.KeyCode.ToString() = "Delete" Then
            cboRuta.SelectedIndex = -1
            cboRuta.SelectedIndex = -1
        End If
    End Sub

    Private Sub chkFactorDensidadMasico_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkFactorDensidadMasico.CheckedChanged

    End Sub

    Private Sub txtPorcentajeInventario_TextChanged(sender As System.Object, e As System.EventArgs) Handles txtPorcentajeInventario.TextChanged

    End Sub

    Private Sub txtFactor_TextChanged(sender As System.Object, e As System.EventArgs) Handles txtFactor.TextChanged

    End Sub

    Private Sub txtFactorPorcentaje_KeyPress(sender As System.Object, e As System.Windows.Forms.KeyPressEventArgs) Handles txtFactorPorcentaje.KeyPress
        If Not (Char.IsDigit(e.KeyChar) OrElse Char.IsControl(e.KeyChar) OrElse Asc(e.KeyChar) = 8 OrElse _
                   (e.KeyChar = CChar(".") AndAlso CType(sender, TextBox).Text.IndexOf(".") < 0)) Then
            e.Handled = True
        Else
            e.Handled = False
        End If
    End Sub

    Private Sub txtFactorPorcentaje_TextChanged(sender As System.Object, e As System.EventArgs) Handles txtFactorPorcentaje.TextChanged
        CType(sender, TextBox).BackColor = Color.White
    End Sub

    Private Sub txtFactorPorcentaje_Enter(sender As System.Object, e As System.EventArgs) Handles txtFactorPorcentaje.Enter
        CType(sender, TextBox).BackColor = Color.LightGoldenrodYellow
    End Sub

    Private Sub lblUmbralRelleno_Click(sender As System.Object, e As System.EventArgs) Handles lblUmbralRelleno.Click

    End Sub

    Private Sub lblPorcentajeinventario_Click(sender As System.Object, e As System.EventArgs) Handles lblPorcentajeinventario.Click

    End Sub

    Private Sub lblCalibracionPorcentaje_Click(sender As System.Object, e As System.EventArgs) Handles lblCalibracionPorcentaje.Click

    End Sub

    Private Sub txtCalibracion_TextChanged(sender As System.Object, e As System.EventArgs) Handles txtCalibracion.TextChanged

    End Sub

    Private Sub lblCalibracion_Click(sender As System.Object, e As System.EventArgs) Handles lblCalibracion.Click

    End Sub

    Private Sub txtCapacidad_TextChanged(sender As System.Object, e As System.EventArgs) Handles txtCapacidad.TextChanged

    End Sub
End Class
