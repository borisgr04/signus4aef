Imports Microsoft.VisualBasic
Imports System.ComponentModel
Imports System.Data


Public Interface COmisos
    Property RutaReport As String
    Function Get_omisos(ByVal Cla_Dec As String, ByVal Vig As String, ByVal nit As String, ByVal mpio As String, ByVal tipoAgen As String, ByVal calendario As DataTable) As DataTable
    Function isDecPer(ByVal Cla_Dec As String, ByVal nit As String, ByVal Vig As String, Per As String) As Integer
End Interface
