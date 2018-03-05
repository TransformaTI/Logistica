Public Class frmBusquedaFolios
    Inherits System.Windows.Forms.Form

#Region " Windows Form Designer generated code "

    Public Sub New()
        MyBase.New()

        'This call is required by the Windows Form Designer.
        InitializeComponent()

        'Add any initialization after the InitializeComponent() call

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
    Friend WithEvents rgrpDatosAutotanque As Logistica.RoundedGroupBox
    Friend WithEvents lblFolio As System.Windows.Forms.Label
    Friend WithEvents lblAutotanque As System.Windows.Forms.Label
    Friend WithEvents txtPlacas As System.Windows.Forms.TextBox
    Friend WithEvents txtRuta As System.Windows.Forms.TextBox
    Friend WithEvents txtAutotanque As System.Windows.Forms.TextBox
    Friend WithEvents txtFolio As System.Windows.Forms.TextBox
    Friend WithEvents lblPlacas As System.Windows.Forms.Label
    Friend WithEvents lblRuta As System.Windows.Forms.Label
    Friend WithEvents rgrpOpciones As Logistica.RoundedGroupBox
    Friend WithEvents rdoCualquiera As System.Windows.Forms.RadioButton
    Friend WithEvents btnCancelar As System.Windows.Forms.Button
    Friend WithEvents btnAceptar As System.Windows.Forms.Button
    Friend WithEvents rdoTodos As System.Windows.Forms.RadioButton
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(frmBusquedaFolios))
        Me.rgrpDatosAutotanque = New Logistica.RoundedGroupBox()
        Me.txtPlacas = New System.Windows.Forms.TextBox()
        Me.txtRuta = New System.Windows.Forms.TextBox()
        Me.txtAutotanque = New System.Windows.Forms.TextBox()
        Me.txtFolio = New System.Windows.Forms.TextBox()
        Me.lblPlacas = New System.Windows.Forms.Label()
        Me.lblRuta = New System.Windows.Forms.Label()
        Me.lblAutotanque = New System.Windows.Forms.Label()
        Me.lblFolio = New System.Windows.Forms.Label()
        Me.rgrpOpciones = New Logistica.RoundedGroupBox()
        Me.rdoCualquiera = New System.Windows.Forms.RadioButton()
        Me.rdoTodos = New System.Windows.Forms.RadioButton()
        Me.btnCancelar = New System.Windows.Forms.Button()
        Me.btnAceptar = New System.Windows.Forms.Button()
        Me.rgrpDatosAutotanque.SuspendLayout()
        Me.rgrpOpciones.SuspendLayout()
        Me.SuspendLayout()
        '
        'rgrpDatosAutotanque
        '
        Me.rgrpDatosAutotanque.BorderColor = System.Drawing.Color.Firebrick
        Me.rgrpDatosAutotanque.Controls.AddRange(New System.Windows.Forms.Control() {Me.txtPlacas, Me.txtRuta, Me.txtAutotanque, Me.txtFolio, Me.lblPlacas, Me.lblRuta, Me.lblAutotanque, Me.lblFolio})
        Me.rgrpDatosAutotanque.Dock = System.Windows.Forms.DockStyle.Top
        Me.rgrpDatosAutotanque.FlatStyle = Logistica.RoundedGroupBox.Style.Pipe
        Me.rgrpDatosAutotanque.ForeColor = System.Drawing.Color.Maroon
        Me.rgrpDatosAutotanque.Location = New System.Drawing.Point(5, 5)
        Me.rgrpDatosAutotanque.Name = "rgrpDatosAutotanque"
        Me.rgrpDatosAutotanque.Size = New System.Drawing.Size(256, 131)
        Me.rgrpDatosAutotanque.TabIndex = 0
        Me.rgrpDatosAutotanque.TabStop = False
        Me.rgrpDatosAutotanque.Text = "Datos del autotanque"
        Me.rgrpDatosAutotanque.TextAlignment = System.Windows.Forms.HorizontalAlignment.Center
        '
        'txtPlacas
        '
        Me.txtPlacas.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtPlacas.ForeColor = System.Drawing.Color.Black
        Me.txtPlacas.Location = New System.Drawing.Point(90, 101)
        Me.txtPlacas.Name = "txtPlacas"
        Me.txtPlacas.Size = New System.Drawing.Size(150, 21)
        Me.txtPlacas.TabIndex = 4
        Me.txtPlacas.Text = ""
        '
        'txtRuta
        '
        Me.txtRuta.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtRuta.ForeColor = System.Drawing.Color.Black
        Me.txtRuta.Location = New System.Drawing.Point(90, 75)
        Me.txtRuta.Name = "txtRuta"
        Me.txtRuta.Size = New System.Drawing.Size(150, 21)
        Me.txtRuta.TabIndex = 3
        Me.txtRuta.Text = ""
        '
        'txtAutotanque
        '
        Me.txtAutotanque.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtAutotanque.ForeColor = System.Drawing.Color.Black
        Me.txtAutotanque.Location = New System.Drawing.Point(90, 49)
        Me.txtAutotanque.Name = "txtAutotanque"
        Me.txtAutotanque.Size = New System.Drawing.Size(150, 21)
        Me.txtAutotanque.TabIndex = 2
        Me.txtAutotanque.Text = ""
        '
        'txtFolio
        '
        Me.txtFolio.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtFolio.ForeColor = System.Drawing.Color.Black
        Me.txtFolio.Location = New System.Drawing.Point(90, 23)
        Me.txtFolio.Name = "txtFolio"
        Me.txtFolio.Size = New System.Drawing.Size(150, 21)
        Me.txtFolio.TabIndex = 1
        Me.txtFolio.Text = ""
        '
        'lblPlacas
        '
        Me.lblPlacas.AutoSize = True
        Me.lblPlacas.ForeColor = System.Drawing.Color.Black
        Me.lblPlacas.Location = New System.Drawing.Point(16, 104)
        Me.lblPlacas.Name = "lblPlacas"
        Me.lblPlacas.Size = New System.Drawing.Size(39, 14)
        Me.lblPlacas.TabIndex = 3
        Me.lblPlacas.Text = "&Placas:"
        '
        'lblRuta
        '
        Me.lblRuta.AutoSize = True
        Me.lblRuta.ForeColor = System.Drawing.Color.Black
        Me.lblRuta.Location = New System.Drawing.Point(16, 78)
        Me.lblRuta.Name = "lblRuta"
        Me.lblRuta.Size = New System.Drawing.Size(31, 14)
        Me.lblRuta.TabIndex = 2
        Me.lblRuta.Text = "&Ruta:"
        '
        'lblAutotanque
        '
        Me.lblAutotanque.AutoSize = True
        Me.lblAutotanque.ForeColor = System.Drawing.Color.Black
        Me.lblAutotanque.Location = New System.Drawing.Point(16, 52)
        Me.lblAutotanque.Name = "lblAutotanque"
        Me.lblAutotanque.Size = New System.Drawing.Size(66, 14)
        Me.lblAutotanque.TabIndex = 1
        Me.lblAutotanque.Text = "Au&totanque:"
        '
        'lblFolio
        '
        Me.lblFolio.AutoSize = True
        Me.lblFolio.ForeColor = System.Drawing.Color.Black
        Me.lblFolio.Location = New System.Drawing.Point(16, 26)
        Me.lblFolio.Name = "lblFolio"
        Me.lblFolio.Size = New System.Drawing.Size(32, 14)
        Me.lblFolio.TabIndex = 0
        Me.lblFolio.Text = "&Folio:"
        '
        'rgrpOpciones
        '
        Me.rgrpOpciones.BorderColor = System.Drawing.Color.Green
        Me.rgrpOpciones.Controls.AddRange(New System.Windows.Forms.Control() {Me.rdoCualquiera, Me.rdoTodos})
        Me.rgrpOpciones.FlatStyle = Logistica.RoundedGroupBox.Style.Road
        Me.rgrpOpciones.Location = New System.Drawing.Point(8, 144)
        Me.rgrpOpciones.Name = "rgrpOpciones"
        Me.rgrpOpciones.Size = New System.Drawing.Size(150, 83)
        Me.rgrpOpciones.TabIndex = 2
        Me.rgrpOpciones.TabStop = False
        Me.rgrpOpciones.Text = "Opciones de búsqueda"
        Me.rgrpOpciones.TextAlignment = System.Windows.Forms.HorizontalAlignment.Left
        '
        'rdoCualquiera
        '
        Me.rdoCualquiera.Location = New System.Drawing.Point(24, 56)
        Me.rdoCualquiera.Name = "rdoCualquiera"
        Me.rdoCualquiera.Size = New System.Drawing.Size(112, 24)
        Me.rdoCualquiera.TabIndex = 1
        Me.rdoCualquiera.Text = "Cualquier campo"
        '
        'rdoTodos
        '
        Me.rdoTodos.Checked = True
        Me.rdoTodos.Location = New System.Drawing.Point(24, 24)
        Me.rdoTodos.Name = "rdoTodos"
        Me.rdoTodos.Size = New System.Drawing.Size(112, 24)
        Me.rdoTodos.TabIndex = 0
        Me.rdoTodos.TabStop = True
        Me.rdoTodos.Text = "Todos los campos"
        '
        'btnCancelar
        '
        Me.btnCancelar.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnCancelar.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnCancelar.Image = CType(resources.GetObject("btnCancelar.Image"), System.Drawing.Bitmap)
        Me.btnCancelar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnCancelar.Location = New System.Drawing.Point(170, 197)
        Me.btnCancelar.Name = "btnCancelar"
        Me.btnCancelar.Size = New System.Drawing.Size(80, 24)
        Me.btnCancelar.TabIndex = 4
        Me.btnCancelar.Text = "&Cancelar"
        Me.btnCancelar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'btnAceptar
        '
        Me.btnAceptar.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnAceptar.Image = CType(resources.GetObject("btnAceptar.Image"), System.Drawing.Bitmap)
        Me.btnAceptar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnAceptar.Location = New System.Drawing.Point(170, 157)
        Me.btnAceptar.Name = "btnAceptar"
        Me.btnAceptar.Size = New System.Drawing.Size(80, 24)
        Me.btnAceptar.TabIndex = 3
        Me.btnAceptar.Text = "&Aceptar"
        Me.btnAceptar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'frmBusquedaFolios
        '
        Me.AcceptButton = Me.btnAceptar
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 14)
        Me.BackColor = System.Drawing.Color.Gainsboro
        Me.CancelButton = Me.btnCancelar
        Me.ClientSize = New System.Drawing.Size(266, 239)
        Me.Controls.AddRange(New System.Windows.Forms.Control() {Me.btnCancelar, Me.btnAceptar, Me.rgrpOpciones, Me.rgrpDatosAutotanque})
        Me.DockPadding.All = 5
        Me.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmBusquedaFolios"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Busqueda de folios"
        Me.rgrpDatosAutotanque.ResumeLayout(False)
        Me.rgrpOpciones.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

#End Region

    Private Sub btnAceptar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAceptar.Click
        Dim ctrl As Control
        Me.DialogResult = DialogResult.Abort
        For Each ctrl In rgrpDatosAutotanque.Controls
            If ctrl.GetType.Name = "TextBox" AndAlso ctrl.Text.Trim <> "" Then
                Me.DialogResult = DialogResult.OK
            End If
        Next
        Me.Close()
    End Sub

    Private Sub TextBox_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtAutotanque.Enter, txtFolio.Enter, txtPlacas.Enter, txtRuta.Enter
        CType(sender, TextBox).BackColor = Color.LightGoldenrodYellow
    End Sub
    Private Sub TextBox_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtAutotanque.Leave, txtFolio.Leave, txtPlacas.Leave, txtRuta.Leave
        CType(sender, TextBox).BackColor = Color.White
    End Sub

    Private Sub TextBox_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtAutotanque.KeyPress, txtFolio.KeyPress, txtRuta.KeyPress
        If Not (Char.IsDigit(e.KeyChar) Or Asc(e.KeyChar) = 8 Or Char.IsControl(e.KeyChar)) Then
            e.Handled = True
        Else
            e.Handled = False
        End If
    End Sub
End Class
