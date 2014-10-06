<%@ Control Language="VB" AutoEventWireup="false" CodeFile="Con_Banco.ascx.vb" Inherits="CtrlUsr_ConsultaBan" %>
<asp:UpdatePanel ID="UpdatePanel1" runat="server">
    <ContentTemplate>
    <table style="width: 573px; height: 10px">
    <tr>
        <td style="width: 100px">
            Nit/Nombre</td>
        <td colspan="1" style="width: 290px">
            <asp:TextBox ID="TxtFilNom" runat="server" Width="277px"> 
</asp:TextBox></td>
        <td colspan="1" style="width: 53px">
            <asp:ImageButton ID="BtnBuscar" runat="server" AccessKey="b" AlternateText="Buscar"
                CausesValidation="False" CommandName="Buscar" ImageUrl="~/images/Operaciones/search2.png" /></td>
        <td colspan="5" style="width: 49px">
            &nbsp;</td>
    </tr>
    <tr>
        <td style="width: 100px">
        </td>
        <td colspan="1" style="width: 290px">
        </td>
        <td colspan="1" style="width: 53px">
            Buscar</td>
        <td colspan="5" style="width: 49px">
            </td>
    </tr>
</table>
        <asp:GridView ID="GridView1" runat="server" AllowPaging="True" AutoGenerateColumns="False"
            DataKeyNames="CTA_BACO" DataSourceID="ObjCuentas" OnRowCommand="GridView1_RowCommand"
            OnRowDataBound="GridView1_RowDataBound" OnSelectedIndexChanged="GridView1_SelectedIndexChanged"
            ShowFooter="True">
            <Columns>
                <asp:TemplateField HeaderText="N° CUENTA" SortExpression="CTA_NRO">
                    <ItemTemplate>
                        <asp:Label ID="LbNom" runat="server" Text='<%# Bind("CTA_NRO") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="N° CUENTA" SortExpression="CTA_BACO">
                    <ItemTemplate>
                        <asp:Label ID="LbNom" runat="server" Text='<%# Bind("CTA_BACO") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="NOMBRE DE LA CUENTA" SortExpression="CTA_DESC">
                    <ItemTemplate>
                        <asp:Label ID="LbUni1" runat="server" Text='<%# Bind("CTA_DESC") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="BANCO" SortExpression="BAN_NOM">
                    <ItemTemplate>
                        <asp:Label ID="LbUni2" runat="server" Text='<%# Bind("BAN_NOM") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                  <asp:TemplateField >
                    <ItemStyle HorizontalAlign="Center" Width="16px" />
                    <ItemTemplate>
                        <img alt="Enviar" title="Enviar Registro" onmouseover="this.style.cursor = 'hand'" onmouseout="this.style.cursor = 'auto'" src="../../images/Operaciones/Select.png"  onclick="javascript:enviarCta('<%# Eval("CTA_NRO") %>','<%# Eval("CTA_BACO")%>','<%#  Eval("BAN_NOM")%>' );" />
                     </ItemTemplate>
                 </asp:TemplateField>
            </Columns>
            <EmptyDataTemplate>
                <br />
                <asp:Label ID="Label1" runat="server" CssClass="NoData" Text="No se encontraron registros"
                    Width="166px"></asp:Label>
            </EmptyDataTemplate>
        </asp:GridView>
    </ContentTemplate>
</asp:UpdatePanel>
&nbsp; &nbsp;<asp:ObjectDataSource ID="ObjCuentas" runat="server" SelectMethod="GetCuentas" TypeName="Bancos">
    <SelectParameters>
            <asp:ControlParameter ControlID="TxtFilNom" Name="busc" PropertyName="Text" Type="String" />   
     </SelectParameters> 
</asp:ObjectDataSource>
<!-- 

-->