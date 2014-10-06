Imports Microsoft.VisualBasic
Imports System.Data
Imports System.ComponentModel
Imports System

'Clase para manejar la Tabla Tramites de la Base de datos
'Fecha Creaciòn: 03 dic 2009
'Autor: Ronal Javier

Public Class TRAMITES
    Inherits BDDatos2
    '---------------------------------------------------------------------------------------------------------------
    ' Funciòn Insert: Agrega datos a la tabla Tramites
    ' Parametros: TRAM_Codi : Còdigo
    '             TRAM_Nomb : nombre del parametro
    '              TRAM_RESP: Responsable
    '             TRAM_GSAN: Genera sancion
    '             TRAM_COSA: Codigo de sancion
    '             TRAM_PLAN: Plantilla

    Public Function Insert(ByVal TRAM_CODI As String, ByVal TRAM_NOMB As String, ByVal TRAM_RESP As String, _
                           ByVal TRAM_GSAN As String, ByVal TRAM_COSA As String, ByVal TRAM_PLAN As String, _
                           ByVal TRAM_PROC As String, ByVal TRAM_TIDO As String, ByVal TRAM_AUTO As String, _
                           ByVal TRAM_DIAS As String, ByVal TRAM_TIPO As String, ByVal TRAM_VFREB As String, _
                           ByVal TRAM_TPRO As String) As String

        Dim na As Integer
        Me.Conectar()
        Try
            ComenzarTransaccion()
            Me.querystring = "INSERT INTO TRAMITES (TRAM_CODI,TRAM_NOMB,TRAM_RESP,TRAM_GSAN,TRAM_COSA,TRAM_PLAN,TRAM_PROC,TRAM_USAP, TRAM_TIDO, TRAM_AUTO, TRAM_DIAS, TRAM_TIPO, TRAM_VFREB, TRAM_TPRO) " & _
            " VALUES(:TRAM_CODI,:TRAM_NOMB,:TRAM_RESP,:TRAM_GSAN,:TRAM_COSA,:TRAM_PLAN,:TRAM_PROC,:TRAM_USAP, :TRAM_TIDO, :TRAM_AUTO, :TRAM_DIAS, :TRAM_TIPO, :TRAM_VFREB, :TRAM_TPRO)"
            CrearComando(querystring)
            AsignarParametroCadena(":TRAM_CODI", TRAM_CODI)
            AsignarParametroCadena(":TRAM_NOMB", TRAM_NOMB)
            AsignarParametroCadena(":TRAM_RESP", TRAM_RESP)
            AsignarParametroCadena(":TRAM_GSAN", TRAM_GSAN)
            AsignarParametroCadena(":TRAM_COSA", TRAM_COSA)
            AsignarParametroCadena(":TRAM_PLAN", TRAM_PLAN)
            AsignarParametroCadena(":TRAM_PROC", TRAM_PROC)
            AsignarParametroCadena(":TRAM_USAP", Me.usuario)
            AsignarParametroCadena(":TRAM_TIDO", TRAM_TIDO)
            AsignarParametroCadena(":TRAM_AUTO", TRAM_AUTO)
            AsignarParametroCadena(":TRAM_DIAS", TRAM_DIAS)
            AsignarParametroCadena(":TRAM_TIPO", TRAM_TIPO)
            AsignarParametroCadena(":TRAM_VFREB", TRAM_VFREB)
            AsignarParametroCadena(":TRAM_TPRO", TRAM_TPRO)

            'Me.usuario

            na = EjecutarComando()
            ConfirmarTransaccion()
            Me.Msg = MsgOk + "<BR> Número de Filas Afectadas " + na.ToString
            Me.lErrorG = False
        Catch ex As Exception
            Me.lErrorG = True
            Me.Msg = "Error de App:" + ex.Message
            CancelarTransaccion()
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

    Public Function Update(ByVal TRAM_CODI_OR As String, ByVal TRAM_CODI As String, ByVal TRAM_NOMB As String, _
                           ByVal TRAM_RESP As String, ByVal TRAM_GSAN As String, ByVal TRAM_COSA As String, _
                           ByVal TRAM_PLAN As String, ByVal TRAM_PROC As String, ByVal TRAM_TIDO As String, _
                           ByVal TRAM_AUTO As String, ByVal TRAM_DIAS As String, ByVal TRAM_TIPO As String, _
                           ByVal TRAM_VFREB As String, ByVal TRAM_TPRO As String) As String
        Dim na As String
        Me.Conectar()
        Try
            Me.querystring = "UPDATE TRAMITES SET TRAM_CODI='" & TRAM_CODI & "',TRAM_NOMB='" & TRAM_NOMB & "',TRAM_RESP='" & TRAM_RESP & "',TRAM_GSAN='" & TRAM_GSAN & "',TRAM_COSA='" & TRAM_COSA & _
            "',TRAM_PLAN='" & TRAM_PLAN & "',TRAM_PROC='" & TRAM_PROC & "', TRAM_TIDO='" & TRAM_TIDO & "', TRAM_AUTO='" & TRAM_AUTO & "', TRAM_DIAS= '" & TRAM_DIAS & "', TRAM_TIPO= '" & TRAM_TIPO & _
            "', TRAM_VFREB='" & TRAM_VFREB & "', TRAM_TPRO = '" & TRAM_TPRO & _
            "' WHERE TRAM_CODI='" & TRAM_CODI_OR & "' "
            CrearComando(querystring)
            na = EjecutarComando()
            ConfirmarTransaccion()
            Me.Msg = MsgOk + "<BR> Registros Actualizados [" + na + "]"

            Me.lErrorG = False
        Catch ex As Exception
            Me.lErrorG = True
            Me.Msg = "Error de App:" + ex.Message
            CancelarTransaccion()
        Finally
            Me.Desconectar()
        End Try

        Return Msg
    End Function
    ' Funciòn Delete: Borra datos a la tabla Tramites
    ' Parametros: TRAM_Codi : Còdigo
    '             TRAM_Nomb : nombre del parametro
    '              TRAM_RESP: Responsable
    '             TRAM_GSAN: Genera sancion
    '             TRAM_COSA: Codigo de sancion
    '             TRAM_PLAN: Plantilla

    Public Function Delete(ByVal CODI As String) As String
        Dim na As String

        'If (CInt(COD) = 1) Or (CInt(COD) = 2) Or (CInt(COD) = 3) Then

        'Return "Esta Clase de Impuesto, No se puede eliminar"
        'End If
        Me.Conectar()
        Try
            ComenzarTransaccion()
            Me.querystring = "DELETE TRAMITES WHERE TRAM_CODI='" + CODI + "'"
            CrearComando(querystring)
            na = EjecutarComando()
            ConfirmarTransaccion()
            Me.Msg = MsgOk + " # Registros Eliminados:" + na.ToString
            Me.lErrorG = False
        Catch ex As Exception
            Me.lErrorG = True
            Me.Msg = "Error de App:" + ex.Message
            CancelarTransaccion()
        Finally
            Me.Desconectar()
        End Try
        Return Msg
    End Function

    <DataObjectMethodAttribute(DataObjectMethodType.Select, True)> _
    Public Overrides Function GetRecords() As DataTable
        Me.Conectar()
        Me.querystring = "SELECT * FROM VTRAMITES ORDER BY TRAM_NOMB"
        CrearComando(querystring)
        Dim dataTb As DataTable = EjecutarConsultaDataTable()
        Me.Desconectar()
        Return dataTb
    End Function

    <DataObjectMethodAttribute(DataObjectMethodType.Select, True)> _
    Public Overloads Function GetPorCod(ByVal Cod As String) As DataTable
        Me.Conectar()
        Me.querystring = "SELECT * FROM TRAMITES WHERE TRAM_CODI=:TRAM_CODI"
        CrearComando(querystring)
        AsignarParametroCadena(":TRAM_CODI", Cod)
        Dim dataTb As DataTable = EjecutarConsultaDataTable()
        Me.Desconectar()
        Return dataTb
    End Function

    <DataObjectMethodAttribute(DataObjectMethodType.Select, True)> _
