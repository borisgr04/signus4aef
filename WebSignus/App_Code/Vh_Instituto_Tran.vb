Imports Microsoft.VisualBasic
Imports System.ComponentModel
Imports System.Data

Public Class Vh_Instituto_Tran
    Inherits BDDatos2

    Public Function Insert(ByVal VINS_DESCRIPCION As String, ByVal VINS_CODIGO As String) As String
        Dim na As String

        Me.Conectar()
        Try
            ComenzarTransaccion()
            Me.querystring = "INSERT INTO VH_INSTITUTO_TRANSITO(VINS_CODIGO, VINS_DESCRIPCION) "
            Me.querystring += " VALUES(:VINS_CODIGO, :VINS_DESCRIPCION)"
            CrearComando(querystring)
            AsignarParametroCadena(":VINS_CODIGO", UCase(VINS_CODIGO))
            AsignarParametroCadena(":VINS_DESCRIPCION", UCase(VINS_DESCRIPCION))
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

    Public Function Update(ByVal VINS_CODIGO As String, ByVal VINS_DESCRIPCION As String) As String
        Dim na As String

        Me.Conectar()
        Try
            ComenzarTransaccion()
            Me.querystring = "UPDATE VH_INSTITUTO_TRANSITO SET VINS_DESCRIPCION = :VINS_DESCRIPCION WHERE VINS_CODIGO = :VINS_CODIGO"
            CrearComando(querystring)
            AsignarParametroCadena(":VINS_DESCRIPCION", UCase(VINS_DESCRIPCION))
            AsignarParametroCadena(":VINS_CODIGO", UCase(VINS_CODIGO))
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
        Me.querystring = "SELECT * FROM VH_INSTITUTO_TRANSITO ORDER BY VINS_DESCRIPCION"
        CrearComando(querystring)
        Dim dataTb As DataTable = EjecutarConsultaDataTable()

        Me.Desconectar()
        Return dataTb

    End Function
    <DataObjectMethodAttribute(DataObjectMethodType.Select, True)> _
    Public Function GetPorNombre(ByVal VINS_DESCRIPCION As String) As DataTable
        Me.Conectar()
        Me.querystring = "SELECT * FROM VH_INSTITUTO_TRANSITO WHERE upper(VINS_DESCRIPCION) like '%" + UCase(VINS_DESCRIPCION) + "%'"
        CrearComando(querystring)
        Dim dataTb As DataTable = EjecutarConsultaDataTable()

        Me.Desconectar()
        Return dataTb

    End Function

End Class
