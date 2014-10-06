<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" validateRequest="false" CodeFile="Validador.aspx.vb" Inherits="MediosM_Declaraciones_Validador" title="Untitled Page" %>

<%@ Register Assembly="ControlesWeb" Namespace="ControlesWeb" TagPrefix="cc1" %>
<%@ Register Src="../../CtrlUsr/Terceros/ConsultaTer.ascx" TagName="ConsultaTer" TagPrefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="SampleContent" Runat="Server">

    <script type='text/javascript'>
    function cancelClick() {
        var label = $get('ctl00_SampleContent_LbRpt');
        //label.innerHTML = 'You hit cancel in the Confirm dialog on ' + (new Date()).localeFormat("T") + '.';
    }
        // Add click handlers for buttons to show and hide modal popup on pageLoad
        function pageLoad() {
            $addHandler($get("BtnCerrar"), 'click', hideModalPopupViaClient);        
            //$addHandler($get("showModalPopupClientButton"), 'click', showModalPopupViaClient);
            //$addHandler($get("hideModalPopupViaClientButton"), 'click', hideModalPopupViaClient);        
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
            
            
        }
        
        function UpdateCombo()
        {
             var no =document.getElementById("<%= CbCdec.ClientID %>").options.length;
            if (no==1)  __doPostBack("<%= CbCdec.ClientID %>","");
            
            
        }

    </script>
<div class="demoarea">
    <ajaxToolkit:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server" EnablePageMethods="true" EnableScriptGlobalization="True" EnableScriptLocalization="True">
    </ajaxToolkit:ToolkitScriptManager>
    &nbsp;<asp:Label ID="LBTITULO" runat="server" CssClass="Titulo" Text="CARGUE Y VALIDACION DE MEDIOS MAGNETICOS"></asp:Label> 
     <asp:UpdatePanel id="UpdatePanel1" runat="server">
        <contenttemplate>
