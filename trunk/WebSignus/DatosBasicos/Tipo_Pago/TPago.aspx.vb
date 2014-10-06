Imports System.Data
Partial Class DatosBasicos_TIPO_PAGO_TPago
    Inherits PaginaComun
    Dim Obj As TIPO_PAGO = New TIPO_PAGO
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Me.Opcion = Me.Tit.Text
        Me.SetTitulo()

        If Not IsPostBack Then
            FillCustomerInGrid()
            Me.MultiView1.ActiveViewIndex = -1
        End If
    End Sub

    Protected Sub GridView1_RowCommand(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewCommandEventArgs)

        Me.Oper.Value = e.CommandName
        MultiView1.ActiveViewIndex = -1

        Select Case Me.Oper.Value
            Case "Nuevo"
                Me.SubT.Text = "Nuevo..."
                MultiView1.ActiveViewIndex = 0
                'Me.TxtCodNew.ReadOnly = True
                Me.SetFocus(Me.TxtNomNew)

            Case "Editar"
                Me.SubT.Text = "Editando..."
                Dim index As Integer = Convert.ToInt32(e.CommandArgument)
                Me.GridView1.SelectedIndex = index

                Dim tb As DataTable = Obj.GetPorCod(GridView1.SelectedValue)
                If tb.Rows.Count > 0 Then
                    Me.TxtCodNew.Text = tb.Rows(0)("TPAG_COD").ToString
                    Me.TxtNomNew.Text = tb.Rows(0)("TPAG_NOM").ToString
                    Me.HdPk1.Value = tb.Rows(0)("TPAG_COD").ToString
                End If
                MultiView1.ActiveViewIndex = 0
                Me.MsgResult.Text = "Editando: Código [" + Me.TxtCodNew.Text + "]"

            Case "Eliminar"
                Dim index As Integer = Convert.ToInt32(e.CommandArgument)
                Me.GridView1.SelectedIndex = index

                Me.MsgResult.Text = Obj.Delete(GridView1.DataKeys(index).Values(0).ToString())
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
                Me.MsgResult.Text = Obj.Insert(Me.TxtCodNew.Text, Me.TxtNomNew.Text)
            Case "Editar"
                Me.MsgResult.Text = Obj.Update(Me.HdPk1.Value, Me.TxtCodNew.Text, Me.TxtNomNew.Text)
        End Select

        Me.MsgBox(MsgResult, Obj.lErrorG)
        FillCustomerInGrid()
        If Obj.lErrorG = False Then
            Me.Limpiar()
        End If

    End Sub

    Protected Sub Limpiar()
        Me.TxtCodNew.Text = ""
        Me.TxtNomNew.Text = ""
        Me.TxtNomNew.Text = ""

        Me.MultiView1.ActiveViewIndex = -1
    End Sub
    Protected Sub BtnCancelar_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        Me.Limpiar()
    End Sub
End Class
