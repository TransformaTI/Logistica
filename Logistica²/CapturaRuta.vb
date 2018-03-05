Imports System.Data.SqlClient

Public Class frmCapturaRuta
    Inherits System.Windows.Forms.Form
    Dim dtUsuarioMovil As New DataTable()
#Region " Windows Form Designer generated code "

    Public Sub New(ByVal Celula As Integer, Optional ByVal Ruta As Integer = 0, Optional ByVal Clase As Integer = 0, Optional ByVal UsuarioMovil As String = "", Optional ByVal RutaDesc As String = "")
        MyBase.New()

        'This call is required by the Windows Form Designer.
        InitializeComponent()

        CargaInformacionUsuarioMovil()

        'Add any initialization after the InitializeComponent() call
        Dim cmdLogistica As New SqlCommand("Select C.Celula as Celula, ltrim(rtrim(C.Descripcion)) as Descripcion from Celula C inner join UsuarioCelula UC " _
                             & " on C.Celula = UC.Celula and UC.Usuario = @Usuario and C.Comercial = 1", cnSigamet)
        Dim daLogistica As New SqlDataAdapter(cmdLogistica)
        Dim dtCelula As New DataTable()
        Dim dtClaseRuta As New DataTable()
        cmdLogistica.Parameters.Add("@Usuario", SqlDbType.Char).Value = _Usuario
        Try
            daLogistica.Fill(dtCelula)

            cmdLogistica.CommandText = "Select ClaseRuta, Descripcion from ClaseRuta order by Descripcion"
            daLogistica.Fill(dtClaseRuta)
        Catch ex As Exception
            ExMessage(ex)
        End Try

        cboCelula.ValueMember = "Celula"
        cboCelula.DisplayMember = "Descripcion"
        cboCelula.DataSource = dtCelula

        cboClase.ValueMember = "ClaseRuta"
        cboClase.DisplayMember = "Descripcion"
        cboClase.DataSource = dtClaseRuta

        cmdLogistica.Dispose()
        daLogistica.Dispose()

        Me.Text = "Nueva ruta"
        cboCelula.SelectedValue = Celula

        If Ruta > 0 Then
            txtRuta.Text = Ruta.ToString
            cboClase.SelectedValue = Clase
            txtRuta.Enabled = False
            txtDescripcionRuta.Text = RutaDesc            
            Me.Text = "Modificación de ruta"

            If UsuarioMovil <> "" Then
                If cboUsuarioMovil.Items.Count > 0 Then
                    cboUsuarioMovil.SelectedValue = UsuarioMovil
                End If
            Else
                If cboUsuarioMovil.Items.Count > 0 Then
                    cboUsuarioMovil.SelectedIndex = -1
                End If
            End If


        Else
            If cboUsuarioMovil.Items.Count > 0 Then
                cboUsuarioMovil.SelectedIndex = -1
            End If
        End If

    End Sub
    Public Sub CargaInformacionUsuarioMovil()

        Dim daLogistica As New SqlDataAdapter("spLOGConsultaUsuarioMovil", cnSigamet)
        cboUsuarioMovil.DataSource = Nothing
       
        Try
            dtUsuarioMovil.Clear()
            daLogistica.Fill(dtUsuarioMovil)

            cboUsuarioMovil.ValueMember = "IdUsuario"
            cboUsuarioMovil.DisplayMember = "Nombre"
            cboUsuarioMovil.DataSource = dtUsuarioMovil

        Catch ex As Exception
            ExMessage(ex)
        End Try
        'End If
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
    Friend WithEvents btnCancelar As System.Windows.Forms.Button
    Friend WithEvents btnAceptar As System.Windows.Forms.Button
    Friend WithEvents lblRuta As System.Windows.Forms.Label
    Friend WithEvents lblCelula As System.Windows.Forms.Label
    Friend WithEvents lblClase As System.Windows.Forms.Label
    Friend WithEvents txtRuta As System.Windows.Forms.TextBox
    Friend WithEvents cboCelula As System.Windows.Forms.ComboBox
    Friend WithEvents lblUsuarioMovil As System.Windows.Forms.Label
    Friend WithEvents cboUsuarioMovil As System.Windows.Forms.ComboBox
    Friend WithEvents txtDescripcionRuta As System.Windows.Forms.TextBox
    Friend WithEvents lblDescripcionRuta As System.Windows.Forms.Label
    Friend WithEvents cboClase As System.Windows.Forms.ComboBox
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmCapturaRuta))
        Me.rgrpDatos = New Logistica.RoundedGroupBox()
        Me.txtDescripcionRuta = New System.Windows.Forms.TextBox()
        Me.lblDescripcionRuta = New System.Windows.Forms.Label()
        Me.cboUsuarioMovil = New System.Windows.Forms.ComboBox()
        Me.lblUsuarioMovil = New System.Windows.Forms.Label()
        Me.cboClase = New System.Windows.Forms.ComboBox()
        Me.cboCelula = New System.Windows.Forms.ComboBox()
        Me.txtRuta = New System.Windows.Forms.TextBox()
        Me.lblClase = New System.Windows.Forms.Label()
        Me.lblCelula = New System.Windows.Forms.Label()
        Me.lblRuta = New System.Windows.Forms.Label()
        Me.btnCancelar = New System.Windows.Forms.Button()
        Me.btnAceptar = New System.Windows.Forms.Button()
        Me.rgrpDatos.SuspendLayout()
        Me.SuspendLayout()
        '
        'rgrpDatos
        '
        Me.rgrpDatos.BorderColor = System.Drawing.Color.SteelBlue
        Me.rgrpDatos.Controls.Add(Me.txtDescripcionRuta)
        Me.rgrpDatos.Controls.Add(Me.lblDescripcionRuta)
        Me.rgrpDatos.Controls.Add(Me.cboUsuarioMovil)
        Me.rgrpDatos.Controls.Add(Me.lblUsuarioMovil)
        Me.rgrpDatos.Controls.Add(Me.cboClase)
        Me.rgrpDatos.Controls.Add(Me.cboCelula)
        Me.rgrpDatos.Controls.Add(Me.txtRuta)
        Me.rgrpDatos.Controls.Add(Me.lblClase)
        Me.rgrpDatos.Controls.Add(Me.lblCelula)
        Me.rgrpDatos.Controls.Add(Me.lblRuta)
        Me.rgrpDatos.Dock = System.Windows.Forms.DockStyle.Left
        Me.rgrpDatos.ForeColor = System.Drawing.Color.DarkBlue
        Me.rgrpDatos.Location = New System.Drawing.Point(3, 0)
        Me.rgrpDatos.Name = "rgrpDatos"
        Me.rgrpDatos.Size = New System.Drawing.Size(246, 164)
        Me.rgrpDatos.TabIndex = 0
        Me.rgrpDatos.TabStop = False
        Me.rgrpDatos.Text = "Datos de la ruta"
        Me.rgrpDatos.TextAlignment = System.Windows.Forms.HorizontalAlignment.Center
        '
        'txtDescripcionRuta
        '
        Me.txtDescripcionRuta.BackColor = System.Drawing.Color.White
        Me.txtDescripcionRuta.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtDescripcionRuta.Location = New System.Drawing.Point(96, 52)
        Me.txtDescripcionRuta.MaxLength = 20
        Me.txtDescripcionRuta.Name = "txtDescripcionRuta"
        Me.txtDescripcionRuta.Size = New System.Drawing.Size(138, 21)
        Me.txtDescripcionRuta.TabIndex = 2
        '
        'lblDescripcionRuta
        '
        Me.lblDescripcionRuta.AutoSize = True
        Me.lblDescripcionRuta.Location = New System.Drawing.Point(16, 55)
        Me.lblDescripcionRuta.Name = "lblDescripcionRuta"
        Me.lblDescripcionRuta.Size = New System.Drawing.Size(65, 13)
        Me.lblDescripcionRuta.TabIndex = 6
        Me.lblDescripcionRuta.Text = "&Descripción:"
        '
        'cboUsuarioMovil
        '
        Me.cboUsuarioMovil.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboUsuarioMovil.FormattingEnabled = True
        Me.cboUsuarioMovil.Location = New System.Drawing.Point(97, 133)
        Me.cboUsuarioMovil.Name = "cboUsuarioMovil"
        Me.cboUsuarioMovil.Size = New System.Drawing.Size(137, 21)
        Me.cboUsuarioMovil.TabIndex = 5
        '
        'lblUsuarioMovil
        '
        Me.lblUsuarioMovil.AutoSize = True
        Me.lblUsuarioMovil.Location = New System.Drawing.Point(17, 136)
        Me.lblUsuarioMovil.Name = "lblUsuarioMovil"
        Me.lblUsuarioMovil.Size = New System.Drawing.Size(74, 13)
        Me.lblUsuarioMovil.TabIndex = 4
        Me.lblUsuarioMovil.Text = "&Usuario Móvil:"
        '
        'cboClase
        '
        Me.cboClase.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboClase.Location = New System.Drawing.Point(96, 106)
        Me.cboClase.Name = "cboClase"
        Me.cboClase.Size = New System.Drawing.Size(138, 21)
        Me.cboClase.TabIndex = 4
        '
        'cboCelula
        '
        Me.cboCelula.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboCelula.Location = New System.Drawing.Point(96, 79)
        Me.cboCelula.Name = "cboCelula"
        Me.cboCelula.Size = New System.Drawing.Size(138, 21)
        Me.cboCelula.TabIndex = 3
        '
        'txtRuta
        '
        Me.txtRuta.BackColor = System.Drawing.Color.White
        Me.txtRuta.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtRuta.Location = New System.Drawing.Point(95, 25)
        Me.txtRuta.Name = "txtRuta"
        Me.txtRuta.Size = New System.Drawing.Size(138, 21)
        Me.txtRuta.TabIndex = 1
        '
        'lblClase
        '
        Me.lblClase.AutoSize = True
        Me.lblClase.Location = New System.Drawing.Point(19, 109)
        Me.lblClase.Name = "lblClase"
        Me.lblClase.Size = New System.Drawing.Size(37, 13)
        Me.lblClase.TabIndex = 2
        Me.lblClase.Text = "Cla&se:"
        '
        'lblCelula
        '
        Me.lblCelula.AutoSize = True
        Me.lblCelula.Location = New System.Drawing.Point(16, 82)
        Me.lblCelula.Name = "lblCelula"
        Me.lblCelula.Size = New System.Drawing.Size(40, 13)
        Me.lblCelula.TabIndex = 1
        Me.lblCelula.Text = "Ce&lula:"
        '
        'lblRuta
        '
        Me.lblRuta.AutoSize = True
        Me.lblRuta.Location = New System.Drawing.Point(15, 28)
        Me.lblRuta.Name = "lblRuta"
        Me.lblRuta.Size = New System.Drawing.Size(34, 13)
        Me.lblRuta.TabIndex = 0
        Me.lblRuta.Text = "&Ruta:"
        '
        'btnCancelar
        '
        Me.btnCancelar.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnCancelar.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnCancelar.Image = CType(resources.GetObject("btnCancelar.Image"), System.Drawing.Image)
        Me.btnCancelar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnCancelar.Location = New System.Drawing.Point(255, 57)
        Me.btnCancelar.Name = "btnCancelar"
        Me.btnCancelar.Size = New System.Drawing.Size(75, 24)
        Me.btnCancelar.TabIndex = 7
        Me.btnCancelar.Text = "&Cancelar"
        Me.btnCancelar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'btnAceptar
        '
        Me.btnAceptar.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnAceptar.Image = CType(resources.GetObject("btnAceptar.Image"), System.Drawing.Image)
        Me.btnAceptar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnAceptar.Location = New System.Drawing.Point(255, 17)
        Me.btnAceptar.Name = "btnAceptar"
        Me.btnAceptar.Size = New System.Drawing.Size(75, 24)
        Me.btnAceptar.TabIndex = 6
        Me.btnAceptar.Text = "&Aceptar"
        Me.btnAceptar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'frmCapturaRuta
        '
        Me.AcceptButton = Me.btnAceptar
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 14)
        Me.BackColor = System.Drawing.Color.Gainsboro
        Me.CancelButton = Me.btnCancelar
        Me.ClientSize = New System.Drawing.Size(338, 167)
        Me.Controls.Add(Me.btnCancelar)
        Me.Controls.Add(Me.btnAceptar)
        Me.Controls.Add(Me.rgrpDatos)
        Me.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmCapturaRuta"
        Me.Padding = New System.Windows.Forms.Padding(3, 0, 0, 3)
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.rgrpDatos.ResumeLayout(False)
        Me.rgrpDatos.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

