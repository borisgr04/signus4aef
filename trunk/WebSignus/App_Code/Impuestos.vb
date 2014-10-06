Imports Microsoft.VisualBasic
Imports System.Data
Imports System.ComponentModel
Imports System

Public Class Impuestos
    Inherits BDDatos2

    Public Function Insert(ByVal IMP_CLA As String, ByVal IMP_NOM As String, ByVal IMP_UNI As String, _
     ByVal IMP_BAR As String, ByVal IMP_NOR As String, ByVal IMP_ABR As String, ByVal IMP_FIN As Date, _
     ByVal IMP_FFI As Date, ByVal IMP_OBS As String) As String
        Dim na As Integer
        Me.Conectar()
        Try
            ComenzarTransaccion()

            Me.querystring = "INSERT INTO IMPUESTOS(IMP_COD, IMP_NOM,IMP_UNI, IMP_OBS, IMP_NOR, IMP_BAR, IMP_CLA,IMP_ABR,IMP_FIN,IMP_FFI,USER_AP_CR)"
            Me.querystring += "VALUES(:IMP_COD, :IMP_NOM,:IMP_UNI, :IMP_OBS, :IMP_NOR, :IMP_BAR,:IMP_CLA,:IMP_ABR,:IMP_FIN,:IMP_FFI,:USER_AP_CR)"
            CrearComando(querystring)
            AsignarParametroCadena(":IMP_CODI", Me.GenCons(IMP_CLA))
            AsignarParametroCadena(":IMP_NOM", IMP_NOM)
            AsignarParametroCadena(":IMP_UNI", IMP_UNI)
            AsignarParametroCadena(":IMP_OBS", IMP_OBS)
            AsignarParametroCadena(":IMP_NOR", IMP_NOR)
            AsignarParametroCadena(":IMP_BAR", IMP_BAR)
            AsignarParametroCadena(":IMP_CLA", IMP_CLA)
            AsignarParametroCadena(":IMP_ABR", IMP_ABR)
            AsignarParametroFecha(":IMP_FIN", IMP_FIN)
            AsignarParametroFecha(":IMP_FFI", IMP_FFI)
            AsignarParametroCadena(":USER_AP_CR", Membership.GetUser().UserName)

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
    Public Function Update(ByVal IMP_COD As String, ByVal IMP_NOM As String, ByVal IMP_UNI As String, _
     ByVal IMP_BAR As String, ByVal IMP_NOR As String, ByVal IMP_ABR As String, ByVal IMP_FIN As Date, _
     ByVal IMP_FFI As Date, ByVal IMP_OBS As String) As String
        Dim na As String
        Me.Conectar()
        Try
            ComenzarTransaccion()
            Me.querystring = "UPDATE IMPUESTOS SET IMP_NOM=:IMP_NOM,IMP_UNI=:IMP_UNI,IMP_OBS=:IMP_OBS,IMP_NOR=:IMP_NOR,IMP_BAR=:IMP_BAR,IMP_ABR=:IMP_ABR,IMP_FIN=:IMP_FIN,IMP_FFI=:IMP_FFI,USER_AP_MD=:USER_AP_MD WHERE IMP_COD='" + IMP_COD + "'"
            CrearComando(querystring)
            'AsignarParametroCadena("IMP_COD",  IMP_COD.Trim
            AsignarParametroCadena(":IMP_NOM", IMP_NOM)
            AsignarParametroCadena(":IMP_UNI", IMP_UNI)
            AsignarParametroCadena(":IMP_OBS", IMP_OBS)
            AsignarParametroCadena(":IMP_NOR", IMP_NOR)
            AsignarParametroCadena(":IMP_BAR", IMP_BAR)
            AsignarParametroCadena(":IMP_ABR", IMP_ABR)
            AsignarParametroFecha(":IMP_FIN", IMP_FIN)
            AsignarParametroFecha(":IMP_FFI", IMP_FFI)
            AsignarParametroCadena(":USER_AP_CR", Membership.GetUser().UserName)

            na = EjecutarComando()
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

    Public Function Delete(ByVal IMP_COD As String) As String
        Dim x As String

        'If (CInt(COD) = 1) Or (CInt(COD) = 2) Or (CInt(COD) = 3) Then
        'Return "Esta Clase de Impuesto, No se puede eliminar"
        'End If
        Me.Conectar()
        Try
            ComenzarTransaccion()

            Me.querystring = "DELETE IMPUESTOS WHERE IMP_COD='" + IMP_COD + "'"
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
        Dim queryString As String = "SELECT * FROM vImpuestos Order by imp_cod"
        CrearComando(queryString)
        Dim dataTb As DataTable = EjecutarConsultaDataTable()
        Me.Desconectar()
        Return dataTb

    End Function

    <DataObjectMethodAttribute(DataObjectMethodType.Select, True)> _
    Public Function GetByCLASE(ByVal imp_cla As String) As DataTable
        Me.Conectar()
        Dim queryString As String = "SELECT * FROM vImpuestos WHERE IMP_CLA='" + imp_cla + "' Order by Imp_cod"
        CrearComando(queryString)
        Dim dataTb As DataTable = EjecutarConsultaDataTable()
        Me.Desconectar()
        Return dataTb

    End Function
    <DataObjectMethodAttribute(DataObjectMethodType.Select, True)> _
    Public Function GetParametros(ByVal imp_cod As String) As DataTable
        Me.Conectar()
        Dim queryString As String = "SELECT * FROM par_imp WHERE Par_cim='" + imp_cod + "'"
        CrearComando(queryString)
        Dim dataTb As DataTable = EjecutarConsultaDataTable()
        Me.Desconectar()
        Return dataTb

    End Function
    <DataObjectMethodAttribute(DataObjectMethodType.Select, True)> _
    Public Overloads Function GetByIde(ByVal IMP_COD As String) As DataTable

        Me.Conectar()
        Dim queryString As String = "SELECT * FROM vIMPUESTOS WHERE IMP_Cod='" + IMP_COD + "'"
        CrearComando(queryString)
        Dim dataTb As DataTable = EjecutarConsultaDataTable()
        Me.Desconectar()
        Return dataTb

    End Function
    <DataObjectMethodAttribute(DataObjectMethodType.Select, True)> _
    Public Overloads Function GetRecords(ByVal busc As String) As DataTable

        Me.Conectar()
        Dim queryString As String = "Select * From vImpuestos WHERE (Imp_Cod like '%" + busc + "%') OR (upper(Imp_Nom) like '%" + UCase(busc) + "%')"
        CrearComando(queryString)
        Dim dataTb As DataTable = EjecutarConsultaDataTable()
        Me.Desconectar()
        Return dataTb

    End Function



    Private Overloads Function UltID() As String

        'me.Conectar
        Dim queryString As String = ""
        '= "SELECT max(clim_codi) FROM CLASE_IMPTO"
        CrearComando(queryString)
        Dim r As String = Convert.ToString(EjecutarEscalar())
        'me.Desconectar()
        Return r

    End Function

    Public Function GenCons(ByVal Imp_Cla As String) As String

        Dim queryString As String = "SELECT to_number(substr(IMP_cod,3,3)) cons FROM Impuestos Where Imp_Cla=:Imp_Cla Order By to_number(substr(imp_cod,3,3)) desc"
        CrearComando(queryString)
        AsignarParametroCadena(":Imp_Cla", Imp_Cla)
        Dim c As New Object, cod As String = ""
        Dim datat As DataTable = EjecutarConsultaDataTable()
        If datat.Rows.Count > 0 Then
            c = CInt(datat.Rows(0)("cons").ToString) + 1
        Else
            c = 1
        End If
        Return (Imp_Cla + c.ToString.PadLeft(3, "0"))



    End Function

End Class


