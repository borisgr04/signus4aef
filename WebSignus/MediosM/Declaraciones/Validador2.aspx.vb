Imports System.data
Imports System.IO

Partial Class MediosM_Declaraciones_Validador2
    Inherits PaginaComun
    Dim Ruta As String
    Dim RutaTmp As String
    Private md5Path As String = "E:\x\DerWeb\Exe\md5.exe" ' E:\Util2\
    Private Function Copiar_Archivo2() As Boolean
        Dim sw As Boolean = False
        If FileUpload1.HasFile Then
            If Cargar_Archivo.ChecarExtension(FileUpload1.FileName) Then

                Me.RutaTmp = ConfigurationManager.AppSettings("RUTA_DOC_TMP")
                Me.Ruta = ConfigurationManager.AppSettings("RUTA_DOC")
                Try
                    FileUpload1.SaveAs(Me.RutaTmp & Me.NombreA.Value)
                    Label1.Text = Me.NombreA.Value & " .... Cargado exitosamente <br>"
                    Label1.Text += "Nombre de Archivo Cargado:  " + Me.FileUpload1.FileName + "<br>"
                    Label1.Text += "Tamaño :  " + (Me.FileUpload1.PostedFile.ContentLength / 1024).ToString + "KB <br>"
                    Label1.Text += "Tipo de Contenido: " + Me.FileUpload1.PostedFile.ContentType.ToString + "<br>"
                    'lblOculto.Text = Me.Ruta & FileUpload1.FileName
                    'Label1.Text += "MD5 " + Generar_MD5(Me.NombreA.Value)
                    sw = True
                Catch ex As Exception
                    sw = False
                    Label1.Text = "Ya existe archivo con ese Nombre<br>"
                End Try
            End If
        Else
            Label1.Text = "Error al subir el archivo o no es el tipo .Txt"
            Me.MsgBox(Me.Label1, True)
            sw = False
        End If
        Return sw
    End Function

    Private Function Copiar_Archivo() As Boolean
        Dim sw As Boolean

        sw = Cargar_Archivo.Guardar_Archivo(Me.FileUpload1, Me.NombreA.Value)
        Me.Label1.Text = Cargar_Archivo.MsgResult
        Me.MsgBox(Me.Label1, Not sw)
        Return sw

    End Function

    'obj.RutaArchivo = "E:\x\DerWeb\Docs\20090102.txt"
    'GridView1.FooterRow.Cells(4).Text = String.Format("{0:C}", dt.Compute("sum(VALORIMPTO)", ""))

    Private Sub Validar_Archivo()
        Me.BtnExcel.Visible = False
        Me.Label1.Text = ""
        Me.Label1.CssClass = ""

        Dim obj As BasesLiq = New BasesLiq(Me.Nit.Text, Me.CbCdec.SelectedValue, Me.CboVigencia.SelectedValue, Me.Periodo.SelectedValue, CDate(Me.TxtFecha.Text))
        Dim dt As DataTable
        Me.NombreA.Value = Me.RUTA_DOC_TMP + obj.Nombre_Archivo()

        If Copiar_Archivo() Then
            obj.Codigo = Me.CboFormatos.SelectedValue
            obj.RutaArchivo = Me.NombreA.Value
            Dim sw As Boolean = obj.Validar()
            If sw = True Then
                Me.Label1.Text = "RADICADO:" + obj.Radicado.ToString
                'Me.Label1.Font.Size = 20
                dt = obj.TablaImp
                Dim ATmp As String = Me.NombreA.Value
                Dim ADoc As String = Me.RUTA_DOC & obj.Radicado.ToString + ".txt"
                Try
                    If File.Exists(ADoc) Then
                        File.Delete(ADoc)
                    End If
                    File.Move(ATmp, ADoc)
                Catch ex As Exception
                    Me.Label1.Text = "Error Archivo" + ex.Message
                    Exit Sub
                End Try
                Me.Label1.Text = obj.Msg
                Me.BtnExcel.Visible = True
                'Agrupar(dt)
                'Me.BtnExcel.Enabled = False
            Else
                Me.Label1.Text = obj.Msg
                Me.BtnExcel.Visible = True
                'Me.BtnExcel.Enabled = True
            End If
            Me.MsgBox(Me.Label1, Not sw)
            dt = obj.TablaImp
            '            dt.Columns.Remove("LOG_ERROR")
            GridViewS1.DataSource = dt
            GridViewS1.DataBind()
        End If

    End Sub

    '    <LINK REL="SHORTCUT ICON" HREF="http://images.midominio.com/ico/icono.ico">
    Protected Sub BrnValidar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BrnValidar.Click
        Me.Validar_Archivo()
    End Sub

    Public Sub Agrupar(ByVal dt As DataTable)
        'distinct 
        Dim distinctTable As DataTable = dt.DefaultView.ToTable(True, "IMPTO")
        Dim dtSummerized As New DataTable("SumaResult")
        Dim objimpto As Impuestos = New Impuestos
        dtSummerized.Columns.Add("No", GetType(String))
        dtSummerized.Columns.Add("Código", GetType(String))
        dtSummerized.Columns.Add("Impuesto", GetType(String))
        dtSummerized.Columns.Add("BaseGravable", GetType(String))
        dtSummerized.Columns.Add("Valor_Impuesto", GetType(String))
        Dim count As Integer = 0
        For Each dr As DataRow In distinctTable.Rows
            count += 1
            'Dim avg As String = dt.Compute("avg(amount)", "CustomerID =" & dr("CustomerID").ToString()).ToString()
            Dim dtimp As DataTable = objimpto.GetByIde(dr("IMPTO").ToString())

            Dim BaseGravable As String = FormatNumber(dt.Compute("sum(VALORBASE)", "IMPTO =" & dr("IMPTO").ToString()).ToString())
            Dim Impuesto As String = FormatNumber(dt.Compute("sum(VALORIMPTO)", "IMPTO =" & dr("IMPTO").ToString()).ToString())
            dtSummerized.Rows.Add(count, dr("IMPTO"), dtimp.Rows(0)("IMP_NOM").ToString, BaseGravable, Impuesto)
        Next
        GridView2.DataSource = dtSummerized
        GridView2.DataBind()
    End Sub


    Protected Sub button_Click(ByVal sender As Object, ByVal e As System.EventArgs)

    End Sub


    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Me.SetTitulo()
        Me.ToolkitScriptManager1.RegisterAsyncPostBackControl(Me.ConsultaTer1)
        If Not Me.IsPostBack Then
            Me.CbCdec.Attributes.Add("OnFocus", "javascript:UpdateCombo()")
            'Me.ROptTD.SelectedValue = "01"
            Dim dt As DataTable = Me.UsuTercero.GetByUser()
            '            Me.MsgResult.Text = dt.Rows(0)("Ter_TUS").ToString() + "-" + dt.Rows(0)("TUS_NOM").ToString()
            If (dt.Rows.Count > 0) Then
                If (dt.Rows(0)("Ter_TUS").ToString() = "AR") Then
                    Me.Agente.Text = dt.Rows(0)("Ter_Nom").ToString
                    Me.Nit.Text = dt.Rows(0)("Ter_nit").ToString
                    Me.Dv.Text = Trim(dt.Rows(0)("Ter_dver").ToString)
                    Me.TxtFecha.Text = Now.ToShortDateString
                    Me.TxtFecha.Enabled = False
                    Me.BtnBuscDP.Visible = False
                Else
                    Me.TxtFecha.Text = Now.ToShortDateString
                    Me.TxtFecha.Enabled = True
                    Me.BtnBuscDP.Visible = True
                End If
            End If
        End If

    End Sub

    Protected Sub BtnBuscDP_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        Me.ModalPopup.Show()
    End Sub

    Protected Sub BtnExcel_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnExcel.Click
        'Dim obj As BasesLiq = New BasesLiq(Me.Nit.Text, Me.CbCdec.SelectedValue, Me.CboVigencia.SelectedValue, Me.Periodo.SelectedValue, CDate(Me.TxtFecha.Text))
        'obj.Codigo = Me.CboFormatos.SelectedValue
        'obj.RutaArchivo = Me.lblOculto.Text
        'obj.Validar()
        'GridViewS1.DataSource = obj.TablaImp
        'GridViewS1.DataBind()
        ExportGridView(GridViewS1)
    End Sub


    Public Overrides Sub VerifyRenderingInServerForm(ByVal control As Control)

    End Sub

    Protected Sub GrdRad_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs)
        '        Me.Agente.Text = (Me.GrdRad.SelectedValue)
    End Sub

    Protected Sub Button1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button1.Click

    End Sub
End Class
