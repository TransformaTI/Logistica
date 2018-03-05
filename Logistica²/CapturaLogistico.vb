Imports System
Imports System.Data
Imports System.Data.SqlClient

Public Class frmCapturaLogistico
    Inherits System.Windows.Forms.Form


#Region " Windows Form Designer generated code "

    Public Sub New(ByVal Celula As Integer, Optional ByVal Empleado As Integer = 0)
        MyBase.New()

        'This call is required by the Windows Form Designer.
        InitializeComponent()

        'Add any initialization after the InitializeComponent() call
        Dim cmdLogistica As New SqlCommand("Select * from CategoriaOperador where Supervisor = 1", cnSigamet)
        Dim daLogistica As New SqlDataAdapter(cmdLogistica)
        'Tablas para datos en combos
        Dim dtCategoria As New DataTable()
        Dim dtCelula As New DataTable()
        cmdLogistica.Parameters.Add("@Usuario", SqlDbType.Char).Value = _Usuario
        Try
            'Llenado de tablas
            daLogistica.Fill(dtCategoria)
            cmdLogistica.CommandText = "Select Celula, Descripcion from Celula where Comercial = 1 and Celula in (Select Celula from UsuarioCelula " _
         & " where Usuario = @Usuario)"
            daLogistica.Fill(dtCelula)
        Catch ex As Exception
            ExMessage(ex)
        End Try
        'Llenado de combos
        cboCategoria.ValueMember = "CategoriaOperador"
        cboCategoria.DisplayMember = "Descripcion"
        cboCategoria.DataSource = dtCategoria

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
        Me.Text = "Nuevo operador"
        If Empleado > 0 Then
            Me.Text = "Modificación de operador"
            txtEmpleado.Text = Empleado.ToString
            txtEmpleado.ReadOnly = True
            txtNombre.ReadOnly = True
            txtEmpleado.TabStop = False
            txtNombre.TabStop = False
            cboCategoria.Focus()
            CargaDatosOperador()
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
    Friend WithEvents btnAceptar As Windows.Forms.Button
    Friend WithEvents btnCancelar As Windows.Forms.Button
    Friend WithEvents rgrpDatos As Logistica.RoundedGroupBox
    Friend WithEvents lblNombre As System.Windows.Forms.Label
    Friend WithEvents cboCategoria As System.Windows.Forms.ComboBox
    Friend WithEvents lblEmpleado As System.Windows.Forms.Label
    Friend WithEvents lblCelula As System.Windows.Forms.Label
    Friend WithEvents lblCategoria As System.Windows.Forms.Label
    Friend WithEvents txtEmpleado As Windows.Forms.TextBox
    Friend WithEvents cboCelula As System.Windows.Forms.ComboBox
    Friend WithEvents txtNombre As Windows.Forms.TextBox
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(frmCapturaLogistico))
        Me.btnAceptar = New System.Windows.Forms.Button()
        Me.btnCancelar = New System.Windows.Forms.Button()
        Me.rgrpDatos = New Logistica.RoundedGroupBox()
        Me.lblNombre = New System.Windows.Forms.Label()
        Me.cboCategoria = New System.Windows.Forms.ComboBox()
        Me.lblEmpleado = New System.Windows.Forms.Label()
        Me.lblCelula = New System.Windows.Forms.Label()
        Me.lblCategoria = New System.Windows.Forms.Label()
        Me.txtEmpleado = New System.Windows.Forms.TextBox()
        Me.cboCelula = New System.Windows.Forms.ComboBox()
        Me.txtNombre = New System.Windows.Forms.TextBox()
        Me.rgrpDatos.SuspendLayout()
        Me.SuspendLayout()
        '
        'btnAceptar
        '
        Me.btnAceptar.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnAceptar.Image = CType(resources.GetObject("btnAceptar.Image"), System.Drawing.Bitmap)
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
        Me.btnCancelar.Image = CType(resources.GetObject("btnCancelar.Image"), System.Drawing.Bitmap)
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
        Me.rgrpDatos.Controls.AddRange(New System.Windows.Forms.Control() {Me.lblNombre, Me.cboCategoria, Me.lblEmpleado, Me.lblCelula, Me.lblCategoria, Me.txtEmpleado, Me.cboCelula, Me.txtNombre})
        Me.rgrpDatos.Dock = System.Windows.Forms.DockStyle.Left
        Me.rgrpDatos.FlatStyle = Logistica.RoundedGroupBox.Style.Pipe
        Me.rgrpDatos.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rgrpDatos.ForeColor = System.Drawing.Color.DarkBlue
        Me.rgrpDatos.Location = New System.Drawing.Point(3, 3)
        Me.rgrpDatos.Name = "rgrpDatos"
        Me.rgrpDatos.Size = New System.Drawing.Size(306, 137)
        Me.rgrpDatos.TabIndex = 0
        Me.rgrpDatos.TabStop = False
        Me.rgrpDatos.Text = "Datos del logístico"
        Me.rgrpDatos.TextAlignment = System.Windows.Forms.HorizontalAlignment.Center
        '
        'lblNombre
        '
        Me.lblNombre.AutoSize = True
        Me.lblNombre.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblNombre.ForeColor = System.Drawing.Color.Black
        Me.lblNombre.Location = New System.Drawing.Point(12, 53)
        Me.lblNombre.Name = "lblNombre"
        Me.lblNombre.Size = New System.Drawing.Size(54, 14)
        Me.lblNombre.TabIndex = 1
        Me.lblNombre.Text = "&Nombre:"
        '
        'cboCategoria
        '
        Me.cboCategoria.BackColor = System.Drawing.Color.White
        Me.cboCategoria.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboCategoria.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboCategoria.ForeColor = System.Drawing.Color.Black
        Me.cboCategoria.Location = New System.Drawing.Point(104, 78)
        Me.cboCategoria.Name = "cboCategoria"
        Me.cboCategoria.Size = New System.Drawing.Size(192, 21)
        Me.cboCategoria.TabIndex = 3
        '
        'lblEmpleado
        '
        Me.lblEmpleado.AutoSize = True
        Me.lblEmpleado.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblEmpleado.ForeColor = System.Drawing.Color.Black
        Me.lblEmpleado.Location = New System.Drawing.Point(12, 25)
        Me.lblEmpleado.Name = "lblEmpleado"
        Me.lblEmpleado.Size = New System.Drawing.Size(64, 14)
        Me.lblEmpleado.TabIndex = 0
        Me.lblEmpleado.Text = "&Empleado:"
        '
        'lblCelula
        '
        Me.lblCelula.AutoSize = True
        Me.lblCelula.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCelula.ForeColor = System.Drawing.Color.Black
        Me.lblCelula.Location = New System.Drawing.Point(12, 109)
        Me.lblCelula.Name = "lblCelula"
        Me.lblCelula.Size = New System.Drawing.Size(43, 14)
        Me.lblCelula.TabIndex = 4
        Me.lblCelula.Text = "Cé&lula:"
        '
        'lblCategoria
        '
        Me.lblCategoria.AutoSize = True
        Me.lblCategoria.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCategoria.ForeColor = System.Drawing.Color.Black
        Me.lblCategoria.Location = New System.Drawing.Point(12, 81)
        Me.lblCategoria.Name = "lblCategoria"
        Me.lblCategoria.Size = New System.Drawing.Size(63, 14)
        Me.lblCategoria.TabIndex = 2
        Me.lblCategoria.Text = "Cate&goria:"
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
        Me.txtEmpleado.TabIndex = 1
        Me.txtEmpleado.Text = ""
        '
        'cboCelula
        '
        Me.cboCelula.BackColor = System.Drawing.Color.White
        Me.cboCelula.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboCelula.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboCelula.ForeColor = System.Drawing.Color.Black
        Me.cboCelula.Location = New System.Drawing.Point(104, 106)
        Me.cboCelula.MaxDropDownItems = 30
        Me.cboCelula.Name = "cboCelula"
        Me.cboCelula.Size = New System.Drawing.Size(192, 21)
        Me.cboCelula.TabIndex = 5
        '
        'txtNombre
        '
        Me.txtNombre.BackColor = System.Drawing.Color.White
        Me.txtNombre.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtNombre.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtNombre.ForeColor = System.Drawing.Color.Black
        Me.txtNombre.Location = New System.Drawing.Point(104, 50)
        Me.txtNombre.MaxLength = 80
        Me.txtNombre.Name = "txtNombre"
        Me.txtNombre.Size = New System.Drawing.Size(192, 21)
        Me.txtNombre.TabIndex = 2
        Me.txtNombre.Text = ""
        '
        'frmCapturaLogistico
        '
        Me.AcceptButton = Me.btnAceptar
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 14)
        Me.BackColor = System.Drawing.Color.Gainsboro
        Me.CancelButton = Me.btnCancelar
        Me.ClientSize = New System.Drawing.Size(418, 143)
        Me.Controls.AddRange(New System.Windows.Forms.Control() {Me.rgrpDatos, Me.btnCancelar, Me.btnAceptar})
        Me.DockPadding.All = 3
        Me.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.MaximizeBox = False
        Me.MaximumSize = New System.Drawing.Size(424, 200)
        Me.MinimizeBox = False
        Me.MinimumSize = New System.Drawing.Size(424, 200)
        Me.Name = "frmCapturaLogistico"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.rgrpDatos.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

