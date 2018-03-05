<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmVentasPortatil
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmVentasPortatil))
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.dgvPedidos = New System.Windows.Forms.DataGridView()
        Me.tlsPedidos = New System.Windows.Forms.ToolStrip()
        Me.tlsModificar = New System.Windows.Forms.ToolStripButton()
        Me.tlsActualizar = New System.Windows.Forms.ToolStripButton()
        Me.tlsVentas = New System.Windows.Forms.ToolStripButton()
        Me.dtpFechaVenta = New System.Windows.Forms.DateTimePicker()
        Me.lblFVenta = New System.Windows.Forms.Label()
        Me.tlsInsertarRemision = New System.Windows.Forms.ToolStripButton()
        CType(Me.dgvPedidos, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tlsPedidos.SuspendLayout()
        Me.SuspendLayout()
        '
        'dgvPedidos
        '
        resources.ApplyResources(Me.dgvPedidos, "dgvPedidos")
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvPedidos.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.dgvPedidos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgvPedidos.DefaultCellStyle = DataGridViewCellStyle2
        Me.dgvPedidos.MultiSelect = False
        Me.dgvPedidos.Name = "dgvPedidos"
        Me.dgvPedidos.ReadOnly = True
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle3.Font = New System.Drawing.Font("Tahoma", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvPedidos.RowHeadersDefaultCellStyle = DataGridViewCellStyle3
        Me.dgvPedidos.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        '
        'tlsPedidos
        '
        Me.tlsPedidos.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tlsModificar, Me.tlsActualizar, Me.tlsVentas, Me.tlsInsertarRemision})
        resources.ApplyResources(Me.tlsPedidos, "tlsPedidos")
        Me.tlsPedidos.Name = "tlsPedidos"
        '
        'tlsModificar
        '
        Me.tlsModificar.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        resources.ApplyResources(Me.tlsModificar, "tlsModificar")
        Me.tlsModificar.Name = "tlsModificar"
        '
        'tlsActualizar
        '
        Me.tlsActualizar.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        resources.ApplyResources(Me.tlsActualizar, "tlsActualizar")
        Me.tlsActualizar.Name = "tlsActualizar"
        '
        'tlsVentas
        '
        Me.tlsVentas.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        resources.ApplyResources(Me.tlsVentas, "tlsVentas")
        Me.tlsVentas.Name = "tlsVentas"
        '
        'dtpFechaVenta
        '
        Me.dtpFechaVenta.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        resources.ApplyResources(Me.dtpFechaVenta, "dtpFechaVenta")
        Me.dtpFechaVenta.Name = "dtpFechaVenta"
        '
        'lblFVenta
        '
        resources.ApplyResources(Me.lblFVenta, "lblFVenta")
        Me.lblFVenta.Name = "lblFVenta"
        '
        'tlsInsertarRemision
        '
        Me.tlsInsertarRemision.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        resources.ApplyResources(Me.tlsInsertarRemision, "tlsInsertarRemision")
        Me.tlsInsertarRemision.Name = "tlsInsertarRemision"
        '
        'frmVentasPortatil
        '
        resources.ApplyResources(Me, "$this")
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.lblFVenta)
        Me.Controls.Add(Me.dtpFechaVenta)
        Me.Controls.Add(Me.tlsPedidos)
        Me.Controls.Add(Me.dgvPedidos)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.Name = "frmVentasPortatil"
        CType(Me.dgvPedidos, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tlsPedidos.ResumeLayout(False)
        Me.tlsPedidos.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents dgvPedidos As System.Windows.Forms.DataGridView
    Friend WithEvents tlsPedidos As System.Windows.Forms.ToolStrip
    Friend WithEvents tlsModificar As System.Windows.Forms.ToolStripButton
    Friend WithEvents dtpFechaVenta As System.Windows.Forms.DateTimePicker
    Friend WithEvents lblFVenta As System.Windows.Forms.Label
    Friend WithEvents tlsActualizar As System.Windows.Forms.ToolStripButton
    Friend WithEvents tlsVentas As System.Windows.Forms.ToolStripButton
    Friend WithEvents tlsInsertarRemision As System.Windows.Forms.ToolStripButton
End Class