Public Overloads Function GetPorNombre(ByVal TRAM_NOMB As String) As DataTable
        Me.Conectar()
        Me.querystring = "SELECT * FROM TRAMITES WHERE (TRAM_NOMB like '%" + TRAM_NOMB + "%') OR (upper(TRAM_NOMB) like '%" + UCase(TRAM_NOMB) + "%') ORDER BY TRAM_NOMB"
        CrearComando(querystring)
        Dim dataTb As DataTable = EjecutarConsultaDataTable()
        Me.Desconectar()
        Return dataTb
    End Function

    <DataObjectMethodAttribute(DataObjectMethodType.Select, True)> _
    Public Overloads Function GetPorProc(ByVal TRAM_PROC As String) As DataTable
        Me.Conectar()
        Me.querystring = "SELECT * FROM TRAMITES WHERE TRAM_PROC=:TRAM_PROC"
        CrearComando(querystring)
        AsignarParametroCadena(":TRAM_PROC", TRAM_PROC)
        Dim dataTb As DataTable = EjecutarConsultaDataTable()
        Me.Desconectar()
        Return dataTb
    End Function

    <DataObjectMethodAttribute(DataObjectMethodType.Select, True)> _
    Public Overloads Function GetPorTipoDoc(ByVal TRAM_TIDO As String) As DataTable
        Me.Conectar()
        Me.querystring = "SELECT * FROM TRAMITES WHERE TRAM_TIDO=:TRAM_TIDO"
        CrearComando(querystring)
        AsignarParametroCadena(":TRAM_TIDO", TRAM_TIDO)
        Dim dataTb As DataTable = EjecutarConsultaDataTable()
        Me.Desconectar()
        Return dataTb
    End Function
End Class
