Imports System.Data
Partial Class DatosBasicos_Calendario1_Calendario
    Inherits PaginaComun
    Dim Obj As Calendario1 = New Calendario1
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Me.Opcion = Me.Tit.Text
        Me.SetTitulo()

        If Not IsPostBack Then
            FillCustomerInGrid()
            ' Me.MultiView1.ActiveViewIndex = -1
            Me.MsgResult.Text = "Configuración "
            Activar()
        End If

    End Sub

    Public Sub Activar()
        If Me.GridView1.Rows.Count >= 0 Then
            Dim index As Integer = 0
            Me.GridView1.SelectedIndex = index
            Me.HdPk1.Value = GridView1.DataKeys(index).Values(0).ToString()
            Me.Hdpk2.Value = GridView1.DataKeys(index).Values(1).ToString()
            Me.Hdpk3.Value = GridView1.DataKeys(index).Values(2).ToString()
            Dim tb As DataTable = Obj.GetPorCod(GridView1.DataKeys(index).Values(0).ToString(), GridView1.DataKeys(index).Values(1).ToString(), GridView1.DataKeys(index).Values(2).ToString())
            If tb.Rows.Count > 0 Then
                Me.TxtperNew.Text = tb.Rows(0)("CAL_PER").ToString
                Me.txtvigNew.Text = tb.Rows(0)("CAL_VIG").ToString
                Me.txtfecini.Text = CDate(tb.Rows(0)("CAL_FINI")).ToShortDateString
                Me.Txtfecfin.Text = CDate(tb.Rows(0)("CAL_FFIN")).ToShortDateString
                Me.txtclaNew.Text = tb.Rows(0)("CAL_CLA").ToString
                Me.txtdesNew.Text = tb.Rows(0)("CAL_DES").ToString
                Me.TxtFVen.Text = CDate(tb.Rows(0)("CAL_FVEN")).ToShortDateString
            End If
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
                Me.SetFocus(Me.txtvigNew)

            Case "Editar"
                Me.SubT.Text = "Editando..."
                Dim index As Integer = Convert.ToInt32(e.CommandArgument)
                Me.GridView1.SelectedIndex = index
                Me.HdPk1.Value = GridView1.DataKeys(index).Values(0).ToString()
                Me.Hdpk2.Value = GridView1.DataKeys(index).Values(1).ToString()
                Me.Hdpk3.Value = GridView1.DataKeys(index).Values(2).ToString()
                Dim tb As DataTable = Obj.GetPorCod(GridView1.DataKeys(index).Values(0).ToString(), GridView1.DataKeys(index).Values(1).ToString(), GridView1.DataKeys(index).Values(2).ToString())
                If tb.Rows.Count > 0 Then
                    Me.HdPk1.Value = tb.Rows(0)("CAL_PER").ToString
                    Me.Hdpk2.Value = tb.Rows(0)("CAL_VIG").ToString
                    Me.Hdpk3.Value = tb.Rows(0)("CAL_CLA").ToString
                    Me.TxtperNew.Text = tb.Rows(0)("CAL_PER").ToString
                    Me.txtvigNew.Text = tb.Rows(0)("CAL_VIG").ToString
                    Me.txtfecini.Text = CDate(tb.Rows(0)("CAL_FINI")).ToShortDateString
                    Me.Txtfecfin.Text = CDate(tb.Rows(0)("CAL_FFIN")).ToShortDateString
                    Me.txtclaNew.Text = tb.Rows(0)("CAL_CLA").ToString
                    Me.txtdesNew.Text = tb.Rows(0)("CAL_DES").ToString
                    Me.TxtFVen.Text = CDate(tb.Rows(0)("CAL_FVEN")).ToShortDateString

                    Habilitar(True)
                    Me.ModalPopupTer.Show()
                End If
                'MultiView1.ActiveViewIndex = 0
                Me.MsgResult.Text = "Editando: Código [" + Me.TxtperNew.Text + "]"

            Case "Eliminar"
                Dim index As Integer = Convert.ToInt32(e.CommandArgument)
                Me.GridView1.SelectedIndex = index
                Me.HdPk1.Value = GridView1.DataKeys(index).Values(0).ToString()
                Me.Hdpk2.Value = GridView1.DataKeys(index).Values(1).ToString()
                Me.Hdpk3.Value = GridView1.DataKeys(index).Values(2).ToString()
                Dim tb As DataTable = Obj.GetPorCod(GridView1.DataKeys(index).Values(0).ToString(), GridView1.DataKeys(index).Values(1).ToString(), GridView1.DataKeys(index).Values(2).ToString())
                If tb.Rows.Count > 0 Then
                    Me.HdPk1.Value = tb.Rows(0)("CAL_PER").ToString
                    Me.Hdpk2.Value = tb.Rows(0)("CAL_VIG").ToString
                    Me.Hdpk3.Value = tb.Rows(0)("CAL_CLA").ToString
                    Me.TxtperNew.Text = tb.Rows(0)("CAL_PER").ToString
                    Me.txtvigNew.Text = tb.Rows(0)("CAL_VIG").ToString
                    Me.txtfecini.Text = tb.Rows(0)("CAL_FINI").ToString
                    Me.Txtfecfin.Text = tb.Rows(0)("CAL_FFIN").ToString
                    Me.txtclaNew.Text = tb.Rows(0)("CAL_CLA").ToString
                    Me.txtdesNew.Text = tb.Rows(0)("CAL_DES").ToString
                    Habilitar(False)
                    Me.ModalPopupTer.Show()
                End If

                'MultiView1.ActiveViewIndex = 0
        End Select
    End Sub


    Protected Sub Habilitar(ByVal b As Boolean)
        Me.TxtperNew.Enabled = b
        Me.txtvigNew.Enabled = b
        Me.txtfecini.Enabled = b
        Me.Txtfecfin.Enabled = b
        Me.txtclaNew.Enabled = b
        Me.txtdesNew.Enabled = b
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
                Me.MsgResult.Text = Obj.Insert(Me.TxtperNew.Text, Me.txtvigNew.Text, Me.txtfecini.Text, Me.Txtfecfin.Text, Me.txtclaNew.Text, Me.txtdesNew.Text, Me.TxtFVen.Text)
            Case "Editar"
                Me.MsgResult.Text = Obj.Update(Me.HdPk1.Value, Me.Hdpk2.Value, Me.Hdpk3.Value, Me.TxtperNew.Text, Me.txtvigNew.Text, Me.txtfecini.Text, Me.Txtfecfin.Text, Me.txtclaNew.Text, Me.txtdesNew.Text, Me.TxtFVen.Text)
        End Select
        Me.MsgBox(MsgResult, Obj.lErrorG)
        FillCustomerInGrid()
        If Obj.lErrorG = False Then
            Me.Limpiar()
        End If



    End Sub

    Protected Sub Limpiar()
        Me.TxtperNew.Text = ""
        Me.txtvigNew.Text = ""
        Me.txtfecini.Text = ""
        Me.Txtfecfin.Text = ""
        Me.txtclaNew.Text = ""
        Me.txtdesNew.Text = ""


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
        Me.MsgResult.Text = Obj.Delete(Me.TxtperNew.Text, Me.txtvigNew.Text, Me.txtclaNew.Text)
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

    
    Protected Sub BtnQuitarF_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        Me.FValores.Value = ""
        Me.GridView1.DataBind()
    End Sub

    Protected Sub BtnFiltrar_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        'Dim FeIn As String = DirectCast(GridView2.HeaderRow.FindControl("txtFeIn"), TextBox).Text
        'Dim Item As String = DirectCast(GridView2.HeaderRow.FindControl("txtItem"), TextBox).Text
        'Dim FeFi As String = DirectCast(GridView2.HeaderRow.FindControl("txtFeFi"), TextBox).Text
        'Dim Valo As String = DirectCast(GridView2.HeaderRow.FindControl("txtValo"), TextBox).Text
        'Dim Dec As String = DirectCast(GridView2.HeaderRow.FindControl("txtDec"), TextBox).Text
        Dim cldec As String = Me.TxtCDec.Text
        cldec = Me.CMBCLADEC.SelectedValue
        Dim a As String = Me.TxtA.Text
        Dim p As String = Me.TxtP.Text

        Me.FValores.Value = ""

        If a <> "" Then
            Me.FValores.Value += " And cal_vig Like '" + a + "'"
        End If
        If p <> "" Then
            Me.FValores.Value += " And cal_per Like '" + p + "'"
        End If
        'If FeFi <> "" Then
        'Me.FValores.Value += " And to_char(Pali_FeFi,'dd/mm/yyyy') Like '" + FeFi + "'"
        'End If
        If cldec <> "" Then
            Me.FValores.Value += " And cal_cla Like '" + cldec + "'"
        End If

        Me.MsgResult.Text = ""
        Me.MsgResult.Visible = True
        Me.GridView1.DataBind()


        'DirectCast(GridView2.HeaderRow.FindControl("txtFeIn"), TextBox).Text = FeIn
        'DirectCast(GridView2.HeaderRow.FindControl("txtItem"), TextBox).Text = Item
        'DirectCast(GridView2.HeaderRow.FindControl("txtFeFi"), TextBox).Text = FeFi
        'DirectCast(GridView2.HeaderRow.FindControl("txtValo"), TextBox).Text = Valo
        'DirectCast(GridView2.HeaderRow.FindControl("txtDec"), TextBox).Text = Dec

    End Sub

    Protected Sub BtnFiltro_Click(ByVal sender As Object, ByVal e As System.EventArgs)

        Dim cldec As String = Me.TxtCDec.Text
        Dim a As String = Me.TxtA.Text
        Dim p As String = Me.TxtP.Text

        Me.FValores.Value = ""

        If a <> "" Then
            Me.FValores.Value += " And cal_vig Like '" + a + "'"
        End If
        If p <> "" Then
            Me.FValores.Value += " And cal_per Like '" + p + "'"
        End If
        'If FeFi <> "" Then
        'Me.FValores.Value += " And to_char(Pali_FeFi,'dd/mm/yyyy') Like '" + FeFi + "'"
        'End If
        If cldec <> "" Then
            Me.FValores.Value += " And cal_cla Like '" + cldec + "'"
        End If

        Me.MsgResult.Text = Me.FValores.Value
        Me.GridView1.DataBind()

    End Sub
    Protected Sub ToolkitScriptManager1_AsyncPostBackError(ByVal sender As Object, ByVal e As System.Web.UI.AsyncPostBackErrorEventArgs) Handles ToolkitScriptManager1.AsyncPostBackError
        If (Not IsNothing(e.Exception)) And (Not IsNothing(e.Exception.InnerException)) Then
            ToolkitScriptManager1.AsyncPostBackErrorMessage = e.Exception.InnerException.Message
        End If

    End Sub

    
    Protected Sub BtnNReg_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        Me.GridView1.PageSize = Me.TxtNReg.Text
    End Sub
End Class
