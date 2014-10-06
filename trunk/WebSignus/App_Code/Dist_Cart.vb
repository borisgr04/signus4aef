Imports Microsoft.VisualBasic
Imports System.Data
Imports System.ComponentModel
Imports System

'Clase para manejar la Tabla Dist_Cart de la Base de datos
'Fecha Creaciòn: 09 dic 2009
'Autor: Ronal Javier

Public Class Dist_Cart
    Inherits BDDatos2
    '---------------------------------------------------------------------------------------------------------------
    ' Funciòn Insert: Agrega datos a la tabla Dist_Cart

    Public Function Insert(ByVal DICA_CDEC As String, ByVal DICA_CODD As String, ByVal DICA_CODC As String, ByVal DICA_FDCO As String, ByVal DICA_ORDE As String) As String

        Dim na As Integer
        Me.Conectar()
        Try
            ComenzarTransaccion()
            Me.querystring = "INSERT INTO Dist_Cart (DICA_CDEC,DICA_CODD,DICA_CODC,DICA_FDCO,DICA_ORDE,DICA_USAP)VALUES(:DICA_CDEC,:DICA_CODD,:DICA_CODC,:DICA_FDCO,:DICA_ORDE,:DICA_USAP)"
            CrearComando(querystring)
            AsignarParametroCadena(":DICA_CDEC", DICA_CDEC)
            AsignarParametroCadena(":DICA_CODD", DICA_CODD)
            AsignarParametroCadena(":DICA_CODC", DICA_CODC)
            AsignarParametroCadena(":DICA_FDCO", DICA_FDCO)
            AsignarParametroCadena(":DICA_ORDE", DICA_ORDE)
            AsignarParametroCadena("DICA_USAP", Me.usuario)
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
    ' Funciòn Actualizar: Actualiza datos a la tabla Dist_Cart

    Public Function Update(ByVal DICA_CDEC_or As String, ByVal DICA_CODD_or As String, ByVal DICA_CODC_or As String, ByVal DICA_CDEC As String, ByVal DICA_CODD As String, ByVal DICA_CODC As String, ByVal DICA_FDCO As String, ByVal DICA_ORDE As String) As String
        Dim na As String
        Me.Conectar()
        Try
            ComenzarTransaccion()
            Me.querystring = "UPDATE Dist_Cart SET DICA_CDEC='" + DICA_CDEC + "',DICA_CODD='" + DICA_CODD + "',DICA_CODC='" + DICA_CODC + "',DICA_FDCO='" + DICA_FDCO + "',DICA_ORDE='" + DICA_ORDE + "' WHERE DICA_CDEC='" + DICA_CDEC_or + "'AND DICA_CODD='" + DICA_CODD_or + "' AND DICA_CODC='" + DICA_CODC_or + "'"
            CrearComando(querystring)
            na = EjecutarComando()
            Me.Msg = MsgOk + "<BR> Registros Actualizados [" + na + "]"
            ConfirmarTransaccion()
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
    ' Funciòn Delete: Borra datos a la tabla Dist_Cart

    Public Function Delete(ByVal COD As String, ByVal CODD As String, ByVal CODC As String) As String
        Dim na As String

        'If (CInt(COD) = 1) Or (CInt(COD) = 2) Or (CInt(COD) = 3) Then

        'Return "Esta Clase de Impuesto, No se puede eliminar"
        'End If
        Me.Conectar()
        Try
            ComenzarTransaccion()
            Me.querystring = "DELETE Dist_Cart WHERE DICA_CDEC='" + COD + "'AND DICA_CODD='" + CODD + "' AND DICA_CODC='" + CODC + "'"
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
        Dim queryString As String = "SELECT * FROM Dist_Cart ORDER BY DICA_CDEC,DICA_CODD,DICA_CODC"
        CrearComando(queryString)
        Dim dataTb As DataTable = EjecutarConsultaDataTable()
        Me.Desconectar()
        Return dataTb
    End Function
    <DataObjectMethodAttribute(DataObjectMethodType.Select, True)> _
    Public Overloads Function GetPorCod(ByVal Cod As String, ByVal CODD As String, ByVal CODC As String) As DataTable
        Me.Conectar()
        Dim queryString As String = "SELECT * FROM Dist_Cart WHERE DICA_CDEC=:DICA_CDEC AND DICA_CODD=:DICA_CODD AND DICA_CODC=:DICA_CODC"
        CrearComando(queryString)
        AsignarParametroCadena(":DICA_CDEC", Cod)
        AsignarParametroCadena(":DICA_CODD", CODD)
        AsignarParametroCadena(":DICA_CODC", CODC)
        Dim dataTb As DataTable = EjecutarConsultaDataTable()
        Me.Desconectar()
        Return dataTb
    End Function
End Class