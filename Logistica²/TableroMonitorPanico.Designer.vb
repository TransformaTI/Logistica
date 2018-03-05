<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class TableroMonitorPanico
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
        Me.components = New System.ComponentModel.Container()
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(TableroMonitorPanico))
        Me.timerControl = New System.Windows.Forms.Timer(Me.components)
        Me.dgvInformacion = New System.Windows.Forms.DataGridView()
        Me.Grupo = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Ruta = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Vehiculo = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.NumeroEconomico = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Fecha = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.HoraSalidaPlanta = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.HoraIngresoRuta = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.HoraPrimerSuministro = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.HoraUltimoSuministro = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.HoraUltimoPanico = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.HoraUltimaPosicion = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.gbxFiltros = New System.Windows.Forms.GroupBox()
        Me.btnBuscar = New System.Windows.Forms.Button()
        Me.lblTotalRegistros = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.dtpFecha = New System.Windows.Forms.DateTimePicker()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.btnRunTimer = New System.Windows.Forms.Button()
        Me.cmbNumeroEconomico = New System.Windows.Forms.ComboBox()
        Me.cmbRuta = New System.Windows.Forms.ComboBox()
        Me.cmbGrupo = New System.Windows.Forms.ComboBox()
        Me.btnStopTimer = New System.Windows.Forms.Button()
        Me.btnRefrescar = New System.Windows.Forms.Button()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.gbxDatos = New System.Windows.Forms.GroupBox()
        Me.pnlFiltros = New System.Windows.Forms.Panel()
        Me.pnlAlertas = New System.Windows.Forms.Panel()
        Me.gbxAlertas = New System.Windows.Forms.GroupBox()
        Me.pnlInformativoAtrasado = New System.Windows.Forms.Panel()
        Me.lblHistorialDePanicos = New System.Windows.Forms.Label()
        Me.pnlInformativoReciente = New System.Windows.Forms.Panel()
        Me.BlinkingClickLabel1 = New SVCC.BlinkingClickLabel()
        Me.pnlDatos = New System.Windows.Forms.Panel()
        Me.lblPlanta = New System.Windows.Forms.Label()
        CType(Me.dgvInformacion, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.gbxFiltros.SuspendLayout()
        Me.gbxDatos.SuspendLayout()
        Me.pnlFiltros.SuspendLayout()
        Me.pnlAlertas.SuspendLayout()
        Me.gbxAlertas.SuspendLayout()
        Me.pnlInformativoAtrasado.SuspendLayout()
        Me.pnlInformativoReciente.SuspendLayout()
        Me.pnlDatos.SuspendLayout()
        Me.SuspendLayout()
        '
        'timerControl
        '
        '
        'dgvInformacion
        '
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.MenuHighlight
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.OrangeRed
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvInformacion.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.dgvInformacion.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing
        Me.dgvInformacion.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Grupo, Me.Ruta, Me.Vehiculo, Me.NumeroEconomico, Me.Fecha, Me.HoraSalidaPlanta, Me.HoraIngresoRuta, Me.HoraPrimerSuministro, Me.HoraUltimoSuministro, Me.HoraUltimoPanico, Me.HoraUltimaPosicion})
        Me.dgvInformacion.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgvInformacion.Location = New System.Drawing.Point(3, 16)
        Me.dgvInformacion.Name = "dgvInformacion"
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.OrangeRed
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvInformacion.RowHeadersDefaultCellStyle = DataGridViewCellStyle2
        Me.dgvInformacion.RowTemplate.DefaultCellStyle.NullValue = "No existen informcación que mostrar."
        Me.dgvInformacion.RowTemplate.DefaultCellStyle.SelectionBackColor = System.Drawing.Color.OrangeRed
        Me.dgvInformacion.Size = New System.Drawing.Size(891, 437)
        Me.dgvInformacion.TabIndex = 3
        '
        'Grupo
        '
        Me.Grupo.DataPropertyName = "Grupo"
        Me.Grupo.HeaderText = "Grupo"
        Me.Grupo.Name = "Grupo"
        Me.Grupo.ReadOnly = True
        Me.Grupo.Width = 95
        '
        'Ruta
        '
        Me.Ruta.DataPropertyName = "Ruta"
        Me.Ruta.HeaderText = "Ruta"
        Me.Ruta.Name = "Ruta"
        Me.Ruta.ReadOnly = True
        Me.Ruta.Width = 94
        '
        'Vehiculo
        '
        Me.Vehiculo.DataPropertyName = "Vehiculo"
        Me.Vehiculo.HeaderText = "Vehiculo"
        Me.Vehiculo.Name = "Vehiculo"
        Me.Vehiculo.ReadOnly = True
        Me.Vehiculo.Width = 95
        '
        'NumeroEconomico
        '
        Me.NumeroEconomico.DataPropertyName = "NumeroEconomico"
        Me.NumeroEconomico.HeaderText = "No.Eco."
        Me.NumeroEconomico.Name = "NumeroEconomico"
        Me.NumeroEconomico.ReadOnly = True
        Me.NumeroEconomico.Width = 95
        '
        'Fecha
        '
        Me.Fecha.DataPropertyName = "Fecha"
        Me.Fecha.HeaderText = "Fecha"
        Me.Fecha.Name = "Fecha"
        Me.Fecha.ReadOnly = True
        Me.Fecha.Width = 94
        '
        'HoraSalidaPlanta
        '
        Me.HoraSalidaPlanta.DataPropertyName = "HoraSalidaPlanta"
        Me.HoraSalidaPlanta.HeaderText = "HoraSalidaPlanta"
        Me.HoraSalidaPlanta.Name = "HoraSalidaPlanta"
        Me.HoraSalidaPlanta.ReadOnly = True
        Me.HoraSalidaPlanta.Width = 95
        '
        'HoraIngresoRuta
        '
        Me.HoraIngresoRuta.DataPropertyName = "HoraIngresoRuta"
        Me.HoraIngresoRuta.HeaderText = "HoraIngresoRuta"
        Me.HoraIngresoRuta.Name = "HoraIngresoRuta"
        Me.HoraIngresoRuta.ReadOnly = True
        Me.HoraIngresoRuta.Width = 95
        '
        'HoraPrimerSuministro
        '
        Me.HoraPrimerSuministro.DataPropertyName = "HoraPrimerSuministro"
        Me.HoraPrimerSuministro.HeaderText = "HoraPrimerSuministro"
        Me.HoraPrimerSuministro.Name = "HoraPrimerSuministro"
        Me.HoraPrimerSuministro.ReadOnly = True
        Me.HoraPrimerSuministro.Width = 94
        '
        'HoraUltimoSuministro
        '
        Me.HoraUltimoSuministro.DataPropertyName = "HoraUltimoSuministro"
        Me.HoraUltimoSuministro.HeaderText = "HoraUltimoSuministro"
        Me.HoraUltimoSuministro.Name = "HoraUltimoSuministro"
        Me.HoraUltimoSuministro.ReadOnly = True
        Me.HoraUltimoSuministro.Width = 95
        '
        'HoraUltimoPanico
        '
        Me.HoraUltimoPanico.DataPropertyName = "HoraUltimoPanico"
        Me.HoraUltimoPanico.HeaderText = "HoraUltimoPanico"
        Me.HoraUltimoPanico.Name = "HoraUltimoPanico"
        Me.HoraUltimoPanico.ReadOnly = True
        Me.HoraUltimoPanico.Width = 95
        '
        'HoraUltimaPosicion
        '
        Me.HoraUltimaPosicion.DataPropertyName = "HoraUltimaPosicion"
        Me.HoraUltimaPosicion.HeaderText = "HoraUltimaPosicion"
        Me.HoraUltimaPosicion.Name = "HoraUltimaPosicion"
        Me.HoraUltimaPosicion.ReadOnly = True
        Me.HoraUltimaPosicion.Width = 94
        '
        'gbxFiltros
        '
        Me.gbxFiltros.Controls.Add(Me.lblPlanta)
        Me.gbxFiltros.Controls.Add(Me.btnBuscar)
        Me.gbxFiltros.Controls.Add(Me.lblTotalRegistros)
        Me.gbxFiltros.Controls.Add(Me.Label6)
        Me.gbxFiltros.Controls.Add(Me.Label5)
        Me.gbxFiltros.Controls.Add(Me.dtpFecha)
        Me.gbxFiltros.Controls.Add(Me.Label4)
        Me.gbxFiltros.Controls.Add(Me.btnRunTimer)
        Me.gbxFiltros.Controls.Add(Me.cmbNumeroEconomico)
        Me.gbxFiltros.Controls.Add(Me.cmbRuta)
        Me.gbxFiltros.Controls.Add(Me.cmbGrupo)
        Me.gbxFiltros.Controls.Add(Me.btnStopTimer)
        Me.gbxFiltros.Controls.Add(Me.btnRefrescar)
        Me.gbxFiltros.Controls.Add(Me.Label3)
        Me.gbxFiltros.Controls.Add(Me.Label2)
        Me.gbxFiltros.Controls.Add(Me.Label1)
        Me.gbxFiltros.Dock = System.Windows.Forms.DockStyle.Top
        Me.gbxFiltros.Location = New System.Drawing.Point(0, 0)
        Me.gbxFiltros.Name = "gbxFiltros"
        Me.gbxFiltros.Size = New System.Drawing.Size(1237, 95)
        Me.gbxFiltros.TabIndex = 4
        Me.gbxFiltros.TabStop = False
        Me.gbxFiltros.Text = "Filtrar"
        '
        'btnBuscar
        '
        Me.btnBuscar.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.btnBuscar.Image = CType(resources.GetObject("btnBuscar.Image"), System.Drawing.Image)
        Me.btnBuscar.Location = New System.Drawing.Point(479, 17)
        Me.btnBuscar.Name = "btnBuscar"
        Me.btnBuscar.Size = New System.Drawing.Size(62, 49)
        Me.btnBuscar.TabIndex = 14
        Me.btnBuscar.Text = "Buscar"
        Me.btnBuscar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        Me.btnBuscar.UseVisualStyleBackColor = True
        '
        'lblTotalRegistros
        '
        Me.lblTotalRegistros.AutoSize = True
        Me.lblTotalRegistros.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTotalRegistros.Location = New System.Drawing.Point(572, 74)
        Me.lblTotalRegistros.Name = "lblTotalRegistros"
        Me.lblTotalRegistros.Size = New System.Drawing.Size(0, 13)
        Me.lblTotalRegistros.TabIndex = 13
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(475, 74)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(91, 13)
        Me.Label6.TabIndex = 12
        Me.Label6.Text = "Total de registros:"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(261, 23)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(39, 13)
        Me.Label5.TabIndex = 11
        Me.Label5.Text = "Célula:"
        '
        'dtpFecha
        '
        Me.dtpFecha.Enabled = False
        Me.dtpFecha.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpFecha.Location = New System.Drawing.Point(90, 28)
        Me.dtpFecha.Name = "dtpFecha"
        Me.dtpFecha.Size = New System.Drawing.Size(158, 20)
        Me.dtpFecha.TabIndex = 1
        Me.dtpFecha.Value = New Date(2016, 3, 31, 0, 0, 0, 0)
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(6, 31)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(40, 13)
        Me.Label4.TabIndex = 9
        Me.Label4.Text = "Fecha:"
        '
        'btnRunTimer
        '
        Me.btnRunTimer.Image = CType(resources.GetObject("btnRunTimer.Image"), System.Drawing.Image)
        Me.btnRunTimer.Location = New System.Drawing.Point(1163, 18)
        Me.btnRunTimer.Name = "btnRunTimer"
        Me.btnRunTimer.Size = New System.Drawing.Size(62, 49)
        Me.btnRunTimer.TabIndex = 7
        Me.btnRunTimer.Text = "Iniciar"
        Me.btnRunTimer.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        Me.btnRunTimer.UseVisualStyleBackColor = True
        Me.btnRunTimer.Visible = False
        '
        'cmbNumeroEconomico
        '
        Me.cmbNumeroEconomico.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbNumeroEconomico.FormattingEnabled = True
        Me.cmbNumeroEconomico.Location = New System.Drawing.Point(90, 66)
        Me.cmbNumeroEconomico.Name = "cmbNumeroEconomico"
        Me.cmbNumeroEconomico.Size = New System.Drawing.Size(158, 21)
        Me.cmbNumeroEconomico.TabIndex = 2
        '
        'cmbRuta
        '
        Me.cmbRuta.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbRuta.FormattingEnabled = True
        Me.cmbRuta.Location = New System.Drawing.Point(306, 66)
        Me.cmbRuta.Name = "cmbRuta"
        Me.cmbRuta.Size = New System.Drawing.Size(158, 21)
        Me.cmbRuta.TabIndex = 4
        '
        'cmbGrupo
        '
        Me.cmbGrupo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbGrupo.FormattingEnabled = True
        Me.cmbGrupo.Location = New System.Drawing.Point(306, 20)
        Me.cmbGrupo.Name = "cmbGrupo"
        Me.cmbGrupo.Size = New System.Drawing.Size(158, 21)
        Me.cmbGrupo.TabIndex = 3
        '
        'btnStopTimer
        '
        Me.btnStopTimer.Image = CType(resources.GetObject("btnStopTimer.Image"), System.Drawing.Image)
        Me.btnStopTimer.Location = New System.Drawing.Point(1163, 17)
        Me.btnStopTimer.Name = "btnStopTimer"
        Me.btnStopTimer.Size = New System.Drawing.Size(62, 49)
        Me.btnStopTimer.TabIndex = 6
        Me.btnStopTimer.Text = "Detener"
        Me.btnStopTimer.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        Me.btnStopTimer.UseVisualStyleBackColor = True
        '
        'btnRefrescar
        '
        Me.btnRefrescar.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.btnRefrescar.Image = CType(resources.GetObject("btnRefrescar.Image"), System.Drawing.Image)
        Me.btnRefrescar.Location = New System.Drawing.Point(1095, 17)
        Me.btnRefrescar.Name = "btnRefrescar"
        Me.btnRefrescar.Size = New System.Drawing.Size(62, 49)
        Me.btnRefrescar.TabIndex = 5
        Me.btnRefrescar.Text = "Refrescar"
        Me.btnRefrescar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        Me.btnRefrescar.UseVisualStyleBackColor = True
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(6, 70)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(80, 13)
        Me.Label3.TabIndex = 2
        Me.Label3.Text = "No.Economico:"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(261, 70)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(33, 13)
        Me.Label2.TabIndex = 1
        Me.Label2.Text = "Ruta:"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(155, 31)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(39, 13)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Célula:"
        '
        'gbxDatos
        '
        Me.gbxDatos.Controls.Add(Me.dgvInformacion)
        Me.gbxDatos.Dock = System.Windows.Forms.DockStyle.Fill
        Me.gbxDatos.Location = New System.Drawing.Point(0, 0)
        Me.gbxDatos.Name = "gbxDatos"
        Me.gbxDatos.Size = New System.Drawing.Size(897, 456)
        Me.gbxDatos.TabIndex = 5
        Me.gbxDatos.TabStop = False
        Me.gbxDatos.Text = "Datos"
        '
        'pnlFiltros
        '
        Me.pnlFiltros.Controls.Add(Me.gbxFiltros)
        Me.pnlFiltros.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnlFiltros.Location = New System.Drawing.Point(0, 0)
        Me.pnlFiltros.Name = "pnlFiltros"
        Me.pnlFiltros.Size = New System.Drawing.Size(1237, 106)
        Me.pnlFiltros.TabIndex = 7
        '
        'pnlAlertas
        '
        Me.pnlAlertas.AutoScroll = True
        Me.pnlAlertas.Controls.Add(Me.gbxAlertas)
        Me.pnlAlertas.Dock = System.Windows.Forms.DockStyle.Right
        Me.pnlAlertas.Location = New System.Drawing.Point(897, 106)
        Me.pnlAlertas.Name = "pnlAlertas"
        Me.pnlAlertas.Size = New System.Drawing.Size(340, 456)
        Me.pnlAlertas.TabIndex = 8
        '
        'gbxAlertas
        '
        Me.gbxAlertas.Controls.Add(Me.pnlInformativoAtrasado)
        Me.gbxAlertas.Controls.Add(Me.pnlInformativoReciente)
        Me.gbxAlertas.Dock = System.Windows.Forms.DockStyle.Right
        Me.gbxAlertas.Location = New System.Drawing.Point(7, 0)
        Me.gbxAlertas.Name = "gbxAlertas"
        Me.gbxAlertas.Size = New System.Drawing.Size(333, 456)
        Me.gbxAlertas.TabIndex = 6
        Me.gbxAlertas.TabStop = False
        Me.gbxAlertas.Text = "Alertas"
        '
        'pnlInformativoAtrasado
        '
        Me.pnlInformativoAtrasado.AutoScroll = True
        Me.pnlInformativoAtrasado.Controls.Add(Me.lblHistorialDePanicos)
        Me.pnlInformativoAtrasado.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pnlInformativoAtrasado.Location = New System.Drawing.Point(3, 344)
        Me.pnlInformativoAtrasado.Name = "pnlInformativoAtrasado"
        Me.pnlInformativoAtrasado.Size = New System.Drawing.Size(327, 109)
        Me.pnlInformativoAtrasado.TabIndex = 2
        '
        'lblHistorialDePanicos
        '
        Me.lblHistorialDePanicos.AutoSize = True
        Me.lblHistorialDePanicos.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblHistorialDePanicos.ForeColor = System.Drawing.Color.Blue
        Me.lblHistorialDePanicos.Location = New System.Drawing.Point(5, 5)
        Me.lblHistorialDePanicos.Name = "lblHistorialDePanicos"
        Me.lblHistorialDePanicos.Size = New System.Drawing.Size(90, 25)
        Me.lblHistorialDePanicos.TabIndex = 2
        Me.lblHistorialDePanicos.Text = "Historial"
        '
        'pnlInformativoReciente
        '
        Me.pnlInformativoReciente.AutoScroll = True
        Me.pnlInformativoReciente.Controls.Add(Me.BlinkingClickLabel1)
        Me.pnlInformativoReciente.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnlInformativoReciente.Location = New System.Drawing.Point(3, 16)
        Me.pnlInformativoReciente.Name = "pnlInformativoReciente"
        Me.pnlInformativoReciente.Size = New System.Drawing.Size(327, 328)
        Me.pnlInformativoReciente.TabIndex = 1
        '
        'BlinkingClickLabel1
        '
        Me.BlinkingClickLabel1.AlternatingColor2 = System.Drawing.Color.Red
        Me.BlinkingClickLabel1.AutoSize = True
        Me.BlinkingClickLabel1.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BlinkingClickLabel1.LinkColor = System.Drawing.Color.Red
        Me.BlinkingClickLabel1.Location = New System.Drawing.Point(3, 9)
        Me.BlinkingClickLabel1.Name = "BlinkingClickLabel1"
        Me.BlinkingClickLabel1.Size = New System.Drawing.Size(244, 29)
        Me.BlinkingClickLabel1.TabIndex = 1
        Me.BlinkingClickLabel1.TabStop = True
        Me.BlinkingClickLabel1.Text = "BlinkingClickLabel1"
        Me.BlinkingClickLabel1.TimerInterval = 500
        '
        'pnlDatos
        '
        Me.pnlDatos.Controls.Add(Me.gbxDatos)
        Me.pnlDatos.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pnlDatos.Location = New System.Drawing.Point(0, 106)
        Me.pnlDatos.Name = "pnlDatos"
        Me.pnlDatos.Size = New System.Drawing.Size(897, 456)
        Me.pnlDatos.TabIndex = 9
        '
        'lblPlanta
        '
        Me.lblPlanta.AutoSize = True
        Me.lblPlanta.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblPlanta.Location = New System.Drawing.Point(625, 37)
        Me.lblPlanta.Name = "lblPlanta"
        Me.lblPlanta.Size = New System.Drawing.Size(222, 29)
        Me.lblPlanta.TabIndex = 15
        Me.lblPlanta.Text = "Nombre de planta"
        '
        'TableroMonitorPanico
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1237, 562)
        Me.Controls.Add(Me.pnlDatos)
        Me.Controls.Add(Me.pnlAlertas)
        Me.Controls.Add(Me.pnlFiltros)
        Me.IsMdiContainer = True
        Me.Name = "TableroMonitorPanico"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Tablero Monitor Panico"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        CType(Me.dgvInformacion, System.ComponentModel.ISupportInitialize).EndInit()
        Me.gbxFiltros.ResumeLayout(False)
        Me.gbxFiltros.PerformLayout()
        Me.gbxDatos.ResumeLayout(False)
        Me.pnlFiltros.ResumeLayout(False)
        Me.pnlAlertas.ResumeLayout(False)
        Me.gbxAlertas.ResumeLayout(False)
        Me.pnlInformativoAtrasado.ResumeLayout(False)
        Me.pnlInformativoAtrasado.PerformLayout()
        Me.pnlInformativoReciente.ResumeLayout(False)
        Me.pnlInformativoReciente.PerformLayout()
        Me.pnlDatos.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents timerControl As System.Windows.Forms.Timer
    Friend WithEvents dgvInformacion As System.Windows.Forms.DataGridView
    Friend WithEvents gbxFiltros As System.Windows.Forms.GroupBox
    Friend WithEvents gbxDatos As System.Windows.Forms.GroupBox
    Friend WithEvents pnlFiltros As System.Windows.Forms.Panel
    Friend WithEvents pnlAlertas As System.Windows.Forms.Panel
    Friend WithEvents pnlDatos As System.Windows.Forms.Panel
    Friend WithEvents cmbNumeroEconomico As System.Windows.Forms.ComboBox
    Friend WithEvents cmbRuta As System.Windows.Forms.ComboBox
    Friend WithEvents cmbGrupo As System.Windows.Forms.ComboBox
    Friend WithEvents btnStopTimer As System.Windows.Forms.Button
    Friend WithEvents btnRefrescar As System.Windows.Forms.Button
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents btnRunTimer As System.Windows.Forms.Button
    Friend WithEvents dtpFecha As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents lblTotalRegistros As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Grupo As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Ruta As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Vehiculo As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents NumeroEconomico As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Fecha As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents HoraSalidaPlanta As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents HoraIngresoRuta As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents HoraPrimerSuministro As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents HoraUltimoSuministro As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents HoraUltimoPanico As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents HoraUltimaPosicion As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents gbxAlertas As System.Windows.Forms.GroupBox
    Friend WithEvents pnlInformativoAtrasado As System.Windows.Forms.Panel
    Friend WithEvents pnlInformativoReciente As System.Windows.Forms.Panel
    Friend WithEvents BlinkingClickLabel1 As SVCC.BlinkingClickLabel
    Friend WithEvents btnBuscar As System.Windows.Forms.Button
    Friend WithEvents lblHistorialDePanicos As System.Windows.Forms.Label
    Friend WithEvents lblPlanta As System.Windows.Forms.Label


  
End Class
