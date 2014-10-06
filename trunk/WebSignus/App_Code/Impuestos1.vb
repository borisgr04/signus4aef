Imports Microsoft.VisualBasic
Imports System.ComponentModel
Imports System.Data
Imports System

'Clase para manejar la Tabla IMPUESTOS de la Base de datos
'Fecha Creaciòn: 04 ene 2010
'Autor: Ronal Javier

Public Class Impuestos1
    Inherits BDDatos2
    Public Function Insert(ByVal IMP_COD As String, ByVal IMP_NOM As String, ByVal IMP_OBS As String, ByVal IMP_NOR As String, ByVal IMP_CLA As String, ByVal IMP_UNI As String) As String
        Dim na As Integer
        Me.Conectar()
        Try
            ComenzarTransaccion()
            Me.querystring = "INSERT INTO IMPUESTOS (IMP_COD,IMP_NOM,IMP_OBS,IMP_NOR,IMP_CLA,IMP_UNI)VALUES(:IMP_COD,:IMP_NOM,:IMP_OBS,:IMP_NOR,:IMP_CLA,:IMP_UNI)"
            CrearComando(querystring)
            AsignarParametroCadena(":IMP_COD", IMP_COD)
            AsignarParametroCadena(":IMP_NOM", IMP_NOM)
            AsignarParametroCadena(":IMP_OBS", IMP_OBS)
            AsignarParametroCadena(":IMP_NOR", IMP_NOR)
            AsignarParametroCadena(":IMP_CLA", IMP_CLA)
            AsignarParametroCadena(":IMP_UNI", IMP_UNI)

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
    Public Function Update(ByVal IMP_COD_or As String, ByVal IMP_COD As String, ByVal IMP_NOM As String, ByVal IMP_OBS As String, ByVal IMP_NOR As String, ByVal IMP_CLA As String, ByVal IMP_UNI As String) As String
        Dim na As String
        Me.Conectar()
        Try
            ComenzarTransaccion()
            Me.querystring = "UPDATE IMPUESTOS SET IMP_COD='" + IMP_COD + "',IMP_NOM='" + IMP_NOM + "',IMP_OBS='" + IMP_OBS + "',IMP_NOR='" + IMP_NOR + "',IMP_CLA='" + IMP_CLA + "',IMP_UNI='" + IMP_UNI + "'WHERE IMP_COD='" + IMP_COD_or + "'"
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
    Public Function Delete(ByVal IMP_COD As String) As String
        Dim na As String

        'If (CInt(COD) = 1) Or (CInt(COD) = 2) Or (CInt(COD) = 3) Then

        'Return "Esta Clase de Impuesto, No se puede eliminar"
        'End If
        Me.Conectar()
        Try
            ComenzarTransaccion()

            Me.querystring = "DELETE IMPUESTOS WHERE IMP_COD='" + IMP_COD + "'"
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
        Dim queryString As String = "SELECT * FROM IMPUESTOS ORDER BY IMP_COD"
        CrearComando(queryString)
        Dim dataTb As DataTable = EjecutarConsultaDataTable()
        Me.Desconectar()
        Return dataTb

    End Function
    <DataObjectMethodAttribute(DataObjectMethodType.Select, True)> _
    Public Overloads Function GetPorCod(ByVal IMP_COD As String) As DataTable
        Me.Conectar()
        Dim queryString As String = "SELECT * FROM IMPUESTOS WHERE IMP_COD=:IMP_COD"
        CrearComando(queryString)
        AsignarParametroCadena(":IMP_COD", IMP_COD)
        Dim dataTb As DataTable = EjecutarConsultaDataTable()
        Me.Desconectar()
        Return dataTb
    End Function
End Class
