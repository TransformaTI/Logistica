<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmNuevoRuta
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmNuevoRuta))
        Me.LblRuta = New System.Windows.Forms.Label()
        Me.LblPL = New System.Windows.Forms.Label()
        Me.chbComision = New System.Windows.Forms.CheckBox()
        Me.txtPrecioLitro = New System.Windows.Forms.TextBox()
        Me.rgrpDatos = New Logistica.RoundedGroupBox()
        Me.LblComision = New System.Windows.Forms.Label()
        Me.btnCancelar = New System.Windows.Forms.Button()
        Me.btnAceptar = New System.Windows.Forms.Button()
        Me.txtIdRuta = New System.Windows.Forms.TextBox()
        Me.txtDescripcion = New System.Windows.Forms.TextBox()
        Me.lblDescripcion = New System.Windows.Forms.Label()
        Me.rgrpDatos.SuspendLayout()
        Me.SuspendLayout()
        '
        'LblRuta
        '
        Me.LblRuta.AutoSize = True
        Me.LblRuta.Location = New System.Drawing.Point(12, 26)
        Me.LblRuta.Name = "LblRuta"
        Me.LblRuta.Size = New System.Drawing.Size(33, 13)
        Me.LblRuta.TabIndex = 0
        Me.LblRuta.Text = "Ruta:"
        '
        'LblPL
        '
        Me.LblPL.AutoSize = True
        Me.LblPL.Location = New System.Drawing.Point(13, 99)
        Me.LblPL.Name = "LblPL"
        Me.LblPL.Size = New System.Drawing.Size(29, 13)
        Me.LblPL.TabIndex = 1
        Me.LblPL.Text = "P. L:"
        '
        'chbComision
        '
        Me.chbComision.AutoSize = True
        Me.chbComision.Location = New System.Drawing.Point(85, 76)
        Me.chbComision.Name = "chbComision"
        Me.chbComision.Size = New System.Drawing.Size(15, 14)
        Me.chbComision.TabIndex = 2
        Me.chbComision.TextAlign = System.Drawing.ContentAlignment.TopLeft
        Me.chbComision.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.chbComision.UseVisualStyleBackColor = True
        '
        'txtPrecioLitro
        '
        Me.txtPrecioLitro.Location = New System.Drawing.Point(85, 95)
        Me.txtPrecioLitro.Name = "txtPrecioLitro"
        Me.txtPrecioLitro.Size = New System.Drawing.Size(100, 20)
        Me.txtPrecioLitro.TabIndex = 3
        '
        'rgrpDatos
        '
        Me.rgrpDatos.BorderColor = System.Drawing.Color.SteelBlue
        Me.rgrpDatos.Controls.Add(Me.txtDescripcion)
        Me.rgrpDatos.Controls.Add(Me.lblDescripcion)
        Me.rgrpDatos.Controls.Add(Me.txtIdRuta)
        Me.rgrpDatos.Controls.Add(Me.LblComision)
        Me.rgrpDatos.Controls.Add(Me.LblRuta)
        Me.rgrpDatos.Controls.Add(Me.chbComision)
        Me.rgrpDatos.Controls.Add(Me.txtPrecioLitro)
        Me.rgrpDatos.Controls.Add(Me.LblPL)
        Me.rgrpDatos.Dock = System.Windows.Forms.DockStyle.Left
        Me.rgrpDatos.ForeColor = System.Drawing.Color.DarkBlue
        Me.rgrpDatos.Location = New System.Drawing.Point(0, 0)
        Me.rgrpDatos.Name = "rgrpDatos"
        Me.rgrpDatos.Size = New System.Drawing.Size(209, 135)
        Me.rgrpDatos.TabIndex = 7
        Me.rgrpDatos.TabStop = False
        Me.rgrpDatos.Text = "Datos de la ruta"
        Me.rgrpDatos.TextAlignment = System.Windows.Forms.HorizontalAlignment.Center
        '
        'LblComision
        '
        Me.LblComision.AutoSize = True
        Me.LblComision.Location = New System.Drawing.Point(12, 76)
        Me.LblComision.Name = "LblComision"
        Me.LblComision.Size = New System.Drawing.Size(49, 13)
        Me.LblComision.TabIndex = 7
        Me.LblComision.Text = "Comisión"
        '
        'btnCancelar
        '
        Me.btnCancelar.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnCancelar.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnCancelar.Image = CType(resources.GetObject("btnCancelar.Image"), System.Drawing.Image)
        Me.btnCancelar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnCancelar.Location = New System.Drawing.Point(215, 48)
        Me.btnCancelar.Name = "btnCancelar"
        Me.btnCancelar.Size = New System.Drawing.Size(75, 24)
        Me.btnCancelar.TabIndex = 9
        Me.btnCancelar.Text = "&Cancelar"
        Me.btnCancelar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'btnAceptar
        '
        Me.btnAceptar.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnAceptar.Image = CType(resources.GetObject("btnAceptar.Image"), System.Drawing.Image)
        Me.btnAceptar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnAceptar.Location = New System.Drawing.Point(215, 12)
        Me.btnAceptar.Name = "btnAceptar"
        Me.btnAceptar.Size = New System.Drawing.Size(75, 24)
        Me.btnAceptar.TabIndex = 8
        Me.btnAceptar.Text = "&Aceptar"
        Me.btnAceptar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'txtIdRuta
        '
        Me.txtIdRuta.Location = New System.Drawing.Point(85, 21)
        Me.txtIdRuta.Name = "txtIdRuta"
        Me.txtIdRuta.ReadOnly = True
        Me.txtIdRuta.Size = New System.Drawing.Size(100, 20)
        Me.txtIdRuta.TabIndex = 8
        '
        'txtDescripcion
        '
        Me.txtDescripcion.Location = New System.Drawing.Point(85, 46)
        Me.txtDescripcion.Name = "txtDescripcion"
        Me.txtDescripcion.ReadOnly = True
        Me.txtDescripcion.Size = New System.Drawing.Size(100, 20)
        Me.txtDescripcion.TabIndex = 10
        '
        'lblDescripcion
        '
        Me.lblDescripcion.AutoSize = True
        Me.lblDescripcion.Location = New System.Drawing.Point(12, 51)
        Me.lblDescripcion.Name = "lblDescripcion"
        Me.lblDescripcion.Size = New System.Drawing.Size(66, 13)
        Me.lblDescripcion.TabIndex = 9
        Me.lblDescripcion.Text = "Descripción:"
        '
        'frmNuevoRuta
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.ClientSize = New System.Drawing.Size(299, 135)
        Me.Controls.Add(Me.btnCancelar)
        Me.Controls.Add(Me.btnAceptar)
        Me.Controls.Add(Me.rgrpDatos)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmNuevoRuta"
        Me.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Comisión"
        Me.rgrpDatos.ResumeLayout(False)
        Me.rgrpDatos.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents LblRuta As System.Windows.Forms.Label
    Friend WithEvents LblPL As System.Windows.Forms.Label
    Friend WithEvents chbComision As System.Windows.Forms.CheckBox
    Friend WithEvents txtPrecioLitro As System.Windows.Forms.TextBox
    Friend WithEvents rgrpDatos As Logistica.RoundedGroupBox
    Friend WithEvents btnCancelar As System.Windows.Forms.Button
    Friend WithEvents btnAceptar As System.Windows.Forms.Button
    Friend WithEvents LblComision As System.Windows.Forms.Label
    Friend WithEvents txtDescripcion As System.Windows.Forms.TextBox
    Friend WithEvents lblDescripcion As System.Windows.Forms.Label
    Friend WithEvents txtIdRuta As System.Windows.Forms.TextBox
End Class
