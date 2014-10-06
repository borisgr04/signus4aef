<%@ Page Language="VB" AutoEventWireup="false" CodeFile="recibooficial2.aspx.vb" Inherits="recibooficial2" %>

<%@ Register Assembly="eWorld.UI.Compatibility, Version=2.0.6.2393, Culture=neutral, PublicKeyToken=24d65337282035f2"
    Namespace="eWorld.UI.Compatibility" TagPrefix="cc2" %>
<%@ Register Assembly="eWorld.UI, Version=2.0.6.2393, Culture=neutral, PublicKeyToken=24d65337282035f2"
    Namespace="eWorld.UI" TagPrefix="ew" %>
<%@ Register Assembly="ControlesWeb" Namespace="ControlesWeb" TagPrefix="cc1" %>
<%@ Register Assembly="Microsoft.ReportViewer.WebForms, Version=10.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a"
    Namespace="Microsoft.Reporting.WebForms" TagPrefix="rsweb" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Untitled Page</title>
    <link href="../../Css/declaracion.css" rel="stylesheet" type="text/css" />
    <script src="../../js/Numeric.js" type="text/javascript"></script>
    <script type='text/javascript'>
        // Add click handlers for buttons to show and hide modal popup on pageLoad
         function cancelClick() {
          //var label = $get('ctl00_SampleContent_LbRpt');
          //label.innerHTML = 'You hit cancel in the Confirm dialog on ' + (new Date()).localeFormat("T") + '.';
          }
        function pageLoad() {
            //$addHandler($get("showModalPopupClientButton"), 'click', showModalPopupViaClient);
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
<body scroll="yes">
    <form id="form1" runat="server" onKeypress="if(event.keyCode == 13) event.returnValue = false;">
        <ajaxToolkit:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server">
        </ajaxToolkit:ToolkitScriptManager>
        <script src="../../js/Declaraciones.js" type="text/javascript"></script>
        &nbsp;&nbsp;&nbsp; &nbsp; &nbsp;
     
        <asp:UpdatePanel ID="UpdatePanel2" runat="server" >
        <ContentTemplate>
        <div  style="width:100%;height:650px;margin:0 auto 0 auto;border:solid 0,5pt;overflow:scroll;" > &nbsp;
            <div class="DecHeaderP" id="DIV1" onclick="return DIV1_onclick()">
        &nbsp;<asp:Label ID="LBTITULO" runat="server" CssClass="Titulo" Text="DECLARACIÓN DE " Visible="False"></asp:Label><br />
        
        <table width="100%" class="tbHeaderDec">
            <tr>
                <td style="width: 435px">
                    <asp:Label ID="Label18" runat="server" CssClass="SubTitulo" Font-Bold="True" Text="DEPARTAMENTO DEL CESAR"></asp:Label></td>
                <td style="width: 457px">
                </td>
            </tr>
            <tr>
                <td colspan="2">
                    <asp:Label ID="Label22" runat="server" Font-Bold="True" 
                        Text="Recibo Oficial de Pago"></asp:Label></td>
            </tr>
            <tr>
                <td rowspan="3" style="width: 435px">
                    <img src="../../images/Reportes/Img_gob.jpg" /></td>
                <td style="width: 457px; text-align: right">
                    <asp:Label ID="lbnorecof" runat="server" Font-Bold="True"></asp:Label></td>
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
            <asp:Label ID="Errormsg" runat="server" CssClass="TitDecl"></asp:Label></div>
        
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
                    &nbsp;<asp:Label ID="AGravable" runat="server" CssClass="TitDecl" Width="132px"></asp:Label>
                    </td>
                <td style="width: 8px">
                    <asp:TextBox ID="R2" runat="server" CssClass="NRenglon" ReadOnly="True" Width="100%">2.</asp:TextBox></td>
                <td style="width: 100px" class="TDNegroTexto">
                    <asp:Label ID="LbPGravable" runat="server" Font-Bold="True" CssClass="TitDecl" Text="PERIODO GRAVABLE"
                        Width="133px"></asp:Label></td>
                <td style="width: 100px">
                    &nbsp;<asp:Label ID="PGravable" runat="server" CssClass="TitDecl"></asp:Label></td>
            </tr>
        </table>
    </div>
        <div class="DecHeader">
            <table width="100%">
                <tr class="DivNegroFila" onmouseout="Resaltar_Off(this);" onmouseover="Resaltar_On(this);">
                    <td style="height: 13px; width: 697px;">
                        <asp:Label ID="Label10" runat="server" Font-Bold="True" Text="II. INFORMACIÓN DEL RESPONSABLE O AGENTE RETENEDOR"></asp:Label></td>
                </tr>
                <tr>
                    <td style="width: 697px">
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
            <div class="DecHeader">
            <table border="0" cellpadding="0" cellspacing="0" class="datatable">
                <tr class="DivNegroFila">
                    <td style="width: 26px; height: 26px">&nbsp;
                    </td>
                    <td style="width: 1072px; height: 26px">
                        VALOR A PAGAR IMPUESTOS</td>
                    <td style="width: 138px; height: 26px">
                        <cc2:NumericBox ID="TXTVP" runat="server" AutoFormatCurrency="True" CssClass="TxtNumC" DecimalSign="," GroupingSeparator="." TextAlign="Right" ></cc2:NumericBox></td>
                </tr>
                <tr>
                    <td style="width: 26px; height: 26px">&nbsp;
                    </td>
                    <td style="width: 1072px; height: 26px">
                        VALOR A PAGAR SANCIONES</td>
                    <td style="width: 138px; height: 26px">
                        <cc2:NumericBox ID="TXTSAN" runat="server" AutoFormatCurrency="True" CssClass="TxtNum" DecimalSign="," GroupingSeparator="." TextAlign="Right" ></cc2:NumericBox></td>
                </tr>
                <tr>
                    <td style="width: 26px; height: 23px">&nbsp;
                    </td>
                    <td style="width: 1072px; height: 23px">
                        INTERESES MORA</td>
                    <td style="width: 138px; height: 23px">
                        <cc2:NumericBox ID="TXTINT" runat="server" AutoFormatCurrency="True" CssClass="TxtNum" DecimalSign="," GroupingSeparator="." TextAlign="Right" ></cc2:NumericBox></td>
                </tr>
                <tr>
                    <td style="width: 26px">&nbsp;
                    </td>
                    <td style="width: 1072px">
                        TOTAL A PAGAR</td>
                    <td style="width: 138px">
                        <cc2:NumericBox ID="TXTTOTP" runat="server" AutoFormatCurrency="True" CssClass="TxtNum" DecimalSign="," GroupingSeparator="." TextAlign="Right" ></cc2:NumericBox></td>
                </tr>
            </table>
            </div>
        <div class="DecHeader">
           </div>
        <div class="DecHeader">
        <br />
        </div>
        <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional">
        <ContentTemplate>
           <div id="flotante" onmouseout="this.style.display='none'"  onclick="this.style.display='none'"  onmouseover="this.style.display='block'" style="width: 145px; height: 30px">
               <table>
                   <tr>
                       <td style="width: 34px">
               <asp:ImageButton ID="btnInfo" runat="server" AlternateText="Ayuda" Height="25px"
                   ImageUrl="~/images/Operaciones/Help.png" 
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
        <asp:ObjectDataSource ID="ObjVP" runat="server" OldValuesParameterFormatString="original_{0}"
            SelectMethod="GetRenglonesRP" TypeName="ReciboOf">
            <SelectParameters>
                <asp:ControlParameter ControlID="Cla_Dec" DefaultValue="01" Name="Cla_Dec" PropertyName="Value"
                    Type="String" />
                <asp:Parameter DefaultValue="VP" Name="Sec_Cod" Type="String" />
                <asp:ControlParameter ControlID="HdFODE" DefaultValue="" Name="Fode_Codi" PropertyName="Value"
                    Type="String" />
                <asp:ControlParameter ControlID="AGravable" DefaultValue="" Name="A&#241;o" PropertyName="Text" />
                <asp:ControlParameter ControlID="PGravable" Name="Per" PropertyName="Text" />
                <asp:ControlParameter ControlID="Identificaci&#242;n" Name="Nit" PropertyName="Text" />
            </SelectParameters>
        </asp:ObjectDataSource>
        </div>
            <br />
        <asp:MultiView ID="MultiView1" runat="server">
            <asp:View ID="View1" runat="server">
                <rsweb:ReportViewer ID="ReportViewer1" runat="server" Height="33px" Width="671px">
                </rsweb:ReportViewer>
            </asp:View>
        </asp:MultiView>&nbsp;
            <asp:HiddenField ID="HidNroReof" runat="server" />
        </ContentTemplate>
        </asp:UpdatePanel>
        &nbsp; &nbsp;&nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
        <asp:HiddenField ID="HdCodDec" runat="server" />
        <asp:HiddenField ID="HdTDocAdm" runat="server" />
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
        &nbsp; &nbsp;
        <asp:ObjectDataSource ID="ObjTSANCIONES" runat="server" SelectMethod="GetRecords"
            TypeName="Sanciones">
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
        <br />
        <br />
        <asp:UpdatePanel ID="UpdatePanel3" runat="server">
            <ContentTemplate>
                <div style="width: 230px; height: 100px">
                    <asp:Panel ID="timer" runat="server" BackColor="White" BorderColor="#CCCCCC" BorderStyle="solid"
                        BorderWidth="0.5pt" ForeColor="#CCCCCC" Style="z-index: 1" Width="469px">
                        <div style="vertical-align: middle; width: 96%; height: 100%; text-align: center">
                            <p>
                                <table>
                                    <tr>
                                        <td style="width: 100px">
                                            <asp:ImageButton ID="BImGDE" runat="server" ImageUrl="~/images/BotonesWeb/BtGDec.png"
                                                OnClick="BImGDE_Click" /></td>
                                        <td style="width: 100px">
                                            <asp:ImageButton ID="BImGPDF" runat="server" ImageUrl="~/images/BotonesWeb/BtnGenPDF.png"
                                                OnClick="BImGPDF_Click" /></td>
                                        <td style="width: 100px">
                                            <asp:ImageButton ID="BtnIrAtras" runat="server" 
                                                ImageUrl="~/images/BotonesWeb/BtnAtras.png" OnClick="BtnIrAtras_Click" 
                                                ToolTip="Ir a Atrás " />
                                        </td>
                                    </tr>
                                </table>
                                &nbsp; &nbsp;&nbsp;&nbsp;</p>
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
                   runat="server" TargetControlID="BImGDE" 
                   OnClientCancel="cancelClick" 
                   DisplayModalPopupID="ModalPopupExtender2">

                </ajaxToolkit:ConfirmButtonExtender> <!-- Extender-->
         <ajaxToolkit:ModalPopupExtender id="ModalPopupExtender2" 
                runat="server" TargetControlID="BImGDE" PopupDragHandleControlID="PnlTitle" 
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
                <asp:PostBackTrigger ControlID="BImGPDF" />
            </Triggers>
        </asp:UpdatePanel>
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
            &nbsp;&nbsp;
                <asp:Image ID="ImgRst" runat="server" ImageUrl="~/images/Error.gif" />
                <asp:Label ID="MsgResult" runat="server" Height="33px" Width="278px" ForeColor="Black"></asp:Label><br />
                <br />
            &nbsp;<br />
            &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
            &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
            &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
                <br />
            <br />
        </asp:Panel>
        
        <asp:HiddenField ID="HdNro" runat="server" />
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
function DIV1_onclick() {

}

        </script>
    </form>
</body>
</html>
