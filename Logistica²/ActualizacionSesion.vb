Public Class ActualizacionSesion

    Private _sesion As Integer
    Public Property Sesion() As Integer
        Get
            Return _sesion
        End Get
        Set(ByVal value As Integer)
            _sesion = value
        End Set
    End Property

    Public Property Usuario() As String
        Get
            Return lblUsuario.Text
        End Get
        Set(ByVal value As String)
            lblUsuario.Text = value
        End Set
    End Property

    Public Property Nombre() As String
        Get
            Return lblNombre.Text
        End Get
        Set(ByVal value As String)
            lblNombre.Text = value
        End Set
    End Property

    Public Property Ruta() As String
        Get
            Return lblRuta.Text
        End Get
        Set(ByVal value As String)
            lblRuta.Text = value
        End Set
    End Property

    Public Property Camion() As String
        Get
            Return lblCamion.Text
        End Get
        Set(ByVal value As String)
            lblCamion.Text = value
        End Set
    End Property

    Public Property IMEI() As String
        Get
            Return lblImei.Text
        End Get
        Set(ByVal value As String)
            lblImei.Text = value
        End Set
    End Property

    Public Property EstadoSesion As String
        Get
            Dim _estadoSesion As String = String.Empty

            If cboEstadoSesion.SelectedItem Is Nothing Then
                _estadoSesion = String.Empty
            Else
                _estadoSesion = cboEstadoSesion.SelectedItem.ToString()
            End If
            Return _estadoSesion
        End Get
        Set(ByVal value As String)
            cboEstadoSesion.SelectedIndex = cboEstadoSesion.FindString(EstadoSesion)
        End Set
    End Property

    Private _estadoLiquidacion As String
    Public Property EstadoLiquidacion As String
        Get
            Return _estadoLiquidacion
        End Get
        Set(ByVal value As String)
            _estadoLiquidacion = value
            End Set
    End Property

    Private _estadoRecuperacion As String
    Public Property EstadoRecuperacion() As String
        Get
            Return _estadoRecuperacion
        End Get
        Set(ByVal value As String)
            _estadoRecuperacion = value

            chkRecuperarInformacion.Checked = (_estadoRecuperacion.Trim.ToUpper = "RECUPERAR")
        End Set
    End Property




    Private Sub btnCancelar_Click(sender As System.Object, e As System.EventArgs) Handles btnCancelar.Click
        Me.DialogResult = Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub

    Private Sub btnAceptar_Click(sender As System.Object, e As System.EventArgs) Handles btnAceptar.Click
        Dim cmdLogistica As New System.Data.SqlClient.SqlCommand()

        cmdLogistica.CommandText = "spLOGActualizaSesionMovilGas"
        cmdLogistica.Connection = cnSigamet
        cmdLogistica.CommandType = CommandType.StoredProcedure

        cmdLogistica.Parameters.Add("@IDSesion", SqlDbType.Int).Value = Me.Sesion
        cmdLogistica.Parameters.Add("@Estatus", SqlDbType.VarChar).Value = Me.EstadoSesion

        cmdLogistica.Parameters.Add("@Recuperar", SqlDbType.Bit).Value = Me.chkRecuperarInformacion.Checked

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

    End Sub
End Class