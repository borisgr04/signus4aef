Imports System.Data.OleDb
Imports System.Collections.Generic
Imports System
Imports System.Configuration
Imports System.Web
Imports System.Web.Security
Imports System.Web.UI
Imports System.Web.UI.WebControls
Imports System.Web.UI.WebControls.WebParts
Imports System.Web.UI.HtmlControls
Imports Microsoft.Reporting.WebForms
Imports AjaxControlToolkit
Imports System.Data
Partial Class Consultas_Declaraciones_VerRptDec
    Inherits PaginaComun
    Public Dec_cod As String
    Public Dec_cdec As String

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dec_cod = Request.QueryString("dec_cod")
        Dec_cdec = Request.QueryString("Dec_cdec")
        Cargar_Rpt()
        Me.SetTitulo()

    End Sub
    Public Sub Cargar_Rpt()
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
        Me.ReportViewer1.LocalReport.ReportPath = obj.GetRpt(Dec_cod)
        Me.ReportViewer1.LocalReport.DisplayName = Dec_cod
        ReportViewer1.LocalReport.Refresh()
    End Sub
    Private Function GetDatosP() As DataSet
        Dim dt As DataSet = New DataSet
        Dim obj As CDeclaraciones = New CDeclaraciones()
        dt = obj.GetDeclaracion(Dec_cod)
        Return dt
    End Function
    Protected Sub ReportViewer1_SubreportProcessing(ByVal sender As Object, ByVal e As SubreportProcessingEventArgs)
        Dim dtSet As DataSet = New DataSet()
        Dim obj As CDeclaraciones = New CDeclaraciones()
        dtSet = obj.GetLiqConcep(Dec_cod)
        Dim dataSource As ReportDataSource = New ReportDataSource("DsDecCon_VCODE_CDEC", dtSet.Tables(0))
        e.DataSources.Add(dataSource)
    End Sub
End Class
