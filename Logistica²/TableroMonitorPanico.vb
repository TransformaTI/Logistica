Imports System.Data.SqlClient
Imports System.Collections.Generic
Imports System.Text
Imports System.Globalization
Imports System.Linq
Imports Logistica.TableroMonitorPanico

Public Class TableroMonitorPanico

    Dim listaAnterior As New List(Of Informacion)
    Dim listaRenovada As New List(Of Informacion)
    Dim mensaje As StringBuilder
    Dim planta As String

    Private Sub TableroMonitorPanico_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        Cursor = Cursors.WaitCursor
        planta = Globales._NombrePlanta
        lblPlanta.Text = planta
        dtpFecha.Value = Now.Date
        LlenaCombos()
        LlenarGridInicial()
        VerAlertaInicial()
        timerControl.Interval = Globales._TimerInterval
        timerControl.Start()
        Cursor = Cursors.Default
    End Sub

    Private Sub timerControl_Tick(sender As System.Object, e As System.EventArgs) Handles timerControl.Tick
        Cursor = Cursors.WaitCursor
        dtpFecha.Value = Now.Date
        LlenarGrid()
        Cursor = Cursors.Default
    End Sub

    Private Sub btnRefrescar_Click(sender As System.Object, e As System.EventArgs) Handles btnRefrescar.Click
        If (dtpFecha.Text.Length > 0) Then
            Cursor = Cursors.WaitCursor
            LlenarGrid()
            Cursor = Cursors.Default
        Else
            MsgBox("El campo fecha es requerido.")
        End If

    End Sub

    Private Sub btnRunTimer_Click(sender As System.Object, e As System.EventArgs) Handles btnRunTimer.Click
        timerControl.Interval = Globales._TimerInterval
        timerControl.Start()
        btnRunTimer.Visible = False
        btnStopTimer.Visible = True
        dtpFecha.Enabled = False
        dtpFecha.Value = Now.Date
    End Sub

    Private Sub btnStopTimer_Click(sender As System.Object, e As System.EventArgs) Handles btnStopTimer.Click
        If MessageBox.Show("¿Desea detener el monitoreo automatico?", "Mensaje del sistema", MessageBoxButtons.OKCancel, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) = DialogResult.OK Then
            timerControl.Stop()
            btnRunTimer.Visible = True
            btnStopTimer.Visible = False
            dtpFecha.Enabled = True
        End If
    End Sub
    Private Sub cmbNumeroEconomico_KeyPress(sender As System.Object, e As System.Windows.Forms.KeyPressEventArgs) Handles cmbNumeroEconomico.KeyPress
        If e.KeyChar = Convert.ToChar(Keys.Back) Then
            If cmbNumeroEconomico.Items.Count > 0 Then
                cmbNumeroEconomico.SelectedIndex = 0
            End If
        End If
    End Sub

    Private Sub cmbGrupo_KeyPress(sender As System.Object, e As System.Windows.Forms.KeyPressEventArgs) Handles cmbGrupo.KeyPress
        If e.KeyChar = Convert.ToChar(Keys.Back) Then
            If cmbGrupo.Items.Count > 0 Then
                cmbGrupo.SelectedIndex = 0
            End If
        End If
    End Sub

    Private Sub cmbRuta_KeyPress(sender As System.Object, e As System.Windows.Forms.KeyPressEventArgs) Handles cmbRuta.KeyPress
        If e.KeyChar = Convert.ToChar(Keys.Back) Then
            If cmbRuta.Items.Count > 0 Then
                cmbRuta.SelectedIndex = 0
            End If
        End If
    End Sub

    Function LlenaCombos()
        Dim listaGrupos As List(Of GrupoCombo) = ConsultarGrupos()

        Dim grupo As New GrupoCombo
        grupo.IdGrupo = 0
        grupo.Descripcion = "TODOS"
        cmbGrupo.Items.Add(grupo)
        For Each g As GrupoCombo In listaGrupos
            cmbGrupo.Items.Add(g)
        Next

        cmbGrupo.ValueMember = "IdGrupo"
        cmbGrupo.DisplayMember = "Descripcion"

        If (cmbGrupo.Items.Count > 0) Then
            cmbGrupo.SelectedIndex = 0
        End If


        Dim listaRutas As List(Of RutaCombo) = ConsultarRutas()
        Dim ruta As New RutaCombo
        ruta.IdRuta = -1
        ruta.Descripcion = "TODOS"
        cmbRuta.Items.Add(ruta)
        For Each r As RutaCombo In listaRutas
            cmbRuta.Items.Add(r)
        Next

        cmbRuta.ValueMember = "IdRuta"
        cmbRuta.DisplayMember = "Descripcion"

        If (cmbRuta.Items.Count > 0) Then
            cmbRuta.SelectedIndex = 0
        End If


        Dim listaVehiculos As List(Of VehiculoCombo) = ConsultarVehiculos()
        Dim vehiculo As New VehiculoCombo
        vehiculo.IdVehiculo = 0
        vehiculo.Descripcion = "TODOS"
        cmbNumeroEconomico.Items.Add(vehiculo)
        For Each v As VehiculoCombo In listaVehiculos
            cmbNumeroEconomico.Items.Add(v)
        Next

        cmbNumeroEconomico.ValueMember = "IdVehiculo"
        cmbNumeroEconomico.DisplayMember = "Descripcion"

        If (cmbNumeroEconomico.Items.Count > 0) Then
            cmbNumeroEconomico.SelectedIndex = 0
        End If


    End Function

    Function LlenarGridInicial()
        Dim celula As Integer = CType(cmbGrupo.SelectedItem, GrupoCombo).IdGrupo
        Dim ruta As Integer = CType(cmbRuta.SelectedItem, RutaCombo).IdRuta
        Dim vehiculo As Integer = CType(cmbNumeroEconomico.SelectedItem, VehiculoCombo).IdVehiculo
        listaAnterior = ConsultaInformacion(dtpFecha.Value, celula, ruta, vehiculo)
        lblTotalRegistros.Text = listaAnterior.Count
        dgvInformacion.DataSource = Nothing

        If listaAnterior.Count <= 0 Then
            dgvInformacion.Rows(0).Cells(0).Value = "No hay registros."
        Else
            dgvInformacion.DataSource = listaAnterior
        End If


    End Function

    Function LlenarGrid()
        Dim celula As Integer = CType(cmbGrupo.SelectedItem, GrupoCombo).IdGrupo
        Dim ruta As Integer = CType(cmbRuta.SelectedItem, RutaCombo).IdRuta
        Dim vehiculo As Integer = CType(cmbNumeroEconomico.SelectedItem, VehiculoCombo).IdVehiculo
        listaRenovada = ConsultaInformacion(dtpFecha.Value, celula, ruta, vehiculo)

        VerAlertas()

        listaAnterior = listaRenovada

        lblTotalRegistros.Text = listaRenovada.Count
        dgvInformacion.DataSource = Nothing


        If listaRenovada.Count <= 0 Then
            dgvInformacion.Rows(0).Cells(0).Value = "No hay registros."
        Else
            dgvInformacion.DataSource = listaRenovada
        End If

    End Function

    Function VerAlertaInicial()
        Dim mensaje As New StringBuilder
        BlinkingClickLabel1.Visible = False
        lblHistorialDePanicos.Text = String.Empty

        If listaAnterior.Count > 0 Then

            Dim query As IEnumerable(Of Informacion) = listaAnterior.OrderBy(Function(Informacion) Informacion.HoraUltimoPanico).Reverse()
            listaAnterior = query.ToList()

            For value As Integer = 0 To listaAnterior.Count - 1
                If (Not (listaAnterior(value).HoraUltimoPanico Is Nothing) And (listaAnterior(value).NumeroEconomico <> Nothing)) Then
                    mensaje.AppendFormat("{0} - {1:dd/MM/yyyy HH:mm}", listaAnterior(value).NumeroEconomico.ToString(), CType(listaAnterior(value).HoraUltimoPanico, DateTime))
                    mensaje.AppendLine()
                End If

            Next
        End If

        Dim mensajeFinal As New StringBuilder

        If (mensaje.Length = 0) Then
            mensajeFinal.Append("NO HAY PANICOS (ACT).")
            lblHistorialDePanicos.Text = mensajeFinal.ToString()
        Else
            mensajeFinal.Append("ALERTAS ACTIVAS.")
            mensajeFinal.AppendLine()
            mensajeFinal.AppendLine()
            mensajeFinal.Append(mensaje)
            lblHistorialDePanicos.Text = mensajeFinal.ToString()
        End If
    End Function

    Function VerAlertas()
        'Seccion para blind blind de alertas recientes

        Dim mensaje As New StringBuilder
        Dim msj As New StringBuilder
        BlinkingClickLabel1.Text = String.Empty
        lblHistorialDePanicos.Text = String.Empty
        BlinkingClickLabel1.Visible = True

        Dim nuevaLista As New List(Of Informacion)

        If (listaAnterior.Count > 0 And listaRenovada.Count > 0) Then
            For value As Integer = 0 To listaAnterior.Count - 1

                Dim evensQuery = (From num In listaRenovada
                Where (num.Vehiculo = listaAnterior(value).Vehiculo And num.Grupo = listaAnterior(value).Grupo And num.Ruta = listaAnterior(value).Ruta And (Not num.HoraUltimoPanico.ToString().Equals(listaAnterior(value).HoraUltimoPanico.ToString())))
                 Select num).FirstOrDefault()
                nuevaLista.Add(CType(evensQuery, Informacion))

            Next

            Dim nuevaListaLimpia As New List(Of Informacion)
            nuevaListaLimpia = (From num In nuevaLista
                                Where num IsNot Nothing Select num).ToList()

            nuevaListaLimpia.AddRange(listaRenovada.Except(listaAnterior, New InformacionComparer))


            If nuevaListaLimpia.Count > 0 Then

                Dim query As IEnumerable(Of Informacion) = nuevaListaLimpia.OrderBy(Function(Informacion) Informacion.HoraUltimoPanico).Reverse()
                nuevaLista = query.ToList()
                For Each item As Informacion In nuevaLista
                    If (Not (item.HoraUltimoPanico Is Nothing) And (item.NumeroEconomico <> Nothing)) Then
                        msj.AppendFormat("{0} - {1:dd/MM/yyyy HH:mm}", item.NumeroEconomico.ToString(), CType(item.HoraUltimoPanico, DateTime))
                        msj.AppendLine()
                    End If
                Next
            End If

            Dim mensajeAlertaFinal As New StringBuilder

            If (msj.Length = 0) Then
                mensajeAlertaFinal.Append("SIN CAMBIOS")
                BlinkingClickLabel1.Text = mensajeAlertaFinal.ToString()
            Else
                mensajeAlertaFinal.Append("EXISTEN CAMBIOS")
                mensajeAlertaFinal.AppendLine()
                mensajeAlertaFinal.AppendLine()
                mensajeAlertaFinal.Append(msj)
                BlinkingClickLabel1.Text = mensajeAlertaFinal.ToString()
            End If

        End If
        'Seccion para blind blind de alertas viejas

        If listaRenovada.Count > 0 Then
            Dim query As IEnumerable(Of Informacion) = listaRenovada.OrderBy(Function(Informacion) Informacion.HoraUltimoPanico).Reverse()
            listaRenovada = query.ToList()

            For Each item As Informacion In listaRenovada
                If (Not (item.HoraUltimoPanico Is Nothing) And (item.NumeroEconomico <> Nothing)) Then
                    mensaje.AppendFormat("{0} - {1:dd/MM/yyyy HH:mm}", item.NumeroEconomico.ToString(), CType(item.HoraUltimoPanico, DateTime))
                    mensaje.AppendLine()
                End If
            Next
        End If

        Dim mensajeFinal As New StringBuilder

        If (mensaje.Length = 0) Then
            mensajeFinal.Append("NO HAY PANICOS (ACT).")
            lblHistorialDePanicos.Text = mensajeFinal.ToString()
        Else
            mensajeFinal.AppendLine()
            mensajeFinal.Append("ALERTAS ACTIVAS.")
            mensajeFinal.AppendLine()
            mensajeFinal.AppendLine()
            mensajeFinal.Append(mensaje)
            lblHistorialDePanicos.Text = mensajeFinal.ToString()
        End If
    End Function

    Public Class Informacion

        Private grupoValue As Integer
        Public Property Grupo() As Integer
            Get
                Return grupoValue
            End Get
            Set(ByVal Value As Integer)
                grupoValue = Value
            End Set
        End Property


        Private rutaValue As Integer
        Public Property Ruta() As Integer
            Get
                Return rutaValue
            End Get
            Set(ByVal Value As Integer)
                rutaValue = Value
            End Set
        End Property

        Private vehiculoValue As Integer
        Public Property Vehiculo() As Integer
            Get
                Return vehiculoValue
            End Get
            Set(ByVal Value As Integer)
                vehiculoValue = Value
            End Set
        End Property


        Private numeroEconomicoValue As String
        Public Property NumeroEconomico() As String
            Get
                Return numeroEconomicoValue
            End Get
            Set(ByVal Value As String)
                numeroEconomicoValue = Value
            End Set
        End Property


        Private fechaValue As Nullable(Of DateTime)
        Public Property Fecha() As Nullable(Of DateTime)
            Get
                Return fechaValue
            End Get
            Set(ByVal Value As Nullable(Of DateTime))
                fechaValue = Value
            End Set
        End Property

        Private horaSalidaPlantaValue As Nullable(Of DateTime)
        Public Property HoraSalidaPlanta() As Nullable(Of DateTime)
            Get
                Return horaSalidaPlantaValue
            End Get
            Set(ByVal Value As Nullable(Of DateTime))
                horaSalidaPlantaValue = Value
            End Set
        End Property

        Private horaIngresoRutaValue As Nullable(Of DateTime)
        Public Property HoraIngresoRuta() As Nullable(Of DateTime)
            Get
                Return horaIngresoRutaValue
            End Get
            Set(ByVal Value As Nullable(Of DateTime))
                horaIngresoRutaValue = Value
            End Set
        End Property

        Private horaPrimerSuministroValue As Nullable(Of DateTime)
        Public Property HoraPrimerSuministro() As Nullable(Of DateTime)
            Get
                Return horaPrimerSuministroValue
            End Get
            Set(ByVal Value As Nullable(Of DateTime))
                horaPrimerSuministroValue = Value
            End Set
        End Property

        Private horaUltimoSuministroValue As Nullable(Of DateTime)
        Public Property HoraUltimoSuministro() As Nullable(Of DateTime)
            Get
                Return horaUltimoSuministroValue
            End Get
            Set(ByVal Value As Nullable(Of DateTime))
                horaUltimoSuministroValue = Value
            End Set
        End Property

        Private horaUltimoPanicoValue As Nullable(Of DateTime)
        Public Property HoraUltimoPanico() As Nullable(Of DateTime)
            Get
                Return horaUltimoPanicoValue
            End Get
            Set(ByVal Value As Nullable(Of DateTime))
                horaUltimoPanicoValue = Value
            End Set
        End Property

        Private horaUltimaPosicionValue As Nullable(Of DateTime)
        Public Property HoraUltimaPosicion() As Nullable(Of DateTime)
            Get
                Return horaUltimaPosicionValue
            End Get
            Set(ByVal Value As Nullable(Of DateTime))
                horaUltimaPosicionValue = Value
            End Set
        End Property


    End Class

    Public Class GrupoCombo

        Private idGrupoValue As Integer
        Public Property IdGrupo() As Integer
            Get
                Return idGrupoValue
            End Get
            Set(ByVal Value As Integer)
                idGrupoValue = Value
            End Set
        End Property


        Private descripcionValue As String
        Public Property Descripcion() As String
            Get
                Return descripcionValue
            End Get
            Set(ByVal Value As String)
                descripcionValue = Value
            End Set
        End Property


    End Class

    Public Class RutaCombo

        Private idRutaValue As Integer
        Public Property IdRuta() As Integer
            Get
                Return idRutaValue
            End Get
            Set(ByVal Value As Integer)
                idRutaValue = Value
            End Set
        End Property


        Private descripcionValue As String
        Public Property Descripcion() As String
            Get
                Return descripcionValue
            End Get
            Set(ByVal Value As String)
                descripcionValue = Value
            End Set
        End Property


    End Class

    Public Class VehiculoCombo

        Private idVehiculoValue As Integer
        Public Property IdVehiculo() As Integer
            Get
                Return idVehiculoValue
            End Get
            Set(ByVal Value As Integer)
                idVehiculoValue = Value
            End Set
        End Property


        Private descripcionValue As String
        Public Property Descripcion() As String
            Get
                Return descripcionValue
            End Get
            Set(ByVal Value As String)
                descripcionValue = Value
            End Set
        End Property


    End Class

    Function ConsultaInformacion(ByRef Fecha As DateTime, ByRef Celula As Integer, ByRef Ruta As Integer, ByRef Autotanque As Integer) As List(Of Informacion)
        Dim lista As List(Of Informacion)
        lista = New List(Of Informacion)

        Dim connetionString As String
        Dim cnn As SqlConnection
        connetionString = Globales._ConexionGPS
        Try

            cnn = New SqlConnection(connetionString)
            cnn.Open()
            Dim command As SqlCommand
            command = New SqlCommand("spLOGConsultaTableroDePanico", cnn)
            command.CommandType = CommandType.StoredProcedure
            command.Parameters.Add("@Fecha", SqlDbType.DateTime).Value = Fecha

            If (Celula <> 0 And Celula <> Nothing) Then
                command.Parameters.Add("@Celula", SqlDbType.Int).Value = Celula
            End If

            If (Ruta <> -1 And Ruta <> Nothing) Then
                command.Parameters.Add("@Ruta", SqlDbType.Int).Value = Ruta
            End If

            If (Autotanque <> 0 And Autotanque <> Nothing) Then
                command.Parameters.Add("@Autotanque", SqlDbType.Int).Value = Autotanque
            End If

            Dim reader As SqlDataReader
            reader = command.ExecuteReader()

            While (reader.Read())
                Dim info As New Informacion()
                info.Grupo = Convert.ToInt32(reader("Grupo").ToString())
                info.Ruta = Convert.ToInt32(reader("Ruta").ToString())
                info.Vehiculo = Convert.ToInt32(reader("Vehiculo").ToString())
                info.NumeroEconomico = reader("NumeroEconomico").ToString()

                If (IsDBNull(reader("Fecha"))) Then

                Else
                    info.Fecha = Convert.ToDateTime(reader("Fecha").ToString())
                End If

                If (IsDBNull(reader("HoraSalidaPlanta"))) Then

                Else
                    info.HoraSalidaPlanta = Convert.ToDateTime(reader("HoraSalidaPlanta").ToString())
                End If


                If (IsDBNull(reader("HoraIngresoRuta"))) Then

                Else
                    info.HoraIngresoRuta = Convert.ToDateTime(reader("HoraIngresoRuta").ToString())
                End If

                If (IsDBNull(reader("HoraPrimerSuministro"))) Then

                Else
                    info.HoraPrimerSuministro = Convert.ToDateTime(reader("HoraPrimerSuministro").ToString())
                End If


                If (IsDBNull(reader("HoraUltimoSuministro"))) Then

                Else
                    info.HoraUltimoSuministro = Convert.ToDateTime(reader("HoraUltimoSuministro").ToString())
                End If


                If (IsDBNull(reader("HoraUltimoPanico"))) Then

                Else
                    info.HoraUltimoPanico = Convert.ToDateTime(reader("HoraUltimoPanico").ToString())
                End If

                If (IsDBNull(reader("HoraUltimaPosicion"))) Then

                Else
                    info.HoraUltimaPosicion = Convert.ToDateTime(reader("HoraUltimaPosicion").ToString())
                End If

                lista.Add(info)
            End While


        Catch ex As Exception
            MsgBox(ex)
            Throw
        Finally
            If (cnn.State = ConnectionState.Open) Then
                cnn.Close()
            End If
        End Try
        Return lista
    End Function

    Function ConsultarGrupos() As List(Of GrupoCombo)
        Dim lista As List(Of GrupoCombo)
        lista = New List(Of GrupoCombo)

        Dim connetionString As String
        Dim cnn As SqlConnection
        connetionString = Globales._ConexionGPS
        Try

            cnn = New SqlConnection(connetionString)
            cnn.Open()
            Dim command As SqlCommand
            command = New SqlCommand("spLOGConsultaGrupos", cnn)
            command.CommandType = CommandType.StoredProcedure

            Dim reader As SqlDataReader
            reader = command.ExecuteReader()

            While (reader.Read())
                Dim grupo As New GrupoCombo()
                grupo.IdGrupo = Convert.ToInt32(reader("IdGrupo").ToString())
                grupo.Descripcion = reader("Descripcion").ToString()
                lista.Add(grupo)
            End While
        Catch ex As Exception
            MsgBox(ex)
            Throw
        Finally
            If (cnn.State = ConnectionState.Open) Then
                cnn.Close()
            End If
        End Try
        Return lista
    End Function

    Function ConsultarRutas() As List(Of RutaCombo)
        Dim lista As List(Of RutaCombo)
        lista = New List(Of RutaCombo)

        Dim connetionString As String
        Dim cnn As SqlConnection
        connetionString = Globales._ConexionGPS
        Try

            cnn = New SqlConnection(connetionString)
            cnn.Open()
            Dim command As SqlCommand
            command = New SqlCommand("spLOGConsultaRutas", cnn)
            command.CommandType = CommandType.StoredProcedure

            Dim reader As SqlDataReader
            reader = command.ExecuteReader()

            While (reader.Read())
                Dim ruta As New RutaCombo()
                ruta.IdRuta = Convert.ToInt32(reader("IdRuta").ToString())
                ruta.Descripcion = reader("Descripcion").ToString()
                lista.Add(ruta)
            End While
        Catch ex As Exception
            MsgBox(ex)
            Throw
        Finally
            If (cnn.State = ConnectionState.Open) Then
                cnn.Close()
            End If
        End Try
        Return lista
    End Function

    Function ConsultarVehiculos() As List(Of VehiculoCombo)
        Dim lista As List(Of VehiculoCombo)
        lista = New List(Of VehiculoCombo)

        Dim connetionString As String
        Dim cnn As SqlConnection
        connetionString = Globales._ConexionGPS
        Try

            cnn = New SqlConnection(connetionString)
            cnn.Open()
            Dim command As SqlCommand
            command = New SqlCommand("spLOGConsultaVehiculos", cnn)
            command.CommandType = CommandType.StoredProcedure

            Dim reader As SqlDataReader
            reader = command.ExecuteReader()

            While (reader.Read())
                Dim vehiculo As New VehiculoCombo()
                vehiculo.IdVehiculo = Convert.ToInt32(reader("IdVehiculo").ToString())
                vehiculo.Descripcion = reader("Descripcion").ToString()
                lista.Add(vehiculo)
            End While
        Catch ex As Exception
            MsgBox(ex)
            Throw
        Finally
            If (cnn.State = ConnectionState.Open) Then
                cnn.Close()
            End If
        End Try
        Return lista
    End Function

    Private Sub btnBuscar_Click(sender As System.Object, e As System.EventArgs) Handles btnBuscar.Click
        Cursor = Cursors.WaitCursor
        LlenarGridInicial()
        VerAlertaInicial()
        timerControl.Interval = Globales._TimerInterval
        timerControl.Start()
        Cursor = Cursors.Default
    End Sub

End Class


Public Class InformacionComparer : Implements IEqualityComparer(Of Informacion)

    Public Overloads Function Equals(ByVal b1 As Informacion, ByVal b2 As Informacion) _
                   As Boolean Implements IEqualityComparer(Of Informacion).Equals
        Return b1.Vehiculo.Equals(b2.Vehiculo)
    End Function

    Public Overloads Function GetHashCode(ByVal bx As Informacion) _
                As Integer Implements IEqualityComparer(Of Informacion).GetHashCode
        Dim hCode As Integer = bx.Vehiculo
        Return hCode.GetHashCode()
    End Function

End Class
