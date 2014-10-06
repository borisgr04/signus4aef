Imports Microsoft.VisualBasic

Imports System.Data
Imports System.ComponentModel
'Clase para manejar la Tabla Cld_Imp de la Base de datos
'Fecha Creaciòn: 07 dic 2009
'Autor: Ronal Javier

Public Class Cld_Imp
    Inherits BDDatos2
    '---------------------------------------------------------------------------------------------------------------
    ' Funciòn Insert: Agrega datos a la tabla Cld_imp

    Public Function Insert(ByVal CLD_COD As String, ByVal CLD_CIMP As String, ByVal CLD_ABIM As String, ByVal CLD_ABVA As String) As String

        Dim na As Integer
        Me.Conectar()
        Try
            ComenzarTransaccion()
            Me.querystring = "INSERT INTO Cld_Imp (CLD_COD,CLD_CIMP,CLD_ABIM,CLD_ABVA,CLD_USAP)VALUES(:CLD_COD,:CLD_CIMP,:CLD_ABIM,:CLD_ABVA,:CLD_USAP)"
            CrearComando(querystring)
            AsignarParametroCadena(":CLD_COD", CLD_COD)
            AsignarParametroCadena(":CLD_CIMP", CLD_CIMP)
            AsignarParametroCadena(":CLD_ABIM", CLD_ABIM)
            AsignarParametroCadena(":CLD_ABVA", CLD_ABVA)
            AsignarParametroCadena(":CLD_USAP", Me.usuario)
            'Me.usuario

            na = EjecutarComando
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
    ' Funciòn Actualizar: Actualiza datos a la tabla Cld_Imp

    Public Function Update(ByVal CLD_COD_or As String, ByVal CLD_CIMP_or As String, ByVal CLD_COD As String, ByVal CLD_CIMP As String, ByVal CLD_ABIM As String, ByVal CLD_ABVA As String) As String
        Dim na As String
        Me.Conectar()
        Try
            ComenzarTransaccion()
            Me.querystring = "UPDATE Cld_Imp SET CLD_COD='" + CLD_COD + "',CLD_CIMP='" + CLD_CIMP + "',CLD_ABIM='" + CLD_ABIM + "',CLD_ABVA='" + CLD_ABVA + "' WHERE CLD_COD='" + CLD_COD_or + "'AND CLD_CIMP='" + CLD_CIMP_or + "'"
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
    ' Funciòn Delete: Borra datos a la tabla Cld_Imp

    Public Function Delete(ByVal COD As String, ByVal CIMP As String) As String
        Dim na As String

        'If (CInt(COD) = 1) Or (CInt(COD) = 2) Or (CInt(COD) = 3) Then

        'Return "Esta Clase de Impuesto, No se puede eliminar"
        'End If
        Me.Conectar()
        Try
            ComenzarTransaccion()
            Me.querystring = "DELETE Cld_Imp WHERE CLD_COD='" + COD + "'AND CLD_CIMP='" + CIMP + "'"
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
        Dim queryString As String = "SELECT * FROM Cld_Imp ORDER BY CLD_COD, CLD_CIMP"
        CrearComando(queryString)
        Dim dataTb As DataTable = EjecutarConsultaDataTable()
        Me.Desconectar()
        Return dataTb
    End Function
    <DataObjectMethodAttribute(DataObjectMethodType.Select, True)> _
    Public Overloads Function GetPorCod(ByVal Cod As String, ByVal CIMP As String) As DataTable
        Me.Conectar()
        Dim queryString As String = "SELECT * FROM Cld_Imp WHERE CLD_COD=:CLD_COD AND CLD_CIMP=:CLD_CIMP"
        CrearComando(queryString)
        AsignarParametroCadena(":CLD_COD", Cod)
        AsignarParametroCadena(":CLD_CIMP", CIMP)
        Dim dataTb As DataTable = EjecutarConsultaDataTable()
        Me.Desconectar()
        Return dataTb
    End Function
End Class
