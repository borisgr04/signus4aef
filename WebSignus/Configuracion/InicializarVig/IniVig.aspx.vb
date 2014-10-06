
Partial Class Configuracion_InicializarVig_IniVig
    Inherits PaginaComun

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Me.Opcion = Me.Tit.Text
        Me.SetTitulo()

        
    End Sub

    Protected Sub BtnTras_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnTras.Click
        Me.MsgResult.Text = OVig.TRALADAR_CONF(Me.CboVig.SelectedValue, CheckBoxList1)
        Me.MsgBox(Me.MsgResult, OVig.lErrorG)
    End Sub

    Protected Sub CheckBoxList1_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles CheckBoxList1.SelectedIndexChanged
        'If CheckBoxList1.SelectedIndex <> -1 Then
        '    Me.MsgResult.Text = OVig.TRALADAR_CONF(Me.CboVig.SelectedValue, CheckBoxList1.SelectedItem.Value)
        '    Me.MsgBox(Me.MsgResult, OVig.lErrorG)
        'End If
    End Sub
End Class
