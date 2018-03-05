Imports System
Imports System.Data
Imports System.Data.SqlClient


Public Class frmAsignacionOperadorPosturero
    Inherits System.Windows.Forms.Form

#Region " Windows Form Designer generated code "

    Public Sub New(ByVal Año As Integer, ByVal Folio As Integer, ByVal Fecha As Date)
        MyBase.New()
        'This call is required by the Windows Form Designer.
        InitializeComponent()

        'Add any initialization after the InitializeComponent() call
        Me.Text = "Asignación del folio: " & CStr(Folio) & " del " & Fecha.ToShortDateString
        Me.Año = Año
        Me.Folio = Folio
        Me.Celula = Celula
        Me.Fecha = Fecha

        If Not _MuestraAsistencia Then
            ReDim Preserve vgrdEmpleadosDisponibles.HidedColumnNames(vgrdEmpleadosDisponibles.HidedColumnNames.Length)
            ReDim Preserve vgrdEmpleadosAsignados.HidedColumnNames(vgrdEmpleadosAsignados.HidedColumnNames.Length)

            vgrdEmpleadosDisponibles.HidedColumnNames(vgrdEmpleadosDisponibles.HidedColumnNames.Length - 1) = "EnPlanta"
            vgrdEmpleadosAsignados.HidedColumnNames(vgrdEmpleadosAsignados.HidedColumnNames.Length - 1) = "EnPlanta"

        End If

        CargaInformacion()
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
    Friend WithEvents pnlBotones As System.Windows.Forms.Panel
    Friend WithEvents rgrpEmpleadosAsignados As Logistica.RoundedGroupBox
    Friend WithEvents rgrpEmpleadosDisponibles As Logistica.RoundedGroupBox
    Friend WithEvents pnlBotonesAsignacion As System.Windows.Forms.Panel
    Friend WithEvents btnDesasignar As System.Windows.Forms.Button
    Friend WithEvents btnAsignar As System.Windows.Forms.Button
    Friend WithEvents sptEmpleadosAsignados As System.Windows.Forms.Splitter
    Friend WithEvents sptEmpleadosDisponibles As System.Windows.Forms.Splitter
    Friend WithEvents btnAceptar As System.Windows.Forms.Button
    Friend WithEvents vgrdEmpleadosDisponibles As Logistica.ViewGrid
    Friend WithEvents vgrdEmpleadosAsignados As Logistica.ViewGrid
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(frmAsignacionOperadorPosturero))
        Me.pnlBotones = New System.Windows.Forms.Panel()
        Me.btnAceptar = New System.Windows.Forms.Button()
        Me.rgrpEmpleadosAsignados = New Logistica.RoundedGroupBox()
        Me.vgrdEmpleadosAsignados = New Logistica.ViewGrid()
        Me.rgrpEmpleadosDisponibles = New Logistica.RoundedGroupBox()
        Me.vgrdEmpleadosDisponibles = New Logistica.ViewGrid()
        Me.pnlBotonesAsignacion = New System.Windows.Forms.Panel()
        Me.btnDesasignar = New System.Windows.Forms.Button()
        Me.btnAsignar = New System.Windows.Forms.Button()
        Me.sptEmpleadosAsignados = New System.Windows.Forms.Splitter()
        Me.sptEmpleadosDisponibles = New System.Windows.Forms.Splitter()
        Me.pnlBotones.SuspendLayout()
        Me.rgrpEmpleadosAsignados.SuspendLayout()
        Me.rgrpEmpleadosDisponibles.SuspendLayout()
        Me.pnlBotonesAsignacion.SuspendLayout()
        Me.SuspendLayout()
        '
        'pnlBotones
        '
        Me.pnlBotones.Controls.AddRange(New System.Windows.Forms.Control() {Me.btnAceptar})
        Me.pnlBotones.Dock = System.Windows.Forms.DockStyle.Right
        Me.pnlBotones.DockPadding.All = 5
        Me.pnlBotones.Location = New System.Drawing.Point(805, 5)
        Me.pnlBotones.Name = "pnlBotones"
        Me.pnlBotones.Size = New System.Drawing.Size(96, 479)
        Me.pnlBotones.TabIndex = 0
        '
        'btnAceptar
        '
        Me.btnAceptar.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnAceptar.Image = CType(resources.GetObject("btnAceptar.Image"), System.Drawing.Bitmap)
        Me.btnAceptar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnAceptar.Location = New System.Drawing.Point(14, 9)
        Me.btnAceptar.Name = "btnAceptar"
        Me.btnAceptar.Size = New System.Drawing.Size(70, 24)
        Me.btnAceptar.TabIndex = 3
        Me.btnAceptar.Text = "&Aceptar"
        Me.btnAceptar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'rgrpEmpleadosAsignados
        '
        Me.rgrpEmpleadosAsignados.BorderColor = System.Drawing.Color.Gray
        Me.rgrpEmpleadosAsignados.Controls.AddRange(New System.Windows.Forms.Control() {Me.vgrdEmpleadosAsignados})
        Me.rgrpEmpleadosAsignados.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.rgrpEmpleadosAsignados.FlatStyle = Logistica.RoundedGroupBox.Style.Pipe
        Me.rgrpEmpleadosAsignados.Location = New System.Drawing.Point(5, 380)
        Me.rgrpEmpleadosAsignados.Name = "rgrpEmpleadosAsignados"
        Me.rgrpEmpleadosAsignados.Size = New System.Drawing.Size(800, 104)
        Me.rgrpEmpleadosAsignados.TabIndex = 2
        Me.rgrpEmpleadosAsignados.TabStop = False
        Me.rgrpEmpleadosAsignados.Text = "Empleados asignados"
        Me.rgrpEmpleadosAsignados.TextAlignment = System.Windows.Forms.HorizontalAlignment.Center
        '
        'vgrdEmpleadosAsignados
        '
        Me.vgrdEmpleadosAsignados.AlternativeBackColor = System.Drawing.Color.SeaShell
        Me.vgrdEmpleadosAsignados.BackColor = System.Drawing.Color.Snow
        Me.vgrdEmpleadosAsignados.CheckCondition = Nothing
        Me.vgrdEmpleadosAsignados.DataSource = Nothing
        Me.vgrdEmpleadosAsignados.Dock = System.Windows.Forms.DockStyle.Fill
        Me.vgrdEmpleadosAsignados.FullRowSelect = True
        Me.vgrdEmpleadosAsignados.GridLines = True
        Me.vgrdEmpleadosAsignados.HidedColumnNames = New String() {"IDCategoria", "IDTipo"}
        Me.vgrdEmpleadosAsignados.Location = New System.Drawing.Point(3, 17)
        Me.vgrdEmpleadosAsignados.MultiSelect = False
        Me.vgrdEmpleadosAsignados.Name = "vgrdEmpleadosAsignados"
        Me.vgrdEmpleadosAsignados.PKColumnNames = Nothing
        Me.vgrdEmpleadosAsignados.Size = New System.Drawing.Size(794, 84)
        Me.vgrdEmpleadosAsignados.TabIndex = 0
        Me.vgrdEmpleadosAsignados.View = System.Windows.Forms.View.Details
        '
        'rgrpEmpleadosDisponibles
        '
        Me.rgrpEmpleadosDisponibles.BackColor = System.Drawing.Color.Gainsboro
        Me.rgrpEmpleadosDisponibles.BorderColor = System.Drawing.Color.Gray
        Me.rgrpEmpleadosDisponibles.Controls.AddRange(New System.Windows.Forms.Control() {Me.vgrdEmpleadosDisponibles})
        Me.rgrpEmpleadosDisponibles.Dock = System.Windows.Forms.DockStyle.Fill
        Me.rgrpEmpleadosDisponibles.FlatStyle = Logistica.RoundedGroupBox.Style.Pipe
        Me.rgrpEmpleadosDisponibles.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rgrpEmpleadosDisponibles.Location = New System.Drawing.Point(5, 5)
        Me.rgrpEmpleadosDisponibles.Name = "rgrpEmpleadosDisponibles"
        Me.rgrpEmpleadosDisponibles.Size = New System.Drawing.Size(800, 332)
        Me.rgrpEmpleadosDisponibles.TabIndex = 1
        Me.rgrpEmpleadosDisponibles.TabStop = False
        Me.rgrpEmpleadosDisponibles.Text = "Empleados disponibles"
        Me.rgrpEmpleadosDisponibles.TextAlignment = System.Windows.Forms.HorizontalAlignment.Center
        '
        'vgrdEmpleadosDisponibles
        '
        Me.vgrdEmpleadosDisponibles.AlternativeBackColor = System.Drawing.Color.Gainsboro
        Me.vgrdEmpleadosDisponibles.BackColor = System.Drawing.Color.WhiteSmoke
        Me.vgrdEmpleadosDisponibles.CheckCondition = Nothing
        Me.vgrdEmpleadosDisponibles.DataSource = Nothing
        Me.vgrdEmpleadosDisponibles.Dock = System.Windows.Forms.DockStyle.Fill
        Me.vgrdEmpleadosDisponibles.FullRowSelect = True
        Me.vgrdEmpleadosDisponibles.GridLines = True
        Me.vgrdEmpleadosDisponibles.HidedColumnNames = New String() {"IDCategoria", "IDTipo"}
        Me.vgrdEmpleadosDisponibles.Location = New System.Drawing.Point(3, 17)
        Me.vgrdEmpleadosDisponibles.MultiSelect = False
        Me.vgrdEmpleadosDisponibles.Name = "vgrdEmpleadosDisponibles"
        Me.vgrdEmpleadosDisponibles.PKColumnNames = Nothing
        Me.vgrdEmpleadosDisponibles.Size = New System.Drawing.Size(794, 312)
        Me.vgrdEmpleadosDisponibles.TabIndex = 0
        Me.vgrdEmpleadosDisponibles.View = System.Windows.Forms.View.Details
        '
        'pnlBotonesAsignacion
        '
        Me.pnlBotonesAsignacion.BackColor = System.Drawing.Color.Gainsboro
        Me.pnlBotonesAsignacion.Controls.AddRange(New System.Windows.Forms.Control() {Me.btnDesasignar, Me.btnAsignar})
        Me.pnlBotonesAsignacion.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.pnlBotonesAsignacion.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.pnlBotonesAsignacion.Location = New System.Drawing.Point(5, 337)
        Me.pnlBotonesAsignacion.Name = "pnlBotonesAsignacion"
        Me.pnlBotonesAsignacion.Size = New System.Drawing.Size(800, 40)
        Me.pnlBotonesAsignacion.TabIndex = 3
        '
        'btnDesasignar
        '
        Me.btnDesasignar.BackColor = System.Drawing.SystemColors.Control
        Me.btnDesasignar.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnDesasignar.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnDesasignar.Image = CType(resources.GetObject("btnDesasignar.Image"), System.Drawing.Bitmap)
        Me.btnDesasignar.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btnDesasignar.Location = New System.Drawing.Point(392, 6)
        Me.btnDesasignar.Name = "btnDesasignar"
        Me.btnDesasignar.Size = New System.Drawing.Size(73, 29)
        Me.btnDesasignar.TabIndex = 0
        '
        'btnAsignar
        '
        Me.btnAsignar.BackColor = System.Drawing.SystemColors.Control
        Me.btnAsignar.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnAsignar.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnAsignar.Image = CType(resources.GetObject("btnAsignar.Image"), System.Drawing.Bitmap)
        Me.btnAsignar.ImageAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnAsignar.Location = New System.Drawing.Point(191, 6)
        Me.btnAsignar.Name = "btnAsignar"
        Me.btnAsignar.Size = New System.Drawing.Size(74, 29)
        Me.btnAsignar.TabIndex = 0
        '
        'sptEmpleadosAsignados
        '
        Me.sptEmpleadosAsignados.BackColor = System.Drawing.Color.Gainsboro
        Me.sptEmpleadosAsignados.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.sptEmpleadosAsignados.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.sptEmpleadosAsignados.Location = New System.Drawing.Point(5, 377)
        Me.sptEmpleadosAsignados.Name = "sptEmpleadosAsignados"
        Me.sptEmpleadosAsignados.Size = New System.Drawing.Size(800, 3)
        Me.sptEmpleadosAsignados.TabIndex = 4
        Me.sptEmpleadosAsignados.TabStop = False
        '
        'sptEmpleadosDisponibles
        '
        Me.sptEmpleadosDisponibles.BackColor = System.Drawing.Color.Gainsboro
        Me.sptEmpleadosDisponibles.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.sptEmpleadosDisponibles.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.sptEmpleadosDisponibles.Location = New System.Drawing.Point(5, 334)
        Me.sptEmpleadosDisponibles.Name = "sptEmpleadosDisponibles"
        Me.sptEmpleadosDisponibles.Size = New System.Drawing.Size(800, 3)
        Me.sptEmpleadosDisponibles.TabIndex = 5
        Me.sptEmpleadosDisponibles.TabStop = False
        '
        'frmAsignacionOperadorPosturero
        '
        Me.AcceptButton = Me.btnAceptar
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 14)
        Me.BackColor = System.Drawing.Color.Gainsboro
        Me.ClientSize = New System.Drawing.Size(906, 489)
        Me.Controls.AddRange(New System.Windows.Forms.Control() {Me.sptEmpleadosDisponibles, Me.rgrpEmpleadosDisponibles, Me.pnlBotonesAsignacion, Me.sptEmpleadosAsignados, Me.rgrpEmpleadosAsignados, Me.pnlBotones})
        Me.DockPadding.All = 5
        Me.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmAsignacionOperadorPosturero"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.pnlBotones.ResumeLayout(False)
        Me.rgrpEmpleadosAsignados.ResumeLayout(False)
        Me.rgrpEmpleadosDisponibles.ResumeLayout(False)
        Me.pnlBotonesAsignacion.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

