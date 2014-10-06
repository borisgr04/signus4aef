Imports Microsoft.VisualBasic
Imports System.Data
Imports System.Data.OleDb
Imports System.IO

Imports System

Public Class Cargar_Archivo
    Public Enum TipoDeArchivoPlano
        Delimited
        Fixed
    End Enum
    Shared TipoArch As TipoDeArchivoPlano
    Public Shared Msg As String
    Dim RutaCSV As String
    Dim lError As Boolean
    Public Property DirectorioCSV() As String
        Get
            Return RutaCSV
        End Get
        Set(ByVal value As String)
            RutaCSV = value
        End Set
    End Property

    Public ReadOnly Property Error_Import() As Boolean
        Get
            Return Me.lError
        End Get
    End Property

    Public Shared ReadOnly Property MsgResult() As String
        Get
            Return Msg
        End Get
    End Property

    Public Shared Function LeerArchivoPlano(ByVal archivo As FileInfo, Optional ByVal tieneEncabezado As Boolean = False, Optional ByVal tipoDeArchivo As TipoDeArchivoPlano = TipoDeArchivoPlano.Delimited) As DataTable
        If Not archivo.Exists Then
            Throw New FileNotFoundException("No se encontró el archivo especificado")
        End If
        Dim conEncabezado As String = IIf(tieneEncabezado, "YES", "NO")

        Dim connectionString As String = String.Format("Provider=Microsoft.Jet.OLEDB.4.0;Data Source={0};" & "Extended Properties='text;HDR={1};FMT={2}'", archivo.DirectoryName, conEncabezado, tipoDeArchivo.ToString())
        Dim dt As New DataTable("miTabla")
        Using conn As New OleDbConnection(connectionString)
            Using da As New OleDbDataAdapter("SELECT * FROM " & archivo.Name, conn)
                da.Fill(dt)
            End Using
        End Using

        Return dt
    End Function

    

    Public Shared Function ChecarExtension(ByVal fileName As String) As Boolean
        Dim ext As String = Path.GetExtension(fileName)
        Select Case ext.ToLower()
            Case ".txt"
                Return True
            Case Else
                Return False
        End Select
    End Function

    Public Shared Function Guardar_Archivo(ByVal FileUpload1 As FileUpload, ByVal Ruta As String) As Boolean
        Dim sw As Boolean = False
        If FileUpload1.HasFile Then
            If ChecarExtension(FileUpload1.FileName) Then
                Try
                    FileUpload1.SaveAs(Ruta)
                    Msg = " .... Cargado exitosamente <br>"
                    Msg += "Nombre de Archivo Cargado:  " + FileUpload1.PostedFile.FileName + "<br>"
                    Msg += "Tamaño :  " + (FileUpload1.PostedFile.ContentLength / 1024).ToString + "KB <br>"
                    Msg += "Tipo de Contenido: " + FileUpload1.PostedFile.ContentType.ToString + "<br>"
                    sw = True
                Catch ex As Exception
                    sw = False
                    Msg = "Ya existe archivo con ese Nombre<br>" + ex.Message
                End Try
            Else
                Msg = "El archivo seleccionado no es de extensión .Txt,verifique. La Extensión del Archivo cargado es :  " + Path.GetExtension(FileUpload1.FileName)
                sw = False
            End If
        Else
            Msg = "No seleccionó Ningún archivo"
        End If

        Return sw
    End Function
    
  
End Class

