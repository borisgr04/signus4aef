Imports Microsoft.VisualBasic
Imports System.ComponentModel
Imports System.Data

Public Class Vh_Carroceria
    Inherits BDDatos2

    Public Function Insert(ByVal NOM_CARROCERIA As String) As String
        Dim na As String

        Me.Conectar()
        Try
            ComenzarTransaccion()
            Me.querystring = "INSERT INTO VH_CARROCERIA(NOM_CARROCERIA) "
            Me.querystring += " VALUES(:NOM_CARROCERIA)"
            CrearComando(querystring)
            AsignarParametroCadena(":NOM_CARROCERIA", UCase(NOM_CARROCERIA))
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

    Public Function Update(ByVal NOM_CARROCERIA_OLD As String, ByVal NOM_CARROCERIA_NEW As String) As String
        Dim na As String

        Me.Conectar()
        Try
            ComenzarTransaccion()
            Me.querystring = "UPDATE VH_CARROCERIA SET NOM_CARROCERIA = :NOM_CARROCERIA_NEW WHERE NOM_CARROCERIA = :NOM_CARROCERIA_OLD"
            CrearComando(querystring)
            AsignarParametroCadena(":NOM_CARROCERIA_OLD", UCase(NOM_CARROCERIA_OLD))
            AsignarParametroCadena(":NOM_CARROCERIA_NEW", UCase(NOM_CARROCERIA_NEW))
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
        Me.querystring = "SELECT * FROM VH_CARROCERIA ORDER BY NOM_CARROCERIA"
        CrearComando(querystring)
        Dim dataTb As DataTable = EjecutarConsultaDataTable()

        Me.Desconectar()
        Return dataTb

    End Function
    <DataObjectMethodAttribute(DataObjectMethodType.Select, True)> _
    Public Function GetPorNombre(ByVal NOM_CARROCERIA As String) As DataTable
        Me.Conectar()
        Me.querystring = "SELECT * FROM VH_CARROCERIA WHERE upper(NOM_CARROCERIA) like '%" + UCase(NOM_CARROCERIA) + "%'"
        CrearComando(querystring)
        Dim dataTb As DataTable = EjecutarConsultaDataTable()

        Me.Desconectar()
        Return dataTb

    End Function
End Class
