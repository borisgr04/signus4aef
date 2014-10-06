Imports System.Data
Imports System.Collections.Generic

Partial Class Procesos_Lote_Itram
    Inherits PaginaComun

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            Dim codTram As String
            codTram = ""
            hfGenerar.Value = "N"
            Try
                querystringSeguro = Me.GetRequest()
                tbNumProc.Text = querystringSeguro("numProc")
                codTram = querystringSeguro("tram")
            Catch ex As Exception

            End Try
            If Not String.IsNullOrEmpty(codTram) Then
                cmbTramite.SelectedValue = codTram
            End If
            If Not String.IsNullOrEmpty(tbNumProc.Text) Then
                CargarDatos()
            End If
        End If
    End Sub

    Protected Sub btImprimir_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btImprimir.Click
        Dim oPlantilla As New Pplantillas
        Dim dtDatos As New DataTable
        Dim dtConsulta As New DataTable
        Dim oExp As New Proc_Lote
        Dim lDescargar As Boolean
        lDescargar = True
        dtDatos = oExp.GetPorID(tbNumProc.Text, cmbTramite.SelectedValue)
        If IsDBNull(dtDatos.Rows(0)("PRLT_DOC")) Then
            'Validacion Para el Control de Usuarios
            Dim oTer As New Tram_Ter
            dtConsulta = oTer.GetPorCod(Membership.GetUser().UserName, cmbTramite.SelectedValue)
            If dtConsulta.Rows.Count > 0 Then
                hfGenerar.Value = "S"
            Else
                hfGenerar.Value = "N"
            End If
            'Fin Control de Usuarios
            If hfGenerar.Value = "N" Then
                lDescargar = False
                MsgResult.Text = "Usted no es un usuario autorizado para Generar el Documento"
                MsgBoxError(MsgResult, True)
            Else
                Dim dtPlantilla As New DataTable
                Dim ListaNomTablas As New List(Of String)
                Dim ListaTablas As New List(Of DataTable)
                'Llenar la tabla de configuracion
                dtConsulta = oPlantilla.GetCamposPorIde(cmbPlantillas.SelectedValue)
                'Se obtiene la plantila
                dtPlantilla = oPlantilla.GetPorIde(cmbPlantillas.SelectedValue)
                'Llenar los datos a Imprimir
                dtDatos = oPlantilla.GetDatosPlantillaPorProceso(cmbTramite.SelectedValue, tbNumProc.Text)
                'Generar el Documento Word
                If dtConsulta.Rows.Count > 0 And dtDatos.Rows.Count > 0 Then
                    Dim DocPlantilla As Byte()
                    Dim DocCombinado As Byte()
                    Dim DocPDF As Byte()
                    DocPlantilla = DirectCast(dtPlantilla.Rows(0)("PLANTILLA"), Byte())
                    If Not IsNothing(DocPlantilla) Then
                        Dim oWord As New GDocWord
                        If dtPlantilla.Rows(0)("EDITABLE").ToString = "1" Then
                            oWord.DocProtegido = True
                            oWord.ClavePlantilla = dtPlantilla.Rows(0)("CLAVE").ToString
                        Else
                            oWord.DocProtegido = False
                        End If
                        DocCombinado = oWord.CombinarCorrespondencia(DocPlantilla, dtConsulta, dtDatos)
                        DocPDF = oWord.Documento_Pdf
                        If Not IsNothing(DocCombinado) Then
                            Dim oProc As New Proc_Lote
                            oProc.UpdateDocumento(DocPlantilla, DocCombinado, DocPDF, tbNumProc.Text)
                        Else
                            MsgResult.Text = oWord.Msg
                            MsgBox1(MsgResult, False)
                            lDescargar = False
                        End If
                        oWord.EliminarTemporales()
                    Else
                        MsgResult.Text = "La plantilla no esta definida. Por favor verifique"
                        MsgBoxAlert(MsgResult, True)
                        lDescargar = False
                    End If

                Else
                    MsgResult.Text = "El documento no se puede Descargar porque no hay datos de Configuracion de la Plantilla"
                    MsgBoxAlert(MsgResult, True)
                    lDescargar = False
                End If
            End If
        End If
        If String.IsNullOrEmpty(tbNumProc.Text) Then
            MsgResult.Text = "No ha Generado el Proceso"
            MsgBoxError(MsgResult, True)
        Else
            If lDescargar Then
                Response.Redirect("~/ashx/DescargarProceso.ashx?numProc=" + tbNumProc.Text + "&tram=" + cmbTramite.SelectedValue + "&formato=" + cmbFormato.SelectedValue)
            End If
        End If
    End Sub

    Protected Sub btBuscar_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btBuscar.Click
        CargarDatos()
    End Sub

    Private Sub CargarDatos()

        Dim dtConsulta As DataTable
        Dim oExp As New Proc_Lote
        dtConsulta = oExp.GetPorNumero(tbNumProc.Text)
        If dtConsulta.Rows.Count > 0 Then
            tbImpuesto.Text = dtConsulta.Rows(dtConsulta.Rows.Count - 1)("CLD_NOM").ToString
            lcodImpuesto.Text = dtConsulta.Rows(dtConsulta.Rows.Count - 1)("PRLT_CDEC").ToString
            cmbTramite.DataBind()
            cmbTramite.SelectedValue = dtConsulta.Rows(dtConsulta.Rows.Count - 1)("PRLT_TRAM").ToString
        End If

    End Sub

    Protected Sub btAnular_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btAnular.Click
        Dim oExp As New Proc_Lote
        oExp.UpdateDocumentoNull(tbNumProc.Text)
        MsgResult.Text = oExp.Msg
        MsgBox1(MsgResult, oExp.lErrorG)
    End Sub

    Protected Sub btRegenDoc_Click(sender As Object, e As System.Web.UI.ImageClickEventArgs) Handles btRegenDoc.Click
        Dim oPlantilla As New Pplantillas
        Dim dtDatos As New DataTable
        Dim dtConsulta As New DataTable
        Dim oExp As New Proc_Lote
        Dim lDescargar As Boolean
        lDescargar = True
        dtDatos = oExp.GetPorID(tbNumProc.Text, cmbTramite.SelectedValue)
        'Validacion Para el Control de Usuarios
        Dim oTer As New Tram_Ter
        dtConsulta = oTer.GetPorCod(Membership.GetUser().UserName, cmbTramite.SelectedValue)
        If dtConsulta.Rows.Count > 0 Then
            hfGenerar.Value = "S"
        Else
            hfGenerar.Value = "N"
        End If
        'Fin Control de Usuarios
        If hfGenerar.Value = "N" Then
            lDescargar = False
            MsgResult.Text = "Usted no es un usuario autorizado para Generar el Documento"
            MsgBoxError(MsgResult, True)
        Else
            Dim dtPlantilla As New DataTable
            Dim ListaNomTablas As New List(Of String)
            Dim ListaTablas As New List(Of DataTable)
            'Llenar la tabla de configuracion
            dtConsulta = oPlantilla.GetCamposPorIde(cmbPlantillas.SelectedValue)
            'Se obtiene la plantila
            dtPlantilla = oPlantilla.GetPorIde(cmbPlantillas.SelectedValue)
            'Llenar los datos a Imprimir
            dtDatos = oPlantilla.GetDatosPlantillaPorProceso(cmbTramite.SelectedValue, tbNumProc.Text)
            'Generar el Documento Word
            If dtConsulta.Rows.Count > 0 And dtDatos.Rows.Count > 0 Then
                Dim DocPlantilla As Byte()
                Dim DocCombinado As Byte()
                Dim DocPDF As Byte()
                DocPlantilla = DirectCast(dtPlantilla.Rows(0)("PLANTILLA"), Byte())
                If Not IsNothing(DocPlantilla) Then
                    Dim oWord As New GDocWord
                    If dtPlantilla.Rows(0)("EDITABLE").ToString = "1" Then
                        oWord.DocProtegido = True
                        oWord.ClavePlantilla = dtPlantilla.Rows(0)("CLAVE").ToString
                    Else
                        oWord.DocProtegido = False
                    End If
                    DocCombinado = oWord.CombinarCorrespondencia(DocPlantilla, dtConsulta, dtDatos)
                    DocPDF = oWord.Documento_Pdf
                    If Not IsNothing(DocCombinado) Then
                        Dim oProc As New Proc_Lote
                        oProc.UpdateDocumento(DocPlantilla, DocCombinado, DocPDF, tbNumProc.Text)
                    Else
                        MsgResult.Text = oWord.Msg
                        MsgBox1(MsgResult, False)
                        lDescargar = False
                    End If
                    oWord.EliminarTemporales()
                Else
                    MsgResult.Text = "La plantilla no esta definida. Por favor verifique"
                    MsgBoxAlert(MsgResult, True)
                    lDescargar = False
                End If

            Else
                MsgResult.Text = "El documento no se puede Descargar porque no hay datos de Configuracion de la Plantilla"
                MsgBoxAlert(MsgResult, True)
                lDescargar = False
            End If
        End If

        If String.IsNullOrEmpty(tbNumProc.Text) Then
            MsgResult.Text = "No ha Generado el Proceso"
            MsgBoxError(MsgResult, True)
        Else
            If lDescargar Then
                Response.Redirect("~/ashx/DescargarProceso.ashx?numProc=" + tbNumProc.Text + "&tram=" + cmbTramite.SelectedValue + "&formato=" + cmbFormato.SelectedValue)
            End If
        End If

    End Sub

  
End Class
