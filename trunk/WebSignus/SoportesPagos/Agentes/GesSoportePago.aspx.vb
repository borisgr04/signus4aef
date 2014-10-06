Imports BLL
Imports ByAUtil

Partial Class SoportesPagos_Agentes_GesSoportePago
    Inherits PaginaComun

    Protected Sub Page_Load(sender As Object, e As EventArgs) Handles Me.Load
        Me.HiddenField1.Value = Me.User.Identity.Name
        Me.grdPagos_Sop.DataBind()
    End Sub

    Protected Sub BtnNuevo_Click(sender As Object, e As EventArgs) Handles BtnNuevo.Click
        Response.Redirect("RegSoportePago.aspx")
    End Sub

    Protected Sub BtnEliminar_Click(sender As Object, e As EventArgs) Handles BtnEliminar.Click
        Dim nrodec As String
        nrodec = grdPagos_Sop.SelectedValue

        Dim bll As New Pagos_SopBLL

        Dim byaRpt As New ByARpt()

        byaRpt = bll.Eliminar(nrodec)


        msgResult.Text = byaRpt.Mensaje

        MsgBox1(msgResult, byaRpt.Error)

        grdPagos_Sop.DataBind()



    End Sub

    Protected Sub BtnSoporte_Click(sender As Object, e As EventArgs) Handles BtnSoporte.Click
        If Not grdPagos_Sop.SelectedValue Is Nothing Then
            Response.Redirect("~/ashx/DescargaSoportePago.ashx?nro_dec=" + grdPagos_Sop.SelectedValue)
        End If

    End Sub
End Class
