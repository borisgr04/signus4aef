Imports Microsoft.VisualBasic
Imports System.Data
Imports System.ComponentModel
Imports System.Collections.Generic
Imports System.Data.Common
Imports System.Data.Common.DbParameter

Public Class Expedientes
    Inherits BDDatos2

    Public ExpePerido As String = ""
    Public CodTramiteActual As String = ""
    Public FechaIni As String = ""
    Public FechaFin As String = ""
    Public NumExpeIni As String = ""
    Public NumExpeFin As String = ""
    Public CodImpuesto As String = ""
    Public CodProceso As String = ""
    Public Nit As String = ""

    Public Function Insert(ByVal proceso As String, ByVal impuesto As String, _
                           ByVal Observacion As String, ByVal NitOmiso As String, ByVal tramite As String) As String

        querystring = "NUEVO_EXPEDIENTE"
        Dim na As Integer
        Dim nProceso As String
        Dim nNumExpe As String

        Try
            Me.Conectar()
            ComenzarTransaccion()
            nProceso = "0"
            nNumExpe = GenConsecutivo()
            If lErrorG = False Then
                CrearComando(querystring, CommandType.StoredProcedure)
                AsignarParametroCad("P_NPROCESO", nProceso)
                AsignarParametroCad("P_PROCESO", proceso)
                AsignarParametroCad("P_TRAMITE", tramite)
                AsignarParametroCad("P_NIT", NitOmiso)
                AsignarParametroCad("P_IMPUESTO", impuesto)
                AsignarParametroCad("P_OBSERVACION", Observacion)
                AsignarParametroCad("P_USUARIO_AP", Membership.GetUser().UserName)
                AsignarParametroCad("P_NUM_EXPE", nNumExpe)
                na = EjecutarComando()
            Else
                lErrorG = True
            End If

            Doc = nNumExpe
            lErrorG = False
            ConfirmarTransaccion()
        Catch ex As Exception
            CancelarTransaccion()
            lErrorG = True
            Msg = "Error de App: " + ex.Message
        Finally
            Me.Desconectar()
        End Try

        Return Msg
    End Function

    Public Function GenConsecutivo() As String
        Dim numExp As String
        Dim oConsecutivo As New Consecutivos
        Dim oVig As New Vigencias
        Dim vigencia As String
        vigencia = oVig.GetActiva()
        oConsecutivo.Conexion = Me.Conexion
        numExp = oConsecutivo.GetConsec("EXPEDIENTES", "")
        numExp = vigencia + numExp.PadLeft(8, "0")

        Return numExp

    End Function

    Public Function GenerarExpediente(ByVal proceso As String, ByVal impuesto As String, _
                                               ByVal dtPeriodos As DataTable, ByVal Observacion As String, _
                                                   ByVal consecutivo As Integer, ByVal Nit As String, ByVal tramite As String) As String
        Dim dtConsulta As New DataTable
        Dim encontrado As Boolean
        encontrado = False

        'Verificar que Los periodos no se le hayan creado expedientes

        For i As Integer = 0 To dtPeriodos.Rows.Count - 1
            Dim oApg As New Expe_Apg
            If oApg.ExistePeriodosEnExpediente(dtPeriodos.Rows(i)("PERIODO").ToString, dtPeriodos.Rows(i)("VIGENCIA").ToString, impuesto, Nit) Then
                Doc = oApg.Doc
                encontrado = True
                Exit For
            End If
        Next
        If Not encontrado Then
            'Crear el expediente
            Dim numExpe As String
            Insert(proceso, impuesto, Observacion, Nit, tramite)
            numExpe = Doc

            If Not lErrorG Then
                Dim oTram As New Expe_Tram
                oTram.Insert(numExpe, "-1", tramite, consecutivo, Observacion)
                For i As Integer = 0 To dtPeriodos.Rows.Count - 1
                    Dim oApg As New Expe_Apg
                    oApg.Insert(numExpe, dtPeriodos.Rows(i)("PERIODO").ToString, dtPeriodos.Rows(i)("VIGENCIA").ToString, impuesto, Observacion, Nit)
                Next
                Msg = "Se Genero el Expediente " + numExpe
            End If
        Else
            lErrorG = True
            ExpePerido = Doc
            Msg = "Uno o Mas Periodos de los escogidos tienen creado ya un Expediente " + Doc
        End If
        Return Msg
    End Function

    Public Function GenerarExpedienteOmiso(ByVal proceso As String, ByVal impuesto As String, _
                                               ByVal Vig_Ini As String, ByVal Vig_Fin As String, ByVal Per_Ini As String, _
                                                   ByVal Per_Fin As String, ByVal Observacion As String, _
                                                   ByVal consecutivo As String, ByVal dtOmisos As DataTable) As String

        querystring = "GENERAR_EXPEDIENTE_OMISOS"
        Dim na As Integer
        Dim oCons As New Consecutivos
        Dim nProceso As String

        Try
            Me.Conectar()
            ComenzarTransaccion()
            oCons.Conexion = Me.Conexion
            nProceso = oCons.GetConsec("PROCESOS", "")
            If Val(consecutivo) < 0 Then
                consecutivo = "0"
            End If
            For i As Integer = 0 To dtOmisos.Rows.Count - 1
                If lErrorG = False Then
                    CrearComando(querystring, CommandType.StoredProcedure)
                    Dim pReturn As DbParameter
                    pReturn = AsignarParametroReturn(10)
                    AsignarParametroCad("P_NPROCESO", nProceso)
                    AsignarParametroCad("P_PROCESO", proceso)
                    AsignarParametroCad("P_TRAMITE", "010101")
                    AsignarParametroCad("P_NIT", dtOmisos.Rows(i)("TER_NIT").ToString)
                    AsignarParametroCad("P_IMPUESTO", impuesto)
                    AsignarParametroCad("P_VIG_INI", Vig_Ini)
                    AsignarParametroCad("P_VIG_FIN", Vig_Fin)
                    AsignarParametroFecha("P_PER_INI", CDate(Per_Ini))
                    AsignarParametroFecha("P_PER_FIN", CDate(Per_Fin))
                    AsignarParametroCad("P_NUM_DOC", consecutivo)
                    AsignarParametroCad("P_OBSERVACION", Observacion)
                    AsignarParametroCad("P_USUARIO_AP", Membership.GetUser().UserName)
                    na = EjecutarComando()
                    consecutivo = Val(pReturn.Value.ToString)
                    consecutivo = consecutivo + 1
                Else
                    lErrorG = True
                    Exit For
                End If
            Next
            Doc = nProceso
            lErrorG = False
            ConfirmarTransaccion()
        Catch ex As Exception
            CancelarTransaccion()
            lErrorG = True
            Msg = "Error de App: " + ex.Message
        Finally
            Me.Desconectar()
        End Try

        Return Msg

    End Function

    Public Function GenerarExpedienteOmiso(ByVal proceso As String, ByVal impuesto As String, _
                                            ByVal Vig_Ini As String, ByVal Vig_Fin As String, ByVal Per_Ini As String, _
                                                ByVal Per_Fin As String, ByVal Observacion As String, _
                                                ByVal consecutivo As String, ByVal ListOmisos As ArrayList) As String

        querystring = "GENERAR_EXPEDIENTE_OMISOS2"
        Dim na As Integer
        Dim oCons As New Consecutivos
        Dim nProceso As String

        Try
            Me.Conectar()
            ComenzarTransaccion()
            oCons.Conexion = Me.Conexion
            nProceso = oCons.GetConsecEx("PROCESOS", "")
            If Val(consecutivo) < 0 Then
                consecutivo = "0"
            End If
            For i As Integer = 0 To ListOmisos.Count - 1
                If lErrorG = False Then
                    CrearComando(querystring, CommandType.StoredProcedure)
                    Dim pReturn As DbParameter
                    pReturn = AsignarParametroReturn(10)
                    AsignarParametroCad("P_NPROCESO", nProceso)
                    AsignarParametroCad("P_PROCESO", proceso)
                    AsignarParametroCad("P_TRAMITE", "010101")
                    AsignarParametroCad("P_NIT", ListOmisos.Item(i).ToString)
                    AsignarParametroCad("P_IMPUESTO", impuesto)
                    AsignarParametroCad("P_VIG_INI", Vig_Ini)
                    AsignarParametroCad("P_VIG_FIN", Vig_Fin)
                    AsignarParametroCad("P_PER_INI", Per_Ini)
                    AsignarParametroCad("P_PER_FIN", Per_Fin)
                    AsignarParametroCad("P_NUM_DOC", consecutivo)
                    AsignarParametroCad("P_OBSERVACION", Observacion)
                    AsignarParametroCad("P_USUARIO_AP", Membership.GetUser().UserName)
                    na = EjecutarComando()
                    consecutivo = Val(pReturn.Value.ToString)
                    consecutivo = consecutivo + 1
                Else
                    lErrorG = True
                    Exit For
                End If
            Next
            Doc = nProceso
            lErrorG = False
            ConfirmarTransaccion()
        Catch ex As Exception
            CancelarTransaccion()
            lErrorG = True
            Msg = "Error de App: " + ex.Message + ex.StackTrace.ToString
        Finally
            Me.Desconectar()
        End Try

        Return Msg

    End Function

    <DataObjectMethodAttribute(DataObjectMethodType.Select, True)> _
    Public Function GetExpediente(Optional ByVal numExpe As String = "", Optional ByVal numProceso As String = "", Optional ByVal NitoNombre As String = "", Optional ByVal proceso As String = "", Optional ByVal tramite As String = "") As DataTable
        Dim expresion As String
        Me.Conectar()
        expresion = ""

        If Not String.IsNullOrEmpty(numExpe) Then
            If String.IsNullOrEmpty(expresion) Then
                expresion = " WHERE EXPE_NUME = '" + numExpe + "'"
            Else
                expresion = expresion + " AND EXPE_NUME = '" + numExpe + "'"
            End If
        End If

        If Not String.IsNullOrEmpty(tramite) Then
            If String.IsNullOrEmpty(expresion) Then
                expresion = " WHERE EXPE_TRAC = '" + tramite + "'"
            Else
                expresion = expresion + " AND EXPE_TRAC = '" + tramite + "'"
            End If
        End If

        If Not String.IsNullOrEmpty(proceso) Then
            If String.IsNullOrEmpty(expresion) Then
                expresion = " WHERE EXPE_PROC = '" + proceso + "'"
            Else
                expresion = expresion + " AND EXPE_PROC = '" + proceso + "'"
            End If
        End If

        If Not String.IsNullOrEmpty(numProceso) Then
            If String.IsNullOrEmpty(expresion) Then
                expresion = " WHERE EXPE_NPRO = '" + numProceso + "'"
            Else
                expresion = expresion + " AND EXPE_NPRO = '" + numProceso + "'"
            End If
        End If
        If Not String.IsNullOrEmpty(NitoNombre) Then
            If String.IsNullOrEmpty(expresion) Then
                expresion = " WHERE "
            Else
                expresion = expresion + " AND "
            End If
            If IsNumeric(NitoNombre) Then
                expresion = expresion + " EXPE_NIT = '" + NitoNombre + "'"
            Else
                expresion = expresion + " TER_NOM LIKE '%" + NitoNombre + "%'"
            End If
        End If
        querystring = "SELECT * FROM VEXPEDIENTES " + expresion + " ORDER BY TO_NUMBER(EXPE_NUME), EXPE_FELA"
        CrearComando(querystring)
        Dim dataTb As DataTable = EjecutarConsultaDataTable()
        Me.Desconectar()

        Return dataTb

    End Function

    <DataObjectMethodAttribute(DataObjectMethodType.Select, True)> _
    Public Function GetByIde(ByVal numExpediente As String) As DataTable
        Dim dataTb As New DataTable
        Me.Conectar()
        Me.querystring = "SELECT * FROM VEXPEDIENTES WHERE expe_nume=:expe_nume"
        CrearComando(querystring)
        AsignarParametroCadena(":expe_nume", numExpediente)
        dataTb = EjecutarConsultaDataTable()
        Me.Desconectar()

        Return dataTb
    End Function

    <DataObjectMethodAttribute(DataObjectMethodType.Select, True)> _
    Public Function GetByIde(ByVal ListaNumExpe As List(Of String)) As DataTable
        Dim dataTb As New DataTable
        Dim lista As String

        lista = ""
        For i As Integer = 0 To ListaNumExpe.Count - 1
            If String.IsNullOrEmpty(lista) Then
                lista = "'" + ListaNumExpe(i) + "'"
            Else
                lista = lista + ", " + "'" + ListaNumExpe(i) + "'"
            End If
        Next
        Me.Conectar()
        Me.querystring = "SELECT * FROM VEXPEDIENTES WHERE expe_nume IN (" + lista + ")"
        CrearComando(querystring)
        ' AsignarParametroCadena(":expe_nume", lista)
        dataTb = EjecutarConsultaDataTable()
        Me.Desconectar()

        Return dataTb

    End Function

    <DataObjectMethodAttribute(DataObjectMethodType.Select, True)> _
    Public Function GetPorProceso(ByVal EXPE_NPRO As String) As DataTable
        Dim dataTb As New DataTable
        Me.Conectar()
        Me.querystring = "SELECT * FROM VEXPEDIENTES WHERE EXPE_NPRO = :EXPE_NPRO"
        CrearComando(querystring)
        AsignarParametroCadena(":EXPE_NPRO", EXPE_NPRO)
        dataTb = EjecutarConsultaDataTable()
        Me.Desconectar()

        Return dataTb

    End Function

    <DataObjectMethodAttribute(DataObjectMethodType.Select, True)> _
    Public Function GetPorNit(ByVal EXPE_NIT As String) As DataTable
        Dim dataTb As New DataTable
        Me.Conectar()
        Me.querystring = "SELECT * FROM VEXPEDIENTES WHERE EXPE_NIT = :EXPE_NIT"
        CrearComando(querystring)
        AsignarParametroCadena(":EXPE_NIT", EXPE_NIT)
        dataTb = EjecutarConsultaDataTable()
        Me.Desconectar()

        Return dataTb

    End Function

    <DataObjectMethodAttribute(DataObjectMethodType.Select, True)> _
    Public Function GetExpeVencidosGral() As DataTable
        Dim dataTb As New DataTable
        Me.Conectar()
        Me.querystring = "SELECT COUNT(EXPE_NUME) as TOTAL, TRAM_NOMB FROM VEXPEDIENTES WHERE EXPE_FEXP <= sysdate GROUP BY TRAM_NOMB"
        CrearComando(querystring)
        dataTb = EjecutarConsultaDataTable()
        Me.Desconectar()
        Return dataTb
    End Function

    <DataObjectMethodAttribute(DataObjectMethodType.Select, True)> _
    Public Function GetExpeVencidos() As DataTable
        Dim dataTb As New DataTable
        Me.Conectar()
        Me.querystring = "SELECT EXPE_NUME, TRAM_NOMB FROM VEXPEDIENTES WHERE EXPE_FEXP <= sysdate "
        CrearComando(querystring)
        dataTb = EjecutarConsultaDataTable()
        Me.Desconectar()
        Return dataTb
    End Function

    <DataObjectMethodAttribute(DataObjectMethodType.Select, True)> _
    Public Function GetExpeVencidos(ByVal TRAM_NOMB As String) As DataTable
        Dim dataTb As New DataTable
        Me.Conectar()
        Me.querystring = "SELECT EXPE_NUME, TRAM_NOMB FROM VEXPEDIENTES WHERE EXPE_FEXP <= sysdate AND TRAM_NOMB = :TRAM_NOMB ORDER BY TO_NUMBER(EXPE_NUME)"
        CrearComando(querystring)
        AsignarParametroCadena(":TRAM_NOMB", TRAM_NOMB)
        dataTb = EjecutarConsultaDataTable()
        Me.Desconectar()
        Return dataTb
    End Function

    <DataObjectMethodAttribute(DataObjectMethodType.Select, True)> _
    Public Function GetExpeSinNotificacion() As DataTable
        Dim dataTb As New DataTable
        Me.Conectar()
        Me.querystring = "SELECT COUNT(EXPE_NUME) AS TOTAL, TRAM_NOMB  FROM VEXPEDIENTES WHERE EXPE_FEXP IS NULL  GROUP BY  TRAM_NOMB"
        CrearComando(querystring)
        dataTb = EjecutarConsultaDataTable()
        Me.Desconectar()
        Return dataTb
    End Function

    <DataObjectMethodAttribute(DataObjectMethodType.Select, True)> _
    Public Function GetExpeSinNotificacion(ByVal TRAM_NOMB As String) As DataTable
        Dim dataTb As New DataTable
        Me.Conectar()
        Me.querystring = "SELECT EXPE_NUME, TRAM_NOMB  FROM VEXPEDIENTES WHERE EXPE_FEXP IS NULL AND TRAM_NOMB = :TRAM_NOMB ORDER BY TO_NUMBER(EXPE_NUME)"
        CrearComando(querystring)
        AsignarParametroCadena(":TRAM_NOMB", TRAM_NOMB)
        dataTb = EjecutarConsultaDataTable()
        Me.Desconectar()
        Return dataTb
    End Function

    <DataObjectMethodAttribute(DataObjectMethodType.Select, True)> _
    Public Function GetExpeAbiertos() As DataTable
        Dim dataTb As New DataTable
        Me.Conectar()
        Me.querystring = "SELECT COUNT(EXPE_NUME) AS TOTAL, TRAM_NOMB FROM VEXPEDIENTES WHERE EXPE_FCIE IS NULL  GROUP BY  TRAM_NOMB"
        CrearComando(querystring)
        dataTb = EjecutarConsultaDataTable()
        Me.Desconectar()
        Return dataTb
    End Function

    <DataObjectMethodAttribute(DataObjectMethodType.Select, True)> _
    Public Function GetListaOmisosSinExpedienteX(ByVal Per_Ini As String, ByVal Per_Fin As String, ByVal Vig_Ini As String, ByVal Vig_Fin As String, ByVal Impuesto As String, Optional ByVal Nit As String = "", Optional ByVal CodMpio As String = "") As DataTable
        Dim pIni1, pFin1 As String
        Dim oApg As New Expe_Apg
        Dim dataTb As New DataTable
        Me.Conectar()
        oApg.Conexion = Me.Conexion
        pIni1 = oApg.ConsPeriodo(Per_Ini, Impuesto, Vig_Ini)
        pFin1 = oApg.ConsPeriodo(Per_Fin, Impuesto, Vig_Fin)
        Me.querystring = "SELECT DISTINCT TER_NIT, TER_NOM, TER_MPIO FROM ("
        Me.querystring = Me.querystring + oApg.QueryApgSinExpediente(pIni1, pFin1, Vig_Ini, Vig_Fin, Impuesto, Nit, CodMpio) + ")"
        Me.querystring = Me.querystring + " ORDER BY TER_NOM "
        CrearComando(Me.querystring)
        dataTb = EjecutarConsultaDataTable()
        Me.Desconectar()
        Return dataTb
    End Function

    <DataObjectMethodAttribute(DataObjectMethodType.Select, True)> _
    Public Function GetListaOmisosSinExpediente(ByVal Per_Ini As String, ByVal Per_Fin As String, ByVal Vig_Ini As String, ByVal Vig_Fin As String, ByVal Impuesto As String, Optional ByVal Nit As String = "", Optional ByVal CodMpio As String = "", Optional Ter_Tip As String = "") As DataTable
        Dim dataTb As New DataTable
        Me.Conectar()
        Me.querystring = "SELECT DISTINCT TER_NIT, TER_NOM, TER_MPIO,TEr_Tip,Cant_Periodos FROM ("
        Me.querystring += "SELECT ter_nit, ter_nom,TER_MPIO,TEr_Tip,"
        Me.querystring += " fnesomiso (ter_nit, '" + Vig_Ini + "', '" + Per_Ini + "', '" + Vig_Fin + "', '" + Per_Fin + "','" + Impuesto + "') Cant_Periodos "
        Me.querystring += " FROM Terceros  WHERE ter_tus = 'AR' )"
        Me.querystring += " WHERE Cant_Periodos > 0 "
        If Not String.IsNullOrEmpty(Nit) Then
            Me.querystring += " AND TER_NIT = '" + Nit + "'"
        End If
        If Not String.IsNullOrEmpty(CodMpio) Then
            Me.querystring += " AND TER_MPIO = '" + CodMpio + "'"
        End If
        If Not String.IsNullOrEmpty(Ter_Tip) Then
            Me.querystring += " AND Ter_Tip = '" + Ter_Tip + "'"
        End If
        Me.querystring += " ORDER BY TER_NOM "
        CrearComando(Me.querystring)
        dataTb = EjecutarConsultaDataTable()
        Me.Desconectar()
        Return dataTb

    End Function

    
    <DataObjectMethodAttribute(DataObjectMethodType.Select, True)> _
    Public Function GetListaOmisosSinExpeVehiculo(ByVal Vig_Ini As String, ByVal Vig_Fin As String, ByVal Impuesto As String, Optional ByVal Nit As String = "", Optional ByVal CodMpioOp As String = "", Optional ByVal CodMpioMat As String = "") As DataTable
        Dim oApg As New Expe_Apg
        Dim dataTb As New DataTable
        Me.Conectar()
        oApg.Conexion = Me.Conexion
        Me.querystring = oApg.QueryApgSinExpeVehiculo(Vig_Ini, Vig_Fin, Impuesto, Nit, CodMpioOp, CodMpioOp)
        CrearComando(Me.querystring)
        dataTb = EjecutarConsultaDataTable()
        Me.Desconectar()
        Return dataTb

    End Function

    Public Function GetImprimirExpedienteByIde(ByVal EXPE_NUME As String) As DataTable
        Dim dataTb As New DataTable
        Me.Conectar()
        Me.querystring = "SELECT * FROM VIMPRIMIR_EXPEDIENTE WHERE EXPE_NUME=:EXPE_NUME"
        CrearComando(querystring)
        AsignarParametroCadena(":EXPE_NUME", EXPE_NUME)
        dataTb = EjecutarConsultaDataTable()
        Me.Desconectar()
        Return dataTb
    End Function

    Public Function GetImprimirExpedienteByIde(ByVal NOM_VISTA As String, ByVal EXPE_NUME As String, ByVal EXTR_DOAD As String, ByVal EXTR_ID As String) As DataTable
        Dim dataTb As New DataTable
        Dim nomCampo As String
        nomCampo = "EXTR_ID_" + EXTR_DOAD
        Me.Conectar()
        Me.querystring = "SELECT * FROM " + NOM_VISTA + " WHERE EXPE_NUME = :EXPE_NUME AND " + nomCampo + " = " + EXTR_ID
        CrearComando(querystring)
        AsignarParametroCadena(":EXPE_NUME", EXPE_NUME)
        dataTb = EjecutarConsultaDataTable()
        Me.Desconectar()
        Return dataTb
    End Function

    Public Function GetImprimirExpedienteByProceso(ByVal EXPE_NPRO As String) As DataTable
        Dim dataTb As New DataTable
        Me.Conectar()
        Me.querystring = "SELECT * FROM VIMPRIMIR_EXPEDIENTE WHERE EXPE_NPRO=:EXPE_NPRO"
        CrearComando(querystring)
        AsignarParametroCadena(":EXPE_NPRO", EXPE_NPRO)
        dataTb = EjecutarConsultaDataTable()
        Me.Desconectar()
        Return dataTb
    End Function

    <DataObjectMethodAttribute(DataObjectMethodType.Select, True)> _
   Public Function GetExpeParametrizado() As DataTable
        Dim expresion As String
        Me.Conectar()
        expresion = ""

        If Not String.IsNullOrEmpty(NumExpeIni) And Not String.IsNullOrEmpty(NumExpeFin) Then
            If String.IsNullOrEmpty(expresion) Then
                expresion = " WHERE EXPE_NUME BETWEEN '" + NumExpeIni + "' AND '" + NumExpeFin + "'"
            Else
                expresion = expresion + " AND EXPE_NUME BETWEEN '" + NumExpeIni + "' AND '" + NumExpeFin + "'"
            End If
        End If

        If Not String.IsNullOrEmpty(CodTramiteActual) Then
            If String.IsNullOrEmpty(expresion) Then
                expresion = " WHERE EXPE_TRAC = '" + CodTramiteActual + "'"
            Else
                expresion = expresion + " AND EXPE_TRAC = '" + CodTramiteActual + "'"
            End If
        End If

        If Not String.IsNullOrEmpty(CodProceso) Then
            If String.IsNullOrEmpty(expresion) Then
                expresion = " WHERE EXPE_PROC = '" + CodProceso + "'"
            Else
                expresion = expresion + " AND EXPE_PROC = '" + CodProceso + "'"
            End If
        End If

        If Not String.IsNullOrEmpty(Nit) Then
            If String.IsNullOrEmpty(expresion) Then
                expresion = " WHERE EXPE_NIT = '" + Nit + "'"
            Else
                expresion = expresion + " AND EXPE_NIT = '" + Nit + "'"
            End If
        End If

        querystring = "SELECT * FROM VEXPEDIENTES " + expresion + " ORDER BY TO_NUMBER(EXPE_NUME), EXPE_FELA"
        CrearComando(querystring)
        Dim dataTb As DataTable = EjecutarConsultaDataTable()
        Me.Desconectar()

        Return dataTb

    End Function
End Class
