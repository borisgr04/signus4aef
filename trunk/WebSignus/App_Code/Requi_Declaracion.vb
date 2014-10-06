Imports Microsoft.VisualBasic
Imports System.ComponentModel
Imports System.Data
'Clase para manejar la Tabla Requi_Declaracion de la Base de datos
'Fecha Creaciòn: 28 dic 2009
'Autor: Ronal Javier

Public Class Requi_Declaracion
    Inherits BDDatos2
    '---------------------------------------------------------------------------------------------------------------
    ' Funciòn Insert: Agrega datos a la tabla Requi_Declaracion

    Public Function Insert(ByVal REQ_CLDEC As String, ByVal REQ_COD As String, ByVal REQ_DESC As String, ByVal REQ_FINI As Date, ByVal REQ_FFIN As Date) As String

        Dim na As Integer
        Me.Conectar()
        Try
            ComenzarTransaccion()
            Me.querystring = "INSERT INTO Requi_Declaracion (REQ_CLDEC,REQ_COD,REQ_DESC,REQ_FINI,REQ_FFIN,REQ_USAP)VALUES(:REQ_CLDEC,:REQ_COD,:REQ_DESC,:REQ_FINI,:REQ_FFIN,:REQ_USAP)"
            CrearComando(querystring)
            AsignarParametroCadena(":REQ_CLDEC", REQ_CLDEC)
            AsignarParametroCadena(":REQ_COD", REQ_COD)
            AsignarParametroCadena(":REQ_DESC", REQ_DESC)
            AsignarParametroFecha(":REQ_FINI", REQ_FINI)
            AsignarParametroFecha(":REQ_FFIN", REQ_FFIN)
            AsignarParametroCadena(":REQ_USAP", Me.usuario)
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
    ' Funciòn Actualizar: Acatualiza datos a la tabla Requi_Declaracion
    '    
    Public Function Update(ByVal REQ_COD_OR As String, ByVal REQ_CLDEC As String, ByVal REQ_COD As String, ByVal REQ_DESC As String, ByVal fec_ini As Date, ByVal fec_fin As Date) As String
        Dim na As String
        Me.Conectar()
        Try
            ComenzarTransaccion()
            Me.querystring = "UPDATE Requi_Declaracion SET REQ_COD='" + REQ_COD + "',REQ_DESC='" + REQ_DESC + "',REQ_FINI=to_date('" + fec_ini.ToShortDateString + "','dd/mm/yyyy'),REQ_FFIN=to_date('" + fec_fin.ToShortDateString + "','dd/mm/yyyy') WHERE REQ_COD='" + REQ_COD_OR + "' And REQ_CLDEC='" + REQ_CLDEC + "'"
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
    'Funciòn Delete: elimina datos a la tabla Requi_Declaracion
    ' Parametros: Tcta_Codi : Còdigo

    Public Function Delete(ByVal REQ_COD As String, ByVal REC_CLDEC As String) As String
        Dim na As String

        'If (CInt(COD) = 1) Or (CInt(COD) = 2) Or (CInt(COD) = 3) Then

        'Return "Esta Clase de Impuesto, No se puede eliminar"
        'End If
        Me.Conectar()
        Try
            ComenzarTransaccion()

            Me.querystring = "DELETE REQUI_DECLARACION WHERE REQ_COD='" + REQ_COD + "' AND REQ_CLDEC='" + REC_CLDEC + "'"
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
        Dim queryString As String = "SELECT * FROM Requi_Declaracion ORDER BY REQ_CLDEC,REQ_COD"
        CrearComando(queryString)
        Dim dataTb As DataTable = EjecutarConsultaDataTable()
        Me.Desconectar()
        Return dataTb

    End Function
    <DataObjectMethodAttribute(DataObjectMethodType.Select, True)> _
    Public Overloads Function GetPorCod(ByVal REQ_COD As String, ByVal REQ_CDEC As String) As DataTable
        Me.Conectar()
        Dim queryString As String = "SELECT * FROM Requi_Declaracion WHERE REQ_COD=:REQ_COD AND REQ_CLDEC=:REQ_CLDEC"
        CrearComando(queryString)
        AsignarParametroCadena(":REQ_COD", REQ_COD)
        AsignarParametroCadena(":REQ_CLDEC", REQ_CDEC)
        Dim dataTb As DataTable = EjecutarConsultaDataTable()
        Me.Desconectar()
        Return dataTb

    End Function



End Class
