Imports System.Data.SqlClient

Public Class frmAbrirCiclo
    Inherits System.Windows.Forms.Form

#Region " Windows Form Designer generated code "

    Public Sub New(ByVal Celula As Integer, ByVal Ruta As Integer, ByVal Autotanque As Integer)
        MyBase.New()

        'This call is required by the Windows Form Designer.
        InitializeComponent()

        'Add any initialization after the InitializeComponent() call
        Me.Celula = Celula : Me.Ruta = Ruta : Me.Autotanque = Autotanque
        txtCelula.Text = Celula.ToString
        txtRuta.Text = Ruta.ToString
        txtAutotanque.Text = Autotanque.ToString
        CargaDatosIniciales()
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
    Friend WithEvents rgrpDatos As Logistica.RoundedGroupBox
    Friend WithEvents lblCelula As System.Windows.Forms.Label
    Friend WithEvents lblRuta As System.Windows.Forms.Label
    Friend WithEvents lblAutotanque As System.Windows.Forms.Label
    Friend WithEvents figSeparador As Logistica.Figure
    Friend WithEvents lblPeso As System.Windows.Forms.Label
    Friend WithEvents lblLitros As System.Windows.Forms.Label
    Friend WithEvents lblPorcentaje As System.Windows.Forms.Label
    Friend WithEvents lblTotalizador As System.Windows.Forms.Label
    Friend WithEvents lblKilometraje As System.Windows.Forms.Label
    Friend WithEvents txtCelula As System.Windows.Forms.TextBox
    Friend WithEvents txtRuta As System.Windows.Forms.TextBox
    Friend WithEvents txtAutotanque As System.Windows.Forms.TextBox
    Friend WithEvents txtKilometraje As System.Windows.Forms.TextBox
    Friend WithEvents txtTotalizador As System.Windows.Forms.TextBox
    Friend WithEvents txtPorcentaje As System.Windows.Forms.TextBox
    Friend WithEvents txtLitros As System.Windows.Forms.TextBox
    Friend WithEvents txtPeso As System.Windows.Forms.TextBox
    Friend WithEvents lblSalida As System.Windows.Forms.Label
    Friend WithEvents btnAceptar As System.Windows.Forms.Button
    Friend WithEvents btnCancelar As System.Windows.Forms.Button
    Friend WithEvents dtpFSalida As System.Windows.Forms.DateTimePicker
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(frmAbrirCiclo))
        Me.rgrpDatos = New Logistica.RoundedGroupBox()
        Me.dtpFSalida = New System.Windows.Forms.DateTimePicker()
        Me.lblSalida = New System.Windows.Forms.Label()
        Me.txtPeso = New System.Windows.Forms.TextBox()
        Me.txtLitros = New System.Windows.Forms.TextBox()
        Me.txtPorcentaje = New System.Windows.Forms.TextBox()
        Me.txtTotalizador = New System.Windows.Forms.TextBox()
        Me.txtKilometraje = New System.Windows.Forms.TextBox()
        Me.txtAutotanque = New System.Windows.Forms.TextBox()
        Me.txtRuta = New System.Windows.Forms.TextBox()
        Me.txtCelula = New System.Windows.Forms.TextBox()
        Me.lblKilometraje = New System.Windows.Forms.Label()
        Me.lblTotalizador = New System.Windows.Forms.Label()
        Me.lblPorcentaje = New System.Windows.Forms.Label()
        Me.lblLitros = New System.Windows.Forms.Label()
        Me.lblPeso = New System.Windows.Forms.Label()
        Me.figSeparador = New Logistica.Figure()
        Me.lblCelula = New System.Windows.Forms.Label()
        Me.lblRuta = New System.Windows.Forms.Label()
        Me.lblAutotanque = New System.Windows.Forms.Label()
        Me.btnAceptar = New System.Windows.Forms.Button()
        Me.btnCancelar = New System.Windows.Forms.Button()
        Me.rgrpDatos.SuspendLayout()
        Me.SuspendLayout()
        '
        'rgrpDatos
        '
        Me.rgrpDatos.BorderColor = System.Drawing.Color.Brown
        Me.rgrpDatos.Controls.AddRange(New System.Windows.Forms.Control() {Me.dtpFSalida, Me.lblSalida, Me.txtPeso, Me.txtLitros, Me.txtPorcentaje, Me.txtTotalizador, Me.txtKilometraje, Me.txtAutotanque, Me.txtRuta, Me.txtCelula, Me.lblKilometraje, Me.lblTotalizador, Me.lblPorcentaje, Me.lblLitros, Me.lblPeso, Me.figSeparador, Me.lblCelula, Me.lblRuta, Me.lblAutotanque})
        Me.rgrpDatos.Dock = System.Windows.Forms.DockStyle.Left
        Me.rgrpDatos.FlatStyle = Logistica.RoundedGroupBox.Style.Pipe
        Me.rgrpDatos.ForeColor = System.Drawing.Color.Maroon
        Me.rgrpDatos.Location = New System.Drawing.Point(5, 5)
        Me.rgrpDatos.Name = "rgrpDatos"
        Me.rgrpDatos.Size = New System.Drawing.Size(219, 317)
        Me.rgrpDatos.TabIndex = 0
        Me.rgrpDatos.TabStop = False
        Me.rgrpDatos.Text = "Datos de inicio de ruta"
        Me.rgrpDatos.TextAlignment = System.Windows.Forms.HorizontalAlignment.Left
        '
        'dtpFSalida
        '
        Me.dtpFSalida.Format = System.Windows.Forms.DateTimePickerFormat.Short
        Me.dtpFSalida.Location = New System.Drawing.Point(96, 120)
        Me.dtpFSalida.Name = "dtpFSalida"
        Me.dtpFSalida.Size = New System.Drawing.Size(100, 21)
        Me.dtpFSalida.TabIndex = 1
        '
        'lblSalida
        '
        Me.lblSalida.AutoSize = True
        Me.lblSalida.ForeColor = System.Drawing.Color.Black
        Me.lblSalida.Location = New System.Drawing.Point(16, 123)
        Me.lblSalida.Name = "lblSalida"
        Me.lblSalida.Size = New System.Drawing.Size(38, 14)
        Me.lblSalida.TabIndex = 0
        Me.lblSalida.Text = "&Salida:"
        '
        'txtPeso
        '
        Me.txtPeso.BackColor = System.Drawing.Color.White
        Me.txtPeso.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtPeso.Location = New System.Drawing.Point(96, 285)
        Me.txtPeso.Name = "txtPeso"
        Me.txtPeso.TabIndex = 11
        Me.txtPeso.Text = ""
        '
        'txtLitros
        '
        Me.txtLitros.BackColor = System.Drawing.Color.White
        Me.txtLitros.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtLitros.Location = New System.Drawing.Point(96, 252)
        Me.txtLitros.Name = "txtLitros"
        Me.txtLitros.TabIndex = 9
        Me.txtLitros.Text = ""
        '
        'txtPorcentaje
        '
        Me.txtPorcentaje.BackColor = System.Drawing.Color.White
        Me.txtPorcentaje.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtPorcentaje.Location = New System.Drawing.Point(96, 219)
        Me.txtPorcentaje.Name = "txtPorcentaje"
        Me.txtPorcentaje.TabIndex = 7
        Me.txtPorcentaje.Text = ""
        '
        'txtTotalizador
        '
        Me.txtTotalizador.BackColor = System.Drawing.Color.White
        Me.txtTotalizador.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtTotalizador.Location = New System.Drawing.Point(96, 186)
        Me.txtTotalizador.Name = "txtTotalizador"
        Me.txtTotalizador.TabIndex = 5
        Me.txtTotalizador.Text = ""
        '
        'txtKilometraje
        '
        Me.txtKilometraje.BackColor = System.Drawing.Color.White
        Me.txtKilometraje.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtKilometraje.Location = New System.Drawing.Point(96, 153)
        Me.txtKilometraje.Name = "txtKilometraje"
        Me.txtKilometraje.TabIndex = 3
        Me.txtKilometraje.Text = ""
        '
        'txtAutotanque
        '
        Me.txtAutotanque.BackColor = System.Drawing.Color.Gainsboro
        Me.txtAutotanque.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtAutotanque.Location = New System.Drawing.Point(96, 74)
        Me.txtAutotanque.Name = "txtAutotanque"
        Me.txtAutotanque.ReadOnly = True
        Me.txtAutotanque.TabIndex = 15
        Me.txtAutotanque.TabStop = False
        Me.txtAutotanque.Text = ""
        '
        'txtRuta
        '
        Me.txtRuta.BackColor = System.Drawing.Color.Gainsboro
        Me.txtRuta.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtRuta.Location = New System.Drawing.Point(96, 50)
        Me.txtRuta.Name = "txtRuta"
        Me.txtRuta.ReadOnly = True
        Me.txtRuta.TabIndex = 14
        Me.txtRuta.TabStop = False
        Me.txtRuta.Text = ""
        '
        'txtCelula
        '
        Me.txtCelula.BackColor = System.Drawing.Color.Gainsboro
        Me.txtCelula.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtCelula.Location = New System.Drawing.Point(96, 26)
        Me.txtCelula.Name = "txtCelula"
        Me.txtCelula.ReadOnly = True
        Me.txtCelula.TabIndex = 13
        Me.txtCelula.TabStop = False
        Me.txtCelula.Text = ""
        '
        'lblKilometraje
        '
        Me.lblKilometraje.AutoSize = True
        Me.lblKilometraje.ForeColor = System.Drawing.Color.Black
        Me.lblKilometraje.Location = New System.Drawing.Point(16, 156)
        Me.lblKilometraje.Name = "lblKilometraje"
        Me.lblKilometraje.Size = New System.Drawing.Size(65, 14)
        Me.lblKilometraje.TabIndex = 2
        Me.lblKilometraje.Text = "&Kilometraje:"
        '
        'lblTotalizador
        '
        Me.lblTotalizador.AutoSize = True
        Me.lblTotalizador.ForeColor = System.Drawing.Color.Black
        Me.lblTotalizador.Location = New System.Drawing.Point(16, 189)
        Me.lblTotalizador.Name = "lblTotalizador"
        Me.lblTotalizador.Size = New System.Drawing.Size(63, 14)
        Me.lblTotalizador.TabIndex = 4
        Me.lblTotalizador.Text = "&Totalizador:"
        '
        'lblPorcentaje
        '
        Me.lblPorcentaje.AutoSize = True
        Me.lblPorcentaje.ForeColor = System.Drawing.Color.Black
        Me.lblPorcentaje.Location = New System.Drawing.Point(16, 222)
        Me.lblPorcentaje.Name = "lblPorcentaje"
        Me.lblPorcentaje.Size = New System.Drawing.Size(61, 14)
        Me.lblPorcentaje.TabIndex = 6
        Me.lblPorcentaje.Text = "&Porcentaje:"
        '
        'lblLitros
        '
        Me.lblLitros.AutoSize = True
        Me.lblLitros.ForeColor = System.Drawing.Color.Black
        Me.lblLitros.Location = New System.Drawing.Point(16, 255)
        Me.lblLitros.Name = "lblLitros"
        Me.lblLitros.Size = New System.Drawing.Size(35, 14)
        Me.lblLitros.TabIndex = 8
        Me.lblLitros.Text = "Litros:"
        '
        'lblPeso
        '
        Me.lblPeso.AutoSize = True
        Me.lblPeso.ForeColor = System.Drawing.Color.Black
        Me.lblPeso.Location = New System.Drawing.Point(16, 288)
        Me.lblPeso.Name = "lblPeso"
        Me.lblPeso.Size = New System.Drawing.Size(32, 14)
        Me.lblPeso.TabIndex = 10
        Me.lblPeso.Text = "Peso:"
        '
        'figSeparador
        '
        Me.figSeparador.FillColor = System.Drawing.Color.LightSteelBlue
        Me.figSeparador.LineColor = System.Drawing.Color.Maroon
        Me.figSeparador.LineWidth = 2.0!
        Me.figSeparador.Location = New System.Drawing.Point(16, 104)
        Me.figSeparador.Name = "figSeparador"
        Me.figSeparador.Size = New System.Drawing.Size(184, 8)
        Me.figSeparador.Style = Logistica.Figure.FigureStyle.Line
        Me.figSeparador.TabIndex = 1
        '
        'lblCelula
        '
        Me.lblCelula.AutoSize = True
        Me.lblCelula.ForeColor = System.Drawing.Color.Black
        Me.lblCelula.Location = New System.Drawing.Point(16, 29)
        Me.lblCelula.Name = "lblCelula"
        Me.lblCelula.Size = New System.Drawing.Size(38, 14)
        Me.lblCelula.TabIndex = 10
        Me.lblCelula.Text = "Celula:"
        '
        'lblRuta
        '
        Me.lblRuta.AutoSize = True
        Me.lblRuta.ForeColor = System.Drawing.Color.Black
        Me.lblRuta.Location = New System.Drawing.Point(16, 53)
        Me.lblRuta.Name = "lblRuta"
        Me.lblRuta.Size = New System.Drawing.Size(31, 14)
        Me.lblRuta.TabIndex = 11
        Me.lblRuta.Text = "Ruta:"
        '
        'lblAutotanque
        '
        Me.lblAutotanque.AutoSize = True
        Me.lblAutotanque.ForeColor = System.Drawing.Color.Black
        Me.lblAutotanque.Location = New System.Drawing.Point(16, 77)
        Me.lblAutotanque.Name = "lblAutotanque"
        Me.lblAutotanque.Size = New System.Drawing.Size(66, 14)
        Me.lblAutotanque.TabIndex = 12
        Me.lblAutotanque.Text = "Autotanque:"
        '
        'btnAceptar
        '
        Me.btnAceptar.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnAceptar.Image = CType(resources.GetObject("btnAceptar.Image"), System.Drawing.Bitmap)
        Me.btnAceptar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnAceptar.Location = New System.Drawing.Point(232, 16)
        Me.btnAceptar.Name = "btnAceptar"
        Me.btnAceptar.TabIndex = 1
        Me.btnAceptar.Text = "&Aceptar"
        Me.btnAceptar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'btnCancelar
        '
        Me.btnCancelar.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnCancelar.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnCancelar.Image = CType(resources.GetObject("btnCancelar.Image"), System.Drawing.Bitmap)
        Me.btnCancelar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnCancelar.Location = New System.Drawing.Point(232, 56)
        Me.btnCancelar.Name = "btnCancelar"
        Me.btnCancelar.TabIndex = 2
        Me.btnCancelar.Text = "&Cancelar"
        Me.btnCancelar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'frmAbrirCiclo
        '
        Me.AcceptButton = Me.btnAceptar
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 14)
        Me.BackColor = System.Drawing.Color.Gainsboro
        Me.CancelButton = Me.btnCancelar
        Me.ClientSize = New System.Drawing.Size(314, 327)
        Me.Controls.AddRange(New System.Windows.Forms.Control() {Me.btnCancelar, Me.btnAceptar, Me.rgrpDatos})
        Me.DockPadding.All = 5
        Me.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmAbrirCiclo"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "AbrirCiclo"
        Me.rgrpDatos.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

