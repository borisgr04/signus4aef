Imports Microsoft.VisualBasic
Imports System.Data
Imports System.ComponentModel
Imports System

'Clase para manejar la Tabla Entidad de la Base de datos
'Fecha Creaciòn: 09 dic 2009
'Autor: Ronal Javier

Public Class Entidad
    Inherits BDDatos2
    ' Funciòn Actualizar: Actualiza datos a la tabla Entidad

    Public Function Update(ByVal ENT_NIT_or As String, ByVal ENT_NIT As String, ByVal ENT_NOM As String, ByVal ENT_DIR As String, ByVal ENT_TEL As String, ByVal ENT_EMAIL As String, ByVal ENT_DPTO As String, ByVal ENT_MPIO As String, ByVal ENT_CEDRES As String, ByVal ENT_NOMRES As String, ByVal ENT_LOGO As String) As String
        Dim na As String
        Me.Conectar()
        'ComenzarTransaccion()

        Try
            Me.querystring = "UPDATE Entidad SET ENT_NIT='" + ENT_NIT + "',ENT_NOM='" + ENT_NOM + "',ENT_DIR='" + ENT_DIR + "',ENT_TEL='" + ENT_TEL + "',ENT_EMAIL='" + ENT_EMAIL + "',ENT_DPTO='" + ENT_DPTO + "',ENT_MPIO='" + ENT_MPIO + "',ENT_CEDRES='" + ENT_CEDRES + "',ENT_NOMRES='" + ENT_NOMRES + "',ENT_LOGO ='" + ENT_LOGO + "' WHERE ENT_NIT='" + ENT_NIT_or + "'"
            CrearComando(querystring)
            na = EjecutarComando()
            Me.Msg = MsgOk + "<BR> Registros Actualizados [" + na + "]"
            'ConfirmarTransaccion()
            Me.lErrorG = False
        Catch ex As Exception
            'CancelarTransaccion()
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
        Dim queryString As String = "SELECT * FROM Entidad ORDER BY ENT_NIT"
        CrearComando(queryString)
        Dim dataTb As DataTable = EjecutarConsultaDataTable()
        Me.Desconectar()
        Return dataTb

    End Function
    <DataObjectMethodAttribute(DataObjectMethodType.Select, True)> _
    Public Overloads Function GetPorCod(ByVal Cod As String) As DataTable
        Me.Conectar()
        Dim queryString As String = "SELECT * FROM Entidad WHERE ENT_NIT=:ENT_NIT"
        CrearComando(queryString)
        AsignarParametroCadena(":ENT_NIT", Cod)
        Dim dataTb As DataTable = EjecutarConsultaDataTable()
        Me.Desconectar()
        Return dataTb

    End Function

End Class
