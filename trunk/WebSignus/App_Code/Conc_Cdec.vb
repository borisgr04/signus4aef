Imports Microsoft.VisualBasic

Imports System.Data
Imports System.ComponentModel
'Clase para manejar la Tabla Conc_Cdec de la Base de datos
'Fecha Creaciòn: 07 dic 2009
'Autor: Ronal Javier

Public Class Conc_Cdec
    Inherits BDDatos2
    '---------------------------------------------------------------------------------------------------------------
    ' Funciòn Insert: Agrega datos a la tabla Conc_Cdec
    ' Parametros: 


    Public Function Insert(ByVal COCD_CDEC As String, ByVal COCD_CODI As String, ByVal COCD_TICO As String, ByVal COCD_NOMB As String, ByVal COCD_REDE As String, ByVal COCD_TMOV As String, ByVal COCD_ABVB As String, ByVal COCD_VADE As String, ByVal COCD_ABVD As String, ByVal COCD_VACA As String, ByVal COCD_SECO As String, ByVal COCD_TARI As String, ByVal COCD_IMPTO As String, ByVal COCD_TSAN As String, ByVal COCD_CART As String, ByVal COCD_VABA As String, ByVal COCD_ISVB As String, ByVal COCD_OPER As String, ByVal COCD_CCAR As String, ByVal COCD_AÑSA As String, ByVal COCD_PESA As String, ByVal COCD_SUM As String, ByVal COCD_FDCO As String, ByVal COCD_CTAR As String, ByVal TIPO_TAR As Decimal, ByVal COCD_REVB As Decimal) As String

        Dim na As Integer
        Me.Conectar()
        Try
            ComenzarTransaccion()
            Me.querystring = "INSERT INTO Conc_Cdec (COCD_CDEC,COCD_CODI,COCD_TICO,COCD_NOMB,COCD_REDE,COCD_TMOV,COCD_ABVB,COCD_VADE,COCD_ABVD,COCD_VACA,COCD_SECO,COCD_TARI,COCD_IMPTO,COCD_TSAN,COCD_CART,COCD_VABA,COCD_ISVB,COCD_OPER,COCD_CCAR,COCD_AÑSA,COCD_PESA,COCD_SUM,COCD_FDCO,COCD_CTAR,TIPO_TAR,COCD_REVB)VALUES(:COCD_CDEC,:COCD_CODI,:COCD_TICO,:COCD_NOMB,:COCD_REDE,:COCD_TMOV,:COCD_ABVB,:COCD_VADE,:COCD_AVVD,:COCD_VACA,:COCD_SECO,:COCD_TARI,:COCD_IMPTO,:COCD_TSAN,:COCD_CART,:COCD_VABA,:COCD_ISVB,:COCD_OPER,:COCD_CCAR,:COCD_AÑSA,:COCD_PESA,:COCD_SUM,:COCD_FDCO,:COCD_CTAR,:TIPO_TAR,:COCD_REVB)"
            CrearComando(querystring)
            AsignarParametroCadena(":COCD_CDEC", COCD_CDEC)
            AsignarParametroCadena(":COCD_CODI", COCD_CODI)
            AsignarParametroCadena(":COCD_TICO", COCD_TICO)
            AsignarParametroCadena(":COCD_NOMB", COCD_NOMB)
            AsignarParametroCadena(":COCD_REDE", COCD_REDE)
            AsignarParametroCadena(":COCD_TMOV", COCD_TMOV)
            AsignarParametroCadena(":COCD_ABVB", COCD_ABVB)
            AsignarParametroCadena(":COCD_VADE", COCD_VADE)
            AsignarParametroCadena(":COCD_ABVD", COCD_ABVD)
            AsignarParametroCadena(":COCD_VACA", COCD_VACA)
            AsignarParametroCadena(":COCD_SECO", COCD_SECO)
            AsignarParametroCadena(":COCD_TARI", COCD_TARI)
            AsignarParametroCadena(":COCD_IMPTO", COCD_IMPTO)
            AsignarParametroCadena(":COCD_TSAN", COCD_TSAN)
            AsignarParametroCadena(":COCD_CART", COCD_CART)
            AsignarParametroCadena(":COCD_VABA", COCD_VABA)
            AsignarParametroCadena(":COCD_ISVB", COCD_ISVB)
            AsignarParametroCadena(":COCD_OPER", COCD_OPER)
            AsignarParametroCadena(":COCD_CCAR", COCD_CCAR)
            AsignarParametroCadena(":COCD_AÑSA", COCD_AÑSA)
            AsignarParametroCadena(":COCD_PESA", COCD_PESA)
            AsignarParametroCadena(":COCD_SUM", COCD_SUM)
            AsignarParametroCadena(":COCD_FDCO", COCD_FDCO)
            AsignarParametroCadena(":COCD_CTAR", COCD_CTAR)
            AsignarParametroDecimal(":TIPO_TAR", TIPO_TAR)
            AsignarParametroDecimal(":COCD_REVB", COCD_REVB)
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
    ' Funciòn Actualizar: Actualiza datos a la tabla Tramites
    ' Parametros: TRAM_Codi : Còdigo
    '             TRAM_Nomb : nombre del parametro
    '              TRAM_RESP: Responsable
    '             TRAM_GSAN: Genera sancion
    '             TRAM_COSA: Codigo de sancion
    '             TRAM_PLAN: Plantilla

    Public Function Update(ByVal COCD_FDCO_O As String, ByVal COCD_CODI_O As String, ByVal COCD_CDEC As String, ByVal COCD_CODI As String, ByVal COCD_TICO As String, ByVal COCD_NOMB As String, ByVal COCD_REDE As String, ByVal COCD_TMOV As String, ByVal COCD_ABVB As String, ByVal COCD_ABVD As String, ByVal COCD_VACA As String, ByVal COCD_SECO As String, ByVal COCD_TARI As String, ByVal COCD_IMPTO As String, ByVal COCD_TSAN As String, ByVal COCD_CART As String, ByVal COCD_VABA As String, ByVal COCD_ISVB As String, ByVal COCD_OPER As String, ByVal COCD_CCAR As String, ByVal COCD_AÑSA As String, ByVal COCD_PESA As String, ByVal COCD_SUM As String, ByVal COCD_FDCO As String, ByVal COCD_CTAR As String, ByVal TIPO_TAR As Decimal, ByVal cocd_revb As Decimal) As String
        Dim na As String
        Me.Conectar()
        Try

            ComenzarTransaccion()
            Me.querystring = "UPDATE Conc_Cdec SET COCD_CDEC='" + COCD_CDEC + "',COCD_CODI='" + COCD_CODI + "',COCD_TICO='" + COCD_TICO + "',COCD_NOMB='" + COCD_NOMB + "',COCD_REDE='" + COCD_REDE + "',COCD_TMOV='" + COCD_TMOV + "',COCD_ABVB='" + COCD_ABVB + "' ,COCD_ABVD='" + COCD_ABVD + "',COCD_VACA='" + COCD_VACA + "',COCD_SECO='" + COCD_SECO + "',COCD_TARI='" + COCD_TARI + "',COCD_IMPTO='" + COCD_IMPTO + "',COCD_TSAN='" + COCD_TSAN + "',COCD_CART='" + COCD_CART + "',COCD_VABA='" + COCD_VABA + "',COCD_ISVB='" + COCD_ISVB + "',COCD_OPER='" + COCD_OPER + "',COCD_CCAR='" + COCD_CCAR + "',COCD_AÑSA='" + COCD_AÑSA + "',COCD_PESA='" + COCD_PESA + "',COCD_SUM='" + COCD_SUM + "',COCD_FDCO='" + COCD_FDCO + "',COCD_CTAR='" + COCD_CTAR + "',TIPO_TAR=" + TIPO_TAR.ToString + ",COCD_REVB=" + CStr(cocd_revb) + " WHERE COCD_CODI='" + COCD_CODI_O + "' AND  COCD_FDCO='" + COCD_FDCO_O + "' "
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

        Return Me.Msg
    End Function
    ' Funciòn Delete: Borra datos a la tabla Tramites
    ' Parametros: TRAM_Codi : Còdigo
    '             TRAM_Nomb : nombre del parametro
    '              TRAM_RESP: Responsable
    '             TRAM_GSAN: Genera sancion
    '             TRAM_COSA: Codigo de sancion
    '             TRAM_PLAN: Plantilla

    Public Function Delete(ByVal CODI As String, ByVal FDCO As String) As String
        Dim na As String

        'If (CInt(COD) = 1) Or (CInt(COD) = 2) Or (CInt(COD) = 3) Then

        'Return "Esta Clase de Impuesto, No se puede eliminar"
        'End If
        Me.Conectar()
        Try
            ComenzarTransaccion()

            Me.querystring = "DELETE Conc_Cdec WHERE COCD_CODI='" + CODI + "'AND COCD_FDCO='" + FDCO + "'"
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
        Dim queryString As String = "SELECT * FROM Conc_Cdec ORDER BY COCD_CODI AND COCD_FDCO"
        CrearComando(queryString)
        Dim dataTb As DataTable = EjecutarConsultaDataTable()
        Me.Desconectar()
        Return dataTb
    End Function

    <DataObjectMethodAttribute(DataObjectMethodType.Select, True)> _
    Public Overloads Function GetConceptos(ByVal Conc_Fode As String, Optional ByVal Filtro As String = "") As DataTable
        Me.Conectar()
        Dim queryString As String = "SELECT * FROM Conc_Cdec WHERE Cocd_FDCO=:Cocd_FDCO " + Filtro + " Order by CoCd_Codi"
        CrearComando(queryString)
        AsignarParametroCadena(":Cocd_FDCO", Conc_Fode)
        Dim dataTb As DataTable = EjecutarConsultaDataTable()
        Me.Desconectar()
        Return dataTb
    End Function

    <DataObjectMethodAttribute(DataObjectMethodType.Select, True)> _
    Public Overloads Function GetPorCod(ByVal Cod As String, ByVal FDCO As String) As DataTable
        Me.Conectar()
        Dim queryString As String = "SELECT * FROM Conc_Cdec WHERE COCD_CODI=:COCD_CODI AND COCD_FDCO=:COCD_FDCO"
        CrearComando(queryString)
        AsignarParametroCadena(":COCD_CODI", Cod)
        AsignarParametroCadena(":COCD_FDCO", FDCO)
        Dim dataTb As DataTable = EjecutarConsultaDataTable()
        Me.Desconectar()
        Return dataTb
    End Function
End Class
