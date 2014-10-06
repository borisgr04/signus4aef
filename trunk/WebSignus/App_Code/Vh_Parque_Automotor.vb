Imports Microsoft.VisualBasic
Imports System.ComponentModel
Imports System.Data
Imports System.Data.Common

<System.ComponentModel.DataObject()> _
Public Class Vh_Parque_Automotor
    Inherits BDDatos2
    Sub New()
        Me.Tabla = "vh_parque_automotor"
        Me.Vista = "vvh_parque_automotor"
    End Sub
    '<DataObjectMethodAttribute(DataObjectMethodType.Select, True)> _
    'Public Overrides Function GetRecords(ByVal Placa As String) As DataTable
    '    Me.Conectar()
    '    querystring = "SELECT * FROM vvh_parque_automotor Where Placa=:Placa"
    '    CrearComando(querystring)
    '    AsignarParametroCadena(":Placa", Placa)
    '    Dim dataTb As DataTable = EjecutarConsultaDataTable()
    '    Me.Desconectar()
    '    Return dataTb
    'End Function


    '<DataObjectMethodAttribute(DataObjectMethodType.Select, True)> _
    'Public Overrides Function GetRecords(ByVal cFiltro As String) As DataTable
    '    Me.Conectar()
    '    cFiltro = IIf(cFiltro = "", " Where 1=0 ", " Where " + cFiltro)
    '    querystring = "SELECT * FROM vvh_parque_automotor " + cFiltro + " Order by Placa"
    '    CrearComando(querystring)
    '    Dim dataTb As DataTable = EjecutarConsultaDataTable()
    '    Me.Desconectar()
    '    Return dataTb
    'End Function

    <DataObjectMethodAttribute(DataObjectMethodType.Select, True)> _
    Public Overloads Function GetRecords(ByVal sFiltro As String) As DataTable
        Me.Conectar()
        sFiltro = IIf(String.IsNullOrEmpty(sFiltro), " Where 1=0 ", " Where " + sFiltro)
        'sFiltro = IIf(String.IsNullOrEmpty(Nro_LiqG), sFiltro, sFiltro + " And Nro_LiqG=" + Nro_LiqG)
        querystring = "SELECT * FROM vvh_parque_automotor_dl " + sFiltro + " Order by Placa"
        'Throw New Exception(querystring)
        CrearComando(querystring)
        Dim dataTb As DataTable = EjecutarConsultaDataTable()
        Me.Desconectar()
        Return dataTb
    End Function
End Class
