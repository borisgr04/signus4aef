Imports System.Data
Imports Signus

Partial Class CtrlUsr_Terceros_Con_Tercero
    Inherits System.Web.UI.UserControl
    Public Event SelClicked As EventHandler
    Dim sTipo As String
    Public ReadOnly Property Nit() As String
        Get
            Return gvConsulta.SelectedValue
        End Get
    End Property
    Public ReadOnly Property Nombre() As String
        Get
            Return HFNombre.Value
        End Get
    End Property
    Public ReadOnly Property Dv() As String
        Get
            Return HFDv.Value
        End Get
    End Property
    Public ReadOnly Property TipoDocumento() As String
        Get
            Return HFTipoDoc.Value
        End Get
    End Property
    Property TextoBusqueda() As String
        Get
            Return TxtFilNom.Text
        End Get
        Set(ByVal value As String)
            TxtFilNom.Text = value
        End Set
    End Property
    Property Ret() As String
        Get
            Return ViewState("RET")
        End Get
        Set(ByVal value As String)
            ViewState("RET") = value
        End Set
    End Property
    Property Tipo() As String
        Get
            Return Me.HiddenField1.Value
        End Get
        Set(ByVal value As String)
            sTipo = value
            Me.HiddenField1.Value = value
        End Set
    End Property
    Protected Sub gvConsulta_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles gvConsulta.SelectedIndexChanged
        Dim oTer As New Terceros
        Dim dtConsulta As New DataTable
        dtConsulta = oTer.GetByIde(gvConsulta.SelectedValue)
        If dtConsulta.Rows.Count > 0 Then
            HFNit.Value = dtConsulta.Rows(0)("TER_NIT").ToString
            HFNombre.Value = dtConsulta.Rows(0)("TER_NOM").ToString
            HFDv.Value = dtConsulta.Rows(0)("TER_DVER").ToString
            HFTipoDoc.Value = dtConsulta.Rows(0)("TER_TDOC").ToString
        End If
        Onclick(sender)
    End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not Me.IsPostBack Then
            'If String.IsNullOrEmpty(Me.Tipo) Then
            ' Me.Tipo = "AR"
            'End If
            Me.HiddenField1.Value = Me.Tipo
        End If
    End Sub
    Protected Overridable Sub Onclick(ByVal sender As Object)
        RaiseEvent SelClicked(sender, New EventArgs)
    End Sub
End Class
