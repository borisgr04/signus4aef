<%@ Application Language="VB" %>
<%@ Import Namespace="System.Diagnostics" %>
<script runat="server">

    Sub Application_Start(ByVal sender As Object, ByVal e As EventArgs)
        Dim m As Menudatos = New Menudatos
        Try
            Dim mc As MembershipUserCollection = Membership.FindUsersByName("admin")
            If mc.Count = 0 Then
                Membership.CreateUser("admin", "signus2011.")
                Mail.EnviarAuto("Creación de Usuario Inicial:" + Now.ToLongTimeString, "admin")
            End If
        Catch ex As Exception

        End Try
        m.GenerarRoles()
            
    End Sub
    
    
     
    Protected Sub Session_End(ByVal sender As Object, ByVal e As EventArgs)
        'FormsAuthentication.SignOut()
        Context.User = Nothing
        Session.Abandon()
        Session.Clear()
    End Sub


    
    Private Sub Application_Error(ByVal sender As Object, ByVal e As EventArgs)
        'Dim ex As Exception = Server.GetLastError().GetBaseException()
        'EventLog.WriteEntry("Test Web", "MESSAGE: " + ex.Message + "\nSOURCE: " + ex.Source + "\nFORM: " + Request.Form.ToString() + "\nQUERYSTRING: " + Request.QueryString.ToString() + "\nTARGETSITE: " + ex.TargetSite + "\nSTACKTRACE: " + ex.StackTrace, EventLogEntryType.Error)
        Dim objErr As Exception = Server.GetLastError().GetBaseException()
        Dim Err As String = "Errores Capturados en el Evento Application_Error " & _
                            System.Environment.NewLine & _
                            "Url de Error : " & Request.Url.ToString() & _
                            System.Environment.NewLine & _
                            "Mensaje de Error: " & objErr.Message.ToString() & _
                            System.Environment.NewLine & _
                            "Seguimiento de la Pila:" & objErr.StackTrace.ToString()
        'Mail.EnviarAuto("Error:[" + Membership.GetUser.UserName + "]" + Now.ToLongTimeString, Err)
        
        'EventLog.WriteEntry("Signus", Err, EventLogEntryType.Error)
        'Session("LastError") = err
      
        
        
        
    End Sub
       
</script>