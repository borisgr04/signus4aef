<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="SelDec.aspx.vb" 
Inherits="Declaraciones_Diligenciar_SelDec" title="Untitled Page" EnableEventValidation="false" %>
<%@ Register Src="../../CtrlUsr/Terceros/ConsultaTer.ascx" TagName="ConsultaTer" TagPrefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="SampleContent" Runat="Server">
    <ajaxToolkit:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server" EnablePageMethods="true">
    </ajaxToolkit:ToolkitScriptManager>
<script type='text/javascript'>
    function cancelClick() {
        var label = $get('ctl00_SampleContent_LbRpt');
        //label.innerHTML = 'You hit cancel in the Confirm dialog on ' + (new Date()).localeFormat("T") + '.';
    }
        // Add click handlers for buttons to show and hide modal popup on pageLoad
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
        }
        
         function enviar(tdoc,ced,dv,rsocial,tip_ter)
        {
            if(tip_ter=='AR'){
                document.aspnetForm.<%=Me.Nit.ClientID%>.value=ced;
                document.aspnetForm.<%=Me.DV.ClientID%>.value=dv;
                document.aspnetForm.<%=Me.Agente.ClientID%>.value=rsocial;
            }
            var modalPopupBehavior = $find('programmaticModalPopupBehavior');
            modalPopupBehavior.hide();
            __doPostBack("<%= button.ClientID %>","");
            __doPostBack("<%= CbCdec.ClientID %>","");
            UpdateCombo();
            
            
        }
        
        function UpdateCombo()
        {
             var no =document.getElementById("<%= CbCdec.ClientID %>").options.length;
            if (no==1)  __doPostBack("<%= CbCdec.ClientID %>","");
            //__doPostBack("<%= CbCdec.ClientID %>","");
            
        }

    </script>
<div class="demoarea">
 
<asp:Label ID="LBTITULO" runat="server" CssClass="Titulo">DILIGENCIAR DECLARACIÓN PRIVADA</asp:Label>&nbsp;
    <div class="DecHeader">

        
        
        <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional"   >
            <ContentTemplate>
