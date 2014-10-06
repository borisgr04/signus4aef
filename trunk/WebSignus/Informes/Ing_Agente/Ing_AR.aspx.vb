Imports System.Web.UI.WebControls
Imports System.Web.UI.WebControls.WebParts
Imports System.Web.UI.HtmlControls
Imports Microsoft.Reporting.WebForms
Imports AjaxControlToolkit
Imports system.data
Imports System.Collections.Generic

Partial Class Ing_AR
    Inherits PaginaComun

    Protected Sub LinkButton1_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        Me.ModalPopup.Show()
    End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Me.Opcion = Me.Tit.Text
        Me.SetTitulo()

        If Not Me.IsPostBack Then
            Dim fecha As Date = Now
            Dim ndias As Integer = Date.DaysInMonth(Now.Year, Now.Month)
            Me.TFI.Text = "01/" + CStr(Now.Month) + "/" + CStr(Year(Now()))
            Me.TFF.Text = CStr(ndias) + "/" + CStr(Now.Month) + "/" + CStr(Year(Now()))
        End If
    End Sub
    Public Sub Cargar_Rpt()
        Me.HiddenField1.Value = Filtrar()
        ReportViewer1.LocalReport.Refresh()
        'RptView.LocalReport.ReportPath = "Report\Consultas\RptIngAgen2012.rdlc"
        'RptView.LocalReport.ReportPath = "Report\Consultas\RptIngAgentI.rdlc"


        ''Dim rptParam1 As ReportParameter = New ReportParameter("Fecha_I", Me.TFI.Text)
        ''Dim rptParam2 As ReportParameter = New ReportParameter("Fecha_F", Me.TFF.Text)
        ''Dim rptParam3 As ReportParameter = New ReportParameter("NIT_AG", Me.TNIT.Text + "-" + Me.TNom.Text)
        ''LIsta de Parametros
        'Dim paramList As New List(Of ReportParameter)
        ''Agregar Parametro a Lista
        ''paramList.Add(rptParam1)
        ''paramList.Add(rptParam2)
        ''paramList.Add(rptParam3)
        '' Actualizar Report
        'Rptview.LocalReport.SetParameters(paramList)
        'Dim dtSource As ReportDataSource = New ReportDataSource("DataSet1", GetDatosP)
        ''Dim rptEntidad As New ReportDataSource("DtEntidad_ENTIDAD", Cargar_Logo())
        'Rptview.LocalReport.DataSources.Clear()
        'Rptview.LocalReport.DataSources.Add(dtSource)
        ''Rptview.LocalReport.DataSources.Add(rptEntidad)
        'RptView.LocalReport.Refresh()
        MsgResult.Text = "Datos del Reporte"
        ''Me.RenderReport(Me.ReportViewer1.LocalReport)

    End Sub
    Protected Sub BtnBuscar_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles BtnBuscar.Click
        Cargar_Rpt()

    End Sub
    Private Function GetDatosP() As DataTable
        Dim dt As DataTable = New DataTable
        'Dim obj As Informes = New Informes(Me.CMBCLADEC.SelectedValue)

        MsgResult.Text = Me.HiddenField1.Value
        'dt = obj.Get_Ing_Agen(Me.HiddenField1.Value)

        'Me.MsgResult.Text = "Número de Filas Generadas: " + dt.Rows.Count().ToString

        'If obj.lErrorG = True Then
        '    Me.MsgResult.Text = obj.Msg
        'End If
        'Me.GridView1.DataSource = dt
        'Me.GridView1.DataBind()
        Return dt
    End Function

    Function Filtrar() As String
        Dim Filtro As String = ""
        If CBAR.Checked = True Then
            Filtro = Util.AddFiltro(Filtro, "  MOV_NIT='" + TNIT.Text + "' ")
        End If
        If CBFEC.Checked = True Then
            Filtro = Util.AddFiltro(Filtro, "  FEC_MOV BETWEEN to_date('" + TFI.Text + "','dd/mm/yyyy') AND to_date('" + TFF.Text + "','dd/mm/yyyy') ")
        End If

        If Me.CBCLA.Checked = True Then
            Filtro = Util.AddFiltro(Filtro, "  MOV_CDEC='" + Me.CMBCLADEC.SelectedValue + "' ")
        End If
        If Me.CBCON.Checked = True Then
            Filtro = Util.AddFiltro(Filtro, " MOV_CCAR='" + Me.CMBCON.SelectedValue + "' ")
        End If

        If Me.CBANO.Checked = True Then
            Filtro = Util.AddFiltro(Filtro, " MOV_AÑO='" + Me.CMBANO.SelectedValue + "' ")
        End If

        If Me.CBPER.Checked = True Then
            Filtro = Util.AddFiltro(Filtro, " MOV_PER='" + CMBPER.SelectedValue + "'")
        End If

        Return Filtro
    End Function
End Class
