<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="Vigencia.aspx.vb" Inherits="Administración_Vigencia_Vigencia" title="Untitled Page" %>
<asp:Content ID="Content1" ContentPlaceHolderID="SampleContent" Runat="Server">
<div class="demoarea">
    <ajaxToolkit:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server">
    </ajaxToolkit:ToolkitScriptManager>
    <br />
    <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl="~/Administracion/Vigencia/Parametros.aspx">Parametros</asp:HyperLink>&nbsp;
    <asp:HyperLink ID="HyperLink2" runat="server" NavigateUrl="~/Administracion/Vigencia/Consecutivos.aspx">Consecutivos</asp:HyperLink>
    <asp:UpdatePanel id="UpdatePanel1" runat="server">
        <contenttemplate>
    <asp:TextBox ID="txtVig" runat="server"></asp:TextBox>
    <asp:Label ID="MsgResult" runat="server"></asp:Label>
    <asp:Button ID="BtnCrear" runat="server" Text="Crear Vigencia" /><BR />
    <asp:GridView ID="GrdVig" runat="server" DataSourceID="ObjVigencia" AllowPaging="True" CellPadding="4" ForeColor="#333333" GridLines="None"><FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White"></FooterStyle>

<RowStyle BackColor="#F7F6F3" ForeColor="#333333"></RowStyle>
<Columns>
<asp:CommandField ShowSelectButton="True"></asp:CommandField>
</Columns>

<PagerStyle HorizontalAlign="Center" BackColor="#284775" ForeColor="White"></PagerStyle>

<SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333"></SelectedRowStyle>

<HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White"></HeaderStyle>

<EditRowStyle BackColor="#999999"></EditRowStyle>

<AlternatingRowStyle BackColor="White" ForeColor="#284775"></AlternatingRowStyle>
    </asp:GridView>
    <asp:ObjectDataSource ID="ObjVigencia" runat="server" OldValuesParameterFormatString="original_{0}"
        SelectMethod="GetRecords" TypeName="Vigencias"></asp:ObjectDataSource></contenttemplate>
    </asp:UpdatePanel>
    <br />
    &nbsp;<asp:UpdateProgress id="UpdateProgress1" runat="server" AssociatedUpdatePanelID="UpdatePanel1">
        <progresstemplate>
Guardando....
</progresstemplate>
    </asp:UpdateProgress>
    <br />
    &nbsp; &nbsp;&nbsp;
</div>
</asp:Content>

