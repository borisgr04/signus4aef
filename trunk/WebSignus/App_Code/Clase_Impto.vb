Imports Microsoft.VisualBasic

Imports System.Data
Imports System.ComponentModel

Public Class Clase_Impto
    Inherits BDDatos2

    Public Function Insert(ByVal NOM As String, ByVal FEIN As Date, ByVal FEFI As Date) As String
        Dim na As Integer
        Me.Conectar()
        Try
            ComenzarTransaccion()
            Me.querystring = "INSERT INTO CLASE_IMPTO (CLIM_CODI,CLIM_NOMB,CLIM_FEIN,CLIM_FEFI)VALUES(:CLIM_CODI,:CLIM_NOMB,to_date('" + FEIN.ToShortDateString + "','dd/mm/yyyy'),to_date('" + FEFI.ToShortDateString + "','dd/mm/yyyy'))"
            CrearComando(querystring)
            AsignarParametroCadena(":CLIM_CODI", Me.GenCons())
            AsignarParametroCadena(":CLIM_NOMB", NOM)

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
    Public Function Update(ByVal COD As String, ByVal NOM As String, ByVal fec_ini As Date, ByVal fec_fin As Date) As String
        Dim x As String
        Me.Conectar()
        Try
            ComenzarTransaccion()
            Me.querystring = "UPDATE CLASE_IMPTO SET CLIM_NOMB='" + NOM + "',CLIM_FEIN=to_date('" + fec_ini.ToShortDateString + "','dd/mm/yyyy'),CLIM_FEFI=to_date('" + fec_fin.ToShortDateString + "','dd/mm/yyyy') WHERE CLIM_CODI='" + COD + "' "
            CrearComando(querystring)
            x = EjecutarComando()
            Me.Msg = MsgOk + "<BR> Registros Actualizados [" + x + "]"
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

    Public Function Delete(ByVal COD As String) As String
        Dim x As String
        Me.Conectar()
        Try
            ComenzarTransaccion()
            Me.querystring = "DELETE CLASE_IMPTO WHERE CLIM_CODI='" + COD + "'"
            CrearComando(querystring)
            x = EjecutarComando()
            Me.Msg = MsgOk + " # Registros Eliminados:" + x.ToString
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
        Dim queryString As String = "SELECT * FROM vCLASE_IMPTO ORDER BY CLIM_CODI"
        CrearComando(queryString)
        Dim dataTb As DataTable = EjecutarConsultaDataTable()
        Me.Desconectar()
        Return dataTb
    End Function

    <DataObjectMethodAttribute(DataObjectMethodType.Select, True)> _
    Public Overloads Function GetPorCod(ByVal Cod As String) As DataTable
        Me.Conectar()
        Dim queryString As String = "SELECT * FROM vCLASE_IMPTO WHERE CLIM_CODI=:CLIM_CODI"
        CrearComando(queryString)
        AsignarParametroCadena(":CLIM_CODI", Cod)
        Dim dataTb As DataTable = EjecutarConsultaDataTable()
        Me.Desconectar()
        Return dataTb

    End Function
    Private Overloads Function UltID() As String
        Dim datat As New Data.DataTable
        'Me.Conectar
        Dim queryString As String = "SELECT max(clim_codi) FROM CLASE_IMPTO"
        CrearComando(queryString)
        Dim r As String = Convert.ToString(EjecutarEscalar())
        'Me.Desconectar()
        Return r
    End Function

    Public Function GenCons() As String

        Dim c As Integer, cod As String
        c = CInt(UltID()) + 1
        cod = c.ToString.PadLeft(2, "0")
        Return cod
    End Function
End Class

