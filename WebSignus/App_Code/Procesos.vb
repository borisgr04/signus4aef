Imports Microsoft.VisualBasic
Imports System.Data
Imports System.Data.OleDb
Imports System.Math
Imports System.IO
Imports System.Collections.Specialized
Imports System.ComponentModel

Public Class Procesos
    Inherits BDDatos2
    <DataObjectMethodAttribute(DataObjectMethodType.Select, True)> _
    Public Function GetAforo(ByVal ClDec As String, ByVal Agravable As String, ByVal PGravable As String, ByVal Tipo_Agente As String) As DataTable

        Me.Conectar()

        Dim objcd As CDeclaraciones = New CDeclaraciones(ClDec)
        objcd.Conexion = Me.Conexion
        Dim dt As DataTable
        dt = objcd.GetFormularios_Dec(Agravable, PGravable).Tables(0)
        Dim FDCO As String
        If dt.Rows.Count > 0 Then
            FDCO = dt.Rows(0)("Fode_codi").ToString()
        Else
            FDCO = ""
        End If
        dt.Clear()
        dt.Dispose()

        Dim qs As String
        'qs = "Select CoCd_Cdec,CoCd_CoDi,CoCd_Nomb,CoCd_Impto,Fn_Ejecutar_Tarifa(CoCd_Impto,parametros) Tarifa,NVL(BaseGravable,0) BaseGravable,NVL(ValorImpuesto,0),ValorImpuesto,CoCd_Ctar "
        qs = "Select Aforo.*,Fn_Ejecutar_Tarifa(CoCd_Impto,parametros) Tarifa,NVL(BaseGravable,0) BaseGravable,NVL(ValorImpuesto,0),ValorImpuesto "
        qs += "From "
        qs += "( "
        qs += " Select  Lp.*, 0  BaseGravable,0  ValorImpuesto"
        qs += ",CASE WHEN CoCd_IsVb ='S' THEN Tarifas_Parametros(CoCd_Cdec,'" & Tipo_Agente & "',Tipo_Tar) ELSE '-' END Parametros "
        qs += " From  Conc_Cdec Lp Where cocd_fdco='" & FDCO & "' And cocd_seco='LP'  "
        'And CoCd_Tico IN('C','K',)
        qs += "Order By CoCd_Codi "
        qs += " ) Aforo"
        Msg = qs
        CrearComando(qs)
        'dbCommand.Parameters.Add("Nrad", OracleDbType.Varchar2, ParameterDirection.Input).Value = nro_rad
        Dim dataTb As DataTable = EjecutarConsultaDataTable()
        Me.Desconectar()
        Return dataTb
    End Function

    <DataObjectMethodAttribute(DataObjectMethodType.Select, True)> _
    Public Function GetLCAritmetica(ByVal DCOD As String) As DataTable

        Me.Conectar()
        Dim qs As String
        qs = "Select *  From Code_Cdec Where COde_DoAd='DELP' AND CODE_DCOD=:CODE_DCOD AND CODE_SECO='LP' Order By CODE_CODI"
        Msg = qs
        CrearComando(qs)
        AsignarParametroCadena(":CODE_DCOD", DCOD)
        Dim dataTb As DataTable = EjecutarConsultaDataTable()
        Me.Desconectar()
        Return dataTb

    End Function
    <DataObjectMethodAttribute(DataObjectMethodType.Select, True)> _
    Public Function GetLRv(ByVal DCOD As String) As DataTable

        Me.Conectar()
        Dim qs As String
        qs = "Select *  From Code_Cdec Where COde_DoAd='DELP' AND CODE_DCOD=:CODE_DCOD AND CODE_SECO='LP'"
        Msg = qs
        CrearComando(qs)
        AsignarParametroCadena(":CODE_DCOD", DCOD)
        Dim dataTb As DataTable = EjecutarConsultaDataTable()
        Me.Desconectar()
        Return dataTb

    End Function

    '
    <DataObjectMethodAttribute(DataObjectMethodType.Select, True)> _
    Public Function GetAforo(ByVal FDCO As String, ByVal Tipo_Agente As String) As DataTable

        Me.Conectar()
        Dim qs As String
        qs = "Select CoCd_Cdec,CoCd_CoDi,CoCd_Nomb,CoCd_Impto,Fn_Ejecutar_Tarifa(CoCd_Impto,parametros) Tarifa,NVL(BaseGravable,0) BaseGravable,NVL(ValorImpuesto,0),ValorImpuesto,CoCd_Ctar "
        qs += "From "
        qs += "( "
        qs += " Select  Lp.CoCd_Cdec,Lp.CoCd_CoDi,Cocd_Tico,CoCd_Nomb,CoCd_Impto, 0  BaseGravable,0  ValorImpuesto,CoCd_Ctar"
        qs += ",CASE WHEN CoCd_IsVb ='S' THEN Tarifas_Parametros(CoCd_Cdec,'" & Tipo_Agente & "',Tipo_Tar) ELSE '-' END Parametros "
        qs += " From  Conc_Cdec Lp Where cocd_fdco='" & FDCO & "' And cocd_seco='LP' And CoCd_Tico='C' "
        qs += "Order By CoCd_Codi "
        qs += " ) Aforo"
        Msg = qs
        CrearComando(qs)
        'dbCommand.Parameters.Add("Nrad", OracleDbType.Varchar2, ParameterDirection.Input).Value = nro_rad
        Dim dataTb As DataTable = EjecutarConsultaDataTable()
        Me.Desconectar()

        Return dataTb
    End Function

    <DataObjectMethodAttribute(DataObjectMethodType.Select, True)> _
    Public Overloads Function GetAforoBL(ByVal Tipo_Agente As String, Optional ByVal nro_rad As Long = 0) As DataTable
        Dim obj As BasesLiq = New BasesLiq
        Return obj.GetAforo(Tipo_Agente, nro_rad)
    End Function


    <DataObjectMethodAttribute(DataObjectMethodType.Select, True)> _
    Public Function GetProcesoHabilitados() As DataTable

        Me.Conectar()
        Dim qs As String
        qs = "Select *  From PROCESOS WHERE PROC_HAB = 'S'"
        Msg = qs
        CrearComando(qs)
        Dim dataTb As DataTable = EjecutarConsultaDataTable()
        Me.Desconectar()
        Return dataTb

    End Function

    <DataObjectMethodAttribute(DataObjectMethodType.Select, True)> _
    Public Function GetProcesoPorCodigo(ByVal PROC_CODI As String) As DataTable

        Me.Conectar()
        Dim qs As String
        qs = "Select *  From PROCESOS WHERE PROC_CODI = :PROC_CODI"
        Msg = qs
        CrearComando(qs)
        AsignarParametroCadena(":PROC_CODI", PROC_CODI)
        Dim dataTb As DataTable = EjecutarConsultaDataTable()
        Me.Desconectar()
        Return dataTb

    End Function
End Class
