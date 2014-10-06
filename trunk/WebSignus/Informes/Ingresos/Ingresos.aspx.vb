Imports System.Web.UI.WebControls
Imports System.Web.UI.WebControls.WebParts
Imports System.Web.UI.HtmlControls
Imports Microsoft.Reporting.WebForms
Imports AjaxControlToolkit
Imports system.data
Imports System.Collections.Generic
Partial Class Informes_Ingresos
    Inherits PaginaComun


    Protected Sub BtnBuscar_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs)
        Cargar_Rpt()
        Me.MultiView1.ActiveViewIndex = 0
    End Sub
    Public Sub Cargar_Rpt()
        'Dim rptParam As ReportParameter = New ReportParameter("Titulo", Me.CMBCLADEC.SelectedItem.Text)
        'Dim rptParam1 = New ReportParameter("Ano_Grav", Me.CMBANO.SelectedItem.Text)
        'LIsta de Parametros
        'Dim paramList As New List(Of ReportParameter)
        'Agregar Parametro a Lista
        ' paramList.Add(rptParam)
        'paramList.Add(rptParam1)
        ' Actualizar Report
        'Rptview.LocalReport.SetParameters(paramList)

        Rptview.LocalReport.ReportPath = "Report\Consultas\RptIngresos.rdlc"
        Dim dtSource As ReportDataSource = New ReportDataSource("DtIngresos_VINGRESOS", GetDatosP)
        Dim rptEntidad As New ReportDataSource("DtEntidad_ENTIDAD", Cargar_Logo())
        Rptview.LocalReport.DataSources.Clear()
        Rptview.LocalReport.DataSources.Add(dtSource)
        Rptview.LocalReport.DataSources.Add(rptEntidad)
        Rptview.LocalReport.Refresh()
        'Me.RenderReport(Me.ReportViewer1.LocalReport)

    End Sub
    Private Function GetDatosP() As DataTable
        Dim dt As DataTable = New DataTable
        Dim VMPIO As String = ""
        Dim vCDEC As String = ""
        Dim vANO As String = ""
        Dim vPER As String = ""
        Dim vCTA As String = ""
        Dim vBCO As String = ""
        Dim vFI As Date
        Dim vFF As Date
        Dim vCONC As String = ""
        Dim obj As Informes = New Informes(Me.CMBCLADEC.SelectedValue)
        Dim vsQuery As String = ""


        If Me.CBCLA.Checked = True Then
            vCDEC = Me.CMBCLADEC.SelectedValue
        End If

        If Me.CBANO.Checked = True Then
            vANO = Me.CMBANO.SelectedValue
            vPER = Me.CMBPER.SelectedValue
        End If

        If Me.CBCTA.Checked = True Then
            vCTA = Me.CMBCTA.SelectedValue
            vBCO = Me.CMBBCO.SelectedValue
        End If
        If Me.CBFEC.Checked = True Then
            If IsDate(Me.TFI.Text) Then
                vFI = Me.TFI.Text
            Else
                MsgResult.Text = "Digite una Fecha Valida"
            End If
            If IsDate(Me.TFF.Text) Then
                vFF = Me.TFF.Text
            Else
                MsgResult.Text = "Digite una Fecha Valida"
            End If
        End If
        If Me.CBMPIO.Checked = True Then
            VMPIO = Me.CMBMPIO.SelectedValue
        End If

        If Me.CBCON.Checked = True Then
            vCONC = Me.CMBCON.SelectedValue
        End If

        dt = obj.Get_Ingresos(vCDEC, vPER, vANO, vCTA, vBCO, vCONC, vFI, vFF, Me.CBFEC.Checked, VMPIO, vsQuery)
        'Me.LabelX.Text = obj.x
        If obj.lErrorG = True Then
            Me.MsgResult.Text = obj.Msg
        End If
        'Me.GridView1.DataSource = dt
        'Me.GridView1.DataBind()


        Return dt
    End Function

    Protected Sub Btncancel_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs)
        Me.MultiView1.ActiveViewIndex = -1
    End Sub

    Protected Sub CBFEC_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs)

    End Sub
    ' Protected Function Cargar_Logo() As DataTable
    ' Dim ta As New DtEntidadTableAdapters.ENTIDADTableAdapter
    ' Dim dt As New DtEntidad.ENTIDADDataTable
    '     ta.Fill(dt)
    ' Dim row As DtEntidad.ENTIDADRow
    ' Dim Rut As String = Me.Img_Rpt'

    'For Each row In dt.Rows
    'Dim fsArchivo As New IO.FileStream(Rut + row.ENT_LOGO, IO.FileMode.Open, IO.FileAccess.Read)
    'Dim arregloBytes(fsArchivo.Length) As Byte
    '        fsArchivo.Read(arregloBytes, 0, fsArchivo.Length)
    '       fsArchivo.Close()
    '       row.ENT_IMG = arregloBytes
    '   Next
    '   Return dt
    'End Function

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Me.Opcion = Me.Tit.Text
        Me.SetTitulo()
        If Not Me.IsPostBack Then
            Dim fecha As Date = Now
            Dim ndias As Integer = Date.DaysInMonth(Now.Year, Now.Month)
            Me.TFI.Text = "01/" + CStr(Now.Month) + "/" + CStr(Year(Now()))
            Me.TFF.Text = CStr(ndias) + "/" + CStr(Now.Month) + "/" + CStr(Year(Now()))
        End If
    End Sub

    Protected Sub CBCLA_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs)
        If Me.CBCLA.Checked = True Then
            Me.CBCON.Checked = False
        End If
    End Sub

    Protected Sub ObjCalVigencias_Selecting(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.ObjectDataSourceSelectingEventArgs) Handles ObjCalVigencias.Selecting

    End Sub
End Class
