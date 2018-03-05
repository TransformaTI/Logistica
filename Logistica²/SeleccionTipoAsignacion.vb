Option Strict On

Public Class frmSeleccionTipoAsignacion
    Inherits System.Windows.Forms.Form

#Region " Windows Form Designer generated code "

    Public Sub New(ByVal Operador As Integer, ByVal Categoria As Integer)
        MyBase.New()

        'This call is required by the Windows Form Designer.
        InitializeComponent()

        'Add any initialization after the InitializeComponent() call
        Dim cmdLogistica As New SqlClient.SqlCommand("Select TipoAsignacionOperador, AplicaComision, Abordo, Descripcion from TipoAsignacionOperador order by Descripcion", cnSigamet)
        Dim daLogistica As New SqlClient.SqlDataAdapter(cmdLogistica)
        Dim dtCategoria As New DataTable()
        Dim PKColumn(0) As DataColumn
        txtOperador.Text = CStr(Operador)
        Try
            daLogistica.Fill(dtAsignacion)
            cmdLogistica.CommandText = "Select Descripcion, CategoriaOperador from CategoriaOperador "
            If Categoria > 3 AndAlso _ValidaRutaExpress Then
                cmdLogistica.CommandText &= " where CategoriaOperador > 3 order by Descripcion "
            Else
                cmdLogistica.CommandText &= " where CategoriaOperador < 3 order by Descripcion "
            End If
            daLogistica.Fill(dtCategoria)
        Catch ex As Exception
            ExMessage(ex)
        Finally
            cmdLogistica.Dispose()
            daLogistica.Dispose()
        End Try
        PKColumn(0) = dtAsignacion.Columns("TipoAsignacionOperador")
        dtAsignacion.PrimaryKey = PKColumn

        cboAsignacion.ValueMember = "TipoAsignacionOperador"
        cboAsignacion.DisplayMember = "Descripcion"
        cboAsignacion.DataSource = dtAsignacion

        cboCategoria.ValueMember = "CategoriaOperador"
        cboCategoria.DisplayMember = "Descripcion"
        cboCategoria.DataSource = dtCategoria

        cboCategoria.SelectedValue = Categoria

        If _AsignacionSuplente > 0 Then
            cboAsignacion.SelectedValue = _AsignacionSuplente
            cboAsignacion.Enabled = False
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
    Friend WithEvents btnAceptar As System.Windows.Forms.Button
    Friend WithEvents rgrpDatos As Logistica.RoundedGroupBox
    Friend WithEvents picComision As System.Windows.Forms.PictureBox
    Friend WithEvents picAbordo As System.Windows.Forms.PictureBox
    Friend WithEvents lblComision As System.Windows.Forms.Label
    Friend WithEvents cboCategoria As System.Windows.Forms.ComboBox
    Friend WithEvents cboAsignacion As System.Windows.Forms.ComboBox
    Friend WithEvents txtOperador As System.Windows.Forms.TextBox
    Friend WithEvents lblTipoAsignacion As System.Windows.Forms.Label
    Friend WithEvents lblCategoria As System.Windows.Forms.Label
    Friend WithEvents lblOperador As System.Windows.Forms.Label
    Friend WithEvents lblAbordo As System.Windows.Forms.Label
    Friend WithEvents btnCancelar As System.Windows.Forms.Button
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(frmSeleccionTipoAsignacion))
        Me.btnAceptar = New System.Windows.Forms.Button()
        Me.rgrpDatos = New Logistica.RoundedGroupBox()
        Me.picComision = New System.Windows.Forms.PictureBox()
        Me.picAbordo = New System.Windows.Forms.PictureBox()
        Me.lblComision = New System.Windows.Forms.Label()
        Me.cboCategoria = New System.Windows.Forms.ComboBox()
        Me.cboAsignacion = New System.Windows.Forms.ComboBox()
        Me.txtOperador = New System.Windows.Forms.TextBox()
        Me.lblTipoAsignacion = New System.Windows.Forms.Label()
        Me.lblCategoria = New System.Windows.Forms.Label()
        Me.lblOperador = New System.Windows.Forms.Label()
        Me.lblAbordo = New System.Windows.Forms.Label()
        Me.btnCancelar = New System.Windows.Forms.Button()
        Me.rgrpDatos.SuspendLayout()
        Me.SuspendLayout()
        '
        'btnAceptar
        '
        Me.btnAceptar.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.btnAceptar.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnAceptar.Image = CType(resources.GetObject("btnAceptar.Image"), System.Drawing.Bitmap)
        Me.btnAceptar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnAceptar.Location = New System.Drawing.Point(280, 16)
        Me.btnAceptar.Name = "btnAceptar"
        Me.btnAceptar.Size = New System.Drawing.Size(80, 24)
        Me.btnAceptar.TabIndex = 1
        Me.btnAceptar.Text = "&Aceptar"
        Me.btnAceptar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'rgrpDatos
        '
        Me.rgrpDatos.BorderColor = System.Drawing.Color.SteelBlue
        Me.rgrpDatos.Controls.AddRange(New System.Windows.Forms.Control() {Me.picComision, Me.picAbordo, Me.lblComision, Me.cboCategoria, Me.cboAsignacion, Me.txtOperador, Me.lblTipoAsignacion, Me.lblCategoria, Me.lblOperador, Me.lblAbordo})
        Me.rgrpDatos.Dock = System.Windows.Forms.DockStyle.Left
        Me.rgrpDatos.FlatStyle = Logistica.RoundedGroupBox.Style.Pipe
        Me.rgrpDatos.Location = New System.Drawing.Point(5, 5)
        Me.rgrpDatos.Name = "rgrpDatos"
        Me.rgrpDatos.Size = New System.Drawing.Size(267, 184)
        Me.rgrpDatos.TabIndex = 0
        Me.rgrpDatos.TabStop = False
        Me.rgrpDatos.TextAlignment = System.Windows.Forms.HorizontalAlignment.Left
        '
        'picComision
        '
        Me.picComision.BackColor = System.Drawing.Color.White
        Me.picComision.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.picComision.Image = CType(resources.GetObject("picComision.Image"), System.Drawing.Bitmap)
        Me.picComision.Location = New System.Drawing.Point(155, 145)
        Me.picComision.Name = "picComision"
        Me.picComision.Size = New System.Drawing.Size(16, 16)
        Me.picComision.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize
        Me.picComision.TabIndex = 22
        Me.picComision.TabStop = False
        '
        'picAbordo
        '
        Me.picAbordo.BackColor = System.Drawing.Color.White
        Me.picAbordo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.picAbordo.Image = CType(resources.GetObject("picAbordo.Image"), System.Drawing.Bitmap)
        Me.picAbordo.Location = New System.Drawing.Point(59, 145)
        Me.picAbordo.Name = "picAbordo"
        Me.picAbordo.Size = New System.Drawing.Size(16, 16)
        Me.picAbordo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize
        Me.picAbordo.TabIndex = 20
        Me.picAbordo.TabStop = False
        '
        'lblComision
        '
        Me.lblComision.BackColor = System.Drawing.Color.Transparent
        Me.lblComision.Location = New System.Drawing.Point(155, 145)
        Me.lblComision.Name = "lblComision"
        Me.lblComision.Size = New System.Drawing.Size(66, 16)
        Me.lblComision.TabIndex = 21
        Me.lblComision.Text = "Comision"
        Me.lblComision.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'cboCategoria
        '
        Me.cboCategoria.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboCategoria.Location = New System.Drawing.Point(93, 94)
        Me.cboCategoria.Name = "cboCategoria"
        Me.cboCategoria.Size = New System.Drawing.Size(152, 21)
        Me.cboCategoria.TabIndex = 2
        '
        'cboAsignacion
        '
        Me.cboAsignacion.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboAsignacion.Location = New System.Drawing.Point(93, 54)
        Me.cboAsignacion.Name = "cboAsignacion"
        Me.cboAsignacion.Size = New System.Drawing.Size(152, 21)
        Me.cboAsignacion.TabIndex = 1
        '
        'txtOperador
        '
        Me.txtOperador.BackColor = System.Drawing.Color.White
        Me.txtOperador.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtOperador.Location = New System.Drawing.Point(93, 20)
        Me.txtOperador.Name = "txtOperador"
        Me.txtOperador.ReadOnly = True
        Me.txtOperador.Size = New System.Drawing.Size(60, 21)
        Me.txtOperador.TabIndex = 16
        Me.txtOperador.TabStop = False
        Me.txtOperador.Text = ""
        '
        'lblTipoAsignacion
        '
        Me.lblTipoAsignacion.AutoSize = True
        Me.lblTipoAsignacion.Location = New System.Drawing.Point(21, 57)
        Me.lblTipoAsignacion.Name = "lblTipoAsignacion"
        Me.lblTipoAsignacion.Size = New System.Drawing.Size(61, 14)
        Me.lblTipoAsignacion.TabIndex = 0
        Me.lblTipoAsignacion.Text = "A&signacion:"
        '
        'lblCategoria
        '
        Me.lblCategoria.AutoSize = True
        Me.lblCategoria.Location = New System.Drawing.Point(21, 97)
        Me.lblCategoria.Name = "lblCategoria"
        Me.lblCategoria.Size = New System.Drawing.Size(56, 14)
        Me.lblCategoria.TabIndex = 1
        Me.lblCategoria.Text = "Ca&tegoria:"
        '
        'lblOperador
        '
        Me.lblOperador.AutoSize = True
        Me.lblOperador.Location = New System.Drawing.Point(21, 23)
        Me.lblOperador.Name = "lblOperador"
        Me.lblOperador.Size = New System.Drawing.Size(55, 14)
        Me.lblOperador.TabIndex = 13
        Me.lblOperador.Text = "Operador:"
        '
        'lblAbordo
        '
        Me.lblAbordo.BackColor = System.Drawing.Color.Transparent
        Me.lblAbordo.Location = New System.Drawing.Point(59, 145)
        Me.lblAbordo.Name = "lblAbordo"
        Me.lblAbordo.Size = New System.Drawing.Size(58, 16)
        Me.lblAbordo.TabIndex = 19
        Me.lblAbordo.Text = "Abordo"
        Me.lblAbordo.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'btnCancelar
        '
        Me.btnCancelar.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnCancelar.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnCancelar.Image = CType(resources.GetObject("btnCancelar.Image"), System.Drawing.Bitmap)
        Me.btnCancelar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnCancelar.Location = New System.Drawing.Point(280, 56)
        Me.btnCancelar.Name = "btnCancelar"
        Me.btnCancelar.Size = New System.Drawing.Size(80, 23)
        Me.btnCancelar.TabIndex = 2
        Me.btnCancelar.Text = "&Cancelar"
        Me.btnCancelar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'frmSeleccionTipoAsignacion
        '
        Me.AcceptButton = Me.btnAceptar
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 14)
        Me.BackColor = System.Drawing.Color.Gainsboro
        Me.CancelButton = Me.btnCancelar
        Me.ClientSize = New System.Drawing.Size(370, 194)
        Me.Controls.AddRange(New System.Windows.Forms.Control() {Me.btnCancelar, Me.rgrpDatos, Me.btnAceptar})
        Me.DockPadding.All = 5
        Me.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.Name = "frmSeleccionTipoAsignacion"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Selección de tipo de asignacion para más de 3 tripulantes"
        Me.rgrpDatos.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

#End Region


    Dim dtAsignacion As New DataTable()

    Private Sub cboAsignacion_SelectedValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboAsignacion.SelectedValueChanged
        If Not cboAsignacion.SelectedItem Is Nothing Then
            Dim FoundRow As DataRow
            FoundRow = dtAsignacion.Rows.Find(cboAsignacion.SelectedValue)
            picComision.Visible = CBool(FoundRow("AplicaComision"))
            picAbordo.Visible = CBool(FoundRow("Abordo"))
        End If
    End Sub


    Private Sub btnAceptar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAceptar.Click
        Me.DialogResult = DialogResult.OK
        Me.Close()
    End Sub
End Class
