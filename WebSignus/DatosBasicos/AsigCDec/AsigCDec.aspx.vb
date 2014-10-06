Imports System.Data
Imports Signus

Partial Class DatosBasicos_AsigCDec_AsigCDec
    Inherits PaginaComun
    Dim ObjTCDec As AsigCDec = New AsigCDec
    Protected Sub BtnTipUS_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs)
        'Cargar_Tercero()
        Me.ModalPopup.Show()
    End Sub
    Protected Sub Cargar_Tercero()
        Dim nit As String = Me.Nit.Text
        Dim obj As Terceros = New Terceros
        Dim dt As DataTable = obj.GetByIde(nit)
        If dt.Rows.Count > 0 Then
            Me.MsgResult.Text = ""
            'Me.CbTTcer.SelectedValue = dt.Rows(0)("Ter_TUS").ToString
            Me.Agente.Text = dt.Rows(0)("Ter_Nom").ToString
            Me.Nit.Text = dt.Rows(0)("Ter_nit").ToString
            Me.DV.Text = dt.Rows(0)("Ter_dver").ToString
            'Me.TIP_DOC_IDE.Text = dt.Rows(0)("Ter_tdoc").ToString
        Else
            MsgBox(MsgResult, True)
            Me.MsgResult.Text = "No tiene asociado Tercero"
        End If
    End Sub

    Protected Sub CargAR_Click(ByVal sender As Object, ByVal e As System.EventArgs)

    End Sub

    Protected Sub Button1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button1.Click
        If Me.RdNit.Checked = True Then

            If Me.Nit.Text = "" Then
                Me.MsgResult.Text = "No ha Digitado el Nit"
                Me.MsgBox(Me.MsgResult, True)
            Else
                Dim j As Integer = 0
                'Dim dt As DataTable = ObjTCDec.GetRecords(Me.Nit.Text)
                'If dt.Rows.Count > 0 Then
                Dim Cant As Integer = DataList1.Items.Count
                Dim StrucAsig(0 To Cant - 1) As VAsig_Ter
                For i As Integer = 0 To Cant - 1
                    Dim CL_EST As CheckBox = DirectCast(DataList1.Items(i).FindControl("asg_est"), CheckBox)
                    Dim CL_NOM As Label = DirectCast(DataList1.Items(i).FindControl("asg_nom"), Label)
                    Dim CL_COD As Label = DirectCast(DataList1.Items(i).FindControl("asg_cod"), Label)
                    Dim CL_FECINI As TextBox = DirectCast(DataList1.Items(i).FindControl("asg_fecini"), TextBox)
                    Dim CL_FECFIN As TextBox = DirectCast(DataList1.Items(i).FindControl("Asg_FecFIN"), TextBox)
                    If CL_EST.Checked = True Then
                        StrucAsig(j).CLD_COD = CL_COD.Text
                        StrucAsig(j).FECHA_INI = CL_FECINI.Text
                        StrucAsig(j).FECHA_FIN = CL_FECFIN.Text
                        j = j + 1
                    End If
                Next

                MsgResult.Text = ObjTCDec.Insert(Me.Nit.Text, StrucAsig)
                Me.MsgBox(MsgResult, ObjTCDec.lErrorG)
                'Else

                ' Me.MsgResult.Text = "No Tiene Clase de impuesto Asociado"
                'MsgBox(MsgResult, True)
                ' End If
            End If

        ElseIf Me.RDtAg.Checked = True Then
            Dim j As Integer = 0
            Dim Cant As Integer = DataList1.Items.Count

            Dim StrucAsig(0 To Cant - 1) As VAsig_Ter
            For i As Integer = 0 To Cant - 1
                Dim CL_EST As CheckBox = DirectCast(DataList1.Items(i).FindControl("asg_est"), CheckBox)
                Dim CL_COD As Label = DirectCast(DataList1.Items(i).FindControl("asg_cod"), Label)
                Dim CL_FECINI As TextBox = DirectCast(DataList1.Items(i).FindControl("asg_fecini"), TextBox)
                Dim CL_FECFIN As TextBox = DirectCast(DataList1.Items(i).FindControl("Asg_FecFIN"), TextBox)
                If CL_EST.Checked = True Then
                    StrucAsig(j).CLD_COD = CL_COD.Text
                    StrucAsig(j).FECHA_INI = CL_FECINI.Text
                    StrucAsig(j).FECHA_FIN = CL_FECFIN.Text
                    j = j + 1
                End If
            Next
            MsgResult.Text = ObjTCDec.InsertGrupo(Me.CbTTcer.SelectedValue, StrucAsig)
            Me.MsgBox(MsgResult, ObjTCDec.lErrorG)

        Else
            Me.MsgResult.Text = "No ha seleccionado un tipo de Busqueda"
            MsgBox(MsgResult, True)
        End If
    End Sub
   
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Me.Opcion = Me.Tit.Text
        Me.SetTitulo()
    End Sub

    Protected Sub Button2_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        'Dim dt As DataTable = ObjTCDec.COnsultarAsig(Me.Nit.Text)
        'If dt.Rows.Count > 0 Then
        'Dim Cant As Integer = DataList1.Items.Count
        'For i As Integer = 0 To Cant - 1
        'Dim CL_EST As CheckBox = DirectCast(DataList1.Items(i).FindControl("asg_est"), CheckBox)
        'If dt.Rows(i)("Cld_Est").ToString = 1 Then
        'CL_EST.Checked = True
        'Else
        'CL_EST.Checked = False
        'End If

        'Next
        'Else
        'Me.MsgResult.Text = "No tiene asociado Declaraciones"
        'MsgBox(MsgResult, True)
        'End If
    End Sub


   
    Protected Sub DataList1_ItemDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.DataListItemEventArgs)
        If e.Item.ItemType = ListItemType.Item Or e.Item.ItemType = ListItemType.AlternatingItem Then
            Dim CL_EST As CheckBox = DirectCast(e.Item.FindControl("asg_est"), CheckBox)

            If CStr(DirectCast(e.Item.DataItem, DataRowView)("Cld_Est")) = 1 Then
                CL_EST.Checked = True
            Else
                CL_EST.Checked = False
            End If
        End If

    End Sub

    Protected Sub BtnTipUS_Click(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.CommandEventArgs)
        Me.MsgResult.Text = ""
        Me.ModalPopup.Show()

    End Sub



    Protected Sub BtnTipUs_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        Me.MsgResult.Text = ""
        Me.ModalPopup.Show()
    End Sub
End Class
