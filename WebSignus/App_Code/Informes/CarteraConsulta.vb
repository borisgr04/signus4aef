Imports Microsoft.VisualBasic
Imports System.Data

Public Class CarteraConsulta
    Inherits BDDatos2

    Public Function GetSaldo() As String
        Me.Conectar()
        querystring = "Select Nvl(Sum(CASE WHEN Saldo >= 0 THEN Saldo ELSE 0 END),0) Saldo_a_Cargo, Nvl(Sum(CASE WHEN Saldo < 0 THEN -Saldo ELSE 0 END),0) Saldo_a_Favor "
        querystring += "From vCarteraD Where Car_Nit=:Car_Nit  "
        CrearComando(querystring)
        AsignarParametroCadena(":Car_Nit", Me.usuario)
        Dim dataTb As DataTable = EjecutarConsultaDataTable()
        Me.Desconectar()
        If dataTb.Rows.Count > 0 Then
            Return dataTb.Rows(0)("Saldo_a_Cargo")
        Else
            Return "-1"
        End If
    End Function

End Class
