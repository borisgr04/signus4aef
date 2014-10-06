
Imports System.Data
Imports System.Collections.Generic

Partial Class Procesos_Lote_Lote
    Inherits PaginaComun

    Protected Sub BtnBuscar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnBuscDP.Click
        Me.ModalPopupTer.Show()
    End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    End Sub

    Protected Sub chTodos_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles chTodos.CheckedChanged
        Chequear(chTodos.Checked)
    End Sub

    Protected Sub gvConsulta_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles gvConsulta.SelectedIndexChanged
        dlDetalle.Visible = True
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
                Me.dlDetalle.DataBind()
                chTodos.Visible = True
                dlDetalle.Visible = False
                lTitulo.Text = "LISTADO DE OMISOS Y PERIODOS ADEUDADOS"
            Case "0201"
        End Select
    End Sub

    Private Sub TramiteOmisos()
        Dim lNit, lmpio, pIni1, pFin1, nProceso As String
        Dim dtOmisos As New DataTable
        Dim ListOmisos As New ArrayList
        Dim oExp As New Expedientes
        Dim oApg As New Expe_Apg
        Dim oCons As New Consecutivos
        Dim numDoc As String
        Dim tip As String = ""

        If String.IsNullOrEmpty(tbConsecutivo.Text) Then
            tbConsecutivo.Text = "0"
        End If

        numDoc = tbConsecutivo.Text

        lNit = ""
        lmpio = ""
        nProceso = ""

        If chTercero.Checked Then
            lNit = Nit.Text
        End If

        If chMunicipo.Checked Then
            lmpio = cmbMunicipio.SelectedValue
        End If

        If CBTPAR.Checked Then
            tip = CbTTcer.SelectedValue
        End If

        'If chTodos.Checked Then
        '    dtOmisos = oExp.GetListaOmisosSinExpediente(cmbPeriodo.SelectedValue, cmbPeriodo1.SelectedValue, cmbVigencia.SelectedValue, cmbVigencia1.SelectedValue, _
        '                                   cmbImpuesto.SelectedValue, lNit, lmpio, tip)
        '    'me devuelve el periodo en formato de Fecha
        '    pIni1 = oApg.ConsPeriodo(cmbPeriodo.SelectedValue, cmbImpuesto.SelectedValue, cmbVigencia.SelectedValue)
        '    pFin1 = oApg.ConsPeriodo(cmbPeriodo1.SelectedValue, cmbImpuesto.SelectedValue, cmbVigencia1.SelectedValue)
        '    oExp.GenerarExpedienteOmiso(cmbProceso.SelectedValue, cmbImpuesto.SelectedValue, _
        '            cmbVigencia.SelectedValue, cmbVigencia1.SelectedValue, pIni1, pFin1, "", numDoc, dtOmisos)
        'Else
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
            pIni1 = cmbPeriodo.SelectedValue ' oApg.ConsPeriodo(cmbPeriodo.SelectedValue, cmbImpuesto.SelectedValue, cmbVigencia.SelectedValue)
            pFin1 = cmbPeriodo1.SelectedValue ' oApg.ConsPeriodo(cmbPeriodo1.SelectedValue, cmbImpuesto.SelectedValue, cmbVigencia1.SelectedValue)
            oExp.GenerarExpedienteOmiso(cmbProceso.SelectedValue, cmbImpuesto.SelectedValue, _
            cmbVigencia.SelectedValue, cmbVigencia1.SelectedValue, pIni1, pFin1, "", numDoc, ListOmisos)
        Else
            MsgResult.Text = "No es posible generar el proceso, no ha seleccionado ningún tercero"
            MsgBoxAlert(MsgResult, True)
            Exit Sub
        End If

        'End If
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

    Private Function BuscarOmisos() As DataTable
        Dim x As String = ""
        Dim dt As DataTable = New DataTable
        Dim o As Expedientes = New Expedientes()
        Dim lcMun, lcNit, lcTip As String
        lcMun = ""
        lcNit = ""
        lcTip = ""
        If chMunicipo.Checked Then
            lcMun = cmbMunicipio.SelectedValue
        End If
        If chTercero.Checked Then
            lcNit = Nit.Text
        End If

        If Me.CBTPAR.Checked Then
            lcTip = CbTTcer.SelectedValue
        End If
        dt = o.GetListaOmisosSinExpediente(cmbPeriodo.Text, cmbPeriodo1.Text, cmbVigencia.SelectedValue, cmbVigencia1.SelectedValue, cmbImpuesto.SelectedValue, lcNit, lcMun, lcTip)
        If o.lErrorG = True Then
            Me.MsgResult.Text = o.Msg
            lmensaje.Text = o.Msg
        Else
            If dt.Rows.Count = 0 Then
                lmensaje.Text = "No Se Encontraron Resultados"
                chTodos.Visible = False
            Else
                lmensaje.Text = ""
                chTodos.Visible = True
            End If

        End If
        Return dt
    End Function

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

    Private Sub GuardarRegistrosChequeados()

        Dim categoryIDList As New ArrayList()

        Dim index As Integer = -1

        For Each row As GridViewRow In gvConsulta.Rows

            index = CInt(gvConsulta.DataKeys(row.RowIndex).Value)

            Dim result As Boolean = DirectCast(row.FindControl("CheckBox1"), CheckBox).Checked

            ' Check in the Session

            If Session("CHECKED_ITEMS") IsNot Nothing Then

                categoryIDList = DirectCast(Session("CHECKED_ITEMS"), ArrayList)

            End If

            If result Then

                If Not categoryIDList.Contains(index) Then

                    categoryIDList.Add(index)

                End If

            Else

                categoryIDList.Remove(index)

            End If

        Next

        If categoryIDList IsNot Nothing AndAlso categoryIDList.Count > 0 Then

            Session("CHECKED_ITEMS") = categoryIDList

        End If

    End Sub

    Private Sub RecargarValores()

        Dim categoryIDList As ArrayList = DirectCast(Session("CHECKED_ITEMS"), ArrayList)

        If categoryIDList IsNot Nothing AndAlso categoryIDList.Count > 0 Then

            For Each row As GridViewRow In gvConsulta.Rows

                Dim index As Integer = CInt(gvConsulta.DataKeys(row.RowIndex).Value)

                If categoryIDList.Contains(index) Then

                    Dim myCheckBox As CheckBox = DirectCast(row.FindControl("CheckBox1"), CheckBox)

                    myCheckBox.Checked = True

                End If

            Next

        End If

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

    Protected Sub btExpedientes_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btExpedientes.Click
        Response.Redirect("~/Expediente/Atram/Atram.aspx")
    End Sub
End Class
