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


Partial Class Declaraciones_AplicarP_AplicarPago
    Inherits PaginaComun
    ' Inherits System.Web.UI.Page
    Dim NroRenglon As String = "0"
    Dim DoAd As String = "DELP"
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Me.Opcion = Me.Tit.Text
        Me.SetTitulo()
        'Me.TxtCta.Attributes.Add("onfocus", "this.setfocus=false;")
        If Not IsPostBack Then
            Me.MultiView1.ActiveViewIndex = -1
            Me.MultiView2.ActiveViewIndex = -1
            Me.BtnDetalleShow.Visible = False
            Me.BtnDetalleHide.Visible = False
            Me.TFec_pre.Text = Now.ToShortDateString
        End If
    End Sub
    Protected Function NRenglon() As String
        NroRenglon = CStr(CInt(NroRenglon) + 1)
        Return NroRenglon
    End Function
    'Aplicar Pago
    Protected Sub BtRadicar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtRadicar.Click
        Me.BtRadicar.Enabled = False
        Dim obj As ReciboOf = New ReciboOf
        Me.MsgResult.Text = obj.Aplicar_pago(Me.TxtNro.Text, Me.TFec_pre.Text, Me.TxtBanCod.Text, Me.TxtCta.Text, Me.HdRof.Value)
        Me.MsgBox(Me.MsgResult, obj.lErrorG)
        Me.BtRadicar.Enabled = obj.lErrorG
    End Sub
    Public Sub Cargar_Rpt()
        GetDatosP()
    End Sub
    Public Sub Cargar_Rpt2()
        Dim obj As CDeclaraciones = New CDeclaraciones
        If obj.Existe_Declaracion(Me.TxtNro.Text) Then
            'Me.MsgResult.Text = obj.GetRpt(Me.TxtNroDec.Text)
            'Response.Write(Me.MsgResult.Text)
            Me.MsgBox(Me.MsgResult, True)
            Dim dtSource As ReportDataSource = New ReportDataSource("DsDecl_VDECLARACION", GetDatosP())
            Dim rptEntidad As New ReportDataSource(Me.DS_Entidad, Cargar_Logo())
            ReportViewer1.LocalReport.DataSources.Clear()
            ReportViewer1.LocalReport.DataSources.Add(dtSource)
            ReportViewer1.LocalReport.DataSources.Add(rptEntidad)
            Me.ReportViewer1.LocalReport.ReportPath = obj.GetRpt(Me.TxtNro.Text)
            Me.ReportViewer1.LocalReport.DisplayName = Me.TxtNro.Text
            ReportViewer1.LocalReport.Refresh()
            Me.MsgResult.CssClass = ""
        Else
            Me.MsgResult.Text = " No se encuentra recibo oficial  con este número"
            Me.MsgBox(Me.MsgResult, True)

        End If

    End Sub
    Protected Sub ReportViewer1_SubreportProcessing(ByVal sender As Object, ByVal e As SubreportProcessingEventArgs)
        Dim dtSet As DataSet = New DataSet()
        Dim obj As CDeclaraciones = New CDeclaraciones(Me.CmbClDec.SelectedValue)
        dtSet = obj.GetLiqConcep(Me.TxtNro.Text)
        Dim dataSource As ReportDataSource = New ReportDataSource("DsDecCon_VCODE_CDEC", dtSet.Tables(0))
        e.DataSources.Add(dataSource)
    End Sub
    Private Function GetDatosP() As DataTable
        Dim dTabla As DataTable = New DataTable
        Dim obj As ReciboOf = New ReciboOf
        dTabla = obj.GetRecordsDF(Me.TxtNro.Text)
        If dTabla.Rows.Count > 0 Then
            Me.Agente.Text = dTabla.Rows(0)("TER_NOM").ToString
            Me.LBTIPODEC.Text = dTabla.Rows(0)("TAG_NOM").ToString
            Me.Identificaciòn.Text = dTabla.Rows(0)("TER_NIT").ToString
            Me.DV.Text = dTabla.Rows(0)("TER_dver").ToString
            Me.TIP_DOC_IDE.Text = dTabla.Rows(0)("TER_TDOC").ToString
            Me.LDEC_ANO.Text = dTabla.Rows(0)("ROF_ANO").ToString
            Me.LDEC_PER.Text = dTabla.Rows(0)("ROF_PER").ToString
            Me.CmbClDec.SelectedValue = dTabla.Rows(0)("ROF_CDEC").ToString
            Me.HdTDOC.Value = dTabla.Rows(0)("ROF_TDOC").ToString
            Me.TxtValImp.Text = dTabla.Rows(0)("ROF_VPA").ToString
            Me.TxtValSan.Text = dTabla.Rows(0)("ROF_SAN").ToString
            Me.TxtIntMora.Text = dTabla.Rows(0)("ROF_INT").ToString
            Me.txtTotPag.Text = dTabla.Rows(0)("ROF_TPAG").ToString
            Me.LbNdoc.Text = dTabla.Rows(0)("ROF_DECC").ToString
            Me.lbTRecib.Text = dTabla.Rows(0)("ROF_TDOC").ToString + "-" + dTabla.Rows(0)("TIDO_NOMB").ToString
            Me.HdRof.Value = dTabla.Rows(0)("ROF_TROF").ToString
            Me.MultiView2.ActiveViewIndex = 0
            Me.MsgResult.Text = ""
        Else
            Me.MsgResult.Text = "No se ha encontrado Formulario de Declaración con este Número" + Me.TxtNro.Text
            Me.Cancelar()
        End If

        Return dTabla
    End Function


    Protected Sub ImageButton1_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles ImageButton1.Click
        Me.BtnDetalleShow.Visible = True
        Me.BtnDetalleHide.Visible = False
        Me.MsgResult.Text = ""
        Me.MsgResult.CssClass = ""
        Cargar_Rpt()
    End Sub


    Protected Sub BtnDetalleShow_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnDetalleShow.Click
        MultiView1.ActiveViewIndex = 0
        Me.BtnDetalleShow.Visible = False
        Me.BtnDetalleHide.Visible = True
    End Sub

    Protected Sub BtnDetalleHide_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnDetalleHide.Click
        MultiView1.ActiveViewIndex = -1
        Me.BtnDetalleShow.Visible = True
        Me.BtnDetalleHide.Visible = False
    End Sub

    Protected Sub Cancelar()
        Me.Agente.Text = ""
        Me.LBTIPODEC.Text = ""
        Me.Identificaciòn.Text = ""
        Me.DV.Text = ""
        Me.TIP_DOC_IDE.Text = ""
        Me.LDEC_ANO.Text = ""
        Me.LDEC_PER.Text = ""
        Me.TxtValImp.Text = ""
        Me.TxtValSan.Text = ""

        Me.MultiView1.ActiveViewIndex = -1
        Me.MultiView2.ActiveViewIndex = -1
        Me.MsgResult.Text = ""
    End Sub
    Protected Sub BtnBuscDP_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnBuscDP.Click
        Me.ModalPopup.Show()
    End Sub

    Protected Sub BtnCancelar_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles BtnCancelar.Click
        Me.Cancelar()
    End Sub


End Class
