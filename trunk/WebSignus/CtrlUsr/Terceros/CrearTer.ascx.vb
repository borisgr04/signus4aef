Imports Signus
Imports System.Data

Partial Class CtrlUsr_Terceros_CrearTer
    Inherits System.Web.UI.UserControl
    Dim Obj As Terceros = New Terceros
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        Me.HideTTER.Value = "00"
        Me.HidTUs.Value = "OT"
        Me.CbEst.SelectedValue = "AC"
        'var theForm = document.forms['aspnetForm'];
        Me.TxtNit.Attributes.Add("onfocusout", "javascript:ColocarNit();")
        Me.TxtNom.Attributes.Add("onfocusout", "javascript:ColocarRep();")
    End Sub


 

    Protected Sub Limpiar()
        Me.SubT.Text = ""
        Me.MsgResult.Text = ""
        Me.Hidenusu.Value = ""
        Me.TxtNit.Text = ""
        Me.TxtDver.Text = ""
        Me.TxtNom.Text = ""
        Me.TxtEma.Text = ""
        Me.TxtTel.Text = ""
        Me.TxtDir.Text = ""
        Me.TxtCed.Text = ""
        Me.TxtRep.Text = ""
        Me.TxtObs.Text = ""

        
        
    End Sub


    Protected Sub BtnCancel_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs)
        Limpiar()
    End Sub


   

    Protected Sub Guardar()
        Me.MsgResult.Text = Obj.Insert(Me.CbTdoc.SelectedValue, Me.TxtNit.Text, Me.TxtDver.Text, Me.TxtNom.Text, Me.HideTTER.Value, Me.CbMun.SelectedValue, Me.TxtEma.Text, Me.TxtTel.Text, Me.TxtDir.Text, Me.TxtCed.Text, Me.TxtRep.Text, Me.Hidenusu.Value, Me.HidTUs.Value, Me.CbEst.SelectedValue, Me.TxtObs.Text)
    End Sub





    
    Protected Sub Btnsave_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs)
        Guardar()
    End Sub
End Class
