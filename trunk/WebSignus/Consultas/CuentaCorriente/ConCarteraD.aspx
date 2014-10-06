<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="ConCarteraD.aspx.vb" 
Inherits="Consultas_CuentaCorriente_ConCarteraD" title="Untitled Page"
EnableEventValidation = "false"  %>
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
            //$addHandler($get("showModalPopupClientButton"), 'click', showModalPopupViaClient);
            $addHandler($get("BtnCerrar"), 'click', hideModalPopupViaClient);        
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
        }
        
        function MostrarNit()
        {
        __doPostBack("<%= BuscarNit.ClientID %>","");
        }
    </script>
    <script type="text/javascript">
        function PanelClick(sender, e) {
            var Messages = $get('<%=Messages.ClientID%>');
            Highlight(Messages);
        }

        function ActiveTabChanged(sender, e) {
            var CurrentTab = $get('<%=CurrentTab.ClientID%>');
            CurrentTab.innerHTML = sender.get_activeTab().get_headerText();
            //Highlight(CurrentTab);
        }

        var HighlightAnimations = {};
        function Highlight(el) {
            if (HighlightAnimations[el.uniqueID] == null) {
                HighlightAnimations[el.uniqueID] = AjaxControlToolkit.Animation.createAnimation({
                    AnimationName: "color",
                    duration: 0.5,
                    property: "style",
                    propertyKey: "backgroundColor",
                    startValue: "#FFFF90",
                    endValue: "#FFFFFF"
                }, el);
            }
            HighlightAnimations[el.uniqueID].stop();
            HighlightAnimations[el.uniqueID].play();
        }

        function ToggleHidden(value) {
            $find('<%=Tabs.ClientID%>').get_tabs()[2].set_enabled(value);
        }
    </script>
    
<ajaxToolkit:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server">
    </ajaxToolkit:ToolkitScriptManager>
    
<div class="demoarea">
    <div class="DecHeader">
        <div class="DecHeader">
            <asp:UpdatePanel id="UpdNit" runat="server">
                <contenttemplate>
<TABLE width=400><TBODY><TR><TD style="HEIGHT: 13px" class="TDNegroFila" width=400><asp:Label id="Label10" runat="server" Font-Bold="True" Text="AGENTE RECAUDADOR"></asp:Label>&nbsp;&nbsp; <asp:Button style="DISPLAY: none" id="button" onclick="button_Click" runat="server"></asp:Button> <asp:Button style="DISPLAY: none" id="BuscarNit" onclick="BuscarNit_Click" runat="server" UseSubmitBehavior="False"></asp:Button></TD></TR><TR><TD style="HEIGHT: 86px" width=400><TABLE width="100%"><TBODY><TR onmouseover="Resaltar_On(this);" onmouseout="Resaltar_Off(this);"><TD style="WIDTH: 86px; HEIGHT: 15px">
    <asp:Label ID="Label45" runat="server" CssClass="TitDecl" Font-Bold="True" 
        Text="IDENTIFICACIÓN" Width="115px"></asp:Label>
    </TD><TD style="WIDTH: 86px; HEIGHT: 15px">&nbsp;<asp:Label ID="Label2" runat="server" 
            CssClass="TitDecl" Font-Bold="True" Text="DV"></asp:Label>
    </TD><TD style="WIDTH: 131px; HEIGHT: 15px"></TD>
    <TD style="WIDTH: 131px; HEIGHT: 15px">
        <asp:Label ID="Label11" runat="server" CssClass="TitDecl" Font-Bold="True" 
            Text="RAZON SOCIAL"></asp:Label>
    </TD>
    <td style="WIDTH: 253px; HEIGHT: 15px">
    </td>
    </TR><TR onmouseover="Resaltar_On(this);" onmouseout="Resaltar_Off(this);"><TD style="WIDTH: 86px; HEIGHT: 19px">
        <asp:TextBox id="Nit" runat="server" Enabled="False" __designer:wfdid="w1"></asp:TextBox> </TD>
        <TD style="HEIGHT: 19px; width: 86px;">
            <asp:TextBox ID="Dv" runat="server" Enabled="False" Width="17px"></asp:TextBox>
        </TD><TD style="HEIGHT: 19px" colSpan=1>
            <asp:Button ID="BtnBuscar" runat="server" __designer:wfdid="w8" accessKey="B" 
                onclick="BtnBuscar_Click" Text="..." ToolTip="Buscar Agente Recaudador" 
                UseSubmitBehavior="False" />
        </TD>
        <td colspan="2" style="HEIGHT: 19px">
            <asp:TextBox ID="Agente" runat="server" Enabled="False" Width="332px"></asp:TextBox>
        </td>
    </TR></TBODY></TABLE></TD></TR></TBODY></TABLE>
