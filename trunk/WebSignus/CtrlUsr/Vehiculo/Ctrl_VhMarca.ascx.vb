
Partial Class CtrlUsr_Vehiculo_Ctrl_VhMarca
    Inherits System.Web.UI.UserControl
    Public Event SelClicked As EventHandler
    Public ReadOnly Property NomMarca() As String
        Get
            Return gvMarcas.SelectedRow.Cells(0).Text
        End Get
    End Property
    Public ReadOnly Property IdMarca() As String
        Get
            Return gvMarcas.SelectedValue
        End Get
    End Property
    Public Property Transaccion() As String
        Get
            Return hfTransaccion.Value
        End Get
        Set(ByVal value As String)
            hfTransaccion.Value = Transaccion
        End Set
    End Property

    Protected Sub btGuardar_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btGuardar.Click
        Dim oMarca As New Vh_Marca
        Select Case hfTransaccion.Value
            Case "N"
                oMarca.Insert(tbNomMarca.Text)
            Case "U"
                oMarca.Update(tbNomMarcaOld.Text, tbNomMarca.Text)
        End Select
        msg.Text = oMarca.Msg
        If oMarca.lErrorG Then
            msg.CssClass = "error"
        Else
            msg.CssClass = "exito"
        End If
        gvMarcas.DataBind()
        MultiView1.ActiveViewIndex = 1
    End Sub

    Protected Sub btNuevo_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btNuevo.Click
        hfTransaccion.Value = "N"
        MultiView1.ActiveViewIndex = 0
        lbEstado.Text = "Creando Marca"
    End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            MultiView1.ActiveViewIndex = 1
        End If
    End Sub

    Protected Sub btCancelar_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btCancelar.Click
        MultiView1.ActiveViewIndex = 1
    End Sub

    Protected Sub gvMarcas_RowCommand(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewCommandEventArgs) Handles gvMarcas.RowCommand
        Select Case e.CommandName
            Case "Editar"
                Dim index As Integer = Convert.ToInt32(e.CommandArgument)
                gvMarcas.SelectedIndex = index
                tbNomMarca.Text = gvMarcas.SelectedRow.Cells(0).Text
                tbNomMarcaOld.Text = gvMarcas.SelectedRow.Cells(0).Text
                lbEstado.Text = "Actualizando Marca"
                hfTransaccion.Value = "U"
                MultiView1.ActiveViewIndex = 0
        End Select
    End Sub
    Protected Overridable Sub Onclick(ByVal sender As Object)
        RaiseEvent SelClicked(sender, New EventArgs)
    End Sub

    Protected Sub gvMarcas_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles gvMarcas.SelectedIndexChanged
        Onclick(sender)
    End Sub
End Class
