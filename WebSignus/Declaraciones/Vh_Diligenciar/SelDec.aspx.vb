Imports System.Data
Imports System.Web.Services
Imports System.Threading
Imports System.Guid



Partial Class Declaraciones_Diligenciar_SelDec
    Inherits PaginaComun

    Dim _TotalLiq As String
    Dim ClDec As String = "50"
    Dim ObjVeh As New Vh_Parque_Automotor
    Dim OLiq As New Vh_Liquidaciones

    Dim Per As String = "00"
    Dim AbrirVentana As String = "javascript:window.open('" + Me.RUTA_VIRTUAL + "declaraciones/vh_diligenciar/verprogreso.aspx','Progress','width=400,height=250,menubar=yes,scrollbars=yes,statusbar=yes'); "
    '    Dim AbrirVentanaImp As String = "javascript:window.open('Vh_ImprimirLG.aspx','Progress','width=400,height=250,menubar=yes,scrollbars=yes'); return true;"

    Property sFiltro() As String
        Get
            Return Session("sFiltro")
        End Get
        Set(ByVal value As String)
            Session("sFiltro") = value
        End Set
    End Property

    Property Nro_LiqG As String
        Set(ByVal value As String)
            Session("Nro_LiqG") = value
            TxtNro_LiqG.Text = value
            LbLote.Text = value
        End Set
        Get
            Return Session("Nro_LiqG")
        End Get
    End Property

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Me.LBTITULO.Text = "Diligenciar Declaraciones "
        Me.Opcion = Me.LBTITULO.Text
        Me.SetTitulo()

        'TxtNro_LiqG.Text = Session("Nro_LiqG")
        'Me.ToolkitScriptManager1.RegisterAsyncPostBackControl(Me.ConsultaTer1)
        If Not Me.IsPostBack Then
            Dim dt As DataTable = Me.UsuTercero.GetByUser()
            Me.Nro_LiqG = (Request.QueryString("Nro_LiqG"))
            Me.BtnVerProgreso.Attributes.Add("onclick", AbrirVentana)
            'Me.BtnImprimirG.Attributes.Add("onclick", AbrirVentanaImp)
            BtnLiquidarG.Enabled = False
            'BtnImprimirG.Enabled = False
            BtnVerProgreso.Enabled = True
            Me.Timer1.Enabled = False
            If (dt.Rows.Count > 0) Then
                HdAR.Value = dt.Rows(0)("Ter_TUS").ToString()
                If (dt.Rows(0)("Ter_TUS").ToString() = "AR") Then
                    Me.Agente.Text = dt.Rows(0)("Ter_Nom").ToString
                    Me.Nit.Text = dt.Rows(0)("Ter_nit").ToString
                    Me.Dv.Text = Trim(dt.Rows(0)("Ter_dver").ToString)
                    '----------Tipo de Agente----------------
                    Me.HdTAG.Value = dt.Rows(0)("Ter_tip").ToString
                    '-------------------------
                    Me.BtnBuscDP.Visible = False
                    Me.CboVigencia.DataBind()
                    Me.CboVigencia.SelectedValue = Request("vig")

                Else
                    Me.BtnBuscDP.Visible = True
                End If
            End If
        End If

    End Sub


    Protected Sub BtnBuscDP_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnBuscDP.Click
        Me.ModalPopup.Show()
    End Sub

    Protected Sub button_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles button.Click
    End Sub

    Protected Sub BtnBuscar_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        Me.ModalPopup.Show()
    End Sub

    Protected Sub ToolkitScriptManager1_AsyncPostBackError(ByVal sender As Object, ByVal e As System.Web.UI.AsyncPostBackErrorEventArgs) Handles ToolkitScriptManager1.AsyncPostBackError
        If (Not IsNothing(e.Exception)) And (Not IsNothing(e.Exception.InnerException)) Then
            ToolkitScriptManager1.AsyncPostBackErrorMessage = e.Exception.InnerException.Message + " Error Ajax"
        End If

    End Sub
    'Protected Sub BtnIDil_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles BtnIDil.Click
    '    Me.Diligenciar_Dec()
    'End Sub

    Protected Sub CboVigencia_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles CboVigencia.SelectedIndexChanged
    End Sub

    Protected Sub BtnFiltrar_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles BtnFiltrar.Click

        Actualizar_Filtro_Veh()

    End Sub

    Sub Actualizar_Filtro_Veh()
        sFiltro = Filtrar()
        If Not String.IsNullOrEmpty(sFiltro) Then
            BtnLiquidarG.Enabled = True
            BtnVerProgreso.Enabled = True
        Else
            Me.MsgResult.Text = "Debe escoger al menos una opción de Filtro"
            Me.MsgBoxAlert(MsgResult, True)
            BtnLiquidarG.Enabled = False
            BtnVerProgreso.Enabled = True
            'Exit Sub
        End If
        BtnLiquidarG.Enabled = True
        Me.grdVeh.DataBind()
    End Sub


    Function Filtrar() As String

        Dim cFiltro As String = ""
        'If (ChkNit.Checked = True) And (Not String.IsNullOrEmpty(Nit.Text)) Then
        If (ChkNit.Checked = True) Then
            Util.AddFiltro(cFiltro, " Nit='" + UCase(Nit.Text) + "'")
        End If
        'If (ChkPlaca.Checked = True) And (Not String.IsNullOrEmpty(TxtPlaca.Text)) Then
        If (ChkPlaca.Checked = True) Then
            Util.AddFiltro(cFiltro, " Marca='" + UCase(TxtPlaca.Text) + "'")
        End If

        Return cFiltro
    End Function

    Protected Sub grdVeh_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles grdVeh.RowDataBound
        If e.Row.RowType = DataControlRowType.DataRow Then
            e.Row.Attributes.Add("OnMouseOver", "Resaltar_On(this);")
            e.Row.Attributes.Add("OnMouseOut", "Resaltar_Off(this);")
        End If
    End Sub

    Protected Sub grdVeh_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles grdVeh.SelectedIndexChanged
    End Sub

    Protected Sub Nit_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles Nit.TextChanged
        Dim dt As DataTable = Me.UsuTercero.GetByIde(Nit.Text)
        If (dt.Rows.Count > 0) Then
            Me.Agente.Text = dt.Rows(0)("Ter_Nom").ToString
            Me.Nit.Text = dt.Rows(0)("Ter_nit").ToString
            Me.Dv.Text = Trim(dt.Rows(0)("Ter_dver").ToString)
        Else
            Me.Agente.Text = ""
            Me.Nit.Text = ""
            Me.Dv.Text = ""
        End If
    End Sub
    ''' <summary>
    ''' LIQUIDACION INDIVIDUAL
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Protected Sub grdVeh_RowCommand(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewCommandEventArgs) Handles grdVeh.RowCommand
        Dim index As Integer = Convert.ToInt32(e.CommandArgument)
        Me.grdVeh.SelectedIndex = index
        Dim dec_cod As String = Me.grdVeh.DataKeys(index)("Dec_Cod").ToString
        Dim Placa As String = Me.grdVeh.DataKeys(index)("Placa").ToString
        If e.CommandName = "Imprimir" Then
            If Not String.IsNullOrEmpty(Me.Nro_LiqG) Then
                Me.MsgResult.Text = "Se Generá documento para Imprimir"
                UpdatePanel1.Update()
                Threading.Thread.Sleep(1000)
                Redireccionar_Pagina("/ashx/Vh_RptForm.ashx?Dec_cod=" + dec_cod)
            Else
                ChkPlaca.Checked = True
                TxtPlaca.Text = grdVeh.SelectedValue()
                Actualizar_Filtro_Veh()
                ObjVhPA.DataBind()

                OLiq.InsNroLiqG()
                Me.Nro_LiqG = OLiq.Nro_LiqG
                Me.MsgResult.Text = OLiq.Liquidar(" And Placa='" + Placa + "'", Me.CboVigencia.SelectedValue, Me.Nro_LiqG)
                MsgResult.Text += " Lote N°" + OLiq.Nro_LiqG
                MsgBox(Me.MsgResult, OLiq.lErrorG)
                ObjVhPA.DataBind()
                '           BtnImprimirG.Enabled = True
                TxtNro_LiqG.Text = Me.Nro_LiqG
                UpdatePanel1.Update()
                Redireccionar_Pagina("/ashx/Vh_RptForm.ashx?Dec_cod=" + dec_cod)

                'MsgResult.Text = "Debe Reliquidar el vehiculo individualmente"
                'MsgBoxAlert(MsgResult, True)
            End If
        End If
        If e.CommandName = "Seleccionar" Then
            ChkPlaca.Checked = True
            TxtPlaca.Text = Placa
            Actualizar_Filtro_Veh()
            ObjVhPA.DataBind()
        End If
        If e.CommandName = "Liquidar" Then

            OLiq.InsNroLiqG()
            Me.Nro_LiqG = OLiq.Nro_LiqG
            Me.MsgResult.Text = OLiq.Liquidar(" And Placa='" + grdVeh.SelectedValue + "'", Me.CboVigencia.SelectedValue, Me.Nro_LiqG)
            MsgResult.Text += " Lote N°" + OLiq.Nro_LiqG
            MsgBox(Me.MsgResult, OLiq.lErrorG)

            'BtnImprimirG.Enabled = True
            TxtNro_LiqG.Text = Me.Nro_LiqG
            'Me.grdLog.DataSource = OLiq.GetLiqLog(OLiq.Nro_LiqG)
            'Me.grdLog.DataBind()


        End If

    End Sub

    Protected Sub BtnLiquidarG_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles BtnLiquidarG.Click
        Run()
    End Sub

    Sub Liquidar()
        Dim F As String = Filtrar()
        If Not String.IsNullOrEmpty(F) Then
            F = " And " + F
            BtnLiquidarG.Enabled = True
        Else
            Me.MsgResult.Text = "Debe escoger al menos una opción de Filtro"
            Me.MsgBoxAlert(MsgResult, True)
            BtnLiquidarG.Enabled = False
            Exit Sub
        End If
        OLiq.InsNroLiqG()
        Me.Nro_LiqG = OLiq.Nro_LiqG
        OLiq.cFiltro = F
        OLiq.cVigencia = CboVigencia.SelectedValue

        OLiq.Liquidar()

        Me.MsgResult.Text = OLiq.Msg
        Me.grdVeh.DataBind()
        'Timer1.Enabled = True
        MsgResult.Text += " Lote N°" + OLiq.Nro_LiqG
        MsgBox(Me.MsgResult, ObjVeh.lErrorG)
        If OLiq.lErrorG Then
            'BtnImprimirG.Enabled = False
            BtnLiquidarG.Enabled = True
        Else
            'BtnImprimirG.Enabled = True
            BtnLiquidarG.Enabled = False
        End If
    End Sub

    Protected Sub Timer1_Tick(ByVal sender As Object, ByVal e As System.EventArgs) Handles Timer1.Tick

        If Me.Nro_LiqG <> "" Then
            LabeltIMER.Text = "Actualización: " + DateTime.Now.ToLongTimeString() + "Cantidad Liq" + OLiq.GetUltimaLiquidacion(Me.Nro_LiqG).ToString + "<b> LiqG " + Me.Nro_LiqG + "</b>"
        Else
            LabeltIMER.Text = "Actualización: " + DateTime.Now.ToLongTimeString() + "No Iniciado a Liquidar"
        End If

    End Sub

    <WebMethod()> _
    Public Shared Function Saludame(ByVal Nombre As String) As String
        Return "    Hola a " + Nombre + " desde el servidor, son las " + DateTime.Now.ToString("hh:mm:ss")
    End Function

    Protected Sub BtnVerProgreso_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnVerProgreso.Click


    End Sub

    'Protected Sub BtnImprimirG_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnImprimirG.Click
    '    If Not String.IsNullOrEmpty(Me.Nro_LiqG) Then
    '        Redireccionar_Pagina("/ashx/Vh_RptForm_LG.ashx?Nro_LiqG=" + Me.Nro_LiqG)
    '    Else
    '        MsgResult.Text = "No Hay Grupo Seleccionado de Liquidación"
    '    End If
    'End Sub

    Public Overrides Sub VerifyRenderingInServerForm(ByVal control As Control)

    End Sub

    'Protected Sub BtnExportLog_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnExportLog.Click

    '    Me.GridLog.DataSource = OLiq.GetLiqLog(Me.Nro_LiqG)
    '    Me.GridLog.DataBind()
    '    If GridLog.Rows.Count = 0 Then
    '        Exit Sub
    '    End If
    '    ExportGridView(Me.GridLog, "Log de Resultados de Liquidacion Grupar N° [" + Me.Nro_LiqG + "]")
    'End Sub


    Protected Sub Con_Tercero1_SelClicked(ByVal sender As Object, ByVal e As System.EventArgs) Handles Con_Tercero1.SelClicked
        Me.Agente.Text = Con_Tercero1.Nombre
        Me.Nit.Text = Con_Tercero1.Nit
        Me.Dv.Text = Con_Tercero1.Dv
        Me.ModalPopup.Hide()
        UpdatePanel1.Update()
    End Sub

    Protected Sub BtnParar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnParar.Click
        Me.MsgResult.Text = OLiq.SuspenderLiq(Me.Nro_LiqG)
        MsgBox1(Me.MsgResult, OLiq.lErrorG)
    End Sub


    Public Sub StartThread()

    End Sub

    Private Sub Run()
        Liquidar()
    End Sub

    Protected Sub BtnLiquidarG0_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles BtnLiquidarG0.Click
        Dim F As String = Filtrar()
        If Not String.IsNullOrEmpty(F) Then
            F = " And " + F
            BtnLiquidarG.Enabled = True
        Else
            Me.MsgResult.Text = "Debe escoger al menos una opción de Filtro"
            Me.MsgBoxAlert(MsgResult, True)
            BtnLiquidarG.Enabled = False
            Exit Sub
        End If
        OLiq.InsNroLiqG()
        Me.Nro_LiqG = OLiq.Nro_LiqG
        OLiq.cFiltro = F
        OLiq.cVigencia = CboVigencia.SelectedValue
        Dim hiloLiq As New System.Threading.Thread(New System.Threading.ThreadStart(AddressOf OLiq.Liquidar))
        Dim idPeticion As Guid = NewGuid()
        GestorL._instancia.Add(idPeticion, OLiq)
        'hiloLiq.Priority = ThreadPriority.Highest
        hiloLiq.Start()

        'Response.Redirect(String.Format("EnProceso.aspx?idPeticion={0}", idPeticion.ToString()))
        Response.Redirect(String.Format("Vh_Progreso.aspx?idPeticion={0}", idPeticion.ToString()))
    End Sub

End Class
