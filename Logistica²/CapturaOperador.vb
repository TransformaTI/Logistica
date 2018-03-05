Imports System
Imports System.Data
Imports System.Data.SqlClient

Public Class frmCapturaOperador
    Inherits System.Windows.Forms.Form


#Region " Windows Form Designer generated code "

    Public Sub New(ByVal Celula As Integer, Optional ByVal Operador As Integer = 0)
        MyBase.New()

        'This call is required by the Windows Form Designer.
        InitializeComponent()

        'Add any initialization after the InitializeComponent() call
        Dim cmdLogistica As New SqlCommand("Select * from CategoriaOperador where Supervisor = 0", cnSigamet)
        Dim daLogistica As New SqlDataAdapter(cmdLogistica)
        'Tablas para datos en combos
        Dim dtCategoria As New DataTable()
        Dim dtTipo As New DataTable()
        Dim dtCelula As New DataTable()
        Dim dtClasificacion As New DataTable()
        cmdLogistica.Parameters.Add("@Usuario", SqlDbType.Char).Value = _Usuario
        Try
            'Llenado de tablas
            daLogistica.Fill(dtCategoria)
            cmdLogistica.CommandText = "Select * from TipoOperador"
            daLogistica.Fill(dtTipo)
            cmdLogistica.CommandText = "Select Celula, Descripcion from Celula where Comercial = 1 and Celula in (Select Celula from UsuarioCelula " _
                    & " where Usuario = @Usuario)"
            daLogistica.Fill(dtCelula)
            cmdLogistica.CommandText = "Select * from ClasificacionOperador"
            daLogistica.Fill(dtClasificacion)
        Catch ex As Exception
            ExMessage(ex)
        End Try
        'Llenado de combos
        cboCategoria.ValueMember = "CategoriaOperador"
        cboCategoria.DisplayMember = "Descripcion"
        cboCategoria.DataSource = dtCategoria

        cboTipo.ValueMember = "TipoOperador"
        cboTipo.DisplayMember = "Descripcion"
        cboTipo.DataSource = dtTipo

        cboCelula.ValueMember = "Celula"
        cboCelula.DisplayMember = "Descripcion"
        cboCelula.DataSource = dtCelula

        cboClasificacion.ValueMember = "ClasificacionOperador"
        cboClasificacion.DisplayMember = "Descripcion"
        cboClasificacion.DataSource = dtClasificacion

        'Parametros de default
        Application.DoEvents()
        cboCelula.SelectedValue = Celula

        'Limpiado de memoria
        cmdLogistica.Dispose()
        daLogistica.Dispose()
        
        'Nuevo/Modificación
        Me.Text = "Nuevo operador"
        If Operador > 0 Then
            Me.Text = "Modificación de operador"
            txtEmpleado.Text = Operador.ToString
            txtEmpleado.ReadOnly = True
            txtNombre.ReadOnly = True
            txtEmpleado.TabStop = False
            txtNombre.TabStop = False
            cboCategoria.Focus()
            CargaDatosOperador()
        End If

        txtLitrosCredito.ReadOnly = Not OperacionLogistica(13).Habilitada
        txtEmpleado.ReadOnly = Not OperacionLogistica(4).Habilitada
        txtNombre.ReadOnly = Not OperacionLogistica(4).Habilitada
        txtNotas.ReadOnly = Not OperacionLogistica(4).Habilitada
        cboCategoria.Enabled = OperacionLogistica(4).Habilitada
        cboCelula.Enabled = OperacionLogistica(4).Habilitada
        cboClasificacion.Enabled = OperacionLogistica(4).Habilitada
        cboRuta.Enabled = OperacionLogistica(4).Habilitada
        cboTipo.Enabled = OperacionLogistica(4).Habilitada
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
    Friend WithEvents btnAceptar As Windows.Forms.Button
    Friend WithEvents btnCancelar As Windows.Forms.Button
    Friend WithEvents rgrpDatos As Logistica.RoundedGroupBox
    Friend WithEvents lblNombre As System.Windows.Forms.Label
    Friend WithEvents cboTipo As System.Windows.Forms.ComboBox
    Friend WithEvents lblTipo As System.Windows.Forms.Label
    Friend WithEvents cboCategoria As System.Windows.Forms.ComboBox
    Friend WithEvents lblEmpleado As System.Windows.Forms.Label
    Friend WithEvents lblCelula As System.Windows.Forms.Label
    Friend WithEvents lblCategoria As System.Windows.Forms.Label
    Friend WithEvents lblNotas As System.Windows.Forms.Label
    Friend WithEvents txtNotas As Windows.Forms.TextBox
    Friend WithEvents txtEmpleado As Windows.Forms.TextBox
    Friend WithEvents cboCelula As System.Windows.Forms.ComboBox
    Friend WithEvents txtNombre As Windows.Forms.TextBox
    Friend WithEvents cboClasificacion As System.Windows.Forms.ComboBox
    Friend WithEvents lblClasificacion As System.Windows.Forms.Label
    Friend WithEvents lblRuta As System.Windows.Forms.Label
    Friend WithEvents cboRuta As System.Windows.Forms.ComboBox
    Friend WithEvents lblLitrosCredito As System.Windows.Forms.Label
    Friend WithEvents txtLitrosCredito As System.Windows.Forms.TextBox
    Friend WithEvents lblCelular As System.Windows.Forms.Label
    Friend WithEvents txtCelular As System.Windows.Forms.TextBox
    Friend WithEvents lblLicencia As System.Windows.Forms.Label
    Friend WithEvents chkPreasignado As System.Windows.Forms.CheckBox
    Friend WithEvents lblPreasignado As System.Windows.Forms.Label
    Friend WithEvents txtLicencia As System.Windows.Forms.TextBox
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmCapturaOperador))
        Me.btnAceptar = New System.Windows.Forms.Button()
        Me.btnCancelar = New System.Windows.Forms.Button()
        Me.rgrpDatos = New Logistica.RoundedGroupBox()
        Me.lblPreasignado = New System.Windows.Forms.Label()
        Me.chkPreasignado = New System.Windows.Forms.CheckBox()
        Me.txtLicencia = New System.Windows.Forms.TextBox()
        Me.lblLicencia = New System.Windows.Forms.Label()
        Me.txtCelular = New System.Windows.Forms.TextBox()
        Me.lblCelular = New System.Windows.Forms.Label()
        Me.lblLitrosCredito = New System.Windows.Forms.Label()
        Me.txtLitrosCredito = New System.Windows.Forms.TextBox()
        Me.cboRuta = New System.Windows.Forms.ComboBox()
        Me.lblRuta = New System.Windows.Forms.Label()
        Me.cboClasificacion = New System.Windows.Forms.ComboBox()
        Me.lblClasificacion = New System.Windows.Forms.Label()
        Me.lblNombre = New System.Windows.Forms.Label()
        Me.cboTipo = New System.Windows.Forms.ComboBox()
        Me.lblTipo = New System.Windows.Forms.Label()
        Me.cboCategoria = New System.Windows.Forms.ComboBox()
        Me.lblEmpleado = New System.Windows.Forms.Label()
        Me.lblCelula = New System.Windows.Forms.Label()
        Me.lblCategoria = New System.Windows.Forms.Label()
        Me.lblNotas = New System.Windows.Forms.Label()
        Me.txtNotas = New System.Windows.Forms.TextBox()
        Me.txtEmpleado = New System.Windows.Forms.TextBox()
        Me.cboCelula = New System.Windows.Forms.ComboBox()
        Me.txtNombre = New System.Windows.Forms.TextBox()
        Me.rgrpDatos.SuspendLayout()
        Me.SuspendLayout()
        '
        'btnAceptar
        '
        Me.btnAceptar.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnAceptar.Image = CType(resources.GetObject("btnAceptar.Image"), System.Drawing.Image)
        Me.btnAceptar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnAceptar.Location = New System.Drawing.Point(327, 12)
        Me.btnAceptar.Name = "btnAceptar"
        Me.btnAceptar.Size = New System.Drawing.Size(75, 24)
        Me.btnAceptar.TabIndex = 1
        Me.btnAceptar.Text = "&Aceptar"
        Me.btnAceptar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'btnCancelar
        '
        Me.btnCancelar.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnCancelar.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnCancelar.Image = CType(resources.GetObject("btnCancelar.Image"), System.Drawing.Image)
        Me.btnCancelar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnCancelar.Location = New System.Drawing.Point(327, 48)
        Me.btnCancelar.Name = "btnCancelar"
        Me.btnCancelar.Size = New System.Drawing.Size(75, 24)
        Me.btnCancelar.TabIndex = 2
        Me.btnCancelar.Text = "&Cancelar"
        Me.btnCancelar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'rgrpDatos
        '
        Me.rgrpDatos.BorderColor = System.Drawing.Color.SteelBlue
        Me.rgrpDatos.Controls.Add(Me.lblPreasignado)
        Me.rgrpDatos.Controls.Add(Me.chkPreasignado)
        Me.rgrpDatos.Controls.Add(Me.txtLicencia)
        Me.rgrpDatos.Controls.Add(Me.lblLicencia)
        Me.rgrpDatos.Controls.Add(Me.txtCelular)
        Me.rgrpDatos.Controls.Add(Me.lblCelular)
        Me.rgrpDatos.Controls.Add(Me.lblLitrosCredito)
        Me.rgrpDatos.Controls.Add(Me.txtLitrosCredito)
        Me.rgrpDatos.Controls.Add(Me.cboRuta)
        Me.rgrpDatos.Controls.Add(Me.lblRuta)
        Me.rgrpDatos.Controls.Add(Me.cboClasificacion)
        Me.rgrpDatos.Controls.Add(Me.lblClasificacion)
        Me.rgrpDatos.Controls.Add(Me.lblNombre)
        Me.rgrpDatos.Controls.Add(Me.cboTipo)
        Me.rgrpDatos.Controls.Add(Me.lblTipo)
        Me.rgrpDatos.Controls.Add(Me.cboCategoria)
        Me.rgrpDatos.Controls.Add(Me.lblEmpleado)
        Me.rgrpDatos.Controls.Add(Me.lblCelula)
        Me.rgrpDatos.Controls.Add(Me.lblCategoria)
        Me.rgrpDatos.Controls.Add(Me.lblNotas)
        Me.rgrpDatos.Controls.Add(Me.txtNotas)
        Me.rgrpDatos.Controls.Add(Me.txtEmpleado)
        Me.rgrpDatos.Controls.Add(Me.cboCelula)
        Me.rgrpDatos.Controls.Add(Me.txtNombre)
        Me.rgrpDatos.Dock = System.Windows.Forms.DockStyle.Left
        Me.rgrpDatos.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rgrpDatos.ForeColor = System.Drawing.Color.DarkBlue
        Me.rgrpDatos.Location = New System.Drawing.Point(3, 0)
        Me.rgrpDatos.Name = "rgrpDatos"
        Me.rgrpDatos.Size = New System.Drawing.Size(306, 380)
        Me.rgrpDatos.TabIndex = 0
        Me.rgrpDatos.TabStop = False
        Me.rgrpDatos.Text = "Datos del operador"
        Me.rgrpDatos.TextAlignment = System.Windows.Forms.HorizontalAlignment.Center
        '
        'lblPreasignado
        '
        Me.lblPreasignado.AutoSize = True
        Me.lblPreasignado.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblPreasignado.ForeColor = System.Drawing.Color.Black
        Me.lblPreasignado.Location = New System.Drawing.Point(12, 354)
        Me.lblPreasignado.Name = "lblPreasignado"
        Me.lblPreasignado.Size = New System.Drawing.Size(73, 13)
        Me.lblPreasignado.TabIndex = 23
        Me.lblPreasignado.Text = "Preasignado :"
        '
        'chkPreasignado
        '
        Me.chkPreasignado.ForeColor = System.Drawing.SystemColors.Desktop
        Me.chkPreasignado.Location = New System.Drawing.Point(102, 348)
        Me.chkPreasignado.Name = "chkPreasignado"
        Me.chkPreasignado.Size = New System.Drawing.Size(18, 24)
        Me.chkPreasignado.TabIndex = 22
        '
        'txtLicencia
        '
        Me.txtLicencia.BackColor = System.Drawing.Color.White
        Me.txtLicencia.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtLicencia.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtLicencia.ForeColor = System.Drawing.Color.Black
        Me.txtLicencia.Location = New System.Drawing.Point(102, 318)
        Me.txtLicencia.MaxLength = 20
        Me.txtLicencia.Name = "txtLicencia"
        Me.txtLicencia.Size = New System.Drawing.Size(90, 21)
        Me.txtLicencia.TabIndex = 21
        Me.txtLicencia.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'lblLicencia
        '
        Me.lblLicencia.AutoSize = True
        Me.lblLicencia.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblLicencia.ForeColor = System.Drawing.Color.Black
        Me.lblLicencia.Location = New System.Drawing.Point(12, 324)
        Me.lblLicencia.Name = "lblLicencia"
        Me.lblLicencia.Size = New System.Drawing.Size(51, 13)
        Me.lblLicencia.TabIndex = 20
        Me.lblLicencia.Text = "Licencia :"
        '
        'txtCelular
        '
        Me.txtCelular.BackColor = System.Drawing.Color.White
        Me.txtCelular.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtCelular.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtCelular.ForeColor = System.Drawing.Color.Black
        Me.txtCelular.Location = New System.Drawing.Point(102, 288)
        Me.txtCelular.MaxLength = 20
        Me.txtCelular.Name = "txtCelular"
        Me.txtCelular.Size = New System.Drawing.Size(90, 21)
        Me.txtCelular.TabIndex = 19
        Me.txtCelular.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'lblCelular
        '
        Me.lblCelular.AutoSize = True
        Me.lblCelular.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCelular.ForeColor = System.Drawing.Color.Black
        Me.lblCelular.Location = New System.Drawing.Point(12, 294)
        Me.lblCelular.Name = "lblCelular"
        Me.lblCelular.Size = New System.Drawing.Size(47, 13)
        Me.lblCelular.TabIndex = 18
        Me.lblCelular.Text = "Celular :"
        '
        'lblLitrosCredito
        '
        Me.lblLitrosCredito.AutoSize = True
        Me.lblLitrosCredito.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblLitrosCredito.ForeColor = System.Drawing.Color.Black
        Me.lblLitrosCredito.Location = New System.Drawing.Point(12, 260)
        Me.lblLitrosCredito.Name = "lblLitrosCredito"
        Me.lblLitrosCredito.Size = New System.Drawing.Size(82, 13)
        Me.lblLitrosCredito.TabIndex = 16
        Me.lblLitrosCredito.Text = "&Litros a crédito:"
        '
        'txtLitrosCredito
        '
        Me.txtLitrosCredito.BackColor = System.Drawing.Color.White
        Me.txtLitrosCredito.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtLitrosCredito.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtLitrosCredito.ForeColor = System.Drawing.Color.Black
        Me.txtLitrosCredito.Location = New System.Drawing.Point(104, 257)
        Me.txtLitrosCredito.MaxLength = 8
        Me.txtLitrosCredito.Name = "txtLitrosCredito"
        Me.txtLitrosCredito.Size = New System.Drawing.Size(88, 21)
        Me.txtLitrosCredito.TabIndex = 17
        Me.txtLitrosCredito.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'cboRuta
        '
        Me.cboRuta.BackColor = System.Drawing.Color.White
        Me.cboRuta.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboRuta.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboRuta.ForeColor = System.Drawing.Color.Black
        Me.cboRuta.Location = New System.Drawing.Point(104, 197)
        Me.cboRuta.MaxDropDownItems = 30
        Me.cboRuta.Name = "cboRuta"
        Me.cboRuta.Size = New System.Drawing.Size(192, 21)
        Me.cboRuta.TabIndex = 15
        '
        'lblRuta
        '
        Me.lblRuta.AutoSize = True
        Me.lblRuta.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblRuta.ForeColor = System.Drawing.Color.Black
        Me.lblRuta.Location = New System.Drawing.Point(12, 200)
        Me.lblRuta.Name = "lblRuta"
        Me.lblRuta.Size = New System.Drawing.Size(34, 13)
        Me.lblRuta.TabIndex = 14
        Me.lblRuta.Text = "&Ruta:"
        '
        'cboClasificacion
        '
        Me.cboClasificacion.BackColor = System.Drawing.Color.White
        Me.cboClasificacion.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboClasificacion.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboClasificacion.ForeColor = System.Drawing.Color.Black
        Me.cboClasificacion.Location = New System.Drawing.Point(103, 138)
        Me.cboClasificacion.Name = "cboClasificacion"
        Me.cboClasificacion.Size = New System.Drawing.Size(192, 21)
        Me.cboClasificacion.TabIndex = 9
        '
        'lblClasificacion
        '
        Me.lblClasificacion.AutoSize = True
        Me.lblClasificacion.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblClasificacion.ForeColor = System.Drawing.Color.Black
        Me.lblClasificacion.Location = New System.Drawing.Point(13, 141)
        Me.lblClasificacion.Name = "lblClasificacion"
        Me.lblClasificacion.Size = New System.Drawing.Size(79, 13)
        Me.lblClasificacion.TabIndex = 8
        Me.lblClasificacion.Text = "&Clasificación:"
        '
        'lblNombre
        '
        Me.lblNombre.AutoSize = True
        Me.lblNombre.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblNombre.ForeColor = System.Drawing.Color.Black
        Me.lblNombre.Location = New System.Drawing.Point(12, 54)
        Me.lblNombre.Name = "lblNombre"
        Me.lblNombre.Size = New System.Drawing.Size(54, 13)
        Me.lblNombre.TabIndex = 2
        Me.lblNombre.Text = "&Nombre:"
        '
        'cboTipo
        '
        Me.cboTipo.BackColor = System.Drawing.Color.White
        Me.cboTipo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboTipo.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboTipo.ForeColor = System.Drawing.Color.Black
        Me.cboTipo.Location = New System.Drawing.Point(104, 109)
        Me.cboTipo.Name = "cboTipo"
        Me.cboTipo.Size = New System.Drawing.Size(192, 21)
        Me.cboTipo.TabIndex = 7
        '
        'lblTipo
        '
        Me.lblTipo.AutoSize = True
        Me.lblTipo.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTipo.ForeColor = System.Drawing.Color.Black
        Me.lblTipo.Location = New System.Drawing.Point(12, 112)
        Me.lblTipo.Name = "lblTipo"
        Me.lblTipo.Size = New System.Drawing.Size(34, 13)
        Me.lblTipo.TabIndex = 6
        Me.lblTipo.Text = "&Tipo:"
        '
        'cboCategoria
        '
        Me.cboCategoria.BackColor = System.Drawing.Color.White
        Me.cboCategoria.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboCategoria.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboCategoria.ForeColor = System.Drawing.Color.Black
        Me.cboCategoria.Location = New System.Drawing.Point(104, 80)
        Me.cboCategoria.Name = "cboCategoria"
        Me.cboCategoria.Size = New System.Drawing.Size(192, 21)
        Me.cboCategoria.TabIndex = 5
        '
        'lblEmpleado
        '
        Me.lblEmpleado.AutoSize = True
        Me.lblEmpleado.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblEmpleado.ForeColor = System.Drawing.Color.Black
        Me.lblEmpleado.Location = New System.Drawing.Point(12, 25)
        Me.lblEmpleado.Name = "lblEmpleado"
        Me.lblEmpleado.Size = New System.Drawing.Size(65, 13)
        Me.lblEmpleado.TabIndex = 0
        Me.lblEmpleado.Text = "&Empleado:"
        '
        'lblCelula
        '
        Me.lblCelula.AutoSize = True
        Me.lblCelula.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCelula.ForeColor = System.Drawing.Color.Black
        Me.lblCelula.Location = New System.Drawing.Point(12, 170)
        Me.lblCelula.Name = "lblCelula"
        Me.lblCelula.Size = New System.Drawing.Size(44, 13)
        Me.lblCelula.TabIndex = 10
        Me.lblCelula.Text = "Cé&lula:"
        '
        'lblCategoria
        '
        Me.lblCategoria.AutoSize = True
        Me.lblCategoria.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCategoria.ForeColor = System.Drawing.Color.Black
        Me.lblCategoria.Location = New System.Drawing.Point(12, 83)
        Me.lblCategoria.Name = "lblCategoria"
        Me.lblCategoria.Size = New System.Drawing.Size(65, 13)
        Me.lblCategoria.TabIndex = 4
        Me.lblCategoria.Text = "Cate&goria:"
        '
        'lblNotas
        '
        Me.lblNotas.AutoSize = True
        Me.lblNotas.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblNotas.ForeColor = System.Drawing.Color.Black
        Me.lblNotas.Location = New System.Drawing.Point(12, 230)
        Me.lblNotas.Name = "lblNotas"
        Me.lblNotas.Size = New System.Drawing.Size(78, 13)
        Me.lblNotas.TabIndex = 12
        Me.lblNotas.Text = "Notas &blancas:"
        '
        'txtNotas
        '
        Me.txtNotas.BackColor = System.Drawing.Color.White
        Me.txtNotas.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtNotas.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtNotas.ForeColor = System.Drawing.Color.Black
        Me.txtNotas.Location = New System.Drawing.Point(104, 227)
        Me.txtNotas.MaxLength = 3
        Me.txtNotas.Name = "txtNotas"
        Me.txtNotas.Size = New System.Drawing.Size(88, 21)
        Me.txtNotas.TabIndex = 13
        Me.txtNotas.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtEmpleado
        '
        Me.txtEmpleado.BackColor = System.Drawing.Color.White
        Me.txtEmpleado.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtEmpleado.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtEmpleado.ForeColor = System.Drawing.Color.Black
        Me.txtEmpleado.Location = New System.Drawing.Point(104, 22)
        Me.txtEmpleado.MaxLength = 10
        Me.txtEmpleado.Name = "txtEmpleado"
        Me.txtEmpleado.Size = New System.Drawing.Size(100, 21)
        Me.txtEmpleado.TabIndex = 1
        '
        'cboCelula
        '
        Me.cboCelula.BackColor = System.Drawing.Color.White
        Me.cboCelula.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboCelula.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboCelula.ForeColor = System.Drawing.Color.Black
        Me.cboCelula.Location = New System.Drawing.Point(104, 167)
        Me.cboCelula.MaxDropDownItems = 30
        Me.cboCelula.Name = "cboCelula"
        Me.cboCelula.Size = New System.Drawing.Size(192, 21)
        Me.cboCelula.TabIndex = 11
        '
        'txtNombre
        '
        Me.txtNombre.BackColor = System.Drawing.Color.White
        Me.txtNombre.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtNombre.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtNombre.ForeColor = System.Drawing.Color.Black
        Me.txtNombre.Location = New System.Drawing.Point(104, 51)
        Me.txtNombre.MaxLength = 80
        Me.txtNombre.Name = "txtNombre"
        Me.txtNombre.Size = New System.Drawing.Size(192, 21)
        Me.txtNombre.TabIndex = 3
        '
        'frmCapturaOperador
        '
        Me.AcceptButton = Me.btnAceptar
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 14)
        Me.BackColor = System.Drawing.Color.Gainsboro
        Me.CancelButton = Me.btnCancelar
        Me.ClientSize = New System.Drawing.Size(414, 383)
        Me.Controls.Add(Me.rgrpDatos)
        Me.Controls.Add(Me.btnCancelar)
        Me.Controls.Add(Me.btnAceptar)
        Me.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmCapturaOperador"
        Me.Padding = New System.Windows.Forms.Padding(3, 0, 0, 3)
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.rgrpDatos.ResumeLayout(False)
        Me.rgrpDatos.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

