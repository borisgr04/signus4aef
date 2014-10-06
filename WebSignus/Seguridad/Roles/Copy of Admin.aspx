<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="Copy of Admin.aspx.vb" Inherits="admin_admin" title="Untitled Page" %>

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
        
  
       <p> &nbsp; &nbsp; &nbsp;
    
        <table style="width: 693px; height: 331px">
            <tr>
                <td rowspan="2" style="width: 108px" valign="top">
                    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" DataKeyNames="USERNAME"
                        DataSourceID="ObjectDataSource1" Font-Bold="False" Width="219px">
                        <Columns>
                            <asp:CommandField SelectText="" ShowSelectButton="True" ButtonType="Image" SelectImageUrl="~/images/Operaciones/Select.png" />
                            <asp:BoundField DataField="UserName" HeaderText="Usuario" ReadOnly="True" SortExpression="UserName" />
                        </Columns>
                    </asp:GridView>
                    <asp:ObjectDataSource ID="ObjectDataSource1" runat="server" SelectMethod="GetRecords"
                        TypeName="Usuarios">
                        <SelectParameters>
                            <asp:ControlParameter ControlID="TxtUserName" Name="busc" PropertyName="Text" Type="String" />
                        </SelectParameters>
                    </asp:ObjectDataSource>
                    <br />
                </td>
                <td style="width: 18px" rowspan="2"> &nbsp;
                </td>
                <td rowspan="2" style="width: 142px" valign="top">
                    &nbsp;&nbsp;
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

