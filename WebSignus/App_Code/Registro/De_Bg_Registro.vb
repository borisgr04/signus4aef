Imports Microsoft.VisualBasic
Imports System.ComponentModel
Imports System.Data


Public Class De_Bg_Registro
    Dim BD As BDDatos2 = New BDDatos2()

    ''' <summary>
    ''' 
    ''' </summary>
    ''' <param name="Tipo_Agente"></param>
    ''' <param name="Nit"></param>
    ''' <param name="Año"></param>
    ''' <param name="Peri"></param>
    ''' <param name="Tip">D, devolucio,I impuesto</param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    <DataObjectMethodAttribute(DataObjectMethodType.Select, True)> _
    Public Function Get_BaseG_Registro(ByVal Tipo_Agente As String, ByVal Nit As String, ByVal Año As String, ByVal Peri As String, Tip As String) As DataTable
        Dim dataTb As DataTable, dt As DataTable
        dataTb = Me.GetRecords(Nit, "30", Año, Peri)
        If dataTb.Rows.Count > 0 Then
            If Tip = "D" Then
                dt = Me.GetAforoRegistroDev(Tipo_Agente, dataTb.Rows(0)("NRAD").ToString)
            Else
                dt = Me.GetAforoRegistroImp(Tipo_Agente, dataTb.Rows(0)("NRAD").ToString)
            End If
        Else
            dt = New DataTable()
        End If
        Return dt
    End Function

    <DataObjectMethodAttribute(DataObjectMethodType.Select, True)> _
    Public Function Get_BaseG_Registro(ByVal Tipo_Agente As String, ByVal Nit As String, ByVal Año As String, ByVal Peri As String) As DataTable
        Dim dataTb As DataTable, dt As DataTable
        dataTb = Me.GetRecords(Nit, "30", Año, Peri)
        If dataTb.Rows.Count > 0 Then
            dt = Me.GetAforoRegistro(Tipo_Agente, dataTb.Rows(0)("NRAD").ToString)
        Else
            dt = New DataTable()
        End If
        Return dt
    End Function

    <DataObjectMethodAttribute(DataObjectMethodType.Select, True)> _
    Private Function GetAforoRegistro(ByVal Tipo_Agente As String, ByVal Nro_rad As Integer) As DataTable
        Dim dtDev As DataTable = GetAforoRegistroDev(Tipo_Agente, Nro_rad)
        Dim dtImp As DataTable = GetAforoRegistroImp(Tipo_Agente, Nro_rad)
        dtDev.Merge(dtImp)
        Dim view As DataView = New DataView(dtDev)
        view.Sort = "Mov,Tacto "
        Return view.ToTable()

    End Function

    <DataObjectMethodAttribute(DataObjectMethodType.Select, True)> _
    Private Function GetAforoRegistroDev(ByVal Tipo_Agente As String, ByVal Nro_rad As Integer) As DataTable
        BD.Conectar()

        Dim tarifaSinCuantia As Decimal
        Dim sb As New StringBuilder()
        '-- CONSULTAR TARIFA
        sb.Append(" Select fn_ejecutar_tarifa ('3001', 'Valor_Base Number:=1;Tipo_Agente Number:=" + Tipo_Agente + ";Tipo_Acto Number:=2;') Tarifa  from dual")
        BD.CrearComando(sb.ToString)
        Dim dataTar As DataTable = BD.EjecutarConsultaDataTable()
        tarifaSinCuantia = dataTar.Rows(0)("Tarifa")
        'Throw New Exception("Tarifa sin cuantia" + tarifaSinCuantia.ToString)

        sb.Clear()
        '--DEVOLUCION CON CUUANTIA OFICINA DE REGSITRO
        sb.Append(" Select 'DEV' MOV,'ACTOS CON CUANTIA' CLASE_ACTOS,Tacto, Count(*) NACTOS, Sum(ValorBase) AS CUANTIA,fn_ejecutar_tarifa ('3001', 'Valor_Base Number:=1;Tipo_Agente Number:=" + Tipo_Agente + ";Tipo_Acto Number:=1;') TARIFA, Sum(ValorImpto) VRIMPTO,Sum(Intereses) VRINTERESES  ")
        sb.Append(" From fm_bliqreg01 where tacto='01' and ES_DEVOLUCION ='SI' And Nro_Rad=" + Nro_rad.ToString + " group by Tacto ")
        '--DEVOLUCION SIN CUUANTIA OFICINA DE REGSITRO
        sb.Append(" UNION ")
        sb.Append(" Select 'DEV' MOV,'ACTOS SIN CUANTIA' CLASE_ACTOS,Tacto, Count(*) NACTOS, Sum(ValorBase) AS CUANTIA,fn_ejecutar_tarifa ('3001', 'Valor_Base Number:=1;Tipo_Agente Number:=" + Tipo_Agente + ";Tipo_Acto Number:=2;') TARIFA, Sum(ValorImpto) VRIMPTO,Sum(Intereses) VRINTERESES ")
        sb.Append(" From fm_bliqreg01 where tacto='02' and ES_DEVOLUCION ='SI' And Nro_Rad=" + Nro_rad.ToString + " group by Tacto")
        BD.CrearComando(sb.ToString)
        Dim dataTb As DataTable = BD.EjecutarConsultaDataTable()
        BD.Desconectar()

        If dataTb.Rows.Count = 1 Then
            Dim dtrownew As DataRow = dataTb.NewRow()
            If dataTb.Rows(0)("Tacto") = "01" Then
                dtrownew("Tacto") = "02"
                dtrownew("CLASE_ACTOS") = "ACTOS SIN CUANTIA"
            End If
            If dataTb.Rows(0)("Tacto") = "02" Then
                dtrownew("CLASE_ACTOS") = "ACTOS CON CUANTIA"
                dtrownew("Tacto") = "01"
            End If
            dtrownew("Nactos") = "0"
            dtrownew("MOV") = "DEV"
            dtrownew("Cuantia") = "0"
            dtrownew("Tarifa") = tarifaSinCuantia.ToString
            dtrownew("VrImpto") = "0"
            dtrownew("VrIntereses") = "0"
            dataTb.Rows.Add(dtrownew)
        End If

        
        Dim view As DataView = New DataView(dataTb)
        view.Sort = "Tacto "
        Return view.ToTable()

    End Function


    Private Function GetAforoRegistroImp(ByVal Tipo_Agente As String, ByVal Nro_rad As Integer) As DataTable
        BD.Conectar()

        Dim tarifaSinCuantia As Decimal
        Dim sb As New StringBuilder()
        '-- CONSULTAR TARIFA
        sb.Append(" Select fn_ejecutar_tarifa ('3001', 'Valor_Base Number:=1;Tipo_Agente Number:=" + Tipo_Agente + ";Tipo_Acto Number:=2;') Tarifa  from dual")
        BD.CrearComando(sb.ToString)
        Dim dataTar As DataTable = BD.EjecutarConsultaDataTable()
        tarifaSinCuantia = dataTar.Rows(0)("Tarifa")
        'Throw New Exception("Tarifa sin cuantia" + tarifaSinCuantia.ToString)

        sb.Clear()

        '--INGRESO  CON CUUANTIA OFICINA DE REGSITRO
        sb.Append("Select 'ING' MOV,'ACTOS CON CUANTIA' CLASE_ACTOS, Tacto, Count(*) NACTOS, Sum(ValorBase) AS CUANTIA,fn_ejecutar_tarifa ('3001', 'Valor_Base Number:=1;Tipo_Agente Number:=" + Tipo_Agente + ";Tipo_Acto Number:=1;') TARIFA, Sum(ValorImpto) VRIMPTO,Sum(Intereses) VRINTERESES  ")
        sb.Append(" From fm_bliqreg01 where tacto='01' and ES_DEVOLUCION ='NO' And Nro_Rad=" + Nro_rad.ToString + " group by Tacto ")

        '--INGRESO CON CUUANTIA OFICINA DE REGSITRO
        sb.Append(" UNION ")
        sb.Append(" Select 'ING' MOV,'ACTOS SIN CUANTIA' CLASE_ACTOS, Tacto, Count(*) NACTOS, Sum(ValorBase) AS CUANTIA,fn_ejecutar_tarifa ('3001', 'Valor_Base Number:=1;Tipo_Agente Number:=" + Tipo_Agente + ";Tipo_Acto Number:=2;') TARIFA, Sum(ValorImpto) VRIMPTO,Sum(Intereses) VRINTERESES  ")
        sb.Append(" From fm_bliqreg01 where tacto='02' and ES_DEVOLUCION ='NO' And Nro_Rad=" + Nro_rad.ToString + " group by Tacto")
        BD.CrearComando(sb.ToString)
        Dim dataTb As DataTable = BD.EjecutarConsultaDataTable()
        BD.Desconectar()


        Dim dtrownew As DataRow = dataTb.NewRow
        If dataTb.Rows.Count = 1 Then
            If dataTb.Rows(0)("Tacto") = "01" Then
                dtrownew("Tacto") = "02"
                dtrownew("CLASE_ACTOS") = "ACTOS SIN CUANTIA"
            End If
            If dataTb.Rows(0)("Tacto") = "02" Then
                dtrownew("CLASE_ACTOS") = "ACTOS CON CUANTIA"
                dtrownew("Tacto") = "01"
            End If
            dtrownew("Nactos") = "0"
            dtrownew("MOV") = "ING"
            dtrownew("Cuantia") = "0"
            dtrownew("Tarifa") = tarifaSinCuantia.ToString
            dtrownew("VrImpto") = "0"
            dtrownew("VrIntereses") = "0"
            dataTb.Rows.Add(dtrownew)
        End If

        Dim view As DataView = New DataView(dataTb)
        view.Sort = "Tacto"

        Return view.ToTable()
    End Function

    <DataObjectMethodAttribute(DataObjectMethodType.Select, True)> _
    Private Function GetRecords(ByVal NIT As String, ByVal CLDEC As String, ByVal AÑO As String, ByVal PERI As String) As DataTable

        BD.Conectar()
        Dim querystring As String = "SELECT BALI_NRAD NRAD, BALI_NIT NIT,  BALI_ARCH ARCHIVO, BALI_EST ESTADO, BALI_USAP USAP, BALI_USBD USBD, BALI_FESI FECHA_SISTEMA  FROM Bases_Liq WHERE BALI_NIT=:BALI_NIT AND  BALI_CDEC=:BALI_CDEC AND BALI_AÑO=:BALI_AÑO AND BALI_PERI=:BALI_PERI ORDER BY BALI_NRAD DESC"
        BD.CrearComando(querystring)
        BD.AsignarParametroCadena(":BALI_NIT", NIT)
        BD.AsignarParametroCadena(":BALI_CDEC", CLDEC)
        BD.AsignarParametroCadena(":BALI_AÑO", AÑO)
        BD.AsignarParametroCadena(":BALI_PERI", PERI)
        Dim dataTb As DataTable = BD.EjecutarConsultaDataTable()
        BD.Desconectar()
        Return dataTb
    End Function

End Class
