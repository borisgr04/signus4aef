Imports Microsoft.VisualBasic
Imports System.Data
Imports System.Data.Common
Imports System.ComponentModel

Public Class Consecutivos
    Inherits BDDatos2
    Public Function Insert(ByVal CONS_VIG As String, ByVal CONS_ID As String, ByVal CONS_NOM As String, ByVal CONS_PRX As Decimal, ByVal CONS_INI As Decimal) As String

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
            num_reg = EjecutarComando()
            ConfirmarTransaccion()
            Me.Msg = MsgOk + "<BR> Número de Filas Afectadas " + num_reg.ToString
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
    Public Function Update(ByVal CONS_ID_OR As String, ByVal CONS_VIG As String, ByVal CONS_ID As String, ByVal CONS_NOM As String, ByVal CONS_PRX As String, ByVal CONS_INI As String) As String

        Me.Conectar()
        Try
            ComenzarTransaccion()
            Me.querystring = "UPDATE Consecutivos SET CONS_VIG='" + CONS_VIG + "',CONS_NOM='" + CONS_NOM + "',CONS_PRX=" + CONS_PRX + ",CONS_INI=" + CONS_INI + " WHERE CONS_ID='" + CONS_ID_OR + "' "
            CrearComando(querystring)
            num_reg = EjecutarComando()
            ConfirmarTransaccion()
            Me.Msg = MsgOk + " Registros Actualizados [" + num_reg.ToString + "]"
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

    Public Function Delete(ByVal ID As String) As String

        Me.Conectar()
        Try
            ComenzarTransaccion()
            Me.querystring = "DELETE Consecutivos WHERE CONS_ID=" + ID + " "
            CrearComando(querystring)
            num_reg = EjecutarComando()
            ConfirmarTransaccion()
            Me.Msg = MsgOk + " # Filas Eliminadas:" + num_reg.ToString
            Me.lErrorG = False
        Catch exo As BDSProvider.BaseDatosException
            CancelarTransaccion()
            Me.lErrorG = True
            Me.Msg = "Error de Datos:" + exo.Message
        Catch ex As Exception
            CancelarTransaccion()
            Me.lErrorG = True
            Me.Msg = "Error de App:" + ex.Message
        Finally
            Me.Desconectar()
        End Try
        Return Msg
    End Function




    '<DataObjectMethodAttribute(DataObjectMethodType.Select, True)> _
    Public Function GetParametros(ByVal CONS_VIG As String) As DataTable
        Me.Conectar()
        Me.querystring = "SELECT * FROM CONSECUTIVOS Where CONS_VIG=:CONS_VIG ORDER BY CONS_ID"
        CrearComando(querystring)
        AsignarParametroCadena("CONS_VIG", CONS_VIG)
        Dim dataTb As DataTable = EjecutarConsultaDataTable()
        Me.Desconectar()
        Return dataTb
    End Function

    'GetConsec(Nom Varchar2, Vig Varchar2)

    Public Function GetConsecEx(ByVal Nom As String, ByVal vig As String) As String

        Me.querystring = "GetConsec"
        CrearComando(querystring, CommandType.StoredProcedure)
        ' Consecutivo
        Dim pReturn As DbParameter = AsignarParametroReturn(100)
        AsignarParametroCad("Nom", Nom)
        AsignarParametroCad("Vig", vig)
        EjecutarComando()

        Return pReturn.Value.ToString()
    End Function
    Public Function GetConsec(ByVal Nom As String, ByVal vig As String) As String
        Me.Conectar()
        Me.querystring = "GetConsec"
        CrearComando(querystring, CommandType.StoredProcedure)
        ' Consecutivo
        Dim pReturn As DbParameter = AsignarParametroReturn(100)
        AsignarParametroCad("Nom", Nom)
        AsignarParametroCad("Vig", vig)
        EjecutarComando()
        'Me.Desconectar()
        Return pReturn.Value.ToString()
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
	 Public Function Get_Consec(ByVal Nom As String, ByVal vig As String) As String
        Me.querystring = "GetConsec"
        CrearComando(querystring, CommandType.StoredProcedure)
        ' Consecutivo
        Dim pReturn As DbParameter = AsignarParametroReturn(100)
        AsignarParametroCad("Nom", Nom)
        AsignarParametroCad("Vig", vig)
        EjecutarComando()
        Return pReturn.Value.ToString()
    End Function
	
	
End Class
