Imports Microsoft.VisualBasic
Imports System.ComponentModel
Imports System.Data
Imports System.Data.Common

Public Class Expe_Tram
    Inherits BDDatos2

    Property Id_Ult_Tramite As String
    Property lst As List(Of Ent_Rsancion)
    Property oTram_Sancion As Ent_TRSan
    Public Function Insert(ByVal NumExpe As String, ByVal Tramite_Ant As String, ByVal Tramite_Act As String, _
                           ByVal numDocumento As String, ByVal observacion As String) As String

        Dim queryString As String = "FN_NUEVO_EXPE_TRAM"
        Dim na As Integer
        Try
            Me.Conectar()
            ComenzarTransaccion()
            If lErrorG = False Then
                CrearComando(queryString, CommandType.StoredProcedure)
                Dim preturn As DbParameter = AsignarParametroReturn(20)
                AsignarParametroCad("P_TRAMITE_ANT", Tramite_Ant)
                AsignarParametroCad("P_TRAMITE_ACT", Tramite_Act)
                AsignarParametroCad("P_NUM_EXPE", NumExpe)
                AsignarParametroCad("P_NUM_DOC", numDocumento)
                AsignarParametroCad("P_OBSERVACION", observacion)
                AsignarParametroCad("P_USUARIO_AP", Membership.GetUser().UserName)
                na = EjecutarComando()
                Id_Ult_Tramite = preturn.Value.ToString()
                If Tramite_Act = "010105" Then
                    Insert_TramRsancion(oTram_Sancion)
                End If
                If Not lst Is Nothing Then
                    Insert_Rsancion(lst)
                End If
            Else
                lErrorG = True
            End If
            ConfirmarTransaccion()
            lErrorG = False
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
    Public Function Insert_TramRsancion(ByVal oTram_San As Ent_TRSan) As Integer
        Dim na As Integer = 0
        querystring = "INSERT INTO TRAM_RSANCION(TRSAN_NEXPE, TRSAN_NIT, TRSAN_IDTRAM,  TRSAN_CONSIDERANDOS, TRSAN_FEC,  TRSAN_USAP,  TRSAN_USBD ) VALUES (:TRSAN_NEXPE, :TRSAN_NIT, :TRSAN_IDTRAM, :TRSAN_CONSIDERANDOS, SYSDATE, :TRSAN_USAP,  USER )"
        Me.CrearComando(querystring)
        Me.AsignarParametroCadena(":TRSAN_NEXPE", oTram_San.TRSAN_NEXPE)
        Me.AsignarParametroCadena(":TRSAN_NIT", oTram_San.TRSAN_NIT)
        Me.AsignarParametroInt(":TRSAN_IDTRAM", Me.Id_Ult_Tramite)
        Me.AsignarParametroCadena(":TRSAN_CONSIDERANDOS", oTram_San.TRSAN_CONSIDERANDOS)
        Me.AsignarParametroCadena(":TRSAN_USAP", Me.getUsuario)
        na = Me.EjecutarComando()
        Return na
    End Function
    <DataObjectMethodAttribute(DataObjectMethodType.Select, True)> _
    Public Function Insert_RSancion(ByVal lst As List(Of Ent_Rsancion)) As Integer
        Dim na As Integer = 0
        For Each obSan As Ent_Rsancion In lst
            querystring = "INSERT INTO EXPE_RSAN( EXRSAN_NEXPE,  EXRSAN_NIT,  EXRSAN_AGRAV,  EXRSAN_PGRAV,  EXRSAN_VULTDEC,  EXRSAN_VINGPER,  EXRSAN_VBASE,  EXRSAN_IDTRAM,  EXRSAN_USAP,  EXRSAN_USBD,  EXRSAN_FREG,  EXRSAN_EST,  EXRSAN_ID, EXRSAN_CDEC ) VALUES (:EXRSAN_NEXPE, :EXRSAN_NIT, :EXRSAN_AGRAV, :EXRSAN_PGRAV, :EXRSAN_VULTDEC, :EXRSAN_VINGPER, :EXRSAN_VBASE, :EXRSAN_IDTRAM, :EXRSAN_USAP,  USER, SYSDATE, 'AC', :EXRSAN_ID, :EXRSAN_CDEC)"
            Me.CrearComando(querystring)
            Me.AsignarParametroCadena(":EXRSAN_NEXPE", obSan.EXRSAN_NEXPE)
            Me.AsignarParametroCadena(":EXRSAN_NIT", obSan.EXRSAN_NIT)
            Me.AsignarParametroCadena(":EXRSAN_AGRAV", obSan.EXRSAN_AGRAV)
            Me.AsignarParametroCadena(":EXRSAN_PGRAV", obSan.EXRSAN_PGRAV)
            Me.AsignarParametroNumber(":EXRSAN_VULTDE", obSan.EXRSAN_VULTDEC)
            Me.AsignarParametroNumber(":EXRSAN_VINGPER", obSan.EXRSAN_VINGPER)
            Me.AsignarParametroNumber(":EXRSAN_VBASE", obSan.EXRSAN_VBASE)
            Me.AsignarParametroCadena(":EXRSAN_IDTRAM", obSan.EXRSAN_IDTRAM)
            Me.AsignarParametroCadena(":EXRSAN_USAP", Me.getUsuario)
            Me.AsignarParametroInt(":EXRSAN_ID", Me.Id_Ult_Tramite)
            Me.AsignarParametroInt(":EXRSAN_CDEC", obSan.EXRSAN_CDEC)
            na = Me.EjecutarComando()
        Next
        Return na
    End Function

    Public Function UpdateDocumento(ByVal EXTR_PLAN As [Byte](), ByVal EXTR_DOC As [Byte](), ByVal EXTR_PDF As [Byte](), ByVal EXTR_ID As String) As String
        Dim na As Integer
        Me.Conectar()
        ComenzarTransaccion()
        Try
            Me.querystring = "UPDATE EXPE_TRAM SET EXTR_DOC = :EXTR_DOC, EXTR_PLAN = :EXTR_PLAN, EXTR_PDF = :EXTR_PDF WHERE EXTR_ID = :EXTR_ID"
            CrearComando(querystring)
            AsignarParametroBLOB(":EXTR_DOC", EXTR_DOC)
            AsignarParametroBLOB(":EXTR_PLAN", EXTR_PLAN)
            AsignarParametroBLOB(":EXTR_PDF", EXTR_PDF)
            AsignarParametroNumber(":EXTR_ID", EXTR_ID)
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

    Public Function UpdateDocumentoNull(ByVal EXTR_ID As String) As String
        Dim na As Integer
        Me.Conectar()
        ComenzarTransaccion()
        Try
            Me.querystring = "UPDATE EXPE_TRAM SET EXTR_DOC = NULL WHERE EXTR_ID = :EXTR_ID"
            CrearComando(querystring)
            AsignarParametroNumber(":EXTR_ID", EXTR_ID)
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

    Public Function UpdateDatos(ByVal EXTR_DATO1 As String, ByVal EXTR_ID As String) As String
        Dim na As Integer
        Me.Conectar()
        ComenzarTransaccion()
        Try
            Me.querystring = "UPDATE EXPE_TRAM SET EXTR_DATO1 = :EXTR_DATO1 WHERE EXTR_ID = :EXTR_ID"
            CrearComando(querystring)
            AsignarParametroCadena(":EXTR_DATO1", EXTR_DATO1)
            AsignarParametroCadena(":EXTR_ID", EXTR_ID)
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



    Public Function Delete(ByVal EXTR_ID As String, ByVal FECHA_ANULA As String, ByVal OBS_ANULA As String) As String

        Dim queryString As String = "ELIMINAR_EXPE_TRAM"
        Dim na As Integer

        Try
            Me.Conectar()
            ComenzarTransaccion()
            CrearComando(queryString, CommandType.StoredProcedure)
            AsignarParametroCad("P_EXTR_ID", EXTR_ID)
            AsignarParametroFecha("P_FEC_ANULA", CDate(FECHA_ANULA))
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
    Public Function GetPorId(ByVal EXTR_ID As String) As DataTable
        Dim dataTb As New DataTable
        Me.Conectar()
        Me.querystring = "select * from EXPE_TRAM WHERE EXTR_ID = :EXTR_ID"
        CrearComando(querystring)
        AsignarParametroCadena(":EXTR_ID", EXTR_ID)
        dataTb = EjecutarConsultaDataTable()
        Me.Desconectar()
        Return dataTb
    End Function

    <DataObjectMethodAttribute(DataObjectMethodType.Select, True)> _
    Public Function GetPorNumExpe(ByVal numExpediente As String) As DataTable
        Dim dataTb As New DataTable
        Me.Conectar()
        Me.querystring = "select * from VEXPE_TRAM WHERE EXTR_NUME = :EXTR_NUME order by extr_id"
        CrearComando(querystring)
        AsignarParametroCadena(":EXTR_NUME", numExpediente)
        dataTb = EjecutarConsultaDataTable()
        Me.Desconectar()
        Return dataTb
    End Function

    <DataObjectMethodAttribute(DataObjectMethodType.Select, True)> _
    Public Function GetTramiteRelacion(ByVal tramiteDesde As String) As DataTable
        Dim dataTb As New DataTable
        Me.Conectar()
        Me.querystring = "SELECT * FROM VTRAMRELA WHERE TRRE_DESD =:TRRE_DESD"
        CrearComando(querystring)
        AsignarParametroCadena(":TRRE_DESD", tramiteDesde)
        dataTb = EjecutarConsultaDataTable()
        Me.Desconectar()

        Return dataTb
    End Function

    Public Function TieneNotifRemLiq(ByVal nexpediente As String) As Boolean
        Dim dataTb As New DataTable
        Dim TieneNotif As Boolean = False
        Me.Conectar()
        Me.querystring = "SELECT COUNT(*) as cant FROM EXPE_NOTIF WHERE EXTR_NUME=" + nexpediente
        CrearComando(querystring)
        dataTb = EjecutarConsultaDataTable()
        Me.Desconectar()
        If dataTb.Rows(0)("cant") > 0 Then
            TieneNotif = True
        End If
        Return TieneNotif
    End Function


    
End Class
