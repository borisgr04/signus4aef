Imports Microsoft.VisualBasic
Imports System.ComponentModel
Imports System.Data

Public Class TTerc
    Inherits BDDatos2

    <DataObjectMethodAttribute(DataObjectMethodType.Select, True)> _
    Public Overrides Function GetRecords() As DataTable
        Me.Conectar()
        
        querystring = "SELECT * FROM TIPO_AGENT order by tag_cod"
        CrearComando(querystring)
        Dim dataTb As DataTable = EjecutarConsultaDataTable()
        Me.Desconectar()
        Return dataTb
    End Function
End Class