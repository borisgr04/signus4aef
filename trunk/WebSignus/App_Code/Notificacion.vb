Imports Microsoft.VisualBasic
Imports System.Data
Imports System.ComponentModel

Public Class Notificacion
    Inherits BDDatos2

    <DataObjectMethodAttribute(DataObjectMethodType.Select, True)> _
    Public Overrides Function GetRecords() As DataTable
        Me.Conectar()
        querystring = "SELECT * FROM CLASE_NOTIFICACION ORDER BY COD_NOTIFICACION"
        CrearComando(querystring)
        Dim dataTb As DataTable = EjecutarConsultaDataTable()
        Me.Desconectar()
        Return dataTb
    End Function

End Class
