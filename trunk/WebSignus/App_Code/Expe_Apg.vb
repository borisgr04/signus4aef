Imports Microsoft.VisualBasic
Imports System.Data
Imports System.ComponentModel
Imports System.Collections.Generic
Imports Oracle.DataAccess.Client

Public Class Expe_Apg
    Inherits BDDatos2

    Public Function Insert(ByVal NumExpe As String, ByVal P_PGRA As String, ByVal P_AGRA As String, _
                           ByVal impuesto As String, ByVal observacion As String, ByVal sujetoImpto As String) As String

        Dim queryString As String = "NUEVO_EXPE_APG"
        Dim na As Integer

        Try
            Me.Conectar()
            ComenzarTransaccion()
            If lErrorG = False Then
                CrearComando(queryString, CommandType.StoredProcedure)
                AsignarParametroCad("P_AGRA", P_AGRA)
                AsignarParametroCad("P_PGRA", P_PGRA)
                AsignarParametroCad("P_NUM_EXPE", NumExpe)
                AsignarParametroCad("P_IMPUESTO", impuesto)
                AsignarParametroCad("P_OBSERVACION", observacion)
                AsignarParametroCad("P_USUARIO_AP", Membership.GetUser().UserName)
                AsignarParametroCad("P_SUJETO_IMPTO", sujetoImpto)
                na = EjecutarComando()
            Else
                lErrorG = True
            End If
            lErrorG = False
            ConfirmarTransaccion()
        Catch ex As Exception
            lErrorG = True
            Msg = "Error de App: " + ex.Message
            CancelarTransaccion()
        Finally
            Me.Desconectar()
        End Try

        Return Msg
    End Function

    Public Function Delete(ByVal EXAP_NUME As String, ByVal EXAP_AGRA As String, ByVal EXAP_PGRA As String, ByVal FECHA_ANULA As String, ByVal OBS_ANULA As String) As String

        Dim queryString As String = "ELIMINAR_EXPE_APG"
        Dim na As Integer

        Try
            Me.Conectar()
            ComenzarTransaccion()
            CrearComando(queryString, CommandType.StoredProcedure)
            AsignarParametroCad("EXAP_NUME", EXAP_NUME)
            AsignarParametroCad("EXAP_AGRA", EXAP_AGRA)
            AsignarParametroCad("EXAP_PGRA", EXAP_PGRA)
            AsignarParametroCad("P_FEC_ANULA", FECHA_ANULA)
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

    Public Function UpdateNumLiquidacion(ByVal EXAP_DCOD As String, ByVal EXAP_NUME As String, ByVal EXAP_AGRA As String, ByVal EXAP_PGRA As String, ByVal EXPE_CDEC As String) As String
        Dim na As Integer
        Me.Conectar()
        ComenzarTransaccion()
        Try
            Me.querystring = "UPDATE EXPE_APG SET EXAP_DCOD = :EXAP_DCOD WHERE EXAP_NUME = :EXAP_NUME AND EXAP_AGRA = :EXAP_AGRA AND EXAP_PGRA = :EXAP_PGRA AND EXPE_CDEC = :EXPE_CDEC"
            CrearComando(querystring)
            AsignarParametroCadena(":EXAP_DCOD", EXAP_DCOD)
            AsignarParametroCadena(":EXAP_NUME", EXAP_NUME)
            AsignarParametroCadena(":EXAP_AGRA", EXAP_AGRA)
            AsignarParametroCadena(":EXAP_PGRA", EXAP_PGRA)
            AsignarParametroCadena(":EXPE_CDEC", EXPE_CDEC)
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

    Public Function ExistePeriodoEnExpediente(ByVal Periodo As String, ByVal Vigencia As String, ByVal Impuesto As String, ByVal NumExpediente As String) As Boolean

        Dim queryString As String = "SELECT EXAP_NUME FROM EXPE_APG WHERE EXAP_NUME = :EXAP_NUME AND EXPE_CDEC = :EXPE_CDEC AND EXAP_AGRA = :EXAP_AGRA AND EXAP_PGRA = :EXAP_PGRA AND EXAP_ESTA <> 'AC'"
        Dim ok As Boolean
        ok = False

        Me.Conectar()
        CrearComando(queryString)
        AsignarParametroCadena(":EXAP_AGRA", Vigencia)
        AsignarParametroCadena(":EXAP_PGRA", Periodo)
        AsignarParametroCadena(":EXPE_CDEC", Impuesto)
        AsignarParametroCadena(":EXAP_NUME", NumExpediente)
        Dim datat As DataTable = EjecutarConsultaDataTable()
        Me.Desconectar()
        If datat.Rows.Count > 0 Then
            ok = True
            Me.Doc = datat.Rows(0)("EXAP_NUME").ToString
        End If

        Return ok
    End Function

    Public Function ExistePeriodosEnExpediente(ByVal Periodos As List(Of String), ByVal Vigencia As String, ByVal Impuesto As String, ByVal Nit As String) As Boolean

        Dim queryString As String = "SELECT * FROM VEXPE_APG WHERE EXAP_PGRA IN (:EXAP_PGRA) AND EXAP_AGRA = :EXAP_AGRA AND EXPE_NIT = :EXPE_NIT AND EXPE_CDEC = :EXPE_CDEC AND EXAP_ESTA = 'AC'"
        Dim ok As Boolean
        ok = False
        Dim Periodo As String
        Periodo = ""
        For i As Integer = 0 To Periodos.Count
            If String.IsNullOrEmpty(Periodo) Then
                Periodo = Periodos(i)
            Else
                Periodo = Periodo + ", " + Periodos(i)
            End If
        Next
        Me.Conectar()
        CrearComando(queryString)
        AsignarParametroCadena(":EXAP_AGRA", Vigencia)
        AsignarParametroCadena(":EXAP_PGRA", Periodo)
        AsignarParametroCadena(":EXPE_CDEC", Impuesto)
        AsignarParametroCadena(":EXPE_NIT", Nit)
        Dim datat As DataTable = EjecutarConsultaDataTable()
        Me.Desconectar()
        If datat.Rows.Count > 0 Then
            ok = True
            Me.Doc = datat.Rows(0)("EXAP_NUME").ToString
        End If

        Return ok
    End Function

    Public Function ExistePeriodosEnExpediente(ByVal Periodo As String, ByVal Vigencia As String, ByVal Impuesto As String, ByVal Nit As String) As Boolean

        Dim queryString As String = "SELECT * FROM VEXPE_APG WHERE EXAP_PGRA = :EXAP_PGRA AND EXAP_AGRA = :EXAP_AGRA AND EXPE_NIT = :EXPE_NIT AND EXPE_CDEC = :EXPE_CDEC AND EXAP_ESTA = 'AC'"
        Dim ok As Boolean
        ok = False
        Me.Conectar()
        CrearComando(queryString)
        AsignarParametroCadena(":EXAP_AGRA", Vigencia)
        AsignarParametroCadena(":EXAP_PGRA", Periodo)
        AsignarParametroCadena(":EXPE_CDEC", Impuesto)
        AsignarParametroCadena(":EXPE_NIT", Nit)
        Dim datat As DataTable = EjecutarConsultaDataTable()
        Me.Desconectar()
        If datat.Rows.Count > 0 Then
            ok = True
            Me.Doc = datat.Rows(0)("EXAP_NUME").ToString
        End If

        Return ok
    End Function

    <DataObjectMethodAttribute(DataObjectMethodType.Select, True)> _
    Public Function GetPorNumExpe(ByVal numExpediente As String) As DataTable
        Dim dataTb As New DataTable
        Me.Conectar()
        Me.querystring = "SELECT * FROM VEXPE_APG WHERE EXAP_NUME=:EXAP_NUME"
        CrearComando(querystring)
        AsignarParametroCadena(":EXAP_NUME", numExpediente)
        dataTb = EjecutarConsultaDataTable()
        Me.Desconectar()

        Return dataTb
    End Function

    <DataObjectMethodAttribute(DataObjectMethodType.Select, True)> _
    Public Function GetSaldoPorPeriodo(ByVal Nit As String, ByVal Impuesto As String, ByVal numExpediente As String) As DataTable
        Dim dataTb As DataTable
        Me.Conectar()
        querystring = "SELECT E.EXAP_AGRA, E.EXAP_PGRA, E.CAL_DES, C.CAR_TDOC, C.CAR_DCOD, C.CAR_ACPA, NVL(C.SALDO, 0) AS SALDO, C.CAR_EST, E.EXAP_SUIM "
        querystring = querystring + "FROM VEXPE_APG E LEFT JOIN VCARTERAXPERIODO C "
        querystring = querystring + "ON E.EXPE_NIT = C.CAR_NIT AND E.EXAP_AGRA = C.CAR_ANO AND E.EXAP_SUIM = C.CAR_SUIM "
        querystring = querystring + "AND E.EXAP_PGRA = C.CAR_PER AND E.EXPE_CDEC = C.CAR_CDEC "
        querystring = querystring + "WHERE E.EXPE_NIT = :EXPE_NIT AND E.EXPE_CDEC=:EXPE_CDEC AND E.EXAP_NUME = :EXPE_NUME "
        querystring = querystring + "ORDER BY EXAP_AGRA, EXAP_PGRA "
        CrearComando(querystring)
        AsignarParametroCadena(":EXPE_NIT", Nit)
        AsignarParametroCadena(":EXPE_CDEC", Impuesto)
        AsignarParametroCadena(":EXPE_NUME", numExpediente)
        dataTb = EjecutarConsultaDataTable()
        Me.Desconectar()
        Return dataTb
    End Function

    'se cambio llamando la nueva funcion que calcula 
    <DataObjectMethodAttribute(DataObjectMethodType.Select, True)> _
    Public Function GetPeriodosAdeudadosSinExpediente(ByVal Per_Ini As String, ByVal Per_Fin As String, ByVal Vig_Ini As String, ByVal Vig_Fin As String, ByVal Impuesto As String, Optional ByVal Nit As String = "", Optional ByVal CodMpio As String = "") As DataTable
        'Dim pIni1, pFin1 As String
        'Dim dataTb As New DataTable
        'Dim oApg As New Expe_Apg
        'pIni1 = ConsPeriodo(Per_Ini, Impuesto, Vig_Ini)
        'pFin1 = ConsPeriodo(Per_Fin, Impuesto, Vig_Fin)
        'Me.Conectar()
        'Me.querystring = QueryApgSinExpediente(pIni1, pFin1, Vig_Ini, Vig_Fin, Impuesto, Nit, CodMpio) + " ORDER BY TER_NOM,  CAL_VIG, CAL_PER "

        Conectar()
        ' create the command for the stored procedure
        Dim cmd = New OracleCommand()
        cmd.Connection = Me.Conexion
        cmd.CommandText = "fnPerOmiso"
        cmd.CommandType = CommandType.StoredProcedure
        ' add the parameters for the stored procedure including the REF CURSOR to retrieve the result set
        cmd.Parameters.Add("outCdecxcal", OracleDbType.RefCursor).Direction = ParameterDirection.ReturnValue
        cmd.Parameters.Add("init", OracleDbType.Varchar2).Value = Nit
        cmd.Parameters.Add("aini", OracleDbType.Varchar2).Value = Vig_Ini
        cmd.Parameters.Add("pini", OracleDbType.Varchar2).Value = Per_Ini
        cmd.Parameters.Add("afin", OracleDbType.Varchar2).Value = Vig_Fin
        cmd.Parameters.Add("pfin", OracleDbType.Varchar2).Value = Per_Fin
        cmd.Parameters.Add("cladec", OracleDbType.Varchar2).Value = Impuesto
        Dim da As OracleDataAdapter = New OracleDataAdapter(cmd)
        Dim dt As New DataTable
        da.Fill(dt)
        da.Dispose()
        Desconectar()
        Return dt

        'CrearComando(Me.querystring)
        'dataTb = EjecutarConsultaDataTable()
        'Me.Desconectar()
        'Return dataTb

    End Function

    <DataObjectMethodAttribute(DataObjectMethodType.Select, True)> _
    Public Function GetResSancion(ByVal nit As String, ByVal numExpediente As String) As DataTable
        Dim dataTb As DataTable
        Me.Conectar()
        Dim ObjSacion As Sancion = New Sancion
        Dim sancion As String = ObjSacion.GetValSan(numExpediente)
        querystring = "SELECT AGRAVABLE ||'-'|| CAL_DES AS ""PERIODO"", CLD_NOM AS ""IMPUESTO"", VALORIMPUESTO AS ""VALOR IMPUESTO"",(FEC_DEC - CAL_FVEN) AS ""DIAS VENCIDOS"", " & _
        sancion + "  AS SANCION, interesMora(VALORIMPUESTO,CAL_FVEN,FEC_DEC) Interes, " & _
        " (VALORIMPUESTO + " + sancion + " + interesMora(VALORIMPUESTO,CAL_FVEN,FEC_DEC)) AS TOTAL, " & _
        " CAL_FVEN, PGRAVABLE, CDEC, FEC_DEC" & _
        " FROM(SELECT NRO_RAD, redondear(ValorImpuesto) as ValorImpuesto, CDEC, AGRAVABLE, PGRAVABLE, CAL_DES, CAL_FVEN, CLD_NOM, " & _
        " (SELECT EXTR_FELA FROM EXPE_TRAM WHERE EXTR_DOAD = 'RESA' AND EXTR_NUME = '" & numExpediente & "') AS FEC_DEC " & _
        " FROM(select nro_rad, CDEC, AGRAVABLE, PGRAVABLE, sum(ValorImpto) ValorImpuesto from  Fm_BasesLiq01 where (nro_rad) in" & _
        " (Select Max(NRO_RAD) From Fm_BasesLiq01 WHERE NIT_AR = :NIT  AND  (CDEC||AGRAVABLE||PGRAVABLE) " & _
        " IN (SELECT EXPE_CDEC||EXAP_AGRA||EXAP_PGRA FROM EXPE_APG WHERE EXAP_NUME = '" & numExpediente & "')	 " & _
        " Group by  CDEC, AGRAVABLE, PGRAVABLE) " & _
        " Group by nro_rad, CDEC, AGRAVABLE, PGRAVABLE)	" & _
        " LEFT JOIN CALENDARIO ON CAL_PER = PGRAVABLE AND CAL_VIG = AGRAVABLE AND CAL_CLA = CDEC " & _
        " LEFT JOIN Clase_Dec oN CLD_COD = CDEC)"
        CrearComando(querystring)
        AsignarParametroCadena(":NIT", nit)
        dataTb = EjecutarConsultaDataTable()
        Me.Desconectar()
        Return dataTb
    End Function
    '<DataObjectMethodAttribute(DataObjectMethodType.Select, True)> _
    'Public Function GetResolucionSancion(ByVal nit As String, ByVal numExpediente As String) As DataTable
    '    Dim dataTb As DataTable
    '    Me.Conectar()
    '    querystring = "SELECT AGRAVABLE ||'-'|| CAL_DES AS ""PERIODO"", CLD_NOM AS ""IMPUESTO"", VALORIMPUESTO AS ""VALOR IMPUESTO"",(FEC_DEC - CAL_FVEN) AS ""DIAS VENCIDOS"", " & _
    '    " SANCION_EXTEMPORANEIDAD(VALORIMPUESTO,FEC_DEC, CAL_FVEN, 1, 0) AS SANCION, " & _
    '    " (VALORIMPUESTO + SANCION_EXTEMPORANEIDAD(VALORIMPUESTO,FEC_DEC, CAL_FVEN, 1, 0)) AS TOTAL, " & _
    '    " CAL_FVEN, PGRAVABLE, CDEC, FEC_DEC" & _
    '    " FROM(SELECT NRO_RAD, redondear(ValorImpuesto) as ValorImpuesto, CDEC, AGRAVABLE, PGRAVABLE, CAL_DES, CAL_FVEN, CLD_NOM, " & _
    '    " (SELECT EXTR_FELA FROM EXPE_TRAM WHERE EXTR_DOAD = 'RESA' AND EXTR_NUME = '" & numExpediente & "') AS FEC_DEC " & _
    '    " FROM(select nro_rad, CDEC, AGRAVABLE, PGRAVABLE, sum(ValorImpto) ValorImpuesto from  Fm_BasesLiq01 where (nro_rad) in" & _
    '    " (Select Max(NRO_RAD) From Fm_BasesLiq01 WHERE NIT_AR = :NIT  AND  (CDEC||AGRAVABLE||PGRAVABLE) " & _
    '    " IN (SELECT EXPE_CDEC||EXAP_AGRA||EXAP_PGRA FROM EXPE_APG WHERE EXAP_NUME = '" & numExpediente & "')	 " & _
    '    " Group by  CDEC, AGRAVABLE, PGRAVABLE) " & _
    '    " Group by nro_rad, CDEC, AGRAVABLE, PGRAVABLE)	" & _
    '    " LEFT JOIN CALENDARIO ON CAL_PER = PGRAVABLE AND CAL_VIG = AGRAVABLE AND CAL_CLA = CDEC " & _
    '    " LEFT JOIN Clase_Dec oN CLD_COD = CDEC)"
    '    CrearComando(querystring)
    '    AsignarParametroCadena(":NIT", nit)
    '    dataTb = EjecutarConsultaDataTable()
    '    Me.Desconectar()
    '    Return dataTb
    'End Function

    <DataObjectMethodAttribute(DataObjectMethodType.Select, True)> _
    Public Function GetCuotasAcuePago(ByVal numExpediente As String) As DataTable
        Dim dataTb As DataTable
        Me.Conectar()
        querystring = "SELECT * FROM VCUOTA_ACUEPAGO WHERE ACPA_NEXP = :ACPA_NEXP"
        CrearComando(querystring)
        AsignarParametroCadena(":ACPA_NEXP", numExpediente)
        dataTb = EjecutarConsultaDataTable()
        Me.Desconectar()
        Return dataTb
    End Function

    <DataObjectMethodAttribute(DataObjectMethodType.Select, True)> _
    Public Function GetLiqAforo(ByVal numExpediente As String) As DataTable
        Dim dataTb As DataTable
        Me.Conectar()
        querystring = "select * FROM VLIQUIDACION_AFORO where FORMULARIO IN(SELECT EXAP_DCOD FROM EXPE_APG WHERE EXAP_NUME = :EXAP_NUME) order by formulario, code_codi"
        CrearComando(querystring)
        AsignarParametroCadena(":EXAP_NUME", numExpediente)
        dataTb = EjecutarConsultaDataTable()
        Me.Desconectar()
        Return dataTb
    End Function

    <DataObjectMethodAttribute(DataObjectMethodType.Select, True)> _
    Public Function GetNumLiqAforo(ByVal numExpediente As String) As DataTable
        Dim dataTb As DataTable
        Me.Conectar()
        querystring = "SELECT DISTINCT FORMULARIO, VIGENCIA, PERIODO FROM VLIQUIDACION_AFORO where FORMULARIO IN(SELECT EXAP_DCOD FROM EXPE_APG WHERE EXAP_NUME = :EXAP_NUME)"
        CrearComando(querystring)
        AsignarParametroCadena(":EXAP_NUME", numExpediente)
        dataTb = EjecutarConsultaDataTable()
        Me.Desconectar()
        Return dataTb
    End Function

    <DataObjectMethodAttribute(DataObjectMethodType.Select, True)> _
    Public Function GetTotalLiqAforo(ByVal numExpediente As String) As DataTable
        Dim dataTb As DataTable
        Me.Conectar()
        querystring = "SELECT 'TOTAL' AS CONCEPTO, SUM(total) AS TOTAL, Numero_a_Texto ( SUM(total) )|| ' PESOS M/C'  as Valor_Letras "
        querystring = querystring + " FROM VLIQUIDACION_AFORO WHERE CONCEPTO= 'TOTAL A PAGAR' AND FORMULARIO IN (SELECT EXAP_DCOD FROM EXPE_APG WHERE EXAP_NUME = :EXAP_NUME)"
        CrearComando(querystring)
        AsignarParametroCadena(":EXAP_NUME", numExpediente)
        dataTb = EjecutarConsultaDataTable()
        Me.Desconectar()
        Return dataTb
    End Function

    'Public Function QueryApgSinExpediente(ByVal Per_Ini As String, ByVal Per_Fin As String, ByVal Vig_Ini As String, ByVal Vig_Fin As String, ByVal Impuesto As String, Optional ByVal Nit As String = "", Optional ByVal CodMpio As String = "") As String
    '    Dim QueryConsulta As String
    '    QueryConsulta = " SELECT TER_NIT, TER_NOM, CAL_PER, CAL_VIG, CAL_DES, TER_MPIO, TEDE_FINI, CAL_FINI, CAL_FFIN"
    '    QueryConsulta = QueryConsulta + " FROM (SELECT TER_NIT, TER_NOM, TER_MPIO, TEDE_FINI, CAL_VIG, CAL_PER, CAL_DES, CAL_FINI, CAL_FFIN"
    '    QueryConsulta = QueryConsulta + " FROM  TER_DEC, CALENDARIO, TERCEROS"
    '    QueryConsulta = QueryConsulta + " WHERE CAL_VIG BETWEEN '" + Vig_Ini + "' AND '" + Vig_Fin + "' AND CAL_CLA = '" + Impuesto + "'"
    '    QueryConsulta = QueryConsulta + " AND CAL_FINI >= '" + Per_Ini + "' AND CAL_FFIN <= last_day('" + Per_Fin + "') AND "
    '    QueryConsulta = QueryConsulta + " TO_DATE(SUBSTR(tede_fini, 1, 11),'dd/mm/yyyy') <= last_day('" + Per_Fin + "') and tede_cdec = '" + Impuesto + "'"
    '    QueryConsulta = QueryConsulta + " AND TO_DATE(SUBSTR(tede_fini, 1, 11),'dd/mm/yyyy') <= CAL_FFIN AND TEDE_TNIT = TER_NIT "
    '    QueryConsulta = QueryConsulta + " AND CAL_FVEN <= last_day('" + Per_Fin + "')) "
    '    QueryConsulta = QueryConsulta + " WHERE (TER_NIT||'-'|| CAL_PER ||'-'|| CAL_VIG)"
    '    QueryConsulta = QueryConsulta + " NOT IN (SELECT LLAVE FROM VTERCERO_DECLARACION"
    '    QueryConsulta = QueryConsulta + " WHERE DEC_VIG BETWEEN  '" + Vig_Ini + "' AND '" + Vig_Fin + "' AND DEC_CDEC = '" + Impuesto + "' AND DEC_EST = 'PR'"
    '    QueryConsulta = QueryConsulta + " AND CAL_FINI >= '" + Per_Ini + "' AND CAL_FFIN <= last_day('" + Per_Fin + "'))"
    '    QueryConsulta = QueryConsulta + " AND (TER_NIT||'-'|| CAL_PER ||'-'|| CAL_VIG)"
    '    QueryConsulta = QueryConsulta + " NOT IN (SELECT EXPE_NIT||'-'||EXAP_PGRA||'-'||EXAP_AGRA"
    '    QueryConsulta = QueryConsulta + " FROM VEXPE_APG WHERE EXAP_ESTA = 'AC' AND EXPE_CDEC = '" + Impuesto + "')"
    '    If Not String.IsNullOrEmpty(Nit) Then
    '        QueryConsulta = QueryConsulta + " AND TER_NIT = '" + Nit + "'"
    '    End If
    '    If Not String.IsNullOrEmpty(CodMpio) Then
    '        QueryConsulta = QueryConsulta + " AND TER_MPIO = '" + CodMpio + "'"
    '    End If
    '    Return QueryConsulta
    'End Function

    Public Function QueryApgSinExpedienteSh(ByVal Per_Ini As String, ByVal Per_Fin As String, ByVal Vig_Ini As String, ByVal Vig_Fin As String, ByVal Impuesto As String, Optional ByVal Nit As String = "", Optional ByVal CodMpio As String = "") As String
        Dim QueryConsulta As String

        QueryConsulta = " SELECT TER_NIT, TER_NOM, CAL_PER, CAL_VIG, CAL_DES, TER_MPIO, TEDE_FINI, CAL_FINI, CAL_FFIN"
        QueryConsulta = QueryConsulta + " FROM (SELECT TER_NIT, TER_NOM, TER_MPIO, TEDE_FINI, CAL_VIG, CAL_PER, CAL_DES, CAL_FINI, CAL_FFIN"
        QueryConsulta = QueryConsulta + " FROM  TER_DEC, CALENDARIO, TERCEROS"
        QueryConsulta = QueryConsulta + " WHERE CAL_VIG BETWEEN '" + Vig_Ini + "' AND '" + Vig_Fin + "' AND CAL_CLA = '" + Impuesto + "'"
        QueryConsulta = QueryConsulta + " AND CAL_FINI >= to_date('" + Per_Ini + "','dd/mm/yyyy') AND CAL_FFIN <= last_day(to_date('" + Per_Fin + "','dd/mm/yyyy')) AND "
        QueryConsulta = QueryConsulta + " TO_DATE(SUBSTR(tede_fini, 1, 11),'dd/mm/yyyy') <= last_day(to_date('" + Per_Fin + "','dd/mm/yyyy')) and tede_cdec = '" + Impuesto + "'"
        QueryConsulta = QueryConsulta + " AND TO_DATE(SUBSTR(tede_fini, 1, 11),'dd/mm/yyyy') <= CAL_FFIN AND TEDE_TNIT = TER_NIT "
        QueryConsulta = QueryConsulta + " AND CAL_FVEN <= last_day(to_date('" + Per_Fin + "','dd/mm/yyyy'))) "
        QueryConsulta = QueryConsulta + " WHERE (TER_NIT||'-'|| CAL_PER ||'-'|| CAL_VIG)"
        QueryConsulta = QueryConsulta + " NOT IN (SELECT LLAVE FROM VTERCERO_DECLARACION"
        QueryConsulta = QueryConsulta + " WHERE DEC_VIG BETWEEN  '" + Vig_Ini + "' AND '" + Vig_Fin + "' AND DEC_CDEC = '" + Impuesto + "' AND DEC_EST = 'PR' OR (dec_est = 'DC' AND DEC_PTOT=0) " 'adiciono or para scar las declaraciones en 0
        QueryConsulta = QueryConsulta + " AND CAL_FINI >= to_date('" + Per_Ini + "','dd/mm/yyyy') AND CAL_FFIN <= last_day(to_date('" + Per_Fin + "','dd/mm/yyyy')))"
        QueryConsulta = QueryConsulta + " AND (TER_NIT||'-'|| CAL_PER ||'-'|| CAL_VIG)"
        QueryConsulta = QueryConsulta + " NOT IN (SELECT EXPE_NIT||'-'||EXAP_PGRA||'-'||EXAP_AGRA"
        QueryConsulta = QueryConsulta + " FROM VEXPE_APG WHERE EXAP_ESTA = 'AC' AND EXPE_CDEC = '" + Impuesto + "')"
        If Not String.IsNullOrEmpty(Nit) Then
            QueryConsulta = QueryConsulta + " AND TER_NIT = '" + Nit + "'"
        End If
        If Not String.IsNullOrEmpty(CodMpio) Then
            QueryConsulta = QueryConsulta + " AND TER_MPIO = '" + CodMpio + "'"
        End If
        Return QueryConsulta
    End Function

    Public Function QueryApgSinExpediente(ByVal Per_Ini As String, ByVal Per_Fin As String, ByVal Vig_Ini As String, ByVal Vig_Fin As String, ByVal Impuesto As String, Optional ByVal Nit As String = "", Optional ByVal CodMpio As String = "") As String
        Dim QueryConsulta As String

        QueryConsulta = " SELECT TER_NIT, TER_NOM, CAL_PER, CAL_VIG, CAL_DES, TER_MPIO, TEDE_FINI, CAL_FINI, CAL_FFIN"
        QueryConsulta = QueryConsulta + " FROM (SELECT TER_NIT, TER_NOM, TER_MPIO, TEDE_FINI, CAL_VIG, CAL_PER, CAL_DES, CAL_FINI, CAL_FFIN"
        QueryConsulta = QueryConsulta + " FROM  TER_DEC, CALENDARIO, TERCEROS"
        QueryConsulta = QueryConsulta + " WHERE CAL_VIG BETWEEN '" + Vig_Ini + "' AND '" + Vig_Fin + "' AND CAL_CLA = '" + Impuesto + "'"
        QueryConsulta = QueryConsulta + " AND CAL_FINI >= to_date('" + Per_Ini + "','dd/mm/yyyy') AND CAL_FFIN <= last_day(to_date('" + Per_Fin + "','dd/mm/yyyy')) AND "
        QueryConsulta = QueryConsulta + " TO_DATE(SUBSTR(tede_fini, 1, 11),'dd/mm/yyyy') <= last_day(to_date('" + Per_Fin + "','dd/mm/yyyy')) and tede_cdec = '" + Impuesto + "'"
        QueryConsulta = QueryConsulta + " AND TO_DATE(SUBSTR(tede_fini, 1, 11),'dd/mm/yyyy') <= CAL_FFIN AND TEDE_TNIT = TER_NIT "
        QueryConsulta = QueryConsulta + " AND CAL_FVEN <= last_day(to_date('" + Per_Fin + "','dd/mm/yyyy'))) "
        QueryConsulta = QueryConsulta + " WHERE (TER_NIT||'-'|| CAL_PER ||'-'|| CAL_VIG)"
        QueryConsulta = QueryConsulta + " NOT IN (SELECT LLAVE FROM VTERCERO_DECLARACION"
        QueryConsulta = QueryConsulta + " WHERE DEC_VIG BETWEEN  '" + Vig_Ini + "' AND '" + Vig_Fin + "' AND DEC_CDEC = '" + Impuesto + "' AND DEC_EST = 'PR' OR (dec_est = 'DC' AND DEC_PTOT=0) " 'adiciono or para scar las declaraciones en 0
        QueryConsulta = QueryConsulta + " AND CAL_FINI >= to_date('" + Per_Ini + "','dd/mm/yyyy') AND CAL_FFIN <= last_day(to_date('" + Per_Fin + "','dd/mm/yyyy')))"
        QueryConsulta = QueryConsulta + " AND (TER_NIT||'-'|| CAL_PER ||'-'|| CAL_VIG)"
        QueryConsulta = QueryConsulta + " NOT IN (SELECT EXPE_NIT||'-'||EXAP_PGRA||'-'||EXAP_AGRA"
        QueryConsulta = QueryConsulta + " FROM VEXPE_APG WHERE EXAP_ESTA = 'AC' AND EXPE_CDEC = '" + Impuesto + "')"
        If Not String.IsNullOrEmpty(Nit) Then
            QueryConsulta = QueryConsulta + " AND TER_NIT = '" + Nit + "'"
        End If
        If Not String.IsNullOrEmpty(CodMpio) Then
            QueryConsulta = QueryConsulta + " AND TER_MPIO = '" + CodMpio + "'"
        End If
        Return QueryConsulta

    End Function

    Public Function QueryApgSinExpeVehiculo(ByVal Vig_Ini As String, ByVal Vig_Fin As String, ByVal Impuesto As String, Optional ByVal Nit As String = "", Optional ByVal CodMpioOper As String = "", Optional ByVal CodMpioMat As String = "") As String
        Dim QueryConsulta As String
        QueryConsulta = "SELECT TER_NIT, PLACA, CAL_PER, CAL_VIG, CAL_CLA, CLASE, MARCA, LINEA, MODELO, TER_NOM, MUN_MATRICULA, MUN_OPERACION FROM "
        QueryConsulta = QueryConsulta + " (SELECT A.NIT, A.PLACA, CAL_PER, CAL_VIG, CAL_CLA, CLASE, MARCA, LINEA, MODELO, MUN_MATRICULA, MUN_OPERACION FROM"
        QueryConsulta = QueryConsulta + " ((SELECT NIT, PLACA, CLASE, MARCA, LINEA, MODELO, MUN_MATRICULA, MUN_OPERACION FROM VH_PARQUE_AUTOMOTOR WHERE ESTADO = 'AC' AND  to_char(FECHA_INGRESO, 'YYYY') <='" & Vig_Fin & "'"
        QueryConsulta = QueryConsulta + " AND (NIT, PLACA) NOT IN (SELECT DEC_NIT, PLACA FROM VVH_DECLARACION WHERE DEC_CDEC = '" & Impuesto & "' AND DEC_VIG BETWEEN '" & Vig_Ini & "' AND '" & Vig_Fin & "'))"
        QueryConsulta = QueryConsulta + " ) A, CALENDARIO WHERE CAL_FVEN <= SYSDATE AND CAL_VIG BETWEEN '" & Vig_Ini & "' AND '" & Vig_Fin & "' AND CAL_CLA = '" & Impuesto & "' ORDER BY NIT, PLACA, CAL_PER, CAL_VIG "
        QueryConsulta = QueryConsulta + " ) LEFT JOIN TERCEROS ON NIT = TER_NIT "
        QueryConsulta = QueryConsulta + " WHERE (NIT, PLACA, CAL_PER, CAL_VIG, CAL_CLA) NOT IN "
        QueryConsulta = QueryConsulta + " (SELECT EXPE_NIT, EXAP_SUIM, EXAP_PGRA, EXAP_AGRA, EXPE_CDEC "
        QueryConsulta = QueryConsulta + " FROM VEXPE_APG WHERE EXAP_AGRA BETWEEN '" & Vig_Ini & "' AND '" & Vig_Fin & "'  AND EXPE_CDEC = '" & Impuesto & "')"

        If Not String.IsNullOrEmpty(Nit) Then
            QueryConsulta = QueryConsulta + " AND NIT = '" + Nit + "'"
        End If
        If Not String.IsNullOrEmpty(CodMpioMat) Then
            QueryConsulta = QueryConsulta + " AND MUN_MATRICULA = '" + CodMpioMat + "'"
        End If
        If Not String.IsNullOrEmpty(CodMpioOper) Then
            QueryConsulta = QueryConsulta + " AND MUN_OPERACION = '" + CodMpioOper + "'"
        End If
        Return QueryConsulta
    End Function

    Public Function ConsPeriodo(ByVal Periodo As String, ByVal Impuesto As String, ByVal Vigencia As String) As String

        Dim queryString As String
        Dim desconectar As Boolean
        desconectar = False
        Me.Conectar()
        queryString = "SELECT CAL_FINI FROM CALENDARIO WHERE CAL_PER = :PER_INI AND CAL_CLA = :IMPUESTO AND CAL_VIG = :VIGENCIA"
        CrearComando(queryString)
        AsignarParametroCadena(":PER_INI", Periodo)
        AsignarParametroCadena(":IMPUESTO", Impuesto)
        AsignarParametroCadena(":VIGENCIA", Vigencia)
        Dim dataTb As DataTable = EjecutarConsultaDataTable()
        Me.Desconectar()

        Return dataTb.Rows(0)("CAL_FINI").ToString.Substring(0, 10)

    End Function

End Class

