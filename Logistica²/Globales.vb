Imports System.IO

Module Globales


#Region "Variables globales"
    'Información del usuario
    Public _Celula As Integer
    Public _Usuario As String
    Public _Nombre As String
    Public _DesCelula As String
    Public _Password As String
    Public _Corporativo As Short
    Public _Sucursal As Short


    'Información de la conexión
    Public _Servidor As String
    Public _Database As String

    'Parámetros
    Public _RutaReportes As String
    Public _DiasCorreccion As Integer
    Public _MuestraAsistencia As Boolean
    Public _AsignacionLogisticos As Boolean
    Public _AsignacionSuplente As Integer
    Public _ValidaRutaExpress As Boolean
    Public _CambiarTipoProducto As Boolean
    Public _CalibracionMinima As Decimal
    Public _CalibracionMaxima As Decimal
    Public _CalibracionPrdeterminada As Decimal
    'texis'
    Public _AsignacionAutomatica As String
    ' texis _ConexionMetroTableroPanico,_ConexionHidroTableroPanico,  _TimerInterval Para Tablero Panico
    Public _ConexionGPS As String
    Public _NombrePlanta As String
    Public _TimerInterval As Integer

    'Vector de operaciones
    '1-Acceso
    '2-Modificación con status de LIQCAJA
    '3-Catálogo de autotanques
    '4-Catálogo de operadores
    '5-Eliminación en catálogos
    '6-Catálogo de logísticos
    '7-Catálogo de rutas
    '8-Pull de postureros
    '9-Catálogo de operadores de portatil
    '10-Asignación de portatil   
    '11-Ciclos automáticos
    '12-Asignación especial
    '13-Litros a crédito del operador
    '14-Asignación de tripulación
    '15-Cancelación de folios
    '16-Captura de calibración
    '17-Factor de calibración por cliente
    Public OperacionLogistica(26) As Logistica.SafeLogin.Operation

    'Conexión
    'Public cnSigamet As New SqlClient.SqlConnection(SigaMetClasses.LeeInfoConexion(True))
    Public cnSigamet As New SqlClient.SqlConnection()

    'RAF LUSATE 
    Public _SeguimientoRAF As Boolean

    '20160616#LUSATE Seguridad Reportes
    Public _SeguridadReportes As Boolean = False

    'Version Móvil GAS
    Public _versionMovilGas As Integer = 0

    'Soporte Móvil anterior
    Public _soporteMovilAnterior As Boolean = False


#End Region

#Region "Funciones y subrutinas globales"
    'Asignación de datos a un grid
    Public Sub GridData(ByRef Grid As DataGrid, ByVal Table As DataTable, Optional ByVal TableStyleIndex As Integer = -1, Optional ByVal Columns As Integer = 0)
        If CInt(Grid.Width / Table.Columns.Count) - 10 > 0 Then
            If TableStyleIndex = -1 Then
                Grid.PreferredColumnWidth = CInt(Grid.Width / Table.Columns.Count) - 20 + Table.Columns.Count
            Else
                Grid.TableStyles(TableStyleIndex).MappingName = Table.TableName
                Dim Index As Byte
                If Columns = 0 Then
                    Columns = Table.Columns.Count - 1
                End If
                For Index = 0 To CByte(Columns - 1)
                    Grid.TableStyles(TableStyleIndex).GridColumnStyles(Index).Width = CInt(Grid.Width / Columns) - 20 + Columns
                Next Index
            End If
        End If
        Grid.DataSource = Table
    End Sub
    'Busqueda en grid
    Public Function EncuentraRegistro(ByRef Grid As DataGrid, ByVal Busqueda As String, Optional ByVal Columna As Integer = 0) As Boolean
        Dim Index As Integer
        For Index = 0 To CuentaFilas(Grid)
            If Not Microsoft.VisualBasic.IsDBNull(Grid.Item(Index, Columna)) Then
                If Trim(CStr(Grid.Item(Index, Columna))).ToUpper = Trim(Busqueda).ToUpper Then
                    Grid.UnSelect(Grid.CurrentRowIndex)
                    Grid.Select(Index)
                    Grid.CurrentRowIndex = Index
                    Return True
                End If
            End If
        Next
        Return False
    End Function
    'Propiedades de un grid
    Public Function CuentaFilas(ByVal Grid As DataGrid) As Integer
        'Return CType(Grid.DataSource, DataTable).Rows.Count - 1
        Return Grid.VisibleRowCount - 1
    End Function

    Public Function CuentaColumnas(ByVal Grid As DataGrid) As Integer
        'Return CType(Grid.DataSource, DataTable).Columns.Count - 1
        Return Grid.VisibleColumnCount - 1
    End Function
    'Mensajes de error
    Public Sub ExMessage(ByVal ex As Exception)
        MessageBox.Show(ex.Message, Application.ProductName & " v." & Application.ProductVersion, MessageBoxButtons.OK, MessageBoxIcon.Error)
    End Sub
    Public Sub ErrMessage(ByVal ErrorMessage As String)
        MessageBox.Show(ErrorMessage, Application.ProductName & " v." & Application.ProductVersion, MessageBoxButtons.OK, MessageBoxIcon.Error)
    End Sub
