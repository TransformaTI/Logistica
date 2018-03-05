Imports System.Data.SqlClient

Public Class frmPrestamoOperador
    Inherits System.Windows.Forms.Form

#Region " Windows Form Designer generated code "

    Public Sub New(ByVal Celula As Integer, ByVal Fecha As Date)
        MyBase.New()

        'This call is required by the Windows Form Designer.
        InitializeComponent()

        'Add any initialization after the InitializeComponent() call
        Dim daLogistica As New SqlDataAdapter("Select Celula, Descripcion from Celula where Comercial = 1 and Celula not in (@Celula,0) ", cnSigamet)
        Dim PKColumn(0) As DataColumn
        Dim dtCelula As New DataTable()
        Me.Text &= CStr(Celula)
        Me.Fecha = Fecha
        daLogistica.SelectCommand.Parameters.Add("@Celula", SqlDbType.TinyInt).Value = Celula
        daLogistica.SelectCommand.Parameters.Add("@Fecha", SqlDbType.DateTime).Value = Fecha
        Try
            daLogistica.Fill(dtCelula)
            daLogistica.SelectCommand.CommandText = "exec spLogOperadoresPrestables @Celula, @Fecha"
            daLogistica.Fill(dtOperador)
        Catch ex As Exception
            ExMessage(ex)
        Finally
            daLogistica.Dispose()
        End Try

        PKColumn(0) = dtOperador.Columns("Operador")
        dtOperador.PrimaryKey = PKColumn

        cboCelula.ValueMember = "Celula"
        cboCelula.DisplayMember = "Descripcion"
        cboCelula.DataSource = dtCelula

        scboNombre.ValueMember = "Operador"
        scboNombre.DisplayMember = "Nombre"
        scboNombre.DataSource = dtOperador

        scboOperador.ValueMember = "Operador"
        scboOperador.DisplayMember = "Operador"
        scboOperador.DataSource = dtOperador

        If Not scboOperador.SelectedValue Is Nothing Then
            Dim Key2Find As Object() = {scboOperador.SelectedValue}
            Dim FoundRow As DataRow = dtOperador.Rows.Find(Key2Find)
            scboOperador.SelectedValue = scboNombre.SelectedValue
            If Not FoundRow Is Nothing Then
                txtCategoria.Text = CStr(FoundRow("Categoria"))
                txtTipo.Text = CStr(FoundRow("Tipo"))
            End If
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
    Friend WithEvents rgrpDatosPrestamo As Logistica.RoundedGroupBox
    Friend WithEvents lblOperador As System.Windows.Forms.Label
    Friend WithEvents lblNombre As System.Windows.Forms.Label
    Friend WithEvents lblCategoria As System.Windows.Forms.Label
    Friend WithEvents lblTipo As System.Windows.Forms.Label
    Friend WithEvents lblCelula As System.Windows.Forms.Label
    Friend WithEvents scboNombre As Logistica.SelfCompletitionComboBox
    Friend WithEvents cboCelula As System.Windows.Forms.ComboBox
    Friend WithEvents txtCategoria As System.Windows.Forms.TextBox
    Friend WithEvents txtTipo As System.Windows.Forms.TextBox
    Friend WithEvents figLinea As Logistica.Figure
    Friend WithEvents scboOperador As Logistica.SelfCompletitionComboBox
    Friend WithEvents btnCancelar As System.Windows.Forms.Button
    Friend WithEvents btnAceptar As System.Windows.Forms.Button
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(frmPrestamoOperador))
        Me.rgrpDatosPrestamo = New Logistica.RoundedGroupBox()
        Me.scboOperador = New Logistica.SelfCompletitionComboBox()
        Me.txtTipo = New System.Windows.Forms.TextBox()
        Me.txtCategoria = New System.Windows.Forms.TextBox()
        Me.cboCelula = New System.Windows.Forms.ComboBox()
        Me.scboNombre = New Logistica.SelfCompletitionComboBox()
        Me.figLinea = New Logistica.Figure()
        Me.lblTipo = New System.Windows.Forms.Label()
        Me.lblCategoria = New System.Windows.Forms.Label()
        Me.lblNombre = New System.Windows.Forms.Label()
        Me.lblOperador = New System.Windows.Forms.Label()
        Me.lblCelula = New System.Windows.Forms.Label()
        Me.btnCancelar = New System.Windows.Forms.Button()
        Me.btnAceptar = New System.Windows.Forms.Button()
        Me.rgrpDatosPrestamo.SuspendLayout()
        Me.SuspendLayout()
        '
        'rgrpDatosPrestamo
        '
        Me.rgrpDatosPrestamo.BorderColor = System.Drawing.Color.DarkRed
        Me.rgrpDatosPrestamo.Controls.AddRange(New System.Windows.Forms.Control() {Me.scboOperador, Me.txtTipo, Me.txtCategoria, Me.cboCelula, Me.scboNombre, Me.figLinea, Me.lblTipo, Me.lblCategoria, Me.lblNombre, Me.lblOperador, Me.lblCelula})
        Me.rgrpDatosPrestamo.Dock = System.Windows.Forms.DockStyle.Left
        Me.rgrpDatosPrestamo.FlatStyle = Logistica.RoundedGroupBox.Style.Pipe
        Me.rgrpDatosPrestamo.ForeColor = System.Drawing.Color.DarkRed
        Me.rgrpDatosPrestamo.Location = New System.Drawing.Point(5, 5)
        Me.rgrpDatosPrestamo.Name = "rgrpDatosPrestamo"
        Me.rgrpDatosPrestamo.Size = New System.Drawing.Size(304, 173)
        Me.rgrpDatosPrestamo.TabIndex = 0
        Me.rgrpDatosPrestamo.TabStop = False
        Me.rgrpDatosPrestamo.Text = "Datos del prestamo"
        Me.rgrpDatosPrestamo.TextAlignment = System.Windows.Forms.HorizontalAlignment.Center
        '
        'scboOperador
        '
        Me.scboOperador.CorrectOnWriting = True
        Me.scboOperador.Location = New System.Drawing.Point(96, 29)
        Me.scboOperador.Name = "scboOperador"
        Me.scboOperador.Size = New System.Drawing.Size(192, 21)
        Me.scboOperador.TabIndex = 1
        Me.scboOperador.TrySimilarOnLeave = True
        '
        'txtTipo
        '
        Me.txtTipo.BackColor = System.Drawing.Color.White
        Me.txtTipo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtTipo.Location = New System.Drawing.Point(96, 104)
        Me.txtTipo.Name = "txtTipo"
        Me.txtTipo.ReadOnly = True
        Me.txtTipo.Size = New System.Drawing.Size(192, 21)
        Me.txtTipo.TabIndex = 4
        Me.txtTipo.TabStop = False
        Me.txtTipo.Text = ""
        '
        'txtCategoria
        '
        Me.txtCategoria.BackColor = System.Drawing.Color.White
        Me.txtCategoria.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtCategoria.Location = New System.Drawing.Point(96, 80)
        Me.txtCategoria.Name = "txtCategoria"
        Me.txtCategoria.ReadOnly = True
        Me.txtCategoria.Size = New System.Drawing.Size(192, 21)
        Me.txtCategoria.TabIndex = 3
        Me.txtCategoria.TabStop = False
        Me.txtCategoria.Text = ""
        '
        'cboCelula
        '
        Me.cboCelula.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboCelula.Location = New System.Drawing.Point(96, 143)
        Me.cboCelula.Name = "cboCelula"
        Me.cboCelula.Size = New System.Drawing.Size(192, 21)
        Me.cboCelula.TabIndex = 5
        '
        'scboNombre
        '
        Me.scboNombre.CorrectOnWriting = True
        Me.scboNombre.Location = New System.Drawing.Point(96, 55)
        Me.scboNombre.Name = "scboNombre"
        Me.scboNombre.Size = New System.Drawing.Size(192, 21)
        Me.scboNombre.TabIndex = 2
        Me.scboNombre.TrySimilarOnLeave = True
        '
        'figLinea
        '
        Me.figLinea.BackColor = System.Drawing.Color.LightSteelBlue
        Me.figLinea.FillColor = System.Drawing.SystemColors.Control
        Me.figLinea.LineColor = System.Drawing.Color.DarkRed
        Me.figLinea.LineWidth = 1
        Me.figLinea.Location = New System.Drawing.Point(20, 132)
        Me.figLinea.Name = "figLinea"
        Me.figLinea.Size = New System.Drawing.Size(264, 8)
        Me.figLinea.Style = Logistica.Figure.FigureStyle.Line
        Me.figLinea.TabIndex = 4
        Me.figLinea.TabStop = False
        '
        'lblTipo
        '
        Me.lblTipo.AutoSize = True
        Me.lblTipo.ForeColor = System.Drawing.Color.Black
        Me.lblTipo.Location = New System.Drawing.Point(16, 110)
        Me.lblTipo.Name = "lblTipo"
        Me.lblTipo.Size = New System.Drawing.Size(30, 14)
        Me.lblTipo.TabIndex = 3
        Me.lblTipo.Text = "Tipo:"
        '
        'lblCategoria
        '
        Me.lblCategoria.AutoSize = True
        Me.lblCategoria.ForeColor = System.Drawing.Color.Black
        Me.lblCategoria.Location = New System.Drawing.Point(16, 84)
        Me.lblCategoria.Name = "lblCategoria"
        Me.lblCategoria.Size = New System.Drawing.Size(56, 14)
        Me.lblCategoria.TabIndex = 2
        Me.lblCategoria.Text = "Categoria:"
        '
        'lblNombre
        '
        Me.lblNombre.AutoSize = True
        Me.lblNombre.ForeColor = System.Drawing.Color.Black
        Me.lblNombre.Location = New System.Drawing.Point(16, 58)
        Me.lblNombre.Name = "lblNombre"
        Me.lblNombre.Size = New System.Drawing.Size(48, 14)
        Me.lblNombre.TabIndex = 1
        Me.lblNombre.Text = "&Nombre:"
        '
        'lblOperador
        '
        Me.lblOperador.AutoSize = True
        Me.lblOperador.ForeColor = System.Drawing.Color.Black
        Me.lblOperador.Location = New System.Drawing.Point(16, 32)
        Me.lblOperador.Name = "lblOperador"
        Me.lblOperador.Size = New System.Drawing.Size(55, 14)
        Me.lblOperador.TabIndex = 0
        Me.lblOperador.Text = "&Operador:"
        '
        'lblCelula
        '
        Me.lblCelula.AutoSize = True
        Me.lblCelula.ForeColor = System.Drawing.Color.Black
        Me.lblCelula.Location = New System.Drawing.Point(16, 146)
        Me.lblCelula.Name = "lblCelula"
        Me.lblCelula.Size = New System.Drawing.Size(78, 14)
        Me.lblCelula.TabIndex = 4
        Me.lblCelula.Text = "Célula &destino:"
        '
        'btnCancelar
        '
        Me.btnCancelar.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnCancelar.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnCancelar.Image = CType(resources.GetObject("btnCancelar.Image"), System.Drawing.Bitmap)
        Me.btnCancelar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnCancelar.Location = New System.Drawing.Point(323, 50)
        Me.btnCancelar.Name = "btnCancelar"
        Me.btnCancelar.Size = New System.Drawing.Size(77, 24)
        Me.btnCancelar.TabIndex = 2
        Me.btnCancelar.Text = "&Cancelar"
        Me.btnCancelar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'btnAceptar
        '
        Me.btnAceptar.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnAceptar.Image = CType(resources.GetObject("btnAceptar.Image"), System.Drawing.Bitmap)
        Me.btnAceptar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnAceptar.Location = New System.Drawing.Point(323, 18)
        Me.btnAceptar.Name = "btnAceptar"
        Me.btnAceptar.Size = New System.Drawing.Size(77, 24)
        Me.btnAceptar.TabIndex = 1
        Me.btnAceptar.Text = "&Aceptar"
        Me.btnAceptar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'frmPrestamoOperador
        '
        Me.AcceptButton = Me.btnAceptar
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 14)
        Me.BackColor = System.Drawing.Color.Gainsboro
        Me.CancelButton = Me.btnCancelar
        Me.ClientSize = New System.Drawing.Size(418, 183)
        Me.Controls.AddRange(New System.Windows.Forms.Control() {Me.btnCancelar, Me.btnAceptar, Me.rgrpDatosPrestamo})
        Me.DockPadding.All = 5
        Me.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmPrestamoOperador"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Prestamo de operador de célula "
        Me.rgrpDatosPrestamo.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

