Imports Microsoft.VisualBasic
Imports System.ComponentModel
Imports System.Data
Imports System

'Clase para manejar la Tabla Municipios de la Base de datos
'Fecha Creaciòn: 19 dic 2009
'Autor: Ronal Javier

Public Class Municipios
    Inherits BDDatos2
    '---------------------------------------------------------------------------------------------------------------
    ' Funciòn Insert: Agrega datos a la tabla Municipios

    Public Function Insert(ByVal MUN_COD As String, ByVal MUN_NOM As String, ByVal MUN_DPCO As String) As String


        Me.Conectar()
        Try
            Me.querystring = "INSERT INTO Municipios (MUN_COD,MUN_NOM,MUN_DPCO)VALUES(:MUN_COD,:MUN_NOM,:MUN_DPCO)"
            CrearComando(querystring)
            AsignarParametroCadena(":MUN_COD", MUN_COD)
            AsignarParametroCadena(":MUN_NOM", MUN_NOM)
            AsignarParametroCadena(":MUN_DPCO", MUN_DPCO)

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
    ' Funciòn Actualizar: Acatualiza datos a la tabla Municipios
    '    
    Public Function Update(ByVal MUN_COD_OR As String, ByVal MUN_COD As String, ByVal MUN_NOM As String, ByVal MUN_DPCO As String) As String
        Me.Conectar()
        Try
            Me.querystring = "UPDATE Municipios SET MUN_COD='" + MUN_COD + "',MUN_NOM='" + MUN_NOM + "' ,MUN_DPCO='" + MUN_DPCO + "' WHERE MUN_COD='" + MUN_COD_OR + "' "
            CrearComando(querystring)
            num_reg = EjecutarComando()
            Me.Msg = MsgOk + "<BR> Registros Actualizados [" + num_reg.ToString + "]"
            Me.lErrorG = False
        Catch ex As Exception
            Me.lErrorG = True
            Me.Msg = "Error de App:" + ex.Message
        Finally
            Me.Desconectar()
        End Try
        Return Msg
    End Function
    'Funciòn Delete: elimina datos a la tabla Municipios
    ' Parametros: Tcta_Codi : Còdigo

    Public Function Delete(ByVal MUN_COD As String) As String


        'If (CInt(COD) = 1) Or (CInt(COD) = 2) Or (CInt(COD) = 3) Then

        'Return "Esta Clase de Impuesto, No se puede eliminar"
        'End If
        Me.Conectar()
        Try
            querystring = "DELETE From Municipios WHERE MUN_COD='" + MUN_COD + "'"
            CrearComando(querystring)
            num_reg = EjecutarComando()
            Me.Msg = MsgOk + " # Registros Eliminados:" + num_reg.ToString
            Me.lErrorG = False
        Catch ex As Exception
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
        Me.querystring = "SELECT * FROM Municipios ORDER BY MUN_COD"
        CrearComando(querystring)
        Dim dataTb As DataTable = EjecutarConsultaDataTable()
        Me.Desconectar()
        Return dataTb
    End Function
    <DataObjectMethodAttribute(DataObjectMethodType.Select, True)> _
    Public Overloads Function GetPorCod(ByVal Cod As String) As DataTable
        Me.Conectar()
        querystring = "SELECT * FROM Municipios WHERE MUN_COD=:MUN_COD"
        CrearComando(querystring)
        AsignarParametroCadena(":MUN_COD", Cod)
        Dim dataTb As DataTable = EjecutarConsultaDataTable()
        Me.Desconectar()
        Return dataTb
    End Function




    <DataObjectMethodAttribute(DataObjectMethodType.Select, True)> _
    Public Overloads Function GetPorDpto(ByVal DpCo As String) As DataTable
        Me.Conectar()
        querystring = "SELECT * FROM MUNICIPIOS WHERE MUN_DPCO=:MUN_DPCO"
        CrearComando(querystring)
        AsignarParametroCadena(":MUN_DPCO", DpCo)
        Dim dataTb As DataTable = EjecutarConsultaDataTable()
        Me.Desconectar()
        Return dataTb
    End Function
End Class
