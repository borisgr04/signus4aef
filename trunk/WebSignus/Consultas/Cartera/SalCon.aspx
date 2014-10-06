<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="SalCon.aspx.vb" 
Inherits="Consultas_Cartera_SalCon" title="Untitled Page"
EnableEventValidation = "false"  %>
<%@ Register Src="../../CtrlUsr/Terceros/ConsultaTer.ascx" TagName="ConsultaTer" TagPrefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="SampleContent" Runat="Server">

<ajaxToolkit:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server" EnableScriptGlobalization="true"
        EnableScriptLocalization="true">
    </ajaxToolkit:ToolkitScriptManager>
    
<div class="demoarea">
    <div class="DecHeader">
        <div class="DecHeader">
            &nbsp;<asp:Label ID="LBTITULO" runat="server" CssClass="Titulo">CARTERA POR CONCEPTOS</asp:Label>
            <asp:UpdatePanel id="UpdatePanel1" runat="server">
                <contenttemplate>
<TABLE><TBODY><TR><TD colSpan=2><asp:Label id="LbClaseDec" runat="server" 
        Width="261px" Font-Bold="True" CssClass="TitDecl"  
        Text="SELECCIONE LA CLASE DE DECLARACION" Visible="False"></asp:Label></TD><TD style="WIDTH: 100px"><asp:Label id="Label1" runat="server" Width="151px" Font-Bold="True" CssClass="TitDecl" __designer:wfdid="w1" Text="FECHA INICIAL"></asp:Label></TD><TD style="WIDTH: 100px"><asp:Label id="Label2" runat="server" Width="151px" Font-Bold="True" CssClass="TitDecl" __designer:wfdid="w2" Text="FECHA FINAL"></asp:Label></TD>
    <td style="WIDTH: 100px">
        &nbsp;</td>
    </TR><TR><TD colSpan=2><asp:DropDownList id="CbCdec" runat="server" 
            __designer:wfdid="w107" DataSourceID="ObjCDec" AutoPostBack="True" 
            DataTextField="CLD_NOM" DataValueField="CLD_COD" Visible="False">
                            <asp:ListItem Value="00">Todos los Conceptos</asp:ListItem>
                            </asp:DropDownList></TD><TD style="WIDTH: 100px"><asp:TextBox id="TxtFI" runat="server" ></asp:TextBox></TD><TD style="WIDTH: 100px"><asp:TextBox id="TxtFF" runat="server" __designer:wfdid="w110"></asp:TextBox></TD>
        <td style="WIDTH: 100px">
            <asp:Button ID="BtnAct" runat="server" Text="Actualizar" />
        </td>
    </TR><TR><TD style="WIDTH: 100px"></TD><TD style="WIDTH: 100px"></TD><TD style="WIDTH: 100px"></TD><TD style="WIDTH: 100px"></TD>
        <td style="WIDTH: 100px">
            &nbsp;</td>
    </TR></TBODY></TABLE>&nbsp;<BR />Consulta Detallada por Periodo<asp:Button id="BtnExcel" onclick="BtnExcel_Click" runat="server" __designer:wfdid="w103" Text="Export Excel"></asp:Button><BR /><asp:GridView id="grConc" runat="server" Width="100%" __designer:wfdid="w104" DataSourceID="ObjDCartD" GridLines="Vertical" AllowSorting="True" AllowPaging="True"><Columns>
<asp:CommandField ShowSelectButton="True"></asp:CommandField>
</Columns>
</asp:GridView> <asp:ObjectDataSource id="ObjDCartD" runat="server" TypeName="Informes" SelectMethod="GetSaldosPorConc" OldValuesParameterFormatString="original_{0}" __designer:wfdid="w105"><SelectParameters __designer:dtid="1125899906842660">
<asp:ControlParameter ControlID="CbCdec" PropertyName="SelectedValue" Name="Dec_Cdec" Type="String"></asp:ControlParameter>
<asp:ControlParameter ControlID="TxtFI" PropertyName="Text" DefaultValue="" Name="Fec_Ini" Type="DateTime"></asp:ControlParameter>
<asp:ControlParameter ControlID="TxtFF" PropertyName="Text" DefaultValue="" Name="Fec_Fin" Type="DateTime"></asp:ControlParameter>
</SelectParameters>
</asp:ObjectDataSource> <ajaxToolkit:CalendarExtender id="CalendarExtender1" runat="server" TargetControlID="TxtFI"></ajaxToolkit:CalendarExtender> <ajaxToolkit:CalendarExtender id="CalendarExtender2" runat="server" TargetControlID="TxtFF"></ajaxToolkit:CalendarExtender> 
</contenttemplate>
                <triggers>
<asp:PostBackTrigger ControlID="BtnExcel"></asp:PostBackTrigger>
</triggers>
            </asp:UpdatePanel>&nbsp;<asp:ObjectDataSource ID="ObjCDec" runat="server" OldValuesParameterFormatString="original_{0}"
                SelectMethod="GetCDEC" TypeName="CDeclaraciones"></asp:ObjectDataSource>
            <br />
            &nbsp;<br />
            &nbsp;<br />
            <asp:UpdatePanel id="UpdatePanel2" runat="server" UpdateMode="Conditional">
                <contenttemplate>
<!-- Mensaje de Salida--><asp:Button style="DISPLAY: none" id="hiddenTargetControlForModalPopup" runat="server" __designer:wfdid="w98"></asp:Button> <ajaxToolkit:ModalPopupExtender id="ModalPopup" runat="server" __designer:wfdid="w99" TargetControlID="hiddenTargetControlForModalPopup" RepositionMode="RepositionOnWindowScroll" PopupDragHandleControlID="programmaticPopupDragHandle" PopupControlID="programmaticPopup" DropShadow="True" BehaviorID="programmaticModalPopupBehavior" BackgroundCssClass="modalBackground">
            </ajaxToolkit:ModalPopupExtender> <asp:Panel id="programmaticPopup" runat="server" Height="229%" CssClass="ModalPanel2" Width="625px" __designer:wfdid="w100"><asp:Panel id="programmaticPopupDragHandle" runat="Server" Height="30px" CssClass="BarTitleModal2" __designer:wfdid="w101">
                    <div style="padding: 5px; vertical-align: middle;">
                        <div style="float: left;">
                            Buscar Agente Recaudador
                        </div>
                    </div>
                </asp:Panel> &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;<BR />&nbsp; &nbsp; &nbsp;&nbsp; <uc1:consultater id="ConsultaTer1" runat="server" __designer:wfdid="w102" tipo="AR" ret="DD"></uc1:consultater> <BR /><BR /><BR /></asp:Panel> 
</contenttemplate>
            </asp:UpdatePanel>
        </div>
    </div>
</div>
</asp:Content>

