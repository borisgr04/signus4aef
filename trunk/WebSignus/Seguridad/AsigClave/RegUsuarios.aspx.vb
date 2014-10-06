
Partial Class Seguridad_RegUsuarios
    Inherits PaginaComun

    Protected Sub cmdEnviar_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim Obj As New Usuarios()
        Me.LbRpt.Text = Obj.Insertar(Me.TxtUsername.Text, Me.TxtClave.Text)
        Me.MsgModalPanel.Text = Me.LbRpt.Text
        If Obj.lErrorG = False Then
            Me.MsgModalPanel.ForeColor = Drawing.Color.Black
            Me.ImgRst.ImageUrl = "~/images/Ok.gif"
        Else
            Me.MsgModalPanel.ForeColor = Drawing.Color.Red
            Me.ImgRst.ImageUrl = "~/images/Error.gif"
        End If
        Me.ModalPopup.Show()
    End Sub

    '   LbRpt.Text = "Prueba de Otro Confirmar" + DateTime.Now.ToLongTimeString() + "."

    Protected Sub hideModalPopupViaServer_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        Me.ModalPopup.Hide()
    End Sub


    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Me.Title = Me.Titulo() + "Registro de Usuarios"
        Me.TxtUsername.Attributes.Add("OnBlur", "javascript:ValidarUser();")
    End Sub



    Protected Sub BtnBuscarUser_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        If Usuarios.IsUser(Me.TxtUsername.Text) Then
            Me.msgResult.Text = "InValido Usuario Existe"
        Else
            Me.msgResult.Text = "No existe"
        End If
    End Sub

    Sub Validar_Usuario(ByVal sender As Object, ByVal value As ServerValidateEventArgs)
        value.IsValid = Not Usuarios.IsUser(Me.TxtUsername.Text)
    End Sub

    
    Protected Sub ImageButton1_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs)
        Me.ModalPopupTer.Show()

    End Sub
End Class
