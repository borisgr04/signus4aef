Imports System.Data
Imports Signus

Partial Class Consultas_ReciboPago_ConRecibosPago
    Inherits PaginaComun
    Public Overrides Sub VerifyRenderingInServerForm(ByVal control As Control)

    End Sub

    Protected Sub lbVolver_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lbVolver.Click
        querystringSeguro = Me.SetRequest()
        querystringSeguro("nit") = tbNit.Text
        Redireccionar_Pagina("Consultas/PanelAgente/PanelAgente.aspx?data=" + HttpUtility.UrlEncode(querystringSeguro.ToString()))
    End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            Try
                lbTercero.Visible = True
                querystringSeguro = Me.GetRequest()
                tbNit.Text = querystringSeguro("nit")
                If Not String.IsNullOrEmpty(tbNit.Text) Then
                    Dim oTer As New Terceros
                    Dim dtConsulta As New DataTable
                    dtConsulta = oTer.GetByIde(tbNit.Text)
                    tbTercero.Text = dtConsulta.Rows(0)("Ter_Nom").ToString
                    tbNit.Text = dtConsulta.Rows(0)("Ter_nit").ToString
                    If (dtConsulta.Rows(0)("Ter_TUS").ToString() = "AR") Then
                        lbTercero.Visible = False
                    End If
                End If
            Catch ex As Exception
                Dim dt As DataTable = Me.UsuTercero.GetByUser()
                If (dt.Rows.Count > 0) Then
                    dt = Me.UsuTercero.GetByUser()
                    If (dt.Rows(0)("Ter_TUS").ToString() = "AR") Then
                        tbTercero.Text = dt.Rows(0)("Ter_Nom").ToString
                        tbNit.Text = dt.Rows(0)("Ter_nit").ToString
                        lbTercero.Visible = False
                    End If
                End If
            End Try
            Consultar()
        End If
    End Sub

    Protected Sub btConsultar_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btConsultar.Click
        Consultar()
    End Sub

    Protected Sub btExportar_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btExportar.Click
        Me.ExportGridView(gvConsulta, "RecibosPago")
    End Sub

    Protected Sub lbTercero_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lbTercero.Click
        Me.ModalPopupConTercero.Show()
    End Sub

    Protected Sub CtrlConTercero2_SelClicked(ByVal sender As Object, ByVal e As System.EventArgs) Handles CtrlConTercero2.SelClicked
        tbNit.Text = CtrlConTercero2.Nit
        tbTercero.Text = CtrlConTercero2.Nombre
        Me.ModalPopupConTercero.Hide()
    End Sub
    Private Sub Consultar()
        Dim oRecibo As New ReciboOf
        Dim dtConsulta As New DataTable
        Dim oEstado As String = ""
        Dim oNumRec As String = ""
        Dim oFecIni As String = ""
        Dim oFecFin As String = ""
        Dim oDocSop As String = ""
        Dim oTipSop As String = ""

        If cbEstado.Checked Then
            oEstado = cmbEstado.SelectedValue
        End If
        If cbNoRecibo.Checked Then
            oNumRec = tbNumRecibo.Text
        End If
        If cbRangoFecha.Checked Then
            oFecFin = tbFechaFin.Text
            oFecIni = tbFechaIni.Text
        End If
        If cbSoporte.Checked Then
            oDocSop = tbNumeroDoc.Text
            oTipSop = cmbSoporte.SelectedValue
        End If

        dtConsulta = oRecibo.GetParametrizado(tbNit.Text, oNumRec, oEstado, oDocSop, oFecIni, oFecFin, oTipSop)
        gvConsulta.DataSource = dtConsulta
        gvConsulta.DataBind()
    End Sub

End Class
