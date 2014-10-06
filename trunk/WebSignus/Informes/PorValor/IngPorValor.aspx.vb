
Partial Class Report_PorValor_IngPorValor
    Inherits PaginaComun

    Function Filtrar() As String
        Dim cFiltro As String = ""

        If CHKValor.Checked = True Then
            Util.AddFiltro(cFiltro, "Valor BetWeen " + TxtValorI.Text + " And " + TxtValorF.Text)
        End If
        If CBCLA.Checked = True Then
            Util.AddFiltro(cFiltro, "Mov_Cdec='" + CMBCLADEC.SelectedValue + "'")
        End If

        If CBFEC.Checked = True Then
            Util.AddFiltro(cFiltro, "Fec_Mov BetWeen to_date('" + TFI.Text + "','dd/mm/yyyy') And to_date('" + TFF.Text + "','dd/mm/yyyy')")
        End If

        If CBANO.Checked = True Then
            Util.AddFiltro(cFiltro, "Mov_Año = '" + CMBANO.SelectedValue + "'")
        End If

        If cbMes.Checked = True Then
            Util.AddFiltro(cFiltro, "Mov_Per = '" + CMBPER.SelectedValue + "'")
        End If

        If CBCTA.Checked = True Then
            Util.AddFiltro(cFiltro, "Pag_BaCo = '" + CMBBCO.SelectedValue + "'")
            Util.AddFiltro(cFiltro, "Pag_CTab = '" + CMBCTA.SelectedValue + "'")
        End If

        If CBCON.Checked = True Then
            Util.AddFiltro(cFiltro, "Mov_CCar = '" + CMBCON.SelectedValue + "'")
        End If

        If Me.CBTPAR.Checked = True Then
            Util.AddFiltro(cFiltro, "ter_tip = '" + Me.CbTTcer.SelectedValue + "'")
        End If
        If Me.CHKMUN.Checked = True Then
            Util.AddFiltro(cFiltro, "ter_mpio = '" + Me.CbMun.SelectedValue + "'")
        End If
        
        Return cFiltro
    End Function
    Protected Sub GridView1_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles GridView1.RowDataBound
        If e.Row.RowType = DataControlRowType.DataRow Then
            'ASIGNA(EVENTOS)
            e.Row.Attributes.Add("OnMouseOver", "Resaltar_On(this);")
            e.Row.Attributes.Add("OnMouseOut", "Resaltar_Off(this);")
            e.Row.Attributes("OnClick") = Page.ClientScript.GetPostBackClientHyperlink(Me.GridView1, "Select$" + e.Row.RowIndex.ToString)
        End If
    End Sub

    
    Protected Sub GridView1_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles GridView1.SelectedIndexChanged
        Redireccionar_Pagina("/ashx/RptForm.ashx?dec_cod=" + GridView1.SelectedDataKey(0) + "&dec_doad=" + GridView1.SelectedDataKey(1))
    End Sub

    Protected Sub BtnBuscar_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles BtnBuscar.Click
        Dim obj As New InfIngxValor
        GridView1.DataSource = obj.GetDatos(Filtrar())
        GridView1.DataBind()

    End Sub
End Class
