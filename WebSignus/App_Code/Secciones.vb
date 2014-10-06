Imports Microsoft.VisualBasic
Imports System.Data
Imports System.ComponentModel
Imports System

'Clase para manejar la Tabla Secciones de la Base de datos
'Fecha Creaciòn: 15 dic 2009
'Autor: Ronal Javier

Public Class Secciones
    Inherits BDDatos2
    '---------------------------------------------------------------------------------------------------------------
    ' Funciòn Insert: Agrega datos a la tabla Secciones

    Public Function Insert(ByVal SECC_CODI As String, ByVal SECC_NOMB As String) As String

        Dim na As Integer
        Me.Conectar()
        Try
            ComenzarTransaccion()
            Me.querystring = "INSERT INTO Secciones (SECC_CODI,SECC_NOMB,SECC_USAP)VALUES(:SECC_CODI,:SECC_NOMB,:SECC_USAP)"
            AsignarParametroCadena(":SECC_CODI", SECC_CODI)
            AsignarParametroCadena(":SECC_NOMB", SECC_NOMB)
            AsignarParametroCadena(":SECC_USAP", Me.usuario)
            'Me.usuario

            na = Me.querystring
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
    ' Funciòn Actualizar: Acatualiza datos a la tabla Secciones

    Public Function Update(ByVal SECC_CODI_OR As String, ByVal SECC_CODI As String, ByVal SECC_NOMB As String) As String
        Dim na As String
        Me.Conectar()
        Try
            ComenzarTransaccion()
            Me.querystring = "UPDATE Secciones SET SECC_CODI='" + SECC_CODI + "',SECC_NOMB='" + SECC_NOMB + "' WHERE SECC_CODI='" + SECC_CODI_OR + "'"
            CrearComando(querystring)
            na = Me.querystring
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
    'Funciòn Delete: elimina datos a la tabla Secciones

    Public Function Delete(ByVal CODI As String) As String
        Dim na As String

        'If (CInt(COD) = 1) Or (CInt(COD) = 2) Or (CInt(COD) = 3) Then

        'Return "Esta Clase de Impuesto, No se puede eliminar"
        'End If
        Me.Conectar()
        Try
            ComenzarTransaccion()

            Me.querystring = "DELETE Secciones WHERE SECC_CODI='" + CODI + "'"
            CrearComando(querystring)
            na = Me.querystring
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
        Dim queryString As String = "SELECT * FROM Secciones ORDER BY SECC_CODI"
        CrearComando(queryString)
        Dim dataTb As DataTable = EjecutarConsultaDataTable()
        Me.Desconectar()
        Return dataTb

    End Function
    <DataObjectMethodAttribute(DataObjectMethodType.Select, True)> _
    Public Overloads Function GetPorCod(ByVal Cod As String) As DataTable
        Me.Conectar()
        Dim queryString As String = "SELECT * FROM Secciones WHERE SECC_CODI=:SECC_CODI "
        CrearComando(queryString)
        AsignarParametroCadena(":SECC_CODI", Cod)
        Dim dataTb As DataTable = EjecutarConsultaDataTable()
        Me.Desconectar()
        Return dataTb

    End Function

End Class