&nbsp;<asp:Label id="MsgResult" runat="server" Width="90%" Height="30px" __designer:wfdid="w9"></asp:Label>&nbsp; <BR />
                <TABLE style="WIDTH: 626px" __designer:dtid="844424930131979"><TBODY><TR onmouseover="Resaltar_On(this);" onmouseout="Resaltar_Off(this);" __designer:dtid="844424930131980"><TD style="HEIGHT: 13px" class="TDNegroFila" __designer:dtid="844424930131981"><asp:Label id="Label10" runat="server" Font-Bold="True" __designer:dtid="844424930131982" __designer:wfdid="w10" Text="AGENTE RECAUDADOR"></asp:Label>&nbsp;&nbsp; <asp:Button style="DISPLAY: none" id="button" onclick="button_Click" runat="server" __designer:dtid="3096246218653697" __designer:wfdid="w198"></asp:Button></TD></TR><TR __designer:dtid="844424930131984"><TD __designer:dtid="844424930131985"><TABLE width="100%" __designer:dtid="844424930131986"><TBODY><TR onmouseover="Resaltar_On(this);" onmouseout="Resaltar_Off(this);" __designer:dtid="844424930131987"><TD style="WIDTH: 25px; HEIGHT: 15px" __designer:dtid="844424930131988"><asp:Label id="Label45" runat="server" Width="115px" Font-Bold="True" __designer:dtid="844424930131989" CssClass="TitDecl" __designer:wfdid="w12" Text="IDENTIFICACIÓN"></asp:Label></TD><TD style="WIDTH: 51px; HEIGHT: 15px" __designer:dtid="844424930131990">&nbsp;<asp:Label id="Label2" runat="server" Font-Bold="True" __designer:dtid="844424930131991" CssClass="TitDecl" __designer:wfdid="w13" Text="DV"></asp:Label> </TD><TD style="WIDTH: 31px; HEIGHT: 15px"></TD><TD style="WIDTH: 131px; HEIGHT: 15px" __designer:dtid="844424930131992"><asp:Label id="Label11" runat="server" Font-Bold="True" __designer:dtid="844424930131993" CssClass="TitDecl" __designer:wfdid="w14" Text="RAZON SOCIAL"></asp:Label></TD><TD style="WIDTH: 253px; HEIGHT: 15px" __designer:dtid="844424930131994"></TD>
                    <td __designer:dtid="844424930131994" rowspan="2" 
                        style="WIDTH: 253px; text-align: center;">
                        <asp:ImageButton ID="BtnIDil" runat="server" 
                            ImageUrl="~/images/imagev2/blog-post-edit-icon.png" 
                            ToolTip="Click, para diligenciar la Declaración" ValidationGroup="Dil" />
                    </td>
                    </TR>
                    <TR  __designer:dtid="844424930131995"><TD style="HEIGHT: 19px; TEXT-ALIGN: right" vAlign=top __designer:dtid="844424930131996"><asp:TextBox id="Nit" runat="server" __designer:dtid="844424930131997" __designer:wfdid="w15" Enabled="False"></asp:TextBox>&nbsp; </TD><TD style="WIDTH: 51px; HEIGHT: 19px" vAlign=top __designer:dtid="844424930131998"><asp:TextBox id="Dv" runat="server" Width="17px" __designer:dtid="844424930131999" __designer:wfdid="w16" Enabled="False"></asp:TextBox>&nbsp;</TD><TD style="WIDTH: 31px; HEIGHT: 19px" vAlign=top><asp:Button accessKey="B" id="BtnBuscDP" onclick="BtnBuscar_Click" runat="server" __designer:wfdid="w2" Text="..." UseSubmitBehavior="False" ToolTip="Buscar Agente Recaudador"></asp:Button></TD><TD style="HEIGHT: 19px" vAlign=top colSpan=2 __designer:dtid="844424930132000"><asp:TextBox id="Agente" runat="server" Width="332px" __designer:dtid="844424930132001" __designer:wfdid="w17" Enabled="False"></asp:TextBox></TD></TR><TR onmouseover="Resaltar_On(this);" onmouseout="Resaltar_On(this);" __designer:dtid="844424930132002"><TD style="HEIGHT: 19px" colSpan=5 __designer:dtid="844424930132003">
                    &nbsp;</TD>
                    <td __designer:dtid="844424930132003" style="HEIGHT: 19px; text-align: center;">
                        Diligenciar Formulario</td>
                    </TR>
                    <tr __designer:dtid="844424930132002" onmouseover="Resaltar_On(this);" 
                    onmouseout="Resaltar_Off(this);"
                        >
                        <td __designer:dtid="844424930132003" colspan="5" style="HEIGHT: 19px">
                            <asp:Label ID="Label1" runat="server" __designer:dtid="844424930132004" 
                                __designer:wfdid="w18" CssClass="TitDecl" Font-Bold="True" 
                                Text="SELECCIONE LA CLASE DE DECLARACION" Width="261px"></asp:Label>
                            <asp:DropDownList ID="CbCdec" runat="server" __designer:dtid="844424930132007" 
                                __designer:wfdid="w19" AutoPostBack="True" DataSourceID="ObjCDec" 
                                DataTextField="CLD_NOM" DataValueField="CLD_COD" 
                                OnSelectedIndexChanged="CbCdec_SelectedIndexChanged">
                            </asp:DropDownList>
                        </td>
                        <td __designer:dtid="844424930132003" style="HEIGHT: 19px">
                            &nbsp;</td>
                    </tr>
                    </TBODY></TABLE></TD></TR></TBODY></TABLE><TABLE style="WIDTH: 631px"><TBODY><TR onmouseover="Resaltar_On(this);" class="TbDecl" onmouseout="Resaltar_Off(this);">
                    <TD colSpan=7>
                    <asp:Label id="LbI" runat="server" Font-Bold="True" __designer:wfdid="w20" 
                        Text="PERIODO DE DECLARACION"></asp:Label>&nbsp;</TD></TR><TR onmouseover="Resaltar_On(this);" onmouseout="Resaltar_Off(this);"><TD style="WIDTH: 7px"></TD><TD style="WIDTH: 100px"><asp:Label id="Label14" runat="server" CssClass="TitDecl" __designer:wfdid="w21" Text="AÑO GRAVABLE"></asp:Label></TD><TD style="WIDTH: 100px"><asp:DropDownList id="CboVigencia" runat="server" __designer:wfdid="w22" DataValueField="cal_vig" DataTextField="cal_vig" DataSourceID="ObjCalVigencias" AutoPostBack="True">
                    </asp:DropDownList> <asp:RequiredFieldValidator id="RequiredFieldValidator1" runat="server" __designer:wfdid="w2" ValidationGroup="Dil" ControlToValidate="CbCdec">*</asp:RequiredFieldValidator></TD><TD style="WIDTH: 8px"></TD><TD style="WIDTH: 100px"><asp:Label id="Label13" runat="server" Width="133px" CssClass="TitDecl" __designer:wfdid="w23" Text="PERIODO GRAVABLE"></asp:Label></TD><TD style="WIDTH: 128px" vAlign=middle>
                        <asp:DropDownList id="Periodo" runat="server" __designer:wfdid="w24" 
                            OnSelectedIndexChanged="Periodo_SelectedIndexChanged" DataValueField="cal_per" 
                            DataTextField="cal_des" DataSourceID="ObjCal" AutoPostBack="True">
                        </asp:DropDownList> <asp:RequiredFieldValidator id="RequiredFieldValidator2" runat="server" __designer:wfdid="w4" ValidationGroup="Dil" ControlToValidate="Periodo">*</asp:RequiredFieldValidator></TD>
                        <td style="WIDTH: 128px" valign="middle">
                            <asp:Button ID="BtnAct" runat="server" Text="Ver Liquidación" />
                        </td>
                    </TR>
                    <TR onmouseover="Resaltar_On(this);" onmouseout="Resaltar_Off(this);" 
                        class="TbDecl"><TD colspan="7">
                            <asp:Label ID="Label5" runat="server" __designer:wfdid="w25" Font-Bold="True" 
                                Text="TIPO DE DECLARACIÓN"></asp:Label>
                        </TD></TR><TR onmouseover="Resaltar_On(this);" onmouseout="Resaltar_Off(this);"><TD style="WIDTH: 7px"></TD><TD colSpan=2><asp:RadioButtonList id="ROptTD" runat="server" __designer:wfdid="w26" DataValueField="TDEC_COD" DataTextField="TDEC_NOM" DataSourceID="ObjTDec"></asp:RadioButtonList> </TD>
                        <TD colspan="4">
                            <asp:CheckBox ID="ChkDecCero" runat="server" Font-Bold="True" 
                                Text="Declaración en Cero (0)" />
                        </TD></TR>
                    <tr onmouseout="Resaltar_Off(this);" onmouseover="Resaltar_On(this);">
                        <td style="WIDTH: 7px">
                            &nbsp;</td>
                        <td colspan="2">
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" 
                                ControlToValidate="ROptTD" ErrorMessage="Debe Seleccionar Tipo de Declaración" 
                                ValidationGroup="Dil"></asp:RequiredFieldValidator>
                        </td>
                        <td colspan="4">
                            &nbsp;</td>
                    </tr>
                    </TBODY></TABLE><TABLE width="100%" border=0 __designer:dtid="3659174697238541"><TBODY><TR __designer:dtid="3659174697238542">
                    <TD onmouseover="Resaltar_On(this);" class="TbDecl" 
                        onmouseout="Resaltar_Off(this);" colSpan=5 __designer:dtid="3659174697238543">&nbsp;<asp:Label id="Label29" runat="server" __designer:dtid="3659174697238544" __designer:wfdid="w29" Text="SIGNATARIOS"></asp:Label></TD></TR><TR __designer:dtid="3659174697238545">
                        <TD style="HEIGHT: 78px; TEXT-ALIGN: left" __designer:dtid="3659174697238546" 
                            colspan="5"><asp:FormView id="FormView1" runat="server" __designer:wfdid="w161" DataSourceID="ObjSign"><ItemTemplate>
