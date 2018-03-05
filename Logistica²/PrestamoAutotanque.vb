Imports System.Data.SqlClient

Public Class frmPrestamoAutotanque
    Inherits System.Windows.Forms.Form

#Region " Windows Form Designer generated code "

    Public Sub New(ByVal Celula As Integer, ByVal Fecha As DateTime)
        MyBase.New()

        'This call is required by the Windows Form Designer.
        InitializeComponent()

        'Add any initialization after the InitializeComponent() call
        Dim daLogistica As New SqlDataAdapter("Select Celula, Descripcion from Celula where Comercial = 1 and Celula not in (@Celula, 0) ", cnSigamet)
        Dim dtCelula As New DataTable()
        Dim dtAutotanque As New DataTable()
        Me.Fecha = Fecha
        daLogistica.SelectCommand.Parameters.Add("@Celula", SqlDbType.TinyInt).Value = Celula
        daLogistica.SelectCommand.Parameters.Add("@Fecha", SqlDbType.DateTime).Value = Fecha
        Try
            daLogistica.Fill(dtCelula)
            daLogistica.SelectCommand.CommandText = "exec spLogAutotanquePrestable @Celula, @Fecha"
            daLogistica.Fill(dtAutotanque)
        Catch ex As Exception
            ExMessage(ex)
        Finally
            daLogistica.Dispose()
        End Try

        cboCelula.ValueMember = "Celula"
        cboCelula.DisplayMember = "Descripcion"
        cboCelula.DataSource = dtCelula

        scboAutotanque.DisplayMember = "Descripcion"
        scboAutotanque.ValueMember = "Folio"
        scboAutotanque.DataSource = dtAutotanque

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
    Friend WithEvents lblAutotanque As System.Windows.Forms.Label
    Friend WithEvents lblCelula As System.Windows.Forms.Label
    Friend WithEvents cboCelula As System.Windows.Forms.ComboBox
    Friend WithEvents scboAutotanque As Logistica.SelfCompletitionComboBox
    Friend WithEvents btnCancelar As System.Windows.Forms.Button
    Friend WithEvents btnAceptar As System.Windows.Forms.Button
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(frmPrestamoAutotanque))
        Me.rgrpDatos = New Logistica.RoundedGroupBox()
        Me.scboAutotanque = New Logistica.SelfCompletitionComboBox()
        Me.cboCelula = New System.Windows.Forms.ComboBox()
        Me.lblCelula = New System.Windows.Forms.Label()
        Me.lblAutotanque = New System.Windows.Forms.Label()
        Me.btnCancelar = New System.Windows.Forms.Button()
        Me.btnAceptar = New System.Windows.Forms.Button()
        Me.rgrpDatos.SuspendLayout()
        Me.SuspendLayout()
        '
        'rgrpDatos
        '
        Me.rgrpDatos.BorderColor = System.Drawing.Color.Green
        Me.rgrpDatos.Controls.AddRange(New System.Windows.Forms.Control() {Me.scboAutotanque, Me.cboCelula, Me.lblCelula, Me.lblAutotanque})
        Me.rgrpDatos.Dock = System.Windows.Forms.DockStyle.Left
        Me.rgrpDatos.FlatStyle = Logistica.RoundedGroupBox.Style.Pipe
        Me.rgrpDatos.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rgrpDatos.ForeColor = System.Drawing.Color.DarkGreen
        Me.rgrpDatos.Location = New System.Drawing.Point(5, 5)
        Me.rgrpDatos.Name = "rgrpDatos"
        Me.rgrpDatos.Size = New System.Drawing.Size(283, 91)
        Me.rgrpDatos.TabIndex = 0
        Me.rgrpDatos.TabStop = False
        Me.rgrpDatos.Text = "Datos del prestamo"
        Me.rgrpDatos.TextAlignment = System.Windows.Forms.HorizontalAlignment.Center
        '
        'scboAutotanque
        '
        Me.scboAutotanque.CorrectOnWriting = True
        Me.scboAutotanque.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.scboAutotanque.ForeColor = System.Drawing.Color.Black
        Me.scboAutotanque.Location = New System.Drawing.Point(104, 26)
        Me.scboAutotanque.Name = "scboAutotanque"
        Me.scboAutotanque.Size = New System.Drawing.Size(167, 21)
        Me.scboAutotanque.TabIndex = 1
        Me.scboAutotanque.TrySimilarOnLeave = True
        '
        'cboCelula
        '
        Me.cboCelula.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboCelula.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboCelula.ForeColor = System.Drawing.Color.Black
        Me.cboCelula.Location = New System.Drawing.Point(104, 56)
        Me.cboCelula.Name = "cboCelula"
        Me.cboCelula.Size = New System.Drawing.Size(167, 21)
        Me.cboCelula.TabIndex = 2
        '
        'lblCelula
        '
        Me.lblCelula.AutoSize = True
        Me.lblCelula.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCelula.ForeColor = System.Drawing.Color.Black
        Me.lblCelula.Location = New System.Drawing.Point(15, 59)
        Me.lblCelula.Name = "lblCelula"
        Me.lblCelula.Size = New System.Drawing.Size(78, 14)
        Me.lblCelula.TabIndex = 1
        Me.lblCelula.Text = "Celula &destino:"
        '
        'lblAutotanque
        '
        Me.lblAutotanque.AutoSize = True
        Me.lblAutotanque.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblAutotanque.ForeColor = System.Drawing.Color.Black
        Me.lblAutotanque.Location = New System.Drawing.Point(15, 29)
        Me.lblAutotanque.Name = "lblAutotanque"
        Me.lblAutotanque.Size = New System.Drawing.Size(66, 14)
        Me.lblAutotanque.TabIndex = 0
        Me.lblAutotanque.Text = "&Autotanque:"
        '
        'btnCancelar
        '
        Me.btnCancelar.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnCancelar.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnCancelar.Image = CType(resources.GetObject("btnCancelar.Image"), System.Drawing.Bitmap)
        Me.btnCancelar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnCancelar.Location = New System.Drawing.Point(300, 54)
        Me.btnCancelar.Name = "btnCancelar"
        Me.btnCancelar.Size = New System.Drawing.Size(74, 24)
        Me.btnCancelar.TabIndex = 2
        Me.btnCancelar.Text = "&Cancelar"
        Me.btnCancelar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'btnAceptar
        '
        Me.btnAceptar.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnAceptar.Image = CType(resources.GetObject("btnAceptar.Image"), System.Drawing.Bitmap)
        Me.btnAceptar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnAceptar.Location = New System.Drawing.Point(300, 22)
        Me.btnAceptar.Name = "btnAceptar"
        Me.btnAceptar.Size = New System.Drawing.Size(74, 24)
        Me.btnAceptar.TabIndex = 1
        Me.btnAceptar.Text = "&Aceptar"
        Me.btnAceptar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'frmPrestamoAutotanque
        '
        Me.AcceptButton = Me.btnAceptar
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 14)
        Me.BackColor = System.Drawing.Color.Gainsboro
        Me.CancelButton = Me.btnCancelar
        Me.ClientSize = New System.Drawing.Size(386, 101)
        Me.Controls.AddRange(New System.Windows.Forms.Control() {Me.btnCancelar, Me.btnAceptar, Me.rgrpDatos})
        Me.DockPadding.All = 5
        Me.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmPrestamoAutotanque"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Prestamo de autotanques"
        Me.rgrpDatos.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

