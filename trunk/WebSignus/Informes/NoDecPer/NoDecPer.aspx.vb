Imports System.Web.UI.WebControls
Imports System.Web.UI.WebControls.WebParts
Imports System.Web.UI.HtmlControls
Imports Microsoft.Reporting.WebForms
Imports AjaxControlToolkit
Imports system.data
Imports System.Collections.Generic
Partial Class Informes_Default
    Inherits PaginaComun

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        ' Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim mn As New DBMenu
        Dim u As New Usuarios
        'Dim p As String = u.GetPerfil(Context.User.Identity.Name)
        'Welcome.Text = "Hello, " & Context.User.Identity.Name + "perfil : " + p
        Me.Opcion = " Declaraciones x Periodo "
        If Not IsPostBack Then
            Me.MultiView1.ActiveViewIndex = -1
            RptDecxPer.Visible = False
        End If

        Me.SetTitulo()
        'Me.TextBox1.Attributes.Add("OnMouseOver", "with (document.aspnetForm.ctl00_SampleContent_TextBox1.style) { this.originalBgColor=borderColor;borderColor='#999999'; borderWidth = '1px'; borderStyle = 'solid';}")
        'Me.TextBox1.Attributes.Add("OnMouseOver", "with (document.aspnetForm.ctl00_SampleContent_TextBox1.style) { borderColor=this.originalBgColor; borderWidth = '1px'; borderStyle = 'solid';}")

    End Sub

    Public Sub Cargar_Rpt()

        'ENVIAR PARAMETROS
        Dim rptParam As ReportParameter = New ReportParameter("Titulo", Me.CMBCLADEC.SelectedItem.Text)
        Dim rptParam1 As ReportParameter = New ReportParameter("Ano_Grav", Me.CMBANO.SelectedItem.Text)
        Dim rptParam2 As ReportParameter = New ReportParameter("Mun", Me.CMBMPIO.SelectedItem.Text)
        'LIsta de Parametros
        Dim paramList As New List(Of ReportParameter)
        'Agregar Parametro a Lista
        paramList.Add(rptParam)
        paramList.Add(rptParam1)
        paramList.Add(rptParam2)
        ' Actualizar Report
        Rptview.LocalReport.SetParameters(paramList)


        'ACTUALIZAR DATASET
        Rptview.LocalReport.ReportPath = "Report\Consultas\NoDecPerV.rdlc"
        Dim dtSource As ReportDataSource = New ReportDataSource("DsPorPer_DTPOR_PER", GetDatosP)
        Dim rptEntidad As New ReportDataSource("DtEntidad_ENTIDAD", Cargar_Logo())

        Rptview.LocalReport.DataSources.Clear()
        Rptview.LocalReport.DataSources.Add(dtSource)
        Rptview.LocalReport.DataSources.Add(rptEntidad)

        Rptview.LocalReport.Refresh()
        'Me.RenderReport(Me.ReportViewer1.LocalReport)
    End Sub

    Protected Sub BtnBuscar_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles BtnBuscar.Click
        Buscar()
    End Sub
    Sub Buscar()
        'Cargar_Rpt()
        'Me.MultiView1.ActiveViewIndex = 0
        RptDecxPer.Visible = True
        If ChkEstado.Checked = True Then
            Cargar_Rpt_DecxPerxEst()
        Else
            Cargar_Rpt_DecxPer()

        End If
    End Sub

    Private Function GetDatosP() As DataTable
        Dim x As String = ""
        Dim dt As DataTable = New DataTable
        Dim obj As Informes = New Informes(Me.CMBCLADEC.SelectedValue)
        dt = obj.Get_NoDecPer(Me.CMBCLADEC.SelectedValue, Me.CMBANO.SelectedValue, IIf(ChkMun.Checked = True, Me.CMBMPIO.SelectedValue, ""), CboEst.SelectedValue, x)
        Me.MsgResult.Text = ""
        MsgBoxLimpiar(MsgResult)
        If obj.lErrorG = True Then
            Me.MsgResult.Text = obj.Msg
        Else
            Me.MsgResult.Text = ""
            MsgBoxLimpiar(MsgResult)
        End If
        'Me.mensaje.Text = x
        
        Return dt
    End Function
    Protected Sub Btncancel_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs)
        Me.MultiView1.ActiveViewIndex = -1
    End Sub


    Private Function GetDatosDecxPer() As DataTable
        Dim x As String = ""
        Dim dt As DataTable = New DataTable
        Dim obj As Informes = New Informes(Me.CMBCLADEC.SelectedValue)
        dt = obj.Get_DecxPer(Me.CMBCLADEC.SelectedValue, Me.CMBANO.SelectedValue, IIf(ChkMun.Checked = True, Me.CMBMPIO.SelectedValue, ""), x)
        Me.MsgResult.Text = ""
        MsgBoxLimpiar(MsgResult)
        If obj.lErrorG = True Then
            Me.MsgResult.Text = obj.Msg
            MsgBox(Me.MsgResult, obj.lErrorG)
        Else
            Me.MsgResult.Text = ""
            MsgBoxLimpiar(MsgResult)
        End If
        'Me.mensaje.Text = x
        Return dt
    End Function

    Public Sub Cargar_Rpt_DecxPerxEst()
        Dim rptEntidad As New ReportDataSource("DtEntidad_ENTIDAD", Cargar_Logo())
        If Me.CMBCLADEC.SelectedValue = "20" Then
            RptDecxPer_24.Visible = True
            RptDecxPer.Visible = False
            RptDecxPer_24.LocalReport.DataSources.Clear()
            RptDecxPer_24.LocalReport.ReportPath = "Report\Consultas\DecxPer_24.rdlc"
            Dim dtSource As ReportDataSource = New ReportDataSource("DsDecxPer_DecxPer_24", GetDatosDecxPerxEst)
            RptDecxPer_24.LocalReport.DataSources.Add(dtSource)
            Dim rptParam As ReportParameter = New ReportParameter("Titulo", Me.CMBCLADEC.SelectedItem.Text)
            Dim rptParam1 As ReportParameter = New ReportParameter("Ano_Grav", Me.CMBANO.SelectedItem.Text)
            Dim rptParam2 As ReportParameter = New ReportParameter("Mun", Me.CMBMPIO.SelectedItem.Text)
            Dim paramList As New List(Of ReportParameter)
            paramList.Add(rptParam)
            paramList.Add(rptParam1)
            paramList.Add(rptParam2)
            RptDecxPer_24.LocalReport.SetParameters(paramList)
            RptDecxPer_24.LocalReport.DataSources.Add(rptEntidad)
            RptDecxPer_24.LocalReport.Refresh()

        Else
            RptDecxPer.Visible = True
            RptDecxPer_24.Visible = False
            RptDecxPer.LocalReport.DataSources.Clear()
            RptDecxPer.LocalReport.ReportPath = "Report\Consultas\DecxPer.rdlc"
            Dim rptParam As ReportParameter = New ReportParameter("Titulo", Me.CMBCLADEC.SelectedItem.Text)
            Dim rptParam1 As ReportParameter = New ReportParameter("Ano_Grav", Me.CMBANO.SelectedItem.Text)
            Dim rptParam2 As ReportParameter = New ReportParameter("Mun", Me.CMBMPIO.SelectedItem.Text)
            Dim paramList As New List(Of ReportParameter)
            paramList.Add(rptParam)
            paramList.Add(rptParam1)
            paramList.Add(rptParam2)
            RptDecxPer.LocalReport.SetParameters(paramList)
            Dim dtSource As ReportDataSource = New ReportDataSource("DsDecxPer_DecxPer", GetDatosDecxPerxEst)
            RptDecxPer.LocalReport.DataSources.Add(dtSource)
            RptDecxPer.LocalReport.DataSources.Add(rptEntidad)
            RptDecxPer.LocalReport.Refresh()
        End If
        'Me.RenderReport(Me.ReportViewer1.LocalReport)
    End Sub

    Public Sub Cargar_Rpt_DecxPer()
        Dim rptEntidad As New ReportDataSource("DtEntidad_ENTIDAD", Cargar_Logo())
        If Me.CMBCLADEC.SelectedValue = "20" Then
            RptDecxPer_24.Visible = True
            RptDecxPer.Visible = False
            RptDecxPer_24.LocalReport.DataSources.Clear()
            RptDecxPer_24.LocalReport.ReportPath = "Report\Consultas\DecxPer_24.rdlc"
            Dim dtSource As ReportDataSource = New ReportDataSource("DsDecxPer_DecxPer_24", GetDatosDecxPer)
            RptDecxPer_24.LocalReport.DataSources.Add(dtSource)
            Dim rptParam As ReportParameter = New ReportParameter("Titulo", Me.CMBCLADEC.SelectedItem.Text)
            Dim rptParam1 As ReportParameter = New ReportParameter("Ano_Grav", Me.CMBANO.SelectedItem.Text)
            Dim rptParam2 As ReportParameter = New ReportParameter("Mun", Me.CMBMPIO.SelectedItem.Text)
            Dim paramList As New List(Of ReportParameter)
            paramList.Add(rptParam)
            paramList.Add(rptParam1)
            paramList.Add(rptParam2)
            RptDecxPer_24.LocalReport.SetParameters(paramList)
            RptDecxPer_24.LocalReport.DataSources.Add(rptEntidad)
            RptDecxPer_24.LocalReport.Refresh()

        Else
            RptDecxPer.Visible = True
            RptDecxPer_24.Visible = False
            RptDecxPer.LocalReport.DataSources.Clear()
            RptDecxPer.LocalReport.ReportPath = "Report\Consultas\DecxPer.rdlc"
            Dim rptParam As ReportParameter = New ReportParameter("Titulo", Me.CMBCLADEC.SelectedItem.Text)
            Dim rptParam1 As ReportParameter = New ReportParameter("Ano_Grav", Me.CMBANO.SelectedItem.Text)
            Dim rptParam2 As ReportParameter = New ReportParameter("Mun", Me.CMBMPIO.SelectedItem.Text)
            Dim paramList As New List(Of ReportParameter)
            paramList.Add(rptParam)
            paramList.Add(rptParam1)
            paramList.Add(rptParam2)
            RptDecxPer.LocalReport.SetParameters(paramList)
            Dim dtSource As ReportDataSource = New ReportDataSource("DsDecxPer_DecxPer", GetDatosDecxPer)
            RptDecxPer.LocalReport.DataSources.Add(dtSource)
            RptDecxPer.LocalReport.DataSources.Add(rptEntidad)
            RptDecxPer.LocalReport.Refresh()
        End If
        'Me.RenderReport(Me.ReportViewer1.LocalReport)
    End Sub

    Private Function GetDatosDecxPerxEst() As DataTable
        Dim x As String = ""
        Dim dt As DataTable = New DataTable
        Dim obj As Informes = New Informes(Me.CMBCLADEC.SelectedValue)
        dt = obj.Get_NoDecPer(Me.CMBCLADEC.SelectedValue, Me.CMBANO.SelectedValue, IIf(ChkMun.Checked = True, Me.CMBMPIO.SelectedValue, ""), CboEst.SelectedValue, x)
        If obj.lErrorG = True Then
            Me.MsgResult.Text = obj.Msg
            Me.MsgBox(MsgResult, obj.lErrorG)
        Else
            Me.MsgResult.Text = ""
            MsgBoxLimpiar(MsgResult)
        End If

        Return dt
    End Function

 
    Protected Sub ChkEstado_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ChkEstado.CheckedChanged
        Buscar()
    End Sub

    Protected Sub CboEst_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles CboEst.SelectedIndexChanged

    End Sub

    Protected Sub CMBMPIO_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles CMBMPIO.SelectedIndexChanged

    End Sub
End Class
