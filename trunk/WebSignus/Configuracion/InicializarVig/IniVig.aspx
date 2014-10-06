<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="IniVig.aspx.vb" Inherits="Configuracion_InicializarVig_IniVig" title="Untitled Page" %>
<asp:Content ID="Content1" ContentPlaceHolderID="SampleContent" Runat="Server">
<div class="demoarea">
    <ajaxToolkit:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server" EnableScriptGlobalization="true"
        EnableScriptLocalization="true">
    </ajaxToolkit:ToolkitScriptManager>
    <br />
<%--    <asp:UpdatePanel id="UpdatePanel1" runat="server">
        <contenttemplate>--%>
<asp:Label id="Tit" runat="server" Width="286px" Text="Inicialización de Vigencias" CssClass="Titulo"></asp:Label><BR /><asp:Label id="MsgResult" runat="server"></asp:Label><BR /><asp:DropDownList id="CboVig" runat="server" DataSourceID="objVig" DataTextField="vig_cod" DataValueField="vig_cod"></asp:DropDownList> <asp:ObjectDataSource id="objVig" runat="server" TypeName="Vigencias" SelectMethod="getrecords"></asp:ObjectDataSource><BR /><asp:Label id="St" runat="server" Text="TRASLADAR CONFIGURACIONES" CssClass="SubTitulo"></asp:Label><BR /><asp:CheckBoxList id="CheckBoxList1" runat="server"><asp:ListItem Value="Calendario">Calendario Tributario</asp:ListItem>
<asp:ListItem Value="Cont_Peri">Periodos Contables</asp:ListItem>
<asp:ListItem Value="Consecutivos">Consecutivos de Documentos </asp:ListItem>
<asp:ListItem Value="requi_declaracion">Requisitos Declaracion</asp:ListItem>
<asp:ListItem Value="tarifas">Tarifas </asp:ListItem>
<asp:ListItem Value="formularios">Formularios Declaracion </asp:ListItem>
</asp:CheckBoxList><BR />&nbsp;
            <asp:Button ID="BtnTras" runat="server" Text="Trasladar" />
<%--</contenttemplate>
    </asp:UpdatePanel>
--%>    <br />
    <br />
    <br />
    <br />
    <br />
</div>
</asp:Content>

