<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="PanelAgente.aspx.vb" Inherits="Consultas_PanelAgente_PanelAgente" title="Panel Agente" %>
<%@ Register Src="../../CtrlUsr/Terceros/Con_Tercero.ascx" TagName="CtrlConTercero" TagPrefix="uc2" %>
<asp:Content ID="Content1" ContentPlaceHolderID="SampleContent" Runat="Server">
        
    <ajaxToolkit:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server" AsyncPostBackTimeout="600">
    </ajaxToolkit:ToolkitScriptManager>
    <div class="demoarea">
    <asp:UpdatePanel id="UpdatePanel1" runat="server">
    <contenttemplate>
    <asp:Label ID="MsgResult" runat="server" Height="100%" Width="90%"></asp:Label>
    <br />
    <asp:Label ID="Tit" runat="server" CssClass="Titulo" 
            Text="PANEL DE AGENTES RECAUDADORES"></asp:Label>
        <table style="width:620px;">
        <tr>
            <td colspan="4">
                
                &nbsp;</td>
        </tr>
        <tr class="TbDecl">
            <td colspan="4">
                <asp:Label ID="Label10" runat="server" Font-Bold="True" 
                    Text="AGENTE RECAUDADOR"></asp:Label>
            </td>
        </tr>
        <tr>
            <td style="width:100px">
                &nbsp;</td>
            <td style="width:120px">
                &nbsp;</td>
            <td style="width:200px">
                &nbsp;</td>
            <td style="width:200px">
                &nbsp;</td>
        </tr>
            <tr>
                <td>
                    <asp:Label ID="Label11" runat="server" Text="Razon Social"></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="Nit" runat="server" AutoPostBack="True" Enabled="False" 
                        Width="110px"></asp:TextBox>
                </td>
                <td align="left" colspan="2">
                    <asp:TextBox ID="Dv" runat="server" Enabled="False" Width="17px"></asp:TextBox>
                    <asp:Button ID="BtnBuscDP" runat="server" accessKey="B" 
                        CausesValidation="False" Text="..." ToolTip="Buscar Agente Recaudador" 
                        UseSubmitBehavior="False" Width="17px" />
                    <asp:TextBox ID="Agente" runat="server" Enabled="False" Width="280px"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" 
                        ControlToValidate="Nit" ErrorMessage="*"></asp:RequiredFieldValidator>
                </td>
            </tr>
        <tr>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
        </tr>
        <tr class="TbDecl">
            <td colspan="4">
                <asp:Label ID="Label1" runat="server" Font-Bold="True" 
                            Text="HISTORIAL DEL AGENTE"></asp:Label>
            </td>
        </tr>
        <tr>
            <td colspan="4">
                &nbsp;</td>
        </tr> 
    </table>
        <table style="width:320px;">
            <tr>
                <td valign="middle">
                    <asp:ImageButton ID="btCartera" runat="server" Height="32px" 
                        ImageUrl="~/images/Operaciones/cartera.png" />&nbsp;&nbsp;
                    <asp:LinkButton ID="lkCartera" runat="server">Cartera</asp:LinkButton>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:ImageButton ID="btExpediente" runat="server" 
                        ImageUrl="~/images/imagev2/blog-post-accept-icon.png" />&nbsp;&nbsp;
                    <asp:LinkButton ID="lkexpediente" runat="server">Expedientes</asp:LinkButton>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:ImageButton ID="btAcpa" runat="server" 
                        ImageUrl="~/images/Operaciones/cartera1.png" />&nbsp;&nbsp;
                    <asp:LinkButton ID="lkAcuerdo" runat="server">Acuerdos de Pagos</asp:LinkButton>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:ImageButton ID="btRopa" runat="server" 
                        ImageUrl="~/images/Operaciones/pagos1.png" />&nbsp;&nbsp;
                    <asp:LinkButton ID="lkRopa" runat="server">Recibo de Pago</asp:LinkButton>
                </td>
            </tr>
         </table>
    </contenttemplate> 
    </asp:UpdatePanel> 

    <asp:UpdatePanel ID="upModalTercero" runat="server" UpdateMode="Conditional" >
    <ContentTemplate>
        <ajaxToolkit:ModalPopupExtender id="ModalPopupConTercero" runat="server" 
            TargetControlID="btn_Target" 
            CancelControlID="btCerrarConTercero"
            PopupControlID="pConsTer"
            PopupDragHandleControlID="pConsTer2"
            DropShadow ="true"
            BackgroundCssClass="modalBackground">
        </ajaxToolkit:ModalPopupExtender> 
        <asp:Panel id="pConsTer" runat="server" Width="650px" Height="229%" CssClass="ModalPanel2">
            <asp:Panel id="pConsTer2" runat="Server" Height="30px" CssClass="BarTitleModal2">
                <div style="padding-right: 5px; padding-left: 5px; padding-bottom: 5px; vertical-align: middle;
                         padding-top: 5px">
                    <div style="FLOAT: left">Consulta de Terceros</DIV>
                    <div style="float: right">
                        <asp:Button ID="btCerrarConTercero" runat="server" Text="X" /> 
                    </div> 
                </div>
            </asp:Panel>
             <uc2:CtrlConTercero id="CtrlConTercero2" runat="server">
            </uc2:CtrlConTercero><br /><br /><br />
            <asp:Button style="display:none" id="btn_Target" runat ="server"></asp:Button>
        </asp:Panel> 
    </ContentTemplate>
    </asp:UpdatePanel>        
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


