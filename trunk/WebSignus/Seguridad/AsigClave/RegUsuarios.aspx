<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false"
    CodeFile="RegUsuarios.aspx.vb" Inherits="Seguridad_RegUsuarios" Title="Untitled Page"  UICulture="auto" Culture="auto"%>
<%@ Register Src="../../CtrlUsr/Terceros/ConsultaTer.ascx" TagName="ConsultaTer" TagPrefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="SampleContent" runat="Server">

    <script type='text/javascript'>
    function cancelClick() {
        var label = $get('ctl00_SampleContent_LbRpt');
        //label.innerHTML = 'You hit cancel in the Confirm dialog on ' + (new Date()).localeFormat("T") + '.';
    }
        // Add click handlers for buttons to show and hide modal popup on pageLoad
        function pageLoad() {
            //$addHandler($get("showModalPopupClientButton"), 'click', showModalPopupViaClient);
            $addHandler($get("hideModalPopupViaClientButton"), 'click', hideModalPopupViaClient);        
            $addHandler($get("BtnCerrar"), 'click', CerrarModalTercero);        
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
        
        function CerrarModalTercero(ev) {
            ev.preventDefault();        
            var modalPopupBehavior2 = $find('programmaticModalPopupBehavior2');
            modalPopupBehavior2.hide();
        }
        
        function ValidarUser()
        {
        __doPostBack("<%= BtnBuscarUser.ClientID %>","");
        }
          function enviar(tdoc,ced,dv,rsocial,tip_ter)
            {
                document.aspnetForm.<%=Me.TxtUsername.ClientID%>.value=ced;
                document.aspnetForm.<%=Me.TxtRazSoc.ClientID%>.value=rsocial;
                var modalPopupBehavior2 = $find('programmaticModalPopupBehavior2');
                modalPopupBehavior2.hide();
            }
            //__doPostBack("= button.ClientID %>","");
            //__doPostBack("= CbCdec.ClientID %>","");
            
            
        
        
    </script>
    

    <ajaxToolkit:ToolkitScriptManager ID="ScriptManager1" runat="Server" EnableScriptGlobalization="true"
        EnableScriptLocalization="true">
    </ajaxToolkit:ToolkitScriptManager>
    <div class="demoarea">
        
        <asp:UpdatePanel id="UpdatePanel1" runat="server">
            <contenttemplate>
<TABLE style="WIDTH: 603px" cellPadding=2><TBODY><TR><TD colSpan=3><asp:Label id="LbRpt" runat="server" __designer:wfdid="w62"></asp:Label></TD></TR><TR><TD colSpan=3><asp:Label id="msgResult" runat="server" Width="100%" Height="30px" __designer:wfdid="w63" Visible="False" Text="Label"></asp:Label><BR /><asp:ValidationSummary id="ValidationSummary1" runat="server" __designer:wfdid="w64"></asp:ValidationSummary></TD></TR><TR><TD class="demoheading" colSpan=3>REGISTRO DE CONTRASEÑA DE USUARIOS</TD></TR><TR><TD colSpan=3>Digite el Numero de identifación del Usuario o Busquelo Haciendo clik en el Boton Buscar</TD></TR><TR><TD style="WIDTH: 84px"><asp:Label id="Label1" runat="server" __designer:wfdid="w65" Text="Usuario"></asp:Label></TD><TD colSpan=2><asp:TextBox id="TxtUsername" runat="server" Width="150px" __designer:wfdid="w66"></asp:TextBox>&nbsp; <asp:ImageButton id="ImageButton1" onclick="ImageButton1_Click" runat="server" ImageUrl="~/images/Operaciones/Find1.png" __designer:wfdid="w67" ToolTip="Boton Buscar" ValidationGroup="BusTer"></asp:ImageButton> <asp:RequiredFieldValidator id="RequiredFieldValidator1" runat="server" __designer:wfdid="w68" ControlToValidate="TxtUsername" ErrorMessage="Seleccione un Tercero">*</asp:RequiredFieldValidator> <asp:CustomValidator id="CustomValidator1" runat="server" __designer:wfdid="w69" ControlToValidate="TxtUsername" ErrorMessage="El Usuario ya Existe" OnServerValidate="Validar_Usuario">*</asp:CustomValidator> <asp:TextBox id="TxtRazSoc" runat="server" Width="223px" __designer:wfdid="w70" Enabled="False"></asp:TextBox> </TD></TR><TR><TD style="WIDTH: 84px"><asp:Label id="Label2" runat="server" __designer:wfdid="w71" Text="Contraseña"></asp:Label></TD><TD colSpan=2><asp:TextBox id="TxtClave" runat="server" Width="150" __designer:wfdid="w72" TextMode="Password" autocomplete="off"></asp:TextBox><asp:RequiredFieldValidator id="RequiredFieldValidator2" runat="server" __designer:wfdid="w73" ControlToValidate="TxtClave" ErrorMessage="Digite Contraseña">*</asp:RequiredFieldValidator> <BR /><asp:Label id="TxtClave_HelpLabel" runat="server" __designer:wfdid="w74"></asp:Label></TD></TR><TR><TD style="WIDTH: 84px"><asp:Label id="Label3" runat="server" Width="119px" __designer:wfdid="w75" Text="Confirmar Contraseña"></asp:Label></TD><TD colSpan=2><asp:TextBox id="TxtClave2" runat="server" Width="150" __designer:wfdid="w76" TextMode="Password" autocomplete="off"></asp:TextBox><asp:RequiredFieldValidator id="RequiredFieldValidator3" runat="server" __designer:wfdid="w77" ControlToValidate="TxtClave2" ErrorMessage="Confirme su Contraseña">*</asp:RequiredFieldValidator> <asp:CompareValidator id="CompareValidator1" runat="server" Width="13px" __designer:wfdid="w78" ControlToValidate="TxtClave2" ErrorMessage="Contraseñas deben Coincidir" ControlToCompare="TxtClave">*</asp:CompareValidator> <asp:Label id="TxtClave2_HelpLabel" runat="server" __designer:wfdid="w79"></asp:Label></TD></TR><TR><TD style="WIDTH: 84px"></TD><TD style="WIDTH: 89px"><asp:Button id="cmdEnviar" onclick="cmdEnviar_Click" runat="server" __designer:wfdid="w87" Text="Guardar"></asp:Button></TD><TD style="WIDTH: 237px"></TD></TR><TR><TD colSpan=3>&nbsp;<asp:Button style="DISPLAY: none" id="BtnBuscarUser" onclick="BtnBuscarUser_Click" runat="server" __designer:wfdid="w88" CausesValidation="False"></asp:Button></TD></TR></TBODY></TABLE><ajaxToolkit:PasswordStrength id="PasswordStrength2" runat="server" __designer:wfdid="w89" BarBorderCssClass="BarBorder_TextBox2" DisplayPosition="RightSide" StrengthIndicatorType="BarIndicator" PreferredPasswordLength="8" HelpStatusLabelID="TxtClave_HelpLabel" TextStrengthDescriptions="Very Poor;Weak;Average;Strong;Excellent" StrengthStyles="BarIndicator_TextBox2_weak;BarIndicator_TextBox2_average;BarIndicator_TextBox2_good" MinimumNumericCharacters="1" MinimumSymbolCharacters="1" RequiresUpperAndLowerCaseCharacters="false" TargetControlID="TxtClave"></ajaxToolkit:PasswordStrength> <ajaxToolkit:PasswordStrength id="PasswordStrength1" runat="server" __designer:wfdid="w90" BarBorderCssClass="BarBorder_TextBox2" DisplayPosition="RightSide" StrengthIndicatorType="BarIndicator" PreferredPasswordLength="8" HelpStatusLabelID="TxtClave2_HelpLabel" TextStrengthDescriptions="Very Poor;Weak;Average;Strong;Excellent" StrengthStyles="BarIndicator_TextBox2_weak;BarIndicator_TextBox2_average;BarIndicator_TextBox2_good" MinimumNumericCharacters="1" MinimumSymbolCharacters="1" RequiresUpperAndLowerCaseCharacters="true" TargetControlID="TxtClave2">
    </ajaxToolkit:PasswordStrength>&nbsp;<BR /><!-- Panel Modal Confirmar Button--><!-- Confirmar  --><ajaxToolkit:ConfirmButtonExtender id="ConfirmButtonExtender3" runat="server" __designer:wfdid="w91" TargetControlID="cmdEnviar" DisplayModalPopupID="ModalPopupExtender2" OnClientCancel="cancelClick">

                </ajaxToolkit:ConfirmButtonExtender> <!-- Extender--><ajaxToolkit:ModalPopupExtender id="ModalPopupExtender2" runat="server" __designer:wfdid="w92" TargetControlID="cmdEnviar" BackgroundCssClass="modalBackground" CancelControlID="BtnCancelar" DropShadow="true" OkControlID="BtnAceptar" PopupControlID="PNL1" PopupDragHandleControlID="PnlTitle"></ajaxToolkit:ModalPopupExtender> <!-- Modal--><asp:Panel id="PNL1" runat="server" Width="410px" Height="155px" __designer:wfdid="w93" CssClass="ModalPanel2"><asp:Panel id="PnlTitle" runat="server" Height="30px" __designer:wfdid="w94" CssClass="BarTitleModal2"> 
                    <div style="padding:5px; vertical-align: middle;">
                        <div style="float: left;">Registro de Usuarios</div>
                    </div>
                    </asp:Panel> &nbsp; &nbsp;&nbsp; <BR /><BR /><DIV style="TEXT-ALIGN: center"><asp:Label id="LbMsg" runat="server" Width="278px" Height="33px" __designer:wfdid="w95" Text="Desea Guardar el Registro?"></asp:Label><BR /><BR /><asp:Button id="BtnAceptar" runat="server" Width="62px" __designer:wfdid="w96" Text="Si"></asp:Button> &nbsp; <asp:Button id="BtnCancelar" runat="server" Width="62px" __designer:wfdid="w97" Text="No"></asp:Button> <BR /><BR /></DIV></asp:Panel> <!-- End Panel Modal --><!-- Mensaje de Salida--><asp:Button style="DISPLAY: none" id="hiddenTargetControlForModalPopup" runat="server" __designer:wfdid="w98"></asp:Button> <ajaxToolkit:ModalPopupExtender id="ModalPopup" runat="server" __designer:wfdid="w99" TargetControlID="hiddenTargetControlForModalPopup" BackgroundCssClass="modalBackground" DropShadow="True" PopupControlID="programmaticPopup" PopupDragHandleControlID="programmaticPopupDragHandle" RepositionMode="RepositionOnWindowScroll" BehaviorID="programmaticModalPopupBehavior">
            </ajaxToolkit:ModalPopupExtender> <asp:Panel id="programmaticPopup" runat="server" Width="404px" Height="135px" __designer:wfdid="w100" CssClass="ModalPanel2"><asp:Panel id="programmaticPopupDragHandle" runat="Server" Height="30px" __designer:wfdid="w101" CssClass="BarTitleModal2"><DIV style="PADDING-RIGHT: 5px; PADDING-LEFT: 5px; PADDING-BOTTOM: 5px; VERTICAL-ALIGN: middle; PADDING-TOP: 5px"><DIV style="FLOAT: left; WIDTH: 53px"><%=Me.TxtRazSoc.ClientID%></DIV></DIV></asp:Panel> <DIV style="TEXT-ALIGN: center"><BR /><asp:Image id="ImgRst" runat="server" ImageUrl="~/images/Error.gif" __designer:wfdid="w102"></asp:Image> <asp:Label id="MsgModalPanel" runat="server" Width="278px" Height="33px" __designer:wfdid="w103" Text="Mensaje de Salida"></asp:Label><BR /><BR /><INPUT id="hideModalPopupViaClientButton" type=button value="Aceptar" /> <BR /><BR /></DIV><BR /></asp:Panel> <!-- End Panel Modal -->
</contenttemplate>
            <triggers>
<asp:AsyncPostBackTrigger ControlID="ImageButton1" EventName="Click"></asp:AsyncPostBackTrigger>
</triggers>
        </asp:UpdatePanel>
        

<asp:UpdatePanel id="UpdatePanel2" runat="server" UpdateMode="Conditional"><contenttemplate>
<!-- Mensaje de Salida--><asp:Button style="DISPLAY: none" id="hiddenTargetControlForModalPopup2" runat="server" __designer:wfdid="w104"></asp:Button> <ajaxToolkit:ModalPopupExtender id="ModalPopupTer" runat="server" __designer:wfdid="w105" TargetControlID="hiddenTargetControlForModalPopup2" PopupDragHandleControlID="programmaticPopupDragHandle2" PopupControlID="programmaticPopup2" DropShadow="True" BackgroundCssClass="modalBackground" BehaviorID="programmaticModalPopupBehavior2" RepositionMode="RepositionOnWindowScroll">
            </ajaxToolkit:ModalPopupExtender> <asp:Panel id="programmaticPopup2" runat="server" Width="625px" Height="229%" __designer:wfdid="w106" CssClass="ModalPanel2"><asp:Panel id="programmaticPopupDragHandle2" runat="Server" Height="30px" __designer:wfdid="w107" CssClass="BarTitleModal2"><DIV style="PADDING-RIGHT: 5px; PADDING-LEFT: 5px; PADDING-BOTTOM: 5px; VERTICAL-ALIGN: middle; PADDING-TOP: 5px"><DIV style="FLOAT: left">Buscar Tercero</DIV><DIV style="FLOAT: right" __designer:dtid="21955056773365768"><INPUT id="BtnCerrar" type=button value="X" __designer:dtid="21955056773365769" /></DIV></DIV></asp:Panel> &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;<BR />&nbsp; &nbsp; &nbsp;&nbsp; <uc1:consultater id="ConsultaTer1" runat="server" __designer:wfdid="w108" ret="DD" tipo=""></uc1:consultater> <BR /><BR /><BR /></asp:Panel> 
</contenttemplate>
            <triggers>
<asp:AsyncPostBackTrigger ControlID="ImageButton1" EventName="Click"></asp:AsyncPostBackTrigger>
</triggers>
        </asp:UpdatePanel><br />
        &nbsp;&nbsp;<br />
        <br />
        
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
