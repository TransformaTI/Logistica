'''''''''''''''''''''''''''''''''''''''''''''
'   Provedor de licencia para componentes   '
'Autor: Manuel Ruiz                         '
'Fecha: 26 de marzo de 2004                 '
'Descripción: Este componenete valida la    '
'             licencia de controles en      '
'             tiempo de diseño.             '
'                                           '
'''''''''''''''''''''''''''''''''''''''''''''

Imports System.ComponentModel
Imports System.ComponentModel.LicenseProvider
Imports System.IO

Public Class ECRALicenseProvider

    Inherits LicenseProvider

    Public Overrides Function GetLicense(ByVal context As LicenseContext, ByVal typ As System.Type, ByVal instance As Object, ByVal allowExceotionas As Boolean) As License
        If context.UsageMode = LicenseUsageMode.Designtime Then
            'Código de validación
            Return New DesignTimeLicense(Me, typ)
        Else
            'Código de validación
            If Application.ProductName = "Logística²" Then
                Return New RunTimeLicense(Me, typ)
            Else
                Return Nothing
            End If
        End If
    End Function
    Public Class DesignTimeLicense
        Inherits License

        Private owner As ECRALicenseProvider
        Private typ As Type

        Sub New(ByVal owner As ECRALicenseProvider, ByVal typ As Type)
            Me.owner = owner
            Me.typ = typ
        End Sub

        Overrides ReadOnly Property LicenseKey() As String
            Get
                'Licencia
            End Get
        End Property

        Overrides Sub Dispose()

        End Sub
    End Class
    Public Class RunTimeLicense
        Inherits License

        Private owner As ECRALicenseProvider
        Private typ As Type

        Sub New(ByVal owner As ECRALicenseProvider, ByVal typ As Type)
            Me.owner = owner
            Me.typ = typ
        End Sub

        Overrides ReadOnly Property LicenseKey() As String
            Get
                'Licencia
            End Get
        End Property

        Overrides Sub Dispose()

        End Sub
    End Class
End Class
