Imports System.Data

Partial Class Procesos_Lote_Rtram
    Inherits PaginaComun

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            Try
                querystringSeguro = Me.GetRequest()
                tbNumProc.Text = querystringSeguro("numProc")
                lcodTramite.Text = querystringSeguro("tram")
            Catch ex As Exception

            End Try
            If Not String.IsNullOrEmpty(tbNumProc.Text) Then
                CargarDatos()
            End If
        End If
    End Sub

    Protected Sub btReasignar_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btReasignar.Click
        Dim oLote As New Proc_Lote
        oLote.InsertSiguienteTramite(tbNumProc.Text, lcodTramite.Text, cmbTramiteSgte.SelectedValue, tbConsecutivo.Text)
        MsgResult.Text = oLote.Msg
        MsgBox1(MsgResult, oLote.lErrorG)
        lcodTramite.Text = cmbTramiteSgte.SelectedValue
        CargarDatos()
    End Sub

    Protected Sub btBuscar_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btBuscar.Click
        CargarDatos()
    End Sub

    Private Sub CargarDatos()

        Dim dtConsulta As DataTable
        Dim oExp As New Proc_Lote

        If String.IsNullOrEmpty(lcodTramite.Text) Then
            dtConsulta = oExp.GetPorNumero(tbNumProc.Text)
        Else
            dtConsulta = oExp.GetPorID(tbNumProc.Text, lcodTramite.Text)
        End If
        If dtConsulta.Rows.Count > 0 Then
            tbFechaExp.Text = String.Format("{0:dd/MM/yyyy}", dtConsulta.Rows(0)("PRLT_FREG"))
            tbImpuesto.Text = dtConsulta.Rows(0)("CLD_NOM").ToString
            lTramite.Text = dtConsulta.Rows(0)("TRAM_NOMB").ToString
            lcodTramite.Text = dtConsulta.Rows(0)("PRLT_TRAM").ToString
            'Validacion Para el Control de Usuarios
            Dim oTer As New Tram_Ter
            dtConsulta = oTer.GetPorCod(Membership.GetUser().UserName, lcodTramite.Text)
            If dtConsulta.Rows.Count > 0 Then
                pCtrlUsuario1.Enabled = True
            Else
                pCtrlUsuario1.Enabled = False
                MsgResult.Text = "Usted No posee los permisos suficientes para realizar acciones en esta seccion"
                MsgBoxInfo(MsgResult, True)
            End If
            'Fin Control de Usuarios
        End If

    End Sub

    Protected Sub btDescargar_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btDescargar.Click
        If Not String.IsNullOrEmpty(tbNumProc.Text) Then
            querystringSeguro = Me.SetRequest()
            querystringSeguro("numProc") = tbNumProc.Text
            querystringSeguro("tram") = lcodTramite.Text
        End If
        Redireccionar_Pagina("Procesos/Lote/Itram.aspx?data=" + HttpUtility.UrlEncode(querystringSeguro.ToString()))
    End Sub
End Class
