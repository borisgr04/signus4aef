Imports Microsoft.VisualBasic
Imports System.Data
Imports System.ComponentModel
Imports System

'Clase para manejar la Tabla Formulaslt de la Base de datos
'Fecha Creaciòn: 09 dic 2009
'Autor: Ronal Javier

Public Class Formulaslt1
    Inherits BDDatos2
    '---------------------------------------------------------------------------------------------------------------
    ' Funciòn Insert: Agrega datos a la tabla Formulaslt

    Public Function Insert(ByVal FORM_CODI As String, ByVal FORM_FEIN As Date, ByVal FORM_FEFI As Date, ByVal FORM_FORM As String, ByVal FORM_NORM As String, ByVal FORM_CIMP As String) As String

        Dim na As Integer
        Me.Conectar()
        Try
            ComenzarTransaccion()
            Me.querystring = "INSERT INTO Formulaslt (FORM_CODI,FORM_FEIN,FORM_FEFI,FORM_FORM,FORM_NORM,FORM_CIMP,FORM_USAP)VALUES(:FORM_CODI,:FORM_FEIN,:FORM_FEFI,:FORM_FORM,:FORM_NORM,:FORM_CIMP,:FORM_USAP)"
            CrearComando(querystring)
            AsignarParametroCadena(":FORM_CODI", FORM_CODI)
            AsignarParametroFecha(":FORM_FEIN", FORM_FEIN)
            AsignarParametroFecha(":FORM_FEFI", FORM_FEFI)
            AsignarParametroCadena(":FORM_FORM", FORM_FORM)
            AsignarParametroCadena(":FORM_NORM", FORM_NORM)
            AsignarParametroCadena(":FORM_CIMP", FORM_CIMP)
            AsignarParametroCadena(":FORM_USAP", "12345")
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
    ' Funciòn Actualizar: Actualiza datos a la tabla Formulaslt

    Public Function Update(ByVal FORM_CODI_OR As String, ByVal FORM_CIMP_OR As String, ByVal FORM_CODI As String, ByVal FORM_CIMP As String, ByVal fec_ini As Date, ByVal fec_fin As Date, ByVal FORM_FORM As String, ByVal FORM_NORM As String) As String
        Dim na As String
        Me.Conectar()
        Try
            ComenzarTransaccion()
            Me.querystring = "UPDATE Formulaslt SET FORM_CODI='" + FORM_CODI + "',FORM_CIMP='" + FORM_CIMP + "', FORM_FEIN=to_date('" + fec_ini.ToShortDateString + "','dd/mm/yyyy'),FORM_FEFI=to_date('" + fec_fin.ToShortDateString + "','dd/mm/yyyy'),FORM_FORM='" + Trim(FORM_FORM) + "',FORM_NORM='" + FORM_NORM + "' WHERE FORM_CODI='" + FORM_CODI_OR + "' AND FORM_CIMP='" + FORM_CIMP_OR + "' "
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
    ' Funciòn Delete: Borra datos a la tabla Formulaslt

    Public Function Delete(ByVal FORM_CODI As String, ByVal FORM_CIMP As String) As String
        Dim na As String

        'If (CInt(COD) = 1) Or (CInt(COD) = 2) Or (CInt(COD) = 3) Then

        'Return "Esta Clase de Impuesto, No se puede eliminar"
        'End If
        Me.Conectar()
        Try
            ComenzarTransaccion()

            Me.querystring = "DELETE Formulaslt WHERE FORM_CODI='" + FORM_CODI + "'AND FORM_CIMP='" + FORM_CIMP + "'"
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
        Dim queryString As String = "SELECT * FROM vFormulaslt ORDER BY FORM_CODI , FORM_CIMP"
        CrearComando(queryString)
        Dim dataTb As DataTable = EjecutarConsultaDataTable()
        Me.Desconectar()
        Return dataTb

    End Function
    <DataObjectMethodAttribute(DataObjectMethodType.Select, True)> _
    Public Overloads Function GetPorCod(ByVal Cod As String, ByVal CIMP As String) As DataTable
        Me.Conectar()
        Dim queryString As String = "SELECT * FROM vFormulaslt WHERE FORM_CODI=:FORM_CODI AND FORM_CIMP=:FORM_CIMP Order by Form_Codi"
        CrearComando(queryString)
        AsignarParametroCadena(":FORM_CODI", Cod)
        AsignarParametroCadena(":FORM_CIMP", CIMP)
        Dim dataTb As DataTable = EjecutarConsultaDataTable()
        Me.Desconectar()
        Return dataTb

    End Function

End Class
