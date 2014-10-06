<%@ Control Language="VB" AutoEventWireup="false" CodeFile="Ctrl_VhAseguradora.ascx.vb" Inherits="CtrlUsr_Vehiculo_Ctrl_VhAseguradora" %>
<asp:UpdatePanel ID="UpdatePanel1" runat="server">
<ContentTemplate>
<div class="demoarea">
<asp:Label ID="msg" runat="server" Text="" Width="90%"></asp:Label>
<asp:MultiView ID="MultiView1" runat="server" ActiveViewIndex="0">
<asp:View ID="vwPanel" runat="server"> 
<table style="width:550px;">
    <tr>
        <td colspan="3" class="TbDecl">
            <asp:Label ID="lbEstado" runat="server"></asp:Label>
        </td>
    </tr>
    <tr>
        <td>
            Codigo de la Aseguradora</td>
        <td>
            &nbsp;</td>
        <td>
            &nbsp;</td>
    </tr>
    <tr>
        <td>
            <asp:TextBox ID="tbCodigo" runat="server"></asp:TextBox>
        </td>
        <td>
            &nbsp;</td>
        <td>
            &nbsp;</td>
    </tr>
    <tr>
        <td>
            <asp:Label ID="lbNomAseguradora" runat="server" Text="Nombre de la Aseguradora"></asp:Label>
        </td>
        <td>
            &nbsp;</td>
        <td>
            &nbsp;</td>
    </tr>
    <tr>
        <td>
            <asp:TextBox ID="tbNomAseguradora" runat="server" Width="450px"></asp:TextBox>
        </td>
        <td>
            <asp:ImageButton ID="btGuardar" runat="server" 
                ImageUrl="~/images/Operaciones/save.png" />
        </td>
        <td>
            <asp:ImageButton ID="btCancelar" runat="server" 
                ImageUrl="~/images/Operaciones/Deshacer.png" />
        </td>
    </tr>
    <tr>
        <td>
            Estado</td>
        <td>
            &nbsp;</td>
        <td>
            &nbsp;</td>
    </tr>
    <tr>
        <td>
            <asp:DropDownList ID="cmbEstado" runat="server">
                <asp:ListItem Value="AC">ACTIVO</asp:ListItem>
                <asp:ListItem Value="IN">INACTIVO</asp:ListItem>
            </asp:DropDownList>
        </td>
        <td>
            &nbsp;</td>
        <td>
            &nbsp;</td>
    </tr>
</table>
<asp:HiddenField ID="hfTransaccion" runat="server" />
</asp:View> 
<asp:View ID="vwLista" runat="server"> 
    <table style="width: 550px;">
        <tr>
            <td>
                Aseguradora:</td>
            <td>
                <asp:TextBox ID="tbBuscaNomAseguradora" runat="server" Width="400px"></asp:TextBox>
            </td>
            <td>
                <asp:ImageButton ID="btBuscar" runat="server" 
                    ImageUrl="~/images/Operaciones/search2.png" />
            </td>
        </tr>
        <tr>
            <td colspan="3">
                <asp:LinkButton ID="btNuevo" runat="server">Nueva Aseguradora</asp:LinkButton>
            </td>
        </tr>
    </table>
    <asp:GridView ID="gvConsulta" runat="server" AllowPaging="True" 
                AutoGenerateColumns="False" DataKeyNames="COD_ASEG" DataSourceID="odsAseguradora">
                <Columns>
                    <asp:BoundField DataField="COD_ASEG" HeaderText="Codigo">
                        <HeaderStyle HorizontalAlign="Left" />
                    </asp:BoundField>
                    <asp:BoundField DataField="NOM_ASEG" HeaderText="Aseguradora">
                        <HeaderStyle HorizontalAlign="Left" />
                        <ItemStyle Width="400px" />
                    </asp:BoundField>
                    <asp:BoundField DataField="EST_ASEG" HeaderText="Estado">
                        <HeaderStyle HorizontalAlign="Left" />
                    </asp:BoundField>
                    <asp:ButtonField ButtonType="Image" CommandName="Editar" 
                        ImageUrl="~/images/Operaciones/Edit2.png" Text="Editar" />
                    <asp:CommandField ButtonType="Image" 
                        SelectImageUrl="~/images/Operaciones/Select.png" ShowSelectButton="True" />
                </Columns>
            </asp:GridView>
    <asp:ObjectDataSource ID="odsAseguradora" runat="server" 
        OldValuesParameterFormatString="original_{0}" SelectMethod="GetPorNombre" 
        TypeName="Vh_Aseguradora">
        <SelectParameters>
            <asp:ControlParameter ControlID="tbBuscaNomAseguradora" Name="NOM_ASEG" 
                PropertyName="Text" Type="String" />
        </SelectParameters>
    </asp:ObjectDataSource>
</asp:View> 
</asp:MultiView> 
</div>
</ContentTemplate>
</asp:UpdatePanel> 
