Imports Microsoft.VisualBasic
Imports System.ComponentModel
Imports System.Data

Public Class TipUsu
    Inherits BDDatos2
    Sub New()
        Me.Tabla = "TIPousua"
        Me.Vista = "TIPousua"
    End Sub

    <DataObjectMethodAttribute(DataObjectMethodType.Select, True)> _
    Public Overrides Function GetRecords() As DataTable
        Me.Conectar()
        Me.querystring = "SELECT * FROM TIPousua"
        CrearComando(querystring)
        Dim dataTb As DataTable = EjecutarConsultaDataTable()
        Me.Desconectar()
        Return dataTb
    End Function
End Class