Imports System.Data
Imports Signus

Partial Class Publico_Logout
    Inherits System.Web.UI.Page
    Dim objt As Terceros = New Terceros
    Dim dt As DataTable
    Dim msg As String

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Me.Title = Me.Tit.Text
        FormsAuthentication.SignOut()
        Context.User = Nothing
        Session.Abandon()
        Session.Clear()
    End Sub

End Class
