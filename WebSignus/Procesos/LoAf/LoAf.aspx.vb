Imports System.Data
Partial Class Procesos_LoAf_LoAf
    Inherits PaginaComun
    Dim NroRenglon As String = "9"
    Dim fnTotalizar As String
    Protected Function NRenglon() As String

        NroRenglon = CStr(CInt(NroRenglon) + 1).PadLeft(2, "0")
        Return NroRenglon

    End Function
    Protected Sub button_Click(ByVal sender As Object, ByVal e As System.EventArgs)

    End Sub

    Protected Sub BtnBuscDP_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        Me.ModalPopupTer.Show()
    End Sub

    Protected Sub Periodo_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim OBJCD As CDeclaraciones = New CDeclaraciones(Me.CbCdec.SelectedValue)
        Dim DT As DataTable
        Dim año As String = Me.CboVigencia.SelectedValue
        Dim per As String = Me.Periodo.SelectedValue
        DT = OBJCD.GetFormularios_Dec(año, per).Tables(0)
        Me.HdFODE.Value = DT.Rows(0)("Fode_codi").ToString()

        Dim objP As Procesos = New Procesos
        Dim dtA As DataTable = objP.GetAforo(Me.HdFODE.Value, Me.HdTAG.Value)
        Me.GridView1.DataSource = dtA
        Me.GridView1.DataBind()
        '      Me.DataList1.DataSource = dtA
        'Me.DataList1.DataBind()
        Me.Label10.Text = Me.DataList1.ClientID


        DirectCast(Me.GridView1.FooterRow.FindControl("LbTIMPUESTO"), Label).Text = FormatNumber(dtA.Compute("Sum(ValorImpuesto)", ""))

        Me.fnTotalizar = "javascript:TotalizarAforo(" & dtA.Rows.Count & ",1000);"

    End Sub

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
                    Me.HdFODE.Value = dt.Rows(0)("Ter_tip").ToString
                    Me.BtnBuscDP.Visible = False
                    '     Me.BtnAnular.Visible = False
                Else
                    Me.BtnBuscDP.Visible = True
                    '      Me.BtnAnular.Visible = True
                End If
            End If
        End If
    End Sub

    Protected Sub DataList1_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs)

    End Sub

    Protected Sub DataList1_ItemDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.DataListItemEventArgs)
        If e.Item.ItemType = ListItemType.Item Or e.Item.ItemType = ListItemType.AlternatingItem Then
            ' ASIGNA EVENTOS
            Dim TxtR As TextBox = DirectCast(e.Item.FindControl("TxtR"), TextBox)
            Dim TxtValBas As TextBox = DirectCast(e.Item.FindControl("TxtValBas"), TextBox)
            Dim LbTar As Label = DirectCast(e.Item.FindControl("LbTar"), Label)
            Dim HdTari As Label = DirectCast(e.Item.FindControl("HdTARI"), Label)
            Dim HdCTAR As HiddenField = DirectCast(e.Item.FindControl("HdCTAR"), HiddenField)


            If HdCTAR.Value = "S" Then
                'If CDbl(HdCTAR.Value) = "S" Then
                'LbTar.Text = CStr(Tarifa(HdIMPTO.Value) * 100) + "%"
                'Else
                'LbTar.Text = "$" + FormatNumber(Tarifa(HdIMPTO.Value))
                'End If
                'HdTari.Value = Tarifa(HdIMPTO.Value)
            End If
            'Operaciones
            TxtR.Attributes.Add("onBlur", Me.fnTotalizar + "Resaltar_Off(this);")
            TxtValBas.Attributes.Add("onBlur", Me.fnTotalizar + "Resaltar_Off(this);")

            Me.Label10.Text = TxtR.ClientID
            'TxtR.Attributes.Add("onFocus", "ResaltarD_On(this)")
            'TxtR.Attributes.Add("onkeypress", "return tabular(event,this);")
            If Me.Cla_Dec.Value = "02" Then
                '   TxtValBas.Attributes.Add("onBlur", "Resaltar_Off(this);")
            Else
                '   TxtValBas.Attributes.Add("onBlur", "Resaltar_Off(this);redondear_input(this,1000);")
            End If
            'TxtValBas.Attributes.Add("onFocus", "Resaltar_On(this);")
            'definición de Renglones ReadOnly- Sumados o calculados
            If (HdCTAR.Value = "S") Then
                '   TxtR.Attributes.Add("onFocus", "ResaltarD_On(this)")
                '  TxtR.ReadOnly = True
                If Me.Cla_Dec.Value = "02" Then
                    '     TxtValBas.Attributes.Add("onBlur", Me.fnTotalizar + "Resaltar_Off(this);")
                Else
                    '    TxtValBas.Attributes.Add("onBlur", Me.fnTotalizar + "Resaltar_Off(this);redondear_input(this,1000);")
                End If
            Else
                'TxtR.Attributes.Add("onFocus", "Resaltar_On(this)")
            End If
        End If
    End Sub
End Class
