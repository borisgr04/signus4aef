<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="ModPerfil.aspx.vb" Inherits="Seguridad_Perfiles_ModPerfil" title="Untitled Page" %>
<asp:Content ID="Content1" ContentPlaceHolderID="SampleContent" Runat="Server">
<div class="demoarea">
    <asp:ScriptManager id="ScriptManager1" runat="server">
    </asp:ScriptManager><asp:Label ID="lTitulo" runat="server" CssClass="Titulo" Text="GESTION DE PERFILES"
        Width="98%"></asp:Label><br />
    <asp:Button ID="BtnElimPerfil" runat="server" onclick="BtnElimPerfil_Click" 
                    Text="Eliminar Perfil" />
    <br />
    <asp:UpdatePanel id="UpdatePanel1" runat="server">
        <contenttemplate>
<BR /><TABLE width=700><TBODY><TR><TD class="Titulo" colSpan=2><asp:Label id="Label1" runat="server"></asp:Label></TD></TR><TR><TD colSpan=2><asp:Label id="msgResult" runat="server" Width="100%" Height="30px"></asp:Label> </TD></TR><TR><TD style="WIDTH: 100px">Lista de Perfiles
                <br />
                <br />
                <asp:HyperLink ID="HyperLink1" runat="server" 
                    NavigateUrl="~/Seguridad/Perfiles/crearPerfil.aspx">Crear Nuevo Perfil</asp:HyperLink>             &nbsp;</TD><TD style="WIDTH: 100px">Perfil Seleccionado:<asp:Label id="lbPerfil" runat="server" Font-Bold="True"></asp:Label> </TD></TR><TR><TD style="WIDTH: 100px" vAlign=top><asp:GridView id="GridView1" runat="server" Width="378px" ForeColor="#333333" AllowSorting="True" DataKeyNames="PERFIL" DataSourceID="ObjPerfil" OnSelectedIndexChanged="GridView1_SelectedIndexChanged" GridLines="None" CellPadding="4" OnRowCommand="GridView1_RowCommand" AutoGenerateColumns="False">
<FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White"></FooterStyle>

<RowStyle BackColor="#F7F6F3" ForeColor="#333333"></RowStyle>
<Columns>
<asp:BoundField DataField="Perfil" HeaderText="Perfil"></asp:BoundField>
<asp:ButtonField CommandName="Editar" Text="Editar Opciones"></asp:ButtonField>
<asp:ButtonField CommandName="Asignar_Usuarios" Text="Asignar Usuarios"></asp:ButtonField>
</Columns>

<PagerStyle HorizontalAlign="Center" BackColor="#284775" ForeColor="White"></PagerStyle>

<SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333"></SelectedRowStyle>

<HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White"></HeaderStyle>

<EditRowStyle BackColor="#999999"></EditRowStyle>

<AlternatingRowStyle BackColor="White" ForeColor="#284775"></AlternatingRowStyle>
</asp:GridView> <asp:ObjectDataSource id="ObjPerfil" runat="server" OldValuesParameterFormatString="original_{0}" SelectMethod="GetSisPerfilesP" TypeName="DBMenu"></asp:ObjectDataSource> &nbsp; </TD><TD style="WIDTH: 100px" vAlign=top><asp:MultiView id="MultiView1" runat="server"><asp:View id="View1" runat="server">&nbsp;Opciones Asignadas al Perfil<asp:TreeView id="Tvw" runat="server" ImageSet="Arrows" ShowCheckBoxes="Root" ShowLines="True">
<HoverNodeStyle Font-Underline="True" ForeColor="#5555DD"></HoverNodeStyle>

<NodeStyle HorizontalPadding="5px" NodeSpacing="0px" VerticalPadding="0px" Font-Names="Verdana" Font-Size="8pt" ForeColor="Black"></NodeStyle>

<ParentNodeStyle Font-Bold="False"></ParentNodeStyle>

<SelectedNodeStyle HorizontalPadding="0px" VerticalPadding="0px" Font-Underline="True" ForeColor="#5555DD"></SelectedNodeStyle>
</asp:TreeView> <asp:Button id="Guardar" onclick="Guardar_Click" runat="server" Text="Actualizar"></asp:Button></asp:View> <asp:View id="View2" runat="server"><asp:GridView id="GrdUsuarios" runat="server" ForeColor="#333333" AllowSorting="True" DataSourceID="ObjUsuarios" GridLines="None" CellPadding="4">
<RowStyle BackColor="#F7F6F3" ForeColor="#333333"></RowStyle>
<Columns>
<asp:CommandField SelectImageUrl="~/images/Operaciones/Select.png" ShowSelectButton="True" ButtonType="Image"></asp:CommandField>
</Columns>

<FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White"></FooterStyle>

<PagerStyle HorizontalAlign="Center" BackColor="#284775" ForeColor="White"></PagerStyle>
<EmptyDataTemplate>
<BR />No Hay Usuarios Asignados a este PERFIL
</EmptyDataTemplate>

<SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333"></SelectedRowStyle>

<HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White"></HeaderStyle>

<EditRowStyle BackColor="#999999"></EditRowStyle>

<AlternatingRowStyle BackColor="White" ForeColor="#284775"></AlternatingRowStyle>
</asp:GridView> Username: <asp:TextBox id="TextBox1" runat="server"></asp:TextBox> <BR /><asp:Button id="Button1" runat="server" Width="64px" Text="Agregar"></asp:Button> <asp:Button id="Button2" runat="server" Width="49px" Text="Quitar"></asp:Button> <asp:ObjectDataSource id="ObjUsuarios" runat="server" SelectMethod="GetUserInPerfil" TypeName="DBMenu"><SelectParameters>
<asp:ControlParameter ControlID="GridView1" PropertyName="SelectedValue" Name="Perfil" Type="String"></asp:ControlParameter>
</SelectParameters>
</asp:ObjectDataSource> </asp:View></asp:MultiView>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; </TD></TR><TR><TD style="WIDTH: 100px"><BR />&nbsp;&nbsp;&nbsp; </TD><TD style="WIDTH: 100px">&nbsp;</TD></TR></TBODY></TABLE>
</contenttemplate>
    </asp:UpdatePanel><asp:UpdateProgress id="UpdateProgress1" runat="server" AssociatedUpdatePanelID="UpdatePanel1">
        <progresstemplate>
                <div class="Loading">
                    <img alt="" src="../../images/loading.gif" title="" />
                    Cargando …
                </div>
            </progresstemplate>
    </asp:UpdateProgress><br />
    <br />
    &nbsp;&nbsp;&nbsp;&nbsp;<br />
    </div>
</asp:Content>

