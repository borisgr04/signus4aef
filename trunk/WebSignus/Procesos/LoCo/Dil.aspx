<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="Dil.aspx.vb" Inherits="Procesos_LoCa_Dil" title="Untitled Page" %>
<%@ Register Src="../../CtrlUsr/Terceros/ConsultaTer.ascx" TagName="ConsultaTer" TagPrefix="uc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="SampleContent" Runat="Server">
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
<asp:Label id="MsgResult" runat="server" __designer:wfdid="w2"></asp:Label><BR /><TABLE width=600 __designer:dtid="844424930131979"><TBODY><TR __designer:dtid="844424930131980"><TD style="HEIGHT: 13px" class="TDNegroFila" __designer:dtid="844424930131981"><asp:Label id="Label10" runat="server" Font-Bold="True" Text="AGENTE RECAUDADOR" __designer:dtid="844424930131982" __designer:wfdid="w13"></asp:Label>&nbsp;&nbsp; <asp:Button style="DISPLAY: none" id="button" onclick="button_Click" runat="server" __designer:dtid="3096246218653697" __designer:wfdid="w14"></asp:Button></TD></TR><TR __designer:dtid="844424930131984"><TD __designer:dtid="844424930131985"><TABLE width="100%" __designer:dtid="844424930131986"><TBODY><TR onmouseover="Resaltar_On(this);" onmouseout="Resaltar_Off(this);" __designer:dtid="844424930131987"><TD style="WIDTH: 25px; HEIGHT: 15px" __designer:dtid="844424930131988"><asp:Label id="Label45" runat="server" Width="115px" Font-Bold="True" Text="IDENTIFICACIÓN" __designer:dtid="844424930131989" __designer:wfdid="w15" CssClass="TitDecl"></asp:Label></TD><TD style="WIDTH: 51px; HEIGHT: 15px" __designer:dtid="844424930131990">&nbsp;<asp:Label id="Label2" runat="server" Font-Bold="True" Text="DV" __designer:dtid="844424930131991" __designer:wfdid="w16" CssClass="TitDecl"></asp:Label> </TD><TD style="WIDTH: 131px; HEIGHT: 15px" __designer:dtid="844424930131992"><asp:Label id="Label11" runat="server" Font-Bold="True" Text="RAZON SOCIAL" __designer:dtid="844424930131993" __designer:wfdid="w17" CssClass="TitDecl"></asp:Label></TD><TD style="WIDTH: 253px; HEIGHT: 15px" __designer:dtid="844424930131994"></TD></TR><TR onmouseover="Resaltar_On(this);" onmouseout="Resaltar_Off(this);" __designer:dtid="844424930131995"><TD style="HEIGHT: 19px; TEXT-ALIGN: right" __designer:dtid="844424930131996"><asp:TextBox id="Nit" runat="server" __designer:dtid="844424930131997" __designer:wfdid="w18" Enabled="False"></asp:TextBox>&nbsp; </TD><TD style="WIDTH: 51px; HEIGHT: 19px" __designer:dtid="844424930131998">-<asp:TextBox id="Dv" runat="server" Width="17px" __designer:dtid="844424930131999" __designer:wfdid="w19" Enabled="False"></asp:TextBox>&nbsp;<asp:Button accessKey="B" id="BtnBuscDP" onclick="BtnBuscar_Click" runat="server" Text="..." __designer:wfdid="w20" ToolTip="Buscar Agente Recaudador" UseSubmitBehavior="False"></asp:Button></TD><TD style="HEIGHT: 19px" colSpan=2 __designer:dtid="844424930132000"><asp:TextBox id="Agente" runat="server" Width="332px" __designer:dtid="844424930132001" __designer:wfdid="w21" Enabled="False"></asp:TextBox></TD></TR><TR onmouseover="Resaltar_On(this);" onmouseout="Resaltar_Off(this);"><TD style="HEIGHT: 19px" colSpan=4>&nbsp;</TD></TR><TR onmouseover="Resaltar_On(this);" onmouseout="Resaltar_On(this);" __designer:dtid="844424930132002"><TD style="HEIGHT: 19px" colSpan=4 __designer:dtid="844424930132003"><asp:Label id="Label1" runat="server" Width="261px" Font-Bold="True" Text="SELECCIONE LA CLASE DE DECLARACION" __designer:dtid="844424930132004" __designer:wfdid="w22" CssClass="TitDecl"></asp:Label> <asp:DropDownList id="CbCdec" runat="server" __designer:dtid="844424930132007" __designer:wfdid="w23" AutoPostBack="True" DataSourceID="ObjCDec" DataTextField="CLD_NOM" DataValueField="CLD_COD"></asp:DropDownList></TD></TR><TR onmouseover="Resaltar_On(this);" onmouseout="Resaltar_Off(this);" __designer:dtid="844424930132005"><TD style="HEIGHT: 19px" colSpan=4 __designer:dtid="844424930132006"></TD></TR></TBODY></TABLE></TD></TR></TBODY></TABLE><BR /><TABLE width="100%"><TBODY><TR onmouseover="Resaltar_On(this);" class="TbDecl" onmouseout="Resaltar_Off(this);"><TD colSpan=6><asp:Label id="LbI" runat="server" Font-Bold="True" Text="PERIODO DE DECLARACION Y TIPO DE DECLARACIÓN"></asp:Label>&nbsp;</TD></TR><TR onmouseover="Resaltar_On(this);" onmouseout="Resaltar_Off(this);"><TD style="WIDTH: 7px"></TD><TD style="WIDTH: 100px"><asp:Label id="Label14" runat="server" Text="AÑO GRAVABLE" CssClass="TitDecl"></asp:Label></TD><TD style="WIDTH: 100px"><asp:DropDownList id="CboVigencia" runat="server" AutoPostBack="True" DataSourceID="ObjCalVigencias" DataTextField="cal_vig" DataValueField="cal_vig">
                    </asp:DropDownList></TD><TD style="WIDTH: 8px"></TD><TD style="WIDTH: 100px"><asp:Label id="Label13" runat="server" Width="133px" Text="PERIODO GRAVABLE" CssClass="TitDecl"></asp:Label></TD><TD style="WIDTH: 100px"><asp:DropDownList id="Periodo" runat="server" AutoPostBack="True" DataSourceID="ObjCal" DataTextField="cal_des" DataValueField="cal_per"></asp:DropDownList></TD></TR><TR onmouseover="Resaltar_On(this);" onmouseout="Resaltar_Off(this);"><TD style="WIDTH: 7px"></TD><TD style="WIDTH: 100px"></TD><TD style="WIDTH: 100px"></TD><TD style="WIDTH: 8px"></TD><TD style="WIDTH: 100px"></TD><TD style="WIDTH: 100px"></TD></TR></TBODY></TABLE>
</contenttemplate>
                    </asp:UpdatePanel><asp:Button ID="BtnDil" runat="server" Text="Diligenciar Liquidación" /><br />
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
    </asp:UpdatePanel>
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

<asp:HiddenField ID="Cla_Dec" runat="server" Value="01" /><asp:HiddenField ID="HdFODE" runat="server" Value="01" />
    <asp:HiddenField ID="HdTAG" runat="server" Value="01" />

    <asp:ObjectDataSource ID="ObjCDec" runat="server" OldValuesParameterFormatString="original_{0}"
        SelectMethod="GetCDEC_PorNit" TypeName="CDeclaraciones">
        <SelectParameters>
            <asp:ControlParameter ControlID="Nit" Name="Nit" PropertyName="Text" Type="String" />
        </SelectParameters>
    </asp:ObjectDataSource>
</asp:Content>

