Imports System.IO
Imports System.Data

Partial Class Consultas_CuentaCorriente_ConCarteraD
    Inherits PaginaComun


    Protected Sub BtnExcel_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        ExportGridView()

    End Sub

    Private Overloads Sub ExportGridView()
        Dim attachment As String = "attachment; filename=Contacts.xls"
        Response.ClearContent()
        Response.AddHeader("content-disposition", attachment)
        Response.ContentType = "application/ms-excel"
        Dim sw As New StringWriter()
        Dim htw As New HtmlTextWriter(sw)
        Me.grConc.RenderControl(htw)
        Response.Write(sw.ToString())
        Response.End()
    End Sub
    Public Overrides Sub VerifyRenderingInServerForm(ByVal control As Control)

    End Sub


    Protected Sub BuscarNit_Click(ByVal sender As Object, ByVal e As System.EventArgs)

    End Sub

    Protected Sub button_Click(ByVal sender As Object, ByVal e As System.EventArgs)

    End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load


        '        Me.MsgResult.Text = ""

        '        Me.LBTITULO.Text = "Diligenciar Declararaciones "
        Me.SetTitulo()

        Me.ToolkitScriptManager1.RegisterAsyncPostBackControl(Me.ConsultaTer1)
        If Not Me.IsPostBack Then
            Dim dt As DataTable = Me.UsuTercero.GetByUser()
            If (dt.Rows.Count > 0) Then
                '        Me.Nit.Text = dt.Rows(0)("TER_NIT").ToString
                Me.Nit.Attributes.Add("onBlur", "javascript:MostrarNit()")
                dt = Me.UsuTercero.GetByUser()
                If (dt.Rows(0)("Ter_TUS").ToString() = "AR") Then
                    Me.Agente.Text = dt.Rows(0)("Ter_Nom").ToString
                    Me.Nit.Text = dt.Rows(0)("Ter_nit").ToString
                    Me.Dv.Text = Trim(dt.Rows(0)("Ter_dver").ToString)
                    Me.BtnBuscar.Visible = False
                Else
                    Me.BtnBuscar.Visible = True
                End If
            End If
        End If

    End Sub

    Protected Sub BtnBuscar_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        Me.ModalPopup.Show()
    End Sub

    Protected Sub CboTipo_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs)
        If Me.CboTipo.SelectedValue = "T" Then
            Me.MultiView1.ActiveViewIndex = 0
        Else
            Me.MultiView1.ActiveViewIndex = 1
        End If
        'Me.MultiView1.ActiveViewIndex = 1
    End Sub

    Protected Sub BtnVerMovA_Click(ByVal sender As Object, ByVal e As System.EventArgs)

        Dim boton As Button = DirectCast(sender, Button)

        Select Case (boton.CommandName)

            Case "MTA"
                Me.ModalPopupTer3.Show()
                Me.MVMov.ActiveViewIndex = 0
            Case "Resumen"


        End Select




    End Sub
End Class
