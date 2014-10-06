<%@ Control Language="VB" AutoEventWireup="false" CodeFile="Con_tramite.ascx.vb" Inherits="CtrlUsr_Tramites_Con_tramite" %>
<div style="padding: 10px; margin: 10px">
<asp:UpdatePanel ID="UpdatePanel1" runat="server">
    <ContentTemplate>
        <table style="width:100%;">
            <tr>
                <td style="width:100px">
                    Tramite</td>
                <td style="width:300px">
                    <asp:TextBox ID="tbTramite" Width="250px" runat="server"></asp:TextBox>
                </td>
                <td>
                    <asp:ImageButton ID="BtnBuscar" runat="server" AccessKey="b" 
                        AlternateText="Buscar" CausesValidation="False" CommandName="Buscar" 
                        ImageUrl="~/images/Operaciones/search2.png" />
                </td>
            </tr>
            <tr>
                <td style="width:100px">
                    &nbsp;</td>
                <td style="width:300px">
                    &nbsp;</td>
                <td>
                    Buscar</td>
            </tr>
        </table>
        <asp:GridView ID="gvConsulta" runat="server" AllowPaging="True" 
            AutoGenerateColumns="False" 
            DataSourceID="odsTramite" 
            DataKeyNames="TRAM_CODI"
            OnSelectedIndexChanged="gvConsulta_SelectedIndexChanged" PageSize="7" 
            ShowFooter="True">
            <Columns>
                <asp:BoundField DataField="TRAM_CODI" HeaderText="Codigo">
                    <HeaderStyle HorizontalAlign="Left" />
                    <ItemStyle Width="110px" />
                </asp:BoundField>
                <asp:BoundField DataField="TRAM_NOMB" HeaderText="Descripción">
                    <HeaderStyle HorizontalAlign="Left" />
                    <ItemStyle Width="210px" />
                </asp:BoundField>
                <asp:CommandField ButtonType="Image" 
                    SelectImageUrl="~/images/Operaciones/Select.png" ShowSelectButton="True" />
            </Columns>
            <EmptyDataTemplate>
                <br />
                <asp:Label ID="Label1" runat="server" CssClass="NoData" 
                    Text="No se encontraron registros" Width="166px"></asp:Label>
            </EmptyDataTemplate>
        </asp:GridView>
        <asp:HiddenField ID="HFCodTramite" runat="server" />
        <asp:ObjectDataSource ID="odsTramite" runat="server" 
            OldValuesParameterFormatString="original_{0}" SelectMethod="GetPorNombre" 
            TypeName="Tramites">
            <SelectParameters>
                <asp:ControlParameter ControlID="tbTramite" Name="TRAM_NOMB" 
                    PropertyName="Text" Type="String" />
            </SelectParameters>
        </asp:ObjectDataSource>
</ContentTemplate> 
</asp:UpdatePanel>    
</div>    
&nbsp; &nbsp;&nbsp;

