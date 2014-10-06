Imports Microsoft.VisualBasic

Imports System.Data
Imports System.ComponentModel
'Clase para manejar la Tabla Conc_Cart de la Base de datos
'Fecha Creaciòn: 07 dic 2009
'Autor: Ronal Javier

Public Class Conc_Cart
    Inherits BDDatos2
    '---------------------------------------------------------------------------------------------------------------
    ' Funciòn Insert: Agrega datos a la tabla Conc_Cart

    Public Function Insert(ByVal CCAR_COD As String, ByVal CCAR_AVCO As String, ByVal CCAR_NOM As String, ByVal CCAR_TICO As String, ByVal CCAR_CDEC As String) As String

        Dim na As Integer
        Me.Conectar()
        Try
            ComenzarTransaccion()
            Me.querystring = "INSERT INTO Conc_Cart (CCAR_COD,CCAR_AVCO,CCAR_NOM,CCAR_TICO,CCAR_CDEC,CCAR_USAP)VALUES(:CCAR_COD,:CCAR_AVCO,:CCAR_NOM,:CCAR_TICO,:CCAR_CDEC,:CCAR_USAP)"
            CrearComando(querystring)
            AsignarParametroCadena(":CCAR_COD", CCAR_COD)
            AsignarParametroCadena(":CCAR_AVCO", CCAR_AVCO)
            AsignarParametroCadena(":CCAR_NOM", CCAR_NOM)
            AsignarParametroCadena(":CCAR_TICO", CCAR_TICO)
            AsignarParametroCadena(":CCAR_CDEC", CCAR_CDEC)
            AsignarParametroCadena(":CCAR_USAP", Me.usuario)
            'Me.usuario
            na = EjecutarComando()
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
    Public Function Update(ByVal CCAR_COD_OR As String, ByVal CCAR_COD As String, ByVal CCAR_AVCO As String, ByVal CCAR_NOM As String, ByVal CCAR_TICO As String, ByVal CCAR_CDEC As String) As String
        Dim na As String
        Me.Conectar()
        Try
            ComenzarTransaccion()
            Me.querystring = "UPDATE Conc_Cart SET CCAR_COD='" + CCAR_COD + "',CCAR_AVCO='" + CCAR_AVCO + "',CCAR_NOM='" + CCAR_NOM + "',CCAR_TICO='" + CCAR_TICO + "',CCAR_CDEC='" + CCAR_CDEC + "' WHERE CCAR_COD='" + CCAR_COD_OR + "'"
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
    Public Function Delete(ByVal COD As String) As String
        Dim na As String

        'If (CInt(COD) = 1) Or (CInt(COD) = 2) Or (CInt(COD) = 3) Then

        'Return "Esta Clase de Impuesto, No se puede eliminar"
        'End If
        Me.Conectar()
        Try
            ComenzarTransaccion()

            Me.querystring = "DELETE Conc_Cart WHERE CCAR_COD='" + COD + "'"
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
        Dim queryString As String = "SELECT * FROM vConc_Cart ORDER BY CCAR_COD"
        CrearComando(queryString)
        Dim dataTb As DataTable = EjecutarConsultaDataTable()
        Me.Desconectar()
        Return dataTb
    End Function
    <DataObjectMethodAttribute(DataObjectMethodType.Select, True)> _
    Public Overloads Function GetPorCod(ByVal Cod As String) As DataTable
        Me.Conectar()
        Dim queryString As String = "SELECT * FROM vConc_Cart WHERE CCAR_COD=:CCAR_COD"
        CrearComando(queryString)
        AsignarParametroCadena(":CCAR_COD", Cod)
        Dim dataTb As DataTable = EjecutarConsultaDataTable()
        Me.Desconectar()
        Return dataTb
    End Function
    <DataObjectMethodAttribute(DataObjectMethodType.Select, True)> _
    Public Function GetPorCDEC(ByVal CCAR_CDEC As String) As DataTable
        Me.Conectar()
        Dim queryString As String = "SELECT * FROM vConc_Cart WHERE CCAR_Cdec=:CCAR_CDEC"
        CrearComando(queryString)
        AsignarParametroCadena(":CCAR_CDEC", CCAR_CDEC)
        Dim dataTb As DataTable = EjecutarConsultaDataTable()
        Me.Desconectar()
        Return dataTb
    End Function
End Class
