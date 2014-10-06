Imports Microsoft.VisualBasic
Imports System.Data
Imports System.Data.OleDb
Imports System.Math
Imports System.IO
Imports System.Collections.Specialized
Imports System.ComponentModel
Imports System.Configuration
Imports System


Public Class FmtosImp
    Inherits BDDatos2
    'Dim Msg As String
    Dim RArchivo As String
    Dim Libro As String
    Dim Fmto_Codigo As String
    Dim Dlm As String = ";"
    Dim ExcelProvider As String = "provider=Microsoft.Jet.OLEDB.4.0; "
    Dim ExcelProperties As String = "; Extended Properties=Excel 8.0;"
    Dim StrArchivo As String
    Dim Values As String = ""
    Dim _PUNTODEC_ As String = ConfigurationManager.AppSettings("PUNTO_DEC")
    Protected dt As DataTable


    Dim ColCampo As String = "FMIM_CAMP"
    Dim ColTIDA As String = "TIDA_NET"
    Dim ColError As String = "LOG_ERROR"

    Private Tabla_Fmto As String

    'FMIM_TIDA
    Dim Campos As String '= "NRO_EGRESO,FECHA,TIPO_IDE,IDENTIFICACIÓN,CONTRAVENTOR,CONCEPTO,VALOR_BASE,COD_IMPTO,TIP_TAR,TARIFA,VALOR"
    Dim TiposCampos As String '= "N,D,C,C,C,C,N,C,C,N,N"

    Dim lError As Boolean
    Protected Nro_Error As Integer
    Public Property Delimitador() As String
        Get
            Return Dlm
        End Get
        Set(ByVal value As String)
            Dlm = value
        End Set
    End Property
    Public Property PathLibro() As String
        Get
            Return Libro
        End Get
        Set(ByVal value As String)
            Libro = value
        End Set
    End Property
    Public Property RutaArchivo() As String
        Get
            Return Me.RArchivo
        End Get
        Set(ByVal value As String)
            Me.RArchivo = value
        End Set
    End Property
    Public Property Codigo() As String
        Get
            Return Fmto_Codigo
        End Get
        Set(ByVal value As String)
            Fmto_Codigo = value
            Me.Tabla_Fmto = GetTabla_Fmto()
        End Set
    End Property
    Public ReadOnly Property Error_Import() As Boolean
        Get
            Return Me.lError
        End Get
    End Property
    Public ReadOnly Property TablaImp() As DataTable
        Get
            Return Me.dt
        End Get
    End Property
    Public ReadOnly Property fmtCampos() As String
        Get
            Return Me.Campos
        End Get
    End Property
    Public ReadOnly Property fmtValues() As String
        Get
            Return Me.Values
        End Get
    End Property
    Public ReadOnly Property fmtTabla() As String
        Get
            Return Me.Tabla_Fmto
        End Get
    End Property
    Public ReadOnly Property MsgResult() As String
        Get
            Return Me.Msg
        End Get
    End Property


    Public ReadOnly Property CampoError() As String
        Get
            Return Me.ColError
        End Get
    End Property
    Private Function GetFormato() As DataTable
        Me.Conectar()
        Me.querystring = "SELECT * FROM  vFmto_Imp Where FmIm_Codi='" & Me.Fmto_Codigo & "' Order By FmIm_Indx"
        CrearComando(querystring)
        Dim dataTb As DataTable = EjecutarConsultaDataTable()
        Me.Desconectar()
        Return dataTb
    End Function
    Public Function GetTabla_Fmto() As String
        Dim sw As Boolean = False
        Dim c As Object
        Me.Conectar()
        Me.querystring = "Select FMTO_NOMB From FMTOS Where FMTO_CODI=:FMTO_CODI"
        CrearComando(querystring)
        AsignarParametroCadena(":FMTO_CODI", Me.Fmto_Codigo)
        c = EjecutarEscalar()

        Me.Desconectar()

        Return CStr(c)
    End Function

    Private Function CrearTableBaseLiq() As DataTable
        Dim dt As DataTable = New DataTable
        Dim dtReturn As DataTable = New DataTable("BasesLiq")
        dt = Me.GetFormato()
        'Dim TiDa As String
        'Dim CoNa As String
        Me.Campos = ""
        Dim DtColum As DataColumn


        'Columnas del Archivo Automáticamente
        For i As Integer = 0 To dt.Rows.Count - 1
            DtColum = New DataColumn
            DtColum.ColumnName = dt.Rows(i)(Me.ColCampo).ToString
            DtColum.DataType = Type.GetType(dt.Rows(i)(Me.ColTIDA).ToString)
            Campos = Campos + IIf(Campos = "", dt.Rows(i)(Me.ColCampo).ToString, "," + dt.Rows(i)(Me.ColCampo).ToString)
            'dtcolum.MaxLength=
            'TiDa = dt.Rows(i)(Me.ColTIDA).ToString
            'CoNa = dt.Rows(i)(Me.ColCampo).ToString
            'dtReturn.Columns.Add(CoNa, System.Type.GetType(TiDa))
            dtReturn.Columns.Add(DtColum)
        Next

        'Columna de Errores
        DtColum = New DataColumn
        DtColum.ColumnName = Me.ColError
        DtColum.DataType = Type.GetType("System.String")
        dtReturn.Columns.Add(DtColum)


        dtReturn.AcceptChanges()
        Return dtReturn

    End Function

    'Leer Archivo Plano Separado por Comas
    Public Function LeerArchivo() As Boolean

        Dim fileName As String = RutaArchivo
        Dim stream As New FileStream(fileName, FileMode.Open, FileAccess.Read)
        Dim reader As New StreamReader(stream)
        'Crear la Data, de acuerdo al Formato de Importación Seleccionado
        Me.dt = CrearTableBaseLiq()

        Dim dtrow As DataRow
        Dim Registro As String
        Dim Columnas As Integer = dt.Columns.Count
        Dim i As Integer = 1
        Dim dtFmt As DataTable = Me.GetFormato()
        Msg = ""
        Me.lError = False
        StrArchivo = ""
        Nro_Error = 0
        Dim sw As Boolean = False
        While reader.Peek() > -1
            dtrow = dt.NewRow
            Registro = reader.ReadLine()
            Dim col() As String = Registro.Split(Dlm)
            Values = ""
            If col.Length = (Columnas - 1) Then
                StrArchivo += "Registro N°" & i.ToString & "-" & (Registro) + "<br>"
                For k As Integer = 0 To Columnas - 2
                    Select Case dtFmt.Rows(k)("FMIM_TIDA").ToString
                        Case "C"
                            dtrow(k) = col(k)
                            ' Values += IIf(Values = "", "'" + col(k) + "'", ",'" + col(k) + "'")
                        Case "N"
                            Try
                                dtrow(k) = CDbl(IIf(col(k) = "", 0, col(k)))
                                '    Values += IIf(Values = "", col(k).Replace(",", "."), "," + col(k).Replace(",", "."))
                            Catch ex As Exception
                                Msg += String.Format("Error Fila {0}, Error al Convertir a Númerico, Campo {1}, Error {2}<br>", i, dtFmt.Rows(k)(Me.ColCampo).ToString, ex.Message)
                                dtrow(Me.ColError) += String.Format("Error Fila {0}, Error al Convertir a Númerico, Campo {1}, Error {2}<br>", i, dtFmt.Rows(k)(Me.ColCampo).ToString, ex.Message)
                                sw = True
                                dtrow(k) = 0
                                Nro_Error += 1
                                Me.lError = True
                            End Try

                        Case "D"
                            If IsDate(col(k)) Then
                                dtrow(k) = CDate(col(k))
                                '   Values += IIf(Values = "", "'" + col(k) + "'", ",'" + col(k) + "'")
                            Else
                                Msg += String.Format("Error Fila {0}, Error Valor {1} no Correnponde a Fecha Válida, Campo {2}<br> ", i, col(k), dtFmt.Rows(k)(Me.ColCampo).ToString)
                                dtrow(Me.ColError) += String.Format("Linea {0}, Error Valor {1} no Correnponde a Fecha Válida, Campo {2}<br> ", i, col(k), dtFmt.Rows(k)(Me.ColCampo).ToString)
                                sw = True
                                Nro_Error += 1
                                Me.lError = True
                            End If
                    End Select
                    Values += IIf(Values = "", ":" + (k + 1).ToString, ",:" + (k + 1).ToString)
                Next k
                dt.Rows.Add(dtrow)
                'dt.AcceptChanges()
            Else
                Msg += String.Format("Número de Columnas Erradas(Requeridas {0}, Existentes {1}) - Registro {2}<br>", Columnas - 1, col.Length, i)
                sw = True
                Me.lError = True
            End If
            i += 1
        End While


        reader.Close()
        'Validar Existencia del Nit cómo Agente Recuadador
        Return Not Me.lError
    End Function

    '  Validación con la Base de Datos
    Public Function Validar() As Boolean
        Return False
    End Function

    Protected Function Guardar_Plano(ByVal Nro_Rad As String) As Boolean
        Dim querystring As String = ""
        For Fila As Integer = 0 To dt.Rows.Count - 1
            Dim Values As String = ""
            For col As Integer = 0 To dt.Columns.Count - 2
                If dt.Columns(col).DataType Is Type.GetType("System.String") Then
                    'dbcommand.Parameters.Add(dt.Columns(col).ColumnName, OracleDbType.Varchar2, ParameterDirection.Input).Value = dt.Rows(Fila)(col)
                    Values += IIf(Values = "", String.Format("'{0}'", dt.Rows(Fila)(col)), String.Format(",'{0}'", dt.Rows(Fila)(col)))
                ElseIf dt.Columns(col).DataType Is Type.GetType("System.DateTime") Then
                    'dbcommand.Parameters.Add(dt.Columns(col).ColumnName, OracleDbType.Date, ParameterDirection.Input).Value = dt.Rows(Fila)(col)
                    Values += IIf(Values = "", String.Format("to_date('{0}','dd/mm/yyyy')", CDate(dt.Rows(Fila)(col)).ToShortDateString), String.Format(",to_date('{0}','dd/mm/yyyy')", CDate(dt.Rows(Fila)(col)).ToShortDateString))
                ElseIf dt.Columns(col).DataType Is Type.GetType("System.Double") Then
                    'dbcommand.Parameters.Add(dt.Columns(col).ColumnName, OracleDbType.Decimal, ParameterDirection.Input).Value = CDbl(dt.Rows(Fila)(col).ToString.Replace(",", "."))
                    Values += IIf(Values = "", "to_number('" + dt.Rows(Fila)(col).ToString.Replace(",", _PUNTODEC_) + "')", "," & "to_number('" + dt.Rows(Fila)(col).ToString.Replace(",", _PUNTODEC_) + "')")
                End If
                Msg += Fila.ToString + "-" + col.ToString + "-" + CStr(dt.Rows(Fila)(col)) + "<->" + dt.Columns(col).DataType.ToString + "<br>"
            Next col
            Msg = Msg + Me.fmtTabla
            querystring = "INSERT INTO " + Me.fmtTabla + "(" + Me.fmtCampos + ",NRO_RAD)Values(" + Values + "," + Nro_Rad + ")"
            CrearComando(querystring)
            'dbcommand.BindByName = True
            EjecutarComando()
            Me.lError = False
        Next Fila
        Return Not Me.lError

    End Function



End Class

