Imports Microsoft.VisualBasic
Imports System.Data
Imports System.ComponentModel
Imports System

'Clase para manejar la Tabla Departamentos de la Base de datos
'Fecha Creaciòn: 19 dic 2009
'Autor: Ronal Javier

Public Class Departamentos

    Inherits BDDatos2
    '---------------------------------------------------------------------------------------------------------------
    ' Funciòn Insert: Agrega datos a la tabla Departamentos

    Public Function Insert(ByVal COD_DEPTO As String, ByVal NOM_DEPTO As String, ByVal ABREV_DISFON As String) As String

        Dim na As Integer
        Me.Conectar()
        Try
            ComenzarTransaccion()
            Me.querystring = "INSERT INTO Departamentos (COD_DEPTO,NOM_DEPTO,ABREV_DISFON,USAP)VALUES(:COD_DEPTO,:NOM_DEPTO,:ABREV_DISFON,:TAG_USAP)"
            CrearComando(querystring)
            AsignarParametroCadena(":COD_DEPTO", COD_DEPTO)
            AsignarParametroCadena(":NOM_DEPTO", NOM_DEPTO)
            AsignarParametroCadena(":ABREV_DISFON", ABREV_DISFON)
            AsignarParametroCadena(":TAG_USAP", "12345")
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
    ' Funciòn Actualizar: Actualiza datos a la tabla Departamentos

    Public Function Update(ByVal COD_DEPTO_or As String, ByVal COD_DEPTO As String, ByVal NOM_DEPTO As String, ByVal ABREV_DISFON As String) As String
        Dim na As String
        Me.Conectar()
        Try
            ComenzarTransaccion()
            querystring = "UPDATE Departamentos SET COD_DEPTO='" + COD_DEPTO + "',NOM_DEPTO='" + NOM_DEPTO + "',ABREV_DISFON='" + ABREV_DISFON + "' WHERE COD_DEPTO='" + COD_DEPTO_or + "'"
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
    ' Funciòn Delete: Borra datos a la tabla Departamentos

    Public Function Delete(ByVal COD_DEPTO As String) As String
        Dim na As String

        'If (CInt(COD) = 1) Or (CInt(COD) = 2) Or (CInt(COD) = 3) Then

        'Return "Esta Clase de Impuesto, No se puede eliminar"
        'End If
        Me.Conectar()
        Try
            ComenzarTransaccion()
            Me.querystring = "DELETE Departamentos WHERE COD_DEPTO='" + COD_DEPTO + "'"
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
        Dim queryString As String = "SELECT * FROM Departamentos ORDER BY COD_DEPTO"
        CrearComando(queryString)
        Dim dataTb As DataTable = EjecutarConsultaDataTable()
        Me.Desconectar()
        Return dataTb

    End Function
    <DataObjectMethodAttribute(DataObjectMethodType.Select, True)> _
    Public Overloads Function GetPorCod(ByVal Cod As String) As DataTable
        Me.Conectar()
        Dim queryString As String = "SELECT * FROM Departamentos WHERE COD_DEPTO=:COD_DEPTO "
        CrearComando(queryString)
        AsignarParametroCadena(":COD_DEPTO", Cod)
        Dim dataTb As DataTable = EjecutarConsultaDataTable()
        Me.Desconectar()
        Return dataTb
    End Function
End Class
