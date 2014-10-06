Imports Microsoft.VisualBasic
Imports System.Data
Imports System.ComponentModel
Imports System

<DataObjectAttribute()> _
Public Class AcuerdosP
    Inherits BDDatos2
    Dim _Nit As String
    Dim _Cdedc As String
    Dim _ACPA_NUME As String

    Public Function Insert(ByVal NIT As String, ByVal DV As String, ByVal CLDEC As String, ByVal GARANTIA As String, _
                           ByVal VALOR_ACPA As Decimal, ByVal Porc_CuoIni As Decimal, ByVal Val_CuoIni As Decimal, _
                           ByVal NCuotas As Decimal, ByVal dtper As DataTable, ByVal dtcuotas As DataTable, ByVal NitRepLegal As String, _
                           ByVal RepLegal As String, ByVal lugarExp As String, ByVal numExpe As String) As String
        Dim na As Integer
        Me.Conectar()
        ComenzarTransaccion()
        'Try

        Dim ACPA_NUME As String = Me.Get_Consecutivo()


        Me._Nit = NIT
        Me._Cdedc = CLDEC


        Me.querystring = "INSERT INTO ACUE_PAGO (ACPA_NUME,ACPA_CDEC, ACPA_NIT_AR,ACPA_TIP_AR,ACPA_GARA,ACPA_VALO,ACPA_POCI,ACPA_VACI,ACPA_NCUO,ACPA_USAP, ACPA_REP_LEG, ACPA_NIT_REP_LEG, ACPA_REP_EXP, ACPA_NEXP)" & _
        "VALUES(:ACPA_NUME,:ACPA_CDEC, :ACPA_NIT_AR,:ACPA_TIP_AR,:ACPA_GARA,:ACPA_VALO,:ACPA_POCI,:ACPA_VACI,:ACPA_NCUO,:ACPA_USAP, :ACPA_REP_LEG, :ACPA_NIT_REP_LEG, :ACPA_REP_EXP, :ACPA_NEXP)"
        CrearComando(querystring)
        ':ACPA_NUME,:ACPA_CDEC, :ACPA_NIT_AR,:ACPA_TIP_AR,:ACPA_GARA,:ACPA_VALO,:ACPA_POCI,:ACPA_VACI,:ACPA_NCUO
        AsignarParametroCadena(":ACPA_NUME", ACPA_NUME)
        AsignarParametroCadena(":ACPA_CDEC", CLDEC)
        AsignarParametroCadena(":ACPA_NIT_AR", NIT)
        AsignarParametroCadena(":ACPA_TIP_AR", "NI")
        AsignarParametroCadena(":ACPA_GARA", GARANTIA)
        AsignarParametroCadena(":ACPA_VALO", VALOR_ACPA)
        AsignarParametroCadena(":ACPA_POCI", Porc_CuoIni)
        AsignarParametroCadena(":ACPA_VACI", Val_CuoIni)
        AsignarParametroCadena(":ACPA_NCUO", NCuotas)
        AsignarParametroCadena(":ACPA_USAP", Me.usuario)
        AsignarParametroCadena(":ACPA_NIT_REP_LEG", NitRepLegal)
        AsignarParametroCadena(":ACPA_REP_LEG", RepLegal)
        AsignarParametroCadena(":ACPA_REP_EXP", lugarExp)
        AsignarParametroCadena(":ACPA_NEXP", numExpe)
        Me.Doc = ACPA_NUME
        na = EjecutarComando()
        For I As Integer = 0 To dtper.Rows.Count - 1
            '---------------deberia insertarse el numero del form
            Me.Insert_APG(ACPA_NUME, CLDEC, dtper.Rows(I)("Año").ToString, dtper.Rows(I)("periodo").ToString)
        Next

        For I As Integer = 0 To dtcuotas.Rows.Count - 1
            Me.Insert_Cuotas(ACPA_NUME, dtcuotas.Rows(I)("NCuotas").ToString, dtcuotas.Rows(I)("Valor_Cuota").ToString, dtcuotas.Rows(I)("Fecha_Pago").ToString)
        Next

        Me.Msg = MsgOk + "<BR> Número de Filas Afectadas " + na.ToString
        Me.lErrorG = False
        ConfirmarTransaccion()
        'Catch ex As Exception
        '    Me.lErrorG = True
        '    Me.Msg = "Error de App:" + ex.Message
        '    CancelarTransaccion()
        'Finally
        '    Me.Desconectar()
        'End Try

        Return Msg
    End Function

    Private Sub Insert_Deudas(ByVal APDE_APNU As String, ByVal APDE_CDEC As String, ByVal APDE_AGRA As String, ByVal APDE_PGRA As String, ByVal APDE_COCO As String, ByVal APDE_VALO As Decimal, ByVal APDE_DOAD As String, ByVal APDE_NDOC As String, ByVal APDE_NOMC As String)
        Dim na As Integer

        Me.querystring = "INSERT INTO ACPA_DEUDA (APDE_APNU,APDE_CDEC, APDE_AGRA,APDE_PGRA,APDE_COCO,APDE_VALO,APDE_DOAD,APDE_NDOC,APDE_NOMC,APDE_USAP)VALUES(:APDE_APNU,:APDE_CDEC, :APDE_AGRA,:APDE_PGRA,:APDE_COCO,:APDE_VALO,:APDE_DOAD,:APDE_NDOC,:APDE_NOMC,:APDE_USAP)"
        CrearComando(querystring)
        ':ACPA_NUME,:ACPA_CDEC, :ACPA_NIT_AR,:ACPA_TIP_AR,:ACPA_GARA,:ACPA_VALO,:ACPA_POCI,:ACPA_VACI,:ACPA_NCUO
        AsignarParametroCadena(":APDE_APNU", APDE_APNU)
        AsignarParametroCadena(":APDE_CDEC", APDE_CDEC)
        AsignarParametroCadena(":APDE_AGRA", APDE_AGRA)
        AsignarParametroCadena(":APDE_PGRA", APDE_PGRA)
        AsignarParametroCadena(":APDE_COCO", APDE_COCO)
        AsignarParametroDecimal(":APDE_VALO", APDE_VALO)
        AsignarParametroCadena(":APDE_DOAD", APDE_DOAD)
        AsignarParametroCadena(":APDE_NDOC", APDE_NDOC)
        AsignarParametroCadena(":APDE_NOMC", APDE_NOMC)
        AsignarParametroCadena(":APDE_USAP", Me.usuario)
        na = EjecutarComando()


    End Sub

    Private Sub Insert_APG(ByVal APG_APNU As String, ByVal APG_CDEC As String, ByVal APG_AGRA As String, ByVal APG_PGRA As String)
        Dim na As Integer
        Me.querystring = "INSERT INTO ACPA_APG (APG_APNU, APG_CDEC, APG_AGRA, APG_PGRA,APG_USAP)VALUES(:APG_APNU, :APG_CDEC, :APG_AGRA, :APG_PGRA,:APG_USAP)"
        CrearComando(querystring)
        ':APG_APNU, :APG_CDEC, :APG_AGRA, :APG_PGRA
        AsignarParametroCadena(":APG_APNU", APG_APNU)
        AsignarParametroCadena(":APG_CDEC", APG_CDEC)
        AsignarParametroCadena(":APG_AGRA", APG_AGRA)
        AsignarParametroCadena(":APG_PGRA", APG_PGRA)
        AsignarParametroCadena(":APG_USAP", Me.usuario)
        
        na = EjecutarComando()

        Me.querystring = "UPDATE CARTERAD SET CAR_EST='AP', CAR_ACPA = :CAR_ACPA WHERE Car_Nit=:Car_Nit And Car_Cdec=:Car_Cdec And Car_Ano=:Car_Ano And Car_Per=:Car_Per"
        ':APG_APNU, :APG_CDEC, :APG_AGRA, :APG_PGRA
        CrearComando(querystring)
        AsignarParametroCadena(":CAR_ACPA", APG_APNU)
        AsignarParametroCadena(":Car_Nit", Me._Nit)
        AsignarParametroCadena(":Car_Cdec", Me._Cdedc)
        AsignarParametroCadena(":Car_Ano", APG_AGRA)
        AsignarParametroCadena(":Car_Per", APG_PGRA)
        'dbCommand.Parameters.Add("APG_USAP", OracleDbType.Varchar2, ParameterDirection.Input).Value = Me.usuario

        'Throw New Exception(Me.vComando.CommandText)

        na = EjecutarComando()

        Me.querystring = "UPDATE DECLARACION SET DEC_EST='AP' WHERE DEC_Nit=:DEC_Nit And DEC_Cdec=:DEC_Cdec And DEC_Ano=:DEC_Ano And dec_Per=:dec_Per"
        ':APG_APNU, :APG_CDEC, :APG_AGRA, :APG_PGRA
        CrearComando(querystring)
        AsignarParametroCadena(":DEC_Nit", Me._Nit)
        AsignarParametroCadena(":DEC_Cdec", Me._Cdedc)
        AsignarParametroCadena(":DEC_Ano", APG_AGRA)
        AsignarParametroCadena(":dec_Per", APG_PGRA)
        'dbCommand.Parameters.Add("APG_USAP", OracleDbType.Varchar2, ParameterDirection.Input).Value = Me.usuario

        'Throw New Exception(Me.vComando.CommandText)

        na = EjecutarComando()

    End Sub
    Private Sub Insert_Cuotas(ByVal CUAP_APNU As String, ByVal CUAP_CUNU As String, ByVal CUAP_VALO As String, ByVal CUAP_FEPA As Date)
        Dim na As Integer

        'Dim dbCommand As New OracleCommand
        'dbCommand.Connection = dbConnection


        Me.querystring = "INSERT INTO CUOT_ACPA (CUAP_APNU,CUAP_CUNU, CUAP_VALO,CUAP_PAGO,CUAP_FEPA,CUAP_USAP)VALUES(:CUAP_APNU,:CUAP_CUNU, :CUAP_VALO,:CUAP_PAGO,:CUAP_FEPA,:CUAP_USAP)"
        CrearComando(querystring)
        AsignarParametroCadena(":CUAP_APNU", CUAP_APNU)
        AsignarParametroCadena(":CUAP_CUNU", CUAP_CUNU)
        AsignarParametroCadena(":CUAP_VALO", CUAP_VALO)
        AsignarParametroCadena(":CUAP_PAGO", 0)
        AsignarParametroFecha(":CUAP_FEPA", CUAP_FEPA)
        AsignarParametroCadena(":CUAP_USAP", Me.usuario)

        na = EjecutarComando()


    End Sub
    <DataObjectMethodAttribute(DataObjectMethodType.Select, True)> _
    Public Function GetCartera(ByVal Car_Nit As String, ByVal Car_Cdec As String) As DataTable

        Me.Conectar()
        Me.querystring = "Select * From vDeclaracion Where Dec_Cdec=:Dec_Cdec And Dec_Nit=:Dec_Nit And Dec_Ano= :Dec_Ano And Dec_per=:Dec_per And Dec_est ='PR' Order by Dec_Cod Desc "
        queryString = "Select Car_Ano,Car_Tdoc,Car_Dcod, Car_Per, Sum(Saldo_a_cargo) As Saldo_a_cargo,Sum(Saldo_a_favor) As Saldo_a_favor "
        queryString += "From  vCuentaCorriente Where Car_Nit=:Car_Nit And Car_Cdec=:Car_Cdec And Car_Est<>'AP' "
        queryString += "Group By Car_Ano,Car_Tdoc,Car_Dcod, Car_Per Having Sum(Saldo_a_cargo)>0"

        CrearComando(queryString)
        AsignarParametroCadena(":Car_Nit", Car_Nit)
        AsignarParametroCadena(":Car_Cdec", Car_Cdec)

        Dim dataSet As DataTable = EjecutarConsultaDataTable()

        Me.Desconectar()

        Return dataSet
    End Function

    <DataObjectMethodAttribute(DataObjectMethodType.Select, True)> _
