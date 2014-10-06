Imports Microsoft.VisualBasic
Imports System.Data
Imports System.ComponentModel

Public Class Expe_Notif
    Inherits BDDatos2

    Public Function Insert(ByVal EXNF_FREB As String, ByVal EXNF_NOTIF As String, ByVal EXNF_MEDIO As String, ByVal EXNF_FENV As String, ByVal EXNF_REC As String, ByVal EXNF_OBS As String, ByVal EXNF_EMM As String, ByVal EXTR_NUME As String, ByVal EXTR_TRAC As String, ByVal EXTR_GUIA As String, ByVal EXTR_NFOL As String, ByVal EXTR_RTANOT As String) As String
        Dim na As String

        Me.Conectar()
        Try
            ComenzarTransaccion()
            Me.querystring = " UPDATE EXPE_NOTIF SET EXTR_EST='IN' WHERE EXTR_NUME=" + EXTR_NUME + " AND EXTR_TRAC=" + EXTR_TRAC
            CrearComando(querystring)
            na = EjecutarComando()
            
            Me.querystring = "INSERT INTO EXPE_NOTIF(EXNF_FREB, EXNF_NOTIF, EXNF_MEDIO, EXNF_FENV, EXNF_REC, EXNF_OBS, EXNF_EMM, EXTR_NUME, EXTR_GUIA, EXTR_TRAC, EXTR_USAP, EXTR_RTANOT, EXTR_NFOL, EXTR_EST ) "
            Me.querystring += " VALUES(:EXNF_FREB, :EXNF_NOTIF, :EXNF_MEDIO, :EXNF_FENV, :EXNF_REC, :EXNF_OBS, :EXNF_EMM, :EXTR_NUME, :EXTR_GUIA, :EXTR_TRAC, :USER_AP_CR, :EXTR_RTANOT, :EXTR_NFOL, :EXTR_EST  )"
            CrearComando(querystring)
            AsignarParametroFec(":EXNF_FREB", CDate(EXNF_FREB))
            AsignarParametroCadena(":EXNF_NOTIF", EXNF_NOTIF)
            AsignarParametroCadena(":EXNF_MEDIO", EXNF_MEDIO)
            AsignarParametroFec(":EXNF_FENV", CDate(EXNF_FENV))
            AsignarParametroCadena(":EXNF_REC", EXNF_REC)
            AsignarParametroCadena(":EXNF_OBS", EXNF_OBS)
            AsignarParametroCadena(":EXNF_EMM", EXNF_EMM)
            AsignarParametroCadena(":EXTR_NUME", EXTR_NUME)
            AsignarParametroCadena(":EXTR_TRAC", EXTR_TRAC)
            AsignarParametroCadena(":EXTR_GUIA", EXTR_GUIA)
            AsignarParametroCadena(":USER_AP_CR", Me.usuario)
            AsignarParametroCadena(":EXTR_RTANOT", EXTR_RTANOT)
            AsignarParametroCadena(":EXTR_NFOL", EXTR_NFOL)
            AsignarParametroCadena(":EXTR_EST", "AC")
            ' Throw New Exception(Me.vComando.CommandText)
            na = EjecutarComando()
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

    Public Function Delete(ByVal EXNF_ID As String, ByVal FECHA_ANULA As String, ByVal OBS_ANULA As String) As String

        Dim queryString As String = "ELIMINAR_EXPE_NOTIF"
        Dim na As Integer

        Try
            Me.Conectar()
            ComenzarTransaccion()
            CrearComando(queryString, CommandType.StoredProcedure)
            AsignarParametroCad("P_EXNF_ID", EXNF_ID)
            AsignarParametroFec("P_FEC_ANULA", CDate(FECHA_ANULA))
            AsignarParametroCad("P_OBS_ANULA", OBS_ANULA)
            na = EjecutarComando()
            ConfirmarTransaccion()
            lErrorG = False
            Msg = "Se realizo el Proceso"
        Catch ex As Exception
            Msg = "Error de App: " + ex.Message
            CancelarTransaccion()
            lErrorG = True
        Finally
            Me.Desconectar()
        End Try

        Return Msg
    End Function

    <DataObjectMethodAttribute(DataObjectMethodType.Select, True)> _
    Public Function GetPorId(ByVal EXNF_ID As String) As DataTable
        Dim dataTb As DataTable
        Me.Conectar()
        querystring = "SELECT * FROM VEXPE_NOTIF WHERE EXNF_ID = :EXNF_ID"
        CrearComando(querystring)
        AsignarParametroCadena(":EXNF_ID", EXNF_ID)
        dataTb = EjecutarConsultaDataTable()
        Me.Desconectar()
        Return dataTb
    End Function

    <DataObjectMethodAttribute(DataObjectMethodType.Select, True)> _
    Public Function GetFinalizada(ByVal EXTR_NUME As String, ByVal EXTR_TRAC As String) As DataTable
        Dim dataTb As DataTable
        Me.Conectar()
        querystring = "SELECT * FROM EXPE_NOTIF WHERE EXTR_NUME = :EXTR_NUME AND EXTR_TRAC = :EXTR_TRAC AND EXNF_REC = 'S'"
        CrearComando(querystring)
        AsignarParametroCadena(":EXTR_NUME", EXTR_NUME)
        AsignarParametroCadena(":EXTR_TRAC", EXTR_TRAC)
        dataTb = EjecutarConsultaDataTable()
        Me.Desconectar()
        Return dataTb
    End Function

    <DataObjectMethodAttribute(DataObjectMethodType.Select, True)> _
    Public Function GetPorExpediente(ByVal EXTR_NUME As String) As DataTable
        Dim dataTb As DataTable
        Me.Conectar()
        querystring = "select * FROM VEXPE_NOTIF where EXTR_NUME = :EXTR_NUME"
        CrearComando(querystring)
        AsignarParametroCadena(":EXTR_NUME", EXTR_NUME)
        dataTb = EjecutarConsultaDataTable()
        Me.Desconectar()
        Return dataTb
    End Function

    <DataObjectMethodAttribute(DataObjectMethodType.Select, True)> _
    Public Function GetPorExpediente(ByVal EXNF_NOTIF As String, ByVal EXNF_REC As String, ByVal EXTR_NUME As String, ByVal EXTR_TRAC As String) As DataTable
        Dim dataTb As DataTable
        Me.Conectar()
        querystring = "SELECT * FROM VEXPE_NOTIF WHERE EXNF_NOTIF = :EXNF_NOTIF AND FINALIZADO = :EXNF_REC AND EXTR_NUME = :EXTR_NUME AND EXTR_TRAC = :EXTR_TRAC"
        CrearComando(querystring)
        AsignarParametroCadena(":EXNF_NOTIF", EXNF_NOTIF)
        AsignarParametroCadena(":EXNF_REC", EXNF_REC)
        AsignarParametroCadena(":EXTR_NUME", EXTR_NUME)
        AsignarParametroCadena(":EXTR_TRAC", EXTR_TRAC)
        dataTb = EjecutarConsultaDataTable()
        Me.Desconectar()
        Return dataTb
    End Function

    Public Function GetParametrizada(ByVal codTramite As String, ByVal expeIni As String, ByVal expeFin As String, ByVal Nit As String, ByVal recibido As String) As DataTable
        Dim dataTb As DataTable
        Dim condicion As String
        Me.Conectar()
        querystring = "SELECT * FROM VEXPE_NOTIF "
        condicion = ""

        If Not String.IsNullOrEmpty(expeIni) And Not String.IsNullOrEmpty(expeFin) Then
            condicion = " WHERE EXTR_NUME BETWEEN '" + expeIni + "' AND '" + expeFin + "'"
        End If
        If Not String.IsNullOrEmpty(codTramite) Then
            If String.IsNullOrEmpty(condicion) Then
                condicion = condicion + " WHERE "
            Else
                condicion = condicion + " AND "
            End If
            condicion = condicion + "EXTR_TRAC = '" + codTramite + "'"
        End If
        If Not String.IsNullOrEmpty(Nit) Then
            If String.IsNullOrEmpty(condicion) Then
                condicion = condicion + " WHERE "
            Else
                condicion = condicion + " AND "
            End If
            condicion = condicion + "TER_NIT = '" + Nit + "'"
        End If
        If Not String.IsNullOrEmpty(recibido) Then
            If String.IsNullOrEmpty(condicion) Then
                condicion = condicion + " WHERE "
            Else
                condicion = condicion + " AND "
            End If
            condicion = condicion + "FINALIZADO = '" + recibido + "'"
        End If
        querystring = querystring + condicion
        CrearComando(querystring)
        dataTb = EjecutarConsultaDataTable()
        Me.Desconectar()
        Return dataTb
    End Function

End Class
