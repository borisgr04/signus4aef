<%@ Page Language="VB" MasterPageFile="~/MPPublic.master" AutoEventWireup="false" CodeFile="RecupClave.aspx.vb" Inherits="Publico_RecupClave" title="Restaurar Contraseña" %>
<asp:Content ID="Content1" ContentPlaceHolderID="SampleContent" Runat="Server">
<div class="demoarea">
    <asp:Label ID="Tit" runat="server" CssClass="Titulo" Text="Restaurar Contraseña"
        Width="286px"></asp:Label><br />
    <asp:Label ID="Label2" runat="server" CssClass="Mensaje" Height="44px" Style="left: 3px;
        top: 15px" Text="Digite su nombre de usuario y le será enviada una <b>nueva contraseña</b> al correo que tenga registrado en nuestra base de datos <br> Por <b>Politicas de Seguridad del Sistema</b> de las Contraseña estas no se pueden recuperar.  Cualquier inquetud por favor comuniquese con la oficina de Gestión de Rentas."></asp:Label><br />
    <br />
    <br />
    <br />
    <br />
    <table>
        <tr>
            <td colspan="3" style="height: 18px; text-align: center">
                <br />
    <asp:Label ID="LMSgBox" runat="server" Height="43px" Width="692px"></asp:Label></td>
        </tr>
        <tr>
            <td style="width: 312px; height: 18px">
            </td>
            <td style="width: 156px; height: 18px">
            </td>
            <td style="width: 350px; height: 18px">
            </td>
        </tr>
        <tr>
            <td style="width: 312px">
            </td>
            <td style="width: 156px">
            </td>
            <td style="width: 350px">
            </td>
        </tr>
        <tr>
            <td style="width: 312px; text-align: right;" id="TD3" runat="server">
                <asp:Label ID="Label1" runat="server" Text="Nombre de Usuario" Font-Bold="True" Width="126px"></asp:Label></td>
            <td style="width: 156px" id="TD2" runat="server">
                <asp:TextBox ID="TxtUser" runat="server"></asp:TextBox></td>
            <td style="width: 350px" id="TD1" runat="server">
                <asp:Button ID="Button1" runat="server" Text="Restaurar Contraseña" /></td>
        </tr>
        <tr>
            <td style="width: 312px">
            </td>
            <td style="width: 156px">
            </td>
            <td style="width: 350px">
            </td>
        </tr>
        <tr>
            <td style="width: 312px">
            </td>
            <td style="width: 156px">
            </td>
            <td style="width: 350px">
            </td>
        </tr>
    </table>
    <br />
    <br />
    <br />
    <br />
    <br />
    <br />

</div>
</asp:Content>

