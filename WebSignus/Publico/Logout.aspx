<%@ Page Language="VB" MasterPageFile="~/MPPublic.master" AutoEventWireup="false" CodeFile="Logout.aspx.vb" Inherits="Publico_Logout" title="LogOut" %>
<asp:Content ID="Content1" ContentPlaceHolderID="SampleContent" Runat="Server">
<div class="demoarea">
    <br />
    <br />
    <table style="width: 100%">
        <tr>
            <td style="width: 272px">
                &nbsp;</td>
            <td align="center" style="width: 319px">
    <asp:Label ID="Tit" runat="server" CssClass="Titulo" Text="Signus"
        Width="52px"></asp:Label>
            </td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td style="width: 272px; height: 172px">
            </td>
            <td style="height: 172px; width: 319px; text-align: center;">
                <asp:LoginView ID="LoginView1" runat="server">
                    <LoggedInTemplate>
                        <b>No se pudo cerrar la Sesión.</b><br />
                        Intenta cerrar el navegador y borrar las Cookies y archivos temporales de tu 
                        Navegador de Internet.
                        <br />
                        <asp:LoginStatus ID="LoginStatus1" runat="server" />
                    </LoggedInTemplate>
                    <AnonymousTemplate>
                        <table style="width: 100%">
                            <tr>
                                <td style="width: 52px">
                                    <asp:Image ID="Image1" runat="server" ImageUrl="~/images/Ok.gif" />
                                </td>
                                <td>
                                    <b>
                                    <asp:Label ID="Label3" runat="server" 
                                        Text="CONFIRMACIÓN DEL ESTADO DE LA SESIÓN"></asp:Label>
                                    </b>
                                </td>
                            </tr>
                            <tr>
                                <td colspan="2">
                                    <b>
                                    <asp:Label ID="Label1" runat="server" 
                                        Text="La Sesión se ha Cerrado Satisfactoriamente."></asp:Label>
                                    </b>
                                </td>
                            </tr>
                            <tr>
                                <td colspan="2">
                                    <asp:Label ID="Label2" runat="server" Font-Bold="True" 
                                        Text="Por Seguridad Cierre la Ventana del Navegador" Width="100%"></asp:Label>
                                    <b>
                                    <br />
                                    </b>
                                    <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl="~/Login.aspx">Iniciar Sesión</asp:HyperLink>
                                </td>
                            </tr>
                        </table>
                    </AnonymousTemplate>
                </asp:LoginView>
            </td>
            <td style="height: 172px">
                <br />
            </td>
        </tr>
    </table>
    <br />
    <br />
    <br />
    <br />
    <br />
    <br />
    <br />
    <br />
    <br />
    <br />

</div>
</asp:Content>

