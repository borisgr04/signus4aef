Imports System.Data
Imports Microsoft.Reporting.WebForms

Partial Class Consultas_Formularios_ConFDec
    Inherits PaginaComun

    Public Dec_cod As String
    Public Dec_cdec As String
    Public Dec_Tdoc As String


    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load


        Me.MsgResult.Text = ""

        '        Me.LBTITULO.Text = "Diligenciar Declararaciones "
        Me.SetTitulo()

        Me.ToolkitScriptManager1.RegisterAsyncPostBackControl(Me.ConsultaTer1)

        If Not Me.IsPostBack Then
            Me.BtnAnular.Enabled = True
            Me.CbCdec.Attributes.Add("OnFocus", "javascript:UpdateCombo()")
            Dim dt As DataTable = Me.UsuTercero.GetByUser()
            If (dt.Rows.Count > 0) Then
                Me.HdUser.Value = dt.Rows(0)("TER_NIT").ToString
                'Me.Nit.Text = dt.Rows(0)("TER_NIT").ToString

                Me.Nit.Attributes.Add("onBlur", "javascript:MostrarNit()")
                If (dt.Rows(0)("Ter_TUS").ToString() = "AR") Then
                    Me.Nit.Text = dt.Rows(0)("TER_NIT").ToString
                    Me.HdTipoUser.Value = dt.Rows(0)("Ter_TUS").ToString()
                    Me.Agente.Text = dt.Rows(0)("Ter_Nom").ToString
                    Me.Nit.Text = dt.Rows(0)("Ter_nit").ToString
                    Me.Dv.Text = Trim(dt.Rows(0)("Ter_dver").ToString)
                    Me.BtnBuscDP.Visible = False
                Else
                    Me.BtnBuscDP.Visible = True
                End If
            End If
        End If

        Me.BtnAnular.Visible = False
    End Sub

    Protected Sub Button1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnActualizar.Click
        '    Dim obj As New CDeclaraciones()
        '   Dim dt As DataTable = obj.GetDeclaraciones(TxtNit.Text, Me.CboVigencia.SelectedValue, Me.Periodo.SelectedValue)


    End Sub

    Protected Sub BtnAnular_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnAnular.Click

        Dim obj As New CDeclaraciones()
        Me.MsgResult.Text = obj.Anular(grDec.SelectedValue)
        Me.MsgBox(Me.MsgResult, obj.lErrorG)

    End Sub

    Protected Sub CboEst_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles CboEst.SelectedIndexChanged
        'If ((CboEst.SelectedValue = "DF") Or (CboEst.SelectedValue = "DC")) And (Me.HdTipoUser.Value = "AR") Then
        'If (CboEst.SelectedValue = "DC") And (Me.HdTipoUser.Value = "AR") Then
        If (CboEst.SelectedValue = "DC") Then
            Me.BtnAnular.Enabled = True
        Else
            Me.BtnAnular.Enabled = False
        End If
    End Sub

    Protected Sub button_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button.Click

    End Sub

    Protected Sub CbCdec_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles CbCdec.SelectedIndexChanged

    End Sub

    Protected Sub BtnBuscDP_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnBuscDP.Click
        Me.ModalPopup.Show()
    End Sub
    Private Sub Mostrar_Nit()
        Dim dt As DataTable
        dt = Me.UsuTercero.GetByIde(Me.Nit.Text)
        If (dt.Rows.Count > 0) Then
            Me.Agente.Text = dt.Rows(0)("Ter_Nom").ToString
            Me.Nit.Text = dt.Rows(0)("Ter_nit").ToString
            Me.Dv.Text = Trim(dt.Rows(0)("Ter_dver").ToString)
        End If

    End Sub

    Private Sub ImpDEC()
        

        If grDec.SelectedValue <> "" Then
            Dec_cod = grDec.SelectedValue
            Dec_Tdoc = grDec.SelectedRow.Cells(1).Text()
            'Public Dec_cdec As String

            'Response.Redirect(Me.RUTA_VIRTUAL + "Consultas/Formularios/VerRptDec.aspx?dec_cod=" + grDec.SelectedValue)
            Cargar_Rpt()
            'Me.MsgResult.Text = "Seleccionando:Declaracion[" + grDec.SelectedValue + "]"
            'Me.MsgBox(MsgResult, False)
        Else
            Me.MsgResult.Text = "Seleccione en la lista de Declaraciones una para Visualizar"
            Me.MsgBox(MsgResult, True)
        End If
    End Sub

    Protected Sub ImageButton1_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs)
        ImpDEC()
    End Sub
    Protected Sub GridView1_RowCommand(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewCommandEventArgs)
        Me.Oper.Value = e.CommandName
        Select Case Me.Oper.Value
            Case "Ver"
                ImpDEC()
                Me.MsgResult.Text = "Seleccionando: Código [" + grDec.SelectedValue + "]"

        End Select
    End Sub

    Protected Sub grDec_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles grDec.SelectedIndexChanged

    End Sub

    Protected Sub BtnBuscar_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        Me.ModalPopup.Show()
    End Sub

    Protected Sub BuscarNit_Click1(ByVal sender As Object, ByVal e As System.EventArgs)
        Mostrar_Nit()
    End Sub

    Protected Sub BtnGenerarPDF_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnGenerarPDF.Click
        ImpDEC()
    End Sub

    '-------------------------------------------- GENERAR REPORTVIEWER EN PDF
    Private Function GetDatosP() As DataSet
        Dim dt As DataSet = New DataSet
        Dim obj As CDeclaraciones = New CDeclaraciones()
        dt = obj.GetDeclaracionRpt(Dec_cod)
        Return dt
    End Function
    Protected Sub ReportViewer1_SubreportProcessing(ByVal sender As Object, ByVal e As SubreportProcessingEventArgs)
        Dim dtSet As DataSet = New DataSet()
        Dim obj As CDeclaraciones = New CDeclaraciones()
        dtSet = obj.GetLiqConcep(Dec_cod)
        Dim dataSource As ReportDataSource = New ReportDataSource("DsDecCon_VCODE_CDEC", dtSet.Tables(0))
        e.DataSources.Add(dataSource)
    End Sub

    Private Sub RenderReport(ByVal Rpt As LocalReport)
        'string reportType = "Image"; 
        Dim reportType As String = "PDF"
        Dim fileNameExtension As String = ""
        Dim warnings As Warning() = Nothing
        Dim streamids As String() = Nothing
        Dim mimeType As String = Nothing
        Dim encoding As String = Nothing
        Dim extension As String = Nothing
        'The DeviceInfo settings should be changed based on the reportType 
        'http://msdn2.microsoft.com/en-us/library/ms155397.aspx 
        Dim deviceInfo As String = "<DeviceInfo>" & " <OutputFormat>PDF</OutputFormat>" & " <PageWidth>8.5in</PageWidth>" & " <PageHeight>11in</PageHeight>" & " <MarginTop>0.5in</MarginTop>" & " <MarginLeft>1in</MarginLeft>" & " <MarginRight>1in</MarginRight>" & " <MarginBottom>0.5in</MarginBottom>" & "</DeviceInfo>"
        Dim streams As String() = Nothing
        Dim renderedBytes As Byte()
        'Render the report 
        'deviceInfo, 
        Rpt.Refresh()
        renderedBytes = Rpt.Render(reportType, Nothing, mimeType, encoding, fileNameExtension, streams, warnings)
        Response.Clear()
        Response.ContentType = mimeType
        Response.AddHeader("content-disposition", "attachment; filename=" + Dec_cod + "." & fileNameExtension)
        Response.BinaryWrite(renderedBytes)
        Response.End()
    End Sub
    
    Public Sub Cargar_Rpt()
        Dim nomReporte As String = ""
        Dim obj As CDeclaraciones = New CDeclaraciones
        obj.GetRpt(Dec_cod)
        If obj.lErrorG = True Then
            Me.MsgBox(Me.MsgResult, True)
        End If
        'Response.Write(Me.MsgResult.Text)

        Dim dtSource As ReportDataSource = New ReportDataSource("DsDecl_VDECLARACION", GetDatosP().Tables(0))
        Dim rptEntidad As New ReportDataSource(Me.DS_Entidad, Cargar_Logo())

        ReportViewer1.LocalReport.DataSources.Clear()
        ReportViewer1.LocalReport.DataSources.Add(dtSource)
        ReportViewer1.LocalReport.DataSources.Add(rptEntidad)
        nomReporte = obj.GetRpt(Dec_cod)
        If Dec_Tdoc = "LOAF" Then
            nomReporte = "Af_" & nomReporte
        End If
        Me.ReportViewer1.LocalReport.ReportPath = nomReporte
        Me.ReportViewer1.LocalReport.DisplayName = Dec_cod
        'ReportViewer1.LocalReport.Refresh()
        Me.RenderReport(Me.ReportViewer1.LocalReport)
    End Sub


End Class
