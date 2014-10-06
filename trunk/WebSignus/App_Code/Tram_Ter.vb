Imports Microsoft.VisualBasic
Imports System.Data
Imports System.ComponentModel
Imports System.Collections.Generic

Public Class Tram_Ter
    Inherits BDDatos2

    Public Function Insert(ByVal TRTE_NIT As String, ByVal TRTE_TRAM As String) As String

        Dim na As Integer
        Me.Conectar()
        Try
            ComenzarTransaccion()
            Me.querystring = "INSERT INTO TRAM_TER (TRTE_NIT, TRTE_TRAM)VALUES(:TRTE_NIT, :TRTE_TRAM)"
            CrearComando(querystring)
            AsignarParametroCadena(":TRTE_TRAM", TRTE_TRAM)
            AsignarParametroCadena(":TRTE_NIT", TRTE_NIT)
            na = EjecutarComando()
            ConfirmarTransaccion()
            Me.Msg = MsgOk + " Número de Filas Afectadas " + na.ToString
            Me.lErrorG = False
        Catch ex As Exception
            Me.lErrorG = True
            Me.Msg = "Error de App:" + ex.Message
            CancelarTransaccion()
        Finally
            Me.Desconectar()
        End Try


        Return Msg
    End Function

    Public Function Insert(ByVal TRTE_NIT As String, ByVal ListaTramite As List(Of String)) As String

        Me.Conectar()
        Dim na As Integer = 0
        Dim i As Integer = 0
        ComenzarTransaccion()
        Try
            querystring = "DELETE FROM TRAM_TER WHERE TRTE_NIT ='" + TRTE_NIT + "'"
            CrearComando(querystring)
            EjecutarComando()

            For i = 0 To ListaTramite.Count - 1
                If ListaTramite(i).ToString <> "" Then
                    Me.Msg = MsgOk + " Número de Filas Afectadas " + na.ToString
                    Me.lErrorG = False
                    Me.querystring = "INSERT INTO TRAM_TER (TRTE_NIT, TRTE_TRAM)VALUES(:TRTE_NIT, :TRTE_TRAM)"
                    CrearComando(querystring)
                    AsignarParametroCadena(":TRTE_NIT", TRTE_NIT)
                    AsignarParametroCadena(":TRTE_TRAM", ListaTramite(i).ToString)
                    Me.Msg += querystring
                    na += EjecutarComando()
                End If
            Next

            ConfirmarTransaccion()
            Me.Msg = MsgOk + "<BR> Número de Filas Afectadas " + na.ToString
            Me.lErrorG = False
        Catch ex As Exception
            Me.lErrorG = True
            Me.Msg = "Error de App:" + ex.Message
            CancelarTransaccion()
        Finally
            Me.Desconectar()
        End Try
        Return Msg
    End Function

    Public Function Delete(ByVal TRTE_NIT As String, ByVal TRTE_TRAM As String) As String
        Dim na As String
        Me.Conectar()
        Try
            ComenzarTransaccion()
            Me.querystring = "DELETE TRAM_TER WHERE TRTE_NIT= :TRTE_NIT AND TRTE_TRAM = :TRTE_TRAM"
            CrearComando(querystring)
            AsignarParametroCadena(":TRTE_TRAM", TRTE_TRAM)
            AsignarParametroCadena(":TRTE_NIT", TRTE_NIT)
            na = EjecutarComando()
            ConfirmarTransaccion()
            Me.Msg = MsgOk + " # Registros Eliminados:" + na.ToString
            Me.lErrorG = False
        Catch ex As Exception
            Me.lErrorG = True
            Me.Msg = "Error de App:" + ex.Message
            CancelarTransaccion()
        Finally
            Me.Desconectar()
        End Try
        Return Msg
    End Function

    <DataObjectMethodAttribute(DataObjectMethodType.Select, True)> _
    Public Overloads Function GetPorCod(ByVal TRTE_NIT As String, ByVal TRTE_TRAM As String) As DataTable
        Me.Conectar()
        Me.querystring = "SELECT * FROM VTRAM_TER WHERE TRTE_NIT=:TRTE_NIT AND TRTE_TRAM = :TRTE_TRAM"
        CrearComando(querystring)
        AsignarParametroCadena(":TRTE_TRAM", TRTE_TRAM)
        AsignarParametroCadena(":TRTE_NIT", TRTE_NIT)
        Dim dataTb As DataTable = EjecutarConsultaDataTable()
        Me.Desconectar()
        Return dataTb
    End Function

    <DataObjectMethodAttribute(DataObjectMethodType.Select, True)> _
    Public Overrides Function GetRecords() As DataTable
        Me.Conectar()
        Me.querystring = "SELECT * FROM VTRAM_TER ORDER BY TER_NOM, TRTE_TRAM"
        CrearComando(querystring)
        Dim dataTb As DataTable = EjecutarConsultaDataTable()
        Me.Desconectar()
        Return dataTb
    End Function

    <DataObjectMethodAttribute(DataObjectMethodType.Select, True)> _
    Public Overloads Function GetPorNit(ByVal TRTE_NIT As String) As DataTable
        Me.Conectar()
        Me.querystring = "SELECT * FROM VTRAM_TER WHERE TRTE_NIT=:TRTE_NIT"
        CrearComando(querystring)
        AsignarParametroCadena(":TRTE_NIT", TRTE_NIT)
        Dim dataTb As DataTable = EjecutarConsultaDataTable()
        Me.Desconectar()
        Return dataTb
    End Function
End Class
