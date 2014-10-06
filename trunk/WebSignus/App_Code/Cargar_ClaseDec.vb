
Imports Microsoft.VisualBasic

Imports System.ComponentModel
Imports System.Data


Public Class Cargar_ClaseDec
    Inherits BDDatos2


    <DataObjectMethodAttribute(DataObjectMethodType.Select, True)> _
    Public Overrides Function GetRecords() As DataTable
        Me.Conectar()
        Dim queryString As String = "SELECT CLD_COD, CLD_NOM FROM CLASE_DEC "
        CrearComando(queryString)
        Dim dataTb As DataTable = EjecutarConsultaDataTable()
        Me.Desconectar()
        Return dataTb
    End Function
End Class