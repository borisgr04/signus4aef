Imports System.IO
Imports System.Data

Partial Class Declaraciones_Cargar_pagos_cargar_pagos
    Inherits PaginaComun
    Dim lote As String
    Dim obs As String = ""
    Private Function Copiar_Archivo() As String
        Dim sw As Boolean
        Dim str As String = ""
        Dim Nom_Archivo As String = Me.RUTA_DOC_TMP + "aso.txt" 'obj.Nombre_Archivo()
        sw = Cargar_Archivo.Guardar_Archivo(Me.FileUpload1, Nom_Archivo)

        'Dim reader As New MemoryStream(Me.FileUpload1.PostedFile.InputStream())


        Dim cg As New Cargar_Pagos
        cg.RutaArchivo = Nom_Archivo
        'Me.Label1.Text = Cargar_Archivo.MsgResult + cg.LeerArchivo()
        'Me.Label1.Text = reader.ReadLine() 'cg.LeerArchivo()
        'Me.Label1.Text = cg.LeerArchivo()
        'Me.MsgBoxV(Me.Label1, Not sw)
        ' Me.Label1.Visible = True

        '1. CARGAR EL FILE UPLOAD Y GUARDARLO EN UN REGISTRO DE LA BD (Me.FileUpload1.PostedFile.InputStream() A BYE()), TABLA PPAL
        '2. RECUPERARLO Y VALIDARLO Y MOSTRARLO (SE PODRIA EXPORTAR A TXT O INTERPRETARLO
        '3. SE REGISTRA CADA PAGO EN REGSITRO DE UNA TABLA PAGOS_ASOBANCARIA (ESTADO PENDIENTE)(TABLA DETALLES)
        '4. SE APLICA CADA PAGO EN UNA TRANSACCION POR SEPARADO Y SE GUARDA EL LOG (INDICANDO LOS ERRORES QUE PUEDAN PASAR)


        str = cg.LeerArchivo()
        Label1.Text = cg.MsgComparacion
        lote = cg.Lote()
        Return str

    End Function

    Protected Sub Button1_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles ImageButton1.Click
        If FileUpload1.HasFile = False Then
            Label1.Text = "Debe seleccionar un archivo para Cargar Pagos"
            Label1.Visible = True
            MsgBox(Label1, True)
            Exit Sub
        End If
        Me.Label1.Text = ""
        Dim dt2 As DataTable = Me.CreateDSDeclaracion()
        Me.Label1.CssClass = ""
        Me.GridView1.DataBind()
        Dim pagos As String
        Dim Vpagos() As String = {}
        Dim Det_Pagos() As String = {}
        pagos = Copiar_Archivo()
        If pagos = "0" Then
            Label1.Text += "El Archivo no superó el proceso de validación. La suma de los pagos no coincide con el valor del archivo"
            Label1.Visible = True
            MsgBox(Label1, True)
            'ElseIf pagos = "1" Then
            '    Label1.Text = "El archivo de Lote " + lote + " ya fue cargado en el sistema"
            '    Label1.Visible = True
            '    MsgBox(Label1, True)
        Else
            Vpagos = Split(pagos, "<li>")
            Dim ObjRd As Pagos = New Pagos
            ObjRd.InsertCtrl(Me.lote, Me.TxtObs.Text, Me.FileUpload1)
            For i As Integer = 1 To Vpagos.Length - 1
                Det_Pagos = Split(Vpagos(i), ";")
                Me.Label1.Text = Det_Pagos(0) & "-" & Det_Pagos(1) & "-" & Det_Pagos(2) & "-" & Det_Pagos(6) & "-" & Det_Pagos(4) & "-" & Det_Pagos(5)
                'Me.Label1.Text += "<li>" + ObjRd.Radicar(Det_Pagos(0), Trim(Det_Pagos(1)), Det_Pagos(2), Det_Pagos(6), Det_Pagos(4), Det_Pagos(5)) + "<li>"
                Dim dr As DataRow
                dr = dt2.NewRow()
                dr("N_FORMULARIO") = Trim(Det_Pagos(1))
                'dr("des_gasto") = row("des_gasto")
                dr("VR_DECLARACION") = Trim(Det_Pagos(3))
                obs = ObjRd.Radicar(CDec(Trim(Det_Pagos(3))), Trim(Det_Pagos(1)), Det_Pagos(2), "S", CInt(Det_Pagos(4)).ToString, Det_Pagos(5))
                dr("OBSERVACION") = obs
                dt2.Rows.Add(dr)
                ObjRd.InsertLog(Me.lote, obs)
            Next
            Me.GridView1.DataSource = dt2
            Me.GridView1.DataBind()
            Label1.Text = "Se realizó la Operacion Exitosamente. Revise el LOG para ver los Detalles"
            Label1.Visible = True
            MsgBox(Label1, False)
            Me.TxtObs.Text = ""
        End If
        'Me.Label1.Text = Copiar_Archivo()
        'Me.Label1.Visible = True
    End Sub
    Protected Function CreateDSDeclaracion() As DataTable
        Dim dt As DataTable = New DataTable()
        Dim dtc As DataColumn = New DataColumn()
        dtc.DataType = System.Type.GetType("System.String")
        dtc.ColumnName = "N_FORMULARIO"
        dt.Columns.Add(dtc)
        dt.Columns.Add("VR_DECLARACION", System.Type.GetType("System.String"))
        dt.Columns.Add("OBSERVACION", System.Type.GetType("System.String"))
        Dim keys(0) As DataColumn
        keys(0) = dtc
        dt.PrimaryKey = keys
        dt.AcceptChanges()



        Return dt


    End Function

    Public Overrides Sub VerifyRenderingInServerForm(ByVal control As Control)

    End Sub

    Protected Sub BtnIExcel_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles BtnIExcel.Click
        If GridView1.Rows.Count = 0 Then
            Exit Sub
        End If
        ExportGridView(GridView1, "Pago")
    End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Me.Opcion = "Cargue de Pagos"
        Me.SetTitulo()
    End Sub
End Class
