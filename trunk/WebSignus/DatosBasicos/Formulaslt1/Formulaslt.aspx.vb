Imports System.Data
Partial Class DatosBasicos_Formulaslt1_Formulaslt
    Inherits PaginaComun
    Dim Obj As Formulaslt1 = New Formulaslt1
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
                Me.CboImpto.Enabled = True

                Limpiar()

                Me.ModalPopupTer.Show()
                'Me.TxtCodNew.ReadOnly = True
                Me.SetFocus(Me.TxtcodiNew)

            Case "Editar"
                Me.SubT.Text = "Editando..."
                Dim index As Integer = Convert.ToInt32(e.CommandArgument)
                Me.GridView1.SelectedIndex = index

                Dim tb As DataTable = Obj.GetPorCod(GridView1.DataKeys(index).Values(0).ToString(), GridView1.DataKeys(index).Values(1).ToString())

                If tb.Rows.Count > 0 Then
                    Me.TxtcodiNew.Text = tb.Rows(0)("FORM_CODI").ToString
                    Me.CboImpto.SelectedValue = tb.Rows(0)("FORM_CIMP").ToString
                    Me.TxtFecIni.Text = CDate(tb.Rows(0)("FORM_FEIN").ToString).ToShortDateString
                    Me.TxtFecFin.Text = CDate(tb.Rows(0)("FORM_FEFI").ToString).ToShortDateString
                    Me.txtformNew.Text = tb.Rows(0)("FORM_FORM").ToString
                    Me.txtnormNew.Text = tb.Rows(0)("FORM_NORM").ToString
                    Me.HdPk1.Value = tb.Rows(0)("FORM_CODI").ToString
                    Me.Hdpk2.Value = tb.Rows(0)("FORM_CIMP").ToString
                    Habilitar(True)
                    Me.ModalPopupTer.Show()
                End If

                'MultiView1.ActiveViewIndex = 0
                Me.MsgResult.Text = "Editando: C�digo [" + Me.TxtcodiNew.Text + "]"

            Case "Eliminar"
                Dim index As Integer = Convert.ToInt32(e.CommandArgument)
                Me.GridView1.SelectedIndex = index
                Me.HdPk1.Value = GridView1.DataKeys(index).Values(0).ToString()
                'Me.Hdpk2.Value = GridView1.DataKeys(index).Values(1).ToString()
                Dim tb As DataTable = Obj.GetPorCod(GridView1.DataKeys(index).Values(0).ToString(), GridView1.DataKeys(index).Values(1).ToString())
                If tb.Rows.Count > 0 Then
                    Me.TxtcodiNew.Text = tb.Rows(0)("FORM_CODI").ToString
                    Me.CboImpto.SelectedValue = tb.Rows(0)("FORM_CIMP").ToString
                    Me.TxtFecIni.Text = CDate(tb.Rows(0)("FORM_FEIN").ToString).ToShortDateString
                    Me.TxtFecFin.Text = CDate(tb.Rows(0)("FORM_FEFI").ToString).ToShortDateString
                    Me.txtformNew.Text = tb.Rows(0)("FORM_FORM").ToString
                    Me.txtnormNew.Text = tb.Rows(0)("FORM_NORM").ToString
                    Me.HdPk1.Value = tb.Rows(0)("FORM_CODI").ToString
                    Me.Hdpk2.Value = tb.Rows(0)("FORM_CIMP").ToString
                    Habilitar(False)
                End If
                Me.ModalPopupTer.Show()
                'MultiView1.ActiveViewIndex = 0




        End Select

    End Sub


    Protected Sub Habilitar(ByVal b As Boolean)
        Me.TxtcodiNew.Enabled = b
        CboImpto.Enabled = False
        Me.TxtFecIni.Enabled = b
        Me.TxtFecFin.Enabled = b
        Me.txtformNew.Enabled = b
        Me.txtnormNew.Enabled = b
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
                Me.MsgResult.Text = Obj.Insert(Me.TxtcodiNew.Text, Me.TxtFecIni.Text, Me.TxtFecFin.Text, Me.txtformNew.Text, Me.txtnormNew.Text, Me.CboImpto.SelectedValue)
            Case "Editar"
                Me.MsgResult.Text = Obj.Update(Me.HdPk1.Value, Me.Hdpk2.Value, Me.TxtcodiNew.Text, Me.CboImpto.SelectedValue, Me.TxtFecIni.Text, Me.TxtFecFin.Text, Me.txtformNew.Text, Me.txtnormNew.Text)
        End Select

        Me.MsgBox(MsgResult, Obj.lErrorG)
        FillCustomerInGrid()
        If Obj.lErrorG = False Then
            Me.Limpiar()
        End If



    End Sub

    Protected Sub Limpiar()
        Me.TxtcodiNew.Text = ""
        'Me.cboimpto.selectedvalue = ""
        Me.TxtFecIni.Text = ""
        Me.TxtFecFin.Text = ""
        Me.txtformNew.Text = ""
        Me.txtnormNew.Text = ""


        'Me.MultiView1.ActiveViewIndex = -1
    End Sub

    Protected Sub GridView1_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs)
        Me.MsgResult.Text = ""
        Me.MsgResult.CssClass = ""
    End Sub




    Protected Sub BtnEliminar_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        Me.MsgResult.Text = Obj.Delete(Me.TxtcodiNew.Text, CboImpto.SelectedValue)
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
