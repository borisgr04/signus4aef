Imports System.Data
Partial Class DatosBasicos_Entidad1_Entidad
    Inherits PaginaComun
    Dim Obj As Entidad = New Entidad
    Protected Sub BtnGuardar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnGuardar.Click


        Me.MsgResult.Text = Obj.Update(Me.nit.Value, Me.TxtnitNew.Text, Me.txtnomNew.Text, Me.txtdirNew.Text, Me.txttelNew.Text, Me.txtemailNew.Text, Me.txtdptoNew.Text, Me.txtmpioNew.Text, Me.txtcedresNew.Text, Me.txtnomresNew.Text, Me.txtlogoNew.Text)
   
        Me.MsgBox(MsgResult, Obj.lErrorG)




    End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Me.Opcion = "Entidad"
        Me.SetTitulo()

        If Not Me.Page.IsPostBack Then

            Dim tb As DataTable = Obj.GetRecords()
            If tb.Rows.Count > 0 Then
                Me.TxtnitNew.Text = tb.Rows(0)("ENT_NIT").ToString
                Me.txtnomNew.Text = tb.Rows(0)("ENT_NOM").ToString
                Me.txtdirNew.Text = tb.Rows(0)("ENT_DIR").ToString
                Me.txttelNew.Text = tb.Rows(0)("ENT_TEL").ToString
                Me.txtemailNew.Text = tb.Rows(0)("ENT_EMAIL").ToString
                Me.txtdptoNew.Text = tb.Rows(0)("ENT_DPTO").ToString
                Me.txtmpioNew.Text = tb.Rows(0)("ENT_MPIO").ToString
                Me.txtcedresNew.Text = tb.Rows(0)("ENT_CEDRES").ToString
                Me.txtnomresNew.Text = tb.Rows(0)("ENT_NOMRES").ToString
                Me.txtlogoNew.Text = tb.Rows(0)("ENT_LOGO").ToString
                Me.nit.Value = tb.Rows(0)("ENT_NIT").ToString
            Else
                Me.MsgResult.Text = "Datos de Entidad No Configurados"

            End If
        End If

    End Sub
End Class
