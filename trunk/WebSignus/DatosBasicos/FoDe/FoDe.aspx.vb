Imports System.Data

Partial Class DatosBasicos_FoDe_FoDe
    Inherits PaginaComun
    Dim Obj As Formularios_Dec = New Formularios_Dec
    Dim objC As Conc_Cdec = New Conc_Cdec

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Me.Opcion = Me.Tit.Text
        Me.SetTitulo()
        If Not IsPostBack Then
            cargar_cboCCar()
        End If
    End Sub

    Protected Sub Cargar_CboImpto(ByVal Cla As String)
        Dim objI As Impuestos = New Impuestos
        Dim dt As DataTable = objI.GetByCLASE(Cla)
        Me.Cargar_Combo(Me.CboImpto, dt, "Imp_CNom", "Imp_Cod")
    End Sub
    Protected Sub Cargar_CboCCar()
        Dim objI As Conc_Cart = New Conc_Cart
        Me.Cargar_Combo(Me.CboCCar, objI.GetRecords(), "CCar_CNom", "CCar_Cod")
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
                Me.TitConc.Text = "Editar"
                Me.ModalPopupTer3.Show()
                Dim index As Integer = Convert.ToInt32(e.CommandArgument)
                Me.GridView2.SelectedIndex = index
                Dim tb As DataTable = objC.GetPorCod(Me.GridView2.SelectedValue, Me.GridView1.SelectedValue)

                '(GridView2.DataKeys(index).Values(0).ToString(), GridView2.DataKeys(index).Values(1).ToString())
                If tb.Rows.Count > 0 Then
                    Me.CmbCdec2.SelectedValue = tb.Rows(0)("COCD_CDEC").ToString
                    Me.TxtCodC.Text = tb.Rows(0)("COCD_CODI").ToString
                    Me.TxtConc.Text = tb.Rows(0)("COCD_NOMB").ToString
                    Me.Cargar_CboImpto(tb.Rows(0)("COCD_CDEC").ToString)
                    Me.CboImpto.SelectedValue = tb.Rows(0)("COCD_IMPTO").ToString
                    Me.CboSeco.SelectedValue = tb.Rows(0)("COCD_SECO").ToString
                    Me.CboIsVb.SelectedValue = tb.Rows(0)("COCD_ISVB").ToString
                    Me.cargar_cboCCar()
                    Me.CboCCar.SelectedValue = tb.Rows(0)("COCD_CCAR").ToString
                    Me.CboCart.SelectedValue = tb.Rows(0)("COCD_CART").ToString
                    Me.CboTico.SelectedValue = tb.Rows(0)("COCD_TICO").ToString
                    'Me.TxtCCart.Text = tb.Rows(0)("COCD_CCAR").ToString
                    Me.CboCTar.SelectedValue = tb.Rows(0)("COCD_CTAR").ToString
                    Me.CboSum.SelectedValue = tb.Rows(0)("COCD_SUM").ToString
                    Me.CboTMOV.SelectedValue = tb.Rows(0)("COCD_TMOV").ToString
                    Me.TxtABVB.Text = tb.Rows(0)("COCD_ABVB").ToString
                    Me.TxtABVD.Text = tb.Rows(0)("COCD_ABVD").ToString
                    Me.TxtREVB.Text = tb.Rows(0)("COCD_REVB").ToString


                    Me.HdPk1.Value = Me.GridView1.SelectedValue
                    Me.HdPk2.Value = tb.Rows(0)("COCD_CODI").ToString
                Else
                    Me.TitConc.Text = "No encontró datos"
                End If
                Me.MsgResult.Text = "Editando: Código [" + Me.TxtFoWe.Text + "]"

            Case "Eliminar"
                Dim index As Integer = Convert.ToInt32(e.CommandArgument)
                Me.GridView2.SelectedIndex = index
                Me.MsgResult.Text = "eliminar"
                Me.MsgResult.Text = objC.Delete(GridView2.DataKeys(index).Values(0).ToString(), GridView2.DataKeys(index).Values(1).ToString())


                Me.MsgBox(MsgResult, Obj.lErrorG)
                FillCustomerInGrid()
        End Select
    End Sub



    Protected Sub BtnGuardar_Click(ByVal sender As Object, ByVal e As System.EventArgs)

        Me.UpdFode()


    End Sub

    Protected Sub UpdCoCd()
        Dim VF As String = False
        If Me.Oper.Value = "Editar" Then
            If IsDate(Me.TxtFeFi.Text) Then
                VF = True
            End If
            '            Me.MsgResult.Text = Obj.UpdParliq(Me.TxtPcod.Text, Me.TxtCod.Text, Me.TxtFecIni.Text, Me.TxtFecFin.Text, Me.TxtVal.Text, Me.TxtPDec.Text)
        ElseIf Me.Oper.Value = "Nuevo" Then
            If IsDate(Me.TxtFeFi.Text) Then
                VF = True
            End If
            '           Me.MsgResult.Text = Obj.InsParliQ(Me.TxtPcod.Text, Me.TxtCod.Text, Me.TxtFecIni.Text, Me.TxtFecFin.Text, Me.TxtVal.Text, Me.TxtPDec.Text, VF)
        End If
        Me.GridView1.DataBind()
        Me.GridView2.DataBind()
    End Sub


    Protected Sub GridView1_RowCommand(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewCommandEventArgs)
        Me.OperFoDe.Value = e.CommandName
        Select Case Me.OperFoDe.Value
            Case "Seleccionar"
                Dim index As Integer = Convert.ToInt32(e.CommandArgument)
                Me.GridView1.SelectedIndex = index
                Me.MsgResult.Text = "Selecionar: Código [" + CStr(GridView1.SelectedValue) + "]"

            Case "Editar"
                Me.TitFode.Text = "Editar"
                Me.ModalPopupTer.Show()
                Dim index As Integer = Convert.ToInt32(e.CommandArgument)
                Me.GridView1.SelectedIndex = index
                Dim tb As DataTable = Obj.GetPorCod(GridView1.SelectedValue)
                If tb.Rows.Count > 0 Then

                    Me.TxtCodi.Text = tb.Rows(0)("FoDe_Codi").ToString
                    Me.CmbCdec.SelectedValue = tb.Rows(0)("FoDe_Cdec").ToString
                    Me.TxtFoWe.Text = tb.Rows(0)("FoDe_FoWe").ToString
                    Me.TxtRpte.Text = tb.Rows(0)("FoDe_Rpte").ToString
                    Me.TxtFeFi.Text = CDate(tb.Rows(0)("FoDe_FeFi").ToString).ToShortDateString
                    Me.TxtFeIn.Text = CDate(tb.Rows(0)("FoDe_FeIn").ToString).ToShortDateString
                    Me.TxtOpeLP.Text = tb.Rows(0)("FoDe_Oper").ToString
                    Me.TxtOpeVP.Text = tb.Rows(0)("FoDe_OPVP").ToString
                    Me.TxtObs.Text = tb.Rows(0)("FoDe_Obs").ToString
                    Me.CboEsta.SelectedValue = tb.Rows(0)("FoDe_Est").ToString



                End If
                Me.MsgResult.Text = "Editando: Código [" + Me.TxtCodi.Text + "]"

            Case "Eliminar"
                Dim index As Integer = Convert.ToInt32(e.CommandArgument)
                Me.GridView1.SelectedIndex = index
                Me.MsgResult.Text = Obj.Delete(GridView1.SelectedValue)
                Me.MsgBox(MsgResult, Obj.lErrorG)
                Me.FillCustomerInGrid()

        End Select
    End Sub



    Protected Sub LinkButton1_Click(ByVal sender As Object, ByVal e As System.EventArgs)

        If GridView1.SelectedValue <> "" Then
            Me.TitFode.Text = "Nuevo"
            'Me.TxtPcod.Text = ""
            Me.TxtFoWe.Text = ""
            Me.TxtRpte.Text = ""
            Me.TxtFeIn.Text = ""
            Me.TxtFeFi.Text = ""
            Me.TxtOpeVP.Text = ""
            Me.Oper.Value = "Nuevo"
            Me.TxtABVB.Text = ""
            Me.TxtABVD.Text = ""
            'Me.TxtPcod.Text = GridView1.SelectedValue
            Me.ModalPopupTer3.Show()
        Else
            Me.MsgResult.Text = "Seleccione un Parametro "
        End If
    End Sub

    Protected Sub BtnGuardarN_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim COCD_CDEC As String = Me.CmbCdec2.SelectedValue
        Dim COCD_CODI As String = Me.TxtCodC.Text
        Dim COCD_NOMB As String = Me.TxtConc.Text
        Dim COCD_IMPTO As String = Me.CboImpto.SelectedValue
        Dim COCD_SECO As String = Me.CboSeco.SelectedValue
        Dim COCD_ISVB As String = Me.CboIsVb.SelectedValue
        Dim COCD_CCAR As String = Me.CboCCar.SelectedValue
        Dim COCD_CTAR As String = Me.CboCTar.SelectedValue
        Dim COCD_TICO As String = Me.CboTico.SelectedValue
        Dim cocd_cart As String = Me.CboCart.SelectedValue
        Dim cocd_sum As String = Me.CboSum.SelectedValue
        Dim cocd_tmov As String = Me.CboTMOV.SelectedValue

        Dim cocd_rede As String = ""
        Dim cocd_abvb As String = Me.TxtABVB.Text
        Dim cocd_vade As String = ""
        Dim cocd_abvd As String = Me.TxtABVD.Text
        Dim cocd_vaca As String = ""

        Dim cocd_tari As String = ""
        Dim cocd_tsan As String = IIf(COCD_TICO = "S", "S", "N")

        Dim cocd_vaba As String = ""
        Dim cocd_oper As String = ""
        Dim cocd_añsa As String = ""
        Dim cocd_pesa As String = ""

        Dim cocd_fdco As String = Me.GridView1.SelectedValue
        Dim cocd_fdco_o As String = Me.HdPk1.Value
        Dim cocd_codi_o As String = Me.HdPk2.Value
        Dim COCD_REVB As Decimal = CDec(Me.TxtREVB.Text)


        Dim tipo_tar As Decimal = 1

        Dim objC As Conc_Cdec = New Conc_Cdec

        If Me.Oper.Value = "Editar" Then
            Me.MsgResult.Text = objC.Update(cocd_fdco_o, cocd_codi_o, COCD_CDEC, COCD_CODI, COCD_TICO, COCD_NOMB, cocd_rede, cocd_tmov, cocd_abvb, cocd_abvd, cocd_vaca, COCD_SECO, cocd_tari, COCD_IMPTO, cocd_tsan, cocd_cart, cocd_vaba, COCD_ISVB, cocd_oper, COCD_CCAR, cocd_añsa, cocd_pesa, cocd_sum, cocd_fdco, COCD_CTAR, tipo_tar, COCD_REVB)

        ElseIf Me.Oper.Value = "Nuevo" Then
            Me.MsgResult.Text = objC.Insert(COCD_CDEC, COCD_CODI, COCD_TICO, COCD_NOMB, cocd_rede, cocd_tmov, cocd_abvb, cocd_vade, cocd_abvd, cocd_vaca, COCD_SECO, cocd_tari, COCD_IMPTO, cocd_tsan, cocd_cart, cocd_vaba, COCD_ISVB, cocd_oper, COCD_CCAR, cocd_añsa, cocd_pesa, cocd_sum, cocd_fdco, COCD_CTAR, tipo_tar, COCD_REVB)

        End If
        Me.MsgBox(Me.MsgResult, objC.lErrorG)
        Me.FillCustomerInGrid()






    End Sub

    Protected Sub UpdFode()
        Dim fode_codi As String = Me.TxtCodi.Text
        Dim fode_cdec As String = Me.CmbCdec.SelectedValue
        Dim fode_fowe As String = Me.TxtFoWe.Text
        Dim fode_rpte As String = Me.TxtRpte.Text
        Dim fode_fefi As String = Me.TxtFeFi.Text
        Dim fode_fein As Date = Me.TxtFeIn.Text
        Dim fode_oper As String = Me.TxtOpeLP.Text
        Dim fode_opvp As String = Me.TxtOpeVP.Text
        Dim fode_obs As String = Me.TxtObs.Text
        Dim fode_fowi As String = ""
        Dim fode_est As String = CboEsta.SelectedValue
        Dim fode_nomb As String = ""


        If Me.OperFoDe.Value = "Editar" Then
            Me.MsgResult.Text = Obj.Update(fode_codi, fode_cdec, fode_fowe, fode_rpte, fode_fein, fode_fefi, fode_oper, fode_fowi, fode_nomb, fode_est, fode_opvp, fode_obs)
        ElseIf Me.OperFoDe.Value = "Nuevo" Then
            Me.MsgResult.Text = Obj.Insert(fode_codi, fode_cdec, fode_fowe, fode_rpte, fode_fein, fode_fefi, fode_oper, fode_fowi, fode_nomb, fode_est, fode_opvp, fode_obs)
        End If
        Me.MsgBox(Me.MsgResult, Obj.lErrorG)
        Me.FillCustomerInGrid()

    End Sub
    Protected Sub Newpar_Click(ByVal sender As Object, ByVal e As System.EventArgs)

        Me.TitFode.Text = "Nuevo Formulario.."
        Me.TxtCodC.Text = ""
        Me.TxtConc.Text = ""
        'Me.TxtDescP.Text = ""
        Me.OperFoDe.Value = "Nuevo"
        'Me.TxtPcod.Text = GridView1.SelectedValue

        Me.TxtCodi.Text = ""
        Me.TxtFoWe.Text = ""
        Me.TxtRpte.Text = ""
        Me.TxtFeFi.Text = ""
        Me.TxtFeIn.Text = ""
        Me.TxtOpeLP.Text = ""
        Me.TxtOpeVP.Text = ""
        Me.TxtObs.Text = ""

        Me.ModalPopupTer.Show()
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


        Dim FeIn As String = "" '= DirectCast(GridView2.HeaderRow.FindControl("txtFeIn"), TextBox).Text
        Dim Item As String = "" '= DirectCast(GridView2.HeaderRow.FindControl("txtItem"), TextBox).Text
        Dim FeFi As String = "" '= DirectCast(GridView2.HeaderRow.FindControl("txtFeFi"), TextBox).Text
        Dim Valo As String = "" '= DirectCast(GridView2.HeaderRow.FindControl("txtValo"), TextBox).Text
        Dim Dec As String = "" '= DirectCast(GridView2.HeaderRow.FindControl("txtDec"), TextBox).Text

        'Me.FValores.Value = ""

        If FeIn <> "" Then
            '    Me.FValores.Value += " And to_char(Pali_FeIn,'dd/mm/yyyy') Like '" + FeIn + "'"
        End If
        If FeFi <> "" Then
            '   Me.FValores.Value += " And to_char(Pali_FeFi,'dd/mm/yyyy') Like '" + FeFi + "'"
        End If
        If Item <> "" Then
            '  Me.FValores.Value += " And Pali_CoId Like '" + Item + "'"
        End If
        If Valo <> "" Then
            ' Me.FValores.Value += " And Pali_Valo Like '" + Valo + "'"
        End If
        If Dec <> "" Then
            'Me.FValores.Value += " And Par_Dec Like '" + Dec + "'"
        End If

        'Me.MsgResult.Text = Me.FValores.Value
        Me.GridView2.DataBind()

        'DirectCast(GridView2.HeaderRow.FindControl("txtFeIn"), TextBox).Text = FeIn
        'DirectCast(GridView2.HeaderRow.FindControl("txtItem"), TextBox).Text = Item
        'DirectCast(GridView2.HeaderRow.FindControl("txtFeFi"), TextBox).Text = FeFi
        'DirectCast(GridView2.HeaderRow.FindControl("txtValo"), TextBox).Text = Valo
        'DirectCast(GridView2.HeaderRow.FindControl("txtDec"), TextBox).Text = Dec

    End Sub



    Protected Sub GridView1_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs)
        Me.FValores.Value = ""
        Me.MsgResult.CssClass = ""
        Me.CmbCdec2.SelectedValue = Left(GridView1.SelectedValue, 2)
        Me.Cargar_CboImpto(Me.CmbCdec2.SelectedValue)
        Me.MsgResult.Text = ""
        
        '        Me.CboImpto.DataBind()
    End Sub

    Protected Sub btnQFiltrar_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        Me.FValores.Value = ""
        Me.GridView2.DataBind()
    End Sub

    
    Protected Sub TxtCodC_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs)

    End Sub

    Protected Sub BtnCancel_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        Me.MsgResult.Text = Me.CboImpto.SelectedValue
    End Sub

    Protected Sub CboImpto_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs)

    End Sub

    Protected Sub GridView2_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs)
        Me.MsgResult.CssClass = ""
        Me.MsgResult.Text = ""

    End Sub
End Class


