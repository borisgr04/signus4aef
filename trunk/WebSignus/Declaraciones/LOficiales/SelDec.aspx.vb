Imports System.Data
Imports Signus

Partial Class Declaraciones_Diligenciar_SelDec
    Inherits PaginaComun
    Dim objcd As CDeclaraciones
    Dim Objsig As Signatario = New Signatario
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load


        Me.LBTITULO.Text = "Diligenciar Declararaciones "
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
                    Me.Cargar_Signatarios()
                    Me.BtnBuscDP.Visible = False
                Else
                    Me.BtnBuscDP.Visible = True
                End If
            End If
        End If
    End Sub

    Protected Sub BtnDil_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnDil.Click

        If Me.Nit.Text = "" Then
            Me.MsgResult.Text = "Seleccione un Agente Recaudador "
            Me.MsgBox(Me.MsgResult, True)
            Exit Sub
        End If

        
        Dim obj As Tipo_Dec = New Tipo_Dec
        'Dim ObdCd As CDeclaraciones = New CDeclaraciones(Me.Cla_Dec.Value)
        Dim ClDec As String = Me.CbCdec.SelectedValue
        objcd = New CDeclaraciones(ClDec)

        '---------------------
        Dim objcal As Calendario = New Calendario
        Dim dtc As DataTable = objcal.GetPorAñoyPer(ClDec, Me.CboVigencia.SelectedValue, Me.Periodo.SelectedValue)
        'REVISAR SANCIONES E INTERESES
        Dim cal_ffin As Date = CDate(dtc.Rows(0)("Cal_Ffin").ToString())

        'Dim OMMD As String = objcd.GetOMMD(cal_ffin)
        'If OMMD = "S" Then
        'Dim objBl As BasesLiq = New BasesLiq
        'If objBl.isExits(Me.Nit.Text, ClDec, Me.CboVigencia.SelectedValue, Me.Periodo.SelectedValue) = False Then
        ' Me.MsgResult.Text = "No puede Diligenciar Declaración<br>Debe Validar y Cargar Medios Magnéticos Para Este Periodo Gravable "
        ' Me.MsgBox(Me.MsgResult, True)
        ' Exit Sub
        ' End If
        ' End If

        Dim Año As String = Me.CboVigencia.SelectedValue
        Dim Per As String = Me.Periodo.SelectedValue
        Dim dt As DataTable
        Dim tp As String
        ' Validar Signatarios
        'Dim objs As New Signatario()
        'Dim dts As DataTable = objs.GetRecords(Me.Nit.Text)
        'If (dts.Rows.Count <= 0) And (HdAR.Value <> "AR") Then
        ' Me.MsgResult.Text = "Debe Asignar Signatarios"
        ' Me.MsgBox(Me.MsgResult, True)
        ' Exit Sub
        ' End If
        ' dts.Clear()

        tp = obj.GetCodiTD(ClDec, Me.ROptTD.SelectedValue)

        Dim nit As String = Me.Nit.Text
        Dim tdNd As DataTable = objcd.GetDecByPer(nit, Me.CboVigencia.SelectedValue, Me.Periodo.SelectedValue)

        dt = Me.objcd.GetFormularios_Dec(Año, Per).Tables(0)
        Dim tip_dec As String = Me.ROptTD.SelectedValue
        If (tp = "I") Then
            If (tdNd.Rows.Count > 0) Then
                Me.MsgResult.Text = "Ya existe una Declaración Inicial, " + ClDec + " Formulario N°" + tdNd.Rows(0)("Dec_Cod").ToString + " Sino ha Presentado esta declaración al banco debe anularse para poder crear la liquidación Oficial"
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
                querystringSeguro("DOAD") = Me.CboTDOC.SelectedValue
                Me.MsgBox(Me.MsgResult, False)
                Me.Redireccionar_Pagina("/Declaraciones/" + dt.Rows(0)("Fode_Fowe").ToString + "?data=" + HttpUtility.UrlEncode(querystringSeguro.ToString()))
                'Dim Rt As String = dt.Rows(0)("Fode_Fowe").ToString + "?" + "CDec=" + ClDec + "&AGravable=" + Año + "&PGravable=" + Per + "&DecTip=" + tip_dec + "&Nit=" & nit + "&TD=" + tp + "&FODE_CODI=" & dt.Rows(0)("Fode_Codi").ToString                
                'Me.MsgResult.Text = Rt
                'Response.Redirect(Rt)
            End If
        ElseIf (tp = "C") Then
            If (tdNd.Rows.Count = 0) Then
                Me.MsgResult.Text = "No existe Declaración Presentada para corregir en el sistema, debe diligenciar una inicial"
                Me.MsgBox(Me.MsgResult, True)
            Else
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

                Me.MsgBox(Me.MsgResult, False)

                Me.Redireccionar_pagina("/Declaraciones/" + dt.Rows(0)("Fode_Fowe").ToString + "?data=" + HttpUtility.UrlEncode(querystringSeguro.ToString()))
            End If

        End If

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
        Tipo_Declaracion()
    End Sub

    <Services.WebMethod()> Public Shared Function GetCurrentDate() As String
        Return DateTime.Now.ToLongTimeString + "XX"
    End Function

    Protected Sub button_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles button.Click
        Me.Cargar_Signatarios()
    End Sub

    Protected Sub CbCdec_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs)
        Me.Cargar_Signatarios()
    End Sub


    Protected Sub BtnBuscar_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        Me.ModalPopup.Show()


    End Sub

    Protected Sub ToolkitScriptManager1_AsyncPostBackError(ByVal sender As Object, ByVal e As System.Web.UI.AsyncPostBackErrorEventArgs) Handles ToolkitScriptManager1.AsyncPostBackError
        If (Not IsNothing(e.Exception)) And (Not IsNothing(e.Exception.InnerException)) Then
            ToolkitScriptManager1.AsyncPostBackErrorMessage = e.Exception.InnerException.Message
        End If

    End Sub

    Protected Sub CboTDOC_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs)
        Tipo_Declaracion()
    End Sub

    Sub Tipo_Declaracion()
        If Me.CboTDOC.SelectedValue = "LOAF" Then
            Me.ROptTD.SelectedValue = "01"
        Else
            Me.ROptTD.SelectedValue = "02"
        End If
    End Sub
End Class
