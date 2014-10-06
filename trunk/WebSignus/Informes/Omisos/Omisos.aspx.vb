Imports System.Web.UI.WebControls
Imports System.Web.UI.WebControls.WebParts
Imports System.Web.UI.HtmlControls
Imports Microsoft.Reporting.WebForms
Imports AjaxControlToolkit
Imports system.data
Imports System.Collections.Generic
Partial Class Informes_Default
    Inherits PaginaComun
    Dim DtCal As DataTable
    Dim factoryomisos As OmisosFactory = New OmisosFactory()
    Dim omisos As COmisos
    Dim Calend As Calendario = New Calendario


    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    End Sub

    Protected Sub BtnBuscar_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles BtnBuscar.Click
        Cargar_Rpt2()
    End Sub
 
  
    Public Sub Cargar_Rpt2()

        Dim vSVigencia As String = Me.CMBANO.SelectedValue
        Dim vSClaseDec As String = Me.CMBCLADEC.SelectedValue


        ' PARAMETROS DEL REPORTE
        'Darle los valores a losparametros
        Dim RptParamVigencia As ReportParameter = New ReportParameter("TITULO", Me.CMBANO.SelectedItem.Text)
        Dim RptParamClaseDec As ReportParameter = New ReportParameter("PrmClaseDec", Me.CMBCLADEC.SelectedItem.Text)
        'Crear la lIsta de Parametros
        Dim paramList As New List(Of ReportParameter)
        'Agregar Parametro a Lista
        paramList.Add(RptParamVigencia)
        paramList.Add(RptParamClaseDec)
        'Enviar los Valores de los parametros
        Rptview.LocalReport.SetParameters(paramList)

        Dim dtSource As New ReportDataSource("DataSet1", GetDatosP(Me.CMBCLADEC.SelectedValue, Me.CMBANO.SelectedValue, ChkEnt.Checked, Me.Nit.Text, ChkMun.Checked, CMBMPIO.SelectedValue, ChkTipAg.Checked, Me.CbTTcer.SelectedValue, DtCal))
        Dim rptEntidad As New ReportDataSource("DtEntidad_ENTIDAD", Cargar_Logo())


        'ACTUALIZAR DATASET
        Rptview.LocalReport.ReportPath = omisos.RutaReport
        Rptview.LocalReport.DataSources.Clear()
        Rptview.LocalReport.DataSources.Add(dtSource)
        Rptview.LocalReport.DataSources.Add(rptEntidad)
        Rptview.LocalReport.Refresh()
        'Me.RenderReport(Me.Rptview.LocalReport)
    End Sub
    Private Function GetDatosP(ByVal vClaseDec As String, ByVal vVigClaseDec As String, ByVal vChkEnt As Boolean, ByVal vNit As String, ByVal vChkMpio As Boolean, ByVal vMpio As String, ByVal vChkTipAge As Boolean, ByVal vTipAge As String, ByVal Calendar As DataTable) As DataTable
        Dim dt As DataTable = New DataTable
        Dim VOmNit As String = IIf(vChkEnt = True, vNit, "")
        Dim VOmMpio As String = IIf(vChkMpio = True, vMpio, "")
        Dim VOmTipAgen As String = IIf(vChkTipAge = True, vTipAge, "")
        Dim cant As Integer = 0

        DtCal = Calend.Get_CalendarioxVigxCla(vClaseDec, vVigClaseDec)
        cant = DtCal.Rows.Count
        omisos = factoryomisos.create(cant)
        dt = omisos.Get_omisos(vClaseDec, vVigClaseDec, VOmNit, VOmMpio, VOmTipAgen, DtCal)

        Me.Rptview.Visible = True
        If factoryomisos.lErrorG = True Then
            Me.MsgResult.Text = factoryomisos.Msg
        Else
            Me.MsgResult.Text = ""
            MsgBoxLimpiar(MsgResult)
        End If


        Return dt
    End Function
  

    Protected Sub BtnBuscar_Click(sender As Object, e As System.EventArgs) Handles BtnBuscDP.Click
        Me.ModalPopupTer.Show()
    End Sub

    

End Class
