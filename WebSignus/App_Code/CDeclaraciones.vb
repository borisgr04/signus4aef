Imports Microsoft.VisualBasic
Imports System.Data
Imports System.Data.Common
Imports System.ComponentModel


Public Structure LPCODE_CDEC
    Public CODE_CDEC As String
    Public CODE_CODI As String
    Public CODE_TICO As String
    Public CODE_NOMB As String
    Public CODE_TMOV As String
    Public CODE_ABVB As String
    Public CODE_VADE As Double
    Public CODE_ABVD As String
    Public CODE_VACA As Double
    Public CODE_SECO As String
    Public CODE_TARI As Double
    Public CODE_IMPTO As String
    Public CODE_TSAN As String
    Public CODE_CART As String
    Public CODE_VABA As Double
    Public CODE_ISVB As String
    Public CODE_REDE As String
    Public CODE_DENR As String
    Public CODE_VASU As Double
    Public CODE_VAOF As Double
    Public CODE_USBD As String
    Public CODE_USAP As String
    Public CODE_DEES As String
    Public CODE_CCAR As String
    Public CODE_AÑSA As String
    Public CODE_PESA As String
    Public CODE_SUM As String
End Structure
    
<DataObjectAttribute()> _
Public Class CDeclaraciones
    Inherits BDDatos2
    Protected Clase_Dec As String
    Protected CAUSAR_LIQ As String
    Protected PD_NRODOC As String = ""
    Protected PD_TIPDOC As String = ""
    Protected PD_RAZSOC As String = ""
    'Datos de Revisor o Contador
    Protected RF_NRODOC As String = ""
    Protected RF_TIPDOC As String = ""
    Protected RF_RAZSOC As String = ""
    Protected RF_TREV As String = ""
    Protected RF_TARPRO As String = ""
    Protected DEC_COD As String
    Protected Vig As New Vigencias
    Protected TiDo As String


    Public Overloads Function GetSignatarios(ByVal Nit As String) As DataTable
        Conectar()
        Me.querystring = "SELECT * FROM VSignatarios WHERE rel_age='" + Nit + "'"
        CrearComando(querystring)
        Dim dataTb As DataTable = EjecutarConsultaDataTable()
        Me.Desconectar()
        Return dataTb
    End Function

    Private Overloads Function GetSignatarios_x(ByVal Nit As String) As DataTable
        'Conectar()
        Me.querystring = "SELECT * FROM VSignatarios WHERE rel_age='" + Nit + "'"
        CrearComando(querystring)
        Dim dataTb As DataTable = EjecutarConsultaDataTable()
        'Me.Desconectar()
        Return dataTb
    End Function

    Private Function Cargar_Signatarios(ByVal dec_nit As String) As Boolean
        'Seleccionar SIGNATARIOS

        Dim dtS As DataTable = GetSignatarios_x(dec_nit)
        If dtS.Rows.Count > 0 Then
            'declarante
            Me.PD_NRODOC = dtS.Rows(0)("Dec_nit").ToString
            Me.PD_TIPDOC = dtS.Rows(0)("Dec_tdoc").ToString
            Me.PD_RAZSOC = dtS.Rows(0)("Dec_nom").ToString
            'revisor
            Me.RF_NRODOC = dtS.Rows(0)("Rev_nit").ToString
            Me.RF_TIPDOC = dtS.Rows(0)("Rev_tdoc").ToString
            Me.RF_RAZSOC = dtS.Rows(0)("Rev_nom").ToString
            Me.RF_TARPRO = dtS.Rows(0)("Rev_tar_pro").ToString
            Me.RF_TREV = dtS.Rows(0)("REV_TREV").ToString
            Return True
        Else
            Me.lErrorG = True
            Me.Msg = "Error de Datos:" + "No tiene Asignado los Signatarios"
            Return False
        End If

    End Function

    Public Function Insert(ByRef DCOD As String, ByVal DEC_CDEC As String, ByVal DEC_NIT As String, ByVal DVer As String, ByVal DEC_ANO As String, ByVal DEC_PER As String, ByVal DEC_CNRO As String, _
     ByVal DEC_TRET As String, ByVal DEC_CSAN As String, ByVal DEC_TSAN As Double, ByVal DEC_TOT As String, ByVal DEC_PRS As Double, ByVal DEC_PIM As Double, ByVal DEC_PTOT As Double, ByVal DEC_TIP As String, _
     ByVal DEC_RAZSOC As String, ByVal Dec_FDCO As String, ByVal Dec_FVEN As Date, ByVal TD As String, ByVal aLiqPriv() As LPCODE_CDEC, ByVal DOAD As String) As String
        Dim na As Integer

        Dim DEC_NRO As String
        Me.TiDo = DOAD
        Me.Conectar()
        Vig.Conexion = Me.Conexion
        Try
            Me.CAUSAR_LIQ = Me.GetCAUSAR_LIQ(Now)
            Dim VActual As String = Vig.GetActiva()
            Dim tdNd As DataTable = Me.GetDecByPer1(DEC_NIT, DEC_ANO, DEC_PER)

            If (tdNd.Rows.Count() > 0) And (TD = "I") Then
                If InList(tdNd.Rows(0)("Dec_Est").ToString, "DF", "DC") Then
                    Msg = "Validación : Existe un Formulario de Declaración en estado DEFINITIVO N°" + tdNd.Rows(0)("Dec_Cod").ToString + " para este periodo <br>si este no ha sido Presentado ante la Entidad Recaudadora, puede anularlo y Diligenciar un Nuevo Formulario de Declaración para este periodo."
                ElseIf tdNd.Rows(0)("Dec_Est").ToString = "PR" Then
                    Msg = "Validación : Existe un Formulario de Declaración PRESENTADO ante la Entidad Recaudadora,  N°" + tdNd.Rows(0)("Dec_Cod").ToString + " para este periodo <br> si va a modificar la Declaración debe Diligenciar Un Formulario de Declaración por Correción ."
                ElseIf tdNd.Rows(0)("Dec_Est").ToString = "CR" Then
                    Msg = "Validación : Existe un Formulario de Declaración CORREGIDA ante la Entidad Recaudadora,  N°" + tdNd.Rows(0)("Dec_Cod").ToString + " para este periodo <br> si va a modificar la Declaración debe Diligenciar Un Formulario de Declaración por Correción ."
                End If
                Me.lErrorG = True
                Return Msg
            End If

            If (tdNd.Rows.Count() = 0) And (TD = "C") Then
                Msg = "Validación : No Existe Formulario de Declaración en estado DEFINITIVO/PRESENTADO para este periodo ."
                Me.lErrorG = True
                Return Msg
            End If

            ComenzarTransaccion()
            Dim Val_DecPer As Boolean = Validar_DecPer(DEC_NIT)
            Dim Cargar_Sig As Boolean = Me.Cargar_Signatarios(DEC_NIT)
            DEC_NRO = Me.GenConsecutivo()

            Dim SqlInsert As String = "INSERT INTO DECLARACION(DEC_NRO,DEC_CDEC,DEC_NIT,DEC_ANO,DEC_PER,DEC_TIP,DEC_CNRO,DEC_TRS, DEC_VIG,DEC_EST,DEC_USAP,DEC_RAZSOC,DEC_FREG,DEC_USBD,DEC_TDOC,DEC_DVER,DEC_TSAN,DEC_PRS,DEC_PIM,DEC_PTOT,DEC_CSAN,DEC_TRET,DEC_COD,Dec_FDCO,DEC_FVEN,DEC_DOAD)"
            SqlInsert += "VALUES(:DEC_NRO,:DEC_CDEC,:DEC_NIT,:DEC_ANO,:DEC_PER,:DEC_TIP,:DEC_CNRO,:DEC_TOT,VigenciaActual,:DEC_EST,:DEC_USAP,:DEC_RAZSOC,SYSDATE,User,:DEC_TDOC,:DEC_DVER,:DEC_TSAN,:DEC_PRS,:DEC_PIM,:DEC_PTOT,:DEC_CSAN,:DEC_TRET,:DEC_COD,:Dec_FDCO,:DEC_FVEN,:DEC_DOAD)"

            Dim ESTADO_INICIAL As String = IIf(CAUSAR_LIQ = "N", "DF", "DC")
            If (Val_DecPer = False) And DEC_TIP = "01" Then
                Msg = "Error de Datos: Existe otra Declaración Inicial para este periodo, debe anularla sino la declaró o hacer una declaracion por corrección"
                Me.lErrorG = True
                Return Msg
            End If
            ''Cargar Signatarios
            ''If Not Cargar_Sig  Then
            ''Msg = "Error Parametrización: Debe Asignar Signatarios"
            ''Me.lErrorG = True
            ''Return Msg
            ''End If
            Me.DEC_COD = VActual + Me.Clase_Dec + DEC_NRO
            DCOD = Me.DEC_COD
            Me.querystring = SqlInsert
            CrearComando(querystring)
            AsignarParametroCadena(":DEC_NRO", DEC_NRO)
            AsignarParametroCadena(":DEC_CDEC", DEC_CDEC)
            AsignarParametroCadena(":DEC_NIT", DEC_NIT)
            AsignarParametroCadena(":DEC_ANO", DEC_ANO)
            AsignarParametroCadena(":DEC_PER", DEC_PER)
            AsignarParametroCadena(":DEC_TIP", DEC_TIP)
            AsignarParametroCadena(":DEC_CNRO", DEC_CNRO)
            AsignarParametroDecimal(":DEC_TRS", DEC_TOT)
            AsignarParametroCadena(":DEC_EST", ESTADO_INICIAL)
            AsignarParametroCadena(":DEC_USAP", Me.usuario)
            AsignarParametroCadena(":DEC_RAZSOC", DEC_RAZSOC)
            AsignarParametroCadena(":DEC_TDOC", "NI")
            AsignarParametroCadena(":DEC_DVER", DVer)
            AsignarParametroCadena(":DEC_TSAN", DEC_TSAN)
            AsignarParametroCadena(":DEC_PRS", DEC_PRS)
            AsignarParametroCadena(":DEC_PIM", DEC_PIM)
            AsignarParametroDecimal(":DEC_PTOT", DEC_PTOT)
            AsignarParametroCadena(":DEC_CSAN", DEC_CSAN)
            AsignarParametroCadena(":DEC_TRET", DEC_TRET)
            AsignarParametroCadena(":DEC_COD", DEC_COD)
            AsignarParametroCadena(":Dec_FDCO", Dec_FDCO)
            AsignarParametroFecha(":Dec_FVEN", Dec_FVEN)
            AsignarParametroCadena(":DEC_DOAD", DOAD)
            na = EjecutarComando()
            Me.InsertLP(DEC_NRO, aLiqPriv, ESTADO_INICIAL, DOAD)
            'Creación de Cartera
            If Me.CAUSAR_LIQ = "S" Then
                Me.querystring = "Decl.CrearCartera"
                CrearComando(querystring, CommandType.StoredProcedure)
                AsignarParametroCad("TCod", DOAD)
                AsignarParametroCad("DCod", Me.DEC_COD)
                AsignarParametroFec("DFpre", Now)
                na = EjecutarComando()
            End If

            Me.Msg = MsgOk + "<BR> Número de Filas Afectadas " + na.ToString
            Me.Msg = MsgOk + "<BR> Formulario N° " + Me.DEC_COD
            ConfirmarTransaccion()
            Me.lErrorG = False
        Catch ex As Exception
            Me.lErrorG = True
            Me.Msg = "Error de App:" + ex.Message
            CancelarTransaccion()
        Finally
            Me.Desconectar()
        End Try

        Return Msg
    End Function

    Private Sub InsertLP(ByVal nro_dec As String, ByVal aLp() As LPCODE_CDEC, ByVal Estado As String, ByVal DoAd As String)
        Me.querystring = "Insert into CODE_CDEC (CODE_CDEC,CODE_CODI,CODE_TICO,CODE_NOMB,CODE_TMOV,CODE_ABVB,CODE_VADE,CODE_ABVD,CODE_VACA,CODE_SECO,CODE_TARI,CODE_IMPTO,CODE_TSAN,CODE_CART,CODE_VABA,CODE_ISVB,CODE_REDE,CODE_DENR,CODE_VASU,CODE_VAOF,CODE_USBD,CODE_USAP,CODE_DEES,CODE_FREG,CODE_CCAR,CODE_SUM,CODE_VIG,CODE_DCOD,CODE_DOAD) "
        Me.querystring += "Values(:CODE_CDEC,:CODE_CODI,:CODE_TICO,:CODE_NOMB,:CODE_TMOV,:CODE_ABVB,:CODE_VADE,:CODE_ABVD,:CODE_VACA,:CODE_SECO,:CODE_TARI,:CODE_IMPTO,:CODE_TSAN,:CODE_CART,:CODE_VABA,:CODE_ISVB,:CODE_REDE,:CODE_DENR,:CODE_VASU,:CODE_VAOF,User,:CODE_USAP,:CODE_DEES,SYSDATE,:CODE_CCAR,:CODE_SUM,VigenciaActual,:CODE_DCOD,:CODE_DOAD)"
        Dim na As Integer = 0
        For i As Integer = 0 To aLp.Length - 1
            CrearComando(querystring)
            ':CODE_CDEC
            AsignarParametroCadena(":CODE_CDEC", Me.Clase_Dec)
            ',:CODE_CODI,
            AsignarParametroCadena(":CODE_CODI", aLp(i).CODE_CODI)
            ':CODE_TICO,
            AsignarParametroCadena(":CODE_TICO", aLp(i).CODE_TICO)
            ':CODE_NOMB,:COCD_CDEC,:CODE_TMOV,:CODE_ABVB,:CODE_VADE,:CODE_ABVD,:CODE_VACA,:CODE_SECO,:CODE_TARI,:CODE_IMPTO,:CODE_TSAN,:CODE_CART,:CODE_VABA,:CODE_ISVB,:CODE_REDE,:CODE_DENR,:CODE_VASU,:CODE_VAOF,User,:CODE_USAP,:CODE_DEES,:CODE_FREG
            AsignarParametroCadena(":CODE_NOMB", aLp(i).CODE_NOMB)

            ':CODE_TMOV,:CODE_ABVB,:CODE_VADE,:CODE_ABVD,:CODE_VACA,:CODE_SECO,:CODE_TARI,:CODE_IMPTO,:CODE_TSAN,:CODE_CART,:CODE_VABA,:CODE_ISVB,:CODE_REDE,:CODE_DENR,:CODE_VASU,:CODE_VAOF,User,:CODE_USAP,:CODE_DEES,:CODE_FREG
            AsignarParametroCadena(":CODE_TMOV", aLp(i).CODE_TMOV)

            ':,:CODE_ABVB,:CODE_VADE,:CODE_ABVD,:CODE_VACA,:CODE_SECO,:CODE_TARI,:CODE_IMPTO,:CODE_TSAN,:CODE_CART,:CODE_VABA,:CODE_ISVB,:CODE_REDE,:CODE_DENR,:CODE_VASU,:CODE_VAOF,User,:CODE_USAP,:CODE_DEES,:CODE_FREG
            AsignarParametroCadena(":CODE_ABVB", aLp(i).CODE_ABVB)

            ':,:CODE_ABVB,:CODE_VADE,:CODE_ABVD,:CODE_VACA,:CODE_SECO,:CODE_TARI,:CODE_IMPTO,:CODE_TSAN,:CODE_CART,:CODE_VABA,:CODE_ISVB,:CODE_REDE,:CODE_DENR,:CODE_VASU,:CODE_VAOF,User,:CODE_USAP,:CODE_DEES,:CODE_FREG
            AsignarParametroDecimal(":CODE_VADE", aLp(i).CODE_VADE)

            ':CODE_VACA,:CODE_SECO,:CODE_TARI,:CODE_IMPTO,:CODE_TSAN,:CODE_CART,:CODE_VABA,:CODE_ISVB,:CODE_REDE,:CODE_DENR,:CODE_VASU,:CODE_VAOF,User,:CODE_USAP,:CODE_DEES,:CODE_FREG
            AsignarParametroCadena(":CODE_ABVD", aLp(i).CODE_ABVD)


            ':CODE_VACA,:CODE_SECO,:CODE_TARI,:CODE_IMPTO,:CODE_TSAN,:CODE_CART,:CODE_VABA,:CODE_ISVB,:CODE_REDE,:CODE_DENR,:CODE_VASU,:CODE_VAOF,User,:CODE_USAP,:CODE_DEES,:CODE_FREG
            AsignarParametroDecimal(":CODE_VACA", aLp(i).CODE_VACA)

            ':CODE_SECO,:CODE_TARI,:CODE_IMPTO,:CODE_TSAN,:CODE_CART,:CODE_VABA,:CODE_ISVB,:CODE_REDE,:CODE_DENR,:CODE_VASU,:CODE_VAOF,User,:CODE_USAP,:CODE_DEES,:CODE_FREG
            AsignarParametroCadena(":CODE_SECO", aLp(i).CODE_SECO)

            'CODE_TARI,:CODE_IMPTO,:CODE_TSAN,:CODE_CART,:CODE_VABA,:CODE_ISVB,:CODE_REDE,:CODE_DENR,:CODE_VASU,:CODE_VAOF,User,:CODE_USAP,:CODE_DEES,:CODE_FREG
            AsignarParametroDecimal(":CODE_TARI", aLp(i).CODE_TARI)


            'CODE_IMPTO,:CODE_TSAN,:CODE_CART,:CODE_VABA,:CODE_ISVB,:CODE_REDE,:CODE_DENR,:CODE_VASU,:CODE_VAOF,User,:CODE_USAP,:CODE_DEES,:CODE_FREG
            AsignarParametroCadena(":CODE_IMPTO", aLp(i).CODE_IMPTO)

            'CODE_TSAN,:CODE_CART,:CODE_VABA,:CODE_ISVB,:CODE_REDE,:CODE_DENR,:CODE_VASU,:CODE_VAOF,User,:CODE_USAP,:CODE_DEES,:CODE_FREG
            'dbCommand2.Parameters.Add("CODE_TSAN", OracleDbType.Varchar2, ParameterDirection.Input).Value = aLp(i).CODE_TSAN
            AsignarParametroCadena(":CODE_TSAN", aLp(i).CODE_TSAN)

            'CODE_CART,:CODE_VABA,:CODE_ISVB,:CODE_REDE,:CODE_DENR,:CODE_VASU,:CODE_VAOF,User,:CODE_USAP,:CODE_DEES,:CODE_FREG
            AsignarParametroCadena(":CODE_CART", aLp(i).CODE_CART)

            'CODE_VABA,:CODE_ISVB,:CODE_REDE,:CODE_DENR,:CODE_VASU,:CODE_VAOF,User,:CODE_USAP,:CODE_DEES,:CODE_FREG
            AsignarParametroDecimal(":CODE_VABA", aLp(i).CODE_VABA)

            'CODE_ISVB,:CODE_REDE,:CODE_DENR,:CODE_VASU,:CODE_VAOF,User,:CODE_USAP,:CODE_DEES,:CODE_FREG
            AsignarParametroCadena(":CODE_ISVB", aLp(i).CODE_ISVB)

            'CODE_REDE,:CODE_DENR,:CODE_VASU,:CODE_VAOF,User,:CODE_USAP,:CODE_DEES,:CODE_FREG
            AsignarParametroCadena(":CODE_REDE", aLp(i).CODE_REDE)

            'CODE_DENR,:CODE_VASU,:CODE_VAOF,User,:CODE_USAP,:CODE_DEES,:CODE_FREG

            AsignarParametroCadena(":CODE_DENR", nro_dec)

            'CODE_VASU,:CODE_VAOF,User,:CODE_USAP,:CODE_DEES,:CODE_FREG
            AsignarParametroDecimal(":CODE_VASU", aLp(i).CODE_VASU)

            'CODE_VAOF,User,:CODE_USAP,:CODE_DEES,:CODE_FREG
            AsignarParametroDecimal(":CODE_VAOF", aLp(i).CODE_VAOF)

            'CODE_USAP,:CODE_DEES,:CODE_FREG
            AsignarParametroCadena(":CODE_USAP", Me.usuario)

            'CODE_DEES,:CODE_FREG, :CODE_DEES,SYSDATE,:CODE_CCAR,:CODE_SUM,VigenciaActual,:CODE_DCOD
            AsignarParametroCadena(":CODE_DEES", Estado)

            'CODE_CAR
            AsignarParametroCadena(":CODE_CCAR", aLp(i).CODE_CCAR)

            'CODE_SUM
            AsignarParametroCadena(":CODE_SUM", aLp(i).CODE_SUM)

            'CODE_dcod
            AsignarParametroCadena(":CODE_DCOD", Me.DEC_COD)

            'CODE_DOAD
            AsignarParametroCadena(":CODE_DOAD", DoAd)


            na += EjecutarComando()
        Next

    End Sub

    'Creación de Cartera al Liquidar
    Private Sub CrearCartera(ByVal Dec_Doad As String, ByVal Dec_Cod As String, ByVal Dec_FPre As Date)
        Dim na As Integer
        Me.querystring = "Decl.CrearCartera"
        CrearComando(querystring, CommandType.StoredProcedure)
        AsignarParametroCad("TCod", Dec_Doad)
        AsignarParametroCad("DCod", Dec_Cod)
        AsignarParametroFec("DFpre", Dec_FPre)
        na = EjecutarComando()
    End Sub


    <DataObjectMethodAttribute(DataObjectMethodType.Select, True)> _
    Public Overloads Function GetDLiquidacion(ByVal Cla_Dec As String, ByVal Año As String, ByVal Periodo As String) As DataTable
        ', Optional ByVal Fec_Dec As Date = Now()
        Me.Conectar()
        'me.querystring = "Select * from vLiqDec Where Cld_Cod=:CD "
        Me.querystring = "Select * from vCld_Imp Where Cld_Cod=:CD And (Select cal_fini From Calendario Where Cal_Cla=vCld_Imp.Cld_Cod And  Cal_Vig=:Cal_Vig And Cal_Per=:Cal_Per) Between imp_fin and imp_ffi Order by Imp_Cod"
        CrearComando(querystring)
        AsignarParametroCadena(":CD", Cla_Dec)
        AsignarParametroCadena(":Cal_Vig", Año)
        AsignarParametroCadena(":Cal_Per", Periodo)

        Dim dataTb As DataTable = EjecutarConsultaDataTable()

        Me.Desconectar()
        Return dataTb

    End Function

    <DataObjectMethodAttribute(DataObjectMethodType.Select, True)> _
    Public Overloads Function GetRenglones(ByVal Cla_Dec As String, ByVal Sec_Cod As String, ByVal Fode_Codi As String) As DataTable
        'ByVal Cla_Dec As String, ByVal Año As String, ByVal Periodo As String
        ', Optional ByVal Fec_Dec As Date = Now()
        Me.Conectar()
        Me.querystring = "Select * from VCONC_CDEC c where c.cocd_cdec=:cdec and c.COCD_SECO=:seco And c.cocd_fdco=:Fode_Codi Order By COCD_CDEC,COCD_CODI"
        CrearComando(querystring)
        AsignarParametroCadena(":cdec", Cla_Dec)
        AsignarParametroCadena(":seco", Sec_Cod)
        AsignarParametroCadena(":Fode_Codi", Fode_Codi)

        Dim dataTb As DataTable = EjecutarConsultaDatatable

        Me.Desconectar()
        Return dataTb
    End Function


    <DataObjectMethodAttribute(DataObjectMethodType.Select, True)> _
    Public Overloads Function GetConceptos(ByVal Cla_Dec As String) As DataTable

        Me.Conectar()
        Me.querystring = "select * from vConc_CDec Where CoCd_Cdec=:CD Order by CoCd_codi"
        CrearComando(querystring)
        AsignarParametroCadena("CD", Cla_Dec)

        Dim dataTb As DataTable = EjecutarConsultaDataTable()

        Me.Desconectar()
        Return dataTb

    End Function
    <DataObjectMethodAttribute(DataObjectMethodType.Select, True)> _
    Public Overloads Function GetDeclaracionRpt(ByVal Dec_Cod As String) As DataSet
        Me.Conectar()
        'me.querystring = "SELECT to_number(dec_nro)dec_nro,*  FROM  vDeclaracion"
        'me.querystring = "Select to_number(dec_nro)dec_nro,* From vDeclaracion,copias_rpt  Where Dec_Nro=:Dec_Nro And dec_cdec=:dec_cdec Order by to_number(Cop_Cod) asc "
        Me.querystring = "Select to_number(dec_nro)dec_nro,* From vDeclaracion,copias_rpt  Where Dec_cod=:Dec_Cod  Order by to_number(Cop_Cod) asc "
        CrearComando(querystring)
        AsignarParametroCadena(":Dec_Cod", Dec_Cod)
        Dim dataSet As DataSet = EjecutarConsultaDataSet()

        Me.Desconectar()
        Return dataSet
    End Function
    <DataObjectMethodAttribute(DataObjectMethodType.Select, True)> _
    Public Overloads Function GetDeclaracion(ByVal Dec_Cod As String) As DataSet
        Me.Conectar()
        'me.querystring = "SELECT to_number(dec_nro)dec_nro,*  FROM  vDeclaracion"
        Me.querystring = "Select to_number(dec_nro)dec_nro,D.* From vDeclaracion D Where Dec_Cod=:Dec_Cod "
        CrearComando(querystring)
        AsignarParametroCadena(":Dec_Cod", Dec_Cod)

        Dim dataSet As DataSet = EjecutarConsultaDataSet()

        Me.Desconectar()
        Return dataSet
    End Function
    <DataObjectMethodAttribute(DataObjectMethodType.Select, True)> _
    Public Overloads Function GetDeclaraciones(ByVal Dec_Nit As String, ByVal dec_año As String, ByVal dec_per As String) As DataTable

        Me.Conectar()
        Me.querystring = "Select * From vDeclaracion Where Dec_Nit=:Dec_Nit and dec_per=:Dec_per and dec_ano=:Dec_ano"
        CrearComando(querystring)
        AsignarParametroCadena(":Dec_Nit", Dec_Nit)
        AsignarParametroCadena(":Dec_per", dec_per)
        AsignarParametroCadena(":Dec_ano", dec_año)
        Dim dataTb As DataTable = EjecutarConsultaDataTable()

        Me.Desconectar()
        Return dataTb

    End Function
    Public Overloads Function GetRAyuda(ByVal FoAy_FdCo As String) As DataTable

        Me.Conectar()
        Me.querystring = "Select * From form_ayud Where FoAy_FdCo=:FoAy_FdCo"
        CrearComando(querystring)

        AsignarParametroCadena(":FoAy_FdCo", FoAy_FdCo)

        Dim dataTb As DataTable = EjecutarConsultaDatatable

        Me.Desconectar()
        Return dataTb

    End Function
    Public Function GetNomDec(ByVal cla_dec As String) As String


        Dim datat As New Data.DataTable
        Me.Conectar()
        Me.querystring = "select Cld_NOM from clase_dec Where Cld_Cod=:CC "
        CrearComando(querystring)
        AsignarParametroCadena(":CC", cla_dec)
        Dim r As String = Convert.ToString(Me.EjecutarEscalar())
        Me.Desconectar()
        Return r

    End Function

    Public Function GetPlazoDec(ByVal Fecha_Dec As Date) As String

        Me.Conectar()
        Me.querystring = "FN_LEER_PARA_LIQU"
        CrearComando(querystring, CommandType.StoredProcedure)
        Dim preturn As DbParameter = AsignarParametroReturn(20)

        AsignarParametroCad("PNOM", "DIASLIMDEC")
        AsignarParametroCad("tipoPar", Me.Clase_Dec)
        Me.Msg = Me.Clase_Dec
        AsignarParametroFec("feFecha", Fecha_Dec)
        EjecutarComando()
        Me.Desconectar()
        Return pReturn.Value.ToString()
    End Function

    Public Function GetOMMD(ByVal Fecha_Dec As Date) As String

        Me.Conectar()
        Me.querystring = "FN_LEER_PARA_LIQU"
        CrearComando(querystring, CommandType.StoredProcedure)
        Dim preturn As DbParameter = AsignarParametroReturn(20)
        AsignarParametroCad("pnom", "OMMD")
        AsignarParametroCad("tipopar", Me.Clase_Dec)
        Me.Msg = Me.Clase_Dec
        AsignarParametroFec("fefecha", Fecha_Dec.ToShortDateString)
        EjecutarComando()
        Me.Desconectar()
        Return pReturn.Value.ToString()


    End Function
    Public Function GetOSIG(ByVal Fecha_Dec As Date) As String

        Me.Conectar()
        Me.querystring = "FN_LEER_PARA_LIQU"
        CrearComando(querystring, CommandType.StoredProcedure)
        Dim preturn As DbParameter = AsignarParametroReturn(20)

        AsignarParametroCad("PNOM", "OSIG")
        AsignarParametroCad("tipoPar", Me.Clase_Dec)
        Me.Msg = Me.Clase_Dec
        AsignarParametroFec("feFecha", Fecha_Dec.ToShortDateString)
        EjecutarComando()
        Me.Desconectar()
        Return pReturn.Value.ToString()

    End Function
    Private Function GetCAUSAR_LIQ(ByVal Fecha_Dec As Date) As String

        'Me.Conectar()
        Me.querystring = "FN_LEER_PARA_LIQU"
        CrearComando(querystring, CommandType.StoredProcedure)
        Dim preturn As DbParameter = AsignarParametroReturn(20)
        AsignarParametroCad("PNOM", "CAUSAR_LIQ")
        AsignarParametroCad("tipoPar", Me.Clase_Dec)
        Me.Msg = Me.Clase_Dec
        AsignarParametroFec("feFecha", Fecha_Dec.ToShortDateString)
        EjecutarComando()
        'Me.Desconectar()
        Return pReturn.Value.ToString()

    End Function
    Public Function GetCVMM(ByVal Fecha_Dec As Date) As String

        Me.Conectar()
        Me.querystring = "FN_LEER_PARA_LIQU"
        CrearComando(querystring, CommandType.StoredProcedure)
        Dim preturn As DbParameter = AsignarParametroReturn(20)
        AsignarParametroCad("PNOM", "CVMM")
        AsignarParametroCad("tipoPar", Me.Clase_Dec)
        Me.Msg = Me.Clase_Dec
        AsignarParametroFec("feFecha", Fecha_Dec)
        EjecutarComando()
        Me.Desconectar()
        Return pReturn.Value.ToString()


    End Function

    Public Function GetSancion_Extemporaneidad(ByVal Valor_Impuesto As Decimal, ByVal Fecha_Dec As Date, ByVal Fecha_Lim As Date, ByVal Emplazado As Int16) As String

        Me.Conectar()

        Me.querystring = "SANCION_EXTEMPORANEIDAD"
        CrearComando(querystring, CommandType.StoredProcedure)
        Dim pReturn As DbParameter = AsignarParametroReturn(20)
        AsignarParametroDec("Valor_Impuesto", Valor_Impuesto)
        AsignarParametroFec("Fecha_Dec", Fecha_Dec.ToShortDateString)
        AsignarParametroFec("Fecha_Lim", Fecha_Lim.ToShortDateString)
        AsignarParametroNumber("Emplazado", Emplazado)

        EjecutarComando()
        Me.Desconectar()

        Return pReturn.Value.ToString()


    End Function

    Public Function GetSancion_Inexactitud(ByVal ValorBase As Decimal, ByVal Acepta As Integer) As String

        'Me.Conectar()
        'Me.querystring = "Sancion_Inexactitud"
        'CrearComando(querystring, CommandType.StoredProcedure)
        'Dim pReturn As DbParameter = AsignarParametroReturn(20)
        'AsignarParametroDec("ValorBase", ValorBase)
        'AsignarParametroCad("Acepta", Acepta)

        Dim Valor As Decimal
        If Acepta = 0 Then
            Valor = ValorBase * 1
        Else
            Valor = ValorBase * 0.25
        End If

        Dim Sancion As Decimal = GetSancion_Minima(Now)

        If Sancion > Valor Then
            Valor = Sancion
        End If

        Return Valor


        'EjecutarComando()
        'Me.Desconectar()
        'Return pReturn.Value.ToString()


    End Function

    Public Function GetSancion_Minima(ByVal Fecha_Dec As Date) As String

        Me.Conectar()

        Me.querystring = "SANCIONMINIMA"
        CrearComando(querystring, CommandType.StoredProcedure)
        Dim preturn As DbParameter = AsignarParametroReturn(20)

        AsignarParametroFec("Fecha_Dec", Fecha_Dec)


        EjecutarComando()
        Me.Desconectar()

        Return pReturn.Value.ToString()


    End Function

    'Select FN_LEER_PARA_LIQU('REDONDEO') FROM DUAL
    Public Function pRedondeo() As Integer
        Me.Conectar()
        Me.querystring = "FN_LEER_PARA_LIQU"
        CrearComando(querystring, CommandType.StoredProcedure)
        Dim preturn As DbParameter = AsignarParametroReturn(20)
        AsignarParametroCad("PNOM", "REDONDEO")

        EjecutarComando()
        Me.Desconectar()

        Return CInt(pReturn.Value.ToString())


    End Function
    Public Overloads Function GetTasaLey1607(ByVal feRef As String) As DataTable

        Me.Conectar()
        Me.querystring = "SELECT  pali_vanu FROM par_liq_det WHERE (pali_plco = '03')AND (:feref BETWEEN pali_fein AND pali_fefi)"
        CrearComando(querystring)

        AsignarParametroFecha(":feRef", feRef)

        Dim dataTb As DataTable = EjecutarConsultaDataTable()

        Me.Desconectar()
        Return dataTb

    End Function

    Public Function GetInteresMora(ByVal Deuda As Decimal, ByVal Fecha_Deuda As Date, ByVal Fecha_Pag As Date) As Double
        Try
            Conectar()
            querystring = "select INTERESMORA(" + Deuda.ToString + ",to_Date(:fDeudaC,'dd/mm/yyyy'),to_Date(:FPago,'dd/mm/yyyy')) Interes from dual"
            CrearComando(querystring)
            AsignarParametroCadena(":fDeudaC", Fecha_Deuda)
            AsignarParametroCadena(":FPago", Fecha_Pag)
            Dim dt As DataTable = EjecutarConsultaDataTable()
            If dt.Rows.Count > 0 Then
                Return dt.Rows(0)("interes")
            Else
                Return 0
            End If
        Catch ex As Exception
            Return -1
        Finally
            Me.Desconectar()

        End Try
        'Me.querystring = "INTERESMORA"
        'CrearComando(querystring, CommandType.StoredProcedure)
        'Dim preturn As DbParameter = AsignarParametroReturn(20)
        'AsignarParametroDec("Deuda", Deuda)
        'AsignarParametroFec("feDeudaC", Fecha_Deuda)
        'AsignarParametroFec("fePago", Fecha_Pag)
        'EjecutarComando()
        'Return CDbl(preturn.Value.ToString.Replace(".", ",")) ', Double) '.ToDouble


    End Function
    Public Function GetInteresMora1066(ByVal Deuda As Decimal, ByVal Fecha_Deuda As Date, ByVal Fecha_Pag As Date) As Double
        Me.Conectar()
        Me.querystring = "InteresMora1066"
        CrearComando(querystring, CommandType.StoredProcedure)
        Dim preturn As DbParameter = AsignarParametroReturn(20)
        AsignarParametroDec("Deuda", Deuda)
        AsignarParametroFec("feDeudaC", Fecha_Deuda)
        AsignarParametroFec("fePago", Fecha_Pag)
        'Throw New Exception("DESPYES DE EJECUTAR" + Me.vComando.CommandText + Deuda.ToString + Fecha_Deuda.ToString + Fecha_Pag.ToString)
        EjecutarComando()
        Me.Desconectar()

        Return CDbl(preturn.Value.ToString.Replace(".", ",")) ', Double) '.ToDouble
        'Return DirectCast((preturn.Value.ToString.Replace(".", ",")), Double) '.ToDouble
    End Function

    Public Function GetInteresMoraC(ByVal Valor_Impuesto As Double, ByVal Fecha_Deuda As Date, ByVal Fecha_Pag As Date) As Double

        Dim interes As Double = RedondearUp(GetInteresMora(Valor_Impuesto, Fecha_Deuda, Fecha_Pag))
        Return interes
        'Return Redondear(interes)
    End Function
    Public Function GetTarifa(ByVal inCimp As String, ByVal inPar_Input As String, ByVal Fecha_Dec As Date) As Double
        Dim tar As Double = 0
        Me.Conectar()

        Me.querystring = "Fn_Ejecutar_Tarifa"
        CrearComando(querystring, CommandType.StoredProcedure)
        Dim preturn As DbParameter = AsignarParametroReturn(20)
        AsignarParametroCad("inCimp", inCimp)
        AsignarParametroCad("inPar_Input", inPar_Input)
        AsignarParametroFec("feFechMovi", Fecha_Dec)
        Try
            EjecutarComando()
        Catch ex As Exception
            Me.lErrorG = True
            Me.Msg = "Error de App:" + ex.Message
        Finally
            Me.Desconectar()
        End Try

        Return Me.RetornarParametroDecimal(preturn)

    End Function
    Public Overloads Function GetDec() As DataTable
        Me.Conectar()
        Me.querystring = "select * from vClase_Dec Where Cld_Cod=:CC "
        CrearComando(querystring)
        AsignarParametroCad(":CC", Me.Clase_Dec)

        Dim dataTb As DataTable = EjecutarConsultaDatatable

        Me.Desconectar()
        Return dataTb

    End Function
    Private Overloads Function GetConsNom() As String
        'PENDIENTE LO DE LA VIGENCIA

        Dim datat As New Data.DataTable
        Me.querystring = "Select Cld_Cons from vClase_Dec Where Cld_Cod=:CC"
        CrearComando(querystring)
        AsignarParametroCadena(":CC", Me.Clase_Dec)
        Dim r As Object = EjecutarEscalar
        Return r.ToString

    End Function
    Public Function GenConsecutivo() As String

        Dim ObjC As Consecutivos = New Consecutivos
        Dim vig As Vigencias = New Vigencias
        ObjC.Conexion = Me.Conexion
        vig.Conexion = Me.Conexion
        Dim svig As String = vig.GetActivaD()
        Return ObjC.GetConsec(GetConsNom(), svig).PadLeft(5, "0")

    End Function

    Public Function GenConsecutivoAnte() As String
        ' LA CONEXXION DEBE ESTAR ABIERTA

        Me.querystring = "FN_GETCONSEC_DOC"
        CrearComando(querystring, CommandType.StoredProcedure)
        Dim preturn As DbParameter = AsignarParametroReturn(20)

        AsignarParametroCad("CODI", Me.TiDo)
        AsignarParametroCad("CDEC", Me.Clase_Dec)

        EjecutarComando()


        Return pReturn.Value.ToString().PadLeft(5, "0")
    End Function

    Public Function GenCons() As String
        ' LA CONEXXION DEBE ESTAR ABIERTA
        'Dim dt As DataTable = GetUltCons()
        'Dim c As Decimal = CDec(dt.Rows(0)("cons_prx").ToString)
        'me.querystring = "Update Consecutivos SET Cons_Prx=Cons_Prx+1 Where cons_id=:id"
        'CrearComando(querystring)
        'dbCommand.Parameters.Add("id", OracleDbType.Varchar2, ParameterDirection.Input).Value = dt.Rows(0)("cld_coid").ToString
        'EjecutarComando
        Dim cod As String = "" ' c.ToString.PadLeft(5, "0")
        Return cod
    End Function
    Public Sub New(ByVal Cla_Dec As String)
        Me.Clase_Dec = Cla_Dec
    End Sub
    Public Sub New()
        Me.Clase_Dec = "00"
    End Sub
    Public Function Redondear(ByVal n As Decimal, ByVal r As Decimal) As Decimal
        Dim x As Decimal = System.Math.Floor(n / r)
        Dim s As Decimal = (n / r) - x
        s = (x + System.Math.Round(s)) * r
        Return s
    End Function
    Public Function RedondearUp(ByVal n As Decimal) As Decimal
        Dim r As Decimal = Me.pRedondeo()
        If (n > 0) Then
            Return Redondear(n, r)
        Else
            Return Redondear(n, r)
        End If

        'Me.Conectar()
        'Me.querystring = "SELECT Redondear(:n) Valor FROM  dual"
        'CrearComando(querystring)
        'AsignarParametroCadena(":n", n)
        'Dim c As Object = EjecutarEscalar()
        'Me.Desconectar()
        'Return CDec(c)

    End Function
    Public Function RedondearUp(ByVal n As Decimal, ByVal r As Decimal) As Decimal

        If (n > 0) Then
            Return Redondear(n - 1, r)
        Else
            Return Redondear(n, r)
        End If
       

    End Function
    Public Overloads Function GetLiqImpPriv() As DataSet
        Me.Conectar()
        Me.querystring = "SELECT * FROM  liqprivimp"
        CrearComando(querystring)
        Dim dataSet As DataSet = EjecutarConsultaDataSet()
        Me.Desconectar()
        Return dataSet
    End Function
    Public Function Validar_DecPer(ByVal Dec_Nit As String) As Boolean
        Dim r As Boolean
        ' LA CONEXXION DEBE ESTAR ABIERTA
        Dim c As Object
        Me.querystring = "Select COUNT(*) from declaracion where dec_ano='2009' and dec_per='01' and dec_est IN ('RE','DE') and dec_nit=:dec_nit"
        CrearComando(querystring)
        AsignarParametroCadena(":dec_nit", Dec_Nit)
        c = EjecutarEscalar
        Dim nr As Integer = CInt(c)
        If c > 0 Then
            r = False
        Else
            r = True
        End If
        r = True
        Return r
    End Function
    Public Function XXDeclaracionAnterior(ByVal Dec_Nit As String) As String
        'Dim r As Boolean
        Dim c As Object
        'Dim SW As Boolean
        Me.Conectar()
        Me.querystring = "Select DEC_NRO from Declaracion Where dec_ano='2009' and dec_per='01' and dec_est = 'AC' And dec_nit=:dec_nit"
        CrearComando(querystring)
        AsignarParametroCadena(":dec_nit", Dec_Nit)
        c = EjecutarEscalar()

        Me.Desconectar()
        Return CStr(c)
    End Function
    Public Function GetporCod(ByVal Dec_Cod As String) As DataTable
        'Dim r As Boolean

        Me.Conectar()
        Me.querystring = "Select * from Declaracion Where dec_cod=:dec_cod"
        CrearComando(querystring)
        AsignarParametroCadena(":dec_cod", Dec_Cod)

        Dim data As DataTable = EjecutarConsultaDatatable

        Me.Desconectar()
        Return data
    End Function
    Public Function IsDeclaracion(ByVal Dec_Nit As String, ByVal DEC_ANO As String, ByVal DEC_PER As String) As String
        'Dim r As Boolean
        Dim c As Object
        
            Me.Conectar()

        Me.querystring = "Select Dec_Nro From VDeclaracion Where Dec_Cdec=:Dec_Cdec And Dec_Nit=:Dec_Nit And Dec_Ano= :Dec_Ano And Dec_per=:Dec_per And Dec_est IN('DF','PR')"
        CrearComando(querystring)
        AsignarParametroCadena(":dec_cdec", Me.Clase_Dec)
        AsignarParametroCadena(":dec_nit", Dec_Nit)
        AsignarParametroCadena(":dec_ano", DEC_ANO)
        AsignarParametroCadena(":dec_per", DEC_PER)

        c = EjecutarEscalar


        Me.Desconectar()
        Return CStr(c)
    End Function
    Public Function Valor_Pagado(ByVal Dec_Cod As String) As Decimal
        'Dim r As Boolean
        Dim c As Object
        Me.Conectar()

        Me.querystring = "Select Sum(code_vade) code_vade from code_cdec where code_seco='VP' and (code_tico='T' or code_tico='F' )and code_dcod=:dec_cod"
        CrearComando(querystring)
        AsignarParametroCadena(":dec_cod", Dec_Cod)

        c = EjecutarEscalar()

       Me.Desconectar()
        Return CDec(c)
    End Function
    Public Function Valor_PagadoK(ByVal Dec_Cod As String) As Decimal
        'Dim r As Boolean
        Dim c As Object
        Me.Conectar()

        Me.querystring = "Select code_vade from code_cdec where code_seco='LP' and code_tico='K' and code_dcod=:dec_cod"
        CrearComando(querystring)
        AsignarParametroCadena(":dec_cod", Dec_Cod)

        c = EjecutarEscalar()

        Me.Desconectar()
        Return CDec(c)
    End Function

    '
    Public Function GetDecByPer(ByVal Dec_Nit As String, ByVal DEC_ANO As String, ByVal DEC_PER As String, ByVal Dec_Cdec As String) As DataTable
        Dim sw As Boolean = False
        Me.Conectar()
        Me.querystring = "Select * From vDeclaracion Where Dec_Cdec=:Dec_Cdec And Dec_Nit=:Dec_Nit And Dec_Ano= :Dec_Ano And Dec_per=:Dec_per And Dec_est IN('DF','PR','CR') Order by Dec_Cod Desc"
        CrearComando(querystring)
        AsignarParametroCadena(":Dec_Cdec", Dec_Cdec)
        AsignarParametroCadena(":Dec_Nit", Dec_Nit)
        AsignarParametroCadena(":Dec_Ano", DEC_ANO)
        AsignarParametroCadena(":Dec_per", DEC_PER)

        Dim dataSet As DataTable = EjecutarConsultaDataTable()

        Me.Desconectar()

        Return dataSet
    End Function
    Public Function GetDecByPer1(ByVal Dec_Nit As String, ByVal DEC_ANO As String, ByVal DEC_PER As String) As DataTable
        'Me.Conectar()
        Me.querystring = "Select * From vDeclaracion Where Dec_Cdec=:Dec_Cdec And Dec_Nit=:Dec_Nit And Dec_Ano= :Dec_Ano And Dec_per=:Dec_per And Dec_est IN('DF','PR','CR','DC') Order by Dec_Cod Desc"
        CrearComando(querystring)
        AsignarParametroCadena(":Dec_Cdec", Me.Clase_Dec)
        AsignarParametroCadena(":Dec_Nit", Dec_Nit)
        AsignarParametroCadena(":Dec_Ano", DEC_ANO)
        AsignarParametroCadena(":Dec_per", DEC_PER)

        Dim dataSet As DataTable = EjecutarConsultaDataTable()


        'Me.Desconectar()

        Return dataSet
    End Function
    Public Function GetDecByPer(ByVal Dec_Nit As String, ByVal DEC_ANO As String, ByVal DEC_PER As String) As DataTable
        Me.Conectar()
        Me.querystring = "Select * From vDeclaracion Where Dec_Cdec=:Dec_Cdec And Dec_Nit=:Dec_Nit And Dec_Ano= :Dec_Ano And Dec_per=:Dec_per And Dec_est IN('DF','PR','CR','DC') Order by Dec_Cod Desc"
        CrearComando(querystring)
        AsignarParametroCadena(":Dec_Cdec", Me.Clase_Dec)
        AsignarParametroCadena(":Dec_Nit", Dec_Nit)
        AsignarParametroCadena(":Dec_Ano", DEC_ANO)
        AsignarParametroCadena(":Dec_per", DEC_PER)

        Dim dataSet As DataTable = EjecutarConsultaDataTable()


        Me.Desconectar()

        Return dataSet
    End Function

    Public Function GetActByAPG(ByVal Dec_Nit As String, ByVal DEC_ANO As String, ByVal DEC_PER As String) As DataTable
        Me.Conectar()
        Me.querystring = "Select * From vDeclaracion Where Dec_Cdec=:dec_cdec And Dec_Nit=:dec_nit And Dec_Ano= :dec_ano And Dec_per=:dec_per And Dec_est ='PR' Order by Dec_Cod Desc"
        CrearComando(querystring)
        AsignarParametroCadena(":dec_cdec", Me.Clase_Dec)
        AsignarParametroCadena(":dec_nit", Dec_Nit)
        AsignarParametroCadena(":dec_ano", DEC_ANO)
        AsignarParametroCadena(":dec_per", DEC_PER)

        Dim dataSet As DataTable = EjecutarConsultaDataTable()

        Me.Desconectar()

        Return dataSet
    End Function

    Public Function GetLiqConcep() As DataSet
        Me.Conectar()
        Me.querystring = "SELECT * FROM  vCODE_CDEC WHERE CODE_CDEC=:CODE_CDEC  Order by CODE_CODI"
        CrearComando(querystring)

        AsignarParametroCadena(":CODE_CDEC", Me.Clase_Dec)
        Dim dataSet As DataSet = EjecutarConsultaDataSet()
        Me.Desconectar()
        Return dataSet
    End Function

    <DataObjectMethodAttribute(DataObjectMethodType.Select, True)> _
    Public Function GetLiqConcep(ByVal CODE_DCOD As String) As DataSet
        Me.Conectar()
        Me.querystring = "SELECT * FROM  vCODE_CDEC WHERE CODE_DCOD=:CODE_DCOD Order by CODE_CODI"
        CrearComando(querystring)

        AsignarParametroCadena(":CODE_DCOD", CODE_DCOD)
        Dim dataSet As DataSet = EjecutarConsultaDataSet()

        Me.Desconectar()
        Return dataSet
    End Function
    <DataObjectMethodAttribute(DataObjectMethodType.Select, True)> _
    Public Function GetFormularios_Dec(ByVal Año As String, ByVal Periodo As String) As DataSet
        Me.Conectar()
        Me.querystring = "Select * From Formularios_Dec f Where f.fode_est='AC' AND f.fode_cdec=:CDec And (Select cal_fini From Calendario Where Cal_Cla=f.fode_cdec And  Cal_Vig=:Cal_Vig And Cal_Per=:Cal_Per) Between f.fode_FEIN and f.fode_FEFI Order By fode_CDEC,fode_CODI"
        CrearComando(querystring)

        AsignarParametroCadena(":CDec", Me.Clase_Dec)
        AsignarParametroCadena(":Cal_Vig", Año)
        AsignarParametroCadena(":Cal_Per", Periodo)
        Dim dataSet As DataSet = EjecutarConsultaDataSet()
        Me.Desconectar()
        Return dataSet
    End Function

    'public property readonly Form_Decl as String
    Public Function GetFoDe_Codi(ByVal Año As String, ByVal Periodo As String) As String
        Dim dt As DataTable = Me.GetFormularios_Dec(Año, Periodo).Tables(0)
        Return dt.Rows(0)("Fode_codi").ToString
    End Function



    Public Function GetFormulariosByCod(ByVal fode_CODI As String) As DataTable
        Me.Conectar()
        Me.querystring = "Select f.*,Replace(fode_oper,chr(13)||chr(10),' ') fode_oper2 From vFormularios_Dec f Where fode_CODI=:fode_CODI "
        CrearComando(querystring)
        AsignarParametroCadena(":fode_CODI", fode_CODI)
        'dbCommand.Parameters.Add("CDec", OracleDbType.Varchar2, ParameterDirection.Input).Value = Me.Clase_Dec
        Dim dataTb As DataTable = EjecutarConsultaDatatable

        Me.Desconectar()
        Return dataTb
    End Function

    Public Function Radicar(ByVal Dec_Cod As String, ByVal Dec_FPre As Date) As String
        Dim na As Integer
        Me.Conectar()
        Try

            Me.querystring = "Decl.Radicar"
            CrearComando(querystring, CommandType.StoredProcedure)
            AsignarParametroCadena("DCod", Dec_Cod)
            AsignarParametroFecha("DFpre", Dec_FPre)
            AsignarParametroCadena("USAP", Me.usuario)
            na = EjecutarComando

            Me.Msg = MsgOk + "<BR> Número de Filas Afectadas " + na.ToString
            Me.lErrorG = False
        Catch ex As Exception
            Me.lErrorG = True
            Me.Msg = "Error de App:" + ex.Message
        Finally
            Me.Desconectar()
        End Try

        'Me.Desconectar()
        Return Msg
    End Function
    <DataObjectMethodAttribute(DataObjectMethodType.Select, True)> _
    Public Function GetCartAGravable2(ByVal Car_Nit As String, ByVal Car_Ano As String) As DataTable
        Me.Conectar()
        Me.querystring = "Select Car_Ano,Sum(Car_Vade) Car_Vade,Sum(Car_Vdb) Car_Vdb,Sum(Car_Vcr) Car_Vcr,Sum(Car_Vpa) Car_Vpa,Sum(Saldo) Saldo From vCarteraD car Inner Join Conc_Cart cc ON car.car_coca=cc.ccar_cod "
        queryString += " Where Car_Nit=:Car_Nit  And Car_Cdec=:Car_Cdec Group By Car_Ano"
        'And Car_Per=:Car_Per And And Car_Ano=:Car_Ano
        CrearComando(querystring)

        'And fode_CDEC=:CDEC
        AsignarParametroCadena(":Car_Nit", Car_Nit)
        'dbCommand.Parameters.Add("Car_Ano", OracleDbType.Varchar2, ParameterDirection.Input).Value = Car_Ano
        'dbCommand.Parameters.Add("Car_Per", OracleDbType.Varchar2, ParameterDirection.Input).Value = Car_Per
        AsignarParametroCadena("Car_Cdec", Me.Clase_Dec)
        Dim dataTb As DataTable = EjecutarConsultaDatatable

        Me.Desconectar()
        Return dataTb
    End Function

    <DataObjectMethodAttribute(DataObjectMethodType.Select, True)> _
    Public Function GetCartAGravable(ByVal Car_Nit As String, ByVal Car_Cdec As String) As DataTable
        Me.Conectar()
        'me.querystring = "Select Car_Ano,Sum(Car_Vade) Car_Vade,Sum(Car_Vdb) Car_Vdb,Sum(Car_Vcr) Car_Vcr,Sum(Car_Vpa) Car_Vpa,Sum(Saldo) Saldo From vCarteraD car Inner Join Conc_Cart cc ON car.car_coca=cc.ccar_cod "
        'queryString += " Where Car_Nit=:Car_Nit  And Car_Cdec=:Car_Cdec Group By Car_Ano"

        Me.querystring = "Select Car_Ano,Sum(Saldo_a_Cargo) Saldo_a_Cargo,  Sum(Saldo_a_Favor) Saldo_a_Favor"
        queryString += " From vCarteraD2 car Inner Join Conc_Cart cc ON car.car_coca=cc.ccar_cod "
        queryString += " Where Car_Nit=:Car_Nit  And Car_Cdec=:Car_Cdec Group By Car_Ano"
        'And Car_Per=:Car_Per And And Car_Ano=:Car_Ano
        CrearComando(querystring)

        'And fode_CDEC=:CDEC
        AsignarParametroCadena(":Car_Nit", Car_Nit)
        'dbCommand.Parameters.Add("Car_Ano", OracleDbType.Varchar2, ParameterDirection.Input).Value = Car_Ano
        'dbCommand.Parameters.Add("Car_Per", OracleDbType.Varchar2, ParameterDirection.Input).Value = Car_Per
        AsignarParametroCadena(":Car_Cdec", Car_Cdec)
        Dim dataTb As DataTable = EjecutarConsultaDatatable

        Me.Desconectar()
        Return dataTb
    End Function
    <DataObjectMethodAttribute(DataObjectMethodType.Select, True)> _
    Public Function GetCartPEstado(ByVal Car_Nit As String, ByVal Car_Cdec As String) As DataTable
        Me.Conectar()
        'me.querystring = "Select Car_Ano,Sum(Car_Vade) Car_Vade,Sum(Car_Vdb) Car_Vdb,Sum(Car_Vcr) Car_Vcr,Sum(Car_Vpa) Car_Vpa,Sum(Saldo) Saldo From vCarteraD car Inner Join Conc_Cart cc ON car.car_coca=cc.ccar_cod "
        'queryString += " Where Car_Nit=:Car_Nit  And Car_Cdec=:Car_Cdec Group By Car_Ano"

        Me.querystring = "Select Car_Est,(CASE WHEN Car_Est = 'AP' THEN 'ACUERDO DE PAGO' WHEN Car_Est = 'AC' THEN 'CARTERA ACTIVA'  END) Estado,Sum(Saldo_a_Cargo) Saldo_a_Cargo,  Sum(Saldo_a_Favor) Saldo_a_Favor"
        queryString += " From vCarteraD2 car Inner Join Conc_Cart cc ON car.car_coca=cc.ccar_cod  "
        queryString += " Where Car_Nit=:Car_Nit  And Car_Cdec=:Car_Cdec Group By Car_Est"
        'And Car_Per=:Car_Per And And Car_Ano=:Car_Ano
        CrearComando(querystring)


        'And fode_CDEC=:CDEC
        AsignarParametroCadena(":Car_Nit", Car_Nit)
        'dbCommand.Parameters.Add("Car_Ano", OracleDbType.Varchar2, ParameterDirection.Input).Value = Car_Ano
        'dbCommand.Parameters.Add("Car_Per", OracleDbType.Varchar2, ParameterDirection.Input).Value = Car_Per
        AsignarParametroCadena(":Car_Cdec", Car_Cdec)
        Dim dataTb As DataTable = EjecutarConsultaDatatable

        Me.Desconectar()
        Return dataTb
    End Function
    <DataObjectMethodAttribute(DataObjectMethodType.Select, True)> _
    Public Function GetCartEAGravable(ByVal Car_Nit As String, ByVal Car_Cdec As String, ByVal Car_Est As String) As DataTable
        Me.Conectar()
        'me.querystring = "Select Car_Ano,Sum(Car_Vade) Car_Vade,Sum(Car_Vdb) Car_Vdb,Sum(Car_Vcr) Car_Vcr,Sum(Car_Vpa) Car_Vpa,Sum(Saldo) Saldo From vCarteraD car Inner Join Conc_Cart cc ON car.car_coca=cc.ccar_cod "
        'queryString += " Where Car_Nit=:Car_Nit  And Car_Cdec=:Car_Cdec Group By Car_Ano"

        Me.querystring = "Select Car_Ano,Sum(Saldo_a_Cargo) Saldo_a_Cargo,  Sum(Saldo_a_Favor) Saldo_a_Favor"
        queryString += " From vCarteraD2 car Inner Join Conc_Cart cc ON car.car_coca=cc.ccar_cod "
        queryString += " Where Car_Nit=:Car_Nit  And Car_Cdec=:Car_Cdec and Car_Est=:Car_Est Group By Car_Ano"
        'And Car_Per=:Car_Per And And Car_Ano=:Car_Ano
        CrearComando(querystring)


        'And fode_CDEC=:CDEC
        AsignarParametroCadena(":Car_Nit", Car_Nit)
        'dbCommand.Parameters.Add("Car_Ano", OracleDbType.Varchar2, ParameterDirection.Input).Value = Car_Ano
        'dbCommand.Parameters.Add("Car_Per", OracleDbType.Varchar2, ParameterDirection.Input).Value = Car_Per
        AsignarParametroCadena(":Car_Cdec", Car_Cdec)
        AsignarParametroCadena(":Car_Est", Car_Est)
        Dim dataTb As DataTable = EjecutarConsultaDatatable

        Me.Desconectar()
        Return dataTb
    End Function


    'SALDOS POR AÑOS GRAVABLES
    '    Select Car_Ano,SUm(CASE WHEN Saldo >= 0 THEN Saldo ELSE 0 END) Saldo_a_Cargo, Sum(CASE WHEN Saldo < 0 THEN -Saldo ELSE 0 END) Saldo_a_Favor
    '    From vCarteraD Where Car_Nit=:Car_Nit  And Car_Cdec=:Car_Cdec Group By Car_Ano

    '----DEBIDO A COBRAR
    '
    '
    Public Function GetDEBIDOCOBRAR(ByVal Nit As String) As DataTable
        Me.Conectar()
        'me.querystring = "Select SUm(CASE WHEN Saldo >= 0 THEN Saldo ELSE 0 END) Saldo_a_Cargo, Sum(CASE WHEN Saldo < 0 THEN -Saldo ELSE 0 END) Saldo_a_Favor"
        'queryString += " From vCarteraD Where Car_Nit=:Car_Nit  And Car_Cdec=:Car_Cdec "

        Me.querystring = "Select Car_Cdec,SUm(CASE WHEN Saldo >= 0 THEN Saldo ELSE 0 END) Saldo_a_Cargo, Sum(CASE WHEN Saldo < 0 THEN -Saldo ELSE 0 END) Saldo_a_Favor"
        queryString += " From vCarteraD Where Car_Nit=:Car_Nit  Group by Car_Cdec"

        queryString = "Select Car_Cdec,Cld_Nom, Saldo_a_Cargo,Saldo_a_Favor From "
        queryString += " (Select Car_Cdec,SUm(CASE WHEN Saldo >= 0 THEN Saldo ELSE 0 END) Saldo_a_Cargo, Sum(CASE WHEN Saldo < 0 THEN -Saldo ELSE 0 END) Saldo_a_Favor"
        queryString += " From vCarteraD Where Car_Nit=:Car_Nit  Group by Car_Cdec)"
        queryString += " Inner Join Clase_Dec On Car_Cdec=CLD_COD"
        'And Car_Per=:Car_Per And And Car_Ano=:Car_Ano
        CrearComando(querystring)


        'And fode_CDEC=:CDEC
        AsignarParametroCadena(":Car_Nit", Nit)
        'dbCommand.Parameters.Add("Car_Cdec", OracleDbType.Varchar2, ParameterDirection.Input).Value = Me.Clase_Dec
        Dim dataTb As DataTable = EjecutarConsultaDatatable

        Me.Desconectar()
        Return dataTb
    End Function

    <DataObjectMethodAttribute(DataObjectMethodType.Select, True)> _
    Public Function GetCartAPGravable(ByVal Car_Nit As String, ByVal Car_Ano As String, ByVal Car_Per As String) As DataTable
        Me.Conectar()
        'Where Car_Nit='12345' And Car_Ano='2009' And Car_Per='01' And Car_Cdec='01'
        Me.querystring = "Select Car_Ano,Car_Per,Ccar_Nom,Car_Vade,Car_Vdb,Car_Vcr,Car_Vpa,Saldo From vCarteraD car Inner Join Conc_Cart cc ON car.car_coca=cc.ccar_cod  "
        queryString += " Where Car_Nit=:Car_Nit And Car_Ano=:Car_Ano  And Car_Cdec=:Car_Cdec"
        CrearComando(querystring)


        'And fode_CDEC=:CDEC
        AsignarParametroCadena(":Car_Nit", Car_Nit)
        AsignarParametroCadena(":Car_Ano", Car_Ano)
        'dbCommand.Parameters.Add("Car_Per", OracleDbType.Varchar2, ParameterDirection.Input).Value = Car_Per
        AsignarParametroCadena(":Car_Cdec", Me.Clase_Dec)
        Dim dataTb As DataTable = EjecutarConsultaDatatable

        Me.Desconectar()
        Return dataTb
    End Function

    'Select Car_Ano,Car_per,Sum(Car_Vade) Car_Vade,Sum(Car_Vdb) Car_Vdb,Sum(Car_Vcr) Car_Vcr,Sum(Car_Vpa) Car_Vpa,Sum(Saldo_a_Cargo) Saldo_a_Cargo,  Sum(Saldo_a_Favor) Saldo_a_Favor
    'From vCarteraD2 car Inner Join Conc_Cart cc ON car.car_coca=cc.ccar_cod 
    'Where Car_Nit=:Car_Nit  And Car_Cdec=:Car_Cdec And Car_Ano=:Car_Ano  Group By Car_Ano,Car_per Order by Car_Ano,Car_per
    'Cartera por Periodo Total
    <DataObjectMethodAttribute(DataObjectMethodType.Select, True)> _
    Public Function GetCartPer(ByVal Car_Nit As String, ByVal Car_Ano As String, ByVal Car_Cdec As String) As DataTable
        Me.Conectar()
        'Where Car_Nit='12345' And Car_Ano='2009' And Car_Per='01' And Car_Cdec='01'
        'me.querystring = "Select Car_Ano,Car_Per,Ccar_Nom,Car_Vade,Car_Vdb,Car_Vcr,Car_Vpa,Saldo From vCarteraD car Inner Join Conc_Cart cc ON car.car_coca=cc.ccar_cod  "
        'queryString += " Where Car_Nit=:Car_Nit And Car_Ano=:Car_Ano  And Car_Cdec=:Car_Cdec"

        Me.querystring = "Select Car_Ano,Car_per,Sum(Car_Vade) Car_Vade,Sum(Car_Vdb) Car_Vdb,Sum(Car_Vcr) Car_Vcr,Sum(Car_Vpa) Car_Vpa,Sum(Saldo_a_Cargo) Saldo_a_Cargo,  Sum(Saldo_a_Favor) Saldo_a_Favor"
        queryString += " From vCarteraD2 car Inner Join Conc_Cart cc ON car.car_coca=cc.ccar_cod "
        queryString += "  Where Car_Nit=:Car_Nit  And Car_Cdec=:Car_Cdec And Car_Ano=:Car_Ano  Group By Car_Ano,Car_per Order by Car_Ano,Car_per"

        CrearComando(querystring)


        'And fode_CDEC=:CDEC
        AsignarParametroCadena(":Car_Nit", Car_Nit)
        AsignarParametroCadena(":Car_Cdec", Car_Cdec)
        AsignarParametroCadena(":Car_Ano", Car_Ano)
        'dbCommand.Parameters.Add("Car_Per", OracleDbType.Varchar2, ParameterDirection.Input).Value = Car_Per

        Dim dataTb As DataTable = EjecutarConsultaDatatable

        Me.Desconectar()
        Return dataTb
    End Function
    ' Cartera por Estado y Por Periodo con acuerdo de pago
    <DataObjectMethodAttribute(DataObjectMethodType.Select, True)> _
    Public Function GetECartPer(ByVal Car_Nit As String, ByVal Car_Ano As String, ByVal Car_Cdec As String, ByVal Car_Est As String) As DataTable
        Me.Conectar()
        'Where Car_Nit='12345' And Car_Ano='2009' And Car_Per='01' And Car_Cdec='01'
        'me.querystring = "Select Car_Ano,Car_Per,Ccar_Nom,Car_Vade,Car_Vdb,Car_Vcr,Car_Vpa,Saldo From vCarteraD car Inner Join Conc_Cart cc ON car.car_coca=cc.ccar_cod  "
        'queryString += " Where Car_Nit=:Car_Nit And Car_Ano=:Car_Ano  And Car_Cdec=:Car_Cdec"

        Me.querystring = "Select Car_Ano,Car_per,Sum(Car_Vade) Car_Vade,Sum(Car_Vdb) Car_Vdb,Sum(Car_Vcr) Car_Vcr,Sum(Car_Vpa) Car_Vpa,Sum(Saldo_a_Cargo) Saldo_a_Cargo,  Sum(Saldo_a_Favor) Saldo_a_Favor"
        queryString += " From vCarteraD2 car Inner Join Conc_Cart cc ON car.car_coca=cc.ccar_cod "
        queryString += "  Where Car_Nit=:Car_Nit  And Car_Cdec=:Car_Cdec And Car_Ano=:Car_Ano and Car_Est=:Car_Est  Group By Car_Ano,Car_per Order by Car_Ano,Car_per"

        CrearComando(querystring)


        'And fode_CDEC=:CDEC
        AsignarParametroCadena(":Car_Nit", Car_Nit)
        AsignarParametroCadena(":Car_Cdec", Car_Cdec)
        AsignarParametroCadena(":Car_Ano", Car_Ano)
        AsignarParametroCadena(":Car_Est", Car_Est)

        Dim dataTb As DataTable = EjecutarConsultaDatatable

        Me.Desconectar()
        Return dataTb
    End Function
    '
    '
    'Cinsulta de cartera detalla general
    <DataObjectMethodAttribute(DataObjectMethodType.Select, True)> _
    Public Function GetCartPerD(ByVal Car_Nit As String, ByVal Car_Ano As String, ByVal Car_Per As String, ByVal Car_Cdec As String) As DataTable
        Me.Conectar()
        'Where Car_Nit='12345' And Car_Ano='2009' And Car_Per='01' And Car_Cdec='01'
        'me.querystring = "Select Car_Ano,Car_Per,Ccar_Nom,Car_Vade,Car_Vdb,Car_Vcr,Car_Vpa,Saldo From vCarteraD car Inner Join Conc_Cart cc ON car.car_coca=cc.ccar_cod  "
        'queryString += " Where Car_Nit=:Car_Nit And Car_Ano=:Car_Ano  And Car_Cdec=:Car_Cdec"

        '        me.querystring = "Select Car_Ano,Car_per,Car_Coca,CCar_Nom,Car_Vade,Car_Vdb,Car_Vcr,Car_Vpa,Saldo_a_Cargo,Saldo_a_Favor"
        '        queryString += " From vCarteraD2 car Inner Join Conc_Cart cc ON car.car_coca=cc.ccar_cod  "
        '        queryString += "  Where Car_Nit=:Car_Nit  And Car_Cdec=:Car_Cdec And Car_Ano=:Car_Ano And Car_per=:Car_per    Order by Car_Ano,Car_per"
        Me.querystring = " Select * From vCuentaCorriente Where Car_Nit=:Car_Nit  And Car_Cdec=:Car_Cdec And Car_Ano=:Car_Ano And Car_per=:Car_per    Order by Car_Ano,Car_per"
        CrearComando(querystring)


        'And fode_CDEC=:CDEC
        AsignarParametroCadena(":Car_Nit", Car_Nit)
        AsignarParametroCadena(":Car_Cdec", Car_Cdec)
        AsignarParametroCadena(":Car_Ano", Car_Ano)
        AsignarParametroCadena(":Car_Per", Car_Per)

        Dim dataTb As DataTable = EjecutarConsultaDatatable

        Me.Desconectar()
        Return dataTb
    End Function
    <DataObjectMethodAttribute(DataObjectMethodType.Select, True)> _
    Public Function GetECartPerD(ByVal Car_Nit As String, ByVal Car_Ano As String, ByVal Car_Per As String, ByVal Car_Cdec As String, ByVal Car_Est As String) As DataTable
        Me.Conectar()
        'Where Car_Nit='12345' And Car_Ano='2009' And Car_Per='01' And Car_Cdec='01'
        'me.querystring = "Select Car_Ano,Car_Per,Ccar_Nom,Car_Vade,Car_Vdb,Car_Vcr,Car_Vpa,Saldo From vCarteraD car Inner Join Conc_Cart cc ON car.car_coca=cc.ccar_cod  "
        'queryString += " Where Car_Nit=:Car_Nit And Car_Ano=:Car_Ano  And Car_Cdec=:Car_Cdec"

        '        me.querystring = "Select Car_Ano,Car_per,Car_Coca,CCar_Nom,Car_Vade,Car_Vdb,Car_Vcr,Car_Vpa,Saldo_a_Cargo,Saldo_a_Favor"
        '        queryString += " From vCarteraD2 car Inner Join Conc_Cart cc ON car.car_coca=cc.ccar_cod  "
        '        queryString += "  Where Car_Nit=:Car_Nit  And Car_Cdec=:Car_Cdec And Car_Ano=:Car_Ano And Car_per=:Car_per    Order by Car_Ano,Car_per"
        Me.querystring = " Select * From vCuentaCorriente Where Car_Nit=:Car_Nit  And Car_Cdec=:Car_Cdec And Car_Ano=:Car_Ano And Car_per=:Car_per and Car_Est=:Car_Est    Order by Car_Ano,Car_per"
        CrearComando(querystring)


        'And fode_CDEC=:CDEC
        AsignarParametroCadena(":Car_Nit", Car_Nit)
        AsignarParametroCadena(":Car_Cdec", Car_Cdec)
        AsignarParametroCadena(":Car_Ano", Car_Ano)
        AsignarParametroCadena(":Car_per", Car_Per)
        AsignarParametroCadena(":Car_Est", Car_Est)

        Dim dataTb As DataTable = EjecutarConsultaDatatable

        Me.Desconectar()
        Return dataTb
    End Function
    <DataObjectMethodAttribute(DataObjectMethodType.Select, True)> _
    Public Function GetCDEC_PorNit(ByVal Nit As String) As DataTable
        Me.Conectar()
        Me.querystring = "Select T.Ter_Nit,CD.CLD_Nom CLD_Nom2,CLD_COD||'-'||CD.CLD_Nom CLD_Nom,CLD_COD From TER_DEC TD Inner Join Terceros T On TD.Tede_TNit=T.Ter_nit Inner Join Clase_Dec CD On CD.CLD_COD=TD.TEDE_CDEC Where T.Ter_Nit=:Ter_Nit Order by CLD_COD"
        CrearComando(querystring)


        'And fode_CDEC=:CDEC
        AsignarParametroCadena(":Ter_Nit", Nit)
        Dim dataTb As DataTable = EjecutarConsultaDatatable


        Me.Desconectar()

        Return dataTb
    End Function

    Public Function IsCDec_Nit(ByVal Nit As String, ByVal ClDec As String) As Boolean
        
            Me.Conectar()
            

        Me.querystring = "Select Count(*) Cantidad From TER_DEC TD Where TD.Tede_tNit=:Tede_tNit And TD.Tede_CDec=:Tede_CDec"
        CrearComando(querystring)


        'And fode_CDEC=:CDEC
        AsignarParametroCadena(":Tede_tNit", Nit)
        AsignarParametroCadena(":Tede_CDec", ClDec)
        Dim c As Object = EjecutarEscalar

        Me.Desconectar()

        Dim cantidad As Integer = CInt(c)
        Return (cantidad > 0)
    End Function


    Public Function IsCDec_Impto(ByVal Cld As String, ByVal Imp As String) As Boolean

        Me.Conectar()
           

        Me.querystring = "Select Count(*) Cantidad from Cld_Imp Where Cld_Cod=:Cld_Cod And Cld_CImp=:Cld_CImp"
        CrearComando(querystring)


        'And fode_CDEC=:CDEC
        AsignarParametroCadena(":Cld_Cod", Cld)
        AsignarParametroCadena(":Cld_CImp", Imp)
        Dim c As Object = EjecutarEscalar


        Me.Desconectar()
        

        Dim cantidad As Integer = CInt(c)
        Return (cantidad > 0)
    End Function

    'Select * from calendario where cal_cla='01' and cal_vig='2009' and cal_per='01'
    Public Function IsCdec_APGravable(ByVal Cld As String, ByVal Agravable As String, ByVal Pgravable As String) As Boolean

        Me.Conectar()
           
        Me.querystring = "Select Count(*) Cantidad From Calendario where cal_cla=:cal_cla and cal_vig=:cal_vig and cal_per=:cal_per"
        CrearComando(querystring)


        'And fode_CDEC=:CDEC
        AsignarParametroCadena(":cal_cla", Cld)
        AsignarParametroCadena(":cal_vig", Agravable)
        AsignarParametroCadena(":cal_per", Pgravable)

        Dim c As Object = EjecutarEscalar


        Me.Desconectar()


        Dim cantidad As Integer = CInt(c)
        Return (cantidad > 0)

    End Function
    'Select * from calendario where cal_cla='01' and cal_vig='2009' and cal_per='01'
    Public Function GetRpt(ByVal Dec_Cod As String) As String

       
            Me.Conectar()

        Me.querystring = "Select Fode_Rpte From Formularios_Dec Inner Join Declaracion On Fode_Codi=Dec_FdCo Where Dec_Cod=:Dec_Cod"
        CrearComando(querystring)


        AsignarParametroCadena(":Dec_Cod", Dec_Cod)
        Dim c As Object = EjecutarEscalar


        Me.Desconectar()
        
        Return c.ToString

    End Function

    Public Function Existe_Declaracion(ByVal DCod As String) As Boolean
       
            Me.Conectar()
        
        Me.querystring = "Select Count(*) as Exit From Declaracion Where Dec_Cod=:Dec_Cod "
        CrearComando(querystring)

        AsignarParametroCadena(":Dec_Cod", DCod)
        'dbCommand.Parameters.Add("Dec_DoAd", OracleDbType.Varchar2, ParameterDirection.Input).Value = DoAd
        Dim c As Object = EjecutarEscalar


        Me.Desconectar()
        
        Return Not (CInt(c) = 0)
    End Function

    Public Function Cdec_APGravable(ByVal Cld As String, ByVal Agravable As String, ByVal Pgravable As String) As DataTable

        
            Me.Conectar()
            
        Me.querystring = "Select * From Calendario where cal_cla=:cal_cla and cal_vig=:cal_vig and cal_per=:cal_per"
        CrearComando(querystring)
        AsignarParametroCadena(":cal_cla", Cld)
        AsignarParametroCadena(":cal_vig", Agravable)
        AsignarParametroCadena(":cal_per", Pgravable)



        Dim dataTb As DataTable = EjecutarConsultaDatatable



        Me.Desconectar()


        Return dataTb



    End Function


    <DataObjectMethodAttribute(DataObjectMethodType.Select, True)> _
    Public Function GetCDEC() As DataTable
        Me.Conectar()
        Me.querystring = "Select * From vClase_Dec2 CD "
        CrearComando(querystring)


        Dim dataTb As DataTable = EjecutarConsultaDatatable

        Me.Desconectar()
        Return dataTb
    End Function

    <DataObjectMethodAttribute(DataObjectMethodType.Select, True)> _
    Public Overloads Function GetDecPorEst(ByVal Dec_Nit As String, ByVal dec_año As String, ByVal dec_est As String, ByVal Dec_Cdec As String) As DataTable

        Me.Conectar()
        Me.querystring = "Select *,Decl.TOTIMPUESTO(Dec_Cod) IMPUESTO,Decl.TOTSANCION(Dec_Cod) SANCION,Decl.TOTDeclarado(Dec_Cod) Declarado From vDeclaracion Where Dec_Nit=:Dec_Nit And Dec_Ano=:Dec_ano And Dec_Est=:Dec_Est And Dec_Cdec =:Dec_Cdec"
        CrearComando(querystring)

        AsignarParametroCadena(":Dec_Nit", Dec_Nit)
        AsignarParametroCadena(":Dec_ano", dec_año)
        AsignarParametroCadena(":Dec_Est", dec_est)
        AsignarParametroCadena(":Dec_Cdec", Dec_Cdec)


        Dim dataTb As DataTable = EjecutarConsultaDatatable

        Me.Desconectar()
        Return dataTb

    End Function
    <DataObjectMethodAttribute(DataObjectMethodType.Select, True)> _
    Public Overloads Function GetDecPorEst(ByVal Dec_Nit As String, ByVal dec_año As String, ByVal dec_est As String, ByVal Dec_Cdec As String, ByVal dec_per As String) As DataTable

        Me.Conectar()
        Me.querystring = "Select *,Decl.TOTIMPUESTO(Dec_Cod) IMPUESTO,Decl.TOTSANCION(Dec_Cod) SANCION,Decl.TOTDeclarado(Dec_Cod) Declarado From vDeclaracion Where Dec_Nit=:Dec_Nit And Dec_Ano=:Dec_ano And Dec_Est=:Dec_Est And Dec_Cdec =:Dec_Cdec and dec_per=:Dec_per"
        CrearComando(querystring)

        AsignarParametroCadena(":Dec_Nit", Dec_Nit)
        AsignarParametroCadena(":Dec_ano", dec_año)
        AsignarParametroCadena(":Dec_Est", dec_est)
        AsignarParametroCadena(":Dec_Cdec", Dec_Cdec)
        AsignarParametroCadena(":Dec_per", dec_per)


        Dim dataTb As DataTable = EjecutarConsultaDataTable()

        Me.Desconectar()
        Return dataTb

    End Function

    'SELECT DEC_COD,TDEC_NOM,DEC_ANO,DEC_PER,DEC_EST,DEC_PTOT,DEC_FDCO,DEC_FPRE,DEC_DOAD,DEC_BACO,DEC_CTA FROM VDECLARACION WHERE DEC_NIT LIKE '%'||:N||'%' AND DEC_CDEC LIKE '%'||:C||'%' AND DEC_ANO LIKE '%'||:A||'%' AND DEC_PER LIKE '%'||:P||'%'

    <DataObjectMethodAttribute(DataObjectMethodType.Select, True)> _
    Public Overloads Function GetDecPorEst_LK(ByVal car_Nit As String, ByVal car_ano As String, ByVal car_Cdec As String, ByVal car_per As String) As DataTable

        Me.Conectar()
        'me.querystring = "Select DEC_COD,TDEC_NOM,DEC_ANO,DEC_PER,DEC_EST,DEC_PTOT,DEC_FDCO,DEC_FPRE,DEC_DOAD,DEC_BACO,DEC_CTA,Decl.TOTIMPUESTO(Dec_Cod) IMPUESTO,Decl.TOTSANCION(Dec_Cod) SANCION,Decl.TOTDeclarado(Dec_Cod) Declarado From vDeclaracion Where DEC_NIT LIKE '%'||:N||'%' AND DEC_CDEC LIKE '%'||:C||'%' AND DEC_ANO LIKE '%'||:A||'%' AND DEC_PER LIKE '%'||:P||'%'"
        Me.querystring = "Select DEC_COD,TDEC_NOM,DEC_ANO,DEC_PER,DEC_EST,DEC_PTOT,DEC_FDCO,DEC_FPRE,DEC_DOAD,DEC_BACO,DEC_CTA,Decl.TOTIMPUESTO(Dec_Cod) IMPUESTO,Decl.TOTSANCION(Dec_Cod) SANCION,Decl.TOTDeclarado(Dec_Cod) Declarado From vDeclaracion Where DEC_NIT=:DEC_NIT AND DEC_CDEC=:DEC_CDEC AND DEC_ANO like '%' || :DEC_ANO || '%' AND DEC_PER like '%'|| :DEC_PER ||'%'"
        'me.querystring = "Select *,Decl.TOTIMPUESTO(Dec_Cod) IMPUESTO,Decl.TOTSANCION(Dec_Cod) SANCION,Decl.TOTDeclarado(Dec_Cod) Declarado From vDeclaracion Where DEC_NIT LIKE '%'||:N||'%' AND DEC_CDEC LIKE '%'||:C||'%' AND DEC_ANO LIKE '%'||:A||'%' AND DEC_PER LIKE '%'||:P||'%'"
        CrearComando(querystring)

        'dbCommand.BindByName = True
        AsignarParametroCadena(":DEC_NIT", car_Nit)
        AsignarParametroCadena(":DEC_CDEC", car_Cdec)
        AsignarParametroCadena(":DEC_ANO", car_ano)
        AsignarParametroCadena(":DEC_PER", car_per)


        Dim dataTb As DataTable = EjecutarConsultaDatatable

        Me.Desconectar()
        Return dataTb

    End Function
    Public Function Anular(ByVal Dec_Cod As String) As String
        Dim x As String
        Me.Conectar()
        Try
            ComenzarTransaccion()
            Me.querystring = "UPDATE DECLARACION SET DEC_EST='AN' WHERE DEC_COD='" + Dec_Cod + "' "
            CrearComando(querystring)
            x = EjecutarComando()
            Me.Msg = MsgOk + " Registros Actualizados [" + x + "]"
            Me.lErrorG = False
            ConfirmarTransaccion()
        Catch ex As Exception
            Me.lErrorG = True
            Me.Msg = "Error de App:" + ex.Message
            CancelarTransaccion()
        Finally
            Me.Desconectar()
        End Try
        Return Msg
    End Function

    Public Function Update_EstFis(ByVal Dec_Cod As String, ByVal DEC_ESTFIS As String) As String
        Dim x As String
        Me.Conectar()
        Try
            ComenzarTransaccion()
            Me.querystring = "UPDATE DECLARACION SET DEC_ESFI='" & DEC_ESTFIS & "' WHERE DEC_COD='" + Dec_Cod + "' "
            x = EjecutarComando
            Me.Msg = MsgOk + " Registros Actualizados [" + x + "]"
            Me.lErrorG = False
            ConfirmarTransaccion()
        Catch ex As Exception
            Me.lErrorG = True
            Me.Msg = "Error de App:" + ex.Message
            CancelarTransaccion()
        Finally
            Me.Desconectar()
        End Try
        Return Msg
    End Function

    Public Shared Function GetParametrosTar2(ByVal ClDec As String, ByVal Tipo_Agente As String, Optional ByVal tip_imp As String = "1") As String
        Dim Input_par As String = ""
        If ClDec = "01" Then ' Deguello
            Input_par = "Valor_Base Number:=1;Tipo_Acto Number:=1;"
        ElseIf ClDec = "02" Then 'Registro
            If Tipo_Agente = "12" Then
                Input_par = "Valor_Base Number:=1;Tipo Number:=1;"
            ElseIf Tipo_Agente = "13" Then
                Input_par = "Valor_Base Number:=1;Tipo Number:=2;"
            Else
                Input_par = "Valor_Base Number:=0;Tipo Number:=0;"
            End If
        Else 'Estampillas
            Input_par = String.Format("Valor_Base Number:=1;Tipo_Acto Number:={0};", tip_imp)
        End If
        Return Input_par
    End Function

    Public Function GetParametrosTar(ByVal ClDec As String, ByVal Tipo_Agente As String, Optional ByVal tip_imp As String = "1") As String

        Me.Conectar()
        Dim Input_par As String = ""
        Me.querystring = "tarifas_parametros"
        CrearComando(querystring, CommandType.StoredProcedure)
        Dim preturn As DbParameter = AsignarParametroReturn(100)
        AsignarParametroCad("cldec", ClDec)
        AsignarParametroCad("tipo_agente", Tipo_Agente)
        AsignarParametroCad("tip_imp", tip_imp)
        EjecutarComando()
        Input_par = pReturn.Value.ToString()
        Me.Desconectar()
        Return Input_par

    End Function

    <DataObjectMethodAttribute(DataObjectMethodType.Select, True)> _
    Public Overloads Function GetCargarTipoDecla() As DataTable
        Me.Conectar()
        Me.querystring = "SELECT * FROM vCLASE_DEC"
        CrearComando(querystring)
        Dim dataTb As DataTable = EjecutarConsultaDataTable()
        Me.Desconectar()
        Return dataTb
    End Function

    Public Function GetFecha_Limite_Dias_Calendario(ByVal Cla_Dec As String, ByVal AGravable As String, ByVal PGravable As String) As Date
        Dim objCal As Calendario = New Calendario
        objCal.Conexion = Me.Conexion
        Dim dtc As DataTable
        dtc = objCal.GetPorAñoyPer(Cla_Dec, AGravable, PGravable)
        'REVISAR SANCIONES E INTERESES
        Dim cal_ffin As Date = CDate(dtc.Rows(0)("Cal_Ffin").ToString())
        'Plazo de Ejecución
        Dim Plazo_dec As Integer = CInt(Me.GetPlazoDec(cal_ffin))
        'Fecha Limite
        Return cal_ffin.AddDays(Plazo_dec)
    End Function
    Public Function GetFecha_Limite_Fija(ByVal Cla_Dec As String, ByVal AGravable As String, ByVal PGravable As String) As Date
        Dim objCal As Calendario = New Calendario
        objCal.Conexion = Me.Conexion
        Dim dtc As DataTable
        dtc = objCal.GetPorAñoyPer(Cla_Dec, AGravable, PGravable)
        'REVISAR SANCIONES E INTERESES
        Return CDate(dtc.Rows(0)("Cal_FVen").ToString())
    End Function

    Public Function GetFecha_Limite(ByVal Cla_Dec As String, ByVal AGravable As String, ByVal PGravable As String) As Date
        Return GetFecha_Limite_Fija(Cla_Dec, AGravable, PGravable)
    End Function

    'agregada shirly
    Public Function GetCVMMLA(ByVal Fecha_Dec As Date) As String

        Me.Conectar()
        Me.querystring = "FN_LEER_PARA_LIQU"
        CrearComando(querystring, CommandType.StoredProcedure)
        Dim preturn As DbParameter = AsignarParametroReturn(20)
        AsignarParametroCad("PNOM", "CVMMLA")
        AsignarParametroCad("tipoPar", Me.Clase_Dec)
        Me.Msg = Me.Clase_Dec
        AsignarParametroFec("feFecha", Fecha_Dec)
        EjecutarComando()
        Me.Desconectar()
        Return preturn.Value.ToString()


    End Function


End Class
