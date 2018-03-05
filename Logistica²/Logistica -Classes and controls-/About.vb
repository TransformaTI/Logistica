Public Class frmAbout
    Inherits System.Windows.Forms.Form

#Region " Windows Form Designer generated code "

    Public Sub New()
        MyBase.New()

        'This call is required by the Windows Form Designer.
        InitializeComponent()

        'Add any initialization after the InitializeComponent() call
        rtbMensaje.Rtf = "{\rtf1\ansi\ansicpg1252\deff0\deflang2058{\fonttbl{\f0\fswiss\fprq2\fcharset0 Arial Black;}{\f1\fmodern\fprq1\fcharset0 Courier New;}}" & _
"{\colortbl ;\red0\green0\blue128;\red0\green51\blue102;}" & _
"\viewkind4\uc1\pard\qc\f0\fs32 Logistica.dll\par" & _
"\pard\qj\cf1\f1\fs20\par" & _
"\pard La biblioteca Log\'edstica.dll, todos los componentes y funciones contenidas en ella, fueron dise\'f1ados y desarrollados por \cf2\f0 Manuel Ruiz Mendoza\cf1\f1  para uso exclusivo en el m\'f3dulo \lang3082 Log\'edstica\'b2 del sistema \'a9SIGAMET de GAS METROPOLITANO S.A. DE C.V..}"

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
    Friend WithEvents rtbMensaje As System.Windows.Forms.RichTextBox
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(frmAbout))
        Me.btnAceptar = New System.Windows.Forms.Button()
        Me.rtbMensaje = New System.Windows.Forms.RichTextBox()
        Me.SuspendLayout()
        '
        'btnAceptar
        '
        Me.btnAceptar.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnAceptar.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnAceptar.Image = CType(resources.GetObject("btnAceptar.Image"), System.Drawing.Bitmap)
        Me.btnAceptar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnAceptar.Location = New System.Drawing.Point(128, 197)
        Me.btnAceptar.Name = "btnAceptar"
        Me.btnAceptar.TabIndex = 0
        Me.btnAceptar.Text = "&Aceptar"
        Me.btnAceptar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'rtbMensaje
        '
        Me.rtbMensaje.BackColor = System.Drawing.Color.Gainsboro
        Me.rtbMensaje.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.rtbMensaje.Dock = System.Windows.Forms.DockStyle.Top
        Me.rtbMensaje.Location = New System.Drawing.Point(10, 10)
        Me.rtbMensaje.Name = "rtbMensaje"
        Me.rtbMensaje.ReadOnly = True
        Me.rtbMensaje.Size = New System.Drawing.Size(310, 174)
        Me.rtbMensaje.TabIndex = 2
        Me.rtbMensaje.Text = ""
        '
        'frmAbout
        '
        Me.AcceptButton = Me.btnAceptar
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 14)
        Me.BackColor = System.Drawing.Color.WhiteSmoke
        Me.CancelButton = Me.btnAceptar
        Me.ClientSize = New System.Drawing.Size(330, 234)
        Me.Controls.AddRange(New System.Windows.Forms.Control() {Me.rtbMensaje, Me.btnAceptar})
        Me.DockPadding.All = 10
        Me.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "frmAbout"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Acerca de Logística.dll"
        Me.TopMost = True
        Me.ResumeLayout(False)

    End Sub

#End Region

    
    
    Private Sub btnAceptar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAceptar.Click
        Me.Close()
        Me.Dispose()
    End Sub
End Class
