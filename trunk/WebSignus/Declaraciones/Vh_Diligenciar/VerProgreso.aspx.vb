
Partial Class Declaraciones_Vh_Diligenciar_VerProgreso
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
        LabeltIMER.Text = "<b>Timer:</b>" + LabeltIMER.Text
    End Sub

    Sub Actualizar()
        If Me.Nro_LiqG <> "" Then
            LabeltIMER.Text = "Actualización: " + DateTime.Now.ToLongTimeString() + "Cantidad Liq" + ObjLiq.GetUltimaLiquidacion(Me.Nro_LiqG).ToString + "<b> LiqG " + Me.Nro_LiqG + "</b>"
        Else
            LabeltIMER.Text = "Actualización: " + DateTime.Now.ToLongTimeString() + "No Iniciado a Liquidar"
        End If
    End Sub

    Protected Sub BtnParar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnParar.Click
        Me.MsgResult.Text = ObjLiq.SuspenderLiq(Me.Nro_LiqG)
        MsgBox1(Me.MsgResult, ObjLiq.lErrorG)
    End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            Actualizar()
            LabeltIMER.Text = "<b>Inicial:</b>" + LabeltIMER.Text
        End If

    End Sub
End Class
