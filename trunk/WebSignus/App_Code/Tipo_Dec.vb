Imports Microsoft.VisualBasic
Imports System.Data
Imports System.ComponentModel
Imports System

Public Class Tipo_Dec
    Inherits BDDatos2
    Public Function Insert(ByVal TDEC_COD As String, ByVal TDEC_NOM As String, ByVal TDEC_FIN As Date, ByVal TDEC_FFI As Date, ByVal TDEC_CDEC As String, ByVal TDEC_CODI As String) As String
        Dim na As Integer
        Me.Conectar()
        Try
            ComenzarTransaccion()
            Me.querystring = "INSERT INTO TIPO_DEC (TDEC_COD,TDEC_NOM,TDEC_FIN,TDEC_FFI,TDEC_CDEC,TDEC_CODI,TDEC_USAP)VALUES(:TDEC_COD,:TDEC_NOM,:TDEC_FIN,:TDEC_FFI,:TDEC_CDEC,:TDEC_CODI,:TDEC_USAP)"
            AsignarParametroCadena(":TDEC_COD", TDEC_COD)
            AsignarParametroCadena(":TDEC_NOM", TDEC_NOM)
            AsignarParametroFecha(":TDEC_FIN", TDEC_FIN)
            AsignarParametroFecha(":TDEC_FFI", TDEC_FFI)
            AsignarParametroCadena(":TDEC_CDEC", TDEC_CDEC)
            AsignarParametroCadena(":TDEC_CODI", TDEC_CODI)
            AsignarParametroCadena(":TDEC_USAp", "12345")
            'Me.usuario
            na = EjecutarComando()
            Me.Msg = MsgOk + "<BR> Número de Filas Afectadas " + na.ToString
            Me.lErrorG = False
            ConfirmarTransaccion()
        Catch ex As Exception
            Me.lErrorG = True
            Me.Msg = "Error de App:" + ex.Message
            CancelarTransaccion()
        Finally
            Me.Desconectar()
        End Try


        Return Msg
    End Function
    Public Function Delete(ByVal TDEC_COD As String, ByVal TDEC_CDEC As String) As String
        Dim na As String

        'If (CInt(COD) = 1) Or (CInt(COD) = 2) Or (CInt(COD) = 3) Then

        'Return "Esta Clase de Impuesto, No se puede eliminar"
        'End If
        Me.Conectar()
        Try
            ComenzarTransaccion()
            Me.querystring = "DELETE TIPO_DEC WHERE TDEC_COD='" + TDEC_COD + "' AND TDEC_CDEC='" + TDEC_CDEC + "'"
            CrearComando(querystring)
            na = EjecutarComando()
            Me.Msg = MsgOk + " # Registros Eliminados:" + na.ToString
            Me.lErrorG = False
            ConfirmarTransaccion()
        Catch ex As Exception
            Me.lErrorG = True
            Me.Msg = "Error de App:" + ex.Message
            CancelarTransaccion()
        Finally
            Me.Desconectar()
        End Try
        Return Msg
    End Function
    Public Function Update(ByVal TDEC_COD_or As String, ByVal TDEC_CDEC_OR As String, ByVal TDEC_COD As String, ByVal TDEC_NOM As String, ByVal fec_ini As Date, ByVal fec_fin As Date, ByVal TDEC_CDEC As String, ByVal TDEC_CODI As String) As String

        Me.Conectar()
        Try
            ComenzarTransaccion()
            Me.querystring = "UPDATE TIPO_DEC SET TDEC_COD='" + TDEC_COD + "', TDEC_NOM='" + TDEC_NOM + "' ,TDEC_FIN=to_date('" + fec_ini.ToShortDateString + "','dd/mm/yyyy'),TDEC_FFI=to_date('" + fec_fin.ToShortDateString + "','dd/mm/yyyy'),TDEC_CDEC='" + TDEC_CDEC + "',TDEC_CODI='" + TDEC_CODI + "' WHERE TDEC_COD='" + TDEC_COD_or + "' AND TDEC_CDEC='" + TDEC_CDEC_OR + "' "
            CrearComando(querystring)
            num_reg = EjecutarComando()
            Me.Msg = MsgOk + "<BR> Registros Actualizados [" + num_reg + "]"
            Me.lErrorG = False
            ConfirmarTransaccion()
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
    Public Overrides Function GetRecords() As DataTable
        Me.Conectar()
        Me.querystring = "SELECT * FROM vTipo_Dec "
        CrearComando(querystring)
        Dim dataTb As DataTable = EjecutarConsultaDataTable()

        Me.Desconectar()
        Return dataTb

    End Function

    <DataObjectMethodAttribute(DataObjectMethodType.Select, True)> _
    Public Overloads Function GetPorClaseDec(ByVal Cla_Dec As String) As DataTable
        Me.Conectar()
        Me.querystring = "Select * From vTipo_Dec WHERE Tdec_cdec=:Cld_COD "
        CrearComando(querystring)
        AsignarParametroCadena(":Cld_COD", Cla_Dec)
        Dim dataTb As DataTable = EjecutarConsultaDataTable()
        Me.Desconectar()
        Return dataTb
    End Function
    <DataObjectMethodAttribute(DataObjectMethodType.Select, True)> _
    Public Overloads Function GetCodiTD(ByVal Cla_Dec As String, ByVal Tdec_cod As String) As String
        Dim c As Object
        Me.Conectar()
        Me.querystring = "    Select TDEC_CODI From vTipo_Dec WHERE Tdec_cdec=:Cld_COD And Tdec_COD=:Tdec_COD "
        CrearComando(querystring)
        AsignarParametroCadena(":Cld_COD", Cla_Dec)
        AsignarParametroCadena(":Tdec_COD", Tdec_cod)
        'dataAdapter.SelectCommand = dbCommand
        'Dim dataTb As DataTable = ejecutarconsultadatatable
        'dataAdapter.Fill(dataTb)
        c = EjecutarEscalar()
        Me.Desconectar()
        Return CStr(c)

    End Function

    <DataObjectMethodAttribute(DataObjectMethodType.Select, True)> _
    Public Overloads Function GetPorCod(ByVal Cod As String, ByVal CLDE As String) As DataTable
        Me.Conectar()
        Me.querystring = "SELECT * FROM TIPO_DEC WHERE TDEC_COD=:TDEC_COD AND TDEC_CDEC=:TDEC_CDEC"
        CrearComando(querystring)
        AsignarParametroCadena(":TDEC_CODI", Cod)
        AsignarParametroCadena(":TDEC_CDEC", CLDE)
        Dim dataTb As DataTable = EjecutarConsultaDataTable()

        Me.Desconectar()
        Return dataTb

    End Function
    'Dim queryString As String = "Select DEC_NRO from Declaracion Where dec_ano='2009' and dec_per='01' and dec_est = 'AC' And dec_nit=:dec_nit"




End Class

