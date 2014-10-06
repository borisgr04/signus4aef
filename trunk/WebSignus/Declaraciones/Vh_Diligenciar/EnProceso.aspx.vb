Imports System.Guid

Partial Class Declaraciones_Vh_Diligenciar_EnProceso
    Inherits PaginaComun

    Property EstadoProceso As String
        Get
            Return ViewState("EstadoProceso")
        End Get
        Set(ByVal value As String)
            ViewState("EstadoProceso") = value
        End Set
    End Property
    Property Nro_LiqG As String
        Get
            Return ViewState("Nro_LiqG")
        End Get
        Set(ByVal value As String)
            ViewState("Nro_LiqG") = value
        End Set
    End Property

    Protected Sub Timer1_Tick(ByVal sender As Object, ByVal e As System.EventArgs) Handles Timer1.Tick
        Actualizar()
        LabelTimer.Text = "<b> Hora :</b>" + DateTime.Now.ToLongTimeString()
    End Sub

    Protected Sub BtnParar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnParar.Click
        Dim ObjLiq As New Vh_Liquidaciones
        Me.MsgResult.Text = ObjLiq.SuspenderLiq(Nro_LiqG)
        If Not ObjLiq.lErrorG Then
            Me.MsgResult.Text = "Se Abortó la Ejecución del Proceso"
        End If
        MsgBox1(Me.MsgResult, ObjLiq.lErrorG)
    End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Timer1.Enabled = True
        If Not IsPostBack Then
            EstadoProceso = Nothing
            Actualizar()
        End If
    End Sub
    
    Sub Actualizar()
        Dim Paquete As Long = 100
        Dim IdPeticion As Guid = New System.Guid(Request.QueryString("idPeticion"))
        Dim Oliq As Vh_Liquidaciones = GestorL._instancia.GetLiquidacion(IdPeticion)
        If Not Oliq Is Nothing Then
            Nro_LiqG = Oliq.Nro_LiqG
            Oliq.CargarDatosLiqG()
            LbPorcentaje.Text = String.Format("<b>{0}</b> <br/> {1} de {2} Vehiculos ", Oliq.Lg.cPorcentaje, Oliq.Lg.Actual, Oliq.Lg.Total)
            lblBarraProcentaje.Width = CInt(Oliq.Lg.nPorcentaje * 500)
            lblBarraProcentaje.Text = CInt(Oliq.Lg.nPorcentaje * 500)
            Me.LbEstado.Text = Oliq.Lg.cEstado
            LbNro_LiqG.Text = Oliq.Nro_LiqG
            If (Oliq.Lg.Estado = "TE") Or (Oliq.Lg.Estado = "SU") Then
                EstadoProceso = "TE"
                GestorL._instancia.Remove(IdPeticion)
                Response.Redirect("SelDec.aspx?Nro_LiqG=" + Nro_LiqG)
            End If
        Else
            If EstadoProceso Is Nothing Then
                LbPorcentaje.Text = "No hay proceso en ejecución. "

            End If
            Response.Redirect("SelDec.aspx?Nro_LiqG=" + Nro_LiqG)

        End If

    End Sub

End Class
