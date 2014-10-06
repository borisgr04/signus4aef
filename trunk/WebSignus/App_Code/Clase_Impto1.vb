Imports Microsoft.VisualBasic

Imports System.ComponentModel
Imports System.Data
'Clase para manejar la Tabla Clase_Impto de la Base de datos
'Fecha Creaciòn: 05 ene 2010
'Autor: Ronal Javier

Public Class Clase_Impto1
    Inherits BDDatos2
    Public Function Insert(ByVal CLIM_CODI As String, ByVal CLIM_NOMB As String, ByVal CLIM_FEIN As Date, ByVal CLIM_FEFI As Date) As String
        Dim na As Integer
        Me.Conectar()
        Try
            ComenzarTransaccion()
            Me.querystring = "INSERT INTO Clase_Impto (CLIM_CODI,CLIM_NOMB,CLIM_FEIN,CLIM_FEFI)VALUES(:CLIM_CODI,:CLIM_NOMB,:CLIM_FEIN,:CLIM_FEFI)"
            CrearComando(querystring)
            AsignarParametroCadena(":CLIM_CODI", CLIM_CODI)
            AsignarParametroCadena(":CLIM_NOMB", CLIM_NOMB)
            AsignarParametroFecha(":CLIM_FEIN", CLIM_FEIN)
            AsignarParametroFecha(":CLIM_FEFI", CLIM_FEFI)

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
    Public Function Update(ByVal CLIM_CODI_or As String, ByVal CLIM_CODI As String, ByVal CLIM_NOMB As String, ByVal fec_ini As Date, ByVal fec_fin As Date) As String
        Dim na As String
        Me.Conectar()
        Try
            ComenzarTransaccion()
            Me.querystring = "UPDATE Clase_Impto SET CLIM_CODI='" + CLIM_CODI + "',CLIM_NOMB='" + CLIM_NOMB + "',CLIM_FEIN=to_date('" + fec_ini.ToShortDateString + "','dd/mm/yyyy'),CLIM_FEFI=to_date('" + fec_fin.ToShortDateString + "','dd/mm/yyyy')WHERE CLIM_CODI='" + CLIM_CODI_or + "'"
            CrearComando(querystring)
            na = EjecutarComando()
            Me.Msg = MsgOk + "<BR> Registros Actualizados [" + na + "]"
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
    Public Function Delete(ByVal CLIM_CODI As String) As String
        Dim na As String

        Me.Conectar()
        Try
            ComenzarTransaccion()

            Me.querystring = "DELETE Clase_Impto WHERE CLIM_CODI='" + CLIM_CODI + "'"
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
        Dim queryString As String = "SELECT * FROM Clase_Impto ORDER BY CLIM_CODI"
        CrearComando(queryString)
        Dim dataTb As DataTable = EjecutarConsultaDataTable()
        Me.Desconectar()
        Return dataTb
    End Function
    <DataObjectMethodAttribute(DataObjectMethodType.Select, True)> _
    Public Overloads Function GetPorCod(ByVal CLIM_CODI As String) As DataTable
        Me.Conectar()
        Dim queryString As String = "SELECT * FROM Clase_Impto WHERE CLIM_CODI=:CLIM_CODI"
        CrearComando(queryString)
        AsignarParametroCadena(":CLIM_CODI", CLIM_CODI)
        Dim dataTb As DataTable = EjecutarConsultaDataTable()
        Me.Desconectar()
        Return dataTb
    End Function
End Class
