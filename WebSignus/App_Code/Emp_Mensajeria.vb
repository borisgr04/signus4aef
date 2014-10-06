Imports Microsoft.VisualBasic
Imports System.Data
Imports System.ComponentModel

Public Class Emp_Mensajeria
    Inherits BDDatos2

    <DataObjectMethodAttribute(DataObjectMethodType.Select, True)> _
    Public Overrides Function GetRecords() As DataTable
        Me.Conectar()
        querystring = "SELECT * FROM EMPRESA_MENSAJERIA ORDER BY DESCRIPCION"
        CrearComando(querystring)
        Dim dataTb As DataTable = EjecutarConsultaDataTable()
        Me.Desconectar()
        Return dataTb
    End Function

End Class
