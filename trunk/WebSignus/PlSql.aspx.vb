Imports System.Data
Partial Class PlSql
    Inherits PaginaComun

    Protected Sub Ejecutar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Ejecutar.Click
        'Dim dt As New BDDatos, ra As Integer
        'Dim ret As String = ""
        'dt.AbrirDB()
        'Dim dbCommand As New OracleCommand
        'dbCommand.Connection = BDDatos.dbConnection
        'dbCommand.CommandText = "LIQUIDAR"
        'dbCommand.CommandType = CommandType.StoredProcedure
        ''dbCommand.Parameters.Add("inAPNOM", OracleDbType.Varchar2, ParameterDirection.Input).Value = Me.AppName
        'Dim pRet As OracleParameter = dbCommand.Parameters.Add("Return", OracleDbType.Decimal, ParameterDirection.ReturnValue, ParameterDirection.ReturnValue)
        'dbCommand.Parameters.Add("inValorBase", OracleDbType.Decimal, ParameterDirection.Input).Value = CInt(Me.ValorBase.Text)
        'dbCommand.Parameters.Add("inCantidad", OracleDbType.Decimal, ParameterDirection.Input).Value = CInt(Me.Cantidad.Text)
        'dbCommand.Parameters.Add("inFormula", OracleDbType.Varchar2,2000,me.Formula.Text, ParameterDirection.Input)
        'ra = dbCommand.ExecuteNonQuery()

        'Me.Resultado.Text = pRet.Value.ToString


    End Sub

    Protected Sub CmbClase_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles CmbClase.SelectedIndexChanged
        Me.SqlPar_Imp.DataBind()
        Me.GridView1.DataBind()
    End Sub

    Protected Sub CboImpto_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles CboImpto.SelectedIndexChanged
        Me.SqlPar_Imp.DataBind()

    End Sub

    Protected Sub BtnDec_Click(ByVal sender As Object, ByVal e As System.EventArgs)

    End Sub

    Protected Sub BtnFormula_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnFormula.Click
        Me.F2.Text = Me.Formula.Text
    End Sub

    Protected Sub BtnGen_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnGen.Click
        Dim obj As New Impuestos
        Dim p As DataTable = obj.GetParametros(Me.CboImpto.SelectedValue)
        Dim StrDec As String = "DECLARE " + vbNewLine
        For i As Integer = 0 To p.Rows.Count - 1
            StrDec += p.Rows(i)("Par_Nom").ToString() + " " + p.Rows(i)("Par_tid").ToString() + ";" + vbNewLine
        Next i
        Me.Formula.Text = StrDec

    End Sub

    Protected Sub Button1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button1.Click
        Me.GridView1.DataBind()
    End Sub
End Class
