Imports System.Data

Partial Class Consultas_Expedientes_conNotificacion
    Inherits PaginaComun
    Public Overrides Sub VerifyRenderingInServerForm(ByVal control As Control)

    End Sub
    Protected Sub lbTramite_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lbTramite.Click
        ModalPopupConTramite.Show()
    End Sub

    Protected Sub lbTercero_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lbTercero.Click
        ModalPopupConTercero.Show()
    End Sub

    Protected Sub tbExpeIni_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles tbExpeIni.TextChanged
        If tbExpeIni.Text.Length < 12 Then
            Dim oVig As New Vigencias
            Dim vigencia As String
            vigencia = oVig.GetActiva()
            tbExpeIni.Text = vigencia + tbExpeIni.Text.PadLeft(8, "0")
        End If
        tbExpeFin.Text = tbExpeIni.Text
    End Sub

    Protected Sub btBuscar_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btBuscar.Click
        Dim vnit, vTramite, vfinalizado, vexpeIni, vExpeFin As String
        Dim oExpe As New Expe_Notif
        Dim dtConsulta As New DataTable
        vTramite = ""
        If cbDocumento.Checked Then
            vTramite = hfTramite.Value
        End If
        vnit = ""
        If cbTercero.Checked Then
            vnit = hfTercero.Value
        End If
        vfinalizado = ""
        If cbEntregado.Checked Then
            vfinalizado = cmbfinalizado.SelectedValue
        End If
        vexpeIni = ""
        vExpeFin = ""
        If cbExpediente.Checked Then
            vexpeIni = tbExpeIni.Text
            vExpeFin = tbExpeFin.Text
        End If
        dtConsulta = oExpe.GetParametrizada(vTramite, vexpeIni, vExpeFin, vnit, vfinalizado)
        gvConsulta.DataSource = dtConsulta
        gvConsulta.DataBind()
    End Sub

    Protected Sub CtrlConsTramite2_SelClicked(ByVal sender As Object, ByVal e As System.EventArgs) Handles CtrlConsTramite2.SelClicked
        hfTramite.Value = CtrlConsTramite2.CodTramite
        tbTramite.Text = CtrlConsTramite2.NomTramite
        ModalPopupConTramite.Hide()
    End Sub

    Protected Sub CtrlConTercero2_SelClicked(ByVal sender As Object, ByVal e As System.EventArgs) Handles CtrlConTercero2.SelClicked
        hfTercero.Value = CtrlConTercero2.Nit
        tbTercero.Text = CtrlConTercero2.Nombre
        ModalPopupConTercero.Hide()
    End Sub

    Protected Sub btExcel_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btExcel.Click
        Me.ExportGridView(gvConsulta, "Notificaciones.xls")
    End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    End Sub
End Class