<TABLE width="100%" __designer:dtid="3659174697238547"><TBODY><TR onmouseover="Resaltar_On(this);" onmouseout="Resaltar_Off(this);" __designer:dtid="3659174697238548"><TD style="HEIGHT: 20px" colSpan=17 __designer:dtid="3659174697238549"><asp:Label id="Label7" runat="server" Font-Bold="True" Text="DECLARANTE" __designer:dtid="3659174697238550" CssClass="TitDecl" __designer:wfdid="w181"></asp:Label></TD></TR><TR onmouseover="Resaltar_On(this);" onmouseout="Resaltar_Off(this);" __designer:dtid="3659174697238551"><TD style="WIDTH: 30px; HEIGHT: 20px" __designer:dtid="3659174697238552"></TD><TD style="WIDTH: 100px; HEIGHT: 20px" __designer:dtid="3659174697238553"><asp:Label id="Label31" runat="server" Text="TIPO DOCUMENTO" __designer:dtid="3659174697238554" CssClass="TitDecl" __designer:wfdid="w182" Width="111px"></asp:Label></TD><TD style="WIDTH: 83px; HEIGHT: 20px" __designer:dtid="3659174697238555"><asp:Label id="Label32" runat="server" Text="IDENTIFICACIÓN" __designer:dtid="3659174697238556" CssClass="TitDecl" __designer:wfdid="w183"></asp:Label></TD><TD style="WIDTH: 25px" __designer:dtid="3659174697238557"></TD><TD style="WIDTH: 25px" __designer:dtid="3659174697238558"></TD><TD style="WIDTH: 345px; HEIGHT: 20px" colSpan=12 __designer:dtid="3659174697238559">&nbsp;<asp:Label id="Label35" runat="server" Text="APELLIDOS Y NOMBRES" __designer:dtid="3659174697238560" CssClass="TitDecl" __designer:wfdid="w184"></asp:Label></TD></TR><TR onmouseover="Resaltar_On(this);" onmouseout="Resaltar_Off(this);" __designer:dtid="3659174697238561"><TD style="HEIGHT: 7px" __designer:dtid="3659174697238562"></TD><TD style="HEIGHT: 7px" __designer:dtid="3659174697238563"><asp:TextBox id="TXTTIPDOC_PD" runat="server" Text='<%# Eval("DEC_TDOC") %>' __designer:dtid="3659174697238564" __designer:wfdid="w185" Width="34px" Enabled="False"></asp:TextBox> </TD><TD style="WIDTH: 83px; HEIGHT: 7px" __designer:dtid="3659174697238565"><asp:TextBox id="TXTNRODOC_PD" runat="server" Text='<%# Eval("DEC_NIT") %>' __designer:dtid="3659174697238566" __designer:wfdid="w186" Width="94px" Enabled="False"></asp:TextBox>&nbsp; </TD><TD style="WIDTH: 25px; HEIGHT: 7px" __designer:dtid="3659174697238567">&nbsp;</TD><TD style="WIDTH: 25px; HEIGHT: 7px" __designer:dtid="3659174697238568">&nbsp;</TD><TD style="WIDTH: 345px; HEIGHT: 7px" colSpan=12 __designer:dtid="3659174697238569"><asp:TextBox id="TXTRAZSOC_PD" runat="server" Text='<%# Eval("DEC_NOM") %>' __designer:dtid="3659174697238570" __designer:wfdid="w187" Width="336px" Enabled="False"></asp:TextBox></TD></TR><TR onmouseover="Resaltar_On(this);" onmouseout="Resaltar_Off(this);" __designer:dtid="3659174697238571"><TD colSpan=17 __designer:dtid="3659174697238572"><asp:Label id="Label9" runat="server" Font-Bold="True" Text="CONTADOR O REVISOR FISCAL" __designer:dtid="3659174697238573" CssClass="TitDecl" __designer:wfdid="w188"></asp:Label></TD></TR><TR onmouseover="Resaltar_On(this);" onmouseout="Resaltar_Off(this);" __designer:dtid="3659174697238574"><TD style="HEIGHT: 15px" __designer:dtid="3659174697238575"></TD><TD style="HEIGHT: 15px" __designer:dtid="3659174697238576"><asp:Label id="Label44" runat="server" Text="TIPO DOCUMENTO" __designer:dtid="3659174697238577" CssClass="TitDecl" __designer:wfdid="w189" Width="111px"></asp:Label></TD><TD style="WIDTH: 83px; HEIGHT: 15px" __designer:dtid="3659174697238578"><asp:Label id="Label3" runat="server" Text="IDENTIFICACIÓN" __designer:dtid="3659174697238579" CssClass="TitDecl" __designer:wfdid="w190"></asp:Label></TD><TD style="WIDTH: 25px; HEIGHT: 15px" __designer:dtid="3659174697238580"></TD><TD style="WIDTH: 25px; HEIGHT: 15px" __designer:dtid="3659174697238581"></TD><TD style="WIDTH: 345px; HEIGHT: 15px" colSpan=12 __designer:dtid="3659174697238582"><asp:Label id="Label48" runat="server" Text="APELLIDOS Y NOMBRES" __designer:dtid="3659174697238583" CssClass="TitDecl" __designer:wfdid="w191"></asp:Label></TD></TR><TR onmouseover="Resaltar_On(this);" onmouseout="Resaltar_Off(this);" __designer:dtid="3659174697238584"><TD style="HEIGHT: 15px" __designer:dtid="3659174697238585"></TD><TD style="HEIGHT: 15px" __designer:dtid="3659174697238586"><asp:TextBox id="TXTTIPDOC_RF" runat="server" Text='<%# Eval("REV_TDOC") %>' __designer:dtid="3659174697238587" __designer:wfdid="w192" Width="34px" Enabled="False"></asp:TextBox></TD><TD style="WIDTH: 83px; HEIGHT: 15px" __designer:dtid="3659174697238588"><asp:TextBox id="TXTNRODOC_RF" runat="server" Text='<%# Eval("REV_NIT") %>' __designer:dtid="3659174697238589" __designer:wfdid="w193" Width="90px" Enabled="False"></asp:TextBox></TD><TD style="WIDTH: 25px; HEIGHT: 15px" __designer:dtid="3659174697238590"></TD><TD style="WIDTH: 25px; HEIGHT: 15px" __designer:dtid="3659174697238591"></TD><TD style="WIDTH: 345px; HEIGHT: 15px" colSpan=12 __designer:dtid="3659174697238592"><asp:TextBox id="TXTRAZSOC_RF" runat="server" Text='<%# Eval("REV_NOM") %>' __designer:dtid="3659174697238593" __designer:wfdid="w194" Width="323px" Enabled="False"></asp:TextBox></TD></TR><TR onmouseover="Resaltar_On(this);" onmouseout="Resaltar_Off(this);" __designer:dtid="3659174697238594"><TD style="HEIGHT: 8px" __designer:dtid="3659174697238595"></TD><TD style="HEIGHT: 8px" colSpan=2 __designer:dtid="3659174697238596"><asp:TextBox id="RFoCT" runat="server" Text='<%# RvoCT(Eval("REV_TREV")) %>' __designer:dtid="3659174697238597" __designer:wfdid="w195" Width="100%" Enabled="False"></asp:TextBox></TD><TD style="WIDTH: 25px; HEIGHT: 8px" __designer:dtid="3659174697238598"></TD><TD style="WIDTH: 25px; HEIGHT: 8px" __designer:dtid="3659174697238599"><asp:Label id="Label4" runat="server" Text="TP" __designer:dtid="3659174697238600" CssClass="TitDecl" __designer:wfdid="w196" Width="17px"></asp:Label></TD><TD style="WIDTH: 345px; HEIGHT: 8px" colSpan=12 __designer:dtid="3659174697238601"><asp:TextBox id="TXTTRAPRO_RF" runat="server" Text='<%# Eval("REV_TAR_PRO") %>' __designer:dtid="3659174697238602" __designer:wfdid="w197" Width="90%" Enabled="False"></asp:TextBox></TD></TR></TBODY></TABLE>
</ItemTemplate>
<EmptyDataTemplate>
<asp:Label id="Label6" runat="server" Text="No tiene Siganatarios Asignados" CssClass="nodata" __designer:wfdid="w160"></asp:Label>
</EmptyDataTemplate>
</asp:FormView>&nbsp;</TD></TR><TR><TD style="HEIGHT: 19px; TEXT-ALIGN: left" colspan="5">
                        <asp:GridView ID="GridView2" runat="server" __designer:wfdid="w9" 
                            autogeneratecolumns="False" ShowFooter="True">
                            <Columns>
                                <asp:TemplateField HeaderText="Código">
                                    <FooterTemplate>
                                        <asp:Label ID="LbTCod" runat="server" Text=""></asp:Label>
                                    </FooterTemplate>
                                    <ItemTemplate>
                                        <asp:Label ID="LbCOD" runat="server" __designer:wfdid="w1" 
                                            Text='<%# Bind("CoCd_Codi") %>'></asp:Label>
                                    </ItemTemplate>
                                    <ItemStyle HorizontalAlign="Left" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Impuesto">
                                    <FooterTemplate>
                                        <asp:Label ID="LbTName" runat="server" Text="Total"></asp:Label>
                                    </FooterTemplate>
                                    <ItemTemplate>
                                        <asp:Label ID="TxtName" runat="server" __designer:wfdid="w2" 
                                            Text='<%# Eval("CoCd_Nomb") %>'></asp:Label>
                                    </ItemTemplate>
                                    <ItemStyle HorizontalAlign="Left" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Base Gravable">
                                    <FooterTemplate>
                                        <asp:Label ID="LbTBASEGRAVABLE" runat="server" Text=""></asp:Label>
                                    </FooterTemplate>
                                    <ItemTemplate>
                                        <asp:Label ID="LbBASEGRAVABLE" runat="server" 
                                            Text='<%# Eval("BASEGRAVABLE","{0:C0}") %>'></asp:Label>
                                    </ItemTemplate>
                                    <ItemStyle HorizontalAlign="Right" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Tarifa">
                                    <FooterTemplate>
                                        <asp:Label ID="LbTarifa" runat="server" Text=""></asp:Label>
                                    </FooterTemplate>
                                    <ItemTemplate>
                                        <asp:Label ID="LbTarifa" runat="server" Text='<%# Eval("Tarifa") %>'></asp:Label>
                                    </ItemTemplate>
                                    <ItemStyle HorizontalAlign="Right" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Valor Impuesto">
                                    <FooterTemplate>
                                        <asp:Label ID="LbTIMPUESTO" runat="server" Text="xxxx"></asp:Label>
                                    </FooterTemplate>
                                    <ItemTemplate>
                                        <asp:Label ID="LbIMPUESTO" runat="server" __designer:wfdid="w6" 
                                            Text='<%# Bind("VALORIMPUESTO","{0:C0}") %>'></asp:Label>
                                    </ItemTemplate>
                                    <ItemStyle HorizontalAlign="Right" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="valor" SortExpression="VALORIMPUESTO" 
                                    Visible="False">
                                    <EditItemTemplate>
                                        <asp:TextBox ID="TextBox1" runat="server" 
                                            Text='<%# Bind("VALORIMPUESTO","{0:C0}") %>'></asp:TextBox>
                                    </EditItemTemplate>
                                    <ItemTemplate>
                                        <asp:Label ID="Label1" runat="server" 
                                            Text='<%# Bind("VALORIMPUESTO", "{0:C0}") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                            </Columns>
                        </asp:GridView>
                        </TD></TR><TR><TD style="HEIGHT: 19px; TEXT-ALIGN: center">&nbsp;</TD>
                        <td style="HEIGHT: 19px; TEXT-ALIGN: center">
                            &nbsp;</td>
                        <td style="HEIGHT: 19px; TEXT-ALIGN: center">
                            &nbsp;</td>
                        <td style="HEIGHT: 19px; TEXT-ALIGN: center">
                            &nbsp;</td>
                        <td style="HEIGHT: 19px; TEXT-ALIGN: center">
                            &nbsp;</td>
                    </TR>
                    <tr>
                        <td style="HEIGHT: 19px; TEXT-ALIGN: center">
                            &nbsp;</td>
                        <td style="HEIGHT: 19px; TEXT-ALIGN: center">
                            &nbsp;</td>
                        <td style="HEIGHT: 19px; TEXT-ALIGN: center">
                            &nbsp;</td>
                        <td style="HEIGHT: 19px; TEXT-ALIGN: center">
                            &nbsp;</td>
                        <td style="HEIGHT: 19px; TEXT-ALIGN: center">
                            &nbsp;</td>
                    </tr>
                    <TR><TD style="HEIGHT: 19px; TEXT-ALIGN: center" colspan="5">
                        <asp:Button ID="BtnDil" runat="server" __designer:dtid="3659174697238605" 
                            __designer:wfdid="w47" Text="Diligenciar Formulario" ValidationGroup="Dil" 
                            Visible="False" />
                        </TD></TR>
                    <tr>
                        <td colspan="5" style="HEIGHT: 19px; TEXT-ALIGN: left">
                            <asp:HiddenField ID="HdTAG" runat="server" __designer:wfdid="w8" />
                        </td>
                    </tr>
                    </TBODY></TABLE><asp:ObjectDataSource id="ObjCalVigencias" runat="server" __designer:dtid="844424930132090" TypeName="Calendario" SelectMethod="GetVigencias" OldValuesParameterFormatString="original_{0}" __designer:wfdid="w27"><SelectParameters __designer:dtid="844424930132091">
