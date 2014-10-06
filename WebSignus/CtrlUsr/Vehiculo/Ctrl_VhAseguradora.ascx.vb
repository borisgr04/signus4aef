
Partial Class CtrlUsr_Vehiculo_Ctrl_VhAseguradora
    Inherits System.Web.UI.UserControl
    Public Event SelClicked As EventHandler
    Public ReadOnly Property NomAseguradora() As String
        Get
            Return gvConsulta.SelectedRow.Cells(1).Text
        End Get
    End Property
    Public ReadOnly Property CodAseguradora() As String
        Get
            Return gvConsulta.SelectedRow.Cells(0).Text
        End Get
    End Property
    Public ReadOnly Property EstadoAseguradora() As String
        Get
            Return gvConsulta.SelectedRow.Cells(2).Text
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
        Dim oAseg As New Vh_Aseguradora
        Select Case hfTransaccion.Value
            Case "N"
                oAseg.Insert(tbCodigo.Text, tbNomAseguradora.Text, cmbEstado.SelectedValue)
            Case "U"
                oAseg.Update(tbCodigo.Text, tbNomAseguradora.Text, cmbEstado.SelectedValue)
        End Select
        msg.Text = oAseg.Msg
        If oAseg.lErrorG Then
            msg.CssClass = "error"
        Else
            msg.CssClass = "exito"
        End If
        gvConsulta.DataBind()
        MultiView1.ActiveViewIndex = 1
    End Sub

    Protected Sub btNuevo_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btNuevo.Click
        hfTransaccion.Value = "N"
        tbCodigo.Enabled = True
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
                tbCodigo.Enabled = False
                tbCodigo.Text = gvConsulta.SelectedRow.Cells(0).Text
                tbNomAseguradora.Text = gvConsulta.SelectedRow.Cells(1).Text
                cmbEstado.SelectedValue = tbCodigo.Text = gvConsulta.SelectedRow.Cells(2).Text
                lbEstado.Text = "Actualizando Aseguradora"
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
