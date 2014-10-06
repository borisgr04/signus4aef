Imports Microsoft.VisualBasic
Imports System.ComponentModel
Imports System.Data

Public Class TipCod
    Inherits BDDatos2
    Sub New()
        Me.Tabla = "TDOC_IDE"
        Me.Vista = "TDOC_IDE"
    End Sub
    <DataObjectMethodAttribute(DataObjectMethodType.Select, True)> _
    Public Overrides Function GetRecords() As DataTable
        Me.Conectar()
        querystring = "SELECT * FROM TDOC_IDE"
        CrearComando(querystring)
        Dim dataTb As DataTable = EjecutarConsultaDataTable()
        Me.Desconectar()
        Return dataTb
    End Function
End Class
