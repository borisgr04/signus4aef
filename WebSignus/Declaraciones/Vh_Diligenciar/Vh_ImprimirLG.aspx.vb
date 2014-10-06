
Partial Class Declaraciones_Vh_Diligenciar_Vh_ImprimirLG
    Inherits PaginaComun

    Dim Paquete As Long = 100
    ReadOnly Property Nro_LiqG() As String
        Get
            Return Request("Nro_LiqG")
        End Get
    End Property

  
    Protected Sub BtnImprimir_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnImprimir.Click
        'Me.Response.Write(String.Format("/ashx/RptForm_LG.aspx?Nro_LiqG={0}&Desde={1}&Hasta={2}", TxtNro_LiqG.Text, TxtDesde.Text, TxtHasta.Text))
        Dim url As String = String.Format("/ashx/RptForm_LG.aspx?Nro_LiqG={0}&Desde={1}&Hasta={2}", TxtNro_LiqG.Text, TxtDesde.Text, TxtHasta.Text)
        Redireccionar_Pagina(url) '345
    End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim oliq As New Vh_Liquidaciones
        Dim tl As Long
        If Not IsPostBack Then
            Me.TxtNro_LiqG.Text = Me.Nro_LiqG
            tl = oliq.GetCantLiqLog(9)
            TxtTotal.Text = tl
            TxtDesde.Text = 1
            TxtHasta.Text = IIf(tl > Paquete, Paquete, tl)
        End If
        oliq.Nro_LiqG = Me.Nro_LiqG
        GridView1.DataSource = oliq.ImpresionLiqxPar(100, tl, Nro_LiqG)
        GridView1.DataBind()

    End Sub
End Class
