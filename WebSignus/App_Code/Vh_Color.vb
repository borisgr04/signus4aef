Imports Microsoft.VisualBasic
Imports System.ComponentModel
Imports System.Data

Public Class Vh_Color
    Inherits BDDatos2

    Public Function Insert(ByVal NOM_COLOR As String) As String
        Dim na As String

        Me.Conectar()
        Try
            ComenzarTransaccion()
            Me.querystring = "INSERT INTO VH_COLOR(NOM_COLOR) "
            Me.querystring += " VALUES(:NOM_COLOR)"
            CrearComando(querystring)
            AsignarParametroCadena(":NOM_COLOR", UCase(NOM_COLOR))
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

    Public Function Update(ByVal NOM_COLOR_OLD As String, ByVal NOM_COLOR_NEW As String) As String
        Dim na As String

        Me.Conectar()
        Try
            ComenzarTransaccion()
            Me.querystring = "UPDATE VH_MARCA SET NOM_COLOR = :NOM_COLOR_NEW WHERE NOM_COLOR = :NOM_COLOR_OLD"
            CrearComando(querystring)
            AsignarParametroCadena(":NOM_COLOR_OLD", UCase(NOM_COLOR_OLD))
            AsignarParametroCadena(":NOM_COLOR_NEW", UCase(NOM_COLOR_NEW))
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
        Me.querystring = "SELECT * FROM VH_COLOR ORDER BY NOM_COLOR"
        CrearComando(querystring)
        Dim dataTb As DataTable = EjecutarConsultaDataTable()

        Me.Desconectar()
        Return dataTb

    End Function
    <DataObjectMethodAttribute(DataObjectMethodType.Select, True)> _
    Public Function GetPorNombre(ByVal NOM_COLOR As String) As DataTable
        Me.Conectar()
        Me.querystring = "SELECT * FROM VH_COLOR WHERE upper(NOM_COLOR) like '%" + UCase(NOM_COLOR) + "%'"
        CrearComando(querystring)
        Dim dataTb As DataTable = EjecutarConsultaDataTable()

        Me.Desconectar()
        Return dataTb

    End Function
End Class
