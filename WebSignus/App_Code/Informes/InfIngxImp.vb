Imports Microsoft.VisualBasic
Imports System.Data

Public Class InfIngxImp
    Inherits BDDatos2


    Public Function Get_MovIng(ByVal Filtro As String, ByVal Tipo_Grupo As String) As DataTable
        Dim DTtab As DataTable = New DataTable
        Me.Conectar()
        Dim cFiltro As String = IIf(Filtro <> "", " Where " + Filtro, "")
        Try
            If Tipo_Grupo = "D" Then
                querystring = "select MOV_AÑO  as ano ,MOV_PER||'-'||cal_des as mes, mov_ccar, CCAR_NOM, sum(VALOR)from (select fec_mov,  mov_ccar, MOV_AÑO,  VALOR , CCAR_NOM, mov_cdec,MOV_PER,cal_des  from vInfIngImp " + cFiltro + ")  group by  MOV_AÑO, MOV_PER||'-'||cal_des, mov_ccar, CCAR_NOM order by mes, mov_ccar "
            Else
                querystring = "select to_Char(fec_mov,'yyyy')||to_Char(fec_mov,'mm') A_MES, to_Char(fec_mov,'yyyy')  as ano ,to_Char(fec_mov,'mm')||'-'||to_Char(fec_mov,'MONTH') as mes, v.* from  vInfIngImp v " + cFiltro + " "
            End If
            CrearComando(querystring)
            DTtab = EjecutarConsultaDataTable()
            Me.Desconectar()
            Me.lErrorG = False
        Catch ex As Exception
            Me.lErrorG = True
            Me.Msg = "Error de App:" + ex.Message
        Finally
            Me.Desconectar()
        End Try
        Return DTtab

    End Function

End Class
