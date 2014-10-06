Imports Microsoft.VisualBasic
Imports System.Data
Imports System.ComponentModel
Imports System
'Clase para manejar la Tabla Formularios_Dec de la Base de datos
'Fecha Creaciòn: 07 dic 2009
'Autor: Ronal Javier

Public Class Formularios_Dec
    Inherits BDDatos2
    '---------------------------------------------------------------------------------------------------------------
    ' Funciòn Insert: Agrega datos a la tabla Tramites
    ' Parametros: TRAM_Codi : Còdigo
    '             TRAM_Nomb : nombre del parametro
    '              TRAM_RESP: Responsable
    '             TRAM_GSAN: Genera sancion
    '             TRAM_COSA: Codigo de sancion
    '             TRAM_PLAN: Plantilla

    Public Function Insert(ByVal FODE_CODI As String, ByVal FODE_CDEC As String, ByVal FODE_FOWE As String, ByVal FODE_RPTE As String, ByVal FODE_FEIN As Date, ByVal FODE_FEFI As Date, ByVal FODE_OPER As String, ByVal FODE_FOWI As String, ByVal FODE_NOMB As String, ByVal FODE_EST As String, ByVal FODE_OPVP As String, ByVal FODE_OBS As String) As String

        Dim na As Integer
        Me.Conectar()
        Try
            ComenzarTransaccion()
            Me.querystring = "INSERT INTO Formularios_Dec (FODE_CODI,FODE_CDEC,FODE_FOWE,FODE_RPTE,FODE_FEIN,FODE_FEFI,FODE_OPER,FODE_FOWI,FODE_NOMB,FODE_EST,FODE_OPVP,FODE_USAP,FODE_OBS)VALUES(:FODE_CODI,:FODE_CDEC,:FODE_FOWE,:FODE_RPTE,:FODE_FEIN,:FODE_FEFI,:FODE_OPER,:FODE_FOWI,:FODE_NOMB,:FODE_EST,:FODE_OPVP,:FODE_USAP,:FODE_OBS)"
            CrearComando(querystring)
            AsignarParametroCadena(":FODE_CODI", FODE_CODI)
            AsignarParametroCadena(":FODE_CDEC", FODE_CDEC)
            AsignarParametroCadena(":FODE_FOWE", FODE_FOWE)
            AsignarParametroCadena(":FODE_RPTE", FODE_RPTE)
            AsignarParametroFecha(":FODE_FEIN", FODE_FEIN)
            AsignarParametroFecha(":FODE_FEFI", FODE_FEFI)
            AsignarParametroCadena(":FODE_OPER", FODE_OPER)
            AsignarParametroCadena(":FODE_FOWI", FODE_FOWI)
            AsignarParametroCadena(":FODE_NOMB", FODE_NOMB)
            AsignarParametroCadena(":FODE_EST", FODE_EST)
            AsignarParametroCadena(":FODE_OPVP", FODE_OPVP)
            AsignarParametroCadena(":FODE_USAP", Me.usuario)
            AsignarParametroCadena(":FODE_OBS", FODE_OBS)

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
    ' Funciòn Actualizar: Actualiza datos a la tabla Formularios_Dec
    ' Parametros: TRAM_Codi : Còdigo
    '             TRAM_Nomb : nombre del parametro
    '              TRAM_RESP: Responsable
    '             TRAM_GSAN: Genera sancion
    '             TRAM_COSA: Codigo de sancion
    '             TRAM_PLAN: Plantilla

    Public Function Update(ByVal FODE_CODI As String, ByVal FODE_CDEC As String, ByVal FODE_FOWE As String, ByVal FODE_RPTE As String, ByVal fec_ini As Date, ByVal fec_fin As Date, ByVal FODE_OPER As String, ByVal FODE_FOWI As String, ByVal FODE_NOMb As String, ByVal FODE_EST As String, ByVal FODE_OPVP As String, ByVal FODE_OBS As String) As String
        Dim na As String
        Me.Conectar()
        Try
            ComenzarTransaccion()
            Me.querystring = "UPDATE Formularios_Dec SET FODE_OBS='" + FODE_OBS + "',FODE_CODI='" + FODE_CODI + "',FODE_CDEC='" + FODE_CDEC + "',FODE_FOWE='" + FODE_FOWE + "',FODE_RPTE='" + FODE_RPTE + "',FODE_FEIN=to_date('" + fec_ini.ToShortDateString + "','dd/mm/yyyy'),FODE_FEFI=to_date('" + fec_fin.ToShortDateString + "','dd/mm/yyyy'),FODE_OPER='" + FODE_OPER + "',FODE_FOWI='" + FODE_FOWI + "',FODE_NOMB='" + FODE_NOMb + "',FODE_EST='" + FODE_EST + "',FODE_OPVP='" + FODE_OPVP + "' WHERE FODE_CODI='" + FODE_CODI + "' "
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
    ' Funciòn Delete: Borra datos a la tabla Tramites
    ' Parametros: TRAM_Codi : Còdigo
    '             TRAM_Nomb : nombre del parametro
    '              TRAM_RESP: Responsable
    '             TRAM_GSAN: Genera sancion
    '             TRAM_COSA: Codigo de sancion
    '             TRAM_PLAN: Plantilla

    Public Function Delete(ByVal CODI As String) As String
        Dim na As String

        'If (CInt(COD) = 1) Or (CInt(COD) = 2) Or (CInt(COD) = 3) Then

        'Return "Esta Clase de Impuesto, No se puede eliminar"
        'End If
        Me.Conectar()
        Try
            ComenzarTransaccion()
            Me.querystring = "DELETE Formularios_Dec WHERE FODE_CODI='" + CODI + "'"
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
        Dim queryString As String = "SELECT * FROM vFormularios_Dec ORDER BY FODE_CODI"
        CrearComando(queryString)
        Dim dataTb As DataTable = EjecutarConsultaDataTable()
        Me.Desconectar()
        Return dataTb
    End Function

    <DataObjectMethodAttribute(DataObjectMethodType.Select, True)> _
    Public Function GetPorCDec(ByVal ClDec As String) As DataTable
        Me.Conectar()
        Dim queryString As String = "SELECT * FROM vFormularios_Dec Where FoDe_Cdec=:FODE_CODI ORDER BY FODE_CODI"
        CrearComando(queryString)
        AsignarParametroCadena(":FODE_CODI", ClDec)
        Dim dataTb As DataTable = EjecutarConsultaDataTable()
        Me.Desconectar()
        Return dataTb

    End Function
    <DataObjectMethodAttribute(DataObjectMethodType.Select, True)> _
    Public Overloads Function GetPorCod(ByVal Cod As String) As DataTable
        Me.Conectar()
        Dim queryString As String = "SELECT * FROM Formularios_Dec WHERE FODE_CODI=:FODE_CODI"
        CrearComando(queryString)
        AsignarParametroCadena(":FODE_CODI", Cod)
        Dim dataTb As DataTable = EjecutarConsultaDataTable()
        Me.Desconectar()
        Return dataTb

    End Function
End Class
