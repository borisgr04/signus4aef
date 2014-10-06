Imports Microsoft.VisualBasic

Imports System.Data
Imports System.ComponentModel

Public Class Calendario
    Inherits BDDatos2

    <DataObjectMethodAttribute(DataObjectMethodType.Select, True)> _
    Public Overrides Function GetRecords() As DataTable
        Me.Conectar()
        Me.querystring = "SELECT * FROM Calendario ORDER BY CLIM_CODI"
        CrearComando(querystring)
        Dim dataTb As DataTable = EjecutarConsultaDataTable()

        Me.Desconectar()
        Return dataTb

    End Function

    <DataObjectMethodAttribute(DataObjectMethodType.Select, True)> _
    Public Overloads Function GetVigencias(ByVal Cla_Dec As String) As DataTable

        Me.Conectar()
        Me.querystring = "Select * From vCalendarioVig WHERE Cal_cla=:Cal_cla Order By cal_vig desc"
        CrearComando(querystring)

        AsignarParametroCadena(":Cal_cla", Cla_Dec)

        Dim dataTb As DataTable = EjecutarConsultaDataTable()
        Me.Desconectar()
        Return dataTb

    End Function
    <DataObjectMethodAttribute(DataObjectMethodType.Select, True)> _
    Public Overloads Function GetPorAñoyPer(ByVal Cla_Dec As String, ByVal año As String, ByVal periodo As String) As DataTable
        Me.Conectar()
        Me.querystring = "Select * From vCalendarioDEC WHERE Cld_COD=:Cld_COD AND CAL_VIG=:CLA_VIG AND CAL_PER=:CAL_PER"
        CrearComando(querystring)
        AsignarParametroCadena(":Cld_COD", Cla_Dec)
        AsignarParametroCadena(":CLA_VIG", año)
        AsignarParametroCadena(":CAL_PER", periodo)
        Dim dataTb As DataTable = EjecutarConsultaDataTable()
        Me.Desconectar()
        Return dataTb
    End Function

    <DataObjectMethodAttribute(DataObjectMethodType.Select, True)> _
    Public Overloads Function GetPorClaseDec(ByVal Cla_Dec As String, ByVal Vigencia As String) As DataTable

        Me.Conectar()
        querystring = "Select cal_per, cal_per||'-'||cal_des cal_des From vCalendarioDEC WHERE Cld_COD=:Cld_COD AND CAL_VIG=:CLA_VIG And Cal_Ffin<SYSDATE Order By cal_per"
        'me.querystring = "Select cal_per, cal_per||'-'||cal_des cal_des From vCalendarioDEC WHERE Cld_COD=:Cld_COD AND CAL_VIG=:CLA_VIG  Order By cal_per"
        querystring = "Select cal_per, cal_per||'-'||cal_des cal_des From vCalendarioDEC WHERE Cld_COD=:Cld_COD AND CAL_VIG=:CLA_VIG And Cal_Fini<=SYSDATE Order By cal_per"
        CrearComando(querystring)
        AsignarParametroCadena(":Cld_COD", Cla_Dec)
        AsignarParametroCadena(":CLA_VIG", Vigencia)
        Dim dataTb As DataTable = EjecutarConsultaDataTable()

        Me.Desconectar()
        Return dataTb

    End Function
    Private Overloads Function UltID() As String

        Dim datat As New Data.DataTable
        'Me.Conectar()
        Me.querystring = "SELECT max(clim_codi) FROM CLASE_IMPTO"
        CrearComando(querystring)
        Dim r As String = Convert.ToString(EjecutarEscalar())

        'Me.Desconectar()
        Return r

    End Function

    Public Function GenCons() As String

        Dim c As Integer, cod As String
        c = CInt(UltID()) + 1
        cod = c.ToString.PadLeft(2, "0")

        Return cod


    End Function
    ' agregado shirly
    <DataObjectMethodAttribute(DataObjectMethodType.Select, True)> _
    Public Overloads Function GetPorFechaIni(ByVal Cla_Dec As String, ByVal Vig_Ini As String, ByVal Vig_Fin As String, ByVal Fec_ini As String) As DataTable

        Me.Conectar()
        Me.querystring = "select CAL_PER, cal_des, cal_vig from calendario where cal_vig >= :Vig_Ini and cal_vig <= :Vig_Fin and cal_cla= :Cla_Dec and  last_day(cal_fini) >= TO_DATE(:Fec_ini,'dd/mm/yyyy')  And Cal_Ffin<SYSDATE order by cal_vig, cal_per"
        CrearComando(querystring)
        AsignarParametroCadena(":Vig_Ini", Vig_Ini)
        AsignarParametroCadena(":Vig_Fin", Vig_Fin)
        AsignarParametroCadena(":Cla_Dec", Cla_Dec)
        AsignarParametroCadena(":Fec_ini", CDate(Fec_ini).ToShortDateString)
        Dim dataTb As DataTable = EjecutarConsultaDataTable()

        Me.Desconectar()
        Return dataTb

    End Function
    <DataObjectMethodAttribute(DataObjectMethodType.Select, True)> _
    Public Function Get_CalendarioxVigxCla(ByVal Cla_Dec As String, ByVal Vig As String) As DataTable
        Dim DTtab As DataTable = New DataTable
        querystring = ""
        Try
            Me.Conectar()
            querystring = "select cal_per, cal_des from calendario where cal_vig='" + Vig + "' and cal_cla=" + Cla_Dec + "order by cal_per"
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
End Class

