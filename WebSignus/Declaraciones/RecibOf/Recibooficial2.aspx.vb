Imports System.Data
Imports System.Data.OleDb
Imports System.Collections.Generic
Imports System
Imports System.Configuration
Imports System.Web
Imports System.Web.Security
Imports System.Web.UI
Imports System.Web.UI.WebControls
Imports System.Web.UI.WebControls.WebParts
Imports System.Web.UI.HtmlControls
Imports Microsoft.Reporting.WebForms
Imports AjaxControlToolkit


Partial Class recibooficial2
    Inherits PaginaComun
    Dim NroRenglon As String = "9"
    Dim Dec_nro As String
    Dim objdec As CDeclaraciones = New CDeclaraciones
    Dim obj As ReciboOf = New ReciboOf
    Dim Clase_dec As String
    Dim NomDec As String
    Dim Plazo_dec As Integer
    Dim fecha_lim As Date
    Dim ValInteresMora As Decimal
    Dim fecha_dec As Date
    Dim TOTAL_RETENCIONES As Double
    Dim fnTotalizar As String
    Dim Nit As String
    Dim TD As String
    Dim FODE_CODI As String
    Dim dtForm As DataTable
    Dim Operaciones_Form As String
    Dim RenglonLP As String
    Dim RenglonVP As String
    Dim LSanciones As Boolean
    Dim Dias_Mora As Integer
    Dim COD_CDEC As String
    Dim Interes As Decimal
    Dim Capital As Decimal
    Dim Sancion As Decimal
    Dim TotalPago As Decimal
    Dim FecPre As Date
    'Dim tip_tar As String = "%"
    Dim strOkDeclaracion As String = "Debe Tener en cuenta que este documento aún NO ha sido presentado a la Gobernación del Cesar. Debe imprimirlo, firmalo autografamente y llevarlo al banco autorizado para dar presentada su declaración"
    Protected Function NRenglon() As String

        NroRenglon = CStr(CInt(NroRenglon) + 1).PadLeft(2, "0")
        Return NroRenglon

    End Function
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        ' OJO NO RECARGAR DATOS !!!!!!!!!!!!!
        If Not IsPostBack Then
            avce.VerticalSide = VerticalSide.Bottom
            avce.HorizontalSide = HorizontalSide.Center
            avce.Enabled = True
            Cargar_datos()
            Me.Opcion = "Recibo Oficial de Pago"
            Me.SetTitulo()
            'Cargar_Ayuda()
        End If
    End Sub
    Private Function mostrar_renglon(ByVal nr As String) As String
        Return "document.form1.HdRenglon.value=" & nr & ";ActualizarAyuda();showdiv(event);"
    End Function
    Private Sub Cargar_datos()


        Me.Opcion = obj.GetNomDec(Me.Cla_Dec.Value)
        Me.LBTITULO.Text = Me.Opcion
        Me.SetTitulo()
        Me.Title = Me.Opcion

        querystringSeguro = Me.GetRequest()
        Clase_dec = querystringSeguro("CDec")
        Me.Cla_Dec.Value = querystringSeguro("CDec")
        Me.AGravable.Text = querystringSeguro("AGravable")
        Me.HdCodDec.Value = querystringSeguro("CodDec")
        Me.HdTDocAdm.Value = querystringSeguro("DocAdm")

        Me.FecPre = querystringSeguro("FecPre")
        Me.PGravable.Text = querystringSeguro("PGravable")
        Me.Nit = querystringSeguro("Nit")
        'Me.HdDecTip.Value = Request.QueryString("DecTip")
        'Me.TD = Request.QueryString("TD")
        'Me.HdTD.Value = Request.QueryString("TD")
        Me.FODE_CODI = querystringSeguro("FODE_CODI")
        Me.HdFODE.Value = Me.FODE_CODI

        Dim objCal As Calendario = New Calendario
        Dim dtc As DataTable
        obj = New ReciboOf(querystringSeguro("CDec"))
        dtc = objCal.GetPorAñoyPer(Me.Cla_Dec.Value, Me.AGravable.Text, Me.PGravable.Text)
        Dim cal_ffin As Date = CDate(dtc.Rows(0)("Cal_Ffin").ToString())
        Me.fecha_dec = cal_ffin

        Dim fecha_lim As Date
        'Plazo de Ejecución
        'Me.Plazo_dec = CInt(objdec.GetPlazoDec(cal_ffin))

        'Fecha Limite
        'fecha_lim = cal_ffin.AddDays(Me.Plazo_dec)
        fecha_lim = objdec.GetFecha_Limite(Me.Cla_Dec.Value, Me.AGravable.Text, Me.PGravable.Text)
        Me.HdFecLim.Value = fecha_lim

        'Me.Errormsg.Text = Me.HdTDocAdm.Value
        'Dim objCal As Calendario = New Calendario
        'Dim dtc As DataTable
        'dtc = objCal.GetPorAñoyPer(Me.Cla_Dec.Value, Me.AGravable.Text, Me.PGravable.Text)
        'REVISAR SANCIONES E INTERESES

        Sancion = obj.Get_San(Clase_dec, Me.AGravable.Text, Me.PGravable.Text, Me.Nit)
        Dim Cap_int As Decimal = obj.Get_CapInt(Clase_dec, Me.AGravable.Text, Me.PGravable.Text, Me.Nit)
        Capital = obj.Get_Val_pago(Clase_dec, Me.AGravable.Text, Me.PGravable.Text, Me.Nit)
        Dim Int_new As Decimal = objdec.GetInteresMoraC(Cap_int, Me.FecPre, Now.ToShortDateString)
        Dim Int_ant As Decimal = obj.Get_IntAnt(Clase_dec, Me.AGravable.Text, Me.PGravable.Text, Me.Nit)
        Interes = Int_ant + Int_new
        TotalPago = CDbl(Capital) + CDbl(Sancion) + +CDbl(Interes)

        Me.TXTSAN.Text = Sancion
        Me.TXTVP.Text = Capital
        Me.TXTINT.Text = Interes
        Me.TXTTOTP.Text = TotalPago
        ' Crear una Funcion que me devuelva el interes que e4sta en cartera y a ese valor  sumarle el interes nuevo

        'Me.HdCodDec.Value = obj.GetCOD_Dec(Me.PGravable.Text, Me.AGravable.Text, Me.Nit, Clase_dec)

        If Not Me.IsPostBack Then
            Dim dt As DataTable = Me.UsuTercero.GetByIde(Me.Nit)
            If dt.Rows.Count > 0 Then
                Me.Agente.Text = dt.Rows(0)("Ter_Nom").ToString
                Me.LBMUN_NOM.Text = dt.Rows(0)("TER_MPIO").ToString
                Me.LBTER_TEL.Text = dt.Rows(0)("TER_TEL").ToString
                Me.Identificaciòn.Text = dt.Rows(0)("Ter_nit").ToString
                Me.DV.Text = Trim(dt.Rows(0)("Ter_dver").ToString)
                'Me.TIP_DOC_IDE.Text = dt.Rows(0)("Ter_tdoc").ToString
            End If
        End If
    End Sub
    Protected Sub ToolkitScriptManager1_AsyncPostBackError(ByVal sender As Object, ByVal e As System.Web.UI.AsyncPostBackErrorEventArgs) Handles ToolkitScriptManager1.AsyncPostBackError
        If (Not IsNothing(e.Exception)) And (Not IsNothing(e.Exception.InnerException)) Then
            ToolkitScriptManager1.AsyncPostBackErrorMessage = e.Exception.InnerException.Message
        End If

    End Sub
    '-*--------------------------
    Protected Sub GuardarDatos()
        Dim nit As String = Me.Identificaciòn.Text
        Dim per As String = Me.PGravable.Text
        Dim año As String = Me.AGravable.Text
        Dim cladec As String = Me.Cla_Dec.Value
        Dim vp As Decimal = CDec(Me.TXTVP.Text.Replace("$", ""))
        Dim Int As Decimal = CDec(Me.TXTINT.Text.Replace("$", ""))
        Dim San As Decimal = CDec(Me.TXTSAN.Text.Replace("$", ""))
        'Dim COD_CDEC As String = obj.GetCOD_Dec(per, año, nit, cladec)
        'COD_CDEC = obj.GetCOD_Dec(per, año, nit, cladec)
        Me.MsgResult.Text = obj.Insert(Me.Identificaciòn.Text, Me.PGravable.Text, Me.AGravable.Text, vp, Int, Me.Cla_Dec.Value, Me.HdCodDec.Value, San, Me.HdTDocAdm.Value, "ROPA")
        Me.HidNroReof.Value = obj.ROF_COD
        Me.lbnorecof.Text = "Numero de Recibo Oficial:" + obj.ROF_COD
        If obj.lErrorG = True Then
            Me.ModalPopup.Show()
        Else
            Me.HdNro.Value = obj.ROF_COD
            Me.BImGDE.Enabled = False
            Me.BImGPDF.Enabled = True
        End If
    End Sub
    Public Sub Cargar_Rpt()
        ReportViewer1.LocalReport.ReportPath = "Report\ReciboOF\RptRecOf.rdlc"
        Dim dtSource As ReportDataSource = New ReportDataSource("DSRecOf_VRecOf", GetDatosP().Tables(0))
        Dim rptEntidad As New ReportDataSource(Me.DS_Entidad, Cargar_Logo())
        ReportViewer1.LocalReport.DataSources.Clear()
        ReportViewer1.LocalReport.DataSources.Add(dtSource)
        ReportViewer1.LocalReport.DataSources.Add(rptEntidad)
        ReportViewer1.LocalReport.Refresh()
        Me.RenderReport(Me.ReportViewer1.LocalReport)
    End Sub
    Private Function GetDatosP() As DataSet
        Dim dt As DataSet = New DataSet
        'Dim objDEC As CDeclaraciones = New CDeclaraciones(Me.Cla_Dec.Value)
        dt = obj.GetRecOfRpt(HidNroReof.Value)
        Return dt
    End Function
    Private Sub RenderReport(ByVal Rpt As LocalReport)
        'string reportType = "Image"; 
        Dim reportType As String = "PDF"
        Dim fileNameExtension As String = ""
        Dim warnings As Warning() = Nothing
        Dim streamids As String() = Nothing
        Dim mimeType As String = Nothing
        Dim encoding As String = Nothing
        Dim extension As String = Nothing
        'The DeviceInfo settings should be changed based on the reportType 
        'http://msdn2.microsoft.com/en-us/library/ms155397.aspx 
        Dim deviceInfo As String = "<DeviceInfo>" & " <OutputFormat>PDF</OutputFormat>" & " <PageWidth>8.5in</PageWidth>" & " <PageHeight>11in</PageHeight>" & " <MarginTop>0.5in</MarginTop>" & " <MarginLeft>1in</MarginLeft>" & " <MarginRight>1in</MarginRight>" & " <MarginBottom>0.5in</MarginBottom>" & "</DeviceInfo>"
        Dim streams As String() = Nothing
        Dim renderedBytes As Byte()
        'Render the report 
        'deviceInfo, 
        Rpt.Refresh()
        renderedBytes = Rpt.Render(reportType, Nothing, mimeType, encoding, fileNameExtension, streams, warnings)
        Response.Clear()
        Response.ContentType = mimeType
        Response.AddHeader("content-disposition", "attachment; filename=ReciboOficialPago." & fileNameExtension)
        Response.BinaryWrite(renderedBytes)
        Response.End()
    End Sub
    Protected Sub BImGPDF_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs)
        Me.Cargar_Rpt()
    End Sub
    Protected Sub BImGDE_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs)
        Me.GuardarDatos()
    End Sub

    Protected Sub BtnIrAtras_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles BtnIrAtras.Click
        IrAtras()
    End Sub
    Private Sub IrAtras()
        Response.Redirect(Me.RUTA_VIRTUAL + "declaraciones/RecibOf/seldec.aspx")
    End Sub
End Class

