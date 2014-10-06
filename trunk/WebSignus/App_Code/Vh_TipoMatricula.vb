Imports Microsoft.VisualBasic
Imports System.ComponentModel
Imports System.Data

Public Class Vh_TipoMatricula
    Inherits BDDatos2
    <DataObjectMethodAttribute(DataObjectMethodType.Select, True)> _
Public Overrides Function GetRecords() As DataTable
        Me.Conectar()
        Me.querystring = "SELECT * FROM VH_TIPO_MATRICULA"
        CrearComando(querystring)
        Dim dataTb As DataTable = EjecutarConsultaDataTable()

        Me.Desconectar()
        Return dataTb

    End Function
End Class
