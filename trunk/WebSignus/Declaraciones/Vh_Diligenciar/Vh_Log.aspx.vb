
Partial Class Declaraciones_Vh_Diligenciar_Vh_Log
    Inherits PaginaComun
    Dim OLiq As New Vh_Liquidaciones
    Dim AbrirVentanaImp As String = "javascript:window.open('Vh_ImprimirLG.aspx','Progress','width=400,height=250,menubar=yes,scrollbars=yes'); return true;"
    ReadOnly Property Nro_LiqG As String
        Get
            Return Request.QueryString("Nro_LiqG")
        End Get
    End Property
    Public Overrides Sub VerifyRenderingInServerForm(ByVal control As Control)

    End Sub
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Me.Opcion = "Vehiculos-Log de Resultados"
        Me.SetTitulo()
        If Not IsPostBack Then
            Me.GridLog.DataSource = OLiq.GetLiqLog(Me.Nro_LiqG)
            Me.GridLog.DataBind()
            If GridLog.Rows.Count = 0 Then
                Exit Sub
            End If
        End If

        Dim tl As Long
        tl = OLiq.GetCantLiqLog(Nro_LiqG)
        OLiq.Nro_LiqG = Me.Nro_LiqG
        GridView1.DataSource = OLiq.ImpresionLiqxPar(100, tl, Nro_LiqG)
        GridView1.DataBind()

    End Sub

 

    Protected Sub IBtnExportar_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles IBtnExportar.Click
        ExportGridView(Me.GridLog, "Log de Resultados de Liquidación Grupal N° [" + Me.Nro_LiqG + "]")
    End Sub

    Protected Sub GridView1_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles GridView1.RowDataBound
        If e.Row.RowType = DataControlRowType.DataRow Then
            e.Row.Attributes.Add("OnMouseOver", "Resaltar_On(this);")
            e.Row.Attributes.Add("OnMouseOut", "Resaltar_Off(this);")
        End If
    End Sub

    Protected Sub GridLog_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles GridLog.RowDataBound
        If e.Row.RowType = DataControlRowType.DataRow Then
            e.Row.Attributes.Add("OnMouseOver", "Resaltar_On(this);")
            e.Row.Attributes.Add("OnMouseOut", "Resaltar_Off(this);")
        End If
    End Sub
End Class
