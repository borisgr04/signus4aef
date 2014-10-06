Imports System.Data
Imports Signus

Partial Class Procesos_Exp_NExpe
    Inherits PaginaComun

    Protected Sub BtnBuscar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnBuscDP.Click
        Dim dtconsulta As New DataTable
        gvPeriodos.DataSource = dtConsulta
        gvPeriodos.DataBind()
        tbIniAct.Text = ""
        Me.ModalPopupConTercero.Show()
    End Sub

    Protected Sub btGuardar_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btGuardar.Click
        Dim dtPeriodos As New DataTable
        dtPeriodos.Columns.Add("PERIODO")
        dtPeriodos.Columns.Add("VIGENCIA")

        For Each row As GridViewRow In gvPeriodos.Rows
            Dim result As Boolean = DirectCast(row.FindControl("CheckBox1"), CheckBox).Checked
            If result Then
                Dim fila As DataRow = dtPeriodos.NewRow
                fila(0) = gvPeriodos.DataKeys(row.RowIndex).Item(0)
                fila(1) = gvPeriodos.DataKeys(row.RowIndex).Item(1)
                dtPeriodos.Rows.Add(fila)
            End If
        Next
        If dtPeriodos.Rows.Count > 0 Then
            Dim dtConsulta As New DataTable
            Dim oProc As New Procesos
            Dim vTram As String = ""
            dtConsulta = oProc.GetProcesoPorCodigo(cmbProceso.SelectedValue)
            If dtConsulta.Rows.Count > 0 Then
                vTram = dtConsulta.Rows(0)("PROC_TINI").ToString
                Dim oExp As New Expedientes
                oExp.GenerarExpediente(cmbProceso.SelectedValue, cmbImpuesto.SelectedValue, dtPeriodos, _
                                       tbNumExp.Text, tbConsecutivo.Text, Nit.Text, vTram)
                If Not String.IsNullOrEmpty(oExp.ExpePerido) Then
                    lbtTramite.Text = oExp.ExpePerido
                    lbtTramite.Visible = True
                Else
                    lbtTramite.Visible = False
                End If
                lbTituExpe.Visible = lbtTramite.Visible
                tbNumExp.Text = oExp.Doc
                MsgResult.Text = oExp.Msg
                MsgBox1(MsgResult, oExp.lErrorG)
            Else
                MsgResult.Text = "No se ha definido el tramite inicial para el proceso"
                MsgBoxAlert(MsgResult, True)
            End If
        Else
            MsgResult.Text = "No ha escogido los peridos"
            MsgBoxAlert(MsgResult, True)
        End If
    End Sub

    Protected Sub btActualizar_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btActualizar.Click
        Dim oTer As New Ter_Dec
        Dim dtConsulta As New DataTable
        Dim obj As New Terceros
        dtConsulta = obj.GetByIde(Nit.Text)
        Agente.Text = dtConsulta.Rows(0)("TER_NOM").ToString
        Dv.Text = dtConsulta.Rows(0)("TER_DVER").ToString
        dtConsulta = oTer.GetPorTerDec(Nit.Text, cmbImpuesto.SelectedValue)
        If dtConsulta.Rows.Count > 0 Then
            tbIniAct.Text = dtConsulta.Rows(0)("TEDE_FINI").ToString.Substring(0, 10)
            Dim oCal As New Calendario
            dtConsulta = oCal.GetPorFechaIni(cmbImpuesto.SelectedValue, cmbVigencia.SelectedValue, cmbVigencia1.SelectedValue, tbIniAct.Text)
            gvPeriodos.DataSource = dtConsulta
            gvPeriodos.DataBind()
            lbtTramite.Visible = False
            lbTituExpe.Visible = False
        Else
            MsgResult.Text = "Configure la Fecha de Inicio de actividades del Tercero"
            MsgBoxAlert(MsgResult, True)
        End If
    End Sub

    Protected Sub btExpedientes_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btExpedientes.Click
        querystringSeguro = Me.SetRequest()
        querystringSeguro("numExp") = tbNumExp.Text
        Redireccionar_Pagina("Expediente/Atram/Atram.aspx?data=" + HttpUtility.UrlEncode(querystringSeguro.ToString()))
    End Sub

    Protected Sub lbtTramite_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lbtTramite.Click
        querystringSeguro = Me.SetRequest()
        querystringSeguro("numExp") = lbtTramite.Text
        Redireccionar_Pagina("Expediente/Atram/Atram.aspx?data=" + HttpUtility.UrlEncode(querystringSeguro.ToString()))
    End Sub

    Protected Sub CtrlConTercero2_SelClicked(ByVal sender As Object, ByVal e As System.EventArgs) Handles CtrlConTercero2.SelClicked
        Nit.Text = CtrlConTercero2.Nit
        Dv.Text = CtrlConTercero2.Dv
        Agente.Text = CtrlConTercero2.Nombre
        Me.ModalPopupConTercero.Hide()
    End Sub

    Protected Sub cmbImpuesto_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbImpuesto.SelectedIndexChanged
        Dim dtconsulta As New DataTable
        gvPeriodos.DataSource = dtconsulta
        gvPeriodos.DataBind()
    End Sub

    Protected Sub ToolkitScriptManager1_AsyncPostBackError(ByVal sender As Object, ByVal e As System.Web.UI.AsyncPostBackErrorEventArgs) Handles ToolkitScriptManager1.AsyncPostBackError
        If (Not IsNothing(e.Exception)) And (Not IsNothing(e.Exception.InnerException)) Then
            ToolkitScriptManager1.AsyncPostBackErrorMessage = e.Exception.InnerException.Message + "Ajax"
        End If

    End Sub

    Protected Sub Button1_Click(sender As Object, e As System.EventArgs) Handles Button1.Click

    End Sub
End Class
