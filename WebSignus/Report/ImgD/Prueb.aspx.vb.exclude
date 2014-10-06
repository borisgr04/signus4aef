Imports Microsoft.Reporting.WebForms

Partial Class Report_ImgD_Prueb
    Inherits PaginaComun

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        'Fill the datasource from DB
        Dim ta As New DsTerTableAdapters.TERCEROSTableAdapter()
        Dim dt As New DsTer.TERCEROSDataTable()
        ta.Fill(dt)

        'Create an instance of Barcode Professional
        'Dim bcp As New Neodynamic.WebControls.BarcodeProfessional.BarcodeProfessional()
        'Barcode settings
        'bcp.Symbology = Neodynamic.WebControls.BarcodeProfessional.Symbology.Code128
        'bcp.BarHeight = 0.25F

        'Update DataTable with barcode image
        Dim row As DsTer.TERCEROSRow



        Dim fsArchivo As New IO.FileStream("E:\x\DERWEB\gen_img.jpg", IO.FileMode.Open, IO.FileAccess.Read)
        Dim arregloBytes(fsArchivo.Length) As Byte
        fsArchivo.Read(arregloBytes, 0, fsArchivo.Length)
        fsArchivo.Close()


        For Each row In dt.Rows
            'Set the value to encode
            'bcp.Code = row.ProductID.ToString()
            'Generate the barcode image and store it into the Barcode Column
            'row.Barcode = bcp.GetBarcodeImage(System.Drawing.Imaging.ImageFormat.Png)
            'me.Image1.
            row.TER_IMG = arregloBytes
            'ConvertImageToByteArray(arregloBytes, System.Drawing.Imaging.ImageFormat.Png)
        Next

        'Create Report Data Source
        Dim rptDataSource As New Microsoft.Reporting.WebForms.ReportDataSource("DsTer_TERCEROS", dt)

        Me.ReportViewer1.LocalReport.DataSources.Add(rptDataSource)
        'Me.ReportViewer1.LocalReport.ReportPath = Server.MapPath("BarcodeReport.rdlc")
        Me.ReportViewer1.LocalReport.Refresh()

    End Sub
End Class
