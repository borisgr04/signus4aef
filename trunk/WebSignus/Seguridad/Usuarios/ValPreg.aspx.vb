Imports System.Data
Partial Class Seguridad_Usuarios_ValPreg
    Inherits PaginaComun

    Protected Sub Button1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button1.Click
        'Me.Label1.Text = Membership.GetUser(Me.TextBox4.Text).GetPassword()
        'Me.TextBox5.Text = Membership.GetUserNameByEmail("borisgr04")

        Dim msgmail As NotEmail = New NotEmail
        Me.Label1.Text = msgmail.EnviarNotificacion(Me.TxtDes.Text, Me.TxtAsunto.Text, Me.Msg.Text)

    End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        Dim obj As CorreosE = New CorreosE
        Dim dt As DataTable = obj.GetRecords()
        Dim m As String = dt.Rows(1)("CORR_BODY").ToString
        m = m.Replace("{fecha}", Now.ToLongDateString)
        m = m.Replace("{agente}", "Hospital")
        m = m.Replace("{impuestos}", "Estampillas, Registro, Degüello")
        m = m.Replace("{fecha_inicio}", Now.ToLongDateString)
        m = m.Replace("{nit}", "12345-1")
        m = m.Replace("{password}", "12345-1")
        m = m.Replace("{fechahora}", CStr(Now))

        Me.Msg.Text = m
    End Sub
End Class

