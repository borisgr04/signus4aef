Imports Microsoft.VisualBasic
Imports System.ComponentModel
Imports System.Data

Public Class Vh_Aseguradora
    Inherits BDDatos2

    Public Function Insert(ByVal COD_ASEG As String, ByVal NOM_ASEG As String, ByVal EST_ASEG As String) As String
        Dim na As String

        Me.Conectar()
        Try
            ComenzarTransaccion()
            Me.querystring = "INSERT INTO VH_ASeguradora(NOM_ASEG, COD_ASEG, EST_ASEG) "
            Me.querystring += " VALUES(:NOM_ASEG, :COD_ASEG, :EST_ASEG)"
            CrearComando(querystring)
            AsignarParametroCadena(":NOM_ASEG", UCase(NOM_ASEG))
            AsignarParametroCadena(":COD_ASEG", UCase(COD_ASEG))
            AsignarParametroCadena(":EST_ASEG", UCase(EST_ASEG))
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

    Public Function Update(ByVal COD_ASEG As String, ByVal NOM_ASEG As String, ByVal EST_ASEG As String) As String
        Dim na As String

        Me.Conectar()
        Try
            ComenzarTransaccion()
            Me.querystring = "UPDATE VH_ASeguradora SET NOM_ASEG = :NOM_ASEG, EST_ASEG = :EST_ASEG WHERE COD_ASEG = :COD_ASEG"
            CrearComando(querystring)
            AsignarParametroCadena(":NOM_ASEG", UCase(NOM_ASEG))
            AsignarParametroCadena(":COD_ASEG", UCase(COD_ASEG))
            AsignarParametroCadena(":EST_ASEG", UCase(EST_ASEG))
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
        Me.querystring = "SELECT * FROM VH_ASeguradora ORDER BY NOM_ASEG"
        CrearComando(querystring)
        Dim dataTb As DataTable = EjecutarConsultaDataTable()

        Me.Desconectar()
        Return dataTb

    End Function
    <DataObjectMethodAttribute(DataObjectMethodType.Select, True)> _
    Public Function GetPorNombre(ByVal NOM_ASEG As String) As DataTable
        Me.Conectar()
        Me.querystring = "SELECT * FROM VH_ASeguradora WHERE upper(NOM_ASEG) like '%" + UCase(NOM_ASEG) + "%'"
        CrearComando(querystring)
        Dim dataTb As DataTable = EjecutarConsultaDataTable()

        Me.Desconectar()
        Return dataTb

    End Function
End Class
