Imports System.Data
Imports Signus
Partial Class DatosBasicos_MisDatos_MisDatos
    Inherits PaginaComun

    Protected Sub Cargar_Terceros()
        Dim tb As DataTable = Me.UsuTercero.GetByUser()
        If tb.Rows.Count > 0 Then
            'If 1 = 0 Then
            Me.HOldDVer.Value = tb.Rows(0)("TER_DVER").ToString
            Me.HOldNit.Value = tb.Rows(0)("TER_NIT").ToString
            Me.HOldTDoc.Value = tb.Rows(0)("TER_TDOC").ToString
            Me.CbTdoc.SelectedValue = tb.Rows(0)("TER_TDOC").ToString
            Me.TxtNit.Text = tb.Rows(0)("TER_NIT").ToString
            Me.TxtDver.Text = tb.Rows(0)("TER_DVER").ToString
            Me.TxtNom.Text = tb.Rows(0)("TER_NOM").ToString
            Me.CbTTcer.SelectedValue = tb.Rows(0)("TER_TIP").ToString
            Me.CbMun.SelectedValue = tb.Rows(0)("TER_MPIO").ToString
            Me.TxtEma.Text = tb.Rows(0)("TER_EMAI").ToString
            Me.TxtTel.Text = tb.Rows(0)("TER_TEL").ToString
            Me.TxtDir.Text = tb.Rows(0)("TER_DIR").ToString
            Me.TxtCed.Text = tb.Rows(0)("TER_CED").ToString
            Me.TxtRep.Text = tb.Rows(0)("TER_REP").ToString
            Me.TxtUsu.Text = tb.Rows(0)("TER_USU").ToString
            Me.CbTUsu.SelectedValue = tb.Rows(0)("TER_TUS").ToString
            Me.TxtObs.Text = tb.Rows(0)("TER_OBS").ToString
        End If
    End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not Me.IsPostBack Then
            Me.Opcion = Me.Tit.Text
            Me.SetTitulo()
            Me.TxtNit.Attributes.Add("onfocusout", "javascript:ColocarNit();")

            Me.Cargar_Terceros()

        End If

    End Sub

    Protected Sub Btnsave_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles BtnSave.Click
        Dim obj As Terceros = New Terceros
        Me.MsgResult.Text = obj.Update(Me.HOldNit.Value, Me.HOldTDoc.Value, Me.HOldDVer.Value, Me.CbTdoc.SelectedValue, Me.TxtNit.Text, Me.TxtDver.Text, Me.TxtNom.Text, Me.CbTTcer.SelectedValue, Me.CbMun.SelectedValue, Me.TxtEma.Text, Me.TxtTel.Text, Me.TxtDir.Text, Me.TxtCed.Text, Me.TxtRep.Text, Me.TxtUsu.Text, Me.CbTUsu.SelectedValue, Me.CbEst.SelectedValue, Me.TxtObs.Text)
        Me.MsgBox(MsgResult, obj.lErrorG)

    End Sub

    Protected Sub BtnCancel_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs)
        Cargar_Terceros()
        Me.MsgResult.Text = ""
        Me.MsgResult.CssClass = ""
    End Sub
End Class
