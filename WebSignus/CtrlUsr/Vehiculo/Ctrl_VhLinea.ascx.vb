
Partial Class CtrlUsr_Vehiculo_Ctrl_VhLinea
    Inherits System.Web.UI.UserControl
    Public Event SelClicked As EventHandler
    Public ReadOnly Property NomLinea() As String
        Get
            Return gvConsulta.SelectedRow.Cells(0).Text
        End Get
    End Property
    Public ReadOnly Property IdLinea() As String
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
    Public Property IdMarca() As String
        Get
            Return hfIdMarca.Value
        End Get
        Set(ByVal value As String)
            hfIdMarca.Value = value
        End Set
    End Property

    Protected Sub btGuardar_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btGuardar.Click
        If String.IsNullOrEmpty(hfIdMarca.Value) Then
            msg.Text = "No se ha Escogido una Marca"
            msg.CssClass = "error"
        Else

            Dim oLinea As New Vh_Linea
            Select Case hfTransaccion.Value
                Case "N"
                    oLinea.Insert(tbNomLinea.Text, hfIdMarca.Value)
                Case "U"
                    oLinea.Update(tbNomLineaOld.Text, tbNomLinea.Text)
            End Select
            msg.Text = oLinea.Msg
            If oLinea.lErrorG Then
                msg.CssClass = "error"
            Else
                msg.CssClass = "exito"
            End If
            gvConsulta.DataBind()
            MultiView1.ActiveViewIndex = 1
        End If
    End Sub

    Protected Sub btNuevo_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btNuevo.Click
        hfTransaccion.Value = "N"
        MultiView1.ActiveViewIndex = 0
        lbEstado.Text = "Creando Linea"
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
                tbNomLinea.Text = gvConsulta.SelectedRow.Cells(0).Text
                tbNomLineaOld.Text = gvConsulta.SelectedRow.Cells(0).Text
                lbEstado.Text = "Actualizando Linea"
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
