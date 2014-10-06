<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="Consultas.aspx.vb" Inherits="MediosM_Declaraciones_Consultas" title="Untitled Page" %>
<%@ Register Assembly="ControlesWeb" Namespace="ControlesWeb" TagPrefix="cc1" %>
<%@ Register Src="../../CtrlUsr/Terceros/ConsultaTer.ascx" TagName="ConsultaTer" TagPrefix="uc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="SampleContent" Runat="Server">

    <script type='text/javascript'>
    function cancelClick() {
        var label = $get('ctl00_SampleContent_LbRpt');
        //label.innerHTML = 'You hit cancel in the Confirm dialog on ' + (new Date()).localeFormat("T") + '.';
    }
        // Add click handlers for buttons to show and hide modal popup on pageLoad
        function pageLoad() 
        {
            //$addHandler($get("showModalPopupClientButton"), 'click', showModalPopupViaClient);
            $addHandler($get("hideModalPopupViaClientButton"), 'click', hideModalPopupViaClient);        
            //$addHandler($get("BtnCerrar"), 'click', hideModalPopupViaClient);        
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
    <ajaxToolkit:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server" EnablePageMethods="true">
    </ajaxToolkit:ToolkitScriptManager>
         <asp:Label ID="LBTITULO" runat="server" CssClass="Titulo" 
        Text="CONSULTA DE MEDIOS MAGNETICOS VÁLIDADOS"></asp:Label> 
    <br />
  <asp:UpdatePanel id="UpdatePanel1" runat="server">
        <contenttemplate>
&nbsp;&nbsp; <BR /><TABLE width=500><TBODY><TR><TD style="HEIGHT: 13px" class="TDNegroFila"><asp:Label id="Label10" runat="server" Font-Bold="True" Text="AGENTE RECAUDADOR" __designer:wfdid="w2"></asp:Label>&nbsp;&nbsp; <asp:Button style="DISPLAY: none" id="button" onclick="button_Click" runat="server" __designer:wfdid="w3"></asp:Button></TD></TR><TR><TD><TABLE width="100%"><TBODY><TR onmouseover="Resaltar_On(this);" onmouseout="Resaltar_Off(this);"><TD style="WIDTH: 25px; HEIGHT: 15px"><asp:Label id="Label45" runat="server" Width="115px" Font-Bold="True" Text="IDENTIFICACIÓN" __designer:wfdid="w4" CssClass="TitDecl"></asp:Label></TD><TD style="WIDTH: 28px; HEIGHT: 15px">&nbsp;<asp:Label id="Label2" runat="server" Font-Bold="True" Text="DV" __designer:wfdid="w5" CssClass="TitDecl"></asp:Label> </TD><TD style="WIDTH: 28px; HEIGHT: 15px"></TD><TD style="WIDTH: 131px; HEIGHT: 15px"><asp:Label id="Label11" runat="server" Font-Bold="True" Text="RAZON SOCIAL" __designer:wfdid="w6" CssClass="TitDecl"></asp:Label></TD><TD style="WIDTH: 253px; HEIGHT: 15px"></TD></TR><TR onmouseover="Resaltar_On(this);" onmouseout="Resaltar_Off(this);"><TD style="HEIGHT: 19px; TEXT-ALIGN: right"><asp:TextBox id="Nit" runat="server" __designer:wfdid="w7" Enabled="False"></asp:TextBox> </TD><TD style="WIDTH: 28px; HEIGHT: 19px"><asp:TextBox id="Dv" runat="server" Width="17px" __designer:wfdid="w8" Enabled="False"></asp:TextBox></TD><TD style="WIDTH: 28px; HEIGHT: 19px">
<asp:Button accessKey="B" id="BtnBusc" onclick="BtnBusc_Click" runat="server" Text="..." __designer:wfdid="w9" UseSubmitBehavior="False" ToolTip="Buscar Agente Recaudador"></asp:Button></TD><TD style="HEIGHT: 19px" colSpan=2><asp:TextBox id="Agente" runat="server" Width="332px" __designer:wfdid="w10" Enabled="False"></asp:TextBox></TD></TR><TR onmouseover="Resaltar_On(this);" onmouseout="Resaltar_Off(this);"><TD style="HEIGHT: 19px" colSpan=5>
                &nbsp;</TD></TR><TR onmouseover="Resaltar_On(this);" onmouseout="Resaltar_On(this);"><TD style="HEIGHT: 19px" colSpan=5><asp:Label id="Label110" runat="server" Width="261px" Font-Bold="True" Text="SELECCIONE LA CLASE DE DECLARACION" __designer:wfdid="w11" CssClass="TitDecl"></asp:Label> <asp:DropDownList id="CbCdec" runat="server" __designer:wfdid="w12" AutoPostBack="True" DataSourceID="ObjCDec" DataTextField="CLD_NOM" DataValueField="CLD_COD"></asp:DropDownList></TD></TR><TR onmouseover="Resaltar_On(this);" onmouseout="Resaltar_Off(this);"><TD style="HEIGHT: 19px" colSpan=5></TD></TR></TBODY></TABLE></TD></TR></TBODY></TABLE><TABLE width="70%"><TBODY><TR onmouseover="Resaltar_On(this);" class="TbDecl" onmouseout="Resaltar_Off(this);"><TD colSpan=6><asp:Label id="LbI" runat="server" Font-Bold="True" Text="PERIODO DE DECLARACION Y TIPO DE DECLARACIÓN" __designer:wfdid="w13"></asp:Label>&nbsp;</TD>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
            </TR><TR onmouseover="Resaltar_On(this);" onmouseout="Resaltar_Off(this);"><TD style="WIDTH: 7px"></TD><TD style="WIDTH: 100px"><asp:Label id="Label14" runat="server" Text="AÑO GRAVABLE" __designer:wfdid="w14" CssClass="TitDecl"></asp:Label></TD><TD style="WIDTH: 100px"><asp:DropDownList id="CboVigencia" runat="server" __designer:wfdid="w15" AutoPostBack="True" DataSourceID="ObjCalVigencias" DataTextField="cal_vig" DataValueField="cal_vig">
                    </asp:DropDownList></TD><TD style="WIDTH: 8px"></TD><TD style="WIDTH: 100px"><asp:Label id="Label13" runat="server" Width="133px" Text="PERIODO GRAVABLE" __designer:wfdid="w16" CssClass="TitDecl"></asp:Label></TD><TD style="WIDTH: 100px"><asp:DropDownList id="Periodo" runat="server" __designer:wfdid="w17" AutoPostBack="True" DataSourceID="ObjCal" DataTextField="cal_des" DataValueField="cal_per"></asp:DropDownList></TD>
                <td style="WIDTH: 100px">
                <asp:Button ID="Button1" runat="server" Text="Ver Archivos Cargados" />
                </td>
                <td style="WIDTH: 100px">
                    <asp:Button ID="BtnAnular" runat="server" __designer:wfdid="w18" 
                        onclick="BtnAnular_Click" Text="Anular" />
                </td>
                <td style="WIDTH: 100px">
                    <asp:Button ID="BtnExcel" runat="server" __designer:wfdid="w19" 
                        onclick="BtnExcel_Click" Text="Exportar Logs" />
                </td>
            </TR><TR onmouseover="Resaltar_On(this);" onmouseout="Resaltar_Off(this);"><TD style="WIDTH: 7px"></TD><TD style="WIDTH: 100px"></TD><TD style="WIDTH: 100px"></TD><TD style="WIDTH: 8px"></TD><TD style="WIDTH: 100px"></TD><TD style="WIDTH: 100px"></TD>
                <td style="WIDTH: 100px">
                    &nbsp;</td>
                <td style="WIDTH: 100px">
                    &nbsp;</td>
            </TR></TBODY></TABLE><BR /><asp:Label id="MsgResult" runat="server" __designer:wfdid="w20"></asp:Label><BR />
            &nbsp;<cc1:GridViewS ID="GrdRad" runat="server" __designer:wfdid="w21" 
                AutoGenerateColumns="False" 
                Caption="ARCHIVOS DE SOPORTE - BASES DE LIQUIDACIÓN" CellPadding="4" 
                DataKeyNames="NRAD" DataSourceID="ObjBl" ForeColor="#333333" GridLines="None" 
                Height="31px" HeightDesplegable="150px" 
                OnSelectedIndexChanged="GrdRad_SelectedIndexChanged" Width="636px" 
                WidthDesplegable="100%">
                <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
                <Columns>
                    <asp:CommandField ButtonType="Image" 
                        SelectImageUrl="~/images/Operaciones/Select.png" ShowSelectButton="True" />
                    <asp:BoundField DataField="Nrad" HeaderText="N° Radicado" />
                    <asp:HyperLinkField DataNavigateUrlFields="archivo" 
                        DataNavigateUrlFormatString="../../Docs/{0}" DataTextField="archivo" 
                        DataTextFormatString="{0}" HeaderText="Archivo" />
                    <asp:BoundField DataField="estado" HeaderText="Estado" />
                    <asp:BoundField DataField="USAP" HeaderText="Usuario" />
                    <asp:BoundField DataField="Fecha_Sistema" HeaderText="Fecha de Cargue" />
                </Columns>
                <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
                <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
                <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                <EditRowStyle BackColor="#999999" />
                <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
            </cc1:GridViewS>
            <BR />
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
                            <asp:Label ID="Label1" runat="server" 
                                Text='<%# Bind("VALORIMPUESTO", "{0:C0}") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>
            &nbsp; <cc1:GridViewS id="GridViewS1" runat="server" Width="636px" Height="70px" ForeColor="#333333" __designer:wfdid="w22" CellPadding="4" GridLines="None" HeightDesplegable="100%" WidthDesplegable="700px">
        <RowStyle BackColor="#F7F6F3" ForeColor="#333333"  />
        <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White"  />
        <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center"  />
        <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333"  />
        <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White"  />
        <EditRowStyle BackColor="#999999"  />
        <AlternatingRowStyle BackColor="White" ForeColor="#284775"  />
    </cc1:GridViewS> &nbsp; <asp:label id="LbTotal" runat="server" __designer:wfdid="w24"></asp:label> <asp:HiddenField id="HdTAG" runat="server" __designer:wfdid="w25"></asp:HiddenField> 
</contenttemplate>
        <triggers>
<asp:AsyncPostBackTrigger ControlID="CboVigencia" EventName="SelectedIndexChanged"></asp:AsyncPostBackTrigger>
<asp:AsyncPostBackTrigger ControlID="Button" EventName="Click"></asp:AsyncPostBackTrigger>
<asp:PostBackTrigger ControlID="BtnExcel" />
<asp:PostBackTrigger ControlID="grdRad" />
</triggers>
        
    </asp:UpdatePanel>
    <br />
    <asp:UpdatePanel id="UpdatePanel2" runat="server" UpdateMode="Conditional">
        <contenttemplate>
<!-- Mensaje de Salida--><asp:Button style="DISPLAY: none" id="hiddenTargetControlForModalPopup" runat="server" __designer:wfdid="w26"></asp:Button> <ajaxToolkit:ModalPopupExtender id="ModalPopup" runat="server" BackgroundCssClass="modalBackground" BehaviorID="programmaticModalPopupBehavior" DropShadow="True" PopupControlID="programmaticPopup" PopupDragHandleControlID="programmaticPopupDragHandle" RepositionMode="RepositionOnWindowScroll" TargetControlID="hiddenTargetControlForModalPopup" __designer:wfdid="w27">
            </ajaxToolkit:ModalPopupExtender> <asp:Panel id="programmaticPopup" runat="server" Width="625px" Height="229%" CssClass="ModalPanel2" __designer:wfdid="w28"><asp:Panel id="programmaticPopupDragHandle" runat="Server" Width="620px" Height="30px" CssClass="BarTitleModal2" __designer:wfdid="w29"><DIV style="PADDING-RIGHT: 5px; PADDING-LEFT: 5px; PADDING-BOTTOM: 5px; VERTICAL-ALIGN: middle; PADDING-TOP: 5px"><DIV style="FLOAT: left">Buscar Agente Recaudador </DIV> <DIV style="FLOAT: right"><INPUT id="hideModalPopupViaClientButton" type=button value="X" /></DIV></DIV></asp:Panel> &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;<BR />&nbsp; &nbsp; &nbsp;&nbsp; <uc1:consultater id="ConsultaTer1" runat="server" ret="AR" tipo="AR" __designer:wfdid="w30"></uc1:consultater> <BR /><BR /><BR /></asp:Panel> 
</contenttemplate>
        <triggers>
<asp:AsyncPostBackTrigger ControlID="BtnBusc" EventName="Click"></asp:AsyncPostBackTrigger>
</triggers>
    </asp:UpdatePanel>
    <br />
    <asp:ObjectDataSource ID="ObjCDec" runat="server" OldValuesParameterFormatString="original_{0}"
        SelectMethod="GetCDEC_PorNit" TypeName="CDeclaraciones">
        <SelectParameters>
            <asp:ControlParameter ControlID="Nit" Name="Nit" PropertyName="Text" Type="String" />
        </SelectParameters>
    </asp:ObjectDataSource>
    <asp:ObjectDataSource ID="ObjBl" runat="server" OldValuesParameterFormatString="original_{0}"
        SelectMethod="GetRecords" TypeName="BasesLiq">
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
    <asp:HiddenField ID="Cla_Dec" runat="server" Value="01" />
    <asp:ObjectDataSource ID="ObjLiq" runat="server" OldValuesParameterFormatString="original_{0}"
        SelectMethod="GetAforoCdec" TypeName="BasesLiq" UpdateMethod="Anular">
        <UpdateParameters>
            <asp:Parameter Name="nro_rad" Type="String" />
        </UpdateParameters>
        <SelectParameters>
            <asp:ControlParameter ControlID="CbCdec" Name="Cla_dec" 
                PropertyName="SelectedValue" Type="String" />
            <asp:ControlParameter ControlID="HdTAG" Name="Tipo_Agente" PropertyName="Value" 
                Type="String" />
            <asp:ControlParameter ControlID="GrdRad" Name="nro_rad" PropertyName="SelectedValue"
                Type="Int64" />
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
    <asp:UpdateProgress ID="UpdateProgress1" runat="server" AssociatedUpdatePanelID="UpdatePanel1">
            <ProgressTemplate>
                <div class="Loading">
                    <img alt="" src="../../images/loading.gif" title="" />
                    Cargando …
                </div>
            </ProgressTemplate>
        </asp:UpdateProgress>    
    </div>
</asp:Content>



