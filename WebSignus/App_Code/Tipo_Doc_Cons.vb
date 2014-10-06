Imports Microsoft.VisualBasic
Imports System.Data
Imports System.ComponentModel
Imports System

'Clase para manejar la Tabla Tipo_Doc_Cons de la Base de datos
'Fecha Creaciòn: 02 dic 2009
'Autor: Ronal Javier
Public Class Tipo_Doc_Cons
    Inherits BDDatos2
    '---------------------------------------------------------------------------------------------------------------
    ' Funciòn Insert: Agrega datos a la tabla Tipo_Doc_Cons
    ' Parametros: TiDo_Codi : Còdigo
    '             TiDO_Cdec : clase de declaracion
    '             Tido_Cons : Consecutivo

    Public Function Insert(ByVal TIDO_CODI As String, ByVal TIDO_CDEC As String, ByVal TIDO_CONS As String) As String

        Dim na As Integer
        Me.Conectar()
        Try
            ComenzarTransaccion()
            Me.querystring = "INSERT INTO Tipo_Doc_Cons (TIDO_CODI,TIDO_CDEC,TIDO_CONS,TIDO_USAP)VALUES(:TIDO_CODI,:TIDO_CDEC,:TIDO_CONS,:TIDO_USAP)"
            CrearComando(querystring)
            AsignarParametroCadena(":TIDO_CODI", TIDO_CODI)
            AsignarParametroCadena(":TIDO_CDEC", TIDO_CDEC)
            AsignarParametroCadena(":TIDO_CONS", TIDO_CONS)
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
    ' Funciòn Actualizar: Acatualiza datos a la tabla Tipo_Doc_Cons
    '    Parametros: Tido_Codi : Còdigo
    '                Tido_cdec : clase de declaracion
    '                Tido_Cons : Consecutivo

    Public Function Update(ByVal TIDO_CODI As String, ByVal TIDO_CDEC As String, ByVal TIDO_CONS As String) As String
        Dim na As String
        Me.Conectar()
        Try
            ComenzarTransaccion()
            Me.querystring = "UPDATE Tipo_Doc_Cons SET TIDO_CODI='" + TIDO_CODI + "',TIDO_CDEC='" + TIDO_CDEC + "',TIDO_CONS='" + TIDO_CONS + "' WHERE TIDO_CODI='" + TIDO_CODI + "' AND TIDO_CDEC='" + TIDO_CDEC + "' "
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
    'Funciòn Delete: elimina datos a la tabla Tipo_Doc_Cons
    ' Parametros: Tido_Codi : Còdigo
    '             Tido_Cdec: Clase de Declaracion
    '             tido_Cons : Consecutivo

    Public Function Delete(ByVal TIDO_CODI As String) As String
        Dim na As String

        'If (CInt(COD) = 1) Or (CInt(COD) = 2) Or (CInt(COD) = 3) Then

        'Return "Esta Clase de Impuesto, No se puede eliminar"
        'End If
        Me.Conectar()
        Try
            ComenzarTransaccion()

            Me.querystring = "DELETE Tipo_Doc_Cons WHERE TIDO_CODI='" + TIDO_CODI + "'"
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
        Dim queryString As String = "SELECT * FROM Tipo_Doc_Cons ORDER BY TIDO_CODI,TIDO_CDEC"
        CrearComando(queryString)
        Dim dataTb As DataTable = EjecutarConsultaDataTable()
        Me.Desconectar()
        Return dataTb

    End Function
    <DataObjectMethodAttribute(DataObjectMethodType.Select, True)> _
    Public Overloads Function GetPorCod(ByVal Cod As String, ByVal CLDE As String) As DataTable
        Me.Conectar()
        Dim queryString As String = "SELECT * FROM Tipo_Doc_Cons WHERE TIDO_CODI=:TIDO_CODI AND TIDO_CDEC=:TIDO_CDEC"
        CrearComando(queryString)
        AsignarParametroCadena(":TIDO_CODI", Cod)
        AsignarParametroCadena(":TIDO_CDEC", CLDE)
        Dim dataTb As DataTable = EjecutarConsultaDataTable()
        Me.Desconectar()
        Return dataTb

    End Function


End Class
