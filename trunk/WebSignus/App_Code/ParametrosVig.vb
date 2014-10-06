Imports Microsoft.VisualBasic
Imports System.Data
Imports System.ComponentModel
Imports System

Public Class ParametrosVig
    Inherits BDDatos2

    Public Function Insert(ByVal Año As String, ByVal nom As String, ByVal val As String) As String
        Me.Conectar()
        Try
            ComenzarTransaccion()
            Me.querystring = "INSERT INTO PARAMETROS_VIG (VIG_COD,PAR_NOM,PAR_VAL)VALUES(:VIG_COD,:PAR_NOM,:PAR_VAL)"
            CrearComando(querystring)
            AsignarParametroCadena(":VIG_COD", Año)
            AsignarParametroCadena(":PAR_NOM", nom)
            AsignarParametroCadena(":PAR_VAL", val)
            EjecutarComando()
            Me.Msg = MsgOk
            Me.lErrorG = False
            ConfirmarTransaccion()
        Catch ex As Exception
            CancelarTransaccion()
            Me.lErrorG = True
            Me.Msg = ex.Message
        Finally
            Me.Desconectar()
        End Try
        Return Msg
    End Function
    Public Function Update(ByVal id As String, ByVal nom As String, ByVal val As String) As String
        Dim x As String
        Me.Conectar()
        Try
            ComenzarTransaccion()
            'me.querystring = "UPDATE PARAMETROS_VIG SET PAR_NOM=:PAR_NOM,PAR_VAL=:PAR_VAL WHERE VIG_COD=:VIG_COD "
            Me.querystring = "UPDATE PARAMETROS_VIG SET PAR_NOM='" + nom + "',PAR_VAL='" + val + "' WHERE ID=" + id + " "
            CrearComando(querystring)
            'dbCommand.Parameters.Add("VIG_COD", Año)
            'dbCommand.Parameters.Add("PAR_NOM", nom)
            'dbCommand.Parameters.Add("PAR_VAL", val)
            x = EjecutarComando()
            ConfirmarTransaccion()
            Me.Msg = MsgOk
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

    Public Function Delete(ByVal id As String) As String
        Dim x As String
        Me.Conectar()
        Try
            ComenzarTransaccion()

            Me.querystring = "DELETE PARAMETROS_VIG WHERE ID=" + id + " "

            CrearComando(querystring)
            x = EjecutarComando()
            Me.Msg = MsgOk + " # Filas Afectadas:" + x.ToString
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


    '<DataObjectMethodAttribute(DataObjectMethodType.Select, True)> _
    Public Function GetParametros(ByVal Vig_Cod As String) As DataTable
        Me.Conectar()
        Dim queryString As String = "SELECT * FROM PARAMETROS_VIG Where VIG_COD=:VIG_COD ORDER BY ID"
        CrearComando(queryString)
        AsignarParametroCadena(":VIG_COD", Vig_Cod)
        Dim dataTb As DataTable = EjecutarConsultaDataTable()
        Me.Desconectar()
        Return dataTb

    End Function
End Class