#End Region

    Private Fecha As DateTime
    
    Private Sub btnAceptar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAceptar.Click
        If Not scboAutotanque.SelectedItem Is Nothing Then
            If MessageBox.Show("¿Desea realizar el siguiente prestamo?" & Chr(13) & "     Autotanque: " & scboAutotanque.Text _
                                    & Chr(13) & "     Célula destino: " & cboCelula.Text, Application.ProductName & " v." & Application.ProductVersion, MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
                Dim cmdLogistica As New SqlCommand("exec spLOGPrestamoAutotanque  @Autotanque, @Folio, @Año, @Fecha, @Celula, @Usuario", cnSigamet)
                Dim rw As DataRow = CType(scboAutotanque.SelectedItem, DataRowView).Row
                cmdLogistica.Parameters.Add("@Autotanque", SqlDbType.Int).Value = CInt(rw("Autotanque"))
                cmdLogistica.Parameters.Add("@Fecha", SqlDbType.DateTime).Value = Fecha
                cmdLogistica.Parameters.Add("@Celula", SqlDbType.TinyInt).Value = CInt(cboCelula.SelectedValue)
                cmdLogistica.Parameters.Add("@Usuario", SqlDbType.Char).Value = _Usuario
                cmdLogistica.Parameters.Add("@Folio", SqlDbType.Int).Value = CInt(rw("Folio"))
                cmdLogistica.Parameters.Add("@Año", SqlDbType.Int).Value = CInt(rw("AñoAtt"))
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
