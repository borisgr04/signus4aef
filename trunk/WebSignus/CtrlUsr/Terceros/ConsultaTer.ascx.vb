
Partial Class CtrlUsr_ConsultaTer
    Inherits System.Web.UI.UserControl
    Dim sTipo As String
    Property TextoBusqueda() As String
        Get
            Return TxtFilNom.Text
        End Get
        Set(ByVal value As String)
            TxtFilNom.Text = value
        End Set
    End Property
    'Dim sRet As String
    Property Ret() As String
        Get
            Return Me.HiddenField1.Value
        End Get
        Set(ByVal value As String)
            Me.HiddenField1.Value = value
        End Set
    End Property
    Property Tipo() As String
        Get
            Return Me.HiddenField1.Value
        End Get
        Set(ByVal value As String)
            sTipo = value
            Me.HiddenField1.Value = Me.Tipo
        End Set
    End Property
    Protected Sub BtnBuscar_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles BtnBuscar.Click

    End Sub

    Protected Sub GridView1_RowCommand(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewCommandEventArgs)
        If e.CommandName = "Seleccionar" Then
            Dim index As Integer = Convert.ToInt32(e.CommandArgument)
            Me.GridView1.SelectedIndex = index
        End If
    End Sub

    Protected Sub GridView1_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs)

    End Sub

    Protected Sub GridView1_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs)

    End Sub

    Protected Sub Page_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Init
        'Page.SetFocus(TxtFilNom)
    End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not Me.IsPostBack Then
            Me.HiddenField1.Value = Me.Tipo
        End If

    End Sub
End Class
