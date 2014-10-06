
Partial Class CtrlUsr_AyudaIzq_ctrAyudIzql
    Inherits System.Web.UI.UserControl
    Property Mensaje() As String
        Get
            Return Me.LtMsgAyuda.Text
        End Get
        Set(ByVal value As String)
            Me.LtMsgAyuda.Text = value
        End Set
    End Property
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    End Sub
End Class
