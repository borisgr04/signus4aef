Imports Microsoft.VisualBasic
Imports System.Data
Imports System.Data.Common
Imports System.ComponentModel

Public Class Anulaciones
    Inherits BDDatos2
    Dim BD As BDDatos2 = New BDDatos2()
    Public NroAnulacion As String
    ' Dim num_reg As Integer = 0
    'Dim MsgOk As String = ""
    Public Function Insert(ByVal ANUL_TDAN As String, ByVal ANUL_TDOC As String, ByVal ANUL_NDOC As String, ByVal ANUL_OBSE As String) As String
        Me.Conectar()
        ComenzarTransaccion()
        Try
            'Me.querystring = "INSERT INTO ANULACIONES(ANUL_TDAN,ANUL_TDOC,ANUL_NDOC,ANUL_OBSE)VALUES(:ANUL_TDAN,:ANUL_TDOC,:ANUL_NDOC,:ANUL_OBSE)"
            querystring = "ANULAR_DOC"
            CrearComando(querystring, CommandType.StoredProcedure)
            Dim pReturn As DbParameter = AsignarParametroReturn(20)
            AsignarParametroCad("iANUL_TDAN", ANUL_TDAN)
            AsignarParametroCad("iANUL_TDOC", ANUL_TDOC)
            AsignarParametroCad("iANUL_NDOC", ANUL_NDOC)
            AsignarParametroCad("iANUL_OBSE", ANUL_OBSE)
            num_reg = EjecutarComando()
            NroAnulacion = pReturn.Value.ToString()
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
    Public Function InsertDesAn(ByVal ANUL_TDAN As String, ByVal ANUL_TDOC As String, ByVal ANUL_NDOC As String, ByVal ANUL_OBSE As String) As String
        Dim querystring As String = "ANULAR_DOC"
        Dim num_reg As Integer = 0
        BD.CrearComando(querystring, CommandType.StoredProcedure)
        Dim pReturn As DbParameter = BD.AsignarParametroReturn(20)
        BD.AsignarParametroCad("iANUL_TDAN", ANUL_TDAN)
        BD.AsignarParametroCad("iANUL_TDOC", ANUL_TDOC)
        BD.AsignarParametroCad("iANUL_NDOC", ANUL_NDOC)
        BD.AsignarParametroCad("iANUL_OBSE", ANUL_OBSE)
        num_reg = BD.EjecutarComando()
        NroAnulacion = pReturn.Value.ToString()
        BD.Msg = MsgOk + "<BR> Número de Filas Afectadas " + num_reg.ToString
        BD.lErrorG = False
        Return BD.Msg

    End Function
    <DataObjectMethodAttribute(DataObjectMethodType.Select, True)>
    Public Function Get_Nro_Anul(ByVal ANUL_NDOC As String) As String
        Dim DTtab As DataTable = New DataTable
        Dim querystring As String = ""
        Dim x As String
        querystring = "SELECT ANUL_NDAN FROM ANULACIONES WHERE ANUL_TDOC='DELP' AND  ANUL_TDAN='ALIQ' AND ANUL_NDOC=" + ANUL_NDOC
        BD.CrearComando(querystring)

        DTtab = BD.EjecutarConsultaDataTable
        BD.lErrorG = False
        x = DTtab.Rows(0)("ANUL_NDAN")
        Return x
    End Function

    '<DataObjectMethodAttribute(DataObjectMethodType.Select, True)>
    'Public Function Get_Cons_NDAN() As String
    '    Dim DTtab As DataTable = New DataTable
    '    Dim querystring As String = ""
    '    Dim x As String
    '    Try
    '        BD.Conectar()
    '        querystring = " SELECT sq_anul.NEXTVAL as ANUL_NDAN  FROM DUAL"
    '        BD.CrearComando(querystring)
    '        DTtab = BD.EjecutarConsultaDataTable
    '        BD.Desconectar()
    '        BD.lErrorG = False
    '    Catch ex As Exception
    '        BD.lErrorG = True
    '        BD.Msg = "Error de App:" + ex.Message
    '    Finally
    '        BD.Desconectar()
    '    End Try
    '    x = DTtab.Rows(0)("ANUL_NDAN")
    '    Return x
    'End Function



    <DataObjectMethodAttribute(DataObjectMethodType.Select, True)>
    Public Function uptadeEstDec(ByVal ANUL_NDOC As String) As String
        Dim na As Integer
        Dim querystring As String = ""
        querystring = "UPDATE DECLARACION SET DEC_EST='DC' WHERE DEC_COD=" + ANUL_NDOC
        BD.CrearComando(querystring)
        na = BD.EjecutarComando()
        BD.lErrorG = False
        BD.Msg = MsgOk + "<BR> Número de Filas Afectadas " + num_reg.ToString
        Return BD.Msg
    End Function




    Public Function InsertMovimiento(ByVal TDAN As String, ByVal ndan As String, ByVal tdoc As String, ByVal ndoc As String, ByVal pago As String) As String


        Dim querystring As String = "cart.anular_mov"
        BD.CrearComando(querystring, CommandType.StoredProcedure)
        'Dim pReturn As DbParameter = BD.AsignarParametroReturn(20)
        BD.AsignarParametroCad("tdan", TDAN)
        BD.AsignarParametroCad("ndan", ndan)
        BD.AsignarParametroCad("tdoc", tdoc)
        BD.AsignarParametroCad("ndoc", ndoc)
        BD.AsignarParametroCad("pag", pago)
        num_reg = BD.EjecutarComando()
        'NroAnulacion = pReturn.Value.ToString()
        BD.Msg = MsgOk + "<BR> Número de Filas Afectadas " + num_reg.ToString
        BD.lErrorG = False
        Return BD.Msg
    End Function



    Public Function DesAnular(ByVal ANUL_TDAN As String, ByVal ANUL_TDOC As String, ByVal NRO_DEC As String, ByVal ANUL_OBSE As String) As String
        Dim NroAnulDec As String
        BD.Conectar()
        BD.ComenzarTransaccion()
        
        Try
            NroAnulDec = Get_Nro_Anul(NRO_DEC)
            InsertDesAn(ANUL_TDAN, ANUL_TDOC, NroAnulDec, ANUL_OBSE)
            uptadeEstDec(NRO_DEC)
            InsertMovimiento(ANUL_TDAN, NroAnulacion, "ALIQ", NroAnulDec, "N")
            BD.Msg = MsgOk + "<BR> Número de Filas Afectadas " + num_reg.ToString
            BD.lErrorG = False
            BD.ConfirmarTransaccion()
        Catch ex As Exception
            BD.CancelarTransaccion()
            BD.lErrorG = True
            BD.Msg = "Error de App:" + ex.Message
        Finally
            BD.Desconectar()
        End Try
        Return BD.Msg
    End Function

End Class
