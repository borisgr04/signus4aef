Imports Microsoft.VisualBasic
Imports System.ComponentModel
Imports System
Imports System.Data

'Clase para manejar la Tabla Fmtos de la Base de datos
'Fecha Creaciòn: 06 ene 2010
'Autor: Ronal Javier

Public Class Fmtos
    Inherits BDDatos2
    '---------------------------------------------------------------------------------------------------------------
    ' Funciòn Insert: Agrega datos a la tabla Fmto

    Public Function Insert(ByVal FMTO_CODI As String, ByVal FMTO_NOMB As String, ByVal FMTO_DESC As String, ByVal FMTO_CDEC As String, ByVal FMTO_EST As String) As String

        Dim na As Integer
        Me.Conectar()
        Try
            ComenzarTransaccion()
            Me.querystring = "INSERT INTO Fmtos (FMTO_CODI,FMTO_NOMB,FMTO_DESC,FMTO_CDEC,FMTO_EST)VALUES(:FMTO_CODI,:FMTO_NOMB,:FMTO_DESC,:FMTO_CDEC,:FMTO_EST)"
            CrearComando(querystring)
            AsignarParametroCadena(":FMTO_CODI", FMTO_CODI)
            AsignarParametroCadena(":FMTO_NOMB", FMTO_NOMB)
            AsignarParametroCadena(":FMTO_DESC", FMTO_DESC)
            AsignarParametroCadena(":FMTO_CDEC", FMTO_CDEC)
            AsignarParametroCadena(":FMTO_EST", FMTO_EST)
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
    ' Funciòn Actualizar: Actualiza datos a la tabla Fmtos


    Public Function Update(ByVal FMTO_CODI_or As String, ByVal FMTO_CODI As String, ByVal FMTO_NOMB As String, ByVal FMTO_DESC As String, ByVal FMTO_CDEC As String, ByVal FMTO_EST As String) As String
        Dim na As String
        Me.Conectar()
        Try
            ComenzarTransaccion()
            Me.querystring = "UPDATE Fmtos SET FMTO_CODI='" + FMTO_CODI + "',FMTO_NOMB='" + FMTO_NOMB + "',FMTO_DESC='" + FMTO_DESC + "',FMTO_CDEC='" + FMTO_CDEC + "',FMTO_EST='" + FMTO_EST + "' WHERE FMTO_CODI='" + FMTO_CODI_or + "'"
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
    ' Funciòn Delete: Borra datos a la tabla Fmto

    Public Function Delete(ByVal COD As String) As String
        Dim na As String

        'If (CInt(COD) = 1) Or (CInt(COD) = 2) Or (CInt(COD) = 3) Then

        'Return "Esta Clase de Impuesto, No se puede eliminar"
        'End If
        Me.Conectar()
        Try
            ComenzarTransaccion()

            Me.querystring = "DELETE Fmtos WHERE FMTO_CODI='" + COD + "'"
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
        Dim queryString As String = "SELECT * FROM Fmtos ORDER BY FMTO_CODI"
        CrearComando(queryString)
        Dim dataTb As DataTable = EjecutarConsultaDataTable()
        Me.Desconectar()
        Return dataTb

    End Function
    <DataObjectMethodAttribute(DataObjectMethodType.Select, True)> _
    Public Overloads Function GetPorCod(ByVal FMTO_CODI As String) As DataTable
        Me.Conectar()
        Dim queryString As String = "SELECT * FROM Fmtos WHERE FMTO_CODI=:FMTO_CODI"
        CrearComando(queryString)
        AsignarParametroCadena(":FMTO_CODI", FMTO_CODI)
        Dim dataTb As DataTable = EjecutarConsultaDataTable()
        Me.Desconectar()
        Return dataTb

    End Function

End Class
