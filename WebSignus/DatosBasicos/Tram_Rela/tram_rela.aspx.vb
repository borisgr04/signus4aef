
Partial Class DatosBasicos_Tram_Rela_tram_rela
    Inherits PaginaComun

    Protected Sub btDesde_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btDesde.Click
        ModalPopupConTramite.Show()
        HfOrigen.Value = "D"
    End Sub

    Protected Sub btPara_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btPara.Click
        ModalPopupConTramite.Show()
        HfOrigen.Value = "P"
    End Sub

    Protected Sub btGuardar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btGuardar.Click
        Dim oTram As New Tram_Rela
        MsgResult.Text = oTram.Insert(HfDesde.Value, HfPara.Value)
        MsgBox1(MsgResult, oTram.lErrorG)
        If Not oTram.lErrorG Then
            Limpiar()
            gvConsulta.DataBind()
        End If
    End Sub

    Protected Sub CtrlConsTradmite2_SelClicked(ByVal sender As Object, ByVal e As System.EventArgs) Handles CtrlConsTramite2.SelClicked
        If HfOrigen.Value = "D" Then
            tbDesde.Text = CtrlConsTramite2.NomTramite
            HfDesde.Value = CtrlConsTramite2.CodTramite
        Else
            tbPara.Text = CtrlConsTramite2.NomTramite
            HfPara.Value = CtrlConsTramite2.CodTramite
        End If
        ModalPopupConTramite.Hide()
    End Sub
    Public Sub Limpiar()
        tbDesde.Text = ""
        tbPara.Text = ""
        HfDesde.Value = ""
        HfPara.Value = ""
        HfOrigen.Value = ""
    End Sub

    Protected Sub gvConsulta_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles gvConsulta.SelectedIndexChanged
        Dim oTram As New Tram_Rela
        HfDesde.Value = gvConsulta.DataKeys(gvConsulta.SelectedIndex).Item(0)
        HfPara.Value = gvConsulta.DataKeys(gvConsulta.SelectedIndex).Item(1)
        MsgResult.Text = oTram.Delete(HfDesde.Value, HfPara.Value)
        MsgBox1(MsgResult, oTram.lErrorG)
        gvConsulta.DataBind()
    End Sub
End Class
