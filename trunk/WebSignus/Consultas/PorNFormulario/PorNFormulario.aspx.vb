
Partial Class Consultas_PorNFormulario_PorNFormulario
    Inherits PaginaComun

    Protected Sub BtnBuscar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnBuscar.Click
        Me.CU_ConLiq1.NroLiq = TxtNLiq.Text
        Me.CU_ConLiq1.Buscar()

    End Sub

  
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Me.Opcion = Me.LBTITULO.Text
        Me.SetTitulo()
    End Sub
End Class
