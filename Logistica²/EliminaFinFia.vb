Imports System.Data.SqlClient
Imports System.Security.Cryptography
Imports System.Text

Public Class frmEliminaFinDia
    Inherits System.Windows.Forms.Form

#Region " Windows Form Designer generated code "

    Public Sub New(ByVal idusuario As Integer, ByVal Usuario As String)
        MyBase.New()

        'This call is required by the Windows Form Designer.
        InitializeComponent()

        'Parametros de default
        Application.DoEvents()

        Me.Text = "Fin de día"

        txtIdUsuario.Text = CStr(idusuario)
        txtUsuarioMovil.Text = Usuario
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
    Friend WithEvents btnCancelar As System.Windows.Forms.Button
    Friend WithEvents btnAceptar As System.Windows.Forms.Button
    Friend WithEvents rgrpDatos As Logistica.RoundedGroupBox
    Friend WithEvents lblIdUsuario As System.Windows.Forms.Label
    Friend WithEvents txtIdUsuario As System.Windows.Forms.TextBox
    Friend WithEvents lblUsuarioMovil As System.Windows.Forms.Label
    Friend WithEvents DateTimePicker1 As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txtUsuarioMovil As System.Windows.Forms.TextBox

    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmEliminaFinDia))
        Me.btnCancelar = New System.Windows.Forms.Button()
        Me.btnAceptar = New System.Windows.Forms.Button()
        Me.rgrpDatos = New Logistica.RoundedGroupBox()
        Me.DateTimePicker1 = New System.Windows.Forms.DateTimePicker()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.lblUsuarioMovil = New System.Windows.Forms.Label()
        Me.txtUsuarioMovil = New System.Windows.Forms.TextBox()
        Me.lblIdUsuario = New System.Windows.Forms.Label()
        Me.txtIdUsuario = New System.Windows.Forms.TextBox()
        Me.rgrpDatos.SuspendLayout()
        Me.SuspendLayout()
        '
        'btnCancelar
        '
        Me.btnCancelar.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnCancelar.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnCancelar.Image = CType(resources.GetObject("btnCancelar.Image"), System.Drawing.Image)
        Me.btnCancelar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnCancelar.Location = New System.Drawing.Point(241, 44)
        Me.btnCancelar.Name = "btnCancelar"
        Me.btnCancelar.Size = New System.Drawing.Size(80, 24)
        Me.btnCancelar.TabIndex = 12
        Me.btnCancelar.Text = "&Cancelar"
        Me.btnCancelar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'btnAceptar
        '
        Me.btnAceptar.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnAceptar.Image = CType(resources.GetObject("btnAceptar.Image"), System.Drawing.Image)
        Me.btnAceptar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnAceptar.Location = New System.Drawing.Point(241, 16)
        Me.btnAceptar.Name = "btnAceptar"
        Me.btnAceptar.Size = New System.Drawing.Size(80, 24)
        Me.btnAceptar.TabIndex = 11
        Me.btnAceptar.Text = "&Aceptar"
        Me.btnAceptar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'rgrpDatos
        '
        Me.rgrpDatos.BorderColor = System.Drawing.Color.SteelBlue
        Me.rgrpDatos.Controls.Add(Me.DateTimePicker1)
        Me.rgrpDatos.Controls.Add(Me.Label1)
        Me.rgrpDatos.Controls.Add(Me.lblUsuarioMovil)
        Me.rgrpDatos.Controls.Add(Me.txtUsuarioMovil)
        Me.rgrpDatos.Controls.Add(Me.lblIdUsuario)
        Me.rgrpDatos.Controls.Add(Me.txtIdUsuario)
        Me.rgrpDatos.Dock = System.Windows.Forms.DockStyle.Left
        Me.rgrpDatos.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rgrpDatos.ForeColor = System.Drawing.Color.DarkBlue
        Me.rgrpDatos.Location = New System.Drawing.Point(3, 3)
        Me.rgrpDatos.Name = "rgrpDatos"
        Me.rgrpDatos.Size = New System.Drawing.Size(232, 116)
        Me.rgrpDatos.TabIndex = 0
        Me.rgrpDatos.TabStop = False
        Me.rgrpDatos.Text = "Eliminar fin de día"
        Me.rgrpDatos.TextAlignment = System.Windows.Forms.HorizontalAlignment.Center
        '
        'DateTimePicker1
        '
        Me.DateTimePicker1.Enabled = False
        Me.DateTimePicker1.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.DateTimePicker1.Location = New System.Drawing.Point(107, 83)
        Me.DateTimePicker1.Name = "DateTimePicker1"
        Me.DateTimePicker1.Size = New System.Drawing.Size(98, 21)
        Me.DateTimePicker1.TabIndex = 32
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.Black
        Me.Label1.Location = New System.Drawing.Point(13, 83)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(57, 13)
        Me.Label1.TabIndex = 31
        Me.Label1.Text = "Fin de día:"
        '
        'lblUsuarioMovil
        '
        Me.lblUsuarioMovil.AutoSize = True
        Me.lblUsuarioMovil.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblUsuarioMovil.ForeColor = System.Drawing.Color.Black
        Me.lblUsuarioMovil.Location = New System.Drawing.Point(13, 54)
        Me.lblUsuarioMovil.Name = "lblUsuarioMovil"
        Me.lblUsuarioMovil.Size = New System.Drawing.Size(74, 13)
        Me.lblUsuarioMovil.TabIndex = 30
        Me.lblUsuarioMovil.Text = "Usuario Móvil:"
        '
        'txtUsuarioMovil
        '
        Me.txtUsuarioMovil.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtUsuarioMovil.Enabled = False
        Me.txtUsuarioMovil.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtUsuarioMovil.ForeColor = System.Drawing.Color.Black
        Me.txtUsuarioMovil.Location = New System.Drawing.Point(107, 50)
        Me.txtUsuarioMovil.MaxLength = 20
        Me.txtUsuarioMovil.Name = "txtUsuarioMovil"
        Me.txtUsuarioMovil.Size = New System.Drawing.Size(98, 21)
        Me.txtUsuarioMovil.TabIndex = 2
        '
        'lblIdUsuario
        '
        Me.lblIdUsuario.AutoSize = True
        Me.lblIdUsuario.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblIdUsuario.ForeColor = System.Drawing.Color.Black
        Me.lblIdUsuario.Location = New System.Drawing.Point(13, 24)
        Me.lblIdUsuario.Name = "lblIdUsuario"
        Me.lblIdUsuario.Size = New System.Drawing.Size(65, 13)
        Me.lblIdUsuario.TabIndex = 0
        Me.lblIdUsuario.Text = "&IdUsuario:"
        '
        'txtIdUsuario
        '
        Me.txtIdUsuario.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtIdUsuario.Enabled = False
        Me.txtIdUsuario.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtIdUsuario.ForeColor = System.Drawing.Color.Black
        Me.txtIdUsuario.Location = New System.Drawing.Point(107, 20)
        Me.txtIdUsuario.MaxLength = 10
        Me.txtIdUsuario.Name = "txtIdUsuario"
        Me.txtIdUsuario.ReadOnly = True
        Me.txtIdUsuario.Size = New System.Drawing.Size(52, 21)
        Me.txtIdUsuario.TabIndex = 1
        '
        'frmEliminaFinDia
        '
        Me.AcceptButton = Me.btnAceptar
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 14)
        Me.BackColor = System.Drawing.Color.Gainsboro
        Me.CancelButton = Me.btnCancelar
        Me.ClientSize = New System.Drawing.Size(336, 122)
        Me.Controls.Add(Me.rgrpDatos)
        Me.Controls.Add(Me.btnAceptar)
        Me.Controls.Add(Me.btnCancelar)
        Me.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmEliminaFinDia"
        Me.Padding = New System.Windows.Forms.Padding(3)
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.rgrpDatos.ResumeLayout(False)
        Me.rgrpDatos.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

#End Region

#Region "Variables globales"
#End Region

#Region "Botones"
    Private Sub btnCancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancelar.Click
        Me.Close()
        Me.Dispose()
    End Sub
    Private Sub btnAceptar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAceptar.Click
        If (MessageBox.Show("¿Desea eliminar el fin de día?", "Eliminar fin de día", MessageBoxButtons.YesNo)) = Windows.Forms.DialogResult.Yes Then
            Dim cmdLogistica As SqlCommand
            Me.Cursor = Cursors.WaitCursor


            cmdLogistica = New SqlCommand("spLOGEliminarFinDeDia", cnSigamet)
            cmdLogistica.CommandType = CommandType.StoredProcedure

            ' Asignación de parámetros
            cmdLogistica.Parameters.Add("@IdUsuario", SqlDbType.Int).Value = txtIdUsuario.Text

            Try
                cnSigamet.Open()
                cmdLogistica.ExecuteNonQuery()
                Me.DialogResult = DialogResult.OK
                Me.Close()
            Catch ex As Exception
                ExMessage(ex)
            Finally
                Me.Cursor = Cursors.Default
                cnSigamet.Close()
                cmdLogistica.Dispose()
            End Try
        End If
    End Sub
#End Region


End Class
