Imports Microsoft.VisualBasic
Imports System.Data
Imports System.ComponentModel
'Clase para manejar la Tabla Menu de la Base de datos
'Fecha Creaciòn: 17 dic 2009
'Autor: Ronal Javier

' modificaco por BORIS GONZALEZ RIVERA
'20 AGOS 2011
' IMPLEMENTACION DE NUEVA DLL
<DataObjectAttribute()> _
Public Class Menudatos
    Inherits BDDatos2
    '---------------------------------------------------------------------------------------------------------------
    ' Funciòn Insert: Agrega datos a la tabla Menu

    Public Function Insert(ByVal MENUID As String, ByVal TITULO As String, ByVal DESCRIPCION As String, ByVal PADREID As String, ByVal POSICION As String, ByVal ICONO As String, ByVal HABILITADO As String, ByVal URL As String, ByVal MODULO As String, ByVal ROLES As String, ByVal TARGET As String, ByVal PPAL As String) As String

        Dim na As Integer
        Me.Conectar()
        Try
            ComenzarTransaccion()
            Me.querystring = "INSERT INTO Menu (MENUID,TITULO,DESCRIPCION,PADREID,POSICION,ICONO,HABILITADO,URL,MODULO,ROLES,TARGET,PPAL,USAP)VALUES(:MENUID,:TITULO,:DESCRIPCION,:PADREID,:POSICION,:ICONO,:HABILITADO,:URL,:MODULO,:ROLES,:TARGET,:PPAL,:USAP)"
            CrearComando(querystring)
            AsignarParametroCadena(":MENUID", MENUID)
            AsignarParametroCadena(":TITULO", TITULO)
            AsignarParametroCadena(":DESCRIPCION", DESCRIPCION)
            AsignarParametroCadena(":PADREID", PADREID)
            AsignarParametroCadena(":POSICION", POSICION)
            AsignarParametroCadena(":ICONO", ICONO)
            AsignarParametroCadena(":HABILITADO", HABILITADO)
            AsignarParametroCadena(":URL", URL)
            AsignarParametroCadena(":MODULO", MODULO)
            AsignarParametroCadena(":ROLES", ROLES)
            AsignarParametroCadena(":TARGET", TARGET)
            AsignarParametroCadena(":PPAL", PPAL)
            AsignarParametroCadena(":USAP", Me.usuario)
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
    ' Funciòn Actualizar: Actualiza datos a la tabla Menu

    Public Function Update(ByVal MENUID_or As String, ByVal MENUID As String, ByVal TITULO As String, ByVal DESCRIPCION As String, ByVal PADREID As String, ByVal POSICION As String, ByVal ICONO As String, ByVal HABILITADO As String, ByVal URL As String, ByVal MODULO As String, ByVal ROLES As String, ByVal TARGET As String, ByVal PPAL As String) As String
        Dim na As String
        Me.Conectar()
        Try
            ComenzarTransaccion()
            Me.querystring = "UPDATE Menu SET MENUID='" + MENUID + "',TITULO='" + TITULO + "',DESCRIPCION='" + DESCRIPCION + "',PADREID='" + PADREID + "',POSICION='" + POSICION + "',ICONO='" + ICONO + "',HABILITADO='" + HABILITADO + "',URL='" + URL + "',MODULO='" + MODULO + "',ROLES='" + ROLES + "',TARGET='" + TARGET + "',PPAL='" + PPAL + "' WHERE MENUID='" + MENUID_or + "'"
            CrearComando(querystring)
            na = EjecutarComando()
            Me.Msg = MsgOk + "<BR> Registros Actualizados [" + na + "]"
            ConfirmarTransaccion()
            Me.lErrorG = False
        Catch ex As Exception
            CancelarTransaccion()
            Me.lErrorG = True
            Me.Msg = "Error de App:" + ex.Message
        Finally
            Me.Desconectar()
        End Try

        Return Msg
    End Function
    ' Funciòn Delete: Borra datos a la tabla Menu

    Public Function Delete(ByVal MENUID As String) As String
        Dim na As String

        'If (CInt(COD) = 1) Or (CInt(COD) = 2) Or (CInt(COD) = 3) Then

        'Return "Esta Clase de Impuesto, No se puede eliminar"
        'End If
        Me.Conectar()
        Try
            ComenzarTransaccion()

            Me.querystring = "DELETE Menu WHERE MENUID='" + MENUID + "'"
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
        Dim queryString As String = "SELECT * FROM VMenuDATOS ORDER BY MENUID"
        CrearComando(queryString)
        Dim dataTb As DataTable = EjecutarConsultaDataTable()
        Me.Desconectar()
        Return dataTb
    End Function

    <DataObjectMethodAttribute(DataObjectMethodType.Select, True)> _
 Public Function GetOpciones() As DataTable
        Me.Conectar()
        Dim queryString As String = "SELECT * FROM VMenuDATOS ORDER BY MENUID"
        CrearComando(queryString)
        Dim dataTb As DataTable = EjecutarConsultaDataTable()
        Me.Desconectar()
        Return dataTb
    End Function

    <DataObjectMethodAttribute(DataObjectMethodType.Select, True)> _
    Public Overloads Function GetRecords(ByVal Filtro As String) As DataTable
        Me.Conectar()
        Dim queryString As String = "SELECT * FROM VMenuDATOS  Where 1=1 " + Filtro + " ORDER BY MENUID"
        CrearComando(queryString)
        Dim dataTb As DataTable = EjecutarConsultaDataTable()
        Me.Desconectar()
        Return dataTb

    End Function

    <DataObjectMethodAttribute(DataObjectMethodType.Select, True)> _
    Public Function GetOpciones(ByVal Filtro As String) As DataTable
        Me.Conectar()
        Dim queryString As String = "SELECT * FROM VMenuDATOS  Where 1=1 " + Filtro + " ORDER BY MENUID"
        CrearComando(queryString)
        Dim dataTb As DataTable = EjecutarConsultaDataTable()
        Me.Desconectar()
        Return dataTb

    End Function
    '+ 
    <DataObjectMethodAttribute(DataObjectMethodType.Select, True)> _
    Public Overloads Function GetPorCod(ByVal Cod As String) As DataTable
        Me.Conectar()
        Dim queryString As String = "SELECT * FROM Menu WHERE MENUID=:MENUID"
        CrearComando(queryString)
        AsignarParametroCadena(":MENUID", Cod)
        Dim dataTb As DataTable = EjecutarConsultaDataTable()
        Me.Desconectar()
        Return dataTb

    End Function


    Public Function GenerarRoles() As String
        Me.Conectar()
        Dim sroles As String = ""
        Dim queryString As String = "SELECT roles FROM Menu where lower(roles) Not In (SELECT lower(rolename) FROM ORA_ASPNET_ROLES) "
        CrearComando(queryString)

        Dim dataTb As DataTable = EjecutarConsultaDataTable()
        'If sw = False Then
        Me.Desconectar()
        'End If
        For i As Integer = 0 To dataTb.Rows.Count - 1
            Dim rol As String = dataTb.Rows(i)("ROLES").ToString.Trim
            If (Roles.RoleExists(rol) = False) Then
                Roles.CreateRole(rol)
                Roles.AddUserToRole("admin", rol)
                'sroles += sroles + " " + rol
            End If

        Next i
        Return sroles
    End Function

End Class
