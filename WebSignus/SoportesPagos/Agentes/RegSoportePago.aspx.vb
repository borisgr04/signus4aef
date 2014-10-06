Imports BLL.Entidades
Imports BLL
Imports ByAUtil

Partial Class SoportesPagos_Agentes_RegSoportePago
    Inherits PaginaComun

    Protected Sub BtnGuardar_Click(sender As Object, e As EventArgs) Handles BtnGuardar.Click

        Dim sop As New Pagos_Sop_DTO
        sop.PAG_NDOC = txtNDec.Text
        'sop.PAG_NIT = Me.u
        sop.PAG_SOP = fupSoporte.FileBytes
        sop.PAG_TIP = rblMedioPago.SelectedValue
        sop.PAG_TOT = txtValPag.Text
        sop.PAG_CTAB = CboCuentaBancaria.SelectedValue
        sop.PAG_FPAG = txtFecPag.Text

        sop.PAG_NIT = Me.User.Identity.Name
        sop.PAG_USAP = Me.User.Identity.Name

        Dim bll As New Pagos_SopBLL

        Dim byaRpt As New ByARpt()
        byaRpt = bll.Insertar(sop)


        msgResult.Text = byaRpt.Mensaje

        MsgBox1(msgResult, byaRpt.Error)





    End Sub

    Protected Sub BtnVolver_Click(sender As Object, e As EventArgs) Handles BtnVolver.Click
        Response.Redirect("GesSoportePago.aspx")
    End Sub
End Class
