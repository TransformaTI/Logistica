Public Class frmAcerca
    Inherits System.Windows.Forms.Form

#Region " Windows Form Designer generated code "

    Public Sub New()
        MyBase.New()

        'This call is required by the Windows Form Designer.
        InitializeComponent()

        'Add any initialization after the InitializeComponent() call
        lblProducto.Text = Application.ProductName
        lblVersion.Text &= Application.ProductVersion

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
    Friend WithEvents pnlLogistica As System.Windows.Forms.Panel
    Friend WithEvents lblProducto As System.Windows.Forms.Label
    Friend WithEvents lblEmpresa As System.Windows.Forms.Label
    Friend WithEvents lblAutor As System.Windows.Forms.Label
    Friend WithEvents btnAceptar As System.Windows.Forms.Button
    Friend WithEvents lblMas As System.Windows.Forms.Label
    Friend WithEvents imgAceptar As System.Windows.Forms.ImageList
    Friend WithEvents lblVersion As System.Windows.Forms.Label
    Friend WithEvents picSIGAMET As System.Windows.Forms.PictureBox
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(frmAcerca))
        Me.pnlLogistica = New System.Windows.Forms.Panel()
        Me.lblEmpresa = New System.Windows.Forms.Label()
        Me.picSIGAMET = New System.Windows.Forms.PictureBox()
        Me.lblProducto = New System.Windows.Forms.Label()
        Me.lblMas = New System.Windows.Forms.Label()
        Me.lblAutor = New System.Windows.Forms.Label()
        Me.lblVersion = New System.Windows.Forms.Label()
        Me.btnAceptar = New System.Windows.Forms.Button()
        Me.imgAceptar = New System.Windows.Forms.ImageList(Me.components)
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.pnlLogistica.SuspendLayout()
        Me.SuspendLayout()
        '
        'pnlLogistica
        '
        Me.pnlLogistica.BackColor = System.Drawing.Color.Gainsboro
        Me.pnlLogistica.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.pnlLogistica.Controls.AddRange(New System.Windows.Forms.Control() {Me.lblEmpresa, Me.picSIGAMET, Me.lblProducto, Me.lblMas, Me.lblAutor, Me.lblVersion})
        Me.pnlLogistica.Location = New System.Drawing.Point(4, 8)
        Me.pnlLogistica.Name = "pnlLogistica"
        Me.pnlLogistica.Size = New System.Drawing.Size(243, 106)
        Me.pnlLogistica.TabIndex = 0
        '
        'lblEmpresa
        '
        Me.lblEmpresa.AutoSize = True
        Me.lblEmpresa.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblEmpresa.Location = New System.Drawing.Point(32, 56)
        Me.lblEmpresa.Name = "lblEmpresa"
        Me.lblEmpresa.Size = New System.Drawing.Size(200, 14)
        Me.lblEmpresa.TabIndex = 2
        Me.lblEmpresa.Text = "GAS METROPOLITANO S.A. de C.V."
        '
        'picSIGAMET
        '
        Me.picSIGAMET.BackColor = System.Drawing.Color.Gainsboro
        Me.picSIGAMET.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.picSIGAMET.Image = CType(resources.GetObject("picSIGAMET.Image"), System.Drawing.Bitmap)
        Me.picSIGAMET.Location = New System.Drawing.Point(8, 8)
        Me.picSIGAMET.Name = "picSIGAMET"
        Me.picSIGAMET.Size = New System.Drawing.Size(32, 32)
        Me.picSIGAMET.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize
        Me.picSIGAMET.TabIndex = 1
        Me.picSIGAMET.TabStop = False
        '
        'lblProducto
        '
        Me.lblProducto.AutoSize = True
        Me.lblProducto.Font = New System.Drawing.Font("Tahoma", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblProducto.Location = New System.Drawing.Point(56, 11)
        Me.lblProducto.Name = "lblProducto"
        Me.lblProducto.Size = New System.Drawing.Size(116, 26)
        Me.lblProducto.TabIndex = 0
        Me.lblProducto.Text = "Logística²"
        '
        'lblMas
        '
        Me.lblMas.AutoSize = True
        Me.lblMas.Cursor = System.Windows.Forms.Cursors.Hand
        Me.lblMas.Font = New System.Drawing.Font("Tahoma", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblMas.ForeColor = System.Drawing.Color.DimGray
        Me.lblMas.Location = New System.Drawing.Point(120, 77)
        Me.lblMas.Name = "lblMas"
        Me.lblMas.Size = New System.Drawing.Size(10, 11)
        Me.lblMas.TabIndex = 4
        Me.lblMas.Text = "+"
        '
        'lblAutor
        '
        Me.lblAutor.AutoSize = True
        Me.lblAutor.Location = New System.Drawing.Point(32, 80)
        Me.lblAutor.Name = "lblAutor"
        Me.lblAutor.Size = New System.Drawing.Size(96, 14)
        Me.lblAutor.TabIndex = 3
        Me.lblAutor.Text = "Manuel Ruiz 2004."
        '
        'lblVersion
        '
        Me.lblVersion.AutoSize = True
        Me.lblVersion.Location = New System.Drawing.Point(61, 34)
        Me.lblVersion.Name = "lblVersion"
        Me.lblVersion.Size = New System.Drawing.Size(13, 14)
        Me.lblVersion.TabIndex = 1
        Me.lblVersion.Text = "v."
        '
        'btnAceptar
        '
        Me.btnAceptar.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnAceptar.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnAceptar.Image = CType(resources.GetObject("btnAceptar.Image"), System.Drawing.Bitmap)
        Me.btnAceptar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnAceptar.ImageIndex = 0
        Me.btnAceptar.ImageList = Me.imgAceptar
        Me.btnAceptar.Location = New System.Drawing.Point(230, 142)
        Me.btnAceptar.Name = "btnAceptar"
        Me.btnAceptar.Size = New System.Drawing.Size(20, 20)
        Me.btnAceptar.TabIndex = 0
        Me.btnAceptar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'imgAceptar
        '
        Me.imgAceptar.ColorDepth = System.Windows.Forms.ColorDepth.Depth8Bit
        Me.imgAceptar.ImageSize = New System.Drawing.Size(12, 12)
        Me.imgAceptar.ImageStream = CType(resources.GetObject("imgAceptar.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.imgAceptar.TransparentColor = System.Drawing.Color.Transparent
        '
        'PictureBox1
        '
        Me.PictureBox1.BackColor = System.Drawing.Color.Gainsboro
        Me.PictureBox1.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.PictureBox1.Image = CType(resources.GetObject("PictureBox1.Image"), System.Drawing.Bitmap)
        Me.PictureBox1.Location = New System.Drawing.Point(85, 122)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(92, 48)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox1.TabIndex = 1
        Me.PictureBox1.TabStop = False
        '
        'frmAcerca
        '
        Me.AcceptButton = Me.btnAceptar
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 14)
        Me.BackColor = System.Drawing.Color.White
        Me.CancelButton = Me.btnAceptar
        Me.ClientSize = New System.Drawing.Size(250, 162)
        Me.Controls.AddRange(New System.Windows.Forms.Control() {Me.pnlLogistica, Me.PictureBox1, Me.btnAceptar})
        Me.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.MaximumSize = New System.Drawing.Size(288, 272)
        Me.Name = "frmAcerca"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Acerca de Logística²"
        Me.pnlLogistica.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

#End Region

    Private Sub btnAceptar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAceptar.Click
        Me.Close()
        Me.Dispose()
    End Sub

    Private Sub lblMas_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lblMas.Click
        Dim frmAboutDLL As New Logistica.frmAbout()
        frmAboutDLL.ShowDialog()
    End Sub
End Class
