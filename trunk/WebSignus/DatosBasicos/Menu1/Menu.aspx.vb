Imports System.Data
Partial Class DatosBasicos_Menu1_Menu
    Inherits PaginaComun
    Dim Obj As Menudatos = New Menudatos
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Me.Opcion = Me.Tit.Text
        Me.SetTitulo()

        If Not IsPostBack Then
            Me.ModalPopupTer.Hide()
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
                Me.SetFocus(Me.txtTituloNew)

            Case "Editar"
                Me.SubT.Text = "Editando..."
                Dim index As Integer = Convert.ToInt32(e.CommandArgument)
                Me.GridView1.SelectedIndex = index

                Dim tb As DataTable = Obj.GetPorCod(GridView1.SelectedValue)
                If tb.Rows.Count > 0 Then
                    Me.TxtMenuidNew.Text = tb.Rows(0)("MENUID").ToString
                    Me.txtTituloNew.Text = tb.Rows(0)("TITULO").ToString
                    Me.txtDescripcionNew.Text = tb.Rows(0)("DESCRIPCION").ToString
                    Me.cbpadreid.SelectedValue = tb.Rows(0)("PADREID").ToString
                    Me.txtPosicionNew.Text = tb.Rows(0)("POSICION").ToString
                    Me.txtIconoNew.Text = tb.Rows(0)("ICONO").ToString
                    Me.CbHabilitado.SelectedValue = tb.Rows(0)("HABILITADO").ToString
                    Me.txtUrlNew.Text = tb.Rows(0)("URL").ToString
                    Me.txtModuloNew.Text = tb.Rows(0)("MODULO").ToString
                    Me.txtTargetNew.Text = tb.Rows(0)("TARGET").ToString
                    Me.txtPpalNew.Text = tb.Rows(0)("PPAL").ToString
                    'Me.CbHabilitado.SelectedValue = tb.Rows(0)("HABILITADO").ToString
                    Me.txtRolesNew.Text = tb.Rows(0)("ROLES").ToString
                    Me.HdPk1.Value = tb.Rows(0)("MENUID").ToString
                    Habilitar(True)
                End If
                Me.ModalPopupTer.Show()
                'MultiView1.ActiveViewIndex = 0
                Me.MsgResult.Text = "Editando: Código [" + Me.TxtMenuidNew.Text + "]"

            Case "Eliminar"
                Dim index As Integer = Convert.ToInt32(e.CommandArgument)
                Me.GridView1.SelectedIndex = index
                Me.HdPk1.Value = GridView1.DataKeys(index).Values(0).ToString()
                Dim tb As DataTable = Obj.GetPorCod(GridView1.SelectedValue)
                If tb.Rows.Count > 0 Then
                    Me.TxtMenuidNew.Text = tb.Rows(0)("MENUID").ToString
                    Me.txtTituloNew.Text = tb.Rows(0)("TITULO").ToString
                    Me.txtDescripcionNew.Text = tb.Rows(0)("DESCRIPCION").ToString
                    Me.cbpadreid.SelectedValue = tb.Rows(0)("PADREID").ToString
                    Me.txtPosicionNew.Text = tb.Rows(0)("POSICION").ToString
                    Me.txtIconoNew.Text = tb.Rows(0)("ICONO").ToString
                    Me.CbHabilitado.SelectedValue = tb.Rows(0)("HABILITADO").ToString
                    Me.txtUrlNew.Text = tb.Rows(0)("URL").ToString
                    Me.txtModuloNew.Text = tb.Rows(0)("MODULO").ToString
                    Me.txtTargetNew.Text = tb.Rows(0)("TARGET").ToString
                    Me.txtPpalNew.Text = tb.Rows(0)("PPAL").ToString
                    'Me.CbHabilitado.SelectedValue = tb.Rows(0)("PPAL").ToString
                    Me.HdPk1.Value = tb.Rows(0)("MENUID").ToString

                    Habilitar(False)
                End If
                Me.ModalPopupTer.Show()
                'MultiView1.ActiveViewIndex = 0

        End Select

    End Sub


    Protected Sub Habilitar(ByVal b As Boolean)
        Me.TxtMenuidNew.Enabled = b
        Me.txtTituloNew.Enabled = b
        Me.txtDescripcionNew.Enabled = b
        Me.cbpadreid.Enabled = b
        Me.txtPosicionNew.Enabled = b
        Me.txtIconoNew.Enabled = b
        Me.CbHabilitado.Enabled = b
        Me.txtUrlNew.Enabled = b
        Me.txtModuloNew.Enabled = b
        Me.txtTargetNew.Enabled = b
        Me.txtPpalNew.Enabled = b
        'Me.txtHabilitadoNew.Enabled = b
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
                Me.MsgResult.Text = Obj.Insert(Me.TxtMenuidNew.Text, Me.txtTituloNew.Text, Me.txtDescripcionNew.Text, Me.cbpadreid.SelectedValue, Me.txtPosicionNew.Text, Me.txtIconoNew.Text, CbHabilitado.SelectedValue, Me.txtUrlNew.Text, Me.txtModuloNew.Text, Me.txtRolesNew.Text, Me.txtTargetNew.Text, Me.txtPpalNew.Text)
            Case "Editar"
                Me.MsgResult.Text = Obj.Update(Me.HdPk1.Value, Me.TxtMenuidNew.Text, Me.txtTituloNew.Text, Me.txtDescripcionNew.Text, Me.cbpadreid.SelectedValue, Me.txtPosicionNew.Text, Me.txtIconoNew.Text, CbHabilitado.SelectedValue, Me.txtUrlNew.Text, Me.txtModuloNew.Text, Me.txtRolesNew.Text, Me.txtTargetNew.Text, Me.txtPpalNew.Text)
        End Select

        Me.MsgBox(MsgResult, Obj.lErrorG)
        FillCustomerInGrid()
        If Obj.lErrorG = False Then
            Me.Limpiar()
        End If
    End Sub

    Protected Sub Limpiar()
        Me.TxtMenuidNew.Text = ""
        Me.txtTituloNew.Text = ""
        Me.txtDescripcionNew.Text = ""
        'Me.txtPadreidNew.Text = ""
        Me.txtPosicionNew.Text = ""
        Me.txtIconoNew.Text = ""
        'Me.txtHabilitadoNew.Text = ""
        Me.txtUrlNew.Text = ""
        Me.txtModuloNew.Text = ""
        Me.txtRolesNew.Text = ""
        Me.txtTargetNew.Text = ""
        Me.txtPpalNew.Text = ""


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
        Me.MsgResult.Text = Obj.Delete(Me.TxtMenuidNew.Text)
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

    Protected Sub btnFiltrar_Click(ByVal sender As Object, ByVal e As System.EventArgs)



        Dim MenuID As String = DirectCast(GridView1.HeaderRow.FindControl("txtMenuId"), TextBox).Text
        Dim PadreId As String = DirectCast(GridView1.HeaderRow.FindControl("CboPadreId"), DropDownList).SelectedValue
        Dim Roles As String = DirectCast(GridView1.HeaderRow.FindControl("TxtRoles"), TextBox).Text


        Me.FValores.Value = ""

        If MenuID <> "" Then
            Me.FValores.Value += " And MenuId Like '" + MenuID + "'"
        End If
        If PadreId <> "" Then
            Me.FValores.Value += " And PadreId Like '" + PadreId + "'"
        End If
        If Roles <> "" Then
            Me.FValores.Value += " And Roles Like '" + Roles + "'"
        End If

        'Me.MsgResult.Text = Me.FValores.Value
        Me.GridView1.DataBind()

        DirectCast(GridView1.HeaderRow.FindControl("txtMenuId"), TextBox).Text = MenuID
        DirectCast(GridView1.HeaderRow.FindControl("CboPadreID"), DropDownList).Text = PadreId
        DirectCast(GridView1.HeaderRow.FindControl("txtRoles"), TextBox).Text = Roles

    End Sub

    Protected Sub btnQFiltrar_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        Me.FValores.Value = ""
        Me.GridView1.DataBind()
    End Sub


    Protected Sub BtnFiltrar_Click1(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnFiltrar.Click
        Me.MsgResult.Text = "Se Borra Filtros"
        Me.FValores.Value = ""
        UpdatePanel1.Update()
    End Sub

    Protected Sub BtnRoles_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnRoles.Click
        Dim m As New Menudatos

        Me.MsgResult.Text = "Se Generaron Roles Automáticamente" + m.GenerarRoles()

        MsgBox(MsgResult, False)

        UpdatePanel1.Update()
    End Sub
End Class
