Imports Microsoft.VisualBasic

Imports System.ComponentModel
Imports System.Data
'Clase para manejar la Tabla Clase_Dec de la Base de datos
'Fecha Creaciòn: 19 dic 2009
'Autor: Ronal Javier

Public Class Clase_Dec

    Inherits BDDatos2
    '---------------------------------------------------------------------------------------------------------------
    ' Funciòn Insert: Agrega datos a la tabla Clase_Dec

    Public Function Insert(ByVal CLD_COD As String, ByVal CLD_NOM As String, ByVal CLD_FIN As Date, ByVal CLD_FFI As Date, ByVal CLD_CONS As String) As String
        Dim na As Integer
        Me.Conectar()
        Try
            ComenzarTransaccion()
            Me.querystring = "INSERT INTO Clase_Dec (CLD_COD,CLD_NOM,CLD_FIN,CLD_FFI,CLD_CONS,CLD_USAP)VALUES(:CLD_COD,:CLD_NOM,:CLD_FIN,:CLD_FFI,:CLD_CONS,:CLD_USAP)"
            CrearComando(querystring)
            AsignarParametroCadena(":CLD_COD", CLD_COD)
            AsignarParametroCadena(":CLD_NOM", CLD_NOM)
            AsignarParametroFecha(":CLD_FIN", CLD_FIN)
            AsignarParametroFecha(":CLD_FFI", CLD_FFI)
            AsignarParametroCadena(":CLD_CONS", CLD_CONS)

            AsignarParametroCadena(":CLD_USAP", Me.usuario)
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
    ' Funciòn Actualizar: Acatualiza datos a la tabla Clase_Dec
    '    
    Public Function Update(ByVal CLD_COD_or As String, ByVal CLD_COD As String, ByVal CLD_NOM As String, ByVal fec_ini As Date, ByVal fec_fin As Date, ByVal CLD_CONS As String) As String
        Dim na As String
        Me.Conectar()
        Try
            ComenzarTransaccion()
            Me.querystring = "UPDATE Clase_Dec SET CLD_COD='" + CLD_COD + "',CLD_NOM='" + CLD_NOM + "',CLD_FIN=to_date('" + fec_ini.ToShortDateString + "','dd/mm/yyyy'),CLD_FFI=to_date('" + fec_fin.ToShortDateString + "','dd/mm/yyyy'),CLD_CONS='" + CLD_CONS + "' WHERE CLD_COD='" + CLD_COD_or + "' "
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
    'Funciòn Delete: elimina datos a la tabla Clase_Dec
    ' Parametros: Tcta_Codi : Còdigo

    Public Function Delete(ByVal CLD_COD As String) As String
        Dim na As String
        Me.Conectar()
        Try
            ComenzarTransaccion()
            Me.querystring = "DELETE Clase_Dec WHERE CLD_COD='" + CLD_COD + "'"
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
        Dim queryString As String = "SELECT * FROM Clase_Dec ORDER BY CLD_COD"
        CrearComando(queryString)
        Dim dataTb As DataTable = EjecutarConsultaDataTable()
        Me.Desconectar()
        Return dataTb
    End Function
    <DataObjectMethodAttribute(DataObjectMethodType.Select, True)> _
    Public Overloads Function GetPorCod(ByVal Cod As String) As DataTable
        Me.Conectar()
        Dim queryString As String = "SELECT * FROM Clase_Dec WHERE CLD_COD=:CLD_COD"
        CrearComando(queryString)
        AsignarParametroCadena(":CLD_COD", Cod)
        Dim dataTb As DataTable = EjecutarConsultaDataTable()
        Me.Desconectar()
        Return dataTb
    End Function
End Class
