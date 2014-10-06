<%@ WebHandler Language="VB" Class="DescargaSoportePago" %>

Imports System
Imports System.Web
Imports BLL
Imports BLL.Entidades

Public Class DescargaSoportePago : Implements IHttpHandler
    
    Public Sub ProcessRequest(ByVal context As HttpContext) Implements IHttpHandler.ProcessRequest
        Dim nro_dec As String = context.Request.QueryString("nro_dec")
        
        Dim obj As New Pagos_SopBLL
        Dim dto As Pagos_Sop_DTO
        dto = obj.GetPk(nro_dec)
        
        
        If Not dto Is Nothing Then
            context.Response.Clear()
            'context.Response.ContentType = ""
            context.Response.AddHeader("content-disposition", "attachment; filename=SoportePago" + dto.PAG_NDOC + ".pdf")
            context.Response.BinaryWrite(dto.PAG_SOP)
            context.Response.End()
        End If
    End Sub
 
    Public ReadOnly Property IsReusable() As Boolean Implements IHttpHandler.IsReusable
        Get
            Return False
        End Get
    End Property

End Class