#End Region

    Private RutaOperador As Integer
    'texis'
    Private AsignacionAutomatica As String = Globales._AsignacionAutomatica

#Region "Manejo de datos"
    Private Sub CargaDatosOperador()
        Dim cmdLogistica As New SqlCommand("select * from vwLOGOperador where Empleado = @Operador", cnSigamet)
        Dim rdrLogistica As SqlDataReader
        'Carga de parámetros
        cmdLogistica.Parameters.Add("@Operador", SqlDbType.Int).Value = CInt(txtEmpleado.Text)
        Try
            cnSigamet.Open()
            rdrLogistica = cmdLogistica.ExecuteReader
            If rdrLogistica.Read Then
                txtNombre.Text = Trim(CStr(rdrLogistica("Nombre")))
                cboCategoria.SelectedValue = rdrLogistica("IDCategoria")
                cboTipo.SelectedValue = rdrLogistica("IDTipo")
                cboCelula.SelectedValue = rdrLogistica("CCelula")
                txtNotas.Text = CStr(rdrLogistica("MaxNotasBlancas"))
                cboClasificacion.SelectedValue = rdrLogistica("IDClasificacion")
                cboRuta.SelectedValue = rdrLogistica("Ruta")
                RutaOperador = CInt(rdrLogistica("Ruta"))
                txtLitrosCredito.Text = Val(rdrLogistica("MaxLitrosCredito")).ToString
                'texis'
                If rdrLogistica("Celular") Is DBNull.Value Then
                    txtCelular.Text = ""
                Else
                    txtCelular.Text = CStr(rdrLogistica("Celular")).Trim()
                End If

                If rdrLogistica("Licencia") Is DBNull.Value Then
                    txtLicencia.Text = ""
                Else
                    txtLicencia.Text = CStr(rdrLogistica("Licencia")).Trim()
                End If

                If rdrLogistica("Preasignacion") Is DBNull.Value Then
                    chkPreasignado.Checked = False
                Else
                    If CBool(rdrLogistica("Preasignacion")) = True Then
                        chkPreasignado.Checked = True
                    Else
                        chkPreasignado.Checked = False
                    End If
                End If
                'texiss'
            Else

                End If
                rdrLogistica.Close()
        Catch ex As Exception
            ExMessage(ex)
        Finally
            cnSigamet.Close()
            cmdLogistica.Dispose()
        End Try
    End Sub
    Private Sub CargaRuta()
        'Dim daLogistica As New SqlDataAdapter("Select Ruta from Ruta where Celula = @Celula", cnSigamet)
        Dim cmdRuta As New SqlCommand("spLogCat_Rutas", cnSigamet)
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
        Catch ex As Exception
            ExMessage(ex)
        End Try
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
        If txtEmpleado.Text.Trim = "" Then
            ErrMessage("No ha proporcionado el número de empleado del operador.")
            txtEmpleado.Focus()
            Exit Sub
        End If
        If txtNombre.Text.Trim = "" Then
            ErrMessage("No ha proporcionado el nombre del operador.")
            txtNombre.Focus()
            Exit Sub
        End If
        If txtNotas.Text.Trim = "" Then
            txtNotas.Text = "0"
        End If
        If Val(txtNotas.Text) > 32767 Then
            ErrMessage("El número de notas debe ser menor a 32768.")
            txtNotas.Clear()
            txtNotas.Focus()
        End If

        'texis CInt(cboCategoria.SelectedValue) = 1 el uno es de operador'

        If chkPreasignado.Checked = True And AsignacionAutomatica = "1" And CInt(cboCategoria.SelectedValue) = 1 And IsNothing(cboRuta.SelectedValue) = False Then
            Dim arregloResultados() As String
            arregloResultados = VerificarAsignacionOperador()
            If arregloResultados.Length > 0 Then
                Dim res As String
                For Each res In arregloResultados
                    Dim valores As String() = res.Split(New Char() {","c})
                    If (valores(1) <> txtEmpleado.Text) Then
                        ErrMessage("No es posible asignar el operador a esta ruta," + Chr(13) + "ya que existe el operador " + valores(0) + Chr(13) + "con número de empleado: " + valores(1) + " asignado previamente.")
                        Exit Sub
                    End If
                Next
            End If
        End If

        'texis'

        Me.Cursor = Cursors.WaitCursor
        cmdLogistica = New SqlCommand("spLOGOperador", cnSigamet)

        ' Asignación de parámetros
        cmdLogistica.CommandType = CommandType.StoredProcedure
        cmdLogistica.Parameters.Add("@Operador", SqlDbType.Int).Value = CInt(txtEmpleado.Text)
        cmdLogistica.Parameters.Add("@Nombre", SqlDbType.Char).Value = Trim(txtNombre.Text)
        cmdLogistica.Parameters.Add("@Categoria", SqlDbType.TinyInt).Value = CInt(cboCategoria.SelectedValue)
        cmdLogistica.Parameters.Add("@Tipo", SqlDbType.TinyInt).Value = CInt(cboTipo.SelectedValue)
        cmdLogistica.Parameters.Add("@Celula", SqlDbType.TinyInt).Value = CInt(cboCelula.SelectedValue)
        cmdLogistica.Parameters.Add("@Notas", SqlDbType.SmallInt).Value = CInt(txtNotas.Text)
        cmdLogistica.Parameters.Add("@Clasificacion", SqlDbType.TinyInt).Value = CInt(cboClasificacion.SelectedValue)
        cmdLogistica.Parameters.Add("@LitrosCredito", SqlDbType.Decimal).Value = Val(txtLitrosCredito.Text)
        cmdLogistica.Parameters.Add("@Nuevo", SqlDbType.Bit).Value = (Me.Text = "Nuevo operador")
        cmdLogistica.Parameters.Add("@Celular", SqlDbType.Char).Value = txtCelular.Text
        cmdLogistica.Parameters.Add("@Licencia", SqlDbType.Char).Value = txtLicencia.Text
       
        'Texis'
        If cboRuta.Enabled Then
            If IsNothing(cboRuta.SelectedValue) Then
                cmdLogistica.Parameters.Add("@Ruta", SqlDbType.SmallInt).Value = DBNull.Value
                    cmdLogistica.Parameters.Add("@Preasignacion", SqlDbType.Bit).Value = False
            Else
                cmdLogistica.Parameters.Add("@Ruta", SqlDbType.SmallInt).Value = CInt(cboRuta.SelectedValue)
                If chkPreasignado.Checked = True Then
                    cmdLogistica.Parameters.Add("@Preasignacion", SqlDbType.Bit).Value = True
                Else
                    cmdLogistica.Parameters.Add("@Preasignacion", SqlDbType.Bit).Value = False
                End If
            End If
        Else
            'LUSATE
            If IsNothing(cboRuta.SelectedValue) Then
                cmdLogistica.Parameters.Add("@Ruta", SqlDbType.SmallInt).Value = DBNull.Value                
            Else
                cmdLogistica.Parameters.Add("@Ruta", SqlDbType.SmallInt).Value = CInt(cboRuta.SelectedValue)
            End If
            ''
            If chkPreasignado.Checked = True Then
                cmdLogistica.Parameters.Add("@Preasignacion", SqlDbType.Bit).Value = True
            Else
                cmdLogistica.Parameters.Add("@Preasignacion", SqlDbType.Bit).Value = False
            End If
        End If
        ''

        Try
            cnSigamet.Open()
            cmdLogistica.ExecuteNonQuery()
            Me.DialogResult = DialogResult.OK
            Me.Close()
        Catch ex As Exception
            ExMessage(ex)
        Finally
            cnSigamet.Close()
            cmdLogistica.Dispose()
            Me.Cursor = Cursors.Default
        End Try
    End Sub
