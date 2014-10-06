Imports Microsoft.VisualBasic
Imports System.ComponentModel
Imports System.Data

Public Class OmisosFactory
    Inherits BDDatos2
    Implements OmisosFactoryMethod

    Property RutaReport As String
  


    Public Function create(Cant_Per As Integer) As COmisos Implements OmisosFactoryMethod.create
        If Cant_Per > 12 Then
            Return New Omisos24Per()
        Else
            Return New Omisos12Per()
        End If
    End Function

      
End Class
