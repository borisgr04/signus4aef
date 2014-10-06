
Partial Class Login
    Inherits PaginaComun
    Dim Vig As New Vigencias
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Context.Request.Browser.Adapters.Clear()
        'Me.CmbVigencia.SelectedValue = Vig.GetActiva()
    End Sub

    Protected Sub cmdEnviar_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        'System.Threading.Thread.Sleep(10000)
        'If Me.TxtUsername.Text = "ADMIN" And Me.TxtClave.Text = "1234567890@" Then
        
    End Sub

    Public Sub IniciarSesion()
        Dim u As String = Me.txtUserName.Text.Trim
        Dim c As String = Me.TxtClave.Text.Trim
        'If Membership.ValidateUser(u, c) = True Then
        If Membership.ValidateUser(u, c) Then
            Me.MsgResult.Text = "Acceso Permitido :" + Now.ToLongTimeString
            'Me.MsgModalPanel.ForeColor = Drawing.Color.Black
            'Me.ImgRst.ImageUrl = "~/images/Ok.gif"
            'Me.ModalPopup.Show()
            'Almacenar Vigencia Seleccionada
            Dim aCookie As New HttpCookie("DERWEB")
            aCookie.Expires = Now
            'aCookie.Values("Vigencia") = UCase(Me.CmbVigencia.SelectedValue)
            Response.Cookies.Add(aCookie)

            FormsAuthentication.RedirectFromLoginPage(Me.txtUserName.Text, False)
        Else

            Me.MsgResult.Text = "Acceso Denegado : Usuario o Contreña Inválidas"
            'Me.MsgModalPanel.ForeColor = Drawing.Color.Black
            'Me.MsgModalPanel.Font.Bold = False
            'Me.ImgRst.ImageUrl = "~/images/Error.gif"
            'Me.ModalPopup.Show()
        End If
    End Sub
    Protected Sub BtnIniciarSesion_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnIniciarSesion.Click
        IniciarSesion()

    End Sub
End Class
