<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="UsuarioCon.aspx.vb" Inherits="Seguridad_UsuarioCon" title="Untitled Page" %>
<asp:Content ID="Content1" ContentPlaceHolderID="SampleContent" Runat="Server">
    <asp:GridView ID="GridView1" runat="server" CellPadding="4" ForeColor="#333333" GridLines="None">
        <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
        <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
        <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
        <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
        <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
        <EditRowStyle BackColor="#999999" />
        <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
    </asp:GridView>
    &nbsp;&nbsp;<br />
    <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
    <br />
    <asp:TextBox ID="TextBox2" runat="server"></asp:TextBox>
    <asp:Button ID="Button3" runat="server" Text="Button" /><br />
    <asp:TextBox ID="TextBox3" runat="server"></asp:TextBox>
    <asp:Button ID="Button1" runat="server" Text="Button" /><br />
    <asp:Button ID="Button2" runat="server" Text="Button" /><br />
    <br />
    <asp:GridView ID="GridView2" runat="server" DataSourceID="ObjectDataSource1">
        <Columns>
            <asp:BoundField DataField="UserName" HeaderText="UserName" ReadOnly="True" SortExpression="UserName" />
            <asp:BoundField DataField="Email" HeaderText="Email" SortExpression="Email" />
            <asp:BoundField DataField="PasswordQuestion" HeaderText="PasswordQuestion" ReadOnly="True"
                SortExpression="PasswordQuestion" />
            <asp:BoundField DataField="Comment" HeaderText="Comment" SortExpression="Comment" />
            <asp:CheckBoxField DataField="IsApproved" HeaderText="IsApproved" SortExpression="IsApproved" />
            <asp:CheckBoxField DataField="IsLockedOut" HeaderText="IsLockedOut" ReadOnly="True"
                SortExpression="IsLockedOut" />
            <asp:BoundField DataField="LastLockoutDate" HeaderText="LastLockoutDate" ReadOnly="True"
                SortExpression="LastLockoutDate" />
            <asp:BoundField DataField="CreationDate" HeaderText="CreationDate" ReadOnly="True"
                SortExpression="CreationDate" />
            <asp:BoundField DataField="LastLoginDate" HeaderText="LastLoginDate" SortExpression="LastLoginDate" />
            <asp:BoundField DataField="LastActivityDate" HeaderText="LastActivityDate" SortExpression="LastActivityDate" />
            <asp:BoundField DataField="LastPasswordChangedDate" HeaderText="LastPasswordChangedDate"
                ReadOnly="True" SortExpression="LastPasswordChangedDate" />
            <asp:CheckBoxField DataField="IsOnline" HeaderText="IsOnline" ReadOnly="True" SortExpression="IsOnline" />
            <asp:BoundField DataField="ProviderName" HeaderText="ProviderName" ReadOnly="True"
                SortExpression="ProviderName" />
        </Columns>
    </asp:GridView>
    <asp:ObjectDataSource ID="ObjectDataSource1" runat="server" SelectMethod="GetAllUsers"
        TypeName="Usuarios"></asp:ObjectDataSource>
    <br />
    &nbsp;
</asp:Content>