#End Region

    Dim dtEmpleadosDisponibles, dtEmpleadosAsignados As New DataTable()
    Dim Año, Folio, Celula As Integer
    Dim Fecha As Date

    Private Sub CargaInformacion()
        Dim cmdLogistica As New SqlCommand("exec spLogOperadoresPosturerosAsignables @Fecha, @Año, @Folio", cnSigamet)
        Dim daLogistica As New SqlDataAdapter(cmdLogistica)
        cmdLogistica.Parameters.Add("@Celula", SqlDbType.TinyInt).Value = Celula
        cmdLogistica.Parameters.Add("@Fecha", SqlDbType.DateTime).Value = Fecha
        cmdLogistica.Parameters.Add("@Año", SqlDbType.Int).Value = Año
        cmdLogistica.Parameters.Add("@Folio", SqlDbType.Int).Value = Folio
        Try
            dtEmpleadosDisponibles.Clear()
            daLogistica.Fill(dtEmpleadosDisponibles)
            cmdLogistica.CommandText = "exec spLogTripulacion @Año, @Folio"
            dtEmpleadosAsignados.Clear()
            daLogistica.Fill(dtEmpleadosAsignados)
            vgrdEmpleadosDisponibles.DataSource = dtEmpleadosDisponibles
            vgrdEmpleadosAsignados.DataSource = dtEmpleadosAsignados
            vgrdEmpleadosDisponibles.Columns(1).Width = 220
            vgrdEmpleadosDisponibles.Columns(4).Width = 50
            vgrdEmpleadosAsignados.Columns(0).Width = 50
            vgrdEmpleadosAsignados.Columns(1).Width = 220
            vgrdEmpleadosAsignados.Columns(5).Width = 50
            vgrdEmpleadosAsignados.Columns(6).Width = 50
        Catch ex As Exception
            ExMessage(ex)
        Finally
            cmdLogistica.Dispose()
        End Try

    End Sub
    Private Sub Asignar()
        If Not vgrdEmpleadosDisponibles.CurrentRow Is Nothing Then
            Dim cmdLogistica As New SqlCommand("Select count(*) from TripulacionTurno TT inner join TipoAsignacionoperador TAO " & _
                                    " on TT.TipoAsignacionOperador = TAO.TipoAsignacionOperador where TT.AñoATT = @AñoAtt and " & _
                                    " TT.Folio = @Folio and TAO.Abordo = 1", cnSigamet)

            cmdLogistica.Parameters.Add("@Operador", SqlDbType.Int).Value = CInt(vgrdEmpleadosDisponibles.CurrentRow("Operador"))
            cmdLogistica.Parameters.Add("@CategoriaOperador", SqlDbType.Int).Value = CInt(vgrdEmpleadosDisponibles.CurrentRow("IDCategoria"))
            cmdLogistica.Parameters.Add("@TipoOperador", SqlDbType.Int).Value = CInt(vgrdEmpleadosDisponibles.CurrentRow("IDTipo"))
            cmdLogistica.Parameters.Add("@Folio", SqlDbType.Int).Value = Folio
            cmdLogistica.Parameters.Add("@AñoAtt", SqlDbType.Int).Value = Año
            cmdLogistica.Parameters.Add("@TipoAsignacionOperador", SqlDbType.Int).Value = 1

            Try
                cnSigamet.Open()
                If CInt(cmdLogistica.ExecuteScalar) >= 2 Then
                    Dim frmSeleccionTipoAsignacion As New frmSeleccionTipoAsignacion(CInt(vgrdEmpleadosDisponibles.CurrentRow("Operador")), CInt(vgrdEmpleadosDisponibles.CurrentRow("IDCategoria")))
                    If frmSeleccionTipoAsignacion.ShowDialog() = DialogResult.OK Then
                        cmdLogistica.Parameters("@CategoriaOperador").Value = CInt(frmSeleccionTipoAsignacion.cboCategoria.SelectedValue)
                        cmdLogistica.Parameters("@TipoAsignacionOperador").Value = CInt(frmSeleccionTipoAsignacion.cboAsignacion.SelectedValue)
                    Else
                        cmdLogistica.Dispose()
                        cnSigamet.Close()
                        Exit Sub
                    End If
                Else
                    cmdLogistica.CommandText = "Select count(*) from TripulacionTurno TT inner join TipoAsignacionoperador TAO " & _
                                    " on TT.TipoAsignacionOperador = TAO.TipoAsignacionOperador where TT.AñoATT = @AñoAtt and " & _
                                    " TT.Folio = @Folio and TAO.Abordo = 1 and TT.CategoriaOperador = @CategoriaOperador"
                    If CInt(cmdLogistica.ExecuteScalar) >= 1 Then
                        Dim frmSeleccionTipoAsignacion As New frmSeleccionTipoAsignacion(CInt(vgrdEmpleadosDisponibles.CurrentRow("Operador")), CInt(vgrdEmpleadosDisponibles.CurrentRow("IDCategoria")))
                        If frmSeleccionTipoAsignacion.ShowDialog() = DialogResult.OK Then
                            cmdLogistica.Parameters("@CategoriaOperador").Value = CInt(frmSeleccionTipoAsignacion.cboCategoria.SelectedValue)
                            cmdLogistica.Parameters("@TipoAsignacionOperador").Value = CInt(frmSeleccionTipoAsignacion.cboAsignacion.SelectedValue)
                        Else
                            cmdLogistica.Dispose()
                            cnSigamet.Close()
                            Exit Sub
                        End If
                    End If
                End If
                cmdLogistica.CommandText = "exec spLOGInsertaTripulacion @Operador,@CategoriaOperador,@TipoOperador,@Folio,@AñoAtt,@TipoAsignacionOperador"
                cmdLogistica.ExecuteNonQuery()
                CargaInformacion()
            Catch ex As Exception
                ExMessage(ex)
            Finally
                cnSigamet.Close()
                cmdLogistica.Dispose()
            End Try
        End If
    End Sub
    Private Sub Desasignar()
        If Not vgrdEmpleadosAsignados.CurrentRow Is Nothing Then
            If CInt(vgrdEmpleadosAsignados.CurrentRow("IDTipo")) = 2 Then
                Dim cmdLogistica As New SqlCommand("exec spLogDesasignaOperador @Año, @Folio, @Operador", cnSigamet)
                Dim Operadores As Integer = CInt(dtEmpleadosAsignados.Compute("Count(Operador)", "IDCategoria = 1 AND Abordo = True"))
                cmdLogistica.Parameters.Add("@Año", SqlDbType.Int).Value = Año
                cmdLogistica.Parameters.Add("@Folio", SqlDbType.Int).Value = Folio
                cmdLogistica.Parameters.Add("@Operador", SqlDbType.Int).Value = CInt(vgrdEmpleadosAsignados.CurrentRow("Operador"))
                Try
                    cnSigamet.Open()
                    cmdLogistica.ExecuteNonQuery()
                    CargaInformacion()
                    If Operadores = 1 AndAlso CInt(dtEmpleadosAsignados.Compute("Count(Operador)", "IDCategoria = 1 AND Abordo = True")) = 0 Then
                        MessageBox.Show("Ha dejado al autotanque sin operador abordo.", Application.ProductName & " v." & Application.ProductVersion, MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    End If
                Catch ex As Exception
                    ExMessage(ex)
                Finally
                    cnSigamet.Close()
                    cmdLogistica.Dispose()
                End Try
            Else
                ErrMessage("Sólo puede desasignar operadores postureros")
            End If

        End If
    End Sub
    Private Sub btnAsignar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAsignar.Click
        Asignar()
    End Sub
    Private Sub btnAceptar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAceptar.Click
        Me.Close()
        Me.Dispose()
    End Sub

    Private Sub btnDesasignar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDesasignar.Click
        Desasignar()
    End Sub
End Class


