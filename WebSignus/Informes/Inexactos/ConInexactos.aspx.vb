Imports System.Data
Partial Class Informes_Inexactos_ConInexactos
    Inherits PaginaComun
    Dim obj As CDeclaraciones = New CDeclaraciones

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Me.Opcion = Me.Tit.Text
        Me.SetTitulo()
    End Sub

    Protected Sub GridView1_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs)
        If e.Row.RowType = DataControlRowType.DataRow Then
            ' ASIGNA EVENTOS
            e.Row.Attributes.Add("OnMouseOver", "Resaltar_On(this);")
            e.Row.Attributes.Add("OnMouseOut", "Resaltar_Off(this);")
            '            e.Row.Attributes("OnClick") = Page.ClientScript.GetPostBackClientHyperlink(Me.GridView1, "Select$" + e.Row.RowIndex.ToString)
        End If

    End Sub



    Protected Sub GridView2_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs)
        If e.Row.RowType = DataControlRowType.DataRow Then
            ' ASIGNA EVENTOS
            e.Row.Attributes.Add("OnMouseOver", "Resaltar_On(this);")
            e.Row.Attributes.Add("OnMouseOut", "Resaltar_Off(this);")
            '            e.Row.Attributes("OnClick") = Page.ClientScript.GetPostBackClientHyperlink(Me.GridView1, "Select$" + e.Row.RowIndex.ToString)
        End If
    End Sub

  

    Protected Sub GridView1_RowCommand(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewCommandEventArgs)
        Select Case e.CommandName
            Case "Editar"
                Me.SubT.Text = "Editando..."
                Dim index As Integer = Convert.ToInt32(e.CommandArgument)
                Me.GridView1.SelectedIndex = index
                Dim tb As DataTable = obj.GetDeclaracion(Me.GridView1.SelectedValue).Tables(0)
                If tb.Rows.Count > 0 Then
                    'If 1 = 0 Then
                    Me.CboEst.SelectedValue = tb.Rows(0)("DEC_ESFI").ToString
                    Me.TxtCodNew.Text = tb.Rows(0)("DEC_COD").ToString
                End If
                Me.ModalPopupTer.Show()
        End Select
    End Sub

    Protected Sub BtnGuardar_Click(ByVal sender As Object, ByVal e As System.EventArgs)

        Me.MsgResult.Text = obj.Update_EstFis(Me.TxtCodNew.Text, Me.CboEst.Text)
        Me.MsgBox(Me.MsgResult, obj.lErrorG)


    End Sub

    Protected Sub GridView1_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles GridView1.SelectedIndexChanged
        Me.MsgResult.CssClass = ""
        Me.MsgResult.Text = ""
    End Sub

    Protected Sub CboEstFis_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs)
        Me.MsgResult.CssClass = ""
        Me.MsgResult.Text = ""
    End Sub
End Class
