Imports Microsoft.VisualBasic
Imports System.Data
Imports System
Imports System.ComponentModel
'Clase para manejar la Tabla Tipo_Doc de la Base de datos
'Fecha Creaciòn: 02 dic 2009
'Autor: Ronal Javier
Public Class TIPO_DOC
    Inherits BDDatos2
    '---------------------------------------------------------------------------------------------------------------
    ' Funciòn Insert: Agrega datos a la tabla Tipo_Doc
    ' Parametros: TiDo_Codi : Còdigo
    '             TiDO_Nomb : Nombre del Parametro

    Public Function Insert(ByVal TIDO_CODI As String, ByVal TIDO_NOMB As String, ByVal TIDO_EST As String, ByVal TIDO_RESP As String) As String


        Dim na As Integer
        Me.Conectar()
        Try
            ComenzarTransaccion()
            Me.querystring = "INSERT INTO TIPO_DOC (TIDO_CODI,TIDO_NOMB,TIDO_EST,TIDO_USAP, TIDO_RESP)VALUES(:TIDO_CODI,:TIDO_NOMB,:TIDO_EST,:TIDO_USAP, :TIDO_RESP)"
            CrearComando(querystring)
            AsignarParametroCadena(":TIDO_CODI", TIDO_CODI)
            AsignarParametroCadena(":TIDO_NOMB", TIDO_NOMB)
            AsignarParametroCadena(":TIDO_EST", TIDO_EST)
            AsignarParametroCadena(":TIDO_USAP", Me.usuario)
            AsignarParametroCadena(":TIDO_RESP", TIDO_RESP)
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
            Me.Conectar()
        End Try


        Return Msg
    End Function

    ' Funciòn Actualizar: Acatualiza datos a la tabla Tipo_Doc
    '    Parametros: TiDo_Codi : Còdigo
    '             TiDO_Nomb : Nombre del Parametro

    Public Function Update(ByVal TIDO_CODI_OR As String, ByVal TIDO_CODI As String, ByVal TIDO_NOMB As String, ByVal TIDO_EST As String, ByVal TIDO_RESP As String) As String
        Dim na As String
        Me.Conectar()
        Try
            ComenzarTransaccion()
            Me.querystring = "UPDATE TIPO_DOC SET TIDO_CODI='" + TIDO_CODI + "',TIDO_NOMB='" + TIDO_NOMB + "',TIDO_EST='" + TIDO_EST + "', TIDO_RESP = :TIDO_RESP WHERE TIDO_CODI='" + TIDO_CODI_OR + "' "
            CrearComando(querystring)
            AsignarParametroCadena(":TIDO_RESP", TIDO_RESP)
            na = EjecutarComando()
            Me.Msg = MsgOk + "<BR> Registros Actualizados [" + na + "]"
            ConfirmarTransaccion()
            Me.lErrorG = False
        Catch ex As Exception
            CancelarTransaccion()
            Me.lErrorG = True
            Me.Msg = "Error de App:" + ex.Message
        Finally
            Me.Conectar()
        End Try

        Return Msg
    End Function
    'Funciòn Delete: elimina datos a la tabla Tipo_Doc
    ' Parametros: TiDo_Codi : Còdigo

    Public Function Delete(ByVal CODI As String) As String
        Dim na As String

        'If (CInt(COD) = 1) Or (CInt(COD) = 2) Or (CInt(COD) = 3) Then

        'Return "Esta Clase de Impuesto, No se puede eliminar"
        'End If
        Me.Conectar()
        Try
            ComenzarTransaccion()

            Me.querystring = "DELETE TIPO_DOC WHERE TIDO_CODI='" + CODI + "'"
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
            Me.Conectar()
        End Try
        Return Msg
    End Function

    <DataObjectMethodAttribute(DataObjectMethodType.Select, True)> _
    Public Overrides Function GetRecords() As DataTable
        Me.Conectar()
        Dim queryString As String = "SELECT * FROM TIPO_DOC ORDER BY TIDO_CODI"
        CrearComando(queryString)
        Dim dataTb As DataTable = EjecutarConsultaDataTable()
        Me.Desconectar()
        Return dataTb

    End Function


    
    Public Function UpdateFirma(ByVal TIDO_CODI As String, ByVal TIDO_FIRMA As [Byte]()) As String
        Dim na As String
        Me.Conectar()
        Try
            ComenzarTransaccion()
            Me.querystring = "UPDATE TIPO_DOC SET TIDO_FIRMA = :TIDO_FIRMA WHERE TIDO_CODI = :TIDO_CODI "
            CrearComando(querystring)
            AsignarParametroBLOB(":TIDO_FIRMA", TIDO_FIRMA)
            AsignarParametroCadena(":TIDO_CODI", TIDO_CODI)
            na = EjecutarComando()
            Me.Msg = MsgOk + "<BR> Registros Actualizados [" + na + "]"
            ConfirmarTransaccion()
            Me.lErrorG = False
        Catch ex As Exception
            CancelarTransaccion()
            Me.lErrorG = True
            Me.Msg = "Error de App:" + ex.Message
        Finally
            Me.Conectar()
        End Try

        Return Msg
    End Function

    <DataObjectMethodAttribute(DataObjectMethodType.Select, True)> _
    Public Overloads Function GetPorCod(ByVal Cod As String) As DataTable
        Me.Conectar()

        Dim queryString As String = "SELECT * FROM TIPO_DOC WHERE TIDO_CODI=:TIDO_CODI"
        CrearComando(queryString)
        AsignarParametroCadena(":TIDO_CODI", Cod)
        Dim dataTb As DataTable = EjecutarConsultaDataTable()
        Me.Conectar()
        Return dataTb

    End Function


End Class








