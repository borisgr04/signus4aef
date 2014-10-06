Imports System.Data

Partial Class Procesos_Anulaciones_Acuerdos_Anu_Acuerdos
    Inherits PaginaComun

    Protected Sub BtnAnular_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnAnular.Click
        Dim oAnu As New Anulaciones
        Dim oDoc As String = ""
        If CboTAnu.SelectedValue = "APAP" Then
            oDoc = "ROAP"
        End If
        If CboTAnu.SelectedValue = "AAP" Then
            oDoc = "ACPA"
        End If
        MsgResult.Text = oAnu.Insert(Me.CboTAnu.Text, oDoc, TxtNSop.Text, TxtObs.Text)
        If Not oAnu.lErrorG Then
            MsgResult.Text += " Anulación N°" + oAnu.NroAnulacion
        End If
        MsgBox(MsgResult, oAnu.lErrorG)
    End Sub

    Protected Sub BtnBuscar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnBuscar.Click
        buscar()
    End Sub
    Private Sub buscar()
        If CboTAnu.SelectedValue = "AAP" Then
            Dim oAcue As New AcuerdosP
            Dim dtConsulta As New DataTable
            dtConsulta = oAcue.GetAcuerdobById(TxtNSop.Text)
            If dtConsulta.Rows.Count > 0 Then
                tbAgente.Text = dtConsulta.Rows(0)("TER_NOM").ToString
                tbFecha.Text = dtConsulta.Rows(0)("ACPA_FREG").ToString.Substring(0, 10)
                cmbEstado.SelectedValue = dtConsulta.Rows(0)("ACPA_EST").ToString
                If cmbEstado.SelectedValue = "AN" Then
                    MsgResult.Text = "El Acuerdo ya Se encuentra Anulado"
                    MsgBoxAlert(MsgResult, True)
                Else
                    BtnAnular.Enabled = True
                End If
            Else
                MsgResult.Text = "El Acuerdo no existe"
                BtnAnular.Enabled = False
                MsgBox(MsgResult, True)
            End If

        End If
        If CboTAnu.SelectedValue = "APAP" Then
            Dim oRec As New ReciboOf
            Dim dtConsulta As New DataTable
            dtConsulta = oRec.GetPagadoPorCodigo(TxtNSop.Text)
            If dtConsulta.Rows.Count > 0 Then
                tbAgente.Text = dtConsulta.Rows(0)("TER_NOM").ToString
                tbFecha.Text = dtConsulta.Rows(0)("ROF_FRAD").ToString.Substring(0, 10)
                cmbEstado.SelectedValue = dtConsulta.Rows(0)("ROF_EST").ToString
                If cmbEstado.SelectedValue = "AN" Then
                    MsgResult.Text = "El Recibo ya Se encuentra Anulado"
                    MsgBoxAlert(MsgResult, True)
                Else
                    BtnAnular.Enabled = True
                End If
            Else
                MsgResult.Text = "El Recibo no existe o su pago no ha sido aplicado"
                BtnAnular.Enabled = False
                MsgBox(MsgResult, True)
            End If

        End If
    End Sub

    Protected Sub TxtNSop_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles TxtNSop.TextChanged
        buscar()
    End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        MsgBoxLimpiar(MsgResult)
    End Sub
End Class
