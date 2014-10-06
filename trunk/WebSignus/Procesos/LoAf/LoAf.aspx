<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="LoAf.aspx.vb" Inherits="Procesos_LoAf_LoAf" title="Untitled Page" %>
<%@ Register Src="../../CtrlUsr/Terceros/ConsultaTer.ascx" TagName="ConsultaTer" TagPrefix="uc1" %>
<%@ Register Assembly="eWorld.UI, Version=2.0.6.2393, Culture=neutral, PublicKeyToken=24d65337282035f2"
    Namespace="eWorld.UI" TagPrefix="ew" %>

<asp:Content ID="Content1" ContentPlaceHolderID="SampleContent" Runat="Server">
   <script type='text/javascript' src="../../js/Declaraciones.js"></script>
  <script type='text/javascript'>
  
  // Add click handlers for buttons to show and hide modal popup on pageLoad
        function pageLoad() {
            $addHandler($get("BtnCerrar"), 'click', CerrarModalTercero);        
        }

       function CerrarModalTercero(ev) {
            ev.preventDefault();        
            var modalPopupBehavior2 = $find('programmaticModalPopupBehavior2');
            modalPopupBehavior2.hide();
        }
        
        function CerrarTercero()
        {
           var modalPopupBehavior2 = $find('programmaticModalPopupBehavior2');
            modalPopupBehavior2.hide();
        }

  function enviar(tdoc,ced,dv,rsocial,tip_ter)
        {
            if(tip_ter=='AR'){
                document.aspnetForm.<%=Me.NIT.ClientID%>.value=ced;
                //document.getElementById('x').innerHTML=ced;
                document.aspnetForm.<%=Me.DV.ClientID%>.value=dv;
                document.aspnetForm.<%=Me.AGENTE.ClientID%>.value=rsocial;
            }
            var modalPopupBehavior = $find('programmaticModalPopupBehavior2');
            modalPopupBehavior.hide();
            __doPostBack("<%= button.ClientID %>","");
            __doPostBack("<%= CbCdec.ClientID %>","");
            
        }

    function cancelClick() {
        var label = $get('ctl00_SampleContent_LbRpt');
        label.innerHTML = 'You hit cancel in the Confirm dialog on ' + (new Date()).localeFormat("T") + '.';
    }
        // Add click handlers for buttons to show and hide modal popup on pageLoad
        function pageLoad() {
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
        
         
       function UpdateCombo()
        {
             var no =document.getElementById("<%= CbCdec.ClientID %>").options.length;
            if (no==1)  __doPostBack("<%= CbCdec.ClientID %>","");
            
            
        }
        
        

    </script>

<div class="demoarea">
    <ajaxToolkit:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server" EnablePageMethods="true">
    </ajaxToolkit:ToolkitScriptManager>
    
    <asp:UpdatePanel id="UpdatePanel1" runat="server">
        <contenttemplate>
<BR /><TABLE width="100%"><TBODY><TR><TD style="HEIGHT: 13px" class="TDNegroFila"><asp:Label id="Label10" runat="server" Font-Bold="True" Text="AGENTE RECAUDADOR"></asp:Label>&nbsp; <asp:LinkButton id="BtnBuscDP" onclick="BtnBuscDP_Click" runat="server">Click para seleccionar ...</asp:LinkButton> <asp:Button style="DISPLAY: none" id="button" onclick="button_Click" runat="server"></asp:Button></TD></TR><TR><TD><TABLE width="100%"><TBODY><TR onmouseover="Resaltar_On(this);" onmouseout="Resaltar_Off(this);"><TD style="WIDTH: 25px; HEIGHT: 15px"><asp:Label id="Label45" runat="server" Width="115px" Font-Bold="True" Text="IDENTIFICACIÓN" CssClass="TitDecl"></asp:Label></TD><TD style="WIDTH: 28px; HEIGHT: 15px">&nbsp;<asp:Label id="Label2" runat="server" Font-Bold="True" Text="DV" CssClass="TitDecl"></asp:Label> </TD><TD style="WIDTH: 131px; HEIGHT: 15px"><asp:Label id="Label11" runat="server" Font-Bold="True" Text="RAZON SOCIAL" CssClass="TitDecl"></asp:Label></TD><TD style="WIDTH: 253px; HEIGHT: 15px"></TD></TR><TR onmouseover="Resaltar_On(this);" onmouseout="Resaltar_Off(this);"><TD style="HEIGHT: 19px; TEXT-ALIGN: right"><asp:TextBox id="Nit" runat="server" Enabled="False"></asp:TextBox> </TD><TD style="WIDTH: 28px; HEIGHT: 19px">-<asp:TextBox id="Dv" runat="server" Width="17px" Enabled="False"></asp:TextBox></TD><TD style="HEIGHT: 19px" colSpan=2><asp:TextBox id="Agente" runat="server" Width="332px" Enabled="False"></asp:TextBox></TD></TR><TR onmouseover="Resaltar_On(this);" onmouseout="Resaltar_Off(this);"><TD style="HEIGHT: 19px" colSpan=4>&nbsp;</TD></TR><TR onmouseover="Resaltar_On(this);" onmouseout="Resaltar_On(this);"><TD style="HEIGHT: 19px" colSpan=4><asp:Label id="Label110" runat="server" Width="261px" Font-Bold="True" Text="SELECCIONE LA CLASE DE DECLARACION" CssClass="TitDecl"></asp:Label> <asp:DropDownList id="CbCdec" runat="server" AutoPostBack="True" DataSourceID="ObjCDec" DataTextField="CLD_NOM" DataValueField="CLD_COD"></asp:DropDownList></TD></TR><TR onmouseover="Resaltar_On(this);" onmouseout="Resaltar_Off(this);"><TD style="HEIGHT: 19px" colSpan=4></TD></TR></TBODY></TABLE></TD></TR></TBODY></TABLE><BR /><TABLE width="100%"><TBODY><TR onmouseover="Resaltar_On(this);" class="TbDecl" onmouseout="Resaltar_Off(this);"><TD colSpan=6><asp:Label id="LbI" runat="server" Font-Bold="True" Text="PERIODO DE DECLARACION Y TIPO DE DECLARACIÓN"></asp:Label>&nbsp;</TD></TR><TR onmouseover="Resaltar_On(this);" onmouseout="Resaltar_Off(this);"><TD style="WIDTH: 7px"></TD><TD style="WIDTH: 100px"><asp:Label id="Label14" runat="server" Text="AÑO GRAVABLE" CssClass="TitDecl"></asp:Label></TD><TD style="WIDTH: 100px"><asp:DropDownList id="CboVigencia" runat="server" AutoPostBack="True" DataSourceID="ObjCalVigencias" DataTextField="cal_vig" DataValueField="cal_vig">
                    </asp:DropDownList></TD><TD style="WIDTH: 8px"></TD><TD style="WIDTH: 100px"><asp:Label id="Label13" runat="server" Width="133px" Text="PERIODO GRAVABLE" CssClass="TitDecl"></asp:Label></TD><TD style="WIDTH: 100px"><asp:DropDownList id="Periodo" runat="server" AutoPostBack="True" DataSourceID="ObjCal" DataTextField="cal_des" DataValueField="cal_per" OnSelectedIndexChanged="Periodo_SelectedIndexChanged"></asp:DropDownList></TD></TR><TR onmouseover="Resaltar_On(this);" onmouseout="Resaltar_Off(this);"><TD style="WIDTH: 7px"></TD><TD style="WIDTH: 100px"></TD><TD style="WIDTH: 100px"></TD><TD style="WIDTH: 8px"></TD><TD style="WIDTH: 100px"></TD><TD style="WIDTH: 100px"></TD></TR></TBODY></TABLE>
                    <asp:GridView id="GridView1" runat="server" ShowFooter="True" autogeneratecolumns="false" __designer:wfdid="w52">
    <Columns>
        
              <asp:TemplateField HeaderText="Código"  >
                <FooterTemplate>
                    <asp:Label ID="LbTCod" runat="server" Text=""></asp:Label>
                </FooterTemplate>
                <ItemTemplate >
                    <asp:Label ID="LbCOD" runat="server" Text='<%# Bind("CoCd_Codi") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            
              <asp:TemplateField HeaderText="Impuesto"  >
                <FooterTemplate>
                    <asp:Label ID="LbTName" runat="server" Text="Total"></asp:Label>
                </FooterTemplate>
                <ItemTemplate >
                    <asp:LABEL ID="TxtName" runat="server" Text='<%# Eval("CoCd_Nomb") %>'></asp:LABEL>
                </ItemTemplate>
            </asp:TemplateField>
            
            <asp:TemplateField HeaderText="Base Gravable"  >
                <FooterTemplate>
                <asp:Label ID="LbTBASEGRAVABLE" runat="server" Text=""></asp:Label>
                </FooterTemplate>
                <ItemTemplate >
                    <asp:Label ID="LbBASEGRAVABLE" runat="server" Text='<%# Eval("BASEGRAVABLE") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            
            <asp:TemplateField HeaderText="Tarifa"  >
                <FooterTemplate>
                <asp:Label ID="LbTarifa" runat="server" Text=""></asp:Label>
                </FooterTemplate>
                <ItemTemplate >
                    <asp:Label ID="LbTarifa" runat="server" Text='<%# Eval("Tarifa") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>

            <asp:TemplateField HeaderText="Valor Impuesto" ShowHeader="true">
                <FooterTemplate>
                        <asp:Label ID="LbTIMPUESTO" runat="server" Text="xxxx"></asp:Label>
                </FooterTemplate>
                <ItemTemplate>
                    <asp:Label ID="LbIMPUESTO" runat="server" Text='<%# Bind("VALORIMPUESTO") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            
        </Columns>
    </asp:GridView><BR />DATA-- 
    
    <asp:DataList id="DataList1" runat="server" ForeColor="#333333" DataSourceID="ObjProc" __designer:wfdid="w57" OnItemDataBound="DataList1_ItemDataBound" CellPadding="0">
<FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White"></FooterStyle>

<AlternatingItemStyle BackColor="White" ForeColor="#284775"></AlternatingItemStyle>

<ItemStyle BackColor="#F7F6F3" ForeColor="#333333"></ItemStyle>

<SelectedItemStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333"></SelectedItemStyle>
<HeaderTemplate>
<TABLE><TBODY><TR>
<TD style="WIDTH: 20px">Código</TD><TD style="WIDTH: 300px">Impuesto</TD><TD style="WIDTH: 100px">Base Gravable</TD><TD style="WIDTH: 50px">Tarifa</TD><TD style="WIDTH: 100px">Valor Impuesto</TD></TR></TBODY></TABLE>
</HeaderTemplate>

<HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White"></HeaderStyle>
<FooterTemplate>
<TABLE><TBODY><TR><TD style="WIDTH: 20px">Total</TD><TD style="WIDTH: 300px"></TD><TD style="WIDTH: 100px"></TD><TD style="WIDTH: 50px"></TD><TD style="WIDTH: 100px"><asp:Label id="Label5" runat="server" Text="Label" __designer:wfdid="w68"></asp:Label></TD></TR></TBODY></TABLE>
</FooterTemplate>
<ItemTemplate>
<TABLE><TBODY><TR><TD style="WIDTH: 20px"><asp:Label id="Label1" runat="server" Text='<%# Bind("CoCd_Codi") %>' __designer:wfdid="w69"></asp:Label></TD><TD style="WIDTH: 300px"><asp:Label id="Label3" runat="server" Text='<%# Bind("CoCd_Nomb") %>' __designer:wfdid="w70"></asp:Label></TD><TD style="WIDTH: 100px"><asp:TextBox id="TxtValBas" runat="server" Text='<%# Bind("BASEGRAVABLE") %>' __designer:wfdid="w71"></asp:TextBox></TD><TD style="WIDTH: 50px"><asp:Label id="LbTari" runat="server" Text='<%# Bind("Tarifa") %>' __designer:wfdid="w66"></asp:Label></TD><TD style="WIDTH: 100px"><asp:TextBox id="TxtR" runat="server" Text='<%# Bind("ValorImpuesto") %>' __designer:wfdid="w73"></asp:TextBox></TD></TR></TBODY></TABLE> <asp:HiddenField id="HdCtar" runat="server" __designer:wfdid="w74" Value='<%# Bind("CoCd_Ctar") %>'></asp:HiddenField>
</ItemTemplate>
</asp:DataList> <BR />--

<asp:Repeater ID="Repeater1" runat="server" DataSourceID="ObjProc">
                    <HeaderTemplate>
                            <table class="datatable" cellpadding="0" cellspacing="0">
                                <tr>
                                    <td colspan="7"><b>III. LIQUIDACIÓN DE RETENCIÓN</b></td>
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
                                </td>
                </td>
                            <td style="width: 20px;  text-align: right">
                                <asp:Label ID="LbABIM" runat="server" CssClass="AB" BorderColor="#E0E0E0" Text='<%#DataBinder.Eval(Container.DataItem, "COCD_ABVB")%>'></asp:Label>
                            </td>
                            <td style="width: 150px;  text-align: right" >
                                <ew:numericbox id="Numericbox1" runat="server" autoformatcurrency="True" cssclass="TxtNum" Text="$0" 
                                    decimalsign="," groupingseparator="." Visible=<%#IIF(DataBinder.Eval(Container.DataItem, "COCD_ISVB")="S",True,False)%>></ew:numericbox>
                            <td style="width: 20px;  text-align: right" >
                                <asp:Label ID="LbTar" runat="server" CssClass="AB" Text=''></asp:Label></td>
                            <td style="width: 20px;  text-align: right" >
                                <asp:Label ID="LbABVD" runat="server" CssClass="AB" Text='<%#DataBinder.Eval(Container.DataItem, "COCD_ABVD")%>'></asp:Label></td>
                            <td style=" text-align: right;width: 150px;">
                                <ew:numericbox id="Numericbox2" runat="server" autoformatcurrency="True" cssclass="TxtNum" 
                                    decimalsign="," groupingseparator="."   Text="$0"></ew:numericbox>
                            </td>
                        </tr>
                </ItemTemplate>
                <FooterTemplate>
      </table>
                </FooterTemplate>
            </asp:Repeater>

---
</contenttemplate>
    </asp:UpdatePanel>
    <asp:HiddenField ID="HdTAG" runat="server" />
    <br />
    &nbsp;<asp:HiddenField ID="HdFODE" runat="server" />
    <asp:UpdatePanel id="UpdatePanel2" runat="server" UpdateMode="Conditional">
        <contenttemplate>
<!-- Mensaje de Salida--><asp:Button style="DISPLAY: none" id="hiddenTargetControlForModalPopup2" runat="server"></asp:Button> <ajaxToolkit:ModalPopupExtender id="ModalPopupTer" runat="server" BackgroundCssClass="modalBackground" BehaviorID="programmaticModalPopupBehavior2" DropShadow="True" PopupControlID="programmaticPopup2" PopupDragHandleControlID="programmaticPopupDragHandle2" RepositionMode="RepositionOnWindowScroll" TargetControlID="hiddenTargetControlForModalPopup2">
             </ajaxToolkit:ModalPopupExtender> <asp:Panel id="programmaticPopup2" runat="server" Width="625px" Height="229%" CssClass="ModalPanel2"><asp:Panel id="programmaticPopupDragHandle2" runat="Server" Height="30px" CssClass="BarTitleModal2">
                     <div style="padding-right: 5px; padding-left: 5px; padding-bottom: 5px; vertical-align: middle;
                         padding-top: 5px">
                         <div style="float: left">
                             Buscar Tercero</div>
                         <div style="float: right">
                             <input id="BtnCerrar" type="button" value="X" onclick="javascript:CerrarTercero();" /></div>
                     </div>
                 </asp:Panel> &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;<BR />&nbsp; &nbsp; &nbsp;&nbsp; <uc1:ConsultaTer id="ConsultaTer1" runat="server" ret="AR" Tipo="AR"></uc1:ConsultaTer> <BR /><BR /><BR /></asp:Panel> 
</contenttemplate>
        <triggers>
<asp:AsyncPostBackTrigger ControlID="BtnBuscDP" EventName="Click"></asp:AsyncPostBackTrigger>
</triggers>
    </asp:UpdatePanel><br />
</div>
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
    <asp:ObjectDataSource ID="ObjProc" runat="server" OldValuesParameterFormatString="original_{0}"
        SelectMethod="GetAforo" TypeName="Procesos">
        <SelectParameters>
            <asp:ControlParameter ControlID="CbCdec" Name="ClDec" PropertyName="SelectedValue" Type="String" />
            <asp:ControlParameter ControlID="CboVigencia" Name="Agravable" PropertyName="SelectedValue" Type="String" />
            <asp:ControlParameter ControlID="Periodo" Name="PGravable" PropertyName="SelectedValue" Type="String" />
            <asp:ControlParameter ControlID="HdTAG" Name="Tipo_Agente" PropertyName="Value" />
            
        </SelectParameters>
    </asp:ObjectDataSource>
</asp:Content>

