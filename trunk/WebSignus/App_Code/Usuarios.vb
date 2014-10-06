Imports Microsoft.VisualBasic
Imports System.Data
Imports System.ComponentModel
Imports System.Web.Security
Imports System.Configuration
Imports System
Imports Signus

Public Class Usuarios
    Inherits BDDatos2
    Public Sub New()

        Me.Tabla = "ORA_ASPNET_USERS"
        Me.Vista = "ORA_ASPNET_USERS"

    End Sub

    Public Overloads Function GetAllUsers() As MembershipUserCollection
        Return (Membership.GetAllUsers())
    End Function


    Public Function Update(ByVal user As String, ByVal correo As String) As String
        Me.lErrorG = True
        Dim un As String = Membership.GetUserNameByEmail(correo)
        If Not String.IsNullOrEmpty(un) Then
            If UCase(un) <> UCase(user) Then
                Msg = "Error. EL Correo esta registrado a nombre de Otro Usuario:" + un
            Else
                Msg = "No realizó cambiado la dirección de Correo Electrónico"
            End If

            Return Msg
        End If
        Try
            Dim u As MembershipUser = Membership.GetUser(user)
            u.Email = correo
            Membership.UpdateUser(u)

            If correo = Membership.GetUser(user).Email Then
                Msg = Me.MsgOk
                Me.lErrorG = False
            Else
                Msg = "Error: No se actualizó el correo electrónico "
                Me.lErrorG = True
            End If
        Catch e As System.Configuration.Provider.ProviderException
            Me.lErrorG = True
            Msg = e.Message
        End Try
        Return Msg
    End Function

    Public Overloads Function Insertar(ByVal username As String, ByVal password As String, ByVal email As String, ByVal question As String, ByVal answer As String) As String

        Dim isApproved As Boolean = True
        Dim status As MembershipCreateStatus
        Dim oTer As Terceros = New Terceros
        If oTer.GetByIde(username).Rows.Count = 0 Then
            Msg = "El Usuario debe ser un Tercero del Sistema"
            Me.lErrorG = True
        Else
            Try
                Dim usuario As MembershipUser = Membership.CreateUser(username, password, email, question, answer, isApproved, status)

                Me.lErrorG = True
                Msg = "Error:"
                Select Case status
                    Case MembershipCreateStatus.DuplicateEmail
                        Msg = Msg + "Correo Eléctronico Duplicado"
                    Case MembershipCreateStatus.DuplicateProviderUserKey
                        Msg = Msg + "Duplicado User Key"
                    Case MembershipCreateStatus.DuplicateUserName
                        Msg = Msg + "Duplicado Nombre de Usuario (Username)"
                    Case MembershipCreateStatus.InvalidAnswer
                        Msg = Msg + "Respuesta Inválida"
                    Case MembershipCreateStatus.InvalidEmail
                        Msg = Msg + "Correo Electrónico Inválido"
                    Case MembershipCreateStatus.InvalidPassword
                        Msg = Msg + "Contraseña Inválida"
                    Case MembershipCreateStatus.InvalidProviderUserKey
                        Msg = Msg + "Provider User Key Inválido "
                    Case MembershipCreateStatus.InvalidQuestion
                        Msg = Msg + "Pregunta Iválida"
                    Case MembershipCreateStatus.InvalidUserName
                        Msg = Msg + "Nombre de Usuario (Username) Inválido"
                    Case MembershipCreateStatus.ProviderError
                        Msg = Msg + "Nombre de Usuario (Username) Inválido"
                    Case MembershipCreateStatus.Success
                        Me.lErrorG = False
                        Dim usuarioID As String = usuario.ProviderUserKey.ToString
                        Msg = AddUserExt(username)
                        If Me.lErrorG = False Then
                            Msg = "Se creo el Usuario ID [" + usuarioID + "]"
                        Else
                            Membership.DeleteUser(username)
                        End If
                    Case MembershipCreateStatus.UserRejected
                        Msg = Msg + "Error: UserRejected en el Proveedor"
                End Select
            Catch ex As MembershipCreateUserException
                Msg = Msg + ex.Message
            End Try
        End If
        Return Msg
    End Function
    Public Overloads Function Insertar(ByVal username As String, ByVal password As String) As String

        Dim isApproved As Boolean = True
        Dim status As MembershipCreateStatus
        Dim oTer As Terceros = New Terceros
        If oTer.GetByIde(username).Rows.Count = 0 Then
            Msg = "El Usuario debe ser un Tercero del Sistema"
            Me.lErrorG = True
        Else
            Try

                Dim usuario As MembershipUser = Membership.CreateUser(username, password)

                Me.lErrorG = True
                Msg = "Error:"
                Select Case status
                    Case MembershipCreateStatus.DuplicateEmail
                        Msg = Msg + "Correo Eléctronico Duplicado"
                    Case MembershipCreateStatus.DuplicateProviderUserKey
                        Msg = Msg + "Duplicado User Key"
                    Case MembershipCreateStatus.DuplicateUserName
                        Msg = Msg + "Duplicado Nombre de Usuario (Username)"
                    Case MembershipCreateStatus.InvalidAnswer
                        Msg = Msg + "Respuesta Inválida"
                    Case MembershipCreateStatus.InvalidEmail
                        Msg = Msg + "Correo Electrónico Inválido"
                    Case MembershipCreateStatus.InvalidPassword
                        Msg = Msg + "Contraseña Inválida"
                    Case MembershipCreateStatus.InvalidProviderUserKey
                        Msg = Msg + "Provider User Key Inválido "
                    Case MembershipCreateStatus.InvalidQuestion
                        Msg = Msg + "Pregunta Iválida"
                    Case MembershipCreateStatus.InvalidUserName
                        Msg = Msg + "Nombre de Usuario (Username) Inválido"
                    Case MembershipCreateStatus.ProviderError
                        Msg = Msg + "Nombre de Usuario (Username) Inválido"
                    Case MembershipCreateStatus.Success
                        Me.lErrorG = False
                        Dim usuarioID As String = usuario.ProviderUserKey.ToString
                        Msg = AddUserExt(username)
                        If Me.lErrorG = False Then
                            Msg = "Se creo el Usuario ID [" + username + "]"
                        Else
                            Membership.DeleteUser(username)
                        End If
                    Case MembershipCreateStatus.UserRejected
                        Msg = Msg + "Error: UserRejected en el Proveedor"
                End Select
            Catch ex As MembershipCreateUserException
                Msg = Msg + ex.Message
            End Try
        End If
        Return Msg
    End Function

    Public Function AddUserExt(ByVal username As String) As String
        Me.Conectar()
        'ComenzarTransaccion()
        Try
            querystring = "INSERT INTO USEREXT (username) VALUES(:username)"
            CrearComando(querystring)
            AsignarParametroCadena(":username", username)
            EjecutarComando()
            'ConfirmarTransaccion()
        Catch ex As Exception
            Msg = ex.Message
            lErrorG = True
            'CancelarTransaccion()
        End Try
        Me.Desconectar()
        Return Msg
    End Function

    Public Function AsigPerfil(ByVal username As String, ByVal Perfil As String) As String
        Me.Conectar()
        
        Try
            Me.querystring = "UPDATE USEREXT SET perfil=:username WHERE username=:username"
            CrearComando(querystring)
            'dbCommand.Parameters.Add("perfil", Perfil)
            AsignarParametroCadena("username", username)

            Dim queryString2 As String = "INSERT INTO MENU_PERFIL (SELECT APPLICATIONID,MENUID,:UserName,:Tipo_User FROM MENU_PERFIL WHERE PERFIL=:PERFIL AND TIPO_PER='P')"
            CrearComando(queryString2)
            AsignarParametroCadena("perfil", Perfil)
            AsignarParametroCadena("UserName", username)
            AsignarParametroCadena("Tipo_User", "U")
            EjecutarComando()
            ConfirmarTransaccion()
        Catch ex As Exception
            Msg = ex.Message
            lErrorG = True
            CancelarTransaccion()
        End Try
        Me.Desconectar()
        Return Msg

    End Function
    Public Function AsigPerfil0(ByVal username As String, ByVal Perfil As String) As String
        Me.Conectar()
        
        Try
            ComenzarTransaccion()
            Me.querystring = "UPDATE USEREXT SET perfil=:username WHERE username=:username"
            CrearComando(querystring)
            'dbCommand.Parameters.Add("perfil", Perfil)
            AsignarParametroCadena("username", username)
            EjecutarComando()
            Me.querystring = "INSERT INTO MENU_PERFIL (SELECT APPLICATIONID,MENUID,:UserName,:Tipo_User FROM MENU_PERFIL WHERE PERFIL=:PERFIL AND TIPO_PER='P')"
            CrearComando(querystring)
            AsignarParametroCadena("perfil", Perfil)
            AsignarParametroCadena("UserName", username)
            AsignarParametroCadena("Tipo_User", "U")
            EjecutarComando()
            ConfirmarTransaccion()
        Catch ex As Exception
            Msg = ex.Message
            lErrorG = True
            CancelarTransaccion()
        End Try
        Me.Desconectar()
        Return Msg
    End Function
    Public Function GetPerfil(ByVal username As String) As String
        Me.Conectar()
        Me.querystring = "select perfil from userext where username=:username"
        CrearComando(querystring)
        AsignarParametroCadena("username", LCase(username))
        Dim Perfil As String = ""
        Perfil = Convert.ToString(EjecutarEscalar())
        Me.Desconectar()
        Return Perfil

    End Function

    '<DataObjectMethodAttribute(DataObjectMethodType.Select, True)> _
    Public Overloads Function GetRecords(ByVal Busc As String) As DataTable

        Me.Conectar()

        Me.querystring = "SELECT * FROM ORA_VW_ASPNET_MEMUSERS m left Join vterceros t On t.TER_NIT=m.USERNAME WHERE (username like '%" + Busc + "%')OR( Upper(Ter_Nom) like '%" + UCase(Busc) + "%')"
        CrearComando(querystring)
        Dim dataTb As DataTable = EjecutarConsultaDataTable()
        Me.Desconectar()
        Return dataTb

    End Function

    Public Shared Function IsUser(ByVal Username As String) As Boolean
        'Dim user  Membership.GetUser(
        Dim u As MembershipUser = Membership.GetUser(Username)
        If Not (u Is Nothing) Then
            Return True
        Else
            Return False
        End If

    End Function

    Public Function Forzar_Cambio_Clave(ByVal Usuario As String, ByVal Nueva_Clave As String) As String
        Try
            '830514235
            Dim u As MembershipUser = Membership.GetUser(Usuario)
            If Not (u Is Nothing) Then
                Dim rst As String = Membership.GetUser(Usuario).ResetPassword
                Membership.GetUser(Usuario).ChangePassword(rst, Nueva_Clave)
                Msg = "Se actualizó Correctamente"
                lErrorG = False
            Else
                Msg = "El " + Usuario + " No esta relacionado como Usuario"
                lErrorG = True
            End If
        Catch ex As Exception
            Msg = "Error de App:" + ex.Message
            lErrorG = True
        Finally

        End Try

        Return Msg
    End Function

    Public Function GenUsuariosAR() As String
        Dim msgr As String = ""
        'Cargar Agentes Sin Usuario
        Dim oTer As Terceros = New Terceros
        Dim vigencia As New Vigencias
        Dim dt As DataTable = oTer.GetAgentesSinUsuario()
        'Vigencia Activa
        Dim Vig As String = vigencia.GetVigenciaA()
        'Caracter de seguridad
        Dim Ctr_Clave As String = ConfigurationManager.AppSettings("CTR_CLAVE")
        Dim USERXCLICK As String = CInt(ConfigurationManager.AppSettings("USERXCLICK"))
        Ctr_Clave = "."
        'Objeto de Email
        Dim oMail As CorreosE = New CorreosE
        Dim clave As String
        Dim username As String
        'Objeto Menu, para asignar los permisos
        Dim objPer As DBMenu = New DBMenu
        Dim Hasta As Long
        Dim msg As String
        If USERXCLICK = -1 Then
            Hasta = dt.Rows.Count - 1
        Else
            Hasta = IIf(USERXCLICK > dt.Rows.Count, dt.Rows.Count - 1, USERXCLICK - 1)
        End If
        If Hasta = -1 Then
            msg = "No hay Usuarios por generar"
            lErrorG = True
            Return msg
        End If


        For i As Integer = 0 To Hasta '
            clave = dt.Rows(i)("Ter_Usu").ToString + Ctr_Clave
            username = dt.Rows(i)("Ter_Usu").ToString
            msg = Me.Insertar(username, clave)
            If Me.lErrorG = False Then
                msg += objPer.AsigPerfilUser("AGENTESR", username)
                If objPer.lErrorG = False Then
                    msg = "Se creó el Usuario <b><i>" + username + "</i></b> Clave Generada <b>" + clave + "</b> Se Asignaron Permisos de Agente Recaudador <br>" + dt.Rows(i)("Ter_nom").ToString
                End If
                If Len(Trim(dt.Rows(i)("Ter_emai").ToString)) > 0 Then
                    msg += "<br>" + oMail.Enviar_Correo_Rst(username, clave)
                Else
                    msg += "<br>No tiene Correo Electrónico Regsitrado"
                End If
            End If
            msgr += "<li>" + msg + "</li>"
        Next

        msgr += " Número Total de usuarios creados " + (Hasta + 1).ToString
        Return msgr
    End Function
    Public Shared Function Desbloquear(ByVal username As String) As Boolean
        Return Membership.GetUser(username).UnlockUser()
    End Function
    Public Shared Function Turn_Activar(ByVal username As String) As Boolean
        Try
            Dim usr As MembershipUser = Membership.GetUser(username)
            usr.IsApproved = Not usr.IsApproved
            Membership.UpdateUser(usr)
            Return True
        Catch ex As Exception
            Return False
        End Try
        
    End Function
End Class



