Imports System.IO

Partial Class DatosBasicos_Plantillas_SubirPlantilla
    Inherits PaginaComun

    Protected Sub btSubir_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btSubir.Click
        Dim oPath As String = ""
        oPath = Util.ArchivoTemporal(".DOC")
        FuArchivo.SaveAs(oPath)
        Dim oFileStream As FileStream = New FileStream(oPath, FileMode.Open)
        Dim bR As New BinaryReader(oFileStream)
        Dim b() As Byte = bR.ReadBytes(oFileStream.Length)
        oFileStream.Close()
        Dim oPp As New Pplantillas
        oPp.ActualizaPlantilla(cmbPlantilla.SelectedValue, b)
        MsgResult.Text = oPp.Msg
        MsgBox1(MsgResult, oPp.lErrorG)
        File.Delete(oPath)
    End Sub
End Class
