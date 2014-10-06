Imports Microsoft.VisualBasic
Imports System.Data
Imports System
Imports System.ComponentModel
'Clase para manejar la Tabla Form_Ayud de la Base de datos
'Fecha Creaciòn: 07 dic 2009
'Autor: Ronal Javier

Public Class Form_ayud
    Inherits BDDatos2
    '---------------------------------------------------------------------------------------------------------------
    ' Funciòn Insert: Agrega datos a la tabla Form_Ayud

    Public Function Insert(ByVal FOAY_CODI As String, ByVal FOAY_NREN As String, ByVal FOAY_FDCO As String, ByVal FOAY_TITU As String, ByVal FOAY_DESC As String) As String

        Dim na As Integer
        Me.Conectar()
        Try
            ComenzarTransaccion()
            Me.querystring = "INSERT INTO Form_Ayud (FOAY_CODI,FOAY_NREN,FOAY_FDCO,FOAY_TITU,FOAY_DESC,FOAY_USAP)VALUES(:FOAY_CODI,:FOAY_NREN,:FOAY_FDCO,:FOAY_TITU,:FOAY_DESC,:FOAY_USAP)"
            CrearComando(querystring)
            AsignarParametroCadena(":FOAY_CODI", FOAY_CODI)
            AsignarParametroCadena(":FOAY_NREN", FOAY_NREN)
            AsignarParametroCadena(":FOAY_FDCO", FOAY_FDCO)
            AsignarParametroCadena(":FOAY_TITU", FOAY_TITU)
            AsignarParametroCadena(":FOAY_DESC", FOAY_DESC)
            AsignarParametroCadena(":FOAY_USAP", Me.usuario)
            'Me.usuario

            na = EjecutarComando
            Me.Msg = MsgOk + "<BR> Número de Filas Afectadas " + na.ToString
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
    ' Funciòn Actualizar: Actualiza datos a la tabla Tramites
    ' Parametros: TRAM_Codi : Còdigo
    '             TRAM_Nomb : nombre del parametro
    '              TRAM_RESP: Responsable
    '             TRAM_GSAN: Genera sancion
    '             TRAM_COSA: Codigo de sancion
    '             TRAM_PLAN: Plantilla

    Public Function Update(ByVal FOAY_CODI_or As String, ByVal FOAY_CODI As String, ByVal FOAY_NREN As String, ByVal FOAY_FDCO As String, ByVal FOAY_TITU As String, ByVal FOAY_DESC As String) As String
        Dim na As String
        Me.Conectar()
        Try
            ComenzarTransaccion()
            Me.querystring = "UPDATE Form_Ayud SET FOAY_CODI='" + FOAY_CODI + "',FOAY_NREN='" + FOAY_NREN + "',FOAY_FDCO='" + FOAY_FDCO + "',FOAY_TITU='" + FOAY_TITU + "',FOAY_DESC='" + FOAY_DESC + "' WHERE FOAY_CODI='" + FOAY_CODI_or + "'"
            CrearComando(querystring)
            na = EjecutarComando()
            Me.Msg = MsgOk + "<BR> Registros Actualizados [" + na + "]"

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
    ' Funciòn Delete: Borra datos a la tabla Tramites
    ' Parametros: TRAM_Codi : Còdigo
    '             TRAM_Nomb : nombre del parametro
    '              TRAM_RESP: Responsable
    '             TRAM_GSAN: Genera sancion
    '             TRAM_COSA: Codigo de sancion
    '             TRAM_PLAN: Plantilla

    Public Function Delete(ByVal CODI As String) As String
        Dim na As String

        'If (CInt(COD) = 1) Or (CInt(COD) = 2) Or (CInt(COD) = 3) Then

        'Return "Esta Clase de Impuesto, No se puede eliminar"
        'End If
        Me.Conectar()
        Try
            ComenzarTransaccion()
            Me.querystring = "DELETE Form_Ayud WHERE FOAY_CODI='" + CODI + "'"
            CrearComando(querystring)
            na = EjecutarComando()
            Me.Msg = MsgOk + " # Registros Eliminados:" + na.ToString
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
        Dim queryString As String = "SELECT * FROM Form_Ayud ORDER BY FOAY_CODI"
        CrearComando(queryString)
        Dim dataTb As DataTable = EjecutarConsultaDataTable()
        Me.Desconectar()
        Return dataTb

    End Function
    <DataObjectMethodAttribute(DataObjectMethodType.Select, True)> _
    Public Overloads Function GetPorFdCo(ByVal FdCo As String) As DataTable
        Me.Conectar()
        Dim queryString As String = "SELECT * FROM Form_Ayud Where foay_fdco=:foay_fdco ORDER BY FOAY_CODI"
        CrearComando(UCase(queryString))
        AsignarParametroCadena(":FOAY_FDCO", FdCo)
        Dim dataTb As DataTable = EjecutarConsultaDataTable()
        Me.Desconectar()
        Return dataTb

    End Function
    <DataObjectMethodAttribute(DataObjectMethodType.Select, True)> _
    Public Overloads Function GetPorCod(ByVal Cod As String) As DataTable
        Me.Conectar()
        Dim queryString As String = "SELECT * FROM Form_Ayud WHERE FOAY_CODI=:FOAY_CODI"
        CrearComando(queryString)
        AsignarParametroCadena(":FOAY_CODI", Cod)
        Dim dataTb As DataTable = EjecutarConsultaDataTable()
        Me.Desconectar()
        Return dataTb

    End Function

End Class