</contenttemplate>
            </asp:UpdatePanel>
            <br />
            <asp:Label ID="Messages" runat="server" />
            <br />
            <asp:CheckBox ID="showComponents" runat="server" Checked="true" 
                onclick="ToggleHidden(this.checked)" Text=" Show Controls Owned" />
            <br />
            <asp:Label ID="CurrentTab" runat="server" Text="CurrentTab" />
            <br />
            <asp:UpdatePanel id="UpdatePanel1" runat="server">
                <contenttemplate>
<asp:DropDownList id="CboTipo" runat="server" __designer:wfdid="w26" AutoPostBack="True" OnSelectedIndexChanged="CboTipo_SelectedIndexChanged"><asp:ListItem Selected="True">Estado</asp:ListItem>
<asp:ListItem Value="T">Total</asp:ListItem>
</asp:DropDownList> 
                    <BR /><asp:GridView id="grDCobrar" runat="server" Width="100%" 
                        __designer:wfdid="w23" GridLines="Vertical" DataSourceID="ObjDBCobrar" 
                        AllowSorting="True" AutoGenerateColumns="False" DataKeyNames="Car_Cdec" 
                        Caption="DEBIDO COBRAR"><Columns>
<asp:BoundField DataField="Car_Cdec" HeaderText="Clase Dec"></asp:BoundField>
<asp:BoundField DataField="Cld_Nom" HeaderText="Por Concepto"></asp:BoundField>
<asp:BoundField DataField="Saldo_a_Cargo" DataFormatString="{0:c}" HeaderText="Saldo a Cargo"></asp:BoundField>
<asp:BoundField DataField="Saldo_a_Favor" DataFormatString="{0:c}" HeaderText="Saldo a Favor"></asp:BoundField>
<asp:CommandField SelectImageUrl="~/images/Operaciones/Select.png" SelectText="Seleccionar" ShowSelectButton="True" ButtonType="Image"></asp:CommandField>
</Columns>
</asp:GridView> <asp:MultiView id="MultiView1" runat="server" __designer:wfdid="w11" ActiveViewIndex="1"><asp:View id="View1" runat="server" __designer:wfdid="w37"><asp:Button id="BtnVerMovA" onclick="BtnVerMovA_Click" runat="server" Text="Movimientos" __designer:wfdid="w176" CommandName="MTA"></asp:Button> 
                        <asp:GridView id="grAño" runat="server" Width="100%" __designer:wfdid="w38" 
                            GridLines="Vertical" DataSourceID="ObjCart" AllowSorting="True" 
                            AutoGenerateColumns="False" DataKeyNames="Car_Ano" 
                            Caption="CONSULTA POR AÑO GRAVABLE"><Columns>
<asp:BoundField DataField="Car_Ano" DataFormatString="{0:c}" HeaderText="A&#241;o "></asp:BoundField>
<asp:BoundField DataField="Saldo_a_Cargo" DataFormatString="{0:c}" HeaderText="Saldo a Cargo">
<ItemStyle HorizontalAlign="Right"></ItemStyle>
</asp:BoundField>
<asp:BoundField DataField="Saldo_a_Favor" DataFormatString="{0:c}" HeaderText="Saldo_a_Favor">
<ItemStyle HorizontalAlign="Right"></ItemStyle>
</asp:BoundField>
<asp:CommandField SelectImageUrl="~/images/Operaciones/Select.png" SelectText="Seleccionar" ShowSelectButton="True" ButtonType="Image">
<ItemStyle HorizontalAlign="Center"></ItemStyle>
</asp:CommandField>
</Columns>
</asp:GridView><asp:GridView id="grPer" runat="server" Width="100%" __designer:wfdid="w39" 
                            GridLines="Vertical" DataSourceID="ObjDCart" AllowSorting="True" 
                            AutoGenerateColumns="False" DataKeyNames="Car_Per" 
                            Caption="CONSULTA POR PERIODO"><Columns>
