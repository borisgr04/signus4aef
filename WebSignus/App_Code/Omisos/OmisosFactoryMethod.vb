Imports Microsoft.VisualBasic
Imports System.Data
Imports System.ComponentModel

Interface OmisosFactoryMethod

    <DataObjectMethodAttribute(DataObjectMethodType.Select, True)> _
    Function create(Cant_Per As Integer) As COmisos
End Interface

