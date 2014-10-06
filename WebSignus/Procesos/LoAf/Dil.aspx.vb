Imports System.Data
Partial Class Procesos_LoAf_Dil
    Inherits PaginaComun
    Dim objCd As CDeclaraciones
    Protected Sub button_Click(ByVal sender As Object, ByVal e As System.EventArgs)

    End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Me.SetTitulo()
        Me.ToolkitScriptManager1.RegisterAsyncPostBackControl(Me.ConsultaTer1)
        If Not Me.IsPostBack Then
            Me.CbCdec.Attributes.Add("OnFocus", "javascript:UpdateCombo()")
            'Me.ROptTD.SelectedValue = "01"
            Dim dt As DataTable = Me.UsuTercero.GetByUser()
            '            Me.MsgResult.Text = dt.Rows(0)("Ter_TUS").ToString() + "-" + dt.Rows(0)("TUS_NOM").ToString()
            If (dt.Rows.Count > 0) Then
                If (dt.Rows(0)("Ter_TUS").ToString() = "AR") Then
                    Me.Agente.Text = dt.Rows(0)("Ter_Nom").ToString
                    Me.Nit.Text = dt.Rows(0)("Ter_nit").ToString
                    Me.Dv.Text = Trim(dt.Rows(0)("Ter_dver").ToString)
                    Me.HdFODE.Value = dt.Rows(0)("Ter_tip").ToString
                    Me.BtnBuscDP.Visible = False
                    '     Me.BtnAnular.Visible = False
                Else
                    Me.BtnBuscDP.Visible = True
                    '      Me.BtnAnular.Visible = True
                End If
            End If
        End If
    End Sub

    Protected Sub BtnDil_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnDil.Click
        Dim obj As Tipo_Dec = New Tipo_Dec
        'Dim ObdCd As CDeclaraciones = New CDeclaraciones(Me.Cla_Dec.Value)
        Dim ClDec As String = Me.CbCdec.SelectedValue
        objCd = New CDeclaraciones(ClDec)
        Dim Año As String = Me.CboVigencia.SelectedValue
        Dim Per As String = Me.Periodo.SelectedValue
        Dim dt As DataTable
        Dim tp As String
        ' Validar Signatarios

        tp = "LOAF"

        Dim nit As String = Me.Nit.Text
        Dim tdNd As DataTable = objCd.GetActByAPG(nit, Me.CboVigencia.SelectedValue, Me.Periodo.SelectedValue)

        dt = Me.objCd.GetFormularios_Dec(Año, Per).Tables(0)

        If (tdNd.Rows.Count > 0) Then
            Me.MsgResult.Text = "Ya existe una  " + tdNd.Rows(0)("Dec_DOAD").ToString + " Formulario N°" + tdNd.Rows(0)("Dec_Cod").ToString

            Me.MsgBox(Me.MsgResult, True)
        Else
            Me.MsgResult.Text = "Abrir "
            'Me.MsgResult.Text = "Clase Dec " + ClDec + " Año Gravable " + Año + " Periodo Gravable " + Per + "Tipo " + Me.ROptTD.SelectedValue
            querystringSeguro = Me.SetRequest()
            querystringSeguro("CDec") = ClDec
            querystringSeguro("AGravable") = Año
            querystringSeguro("PGravable") = Per
            'querystringSeguro("DecTip") = tip_dec
            querystringSeguro("Nit") = nit
            'querystringSeguro("TD") = tp
            querystringSeguro("FODE_CODI") = dt.Rows(0)("Fode_Codi").ToString
            Dim Ruta As String = "/Procesos/LoAf/Declaracionv01.aspx?data=" + HttpUtility.UrlEncode(querystringSeguro.ToString())
            'Me.MsgResult.Text = Ruta
            'Me.MsgBox(Me.MsgResult, False)
            Response.Redirect(Ruta)
            'Dim Rt As String = dt.Rows(0)("Fode_Fowe").ToString + "?" + "CDec=" + ClDec + "&AGravable=" + Año + "&PGravable=" + Per + "&DecTip=" + tip_dec + "&Nit=" & nit + "&TD=" + tp + "&FODE_CODI=" & dt.Rows(0)("Fode_Codi").ToString                
            'Me.MsgResult.Text = Rt
            'Response.Redirect(Rt)
        End If

    End Sub

    Protected Sub BtnBuscar_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        Me.ModalPopupTer.Show()
    End Sub
End Class