<asp:BoundField DataField="Car_Ano" DataFormatString="{0:c}" HeaderText="A&#241;o ">
<ItemStyle Font-Size="8pt"></ItemStyle>
</asp:BoundField>
<asp:BoundField DataField="Car_per" HeaderText="Periodo">
<ItemStyle HorizontalAlign="Right" Font-Size="8pt"></ItemStyle>
</asp:BoundField>
<asp:BoundField DataField="Car_VaDe" DataFormatString="{0:c}" HeaderText="Valor Declarado">
<ItemStyle HorizontalAlign="Right" Font-Size="8pt"></ItemStyle>
</asp:BoundField>
<asp:BoundField DataField="Car_Vdb" DataFormatString="{0:c}" HeaderText="D&#233;bitos">
<ItemStyle HorizontalAlign="Right" Font-Size="8pt"></ItemStyle>
</asp:BoundField>
<asp:BoundField DataField="Car_Vcr" DataFormatString="{0:c}" HeaderText="Cr&#233;ditos">
<ItemStyle HorizontalAlign="Right" Font-Size="8pt"></ItemStyle>
</asp:BoundField>
<asp:BoundField DataField="Car_Vpa" DataFormatString="{0:c}" HeaderText="Pagos">
<ItemStyle HorizontalAlign="Right" Font-Size="8pt"></ItemStyle>
</asp:BoundField>
<asp:BoundField DataField="Saldo_a_Cargo" DataFormatString="{0:c}" HeaderText="Saldo a Cargo">
<ItemStyle HorizontalAlign="Right" Font-Size="8pt"></ItemStyle>
</asp:BoundField>
<asp:BoundField DataField="Saldo_a_Favor" DataFormatString="{0:c}" HeaderText="Saldo a Favor">
<ItemStyle HorizontalAlign="Right"></ItemStyle>
</asp:BoundField>
<asp:CommandField SelectImageUrl="~/images/Operaciones/Select.png" SelectText="Seleccionar" ShowSelectButton="True" ButtonType="Image"></asp:CommandField>
</Columns>
</asp:GridView><asp:Button id="BtnExcel" onclick="BtnExcel_Click" runat="server" Text="Export Excel" __designer:wfdid="w40"></asp:Button><BR />
                        <asp:GridView id="grConc" runat="server" Width="100%" __designer:wfdid="w41" 
                            GridLines="Vertical" DataSourceID="ObjDCartD" AllowSorting="True" 
                            AutoGenerateColumns="False" Caption="DETALLE CONCEPTOS POR PERIODO"><Columns>
<asp:BoundField DataField="Car_Ano" DataFormatString="{0:c}" HeaderText="A&#241;o " Visible="False">
<ItemStyle Font-Size="8pt"></ItemStyle>
</asp:BoundField>
<asp:BoundField DataField="Car_per" HeaderText="Periodo" Visible="False">
<ItemStyle HorizontalAlign="Right" Font-Size="8pt"></ItemStyle>
</asp:BoundField>
<asp:BoundField DataField="Car_Coca" HeaderText="C&#243;digo Cartera" Visible="False">
<ControlStyle Width="0px"></ControlStyle>

<ItemStyle Width="0px"></ItemStyle>
</asp:BoundField>
<asp:BoundField DataField="cCar_Nom" HeaderText="Concepto"></asp:BoundField>
<asp:BoundField DataField="Car_VaDe" DataFormatString="{0:c}" HeaderText="Valor Declarado">
<ItemStyle HorizontalAlign="Right" Font-Size="8pt"></ItemStyle>
</asp:BoundField>
<asp:BoundField DataField="Car_Vdb" DataFormatString="{0:c}" HeaderText="D&#233;bitos">
<ItemStyle HorizontalAlign="Right" Font-Size="8pt"></ItemStyle>
</asp:BoundField>
<asp:BoundField DataField="Car_Vcr" DataFormatString="{0:c}" HeaderText="Cr&#233;ditos">
<ItemStyle HorizontalAlign="Right" Font-Size="8pt"></ItemStyle>
</asp:BoundField>
<asp:BoundField DataField="Car_Vpa" DataFormatString="{0:c}" HeaderText="Pagos">
<ItemStyle HorizontalAlign="Right" Font-Size="8pt"></ItemStyle>
</asp:BoundField>
<asp:BoundField DataField="Saldo_a_Cargo" DataFormatString="{0:c}" HeaderText="Saldo a Cargo">
<ItemStyle HorizontalAlign="Right" Font-Size="8pt"></ItemStyle>
</asp:BoundField>
<asp:BoundField DataField="Saldo_a_Favor" DataFormatString="{0:c}" HeaderText="Saldo a Favor">
<ItemStyle HorizontalAlign="Right"></ItemStyle>
</asp:BoundField>
<asp:CommandField SelectImageUrl="~/images/Operaciones/Select.png" SelectText="Seleccionar" ShowSelectButton="True" ButtonType="Image"></asp:CommandField>
</Columns>
</asp:GridView></asp:View> <asp:View id="View2" runat="server" __designer:wfdid="w42">
                            <asp:GridView id="grCEstado" runat="server" Width="100%" __designer:wfdid="w43" 
                                GridLines="Vertical" DataSourceID="ObjCPEst" AllowSorting="True" 
                                AutoGenerateColumns="False" DataKeyNames="Car_Est" 
                                Caption="CONSULTA POR ESTADO DE LA CARTERA"><Columns>
