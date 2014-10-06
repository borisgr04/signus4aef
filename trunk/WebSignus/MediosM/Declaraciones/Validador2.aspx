<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="Validador2.aspx.vb" Inherits="MediosM_Declaraciones_Validador2" title="Untitled Page" %>

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
    &nbsp;<asp:UpdatePanel id="UpdatePanel1" runat="server">
        <contenttemplate>
&nbsp;<asp:Label id="MsgResult" runat="server" __designer:wfdid="w11"></asp:Label>&nbsp; <BR /><TABLE width=500><TBODY><TR class="TbDecl"><TD style="HEIGHT: 13px" class="TDNegroFila"><asp:Label id="Label10" runat="server" Font-Bold="True" Text="AGENTE RECAUDADOR" __designer:wfdid="w12"></asp:Label>&nbsp;&nbsp; <asp:Button style="DISPLAY: none" id="button" onclick="button_Click" runat="server" __designer:wfdid="w14"></asp:Button></TD></TR><TR><TD><TABLE width="100%"><TBODY><TR onmouseover="Resaltar_On(this);" onmouseout="Resaltar_Off(this);"><TD style="WIDTH: 25px; HEIGHT: 15px"><asp:Label id="Label45" runat="server" Width="115px" Font-Bold="True" Text="IDENTIFICACIÓN" CssClass="TitDecl" __designer:wfdid="w15"></asp:Label></TD><TD style="WIDTH: 28px; HEIGHT: 15px">&nbsp;<asp:Label id="Label2" runat="server" Font-Bold="True" Text="DV" CssClass="TitDecl" __designer:wfdid="w16"></asp:Label> </TD><TD style="WIDTH: 28px; HEIGHT: 15px"></TD><TD style="WIDTH: 131px; HEIGHT: 15px"><asp:Label id="Label11" runat="server" Font-Bold="True" Text="RAZON SOCIAL" CssClass="TitDecl" __designer:wfdid="w17"></asp:Label></TD><TD style="WIDTH: 253px; HEIGHT: 15px"></TD></TR><TR onmouseover="Resaltar_On(this);" onmouseout="Resaltar_Off(this);"><TD style="HEIGHT: 19px; TEXT-ALIGN: right"><asp:TextBox id="Nit" runat="server" __designer:wfdid="w18" Enabled="False"></asp:TextBox> </TD><TD style="WIDTH: 28px; HEIGHT: 19px"><asp:TextBox id="Dv" runat="server" Width="17px" __designer:wfdid="w19" Enabled="False"></asp:TextBox></TD><TD style="WIDTH: 28px; HEIGHT: 19px"><asp:Button accessKey="B" id="BtnBuscDP" runat="server" Text="..." __designer:wfdid="w31" ToolTip="Buscar Agente Recaudador" UseSubmitBehavior="False" OnClick="BtnBuscDP_Click"></asp:Button></TD><TD style="HEIGHT: 19px" colSpan=2><asp:TextBox id="Agente" runat="server" Width="332px" __designer:wfdid="w20" Enabled="False"></asp:TextBox></TD></TR><TR onmouseover="Resaltar_On(this);" onmouseout="Resaltar_Off(this);"><TD style="HEIGHT: 19px" colSpan=5>&nbsp;</TD></TR><TR onmouseover="Resaltar_On(this);" onmouseout="Resaltar_On(this);"><TD style="HEIGHT: 19px" colSpan=5><asp:Label id="Label110" runat="server" Width="261px" Font-Bold="True" Text="SELECCIONE LA CLASE DE DECLARACION" CssClass="TitDecl" __designer:wfdid="w21"></asp:Label> <asp:DropDownList id="CbCdec" runat="server" DataValueField="CLD_COD" DataTextField="CLD_NOM" DataSourceID="ObjCDec" __designer:wfdid="w22" AutoPostBack="True"></asp:DropDownList></TD></TR><TR onmouseover="Resaltar_On(this);" onmouseout="Resaltar_Off(this);"><TD style="HEIGHT: 19px" colSpan=5></TD></TR></TBODY></TABLE></TD></TR></TBODY></TABLE><BR /><TABLE width=500><TBODY><TR onmouseover="Resaltar_On(this);" class="TbDecl" onmouseout="Resaltar_Off(this);"><TD colSpan=6><asp:Label id="LbI" runat="server" Font-Bold="True" Text="PERIODO DE DECLARACION Y TIPO DE DECLARACIÓN" __designer:wfdid="w23"></asp:Label>&nbsp;</TD></TR><TR onmouseover="Resaltar_On(this);" onmouseout="Resaltar_Off(this);"><TD style="WIDTH: 7px"></TD><TD style="WIDTH: 100px"><asp:Label id="Label14" runat="server" Text="AÑO GRAVABLE" CssClass="TitDecl" __designer:wfdid="w24"></asp:Label></TD><TD style="WIDTH: 100px"><asp:DropDownList id="CboVigencia" runat="server" DataValueField="cal_vig" DataTextField="cal_vig" DataSourceID="ObjCalVigencias" __designer:wfdid="w25" AutoPostBack="True">
                    </asp:DropDownList></TD><TD style="WIDTH: 8px"></TD><TD style="WIDTH: 100px"><asp:Label id="Label13" runat="server" Width="133px" Text="PERIODO GRAVABLE" CssClass="TitDecl" __designer:wfdid="w26"></asp:Label></TD><TD style="WIDTH: 100px"><asp:DropDownList id="Periodo" runat="server" DataValueField="cal_per" DataTextField="cal_des" DataSourceID="ObjCal" __designer:wfdid="w27">
                    </asp:DropDownList></TD></TR></TBODY></TABLE>
