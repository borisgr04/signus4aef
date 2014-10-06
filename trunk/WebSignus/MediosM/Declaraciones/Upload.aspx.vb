
Partial Class MediosM_Declaraciones_Upload
    Inherits System.Web.UI.Page

    Protected Sub btnDate1_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        '    //Doing a fake delay for 3 seconds
        System.Threading.Thread.Sleep(3000)
        lblDate1.Text = DateTime.Now.ToString()
    End Sub

    Protected Sub btnDate2_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnDate2.Click

    End Sub


    <Services.WebMethod()> Public Function GetDate() As String
        'Doing a fake delay for 3 seconds
        System.Threading.Thread.Sleep(3000)

        Return DateTime.Now.ToString()
    End Function

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        If (Not IsPostBack) Then
            lblDate1.Text = lblDate2.Text = DateTime.Now.ToString()
        End If
    End Sub

    

End Class