<asp:BoundField DataField="Estado" HeaderText="Estado" SortExpression="Estado"></asp:BoundField>
<asp:BoundField DataField="Saldo_a_Cargo" DataFormatString="{0:c}" HeaderText="Saldo a Cargo" SortExpression="Saldo_a_Cargo">
<ItemStyle HorizontalAlign="Right"></ItemStyle>
</asp:BoundField>
<asp:BoundField DataField="Saldo_a_Favor" DataFormatString="{0:c}" HeaderText="Saldo_a_Favor" SortExpression="Saldo_a_Favor">
<ItemStyle HorizontalAlign="Right"></ItemStyle>
</asp:BoundField>
<asp:CommandField SelectImageUrl="~/images/Operaciones/Select.png" SelectText="Seleccionar" ShowSelectButton="True" ButtonType="Image">
<ItemStyle HorizontalAlign="Center"></ItemStyle>
</asp:CommandField>
</Columns>
</asp:GridView><asp:GridView id="grdCEAP" runat="server" Width="100%" __designer:wfdid="w44" 
                                GridLines="Vertical" DataSourceID="ObjCEstAP" AllowSorting="True" 
                                AutoGenerateColumns="False" DataKeyNames="Car_Ano" 
                                Caption="CONSULTA POR AÑO GRAVABLE"><Columns>
<asp:BoundField DataField="Car_Ano" DataFormatString="{0:c}" HeaderText="A&#241;o "></asp:BoundField>
<asp:BoundField DataField="Saldo_a_Cargo" DataFormatString="{0:c}" HeaderText="Saldo a Cargo">
<ItemStyle HorizontalAlign="Right"></ItemStyle>
</asp:BoundField>
<asp:BoundField DataField="Saldo_a_Favor" DataFormatString="{0:c}" HeaderText="Saldo_a_Favor">
<ItemStyle HorizontalAlign="Right"></ItemStyle>
</asp:BoundField>
<asp:CommandField SelectImageUrl="~/images/Operaciones/Select.png" SelectText="Seleccionar" ShowSelectButton="True" ButtonType="Image">
<ItemStyle HorizontalAlign="Center"></ItemStyle>
</asp:CommandField>
</Columns>
</asp:GridView>
                            <br />
                            <asp:Button ID="Button1" runat="server" Text="Button" />
                            <asp:GridView id="grdEPer" runat="server" Width="100%" __designer:wfdid="w45" 
                                GridLines="Vertical" DataSourceID="ObjDECart" AllowSorting="True" 
                                AutoGenerateColumns="False" DataKeyNames="Car_Per" 
                                Caption="CONSULTA DE PERIODOS GRAVABLES"><Columns>
