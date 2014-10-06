Imports System.Data
Imports System.Data.OleDb
Imports Signus

Partial Class DatosBasicos_AgentesR_Signatarios
    Inherits PaginaComun
    Dim NroRenglon As String = "00"
    Dim objCd As CDeclaraciones = New CDeclaraciones
    Dim Objsig As Signatario = New Signatario
    Dim NomDec As String
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Me.SetTitulo()
        If Not Me.IsPostBack Then
            Me.Cargar_Tipo_usuario()
            Me.Cargar_TerceroAct()
        End If
    End Sub

    Protected Sub BtnBuscDP_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnBuscDP.Click
        Me.ConsultaTer1.Ret = "PD"
        Me.ConsultaTer1.TextoBusqueda = ""
        Me.Label49.Text = "PD"
        Me.HdTipo.Value = "PD"
        If Me.Nit.Text <> "" Then
            Me.ModalPopupTer.Show()
        Else
            Me.MsgResult.Text = "Aún no ha Seleccionado el Agente al Cual le Asignara los Signatarios"
            MsgBox(Me.MsgResult, True)
        End If
    End Sub

    Protected Sub BtnBuscRF_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        Me.ConsultaTer1.Ret = "RF"
        Me.Label49.Text = "RF"
        Me.HdTipo.Value = "RF"
        Me.ConsultaTer1.TextoBusqueda = ""
        If Me.Nit.Text <> "" Then
            Me.ModalPopupTer.Show()
        Else
            Me.MsgResult.Text = "Aún no ha Selccionado el Agente al Cual le Asignará los Signatarios"
            MsgBox(Me.MsgResult, True)
        End If

    End Sub
    Protected Sub Guardar()
        Me.MsgResult.Text = ""

        Dim ObjSig As Signatario = New Signatario
        If Me.TXTNRODOC_RF.Text = Me.TXTNRODOC_PD.Text Then
            Me.MsgResult.Text = "Los Signatarios deben Ser distintos"
            Me.MsgBox(MsgResult, True)
        Else
            If Me.Operacion.Value = "Guardar" Then
                MsgResult.Visible = True

                MsgResult.Text = ObjSig.Insert("NI", Me.Nit.Text, Me.Dv.Text, Me.TXTTIPDOC_RF.Text, Me.TXTNRODOC_RF.Text, Me.CbTFIRMANTE_RF.SelectedValue, Me.TXTTRAPRO_RF.Text, Me.TXTTIPDOC_PD.Text, Me.TXTNRODOC_PD.Text, Me.CbTFIRMANTE_PD.SelectedValue)
                Me.MsgBox(MsgResult, ObjSig.lErrorG)
                If ObjSig.lErrorG = False Then
                    Me.Operacion.Value = "Editar"
                    Me.MultiView1.ActiveViewIndex = 0
                    Me.FormView1.DataBind()
                End If
            Else
                MsgResult.Visible = True

                MsgResult.Text = ObjSig.update(Nit.Text, Me.Dv.Text, "NI", Me.Nit.Text, Me.Dv.Text, Me.TXTTIPDOC_RF.Text, Me.TXTNRODOC_RF.Text, Me.CbTFIRMANTE_RF.SelectedValue, Me.TXTTRAPRO_RF.Text, Me.TXTTIPDOC_PD.Text, Me.TXTNRODOC_PD.Text, Me.CbTFIRMANTE_PD.SelectedValue)
                Me.MsgBox(MsgResult, ObjSig.lErrorG)
                If ObjSig.lErrorG = False Then
                    Me.MultiView1.ActiveViewIndex = 0
                    Me.FormView1.DataBind()
                End If
            End If
        End If
    End Sub
    Protected Sub BtnCrearTer_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        'Me.ModPopCearTer.Show()
    End Sub
    Protected Sub LinkButton1_Click1(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnNuev.Click
        CrearNuevoTer()
    End Sub
    Private Sub CrearNuevoTer()
        LimpiarTextosTer()
        Me.Oper.Value = "Nuevo"
        Me.CbTdoc.SelectedValue = "CC"
        Me.ModalPopupTer3.Show()
    End Sub
    Protected Sub CargAR_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        LIMPIAR()
        Me.ModalPopup.Show()
    End Sub

    Protected Sub Cargar_Tercero()
        Dim nit As String = Me.Nit.Text
        Dim obj As Terceros = New Terceros
        Dim dt As DataTable = obj.GetByIde(nit)
        If dt.Rows.Count > 0 Then
            Me.MsgResult.Text = ""
            Me.Tip_Us.Value = dt.Rows(0)("Ter_TUS").ToString
            Me.Agente.Text = dt.Rows(0)("Ter_Nom").ToString
            Me.Nit.Text = dt.Rows(0)("Ter_nit").ToString
            Me.DV.Text = dt.Rows(0)("Ter_dver").ToString
            Me.OldNit.Value = dt.Rows(0)("Ter_nit").ToString
            Me.OldDver.Value = dt.Rows(0)("Ter_dver").ToString
            Cargar_Signatarios(dt.Rows(0)("Ter_nit").ToString)
        Else
            MsgBox(MsgResult, True)
            Me.MsgResult.Text = "No tiene asociado Tercero"
        End If
    End Sub
    Protected Sub Cargar_TerceroAct()
        Select Case Me.Tip_Us.Value
            Case "AR"
                Dim dt As DataTable = Me.UsuTercero.GetByUser()
                If dt.Rows.Count > 0 Then
                    Me.Agente.Text = dt.Rows(0)("Ter_Nom").ToString
                    Me.Nit.Text = dt.Rows(0)("Ter_nit").ToString
                    Me.Dv.Text = dt.Rows(0)("Ter_dver").ToString
                    Me.OldNit.Value = dt.Rows(0)("Ter_nit").ToString
                    Me.OldDver.Value = dt.Rows(0)("Ter_dver").ToString
                    Me.Nit.Enabled = False
                    Cargar_Signatarios(dt.Rows(0)("Ter_nit").ToString)
                    Me.BtnBuscAR.Visible = False
                Else
                    MsgBox(MsgResult, True)
                    Me.MsgResult.Text = "No tiene asociado Tercero"
                End If
            Case "RT"
                Me.BtnBuscAR.Visible = True
            Case "OT"
                Me.BtnEdit.Visible = False
        End Select
    End Sub

    Protected Sub Cargar_Signatarios(ByVal NitTer As String)

        Dim Datos As DataTable = Me.Objsig.GetRecords(NitTer)
        If Datos.Rows.Count > 0 Then
            Me.TXTTIPDOC_PD.Text = Datos.Rows(0)("DEC_TDOC").ToString
            Me.TXTNRODOC_PD.Text = Datos.Rows(0)("DEC_NIT").ToString
            Me.TXTDV_PD.Text = Datos.Rows(0)("DEC_DVER").ToString
            Me.TXTRAZSOC_PD.Text = Datos.Rows(0)("DEC_NOM").ToString
            Me.CbTFIRMANTE_PD.SelectedValue = Datos.Rows(0)("DEC_TIP").ToString

            Me.TXTTIPDOC_RF.Text = Datos.Rows(0)("REV_TDOC").ToString
            Me.TXTNRODOC_RF.Text = Datos.Rows(0)("REV_NIT").ToString
            Me.TXTDV_RF.Text = Datos.Rows(0)("REV_DVER").ToString
            Me.TXTRAZSOC_RF.Text = Datos.Rows(0)("REV_NOM").ToString
            Me.CbTFIRMANTE_RF.SelectedValue = Datos.Rows(0)("REV_TREV").ToString
            Me.TXTTRAPRO_RF.Text = Datos.Rows(0)("REV_TAR_PRO").ToString
            Me.Operacion.Value = "Editar"
        Else
            Me.Operacion.Value = "Guardar"
        End If

    End Sub
    Protected Sub BtnTipUS_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs)
        LIMPIAR()
        Me.Cargar_Tercero()
    End Sub

    Protected Sub Cargar_Tipo_usuario()
        Dim dt As DataTable = Me.UsuTercero.GetByUser()
        If dt.Rows.Count > 0 Then
            Me.Tip_Us.Value = dt.Rows(0)("Ter_tus").ToString
        End If
    End Sub
    Protected Sub LIMPIAR()
        Me.TXTTIPDOC_PD.Text = ""
        Me.TXTNRODOC_PD.Text = ""
        Me.TXTDV_PD.Text = ""
        Me.TXTRAZSOC_PD.Text = ""
        Me.TXTTIPDOC_RF.Text = ""
        Me.TXTNRODOC_RF.Text = ""
        Me.TXTDV_RF.Text = ""
        Me.TXTRAZSOC_RF.Text = ""
        Me.TXTTRAPRO_RF.Text = ""
    End Sub
    Protected Sub BtnBuscar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnBuscAR.Click
        Me.HdTipo.Value = "AR"

        Me.ModalPopup.Show()
    End Sub
    Protected Sub button_Click(ByVal sender As Object, ByVal e As System.EventArgs)

    End Sub
    
    Protected Sub Editar_Signatario()
        If Me.Nit.Text <> "" Then
            Me.MultiView1.ActiveViewIndex = 1
            Cargar_Signatarios(Me.Nit.Text)
        Else
            Me.MsgResult.Text = "Debe Seleccionar un Tercero"
            'Me.MsgBox(Me.MsgResult, True)
        End If
    End Sub

    Protected Sub BtnCancelar_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        Me.MultiView1.ActiveViewIndex = 0
    End Sub

    Protected Sub BtnSave_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        Guardar()
    End Sub

    Protected Sub BtnSave2_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) 'Handles BtnSave2.Click
        GuardarTercero()
    End Sub

    Sub GuardarTercero()
        Select Case Me.Oper.Value
            Case "Nuevo"
                Me.MsgResult.Text = Objsig.InsertSig(Me.CbTdoc.SelectedValue, Me.TxtNit.Text, Me.TxtNom.Text, Me.CbMun.SelectedValue, Me.TxtEma.Text, Me.TxtTel.Text, Me.TxtDir.Text, Me.TxtObs.Text)
                Me.MsgBox(Me.MsgResult, Objsig.lErrorG)
            Case "Editar"
                Me.MsgResult.Text = Objsig.UpdateSig(Me.PK.Value, Me.CbTdoc.SelectedValue, Me.TxtNit.Text, Me.TxtNom.Text, Me.CbMun.SelectedValue, Me.TxtEma.Text, Me.TxtTel.Text, Me.TxtDir.Text, Me.TxtObs.Text)
                Me.MsgBox(Me.MsgResult, Objsig.lErrorG)
                Editar_Signatario()
        End Select
        
    End Sub

    Protected Sub BtnEdit_Click1(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles BtnEdit.Click
        Editar_Signatario()
    End Sub

    Protected Sub BtnSave3_Click1(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles BtnSave3.Click
        Guardar()
    End Sub

    Protected Sub BtnCancelar2_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs)
        Me.MultiView1.ActiveViewIndex = 0
    End Sub

    
    Protected Sub btnBorrarRF_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        Me.TXTDV_RF.Text = ""
        Me.TXTNRODOC_RF.Text = ""
        Me.TXTRAZSOC_RF.Text = ""
        Me.TXTTIPDOC_RF.Text = ""
        Me.TXTTRAPRO_RF.Text = ""
        Me.CbTFIRMANTE_RF.Text = ""
    End Sub

    Protected Sub ToolkitScriptManager1_AsyncPostBackError(ByVal sender As Object, ByVal e As System.Web.UI.AsyncPostBackErrorEventArgs) Handles ToolkitScriptManager1.AsyncPostBackError
        If (Not IsNothing(e.Exception)) And (Not IsNothing(e.Exception.InnerException)) Then
            ToolkitScriptManager1.AsyncPostBackErrorMessage = e.Exception.InnerException.Message
        End If

    End Sub

    Protected Sub BtnNuevo_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles BtnNuevo.Click
        CrearNuevoTer()
    End Sub

    Private Sub LimpiarTextosTer()
        Me.TxtNit.Text = ""
        'Me.CbTdoc.SelectedValue
        Me.TxtNom.Text = ""
        Me.TxtEma.Text = ""
        Me.TxtTel.Text = ""
        Me.TxtDir.Text = ""
        Me.TxtObs.Text = ""
    End Sub

    Protected Sub ImageButton1_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles ImageButton1.Click
        If TXTNRODOC_PD.Text = "" Then
            Me.MsgResult.Text = "No se ha registrado signatario Declarante aún"
            Me.MsgBox(MsgResult, True)
        Else
            EditTer()

        End If
    End Sub
    Sub EditTer()
        Me.Oper.Value = "Editar"
        Dim objsig As New Terceros
        Dim dt As DataTable = objsig.GetByIde(Me.TXTNRODOC_PD.Text)
        Me.PK.Value = dt.Rows(0)("TER_NIT").ToString
        Me.CbTdoc.SelectedValue = dt.Rows(0)("TER_TDOC").ToString
        Me.TxtNit.Text = dt.Rows(0)("TER_NIT").ToString
        Me.TxtNom.Text = dt.Rows(0)("TER_NOM").ToString
        Me.CbMun.SelectedValue = dt.Rows(0)("TER_MPIO").ToString
        Me.TxtDir.Text = dt.Rows(0)("TER_DIR").ToString
        Me.TxtEma.Text = dt.Rows(0)("TER_EMAI").ToString
        Me.TxtTel.Text = dt.Rows(0)("TER_TEL").ToString
        Me.TxtObs.Text = dt.Rows(0)("TER_OBS").ToString
        Me.ModalPopupTer3.Show()
    End Sub
    Sub EditTerRF()
        Me.Oper.Value = "Editar"
        Dim objsig As New Terceros
        Dim dt As DataTable = objsig.GetByIde(Me.TXTNRODOC_RF.Text)
        Me.PK.Value = dt.Rows(0)("TER_NIT").ToString
        Me.CbTdoc.SelectedValue = dt.Rows(0)("TER_TDOC").ToString
        Me.TxtNit.Text = dt.Rows(0)("TER_NIT").ToString
        Me.TxtNom.Text = dt.Rows(0)("TER_NOM").ToString
        Me.CbMun.SelectedValue = dt.Rows(0)("TER_MPIO").ToString
        Me.TxtDir.Text = dt.Rows(0)("TER_DIR").ToString
        Me.TxtEma.Text = dt.Rows(0)("TER_EMAI").ToString
        Me.TxtTel.Text = dt.Rows(0)("TER_TEL").ToString
        Me.TxtObs.Text = dt.Rows(0)("TER_OBS").ToString
        Me.ModalPopupTer3.Show()

    End Sub

    Protected Sub ImgEditCT_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles ImgEditCT.Click
        If TXTNRODOC_RF.Text = "" Then
            Me.MsgResult.Text = "No se ha registrado signatario CONTADOR O REVISOR FISCAL aún"
            Me.MsgBox(MsgResult, True)
        Else
            EditTerRF()

        End If
    End Sub
End Class
