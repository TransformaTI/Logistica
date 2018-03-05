Imports System.Data.SqlClient
Imports System.Security.Cryptography
Imports System.Text

Public Class frmCapturaUsuarioMovil
    Inherits System.Windows.Forms.Form

#Region " Windows Form Designer generated code "

    Public Sub New(Optional ByVal idusuario As Integer = 0)
        MyBase.New()

        'This call is required by the Windows Form Designer.
        InitializeComponent()

        'Add any initialization after the InitializeComponent() call
        Dim cmdLogistica As New SqlCommand("", cnSigamet)
        cmdLogistica.CommandType = CommandType.StoredProcedure
        Dim daLogistica As New SqlDataAdapter(cmdLogistica)
        'Tablas para llenado de combos      
        Dim dtSucursal As New DataTable()
        Dim dtZonaEconomica As New DataTable()        
        Try           
            cmdLogistica.CommandText = "spLOGConsultarSucursales"
            daLogistica.Fill(dtSucursal)

            cmdLogistica.CommandText = "spLOGConsultarZonaEconomica"
            daLogistica.Fill(dtZonaEconomica)

        Catch ex As Exception
            ExMessage(ex)
        End Try

        cmbSucursal.ValueMember = "IdSucursal"
        cmbSucursal.DisplayMember = "Descripcion"
        cmbSucursal.DataSource = dtSucursal


        cmbZonaEconomica.ValueMember = "IdZonaEconomica"
        cmbZonaEconomica.DisplayMember = "Descripcion"
        cmbZonaEconomica.DataSource = dtZonaEconomica

        'Parametros de default
        Application.DoEvents()

        'Limpiado de memoria
        cmdLogistica.Dispose()
        daLogistica.Dispose()

        'Nuevo/Modificación
        Me.Text = "Nuevo usuario móvil"
        If idusuario > 0 Then
            Me.Text = "Modificación de usuario móvil"
            txtIdUsuario.Text = idusuario.ToString()
            chkCambiaPassword.Visible = True
            chkCambiarPasswordTitular.Visible = True
            CargaDatosUsuarioMovil()
        Else
            chkImprimeNota.Checked = True
            txtPasswordTitular.Enabled = True
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
    Friend WithEvents btnCancelar As System.Windows.Forms.Button
    Friend WithEvents btnAceptar As System.Windows.Forms.Button
    Friend WithEvents rgrpDatos As Logistica.RoundedGroupBox
    Friend WithEvents lblIdUsuario As System.Windows.Forms.Label
    Friend WithEvents txtIdUsuario As System.Windows.Forms.TextBox
    Friend WithEvents lblUsuarioMovil As System.Windows.Forms.Label
    Friend WithEvents txtUsuarioMovil As System.Windows.Forms.TextBox

    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents txtSufijoRuta As System.Windows.Forms.TextBox
    Friend WithEvents lblSucursal As System.Windows.Forms.Label
    Friend WithEvents lblPassword As System.Windows.Forms.Label
    Friend WithEvents txtPassword As System.Windows.Forms.TextBox
    Friend WithEvents lblPasswordTitular As System.Windows.Forms.Label
    Friend WithEvents txtPasswordTitular As System.Windows.Forms.TextBox
    Friend WithEvents chkImprimeNota As System.Windows.Forms.CheckBox
    Friend WithEvents lblImprimeNota As System.Windows.Forms.Label
    Friend WithEvents cmbSucursal As System.Windows.Forms.ComboBox
    Friend WithEvents lblZonaEconomica As System.Windows.Forms.Label
    Friend WithEvents chkCambiarPasswordTitular As System.Windows.Forms.CheckBox
    Friend WithEvents chkCambiaPassword As System.Windows.Forms.CheckBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txtIdSesion As System.Windows.Forms.TextBox
    Friend WithEvents txtUltimoFolioNota As System.Windows.Forms.TextBox
    Friend WithEvents cmbZonaEconomica As System.Windows.Forms.ComboBox
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmCapturaUsuarioMovil))
        Me.btnCancelar = New System.Windows.Forms.Button()
        Me.btnAceptar = New System.Windows.Forms.Button()
        Me.rgrpDatos = New Logistica.RoundedGroupBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txtIdSesion = New System.Windows.Forms.TextBox()
        Me.txtUltimoFolioNota = New System.Windows.Forms.TextBox()
        Me.chkCambiaPassword = New System.Windows.Forms.CheckBox()
        Me.lblZonaEconomica = New System.Windows.Forms.Label()
        Me.chkCambiarPasswordTitular = New System.Windows.Forms.CheckBox()
        Me.cmbZonaEconomica = New System.Windows.Forms.ComboBox()
        Me.cmbSucursal = New System.Windows.Forms.ComboBox()
        Me.chkImprimeNota = New System.Windows.Forms.CheckBox()
        Me.lblImprimeNota = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.txtSufijoRuta = New System.Windows.Forms.TextBox()
        Me.lblSucursal = New System.Windows.Forms.Label()
        Me.lblPassword = New System.Windows.Forms.Label()
        Me.txtPassword = New System.Windows.Forms.TextBox()
        Me.lblPasswordTitular = New System.Windows.Forms.Label()
        Me.txtPasswordTitular = New System.Windows.Forms.TextBox()
        Me.lblUsuarioMovil = New System.Windows.Forms.Label()
        Me.txtUsuarioMovil = New System.Windows.Forms.TextBox()
        Me.lblIdUsuario = New System.Windows.Forms.Label()
        Me.txtIdUsuario = New System.Windows.Forms.TextBox()
        Me.rgrpDatos.SuspendLayout()
        Me.SuspendLayout()
        '
        'btnCancelar
        '
        Me.btnCancelar.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnCancelar.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnCancelar.Image = CType(resources.GetObject("btnCancelar.Image"), System.Drawing.Image)
        Me.btnCancelar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnCancelar.Location = New System.Drawing.Point(348, 44)
        Me.btnCancelar.Name = "btnCancelar"
        Me.btnCancelar.Size = New System.Drawing.Size(80, 24)
        Me.btnCancelar.TabIndex = 14
        Me.btnCancelar.Text = "&Cancelar"
        Me.btnCancelar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'btnAceptar
        '
        Me.btnAceptar.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnAceptar.Image = CType(resources.GetObject("btnAceptar.Image"), System.Drawing.Image)
        Me.btnAceptar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnAceptar.Location = New System.Drawing.Point(348, 16)
        Me.btnAceptar.Name = "btnAceptar"
        Me.btnAceptar.Size = New System.Drawing.Size(80, 24)
        Me.btnAceptar.TabIndex = 13
        Me.btnAceptar.Text = "&Aceptar"
        Me.btnAceptar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'rgrpDatos
        '
        Me.rgrpDatos.BorderColor = System.Drawing.Color.SteelBlue
        Me.rgrpDatos.Controls.Add(Me.Label2)
        Me.rgrpDatos.Controls.Add(Me.Label1)
        Me.rgrpDatos.Controls.Add(Me.txtIdSesion)
        Me.rgrpDatos.Controls.Add(Me.txtUltimoFolioNota)
        Me.rgrpDatos.Controls.Add(Me.chkCambiaPassword)
        Me.rgrpDatos.Controls.Add(Me.lblZonaEconomica)
        Me.rgrpDatos.Controls.Add(Me.chkCambiarPasswordTitular)
        Me.rgrpDatos.Controls.Add(Me.cmbZonaEconomica)
        Me.rgrpDatos.Controls.Add(Me.cmbSucursal)
        Me.rgrpDatos.Controls.Add(Me.chkImprimeNota)
        Me.rgrpDatos.Controls.Add(Me.lblImprimeNota)
        Me.rgrpDatos.Controls.Add(Me.Label4)
        Me.rgrpDatos.Controls.Add(Me.txtSufijoRuta)
        Me.rgrpDatos.Controls.Add(Me.lblSucursal)
        Me.rgrpDatos.Controls.Add(Me.lblPassword)
        Me.rgrpDatos.Controls.Add(Me.txtPassword)
        Me.rgrpDatos.Controls.Add(Me.lblPasswordTitular)
        Me.rgrpDatos.Controls.Add(Me.txtPasswordTitular)
        Me.rgrpDatos.Controls.Add(Me.lblUsuarioMovil)
        Me.rgrpDatos.Controls.Add(Me.txtUsuarioMovil)
        Me.rgrpDatos.Controls.Add(Me.lblIdUsuario)
        Me.rgrpDatos.Controls.Add(Me.txtIdUsuario)
        Me.rgrpDatos.Dock = System.Windows.Forms.DockStyle.Left
        Me.rgrpDatos.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rgrpDatos.ForeColor = System.Drawing.Color.DarkBlue
        Me.rgrpDatos.Location = New System.Drawing.Point(3, 3)
        Me.rgrpDatos.Name = "rgrpDatos"
        Me.rgrpDatos.Size = New System.Drawing.Size(339, 310)
        Me.rgrpDatos.TabIndex = 0
        Me.rgrpDatos.TabStop = False
        Me.rgrpDatos.Text = "Datos del usuario"
        Me.rgrpDatos.TextAlignment = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.Black
        Me.Label2.Location = New System.Drawing.Point(13, 251)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(70, 13)
        Me.Label2.TabIndex = 40
        Me.Label2.Text = "Id de Sesión:"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.Black
        Me.Label1.Location = New System.Drawing.Point(13, 222)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(91, 13)
        Me.Label1.TabIndex = 49
        Me.Label1.Text = "Ultimo Folio Nota:"
        '
        'txtIdSesion
        '
        Me.txtIdSesion.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtIdSesion.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtIdSesion.ForeColor = System.Drawing.Color.Black
        Me.txtIdSesion.Location = New System.Drawing.Point(107, 247)
        Me.txtIdSesion.MaxLength = 20
        Me.txtIdSesion.Name = "txtIdSesion"
        Me.txtIdSesion.Size = New System.Drawing.Size(145, 21)
        Me.txtIdSesion.TabIndex = 11
        '
        'txtUltimoFolioNota
        '
        Me.txtUltimoFolioNota.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtUltimoFolioNota.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtUltimoFolioNota.ForeColor = System.Drawing.Color.Black
        Me.txtUltimoFolioNota.Location = New System.Drawing.Point(107, 218)
        Me.txtUltimoFolioNota.MaxLength = 20
        Me.txtUltimoFolioNota.Name = "txtUltimoFolioNota"
        Me.txtUltimoFolioNota.Size = New System.Drawing.Size(145, 21)
        Me.txtUltimoFolioNota.TabIndex = 10
        '
        'chkCambiaPassword
        '
        Me.chkCambiaPassword.AutoSize = True
        Me.chkCambiaPassword.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.chkCambiaPassword.Location = New System.Drawing.Point(258, 103)
        Me.chkCambiaPassword.Name = "chkCambiaPassword"
        Me.chkCambiaPassword.Size = New System.Drawing.Size(73, 17)
        Me.chkCambiaPassword.TabIndex = 6
        Me.chkCambiaPassword.Text = "Cambiar"
        Me.chkCambiaPassword.UseVisualStyleBackColor = True
        Me.chkCambiaPassword.Visible = False
        '
        'lblZonaEconomica
        '
        Me.lblZonaEconomica.AutoSize = True
        Me.lblZonaEconomica.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblZonaEconomica.ForeColor = System.Drawing.Color.Black
        Me.lblZonaEconomica.Location = New System.Drawing.Point(13, 161)
        Me.lblZonaEconomica.Name = "lblZonaEconomica"
        Me.lblZonaEconomica.Size = New System.Drawing.Size(88, 13)
        Me.lblZonaEconomica.TabIndex = 47
        Me.lblZonaEconomica.Text = "Zona economica:"
        '
        'chkCambiarPasswordTitular
        '
        Me.chkCambiarPasswordTitular.AutoSize = True
        Me.chkCambiarPasswordTitular.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.chkCambiarPasswordTitular.Location = New System.Drawing.Point(258, 77)
        Me.chkCambiarPasswordTitular.Name = "chkCambiarPasswordTitular"
        Me.chkCambiarPasswordTitular.Size = New System.Drawing.Size(73, 17)
        Me.chkCambiarPasswordTitular.TabIndex = 4
        Me.chkCambiarPasswordTitular.Text = "Cambiar"
        Me.chkCambiarPasswordTitular.UseVisualStyleBackColor = True
        Me.chkCambiarPasswordTitular.Visible = False
        '
        'cmbZonaEconomica
        '
        Me.cmbZonaEconomica.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbZonaEconomica.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbZonaEconomica.Location = New System.Drawing.Point(107, 158)
        Me.cmbZonaEconomica.Name = "cmbZonaEconomica"
        Me.cmbZonaEconomica.Size = New System.Drawing.Size(145, 21)
        Me.cmbZonaEconomica.TabIndex = 8
        '
        'cmbSucursal
        '
        Me.cmbSucursal.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbSucursal.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbSucursal.Location = New System.Drawing.Point(107, 131)
        Me.cmbSucursal.Name = "cmbSucursal"
        Me.cmbSucursal.Size = New System.Drawing.Size(145, 21)
        Me.cmbSucursal.TabIndex = 7
        '
        'chkImprimeNota
        '
        Me.chkImprimeNota.AutoSize = True
        Me.chkImprimeNota.Location = New System.Drawing.Point(107, 279)
        Me.chkImprimeNota.Name = "chkImprimeNota"
        Me.chkImprimeNota.Size = New System.Drawing.Size(15, 14)
        Me.chkImprimeNota.TabIndex = 12
        Me.chkImprimeNota.UseVisualStyleBackColor = True
        '
        'lblImprimeNota
        '
        Me.lblImprimeNota.AutoSize = True
        Me.lblImprimeNota.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblImprimeNota.ForeColor = System.Drawing.Color.Black
        Me.lblImprimeNota.Location = New System.Drawing.Point(13, 279)
        Me.lblImprimeNota.Name = "lblImprimeNota"
        Me.lblImprimeNota.Size = New System.Drawing.Size(74, 13)
        Me.lblImprimeNota.TabIndex = 43
        Me.lblImprimeNota.Text = "Imprime nota:"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.Color.Black
        Me.Label4.Location = New System.Drawing.Point(13, 190)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(61, 13)
        Me.Label4.TabIndex = 42
        Me.Label4.Text = "Sufijo ruta:"
        '
        'txtSufijoRuta
        '
        Me.txtSufijoRuta.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtSufijoRuta.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtSufijoRuta.ForeColor = System.Drawing.Color.Black
        Me.txtSufijoRuta.Location = New System.Drawing.Point(107, 186)
        Me.txtSufijoRuta.MaxLength = 20
        Me.txtSufijoRuta.Name = "txtSufijoRuta"
        Me.txtSufijoRuta.Size = New System.Drawing.Size(145, 21)
        Me.txtSufijoRuta.TabIndex = 9
        '
        'lblSucursal
        '
        Me.lblSucursal.AutoSize = True
        Me.lblSucursal.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblSucursal.ForeColor = System.Drawing.Color.Black
        Me.lblSucursal.Location = New System.Drawing.Point(13, 135)
        Me.lblSucursal.Name = "lblSucursal"
        Me.lblSucursal.Size = New System.Drawing.Size(51, 13)
        Me.lblSucursal.TabIndex = 40
        Me.lblSucursal.Text = "Sucursal:"
        '
        'lblPassword
        '
        Me.lblPassword.AutoSize = True
        Me.lblPassword.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblPassword.ForeColor = System.Drawing.Color.Black
        Me.lblPassword.Location = New System.Drawing.Point(13, 108)
        Me.lblPassword.Name = "lblPassword"
        Me.lblPassword.Size = New System.Drawing.Size(57, 13)
        Me.lblPassword.TabIndex = 38
        Me.lblPassword.Text = "Password:"
        '
        'txtPassword
        '
        Me.txtPassword.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtPassword.Enabled = False
        Me.txtPassword.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtPassword.ForeColor = System.Drawing.Color.Black
        Me.txtPassword.Location = New System.Drawing.Point(107, 104)
        Me.txtPassword.MaxLength = 20
        Me.txtPassword.Name = "txtPassword"
        Me.txtPassword.Size = New System.Drawing.Size(145, 21)
        Me.txtPassword.TabIndex = 5
        '
        'lblPasswordTitular
        '
        Me.lblPasswordTitular.AutoSize = True
        Me.lblPasswordTitular.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblPasswordTitular.ForeColor = System.Drawing.Color.Black
        Me.lblPasswordTitular.Location = New System.Drawing.Point(13, 81)
        Me.lblPasswordTitular.Name = "lblPasswordTitular"
        Me.lblPasswordTitular.Size = New System.Drawing.Size(88, 13)
        Me.lblPasswordTitular.TabIndex = 36
        Me.lblPasswordTitular.Text = "Password titular:"
        '
        'txtPasswordTitular
        '
        Me.txtPasswordTitular.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtPasswordTitular.Enabled = False
        Me.txtPasswordTitular.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtPasswordTitular.ForeColor = System.Drawing.Color.Black
        Me.txtPasswordTitular.Location = New System.Drawing.Point(107, 77)
        Me.txtPasswordTitular.MaxLength = 20
        Me.txtPasswordTitular.Name = "txtPasswordTitular"
        Me.txtPasswordTitular.Size = New System.Drawing.Size(145, 21)
        Me.txtPasswordTitular.TabIndex = 3
        '
        'lblUsuarioMovil
        '
        Me.lblUsuarioMovil.AutoSize = True
        Me.lblUsuarioMovil.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblUsuarioMovil.ForeColor = System.Drawing.Color.Black
        Me.lblUsuarioMovil.Location = New System.Drawing.Point(13, 54)
        Me.lblUsuarioMovil.Name = "lblUsuarioMovil"
        Me.lblUsuarioMovil.Size = New System.Drawing.Size(74, 13)
        Me.lblUsuarioMovil.TabIndex = 30
        Me.lblUsuarioMovil.Text = "Usuario móvil:"
        '
        'txtUsuarioMovil
        '
        Me.txtUsuarioMovil.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtUsuarioMovil.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtUsuarioMovil.ForeColor = System.Drawing.Color.Black
        Me.txtUsuarioMovil.Location = New System.Drawing.Point(107, 50)
        Me.txtUsuarioMovil.MaxLength = 20
        Me.txtUsuarioMovil.Name = "txtUsuarioMovil"
        Me.txtUsuarioMovil.Size = New System.Drawing.Size(145, 21)
        Me.txtUsuarioMovil.TabIndex = 2
        '
        'lblIdUsuario
        '
        Me.lblIdUsuario.AutoSize = True
        Me.lblIdUsuario.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblIdUsuario.ForeColor = System.Drawing.Color.Black
        Me.lblIdUsuario.Location = New System.Drawing.Point(13, 24)
        Me.lblIdUsuario.Name = "lblIdUsuario"
        Me.lblIdUsuario.Size = New System.Drawing.Size(65, 13)
        Me.lblIdUsuario.TabIndex = 0
        Me.lblIdUsuario.Text = "&IdUsuario:"
        '
        'txtIdUsuario
        '
        Me.txtIdUsuario.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtIdUsuario.Enabled = False
        Me.txtIdUsuario.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtIdUsuario.ForeColor = System.Drawing.Color.Black
        Me.txtIdUsuario.Location = New System.Drawing.Point(107, 20)
        Me.txtIdUsuario.MaxLength = 10
        Me.txtIdUsuario.Name = "txtIdUsuario"
        Me.txtIdUsuario.ReadOnly = True
        Me.txtIdUsuario.Size = New System.Drawing.Size(52, 21)
        Me.txtIdUsuario.TabIndex = 1
        '
        'frmCapturaUsuarioMovil
        '
        Me.AcceptButton = Me.btnAceptar
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 14)
        Me.BackColor = System.Drawing.Color.Gainsboro
        Me.CancelButton = Me.btnCancelar
        Me.ClientSize = New System.Drawing.Size(433, 316)
        Me.Controls.Add(Me.rgrpDatos)
        Me.Controls.Add(Me.btnAceptar)
        Me.Controls.Add(Me.btnCancelar)
        Me.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmCapturaUsuarioMovil"
        Me.Padding = New System.Windows.Forms.Padding(3)
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.rgrpDatos.ResumeLayout(False)
        Me.rgrpDatos.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

