Imports System.Data
Imports Tawammar.CustomControls

Partial Class DatosBasicos_Parametros_Parametros
    Inherits PaginaComun
    Dim Obj As Parametros = New Parametros


    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Me.Opcion = Me.Tit.Text
        Me.SetTitulo()
        If Not IsPostBack Then

        End If
    End Sub
   
    Private Sub FillCustomerInGrid()
        Me.GridView2.DataBind()
        Me.GridView1.DataBind()
    End Sub

    Protected Sub GridView2_RowCommand(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewCommandEventArgs)
        Me.Oper.Value = e.CommandName

        Select Case Me.Oper.Value
            Case "Seleccionar"
                Dim index As Integer = Convert.ToInt32(e.CommandArgument)
                Me.GridView2.SelectedIndex = index
                Me.MsgResult.Text = "Selecionar: Código [" + CStr(GridView2.SelectedValue) + "]"
          
            Case "Editar"
                Me.TituloPoup.Text = "Editar"
                Me.ModalPopupTer.Show()
                Dim index As Integer = Convert.ToInt32(e.CommandArgument)
                Me.GridView2.SelectedIndex = index
                Dim tb As DataTable = Obj.GetPARLIQDET(GridView2.DataKeys(index).Values(0).ToString(), GridView2.DataKeys(index).Values(1).ToString())
                If tb.Rows.Count > 0 Then
                    Me.TxtPcod.Text = tb.Rows(0)("PALI_PLCO").ToString
                    Me.Txtcod.Text = tb.Rows(0)("PALI_COID").ToString
                    Me.TxtFecIni.Text = CDate(tb.Rows(0)("PALI_FEIN").ToString).ToShortDateString
                    Me.TxtFecFin.Text = CDate(tb.Rows(0)("PALI_FEFI").ToString).ToShortDateString
                    Me.TxtVal.Text = tb.Rows(0)("PALI_VALO").ToString
                    Me.TxtPDec.Text = tb.Rows(0)("PAR_DEC").ToString

                End If
                Me.MsgResult.Text = "Editando: Código [" + Me.Txtcod.Text + "]"

            Case "Eliminar"
                Dim index As Integer = Convert.ToInt32(e.CommandArgument)
                Me.GridView2.SelectedIndex = index
                Me.MsgResult.Text = "eliminar"
                Me.MsgResult.Text = Obj.DelParliq(GridView2.DataKeys(index).Values(0).ToString(), GridView2.DataKeys(index).Values(1).ToString())

                Me.MsgBox(MsgResult, Obj.lErrorG)
                FillCustomerInGrid()
        End Select
    End Sub



    Protected Sub BtnGuardar_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim VF As String = False
        If Me.Oper.Value = "Editar" Then
            If IsDate(Me.TxtVal.Text) Then
                VF = True
            End If
            Me.MsgResult.Text = Obj.UpdParliQ(Me.TxtPcod.Text, Me.TxtCod.Text, Me.TxtFecIni.Text, Me.TxtFecFin.Text, Me.TxtVal.Text, Me.TxtPDec.Text)
        ElseIf Me.Oper.Value = "Nuevo" Then
            If IsDate(Me.TxtVal.Text) Then
                VF = True
            End If
            Me.MsgResult.Text = Obj.InsParliQ(Me.TxtPcod.Text, Me.TxtCod.Text, Me.TxtFecIni.Text, Me.TxtFecFin.Text, Me.TxtVal.Text, Me.TxtPDec.Text, VF)
        End If
        Me.MsgBox(MsgResult, Obj.lErrorG)
        Me.GridView1.DataBind()
        Me.GridView2.DataBind()
    End Sub


    Protected Sub GridView1_RowCommand(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewCommandEventArgs)
        Me.OperPar.Value = e.CommandName
        Select Case Me.OperPar.Value
            Case "Seleccionar"
                Dim index As Integer = Convert.ToInt32(e.CommandArgument)
                Me.GridView1.SelectedIndex = index
                Me.MsgResult.Text = "Selecionar: Código [" + CStr(GridView1.SelectedValue) + "]"

            Case "Editar"
                LbTiTpop2.Text = "Editar"
                Me.ModalPopupTer3.Show()
                Dim index As Integer = Convert.ToInt32(e.CommandArgument)
                Me.GridView1.SelectedIndex = index
                Dim tb As DataTable = Obj.GetParametros(GridView1.SelectedValue)
                If tb.Rows.Count > 0 Then
                    Me.TxtCodP.Text = tb.Rows(0)("PALI_CODI").ToString
                    Me.TxtNomP.Text = tb.Rows(0)("PALI_NOMB").ToString
                    Me.CboTD.SelectedValue = tb.Rows(0)("PALI_TIDA").ToString
                    Me.CboEst.Text = tb.Rows(0)("PALI_ESTA").ToString
                    Me.TxtDescP.Text = tb.Rows(0)("PALI_DESC").ToString
                End If
                Me.MsgResult.Text = "Editando: Código [" + Me.Txtcod.Text + "]"

            Case "Eliminar"
                Dim index As Integer = Convert.ToInt32(e.CommandArgument)
                Me.GridView1.SelectedIndex = index
                Me.MsgResult.Text = Obj.DelPar(GridView1.SelectedValue)
                ' Me.MsgResult.Text = Obj.Delete(GridView1.DataKeys(index).Values(0).ToString())
                Me.MsgBox(MsgResult, Obj.lErrorG)

        End Select
    End Sub


   
    Protected Sub LinkButton1_Click(ByVal sender As Object, ByVal e As System.EventArgs)

        If GridView1.SelectedValue <> "" Then
            Me.TituloPoup.text = "Nuevo"
            Me.TxtPcod.Text = ""
            Me.TxtCod.Text = ""
            Me.TxtFecIni.Text = ""
            Me.TxtFecFin.Text = ""
            Me.TxtVal.Text = ""
            Me.TxtPDec.Text = ""
            Me.Oper.Value = "Nuevo"
            Me.TxtPcod.Text = GridView1.SelectedValue
            Me.ModalPopupTer.Show()


        Else
            Me.MsgResult.Text = "Seleccione un Parametro "
        End If
    End Sub

    Protected Sub BtnGuardarN_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        If Me.OperPar.Value = "Editar" Then
            Me.MsgResult.Text = Obj.UpdPar(Me.TxtCodP.Text, Me.TxtNomP.Text, Me.CboTD.SelectedValue, Me.CboEst.Text, Me.TxtDescP.Text)
        ElseIf Me.OperPar.Value = "Nuevo" Then
            Me.MsgResult.Text = Obj.InsNewPar(Me.TxtCodP.Text, Me.TxtNomP.Text, Me.CboTD.SelectedValue, Me.CboEst.Text, Me.TxtDescP.Text)
        End If
        Me.MsgBox(MsgResult, Obj.lErrorG)
        Me.GridView1.DataBind()
        Me.GridView2.DataBind()
    End Sub
    Protected Sub Newpar_Click(ByVal sender As Object, ByVal e As System.EventArgs)

        Me.TituloPoup.Text = "Nuevo"
        Me.TxtCodP.Text = ""
        Me.TxtNomP.Text = ""
        Me.TxtDescP.Text = ""
        Me.OperPar.Value = "Nuevo"
        Me.TxtPcod.Text = GridView1.SelectedValue
        Me.ModalPopupTer3.Show()
    End Sub

    Protected Sub GridView1_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs)
        If e.Row.RowType = DataControlRowType.DataRow Then
            ' ASIGNA EVENTOS
            e.Row.Attributes.Add("OnMouseOver", "Resaltar_On(this);")
            e.Row.Attributes.Add("OnMouseOut", "Resaltar_Off(this);")
            '            e.Row.Attributes("OnClick") = Page.ClientScript.GetPostBackClientHyperlink(Me.GridView1, "Select$" + e.Row.RowIndex.ToString)
        End If
    End Sub

    Protected Sub GridView2_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs)
        If e.Row.RowType = DataControlRowType.DataRow Then
            ' ASIGNA EVENTOS
            e.Row.Attributes.Add("OnMouseOver", "Resaltar_On(this);")
            e.Row.Attributes.Add("OnMouseOut", "Resaltar_Off(this);")
            '            e.Row.Attributes("OnClick") = Page.ClientScript.GetPostBackClientHyperlink(Me.GridView1, "Select$" + e.Row.RowIndex.ToString)
        End If
    End Sub

    Protected Sub ToolkitScriptManager1_AsyncPostBackError(ByVal sender As Object, ByVal e As System.Web.UI.AsyncPostBackErrorEventArgs) Handles ToolkitScriptManager1.AsyncPostBackError
        If (Not IsNothing(e.Exception)) And (Not IsNothing(e.Exception.InnerException)) Then
            ToolkitScriptManager1.AsyncPostBackErrorMessage = e.Exception.InnerException.Message
        End If

    End Sub


    Protected Sub btnFiltrar_Click(ByVal sender As Object, ByVal e As System.EventArgs)

        
        Dim FeIn As String = DirectCast(GridView2.HeaderRow.FindControl("txtFeIn"), TextBox).Text
        Dim Item As String = DirectCast(GridView2.HeaderRow.FindControl("txtItem"), TextBox).Text
        Dim FeFi As String = DirectCast(GridView2.HeaderRow.FindControl("txtFeFi"), TextBox).Text
        Dim Valo As String = DirectCast(GridView2.HeaderRow.FindControl("txtValo"), TextBox).Text
        Dim Dec As String = DirectCast(GridView2.HeaderRow.FindControl("txtDec"), TextBox).Text

        Me.FValores.Value = ""

        If FeIn <> "" Then
            Me.FValores.Value += " And to_char(Pali_FeIn,'dd/mm/yyyy') Like '" + FeIn + "'"
        End If
        If FeFi <> "" Then
            Me.FValores.Value += " And to_char(Pali_FeFi,'dd/mm/yyyy') Like '" + FeFi + "'"
        End If
        If Item <> "" Then
            Me.FValores.Value += " And Pali_CoId Like '" + Item + "'"
        End If
        If Valo <> "" Then
            Me.FValores.Value += " And Pali_Valo Like '" + Valo + "'"
        End If
        If Dec <> "" Then
            Me.FValores.Value += " And Par_Dec Like '" + Dec + "'"
        End If

        'Me.MsgResult.Text = Me.FValores.Value
        Me.GridView2.DataBind()

        DirectCast(GridView2.HeaderRow.FindControl("txtFeIn"), TextBox).Text = FeIn
        DirectCast(GridView2.HeaderRow.FindControl("txtItem"), TextBox).Text = Item
        DirectCast(GridView2.HeaderRow.FindControl("txtFeFi"), TextBox).Text = FeFi
        DirectCast(GridView2.HeaderRow.FindControl("txtValo"), TextBox).Text = Valo
        DirectCast(GridView2.HeaderRow.FindControl("txtDec"), TextBox).Text = Dec

    End Sub



    Protected Sub GridView1_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs)
        Me.FValores.Value = ""
    End Sub

    Protected Sub btnQFiltrar_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        Me.FValores.Value = ""
        Me.GridView2.DataBind()
    End Sub
End Class

