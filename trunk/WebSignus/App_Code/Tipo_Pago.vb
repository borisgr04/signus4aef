Imports Microsoft.VisualBasic
Imports System.Data
Imports System.ComponentModel
Imports System

'Clase para manejar la Tabla Tipo_Doc_Cons de la Base de datos
'Fecha Creaciòn: 02 dic 2009
'Autor: Ronal Javier

Public Class TIPO_PAGO
    Inherits BDDatos2
    '---------------------------------------------------------------------------------------------------------------
    ' Funciòn Insert: Agrega datos a la tabla Tipo_Pago
    ' Parametros: TPAG_Cod : Còdigo
    '             TPAG_Nom : nombre del parametro

    Public Function Insert(ByVal TPAG_COD As String, ByVal TPAG_NOM As String) As String

        Dim na As Integer
        Me.Conectar()
        Try
            ComenzarTransaccion()
            Me.querystring = "INSERT INTO TIPO_PAGO (TPAG_COD,TPAG_NOM,TPAG_USAP)VALUES(:TPAG_COD,:TPAG_NOM,:TPAG_USAP)"
            CrearComando(querystring)
            AsignarParametroCadena(":TPAG_COD", TPAG_COD)
            AsignarParametroCadena(":TPAG_NOM", TPAG_NOM)
            AsignarParametroCadena(":TIDO_USAP", Me.usuario)
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
    ' Funciòn Actualizar: Acatualiza datos a la tabla TIPO_PAGO
    '    Parametros: Tpag_Cod : Còdigo
    '                Tpag_Nom : Nombre del parametro

    Public Function Update(ByVal TPAG_COD_OR As String, ByVal TPAG_COD As String, ByVal TPAG_NOM As String) As String
        Dim na As String
        Me.Conectar()
        Try
            ComenzarTransaccion()
            Me.querystring = "UPDATE TIPO_PAGO SET TPAG_COD='" + TPAG_COD + "',TPAG_NOM='" + TPAG_NOM + "' WHERE TPAG_COD='" + TPAG_COD_OR + "' "
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
    'Funciòn Delete: elimina datos a la tabla TIPO_PAGO
    ' Parametros: TPAG_Cod : Còdigo
    '             TPAG_Nom: Clase de Declaracion

    Public Function Delete(ByVal TPAG_COD As String) As String
        Dim na As String

        'If (CInt(COD) = 1) Or (CInt(COD) = 2) Or (CInt(COD) = 3) Then

        'Return "Esta Clase de Impuesto, No se puede eliminar"
        'End If
        Me.Conectar()
        Try
            ComenzarTransaccion()

            Me.querystring = "DELETE TIPO_PAGO WHERE TPAG_COD='" + TPAG_COD + "'"
            CrearComando(querystring)
            na = EjecutarComando()
            Me.Msg = MsgOk + " # Registros Eliminados:" + na.ToString
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

    <DataObjectMethodAttribute(DataObjectMethodType.Select, True)> _
    Public Overrides Function GetRecords() As DataTable
        Me.Conectar()
        Dim queryString As String = "SELECT * FROM TIPO_PAGO ORDER BY TPAG_COD"
        CrearComando(queryString)
        Dim dataTb As DataTable = EjecutarConsultaDataTable()
        Me.Desconectar()
        Return dataTb

    End Function
    <DataObjectMethodAttribute(DataObjectMethodType.Select, True)> _
    Public Overloads Function GetPorCod(ByVal Cod As String) As DataTable
        Me.Conectar()
        Dim queryString As String = "SELECT * FROM TIPO_PAGO WHERE TPAG_COD=:TPAG_COD"
        CrearComando(queryString)
        AsignarParametroCadena(":TPAG_COD", Cod)
        Dim dataTb As DataTable = EjecutarConsultaDataTable()
        Me.Desconectar()
        Return dataTb
    End Function
End Class