Imports System.Data

Partial Class Expediente_Ntram_Ntram
    Inherits PaginaComun

    Protected Sub Btnsave_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles BtnSave.Click
        Dim oNot As New Expe_Notif
        Dim valido As Boolean
        Dim empresa As String = ""
        Dim Periodico As String = ""
        valido = True
        Select Case cmbNotificacion.SelectedValue
            Case "01"
                If String.IsNullOrEmpty(tbNFolios.Text) Then
                    MsgResult.Text = "Debe digitar el número de folios a enviar en el ofico remisorio"
                    valido = False
                End If
                If String.IsNullOrEmpty(cmbEmpresa.SelectedValue) Then
                    MsgResult.Text = "Debe escoger una empresa de mensajeria"
                    valido = False
                End If
                If String.IsNullOrEmpty(tbNumguia.Text) Then
                    MsgResult.Text = "Debe escribir el Numero de Guia"
                    valido = False
                End If
                If String.IsNullOrEmpty(tbFecEnvio.Text) Then
                    MsgResult.Text = "Debe escribir la fecha de Envio"
                    valido = False
                End If
                If cmbFinalizado.Text = "S" Then
                    If String.IsNullOrEmpty(tbFechaRecibido.Text) Then
                        MsgResult.Text = "Debe escribir la fecha de Recibido"
                        valido = False
                    End If
                End If
                empresa = cmbEmpresa.SelectedValue
            Case "02"
                If cmbFinalizado.Text = "S" Then
                    If String.IsNullOrEmpty(tbFechaRecibido.Text) Then
                        MsgResult.Text = "Debe escribir la fecha de Publicacion"
                        valido = False
                    End If
                End If
                If String.IsNullOrEmpty(tbPeriodico.Text) Then
                    MsgResult.Text = "Debe escribir el nombre del Periodico"
                    valido = False
                End If
                If String.IsNullOrEmpty(tbFecEnvio.Text) Then
                    tbFecEnvio.Text = tbFechaRecibido.Text
                End If
                Periodico = tbPeriodico.Text
        End Select
        Dim dtConsulta As New DataTable
        dtConsulta = oNot.GetFinalizada(tbNumExp.Text, HFTramiteActual.Value)
        If dtConsulta.Rows.Count > 0 Then
            valido = False
            MsgResult.Text = "El tramite se le ha finalizado la entrega de Notificaciones"
        End If
        If valido Then
            oNot.Insert(tbFechaRecibido.Text, cmbNotificacion.SelectedValue, Periodico, _
                                       tbFecEnvio.Text, cmbFinalizado.SelectedValue, tbObservacion.Text, empresa, tbNumExp.Text, HFTramiteActual.Value, tbNumguia.Text, tbNFolios.Text, CmbRtaNotif.SelectedValue)
            MsgResult.Text = oNot.Msg
            MsgBox1(MsgResult, oNot.lErrorG)
            odsEntregas.DataBind()
            GridView1.DataBind()
        Else
            Me.MsgBoxError(MsgResult, True)
        End If


    End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            MultiView1.ActiveViewIndex = 0
            Label1.Text = "Fecha de Recibido"
            tbFecEnvio.Text = System.DateTime.Now.Date.ToString("dd/MM/yyyy")
            tbFechaRecibido.Text = System.DateTime.Now.Date.ToString("dd/MM/yyyy")
            tbPeriodico.Text = ""
            querystringSeguro = Me.GetRequest()
            tbNumExp.Text = querystringSeguro("numExp")
            HFTramiteActual.Value = querystringSeguro("tram")
            If Not String.IsNullOrEmpty(tbNumExp.Text) Then
                Dim dtConsulta As DataTable
                Dim oExp As New Expedientes
                dtConsulta = oExp.GetByIde(tbNumExp.Text)
                If dtConsulta.Rows.Count > 0 Then
                    tbImpuesto.Text = dtConsulta.Rows(0)("CLD_NOM").ToString
                    lAgente.Text = dtConsulta.Rows(0)("TER_NOM").ToString
                    lTramite.Text = dtConsulta.Rows(0)("TRAM_NOMB").ToString
                End If
            End If
        End If

    End Sub

    Private Sub CargarVista()
        Select Case cmbNotificacion.SelectedValue
            Case "01"
                MultiView1.ActiveViewIndex = 0
                Label1.Text = "Fecha de Recibido"
                tbFecEnvio.Text = System.DateTime.Now.Date.ToString("dd/MM/yyyy")
                tbFechaRecibido.Text = System.DateTime.Now.Date.ToString("dd/MM/yyyy")
                tbPeriodico.Text = ""
            Case "02"
                MultiView1.ActiveViewIndex = 1
                Label1.Text = "Fecha de Publicacion"
                tbNumguia.Text = ""

            Case Else
                MultiView1.ActiveViewIndex = -1
        End Select
    End Sub

    Protected Sub cmbNotificacion_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbNotificacion.SelectedIndexChanged
        CargarVista()
    End Sub

    Protected Sub LinkButton1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles LinkButton1.Click
        querystringSeguro = Me.SetRequest()
        querystringSeguro("numExp") = tbNumExp.Text
        Redireccionar_Pagina("Expediente/Atram/Atram.aspx?data=" + HttpUtility.UrlEncode(querystringSeguro.ToString()))
    End Sub

    Protected Sub GridView1_RowCommand(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewCommandEventArgs) Handles GridView1.RowCommand
        Select Case e.CommandName
            Case "Eliminar"
                Dim dtConsulta As New DataTable
                Dim index As Integer = Convert.ToInt32(e.CommandArgument)
                GridView1.SelectedIndex = index
                Dim oNot As New Expe_Notif
                dtConsulta = oNot.GetPorId(GridView1.SelectedValue)
                If dtConsulta.Rows.Count > 0 Then
                    If dtConsulta.Rows(0)("EXTR_TRAC").ToString = HFTramiteActual.Value Then
                        CtrlAnulaExpeTram2.IdTabla = GridView1.SelectedValue
                        CtrlAnulaExpeTram2.NumExpediente = tbNumExp.Text
                        CtrlAnulaExpeTram2.Tabla = "EXPE_NOTIF"
                        Me.ModalPopupAnular.Show()
                    Else
                        CtrlAnulaExpeTram2.IdTabla = ""
                        CtrlAnulaExpeTram2.NumExpediente = ""
                        CtrlAnulaExpeTram2.Tabla = ""
                        MsgResult.Text = "Solo puede Eliminar Notificaciones del tramite actual"
                        MsgBoxError(MsgResult, True)
                    End If
                End If

        End Select
    End Sub

    Protected Sub btCerrarAnular_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btCerrarAnular.Click
        GridView1.DataBind()
        Me.ModalPopupAnular.Hide()
    End Sub

    Protected Sub GridView1_SelectedIndexChanged(sender As Object, e As System.EventArgs) Handles GridView1.SelectedIndexChanged

    End Sub

    Protected Sub BtnCancel_Click(sender As Object, e As System.Web.UI.ImageClickEventArgs) Handles BtnCancel.Click
        querystringSeguro = Me.SetRequest()
        querystringSeguro("numExp") = tbNumExp.Text
        Redireccionar_Pagina("Expediente/Atram/Atram.aspx?data=" + HttpUtility.UrlEncode(querystringSeguro.ToString()))
    End Sub
End Class
