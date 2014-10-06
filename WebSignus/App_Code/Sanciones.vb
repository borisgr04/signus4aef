Imports Microsoft.VisualBasic
Imports System.Data
Imports System.ComponentModel
Imports System

Public Class TIPO_SANCIONES
    Inherits BDDatos2


    Public Function Insert(ByVal TSAN_COD As String, ByVal TSAN_NOM As String, ByVal TSAN_FORM As String, ByVal TSAN_PAR As String, ByVal TSAN_DEC As String, ByVal TSAN_DETI As String) As String
        Dim na As Integer
        Me.Conectar()
        Try
            ComenzarTransaccion()
            Me.querystring = "INSERT INTO TIPO_SANCIONES (TSAN_COD,TSAN_NOM,TSAN_FORM,TSAN_PAR,TSAN_DEC,TSAN_DETI)VALUES(:TSAN_COD,:TSAN_NOM,:TSAN_FORM,:TSAN_PAR,:TSAN_DEC,:TSAN_DETI)"
            CrearComando(querystring)
            AsignarParametroCadena(":TSAN_COD", TSAN_COD)
            AsignarParametroCadena(":TSAN_NOM", TSAN_NOM)
            AsignarParametroCadena(":TSAN_FORM", TSAN_FORM)
            AsignarParametroCadena(":TSAN_PAR", TSAN_PAR)
            AsignarParametroCadena(":TSAN_DEC", TSAN_DEC)
            AsignarParametroCadena(":TSAN_DETI", TSAN_DETI)

            na = EjecutarComando()
            ConfirmarTransaccion()
            Me.Msg = MsgOk + "<BR> Número de Filas Afectadas " + na.ToString
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
    Public Function Delete(ByVal COD As String) As String
        Dim na As String

        'If (CInt(COD) = 1) Or (CInt(COD) = 2) Or (CInt(COD) = 3) Then

        'Return "Esta Clase de Impuesto, No se puede eliminar"
        'End If
        Me.Conectar()
        Try
            ComenzarTransaccion()
            Me.querystring = "DELETE TIPO_SANCIONES WHERE TSAN_COD='" + COD + "'"
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
    Public Function Update(ByVal TSAN_COD_Original As String, ByVal TSAN_COD As String, ByVal TSAN_NOM As String, ByVal TSAN_FORM As String, ByVal TSAN_PAR As String, ByVal TSAN_DEC As String, ByVal TSAN_DETI As String) As String
        Dim na As String
        Me.Conectar()
        Try
            ComenzarTransaccion()
            Me.querystring = "UPDATE TIPO_SANCIONES SET TSAN_COD='" + TSAN_COD + "',TSAN_NOM='" + TSAN_NOM + "',TSAN_FORM='" + TSAN_FORM + "',TSAN_PAR='" + TSAN_PAR + "',TSAN_DEC='" + TSAN_DEC + "',TSAN_DETI='" + TSAN_DETI + "' WHERE TSAN_COD='" + TSAN_COD_Original + "' "
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

    <DataObjectMethodAttribute(DataObjectMethodType.Select, True)> _
    Public Overrides Function GetRecords() As DataTable
        Me.Conectar()
        Dim queryString As String = "SELECT * FROM vTSANCIONES WHERE TSAN_DEC=:TSAN_DEC ORDER BY TSAN_COD"
        CrearComando(queryString)
        Dim dataTb As DataTable = EjecutarConsultaDataTable()
        Me.Desconectar()
        Return dataTb
    End Function
    'Para las liquidaciones oficiales
    <DataObjectMethodAttribute(DataObjectMethodType.Select, True)> _
    Public Overloads Function GetRecordsLO(ByVal Dec_tip As String) As DataTable
        Me.Conectar()
        'Dim queryString As String = "SELECT * FROM vTSANCIONES_D WHERE TSAN_DETI Like '%' || TSAN_DETI || '%' ORDER BY TSAN_COD "
        Dim queryString As String = "SELECT * FROM vTSANCIONES_D WHERE :TSAN_DETI Like '%' || TSAN_DETI || '%' AND TSAN_DEC='N'  ORDER BY TSAN_COD"
        CrearComando(queryString)
        AsignarParametroCadena(":TSAN_DETI", Dec_tip)
        Dim dataTb As DataTable = EjecutarConsultaDataTable()
        Me.Desconectar()
        Return dataTb
    End Function
    'Para las declaraciones liquidaciones privadas
    <DataObjectMethodAttribute(DataObjectMethodType.Select, True)> _
    Public Overloads Function GetRecords(ByVal Dec_tip As String) As DataTable
        Me.Conectar()
        'Dim queryString As String = "SELECT * FROM vTSANCIONES_D WHERE TSAN_DETI Like '%' || TSAN_DETI || '%' ORDER BY TSAN_COD "
        Dim queryString As String = "SELECT * FROM vTSANCIONES_D WHERE TSAN_DETI =:TSAN_DETI AND TSAN_DEC='S'  ORDER BY TSAN_COD"
        CrearComando(queryString)
        AsignarParametroCadena(":TSAN_DETI", Dec_tip)
        'dbCommand.Parameters.Add("TSAN_DETI", OracleDbType.Varchar2, ParameterDirection.Input).Value = Dec_tip
        Dim dataTb As DataTable = EjecutarConsultaDataTable()
        Me.Desconectar()
        Return dataTb
    End Function
    <DataObjectMethodAttribute(DataObjectMethodType.Select, True)> _
    Public Overloads Function GetRecordsT() As DataTable
        Me.Conectar()
        Dim queryString As String = "SELECT * FROM TIPO_SANCIONES  "
        CrearComando(queryString)
        Dim dataTb As DataTable = EjecutarConsultaDataTable()
        Me.Desconectar()
        Return dataTb
    End Function
    <DataObjectMethodAttribute(DataObjectMethodType.Select, True)> _
    Public Overloads Function GetPorCod(ByVal Cod As String) As DataTable
        Me.Conectar()
        Dim queryString As String = "SELECT * FROM vTSANCIONES WHERE TSAN_COD=:TSAN_COD"
        CrearComando(queryString)
        AsignarParametroCadena(":TSAN_COD", Cod)
        Dim dataTb As DataTable = EjecutarConsultaDataTable()
        Me.Desconectar()
        Return dataTb

    End Function
    <DataObjectMethodAttribute(DataObjectMethodType.Select, True)> _
    Public Overloads Function GetPorCod2(ByVal Cod As String) As DataTable
        Me.Conectar()
        Dim queryString As String = "SELECT * FROM TIPO_SANCIONES WHERE TSAN_COD=:TSAN_COD"
        CrearComando(queryString)
        AsignarParametroCadena(":TSAN_COD", Cod)
        Dim dataTb As DataTable = EjecutarConsultaDataTable()
        Me.Desconectar()
        Return dataTb

    End Function
    <DataObjectMethodAttribute(DataObjectMethodType.Select, True)> _
    Public Overloads Function GetPorId(ByVal Cod As String) As DataTable
        Me.Conectar()
        Dim queryString As String = "SELECT * FROM Tipo_SANCIONES WHERE TSAN_COD=:TSAN_COD"
        CrearComando(queryString)
        AsignarParametroCadena(":TSAN_COD", Cod)
        Dim dataTb As DataTable = EjecutarConsultaDataTable()
        Me.Desconectar()
        Return dataTb

    End Function

End Class