#End Region

#Region "Variables globales"
#End Region

#Region "Manejo de datos"
    Private Sub CargaDatosUsuarioMovil()
        Dim cmdLogistica As New SqlCommand("spLOGConsultaUsuarioMovil", cnSigamet)
        cmdLogistica.CommandType = CommandType.StoredProcedure
        Dim rdrLogistica As SqlDataReader
        'Carga de parámetros
        cmdLogistica.Parameters.Add("@UsuarioMovil", SqlDbType.Int).Value = CInt(txtIdUsuario.Text)
        Try
            cnSigamet.Open()
            rdrLogistica = cmdLogistica.ExecuteReader
            If rdrLogistica.Read Then

                txtUsuarioMovil.Text = CStr(rdrLogistica("nombre"))
                txtPasswordTitular.Text = CStr(rdrLogistica("passwordtitular"))
                txtPassword.Text = CStr(rdrLogistica("password"))
                cmbSucursal.SelectedValue = CInt(rdrLogistica("idsucursal").ToString())
                cmbZonaEconomica.SelectedValue = CInt(rdrLogistica("idpoprecio").ToString())
                txtSufijoRuta.Text = CStr(rdrLogistica("Sufijo"))
                txtIdSesion.Text = CStr(rdrLogistica("Sesion"))
                txtUltimoFolioNota.Text = CStr(rdrLogistica("UltimoFolioNota"))
                chkImprimeNota.Checked = CBool(rdrLogistica("imprimenota"))
            End If
            rdrLogistica.Close()
        Catch ex As Exception
            ExMessage(ex)
        Finally
            cnSigamet.Close()
            cmdLogistica.Dispose()
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
        If Trim(txtUsuarioMovil.Text) = "" Then
            ErrMessage("Debe proporcionar un usuario.")
            txtUsuarioMovil.Focus()
            Exit Sub
        End If

        If (chkCambiarPasswordTitular.Checked Or txtIdUsuario.Text = "") And txtPasswordTitular.Text = "" Then
            ErrMessage("Debe proporcionar un password titular.")
            txtPasswordTitular.Focus()
            Exit Sub
        End If

        If (chkCambiaPassword.Checked Or txtIdUsuario.Text = "") And txtPassword.Text = "" Then
            ErrMessage("Debe proporcionar un password.")
            txtPassword.Focus()
            Exit Sub
        End If

        If txtIdSesion.Text = "" Then
            ErrMessage("Debe proporcionar un Id de sesión.")
            txtPassword.Focus()
            Exit Sub
        End If

        If txtUltimoFolioNota.Text = "" Then
            ErrMessage("Debe proporcionar un ultimo folio nota.")
            txtPassword.Focus()
            Exit Sub
        End If

        If txtSufijoRuta.Text = "" Then
            ErrMessage("Debe proporcionar sufijo de ruta.")
            txtSufijoRuta.Focus()
            Exit Sub
        End If

        Me.Cursor = Cursors.WaitCursor


        If txtIdUsuario.Text = "" Then
            cmdLogistica = New SqlCommand("spLOGAltaUsuarioMovil", cnSigamet)            
        Else
            cmdLogistica = New SqlCommand("spLOGModificarUsuarioMovil", cnSigamet)            
            cmdLogistica.Parameters.Add("@IdUsuario", SqlDbType.Int).Value = txtIdUsuario.Text
            cmdLogistica.Parameters.Add("@IdSesion", SqlDbType.Int).Value = txtIdSesion.Text
            cmdLogistica.Parameters.Add("@UltimoFolioNota", SqlDbType.Int).Value = txtUltimoFolioNota.Text
        End If
        cmdLogistica.CommandType = CommandType.StoredProcedure
        ' Asignación de parámetros
        cmdLogistica.Parameters.Add("@Nombre", SqlDbType.VarChar).Value = txtUsuarioMovil.Text


        cmdLogistica.Parameters.Add("@IdPoPrecio", SqlDbType.Int).Value = cmbZonaEconomica.SelectedValue
        cmdLogistica.Parameters.Add("@IdSucursal", SqlDbType.Int).Value = cmbSucursal.SelectedValue

        If txtIdUsuario.Text = "" Or chkCambiarPasswordTitular.Checked Then
            cmdLogistica.Parameters.Add("@PasswordTitular", SqlDbType.VarChar).Value = EncriptarClaves(txtPasswordTitular.Text)           
        End If

        If txtIdUsuario.Text = "" Or chkCambiaPassword.Checked Then
            cmdLogistica.Parameters.Add("@Password", SqlDbType.VarChar).Value = EncriptarClaves(txtPassword.Text)
        ElseIf chkCambiarPasswordTitular.Checked And chkCambiaPassword.Checked = False Then
            cmdLogistica.Parameters.Add("@Password", SqlDbType.VarChar).Value = EncriptarClaves(txtPasswordTitular.Text)
        End If


        cmdLogistica.Parameters.Add("@ImprimeNota", SqlDbType.Bit).Value = chkImprimeNota.Checked
        cmdLogistica.Parameters.Add("@SufijoRuta", SqlDbType.VarChar).Value = txtSufijoRuta.Text

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

    Private Sub frmCapturaUsuarioMovil_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load

        If OperacionLogistica(23).Habilitada = False And OperacionLogistica(24).Habilitada Then
            txtUsuarioMovil.Enabled = False
            txtPasswordTitular.Enabled = False
            chkCambiarPasswordTitular.Enabled = False
            cmbSucursal.Enabled = False
            cmbZonaEconomica.Enabled = False
            txtSufijoRuta.Enabled = False
            txtUltimoFolioNota.Enabled = False
            txtIdSesion.Enabled = False
            chkImprimeNota.Enabled = False
            txtPassword.Focus()
        End If
        If OperacionLogistica(23).Habilitada Then
            txtUsuarioMovil.Focus()
        End If

        If txtIdUsuario.Text = "" Then
            txtIdSesion.Text = "0"
            txtIdSesion.Enabled = False
            txtUltimoFolioNota.Text = "0"
            txtUltimoFolioNota.Enabled = False
        End If
        
    End Sub


