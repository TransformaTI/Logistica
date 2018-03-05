Imports System.Data.SqlClient

Public Class frmCapturaFactorCliente
    Inherits System.Windows.Forms.Form

#Region " Windows Form Designer generated code "

    Public Sub New(Optional ByVal ClienteModifica As Integer = 0)
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


        If ClienteModifica <> 0 Then
            CargaCliente(ClienteModifica)
            txtCliente.Text = CStr(ClienteModifica)
            txtCliente.ReadOnly = True
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
    Friend WithEvents lblCliente As System.Windows.Forms.Label
    Friend WithEvents lblRuta As System.Windows.Forms.Label
    Friend WithEvents txtRuta As System.Windows.Forms.TextBox
    Friend WithEvents lblCelula As System.Windows.Forms.Label
    Friend WithEvents txtCelula As System.Windows.Forms.TextBox
    Friend WithEvents lblDireccion As System.Windows.Forms.Label
    Friend WithEvents txtDireccion As System.Windows.Forms.TextBox
    Friend WithEvents lblNombre As System.Windows.Forms.Label
    Friend WithEvents txtNombre As System.Windows.Forms.TextBox
    Friend WithEvents lblFactor As System.Windows.Forms.Label
    Friend WithEvents lblPorcentaje As System.Windows.Forms.Label
    Friend WithEvents txtPorcentaje As System.Windows.Forms.TextBox
    Friend WithEvents lblDescuento As System.Windows.Forms.Label
    Friend WithEvents txtDescuento As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents btnBuscar As System.Windows.Forms.Button
    Friend WithEvents txtFactorCalibracion As System.Windows.Forms.TextBox
    Friend WithEvents lblCantCaracteres As System.Windows.Forms.Label
    Friend WithEvents txtCliente As System.Windows.Forms.TextBox
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmCapturaFactorCliente))
        Me.btnCancelar = New System.Windows.Forms.Button()
        Me.btnAceptar = New System.Windows.Forms.Button()
        Me.rgrpDatos = New Logistica.RoundedGroupBox()
        Me.lblCantCaracteres = New System.Windows.Forms.Label()
        Me.btnBuscar = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.lblFactor = New System.Windows.Forms.Label()
        Me.txtFactorCalibracion = New System.Windows.Forms.TextBox()
        Me.lblPorcentaje = New System.Windows.Forms.Label()
        Me.txtPorcentaje = New System.Windows.Forms.TextBox()
        Me.lblDescuento = New System.Windows.Forms.Label()
        Me.txtDescuento = New System.Windows.Forms.TextBox()
        Me.lblRuta = New System.Windows.Forms.Label()
        Me.txtRuta = New System.Windows.Forms.TextBox()
        Me.lblCelula = New System.Windows.Forms.Label()
        Me.txtCelula = New System.Windows.Forms.TextBox()
        Me.lblDireccion = New System.Windows.Forms.Label()
        Me.txtDireccion = New System.Windows.Forms.TextBox()
        Me.lblNombre = New System.Windows.Forms.Label()
        Me.txtNombre = New System.Windows.Forms.TextBox()
        Me.lblCliente = New System.Windows.Forms.Label()
        Me.txtCliente = New System.Windows.Forms.TextBox()
        Me.rgrpDatos.SuspendLayout()
        Me.SuspendLayout()
        '
        'btnCancelar
        '
        Me.btnCancelar.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnCancelar.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnCancelar.Image = CType(resources.GetObject("btnCancelar.Image"), System.Drawing.Image)
        Me.btnCancelar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnCancelar.Location = New System.Drawing.Point(343, 52)
        Me.btnCancelar.Name = "btnCancelar"
        Me.btnCancelar.Size = New System.Drawing.Size(80, 24)
        Me.btnCancelar.TabIndex = 5
        Me.btnCancelar.Text = "&Cancelar"
        Me.btnCancelar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'btnAceptar
        '
        Me.btnAceptar.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnAceptar.Image = CType(resources.GetObject("btnAceptar.Image"), System.Drawing.Image)
        Me.btnAceptar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnAceptar.Location = New System.Drawing.Point(343, 16)
        Me.btnAceptar.Name = "btnAceptar"
        Me.btnAceptar.Size = New System.Drawing.Size(80, 24)
        Me.btnAceptar.TabIndex = 4
        Me.btnAceptar.Text = "&Aceptar"
        Me.btnAceptar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'rgrpDatos
        '
        Me.rgrpDatos.BorderColor = System.Drawing.Color.SteelBlue
        Me.rgrpDatos.Controls.Add(Me.lblCantCaracteres)
        Me.rgrpDatos.Controls.Add(Me.btnBuscar)
        Me.rgrpDatos.Controls.Add(Me.Label1)
        Me.rgrpDatos.Controls.Add(Me.lblFactor)
        Me.rgrpDatos.Controls.Add(Me.txtFactorCalibracion)
        Me.rgrpDatos.Controls.Add(Me.lblPorcentaje)
        Me.rgrpDatos.Controls.Add(Me.txtPorcentaje)
        Me.rgrpDatos.Controls.Add(Me.lblDescuento)
        Me.rgrpDatos.Controls.Add(Me.txtDescuento)
        Me.rgrpDatos.Controls.Add(Me.lblRuta)
        Me.rgrpDatos.Controls.Add(Me.txtRuta)
        Me.rgrpDatos.Controls.Add(Me.lblCelula)
        Me.rgrpDatos.Controls.Add(Me.txtCelula)
        Me.rgrpDatos.Controls.Add(Me.lblDireccion)
        Me.rgrpDatos.Controls.Add(Me.txtDireccion)
        Me.rgrpDatos.Controls.Add(Me.lblNombre)
        Me.rgrpDatos.Controls.Add(Me.txtNombre)
        Me.rgrpDatos.Controls.Add(Me.lblCliente)
        Me.rgrpDatos.Controls.Add(Me.txtCliente)
        Me.rgrpDatos.Dock = System.Windows.Forms.DockStyle.Left
        Me.rgrpDatos.FlatStyle = Logistica.RoundedGroupBox.Style.Pipe
        Me.rgrpDatos.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rgrpDatos.ForeColor = System.Drawing.Color.DarkBlue
        Me.rgrpDatos.Location = New System.Drawing.Point(3, 3)
        Me.rgrpDatos.Name = "rgrpDatos"
        Me.rgrpDatos.Size = New System.Drawing.Size(334, 336)
        Me.rgrpDatos.TabIndex = 0
        Me.rgrpDatos.TabStop = False
        Me.rgrpDatos.Text = "Datos calibración cliente"
        Me.rgrpDatos.TextAlignment = System.Windows.Forms.HorizontalAlignment.Center
        '
        'lblCantCaracteres
        '
        Me.lblCantCaracteres.AutoSize = True
        Me.lblCantCaracteres.Location = New System.Drawing.Point(301, 275)
        Me.lblCantCaracteres.Name = "lblCantCaracteres"
        Me.lblCantCaracteres.Size = New System.Drawing.Size(14, 13)
        Me.lblCantCaracteres.TabIndex = 25
        Me.lblCantCaracteres.Text = "0"
        '
        'btnBuscar
        '
        Me.btnBuscar.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnBuscar.BackColor = System.Drawing.Color.Gainsboro
        Me.btnBuscar.Image = CType(resources.GetObject("btnBuscar.Image"), System.Drawing.Image)
        Me.btnBuscar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnBuscar.Location = New System.Drawing.Point(195, 20)
        Me.btnBuscar.Name = "btnBuscar"
        Me.btnBuscar.Size = New System.Drawing.Size(75, 23)
        Me.btnBuscar.TabIndex = 0
        Me.btnBuscar.Text = "&Buscar"
        Me.btnBuscar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnBuscar.UseVisualStyleBackColor = False
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.Black
        Me.Label1.Location = New System.Drawing.Point(162, 240)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(18, 13)
        Me.Label1.TabIndex = 17
        Me.Label1.Text = "%"
        '
        'lblFactor
        '
        Me.lblFactor.AutoSize = True
        Me.lblFactor.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblFactor.ForeColor = System.Drawing.Color.Black
        Me.lblFactor.Location = New System.Drawing.Point(13, 275)
        Me.lblFactor.Name = "lblFactor"
        Me.lblFactor.Size = New System.Drawing.Size(42, 13)
        Me.lblFactor.TabIndex = 14
        Me.lblFactor.Text = "Factor:"
        '
        'txtFactorCalibracion
        '
        Me.txtFactorCalibracion.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtFactorCalibracion.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtFactorCalibracion.ForeColor = System.Drawing.Color.Black
        Me.txtFactorCalibracion.Location = New System.Drawing.Point(86, 273)
        Me.txtFactorCalibracion.MaxLength = 32
        Me.txtFactorCalibracion.Name = "txtFactorCalibracion"
        Me.txtFactorCalibracion.Size = New System.Drawing.Size(209, 21)
        Me.txtFactorCalibracion.TabIndex = 3
        '
        'lblPorcentaje
        '
        Me.lblPorcentaje.AutoSize = True
        Me.lblPorcentaje.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblPorcentaje.ForeColor = System.Drawing.Color.Black
        Me.lblPorcentaje.Location = New System.Drawing.Point(13, 238)
        Me.lblPorcentaje.Name = "lblPorcentaje"
        Me.lblPorcentaje.Size = New System.Drawing.Size(63, 13)
        Me.lblPorcentaje.TabIndex = 12
        Me.lblPorcentaje.Text = "Porcentaje:"
        '
        'txtPorcentaje
        '
        Me.txtPorcentaje.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtPorcentaje.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtPorcentaje.ForeColor = System.Drawing.Color.Black
        Me.txtPorcentaje.Location = New System.Drawing.Point(86, 236)
        Me.txtPorcentaje.MaxLength = 4
        Me.txtPorcentaje.Name = "txtPorcentaje"
        Me.txtPorcentaje.Size = New System.Drawing.Size(70, 21)
        Me.txtPorcentaje.TabIndex = 2
        '
        'lblDescuento
        '
        Me.lblDescuento.AutoSize = True
        Me.lblDescuento.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblDescuento.ForeColor = System.Drawing.Color.Black
        Me.lblDescuento.Location = New System.Drawing.Point(13, 202)
        Me.lblDescuento.Name = "lblDescuento"
        Me.lblDescuento.Size = New System.Drawing.Size(62, 13)
        Me.lblDescuento.TabIndex = 10
        Me.lblDescuento.Text = "Descuento:"
        '
        'txtDescuento
        '
        Me.txtDescuento.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtDescuento.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtDescuento.ForeColor = System.Drawing.Color.Black
        Me.txtDescuento.Location = New System.Drawing.Point(86, 200)
        Me.txtDescuento.MaxLength = 10
        Me.txtDescuento.Name = "txtDescuento"
        Me.txtDescuento.ReadOnly = True
        Me.txtDescuento.Size = New System.Drawing.Size(70, 21)
        Me.txtDescuento.TabIndex = 11
        Me.txtDescuento.TabStop = False
        '
        'lblRuta
        '
        Me.lblRuta.AutoSize = True
        Me.lblRuta.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblRuta.ForeColor = System.Drawing.Color.Black
        Me.lblRuta.Location = New System.Drawing.Point(13, 166)
        Me.lblRuta.Name = "lblRuta"
        Me.lblRuta.Size = New System.Drawing.Size(34, 13)
        Me.lblRuta.TabIndex = 8
        Me.lblRuta.Text = "Ruta:"
        '
        'txtRuta
        '
        Me.txtRuta.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtRuta.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtRuta.ForeColor = System.Drawing.Color.Black
        Me.txtRuta.Location = New System.Drawing.Point(86, 164)
        Me.txtRuta.MaxLength = 15
        Me.txtRuta.Name = "txtRuta"
        Me.txtRuta.ReadOnly = True
        Me.txtRuta.Size = New System.Drawing.Size(70, 21)
        Me.txtRuta.TabIndex = 9
        Me.txtRuta.TabStop = False
        '
        'lblCelula
        '
        Me.lblCelula.AutoSize = True
        Me.lblCelula.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCelula.ForeColor = System.Drawing.Color.Black
        Me.lblCelula.Location = New System.Drawing.Point(13, 129)
        Me.lblCelula.Name = "lblCelula"
        Me.lblCelula.Size = New System.Drawing.Size(40, 13)
        Me.lblCelula.TabIndex = 6
        Me.lblCelula.Text = "Celula:"
        '
        'txtCelula
        '
        Me.txtCelula.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtCelula.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtCelula.ForeColor = System.Drawing.Color.Black
        Me.txtCelula.Location = New System.Drawing.Point(86, 127)
        Me.txtCelula.MaxLength = 15
        Me.txtCelula.Name = "txtCelula"
        Me.txtCelula.ReadOnly = True
        Me.txtCelula.Size = New System.Drawing.Size(70, 21)
        Me.txtCelula.TabIndex = 7
        Me.txtCelula.TabStop = False
        '
        'lblDireccion
        '
        Me.lblDireccion.AutoSize = True
        Me.lblDireccion.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblDireccion.ForeColor = System.Drawing.Color.Black
        Me.lblDireccion.Location = New System.Drawing.Point(13, 91)
        Me.lblDireccion.Name = "lblDireccion"
        Me.lblDireccion.Size = New System.Drawing.Size(54, 13)
        Me.lblDireccion.TabIndex = 4
        Me.lblDireccion.Text = "Dirección:"
        '
        'txtDireccion
        '
        Me.txtDireccion.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtDireccion.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtDireccion.ForeColor = System.Drawing.Color.Black
        Me.txtDireccion.Location = New System.Drawing.Point(86, 89)
        Me.txtDireccion.MaxLength = 150
        Me.txtDireccion.Name = "txtDireccion"
        Me.txtDireccion.ReadOnly = True
        Me.txtDireccion.Size = New System.Drawing.Size(215, 21)
        Me.txtDireccion.TabIndex = 5
        Me.txtDireccion.TabStop = False
        '
        'lblNombre
        '
        Me.lblNombre.AutoSize = True
        Me.lblNombre.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblNombre.ForeColor = System.Drawing.Color.Black
        Me.lblNombre.Location = New System.Drawing.Point(13, 54)
        Me.lblNombre.Name = "lblNombre"
        Me.lblNombre.Size = New System.Drawing.Size(48, 13)
        Me.lblNombre.TabIndex = 2
        Me.lblNombre.Text = "Nombre:"
        '
        'txtNombre
        '
        Me.txtNombre.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtNombre.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtNombre.ForeColor = System.Drawing.Color.Black
        Me.txtNombre.Location = New System.Drawing.Point(86, 52)
        Me.txtNombre.MaxLength = 150
        Me.txtNombre.Name = "txtNombre"
        Me.txtNombre.ReadOnly = True
        Me.txtNombre.Size = New System.Drawing.Size(215, 21)
        Me.txtNombre.TabIndex = 0
        Me.txtNombre.TabStop = False
        '
        'lblCliente
        '
        Me.lblCliente.AutoSize = True
        Me.lblCliente.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCliente.ForeColor = System.Drawing.Color.Black
        Me.lblCliente.Location = New System.Drawing.Point(13, 24)
        Me.lblCliente.Name = "lblCliente"
        Me.lblCliente.Size = New System.Drawing.Size(49, 13)
        Me.lblCliente.TabIndex = 0
        Me.lblCliente.Text = "&Cliente:"
        '
        'txtCliente
        '
        Me.txtCliente.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtCliente.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtCliente.ForeColor = System.Drawing.Color.Black
        Me.txtCliente.Location = New System.Drawing.Point(86, 22)
        Me.txtCliente.MaxLength = 150
        Me.txtCliente.Name = "txtCliente"
        Me.txtCliente.Size = New System.Drawing.Size(94, 21)
        Me.txtCliente.TabIndex = 1
        '
        'frmCapturaFactorCliente
        '
        Me.AcceptButton = Me.btnAceptar
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 14)
        Me.BackColor = System.Drawing.Color.Gainsboro
        Me.CancelButton = Me.btnCancelar
        Me.ClientSize = New System.Drawing.Size(438, 342)
        Me.Controls.Add(Me.btnCancelar)
        Me.Controls.Add(Me.btnAceptar)
        Me.Controls.Add(Me.rgrpDatos)
        Me.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmCapturaFactorCliente"
        Me.Padding = New System.Windows.Forms.Padding(3)
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.rgrpDatos.ResumeLayout(False)
        Me.rgrpDatos.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

