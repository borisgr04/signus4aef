
Imports System.Text
Imports System.CodeDom.Compiler
Imports System.Collections.Specialized

Imports System.Data
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
Partial Class Declaraciones_AcuerdoPag_RecAcPag
    Inherits PaginaComun

    Protected Sub BtnBuscDP_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        Me.ModalPopup.Show()
    End Sub

    Protected Sub GridView1_RowCommand(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewCommandEventArgs)
        MultiView1.ActiveViewIndex = 0
        Dim index As Integer = Convert.ToInt32(e.CommandArgument)
        Me.GridView1.SelectedIndex = index
        Me.HdNroAcu.Value = Me.GridView1.SelectedValue
    End Sub


    Protected Sub GuardarPago()
        Dim objRec As ReciboOf = New ReciboOf
        Dim NitAg As String = Me.Nit.Text
        Dim Per As String = ""
        Dim Año As String = ""
        Dim Cla_Dec As String = Me.CbCdec.SelectedValue
        Dim VP As Decimal = CDec(Me.TXTVP.Text.Replace("$", ""))
        Dim Int As Decimal = 0
        Dim San As Decimal = 0
        Dim cap As Decimal = 0
        Dim dtConsulta As DataTable
        Dim NroAcu As String = Me.GridView1.SelectedValue
        'VALIDAR QUE EL VALOR DEL RECIBO NO SEA MAYOR QUE EL SALDO DEL ACUERDO DE PAGO DE LA PERSONA
        dtConsulta = objRec.GetDistribucionROAP(VP, NitAg, GridView1.SelectedValue)
        cap = dtConsulta.Rows(0)("VAL_PAG")
        Int = dtConsulta.Rows(1)("VAL_PAG")
        San = dtConsulta.Rows(2)("VAL_PAG")
        Me.MsgResult.Text = objRec.Insert(NitAg, Per, Año, cap, Int, Cla_Dec, NroAcu, San, "ACPA", "ROAP")
        Me.HdNoAcu.Value = objRec.ROF_COD

        Me.MsgBox(Me.MsgResult, objRec.lErrorG)
    End Sub

    Protected Sub BTNPAGCUO_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BTNPAGCUO.Click
        If GridView1.SelectedIndex > -1 Then
            Me.ModalPopupTer3.Show()
            MsgBoxLimpiar(MsgResult)
        Else
            MsgResult.Text = "Seleccione primero el Acuerdo de Pago"
            MsgBoxError(MsgResult, True)
        End If
    End Sub
    Protected Sub BTNGPDF_Click1(ByVal sender As Object, ByVal e As System.EventArgs) Handles BTNGPDF.Click
        If GridView1.SelectedIndex > -1 Then
            If CDec(Me.TXTVP.Text.Replace("$", "")) <> 0 Then
                Dim oAcuerdo As New AcuerdosP
                Dim dtConsulta As New DataTable
                dtConsulta = oAcuerdo.GetSaldoAcuerdo(GridView1.SelectedValue)
                If CDec(Me.TXTVP.Text.Replace("$", "")) > CDec(dtConsulta.Rows(0)("SALDO").ToString) Then
                    MsgResult.Text = "El valor del Recibo de Pago no puede ser mayor al Saldo del Acuerdo: " + dtConsulta.Rows(0)("SALDO").ToString
                    MsgBoxError(MsgResult, True)
                    ModalPopupTer3.Hide()
                Else
                    GuardarPago()
                    Me.Cargar_Rpt()
                    ModalPopupTer3.Hide()
                End If
            End If
        Else
            MsgResult.Text = "Seleccione primero el Acuerdo de Pago"
            MsgBoxError(MsgResult, True)
        End If
    End Sub
   
    '-*--------------------------
    Public Sub Cargar_Rpt()
        Dim objRec As ReciboOf = New ReciboOf
        ReportViewer1.LocalReport.ReportPath = "Report\ReciboOF\RptRecOf.rdlc"
        If HdNoAcu.Value <> "" Then
            Dim dtSource As ReportDataSource = New ReportDataSource("DSRecOf_VRecOf", GetDatosP().Tables(0))
            Dim rptEntidad As New ReportDataSource(Me.DS_Entidad, Cargar_Logo())

            ReportViewer1.LocalReport.DataSources.Clear()
            ReportViewer1.LocalReport.DataSources.Add(dtSource)
            ReportViewer1.LocalReport.DataSources.Add(rptEntidad)
            ReportViewer1.LocalReport.Refresh()
            Me.RenderReport(Me.ReportViewer1.LocalReport)
            'MultiView1.ActiveViewIndex = 1
        End If
    End Sub
    Private Function GetDatosP() As DataSet
        Dim dt As DataSet = New DataSet
        Dim objRec As ReciboOf = New ReciboOf
        Me.MsgResult.Text = "el valor es" + HdNoAcu.Value
        'If HdNoAcu.Value <> "" Then
        'Dim objDEC As CDeclaraciones = New CDeclaraciones(Me.Cla_Dec.Value)
        dt = objRec.GetRecOfRpt(HdNoAcu.Value)
        ' Else
        '    Me.MsgResult.Text = "No existe Nro de Recibo de Pago"
        '   Me.MsgBox(Me.MsgResult, True)
        ' End If

        Return dt

    End Function

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
        Response.AddHeader("content-disposition", "attachment; filename=ROAP" & Me.HdNoAcu.Value & "." & fileNameExtension)
        Response.BinaryWrite(renderedBytes)
        Response.End()
    End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Me.Opcion = Me.Tit.Text
        Me.SetTitulo()
    End Sub
End Class
