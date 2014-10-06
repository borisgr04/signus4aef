Imports System.Data
Imports System.Collections.Generic
Imports System.IO

Partial Class Expediente_Itram_Itram
    Inherits PaginaComun

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            querystringSeguro = Me.GetRequest()
            tbNumExp.Text = querystringSeguro("numExp")
            lcodTramite.Text = querystringSeguro("tram")
            lExpeTramID.Text = querystringSeguro("id")
            hfGenerar.Value = querystringSeguro("genera")
            If Not String.IsNullOrEmpty(tbNumExp.Text) Then
                Dim dtConsulta As DataTable
                Dim oExp As New Expedientes
                dtConsulta = oExp.GetByIde(tbNumExp.Text)
                If dtConsulta.Rows.Count > 0 Then
                    tbImpuesto.Text = dtConsulta.Rows(0)("CLD_NOM").ToString
                    lAgente.Text = dtConsulta.Rows(0)("TER_NOM").ToString
                    lcodImpuesto.Text = dtConsulta.Rows(0)("EXPE_CDEC").ToString
                    hfNit.Value = dtConsulta.Rows(0)("EXPE_NIT").ToString
                End If
                Dim oTram As New TRAMITES
                dtConsulta = oTram.GetPorCod(lcodTramite.Text)
                If dtConsulta.Rows.Count > 0 Then
                    lTramite.Text = dtConsulta.Rows(0)("TRAM_NOMB").ToString
                End If
            End If
        End If
    End Sub
    Private Function ValidarDatos(ByVal tipoDoc As String) As Boolean
        Dim ok As Boolean = True
        If tipoDoc = "RESA" Then
            Dim oApg As New Expe_Apg
            Dim dtPeriodo As New DataTable
            dtPeriodo = oApg.GetPorNumExpe(tbNumExp.Text)

            If dtPeriodo.Rows.Count > 0 Then
                Dim oSancion As New Sancion
                If (oSancion.TieneArchPlano(hfNit.Value, tbNumExp.Text) = False) Then
                    MsgResult.Text = "Cargue el(los) archivo(s) Plano(s) correspondiente al(los) periodo(s) " + oSancion.periodos + " para generar la Sanción"
                    ok = False
                    MsgBoxAlert(MsgResult, True)
                End If
                'For i As Integer = 0 To dtPeriodo.Rows.Count - 1
                '    Dim objcd As New CDeclaraciones
                '    Dim objcal As Calendario = New Calendario
                '    Dim dtc As DataTable = objcal.GetPorAñoyPer(lcodImpuesto.Text, dtPeriodo.Rows(i)("EXAP_AGRA").ToString, dtPeriodo.Rows(i)("EXAP_PGRA").ToString)
                '    Dim cal_ffin As Date = CDate(dtc.Rows(0)("Cal_Ffin").ToString())
                '    Dim OMMD As String = objcd.GetCVMMLA(cal_ffin)
                '    If (OMMD = "S") Then
                '        Dim objBl As BasesLiq = New BasesLiq
                '        If objBl.isExits(hfNit.Value, lcodImpuesto.Text, dtPeriodo.Rows(i)("EXAP_AGRA").ToString, dtPeriodo.Rows(i)("EXAP_PGRA").ToString) = False Then
                '            Me.MsgResult.Text = "No puede Generar el Documento<br>Debe Validar y Cargar Medios Magnéticos Para todos los Periodos Gravables del Expediente. " + dtPeriodo.Rows(i)("EXAP_AGRA").ToString + " - " + dtPeriodo.Rows(i)("EXAP_PGRA").ToString
                '            Me.MsgBox(Me.MsgResult, True)
                '            ok = False
                '            Exit For
                '        End If
                '    End If
                'Next
            Else
                Me.MsgResult.Text = "No se encontraron los Periodos Gravables del Expediente "
                Me.MsgBox(Me.MsgResult, True)
                ok = False
            End If
        End If
        Return ok
    End Function

    Protected Sub btImprimir_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btImprimir.Click
             GenerarDocumento()



    End Sub

    Sub GenerarDocumento()
        Dim dtConsulta As New DataTable
        Dim oExp As New Expe_Tram
        Dim tipoDoc As String = ""
        dtConsulta = oExp.GetPorId(lExpeTramID.Text)
        tipoDoc = dtConsulta.Rows(0)("EXTR_DOAD").ToString
        Try
            'Si el documento no ha sido Creado entonces Crearlo
            If IsDBNull(dtConsulta.Rows(0)("EXTR_DOC")) Then
                If hfGenerar.Value = "N" Then
                    MsgResult.Text = "Usted no es un usuario autorizado para Generar este Documento"
                    MsgBoxError(MsgResult, True)
                Else
                    If ValidarDatos(dtConsulta.Rows(0)("EXTR_DOAD").ToString) Then
                        'Guardar la informacion adicional de la plantilla
                        oExp.UpdateDatos(tbObservacion.Text, lExpeTramID.Text)
                        Dim dtDatos As New DataTable
                        Dim dtPlantilla As New DataTable
                        Dim ListaNomTablas As New List(Of String)
                        Dim ListaTablas As New List(Of DataTable)
                        Dim ListaGrupoNomTabla As New List(Of String)
                        Dim ListaGrupoTabla As New List(Of DataTable)
                        Dim oPlantilla As New Pplantillas
                        'Llenar la tabla de configuracion
                        dtConsulta = oPlantilla.GetCamposPorIde(cmbPlantillas.SelectedValue)
                        'Llenar los datos a Imprimir
                        dtDatos = oPlantilla.GetDatosPlantilla(dtConsulta.Rows(0)("VISTA").ToString, tbNumExp.Text, tipoDoc, lExpeTramID.Text)
                        'Se obtiene la plantila
                        dtPlantilla = oPlantilla.GetPorIde(cmbPlantillas.SelectedValue)
                        'Generar el Documento Word
                        If dtConsulta.Rows.Count > 0 And dtDatos.Rows.Count > 0 Then
                            LlenarTablas(tbNumExp.Text, dtConsulta, ListaNomTablas, ListaTablas, ListaGrupoNomTabla, ListaGrupoTabla)
                            Dim DocPlantilla As Byte()
                            Dim Documento As Byte()
                            Dim DocumentoPDF As Byte()
                            Dim oWord As New GDocWord
                            DocPlantilla = DirectCast(dtPlantilla.Rows(0)("PLANTILLA"), Byte())
                            If Not IsNothing(DocPlantilla) Then
                                If dtPlantilla.Rows(0)("EDITABLE").ToString = "1" Then
                                    oWord.DocProtegido = True
                                    oWord.ClavePlantilla = dtPlantilla.Rows(0)("CLAVE").ToString
                                Else
                                    oWord.DocProtegido = False
                                End If
                                oWord.IdPlantilla = cmbPlantillas.SelectedValue
                                oWord.ListaNomTablas = ListaNomTablas
                                oWord.ListaTablas = ListaTablas
                                Documento = oWord.GenerarDocumento(DocPlantilla, dtConsulta, dtDatos)
                                DocumentoPDF = oWord.Documento_Pdf
                                MsgResult.Text = oWord.Msg
                                MsgResult.Text = MsgResult.Text + oWord.Path_NuevoDocumentoPDF + " Plantilla " + oWord.Path_Plantilla
                                MsgBox1(MsgResult, oWord.lErrorG)
                                If Not oWord.lErrorG Then
                                    If Not IsNothing(Documento) Then
                                        Dim oExpTram As New Expe_Tram
                                        oExpTram.UpdateDocumento(DocPlantilla, Documento, DocumentoPDF, lExpeTramID.Text)
                                    End If
                                    Response.Redirect("~/ashx/DescargarExpediente.ashx?id=" + lExpeTramID.Text + "&formato=" + cmbFormato.SelectedValue)
                                End If
                            Else
                                MsgResult.Text = "La plantilla no esta definida. Por favor verifique"
                                MsgBoxAlert(MsgResult, True)
                            End If
                        Else
                            If dtConsulta.Rows.Count = 0 Then
                                MsgResult.Text = "No existen Datos de configuracion para esta Plantilla"
                                MsgBoxAlert(MsgResult, True)
                            End If
                            If dtDatos.Rows.Count = 0 Then
                                MsgResult.Text = "No se encontraron datos para llenar esta Plantilla"
                                MsgBoxAlert(MsgResult, True)
                            End If
                        End If
                    End If
                End If
            Else
                Response.Redirect("~/ashx/DescargarExpediente.ashx?id=" + lExpeTramID.Text + "&formato=" + cmbFormato.SelectedValue)
            End If
        Catch ex As Exception

            MsgResult.Text = "Error de App: " + ex.Message + ex.StackTrace.ToString
            MsgResult.Visible = True
        End Try
    End Sub

    Private Sub LlenarTablas(ByVal numExpe As String, ByVal dtCamposPlantilla As DataTable, ByRef oListaNomTablas As List(Of String), ByRef oListaTablas As List(Of DataTable), ByRef oListaNomGrupoTablas As List(Of String), ByRef oListaGrupoTablas As List(Of DataTable))
        For i As Integer = 0 To dtCamposPlantilla.Rows.Count - 1
            Select Case dtCamposPlantilla.Rows(i)("NTABLA").ToString()
                Case "VLIQUIDACION_AFORO"
                    Dim oApg As New Expe_Apg
                    Dim dtTabla As New DataTable
                    dtTabla = oApg.GetLiqAforo(numExpe)
                    If dtTabla.Rows.Count > 0 Then
                        oListaTablas.Add(dtTabla)
                        oListaNomTablas.Add("VLIQUIDACION_AFORO")
                        dtTabla = oApg.GetNumLiqAforo(numExpe)
                        oListaGrupoTablas.Add(dtTabla)
                        oListaNomGrupoTablas.Add("VLIQUIDACION_AFORO")
                    End If
                Case "VCUOTA_ACUEPAGO"
                    Dim oApg As New Expe_Apg
                    Dim dtTabla As New DataTable
                    dtTabla = oApg.GetCuotasAcuePago(numExpe)
                    If dtTabla.Rows.Count > 0 Then
                        oListaTablas.Add(dtTabla)
                        oListaNomTablas.Add("VCUOTA_ACUEPAGO")
                    End If
                Case "VRESOLUCION_SANCION"
                    Dim oApg As New Expe_Apg
                    Dim dtTabla As New DataTable
                    dtTabla = oApg.GetResSancion(hfNit.Value, numExpe)
                    If dtTabla.Rows.Count > 0 Then
                        oListaTablas.Add(dtTabla)
                        oListaNomTablas.Add("VRESOLUCION_SANCION")
                    End If
                    

            End Select
        Next
    End Sub

    Protected Sub LinkButton1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles LinkButton1.Click
        querystringSeguro = Me.SetRequest()
        querystringSeguro("numExp") = tbNumExp.Text
        Redireccionar_Pagina("Expediente/Atram/Atram.aspx?data=" + HttpUtility.UrlEncode(querystringSeguro.ToString()))
    End Sub

    Protected Sub btAnular_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btAnular.Click
        Dim oTram As New Expe_Tram
        oTram.UpdateDocumentoNull(lExpeTramID.Text)
        MsgResult.Text = oTram.Msg
        MsgBox1(MsgResult, oTram.lErrorG)
    End Sub

    Protected Sub btRImprimir_Click(sender As Object, e As System.Web.UI.ImageClickEventArgs) Handles btRImprimir.Click
        Dim dtConsulta As New DataTable
        Dim oExp As New Expe_Tram
        Dim tipoDoc As String = ""
        dtConsulta = oExp.GetPorId(lExpeTramID.Text)
        tipoDoc = dtConsulta.Rows(0)("EXTR_DOAD").ToString

            If hfGenerar.Value = "N" Then
                MsgResult.Text = "Usted no es un usuario autorizado para Generar este Documento"
                MsgBoxError(MsgResult, True)
            Else
                If ValidarDatos(dtConsulta.Rows(0)("EXTR_DOAD").ToString) Then
                    'Guardar la informacion adicional de la plantilla
                    oExp.UpdateDatos(tbObservacion.Text, lExpeTramID.Text)
                    Dim dtDatos As New DataTable
                    Dim dtPlantilla As New DataTable
                    Dim ListaNomTablas As New List(Of String)
                    Dim ListaTablas As New List(Of DataTable)
                    Dim ListaGrupoNomTabla As New List(Of String)
                    Dim ListaGrupoTabla As New List(Of DataTable)
                    Dim oPlantilla As New Pplantillas
                    'Llenar la tabla de configuracion
                    dtConsulta = oPlantilla.GetCamposPorIde(cmbPlantillas.SelectedValue)
                    'Llenar los datos a Imprimir
                    dtDatos = oPlantilla.GetDatosPlantilla(dtConsulta.Rows(0)("VISTA").ToString, tbNumExp.Text, tipoDoc, lExpeTramID.Text)
                    'Se obtiene la plantila
                    dtPlantilla = oPlantilla.GetPorIde(cmbPlantillas.SelectedValue)
                    'Generar el Documento Word
                    If dtConsulta.Rows.Count > 0 And dtDatos.Rows.Count > 0 Then
                        LlenarTablas(tbNumExp.Text, dtConsulta, ListaNomTablas, ListaTablas, ListaGrupoNomTabla, ListaGrupoTabla)
                        Dim DocPlantilla As Byte()
                        Dim Documento As Byte()
                        Dim DocumentoPDF As Byte()
                        Dim oWord As New GDocWord
                        DocPlantilla = DirectCast(dtPlantilla.Rows(0)("PLANTILLA"), Byte())
                        If Not IsNothing(DocPlantilla) Then
                            If dtPlantilla.Rows(0)("EDITABLE").ToString = "1" Then
                                oWord.DocProtegido = True
                                oWord.ClavePlantilla = dtPlantilla.Rows(0)("CLAVE").ToString
                            Else
                                oWord.DocProtegido = False
                            End If
                            oWord.IdPlantilla = cmbPlantillas.SelectedValue
                            oWord.ListaNomTablas = ListaNomTablas
                            oWord.ListaTablas = ListaTablas
                            Documento = oWord.GenerarDocumento(DocPlantilla, dtConsulta, dtDatos)
                            DocumentoPDF = oWord.Documento_Pdf
                            MsgResult.Text = oWord.Msg
                            MsgResult.Text = MsgResult.Text + oWord.Path_NuevoDocumentoPDF + " Plantilla " + oWord.Path_Plantilla
                            MsgBox1(MsgResult, oWord.lErrorG)
                            If Not oWord.lErrorG Then
                                If Not IsNothing(Documento) Then
                                    Dim oExpTram As New Expe_Tram
                                    oExpTram.UpdateDocumento(DocPlantilla, Documento, DocumentoPDF, lExpeTramID.Text)
                                End If
                                Response.Redirect("~/ashx/DescargarExpediente.ashx?id=" + lExpeTramID.Text + "&formato=" + cmbFormato.SelectedValue)
                            End If
                        Else
                            MsgResult.Text = "La plantilla no esta definida. Por favor verifique"
                            MsgBoxAlert(MsgResult, True)
                        End If
                    Else
                        If dtConsulta.Rows.Count = 0 Then
                            MsgResult.Text = "No existen Datos de configuracion para esta Plantilla"
                            MsgBoxAlert(MsgResult, True)
                        End If
                        If dtDatos.Rows.Count = 0 Then
                            MsgResult.Text = "No se encontraron datos para llenar esta Plantilla"
                            MsgBoxAlert(MsgResult, True)
                        End If
                    End If
                End If
            End If
        
    End Sub

    'Protected Sub Button1_Click(sender As Object, e As System.EventArgs) Handles Button1.Click
    '    Dim dtConsulta As New DataTable
    '    Dim oExp As New Expe_Tram
    '    Dim tipoDoc As String = ""
    '    dtConsulta = oExp.GetPorId(lExpeTramID.Text)
    '    tipoDoc = dtConsulta.Rows(0)("EXTR_DOAD").ToString

    '    'Si el documento no ha sido Creado entonces Crearlo
    '    If IsDBNull(dtConsulta.Rows(0)("EXTR_DOC")) Then
    '        If hfGenerar.Value = "N" Then
    '            MsgResult.Text = "Usted no es un usuario autorizado para Generar este Documento"
    '            MsgBoxError(MsgResult, True)
    '        Else
    '            If ValidarDatos(dtConsulta.Rows(0)("EXTR_DOAD").ToString) Then
    '                'Guardar la informacion adicional de la plantilla
    '                oExp.UpdateDatos(tbObservacion.Text, lExpeTramID.Text)
    '                Dim dtDatos As New DataTable
    '                Dim dtPlantilla As New DataTable
    '                Dim ListaNomTablas As New List(Of String)
    '                Dim ListaTablas As New List(Of DataTable)
    '                Dim ListaGrupoNomTabla As New List(Of String)
    '                Dim ListaGrupoTabla As New List(Of DataTable)
    '                Dim oPlantilla As New Pplantillas
    '                'Llenar la tabla de configuracion
    '                dtConsulta = oPlantilla.GetCamposPorIde(cmbPlantillas.SelectedValue)
    '                'Llenar los datos a Imprimir
    '                dtDatos = oPlantilla.GetDatosPlantilla(dtConsulta.Rows(0)("VISTA").ToString, tbNumExp.Text, tipoDoc, lExpeTramID.Text)
    '                'Se obtiene la plantila
    '                dtPlantilla = oPlantilla.GetPorIde(cmbPlantillas.SelectedValue)
    '                'Generar el Documento Word
    '                If dtConsulta.Rows.Count > 0 And dtDatos.Rows.Count > 0 Then
    '                    LlenarTablas(tbNumExp.Text, dtConsulta, ListaNomTablas, ListaTablas, ListaGrupoNomTabla, ListaGrupoTabla)
    '                    Dim DocPlantilla As Byte()
    '                    Dim Documento As Byte()
    '                    Dim DocumentoPDF As Byte()
    '                    Dim oWord As New GDocWord
    '                    DocPlantilla = DirectCast(dtPlantilla.Rows(0)("PLANTILLA"), Byte())
    '                    If Not IsNothing(DocPlantilla) Then
    '                        If dtPlantilla.Rows(0)("EDITABLE").ToString = "1" Then
    '                            oWord.DocProtegido = True
    '                            oWord.ClavePlantilla = dtPlantilla.Rows(0)("CLAVE").ToString
    '                        Else
    '                            oWord.DocProtegido = False
    '                        End If
    '                        oWord.IdPlantilla = cmbPlantillas.SelectedValue
    '                        oWord.ListaNomTablas = ListaNomTablas
    '                        oWord.ListaTablas = ListaTablas
    '                        Documento = oWord.GenerarDocumento(DocPlantilla, dtConsulta, dtDatos)
    '                        DocumentoPDF = oWord.Documento_Pdf
    '                        MsgResult.Text = oWord.Msg
    '                        MsgResult.Text = MsgResult.Text + oWord.Path_NuevoDocumentoPDF + " Plantilla " + oWord.Path_Plantilla
    '                        MsgBox1(MsgResult, oWord.lErrorG)
    '                        If Not oWord.lErrorG Then
    '                            If Not IsNothing(Documento) Then
    '                                Dim oExpTram As New Expe_Tram
    '                                oExpTram.UpdateDocumento(DocPlantilla, Documento, DocumentoPDF, lExpeTramID.Text)
    '                            End If
    '                            Response.Redirect("~/ashx/DescargarExpediente.ashx?id=" + lExpeTramID.Text + "&formato=" + cmbFormato.SelectedValue)
    '                        End If
    '                    Else
    '                        MsgResult.Text = "La plantilla no esta definida. Por favor verifique"
    '                        MsgBoxAlert(MsgResult, True)
    '                    End If
    '                Else
    '                    If dtConsulta.Rows.Count = 0 Then
    '                        MsgResult.Text = "No existen Datos de configuracion para esta Plantilla"
    '                        MsgBoxAlert(MsgResult, True)
    '                    End If
    '                    If dtDatos.Rows.Count = 0 Then
    '                        MsgResult.Text = "No se encontraron datos para llenar esta Plantilla"
    '                        MsgBoxAlert(MsgResult, True)
    '                    End If
    '                End If
    '            End If
    '        End If
    '    Else
    '        Response.Redirect("~/ashx/DescargarExpediente.ashx?id=" + lExpeTramID.Text + "&formato=" + cmbFormato.SelectedValue)
    '    End If
    'End Sub

    

End Class