</contenttemplate>
        <triggers>
<asp:AsyncPostBackTrigger ControlID="CboVigencia" EventName="SelectedIndexChanged"></asp:AsyncPostBackTrigger>
<asp:AsyncPostBackTrigger ControlID="Button" EventName="Click"></asp:AsyncPostBackTrigger>
</triggers>
    </asp:UpdatePanel>
    &nbsp;<table style="width: 720px">
        <tr class="TbDecl">
            <td colspan="4" style="height: 23px">
                <asp:Label ID="LbIc" runat="server" CssClass="Decl" Font-Bold="True" Text="CARGAR Y VALIDAR ARCHIVO"></asp:Label>&nbsp;</td>
        </tr>
        <tr>
            <td style="width: 96px; height: 23px;">
                <asp:Label ID="Label16" runat="server" CssClass="TitDecl" Text="Formato de Importación"
                    Width="139px"></asp:Label></td>
            <td style="width: 131px; height: 23px;">
                <asp:Label ID="Label3" runat="server" CssClass="TitDecl" Text="Fecha de Presentación"
                    Width="116px"></asp:Label>
            </td>
            <td style="width: 100px; height: 23px;">
                &nbsp;<asp:Label ID="Label4" runat="server" CssClass="TitDecl" Text="Seleccione el Archivo"
                    Width="139px"></asp:Label></td>
            <td style="width: 126px; height: 23px">
                &nbsp;</td>
        </tr>
        <tr>
            <td style="width: 96px">
    <asp:DropDownList ID="CboFormatos" runat="server" DataSourceID="ObjFmtos" DataTextField="Fmto_Desc"
        DataValueField="Fmto_Codi">
    </asp:DropDownList></td>
            <td style="width: 131px">
    <asp:TextBox ID="TxtFecha" runat="server" Width="97px"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="TxtFecha"
                    ErrorMessage="*" ValidationGroup="Validar" Width="16px"></asp:RequiredFieldValidator></td>
            <td style="width: 100px">
                &nbsp;<asp:FileUpload ID="FileUpload1" runat="server" />
      <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="FileUpload1"
          ErrorMessage="*" ValidationGroup="Validar"></asp:RequiredFieldValidator></td>
            <td style="width: 126px">
      <asp:Button ID="BrnValidar" runat="server" Text="Validar" Width="111px" ValidationGroup="Validar" />
                <asp:Button ID="Button1" runat="server" Text="Validar2" Width="111px" ValidationGroup="Validar" /></td>
        </tr>
        <tr>
            <td style="width: 96px">
    <asp:Label ID="lblOculto" runat="server"></asp:Label></td>
            <td style="width: 131px">
                &nbsp;</td>
            <td style="width: 100px">
            </td>
            <td style="width: 126px">
            </td>
        </tr>
        <tr>
            <td colspan="4">
    <asp:Label ID="Label1" runat="server" Text=""></asp:Label></td>
        </tr>
        <tr>
            <td colspan="4" style="text-align: center">
      <asp:Button ID="BtnExcel" runat="server" OnClick="BtnExcel_Click" Text="Exportar Logs" Visible="False" /></td>
        </tr>
    </table>
  <div>
      <br />
      &nbsp;<asp:Label ID="Label5" runat="server" CssClass="Decl" Font-Bold="True" Text="Consolidado por Impuesto"></asp:Label>
    <asp:GridView ID="GridView2" runat="server" AutoGenerateColumns="true" ShowFooter="True">
    </asp:GridView>
      <br />
      <br />
    <cc1:GridViewS ID="GridViewS1" runat="server" CellPadding="4" ForeColor="#333333" 
        GridLines="None" Height="70px" HeightDesplegable="100%" Width="1000px" WidthDesplegable="700px">
        <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
        <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
        <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
        <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
        <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
        <EditRowStyle BackColor="#999999" />
        <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
    </cc1:GridViewS>
    &nbsp;&nbsp;
    <asp:HiddenField ID="NombreA" runat="server" />
                <ajaxToolkit:CalendarExtender ID="CalendarExtender1" runat="server" TargetControlID="TxtFecha">
                </ajaxToolkit:CalendarExtender>
                <asp:ObjectDataSource ID="ObjFmtos" runat="server" SelectMethod="GetFmtos" TypeName="BasesLiq">
                </asp:ObjectDataSource>
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
      &nbsp;<br />
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
    </asp:UpdatePanel><br />
</div>
</div>
</asp:Content>

