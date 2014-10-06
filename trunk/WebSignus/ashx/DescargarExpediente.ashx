<%@ WebHandler Language="VB" Class="DescargarExpediente" %>

Imports System
Imports System.Web
Imports System.Data

Public Class DescargarExpediente : Implements IHttpHandler
    
    Public Sub ProcessRequest(ByVal context As HttpContext) Implements IHttpHandler.ProcessRequest
        Dim Id As String = context.Request.QueryString("Id")
        Dim formato As String = context.Request.QueryString("formato")
        Dim campo As String = "EXTR_DOC"
        Dim obj As New Expe_Tram
        Dim dt As DataTable = obj.GetPorId(Id)
        
        If formato = ".pdf" then
           campo = "EXTR_PDF"
        End If 
        
        If dt.Rows.Count > 0 Then
            context.Response.Clear()
            context.Response.AddHeader("content-disposition", "attachment; filename=Expediente" + Id + formato)
            context.Response.BinaryWrite(DirectCast(dt.Rows(0)(campo), Byte()))
            context.Response.End()
        End If
    End Sub
 
    Public ReadOnly Property IsReusable() As Boolean Implements IHttpHandler.IsReusable
        Get
            Return False
        End Get
    End Property

End Class