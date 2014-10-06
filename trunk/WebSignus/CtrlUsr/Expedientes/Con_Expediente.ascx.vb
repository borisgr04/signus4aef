
Partial Class CtrlUsr_Expedientes_Con_Expediente
    Inherits System.Web.UI.UserControl
    Dim sTipo As String

    Property Tipo() As String
        Get
            Return sTipo
        End Get
        Set(ByVal value As String)
            sTipo = value
        End Set
    End Property
    Protected Sub gvConsulta_RowCommand(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewCommandEventArgs)
        If e.CommandName = "Seleccionar" Then
            Dim index As Integer = Convert.ToInt32(e.CommandArgument)
            Me.gvConsulta.SelectedIndex = index
        End If
    End Sub
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
    End Sub

    Protected Sub BtnBuscar_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles BtnBuscar.Click
        tbProceso.Text = ""
        tbTramite.Text = ""
        If chProceso.Checked Then
            tbProceso.Text = cmbProceso.SelectedValue
        End If
        If chTramite.Checked Then
            tbTramite.Text = cmbTramite.SelectedValue
        End If
        odsExpedientes.DataBind()
    End Sub

    Protected Sub gvConsulta_PageIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles gvConsulta.PageIndexChanged

    End Sub

    Protected Sub gvConsulta_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles gvConsulta.RowDataBound

    End Sub

    Protected Sub gvConsulta_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles gvConsulta.SelectedIndexChanged

    End Sub

    Protected Sub tbNumExpe_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles tbNumExpe.TextChanged
        Dim oVig As New Vigencias
        Dim vigencia As String
        vigencia = oVig.GetActiva()
        If Not String.IsNullOrEmpty(tbNumExpe.Text) Then
            If tbNumExpe.Text.Length < 12 Then
                tbNumExpe.Text = vigencia + tbNumExpe.Text.PadLeft(8, "0")
            End If
        End If
    End Sub
End Class