#End Region

    Private Fecha As Date
    Dim dtOperador As New DataTable()

    
    Private Sub scboNombre_SelectedValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles scboNombre.SelectedValueChanged, scboNombre.Leave
        If Not scboNombre.SelectedItem Is Nothing AndAlso CInt(scboNombre.SelectedValue) <> CInt(scboOperador.SelectedValue) Then
            Dim Key2Find As Object() = {scboOperador.SelectedValue}
            Dim FoundRow As DataRow = dtOperador.Rows.Find(Key2Find)
            scboOperador.SelectedValue = scboNombre.SelectedValue
            If Not FoundRow Is Nothing Then
                txtCategoria.Text = CStr(FoundRow("Categoria"))
                txtTipo.Text = CStr(FoundRow("Tipo"))
            End If
        End If
    End Sub
    Private Sub scboOperador_SelectedValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles scboOperador.SelectedValueChanged, scboOperador.Leave
        If Not scboOperador.SelectedItem Is Nothing AndAlso CInt(scboNombre.SelectedValue) <> CInt(scboOperador.SelectedValue) Then
            Dim Key2Find As Object() = {scboOperador.SelectedValue}
            Dim FoundRow As DataRow = dtOperador.Rows.Find(Key2Find)
            scboNombre.SelectedValue = scboOperador.SelectedValue
            If Not FoundRow Is Nothing Then
                txtCategoria.Text = CStr(FoundRow("Categoria"))
                txtTipo.Text = CStr(FoundRow("Tipo"))
            End If
        End If
    End Sub

    Private Sub btnAceptar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAceptar.Click
        If Not scboNombre.SelectedItem Is Nothing AndAlso CInt(scboNombre.SelectedValue) <> CInt(scboOperador.SelectedValue) Then
            Dim Key2Find As Object() = {scboOperador.SelectedValue}
            Dim FoundRow As DataRow = dtOperador.Rows.Find(Key2Find)
            scboOperador.SelectedValue = scboNombre.SelectedValue
            If Not FoundRow Is Nothing Then
                txtCategoria.Text = CStr(FoundRow("Categoria"))
                txtTipo.Text = CStr(FoundRow("Tipo"))
            End If
        End If
        If Not scboOperador.SelectedItem Is Nothing AndAlso CInt(scboNombre.SelectedValue) <> CInt(scboOperador.SelectedValue) Then
            Dim Key2Find As Object() = {scboOperador.SelectedValue}
            Dim FoundRow As DataRow = dtOperador.Rows.Find(Key2Find)
            scboNombre.SelectedValue = scboOperador.SelectedValue
            If Not FoundRow Is Nothing Then
                txtCategoria.Text = CStr(FoundRow("Categoria"))
                txtTipo.Text = CStr(FoundRow("Tipo"))
            End If
        End If
        If Not scboOperador.SelectedItem Is Nothing Then
            If MessageBox.Show("¿Desea realizar el siguiente prestamo?" & Chr(13) & "     Operador: " & scboOperador.Text & " " & scboNombre.Text _
                            & Chr(13) & "     Célula destino: " & cboCelula.Text, Application.ProductName & " v." & Application.ProductVersion, MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
                Dim cmdLogistica As New SqlCommand("exec spLOGPrestamoOperador @Operador, @Fecha, @Celula, @Usuario", cnSigamet)
                cmdLogistica.Parameters.Add("@Operador", SqlDbType.Int).Value = CInt(scboOperador.SelectedValue)
                cmdLogistica.Parameters.Add("@Fecha", SqlDbType.DateTime).Value = Fecha
                cmdLogistica.Parameters.Add("@Celula", SqlDbType.TinyInt).Value = CInt(cboCelula.SelectedValue)
                cmdLogistica.Parameters.Add("@Usuario", SqlDbType.Char).Value = _Usuario
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
                End Try
            End If
        End If
    End Sub


End Class
