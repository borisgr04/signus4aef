Imports Microsoft.VisualBasic
Imports System.Data
Imports System.ComponentModel
'Clase para manejar la Tabla Cont_Peri de la Base de datos
'Fecha Creaci�n: 07 dic 2009
'Autor: Ronal Javier

Public Class Cont_Peri
    Inherits BDDatos2
    '---------------------------------------------------------------------------------------------------------------
    ' Funci�n Insert: Agrega datos a la tabla Cont_Peri

    Public Function Insert(ByVal COPE_A�O As String, ByVal COPE_MES As String, ByVal COPE_ESTA As String) As String

        Dim na As Integer
        Me.Conectar()
        Try
            ComenzarTransaccion()
            Me.querystring = "INSERT INTO Cont_Peri (COPE_A�O,COPE_MES,COPE_ESTA,COPE_USAP)VALUES(:COPE_A�O,:COPE_MES,:COPE_ESTA,:COPE_USAP)"
            CrearComando(querystring)
            AsignarParametroCadena(":COPE_A�O", COPE_A�O)
            AsignarParametroCadena(":COPE_MES", COPE_MES)
            AsignarParametroCadena(":COPE_ESTA", COPE_ESTA)
            AsignarParametroCadena(":COPE_USAP", Me.usuario)
            'Me.usuario
            na = EjecutarComando()
            Me.Msg = MsgOk + "<BR> N�mero de Filas Afectadas " + na.ToString
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
    ' Funci�n Actualizar: Actualiza datos a la tabla Cld_Imp

    Public Function Update(ByVal COPE_A�O_OR As String, ByVal COPE_MES_OR As String, ByVal COPE_A�O As String, ByVal COPE_MES As String, ByVal COPE_ESTA As String) As String
        Dim na As String
        Me.Conectar()
        Try
            ComenzarTransaccion
            Me.querystring = "UPDATE Cont_Peri SET COPE_A�O='" + COPE_A�O + "',COPE_MES='" + COPE_MES + "',COPE_ESTA='" + COPE_ESTA + "' WHERE COPE_A�O='" + COPE_A�O_OR + "'AND COPE_MES='" + COPE_MES_OR + "'"
            CrearComando(querystring)
            na = EjecutarComando()
            Me.Msg = MsgOk + "<BR> Registros Actualizados [" + na + "]"
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
    ' Funci�n Delete: Borra datos a la tabla Cld_Imp

    Public Function Delete(ByVal COD As String, ByVal MES As String) As String
        Dim na As String

        'If (CInt(COD) = 1) Or (CInt(COD) = 2) Or (CInt(COD) = 3) Then

        'Return "Esta Clase de Impuesto, No se puede eliminar"
        'End If
        Me.Conectar()
        Try
            ComenzarTransaccion()
            Me.querystring = "DELETE Cont_Peri WHERE COPE_A�O='" + COD + "'AND COPE_MES='" + MES + "'"
            na = EjecutarComando
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
        Dim queryString As String = "SELECT * FROM  Cont_Peri ORDER BY COPE_A�O , COPE_MES"
        CrearComando(queryString)
        Dim dataTb As DataTable = EjecutarConsultaDataTable()
        Me.Desconectar()
        Return dataTb
    End Function
    <DataObjectMethodAttribute(DataObjectMethodType.Select, True)> _
    Public Overloads Function GetPorCod(ByVal Cod As String, ByVal MES As String) As DataTable
        Me.Conectar()
        Dim queryString As String = "SELECT * FROM Cont_Peri WHERE COPE_A�O=:COPE_A�O AND COPE_MES=: COPE_MES "
        CrearComando(queryString)
        AsignarParametroCadena(":COPE_A�O", Cod)
        AsignarParametroCadena(":COPE_MES", MES)
        Dim dataTb As DataTable = EjecutarConsultaDataTable()
        Me.Desconectar()
        Return dataTb
    End Function
End Class