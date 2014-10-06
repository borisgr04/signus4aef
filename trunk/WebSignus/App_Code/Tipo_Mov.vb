Imports Microsoft.VisualBasic
Imports System.Data
Imports System.ComponentModel
Imports System

'Clase para manejar la Tabla Tipo_Mov de la Base de datos
'Fecha Creaciòn: 09 dic 2009
'Autor: Ronal Javier

Public Class Tipo_Mov
    Inherits BDDatos2
    '---------------------------------------------------------------------------------------------------------------
    ' Funciòn Insert: Agrega datos a la tabla Tipo_Mov

    Public Function Insert(ByVal TMOV_COD As String, ByVal TMOV_NOM As String) As String

        Dim na As Integer
        Me.Conectar()
        Try
            ComenzarTransaccion()
            Me.querystring = "INSERT INTO Tipo_Mov (TMOV_COD,TMOV_NOM,TMOV_USAP)VALUES(:TMOV_COD,:TMOV_NOM,:TMOV_USAP)"
            CrearComando(querystring)
            AsignarParametroCadena(":TMOV_COD", TMOV_COD)
            AsignarParametroCadena(":TMOV_NOM", TMOV_NOM)
            AsignarParametroCadena(":TMOV_USAP", Me.usuario)
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
    ' Funciòn Actualizar: Actualiza datos a la tabla Tipo_Mov

    Public Function Update(ByVal TMOV_COD_OR As String, ByVal TMOV_COD As String, ByVal TMOV_NOM As String) As String
        Dim na As String
        Me.Conectar()
        Try
            ComenzarTransaccion()
            Me.querystring = "UPDATE Tipo_Mov SET TMOV_COD='" + TMOV_COD + "',TMOV_NOM='" + TMOV_NOM + "' WHERE TMOV_COD='" + TMOV_COD_OR + "'"
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
    ' Funciòn Delete: Borra datos a la tabla Tipo_Mov

    Public Function Delete(ByVal COD As String) As String
        Dim na As String

        'If (CInt(COD) = 1) Or (CInt(COD) = 2) Or (CInt(COD) = 3) Then

        'Return "Esta Clase de Impuesto, No se puede eliminar"
        'End If
        Me.Conectar()
        Try
            ComenzarTransaccion()

            Me.querystring = "DELETE Tipo_Mov WHERE TMOV_COD='" + COD + "'"
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
        Dim queryString As String = "SELECT * FROM Tipo_Mov ORDER BY TMOV_COD"
        CrearComando(queryString)
        Dim dataTb As DataTable = EjecutarConsultaDataTable()
        Me.Desconectar()
        Return dataTb

    End Function
    <DataObjectMethodAttribute(DataObjectMethodType.Select, True)> _
    Public Overloads Function GetPorCod(ByVal Cod As String) As DataTable
        Me.Conectar()
        Dim queryString As String = "SELECT * FROM Tipo_Mov WHERE TMOV_COD=:TMOV_COD "
        CrearComando(queryString)
        AsignarParametroCadena(":TMOV_COD", Cod)
        Dim dataTb As DataTable = EjecutarConsultaDataTable()
        Me.Desconectar()
        Return dataTb

    End Function



End Class
