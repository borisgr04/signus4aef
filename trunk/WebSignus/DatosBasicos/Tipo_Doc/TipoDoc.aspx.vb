Imports System.Data
Imports System.IO

Partial Class DatosBasicos_Tipo_Doc_TipoDoc
    Inherits PaginaComun
    Dim Obj As TIPO_DOC = New TIPO_DOC
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
                Me.SetFocus(Me.TxtNomNew)

            Case "Editar"
                Me.SubT.Text = "Editando..."
                Dim index As Integer = Convert.ToInt32(e.CommandArgument)
                Me.GridView1.SelectedIndex = index

                Dim tb As DataTable = Obj.GetPorCod(GridView1.SelectedValue)
                If tb.Rows.Count > 0 Then
                    Me.TxtCodiNew.Text = tb.Rows(0)("TIDO_CODI").ToString
                    Me.TxtNomNew.Text = tb.Rows(0)("TIDO_NOMB").ToString
                    Me.CboEst.SelectedValue = tb.Rows(0)("TIDO_EST").ToString
                    Me.HdPk1CODI.Value = tb.Rows(0)("TIDO_CODI").ToString
                    tbResponsable.Text = tb.Rows(0)("TIDO_RESP").ToString
                    If Not IsDBNull(tb.Rows(0)("TIDO_FIRMA")) Then
                        lbFirma1.Text = "Firma digital cargada"
                        Image1.ImageUrl = "~/ashx/Firma.ashx?id=" + TxtCodiNew.Text
                        Image1.Visible = True
                    Else
                        lbFirma1.Text = ""
                        Image1.Visible = False
                    End If
                    Habilitar(True)
                End If
                Me.ModalPopupTer.Show()
                'MultiView1.ActiveViewIndex = 0
                Me.MsgResult.Text = "Editando: Código [" + Me.TxtCodiNew.Text + "]"

            Case "Eliminar"
                Dim index As Integer = Convert.ToInt32(e.CommandArgument)
                Me.GridView1.SelectedIndex = index
                Me.HdPk1CODI.Value = GridView1.DataKeys(index).Values(0).ToString()
                Dim tb As DataTable = Obj.GetPorCod(GridView1.SelectedValue)
                If tb.Rows.Count > 0 Then
                    Me.TxtCodiNew.Text = tb.Rows(0)("TIDO_CODI").ToString
                    Me.TxtNomNew.Text = tb.Rows(0)("TIDO_NOMB").ToString
                    Me.CboEst.SelectedValue = tb.Rows(0)("TIDO_EST").ToString
                    Me.HdPk1CODI.Value = tb.Rows(0)("TIDO_CODI").ToString
                    tbResponsable.Text = tb.Rows(0)("TIDO_RESP").ToString
                    If Not IsDBNull(tb.Rows(0)("TIDO_FIRMA")) Then
                        lbFirma1.Text = "Firma digital cargada"
                        Image1.ImageUrl = "~/ashx/Firma.ashx?id=" + TxtCodiNew.Text
                        Image1.Visible = True
                    Else
                        lbFirma1.Text = ""
                        Image1.Visible = False
                    End If
                    Habilitar(False)
                End If
                Me.ModalPopupTer.Show()
                'MultiView1.ActiveViewIndex = 0
        End Select

    End Sub


    Protected Sub Habilitar(ByVal b As Boolean)
        Me.TxtCodiNew.Enabled = b
        Me.TxtNomNew.Enabled = b
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
                Me.MsgResult.Text = Obj.Insert(Me.TxtCodiNew.Text, Me.TxtNomNew.Text, Me.CboEst.SelectedValue, tbResponsable.Text)
                Dim image As Byte()
                image = Util.ImageByte(FuFirma)
                If Not image Is Nothing Then
                    Dim oTipoDoc As New TIPO_DOC
                    oTipoDoc.UpdateFirma(TxtCodiNew.Text, image)
                End If
            Case "Editar"
                Me.MsgResult.Text = Obj.Update(Me.HdPk1CODI.Value, Me.TxtCodiNew.Text, Me.TxtNomNew.Text, Me.CboEst.SelectedValue, tbResponsable.Text)
                Dim image As Byte()
                image = Util.ImageByte(FuFirma)
                If Not image Is Nothing Then
                    Dim oTipoDoc As New TIPO_DOC
                    oTipoDoc.UpdateFirma(TxtCodiNew.Text, image)
                End If
        End Select

        Me.MsgBox(MsgResult, Obj.lErrorG)
        FillCustomerInGrid()
        If Obj.lErrorG = False Then
            Me.Limpiar()
        End If

    End Sub

    Protected Sub Limpiar()
        Me.TxtCodiNew.Text = ""
        Me.TxtNomNew.Text = ""
        Image1.Visible = False
        lbFirma1.Text = ""
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
