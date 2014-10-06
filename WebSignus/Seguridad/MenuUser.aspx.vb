
Partial Class Seguridad_MenuUser
    Inherits System.Web.UI.Page

    Protected Sub Button1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button1.Click

        'Membership.DeleteUser("ROOT", True)
        'Membership.DeleteUser("qwerty", True)
        'Membership.DeleteUser("boris", True)
        'Membership.DeleteUser("1", True)
        'Membership.DeleteUser("ADMIN", True)
        'Membership.DeleteUser("B", True)
        'Membership.DeleteUser("BORIS", True)
        '1234567890@




    End Sub

    Protected Sub Button2_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button2.Click
        Dim X As Boolean = Membership.ValidateUser("ADMIN", "1234567890@")
        If X = True Then
            Response.Write("ok")

        End If

    End Sub
End Class

