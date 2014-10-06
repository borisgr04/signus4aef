Imports Microsoft.VisualBasic
Imports System.Data
Imports System.ComponentModel
Imports System

Public Class Parametros
    Inherits BDDatos2

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

            Me.Msg = MsgOk
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


    <DataObjectMethodAttribute(DataObjectMethodType.Select, True)> _
    Public Overrides Function GetRecords() As DataTable
        Me.Conectar()
        'Dim queryString As String = "SELECT  PALI_CODI,PALI_CODI ""Código"", PALI_NOMB ""Nombre"", PALI_TIDA , PALI_VARI ""Variable"", PALIESTA ""Estado"", PALI_DESC   FROM PARA_LIQU"
        Dim queryString As String = "SELECT  PALI_CODI ""Código"", PALI_NOMB ""Nombre"", PALI_TIDA ""Tipo de Dato"", PALI_VARI ""Variable"", PALI_ESTA ""Estado"", PALI_DESC ""Descripción""  FROM PARA_LIQU Order By PALI_CODI"
        CrearComando(queryString)
        '        dbCommand.Parameters.Add("VIG_COD", OracleDbType.Varchar2, ParameterDirection.Input).Value = Vig_Cod
        Dim dataTb As DataTable = EjecutarConsultaDataTable()
        Me.Desconectar()
        Return dataTb
    End Function

    <DataObjectMethodAttribute(DataObjectMethodType.Select, True)> _
    Public Overloads Function GetPorCOd(ByVal PALI_CODI As String) As DataTable
        Me.Conectar()
        Dim queryString As String = "SELECT  PALI_CODI ""Código"", PALI_NOMB ""Nombre"", PALI_TIDA , PALI_VARI ""Variable"", PALIESTA ""Estado"", PALI_DESC  FROM PARA_LIQU WHERE PALI_CODI=:PALI_CODI"
        CrearComando(queryString)
        AsignarParametroCadena(":PALI_CODI", PALI_CODI)
        Dim dataTb As DataTable = EjecutarConsultaDataTable()
        Me.Desconectar()
        Return dataTb
    End Function

    <DataObjectMethodAttribute(DataObjectMethodType.Select, True)> _
    Public Overloads Function GetValores(ByVal PALI_PLCO As String) As DataTable
        Me.Conectar()
        Dim queryString As String = "SELECT * FROM PAR_LIQ_DET WHERE PALI_PLCO=:PALI_PLCO"
        CrearComando(queryString)
        AsignarParametroCadena(":PALI_PLCO", PALI_PLCO)
        Dim dataTb As DataTable = EjecutarConsultaDataTable()
        Me.Desconectar()
        Return dataTb

    End Function
    '' se agrego para filtro en la grid 13 de diciem 2009
    '' Autor: Boris Gonzalez
    <DataObjectMethodAttribute(DataObjectMethodType.Select, True)> _
    Public Overloads Function GetValores(ByVal PALI_PLCO As String, ByVal Filtro As String) As DataTable
        Me.Conectar()
        Dim queryString As String = "SELECT * FROM PAR_LIQ_DET WHERE PALI_PLCO=:PALI_PLCO " + Filtro
        CrearComando(queryString)
        AsignarParametroCadena(":PALI_PLCO", PALI_PLCO)
        Dim dataTb As DataTable = EjecutarConsultaDataTable()
        Me.Desconectar()
        Return dataTb

    End Function



    ' /////////////// 21/noviembre/ 2009//////////////


    Public Function UpdParliq(ByVal parcod As String, ByVal Cod As String, ByVal FecIni As Date, ByVal FecFin As Date, ByVal val As String, ByVal PDec As String) As String
        Dim x As String
        Me.Conectar()
        Dim qs As String = ""
        Try
            ComenzarTransaccion()
            qs = "UPDATE PAR_liq_det SET pali_fein=to_date('" & FecIni.ToShortDateString & "','dd/mm/yyyy'),pali_fefi=to_date('" & FecFin.ToShortDateString & "','dd/mm/yyyy'), pali_valo='" & val & "', par_dec='" & PDec & "' WHERE pali_coid='" & Cod & "' and pali_plco='" & parcod & "'"
            Me.querystring = qs
            CrearComando(querystring)
            x = EjecutarComando()
            Me.Msg = MsgOk
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

    Public Function DelParliq(ByVal PlCo As String, ByVal CoId As String) As String
        Dim x As String
        Me.Conectar()
        Dim qs As String = ""
        Try
            ComenzarTransaccion()
            qs = "DELETE FROM PAR_liq_det  WHERE pali_plco='" & PlCo & "' and pali_coid='" & CoId & "'"
            CrearComando(qs)
            x = EjecutarComando()
            Me.Msg = MsgOk
            Me.lErrorG = False
            ConfirmarTransaccion()
        Catch ex As Exception
            CancelarTransaccion()
            Me.lErrorG = True
            Me.Msg = "Error de App:" + ex.Message
        Finally
            Me.Desconectar()
        End Try
        Return Me.Msg
    End Function


    Public Function InsParliQ2(ByVal PALI_PLCO As String, ByVal PALI_COID As String, ByVal PALI_FEIN As Date, ByVal PALI_FEFI As Date, ByVal PALI_VALO As String, ByVal PAR_DEC As String, ByVal IsFec As String) As String
        Dim x As String
        Dim PALI_VANU As Double
        Dim IsNum As String = False
        Try
            PALI_VANU = CDbl(PALI_VALO)
            IsNum = True
        Catch ex As Exception
            IsNum = False
        End Try
        Me.Conectar()
        Dim qs As String = ""

        Try
            ComenzarTransaccion()
            qs = "INSERT INTO  PAR_LIQ_DET (PALI_PLCO, PALI_COID, PALI_FEIN, PALI_FEFI, PALI_VALO, PAR_DEC"
            If IsNum = True Then
                qs += ", PALI_VANU"
            End If

            If IsFec = True Then
                qs += ", PALI_VADA"
            End If

            qs += ") VALUES(:PALI_PLCO, :PALI_COID, :PALI_FEIN, :PALI_FEFI, :PALI_VALO, :PAR_DEC"

            If IsNum = True Then
                qs += ", :PALI_VANU"
            End If

            If IsFec = True Then
                qs += ", :PALI_VADA"
            End If

            qs += ")"
            CrearComando(qs)
            AsignarParametroCadena(":PALI_PLCO", PALI_PLCO)
            AsignarParametroCadena(":PALI_COID", PALI_COID)
            AsignarParametroFecha(":PALI_FEIN", PALI_FEIN)
            AsignarParametroFecha(":PALI_FEFI", PALI_FEFI)
            AsignarParametroCadena(":PALI_VALO", PALI_VALO)
            AsignarParametroCadena(":PAR_DEC", PAR_DEC)
            If IsNum = True Then
                AsignarParametroCadena(":PALI_VANU", PALI_VALO)
            End If

            If IsFec = True Then
                AsignarParametroCadena(":PALI_VADA", PALI_VALO)
            End If
            'f IsFec = True Then
            'dbCommand.Parameters.Add("PALI_VADA", OracleDbType.Varchar2, ParameterDirection.Input).Value = PALI_VALO
            'End If
            x = EjecutarComando()

            Me.Msg = MsgOk
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
    Public Function InsParliQ(ByVal PALI_PLCO As String, ByVal PALI_COID As String, ByVal PALI_FEIN As Date, ByVal PALI_FEFI As Date, ByVal PALI_VALO As String, ByVal PAR_DEC As String, ByVal IsFec As String) As String
        Dim x As String
        Dim PALI_VANU As Double
        Dim IsNum As String = False
        Try
            PALI_VANU = CDbl(PALI_VALO)
            IsNum = True
        Catch ex As Exception
            IsNum = False
        End Try
        Me.Conectar()
        Dim qs As String = ""

        Try
            ComenzarTransaccion()
            qs = "INSERT INTO  PAR_LIQ_DET (PALI_PLCO, PALI_COID, PALI_FEIN, PALI_FEFI, PALI_VALO, PAR_DEC"
            qs += ") VALUES(:PALI_PLCO, :PALI_COID, :PALI_FEIN, :PALI_FEFI, :PALI_VALO, :PAR_DEC"
            qs += ")"
            CrearComando(qs)
            AsignarParametroCadena(":PALI_PLCO", PALI_PLCO)
            AsignarParametroCadena(":PALI_COID", PALI_COID)
            AsignarParametroFecha(":PALI_FEIN", PALI_FEIN)
            AsignarParametroFecha(":PALI_FEFI", PALI_FEFI)
            AsignarParametroCadena(":PALI_VALO", PALI_VALO)
            AsignarParametroCadena(":PAR_DEC", PAR_DEC)
            x = EjecutarComando()
            Me.Msg = MsgOk
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
    Public Overloads Function GetPARLIQDET(ByVal PALI_PLCO As String, ByVal PALI_COID As String) As DataTable
        Me.Conectar()
        Dim queryString As String = "SELECT * FROM PAR_LIQ_DET WHERE PALI_COID=:PALI_COID AND PALI_PLCO=:PALI_PLCO Order by Pali_FeIn "
        CrearComando(queryString)
        AsignarParametroCadena(":PALI_COID", PALI_COID)
        AsignarParametroCadena(":PALI_PLCO", PALI_PLCO)
        Dim dataTb As DataTable = EjecutarConsultaDataTable()
        Me.Desconectar()
        Return dataTb

    End Function
    Public Function InsNewPar(ByVal PALI_CODI As String, ByVal PALI_NOMB As String, ByVal PALI_TIDA As String, ByVal PALIESTA As String, ByVal PALI_DESC As String) As String
        Dim x As String
        Me.Conectar()
        Dim qs As String = ""
        Try

            ComenzarTransaccion()
            qs = "INSERT INTO  PARA_LIQU (PALI_CODI, PALI_NOMB, PALI_TIDA,  PALI_ESTA, PALI_DESC)"
            qs += " VALUES(:PALI_CODI, :PALI_NOMB, :PALI_TIDA, :PALI_ESTA, :PALI_DESC)"

            CrearComando(qs)
            AsignarParametroCadena(":PALI_CODI", PALI_CODI)
            AsignarParametroCadena(":PALI_NOMB", PALI_NOMB)
            AsignarParametroCadena(":PALI_TIDA", PALI_TIDA)
            'dbCommand.Parameters.Ad:d("PALI_VARI", OracleDbType.Varchar2, ParameterDirection.Input).Value = PALI_VARI
            AsignarParametroCadena(":PALI_ESTA", PALIESTA)
            AsignarParametroCadena(":PALI_DESC", PALI_DESC)

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

    Public Function UpdPar(ByVal PALI_CODI As String, ByVal PALI_NOMB As String, ByVal PALI_TIDA As String, ByVal PALIESTA As String, ByVal PALI_DESC As String) As String
        Dim x As String
        Me.Conectar()
        Dim qs As String = ""
        Try
            ComenzarTransaccion()
            qs = "UPDATE PARA_LIQU SET PALI_NOMB='" + PALI_NOMB + "', PALI_TIDA='" + PALI_TIDA + "', PALI_ESTA='" + PALIESTA + "', PALI_DESC='" + PALI_DESC + "' WHERE PALI_CODI='" + PALI_CODI + "'"
            CrearComando(qs)

            'dbCommand.Parameters.Add("PALI_CODI", OracleDbType.Varchar2, ParameterDirection.Input).Value = PALI_CODI
            'dbCommand.Parameters.Add("PALI_NOMB", OracleDbType.Varchar2, ParameterDirection.Input).Value = PALI_NOMB
            'dbCommand.Parameters.Add("PALI_TIDA", OracleDbType.Varchar2, ParameterDirection.Input).Value = PALI_TIDA
            ''dbCommand.Parameters.Add("PALI_VARI", OracleDbType.Date, ParameterDirection.Input).Value = PALI_VARI
            'dbCommand.Parameters.Add("PALIESTA", OracleDbType.Varchar2, ParameterDirection.Input).Value = PALIESTA
            'dbCommand.Parameters.Add("PALI_DESC", OracleDbType.Varchar2, ParameterDirection.Input).Value = PALI_DESC

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

    <DataObjectMethodAttribute(DataObjectMethodType.Select, True)> _
    Public Overloads Function GetParametros(ByVal PALI_CODI As String) As DataTable
        Me.Conectar()
        Dim queryString As String = "SELECT * FROM PARA_LIQU WHERE PALI_CODI=:PALI_CODI"
        CrearComando(queryString)
        AsignarParametroCadena(":PALI_CODI", PALI_CODI)

        Dim dataTb As DataTable = EjecutarConsultaDataTable()
        Me.Desconectar()
        Return dataTb

    End Function
    Public Function DelPar(ByVal PALI_CODI As String) As String
        Dim x As String
        Me.Conectar()
        Dim qs As String = ""
        Try
            ComenzarTransaccion()
            qs = "DELETE FRoM PARA_LIQU  WHERE PALI_CODI='" + PALI_CODI + "'"
            CrearComando(qs)
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
End Class
