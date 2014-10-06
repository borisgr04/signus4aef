Imports Microsoft.VisualBasic

Imports System.Data
Imports System.ComponentModel
Imports System
'Clase para manejar la Tabla Bancos de la Base de datos
'Fecha Creaciòn: 21 dic 2009
'Autor: Ronal Javier

Public Class Bancos1
    Inherits BDDatos2
    '---------------------------------------------------------------------------------------------------------------
    ' Funciòn Insert: Agrega datos a la tabla Bancos
    ' Parametros: TPAG_Cod : Còdigo
    '             TPAG_Nom : nombre del parametro

    Public Function Insert(ByVal BAN_COD As String, ByVal BAN_NOM As String, ByVal BAN_EST As String) As String

        Dim na As Integer
        Me.Conectar()
        ComenzarTransaccion()
        Try
            Me.querystring = "INSERT INTO Bancos (BAN_COD,BAN_NOM,BAN_EST)VALUES(:BAN_COD,:BAN_NOM,:BAN_EST)"
            CrearComando(querystring)
            AsignarParametroCadena(":BAN_COD", BAN_COD)
            AsignarParametroCadena(":BAN_NOM", BAN_NOM)
            AsignarParametroCadena(":BAN_EST", BAN_EST)

            
            na = EjecutarComando
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
            Me.querystring = "UPDATE Bancos SET BAN_COD='" + BAN_COD + "',BAN_NOM='" + BAN_NOM + "',BAN_EST='" + BAN_EST + "'  WHERE BAN_COD='" + BAN_COD_OR + "' "
            CrearComando(querystring)
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
    'Funciòn Delete: elimina datos a la tabla Bancos
    ' Parametros: TPAG_Cod : Còdigo
    '             TPAG_Nom: Clase de Declaracion

    Public Function Delete(ByVal BAN_COD As String) As String
        Dim na As String
        Me.Conectar()
        ComenzarTransaccion()
        Try
            Me.querystring = "DELETE Bancos WHERE BAN_COD='" + BAN_COD + "'"
            CrearComando(querystring)
            na = EjecutarComando
            Me.Msg = MsgOk + " # Registros Eliminados:" + na.ToString
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
        Dim queryString As String = "SELECT * FROM Bancos ORDER BY BAN_COD"
        CrearComando(querystring)
        Dim dataTb As DataTable = EjecutarConsultaDataTable()
        Me.Desconectar()
        Return dataTb
    End Function
    <DataObjectMethodAttribute(DataObjectMethodType.Select, True)> _
    Public Overloads Function GetPorCod(ByVal Cod As String) As DataTable
        Me.Conectar()
        Dim queryString As String = "SELECT * FROM Bancos WHERE BAN_COD=:BAN_COD"
        CrearComando(querystring)
        AsignarParametroCadena(":BAN_COD", Cod)
        Dim dataTb As DataTable = EjecutarConsultaDataTable()
        Me.Desconectar()
        Return dataTb
    End Function
End Class
