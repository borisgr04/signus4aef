Imports Microsoft.VisualBasic
Imports System.ComponentModel
Imports System.Data
'Clase para manejar la Tabla Correose de la Base de datos
'Fecha Creaciòn: 22 dic 2009
'Autor: Ronal Javier

Public Class Correose0
    Inherits BDDatos2
    '---------------------------------------------------------------------------------------------------------------
    ' Funciòn Insert: Agrega datos a la tabla Correose

    Public Function Insert(ByVal CORR_CODI As String, ByVal CORR_NOMB As String, ByVal CORR_DATO As String, ByVal CORR_BODY As String) As String

        Dim na As Integer
        Me.Conectar()
        Try
            ComenzarTransaccion()
            Me.querystring = "INSERT INTO Correose (CORR_CODI,CORR_NOMB,CORR_DATO,CORR_BODY,CORR_USAP)VALUES(:CORR_CODI,:CORR_NOMB,:CORR_DATO,:CORR_BODY,:CORR_USAP)"
            CrearComando(querystring)
            AsignarParametroCadena(":CORR_CODI", CORR_CODI)
            AsignarParametroCadena(":CORR_NOMB", CORR_NOMB)
            AsignarParametroCadena(":CORR_DATO", CORR_DATO)
            AsignarParametroCadena(":CORR_BODY", CORR_BODY)
            AsignarParametroCadena(":CORR_USAP", Me.usuario)
            'Me.usuario

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
    ' Funciòn Actualizar: Acatualiza datos a la tabla Correose
    '    
    Public Function Update(ByVal CORR_CODI_OR As String, ByVal CORR_CODI As String, ByVal CORR_NOMB As String, ByVal CORR_DATO As String, ByVal CORR_BODY As String) As String
        Dim na As String
        Me.Conectar()
        Try
            ComenzarTransaccion()
            Me.querystring = "UPDATE Correose SET CORR_CODI='" + CORR_CODI + "',CORR_NOMB='" + CORR_NOMB + "',CORR_DATO='" + CORR_DATO + "',CORR_BODY='" + CORR_BODY + "'WHERE CORR_CODI='" + CORR_CODI_OR + "'"
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
    'Funciòn Delete: elimina datos a la tabla Correose
    ' Parametros: Tcta_Codi : Còdigo

    Public Function Delete(ByVal CORR_CODI As String) As String
        Dim na As String

        'If (CInt(COD) = 1) Or (CInt(COD) = 2) Or (CInt(COD) = 3) Then

        'Return "Esta Clase de Impuesto, No se puede eliminar"
        'End If
        Me.Conectar()
        Try
            ComenzarTransaccion()
            Me.querystring = "DELETE Correose WHERE CORR_CODI='" + CORR_CODI + "'"
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
        Dim queryString As String = "SELECT * FROM Correose ORDER BY CORR_CODI"
        CrearComando(queryString)
        Dim dataTb As DataTable = EjecutarConsultaDataTable()
        Me.Desconectar()
        Return dataTb
    End Function
    <DataObjectMethodAttribute(DataObjectMethodType.Select, True)> _
    Public Overloads Function GetPorCod(ByVal CORR_CODI As String) As DataTable
        Me.Conectar()
        Dim queryString As String = "SELECT * FROM Correose WHERE CORR_CODI=:CORR_CODI"
        CrearComando(queryString)
        AsignarParametroCadena(":CORR_CODI", CORR_CODI)
        Dim dataTb As DataTable = EjecutarConsultaDataTable()
        Me.Desconectar()
        Return dataTb
    End Function
End Class