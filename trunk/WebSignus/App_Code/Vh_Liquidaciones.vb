Imports Microsoft.VisualBasic
Imports System.ComponentModel
Imports System.Data
Imports System.Data.Common
Imports System.Math
<System.ComponentModel.DataObject()> _
Public Class Vh_Liquidaciones
    Inherits BDDatos2
    Dim pNro_LiqG As String = "0"

    Public cFiltro As String
    Public cVigencia As String
    
    Property Nro_LiqG() As String
        Get
            Return pNro_LiqG
        End Get
        Set(ByVal value As String)
            pNro_LiqG = value
        End Set
    End Property
    Dim _Estado_liq As String
    ReadOnly Property Estado_liq() As String
        Get
            Return pNro_LiqG
        End Get
    End Property
    Class sLiqGrupal
        Public Nro_LiqG As String
        Public FechaIni As Date
        Public FechaFin As Date
        Public Estado As String
        Public Total As Long
        Public Actual As Long
        Public nPorcentaje As Double
        Public cPorcentaje As String
        Public cEstado As String

    End Class

    Public Lg As sLiqGrupal


    Public Function SuspenderLiq(ByVal Nro_LiqG As String) As String
        Dim na As Integer
        Me.Conectar()
        Try
            ComenzarTransaccion()
            querystring = "VH.SuspenderLiqG"
            CrearComando(querystring, CommandType.StoredProcedure)
            Dim pReturn As DbParameter = AsignarParametroReturn(20)
            AsignarParametroCad("inNro_LiqG", Nro_LiqG)
            na = EjecutarComando()
            Me.pNro_LiqG = pReturn.Value.ToString()
            Me.Msg = MsgOk + "<BR> Número de Filas Afectadas " + na.ToString
            ConfirmarTransaccion()
            Me.lErrorG = False
        Catch ex As Exception
            Me.lErrorG = True
            CancelarTransaccion()
            Me.Msg = "Error de App:" + ex.Message
        Finally
            Me.Desconectar()
        End Try
        Return Msg
    End Function

    Public Function SuspenderLiq() As String
        Dim na As Integer
        Me.Conectar()
        Try
            ComenzarTransaccion()
            querystring = "VH.SuspenderLiqG"
            CrearComando(querystring, CommandType.StoredProcedure)
            Dim pReturn As DbParameter = AsignarParametroReturn(20)
            AsignarParametroCad("inNro_LiqG", Nro_LiqG)
            na = EjecutarComando()
            Me.pNro_LiqG = pReturn.Value.ToString()
            Me.Msg = MsgOk + "<BR> Número de Filas Afectadas " + na.ToString
            ConfirmarTransaccion()
            Me.lErrorG = False
        Catch ex As Exception
            Me.lErrorG = True
            CancelarTransaccion()
            Me.Msg = "Error de App:" + ex.Message
        Finally
            Me.Desconectar()
        End Try
        Return Msg
    End Function


    Public Sub Liquidar()
        Dim na As Integer
        Me.Conectar()
        _Estado_liq = "IN"
        Try
            'ComenzarTransaccion()
            querystring = "VH.LIQUIDAR_G"
            CrearComando(querystring, CommandType.StoredProcedure)
            Dim pReturn As DbParameter = AsignarParametroReturn(20)
            AsignarParametroCad("inFiltro", Me.cFiltro)
            AsignarParametroCad("inVigLiq", Me.cVigencia)
            AsignarParametroCad("inNro_LiqG", Me.Nro_LiqG)
            na = EjecutarComando()
            _Estado_liq = "TE"
            'ConfirmarTransaccion()
            Me.pNro_LiqG = pReturn.Value.ToString()
            Me.Msg = MsgOk + "<BR> Número de Filas Afectadas " + na.ToString
            Me.lErrorG = False
        Catch ex As Exception
            Me.lErrorG = True
            'CancelarTransaccion()
            Me.Msg = "Error de App:" + ex.Message
        Finally
            Me.Desconectar()
        End Try

    End Sub


    Public Function Liquidar(ByVal cFiltro As String, ByVal cVigencia As String, ByVal Nro_LiqG As String) As String
        Dim na As Integer
        Me.Conectar()
        Try
            ComenzarTransaccion()
            querystring = "VH.LIQUIDAR_G"
            CrearComando(querystring, CommandType.StoredProcedure)
            Dim pReturn As DbParameter = AsignarParametroReturn(20)
            AsignarParametroCad("inFiltro", cFiltro)
            AsignarParametroCad("inVigLiq", cVigencia)
            AsignarParametroCad("inNro_LiqG", Nro_LiqG)
            na = EjecutarComando()
            'ConfirmarTransaccion()
            Me.pNro_LiqG = pReturn.Value.ToString()

            Me.Msg = MsgOk + "<BR> Número de Filas Afectadas " + na.ToString
            Me.lErrorG = False
        Catch ex As Exception
            Me.lErrorG = True
            CancelarTransaccion()
            Me.Msg = "Error de App:" + ex.Message
        Finally
            Me.Desconectar()
        End Try
        Return Msg
    End Function

    Public Function GetLiquidaciones(ByVal Placa As String, ByVal VigLiq As String) As DataTable
        Me.Conectar()
        querystring = "select * from vvh_declaracion where placa=:placa And Dec_Ano=:dec_ano and dec_est<>'AN' Order by Placa"
        '        Throw New Exception(querystring)
        CrearComando(querystring)
        AsignarParametroCadena(":placa", Placa)
        AsignarParametroCadena(":dec_ano", VigLiq)
        Dim dataTb As DataTable = EjecutarConsultaDataTable()
        Me.Desconectar()
        Return dataTb
    End Function

    Public Function GetUltimaLiquidacion(ByVal Nro_LiqG As String) As Long
        Dim sw As Boolean = False
        Conectar()
        querystring = "SELECT COunt(*) cant  FROM VH_LIQUIDLOG where NRO_LIQG=" + Nro_LiqG
        CrearComando(querystring)
        Dim dataTb As DataTable = EjecutarConsultaDataTable()
        Desconectar()
        Return dataTb.Rows(0)("Cant").ToString
    End Function
    Public Function GetCantLiquidacion() As Long
        Dim sw As Boolean = False
        Conectar()
        querystring = "SELECT COunt(*) cant  FROM VH_LIQUIDLOG where NRO_LIQG=" + Nro_LiqG
        CrearComando(querystring)
        Dim dataTb As DataTable = EjecutarConsultaDataTable()
        Desconectar()
        Return dataTb.Rows(0)("Cant").ToString
    End Function
    Public Function GetEstado() As String
        Dim sw As Boolean = False
        Conectar()
        querystring = "SELECT Estado FROM VH_Liq_Grupal where NRO_LIQG=" + Nro_LiqG
        CrearComando(querystring)
        Dim dataTb As DataTable = EjecutarConsultaDataTable()
        Desconectar()
        Return dataTb.Rows(0)("Estado").ToString
    End Function

    Public Function Obtener_Nro_LiqG() As Long
        Conectar()
        querystring = "  SELECT Nvl(vh.Obtener_Nro_LiqG,0) Cantidad FROM dual"
        CrearComando(querystring)
        Dim dataTb As DataTable = EjecutarConsultaDataTable()
        Desconectar()
        Return dataTb.Rows(0)("Cantidad").ToString
    End Function

    Public Function InsNroLiqG() As String
        Dim na As Integer
        Me.Conectar()
        Try
            ComenzarTransaccion()
            querystring = "VH.INS_LIQ_GRUPAL"
            CrearComando(querystring, CommandType.StoredProcedure)
            Dim pReturn As DbParameter = AsignarParametroReturn(20)
            na = EjecutarComando()
            ConfirmarTransaccion()
            Me.pNro_LiqG = pReturn.Value.ToString()
            Me.Msg = MsgOk + "<BR> Número de Filas Afectadas " + na.ToString
            Me.lErrorG = False
        Catch ex As Exception
            Me.lErrorG = True
            CancelarTransaccion()
            Me.Msg = "Error de App:" + ex.Message
        Finally
            Me.Desconectar()
        End Try
        Return Msg
    End Function

    Public Function GetLiqLog(ByVal NroLiqG As String) As DataTable
        Me.Conectar()
        querystring = "SELECT * FROM VH_LIQUIDLOG where Nro_LiqG=:Nro_LiqG  Order by Placa"
        CrearComando(querystring)
        AsignarParametroCadena(":Nro_LiqG", NroLiqG)
        Dim dataTb As DataTable = EjecutarConsultaDataTable()
        Me.Desconectar()
        Return dataTb
    End Function


    Public Function GetCantLiqLog(ByVal NroLiqG As String) As Long
        Me.Conectar()
        querystring = "SELECT Count(*) FROM VH_LIQUIDLOG where Nro_LiqG=:Nro_LiqG And Liquido='S'  Order by Placa"
        CrearComando(querystring)
        AsignarParametroCadena(":Nro_LiqG", NroLiqG)
        Dim c As Long = CLng(EjecutarEscalar())
        Me.Desconectar()
        Return c
    End Function
    'select * from vvh_declaracion where placa='AKK238' And Dec_Ano='2011'
    <DataObjectMethodAttribute(DataObjectMethodType.Select, True)> _
    Public Overloads Function GetDeclaracionRpt(ByVal Dec_Cod As String) As DataSet
        Me.Conectar()
        Me.querystring = "Select to_number(dec_nro)dec_nro,d.*,r.* From vVh_Declaracion d,copias_rpt r   Where Dec_cod=:Dec_Cod  Order by to_number(Cop_Cod) asc "
        CrearComando(querystring)
        AsignarParametroCadena(":Dec_Cod", Dec_Cod)
        'Throw New Exception(Me.vComando.CommandText)
        Dim dataSet As DataSet = EjecutarConsultaDataSet()
        Me.Desconectar()
        Return dataSet
    End Function


    <DataObjectMethodAttribute(DataObjectMethodType.Select, True)> _
    Public Overloads Function GetDeclaracionRpt_LG(ByVal Nro_LiqG As String, ByVal Desde As String, ByVal Hasta As String) As DataSet
        Me.Conectar()
        'And cop_cod='02'
        querystring = "Select to_number(dec_nro) dec_nro,d.* From vVh_Declaracion d  Where Dec_cod IN (SELECT Dec_Cod FROM vh_liquidlog WHERE (nro_liqg = :Nro_LiqG) And (Liquido='S') AND (dec_cod IS NOT NULL) AND (Liq_Cons>=:Desde AND Liq_Cons<=:Hasta)) Order by Dec_Cod "
        CrearComando(querystring)
        AsignarParametroCadena(":Nro_LiqG", Nro_LiqG)
        AsignarParametroEntero(":Desde", Desde)
        AsignarParametroEntero(":Hasta", Hasta)
        'Throw New Exception(Me.vComando.CommandText)
        Dim dataSet As DataSet = EjecutarConsultaDataSet()
        Me.Desconectar()
        Return dataSet
    End Function

    <DataObjectMethodAttribute(DataObjectMethodType.Select, True)> _
    Public Function GetRpt(ByVal Cod_Form As String) As String
        Me.Conectar()
        'Me.querystring = "Select Fode_Rpte From Formularios_Dec Inner Join Declaracion On Fode_Codi=Dec_FdCo Where Dec_Cod=:Dec_Cod"
        Me.querystring = "Select Fode_Rpte From Formularios_Dec Where fode_cdec = '50' AND sysdate BETWEEN fode_fein AND fode_fefi"
        CrearComando(querystring)
        'AsignarParametroCadena(":Dec_Cod", Dec_Cod)
        Dim c As Object = EjecutarEscalar()
        Me.Desconectar()
        Return c.ToString
    End Function

    <DataObjectMethodAttribute(DataObjectMethodType.Select, True)> _
    Public Function GetLiqConcep(ByVal CODE_DCOD As String) As DataSet
        Me.Conectar()
        Me.querystring = "SELECT * FROM  vCODE_CDEC WHERE CODE_DCOD=:CODE_DCOD Order by CODE_CODI"
        CrearComando(querystring)

        AsignarParametroCadena(":CODE_DCOD", CODE_DCOD)
        Dim dataSet As DataSet = EjecutarConsultaDataSet()

        Me.Desconectar()
        Return dataSet
    End Function

    <DataObjectMethodAttribute(DataObjectMethodType.Select, True)> _
    Public Function GetLiqConcep_LG(ByVal Nro_LiqG As String) As DataSet
        Me.Conectar()
        Me.querystring = "SELECT * FROM  vCODE_CDEC WHERE CODE_DCOD IN (Select Dec_Cod From Vh_LiquidLog Where Nro_LiqG =:Nro_LiqG And Dec_Cod Is Not Null) Order by CODE_CODI"
        CrearComando(querystring)

        AsignarParametroCadena(":Nro_LiqG", Nro_LiqG)
        Dim dataSet As DataSet = EjecutarConsultaDataSet()

        Me.Desconectar()
        Return dataSet
    End Function


    Public Function ImpresionLiqxPar(ByVal Paquete As Long, ByVal Cant_liq As Long, ByVal Nliq As String) As DataTable
        Dim dt As DataTable = New DataTable
        Dim dtReturn As DataTable = New DataTable("dtLiqxPar")
        Dim DtColum As DataColumn

        DtColum = New DataColumn
        DtColum.ColumnName = "Nro_LiqG"
        DtColum.DataType = System.Type.GetType("System.String")
        dtReturn.Columns.Add(DtColum)
        'Columnas del Archivo Automáticamente
        DtColum = New DataColumn
        DtColum.ColumnName = "Desde"
        DtColum.DataType = System.Type.GetType("System.String")
        dtReturn.Columns.Add(DtColum)
        DtColum = New DataColumn
        DtColum.ColumnName = "Hasta"
        DtColum.DataType = System.Type.GetType("System.String")
        dtReturn.Columns.Add(DtColum)
        'Columna de Errores
        DtColum = New DataColumn
        DtColum.ColumnName = "Link"
        DtColum.DataType = Type.GetType("System.String")
        dtReturn.Columns.Add(DtColum)
        dtReturn.AcceptChanges()
        Dim dtrow As DataRow

        Dim cant_paq As Integer = Ceiling(Cant_liq / Paquete)

        Dim ini As Integer = 1
        Dim fin As Integer = IIf(Paquete > Cant_liq, Cant_liq, Paquete)

        For i As Integer = 1 To cant_paq

            dtrow = dtReturn.NewRow
            dtrow("Nro_LiqG") = Nliq
            dtrow("Desde") = ini
            dtrow("Hasta") = fin


            dtReturn.Rows.Add(dtrow)

            ini = fin + 1
            fin = IIf((fin + Paquete) > Cant_liq, Cant_liq, (fin + Paquete))

        Next
        dtReturn.AcceptChanges()
        Return dtReturn

    End Function

    '----------------------- CARGAR LIQUIDACIONES
    Public Sub CargarDatosLiqG()
        Dim sw As Boolean = False
        Conectar()
        querystring = "SELECT * FROM vVh_Liquidlog where NRO_LIQG=" + Nro_LiqG
        CrearComando(querystring)
        Dim dataTb As DataTable = EjecutarConsultaDataTable()
        Desconectar()
        Lg = New sLiqGrupal
        Lg.Nro_LiqG = Me.Nro_LiqG
        'Lg.FechaIni = CDate(dataTb.Rows(0)("Fecha_Ini"))
        'Lg.FechaFin = CDate(dataTb.Rows(0)("Fecha_Fin"))
        Lg.Estado = dataTb.Rows(0)("Estado").ToString
        Lg.Total = CLng(dataTb.Rows(0)("Total"))
        Lg.Actual = CLng(dataTb.Rows(0)("Cant"))
        If Lg.Total <> 0 Then
            Lg.nPorcentaje = (Lg.Actual / Lg.Total)
        Else
            Lg.nPorcentaje = "0"
        End If

        Lg.cPorcentaje = FormatPercent(Lg.nPorcentaje, 2)

        Select Case Lg.Estado
            Case "PE"
                Lg.cEstado = "SIN INICIAR"
            Case "IN"
                Lg.cEstado = "EN EJECUCIÓN"
            Case "TE"
                Lg.cEstado = "FINALIZADO"
            Case "SU"
                Lg.cEstado = "ABORTADO"
        End Select

    End Sub


End Class