#End Region

    Private Sub txtRuta_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtRuta.Enter
        If txtRuta.Enabled Then
            txtRuta.BackColor = Color.LightGoldenrodYellow
        End If
    End Sub
    Private Sub txtRuta_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtRuta.Leave
        If txtRuta.Enabled Then
            txtRuta.BackColor = Color.White
        End If
    End Sub
    Private Sub txtRuta_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtRuta.KeyPress
        If Not (Char.IsDigit(e.KeyChar) OrElse Asc(e.KeyChar) = 8 OrElse Char.IsControl(e.KeyChar)) OrElse (txtRuta.Text.Trim.Length = 3 AndAlso Asc(e.KeyChar) <> 8) Then
            e.Handled = True
        Else
            e.Handled = False
        End If
    End Sub

    Private Sub btnAceptar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAceptar.Click
        Dim cmdLogistica As New SqlCommand("spLOGRuta", cnSigamet)
        If txtRuta.Text.Trim <> "" Then
            cmdLogistica.Parameters.Add("@Ruta", SqlDbType.Int).Value = CInt(txtRuta.Text)
            cmdLogistica.Parameters.Add("@Celula", SqlDbType.TinyInt).Value = CInt(cboCelula.SelectedValue)
            cmdLogistica.Parameters.Add("@Clase", SqlDbType.TinyInt).Value = CInt(cboClase.SelectedValue)
            cmdLogistica.Parameters.Add("@Nuevo", SqlDbType.Bit).Value = txtRuta.Enabled
            cmdLogistica.Parameters.Add("@UsuarioMovil", SqlDbType.VarChar).Value = IIf((cboUsuarioMovil.SelectedValue Is Nothing), DBNull.Value, cboUsuarioMovil.SelectedValue)
            If txtDescripcionRuta.Text = "" Then
                cmdLogistica.Parameters.Add("@Descripcion", SqlDbType.VarChar).Value = DBNull.Value
            Else
                cmdLogistica.Parameters.Add("@Descripcion", SqlDbType.VarChar).Value = txtDescripcionRuta.Text
            End If
            cmdLogistica.CommandType = CommandType.StoredProcedure
            Try
                cnSigamet.Open()
                cmdLogistica.ExecuteNonQuery()
                cnSigamet.Close()
                Me.DialogResult = DialogResult.OK
                Me.Close()
            Catch ex As Exception
                ExMessage(ex)
            Finally
                cnSigamet.Close()
            End Try
        Else
            ErrMessage("No ha escrito el número de ruta.")
        End If
    End Sub


    Private Sub cboUsuarioMovil_KeyPress(sender As System.Object, e As System.Windows.Forms.KeyPressEventArgs) Handles cboUsuarioMovil.KeyPress
        If Asc(e.KeyChar) = 8 Then
            If cboUsuarioMovil.Items.Count > 0 Then
                cboUsuarioMovil.SelectedIndex = -1
            End If
        End If
    End Sub
End Class
