Imports Microsoft.VisualBasic

Public Class frmEditaMotivoAutotanqueNA
    Inherits System.Windows.Forms.Form

    Dim Folio As Integer
    Dim Opened As Boolean

#Region " Windows Form Designer generated code "

    Public Sub New(ByVal Fecha As Date, ByVal Autotanque As Integer)
        MyBase.New()

        'This call is required by the Windows Form Designer.
        InitializeComponent()

        'Add any initialization after the InitializeComponent() call
        Dim cmdLogistica As New SqlClient.SqlCommand("Select MotivoNoAsignacion, Descripcion from MotivoNoAsignacion order by Descripcion", cnSigamet)
        Dim daLogistica As New SqlClient.SqlDataAdapter(cmdLogistica)
        Dim rdLogistica As SqlClient.SqlDataReader
        Dim dtMotivo As New DataTable()
        txtAutotanque.Text = Autotanque.ToString
        dtpFInicio.Value = Fecha
        dtpFFin.Value = Fecha
        Try
            daLogistica.Fill(dtMotivo)
            cboMotivo.ValueMember = "MotivoNoAsignacion"
            cboMotivo.DisplayMember = "Descripcion"
            cboMotivo.DataSource = dtMotivo
            Application.DoEvents()
            cmdLogistica.CommandText = "Select * from AutotanqueSinSalida where Autotanque = @Autotanque and FInicio <= @Fecha and FFin >= @Fecha"
            cmdLogistica.Parameters.Add("@Autotanque", SqlDbType.SmallInt).Value = Autotanque
            cmdLogistica.Parameters.Add("@Fecha", SqlDbType.DateTime).Value = Fecha
            cnSigamet.Open()
            rdLogistica = cmdLogistica.ExecuteReader

            If rdLogistica.Read() Then
                If Not IsDBNull(rdLogistica("Folio")) Then
                    Me.Folio = CInt(rdLogistica("Folio"))
                    cboMotivo.SelectedValue = CInt(rdLogistica("MotivoNoAsignacion"))
                    dtpFInicio.Value = CDate(rdLogistica("Finicio"))
                    dtpFFin.Value = CDate(rdLogistica("FFin"))
                    If Not IsDBNull(rdLogistica("Comentario")) Then
                        txtComentario.Text = CStr(rdLogistica("Comentario"))
                    End If
                End If
            End If
            rdLogistica.Close()
        Catch ex As Exception
            ExMessage(ex)
        Finally
            cnSigamet.Close()
            daLogistica.Dispose()
            cmdLogistica.Dispose()
        End Try
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
    Friend WithEvents Comentarios As System.Windows.Forms.Label
    Friend WithEvents lblFFin As System.Windows.Forms.Label
    Friend WithEvents lblFInicio As System.Windows.Forms.Label
    Friend WithEvents lblMotivo As System.Windows.Forms.Label
    Friend WithEvents lblAutotanque As System.Windows.Forms.Label
    Friend WithEvents txtAutotanque As System.Windows.Forms.TextBox
    Friend WithEvents cboMotivo As System.Windows.Forms.ComboBox
    Friend WithEvents dtpFInicio As System.Windows.Forms.DateTimePicker
    Friend WithEvents dtpFFin As System.Windows.Forms.DateTimePicker
    Friend WithEvents btnAceptar As System.Windows.Forms.Button
    Friend WithEvents btnCancelar As System.Windows.Forms.Button
    Friend WithEvents txtComentario As System.Windows.Forms.TextBox
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(frmEditaMotivoAutotanqueNA))
        Me.rgrpDatos = New Logistica.RoundedGroupBox()
        Me.dtpFFin = New System.Windows.Forms.DateTimePicker()
        Me.dtpFInicio = New System.Windows.Forms.DateTimePicker()
        Me.cboMotivo = New System.Windows.Forms.ComboBox()
        Me.txtComentario = New System.Windows.Forms.TextBox()
        Me.txtAutotanque = New System.Windows.Forms.TextBox()
        Me.Comentarios = New System.Windows.Forms.Label()
        Me.lblFFin = New System.Windows.Forms.Label()
        Me.lblFInicio = New System.Windows.Forms.Label()
        Me.lblMotivo = New System.Windows.Forms.Label()
        Me.lblAutotanque = New System.Windows.Forms.Label()
        Me.btnAceptar = New System.Windows.Forms.Button()
        Me.btnCancelar = New System.Windows.Forms.Button()
        Me.rgrpDatos.SuspendLayout()
        Me.SuspendLayout()
        '
        'rgrpDatos
        '
        Me.rgrpDatos.BorderColor = System.Drawing.Color.Gray
        Me.rgrpDatos.Controls.AddRange(New System.Windows.Forms.Control() {Me.dtpFFin, Me.dtpFInicio, Me.cboMotivo, Me.txtComentario, Me.txtAutotanque, Me.Comentarios, Me.lblFFin, Me.lblFInicio, Me.lblMotivo, Me.lblAutotanque})
        Me.rgrpDatos.Dock = System.Windows.Forms.DockStyle.Left
        Me.rgrpDatos.FlatStyle = Logistica.RoundedGroupBox.Style.Pipe
        Me.rgrpDatos.Location = New System.Drawing.Point(5, 5)
        Me.rgrpDatos.Name = "rgrpDatos"
        Me.rgrpDatos.Size = New System.Drawing.Size(336, 173)
        Me.rgrpDatos.TabIndex = 0
        Me.rgrpDatos.TabStop = False
        Me.rgrpDatos.TextAlignment = System.Windows.Forms.HorizontalAlignment.Left
        '
        'dtpFFin
        '
        Me.dtpFFin.Location = New System.Drawing.Point(123, 99)
        Me.dtpFFin.Name = "dtpFFin"
        Me.dtpFFin.TabIndex = 9
        '
        'dtpFInicio
        '
        Me.dtpFInicio.Location = New System.Drawing.Point(123, 70)
        Me.dtpFInicio.Name = "dtpFInicio"
        Me.dtpFInicio.TabIndex = 8
        '
        'cboMotivo
        '
        Me.cboMotivo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboMotivo.Location = New System.Drawing.Point(123, 41)
        Me.cboMotivo.Name = "cboMotivo"
        Me.cboMotivo.Size = New System.Drawing.Size(197, 21)
        Me.cboMotivo.TabIndex = 7
        '
        'txtComentario
        '
        Me.txtComentario.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtComentario.Location = New System.Drawing.Point(123, 132)
        Me.txtComentario.MaxLength = 50
        Me.txtComentario.Multiline = True
        Me.txtComentario.Name = "txtComentario"
        Me.txtComentario.Size = New System.Drawing.Size(197, 36)
        Me.txtComentario.TabIndex = 6
        Me.txtComentario.Text = ""
        '
        'txtAutotanque
        '
        Me.txtAutotanque.BackColor = System.Drawing.Color.White
        Me.txtAutotanque.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtAutotanque.Location = New System.Drawing.Point(123, 12)
        Me.txtAutotanque.Name = "txtAutotanque"
        Me.txtAutotanque.ReadOnly = True
        Me.txtAutotanque.Size = New System.Drawing.Size(56, 21)
        Me.txtAutotanque.TabIndex = 5
        Me.txtAutotanque.Text = ""
        '
        'Comentarios
        '
        Me.Comentarios.AutoSize = True
        Me.Comentarios.Location = New System.Drawing.Point(8, 132)
        Me.Comentarios.Name = "Comentarios"
        Me.Comentarios.Size = New System.Drawing.Size(71, 14)
        Me.Comentarios.TabIndex = 4
        Me.Comentarios.Text = "Comentarios:"
        '
        'lblFFin
        '
        Me.lblFFin.AutoSize = True
        Me.lblFFin.Location = New System.Drawing.Point(8, 103)
        Me.lblFFin.Name = "lblFFin"
        Me.lblFFin.Size = New System.Drawing.Size(54, 14)
        Me.lblFFin.TabIndex = 3
        Me.lblFFin.Text = "Fecha fin:"
        '
        'lblFInicio
        '
        Me.lblFInicio.AutoSize = True
        Me.lblFInicio.Location = New System.Drawing.Point(8, 74)
        Me.lblFInicio.Name = "lblFInicio"
        Me.lblFInicio.Size = New System.Drawing.Size(67, 14)
        Me.lblFInicio.TabIndex = 2
        Me.lblFInicio.Text = "Fecha inicio:"
        '
        'lblMotivo
        '
        Me.lblMotivo.AutoSize = True
        Me.lblMotivo.Location = New System.Drawing.Point(8, 45)
        Me.lblMotivo.Name = "lblMotivo"
        Me.lblMotivo.Size = New System.Drawing.Size(113, 14)
        Me.lblMotivo.TabIndex = 1
        Me.lblMotivo.Text = "Motivo no asignación:"
        '
        'lblAutotanque
        '
        Me.lblAutotanque.AutoSize = True
        Me.lblAutotanque.Location = New System.Drawing.Point(8, 16)
        Me.lblAutotanque.Name = "lblAutotanque"
        Me.lblAutotanque.Size = New System.Drawing.Size(66, 14)
        Me.lblAutotanque.TabIndex = 0
        Me.lblAutotanque.Text = "Autotanque:"
        '
        'btnAceptar
        '
        Me.btnAceptar.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnAceptar.Image = CType(resources.GetObject("btnAceptar.Image"), System.Drawing.Bitmap)
        Me.btnAceptar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnAceptar.Location = New System.Drawing.Point(349, 8)
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
        Me.btnCancelar.Location = New System.Drawing.Point(349, 40)
        Me.btnCancelar.Name = "btnCancelar"
        Me.btnCancelar.TabIndex = 2
        Me.btnCancelar.Text = "&Cancelar"
        Me.btnCancelar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'frmEditaMotivoAutotanqueNA
        '
        Me.AcceptButton = Me.btnAceptar
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 14)
        Me.BackColor = System.Drawing.Color.Gainsboro
        Me.CancelButton = Me.btnCancelar
        Me.ClientSize = New System.Drawing.Size(434, 183)
        Me.Controls.AddRange(New System.Windows.Forms.Control() {Me.btnCancelar, Me.btnAceptar, Me.rgrpDatos})
        Me.DockPadding.All = 5
        Me.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmEditaMotivoAutotanqueNA"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Autotanque sin asignar"
        Me.rgrpDatos.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

