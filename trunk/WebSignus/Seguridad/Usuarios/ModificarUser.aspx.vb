
Partial Class Seguridad_ModificarUser
    '    Inherits System.Web.UI.Page
    Inherits PaginaComun
    Dim u As Membership
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        ' Me.Title = Me.Titulo() + "Cambiar Contraseña"
        Me.SetTitulo()
    End Sub

    Protected Sub Buscar()
        Dim u As MembershipUser = Membership.GetUser(Me.TxtUsername.Text)
        If Not (u Is Nothing) Then
            Me.TxtCorreo.Text = u.Email
            Me.BtnGuardar.Enabled = True
            Me.BtnCancelar.Enabled = True
            Me.TxtUsername.Enabled = False

        Else
            Me.BtnGuardar.Enabled = False
            Me.BtnCancelar.Enabled = False
        End If

    End Sub
    Protected Sub Button1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button1.Click
        Me.Buscar()
    End Sub

    


    Protected Sub BtnGuardar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnGuardar.Click
        Dim oUser As New Usuarios
        msgResult.Text = oUser.Update(Me.TxtUsername.Text, Me.TxtCorreo.Text)
        msgResult.Visible = True

        'Membership.GeneratePassword(
        'Membership.GetUser().ChangePassword()
        'Membership.GetUser.ChangePasswordQuestionAndAnswer()
        'Membership.GetUser.ResetPassword()




        'Me.MsgModalPanel.Text = Me.LbRpt.Text
        'If ap = True Then
        ' Me.MsgModalPanel.ForeColor = Drawing.Color.Black
        ' Me.ImgRst.ImageUrl = "~/images/Ok.gif"
        ' Else
        'Me.MsgModalPanel.ForeColor = Drawing.Color.Red
        'Me.ImgRst.ImageUrl = "~/images/Error.gif"
        'End If
        'Me.ModalPopup.Show()
    End Sub

    Protected Sub Button2_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button2.Click
        Dim u As String = Me.TextBox1.Text
        Dim rst As String = Membership.GetUser(u).ResetPassword
        Membership.GetUser(u).ChangePassword(rst, Me.TextBox2.Text)



    End Sub
End Class
