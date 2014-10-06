<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="Admin.aspx.vb" Inherits="Seguridad_Roles_Admin" title="Permisos" %>
<asp:Content ID="Content1" ContentPlaceHolderID="SampleContent" Runat="Server">
<div class="demoarea">
        <ajaxToolkit:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server">
        </ajaxToolkit:ToolkitScriptManager>
        <p>
            &nbsp;<table style="width: 389px; height: 106px">
                <tr>
                    <td style="width: 149px; height: 44px">
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
                    <td style="width: 131px; height: 44px">
                    </td>
                    <td style="width: 120px; height: 44px">
                    </td>
                </tr>
                <tr>
                    <td colspan="3">
        <asp:Label ID="MsgResult" runat="server" Font-Bold="False"></asp:Label></td>
                    <td colspan="1">
                    </td>
                    <td colspan="1" style="width: 100px">
                        &nbsp;</td>
                    <td colspan="1" style="width: 131px">
                        <asp:HyperLink ID="HyperLink2" runat="server" 
                            NavigateUrl="~/Seguridad/AsigClave/RegUsuarios.aspx">Nuevo Usuario</asp:HyperLink>
                    </td>
                    <td colspan="1" style="width: 120px">
                        <asp:HyperLink ID="HyperLink3" runat="server" 
                            NavigateUrl="~/Seguridad/Usuarios/UsuarioCon.aspx" Visible="False">Ver Usuarios en Linea</asp:HyperLink>
                    </td>
                </tr>
                <tr>
                    <td style="width: 149px">
                        Digite UserName o Nombre:</td>
                    <td style="width: 125px">
        <asp:TextBox ID="TxtUserName" runat="server" AutoPostBack="True"></asp:TextBox>&nbsp;
                    </td>
                    <td style="width: 100px">
                        &nbsp;<asp:Button ID="LookupBtn" runat="server" Text="Buscar" /></td>
                    <td style="width: 100px">
                    <asp:Button ID="btnAct" runat="server" Text="Actualizar" Visible="False" /></td>
                    <td style="width: 100px">
                        <asp:Button ID="BtnCargarRoles" runat="server" Text="Cargar Roles" />
                    </td>
                    <td style="width: 131px">
                    </td>
                    <td style="width: 120px">
                    </td>
                </tr>
                <tr>
                    <td style="width: 149px">
                        &nbsp;</td>
                    <td style="width: 125px">
                        &nbsp;</td>
                    <td style="width: 100px">
                        &nbsp;</td>
                    <td style="width: 100px">
                        &nbsp;</td>
                    <td style="width: 100px">
                        &nbsp;</td>
                    <td style="width: 131px">
                        &nbsp;</td>
                    <td style="width: 120px">
                        &nbsp;</td>
                </tr>
                <tr>
                    <td colspan="7">
                        <asp:GridView ID="GridView1" runat="server" AllowPaging="True" AllowSorting="True"
                            AutoGenerateColumns="False" DataSourceID="ObjUser" Width="799px" 
                            DataKeyNames="username">
                            <Columns>
                                <asp:BoundField DataField="UserName" HeaderText="UserName" ReadOnly="True" SortExpression="UserName" />
                                <asp:BoundField DataField="Ter_Nom" HeaderText="Nombre o Razon Social" />
                                <asp:BoundField DataField="LastLockoutDate" HeaderText="LastLockoutDate" ReadOnly="True"
                                    SortExpression="LastLockoutDate" />
                                <asp:BoundField DataField="CreateDate" HeaderText="Fecha de Creaci&#243;n" ReadOnly="True"
                                    SortExpression="CreateDate" />
                                <asp:BoundField DataField="LastLoginDate" HeaderText="LastLoginDate" SortExpression="LastLoginDate" />
                                <asp:BoundField DataField="LastActivityDate" HeaderText="LastActivityDate" SortExpression="LastActivityDate" />
                                <asp:BoundField DataField="LastPasswordChangedDate" HeaderText="LastPasswordChangedDate"
                                    ReadOnly="True" SortExpression="LastPasswordChangedDate" />
                                <asp:TemplateField HeaderText="Activo" SortExpression="ISAPPROVED">
                                <ItemTemplate>
                                        <asp:CheckBox ID="CheckBoxA" runat="server" 
                                            Checked='<%# IIF(Container.DataItem("ISAPPROVED")=1,true,false) %>' 
                                            Enabled="false" />
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Bloqueado" SortExpression="ISLOCKEDOUT">
                                <ItemTemplate>
                                        <asp:CheckBox ID="CheckBoxL" runat="server" Checked='<%# IIF(Container.DataItem("ISLOCKEDOUT")=1,true,false) %>' 
                                            Enabled="false" />
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:CommandField ButtonType="Image" SelectImageUrl="~/images/Operaciones/Select.png"
                                    ShowSelectButton="True" />
                                <asp:ButtonField CommandName="Activar" Text="Activar/Inactivar" />
                                <asp:ButtonField CommandName="Desbloquear" Text="Desbloquear" />
                            </Columns>
                        </asp:GridView>
                    </td>
                </tr>
                <tr>
                    <td colspan="7">
                        <asp:ObjectDataSource ID="ObjUser" runat="server" SelectMethod="GetRecords" TypeName="Usuarios">
                            <SelectParameters>
                                <asp:ControlParameter ControlID="TxtUserName" Name="busc" PropertyName="Text" />
                            </SelectParameters>
                        </asp:ObjectDataSource>
                        &nbsp;<asp:HiddenField ID="HdFiltro" runat="server" />
                    </td>
                </tr>
            </table>
        </p>
        
  
       <p> &nbsp; &nbsp; &nbsp;
    
        <table style="width: 693px; height: 331px">
            <tr>
                <td valign="top" colspan="3">
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