Public Function GetAcuerdobById(ByVal ACPA_NUME As String) As DataTable

        Me.Conectar()

        Me.querystring = "Select * From vAcue_pago Where NUMERO =:ACPA_NUME"

        CrearComando(querystring)
        AsignarParametroCadena(":ACPA_NUME", ACPA_NUME)

        Dim datat As DataTable = EjecutarConsultaDataTable()
        Me.Desconectar()

        Return datat
    End Function
    <DataObjectMethodAttribute(DataObjectMethodType.Select, True)> _
    Public Function GetAcuerdosP(ByVal Car_Nit As String, ByVal Car_Cdec As String) As DataTable

        Me.Conectar()

        Me.querystring = "Select * From vAcue_pago Where Acpa_Nit_Ar=:Acpa_Nit_Ar And AcPa_Cdec=:AcPa_Cdec Order by Acpa_Freg Desc"

        CrearComando(querystring)
        AsignarParametroCadena(":Acpa_Nit_Ar", Car_Nit)
        AsignarParametroCadena(":AcPa_Cdec", Car_Cdec)

        Dim datat As DataTable = EjecutarConsultaDataTable()


        Me.Desconectar()

        Return datat
    End Function

    <DataObjectMethodAttribute(DataObjectMethodType.Select, True)> _
    Public Function GetAcuerdosActivos(ByVal Car_Nit As String, ByVal Car_Cdec As String) As DataTable

        Me.Conectar()

        Me.querystring = "Select * From vAcue_pago Where Acpa_Nit_Ar=:Acpa_Nit_Ar And AcPa_Cdec=:AcPa_Cdec AND ACPA_EST = 'AC' Order by Acpa_Freg Desc"

        CrearComando(querystring)
        AsignarParametroCadena(":Acpa_Nit_Ar", Car_Nit)
        AsignarParametroCadena(":AcPa_Cdec", Car_Cdec)

        Dim datat As DataTable = EjecutarConsultaDataTable()


        Me.Desconectar()

        Return datat
    End Function

    <DataObjectMethodAttribute(DataObjectMethodType.Select, True)> _
    Public Function GetCuotas(ByVal cuap_apnu As String) As DataTable

        Me.Conectar()
        Dim queryString As String = "SELECT * FROM Vcuot_acpa WHERE cuap_apnu = :cuap_apnu "
        CrearComando(queryString)
        AsignarParametroCadena(":cuap_apnu", cuap_apnu)


        Dim datat As DataTable = EjecutarConsultaDataTable()
        Me.Desconectar()

        Return datat
    End Function
    <DataObjectMethodAttribute(DataObjectMethodType.Select, True)> _
    Public Function GetSaldoAcuerdo(ByVal cuap_apnu As String) As DataTable

        Me.Conectar()
        Dim queryString As String = "Select CUAP_APNU, sum(CuAp_VAlo-CuAp_Pago) SALDO From Cuot_AcPa WHERE CUAP_APNU = :CUAP_APNU GROUP BY CUAP_APNU "
        CrearComando(queryString)
        AsignarParametroCadena(":CUAP_APNU", cuap_apnu)

        Dim datat As DataTable = EjecutarConsultaDataTable()
        Me.Desconectar()

        Return datat
    End Function
    <DataObjectMethodAttribute(DataObjectMethodType.Select, True)> _
    Public Function GetCarteraD(ByVal Car_Nit As String, ByVal Car_Cdec As String, ByVal car_ano As String, ByVal car_per As String) As DataTable

        Me.Conectar()
        querystring = "Select * "
        querystring += "From  vcuentacorriente Where Car_Nit=:Car_Nit And Car_Cdec=:Car_Cdec And Car_Ano=:Car_Ano And Car_Per=:Car_Per"


        CrearComando(querystring)
        AsignarParametroCadena(":Car_Nit", Car_Nit)
        AsignarParametroCadena(":Car_Cdec", Car_Cdec)
        AsignarParametroCadena(":Car_Ano", car_ano)
        AsignarParametroCadena(":Car_Per", car_per)

        Dim dataSet As DataTable = EjecutarConsultaDataTable()


        Me.Desconectar()


        Return dataSet
    End Function

    <DataObjectMethodAttribute(DataObjectMethodType.Select, True)> _
 Public Function GetVencidos() As DataTable
        Me.Conectar()
        querystring = "Select Ter_nom, AcPa_Nume,Fecha_Registro,Saldo_VEncido,N_Cuotas From ( " & _
        "Select AcPa_Nume,Count(*) N_Cuotas,Sum(CuAp_SAldo) Saldo_VEncido From VCUOT_ACPA ap " & _
        "WHERE CUAP_FEPA<SYSDATE AND CUAP_SALDO>0 Group by AcPa_Nume " & _
        ")ap Inner join vAcue_Pagov2 ap2 On ap.AcPa_Nume=ap2.Numero"
        CrearComando(querystring)
        Dim dt As DataTable = EjecutarConsultaDataTable()
        Me.Desconectar()
        Return dt
    End Function

    Public Function CrearTableCuotas() As DataTable

        Dim dtReturn As DataTable = New DataTable("Cuotas")
        Dim DtColum As DataColumn

        DtColum = New DataColumn
        DtColum.ColumnName = "NCuotas"
        DtColum.DataType = Type.GetType("System.Int16")
        dtReturn.Columns.Add(DtColum)

        DtColum = New DataColumn
        DtColum.ColumnName = "Fecha_Pago"
        DtColum.DataType = Type.GetType("System.DateTime")
        dtReturn.Columns.Add(DtColum)

        DtColum = New DataColumn
        DtColum.ColumnName = "Valor_Cuota"
        DtColum.DataType = Type.GetType("System.Decimal")
        dtReturn.Columns.Add(DtColum)

        dtReturn.AcceptChanges()

        Return dtReturn

    End Function

    Public Function CrearTablePeriodos() As DataTable

        Dim dtReturn As DataTable = New DataTable("Periodos")
        Dim DtColum As DataColumn

        DtColum = New DataColumn
        DtColum.ColumnName = "Año"
        DtColum.DataType = Type.GetType("System.Int16")
        dtReturn.Columns.Add(DtColum)

        DtColum = New DataColumn
        DtColum.ColumnName = "Periodo"
        DtColum.DataType = Type.GetType("System.String")
        dtReturn.Columns.Add(DtColum)

        DtColum = New DataColumn
        DtColum.ColumnName = "Saldo"
        DtColum.DataType = Type.GetType("System.Decimal")
        dtReturn.Columns.Add(DtColum)

        DtColum = New DataColumn
        DtColum.ColumnName = "Documento"
        DtColum.DataType = Type.GetType("System.String")
        dtReturn.Columns.Add(DtColum)


        DtColum = New DataColumn
        DtColum.ColumnName = "NDocumento"
        DtColum.DataType = Type.GetType("System.String")
        dtReturn.Columns.Add(DtColum)

        dtReturn.AcceptChanges()

        Return dtReturn

    End Function
    Function GetPorcMinimo() As Decimal
        Return 15
    End Function
    Function GetNCuotas() As Decimal
        Return 10
    End Function

    Function Get_Consecutivo() As String
        Dim numAcuerdo As String
        Dim ObjC As Consecutivos = New Consecutivos
        Dim vig As Vigencias = New Vigencias
        vig.Conexion = Me.Conexion
        ObjC.Conexion = Me.Conexion
        Dim svig As String = vig.Get_ActivaD()
        numAcuerdo = svig + ObjC.Get_Consec("ACPA", svig).PadLeft(6, "0")
        Return numAcuerdo
    End Function

    Function GetConsecutivo() As String
        Dim numAcuerdo As String
        Dim ObjC As Consecutivos = New Consecutivos
        Dim vig As Vigencias = New Vigencias
        Dim svig As String = vig.GetActivaD()
        numAcuerdo = svig + ObjC.GetConsec("ACPA", svig).PadLeft(6, "0")
        Return numAcuerdo
    End Function

    Function ReLiquidarInteres(ByVal nit As String, ByVal cldec As String) As String
        Me.Conectar()
        ComenzarTransaccion()
        Try
            Me.querystring = "cart.rliquidar_intm"
            CrearComando(querystring, CommandType.StoredProcedure)
            AsignarParametroCad("nit", nit)
            AsignarParametroCad("cdec", cldec)
            'dbCommand.Parameters.Add("fmov", OracleDbType.Date, ParameterDirection.Input).Value = 
            EjecutarComando()
            Me.Msg = Me.MsgOk
            ConfirmarTransaccion()
        Catch ex As Exception
            Me.lErrorG = True
            Me.Msg = "Error de App:" + ex.Message
            CancelarTransaccion()
        Finally
            Me.Desconectar()
        End Try

        Return (Msg)

    End Function
End Class
