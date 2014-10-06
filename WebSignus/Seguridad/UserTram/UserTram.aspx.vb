Imports System.Data
Imports System.Collections.Generic

Partial Class Seguridad_UserTram_UserTram
    Inherits PaginaComun

    Protected Sub BtnBuscar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnBuscDP.Click
        CtrlConTercero2.Tipo = "RT"
        Me.ModalPopupConTercero.Show()
    End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    End Sub

    Protected Sub btGuardar_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btGuardar.Click
        Dim listaTramite As New List(Of String)
        For Each row As GridViewRow In gvTramites.Rows
            Dim result As Boolean = DirectCast(row.FindControl("CheckBox1"), CheckBox).Checked
            If result Then
                listaTramite.Add(gvTramites.DataKeys(row.RowIndex).Item(0))
            End If
        Next
        Dim oTram As New Tram_Ter
        oTram.Insert(Nit.Text, listaTramite)
        MsgResult.Text = oTram.Msg
        If oTram.lErrorG Then
            MsgBoxError(MsgResult, True)
        Else
            MsgBoxExito(MsgResult, True)
            gvConsulta.DataBind()
            MultiView1.ActiveViewIndex = 1
        End If
    End Sub

    Protected Sub btPermiso_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btPermiso.Click
        MultiView1.ActiveViewIndex = 0
        Dim listaSelec As New ArrayList

        For Each row As GridViewRow In gvTramites.Rows

            Dim index As Integer = CInt(gvTramites.DataKeys(row.RowIndex).Value)

            If listaSelec.Contains(index) Then

                Dim myCheckBox As CheckBox = DirectCast(row.FindControl("CheckBox1"), CheckBox)

                myCheckBox.Checked = True

            End If

        Next
    End Sub

    Protected Sub btCancelar_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btCancelar.Click
        MultiView1.ActiveViewIndex = 1
    End Sub

    Protected Sub gvConsulta_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles gvConsulta.SelectedIndexChanged
        Dim oTram As New Tram_Ter
        oTram.Delete(gvConsulta.SelectedDataKey.Item(0), gvConsulta.SelectedDataKey.Item(1))
        MsgResult.Text = oTram.Msg
        If oTram.lErrorG Then
            MsgBoxError(MsgResult, True)
        Else
            MsgBoxExito(MsgResult, True)
            gvConsulta.DataBind()
        End If
    End Sub

    Protected Sub Nit_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles Nit.TextChanged

    End Sub

    Protected Sub CtrlConTercero2_SelClicked(ByVal sender As Object, ByVal e As System.EventArgs) Handles CtrlConTercero2.SelClicked
        Nit.Text = CtrlConTercero2.Nit
        Dv.Text = CtrlConTercero2.Dv
        Agente.Text = CtrlConTercero2.Nombre
        If Not String.IsNullOrEmpty(Nit.Text) Then
            Dim otram As New Tram_Ter
            Dim dtConsulta As New DataTable
            Dim listaSelec As New ArrayList

            dtConsulta = otram.GetPorNit(Nit.Text)
            If dtConsulta.Rows.Count > 0 Then
                For i As Integer = 0 To dtConsulta.Rows.Count - 1
                    listaSelec.Add(dtConsulta.Rows(i)("TRTE_TRAM").ToString)
                Next
                For Each row As GridViewRow In gvTramites.Rows
                    Dim index As String = gvTramites.DataKeys(row.RowIndex).Value
                    If listaSelec.Contains(index) Then
                        Dim myCheckBox As CheckBox = DirectCast(row.FindControl("CheckBox1"), CheckBox)
                        myCheckBox.Checked = True
                    End If
                Next
            End If
        End If
        ModalPopupConTercero.Hide()
    End Sub
End Class
