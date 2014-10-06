Imports Microsoft.VisualBasic
Imports System.Data
Imports System.ComponentModel
Partial Class Seguridad_Usuarios_Cam_CambCont_us
    Inherits PaginaComun

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Me.Opcion = Me.Tit.Text
        Me.SetTitulo()
    End Sub

    Protected Sub BTfor_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BTfor.Click

        Dim obj As Usuarios = New Usuarios
        Me.LMSgBox.Text = obj.Forzar_Cambio_Clave(Me.Tus.Text, Me.Tcont.Text)
        Me.MsgBox1(Me.LMSgBox, obj.lErrorG)

    End Sub

  
End Class
