<%@ Control Language="VB" AutoEventWireup="false" CodeFile="ConsultaTer.ascx.vb" Inherits="CtrlUsr_ConsultaTer" %>
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
                CausesValidation="False" CommandName="Buscar" ImageUrl="~/images/Operaciones/search2.png"
                OnClick="BtnBuscar_Click" /></td>
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
            DataKeyNames="ter_nit" DataSourceID="ObjTerceros" OnRowCommand="GridView1_RowCommand"
            OnRowDataBound="GridView1_RowDataBound" OnSelectedIndexChanged="GridView1_SelectedIndexChanged"
            ShowFooter="True">
            <Columns>
                <asp:TemplateField HeaderText="Tipo Doc" SortExpression="TER_TDOC">
                    <ItemTemplate>
                        <asp:Label ID="LbNom" runat="server" Text='<%# Bind("TER_TDOC") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="N&#176; Identificaci&#243;n" SortExpression="TER_NIT">
                    <ItemTemplate>
                        <asp:Label ID="LbUni1" runat="server" Text='<%# Bind("TER_NIT") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Nombre" SortExpression="TER_NOM">
                    <ItemTemplate>
                        <asp:Label ID="LbUni2" runat="server" Text='<%# Bind("TER_NOM") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Municipio" SortExpression="TER_MPIO">
                    <ItemTemplate>
                        <asp:Label ID="LbBar" runat="server" Text='<%# Bind("TER_MPIO") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Telefono" SortExpression="TER_TEL">
                    <ItemTemplate>
                        <asp:Label ID="LbNor" runat="server" Text='<%# Bind("TER_TEL") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Observaci&#243;n" SortExpression="TER_OBS">
                    <ItemTemplate>
                        <asp:Label ID="LbObs" runat="server" Text='<%# Bind("TER_OBS") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                  <asp:TemplateField >
                    <ItemStyle HorizontalAlign="Center" Width="16px" />
                    <ItemTemplate>
                        <img alt="Enviar" title="Enviar Registro" onmouseover="this.style.cursor = 'hand'" onmouseout="this.style.cursor = 'auto'" src="../../images/Operaciones/Select.png" onclick="javascript:enviar('<%# Eval("TER_TDOC") %>','<%# Eval("TER_NIT") %>','<%# Eval("TER_DVER") %>','<%# Eval("TER_NOM") %>','<%= Me.Tipo %>');"  />
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
&nbsp; &nbsp;<asp:ObjectDataSource ID="ObjTerceros" runat="server" SelectMethod="GetRecords" TypeName="Signus.Terceros">
    <SelectParameters>
        <asp:ControlParameter ControlID="TxtFilNom" Name="busc" PropertyName="Text" Type="String" />
    </SelectParameters>
</asp:ObjectDataSource>
