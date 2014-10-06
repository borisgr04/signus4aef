Imports System.Data
Imports Signus

Partial Class Declaraciones_Diligenciar_SelDec
    Inherits PaginaComun
    Dim objcd As CDeclaraciones
    Dim Objsig As Signatario = New Signatario
    Dim _TotalLiq As String
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load


        Me.LBTITULO.Text = "Diligenciar Declaraciones "
        Me.Opcion = Me.LBTITULO.Text
        Me.SetTitulo()
        Me.ToolkitScriptManager1.RegisterAsyncPostBackControl(Me.ConsultaTer1)

        If Not Me.IsPostBack Then
            Me.CbCdec.Attributes.Add("OnFocus", "javascript:UpdateCombo()")
            'Me.ROptTD.SelectedValue = "01"
            Dim dt As DataTable = Me.UsuTercero.GetByUser()
            '            Me.MsgResult.Text = dt.Rows(0)("Ter_TUS").ToString() + "-" + dt.Rows(0)("TUS_NOM").ToString()
            If (dt.Rows.Count > 0) Then
                HdAR.Value = dt.Rows(0)("Ter_TUS").ToString()
                If (dt.Rows(0)("Ter_TUS").ToString() = "AR") Then
                    Me.Agente.Text = dt.Rows(0)("Ter_Nom").ToString
                    Me.Nit.Text = dt.Rows(0)("Ter_nit").ToString
                    Me.Dv.Text = Trim(dt.Rows(0)("Ter_dver").ToString)
                    '----------Tipo de Agente----------------
                    Me.HdTAG.Value = dt.Rows(0)("Ter_tip").ToString
                    '-------------------------
                    Me.Cargar_Signatarios()
                    Me.BtnBuscDP.Visible = False
                    Me.CbCdec.DataBind()
                    Me.CbCdec.SelectedValue = Request("cdec")
                    Me.CboVigencia.DataBind()
                    Me.CboVigencia.SelectedValue = Request("vig")
                    Me.Periodo.DataBind()
                    Me.Periodo.SelectedValue = Request("per")
                Else
                    Me.BtnBuscDP.Visible = True
                End If
            End If
        End If

    End Sub
    Public Sub Diligenciar_Dec()
        If Me.Nit.Text = "" Then
            Me.MsgResult.Text = "Seleccione un Agente Recaudador "
            Me.MsgBox(Me.MsgResult, True)
            Exit Sub
        End If


        Dim obj As Tipo_Dec = New Tipo_Dec
        'Dim ObdCd As CDeclaraciones = New CDeclaraciones(Me.Cla_Dec.Value)
        Dim ClDec As String = Me.CbCdec.SelectedValue
        objcd = New CDeclaraciones(ClDec)
        Dim DOAD As String = "DELP"
        '---------------------
        Dim objcal As Calendario = New Calendario
        Dim dtc As DataTable = objcal.GetPorAñoyPer(ClDec, Me.CboVigencia.SelectedValue, Me.Periodo.SelectedValue)
        'REVISAR SANCIONES E INTERESES
        Dim cal_ffin As Date = CDate(dtc.Rows(0)("Cal_Ffin").ToString())

        Dim OMMD As String = objcd.GetOMMD(cal_ffin)
        If (OMMD = "S") And (Me.ChkDecCero.Checked = False) Then
            Dim objBl As BasesLiq = New BasesLiq
            If objBl.isExits(Me.Nit.Text, ClDec, Me.CboVigencia.SelectedValue, Me.Periodo.SelectedValue) = False Then
                Me.MsgResult.Text = "No puede Diligenciar Declaración<br>Debe Validar y Cargar Medios Magnéticos Para Este Periodo Gravable "
                Me.MsgBox(Me.MsgResult, True)
                Exit Sub
            End If
        End If

        Dim Año As String = Me.CboVigencia.SelectedValue
        Dim Per As String = Me.Periodo.SelectedValue
        Dim dt As DataTable
        Dim tp As String
        ' Validar Signatarios
        Dim objs As New Signatario()
        Dim dts As DataTable = objs.GetRecords(Me.Nit.Text)
        Dim OSIG As String = objcd.GetOSIG(cal_ffin)
        If (OSIG = "S") Then
            If (dts.Rows.Count <= 0) And (HdAR.Value = "AR") Then
                Me.MsgResult.Text = "Debe Asignar Signatarios"
                Me.MsgBox(Me.MsgResult, True)
                Exit Sub
            End If
        End If
        dts.Clear()

        tp = obj.GetCodiTD(ClDec, Me.ROptTD.SelectedValue)

        Dim nit As String = Me.Nit.Text
        Dim tdNd As DataTable = objcd.GetDecByPer(nit, Me.CboVigencia.SelectedValue, Me.Periodo.SelectedValue)

        dt = Me.objcd.GetFormularios_Dec(Año, Per).Tables(0)
        Dim tip_dec As String = Me.ROptTD.SelectedValue
        If (tp = "I") Then
            If (tdNd.Rows.Count > 0) Then
                Me.MsgResult.Text = "Ya existe una Declaración Inicial, " + ClDec + " Formulario N°" + tdNd.Rows(0)("Dec_Cod").ToString + " Sino ha Presentado esta declaración al banco puede anularla y crear una nueva declaración"
                Me.MsgBox(Me.MsgResult, True)
            Else
                Me.MsgResult.Text = "Abrir "
                Me.MsgResult.Text = "Clase Dec " + ClDec + " Año Gravable " + Año + " Periodo Gravable " + Per + "Tipo " + Me.ROptTD.SelectedValue
                querystringSeguro = Me.SetRequest()
                querystringSeguro("CDec") = ClDec
                querystringSeguro("AGravable") = Año
                querystringSeguro("PGravable") = Per
                querystringSeguro("DecTip") = tip_dec
                querystringSeguro("Nit") = nit
                querystringSeguro("TD") = tp
                querystringSeguro("FODE_CODI") = dt.Rows(0)("Fode_Codi").ToString
                querystringSeguro("DOAD") = DOAD
                Me.MsgBox(Me.MsgResult, False)
                'Response.Redirect("/Declaraciones/" + dt.Rows(0)("Fode_Fowe").ToString + "?data=" + HttpUtility.UrlEncode(querystringSeguro.ToString()))
                'Me.MsgResult.Text = dt.Rows(0)("Fode_Fowe").ToString
                Redireccionar_Pagina("Declaraciones/" + dt.Rows(0)("Fode_Fowe").ToString + "?data=" + HttpUtility.UrlEncode(querystringSeguro.ToString()))
                'Dim Rt As String = dt.Rows(0)("Fode_Fowe").ToString + "?" + "CDec=" + ClDec + "&AGravable=" + Año + "&PGravable=" + Per + "&DecTip=" + tip_dec + "&Nit=" & nit + "&TD=" + tp + "&FODE_CODI=" & dt.Rows(0)("Fode_Codi").ToString                
                'Me.MsgResult.Text = Rt
                'Response.Redirect(Rt)
            End If
        ElseIf (tp = "C") Then
            If (tdNd.Rows.Count = 0) Then
                Me.MsgResult.Text = "No existe una declaración inicial. No se puede hacer una corrección."
                Me.MsgBox(Me.MsgResult, True)
            ElseIf (tdNd.Rows(0)("Dec_Est") <> "PR") Then
                Me.MsgResult.Text = "La declaración inicial debe estar Pagada para corregirla. Su estado es:" + tdNd.Rows(0)("Dec_Est")
                Me.MsgBox(Me.MsgResult, True)
            Else ' solo si es igual a PR
                Dim Rt As String = dt.Rows(0)("Fode_Fowe").ToString + "?" + "CDec=" + ClDec + "&AGravable=" + Año + "&PGravable=" + Per + "&DecTip=" + Me.ROptTD.SelectedValue + "&Nit=" & nit + "&TD=" + tp + "&FODE_CODI=" & dt.Rows(0)("Fode_codi").ToString + "&Dec_Cor=" + tdNd.Rows(0)("Dec_cod").ToString
                querystringSeguro = Me.SetRequest()
                querystringSeguro("CDec") = ClDec
                querystringSeguro("AGravable") = Año
                querystringSeguro("PGravable") = Per
                querystringSeguro("DecTip") = tip_dec
                querystringSeguro("Nit") = nit
                querystringSeguro("TD") = tp
                querystringSeguro("Dec_Cor") = tdNd.Rows(0)("Dec_cod").ToString
                querystringSeguro("FODE_CODI") = dt.Rows(0)("Fode_Codi").ToString
                querystringSeguro("DOAD") = DOAD

                'Me.MsgResult.Text = Rt
                Me.MsgBox(Me.MsgResult, False)
                'Response.Redirect(Rt)
                '
                Redireccionar_Pagina("Declaraciones/" + dt.Rows(0)("Fode_Fowe").ToString + "?data=" + HttpUtility.UrlEncode(querystringSeguro.ToString()))
            End If
        Else
            Me.MsgResult.Text = "Debe seleccionar un tipo de declaración"
            Me.MsgBox(Me.MsgResult, True)
        End If

    End Sub

    Protected Sub BtnDil_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnDil.Click
        Me.Diligenciar_Dec()
    End Sub

    Protected Sub BtnBuscDP_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnBuscDP.Click
        Me.ModalPopup.Show()
    End Sub

    Protected Sub Cargar_Signatarios()
        Dim nit As String = Me.Nit.Text
        Dim obj As Terceros = New Terceros
        Dim dt As DataTable = obj.GetByIde(nit)
        If dt.Rows.Count > 0 Then
            Me.Agente.Text = dt.Rows(0)("Ter_Nom").ToString
            Me.Nit.Text = dt.Rows(0)("Ter_nit").ToString
            Me.Dv.Text = Trim(dt.Rows(0)("Ter_dver").ToString)

        End If
    End Sub

    <Services.WebMethod()> Public Shared Function GetCurrentDate() As String
        Return DateTime.Now.ToLongTimeString + "XX"
    End Function

    Protected Sub button_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles button.Click
        Me.Cargar_Signatarios()
    End Sub

    Protected Sub CbCdec_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles CbCdec.SelectedIndexChanged
        Me.Cargar_Signatarios()
        Actualizar_Aforo()
    End Sub


    Protected Sub BtnBuscar_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        Me.ModalPopup.Show()


    End Sub

    Protected Sub ToolkitScriptManager1_AsyncPostBackError(ByVal sender As Object, ByVal e As System.Web.UI.AsyncPostBackErrorEventArgs) Handles ToolkitScriptManager1.AsyncPostBackError
        If (Not IsNothing(e.Exception)) And (Not IsNothing(e.Exception.InnerException)) Then
            ToolkitScriptManager1.AsyncPostBackErrorMessage = e.Exception.InnerException.Message + "Ajax"
        End If

    End Sub

    Protected Sub Periodo_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles Periodo.SelectedIndexChanged
        Actualizar_Aforo()
        'If GridView2.Rows.Count > 0 Then ' Validar si tiene datos la grid para mostrar
        'DirectCast(Me.GridView2.FooterRow.FindControl("LbTIMPUESTO"), Label).Text = FormatNumber(dt2.Compute("Sum(ValorImpuesto)", ""))
        'End If

    End Sub

    Sub Actualizar_Aforo()
        Dim obj As BasesLiq = New BasesLiq
        Dim dt2 As New DataTable
        dt2 = obj.GetAforo(Me.HdTAG.Value, Me.CbCdec.SelectedValue, Me.Nit.Text, Me.CboVigencia.SelectedValue, Me.Periodo.SelectedValue)
        Me.GridView2.DataSource = dt2
        Me.GridView2.DataBind()
    End Sub

    Protected Sub BtnIDil_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles BtnIDil.Click
        Me.Diligenciar_Dec()
    End Sub

    Protected Sub GridView2_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles GridView2.SelectedIndexChanged

    End Sub

    Protected Sub GridView2_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles GridView2.RowDataBound
        Select Case e.Row.RowType
            Case DataControlRowType.Header
                Me._TotalLiq = 0
            Case DataControlRowType.DataRow
                If DataBinder.Eval(e.Row.DataItem, "cocd_cdec") = "30" Then
                    If DataBinder.Eval(e.Row.DataItem, "cocd_codi") = "01" Then
                        Me._TotalLiq += CDec(DataBinder.Eval(e.Row.DataItem, "ValorImpuesto"))
                    Else
                        Me._TotalLiq -= CDec(DataBinder.Eval(e.Row.DataItem, "ValorImpuesto"))
                    End If
                Else
                    Me._TotalLiq += CDec(DataBinder.Eval(e.Row.DataItem, "ValorImpuesto"))
                End If
            Case DataControlRowType.Footer
                e.Row.Cells(4).Text = FormatCurrency(Me._TotalLiq.ToString)
                e.Row.Cells(4).HorizontalAlign = HorizontalAlign.Right
                e.Row.Font.Bold = True
        End Select
    End Sub

    Protected Sub ROptTD_DataBound(ByVal sender As Object, ByVal e As System.EventArgs) Handles ROptTD.DataBound
        ROptTD.SelectedIndex = 0
    End Sub

    Protected Sub CboVigencia_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles CboVigencia.SelectedIndexChanged
        Actualizar_Aforo()
    End Sub

    Protected Sub BtnAct_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnAct.Click
        Actualizar_Aforo()
    End Sub
End Class
