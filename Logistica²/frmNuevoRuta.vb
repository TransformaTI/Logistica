Imports System.Data.SqlClient

Public Class frmNuevoRuta
    Private idValorRuta As Integer
    Private rutaGlobal As New Ruta
    Private conexion As SqlConnection

    Public Sub New(ByVal IdRura As Integer, ByVal Conexion As SqlConnection)
        MyBase.New()
        InitializeComponent()
        Me.idValorRuta = IdRura
        Me.conexion = Conexion
        rutaGlobal = Consultar(Me.idValorRuta)

        txtIdRuta.Text = rutaGlobal.IdRuta.ToString()
        txtDescripcion.Text = rutaGlobal.Descripcion
        chbComision.Checked = rutaGlobal.Comision
        txtPrecioLitro.Text = rutaGlobal.PrecioLitro.ToString()
    End Sub
    Private Sub btnAceptar_Click(sender As System.Object, e As System.EventArgs) Handles btnAceptar.Click
        Dim res As Boolean = Actualiza(Me.idValorRuta)
        If (res) Then
            MessageBox.Show("Registro actualizado correctamente.", "Mensaje del sistema", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Me.Close()
        Else
            MessageBox.Show("No pudo ser actualizado el registro.", "Mensaje del sistema", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End If
    End Sub

    Private Sub btnCancelar_Click(sender As System.Object, e As System.EventArgs) Handles btnCancelar.Click
        Me.Close()
    End Sub


    Public Class Ruta
        Public Sub New()

        End Sub

        Private idRutas As Integer

        Public Property IdRuta() As Integer
            Get
                Return Me.idRutas
            End Get
            Set(value As Integer)
                idRutas = value
            End Set
        End Property

        Private descripciones As String

        Public Property Descripcion() As String
            Get
                Return Me.descripciones
            End Get
            Set(value As String)
                descripciones = value
            End Set
        End Property

        Private comisiones As Boolean

        Public Property Comision() As Boolean
            Get
                Return Me.comisiones
            End Get
            Set(value As Boolean)
                comisiones = value
            End Set
        End Property

        Private precioLitros As Decimal

        Public Property PrecioLitro() As Decimal
            Get
                Return Me.precioLitros
            End Get
            Set(value As Decimal)
                precioLitros = value
            End Set
        End Property

    End Class

    Private Function Consultar(ByVal IdRuta As Integer) As Ruta
        Dim ruta As New Ruta
        Dim Conexion As SqlConnection = Me.conexion
        Try

            Conexion.Open()
            Dim Comando As New SqlCommand()
            Comando.Connection = Conexion
            Comando.Parameters.Add("@Ruta", SqlDbType.Char).Value = idValorRuta
            Comando.CommandType = CommandType.StoredProcedure
            Comando.CommandText = "spLogConsultarRutaComision"

            Dim reader As SqlDataReader

            reader = Comando.ExecuteReader()
            If (reader.Read()) Then
                ruta.IdRuta = Integer.Parse(reader("Ruta").ToString())
                ruta.Descripcion = reader("Descripcion").ToString()
                ruta.Comision = CType(reader("Comision").ToString(), Boolean)
                ruta.PrecioLitro = Decimal.Parse(reader("PrecioLitro").ToString())
            End If

        Catch eException As Exception
            MsgBox(eException.Message)
        Finally
            Conexion.Close()
        End Try
        Return ruta
    End Function

    Private Function Actualiza(ByVal IdRuta As Integer) As Boolean
        Dim resultado As Boolean = False
        Dim Conexion As SqlConnection = Me.conexion
        Try

            Conexion.Open()
            Dim Comando As New SqlCommand()
            Comando.Connection = Conexion
            Comando.Parameters.Add("@Ruta", SqlDbType.Char).Value = idValorRuta
            Comando.Parameters.Add("@Comision", SqlDbType.Bit).Value = chbComision.Checked
            If (txtPrecioLitro.Text.Length > 0) Then
                Comando.Parameters.Add("@PrecioLitro", SqlDbType.Money).Value = Decimal.Parse(txtPrecioLitro.Text)
            Else
                Comando.Parameters.Add("@PrecioLitro", SqlDbType.Money).Value = 0
            End If

            Comando.CommandType = CommandType.StoredProcedure
            Comando.CommandText = "spLogActualizaComisionRuta"

            Comando.ExecuteNonQuery()
            resultado = True
        Catch eException As Exception
            MsgBox(eException.Message)
        Finally
            Conexion.Close()
        End Try
        Return resultado
    End Function

    Private Sub txtPrecioLitro_KeyPress(sender As System.Object, e As System.Windows.Forms.KeyPressEventArgs) Handles txtPrecioLitro.KeyPress
        If Not (Char.IsDigit(e.KeyChar) OrElse Char.IsControl(e.KeyChar) OrElse Asc(e.KeyChar) = 8 OrElse _
                   (e.KeyChar = CChar(".") AndAlso CType(sender, TextBox).Text.IndexOf(".") < 0)) Then
            e.Handled = True
        Else
            e.Handled = False
        End If
    End Sub
End Class