Imports Microsoft.VisualBasic
Imports System.Data
Imports System.ComponentModel
Imports System

'Clase para manejar la Tabla Tipo_Conceptos de la Base de datos
'Fecha Creaciòn: 10 dic 2009
'Autor: Ronal Javier

Public Class Tipo_Conceptos
    Inherits BDDatos2
    '---------------------------------------------------------------------------------------------------------------
    ' Funciòn Insert: Agrega datos a la tabla Tipo_Conceptos

    Public Function Insert(ByVal TCON_COD As String, ByVal TCON_NOM As String) As String

        Dim na As Integer
        Me.Conectar()
        Try
            ComenzarTransaccion()
            Me.querystring = "INSERT INTO Tipo_Conceptos (TCON_COD,TCON_NOM,TCON_USAP)VALUES(:TCON_COD,:TCON_NOM,:TCON_USAP)"
            AsignarParametroCadena(":TCON_COD", TCON_COD)
            AsignarParametroCadena(":TCON_NOM", TCON_NOM)
            AsignarParametroCadena(":DR_USAP", Me.usuario)
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
    ' Funciòn Actualizar: Actualiza datos a la tabla Tipo_Conceptos

    Public Function Update(ByVal TCON_COD_or As String, ByVal TCON_COD As String, ByVal TCON_NOM As String) As String
        Dim na As String
        Me.Conectar()
        Try
            ComenzarTransaccion()
            Me.querystring = "UPDATE Tipo_Conceptos SET TCON_COD='" + TCON_COD + "',TCON_NOM='" + TCON_NOM + "' WHERE TCON_COD='" + TCON_COD_or + "'"
            CrearComando(querystring)
            na = EjecutarComando()
            Me.Msg = MsgOk + "<BR> Registros Actualizados [" + na + "]"
            ConfirmarTransaccion()
            Me.lErrorG = False
        Catch ex As Exception
            CancelarTransaccion()
            Me.lErrorG = True
            Me.Msg = "Error de App:" + ex.Message
        Finally
            Me.Desconectar()
        End Try

        Return Msg
    End Function
    ' Funciòn Delete: Borra datos a la tabla Tipo_Conceptos

    Public Function Delete(ByVal COD As String) As String
        Dim na As String

        'If (CInt(COD) = 1) Or (CInt(COD) = 2) Or (CInt(COD) = 3) Then

        'Return "Esta Clase de Impuesto, No se puede eliminar"
        'End If
        Me.Conectar()
        Try
            ComenzarTransaccion()

            Me.querystring = "DELETE Tipo_Conceptos WHERE TCON_COD='" + COD + "'"
            CrearComando(querystring)
            na = EjecutarComando()
            Me.Msg = MsgOk + " # Registros Eliminados:" + na.ToString
            Me.lErrorG = False
            ConfirmarTransaccion()
        Catch ex As Exception
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
        Dim queryString As String = "SELECT * FROM vTipo_Conceptos ORDER BY TCON_COD"
        CrearComando(queryString)
        Dim dataTb As DataTable = EjecutarConsultaDataTable()
        Me.Desconectar()
        Return dataTb

    End Function
    <DataObjectMethodAttribute(DataObjectMethodType.Select, True)> _
    Public Overloads Function GetPorCod(ByVal Cod As String) As DataTable
        Me.Conectar()
        Dim queryString As String = "SELECT * FROM Tipo_Conceptos WHERE TCON_COD=:TCON_COD"
        CrearComando(queryString)
        AsignarParametroCadena(":TCON_COD", Cod)
        Dim dataTb As DataTable = EjecutarConsultaDataTable()
        Me.Desconectar()
        Return dataTb

    End Function

End Class