#End Region

#Region "Manejo de cajas de texto"
    Private Sub TextBox_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtEmpleado.Enter, txtNombre.Enter, txtNotas.Enter, txtCelular.Enter, txtLicencia.Enter
        CType(sender, TextBox).BackColor = Color.LightGoldenrodYellow
    End Sub
    Private Sub TextBox_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtEmpleado.Leave, txtNombre.Leave, txtNotas.Leave, txtCelular.Leave, txtLicencia.Leave
        CType(sender, TextBox).BackColor = Color.White
        'Busqueda de empleado correcto
        If CType(sender, TextBox).Name = "txtEmpleado" And Trim(txtEmpleado.Text) <> "" Then
            Dim cmdLogistica As New SqlCommand("Select Nombre, Puesto from Empleado where Empleado = @Empleado", cnSigamet)
            Dim rdrLogistica As SqlDataReader
            cmdLogistica.Parameters.Add("@Empleado", SqlDbType.Int).Value = CInt(txtEmpleado.Text)
            Try
                cnSigamet.Open()
                rdrLogistica = cmdLogistica.ExecuteReader
                If rdrLogistica.Read Then
                    If Not IsDBNull(rdrLogistica("Nombre")) Then
                        txtNombre.Text = CStr(rdrLogistica("Nombre"))
                    End If
                    If Not IsDBNull(rdrLogistica("Puesto")) Then
                        cboCategoria.SelectedValue = CInt(rdrLogistica("Puesto"))
                    End If
                End If
            Catch ex As Exception
                ExMessage(ex)
            Finally
                cnSigamet.Close()
                cmdLogistica.Dispose()
            End Try
        End If
    End Sub
    Private Sub TextBox_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtEmpleado.KeyPress, txtNotas.KeyPress, txtCelular.KeyPress
        If Not (Char.IsDigit(e.KeyChar) Or Asc(e.KeyChar) = 8 Or Char.IsControl(e.KeyChar)) Then
            e.Handled = True
        Else
            e.Handled = False
        End If
    End Sub
    Private Sub TextBoxDecimal_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtLitrosCredito.KeyPress
        If Not (Char.IsDigit(e.KeyChar) OrElse Char.IsControl(e.KeyChar) OrElse Asc(e.KeyChar) = 8 OrElse _
                    (e.KeyChar = CChar(".") AndAlso CType(sender, TextBox).Text.IndexOf(".") < 0)) Then
            e.Handled = True
        Else
            e.Handled = False
        End If
    End Sub
