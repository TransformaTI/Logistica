Imports System.Data.SqlClient
Public Class VentasPortatilAgrupadas
    Dim cmdVentas As SqlCommand
    Dim daVentas As SqlDataAdapter
    Dim dtVentas As DataTable
    Private _fechaVenta As Date
    Public Property FechaVenta() As Date
        Get
            Return _fechaVenta
        End Get
        Set(ByVal value As Date)
            _fechaVenta = value
        End Set
    End Property

    Private _usuarioMovil As String
    Public Property UsuarioMovil() As String
        Get
            Return _usuarioMovil
        End Get
        Set(ByVal value As String)
            _usuarioMovil = value
        End Set
    End Property
    Private _versionMovilGas As Integer
    Public Property VersionMovilGas() As Integer
        Get
            Return _versionMovilGas
        End Get
        Set(ByVal value As Integer)
            _versionMovilGas = value
        End Set
    End Property

    Private Sub frmVentasPortatilPorProducto_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        ConsultaVentasPortatilAgrupada()
    End Sub

    Private Sub ConsultaVentasPortatilAgrupada()
        cmdVentas = New SqlCommand("spLOGConsultaVentasPortatilAgrupada", cnSigamet)
        cmdVentas.CommandType = CommandType.StoredProcedure
        cmdVentas.Parameters.Add("@FVenta", SqlDbType.DateTime).Value = _fechaVenta
        cmdVentas.Parameters.Add("@UsuarioMovil", SqlDbType.VarChar).Value = _usuarioMovil

        daVentas = New SqlDataAdapter(cmdVentas)
        dtVentas = New DataTable
        Dim PKColumn(0) As DataColumn
        dgvVentas.DataSource = Nothing
        Try
            dtVentas.Clear()
            daVentas.Fill(dtVentas)
            If dtVentas.Rows.Count > 0 Then
                PKColumn(0) = dtVentas.Columns(0)
                dtVentas.PrimaryKey = PKColumn
            End If
            dgvVentas.DataSource = dtVentas
            dgvVentas.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.DisplayedCells
        Catch ex As Exception
            ExMessage(ex)
        End Try
    End Sub
End Class