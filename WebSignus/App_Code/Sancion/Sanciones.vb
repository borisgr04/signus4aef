Imports Microsoft.VisualBasic
Imports System.Data
Imports System.ComponentModel

Public Class Sancion
    Dim BD As BDDatos2 = New BDDatos2()
    Property periodos As String = ""
    ''' <summary>
    ''' Retorna Tabla de La Sanción, por periodo en Expediente
    ''' </summary>
    ''' <param name="NroExpe"></param>
    ''' <param name="Nit"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    <DataObjectMethodAttribute(DataObjectMethodType.Select, True)> _
    Public Function Get_PerSancion(ByVal NroExpe As String, ByVal Nit As String) As DataTable
        Dim DTtab As DataTable = New DataTable
        Dim ValDec As String = "0"
        Dim Nrodec As String = Get_Ult_Dec(Nit)
        If Not String.IsNullOrEmpty(Nrodec) Then
            ValDec = Get_Ult_ValDe(Nrodec)
        End If

        Dim querystring As String = ""
        Try
            BD.Conectar()
            querystring = "select EXAP_AGRA, EXAP_PGRA," + ValDec + "as code_valdec, 0 as Exap_ValIng  from expe_apg where exap_nume='" + NroExpe + "' and EXAP_ESTA='AC' "

            BD.CrearComando(querystring)
            DTtab = BD.EjecutarConsultaDataTable()
            BD.Desconectar()
            BD.lErrorG = False
        Catch ex As Exception
            BD.lErrorG = True
            BD.Msg = "Error de App:" + ex.Message
        Finally
            BD.Desconectar()
        End Try
        Return DTtab
    End Function
    <DataObjectMethodAttribute(DataObjectMethodType.Select, True)> _
    Private Function Get_Ult_Dec(ByVal Vnit As String) As String

        Dim DTtab As DataTable = New DataTable
        Dim querystring As String = ""
        Dim x As String = ""
        Try
            BD.Conectar()
            querystring = "select * from (select dec_cod from declaracion where dec_nit='" + Vnit + "' and   dec_doad='DELP' AND DEC_EST='PR' order by DEC_fpre desc)  where ROWNUM<=1"
            BD.CrearComando(querystring)
            DTtab = BD.EjecutarConsultaDataTable
            BD.lErrorG = False
        Catch ex As Exception
            BD.lErrorG = True
            BD.Msg = "Error de App:" + ex.Message
        Finally
            BD.Desconectar()
        End Try
        Dim cant As String = DTtab.Rows.Count
        If cant > 0 Then
            x = DTtab.Rows(0)("dec_cod")
        Else
            'If String.IsNullOrEmpty(x) Or IsNothing(x) Then
            x = ""
        End If
        Return x
    End Function
   
    <DataObjectMethodAttribute(DataObjectMethodType.Select, True)> _
    Public Function Get_Ult_ValDe(ByVal NroDec As String) As Double

        Dim querystring As String = ""
        Dim x As String
        Dim DTtab As DataTable = New DataTable
        Try
            BD.Conectar()
            querystring = "select Code_Vade from code_cdec where  code_dcod ='" + NroDec + "' and code_tico='K'"
            BD.CrearComando(querystring)
            DTtab = BD.EjecutarConsultaDataTable
            BD.Desconectar()
            BD.lErrorG = False
        Catch ex As Exception
            BD.lErrorG = True
            BD.Msg = "Error de App:" + ex.Message
        Finally
            BD.Desconectar()
        End Try
        x = DTtab.Rows(0)("Code_Vade")
        Return x

    End Function
    Public Function TieneArchPlano(ByVal nit As String, ByVal nexp As String) As Boolean
        Dim DTtab As DataTable = New DataTable
        Dim HavePlanos As Boolean = False
        Dim querystring As String = "SELECT * FROM "
        querystring += "(SELECT EXAP_NUME, EXAP_SUIM AS NIT, (BALI_AÑO||BALI_PERI) AS TARPLAN, (EXAP_AGRA||EXAP_PGRA)  AS TSAN "
        querystring += "FROM EXPE_APG  LEFT JOIN BASES_LIQ  ON  BALI_EST='AC' AND BALI_NIT = EXAP_SUIM  AND BALI_CDEC=EXPE_CDEC AND (BALI_AÑO||BALI_PERI)= (EXAP_AGRA||EXAP_PGRA)) WHERE  "
        querystring += "EXAP_NUME =" + nexp + " AND TARPLAN IS NULL ORDER BY TSAN"

        Try
            BD.Conectar()
            BD.CrearComando(querystring)
            DTtab = BD.EjecutarConsultaDataTable()

            If DTtab.Rows.Count = 0 Then
                HavePlanos = True
            Else
                For Each dtRow As DataRow In DTtab.Rows
                    periodos = dtRow("TSAN") + ", "
                Next
            End If

        Catch ex As Exception
            BD.lErrorG = True
            BD.Msg = "Error de App:" + ex.Message
        Finally
            BD.Desconectar()
        End Try
        Return HavePlanos
    End Function
    <DataObjectMethodAttribute(DataObjectMethodType.Select, True)> _
    Public Function GetValSan(ByVal Nexpe As String) As String
        'se utiliza para tomar el valor de la sanción que esta guardada en la tabla expe_rsan, para imprimirla en el archivo plano
        Dim DTtab As DataTable = New DataTable
        Dim querystring As String = ""
        Dim x As String
        Try
            BD.Conectar()
            querystring = "select * from  (Select EXRSAN_VBASE from expe_rsan where  exrsan_nexpe =" + Nexpe + ") where  ROWNUM<=1"
            BD.CrearComando(querystring)
            DTtab = BD.EjecutarConsultaDataTable
            BD.Desconectar()
            BD.lErrorG = False
        Catch ex As Exception
            BD.lErrorG = True
            BD.Msg = "Error de App:" + ex.Message
        Finally
            BD.Desconectar()
        End Try
        x = DTtab.Rows(0)("EXRSAN_VBASE")
        If String.IsNullOrEmpty(x) Then
            x = 0
        End If
        Return x
    End Function
End Class
