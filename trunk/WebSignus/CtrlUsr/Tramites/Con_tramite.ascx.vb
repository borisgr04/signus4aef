Imports System.Data

Partial Class CtrlUsr_Tramites_Con_tramite
    Inherits System.Web.UI.UserControl
    Public Event SelClicked As EventHandler

    Public ReadOnly Property CodTramite() As String
        Get
            Return gvConsulta.SelectedValue
        End Get
    End Property
    Public ReadOnly Property NomTramite() As String
        Get
            Dim otram As New TRAMITES
            Dim dtConsulta As New DataTable
            Dim valor As String = ""
            dtConsulta = otram.GetPorCod(gvConsulta.SelectedValue)
            If dtConsulta.Rows.Count > 0 Then
                valor = dtConsulta.Rows(0)("TRAM_NOMB")
            End If
            Return valor
        End Get
    End Property

    Protected Overridable Sub Onclick(ByVal sender As Object)
        RaiseEvent SelClicked(sender, New EventArgs)
    End Sub

    Protected Sub gvConsulta_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles gvConsulta.SelectedIndexChanged
        Onclick(sender)
    End Sub
End Class
