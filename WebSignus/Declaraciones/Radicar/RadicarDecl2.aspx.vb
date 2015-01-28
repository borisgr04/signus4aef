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
Imports BLL



Partial Class Declaraciones_Radicar_RadicarDecl2
    Inherits PaginaComun
    ' Inherits System.Web.UI.Page
    Dim NroRenglon As String = "0"
    Dim DoAd As String = "DELP"
    Dim nro_dec As String
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Me.Opcion = Me.Tit.Text
        Me.SetTitulo()
        'Me.TxtCta.Attributes.Add("onfocus", "this.setfocus=false;")
        If Not IsPostBack Then
            Me.BtnDetalleShow.Visible = False
            Me.TFec_pre.Text = Now.ToShortDateString

            nro_dec = Request.QueryString("nro_dec")
            TxtNroDec.Text = nro_dec
            GetDatosP()
        End If
    End Sub
    Protected Function NRenglon() As String
        NroRenglon = CStr(CInt(NroRenglon) + 1)
        Return NroRenglon
    End Function
    Protected Function Radicar() As String
        Me.MsgResult.Text = "<ul>"
        Dim r As New BLL.Radicar()
        Dim dto As New RadicacionDTO()
        dto.ban_cod = Me.TxtBanCod.Text
        dto.ban_cta = Me.TxtCta.Text
        dto.dcod = Me.TxtNroDec.Text
        'dto.dest = "PR"
        dto.dfpre = CDate(Me.TFec_pre.Text)
        dto.usap = Membership.GetUser().UserName
        dto.lstReq = New List(Of Dec_RequiDTO)
        Dim ObjRd As Radicar_Dec = New Radicar_Dec
        Dim Cant As Integer = DataList1.Items.Count
        For i As Integer = 0 To Cant - 1
            Dim ESTADO As CheckBox = DirectCast(DataList1.Items(i).FindControl("Req_estado"), CheckBox)
            Dim CODREQ As HiddenField = DirectCast(DataList1.Items(i).FindControl("Req_CODREQ"), HiddenField)
            Dim dr As New Dec_RequiDTO()
            dr.DR_NRORAD = dto.dcod
            dr.DR_ESTADO = IIf(ESTADO.Checked = True, "1", "0")
            dr.DR_CODREQ = CODREQ.Value
            dto.lstReq.Add(dr)
        Next
        r.rad = dto

        If (IsDate(Me.TFec_pre.Text) = False) Then
            Me.MsgResult.Text = "Digite una Fecha Válida"
            Me.MsgBox(MsgResult, True)
        Else
            MsgResult.Text = r.RadicarD()
            'MsgResult.Text = ObjRd.Insert(Me.HdTDOC.Value, Me.TxtNroDec.Text, aRadD, CDate(Me.TFec_pre.Text), Me.TxtBanCod.Text, Me.TxtCta.Text)
            Me.MsgBox(MsgResult, r.lErrorG)
        End If
        Return ""
    End Function

    Protected Sub BtRadicar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtRadicar.Click
        Radicar()
    End Sub

    Private Function GetDatosP() As DataSet
        Dim dt As DataSet = New DataSet
        Dim obj As CDeclaraciones = New CDeclaraciones(Me.CmbClDec.SelectedValue)
        dt = obj.GetDeclaracion(Me.TxtNroDec.Text)
        Dim dTabla As DataTable = dt.Tables(0)


        If dTabla.Rows.Count > 0 Then
            Me.Agente.Text = dTabla.Rows(0)("DEC_RAZSOC").ToString
            Me.LBTIPODEC.Text = dTabla.Rows(0)("TAG_NOM").ToString
            Me.Identificaciòn.Text = dTabla.Rows(0)("DEC_nit").ToString
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

            Me.MsgResult.Text = ""
        Else
            Me.MsgResult.Text = "No se ha encontrado Formulario de Declaración con este Número" + Me.TxtNroDec.Text
            Me.Cancelar()
        End If

        ' Me.MsgResult.Text += Me.TxtNroDec.Text + dTabla.Rows.Count.ToString
        ' Me.MsgResult.Visible = True

        Return dt
    End Function


    Protected Sub ImageButton1_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles ImageButton1.Click
        Me.BtnDetalleShow.Visible = True
        GetDatosP()
    End Sub


    Protected Sub BtnDetalleShow_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnDetalleShow.Click

        'Me.BtnDetalleShow.Visible = False
        Redireccionar_Pagina("/ashx/RptForm.ashx?dec_cod=" + TxtNroDec.Text)

    End Sub

    

    Protected Sub Cancelar()
        Me.Agente.Text = ""
        Me.LBTIPODEC.Text = ""
        Me.Identificaciòn.Text = ""
        Me.DV.Text = ""
        Me.TIP_DOC_IDE.Text = ""
        Me.LDEC_ANO.Text = ""
        Me.LDEC_PER.Text = ""
        Me.TTOTALDEC.Text = ""
        Me.TTOTALPAGO.Text = ""

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
    End Sub
End Class
