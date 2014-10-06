Imports Microsoft.VisualBasic
Imports System.Data
Imports System.ComponentModel
Imports System

Namespace Signus




    Public Class Terceros
        Inherits BDDatos2

        Public Function Insert(ByVal TER_TDOC As String, ByVal TER_NIT As String, ByVal TER_DVER As String, _
        ByVal TER_NOM As String, ByVal TER_TIP As String, ByVal TER_MPIO As String, _
        ByVal TER_EMAI As String, ByVal TER_TEL As String, ByVal TER_DIR As String, _
        ByVal TER_CED As String, ByVal TER_REP As String, ByVal TER_USU As String, ByVal TER_TUS As String, _
        ByVal TER_EST As String, ByVal TER_OBS As String, Optional ByVal TER_REP_EXP As String = "") As String


            Me.Conectar()
            Try
                ComenzarTransaccion()
                Me.querystring = "INSERT INTO TERCEROS(TER_TDOC, TER_NIT, TER_DVER, TER_NOM, TER_TIP, TER_MPIO, TER_EMAI, TER_TEL, TER_DIR, TER_CED, TER_REP, TER_USU, TER_TUS,TER_FREG, TER_FNOV,  TER_EST, TER_OBS, TER_USAP, TER_USBD, TER_REP_EXP )" & _
                "VALUES(:TER_TDOC, :TER_NIT, :TER_DVER, :TER_NOM, :TER_TIP, :TER_MPIO, :TER_EMAI, :TER_TEL, :TER_DIR, :TER_CED, :TER_REP, :TER_USU, :TER_TUS,SYSDATE, SYSDATE,  :TER_EST, :TER_OBS, :TER_USAP, USER, :TER_REP_EXP)"
                CrearComando(querystring)
                AsignarParametroCadena(":TER_TDOC", TER_TDOC)
                AsignarParametroCadena(":TER_NIT", TER_NIT)
                AsignarParametroCadena(":TER_DVER", TER_DVER)
                AsignarParametroCadena(":TER_NOM", TER_NOM)
                AsignarParametroCadena(":TER_TIP", TER_TIP)
                AsignarParametroCadena(":TER_MPIO", TER_MPIO)
                AsignarParametroCadena(":TER_EMAI", TER_EMAI)
                AsignarParametroCadena(":TER_TEL", TER_TEL)
                AsignarParametroCadena(":TER_DIR", TER_DIR)
                AsignarParametroCadena(":TER_CED", TER_CED)
                AsignarParametroCadena(":TER_REP", TER_REP)
                AsignarParametroCadena(":TER_USU", TER_USU)
                AsignarParametroCadena(":TER_TUS", TER_TUS)
                AsignarParametroCadena(":TER_REP_EXP", TER_REP_EXP)
                'dbCommand.Parameters.Add("TER_FREG", OracleDbType.Varchar2, ParameterDirection.Input).Value = SYSDATE
                ' dbCommand.Parameters.Add("TER_FNOV", OracleDbType.Varchar2, ParameterDirection.Input).Value =
                'dbCommand.Parameters.Add("TER_FFIN", OracleDbType.Varchar2, ParameterDirection.Input).Value =
                AsignarParametroCadena(":TER_EST", TER_EST)
                AsignarParametroCadena(":TER_OBS", TER_OBS)
                AsignarParametroCadena(":TER_USAP", Me.usuario)
                'dbCommand.Parameters.Add("TER_USBD", OracleDbType.Varchar2, ParameterDirection.Input).Value = 


                num_reg = EjecutarComando()
                'Dim objmn As DBMenu = New DBMenu
                'If TER_TUS = "AR" Then
                ' objmn.AsigPerfilUser("AGENTER", TER_NIT)
                'End If


                Me.Msg = MsgOk + "<BR> Número de Filas Afectadas " + num_reg.ToString
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
        Public Function Update(ByVal OldNit As String, ByVal OldTDoc As String, _
        ByVal OldDver As String, ByVal TER_TDOC As String, ByVal TER_NIT As String, ByVal TER_DVER As String, _
     ByVal TER_NOM As String, ByVal TER_TIP As String, ByVal TER_MPIO As String, _
     ByVal TER_EMAI As String, ByVal TER_TEL As String, ByVal TER_DIR As String, _
     ByVal TER_CED As String, ByVal TER_REP As String, ByVal TER_USU As String, ByVal TER_TUS As String, _
     ByVal TER_EST As String, ByVal TER_OBS As String, Optional ByVal TER_REP_EXP As String = "") As String

            Dim dig As String
            Me.Conectar()
            Try
                ComenzarTransaccion()
                'If OldDver <> "" Then
                '    dig = "' and TER_DVER='" + OldDver + "'"
                'Else
                '    dig = "'"
                'End If
                dig = "'"
                If String.IsNullOrEmpty(TER_REP_EXP) Then
                    Me.querystring = "UPDATE TERCEROS SET TER_TDOC=:TER_TDOC, TER_NIT=:TER_NIT, TER_DVER=:TER_DVER, TER_NOM=:TER_NOM, TER_TIP=:TER_TIP, TER_MPIO=:TER_MPIO, TER_EMAI=:TER_EMAI, TER_TEL=:TER_TEL, TER_DIR=:TER_DIR, TER_CED=:TER_CED, TER_REP=:TER_REP, TER_USU=:TER_USU, TER_TUS=:TER_TUS, TER_FNOV=SYSDATE, TER_EST=:TER_EST, TER_OBS=:TER_OBS, TER_USAP=:TER_USAP, TER_USBD=USER WHERE TER_NIT='" + OldNit + "' and TER_TDOC='" + OldTDoc + dig
                Else
                    Me.querystring = "UPDATE TERCEROS SET TER_TDOC=:TER_TDOC, TER_NIT=:TER_NIT, TER_DVER=:TER_DVER, TER_NOM=:TER_NOM, TER_TIP=:TER_TIP, TER_MPIO=:TER_MPIO, TER_EMAI=:TER_EMAI, TER_TEL=:TER_TEL, TER_DIR=:TER_DIR, TER_CED=:TER_CED, TER_REP=:TER_REP, TER_USU=:TER_USU, TER_TUS=:TER_TUS, TER_FNOV=SYSDATE, TER_EST=:TER_EST, TER_OBS=:TER_OBS, TER_USAP=:TER_USAP, TER_USBD=USER, TER_REP_EXP = :TER_REP_EXP WHERE TER_NIT='" + OldNit + "' and TER_TDOC='" + OldTDoc + dig
                End If
                CrearComando(querystring)
                'Throw New Exception(Me.vComando.CommandText)
                AsignarParametroCadena(":TER_TDOC", TER_TDOC)
                AsignarParametroCadena(":TER_NIT", TER_NIT)
                AsignarParametroCadena(":TER_DVER", TER_DVER)
                AsignarParametroCadena(":TER_NOM", TER_NOM)
                AsignarParametroCadena(":TER_TIP", TER_TIP)
                AsignarParametroCadena(":TER_MPIO", TER_MPIO)
                AsignarParametroCadena(":TER_EMAI", TER_EMAI)
                AsignarParametroCadena(":TER_TEL", TER_TEL)
                AsignarParametroCadena(":TER_DIR", TER_DIR)
                AsignarParametroCadena(":TER_CED", TER_CED)
                AsignarParametroCadena(":TER_REP", TER_REP)
                AsignarParametroCadena(":TER_USU", TER_USU)
                AsignarParametroCadena(":TER_TUS", TER_TUS)
                'dbCommand.Parameters.Add("TER_FREG", OracleDbType.Varchar2, ParameterDirection.Input).Value = SYSDATE
                ' dbCommand.Parameters.Add("TER_FNOV", OracleDbType.Varchar2, ParameterDirection.Input).Value =
                'dbCommand.Parameters.Add("TER_FFIN", OracleDbType.Varchar2, ParameterDirection.Input).Value =
                AsignarParametroCadena(":TER_EST", TER_EST)
                AsignarParametroCadena(":TER_OBS", TER_OBS)
                AsignarParametroCadena(":TER_USAP", Me.usuario)
                If Not String.IsNullOrEmpty(TER_REP_EXP) Then
                    AsignarParametroCadena(":TER_REP_EXP", TER_REP_EXP)
                End If

                num_reg = EjecutarComando()

                'Dim objmn As DBMenu = New DBMenu
                'If TER_TUS = "AR" Then
                'objmn.AsigPerfilUser("AGENTER", TER_NIT)
                'End If

                Me.Msg = MsgOk + " Registros Actualizados [" + num_reg.ToString + "]"
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

        Public Function Inactivar(ByVal TER_NIT As String, ByVal TER_TDOC As String, ByVal TER_DVER As String, ByVal TER_EST As String, ByVal TER_OBS As String) As String
            'Dim x As String

            'If (CInt(COD) = 1) Or (CInt(COD) = 2) Or (CInt(COD) = 3) Then
            'Return "Esta Clase de Impuesto, No se puede eliminar"
            'End If
            Me.Conectar()
            Try
                ComenzarTransaccion()
                Me.querystring = "UPDATE TERCEROS SET  TER_EST=:TER_EST, TER_OBS=:TER_OBS, TER_FFIN=SYSDATE, TER_USAP=:TER_USAP, TER_USBD=USER WHERE TER_NIT=" + TER_NIT + " and TER_TDOC=" + TER_TDOC + " and TER_DVER=" + TER_DVER
                CrearComando(querystring)
                AsignarParametroCadena(":TER_EST", "IN")
                AsignarParametroCadena(":TER_OBS", TER_OBS)
                AsignarParametroCadena(":TER_USAP", Membership.GetUser().UserName)
                ' dbCommand.CommandText = "DELETE IMPUESTOS WHERE IMP_COD='" + IMP_COD + "'"
                num_reg = EjecutarComando()
                Me.Msg = MsgOk + " # Registros Eliminados:" + num_reg.ToString
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
        Public Function Delete(ByVal TER_NIT As String) As String
            'Dim x As String

            'If (CInt(COD) = 1) Or (CInt(COD) = 2) Or (CInt(COD) = 3) Then
            'Return "Esta Clase de Impuesto, No se puede eliminar"
            'End If
            Me.Conectar()
            Try
                ComenzarTransaccion()
                Me.querystring = "DELETE TERCEROS WHERE TER_NIT='" + TER_NIT + "'"
                CrearComando(querystring)
                num_reg = EjecutarComando()
                Me.Msg = MsgOk + " # Registros Eliminados:" + num_reg.ToString
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
            Me.querystring = "SELECT * FROM VTERCEROS "
            CrearComando(querystring)
            Dim dataTb As DataTable = EjecutarConsultaDataTable()
            Me.Desconectar()
            Return dataTb
        End Function
        <DataObjectMethodAttribute(DataObjectMethodType.Select, True)> _
        Public Overloads Function GetRecords(ByVal busc As String, ByVal tipo As String) As DataTable

            Me.Conectar()
            '++++++++++ TIPO: 
            '** AR -> AGENTE RECAUDADOR
            '** RT -> RENTAS
            '** OT -> OTRO - PD o P
            '**
            Dim tp As String = "OT"
            If (tipo = "AR") Or (tipo = "RT") Then
                tp = tipo
            End If
            If busc <> "" Then
                If tipo = "" Then
                    Me.querystring = "SELECT * FROM VTERCEROS WHERE TER_EST='AC' And (ter_nit like '%" + busc + "%') OR (upper(ter_nom) like '%" + UCase(busc) + "%') "
                Else
                    Me.querystring = "SELECT * FROM VTERCEROS WHERE TER_EST='AC' And (ter_nit like '%" + busc + "%') OR (upper(ter_nom) like '%" + UCase(busc) + "%') and ter_tus='" + tp + "'"
                End If
            Else
                Me.querystring = "SELECT * FROM VTERCEROS WHERE 1<>1"
            End If
            CrearComando(querystring)
            Dim dataTb As DataTable = EjecutarConsultaDataTable()
            Me.Desconectar()
            Return dataTb
        End Function
        <DataObjectMethodAttribute(DataObjectMethodType.Select, True)> _
        Public Overloads Function GetRecords(ByVal busc As String) As DataTable
            Me.Conectar()
            Me.querystring = "SELECT * FROM VTERCEROS WHERE (ter_nit like '%" + busc + "%') OR (upper(ter_nom) like '%" + UCase(busc) + "%')"
            CrearComando(querystring)
            Dim dataTb As DataTable = EjecutarConsultaDataTable()
            Me.Desconectar()
            Return dataTb
        End Function
        <DataObjectMethodAttribute(DataObjectMethodType.Select, True)> _
        Public Function GetByTer(ByVal TER_NIT As String, ByVal TER_MUN As String, ByVal TER_NOM As String, ByVal TER_TDOC As String) As DataTable
            Me.Conectar()
            Me.querystring = "SELECT * FROM vTERCEROS WHERE TER_NIT='" + TER_NIT + "'"
            CrearComando(querystring)
            Dim dataTb As DataTable = EjecutarConsultaDataTable()
            Me.Desconectar()
            Return dataTb
        End Function
        <DataObjectMethodAttribute(DataObjectMethodType.Select, True)> _
        Public Overloads Function GetByIde(ByVal IDE As String) As DataTable
            Me.Conectar()
            querystring = "SELECT * FROM vTerceros WHERE Ter_NIT='" + IDE + "'"
            CrearComando(querystring)
            Dim dataTb As DataTable = EjecutarConsultaDataTable()
            Me.Desconectar()
            Return dataTb
        End Function

        Public Overloads Function GetByIde(ByVal Nit As String, ByVal DV As String, ByVal TUS As String) As DataTable
            Me.Conectar()
            querystring = "SELECT * FROM vTerceros WHERE Ter_NIT='" + Nit + "' And Ter_Dver='" + DV + "' And Ter_TUs='" + TUS + "'"
            CrearComando(querystring)
            'Throw New Exception(Me.vComando.CommandText)
            Dim dataTb As DataTable = EjecutarConsultaDataTable()
            Me.Desconectar()
            Return dataTb
        End Function


        Public Function GetAgentesSinUsuario() As DataTable
            Me.Conectar()
            querystring = "Select * from vAgentesSinUsuario"
            CrearComando(querystring)
            Dim dataTb As DataTable = EjecutarConsultaDataTable()
            Me.Desconectar()
            Return dataTb
        End Function

        <DataObjectMethodAttribute(DataObjectMethodType.Select, True)> _
        Public Overloads Function GetByUser(Optional ByVal User As String = "") As DataTable

            'Si no recibe ningún Usuario, buscará los Datos del Usuario Conectado

            If User = "" Then
                User = Me.usuario
            End If

            Me.Conectar()
            querystring = "SELECT * FROM vTerceros WHERE ter_est='AC' And upper(Ter_usu)='" + UCase(User) + "'"
            CrearComando(querystring)
            Dim dataTb As DataTable = EjecutarConsultaDataTable()
            Me.Desconectar()
            Return dataTb

        End Function




        Public Function DigitoNIT(ByVal sNit As String) As String
            On Error Resume Next
            '<-- Devuelve el Digito de verificación del NIT.
            Dim sTMP, sTmp1, sTMP2 As String
            Dim DigitoNIT0 As String = ""
            Dim i As Integer
            Dim iResiduo As Integer
            Dim iChequeo As Integer
            Dim iPrimos(15) As Integer '<- Defino el Arreglo de los Primos.
            iPrimos(1) = 3 : iPrimos(2) = 7 : iPrimos(3) = 13 : iPrimos(4) = 17 : iPrimos(5) = 19
            iPrimos(6) = 23 : iPrimos(7) = 29 : iPrimos(8) = 37 : iPrimos(9) = 41 : iPrimos(10) = 43
            iPrimos(11) = 47 : iPrimos(12) = 53 : iPrimos(13) = 59 : iPrimos(14) = 67 : iPrimos(15) = 71
            iChequeo = 0 : iResiduo = 0
            For i = 0 To Len(Trim(sNit)) - 1
                sTMP = Mid(sNit, Len(Trim(sNit)) - i, 1)
                iChequeo = iChequeo + (Val(sTMP) * iPrimos(i + 1))
                'MsgBox Val(sTmp), vbCritical, iPrimos(i + 1)
            Next i
            iResiduo = iChequeo Mod 11
            If iResiduo <= 1 Then
                If iResiduo = 0 Then DigitoNIT = 0
                If iResiduo = 1 Then DigitoNIT = 1
            Else
                DigitoNIT0 = 11 - iResiduo
            End If
            Return DigitoNIT0
            'MsgBox DigitoNIT
            'By GeNeTiKo
        End Function


    End Class


End Namespace