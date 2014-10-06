<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="SelDec.aspx.vb" Inherits="Declaraciones_Diligenciar_SelDec" title="Untitled Page" EnableEventValidation="true" %>
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
            $addHandler($get("BtnClosePar"), 'click', CerrarModal3);
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
            
            
        }

 function CerrarModal3(ev) {
            ev.preventDefault();        
            var modalPopupBehavior2 = $find('programmaticModalPopupBehavior3');
            modalPopupBehavior2.hide();
          
        }
      
    </script>
<div class="demoarea">
 
<asp:Label ID="LBTITULO" runat="server" CssClass="Titulo"></asp:Label>&nbsp;
    <div class="DecHeader">

        
        
        <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional"   >
            <ContentTemplate>
&nbsp;<asp:Label id="MsgResult" runat="server" Width="90%" Height="30px" __designer:wfdid="w9"></asp:Label>&nbsp; <BR /><TABLE width=600 __designer:dtid="844424930131979"><TBODY><TR __designer:dtid="844424930131980"><TD style="HEIGHT: 13px" class="TDNegroFila" __designer:dtid="844424930131981"><asp:Label id="Label10" runat="server" Font-Bold="True" __designer:dtid="844424930131982" __designer:wfdid="w10" Text="AGENTE RECAUDADOR"></asp:Label>&nbsp;&nbsp; <asp:Button style="DISPLAY: none" id="button" runat="server" __designer:dtid="3096246218653697" __designer:wfdid="w198"></asp:Button></TD></TR><TR __designer:dtid="844424930131984"><TD __designer:dtid="844424930131985"><TABLE width="100%" __designer:dtid="844424930131986"><TBODY><TR onmouseover="Resaltar_On(this);" onmouseout="Resaltar_Off(this);" __designer:dtid="844424930131987"><TD style="WIDTH: 51px; HEIGHT: 15px" __designer:dtid="844424930131990">
                    <asp:Label ID="Label45" runat="server" __designer:dtid="844424930131989" 
                        __designer:wfdid="w12" CssClass="TitDecl" Font-Bold="True" 
                        Text="IDENTIFICACIÓN" Width="115px"></asp:Label>
                    </TD>
                    <td __designer:dtid="844424930131990" style="WIDTH: 51px; HEIGHT: 15px">
                        &nbsp;<asp:Label ID="Label2" runat="server" __designer:dtid="844424930131991" 
                            __designer:wfdid="w13" CssClass="TitDecl" Font-Bold="True" Text="DV"></asp:Label>
                    </td>
                    <TD style="WIDTH: 51px; HEIGHT: 15px" __designer:dtid="844424930131990">&nbsp;</TD>
                    <TD style="WIDTH: 131px; HEIGHT: 15px" __designer:dtid="844424930131992">
                        <asp:Label ID="Label11" runat="server" __designer:dtid="844424930131993" 
                            __designer:wfdid="w14" CssClass="TitDecl" Font-Bold="True" Text="RAZON SOCIAL"></asp:Label>
                    </TD>
                    <td __designer:dtid="844424930131994" style="WIDTH: 253px; HEIGHT: 15px">
                    </td>
                    </TR><TR onmouseover="Resaltar_On(this);" onmouseout="Resaltar_Off(this);" __designer:dtid="844424930131995"><TD style="WIDTH: 51px; HEIGHT: 19px" __designer:dtid="844424930131998">
                        <asp:TextBox id="Nit" runat="server" __designer:dtid="844424930131997" 
                            __designer:wfdid="w15" Enabled="False"></asp:TextBox></TD>
                        <td __designer:dtid="844424930131998" style="WIDTH: 51px; HEIGHT: 19px">
                            -<asp:TextBox ID="Dv" runat="server" __designer:dtid="844424930131999" 
                                __designer:wfdid="w16" Enabled="False" Width="17px"></asp:TextBox>
                            &nbsp;</td>
                        <TD style="HEIGHT: 19px; width: 51px;" __designer:dtid="844424930131998">
                            <asp:Button ID="BtnBuscDP" runat="server" __designer:wfdid="w2" accessKey="B" 
                                onclick="BtnBuscDP_Click" Text="..." ToolTip="Buscar Agente Recaudador" 
                                UseSubmitBehavior="False" />
                        </TD>
                        <td __designer:dtid="844424930132000" colspan="2" style="HEIGHT: 19px">
                            <asp:TextBox ID="Agente" runat="server" __designer:dtid="844424930132001" 
                                __designer:wfdid="w17" Enabled="False" Width="332px"></asp:TextBox>
                        </td>
                    </TR><TR onmouseover="Resaltar_On(this);" onmouseout="Resaltar_Off(this);">
                        <TD style="HEIGHT: 19px" colSpan=5>&nbsp;</TD></TR><TR onmouseover="Resaltar_On(this);" onmouseout="Resaltar_On(this);" __designer:dtid="844424930132002">
                    <TD style="HEIGHT: 19px" colSpan=5 __designer:dtid="844424930132003"><asp:Label id="Label1" runat="server" Width="261px" Font-Bold="True" __designer:dtid="844424930132004" CssClass="TitDecl" __designer:wfdid="w18" Text="SELECCIONE LA CLASE DE DECLARACION"></asp:Label> <asp:DropDownList id="CbCdec" runat="server" __designer:dtid="844424930132007" __designer:wfdid="w19" AutoPostBack="True" DataSourceID="ObjCDec" DataTextField="CLD_NOM" DataValueField="CLD_COD"></asp:DropDownList></TD></TR><TR onmouseover="Resaltar_On(this);" onmouseout="Resaltar_Off(this);" __designer:dtid="844424930132005">
                    <TD style="HEIGHT: 19px" colSpan=5 __designer:dtid="844424930132006"></TD></TR></TBODY></TABLE></TD></TR></TBODY></TABLE><BR /><TABLE width=600><TBODY><TR onmouseover="Resaltar_On(this);" class="TbDecl" onmouseout="Resaltar_Off(this);"><TD colSpan=6><asp:Label id="LbI" runat="server" Font-Bold="True" __designer:wfdid="w20" Text="PERIODO DE DECLARACION Y TIPO DE DECLARACIÓN"></asp:Label>&nbsp;</TD></TR><TR onmouseover="Resaltar_On(this);" onmouseout="Resaltar_Off(this);"><TD style="WIDTH: 7px"></TD><TD style="WIDTH: 100px"><asp:Label id="Label14" runat="server" CssClass="TitDecl" __designer:wfdid="w21" Text="AÑO GRAVABLE"></asp:Label></TD><TD style="WIDTH: 100px"><asp:DropDownList id="CboVigencia" runat="server" __designer:wfdid="w22" AutoPostBack="True" DataSourceID="ObjCalVigencias" DataTextField="cal_vig" DataValueField="cal_vig">
                    </asp:DropDownList></TD><TD style="WIDTH: 8px"></TD><TD style="WIDTH: 100px"><asp:Label id="Label13" runat="server" Width="133px" CssClass="TitDecl" __designer:wfdid="w23" Text="PERIODO GRAVABLE"></asp:Label></TD><TD style="WIDTH: 100px"><asp:DropDownList id="Periodo" runat="server" __designer:wfdid="w24" DataSourceID="ObjCal" DataTextField="cal_des" DataValueField="cal_per">
                    </asp:DropDownList></TD></TR><TR onmouseover="Resaltar_On(this);" onmouseout="Resaltar_Off(this);"><TD style="WIDTH: 7px"></TD><TD colSpan=2></TD><TD style="WIDTH: 8px"></TD><TD style="WIDTH: 100px"></TD><TD style="WIDTH: 100px"></TD></TR><TR onmouseover="Resaltar_On(this);" onmouseout="Resaltar_Off(this);"><TD style="WIDTH: 7px"></TD><TD style="TEXT-ALIGN: center" colSpan=5><asp:Button id="BtnDil" onclick="BtnDil_Click" runat="server" __designer:dtid="3659174697238605" __designer:wfdid="w1" Text="Generar Recibo"></asp:Button></TD></TR></TBODY></TABLE><asp:ObjectDataSource id="ObjCalVigencias" runat="server" __designer:dtid="844424930132090" TypeName="Calendario" SelectMethod="GetVigencias" OldValuesParameterFormatString="original_{0}" __designer:wfdid="w27"><SelectParameters __designer:dtid="844424930132091">
