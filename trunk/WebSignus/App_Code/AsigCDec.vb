Imports Microsoft.VisualBasic
Imports System.Data
Imports System.ComponentModel
Imports System
Public Structure VAsig_Ter
    Public CLD_COD As String
    Public CL_EST As String
    Public FECHA_INI As String
    Public FECHA_FIN As String
End Structure
Public Class AsigCDec
    Inherits BDDatos2
    <DataObjectMethodAttribute(DataObjectMethodType.Select, True)> _
    Public Overloads Function GetRecords(ByVal TEDE_NIT As String) As DataTable
        Me.Conectar()
        Dim queryString As String = "SELECT * FROM TER_DEC  INNER JOIN TERCEROS ON TEDE_TNIT=TER_NIT WHERE  TEDE_TNIT='" + TEDE_NIT + "'"
        CrearComando(queryString)
        Dim dataTb As DataTable = EjecutarConsultaDataTable()
        Me.Desconectar()
        Return dataTb

    End Function
    Public Function Insert(ByVal TEDE_TNIT As String, ByRef StrucAsigTer() As VAsig_Ter) As String
        Me.Conectar()
        Dim na As Integer = 0
        Dim i As Integer = 0
        ComenzarTransaccion()
        Try
            'Dim dbCommand1 As New OracleCommand
            'dbCommand1.Connection = BDDatos.dbConnection
            querystring = "DELETE FROM ter_dec WHERE tede_tnit ='" + TEDE_TNIT + "'"
            CrearComando(querystring)
            'dbCommand1.Parameters.Add("TEDE_TNIT", OracleDbType.Varchar2, ParameterDirection.Input).Value = TEDE_TNIT
            EjecutarComando()

            For i = 0 To StrucAsigTer.Length - 1
                If StrucAsigTer(i).CLD_COD <> "" Then
                    querystring = "INSERT INTO TER_DEC( TEDE_TNIT, TEDE_CDEC, TEDE_FINI, TEDE_FFIN, TEDE_USAP, TEDE_USBD, TEDE_FREG, TEDE_FNOV )"
                    querystring += "VALUES('" + TEDE_TNIT + "','" + StrucAsigTer(i).CLD_COD + "',  to_date('" + CDate(StrucAsigTer(i).FECHA_INI).ToShortDateString + "', 'dd/mm/yyyy'), " + " to_date('" + CDate(StrucAsigTer(i).FECHA_FIN).ToShortDateString + "', 'dd/mm/yyyy'), '" + Me.usuario + "',USER, SYSDATE, SYSDATE)"
                    Me.Msg += querystring
                    CrearComando(querystring)
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
    <DataObjectMethodAttribute(DataObjectMethodType.Select, True)> _
    Public Function COnsultarAsig(ByVal TEDE_TNIT As String) As DataTable
        Me.Conectar()
        Dim na As Integer = 0
        Dim dt As DataTable ' = New DataTable
        'Try

        'TEDE_TNIT = IIf(String.IsNullOrEmpty(TEDE_TNIT), "-", TEDE_TNIT)

        If Not String.IsNullOrEmpty(TEDE_TNIT) Then
            querystring = "SELECT cld_cod,cld_nom, TEDE_FINI, TEDE_FFIN, case When tede_cdec is not null then '1' else '0' end Cld_Est FROM clase_dec c  Left Join(Select * From ter_dec Where tede_tnit=:TEDE_TNIT) t On t.tede_cdec=c.cld_cod  order by c.CLD_COD"
            CrearComando(querystring)
            AsignarParametroCadena(":TEDE_TNIT", TEDE_TNIT)
        Else
            querystring = "SELECT cld_cod,cld_nom, TEDE_FINI, TEDE_FFIN, case When tede_cdec is not null then '1' else '0' end Cld_Est FROM clase_dec c  Left Join(Select * From ter_dec Where tede_tnit=:TEDE_TNIT) t On t.tede_cdec=c.cld_cod  order by c.CLD_COD"
            CrearComando(querystring)
            AsignarParametroCadena(":TEDE_TNIT", "*")
        End If

        

        dt = EjecutarConsultaDataTable()

        '        Throw New Exception(Me.vComando.CommandText)
        Me.Desconectar()
        'Catch ex As Exception
        'Me.lErrorG = True
        'Me.Msg = "Error de App:" + ex.Message
        'Finally

        'End Try
        Return dt
    End Function
    Public Function InsertGrupo(ByVal TER_TIP As String, ByRef StrucAsigTer() As VAsig_Ter) As String
        Me.Conectar()
        Dim i As Integer = 0
        Dim na As Integer = 0
        ComenzarTransaccion()
        Try

            querystring = "DELETE FROM ter_dec WHERE tede_tnit IN (sELECT ter_nit  FROM terceros WHERE ter_est = 'AC'  AND ter_tip = :TER_TIP) "
            CrearComando(querystring)
            AsignarParametroCadena(":TER_TIP", TER_TIP)
            EjecutarComando()

            For i = 0 To StrucAsigTer.Length - 1
                If StrucAsigTer(i).CLD_COD <> "" Then
                    Dim StrSql2 As String = "INSERT INTO TER_DEC( TEDE_TNIT, TEDE_CDEC, TEDE_FINI, TEDE_FFIN )"
                    StrSql2 += " SELECT  TER_NIT, '" + StrucAsigTer(i).CLD_COD + "' , to_date('" + StrucAsigTer(i).FECHA_INI + "', 'dd/mm/yyyy'), " + " to_date('" + StrucAsigTer(i).FECHA_FIN + "', 'dd/mm/yyyy') FROM TERCEROS WHERE TER_TIP=:TER_TIP "
                    CrearComando(StrSql2)
                    AsignarParametroCadena(":TER_TIP", TER_TIP)
                    na += EjecutarComando()
                End If
            Next
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
End Class
