Imports System.Data.SqlClient

Public Class frmCancelacionFolio
    Inherits System.Windows.Forms.Form

#Region " Windows Form Designer generated code "

    Public Sub New(ByVal Año As Integer, ByVal Folio As Integer, ByVal Autotanque As Integer, ByVal Ruta As Integer, ByVal Fecha As Date)
        MyBase.New()

        'This call is required by the Windows Form Designer.
        InitializeComponent()

        'Add any initialization after the InitializeComponent() call
        Dim daLogistica As New SqlDataAdapter("Select MotivoNoAsignacion, Descripcion from MotivoNoAsignacion where MotivoNoAsignacion > 0 order by Descripcion", cnSigamet)
        Dim dtMotivo As New DataTable()
        Me.Año = Año
        Me.Fecha = Fecha
        txtFolio.Text = Folio.ToString
        txtAutotanque.Text = Autotanque.ToString
        txtRuta.Text = Ruta.ToString
        Try
            daLogistica.Fill(dtMotivo)
        Catch ex As Exception
            ExMessage(ex)
        Finally
            daLogistica.Dispose()
        End Try
        cboMotivo.ValueMember = "MotivoNoAsignacion"
        cboMotivo.DisplayMember = "Descripcion"
        cboMotivo.DataSource = dtMotivo
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
    Friend WithEvents lblFolio As System.Windows.Forms.Label
    Friend WithEvents lblAutotanque As System.Windows.Forms.Label
    Friend WithEvents lblRuta As System.Windows.Forms.Label
    Friend WithEvents lblMotivo As System.Windows.Forms.Label
    Friend WithEvents cboMotivo As System.Windows.Forms.ComboBox
    Friend WithEvents txtFolio As System.Windows.Forms.TextBox
    Friend WithEvents txtAutotanque As System.Windows.Forms.TextBox
    Friend WithEvents txtRuta As System.Windows.Forms.TextBox
    Friend WithEvents Figure1 As Logistica.Figure
    Friend WithEvents btnCancelar As System.Windows.Forms.Button
    Friend WithEvents btnAceptar As System.Windows.Forms.Button
    Friend WithEvents lblClave As System.Windows.Forms.Label
    Friend WithEvents txtClave As System.Windows.Forms.TextBox
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(frmCancelacionFolio))
        Me.rgrpDatos = New Logistica.RoundedGroupBox()
        Me.Figure1 = New Logistica.Figure()
        Me.txtRuta = New System.Windows.Forms.TextBox()
        Me.txtAutotanque = New System.Windows.Forms.TextBox()
        Me.txtFolio = New System.Windows.Forms.TextBox()
        Me.cboMotivo = New System.Windows.Forms.ComboBox()
        Me.lblMotivo = New System.Windows.Forms.Label()
        Me.lblRuta = New System.Windows.Forms.Label()
        Me.lblAutotanque = New System.Windows.Forms.Label()
        Me.lblFolio = New System.Windows.Forms.Label()
        Me.txtClave = New System.Windows.Forms.TextBox()
        Me.lblClave = New System.Windows.Forms.Label()
        Me.btnCancelar = New System.Windows.Forms.Button()
        Me.btnAceptar = New System.Windows.Forms.Button()
        Me.rgrpDatos.SuspendLayout()
        Me.SuspendLayout()
        '
        'rgrpDatos
        '
        Me.rgrpDatos.BorderColor = System.Drawing.Color.Indigo
        Me.rgrpDatos.Controls.AddRange(New System.Windows.Forms.Control() {Me.Figure1, Me.txtRuta, Me.txtAutotanque, Me.txtFolio, Me.cboMotivo, Me.lblMotivo, Me.lblRuta, Me.lblAutotanque, Me.lblFolio, Me.txtClave, Me.lblClave})
        Me.rgrpDatos.Dock = System.Windows.Forms.DockStyle.Left
        Me.rgrpDatos.FlatStyle = Logistica.RoundedGroupBox.Style.Pipe
        Me.rgrpDatos.Location = New System.Drawing.Point(5, 5)
        Me.rgrpDatos.Name = "rgrpDatos"
        Me.rgrpDatos.Size = New System.Drawing.Size(363, 197)
        Me.rgrpDatos.TabIndex = 0
        Me.rgrpDatos.TabStop = False
        Me.rgrpDatos.TextAlignment = System.Windows.Forms.HorizontalAlignment.Left
        '
        'Figure1
        '
        Me.Figure1.BackColor = System.Drawing.Color.LightSteelBlue
        Me.Figure1.FillColor = System.Drawing.SystemColors.Control
        Me.Figure1.LineColor = System.Drawing.Color.Indigo
        Me.Figure1.LineWidth = 2.0!
        Me.Figure1.Location = New System.Drawing.Point(9, 112)
        Me.Figure1.Name = "Figure1"
        Me.Figure1.Size = New System.Drawing.Size(343, 8)
        Me.Figure1.Style = Logistica.Figure.FigureStyle.Line
        Me.Figure1.TabIndex = 8
        Me.Figure1.TabStop = False
        '
        'txtRuta
        '
        Me.txtRuta.BackColor = System.Drawing.Color.WhiteSmoke
        Me.txtRuta.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtRuta.Location = New System.Drawing.Point(136, 85)
        Me.txtRuta.Name = "txtRuta"
        Me.txtRuta.ReadOnly = True
        Me.txtRuta.TabIndex = 7
        Me.txtRuta.TabStop = False
        Me.txtRuta.Text = ""
        '
        'txtAutotanque
        '
        Me.txtAutotanque.BackColor = System.Drawing.Color.WhiteSmoke
        Me.txtAutotanque.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtAutotanque.Location = New System.Drawing.Point(136, 53)
        Me.txtAutotanque.Name = "txtAutotanque"
        Me.txtAutotanque.ReadOnly = True
        Me.txtAutotanque.TabIndex = 6
        Me.txtAutotanque.TabStop = False
        Me.txtAutotanque.Text = ""
        '
        'txtFolio
        '
        Me.txtFolio.BackColor = System.Drawing.Color.WhiteSmoke
        Me.txtFolio.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtFolio.Location = New System.Drawing.Point(136, 21)
        Me.txtFolio.Name = "txtFolio"
        Me.txtFolio.ReadOnly = True
        Me.txtFolio.TabIndex = 5
        Me.txtFolio.TabStop = False
        Me.txtFolio.Text = ""
        '
        'cboMotivo
        '
        Me.cboMotivo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboMotivo.Location = New System.Drawing.Point(136, 132)
        Me.cboMotivo.Name = "cboMotivo"
        Me.cboMotivo.Size = New System.Drawing.Size(216, 21)
        Me.cboMotivo.TabIndex = 1
        '
        'lblMotivo
        '
        Me.lblMotivo.AutoSize = True
        Me.lblMotivo.Location = New System.Drawing.Point(16, 135)
        Me.lblMotivo.Name = "lblMotivo"
        Me.lblMotivo.Size = New System.Drawing.Size(41, 14)
        Me.lblMotivo.TabIndex = 0
        Me.lblMotivo.Text = "&Motivo:"
        '
        'lblRuta
        '
        Me.lblRuta.AutoSize = True
        Me.lblRuta.Location = New System.Drawing.Point(16, 88)
        Me.lblRuta.Name = "lblRuta"
        Me.lblRuta.Size = New System.Drawing.Size(31, 14)
        Me.lblRuta.TabIndex = 5
        Me.lblRuta.Text = "Ruta:"
        '
        'lblAutotanque
        '
        Me.lblAutotanque.AutoSize = True
        Me.lblAutotanque.Location = New System.Drawing.Point(16, 56)
        Me.lblAutotanque.Name = "lblAutotanque"
        Me.lblAutotanque.Size = New System.Drawing.Size(66, 14)
        Me.lblAutotanque.TabIndex = 5
        Me.lblAutotanque.Text = "Autotanque:"
        '
        'lblFolio
        '
        Me.lblFolio.AutoSize = True
        Me.lblFolio.Location = New System.Drawing.Point(16, 24)
        Me.lblFolio.Name = "lblFolio"
        Me.lblFolio.Size = New System.Drawing.Size(32, 14)
        Me.lblFolio.TabIndex = 5
        Me.lblFolio.Text = "Folio:"
        '
        'txtClave
        '
        Me.txtClave.Location = New System.Drawing.Point(136, 162)
        Me.txtClave.Name = "txtClave"
        Me.txtClave.PasswordChar = Microsoft.VisualBasic.ChrW(42)
        Me.txtClave.TabIndex = 2
        Me.txtClave.Text = ""
        '
        'lblClave
        '
        Me.lblClave.AutoSize = True
        Me.lblClave.Location = New System.Drawing.Point(16, 165)
        Me.lblClave.Name = "lblClave"
        Me.lblClave.Size = New System.Drawing.Size(115, 14)
        Me.lblClave.TabIndex = 1
        Me.lblClave.Text = "Cla&ve de autorización:"
        '
        'btnCancelar
        '
        Me.btnCancelar.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnCancelar.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnCancelar.Image = CType(resources.GetObject("btnCancelar.Image"), System.Drawing.Bitmap)
        Me.btnCancelar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnCancelar.Location = New System.Drawing.Point(377, 53)
        Me.btnCancelar.Name = "btnCancelar"
        Me.btnCancelar.Size = New System.Drawing.Size(72, 24)
        Me.btnCancelar.TabIndex = 2
        Me.btnCancelar.Text = "&Cancelar"
        Me.btnCancelar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'btnAceptar
        '
        Me.btnAceptar.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnAceptar.Image = CType(resources.GetObject("btnAceptar.Image"), System.Drawing.Bitmap)
        Me.btnAceptar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnAceptar.Location = New System.Drawing.Point(377, 17)
        Me.btnAceptar.Name = "btnAceptar"
        Me.btnAceptar.Size = New System.Drawing.Size(72, 24)
        Me.btnAceptar.TabIndex = 1
        Me.btnAceptar.Text = "&Aceptar"
        Me.btnAceptar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'frmCancelacionFolio
        '
        Me.AcceptButton = Me.btnAceptar
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 14)
        Me.BackColor = System.Drawing.Color.Gainsboro
        Me.CancelButton = Me.btnCancelar
        Me.ClientSize = New System.Drawing.Size(458, 207)
        Me.Controls.AddRange(New System.Windows.Forms.Control() {Me.btnCancelar, Me.btnAceptar, Me.rgrpDatos})
        Me.DockPadding.All = 5
        Me.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmCancelacionFolio"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Cancelación"
        Me.rgrpDatos.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

