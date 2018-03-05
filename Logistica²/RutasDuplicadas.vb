Public Class frmRutasDuplicadas
    Inherits System.Windows.Forms.Form

#Region " Windows Form Designer generated code "

    Public Sub New(ByVal dtRutas As DataTable)
        MyBase.New()

        'This call is required by the Windows Form Designer.
        InitializeComponent()

        'Add any initialization after the InitializeComponent() call
        vgrdRutas.DataSource = dtRutas
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
    Friend WithEvents txtMensaje As System.Windows.Forms.TextBox
    Friend WithEvents vgrdRutas As Logistica.ViewGrid
    Friend WithEvents pnlPregunta As System.Windows.Forms.Panel
    Friend WithEvents lblPregunta As System.Windows.Forms.Label
    Friend WithEvents btnSi As System.Windows.Forms.Button
    Friend WithEvents btnNo As System.Windows.Forms.Button
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(frmRutasDuplicadas))
        Me.txtMensaje = New System.Windows.Forms.TextBox()
        Me.vgrdRutas = New Logistica.ViewGrid()
        Me.pnlPregunta = New System.Windows.Forms.Panel()
        Me.btnNo = New System.Windows.Forms.Button()
        Me.btnSi = New System.Windows.Forms.Button()
        Me.lblPregunta = New System.Windows.Forms.Label()
        Me.pnlPregunta.SuspendLayout()
        Me.SuspendLayout()
        '
        'txtMensaje
        '
        Me.txtMensaje.BackColor = System.Drawing.Color.LightGray
        Me.txtMensaje.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.txtMensaje.Dock = System.Windows.Forms.DockStyle.Top
        Me.txtMensaje.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtMensaje.ForeColor = System.Drawing.Color.DarkBlue
        Me.txtMensaje.Multiline = True
        Me.txtMensaje.Name = "txtMensaje"
        Me.txtMensaje.ReadOnly = True
        Me.txtMensaje.Size = New System.Drawing.Size(292, 40)
        Me.txtMensaje.TabIndex = 3
        Me.txtMensaje.TabStop = False
        Me.txtMensaje.Text = "Las siguientes rutas tienen más de un autotanque titular asignado:"
        '
        'vgrdRutas
        '
        Me.vgrdRutas.AlternativeBackColor = System.Drawing.Color.Gainsboro
        Me.vgrdRutas.CheckCondition = Nothing
        Me.vgrdRutas.DataSource = Nothing
        Me.vgrdRutas.Dock = System.Windows.Forms.DockStyle.Fill
        Me.vgrdRutas.FullRowSelect = True
        Me.vgrdRutas.GridLines = True
        Me.vgrdRutas.HidedColumnNames = New String() {Nothing}
        Me.vgrdRutas.Location = New System.Drawing.Point(0, 40)
        Me.vgrdRutas.Name = "vgrdRutas"
        Me.vgrdRutas.PKColumnNames = Nothing
        Me.vgrdRutas.Size = New System.Drawing.Size(292, 213)
        Me.vgrdRutas.TabIndex = 3
        Me.vgrdRutas.View = System.Windows.Forms.View.Details
        '
        'pnlPregunta
        '
        Me.pnlPregunta.Controls.AddRange(New System.Windows.Forms.Control() {Me.btnNo, Me.btnSi, Me.lblPregunta})
        Me.pnlPregunta.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.pnlPregunta.Location = New System.Drawing.Point(0, 253)
        Me.pnlPregunta.Name = "pnlPregunta"
        Me.pnlPregunta.Size = New System.Drawing.Size(292, 80)
        Me.pnlPregunta.TabIndex = 2
        '
        'btnNo
        '
        Me.btnNo.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnNo.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnNo.Image = CType(resources.GetObject("btnNo.Image"), System.Drawing.Bitmap)
        Me.btnNo.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnNo.Location = New System.Drawing.Point(167, 40)
        Me.btnNo.Name = "btnNo"
        Me.btnNo.Size = New System.Drawing.Size(47, 23)
        Me.btnNo.TabIndex = 1
        Me.btnNo.Text = "&No"
        Me.btnNo.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'btnSi
        '
        Me.btnSi.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.btnSi.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnSi.Image = CType(resources.GetObject("btnSi.Image"), System.Drawing.Bitmap)
        Me.btnSi.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnSi.Location = New System.Drawing.Point(79, 40)
        Me.btnSi.Name = "btnSi"
        Me.btnSi.Size = New System.Drawing.Size(47, 23)
        Me.btnSi.TabIndex = 0
        Me.btnSi.Text = "&Sí"
        Me.btnSi.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblPregunta
        '
        Me.lblPregunta.AutoSize = True
        Me.lblPregunta.Location = New System.Drawing.Point(90, 9)
        Me.lblPregunta.Name = "lblPregunta"
        Me.lblPregunta.Size = New System.Drawing.Size(112, 14)
        Me.lblPregunta.TabIndex = 3
        Me.lblPregunta.Text = "¿Desea corregir esto?"
        '
        'frmRutasDuplicadas
        '
        Me.AcceptButton = Me.btnSi
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 14)
        Me.BackColor = System.Drawing.Color.Gainsboro
        Me.CancelButton = Me.btnNo
        Me.ClientSize = New System.Drawing.Size(292, 333)
        Me.ControlBox = False
        Me.Controls.AddRange(New System.Windows.Forms.Control() {Me.vgrdRutas, Me.txtMensaje, Me.pnlPregunta})
        Me.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Name = "frmRutasDuplicadas"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Rutas duplicadas"
        Me.pnlPregunta.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

#End Region

End Class
