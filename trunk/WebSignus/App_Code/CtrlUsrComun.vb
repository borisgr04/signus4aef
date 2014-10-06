Imports Microsoft.VisualBasic

Public Class CtrlUsrComun
    Inherits System.Web.UI.UserControl

    Public Sub Redireccionar_Pagina(ByVal Url As String)
        'Response.Redirect(Me.RUTA_VIRTUAL() + Url)
        Response.Redirect("~" + Url)
        '900006971:
    End Sub

    Public ReadOnly Property RUTA_VIRTUAL() As String
        Get
            Return ConfigurationManager.AppSettings("VIRTUAL")
        End Get
    End Property

End Class