<asp:BoundField DataField="Car_Ano" DataFormatString="{0:c}" HeaderText="A&#241;o ">
<ItemStyle Font-Size="8pt"></ItemStyle>
</asp:BoundField>
<asp:BoundField DataField="Car_per" HeaderText="Periodo">
<ItemStyle HorizontalAlign="Right" Font-Size="8pt"></ItemStyle>
</asp:BoundField>
<asp:BoundField DataField="Car_VaDe" DataFormatString="{0:c}" HeaderText="Valor Declarado">
<ItemStyle HorizontalAlign="Right" Font-Size="8pt"></ItemStyle>
</asp:BoundField>
<asp:BoundField DataField="Car_Vdb" DataFormatString="{0:c}" HeaderText="D&#233;bitos">
<ItemStyle HorizontalAlign="Right" Font-Size="8pt"></ItemStyle>
</asp:BoundField>
<asp:BoundField DataField="Car_Vcr" DataFormatString="{0:c}" HeaderText="Cr&#233;ditos">
<ItemStyle HorizontalAlign="Right" Font-Size="8pt"></ItemStyle>
</asp:BoundField>
<asp:BoundField DataField="Car_Vpa" DataFormatString="{0:c}" HeaderText="Pagos">
<ItemStyle HorizontalAlign="Right" Font-Size="8pt"></ItemStyle>
</asp:BoundField>
<asp:BoundField DataField="Saldo_a_Cargo" DataFormatString="{0:c}" HeaderText="Saldo a Cargo">
<ItemStyle HorizontalAlign="Right" Font-Size="8pt"></ItemStyle>
</asp:BoundField>
<asp:BoundField DataField="Saldo_a_Favor" DataFormatString="{0:c}" HeaderText="Saldo a Favor">
<ItemStyle HorizontalAlign="Right"></ItemStyle>
</asp:BoundField>
<asp:CommandField SelectImageUrl="~/images/Operaciones/Select.png" SelectText="Seleccionar" ShowSelectButton="True" ButtonType="Image"></asp:CommandField>
</Columns>
</asp:GridView>
                            <br />
                            <ajaxToolkit:TabContainer ID="Tabs" runat="server" ActiveTabIndex="1" 
                                Height="300px" OnClientActiveTabChanged="ActiveTabChanged" Width="100%">
                                <ajaxToolkit:TabPanel ID="TabPanel1" runat="server" HeaderText="Por Periodos">
                                <HeaderTemplate>
                                <b>Detallado por Conceptos</b>
                                </HeaderTemplate>
                                
                                    <ContentTemplate>
                                        <asp:GridView ID="grdEConc" runat="server" __designer:wfdid="w46" 
                                            AllowSorting="True" AutoGenerateColumns="False" 
                                            Caption="CONSULTA DETALLADA POR PERIODO" DataSourceID="ObjDECartD" 
                                            GridLines="Vertical" Width="100%">
                                            <Columns>
                                                <asp:BoundField DataField="Car_Ano" DataFormatString="{0:c}" HeaderText="Año " 
                                                    Visible="False">
                                                <ItemStyle Font-Size="8pt" />
                                                </asp:BoundField>
                                                <asp:BoundField DataField="Car_per" HeaderText="Periodo" Visible="False">
                                                <ItemStyle Font-Size="8pt" HorizontalAlign="Right" />
                                                </asp:BoundField>
                                                <asp:BoundField DataField="Car_Coca" HeaderText="Código Cartera" 
                                                    Visible="False">
                                                <ControlStyle Width="0px" />
                                                <ItemStyle Width="0px" />
                                                </asp:BoundField>
                                                <asp:BoundField DataField="cCar_Nom" HeaderText="Concepto" />
                                                <asp:BoundField DataField="Car_VaDe" DataFormatString="{0:c}" 
                                                    HeaderText="Valor Declarado">
                                                <ItemStyle Font-Size="8pt" HorizontalAlign="Right" />
                                                </asp:BoundField>
                                                <asp:BoundField DataField="Car_Vdb" DataFormatString="{0:c}" 
                                                    HeaderText="Débitos">
                                                <ItemStyle Font-Size="8pt" HorizontalAlign="Right" />
                                                </asp:BoundField>
                                                <asp:BoundField DataField="Car_Vcr" DataFormatString="{0:c}" 
                                                    HeaderText="Créditos">
                                                <ItemStyle Font-Size="8pt" HorizontalAlign="Right" />
                                                </asp:BoundField>
                                                <asp:BoundField DataField="Car_Vpa" DataFormatString="{0:c}" HeaderText="Pagos">
                                                <ItemStyle Font-Size="8pt" HorizontalAlign="Right" />
                                                </asp:BoundField>
                                                <asp:BoundField DataField="Saldo_a_Cargo" DataFormatString="{0:c}" 
                                                    HeaderText="Saldo a Cargo">
                                                <ItemStyle Font-Size="8pt" HorizontalAlign="Right" />
                                                </asp:BoundField>
                                                <asp:BoundField DataField="Saldo_a_Favor" DataFormatString="{0:c}" 
                                                    HeaderText="Saldo a Favor">
                                                <ItemStyle HorizontalAlign="Right" />
                                                </asp:BoundField>
                                                <asp:BoundField DataField="Car_TDoc" HeaderText="TDoc" 
                                                    SortExpression="Car_TDoc" />
                                                <asp:BoundField DataField="Car_DCod" HeaderText="N° Doc" 
                                                    SortExpression="Car_DCod" />
                                                <asp:CommandField ButtonType="Image" 
                                                    SelectImageUrl="~/images/Operaciones/Select.png" 
                                                    ShowSelectButton="True" />
                                            </Columns>
                                        </asp:GridView>
                                    </ContentTemplate>
                                </ajaxToolkit:TabPanel>
                                <ajaxToolkit:TabPanel ID="TabPanel2" runat="server" HeaderText="Declaraciones">
                                    <HeaderTemplate>
                                     <b>Declararaciones</b> 
                                    </HeaderTemplate>
                                    <ContentTemplate>
                                        <cc1:GridViewS ID="grdEDec" runat="server" __designer:wfdid="w23" 
                                            AllowSorting="True" 
                                            DataSourceID="ObjDecP" GridLines="None" 
                                            EmptyDataText="NO RECORDS" Width="636px" Height="70px" 
                                            HeightDesplegable="250px" WidthDesplegable="900px" CellPadding="4" 
                                            ForeColor="#333333">
                                            <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
                                            <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                                            <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
                                            <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
                                            <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                                            <EditRowStyle BackColor="#999999" />
                                            <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                                        </cc1:GridViewS>
                                    </ContentTemplate>
                                </ajaxToolkit:TabPanel>
                                <ajaxToolkit:TabPanel ID="TabPanel3" runat="server" HeaderText="Por Periodos">
                                <HeaderTemplate>
                                <b>Pagos</b>
                                </HeaderTemplate>
                                    <ContentTemplate>
                                    </ContentTemplate>
                                    </ajaxToolkit:TabPanel>
                              <ajaxToolkit:TabPanel ID="TabPanel4" runat="server" HeaderText="Por Periodos">
                                <HeaderTemplate>
                                <b>Movimientos</b>
                                </HeaderTemplate>
                                    <ContentTemplate>
                                    </ContentTemplate>
                                    </ajaxToolkit:TabPanel>
                                <ajaxToolkit:TabPanel ID="TabPanel5" runat="server" HeaderText="Por Periodos">
                                <HeaderTemplate>
                                <b>Acuerdos de Pago</b>
                                </HeaderTemplate>
                                    <ContentTemplate>
                                    </ContentTemplate>
                                    </ajaxToolkit:TabPanel>                                    
                            </ajaxToolkit:TabContainer>
