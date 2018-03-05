Option Strict On
Imports System
Imports System.Data
Imports System.Convert
Imports System.Data.SqlClient
Imports System.Exception

Public Class frmGeneraAsignacion
    Inherits System.Windows.Forms.Form


#Region " Windows Form Designer generated code "

    Public Sub New(ByVal Celula As Integer, ByVal Fecha As Date)
        MyBase.New()

        'This call is required by the Windows Form Designer.
        InitializeComponent()

        'Add any initialization after the InitializeComponent() call
        Me.Celula = Celula
        Me.Text = "Generación de asignación para la célula " & Celula.ToString
        txtFechaDestino.Text = Fecha.ToShortDateString
        dtpFechaOrigen.MaxDate = Fecha.AddDays(-1)
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
    Friend WithEvents lblFechaDestino As System.Windows.Forms.Label
    Friend WithEvents lblFechaOrigen As System.Windows.Forms.Label
    Friend WithEvents txtFechaDestino As System.Windows.Forms.TextBox
    Friend WithEvents dtpFechaOrigen As System.Windows.Forms.DateTimePicker
    Friend WithEvents btnAceptar As System.Windows.Forms.Button
    Friend WithEvents btnCancelar As System.Windows.Forms.Button
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(frmGeneraAsignacion))
        Me.rgrpDatos = New Logistica.RoundedGroupBox()
        Me.dtpFechaOrigen = New System.Windows.Forms.DateTimePicker()
        Me.txtFechaDestino = New System.Windows.Forms.TextBox()
        Me.lblFechaOrigen = New System.Windows.Forms.Label()
        Me.lblFechaDestino = New System.Windows.Forms.Label()
        Me.btnAceptar = New System.Windows.Forms.Button()
        Me.btnCancelar = New System.Windows.Forms.Button()
        Me.rgrpDatos.SuspendLayout()
        Me.SuspendLayout()
        '
        'rgrpDatos
        '
        Me.rgrpDatos.BorderColor = System.Drawing.Color.ForestGreen
        Me.rgrpDatos.Controls.AddRange(New System.Windows.Forms.Control() {Me.dtpFechaOrigen, Me.txtFechaDestino, Me.lblFechaOrigen, Me.lblFechaDestino})
        Me.rgrpDatos.FlatStyle = Logistica.RoundedGroupBox.Style.Pipe
        Me.rgrpDatos.Location = New System.Drawing.Point(5, -2)
        Me.rgrpDatos.Name = "rgrpDatos"
        Me.rgrpDatos.Size = New System.Drawing.Size(200, 88)
        Me.rgrpDatos.TabIndex = 0
        Me.rgrpDatos.TabStop = False
        Me.rgrpDatos.TextAlignment = System.Windows.Forms.HorizontalAlignment.Left
        '
        'dtpFechaOrigen
        '
        Me.dtpFechaOrigen.Format = System.Windows.Forms.DateTimePickerFormat.Short
        Me.dtpFechaOrigen.Location = New System.Drawing.Point(96, 53)
        Me.dtpFechaOrigen.Name = "dtpFechaOrigen"
        Me.dtpFechaOrigen.Size = New System.Drawing.Size(88, 21)
        Me.dtpFechaOrigen.TabIndex = 2
        '
        'txtFechaDestino
        '
        Me.txtFechaDestino.BackColor = System.Drawing.Color.White
        Me.txtFechaDestino.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtFechaDestino.Location = New System.Drawing.Point(96, 21)
        Me.txtFechaDestino.Name = "txtFechaDestino"
        Me.txtFechaDestino.ReadOnly = True
        Me.txtFechaDestino.Size = New System.Drawing.Size(88, 21)
        Me.txtFechaDestino.TabIndex = 2
        Me.txtFechaDestino.TabStop = False
        Me.txtFechaDestino.Text = ""
        '
        'lblFechaOrigen
        '
        Me.lblFechaOrigen.AutoSize = True
        Me.lblFechaOrigen.CausesValidation = False
        Me.lblFechaOrigen.Location = New System.Drawing.Point(18, 56)
        Me.lblFechaOrigen.Name = "lblFechaOrigen"
        Me.lblFechaOrigen.Size = New System.Drawing.Size(72, 14)
        Me.lblFechaOrigen.TabIndex = 1
        Me.lblFechaOrigen.Text = "Fecha &origen:"
        '
        'lblFechaDestino
        '
        Me.lblFechaDestino.AutoSize = True
        Me.lblFechaDestino.Location = New System.Drawing.Point(18, 24)
        Me.lblFechaDestino.Name = "lblFechaDestino"
        Me.lblFechaDestino.Size = New System.Drawing.Size(77, 14)
        Me.lblFechaDestino.TabIndex = 0
        Me.lblFechaDestino.Text = "Fecha destino:"
        '
        'btnAceptar
        '
        Me.btnAceptar.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnAceptar.Image = CType(resources.GetObject("btnAceptar.Image"), System.Drawing.Bitmap)
        Me.btnAceptar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnAceptar.Location = New System.Drawing.Point(215, 8)
        Me.btnAceptar.Name = "btnAceptar"
        Me.btnAceptar.Size = New System.Drawing.Size(73, 23)
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
        Me.btnCancelar.Location = New System.Drawing.Point(215, 40)
        Me.btnCancelar.Name = "btnCancelar"
        Me.btnCancelar.Size = New System.Drawing.Size(73, 23)
        Me.btnCancelar.TabIndex = 2
        Me.btnCancelar.Text = "&Cancelar"
        Me.btnCancelar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'frmGeneraAsignacion
        '
        Me.AcceptButton = Me.btnAceptar
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 14)
        Me.BackColor = System.Drawing.Color.Gainsboro
        Me.CancelButton = Me.btnCancelar
        Me.ClientSize = New System.Drawing.Size(306, 90)
        Me.Controls.AddRange(New System.Windows.Forms.Control() {Me.btnCancelar, Me.btnAceptar, Me.rgrpDatos})
        Me.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MaximumSize = New System.Drawing.Size(312, 115)
        Me.MinimizeBox = False
        Me.MinimumSize = New System.Drawing.Size(312, 115)
        Me.Name = "frmGeneraAsignacion"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.rgrpDatos.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

#End Region

    Dim Celula As Integer


    Private Sub btnAceptar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAceptar.Click
        Dim cmdLogistica As New SqlCommand("exec spLOGAltaInicioRuta @FDestino, @FOrigen, @Celula, 1", cnSigamet)
        If MessageBox.Show("¿Desea copiar las asignaciones de célula " & Celula.ToString & " del día " & dtpFechaOrigen.Value.ToShortDateString & _
            " al día " & txtFechaDestino.Text & "?", Application.ProductName & " v." & Application.ProductVersion, MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
            cmdLogistica.Parameters.Add("@FDestino", SqlDbType.DateTime).Value = CDate(txtFechaDestino.Text)
            cmdLogistica.Parameters.Add("@FOrigen", SqlDbType.DateTime).Value = dtpFechaOrigen.Value.Date
            cmdLogistica.Parameters.Add("@Celula", SqlDbType.TinyInt).Value = Celula
            cmdLogistica.CommandTimeout = 360
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
    End Sub
End Class
