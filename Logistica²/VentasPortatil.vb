Imports System.Data.SqlClient

Public Class frmVentasPortatil

    Public Sub New(ByVal UsuarioMovil As String, ByVal NombreUsr As String, ByVal SoporteMovilAnterior As Boolean)
        MyBase.New()

        InitializeComponent()

        Me.Text = "Ventas usuario móvil: " + NombreUsr
        _usuarioMovil = UsuarioMovil
        _fVenta = Now
        _soporteMovilAnterior = SoporteMovilAnterior
        CargarVentas()
        ConsultaVentasPortatilAgrupada()
    End Sub

    'Public Sub New(ByVal Usuario As String, ByVal NombreUsuario As String)
    '    MyBase.New()

    '    InitializeComponent()

    '    Me.Text = "Ventas usuario móvil: " + NombreUsuario
    '    Me.UsuarioMovil = Usuario
    '    FVenta = Now
    '    CargarVentas(FVenta, UsuarioMovil)
    'End Sub

#Region "Variables globales"
    Dim dtPedidos As New DataTable()
    Dim _fVenta As Date
    Dim _usuarioMovil As String
    Dim _soporteMovilAnterior As Boolean = False
#End Region

#Region "Rutinas de actualización"
    Public Sub CargarVentas()
        'If Not cboCelula.SelectedValue Is Nothing Then
        Dim cmdLogistica As New SqlCommand("spLOGConsultaVentaPortatil", cnSigamet)
        cmdLogistica.CommandType = CommandType.StoredProcedure
        cmdLogistica.Parameters.Add("@FVenta", SqlDbType.DateTime).Value = _fVenta
        cmdLogistica.Parameters.Add("@UsuarioMovil", SqlDbType.VarChar).Value = _usuarioMovil
        If _soporteMovilAnterior Then
            cmdLogistica.CommandText = "spLOGConsultaVentasPortatil"
        End If
        Dim daLogistica As New SqlDataAdapter(cmdLogistica)
        Dim PKColumn(0) As DataColumn
        dgvPedidos.DataSource = Nothing
        Try
            dtPedidos.Clear()
            daLogistica.Fill(dtPedidos)
            If dtPedidos.Rows.Count > 0 Then
                PKColumn(0) = dtPedidos.Columns(0)
                dtPedidos.PrimaryKey = PKColumn
            End If
            dgvPedidos.DataSource = dtPedidos
            dgvPedidos.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.DisplayedCells
        Catch ex As Exception
            ExMessage(ex)
        End Try
        'End If
    End Sub

    'Public Sub CargarVentas(ByVal FVenta As Date, ByVal Usuario As String)
    '    'If Not cboCelula.SelectedValue Is Nothing Then
    '    'VersionMovil = 3
    '    Dim cmdLogistica As New SqlCommand("spLOGConsultaVentasPortatil", cnSigamet)
    '    cmdLogistica.CommandType = CommandType.StoredProcedure
    '    cmdLogistica.Parameters.Add("@FVenta", SqlDbType.Int).Value = FVenta
    '    cmdLogistica.Parameters.Add("@UsuarioMovil", SqlDbType.DateTime).Value = Usuario

    '    Dim daLogistica As New SqlDataAdapter(cmdLogistica)
    '    Dim PKColumn(0) As DataColumn
    '    dgvPedidos.DataSource = Nothing
    '    Try
    '        dtPedidos.Clear()
    '        daLogistica.Fill(dtPedidos)
    '        If dtPedidos.Rows.Count > 0 Then
    '            PKColumn(0) = dtPedidos.Columns(0)
    '            dtPedidos.PrimaryKey = PKColumn
    '        End If
    '        dgvPedidos.DataSource = dtPedidos
    '        dgvPedidos.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.DisplayedCells
    '    Catch ex As Exception
    '        ExMessage(ex)
    '    End Try
    '    'End If
    'End Sub

