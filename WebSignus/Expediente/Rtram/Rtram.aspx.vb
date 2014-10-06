Imports System.Data

Partial Class Expediente_Rtram_Rtram
    Inherits PaginaComun
    Dim EXTR_IDTRAM As String
    Dim EXRSAN_CDEC As String


    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            querystringSeguro = Me.GetRequest()
            tbNumExp.Text = querystringSeguro("numExp")
            lcodTramite.Text = querystringSeguro("tram")
            tbConsecutivo.Text = "1"
            If Not String.IsNullOrEmpty(tbNumExp.Text) Then
                Dim dtConsulta As DataTable
                Dim oExp As New Expedientes
                dtConsulta = oExp.GetByIde(tbNumExp.Text)
                If dtConsulta.Rows.Count > 0 Then
                    tbFechaExp.Text = String.Format("{0:dd/MM/yyyy}", dtConsulta.Rows(0)("EXPE_FELA"))
                    tbImpuesto.Text = dtConsulta.Rows(0)("CLD_NOM").ToString
                    lAgente.Text = dtConsulta.Rows(0)("TER_NOM").ToString
                    lTramite.Text = dtConsulta.Rows(0)("TRAM_NOMB").ToString
                    lcodTramite.Text = dtConsulta.Rows(0)("EXPE_TRAC").ToString
                    Me.tbNit.Text = dtConsulta.Rows(0)("expe_nit").ToString
                    EXTR_IDTRAM = dtConsulta.Rows(0)("expe_extrid").ToString
                    lcodImpuesto.Text = dtConsulta.Rows(0)("EXPE_CDEC").ToString
                    EXRSAN_CDEC = dtConsulta.Rows(0)("EXPE_CDEC").ToString
                End If
            End If
        End If
    End Sub

    Protected Sub btReasignar_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btReasignar.Click
        Guardar()
    End Sub

    Protected Sub LinkButton1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles LinkButton1.Click
        querystringSeguro = Me.SetRequest()
        querystringSeguro("numExp") = tbNumExp.Text
        Redireccionar_Pagina("Expediente/Atram/Atram.aspx?data=" + HttpUtility.UrlEncode(querystringSeguro.ToString()))
    End Sub
   
    Protected Sub cmbTramiteSgte_SelectedIndexChanged(sender As Object, e As System.EventArgs) Handles cmbTramiteSgte.SelectedIndexChanged
        ' Me.tbConsecutivo.Text = Me.cmbTramiteSgte.SelectedValue
        If Me.cmbTramiteSgte.SelectedValue = "010105" Then
            Me.MultiView1.ActiveViewIndex = 0
            DataList1.DataSource = ObjRsancion
            DataList1.DataBind()
        Else
            Me.MultiView1.ActiveViewIndex = -1
            DataList1.DataSource = Nothing
            DataList1.DataBind()
        End If
    End Sub

    'Public Sub GetDatosSancion0()
    '    Dim lst As List(Of Ent_Rsancion) = New List(Of Ent_Rsancion)
    '    'Dim obSan As Ent_Rsancion = New Ent_Rsancion()
    '    Dim San As Sancion = New Sancion
    '    Dim j As Integer = 0
    '    Dim Cant As Integer = DataList1.Items.Count
    '    For i As Integer = 0 To Cant - 1
    '        Dim obSan As Ent_Rsancion = New Ent_Rsancion()
    '        obSan.EXRSAN_NEXPE = Me.tbNumExp.Text
    '        obSan.EXRSAN_NIT = Me.tbNit.Text
    '        obSan.EXRSAN_CDEC=EXRSAN_CDEC
    '        obSan.EXRSAN_AGRAV = DirectCast(DataList1.Items(i).FindControl("LbAgrav"), Label).Text
    '        obSan.EXRSAN_PGRAV = DirectCast(DataList1.Items(i).FindControl("lbPerGrav"), Label).Text
    '        Dim l As Label = DirectCast(DataList1.Items(i).FindControl("lbValDec"), Label)
    '        Dim t As TextBox = DirectCast(DataList1.Items(i).FindControl("txValIngr"), TextBox)

    '        obSan.EXRSAN_VULTDEC = Convert.ToDouble(l.Text.Replace("$", "")) 'Convert.ToDouble(DirectCast(DataList1.Items(i).FindControl("lbValDec"), Label).Text)
    '        obSan.EXRSAN_VINGPER = Convert.ToDouble(t.Text.Replace("$", "")) 'Convert.ToDouble(DirectCast(DataList1.Items(i).FindControl("txValIngr"), Label).Text)
    '        obSan.EXRSAN_VBASE = IIf(obSan.EXRSAN_VULTDEC > obSan.EXRSAN_VINGPER, obSan.EXRSAN_VULTDEC, obSan.EXRSAN_VINGPER)
    '        obSan.EXRSAN_IDTRAM = cmbTramiteSgte.SelectedValue
    '        obSan.EXRSAN_ID = EXTR_IDTRAM
    '        lst.Add(obSan)
    '    Next
    '    ' San.Insert_Rsancion(lst)


    'End Sub

    Public Function GetDatosSancion() As List(Of Ent_Rsancion)
        Dim lst As List(Of Ent_Rsancion) = New List(Of Ent_Rsancion)
        Dim Cant As Integer = DataList1.Items.Count
        For i As Integer = 0 To Cant - 1
            Dim obSan As Ent_Rsancion = New Ent_Rsancion()
            obSan.EXRSAN_NEXPE = Me.tbNumExp.Text
            obSan.EXRSAN_NIT = Me.tbNit.Text
            obSan.EXRSAN_CDEC = lcodImpuesto.Text
            obSan.EXRSAN_AGRAV = DirectCast(DataList1.Items(i).FindControl("LbAgrav"), Label).Text
            obSan.EXRSAN_PGRAV = DirectCast(DataList1.Items(i).FindControl("lbPerGrav"), Label).Text
            Dim l As Label = DirectCast(DataList1.Items(i).FindControl("lbValDec"), Label)
            Dim t As TextBox = DirectCast(DataList1.Items(i).FindControl("txValIngr"), TextBox)

            obSan.EXRSAN_VULTDEC = Convert.ToDouble(l.Text.Replace("$", "")) 'Convert.ToDouble(DirectCast(DataList1.Items(i).FindControl("lbValDec"), Label).Text)
            obSan.EXRSAN_VINGPER = Convert.ToDouble(t.Text.Replace("$", "")) 'Convert.ToDouble(DirectCast(DataList1.Items(i).FindControl("txValIngr"), Label).Text)
            obSan.EXRSAN_VBASE = IIf(obSan.EXRSAN_VULTDEC > obSan.EXRSAN_VINGPER, obSan.EXRSAN_VULTDEC, obSan.EXRSAN_VINGPER)
            obSan.EXRSAN_IDTRAM = cmbTramiteSgte.SelectedValue
            obSan.EXRSAN_ID = EXTR_IDTRAM
            If obSan.EXRSAN_VBASE = 0 Then
                lst.Clear()
                Exit For
            Else
                lst.Add(obSan)
            End If
        Next
        Return lst
    End Function

    Private Sub Guardar()

        Dim oEtram As New Expe_Tram

        'Para Resolucion Sanción
        If cmbTramiteSgte.SelectedValue = "010105" Then

            oEtram.lst = GetDatosSancion()
            oEtram.oTram_Sancion = GetDatosTramiteSancion()
            If oEtram.lst.Count = 0 Then
                MsgResult.Text = "Existen periodos con valor de la sanción en Cero, por favor diligencia el monto correspondiente."
                MsgBox1(MsgResult, True)
                Exit Sub
            End If

        End If


        'Para  Remision a grupo de Liquidacion
        If cmbTramiteSgte.SelectedValue = "010103" Then
            Dim Rta As Boolean = oEtram.TieneNotifRemLiq(tbNumExp.Text)
            If Rta = False Then
                MsgResult.Text = "Debe Diligenciar los Datos de Notificación del Agente Recaudador Antes de Remitir al Grupo de Liquidación"
                MsgBoxError(MsgResult, True)
                Exit Sub
            End If
        End If
        oEtram.Insert(tbNumExp.Text, lcodTramite.Text, cmbTramiteSgte.SelectedValue, tbConsecutivo.Text, "")
        If oEtram.lErrorG Then
            MsgResult.Text = oEtram.Msg
            MsgBoxError(MsgResult, True)
        Else
            MsgResult.Text = "Se Generó el Trámite correctamente"
            MsgBox1(MsgResult, False)
            'querystringSeguro = Me.SetRequest()
            'querystringSeguro("numExp") = tbNumExp.Text
            'Redireccionar_Pagina("Expediente/Atram/Atram.aspx?data=" + HttpUtility.UrlEncode(querystringSeguro.ToString()))
        End If
    End Sub

    Private Function GetDatosTramiteSancion() As Ent_TRSan
        Dim obTRSAn As Ent_TRSan = New Ent_TRSan()
        obTRSAn.TRSAN_NEXPE = Me.tbNumExp.Text
        obTRSAn.TRSAN_NIT = Me.tbNit.Text
        obTRSAn.TRSAN_CONSIDERANDOS = Me.TxtConsiderandos.Text
        Return obTRSAn
    End Function


End Class
