
Partial Class CtrlUsr_Expedientes_Anu_Expediente
    Inherits System.Web.UI.UserControl
    Public Property NumExpediente() As String
        Get
            Return HFNumExpe.Value
        End Get
        Set(ByVal value As String)
            HFNumExpe.Value = value
        End Set
    End Property

    Public Property Periodo() As String
        Get
            Return HFPeriodo.Value
        End Get
        Set(ByVal value As String)
            HFPeriodo.Value = value
        End Set
    End Property

    Public Property Vigencia() As String
        Get
            Return HFVigencia.Value
        End Get
        Set(ByVal value As String)
            HFVigencia.Value = value
        End Set
    End Property

    Public Property Tabla() As String
        Get
            Return HFTabla.Value
        End Get
        Set(ByVal value As String)
            HFTabla.Value = value
        End Set
    End Property

    Public Property IdTabla() As String
        Get
            Return HFID.Value
        End Get
        Set(ByVal value As String)
            HFID.Value = value
        End Set
    End Property


    Protected Sub btGuardar_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btGuardar.Click
        Select Case HFTabla.Value
            Case "EXPE_TRAM"
                Dim oExpeTram As New Expe_Tram
                oExpeTram.Delete(HFID.Value, tbFecha.Text, tbObservacion.Text)
                MsgResult.Text = oExpeTram.Msg
                If oExpeTram.lErrorG Then
                    MsgResult.CssClass = "error"
                Else
                    MsgResult.CssClass = "infor"
                End If
            Case "EXPE_NOTIF"
                Dim oNot As New Expe_Notif
                oNot.Delete(HFID.Value, tbFecha.Text, tbObservacion.Text)
                MsgResult.Text = oNot.Msg
                If oNot.lErrorG Then
                    MsgResult.CssClass = "error"
                Else
                    MsgResult.CssClass = "infor"
                End If
            Case "EXPE_APG"
                Dim oApg As New Expe_Apg
                oApg.Delete(HFNumExpe.Value, HFVigencia.Value, HFPeriodo.Value, tbFecha.Text, tbObservacion.Text)
                MsgResult.Text = oApg.Msg
                If oApg.lErrorG Then
                    MsgResult.CssClass = "error"
                Else
                    MsgResult.CssClass = "infor"
                End If
        End Select
    End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        MsgResult.Text = ""
        MsgResult.CssClass = ""
    End Sub
End Class
