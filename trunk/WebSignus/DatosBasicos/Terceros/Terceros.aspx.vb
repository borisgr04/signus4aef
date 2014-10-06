Imports System.Data
Imports Signus

Partial Class DatosBasicos_Terceros_Terceros
    Inherits PaginaComun
    Dim Obj As Terceros = New Terceros
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Me.Opcion = Me.Tit.Text
        Me.SetTitulo()
        'var theForm = document.forms['aspnetForm'];
        If Not IsPostBack Then
            FillCustomerInGrid()
            Me.MultiView1.ActiveViewIndex = 1
        End If
        Me.TxtNit.Attributes.Add("onfocusout", "javascript:ColocarNit();")
    End Sub
    Protected Sub GridView1_RowCommand(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewCommandEventArgs)

        Me.MsgResult.Text = ""
        Me.MsgResult.CssClass = ""
        Me.Oper.Value = e.CommandName
        MultiView1.ActiveViewIndex = 1
        Select Case Me.Oper.Value
            Case "Nuevo"
                Me.SubT.Text = "Nuevo..."
                MultiView1.ActiveViewIndex = 0
                Me.SetFocus(Me.CbTdoc)
            Case "Editar"
                Me.SubT.Text = "Editando..."
                Dim index As Integer = Convert.ToInt32(e.CommandArgument)

                If index > 9 Then
                    index = index - (index \ 10) * 10
                End If

                Me.GridView1.SelectedIndex = index
                Dim tb As DataTable = Obj.GetByIde(Me.GridView1.SelectedValue)
                If tb.Rows.Count > 0 Then
                    'If 1 = 0 Then
                    Me.HoldDVer.Value = tb.Rows(0)("TER_DVER").ToString
                    Me.HOldNit.Value = tb.Rows(0)("TER_NIT").ToString
                    Me.HoldTDoc.Value = tb.Rows(0)("TER_TDOC").ToString
                    Me.CbTdoc.SelectedValue = tb.Rows(0)("TER_TDOC").ToString
                    Me.TxtNit.Text = tb.Rows(0)("TER_NIT").ToString
                    Me.TxtDver.Text = tb.Rows(0)("TER_DVER").ToString
                    Me.TxtNom.Text = tb.Rows(0)("TER_NOM").ToString
                    Me.CbTTcer.SelectedValue = tb.Rows(0)("TER_TIP").ToString
                    Me.CbMun.SelectedValue = tb.Rows(0)("TER_MPIO").ToString
                    Me.TxtEma.Text = tb.Rows(0)("TER_EMAI").ToString
                    Me.TxtTel.Text = tb.Rows(0)("TER_TEL").ToString
                    Me.TxtDir.Text = tb.Rows(0)("TER_DIR").ToString
                    Me.TxtCed.Text = tb.Rows(0)("TER_CED").ToString
                    Me.TxtRep.Text = tb.Rows(0)("TER_REP").ToString
                    Me.TxtUsu.Text = tb.Rows(0)("TER_USU").ToString
                    Me.CbTUsu.SelectedValue = tb.Rows(0)("TER_TUS").ToString
                    Me.TxtObs.Text = tb.Rows(0)("TER_OBS").ToString
                    Me.txLugarExp.Text = tb.Rows(0)("TER_REP_EXP").ToString
                End If
                MultiView1.ActiveViewIndex = 0
                Me.MsgResult.Text = "Editando: Código [" + Me.TxtNit.Text + "]"

            Case "Eliminar"

                Dim index As Integer = Convert.ToInt32(e.CommandArgument)
                If index > 9 Then
                    index = index - (index \ 10) * 10
                End If
                Me.GridView1.SelectedIndex = index

                Me.MsgResult.Text = "'" + index.ToString + "'" + Obj.Delete(Trim(GridView1.SelectedValue))


                'Me.MsgResult.Text = "EL Método debe ser implementado"
                Me.MsgBox(MsgResult, Obj.lErrorG)
                FillCustomerInGrid()

            Case "Seleccionar"
                Dim index As Integer = Convert.ToInt32(e.CommandArgument)
                If index > 9 Then
                    index = index - (index \ 10) * 10
                End If

                Me.GridView1.SelectedIndex = index
                Dim tb As DataTable = Obj.GetByIde(Me.GridView1.SelectedValue)
                If tb.Rows.Count > 0 Then
                    'If 1 = 0 Then
                    Me.HoldDVer.Value = tb.Rows(0)("TER_DVER").ToString
                    Me.HOldNit.Value = tb.Rows(0)("TER_NIT").ToString
                    Me.HoldTDoc.Value = tb.Rows(0)("TER_TDOC").ToString
                    Me.CbTdoc.SelectedValue = tb.Rows(0)("TER_TDOC").ToString
                    Me.TxtNit.Text = tb.Rows(0)("TER_NIT").ToString
                    Me.TxtDver.Text = tb.Rows(0)("TER_DVER").ToString
                    Me.TxtNom.Text = tb.Rows(0)("TER_NOM").ToString
                    Me.CbTTcer.SelectedValue = tb.Rows(0)("TER_TIP").ToString
                    Me.CbMun.SelectedValue = tb.Rows(0)("TER_MPIO").ToString
                    Me.TxtEma.Text = tb.Rows(0)("TER_EMAI").ToString
                    Me.TxtTel.Text = tb.Rows(0)("TER_TEL").ToString
                    Me.TxtDir.Text = tb.Rows(0)("TER_DIR").ToString
                    Me.TxtCed.Text = tb.Rows(0)("TER_CED").ToString
                    Me.TxtRep.Text = tb.Rows(0)("TER_REP").ToString
                    Me.CbTUsu.SelectedValue = tb.Rows(0)("TER_TUS").ToString
                    Me.TxtUsu.Text = tb.Rows(0)("TER_USU").ToString
                    Me.txLugarExp.Text = tb.Rows(0)("TER_REP_EXP").ToString
                    Me.CbTdoc.Enabled = False
                    Me.TxtUsu.Enabled = False
                    Me.TxtNit.Enabled = False
                    Me.TxtDver.Enabled = False
                    Me.TxtNom.Enabled = False
                    Me.CbTTcer.Enabled = False
                    Me.CbMun.Enabled = False
                    Me.TxtEma.Enabled = False
                    Me.TxtTel.Enabled = False
                    Me.TxtDir.Enabled = False
                    Me.TxtCed.Enabled = False
                    Me.TxtRep.Enabled = False
                    Me.CbTUsu.Enabled = False
                    Me.txLugarExp.Enabled = False
                    Me.CbEst.Enabled = False
                    Me.TxtObs.Enabled = False
                    Me.BtnSave.Visible = False
                End If
                MultiView1.ActiveViewIndex = 0
                'Me.MsgResult.Text = "Seleccionando: Código [" + Me.TxtNit.Text + "]"
                'Me.MsgResult.Text = Obj.Delete(Me.GridView1.SelectedValue)
                'Me.MsgResult.Text = "EL Método debe ser implementado"
                'Me.MsgBox(MsgResult, Obj.lErrorG)
                'FillCustomerInGrid()
        End Select

    End Sub
    Private Sub FillCustomerInGrid()

        Me.GridView1.DataBind()

    End Sub


    Protected Sub BtnGuardar_Click(ByVal sender As Object, ByVal e As System.EventArgs)

        Guardar()


    End Sub

    Protected Sub Limpiar()

        'Me.CbTdoc.Text = ""
        Me.TxtUsu.Text = ""
        Me.TxtNit.Text = ""
        Me.TxtDver.Text = ""
        Me.TxtNom.Text = ""
        'Me.CbTTcer.SelectedValue = ""
        'Me.CbMun.SelectedValue = ""
        Me.TxtEma.Text = ""
        Me.TxtTel.Text = ""
        Me.TxtDir.Text = ""
        Me.TxtCed.Text = ""
        Me.TxtRep.Text = ""
        'Me.CbTUsu.Text = ""
        'Me.CbEst.Text = ""
        Me.TxtObs.Text = ""
        Me.MultiView1.ActiveViewIndex = 1
        Me.Oper.Value = ""
        Me.txLugarExp.Text = ""
        Me.CbTdoc.Enabled = True
        ' Me.TxtUsu.Enabled = True
        Me.TxtNit.Enabled = True
        Me.TxtDver.Enabled = True
        Me.TxtNom.Enabled = True
        Me.CbTTcer.Enabled = True
        Me.CbMun.Enabled = True
        Me.TxtEma.Enabled = True
        Me.TxtTel.Enabled = True
        Me.TxtDir.Enabled = True
        Me.TxtCed.Enabled = True
        Me.TxtRep.Enabled = True
        Me.CbTUsu.Enabled = True
        Me.txLugarExp.Enabled = True
        Me.CbEst.Enabled = True
        Me.TxtObs.Enabled = True
        Me.BtnSave.Visible = True
    End Sub


    Protected Sub Page_PreRender(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.PreRender
        ' Dim strjscript As String = "function ColocarNit(){"
        ' strjscript = strjscript & "document.forms['aspnetForm']." + Me.TxtUsu.ClientID + ".value=document.forms['aspnetForm']." + Me.TxtNit.ClientID + ".value;"
        ' strjscript = strjscript & "}"
        ' ScriptManager.RegisterClientScriptBlock(Me, GetType(Page), "ColocarNit", strjscript, True)
        'Response.Write(strjscript)
        'strjscript = strjscript & "window.opener.document.aspnetForm.ctl00$FlowerText$TxtNom.value=nom;"
        'strjscript = strjscript & "window.close();window.opener.focus();}"
    End Sub

    Protected Sub GridView1_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs)
        If e.Row.RowType = DataControlRowType.DataRow Then
            ' ASIGNA EVENTOS
            e.Row.Attributes.Add("OnMouseOver", "Resaltar_On(this);")
            e.Row.Attributes.Add("OnMouseOut", "Resaltar_Off(this);")
            '            e.Row.Attributes("OnClick") = Page.ClientScript.GetPostBackClientHyperlink(Me.GridView1, "Select$" + e.Row.RowIndex.ToString)
        End If
    End Sub

    Protected Sub BtnCancel_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs)
        Limpiar()
    End Sub

    Protected Sub BtnBuscar_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs)

        Me.MsgResult.Text = ""
        Me.SubT.Text = "Buscando..."
        Me.FillCustomerInGrid()
        Me.MultiView1.ActiveViewIndex = 1

    End Sub

    Protected Sub Btnsave_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles BtnSave.Click
        Guardar()
    End Sub

    Protected Sub Guardar()

        'System.Threading.Thread.Sleep(10000)
        Dim Obj1 As Terceros = New Terceros
        Select Case Me.Oper.Value
            Case "Nuevo"
                Me.MsgResult.Text = Obj1.Insert(Me.CbTdoc.SelectedValue, Me.TxtNit.Text, Me.TxtDver.Text, Me.TxtNom.Text, Me.CbTTcer.SelectedValue, Me.CbMun.SelectedValue, Me.TxtEma.Text, Me.TxtTel.Text, Me.TxtDir.Text, Me.TxtCed.Text, Me.TxtRep.Text, Me.TxtUsu.Text, Me.CbTUsu.SelectedValue, Me.CbEst.SelectedValue, Me.TxtObs.Text, txLugarExp.Text)
            Case "Editar"
                Me.MsgResult.Text = Obj1.Update(Me.HOldNit.Value, Me.HoldTDoc.Value, Me.HoldDVer.Value, Me.CbTdoc.SelectedValue, Me.TxtNit.Text, Me.TxtDver.Text, Me.TxtNom.Text, Me.CbTTcer.SelectedValue, Me.CbMun.SelectedValue, Me.TxtEma.Text, Me.TxtTel.Text, Me.TxtDir.Text, Me.TxtCed.Text, Me.TxtRep.Text, Me.TxtUsu.Text, Me.CbTUsu.SelectedValue, Me.CbEst.SelectedValue, Me.TxtObs.Text, txLugarExp.Text)
        End Select
        MsgResult.Visible = True
        Me.MsgBox(MsgResult, Obj1.lErrorG)
        FillCustomerInGrid()
        If Obj1.lErrorG = False Then
            Me.Limpiar()
        End If




    End Sub

    Protected Sub BtnAgregar_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs)
        Nuevo()
    End Sub

    Protected Sub Nuevo()
        Limpiar()
        Me.SubT.Text = "Nuevo..."
        MultiView1.ActiveViewIndex = 0
        Me.SetFocus(Me.CbTdoc)
        Me.Oper.Value = "Nuevo"

    End Sub


    Protected Sub GridView1_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs)

    End Sub


    Protected Sub ToolkitScriptManager1_AsyncPostBackError(ByVal sender As Object, ByVal e As System.Web.UI.AsyncPostBackErrorEventArgs) Handles ToolkitScriptManager1.AsyncPostBackError
        If (Not IsNothing(e.Exception)) And (Not IsNothing(e.Exception.InnerException)) Then
            ToolkitScriptManager1.AsyncPostBackErrorMessage = e.Exception.InnerException.Message
        End If

    End Sub
End Class