&nbsp;<asp:Label id="MsgResult" runat="server" __designer:wfdid="w50"></asp:Label>&nbsp; <BR /><TABLE width=500><TBODY><TR class="TbDecl"><TD style="HEIGHT: 13px" class="TDNegroFila"><asp:Label id="Label10" runat="server" Font-Bold="True" Text="AGENTE RECAUDADOR" __designer:wfdid="w51"></asp:Label>&nbsp;&nbsp; <asp:Button style="DISPLAY: none" id="button" onclick="button_Click" runat="server" __designer:wfdid="w52"></asp:Button></TD></TR><TR><TD><TABLE width="100%"><TBODY><TR onmouseover="Resaltar_On(this);" onmouseout="Resaltar_Off(this);"><TD style="WIDTH: 25px; HEIGHT: 15px"><asp:Label id="Label45" runat="server" Width="115px" Font-Bold="True" Text="IDENTIFICACIÓN" CssClass="TitDecl" __designer:wfdid="w53"></asp:Label></TD><TD style="WIDTH: 28px; HEIGHT: 15px">&nbsp;<asp:Label id="Label2" runat="server" Font-Bold="True" Text="DV" CssClass="TitDecl" __designer:wfdid="w54"></asp:Label> </TD><TD style="WIDTH: 28px; HEIGHT: 15px"></TD><TD style="WIDTH: 131px; HEIGHT: 15px"><asp:Label id="Label11" runat="server" Font-Bold="True" Text="RAZON SOCIAL" CssClass="TitDecl" __designer:wfdid="w55"></asp:Label></TD><TD style="WIDTH: 253px; HEIGHT: 15px"></TD></TR><TR onmouseover="Resaltar_On(this);" onmouseout="Resaltar_Off(this);"><TD style="HEIGHT: 19px; TEXT-ALIGN: right"><asp:TextBox id="Nit" runat="server" __designer:wfdid="w56" Enabled="False"></asp:TextBox> </TD><TD style="WIDTH: 28px; HEIGHT: 19px"><asp:TextBox id="Dv" runat="server" Width="17px" __designer:wfdid="w57" Enabled="False"></asp:TextBox></TD><TD style="WIDTH: 28px; HEIGHT: 19px"><asp:Button accessKey="B" id="BtnBuscDP" onclick="BtnBuscDP_Click" runat="server" Text="..." __designer:wfdid="w58" UseSubmitBehavior="False" ToolTip="Buscar Agente Recaudador"></asp:Button></TD><TD style="HEIGHT: 19px" colSpan=2><asp:TextBox id="Agente" runat="server" Width="332px" __designer:wfdid="w59" Enabled="False"></asp:TextBox></TD></TR><TR onmouseover="Resaltar_On(this);" onmouseout="Resaltar_Off(this);"><TD style="HEIGHT: 19px" colSpan=5>&nbsp;</TD></TR><TR onmouseover="Resaltar_On(this);" onmouseout="Resaltar_On(this);"><TD style="HEIGHT: 19px" colSpan=5><asp:Label id="Label110" runat="server" Width="261px" Font-Bold="True" Text="SELECCIONE LA CLASE DE DECLARACION" CssClass="TitDecl" __designer:wfdid="w60"></asp:Label> <asp:DropDownList id="CbCdec" runat="server" DataValueField="CLD_COD" DataTextField="CLD_NOM" DataSourceID="ObjCDec" __designer:wfdid="w61" AutoPostBack="True"></asp:DropDownList></TD></TR><TR onmouseover="Resaltar_On(this);" onmouseout="Resaltar_Off(this);"><TD style="HEIGHT: 19px" colSpan=5></TD></TR></TBODY></TABLE></TD></TR></TBODY></TABLE><TABLE width=500><TBODY><TR onmouseover="Resaltar_On(this);" class="TbDecl" onmouseout="Resaltar_Off(this);"><TD colSpan=6><asp:Label id="LbI" runat="server" Font-Bold="True" Text="PERIODO DE DECLARACION Y TIPO DE DECLARACIÓN" __designer:wfdid="w62"></asp:Label>&nbsp;</TD></TR><TR onmouseover="Resaltar_On(this);" onmouseout="Resaltar_Off(this);"><TD style="WIDTH: 7px"></TD><TD style="WIDTH: 100px"><asp:Label id="Label14" runat="server" Text="AÑO GRAVABLE" CssClass="TitDecl" __designer:wfdid="w63"></asp:Label></TD><TD style="WIDTH: 100px"><asp:DropDownList id="CboVigencia" runat="server" DataValueField="cal_vig" DataTextField="cal_vig" DataSourceID="ObjCalVigencias" __designer:wfdid="w64" AutoPostBack="True">
                    </asp:DropDownList></TD><TD style="WIDTH: 8px"></TD><TD style="WIDTH: 100px"><asp:Label id="Label13" runat="server" Width="133px" Text="PERIODO GRAVABLE" CssClass="TitDecl" __designer:wfdid="w65"></asp:Label></TD><TD style="WIDTH: 100px"><asp:DropDownList id="Periodo" runat="server" DataValueField="cal_per" DataTextField="cal_des" DataSourceID="ObjCal" __designer:wfdid="w66">
                    </asp:DropDownList></TD></TR></TBODY></TABLE><TABLE style="WIDTH: 720px" __designer:dtid="562949953421319"><TBODY><TR class="TbDecl" __designer:dtid="562949953421320">
                <TD style="HEIGHT: 23px" colSpan=8 __designer:dtid="562949953421321"><asp:Label id="LbIc" runat="server" Font-Bold="True" __designer:dtid="562949953421322" Text="CARGAR Y VALIDAR ARCHIVO" CssClass="Decl" __designer:wfdid="w67"></asp:Label>&nbsp;</TD>
                <td __designer:dtid="562949953421321" style="HEIGHT: 23px">
                    &nbsp;</td>
                <td __designer:dtid="562949953421321" style="HEIGHT: 23px">
                    &nbsp;</td>
                </TR><TR __designer:dtid="562949953421323"><TD style="HEIGHT: 23px" 
                        __designer:dtid="562949953421324" colspan="3">&nbsp;</TD>
                    <td __designer:dtid="562949953421326" style="WIDTH: 127px; HEIGHT: 23px">
                        &nbsp;</td>
                <TD style="WIDTH: 131px; HEIGHT: 23px" __designer:dtid="562949953421326">&nbsp;</TD>
                <TD style="WIDTH: 100px; HEIGHT: 23px" __designer:dtid="562949953421328" 
                        valign="middle">
                    &nbsp;</TD>
                <td __designer:dtid="562949953421330" style="WIDTH: 23px; HEIGHT: 23px">
                    &nbsp;</td>
                    <td __designer:dtid="562949953421330" style="WIDTH: 136px; HEIGHT: 23px">
                        &nbsp;</td>
                    <td __designer:dtid="562949953421330" style="WIDTH: 126px; HEIGHT: 23px">
                        &nbsp;</td>
                    <td __designer:dtid="562949953421330" style="WIDTH: 126px; HEIGHT: 23px">
                        &nbsp;</td>
                </TR><TR __designer:dtid="562949953421331">
                    <TD __designer:dtid="562949953421332" 
                        colspan="3" valign="bottom">
                        <asp:Label ID="Label16" runat="server" __designer:dtid="562949953421325" 
                            __designer:wfdid="w68" CssClass="TitDecl" Text="Formato de Importación" 
                            Width="139px"></asp:Label>
                    </TD>
                    <td __designer:dtid="562949953421334" style="WIDTH: 127px" valign="bottom">
                        <asp:Label ID="Label3" runat="server" __designer:dtid="562949953421327" 
                            __designer:wfdid="w69" CssClass="TitDecl" Text="Fecha de Cargue" 
                            Width="116px"></asp:Label>
                    </td>
                <TD style="WIDTH: 131px" __designer:dtid="562949953421334">
                    &nbsp;</TD>
                    <TD style="WIDTH: 100px" __designer:dtid="562949953421337" valign="bottom">
                        <asp:Label ID="Label4" runat="server" __designer:dtid="562949953421329" 
                            __designer:wfdid="w70" CssClass="TitDecl" Text="Seleccione el Archivo" 
                            Width="129px"></asp:Label>
                    </TD>
                    <td __designer:dtid="562949953421340" style="WIDTH: 23px">
                        &nbsp;</td>
                    <td __designer:dtid="562949953421340" style="WIDTH: 136px; text-align: center;">
                        <asp:ImageButton ID="BtnIValidar" runat="server" Height="32px" 
                            ImageUrl="~/images/imagev2/blog-post-accept-icon.png" 
                            ToolTip="Click, para validar y cargar el archivo" ValidationGroup="Validar" 
                            Width="32px" />
                    </td>
                    <td __designer:dtid="562949953421340" style="WIDTH: 126px; text-align: center;">
                        <asp:ImageButton ID="BtnIExcel" runat="server" Height="32px" 
                            ImageUrl="~/images/imagev2/excel2007.gif" ToolTip="Click, para exportar Logs " 
                            Width="32px" />
                    </td>
                    <td __designer:dtid="562949953421340" style="WIDTH: 126px; text-align: center;">
                        <asp:ImageButton ID="BtnIDil" runat="server" 
                            ImageUrl="~/images/imagev2/blog-post-edit-icon.png" 
                            ToolTip="Click, para diligenciar Formulario de Declaración" />
                    </td>
                </TR><TR __designer:dtid="562949953421342">
                    <TD 
                        __designer:dtid="562949953421343" colspan="3">
                        <asp:DropDownList ID="CboFormatos" runat="server" 
                            __designer:dtid="562949953421333" __designer:wfdid="w71" 
                            DataSourceID="ObjFmtos" DataTextField="Fmto_Desc" DataValueField="Fmto_Codi">
                        </asp:DropDownList>
                    </TD>
                    <td __designer:dtid="562949953421345" style="WIDTH: 127px">
                        <asp:TextBox ID="TxtFecha" runat="server" __designer:dtid="562949953421335" 
                            __designer:wfdid="w72" Width="97px"></asp:TextBox>
                    </td>
                    <TD style="WIDTH: 131px" __designer:dtid="562949953421345">
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
                            __designer:dtid="562949953421336" __designer:wfdid="w73" 
                            ControlToValidate="TxtFecha" ErrorMessage="Debe digitar fecha de cargue" ValidationGroup="Validar" 
                            Width="16px">*</asp:RequiredFieldValidator>
                    </TD>
                    <TD style="WIDTH: 100px" __designer:dtid="562949953421346">
                        <asp:FileUpload ID="FileUpload1" runat="server" 
                            __designer:dtid="562949953421338" __designer:wfdid="w74" />
                    </TD>
                    <td __designer:dtid="562949953421347" style="WIDTH: 23px">
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" 
                            __designer:dtid="562949953421339" __designer:wfdid="w75" 
                            ControlToValidate="FileUpload1" 
                            ErrorMessage="Seleccione un archivo para cargar y válidar" 
                            ValidationGroup="Validar">*</asp:RequiredFieldValidator>
                    </td>
                    <td __designer:dtid="562949953421347" style="WIDTH: 136px; text-align: center;">
                        &nbsp;Validar
                        </td>
                    <td __designer:dtid="562949953421347" style="WIDTH: 126px; text-align: center;">
                        Exportar Logs</td>
                    <td __designer:dtid="562949953421347" style="WIDTH: 126px; text-align: center;">
                        Diligenciar
                    </td>
                </TR>
                <tr __designer:dtid="562949953421342">
                    <td __designer:dtid="562949953421343" style="WIDTH: 26px">
                        <asp:Label ID="lbTituloLog" runat="server" __designer:dtid="562949953421344" 
                            __designer:wfdid="w77"></asp:Label>
                    </td>
                    <td __designer:dtid="562949953421343" style="WIDTH: 96px">
                        &nbsp;</td>
                    <td __designer:dtid="562949953421343" style="WIDTH: 96px">
                        &nbsp;</td>
                    <td __designer:dtid="562949953421345" colspan="3">
                        <asp:ValidationSummary ID="ValidationSummary1" runat="server" 
                            ValidationGroup="Validar" />
                    </td>
                    <td __designer:dtid="562949953421347" style="WIDTH: 23px">
                        &nbsp;</td>
                    <td __designer:dtid="562949953421347" style="WIDTH: 136px; text-align: center;">
                        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;</td>
                    <td __designer:dtid="562949953421347" style="WIDTH: 126px; text-align: center;">
                        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;</td>
                    <td __designer:dtid="562949953421347" style="WIDTH: 126px; text-align: center;">
                        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;</td>
                </tr>
                <tr __designer:dtid="562949953421342">
                    <td __designer:dtid="562949953421343" style="WIDTH: 26px">
                        </td>
                    <td __designer:dtid="562949953421343" style="WIDTH: 96px">
                        </td>
                    <td __designer:dtid="562949953421343" align="right" rowspan="2" 
                        style="WIDTH: 96px" valign="top">
                        <asp:Image ID="Image1" runat="server" Visible="False" />
                    </td>
                    <td __designer:dtid="562949953421345" colspan="6">
                    <div id="div" style="overflow-y:auto;overflow-x:auto;"  runat="server"> 
                        <asp:Label ID="Label1" runat="server" __designer:dtid="562949953421350"
                            __designer:wfdid="w78"></asp:Label>
                     </div>
                    </td>
                    <td __designer:dtid="562949953421347" style="WIDTH: 126px">
                        </td>
                </tr>
                <tr __designer:dtid="562949953421342">
                    <td __designer:dtid="562949953421343" style="WIDTH: 26px">
                        &nbsp;</td>
                    <td __designer:dtid="562949953421343" style="WIDTH: 96px">
                        &nbsp;</td>
                    <td __designer:dtid="562949953421345" style="WIDTH: 127px">
                        &nbsp;</td>
                    <td __designer:dtid="562949953421345" style="WIDTH: 131px">
                        &nbsp;</td>
                    <td __designer:dtid="562949953421346" style="WIDTH: 100px">
                        &nbsp;</td>
                    <td __designer:dtid="562949953421347" style="WIDTH: 23px">
                        &nbsp;</td>
                    <td __designer:dtid="562949953421347" style="WIDTH: 136px">
                        <asp:Button ID="BrnValidar" runat="server" __designer:dtid="562949953421341" 
                            __designer:wfdid="w76" Text="Validar" ValidationGroup="Validar" Visible="False" 
                            Width="85px" />
                    </td>
                    <td __designer:dtid="562949953421347" style="WIDTH: 126px">
                        <asp:Button ID="BtnExcel" runat="server" __designer:dtid="562949953421353" 
                            __designer:wfdid="w79" onclick="BtnExcel_Click" Text="Exportar Logs" 
                            Visible="False" />
                    </td>
                    <td __designer:dtid="562949953421347" style="WIDTH: 126px">
                        <asp:Button ID="BtnDil" runat="server" Text="Diligenciar" Visible="False" />
                    </td>
                </tr>
                <tr __designer:dtid="562949953421342">
                    <td __designer:dtid="562949953421343" style="WIDTH: 26px">
                        &nbsp;</td>
                    <td __designer:dtid="562949953421343" style="WIDTH: 96px">
                        &nbsp;</td>
                    <td __designer:dtid="562949953421343" style="WIDTH: 96px">
                        &nbsp;</td>
                    <td __designer:dtid="562949953421345" style="WIDTH: 127px">
                        &nbsp;</td>
                    <td __designer:dtid="562949953421345" style="WIDTH: 131px">
                        &nbsp;</td>
                    <td __designer:dtid="562949953421346" style="WIDTH: 100px">
                        &nbsp;</td>
                    <td __designer:dtid="562949953421347" style="WIDTH: 23px">
                        &nbsp;</td>
                    <td __designer:dtid="562949953421347" style="WIDTH: 136px">
                        &nbsp;</td>
                    <td __designer:dtid="562949953421347" style="WIDTH: 126px">
                        &nbsp;</td>
                    <td __designer:dtid="562949953421347" style="WIDTH: 126px">
                        &nbsp;</td>
                </tr>
                <tr __designer:dtid="562949953421342">
                    <td __designer:dtid="562949953421343" rowspan="2" 
                        style="WIDTH: 26px; text-align: right;" valign="top">
                        &nbsp;</td>
                    <td __designer:dtid="562949953421343" colspan="9" style="text-align: center;">
                        <asp:GridView ID="GridView1" runat="server" __designer:wfdid="w23" 
                            autogeneratecolumns="False" Caption="LIQUIDACIÓN AUTOMÁTICA" 
                            DataSourceID="ObjLiq" ShowFooter="True">
                            <Columns>
                                <asp:TemplateField HeaderText="Código">
                                    <FooterTemplate>
                                        <asp:Label ID="LbTCod" runat="server" Text=""></asp:Label>
                                    </FooterTemplate>
                                    <ItemTemplate>
                                        <asp:Label ID="LbCOD" runat="server" __designer:wfdid="w5" 
                                            Text='<%# Bind("CoCd_Codi") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Impuesto">
                                    <FooterTemplate>
                                        <asp:Label ID="LbTName" runat="server" Text="Total"></asp:Label>
                                    </FooterTemplate>
                                    <ItemTemplate>
                                        <asp:Label ID="TxtName" runat="server" Text='<%# Eval("CoCd_Nomb") %>'></asp:Label>
                                    </ItemTemplate>
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
                                        <asp:Label ID="LbTarifa0" runat="server" Text='<%# Eval("Tarifa") %>'></asp:Label>
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
                                <asp:TemplateField HeaderText="Valor" SortExpression="VALORIMPUESTO" 
                                    Visible="False">
                                    <EditItemTemplate>
                                        <asp:TextBox ID="TextBox1" runat="server" 
                                            Text='<%# Bind("VALORIMPUESTO","{0:C0}") %>'></asp:TextBox>
                                    </EditItemTemplate>
                                    <ItemTemplate>
                                        <asp:Label ID="Label111" runat="server" 
                                            Text='<%# Bind("VALORIMPUESTO", "{0:C0}") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                            </Columns>
                        </asp:GridView>
                    </td>
                </tr>
                <tr __designer:dtid="562949953421342">
                    <td __designer:dtid="562949953421343" align="right" style="WIDTH: 96px" 
                        valign="top">
                        &nbsp;</td>
                    <td __designer:dtid="562949953421343" colspan="8">
                        &nbsp;</td>
                </tr>
                </TBODY></TABLE>
            <br />
            <ajaxToolkit:CalendarExtender id="CalendarExtender1" runat="server" __designer:dtid="562949953421369" TargetControlID="TxtFecha" __designer:wfdid="w80">
                </ajaxToolkit:CalendarExtender> 
            <cc1:GridViewS id="GridViewS1" runat="server" Width="1000px" Height="70px" ForeColor="#333333" __designer:dtid="562949953421360" WidthDesplegable="700px" HeightDesplegable="100%" GridLines="None" CellPadding="4" __designer:wfdid="w83">
        <RowStyle __designer:dtid="562949953421361" BackColor="#F7F6F3" ForeColor="#333333"  />
        <FooterStyle __designer:dtid="562949953421362" BackColor="#5D7B9D" Font-Bold="True" ForeColor="White"  />
        <PagerStyle __designer:dtid="562949953421363" BackColor="#284775" ForeColor="White" HorizontalAlign="Center"  />
        <SelectedRowStyle __designer:dtid="562949953421364" BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333"  />
        <HeaderStyle __designer:dtid="562949953421365" BackColor="#5D7B9D" Font-Bold="True" ForeColor="White"  />
        <EditRowStyle __designer:dtid="562949953421366" BackColor="#999999"  />
        <AlternatingRowStyle __designer:dtid="562949953421367" BackColor="White" ForeColor="#284775"  />
    </cc1:GridViewS>
            <asp:ObjectDataSource ID="ObjLiq" runat="server" 
                OldValuesParameterFormatString="original_{0}" SelectMethod="GetAforoCdec" 
                TypeName="BasesLiq" UpdateMethod="Anular">
                <UpdateParameters>
                    <asp:Parameter Name="nro_rad" Type="String" />
                </UpdateParameters>
                <SelectParameters>
                    <asp:ControlParameter ControlID="CbCdec" Name="Cla_dec" 
                        PropertyName="SelectedValue" Type="String" />
                    <asp:ControlParameter ControlID="HdAR" Name="Tipo_Agente" PropertyName="Value" 
                        Type="String" />
                    <asp:ControlParameter ControlID="HdNrad" Name="nro_rad" PropertyName="Value" 
                        Type="Int64" />
                </SelectParameters>
            </asp:ObjectDataSource>
