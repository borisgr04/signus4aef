Imports System.Data
Partial Class Procesos_LCp_LCp
    Inherits PaginaComun
    Dim NroRenglon As String = "9"
    Dim fnTotalizar As String
    Dim objCd As CDeclaraciones
    Dim fecha_dec As Date
    Dim Plazo_dec As Integer
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        'Dim cldec As String = Request.QueryString("Cdec")
        'Dim nit As String = Request.QueryString("Nit")
        'Dim ag As String = Request.QueryString("agravable")
        'Dim pg As String = Request.QueryString("pgravable")
        'Dim Fode As String = Request.QueryString("Fode")
        Me.querystringSeguro = Me.GetRequest()
        Dim ClDec As String = querystringSeguro("Cdec")
        Dim nit As String = querystringSeguro("Nit")
        Dim ag As String = querystringSeguro("agravable")
        Dim pg As String = querystringSeguro("pgravable")
        Dim Fode As String = querystringSeguro("Fode")
        Dim Dec_Cor As String = querystringSeguro("Dec_Cor")

        objCd = New CDeclaraciones(ClDec)
        Dim dt As DataTable
        Me.Nit.Text = nit
        Me.AGravable.Text = ag
        Me.PGravable.Text = pg
        Me.HdFode.Value = Fode
        Me.HdCDec.Value = ClDec
        Me.CmbClDec.SelectedValue = ClDec
        Me.HdDCOD.Value = Dec_Cor
        Me.TxtDecCorrige.Text = Dec_Cor

        'Calcular Fecha de Vencimiento
        Dim objCal As Calendario = New Calendario
        Dim dtc As DataTable
        dtc = objCal.GetPorAñoyPer(Me.HdCDec.Value, Me.AGravable.Text, Me.PGravable.Text)
        'REVISAR SANCIONES E INTERESES
        Dim Cal_Ffin As Date = CDate(dtc.Rows(0)("Cal_Ffin").ToString())
        'Me.fecha_dec = Cal_Ffin
        Dim fecha_lim As Date
        'Plazo de Ejecución

        Me.Plazo_dec = CInt(objCd.GetPlazoDec(Cal_Ffin))

        'Fecha Limite
        fecha_lim = Cal_Ffin.AddDays(Me.Plazo_dec)
        Me.HdFecLim.Value = fecha_lim
        '----------------------------

        Me.SetTitulo()
        'Me.ToolkitScriptManager1.RegisterAsyncPostBackControl(Me.ConsultaTer1)
        If Not Me.IsPostBack Then
            'Me.CbCdec.Attributes.Add("OnFocus", "javascript:UpdateCombo()")
            'Me.ROptTD.SelectedValue = "01"
            dt = Me.UsuTercero.GetByIde(nit)
            'Me.MsgResult.Text = dt.Rows(0)("Ter_TUS").ToString() + "-" + dt.Rows(0)("TUS_NOM").ToString()
            If (dt.Rows.Count > 0) Then
                If (dt.Rows(0)("Ter_TUS").ToString() = "AR") Then
                    Me.Agente.Text = dt.Rows(0)("Ter_Nom").ToString
                    Me.Nit.Text = dt.Rows(0)("Ter_nit").ToString
                    Me.DV.Text = Trim(dt.Rows(0)("Ter_dver").ToString)
                    Me.HdTAG.Value = dt.Rows(0)("Ter_tip").ToString
                    '       Me.BtnBuscDP.Visible = False
                    '     Me.BtnAnular.Visible = False
                Else
                    '      Me.BtnBuscDP.Visible = True
                    '      Me.BtnAnular.Visible = True
                End If
            End If
        End If
        Dim p As Procesos = New Procesos
        Dim dta As DataTable = p.GetLCAritmetica(Me.HdDCOD.Value)

        Me.fnTotalizar = "javascript:TotalizarCA(" & dta.Rows.Count & ",0,'',1000);"

    End Sub

    Protected Function NRenglon() As String

        NroRenglon = CStr(CInt(NroRenglon) + 1).PadLeft(2, "0")
        Return NroRenglon

    End Function

    Protected Sub DataList1_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs)

    End Sub

    Protected Sub DataList1_ItemDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.DataListItemEventArgs)
        If e.Item.ItemType = ListItemType.Item Or e.Item.ItemType = ListItemType.AlternatingItem Then
            ' ASIGNA EVENTOS
            Dim TxtR As TextBox = DirectCast(e.Item.FindControl("TxtR"), TextBox)
            Dim TxtVD As TextBox = DirectCast(e.Item.FindControl("TxtVD"), TextBox)
            Dim TxtValBas As TextBox = DirectCast(e.Item.FindControl("TxtValBas"), TextBox)
            Dim TxtValBasD As TextBox = DirectCast(e.Item.FindControl("TxtValBasD"), TextBox)
            Dim txtTar As TextBox = DirectCast(e.Item.FindControl("txtTari"), TextBox)
            txtTar.ReadOnly = True
            Dim HdTari As HiddenField = DirectCast(e.Item.FindControl("HdTARI"), HiddenField)
            Dim HdCTAR As HiddenField = DirectCast(e.Item.FindControl("HdCTAR"), HiddenField)
            Dim HdIsVb As HiddenField = DirectCast(e.Item.FindControl("HdIsVb"), HiddenField)



            If HdIsVb.Value = "N" Then
                TxtValBas.Text = ""
                TxtValBasD.Text = ""
                TxtValBasD.Enabled = False
                txtTar.Text = ""
            End If

            'If HdCTAR.Value = "S" Then
            If HdIsVb.Value = "S" Then
                'TxtR.ReadOnly = True
            Else
                TxtR.ReadOnly = False
                'If CDbl(HdCTAR.Value) = "S" Then
                'LbTar.Text = CStr(Tarifa(HdIMPTO.Value) * 100) + "%"
                'Else
                'LbTar.Text = "$" + FormatNumber(Tarifa(HdIMPTO.Value))
                'End If
                'HdTari.Value = Tarifa(HdIMPTO.Value)
            End If
            'Operaciones
            If Me.HdCDec.Value = "02" Then
                TxtValBas.Attributes.Add("onBlur", Me.fnTotalizar + "Resaltar_Off(this);redondear_input(this,1000);")
                TxtR.Attributes.Add("onBlur", Me.fnTotalizar + "Resaltar_Off(this);redondear_input(this,1000);")
            Else
                TxtValBas.Attributes.Add("onBlur", Me.fnTotalizar + "Resaltar_Off(this);redondear_input(this,1000);")
                TxtR.Attributes.Add("onBlur", Me.fnTotalizar + "Resaltar_Off(this);redondear_input(this,1000);")
            End If
            TxtValBas.Attributes.Add("onFocus", "Resaltar_On(this);")
            'definición de Renglones ReadOnly- Sumados o calculados
            If (HdCTAR.Value = "S") Then
                '   TxtR.Attributes.Add("onFocus", "ResaltarD_On(this)")
                '  TxtR.ReadOnly = True
                If Me.HdCDec.Value = "02" Then
                    '     TxtValBas.Attributes.Add("onBlur", Me.fnTotalizar + "Resaltar_Off(this);")
                Else
                    '    TxtValBas.Attributes.Add("onBlur", Me.fnTotalizar + "Resaltar_Off(this);redondear_input(this,1000);")
                End If
            Else
                'TxtR.Attributes.Add("onFocus", "Resaltar_On(this)")
            End If
        End If
    End Sub


    Public Function Cargar_CODE() As LPCODE_CDEC()

        Me.Label2.Text = ""
        Dim Cant As Integer = Me.DataList1.Items.Count
        Dim LiqP(Cant - 1) As LPCODE_CDEC
        objCd = New CDeclaraciones
        Dim Tr As Double = 0
        Dim r As Integer = 0
        Dim j As Integer = 0
        For i As Integer = 0 To Cant - 1
            Dim txtR As TextBox = DirectCast(Me.DataList1.Items(i).FindControl("TxtR"), TextBox)
            Dim HdCodi As HiddenField = DirectCast(Me.DataList1.Items(i).FindControl("HdCodi"), HiddenField)
            Dim HdIsVB As HiddenField = DirectCast(Me.DataList1.Items(i).FindControl("HdIsVB"), HiddenField)
            Dim HdTICO As HiddenField = DirectCast(Me.DataList1.Items(i).FindControl("HdTICO"), HiddenField)
            Dim HdCimp As HiddenField = DirectCast(Me.DataList1.Items(i).FindControl("HdCimp"), HiddenField)
            Dim HdSECO As HiddenField = DirectCast(Me.DataList1.Items(i).FindControl("HdSECO"), HiddenField)
            Dim HdTMOV As HiddenField = DirectCast(Me.DataList1.Items(i).FindControl("HdTMOV"), HiddenField)
            Dim HdCART As HiddenField = DirectCast(Me.DataList1.Items(i).FindControl("HdCART"), HiddenField)
            Dim HdCCAR As HiddenField = DirectCast(Me.DataList1.Items(i).FindControl("HdCCAR"), HiddenField)
            Dim HdSum As HiddenField = DirectCast(Me.DataList1.Items(i).FindControl("HdSum"), HiddenField)
            Dim HdTari As HiddenField = DirectCast(Me.DataList1.Items(i).FindControl("HdTari"), HiddenField)
            Dim TxtTari As TextBox = DirectCast(Me.DataList1.Items(i).FindControl("TxtTari"), TextBox)
            Dim HdCTar As HiddenField = DirectCast(Me.DataList1.Items(i).FindControl("HdCTar"), HiddenField)

            Dim LbABIM As Label = DirectCast(Me.DataList1.Items(i).FindControl("LbABIM"), Label)
            Dim LbABVD As Label = DirectCast(Me.DataList1.Items(i).FindControl("LbABVD"), Label)
            Dim LbNomImp As Label = DirectCast(Me.DataList1.Items(i).FindControl("LbNomImp"), Label)
            'Dim CboTSan As DropDownList = DirectCast(Me.DataList1.Items(i).FindControl("CboTSan"), DropDownList)

            Me.Label2.Text += "<li>"
            Me.Label2.Text += "Codi" + HdCodi.Value
            Me.Label2.Text += "TiCO" + HdTICO.Value

            LiqP(i).CODE_DEES = ""
            'LiqP(i).CODE_ABVB = LbABIM.Text
            'LiqP(i).CODE_ABVD = LbABVD.Text
            LiqP(i).CODE_CART = HdCART.Value
            LiqP(i).CODE_CDEC = Me.HdCDec.Value
            LiqP(i).CODE_CODI = HdCodi.Value
            LiqP(i).CODE_ISVB = HdIsVB.Value
            LiqP(i).CODE_NOMB = LbNomImp.Text
            LiqP(i).CODE_REDE = ""
            LiqP(i).CODE_SECO = "LP"
            LiqP(i).CODE_TICO = HdTICO.Value
            LiqP(i).CODE_TMOV = HdTMOV.Value
            LiqP(i).CODE_USAP = ""
            LiqP(i).CODE_USBD = ""
            LiqP(i).CODE_VACA = 0
            LiqP(i).CODE_VAOF = 0
            LiqP(i).CODE_VASU = 0
            LiqP(i).CODE_CCAR = HdCCAR.Value
            LiqP(i).CODE_SUM = HdSum.Value

            'si tiene valor base

            If HdIsVB.Value = "S" Then
                Dim TxtValBas As TextBox = DirectCast(Me.DataList1.Items(i).FindControl("TxtValBas"), TextBox)
                LiqP(i).CODE_VABA = CDbl(TxtValBas.Text.Replace("$", ""))
                LiqP(i).CODE_IMPTO = HdCimp.Value
                LiqP(i).CODE_TARI = TxtTari.Text

            Else
                LiqP(i).CODE_VABA = Nothing
            End If
            r = i + 1

            ' si calcula el valor declaracdo
            If HdCTar.Value = "S" Then
                LiqP(i).CODE_VAOF = objCd.RedondearUp(LiqP(i).CODE_VABA * LiqP(i).CODE_TARI)
            Else
                LiqP(i).CODE_VAOF = CDbl(txtR.Text.Replace("$", ""))
            End If
            If HdSum.Value = "S" Then
                LiqP(i).CODE_VAOF = Tr
            Else
                Tr += LiqP(i).CODE_VAOF
            End If
            txtR.Text = LiqP(i).CODE_VAOF
            Me.Label2.Text += "VaBa" + LiqP(i).CODE_VABA.ToString
            Me.Label2.Text += "VaOf" + LiqP(i).CODE_VAOF.ToString
            LiqP(i).CODE_VADE = LiqP(i).CODE_VADE
            'SI ES SANCIÓN
            'If HdTICO.Value = "S" Then
            ' Me.Label2.Text += "Sancion:" + (CboTSan.SelectedValue)
            ' LiqP(i).CODE_TSAN = CboTSan.SelectedValue
            ' End If
            j = i
        Next i
        j = j + 1
        Tr = 0

        '        Me.Label2.Text = ""

        Return LiqP

    End Function

    Protected Sub BtnGuardar_Click1(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnGuardar.Click
        Dim aLp() As LPCODE_CDEC = Me.Cargar_CODE()

        Me.BtnGuardar.Enabled = False
        Dim Dec_Cod As String = ""
        objCd = New CDeclaraciones(Me.HdCDec.Value)
        'DEC_PTOT = DEC_PIM + DEC_PRS
        Dim DEC_CSAN As String = "00"
        Dim dec_cdec As String = Me.HdCDec.Value
        Dim Dec_FDCO As String = Me.HdFode.Value
        Dim Dec_Fven As Date = CDate(Me.HdFecLim.Value)
        Dim Dec_Cor As String = Me.HdDCOD.Value
        Dim DEC_TRET As String = 0
        Dim dec_tot As Double = 0
        Dim DEC_TSAN As String = 0
        Dim DEC_PRS As String = 0
        Dim DEC_PIM As String = 0
        Dim DEC_PTOT As String = 0
        Dim Tip_Decla As String = "02" ' Corrección
        Dim TD As String = "C"
        Dim sw As Boolean
        If Dec_FDCO <> "" Then
            MsgResult.Text = objCd.Insert(Dec_Cod, dec_cdec, Me.Nit.Text, Me.DV.Text.Trim, AGravable.Text, PGravable.Text, Dec_Cor, DEC_TRET, DEC_CSAN, DEC_TSAN, dec_tot, DEC_PRS, DEC_PIM, DEC_PTOT, Tip_Decla, Me.Agente.Text, Dec_FDCO, Dec_Fven, TD, aLp, "LOCP")
        Else
            sw = True
            MsgResult.Text = "No Hay Formulario de Declaración definido,no se puede generar la liquidación."
        End If


        Me.MsgResult.Visible = True
        Me.MsgBox(MsgResult, objCd.lErrorG)

        If (objCd.lErrorG = True) Or (sw = True) Then
            Me.BtnGuardar.Enabled = True
            Me.MsgResult.ForeColor = Drawing.Color.Red
            'Me.ImgRst.ImageUrl = Me.IMGNOTOK.ToString
            'Me.BtnPDF.Enabled = False
            'Me.ModalPopup.Show()
        Else
            Me.MsgResult.Text = "<br>Liquidación  N° :" + Dec_Cod + " - Corregido " + Dec_Cor
            'Me.HdNroDec.Value = Dec_Cod
            '    Me.BtnPDF.Enabled = True
            '   Me.ImgRst.ImageUrl = Me.IMGOK.ToString
            '  Me.ModalPopup.Show()
        End If

    End Sub

    Public Function Redondear(ByVal N As Double) As Double
        Dim c As CDeclaraciones = New CDeclaraciones
        Return c.RedondearUp(N)

    End Function

End Class
