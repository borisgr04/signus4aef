
Partial Class Error_prueba
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Throw (New System.ArgumentNullException())
    End Sub
    'Protected Sub Page_Error(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Error
    Private Sub c()
        Dim objErr As Exception = Server.GetLastError().GetBaseException()
        Dim err As String = "<b>Error Caught in Page_Error event</b><hr><br>" & _
            "<br><b>Error in: </b>" & Request.Url.ToString() & _
            "<br><b>Error Message: </b>" & objErr.Message.ToString() & _
            "<br><b>Stack Trace:</b><br>" & _
            objErr.StackTrace.ToString()
        Dim s As String = Mail.EnviarAuto("Error:[" + Membership.GetUser.UserName + "]" + Now.ToLongTimeString, err)
        Response.Write(err.ToString() + s)

        Server.ClearError()
    End Sub
End Class
