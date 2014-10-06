Imports Microsoft.VisualBasic

Public Class EjemploPropiedades
    
End Class
'Ejemplo de Propiedades
Public Class sisPerfil

    Private nameValue As String
    Private numberValue As Integer

    Public Property Name() As String
        Get
            Return nameValue
        End Get
        Set(ByVal value As String)
            nameValue = value
        End Set
    End Property

    Public Property Number() As Integer
        Get
            Return numberValue
        End Get
        Set(ByVal value As Integer)
            numberValue = value
        End Set
    End Property
End Class
