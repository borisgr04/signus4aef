Imports Microsoft.VisualBasic
Imports System.ComponentModel
Imports System.Data

Public Class Vh_Marca
    Inherits BDDatos2

    Public Function Insert(ByVal NOM_MARCA As String) As String
        Dim na As String

        Me.Conectar()
        Try
            ComenzarTransaccion()
            Me.querystring = "INSERT INTO VH_MARCA(NOM_MARCA) "
            Me.querystring += " VALUES(:NOM_MARCA)"
            CrearComando(querystring)
            AsignarParametroCadena(":NOM_MARCA", UCase(NOM_MARCA))
            na = EjecutarComando()
            Me.Msg = MsgOk + "<BR> Número de Filas Afectadas " + na.ToString
            Me.lErrorG = False
            ConfirmarTransaccion()
        Catch ex As Exception
            CancelarTransaccion()
            Me.lErrorG = True
            Me.Msg = "Error de App:" + ex.Message
        Finally
            Me.Desconectar()
        End Try

        Return Msg

    End Function

    Public Function Update(ByVal NOM_MARCA_OLD As String, ByVal NOM_MARCA_NEW As String) As String
        Dim na As String

        Me.Conectar()
        Try
            ComenzarTransaccion()
            Me.querystring = "UPDATE VH_MARCA SET NOM_MARCA = :NOM_MARCA_NEW WHERE NOM_MARCA = :NOM_MARCA_OLD"
            CrearComando(querystring)
            AsignarParametroCadena(":NOM_MARCA_OLD", UCase(NOM_MARCA_OLD))
            AsignarParametroCadena(":NOM_MARCA_NEW", UCase(NOM_MARCA_NEW))
            na = EjecutarComando()
            Me.Msg = MsgOk + "<BR> Número de Filas Afectadas " + na.ToString
            Me.lErrorG = False
            ConfirmarTransaccion()
        Catch ex As Exception
            CancelarTransaccion()
            Me.lErrorG = True
            Me.Msg = "Error de App:" + ex.Message
        Finally
            Me.Desconectar()
        End Try

        Return Msg

    End Function

    <DataObjectMethodAttribute(DataObjectMethodType.Select, True)> _
    Public Overrides Function GetRecords() As DataTable
        Me.Conectar()
        Me.querystring = "SELECT * FROM VH_MARCA ORDER BY NOM_MARCA"
        CrearComando(querystring)
        Dim dataTb As DataTable = EjecutarConsultaDataTable()

        Me.Desconectar()
        Return dataTb

    End Function
    <DataObjectMethodAttribute(DataObjectMethodType.Select, True)> _
    Public Function GetPorNombre(ByVal NOM_MARCA As String) As DataTable
        Me.Conectar()
        Me.querystring = "SELECT * FROM VH_MARCA WHERE upper(NOM_MARCA) like '%" + UCase(NOM_MARCA) + "%'"
        CrearComando(querystring)
        Dim dataTb As DataTable = EjecutarConsultaDataTable()

        Me.Desconectar()
        Return dataTb

    End Function
End Class