<asp:ControlParameter ControlID="CbCdec" PropertyName="SelectedValue" Name="Cla_Dec" Type="String" __designer:dtid="844424930132092"></asp:ControlParameter>
</SelectParameters>
</asp:ObjectDataSource> <asp:ObjectDataSource id="ObjCal" runat="server" __designer:dtid="844424930132093" TypeName="Calendario" SelectMethod="GetPorClaseDec" __designer:wfdid="w28"><SelectParameters __designer:dtid="844424930132094">
<asp:ControlParameter ControlID="CbCdec" PropertyName="SelectedValue" Name="Cla_Dec" Type="String" __designer:dtid="844424930132095"></asp:ControlParameter>
<asp:ControlParameter ControlID="CboVigencia" PropertyName="SelectedValue" Name="Vigencia" __designer:dtid="844424930132096"></asp:ControlParameter>
</SelectParameters>
</asp:ObjectDataSource> <asp:HiddenField id="HdAR" runat="server" __designer:wfdid="w14"></asp:HiddenField> <asp:ObjectDataSource id="ObjTDec" runat="server" __designer:dtid="5629499534213129" TypeName="Tipo_Dec" SelectMethod="GetPorClaseDec" __designer:wfdid="w40"><SelectParameters __designer:dtid="5629499534213130">
<asp:ControlParameter ControlID="CbCdec" PropertyName="SelectedValue" DefaultValue="" Name="Cla_Dec" Type="String" __designer:dtid="5629499534213131"></asp:ControlParameter>
</SelectParameters>
</asp:ObjectDataSource> 
</ContentTemplate>
            <Triggers>
