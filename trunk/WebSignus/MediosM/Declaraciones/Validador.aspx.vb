Imports System.data
Imports System.IO

Partial Class MediosM_Declaraciones_Validador
    Inherits PaginaComun
    Dim Ruta As String
    Dim RutaTmp As String
    Dim objcd As CDeclaraciones
    Dim _TotalLiq As Double
    Property _TablaLog() As DataTable
        Get
            Dim dt As New DataTable
            dt = CType(ViewState("TablaLog"), DataTable)
            Return dt
        End Get
        Set(ByVal value As DataTable)
            ViewState("TablaLog") = value
        End Set
    End Property
    Property _NomArchivo() As String
        Get
            Return CType(ViewState("NombreArchivo"), String)
        End Get
        Set(ByVal value As String)
            ViewState("NombreArchivo") = value
        End Set
    End Property

    'Private Function Copiar_Archivo2() As Boolean
    '    Dim sw As Boolean = False
    '    If FileUpload1.HasFile Then
    '        If Cargar_Archivo.ChecarExtension(FileUpload1.FileName) Then

    '            Me.RutaTmp = ConfigurationManager.AppSettings("RUTA_DOC_TMP")
    '            Me.Ruta = ConfigurationManager.AppSettings("RUTA_DOC")
    '            Try
    '                FileUpload1.SaveAs(Me.RutaTmp & Me.NombreA.Value)
    '                Label1.Text = Me.NombreA.Value & " .... Cargado exitosamente <br>"
    '                Label1.Text += "Nombre de Archivo Cargado:  " + Me.FileUpload1.FileName + "<br>"
    '                Label1.Text += "Tamaño :  " + (Me.FileUpload1.PostedFile.ContentLength / 1024).ToString + "KB <br>"
    '                Label1.Text += "Tipo de Contenido: " + Me.FileUpload1.PostedFile.ContentType.ToString + "<br>"
    '                'lblOculto.Text = Me.Ruta & FileUpload1.FileName
    '                'Label1.Text += "MD5 " + Generar_MD5(Me.NombreA.Value)
    '                sw = True
    '            Catch ex As Exception
    '                sw = False
    '                Label1.Text = "Ya existe archivo con ese Nombre<br>"
    '            End Try
    '        End If
    '    Else
    '        Label1.Text = "Error al subir el archivo o no es el tipo .Txt"
    '        Me.MsgBox(Me.Label1, True)
    '        sw = False
    '    End If
    '    Return sw
    'End Function

    Private Function Copiar_Archivo() As Boolean
        Dim sw As Boolean

        sw = Cargar_Archivo.Guardar_Archivo(Me.FileUpload1, Me.NombreA.Value)

        Me.Label1.Text = "<b>Error al Cargar Archivo:</b> <br>" + Cargar_Archivo.MsgResult
        '        Me.MsgBoxV(Me.Label1, Not sw)
        Me.Label1.Visible = True
        Return sw

    End Function

    'obj.RutaArchivo = "E:\x\DerWeb\Docs\20090102.txt"
    'GridView1.FooterRow.Cells(4).Text = String.Format("{0:C}", dt.Compute("sum(VALORIMPTO)", ""))

    'Private Sub Validar_Archivo_ant()
    '    Me.HdNrad.Value = ""
    '    Me.BtnExcel.Enabled = False
    '    Me.Label1.Text = ""
    '    Me.Label1.CssClass = ""

    '    Dim obj As BasesLiq = New BasesLiq(Me.Nit.Text, Me.CbCdec.SelectedValue, Me.CboVigencia.SelectedValue, Me.Periodo.SelectedValue, CDate(Me.TxtFecha.Text))
    '    Dim dt As DataTable

    '    'Se crea la Ruta del archivo Temporal
    '    Me._NomArchivo = obj.Nombre_Archivo()
    '    Me.NombreA.Value = Me.RUTA_DOC_TMP + obj.Nombre_Archivo()

    '    Dim ctr_trans As Boolean = False

    '    If Copiar_Archivo() Then
    '        obj.Codigo = Me.CboFormatos.SelectedValue
    '        obj.RutaArchivo = Me.NombreA.Value 'Ruta de Archivo Temporal
    '        'Abrir Base de Datos

    '        Dim sw As Boolean = obj.Validar()
    '        If sw = True Then
    '            dt = obj.TablaImp
    '            Dim ATmp As String = Me.NombreA.Value
    '            'Ruta Permanente del Archivo
    '            Dim ADoc As String = Me.RUTA_DOC & obj.Radicado.ToString + ".txt"
    '            Try
    '                If File.Exists(ADoc) Then
    '                    File.Delete(ADoc)
    '                End If
    '                File.Move(ATmp, ADoc)
    '                obj._Transaccion.Commit()
    '                Me.Label1.Text = "Se realizó la Operación satisfactoriamente" + obj.MsgResult
    '            Catch ex As Exception
    '                Me.Label1.Text = "Error Archivo, en operación de escritura en el servidor" '+ ex.Message
    '                ctr_trans = False
    '                obj._Transaccion.Rollback()
    '            Finally
    '                If Not obj._Transaccion Is Nothing Then
    '                    BDDatos.CerrarSBD()
    '                End If
    '            End Try
    '            If ctr_trans = True Then ' Si el Archivo es Válido y Cargado
    '                Me.HdNrad.Value = obj.Radicado.ToString
    '            End If
    '        End If

    '        Me.Label1.Text = obj.MsgResult
    '        Me.BtnExcel.Enabled = True
    '        Me._TablaLog = obj.TablaImp 'Guardar Tabla de Logs
    '    End If
    'End Sub

    Private Sub Validar_Archivo()
        Me.HdNrad.Value = ""
        Me.BtnExcel.Enabled = False
        Me.Label1.Text = ""
        Me.Label1.CssClass = ""

        Dim obj As BasesLiq = New BasesLiq(Me.Nit.Text, Me.CbCdec.SelectedValue, Me.CboVigencia.SelectedValue, Me.Periodo.SelectedValue, CDate(Me.TxtFecha.Text))

        'Se crea la Ruta del archivo Temporal
        Me._NomArchivo = obj.Nombre_Archivo()
        Me.NombreA.Value = Me.RUTA_DOC_TMP + obj.Nombre_Archivo()

        Dim ctr_trans As Boolean = False

        If Copiar_Archivo() Then
            obj.Codigo = Me.CboFormatos.SelectedValue
            obj.RutaArchivo = Me.NombreA.Value 'Ruta de Archivo Temporal
            'Abrir Base de Datos
            Dim sw As Boolean = obj.Validar()
            If sw = True Then
                Me.HdNrad.Value = obj.Radicado.ToString
                Me.Image1.ImageUrl = Me.RUTA_VIRTUAL + "images/ok.gif"
                Me.BtnIDil.Enabled = True
            Else
                Me.Image1.ImageUrl = Me.RUTA_VIRTUAL + "images/error.gif"
                Me.BtnIDil.Enabled = False
            End If
            Me.Label1.Text = obj.MsgResult
        Else
            Me.Image1.ImageUrl = Me.RUTA_VIRTUAL + "images/error.gif"
        End If
        Me.Image1.Visible = True
        Me.BtnIExcel.Enabled = True
        Me._TablaLog = obj.TablaImp 'Guardar Tabla de Logs

    End Sub
    Protected Sub BrnValidar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BrnValidar.Click
        Me.Validar_Archivo()
    End Sub

    'Public Sub Agrupar(ByVal dt As DataTable)
    '    'distinct 
    '    Dim distinctTable As DataTable = dt.DefaultView.ToTable(True, "IMPTO")
    '    Dim dtSummerized As New DataTable("SumaResult")
    '    Dim objimpto As Impuestos = New Impuestos
    '    dtSummerized.Columns.Add("No", GetType(String))
    '    dtSummerized.Columns.Add("Código", GetType(String))
    '    dtSummerized.Columns.Add("Impuesto", GetType(String))
    '    dtSummerized.Columns.Add("BaseGravable", GetType(String))
    '    dtSummerized.Columns.Add("Valor_Impuesto", GetType(String))
    '    Dim count As Integer = 0
    '    For Each dr As DataRow In distinctTable.Rows
    '        count += 1
    '        'Dim avg As String = dt.Compute("avg(amount)", "CustomerID =" & dr("CustomerID").ToString()).ToString()
    '        Dim dtimp As DataTable = objimpto.GetByIde(dr("IMPTO").ToString())

    '        Dim BaseGravable As String = FormatNumber(dt.Compute("sum(VALORBASE)", "IMPTO =" & dr("IMPTO").ToString()).ToString())
    '        Dim Impuesto As String = FormatNumber(dt.Compute("sum(VALORIMPTO)", "IMPTO =" & dr("IMPTO").ToString()).ToString())
    '        dtSummerized.Rows.Add(count, dr("IMPTO"), dtimp.Rows(0)("IMP_NOM").ToString, BaseGravable, Impuesto)
    '    Next
    '    'GridView2.DataSource = dtSummerized
    '    'GridView2.DataBind()
    'End Sub


    Protected Sub button_Click(ByVal sender As Object, ByVal e As System.EventArgs)

    End Sub


    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Me.SetTitulo()
        Me.ToolkitScriptManager1.RegisterAsyncPostBackControl(Me.ConsultaTer1)
        If Not Me.IsPostBack Then
            Me.CbCdec.Attributes.Add("OnFocus", "javascript:UpdateCombo()")
            'Me.ROptTD.SelectedValue = "01"
            Dim dt As DataTable = Me.UsuTercero.GetByUser()
            '            Me.MsgResult.Text = dt.Rows(0)("Ter_TUS").ToString() + "-" + dt.Rows(0)("TUS_NOM").ToString()
            If (dt.Rows.Count > 0) Then
                If (dt.Rows(0)("Ter_TUS").ToString() = "AR") Then
                    Me.Agente.Text = dt.Rows(0)("Ter_Nom").ToString
                    Me.Nit.Text = dt.Rows(0)("Ter_nit").ToString
                    Me.Dv.Text = Trim(dt.Rows(0)("Ter_dver").ToString)
                    Me.TxtFecha.Text = Now.ToShortDateString
                    Me.TxtFecha.Enabled = False
                    Me.BtnBuscDP.Visible = False
                Else

                    Me.TxtFecha.Enabled = True
                    Me.BtnBuscDP.Visible = True
                End If
                Me.BtnIDil.Enabled = False
                Me.BtnIExcel.Enabled = False
                Me.TxtFecha.Text = Now.ToShortDateString
            End If
        End If

    End Sub

    Protected Sub BtnBuscDP_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        Me.ModalPopup.Show()
    End Sub

    Protected Sub BtnExcel_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnExcel.Click
        Exportar_Logs()
    End Sub

    Private Sub Exportar_Logs()
        GridViewS1.DataSource = Me._TablaLog
        GridViewS1.DataBind()
        ExportGridView(GridViewS1, Me._NomArchivo.ToString)
    End Sub
    Public Overrides Sub VerifyRenderingInServerForm(ByVal control As Control)

    End Sub

    Protected Sub GrdRad_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs)
        'Me.Agente.Text = (Me.GrdRad.SelectedValue)
    End Sub

    Protected Sub BtnDil_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnDil.Click
        'Diligenciar_Dec()
        Diligenciar()
    End Sub

    Private Sub Diligenciar()
        'Response.Redirect(Me.RUTA_VIRTUAL + "/Declaraciones/Diligenciar/SelDec.aspx?cdec=" + Me.CbCdec.SelectedValue + "&vig=" + Me.CboVigencia.SelectedValue + "&per=" + Me.Periodo.SelectedValue)
        Redireccionar_Pagina("/Declaraciones/Diligenciar/SelDec.aspx?cdec=" + Me.CbCdec.SelectedValue + "&vig=" + Me.CboVigencia.SelectedValue + "&per=" + Me.Periodo.SelectedValue)
    End Sub
    Public Sub Diligenciar_Dec()
        If Me.Nit.Text = "" Then
            Me.MsgResult.Text = "Seleccione un Agente Recaudador "
            Me.MsgBox(Me.MsgResult, True)
            Exit Sub
        End If


        Dim obj As Tipo_Dec = New Tipo_Dec
        'Dim ObdCd As CDeclaraciones = New CDeclaraciones(Me.Cla_Dec.Value)
        Dim ClDec As String = Me.CbCdec.SelectedValue
        objcd = New CDeclaraciones(ClDec)
        Dim DOAD As String = "DELP"
        '---------------------
        Dim objcal As Calendario = New Calendario
        Dim dtc As DataTable = objcal.GetPorAñoyPer(ClDec, Me.CboVigencia.SelectedValue, Me.Periodo.SelectedValue)
        'REVISAR SANCIONES E INTERESES
        Dim cal_ffin As Date = CDate(dtc.Rows(0)("Cal_Ffin").ToString())

        Dim OMMD As String = objcd.GetOMMD(cal_ffin)
        If OMMD = "S" Then
            Dim objBl As BasesLiq = New BasesLiq
            If objBl.isExits(Me.Nit.Text, ClDec, Me.CboVigencia.SelectedValue, Me.Periodo.SelectedValue) = False Then
                Me.MsgResult.Text = "No puede Diligenciar Declaración<br>Debe Validar y Cargar Medios Magnéticos Para Este Periodo Gravable "
                Me.MsgBox(Me.MsgResult, True)
                Exit Sub
            End If
        End If

        Dim Año As String = Me.CboVigencia.SelectedValue
        Dim Per As String = Me.Periodo.SelectedValue
        Dim dt As DataTable
        Dim tp As String
        ' Validar Signatarios
        Dim objs As New Signatario()
        Dim dts As DataTable = objs.GetRecords(Me.Nit.Text)
        Dim OSIG As String = objcd.GetOSIG(cal_ffin)
        If (OSIG = "S") Then
            If (dts.Rows.Count <= 0) And (HdAR.Value <> "AR") Then
                Me.MsgResult.Text = "Debe Asignar Signatarios"
                Me.MsgBox(Me.MsgResult, True)
                Exit Sub
            End If
        End If
        dts.Clear()

        tp = obj.GetCodiTD(ClDec, Me.ROptTD.SelectedValue)

        Dim nit As String = Me.Nit.Text
        Dim tdNd As DataTable = objcd.GetDecByPer(nit, Me.CboVigencia.SelectedValue, Me.Periodo.SelectedValue)

        dt = Me.objcd.GetFormularios_Dec(Año, Per).Tables(0)
        Dim tip_dec As String = Me.ROptTD.SelectedValue
        If (tp = "I") Then
            If (tdNd.Rows.Count > 0) Then
                Me.MsgResult.Text = "Ya existe una Declaración Inicial, " + ClDec + " Formulario N°" + tdNd.Rows(0)("Dec_Cod").ToString + " Sino ha Presentado esta declaración al banco puede anularla y crear una nueva declaración"
                Me.MsgBox(Me.MsgResult, True)
            Else
                Me.MsgResult.Text = "Abrir "
                Me.MsgResult.Text = "Clase Dec " + ClDec + " Año Gravable " + Año + " Periodo Gravable " + Per + "Tipo " + Me.ROptTD.SelectedValue
                querystringSeguro = Me.SetRequest()
                querystringSeguro("CDec") = ClDec
                querystringSeguro("AGravable") = Año
                querystringSeguro("PGravable") = Per
                querystringSeguro("DecTip") = tip_dec
                querystringSeguro("Nit") = nit
                querystringSeguro("TD") = tp
                querystringSeguro("FODE_CODI") = dt.Rows(0)("Fode_Codi").ToString
                querystringSeguro("DOAD") = DOAD
                Me.MsgBox(Me.MsgResult, False)
                Response.Redirect("/Declaraciones/" + dt.Rows(0)("Fode_Fowe").ToString + "?data=" + HttpUtility.UrlEncode(querystringSeguro.ToString()))
                'Dim Rt As String = dt.Rows(0)("Fode_Fowe").ToString + "?" + "CDec=" + ClDec + "&AGravable=" + Año + "&PGravable=" + Per + "&DecTip=" + tip_dec + "&Nit=" & nit + "&TD=" + tp + "&FODE_CODI=" & dt.Rows(0)("Fode_Codi").ToString                
                'Me.MsgResult.Text = Rt
                'Response.Redirect(Rt)
            End If
        ElseIf (tp = "C") Then
            If (tdNd.Rows.Count = 0) Then
                Me.MsgResult.Text = "No existe Declaración Presentada para corregir en el sistema, debe diligenciar una inicial"
                Me.MsgBox(Me.MsgResult, True)
            Else
                Dim Rt As String = dt.Rows(0)("Fode_Fowe").ToString + "?" + "CDec=" + ClDec + "&AGravable=" + Año + "&PGravable=" + Per + "&DecTip=" + Me.ROptTD.SelectedValue + "&Nit=" & nit + "&TD=" + tp + "&FODE_CODI=" & dt.Rows(0)("Fode_codi").ToString + "&Dec_Cor=" + tdNd.Rows(0)("Dec_cod").ToString
                querystringSeguro = Me.SetRequest()
                querystringSeguro("CDec") = ClDec
                querystringSeguro("AGravable") = Año
                querystringSeguro("PGravable") = Per
                querystringSeguro("DecTip") = tip_dec
                querystringSeguro("Nit") = nit
                querystringSeguro("TD") = tp
                querystringSeguro("Dec_Cor") = tdNd.Rows(0)("Dec_cod").ToString
                querystringSeguro("FODE_CODI") = dt.Rows(0)("Fode_Codi").ToString


                'Me.MsgResult.Text = Rt
                Me.MsgBox(Me.MsgResult, False)
                'Response.Redirect(Rt)
                Response.Redirect(Me.RUTA_VIRTUAL + "/Declaraciones/" + dt.Rows(0)("Fode_Fowe").ToString + "?data=" + HttpUtility.UrlEncode(querystringSeguro.ToString()))
            End If

        End If

    End Sub

    Protected Sub GridView1_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles GridView1.SelectedIndexChanged

    End Sub

    Protected Sub GridView1_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles GridView1.RowDataBound
        Select Case e.Row.RowType
            Case DataControlRowType.DataRow
                'Me._TotalLiq += CDec(DataBinder.Eval(e.Row.DataItem, "ValorImpuesto"))
                If DataBinder.Eval(e.Row.DataItem, "cocd_cdec") = "30" Then
                    If DataBinder.Eval(e.Row.DataItem, "cocd_codi") = "01" Then
                        Me._TotalLiq += CDec(DataBinder.Eval(e.Row.DataItem, "ValorImpuesto"))
                    Else
                        Me._TotalLiq -= CDec(DataBinder.Eval(e.Row.DataItem, "ValorImpuesto"))
                    End If
                Else
                    Me._TotalLiq += CDec(DataBinder.Eval(e.Row.DataItem, "ValorImpuesto"))
                End If
            Case DataControlRowType.Footer
                e.Row.Cells(4).Text = FormatCurrency(Me._TotalLiq.ToString)
                e.Row.Cells(4).HorizontalAlign = HorizontalAlign.Right
                e.Row.Font.Bold = True
        End Select
    End Sub


    Protected Sub BtnIExcel_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles BtnIExcel.Click
        Me.Exportar_Logs()
    End Sub

    Protected Sub BtnIDil_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles BtnIDil.Click
        Me.Diligenciar()
    End Sub

    Protected Sub BtnIValidar_Click1(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles BtnIValidar.Click
        Me.Validar_Archivo()
    End Sub
    Protected Sub ToolkitScriptManager1_AsyncPostBackError(ByVal sender As Object, ByVal e As System.Web.UI.AsyncPostBackErrorEventArgs) Handles ToolkitScriptManager1.AsyncPostBackError
        If (Not IsNothing(e.Exception)) And (Not IsNothing(e.Exception.InnerException)) Then
            ToolkitScriptManager1.AsyncPostBackErrorMessage = e.Exception.InnerException.Message + "Ajax"
        End If
    End Sub
End Class
