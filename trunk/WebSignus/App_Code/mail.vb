Imports Microsoft.VisualBasic
Imports System.Net
Imports System.Net.Mail
Imports System.Net.Mime
Imports System.Diagnostics
Imports System.IO
Public Class Mail
    Shared ReadOnly Property _MailSend() As String
        Get
            Return ConfigurationManager.AppSettings("MailSend").ToString
        End Get
    End Property

    Shared ReadOnly Property _MailAdmin() As String
        Get
            Return ConfigurationManager.AppSettings("MailAdmin").ToString
        End Get
    End Property

    Private Sub Enviar(ByVal ex As Exception)

        Dim origen As String = "direccion@origen-de-aplicacion.com"
        Dim destino As String = "correo@electronicodedestino.com"
        Dim titulo As String = "Error de ejecución"

        Dim cuerpo As String = "<h2>Informe de error</h2>Fecha-hora: " + DateTime.Now.ToString("dd/MM/yyyy – HH:mm:ss")

        cuerpo += "<h3>Mensaje</h3>" + ex.Message + "<h3>StackTrace:</h3>" + ex.StackTrace.ToString + "<h3>TargetSite:</h3>" + ex.TargetSite.ToString

        Dim mensaje As MailMessage = New MailMessage(origen, destino, titulo, cuerpo)
        mensaje.IsBodyHtml = True '  //Si hemos añadido etiquetas HTML
        Dim smtp As SmtpClient = New SmtpClient("mismtp.midireccion.com")

        smtp.Timeout = 6000
        smtp.Send(mensaje)

        'EventLog.WriteEntry("Test Web", "MESSAGE: " + ex.Message + "\nSOURCE: " + ex.Source + "\nFORM: " + Request.Form.ToString() + "\nQUERYSTRING: " + Request.QueryString.ToString() + "\nTARGETSITE: " + ex.TargetSite + "\nSTACKTRACE: " + ex.StackTrace, EventLogEntryType.Error)


    End Sub
    Protected Function Enviar2(ByVal origen As String, ByVal destino As String, ByVal asunto As String, ByVal cuerpo As String) As String

        'Dim origen As String = "direccion@origen-de-aplicacion.com"
        'Dim destino As String = "correo@electronicodedestino.com"
        'Dim titulo As String = "Error de ejecución"

        'Dim cuerpo As String = "<h2>Informe de error</h2>Fecha-hora: " + DateTime.Now.ToString("dd/MM/yyyy – HH:mm:ss")
        'cuerpo += "<h3>Mensaje</h3>" + ex.Message + "<h3>StackTrace:</h3>" + ex.StackTrace.ToString + "<h3>TargetSite:</h3>" + ex.TargetSite.ToString
        'Try
        Dim mensaje As MailMessage = New MailMessage(origen, destino, asunto, cuerpo)
        'mensaje.From = New MailAddress(origen)
        'mensaje.To.Add(New MailAddress(origen))
        'mensaje.Subject = asunto
        'mensaje.Body = cuerpo
        'mensaje.Attachments.Add( new Attachment(ruta))
        'Dim Fmto_cuerpo As String = String.Format("<html><body><img scr=""cid:logo""><h1>Valledupar {0} <br><br> ", DateTime.Now.ToString("dd/MM/yyyy – HH:mm:ss"))
        'Fmto_cuerpo += String.Format("<p> Alcaldia de La Paz, usted como agente recaudador debe ingresas a <a>http://www.goole.com</a> con las siguientes credenciales de autenticación<br>", 12345)
        'Fmto_cuerpo += String.Format("Usuario : Nit<br>", 12345)
        'Fmto_cuerpo += String.Format("Contraseña : Nit<br>", 12345)
        'Fmto_cuerpo += String.Format("Cualquier inquietud llamar a 5xxx xxx xxx <br></body></html>", 12345)
        'cuerpo = Fmto_cuerpo + cuerpo

        mensaje.IsBodyHtml = True '  //Si hemos añadido etiquetas HTML

        Dim VistaHtml As AlternateView = AlternateView.CreateAlternateViewFromString(cuerpo, Nothing, MediaTypeNames.Text.Html)
        'Dim logo As New LinkedResource("E:\x\DERWEB\images\Login\Img_gob_R.jpg", MediaTypeNames.Image.Jpeg)
        'logo.ContentId = "logo"
        'VistaHtml.LinkedResources.Add(logo)
        'mensaje.AlternateViews.Add(VistaHtml)
        mensaje.Attachments.Add(New Attachment("E:\x\DERWEB\images\Login\Img_gob.jpg"))

        'Dim smtp As SmtpClient = New SmtpClient("smtp.gmail.com", 465)
        Dim smtp As SmtpClient = New SmtpClient '("200.21.133.181")

        'smtp.Credentials = New System.Net.NetworkCredential("borisgr04@gmail.com", "anyamiyeth")
        'smtp.EnableSsl = True
        '("200.21.133.181")
        'smtp.Host = "smtp.gmail.com"
        'smtp.Port = "465"
        smtp.Timeout = 100000000
        smtp.Send(mensaje)
        Return "Mensaje enviado satisfactoriamente"
        'Catch ex As Exception
        'Return "ERROR: " & ex.Message
        'End Try



        'EventLog.WriteEntry("Test Web", "MESSAGE: " + ex.Message + "\nSOURCE: " + ex.Source + "\nFORM: " + Request.Form.ToString() + "\nQUERYSTRING: " + Request.QueryString.ToString() + "\nTARGETSITE: " + ex.TargetSite + "\nSTACKTRACE: " + ex.StackTrace, EventLogEntryType.Error)


    End Function

    Public Function Enviar(ByVal origen As String, ByVal destino As String, ByVal asunto As String, ByVal cuerpo As String) As String

        Try
            'Mensaje
            Dim mensaje As MailMessage = New MailMessage(origen, destino, asunto, cuerpo)
            'mensaje.Bcc="enviados@gobcesar.gov.co"
            mensaje.IsBodyHtml = True '  //Si hemos añadido etiquetas HTML
            mensaje.Attachments.Add(New Attachment(ConfigurationManager.AppSettings("IMG_RPT") + "\Img_gob.jpg"))
            mensaje.Priority = MailPriority.High
            'Servidor de Correo
            Dim smtp As SmtpClient = New SmtpClient
            smtp.Timeout = 100000000
            smtp.Send(mensaje)
            Return "Mensaje enviado satisfactoriamente"
        Catch ex As Exception
            Return "ERROR: " & ex.Message
        End Try


    End Function
    Public Shared Function EnviarAuto(ByVal asunto As String, ByVal cuerpo As String) As String
        Try
            Dim mensaje As MailMessage = New MailMessage(_MailSend, _MailAdmin, asunto, cuerpo)
            'mensaje.Bcc="enviados@gobcesar.gov.co"
            mensaje.IsBodyHtml = True '  //Si hemos añadido etiquetas HTML
            mensaje.Attachments.Add(New Attachment(ConfigurationManager.AppSettings("IMG_RPT") + "\Img_gob.jpg"))
            mensaje.Priority = MailPriority.High

            Dim smtp As SmtpClient = New SmtpClient
            smtp.Timeout = 100000000
            smtp.Send(mensaje)
            Return "Mensaje enviado satisfactoriamente"
        Catch ex As Exception
            Return "ERROR: " & ex.Message
        End Try


    End Function

End Class


