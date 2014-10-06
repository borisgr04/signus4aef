
Partial Class DatosBasicos_Formulaslt1_ProbarTarifa
    Inherits System.Web.UI.Page

    Protected Sub BtnAceptar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnAceptar.Click
        Dim Clase As String = TxtClaDec.Text
        Dim TipoAgente As String = TxtTipoAgente.Text
        Dim Tipo_Acto As String = TxtTipoActo.Text
        Dim Impuesto As String = TxtImpto.Text
        Dim fecha As Date = CDate(TxtFecha.Text)
        Dim objCd As New CDeclaraciones(Clase)
        Dim Input_par As String = objCd.GetParametrosTar(Clase, TipoAgente, Tipo_Acto)

        Dim tarifa As Double = objCd.GetTarifa(Impuesto, Input_par, fecha)
        TxtParametros.Text = Input_par
        TxtTarifa.Text = tarifa.ToString
    End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    End Sub
End Class
