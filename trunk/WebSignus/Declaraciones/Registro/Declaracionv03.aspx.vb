Imports System.Text
Imports System.CodeDom.Compiler
Imports System.Collections.Specialized

Imports System.Data
Imports System.Data.OleDb
Imports System.Collections.Generic
Imports System
Imports System.Configuration
Imports System.Web
Imports System.Web.Security
Imports System.Web.UI
Imports System.Web.UI.WebControls
Imports System.Web.UI.WebControls.WebParts
Imports System.Web.UI.HtmlControls
Imports Microsoft.Reporting.WebForms
Imports AjaxControlToolkit


Partial Class Declaraciones_Registro_Declaracionv02
    Inherits PaginaComun
    Dim NroRenglon As String = "9"
    Dim Dec_nro As String
    Dim objCd As CDeclaraciones
    Dim NomDec As String
    Dim Plazo_dec As Integer
    Dim fecha_lim As Date
    Dim ValInteresMora As Decimal
    Dim fecha_dec As Date
    Dim TOTAL_RETENCIONES As Double
    Dim fnTotalizar As String
    Dim Nit As String
    Dim TD As String
    Dim FODE_CODI As String
    Dim dtForm As DataTable
    Dim Operaciones_Form As String
    Dim RenglonLP As String
    Dim RenglonVP As String
    Dim LSanciones As Boolean
    Dim Dias_Mora As Integer
    Dim dec_cor As String
    Dim redondear As Decimal
    Dim DOAD As String

    Protected Function NRenglon() As String

        NroRenglon = CStr(CInt(NroRenglon) + 1).PadLeft(2, "0")
        Return NroRenglon

    End Function
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        ' OJO NO RECARGAR DATOS !!!!!!!!!!!!!
        If Not IsPostBack Then

            Me.BtnLiq.Enabled = True
            Me.BtnGuardarD.Enabled = False
            Me.BtnGPDF.Enabled = False

            Me.Opcion = "Impuesto de Registro"
            Me.SetTitulo()
            avce.VerticalSide = VerticalSide.Bottom
            avce.HorizontalSide = HorizontalSide.Center
            avce.Enabled = True
            Cargar_datos()
            Cargar_Ayuda()

        End If
    End Sub
    Private Function mostrar_renglon(ByVal nr As String) As String
        Return "document.form1.HdRenglon.value=" & nr & ";ActualizarAyuda();showdiv(event);"
    End Function

    Private Sub Cargar_Ayuda()
        Me.R1.Attributes.Add("OnClick", mostrar_renglon("1"))
        Me.R1.Attributes.Add("OnMouseOver", mostrar_renglon("1"))

        Me.R2.Attributes.Add("OnClick", mostrar_renglon("2"))
        Me.R2.Attributes.Add("OnMouseOver", mostrar_renglon("2"))

        Me.R3.Attributes.Add("OnClick", mostrar_renglon("3"))
        Me.R3.Attributes.Add("OnMouseOver", mostrar_renglon("3"))

        Me.R4.Attributes.Add("OnClick", mostrar_renglon("4"))
        Me.R4.Attributes.Add("OnMouseOver", mostrar_renglon("4"))

        Me.R5.Attributes.Add("OnClick", mostrar_renglon("5"))
        Me.R5.Attributes.Add("OnMouseOver", mostrar_renglon("5"))

        Me.R6.Attributes.Add("OnClick", mostrar_renglon("6"))
        Me.R6.Attributes.Add("OnMouseOver", mostrar_renglon("6"))

        Me.R7.Attributes.Add("OnClick", mostrar_renglon("7"))
        Me.R7.Attributes.Add("OnMouseOver", mostrar_renglon("7"))

        Me.R8.Attributes.Add("OnClick", mostrar_renglon("8"))
        Me.R8.Attributes.Add("OnMouseOver", mostrar_renglon("8"))

        Me.R9.Attributes.Add("OnClick", mostrar_renglon("9"))
        Me.R9.Attributes.Add("OnMouseOver", mostrar_renglon("9"))

        Me.R19.Attributes.Add("OnClick", mostrar_renglon("19"))
        Me.R19.Attributes.Add("OnMouseOver", mostrar_renglon("19"))

        Me.R20.Attributes.Add("OnClick", mostrar_renglon("20"))
        Me.R20.Attributes.Add("OnMouseOver", mostrar_renglon("20"))

        Me.R21.Attributes.Add("OnClick", mostrar_renglon("21"))
        Me.R21.Attributes.Add("OnMouseOver", mostrar_renglon("21"))

        Me.R22.Attributes.Add("OnClick", mostrar_renglon("22"))
        Me.R22.Attributes.Add("OnMouseOver", mostrar_renglon("22"))

        Me.R23.Attributes.Add("OnClick", mostrar_renglon("23"))
        Me.R23.Attributes.Add("OnMouseOver", mostrar_renglon("23"))

        Me.R24.Attributes.Add("OnClick", mostrar_renglon("24"))
        Me.R24.Attributes.Add("OnMouseOver", mostrar_renglon("24"))

        Me.R25.Attributes.Add("OnClick", mostrar_renglon("25"))
        Me.R25.Attributes.Add("OnMouseOver", mostrar_renglon("25"))

        Me.R26.Attributes.Add("OnClick", mostrar_renglon("26"))
        Me.R26.Attributes.Add("OnMouseOver", mostrar_renglon("26"))

    End Sub

    Private Sub Cargar_datos()
        Try
            'Me.Cla_Dec.Value = Request.QueryString("Cdec")
            'Me.AGravable.Text = Request.QueryString("AGravable")
            'Me.PGravable.Text = Request.QueryString("PGravable")
            'Me.Nit = Request.QueryString("Nit")
            'Me.HdDecTip.Value = Request.QueryString("DecTip")
            'Me.TD = Request.QueryString("TD")
            ''Me.HdTD.Value = Request.QueryString("TD")
            'Me.FODE_CODI = Request.QueryString("FODE_CODI")
            'Dim dec_cor As String = Request.QueryString("Dec_Cor")
            querystringSeguro = Me.GetRequest()
            Me.Cla_Dec.Value = querystringSeguro("Cdec")
            Me.AGravable.Text = querystringSeguro("AGravable")
            Me.PGravable.Text = querystringSeguro("PGravable")
            Me.Nit = querystringSeguro("Nit")
            Me.HdDecTip.Value = querystringSeguro("DecTip")
            Me.TD = querystringSeguro("TD")
            Me.HdTD.Value = querystringSeguro("TD")
            Me.FODE_CODI = querystringSeguro("FODE_CODI")
            Me.dec_cor = querystringSeguro("Dec_Cor")
            Me.HdDOAD.Value = querystringSeguro("DOAD")

            Me.HdFecDec.Value = Now.ToShortDateString
            'Response.Write(Me.Cla_Dec.Value)
            'Response.Write(Me.AGravable.Text)
            'Response.Write(Me.PGravable.Text)
            'Response.Write(Me.Nit)
            'Response.Write(Me.HdDecTip.Value)
            'Response.Write(Request("data"))
            'Response.End()
            'Dim idtran As Integer = querystringSeguro("Cdec")
            'Dim tipo As Integer = Integer.Parse(querystringSeguro("tipo"))
            'Dim usuario As String = querystringSeguro("usuario").ToString
            'Dim priori As Integer = Integer.Parse(querystringSeguro("priori"))
            'Me.MsgResult.Text = "idtran=" & idtran & " tipo=" & tipo & " usuario=" & usuario & " priori=" & priori
        Catch ex As Exception
            Me.MsgResult.Text = "ERROR EN RECEPCIÓN DE PARAMETROS"
        End Try

        objCd = New CDeclaraciones(Me.Cla_Dec.Value)
        Me.HdFODE.Value = Me.FODE_CODI

        '-----
        Dim objCal As Calendario = New Calendario
        Dim dtc As DataTable
        dtc = objCal.GetPorAñoyPer(Me.Cla_Dec.Value, Me.AGravable.Text, Me.PGravable.Text)
        'REVISAR SANCIONES E INTERESES
        Dim cal_ffin As Date = CDate(dtc.Rows(0)("Cal_Ffin").ToString())
        Me.fecha_dec = cal_ffin

        'Dim fecha_lim As Date
        'Plazo de Ejecución
        'Me.Plazo_dec = CInt(objCd.GetPlazoDec(cal_ffin))

        'Fecha Limite
        'fecha_lim = cal_ffin.AddDays(Me.Plazo_dec)
        'Me.HdFecLim.Value = fecha_lim


        fecha_lim = objCd.GetFecha_Limite(Me.Cla_Dec.Value, Me.AGravable.Text, Me.PGravable.Text)
        Me.HdFecLim.Value = fecha_lim

        'Dias Extemporaneidad
        Me.Dias_Mora = DateDiff(DateInterval.Day, fecha_lim, CDate(Me.HdFecDec.Value))
        Me.HdSancionMinima.Value = objCd.GetSancion_Minima(CDate(Me.HdFecDec.Value))
        Dim str As String

        If (fecha_lim < (Me.HdFecDec.Value)) Then
            Me.HdExtem.Value = "S"
            If (Me.HdTD.Value = "I") Then
                str = "Se venció el Plazo de Declaración, debe declarar Sanciones y Liquidar Intereses de Mora "
                str += "<br/><i>Mora</i>  " + Me.Dias_Mora.ToString + " días"
                str += "<br/><i>Extemporaneidad</i>  " + System.Math.Ceiling(Me.Dias_Mora / 30).ToString + " Mes(es) o Fracción de Mes"
            Else
                Dim dtcorr As DataTable = Me.objCd.GetporCod(Me.dec_cor)
                Me.HdSancionMinima.Value = objCd.GetSancion_Minima(dtcorr.Rows(0)("DEC_FPRE"))
                Me.HdVALPAG_INI.Value = objCd.Valor_Pagado(Me.dec_cor)
                str = "Realizará una Declaración de Corrección, debe declarar Sanciones y Liquidar Intereses de Mora del Valor no Pagado.<br>"
                str += " Valor Pagado en la Declaración anterior: " + FormatNumber(Me.HdVALPAG_INI.Value)
            End If
            str += "<br/><br/><i>Sanción Mínima</i> para la Declaración $" + FormatNumber(Me.HdSancionMinima.Value)
            Me.MsgResult.Text = str
            Me.ImgRst.ImageUrl = Me.IMGOK
            Me.LSanciones = True
            Me.ModalPopup.Show()
        Else
            Me.HdExtem.Value = "N"
            Me.MsgResult.Text = "No se calcula, ni sanción, ni interés"
            Me.LSanciones = False
        End If

        'Me.MsgResult.Text = fecha_lim
        'Me.ModalPopup.Show()


        'PlazoDec()
        Dim dtForm As DataTable = Me.objCd.GetFormulariosByCod(Me.FODE_CODI)
        Me.Operaciones_Form = dtForm.Rows(0)("FODE_OPER2").ToString.Trim

        Me.Opcion = "Formulario único para la declaración de " + objCd.GetNomDec(Me.Cla_Dec.Value)
        Me.LBTITULO.Text = Me.Opcion
        Me.Label22.Text = Me.Opcion
        Me.Title = Me.Opcion
        'Me.SetTitulo()


        Me.RenglonLP = objCd.GetRenglones(Me.Cla_Dec.Value, "LP", Me.HdFODE.Value).Rows.Count
        Me.RenglonVP = objCd.GetRenglones(Me.Cla_Dec.Value, "VP", Me.HdFODE.Value).Rows.Count
        Me.redondear = objCd.pRedondeo()
        Me.fnTotalizar = "Totalizar(" + Me.RenglonLP.ToString + "," + Me.RenglonVP.ToString + ",'" + Me.Operaciones_Form.Trim + "'," + redondear.ToString + ");"
     
        Me.ReportViewer1.LocalReport.ReportPath = Me.Server.MapPath("~") + "\" + dtForm.Rows(0)("FODE_RPTE").ToString.Trim

        'Me.LbPGravable.Text = dtForm.Rows(0)("FODE_RPTE").ToString.Trim
        If Me.TD = "C" Then
            Me.TxtDecCorrige.Text = dec_cor
            Me.DCorr.Checked = True
        Else
            Me.DInicial.Checked = True
        End If

        Dim objS As Signatario = New Signatario
        If Not Me.IsPostBack Then
            Dim dt As DataTable = Me.UsuTercero.GetByIde(Me.Nit)
            If dt.Rows.Count > 0 Then
                Me.Agente.Text = dt.Rows(0)("Ter_Nom").ToString
                'Me.LBTIPODEC.Text = dt.Rows(0)("TAG_NOM").ToString
                Me.LBMUN_NOM.Text = dt.Rows(0)("TER_MPIO").ToString + "-" + dt.Rows(0)("MUN_NOM").ToString
                Me.LBTER_TEL.Text = dt.Rows(0)("TER_TEL").ToString
                Me.Identificaciòn.Text = dt.Rows(0)("Ter_nit").ToString
                Me.DV.Text = Trim(dt.Rows(0)("Ter_dver").ToString)
                'Me.TIP_DOC_IDE.Text = dt.Rows(0)("Ter_tdoc").ToString

                Me.HdTAG.Value = dt.Rows(0)("TAG_COD").ToString

                Me.TXTDIR.Text = dt.Rows(0)("Ter_DIR").ToString
                'Me.Municipio.Text = "*****"
                'dt.Rows(0)("mun_nom").ToString()
                Dim dtS As DataTable = objS.GetRecords(dt.Rows(0)("Ter_nit").ToString)
                Dim OSIG As String = objCd.GetOSIG(cal_ffin)
                If dtS.Rows.Count > 0 Then
                    Me.LbNRODOC_PD.Text = dtS.Rows(0)("Dec_nit").ToString
                    'Me.LbTIPDOC_PD.Text = dtS.Rows(0)("Dec_tdoc").ToString
                    'Dim TIPOID_PD As String = dtS.Rows(0)("Dec_tdoc").ToString
                    Dim TipoId_PD As String = dtS.Rows(0)("Dec_tdoc").ToString
                    If TipoId_PD = "CC" Then
                        Me.CC_PD.Checked = True
                        Me.CE_PD.Checked = False
                    Else
                        Me.CC_PD.Checked = False
                        Me.CE_PD.Checked = True
                    End If
                    Me.lbRAZSOC_PD.Text = dtS.Rows(0)("Dec_nom").ToString
                    Me.LbNRODOC_RF.Text = dtS.Rows(0)("Rev_nit").ToString
                    Dim TipoId_RF As String = dtS.Rows(0)("Rev_tdoc").ToString
                    If TipoId_RF = "CC" Then
                        Me.CC_RF.Checked = True
                        Me.CE_RF.Checked = False
                    Else
                        Me.CC_RF.Checked = False
                        Me.CE_RF.Checked = True
                    End If
                    Dim TipoCToRF As String = dtS.Rows(0)("REV_TREV").ToString
                    If TipoCToRF = "RF" Then
                        Me.ChkContador.Checked = False
                        Me.ChkRevisor.Checked = True
                    Else
                        Me.ChkContador.Checked = True
                        Me.ChkRevisor.Checked = False
                    End If
                    Me.LbRAZSOC_RF.Text = dtS.Rows(0)("Rev_nom").ToString
                    Me.LbTarPro.Text = dtS.Rows(0)("Rev_tar_pro").ToString
                Else
                    Me.MsgResult.Text = "No tiene Asignado los Signatarios."
                End If
            Else
                Me.Agente.Text = "No tiene Asociado Tercero"
            End If
        End If

        Dim de_bg As New De_Bg_Registro()

        RptBGDev.DataSource = de_bg.Get_BaseG_Registro(Me.HdTAG.Value, Me.Identificaciòn.Text, Me.AGravable.Text, Me.PGravable.Text, "D")
        RptBGDev.DataBind()

        RptBGImpto.DataSource = de_bg.Get_BaseG_Registro(Me.HdTAG.Value, Me.Identificaciòn.Text, Me.AGravable.Text, Me.PGravable.Text, "I")
        RptBGImpto.DataBind()

        'RptBG.DataSource
        'RptBG

        'Me.BtnPDF.Enabled = True
    End Sub

    Protected Sub Periodo_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs)
        'Me.FormView1.PageIndex = Me.Periodo.SelectedIndex
    End Sub

    Public Function Tarifa(ByVal Cod_imp As String, ByVal tip As String) As String
        objCd = New CDeclaraciones(Me.Cla_Dec.Value)
        Dim Input_par As String = ""

        'If Me.Cla_Dec.Value = "01" Then
        ' Input_par = String.Format("Valor_Base Number:=1;Tipo_Acto Number:={0};", tip)
        ' ElseIf Me.Cla_Dec.Value = "02" Then
        ' Input_par = "Valor_Base Number:=1;Tipo_Acto Number:=1;"
        ' ElseIf Me.Cla_Dec.Value = "03" Then
        ' If Me.HdTAG.Value = "12" Then
        ' Input_par = "Valor_Base Number:=1;Tipo Number:=1;"
        ' End If
        'If Me.HdTAG.Value = "13" Then
        ' Input_par = "Valor_Base Number:=1;Tipo Number:=2;"
        ' End If
        ' End If
        Input_par = objCd.GetParametrosTar(Me.Cla_Dec.Value, Me.HdTAG.Value, tip)
        'Response.Write(Input_par)
        'Response.End()
        Return objCd.GetTarifa(Cod_imp, Input_par, Me.fecha_dec)
    End Function

    Public Function DiasMora(ByVal Fecha As Date) As Integer
        objCd = New CDeclaraciones(Me.Cla_Dec.Value)
        Me.Plazo_dec = CInt(objCd.GetPlazoDec(Fecha))
        fecha_lim = Fecha.AddDays(Me.Plazo_dec)
        Return DateDiff(DateInterval.Day, fecha_lim, CDate(Me.HdFecDec.Value))
    End Function
    Public Function PlazoDec(ByVal Fecha As Date) As String
        Me.fecha_dec = Fecha
        objCd = New CDeclaraciones(Me.Cla_Dec.Value)
        Me.Plazo_dec = CInt(objCd.GetPlazoDec(Fecha))
        fecha_lim = Fecha.AddDays(Me.Plazo_dec)
        If fecha_lim < CDate(Me.HdFecDec.Value) Then
            Me.MsgResult.Text = "Se Venció el plazo de declaración, debe Calcular Intereses y Sanciones"
        Else
            Me.MsgResult.Text = "No se calcula, ni sanción, ni interés"
        End If
        Return fecha_lim
    End Function
    '----------------------------------------------
    Protected Sub ReportViewer1_SubreportProcessing(ByVal sender As Object, ByVal e As SubreportProcessingEventArgs)
        Dim dtSet As DataSet = New DataSet()
        Dim obj As CDeclaraciones = New CDeclaraciones(Me.Cla_Dec.Value)
        dtSet = obj.GetLiqConcep(Me.HdNroDec.Value)
        Dim dataSource As ReportDataSource = New ReportDataSource("DsDecCon_VCODE_CDEC", dtSet.Tables(0))
        e.DataSources.Add(dataSource)
    End Sub
    Private Function GetDatosP() As DataSet
        Dim dt As DataSet = New DataSet
        Dim obj As CDeclaraciones = New CDeclaraciones(Me.Cla_Dec.Value)
        dt = obj.GetDeclaracionRpt(HdNroDec.Value)
        Return dt
    End Function
    Private Sub RenderReport(ByVal Rpt As LocalReport)
        'string reportType = "Image"; 
        Dim reportType As String = "PDF"
        Dim fileNameExtension As String = ""
        Dim warnings As Warning() = Nothing
        Dim streamids As String() = Nothing
        Dim mimeType As String = Nothing
        Dim encoding As String = Nothing
        Dim extension As String = Nothing
        'The DeviceInfo settings should be changed based on the reportType 
        'http://msdn2.microsoft.com/en-us/library/ms155397.aspx 
        Dim deviceInfo As String = "<DeviceInfo>" & " <OutputFormat>PDF</OutputFormat>" & " <PageWidth>8.5in</PageWidth>" & " <PageHeight>11in</PageHeight>" & " <MarginTop>0.5in</MarginTop>" & " <MarginLeft>1in</MarginLeft>" & " <MarginRight>1in</MarginRight>" & " <MarginBottom>0.5in</MarginBottom>" & "</DeviceInfo>"
        Dim streams As String() = Nothing
        Dim renderedBytes As Byte()
        'Render the report 
        'deviceInfo, 
        Rpt.Refresh()
        renderedBytes = Rpt.Render(reportType, Nothing, mimeType, encoding, fileNameExtension, streams, warnings)
        Response.Clear()
        Response.ContentType = mimeType
        Response.AddHeader("content-disposition", "attachment; filename=" + Me.HdNroDec.Value + "." & fileNameExtension)
        Response.BinaryWrite(renderedBytes)
        Response.End()
    End Sub
    Public Sub Cargar_Rpt()
        Dim dtSource As ReportDataSource = New ReportDataSource("DsDecl_VDECLARACION", GetDatosP().Tables(0))
        Dim rptEntidad As New ReportDataSource(Me.DS_Entidad, Cargar_Logo())
        ReportViewer1.LocalReport.DataSources.Clear()
        ReportViewer1.LocalReport.DataSources.Add(dtSource)
        ReportViewer1.LocalReport.DataSources.Add(rptEntidad)
        Me.ReportViewer1.LocalReport.DisplayName = HdNroDec.Value
        Me.RenderReport(Me.ReportViewer1.LocalReport)
    End Sub
    Protected Sub ImageButton1_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs)
        Cargar_Rpt()
    End Sub

    Protected Sub Repeater1_ItemDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.RepeaterItemEventArgs) Handles Repeater1.ItemDataBound

        If e.Item.ItemType = ListItemType.Item Or e.Item.ItemType = ListItemType.AlternatingItem Then
            ' ASIGNA EVENTOS

            Dim TxtR As TextBox = DirectCast(e.Item.FindControl("TxtR"), TextBox)
            Dim TxtValBas As TextBox = DirectCast(e.Item.FindControl("TxtValBas"), TextBox)
            Dim LbTar As Label = DirectCast(e.Item.FindControl("LbTar"), Label)
            Dim HdTICO As HiddenField = DirectCast(e.Item.FindControl("HdTICO"), HiddenField)
            Dim HdCodi As HiddenField = DirectCast(e.Item.FindControl("HdCodi"), HiddenField)
            Dim HdIsVb As HiddenField = DirectCast(e.Item.FindControl("HdIsVb"), HiddenField)
            Dim HdIMPTO As HiddenField = DirectCast(e.Item.FindControl("HdIMPTO"), HiddenField)
            Dim HdTari As HiddenField = DirectCast(e.Item.FindControl("HdTARI"), HiddenField)
            Dim CboTSan As DropDownList = DirectCast(e.Item.FindControl("CboTSan"), DropDownList)
            Dim HdSum As HiddenField = DirectCast(e.Item.FindControl("HdSUM"), HiddenField)
            Dim HdCTAR As HiddenField = DirectCast(e.Item.FindControl("HdCTAR"), HiddenField)
            Dim HdTipo_Tar As HiddenField = DirectCast(e.Item.FindControl("HdTipo_Tar"), HiddenField)



            Dim CVMM As String = objCd.GetCVMM(Me.HdFecLim.Value)
            If (CVMM = "S") Then
                If (HdCodi.Value = "01") Or (HdCodi.Value = "02") Then
                    Dim obj As BasesLiq = New BasesLiq
                    Dim dt As DataTable = obj.GetAforo(Me.HdTAG.Value, Me.Cla_Dec.Value, Me.Identificaciòn.Text, Me.AGravable.Text, Me.PGravable.Text, HdCodi.Value)
                    'Me.Labe25.Text = Me.Labe25.Text + Me.Identificaciòn.Text + "," + Me.AGravable.Text + "," + Me.PGravable.Text + "," + HdIMPTO.Value + "," + dt.Rows.Count.ToString + "<br>"
                    'Response.Write(HdIMPTO.Value)
                    'Me.MsgResult.Text += HdIMPTO.Value + ";" + dt.Rows.Count.ToString
                    'Response.End()
                    'Me.MsgResult.Text += dt.Rows.Count.ToString
                    If dt.Rows.Count > 0 Then
                        'TxtValBas.Text = dt.Rows(0)("BASEGRAVABLE").ToString
                        TxtR.Text = dt.Rows(0)("VALORIMPUESTO").ToString
                    End If
                End If
            End If

            If HdIsVb.Value = "S" Then
                'Dim Tar As String = Tarifa(HdIMPTO.Value, HdTipo_Tar.Value)
                'If CDbl(Tar) < 1 Then
                ' LbTar.Text = CStr(Tar * 100) + "%"
                'Else
                '   LbTar.Text = "$" + FormatNumber(Tar)
                'End If
                'HdTari.Value = Tar
            End If



            Dim TxtNR As TextBox = DirectCast(e.Item.FindControl("NR"), TextBox)
            TxtNR.Attributes.Add("OnClick", Me.mostrar_renglon(TxtNR.Text))
            TxtNR.Attributes.Add("OnMouseOver", Me.mostrar_renglon(TxtNR.Text))
            TxtNR.Text += "."
            If (HdTICO.Value = "S") And Me.TD = "I" Then
                CboTSan.Enabled = Me.LSanciones
                TxtR.ReadOnly = Not Me.LSanciones
            End If
            If (Me.Dias_Mora = 0) And (HdTICO.Value = "I") Then
                TxtR.ReadOnly = False
            End If
            'Operaciones
            TxtR.Attributes.Add("onBlur", Me.fnTotalizar + "Resaltar_Off(this);")
            'TxtR.Attributes.Add("onkeypress", "return tabular(event,this);")

            'Dim r As String = CStr(DirectCast(e.Item.DataItem, DataRowView)("Cocd_REVB"))
            'If r > 1 Then
            ' TxtValBas.Attributes.Add("onBlur", Me.fnTotalizar + "Resaltar_Off(this);redondear_input(this," & r.ToString & ");")
            'Else
            '   TxtValBas.Attributes.Add("onBlur", Me.fnTotalizar + "Resaltar_Off(this);")
            'End If


            '   TxtValBas.Attributes.Add("onFocus", "Resaltar_On(this);")

            'definición de Renglones ReadOnly- Sumados o calculados
            If (HdSum.Value = "S") Then
                'TxtR.Attributes.Add("onfocus", "validar_focus('T')")
                'TxtR.Attributes.Add("onfocus", "this.blur()")
                TxtR.Attributes.Add("onFocus", "ResaltarD_On(this)")
                TxtR.ReadOnly = True
            Else
                TxtR.Attributes.Add("onFocus", "Resaltar_On(this)")
            End If

            'definición de Renglones ReadOnly- Sumados o calculados A partir de Valor Base y Tarifa
            If ((HdIsVb.Value = "S") And (HdCTAR.Value = "S")) Then
                TxtR.Attributes.Add("onFocus", "ResaltarD_On(this)")
                TxtR.ReadOnly = True
            Else
                TxtR.Attributes.Add("onFocus", "Resaltar_On(this)")
            End If


        End If
    End Sub

    Protected Sub Repeater2_ItemDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.RepeaterItemEventArgs) Handles Repeater2.ItemDataBound
        If e.Item.ItemType = ListItemType.Item Or e.Item.ItemType = ListItemType.AlternatingItem Then
            ' ASIGNA EVENTOS
            Dim TxtR As TextBox = DirectCast(e.Item.FindControl("TxtR"), TextBox)
            Dim HdTICO As HiddenField = DirectCast(e.Item.FindControl("HdTICO"), HiddenField)
            Dim HdSum As HiddenField = DirectCast(e.Item.FindControl("HdSum"), HiddenField)
            TxtR.Attributes.Add("onBlur", Me.fnTotalizar + "Resaltar_Off(this);")

            Dim TxtNR As TextBox = DirectCast(e.Item.FindControl("NR"), TextBox)
            TxtNR.Attributes.Add("OnClick", Me.mostrar_renglon(TxtNR.Text))
            TxtNR.Attributes.Add("OnMouseOver", Me.mostrar_renglon(TxtNR.Text))
            TxtNR.Text += "."
            If HdSum.Value = "S" Then
                'TxtR.Attributes.Add("onfocus", "validar_focus('T')")
                'TxtR.Attributes.Add("onfocus", "this.blur()")
                TxtR.Attributes.Add("onFocus", "ResaltarD_On(this)")
                TxtR.ReadOnly = True
            Else
                TxtR.Attributes.Add("onFocus", "Resaltar_On(this)")
            End If

        End If
    End Sub

    Public Function Cargar_CODE3(ByRef LP As LPCODE_CDEC()) As Boolean
        Me.Label2.Text = ""
        Dim Cant As Integer = Me.Repeater1.Items.Count
        Dim Cant2 As Integer = Me.Repeater2.Items.Count
        Dim LiqP(Cant + Cant2 - 1) As LPCODE_CDEC

        Dim Tr As Double = 0
        Dim r As Integer = 0
        Dim j As Integer = 0

        Dim C_K As Decimal = 0
        Dim C_T As Decimal = 0
        Dim C_D As Decimal = 0
        Dim C_I As Decimal = 0
        Dim C_S As Decimal = 0

        For i As Integer = 0 To Cant - 1
            Dim txtR As TextBox = DirectCast(Me.Repeater1.Items(i).FindControl("TxtR"), TextBox)

            Dim HdCodi As HiddenField = DirectCast(Me.Repeater1.Items(i).FindControl("HdCodi"), HiddenField)
            Dim HdIsVB As HiddenField = DirectCast(Me.Repeater1.Items(i).FindControl("HdIsVB"), HiddenField)
            Dim HdTICO As HiddenField = DirectCast(Me.Repeater1.Items(i).FindControl("HdTICO"), HiddenField)
            Dim HdCimp As HiddenField = DirectCast(Me.Repeater1.Items(i).FindControl("HdCimp"), HiddenField)
            Dim HdSECO As HiddenField = DirectCast(Me.Repeater1.Items(i).FindControl("HdSECO"), HiddenField)
            Dim HdTMOV As HiddenField = DirectCast(Me.Repeater1.Items(i).FindControl("HdTMOV"), HiddenField)
            Dim HdCART As HiddenField = DirectCast(Me.Repeater1.Items(i).FindControl("HdCART"), HiddenField)
            Dim HdCCAR As HiddenField = DirectCast(Me.Repeater1.Items(i).FindControl("HdCCAR"), HiddenField)
            Dim HdSum As HiddenField = DirectCast(Me.Repeater1.Items(i).FindControl("HdSum"), HiddenField)
            Dim HdTari As HiddenField = DirectCast(Me.Repeater1.Items(i).FindControl("HdTari"), HiddenField)
            Dim HdCTar As HiddenField = DirectCast(Me.Repeater1.Items(i).FindControl("HdCTar"), HiddenField)

            Dim LbABIM As Label = DirectCast(Me.Repeater1.Items(i).FindControl("LbABIM"), Label)
            Dim LbABVD As Label = DirectCast(Me.Repeater1.Items(i).FindControl("LbABVD"), Label)
            Dim LbNomImp As Label = DirectCast(Me.Repeater1.Items(i).FindControl("LbNomImp"), Label)
            Dim CboTSan As DropDownList = DirectCast(Me.Repeater1.Items(i).FindControl("CboTSan"), DropDownList)

            LiqP(i).CODE_DEES = ""
            'LiqP(i).CODE_ABVB = LbABIM.Text
            'LiqP(i).CODE_ABVD = LbABVD.Text
            LiqP(i).CODE_CART = HdCART.Value
            LiqP(i).CODE_CDEC = Me.Cla_Dec.Value
            LiqP(i).CODE_CODI = HdCodi.Value
            LiqP(i).CODE_ISVB = HdIsVB.Value
            LiqP(i).CODE_NOMB = LbNomImp.Text
            LiqP(i).CODE_REDE = ""
            LiqP(i).CODE_SECO = HdSECO.Value
            LiqP(i).CODE_TICO = HdTICO.Value
            LiqP(i).CODE_TMOV = HdTMOV.Value
            LiqP(i).CODE_USAP = ""
            LiqP(i).CODE_USBD = ""
            LiqP(i).CODE_VACA = 0
            LiqP(i).CODE_VAOF = 0
            LiqP(i).CODE_VASU = 0
            LiqP(i).CODE_CCAR = HdCCAR.Value
            LiqP(i).CODE_SUM = HdSum.Value

            'si tiene valor base

            'If HdIsVB.Value = "S" Then
            'Dim TxtValBas As TextBox = DirectCast(Me.Repeater1.Items(i).FindControl("TxtValBas"), TextBox)
            'LiqP(i).CODE_VABA = CDbl(TxtValBas.Text.Replace("$", ""))
            'LiqP(i).CODE_IMPTO = HdCimp.Value
            'LiqP(i).CODE_TARI = HdTari.Value
            'Else
            LiqP(i).CODE_VABA = Nothing
            'End If
            r = i + 1

            ' si calcula el valor declaracdo
            'If HdCTar.Value = "S" Then
            'LiqP(i).CODE_VADE = objCd.RedondearUp(LiqP(i).CODE_VABA * LiqP(i).CODE_TARI)
            'Else
            LiqP(i).CODE_VADE = CDbl(txtR.Text.Replace("$", ""))
            'End If
            'SI ES SANCIÓN
            If HdTICO.Value = "S" Then
                LiqP(i).CODE_TSAN = CboTSan.SelectedValue
                If ((Me.HdExtem.Value = "S") And (Me.HdTD.Value = "I")) Or (Me.HdTD.Value = "C") Then
                    Select Case CboTSan.SelectedValue
                        Case "00"
                            Me.MsgResult.Text = "Debe Seleccionar el Tipo de Sanción de la Liquidación Privada"
                            Me.ModalPopup.Show()
                            Return False
                        Case "01"
                            LiqP(i).CODE_VADE = objCd.GetSancion_Extemporaneidad(C_K, CDate(Me.HdFecDec.Value), CDate(Me.HdFecLim.Value), 0)
                        Case "02"
                            LiqP(i).CODE_VADE = objCd.GetSancion_Extemporaneidad(C_K, CDate(Me.HdFecDec.Value), CDate(Me.HdFecLim.Value), 1)
                        Case Else
                            LiqP(i).CODE_VADE = 0
                    End Select
                    C_S = LiqP(i).CODE_VADE
                End If
            End If

            txtR.Text = LiqP(i).CODE_VADE

            If HdSum.Value = "S" Then
                LiqP(i).CODE_VADE = Tr
                txtR.Text = LiqP(i).CODE_VADE
                If LiqP(i).CODE_TICO = "K" Then
                    C_K = LiqP(i).CODE_VADE
                End If
            Else
                Tr += IIf(HdTMOV.Value = "DEBI", 1, -1) * LiqP(i).CODE_VADE
            End If
            If LiqP(i).CODE_TICO = "D" Then
                C_D = C_K + C_S
            End If

            j = i
        Next i
        j = j + 1
        'Tr = 0
        For i As Integer = 0 To Cant2 - 1

            Dim txtR As TextBox = DirectCast(Me.Repeater2.Items(i).FindControl("TxtR"), TextBox)
            Dim HdCodi As HiddenField = DirectCast(Me.Repeater2.Items(i).FindControl("HdCodi"), HiddenField)
            Dim HdIsVB As HiddenField = DirectCast(Me.Repeater2.Items(i).FindControl("HdIsVB"), HiddenField)
            Dim HdTICO As HiddenField = DirectCast(Me.Repeater2.Items(i).FindControl("HdTICO"), HiddenField)
            Dim HdCimp As HiddenField = DirectCast(Me.Repeater2.Items(i).FindControl("HdCimp"), HiddenField)
            Dim HdSECO As HiddenField = DirectCast(Me.Repeater2.Items(i).FindControl("HdSECO"), HiddenField)
            Dim HdTMOV As HiddenField = DirectCast(Me.Repeater2.Items(i).FindControl("HdTMOV"), HiddenField)
            Dim HdCART As HiddenField = DirectCast(Me.Repeater2.Items(i).FindControl("HdCART"), HiddenField)
            Dim HdCCAR As HiddenField = DirectCast(Me.Repeater2.Items(i).FindControl("HdCCAR"), HiddenField)
            Dim HdSum As HiddenField = DirectCast(Me.Repeater2.Items(i).FindControl("HdSum"), HiddenField)

            Dim CboTSan As DropDownList = DirectCast(Me.Repeater2.Items(i).FindControl("CboTSan"), DropDownList)
            'Dim LbABIM As Label = DirectCast(Me.Repeater2.Items(i).FindControl("LbABIM"), Label)
            'Dim LbABVD As Label = DirectCast(Me.Repeater2.Items(i).FindControl("LbABVD"), Label)
            Dim LbNomImp As Label = DirectCast(Me.Repeater2.Items(i).FindControl("LbNomImp"), Label)
            LiqP(j).CODE_DEES = ""
            'LiqP(j).CODE_ABVD = LbABVD.Text
            LiqP(j).CODE_CART = HdCART.Value
            LiqP(j).CODE_CDEC = Me.Cla_Dec.Value
            LiqP(j).CODE_CODI = HdCodi.Value
            LiqP(j).CODE_ISVB = HdIsVB.Value
            LiqP(j).CODE_NOMB = LbNomImp.Text
            LiqP(j).CODE_REDE = ""
            LiqP(j).CODE_SECO = HdSECO.Value
            LiqP(j).CODE_TICO = HdTICO.Value
            LiqP(j).CODE_TMOV = HdTMOV.Value
            LiqP(j).CODE_USAP = ""
            LiqP(j).CODE_USBD = ""
            LiqP(j).CODE_VACA = 0
            LiqP(j).CODE_VAOF = 0
            LiqP(j).CODE_VASU = 0
            LiqP(j).CODE_CCAR = HdCCAR.Value
            LiqP(j).CODE_SUM = HdSum.Value

            If HdTICO.Value = "D" Then
                'Me.MsgResult.Text = "Valor a Pagar" + txtR.Text
                'Me.ModalPopup.Show()
                LiqP(j).CODE_VADE = C_D
                Tr += LiqP(j).CODE_VADE
                txtR.Text = LiqP(j).CODE_VADE
            End If

            If HdTICO.Value = "I" Then
                'LiqP(j).CODE_VADE = objCd.GetInteresMoraC(C_K, CDate(Me.HdFecLim.Value), CDate(Me.HdFecDec.Value))
                'txtR.Text = LiqP(j).CODE_VADE
                C_I = LiqP(j).CODE_VADE
                Tr += LiqP(j).CODE_VADE
            End If

            If HdSum.Value = "S" And HdTICO.Value = "T" Then
                txtR.Text = Tr
                LiqP(j).CODE_VADE = Tr
                HdTot.Value = Tr
            End If

            txtR.Text = LiqP(j).CODE_VADE

            j += 1
        Next i
        Me.Label2.Text = ""
        Return True
    End Function

    Public Function Cargar_CODE(ByRef LP As LPCODE_CDEC()) As Boolean

        Me.Label2.Text = ""
        Dim Cant As Integer = Me.Repeater1.Items.Count
        Dim Cant2 As Integer = Me.Repeater2.Items.Count
        Dim LiqP(Cant + Cant2 - 1) As LPCODE_CDEC

        Dim Tr As Double = 0
        Dim r As Integer = 0
        Dim j As Integer = 0
        For i As Integer = 0 To Cant - 1
            Dim txtR As TextBox = DirectCast(Me.Repeater1.Items(i).FindControl("TxtR"), TextBox)

            Dim HdCodi As HiddenField = DirectCast(Me.Repeater1.Items(i).FindControl("HdCodi"), HiddenField)
            Dim HdIsVB As HiddenField = DirectCast(Me.Repeater1.Items(i).FindControl("HdIsVB"), HiddenField)
            Dim HdTICO As HiddenField = DirectCast(Me.Repeater1.Items(i).FindControl("HdTICO"), HiddenField)
            Dim HdCimp As HiddenField = DirectCast(Me.Repeater1.Items(i).FindControl("HdCimp"), HiddenField)
            Dim HdSECO As HiddenField = DirectCast(Me.Repeater1.Items(i).FindControl("HdSECO"), HiddenField)
            Dim HdTMOV As HiddenField = DirectCast(Me.Repeater1.Items(i).FindControl("HdTMOV"), HiddenField)
            Dim HdCART As HiddenField = DirectCast(Me.Repeater1.Items(i).FindControl("HdCART"), HiddenField)
            Dim HdCCAR As HiddenField = DirectCast(Me.Repeater1.Items(i).FindControl("HdCCAR"), HiddenField)
            Dim HdSum As HiddenField = DirectCast(Me.Repeater1.Items(i).FindControl("HdSum"), HiddenField)
            Dim HdTari As HiddenField = DirectCast(Me.Repeater1.Items(i).FindControl("HdTari"), HiddenField)
            Dim HdCTar As HiddenField = DirectCast(Me.Repeater1.Items(i).FindControl("HdCTar"), HiddenField)

            '            Dim LbABIM As Label = DirectCast(Me.Repeater1.Items(i).FindControl("LbABIM"), Label)
            'Dim LbABVD As Label = DirectCast(Me.Repeater1.Items(i).FindControl("LbABVD"), Label)
            Dim LbNomImp As Label = DirectCast(Me.Repeater1.Items(i).FindControl("LbNomImp"), Label)
            Dim CboTSan As DropDownList = DirectCast(Me.Repeater1.Items(i).FindControl("CboTSan"), DropDownList)

            LiqP(i).CODE_DEES = ""
            '          LiqP(i).CODE_ABVB = LbABIM.Text
            'LiqP(i).CODE_ABVD = LbABVD.Text
            LiqP(i).CODE_CART = HdCART.Value
            LiqP(i).CODE_CDEC = Me.Cla_Dec.Value
            LiqP(i).CODE_CODI = HdCodi.Value
            LiqP(i).CODE_ISVB = HdIsVB.Value
            LiqP(i).CODE_NOMB = LbNomImp.Text
            LiqP(i).CODE_REDE = ""
            LiqP(i).CODE_SECO = HdSECO.Value
            LiqP(i).CODE_TICO = HdTICO.Value
            LiqP(i).CODE_TMOV = HdTMOV.Value
            LiqP(i).CODE_USAP = ""
            LiqP(i).CODE_USBD = ""
            LiqP(i).CODE_VACA = 0
            LiqP(i).CODE_VAOF = 0
            LiqP(i).CODE_VASU = 0
            LiqP(i).CODE_CCAR = HdCCAR.Value
            LiqP(i).CODE_SUM = HdSum.Value

            'si tiene valor base

            '         If HdIsVB.Value = "S" Then
            'Dim TxtValBas As TextBox = DirectCast(Me.Repeater1.Items(i).FindControl("TxtValBas"), TextBox)
            'LiqP(i).CODE_VABA = CDbl(TxtValBas.Text.Replace("$", ""))
            'LiqP(i).CODE_IMPTO = HdCimp.Value
            'LiqP(i).CODE_TARI = HdTari.Value

            'Else
            'LiqP(i).CODE_VABA = Nothing
            'End If
            r = i + 1

            ' si calcula el valor declaracdo
            'If HdCTar.Value = "S" Then
            ' LiqP(i).CODE_VADE = objCd.RedondearUp(LiqP(i).CODE_VABA * LiqP(i).CODE_TARI)
            'Else
            LiqP(i).CODE_VADE = CDbl(txtR.Text.Replace("$", ""))
            'End If

            If HdSum.Value = "S" Then
                LiqP(i).CODE_VADE = Tr
                txtR.Text = LiqP(i).CODE_VADE
            Else
                Tr += IIf(HdTMOV.Value = "DEBI", 1, -1) * LiqP(i).CODE_VADE
            End If

            'SI ES SANCIÓN
            If HdTICO.Value = "S" Then
                Me.Label2.Text += "Sancion:" + (CboTSan.SelectedValue)
                LiqP(i).CODE_TSAN = CboTSan.SelectedValue
                If ((Me.HdExtem.Value = "S") And (Me.HdTD.Value = "I")) Or (Me.HdTD.Value = "C") Then
                    If CDbl(txtR.Text.Replace("$", "")) < CDbl(Me.HdSancionMinima.Value) Then
                        Me.MsgResult.Text = "<B>" + "</b><br>Valor de la Sanción debe ser mayor  o igual a la sanción minima"
                        Me.ModalPopup.Show()
                        Return False
                    End If
                    If CboTSan.SelectedValue = "00" Then
                        Me.MsgResult.Text = "Debe Seleccionar el Tipo de Sanción de la Liquidación Privada"
                        Me.ModalPopup.Show()
                        Return False
                    Else
                        'objcd.GetSancion_Extemporaneidad(me.HdFecLim
                    End If
                End If
            End If
            txtR.Text = LiqP(i).CODE_VADE
            j = i
        Next i
        j = j + 1
        Tr = 0
        For i As Integer = 0 To Cant2 - 1
            Dim txtR As TextBox = DirectCast(Me.Repeater2.Items(i).FindControl("TxtR"), TextBox)

            Dim HdCodi As HiddenField = DirectCast(Me.Repeater2.Items(i).FindControl("HdCodi"), HiddenField)
            Dim HdIsVB As HiddenField = DirectCast(Me.Repeater2.Items(i).FindControl("HdIsVB"), HiddenField)
            Dim HdTICO As HiddenField = DirectCast(Me.Repeater2.Items(i).FindControl("HdTICO"), HiddenField)
            Dim HdCimp As HiddenField = DirectCast(Me.Repeater2.Items(i).FindControl("HdCimp"), HiddenField)
            Dim HdSECO As HiddenField = DirectCast(Me.Repeater2.Items(i).FindControl("HdSECO"), HiddenField)
            Dim HdTMOV As HiddenField = DirectCast(Me.Repeater2.Items(i).FindControl("HdTMOV"), HiddenField)
            Dim HdCART As HiddenField = DirectCast(Me.Repeater2.Items(i).FindControl("HdCART"), HiddenField)
            Dim HdCCAR As HiddenField = DirectCast(Me.Repeater2.Items(i).FindControl("HdCCAR"), HiddenField)
            Dim HdSum As HiddenField = DirectCast(Me.Repeater2.Items(i).FindControl("HdSum"), HiddenField)

            Dim CboTSan As DropDownList = DirectCast(Me.Repeater2.Items(i).FindControl("CboTSan"), DropDownList)
            'Dim LbABIM As Label = DirectCast(Me.Repeater2.Items(i).FindControl("LbABIM"), Label)
            'Dim LbABVD As Label = DirectCast(Me.Repeater2.Items(i).FindControl("LbABVD"), Label)
            Dim LbNomImp As Label = DirectCast(Me.Repeater2.Items(i).FindControl("LbNomImp"), Label)

            LiqP(j).CODE_DEES = ""
            'LiqP(j).CODE_ABVD = LbABVD.Text
            LiqP(j).CODE_CART = HdCART.Value
            LiqP(j).CODE_CDEC = Me.Cla_Dec.Value
            LiqP(j).CODE_CODI = HdCodi.Value
            LiqP(j).CODE_ISVB = HdIsVB.Value
            LiqP(j).CODE_NOMB = LbNomImp.Text
            LiqP(j).CODE_REDE = ""
            LiqP(j).CODE_SECO = HdSECO.Value
            LiqP(j).CODE_TICO = HdTICO.Value
            LiqP(j).CODE_TMOV = HdTMOV.Value
            LiqP(j).CODE_USAP = ""
            LiqP(j).CODE_USBD = ""
            LiqP(j).CODE_VACA = 0
            LiqP(j).CODE_VAOF = 0
            LiqP(j).CODE_VASU = 0
            LiqP(j).CODE_CCAR = HdCCAR.Value
            LiqP(j).CODE_SUM = HdSum.Value

            If HdSum.Value = "S" Then
                txtR.Text = Tr
                LiqP(j).CODE_VADE = Tr
                HdTot.Value = Tr
            Else
                Tr += CDbl(txtR.Text.Replace("$", ""))
                LiqP(j).CODE_VADE = CDbl(txtR.Text.Replace("$", ""))
            End If
            j += 1
        Next i

        Me.Label2.Text = ""
        LP = LiqP

        Return True

    End Function
    Protected Sub BtnPDF_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        'Me.HdNroDec.Value = "20090100246"
        Me.Cargar_Rpt()
    End Sub
    Protected Sub Page_PreRender(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.PreRender
        'SpanAyuda
        Me.objCd = New CDeclaraciones(Me.Cla_Dec.Value)
        Dim dt As DataTable = Me.objCd.GetRAyuda(Me.HdFODE.Value)
        Dim Nr As Integer, Desc As String, Tit As String
        Dim strjscript As String = "function ActualizarAyuda(){"
        For i As Integer = 0 To dt.Rows.Count - 1
            Nr = dt.Rows(i)("FoAy_Nren").ToString
            Tit = dt.Rows(i)("FoAy_TITU").ToString
            Desc = (dt.Rows(i)("FoAy_Desc").ToString)
            '.firstChild.nodeValue
            strjscript = strjscript & "if(document.form1." + Me.HdRenglon.ClientID + ".value==" + Nr.ToString + "){"
            strjscript = strjscript & "document.getElementById('" + Me.LbAyudaTit.ClientID + "').innerHTML=' RENGLON N° ' + document.form1." + Me.HdRenglon.ClientID + ".value +'- " + Tit + " ';"
            strjscript = strjscript & "document.getElementById('" + Me.LbAyuda.ClientID + "').innerHTML='" + Desc + "';}"
        Next i
        strjscript = strjscript & "}"

        ScriptManager.RegisterClientScriptBlock(Me, GetType(Page), "ActualizarAyuda", strjscript, True)
        'Response.Write(strjscript)
        'strjscript = strjscript & "window.opener.document.aspnetForm.ctl00$FlowerText$TxtNom.value=nom;"
        'strjscript = strjscript & "window.close();window.opener.focus();}"
    End Sub


    Protected Sub btnInfo_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btnInfo.Click

    End Sub

    Private Sub IrAtras()
        Response.Redirect(Me.RUTA_VIRTUAL + "declaraciones/diligenciar/seldec.aspx")
    End Sub


    Protected Sub BtnGuardarD_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs)
        Me.BtnGuardarD.Enabled = False
        '        Me.BtnGuardarD.ImageUrl = "~/images/BotonesWeb/BtGDecDes.Png"
        If Guardar_Dec() = True Then
            Me.BtnGPDF.Enabled = True
            '           Me.BtnGuardarD.ImageUrl = "~/images/BotonesWeb/BtGenPDF.Png"
        Else

            Me.BtnGPDF.Enabled = False
            '          Me.BtnGuardarD.ImageUrl = "~/images/BotonesWeb/BtGenPDF.Png"

            Me.BtnGuardarD.Enabled = True
            '         Me.BtnGuardarD.ImageUrl = "~/images/BotonesWeb/BtGDec.Png"

        End If
    End Sub


    Function Guardar_Dec() As Boolean

        Dim Dec_Cod As String = ""
        Dim Tip_Decla As String = Me.HdDecTip.Value
        objCd = New CDeclaraciones(Me.Cla_Dec.Value)
        Dim aLp As LPCODE_CDEC()
        If Me.Cargar_CODE(aLp) = False Then
            Return False
        End If
        Dim DEC_TRET As Double = Me.TOTAL_RETENCIONES
        Dim DEC_TSAN As Double = 0
        Dim DEC_PRS As Double = 0
        Dim DEC_PIM As Double = 0
        Dim DEC_PTOT As Double = Me.HdTot.Value
        'DEC_PTOT = DEC_PIM + DEC_PRS
        Dim DEC_CSAN As String = "00"
        Dim dec_cdec As String = Me.Cla_Dec.Value
        Dim Dec_FDCO As String = Me.HdFODE.Value
        Dim Dec_Fven As Date = CDate(Me.HdFecLim.Value)

        Dim dec_tot As Double = 0
        Me.TD = Me.HdTD.Value
        MsgResult.Text = objCd.Insert(Dec_Cod, dec_cdec, Me.Identificaciòn.Text, Me.DV.Text.Trim, AGravable.Text, PGravable.Text, Me.TxtDecCorrige.Text, DEC_TRET, DEC_CSAN, DEC_TSAN, dec_tot, DEC_PRS, DEC_PIM, DEC_PTOT, Tip_Decla, Me.Agente.Text, Dec_FDCO, Dec_Fven, Me.TD, aLp, Me.HdDOAD.Value)

        Me.MsgResult.Visible = True
        'Me.MsgBox(MsgResult, objCd.lErrorG)
        If objCd.lErrorG = False Then
            Me.MsgResult.Text = ConfigurationManager.AppSettings("MSG_PRE_DEC") + "<br>Formulario N° :" + Dec_Cod
            Me.HdNroDec.Value = Dec_Cod
            Me.TxtNForm.Text = Dec_Cod
            Me.MsgResult.ForeColor = Drawing.Color.Black
            Me.ImgRst.ImageUrl = Me.IMGOK.ToString
            Me.ModalPopup.Show()
            Return True
        Else
            Me.MsgResult.ForeColor = Drawing.Color.Red
            Me.ImgRst.ImageUrl = Me.IMGNOTOK.ToString
            'Me.BtnPDF.Enabled = False
            Me.ModalPopup.Show()
            Return False
        End If

    End Function

    Protected Sub BtnGPDF_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs)
        Me.Cargar_Rpt()
    End Sub

    Protected Sub BtnIrAtras_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs)
        IrAtras()
    End Sub

    Protected Sub BtnLiq_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs)
        Dim Tip_Decla As String = Me.HdDecTip.Value
        objCd = New CDeclaraciones(Me.Cla_Dec.Value)
        Me.Liquidar()

    End Sub

    Public Function Liquidar() As Boolean

        Me.Label2.Text = ""
        Dim Cant As Integer = Me.Repeater1.Items.Count
        Dim Cant2 As Integer = Me.Repeater2.Items.Count
        Dim LiqP(Cant + Cant2 - 1) As LPCODE_CDEC

        Dim Tr As Double = 0
        Dim r As Integer = 0
        Dim j As Integer = 0

        Dim C_K As Decimal = 0
        Dim C_T As Decimal = 0
        Dim C_D As Decimal = 0
        Dim C_I As Decimal = 0
        Dim C_S As Decimal = 0

        For i As Integer = 0 To Cant - 1
            Dim txtR As TextBox = DirectCast(Me.Repeater1.Items(i).FindControl("TxtR"), TextBox)

            Dim HdCodi As HiddenField = DirectCast(Me.Repeater1.Items(i).FindControl("HdCodi"), HiddenField)
            Dim HdIsVB As HiddenField = DirectCast(Me.Repeater1.Items(i).FindControl("HdIsVB"), HiddenField)
            Dim HdTICO As HiddenField = DirectCast(Me.Repeater1.Items(i).FindControl("HdTICO"), HiddenField)
            Dim HdCimp As HiddenField = DirectCast(Me.Repeater1.Items(i).FindControl("HdCimp"), HiddenField)
            Dim HdSECO As HiddenField = DirectCast(Me.Repeater1.Items(i).FindControl("HdSECO"), HiddenField)
            Dim HdTMOV As HiddenField = DirectCast(Me.Repeater1.Items(i).FindControl("HdTMOV"), HiddenField)
            Dim HdCART As HiddenField = DirectCast(Me.Repeater1.Items(i).FindControl("HdCART"), HiddenField)
            Dim HdCCAR As HiddenField = DirectCast(Me.Repeater1.Items(i).FindControl("HdCCAR"), HiddenField)
            Dim HdSum As HiddenField = DirectCast(Me.Repeater1.Items(i).FindControl("HdSum"), HiddenField)
            Dim HdTari As HiddenField = DirectCast(Me.Repeater1.Items(i).FindControl("HdTari"), HiddenField)
            Dim HdCTar As HiddenField = DirectCast(Me.Repeater1.Items(i).FindControl("HdCTar"), HiddenField)

            Dim LbABIM As Label = DirectCast(Me.Repeater1.Items(i).FindControl("LbABIM"), Label)
            Dim LbABVD As Label = DirectCast(Me.Repeater1.Items(i).FindControl("LbABVD"), Label)
            Dim LbNomImp As Label = DirectCast(Me.Repeater1.Items(i).FindControl("LbNomImp"), Label)
            Dim CboTSan As DropDownList = DirectCast(Me.Repeater1.Items(i).FindControl("CboTSan"), DropDownList)

            LiqP(i).CODE_DEES = ""
            'LiqP(i).CODE_ABVB = LbABIM.Text
            'LiqP(i).CODE_ABVD = LbABVD.Text
            LiqP(i).CODE_CART = HdCART.Value
            LiqP(i).CODE_CDEC = Me.Cla_Dec.Value
            LiqP(i).CODE_CODI = HdCodi.Value
            LiqP(i).CODE_ISVB = HdIsVB.Value
            LiqP(i).CODE_NOMB = LbNomImp.Text
            LiqP(i).CODE_REDE = ""
            LiqP(i).CODE_SECO = HdSECO.Value
            LiqP(i).CODE_TICO = HdTICO.Value
            LiqP(i).CODE_TMOV = HdTMOV.Value
            LiqP(i).CODE_USAP = ""
            LiqP(i).CODE_USBD = ""
            LiqP(i).CODE_VACA = 0
            LiqP(i).CODE_VAOF = 0
            LiqP(i).CODE_VASU = 0
            LiqP(i).CODE_CCAR = HdCCAR.Value
            LiqP(i).CODE_SUM = HdSum.Value
            'si tiene valor base
            'If HdIsVB.Value = "S" Then
            'Dim TxtValBas As TextBox = DirectCast(Me.Repeater1.Items(i).FindControl("TxtValBas"), TextBox)
            'LiqP(i).CODE_VABA = CDbl(TxtValBas.Text.Replace("$", ""))
            'LiqP(i).CODE_IMPTO = HdCimp.Value
            'LiqP(i).CODE_TARI = HdTari.Value
            'Else
            LiqP(i).CODE_VABA = Nothing
            'End If
            r = i + 1
            ' si calcula el valor declaracdo
            'If HdCTar.Value = "S" Then
            'LiqP(i).CODE_VADE = objCd.RedondearUp(LiqP(i).CODE_VABA * LiqP(i).CODE_TARI)
            'Else
            LiqP(i).CODE_VADE = CDbl(txtR.Text.Replace("$", ""))
            'End If
            'SI ES SANCIÓN
            If HdTICO.Value = "S" Then
                LiqP(i).CODE_TSAN = CboTSan.SelectedValue
                If ((Me.HdExtem.Value = "S") And (Me.HdTD.Value = "I")) Or (Me.HdTD.Value = "C") Then
                    Select Case CboTSan.SelectedValue
                        Case "00"
                            Me.MsgResult.Text = "Debe Seleccionar el Tipo de Sanción de la Liquidación Privada"
                            Me.ModalPopup.Show()
                            Return False
                        Case "01"
                            LiqP(i).CODE_VADE = objCd.GetSancion_Extemporaneidad(C_K, CDate(Me.HdFecDec.Value), CDate(Me.HdFecLim.Value), 0)
                        Case "02"
                            LiqP(i).CODE_VADE = objCd.GetSancion_Extemporaneidad(C_K, CDate(Me.HdFecDec.Value), CDate(Me.HdFecLim.Value), 1)
                        Case Else
                            LiqP(i).CODE_VADE = 0
                    End Select
                    C_S = LiqP(i).CODE_VADE
                End If
            End If

            txtR.Text = LiqP(i).CODE_VADE

            If HdSum.Value = "S" Then
                LiqP(i).CODE_VADE = Tr
                txtR.Text = LiqP(i).CODE_VADE
                If LiqP(i).CODE_TICO = "K" Then
                    C_K = LiqP(i).CODE_VADE
                End If
            Else
                Tr += IIf(HdTMOV.Value = "DEBI", 1, -1) * LiqP(i).CODE_VADE
            End If
            If LiqP(i).CODE_TICO = "D" Then
                C_D = C_K + C_S
            End If

            j = i
        Next i
        j = j + 1
        Tr = 0
        For i As Integer = 0 To Cant2 - 1

            Dim txtR As TextBox = DirectCast(Me.Repeater2.Items(i).FindControl("TxtR"), TextBox)
            Dim HdCodi As HiddenField = DirectCast(Me.Repeater2.Items(i).FindControl("HdCodi"), HiddenField)
            Dim HdIsVB As HiddenField = DirectCast(Me.Repeater2.Items(i).FindControl("HdIsVB"), HiddenField)
            Dim HdTICO As HiddenField = DirectCast(Me.Repeater2.Items(i).FindControl("HdTICO"), HiddenField)
            Dim HdCimp As HiddenField = DirectCast(Me.Repeater2.Items(i).FindControl("HdCimp"), HiddenField)
            Dim HdSECO As HiddenField = DirectCast(Me.Repeater2.Items(i).FindControl("HdSECO"), HiddenField)
            Dim HdTMOV As HiddenField = DirectCast(Me.Repeater2.Items(i).FindControl("HdTMOV"), HiddenField)
            Dim HdCART As HiddenField = DirectCast(Me.Repeater2.Items(i).FindControl("HdCART"), HiddenField)
            Dim HdCCAR As HiddenField = DirectCast(Me.Repeater2.Items(i).FindControl("HdCCAR"), HiddenField)
            Dim HdSum As HiddenField = DirectCast(Me.Repeater2.Items(i).FindControl("HdSum"), HiddenField)

            Dim CboTSan As DropDownList = DirectCast(Me.Repeater2.Items(i).FindControl("CboTSan"), DropDownList)
            'Dim LbABIM As Label = DirectCast(Me.Repeater2.Items(i).FindControl("LbABIM"), Label)
            'Dim LbABVD As Label = DirectCast(Me.Repeater2.Items(i).FindControl("LbABVD"), Label)
            Dim LbNomImp As Label = DirectCast(Me.Repeater2.Items(i).FindControl("LbNomImp"), Label)
            LiqP(j).CODE_DEES = ""
            'LiqP(j).CODE_ABVD = LbABVD.Text
            LiqP(j).CODE_CART = HdCART.Value
            LiqP(j).CODE_CDEC = Me.Cla_Dec.Value
            LiqP(j).CODE_CODI = HdCodi.Value
            LiqP(j).CODE_ISVB = HdIsVB.Value
            LiqP(j).CODE_NOMB = LbNomImp.Text
            LiqP(j).CODE_REDE = ""
            LiqP(j).CODE_SECO = HdSECO.Value
            LiqP(j).CODE_TICO = HdTICO.Value
            LiqP(j).CODE_TMOV = HdTMOV.Value
            LiqP(j).CODE_USAP = ""
            LiqP(j).CODE_USBD = ""
            LiqP(j).CODE_VACA = 0
            LiqP(j).CODE_VAOF = 0
            LiqP(j).CODE_VASU = 0
            LiqP(j).CODE_CCAR = HdCCAR.Value
            LiqP(j).CODE_SUM = HdSum.Value

            If HdTICO.Value = "D" Then
                'Me.MsgResult.Text = "Valor a Pagar" + txtR.Text
                'Me.ModalPopup.Show()
                LiqP(j).CODE_VADE = C_D
                Tr += LiqP(j).CODE_VADE
                txtR.Text = LiqP(j).CODE_VADE
            End If

            If HdTICO.Value = "I" Then
                LiqP(j).CODE_VADE = objCd.GetInteresMoraC(C_K, CDate(Me.HdFecLim.Value), CDate(Me.HdFecDec.Value))
                txtR.Text = LiqP(j).CODE_VADE
                C_I = LiqP(j).CODE_VADE
                Tr += LiqP(j).CODE_VADE
            End If

            If HdSum.Value = "S" And HdTICO.Value = "T" Then
                txtR.Text = Tr
                LiqP(j).CODE_VADE = Tr
                HdTot.Value = Tr
            End If

            txtR.Text = LiqP(j).CODE_VADE

            j += 1
        Next i
        Me.Label2.Text = ""


        Me.BtnLiq.Enabled = True
        Me.BtnGuardarD.Enabled = True
        Me.BtnGPDF.Enabled = False
        Return True
    End Function

    Protected Sub ToolkitScriptManager1_AsyncPostBackError(ByVal sender As Object, ByVal e As System.Web.UI.AsyncPostBackErrorEventArgs) Handles ToolkitScriptManager1.AsyncPostBackError
        If (Not IsNothing(e.Exception)) And (Not IsNothing(e.Exception.InnerException)) Then
            ToolkitScriptManager1.AsyncPostBackErrorMessage = e.Exception.InnerException.Message
        End If

    End Sub



End Class

