Imports System.Data
Imports System.Data.Common
Imports System.Configuration
Imports Oracle.DataAccess.Client
Imports Oracle.DataAccess.Types
Imports BDSProvider

Public MustInherit Class OraBDatos
    Inherits BDSProvider.BDSProvider

    Dim pRet1 As OracleParameter

    Public Sub New()

        'MyBase.New("Oracle.DataAccess.Client", ConfigurationManager.ConnectionStrings("ConnectionString").ConnectionString)
        MyBase.New(ConfigurationManager.ConnectionStrings("ConnectionString").ProviderName, ConfigurationManager.ConnectionStrings("ConnectionString").ConnectionString)
        'MyBase.New("ConnectionString")
    End Sub

    Public Overloads Sub AsignarParametroByte(ByVal nombre As String, ByVal valor() As Byte)
        Dim pa As New OracleParameter(nombre, OracleDbType.Byte, valor.Length)
        pa.Value = valor
        
        Me.vComando.Parameters.Add(pa)
    End Sub
    ''ASIGNAR CLOB
    Public Overloads Sub AsignarParametroBLOB(ByVal nombre As String, ByVal valor() As Byte)
        Dim pa As New OracleParameter(nombre, OracleDbType.Blob, valor.Length)
        pa.Value = valor
        pa.Direction = ParameterDirection.Input

        Me.vComando.Parameters.Add(pa)
    End Sub
    ''ASIGNAR Return
    Public Overloads Function AsignarParametroReturn(Optional ByVal size As Integer = 20) As DbParameter
        Dim pa As New OracleParameter
        pa.OracleDbType = OracleDbType.Varchar2
        pa.Size = size
        pa.Direction = ParameterDirection.ReturnValue
        Me.vComando.Parameters.Add(pa)
        Me.pRet1 = pa
        Return (pa)
    End Function
    
    ''ASIGNAR CADENA

    ''' <summary>
    ''' Usando directamente Oraclce
    ''' </summary>
    ''' <param name="nombre"></param>
    ''' <param name="valor"></param>
    ''' <remarks></remarks>

    Public Overloads Sub AsignarParametroCad(ByVal nombre As String, ByVal valor As String)
        Dim pa As New OracleParameter(nombre, OracleDbType.Varchar2, valor.Length)
        pa.Value = valor
        pa.Direction = ParameterDirection.Input
        Me.vComando.Parameters.Add(pa)
    End Sub
    Public Overloads Sub AsignarParametroFec(ByVal nombre As String, ByVal valor As Date)
        Dim pa As New OracleParameter(nombre, OracleDbType.Date)
        pa.Value = valor
        pa.Direction = ParameterDirection.Input
        Me.vComando.Parameters.Add(pa)
    End Sub
    Public Overloads Sub AsignarParametroNumber(ByVal nombre As String, ByVal valor As Integer)
        Dim pa As New OracleParameter(nombre, OracleDbType.Int32)
        pa.Value = valor
        pa.Direction = ParameterDirection.Input
        Me.vComando.Parameters.Add(pa)
    End Sub
    Public Overloads Sub AsignarParametroDec(ByVal nombre As String, ByVal valor As Decimal, Optional ByVal isize As Integer = 17, Optional ByVal iscala As Integer = 4)
        Dim pa As New OracleParameter(nombre, OracleDbType.Decimal)
        pa.Size = isize
        pa.Scale = iscala
        pa.Value = valor
        pa.Direction = ParameterDirection.Input
        Me.vComando.Parameters.Add(pa)
    End Sub
    ''ASIGNAR CLOB
    Public Overloads Sub AsignarParametroCLOB(ByVal nombre As String, ByVal valor As String)
        Dim pa As New OracleParameter(nombre, OracleDbType.Clob, valor.Length)
        pa.Value = valor
        Me.vComando.Parameters.Add(pa)
    End Sub
    ''' <summary>
    ''' Implemtado con Oracle Data Type OracleDbType.Decimal
    ''' </summary>
    ''' <param name="nombre"></param>
    ''' <param name="valor"></param>
    ''' <remarks></remarks>
    Public Overloads Sub AsignarParametroDecimal(ByVal nombre As String, ByVal valor As Decimal, Optional ByVal isize As Integer = 17, Optional ByVal iscala As Integer = 4)
        Dim pa As New OracleParameter(nombre, OracleDbType.Decimal)
        pa.Size = isize
        pa.Scale = iscala
        pa.Value = valor
        Me.vComando.Parameters.Add(pa)
    End Sub
    ''' <summary>
    ''' Implemtado con Oracle Data Type OracleDbType.Date
    ''' </summary>
    ''' <param name="nombre"></param>
    ''' <param name="valor"></param>
    ''' <remarks></remarks>
    Public Overloads Sub AsignarParametroFecha(ByVal nombre As String, ByVal valor As Date)
        Dim pa As New OracleParameter(nombre, OracleDbType.Date)
        pa.Value = valor
        Me.vComando.Parameters.Add(pa)
    End Sub
    ''' <summary>
    ''' Implemtado con Oracle Data Type OracleDbType.Int32
    ''' </summary>
    ''' <param name="nombre"></param>
    ''' <param name="valor"></param>
    ''' <remarks></remarks>
    Public Overloads Sub AsignarParametroInt(ByVal nombre As String, ByVal valor As Integer)
        Dim pa As New OracleParameter(nombre, OracleDbType.Int32)
        pa.Value = valor
        Me.vComando.Parameters.Add(pa)
    End Sub
    '''
    ''' Ejecuta la Consulta y lo devuelve en un DataSet
    '''
    Public Overloads Function EjecutarConsultaDataSet() As DataSet
        Dim dsResult As New DataSet
        Dim adapter As OracleDataAdapter = New OracleDataAdapter(Me.vComando.CommandText, Me.Conexion)
        Dim customers As DataSet = New DataSet
        adapter.Fill(dsResult) ', "Tabla1"
        Return dsResult
    End Function
    '''
    ''' Ejecuta la Consulta y lo devuelve en un DataSet
    '''
    Public Overloads Function EjecutarConsultaDataTable() As DataTable
        Dim dsResult As New DataSet
        Dim adapter As OracleDataAdapter = New OracleDataAdapter(Me.vComando.CommandText, Conexion)
        Dim customers As DataSet = New DataSet
        adapter.Fill(dsResult) ', "Tabla1"
        Return dsResult.Tables(0)
    End Function

    Public Function RetornarParametroDecimal(ByVal pReturn As OracleParameter) As Decimal
        'If xxxx = "OR"
        'Return DirectCast((Me.pRet1.Value), OracleDecimal).todouble

        Dim valor As String = "0" + pReturn.Value.tostring.replace(".", ",")
        Dim CValor As Decimal = CDec(valor)
        Return CValor

    End Function
End Class
