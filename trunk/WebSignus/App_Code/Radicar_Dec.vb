Imports Microsoft.VisualBasic
Imports System.Data
Imports System.ComponentModel
Public Structure Radicar_Decl
    Public DR_CODREQ As String
    Public DR_ESTADO As String
End Structure
Public Class Radicar_Dec
    Inherits BDDatos2
    Public Function Insert(ByVal Dr_DoAd As String, ByRef DR_NRODEC As String, ByVal aRadDec() As Radicar_Decl, ByVal DR_FECPRE As Date, ByVal Ban_Cod As String, ByVal Ban_Cta As String) As String
        Me.Conectar()
        Dim DEst As String = "S"
        ComenzarTransaccion()
        Try
            ' na = EjecutarComando()

            Dim queryString As String = "SELECT DEC_EST FROM DECLARACION  WHERE DEC_COD=:DEC_COD And DEC_DOAD=:DEC_DOAD"
            CrearComando(queryString)
            AsignarParametroCadena(":DEC_COD", DR_NRODEC)
            AsignarParametroCadena(":DEC_DOAD", Dr_DoAd)
            Dim dataSet As DataTable = EjecutarConsultaDataTable()
            Dim DEC_EST As String = dataSet.Rows(0)("DEC_EST").ToString
            If InList(DEC_EST, "DF", "DC") Then
                Dim DR_NRORAD As String = GeneraCons(4)
                Dim na As Integer = 0
                For i As Integer = 0 To aRadDec.Length - 1
                    Dim StrSql As String = "INSERT INTO DEC_REQUI(DR_CODDEC,DR_ANO, DR_CODREQ, DR_ESTADO, DR_USAP,DR_FECPRE, DR_FECRAD, DR_USBD, DR_NRORAD  )"
                    StrSql += "VALUES('" + DR_NRODEC + "','" + Left(DR_NRODEC, 4) + "','" + aRadDec(i).DR_CODREQ + "','" + aRadDec(i).DR_ESTADO + "', '" + Me.usuario + "',TO_DATE('" + DR_FECPRE + "','dd/mm/yyyy'), SYSDATE, USER,'" + DR_NRORAD + "')"
                    CrearComando(StrSql)
                    'dbCommand.Parameters.Add("DR_NRODEC", OracleDbType.Varchar2, ParameterDirection.Input).Value = 
                    'dbCommand.Parameters.Add("DR_PERI", OracleDbType.Varchar2, ParameterDirection.Input).Value = DR_PERI
                    'dbCommand.Parameters.Add("DR_ANO", OracleDbType.Varchar2, ParameterDirection.Input).Value = DR_ANO
                    'dbCommand.Parameters.Add("DR_CODREQ", OracleDbType.Varchar2, ParameterDirection.Input).Value = aRadDec(i).DR_CODREQ
                    'dbCommand.Parameters.Add("DR_ESTADO", OracleDbType.Varchar2, ParameterDirection.Input).Value = aRadDec(i).DR_ESTADO
                    'dbCommand.Parameters.Add("DR_USAP", OracleDbType.Varchar2, ParameterDirection.Input).Value = Me.usuario
                    If aRadDec(i).DR_ESTADO = "0" Then
                        DEst = "N"
                    End If
                    na += EjecutarComando()
                Next
                Radicar(Dr_DoAd, DR_NRODEC, DR_FECPRE, DEst, Ban_Cod, Ban_Cta)
                ConfirmarTransaccion()
                Me.Msg = MsgOk + "<BR> Número de Filas Afectadas " + na.ToString
                Me.lErrorG = False
            Else
                Me.Msg = "Error de  Usuario:Esta Declaracion ya ha sido Presentada, si dece presentar nuevamente esta Declarcion Realice una correccion"
            End If
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
    Public Overloads Function GetConceptos(ByVal Cla_Dec As String) As DataTable

        Me.Conectar()
        Dim queryString As String = "select * from vConc_CDec Where CoCd_Cdec=:CD Order by CoCd_codi"
        CrearComando(queryString)
        AsignarParametroCadena(":CD", Cla_Dec)
        Dim dataTb As DataTable = EjecutarConsultaDataTable()
        Me.Desconectar()
        Return dataTb

    End Function
    Public Function GetTotDec(ByVal Dec_Nro As String) As DataTable
        Me.Conectar()
        Dim queryString As String = "SELECT code_vade  FROM  vCODE_CDEC WHERE CODE_DCOD=:CODE_DCOD and SECC_CODI='LP' AND CODE_TICO='D' "
        CrearComando(queryString)
        AsignarParametroCadena(":CODE_DCOD", Dec_Nro)
        Dim dataSet As DataTable = EjecutarConsultaDataTable()
        Me.Desconectar()
        Return dataSet
    End Function
    Public Function GetTotPag(ByVal Dec_Nro As String) As DataTable
        Me.Conectar()
        Dim queryString As String = "SELECT code_vade  FROM  vCODE_CDEC WHERE CODE_DCOD=:CODE_DCOD and SECC_CODI='VP' AND CODE_TICO='T' "
        CrearComando(queryString)
        AsignarParametroCadena(":CODE_DCOD", Dec_Nro)
        Dim dataSet As DataTable = EjecutarConsultaDataTable()
        Me.Desconectar()
        Return dataSet
    End Function
    Public Function GetIntMora(ByVal Dec_Nro As String) As DataTable
        Me.Conectar()
        Dim queryString As String = "SELECT code_vade  FROM  vCODE_CDEC WHERE CODE_DCOD=:CODE_DCOD and SECC_CODI='VP' AND CODE_TICO='I' "
        CrearComando(queryString)
        AsignarParametroCadena(":CODE_DCOD", Dec_Nro)
        Dim dataSet As DataTable = EjecutarConsultaDataTable()
        Me.Desconectar()
        Return dataSet
    End Function

    Public Function GeneraCons(ByVal CONS_ID As String) As String

        'Consultar Consecutivo
        Dim na As Integer = 0
        Dim NroCons As Decimal = 0
        Try
            Dim queryString As String = "SELECT CONS_PRX FROM CONSECUTIVOS WHERE CONS_ID=:CONS_ID"
            CrearComando(queryString)
            AsignarParametroCadena(":CONS_ID", CONS_ID)
            Dim dataSet As DataTable = EjecutarConsultaDataTable()
            NroCons = CDec(dataSet.Rows(0)("CONS_PRX").ToString)

            Dim queryString2 As String = "Update Consecutivos SET Cons_Prx=Cons_Prx+1 Where cons_id=:id"
            CrearComando(queryString2)
            AsignarParametroCadena(":id", CONS_ID)
            na += EjecutarComando()
            Me.lErrorG = False
        Catch ex As Exception
            Me.lErrorG = True
            Me.Msg = "Error de App:" + ex.Message
        Finally
        End Try

        Return NroCons

    End Function
    Public Function Consultar(ByRef DR_NRODEC As String, ByVal aRadDec() As Radicar_Decl, ByVal DR_FECPRE As Date) As String
        Me.Conectar()
        Try
            'Dim dbCommand As New OracleCommand
            'dbCommand.Connection = BDDatos.dbConnection
            Dim DR_NRORAD As String = GeneraCons(4)
            Dim na As Integer = 0
            For i As Integer = 0 To aRadDec.Length - 1
                Dim queryString As String = "SELECT  DR_CODDEC, DR_CODREQ, DR_ESTADO, DR_USAP,DR_FECPRE, DR_FECRAD, DR_USBD, DR_NRORAD  FROM DEC_REQUI WHERE DR_NRORAD=:DR_NRORAD"
                CrearComando(queryString)
                AsignarParametroCadena(":DR_NRODEC", DR_NRODEC)
                Dim dataSet As DataTable = EjecutarConsultaDataTable()
                na += EjecutarComando()
            Next
            Me.Msg = MsgOk + "<BR> Número de Filas Afectadas " + na.ToString
            Me.lErrorG = False
        Catch ex As Exception
            Me.lErrorG = True
            Me.Msg = "Error de App:" + ex.Message
        Finally
            Me.Desconectar()
        End Try
        Return Msg

    End Function

    Public Function Act_Dec(ByVal DEC_NRO As String) As String

        Try
            Dim queryString2 As String = "Update DECLARACION SET DEC_EST='PR' WHERE DEC_NRO=:DEC_NRO"
            CrearComando(queryString2)
            AsignarParametroCadena(":DEC_NRO", DEC_NRO)
            EjecutarConsultaDataTable()
            Me.lErrorG = False
        Catch ex As Exception
            Me.lErrorG = True
            Me.Msg = "Error de App:" + ex.Message
        Finally
        End Try
        Return Msg

    End Function
    Public Sub Radicar(ByVal Dec_Doad As String, ByVal Dec_Cod As String, ByVal Dec_FPre As Date, ByVal Dec_Est As String, ByVal Ban_Cod As String, ByVal Ban_Cta As String)
        Dim na As Integer
        'Me.Conectar
        Me.querystring = "Decl.RadicarD2"
        CrearComando(querystring, CommandType.StoredProcedure)
        AsignarParametroCad("TCod", Dec_Doad)
        AsignarParametroCad("DCod", Dec_Cod)
        AsignarParametroFec("DFpre", Dec_FPre)
        AsignarParametroCad("DEst", Dec_Est)
        AsignarParametroCad("Ban_Cod", Ban_Cod)
        AsignarParametroCad("Ban_Cta", Ban_Cta)
        AsignarParametroCad("USAP", Me.usuario)
        na = EjecutarComando()
    End Sub
End Class
