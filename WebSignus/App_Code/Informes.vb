Imports Microsoft.VisualBasic
Imports System.Data
Imports System.ComponentModel
Imports System.Data.Common
Imports System

<DataObjectAttribute()> _
Public Class Informes

    Inherits BDDatos2
    Dim Clase_Dec As String
    Public x As String
    Public FEC_I As Date
    Public FEC_F As Date
    Public Sub New(ByVal Cla_Dec As String)
        Me.Clase_Dec = Cla_Dec
    End Sub
    Public Sub New()
        'Me.Clase_Dec = "01"
    End Sub

    Public Function Get_NoDeclarantes(ByVal DEC_PER As String, ByVal DEC_ANO As String, ByVal TER_MPIO As String, ByVal DEC_EST As String, Optional ByVal MOSTRAR As String = "NO") As DataTable
        Dim DTtab As DataTable = New DataTable
        Me.Conectar()
        Dim Negacion As String = IIf(MOSTRAR = "SI", " ", " NOT ")
        'Try
        Dim queryString As String = "SELECT *  FROM  vTERCEROS INNER JOIN TER_DEC ON TEDE_TNIT=TER_NIT WHERE TEDE_CDEC=:DEC_CDEC AND TER_EST='AC' AND TER_TUS='AR' "
        If TER_MPIO <> "" Then
            queryString += " AND TER_MPIO=:TER_MPIO "
        End If
        queryString += " AND TER_NIT " + Negacion + " IN (SELECT DEC_NIT FROM vDECLARACION WHERE DEC_PER=:DEC_PER AND DEC_ANO=:DEC_ANO AND DEC_CDEC=:DEC_CDEC AND DEC_EST='" + DEC_EST + "') "
        CrearComando(queryString)


        AsignarParametroCadena(":DEC_CDEC", Me.Clase_Dec)
        AsignarParametroCadena(":DEC_CDEC", Me.Clase_Dec)

        If TER_MPIO <> "" Then
            AsignarParametroCadena(":TER_MPIO", TER_MPIO)
        End If
        AsignarParametroCadena(":DEC_PER", DEC_PER)
        AsignarParametroCadena(":DEC_ANO", DEC_ANO)
        'dbCommand.Parameters.Add("DEC_EST", OracleDbType.Varchar2, ParameterDirection.Input).Value = DEC_EST
        'Throw New Exception(Me.vComando.CommandText)

        DTtab = EjecutarConsultaDataTable()
        Me.Desconectar()
        Me.lErrorG = False
        Return DTtab

    End Function

    <DataObjectMethodAttribute(DataObjectMethodType.Select, True)> _
    Public Overloads Function GetPErClaseDec(ByVal Cla_Dec As String, ByVal Vigencia As String) As DataTable

        Me.Conectar()
        Dim queryString As String = "Select cal_per, cal_per||'-'||cal_des cal_des From vCalendarioDEC WHERE Cld_COD=:Cld_COD AND CAL_VIG=:CLA_VIG Order By cal_per"
        CrearComando(queryString)
        AsignarParametroCadena(":Cld_COD", Cla_Dec)
        AsignarParametroCadena(":CLA_VIG", Vigencia)
        Dim dataTb As DataTable = EjecutarConsultaDataTable()
        Me.Desconectar()
        Return dataTb

    End Function
    <DataObjectMethodAttribute(DataObjectMethodType.Select, True)> _
    Public Overloads Function GetcargarTipoDecla() As DataTable
        Me.Conectar()
        Dim queryString As String = "SELECT * FROM vCLASE_DEC2"
        CrearComando(queryString)
        Dim dataTb As DataTable = EjecutarConsultaDataTable()
        Me.Desconectar()
        Return dataTb

    End Function

    <DataObjectMethodAttribute(DataObjectMethodType.Select, True)> _
    Public Overloads Function GetVigencias(ByVal Cla_Dec As String) As DataTable

        Me.Conectar()
        Dim queryString As String = "Select * From vCalendarioVig WHERE Cal_cla=:Cal_cla Order By cal_vig"
        CrearComando(queryString)
        AsignarParametroCadena(":Cal_cla", Cla_Dec)
        Dim dataTb As DataTable = EjecutarConsultaDataTable()
        Me.Desconectar()
        Return dataTb

    End Function

    <DataObjectMethodAttribute(DataObjectMethodType.Select, True)> _
    Public Overloads Function GetDecInexactas(ByVal Cla_Dec As String, ByVal Est_Fis As String) As DataTable

        Me.Conectar()


        Dim queryString As String = "SELECT d.*,f.Saldo_dif FROM vdeclaracion d INNER JOIN vdecfisc_2 f ON f.code_dcod = d.dec_cod Where d.Dec_EsFi=:Dec_EsFi And d.Dec_Cdec=:Dec_Cdec"
        CrearComando(queryString)
        AsignarParametroCadena(":Dec_EsFi", Est_Fis)
        AsignarParametroCadena(":Dec_Cdec", Cla_Dec)
        Dim dataTb As DataTable = EjecutarConsultaDataTable()
        Me.Desconectar()
        Return dataTb

    End Function
    <DataObjectMethodAttribute(DataObjectMethodType.Select, True)> _
    Public Overloads Function GetDecInexactasPorCod(ByVal Dec_Cod As String) As DataTable

        Me.Conectar()
        Dim queryString As String = "SELECT * FROM vdeclaracion Where dec_cod =:dec_cod"
        CrearComando(queryString)
        AsignarParametroCadena(":Dec_Cod", Dec_Cod)
        Dim dataTb As DataTable = EjecutarConsultaDataTable()
        Me.Desconectar()
        Return dataTb

    End Function


    <DataObjectMethodAttribute(DataObjectMethodType.Select, True)> _
    Public Overloads Function GetDecInexactasD(ByVal Dec_Cod As String) As DataTable

        Me.Conectar()


        Dim queryString As String = "select  CODE_CODI,CODE_NOMB,CODE_TICO,CODE_VABA,CODE_VBCA,CODE_TARI,CODE_TACA,CODE_VADE,CODE_VACA,DIF_VABA,DIF_TARI,DIF_VADE  from vcode_cdec_fisc  where code_dcod=:Dec_Cod"
        CrearComando(queryString)
        AsignarParametroCadena(":Dec_Cod", Dec_Cod)
        Dim dataTb As DataTable = EjecutarConsultaDataTable()
        Me.Desconectar()
        Return dataTb

    End Function


    'select * from vcode_cdec_fisc  where code_dcod='20101100001'

    Public Function Get_NoDecPer(ByVal DEC_PER As String, ByVal DEC_ANO As String, ByVal DEC_MPIO As String, ByVal DEC_EST As String, ByRef m As String) As DataTable
        Dim DTtab As DataTable = New DataTable
        Me.Conectar()
        Try
            Me.querystring = "PKCONS.CONS3"
            CrearComando(querystring, CommandType.StoredProcedure)
            Dim pReturn As DbParameter = AsignarParametroReturn(5000)
            AsignarParametroCad("CDEC", DEC_PER)
            AsignarParametroCad("AGRA", DEC_ANO)
            AsignarParametroCad("EST", DEC_EST)
            AsignarParametroCad("CMPIO", DEC_MPIO)
            EjecutarComando()
            querystring = Trim(CStr(pReturn.Value.ToString))
            m = querystring
            CrearComando(querystring)
            DTtab = EjecutarConsultaDataTable()
            Me.Desconectar()
            Me.lErrorG = False
        Catch ex As Exception
            Me.lErrorG = True
            Me.Msg = "Error de App:" + ex.Message
        Finally
            Me.Desconectar()
        End Try
        Return DTtab

    End Function

    Public Function Get_DecxPer(ByVal DEC_PER As String, ByVal DEC_ANO As String, ByVal DEC_MPIO As String, ByRef m As String) As DataTable
        Dim DTtab As DataTable = New DataTable
        Me.Conectar()
        Try
            Me.querystring = "PKCONS.CONS4"
            CrearComando(querystring, CommandType.StoredProcedure)
            Dim pReturn As DbParameter = AsignarParametroReturn(10000)
            AsignarParametroCad("CDEC", DEC_PER)
            AsignarParametroCad("AGRA", DEC_ANO)
            AsignarParametroCad("CMPIO", DEC_MPIO)
            EjecutarComando()
            querystring = Trim(CStr(pReturn.Value.ToString))
            m = querystring
            CrearComando(querystring)
            DTtab = EjecutarConsultaDataTable()
            Me.lErrorG = False
        Catch ex As Exception
            Me.lErrorG = True
            Me.Msg = "Error de App:" + ex.Message
        Finally
            Me.Desconectar()
        End Try

        Return DTtab

    End Function

    Public Function Get_Ingresos(ByVal MOV_CDEC As String, ByVal MOV_PER As String, ByVal MOV_AÑO As String, ByVal PAG_CTAB As String, ByVal PAG_BACO As String, ByVal COD_REF As String, ByVal FI As Date, ByVal FF As Date, ByVal isFecha As Boolean, ByVal TER_MPIO As String, ByRef st As String) As DataTable
        Dim DTtab As DataTable = New DataTable
        Me.Conectar()
        Try

            Dim queryString As String = "SELECT *  FROM  vINGRESOS WHERE 0=0 "

            If MOV_CDEC <> "" Then
                queryString += " AND MOV_CDEC=:MOV_CDEC"
            End If

            If MOV_PER <> "" And MOV_AÑO <> "" Then
                queryString += " AND MOV_PER=:MOV_PER  AND MOV_AÑO=:MOV_AÑO"
            End If
            If PAG_CTAB <> "" And PAG_BACO <> "" Then
                queryString += " AND PAG_CTAB=:PAG_CTAB AND PAG_BACO=:PAG_BACO"
            End If

            If COD_REF <> "" Then
                queryString += " AND MOV_CCAR=:MOV_CCAR"
            End If
            If isFecha Then
                queryString += "AND FEC_MOV BETWEEN TO_DATE(:FI ,'dd/mm/yyyy')AND TO_DATE(:FF ,'dd/mm/yyyy')"
                'queryString += " AND FEC_MOV BETWEEN :FI AND :FF "
            End If

            If TER_MPIO <> "" Then
                queryString += " AND TER_MPIO=:TER_MPIO "
            End If

            st = "xxx"
            x = queryString


            CrearComando(queryString)
            If MOV_CDEC <> "" Then
                AsignarParametroCadena(":MOV_CDEC", Me.Clase_Dec)
            End If
            If MOV_PER <> "" And MOV_AÑO <> "" Then
                AsignarParametroCadena(":MOV_PER", MOV_PER)
                AsignarParametroCadena(":MOV_AÑO", MOV_AÑO)
            End If
            If PAG_CTAB <> "" And PAG_BACO <> "" Then
                AsignarParametroCadena(":PAG_CTAB", PAG_CTAB)
                AsignarParametroCadena(":PAG_BACO", PAG_BACO)
            End If
            If COD_REF <> "" Then
                AsignarParametroCadena(":MOV_CCAR", COD_REF)
            End If
            If isFecha Then
                AsignarParametroCadena(":FI", FI)
                AsignarParametroCadena(":FF", FF)
            End If
            If TER_MPIO <> "" Then
                AsignarParametroCadena(":TER_MPIO", TER_MPIO)
            End If

            'Throw New Exception(queryString + "-" + isFecha.ToString)

            DTtab = EjecutarConsultaDataTable()
            Me.Desconectar()
            Me.lErrorG = False
        Catch ex As Exception
            Me.lErrorG = True
            Me.Msg = "Error de App:" + ex.Message
        Finally
            Me.Desconectar()
        End Try
        Return DTtab

    End Function
    <DataObjectMethodAttribute(DataObjectMethodType.Select, True)> _
    Public Overloads Function GetConceptos() As DataTable
        Me.Conectar()
        Dim queryString As String = "SELECT * FROM CONC_CART"
        CrearComando(queryString)
        Dim dataTb As DataTable = EjecutarConsultaDataTable()
        Me.Desconectar()
        Return dataTb

    End Function
    <DataObjectMethodAttribute(DataObjectMethodType.Select, True)> _
    Public Overloads Function GetBancos() As DataTable
        Me.Conectar()
        Dim queryString As String = "SELECT * FROM BANCOS"
        CrearComando(queryString)
        Dim dataTb As DataTable = EjecutarConsultaDataTable()
        Me.Desconectar()
        Return dataTb

    End Function
    <DataObjectMethodAttribute(DataObjectMethodType.Select, True)> _
    Public Overloads Function GetCta(ByVal CTA_BACO As String) As DataTable
        Me.Conectar()
        Dim queryString As String = "SELECT * FROM CTA_BANCO  WHERE  CTA_BACO=:CTA_BACO"
        CrearComando(queryString)
        AsignarParametroCadena(":CTA_BACO", CTA_BACO)
        Dim dataTb As DataTable = EjecutarConsultaDataTable()
        Me.Desconectar()
        Return dataTb
    End Function
    Public Function Get_MovIng(ByVal Filtro As String, ByVal Tipo_Grupo As String) As DataTable
        Dim DTtab As DataTable = New DataTable
        Me.Conectar()
        Dim cFiltro As String = IIf(Filtro <> "", " Where " + Filtro, "")
        Try
            If Tipo_Grupo = "D" Then
                querystring = "select MOV_AÑO  as ano ,MOV_PER||'-'||cal_des as mes, mov_ccar, CCAR_NOM, sum(VALOR)from (select fec_mov,  mov_ccar, MOV_AÑO,  VALOR , CCAR_NOM, mov_cdec,MOV_PER,cal_des  from vIngresosv02 " + cFiltro + ")  group by  MOV_AÑO, MOV_PER||'-'||cal_des, mov_ccar, CCAR_NOM order by mes, mov_ccar "
            Else
                querystring = "select to_Char(fec_mov,'yyyy')  as ano ,to_Char(fec_mov,'mm')||'-'||to_Char(fec_mov,'MONTH') as mes, mov_ccar, CCAR_NOM, sum(VALOR) SUM_VALOR from (select fec_mov,  mov_ccar, MOV_AÑO,  VALOR , CCAR_NOM, mov_cdec,cal_des  from vIngresosv02 " + cFiltro + ")  group by  to_Char(fec_mov,'yyyy'), to_Char(fec_mov,'mm')||'-'||to_Char(fec_mov,'MONTH'), mov_ccar, CCAR_NOM order by mes, mov_ccar "
            End If
            CrearComando(querystring)
            DTtab = EjecutarConsultaDataTable()
            Me.Desconectar()
            Me.lErrorG = False
        Catch ex As Exception
            Me.lErrorG = True
            Me.Msg = "Error de App:" + ex.Message
        Finally
            Me.Desconectar()
        End Try
        Return DTtab

    End Function

    <DataObjectMethodAttribute(DataObjectMethodType.Select, True)> _
    Public Function GetSaldosPorConc(ByVal Dec_Cdec As String, ByVal Fec_Ini As Date, ByVal Fec_Fin As Date) As DataTable

        Me.Conectar()

        '        queryString = "Select CCar_Cod ""Código"",CCar_Nom, NVL(Saldo_Inicial,0) Saldo_Inicial,DB,CR, Abs(NVL(Saldo_Inicial,0)+DB-CR)  Saldo_Final"
        queryString = "Select CCar_Cod ""Código"",CCar_Nom ""Concepto"", NVL(Saldo_Inicial,0) ""Saldo Inicial"",Nvl(DB,0) ""Débito"",Nvl(CR,0) ""Créditos"", Abs(NVL(Saldo_Inicial,0)+DB-CR)  ""Saldo Final"" "
        queryString += " From Conc_Cart CC Left Join "
        queryString += " (Select Mov_CCar,Nvl(Sum(Mov_Vdb),0) DB,Nvl(Sum(Mov_VCr),0) CR From(Movimiento) Where Mov_FMov BetWeen to_date('" + Fec_Ini.ToShortDateString + "','dd/mm/yyyy') And  to_date('" + Fec_Fin.ToShortDateString + "','dd/mm/yyyy') Group By Mov_CCar) M"
        queryString += " ON CC.CCar_Cod=Mov_CCar "
        queryString += " Left Join ("
        queryString += " Select mv.Mov_Ccar,Nvl(Sum(mv.Mov_Vdb-mv.Mov_Vcr),0) Saldo_Inicial From movimiento mv Where mv.mov_fmov < to_date('" + Fec_Ini.ToShortDateString + "','dd/mm/yyyy') Group by mv.Mov_Ccar "
        queryString += " ) MSa On MSa.Mov_Ccar=M.Mov_Ccar "
        'queryString += " Where CCar_Cdec='" + Dec_Cdec + "'"

        CrearComando(queryString)
        'AsignarParametroFecha(":FI", Fec_Ini)
        'AsignarParametroFecha(":FF", Fec_Fin)
        'AsignarParametroCadena(":CDEC", Dec_Cdec)
        'Throw New Exception(vComando.CommandText)
        Dim dataTb As DataTable = EjecutarConsultaDataTable()
        Me.Desconectar()
        Return dataTb

    End Function

    Public Function Get_Ing_Agen(ByVal mov_per As String, ByVal mov_año As String, ByVal mov_cdec As String, ByVal mov_ccar As String, ByVal FI As Date, ByVal FF As Date, ByVal MOV_NIT As String) As DataTable

        Dim DTtab As DataTable = New DataTable
        Dim queryString As String

        'Try ---800096610
        Me.Conectar()
        queryString = "SELECT  FEC_MOV, FEC_SIS, MOV_CDEC, MOV_CCAR, CCAR_NOM,MOV_TDOC, MOV_NDOC, MOV_AÑO, MOV_PER, VALOR,CLD_NOM FROM vingresosv02 WHERE "
        'queryString += "  MOV_NIT='" + MOV_NIT + "' "
        queryString += "  FEC_MOV BETWEEN to_date('" + FI + "','dd/mm/yyyy') AND to_date('" + FF + "','dd/mm/yyyy') "
        If mov_cdec <> "" Then
            queryString += " AND MOV_CDEC='" + mov_cdec + "' "
        End If
        If mov_ccar <> "" Then
            queryString += " AND MOV_CCAR='" + mov_ccar + "' "
        End If
        If mov_año <> "" Then
            queryString += "  AND MOV_AÑO='" + mov_año + "' "
        End If

        If mov_per <> "" Then
            queryString += " AND MOV_PER='" + mov_per + "'"
        End If

        x = queryString
        CrearComando(queryString)
        DTtab = EjecutarConsultaDataTable()
        Me.Desconectar()
        Me.lErrorG = False
        'Catch ex As Exception
        'Me.lErrorG = True
        'Me.Msg = "Error de App:" + ex.Message
        'Finally
        'Me.Desconectar()
        'End Try
        Return DTtab
    End Function
    <DataObjectMethodAttribute(DataObjectMethodType.Select, True)> _
    Public Function Get_Ing_Agen(ByVal Filtro As String) As DataTable
        Dim DTtab As DataTable = New DataTable
        Try
            Dim f As String = IIf(Filtro <> "", " Where " + Filtro, "")
            Me.Conectar()
            querystring = "SELECT  TER_NOM,FEC_MOV, FEC_SIS, MOV_CDEC, MOV_CCAR, CCAR_NOM,MOV_TDOC, MOV_NDOC, MOV_AÑO, MOV_PER, VALOR,CLD_NOM FROM vingresosv03  " + f
            'Throw New Exception(querystring)
            CrearComando(querystring)
            DTtab = EjecutarConsultaDataTable()
            Msg = querystring
            Me.lErrorG = False
        Catch ex As Exception
            Msg = ex.Message
            Me.lErrorG = True
        Finally

            Me.Desconectar()
        End Try

        Return DTtab
    End Function

    <DataObjectMethodAttribute(DataObjectMethodType.Select, True)> _
    Public Function GetMovimientosA(ByVal Cldec As String, ByVal Nit As String, ByVal AGra As String) As DataTable

        Me.Conectar()
        querystring = "Select * From Movimiento Where Mov_Cdec=:Mov_Cdec and Mov_Nit=:Mov_Nit And Mov_Año=:Mov_Año"
        CrearComando(querystring)
        AsignarParametroCadena(":Mov_Cdec", Cldec)
        AsignarParametroCadena(":Mov_Nit", Nit)
        AsignarParametroCadena(":Mov_Año", AGra)
        Dim dataTb As DataTable = EjecutarConsultaDataTable()
        Me.Desconectar()
        Return dataTb

    End Function

    <DataObjectMethodAttribute(DataObjectMethodType.Select, True)> _
   Public Function GetMovxConc(ByVal Cldec As String, ByVal Nit As String, ByVal AGra As String, ByVal PGra As String, ByVal Ccar As String) As DataTable
        Me.Conectar()
        querystring = "Select * From Movimiento  where mov_cdec=:mov_cdec and mov_nit=:mov_nit and mov_año=:mov_año and mov_per=:mov_per and mov_ccar=:mov_ccar"
        CrearComando(querystring)
        AsignarParametroCadena(":mov_cdec", Cldec)
        AsignarParametroCadena(":mov_nit", Nit)
        AsignarParametroCadena(":mov_año", AGra)
        AsignarParametroCadena(":mov_per", PGra)
        AsignarParametroCadena(":mov_ccar", Ccar)
        'Throw New Exception(Me.vComando.CommandText)
        Dim dataTb As DataTable = EjecutarConsultaDataTable()
        Me.Desconectar()
        Return dataTb

    End Function

    ''' <summary>
    ''' Declaraciones 
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    <DataObjectMethodAttribute(DataObjectMethodType.Select, True)> _
    Public Overloads Function GetDeclaraciones(ByVal Filtro As String) As DataTable

        Me.Conectar()
        Dim f As String = IIf(Filtro = "", "", " Where " + Filtro)
        Dim queryString As String = "SELECT * FROM vDeclaracion " + f
        CrearComando(queryString)
        Dim dataTb As DataTable = EjecutarConsultaDataTable()
        Me.Desconectar()
        Return dataTb

    End Function

    ''' <summary>
    ''' Declaraciones 
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    <DataObjectMethodAttribute(DataObjectMethodType.Select, True)> _
    Public Overloads Function GetDeclaracionesCal() As DataTable

        Me.Conectar()
        'Where calcla='40' And calVig='2011'
        querystring = "SELECT * FROM vDeclaracionCal02 "
        CrearComando(queryString)
        'AsignarParametroCadena(":Dec_EsFi", Est_Fis)
        'AsignarParametroCadena(":Dec_Cdec", Cla_Dec)
        Dim dataTb As DataTable = EjecutarConsultaDataTable()
        Me.Desconectar()
        Return dataTb

    End Function


End Class