</contenttemplate>
        <triggers>
<asp:AsyncPostBackTrigger ControlID="CboVigencia" EventName="SelectedIndexChanged"></asp:AsyncPostBackTrigger>
<asp:AsyncPostBackTrigger ControlID="Button" EventName="Click"></asp:AsyncPostBackTrigger>
<asp:PostBackTrigger ControlID="BrnValidar"></asp:PostBackTrigger>
<asp:PostBackTrigger ControlID="BtnExcel"></asp:PostBackTrigger>
            <asp:PostBackTrigger ControlID="BtnIExcel" />
            <asp:PostBackTrigger ControlID="BtnIValidar" />
</triggers>
    </asp:UpdatePanel>
    &nbsp;&nbsp;<div>
      <br />
      &nbsp; &nbsp;<br />
      <br />
    &nbsp;&nbsp;<asp:HiddenField ID="NombreA" runat="server" />
        &nbsp;&nbsp;
                <asp:ObjectDataSource ID="ObjBl" runat="server" SelectMethod="GetRecords" TypeName="BasesLiq" OldValuesParameterFormatString="original_{0}">
                    <SelectParameters>
                        <asp:ControlParameter ControlID="Nit" Name="NIT" PropertyName="Text" Type="String" />
                        <asp:ControlParameter ControlID="CbCdec" Name="CLDEC" PropertyName="SelectedValue"
                            Type="String" />
                        <asp:ControlParameter ControlID="CboVigencia" Name="A&#209;O" PropertyName="SelectedValue"
                            Type="String" />
                        <asp:ControlParameter ControlID="Periodo" Name="PERI" PropertyName="SelectedValue"
                            Type="String" />
                    </SelectParameters>
                </asp:ObjectDataSource>
      &nbsp;&nbsp;<br />
                <asp:ObjectDataSource ID="ObjFmtos" runat="server" SelectMethod="GetFmtos" TypeName="BasesLiq">
                    <SelectParameters>
                        <asp:ControlParameter ControlID="CbCdec" Name="FMTO_CDEC" PropertyName="SelectedValue" />
                    </SelectParameters>
                </asp:ObjectDataSource>
    <br />
    <asp:ObjectDataSource ID="ObjCDec" runat="server" OldValuesParameterFormatString="original_{0}"
        SelectMethod="GetCDEC_PorNit" TypeName="CDeclaraciones">
        <SelectParameters>
            <asp:ControlParameter ControlID="Nit" Name="Nit" PropertyName="Text" Type="String" />
        </SelectParameters>
    </asp:ObjectDataSource>
    <br />
    <asp:ObjectDataSource ID="ObjTDec" runat="server" SelectMethod="GetPorClaseDec" TypeName="Tipo_Dec">
        <SelectParameters>
            <asp:ControlParameter ControlID="Cla_Dec" Name="Cla_Dec" PropertyName="Value" Type="String" />
        </SelectParameters>
    </asp:ObjectDataSource>
    &nbsp;&nbsp;<br />
    <asp:ObjectDataSource ID="ObjCalVigencias" runat="server" OldValuesParameterFormatString="original_{0}"
        SelectMethod="GetVigencias" TypeName="Calendario">
        <SelectParameters>
            <asp:ControlParameter ControlID="CbCdec" Name="Cla_Dec" PropertyName="SelectedValue"
                Type="String" />
        </SelectParameters>
    </asp:ObjectDataSource>
    <asp:ObjectDataSource ID="ObjCal" runat="server" SelectMethod="GetPorClaseDec" TypeName="Calendario">
        <SelectParameters>
            <asp:ControlParameter ControlID="CbCdec" Name="Cla_Dec" PropertyName="SelectedValue"
                Type="String" />
            <asp:ControlParameter ControlID="CboVigencia" Name="Vigencia" PropertyName="SelectedValue" />
        </SelectParameters>
    </asp:ObjectDataSource>
    <br />
    &nbsp;<asp:HiddenField ID="Cla_Dec" runat="server" Value="01" />
    <br />
    <asp:UpdatePanel id="UpdatePanel2" runat="server" UpdateMode="Conditional">
        <contenttemplate>