#End Region



    Private Sub btnAceptar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAceptar.Click
        Dim cmdLogistica As New SqlClient.SqlCommand("spLOGAttSinSalida", cnSigamet)
        cmdLogistica.CommandType = CommandType.StoredProcedure
        cmdLogistica.Parameters.Add("@Autotanque", SqlDbType.SmallInt).Value = CInt(txtAutotanque.Text)
        cmdLogistica.Parameters.Add("@Folio", SqlDbType.Int).Value = Folio
        cmdLogistica.Parameters.Add("@Motivo", SqlDbType.SmallInt).Value = CInt(cboMotivo.SelectedValue)
        cmdLogistica.Parameters.Add("@FInicio", SqlDbType.DateTime).Value = dtpFInicio.Value.Date
        cmdLogistica.Parameters.Add("@FFin", SqlDbType.DateTime).Value = dtpFFin.Value.Date
        cmdLogistica.Parameters.Add("@Comentario", SqlDbType.Char).Value = txtComentario.Text
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
    End Sub

    Private Sub frmAttSinAsignar_Closed(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Closed
        If Opened And Not cnSigamet.State = ConnectionState.Closed Then
            cnSigamet.Open()
        End If
    End Sub

    Private Sub dtpFInicio_ValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles dtpFInicio.ValueChanged
        If dtpFFin.Value < dtpFInicio.Value Then
            dtpFFin.Value = dtpFInicio.Value
        End If
    End Sub

    Private Sub dtpFFin_ValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles dtpFFin.ValueChanged
        If dtpFInicio.Value > dtpFFin.Value Then
            dtpFInicio.Value = dtpFFin.Value
        End If
    End Sub
End Class
