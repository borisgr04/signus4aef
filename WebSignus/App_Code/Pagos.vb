Imports Microsoft.VisualBasic
Imports System.Data
Imports System.IO
Public Class Pagos
    Inherits BDDatos2
    Public Function Radicar(ByVal Valor As Decimal, ByVal Dec_Cod As String, ByVal Dec_FPre As Date, ByVal Dec_Est As String, ByVal Ban_Cod As String, ByVal Ban_Cta As String) As String
        Dim na As Integer
        Try
            Me.Conectar()
            Me.querystring = "registrarpago"
            CrearComando(querystring, CommandType.StoredProcedure)
            AsignarParametroCad("DCod", Dec_Cod)
            AsignarParametroFec("DFpre", Dec_FPre)
            AsignarParametroCad("DEst", Dec_Est)
            AsignarParametroCad("Ban_Cod", Ban_Cod)
            AsignarParametroCad("Ban_Cta", Ban_Cta)
            AsignarParametroCad("Valor", Valor)
            AsignarParametroCad("USAP", Me.usuario)
            na = EjecutarComando()
            Msg = "Se Registro el Pago correctamente"
        Catch ex As Exception
            Me.lErrorG = True
            Me.Msg = "Err: " + ex.Message
        Finally
            Me.Desconectar()
        End Try
        Return Msg
    End Function
    Public Function InsertCtrl(ByVal lote As String, ByVal Obs As String, ByVal fup As FileUpload) As String
        Me.Conectar()
        Dim success As Boolean = False
        Dim imgStream As Stream = fup.PostedFile.InputStream
        Dim imgLength As Integer = fup.PostedFile.ContentLength
        Dim imgContentType As String = fup.PostedFile.ContentType
        Dim imgFileName As String = fup.PostedFile.FileName
        'Dim Ext As String = Extraer(imgFileName, ".")
        'Try
        Dim ImageContent As [Byte]() = New Byte(imgLength - 1) {}
        Dim intStatus As Integer
        intStatus = imgStream.Read(ImageContent, 0, imgLength)


        Me.querystring = "Insert into Ctrl_Pagos(Num_Lote, Fecha_Subida, Observacion, USAP, Documento) Values(:Lote, :Fecha_Subida, :Observacion, :USAP, :DOCUMENTO)"
        CrearComando(querystring)
        Me.AsignarParametroCadena(":Lote", lote)
        Me.AsignarParametroBLOB(":DOCUMENTO", ImageContent)
        Me.AsignarParametroCadena(":Fecha_Subida", Today.ToShortDateString)
        Me.AsignarParametroCadena(":Observacion", Obs)
        Me.AsignarParametroCadena(":USAP", Me.usuario)
        EjecutarComando()
        Me.lErrorG = False
        'Catch ex As Exception
        Me.lErrorG = True
        Msg = "Err: " '+ ex.Message
        'Finally
        Me.Desconectar()
        'End Try
        Return Msg
    End Function
    Public Function InsertLog(ByVal Lote As String, ByVal Obs As String) As String
        Me.Conectar()
        'Try
        Me.querystring = "Insert into Log_Pago(Num_Lote, Observacion) Values(:Lote, :Observacion)"
        CrearComando(querystring)
        Me.AsignarParametroCadena(":Lote", Lote)
        Me.AsignarParametroCad(":Observacion", Obs)
        'Throw New Exception(Me.vComando.CommandText)
        EjecutarComando()
        Me.lErrorG = False
        'Catch ex As Exception
        Me.lErrorG = True
        Msg = "Err: " '+ 'ex.Message
        'Finally
        Me.Desconectar()
        'End Try
        Return Msg
    End Function
End Class
