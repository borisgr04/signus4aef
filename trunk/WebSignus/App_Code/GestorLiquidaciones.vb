Imports Microsoft.VisualBasic
Imports System
Imports System.Collections

Public Class GestorLiquidaciones

    Private hLiquidaciones As Hashtable
    Sub New()
        hLiquidaciones = New Hashtable()
    End Sub

    Public Sub Add(ByVal idLiq As Guid, ByVal t As Vh_Liquidaciones)
        hLiquidaciones.Add(idLiq, t)
    End Sub

    Public Sub Remove(ByVal idLiq As Guid)
        hLiquidaciones.Remove(idLiq)
    End Sub

    Public Function GetLiquidacion(ByVal id As Guid) As Vh_Liquidaciones
        Dim resultado As Vh_Liquidaciones
        If (hLiquidaciones.ContainsKey(id)) Then
            resultado = DirectCast(hLiquidaciones(id), Vh_Liquidaciones)
        Else
            resultado = Nothing
        End If

        Return resultado
    End Function

End Class

Public Class GestorL
    Public Shared _instancia As GestorLiquidaciones = New GestorLiquidaciones()

    Public ReadOnly Property Gestor As GestorLiquidaciones
        Get
            Return _instancia
        End Get
    End Property
End Class



