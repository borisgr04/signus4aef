Imports System.Data
Partial Class DatosBasicos_Requi_Declaracion_Requideclaracion
    Inherits PaginaComun
    Dim Obj As Requi_Declaracion = New Requi_Declaracion
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Me.Opcion = Me.Tit.Text
        Me.SetTitulo()

        If Not IsPostBack Then
            FillCustomerInGrid()
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
                Me.SetFocus(Me.txtcodNew)

            Case "Editar"


                Dim index As Integer = Convert.ToInt32(e.CommandArgument)
                Me.GridView1.SelectedIndex = index

                Me.HdPk1.Value = GridView1.DataKeys(index).Values(0).ToString()
                Me.HdPk2.Value = GridView1.DataKeys(index).Values(1).ToString()

                Dim tb As DataTable = Obj.GetPorCod(HdPk1.Value, HdPk2.Value)
                If tb.Rows.Count > 0 Then
                    Me.TxtcldecNew.Text = tb.Rows(0)("REQ_CLDEC").ToString
                    Me.txtcodNew.Text = tb.Rows(0)("REQ_COD").ToString
                    Me.TxtdescNew.Text = tb.Rows(0)("REQ_DESC").ToString
                    Me.TxtFecini.Text = CDate(tb.Rows(0)("REQ_FINI").ToString).ToShortDateString
                    Me.txtfecfin.Text = CDate(tb.Rows(0)("REQ_FFIN").ToString).ToShortDateString
                    'Me.HdPk1.Value = tb.Rows(0)("REQ_COD").ToString
                    Habilitar(True)
                    Me.ModalPopupTer.Show()
                End If
                Me.SubT.Text = "Editando...Código [" + Me.txtcodNew.Text + "]"
                'MultiView1.ActiveViewIndex = 0
                Me.MsgResult.Text = "Editando: Código [" + Me.txtcodNew.Text + "]"

            Case "Eliminar"
                Dim index As Integer = Convert.ToInt32(e.CommandArgument)
                Me.GridView1.SelectedIndex = index

                Me.HdPk1.Value = GridView1.DataKeys(index).Values(0).ToString()
                Me.HdPk2.Value = GridView1.DataKeys(index).Values(1).ToString()

                Dim tb As DataTable = Obj.GetPorCod(HdPk1.Value, HdPk2.Value)

                If tb.Rows.Count > 0 Then
                    Me.TxtcldecNew.Text = tb.Rows(0)("REQ_CLDEC").ToString
                    Me.txtcodNew.Text = tb.Rows(0)("REQ_COD").ToString
                    Me.TxtdescNew.Text = tb.Rows(0)("REQ_DESC").ToString
                    Me.TxtFecini.Text = CDate(tb.Rows(0)("REQ_FINI").ToString).ToShortDateString
                    Me.txtfecfin.Text = CDate(tb.Rows(0)("REQ_FFIN").ToString).ToShortDateString
                    Habilitar(False)
                    Me.ModalPopupTer.Show()
                End If

                'MultiView1.ActiveViewIndex = 0




        End Select

    End Sub


    Protected Sub Habilitar(ByVal b As Boolean)
        Me.TxtcldecNew.Enabled = b
        Me.txtcodNew.Enabled = b
        Me.TxtdescNew.Enabled = b
        Me.TxtFecini.Enabled = b
        Me.txtfecfin.Enabled = b
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
                Me.MsgResult.Text = Obj.Insert(Me.TxtcldecNew.Text, Me.txtcodNew.Text, Me.TxtdescNew.Text, Me.TxtFecini.Text, Me.txtfecfin.Text)
            Case "Editar"
                Me.MsgResult.Text = Obj.Update(Me.HdPk1.Value, Me.HdPk2.Value, Me.txtcodNew.Text, Me.TxtdescNew.Text, Me.TxtFecini.Text, Me.txtfecfin.Text)
        End Select

        Me.MsgBox(MsgResult, Obj.lErrorG)
        FillCustomerInGrid()
        If Obj.lErrorG = False Then
            Me.Limpiar()
        End If

    End Sub

    Protected Sub Limpiar()
        Me.TxtcldecNew.Text = ""
        Me.txtcodNew.Text = ""
        Me.TxtdescNew.Text = ""
        Me.TxtFecini.Text = ""
        Me.txtfecfin.Text = ""

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
        Me.MsgResult.Text = Obj.Delete(HdPk1.Value, HdPk2.Value)
        Me.MsgBox(MsgResult, Obj.lErrorG)
        FillCustomerInGrid()
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
