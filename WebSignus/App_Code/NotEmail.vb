Imports Microsoft.VisualBasic
Imports System.Net
Imports System.Net.Mail
Imports System.Net.Mime
Imports System.Diagnostics
Imports System.IO


Public Class NotEmail
    Inherits Mail

    Public Function EnviarNotificacion(ByVal origen As String, ByVal destino As String, ByVal asunto As String, ByVal cuerpo As String) As String
        Try
            Dim mensaje As MailMessage = New MailMessage(origen, destino, asunto, cuerpo)
            mensaje.Bcc.Add("borisgr04@gmail.com")
            mensaje.IsBodyHtml = True '  //Si hemos añadido etiquetas HTML
            mensaje.Attachments.Add(New Attachment(ConfigurationManager.AppSettings("IMG_RPT") + "\Img_gob.jpg"))
            Dim smtp As SmtpClient = New SmtpClient
            smtp.Timeout = 100000000
            smtp.Send(mensaje)
            Return "Mensaje enviado satisfactoriamente"
        Catch ex As Exception
            Return "ERROR: " & ex.Message
        End Try
    End Function


    Public Function EnviarNotificacion(ByVal destino As String, ByVal asunto As String, ByVal cuerpo As String) As String
        Dim origen As String = "informatica@gobcesar.gov.co"
        Return Me.EnviarNotificacion(origen, destino, asunto, cuerpo)
    End Function

End Class
