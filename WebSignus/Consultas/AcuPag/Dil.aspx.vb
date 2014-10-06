Imports System.Data
Imports Signus

Partial Class Procesos_AcPa_Dil
    Inherits PaginaComun
    Dim objCd As CDeclaraciones
    Dim Total_Saldo As Decimal = 0
    Dim obj As AcuerdosP

    Protected Sub button_Click(ByVal sender As Object, ByVal e As System.EventArgs)
    End Sub



    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not Me.IsPostBack Then
            Me.SetTitulo()
            Me.ToolkitScriptManager1.RegisterAsyncPostBackControl(Me.ConsultaTer1)
            'Me.txtFec.Text = Now.ToShortDateString
            Me.CbCdec.Attributes.Add("OnFocus", "javascript:UpdateCombo()")
            Me.BtnBuscDP.Visible = True
            Try
                querystringSeguro = Me.GetRequest()
                Me.Nit.Text = querystringSeguro("nit")
                If Not String.IsNullOrEmpty(Me.Nit.Text) Then
                    Dim oTer As New Terceros
                    Dim dtConsulta As New DataTable
                    dtConsulta = oTer.GetByIde(Nit.Text)
                    Me.Agente.Text = dtConsulta.Rows(0)("Ter_Nom").ToString
                    Me.Nit.Text = dtConsulta.Rows(0)("Ter_nit").ToString
                    Me.Dv.Text = Trim(dtConsulta.Rows(0)("Ter_dver").ToString)
                    If (dtConsulta.Rows(0)("Ter_TUS").ToString() = "AR") Then
                        Me.BtnBuscDP.Visible = False
                    End If
                End If
            Catch ex As Exception
                Dim dt As DataTable = Me.UsuTercero.GetByUser()
                If (dt.Rows.Count > 0) Then
                    Me.Nit.Attributes.Add("onBlur", "javascript:MostrarNit()")
                    dt = Me.UsuTercero.GetByUser()
                    If (dt.Rows(0)("Ter_TUS").ToString() = "AR") Then
                        Me.Agente.Text = dt.Rows(0)("Ter_Nom").ToString
                        Me.Nit.Text = dt.Rows(0)("Ter_nit").ToString
                        Me.Dv.Text = Trim(dt.Rows(0)("Ter_dver").ToString)
                        Me.BtnBuscDP.Visible = False
                    Else
                        Me.BtnBuscDP.Visible = True
                    End If
                End If
            End Try

            

            'Me.ROptTD.SelectedValue = "01"
            'Dim dt As DataTable = Me.UsuTercero.GetByUser()
            '            Me.MsgResult.Text = dt.Rows(0)("Ter_TUS").ToString() + "-" + dt.Rows(0)("TUS_NOM").ToString()
            'If (dt.Rows.Count > 0) Then
            ' If (dt.Rows(0)("Ter_TUS").ToString() = "AR") Then
            'Me.Agente.Text = dt.Rows(0)("Ter_Nom").ToString
            'Me.Nit.Text = dt.Rows(0)("Ter_nit").ToString
            ' Me.Dv.Text = Trim(dt.Rows(0)("Ter_dver").ToString)
            ' Me.HdFODE.Value = dt.Rows(0)("Ter_tip").ToString
            ' Me.TxtRep.Text = dt.Rows(0)("Ter_repo").ToString
            ' Me.BtnBuscDP.Visible = False
            '     Me.BtnAnular.Visible = False
            'Else
            '    Me.BtnBuscDP.Visible = True
            '      Me.BtnAnular.Visible = True
            'End If
            'End If
        End If

        'Response.Write(Pais_Navegador)
    End Sub

    
    Protected Sub DataList1_ItemDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.DataListItemEventArgs)


        If e.Item.ItemType = ListItemType.Header Then
            Me.Total_Saldo = 0
        ElseIf e.Item.ItemType = ListItemType.Item OrElse e.Item.ItemType = ListItemType.AlternatingItem Then
            Me.Total_Saldo += CDec(DirectCast(e.Item.DataItem, DataRowView)("Saldo_a_Cargo"))

            Dim _grDetalle As GridView = e.Item.FindControl("grDetalle")


            Dim car_ano As String = CDec(DirectCast(e.Item.DataItem, DataRowView)("car_ano"))
            Dim car_per As String = CDec(DirectCast(e.Item.DataItem, DataRowView)("car_per"))
            'Dim obj As AcuerdosP = New AcuerdosP
            '_grDetalle.DataSource = obj.GetCarteraD(Me.Nit.Text, Me.CbCdec.SelectedValue, car_ano, car_per)
            '_grDetalle.DataBind()
            Me.MsgResult.Text += car_ano + car_per

        ElseIf e.Item.ItemType = ListItemType.Footer Then
            'Dim lblCount As Label = TryCast(e.Item.FindControl("lblItemCount"), Label)
            'lblCount.Text = "Count: " & DataList1.Items.Count
            Dim lblSum As Label = TryCast(e.Item.FindControl("lbTSaldo"), Label)
            lblSum.Text = FormatNumber(Me.Total_Saldo)
        End If




    End Sub

    Protected Sub BtnBuscar_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        Me.ModalPopupTer.Show()
    End Sub

    Protected Sub CbCdec_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs)

    End Sub

    Protected Sub DataList1_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs)

    End Sub

    Protected Sub GridView2_RowCommand(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewCommandEventArgs)

        'MultiView1.ActiveViewIndex = -1
        Dim index As Integer = Convert.ToInt32(e.CommandArgument)
        Me.GridView2.SelectedIndex = index

        Select Case e.CommandName
            Case "VerDetalle"

                Me.MultiView1.ActiveViewIndex = 0

            Case "VerCuotas"
                
                Me.MultiView1.ActiveViewIndex = 1

        End Select


    End Sub

    Protected Sub GridView2_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs)

    End Sub

    Protected Sub ToolkitScriptManager1_AsyncPostBackError(ByVal sender As Object, ByVal e As System.Web.UI.AsyncPostBackErrorEventArgs) Handles ToolkitScriptManager1.AsyncPostBackError
        If (Not IsNothing(e.Exception)) And (Not IsNothing(e.Exception.InnerException)) Then
            ToolkitScriptManager1.AsyncPostBackErrorMessage = e.Exception.InnerException.Message
        End If
    End Sub

    Protected Sub lbVolver_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lbVolver.Click
        querystringSeguro = Me.SetRequest()
        querystringSeguro("nit") = Nit.Text
        Redireccionar_Pagina("Consultas/PanelAgente/PanelAgente.aspx?data=" + HttpUtility.UrlEncode(querystringSeguro.ToString()))
    End Sub
End Class



