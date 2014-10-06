Imports Microsoft.VisualBasic
Imports System.ComponentModel
Imports System.Data
Imports System.Collections.Generic

Public Class Pplantillas
    Inherits BDDatos2
    Public Function ActualizaPlantilla(ByVal IDE_PLA As String, ByVal DocByte As [Byte]()) As String
        Conectar()
        ComenzarTransaccion()
        Try
            querystring = "UPDATE PPLANTILLAS SET PLANTILLA=:PLANTILLA WHERE IDE_PLA=:IDE_PLA"
            CrearComando(querystring)
            AsignarParametroBLOB(":PLANTILLA", DocByte)
            AsignarParametroCadena(":IDE_PLA", IDE_PLA)
            num_reg = EjecutarComando()
            Me.Msg = MsgOk + "<BR> Número de Filas Afectadas " + num_reg.ToString
            ConfirmarTransaccion()
            Me.lErrorG = False
        Catch ex As Exception
            CancelarTransaccion()
            Msg = ex.Message
            Me.lErrorG = True
        End Try
        Return Msg
    End Function

    <DataObjectMethodAttribute(DataObjectMethodType.Select, True)> _
    Public Function GetPorIde(ByVal IDE_PLA As String) As DataTable
        Me.Conectar()
        Me.querystring = "SELECT * FROM PPLANTILLAS WHERE IDE_PLA = :IDE_PLA"
        CrearComando(querystring)
        AsignarParametroCadena(":IDE_PLA", IDE_PLA)
        Dim dataTb As DataTable = EjecutarConsultaDataTable()
        Me.Desconectar()
        Return dataTb
    End Function

    <DataObjectMethodAttribute(DataObjectMethodType.Select, True)> _
    Public Overrides Function GetRecords() As DataTable
        Me.Conectar()
        Me.querystring = "SELECT * FROM PPLANTILLAS"
        CrearComando(querystring)
        Dim dataTb As DataTable = EjecutarConsultaDataTable()
        Me.Desconectar()
        Return dataTb
    End Function

    <DataObjectMethodAttribute(DataObjectMethodType.Select, True)> _
    Public Function GetPorTipo(ByVal TIP_PLA As String) As DataTable
        Me.Conectar()
        Me.querystring = "SELECT * FROM PPLANTILLAS WHERE TIP_PLA = :TIP_PLA"
        CrearComando(querystring)
        AsignarParametroCadena(":TIP_PLA", TIP_PLA)
        Dim dataTb As DataTable = EjecutarConsultaDataTable()
        Me.Desconectar()
        Return dataTb
    End Function

    <DataObjectMethodAttribute(DataObjectMethodType.Select, True)> _
    Public Function GetPorTramiteImpuesto(ByVal TRAM_CODI As String, ByVal PLAN_CDEC As String) As DataTable
        Me.Conectar()
        Me.querystring = "SELECT * FROM PPLANTILLAS WHERE TRAM_CODI = :TRAM_CODI AND PLAN_CDEC = :PLAN_CDEC"
        CrearComando(querystring)
        AsignarParametroCadena(":TRAM_CODI", TRAM_CODI)
        AsignarParametroCadena(":PLAN_CDEC", PLAN_CDEC)
        Dim dataTb As DataTable = EjecutarConsultaDataTable()
        Me.Desconectar()
        Return dataTb
    End Function

    <DataObjectMethodAttribute(DataObjectMethodType.Select, True)> _
    Public Function GetCampos() As DataTable
        Me.Conectar()
        Me.querystring = "SELECT * FROM PPLANTILLAS_CAMPOS"
        CrearComando(querystring)
        Dim dataTb As DataTable = EjecutarConsultaDataTable()
        Me.Desconectar()
        Return dataTb
    End Function

    <DataObjectMethodAttribute(DataObjectMethodType.Select, True)> _
    Public Overloads Function GetCamposPorIde(ByVal IDE_PLA As String) As DataTable
        Me.Conectar()
        Me.querystring = "SELECT * FROM PPLANTILLAS_CAMPOS WHERE IDE_PLA=:IDE_PLA"
        CrearComando(querystring)
        AsignarParametroCadena(":IDE_PLA", IDE_PLA)
        Dim dataTb As DataTable = EjecutarConsultaDataTable()
        Me.Desconectar()
        Return dataTb
    End Function

    <DataObjectMethodAttribute(DataObjectMethodType.Select, True)> _
    Public Function GetDatosPlantilla(ByVal Nom_Vista As String, ByVal numExpediente As String, ByVal docAdministrativo As String, ByVal IdExpeTram As String) As DataTable
        Dim dataTb As New DataTable
        Dim oExpe As New Expedientes
        dataTb = oExpe.GetImprimirExpedienteByIde(Nom_Vista, numExpediente, docAdministrativo, IdExpeTram)
        Return dataTb

    End Function

    <DataObjectMethodAttribute(DataObjectMethodType.Select, True)> _
    Public Function GetDatosPlantillaPorProceso(ByVal codTramite As String, ByVal numProceso As String) As DataTable
        Dim dataTb As New DataTable

        Dim oExpe As New Expedientes
        dataTb = oExpe.GetImprimirExpedienteByProceso(numProceso)

        Return dataTb

    End Function

    Public Function GetFormatoTabla(ByVal nomTabla As String, ByVal idPlantilla As String) As DataTable
        Me.Conectar()
        Me.querystring = "SELECT * FROM PPLANTILLAS_FORMATO_TABLAS WHERE IDE_PLA=:IDE_PLA AND NTABLA=:NTABLA"
        CrearComando(querystring)
        AsignarParametroCadena(":IDE_PLA", idPlantilla)
        AsignarParametroCadena(":NTABLA", nomTabla)
        Dim dataTb As DataTable = EjecutarConsultaDataTable()
        Me.Desconectar()
        Return dataTb
    End Function

    Public Function GetFormatoTabla(ByVal nomTabla As String, ByVal idPlantilla As String, ByVal NomCampo As String) As DataTable
        Me.Conectar()
        Me.querystring = "SELECT * FROM PPLANTILLAS_FORMATO_TABLAS WHERE IDE_PLA=:IDE_PLA AND NTABLA=:NTABLA AND NOM_CAM =:NOM_CAM"
        CrearComando(querystring)
        AsignarParametroCadena(":IDE_PLA", idPlantilla)
        AsignarParametroCadena(":NTABLA", nomTabla)
        AsignarParametroCadena(":NOM_CAM", NomCampo)
        Dim dataTb As DataTable = EjecutarConsultaDataTable()
        Me.Desconectar()
        Return dataTb
    End Function
End Class
