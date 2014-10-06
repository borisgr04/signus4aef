Imports Microsoft.VisualBasic
Imports System.ComponentModel
Imports System.Data
Public Class Tram_Rela
    Inherits BDDatos2

    Public Function Insert(ByVal TRRE_DESD As String, ByVal TRRE_PARA As String) As String

        Dim na As Integer
        Me.Conectar()
        Try
            ComenzarTransaccion()
            Me.querystring = "INSERT INTO TRAMRELA (TRRE_DESD, TRRE_PARA) VALUES (:TRRE_DESD,:TRRE_PARA)"
            CrearComando(querystring)
            AsignarParametroCadena(":TRRE_DESD", TRRE_DESD)
            AsignarParametroCadena(":TRRE_PARA", TRRE_PARA)
            na = EjecutarComando()
            ConfirmarTransaccion()
            Me.Msg = MsgOk + "<BR> Número de Filas Afectadas " + na.ToString
            Me.lErrorG = False
        Catch ex As Exception
            Me.lErrorG = True
            Me.Msg = "Error de App:" + ex.Message
            CancelarTransaccion()
        Finally
            Me.Desconectar()
        End Try


        Return Msg
    End Function


    Public Function Delete(ByVal TRRE_DESD As String, ByVal TRRE_PARA As String) As String
        Dim na As String
        Me.Conectar()
        Try
            ComenzarTransaccion()
            Me.querystring = "DELETE TRAMRELA WHERE TRRE_DESD = :TRRE_DESD AND TRRE_PARA = :TRRE_PARA "
            CrearComando(querystring)
            AsignarParametroCadena(":TRRE_DESD", TRRE_DESD)
            AsignarParametroCadena(":TRRE_PARA", TRRE_PARA)
            na = EjecutarComando()
            ConfirmarTransaccion()
            Me.Msg = MsgOk + " # Registros Eliminados:" + na.ToString
            Me.lErrorG = False
        Catch ex As Exception
            Me.lErrorG = True
            Me.Msg = "Error de App:" + ex.Message
            CancelarTransaccion()
        Finally
            Me.Desconectar()
        End Try
        Return Msg
    End Function

    <DataObjectMethodAttribute(DataObjectMethodType.Select, True)> _
    Public Overrides Function GetRecords() As DataTable
        Me.Conectar()
        Me.querystring = "SELECT * FROM VTRAMRELA"
        CrearComando(querystring)
        Dim dataTb As DataTable = EjecutarConsultaDataTable()
        Me.Desconectar()
        Return dataTb
    End Function
End Class