#End Region

#Region "Manejo de datos"
    Private Sub CargaDatosOperador()
        Dim cmdLogistica As New SqlCommand("select E.Nombre, O.CategoriaOperador, O.Celula " & _
                    "from Operador O inner join Empleado E on E.Empleado = O.Empleado where O.Operador = @Operador", cnSigamet)
        Dim rdrLogistica As SqlDataReader
        'Carga de parámetros
        cmdLogistica.Parameters.Add("@Operador", SqlDbType.Int).Value = CInt(txtEmpleado.Text)
        Try
            cnSigamet.Open()
            rdrLogistica = cmdLogistica.ExecuteReader
            If rdrLogistica.Read Then
                txtNombre.Text = Trim(CStr(rdrLogistica("Nombre")))
                cboCategoria.SelectedValue = rdrLogistica("CategoriaOperador")
                cboCelula.SelectedValue = rdrLogistica("Celula")
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
        If Trim(txtEmpleado.Text) = "" Then
            ErrMessage("No ha proporcionado el número de empleado del logístico.")
            txtEmpleado.Focus()
            Exit Sub
        End If
        If Trim(txtNombre.Text) = "" Then
            ErrMessage("No ha proporcionado el nombre del logistico.")
            txtNombre.Focus()
            Exit Sub
        End If
        

        Me.Cursor = Cursors.WaitCursor
        cmdLogistica = New SqlCommand("spLOGLogistico", cnSigamet)

        ' Asignación de parámetros
        cmdLogistica.CommandType = CommandType.StoredProcedure
        cmdLogistica.Parameters.Add("@Operador", SqlDbType.Int).Value = CInt(txtEmpleado.Text)
        cmdLogistica.Parameters.Add("@Nombre", SqlDbType.Char).Value = Trim(txtNombre.Text)
        cmdLogistica.Parameters.Add("@Categoria", SqlDbType.TinyInt).Value = CInt(cboCategoria.SelectedValue)
        cmdLogistica.Parameters.Add("@Celula", SqlDbType.TinyInt).Value = CInt(cboCelula.SelectedValue)
        cmdLogistica.Parameters.Add("@Nuevo", SqlDbType.Bit).Value = (Me.Text = "Nuevo operador")
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
    Private Sub TextBox_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtEmpleado.Enter, txtNombre.Enter
        CType(sender, TextBox).BackColor = Color.LightGoldenrodYellow
    End Sub
    Private Sub TextBox_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtEmpleado.Leave, txtNombre.Leave
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
                End If
            Catch ex As Exception
                ExMessage(ex)
            Finally
                cnSigamet.Close()
                cmdLogistica.Dispose()
            End Try
        End If
    End Sub
    Private Sub TextBox_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtEmpleado.KeyPress
        If Not (Char.IsDigit(e.KeyChar) Or Asc(e.KeyChar) = 8 Or Char.IsControl(e.KeyChar)) Then
            e.Handled = True
        Else
            e.Handled = False
        End If
    End Sub
#End Region

End Class
