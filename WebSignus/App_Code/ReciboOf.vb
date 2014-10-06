Imports Microsoft.VisualBasic
Imports System.Data
Imports System.ComponentModel
Imports System.Data.Common
Imports System

<DataObjectAttribute()> _
Public Class ReciboOf

    Inherits BDDatos2
    Dim Clase_Dec As String
    Public ROF_COD As String
    Public Sub New(ByVal Cla_Dec As String)
        Me.Clase_Dec = Cla_Dec
    End Sub
    Public Sub New()
        Me.Clase_Dec = "01"
    End Sub
    <DataObjectMethodAttribute(DataObjectMethodType.Select, True)> _
    Public Overloads Function GetByUser(Optional ByVal User As String = "") As DataTable
        'Si no recibe ningún Usuario, buscará los Datos del Usuario Conectado
        If User = "" Then
            User = Membership.GetUser.UserName
        End If
        Me.Conectar()
        Dim queryString As String = "SELECT * FROM vTerceros WHERE upper(Ter_usu)='" + UCase(User) + "'"
        CrearComando(queryString)
        Dim dataTb As DataTable = EjecutarConsultaDataTable()
        Me.Desconectar()
        Return dataTb
    End Function
    Public Function GetDecByPer(ByVal Dec_Nit As String, ByVal DEC_ANO As String, ByVal DEC_PER As String, ByVal Dec_Cdec As String) As DataTable
        Me.Conectar()

        Dim queryString As String = "Select * From vDeclaracion Where Dec_Cdec=:Dec_Cdec And Dec_Nit=:Dec_Nit And Dec_Ano= :Dec_Ano And Dec_per=:Dec_per And Dec_est IN('DF','PR','CR') Order by Dec_Cod Desc"
        CrearComando(queryString)
        AsignarParametroCadena(":Dec_Cdec", Dec_Cdec)
        AsignarParametroCadena(":Dec_Nit", Dec_Nit)
        AsignarParametroCadena(":Dec_Ano", DEC_ANO)
        AsignarParametroCadena(":Dec_per", DEC_PER)
        Dim dataSet As DataTable = EjecutarConsultaDataTable()

        Me.Desconectar()
        Return dataSet
    End Function
    Public Function GetFormularios_Dec(ByVal Año As String, ByVal Periodo As String) As DataSet
        Me.Conectar()
        Dim queryString As String = "Select * From Formularios_Dec f Where f.fode_cdec=:CDec And (Select cal_fini From Calendario Where Cal_Cla=f.fode_cdec And  Cal_Vig=:Cal_Vig And Cal_Per=:Cal_Per) Between f.fode_FEIN and f.fode_FEFI Order By fode_CDEC,fode_CODI"
        CrearComando(queryString)
        AsignarParametroCadena(":CDec", Me.Clase_Dec)
        AsignarParametroCadena(":Cal_Vig", Año)
        AsignarParametroCadena(":Cal_Per", Periodo)
        Dim dataSet As DataSet = EjecutarConsultaDataSet()
        Me.Desconectar()
        Return dataSet
    End Function
    <DataObjectMethodAttribute(DataObjectMethodType.Select, True)> _
    Public Overloads Function GetcargarTipoDecla() As DataTable
        Me.Conectar()
        Dim queryString As String = "SELECT * FROM vCLASE_DEC"
        CrearComando(queryString)
        Dim dataTb As DataTable = EjecutarConsultaDataTable()
        Me.Desconectar()
        Return dataTb

    End Function
    <DataObjectMethodAttribute(DataObjectMethodType.Select, True)> _
    Public Function GetCDEC_PorNit(ByVal Nit As String) As DataTable
        Me.Conectar()

        Dim queryString As String = "Select T.Ter_Nit,CD.CLD_Nom,CLD_COD From TER_DEC TD Inner Join Terceros T On TD.Tede_TNit=T.Ter_nit Inner Join Clase_Dec CD On CD.CLD_COD=TD.TEDE_CDEC Where T.Ter_Nit=:Ter_Nit"
        CrearComando(queryString)
        'And fode_CDEC=:CDEC
        AsignarParametroCadena(":Ter_Nit", Nit)
        Dim dataTb As DataTable = EjecutarConsultaDataTable()

        Me.Desconectar()
        Return dataTb
    End Function
    Public Function GetFormulariosByCod(ByVal fode_CODI As String) As DataTable
        Me.Conectar()
        Dim queryString As String = "Select * From Formularios_Dec f Where fode_CODI=:fode_CODI "
        CrearComando(queryString)
        'And fode_CDEC=:CDEC
        AsignarParametroCadena(":fode_CODI", fode_CODI)
        'dbCommand.Parameters.Add("CDec", OracleDbType.Varchar2, ParameterDirection.Input).Value = Me.Clase_Dec
        Dim dataTb As DataTable = EjecutarConsultaDataTable()
        Me.Desconectar()
        Return dataTb
    End Function
    <DataObjectMethodAttribute(DataObjectMethodType.Select, True)> _
    Public Overloads Function GetRenglones(ByVal FODE_CODI As String, ByVal Sec_Cod As String, ByVal Año As String, ByVal Periodo As String) As DataTable
        'ByVal Cla_Dec As String, ByVal Año As String, ByVal Periodo As String
        ', Optional ByVal Fec_Dec As Date = Now()
        Me.Conectar()
        'Select * from CONC_CDEC cc Where Cocd_cdec=:Cocd_cdec And (Select cal_fini From Calendario Where Cal_Cla=:Cocd_cdec And  Cal_Vig=:Cal_Vig And Cal_Per=:Cal_Per)  Between cc.conc_fein and cc.COCD_FEFI Order By COCD_CDEC,COCD_CODI
        'Dim queryString As String = "Select * from vLiqDec Where Cld_Cod=:CD "
        'Dim queryString As String = "Select * from CONC_CDEC c where c.cocd_cdec=:cdec and  c.COCD_SECO=:SECO Order By COCD_CDEC,COCD_CODI"
        Dim queryString As String = "Select * from VCONC_CDEC c where c.cocd_fdco=:cocd_fdco and  c.COCD_SECO=:SECO And (Select cal_fini From Calendario Where Cal_Cla=c.cocd_cdec And  Cal_Vig=:Cal_Vig And Cal_Per=:Cal_Per) Between c.COCD_FEIN and c.COCD_FEFI Order By COCD_CDEC,COCD_CODI"
        CrearComando(queryString)
        AsignarParametroCadena(":cocd_fdco", FODE_CODI)
        AsignarParametroCadena(":SECO", Sec_Cod)
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
        Dim queryString As String = "Select * from VCONC_CDEC c where c.cocd_cdec=:cdec and c.COCD_SECO=:Seco And c.cocd_fdco=:Fode_Codi Order By COCD_CDEC,COCD_CODI"
        CrearComando(queryString)
        AsignarParametroCadena(":cdec", Cla_Dec)
        AsignarParametroCadena(":Seco", Sec_Cod)
        AsignarParametroCadena(":Fode_Codi", Fode_Codi)
        Dim dataTb As DataTable = EjecutarConsultaDataTable()
        Me.Desconectar()
        Return dataTb

    End Function

    <DataObjectMethodAttribute(DataObjectMethodType.Select, True)> _
    Public Overloads Function GetRenglonesRP(ByVal Cla_Dec As String, ByVal Sec_Cod As String, ByVal Fode_Codi As String, ByVal año As String, ByVal per As String, ByVal nit As String) As DataTable

        'ByVal Cla_Dec As String, ByVal Año As String, ByVal Periodo As String
        ', Optional ByVal Fec_Dec As Date = Now()
        Dim obj As CDeclaraciones = New CDeclaraciones
        Dim dt As DataTable = obj.GetRenglones(Cla_Dec, Sec_Cod, Fode_Codi)

        Dim Val_Pago As Decimal = Me.Get_Val_pago(Cla_Dec, año, per, nit)

        dt.Rows(0)("cocd_vade") = Val_Pago
        dt.Rows(1)("cocd_vade") = Val_Pago
        dt.Rows(2)("cocd_vade") = Val_Pago

        Return dt
    End Function

    Public Function GetNomDec(ByVal cla_dec As String) As String

        Dim datat As New DataTable
        Me.Conectar()
        Dim queryString As String = "select Cld_NOM from clase_dec Where Cld_Cod=:CC"
        CrearComando(queryString)
        AsignarParametroCadena(":CC", cla_dec)
        datat = EjecutarConsultaDataTable()
        'Throw New Exception(vComando.CommandText)
        Dim r As String
        If datat.Rows.Count > 0 Then
            r = CStr(datat.Rows(0).Item(0).ToString)
        Else
            r = ""
        End If
        Me.Desconectar()
        Return r

    End Function
    Public Function GetDatos_Dec(ByVal DEC_PER As String, ByVal DEC_ANO As String, ByVal DEC_NIT As String, ByVal DEC_CDEC As String) As DataTable
        Dim datat As New Data.DataTable
        Me.Conectar()
        ' Dim queryString As String = "select * from declaracion  where DEC_PER=:DEC_PER AND  DEC_ANO=:DEC_ANO  AND DEC_NIT=:DEC_NIT AND DEC_CDEC=:DEC_CDEC AND DEC_EST='PR' "
        Dim queryString As String = "select sum(saldo) as car_sal, car_dcod, car_fnov, car_tdoc, car_est from vcarterad  where car_PER=:car_PER AND  car_ANO=:car_ANO  AND Car_NIT=:Car_NIT and car_cdec=:car_cedc group by car_dcod, car_fnov,car_tdoc, car_est"
        CrearComando(queryString)
        AsignarParametroCadena(":car_PER", DEC_PER)
        AsignarParametroCadena(":car_ANO", DEC_ANO)
        AsignarParametroCadena(":Car_NIT", DEC_NIT)
        AsignarParametroCadena(":car_cedc", DEC_CDEC)
        'Dim r As String = Convert.ToString(dbCommand.ExecuteScalar())
        Dim dataTb As DataTable = EjecutarConsultaDataTable()
        Me.Desconectar()
        Return dataTb
        'Me.Desconectar
        'Return r

    End Function
    Public Function Get_Val_pago(ByVal CDECC As String, ByVal CANO As String, ByVal CPER As String, ByVal CNIT As String) As Decimal

        ' Dim DTtab As DataTable = New DataTable
        Dim TotPagar As Decimal = 0
        Me.Conectar()
        Try
            Me.querystring = "CART.TotSaldoC"
            CrearComando(querystring, CommandType.StoredProcedure)

            Dim pReturn As DbParameter = AsignarParametroReturn(5000)
            AsignarParametroCad(":CDEC", CDECC)
            AsignarParametroCad(":CNIT", CNIT)
            AsignarParametroCad(":CANO", CANO)
            AsignarParametroCad(":CPER", CPER)
            EjecutarComando()
            'TotPagar = Trim(DirectCast((pReturn.Value), OracleString).ToString)
            TotPagar = CStr(pReturn.Value.ToString)
            Me.lErrorG = False
        Catch ex As Exception
            Me.lErrorG = True
            Me.Msg = "Error de App:" + ex.Message
        Finally
            Me.Desconectar()
        End Try
        Return TotPagar
    End Function
    Public Function Get_CapInt(ByVal CDECC As String, ByVal CANO As String, ByVal CPER As String, ByVal CNIT As String) As Decimal

        ' Dim DTtab As DataTable = New DataTable
        Dim TotPagar As Decimal = 0
        Me.Conectar()
        Try
            Me.querystring = "CART.TotSaldoCI"
            CrearComando(querystring, CommandType.StoredProcedure)

            Dim pReturn As DbParameter = AsignarParametroReturn(5000)
            AsignarParametroCad("CDEC", CDECC)
            AsignarParametroCad("CNIT", CNIT)
            AsignarParametroCad("CANO", CANO)
            AsignarParametroCad("CPER", CPER)

            EjecutarComando()
            'TotPagar = Trim(DirectCast((pReturn.Value), OracleString).ToString)
            TotPagar = CStr(pReturn.Value.ToString)
            Me.lErrorG = False
        Catch ex As Exception
            Me.lErrorG = True
            Me.Msg = "Error de App:" + ex.Message
        Finally
            Me.Desconectar()
        End Try
        Return TotPagar
    End Function
    Public Function Get_San(ByVal CDECC As String, ByVal CANO As String, ByVal CPER As String, ByVal CNIT As String) As Decimal

        ' Dim DTtab As DataTable = New DataTable
        Dim TotSan As Decimal = 0
        Me.Conectar()
        Try
            Me.querystring = "CART.TotSancion"
            CrearComando(querystring, CommandType.StoredProcedure)

            Dim pReturn As DbParameter = AsignarParametroReturn(5000)
            AsignarParametroCad("CDEC", CDECC)
            AsignarParametroCad("CNIT", CNIT)
            AsignarParametroCad("CANO", CANO)
            AsignarParametroCad("CPER", CPER)

            EjecutarComando()

            TotSan = CStr(pReturn.Value.ToString) 'Trim(DirectCast((pReturn.Value), OracleString).ToString)

            Me.lErrorG = False
        Catch ex As Exception
            Me.lErrorG = True
            Me.Msg = "Error de App:" + ex.Message
        Finally
            Me.Desconectar()
        End Try
        Return TotSan
    End Function
    Public Function Insert(ByVal ROF_NIT As String, ByVal ROF_PER As String, ByVal ROF_ANO As String, ByVal ROF_VPA As Decimal, ByVal ROF_INT As Decimal, ByVal ROF_CDEC As String, ByVal ROF_DECC As String, ByVal ROF_SAN As Decimal, ByVal ROF_TDOC As String, ByVal ROF_TROF As String) As String
        Me.Conectar()
        Dim na As Integer = 0
        Dim Str As String = ""
        ComenzarTransaccion()
        Try
            Me.ROF_COD = GetConsecutivo()
            Dim StrSql As String = "INSERT INTO RECOFICIAL ( ROF_NIT, ROF_PER, ROF_ANO, ROF_VPA, ROF_INT, ROF_COD, ROF_CDEC, ROF_DECC, ROF_FNOV,  ROF_USBD, ROF_EST, ROF_SAN, ROF_TDOC, ROF_TROF, ROF_TPAG, ROF_USAP ) VALUES "
            StrSql += "(:ROF_NIT, :ROF_PER, :ROF_ANO, :ROF_VPA, :ROF_INT, :ROF_COD, :ROF_CDEC, :ROF_DECC, SYSDATE, USER, :ROF_EST, :ROF_SAN, :ROF_TDOC, :ROF_TROF, :ROF_TPAG, :ROF_USAP)"
            'Str = StrSql
            CrearComando(StrSql)
            AsignarParametroCadena(":ROF_NIT", ROF_NIT)
            AsignarParametroCadena(":ROF_PER", ROF_PER)
            AsignarParametroCadena(":ROF_ANO", ROF_ANO)
            AsignarParametroDecimal(":ROF_VPA", ROF_VPA)
            AsignarParametroDecimal(":ROF_INT", ROF_INT)
            AsignarParametroCadena(":ROF_COD", Me.ROF_COD)
            AsignarParametroCadena(":ROF_CDEC", ROF_CDEC)
            AsignarParametroCadena(":ROF_DECC", ROF_DECC)
            AsignarParametroCadena(":ROF_EST", "DF")
            AsignarParametroDecimal(":ROF_SAN", ROF_SAN)
            AsignarParametroCadena(":ROF_TDOC", ROF_TDOC)
            AsignarParametroCadena(":ROF_TROF", ROF_TROF)
            AsignarParametroDecimal(":ROF_TPAG", CDbl(ROF_VPA) + CDbl(ROF_INT) + CDbl(ROF_SAN))
            AsignarParametroCadena(":ROF_USAP", Me.usuario)
            na = EjecutarComando()

            ConfirmarTransaccion()
            Me.Msg = "<BR> Número de Filas Afectadas " + na.ToString
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
    Public Function Insert2(ByVal ROF_NIT As String, ByVal ROF_PER As String, ByVal ROF_ANO As String, ByVal ROF_VPA As Decimal, ByVal ROF_INT As Decimal, ByVal ROF_CDEC As String, ByVal ROF_DECC As String, ByVal ROF_SAN As Decimal, ByVal ROF_TDOC As String) As String
        Me.Conectar()
        Dim na As Integer = 0
        Dim Str As String = ""
        ComenzarTransaccion()
        Try
            Me.ROF_COD = GetConsecutivo()
            Dim StrSql As String = "INSERT INTO RECOFICIAL (ROF_CONS, ROF_NIT, ROF_PER, ROF_ANO,ROF_VPA, ROF_INT, ROF_COD, ROF_CDEC, ROF_DECC, ROF_FNOV,  ROF_USBD, ROF_EST, ROF_SAN, ROF_TDOC, ROF_TROF, ROF_TPAG, ROF_USAP ) VALUES "
            StrSql += "(:ROF_CONS,:ROF_NIT, :ROF_PER, :ROF_ANO,:ROF_VPA, :ROF_INT, :ROF_COD, :ROF_CDEC, :ROF_DECC, SYSDATE, USER, :ROF_EST, :ROF_SAN, :ROF_TDOC, :ROF_TROF, :ROF_TPAG, :ROF_USAP)"
            Str = StrSql
            CrearComando(StrSql)
            AsignarParametroCadena(":ROF_CONS,", Me.ROF_COD)
            AsignarParametroCadena(":ROF_NIT", ROF_NIT)
            AsignarParametroCadena(":ROF_PER", ROF_PER)
            AsignarParametroCadena(":ROF_ANO", ROF_ANO)
            AsignarParametroDecimal(":ROF_VPA", ROF_VPA)
            AsignarParametroDecimal(":ROF_INT", ROF_INT)
            AsignarParametroCadena(":ROF_COD", ROF_COD)
            AsignarParametroCadena(":ROF_CDEC", ROF_CDEC)
            AsignarParametroCadena(":ROF_DECC", ROF_DECC)
            AsignarParametroCadena(":ROF_EST", "DF")
            AsignarParametroDecimal(":ROF_SAN", ROF_SAN)
            AsignarParametroCadena(":ROF_TDOC", ROF_TDOC)
            AsignarParametroCadena(":ROF_TROF", "ROPA")
            AsignarParametroDecimal(":ROF_TPAG", CDbl(ROF_VPA) + CDbl(ROF_INT) + CDbl(ROF_SAN))
            AsignarParametroCadena(":ROF_USAP", Me.usuario)
            na = EjecutarComando()
            ConfirmarTransaccion()
            Me.Msg = MsgOk + "<BR> Número de Filas Afectadas " + na.ToString
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

    Public Function GeneraCons(ByVal CONS_ID As String) As String
        Dim NroCons As Decimal = 0
        Dim obj As Consecutivos = New Consecutivos
        Dim vig As Vigencias = New Vigencias
        NroCons = obj.GetConsec("ROPA", vig.GetActivaD)
        Return NroCons
    End Function


    Function GetConsecutivo() As String

        Dim ObjC As Consecutivos = New Consecutivos
        Dim vig As Vigencias = New Vigencias
        Dim num As String
        Dim svig As String = vig.GetActivaD()
        num = svig + "99" + ObjC.GetConsec("ROPA", svig).PadLeft(5, "0")
        Return num
    End Function

    Private Sub InsertLP(ByVal nro_dec As String, ByVal aLp() As LPCODE_CDEC, ByVal Estado As String)
        Dim StrSql As String = "Insert into CON_ROF (CORP_CDEC,CORP_CODI,CORP_TICO,CORP_NOMB,CORP_TMOV,CORP_ABVB,CORP_VADE,CORP_ABVD,CORP_VACA,CORP_SECO,CORP_TARI,CORP_IMPTO,CORP_TSAN,CORP_CART,CORP_VABA,CORP_ISVB,CORP_REDE,CORP_DENR,CORP_VASU,CORP_VAOF,CORP_USBD,CORP_USAP,CORP_DEES,CORP_FREG,CORP_CCAR,CORP_SUM,CORP_VIG,CORP_DCOD) "
        StrSql += "Values(:CORP_CDEC,:CORP_CODI,:CORP_TICO,:CORP_NOMB,:CORP_TMOV,:CORP_ABVB,:CORP_VADE,:CORP_ABVD,:CORP_VACA,:CORP_SECO,:CORP_TARI,:CORP_IMPTO,:CORP_TSAN,:CORP_CART,:CORP_VABA,:CORP_ISVB,:CORP_REDE,:CORP_DENR,:CORP_VASU,:CORP_VAOF,User,:CORP_USAP,:CORP_DEES,SYSDATE,:CORP_CCAR,:CORP_SUM,VigenciaActual,:CORP_DCOD)"
        Dim na As Integer = 0
        For i As Integer = 0 To aLp.Length - 1
            CrearComando(StrSql)

            'dbCommand2.Parameters.Add("CORP_CDEC", OracleDbType.Varchar2, ParameterDirection.Input).Value = Me.Clase_Dec
            'dbCommand2.Parameters.Add("CORP_CODI", OracleDbType.Varchar2, ParameterDirection.Input).Value = aLp(i).CORP_CODI
            'dbCommand2.Parameters.Add("CORP_TICO", OracleDbType.Varchar2, ParameterDirection.Input).Value = aLp(i).CORP_TICO
            'dbCommand2.Parameters.Add("CORP_NOMB", OracleDbType.Varchar2, ParameterDirection.Input).Value = aLp(i).CORP_NOMB
            'dbCommand2.Parameters.Add("CORP_TMOV", OracleDbType.Varchar2, ParameterDirection.Input).Value = aLp(i).CORP_TMOV
            'dbCommand2.Parameters.Add("CORP_ABVB", OracleDbType.Varchar2, ParameterDirection.Input).Value = aLp(i).CORP_ABVB
            'dbCommand2.Parameters.Add("CORP_VADE", OracleDbType.Decimal, ParameterDirection.Input).Value = aLp(i).CORP_VADE
            'dbCommand2.Parameters.Add("CORP_ABVD", OracleDbType.Varchar2, ParameterDirection.Input).Value = aLp(i).CORP_ABVD
            'dbCommand2.Parameters.Add("CORP_VACA", OracleDbType.Decimal, ParameterDirection.Input).Value = aLp(i).CORP_VACA
            'dbCommand2.Parameters.Add("CORP_SECO", OracleDbType.Varchar2, ParameterDirection.Input).Value = aLp(i).CORP_SECO
            'dbCommand2.Parameters.Add("CORP_TARI", OracleDbType.Decimal, ParameterDirection.Input).Value = aLp(i).CORP_TARI
            'dbCommand2.Parameters.Add("CORP_IMPTO", OracleDbType.Varchar2, ParameterDirection.Input).Value = aLp(i).CORP_IMPTO
            'dbCommand2.Parameters.Add("CORP_TSAN", OracleDbType.Varchar2, ParameterDirection.Input).Value = aLp(i).CORP_TSAN
            'dbCommand2.Parameters.Add("CORP_CART", OracleDbType.Varchar2, ParameterDirection.Input).Value = aLp(i).CORP_CART
            'dbCommand2.Parameters.Add("CORP_VABA", OracleDbType.Decimal, ParameterDirection.Input).Value = aLp(i).CORP_VABA
            '   'dbCommand2.Parameters.Add("CORP_ISVB", OracleDbType.Varchar2, ParameterDirection.Input).Value = aLp(i).CORP_ISVB
            '  dbCommand2.Parameters.Add("CORP_REDE", OracleDbType.Varchar2, ParameterDirection.Input).Value = aLp(i).CORP_REDE
            ' dbCommand2.Parameters.Add("CORP_DENR", OracleDbType.Varchar2, ParameterDirection.Input).Value = nro_dec
            'dbCommand2.Parameters.Add("CORP_VASU", OracleDbType.Decimal, ParameterDirection.Input).Value = aLp(i).CORP_VASU
            '    dbCommand2.Parameters.Add("CORP_VAOF", OracleDbType.Decimal, ParameterDirection.Input).Value = aLp(i).CORP_VAOF
            '   dbCommand2.Parameters.Add("CORP_USAP", OracleDbType.Varchar2, ParameterDirection.Input).Value = Me.usuario
            '  dbCommand2.Parameters.Add("CORP_DEES", OracleDbType.Varchar2, ParameterDirection.Input).Value = Estado
            ' dbCommand2.Parameters.Add("CORP_CCAR", OracleDbType.Varchar2, ParameterDirection.Input).Value = aLp(i).CORP_CCAR
            'dbCommand2.Parameters.Add("CORP_SUM", OracleDbType.Varchar2, ParameterDirection.Input).Value = aLp(i).CORP_SUM
            ' dbCommand2.Parameters.Add("CORP_DCOD", OracleDbType.Varchar2, ParameterDirection.Input).Value = Me.DEC_COD

            na += EjecutarComando()
        Next

    End Sub

    Public Function Get_IntAnt(ByVal CDECC As String, ByVal CANO As String, ByVal CPER As String, ByVal CNIT As String) As Decimal

        ' Dim DTtab As DataTable = New DataTable
        Dim TotPagar As Decimal = 0
        Me.Conectar()
        Try
            Me.querystring = "CART.TotInteres"
            CrearComando(querystring, CommandType.StoredProcedure)

            Dim pReturn As DbParameter = AsignarParametroReturn(5000)
            AsignarParametroCad("CDEC", CDECC)
            AsignarParametroCad("CNIT", CNIT)
            AsignarParametroCad("CANO", CANO)
            AsignarParametroCad("CPER", CPER)

            EjecutarComando()

            'TotPagar = Trim(DirectCast((pReturn.Value), OracleString).ToString)
            TotPagar = CStr(pReturn.Value.ToString)

            Me.lErrorG = False
        Catch ex As Exception
            Me.lErrorG = True
            Me.Msg = "Error de App:" + ex.Message
        Finally
            Me.Desconectar()
        End Try
        Return TotPagar
    End Function
    <DataObjectMethodAttribute(DataObjectMethodType.Select, True)> _
    Public Overloads Function GetRecOfRpt(ByVal Dec_Cod As String) As DataSet
        Me.Conectar()
        'Dim queryString As String = "SELECT to_number(dec_nro)dec_nro,*  FROM  vDeclaracion"
        'Dim queryString As String = "Select to_number(dec_nro)dec_nro,* From vDeclaracion,copias_rpt  Where Dec_Nro=:Dec_Nro And dec_cdec=:dec_cdec Order by to_number(Cop_Cod) asc "
        Dim queryString As String = "Select *  From vRECOFICIAL, copias_rpt  Where ROF_COD=:ROF_COD Order by to_number(Cop_Cod) asc"
        CrearComando(queryString)
        AsignarParametroCadena(":ROF_COD", Dec_Cod)
        Dim dataSet As DataSet = EjecutarConsultaDataSet()
        Me.Desconectar()
        Return dataSet
    End Function
    <DataObjectMethodAttribute(DataObjectMethodType.Select, True)> _
    Public Overloads Function GetRecords(ByVal ROF_COD As String) As DataSet
        Me.Conectar()
        Dim queryString As String = "select  * from vrecoficial where ROF_COD=:ROF_COD"
        CrearComando(queryString)
        AsignarParametroCadena(":ROF_CONS", ROF_COD)
        Dim dataSet As DataSet = EjecutarConsultaDataSet()
        Me.Desconectar()
        Return dataSet
    End Function
    <DataObjectMethodAttribute(DataObjectMethodType.Select, True)> _
    Public Function GetPagadoPorCodigo(ByVal ROF_COD As String) As DataTable
        Me.Conectar()
        Dim queryString As String = "select  * from vrecoficial where ROF_COD=:ROF_COD AND ROF_EST = 'PR'"
        CrearComando(queryString)
        AsignarParametroCadena(":ROF_COD", ROF_COD)
        Dim oData As DataTable = EjecutarConsultaDataTable()
        Me.Desconectar()
        Return oData
    End Function
    <DataObjectMethodAttribute(DataObjectMethodType.Select, True)> _
    Public Overloads Function GetRecordsDF(ByVal ROF_COD As String) As DataTable
        Me.Conectar()
        Me.querystring = "select  * from VRECOFICIAL2 where ROF_COD = '" & ROF_COD & "' AND ROF_EST='DF'"
        CrearComando(Me.querystring)
        'AsignarParametroCadena(":ROF_CONS", ROF_COD)
        Dim data As DataTable = EjecutarConsultaDataTable()
        Me.Desconectar()
        Return data
    End Function

    <DataObjectMethodAttribute(DataObjectMethodType.Select, True)> _
    Public Overloads Function GetParametrizado(ByVal ROF_NIT As String, ByVal ROF_COD As String, ByVal ROF_EST As String, _
                                               ByVal ROF_DECC As String, ByVal ROF_FREG_INI As String, ByVal ROF_FREG_FIN As String, _
                                               ByVal ROF_TDOC As String) As DataTable
        Me.Conectar()
        Me.querystring = "select  * from VRECOFICIAL2 WHERE ROF_NIT = '" & ROF_NIT & "'"
        If Not String.IsNullOrEmpty(ROF_COD) Then
            Me.querystring = Me.querystring + " AND ROF_COD = '" & ROF_COD & "'"
        End If
        If Not String.IsNullOrEmpty(ROF_EST) Then
            Me.querystring = Me.querystring + " AND ROF_EST = '" & ROF_EST & "'"
        End If
        If Not String.IsNullOrEmpty(ROF_DECC) Then
            Me.querystring = Me.querystring + " AND ROF_DECC = '" & ROF_DECC & "' AND ROF_TDOC = '" + ROF_TDOC + "'"
        End If
        If Not String.IsNullOrEmpty(ROF_FREG_INI) And Not String.IsNullOrEmpty(ROF_FREG_FIN) Then
            Me.querystring = Me.querystring + " AND ROF_FREG_INI = '" & ROF_FREG_INI & "' AND '" + ROF_FREG_FIN + "'"
        End If
        CrearComando(Me.querystring)
        Dim data As DataTable = EjecutarConsultaDataTable()
        Me.Desconectar()
        Return data
    End Function

    Public Function Aplicar_pago(ByVal nro_rec As String, ByVal fecha_pago As Date, ByVal ban_cod As String, ByVal ban_cta As String, ByVal tip_rec As String) As String

        Me.Conectar()
        Dim na As Integer = 0
        Dim Str As String = ""
        ComenzarTransaccion()
        Try
            If tip_rec = "ROPA" Then
                Me.querystring = "Decl.PAGAR_ROPA"
            ElseIf tip_rec = "ROAP" Then
                Me.querystring = "PkAcPa.Aplicar_Pago"
            End If
            CrearComando(querystring, CommandType.StoredProcedure)
            AsignarParametroCad("nro_rec", nro_rec)
            AsignarParametroFec("fecha_pago", fecha_pago)
            AsignarParametroCad("ban_cod", ban_cod)
            AsignarParametroCad("ban_cta", ban_cta)
            EjecutarComando()
            ConfirmarTransaccion()
            Me.Msg = Me.MsgOk
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

    Public Function GetDistribucionROAP(ByVal ValCuota As Decimal, ByVal Nit As String, ByVal NumAcuerdo As String) As DataTable
        Me.Conectar()
        Me.querystring = "SELECT  TCON_NOM, car_tcon, SUM(saldo), ROUND(SUM (saldo)/(SELECT SUM (saldo) FROM vcarterad WHERE car_nit = '" & Nit & "' AND " & _
        "(car_per, car_ano, car_cdec) IN (SELECT apg_pgra, apg_agra, apg_cdec FROM acpa_apg WHERE apg_apnu = '" & NumAcuerdo & "')), 2) dist," & _
        ValCuota.ToString & "*ROUND(SUM (saldo)/(SELECT SUM (saldo) FROM vcarterad WHERE car_nit = '" & Nit & "' AND (car_per, car_ano, car_cdec) " & _
        "IN (SELECT apg_pgra, apg_agra, apg_cdec FROM acpa_apg WHERE apg_apnu = '" & NumAcuerdo & "')), 2) val_pag FROM vcarterad, TIPO_CONCEPTOS " & _
        "WHERE car_nit = '" & Nit & "' AND (car_per, car_ano, car_cdec) IN (SELECT apg_pgra, apg_agra, apg_cdec FROM acpa_apg " & _
        "WHERE apg_apnu = '" & NumAcuerdo & "') AND CAR_TCON = TCON_COD GROUP BY TCON_NOM, car_tcon"
        Me.CrearComando(Me.querystring)
        Dim dt As DataTable = EjecutarConsultaDataTable()
        Me.Desconectar()
        Return dt
    End Function
End Class