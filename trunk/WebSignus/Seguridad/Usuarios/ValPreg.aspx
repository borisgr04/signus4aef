<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="ValPreg.aspx.vb" Inherits="Seguridad_Usuarios_ValPreg" title="Untitled Page" ValidateRequest="false" %>
<asp:Content ID="Content1" ContentPlaceHolderID="SampleContent" Runat="Server">
    <div class="demoarea">
        <asp:Label ID="Label1" runat="server" Text="Label"></asp:Label><br />
        <table>
            <tr>
                <td style="width: 100px">
        Usuario</td>
                <td style="width: 100px">
                    <asp:TextBox ID="TxtDes" runat="server" Width="334px">borisgr04@hotmail.com,elreggue_18@hotmail.com,anyamiyeth@hotmail.com</asp:TextBox></td>
                <td style="width: 100px">
                </td>
            </tr>
            <tr>
                <td style="width: 100px">
                    Asunto
                </td>
                <td style="width: 100px">
                    <asp:TextBox ID="TxtAsunto" runat="server" Width="447px"></asp:TextBox></td>
                <td style="width: 100px">
                </td>
            </tr>
            <tr>
                <td style="width: 100px">
                </td>
                <td style="width: 100px">
                </td>
                <td style="width: 100px">
                </td>
            </tr>
            <tr>
                <td style="width: 100px" valign="top">
                    Cuerpo &nbsp;</td>
                <td style="width: 100px">
        <asp:TextBox ID="TxtCuerpo" runat="server" Height="120px" TextMode="MultiLine" Width="448px"></asp:TextBox></td>
                <td style="width: 100px">
                </td>
            </tr>
            <tr>
                <td style="width: 100px; height: 19px" valign="top">
                </td>
                <td style="width: 100px; height: 19px">
                </td>
                <td style="width: 100px; height: 19px">
                </td>
            </tr>
        </table>
        <asp:Label ID="Msg" runat="server" Text="Mensaje" Width="400px"></asp:Label><br />
        <br />
        <asp:Button ID="Button1" runat="server" Text="Enviar" /><br />
        <br />
        <br />
    </div>
</asp:Content>

