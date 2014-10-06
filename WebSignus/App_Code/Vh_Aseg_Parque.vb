Imports Microsoft.VisualBasic
Imports System.ComponentModel
Imports System.Data

Public Class Vh_Aseg_Parque
    Inherits BDDatos2
    Public Cod_Aseg As String
    Public Placa As String
    Public Poliza As String
    Public Vencimiento As String

    Public Function Insert() As String
        Dim na As String

        Me.Conectar()
        Try
            ComenzarTransaccion()
            Me.querystring = "SELECT COD_ASEG FROM vh_aseg_parque WHERE COD_ASEG = :COD_ASEG AND PLACA = :PLACA AND NRO_POLIZA = :NRO_POLIZA AND VENCIMIENTO = :VENCIMIENTO"
            CrearComando(querystring)
            AsignarParametroCadena(":COD_ASEG", UCase(Cod_Aseg))
            AsignarParametroCadena(":PLACA", UCase(Placa))
            AsignarParametroCadena(":NRO_POLIZA", UCase(Poliza))
            AsignarParametroCadena(":VENCIMIENTO", UCase(Vencimiento))
            Dim dt As DataTable = EjecutarConsultaDataTable()
            If dt.Rows.Count = 0 Then
                Me.querystring = "INSERT INTO vh_aseg_parque(COD_ASEG, PLACA, NRO_POLIZA, VENCIMIENTO) "
                Me.querystring += " VALUES(:COD_ASEG, :PLACA, :NRO_POLIZA, :VENCIMIENTO)"
                CrearComando(querystring)
                AsignarParametroCadena(":COD_ASEG", UCase(Cod_Aseg))
                AsignarParametroCadena(":PLACA", UCase(Placa))
                AsignarParametroCadena(":NRO_POLIZA", UCase(Poliza))
                AsignarParametroCadena(":VENCIMIENTO", UCase(Vencimiento))
                na = EjecutarComando()
                Me.Msg = MsgOk + "<BR> Número de Filas Afectadas " + na.ToString
            End If
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
        Me.querystring = "SELECT * FROM vvh_aseg_parque ORDER BY NOM_ASEG"
        CrearComando(querystring)
        Dim dataTb As DataTable = EjecutarConsultaDataTable()

        Me.Desconectar()
        Return dataTb

    End Function
    <DataObjectMethodAttribute(DataObjectMethodType.Select, True)> _
    Public Function GetPorPlaca(ByVal PLACA As String) As DataTable
        Me.Conectar()
        Me.querystring = "SELECT * FROM vvh_aseg_parque WHERE PLACA = :PLACA"
        CrearComando(querystring)
        AsignarParametroCadena(":PLACA", UCase(PLACA))
        Dim dataTb As DataTable = EjecutarConsultaDataTable()

        Me.Desconectar()
        Return dataTb

    End Function
End Class
