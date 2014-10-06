Imports System.Data
'Imports datos = DAL
Imports Signus

Partial Class MasterPage
    Inherits System.Web.UI.MasterPage

    Dim UsuTercero As New Terceros

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim mn As New DBMenu


        mn.cargarMenu(Me.MnuPpal)
        'mn.cargarMenu(Me.Menu2)
        'Me.Menu2.Orientation = Orientation.Vertical
        'Me.Menu2.DisappearAfter = 2000
        'Me.Menu2.MaximumDynamicDisplayLevels = 3
        'Me.Menu2.StaticDisplayLevels = 2
        'Me.Menu2.DynamicVerticalOffset = 0
        'Me.Menu2.StaticSubMenuIndent = 20

        'Me.Menu1.DisappearAfter = 1000





        Dim dt As DataTable = Me.UsuTercero.GetByUser()
        If dt.Rows.Count > 0 Then
            Me.LbTer.Text = dt.Rows(0)("Ter_Nom").ToString
            'Me.TIP_DOC_IDE.Text = dt.Rows(0)("Ter_tdoc").ToString
            'Me.Agente.Text = dt.Rows(0)("Ter_Nom").ToString
            'Me.LBTIPODEC.Text = dt.Rows(0)("TAG_NOM").ToString
            'Me.Identificaciòn.Text = dt.Rows(0)("Ter_nit").ToString
            'Me.DV.Text = dt.Rows(0)("Ter_dver").ToString
        End If
        ''..
        If Not Me.IsPostBack Then
            'LbVig.Text = Request.Cookies("DERWEB")("vigencia")
            'LbVig.Text = ""
        End If

        'Dim e As Entidad = New Entidad
        Me.LbEntidad.Text = "<B>DEPARTAMENTO DEL CESAR</B>"

        Context.Request.Browser.Adapters.Clear()
    End Sub

    
    Protected Sub LoginStatus1_LoggingOut(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.LoginCancelEventArgs) Handles LoginStatus1.LoggingOut
        FormsAuthentication.SignOut()
        Context.User = Nothing
        Session.Abandon()
        Session.Clear()
        'FormsAuthentication.RedirectToLoginPage()

    End Sub

    Protected Sub LoginStatus1_LoggedOut(ByVal sender As Object, ByVal e As System.EventArgs) Handles LoginStatus1.LoggedOut
        FormsAuthentication.SignOut()
        Context.User = Nothing
        Session.Abandon()
        Session.Clear()
        'Response.Redirect(ConfigurationManager.AppSettings("VIRTUAL") + "/publico/logout.aspx")
        Response.Redirect("~/publico/logout.aspx")
    End Sub

    Protected Sub BtnCerrar_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles BtnCerrar.Click
        Response.Redirect("~/default.aspx")
    End Sub
End Class

