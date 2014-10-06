Imports Microsoft.VisualBasic

Imports System.Data
Imports System.ComponentModel
Imports System

Public Class Bancos
    Inherits BDDatos2

    Public Function Insert(ByVal BAN_COD As String, ByVal BAN_NOM As String, ByVal BAN_EST As String) As String

        Dim na As Integer
        Me.Conectar()
        ComenzarTransaccion()
        Try
            querystring = "INSERT INTO Bancos (BAN_COD,BAN_NOM,BAN_EST,BAN_USAP)VALUES(:BAN_COD,:BAN_NOM,:BAN_EST,:BAN_USAP)"
            AsignarParametroCadena(":BAN_COD", BAN_COD)
            AsignarParametroCadena(":BAN_NOM", BAN_NOM)
            AsignarParametroCadena(":BAN_EST", BAN_EST)

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
    ' Funciòn Actualizar: Acatualiza datos a la tabla Bancos
    '    Parametros: Tpag_Cod : Còdigo
    '                Tpag_Nom : Nombre del parametro

    Public Function Update(ByVal BAN_COD_OR As String, ByVal BAN_COD As String, ByVal BAN_NOM As String, ByVal BAN_EST As String) As String
        Dim na As String
        Me.Conectar()
        ComenzarTransaccion()
        Try
            querystring = "UPDATE Bancos SET BAN_COD='" + BAN_COD + "',BAN_NOM='" + BAN_NOM + "',BAN_EST='" + BAN_EST + "'  WHERE BAN_COD='" + BAN_COD_OR + "' "
            na = EjecutarComando()
            Me.Msg = MsgOk + "<BR> Registros Actualizados [" + na + "]"
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
    Public Function Delete(ByVal BAN_COD As String) As String
        Dim x As String
        Me.Conectar()
        ComenzarTransaccion()
        Try
            querystring = "DELETE BANCOS WHERE BAN_COD='" + BAN_COD + "'"
            x = EjecutarComando()
            Me.msg = MsgOk + " # Registros Eliminados:" + x.ToString
            Me.lErrorG = False
            ConfirmarTransaccion()
        Catch ex As Exception
            CancelarTransaccion()
            Me.lErrorG = True
            Me.Msg = "Error de App:" + ex.Message
        Finally
            Me.Desconectar()
        End Try
        Return msg
    End Function
    <DataObjectMethodAttribute(DataObjectMethodType.Select, True)> _
    Public Overrides Function GetRecords() As DataTable
        Me.Conectar()
        querystring = "SELECT * FROM vBANCOS ORDER BY BAN_NOM"
        CrearComando(querystring)
        Dim dataTb As DataTable = EjecutarConsultaDataTable()
        Me.Desconectar()
        Return dataTb
    End Function

    <DataObjectMethodAttribute(DataObjectMethodType.Select, True)> _
    Public Function GetCuentas(ByVal busc As String) As DataTable
        Me.Conectar()
        querystring = "Select * From cta_banco Inner Join bancos On Cta_Baco=Ban_cod Where Cta_Est='AC' And (Cta_Nro like '%" + busc + "%') OR (Upper(Cta_Desc) like '%" + UCase(busc) + "%')"
        CrearComando(querystring)
        Dim dataTb As DataTable = EjecutarConsultaDataTable()
        Me.Desconectar()
        Return dataTb
    End Function

    <DataObjectMethodAttribute(DataObjectMethodType.Select, True)> _
    Public Overloads Function GetPorCod(ByVal Cod As String) As DataTable
        Me.Conectar()
        querystring = "SELECT * FROM Bancos WHERE BAN_COD=:BAN_COD"
        CrearComando(querystring)
        AsignarParametroCadena(":BAN_COD", Cod)
        Dim dataTb As DataTable = EjecutarConsultaDataTable()
        Me.Desconectar()
        Return dataTb
    End Function
End Class
