Imports System
'''''''''''''''''''''''''''''''''''''''''''''
'                AppSettings                '
'                                           '
'Descripción: Clase que permite la lectura y'
'             escritura de los parametros de'
'             una aplicación.               '
'Autor: Manuel Ruiz                         '
'Fecha: 2/04/2004                           '
'                                           '
'''''''''''''''''''''''''''''''''''''''''''''
Public Class AppSettings
    Private _configFileName As String 'local var to hold the config file name


    

    'Constructor
    Public Sub New(ByVal ConfigFileName As String)
        If Application.ProductName <> "Logística²" Then
            Application.Exit()
            Exit Sub
        End If
        _configFileName = ConfigFileName
        ValidateConfigFile()
    End Sub
    'Creación del archivo de configuración en caso de no existir
    Private Sub ValidateConfigFile()
        If Not IO.File.Exists(_configFileName) Then
            Dim cfgFile As New IO.StreamWriter(IO.File.Open(_configFileName, IO.FileMode.Create))
            cfgFile.WriteLine("<?xml version=""1.0"" encoding=""utf-8""?>")
            cfgFile.WriteLine("<configuration>")
            cfgFile.WriteLine("  <appSettings>")
            cfgFile.WriteLine("  </appSettings>")
            cfgFile.WriteLine("</configuration>")
            cfgFile.Close()
        End If
    End Sub
    'Lectura de parametros por medio de nombre
    Public Function GetSetting(ByVal section As String, ByVal key As String) As String
        Dim xmlSettings As New Xml.XmlDocument()
        xmlSettings.Load(_configFileName)
        Dim Node As Xml.XmlNode = xmlSettings.DocumentElement.SelectSingleNode("/configuration/appSettings/" & section & "/add[@key=""" & key & """]")
        If Not Node Is Nothing Then
            Return Node.Attributes.GetNamedItem("value").Value
        Else
            Return Nothing
        End If
    End Function
    'Escritura de parametros usando nombre y valor del mismo
    Public Sub SaveSetting(ByVal section As String, ByVal key As String, ByVal value As String)
        Dim xmlSettings As New Xml.XmlDocument()
        xmlSettings.Load(_configFileName)
        Dim Node As Xml.XmlElement = CType(xmlSettings.DocumentElement.SelectSingleNode("/configuration/appSettings/" & section _
                                        & "/add[@key=""" & key & """]"), Xml.XmlElement)
        If Not Node Is Nothing Then
            Node.Attributes.GetNamedItem("value").Value = value
        Else
            Node = xmlSettings.CreateElement("add")
            Node.SetAttribute("key", key)
            Node.SetAttribute("value", value)


            Dim Root As Xml.XmlNode = xmlSettings.DocumentElement.SelectSingleNode("/configuration/appSettings/" & section)

            If Not Root Is Nothing Then
                Root.AppendChild(Node)
            Else
                Try
                    Root = xmlSettings.DocumentElement.SelectSingleNode("/configuration")
                    Root.AppendChild(xmlSettings.CreateElement("appSettings"))
                    Root = xmlSettings.DocumentElement.SelectSingleNode("/configuration/appSettings")
                    Root.AppendChild(xmlSettings.CreateElement(section))
                    Root = xmlSettings.DocumentElement.SelectSingleNode("/configuration/appSettings/" & section)
                    Root.AppendChild(Node)
                Catch ex As Exception
                    Throw New Exception("Could not set value", ex)
                End Try
            End If
        End If

        xmlSettings.Save(_configFileName)
    End Sub
End Class