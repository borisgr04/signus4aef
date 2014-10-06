Imports BLL
Imports ByAUtil

Partial Class SoportesPagos_Rentas_GesSoportePago
    Inherits PaginaComun

    Protected Sub Page_Load(sender As Object, e As EventArgs) Handles Me.Load
        Me.HiddenField1.Value = Me.User.Identity.Name
        Me.grdPagos_Sop.DataBind()
    End Sub

    
    Protected Sub BtnSoporte_Click(sender As Object, e As EventArgs) Handles BtnSoporte.Click
        If Not grdPagos_Sop.SelectedValue Is Nothing Then
            Response.Redirect("~/ashx/DescargaSoportePago.ashx?nro_dec=" + grdPagos_Sop.SelectedValue)
        End If

    End Sub

    Protected Sub grdPagos_Sop_SelectedIndexChanged(sender As Object, e As EventArgs) Handles grdPagos_Sop.SelectedIndexChanged
        
    End Sub

    Protected Sub BtnAplicar_Click(sender As Object, e As EventArgs) Handles BtnAplicar.Click
        If Not grdPagos_Sop.SelectedValue Is Nothing Then
            Response.Redirect("~/Declaraciones/Radicar/RadicarDecl2.aspx?nro_dec=" + grdPagos_Sop.SelectedValue)
        End If
    End Sub
End Class
