Imports Microsoft.VisualBasic
Imports System.ComponentModel
Imports System.Data
Imports System

'Clase para manejar la Tabla Tipousua de la Base de datos
'Fecha Creaciòn: 03 dic 2009
'Autor: Ronal Javier

Public Class tipousua
    Inherits BDDatos2
    '---------------------------------------------------------------------------------------------------------------
    ' Funciòn Insert: Agrega datos a la tabla Tipousua
    ' Parametros: TiDo_Cod : Còdigo
    '             TiDO_Nom : Nombre del Parametro

    Public Function Insert(ByVal TUS_COD As String, ByVal TUS_NOM As String) As String

        Dim na As Integer
        Me.Conectar()
        Try
            ComenzarTransaccion()
            Me.querystring = "INSERT INTO Tipousua (TUS_COD,TUS_NOM,TUS_USAP)VALUES(:TUS_COD,:TUS_NOM,:TUS_USAP)"
            CrearComando(querystring)
            AsignarParametroCadena(":TUS_COD", TUS_COD)
            AsignarParametroCadena(":TUS_NOM", TUS_NOM)
            AsignarParametroCadena(":TUS_USAP", Me.usuario)
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
    ' Funciòn Actualizar: Acatualiza datos a la tabla Tipousua
    '    Parametros: Tcta_Cod : Còdigo
    '             Tcta_Nom : Nombre del Parametro

    Public Function Update(ByVal TUS_COD_OR As String, ByVal TUS_COD As String, ByVal TUS_NOM As String) As String
        Dim na As String
        Me.Conectar()
        Try
            ComenzarTransaccion()
            Me.querystring = "UPDATE Tipousua SET TUS_COD='" + TUS_COD + "',TUS_NOM='" + TUS_NOM + "' WHERE TUS_COD='" + TUS_COD_OR + "' "
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
    'Funciòn Delete: elimina datos a la tabla Tipousua
    ' Parametros: Tcta_Cod : Còdigo

    Public Function Delete(ByVal COD As String) As String
        Dim na As String

        'If (CInt(COD) = 1) Or (CInt(COD) = 2) Or (CInt(COD) = 3) Then

        'Return "Esta Clase de Impuesto, No se puede eliminar"
        'End If
        Me.Conectar()
        Try
            ComenzarTransaccion()
            Me.querystring = "DELETE Tipousua WHERE TUS_COD='" + COD + "'"
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
        Dim queryString As String = "SELECT * FROM Tipousua ORDER BY TUS_COD"
        CrearComando(queryString)
        Dim dataTb As DataTable = EjecutarConsultaDataTable()
        Me.Desconectar()
        Return dataTb

    End Function
    <DataObjectMethodAttribute(DataObjectMethodType.Select, True)> _
    Public Overloads Function GetPorCod(ByVal Cod As String) As DataTable
        Me.Conectar()
        Dim queryString As String = "SELECT * FROM Tipousua WHERE TUS_COD=:TUS_COD"
        CrearComando(queryString)
        AsignarParametroCadena(":TUS_COD", Cod)
        Dim dataTb As DataTable = EjecutarConsultaDataTable()
        Me.Desconectar()
        Return dataTb

    End Function


End Class
