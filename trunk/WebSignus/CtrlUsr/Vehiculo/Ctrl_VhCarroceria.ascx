<%@ Control Language="VB" AutoEventWireup="false" CodeFile="Ctrl_VhCarroceria.ascx.vb" Inherits="CtrlUsr_Vehiculo_Ctrl_VhCarroceria" %>
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
            &nbsp;</td>
        <td>
            &nbsp;</td>
        <td>
            &nbsp;</td>
    </tr>
    <tr>
        <td>
            <asp:Label ID="lbNomCarroceria" runat="server" Text="Nombre de la Carroceria"></asp:Label>
        </td>
        <td>
            &nbsp;</td>
        <td>
            &nbsp;</td>
    </tr>
    <tr>
        <td>
            <asp:TextBox ID="tbNomCarroceria" runat="server" Width="450px"></asp:TextBox>
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
            Nombre de la Carroceria Anterior</td>
        <td>
            &nbsp;</td>
        <td>
            &nbsp;</td>
    </tr>
    <tr>
        <td>
            <asp:TextBox ID="tbNomCarroceriaOld" runat="server"  Width="450px" Enabled="False"></asp:TextBox>
            
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
                Carroceria:</td>
            <td>
                <asp:TextBox ID="tbBuscaNomCarroceria" runat="server" Width="400px"></asp:TextBox>
            </td>
            <td>
                <asp:ImageButton ID="btBuscar" runat="server" 
                    ImageUrl="~/images/Operaciones/search2.png" />
            </td>
        </tr>
        <tr>
            <td colspan="3">
                <asp:LinkButton ID="btNuevo" runat="server">Nueva Carroceria</asp:LinkButton>
            </td>
        </tr>
    </table>
    <asp:GridView ID="gvConsulta" runat="server" AllowPaging="True" 
                AutoGenerateColumns="False" DataKeyNames="ID_VH_CARROCERIA" DataSourceID="odsCarroceria">
                <Columns>
                    <asp:BoundField DataField="NOM_CARROCERIA" HeaderText="Carroceria">
                        <ItemStyle Width="500px" />
                    </asp:BoundField>
                    <asp:ButtonField ButtonType="Image" CommandName="Editar" 
                        ImageUrl="~/images/Operaciones/Edit2.png" Text="Editar" />
                    <asp:CommandField ButtonType="Image" 
                        SelectImageUrl="~/images/Operaciones/Select.png" ShowSelectButton="True" />
                </Columns>
            </asp:GridView>
    <asp:ObjectDataSource ID="odsCarroceria" runat="server" 
        OldValuesParameterFormatString="original_{0}" SelectMethod="GetPorNombre" 
        TypeName="Vh_Carroceria">
        <SelectParameters>
            <asp:ControlParameter ControlID="tbBuscaNomCarroceria" Name="NOM_CARROCERIA" 
                PropertyName="Text" Type="String" />
        </SelectParameters>
    </asp:ObjectDataSource>
</asp:View> 
</asp:MultiView> 
</div>
</ContentTemplate>
</asp:UpdatePanel> 
