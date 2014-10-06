Imports Microsoft.VisualBasic

Imports System.Data
Imports System.ComponentModel
Imports System

Public Class ActiEcon
    Inherits BDDatos2

    'Public Function Insert(ByVal NOM As String, ByVal FEIN As Date, ByVal FEFI As Date) As String
    '    Dim na As Integer
    '    Me.conectar()
    '    Try
    '        Dim dbCommand As New OracleCommand
    '        dbCommand.Connection = dbConnection
    '        dbCommand.CommandText = "INSERT INTO CLASE_IMPTO (CLIM_CODI,CLIM_NOMB,CLIM_FEIN,CLIM_FEFI)VALUES(:CLIM_CODI,:CLIM_NOMB,to_date('" + FEIN.ToShortDateString + "','dd/mm/yyyy'),to_date('" + FEFI.ToShortDateString + "','dd/mm/yyyy'))"

    '        dbCommand.Parameters.Add("CLIM_CODI", OracleDbType.Varchar2, ParameterDirection.Input).Value = Me.GenCons()
    '        dbCommand.Parameters.Add("CLIM_NOMB", OracleDbType.Varchar2, ParameterDirection.Input).Value = NOM

    '        na = dbCommand.ExecuteNonQuery()
    '        Me.Msg = MsgOk + "<BR> Número de Filas Afectadas " + na.ToString
    '        Me.lErrorG = False
    '    Catch exo As OracleException
    '        Me.lErrorG = True
    '        Me.Msg = "Error de Datos:" + exo.Message
    '    Catch ex As Exception
    '        Me.lErrorG = True
    '        Me.Msg = "Error de App:" + ex.Message
    '    Finally
    '        Me.Desconectar()
    '    End Try

    '    Return Msg
    'End Function
    'Public Function Update(ByVal COD As String, ByVal NOM As String, ByVal fec_ini As Date, ByVal fec_fin As Date) As String
    '    Dim x As String
    '    Me.conectar()
    '    Try
    '        Dim dbCommand As New OracleCommand
    '        dbCommand.Connection = dbConnection
    '        dbCommand.CommandText = "UPDATE CLASE_IMPTO SET CLIM_NOMB='" + NOM + "',CLIM_FEIN=to_date('" + fec_ini.ToShortDateString + "','dd/mm/yyyy'),CLIM_FEFI=to_date('" + fec_fin.ToShortDateString + "','dd/mm/yyyy') WHERE CLIM_CODI='" + COD + "' "
    '        x = dbCommand.ExecuteNonQuery()
    '        Me.Msg = MsgOk + "<BR> Registros Actualizados [" + x + "]"
    '        Me.lErrorG = False
    '    Catch exo As OracleException
    '        Me.lErrorG = True
    '        Me.Msg = "Error de Datos:" + exo.Message
    '    Catch ex As Exception
    '        Me.lErrorG = True
    '        Me.Msg = "Error de App:" + ex.Message
    '    Finally
    '        Me.Desconectar()
    '    End Try
    '    Return Msg
    'End Function

    'Public Function Delete(ByVal COD As String) As String
    '    Dim x As String

    '    'If (CInt(COD) = 1) Or (CInt(COD) = 2) Or (CInt(COD) = 3) Then

    '    'Return "Esta Clase de Impuesto, No se puede eliminar"
    '    'End If
    '    Me.conectar()
    '    Try
    '        Dim dbCommand As New OracleCommand
    '        dbCommand.Connection = dbConnection

    '        dbCommand.CommandText = "DELETE CLASE_IMPTO WHERE CLIM_CODI='" + COD + "'"
    '        x = dbCommand.ExecuteNonQuery()
    '        Me.Msg = MsgOk + " # Registros Eliminados:" + x.ToString
    '        Me.lErrorG = False
    '    Catch exo As OracleException
    '        Me.lErrorG = True
    '        Me.Msg = "Error de Datos:" + exo.Message
    '    Catch ex As Exception
    '        Me.lErrorG = True
    '        Me.Msg = "Error de App:" + ex.Message
    '    Finally
    '        Me.Desconectar()
    '    End Try
    '    Return Msg
    'End Function


    <DataObjectMethodAttribute(DataObjectMethodType.Select, True)> _
    Public Overrides Function GetRecords() As DataTable
        Me.Conectar()
        querystring = "SELECT * FROM vACTIECON ORDER BY ACEC_CODI"
        CrearComando(querystring)
        Dim dataTb As DataTable = EjecutarConsultaDataTable()
        Me.Desconectar()
        Return dataTb
    End Function

    <DataObjectMethodAttribute(DataObjectMethodType.Select, True)> _
    Public Overloads Function GetPorCod(ByVal Cod As String) As DataTable
        Me.conectar()
        Dim queryString As String = "SELECT * FROM vACTIECON WHERE AcEc_CODI=:AcEc_CODI"
        CrearComando(queryString)
        Dim dataTb As DataTable = EjecutarConsultaDataTable()
        Me.Desconectar()
        Return dataTb

    End Function
    Private Overloads Function UltID() As String

        querystring = "SELECT max(clim_codi) FROM CLASE_IMPTO"
        CrearComando(queryString)
        Dim dataTb As DataTable = EjecutarConsultaDataTable()
        'Me.Desconectar()
        Dim r As String = dataTb.Rows(0).Item(0).ToString
        'Me.Desconectar()
        Return r
    End Function

    Public Function GenCons() As String

        Dim c As Integer, cod As String
        c = CInt(UltID()) + 1
        cod = c.ToString.PadLeft(2, "0")

        Return cod


    End Function

End Class

