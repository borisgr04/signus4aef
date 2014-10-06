<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="Admin2.aspx.vb" Inherits="admin_admin" title="Untitled Page" %>

<asp:Content ID="Content1" ContentPlaceHolderID="SampleContent" Runat="Server">
<div class="demoarea">
        <ajaxToolkit:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server">
        </ajaxToolkit:ToolkitScriptManager>
        <p>
            &nbsp;<table style="width: 389px; height: 106px">
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
                </tr>
                <tr>
                    <td colspan="3">
        <asp:Label ID="Result" runat="server" Font-Bold="False"></asp:Label></td>
                    <td colspan="1">
                    </td>
                </tr>
                <tr>
                    <td style="width: 100px">
                        Digite UserName:</td>
                    <td style="width: 125px">
        <asp:TextBox ID="TxtUserName" runat="server"></asp:TextBox></td>
                    <td style="width: 100px">
        
        <asp:Button ID="LookupBtn" runat="server" Text="Buscar" />
                    </td>
                    <td style="width: 100px">
                    <asp:Button ID="btnAct" runat="server" Text="Actualizar" Visible="False" /></td>
                </tr>
            </table>
        </p>
        
  
       <p> &nbsp; &nbsp; &nbsp; &nbsp;
           <asp:DetailsView ID="DetailsView1" runat="server" AllowPaging="True" AutoGenerateRows="False"
               CellPadding="4" DataSourceID="ObjUser" ForeColor="#333333" GridLines="None" Height="50px"
               Width="336px">
               <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
               <CommandRowStyle BackColor="#E2DED6" Font-Bold="True" />
               <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
               <FieldHeaderStyle BackColor="#E9ECF1" Font-Bold="True" />
               <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
               <Fields>
                   <asp:BoundField DataField="UserName" HeaderText="UserName" ReadOnly="True" SortExpression="UserName" />
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
               </Fields>
               <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
               <EditRowStyle BackColor="#999999" />
               <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
           </asp:DetailsView>
    
        <table style="width: 693px; height: 331px">
            <tr>
                <td rowspan="2" valign="top" colspan="3">
                                        <asp:TreeView ID="Tvw" runat="server" ImageSet="Arrows" ShowCheckBoxes="Root" ShowLines="True" Height="100%" Width="400px">
                        <HoverNodeStyle Font-Underline="True" ForeColor="#5555DD" />
                        <NodeStyle Font-Names="Verdana" Font-Size="8pt" ForeColor="Black" HorizontalPadding="5px"
                            NodeSpacing="0px" VerticalPadding="0px" />
                        <ParentNodeStyle Font-Bold="False" />
                        <SelectedNodeStyle Font-Underline="True" ForeColor="#5555DD" HorizontalPadding="0px"
                            VerticalPadding="0px" />
                    </asp:TreeView>
                </td>
            </tr>
              <tr>
            </tr>
        </table>
       </p>
    <p>
        <br />
        &nbsp;
                                        </p>
   

    <div class="roleList">
        &nbsp;</div>
    
    <div>
        &nbsp;
    </div>
    
    </div>
</asp:Content>

