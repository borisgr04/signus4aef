Imports System.Data
Imports Signus

Partial Class Consultas_Expedientes_ConsExpediente
    Inherits PaginaComun
    Public Overrides Sub VerifyRenderingInServerForm(ByVal control As Control)

    End Sub

    Protected Sub CtrlConTercero2_SelClicked(ByVal sender As Object, ByVal e As System.EventArgs) Handles CtrlConTercero2.SelClicked
        Nit.Text = CtrlConTercero2.Nit
        Dv.Text = CtrlConTercero2.Dv
        Agente.Text = CtrlConTercero2.Nombre
        Me.ModalPopupConTercero.Hide()
    End Sub

    Protected Sub BtnBuscar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnBuscar.Click
        Me.ModalPopupConTercero.Show()
    End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            Try
                Me.BtnBuscar.Visible = True
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
                        Me.BtnBuscar.Visible = False
                    End If
                End If
            Catch ex As Exception
                Dim dt As DataTable = Me.UsuTercero.GetByUser()
                If (dt.Rows.Count > 0) Then
                    dt = Me.UsuTercero.GetByUser()
                    If (dt.Rows(0)("Ter_TUS").ToString() = "AR") Then
                        Me.Agente.Text = dt.Rows(0)("Ter_Nom").ToString
                        Me.Nit.Text = dt.Rows(0)("Ter_nit").ToString
                        Me.Dv.Text = Trim(dt.Rows(0)("Ter_dver").ToString)
                        Me.BtnBuscar.Visible = False
                    Else
                        Me.BtnBuscar.Visible = True
                    End If
                End If
            End Try
        End If
    End Sub

    Protected Sub btConsultar_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btConsultar.Click
        gvExpedientes.DataBind()
    End Sub

    Protected Sub btExportar_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btExportar.Click
        Me.ExportGridView(gvExpedientes, "Expedientes.xls")
    End Sub

    Protected Sub lbVolver_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lbVolver.Click
        querystringSeguro = Me.SetRequest()
        querystringSeguro("nit") = Nit.Text
        Redireccionar_Pagina("Consultas/PanelAgente/PanelAgente.aspx?data=" + HttpUtility.UrlEncode(querystringSeguro.ToString()))
    End Sub
End Class
