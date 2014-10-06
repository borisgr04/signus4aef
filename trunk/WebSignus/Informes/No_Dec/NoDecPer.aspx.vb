Imports System.Web.UI.WebControls
Imports System.Web.UI.WebControls.WebParts
Imports System.Web.UI.HtmlControls
Imports Microsoft.Reporting.WebForms
Imports AjaxControlToolkit
Imports system.data
Imports System.Collections.Generic
Partial Class Informes_Default
    Inherits PaginaComun

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        ' Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim mn As New DBMenu
        Dim u As New Usuarios
        'Dim p As String = u.GetPerfil(Context.User.Identity.Name)
        'Welcome.Text = "Hello, " & Context.User.Identity.Name + "perfil : " + p
        Me.Opcion = " Inicio de Sesión "
        If Not IsPostBack Then
            Me.MultiView1.ActiveViewIndex = -1
        End If

        Me.SetTitulo()
        'Me.TextBox1.Attributes.Add("OnMouseOver", "with (document.aspnetForm.ctl00_SampleContent_TextBox1.style) { this.originalBgColor=borderColor;borderColor='#999999'; borderWidth = '1px'; borderStyle = 'solid';}")
        'Me.TextBox1.Attributes.Add("OnMouseOver", "with (document.aspnetForm.ctl00_SampleContent_TextBox1.style) { borderColor=this.originalBgColor; borderWidth = '1px'; borderStyle = 'solid';}")

    End Sub

    Public Sub Cargar_Rpt()

        'ENVIAR PARAMETROS
        Dim rptParam As ReportParameter = New ReportParameter("Titulo", Me.CMBCLADEC.SelectedItem.Text)
        Dim rptParam1 As ReportParameter = New ReportParameter("Ano_Grav", Me.CMBANO.SelectedItem.Text)
        'LIsta de Parametros
        Dim paramList As New List(Of ReportParameter)
        'Agregar Parametro a Lista
        paramList.Add(rptParam)
        paramList.Add(rptParam1)
        ' Actualizar Report
        Rptview.LocalReport.SetParameters(paramList)


        'ACTUALIZAR DATASET
        Rptview.LocalReport.ReportPath = "Report\Consultas\NoDecPer.rdlc"
        Dim dtSource As ReportDataSource = New ReportDataSource("DsPorPer_DTPOR_PER", GetDatosP)
        Dim rptEntidad As New ReportDataSource("DtEntidad_ENTIDAD", Cargar_Logo())

        Rptview.LocalReport.DataSources.Clear()
        Rptview.LocalReport.DataSources.Add(dtSource)
        Rptview.LocalReport.DataSources.Add(rptEntidad)

        Rptview.LocalReport.Refresh()
        'Me.RenderReport(Me.ReportViewer1.LocalReport)
    End Sub

    Protected Sub BtnBuscar_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs)
        Cargar_Rpt()
        Me.MultiView1.ActiveViewIndex = 0
       
    End Sub
    Private Function GetDatosP() As DataTable
        Dim x As String = ""
        Dim dt As DataTable = New DataTable
        Dim obj As Informes = New Informes(Me.CMBCLADEC.SelectedValue)
        Dim m As String
        dt = obj.Get_NoDecPer(Me.CMBCLADEC.SelectedValue, Me.CMBANO.SelectedValue, Me.CMBMPIO.SelectedValue, x, m)
        If obj.lErrorG = True Then
            Me.MsgResult.Text = obj.Msg
        End If
        'Me.mensaje.Text = x
        Return dt
    End Function

    Protected Sub Btncancel_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs)
        Me.MultiView1.ActiveViewIndex = -1
    End Sub

    'Protected Function Cargar_Logo() As DataTable
    ' Dim ta As New DtEntidadTableAdapters.ENTIDADTableAdapter
    ' Dim dt As New DtEntidad.ENTIDADDataTable
    '     ta.Fill(dt)
    ' Dim row As DtEntidad.ENTIDADRow
    ' Dim Rut As String = Me.Img_Rpt'

    'For Each row In dt.Rows
    'Dim fsArchivo As New IO.FileStream(Rut + row.ENT_LOGO, IO.FileMode.Open, IO.FileAccess.Read)
    'Dim arregloBytes(fsArchivo.Length) As Byte
    '        fsArchivo.Read(arregloBytes, 0, fsArchivo.Length)
    '        fsArchivo.Close()
    '        row.ENT_IMG = arregloBytes
    '    Next
    '    Return dt
    'End Function
End Class
