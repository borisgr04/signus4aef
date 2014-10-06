Imports System.Data
Partial Class MediosM_Declaraciones_Consultas
    Inherits PaginaComun

    Private _TotalLiq As Decimal = 0

    Protected Sub GrdRad_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles GrdRad.SelectedIndexChanged

    End Sub
    Private Sub Habilitar_Ctrl(ByVal valor As Boolean)
        Me.BtnAnular.Enabled = valor
        Me.BtnExcel.Enabled = valor
    End Sub

    'Private Sub Mostrar_Liq()
    '    Me.GrdRad.DataBind()
    '    Me.GridView1.Visible = False
    '    Me.BtnAnular.Enabled = False
    '    Me.BtnExcel.Enabled = False
    '    If (Me.GrdRad.Rows.Count > 0) And Not (Me.GrdRad.SelectedValue) Then
    '        Dim obj As BasesLiq = New BasesLiq
    '        Dim dt As DataTable = obj.GetAforo(Me.HdTAG.Value, Me.GrdRad.SelectedValue)
    '        Me.GridView1.DataSource = dt
    '        Me.GridView1.DataBind()
    '        If Me.GridView1.Rows.Count > 0 Then
    '            DirectCast(Me.GridView1.FooterRow.FindControl("LbTIMPUESTO"), Label).Text = FormatNumber(dt.Compute("Sum(ValorImpuesto)", ""))
    '            Me.GridView1.Visible = True
    '            Me.BtnAnular.Enabled = True
    '            Me.BtnExcel.Enabled = True
    '        End If
    '    End If
    'End Sub
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Me.SetTitulo()
        Me.ToolkitScriptManager1.RegisterAsyncPostBackControl(Me.ConsultaTer1)
        If Not Me.IsPostBack Then
            Me.CbCdec.Attributes.Add("OnFocus", "javascript:UpdateCombo()")
            'Me.ROptTD.SelectedValue = "01"
            Dim dt As DataTable = Me.UsuTercero.GetByUser()
            '            Me.MsgResult.Text = dt.Rows(0)("Ter_TUS").ToString() + "-" + dt.Rows(0)("TUS_NOM").ToString()
            If (dt.Rows.Count > 0) Then
                If (dt.Rows(0)("Ter_TUS").ToString() = "AR") Then
                    Me.Agente.Text = dt.Rows(0)("Ter_Nom").ToString
                    Me.Nit.Text = dt.Rows(0)("Ter_nit").ToString
                    Me.Dv.Text = Trim(dt.Rows(0)("Ter_dver").ToString)
                    Me.HdTAG.Value = dt.Rows(0)("Ter_tip").ToString
                    Me.BtnBusc.Visible = False
                    Me.BtnAnular.Visible = False
                    Me.BtnAnular.Visible = True 'Si los agentes pueden anular
                Else
                    Me.BtnBusc.Visible = True
                    Me.BtnAnular.Visible = True 'Si error

                End If
            End If
        End If
    End Sub

    Protected Sub BtnAnular_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnAnular.Click
        Dim obj As BasesLiq = New BasesLiq
        Me.MsgResult.Text = obj.Anular(Me.GrdRad.SelectedValue)
        Me.MsgBox(Me.MsgResult, obj.lErrorG)
        Me.GrdRad.DataBind()
        Me.GridView1.DataBind()
    End Sub

    Protected Sub BtnExcel_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnExcel.Click
        Dim obj As BasesLiq = New BasesLiq
        Me.GridViewS1.DataSource = obj.GetFmto(Me.GrdRad.SelectedValue)
        Me.GridViewS1.DataBind()
        ExportGridView(Me.GridViewS1)
    End Sub

    Public Overrides Sub VerifyRenderingInServerForm(ByVal control As Control)

    End Sub


    Protected Sub BtnBusc_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        Me.ModalPopup.Show()
    End Sub

    Protected Sub button_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles button.Click
        '    Me.HdTAG.Value = dt.Rows(0)("Ter_tip").ToString
    End Sub

    Protected Sub GridView1_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles GridView1.RowDataBound
        Select Case e.Row.RowType
            Case DataControlRowType.DataRow
                If DataBinder.Eval(e.Row.DataItem, "cocd_cdec") = "30" Then
                    If DataBinder.Eval(e.Row.DataItem, "cocd_codi") = "01" Then
                        Me._TotalLiq += CDec(DataBinder.Eval(e.Row.DataItem, "ValorImpuesto"))
                    Else
                        Me._TotalLiq -= CDec(DataBinder.Eval(e.Row.DataItem, "ValorImpuesto"))
                    End If
                Else
                    Me._TotalLiq += CDec(DataBinder.Eval(e.Row.DataItem, "ValorImpuesto"))
                End If
            Case DataControlRowType.Footer
                e.Row.Cells(4).Text = FormatCurrency(Me._TotalLiq.ToString)
                e.Row.Cells(4).HorizontalAlign = HorizontalAlign.Right
                e.Row.Font.Bold = True
        End Select
    End Sub

    
    Protected Sub GrdRad_DataBound(ByVal sender As Object, ByVal e As System.EventArgs) Handles GrdRad.DataBound
        Me.Habilitar_Ctrl(Me.GrdRad.Rows.Count > 0)
    End Sub

    Protected Sub ToolkitScriptManager1_AsyncPostBackError(ByVal sender As Object, ByVal e As System.Web.UI.AsyncPostBackErrorEventArgs) Handles ToolkitScriptManager1.AsyncPostBackError
        If (Not IsNothing(e.Exception)) And (Not IsNothing(e.Exception.InnerException)) Then
            Me.MsgResult.Text = e.Exception.InnerException.Message + "Ajax"
            ToolkitScriptManager1.AsyncPostBackErrorMessage = e.Exception.InnerException.Message + "Ajax"
        End If

    End Sub
End Class