#Region "Manejo de encriptación de password"

    Shared Function verificarClaves(ByVal clave As String, ByVal hash As String) As Boolean
        Dim resultado As Boolean = False
        Using md5Hash As MD5 = MD5.Create()
            Dim llave As String = GetMd5Hash(md5Hash, clave)
            resultado = VerifyMd5Hash(md5Hash, clave, hash)
        End Using
        Return resultado

    End Function
    Shared Function GetMd5Hash(ByVal md5Hash As MD5, ByVal input As String) As String
        Dim data() As Byte = md5Hash.ComputeHash(Encoding.UTF8.GetBytes(input))
        Dim sBuilder As StringBuilder = New StringBuilder
        For i As Integer = 0 To data.Length - 1
            sBuilder.Append(data(i).ToString("x2"))
        Next
        Return sBuilder.ToString()
    End Function
    Shared Function VerifyMd5Hash(ByVal md5Hash As MD5, ByVal input As String, ByVal hash As String) As Boolean
        Dim hashOfInput As String = GetMd5Hash(md5Hash, input)
        Dim comparer As StringComparer = StringComparer.OrdinalIgnoreCase
        If 0 = comparer.Compare(hashOfInput, hash) Then
            Return True
        Else
            Return False
        End If
    End Function
#End Region


    Private Sub txtPasswordTitular_TextChanged(sender As System.Object, e As System.EventArgs) Handles txtPasswordTitular.TextChanged

    End Sub

    Private Sub chkCambiarPasswordTitular_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles chkCambiarPasswordTitular.CheckedChanged
        If chkCambiarPasswordTitular.Checked Then
            txtPasswordTitular.Enabled = True
            txtPasswordTitular.Text = ""            
            chkCambiaPassword.Visible = False
            txtPassword.Text = ""
        Else
            txtPasswordTitular.Enabled = False
            chkCambiaPassword.Visible = True
        End If
    End Sub

    Private Function EncriptarClaves(ByVal Clave As String) As String
        'EncriptaClaves
        Dim ClaveEncriptada As String
        Using md5Hash As MD5 = MD5.Create()
            ClaveEncriptada = GetMd5Hash(md5Hash, Clave)
        End Using
        Return ClaveEncriptada
    End Function
    Private Sub txtPasswordTitular_Leave(sender As System.Object, e As System.EventArgs) Handles txtPasswordTitular.Leave
        If txtIdUsuario.Text = "" Or (chkCambiarPasswordTitular.Checked And chkCambiaPassword.Checked = False) Then
            txtPassword.Text = txtPasswordTitular.Text
        End If
    End Sub


    Private Sub chkCambiaPassword_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles chkCambiaPassword.CheckedChanged
        If chkCambiaPassword.Checked Then
            txtPassword.Enabled = True
            txtPassword.Text = ""
        Else
            txtPassword.Enabled = False
        End If
    End Sub

    Private Sub TextBox_KeyPress(ByVal sender As Object, ByVal e As KeyPressEventArgs) Handles txtPassword.KeyPress, txtPasswordTitular.KeyPress, txtIdSesion.KeyPress, txtUltimoFolioNota.KeyPress
        If Not (Char.IsDigit(e.KeyChar) Or Asc(e.KeyChar) = 8 Or Char.IsControl(e.KeyChar)) Then
            e.Handled = True
        Else
            e.Handled = False
        End If
    End Sub
End Class
