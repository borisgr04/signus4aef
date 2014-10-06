Imports System.Data
Partial Class DatosBasicos_Cta_Banco_Ctabanco
    Inherits PaginaComun
    Dim Obj As Cta_Banco = New Cta_Banco
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Me.Opcion = Me.Tit.Text
        Me.SetTitulo()

        If Not IsPostBack Then
            FillCustomerInGrid()

        End If
    End Sub

    Protected Sub GridView1_RowCommand(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewCommandEventArgs)

        Me.Oper.Value = e.CommandName


        Select Case Me.Oper.Value
            Case "Nuevo"
                Me.SubT.Text = "Nuevo..."
                'MultiView1.ActiveViewIndex = 0
                Me.ModalPopupTer.Show()
                'Me.TxtCodNew.ReadOnly = True
                Me.SetFocus(Me.txtdescNew)

            Case "Editar"
                Me.SubT.Text = "Editando..."
                Dim index As Integer = Convert.ToInt32(e.CommandArgument)
                Me.GridView1.SelectedIndex = index

                Dim tb As DataTable = Obj.GetPorCod(GridView1.DataKeys(index).Values(0).ToString, GridView1.DataKeys(index).Values(1).ToString())
                If tb.Rows.Count > 0 Then
                    Me.CboBanco.SelectedValue = tb.Rows(0)("CTA_BACO").ToString
                    Me.TxtnroNew.Text = tb.Rows(0)("CTA_NRO").ToString
                    Me.Cbocuenta.SelectedValue = tb.Rows(0)("CTA_TIP").ToString
                    Me.txtcodbarNew.Text = tb.Rows(0)("CTA_CODBAR").ToString
                    Me.Cboest.SelectedValue = tb.Rows(0)("CTA_EST").ToString
                    Me.txtdescNew.Text = tb.Rows(0)("CTA_DESC").ToString
                    Me.HdPk1.Value = tb.Rows(0)("CTA_BACO").ToString
                    Me.HdPk2.Value = tb.Rows(0)("CTA_NRO").ToString

                End If
                'MultiView1.ActiveViewIndex = 0
                Me.ModalPopupTer.Show()
                Me.MsgResult.Text = "Editando: Código [" + Me.CboBanco.SelectedValue + "]"

            Case "Eliminar"
                Dim index As Integer = Convert.ToInt32(e.CommandArgument)
                Me.GridView1.SelectedIndex = index

                Me.MsgResult.Text = Obj.Delete(GridView1.DataKeys(index).Values(0).ToString, GridView1.DataKeys(index).Values(1).ToString())
                Me.MsgBox(MsgResult, Obj.lErrorG)
                FillCustomerInGrid()

        End Select

    End Sub

    Protected Sub GridView1_RowEditing(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewEditEventArgs) Handles GridView1.RowEditing
        GridView1.EditIndex = e.NewEditIndex
        FillCustomerInGrid()
    End Sub


    Private Sub FillCustomerInGrid()
        Me.GridView1.DataBind()
        'Dim cl As String = Me.CboImpto.SelectedValue
        'If Left(Me.CboImpto.SelectedValue, 2) <> Me.CmbClase.SelectedValue Then
        ' Me.CboImpto.SelectedIndex = 0
        ' cl = ""
        'End If
        'Dim dtCustomer As DataTable = Obj.GetByImpuesto(cl)
        'If (dtCustomer.Rows.Count > 0) Then
        ' GridView1.DataSource = dtCustomer
        'GridView1.DataBind()
        'Else
        'dtCustomer.Rows.Add(dtCustomer.NewRow())
        'GridView1.DataSource = dtCustomer
        'GridView1.DataBind()
        'Dim TotalColumns As Integer = GridView1.Rows(0).Cells.Count
        'GridView1.Rows(0).Cells.Clear()
        'GridView1.Rows(0).Cells.Add(New TableCell())
        ' GridView1.Rows(0).Cells(0).ColumnSpan = TotalColumns
        'GridView1.Rows(0).Cells(0).Text = "No se encontraron Registro"
        'End If
    End Sub

    Protected Sub BtnGuardar_Click(ByVal sender As Object, ByVal e As System.EventArgs)

        Select Case Me.Oper.Value
            Case "Nuevo"
                'Me.DropDownList1.SelectedValue
                Me.MsgResult.Text = Obj.Insert(Me.CboBanco.SelectedValue, Me.TxtnroNew.Text, Me.Cbocuenta.SelectedValue, Me.txtcodbarNew.Text, Me.Cboest.SelectedValue, Me.txtdescNew.Text, Me.txtsucNew.Text)
            Case "Editar"
                Me.MsgResult.Text = Obj.Update(Me.HdPk1.Value, Me.HdPk2.Value, Me.CboBanco.SelectedValue, Me.TxtnroNew.Text, Me.Cbocuenta.SelectedValue, Me.txtcodbarNew.Text, Me.Cboest.SelectedValue, Me.txtdescNew.Text, Me.txtsucNew.Text)
        End Select

        Me.MsgBox(MsgResult, Obj.lErrorG)
        FillCustomerInGrid()
        If Obj.lErrorG = False Then
            Me.Limpiar()
        End If

    End Sub

    Protected Sub Limpiar()

        Me.TxtnroNew.Text = ""
        'Me.txttipNew.Text = ""
        Me.txtcodbarNew.Text = ""
        ' Me.txtestNew.Text = ""
        Me.txtdescNew.Text = ""
        Me.txtsucNew.Text = ""


    End Sub
    Protected Sub BtnCancelar_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        Me.Limpiar()

    End Sub

    Protected Sub GridView1_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs)

    End Sub
  


    Protected Sub GridView1_RowDataBound1(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs)
        If e.Row.RowType = DataControlRowType.DataRow Then
            ' ASIGNA EVENTOS
            e.Row.Attributes.Add("OnMouseOver", "Resaltar_On(this);")
            e.Row.Attributes.Add("OnMouseOut", "Resaltar_Off(this);")
            '            e.Row.Attributes("OnClick") = Page.ClientScript.GetPostBackClientHyperlink(Me.GridView1, "Select$" + e.Row.RowIndex.ToString)
        End If
    End Sub
End Class
