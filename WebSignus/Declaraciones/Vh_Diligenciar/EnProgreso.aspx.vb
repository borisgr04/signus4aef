Imports System.Guid

Partial Class Declaraciones_Vh_Diligenciar_EnProgreso
    Inherits PaginaComun
    Dim ObjLiq As New Vh_Liquidaciones
    Property Nro_LiqG As String
        Set(ByVal value As String)
            Session("Nro_LiqG") = value

        End Set
        Get
            Return Session("Nro_LiqG")
        End Get
    End Property
    Protected Sub Timer1_Tick(ByVal sender As Object, ByVal e As System.EventArgs) Handles Timer1.Tick
        Actualizar()
        LabeltIMER.Text = "<b>Timer:</b>" + DateTime.Now.ToLongTimeString()
    End Sub

    'Sub Actualizar()
    '    If Me.Nro_LiqG <> "" Then
    '        LabeltIMER.Text = "Actualización: " + DateTime.Now.ToLongTimeString() + "Cantidad Liq" + ObjLiq.GetUltimaLiquidacion(Me.Nro_LiqG).ToString + "<b> LiqG " + Me.Nro_LiqG + "</b>"
    '    Else
    '        LabeltIMER.Text = "Actualización: " + DateTime.Now.ToLongTimeString() + "No Iniciado a Liquidar"
    '    End If
    'End Sub

    Protected Sub BtnParar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnParar.Click
        Me.MsgResult.Text = ObjLiq.SuspenderLiq(Me.Nro_LiqG)
        MsgBox1(Me.MsgResult, ObjLiq.lErrorG)
    End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Timer1.Enabled = True
        If Not IsPostBack Then
            Actualizar()
            'LabeltIMER.Text = "<b>Inicial:</b>" + LabeltIMER.Text
        End If
    End Sub

    Sub Actualizar()
        Dim idPeticion As Guid = New System.Guid(Request.QueryString("idPeticion"))
        Dim OLiq As Vh_Liquidaciones = GestorL._instancia.GetLiquidacion(idPeticion)
        OLiq.CargarDatosLiqG()

        If (OLiq.Lg.Estado = "TE") Or (OLiq.Lg.Estado = "SU") Then
            GestorL._instancia.Remove(idPeticion)
            Response.Redirect("Terminado.aspx")
            'Response.AddHeader("Refresh", "0")
        Else
            'lblBarraProcentaje.Width = CInt(OLiq.GetCantLiquidacion * 3)ToString("0.00")
            lblBarraProcentaje.Text = String.Format("{0}% {1} de {2} ", OLiq.Lg.Actual.ToString / OLiq.Lg.Total.ToString, OLiq.Lg.Actual.ToString("0.00"), OLiq.Lg.Total.ToString("0.00"))
            lblBarraProcentaje.Text = String.Format("{0}% {1} de {2} ", OLiq.GetCantLiquidacion)
            lblBarraProcentaje.Text = "PRUEBA"
            'lblActual.Text = t.Actual.ToString();
            'lblMinimo.Text = t.Minimo.ToString();
            'lblMaximo.Text = t.Maximo.ToString();
            'Response.AddHeader("Refresh", "2")
        End If
    End Sub


End Class
