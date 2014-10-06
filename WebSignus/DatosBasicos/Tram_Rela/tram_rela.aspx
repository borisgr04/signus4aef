<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="tram_rela.aspx.vb" Inherits="DatosBasicos_Tram_Rela_tram_rela" title="Relacionar Tramites" %>
<%@ Register Src="~/CtrlUsr/Tramites/Con_tramite.ascx" TagName="CtrlConsTramite" TagPrefix="uc2" %>
<asp:Content ID="Content1" ContentPlaceHolderID="SampleContent" Runat="Server">
<asp:ScriptManager ID="ScriptManager1" runat="server">
</asp:ScriptManager>
<div class="demoarea">
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
    <ContentTemplate>
    <asp:Label ID="MsgResult" runat="server" Width="90%"></asp:Label>
        <table style="width: 600px;">
            <tr>
                <td>
                    &nbsp;</td>
                <td>
                    &nbsp;</td>
                <td>
                    &nbsp;</td>
            </tr>
            <tr>
                <td>
                    &nbsp;</td>
                <td>
                    &nbsp;</td>
                <td>
                    &nbsp;</td>
            </tr>
            <tr class="TbDecl">
                <td colspan="3">
                    RELACION DE TRAMITES</td>
            </tr>
            <tr>
                <td>
                    &nbsp;</td>
                <td>
                    &nbsp;</td>
                <td>
                    &nbsp;</td>
            </tr>
            <tr>
                <td style="width:100px">
                    <asp:Label ID="Label1" runat="server" Text="Tramite Desde"></asp:Label>
                </td>
                <td style="width:350px">
                    <asp:TextBox ID="tbDesde" runat="server" width="350px" Enabled="False"></asp:TextBox>
                </td>
                <td>
                 &nbsp;
                    <asp:Button ID="btDesde" runat="server" Text="..." />
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="Label2" runat="server" Text="Tramite Para"></asp:Label>
                </td>
                <td style="width:350px">
                    <asp:TextBox ID="tbPara" runat="server" width="350px" Enabled="False"></asp:TextBox>
                </td>
                <td>
                    &nbsp;
                    <asp:Button ID="btPara" runat="server" Text="..." />
                </td>
            </tr>
            <tr>
                <td>
                    &nbsp;
                </td>
                <td>
                    <asp:Button ID="btGuardar" runat="server" Text="Agregar" />
                </td>
                <td>
                    &nbsp;
                </td>
            </tr>
            <tr>
                <td>
                    &nbsp;</td>
                <td>
                    &nbsp;</td>
                <td>
                    &nbsp;</td>
            </tr>
        </table> 
        <asp:GridView ID="gvConsulta" runat="server" AllowPaging="True" 
            AllowSorting="True" AutoGenerateColumns="False" DataSourceID="odsTramRela" DataKeyNames="TRRE_DESD, TRRE_PARA">
            <Columns>
                <asp:BoundField DataField="TRAM_DESD" HeaderText="Desde" 
                    SortExpression="TRAM_DESD">
                    <HeaderStyle HorizontalAlign="Left" />
                    <ItemStyle Width="250px" />
                </asp:BoundField>
                <asp:BoundField DataField="TRAM_PARA" HeaderText="Para" 
                    SortExpression="TRAM_PARA">
                    <HeaderStyle HorizontalAlign="Left" />
                    <ItemStyle Width="250px" />
                </asp:BoundField>
                <asp:CommandField ButtonType="Image" 
                    SelectImageUrl="~/images/Operaciones/delete2.png" SelectText="Eliminar" 
                    ShowSelectButton="True" />
            </Columns>
        </asp:GridView>   
        <asp:ObjectDataSource ID="odsTramRela" runat="server" 
            OldValuesParameterFormatString="original_{0}" SelectMethod="GetRecords" 
            TypeName="Tram_Rela">
        </asp:ObjectDataSource>
        <asp:HiddenField ID="HfOrigen" runat="server" />
        <asp:HiddenField ID="HfDesde" runat="server" />
        <asp:HiddenField ID="HfPara" runat="server" />
    </ContentTemplate>
    </asp:UpdatePanel>
    
    <asp:UpdatePanel ID="upModalContramite" runat="server" UpdateMode="Conditional" >
    <ContentTemplate>
        <ajaxToolkit:ModalPopupExtender id="ModalPopupConTramite" runat="server" 
            TargetControlID="btn_Target" 
            PopupControlID="pConsTram"
            PopupDragHandleControlID="pConsTram2"
            DropShadow ="true"
            BackgroundCssClass="modalBackground">
        </ajaxToolkit:ModalPopupExtender> 
        <asp:Panel id="pConsTram" runat="server" Width="450px" Height="229%" CssClass="ModalPanel2">
            <asp:Panel id="pConsTram2" runat="Server" Height="30px" CssClass="BarTitleModal2">
                <div style="padding-right: 5px; padding-left: 5px; padding-bottom: 5px; vertical-align: middle;
                         padding-top: 5px">
                    <div style="FLOAT: left">Consulta de Tramites</DIV>
                    <div style="float: right">
                        <asp:Button ID="btCerrarConTramite" runat="server" Text="X" /> 
                    </div> 
                </div>
            </asp:Panel>
             <uc2:CtrlConsTramite id="CtrlConsTramite2" runat="server">
            </uc2:CtrlConsTramite><br /><br /><br />
            <asp:Button style="display:none" id="btn_Target" runat ="server"></asp:Button>
        </asp:Panel> 
    </ContentTemplate>
    </asp:UpdatePanel>
    
</div>
</asp:Content>

