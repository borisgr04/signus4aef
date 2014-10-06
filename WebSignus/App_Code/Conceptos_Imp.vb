Imports Microsoft.VisualBasic
Imports System.Data
Imports System.ComponentModel
Imports System

Public Class Conceptos_Imp
    Inherits BDDatos2

    Public Function Insert(ByVal COIM_CIMP As String, ByVal COIM_NOM As String, ByVal COIM_EST As String, ByVal COIM_PRI As String, ByVal COIM_TCON As String, ByVal COIM_TMOV As String) As String
        Dim na As Integer
        Me.Conectar()
        Try
            ComenzarTransaccion()

            Me.querystring = "INSERT INTO Conceptos_Imp(COIM_CIMP, COIM_COD,COIM_NOM, COIM_EST, COIM_PRI,COIM_TCON, COIM_TMOV,COIM_TARIFA)"
            Me.querystring += "VALUES(:COIM_CIMP, :COIM_COD,:COIM_NOM, :COIM_EST, :COIM_PRI,:COIM_TCON, :COIM_TMOV,0)"
            CrearComando(querystring)
            AsignarParametroCadena(":COIM_CIMP", COIM_CIMP)
            AsignarParametroCadena(":COIM_COD", Me.GenCons(COIM_CIMP))
            AsignarParametroCadena(":COIM_NOM", COIM_NOM)
            AsignarParametroCadena(":COIM_EST", COIM_EST)
            AsignarParametroCadena(":COIM_PRI", COIM_PRI)
            AsignarParametroCadena(":COIM_TCON", COIM_TCON)
            AsignarParametroCadena(":COIM_TMOV", COIM_TMOV)

            'dbCommand.Parameters.Add("USER_AP_CR", OracleDbType.Varchar2, ParameterDirection.Input).Value = Membership.GetUser().UserName

            na = EjecutarComando
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
    Public Function Update(ByVal IMP_COD As String, ByVal IMP_NOM As String, ByVal IMP_UNI As String, _
     ByVal IMP_BAR As String, ByVal IMP_NOR As String, ByVal IMP_ABR As String, ByVal IMP_FIN As Date, _
     ByVal IMP_FFI As Date, ByVal IMP_OBS As String) As String
        Dim na As String
        Me.Conectar()
        Try
            ComenzarTransaccion()
            Me.querystring = "UPDATE IMPUESTOS SET IMP_NOM=:IMP_NOM,IMP_UNI=:IMP_UNI,IMP_OBS=:IMP_OBS,IMP_NOR=:IMP_NOR,IMP_BAR=:IMP_BAR,IMP_ABR=:IMP_ABR,IMP_FIN=:IMP_FIN,IMP_FFI=:IMP_FFI,USER_AP_MD=:USER_AP_MD WHERE IMP_COD='" + IMP_COD + "'"
            'AsignarParametroCadena("IMP_COD", OracleDbType.Varchar2, ParameterDirection.Input).Value = IMP_COD.Trim
            AsignarParametroCadena(":IMP_NOM", IMP_NOM)
            AsignarParametroCadena(":IMP_UNI", IMP_UNI)
            AsignarParametroCadena(":IMP_OBS", IMP_OBS)
            AsignarParametroCadena(":IMP_NOR", IMP_NOR)
            AsignarParametroCadena(":IMP_BAR", IMP_BAR)
            AsignarParametroCadena(":IMP_ABR", IMP_ABR)
            AsignarParametroFecha(":IMP_FIN", IMP_FIN)
            AsignarParametroFecha(":IMP_FFI", IMP_FFI)
            AsignarParametroCadena(":USER_AP_CR", Membership.GetUser().UserName)

            na = EjecutarComando
            Me.Msg = MsgOk + " Registros Actualizados [" + na + "]"
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

    Public Function Delete(ByVal COIM_COD As String) As String
        Dim x As String

        Me.Conectar()
        Try
            ComenzarTransaccion()

            Me.querystring = "DELETE CONCEPTOS_IMP WHERE COIM_COD='" + COIM_COD + "'"
            CrearComando(querystring)
            x = EjecutarComando()
            Me.Msg = MsgOk + " # Registros Eliminados:" + x.ToString
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
        Dim queryString As String = "SELECT * FROM vImpuestos "
        CrearComando(queryString)
        Dim dataTb As DataTable = EjecutarConsultaDataTable()
        Me.Desconectar()
        Return dataTb

    End Function

    <DataObjectMethodAttribute(DataObjectMethodType.Select, True)> _
    Public Overloads Function GetByImpuesto(ByVal imp_cod As String) As DataTable
        Me.Conectar()
        Dim queryString As String = "SELECT * FROM vConceptos_Imp WHERE COIM_CIMP='" + imp_cod + "' Order by to_number(COIM_COD) Asc"
        CrearComando(queryString)
        Dim dataTb As DataTable = EjecutarConsultaDataTable()
        Me.Desconectar()
        Return dataTb

    End Function
    <DataObjectMethodAttribute(DataObjectMethodType.Select, True)> _
    Public Overloads Function GetByIde(ByVal COIM_COD As String) As DataTable

        Me.Conectar()
        Dim queryString As String = "SELECT * FROM vCONCEPTOS_IMP WHERE COIM_COD='" + COIM_COD + "'"
        CrearComando(queryString)
        Dim dataTb As DataTable = EjecutarConsultaDataTable()
        Me.Desconectar()
        Return dataTb

    End Function

    Private Overloads Function UltID() As String

        'Me.Conectar
        Dim queryString As String = ""
        '= "SELECT max(clim_codi) FROM CLASE_IMPTO"
        CrearComando(queryString)
        Dim r As String = Convert.ToString(EjecutarEscalar())
        'Me.Desconectar()
        Return r

    End Function

    Public Function GenCons(ByVal COIM_CIMP As String) As String
        Dim queryString As String = "SELECT to_number(substr(COIM_COD,6,2)) cons  FROM Conceptos_Imp  Where COIM_CIMP= :COIM_CIMP Order By to_number(substr(coim_cod,6,2)) desc"
        CrearComando(queryString)
        AsignarParametroCadena(":COIM_CIMP", COIM_CIMP)
        Dim c As New Object, cod As String = ""
        Dim datat As DataTable = EjecutarConsultaDataTable()
        If datat.Rows.Count > 0 Then
            c = CInt(datat.Rows(0)("cons").ToString) + 1
        Else
            c = 1
        End If
        Return (COIM_CIMP + c.ToString.PadLeft(2, "0"))
    End Function
End Class


