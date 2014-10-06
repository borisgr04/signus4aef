Imports System.Web.UI.WebControls
Imports System.Web.UI.WebControls.WebParts
Imports System.Web.UI.HtmlControls
Imports Microsoft.Reporting.WebForms
Imports AjaxControlToolkit
Imports system.data
Imports System.Collections.Generic

Partial Class Informes_No_Declarantes
    Inherits PaginaComun

    Sub Page_Load(ByVal Src As Object, ByVal e As EventArgs) Handles Me.Load
        ' Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim mn As New DBMenu
        Dim u As New Usuarios
        Me.Opcion = " Listado de Declaraciones  "
        If Not IsPostBack Then
            Me.MultiView1.ActiveViewIndex = -1
        End If
        Me.SetTitulo()
    End Sub

    'Public Sub Cargar_Rpt()
    '    Dim rptParam As ReportParameter = New ReportParameter("Titulo", Me.CMBCLADEC.SelectedItem.Text)
    '    Dim rptParam1 As ReportParameter = New ReportParameter("Ano_Grav", Me.CMBANO.SelectedItem.Text)
    '    'LIsta de Parametros
    '    Dim paramList As New List(Of ReportParameter)
    '    'Agregar Parametro a Lista
    '    paramList.Add(rptParam)
    '    paramList.Add(rptParam1)
    '    ' Actualizar Report
    '    Rptview.LocalReport.SetParameters(paramList)

    '    Rptview.LocalReport.ReportPath = "Report\Consultas\NO_Declarante.rdlc"
    '    Dim dtSource As ReportDataSource = New ReportDataSource("DsTerceros_VTERCEROS", GetDatosP)
    '    Dim rptEntidad As New ReportDataSource("DtEntidad_ENTIDAD", Cargar_Logo())

    '    Rptview.LocalReport.DataSources.Clear()
    '    Rptview.LocalReport.DataSources.Add(dtSource)
    '    Rptview.LocalReport.DataSources.Add(rptEntidad)
    '    Rptview.LocalReport.Refresh()
    '    'Me.RenderReport(Me.ReportViewer1.LocalReport)

    'End Sub

    Protected Sub BtnBuscar_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles BtnBuscar.Click
        'Cargar_Rpt()
        Cargar_Rpt2()
        'Cargar_Rpt3()
        Me.MultiView1.ActiveViewIndex = 0
    End Sub
    'Private Function GetDatosP() As DataTable
    '    Dim dt As DataTable = New DataTable
    '    Dim VarmPIO As String
    '    Dim obj As Informes = New Informes(Me.CMBCLADEC.SelectedValue)
    '    If Me.CheckBox1.Checked = False Then
    '        VarmPIO = ""
    '    Else
    '        VarmPIO = Me.CMBMPIO.SelectedValue
    '    End If
    '    dt = obj.Get_NoDeclarantes(Me.CMBPER.SelectedValue, Me.CMBANO.SelectedValue, VarmPIO, Me.CMBEST.SelectedValue, CboMostrar.SelectedValue)
    '    Return dt
    'End Function

    Protected Sub Btncancel_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs)
        Me.MultiView1.ActiveViewIndex = -1
    End Sub

    
    Public Sub Cargar_Rpt2()
        'Dim rptParam As ReportParameter = New ReportParameter("Titulo", Me.CMBCLADEC.SelectedItem.Text)
        'Dim rptParam1 As ReportParameter = New ReportParameter("Ano_Grav", Me.CMBANO.SelectedItem.Text)
        'LIsta de Parametros
        'Dim paramList As New List(Of ReportParameter)
        'Agregar Parametro a Lista
        'paramList.Add(rptParam)
        'paramList.Add(rptParam1)
        ' Actualizar Report
        'Rptview.LocalReport.SetParameters(paramList)

        ReportViewer1.LocalReport.ReportPath = "Report\Consultas\RptDecPer.rdlc"
        Dim dtSource As ReportDataSource = New ReportDataSource("DsDecl_VDECLARACION", GetDatosDec)
        'Dim rptEntidad As New ReportDataSource("DtEntidad_ENTIDAD", Cargar_Logo())
        ReportViewer1.LocalReport.DataSources.Clear()
        ReportViewer1.LocalReport.DataSources.Add(dtSource)
        'Rptview.LocalReport.DataSources.Add(rptEntidad)
        ReportViewer1.LocalReport.Refresh()
        'Me.RenderReport(Me.ReportViewer1.LocalReport)

    End Sub


    Private Function GetDatosDec() As DataTable
        Dim dt As DataTable = New DataTable
        Dim obj As Informes = New Informes(Me.CMBCLADEC.SelectedValue)
        dt = obj.GetDeclaraciones(Filtrar)
        Return dt
    End Function

    Function Filtrar() As String

        Dim cFiltro As String = ""
        If CBCLA.Checked = True Then
            Util.AddFiltro(cFiltro, "Dec_Cdec='" + CMBCLADEC.SelectedValue + "'")
        End If
        If (CBFEC.Checked = True) And Tipo_Grupo.SelectedValue = "D" Then
            Util.AddFiltro(cFiltro, "Dec_FReg BetWeen to_date('" + TFI.Text + "','dd/mm/yyyy') And to_date('" + TFF.Text + "','dd/mm/yyyy')")
        ElseIf (CBFEC.Checked = True) And Tipo_Grupo.SelectedValue = "I" Then
            Util.AddFiltro(cFiltro, "Dec_FPre BetWeen to_date('" + TFI.Text + "','dd/mm/yyyy') And to_date('" + TFF.Text + "','dd/mm/yyyy')")
        End If
        If CBANO.Checked = True Then
            Util.AddFiltro(cFiltro, "Dec_Ano = '" + CMBANO.SelectedValue + "'")
        End If
        If cbMes.Checked = True Then
            Util.AddFiltro(cFiltro, "Dec_Per = '" + CMBPER.SelectedValue + "'")
        End If
        If CboMun.Checked = True Then
            Util.AddFiltro(cFiltro, "Ter_Mpio = '" + CMBMPIO.SelectedValue + "'")
        End If
        If CBEst.Checked = True Then
            Util.AddFiltro(cFiltro, "Dec_Est = '" + CboEst.SelectedValue + "'")
        End If
        If CBCTA.Checked = True Then
            Util.AddFiltro(cFiltro, "Dec_BaCo = '" + CMBBCO.SelectedValue + "'")
            Util.AddFiltro(cFiltro, "Dec_CTa = '" + CMBCTA.SelectedValue + "'")
        End If

        'Me.MsgResult.Text = cFiltro
        Return cFiltro
    End Function
    
End Class
