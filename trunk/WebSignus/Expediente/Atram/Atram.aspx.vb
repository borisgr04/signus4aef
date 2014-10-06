Imports System.Data
Imports System.Collections.Generic

Partial Class Expediente_Atram_Atram
    Inherits PaginaComun

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            Try
                Dim num As String
                querystringSeguro = Me.GetRequest()
                num = querystringSeguro("numExp")
                If Not String.IsNullOrEmpty(num) Then
                    tbNumExp.Text = num
                    CargarDatos()
                End If
            Catch ex As Exception

            End Try
        End If
    End Sub

    Protected Sub btBuscarExp_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btBuscarExp.Click
        Me.ModalPopup.Show()
    End Sub

    Protected Sub tbNumExp_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles tbNumExp.TextChanged
        Me.MsgResult.Text = ""
        Me.MsgResult.Visible = False
        If tbNumExp.Text.Length < 12 Then
            Dim oVig As New Vigencias
            Dim vigencia As String
            vigencia = oVig.GetActiva()
            tbNumExp.Text = vigencia + tbNumExp.Text.PadLeft(8, "0")
        End If
        CargarDatos()
    End Sub

    Private Sub CargarDatos()
        If Not String.IsNullOrEmpty(tbNumExp.Text) Then
            Dim dtConsulta As DataTable
            Dim oExp As New Expedientes

            dtConsulta = oExp.GetByIde(tbNumExp.Text)
            If dtConsulta.Rows.Count > 0 Then
                tbFechaExp.Text = String.Format("{0:dd/MM/yyyy}", dtConsulta.Rows(0)("EXPE_FELA"))
                tbImpuesto.Text = dtConsulta.Rows(0)("CLD_NOM").ToString
                lProceso.Text = dtConsulta.Rows(0)("PROC_NOMB").ToString
                lNumProc.Text = dtConsulta.Rows(0)("EXPE_NPRO").ToString
                lRepLegal.Text = dtConsulta.Rows(0)("TER_REP").ToString
                lNit.Text = dtConsulta.Rows(0)("EXPE_NIT").ToString
                lAgente.Text = dtConsulta.Rows(0)("TER_NOM").ToString
                lDV.Text = dtConsulta.Rows(0)("TER_DVER").ToString
                lMunicipio.Text = dtConsulta.Rows(0)("MUN_NOM").ToString
                lTramite.Text = dtConsulta.Rows(0)("TRAM_NOMB").ToString
                lcodImpuesto.Text = dtConsulta.Rows(0)("EXPE_CDEC").ToString
                lcodTramite.Text = dtConsulta.Rows(0)("EXPE_TRAC").ToString
                tbFechaExpira.Text = String.Format("{0:dd/MM/yyyy}", dtConsulta.Rows(0)("EXPE_FEXP"))
                lIdExpeTram.Text = dtConsulta.Rows(0)("EXPE_EXTRID").ToString
                tbConsecutivo.Text = dtConsulta.Rows(0)("EXPE_DONU").ToString
                If lcodImpuesto.Text = "50" Then
                    gvPeriodos.Columns(0).Visible = True
                Else
                    gvPeriodos.Columns(0).Visible = False
                End If
                'Validacion de Fecha de Recibido de documentos para pasar a siguiente tramite
                Dim oTram As New TRAMITES
                dtConsulta = oTram.GetPorCod(lcodTramite.Text)
                If dtConsulta.Rows.Count > 0 Then
                    If dtConsulta.Rows(0)("TRAM_VFREB").ToString = "S" Then
                        If String.IsNullOrEmpty(tbFechaExpira.Text) Then
                            btSgteTram.Enabled = False
                        Else
                            If CDate(tbFechaExpira.Text) <= Date.Now.Date Then
                                btSgteTram.Enabled = True
                            Else
                                btSgteTram.Enabled = False
                            End If
                        End If
                    Else
                        btSgteTram.Enabled = True
                    End If
                End If
                'Fin
                'Validacion Para el Control de Usuarios
                Dim oTer As New Tram_Ter
                dtConsulta = oTer.GetPorCod(Membership.GetUser().UserName, lcodTramite.Text)
                If dtConsulta.Rows.Count > 0 Then
                    pCtrlUsuario1.Enabled = True
                    pCtrlUsuario2.Enabled = True
                Else
                    pCtrlUsuario1.Enabled = False
                    pCtrlUsuario2.Enabled = False
                    MsgResult.Text = "Usted No posee los permisos suficientes para realizar acciones en esta seccion"
                    MsgBoxInfo(MsgResult, True)
                End If
                'Fin Control de Usuarios

            End If
        End If
    End Sub

    Protected Sub gvTramites_RowCommand(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewCommandEventArgs) Handles gvTramites.RowCommand
        Select Case e.CommandName
            Case "Eliminar"
                Dim index As Integer = Convert.ToInt32(e.CommandArgument)
                gvTramites.SelectedIndex = index
                CtrlAnulaExpeTram2.IdTabla = gvTramites.DataKeys(gvTramites.SelectedIndex).Value
                CtrlAnulaExpeTram2.NumExpediente = tbNumExp.Text
                CtrlAnulaExpeTram2.Tabla = "EXPE_TRAM"
                Me.ModalPopupAnular.Show()

        End Select
    End Sub

    Protected Sub gvTramites_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles gvTramites.RowDataBound
        Dim habilitado As Boolean = pCtrlUsuario1.Enabled
        Try
            If e.Row.RowType = DataControlRowType.DataRow Then
                Dim boton As ImageButton = e.Row.FindControl("btEliminar")
                If boton IsNot Nothing Then
                    boton.Enabled = habilitado
                End If
            End If
        Catch ex As Exception

        End Try
    End Sub

    Protected Sub gvTramites_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles gvTramites.SelectedIndexChanged
        If Not String.IsNullOrEmpty(tbNumExp.Text) Then
            Dim dtConsulta As New DataTable
            Dim oExpTram As New Expe_Tram
            dtConsulta = oExpTram.GetPorId(gvTramites.SelectedValue.ToString)
            querystringSeguro = Me.SetRequest()
            querystringSeguro("numExp") = tbNumExp.Text
            querystringSeguro("tram") = dtConsulta.Rows(0)("EXTR_TACT").ToString
            querystringSeguro("id") = gvTramites.SelectedValue.ToString
            querystringSeguro("genera") = IIf(pCtrlUsuario2.Enabled, "S", "N")
            Redireccionar_Pagina("Expediente/Itram/Itram.aspx?data=" + HttpUtility.UrlEncode(querystringSeguro.ToString()))
        End If
    End Sub

    Protected Sub btSgteTram_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btSgteTram.Click
        If Not String.IsNullOrEmpty(tbNumExp.Text) Then
            querystringSeguro = Me.SetRequest()
            querystringSeguro("numExp") = tbNumExp.Text
            querystringSeguro("tram") = lcodTramite.Text
            Redireccionar_Pagina("Expediente/Rtram/Rtram.aspx?data=" + HttpUtility.UrlEncode(querystringSeguro.ToString()))
        End If
    End Sub

    Protected Sub btRadicado_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btRadicado.Click
        If Not String.IsNullOrEmpty(tbNumExp.Text) Then
            querystringSeguro = Me.SetRequest()
            querystringSeguro("numExp") = tbNumExp.Text
            querystringSeguro("tram") = lcodTramite.Text
            Redireccionar_Pagina("Expediente/Ntram/Ntram.aspx?data=" + HttpUtility.UrlEncode(querystringSeguro.ToString()))
        End If
    End Sub

    Protected Sub btGenDoc_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btGenDoc.Click
        If Not String.IsNullOrEmpty(tbNumExp.Text) Then
            querystringSeguro = Me.SetRequest()
            querystringSeguro("numExp") = tbNumExp.Text
            querystringSeguro("tram") = lcodTramite.Text
            querystringSeguro("id") = lIdExpeTram.Text
            Redireccionar_Pagina("Expediente/Itram/Itram.aspx?data=" + HttpUtility.UrlEncode(querystringSeguro.ToString()))
        End If
    End Sub

    Protected Sub btCerrarAnular_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btCerrarAnular.Click
        CargarDatos()
        odsExpTram.DataBind()
        gvTramites.DataBind()
        ModalPopupAnular.Hide()
    End Sub


    Protected Sub gvPeriodos_RowCommand(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewCommandEventArgs) Handles gvPeriodos.RowCommand
        Select Case e.CommandName
            Case "Eliminar"
                Dim index As Integer = Convert.ToInt32(e.CommandArgument)
                gvPeriodos.SelectedIndex = index
                CtrlAnulaApg1.Vigencia = gvPeriodos.DataKeys(gvPeriodos.SelectedIndex).Item(0)
                CtrlAnulaApg1.Periodo = gvPeriodos.DataKeys(gvPeriodos.SelectedIndex).Item(1)
                CtrlAnulaApg1.NumExpediente = tbNumExp.Text
                CtrlAnulaApg1.Tabla = "EXPE_APG"
                Me.ModalPopupAnulaApg.Show()
        End Select
    End Sub

    Protected Sub gvPeriodos_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles gvPeriodos.RowDataBound
        Dim habilitado As Boolean = pCtrlUsuario1.Enabled
        Try
            If e.Row.RowType = DataControlRowType.DataRow Then
                Dim boton As ImageButton = e.Row.FindControl("btEliminar")
                If boton IsNot Nothing Then
                    boton.Enabled = habilitado
                End If
            End If
        Catch ex As Exception

        End Try
    End Sub

    Protected Sub gvPeriodos_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles gvPeriodos.SelectedIndexChanged
        Dim otram As New TRAMITES
        Dim dt As New DataTable
        dt = otram.GetPorTipoDoc("LOAF")
        If lcodTramite.Text = dt.Rows(0)("TRAM_CODI").ToString Then
            Dim objcd As CDeclaraciones
            Dim obj As Tipo_Dec = New Tipo_Dec
            Dim ClDec As String = lcodImpuesto.Text
            objcd = New CDeclaraciones(ClDec)
            Dim Vig As String = gvPeriodos.SelectedDataKey.Item(0)
            Dim Per As String = gvPeriodos.SelectedDataKey.Item(1)
            Dim tp As String
            Dim objcal As Calendario = New Calendario
            Dim dtc As DataTable = objcal.GetPorAñoyPer(ClDec, Vig, Per)
            Dim cal_ffin As Date = CDate(dtc.Rows(0)("Cal_Ffin").ToString())
            Dim OMMD As String = objcd.GetCVMMLA(cal_ffin)
            Dim tip_dec As String = "01"
            'REVISAR SANCIONES E INTERESES
            If (OMMD = "S") Then
                Dim objBl As BasesLiq = New BasesLiq
                If objBl.isExits(lNit.Text, ClDec, Vig, Per) = False Then
                    Me.MsgResult.Text = "No puede Diligenciar la Liquidacion de Aforo<br>Debe Validar y Cargar Medios Magnéticos Para Este Periodo Gravable "
                    Me.MsgBox(Me.MsgResult, True)
                    Exit Sub
                End If
            End If

            tp = obj.GetCodiTD(ClDec, tip_dec)

            Dim tdNd As DataTable = objcd.GetDecByPer(lNit.Text, Vig, Per)

            dt = objcd.GetFormularios_Dec(Vig, Per).Tables(0)

            If (tp = "I") Then
                If (tdNd.Rows.Count > 0) Then
                    Me.MsgResult.Text = "Ya existe una Liquidación, " + ClDec + " Formulario N°" + tdNd.Rows(0)("Dec_Cod").ToString + " Puede anularla y crear una nueva Liquidación"
                    Me.MsgBox(Me.MsgResult, True)
                Else
                    Me.MsgResult.Text = "Abrir "
                    Me.MsgResult.Text = "Clase Dec " + ClDec + " Año Gravable " + Vig + " Periodo Gravable " + Per + "Tipo " + tip_dec
                    querystringSeguro = Me.SetRequest()
                    querystringSeguro("CDec") = ClDec
                    querystringSeguro("AGravable") = Vig
                    querystringSeguro("PGravable") = Per
                    querystringSeguro("DecTip") = tip_dec
                    querystringSeguro("Nit") = lNit.Text
                    querystringSeguro("TD") = tp
                    querystringSeguro("FODE_CODI") = dt.Rows(0)("Fode_Codi").ToString
                    querystringSeguro("DOAD") = "LOAF"
                    querystringSeguro("EXPE_NUME") = tbNumExp.Text
                    Me.MsgBox(Me.MsgResult, False)
                    Redireccionar_Pagina("Declaraciones/Af_" + dt.Rows(0)("Fode_Fowe").ToString + "?data=" + HttpUtility.UrlEncode(querystringSeguro.ToString()))
                End If
            End If
        Else
            Me.MsgResult.Text = "La Liquidación de Aforo se realiza cuando el tramite actual es " + dt.Rows(0)("TRAM_NOMB").ToString
            Me.MsgBoxError(Me.MsgResult, True)
        End If
    End Sub


    Protected Sub btCerrarAnulaApg_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btCerrarAnulaApg.Click
        CargarDatos()
        odsPeriodos.DataBind()
        gvPeriodos.DataBind()
        ModalPopupAnulaApg.Hide()
    End Sub

    Protected Sub btAcuerdo_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btAcuerdo.Click
        querystringSeguro = Me.SetRequest()
        querystringSeguro("numExp") = tbNumExp.Text
        querystringSeguro("Nit") = lNit.Text
        querystringSeguro("CDec") = lcodImpuesto.Text
        Redireccionar_Pagina("Procesos/AcPa/Dil.aspx?data=" + HttpUtility.UrlEncode(querystringSeguro.ToString()))
    End Sub
End Class