<br />
</asp:View></asp:MultiView><asp:ObjectDataSource id="ObjDecP" runat="server" 
                        __designer:dtid="1125899906842659" TypeName="CDeclaraciones" 
                        SelectMethod="GetDecPorEst_LK" OldValuesParameterFormatString="original_{0}" 
                        __designer:wfdid="w28"><SelectParameters __designer:dtid="1125899906842660">
<asp:ControlParameter ControlID="Nit" PropertyName="Text" DefaultValue="" Name="Car_Nit" Type="String" 
                                __designer:dtid="1125899906842661"></asp:ControlParameter>
                            <asp:ControlParameter ControlID="grdCEAP" DefaultValue="" Name="Car_Ano" 
                                PropertyName="SelectedValue" Type="String" />
                            <asp:ControlParameter ControlID="grDCobrar" DefaultValue="" Name="Car_Cdec" 
                                PropertyName="SelectedValue" Type="String" />
                            <asp:ControlParameter ControlID="grdEPer" DefaultValue="" Name="car_per" 
                                PropertyName="SelectedValue" Type="String" />
</SelectParameters>
</asp:ObjectDataSource><asp:ObjectDataSource id="ObjDECart" runat="server" __designer:dtid="2533274790395915" TypeName="CDeclaraciones" SelectMethod="GetECartPer" OldValuesParameterFormatString="original_{0}" __designer:wfdid="w7"><SelectParameters __designer:dtid="2533274790395916">
<asp:ControlParameter ControlID="Nit" PropertyName="Text" DefaultValue="" Name="Car_Nit" Type="String" __designer:dtid="2533274790395917"></asp:ControlParameter>
<asp:ControlParameter ControlID="grdCEAP" PropertyName="SelectedValue" DefaultValue="" Name="Car_Ano" Type="String" __designer:dtid="2533274790395918"></asp:ControlParameter>
<asp:ControlParameter ControlID="grDCobrar" PropertyName="SelectedValue" DefaultValue="" Name="Car_Cdec" Type="String" __designer:dtid="2533274790395919"></asp:ControlParameter>
<asp:ControlParameter ControlID="grCEstado" PropertyName="SelectedValue" Name="Car_Est"></asp:ControlParameter>
</SelectParameters>
</asp:ObjectDataSource> <asp:ObjectDataSource id="ObjDECartD" runat="server" __designer:dtid="1125899906842659" TypeName="CDeclaraciones" SelectMethod="GetECartPerD" OldValuesParameterFormatString="original_{0}" __designer:wfdid="w10"><SelectParameters __designer:dtid="1125899906842660">
<asp:ControlParameter ControlID="Nit" PropertyName="Text" DefaultValue="12345" Name="Car_Nit" Type="String" __designer:dtid="1125899906842661"></asp:ControlParameter>
<asp:ControlParameter ControlID="grdCEAP" PropertyName="SelectedValue" DefaultValue="" Name="Car_Ano" Type="String" __designer:dtid="1125899906842662"></asp:ControlParameter>
<asp:ControlParameter ControlID="grDCobrar" PropertyName="SelectedValue" DefaultValue="" Name="Car_Cdec" Type="String"></asp:ControlParameter>
<asp:ControlParameter ControlID="grdEPer" PropertyName="SelectedValue" Name="Car_Per"></asp:ControlParameter>
<asp:ControlParameter ControlID="grCEstado" PropertyName="SelectedValue" DefaultValue="" Name="Car_Est"></asp:ControlParameter>
</SelectParameters>
</asp:ObjectDataSource>&nbsp;<asp:ObjectDataSource ID="ObjDCartD" runat="server" 
                        __designer:dtid="1125899906842659" __designer:wfdid="w28" 
                        OldValuesParameterFormatString="original_{0}" SelectMethod="GetCartPerD" 
                        TypeName="CDeclaraciones">
                        <SelectParameters __designer:dtid="1125899906842660">
                            <asp:ControlParameter __designer:dtid="1125899906842661" ControlID="Nit" 
                                DefaultValue="12345" Name="Car_Nit" PropertyName="Text" Type="String" />
                            <asp:ControlParameter __designer:dtid="1125899906842662" ControlID="grAño" 
                                DefaultValue="" Name="Car_Ano" PropertyName="SelectedValue" Type="String" />
                            <asp:ControlParameter ControlID="grDCobrar" DefaultValue="" Name="Car_Cdec" 
                                PropertyName="SelectedValue" Type="String" />
                            <asp:ControlParameter ControlID="grPer" Name="Car_Per" 
                                PropertyName="SelectedValue" />
                        </SelectParameters>
                    </asp:ObjectDataSource>
