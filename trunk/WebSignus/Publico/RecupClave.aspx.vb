Imports System.Data
Imports Signus

Partial Class Publico_RecupClave
    Inherits System.Web.UI.Page
    Dim objt As Terceros = New Terceros
    Dim dt As DataTable
    Dim msg As String

    Protected Sub Button1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button1.Click
        Try
            Dim u As String = Me.TxtUser.Text
            dt = objt.GetByUser(u)
            If dt.Rows.Count > 0 Then
                Dim rst As String = Membership.GetUser(u).ResetPassword
                Dim MsgMail As NotEmail = New NotEmail
                'Dim cuerpo As String = String.Format("Usuario <b>{0}</b> <br>Contraseña <b>{1}</b>", u, rst)
                Dim Cuerpo As String = Me.Cargar_Plantilla(u, rst)
                msg = msgmail.EnviarNotificacion(dt.Rows(0)("ter_emai").ToString, ConfigurationManager.AppSettings("NOMAPP") + Me.Tit.Text, cuerpo)
                Me.LMSgBox.Text = "El Sistema envió nueva contraseña de forma automático, a su Correo Electrónico de Notificaciones"
                'Me.LMSgBox.CssClass = "Ok"
                'Membership.GetUser(u).ChangePassword(rst, Me.Tcont.Text)
            Else
                Me.LMSgBox.Text = "Usuario no registrado en el Sistema"
                'Me.LMSgBox.CssClass = "NotOk"
            End If
        Catch exo As Exception
            Me.LMSgBox.Text = "Error de Datos:" + exo.Message
            'Me.LMSgBox.CssClass = "NotOK"
        Finally

        End Try
    End Sub

    Public Function Cargar_Plantilla(ByVal u As String, ByVal rst As String) As String
        Dim obj As CorreosE = New CorreosE
        Dim dtc As DataTable = obj.GetPorNom("resclave")
        Dim m As String = ""
        If dtc.Rows.Count > 0 Then
            m = dtc.Rows(0)("Corr_Body").ToString
            m = m.Replace("{fecha}", Now.ToLongDateString)
            m = m.Replace("{agente}", dt.Rows(0)("ter_nom").ToString)
            m = m.Replace("{usuario}", u)
            m = m.Replace("{password}", rst)
            m = m.Replace("{fechahora}", CStr(Now))
        End If
        Return m
    End Function




    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Me.Title = Me.Tit.Text
    End Sub

End Class
