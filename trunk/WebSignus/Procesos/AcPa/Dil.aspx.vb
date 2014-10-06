Imports System.Data
Imports Signus

Partial Class Procesos_AcPa_Dil
    Inherits PaginaComun
    Dim objCd As CDeclaraciones
    Dim Total_Saldo As Decimal = 0
    Dim obj As AcuerdosP

    Protected Sub button_Click(ByVal sender As Object, ByVal e As System.EventArgs)
    End Sub
    Private Sub cargarDatos()
        Try
            Dim dtConsulta As New DataTable
            querystringSeguro = Me.GetRequest()
            lbNumExpe.Text = querystringSeguro("numExp")
            Me.Nit.Text = querystringSeguro("nit")
            CbCdec.DataBind()
            CbCdec.SelectedValue = querystringSeguro("CDec")
            If Not String.IsNullOrEmpty(Me.Nit.Text) Then
                Dim oTer As New Terceros
                dtConsulta = oTer.GetByIde(Nit.Text)
                Me.Agente.Text = dtConsulta.Rows(0)("Ter_Nom").ToString
                Me.Dv.Text = Trim(dtConsulta.Rows(0)("Ter_dver").ToString)
                If (dtConsulta.Rows(0)("Ter_TUS").ToString() = "AR") Then
                    Me.BtnBuscDP.Visible = False
                End If
            End If
            DataList1.DataBind()
            ltituloExpe.Visible = True
            lbNumExpe.Visible = True
        Catch ex As Exception
            lbNumExpe.Text = ""
            ltituloExpe.Visible = False
            lbNumExpe.Visible = False
        End Try
    End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not Me.IsPostBack Then
            cargarDatos()
            Me.SetTitulo()
            Me.ToolkitScriptManager1.RegisterAsyncPostBackControl(Me.ConsultaTer1)
            Me.txtFec.Text = Now.ToShortDateString
            Me.CbCdec.Attributes.Add("OnFocus", "javascript:UpdateCombo()")
            Me.BtnGuardar.Enabled = False
            Me.Opcion = Me.Tit.Text
            Me.SetTitulo()
        End If
    End Sub

    
    Protected Sub DataList1_ItemDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.DataListItemEventArgs) Handles DataList1.ItemDataBound

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
            ' Me.MsgResult.Text += car_ano + car_per

        ElseIf e.Item.ItemType = ListItemType.Footer Then
            'Dim lblCount As Label = TryCast(e.Item.FindControl("lblItemCount"), Label)
            'lblCount.Text = "Count: " & DataList1.Items.Count
            Dim lblSum As Label = TryCast(e.Item.FindControl("lbTSaldo"), Label)
            lblSum.Text = FormatNumber(Me.Total_Saldo)
        End If

        If e.Item.ItemType = ListItemType.AlternatingItem Or e.Item.ItemType = ListItemType.Item Then
            Dim oApg As New Expe_Apg
            Dim dtConsulta As New DataTable
            dtConsulta = oApg.GetPorNumExpe(lbNumExpe.Text)
            If dtConsulta.Rows.Count > 0 Then
                Dim cant_item As Integer = Me.DataList1.Items.Count
                For j As Integer = 0 To dtConsulta.Rows.Count - 1
                    Dim ChkSel As CheckBox = DirectCast(e.Item.FindControl("ChkSel"), CheckBox)
                    Dim LbVig As Label = DirectCast(e.Item.FindControl("lbAño"), Label)
                    Dim LbPeriodo As Label = DirectCast(e.Item.FindControl("LbPer"), Label)
                    'Dim LbSaldo As Label = DirectCast(e.Item.FindControl("LbSaldo"), Label)
                    'LbSaldo.Text = FormatNumber(LbSaldo.Text)
                    ChkSel.Enabled = False
                    If dtConsulta.Rows(j)("EXAP_AGRA").ToString = LbVig.Text And dtConsulta.Rows(j)("EXAP_PGRA").ToString = LbPeriodo.Text Then
                        ChkSel.Checked = True
                        Exit For
                    End If
                Next
            End If
        End If

        If e.Item.ItemType = ListItemType.Item Then
            ' ASIGNA EVENTOS
            e.Item.Attributes.Add("OnMouseOver", "Resaltar_On(this);")
            e.Item.Attributes.Add("OnMouseOut", "Resaltar_Off(this);")
            '            e.Row.Attributes("OnClick") = Page.ClientScript.GetPostBackClientHyperlink(Me.GridView1, "Select$" + e.Row.RowIndex.ToString)
        End If

    End Sub

    Protected Sub Programar()

        Dim deuda As Decimal = 0
        Dim porc_ci As Decimal
        Me.obj = New AcuerdosP

        If Me.TxtPor.Text <> "" Then
            porc_ci = CDec(Me.TxtPor.Text)
        Else
            porc_ci = 0
        End If
        Dim cuota_inicial As Decimal = 0
        Dim ncuotas As Integer

        If Me.TxtNCuotas.Text <> "" Then
            ncuotas = CDec(Me.TxtNCuotas.Text) + 1
        Else
            ncuotas = obj.GetNCuotas()
            Me.TxtNCuotas.Text = ncuotas
        End If
        ncuotas -= 1
        Dim cant_item As Integer = Me.DataList1.Items.Count
        Dim saldo_prog As Decimal
        Dim valor_cuota As Decimal = 0

        Dim fecha_cuotas As Date = Me.txtFec.Text

        Dim sum As Decimal = 0
        Dim dtp As DataTable = obj.CrearTablePeriodos()
        Dim dtrow As DataRow
        For i As Integer = 0 To cant_item - 1
            Dim ChkSel As CheckBox = DirectCast(Me.DataList1.Items(i).FindControl("ChkSel"), CheckBox)
            Dim LbSaldo As Label = DirectCast(Me.DataList1.Items(i).FindControl("LbSaldo"), Label)
            If ChkSel.Checked = True Then
                sum += CDec(LbSaldo.Text)
                dtrow = dtp.NewRow
                'Asigno valores a la nueva  fila
                dtrow("Año") = DirectCast(Me.DataList1.Items(i).FindControl("lbAño"), Label).Text
                dtrow("Periodo") = DirectCast(Me.DataList1.Items(i).FindControl("lbPer"), Label).Text
                'dtrow("Saldo") = DirectCast(Me.DataList1.Items(i).FindControl("lbSaldo"), Label).Text
                dtrow("Saldo") = DirectCast(Me.DataList1.Items(i).FindControl("hdSaldo"), HiddenField).Value
                dtrow("documento") = DirectCast(Me.DataList1.Items(i).FindControl("lbTDOC"), Label).Text
                dtrow("ndocumento") = DirectCast(Me.DataList1.Items(i).FindControl("lbNDOC"), Label).Text
                dtp.Rows.Add(dtrow)
            End If
        Next i
        ViewState("TablaAPG") = dtp
        Me.TxtDeuSel.Text = sum.ToString
        If Me.OptPorc.Checked = True Then
            cuota_inicial = sum * porc_ci / 100
            Me.TxtCuotaI.Text = cuota_inicial
        Else
            cuota_inicial = Me.TxtCuotaI.Text
            porc_ci = cuota_inicial * 100 / sum
        End If
        Dim objcd As CDeclaraciones = New CDeclaraciones()
        saldo_prog = sum - cuota_inicial
        valor_cuota = objcd.RedondearUp(saldo_prog / ncuotas)
        'valor_cuota = (saldo_prog / ncuotas)
        Dim fcuota As Date = fecha_cuotas
        cuota_inicial += saldo_prog - (valor_cuota * ncuotas)
        Me.TxtCuotaI.Text = cuota_inicial
        'Creo la Tabla Temporal de Cuotas
        Dim dtcuotas As DataTable = obj.CrearTableCuotas()
        'CUOTA INICIAL
        dtrow = dtcuotas.NewRow
        'Asigno valores a la nueva  fila
        dtrow("NCuotas") = 0
        dtrow("Fecha_pago") = fcuota.ToShortDateString
        dtrow("Valor_Cuota") = cuota_inicial
        dtcuotas.Rows.Add(dtrow)
        Dim sumcuotas As Decimal = 0, vcuotas As Decimal = 0
        For i As Integer = 2 To ncuotas + 1
            'crea un fila vacia de la tabla dtcuotas
            dtrow = dtcuotas.NewRow
            fcuota = fcuota.AddMonths(1)
            'Asigno valores a la nueva  fila
            dtrow("NCuotas") = i - 1
            dtrow("Fecha_pago") = fcuota.ToShortDateString
            dtrow("Valor_Cuota") = valor_cuota
            dtcuotas.Rows.Add(dtrow)
        Next i
        cuota_inicial = cuota_inicial + sumcuotas
        ViewState("TablaCuotas") = dtcuotas
        'Asigno la Tabla al Gridview
        Me.GridView1.DataSource = dtcuotas
        'Actulizo en pantalla el gridview
        Me.GridView1.DataBind()
        'Response.Write("Seleccionado :" + sum.ToString)
        Me.BtnGuardar.Enabled = True
    End Sub
    Protected Sub BtnBuscar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnBuscDP.Click
        Me.ModalPopupTer.Show()
        LimpiarVentana()
    End Sub

    Protected Sub CbCdec_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs)
        Me.BtnProgramar.Enabled = False
        Me.MultiView1.ActiveViewIndex = 1
    End Sub

    Protected Sub BtnDeuda_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        Me.MultiView1.ActiveViewIndex = 1
    End Sub

    Protected Sub DataList1_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs)

    End Sub

    Protected Sub grDetalle_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs)
        If e.Row.RowType = DataControlRowType.DataRow Then
            ' ASIGNA EVENTOS
            e.Row.Attributes.Add("OnMouseOver", "Resaltar_On(this);")
            e.Row.Attributes.Add("OnMouseOut", "Resaltar_Off(this);")
            '            e.Row.Attributes("OnClick") = Page.ClientScript.GetPostBackClientHyperlink(Me.GridView1, "Select$" + e.Row.RowIndex.ToString)
        End If
    End Sub

    Protected Sub ToolkitScriptManager1_AsyncPostBackError(ByVal sender As Object, ByVal e As System.Web.UI.AsyncPostBackErrorEventArgs) Handles ToolkitScriptManager1.AsyncPostBackError

    End Sub

    Protected Sub BtnProgramar_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles BtnProgramar.Click
        Me.MultiView1.ActiveViewIndex = 0
        Me.obj = New AcuerdosP
        Dim deuda As Decimal = 0
        Dim porc_ci As Decimal = obj.GetPorcMinimo()
        Dim ncuotas As Integer = obj.GetNCuotas()
        Dim cuota_inicial As Decimal = 0
        Dim cant_item As Integer = Me.DataList1.Items.Count
        Dim fecha_cuotas As Date = Me.txtFec.Text
        Dim sum As Decimal = 0
        Dim dtp As DataTable = obj.CrearTablePeriodos()
        Dim dtrow As DataRow
        Dim Años As Decimal = 0
        Dim periodos As String = 0
        For i As Integer = 0 To cant_item - 1
            Dim ChkSel As CheckBox = DirectCast(Me.DataList1.Items(i).FindControl("ChkSel"), CheckBox)
            Dim LbSaldo As Label = DirectCast(Me.DataList1.Items(i).FindControl("LbSaldo"), Label)
            If ChkSel.Checked = True Then
                sum += CDec(LbSaldo.Text)
                dtrow = dtp.NewRow
                'Asigno valores a la nueva  fila
                dtrow("Año") = DirectCast(Me.DataList1.Items(i).FindControl("lbAño"), Label).Text
                'Años += dtrow("Año")
                'periodos += dtrow("periodos")
                dtrow("Periodo") = DirectCast(Me.DataList1.Items(i).FindControl("lbPer"), Label).Text
                dtrow("Saldo") = DirectCast(Me.DataList1.Items(i).FindControl("hdSaldo"), HiddenField).Value
                dtrow("documento") = DirectCast(Me.DataList1.Items(i).FindControl("lbTDOC"), Label).Text
                dtrow("ndocumento") = DirectCast(Me.DataList1.Items(i).FindControl("lbNDOC"), Label).Text
                dtp.Rows.Add(dtrow)
            End If
        Next i

        Me.TxtDeuSel.Text = sum.ToString
        Me.TxtPor.Text = porc_ci
        Me.TxtCuotaI.Text = sum * porc_ci / 100
        Me.TxtNCuotas.Text = ncuotas
        Me.OptPorc.Checked = True
        Programar()
    End Sub

    Protected Sub BtnRLIM_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles BtnRLIM.Click
        If String.IsNullOrEmpty(Nit.Text) Then
            Me.MsgResult.Text = "No ha seleccionado un Agente"
            Me.MsgBox(MsgResult, True)
        Else

            Me.obj = New AcuerdosP
            Me.MsgResult.Text = obj.ReLiquidarInteres(Me.Nit.Text, Me.CbCdec.SelectedValue)
            Me.MsgBox(Me.MsgResult, obj.lErrorG)
            Me.BtnProgramar.Enabled = True
        End If
    End Sub

    Protected Sub CmdProgramar_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles CmdProgramar.Click
        Programar()
    End Sub

    Protected Sub BtnGuardar_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles BtnGuardar.Click
        Me.obj = New AcuerdosP
        Dim dtp As DataTable = ViewState("TablaAPG")
        Dim dtc As DataTable = ViewState("TablaCuotas")
        Dim dt As DataTable
        Dim oNit As New Terceros
        Dim tbNitRepLegal As TextBox
        tbNitRepLegal = FormView1.FindControl("TXTNRODOC_PD")
        dt = oNit.GetByIde(Nit.Text)
        If dt.Rows.Count > 0 Then
            If Not String.IsNullOrEmpty(dt.Rows(0)("TER_REP_EXP").ToString) Then
                Me.MsgResult.Text = Me.obj.Insert(Me.Nit.Text, Me.Dv.Text, Me.CbCdec.SelectedValue, Me.TxtGar.Text, _
                                                 Me.TxtDeuSel.Text, Me.TxtPor.Text, Me.TxtCuotaI.Text, Me.TxtNCuotas.Text, _
                                                dtp, dtc, tbNitRepLegal.Text, dt.Rows(0)("TER_REP"), dt.Rows(0)("TER_REP_EXP"), lbNumExpe.Text)
                Me.MsgBox(MsgResult, obj.lErrorG)
                If Not obj.lErrorG Then
                    MsgResult.Text = MsgResult.Text & "</br> Creado el Acuerdo de Pago No. " & obj.Doc & " de " + dtc.Rows.Count.ToString + " Cuotas"
                    lbNumAcuerdo.Text = "Acuerdo de Pago No. " + obj.Doc
                    BtnGuardar.Enabled = False
                    CmdProgramar.Enabled = False
                End If
            Else
                Me.MsgResult.Text = "El Representante Legal No tien Asociado el lugar de Expedición de la Cedula. </br> Por favor Actualice en Datos Basicos - Terceros"
                Me.MsgBox(MsgResult, True)
            End If
        End If
    End Sub
    Private Sub LimpiarVentana()
        BtnGuardar.Enabled = True
        CmdProgramar.Enabled = True
        BtnProgramar.Enabled = False
        BtnRLIM.Enabled = True
        Nit.Text = ""
        Agente.Text = ""
        ObjCartera.DataBind()
        Dv.Text = ""
        MultiView1.ActiveViewIndex = 1
    End Sub

    Protected Sub lbNumExpe_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lbNumExpe.Click
        querystringSeguro = Me.SetRequest()
        querystringSeguro("numExp") = lbNumExpe.Text
        Redireccionar_Pagina("Expediente/Atram/Atram.aspx?data=" + HttpUtility.UrlEncode(querystringSeguro.ToString()))
    End Sub
End Class



