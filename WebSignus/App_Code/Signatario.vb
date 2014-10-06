Imports Microsoft.VisualBasic
Imports System.Data
Imports System.ComponentModel
Imports System
Imports Signus

<System.ComponentModel.DataObject()> _
Public Class Signatario
    Inherits BDDatos2

    Public Function InsertSig(ByVal TER_TDOC As String, ByVal TER_NIT As String, _
       ByVal TER_NOM As String, ByVal TER_MPIO As String, _
       ByVal TER_EMAI As String, ByVal TER_TEL As String, ByVal TER_DIR As String, _
              ByVal TER_OBS As String) As String

        Dim TER_DVER As String = Util.ValidarDigitoVerificacion(TER_NIT)
        Dim TER_TIP As String = "00"
        Dim TER_TUS As String = "OT"
        Dim TER_EST As String = "AC"

        Dim obj As Terceros = New Terceros
        Me.Msg = obj.Insert(TER_TDOC, TER_NIT, TER_DVER, TER_NOM, TER_TIP, TER_MPIO, TER_EMAI, TER_TEL, TER_DIR, TER_NIT, TER_NOM, TER_NIT, TER_TUS, TER_EST, TER_OBS)
        Me.lErrorG = obj.lErrorG

        Return Msg

    End Function
    Public Function UpdateSig(ByVal PK As String, ByVal TER_TDOC As String, ByVal TER_NIT As String, _
       ByVal TER_NOM As String, ByVal TER_MPIO As String, _
       ByVal TER_EMAI As String, ByVal TER_TEL As String, ByVal TER_DIR As String, _
              ByVal TER_OBS As String) As String

        Dim TER_DVER As String = ""
        Dim TER_TIP As String = "00"
        Dim TER_TUS As String = "OT"
        Dim TER_EST As String = "AC"

        Dim obj As Terceros = New Terceros
        Dim DV As String = Util.ValidarDigitoVerificacion(TER_NIT)
        Me.Msg = obj.Update(PK, "CC", DV, TER_TDOC, TER_NIT, TER_DVER, TER_NOM, TER_TIP, TER_MPIO, TER_EMAI, TER_TEL, TER_DIR, TER_NIT, TER_NOM, TER_NIT, TER_TUS, TER_EST, TER_OBS)
        Me.lErrorG = obj.lErrorG
        Return Msg
    End Function
    Public Function InsertSig2(ByVal TER_TDOC As String, ByVal TER_NIT As String, _
       ByVal TER_NOM As String, ByVal TER_MPIO As String, _
       ByVal TER_EMAI As String, ByVal TER_TEL As String, ByVal TER_DIR As String, _
              ByVal TER_OBS As String) As String


        Me.Conectar()
        Try
            Me.querystring = "INSERT INTO TERCEROS(TER_TDOC, TER_NIT, TER_DVER, TER_NOM, TER_TIP, TER_MPIO, TER_EMAI, TER_TEL, TER_DIR, TER_CED, TER_REP, TER_USU, TER_TUS,TER_FREG, TER_FNOV,  TER_EST, TER_OBS, TER_USAP, TER_USBD )"
            Me.querystring += "VALUES(:TER_TDOC, :TER_NIT, :TER_DVER, :TER_NOM, :TER_TIP, :TER_MPIO, :TER_EMAI, :TER_TEL, :TER_DIR, :TER_CED, :TER_REP, :TER_USU, :TER_TUS,SYSDATE, SYSDATE,  :TER_EST, :TER_OBS, :TER_USAP, USER)"
            CrearComando(querystring)

            AsignarParametroCadena(":TER_TDOC", TER_TDOC)
            AsignarParametroCadena(":TER_NIT", TER_NIT)
            AsignarParametroCadena(":TER_DVER", "")
            AsignarParametroCadena(":TER_NOM", TER_NOM)
            AsignarParametroCadena(":TER_TIP", "00")
            AsignarParametroCadena(":TER_MPIO", TER_MPIO)
            AsignarParametroCadena(":TER_EMAI", TER_EMAI)
            AsignarParametroCadena(":TER_TEL", TER_TEL)
            AsignarParametroCadena(":TER_DIR", TER_DIR)
            AsignarParametroCadena(":TER_CED", TER_NIT)
            AsignarParametroCadena(":TER_REP", TER_NOM)
            AsignarParametroCadena(":TER_USU", TER_NIT)
            AsignarParametroCadena(":TER_TUS", "OT")
            'dbCommand.Parameters.Add("TER_FREG", OracleDbType.Varchar2, ParameterDirection.Input).Value = SYSDATE
            ' dbCommand.Parameters.Add("TER_FNOV", OracleDbType.Varchar2, ParameterDirection.Input).Value =
            'dbCommand.Parameters.Add("TER_FFIN", OracleDbType.Varchar2, ParameterDirection.Input).Value =
            AsignarParametroCadena(":TER_EST", "AC")
            AsignarParametroCadena(":TER_OBS", TER_OBS)
            AsignarParametroCadena(":TER_USAP", Me.usuario)
            'dbCommand.Parameters.Add("TER_USBD", OracleDbType.Varchar2, ParameterDirection.Input).Value = 

            num_reg = EjecutarComando()
            Me.Msg = MsgOk + "<BR> Número de Filas Afectadas " + num_reg.ToString
            Me.lErrorG = False
        Catch ex As Exception
            Me.lErrorG = True
            Me.Msg = "Error de App:" + ex.Message
        Finally
            Me.Desconectar()
        End Try

        Return Msg

    End Function
    Public Function Insert(ByVal REL_TDOC As String, ByVal REL_AGE As String, _
     ByVal REL_DVER As String, ByVal REL_TDOCREV As String, ByVal REL_REV As String, ByVal REL_TREV As String, _
     ByVal REL_TARPRO As String, ByVal REL_TDOCDEC As String, ByVal REL_DEC As String, ByVal REL_TDEC As String) As String

        Dim na As Integer
        Me.Conectar()
        'Try
        Me.querystring = "INSERT INTO RELA_AGETER( REL_TDOC, REL_AGE, REL_DVER,REL_TDOCREV, REL_REV,REL_TREV, REL_TARPRO, REL_TDOCDEC, REL_DEC, REL_TDEC,  REL_FNOV,  REL_USBD, REL_USAP)"
        Me.querystring += "VALUES( :REL_TDOC, :REL_AGE, :REL_DVER, :REL_TDOCREV, :REL_REV, :REL_TREV, :REL_TARPRO, :REL_TDOCDEC, :REL_DEC, :REL_TDEC,  SYSDATE,  USER, :REL_USAP)"

        CrearComando(querystring)
        AsignarParametroCadena(":REL_TDOC", REL_TDOC)
        AsignarParametroCadena(":REL_AGE", REL_AGE)
        AsignarParametroCadena(":REL_DVER", REL_DVER)

        AsignarParametroCadena(":REL_TDOCREV", REL_TDOCREV)
        AsignarParametroCadena(":REL_REV", REL_REV)
        AsignarParametroCadena(":REL_TREV", REL_TREV)
        AsignarParametroCadena(":REL_TARPRO", REL_TARPRO)

        AsignarParametroCadena(":REL_TDOCDEC", REL_TDOCDEC)
        AsignarParametroCadena(":REL_DEC", REL_DEC)
        AsignarParametroCadena(":REL_TDEC", REL_TDEC)


        'dbCommand.Parameters.Add("REL_EST", OracleDbType.Varchar2, ParameterDirection.Input).Value = REL_EST
        AsignarParametroCadena(":REL_USAP", Me.usuario)
        'Msg = dbCommand.CommandText
        num_reg = EjecutarComando()
        Me.Msg = MsgOk + "<BR> Número de Filas Afectadas " + na.ToString
        Me.lErrorG = False
        'Catch ex As Exception
        '    Me.lErrorG = True
        '    Me.Msg = "Error de App:" + ex.Message
        'Finally
        '    Me.Desconectar()
        'End Try

        Return Msg

    End Function

    <DataObjectMethodAttribute(DataObjectMethodType.Select, True)> _
    Public Overloads Function GetRecords(ByVal Nit As String) As DataTable
        Me.Conectar()
        querystring = "SELECT * FROM VSignatarios WHERE rel_age='" + Nit + "'"
        CrearComando(querystring)
        Dim dataTb As DataTable = EjecutarConsultaDataTable()
        Me.Desconectar()
        Return dataTb
    End Function



    Public Function update(ByVal OldNit As String, ByVal OldDver As String, ByVal REL_TDOC As String, ByVal REL_AGE As String, _
     ByVal REL_DVER As String, ByVal REL_TDOCREV As String, ByVal REL_REV As String, ByVal REL_TREV As String, _
     ByVal REL_TARPRO As String, ByVal REL_TDOCDEC As String, ByVal REL_DEC As String, ByVal REL_TDEC As String) As String

        'Dim na As Integer
        'Dim Dig As String
        Me.Conectar()
      Try
            '''' Se quitó Filtro.
            'If OldDver <> "" Then
            '    Dig = "' and REL_Dver='" + OldDver + "'"
            'Else
            '    Dig = "'"
            'End If
            'Dig = "'"
            querystring = "UPDATE RELA_AGETER SET REL_TDOC=:REL_TDOC, REL_AGE=:REL_AGE, REL_DVER=:REL_DVER, REL_TDOCREV=:REL_TDOCREV, REL_REV=:REL_REV, REL_TREV=:REL_TREV, REL_TARPRO=:REL_TARPRO, REL_TDOCDEC=:REL_TDOCDEC, REL_DEC=:REL_DEC, REL_TDEC=:REL_TDEC,   REL_USBD=USER,  REL_USAP=:REL_USAP, REL_FNOV=SYSDATE   WHERE REL_AGE='" + OldNit + "'"
            CrearComando(querystring)
            AsignarParametroCadena(":REL_TDOC", REL_TDOC)

            AsignarParametroCadena(":REL_AGE", REL_AGE)
            AsignarParametroCadena(":REL_DVER", REL_DVER)

            'Throw New Exception(Me.vComando.CommandText + "**" + REL_TDOCREV)

            AsignarParametroCadena(":REL_TDOCREV", REL_TDOCREV)

            AsignarParametroCadena(":REL_REV", REL_REV)

            AsignarParametroCadena(":REL_TREV", REL_TREV)

            AsignarParametroCadena(":REL_TARPRO", REL_TARPRO)

            AsignarParametroCadena(":REL_TDOCDEC", REL_TDOCDEC)
            AsignarParametroCadena(":REL_DEC", REL_DEC)
            AsignarParametroCadena(":REL_TDEC", REL_TDEC)
            'dbCommand.Parameters.Add("REL_EST", OracleDbType.Varchar2, ParameterDirection.Input).Value = REL_EST
            AsignarParametroCadena(":REL_USAP", Me.usuario)
            'Throw New Exception(Me.vComando.CommandText)
            num_reg = EjecutarComando()
            Me.Msg = MsgOk + "<BR> Número de Filas Afectadas " + num_reg.ToString
            Me.lErrorG = False
        Catch ex As Exception
            Me.lErrorG = True
            Me.Msg = "Error de App:" + ex.Message
        Finally
            Me.Desconectar()
        End Try

        Return Msg

    End Function
End Class