Imports Microsoft.VisualBasic
Imports System.Data
Imports System.ComponentModel
'Tabla Actualizada el dia 9 de dic 2009
'Ronal

Public Class Consecutivos2
    Inherits BDDatos2

    Public Function Insert(ByVal CONS_VIG As String, ByVal CONS_ID As String, ByVal CONS_NOM As String, ByVal CONS_PRX As Decimal, ByVal CONS_INI As Decimal) As String
        Dim na As String
        Me.Conectar()
        Try
            ComenzarTransaccion()
            Me.querystring = "INSERT INTO Consecutivos (CONS_VIG,CONS_ID,CONS_NOM,CONS_PRX,CONS_INI)VALUES(:CONS_VIG,:CONS_ID,:CONS_NOM,:CONS_PRX,:CONS_INI)"
            CrearComando(querystring)
            AsignarParametroCadena(":CONS_VIG", CONS_VIG)
            AsignarParametroCadena(":CONS_ID", CONS_ID)
            AsignarParametroCadena(":CONS_NOM", CONS_NOM)
            AsignarParametroDecimal(":CONS_PRX", CONS_PRX)
            AsignarParametroDecimal(":CONS_INI", CONS_INI)
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
    Public Function Update(ByVal CONS_ID_OR As String, ByVal CONS_VIG As String, ByVal CONS_ID As String, ByVal CONS_NOM As String, ByVal CONS_PRX As String, ByVal CONS_INI As String) As String
        Dim na As String
        Me.Conectar()
        Try
            ComenzarTransaccion()
            Me.querystring = "UPDATE Consecutivos SET CONS_VIG='" + CONS_VIG + "',CONS_NOM='" + CONS_NOM + "',CONS_PRX=" + CONS_PRX + ",CONS_INI=" + CONS_INI + " WHERE CONS_ID='" + CONS_ID_OR + "' "
            CrearComando(querystring)
            na = EjecutarComando()
            Me.Msg = MsgOk + " Registros Actualizados [" + na + "]"
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

    Public Function Delete(ByVal ID As String) As String
        Dim na As String
        Me.Conectar()
        Try
            ComenzarTransaccion()

            Me.querystring = "DELETE Consecutivos WHERE CONS_ID=" + ID + " "
            CrearComando(querystring)
            na = EjecutarComando()
            Me.Msg = MsgOk + " # Filas Eliminadas:" + na.ToString
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
        Dim queryString As String = "SELECT * FROM CONSECUTIVOS ORDER BY CONS_ID"
        CrearComando(queryString)
        Dim dataTb As DataTable = EjecutarConsultaDataTable()
        Me.Desconectar()
        Return dataTb
    End Function
    <DataObjectMethodAttribute(DataObjectMethodType.Select, True)> _
    Public Overloads Function GetPorCod(ByVal Cod As String) As DataTable
        Me.Conectar()
        Dim queryString As String = "SELECT * FROM CONSECUTIVOS WHERE CONS_ID=:CONS_ID"
        CrearComando(queryString)
        AsignarParametroCadena(":CONS_ID", Cod)
        Dim dataTb As DataTable = EjecutarConsultaDataTable()
        Me.Desconectar()
        Return dataTb
    End Function
	
    'Agregado Shirly
	
	
End Class