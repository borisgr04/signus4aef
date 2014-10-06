<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="Gtram.aspx.vb" Inherits="Expediente_Gtram_Gtram" title="Untitled Page" %>
<asp:Content ID="Content1" ContentPlaceHolderID="SampleContent" Runat="Server">
<asp:ScriptManager ID="ScriptManager1" runat="server">
</asp:ScriptManager>
<asp:UpdatePanel ID="UpdatePanel1" runat="server">
<ContentTemplate>
<div class="demoarea">
    <table style="width:100%;">
        <tr class="TbDecl">
            <td>
                EXPEDIENTES ABIERTOS</td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td valign="top">
                <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" 
                    AllowPaging="True" DataSourceID="odsExpeAbiertos">
                    <Columns>
                        <asp:BoundField DataField="TRAM_NOMB" HeaderText="TRAMITE">
                            <HeaderStyle HorizontalAlign="Left" />
                            <ItemStyle Width="250px" />
                        </asp:BoundField>
                        <asp:BoundField DataField="TOTAL" HeaderText="TOTAL">
                            <HeaderStyle HorizontalAlign="Right" />
                            <ItemStyle HorizontalAlign="Right" Width="150px" />
                        </asp:BoundField>
                    </Columns>
                </asp:GridView>
            </td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
        </tr>
        <tr class="TbDecl">
            <td>
                TRAMITES CON TIEMPO CUMPLIDO</td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td style="width:430px" valign="top">
            <asp:GridView ID="gvVencidosGral" runat="server" AutoGenerateColumns="False" 
                DataSourceID="odsExpeVencidoGral"  DataKeyNames="TRAM_NOMB" AllowPaging="True">
                <Columns>
                    <asp:BoundField DataField="TRAM_NOMB" HeaderText="TRAMITE" >
                        <HeaderStyle HorizontalAlign="Left" />
                        <ItemStyle Width="250px" />
                    </asp:BoundField>
                    <asp:BoundField DataField="TOTAL" HeaderText="VENCIDOS" >
                        <HeaderStyle HorizontalAlign="Right" />
                        <ItemStyle HorizontalAlign="Right" Width="150px" />
                    </asp:BoundField>
                    <asp:CommandField SelectText="Detalle" ShowSelectButton="True" >
                        <ItemStyle HorizontalAlign="Right" Width="100px" />
                    </asp:CommandField>
                </Columns>
            </asp:GridView>
            </td>
            <td valign="top">
            <asp:GridView ID="gvVencidos" runat="server" AutoGenerateColumns="False" 
                DataKeyNames="EXPE_NUME" DataSourceID="odsExpeVencido" AllowPaging="True">
                <Columns>
                    <asp:BoundField DataField="EXPE_NUME" HeaderText="EXPEDIENTE No." >
                        <HeaderStyle HorizontalAlign="Left" />
                        <ItemStyle Width="100px" />
                    </asp:BoundField>
                    <asp:BoundField DataField="TRAM_NOMB" HeaderText="TRAMITE" >
                        <HeaderStyle HorizontalAlign="Left" />
                        <ItemStyle Width="200px" />
                    </asp:BoundField>
                    <asp:CommandField SelectText="Ir" ShowSelectButton="True" >
                        <HeaderStyle HorizontalAlign="Right" />
                        <ItemStyle Width="20px" />
                    </asp:CommandField>
                </Columns>
            </asp:GridView>
            </td>
        </tr>
        <tr>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
        </tr>
        <tr class="TbDecl">
            <td>
                TRAMITES SIN NOTIFICACION DE RECIBIDO</td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td valign="top">
                <asp:GridView ID="gvExpeSinNotifGral" runat="server" AllowPaging="True" 
                 DataKeyNames="TRAM_NOMB"  AutoGenerateColumns="False" DataSourceID="odsExpeSinNoficacionGral">
                    <Columns>
                        <asp:BoundField DataField="TRAM_NOMB" HeaderText="TRAMITE">
                            <HeaderStyle HorizontalAlign="Left" />
                            <ItemStyle Width="250px" />
                        </asp:BoundField>
                        <asp:BoundField DataField="TOTAL" HeaderText="TOTAL">
                            <HeaderStyle HorizontalAlign="Right" />
                            <ItemStyle HorizontalAlign="Right" Width="120px" />
                        </asp:BoundField>
                        <asp:CommandField SelectText="Detalle" ShowSelectButton="True">
                            <HeaderStyle HorizontalAlign="Right" />
                            <ItemStyle HorizontalAlign="Right" Width="100px" />
                        </asp:CommandField>
                    </Columns>
                </asp:GridView>
            </td>
            <td valign="top">
                <asp:GridView ID="gvExpeSinNotif" runat="server" AllowPaging="True" DataKeyNames="EXPE_NUME"
                    AutoGenerateColumns="False" DataSourceID="odsExpeSinNoficacion">
                    <Columns>
                        <asp:BoundField DataField="EXPE_NUME" HeaderText="EXPEDIENTE No.">
                            <HeaderStyle HorizontalAlign="Left" />
                            <ItemStyle Width="100px" />
                        </asp:BoundField>
                        <asp:BoundField DataField="TRAM_NOMB" HeaderText="TRAMITE">
                            <HeaderStyle HorizontalAlign="Left" />
                            <ItemStyle Width="200px" />
                        </asp:BoundField>
                        <asp:CommandField SelectText="Ir" ShowSelectButton="True">
                            <HeaderStyle HorizontalAlign="Right" />
                            <ItemStyle Width="20px" />
                        </asp:CommandField>
                    </Columns>
                </asp:GridView>
            </td>
        </tr>
        <tr>
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
        </tr>
        <tr>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
        </tr>
    </table>
    <asp:ObjectDataSource ID="odsExpeVencidoGral" runat="server" SelectMethod="GetExpeVencidosGral" 
    TypeName="Expedientes"  OldValuesParameterFormatString="original_{0}">
    </asp:ObjectDataSource>
    <asp:ObjectDataSource ID="odsExpeVencido" runat="server" SelectMethod="GetExpeVencidos" 
    TypeName="Expedientes" OldValuesParameterFormatString="original_{0}" >
        <SelectParameters>
            <asp:ControlParameter ControlID="gvVencidosGral" Name="TRAM_NOMB" 
                PropertyName="SelectedValue" Type="String" />
        </SelectParameters>
    </asp:ObjectDataSource>    
    <asp:ObjectDataSource ID="odsExpeSinNoficacionGral" runat="server" SelectMethod="GetExpeSinNotificacion" 
    TypeName="Expedientes"  OldValuesParameterFormatString="original_{0}">
    </asp:ObjectDataSource>
    <asp:ObjectDataSource ID="odsExpeSinNoficacion" runat="server"  SelectMethod="GetExpeSinNotificacion" 
    TypeName="Expedientes"  OldValuesParameterFormatString="original_{0}">
        <SelectParameters>
            <asp:ControlParameter ControlID="gvExpeSinNotifGral" Name="TRAM_NOMB" 
                PropertyName="SelectedValue" Type="String" />
        </SelectParameters>
    </asp:ObjectDataSource>
    <asp:ObjectDataSource ID="odsExpeAbiertos" runat="server" SelectMethod="GetExpeAbiertos" 
    TypeName="Expedientes" OldValuesParameterFormatString="original_{0}">
    </asp:ObjectDataSource>
</div>
</ContentTemplate>
</asp:UpdatePanel>
</asp:Content>

