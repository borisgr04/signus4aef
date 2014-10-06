Imports System.Data
Partial Class CtrlUsr_Liq_CU_ConLiq
    Inherits CtrlUsrComun

    Property NroLiq() As String
        Get
            Return HdLiq.Value
        End Get
        Set(ByVal value As String)
            HdLiq.Value = value

        End Set

    End Property

    Property Encontrado() As Boolean
        Get
            Return CBool(ViewState("Encontrado"))
        End Get
        Set(ByVal value As Boolean)
            ViewState("Encontrado") = value
        End Set
    End Property
    Property Tabla() As DataTable
        Get
            Return DirectCast(ViewState("Tabla"), DataTable)
        End Get
        Set(ByVal value As DataTable)
            ViewState("Tabla") = value
        End Set
    End Property
    Property Tipo_Doc() As String
        Get
            Return ViewState("Tipo_Doc")
        End Get
        Set(ByVal value As String)
            ViewState("Tipo_Doc") = value
        End Set
    End Property
    Property Estado() As String
        Get
            Return ViewState("Estado")
        End Get
        Set(ByVal value As String)
            ViewState("Estado") = value
        End Set
    End Property
    Sub Buscar()
        Dim dt As DataSet = New DataSet
        Dim obj As CDeclaraciones = New CDeclaraciones()
        dt = obj.GetDeclaracion(NroLiq)
        Dim dTabla As DataTable = dt.Tables(0)
        Tabla = dTabla
        MsgResult.CssClass = ""
        MsgResult.Text = ""
        If dTabla.Rows.Count > 0 Then
            Me.Agente.Text = dTabla.Rows(0)("DEC_RAZSOC").ToString
            Me.LBTIPODEC.Text = dTabla.Rows(0)("TAG_NOM").ToString
            Me.Identificaciòn.Text = dTabla.Rows(0)("DEC_nit").ToString
            Me.DV.Text = dTabla.Rows(0)("DEC_dver").ToString
            Me.TIP_DOC_IDE.Text = dTabla.Rows(0)("DEC_tdoc").ToString
            Me.LDEC_ANO.Text = dTabla.Rows(0)("DEC_ANO").ToString
            Me.LDEC_PER.Text = dTabla.Rows(0)("DEC_PER").ToString
            Me.Cla_Dec.Text = dTabla.Rows(0)("CLD_NOM").ToString
            Me.CboEstado.Text = dTabla.Rows(0)("DEC_EST").ToString
            Estado = dTabla.Rows(0)("DEC_EST").ToString
            Tipo_Doc = dTabla.Rows(0)("DEC_DOAD").ToString
            'Me.HdTDOC.Value = dTabla.Rows(0)("DEC_DOAD").ToString
            Me.MsgResult.Text = ""
            Pn1.Visible = True
            Encontrado = True
        Else
            Me.MsgResult.Text = "No se ha encontrado Formulario N° " + NroLiq
            MsgBox(MsgResult, True)
            Pn1.Visible = False
            Encontrado = False
        End If
        Me.GridView1.DataBind()
    End Sub

    Protected Sub GridView1_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles GridView1.RowDataBound
        If e.Row.RowType = DataControlRowType.DataRow Then
            'ASIGNA(EVENTOS)
            e.Row.Attributes.Add("OnMouseOver", "Resaltar_On(this);")
            e.Row.Attributes.Add("OnMouseOut", "Resaltar_Off(this);")
            'e.Row.Attributes("OnClick") = Page.ClientScript.GetPostBackClientHyperlink(Me.GridView1, "Select$" + e.Row.RowIndex.ToString)
        End If
    End Sub

    

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Me.HdLiq.Value = "" Then
            Buscar()
            Estado = ""
        End If

    End Sub

    Protected Sub LnkDec_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles LnkDec.Click
        Redireccionar_Pagina("/ASHX/RptForm.ashx?dec_cod=" + Me.HdLiq.Value)
    End Sub

    Protected Sub MsgBox(ByRef msg As Label, ByVal lError As Boolean)

        msg.Height = 50
        msg.Width = 600

        msg.CssClass = IIf(lError = True, "NotOk", "Ok")

    End Sub
End Class
