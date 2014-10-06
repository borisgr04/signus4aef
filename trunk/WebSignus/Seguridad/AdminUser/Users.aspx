<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="Users.aspx.vb" Inherits="Seguridad_AdminUser_Users" title="Administrar Usuarios" %>
<asp:Content ID="Content1" ContentPlaceHolderID="SampleContent" Runat="Server">
<div class="demoarea">
    <ajaxtoolkit:toolkitscriptmanager id="ToolkitScriptManager1" runat="server">
        </ajaxtoolkit:toolkitscriptmanager>
    &nbsp;&nbsp;<asp:UpdatePanel id="UpdatePanel1" runat="server"><contenttemplate><table style="width: 389px; height: 106px">
            <tr>
                <td style="width: 100px; height: 44px">
                    <asp:Image ID="Image1" runat="server" Height="45px" ImageUrl="~/images/Permiso.png"
                        Width="63px" /></td>
                <td style="width: 125px; height: 44px">
                    <asp:Label ID="Label1" runat="server" Text="Administrador de Roles"></asp:Label></td>
                <td style="width: 100px; height: 44px">
                </td>
                <td style="width: 100px; height: 44px">
                </td>
                <td style="width: 100px; height: 44px">
                </td>
                <td style="width: 100px; height: 44px">
                </td>
                <td style="width: 100px; height: 44px">
                </td>
            </tr>
            <tr>
                <td colspan="3">
                    <asp:Label ID="MsgResult" runat="server" Font-Bold="False"></asp:Label></td>
                <td colspan="1">
                </td>
                <td colspan="1" style="width: 100px">
                </td>
                <td colspan="1" style="width: 100px">
                </td>
                <td colspan="1" style="width: 100px">
                </td>
            </tr>
            <tr>
                <td style="width: 100px">
                    Digite UserName:</td>
                <td style="width: 125px">
                    <asp:TextBox ID="TxtUserName" runat="server"></asp:TextBox>&nbsp;
                </td>
                <td style="width: 100px">
                    &nbsp;<asp:Button ID="LookupBtn" runat="server" Text="Buscar" /></td>
                <td style="width: 100px">
                    <asp:Button ID="btnIna" runat="server" Text="Desbloquear" OnClick="btnIna_Click" /></td>
                <td style="width: 100px"><asp:Button ID="Eliminar" runat="server" Text="Eliminar" OnClick="Eliminar_Click" /></td>
                <td style="width: 100px">
                </td>
                <td style="width: 100px">
                </td>
            </tr>
            <tr>
                <td colspan="7">
                    <asp:GridView ID="GridView1" runat="server" AllowPaging="True" AllowSorting="True"
                        AutoGenerateColumns="False" DataSourceID="ObjUser" Width="799px" DataKeyNames="UserName" OnSelectedIndexChanged="GridView1_SelectedIndexChanged">
                        <Columns>
                            <asp:BoundField DataField="UserName" HeaderText="UserName" ReadOnly="True" SortExpression="UserName" />
                            <asp:BoundField DataField="LastLockoutDate" HeaderText="LastLockoutDate" ReadOnly="True"
                                SortExpression="LastLockoutDate" />
                            <asp:BoundField DataField="CreateDate" HeaderText="Fecha de Creaci&#243;n" ReadOnly="True"
                                SortExpression="CreateDate" />
                            <asp:BoundField DataField="LastLoginDate" HeaderText="LastLoginDate" SortExpression="LastLoginDate" />
                            <asp:BoundField DataField="LastActivityDate" HeaderText="LastActivityDate" SortExpression="LastActivityDate" />
                            <asp:BoundField DataField="LastPasswordChangedDate" HeaderText="LastPasswordChangedDate"
                                ReadOnly="True" SortExpression="LastPasswordChangedDate" />
                            <asp:CommandField ButtonType="Image" SelectImageUrl="~/images/Operaciones/Select.png"
                                ShowSelectButton="True" />
                        </Columns>
                    </asp:GridView>
                    <asp:ObjectDataSource ID="ObjUser" runat="server" SelectMethod="GetRecords" TypeName="Usuarios">
                        <SelectParameters>
                            <asp:ControlParameter ControlID="TxtUserName" Name="busc" PropertyName="Text" />
                        </SelectParameters>
                    </asp:ObjectDataSource>
                    &nbsp;
                    <asp:HiddenField ID="HdFiltro" runat="server" />
                </td>
            </tr>
        </table></contenttemplate>
    </asp:UpdatePanel>
    <p>
        <asp:UpdateProgress id="UpdateProgress1" runat="server" AssociatedUpdatePanelID="UpdatePanel1">
            <progresstemplate>
            <div class="Loading">
            <img src="../../images/loading.gif" alt="" title="" /> Cargando …
            </div>
        </progresstemplate>
        </asp:UpdateProgress>
        <br />
        &nbsp;</p>
</div>
</asp:Content>

