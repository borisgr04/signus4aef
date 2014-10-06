<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="ConExpediente.aspx.vb" Inherits="Consultas_Expedientes_ConsExpediente" %>
<%@ Register Src="../../CtrlUsr/Terceros/Con_Tercero.ascx" TagName="CtrlConTercero" TagPrefix="uc2" %>
<asp:Content ID="Content1" ContentPlaceHolderID="SampleContent" Runat="Server">
<ajaxToolkit:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server" AsyncPostBackTimeout="600">
</ajaxToolkit:ToolkitScriptManager>
<div class="demoarea">
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
    <ContentTemplate>
    <table style="width: 600px;">
        <tr>
            <td colspan="3"  class="TbDecl">
                CONSULTA DE EXPEDIENTES</td>
        </tr>
        <tr>
            <td colspan="3" align="right">
                <asp:LinkButton ID="lbVolver" runat="server">Volver</asp:LinkButton>
            </td>
        </tr>
        <tr>
            <td colspan="3">
                <asp:Label ID="Label10" runat="server" Font-Bold="True" 
                    Text="AGENTE RECAUDADOR"></asp:Label>
            </td>
        </tr>
        <tr>
            <td style="width: 110px;">
                &nbsp;</td>
            <td style="width: 65px;">
                &nbsp;</td>
            <td align="right">
                &nbsp;</td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="Label45" runat="server" CssClass="TitDecl" Font-Bold="True" Text="IDENTIFICACIÓN" Width="115px"></asp:Label>
            </td>
            <td>
                <asp:Label ID="Label2" runat="server" CssClass="TitDecl" Font-Bold="True" Text="DV"></asp:Label>
            </td>
            <td>
                <asp:Label ID="Label11" runat="server" CssClass="TitDecl" Font-Bold="True" Text="RAZON SOCIAL"></asp:Label>
            </td>
        </tr>
        <tr>
            <td>
                <asp:TextBox ID="Nit" runat="server" Enabled="False" Width="100%" ></asp:TextBox>
            </td>
            <td>
                <asp:TextBox ID="Dv" runat="server" Enabled="False" Width="17px">
                </asp:TextBox>
                <asp:Button ID="BtnBuscar" runat="server" accessKey="B" Text="..." ToolTip="Buscar Agente Recaudador" 
                         Width="17px" CausesValidation="False" />
            </td>
            <td>
                <asp:TextBox ID="Agente" runat="server" Enabled="False" Width="220px">
                </asp:TextBox>
             </td>
        </tr>
        <tr>
            <td>
                &nbsp;
            </td>
            <td>
                &nbsp;
            </td>
            <td>
                &nbsp;
            </td>
        </tr>
        <tr>
            <td>
                <asp:ImageButton ID="btConsultar" runat="server" 
                    ImageUrl="~/images/Operaciones/search2.png" />
            </td>
            <td>
                <asp:ImageButton ID="btExportar" runat="server" 
                    ImageUrl="~/images/imagev2/excel2007.gif" />
            </td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td>
                Buscar</td>
            <td>
                Exportar</td>
            <td>
                &nbsp;</td>
        </tr>
    </table>
    <asp:GridView ID="gvExpedientes" runat="server" AllowPaging="True" 
            AutoGenerateColumns="False" DataSourceID="odsExpePorNit">
        <Columns>
            <asp:BoundField DataField="EXPE_FELA" DataFormatString="{0:d}" 
                HeaderText="Fecha">
                <HeaderStyle HorizontalAlign="Left" />
                <ItemStyle HorizontalAlign="Left" />
            </asp:BoundField>
            <asp:BoundField DataField="PROC_NOMB" HeaderText="Tipo Proceso">
                <HeaderStyle HorizontalAlign="Left" />
                <ItemStyle Width="110px" />
            </asp:BoundField>
            <asp:BoundField DataField="EXPE_NUME" HeaderText="Expediente No.">
                <HeaderStyle HorizontalAlign="Left" />
                <ItemStyle Width="110px" />
            </asp:BoundField>
            <asp:BoundField DataField="CLD_NOM" HeaderText="Impuesto">
                <HeaderStyle HorizontalAlign="Left" />
                <ItemStyle Width="180px" />
            </asp:BoundField>
            <asp:BoundField DataField="TRAM_NOMB" HeaderText="Tramite Actual">
                <HeaderStyle HorizontalAlign="Left" />
                <ItemStyle Width="180px" />
            </asp:BoundField>
            <asp:BoundField DataField="PERIODOS" HeaderText="Periodos">
                <HeaderStyle HorizontalAlign="Left" />
                <ItemStyle Width="220px" />
            </asp:BoundField>
        </Columns>
    </asp:GridView>
    </ContentTemplate>
        <Triggers>
            <asp:PostBackTrigger ControlID="btExportar" />
        </Triggers>
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
    
    <asp:ObjectDataSource ID="odsExpePorNit" runat="server" 
        OldValuesParameterFormatString="original_{0}" SelectMethod="GetPorNit" 
        TypeName="Expedientes">
        <SelectParameters>
            <asp:ControlParameter ControlID="Nit" Name="EXPE_NIT" PropertyName="Text" 
                Type="String" />
        </SelectParameters>
    </asp:ObjectDataSource>
</div>
</asp:Content>

