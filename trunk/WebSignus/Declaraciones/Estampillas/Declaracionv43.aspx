<%@ Page Language="VB" AutoEventWireup="false" CodeFile="Declaracionv43.aspx.vb" Inherits="Declaraciones_Estampillas_Declaracionv43" %>
<%@ Register Assembly="eWorld.UI, Version=2.0.6.2393, Culture=neutral, PublicKeyToken=24d65337282035f2"
    Namespace="eWorld.UI" TagPrefix="ew" %>
<%@ Register Assembly="ControlesWeb" Namespace="ControlesWeb" TagPrefix="cc1" %>
<%@ Register Assembly="Microsoft.ReportViewer.WebForms, Version=10.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a"
    Namespace="Microsoft.Reporting.WebForms" TagPrefix="rsweb" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Declaraciones Asistidas</title>
    <link href="../../Css/declaracion.css" rel="stylesheet" type="text/css" />
    <script src="../../js/Numeric.js" type="text/javascript"></script>
    <script type='text/javascript'>
        // Add click handlers for buttons to show and hide modal popup on pageLoad
         function cancelClick() {
          }
        function pageLoad() {
            $addHandler($get("hideModalPopupViaClientButton"), 'click', hideModalPopupViaClient);        
        }
        function showModalPopupViaClient(ev) {
            ev.preventDefault();
            var modalPopupBehavior = $find('programmaticModalPopupBehavior');
            modalPopupBehavior.show();
        }
        function hideModalPopupViaClient(ev) {
            ev.preventDefault();        
            var modalPopupBehavior = $find('programmaticModalPopupBehavior');
            modalPopupBehavior.hide();
//            cerrar();
        }
        function cerrar(){ 
            var ventana = window.self; 
            ventana.opener = window.self; 
            ventana.close(); 
        } 
        </script>
        <style type="text/css">
        .DivHeader{
            border-right: black 0.5pt solid;
            border-top: black 0pt none;
            border-left: black 0.5pt solid; 
            border-bottom: black 0pt none;
            font-family:Arial;
            font-size:7pt;
            margin:0;
            padding-right: 0pt;
            padding-left: 0pt; 
            padding-bottom: 0pt; 
            padding-top: 0pt;
            width: 191.27mm;
            background-repeat: repeat;
            background-color: transparent; color:black;
            }
        </style>
</head>

