Imports Microsoft.VisualBasic
Imports System.ComponentModel
Imports System.Data

Public Class Vh_ParqueAutomotor
    Inherits BDDatos2

    Public PLACA As String
    Public CLASE As String
    Public MARCA As String
    Public LINEA As String
    Public MODELO As String
    Public COLOR As String
    Public CARROCERIA As String
    Public CILINDRAJE As String
    Public TONELAJE As String
    Public PASAJEROS As String
    Public MOTOR As String
    Public CHASIS As String
    Public BLINDADO As String
    Public ANTIGUO As String
    Public NIT As String
    Public FECHA_COMPRA As String
    Public MUN_MATRICULA As String
    Public MUN_OPERACION As String
    Public FECHA_MAT As String
    Public TIPO_MATRICULA As String
    Public VALOR_FACT As String
    Public ESTADO As String
    Public FECHA_INGRESO As String
    Public PARQ_USAP As String
    Public PARQ_USBD As String
    Public PARQ_FREG As String
    Public FEC_EXP_TP As String
    Public VINS_CODIGO As String
    Public IMPORTADO As String
    Public USO As String
    Public CATEGORIA As String

    Public Function Insert() As String
        Dim na As String
        Me.Conectar()
        Try
            ComenzarTransaccion()
            Me.querystring = "INSERT INTO VH_PARQUE_AUTOMOTOR(PLACA, CLASE, MARCA, LINEA, MODELO, COLOR, CARROCERIA, CILINDRAJE, TONELAJE, PASAJEROS, MOTOR, CHASIS, BLINDADO, ANTIGUO, NIT, FECHA_COMPRA, MUN_MATRICULA, MUN_OPERACION, FECHA_MAT, TIPO_MATRICULA, VALOR_FACT, ESTADO, FECHA_INGRESO, FEC_EXP_TP, VINS_CODIGO, IMPORTADO, USO, CATEGORIA) "
            Me.querystring += " VALUES(:PLACA, :CLASE, :MARCA, :LINEA, :MODELO, :COLOR, :CARROCERIA, :CILINDRAJE, :TONELAJE, :PASAJEROS, :MOTOR, :CHASIS, :BLINDADO, :ANTIGUO, :NIT, :FECHA_COMPRA, :MUN_MATRICULA, :MUN_OPERACION, :FECHA_MAT, :TIPO_MATRICULA, :VALOR_FACT, :ESTADO, :FECHA_INGRESO, :FEC_EXP_TP, :VINS_CODIGO, :IMPORTADO, :USO, :CATEGORIA)"
            CrearComando(querystring)
            AsignarParametroCadena(":PLACA", UCase(PLACA))
            AsignarParametroCadena(":CLASE", UCase(CLASE))
            AsignarParametroCadena(":MARCA", UCase(MARCA))
            AsignarParametroCadena(":LINEA", UCase(LINEA))
            AsignarParametroCadena(":MODELO", UCase(MODELO))
            AsignarParametroCadena(":COLOR", UCase(COLOR))
            AsignarParametroCadena(":CARROCERIA", UCase(CARROCERIA))
            AsignarParametroCadena(":CILINDRAJE", UCase(CILINDRAJE))
            AsignarParametroCadena(":TONELAJE", UCase(TONELAJE))
            AsignarParametroCadena(":PASAJEROS", UCase(PASAJEROS))
            AsignarParametroCadena(":MOTOR", UCase(MOTOR))
            AsignarParametroCadena(":CHASIS", UCase(CHASIS))
            AsignarParametroCadena(":BLINDADO", UCase(BLINDADO))
            AsignarParametroCadena(":ANTIGUO", UCase(ANTIGUO))
            AsignarParametroCadena(":NIT", UCase(NIT))
            AsignarParametroCadena(":FECHA_COMPRA", FECHA_COMPRA)
            AsignarParametroCadena(":MUN_MATRICULA", MUN_MATRICULA)
            AsignarParametroCadena(":MUN_OPERACION", MUN_OPERACION)
            AsignarParametroCadena(":FECHA_MAT", FECHA_MAT)
            AsignarParametroCadena(":TIPO_MATRICULA", TIPO_MATRICULA)
            AsignarParametroCadena(":VALOR_FACT", VALOR_FACT)
            AsignarParametroCadena(":ESTADO", ESTADO)
            AsignarParametroCadena(":FECHA_INGRESO", FECHA_INGRESO)
            AsignarParametroCadena(":FEC_EXP_TP", FEC_EXP_TP)
            AsignarParametroCadena(":VINS_CODIGO", VINS_CODIGO)
            AsignarParametroCadena(":IMPORTADO", UCase(IMPORTADO))
            AsignarParametroCadena(":USO", UCase(USO))
            AsignarParametroCadena(":CATEGORIA", CATEGORIA)
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

    Public Function Traslado() As String
        Dim na As String
        Me.Conectar()
        Try
            ComenzarTransaccion()
            Me.querystring = "UPDATE VH_PARQUE_AUTOMOTOR SET  MUN_MATRICULA = :MUN_MATRICULA , MUN_OPERACION = :MUN_OPERACION, ESTADO = :ESTADO "
            Me.querystring += " WHERE PLACA = :PLACA"
            CrearComando(querystring)
            AsignarParametroCadena(":PLACA", UCase(PLACA))
            AsignarParametroCadena(":MUN_MATRICULA", MUN_MATRICULA)
            AsignarParametroCadena(":MUN_OPERACION", MUN_OPERACION)
            AsignarParametroCadena(":ESTADO", ESTADO)
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

    Public Function Update() As String
        Dim na As String
        Me.Conectar()
        Try
            ComenzarTransaccion()
            Me.querystring = "UPDATE VH_PARQUE_AUTOMOTOR SET CLASE = :CLASE, MARCA = :MARCA, LINEA = :LINEA, MODELO = :MODELO, COLOR = :COLOR , "
            Me.querystring += " CARROCERIA =:CARROCERIA, CILINDRAJE = :CILINDRAJE, TONELAJE = :TONELAJE, PASAJEROS = :PASAJEROS, MOTOR = :MOTOR, "
            Me.querystring += " CHASIS = :CHASIS, BLINDADO = :BLINDADO, ANTIGUO = :ANTIGUO, NIT = :NIT, FECHA_COMPRA = :FECHA_COMPRA, MUN_MATRICULA = :MUN_MATRICULA, "
            Me.querystring += " MUN_OPERACION = :MUN_OPERACION, FECHA_MAT = :FECHA_MAT, TIPO_MATRICULA = :TIPO_MATRICULA, VALOR_FACT = :VALOR_FACT, "
            Me.querystring += " ESTADO = :ESTADO, FECHA_INGRESO = :FECHA_INGRESO, FEC_EXP_TP = :FEC_EXP_TP, VINS_CODIGO = :VINS_CODIGO, IMPORTADO = :IMPORTADO, USO = :USO, CATEGORIA = :CATEGORIA"
            Me.querystring += " WHERE PLACA = :PLACA"
            CrearComando(querystring)
            AsignarParametroCadena(":PLACA", UCase(PLACA))
            AsignarParametroCadena(":CLASE", UCase(CLASE))
            AsignarParametroCadena(":MARCA", UCase(MARCA))
            AsignarParametroCadena(":LINEA", UCase(LINEA))
            AsignarParametroCadena(":MODELO", UCase(MODELO))
            AsignarParametroCadena(":COLOR", UCase(COLOR))
            AsignarParametroCadena(":CARROCERIA", UCase(CARROCERIA))
            AsignarParametroCadena(":CILINDRAJE", UCase(CILINDRAJE))
            AsignarParametroCadena(":TONELAJE", UCase(TONELAJE))
            AsignarParametroCadena(":PASAJEROS", UCase(PASAJEROS))
            AsignarParametroCadena(":MOTOR", UCase(MOTOR))
            AsignarParametroCadena(":CHASIS", UCase(CHASIS))
            AsignarParametroCadena(":BLINDADO", UCase(BLINDADO))
            AsignarParametroCadena(":ANTIGUO", UCase(ANTIGUO))
            AsignarParametroCadena(":NIT", UCase(NIT))
            AsignarParametroCadena(":FECHA_COMPRA", FECHA_COMPRA)
            AsignarParametroCadena(":MUN_MATRICULA", MUN_MATRICULA)
            AsignarParametroCadena(":MUN_OPERACION", MUN_OPERACION)
            AsignarParametroCadena(":FECHA_MAT", FECHA_MAT)
            AsignarParametroCadena(":TIPO_MATRICULA", TIPO_MATRICULA)
            AsignarParametroCadena(":VALOR_FACT", VALOR_FACT)
            AsignarParametroCadena(":ESTADO", ESTADO)
            AsignarParametroCadena(":FECHA_INGRESO", FECHA_INGRESO)
            AsignarParametroCadena(":FEC_EXP_TP", FEC_EXP_TP)
            AsignarParametroCadena(":VINS_CODIGO", VINS_CODIGO)
            AsignarParametroCadena(":IMPORTADO", UCase(IMPORTADO))
            AsignarParametroCadena(":USO", UCase(USO))
            AsignarParametroCadena(":CATEGORIA", CATEGORIA)
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

    <DataObjectMethodAttribute(DataObjectMethodType.Select, True)> _
    Public Function GetPorPlaca(ByVal PLACA As String) As DataTable
        Me.Conectar()
        Me.querystring = "SELECT * FROM vVH_PARQUE_AUTOMOTOR WHERE PLACA = :PLACA"
        CrearComando(querystring)
        AsignarParametroCadena(":PLACA", PLACA)
        Dim dataTb As DataTable = EjecutarConsultaDataTable()
        Me.Desconectar()
        Return dataTb

    End Function
End Class