<asp:ControlParameter ControlID="CbCdec" PropertyName="SelectedValue" Name="Cla_Dec" Type="String" __designer:dtid="844424930132092"></asp:ControlParameter>
</SelectParameters>
</asp:ObjectDataSource><asp:ObjectDataSource id="ObjCal" runat="server" __designer:dtid="844424930132093" TypeName="Calendario" SelectMethod="GetPorClaseDec" OldValuesParameterFormatString="original_{0}" __designer:wfdid="w28"><SelectParameters __designer:dtid="844424930132094">
<asp:ControlParameter ControlID="CbCdec" PropertyName="SelectedValue" Name="Cla_Dec" Type="String" __designer:dtid="844424930132095"></asp:ControlParameter>
<asp:ControlParameter ControlID="CboVigencia" PropertyName="SelectedValue" Name="Vigencia" Type="String"></asp:ControlParameter>
</SelectParameters>
</asp:ObjectDataSource> <BR />
</ContentTemplate>
            <Triggers>
<asp:AsyncPostBackTrigger ControlID="CboVigencia" EventName="SelectedIndexChanged"></asp:AsyncPostBackTrigger>
<asp:AsyncPostBackTrigger ControlID="Button" EventName="Click"></asp:AsyncPostBackTrigger>
</Triggers>
        </asp:UpdatePanel>
        <asp:ObjectDataSource ID="ObjTDec" runat="server" SelectMethod="GetPorClaseDec" TypeName="Tipo_Dec">
            <SelectParameters>
                <asp:ControlParameter ControlID="Cla_Dec" Name="Cla_Dec" PropertyName="Value" Type="String" />
            </SelectParameters>
        </asp:ObjectDataSource>
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
        SelectMethod="GetCDEC_PorNit" TypeName="ReciboOf">
        <SelectParameters>
            <asp:ControlParameter ControlID="Nit" Name="Nit" PropertyName="Text" Type="String" />
        </SelectParameters>
    </asp:ObjectDataSource>
    <asp:UpdatePanel id="UpdatePanel2" runat="server" UpdateMode="Conditional">
        <contenttemplate>
