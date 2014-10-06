Imports Microsoft.VisualBasic
Imports Oracle.DataAccess.Client
Imports Oracle.DataAccess.Types
Imports System.Data

Public Class PruebaX
    Inherits BDDatos2
    Public Function ConsultaRef() As DataTable
        Conectar()
        ' create the command for the stored procedure
        Dim cmd = New OracleCommand()
        cmd.Connection = Me.Conexion
        cmd.CommandText = "fnPerOmiso"
        cmd.CommandType = CommandType.StoredProcedure
        ' add the parameters for the stored procedure including the REF CURSOR to retrieve the result set
        cmd.Parameters.Add("outCdecxcal", OracleDbType.RefCursor).Direction = ParameterDirection.ReturnValue
        cmd.Parameters.Add("init", OracleDbType.Varchar2).Value = "824000480"
        cmd.Parameters.Add("aini", OracleDbType.Varchar2).Value = "2012"
        cmd.Parameters.Add("pini", OracleDbType.Varchar2).Value = "01"
        cmd.Parameters.Add("afin", OracleDbType.Varchar2).Value = "2013"
        cmd.Parameters.Add("pfin", OracleDbType.Varchar2).Value = "06"
        cmd.Parameters.Add("cladec", OracleDbType.Varchar2).Value = "40"
        Dim da As OracleDataAdapter = New OracleDataAdapter(cmd)
        Dim dt As New DataTable
        da.Fill(dt)
        da.Dispose()
        Desconectar()
        Return dt
    End Function
End Class
