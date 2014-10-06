Imports Microsoft.VisualBasic
Imports System.Data
Imports System.ComponentModel
Imports System.Collections.Generic

Public Class Proc_Lote
    Inherits BDDatos2

    Public Function Insert(ByVal P_NPROCESO As String, ByVal P_TRAMITE As String, ByVal P_PROCESO As String, ByVal P_IMPUESTO As String) As String
        Dim na As Integer
        Me.Conectar()
        ComenzarTransaccion()
        Try
            querystring = "INSERT INTO PROC_LOTE (PRLT_NUM, PRLT_TRAM, PRLT_PROC, PRLT_CDEC) VALUES (:P_NPROCESO, :P_TRAMITE, :P_PROCESO, :P_IMPUESTO)"
            CrearComando(querystring)
            AsignarParametroCadena(":P_NPROCESO", P_NPROCESO)
            AsignarParametroCadena(":P_TRAMITE", P_TRAMITE)
            AsignarParametroCadena(":P_PROCESO", P_PROCESO)
            AsignarParametroCadena(":P_IMPUESTO", P_IMPUESTO)
            na = EjecutarComando()
            ConfirmarTransaccion()
            Me.lErrorG = False
            Me.Msg = MsgOk + "<BR> Número de Filas Afectadas " + na.ToString
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
    Public Function GetPorNumero(ByVal PRLT_NUM As String) As DataTable
        Dim dtConsulta As New DataTable
        Me.Conectar()
        Me.querystring = "SELECT * FROM VPROC_LOTE WHERE PRLT_NUM = :PRLT_NUM ORDER BY PRLT_TRAM DESC"
        CrearComando(querystring)
        AsignarParametroCadena(":PRLT_NUM", PRLT_NUM)
        dtConsulta = EjecutarConsultaDataTable()
        Me.Desconectar()
        Return dtConsulta
    End Function

    <DataObjectMethodAttribute(DataObjectMethodType.Select, True)> _
    Public Function GetPorID(ByVal PRLT_NUM As String, ByVal PRLT_TRAM As String) As DataTable
        Dim dtConsulta As New DataTable
        Me.Conectar()
        Me.querystring = "SELECT * FROM VPROC_LOTE WHERE PRLT_NUM = :PRLT_NUM AND PRLT_TRAM = :PRLT_TRAM ORDER BY PRLT_TRAM DESC "
        CrearComando(querystring)
        AsignarParametroCadena(":PRLT_NUM", PRLT_NUM)
        AsignarParametroCadena(":PRLT_TRAM", PRLT_TRAM)
        dtConsulta = EjecutarConsultaDataTable()
        Me.Desconectar()
        Return dtConsulta
    End Function

    <DataObjectMethodAttribute(DataObjectMethodType.Select, True)> _
    Public Function GetUltimoTramite(ByVal PRLT_NUM As String) As DataTable
        Dim dtConsulta As New DataTable
        Me.Conectar()
        Me.querystring = "SELECT * FROM VPROC_LOTE WHERE PRLT_NUM = :PRLT_NUM AND PRLT_FREG = (SELECT MAX(PRLT_FREG) FROM VPROC_LOTE WHERE PRLT_NUM = :PRLT_NUM) "
        CrearComando(querystring)
        AsignarParametroCadena(":PRLT_NUM", PRLT_NUM)
        dtConsulta = EjecutarConsultaDataTable()
        Me.Desconectar()
        Return dtConsulta
    End Function

    Public Function UpdateDocumento(ByVal PRLT_PLAN As [Byte](), ByVal PRLT_DOC As [Byte](), ByVal PRLT_PDF As [Byte](), ByVal PRLT_NUM As String) As String
        Dim na As Integer
        Me.Conectar()
        ComenzarTransaccion()
        Try
            Me.querystring = "UPDATE PROC_LOTE SET PRLT_DOC = :PRLT_DOC, PRLT_PDF = :PRLT_PDF, PRLT_PLAN = :PRLT_PLAN WHERE PRLT_NUM = :PRLT_NUM"
            CrearComando(querystring)
            AsignarParametroBLOB(":PRLT_DOC", PRLT_DOC)
            AsignarParametroBLOB(":PRLT_PDF", PRLT_PDF)
            AsignarParametroBLOB(":PRLT_PLAN", PRLT_PLAN)
            AsignarParametroCadena(":PRLT_NUM", PRLT_NUM)
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

    Public Function UpdateDocumentoNull(ByVal PRLT_NUM As String) As String
        Dim na As Integer
        Me.Conectar()
        ComenzarTransaccion()
        Try
            Me.querystring = "UPDATE PROC_LOTE SET PRLT_DOC = NULL WHERE PRLT_NUM = :PRLT_NUM"
            CrearComando(querystring)
            AsignarParametroCadena(":PRLT_NUM", PRLT_NUM)
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

    Public Function InsertSiguienteTramite(ByVal PRLT_NUM As String, ByVal TRAM_ANT As String, ByVal TRAM_ACT As String, ByVal NUM_DOC As String) As String
        Dim oExp As New Expedientes
        Dim dtConsulta As New DataTable
        Dim consecutivo As Integer
        consecutivo = CInt(NUM_DOC)
        dtConsulta = oExp.GetPorProceso(PRLT_NUM)
        For i As Integer = 0 To dtConsulta.Rows.Count - 1
            Dim oExpTram As New Expe_Tram
            oExpTram.Insert(dtConsulta.Rows(i)("EXPE_NUME"), TRAM_ANT, TRAM_ACT, consecutivo.ToString, "")
            consecutivo = consecutivo + 1
            If oExpTram.lErrorG Then
                lErrorG = True
                Msg = oExpTram.Msg
                Exit For
            End If
        Next
        dtConsulta = GetPorID(PRLT_NUM, TRAM_ANT)
        If lErrorG = False Then
            Insert(PRLT_NUM, TRAM_ACT, dtConsulta.Rows(0)("PRLT_PROC").ToString, dtConsulta.Rows(0)("PRLT_CDEC").ToString)
        End If
        Return Msg
    End Function

End Class
