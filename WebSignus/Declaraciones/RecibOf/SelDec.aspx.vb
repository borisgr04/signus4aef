Imports System.data
Partial Class Declaraciones_Diligenciar_SelDec
    Inherits PaginaComun
    Dim objcd As ReciboOf
    'Dim Objsig As Signatario = New Signatario
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        Me.LBTITULO.Text = "Diligenciar Recibo Oficial de Pago "
        Me.SetTitulo()
        Me.ToolkitScriptManager1.RegisterAsyncPostBackControl(Me.ConsultaTer1)

        If Not Me.IsPostBack Then
            Me.CbCdec.Attributes.Add("OnFocus", "javascript:UpdateCombo()")
            'Me.ROptTD.SelectedValue = "01"
            Dim dt As DataTable = Me.UsuTercero.GetByUser()
            'Me.MsgResult.Text = dt.Rows(0)("Ter_TUS").ToString() + "-" + dt.Rows(0)("TUS_NOM").ToString()
            If (dt.Rows.Count > 0) Then
                If (dt.Rows(0)("Ter_TUS").ToString() = "AR") Then
                    Me.Agente.Text = dt.Rows(0)("Ter_Nom").ToString
                    Me.Nit.Text = dt.Rows(0)("Ter_nit").ToString
                    Me.Dv.Text = Trim(dt.Rows(0)("Ter_dver").ToString)
                    Me.BtnBuscDP.Visible = False
                Else
                    Me.BtnBuscDP.Visible = True
                End If
            End If
        End If
    End Sub

    Protected Sub BtnBuscDP_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        Me.ModalPopup.Show()
    End Sub

    Protected Sub BtnDil_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnDil.Click
        Dim obj As Tipo_Dec = New Tipo_Dec
        Dim ClDec As String = Me.CbCdec.SelectedValue
        objcd = New ReciboOf(ClDec)
        Dim Año As String = Me.CboVigencia.SelectedValue
        Dim Per As String = Me.Periodo.SelectedValue
        Dim dt As DataTable
        Dim tp As String = ""
        Dim nit As String = Me.Nit.Text
        Dim Tip_DocAdmon As String = ""
        Dim CodDec As String = ""
        Dim FecPre As Date
        Dim Car_est As String = ""
        Dim Car_Sal As Decimal = 0
        Dim objrof As ReciboOf = New ReciboOf

        Dim tdNd As DataTable = objcd.GetDecByPer(nit, Me.CboVigencia.SelectedValue, Me.Periodo.SelectedValue, ClDec)
        dt = Me.objcd.GetFormularios_Dec(Año, Per).Tables(0)

        Dim tb As DataTable = objrof.GetDatos_Dec(Per, Año, nit, ClDec)
        If tb.Rows.Count > 0 Then
            Tip_DocAdmon = tb.Rows(0)("car_tdoc").ToString()
            CodDec = tb.Rows(0)("car_dcod").ToString()
            FecPre = tb.Rows(0)("car_fnov").ToString()
            Car_est = tb.Rows(0)("car_est").ToString()
            Car_Sal = CDbl(tb.Rows(0)("car_Sal").ToString())

            Me.MsgResult1.Text = "fecha" + FecPre.ToString
            Me.ModalPopupTer3.Show()

            If Car_Sal <> 0 Then
                If Car_est = "AC" Then
                    Me.MsgResult.Text = "Abrir "
                    Me.MsgResult.Text = "Clase Dec " + ClDec + " Año Gravable " + Año + " Periodo Gravable " + Per '+ "Tipo " + Me.ROptTD.SelectedValue
                    querystringSeguro = Me.SetRequest()
                    querystringSeguro("CDec") = ClDec
                    querystringSeguro("AGravable") = Año
                    querystringSeguro("PGravable") = Per
                    querystringSeguro("DocAdm") = Tip_DocAdmon
                    querystringSeguro("CodDec") = CodDec
                    querystringSeguro("Nit") = nit
                    querystringSeguro("FecPre") = FecPre
                    querystringSeguro("CDec") = ClDec
                    querystringSeguro("FODE_CODI") = dt.Rows(0)("Fode_Codi").ToString

                    'Me.MsgBox(Me.MsgResult, False)
                    Redireccionar_Pagina("/Declaraciones/RecibOf/Recibooficial2.aspx?data=" + HttpUtility.UrlEncode(querystringSeguro.ToString()))
                    'Dim Rt As String = "/Declaraciones/RecibOf/Recibooficial2.aspx?" + "CDec=" + ClDec + "&AGravable=" + Año + "&PGravable=" + Per + "&Nit=" & nit + "&FODE_CODI=" & dt.Rows(0)("Fode_Codi").ToString + "&DocAdm=" + Tip_DocAdmon + "&CodDec=" + CodDec + "&FecPre=" + FecPre
                    'Me.MsgResult.Text = Rt
                    'Response.Redirect(Rt)
                Else
                    Me.MsgResult1.Text = "Ya tiene un Acuerdo de Pago para el Periodo  Gravable" + Per + "y el Ano Gravable" + Año
                    Me.ModalPopupTer3.Show()
                End If
            Else
                Me.MsgResult1.Text = "No Tiene Saldos en Cartera para el Periodo: " + Per + " y el Ano Gravable: " + Año + ". Verifique si ya se Radico una Declaracion para este Periodo gravable"
                Me.ModalPopupTer3.Show()
            End If
        Else
            Me.MsgResult1.Text = "No Existe Cartera en este Perido"
            Me.ModalPopupTer3.Show()
        End If

    End Sub


    Protected Sub ToolkitScriptManager1_AsyncPostBackError(ByVal sender As Object, ByVal e As System.Web.UI.AsyncPostBackErrorEventArgs) Handles ToolkitScriptManager1.AsyncPostBackError
        If (Not IsNothing(e.Exception)) And (Not IsNothing(e.Exception.InnerException)) Then
            ToolkitScriptManager1.AsyncPostBackErrorMessage = e.Exception.InnerException.Message
        End If

    End Sub
End Class
