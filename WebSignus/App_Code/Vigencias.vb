Imports Microsoft.VisualBasic
Imports System.Data
Imports System.ComponentModel
Imports System
Imports System.Data.Common


<System.ComponentModel.DataObject()> _
Public Class Vigencias
    Inherits BDDatos2

    Private Año_Vigencia As String
    Private cod_Estado As String


    Public Property Vigencia() As String
        Get
            Return Año_Vigencia
        End Get
        Set(ByVal value As String)
            Año_Vigencia = value
        End Set
    End Property

    Public Property Estado() As String
        Get
            Return cod_Estado
        End Get
        Set(ByVal value As String)
            cod_Estado = value
        End Set
    End Property



    Public Sub New()

        Me.Tabla = "VIGENCIA"
        Me.Vista = "VIGENCIA"

        'Order by Vig_Cod desc

    End Sub
    <DataObjectMethodAttribute(DataObjectMethodType.Select, True)> _
    Public Overrides Function GetRecords() As System.Data.DataTable
        Me.Conectar()
        Me.querystring = "SELECT * FROM  " + Vista + " Order by vig_cod Desc"
        CrearComando(querystring)
        Dim dataSet As System.Data.DataTable = EjecutarConsultaDataTable()
        Me.Desconectar()
        Return dataSet
    End Function
    '<DataObjectMethodAttribute(DataObjectMethodType.Insert, True)> _
    Public Function Insert(ByVal Año As String) As String
        Me.Conectar()
        Try
            ComenzarTransaccion()
            Me.querystring = "INSERT INTO VIGENCIA (VIG_COD)VALUES(:VIG_COD)"
            CrearComando(querystring)
            AsignarParametroCadena(":VIG_COD", Año)
            Me.num_reg = EjecutarComando()
            Me.Msg = MsgOk + "<BR> Número de Filas Afectadas " + num_reg.ToString
            Me.lErrorG = False
            ConfirmarTransaccion()
        Catch ex As Exception
            CancelarTransaccion()
            Me.lErrorG = True
            Me.Msg = ex.Message
        End Try
        Me.Desconectar()
        Return Msg
    End Function

    '<DataObjectMethodAttribute(DataObjectMethodType.Insert, True)> _
    Public Function delete(ByVal Año As String) As String
        Me.Conectar()
        Try
            Me.querystring = "DELETE FROM VIGENCIA  WHERE VIG_COD=:VIG_COD"
            CrearComando(querystring)
            AsignarParametroCadena(":VIG_COD", Año)
            EjecutarComando()
            Me.Msg = MsgOk
            Me.lErrorG = False
        Catch ex As Exception
            Me.lErrorG = True
            Me.Msg = ex.Message
        End Try
        Me.Desconectar()
        Return Msg
    End Function
    <DataObjectMethodAttribute(DataObjectMethodType.Select, True)> _
    Public Function GetActiva() As String
        Me.Conectar()
        Me.querystring = "SELECT Vig_Cod FROM  " + Vista + " Where Vig_Est='AC'"
        CrearComando(querystring)
        Dim dataTb As DataTable = EjecutarConsultaDataTable()

        Me.Desconectar()

        Return dataTb.Rows(0)(0).ToString
    End Function

    Public Function GetVigenciaA() As String
        Me.Conectar()
        Me.querystring = "SELECT Vig_Cod FROM  Vigencia Where Vig_Est='AC'"
        CrearComando(querystring)
        Dim dataTb As DataTable = EjecutarConsultaDataTable()
        Me.Desconectar()
        Return dataTb.Rows(0)(0).ToString
    End Function

    Public Function GetActivaD() As String
        Me.Conectar()
        Me.querystring = "SELECT Vig_Cod FROM  Vigencia Where Vig_Est='AC'"
        CrearComando(querystring)
        Dim dataTb As DataTable = EjecutarConsultaDataTable()
        Me.Desconectar()
        Return dataTb.Rows(0)(0).ToString
    End Function

    Public Function GetVigencia(ByVal Nom As String, ByVal vig As String) As String
        Me.Conectar()
        Me.querystring = "VigenciaActual"
        CrearComando(querystring, CommandType.StoredProcedure)
        ' Consecutivo
        Dim pReturn As dbparameter = AsignarParametroReturn(20)
        EjecutarComando()
        'Me.Desconectar()
        Return pReturn.Value.ToString()
    End Function
    <DataObjectMethodAttribute(DataObjectMethodType.Select, True)> _
    Public Overloads Function GetPorCod(ByVal VIG_COD As String) As DataTable
        Me.Conectar()
        Me.querystring = "SELECT * FROM Vigencia WHERE VIG_COD=:VIG_COD"
        CrearComando(querystring)
        AsignarParametroCadena(":VIG_COD", VIG_COD)
        Dim dataTb As DataTable = EjecutarConsultaDataTable()
        Me.Desconectar()
        Return dataTb
    End Function

    Public Function Update(ByVal Vig_Cod As String, ByVal VIG_EST As String) As String
        Dim na As String
        Me.Conectar()
        Try
            ComenzarTransaccion()
            Me.querystring = "UPDATE Vigencia SET VIG_EST='" + VIG_EST + "' WHERE VIG_COD='" + Vig_Cod + "'"
            CrearComando(querystring)
            na = EjecutarComando()
            ConfirmarTransaccion()
            Me.Msg = MsgOk + "<BR> Registros Actualizados [" + na + "]"
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

    Public Function TRALADAR_CONF(ByVal vig_para As String, ByVal tablas As CheckBoxList) As String
        Dim na As Integer
        Dim tabla1 As String = ""
        Me.Conectar()
        ComenzarTransaccion()
        Dim i As Integer
        Try
            For i = 0 To tablas.Items.Count - 1
                If tablas.Items(i).Selected = True Then
                    Me.querystring = "Config.TRASLADAR_CONF"
                    CrearComando(querystring, CommandType.StoredProcedure)
                    AsignarParametroCad(":vig_para", vig_para)
                    AsignarParametroCad(":tbla", tablas.Items(i).Value)
                    na = EjecutarComando()
                    If tabla1 = "" Then
                        tabla1 = tabla1 & tablas.Items(i).Value
                    Else
                        tabla1 = tabla1 & ", " & tablas.Items(i).Value
                    End If
                End If
            Next
            ConfirmarTransaccion()
            Me.Msg = MsgOk + "Traslado de " + tabla1
            Me.lErrorG = False
        Catch ex As Exception
            Me.lErrorG = True
            Me.Msg = "Error de App:" + ex.Message
            CancelarTransaccion()
        Finally
            Me.Desconectar()
        End Try

        'Me.Desconectar()
        Return Msg

    End Function
'agregado shirly
    Public Function Get_ActivaD() As String
        Me.querystring = "SELECT Vig_Cod FROM  Vigencia Where Vig_Est='AC'"
        CrearComando(querystring)
        Dim dataTb As DataTable = EjecutarConsultaDataTable()
        Return dataTb.Rows(0)(0).ToString
    End Function

End Class



