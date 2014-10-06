Imports Microsoft.VisualBasic
Imports System.Data
Imports System.ComponentModel

Public Class Unidades
    Inherits BDDatos2
    <DataObjectMethodAttribute(DataObjectMethodType.Select, True)> _
    Public Overrides Function GetRecords() As DataTable
        Me.Conectar()
        Dim queryString As String = "SELECT * FROM UNIDAD ORDER BY UNI_NOM"
        CrearComando(queryString)
        Dim dataTb As DataTable = EjecutarConsultaDataTable()
        Me.Desconectar()
        Return dataTb

    End Function

End Class
