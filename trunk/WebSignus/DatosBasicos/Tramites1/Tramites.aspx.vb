Imports System.Data
Partial Class DatosBasicos_Tramites1_Tramites
    Inherits PaginaComun
    Dim Obj As TRAMITES = New TRAMITES
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
                Me.SetFocus(Me.txtnombNew)

            Case "Editar"
                Me.SubT.Text = "Editando..."
                Dim index As Integer = Convert.ToInt32(e.CommandArgument)
                Me.GridView1.SelectedIndex = index

                Dim tb As DataTable = Obj.GetPorCod(GridView1.SelectedValue)
                If tb.Rows.Count > 0 Then
                    Me.TxtCodiNew.Text = tb.Rows(0)("TRAM_CODI").ToString
                    Me.txtnombNew.Text = tb.Rows(0)("TRAM_NOMB").ToString
                    Me.txtrespNew.Text = tb.Rows(0)("TRAM_RESP").ToString
                    Me.txtgsanNew.Text = tb.Rows(0)("TRAM_GSAN").ToString
                    Me.txtcosaNew.Text = tb.Rows(0)("TRAM_COSA").ToString
                    Me.txtplanNew.Text = tb.Rows(0)("TRAM_PLAN").ToString
                    cmbProceso.SelectedValue = tb.Rows(0)("TRAM_PROC").ToString
                    Me.HdPk1.Value = tb.Rows(0)("TRAM_CODI").ToString
                    cmbCalendario.SelectedValue = tb.Rows(0)("TRAM_TIPO").ToString
                    cmbFechaRec.SelectedValue = tb.Rows(0)("TRAM_VFREB").ToString
                    cmbManual.SelectedValue = tb.Rows(0)("TRAM_AUTO").ToString
                    cmbTipoProc.SelectedValue = tb.Rows(0)("TRAM_TPRO").ToString
                    If Not String.IsNullOrEmpty(tb.Rows(0)("TRAM_TIDO").ToString) Then
                        cmbTipoDoc.SelectedValue = tb.Rows(0)("TRAM_TIDO").ToString
                    End If
                    tbDiasTramite.Text = tb.Rows(0)("TRAM_DIAS").ToString
                    Habilitar(True)
                End If
                Me.ModalPopupTer.Show()
                'MultiView1.ActiveViewIndex = 0
                Me.MsgResult.Text = "Editando: Código [" + Me.TxtCodiNew.Text + "]"

            Case "Eliminar"
                Dim index As Integer = Convert.ToInt32(e.CommandArgument)
                Me.GridView1.SelectedIndex = index
                Me.HdPk1.Value = GridView1.DataKeys(index).Values(0).ToString()
                Dim tb As DataTable = Obj.GetPorCod(GridView1.SelectedValue)
                If tb.Rows.Count > 0 Then
                    Me.TxtCodiNew.Text = tb.Rows(0)("TRAM_CODI").ToString
                    Me.txtnombNew.Text = tb.Rows(0)("TRAM_NOMB").ToString
                    Me.txtrespNew.Text = tb.Rows(0)("TRAM_RESP").ToString
                    Me.txtgsanNew.Text = tb.Rows(0)("TRAM_GSAN").ToString
                    Me.txtcosaNew.Text = tb.Rows(0)("TRAM_COSA").ToString
                    Me.txtplanNew.Text = tb.Rows(0)("TRAM_PLAN").ToString
                    cmbProceso.SelectedValue = tb.Rows(0)("TRAM_PROC").ToString
                    Me.HdPk1.Value = tb.Rows(0)("TRAM_CODI").ToString
                    cmbCalendario.SelectedValue = tb.Rows(0)("TRAM_TIPO").ToString
                    cmbFechaRec.SelectedValue = tb.Rows(0)("TRAM_VFREB").ToString
                    cmbManual.SelectedValue = tb.Rows(0)("TRAM_AUTO").ToString
                    cmbTipoDoc.SelectedValue = tb.Rows(0)("TRAM_TIDO").ToString
                    tbDiasTramite.Text = tb.Rows(0)("TRAM_DIAS").ToString
                    Habilitar(False)
                End If
                Me.ModalPopupTer.Show()
                'MultiView1.ActiveViewIndex = 0




        End Select

    End Sub


    Protected Sub Habilitar(ByVal b As Boolean)
        Me.TxtCodiNew.Enabled = b
        Me.txtnombNew.Enabled = b
        Me.txtrespNew.Enabled = b
        Me.txtgsanNew.Enabled = b
        Me.txtcosaNew.Enabled = b
        Me.txtplanNew.Enabled = b
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

    Protected Sub BtnGuardar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnGuardar.Click

        Select Case Me.Oper.Value
            Case "Nuevo"
                Me.MsgResult.Text = Obj.Insert(Me.TxtCodiNew.Text, Me.txtnombNew.Text, Me.txtrespNew.Text, Me.txtgsanNew.Text, _
                                               Me.txtcosaNew.Text, Me.txtplanNew.Text, cmbProceso.SelectedValue, cmbTipoDoc.SelectedValue, _
                                               cmbManual.SelectedValue, tbDiasTramite.Text, cmbCalendario.SelectedValue, cmbFechaRec.SelectedValue, cmbTipoProc.SelectedValue)
            Case "Editar"
                Me.MsgResult.Text = Obj.Update(Me.HdPk1.Value, Me.TxtCodiNew.Text, Me.txtnombNew.Text, Me.txtrespNew.Text, _
                                               Me.txtgsanNew.Text, Me.txtcosaNew.Text, Me.txtplanNew.Text, cmbProceso.SelectedValue, cmbTipoDoc.SelectedValue, _
                                               cmbManual.SelectedValue, tbDiasTramite.Text, cmbCalendario.SelectedValue, cmbFechaRec.SelectedValue, cmbTipoProc.SelectedValue)
        End Select

        Me.MsgBox(MsgResult, Obj.lErrorG)
        FillCustomerInGrid()
        If Obj.lErrorG = False Then
            Me.Limpiar()
        End If



    End Sub

    Protected Sub Limpiar()
        Me.TxtCodiNew.Text = ""
        Me.txtnombNew.Text = ""
        Me.txtrespNew.Text = ""
        Me.txtgsanNew.Text = ""
        Me.txtcosaNew.Text = ""
        Me.txtplanNew.Text = ""
        'Me.MultiView1.ActiveViewIndex = -1
    End Sub

    Protected Sub GridView1_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles GridView1.SelectedIndexChanged
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
        Me.MsgResult.Text = Obj.Delete(Me.TxtCodiNew.Text)
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