#End Region

    Private Año As Integer
    Private Fecha As Date

    Private Sub btnAceptar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAceptar.Click
        If txtClave.Text.Trim = "" Then
            ErrMessage("No ha escrito su clve de usuario.")
            txtClave.Focus()
        Else
            If txtClave.Text.ToUpper.Trim <> _Password.ToUpper.Trim Then
                ErrMessage("La clave no corresponde a la del usuario " & _Usuario & ".")
                txtClave.Focus()
            ElseIf MessageBox.Show("¿Desea cancelar la salida de la ruta " & txtRuta.Text.Trim & " en el autotanque " & txtAutotanque.Text.Trim & " del " & Fecha.ToShortDateString & "?", _
                     Application.ProductName & " v." & Application.ProductVersion, MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) = DialogResult.Yes Then
                Dim cmdLogistica As New SqlCommand("exec spLOGMotivoNoAsignacion @Año, @Folio, @Autotanque, @Motivo, @Usuario", cnSigamet)
                cmdLogistica.Parameters.Add("@Año", SqlDbType.Int).Value = Año
                cmdLogistica.Parameters.Add("@Folio", SqlDbType.Int).Value = CInt(txtFolio.Text)
                cmdLogistica.Parameters.Add("@Autotanque", SqlDbType.Int).Value = CInt(txtAutotanque.Text)
                cmdLogistica.Parameters.Add("@Motivo", SqlDbType.TinyInt).Value = CInt(cboMotivo.SelectedValue)
                cmdLogistica.Parameters.Add("@Usuario", SqlDbType.Char).Value = _Usuario.Trim
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
