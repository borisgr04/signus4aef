Imports Microsoft.VisualBasic
Imports Signus
Imports System.Data

Public Class RolesAR
    Dim BD As BDDatos2 = New BDDatos2()
    Property Msg As String = ""

    Public Function AsignarRolToAR(Rol As String) As String
        Dim msgr As String = ""
        'Cargar Agentes Sin Usuario
        Dim oTer As Terceros = New Terceros

        Dim dt As DataTable = oTer.GetAgentes()
        Dim username As String

        For Each dtrow In dt.Rows
            username = dtrow("Ter_Nit").ToString
            If Not Roles.IsUserInRole(username, Rol) Then
                Roles.AddUserToRole(username, Rol)
                Msg += "Se Asignó al Usuario <b><i>" + username + "</i></b> El Rol <b>" + Rol + "</b></br>"
            End If
        Next

        Return msgr
    End Function

End Class