#End Region


    
    Private Sub cboCelula_SelectedValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboCelula.SelectedValueChanged
        If Not cboCelula.SelectedValue Is Nothing Then
            CargaRuta()
            cboRuta.SelectedValue = RutaOperador
        End If
    End Sub

    Private Sub cboCategoria_SelectedValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboCategoria.SelectedValueChanged
        cboRuta.Enabled = OperacionLogistica(4).Habilitada AndAlso (Not cboCategoria.SelectedValue Is Nothing AndAlso (CInt(cboCategoria.SelectedValue) = 1 OrElse CInt(cboCategoria.SelectedValue) = 2 OrElse CInt(cboCategoria.SelectedValue) = 4 OrElse CInt(cboCategoria.SelectedValue) = 5))
    End Sub

    'texis'
    Private Function VerificarAsignacionOperador() As String()
        Dim arregloResultado As New ArrayList()
        Dim cmd As SqlCommand
        cmd = New SqlCommand("spValidarOperadorPorRuta", cnSigamet)
        cmd.CommandType = CommandType.StoredProcedure
        cmd.Parameters.Add("@Ruta", SqlDbType.Int).Value = CInt(cboRuta.SelectedValue)

        Try
            cnSigamet.Open()
            Dim reader As SqlDataReader = cmd.ExecuteReader()
            While reader.Read()
                Dim res As String = String.Empty
                res += CStr(reader("Nombre"))
                res += ","
                res += CStr(reader("Empleado"))
                arregloResultado.Add(res)
            End While

        Catch ex As Exception
            ExMessage(ex)
        Finally
            cnSigamet.Close()
            cmd.Dispose()
        End Try

        Return CType(arregloResultado.ToArray(GetType(String)), String())
    End Function

    Private Sub cboRuta_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cboRuta.KeyUp
        If e.KeyCode.ToString() = "Delete" Then
            cboRuta.SelectedIndex = -1
            cboRuta.SelectedIndex = -1
            If chkPreasignado.Checked Then
                chkPreasignado.Checked = False
            End If
        End If
    End Sub
End Class
