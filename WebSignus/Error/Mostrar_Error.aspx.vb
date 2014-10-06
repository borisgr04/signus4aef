
Partial Class Error_Mostrar_Error
    Inherits System.Web.UI.Page

    Protected Sub Button1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button1.Click
        c()
    End Sub

    'Protected Sub Page_Error(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Error
    Private Sub c()
        Dim objErr As Exception = Server.GetLastError().GetBaseException()
        Dim err As String = "<b>Error Caught in Page_Error event</b><hr><br>" & _
            "<br><b>Error in: </b>" & Request.Url.ToString() & _
            "<br><b>Error Message: </b>" & objErr.Message.ToString() & _
            "<br><b>Stack Trace:</b><br>" & _
            objErr.StackTrace.ToString()
        Response.Write(err.ToString())
        Server.ClearError()
    End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        c()
    End Sub
End Class
