Imports Microsoft.VisualBasic
Imports System.Data
Imports System.ComponentModel

Public Class Omisos12Per
    Implements COmisos

    Dim BD As BDDatos2 = New BDDatos2()

    <DataObjectMethodAttribute(DataObjectMethodType.Select, True)> _
    Public Function Get_omisos(ByVal Cla_Dec As String, ByVal Vig As String, ByVal nit As String, ByVal mpio As String, ByVal tipoAgen As String, ByVal calendario As DataTable) As DataTable Implements COmisos.Get_omisos
        Dim DTtab As DataTable = New DataTable
        RutaReport = "Report\Consultas\RptOmisos.rdlc"
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
                dtr("ENERO") = IIf(isDecPer(Cla_Dec, dtr("ter_nit"), Vig, "01") = 0, -2, dtr("ENERO"))
                dtr("FEBRERO") = IIf(isDecPer(Cla_Dec, dtr("ter_nit"), Vig, "02") = 0, -2, dtr("FEBRERO"))
                dtr("MARZO") = IIf(isDecPer(Cla_Dec, dtr("ter_nit"), Vig, "03") = 0, -2, dtr("MARZO"))
                dtr("ABRIL") = IIf(isDecPer(Cla_Dec, dtr("ter_nit"), Vig, "04") = 0, -2, dtr("ABRIL"))
                dtr("MAYO") = IIf(isDecPer(Cla_Dec, dtr("ter_nit"), Vig, "05") = 0, -2, dtr("MAYO"))
                dtr("JUNIO") = IIf(isDecPer(Cla_Dec, dtr("ter_nit"), Vig, "06") = 0, -2, dtr("JUNIO"))
                dtr("JULIO") = IIf(isDecPer(Cla_Dec, dtr("ter_nit"), Vig, "07") = 0, -2, dtr("JULIO"))
                dtr("AGOSTO") = IIf(isDecPer(Cla_Dec, dtr("ter_nit"), Vig, "08") = 0, -2, dtr("AGOSTO"))
                dtr("SEPTIEMBRE") = IIf(isDecPer(Cla_Dec, dtr("ter_nit"), Vig, "09") = 0, -2, dtr("SEPTIEMBRE"))
                dtr("OCTUBRE") = IIf(isDecPer(Cla_Dec, dtr("ter_nit"), Vig, "10") = 0, -2, dtr("OCTUBRE"))
                dtr("NOVIEMBRE") = IIf(isDecPer(Cla_Dec, dtr("ter_nit"), Vig, "11") = 0, -2, dtr("NOVIEMBRE"))
                dtr("DICIEMBRE") = IIf(isDecPer(Cla_Dec, dtr("ter_nit"), Vig, "12") = 0, -2, dtr("DICIEMBRE"))
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
            BD.Conectar()
            Qstring = "select Count(*) res from ter_dec where TEDE_CDEC= '" + Cla_Dec + "' and tede_tnit= '" + nit + "' and '" + Vig + Per + "' between to_char(tede_fini,'yyyymm') and to_char(tede_ffin,'yyyymm')"
            BD.CrearComando(Qstring)
            DTtab = BD.EjecutarConsultaDataTable()
            BD.Desconectar()
            BD.lErrorG = False
        Catch ex As Exception
            BD.lErrorG = True
            BD.Msg = "Error de App:" + ex.Message
        Finally
            BD.Desconectar()
        End Try

        r = DTtab.Rows(0)("res")
        Return r
    End Function

    
    Public Property RutaReport As String Implements COmisos.RutaReport
    
End Class

