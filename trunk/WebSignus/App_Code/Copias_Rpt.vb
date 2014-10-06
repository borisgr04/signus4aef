Imports Microsoft.VisualBasic
Imports System.Data
Imports System.ComponentModel
'Clase para manejar la Tabla Copias_Rpt de la Base de datos
'Fecha Creaciòn: 10 dic 2009
'Autor: Ronal Javier

Public Class Copias_Rpt
    Inherits BDDatos2
    '---------------------------------------------------------------------------------------------------------------
    ' Funciòn Insert: Agrega datos a la tabla Copias_Rpt

    Public Function Insert(ByVal COP_COD As String, ByVal COP_NOM As String) As String

        Dim na As Integer
        Me.Conectar()
        Try
            ComenzarTransaccion()
            Me.querystring = "INSERT INTO Copias_Rpt (COP_COD,COP_NOM,COP_USAP)VALUES(:COP_COD,:COP_NOM,:COP_USAP)"
            CrearComando(querystring)
            AsignarParametroCadena(":COP_COD", COP_COD)
            AsignarParametroCadena(":COP_NOM", COP_NOM)
            AsignarParametroCadena(":COP_USAP", Me.usuario)
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
    ' Funciòn Actualizar: Actualiza datos a la tabla Copias_Rpt

    Public Function Update(ByVal COP_COD_or As String, ByVal COP_COD As String, ByVal COP_NOM As String) As String
        Dim na As String
        Me.Conectar()
        Try
            ComenzarTransaccion()
            Me.querystring = "UPDATE Copias_Rpt SET COP_COD='" + COP_COD + "',COP_NOM='" + COP_NOM + "' WHERE COP_COD='" + COP_COD_or + "'"
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
    ' Funciòn Delete: Borra datos a la tabla Copias_Rpt

    Public Function Delete(ByVal COD As String) As String
        Dim na As String

        'If (CInt(COD) = 1) Or (CInt(COD) = 2) Or (CInt(COD) = 3) Then

        'Return "Esta Clase de Impuesto, No se puede eliminar"
        'End If
        Me.Conectar()
        Try
            ComenzarTransaccion()
            Me.querystring = "DELETE Copias_Rpt WHERE COP_COD='" + COD + "'"
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
        Dim queryString As String = "SELECT * FROM Copias_Rpt ORDER BY COP_COD"
        CrearComando(queryString)
        Dim dataTb As DataTable = EjecutarConsultaDataTable()
        Me.Desconectar()
        Return dataTb
    End Function
    <DataObjectMethodAttribute(DataObjectMethodType.Select, True)> _
    Public Overloads Function GetPorCod(ByVal Cod As String) As DataTable
        Me.Conectar()
        Dim queryString As String = "SELECT * FROM Copias_Rpt WHERE COP_COD=:COP_COD "
        CrearComando(queryString)
        AsignarParametroCadena(":COP_COD", Cod)
        Dim dataTb As DataTable = EjecutarConsultaDataTable()
        Me.Desconectar()
        Return dataTb
    End Function
End Class