Imports System.Data.SqlClient

Public Class frmAsignacionRutaGeneral
    Inherits System.Windows.Forms.Form

#Region " Windows Form Designer generated code "

    Public Sub New(ByVal Celula As Integer, ByVal Año As Integer, ByVal Folio As Integer, ByVal Autotanque As Integer, ByVal Ruta As Integer)
        MyBase.New()

        'This call is required by the Windows Form Designer.
        InitializeComponent()

        'Add any initialization after the InitializeComponent() call
        Dim daLogistica As New SqlDataAdapter("Select Celula from Celula where Comercial = 1 and Celula <> 0", cnSigamet)
        Dim dtCelula As New DataTable()
        Me.Año = Año
        txtAutotanque.Text = Autotanque.ToString
        txtFolio.Text = Folio.ToString
        txtRutaActual.Text = Ruta.ToString
        txtCelula.Text = Celula.ToString
        Try
            daLogistica.Fill(dtCelula)
            daLogistica.SelectCommand.CommandText = "Select Celula, Ruta from Ruta"
            daLogistica.Fill(dtRuta)
        Catch ex As Exception
            ExMessage(ex)
        Finally
            daLogistica.Dispose()
        End Try
        cboCelula.ValueMember = "Celula"
        cboCelula.DisplayMember = "Celula"
        cboCelula.DataSource = dtCelula
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
    Friend WithEvents lblFolio As System.Windows.Forms.Label
    Friend WithEvents lblRutaActual As System.Windows.Forms.Label
    Friend WithEvents lblNuevaRuta As System.Windows.Forms.Label
    Friend WithEvents txtRutaActual As System.Windows.Forms.TextBox
    Friend WithEvents txtAutotanque As System.Windows.Forms.TextBox
    Friend WithEvents txtFolio As System.Windows.Forms.TextBox
    Friend WithEvents Figure1 As Logistica.Figure
    Friend WithEvents btnCancelar As System.Windows.Forms.Button
    Friend WithEvents btnAceptar As System.Windows.Forms.Button
    Friend WithEvents scboRuta As Logistica.SelfCompletitionComboBox
    Friend WithEvents txtCelula As System.Windows.Forms.TextBox
    Friend WithEvents lblCelula As System.Windows.Forms.Label
    Friend WithEvents lblNuevaCelula As System.Windows.Forms.Label
    Friend WithEvents cboCelula As System.Windows.Forms.ComboBox
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(frmAsignacionRutaGeneral))
        Me.rgrpDatos = New Logistica.RoundedGroupBox()
        Me.cboCelula = New System.Windows.Forms.ComboBox()
        Me.scboRuta = New Logistica.SelfCompletitionComboBox()
        Me.txtFolio = New System.Windows.Forms.TextBox()
        Me.txtAutotanque = New System.Windows.Forms.TextBox()
        Me.txtRutaActual = New System.Windows.Forms.TextBox()
        Me.lblNuevaRuta = New System.Windows.Forms.Label()
        Me.lblRutaActual = New System.Windows.Forms.Label()
        Me.lblFolio = New System.Windows.Forms.Label()
        Me.lblAutotanque = New System.Windows.Forms.Label()
        Me.Figure1 = New Logistica.Figure()
        Me.txtCelula = New System.Windows.Forms.TextBox()
        Me.lblCelula = New System.Windows.Forms.Label()
        Me.lblNuevaCelula = New System.Windows.Forms.Label()
        Me.btnCancelar = New System.Windows.Forms.Button()
        Me.btnAceptar = New System.Windows.Forms.Button()
        Me.rgrpDatos.SuspendLayout()
        Me.SuspendLayout()
        '
        'rgrpDatos
        '
        Me.rgrpDatos.BorderColor = System.Drawing.Color.RosyBrown
        Me.rgrpDatos.Controls.AddRange(New System.Windows.Forms.Control() {Me.cboCelula, Me.scboRuta, Me.txtFolio, Me.txtAutotanque, Me.txtRutaActual, Me.lblNuevaRuta, Me.lblRutaActual, Me.lblFolio, Me.lblAutotanque, Me.Figure1, Me.txtCelula, Me.lblCelula, Me.lblNuevaCelula})
        Me.rgrpDatos.Dock = System.Windows.Forms.DockStyle.Left
        Me.rgrpDatos.FlatStyle = Logistica.RoundedGroupBox.Style.Pipe
        Me.rgrpDatos.Location = New System.Drawing.Point(5, 5)
        Me.rgrpDatos.Name = "rgrpDatos"
        Me.rgrpDatos.Size = New System.Drawing.Size(211, 197)
        Me.rgrpDatos.TabIndex = 0
        Me.rgrpDatos.TabStop = False
        Me.rgrpDatos.TextAlignment = System.Windows.Forms.HorizontalAlignment.Left
        '
        'cboCelula
        '
        Me.cboCelula.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboCelula.Location = New System.Drawing.Point(88, 133)
        Me.cboCelula.Name = "cboCelula"
        Me.cboCelula.Size = New System.Drawing.Size(105, 21)
        Me.cboCelula.TabIndex = 9
        '
        'scboRuta
        '
        Me.scboRuta.CorrectOnWriting = True
        Me.scboRuta.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.scboRuta.ForceCompleteOnLeave = True
        Me.scboRuta.Location = New System.Drawing.Point(87, 163)
        Me.scboRuta.Name = "scboRuta"
        Me.scboRuta.Size = New System.Drawing.Size(105, 21)
        Me.scboRuta.TabIndex = 4
        Me.scboRuta.TrySimilarOnLeave = True
        '
        'txtFolio
        '
        Me.txtFolio.BackColor = System.Drawing.Color.WhiteSmoke
        Me.txtFolio.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtFolio.Location = New System.Drawing.Point(87, 40)
        Me.txtFolio.Name = "txtFolio"
        Me.txtFolio.ReadOnly = True
        Me.txtFolio.Size = New System.Drawing.Size(105, 21)
        Me.txtFolio.TabIndex = 2
        Me.txtFolio.TabStop = False
        Me.txtFolio.Text = ""
        '
        'txtAutotanque
        '
        Me.txtAutotanque.BackColor = System.Drawing.Color.WhiteSmoke
        Me.txtAutotanque.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtAutotanque.Location = New System.Drawing.Point(87, 15)
        Me.txtAutotanque.Name = "txtAutotanque"
        Me.txtAutotanque.ReadOnly = True
        Me.txtAutotanque.Size = New System.Drawing.Size(105, 21)
        Me.txtAutotanque.TabIndex = 1
        Me.txtAutotanque.TabStop = False
        Me.txtAutotanque.Text = ""
        '
        'txtRutaActual
        '
        Me.txtRutaActual.BackColor = System.Drawing.Color.WhiteSmoke
        Me.txtRutaActual.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtRutaActual.Location = New System.Drawing.Point(87, 65)
        Me.txtRutaActual.Name = "txtRutaActual"
        Me.txtRutaActual.ReadOnly = True
        Me.txtRutaActual.Size = New System.Drawing.Size(105, 21)
        Me.txtRutaActual.TabIndex = 3
        Me.txtRutaActual.TabStop = False
        Me.txtRutaActual.Text = ""
        '
        'lblNuevaRuta
        '
        Me.lblNuevaRuta.AutoSize = True
        Me.lblNuevaRuta.Location = New System.Drawing.Point(16, 166)
        Me.lblNuevaRuta.Name = "lblNuevaRuta"
        Me.lblNuevaRuta.Size = New System.Drawing.Size(63, 14)
        Me.lblNuevaRuta.TabIndex = 3
        Me.lblNuevaRuta.Text = "Nueva &ruta:"
        '
        'lblRutaActual
        '
        Me.lblRutaActual.AutoSize = True
        Me.lblRutaActual.Location = New System.Drawing.Point(16, 68)
        Me.lblRutaActual.Name = "lblRutaActual"
        Me.lblRutaActual.Size = New System.Drawing.Size(65, 14)
        Me.lblRutaActual.TabIndex = 2
        Me.lblRutaActual.Text = "Ruta act&ual:"
        '
        'lblFolio
        '
        Me.lblFolio.AutoSize = True
        Me.lblFolio.Location = New System.Drawing.Point(16, 43)
        Me.lblFolio.Name = "lblFolio"
        Me.lblFolio.Size = New System.Drawing.Size(32, 14)
        Me.lblFolio.TabIndex = 1
        Me.lblFolio.Text = "&Folio:"
        '
        'lblAutotanque
        '
        Me.lblAutotanque.AutoSize = True
        Me.lblAutotanque.Location = New System.Drawing.Point(16, 18)
        Me.lblAutotanque.Name = "lblAutotanque"
        Me.lblAutotanque.Size = New System.Drawing.Size(66, 14)
        Me.lblAutotanque.TabIndex = 0
        Me.lblAutotanque.Text = "Au&totanque:"
        '
        'Figure1
        '
        Me.Figure1.BackColor = System.Drawing.Color.LightSteelBlue
        Me.Figure1.FillColor = System.Drawing.SystemColors.Control
        Me.Figure1.LineColor = System.Drawing.Color.RosyBrown
        Me.Figure1.LineWidth = 2.0!
        Me.Figure1.Location = New System.Drawing.Point(16, 116)
        Me.Figure1.Name = "Figure1"
        Me.Figure1.Size = New System.Drawing.Size(184, 8)
        Me.Figure1.Style = Logistica.Figure.FigureStyle.Line
        Me.Figure1.TabIndex = 8
        Me.Figure1.TabStop = False
        '
        'txtCelula
        '
        Me.txtCelula.BackColor = System.Drawing.Color.WhiteSmoke
        Me.txtCelula.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtCelula.Location = New System.Drawing.Point(87, 90)
        Me.txtCelula.Name = "txtCelula"
        Me.txtCelula.ReadOnly = True
        Me.txtCelula.Size = New System.Drawing.Size(105, 21)
        Me.txtCelula.TabIndex = 3
        Me.txtCelula.TabStop = False
        Me.txtCelula.Text = ""
        '
        'lblCelula
        '
        Me.lblCelula.AutoSize = True
        Me.lblCelula.Location = New System.Drawing.Point(16, 93)
        Me.lblCelula.Name = "lblCelula"
        Me.lblCelula.Size = New System.Drawing.Size(72, 14)
        Me.lblCelula.TabIndex = 2
        Me.lblCelula.Text = "Célula act&ual:"
        '
        'lblNuevaCelula
        '
        Me.lblNuevaCelula.AutoSize = True
        Me.lblNuevaCelula.Location = New System.Drawing.Point(16, 136)
        Me.lblNuevaCelula.Name = "lblNuevaCelula"
        Me.lblNuevaCelula.Size = New System.Drawing.Size(72, 14)
        Me.lblNuevaCelula.TabIndex = 3
        Me.lblNuevaCelula.Text = "Nueva cé&lula:"
        '
        'btnCancelar
        '
        Me.btnCancelar.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnCancelar.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnCancelar.Image = CType(resources.GetObject("btnCancelar.Image"), System.Drawing.Bitmap)
        Me.btnCancelar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnCancelar.Location = New System.Drawing.Point(229, 51)
        Me.btnCancelar.Name = "btnCancelar"
        Me.btnCancelar.Size = New System.Drawing.Size(80, 24)
        Me.btnCancelar.TabIndex = 2
        Me.btnCancelar.Text = "&Cancelar"
        Me.btnCancelar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'btnAceptar
        '
        Me.btnAceptar.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnAceptar.Image = CType(resources.GetObject("btnAceptar.Image"), System.Drawing.Bitmap)
        Me.btnAceptar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnAceptar.Location = New System.Drawing.Point(229, 19)
        Me.btnAceptar.Name = "btnAceptar"
        Me.btnAceptar.Size = New System.Drawing.Size(80, 24)
        Me.btnAceptar.TabIndex = 1
        Me.btnAceptar.Text = "&Aceptar"
        Me.btnAceptar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'frmAsignacionRutaGeneral
        '
        Me.AcceptButton = Me.btnAceptar
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 14)
        Me.BackColor = System.Drawing.Color.Gainsboro
        Me.CancelButton = Me.btnCancelar
        Me.ClientSize = New System.Drawing.Size(322, 207)
        Me.Controls.AddRange(New System.Windows.Forms.Control() {Me.btnCancelar, Me.btnAceptar, Me.rgrpDatos})
        Me.DockPadding.All = 5
        Me.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmAsignacionRutaGeneral"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Asignacion de ruta"
        Me.rgrpDatos.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

