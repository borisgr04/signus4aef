<%@ WebHandler Language="VB" Class="Firma" %>

Imports System
Imports System.Web
Imports System.Data

Public Class Firma : Implements IHttpHandler
    
    Public Sub ProcessRequest(ByVal context As HttpContext) Implements IHttpHandler.ProcessRequest
        Dim Id As String = context.Request.QueryString("Id")
        Dim o As New TIPO_DOC
        Dim dt As DataTable = o.GetPorCod(Id)
        Dim arrImg() As Byte = DirectCast(dt.Rows(0)("TIDO_FIRMA"), Byte())
        context.Response.Clear()
        context.Response.ContentType = "image/jpeg"
        context.Response.BinaryWrite(arrImg)
        context.Response.End()
    End Sub
 
    Public ReadOnly Property IsReusable() As Boolean Implements IHttpHandler.IsReusable
        Get
            Return False
        End Get
    End Property

End Class