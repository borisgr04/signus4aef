Imports System.Data
Imports Signus

Partial Class Seguridad_GenUserAR_ARSinUsuario
    Inherits PaginaComun

    Protected Sub GridView1_RowCommand(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewCommandEventArgs)

    End Sub

    Protected Sub GridView1_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs)

    End Sub

    Protected Sub GridView1_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs)

    End Sub

    Protected Sub BtnCrearUsua_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnCrearUsua.Click
        'Me.MsgResult.Text = "Presiono Boton Generar Usuarios"
        CrearUsua2()
    End Sub
    Protected Sub CrearUsua2()
        Dim oUsu As Usuarios = New Usuarios
        Me.MsgResult.Text = oUsu.GenUsuariosAR()
        'MsgBox(MsgResult, oUsu.lErrorG)
        Me.actualizar_grid()
    End Sub
    Protected Sub CrearUsua1()
        Dim obj As Terceros = New Terceros
        Dim dt As DataTable = obj.GetAgentesSinUsuario()
        Dim oUsu As Usuarios = New Usuarios
        Dim oVig As New Vigencias
        Dim Vig As String = oVig.GetVigenciaA()
        Dim clave As String
        Dim caracter As String = "!"
        Dim username As String
        Me.MsgResult.Text = ""
        Dim objPer As DBMenu = New DBMenu
        Dim msg As String
        'dt.Rows.Count - 1
        For i As Integer = 0 To 10
            clave = dt.Rows(i)("Ter_Usu").ToString '+ caracter + Vig
            username = dt.Rows(i)("Ter_Usu").ToString
            msg = oUsu.Insertar(username, clave)
            If oUsu.lErrorG = False Then
                msg += objPer.AsigPerfilUser("AGENTESR", username)
                If objPer.lErrorG = False Then
                    msg = "Se creó el Usuario <b><i>" + username + "</i></b> Clave Generada <b>" + clave + "</b> Se Asignaron Permisos de Agente Recaudador"
                End If
            End If
            Me.MsgResult.Text += "<li>" + msg + "</li>"
            'Me.UpdatePanel1.Update()
            'Threading.Thread.Sleep(1000)

        Next
        Me.actualizar_grid()
    End Sub

    Protected Sub BtnPag_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        Me.MsgResult.Text = Me.TxtPag.Text
        If Val(Me.TxtPag.Text) = -1 Then
            Me.GridView1.AllowPaging = False
        Else
            Me.GridView1.AllowPaging = True
            Me.GridView1.PageSize = Me.TxtPag.Text
        End If
        Me.actualizar_grid()
    End Sub

    Sub actualizar_grid()
        Me.GridView1.DataBind()

    End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Me.actualizar_grid()
        Me.Opcion = Me.Tit.Text
        Me.SetTitulo()
    End Sub
End Class
