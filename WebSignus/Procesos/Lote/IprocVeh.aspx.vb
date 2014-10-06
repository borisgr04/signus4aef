Imports System.Data

Partial Class Procesos_Lote_IprocVeh
    Inherits PaginaComun

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        cmbImpuesto.SelectedValue = "50"

    End Sub

    Protected Sub btBuscaTer_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btBuscaTer.Click
        CtrlConTercero2.Tipo = ""
        ModalPopupConTercero.Show()
    End Sub

    Protected Sub CtrlConTercero2_SelClicked(ByVal sender As Object, ByVal e As System.EventArgs) Handles CtrlConTercero2.SelClicked
        tbNit.Text = CtrlConTercero2.Nit
        tbDv.Text = CtrlConTercero2.Dv
        tbNomTercero.Text = CtrlConTercero2.Nombre
        ModalPopupConTercero.Hide()
    End Sub

    Protected Sub btBuscar_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btBuscar.Click
        Dim oProc As New Procesos
        Dim dtConsulta As New DataTable
        dtConsulta = oProc.GetProcesoPorCodigo(cmbProceso.SelectedValue)
        If dtConsulta.Rows.Count > 0 Then
            ltramite.Text = dtConsulta.Rows(0)("PROC_TINI").ToString
        Else
            ltramite.Text = "-1"
        End If

        Select Case cmbProceso.SelectedValue
            Case "0101"
                gvConsulta.DataSource = BuscarOmisos()
                gvConsulta.DataBind()
                chTodos.Visible = True
                lTitulo.Text = "LISTADO DE OMISOS"
            Case "0201"
        End Select

    End Sub
    Private Function BuscarOmisos() As DataTable
        Dim x As String = ""
        Dim dt As DataTable = New DataTable
        Dim o As Expedientes = New Expedientes()
        Dim lcMunOp, lcMunMat, lcNit As String
        lcMunOp = ""
        lcMunMat = ""
        lcNit = ""
        If chMunicipoOp.Checked Then
            lcMunOp = cmbMunOper.SelectedValue
        End If
        If chMunicipioMat.Checked Then
            lcMunMat = cmbMunMat.SelectedValue
        End If
        If chTercero.Checked Then
            lcNit = tbNit.Text
        End If
        dt = o.GetListaOmisosSinExpeVehiculo(cmbVigencia.SelectedValue, cmbVigencia1.SelectedValue, cmbImpuesto.SelectedValue, lcNit, lcMunOp, lcMunMat)
        If dt.Rows.Count = 0 Then
            lmensaje.Text = "No Se Encontraron Resultados"
            chTodos.Visible = False
        Else
            lmensaje.Text = ""
            chTodos.Visible = True
        End If
        If o.lErrorG = True Then
            Me.MsgResult.Text = o.Msg
            lmensaje.Text = o.Msg
        End If

        Return dt
    End Function

    Protected Sub chTodos_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles chTodos.CheckedChanged
        Chequear(chTodos.Checked)
    End Sub

    Private Sub Chequear(ByVal checkState As Boolean)
        ' Iterate through the Products.Rows property 
        For Each row As GridViewRow In gvConsulta.Rows  ' Access the CheckBox 
            Dim cb As CheckBox = row.FindControl("CheckBox1")
            If cb IsNot Nothing Then
                cb.Checked = checkState
            End If
        Next
    End Sub

    Protected Sub BtIniciar_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles BtIniciar.Click
        Select Case cmbProceso.SelectedValue
            Case "0101"
                If gvConsulta.Rows.Count > 0 Then
                    TramiteOmisos()
                End If
            Case "0201"
        End Select
    End Sub
    Private Sub TramiteOmisos()
        Dim lcNit, pIni1, pFin1, nProceso As String
        Dim lcMunOp, lcMunMat As String
        Dim dtOmisos As New DataTable
        Dim ListOmisos As New ArrayList
        Dim oExp As New Expedientes
        Dim oApg As New Expe_Apg
        Dim oCons As New Consecutivos
        Dim numDoc As String

        If String.IsNullOrEmpty(tbConsecutivo.Text) Then
            tbConsecutivo.Text = "0"
        End If

        numDoc = tbConsecutivo.Text
        nProceso = ""
        pIni1 = oApg.ConsPeriodo("00", cmbImpuesto.SelectedValue, cmbVigencia.SelectedValue)
        pFin1 = oApg.ConsPeriodo("00", cmbImpuesto.SelectedValue, cmbVigencia1.SelectedValue)
        lcMunOp = ""
        lcMunMat = ""
        lcNit = ""
        If chMunicipoOp.Checked Then
            lcMunOp = cmbMunOper.SelectedValue
        End If
        If chMunicipioMat.Checked Then
            lcMunMat = cmbMunMat.SelectedValue
        End If
        If chTercero.Checked Then
            lcNit = tbNit.Text
        End If

        If chTodos.Checked Then

            dtOmisos = oExp.GetListaOmisosSinExpeVehiculo(cmbVigencia.SelectedValue, cmbVigencia1.SelectedValue, cmbImpuesto.SelectedValue, lcNit, lcMunOp, lcMunMat)

            oExp.GenerarExpedienteOmiso(cmbProceso.SelectedValue, cmbImpuesto.SelectedValue, _
                    cmbVigencia.SelectedValue, cmbVigencia1.SelectedValue, pIni1, pFin1, "", numDoc, dtOmisos)
        Else
            Dim index As Integer = -1

            For Each row As GridViewRow In gvConsulta.Rows
                index = CInt(gvConsulta.DataKeys(row.RowIndex).Value)
                Dim result As Boolean = DirectCast(row.FindControl("CheckBox1"), CheckBox).Checked
                If result Then
                    If Not ListOmisos.Contains(index) Then
                        ListOmisos.Add(index)
                    End If
                End If
            Next

            If ListOmisos IsNot Nothing AndAlso ListOmisos.Count > 0 Then
                oExp.GenerarExpedienteOmiso(cmbProceso.SelectedValue, cmbImpuesto.SelectedValue, _
                cmbVigencia.SelectedValue, cmbVigencia1.SelectedValue, pIni1, pFin1, "", numDoc, ListOmisos)
            Else
                MsgResult.Text = "No se encontraron los Terceros a los que se les va Iniciar el Proceso ?"
                MsgBoxAlert(MsgResult, True)
            End If

        End If
        nProceso = oExp.Doc
        If oExp.lErrorG Then
            MsgResult.Text = "Error Generando: " + oExp.Msg
            MsgBoxError(MsgResult, True)
            lNumProceso.Visible = False
            lNumProceso.Text = nProceso
        Else
            MsgResult.Text = "Se Genero la Informacion "
            MsgBoxInfo(MsgResult, True)
            lNumProceso.Visible = True
            lNumProceso.Text = nProceso
        End If
    End Sub

    Protected Sub btDescargar_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btDescargar.Click
        If Not String.IsNullOrEmpty(lNumProceso.Text) Then
            querystringSeguro = Me.SetRequest()
            querystringSeguro("numProc") = lNumProceso.Text
            querystringSeguro("tram") = ltramite.Text
            Redireccionar_Pagina("Procesos/Lote/Itram.aspx?data=" + HttpUtility.UrlEncode(querystringSeguro.ToString()))
        Else
            Redireccionar_Pagina("Procesos/Lote/Itram.aspx")
        End If
    End Sub

    Protected Sub btSgteTram_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btSgteTram.Click
        If Not String.IsNullOrEmpty(lNumProceso.Text) Then
            querystringSeguro = Me.SetRequest()
            querystringSeguro("numProc") = lNumProceso.Text
            querystringSeguro("tram") = ltramite.Text
            Redireccionar_Pagina("Procesos/Lote/Rtram.aspx?data=" + HttpUtility.UrlEncode(querystringSeguro.ToString()))
        Else
            Redireccionar_Pagina("Procesos/Lote/Rtram.aspx")
        End If

    End Sub

    Protected Sub btExpedientes_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btExpedientes.Click
        Response.Redirect("~/Expediente/Atram/Atram.aspx")
    End Sub
End Class
