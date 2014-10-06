Imports Microsoft.VisualBasic
Imports System.Data
Imports System.ComponentModel

Public Class Omisos24Per
    Implements COmisos


    Dim BD As BDDatos2 = New BDDatos2()


    <DataObjectMethodAttribute(DataObjectMethodType.Select, True)> _
    Public Function Get_omisos(ByVal Cla_Dec As String, ByVal Vig As String, ByVal nit As String, ByVal mpio As String, ByVal tipoAgen As String, ByVal calendario As DataTable) As DataTable Implements COmisos.Get_omisos
        RutaReport = "Report\Consultas\RptOmisos24.rdlc"
        Dim DTtab As DataTable = New DataTable
        Dim i As Integer = 0
        Dim querystring As String = ""

        Try
            BD.Conectar()
            querystring = "select T.ter_nit,t.ter_nom,ta.tag_nom, m.mun_nom, t.ter_dir, t.ter_tel, t.ter_emai "
            For Each dtRow As DataRow In calendario.Rows
                querystring += ", Nvl((select To_Char(dec_ptot) from declaracion where dec_est='PR' and dec_cdec='" + Cla_Dec + "' and dec_nit=t.ter_nit and dec_ano='" + Vig + "' and dec_per='" + dtRow("cal_per") + "'),'-1')" + dtRow("cal_des")
            Next
            querystring += " from terceros T  inner join municipios m on ter_mpio=mun_cod  INNER join tipo_agent ta on ta.tag_cod = t.TER_TIP  where ter_tus='AR'"

            If Not String.IsNullOrEmpty(nit) Then
                querystring += " and ter_nit= " + nit
            End If
            If Not String.IsNullOrEmpty(mpio) Then
                querystring += " and ter_mpio= " + mpio + ""
            End If
            If Not String.IsNullOrEmpty(tipoAgen) Then
                querystring += " and ter_tip = " + tipoAgen + ""
            End If
            BD.CrearComando(querystring)
            DTtab = BD.EjecutarConsultaDataTable()

            For Each dtr As DataRow In DTtab.Rows
                dtr("ENERO_1") = IIf(isDecPer(Cla_Dec, dtr("ter_nit"), Vig, "01") = 0, -2, dtr("ENERO_1"))
                dtr("ENERO_2") = IIf(isDecPer(Cla_Dec, dtr("ter_nit"), Vig, "01") = 0, -2, dtr("ENERO_2"))
                dtr("FEBRERO_1") = IIf(isDecPer(Cla_Dec, dtr("ter_nit"), Vig, "02") = 0, -2, dtr("FEBRERO_1"))
                dtr("FEBRERO_2") = IIf(isDecPer(Cla_Dec, dtr("ter_nit"), Vig, "02") = 0, -2, dtr("FEBRERO_2"))
                dtr("MARZO_1") = IIf(isDecPer(Cla_Dec, dtr("ter_nit"), Vig, "03") = 0, -2, dtr("MARZO_1"))
                dtr("MARZO_2") = IIf(isDecPer(Cla_Dec, dtr("ter_nit"), Vig, "03") = 0, -2, dtr("MARZO_2"))
                dtr("ABRIL_1") = IIf(isDecPer(Cla_Dec, dtr("ter_nit"), Vig, "04") = 0, -2, dtr("ABRIL_1"))
                dtr("ABRIL_2") = IIf(isDecPer(Cla_Dec, dtr("ter_nit"), Vig, "04") = 0, -2, dtr("ABRIL_2"))
                dtr("MAYO_1") = IIf(isDecPer(Cla_Dec, dtr("ter_nit"), Vig, "05") = 0, -2, dtr("MAYO_1"))
                dtr("MAYO_2") = IIf(isDecPer(Cla_Dec, dtr("ter_nit"), Vig, "05") = 0, -2, dtr("MAYO_2"))
                dtr("JUNIO_1") = IIf(isDecPer(Cla_Dec, dtr("ter_nit"), Vig, "06") = 0, -2, dtr("JUNIO_1"))
                dtr("JUNIO_2") = IIf(isDecPer(Cla_Dec, dtr("ter_nit"), Vig, "06") = 0, -2, dtr("JUNIO_2"))
                dtr("JULIO_1") = IIf(isDecPer(Cla_Dec, dtr("ter_nit"), Vig, "07") = 0, -2, dtr("JULIO_1"))
                dtr("JULIO_2") = IIf(isDecPer(Cla_Dec, dtr("ter_nit"), Vig, "07") = 0, -2, dtr("JULIO_2"))
                dtr("AGOSTO_1") = IIf(isDecPer(Cla_Dec, dtr("ter_nit"), Vig, "08") = 0, -2, dtr("AGOSTO_1"))
                dtr("AGOSTO_2") = IIf(isDecPer(Cla_Dec, dtr("ter_nit"), Vig, "08") = 0, -2, dtr("AGOSTO_2"))
                dtr("SEPTIEMBRE_1") = IIf(isDecPer(Cla_Dec, dtr("ter_nit"), Vig, "09") = 0, -2, dtr("SEPTIEMBRE_1"))
                dtr("SEPTIEMBRE_1") = IIf(isDecPer(Cla_Dec, dtr("ter_nit"), Vig, "09") = 0, -2, dtr("SEPTIEMBRE_2"))
                dtr("OCTUBRE_1") = IIf(isDecPer(Cla_Dec, dtr("ter_nit"), Vig, "10") = 0, -2, dtr("OCTUBRE_1"))
                dtr("OCTUBRE_2") = IIf(isDecPer(Cla_Dec, dtr("ter_nit"), Vig, "10") = 0, -2, dtr("OCTUBRE_2"))
                dtr("NOVIEMBRE_1") = IIf(isDecPer(Cla_Dec, dtr("ter_nit"), Vig, "11") = 0, -2, dtr("NOVIEMBRE_1"))
                dtr("NOVIEMBRE_2") = IIf(isDecPer(Cla_Dec, dtr("ter_nit"), Vig, "11") = 0, -2, dtr("NOVIEMBRE_2"))
                dtr("DICIEMBRE_1") = IIf(isDecPer(Cla_Dec, dtr("ter_nit"), Vig, "12") = 0, -2, dtr("DICIEMBRE_1"))
                dtr("DICIEMBRE_2") = IIf(isDecPer(Cla_Dec, dtr("ter_nit"), Vig, "12") = 0, -2, dtr("DICIEMBRE_2"))
            Next
            DTtab.AcceptChanges()
            Dim x = DTtab.Rows(0)("ENERO")
            BD.Desconectar()
            BD.lErrorG = False
        Catch ex As Exception
            BD.lErrorG = True
            BD.Msg = "Error de App:" + ex.Message
        Finally
            BD.Desconectar()
        End Try
        Return DTtab
    End Function

    Public Function isDecPer(ByVal Cla_Dec As String, ByVal nit As String, ByVal Vig As String, Per As String) As Integer Implements COmisos.isDecPer
        Dim DTtab As DataTable = New DataTable
        Dim Qstring As String = ""
        Dim r As Integer = 0
        Try
            'BD.Conectar()
            Qstring = "select Count(*) res from ter_dec where TEDE_CDEC= '" + Cla_Dec + "' and tede_tnit= '" + nit + "' and '" + Vig + Per + "' between to_char(tede_fini,'yyyymm') and to_char(tede_ffin,'yyyymm')"
            BD.CrearComando(Qstring)
            DTtab = BD.EjecutarConsultaDataTable()
            'BD.Desconectar()
            BD.lErrorG = False
        Catch ex As Exception
            BD.lErrorG = True
            BD.Msg = "Error de App:" + ex.Message
        Finally
            'BD.Desconectar()
        End Try
        r = DTtab.Rows(0)("res")
        Return r
    End Function

    Public Property RutaReport As String Implements COmisos.RutaReport
    
End Class
