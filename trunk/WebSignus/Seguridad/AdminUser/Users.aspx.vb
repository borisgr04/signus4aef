
Partial Class Seguridad_AdminUser_Users
    Inherits PaginaComun

    Protected Sub LookupBtn_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles LookupBtn.Click

    End Sub

    Protected Sub GridView1_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs)




    End Sub

    Protected Sub btnIna_Click(ByVal sender As Object, ByVal e As System.EventArgs)

        Membership.GetUser(Me.TxtUserName.Text).UnlockUser()

    End Sub

    Protected Sub Eliminar_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        Membership.DeleteUser(Me.TxtUserName.Text)
    End Sub
End Class
