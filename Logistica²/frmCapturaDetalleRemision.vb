Imports System.Data.SqlClient
Imports System.Configuration
Imports System.Text

Public Class frmCapturaDetalleRemision
    Inherits System.Windows.Forms.Form

    Private Folio As Integer
    Private AñoAtt As Integer
    Private SerieRemision As String
    Dim pedidoPortatil As Integer = 0


#Region " Windows Form Designer generated code "

    Public Sub New(ByVal Folio As Integer, ByVal AñoAtt As Integer, ByVal SerieRemision As String)
        MyBase.New()
        InitializeComponent()

        Dim daCallCenter As New SqlDataAdapter("spCCConsultaProductosPtl @ZonaEconomica = " & ZonaEconomica, cnSigamet)
        Me.txtRemision.Focus()
        Me.txtRemision.Select()
        Me.Text = "Folio: " & Folio & " SerieRemision: " & SerieRemision
        Me.Folio = Folio
        Me.AñoAtt = AñoAtt
        Me.SerieRemision = SerieRemision
        Try
            daCallCenter.Fill(dtProducto)
            grdDetalle.DataSource = dtProducto
        Catch ex As Exception
            MessageBox.Show(ex.Message, Application.ProductName & " v." & Application.ProductVersion, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
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
    Friend WithEvents grpPedido As System.Windows.Forms.GroupBox
    Friend WithEvents lblRemision As System.Windows.Forms.Label
    Friend WithEvents txtRemision As System.Windows.Forms.TextBox
    Friend WithEvents grpDetalle As System.Windows.Forms.GroupBox
    Friend WithEvents tbsDetalle As System.Windows.Forms.DataGridTableStyle
    Friend WithEvents colProducto As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents colCantidad As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents btnAceptar As System.Windows.Forms.Button
    Friend WithEvents btnCancelar As System.Windows.Forms.Button
    Friend WithEvents grdDetalle As System.Windows.Forms.DataGrid
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmCapturaDetalleRemision))
        Me.grpPedido = New System.Windows.Forms.GroupBox()
        Me.lblRemision = New System.Windows.Forms.Label()
        Me.txtRemision = New System.Windows.Forms.TextBox()
        Me.grpDetalle = New System.Windows.Forms.GroupBox()
        Me.grdDetalle = New System.Windows.Forms.DataGrid()
        Me.tbsDetalle = New System.Windows.Forms.DataGridTableStyle()
        Me.colProducto = New System.Windows.Forms.DataGridTextBoxColumn()
        Me.colCantidad = New System.Windows.Forms.DataGridTextBoxColumn()
        Me.btnAceptar = New System.Windows.Forms.Button()
        Me.btnCancelar = New System.Windows.Forms.Button()
        Me.grpPedido.SuspendLayout()
        Me.grpDetalle.SuspendLayout()
        CType(Me.grdDetalle, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'grpPedido
        '
        Me.grpPedido.Controls.Add(Me.lblRemision)
        Me.grpPedido.Controls.Add(Me.txtRemision)
        Me.grpPedido.Dock = System.Windows.Forms.DockStyle.Top
        Me.grpPedido.Location = New System.Drawing.Point(3, 0)
        Me.grpPedido.Name = "grpPedido"
        Me.grpPedido.Size = New System.Drawing.Size(425, 80)
        Me.grpPedido.TabIndex = 0
        Me.grpPedido.TabStop = False
        Me.grpPedido.Text = "Pedido"
        '
        'lblRemision
        '
        Me.lblRemision.AutoSize = True
        Me.lblRemision.Location = New System.Drawing.Point(8, 24)
        Me.lblRemision.Name = "lblRemision"
        Me.lblRemision.Size = New System.Drawing.Size(53, 13)
        Me.lblRemision.TabIndex = 0
        Me.lblRemision.Text = "Remisión:"
        '
        'txtRemision
        '
        Me.txtRemision.BackColor = System.Drawing.Color.WhiteSmoke
        Me.txtRemision.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtRemision.Location = New System.Drawing.Point(112, 21)
        Me.txtRemision.Name = "txtRemision"
        Me.txtRemision.Size = New System.Drawing.Size(296, 21)
        Me.txtRemision.TabIndex = 1
        Me.txtRemision.TabStop = False
        '
        'grpDetalle
        '
        Me.grpDetalle.Controls.Add(Me.grdDetalle)
        Me.grpDetalle.Dock = System.Windows.Forms.DockStyle.Top
        Me.grpDetalle.Location = New System.Drawing.Point(3, 80)
        Me.grpDetalle.Name = "grpDetalle"
        Me.grpDetalle.Size = New System.Drawing.Size(425, 155)
        Me.grpDetalle.TabIndex = 1
        Me.grpDetalle.TabStop = False
        Me.grpDetalle.Text = "Detalle"
        '
        'grdDetalle
        '
        Me.grdDetalle.AllowSorting = False
        Me.grdDetalle.AlternatingBackColor = System.Drawing.Color.Lavender
        Me.grdDetalle.BackColor = System.Drawing.Color.WhiteSmoke
        Me.grdDetalle.BackgroundColor = System.Drawing.Color.LightGray
        Me.grdDetalle.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.grdDetalle.CaptionBackColor = System.Drawing.Color.LightSteelBlue
        Me.grdDetalle.CaptionForeColor = System.Drawing.Color.MidnightBlue
        Me.grdDetalle.CaptionVisible = False
        Me.grdDetalle.DataMember = ""
        Me.grdDetalle.Dock = System.Windows.Forms.DockStyle.Fill
        Me.grdDetalle.FlatMode = True
        Me.grdDetalle.Font = New System.Drawing.Font("Tahoma", 8.0!)
        Me.grdDetalle.ForeColor = System.Drawing.Color.MidnightBlue
        Me.grdDetalle.GridLineColor = System.Drawing.Color.Gainsboro
        Me.grdDetalle.GridLineStyle = System.Windows.Forms.DataGridLineStyle.None
        Me.grdDetalle.HeaderBackColor = System.Drawing.Color.MidnightBlue
        Me.grdDetalle.HeaderFont = New System.Drawing.Font("Tahoma", 8.0!, System.Drawing.FontStyle.Bold)
        Me.grdDetalle.HeaderForeColor = System.Drawing.Color.WhiteSmoke
        Me.grdDetalle.LinkColor = System.Drawing.Color.Teal
        Me.grdDetalle.Location = New System.Drawing.Point(3, 17)
        Me.grdDetalle.Name = "grdDetalle"
        Me.grdDetalle.ParentRowsBackColor = System.Drawing.Color.Gainsboro
        Me.grdDetalle.ParentRowsForeColor = System.Drawing.Color.MidnightBlue
        Me.grdDetalle.RowHeaderWidth = 5
        Me.grdDetalle.SelectionBackColor = System.Drawing.Color.CadetBlue
        Me.grdDetalle.SelectionForeColor = System.Drawing.Color.WhiteSmoke
        Me.grdDetalle.Size = New System.Drawing.Size(419, 135)
        Me.grdDetalle.TabIndex = 0
        Me.grdDetalle.TableStyles.AddRange(New System.Windows.Forms.DataGridTableStyle() {Me.tbsDetalle})
        '
        'tbsDetalle
        '
        Me.tbsDetalle.AlternatingBackColor = System.Drawing.Color.Lavender
        Me.tbsDetalle.BackColor = System.Drawing.Color.WhiteSmoke
        Me.tbsDetalle.DataGrid = Me.grdDetalle
        Me.tbsDetalle.ForeColor = System.Drawing.Color.MidnightBlue
        Me.tbsDetalle.GridColumnStyles.AddRange(New System.Windows.Forms.DataGridColumnStyle() {Me.colProducto, Me.colCantidad})
        Me.tbsDetalle.GridLineColor = System.Drawing.Color.Gainsboro
        Me.tbsDetalle.HeaderBackColor = System.Drawing.Color.MidnightBlue
        Me.tbsDetalle.HeaderForeColor = System.Drawing.Color.WhiteSmoke
        Me.tbsDetalle.LinkColor = System.Drawing.Color.Teal
        Me.tbsDetalle.SelectionBackColor = System.Drawing.Color.CadetBlue
        Me.tbsDetalle.SelectionForeColor = System.Drawing.Color.WhiteSmoke
        '
        'colProducto
        '
        Me.colProducto.Format = ""
        Me.colProducto.FormatInfo = Nothing
        Me.colProducto.HeaderText = "Producto"
        Me.colProducto.MappingName = "Descripcion"
        Me.colProducto.ReadOnly = True
        Me.colProducto.Width = 325
        '
        'colCantidad
        '
        Me.colCantidad.Format = ""
        Me.colCantidad.FormatInfo = Nothing
        Me.colCantidad.HeaderText = "Cantidad"
        Me.colCantidad.MappingName = "Cantidad"
        Me.colCantidad.NullText = "0"
        Me.colCantidad.Width = 70
        '
        'btnAceptar
        '
        Me.btnAceptar.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnAceptar.Image = CType(resources.GetObject("btnAceptar.Image"), System.Drawing.Image)
        Me.btnAceptar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnAceptar.Location = New System.Drawing.Point(118, 253)
        Me.btnAceptar.Name = "btnAceptar"
        Me.btnAceptar.Size = New System.Drawing.Size(75, 23)
        Me.btnAceptar.TabIndex = 2
        Me.btnAceptar.Text = "&Aceptar"
        Me.btnAceptar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'btnCancelar
        '
        Me.btnCancelar.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnCancelar.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnCancelar.Image = CType(resources.GetObject("btnCancelar.Image"), System.Drawing.Image)
        Me.btnCancelar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnCancelar.Location = New System.Drawing.Point(230, 253)
        Me.btnCancelar.Name = "btnCancelar"
        Me.btnCancelar.Size = New System.Drawing.Size(75, 23)
        Me.btnCancelar.TabIndex = 3
        Me.btnCancelar.Text = "&Cancelar"
        Me.btnCancelar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'frmCapturaDetalleRemision
        '
        Me.AcceptButton = Me.btnAceptar
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 14)
        Me.BackColor = System.Drawing.Color.Gainsboro
        Me.CancelButton = Me.btnCancelar
        Me.ClientSize = New System.Drawing.Size(431, 286)
        Me.Controls.Add(Me.btnAceptar)
        Me.Controls.Add(Me.grpDetalle)
        Me.Controls.Add(Me.grpPedido)
        Me.Controls.Add(Me.btnCancelar)
        Me.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.Name = "frmCapturaDetalleRemision"
        Me.Padding = New System.Windows.Forms.Padding(3, 0, 3, 0)
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.grpPedido.ResumeLayout(False)
        Me.grpPedido.PerformLayout()
        Me.grpDetalle.ResumeLayout(False)
        CType(Me.grdDetalle, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

#End Region

#Region "Variables globales"
    Private dtProducto As New DataTable()
    Private ZonaEconomica As Short
    Private banderaTransaccion As Boolean = False
#End Region

    Private Sub btnAceptar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAceptar.Click
        If txtRemision.Text.Length > 0 Then
            Dim BanderaCantidad As Boolean = False
            Dim Row As DataRow
            Dim msjDetalle As New StringBuilder
            msjDetalle.Append("¿La remisión a insertar es: " + txtRemision.Text + ", ¿El detalle de venta es correcto?")
            msjDetalle.AppendLine()
            Dim Producto As String
            For Each Row In dtProducto.Rows
                If Not Microsoft.VisualBasic.IsDBNull(Row("Cantidad")) AndAlso CInt(Row("Cantidad")) > 0 Then
                    BanderaCantidad = True
                    Producto = Row("Producto").ToString()
                    msjDetalle.Append("Producto: " + Row("Descripcion").ToString() + "  Cantidad: " + Row("Cantidad").ToString())
                    msjDetalle.AppendLine()
                End If
            Next
            If BanderaCantidad Then
                If MessageBox.Show(msjDetalle.ToString(), Me.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) = Windows.Forms.DialogResult.Yes Then
                    ExecuteLiquidationWithSqlTransaction(cnSigamet)
                End If
            Else
                MessageBox.Show("No realizó ninguna asignación de venta para esta remisión.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If
        Else
            MessageBox.Show("Debe ingresar una remisión", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If

    End Sub

    Private Sub ExecuteLiquidationWithSqlTransaction(ByVal connection As SqlConnection)
        connection.Open()
        Dim command As SqlCommand = connection.CreateCommand()
        Dim transaction As SqlTransaction
        transaction = connection.BeginTransaction("SampleTransaction")
        command.Connection = connection
        command.Transaction = transaction

        Try

            InsertaCabeceraRemision(Folio, AñoAtt, SerieRemision, Convert.ToInt32(txtRemision.Text), connection, transaction)
            Dim Row As DataRow
            For Each Row In dtProducto.Rows
                If Not Microsoft.VisualBasic.IsDBNull(Row("Cantidad")) AndAlso CInt(Row("Cantidad")) > 0 Then
                    InsertaDetalleRemision(pedidoPortatil, Convert.ToInt32(Row("Producto")), Convert.ToInt32(Row("Cantidad")), connection, transaction)
                End If
            Next

            transaction.Commit()
            Me.Close()
            Me.DialogResult = Windows.Forms.DialogResult.OK

        Catch ex As Exception
            transaction.Rollback()
            MessageBox.Show("Error: " + ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            If connection.State = System.Data.ConnectionState.Open Then
                connection.Close()
            End If
        End Try
    End Sub

    Public Sub InsertaCabeceraRemision(ByVal Folio As Integer, ByVal AñoAtt As Integer, ByVal SerieRemision As String, ByVal Remision As Integer, ByVal Connection As SqlConnection, ByVal Transaction As SqlTransaction)
        Dim cmdComando As SqlCommand

        Try
            cmdComando = New SqlCommand("spSOPMOVInsertaPedidoPortatil", Connection)
            cmdComando.Transaction = Transaction
            cmdComando.Parameters.Add("@Folio", SqlDbType.Int).Value = Folio
            cmdComando.Parameters.Add("@AñoAtt", SqlDbType.Int).Value = AñoAtt
            cmdComando.Parameters.Add("@SerieRemision", SqlDbType.VarChar).Value = SerieRemision
            cmdComando.Parameters.Add("@Remision", SqlDbType.Int).Value = Remision
            cmdComando.Parameters.Add("@PedidoPortatil", SqlDbType.Int).Direction = ParameterDirection.Output
            cmdComando.CommandType = CommandType.StoredProcedure
            cmdComando.ExecuteNonQuery()
            pedidoPortatil = Convert.ToInt32(cmdComando.Parameters("@PedidoPortatil").Value)
            cmdComando.Dispose()
        Catch exc As Exception
            Throw exc
        End Try
    End Sub

    Public Sub InsertaDetalleRemision(ByVal PedidoPortatil As Integer, ByVal Producto As Integer, ByVal Cantidad As Integer, ByVal Connection As SqlConnection, ByVal Transaction As SqlTransaction)
        Dim cmdComando As SqlCommand

        Try
            cmdComando = New SqlCommand("spSOPMOVInsertaPedidoPortatilAtendido", Connection)
            cmdComando.Transaction = Transaction
            cmdComando.Parameters.Add("@PedidoPortatil", SqlDbType.Int).Value = PedidoPortatil
            cmdComando.Parameters.Add("@Producto", SqlDbType.Int).Value = Producto
            cmdComando.Parameters.Add("@CantidadTanques", SqlDbType.Int).Value = Cantidad
            cmdComando.CommandType = CommandType.StoredProcedure
            cmdComando.ExecuteNonQuery()
            cmdComando.Dispose()
        Catch exc As Exception
            Throw exc
        End Try
    End Sub

    
    Private Sub grdDetalle_PreviewKeyDown(sender As System.Object, e As System.Windows.Forms.PreviewKeyDownEventArgs) Handles grdDetalle.PreviewKeyDown
        If e.KeyCode = 46 Then
            grdDetalle.ReadOnly = True
        End If
    End Sub

    Protected Overrides Function ProcessCmdKey( _
               ByRef msg As Message, _
               ByVal keyData As Keys) As Boolean

        ' Si el control DataGrid no tiene el foco, abandonamos la función.
        '
        If (Not (m_IsDataGridFocused)) Then
            Return False
        End If


        ' Si se ha pulsado la tecla Supr, abandonamos la función.
        If (keyData = Keys.Delete) Then
            Return True
        Else
            grdDetalle.ReadOnly = False
            Return False
        End If

        Return MyBase.ProcessCmdKey(msg, keyData)

    End Function

    Private m_IsDataGridFocused As Boolean

    Private Sub grdDetalle_Enter(ByVal sender As Object, ByVal e As EventArgs) Handles grdDetalle.Enter

        m_IsDataGridFocused = True

    End Sub

    Private Sub grdDetalle_Click(ByVal sender As Object, ByVal e As EventArgs) Handles grdDetalle.MouseClick

        m_IsDataGridFocused = True

    End Sub

    Private Sub grdDetalle_MousseDown(ByVal sender As Object, ByVal e As EventArgs) Handles grdDetalle.MouseDown

        m_IsDataGridFocused = True

    End Sub
    Private Sub grdDetalle_MoussUp(ByVal sender As Object, ByVal e As EventArgs) Handles grdDetalle.MouseUp

        m_IsDataGridFocused = True

    End Sub

    Private Sub grdDetalle_MoussDoubleClick(ByVal sender As Object, ByVal e As EventArgs) Handles grdDetalle.MouseDoubleClick


        m_IsDataGridFocused = True

    End Sub

    Private Sub grdDetalle_Leave(ByVal sender As Object, ByVal e As EventArgs) Handles grdDetalle.Leave

        m_IsDataGridFocused = False

    End Sub

    Private Sub btnCancelar_Click(sender As System.Object, e As System.EventArgs) Handles btnCancelar.Click
        Me.Close()
        Me.DialogResult = Windows.Forms.DialogResult.Cancel
    End Sub

    Private Sub frmPedidoPortatil_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load

    End Sub

    Private Sub grpPedido_Enter(sender As System.Object, e As System.EventArgs) Handles grpPedido.Enter

    End Sub

    Private Sub txtRemision_KeyPress(sender As System.Object, e As System.Windows.Forms.KeyPressEventArgs) Handles txtRemision.KeyPress
        If Not (Char.IsDigit(e.KeyChar) Or Asc(e.KeyChar) = 8 Or Char.IsControl(e.KeyChar)) Then
            e.Handled = True
        Else
            e.Handled = False
        End If
    End Sub
End Class
