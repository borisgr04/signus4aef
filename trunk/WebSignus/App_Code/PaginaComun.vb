Imports Microsoft.VisualBasic
Imports System
Imports System.Collections
Imports System.Web.UI
Imports System.IO
'Para manejar graficos
Imports System.Drawing.Imaging
Imports System.Data
Imports Signus

' <summary>
' This Page class is common to all sample pages and exists as a place to
' implement common functionality
' </summary>

Public Class PaginaComun
    Inherits System.Web.UI.Page
    Protected Opcion As String = ""
    Dim Nombre_App As String = ConfigurationManager.AppSettings("NOMAPP")
    Protected UsuTercero As New Terceros
    Public IMGOK As String = "~/images/Ok.gif"
    Public IMGNOTOK As String = "~/images/Error.gif"
    Public DS_Entidad As String = "DtEntidad_ENTIDAD"
    Protected querystringSeguro As TSHAK.Components.SecureQueryString
    Protected OVig As Vigencias = New Vigencias

    Public Function GetRequest(Optional ByVal Str As String = "data") As TSHAK.Components.SecureQueryString
        Return New TSHAK.Components.SecureQueryString(New Byte() {0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 1, 2, 3, 4, 5, 8}, Request(str))
    End Function

    Public Function SetRequest() As TSHAK.Components.SecureQueryString
        Return New TSHAK.Components.SecureQueryString(New Byte() {0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 1, 2, 3, 4, 5, 8})
    End Function


    Protected Function Pie_de_Pagina() As String

        Return ""

    End Function
    Protected Function Titulo() As String

        Return Nombre_App + " Sistema de Declaraciones en Línea"

    End Function
    Protected Sub SetTitulo()
        Me.Title = Titulo() + " [ " + Me.Opcion + " ]"

    End Sub

    Protected Sub MsgBox(ByRef msg As Label, ByVal lError As Boolean)

        msg.Height = 50
        msg.Width = 600

        msg.CssClass = IIf(lError = True, "NotOk", "Ok")

    End Sub

    Protected Sub MsgBoxV(ByRef msg As Label, ByVal lError As Boolean)

        msg.Height = 100
        msg.Width = 600

        msg.CssClass = IIf(lError = True, "NotOk", "Ok")

    End Sub

    Protected Sub MsgBoxLQ(ByRef msg As Label, ByVal lError As Boolean)

        msg.CssClass = IIf(lError = True, "NotOk", "Ok")

    End Sub

    Public Function Path() As String
        Return Server.MapPath(".")
    End Function
    'Public Function Ruta_Doc() As String
    '    Return Me.Path + "Docs\"
    'End Function

    Public Function vRuta_Doc() As String
        Return "~/Docs/"
    End Function

    Protected Shared Function ConvertImageToByteArray(ByVal imageToConvert As System.Drawing.Image, ByVal formatOfImage As ImageFormat) As Byte()
        Dim Ret As Byte()

        Try

            Using ms As New MemoryStream()
                imageToConvert.Save(ms, formatOfImage)
                Ret = ms.ToArray()
            End Using
        Catch generatedExceptionName As Exception
            Throw
        End Try

        Return Ret
    End Function

    Public Shared Sub SaveJPG(ByVal image As Drawing.Image, ByVal szFileName As String)
        'Si ya existe una imagen se tendra que eliminar
        If System.IO.File.Exists(szFileName) = True Then
            System.IO.File.Delete(szFileName)
        End If
        'Despues de eliminar la imagen existe se crea otra con el Drawing.Image nuevo
        image.Save(szFileName)
    End Sub
    Public Shared Function Bytes2Image(ByVal bytes() As Byte) As Drawing.Bitmap

        If bytes Is Nothing Then Return Nothing
        Dim ms As New MemoryStream(bytes)
        Dim bm As Drawing.Bitmap = Nothing
        Try
            bm = New Drawing.Bitmap(ms)
        Catch ex As Exception
            System.Diagnostics.Debug.WriteLine(ex.Message)
        End Try
        Return bm
    End Function
    Public Function AppPath() As String
        Return System.AppDomain.CurrentDomain.BaseDirectory()
    End Function

    Public Sub ExportGridView(ByRef grd As GridView, Optional ByVal Archivo As String = "Export")
        Dim attachment As String = String.Format("attachment; filename={0}.xls", Archivo)
        Response.ClearContent()
        Response.AddHeader("content-disposition", attachment)
        Response.ContentType = "application/ms-excel"
        Dim sw As New StringWriter()
        Dim htw As New HtmlTextWriter(sw)
        grd.RenderControl(htw)
        Response.Write(sw.ToString())
        Response.End()
    End Sub


    Public ReadOnly Property RUTA_DOC_TMP() As String
        Get
            Return ConfigurationManager.AppSettings("RUTA_DOC_TMP")
        End Get
    End Property
    Public ReadOnly Property RUTA_DOC() As String
        Get
            Return ConfigurationManager.AppSettings("RUTA_DOC")
        End Get
    End Property
    Public ReadOnly Property RUTA_VIRTUAL() As String
        Get
            Return ConfigurationManager.AppSettings("VIRTUAL")
        End Get
    End Property

    Public Function Img_Rpt() As String
        Return ConfigurationManager.AppSettings("IMG_RPT")
    End Function

    Protected Function Cargar_Logo() As DataTable
        'Dim ta As New DtEntidadTableAdapters.ENTIDADTableAdapter
        'Dim dt As New DtEntidad.ENTIDADDataTable
        Dim dt As DataTable = New DataTable
        Dim e As New Entidad
        dt = e.GetRecords()
        dt.Columns.Add("ENT_IMG", Type.GetType("System.Byte[]"))

        ''ta.Fill(dt)
        'Dim row As DtEntidad.ENTIDADRow
        Dim Rut As String = Me.Img_Rpt

        'For Each row In dt.Rows
        Dim fsArchivo As New IO.FileStream(Rut + "\" + dt.Rows(0)("ENT_LOGO"), IO.FileMode.Open, IO.FileAccess.Read)
        Dim arregloBytes(fsArchivo.Length) As Byte
        fsArchivo.Read(arregloBytes, 0, fsArchivo.Length)
        fsArchivo.Close()
        dt.Rows(0)("ENT_IMG") = arregloBytes
        'Next

        Return dt
    End Function

    'Public Function MakeBarcode(ByVal Code As String) As Byte()
    '    Dim b As New IDAutomation.BarCode
    '    b.DataToEncode = Code
    '    b.SymbologyID = IDAutomation._Symbology.CODE128
    '    Dim img As System.Drawing.Image
    '    img = Microsoft.VisualBasic.Compatibility.VB6.IPictureToImage(b.GetEnhWMF())
    '    Dim ms As System.IO.MemoryStream = New System.IO.MemoryStream()
    '    img.Save(ms, System.Drawing.Imaging.ImageFormat.Png)
    '    Dim bmpbytes As Byte() = ms.ToArray()
    '    ms.Close()
    '    Return bmpbytes
    'End Function

    Protected Function Pais_Navegador() As String

        Dim lenguaje_usuario As String = Request.ServerVariables("HTTP_ACCEPT_LANGUAGE")
        lenguaje_usuario = Left(lenguaje_usuario, 5)

        Dim pais_usuario As String

        Select Case lenguaje_usuario
            Case "es-ar"
                pais_usuario = "Argentina"
            Case "es-bo"
                pais_usuario = "Bolivia"
            Case "es-cl"
                pais_usuario = "Chile"
            Case "es-co"
                pais_usuario = "Colombia"
            Case "es-mx"
                pais_usuario = "Mexico"
            Case "es-py"
                pais_usuario = "Paraguay"
            Case "es-es"
                pais_usuario = "España"
            Case "es-uy"
                pais_usuario = "Uruguay"
            Case "es-ve"
                pais_usuario = "Venezuela"
            Case Else
                pais_usuario = "Otro"
        End Select

        Return pais_usuario

    End Function


    Protected Sub Cargar_Combo(ByRef cbo As DropDownList, ByVal dt As DataTable, ByVal Text As String, ByVal Value As String, Optional ByVal TextIni As String = "")

        cbo.Items.Clear()
        cbo.Items.Add("")
        cbo.AppendDataBoundItems = True
        cbo.DataSource = dt
        cbo.DataTextField = Text
        cbo.DataValueField = Value
        cbo.DataBind()

    End Sub

    Public Function RvoCT(ByVal cod As String) As String
        Return IIf(cod = "RF", "REVISOR FISCAL", "CONTADOR")
    End Function

    Public Sub Redireccionar_Pagina(ByVal Url As String)
        'Response.Redirect(Me.RUTA_VIRTUAL() + Url)
        Response.Redirect("~/" + Url)
    End Sub

    Function GUID() As String

        GUID = System.Guid.NewGuid().ToString()

    End Function

    Protected Overloads Sub MsgBox1(ByRef msg As Label, ByVal lError As Boolean, Optional ByVal alto As Integer = 50, Optional ByVal ancho As Integer = 600)
        msg.Visible = True
        msg.Text = "<P style='text-align:justify;'>" + msg.Text + "</P>"
        If lError = True Then
            MsgBoxError(msg, lError)
        Else
            MsgBoxExito(msg, lError)
        End If

    End Sub

    Protected Overloads Sub MsgBoxLimpiar(ByRef msg As Label)
        msg.CssClass = ""
        msg.Text = ""
    End Sub

    Protected Sub MsgBoxAlert(ByRef msg As Label, ByVal lError As Boolean, Optional ByVal alto As Integer = 50, Optional ByVal ancho As Integer = 600)
        msg.CssClass = "alerta"
    End Sub

    Protected Sub MsgBoxInfo(ByRef msg As Label, ByVal lError As Boolean, Optional ByVal alto As Integer = 50, Optional ByVal ancho As Integer = 600)
        msg.CssClass = "infor"
    End Sub

    Protected Sub MsgBoxExito(ByRef msg As Label, ByVal lError As Boolean, Optional ByVal alto As Integer = 50, Optional ByVal ancho As Integer = 600)
        msg.CssClass = "exito"
    End Sub
    Protected Sub MsgBoxError(ByRef msg As Label, ByVal lError As Boolean, Optional ByVal alto As Integer = 50, Optional ByVal ancho As Integer = 600)
        msg.CssClass = "error"
    End Sub

End Class


'Public Interface IContentPlaceHolders
'dim GetContentPlaceHolders as IList
'End Interface
