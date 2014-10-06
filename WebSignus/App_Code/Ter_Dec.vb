Imports Microsoft.VisualBasic
Imports System.Data
Imports System.ComponentModel
Imports System

Public Class Ter_Dec
    Inherits BDDatos2

    <DataObjectMethodAttribute(DataObjectMethodType.Select, True)> _
    Public Overloads Function GetPorTerDec(ByVal TEDE_TNIT As String, ByVal TEDE_CDEC As String) As DataTable

        Me.Conectar()
        Me.querystring = "SELECT * FROM TER_DEC WHERE TEDE_TNIT = :TEDE_TNIT AND TEDE_CDEC = :TEDE_CDEC"
        CrearComando(querystring)
        AsignarParametroCadena(":TEDE_TNIT", TEDE_TNIT)
        AsignarParametroCadena(":TEDE_CDEC", TEDE_CDEC)
        Dim dataTb As DataTable = EjecutarConsultaDataTable()
        Me.Desconectar()
        Return dataTb

    End Function
End Class
