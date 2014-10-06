
Partial Class Expediente_Gtram_Gtram
    Inherits PaginaComun

    Protected Sub gvVencidos_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles gvVencidos.SelectedIndexChanged
        querystringSeguro = Me.SetRequest()
        querystringSeguro("numExp") = gvVencidos.SelectedValue
        Redireccionar_Pagina("Expediente/Atram/Atram.aspx?data=" + HttpUtility.UrlEncode(querystringSeguro.ToString()))
    End Sub

    Protected Sub gvExpeSinNotif_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles gvExpeSinNotif.SelectedIndexChanged
        querystringSeguro = Me.SetRequest()
        querystringSeguro("numExp") = gvExpeSinNotif.SelectedValue
        Redireccionar_Pagina("Expediente/Atram/Atram.aspx?data=" + HttpUtility.UrlEncode(querystringSeguro.ToString()))
    End Sub
End Class
