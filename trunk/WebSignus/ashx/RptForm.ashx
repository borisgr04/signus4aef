<%@ WebHandler Language="VB" Class="RptForm" %>

Imports System
Imports System.Web
Imports Microsoft.Reporting.WebForms
Imports System.Data

Public Class RptForm : Implements IHttpHandler
    Dim Dec_cod As String
    Dim dec_doad As String
    Public DS_Entidad As String = "DtEntidad_ENTIDAD"
    Dim ReportViewer1 As New ReportViewer
    
    Public Sub ProcessRequest(ByVal context As HttpContext) Implements IHttpHandler.ProcessRequest
        Dec_cod = context.Request("Dec_Cod")
        dec_doad = context.Request("dec_doad")
        Dim renderedBytes As Byte()
        renderedBytes = Cargar_Rpt()
        'context.Response.ContentType = "text/plain"
        'context.Response.Write("Hello World")
        Dim mimeType As String = Nothing
        context.Response.Clear()
        context.Response.ContentType = mimeType
        context.Response.AddHeader("content-disposition", "attachment; filename=" + Dec_cod + ".pdf")
        context.Response.BinaryWrite(renderedBytes)
        context.Response.End()
    End Sub
 
    Public ReadOnly Property IsReusable() As Boolean Implements IHttpHandler.IsReusable
        Get
            Return False
        End Get
    End Property
    
    Public Function Cargar_Rpt() As Byte()
        Dim obj As CDeclaraciones = New CDeclaraciones
        Dim nomReporte As String = ""
        obj.GetRpt(Dec_cod)
        Dim dtSource As ReportDataSource = New ReportDataSource("DsDecl_VDECLARACION", GetDatosP().Tables(0))
        Dim rptEntidad As New ReportDataSource(Me.DS_Entidad, Cargar_Logo())
    
        AddHandler ReportViewer1.LocalReport.SubreportProcessing, AddressOf ReportViewer1_SubreportProcessing

        ReportViewer1.LocalReport.DataSources.Clear()
        ReportViewer1.LocalReport.DataSources.Add(dtSource)
        ReportViewer1.LocalReport.DataSources.Add(rptEntidad)
        nomReporte = obj.GetRpt(Dec_cod)
        If dec_doad = "LOAF" Then
            nomReporte = "Af_" & nomReporte
        End If
        ReportViewer1.LocalReport.ReportPath = nomReporte
        ReportViewer1.LocalReport.DisplayName = Dec_cod
        'ReportViewer1.LocalReport.Refresh()
        Return Me.RenderReport(ReportViewer1.LocalReport)
    End Function


    Private Function RenderReport(ByVal Rpt As LocalReport) As Byte()
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
        Return renderedBytes
    End Function
    
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
        Dim tip_dec As String = Dec_cod.Substring(4, 2)
        If tip_dec = "30" Then '' Si es registro
            Dim dbg As New De_Bg_Registro()
            Dim d As New CDeclaraciones(tip_dec)
            Dim dec As New DataTable
            dec = d.GetDeclaracion(Dec_cod).Tables(0)
            Dim nit, vig, per As String
            nit = dec.Rows(0)("Dec_Nit")
            vig = dec.Rows(0)("Dec_Ano")
            per = dec.Rows(0)("Dec_Per")
            Dim ter As New Signus.Terceros
            Dim dt As DataTable = ter.GetByIde(nit)
            Dim tag As String = dt.Rows(0)("Ter_tip").ToString

            Dim dtReg As DataTable = dbg.Get_BaseG_Registro(tag, nit, vig, per, "I")
            Dim dtDev As DataTable = dbg.Get_BaseG_Registro(tag, nit, vig, per, "D")

            'Throw New Exception("Registro" + dtReg.Rows.Count + "Impto" + dtDev.Rows.Count)

            Dim ds_bg_registro As ReportDataSource = New ReportDataSource("ds_bg_ingresos", dtReg)
            e.DataSources.Add(ds_bg_registro)

            Dim ds_bg_devoluciones As ReportDataSource = New ReportDataSource("ds_bg_devoluciones", dtDev)
            e.DataSources.Add(ds_bg_devoluciones)
        End If
    End Sub
    
    Protected Function Cargar_Logo() As DataTable
        'Dim ta As New DtEntidadTableAdapters.ENTIDADTableAdapter
        'Dim dt As New DtEntidad.ENTIDADDataTable
        Dim dt As DataTable = New DataTable
        Dim e As New Entidad
        dt = e.GetRecords()
        dt.Columns.Add("ENT_IMG", Type.GetType("System.Byte[]"))

        ''ta.Fill(dt)
        'Dim row As DtEntidad.ENTIDADRow
        Dim Rut As String = Me.Img_Rpt

        'For Each row In dt.Rows
        Dim fsArchivo As New IO.FileStream(Rut + "\" + dt.Rows(0)("ENT_LOGO"), IO.FileMode.Open, IO.FileAccess.Read)
        Dim arregloBytes(fsArchivo.Length) As Byte
        fsArchivo.Read(arregloBytes, 0, fsArchivo.Length)
        fsArchivo.Close()
        dt.Rows(0)("ENT_IMG") = arregloBytes
        'Next

        Return dt
    End Function
    
    Public Function Img_Rpt() As String
        Return ConfigurationManager.AppSettings("IMG_RPT")
    End Function

End Class