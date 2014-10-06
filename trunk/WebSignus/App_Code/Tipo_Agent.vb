Imports Microsoft.VisualBasic
Imports System.Data
Imports System.ComponentModel
Imports System

'Clase para manejar la Tabla Tipo_Agent de la Base de datos
'Fecha Creaciòn: 09 dic 2009
'Autor: Ronal Javier

Public Class Tipo_Agent
    Inherits BDDatos2
    '---------------------------------------------------------------------------------------------------------------
    ' Funciòn Insert: Agrega datos a la tabla Tipo_Agent

    Public Function Insert(ByVal TAG_COD As String, ByVal TAG_NOM As String, ByVal TAG_EST As String) As String

        Dim na As Integer
        Me.Conectar()
        Try
            ComenzarTransaccion()
            Me.querystring = "INSERT INTO Tipo_Agent (TAG_COD,TAG_NOM,TAG_EST,TAG_USAP)VALUES(:TAG_COD,:TAG_NOM,:TAG_EST,:TAG_USAP)"
            CrearComando(querystring)
            AsignarParametroCadena(":TAG_COD", TAG_COD)
            AsignarParametroCadena(":TAG_NOM", TAG_NOM)
            AsignarParametroCadena(":TAG_EST", TAG_EST)
            AsignarParametroCadena(":TAG_USAP", Me.usuario)
            'Me.usuario

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
    ' Funciòn Actualizar: Actualiza datos a la tabla Tipo_Agent

    Public Function Update(ByVal TAG_COD_OR As String, ByVal TAG_COD As String, ByVal TAG_NOM As String, ByVal TAG_EST As String) As String
        Dim na As String
        Me.Conectar()
        Try
            ComenzarTransaccion()
            Me.querystring = "UPDATE Tipo_Agent SET TAG_COD='" + TAG_COD + "',TAG_NOM='" + TAG_NOM + "',TAG_EST='" + TAG_EST + "' WHERE TAG_COD='" + TAG_COD_OR + "'"
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
    ' Funciòn Delete: Borra datos a la tabla Tipo_Agent

    Public Function Delete(ByVal COD As String) As String
        Dim na As String

        'If (CInt(COD) = 1) Or (CInt(COD) = 2) Or (CInt(COD) = 3) Then

        'Return "Esta Clase de Impuesto, No se puede eliminar"
        'End If
        Me.Conectar()
        Try
            ComenzarTransaccion()
            Me.querystring = "DELETE Tipo_Agent WHERE TAG_COD='" + COD + "'"
            CrearComando(querystring)
            na = EjecutarComando()
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
        Dim queryString As String = "SELECT * FROM Tipo_Agent ORDER BY TAG_COD"
        CrearComando(queryString)
        Dim dataTb As DataTable = EjecutarConsultaDataTable()
        Me.Desconectar()
        Return dataTb

    End Function
    <DataObjectMethodAttribute(DataObjectMethodType.Select, True)> _
    Public Overloads Function GetPorCod(ByVal Cod As String) As DataTable
        Me.Conectar()
        Dim queryString As String = "SELECT * FROM Tipo_Agent WHERE TAG_COD=:TAG_COD "
        CrearComando(queryString)
        AsignarParametroCadena(":TAG_COD", Cod)
        Dim dataTb As DataTable = EjecutarConsultaDataTable()
        Me.Desconectar()
        Return dataTb

    End Function


End Class