#End Region

    Private Celula, Ruta, Autotanque As Integer

    Private Sub CargaDatosIniciales()
        Dim cmdLogistica As New SqlCommand("select * from vwBASInicioAutotmaticoCiclo where Celula = @Celula " & _
                    " and Ruta = @Ruta and Autotanque = @Autotanque", cnSigamet)
        Dim Ini As SqlDataReader
        cmdLogistica.Parameters.Add("@Celula", SqlDbType.TinyInt).Value = Celula
        cmdLogistica.Parameters.Add("@Ruta", SqlDbType.SmallInt).Value = Ruta
        cmdLogistica.Parameters.Add("@Autotanque", SqlDbType.Int).Value = Autotanque
        Try
            cnSigamet.Open()
            Ini = cmdLogistica.ExecuteReader
            If Ini.Read Then
                txtKilometraje.Text = CStr(Ini("KilometrajeInicial"))
                txtTotalizador.Text = CStr(Ini("TotalizadorInicial"))
                txtPorcentaje.Text = CStr(Ini("PorcentajeGasInicial"))
                txtLitros.Text = CStr(Ini("LitrosGasInicial"))
                txtPeso.Text = CStr(Ini("PesoSalida"))
            End If
        Catch ex As Exception
            ExMessage(ex)
        Finally
            cnSigamet.Close()
        End Try
    End Sub

    Private Sub TextBox_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtKilometraje.Enter, txtTotalizador.Enter, _
                            txtPorcentaje.Enter, txtLitros.Enter, txtPeso.Enter
        CType(sender, TextBox).BackColor = Color.LemonChiffon
        CType(sender, TextBox).SelectAll()
    End Sub
    Private Sub TextBox_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtKilometraje.Leave, txtTotalizador.Leave, _
                            txtPorcentaje.Leave, txtLitros.Leave, txtPeso.Leave
        CType(sender, TextBox).BackColor = Color.White
    End Sub

    Private Sub TextBoxDecimal_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtKilometraje.KeyPress, txtTotalizador.KeyPress, _
                            txtPorcentaje.KeyPress, txtLitros.KeyPress, txtPeso.KeyPress
        If Not (Char.IsDigit(e.KeyChar) OrElse Char.IsControl(e.KeyChar) OrElse Asc(e.KeyChar) = 8 OrElse _
                    (e.KeyChar = CChar(".") AndAlso CType(sender, TextBox).Text.IndexOf(".") < 0)) Then
            e.Handled = True
        Else
            e.Handled = False
        End If
    End Sub

    Private Sub btnAceptar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAceptar.Click
        AbreCiclo()
    End Sub

    Private Sub AbreCiclo()
        Dim cmdBascula As New SqlCommand("Select count(Folio) from AutotanqueTurno where Autotanque = @Autotanque and FInicioRuta = @FInicioRuta", cnSigamet)
        Dim Existentes As Integer
        cmdBascula.Parameters.Add("@Año", SqlDbType.SmallInt).Value = dtpFSalida.Value.Year
        cmdBascula.Parameters.Add("@FInicioRuta", SqlDbType.DateTime).Value = dtpFSalida.Value.Date
        cmdBascula.Parameters.Add("@ObservacionesInicioRuta", SqlDbType.VarChar).Value = "Apertura automática"
        cmdBascula.Parameters.Add("@Folio", SqlDbType.Int).Value = 0
        cmdBascula.Parameters.Add("@Celula", SqlDbType.TinyInt).Value = Celula
        cmdBascula.Parameters.Add("@Autotanque", SqlDbType.SmallInt).Value = Autotanque
        cmdBascula.Parameters.Add("@Ruta", SqlDbType.SmallInt).Value = Ruta
        cmdBascula.Parameters.Add("@KilometrajeInicial", SqlDbType.Int).Value = CInt(Val(txtKilometraje.Text))
        cmdBascula.Parameters.Add("@TotalizadorInicial", SqlDbType.Decimal).Value = Val(txtTotalizador.Text)
        cmdBascula.Parameters.Add("@PorcentajeGasInicial", SqlDbType.Decimal).Value = Val(txtPorcentaje.Text)
        cmdBascula.Parameters.Add("@LitrosGasInicial", SqlDbType.Decimal).Value = Val(txtLitros.Text)
        cmdBascula.Parameters.Add("@PesoSalida", SqlDbType.Decimal).Value = Val(txtPeso.Text)
        Me.Cursor = Cursors.WaitCursor
        Try
            cnSigamet.Open()
            Existentes = CInt(cmdBascula.ExecuteScalar)
            If Existentes = 0 OrElse MessageBox.Show("Ya existe un ciclo para la fecha seleccionada." & Chr(13) & _
                                "¿Desea continuar?", Application.ProductName & " v." & Application.ProductVersion, _
                                MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) = DialogResult.Yes Then
                cmdBascula.CommandText = "spBASAbreCiclo"
                cmdBascula.CommandType = CommandType.StoredProcedure
                cmdBascula.ExecuteNonQuery()
                MessageBox.Show("Se han abierto el cilos seleccionado.", Application.ProductName & " v." & Application.ProductVersion, MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If
            Me.Close()
            Me.Dispose()
        Catch ex As Exception
            ExMessage(ex)
        Finally
            cnSigamet.Close()
            Me.Cursor = Cursors.Default
        End Try

    End Sub
End Class
