Imports Microsoft.VisualBasic
Imports System.Data
Imports System.ComponentModel
Imports System
'Clase para manejar la Tabla Tipo_proceso de la Base de datos
'Fecha Creaciòn: 03 dic 2009
'Autor: Ronal Javier

Public Class tipo_proceso
    Inherits BDDatos2
    '---------------------------------------------------------------------------------------------------------------
    ' Funciòn Insert: Agrega datos a la tabla Tipo_proceso
    ' Parametros: TiDo_Codi : Còdigo
    '             TiDO_Nomb : Nombre del Parametro

    Public Function Insert(ByVal TPRO_CODI As String, ByVal TPRO_NOMB As String) As String

        Dim na As Integer
        Me.Conectar()
        Try
            ComenzarTransaccion()
            Me.querystring = "INSERT INTO Tipo_proceso (TPRO_CODI,TPRO_NOMB,TPRO_USAP)VALUES(:TPRO_CODI,:TPRO_NOMB,:TCTA_USAP)"
            CrearComando(querystring)
            AsignarParametroCadena(":TPRO_CODI", TPRO_CODI)
            AsignarParametroCadena(":TPRO_NOMB", TPRO_NOMB)
            AsignarParametroCadena(":TCTA_USAP", Me.usuario)
            'Me.usuario

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
    ' Funciòn Actualizar: Acatualiza datos a la tabla Tipo_proceso
    '    Parametros: Tcta_Codi : Còdigo
    '             Tcta_Nomb : Nombre del Parametro

    Public Function Update(ByVal TPRO_CODI_OR As String, ByVal TPRO_CODI As String, ByVal TPRO_NOMB As String) As String
        Dim na As String
        Me.Conectar()
        Try
            ComenzarTransaccion()
            Me.querystring = "UPDATE Tipo_proceso SET TPRO_CODI='" + TPRO_CODI + "',TPRO_NOMB='" + TPRO_NOMB + "' WHERE TPRO_CODI='" + TPRO_CODI_OR + "' "
            CrearComando(querystring)
            na = EjecutarComando()
            Me.Msg = MsgOk + "<BR> Registros Actualizados [" + na + "]"
            ConfirmarTransaccion()
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
    'Funciòn Delete: elimina datos a la tabla Tipo_proceso
    ' Parametros: Tcta_Codi : Còdigo

    Public Function Delete(ByVal CODI As String) As String
        Dim na As String

        'If (CInt(COD) = 1) Or (CInt(COD) = 2) Or (CInt(COD) = 3) Then

        'Return "Esta Clase de Impuesto, No se puede eliminar"
        'End If
        Me.Conectar()
        Try
            ComenzarTransaccion()
            Me.querystring = "DELETE Tipo_proceso WHERE TPRO_CODI='" + CODI + "'"
            CrearComando(querystring)
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
        Me.querystring = "SELECT * FROM Tipo_proceso ORDER BY TPRO_CODI"
        CrearComando(querystring)
        Dim dataTb As DataTable = EjecutarConsultaDataTable()

        Me.Desconectar()
        Return dataTb

    End Function
    <DataObjectMethodAttribute(DataObjectMethodType.Select, True)> _
    Public Overloads Function GetPorCod(ByVal Cod As String) As DataTable
        Me.Conectar()
        Me.querystring = "SELECT * FROM TIPO_proceso WHERE TPRO_CODI=:TPRO_CODI"
        CrearComando(querystring)
        AsignarParametroCadena(":TPRO_CODI", Cod)
        Dim dataTb As DataTable = EjecutarConsultaDataTable()
        Me.Desconectar()
        Return dataTb
    End Function
End Class
