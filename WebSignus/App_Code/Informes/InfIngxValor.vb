Imports Microsoft.VisualBasic
Imports System.Data

Public Class InfIngxValor
    Inherits BDDatos2

    Public Function GetDatos(ByVal Filtro As String) As DataTable
        Dim DTtab As DataTable = New DataTable
        Me.Conectar()
        Dim cFiltro As String = IIf(Filtro <> "", " Where " + Filtro, "")
        Try
            querystring = "select v.* from  vInfDecxConc v " + cFiltro + " "
            CrearComando(querystring)
            DTtab = EjecutarConsultaDataTable()
            Me.Desconectar()
            Me.lErrorG = False
        Catch ex As Exception
            Me.lErrorG = True
            Me.Msg = "Error de App:" + ex.Message
        Finally
            Me.Desconectar()
        End Try
        Return DTtab

    End Function

End Class
