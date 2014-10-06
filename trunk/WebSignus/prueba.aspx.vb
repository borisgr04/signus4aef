Imports System.Data


Partial Class prueba
    Inherits System.Web.UI.Page

    Protected Sub Button1_Click(sender As Object, e As System.EventArgs) Handles Button1.Click
        Dim p As New PruebaX
        GridView1.DataSource = p.ConsultaRef()
        GridView1.DataBind()
    End Sub

    
End Class