&nbsp;<asp:ObjectDataSource id="ObjMA" runat="server" TypeName="Informes" SelectMethod="GetMovimientosA" __designer:wfdid="w174"><SelectParameters>
<asp:ControlParameter ControlID="grDCobrar" PropertyName="SelectedValue" Name="ClDec"></asp:ControlParameter>
<asp:ControlParameter ControlID="Nit" PropertyName="Text" Name="Nit"></asp:ControlParameter>
<asp:ControlParameter ControlID="grA&#241;o" PropertyName="SelectedValue" Name="Agra"></asp:ControlParameter>
</SelectParameters>
</asp:ObjectDataSource><BR />
</contenttemplate>
                <triggers>
<asp:PostBackTrigger ControlID="BtnExcel"></asp:PostBackTrigger>
</triggers>
            </asp:UpdatePanel><asp:ObjectDataSource ID="ObjDCart" runat="server" OldValuesParameterFormatString="original_{0}"
        SelectMethod="GetCartPer" TypeName="CDeclaraciones">
        <SelectParameters>
            <asp:ControlParameter ControlID="Nit" DefaultValue="12345" Name="Car_Nit" PropertyName="Text"
                Type="String" />
            <asp:ControlParameter ControlID="grA&#241;o" DefaultValue="" Name="Car_Ano" PropertyName="SelectedValue"
                Type="String" />
            <asp:ControlParameter ControlID="grDCobrar" DefaultValue="" Name="Car_Cdec" PropertyName="SelectedValue"
                Type="String" />
        </SelectParameters>
    </asp:ObjectDataSource>
            <asp:ObjectDataSource ID="ObjDBCobrar" runat="server" SelectMethod="GetDEBIDOCOBRAR"
                TypeName="CDeclaraciones">
                <SelectParameters>
                    <asp:ControlParameter ControlID="Nit" Name="Nit" PropertyName="Text" />
                </SelectParameters>
            </asp:ObjectDataSource>
    <asp:ObjectDataSource ID="ObjCart" runat="server" OldValuesParameterFormatString="original_{0}"
        SelectMethod="GetCartAGravable" TypeName="CDeclaraciones">
        <SelectParameters>
            <asp:ControlParameter ControlID="Nit" DefaultValue="12345" Name="Car_Nit" PropertyName="Text"
                Type="String" />
            <asp:ControlParameter ControlID="grDCobrar" DefaultValue="" Name="Car_Cdec" PropertyName="SelectedValue" />
        </SelectParameters>
    </asp:ObjectDataSource><asp:ObjectDataSource ID="ObjCPEst" runat="server" OldValuesParameterFormatString="original_{0}"
        SelectMethod="GetCartPEstado" TypeName="CDeclaraciones">
        <SelectParameters>
            <asp:ControlParameter ControlID="Nit" Name="Car_Nit" PropertyName="Text"
                Type="String" />
            <asp:ControlParameter ControlID="grDCobrar" DefaultValue="" Name="Car_Cdec" PropertyName="SelectedValue" />
        </SelectParameters>
    </asp:ObjectDataSource>
            <asp:ObjectDataSource ID="ObjCEstAP" runat="server" OldValuesParameterFormatString="original_{0}"
        SelectMethod="GetCartEAGravable" TypeName="CDeclaraciones">
                <SelectParameters>
                    <asp:ControlParameter ControlID="Nit" Name="Car_Nit" PropertyName="Text"
                Type="String" />
                    <asp:ControlParameter ControlID="grDCobrar" DefaultValue="" Name="Car_Cdec" PropertyName="SelectedValue" />
                    <asp:ControlParameter ControlID="grCEstado" Name="Car_Est" PropertyName="SelectedValue" />
                </SelectParameters>
            </asp:ObjectDataSource>
            <asp:UpdatePanel id="UpdatePanel2" runat="server" UpdateMode="Conditional">
                <contenttemplate>
