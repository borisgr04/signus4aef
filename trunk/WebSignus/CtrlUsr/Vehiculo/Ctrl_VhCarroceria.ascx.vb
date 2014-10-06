
Partial Class CtrlUsr_Vehiculo_Ctrl_VhCarroceria
    Inherits System.Web.UI.UserControl
    Public Event SelClicked As EventHandler
    Public ReadOnly Property NomCarroceria() As String
        Get
            Return gvConsulta.SelectedRow.Cells(0).Text
        End Get
    End Property
    Public ReadOnly Property IdCarroceria() As String
        Get
            Return gvConsulta.SelectedValue
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
        Dim oCarroceria As New Vh_Carroceria
        Select Case hfTransaccion.Value
            Case "N"
                oCarroceria.Insert(tbNomCarroceria.Text)
            Case "U"
                oCarroceria.Update(tbNomCarroceriaOld.Text, tbNomCarroceria.Text)
        End Select
        msg.Text = oCarroceria.Msg
        If oCarroceria.lErrorG Then
            msg.CssClass = "error"
        Else
            msg.CssClass = "exito"
        End If
        gvConsulta.DataBind()
        MultiView1.ActiveViewIndex = 1
    End Sub

    Protected Sub btNuevo_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btNuevo.Click
        hfTransaccion.Value = "N"
        MultiView1.ActiveViewIndex = 0
        lbEstado.Text = "Creando Carroceria"
    End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            MultiView1.ActiveViewIndex = 1
        End If
    End Sub

    Protected Sub btCancelar_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btCancelar.Click
        MultiView1.ActiveViewIndex = 1
    End Sub

    Protected Sub gvConsulta_RowCommand(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewCommandEventArgs) Handles gvConsulta.RowCommand
        Select Case e.CommandName
            Case "Editar"
                Dim index As Integer = Convert.ToInt32(e.CommandArgument)
                gvConsulta.SelectedIndex = index
                tbNomCarroceriaOld.Text = gvConsulta.SelectedRow.Cells(0).Text
                lbEstado.Text = "Actualizando Carroceria"
                hfTransaccion.Value = "U"
                MultiView1.ActiveViewIndex = 0
        End Select
    End Sub
    Protected Overridable Sub Onclick(ByVal sender As Object)
        RaiseEvent SelClicked(sender, New EventArgs)
    End Sub

    Protected Sub gvConsulta_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles gvConsulta.SelectedIndexChanged
        Onclick(sender)
    End Sub
End Class
