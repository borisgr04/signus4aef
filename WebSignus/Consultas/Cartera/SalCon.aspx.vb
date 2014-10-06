Imports System.IO
Imports System.Data

Partial Class Consultas_Cartera_SalCon
    Inherits PaginaComun

    Protected Sub BtnExcel_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        Me.ExportGridView(Me.grConc, "Saldos_Por_Concepto.xls")
    End Sub

    Private Sub ExportGridView2()


        Dim attachment As String = "attachment; filename=Contacts.xls"

        Response.ClearContent()

        Response.AddHeader("content-disposition", attachment)

        Response.ContentType = "application/ms-excel"

        Dim sw As New StringWriter()

        Dim htw As New HtmlTextWriter(sw)


        Me.grConc.RenderControl(htw)

        Response.Write(sw.ToString())


        Response.End()
    End Sub
    Public Overrides Sub VerifyRenderingInServerForm(ByVal control As Control)

    End Sub


    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Me.Opcion = Me.LBTITULO.Text
        Me.SetTitulo()

    End Sub
End Class
