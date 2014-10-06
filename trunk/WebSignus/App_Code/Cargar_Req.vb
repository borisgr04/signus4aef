Imports Microsoft.VisualBasic

Imports System.ComponentModel
Imports System.Data

Public Class Cargar_Req
    Inherits BDDatos2


    <DataObjectMethodAttribute(DataObjectMethodType.Select, True)> _
    Public Overrides Function GetRecords() As DataTable
        Me.Conectar()
        Dim queryString As String = "SELECT * FROM REQUI_DECLARACION "
        CrearComando(queryString)
        Dim dataTb As DataTable = EjecutarConsultaDataTable()
        Me.Desconectar()
        Return dataTb
    End Function

    <DataObjectMethodAttribute(DataObjectMethodType.Select, True)> _
    Public Overloads Function GetRecords(ByVal ClDec As String, ByVal Agravable As String, ByVal Pgravable As String) As DataTable
        Me.Conectar()
        Dim queryString As String = "Select * from Requi_Declaracion r where req_cldec=:req_cldec And (Select cal_fini From Calendario Where Cal_Cla=:Req_Cldec And  Cal_Vig=:Cal_Vig And Cal_Per=:Cal_Per) Between r.REQ_FINI and r.REQ_FFIN "
        CrearComando(UCase(queryString))
        AsignarParametroCadena(":REQ_CLDEC", ClDec)
        AsignarParametroCadena(":REQ_CLDEC", ClDec)
        AsignarParametroCadena(":CAL_VIG", Agravable)
        AsignarParametroCadena(":CAL_PER", Pgravable)
        Dim dataTb As DataTable = EjecutarConsultaDataTable()
        Me.Desconectar()
        Return dataTb
    End Function
End Class
