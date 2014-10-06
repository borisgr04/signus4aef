Imports System.Data
Partial Class Procesos_Anulaciones_Declaraciones_Anu_Declaraciones
    Inherits PaginaComun

    Protected Sub Button1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnBuscar.Click
        buscar()


    End Sub
    Sub buscar()
        Me.CU_ConLiq1.NroLiq = Me.TxtNLiq.Text
        Me.CU_ConLiq1.Buscar()
        'Me.MsgResult.Text = CU_ConLiq1.ms
        'Me.MsgBox(MsgResult, Not CU_ConLiq1.Encontrado)
        If (CU_ConLiq1.Estado.Trim = "CR") Or (CU_ConLiq1.Estado.Trim = "AN") Or (CU_ConLiq1.Estado.Trim = "AP") Then
            BtnAnular.Enabled = False
            CboTAnu.Enabled = False
        Else
            BtnAnular.Enabled = True
            CboTAnu.Enabled = True

            If (CU_ConLiq1.Estado.Trim = "DC") Then
                Me.CboTAnu.Items(0).Enabled = True
                Me.CboTAnu.Items(1).Enabled = False
            ElseIf (CU_ConLiq1.Estado.Trim = "PR") Then
                Me.CboTAnu.Items(0).Enabled = False
                Me.CboTAnu.Items(1).Enabled = True
            End If
        End If



    End Sub

   
    Protected Sub TxtNLiq_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles TxtNLiq.TextChanged
        buscar()
    End Sub

    Protected Sub BtnAnular_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnAnular.Click
        Dim an As New Anulaciones

        MsgResult.Text = an.Insert(Me.CboTAnu.Text, CU_ConLiq1.Tipo_Doc, CU_ConLiq1.NroLiq, TxtObs.Text)
        MsgResult.Text += "Anulación N°" + an.NroAnulacion

        MsgBox(MsgResult, an.lErrorG)

    End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Me.Opcion = LBTITULO.Text
        Me.SetTitulo()
    End Sub
End Class