#End Region

    Public Sub Main()
        Dim frmSplash As New frmSplash()
        'Dim frmLogin As SigaMetClasses.Seguridad
        Dim frmPrincipal As frmPrincipal
        Dim Acceso As Logistica.Updater.UpdaterResult = Updater.UpdaterResult.NotValidated
        frmSplash.ShowDialog()
        'Validación de acceso
        While Acceso = Updater.UpdaterResult.NotValidated
            Dim img As Bitmap = Nothing
            Try
                img = New Bitmap(Application.StartupPath + "\Logistica.ico")
            Catch ex As Exception
            End Try
            Dim frmAcceso As New SigametSeguridad.UI.Acceso(Application.StartupPath + "\Default.Seguridad y Administracion.exe.config", True, 6, img)

            ' frmLogin = New SigaMetClasses.Seguridad(Application.ProductName, Application.ProductVersion, Color.LightSteelBlue.Name, Image.FromFile(Application.StartupPath & "\Logistica.ico"))
            'frmLogin.ShowDialog()
            'If frmLogin.DialogResult = DialogResult.OK Then
            If frmAcceso.ShowDialog() = DialogResult.OK Then
                Dim frmLogin As New SigaMetClasses.Seguridad(6, frmAcceso.CadenaConexion, frmAcceso.Usuario.IdUsuario, frmAcceso.Usuario.ClaveDesencriptada)
                cnSigamet = frmAcceso.Conexion
                cnSigamet.ConnectionString = frmAcceso.CadenaConexion
                Acceso = ValidaAcceso(frmLogin)
                cnSigamet = frmAcceso.Conexion
                cnSigamet.ConnectionString = frmAcceso.CadenaConexion
            Else
                Application.Exit()
                Exit Sub
            End If
            'frmLogin.Dispose()
        End While
        'Ejecuta la aplicación
        If Acceso = Updater.UpdaterResult.NotNeedUpdate Then
            frmPrincipal = New frmPrincipal()
            frmPrincipal.Show()
            Application.Run(frmPrincipal)
        End If
    End Sub

    Private Function ValidaAcceso(ByVal Login As SigaMetClasses.Seguridad) As Logistica.Updater.UpdaterResult
        Dim Acceso As New Logistica.SafeLogin()
        Dim Updater As Logistica.Updater
        Dim oConfig As SigaMetClasses.cConfig
        Dim UpdateResult As Logistica.Updater.UpdaterResult
        With Login
            Try
                'Configura conexión
                'cnSigamet.ConnectionString &= "User ID=" & Trim(.UserID) & ";Password=" & .Password & _
                '                             ";Application Name=" & Application.ProductName & " Versión: " & Application.ProductVersion
                'Valida acceso
                If Not Acceso.Authorized(.UserID, .Password, 6, cnSigamet) Then
                    ErrMessage("No tiene privilegios para usar este módulo.")
                    Return Updater.UpdaterResult.RejectUpdate
                    Exit Function
                End If
                'Valida versión
                Updater = New Logistica.Updater(6, Application.ProductVersion, Application.StartupPath, cnSigamet)
                UpdateResult = Updater.Validar()
                If UpdateResult = Updater.UpdaterResult.NotNeedUpdate Then
                    'Carga privilegios
                    Acceso.GetOperation(.UserID, .Password, 6, cnSigamet, OperacionLogistica)
                    'Carga parámetros
                    _Corporativo = .Corporativo
                    _Sucursal = .Sucursal

                    oConfig = New SigaMetClasses.cConfig(6, _Corporativo, _Sucursal)
                    _Servidor = cnSigamet.DataSource
                    _Database = cnSigamet.Database
                    _Usuario = Trim(.UserID)
                    _Password = Trim(.Password)
                    _Celula = .Celula
                    _Nombre = .UsuarioNombre
                    _DesCelula = .CelulaDescripcion
                    _RutaReportes = CStr(oConfig.Parametros("RutaReportesW7"))
                    _DiasCorreccion = CInt(oConfig.Parametros("DiasCorreccion"))
                    _MuestraAsistencia = CBool(oConfig.Parametros("MostrarAsistencia"))
                    _AsignacionLogisticos = CBool(oConfig.Parametros("AsignacionLogisticos"))
                    _AsignacionSuplente = CInt(oConfig.Parametros("AsignacionSuplente"))
                    _ValidaRutaExpress = CBool(oConfig.Parametros("ValidaRutaExpress"))
                    _CambiarTipoProducto = CBool(oConfig.Parametros("CambiarTipoProducto"))
                    _CalibracionMinima = CDec(oConfig.Parametros("CalibracionMinima"))
                    _CalibracionMaxima = CDec(oConfig.Parametros("CalibracionMaxima"))
                    _CalibracionPrdeterminada = CDec(oConfig.Parametros("CalibracionPredeterminada"))
                    'texis'
                    _AsignacionAutomatica = CStr(oConfig.Parametros("AsignacionAutomatica"))
                    'texis tablero panico
                    _ConexionGPS = CStr(oConfig.Parametros("CadenaConexionGPS"))
                    _NombrePlanta = CStr(oConfig.Parametros("NombrePlanta"))
                    _TimerInterval = CStr(oConfig.Parametros("IntervaloTimer"))
                    '20160616#LUSATE Seguridad Reportes
                    _SeguridadReportes = CBool(.Parametros("SeguridadReportes"))                    
                    'Version MovilGas
                    _versionMovilGas = CInt(oConfig.Parametros("VersionMovilGas"))
                    'Soporte Móvil Anterior
                    _soporteMovilAnterior = CInt(oConfig.Parametros("SoporteMovilAnterior"))
                    'Libera objetos no utilizados
                    oConfig.Dispose()
                    Return Updater.UpdaterResult.NotNeedUpdate
                Else
                    Return UpdateResult
                End If
            Catch ex As Exception
                ExMessage(ex)
            End Try
        End With
    End Function

End Module


