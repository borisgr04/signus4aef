Imports Microsoft.VisualBasic
Imports System.Data
Imports System.Data.OleDb
Imports System.Math
Imports System
Imports System.IO
Imports System.Collections.Specialized
Imports System.ComponentModel
Imports Signus

Public Class BasesLiq
    Inherits FmtosImp

    '  Validación con la Base de Datos

    Dim NRAD As String
    Dim NIT As String
    Dim CLDEC As String
    Dim AÑO As String
    Dim PERI As String
    Dim ARCH As String
    Dim FECH As Date
    Dim EST As String
    Dim Adoc As String

    Property _Adoc() As String
        Get
            Return Adoc

        End Get
        Set(ByVal value As String)
            Adoc = value
        End Set
    End Property

    Public ReadOnly Property Radicado() As Integer
        Get
            Return NRAD
        End Get
    End Property

    Public ReadOnly Property Nombre_Archivo() As String
        Get
            Return Me.AÑO + Me.PERI + "_" + Me.CLDEC + "_" + Me.NIT + ".txt"
        End Get
    End Property
    Public Sub New(ByVal BALI_NIT As String, ByVal BALI_CDEC As String, ByVal BALI_AÑO As String, ByVal BALI_PERI As String, ByVal BALI_FECH As Date)

        Me.NIT = BALI_NIT
        Me.NRAD = 0
        Me.CLDEC = BALI_CDEC
        Me.AÑO = BALI_AÑO
        Me.PERI = BALI_PERI
        Me.EST = "AC"
        Me.FECH = BALI_FECH
        'Me.ARCH = Nombre_Archivo()

    End Sub

    Public Sub New()

    
    End Sub


    Public Function Insert0() As Boolean
        Dim na As Integer

        Dim obj As Consecutivos = New Consecutivos
        Dim vig As Vigencias = New Vigencias
        'Dim ObjC As CDeclaraciones = New CDeclaraciones(CLDEC)
        Me.Conectar()
        obj.Conexion = Me.Conexion
        vig.Conexion = Me.Conexion
        Try

            NRAD = obj.GetConsec("BLQ_RAD", vig.GetActivaD())

            'Dim FDCO As String = ObjC.GetFoDe_Codi(AÑO, PERI)
            Me.ComenzarTransaccion()
            Me.querystring = "INSERT INTO BASES_LIQ (BALI_NRAD, BALI_NIT, BALI_CDEC, BALI_AÑO, BALI_PERI, BALI_ARCH, BALI_EST, BALI_USAP, BALI_USBD, BALI_FESI, BALI_FECH)VALUES(:BALI_NRAD, :BALI_NIT, :BALI_CDEC, :BALI_AÑO, :BALI_PERI, :BALI_ARCH, :BALI_EST, :BALI_USAP, user, sysdate, :BALI_FECH)"
            AsignarParametroDecimal(":BALI_NRAD", NRAD)
            AsignarParametroCadena(":BALI_NIT", NIT)
            AsignarParametroCadena(":BALI_CDEC", CLDEC)
            AsignarParametroCadena(":BALI_AÑO", AÑO)
            AsignarParametroCadena(":BALI_PERI", PERI)
            AsignarParametroCadena(":BALI_ARCH", NRAD.ToString & ".txt")
            AsignarParametroCadena(":BALI_EST", EST)
            AsignarParametroCadena(":BALI_USAP", Me.usuario)
            AsignarParametroFecha(":BALI_FECH", FECH)
            'dbCommand.Parameters.Add("BALI_FDCO", OracleDbType.Date, ParameterDirection.Input).Value = FDCO

            na = EjecutarComando()
            Me.Guardar_Plano(Me.NRAD)

            Me.Msg = MsgOk + "<BR> Número de Filas Afectadas " + na.ToString
            Me.lErrorG = False
            ConfirmarTransaccion()
        Catch ex As Exception
            Me.lErrorG = True
            Me.Msg += "Error de App:" + ex.Message
            CancelarTransaccion()
        Finally
            Me.Desconectar()
        End Try
        Return Not Me.lErrorG
    End Function

    Public Function Insert() As Boolean
        Dim na As Integer

        Dim obj As Consecutivos = New Consecutivos
        Dim vig As Vigencias = New Vigencias
        'Dim ObjC As CDeclaraciones = New CDeclaraciones(CLDEC)
        Me.Conectar()
        obj.Conexion = Me.Conexion
        vig.Conexion = Me.Conexion
        Try

            NRAD = obj.GetConsec("BLQ_RAD", vig.GetActivaD())
            ComenzarTransaccion()
            Me.querystring = "INSERT INTO BASES_LIQ (BALI_NRAD, BALI_NIT, BALI_CDEC, BALI_AÑO, BALI_PERI, BALI_ARCH, BALI_EST, BALI_USAP, BALI_USBD, BALI_FESI, BALI_FECH)VALUES(:BALI_NRAD, :BALI_NIT, :BALI_CDEC, :BALI_AÑO, :BALI_PERI, :BALI_ARCH, :BALI_EST, :BALI_USAP, user, sysdate, :BALI_FECH)"
            CrearComando(querystring)
            AsignarParametroDecimal(":BALI_NRAD", NRAD)
            AsignarParametroCadena(":BALI_NIT", NIT)
            AsignarParametroCadena(":BALI_CDEC", CLDEC)
            AsignarParametroCadena(":BALI_AÑO", AÑO)
            AsignarParametroCadena(":BALI_PERI", PERI)
            AsignarParametroCadena(":BALI_ARCH", NRAD.ToString & ".txt")
            AsignarParametroCadena(":BALI_EST", EST)
            AsignarParametroCadena(":BALI_USAP", Me.usuario)
            AsignarParametroFecha(":BALI_FECH", FECH)
            'dbCommand.Parameters.Add("BALI_FDCO", OracleDbType.Date, ParameterDirection.Input).Value = FDCO

            na = EjecutarComando()
            Me.Guardar_Plano(Me.NRAD)
            Me.GuardarArchivoDef()
            Me.Msg = MsgOk + "<BR> Número de Filas Afectadas " + na.ToString
            Me.lErrorG = False
            ConfirmarTransaccion()
        Catch exio As IOException
            Me.lErrorG = True
            Dim msgr As String
            Dim m As New Mail
            msgr = m.Enviar(Me._MailSend, Me._MailAdmin, "Cargue de Archivo [" + Membership.GetUser.UserName + "]", exio.Message + "[" + Me._Adoc + "]")
            Me.Msg = "Error IO: No se pudo Cargar el Archivo. Error del Sistema de Archivo " + exio.Message ' + msgr
            CancelarTransaccion()
        Catch ex As Exception
            Me.lErrorG = True
            Me.Msg = "Error de App:" + ex.Message + ex.StackTrace '+ vComando.CommandText
            Dim m As New Mail
            Dim msgr As String
            msgr = m.Enviar(Me._MailSend, Me._MailAdmin, "Cargue de Archivo [" + Membership.GetUser.UserName + "]", ex.Message + Me._Adoc)

            CancelarTransaccion()
        Finally
            Me.Desconectar()
        End Try

        Return Not Me.lErrorG
    End Function

    Private Function GuardarArchivoDef() As Boolean

        Dim ATmp As String = Me.RutaArchivo

        'Ruta Permanente del Archivo
        Me._Adoc = Me.Ruta_Doc & Me.Radicado.ToString + ".txt"

        If File.Exists(Me._Adoc) Then
            File.Delete(Me._Adoc)
        End If
        'Throw New Exception(ATmp + "-" + Me._Adoc)

        File.Move(ATmp, Me._Adoc)

        Return True

    End Function

    Public Overloads Function Validar() As Boolean
        If Me.LeerArchivo() = True Then
            If Validar_Datos() = True Then
                If Me.Insert() Then
                    Me.Msg = "<b>Archivo Cargado y Válidado Satisfactaotiamente.</b> <br> Archivo Radicado <b>N° [" + Me.NRAD + "]</b>"
                    Return True
                Else
                    Me.Msg = "<b>Error al Guadar los Datos</b><br>" + Me.Msg
                    Return False
                End If
            Else

                Me.Msg = "<b>Los Datos del Archivo no son Válidos</b> <br> Presione el Botón de  "
                Me.Msg += "<b>Exportar Logs</b> para ver los detalles por cada registro del archivo cargado.<br>" '+ Me.Msg
                Me.Msg += "Ver Columna <b>LOG_ERROR</b>"
                Return False
            End If
        Else
            Me.Msg = "<b>El Formato del Archivo no es válido.</b><br>" + Me.Msg
            Return False
        End If

    End Function
    Public Overloads Function Validarx() As Boolean
        If Me.LeerArchivo() = True Then
            Me.Msg += "Subio"
            Return True
        Else
            Me.Msg += "Error Validación de Formato"
            Return False
        End If

    End Function
    <DataObjectMethodAttribute(DataObjectMethodType.Select, True)> _
    Public Overloads Function GetFmtos() As DataTable
        Me.Conectar()
        Me.querystring = "SELECT * FROM FMTOS WHERE FMTO_EST='AC'"
        CrearComando(querystring)
        Dim dataTb As DataTable = EjecutarConsultaDataTable()
        Me.Desconectar()
        Return dataTb
    End Function

    <DataObjectMethodAttribute(DataObjectMethodType.Select, True)> _
    Public Overloads Function GetFmtos(ByVal FMTO_CDEC As String) As DataTable
        Me.Conectar()
        Me.querystring = "SELECT * FROM FMTOS WHERE FMTO_EST='AC' AND FMTO_CDEC=:FMTO_CDEC"
        CrearComando(querystring)
        AsignarParametroCadena(":FMTO_CDEC", FMTO_CDEC)
        Dim dataTb As DataTable = EjecutarConsultaDataTable()
        Me.Desconectar()
        Return dataTb
    End Function


    Public Function Validar_Datos() As Boolean
        If Me.Codigo <> "3001" Then
            Return Val_BasesLiq01()
        Else
            Return Val_Fm_BLiqReg01()
        End If
    End Function
    ' Validacion de degüello y de Estampillas
    Public Function Val_BasesLiq01() As Boolean
        Dim TVALORIMPTO As Double = 0
        Dim TVALORBASE As Double = 0
        Me.Nro_Error = 0
        For i As Integer = 0 To dt.Rows.Count - 1
            Dim objT As Terceros = New Terceros
            Dim dtT As DataTable
            'Verificación de Nit
            Dim NIT As String = dt.Rows(i)("NIT_AR")
            Dim DV As String = dt.Rows(i)("DV_AR")
            Dim ClaDec As String = dt.Rows(i)("CDEC")
            Dim Imp As String = dt.Rows(i)("Impto")
            Dim AGravable As String = dt.Rows(i)("AGravable")
            Dim PGravable As String = dt.Rows(i)("PGravable")
            Dim VALORBASE As Double = dt.Rows(i)("VALORBASE")
            Dim TARIFA As Double = dt.Rows(i)("TARIFA")
            Dim VALORIMPTO As Double = dt.Rows(i)("VALORIMPTO")
            Dim NDOC As Double = dt.Rows(i)("NDOC")
            Dim FOPER As Date = dt.Rows(i)("FOPER")
            Dim TIDE As String = dt.Rows(i)("TIDE")

            Dim COD_MPIO As String = ""


            TVALORIMPTO += VALORIMPTO
            TVALORBASE += VALORBASE
            
            If Me.CLDEC <> ClaDec Then
                Msg += String.Format("Error Clase Dec {0}, No Corresponde a la Clase de Declaración definida <br>", ClaDec)
                dt.Rows(i)("log_Error") += String.Format("Error Clase Dec {0}, No Corresponde a la Clase de Declaración definida <br>", ClaDec)
                Nro_Error += 1
            End If

            If Me.AÑO <> AGravable Then
                Msg += String.Format("Error Año Gravable {0}, No Corresponde al definido <br>", AGravable)
                dt.Rows(i)("log_Error") += String.Format("Error Año Gravable {0}, No Corresponde al definido <br>", AGravable)
                Nro_Error += 1
            End If

            If Me.PERI <> PGravable Then
                Msg += String.Format("Error Periodo Gravable {0}, No Corresponde al definido <br>", PGravable)
                dt.Rows(i)("log_Error") += String.Format("Error Periodo Gravable {0}, No Corresponde al definido <br>", PGravable)
                Nro_Error += 1
            End If
            Dim TAG As String = ""
            dtT = objT.GetByIde(NIT, DV, "AR")
            If dtT.Rows.Count < 1 Then
                Msg += String.Format("Error Nit {0}, No Corresponde a un Agente Recuadador<br>", NIT)
                dt.Rows(i)("log_Error") += String.Format("Error Nit {0}, No Corresponde a un Agente Recuadador<br>", NIT)
                Nro_Error += 1
            Else
                TAG = dtT.Rows(0)("TAG_COD").ToString
            End If

            Dim ObjC As CDeclaraciones = New CDeclaraciones

            If Not ObjC.IsCDec_Nit(NIT, ClaDec) Then
                Msg += String.Format("Error Cdec, NIT {0} No tiene Asociado la Clase de Declaración {1}<br>", NIT, ClaDec)
                dt.Rows(i)(Me.CampoError) += String.Format("Error Cdec, NIT {0} No tiene Asociado la Clase de Declaración {1}<br>", NIT, ClaDec)
                Nro_Error += 1
            Else
                'Msg += "Si Tiene Asociado, la Cdec"
            End If

            If Not ObjC.IsCDec_Impto(ClaDec, Imp) Then
                Msg += String.Format("Error Cdec, Impto {0} No esta Asociado a la Clase de Declaración {1}<br>", Imp, ClaDec)
                dt.Rows(i)(Me.CampoError) += String.Format("Error Cdec, Impto {0} No esta Asociado a la Clase de Declaración {1}<br>", Imp, ClaDec)
                Nro_Error += 1
            Else
                'Msg += "Si Tiene Asociado, la Impto"
            End If

            Dim dtCal As DataTable = ObjC.Cdec_APGravable(ClaDec, AGravable, PGravable)
            If dtCal.Rows.Count = 0 Then
                Msg += String.Format("Error Cdec, Año: {0} y Periodo: {1} Gravable No Corresponden  No esta Asociado a la Clase de Declaración {2}<br>", AGravable, PGravable, ClaDec)
                dt.Rows(i)(Me.CampoError) += String.Format("Error Cdec, Año: {0} y Periodo: {1} Gravable No Corresponden  No esta Asociado a la Clase de Declaración {2}<br>", AGravable, PGravable, ClaDec)
                Nro_Error += 1
            Else
                'Msg += "Si Tiene Asociado, la A y P Gravable"

                If (FOPER < dtCal.Rows(0)("Cal_Fini")) Or (FOPER > dtCal.Rows(0)("Cal_FFin")) Then
                    Msg += String.Format("Error Fecha {0}, no esta dentro del periodo gravable: {1} y Periodo: {2} Gravable [{3} - {4}] <br>", FOPER, AGravable, PGravable, dtCal.Rows(0)("Cal_Fini"), dtCal.Rows(0)("Cal_FFin"))
                    dt.Rows(i)(Me.CampoError) += String.Format("Error Fecha {0}, no esta dentro del periodo gravable: {1} y Periodo: {2} Gravable [{3} - {4}] <br>", FOPER, AGravable, PGravable, dtCal.Rows(0)("Cal_Fini"), dtCal.Rows(0)("Cal_FFin"))
                    Nro_Error += 1
                End If
            End If

            Dim TARIFA_REAL As Double = TarifaImpto(ClaDec, Imp, TAG, FOPER)
            Dim VALORIMPTOC As Double = Round(VALORBASE * TARIFA_REAL)
            If TARIFA_REAL <> TARIFA Then
                Msg += String.Format("Tarifa del Archivo Plano {0} Tarifa del sistema {1}, No corresponden", TARIFA, TARIFA_REAL)
                dt.Rows(i)(Me.CampoError) += String.Format("Tarifa del Archivo Plano {0} Tarifa del sistema {1}, No corresponden", TARIFA, TARIFA_REAL)
                Nro_Error += 1
            Else
                Msg += "Si Corresponde el Cálculo de Impto"
            End If

            'If VALORIMPTO <> VALORIMPTOC Then
            '    Msg += String.Format("Valor Base {0} x Tarifa {1} = Valor Impto {2}, No corresponde con el Valor del Archivo Valor_Impto {3}", VALORBASE, TARIFA, VALORIMPTOC, VALORIMPTO)
            '    dt.Rows(i)(Me.CampoError) += String.Format("Valor Base {0} x Tarifa {1} = Valor Impto {2}, No corresponde con el Valor del Archivo Valor_Impto {3}", VALORBASE, TARIFA, VALORIMPTOC, VALORIMPTO)
            '    Nro_Error += 1
            'Else
            '    'Msg += "Si Corresponde el Cálculo de Impto"
            'End If


            If ClaDec = "20" And CInt(AGravable) > 2013 Then
                COD_MPIO = dt.Rows(i)("COD_MPIO").ToString
                Dim objM As New Municipios
                Dim dtM As DataTable = objM.GetPorCod(COD_MPIO)
                If dtM.Rows.Count = 0 Then
                    Msg += String.Format("Error Municipio Código Dane {0}, No Corresponde a la Clase de Declaración definida <br>", COD_MPIO)
                    dt.Rows(i)("log_Error") += String.Format("Error Municipio Código Dane {0}, No Corresponde a la Clase de Declaración definida <br>", COD_MPIO)
                    Nro_Error += 1
                End If
            Else
                COD_MPIO = ""
            End If
        Next
        Return (Me.Nro_Error = 0)

    End Function


 

    Public Function Val_Fm_BLiqReg01() As Boolean

        Dim TVALORIMPTO As Double = 0
        Dim TVALORBASE As Double = 0
        Me.Nro_Error = 0
        For i As Integer = 0 To dt.Rows.Count - 1
            Dim objT As Terceros = New Terceros
            Dim dtT As DataTable
            'Verificación de Nit
            'Encabezado
            Dim NIT As String = dt.Rows(i)("NIT_AR")
            Dim DV As String = dt.Rows(i)("DV_AR")
            Dim ClaDec As String = dt.Rows(i)("CDEC")
            Dim AGravable As String = dt.Rows(i)("AGravable")
            Dim PGravable As String = dt.Rows(i)("PGravable")

            Dim Imp As String = dt.Rows(i)("Impto")
            Dim NDOC As Double = dt.Rows(i)("NDOC")
            Dim FOPER As Date = dt.Rows(i)("FOPER")
            Dim TIDE As String = dt.Rows(i)("TIDE")


            Dim VALORBASE As Double = dt.Rows(i)("VALORBASE")
            Dim TARIFA As Double = dt.Rows(i)("TARIFA")
            Dim VALORIMPTO As Double = dt.Rows(i)("VALORIMPTO")

            Dim TACTO As String = dt.Rows(i)("TACTO")

            Dim INTERESES As String = dt.Rows(i)("INTERESES")


            Dim VALORIMPTOC As Double = VALORBASE * TARIFA
            TVALORIMPTO += VALORIMPTO
            TVALORBASE += VALORBASE

            'me.PERI
            'me.AÑO
            'me.CLDEC
            If Me.CLDEC <> ClaDec Then
                Msg += String.Format("Error Clase Dec {0}, No Corresponde a la Clase de Declaración definida <br>", ClaDec)
                dt.Rows(i)("log_Error") += String.Format("Error Clase Dec {0}, No Corresponde a la Clase de Declaración definida <br>", ClaDec)
                Nro_Error += 1
            End If

            If Me.AÑO <> AGravable Then
                Msg += String.Format("Error Año Gravable {0}, No Corresponde al definido <br>", AGravable)
                dt.Rows(i)("log_Error") += String.Format("Error Año Gravable {0}, No Corresponde al definido <br>", AGravable)
                Nro_Error += 1
            End If

            If Me.PERI <> PGravable Then
                Msg += String.Format("Error Periodo Gravable {0}, No Corresponde al definido <br>", PGravable)
                dt.Rows(i)("log_Error") += String.Format("Error Periodo Gravable {0}, No Corresponde al definido <br>", PGravable)
                Nro_Error += 1
            End If
            dtT = objT.GetByIde(NIT, DV, "AR")
            Dim TAG As String = ""
            If dtT.Rows.Count < 1 Then
                Msg += String.Format("Error Nit {0}, No Corresponde a un Agente Recuadador<br>", NIT)
                dt.Rows(i)("log_Error") += String.Format("Error Nit {0}, No Corresponde a un Agente Recuadador<br>", NIT)
                Nro_Error += 1
            Else
                TAG = dtT.Rows(0)("TAG_COD").ToString
                'Msg += "Si Existe el Nit"
            End If
            Dim ObjC As CDeclaraciones = New CDeclaraciones(ClaDec)

            If Not ObjC.IsCDec_Nit(NIT, ClaDec) Then
                Msg += String.Format("Error Cdec, NIT {0} No tiene Asociado la Clase de Declaración {1}<br>", NIT, ClaDec)
                dt.Rows(i)(Me.CampoError) += String.Format("Error Cdec, NIT {0} No tiene Asociado la Clase de Declaración {1}<br>", NIT, ClaDec)
                Nro_Error += 1
            Else
                'Msg += "Si Tiene Asociado, la Cdec"
            End If

            If Not ObjC.IsCDec_Impto(ClaDec, Imp) Then
                Msg += String.Format("Error Cdec, Impto {0} No esta Asociado a la Clase de Declaración {1}<br>", Imp, ClaDec)
                dt.Rows(i)(Me.CampoError) += String.Format("Error Cdec, Impto {0} No esta Asociado a la Clase de Declaración {1}<br>", Imp, ClaDec)
                Nro_Error += 1
            Else
                'Msg += "Si Tiene Asociado, la Impto"
            End If

            Dim dtCal As DataTable = ObjC.Cdec_APGravable(ClaDec, AGravable, PGravable)
            If dtCal.Rows.Count = 0 Then
                Msg += String.Format("Error Cdec, Año: {0} y Periodo: {1} Gravable No Corresponden  No esta Asociado a la Clase de Declaración {2}<br>", AGravable, PGravable, ClaDec)
                dt.Rows(i)(Me.CampoError) += String.Format("Error Cdec, Año: {0} y Periodo: {1} Gravable No Corresponden  No esta Asociado a la Clase de Declaración {2}<br>", AGravable, PGravable, ClaDec)
                Nro_Error += 1
            Else
                'Msg += "Si Tiene Asociado, la A y P Gravable"

                If (FOPER < dtCal.Rows(0)("Cal_Fini")) Or (FOPER > dtCal.Rows(0)("Cal_FFin")) Then
                    Msg += String.Format("Error Fecha {0}, no esta dentro del periodo gravable: {1} y Periodo: {2} Gravable [{3} - {4}] <br>", FOPER, AGravable, PGravable, dtCal.Rows(0)("Cal_Fini"), dtCal.Rows(0)("Cal_FFin"))
                    dt.Rows(i)(Me.CampoError) += String.Format("Error Fecha {0}, no esta dentro del periodo gravable: {1} y Periodo: {2} Gravable [{3} - {4}] <br>", FOPER, AGravable, PGravable, dtCal.Rows(0)("Cal_Fini"), dtCal.Rows(0)("Cal_FFin"))
                    Nro_Error += 1
                End If
            End If
            Dim TARIFA_REAL As Double = Tarifa_Registro(TACTO, TAG, FECH)
            If TARIFA_REAL <> TARIFA Then
                Msg += String.Format("Tarifa del Archivo Plano {0} Tarifa del sistema {1}, No corresponden", TARIFA, TARIFA_REAL)
                dt.Rows(i)(Me.CampoError) += String.Format("Tarifa del Archivo Plano {0} Tarifa del sistema {1}, No corresponden", TARIFA, TARIFA_REAL)
                Nro_Error += 1
            Else
                Msg += "Si Corresponde el Cálculo de Impto"
            End If

            VALORIMPTOC = VALORBASE * TARIFA_REAL

            If VALORIMPTO <> VALORIMPTOC Then
                Msg += String.Format("Valor Base {0} x Tarifa {1} = Valor Impto {2}, No corresponde con el Valor del Archivo Valor_Impto {3}", VALORBASE, TARIFA_REAL, VALORIMPTOC, VALORIMPTO)
                dt.Rows(i)(Me.CampoError) += String.Format("Valor Base {0} x Tarifa {1} = Valor Impto {2}, No corresponde con el Valor del Archivo Valor_Impto {3}", VALORBASE, TARIFA_REAL, VALORIMPTOC, VALORIMPTO)
                Nro_Error += 1
            Else
                'Msg += "Si Corresponde el Cálculo de Impto"
            End If

        Next
        'Msg += "Valor Base :" + TVALORBASE.ToString + "<BR>"
        'Msg += "Valor Impto :" + TVALORIMPTO.ToString + "<BR>"
        'Msg = ""
        'Msg = "INSERT INTO " + Me.fmtTabla + "(" + Me.fmtCampos + ")Values(" + Me.fmtValues + ")"
        Return (Me.Nro_Error = 0)

    End Function

    'Public Sub New(ByVal PathLibro As String)
    '   Me.Libro = PathLibro
    'End Sub
    <DataObjectMethodAttribute(DataObjectMethodType.Select, True)> _
    Public Overloads Function GetRecords(ByVal NIT As String, ByVal CLDEC As String, ByVal AÑO As String, ByVal PERI As String) As DataTable

        Me.Conectar()
        Me.querystring = "SELECT BALI_NRAD NRAD, BALI_NIT NIT,  BALI_ARCH ARCHIVO, BALI_EST ESTADO, BALI_USAP USAP, BALI_USBD USBD, BALI_FESI FECHA_SISTEMA  FROM Bases_Liq WHERE BALI_NIT=:BALI_NIT AND  BALI_CDEC=:BALI_CDEC AND BALI_AÑO=:BALI_AÑO AND BALI_PERI=:BALI_PERI ORDER BY BALI_NRAD DESC"
        CrearComando(querystring)
        AsignarParametroCadena(":BALI_NIT", NIT)
        AsignarParametroCadena(":BALI_CDEC", CLDEC)
        AsignarParametroCadena(":BALI_AÑO", AÑO)
        AsignarParametroCadena(":BALI_PERI", PERI)
        Dim dataTb As DataTable = EjecutarConsultaDataTable()
        Me.Desconectar()
        Return dataTb
    End Function

    <DataObjectMethodAttribute(DataObjectMethodType.Select, True)> _
    Public Overloads Function isExits(ByVal NIT As String, ByVal CLDEC As String, ByVal AÑO As String, ByVal PERI As String) As Boolean

        Me.Conectar()
        Me.querystring = "SELECT Count(*) Cant  FROM Bases_Liq WHERE BALI_NIT=:BALI_NIT AND  BALI_CDEC=:BALI_CDEC AND BALI_AÑO=:BALI_AÑO AND BALI_PERI=:BALI_PERI AND BALI_EST='AC'"
        CrearComando(querystring)
        AsignarParametroCadena(":BALI_NIT", NIT)
        AsignarParametroCadena(":BALI_CDEC", CLDEC)
        AsignarParametroCadena(":BALI_AÑO", AÑO)
        AsignarParametroCadena(":BALI_PERI", PERI)
        Dim c As Object = EjecutarEscalar()
        Me.Desconectar()
        Dim cantidad As Integer = CInt(c)
        Return (cantidad > 0)


    End Function



    <DataObjectMethodAttribute(DataObjectMethodType.Select, True)> _
    Public Overloads Function GetFmto(ByVal nro_rad As String) As DataTable

        Me.Conectar()
        Me.querystring = "Select * From fm_basesliq01 where  nro_rad=:nro_rad"
        CrearComando(querystring)
        AsignarParametroCadena(":nro_rad", nro_rad)
        Dim dataTb As DataTable = EjecutarConsultaDataTable()
        Me.Desconectar()
        Return dataTb

    End Function

    <DataObjectMethodAttribute(DataObjectMethodType.Select, True)> _
    Public Overloads Function GetAforoCdec(ByVal Cla_dec As String, ByVal Tipo_Agente As String, Optional ByVal nro_rad As Long = 0) As DataTable
        If Cla_dec = "30" Then
            Return GetAforoReg(Tipo_Agente, nro_rad)
        Else
            Return GetAforo(Tipo_Agente, nro_rad)
        End If
    End Function


    <DataObjectMethodAttribute(DataObjectMethodType.Select, True)> _
    Public Overloads Function GetAforo(ByVal Tipo_Agente As String, Optional ByVal nro_rad As Long = 0) As DataTable
        Me.Conectar()
        'Dim Param As String = CDeclaraciones.GetParametrosTar(Me.CLDEC, Tipo_Agente)
        'Dim queryString As String = String.Format("Select Impto, Sum(ValorBase) BaseGravable, Sum(valorImpto) ValorImpuesto,Fn_Ejecutar_Tarifa(Impto,{0}) Tarifa From Fm_BasesLiq01  Where Nro_rad=:Nro_rad  Group by Impto", Param)
        querystring = "Select CoCd_Cdec,CoCd_CoDi,CoCd_Nomb,CoCd_Impto,Fn_Ejecutar_Tarifa(CoCd_Impto,parametros) Tarifa,NVL(BaseGravable,0) BaseGravable,NVL(ValorImpuesto,0) ValorImpuesto From "
        querystring += "("
        querystring += "Select  Lp.CoCd_Cdec,Lp.CoCd_CoDi,Cocd_Tico,CoCd_Nomb,CoCd_Impto "
        querystring += ",CASE WHEN CoCd_IsVb ='S' THEN Tarifas_Parametros(CoCd_Cdec,'" + Tipo_Agente + "',Tipo_Tar) ELSE '-' END Parametros "
        querystring += " From Bases_liq "
        querystring += "Inner Join Conc_Cdec Lp On cocd_fdco=BaLi_FdCo And cocd_seco='LP' And CoCd_Tico='C' "
        querystring += "Where BaLi_NRad=" + nro_rad.ToString + " And bali_est='AC' Order By CoCd_Codi "
        querystring += ") Aforo Left Join "
        querystring += "("
        querystring += "Select Impto, Sum(ValorBase) BaseGravable, Sum(valorImpto) ValorImpuesto From Fm_BasesLiq01  Where Nro_rad=" + nro_rad.ToString + "  Group by Impto "
        querystring += ") On Impto=CoCd_Impto "
        Msg = querystring
        CrearComando(querystring)
        'AsignarParametroCadena(":Nrad", nro_rad)
        Dim dataTb As DataTable = EjecutarConsultaDataTable()
        Me.Desconectar()
        Return dataTb
    End Function
    ''' <summary>
    ''' Genera Aforo de Impuesto de Registro, Fm_BliqReg01/SE LLAMA DESDE LA CONSULTA
    ''' </summary>
    ''' <param name="Tipo_Agente"></param>
    ''' <param name="nro_rad"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    <DataObjectMethodAttribute(DataObjectMethodType.Select, True)> _
    Public Overloads Function GetAforoReg(ByVal Tipo_Agente As String, Optional ByVal nro_rad As Long = 0) As DataTable
        Me.Conectar()
        'Dim Param As String = CDeclaraciones.GetParametrosTar(Me.CLDEC, Tipo_Agente)
        'Dim queryString As String = String.Format("Select Impto, Sum(ValorBase) BaseGravable, Sum(valorImpto) ValorImpuesto,Fn_Ejecutar_Tarifa(Impto,{0}) Tarifa From Fm_BasesLiq01  Where Nro_rad=:Nro_rad  Group by Impto", Param)
        querystring = "SELECT cocd_cdec, cocd_codi, cocd_nomb, cocd_impto, fn_ejecutar_tarifa (cocd_impto, parametros) tarifa,        NVL (basegravable, 0) basegravable,NVL (valorimpuesto, 0) valorimpuesto From "
        querystring += "("
        querystring += "Select  Lp.CoCd_Cdec,Lp.CoCd_CoDi,Cocd_Tico,CoCd_Nomb,CoCd_Impto "
        querystring += ",CASE WHEN CoCd_IsVb ='S' THEN Tarifas_Parametros(CoCd_Cdec,(select Ter_Tip from terceros where ter_nit=(select distinct nit_ar from fm_bliqreg01  WHERE nro_rad = " + nro_rad.ToString + ")),Tipo_Tar) ELSE '-' END Parametros "
        querystring += " From Bases_liq "
        querystring += "Inner Join Conc_Cdec Lp On cocd_fdco=BaLi_FdCo And cocd_seco='LP' And CoCd_Tico='C' "
        querystring += "Where BaLi_NRad=" + nro_rad.ToString + " And bali_est='AC' Order By CoCd_Codi "
        querystring += ") Aforo Left Join "
        querystring += "("
        'queryString += "Select Impto, Sum(ValorBase) BaseGravable, Sum(valorImpto) ValorImpuesto From Fm_BasesLiq01  Where Nro_rad=" + nro_rad.ToString + "  Group by Impto "
        querystring += "SELECT   '30' cdec, CASE WHEN es_devolucion = 'NO' THEN '01' ELSE '02' END codi, SUM (valorbase) basegravable, SUM (valorimpto+intereses) valorimpuesto FROM fm_bliqreg01  WHERE nro_rad = " + nro_rad.ToString + " GROUP BY impto, es_devolucion"
        querystring += ") On cdec = cocd_cdec AND cocd_codi=codi "
        Msg = querystring
        'Throw New Exception("OJO desde el validador" + querystring)
        CrearComando(querystring)

        'AsignarParametroCadena(":Nrad", nro_rad)
        Dim dataTb As DataTable = EjecutarConsultaDataTable()
        Me.Desconectar()
        Return dataTb
    End Function

    ''' <summary>
    ''' Llamado en formulario de declaracion de registro
    ''' </summary>
    ''' <param name="Tipo_Agente"></param>
    ''' <param name="nro_rad"></param>
    ''' <param name="Codi"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    ''' 
    <DataObjectMethodAttribute(DataObjectMethodType.Select, True)> _
    Public Overloads Function GetAforoReg(ByVal Tipo_Agente As String, ByVal nro_rad As Integer, ByVal Codi As String) As DataTable
        Me.Conectar()
        'Dim Param As String = CDeclaraciones.GetParametrosTar(Me.CLDEC, Tipo_Agente)
        'Dim queryString As String = String.Format("Select Impto, Sum(ValorBase) BaseGravable, Sum(valorImpto) ValorImpuesto,Fn_Ejecutar_Tarifa(Impto,{0}) Tarifa From Fm_BasesLiq01  Where Nro_rad=:Nro_rad  Group by Impto", Param)
        querystring = "SELECT cocd_cdec, cocd_codi, cocd_nomb, cocd_impto,        fn_ejecutar_tarifa (cocd_impto, parametros) tarifa,        NVL (basegravable, 0) basegravable,NVL (valorimpuesto, 0) valorimpuesto From "
        querystring += "("
        querystring += "Select  Lp.CoCd_Cdec,Lp.CoCd_CoDi,Cocd_Tico,CoCd_Nomb,CoCd_Impto "
        querystring += ",CASE WHEN CoCd_IsVb ='S' THEN Tarifas_Parametros(CoCd_Cdec,'" + Tipo_Agente + "',Tipo_Tar) ELSE '-' END Parametros "
        querystring += " From Bases_liq "
        querystring += "Inner Join Conc_Cdec Lp On cocd_fdco=BaLi_FdCo And cocd_seco='LP' And CoCd_Tico='C' "
        querystring += "Where BaLi_NRad=" + nro_rad.ToString + " And bali_est='AC' Order By CoCd_Codi "
        querystring += ") Aforo Left Join "
        querystring += "("
        'queryString += "Select Impto, Sum(ValorBase) BaseGravable, Sum(valorImpto) ValorImpuesto From Fm_BasesLiq01  Where Nro_rad=" + nro_rad.ToString + "  Group by Impto "
        querystring += "SELECT   '30' cdec, CASE WHEN es_devolucion = 'NO' THEN '01' ELSE '02' END codi, SUM (valorbase) basegravable, Redondear(SUM (valorimpto+intereses)) valorimpuesto FROM fm_bliqreg01  WHERE nro_rad = " + nro_rad.ToString + " GROUP BY impto, es_devolucion"
        querystring += ") On cdec = cocd_cdec AND cocd_codi=codi WHERE cocd_codi='" + Codi + "'"
        Msg = querystring
        'Throw New Exception(querystring)
        CrearComando(querystring)
        'AsignarParametroCadena(":Nrad", nro_rad)
        Dim dataTb As DataTable = EjecutarConsultaDataTable()
        Me.Desconectar()
        Return dataTb
    End Function
    ''' <summary>
    ''' Llamado en los formularios de declaracion de Estampillas y Degüello
    ''' </summary>
    ''' <param name="Tipo_Agente"></param>
    ''' <param name="nro_rad"></param>
    ''' <param name="cod_impto"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    <DataObjectMethodAttribute(DataObjectMethodType.Select, True)> _
    Public Overloads Function GetAforo(ByVal Tipo_Agente As String, ByVal nro_rad As Long, ByVal cod_impto As String) As DataTable
        Me.Conectar()
        'Dim Param As String = CDeclaraciones.GetParametrosTar(Me.CLDEC, Tipo_Agente)
        'Dim queryString As String = String.Format("Select Impto, Sum(ValorBase) BaseGravable, Sum(valorImpto) ValorImpuesto,Fn_Ejecutar_Tarifa(Impto,{0}) Tarifa From Fm_BasesLiq01  Where Nro_rad=:Nro_rad  Group by Impto", Param)
        querystring = "Select CoCd_Cdec,CoCd_CoDi,CoCd_Nomb,CoCd_Impto,Fn_Ejecutar_Tarifa(CoCd_Impto,parametros) Tarifa,NVL(BaseGravable,0) BaseGravable,NVL(ValorImpuesto,0) ValorImpuesto From "
        querystring += "("
        querystring += "Select  Lp.CoCd_Cdec,Lp.CoCd_CoDi,Cocd_Tico,CoCd_Nomb,CoCd_Impto "
        querystring += ",CASE WHEN CoCd_IsVb ='S' THEN Tarifas_Parametros(CoCd_Cdec,(select Ter_Tip from terceros where ter_nit=(select distinct nit_ar from fm_bliqreg01  WHERE nro_rad = " + nro_rad.ToString + ")),Tipo_Tar) ELSE '-' END Parametros "
        querystring += " From Bases_liq "
        querystring += "Inner Join Conc_Cdec Lp On cocd_fdco=BaLi_FdCo And cocd_seco='LP' And CoCd_Tico='C' "
        querystring += "Where BaLi_NRad=" + nro_rad.ToString + " And bali_est='AC' Order By CoCd_Codi "
        querystring += ") Aforo Left Join "
        querystring += "("
        querystring += "Select Impto, Sum(ValorBase) BaseGravable, Redondear(Sum(valorImpto)) ValorImpuesto From Fm_BasesLiq01  Where Nro_rad=" + nro_rad.ToString + "  Group by Impto "
        querystring += ") On Impto=CoCd_Impto Where CoCd_Impto='" + cod_impto + "'"
        Msg = querystring
        CrearComando(querystring)
        'AsignarParametroCadena(":Nrad", nro_rad)
        Dim dataTb As DataTable = EjecutarConsultaDataTable()
        Me.Desconectar()
        Return dataTb
    End Function

    <DataObjectMethodAttribute(DataObjectMethodType.Select, True)> _
    Public Overloads Function GetAforo2(ByVal Tipo_Agente As String, ByVal nit As String, ByVal año As String, ByVal peri As String) As DataTable
        Me.Conectar()
        'Dim Param As String = CDeclaraciones.GetParametrosTar(Me.CLDEC, Tipo_Agente)
        'Dim queryString As String = String.Format("Select Impto, Sum(ValorBase) BaseGravable, Sum(valorImpto) ValorImpuesto,Fn_Ejecutar_Tarifa(Impto,{0}) Tarifa From Fm_BasesLiq01  Where Nro_rad=:Nro_rad  Group by Impto", Param)
        querystring = "Select CoCd_Cdec,CoCd_CoDi,CoCd_Nomb,CoCd_Impto,Fn_Ejecutar_Tarifa(CoCd_Impto,parametros) Tarifa,NVL(BaseGravable,0) BaseGravable,NVL(ValorImpuesto,0) ValorImpuesto From "
        querystring += "("
        querystring += "Select  Lp.CoCd_Cdec,Lp.CoCd_CoDi,Cocd_Tico,CoCd_Nomb,CoCd_Impto "
        querystring += ",CASE WHEN CoCd_IsVb ='S' THEN Tarifas_Parametros(CoCd_Cdec,'" + Tipo_Agente + "',Tipo_Tar) ELSE '-' END Parametros "
        querystring += " From Bases_liq "
        querystring += "Inner Join Conc_Cdec Lp On cocd_fdco=BaLi_FdCo And cocd_seco='LP' And CoCd_Tico='C' "
        querystring += "Where BaLi_año=" + año + " and bali_peri='" + peri + "' and bali_nit='" + nit + "' Order By CoCd_Codi "
        querystring += ") Aforo Left Join "
        querystring += "("
        querystring += "Select Impto, Sum(ValorBase) BaseGravable, Sum(valorImpto) ValorImpuesto From Fm_BasesLiq01  Where Agravable=" + año + " and Pgravable='" + peri + "' and nit_ar='" + nit + "'  Group by Impto "
        querystring += ") On Impto=CoCd_Impto "
        Msg = querystring
        CrearComando(querystring)
        'AsignarParametroCadena(":Nrad", nro_rad)
        Dim dataTb As DataTable = EjecutarConsultaDataTable()

        Me.Desconectar()
        Return dataTb
    End Function
    <DataObjectMethodAttribute(DataObjectMethodType.Select, True)> _
    Public Overloads Function GetAforo(ByVal Tipo_Agente As String, ByVal cla_dec As String, ByVal nit As String, ByVal año As String, ByVal peri As String) As DataTable
        Dim dataTb As DataTable, dt As DataTable
        dataTb = Me.GetRecords(nit, cla_dec, año, peri) 'Consulta el numero de Radicacion. 

        If dataTb.Rows.Count > 0 Then
            If cla_dec = "30" Then ' Si es Registro
                dt = Me.GetAforoReg(Tipo_Agente, dataTb.Rows(0)("NRAD").ToString)
            Else
                dt = Me.GetAforo(Tipo_Agente, dataTb.Rows(0)("NRAD").ToString)
            End If

        Else
            dt = New DataTable
        End If

        Return dt
    End Function
    <DataObjectMethodAttribute(DataObjectMethodType.Select, True)> _
    Public Overloads Function GetAforo(ByVal Tipo_Agente As String, ByVal cla_dec As String, ByVal nit As String, ByVal año As String, ByVal peri As String, ByVal cod_impto As String) As DataTable
        Dim dataTb As DataTable, dt As DataTable
        dataTb = Me.GetRecords(nit, cla_dec, año, peri)
        If dataTb.Rows.Count > 0 Then
            If cla_dec = "30" Then ' Si es Registro
                dt = Me.GetAforoReg(Tipo_Agente, dataTb.Rows(0)("NRAD").ToString, cod_impto)
            Else
                dt = Me.GetAforo(Tipo_Agente, dataTb.Rows(0)("NRAD").ToString, cod_impto)
            End If
        Else
            dt = New DataTable
        End If
        Return dt
    End Function

    <DataObjectMethodAttribute(DataObjectMethodType.Select, True)> _
    Public Overloads Function GetAforo2(ByVal Tipo_Agente As String, ByVal cla_dec As String, ByVal nit As String, ByVal año As String, ByVal peri As String, ByVal cod_impto As String) As DataTable
        Me.Conectar()
        'Dim Param As String = CDeclaraciones.GetParametrosTar(Me.CLDEC,, Tipo_Agente)
        'Dim queryString As String = String.Format("Select Impto, Sum(ValorBase) BaseGravable, Sum(valorImpto) ValorImpuesto,Fn_Ejecutar_Tarifa(Impto,{0}) Tarifa From Fm_BasesLiq01  Where Nro_rad=:Nro_rad  Group by Impto", Param)
        querystring = "Select CoCd_Cdec,CoCd_CoDi,CoCd_Nomb,CoCd_Impto,Fn_Ejecutar_Tarifa(CoCd_Impto,parametros) Tarifa,NVL(BaseGravable,0) BaseGravable,NVL(ValorImpuesto,0) ValorImpuesto From "
        querystring += "("
        querystring += "Select  Lp.CoCd_Cdec,Lp.CoCd_CoDi,Cocd_Tico,CoCd_Nomb,CoCd_Impto "
        querystring += ",CASE WHEN CoCd_IsVb ='S' THEN Tarifas_Parametros(CoCd_Cdec,'" + Tipo_Agente + "',Tipo_Tar) ELSE '-' END Parametros "
        querystring += " From Bases_liq "
        querystring += "Inner Join Conc_Cdec Lp On cocd_fdco=BaLi_FdCo And cocd_seco='LP' And CoCd_Tico='C' "
        querystring += "Where BaLi_año=" + año + " and bali_peri='" + peri + "' and bali_nit='" + nit + "' Order By CoCd_Codi "
        querystring += ") Aforo Left Join "
        querystring += "("
        querystring += "Select Impto, Sum(ValorBase) BaseGravable, Sum(valorImpto) ValorImpuesto From Fm_BasesLiq01  Where Agravable=" + año + " and Pgravable='" + peri + "' and nit_ar='" + nit + "'  Group by Impto "
        querystring += ") On Impto=CoCd_Impto Where CoCd_Impto='" + cod_impto + "'"
        Msg = querystring
        CrearComando(querystring)
        'AsignarParametroCadena(":Nrad", nro_rad)
        Dim dataTb As DataTable = EjecutarConsultaDataTable()
        Me.Desconectar()
        Return dataTb
    End Function

    'Select Impto, Sum(VAlorBase) BaseGravable, Sum(valorImpto) ValorImpuesto,Fn_Ejecutar_Tarifa(Impto,'Valor_Base Number:=1;Tipo_Acto Number:=1;') Tarifa From Fm_BasesLiq01  Where Nro_rad=50  Group by Impto
    <DataObjectMethodAttribute(DataObjectMethodType.Update, True)> _
    Public Function Anular(ByVal nro_rad As String) As String
        Dim na As Integer
        Me.Conectar()
        Try
            ComenzarTransaccion()
            Me.querystring = "Update Bases_Liq Set bali_est='AN' where  bali_nrad=:nro_rad"
            CrearComando(querystring)
            AsignarParametroCadena(":nro_rad", nro_rad)
            EjecutarComando()
            Me.Msg = MsgOk + "<BR> Número de Filas Afectadas " + na.ToString
            Me.lErrorG = False
            ConfirmarTransaccion()
        Catch ex As Exception
            Me.lErrorG = True
            Me.Msg += "Error de App:" + ex.Message
            CancelarTransaccion()
        Finally
            Me.Desconectar()
        End Try
        Return Me.Msg
    End Function

    ''' <summary>
    ''' Diseñada el 21 de Julio del 2011, con el Objetivo de Validar sistematicamente al archivo de registro
    ''' </summary>
    ''' <param name="tip"></param>
    ''' <param name="TAG"></param>
    ''' <param name="fecha"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function Tarifa_Registro(ByVal tip As String, ByVal TAG As String, ByVal fecha As Date) As Double
        Dim objCd As New CDeclaraciones("30")
        Dim Input_par As String = objCd.GetParametrosTar("30", TAG, tip)

        Return objCd.GetTarifa("3001", Input_par, fecha)
    End Function

    Public Function TarifaImpto(ByVal ClaseDec As String, ByVal CodImpto As String, ByVal TAG As String, ByVal fecha As Date) As Double
        Dim objCd As New CDeclaraciones(ClaseDec)
        Dim Input_par As String = objCd.GetParametrosTar(ClaseDec, TAG)
        'Throw New Exception(Input_par)
        Return objCd.GetTarifa(CodImpto, Input_par, fecha)
    End Function


End Class

