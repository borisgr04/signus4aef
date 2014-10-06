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



Partial Class Declaraciones_Radicar_RadicarDecl
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
    Protected Function Radicar() As Radicar_Decl()


        Dim Cant As Integer = DataList1.Items.Count
        Dim aRadD(0 To Cant - 1) As Radicar_Decl
        Me.MsgResult.Text = "<ul>"
        Dim ObjRd As Radicar_Dec = New Radicar_Dec
        For i As Integer = 0 To Cant - 1
            Dim ESTADO As CheckBox = DirectCast(DataList1.Items(i).FindControl("Req_estado"), CheckBox)
            Dim CODREQ As HiddenField = DirectCast(DataList1.Items(i).FindControl("Req_CODREQ"), HiddenField)
            aRadD(i).DR_ESTADO = IIf(ESTADO.Checked = True, "1", "0")
            aRadD(i).DR_CODREQ = CODREQ.Value
        Next

        If (IsDate(Me.TFec_pre.Text) = False) Then
            Me.MsgResult.Text = "Digite una Fecha V�lida"
            Me.MsgBox(MsgResult, True)
        Else
            Me.MsgResult.Text = Me.TxtCta.Text

            MsgResult.Text = ObjRd.Insert(Me.HdTDOC.Value, Me.TxtNroDec.Text, aRadD, CDate(Me.TFec_pre.Text), Me.TxtBanCod.Text, Me.TxtCta.Text)
            Me.MsgBox(MsgResult, ObjRd.lErrorG)
        End If

        Return aRadD
    End Function

    Protected Sub BtRadicar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtRadicar.Click
        Radicar()
    End Sub
    Public Sub Cargar_Rpt()
        Dim obj As CDeclaraciones = New CDeclaraciones
        If obj.Existe_Declaracion(Me.TxtNroDec.Text) Then
            'Me.MsgResult.Text = obj.GetRpt(Me.TxtNroDec.Text)
            'Response.Write(Me.MsgResult.Text)
            Me.MsgBox(Me.MsgResult, True)
            Dim dtSource As ReportDataSource = New ReportDataSource("DsDecl_VDECLARACION", GetDatosP().Tables(0))
            Dim rptEntidad As New ReportDataSource(Me.DS_Entidad, Cargar_Logo())
            ReportViewer1.LocalReport.DataSources.Clear()
            ReportViewer1.LocalReport.DataSources.Add(dtSource)
            ReportViewer1.LocalReport.DataSources.Add(rptEntidad)
            Me.ReportViewer1.LocalReport.ReportPath = obj.GetRpt(Me.TxtNroDec.Text)
            Me.ReportViewer1.LocalReport.DisplayName = Me.TxtNroDec.Text
            ReportViewer1.LocalReport.Refresh()
            Me.MsgResult.CssClass = ""
        Else
            Me.MsgResult.Text = " No se encuentra la formulario con este n�mero"
            Me.MsgBox(Me.MsgResult, True)

        End If

    End Sub
    Protected Sub ReportViewer1_SubreportProcessing(ByVal sender As Object, ByVal e As SubreportProcessingEventArgs)
        Dim dtSet As DataSet = New DataSet()
        Dim obj As CDeclaraciones = New CDeclaraciones(Me.CmbClDec.SelectedValue)
        dtSet = obj.GetLiqConcep(Me.TxtNroDec.Text)
        Dim dataSource As ReportDataSource = New ReportDataSource("DsDecCon_VCODE_CDEC", dtSet.Tables(0))
        e.DataSources.Add(dataSource)
    End Sub
    Private Function GetDatosP() As DataSet
        Dim dt As DataSet = New DataSet
        Dim obj As CDeclaraciones = New CDeclaraciones(Me.CmbClDec.SelectedValue)
        dt = obj.GetDeclaracion(Me.TxtNroDec.Text)
        Dim dTabla As DataTable = dt.Tables(0)
        If dTabla.Rows.Count > 0 Then
            Me.Agente.Text = dTabla.Rows(0)("DEC_RAZSOC").ToString
            Me.LBTIPODEC.Text = dTabla.Rows(0)("TAG_NOM").ToString
            Me.Identificaci�n.Text = dTabla.Rows(0)("DEC_nit").ToString
            Me.DV.Text = dTabla.Rows(0)("DEC_dver").ToString
            Me.TIP_DOC_IDE.Text = dTabla.Rows(0)("DEC_tdoc").ToString
            Me.LDEC_ANO.Text = dTabla.Rows(0)("DEC_ANO").ToString
            Me.LDEC_PER.Text = dTabla.Rows(0)("DEC_PER").ToString
            Me.CmbClDec.SelectedValue = dTabla.Rows(0)("DEC_CDEC").ToString
            Me.HdTDOC.Value = dTabla.Rows(0)("DEC_DOAD").ToString
            Dim Objrad As Radicar_Dec = New Radicar_Dec
            Dim dTabTotDec As DataTable = New DataTable
            dTabTotDec = Objrad.GetTotDec(Me.TxtNroDec.Text)
            If dTabTotDec.Rows.Count > 0 Then
                Me.TTOTALDEC.Text = dTabTotDec.Rows(0)("code_vade").ToString
            End If
            Dim dTabTotPag As DataTable = New DataTable
            dTabTotPag = Objrad.GetTotPag(Me.TxtNroDec.Text)
            If dTabTotPag.Rows.Count > 0 Then
                Me.TTOTALPAGO.Text = dTabTotPag.Rows(0)("code_vade").ToString
            End If
            Dim dTabIM As DataTable = New DataTable
            dTabIM = Objrad.GetIntMora(Me.TxtNroDec.Text)
            If dTabTotPag.Rows.Count > 0 Then
                Me.TxtIntMora.Text = dTabIM.Rows(0)("code_vade").ToString
            End If
            Me.MultiView2.ActiveViewIndex = 0
            Me.MsgResult.Text = ""
        Else
            Me.MsgResult.Text = "No se ha encontrado Formulario de Declaraci�n con este N�mero" + Me.TxtNroDec.Text
            Me.Cancelar()
        End If

        Return dt
    End Function


    Protected Sub ImageButton1_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles ImageButton1.Click
        Me.BtnDetalleShow.Visible = True
        Me.BtnDetalleHide.Visible = False
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
        Me.Identificaci�n.Text = ""
        Me.DV.Text = ""
        Me.TIP_DOC_IDE.Text = ""
        Me.LDEC_ANO.Text = ""
        Me.LDEC_PER.Text = ""
        Me.TTOTALDEC.Text = ""
        Me.TTOTALPAGO.Text = ""

        Me.MultiView1.ActiveViewIndex = -1
        Me.MultiView2.ActiveViewIndex = -1
        Me.MsgResult.Text = ""

        Dim Cant As Integer = DataList1.Items.Count
        Dim aRadD(0 To Cant - 1) As Radicar_Decl
        Dim ObjRd As Radicar_Dec = New Radicar_Dec
        For i As Integer = 0 To Cant - 1
            Dim ESTADO As CheckBox = DirectCast(DataList1.Items(i).FindControl("req_estado"), CheckBox)
            ESTADO.Checked = True
        Next
    End Sub
    Protected Sub BtnBuscDP_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnBuscDP.Click
        Me.ModalPopup.Show()
    End Sub

    Protected Sub BtnCancelar_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles BtnCancelar.Click
        Me.Cancelar()
    End Sub

    Protected Sub TxtNroDec_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles TxtNroDec.TextChanged
        Me.BtnDetalleShow.Visible = True
        Me.BtnDetalleHide.Visible = False
        Cargar_Rpt()
    End Sub
End Class