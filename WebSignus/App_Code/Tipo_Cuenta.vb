Imports Microsoft.VisualBasic
Imports System.Data
Imports System.ComponentModel
Imports System

'Clase para manejar la Tabla Tipo_cuenta de la Base de datos
'Fecha Creaciòn: 02 dic 2009
'Autor: Ronal Javier
Public Class Tipo_Cuenta
    Inherits BDDatos2
    '---------------------------------------------------------------------------------------------------------------
    ' Funciòn Insert: Agrega datos a la tabla Tipo_cuenta
    ' Parametros: TiDo_Codi : Còdigo
    '             TiDO_Nomb : Nombre del Parametro

    Public Function Insert(ByVal TCTA_CODI As String, ByVal TCTA_NOMB As String) As String

        Dim na As Integer
        Me.Conectar()
        Try
            ComenzarTransaccion()
            Me.querystring = "INSERT INTO Tipo_Cuenta (TCTA_CODI,TCTA_NOMB,TCTA_USAP)VALUES(:TCTA_CODI,:TCTA_NOMB,:TCTA_USAP)"
            CrearComando(querystring)
            AsignarParametroCadena(":TCTA_CODI", TCTA_CODI)
            AsignarParametroCadena(":TCTA_NOMB", TCTA_NOMB)
            AsignarParametroCadena(":TCTA_USAP", Me.usuario)
            'Me.usuario

            na = EjecutarComando()
            ConfirmarTransaccion()
            Me.Msg = MsgOk + "<BR> Número de Filas Afectadas " + na.ToString
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
    ' Funciòn Actualizar: Acatualiza datos a la tabla Tipo_Cuenta
    '    Parametros: Tcta_Codi : Còdigo
    '             Tcta_Nomb : Nombre del Parametro

    Public Function Update(ByVal TCTA_CODI_OR As String, ByVal TCTA_CODI As String, ByVal TCTA_NOMB As String) As String
        Dim na As String
        Me.Conectar()
        Try
            ComenzarTransaccion()
            Me.querystring = "UPDATE Tipo_Cuenta SET TCTA_CODI='" + TCTA_CODI + "',TCTA_NOMB='" + TCTA_NOMB + "' WHERE TCTA_CODI='" + TCTA_CODI_OR + "' "
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
    'Funciòn Delete: elimina datos a la tabla Tipo_Cuenta
    ' Parametros: Tcta_Codi : Còdigo

    Public Function Delete(ByVal CODI As String) As String
        Dim na As String

        'If (CInt(COD) = 1) Or (CInt(COD) = 2) Or (CInt(COD) = 3) Then

        'Return "Esta Clase de Impuesto, No se puede eliminar"
        'End If
        Me.Conectar()
        Try
            ComenzarTransaccion()

            Me.querystring = "DELETE Tipo_Cuenta WHERE TCTA_CODI='" + CODI + "'"
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
        Dim queryString As String = "SELECT * FROM Tipo_Cuenta ORDER BY TCTA_CODI"
        CrearComando(queryString)
        Dim dataTb As DataTable = EjecutarConsultaDataTable()
        Me.Desconectar()
        Return dataTb

    End Function
    <DataObjectMethodAttribute(DataObjectMethodType.Select, True)> _
    Public Overloads Function GetPorCod(ByVal Cod As String) As DataTable
        Me.Conectar()
        Dim queryString As String = "SELECT * FROM TIPO_Cuenta WHERE TCTA_CODI=:TCTA_CODI"
        CrearComando(queryString)
        AsignarParametroCadena(":TCTA_CODI", Cod)
        Dim dataTb As DataTable = EjecutarConsultaDataTable()
        Me.Desconectar()
        Return dataTb

    End Function

End Class
