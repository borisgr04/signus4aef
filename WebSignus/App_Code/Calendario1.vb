Imports Microsoft.VisualBasic

Imports System.ComponentModel
Imports System.Data
'Clase para manejar la Tabla CALENDARIO de la Base de datos
'Fecha Creaciòn: 28 dic 2009
'Autor: Ronal Javier

Public Class Calendario1
    Inherits BDDatos2
    Public Function Insert(ByVal CAL_PER As String, ByVal CAL_VIG As String, ByVal CAL_FINI As Date, ByVal CAL_FFIN As Date, ByVal CAL_CLA As String, ByVal CAL_DES As String, ByVal CAL_FVEN As Date) As String
        Dim na As Integer
        Me.Conectar()
        ComenzarTransaccion()
        Try
            Me.querystring = "INSERT INTO CALENDARIO (CAL_PER,CAL_VIG,CAL_FINI,CAL_FFIN,CAL_CLA,CAL_DES,CAL_FVEN)VALUES(:CAL_PER,:CAL_VIG,:CAL_FINI,:CAL_FFIN,:CAL_CLA,:CAL_DES,:CAL_FVEN)"
            CrearComando(querystring)
            AsignarParametroCadena(":CAL_PER", CAL_PER)
            AsignarParametroCadena(":CAL_VIG", CAL_VIG)
            AsignarParametroFecha(":CAL_FINI", CAL_FINI)
            AsignarParametroFecha(":CAL_FFIN", CAL_FFIN)
            AsignarParametroCadena(":CAL_CLA", CAL_CLA)
            AsignarParametroCadena(":CAL_DES", CAL_DES)
            AsignarParametroFecha(":CAL_FVEN", CAL_FVEN)
            'Me.usuario
            na = EjecutarComando
            Me.Msg = MsgOk + "<BR> Número de Filas Afectadas " + na.ToString
            Me.lErrorG = False
            ConfirmarTransaccion()
        Catch ex As Exception
            CancelarTransaccion()
            Me.lErrorG = True
            Me.Msg = "Error de App:" + ex.Message
        Finally
            Me.Desconectar()
        End Try
        Return Msg
    End Function
    Public Function Update(ByVal CAL_PER_OR As String, ByVal CAL_VIG_OR As String, ByVal CAL_CLA_OR As String, ByVal CAL_PER As String, ByVal CAL_VIG As String, ByVal fec_ini As Date, ByVal fec_fin As Date, ByVal CAL_CLA As String, ByVal CAL_DES As String, ByVal CAL_FVEN As Date) As String
        Dim na As String
        Me.Conectar()
        Try
            ComenzarTransaccion()
            Me.querystring = "UPDATE CALENDARIO SET CAL_PER='" + CAL_PER + "',CAL_VIG='" + CAL_VIG + "',CAL_FINI=to_date('" + fec_ini.ToShortDateString + "','dd/mm/yyyy'),CAL_FFIN=to_date('" + fec_fin.ToShortDateString + "','dd/mm/yyyy'),CAL_FVEN=to_date('" + CAL_FVEN.ToShortDateString + "','dd/mm/yyyy'),CAL_CLA='" + CAL_CLA + "',CAL_DES='" + CAL_DES + "' WHERE CAL_PER='" + CAL_PER_OR + "'AND CAL_VIG='" + CAL_VIG_OR + "' AND CAL_CLA='" + CAL_CLA_OR + "'"
            CrearComando(querystring)
            na = EjecutarComando()
            Me.Msg = MsgOk + "<BR> Registros Actualizados [" + na + "]"
            ConfirmarTransaccion()
            Me.lErrorG = False
        Catch ex As Exception
            CancelarTransaccion()
            Me.lErrorG = True
            Me.Msg = "Error de App:" + ex.Message
        Finally
            Me.Desconectar()
        End Try
        Return Msg
    End Function
    Public Function Delete(ByVal CAL_PER As String, ByVal CAL_VIG As String, ByVal CAL_CLA As String) As String
        Dim na As String
        Me.Conectar()
        Try
            ComenzarTransaccion()
            Me.querystring = "DELETE FROM CALENDARIO WHERE CAL_PER='" + CAL_PER + "' and CAL_VIG='" + CAL_VIG + "' and CAL_CLA='" + CAL_CLA + "'"
            CrearComando(querystring)
            na = EjecutarComando()
            Me.Msg = MsgOk + " # Registros Eliminados:" + na.ToString
            Me.lErrorG = False
            ConfirmarTransaccion()
        Catch ex As Exception
            CancelarTransaccion()
            Me.lErrorG = True
            Me.Msg = "Error de App:" + ex.Message
        Finally
            Me.Desconectar()
        End Try
        Return Msg
    End Function
    <DataObjectMethodAttribute(DataObjectMethodType.Select, True)> _
    Public Overrides Function GetRecords() As DataTable
        Me.Conectar()
        Dim queryString As String = "SELECT * FROM VCALENDARIODEC ORDER BY CAL_PER,CAL_VIG,CAL_CLA"
        CrearComando(queryString)
        Dim dataTb As DataTable = EjecutarConsultaDataTable()
        Me.Desconectar()
        Return dataTb
    End Function
    <DataObjectMethodAttribute(DataObjectMethodType.Select, True)> _
    Public Overrides Function GetRecords(ByVal Filtro As String) As DataTable
        Me.Conectar()
        Dim queryString As String = "SELECT * FROM VCALENDARIODEC WHERE 1=1 " & Filtro & " ORDER BY CAL_PER,CAL_VIG,CAL_CLA "
        CrearComando(queryString)
        Dim dataTb As DataTable = EjecutarConsultaDataTable()
        Me.Desconectar()
        Return dataTb
    End Function
    '
    <DataObjectMethodAttribute(DataObjectMethodType.Select, True)> _
    Public Overloads Function GetPorCod(ByVal CAL_PER As String, ByVal CAL_VIG As String, ByVal CAL_CLA As String) As DataTable
        Me.Conectar()
        Dim queryString As String = "SELECT * FROM CALENDARIO WHERE CAL_PER=:CAL_PER AND CAL_VIG=:CAL_VIG AND CAL_CLA=:CAL_CLA"
        CrearComando(queryString)
        AsignarParametroCadena(":CAL_PER", CAL_PER)
        AsignarParametroCadena(":CAL_VIG", CAL_VIG)
        AsignarParametroCadena(":CAL_CLA", CAL_CLA)
        Dim dataTb As DataTable = EjecutarConsultaDataTable()
        Me.Desconectar()
        Return dataTb
    End Function
End Class