<!-- Mensaje de Salida--><asp:Button style="DISPLAY: none" id="hiddenTargetControlForModalPopup" runat="server"></asp:Button> <ajaxToolkit:ModalPopupExtender id="ModalPopup" runat="server" TargetControlID="hiddenTargetControlForModalPopup" BackgroundCssClass="modalBackground" BehaviorID="programmaticModalPopupBehavior" DropShadow="True" PopupControlID="programmaticPopup" PopupDragHandleControlID="programmaticPopupDragHandle" RepositionMode="RepositionOnWindowScroll">
            </ajaxToolkit:ModalPopupExtender> <asp:Panel id="programmaticPopup" runat="server" Width="625px" Height="229%" CssClass="ModalPanel2"><asp:Panel id="programmaticPopupDragHandle" runat="Server" Width="621px" Height="30px" CssClass="BarTitleModal2"><DIV style="PADDING-RIGHT: 5px; PADDING-LEFT: 5px; PADDING-BOTTOM: 5px; VERTICAL-ALIGN: middle; PADDING-TOP: 5px"><DIV style="FLOAT: left">Buscar Agente Recaudador </DIV> <DIV style="FLOAT: right"><INPUT id="BtnCerrar"  type=button value="X" /></DIV></DIV></asp:Panel> &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;<BR />&nbsp; &nbsp; &nbsp;&nbsp; <uc1:consultater id="ConsultaTer1" runat="server" ret="AR" tipo="AR"></uc1:consultater> <BR /><BR /><BR /></asp:Panel> 
</contenttemplate>
        <triggers>
<asp:AsyncPostBackTrigger ControlID="BtnBuscDP" EventName="Click"></asp:AsyncPostBackTrigger>
</triggers>
    </asp:UpdatePanel>
    <asp:HiddenField id="HdAR" runat="server"></asp:HiddenField> 
    <asp:HiddenField id="HdNrad" runat="server"></asp:HiddenField> 
    <asp:RadioButtonList id="ROptTD" runat="server" DataSourceID="ObjTDec" DataTextField="TDEC_NOM" DataValueField="TDEC_COD"></asp:RadioButtonList>
    <br />
</div>
</div>
</asp:Content>