<!-- Mensaje de Salida--><asp:Button style="DISPLAY: none" id="hiddenTargetControlForModalPopup" runat="server" __designer:wfdid="w3"></asp:Button> <ajaxToolkit:ModalPopupExtender id="ModalPopup" runat="server" __designer:wfdid="w4" BackgroundCssClass="modalBackground" BehaviorID="programmaticModalPopupBehavior" DropShadow="True" PopupControlID="programmaticPopup" PopupDragHandleControlID="programmaticPopupDragHandle" RepositionMode="RepositionOnWindowScroll" TargetControlID="hiddenTargetControlForModalPopup">
            </ajaxToolkit:ModalPopupExtender> <asp:Panel id="programmaticPopup" runat="server" Width="625px" Height="229%" CssClass="ModalPanel2" __designer:wfdid="w5"><asp:Panel id="programmaticPopupDragHandle" runat="Server" Width="620px" Height="30px" CssClass="BarTitleModal2" __designer:wfdid="w6"><DIV style="PADDING-RIGHT: 5px; PADDING-LEFT: 5px; PADDING-BOTTOM: 5px; VERTICAL-ALIGN: middle; PADDING-TOP: 5px"><DIV style="FLOAT: left">Buscar Agente Recaudador </DIV> 
                        &nbsp;<DIV style="FLOAT: right"><INPUT id="BtnCerrar" type=button value="X" /></DIV></DIV></asp:Panel> &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;<BR />&nbsp; &nbsp; &nbsp;&nbsp; <uc1:consultater id="ConsultaTer1" runat="server" __designer:wfdid="w7" ret="AR" tipo="AR"></uc1:consultater> <BR /><BR /><BR /></asp:Panel> 
</contenttemplate>
                <triggers>
<asp:AsyncPostBackTrigger ControlID="BtnBuscar" EventName="Click"></asp:AsyncPostBackTrigger>
</triggers>
            </asp:UpdatePanel><asp:UpdatePanel id="UpdatePanel3" runat="server"><contenttemplate>
<BR /><asp:Button style="DISPLAY: none" id="hiddenTargetControlForModalPopup3" runat="server"></asp:Button> <ajaxToolkit:ModalPopupExtender id="ModalPopupTer3" runat="server" TargetControlID="hiddenTargetControlForModalPopup3" RepositionMode="RepositionOnWindowScroll" PopupDragHandleControlID="programmaticPopupDragHandle3" PopupControlID="programmaticPopup3" DropShadow="True" BehaviorID="programmaticModalPopupBehavior3" BackgroundCssClass="modalBackground"></ajaxToolkit:ModalPopupExtender> <asp:Panel id="programmaticPopup3" runat="server" Width="740px" Height="468%" CssClass="ModalPanel2"><asp:Panel id="programmaticPopupDragHandle3" runat="Server" Width="736px" Height="30px" CssClass="BarTitleModal2"><DIV style="PADDING-RIGHT: 5px; PADDING-LEFT: 5px; PADDING-BOTTOM: 5px; VERTICAL-ALIGN: middle; PADDING-TOP: 5px"><DIV style="FLOAT: left">Consulta de Movimientos</DIV><DIV style="FLOAT: right"><INPUT id="BtnClosePar" type=button value="X" /></DIV></DIV></asp:Panel> <BR /><asp:MultiView id="MVMov" runat="server"><asp:View id="VA" runat="server"><asp:GridView id="grdMTA" runat="server" AllowSorting="True" DataSourceID="ObjMA" AllowPaging="True"></asp:GridView> </asp:View></asp:MultiView><BR /></asp:Panel>&nbsp; 
</contenttemplate>
            </asp:UpdatePanel><br />
        </div>
    </div>
    <asp:UpdateProgress id="UpdateProgress1" runat="server" AssociatedUpdatePanelID="UpdatePanel1">
        <progresstemplate>
<DIV class="Loading"><IMG title="" alt="" src="../../images/loading.gif" /> Cargando … </DIV>
</progresstemplate>
    </asp:UpdateProgress><br />
</div>
</asp:Content>

