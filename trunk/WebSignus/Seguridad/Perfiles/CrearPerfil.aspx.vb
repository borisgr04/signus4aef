
Partial Class Seguridad_Perfiles_crearPerfil
    Inherits PaginaComun

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not Page.IsPostBack Then
            CargarElementos()
        End If
        Me.SetTitulo()

    End Sub
    Protected Sub CargarElementos()
        Dim objM As New DBMenu()
        objM.cargarElementos(Me.Tvw, "")
    End Sub

    Protected Sub BtnAgregar_Click(ByVal sender As Object, ByVal e As System.EventArgs)

        Dim obj As New DBMenu
        msgResult.Text = obj.AgregarPerfil(Me.Tvw, TxtNomPer.Text)
        If obj.lErrorG = True Then
            Me.msgResult.CssClass = "respuestaNotOk"
        Else
            Me.msgResult.CssClass = "respuestaOk"
        End If
        Me.MsgBox(Me.msgResult, obj.lErrorG)
    End Sub


End Class
