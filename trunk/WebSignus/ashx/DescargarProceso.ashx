<%@ WebHandler Language="VB" Class="DescargarProceso" %>

Imports System
Imports System.Web
Imports System.Data

Public Class DescargarProceso : Implements IHttpHandler
    
    Public Sub ProcessRequest(ByVal context As HttpContext) Implements IHttpHandler.ProcessRequest
        Dim numProc As String = context.Request.QueryString("numProc")
        Dim tram As String = context.Request.QueryString("Tram")
        Dim formato As String = context.Request.QueryString("formato")
        Dim campo As String = "PRLT_DOC"
        Dim obj As New Proc_Lote
        Dim dt As DataTable = obj.GetPorID(numProc, tram)
        
        If formato = ".pdf" Then
            campo = "PRLT_PDF"
        End If
                
        If dt.Rows.Count > 0 Then
            context.Response.Clear()
            context.Response.AddHeader("content-disposition", "attachment; filename=Proceso" + numProc + formato)
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