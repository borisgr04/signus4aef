Imports Microsoft.VisualBasic
Imports System.Data

Public Class De_Bg_Gasolina
    Dim BD As BDDatos2 = New BDDatos2()
    Dim querystring As String


    
    Public Overloads Function GetAforo(ByVal Tipo_Agente As String, ByVal nit As String, ByVal año As String, ByVal peri As String) As DataTable
        Dim dataTb As DataTable
        dataTb = Me.GetRecords(nit, "50", año, peri) 'Consulta el numero de Radicacion. 
        Return GetAforoGas("50", dataTb.Rows(0)("NRAD").ToString)
    End Function
    Private Function GetAforoGas(ByVal Tipo_Agente As String, Optional ByVal nro_rad As Long = 0) As DataTable
        BD.Conectar()
        'Para Mostrar Detalle de la Liquidacion
        querystring = "SELECT '50' CoCd_Cdec,'01' CoCd_Codi, Clase,'5001' CoCd_Impto, SUM (galones) Galones, AVG (precio_ref) Precio_Ref,"
        querystring += " AVG (porc_alcohol) Porc_Alcohol, SUM (valorbase) BASEGRAVABLE, "
        querystring += " AVG (tarifa) Tarifa, AVG (valorimpto) VALORIMPUESTO, "
        querystring += " DECODE(Clase, '01', 'GASOLINA CORRIENTE BÁSICA', "
        querystring += " '02', 'GASOLINA CORRIENTE OXIGENADA', "
        querystring += " '03', 'GASOLINA EXTRA BÁSICA', "
        querystring += " '04','GASOLINA EXTRA OXIGENADA', "
        querystring += " '05','GASOLINA IMPORTADA',"
        querystring += " '06','GASOLINA NAL.ZON.ESP.FRONT'"
        querystring += ") CLASE_PRODUCTOS "
        querystring += " FROM fm_blsobretasa WHERE nro_rad = " + nro_rad.ToString + " GROUP BY clase "

        BD.CrearComando(querystring)
        Dim dataTb As DataTable = BD.EjecutarConsultaDataTable()
        BD.Desconectar()
        Return dataTb
    End Function
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
