
Partial Class _Default
    Inherits PaginaComun


    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Me.Opcion = "Inicio - Instrucciones a Seguir..."
        Me.SetTitulo()
        Dim c As New CarteraConsulta()
        lbCartera.Text = FormatCurrency(c.GetSaldo())
        'PnlCartera.visible = False
    End Sub
End Class