<body  >
<%--scroll="yes"--%>
    <form id="form1" runat="server" onkeypress="if(event.keyCode == 13) event.returnValue = false;">
        <ajaxToolkit:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server">
        </ajaxToolkit:ToolkitScriptManager>
        <script src="../../js/Declaraciones.js" type="text/javascript"></script>
        &nbsp;
        <div style="z-index: 101; left: 0px; visibility: hidden; overflow: auto; width: 100px;
            position: absolute; top: 0px; height: 100px">
            <rsweb:ReportViewer ID="ReportViewer1" runat="server" AsyncRendering="False" Font-Names="Verdana"
                Font-Size="8pt" Height="100%" SizeToReportContent="True" Width="800px">
                <LocalReport OnSubreportProcessing="ReportViewer1_SubreportProcessing" ReportPath="">
                </LocalReport>
            </rsweb:ReportViewer>
        </div>
        <asp:UpdatePanel ID="UpdatePanel2" runat="server" UpdateMode="Conditional" >
        <ContentTemplate>
        
        <div  style="width:100%;height:600px;margin:0 auto 0 auto;border:solid 0,5pt;overflow:auto;" > &nbsp;<div class="DecHeaderP">
        &nbsp;<asp:Label ID="LBTITULO" runat="server" CssClass="Titulo" Text="DECLARACIÓN DE " Visible="False"></asp:Label><br />
        
        <table width="100%" class="tbHeaderDec">
            <tr>
                <td style="width: 435px">
                    <asp:Label ID="Label18" runat="server" CssClass="SubTitulo" Font-Bold="True" Text="DEPARTAMENTO DEL CESAR"></asp:Label></td>
                <td style="width: 457px">
                    <asp:Label ID="Label3" runat="server" Font-Bold="True" Width="131px">Formulario N°</asp:Label>
                    <asp:Label ID="TxtNForm" runat="server" CssClass="TitDecl" Width="170px"></asp:Label></td>
            </tr>
            <tr>
                <td colspan="2">
                    <asp:Label ID="Label22" runat="server" Font-Bold="True" Text="Formulario único para declaración del Impuesto de Estampillas Departamentales"></asp:Label></td>
            </tr>
            <tr>
                <td rowspan="3" style="width: 435px">
                    <img src="../../images/Reportes/Img_gob.jpg" height="50px" width="100px" /></td>
                <td style="width: 457px; text-align: right">
                    </td>
            </tr>
            <tr>
                <td style="width: 457px; text-align: right">
                    </td>
            </tr>
            <tr>
                <td style="width: 457px; text-align: right">
                    </td>
            </tr>
        </table>
         <asp:Label ID="Label2" runat="server"></asp:Label></div>
        
        <!-- Button used to launch the animation -->
        <div class="DecHeader">
        <table width="100%">
            <tr class="DivNegroFila" onmouseout="Resaltar_Off(this);" onmouseover="Resaltar_On(this);">
                <td colspan="6">
                    <asp:Label ID="LbI" runat="server" Font-Bold="True" Text="I. PERIODO DE DECLARACION Y TIPO DE DECLARACIÓN"></asp:Label>&nbsp;</td>
            </tr>
            <tr onmouseout="Resaltar_Off(this);" onmouseover="Resaltar_On(this);" class="DivNegroFila">
                <td style="width: 6px">
                    <asp:TextBox ID="R1" runat="server" CssClass="NRenglon" ReadOnly="True" Width="20px">1.</asp:TextBox></td>
                <td style="width: 100px" class="TDNegroTexto">
                    <asp:Label ID="Label14" runat="server" Font-Bold="True" CssClass="TitDecl" Text="AÑO GRAVABLE"></asp:Label></td>
                <td style="width: 100px">
                    &nbsp;<asp:Label ID="AGravable" runat="server" CssClass="TitDecl"></asp:Label></td>
                <td style="width: 8px">
                    <asp:TextBox ID="R2" runat="server" CssClass="NRenglon" ReadOnly="True" Width="100%">2.</asp:TextBox></td>
                <td style="width: 100px" class="TDNegroTexto">
                    <asp:Label ID="LbPGravable" runat="server" Font-Bold="True" CssClass="TitDecl" Text="PERIODO GRAVABLE"
                        Width="133px"></asp:Label></td>
                <td style="width: 100px">
                    &nbsp;<asp:Label ID="PGravable" runat="server" CssClass="TitDecl"></asp:Label></td>
            </tr>
        </table>
            <br />
                <table width="100%">
                    <tr>
                        <td class="TDNegroTexto" colspan="7">
                            <asp:Label ID="Labe25" runat="server" Font-Bold="True" Text="I. TIPO DECLARACIÓN"></asp:Label></td>
                    </tr>
                    <tr>
                        <td style="width: 20px">
                            <asp:TextBox ID="R3" runat="server" CssClass="NRenglon" ReadOnly="True" Width="20px">3.</asp:TextBox></td>
                        <td style="width: 130px">
                            <asp:RadioButton ID="DInicial" runat="server" AutoPostBack="True" Checked="True"
                                CssClass="TitDecl" GroupName="TIPODEC" Text="Inicial" Enabled="False" /></td>
                        <td style="width: 20px">
                            <asp:TextBox ID="R4" runat="server" CssClass="NRenglon" ReadOnly="True" Width="20px">4.</asp:TextBox></td>
                        <td style="width: 130px">
                            <asp:RadioButton ID="DCorr" runat="server" AutoPostBack="True" CssClass="TitDecl"
                                GroupName="TIPODEC" Text="Correción" Enabled="False" /></td>
                        <td style="width: 20px">
                            <asp:Label ID="Label8" runat="server" CssClass="TitDecl"></asp:Label></td>
                        <td style="width: 260px">
                            <asp:Label ID="Label9" runat="server" CssClass="TitDecl" Font-Bold=true Text="N° Formulario que Corrige"></asp:Label></td>
                        <td style="width: 50px">
                            <asp:Label ID="TxtDecCorrige" runat="server" CssClass="TitDecl" 
                                Width="86px"></asp:Label></td>
                    </tr>
                </table>
    </div>
        <div class="DecHeader">
            <table width="100%">
                <tr class="DivNegroFila" onmouseout="Resaltar_Off(this);" onmouseover="Resaltar_On(this);">
                    <td class="TDNegroFila" style="height: 13px">
                        <asp:Label ID="Label10" runat="server" Font-Bold="True" Text="II. INFORMACIÓN DEL RESPONSABLE O AGENTE RETENEDOR"></asp:Label></td>
                </tr>
                <tr>
                    <td>
                        <table width="100%">
                            <tr onmouseout="Resaltar_Off(this);" onmouseover="Resaltar_On(this);">
                                <td colspan="4" style="height: 22px">
                                    <asp:TextBox ID="R5" runat="server" CssClass="NRenglon" ReadOnly="True" Width="20px">5.</asp:TextBox>
                                    <asp:Label ID="Label11" runat="server" CssClass="TitDecl" Font-Bold="True" Text="RAZON SOCIAL"></asp:Label></td>
                            </tr>
                            <tr onmouseout="Resaltar_Off(this);" onmouseover="Resaltar_On(this);">
                                <td colspan="4" style="height: 16px">
                                    <asp:Label ID="Agente" runat="server" CssClass="TitDecl"></asp:Label></td>
                            </tr>
                            <tr onmouseout="Resaltar_Off(this);" onmouseover="Resaltar_On(this);">
                                <td style="width: 130px; height: 15px">
                                    <asp:TextBox ID="R6" runat="server" CssClass="NRenglon" ReadOnly="True" Width="20px">6.</asp:TextBox>
                                    <asp:Label ID="Label45" runat="server" CssClass="TitDecl" Font-Bold="True" Text="IDENTIFICACIÓN"
                                        Width="94px"></asp:Label></td>
                                <td style="width: 91px; height: 15px">
                                    &nbsp;<asp:Label ID="Label5" runat="server" CssClass="TitDecl" Font-Bold="True" Text="DV"></asp:Label>
                                </td>
                                <td style="width: 131px; height: 15px">
                                    <asp:TextBox ID="R7" runat="server" CssClass="NRenglon" ReadOnly="True" Width="20px">7.</asp:TextBox>
                                    <asp:Label ID="Label19" runat="server" CssClass="TitDecl" Font-Bold="True" Text="TELEFONO FIJO" Width="103px"></asp:Label></td>
                                <td style="width: 253px; height: 15px">
                                    <asp:TextBox ID="R8" runat="server" CssClass="NRenglon" ReadOnly="True" Width="20px">8.</asp:TextBox>
                                    <asp:Label ID="Label20" runat="server" CssClass="TitDecl" Font-Bold="True" Text="CÓDIGO MUNICIPIO" Width="157px"></asp:Label></td>
                            </tr>
                            <tr onmouseout="Resaltar_Off(this);" onmouseover="Resaltar_On(this);">
                                <td style="height: 19px; text-align: right; width: 130px;">
                                    <asp:Label ID="Identificaciòn" runat="server" CssClass="TitDecl"></asp:Label></td>
                                <td style="width: 91px; height: 19px">
                                    -<asp:Label ID="DV" runat="server" CssClass="TitDecl"></asp:Label></td>
                                <td style="width: 131px; height: 19px">
                                    <asp:Label ID="LBTER_TEL" runat="server" CssClass="TitDecl"></asp:Label></td>
                                <td style="width: 253px; height: 19px">
                                    <asp:Label ID="LBMUN_NOM" runat="server" CssClass="TitDecl"></asp:Label></td>
                            </tr>
                            <tr onmouseout="Resaltar_Off(this);" onmouseover="Resaltar_On(this);">
                                <td colspan="4" style="text-align: left">
                                    <asp:TextBox ID="R9" runat="server" CssClass="NRenglon" ReadOnly="True" Width="20px">9.</asp:TextBox>
                                    <asp:Label ID="Label25" runat="server" CssClass="TitDecl" Font-Bold="True" Text="DIRECCIÓN DE NOTIFICACIÓN"></asp:Label></td>
                            </tr>
                            <tr onmouseout="Resaltar_Off(this);" onmouseover="Resaltar_On(this);">
                                <td colspan="4" style="text-align: left">
                                    <asp:Label ID="TXTDIR" runat="server" CssClass="TitDecl"></asp:Label></td>
                            </tr>
                        </table>
                    </td>
                </tr>
            </table>
        </div>
        <div class="datasheet">
                     <asp:Repeater ID="Repeater1" runat="server" DataSourceID="ObjLP">
                    <HeaderTemplate>
                            <table class="datatable" cellpadding="0" cellspacing="0">
                                <tr>
                                    <td colspan="7"><b>III. LIQUIDACIÓN PRIVADA</b></td>
                                </tr>
                                <tr>
                                    <td class="center">&nbsp;</td>
                                    <td class="center">&nbsp;</td>
                                    <td>&nbsp;</td>
                                    <td class="center"><b>BASE GRAVABLE</b></td>
                                    <td class="center"><b>TARIFA</b></td>
                                    <td class="center">&nbsp;</td>
                                    <td class="center"><b>VALOR IMPUESTO</b></td>   
                                </tr>
                                <tr id="itemPlaceholder" runat="server" />
                    </HeaderTemplate>
                    <ItemTemplate>
                        <tr>
                            <asp:HiddenField ID="HdCodi" runat="server" value='<%#(DataBinder.Eval(Container.DataItem, "COCD_CODI"))%>' />
                            <asp:HiddenField ID="HdIsVb" runat="server" value='<%#(DataBinder.Eval(Container.DataItem, "COCD_ISVB"))%>' />
                            <asp:HiddenField ID="HdTICO" runat="server" value='<%#(DataBinder.Eval(Container.DataItem, "COCD_TICO"))%>' />
                            <asp:HiddenField ID="HdCimp" runat="server" value='<%#(DataBinder.Eval(Container.DataItem, "COCD_IMPTO"))%>' />
                            <asp:HiddenField ID="HdSeco" runat="server" value='<%#(DataBinder.Eval(Container.DataItem, "COCD_SECO"))%>' />
                            <asp:HiddenField ID="HdTMOV" runat="server" value='<%#(DataBinder.Eval(Container.DataItem, "COCD_TMOV"))%>' />
                            <asp:HiddenField ID="HdCART" runat="server" value='<%#(DataBinder.Eval(Container.DataItem, "COCD_CART"))%>' />
                            <asp:HiddenField ID="HdCCAR" runat="server" value='<%#(DataBinder.Eval(Container.DataItem, "COCD_CCAR"))%>' />
                            <asp:HiddenField ID="HdSum" runat="server" value='<%#(DataBinder.Eval(Container.DataItem, "COCD_SUM"))%>' />
                            <asp:HiddenField ID="HdIMPTO" runat="server" value='<%#(DataBinder.Eval(Container.DataItem, "COCD_IMPTO"))%>' />
                            <asp:HiddenField ID="HdTari" runat="server" value='<%#(DataBinder.Eval(Container.DataItem, "COCD_TARI"))%>' />
                            <asp:HiddenField ID="HdTipo_Tar" runat="server" value='<%#(DataBinder.Eval(Container.DataItem, "Tipo_TAR"))%>' />
                            <asp:HiddenField ID="HdCTAR" runat="server" value='<%#(DataBinder.Eval(Container.DataItem, "COCD_CTAR"))%>' />
                            <td style="width: 17px; " >
                                <asp:textbox ID="NR" ReadOnly="true" runat="server" Text='<%#NRenglon()%>' CssClass="NRenglon"></asp:textbox></td>
                            <td style="width: 300px; ">
                                <asp:Label ID="LbNomImp" runat="server" Text='<%#DataBinder.Eval(Container.DataItem, "COCD_NOMB")%>'></asp:Label>
                                <asp:DropDownList ID="CboTSan" style="accelerator:true; font-size:7pt; " runat="server" DataSourceID="ObjTSANCIONES" DataTextField="TSAN_NOM" DataValueField="TSAN_COD" Visible=<%#IIF(DataBinder.Eval(Container.DataItem, "COCD_TICO")="S",True,False)%> AppendDataBoundItems="true"  >
                                <asp:ListItem Value="00" Text=""> </asp:ListItem>
                                 </asp:DropDownList></td>
                            </td>
                            <td style="width: 20px;  text-align: right">
                                <asp:Label ID="LbABIM" runat="server" CssClass="AB" BorderColor="#E0E0E0" Text='<%#DataBinder.Eval(Container.DataItem, "COCD_ABVB")%>'></asp:Label>
                            </td>
                            <td style="width: 150px;  text-align: right" >
                                <ew:numericbox id="TxtValBas" runat="server" autoformatcurrency="True" cssclass="TxtNum" Text="$0" 
                                    decimalsign="," groupingseparator="." Visible=<%#IIF(DataBinder.Eval(Container.DataItem, "COCD_ISVB")="S",True,False)%>></ew:numericbox>
                            <td style="width: 20px;  text-align: right" >
                                <asp:Label ID="LbTar" runat="server" CssClass="AB" Text=''></asp:Label></td>
                            <td style="width: 20px;  text-align: right" >
                                <asp:Label ID="LbABVD" runat="server" CssClass="AB" Text='<%#DataBinder.Eval(Container.DataItem, "COCD_ABVD")%>'></asp:Label></td>
                            <td style=" text-align: right;width: 150px;">
                                <ew:numericbox id="TxtR" runat="server" autoformatcurrency="True" cssclass="TxtNum" 
                                    decimalsign="," groupingseparator="."   Text="$0"></ew:numericbox>
                            </td>
                        </tr>
                </ItemTemplate>
                <FooterTemplate>
                </table>
                </FooterTemplate>
            </asp:Repeater><asp:Repeater ID="Repeater2" runat="server" DataSourceID="ObjVP">
                <FooterTemplate>
                    </table>
                </FooterTemplate>
                <HeaderTemplate>
                    <table class="datatable" cellpadding="0" cellspacing="0">
                        <tr>
                            <td colspan="4"><b>IV. PAGOS</b></td>
                        </tr>
                        <tr id="itemPlaceholder" runat="server" />
                </HeaderTemplate>
                <ItemTemplate>
                    <tr>
                            <asp:HiddenField ID="HdCodi" runat="server" value='<%#(DataBinder.Eval(Container.DataItem, "COCD_CODI"))%>' />
                            <asp:HiddenField ID="HdIsVb" runat="server" value='<%#(DataBinder.Eval(Container.DataItem, "COCD_ISVB"))%>' />
                            <asp:HiddenField ID="HdTICO" runat="server" value='<%#(DataBinder.Eval(Container.DataItem, "COCD_TICO"))%>' />
                            <asp:HiddenField ID="HdCimp" runat="server" value='<%#(DataBinder.Eval(Container.DataItem, "COCD_IMPTO"))%>' />
                            <asp:HiddenField ID="HdSeco" runat="server" value='<%#(DataBinder.Eval(Container.DataItem, "COCD_SECO"))%>' />
                            <asp:HiddenField ID="HdTMOV" runat="server" value='<%#(DataBinder.Eval(Container.DataItem, "COCD_TMOV"))%>' />
                            <asp:HiddenField ID="HdCART" runat="server" value='<%#(DataBinder.Eval(Container.DataItem, "COCD_CART"))%>' />
                            <asp:HiddenField ID="HdCCAR" runat="server" value='<%#(DataBinder.Eval(Container.DataItem, "COCD_CCAR"))%>' />
                            <asp:HiddenField ID="HdSum" runat="server" value='<%#(DataBinder.Eval(Container.DataItem, "COCD_SUM"))%>' />
                            
                        <td style="width: 17px; ">
                            <asp:textbox ID="NR" readonly="true" runat="server" Text='<%#NRenglon()%>' CssClass="NRenglon"></asp:textbox>
                            </td>
                        <td style="width: 502px; ">
                            <asp:Label ID="LbNomImp" runat="server" Text='<%#DataBinder.Eval(Container.DataItem, "COCD_NOMB")%>'></asp:Label>
                        </td>
                        <td style="width: 20px;  text-align: right">
                            <asp:Label ID="LbABVD" runat="server" Text='<%#DataBinder.Eval(Container.DataItem, "COCD_ABVD")%>'></asp:Label></td>
                        <td style=" text-align: right">
                            <ew:NumericBox ID="TxtR" runat="server" AutoFormatCurrency="True" CssClass="TxtNum"
                                DecimalSign="," GroupingSeparator="." ReadOnly='<%#IIF((DataBinder.Eval(Container.DataItem, "COCD_TICO")="T"),True,False)%>'
                                Text="$0"></ew:NumericBox>
                        </td>
                    </tr>
                </ItemTemplate>
            </asp:Repeater>