#End Region

    Private Sub dtpFechaVenta_ValueChanged(sender As System.Object, e As System.EventArgs) Handles dtpFechaVenta.ValueChanged
        _fVenta = dtpFechaVenta.Value
        CargarVentas()
        ConsultaVentasPortatilAgrupada()
    End Sub

    Private Sub tlsModificar_Click(sender As System.Object, e As System.EventArgs) Handles tlsModificar.Click
        If Not dgvPedidos.CurrentRow Is Nothing Then
            Dim NumPedidoPortatil, NumClientePortatil As Integer
            Dim Remision As String
            Dim Permitemodificar As Boolean = False

            NumPedidoPortatil = CInt(dgvPedidos.CurrentRow.Cells("PedidoPortatil").Value)
            NumClientePortatil = CInt(dgvPedidos.CurrentRow.Cells("ClientePortatil").Value)
            Remision = CStr(dgvPedidos.CurrentRow.Cells("SerieRemision").Value) & "-" & CStr(dgvPedidos.CurrentRow.Cells("Remision").Value)

            CargarVentas()
            BuscaValorEnGrid(NumPedidoPortatil)

            If CStr(dgvPedidos.CurrentRow.Cells("StatusMG").Value) = "CANCELADO" Then
                MessageBox.Show("El pedido se encuentra cancelado, no es posible modificar el detalle.", "Soporte móvil.", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
                Exit Sub
            End If

            If CStr(dgvPedidos.CurrentRow.Cells("StatusLogistica").Value) <> "LIQCAJA" Then
                Permitemodificar = True
            Else
                Permitemodificar = False
                MessageBox.Show("El folio de venta se encuentra liquidado, no será posible modificar el detalle del pedido.", "Soporte móvil.", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If

            Dim frmDetallePedidoPortatil As New frmPedidoPortatil(NumClientePortatil, NumPedidoPortatil, Remision, Permitemodificar)
            If frmDetallePedidoPortatil.ShowDialog = Windows.Forms.DialogResult.OK Then
                'MessageBox.Show("El detalle del pedido fué modificado.", "Soporte móvil.", MessageBoxButtons.OK, MessageBoxIcon.Information)                
                dgvPedidos.Focus()
                CargarVentas()
                BuscaValorEnGrid(NumPedidoPortatil)
            End If
            'Eliminación de objetos
            frmDetallePedidoPortatil.Dispose()
        End If
    End Sub

    Private Sub tlsCerrar_Click(sender As System.Object, e As System.EventArgs)
        Me.Close()
    End Sub

    Private Sub tlsActualizar_Click(sender As System.Object, e As System.EventArgs) Handles tlsActualizar.Click
        CargarVentas()
    End Sub

    Private Sub BuscaValorEnGrid(ByVal NumPedidoPortatil As Integer)
        For Each row As DataGridViewRow In dgvPedidos.Rows
            If CInt(row.Cells("PedidoPortatil").Value) = NumPedidoPortatil Then
                'row.Selected = True                
                dgvPedidos.CurrentCell = dgvPedidos.Rows(row.Index).Cells(0)
                Exit For
            End If
        Next

    End Sub

    Private Sub tlsPedidos_ItemClicked(sender As System.Object, e As System.Windows.Forms.ToolStripItemClickedEventArgs) Handles tlsPedidos.ItemClicked

    End Sub
    Private Sub frmVentasPortatil_KeyDown(sender As System.Object, e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown
        If (e.KeyCode = Keys.Escape) Then
            Me.Close()
        End If
    End Sub

    Private Sub tlsVentas_Click(sender As System.Object, e As System.EventArgs) Handles tlsVentas.Click
        Dim frmVentas As New VentasPortatilAgrupadas
        frmVentas.FechaVenta = _fVenta
        frmVentas.UsuarioMovil = _usuarioMovil
        frmVentas.ShowDialog()
    End Sub

    Private Sub tlsInsertarRemision_Click(sender As System.Object, e As System.EventArgs) Handles tlsInsertarRemision.Click

        If Not dgvPedidos.CurrentRow Is Nothing Then
            If CStr(dgvPedidos.CurrentRow.Cells("StatusLogistica").Value) <> "LIQCAJA" Then
                Dim Folio, AñoAtt As Integer
                Dim SerieRemision As String = String.Empty

                If IsDBNull(dgvPedidos.CurrentRow.Cells("Folio").Value) = False Then
                    Folio = Convert.ToInt32(dgvPedidos.CurrentRow.Cells("Folio").Value)
                    AñoAtt = Convert.ToDateTime(dgvPedidos.CurrentRow.Cells("FechaSuministro").Value).Year
                    SerieRemision = dgvPedidos.CurrentRow.Cells("SerieRemision").Value.ToString()
                    'Dim frmDetallePedidoPortatil As New frmCapturaDetalleRemision(Folio, AñoAtt, SerieRemision)
                    'If frmDetallePedidoPortatil.ShowDialog = Windows.Forms.DialogResult.OK Then
                    '    MessageBox.Show("La remisión se genero con exito.", "Soporte móvil.", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
                    '    CargarVentas()
                    'End If
                End If
            Else
                MessageBox.Show("El folio de venta se encuentra liquidado, no será posible agragar alguna remisión adicional.", "Soporte móvil.", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If
        End If
    End Sub

    Private Sub ConsultaVentasPortatilAgrupada()
        Dim cmdVentas As SqlCommand
        Dim daVentas As SqlDataAdapter
        Dim dtVentas As DataTable
        cmdVentas = New SqlCommand("spLOGConsultaVentasPortatilAgrupada", cnSigamet)
        cmdVentas.CommandType = CommandType.StoredProcedure
        cmdVentas.Parameters.Add("@FVenta", SqlDbType.DateTime).Value = _fVenta
        cmdVentas.Parameters.Add("@UsuarioMovil", SqlDbType.VarChar).Value = _usuarioMovil

        daVentas = New SqlDataAdapter(cmdVentas)
        dtVentas = New DataTable
        Dim PKColumn(0) As DataColumn
        'dgvVentas.DataSource = Nothing
        Try
            dtVentas.Clear()
            daVentas.Fill(dtVentas)
            If dtVentas.Rows.Count > 0 Then
                PKColumn(0) = dtVentas.Columns(0)
                dtVentas.PrimaryKey = PKColumn
            End If
            'dgvVentas.DataSource = dtVentas
            'dgvVentas.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.DisplayedCells
        Catch ex As Exception
            ExMessage(ex)
        End Try
    End Sub


End Class