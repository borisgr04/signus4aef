Imports System.Data
Imports Signus

Partial Class Consultas_PanelAgente_PanelAgente
    Inherits PaginaComun

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            Try
                querystringSeguro = Me.GetRequest()
                Me.Nit.Text = querystringSeguro("nit")
                If Not String.IsNullOrEmpty(Me.Nit.Text) Then
                    Dim oTer As New Terceros
                    Dim dtConsulta As New DataTable
                    dtConsulta = oTer.GetByIde(Nit.Text)
                    Me.Agente.Text = dtConsulta.Rows(0)("Ter_Nom").ToString
                    Me.Nit.Text = dtConsulta.Rows(0)("Ter_nit").ToString
                    Me.Dv.Text = Trim(dtConsulta.Rows(0)("Ter_dver").ToString)
                    If (dtConsulta.Rows(0)("Ter_TUS").ToString() = "AR") Then
                        BtnBuscDP.Visible = False
                    End If
                End If
            Catch ex As Exception
                Dim dt As DataTable = Me.UsuTercero.GetByUser()
                If (dt.Rows.Count > 0) Then
                    'Me.Nit.Attributes.Add("onBlur", "javascript:MostrarNit()")
                    dt = Me.UsuTercero.GetByUser()
                    If (dt.Rows(0)("Ter_TUS").ToString() = "AR") Then
                        Me.Agente.Text = dt.Rows(0)("Ter_Nom").ToString
                        Me.Nit.Text = dt.Rows(0)("Ter_nit").ToString
                        Me.Dv.Text = Trim(dt.Rows(0)("Ter_dver").ToString)
                        Me.BtnBuscDP.Visible = False
                    Else
                        Me.BtnBuscDP.Visible = True
                    End If
                End If
            End Try
        End If
    End Sub

    Protected Sub BtnBuscDP_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnBuscDP.Click
        ModalPopupConTercero.Show()
    End Sub

    Protected Sub CtrlConTercero2_SelClicked(ByVal sender As Object, ByVal e As System.EventArgs) Handles CtrlConTercero2.SelClicked
        Nit.Text = CtrlConTercero2.Nit
        Dv.Text = CtrlConTercero2.Dv
        Agente.Text = CtrlConTercero2.Nombre
        ModalPopupConTercero.Hide()
    End Sub
    Sub cartera()
        querystringSeguro = Me.SetRequest()
        querystringSeguro("nit") = Nit.Text
        Redireccionar_Pagina("Consultas/CuentaCorriente/ConCartera.aspx?data=" + HttpUtility.UrlEncode(querystringSeguro.ToString()))
    End Sub

    Protected Sub lkCartera_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lkCartera.Click
        cartera()
    End Sub

    Protected Sub btCartera_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btCartera.Click
        cartera()
    End Sub
    Sub expediente()
        querystringSeguro = Me.SetRequest()
        querystringSeguro("nit") = Nit.Text
        Redireccionar_Pagina("Consultas/Expedientes/ConExpediente.aspx?data=" + HttpUtility.UrlEncode(querystringSeguro.ToString()))
    End Sub
    Protected Sub lkexpediente_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lkexpediente.Click
        expediente()
    End Sub

    Protected Sub btExpediente_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btExpediente.Click
        expediente()
    End Sub
    Sub Acuerdo()
        querystringSeguro = Me.SetRequest()
        querystringSeguro("nit") = Nit.Text
        Redireccionar_Pagina("Consultas/AcuPag/Dil.aspx?data=" + HttpUtility.UrlEncode(querystringSeguro.ToString()))
    End Sub
    Protected Sub lkAcuerdo_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lkAcuerdo.Click
        Acuerdo()
    End Sub

    Protected Sub btAcpa_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btAcpa.Click
        Acuerdo()
    End Sub
    Sub Recibo()
        querystringSeguro = Me.SetRequest()
        querystringSeguro("nit") = Nit.Text
        Redireccionar_Pagina("Consultas/ReciboPago/ConRecibosPago.aspx?data=" + HttpUtility.UrlEncode(querystringSeguro.ToString()))
    End Sub
    Protected Sub lkRopa_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lkRopa.Click
        Recibo()
    End Sub

    Protected Sub btRopa_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btRopa.Click
        Recibo()
    End Sub
End Class

