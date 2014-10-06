Imports Microsoft.VisualBasic
Imports System.Data
Imports System.ComponentModel
'Clase para manejar la Tabla Cta_Banco de la Base de datos
'Fecha Creaciòn: 09 dic 2009
'Autor: Ronal Javier

Public Class Cta_Banco
    Inherits BDDatos2
    '---------------------------------------------------------------------------------------------------------------
    ' Funciòn Insert: Agrega datos a la tabla Cta_Banco

    Public Function Insert(ByVal CTA_BACO As String, ByVal CTA_NRO As String, ByVal CTA_TIP As String, ByVal CTA_CODBAR As String, ByVal CTA_EST As String, ByVal CTA_DESC As String, ByVal CTA_SUC As String) As String

        Dim na As Integer
        Me.Conectar()
        Try
            ComenzarTransaccion()
            Me.querystring = "INSERT INTO Cta_Banco (CTA_BACO,CTA_NRO,CTA_TIP,CTA_CODBAR,CTA_EST,CTA_DESC,CTA_SUC,CTA_USAP)VALUES(:CTA_BACO,:CTA_NRO,:CTA_TIP,:CTA_CODBAR,:CTA_EST,:CTA_DESC,:CTA_SUC,:CTA_USAP)"
            CrearComando(querystring)
            AsignarParametroCadena(":CTA_BACO", CTA_BACO)
            AsignarParametroCadena(":CTA_NRO", CTA_NRO)
            AsignarParametroCadena(":CTA_TIP", CTA_TIP)
            AsignarParametroCadena(":CTA_CODBAR", CTA_CODBAR)
            AsignarParametroCadena(":CTA_EST", CTA_EST)
            AsignarParametroCadena(":CTA_DESC", CTA_DESC)
            AsignarParametroCadena(":CTA_SUC", CTA_SUC)
            AsignarParametroCadena(":CTA_USAP", "12345")
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
    ' Funciòn Actualizar: Actualiza datos a la tabla Cta_Banco

    Public Function Update(ByVal CTA_BACO_or As String, ByVal CTA_NRO_or As String, ByVal CTA_BACO As String, ByVal CTA_NRO As String, ByVal CTA_TIP As String, ByVal CTA_CODBAR As String, ByVal CTA_EST As String, ByVal CTA_DESC As String, ByVal CTA_SUC As String) As String
        Dim na As String
        Me.Conectar()
        Try
            ComenzarTransaccion()
            Me.querystring = "UPDATE Cta_Banco SET CTA_BACO='" + CTA_BACO + "',CTA_NRO='" + CTA_NRO + "',CTA_TIP='" + CTA_TIP + "',CTA_CODBAR='" + CTA_CODBAR + "',CTA_EST='" + CTA_EST + "',CTA_DESC='" + CTA_DESC + "',CTA_SUC='" + CTA_SUC + "' WHERE CTA_BACO='" + CTA_BACO_or + "' AND CTA_NRO='" + CTA_NRO_or + "'"
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
    ' Funciòn Delete: Borra datos a la tabla Cta_Banco

    Public Function Delete(ByVal CTA_BACO As String, ByVal CTA_NRO As String) As String
        Dim na As String

        'If (CInt(COD) = 1) Or (CInt(COD) = 2) Or (CInt(COD) = 3) Then

        'Return "Esta Clase de Impuesto, No se puede eliminar"
        'End If
        Me.Conectar()
        Try
            ComenzarTransaccion()

            Me.querystring = "DELETE Cta_Banco WHERE CTA_BACO='" + CTA_BACO + "'AND CTA_NRO='" + CTA_NRO + "'"
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
        Dim queryString As String = "SELECT * FROM Cta_Banco ORDER BY CTA_BACO, CTA_NRO"
        CrearComando(queryString)
        Dim dataTb As DataTable = EjecutarConsultaDataTable()
        Me.Desconectar()
        Return dataTb
    End Function
    <DataObjectMethodAttribute(DataObjectMethodType.Select, True)> _
    Public Overloads Function GetPorCod(ByVal Cod As String, ByVal NRO As String) As DataTable
        Me.Conectar()
        Dim queryString As String = "SELECT * FROM Cta_Banco WHERE CTA_BACO=:CTA_BACO AND CTA_NRO=:CTA_NRO"
        CrearComando(queryString)
        AsignarParametroCadena(":CTA_BACO", Cod)
        AsignarParametroCadena(":CTA_NRO", NRO)
        Dim dataTb As DataTable = EjecutarConsultaDataTable()
        Me.Desconectar()
        Return dataTb
    End Function
    <DataObjectMethodAttribute(DataObjectMethodType.Select, True)> _
    Public Overloads Function GetPorCodBan(ByVal Cod As String) As DataTable
        Me.Conectar()
        Dim queryString As String = "SELECT * FROM Cta_Banco WHERE CTA_BACO=:CTA_BACO "
        CrearComando(queryString)
        AsignarParametroCadena(":CTA_BACO", Cod)
        Dim dataTb As DataTable = EjecutarConsultaDataTable()
        Me.Desconectar()
        Return dataTb
    End Function
End Class
