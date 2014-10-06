<%@ Control Language="VB" AutoEventWireup="false" CodeFile="Ctrl_VhInstituto.ascx.vb" Inherits="CtrlUsr_Vehiculo_Ctrl_VhInstituto" %>
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
            <asp:Label ID="lbNomInstituto" runat="server" Text="Nombre del Instituto"></asp:Label>
            &nbsp;de Transito</td>
        <td>
            &nbsp;</td>
        <td>
            &nbsp;</td>
    </tr>
    <tr>
        <td>
            <asp:TextBox ID="tbNomInstituto" runat="server" Width="450px"></asp:TextBox>
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
            Codigo</td>
        <td>
            &nbsp;</td>
        <td>
            &nbsp;</td>
    </tr>
    <tr>
        <td>
            <asp:TextBox ID="tbCodigo" runat="server"  Width="450px"></asp:TextBox>
            
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
                Instituto:</td>
            <td>
                <asp:TextBox ID="tbBuscaNomInstituto" runat="server" Width="400px"></asp:TextBox>
            </td>
            <td>
                <asp:ImageButton ID="btBuscar" runat="server" 
                    ImageUrl="~/images/Operaciones/search2.png" />
            </td>
        </tr>
        <tr>
            <td colspan="3">
                <asp:LinkButton ID="btNuevo" runat="server">Nuevo Instituto de Transito</asp:LinkButton>
            </td>
        </tr>
    </table>
    <asp:GridView ID="gvConsulta" runat="server" AllowPaging="True" 
                AutoGenerateColumns="False" DataKeyNames="VINS_CODIGO" DataSourceID="odsInstituto">
                <Columns>
                    <asp:BoundField DataField="VINS_DESCRIPCION" HeaderText="Instituto de Transito">
                        <ItemStyle Width="500px" />
                    </asp:BoundField>
                    <asp:ButtonField ButtonType="Image" CommandName="Editar" 
                        ImageUrl="~/images/Operaciones/Edit2.png" Text="Editar" />
                    <asp:CommandField ButtonType="Image" 
                        SelectImageUrl="~/images/Operaciones/Select.png" ShowSelectButton="True" />
                </Columns>
            </asp:GridView>
    <asp:ObjectDataSource ID="odsInstituto" runat="server" 
        OldValuesParameterFormatString="original_{0}" SelectMethod="GetPorNombre" 
        TypeName="Vh_Instituto_Tran">
        <SelectParameters>
            <asp:ControlParameter ControlID="tbBuscaNomInstituto" Name="VINS_DESCRIPCION" 
                PropertyName="Text" Type="String" />
        </SelectParameters>
    </asp:ObjectDataSource>
</asp:View> 
</asp:MultiView> 
</div>
</ContentTemplate>
</asp:UpdatePanel> 