<asp:AsyncPostBackTrigger ControlID="CboVigencia" EventName="SelectedIndexChanged"></asp:AsyncPostBackTrigger>
<asp:AsyncPostBackTrigger ControlID="Button" EventName="Click"></asp:AsyncPostBackTrigger>
                <asp:PostBackTrigger ControlID="Periodo" />
</Triggers>
        </asp:UpdatePanel>&nbsp;
    </div>
    &nbsp;
    <asp:ObjectDataSource ID="ObjSign" runat="server" OldValuesParameterFormatString="original_{0}"
        SelectMethod="GetRecords" TypeName="Signatario">
        <SelectParameters>
            <asp:ControlParameter ControlID="Nit" Name="Nit" PropertyName="Text" Type="String" />
        </SelectParameters>
    </asp:ObjectDataSource>
    <asp:HiddenField ID="Cla_Dec" runat="server" Value="01" />
    <asp:ObjectDataSource ID="ObjCDec" runat="server" OldValuesParameterFormatString="original_{0}"
        SelectMethod="GetCDEC_PorNit" TypeName="CDeclaraciones">
        <SelectParameters>
            <asp:ControlParameter ControlID="Nit" Name="Nit" PropertyName="Text" Type="String" />
        </SelectParameters>
    </asp:ObjectDataSource>
    <asp:UpdatePanel id="UpdatePanel2" runat="server" UpdateMode="Conditional">
        <contenttemplate>
