Imports Microsoft.VisualBasic
Imports System.Data
Imports System.ComponentModel
Imports System

'Clase para manejar la Tabla Fmto_Imp de la Base de datos
'Fecha Creaciòn: 10 dic 2009
'Autor: Ronal Javier

Public Class Fmto_Imp
    Inherits BDDatos2
    '---------------------------------------------------------------------------------------------------------------
    ' Funciòn Insert: Agrega datos a la tabla Fmto_Imp

    Public Function Insert(ByVal FMIM_CAMP As String, ByVal FMIM_TIDA As String, ByVal FMIM_CODI As String, ByVal FMIM_INDX As String, ByVal FMIM_LONG As String, ByVal FMIM_EST As String) As String

        Dim na As Integer
        Me.Conectar()
        Try
            ComenzarTransaccion()
            Me.querystring = "INSERT INTO Fmto_Imp (FMIM_CAMP,FMIM_TIDA,FMIM_CODI,FMIM_INDX,FMIM_LONG,FMIM_USAP,FMIM_EST)VALUES(:FMIM_CAMP,:FMIM_TIDA,:FMIM_CODI,:FMIM_INDX,:FMIM_LONG,:FMIM_USAP,:FMIM_EST)"
            CrearComando(querystring)
            AsignarParametroCadena(":FMIM_CAMP", FMIM_CAMP)
            AsignarParametroCadena(":FMIM_TIDA", FMIM_TIDA)
            AsignarParametroCadena(":FMIM_CODI", FMIM_CODI)
            AsignarParametroCadena(":FMIM_INDX", FMIM_INDX)
            AsignarParametroCadena(":FMIM_LONG", FMIM_LONG)
            AsignarParametroCadena(":FMIM_USAP", Me.usuario)
            AsignarParametroCadena(":FMIM_EST", FMIM_EST)
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
    ' Funciòn Actualizar: Actualiza datos a la tabla Fmto_Imp

    Public Function Update(ByVal FMIM_CODI_or As String, ByVal FMIM_INDX_or As String, ByVal FMIM_CAMP As String, ByVal FMIM_TIDA As String, ByVal FMIM_CODI As String, ByVal FMIM_INDX As String, ByVal FMIM_LONG As String, ByVal FMIM_EST As String) As String
        Dim na As String
        Me.Conectar()
        Try
            ComenzarTransaccion()
            querystring = "UPDATE Fmto_Imp SET FMIM_CAMP='" + FMIM_CAMP + "',FMIM_TIDA='" + FMIM_TIDA + "',FMIM_CODI='" + FMIM_CODI + "',FMIM_INDX='" + FMIM_INDX + "',FMIM_LONG='" + FMIM_LONG + "', FMIM_EST ='" + FMIM_EST + "' WHERE FMIM_CODI='" + FMIM_CODI_or + "'AND FMIM_INDX='" + FMIM_INDX_or + "'"
            CrearComando(querystring)
            'Throw New Exception(Me.vComando.CommandText)
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
    ' Funciòn Delete: Borra datos a la tabla Fmto_Imp

    Public Function Delete(ByVal COD As String, ByVal INDX As String) As String
        Dim na As String

        'If (CInt(COD) = 1) Or (CInt(COD) = 2) Or (CInt(COD) = 3) Then

        'Return "Esta Clase de Impuesto, No se puede eliminar"
        'End If
        Me.Conectar()
        Try
            ComenzarTransaccion()

            Me.querystring = "DELETE Fmto_Imp WHERE FMIM_CODI='" + COD + "'AND FMIM_INDX='" + INDX + "'"
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
    Public Overrides Function GetRecords(ByVal filtro As String) As DataTable
        Me.Conectar()
        Dim queryString As String = "SELECT * FROM Fmto_Imp WHERE 1=1 " & filtro & "  ORDER BY FMIM_CODI,FMIM_INDX"
        CrearComando(queryString)
        Dim dataTb As DataTable = EjecutarConsultaDataTable()
        Me.Desconectar()
        Return dataTb

    End Function
    <DataObjectMethodAttribute(DataObjectMethodType.Select, True)> _
    Public Overloads Function GetPorCod(ByVal CODI As String, ByVal INDX As String) As DataTable
        Me.Conectar()
        Dim queryString As String = "SELECT * FROM Fmto_Imp WHERE FMIM_CODI=:FMIM_CODI AND FMIM_INDX=:FMIM_INDX"
        CrearComando(queryString)
        AsignarParametroCadena(":FMIM_CODI", CODI)
        AsignarParametroCadena(":FMIM_INDX", INDX)
        Dim dataTb As DataTable = EjecutarConsultaDataTable()
        Me.Desconectar()
        Return dataTb

    End Function

End Class
