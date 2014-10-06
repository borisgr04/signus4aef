<%@ Control Language="VB" AutoEventWireup="false" CodeFile="Con_Tercero.ascx.vb" Inherits="CtrlUsr_Terceros_Con_Tercero" %>
<div style="padding: 10px; margin: 10px">
<asp:UpdatePanel ID="UpdatePanel1" runat="server">
    <ContentTemplate>
    <table style="width: 573px; height: 10px">
    <tr>
        <td style="width: 100px">
            Nit/Nombre</td>
        <td colspan="1" style="width: 290px">
            <asp:TextBox ID="TxtFilNom" runat="server" Width="277px"> 
            </asp:TextBox>
        </td>
        <td colspan="1" style="width: 53px">
            <asp:ImageButton ID="BtnBuscar" runat="server" AccessKey="b" AlternateText="Buscar"
                CausesValidation="False" CommandName="Buscar" ImageUrl="~/images/Operaciones/search2.png"/></td>
        <td style="width: 49px">
            &nbsp;</td>
    </tr>
    <tr>
        <td style="width: 100px">
        </td>
        <td colspan="1" style="width: 290px">
        </td>
        <td colspan="1" style="width: 53px">
            Buscar</td>
        <td style="width: 49px">
            </td>
    </tr>
    </table>
    <asp:GridView ID="gvConsulta" runat="server" AllowPaging="True" AutoGenerateColumns="False"
            DataKeyNames="ter_nit" DataSourceID="ObjTerceros" ShowFooter="True">
            <Columns>
                <asp:BoundField DataField="TER_TDOC" HeaderText="Tipo  Doc" />
                <asp:BoundField DataField="TER_NIT" HeaderText="No. Identificacion" />
                <asp:BoundField DataField="TER_NOM" HeaderText="Nombre" />                            
                <asp:BoundField DataField="TER_MPIO" HeaderText="Municipio" />                                                 
                <asp:BoundField DataField="TER_TEL" HeaderText="Telefono" />                            
                <asp:BoundField DataField="TER_OBS" HeaderText="Observaci&#243;n" />                            
                <asp:CommandField ButtonType="Image" 
                    SelectImageUrl="~/images/Operaciones/Select.png" ShowSelectButton="True" />
            </Columns>
            <EmptyDataTemplate>
                <br />
                <asp:Label ID="Label1" runat="server" CssClass="NoData" Text="No se encontraron registros"
                    Width="166px"></asp:Label>
            </EmptyDataTemplate>
        </asp:GridView>
        <asp:HiddenField ID="HFNit" runat="server" />
        <asp:HiddenField ID="HFDv" runat="server" />
        <asp:HiddenField ID="HFNombre" runat="server" />
        <asp:HiddenField ID="HFTipoDoc" runat="server" />
        <asp:HiddenField ID="HiddenField1" runat="server" Value="" />
    </ContentTemplate> 
</asp:UpdatePanel> 
</div>
        <asp:ObjectDataSource ID="ObjTerceros" runat="server" SelectMethod="GetRecords" 
            TypeName="Signus.Terceros" OldValuesParameterFormatString="original_{0}">
            <SelectParameters>
                <asp:ControlParameter ControlID="TxtFilNom" Name="busc" PropertyName="Text" 
                    Type="String" />
                <asp:ControlParameter ControlID="HiddenField1" Name="tipo" 
                    PropertyName="Value" Type="String" />
            </SelectParameters>
        </asp:ObjectDataSource>
     
