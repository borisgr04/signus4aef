Imports System.Data
Partial Class DatosBasicos_Dist_Cart_Dist_Cart
    Inherits PaginaComun
    Dim Obj As Dist_Cart = New Dist_Cart
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Me.Opcion = Me.Tit.Text
        Me.SetTitulo()

        If Not IsPostBack Then
            '            FillCustomerInGrid()
            ' Me.MultiView1.ActiveViewIndex = -1
        End If
    End Sub

    Protected Sub GridView1_RowCommand(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewCommandEventArgs)

        Me.Oper.Value = e.CommandName
        'MultiView1.ActiveViewIndex = -1

        Select Case Me.Oper.Value
            Case "Nuevo"
                Me.SubT.Text = "Nuevo..."

                Me.Habilitar(True)
                Limpiar()

                Me.ModalPopupTer.Show()
                'Me.TxtCodNew.ReadOnly = True
                Me.SetFocus(Me.TxtcdecNew)

            Case "Editar"
                Me.SubT.Text = "Editando..."
                Dim index As Integer = Convert.ToInt32(e.CommandArgument)
                Me.GridView1.SelectedIndex = index
                Me.HdPk1.Value = GridView1.DataKeys(index).Values(0).ToString()
                Me.Hdpk2.Value = GridView1.DataKeys(index).Values(1).ToString()
                Me.Hdpk3.Value = GridView1.DataKeys(index).Values(2).ToString()
                Dim tb As DataTable = Obj.GetPorCod(GridView1.DataKeys(index).Values(0).ToString(), GridView1.DataKeys(index).Values(1).ToString(), GridView1.DataKeys(index).Values(2).ToString())
                If tb.Rows.Count > 0 Then
                    Me.HdPk1.Value = tb.Rows(0)("DICA_CDEC").ToString
                    Me.Hdpk2.Value = tb.Rows(0)("DICA_CODD").ToString
                    Me.Hdpk3.Value = tb.Rows(0)("DICA_CODC").ToString
                    Me.TxtcdecNew.Text = tb.Rows(0)("DICA_CDEC").ToString
                    Me.txtcoddNew.Text = tb.Rows(0)("DICA_CODD").ToString
                    Me.txtcodcNew.Text = tb.Rows(0)("DICA_CODC").ToString
                    Me.TxtfdcoNew.Text = tb.Rows(0)("DICA_FDCO").ToString
                    Me.txtordeNew.Text = tb.Rows(0)("DICA_ORDE").ToString


                    Habilitar(True)
                    Me.ModalPopupTer.Show()
                End If

                'MultiView1.ActiveViewIndex = 0
                Me.MsgResult.Text = "Editando: Código [" + Me.txtcodcNew.Text + "]"

            Case "Eliminar"
                Dim index As Integer = Convert.ToInt32(e.CommandArgument)
                Me.GridView1.SelectedIndex = index
                Me.HdPk1.Value = GridView1.DataKeys(index).Values(0).ToString()
                Me.Hdpk2.Value = GridView1.DataKeys(index).Values(1).ToString()
                Me.Hdpk3.Value = GridView1.DataKeys(index).Values(2).ToString()
                Dim tb As DataTable = Obj.GetPorCod(GridView1.DataKeys(index).Values(0).ToString(), GridView1.DataKeys(index).Values(1).ToString(), GridView1.DataKeys(index).Values(2).ToString())
                If tb.Rows.Count > 0 Then
                    Me.HdPk1.Value = tb.Rows(0)("DICA_CDEC").ToString
                    Me.Hdpk2.Value = tb.Rows(0)("DICA_CODD").ToString
                    Me.Hdpk3.Value = tb.Rows(0)("DICA_CODC").ToString
                    Me.TxtcdecNew.Text = tb.Rows(0)("DICA_CDEC").ToString
                    Me.txtcoddNew.Text = tb.Rows(0)("DICA_CODD").ToString
                    Me.txtcodcNew.Text = tb.Rows(0)("DICA_CODC").ToString
                    Me.TxtfdcoNew.Text = tb.Rows(0)("DICA_FDCO").ToString
                    Me.txtordeNew.Text = tb.Rows(0)("DICA_ORDE").ToString

                    Habilitar(False)
                    Me.ModalPopupTer.Show()
                End If

                'MultiView1.ActiveViewIndex = 0
        End Select
    End Sub


    Protected Sub Habilitar(ByVal b As Boolean)
        Me.TxtcdecNew.Enabled = b
        Me.txtcoddNew.Enabled = b
        Me.txtcodcNew.Enabled = b
        Me.TxtfdcoNew.Enabled = b
        Me.txtordeNew.Enabled = b
        Me.BtnGuardar.Enabled = b
        Me.BtnEliminar.Enabled = Not b
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
                Me.MsgResult.Text = Obj.Insert(Me.TxtcdecNew.Text, Me.txtcoddNew.Text, Me.txtcodcNew.Text, Me.TxtfdcoNew.Text, Me.txtordeNew.Text)
            Case "Editar"
                Me.MsgResult.Text = Obj.Update(Me.HdPk1.Value, Me.Hdpk2.Value, Me.Hdpk3.Value, Me.TxtcdecNew.Text, Me.txtcoddNew.Text, Me.txtcodcNew.Text, Me.TxtfdcoNew.Text, Me.txtordeNew.Text)
        End Select
        Me.MsgBox(MsgResult, Obj.lErrorG)
        FillCustomerInGrid()
        If Obj.lErrorG = False Then
            Me.Limpiar()
        End If



    End Sub

    Protected Sub Limpiar()
        Me.TxtcdecNew.Text = ""
        Me.txtcoddNew.Text = ""
        Me.txtcodcNew.Text = ""
        Me.TxtfdcoNew.Text = ""
        Me.txtordeNew.Text = ""

        'Me.MultiView1.ActiveViewIndex = -1
    End Sub

    Protected Sub GridView1_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs)
        Me.MsgResult.Text = ""
        Me.MsgResult.CssClass = ""
    End Sub



    Protected Sub GridView1_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs)
        If e.Row.RowType = DataControlRowType.DataRow Then
            'ASIGNA(EVENTOS)
            e.Row.Attributes.Add("OnMouseOver", "Resaltar_On(this);")
            e.Row.Attributes.Add("OnMouseOut", "Resaltar_Off(this);")
            e.Row.Attributes("OnClick") = Page.ClientScript.GetPostBackClientHyperlink(Me.GridView1, "Select$" + e.Row.RowIndex.ToString)
        End If
    End Sub


    Protected Sub BtnEliminar_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        Me.MsgResult.Text = Obj.Delete(Me.TxtcdecNew.Text, Me.txtcoddNew.Text, Me.txtcodcNew.Text)
        Me.MsgBox(MsgResult, Obj.lErrorG)
        FillCustomerInGrid()
    End Sub
    Protected Sub GridView1_RowDataBound1(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs)

        If e.Row.RowType = DataControlRowType.DataRow Then
            ' ASIGNA EVENTOS
            e.Row.Attributes.Add("OnMouseOver", "Resaltar_On(this);")
            e.Row.Attributes.Add("OnMouseOut", "Resaltar_Off(this);")
            'e.Row.Attributes("OnClick") = Page.ClientScript.GetPostBackClientHyperlink(Me.GridView1, "Select$" + e.Row.RowIndex.ToString)
        End If

    End Sub
End Class
