
Partial Class Administración_Vigencia_Vigencia
    Inherits PaginaComun


    Protected Sub BtnCrear_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnCrear.Click
        Dim obj As New Vigencias
        MsgResult.Text = obj.Insert(Me.txtVig.Text.Trim)
        MsgResult.ForeColor = IIf(obj.lErrorG = True, Drawing.Color.Red, Drawing.Color.Blue)
        Me.DataBind()
        System.Threading.Thread.Sleep(2500)
    End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Me.Opcion = "Administrador de Vigencias"
        Me.SetTitulo()
    End Sub
End Class