<!-- Mensaje de Salida--><asp:Button style="DISPLAY: none" id="hiddenTargetControlForModalPopup" runat="server"></asp:Button> <ajaxToolkit:ModalPopupExtender id="ModalPopup" runat="server" TargetControlID="hiddenTargetControlForModalPopup" RepositionMode="RepositionOnWindowScroll" PopupDragHandleControlID="programmaticPopupDragHandle" PopupControlID="programmaticPopup" DropShadow="True" BehaviorID="programmaticModalPopupBehavior" BackgroundCssClass="modalBackground">
            </ajaxToolkit:ModalPopupExtender> <asp:Panel id="programmaticPopup" runat="server" Width="625px" Height="229%" CssClass="ModalPanel2"><asp:Panel id="programmaticPopupDragHandle" runat="Server" Height="30px" CssClass="BarTitleModal2"><DIV style="PADDING-RIGHT: 5px; PADDING-LEFT: 5px; PADDING-BOTTOM: 5px; VERTICAL-ALIGN: middle; PADDING-TOP: 5px"><DIV style="FLOAT: left">Buscar Agente Recaudador </DIV> <DIV style="FLOAT: right" __designer:dtid="1407383473487880"><INPUT id="hideModalPopupViaClientButton" type=button value="X" __designer:dtid="1407383473487881" /></DIV></DIV></asp:Panel> &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;<BR />&nbsp; &nbsp; &nbsp;&nbsp; <uc1:consultater id="ConsultaTer1" runat="server" tipo="AR" ret="AR"></uc1:consultater> <BR /><BR /><BR /></asp:Panel> 
</contenttemplate>
        <triggers>
<asp:AsyncPostBackTrigger ControlID="BtnBuscDP" EventName="Click"></asp:AsyncPostBackTrigger>

</triggers>
    </asp:UpdatePanel><br />
    
    
    <asp:UpdatePanel id="UpdatePanel3" runat="server">
        <contenttemplate>
<BR />&nbsp;<BR />&nbsp;<asp:Button style="DISPLAY: none" id="hiddenTargetControlForModalPopup3" runat="server"></asp:Button> <ajaxToolkit:ModalPopupExtender id="ModalPopupTer3" runat="server" BackgroundCssClass="modalBackground" BehaviorID="programmaticModalPopupBehavior3" DropShadow="True" PopupControlID="programmaticPopup3" PopupDragHandleControlID="programmaticPopupDragHandle3" RepositionMode="RepositionOnWindowScroll" TargetControlID="hiddenTargetControlForModalPopup3"></ajaxToolkit:ModalPopupExtender> <asp:Panel id="programmaticPopup3" runat="server" Width="367px" Height="277%" CssClass="ModalPanel2"><asp:Panel id="programmaticPopupDragHandle3" runat="Server" Height="30px" CssClass="BarTitleModal2"><DIV style="PADDING-RIGHT: 5px; PADDING-LEFT: 5px; PADDING-BOTTOM: 5px; VERTICAL-ALIGN: middle; PADDING-TOP: 5px"><DIV style="FLOAT: left">Mensaje</DIV><DIV style="FLOAT: right"><INPUT id="BtnClosePar" type=button value="X" /></DIV></DIV></asp:Panel> <asp:Image id="ImgRst" runat="server" ImageUrl="~/images/Error.gif"></asp:Image>&nbsp;&nbsp; &nbsp;<asp:Label id="MsgResult1" runat="server" Width="278px" Height="59px" ForeColor="Black"></asp:Label><BR /><BR /><BR /></asp:Panel>&nbsp; 
</contenttemplate>
    </asp:UpdatePanel><br />
    <br />
    <asp:UpdateProgress id="UpdateProgress1" runat="server" AssociatedUpdatePanelID="UpdatePanel1">
        <progresstemplate>
<DIV class="Loading"><IMG title="" alt="" src="../../images/loading.gif" /> Cargando … </DIV>
</progresstemplate>
    </asp:UpdateProgress>
    <br />
</div>
</asp:Content>