#End Region

    Dim Año As Integer
    Dim dtRuta As New DataTable()


    Private Function View2Table(ByVal view As DataView) As DataTable
        Dim dtResult As New DataTable()
        Dim RowIndex, ColumnIndex As Integer
        Dim IArray(view.Table.Columns.Count - 1) As Object
        dtResult = view.Table.Clone
        For RowIndex = 0 To view.Count - 1
            For ColumnIndex = 0 To view.Table.Columns.Count - 1
                IArray(ColumnIndex) = view.Item(RowIndex)(ColumnIndex)
            Next
            dtResult.Rows.Add(IArray)
        Next
        Return dtResult
    End Function

    Private Sub btnAceptar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAceptar.Click
        If Not CInt(scboRuta.SelectedValue) = 0 Then
            If MessageBox.Show("¿Desea cambiar la ruta del autotanque " & txtAutotanque.Text.Trim & " folio " & txtFolio.Text.Trim & Chr(13) & _
                "de la ruta " & txtRutaActual.Text.Trim & " a la ruta " & scboRuta.Text.Trim & "?", Application.ProductName & " v." & Application.ProductVersion, _
                 MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
                Dim cmdLogistica As New SqlCommand("Update AutotanqueTurno set Ruta = @Ruta where AñoAtt = @Año and Folio = @Folio", cnSigamet)
                cmdLogistica.Parameters.Add("@Año", SqlDbType.Int).Value = Año
                cmdLogistica.Parameters.Add("@Folio", SqlDbType.Int).Value = CInt(txtFolio.Text)
                cmdLogistica.Parameters.Add("@Ruta", SqlDbType.Int).Value = CInt(scboRuta.SelectedValue)
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

    
    Private Sub cboCelula_SelectedValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboCelula.SelectedValueChanged
        If Not cboCelula.SelectedItem Is Nothing Then
            Dim dtR As New DataTable()
            scboRuta.Text = ""
            dtRuta.DefaultView.RowFilter = "Celula = " & CStr(cboCelula.SelectedValue)
            dtR = View2Table(dtRuta.DefaultView)
            scboRuta.ValueMember = "Ruta"
            scboRuta.DisplayMember = "Ruta"
            scboRuta.DataSource = dtR
        End If
    End Sub
End Class