</div>
        <div class="DecHeader">
            <table width="100%">
                <tr class="DivNegroFila">
                    <td class="TDNegroFila" colspan="16" onmouseout="Resaltar_Off(this);" onmouseover="Resaltar_On(this);">
                        <asp:Label ID="Label29" runat="server" Font-Bold="True" Text="VI. SIGNATARIOS"></asp:Label></td>
                </tr>
                <tr>
                    <td style="vertical-align: top; height: 163px">
                        <table width="100%">
                            <tr onmouseout="Resaltar_Off(this);" onmouseover="Resaltar_On(this);">
                                <td style="height: 20px; text-align: left; width: 122px;">
                                    <asp:TextBox ID="R19" runat="server" CssClass="NRenglon" ReadOnly="True" Width="20px">19.</asp:TextBox>
                                    <asp:CheckBox ID="CE_PD" runat="server" Enabled="False" Text="CE" />
                                    <asp:CheckBox ID="CC_PD" runat="server" Enabled="False" Text="CC" />&nbsp;
                                </td>
                                <td colspan="2" style="width: 84px; height: 20px">
                                    &nbsp;&nbsp;
                                </td>
                                <td colspan="12" style="height: 20px">
                                    &nbsp;<asp:TextBox ID="R20" runat="server" CssClass="NRenglon" ReadOnly="True" Width="20px">20.</asp:TextBox>
                                    <asp:Label ID="LT20" runat="server" CssClass="TitDecl" Font-Bold="True"
                                        ForeColor="Black" Text="APELLIDOS Y NOMBRES DE QUIEN FIRMA EN CALIDAD DE DECLARANTE"
                                        Width="443px"></asp:Label></td>
                            </tr>
                            <tr onmouseout="Resaltar_Off(this);" onmouseover="Resaltar_On(this);">
                                <td style="width: 122px">
                                    <asp:TextBox ID="R21" runat="server" CssClass="NRenglon" ReadOnly="True" Width="20px">21.</asp:TextBox>
                                    <asp:Label ID="Label32" runat="server" CssClass="TitDecl" Font-Bold="True" Text="NÚMERO"
                                        Width="81px"></asp:Label></td>
                                <td colspan="2" style="width: 84px; text-align: right">
                                    <asp:Label ID="LbNRODOC_PD" runat="server" ForeColor="Black"></asp:Label></td>
                                <td colspan="12" style="height: 28px">
                                    &nbsp;<asp:Label ID="lbRAZSOC_PD" runat="server" ForeColor="Black" Width="336px"></asp:Label></td>
                            </tr>
                        </table>
                        <table width="100%">
                            <tr onmouseout="Resaltar_Off(this);" onmouseover="Resaltar_On(this);">
                                <td style="height: 23px; width: 108px;">
                                    <asp:TextBox ID="R22" runat="server" CssClass="NRenglon" ReadOnly="True" Width="20px">22.</asp:TextBox>
                                    <asp:CheckBox ID="CE_RF" runat="server" Enabled="False" Text="CE" />
                                    &nbsp;<asp:CheckBox ID="CC_RF" runat="server" Enabled="False" Text="CC" /></td>
                                <td colspan="2" style="height: 23px">
                                    &nbsp; &nbsp;
                                </td>
                                <td colspan="14" style="height: 23px">
                                    &nbsp;<asp:TextBox ID="R23" runat="server" CssClass="NRenglon" ReadOnly="True" Width="20px">23.</asp:TextBox>
                                    <asp:Label ID="Label48" runat="server" CssClass="TitDecl" Font-Bold="True"
                                        ForeColor="Black" Text="APELLIDOS Y NOMBRE DEL REVISOR FISCAL O CONTADOR"
                                        Width="369px"></asp:Label></td>
                            </tr>
                            <tr onmouseout="Resaltar_Off(this);" onmouseover="Resaltar_On(this);">
                                <td style="width: 108px; height: 20px">
                                    <asp:TextBox ID="R24" runat="server" CssClass="NRenglon" ReadOnly="True" Width="20px">24.</asp:TextBox><asp:Label ID="Label1" runat="server" CssClass="TitDecl" Font-Bold="True" Text="NÚMERO"
                                        Width="78px"></asp:Label></td>
                                <td colspan="2" style="height: 20px">
                                    <asp:Label ID="LbNRODOC_RF" runat="server" ForeColor="Black"></asp:Label></td>
                                <td colspan="14">
                                    <asp:Label ID="LbRAZSOC_RF" runat="server" ForeColor="Black" Width="336px"></asp:Label></td>
                            </tr>
                            <tr onmouseout="Resaltar_Off(this);" onmouseover="Resaltar_On(this);">
                                <td colspan="3" style="height: 11px">
                                    <asp:TextBox ID="R25" runat="server" CssClass="NRenglon" ReadOnly="True" Width="20px">25.</asp:TextBox>
                                    <asp:CheckBox ID="ChkContador" runat="server" Enabled="False" Text="Contador" />
                                    &nbsp;
                                    <asp:CheckBox ID="ChkRevisor" runat="server" Enabled="False" Text="Revisor Fiscal" /></td>
                                <td colspan="14" style="height: 11px">
                                    <asp:TextBox ID="R26" runat="server" CssClass="NRenglon" ReadOnly="True" Width="20px">26.</asp:TextBox>
                                    <asp:Label ID="Label4" runat="server" CssClass="TitDecl" ForeColor="Black"
                                        Text="TARJETA PROFESIONAL" Width="165px"></asp:Label>&nbsp;
                                    <asp:Label ID="LbTarPro" runat="server" ForeColor="Black" ></asp:Label></td>
                            </tr>
                        </table>
                    </td>
                </tr>
            </table>
            <br />
        </div>
        <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional">
        <ContentTemplate>
           <div id="flotante" onmouseout="this.style.display='none'"  onclick="this.style.display='none'"  onmouseover="this.style.display='block'" style="width: 145px; height: 30px">
               <table>
                   <tr>
                       <td style="width: 34px">
               <asp:ImageButton ID="btnInfo" runat="server" AlternateText="Ayuda" Height="25px"
                   ImageUrl="~/images/Operaciones/Help.png" OnClick="btnInfo_Click" OnClientClick="return false;"
                   Width="31px" /></td>
                       <td style="width: 100px">
                           Ver Ayuda</td>
                   </tr>
               </table>
          </div>
        <div id="flyout" style="display: none; overflow: hidden; z-index: 2; background-color: #FFFFFF; border: solid 1px #D0D0D0;"></div>
        <!-- Info panel to be displayed as a flyout when the button is clicked -->
        <div id="info" style="display: none; width: 250px; z-index: 2; margin:0 auto 0 auto; opacity: 0; filter: progid:DXImageTransform.Microsoft.Alpha(opacity=0); font-size: 12px; border: solid 1px #CCCCCC; background-color: #FFFFFF; padding: 5px;">
            <div id="btnCloseParent" style="float: right; opacity: 0; filter: progid:DXImageTransform.Microsoft.Alpha(opacity=0);">
                <asp:LinkButton id="btnClose" runat="server" OnClientClick="return false;" Text="X" ToolTip="Close"
                    Style="background-color: #666666; color: #FFFFFF; text-align: center; font-weight: bold; text-decoration: none; border: outset thin #FFFFFF; padding: 5px;" />
            </div>
            <div>
                <p>
                    <asp:label ID="LbAyudaTit" Text="VALOR BASE" runat="server" Font-Bold=true > </asp:label>
         
                <p>
                    <asp:label ID="LbAyuda" Text="Ayuda" runat="server" CssClass="TitDecl"> </asp:label>
	            <asp:HiddenField ID="HdRenglon" runat="server" />
                    &nbsp;
                </p>
                <br />
            </div>
        </div>
        
        <ajaxToolkit:AnimationExtender id="OpenAnimation" runat="server" TargetControlID="btnInfo">
            <Animations>
                <OnClick>
                    <Sequence>
                        <%-- Disable the button so it can't be clicked again --%>
                        <EnableAction Enabled="false" />
                        
                        <%-- Position the wire frame on top of the button and show it --%>
                        <ScriptAction Script="Cover($get('ctl00_SampleContent_btnInfo'), $get('flyout'));" />
                        <StyleAction AnimationTarget="flyout" Attribute="display" Value="block"/>
                        
                        <%-- Move the wire frame from the button's bounds to the info panel's bounds --%>
                        <Parallel AnimationTarget="flyout" Duration=".3" Fps="25">
                            <Move Horizontal="150" Vertical="-50" />
                            <Resize Width="260" Height="280" />
                            <Color PropertyKey="backgroundColor" StartValue="#AAAAAA" EndValue="#FFFFFF" />
                        </Parallel>
                        
                        <%-- Move the info panel on top of the wire frame, fade it in, and hide the frame --%>
                        <ScriptAction Script="Cover($get('flyout'), $get('info'), true);" />
                        <StyleAction AnimationTarget="info" Attribute="display" Value="block"/>
                        <FadeIn AnimationTarget="info" Duration=".2"/>
                        <StyleAction AnimationTarget="flyout" Attribute="display" Value="none"/>
                        
                        <%-- Flash the text/border red and fade in the "close" button --%>
                        <Parallel AnimationTarget="info" Duration=".5">
                            <Color PropertyKey="color" StartValue="#666666" EndValue="#FF0000" />
                            <Color PropertyKey="borderColor" StartValue="#666666" EndValue="#FF0000" />
                        </Parallel>
                        <Parallel AnimationTarget="info" Duration=".5">
                            <Color PropertyKey="color" StartValue="#FF0000" EndValue="#666666" />
                            <Color PropertyKey="borderColor" StartValue="#FF0000" EndValue="#666666" />
                            <FadeIn AnimationTarget="btnCloseParent" MaximumOpacity=".9" />
                        </Parallel>
                    </Sequence>
                </OnClick>
            </Animations>
        </ajaxToolkit:AnimationExtender>
        <ajaxToolkit:AnimationExtender id="CloseAnimation" runat="server" TargetControlID="btnClose">
            <Animations>
                <OnClick>
                    <Sequence AnimationTarget="info">
                        <%--  Shrink the info panel out of view --%>
                        <StyleAction Attribute="overflow" Value="hidden"/>
                        <Parallel Duration=".3" Fps="15">
                            <Scale ScaleFactor="0.05" Center="true" ScaleFont="true" FontUnit="px" />
                            <FadeOut />
                        </Parallel>
                        
                        <%--  Reset the sample so it can be played again --%>
                        <StyleAction Attribute="display" Value="none"/>
                        <StyleAction Attribute="width" Value="250px"/>
                        <StyleAction Attribute="height" Value=""/>
                        <StyleAction Attribute="fontSize" Value="12px"/>
                        <OpacityAction AnimationTarget="btnCloseParent" Opacity="0" />
                        
                        <%--  Enable the button so it can be played again --%>
                        <EnableAction AnimationTarget="btnInfo" Enabled="true" />
                    </Sequence>
                </OnClick>
                <OnMouseOver>
                    <Color Duration=".2" PropertyKey="color" StartValue="#FFFFFF" EndValue="#FF0000" />
                </OnMouseOver>
                <OnMouseOut>
                    <Color Duration=".2" PropertyKey="color" StartValue="#FF0000" EndValue="#FFFFFF" />
                </OnMouseOut>
             </Animations>
        </ajaxToolkit:AnimationExtender>
        </ContentTemplate>
            <Triggers>
                <asp:AsyncPostBackTrigger ControlID="btnInfo" EventName="Click" />
            </Triggers>
        </asp:UpdatePanel>
        </div>
        </ContentTemplate>
            <Triggers>
                <asp:AsyncPostBackTrigger ControlID="BtnLiq" EventName="Click" />
                <asp:AsyncPostBackTrigger ControlID="BtnGuardarD" EventName="Click" />
            </Triggers>
        </asp:UpdatePanel>
        &nbsp; &nbsp;
        <asp:ObjectDataSource ID="ObjLP" runat="server" OldValuesParameterFormatString="original_{0}"
            SelectMethod="GetRenglones" TypeName="CDeclaraciones">
            <SelectParameters>
                <asp:ControlParameter ControlID="Cla_Dec" DefaultValue="01" Name="Cla_Dec" PropertyName="Value"
                    Type="String" />
                <asp:Parameter DefaultValue="LP" Name="Sec_Cod" Type="String" />
                <asp:ControlParameter ControlID="HdFODE" DefaultValue="" Name="Fode_Codi" PropertyName="Value"
                    Type="String" />
            </SelectParameters>
        </asp:ObjectDataSource>
        <asp:ObjectDataSource ID="ObjVP" runat="server" OldValuesParameterFormatString="original_{0}"
            SelectMethod="GetRenglones" TypeName="CDeclaraciones">
            <SelectParameters>
                <asp:ControlParameter ControlID="Cla_Dec" DefaultValue="01" Name="Cla_Dec" PropertyName="Value"
                    Type="String" />
                <asp:Parameter DefaultValue="VP" Name="Sec_Cod" Type="String" />
                <asp:ControlParameter ControlID="HdFODE" DefaultValue="" Name="Fode_Codi" PropertyName="Value"
                    Type="String" />
            </SelectParameters>
        </asp:ObjectDataSource>
        &nbsp;
        <asp:ObjectDataSource ID="ObjTSANCIONES" runat="server" SelectMethod="GetRecords"
            TypeName="Tipo_Sanciones">
            <SelectParameters>
                <asp:ControlParameter ControlID="HdTD" Name="Dec_Tip" PropertyName="Value" />
            </SelectParameters>
        </asp:ObjectDataSource>
        <asp:ObjectDataSource ID="ObjCal" runat="server" SelectMethod="GetPorClaseDec" TypeName="Calendario">
            <SelectParameters>
                <asp:ControlParameter ControlID="Cla_Dec" Name="Cla_Dec" PropertyName="Value" Type="String" />
                <asp:ControlParameter ControlID="AGravable" Name="Vigencia" PropertyName="Text" />
            </SelectParameters>
        </asp:ObjectDataSource>
        <asp:ObjectDataSource ID="ObjCalVigencias" runat="server" OldValuesParameterFormatString="original_{0}"
            SelectMethod="GetVigencias" TypeName="Calendario">
            <SelectParameters>
                <asp:ControlParameter ControlID="Cla_Dec" Name="Cla_Dec" PropertyName="Value" Type="String" />
            </SelectParameters>
        </asp:ObjectDataSource>
        <asp:ObjectDataSource ID="ObjTipoDec" runat="server" SelectMethod="GetPorClaseDec"
            TypeName="Tipo_Dec">
            <SelectParameters>
                <asp:ControlParameter ControlID="Cla_Dec" Name="Cla_Dec" PropertyName="Value" Type="String" />
            </SelectParameters>
        </asp:ObjectDataSource>
        <asp:HiddenField ID="Cla_Dec" runat="server" Value="01" />
        <asp:HiddenField ID="HdOper" runat="server" />
        <asp:HiddenField ID="HdFODE" runat="server" /><asp:HiddenField ID="HdSancionMinima" runat="server" />
        <asp:HiddenField ID="HdExtem" runat="server" /><asp:HiddenField ID="HdFecLim" runat="server" />
        <asp:HiddenField ID="HdTot" runat="server" /><asp:HiddenField ID="HdTD" runat="server" /><asp:HiddenField ID="HdDecTip" runat="server" />
        <asp:HiddenField ID="HdTAG" runat="server" />
        <asp:HiddenField ID="HdFecDec" runat="server" /><asp:HiddenField ID="HdDOAD" runat="server" />
        <asp:HiddenField ID="HdFECPRE_INI" runat="server" />
        <asp:HiddenField ID="HdVALPAG_INI" runat="server" />
        <asp:HiddenField ID="HdVALPAG_INI_k" runat="server" />
        <br />
        <br />
        <asp:UpdatePanel ID="UpdatePanel3" runat="server">
            <ContentTemplate>
                <div style="width: 317px; height: 83px">
                    <asp:Panel ID="timer" runat="server" BackColor="White" BorderColor="#CCCCCC" BorderStyle="solid"
                        BorderWidth="0.5pt" ForeColor="#CCCCCC" Style="z-index: 1" Width="800px">
                        <div style="vertical-align: middle; width: 100%; height: 73%; text-align: center">
                            <p>
                                <table>
                                    <tr>
                                        <td style="width: 100px">
                                            <asp:ImageButton ID="BtnLiq" runat="server" ImageUrl="~/images/BotonesWeb/BtnLiq.png" OnClick="BtnLiq_Click" ToolTip="Liquidar Sanciones e Interéses" /></td>
                                        <td style="width: 100px">
                                            <asp:ImageButton ID="BtnGuardarD" runat="server" ImageUrl="~/images/BotonesWeb/BtGDec.png" OnClick="BtnGuardarD_Click" ToolTip="Guardar Formulario de Declaración" /></td>
                                        <td style="width: 100px">
                                            <asp:ImageButton ID="BtnGPDF" runat="server" ImageUrl="~/images/BotonesWeb/BtnGenPDF.png" Enabled="False" OnClick="BtnGPDF_Click" ToolTip="Generar Documento PDF para Impresión y entrega en Entidad Recaudadora" /></td>
                                        <td style="width: 100px">
                                            <asp:ImageButton ID="BtnIrAtras" runat="server" ImageUrl="~/images/BotonesWeb/BtnAtras.png" OnClick="BtnIrAtras_Click" ToolTip="Ir a Atrás " /></td>
                                    </tr>
                                </table>
                            </p>
                        </div>
                    </asp:Panel>
                    <ajaxToolkit:AlwaysVisibleControlExtender ID="avce" runat="server" HorizontalOffset="10"
                        HorizontalSide="Right" ScrollEffectDuration=".1" TargetControlID="timer" VerticalOffset="10"
                        VerticalSide="Top">
                    </ajaxToolkit:AlwaysVisibleControlExtender>
                </div>
                <p>
                    </p>
                   <ajaxToolkit:ConfirmButtonExtender id="ConfirmButtonExtender3" 
                   runat="server" TargetControlID="BtnGuardarD" 
                   OnClientCancel="cancelClick" 
                   DisplayModalPopupID="ModalPopupExtender2">

                </ajaxToolkit:ConfirmButtonExtender> <!-- Extender-->
         <ajaxToolkit:ModalPopupExtender id="ModalPopupExtender2" 
                runat="server" TargetControlID="BtnGuardarD" PopupDragHandleControlID="PnlTitle" 
                PopupControlID="PNL1" OkControlID="BtnAceptar" DropShadow="true" 
                CancelControlID="BtnCancelar" BackgroundCssClass="modalBackground">
                </ajaxToolkit:ModalPopupExtender>
        <!-- Modal-->
        <asp:Panel id="Pnl1" runat="server"  CssClass="ModalPanel">
        <div class="container">
                 <asp:Panel id="PnlTitle" runat="server" Height="30px" CssClass="BarTitleModal"> 
                    <div class="header">
                        <div style="float: left;"><% = Me.Titulo()%></div>
                    </div>
                    <asp:LinkButton ID="LinkButton1" runat="server" CssClass="close" />
                    </asp:Panel> 
                     <DIV style=" padding-left:5px; padding-right:8px; padding-top:8px; TEXT-ALIGN:justify;">
                     <asp:Label id="LbMsg" runat="server" Text="<%$ AppSettings:MSG_PRE_DEC %>" Width="100%"/>
                     <asp:Label id="lbMsgP" runat="server" style="text-align:center" Text="<b>¿Desea Guardar la Declaración?</b>" Width="100%"/>
                     </div>  
                      <div style="padding-top:10px; text-align:center"> 
                        <asp:Button id="BtnAceptar" runat="server" Text="Si" Width="62px"></asp:Button> 
                        &nbsp; <asp:Button id="BtnCancelar" runat="server" Text="No" Width="62px"></asp:Button> <BR /><BR /></DIV>
                      </div>            
                     </asp:Panel> <!-- End Panel Modal -->           
                     
  
            </ContentTemplate>
            <Triggers>
                <asp:PostBackTrigger ControlID="BtnGPDF" />
            </Triggers>
        </asp:UpdatePanel>
        &nbsp;
        <asp:UpdatePanel ID="UpdatePanel4" runat="server">
            <ContentTemplate>
        <asp:Button ID="hiddenTargetControlForModalPopup" runat="server" Style="display: none"
            Width="35px" /><ajaxToolkit:ModalPopupExtender ID="ModalPopup" runat="server" BackgroundCssClass="modalBackground"
                BehaviorID="programmaticModalPopupBehavior" DropShadow="True" PopupControlID="programmaticPopup"
                PopupDragHandleControlID="programmaticPopupDragHandle" RepositionMode="RepositionOnWindowScroll"
                TargetControlID="hiddenTargetControlForModalPopup">
            </ajaxToolkit:ModalPopupExtender>
            
        <asp:Panel ID="programmaticPopup" runat="server" CssClass="ModalPanel" Width="361px" Height="150px" 
                       style="BORDER-RIGHT: black 1px solid; BORDER-TOP: black 1px solid;BORDER-LEFT: black 1px solid;BORDER-BOTTOM: black 1px solid;">             
            <!-- MODAL DE SALIDA -->
            <asp:Panel ID="programmaticPopupDragHandle" runat="Server" CssClass="BarTitleModal2" Height="30px"
                style="font-size:8pt; width:100%;height:30px;background-repeat:repeat-x;cursor:move;font-weight:bold;
                       BORDER-RIGHT: gray 0,5pt solid; BORDER-TOP: gray 0,5pt solid;BORDER-LEFT: gray 0,5pt solid;BORDER-BOTTOM: gray 0,5pt solid;CURSOR: move;background-color:#ccccccs;Color:#333333;">
                <div style="padding: 5px; vertical-align: middle;">
                    <div style="float: left;">
                        <%=Me.Titulo()%>
                    </div>
                    <div style="float: right;">
                        <input id="hideModalPopupViaClientButton" type="button" value="X" /></div>
                    </div>
            </asp:Panel>
                <DIV style=" padding-left:5px; padding-right:8px; padding-top:8px; TEXT-ALIGN:justify;">
                <asp:Image ID="ImgRst" runat="server" ImageUrl="~/images/Error.gif" />
                <asp:Label ID="MsgResult" runat="server" Height="33px" Width="278px" ForeColor="Black"></asp:Label>
                </DIV>
        </asp:Panel>
        
        <asp:HiddenField ID="HdNroDec" runat="server" />
            </ContentTemplate>
        </asp:UpdatePanel>
        <asp:UpdateProgress ID="UpdateProgress1" runat="server" AssociatedUpdatePanelID="UpdatePanel3">
            <ProgressTemplate>
                <div class="Loading">
                    <img alt="" src="../../images/loading.gif" title="" />
                    Cargando …
                </div>
            </ProgressTemplate>
        </asp:UpdateProgress>
        &nbsp;<!--
            Generamos el div con tres eventos del mouse:
	        onmouseout = en el momento que el raton desaparezca del div,
	        se escondera el div
	        onclick = si se realiza unclick en el div, se escondera el div
	        onmouseover = miestras el raton este encima del div, se indica
	        que se muestre el div. No se si es del todo necesaria esta
	        casilla...
	        	        <br /><span id="posicion"></span>
            --><!-- "Wire frame" div used to transition from the button to the info panel -->
        <script type="text/javascript" language="javascript">
            // Move an element directly on top of another element (and optionally
            // make it the same size)
            function detectBrowser() {
                var ie = document.all != undefined;
                var opera = window.opera != undefined;
               if (opera) return "opera";
                if (ie) return "ie";
                if ((window)&&(window.netscape)&&(window.netscape.security)) {
                if (window.XML) {
                return "firefox15";
                }
                else return "firefox10";
                }
                return "ie";      // Si no sabemos que navegador es, devolvemos ie.
            }

            function Cover(bottom, top, ignoreSize) {
                var location = Sys.UI.DomElement.getLocation(bottom);
                top.style.position = 'absolute';
                top.style.top = location.y + 'px';
                top.style.left = location.x + 'px';
                if (detectBrowser()=='ie'){
                var t=new String((window.screen.availHeight/2)-150);
                var l=new String(window.screen.availWidth/2-400);
                top.style.top =  t+'px';
                top.style.left = l+'px';
                }
                else
                {
                top.style.top='300px';
                top.style.left='300px';
                }
                if (!ignoreSize) {
                    top.style.height = bottom.offsetHeight + 'px';
                    top.style.width = bottom.offsetWidth + 'px';
                }
            }
        </script>
    </form>
</body>
</html>
