'// (c) Copyright Microsoft Corporation.
'// This source is subject to the Microsoft Permissive License.
'// See http://www.microsoft.com/resources/sharedsource/licensingbasics/sharedsourcelicenses.mspx.
'// All other rights reserved.
Imports Microsoft.VisualBasic
Imports System
Imports System.Collections.Generic
Imports System.Web.Services

Imports System.Data
Imports Signus

<System.Web.Script.Services.ScriptService()> <WebService(Namespace:="http://microsoft.com/webservices/")> Public Class AutoComplete
    Inherits WebService

    <WebMethod()> Public Function GetTerceros(ByVal prefixText As String, ByVal count As Integer) As String()

        Dim obj As New Terceros
        Dim lerrorg As Boolean = False

        If (count = 0) Then
            count = 10
        End If

        'If (prefixText.Equals("xyz")) Then
        ' Return New String(0)
        'End If

        Dim datat As New DataTable
        datat = obj.GetRecords(prefixText)

        Dim items As List(Of String) = New List(Of String)(count)
        Dim i As Integer
        Dim Sal As String
        If datat.Rows.Count > 0 Then

            For i = 0 To datat.Rows.Count - 1
                Sal = datat.Rows(i).Item("Ter_Nom").ToString()
                items.Add(Sal)
            Next i
        Else
            count = 0
            items.Add("****** . No se ha encontrado coincidencias.")
        End If


        Return items.ToArray()
    End Function
    <WebMethod()> Public Function GetImpuestos(ByVal prefixText As String, ByVal count As Integer) As String()

        Dim obj As New Impuestos
        Dim lerrorg As Boolean = False

        

        'If (prefixText.Equals("xyz")) Then
        ' Return New String(0)
        'End If

        Dim datat As New DataTable
        datat = obj.GetRecords(prefixText)

        If (count = 0) Then
            count = 10
        End If
        If count > datat.Rows.Count Then
            count = datat.Rows.Count
        End If

        Dim items As List(Of String) = New List(Of String)(count)
        Dim i As Integer
        Dim Sal As String
        items.Add("****** . No se ha encontrado coincidencias.")
        If datat.Rows.Count > 0 Then

            For i = 0 To datat.Rows.Count - 1
                Sal = datat.Rows(i).Item("Imp_Nom").ToString()
                items.Add(Sal)
            Next i
        Else
            count = 0
            items.Add("****** . No se ha encontrado coincidencias.")
        End If
        Return items.ToArray()
    End Function
    <WebMethod()> Public Function GetTercero(ByVal Nit As String) As String

        Dim obj As New Terceros
        Dim lerrorg As Boolean = False
        Dim sal As String

        Dim datat As New DataTable
        datat = obj.GetByIde(Nit)

        If datat.Rows.Count > 0 Then
            sal = datat.Rows(0).Item("Ter_Nom").ToString()
        Else
            sal = "no encontrado!!"
        End If
        Return sal
    End Function

End Class
