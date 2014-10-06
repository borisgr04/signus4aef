Imports Microsoft.VisualBasic
Imports System.Data
Imports System.ComponentModel
Imports Signus

'Clase para manejar la Tabla Conc_Cart de la Base de datos
'Fecha Creaciòn: 07 dic 2009
'Autor: Ronal Javier

Public Class CorreosE
    Inherits BDDatos2
    '---------------------------------------------------------------------------------------------------------------

 '---------------------------------------------------------------------------------------------------------------
    ' Funciòn Insert: Agrega datos a la tabla Correose

    Public Function Insert(ByVal CORR_CODI As String, ByVal CORR_NOMB As String, ByVal CORR_DATO As String, ByVal CORR_BODY As String, ByVal CORR_camp As String, ByVal CORR_vista As String) As String

        Dim na As Integer
        Me.Conectar()
        Try
            ComenzarTransaccion()
            Me.querystring = "INSERT INTO Correose (CORR_CODI,CORR_NOMB,CORR_DATO,CORR_BODY,CORR_CAMP)VALUES(:CORR_CODI,:CORR_NOMB,:CORR_DATO,:CORR_BODY,:CORR_CAMP,:CORR_VISTA)"
            CrearComando(querystring)
            AsignarParametroCadena(":CORR_CODI", CORR_CODI)
            AsignarParametroCadena(":CORR_NOMB", CORR_NOMB)
            AsignarParametroCadena(":CORR_DATO", CORR_DATO)
            AsignarParametroCadena(":CORR_BODY", CORR_BODY)
            AsignarParametroCadena(":CORR_CAMP", CORR_camp)
            AsignarParametroCadena(":CORR_VISTA", CORR_vista)
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
    ' Funciòn Actualizar: Acatualiza datos a la tabla Correose
    '    
    Public Function Update(ByVal CORR_CODI_OR As String, ByVal CORR_CODI As String, ByVal CORR_NOMB As String, ByVal CORR_DATO As String, ByVal CORR_BODY As String, ByVal CORR_camp As String, ByVal CORR_vista As String) As String
        Dim na As String
        Me.Conectar()
        Try
            ComenzarTransaccion()
            Me.querystring = "UPDATE Correose SET CORR_CODI='" + CORR_CODI + "',CORR_NOMB='" + CORR_NOMB + "',CORR_DATO='" + CORR_DATO + "',CORR_BODY='" + CORR_BODY + "', CORR_CAMP='" + CORR_camp + "', CORR_VISTA='" + CORR_vista + "'  WHERE CORR_CODI='" + CORR_CODI_OR + "'"
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
        Return Msg
    End Function
    'Funciòn Delete: elimina datos a la tabla Correose
    ' Parametros: Tcta_Codi : Còdigo

    Public Function Delete(ByVal CORR_CODI As String) As String
        Dim na As String

        'If (CInt(COD) = 1) Or (CInt(COD) = 2) Or (CInt(COD) = 3) Then

        'Return "Esta Clase de Impuesto, No se puede eliminar"
        'End If
        Me.Conectar()
        Try
            ComenzarTransaccion()

            Me.querystring = "DELETE Correose WHERE CORR_CODI='" + CORR_CODI + "'"
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
        Dim queryString As String = "SELECT * FROM Correose ORDER BY CORR_CODI"
        CrearComando(queryString)
        Dim dataTb As DataTable = EjecutarConsultaDataTable()
        Me.Desconectar()
        Return dataTb
    End Function
    <DataObjectMethodAttribute(DataObjectMethodType.Select, True)> _
    Public Overloads Function GetPorCod(ByVal CORR_CODI As String) As DataTable
        Me.Conectar()
        Dim queryString As String = "SELECT * FROM Correose WHERE CORR_CODI=:CORR_CODI"
        CrearComando(queryString)
        AsignarParametroCadena(":CORR_CODI", CORR_CODI)
        Dim dataTb As DataTable = EjecutarConsultaDataTable()
        Me.Desconectar()
        Return dataTb
    End Function
    <DataObjectMethodAttribute(DataObjectMethodType.Select, True)> _
    Public Overloads Function GetPorNom(ByVal Corr_Nomb As String) As DataTable
        Me.Conectar()
        Dim queryString As String = "SELECT * FROM CorreosE Where Corr_Nomb=:Corr_Nomb"
        CrearComando(queryString)
        AsignarParametroCadena(":Corr_Nomb", Corr_Nomb)
        Dim dataTb As DataTable = EjecutarConsultaDataTable()
        Me.Desconectar()
        Return dataTb
    End Function

    Public Function Cargar_Plantilla(ByVal u As String, ByVal rst As String, ByVal nom As String, ByVal nom_pla As String) As String
        Dim dtc As DataTable = Me.GetPorNom("resclave")
        Dim m As String = ""
        If dtc.Rows.Count > 0 Then
            m = dtc.Rows(0)("Corr_Body").ToString
            m = m.Replace("{fecha}", Now.ToLongDateString)
            m = m.Replace("{agente}", nom)
            m = m.Replace("{usuario}", u)
            m = m.Replace("{password}", rst)
            m = m.Replace("{fechahora}", CStr(Now))
        End If
        Return m
    End Function


    Public Function Enviar_Correo_Rst(ByVal User As String, Optional ByVal rst As String = "x") As String
        Dim objt As Terceros = New Terceros
        Dim dt As DataTable
        Try
            Dim u As String = User
            dt = objt.GetByUser(u)
            If dt.Rows.Count > 0 Then
                If rst = "x" Then
                    rst = Membership.GetUser(u).ResetPassword
                End If
                Dim MsgMail As NotEmail = New NotEmail
                Dim Cuerpo As String = Me.Cargar_Plantilla(u, rst, dt.Rows(0)("TER_NOM").ToString, "Cla_Not")
                Msg = MsgMail.EnviarNotificacion(dt.Rows(0)("ter_emai").ToString, ConfigurationManager.AppSettings("NOMAPP") + "- RESTAURAR CONTRASEÑA", Cuerpo)
                Msg = "El Sistema envió nueva contraseña de forma automático, a su Correo Electrónico de Notificaciones"
                Me.lErrorG = False
                'Me.LMSgBox.CssClass = "Ok"
                'Membership.GetUser(u).ChangePassword(rst, Me.Tcont.Text)
            Else
                Msg = "Usuario no registrado en el Sistema"
                Me.lErrorG = True
                'Me.LMSgBox.CssClass = "NotOk"
            End If
        Catch ex As Exception
            Msg = "Error de App:" + ex.Message
            Me.lErrorG = True
            'Me.LMSgBox.CssClass = "NotOK"
        Finally
        End Try
        Return Msg
    End Function
End Class