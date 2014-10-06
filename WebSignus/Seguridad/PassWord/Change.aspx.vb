
Partial Class Seguridad_PassWord_Change
    Inherits PaginaComun

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Me.Opcion = "Modificar Contraseña"
        Me.SetTitulo()
    End Sub

    Protected Sub ContinuePushButton_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        Response.Redirect(Me.RUTA_VIRTUAL + "default.aspx")
    End Sub
End Class