#End Region

#Region "Variables globales"
    Dim Porcentaje As String = Nothing
    Dim Factor As String = Nothing
#End Region

#Region "Botones"
    Private Sub btnCancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancelar.Click
        Me.Close()
        Me.Dispose()
    End Sub
    Private Sub btnAceptar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAceptar.Click        
        'Dim TieneCaracter As Boolean = False
        'TieneCaracter = TieneCaracteres(txtFactorCalibracion.Text)

        If txtCliente.Text <> "" Then
            If txtPorcentaje.Text <> "" And txtFactorCalibracion.Text <> "" Then
                If CDec(txtPorcentaje.Text) <= 100 Then
                    If txtPorcentaje.Text <> Porcentaje Or txtFactorCalibracion.Text <> Factor Then
                        'If TieneCaracter = True Then
                        Dim cmdFactorCliente As SqlCommand
                        Me.Cursor = Cursors.WaitCursor
                        cmdFactorCliente = New SqlCommand("spLOGClienteCalibracion", cnSigamet)

                        ' Asignación de parámetros
                        cmdFactorCliente.CommandType = CommandType.StoredProcedure
                        cmdFactorCliente.Parameters.Add("@Cliente", SqlDbType.Int).Value = CInt(txtCliente.Text)
                        cmdFactorCliente.Parameters.Add("@PorcentajeCalibracion", SqlDbType.Decimal).Value = CDec(txtPorcentaje.Text)
                        cmdFactorCliente.Parameters.Add("@Calibracion", SqlDbType.Char).Value = txtFactorCalibracion.Text
                        cmdFactorCliente.Parameters.Add("@UsuarioAlta", SqlDbType.VarChar).Value = _Usuario
                        cmdFactorCliente.Parameters.Add("@UsuarioSolicito", SqlDbType.VarChar).Value = _Usuario

                        Try
                            If cnSigamet.State = ConnectionState.Closed Then
                                cnSigamet.Open()
                            End If
                            cmdFactorCliente.ExecuteNonQuery()
                            Me.DialogResult = DialogResult.OK
                            Me.Close()
                        Catch ex As Exception
                            ExMessage(ex)
                        Finally
                            Me.Cursor = Cursors.Default
                            cnSigamet.Close()
                            cmdFactorCliente.Dispose()
                        End Try
                        'Else
                        '    Me.Close()
                        '    Me.Dispose()
                        'End If
                    Else
                        Me.Close()
                        Me.Dispose()
                    End If
                Else
                    MessageBox.Show("El porcentaje de calibracion es incorreco, debe ser menor o igual a 100% ", Application.ProductName & " v." & Application.ProductVersion, MessageBoxButtons.OK, MessageBoxIcon.Information)
                End If
            Else
                MessageBox.Show("No se han proporcionado los datos de factor y/o porcentaje de calibración ", Application.ProductName & " v." & Application.ProductVersion, MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If
        Else
            MessageBox.Show("No se ha proporcionado un número de cliente ", Application.ProductName & " v." & Application.ProductVersion, MessageBoxButtons.OK, MessageBoxIcon.Information)
        End If


    End Sub
#End Region

#Region "Manejo de cajas de texto"
    Private Sub TextBox_Enter(ByVal sender As Object, ByVal e As EventArgs) Handles txtCliente.Enter
        CType(sender, TextBox).BackColor = Color.LightGoldenrodYellow        
    End Sub
    Private Sub TextBox_Leave(ByVal sender As Object, ByVal e As EventArgs) Handles txtCliente.Leave
        CType(sender, TextBox).BackColor = Color.White
        If txtCliente.Text <> "" Then
            CargaCliente(CInt(txtCliente.Text))
        End If
    End Sub
    Private Sub TextBox_Leave2(ByVal sender As Object, ByVal e As EventArgs) Handles txtFactorCalibracion.Leave
        CType(sender, TextBox).BackColor = Color.White
        If txtFactorCalibracion.Text <> "" Then
            lblCantCaracteres.Text = (txtFactorCalibracion.TextLength).ToString()
        Else
            lblCantCaracteres.Text = CStr(0)
        End If
    End Sub
    Private Sub txtCliente_KeyPress(ByVal sender As Object, ByVal e As KeyPressEventArgs) Handles txtCliente.KeyPress
        If Not (Char.IsDigit(e.KeyChar) Or Asc(e.KeyChar) = 8 Or Char.IsControl(e.KeyChar)) Then
            e.Handled = True
        Else
            e.Handled = False
        End If
    End Sub
    Private Sub txtFactorCalibracion_KeyPress(ByVal sender As Object, ByVal e As KeyPressEventArgs) Handles txtFactorCalibracion.KeyPress
        'If Char.IsLetterOrDigit(e.KeyChar) OrElse Asc(e.KeyChar) = 8 OrElse Asc(e.KeyChar) = 46 OrElse (Asc(e.KeyChar) >= 32 And Asc(e.KeyChar) <= 47) _
        '    OrElse Asc(e.KeyChar) = 64 Then
        '    If Asc(e.KeyChar) = 8 Then
        '        If txtFactorCalibracion.TextLength > 0 Then
        '            lblCantCaracteres.Text = (txtFactorCalibracion.TextLength - 1).ToString()
        '        End If
        '    Else
        '        lblCantCaracteres.Text = (txtFactorCalibracion.TextLength + 1).ToString()
        '    End If
        'End If
    End Sub
    Private Sub TextBoxDecimal_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
        If Not (Char.IsDigit(e.KeyChar) OrElse Char.IsControl(e.KeyChar) OrElse Asc(e.KeyChar) = 8 OrElse _
                    (e.KeyChar = CChar(".") AndAlso CType(sender, TextBox).Text.IndexOf(".") < 0)) Then
            e.Handled = True
        Else
            e.Handled = False
        End If
    End Sub


    Private Sub TextBox_KeyPress(ByVal sender As Object, ByVal e As KeyPressEventArgs) Handles txtDescuento.KeyPress, txtCliente.KeyPress
        If Not (Char.IsDigit(e.KeyChar) Or Asc(e.KeyChar) = 8 Or Char.IsControl(e.KeyChar)) Then
            e.Handled = True
        Else
            e.Handled = False
        End If
    End Sub
#End Region

    Private Sub CargaCliente(ByVal Cliente As Integer)        
        Factor = ""
        Porcentaje = ""
        Cursor = Cursors.WaitCursor
        Dim Celula As Integer = Nothing
        Dim Ruta As Integer = Nothing
        Dim strQuery As String = "spLOGConsultaDatosCliente"
        Dim cmd As New SqlCommand(strQuery, cnSigamet)
        cmd.CommandType = CommandType.StoredProcedure
        cmd.Parameters.Add("@Cliente", SqlDbType.Int).Value = Cliente
        Dim dr As SqlDataReader
        Try
            If cnSigamet.State = ConnectionState.Closed Then
                cnSigamet.Open()
            End If

            dr = cmd.ExecuteReader(CommandBehavior.CloseConnection)

            If dr.Read Then

                txtNombre.Text = dr("Nombre").ToString()
                Celula = CInt(dr("Celula"))
                txtCelula.Text = dr("CelulaDescripcion").ToString()
                Ruta = CInt(dr("Celula"))
                txtRuta.Text = dr("RutaDescripcion").ToString()
                txtDireccion.Text = dr("DirCompleta").ToString()
                txtDescuento.Text = dr("Descuento").ToString()                

                If IsDBNull(dr("Calibracion")) Then
                    txtFactorCalibracion.Text = ""
                    Factor = ""
                Else                    
                    txtFactorCalibracion.Text = dr("Calibracion").ToString()
                    Factor = dr("Calibracion").ToString()
                End If

                txtPorcentaje.Text = If(dr("PorcentajeCalibracion").ToString() = "NULL", "", dr("PorcentajeCalibracion").ToString())
                Porcentaje = If(dr("PorcentajeCalibracion").ToString() = "NULL", "", dr("PorcentajeCalibracion").ToString())
                If txtFactorCalibracion.Text <> "" Then
                    lblCantCaracteres.Text = (txtFactorCalibracion.TextLength).ToString()
                Else
                    lblCantCaracteres.Text = CStr(0)
                End If
            End If

        Catch ex As Exception
            MessageBox.Show(ex.Message, ex.Source, MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            cnSigamet.Close()
            Cursor = Cursors.Default()
            cmd.Dispose()

        End Try
    End Sub


    Private Sub btnBuscar_Click(sender As System.Object, e As System.EventArgs) Handles btnBuscar.Click
        Cursor = Cursors.WaitCursor
        Dim frmBuscar As New SigaMetClasses.BusquedaCliente()

        'frmBuscar.ClientesPortatil = GLOBAL_ManejarClientesPortatil
        If frmBuscar.ShowDialog = DialogResult.OK Then
            If frmBuscar.Cliente <> 0 Then
                txtCliente.Text = frmBuscar.Cliente.ToString()
                CargaCliente(CInt(txtCliente.Text))                
            End If

        End If
        Cursor = Cursors.Default
    End Sub

    Private Sub frmCapturaFactorCliente_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load

    End Sub

    Private Sub txtPorcentaje_TextChanged(sender As System.Object, e As System.EventArgs) Handles txtPorcentaje.TextChanged

    End Sub

    Private Sub txtPorcentaje_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtPorcentaje.KeyPress
        If Not (Char.IsDigit(e.KeyChar) OrElse Char.IsControl(e.KeyChar) OrElse Asc(e.KeyChar) = 8 OrElse _
                    (e.KeyChar = CChar(".") AndAlso CType(sender, TextBox).Text.IndexOf(".") < 0)) Then
            e.Handled = True            
        Else
            e.Handled = False
                End If
                NumeroDec(e, Me.txtPorcentaje)
    End Sub


    Public Function NumeroDec(ByVal e As System.Windows.Forms.KeyPressEventArgs, ByVal Text As TextBox) As Integer

        Dim dig As Integer = Len(Text.Text & e.KeyChar)

        Dim a, esDecimal, NumDecimales As Integer

        Dim esDec As Boolean



        If Char.IsDigit(e.KeyChar) Or e.KeyChar = "." Then

            e.Handled = False

        ElseIf Char.IsControl(e.KeyChar) Then

            e.Handled = False

            Return a

        Else

            e.Handled = True

        End If

        ' se verifica que el primer digito ingresado no sea un punto al seleccionar

        If Text.SelectedText <> "" Then

            If e.KeyChar = "." Then

                e.Handled = True

                Return a

            End If

        End If



        If dig = 1 And e.KeyChar = "." Then

            e.Handled = True

            Return a

        End If

        ' aqui se hace la verificacion cuando es seleccionado el valor del texto

        'y no sea considerado como la adicion de un digito mas al valor ya contenido en el textbox

        If Text.SelectedText = "" Then

            ' aqui se hace el for para controlar que el numero sea de dos digitos - contadose a partir del punto decimal.

            For a = 0 To dig - 1

                Dim car As String = CStr(Text.Text & e.KeyChar)

                If car.Substring(a, 1) = "." Then

                    esDecimal = esDecimal + 1

                    esDec = True

                End If

                If esDec = True Then

                    NumDecimales = NumDecimales + 1

                End If

                ' aqui se controla los digitos a partir del punto numdecimales = 4 si es de dos decimales 

                If NumDecimales >= 3 Or esDecimal >= 2 Then

                    e.Handled = True

                End If

            Next

        End If

    End Function

    'Function TieneCaracteres(ByVal cadena As String) As Boolean
    '    Dim i As Integer
    '    For i = 0 To cadena.Length - 1
    '        If cadena(i) <> " " Then
    '            Return True
    '        End If
    '    Next
    '    Return False
    'End Function

    Private Sub txtFactorCalibracion_KeyUp(sender As System.Object, e As System.Windows.Forms.KeyEventArgs) Handles txtFactorCalibracion.KeyUp
        lblCantCaracteres.Text = (txtFactorCalibracion.TextLength).ToString()
    End Sub
End Class
