<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="RecAcPag.aspx.vb" Inherits="Declaraciones_AcuerdoPag_RecAcPag" title="Untitled Page" %>

<%@ Register Assembly="eWorld.UI, Version=2.0.6.2393, Culture=neutral, PublicKeyToken=24d65337282035f2"
    Namespace="eWorld.UI" TagPrefix="ew" %>
<%@ Register Assembly="ControlesWeb" Namespace="ControlesWeb" TagPrefix="cc1" %>
<%@ Register Src="../../CtrlUsr/Terceros/ConsultaTer.ascx" TagName="ConsultaTer" TagPrefix="uc1" %>
<%@ Register Assembly="Microsoft.ReportViewer.WebForms, Version=10.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a"
    Namespace="Microsoft.Reporting.WebForms" TagPrefix="rsweb" %>
<asp:Content ID="Content1" ContentPlaceHolderID="SampleContent" Runat="Server">

<div class="demoarea">

<script type='text/javascript'>
    function cancelClick() {
        var label = $get('ctl00_SampleContent_LbRpt');
        //label.innerHTML = 'You hit cancel in the Confirm dialog on ' + (new Date()).localeFormat("T") + '.';
    }
        // Add click handlers for buttons to show and hide modal popup on pageLoad
        function pageLoad() {
            $addHandler($get("BtnCerrar3"), 'click', hideModalPopupViaClient3);
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
        
         function hideModalPopupViaClient3(ev) {
            ev.preventDefault();        
            var modalPopupBehavior = $find('programmaticModalPopupBehavior3');
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

    &nbsp;<asp:Label ID="Tit" runat="server" CssClass="Titulo" Text="RECIBOS OFICIALES DE PAGOS -  ACUERDOS DE PAGO"></asp:Label>
    <asp:ScriptManager id="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <asp:UpdatePanel id="UpdatePanel1" runat="server" UpdateMode="Conditional">
        <contenttemplate>
&nbsp;<asp:Label id="MsgResult" runat="server" Width="90%" Height="30px" __designer:wfdid="w77"></asp:Label>&nbsp; <BR /><TABLE width=600><TBODY><TR><TD style="HEIGHT: 13px" class="TDNegroFila"><asp:Label id="Label10" runat="server" Font-Bold="True" Text="AGENTE RECAUDADOR" __designer:wfdid="w78"></asp:Label> &nbsp; <asp:Button style="DISPLAY: none" id="button" runat="server" __designer:wfdid="w79"></asp:Button></TD></TR><TR><TD><TABLE width="100%"><TBODY><TR onmouseover="Resaltar_On(this);" onmouseout="Resaltar_Off(this);">
                <TD style="WIDTH: 26px; HEIGHT: 15px">
                    <asp:Label ID="Label45" runat="server" __designer:wfdid="w80" 
                        CssClass="TitDecl" Font-Bold="True" Text="IDENTIFICACIÓN" Width="115px"></asp:Label>
                </TD>
                <td style="WIDTH: 29px; HEIGHT: 15px">
                    <asp:Label ID="Label2" runat="server" __designer:wfdid="w81" CssClass="TitDecl" 
                        Font-Bold="True" Text="DV"></asp:Label>
                </td>
                <td style="WIDTH: 29px; HEIGHT: 15px">
                    &nbsp;</td>
                <TD style="WIDTH: 131px; HEIGHT: 15px"><asp:Label id="Label11" runat="server" Font-Bold="True" Text="RAZON SOCIAL" __designer:wfdid="w82" CssClass="TitDecl"></asp:Label></TD><TD style="WIDTH: 253px; HEIGHT: 15px"></TD></TR><TR onmouseover="Resaltar_On(this);" onmouseout="Resaltar_Off(this);">
                <TD style="WIDTH: 26px; HEIGHT: 19px"><asp:TextBox id="Nit" runat="server" 
                        __designer:wfdid="w83" Enabled="False"></asp:TextBox></TD>
                <td style="WIDTH: 29px; HEIGHT: 19px">
                    <asp:TextBox ID="Dv" runat="server" __designer:wfdid="w84" Enabled="False" 
                        Width="17px"></asp:TextBox>
                </td>
                <td style="WIDTH: 29px; HEIGHT: 19px">
                    <asp:Button ID="BtnBuscDP" runat="server" __designer:wfdid="w85" accessKey="B" 
                        onclick="BtnBuscDP_Click" Text="..." ToolTip="Buscar Agente Recaudador" 
                        UseSubmitBehavior="False" />
                </td>
                <TD style="HEIGHT: 19px" colSpan=2><asp:TextBox id="Agente" runat="server" Width="332px" __designer:wfdid="w86" Enabled="False"></asp:TextBox></TD></TR><TR onmouseover="Resaltar_On(this);" onmouseout="Resaltar_Off(this);">
                <TD style="HEIGHT: 19px" colSpan=5><asp:Label id="Label1" runat="server" Width="261px" Font-Bold="True" __designer:dtid="844424930132004" Text="SELECCIONE LA CLASE DE DECLARACION" __designer:wfdid="w87" CssClass="TitDecl"></asp:Label> <asp:DropDownList id="CbCdec" runat="server" __designer:dtid="844424930132007" __designer:wfdid="w88" AutoPostBack="True" DataSourceID="ObjCDec" DataTextField="CLD_NOM" DataValueField="CLD_COD"></asp:DropDownList></TD></TR></TBODY></TABLE></TD></TR></TBODY></TABLE><BR />
                <asp:GridView id="GridView1" runat="server" __designer:wfdid="w89" DataSourceID="ObjAcuerdos" OnRowCommand="GridView1_RowCommand" ShowFooter="True" DataKeyNames="numero" AutoGenerateColumns="False" AllowPaging="True"><Columns>
                    <asp:TemplateField HeaderText="No Auerdo" SortExpression="numero">
                        <ItemTemplate>
                            <asp:Label id="LbCod" runat="server" Text='<%# Bind("numero") %>'></asp:Label> 
                        </ItemTemplate>
                        <HeaderStyle HorizontalAlign="Left" />
                        <ItemStyle Width="100px" />
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Fec Reg" SortExpression="fecha_registro">
                        <ItemTemplate>
                                <asp:Label ID="LbNom" runat="server" Text='<%# Bind("fecha_registro", "{0:d}") %>'></asp:Label>
                        </ItemTemplate>
                        <HeaderStyle HorizontalAlign="Left" />
                        <ItemStyle Width="70px" />
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Valor" SortExpression="valor_">
                        <ItemTemplate>
                                <asp:Label ID="LbUni1" runat="server" Text='<%# Bind("valor_", "{0:c}") %>'></asp:Label>
                        </ItemTemplate>
                        <HeaderStyle HorizontalAlign="Right" />
                        <ItemStyle HorizontalAlign="Right" Width="120px" />
                    </asp:TemplateField>
<asp:TemplateField HeaderText="%Cuato In" SortExpression="porcentaje_cuo_ini"><ItemTemplate>
                                <asp:Label ID="LbUni2" runat="server" Text='<%# Bind("porcentaje_cuo_ini") %>'></asp:Label>
                            
</ItemTemplate>
    <HeaderStyle HorizontalAlign="Right" />
    <ItemStyle HorizontalAlign="Right" Width="70px" />
</asp:TemplateField>
<asp:TemplateField HeaderText="Valor Cuota In" SortExpression="valor_cuota_ini"><ItemTemplate>
                                <asp:Label ID="LbBar" runat="server" Text='<%# Bind("valor_cuota_ini", "{0:c}") %>'></asp:Label>
                            
</ItemTemplate>
    <HeaderStyle HorizontalAlign="Right" />
    <ItemStyle HorizontalAlign="Right" Width="120px" />
</asp:TemplateField>
<asp:TemplateField HeaderText="Saldo" SortExpression="saldo_acuerdo">
    <HeaderStyle HorizontalAlign="Right" />
    <ItemStyle HorizontalAlign="Right" Width="120px" />
                    </asp:TemplateField>
<asp:TemplateField><ItemTemplate>
        <asp:ImageButton CommandName="Seleccionar" CommandArgument='<%#Convert.ToInt32(DataBinder.Eval(Container, "DataItemIndex"))%>' 
        id="BtnSel" runat="server" ImageUrl="~/images/Operaciones/Select.png" tooltip="Seleccionar"></asp:ImageButton>
    
</ItemTemplate>
</asp:TemplateField>
</Columns>
<EmptyDataTemplate>
<BR /><asp:Label id="Label1" runat="server" Text="No se encontraron registros" CssClass="NoData" Width="166px"></asp:Label>
</EmptyDataTemplate>
</asp:GridView><asp:ObjectDataSource id="ObjAcuerdos" runat="server" __designer:wfdid="w90" OldValuesParameterFormatString="original_{0}" TypeName="AcuerdosP" SelectMethod="GetAcuerdosActivos"><SelectParameters>
<asp:ControlParameter ControlID="Nit" PropertyName="Text" Name="Car_Nit" Type="String"></asp:ControlParameter>
<asp:ControlParameter ControlID="CbCdec" PropertyName="SelectedValue" Name="Car_Cdec" Type="String"></asp:ControlParameter>
</SelectParameters>
</asp:ObjectDataSource><asp:ObjectDataSource id="ObjCDec" runat="server" __designer:dtid="12666373951979536" __designer:wfdid="w92" OldValuesParameterFormatString="original_{0}" TypeName="CDeclaraciones" SelectMethod="GetCDEC_PorNit">
        <SelectParameters __designer:dtid="12666373951979537">
            <asp:ControlParameter __designer:dtid="12666373951979538" ControlID="Nit" Name="Nit" PropertyName="Text" Type="String"  />
        </SelectParameters>
    </asp:ObjectDataSource><BR /><BR /><asp:MultiView id="MultiView1" runat="server" __designer:wfdid="w94" ActiveViewIndex="1"><asp:View id="View1" runat="server" __designer:wfdid="w95">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 
    <asp:GridView id="GridView2" runat="server"  DataSourceID="ObjCuotas" ShowFooter="True" AutoGenerateColumns="False" AllowPaging="True">
    <Columns>
        <asp:TemplateField HeaderText="No Cuota" SortExpression="cupa_cunu">
        <ItemTemplate>
            <asp:Label id="LbCod" runat="server" Text='<%# Bind("cuap_cunu") %>'></asp:Label> 
        </ItemTemplate>
        <HeaderStyle HorizontalAlign="Left" />
        <ItemStyle Width="100px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Valor Cuota" SortExpression="cuap_valo">
        <ItemTemplate>
            <asp:Label ID="LbNom" runat="server" Text='<%# Bind("cuap_valo", "{0:c}") %>'></asp:Label>
        </ItemTemplate>
        <HeaderStyle HorizontalAlign="Right" />
        <ItemStyle HorizontalAlign="Right" Width="120px" />
    </asp:TemplateField>
    <asp:TemplateField HeaderText="Fecha a Pagar" SortExpression="cuap_fepa">
    <ItemTemplate>
            <asp:Label ID="LbUni1" runat="server" Text='<%# Bind("cuap_fepa", "{0:d}") %>'></asp:Label>
    </ItemTemplate>
    <HeaderStyle HorizontalAlign="Right" />
    <ItemStyle HorizontalAlign="Right" Width="100px" />
    </asp:TemplateField>
    <asp:TemplateField HeaderText="Valor Pagado" SortExpression="cuap_pago">
    <ItemTemplate>
            <asp:Label ID="LbUni2" runat="server" Text='<%# Bind("cuap_pago", "{0:c}") %>'></asp:Label>
    </ItemTemplate>
    <HeaderStyle HorizontalAlign="Right" />
    <ItemStyle HorizontalAlign="Right" Width="120px" />
    </asp:TemplateField>
<asp:TemplateField><ItemTemplate>
        <asp:ImageButton CommandName="Seleccionar" CommandArgument='<%#Convert.ToInt32(DataBinder.Eval(Container, "DataItemIndex"))%>' 
        id="BtnSel" runat="server" ImageUrl="~/images/Operaciones/Select.png" tooltip="Seleccionar"></asp:ImageButton>
    
</ItemTemplate>
</asp:TemplateField>
</Columns>
<EmptyDataTemplate>
<BR /><asp:Label id="Label1" runat="server" Text="No se encontraron registros" CssClass="NoData" Width="166px"></asp:Label>
</EmptyDataTemplate>
</asp:GridView> <asp:ObjectDataSource id="ObjCuotas" runat="server" __designer:wfdid="w90" OldValuesParameterFormatString="original_{0}" TypeName="AcuerdosP" SelectMethod="GetCuotas"><SelectParameters>
<asp:ControlParameter ControlID="GridView1" PropertyName="SelectedValue" Name="cuap_apnu" Type="String"></asp:ControlParameter>
</SelectParameters>
</asp:ObjectDataSource></asp:View>&nbsp;&nbsp; <asp:View id="View2" runat="server" __designer:wfdid="w123"><rsweb:ReportViewer id="ReportViewer1" runat="server" Height="73px" __designer:wfdid="w207"></rsweb:ReportViewer></asp:View></asp:MultiView> <asp:HiddenField id="HdNroAcu" runat="server" __designer:dtid="10977524091715593" __designer:wfdid="w208"></asp:HiddenField> <asp:HiddenField id="HdVPag" runat="server" __designer:dtid="10977524091715595" __designer:wfdid="w209"></asp:HiddenField><BR /><asp:HiddenField id="HdNoAcu" runat="server" __designer:wfdid="w210"></asp:HiddenField> 
</contenttemplate>
        <triggers>
<asp:AsyncPostBackTrigger ControlID="Button" EventName="Click"></asp:AsyncPostBackTrigger>
</triggers>
    </asp:UpdatePanel>&nbsp;&nbsp;&nbsp;<asp:Button ID="BTNPAGCUO" runat="server" Text="Recibo de Pago" />&nbsp;
    <asp:UpdatePanel id="UpdatePanel2" runat="server" UpdateMode="Conditional"><contenttemplate>
<!-- Mensaje de Salida--><asp:Button style="DISPLAY: none" id="hiddenTargetControlForModalPopup" runat="server"></asp:Button> <ajaxToolkit:ModalPopupExtender id="ModalPopup" runat="server" TargetControlID="hiddenTargetControlForModalPopup" RepositionMode="RepositionOnWindowScroll" PopupDragHandleControlID="programmaticPopupDragHandle" PopupControlID="programmaticPopup" DropShadow="True" BehaviorID="programmaticModalPopupBehavior" BackgroundCssClass="modalBackground">
            </ajaxToolkit:ModalPopupExtender> <asp:Panel id="programmaticPopup" runat="server" Width="625px" Height="229%" CssClass="ModalPanel2"><asp:Panel id="programmaticPopupDragHandle" runat="Server" Height="30px" CssClass="BarTitleModal2"><DIV style="PADDING-RIGHT: 5px; PADDING-LEFT: 5px; PADDING-BOTTOM: 5px; VERTICAL-ALIGN: middle; PADDING-TOP: 5px"><DIV style="FLOAT: left">Buscar Agente Recaudador </DIV> <DIV style="FLOAT: right"><INPUT id="hideModalPopupViaClientButton" type=button value="X" /></DIV></DIV></asp:Panel> &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;<BR />&nbsp; &nbsp; &nbsp;&nbsp; <uc1:consultater id="ConsultaTer1" runat="server" tipo="AR" ret="AR"></uc1:consultater> <BR /><BR /><BR /></asp:Panel> 
</contenttemplate>
        <triggers>
<asp:AsyncPostBackTrigger ControlID="BtnBuscDP" EventName="Click"></asp:AsyncPostBackTrigger>
</triggers>
    </asp:UpdatePanel>
    <asp:UpdatePanel id="UpdatePanel3" runat="server">
        <contenttemplate>
<asp:Button style="DISPLAY: none" id="hiddenTargetControlForModalPopup3" runat="server" __designer:wfdid="w193"></asp:Button> <ajaxToolkit:ModalPopupExtender id="ModalPopupTer3" runat="server" __designer:wfdid="w194" BackgroundCssClass="modalBackground" BehaviorID="programmaticModalPopupBehavior3" DropShadow="True" PopupControlID="programmaticPopup3" PopupDragHandleControlID="programmaticPopupDragHandle3" RepositionMode="RepositionOnWindowScroll" TargetControlID="hiddenTargetControlForModalPopup3"></ajaxToolkit:ModalPopupExtender> <asp:Panel id="programmaticPopup3" runat="server" Width="350px" Height="346%" __designer:wfdid="w195" CssClass="ModalPanel2"><asp:Panel id="programmaticPopupDragHandle3" runat="Server" Width="347px" Height="30px" __designer:wfdid="w148" CssClass="BarTitleModal2"><DIV style="PADDING-RIGHT: 5px; PADDING-LEFT: 5px; PADDING-BOTTOM: 5px; VERTICAL-ALIGN: middle; PADDING-TOP: 5px"><DIV style="FLOAT: left">Digite Valor a Pagar</DIV><DIV style="FLOAT: right"><INPUT id="BtnCerrar3" type=button value="X" /></DIV></DIV></asp:Panel>&nbsp;<TABLE><TBODY>
        <TR><TD style="WIDTH: 85px" colSpan=1></TD><TD colSpan=3>Valor a Pagar</TD><TD colSpan=1></TD></TR><TR>
        <TD style="WIDTH: 85px; HEIGHT: 23px" colSpan=1>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; </TD>
        <TD style="HEIGHT: 23px" colSpan=3><ew:NumericBox id="TXTVP" runat="server" Width="152px" __designer:wfdid="w151"></ew:NumericBox></TD>
        <TD style="WIDTH: 100px; HEIGHT: 23px"></TD></TR>
        <TR><TD style="WIDTH: 85px; HEIGHT: 22px; TEXT-ALIGN: center" colSpan=1></TD><TD style="HEIGHT: 22px; TEXT-ALIGN: center" colSpan=3><asp:Button id="BTNGPDF" runat="server" Width="170px" Text="Generar Recibo de Pago" __designer:wfdid="w152"></asp:Button></TD><TD style="HEIGHT: 22px; TEXT-ALIGN: center" colSpan=1></TD></TR></TBODY></TABLE></asp:Panel>&nbsp; 
</contenttemplate>
        <triggers>
<asp:PostBackTrigger ControlID="BTNGPDF"></asp:PostBackTrigger>
</triggers>
    </asp:UpdatePanel><br />
    <br />
    <br />
  
</div> 

</asp:Content>

 