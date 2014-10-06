Imports Microsoft.VisualBasic
Imports System.ComponentModel
Imports System.Data

Public Class Vh_Linea
    Inherits BDDatos2

    Public Function Insert(ByVal NOM_LINEA As String, ByVal ID_VH_MARCA As String) As String
        Dim na As String

        Me.Conectar()
        Try
            ComenzarTransaccion()
            Me.querystring = "INSERT INTO VH_LINEA(NOM_LINEA, ID_VH_MARCA) "
            Me.querystring += " VALUES(:NOM_LINEA, :ID_VH_MARCA)"
            CrearComando(querystring)
            AsignarParametroCadena(":NOM_LINEA", UCase(NOM_LINEA))
            AsignarParametroCadena(":ID_VH_MARCA", UCase(ID_VH_MARCA))
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

    Public Function Update(ByVal NOM_LINEA_OLD As String, ByVal NOM_LINEA_NEW As String) As String
        Dim na As String

        Me.Conectar()
        Try
            ComenzarTransaccion()
            Me.querystring = "UPDATE VH_MARCA SET NOM_LINEA = :NOM_LINEA_NEW WHERE NOM_LINEA = :NOM_LINEA_OLD"
            CrearComando(querystring)
            AsignarParametroCadena(":NOM_LINEA_OLD", UCase(NOM_LINEA_OLD))
            AsignarParametroCadena(":NOM_LINEA_NEW", UCase(NOM_LINEA_NEW))
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

    <DataObjectMethodAttribute(DataObjectMethodType.Select, True)> _
    Public Overrides Function GetRecords() As DataTable
        Me.Conectar()
        Me.querystring = "SELECT * FROM VH_LINEA ORDER BY NOM_LINEA"
        CrearComando(querystring)
        Dim dataTb As DataTable = EjecutarConsultaDataTable()

        Me.Desconectar()
        Return dataTb

    End Function
    <DataObjectMethodAttribute(DataObjectMethodType.Select, True)> _
    Public Function GetPorNombre(ByVal NOM_LINEA As String, ByVal ID_VH_MARCA As String) As DataTable
        Me.Conectar()
        Me.querystring = "SELECT * FROM VH_LINEA WHERE ID_VH_MARCA = :ID_VH_MARCA AND upper(NOM_LINEA) like '%" + UCase(NOM_LINEA) + "%'"
        CrearComando(querystring)
        AsignarParametroCadena(":ID_VH_MARCA", ID_VH_MARCA)
        Dim dataTb As DataTable = EjecutarConsultaDataTable()

        Me.Desconectar()
        Return dataTb

    End Function
End Class