<!-- Mensaje de Salida--><asp:Button style="DISPLAY: none" id="hiddenTargetControlForModalPopup" runat="server"></asp:Button> <ajaxToolkit:ModalPopupExtender id="ModalPopup" runat="server" BackgroundCssClass="modalBackground" BehaviorID="programmaticModalPopupBehavior" DropShadow="True" PopupControlID="programmaticPopup" PopupDragHandleControlID="programmaticPopupDragHandle" RepositionMode="RepositionOnWindowScroll" TargetControlID="hiddenTargetControlForModalPopup">
            </ajaxToolkit:ModalPopupExtender> <asp:Panel id="programmaticPopup" runat="server" Width="625px" Height="229%" CssClass="ModalPanel2"><asp:Panel id="programmaticPopupDragHandle" runat="Server" Width="615px" Height="30px" CssClass="BarTitleModal2"><DIV style="PADDING-RIGHT: 5px; PADDING-LEFT: 5px; PADDING-BOTTOM: 5px; VERTICAL-ALIGN: middle; PADDING-TOP: 5px"><DIV style="FLOAT: left">Buscar Agente Recaudador </DIV> <DIV style="FLOAT: right" __designer:dtid="1407383473487880"><INPUT id="hideModalPopupViaClientButton" type=button value="X" __designer:dtid="1407383473487881" /></DIV></DIV></asp:Panel> &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;<BR />&nbsp; &nbsp; &nbsp;&nbsp; <uc1:consultater id="ConsultaTer1" runat="server" ret="AR" tipo="AR"></uc1:consultater> <BR /><BR /><BR /></asp:Panel> 
</contenttemplate>
        <triggers>
<asp:AsyncPostBackTrigger ControlID="BtnBuscDP" EventName="Click"></asp:AsyncPostBackTrigger>

</triggers>
    </asp:UpdatePanel><br />
    <asp:UpdateProgress id="UpdateProgress1" runat="server" AssociatedUpdatePanelID="UpdatePanel1">
        <progresstemplate>
<DIV class="Loading"><IMG title="" alt="" src="../../images/loading.gif" /> Cargando … </DIV>
</progresstemplate>
    </asp:UpdateProgress>
    <br />
</div>
</asp:Content>

