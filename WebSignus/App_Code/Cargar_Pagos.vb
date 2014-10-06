Imports Microsoft.VisualBasic
Imports System.IO
Imports System.Data

Structure Detalle_pagos
    Dim Tip_Reg As String
    Dim Ref_Ppal As String
    Dim Valor_Recaudo As String
    Dim Procedencia As String
    Dim Medios_Pago As String
    Dim No_Operacion As String
    Dim No_Autorizacion As String
    Dim Cod_Ent_Financiera As String
    Dim Cod_Sucursal As String
    Dim Secuencia As String
End Structure
Public Class Cargar_Pagos
    Inherits FmtosImp
    Dim Datos_Entidad(10, 2) As String
    Dim Detalle_Pago(,,) As String = {}
    Dim Ctrl_Lote(4, 2) As String
    Dim _Pagos(,) As String = {}
    Private _Lote As String
    Public MsgComparacion As String
    Property Lote() As String
        Get
            Return _Lote
        End Get
        Set(ByVal value As String)
            _Lote = value
        End Set
    End Property
    Public Overloads Function LeerArchivo() As String

        Dim StrArchivo As String = ""

        Dim fileName As String = RutaArchivo
        Dim stream As New FileStream(fileName, FileMode.Open, FileAccess.Read)
        Dim reader As New StreamReader(stream)
        'Crear la Data, de acuerdo al Formato de Importación Seleccionado

        'Me.dt = CrearTableBaseLiq()

        'Dim dtrow As DataRow
        Dim Registro As String
        'Dim Columnas As Integer = dt.Columns.Count
        Dim i As Integer = 1
        'Dim dtFmt As DataTable = Me.GetFormato()
        Msg = ""
        'Me.lError = False
        StrArchivo = ""
        Nro_Error = 0
        Dim NumLinea As Integer = 0
        Dim sw As Boolean = False
        '------------------------------

        '----------------------
        Dim TipoReg As String = ""
        Dim pos As Integer = 0
        Dim largo As Integer = 0
        Dim fila_reg As Integer = 0

        Dim DoAd As String = "DELP"
        Dim Fecha_Recaudo As Date
        Dim Banco_Cod As String
        Dim Banco_Cta As String
        Dim NFormulario As String
        Dim DEst As String = "S"
        Dim Valor As String
        Dim VrTotal As Decimal = 0.0
        Dim Vr_Archivo As Decimal = 0.0

        'LINEA
        Registro = reader.ReadLine()
        NumLinea += 1
        pos = 1
        largo = 2
        fila_reg += 1
        Datos_Entidad(fila_reg, 1) = "TIP_REG"
        Datos_Entidad(fila_reg, 2) = Mid(Registro, pos, largo)

        pos += largo
        largo = 10
        fila_reg += 1
        Datos_Entidad(fila_reg, 1) = "NIT"
        Datos_Entidad(fila_reg, 2) = Mid(Registro, pos, largo)

        pos += largo
        largo = 8
        fila_reg += 1
        Datos_Entidad(fila_reg, 1) = "Fec_Recaudo"
        Datos_Entidad(fila_reg, 2) = Mid(Registro, pos, largo)


        pos += largo
        largo = 3
        fila_reg += 1
        Datos_Entidad(fila_reg, 1) = "Cod_Ent_Rec"
        Datos_Entidad(fila_reg, 2) = Mid(Registro, pos, largo)
        'Codigo del Banco
        Banco_Cod = Mid(Registro, pos, largo)

        pos += largo
        largo = 17
        fila_reg += 1
        Datos_Entidad(fila_reg, 1) = "Num_Cta"
        Datos_Entidad(fila_reg, 2) = Mid(Registro, pos, largo)
        'N° de Cta Bancaria
        Banco_Cta = Mid(Registro, pos, largo)
        'Throw New Exception(Banco_Cta)
        pos += largo
        largo = 8
        fila_reg += 1
        Datos_Entidad(fila_reg, 1) = "Fec_Archivo"
        Datos_Entidad(fila_reg, 2) = Mid(Registro, pos, largo)
        Dim fec As String = Mid(Registro, pos, largo)
        ''Fecha 
        Fecha_Recaudo = CDate(Right(fec, 2) + "/" + Mid(fec, 5, 2) + "/" + Left(fec, 4))



        pos += largo
        largo = 1
        fila_reg += 1
        Datos_Entidad(fila_reg, 1) = "Mod_Archivo"
        Datos_Entidad(fila_reg, 2) = Mid(Registro, pos, largo)

        pos += largo
        largo = 2
        fila_reg += 1
        Datos_Entidad(fila_reg, 1) = "Tipo_Cta"
        Datos_Entidad(fila_reg, 2) = Mid(Registro, pos, largo)

        'LINEA2
        Registro = reader.ReadLine()
        NumLinea += 1


        Dim Encabezado_Lote(4, 2) As String

        pos = 1
        largo = 2
        fila_reg = 1
        Encabezado_Lote(fila_reg, 1) = "TIP_REG"
        Encabezado_Lote(fila_reg, 2) = Mid(Registro, pos, largo)

        pos += largo
        largo = 13
        fila_reg += 1
        Encabezado_Lote(fila_reg, 1) = "Cod_Servicio"
        Encabezado_Lote(fila_reg, 2) = Mid(Registro, pos, largo)

        pos += largo
        largo = 4
        fila_reg += 1
        Encabezado_Lote(fila_reg, 1) = "Num_Lote"
        Encabezado_Lote(fila_reg, 2) = Mid(Registro, pos, largo)
        _Lote = Banco_Cod & Mid(Registro, pos, largo)


        Dim str As String = "Matriz"
        fila_reg = 1
        Dim can_reg As Integer = 1
        Do While reader.Peek() > -1
            Registro = reader.ReadLine()

            pos = 1
            largo = 2
            fila_reg = 1
            TipoReg = Mid(Registro, pos, largo)
            If TipoReg <> "06" Then
                Exit Do
            End If
            ReDim Preserve Detalle_Pago(13, 2, can_reg + 1)
            Detalle_Pago(fila_reg, 1, can_reg) = "TIP_REG"
            Detalle_Pago(fila_reg, 2, can_reg) = TipoReg

            pos += largo
            largo = 48
            fila_reg += 1
            Detalle_Pago(fila_reg, 1, can_reg) = "REF_PPAL"
            Detalle_Pago(fila_reg, 2, can_reg) = Mid(Registro, pos, largo)
            NFormulario = Val(Mid(Registro, pos, largo)).ToString

            pos += largo
            largo = 14
            fila_reg += 1
            Detalle_Pago(fila_reg, 1, can_reg) = "VALOR_RECAUDO"
            Detalle_Pago(fila_reg, 2, can_reg) = Mid(Registro, pos, largo)
            Valor = Val(Mid(Registro, pos, largo).Insert(12, ".")).ToString
            VrTotal += CDec(Valor)

            pos += largo
            largo = 2
            fila_reg += 1
            Detalle_Pago(fila_reg, 1, can_reg) = "PROCEDENCIA"
            Detalle_Pago(fila_reg, 2, can_reg) = Mid(Registro, pos, largo)

            pos += largo
            largo = 2
            fila_reg += 1
            Detalle_Pago(fila_reg, 1, can_reg) = "MEDIOS_PAGO"
            Detalle_Pago(fila_reg, 2, can_reg) = Mid(Registro, pos, largo)

            pos += largo
            largo = 6
            fila_reg += 1
            Detalle_Pago(fila_reg, 1, can_reg) = "No_Operacion"
            Detalle_Pago(fila_reg, 2, can_reg) = Mid(Registro, pos, largo)

            pos += largo
            largo = 6
            fila_reg += 1
            Detalle_Pago(fila_reg, 1, can_reg) = "No_Autorizacion"
            Detalle_Pago(fila_reg, 2, can_reg) = Mid(Registro, pos, largo)

            pos += largo
            largo = 3
            fila_reg += 1
            Detalle_Pago(fila_reg, 1, can_reg) = "Cod_Ent_Fin"
            Detalle_Pago(fila_reg, 2, can_reg) = Mid(Registro, pos, largo)


            pos += largo
            largo = 4
            fila_reg += 1
            Detalle_Pago(fila_reg, 1, can_reg) = "Cod_Sucursal"
            Detalle_Pago(fila_reg, 2, can_reg) = Mid(Registro, pos, largo)

            pos += largo
            largo = 7
            fila_reg += 1
            Detalle_Pago(fila_reg, 1, can_reg) = "Secuencia"
            Detalle_Pago(fila_reg, 2, can_reg) = Mid(Registro, pos, largo)

            pos += largo
            largo = 3
            fila_reg += 1
            Detalle_Pago(fila_reg, 1, can_reg) = "Causal_Devolucion"
            Detalle_Pago(fila_reg, 2, can_reg) = Mid(Registro, pos, largo)

            'Dim Cod_Sucursal As String
            'Dim Secuencia As String


            'fila_reg = fila_reg + 1
            'str = fila_reg + TipoReg
            can_reg += 1

            str += "<li> DELP;" + NFormulario + ";" + Fecha_Recaudo.ToShortDateString + ";" + Valor + ";" + Banco_Cod + ";" + Banco_Cta + ";" + DEst + "</li>"
        Loop
        pos = 1
        largo = 2
        fila_reg = 1
        Ctrl_Lote(fila_reg, 1) = "TIPO_REG"
        Ctrl_Lote(fila_reg, 2) = Mid(Registro, pos, largo)
        fila_reg += 1

        pos += largo
        largo = 9
        Ctrl_Lote(fila_reg, 1) = "TOTAL_REGISTROS"
        Ctrl_Lote(fila_reg, 2) = Mid(Registro, pos, largo)
        fila_reg += 1

        pos += largo
        largo = 18
        Ctrl_Lote(fila_reg, 1) = "VALOR_TOTAL"
        Ctrl_Lote(fila_reg, 2) = Mid(Registro, pos, largo)

        Registro = reader.ReadLine()
        Dim Ctrl_Archivo(3, 2) As String
        pos = 1
        largo = 2
        fila_reg = 1
        Ctrl_Archivo(fila_reg, 1) = "TIPO_REG"
        Ctrl_Archivo(fila_reg, 2) = Mid(Registro, pos, largo)
        fila_reg += 1

        pos += largo
        largo = 9
        Ctrl_Archivo(fila_reg, 1) = "TOTAL_REGISTROS"
        Ctrl_Archivo(fila_reg, 2) = Mid(Registro, pos, largo)
        fila_reg += 1

        pos += largo
        largo = 18
        Ctrl_Archivo(fila_reg, 1) = "VALOR_TOTAL"
        Ctrl_Archivo(fila_reg, 2) = Mid(Registro, pos, largo)
        Vr_Archivo = Val(Mid(Registro, pos, largo).Insert(16, ".")).ToString

        'Throw New Exception(Vr_Archivo.ToString + "x" + VrTotal.ToString)
        reader.Close()


        'For f As Integer = 1 To 10
        '    str += "<li>" + Datos_Entidad(f, 1) + "--" + Datos_Entidad(f, 2) + "</li>"
        'Next

        'For f As Integer = 1 To 3
        '    str += "<li>" + Encabezado_Lote(f, 1) + "--" + Encabezado_Lote(f, 2) + "</li>"
        'Next

        'For k As Integer = 1 To UBound(Detalle_Pago, 3) - 1
        '    For f As Integer = 1 To 13
        '        str += "<li>" + Detalle_Pago(f, 1, k) + "--" + Detalle_Pago(f, 2, k) + "</li>"
        '    Next
        'Next

        'For f As Integer = 1 To 4
        '    str += "<li>" + Ctrl_Lote(f, 1) + "--" + Ctrl_Lote(f, 2) + "</li>"
        'Next

        'For f As Integer = 1 To 3
        '    str += "<li>" + Ctrl_Archivo(f, 1) + "--" + Ctrl_Archivo(f, 2) + "</li>"
        'Next
        'Validar Existencia del Nit cómo Agente Recuadador
        'If ValidarLote(Me.Lote) > 0 Then
        '    Return "1"
        'Else
        If Vr_Archivo <> VrTotal Then
            MsgComparacion = String.Format("El Valor del archivo {0} es y el Valor de la Sumatoria es {1}", Vr_Archivo, VrTotal)
            Return "0"
        Else
            Return str 'Not Me.lError
        End If
        'End If
        'Return Me.Lote
    End Function
    Public Function ValidarLote(ByVal lote As String) As Integer
        Me.Conectar()
        Me.querystring = "Select count(*) from Ctrl_Pagos where Num_Lote=:Num_Lote"
        CrearComando(querystring)
        Me.AsignarParametroCadena(":Num_Lote", lote)
        Dim dt As DataTable = EjecutarConsultaDataTable()
        Me.Desconectar()
        Return Val(dt.Rows(0).Item(0).ToString)
    End Function
End Class