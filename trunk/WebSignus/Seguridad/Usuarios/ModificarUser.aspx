<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="ModificarUser.aspx.vb" Inherits="Seguridad_ModificarUser" title="Untitled Page" %>
<asp:Content ID="Content1" ContentPlaceHolderID="SampleContent" Runat="Server">
    <ajaxToolkit:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server">
    </ajaxToolkit:ToolkitScriptManager>
    <br />
    <br />
    <br />
    <ajaxToolkit:TabContainer ID="TabContainer1" runat="server" ActiveTabIndex="0">
        <ajaxToolkit:TabPanel ID="TabPanel1" runat="server" HeaderText="TabPanel1">
            <ContentTemplate>
                <br />
                &nbsp;<br />
                <asp:ChangePassword ID="ChangePassword1" runat="server" CancelButtonText="Cancelar" ChangePasswordButtonText="Cambiar Contrase�a" ChangePasswordFailureText="Contrase�a Incorrecta o Nueva Contrase�a Inv�lida.Caracteres M�nimos: {0}. Caract�res especiales Requeridos: {1}." ChangePasswordTitleText="Cambie su Contrase�a" ConfirmNewPasswordLabelText="Confirme Nueva Contrase�a:" ConfirmPasswordCompareErrorMessage="La Contrase�a Confirmada debe ser Igual a la Nueva Contrasela." ConfirmPasswordRequiredErrorMessage="Confirmar Nueva Contrase�a esRequerida." ContinueButtonText="Continuar" NewPasswordLabelText="Nueva Contrase�a:" NewPasswordRegularExpressionErrorMessage="Por favor digite una Contrasela diferente." NewPasswordRequiredErrorMessage="Nueva Contrase�a es requerida ." PasswordLabelText="Contrase�a:" PasswordRequiredErrorMessage="Contrase�a es requerida." SuccessText="Tu Contrase�a ha sido cambiada!. No la Olvides" SuccessTitleText="Cambio de Contrase�a Terminado">
                    <ChangePasswordTemplate>
                        <table border="0" cellpadding="1" cellspacing="0" style="border-collapse: collapse">
                            <tr>
                                <td>
                                    <table border="0" cellpadding="0">
                                        <tr>
                                            <td align="center" colspan="2">
                                                Cambie su Contrase�a</td>
                                        </tr>
                                        <tr>
                                            <td align="right">
                                                <asp:Label ID="Label2" runat="server" AssociatedControlID="CurrentPassword">Nombre de Usuario</asp:Label></td>
                                            <td>
                <asp:LoginName ID="LoginName3" runat="server" />
                                            </td>
                                        </tr>
                                        <tr>
                                            <td align="right">
                                                <asp:Label ID="CurrentPasswordLabel" runat="server" AssociatedControlID="CurrentPassword">Contrase�a:</asp:Label></td>
                                            <td>
                                                <asp:TextBox ID="CurrentPassword" runat="server" TextMode="Password"></asp:TextBox>
                                                <asp:RequiredFieldValidator ID="CurrentPasswordRequired" runat="server" ControlToValidate="CurrentPassword"
                                                    ErrorMessage="Contrase�a es requerida." ToolTip="Contrase�a es requerida." ValidationGroup="ChangePassword1">*</asp:RequiredFieldValidator>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td align="right">
                                                <asp:Label ID="NewPasswordLabel" runat="server" AssociatedControlID="NewPassword">Nueva Contrase�a:</asp:Label></td>
                                            <td>
                                                <asp:TextBox ID="NewPassword" runat="server" TextMode="Password"></asp:TextBox>
                                                <asp:RequiredFieldValidator ID="NewPasswordRequired" runat="server" ControlToValidate="NewPassword"
                                                    ErrorMessage="Nueva Contrase�a es requerida ." ToolTip="Nueva Contrase�a es requerida ."
                                                    ValidationGroup="ChangePassword1">*</asp:RequiredFieldValidator>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td align="right">
                                                <asp:Label ID="ConfirmNewPasswordLabel" runat="server" AssociatedControlID="ConfirmNewPassword">Confirme Nueva Contrase�a:</asp:Label></td>
                                            <td>
                                                <asp:TextBox ID="ConfirmNewPassword" runat="server" TextMode="Password"></asp:TextBox>
                                                <asp:RequiredFieldValidator ID="ConfirmNewPasswordRequired" runat="server" ControlToValidate="ConfirmNewPassword"
                                                    ErrorMessage="Confirmar Nueva Contrase�a esRequerida." ToolTip="Confirmar Nueva Contrase�a esRequerida."
                                                    ValidationGroup="ChangePassword1">*</asp:RequiredFieldValidator>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td align="center" colspan="2">
                                                <asp:CompareValidator ID="NewPasswordCompare" runat="server" ControlToCompare="NewPassword"
                                                    ControlToValidate="ConfirmNewPassword" Display="Dynamic" ErrorMessage="La Contrase�a Confirmada debe ser Igual a la Nueva Contrasela."
                                                    ValidationGroup="ChangePassword1"></asp:CompareValidator>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td align="center" colspan="2" style="color: red">
                                                <asp:Literal ID="FailureText" runat="server" EnableViewState="False"></asp:Literal>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td align="right">
                                                <asp:Button ID="ChangePasswordPushButton" runat="server" CommandName="ChangePassword"
                                                    Text="Cambiar Contrase�a" ValidationGroup="ChangePassword1" />
                                            </td>
                                            <td>
                                                <asp:Button ID="CancelPushButton" runat="server" CausesValidation="False" CommandName="Cancel"
                                                    Text="Cancelar" />
                                            </td>
                                        </tr>
                                    </table>
                                </td>
                            </tr>
                        </table>
                    </ChangePasswordTemplate>
                </asp:ChangePassword>
            </ContentTemplate>
            <HeaderTemplate>
                Cambiar Password
            </HeaderTemplate>
        </ajaxToolkit:TabPanel>
        <ajaxToolkit:TabPanel ID="TabPanel2" runat="server" HeaderText="TabPanel2">
            <ContentTemplate>
                <br />
                <asp:LoginName ID="LoginName2" runat="server" FormatString="Usuario : [ {0} ]" />
    <br />
    <table cellpadding="2" style="width: 603px">
        <tr>
            <td colspan="3">
                <asp:Label ID="msgResult" runat="server" Height="30px" Visible="False" Width="100%"></asp:Label></td>
        </tr>
        <tr>
            <td class="demoheading" colspan="3">
                MODIFICAR EMAIL</td>
        </tr>
        <tr>
            <td style="width: 84px">
                <asp:Label ID="Label1" runat="server" Text="Usuario"></asp:Label></td>
            <td colspan="2">
                <asp:TextBox ID="TxtUsername" runat="server" Width="150px"></asp:TextBox>&nbsp;<asp:Button
                    ID="Button1" runat="server" CausesValidation="False" Text="..." /></td>
        </tr>
        <tr>
            <td style="width: 84px; height: 10px">
                Correo Electr�nico</td>
            <td colspan="2" style="height: 10px">
                <asp:TextBox ID="TxtCorreo" runat="server"></asp:TextBox><asp:RequiredFieldValidator
                    ID="RequiredFieldValidator7" runat="server" ControlToValidate="TxtCorreo" ErrorMessage="Valor Requerido"></asp:RequiredFieldValidator>
                <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ErrorMessage="Correo- E inv�lido" ControlToValidate="TxtCorreo" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"></asp:RegularExpressionValidator></td>
        </tr>
        <tr>
            <td colspan="3" style="text-align: center">
                <asp:Button ID="BtnGuardar" runat="server" Enabled="False" Text="Guardar" Width="75px" /><asp:Button ID="BtnCancelar" runat="server" Enabled="False" Text="Cancelar" /></td>
        </tr>
    </table>
            </ContentTemplate>
            <HeaderTemplate>
                Modificar Correo - E
            </HeaderTemplate>
        </ajaxToolkit:TabPanel>
    </ajaxToolkit:TabContainer>&nbsp;<br />
    <table>
        <tr>
            <td style="width: 100px">
            </td>
            <td style="width: 100px">
    Usuario</td>
            <td style="width: 100px">
    <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox></td>
            <td style="width: 411px">
            </td>
        </tr>
        <tr>
            <td style="width: 100px">
            </td>
            <td style="width: 100px">
    Nuevo Contrase�a
            </td>
            <td style="width: 100px">
    <asp:TextBox ID="TextBox2" runat="server"></asp:TextBox></td>
            <td rowspan="2" style="width: 411px">
                Para hacer tu Contrase�a mas Segura utiliza<br />
                -Caracteres Especiales (p ej. @,&amp;,?,etc)<br />
                -Letras y n�meros<br />
                - Mayusculas y minusculas</td>
        </tr>
        <tr>
            <td colspan="2" style="text-align: right">
    Confirmar Contrase�a
            </td>
            <td style="width: 100px">
    <asp:TextBox ID="TextBox3" runat="server"></asp:TextBox></td>
        </tr>
        <tr>
            <td colspan="2" style="text-align: right">
            </td>
            <td style="width: 100px">
    <asp:Button ID="Button2" runat="server" CausesValidation="False" Text="Forzar Password" /></td>
            <td style="width: 411px">
            </td>
        </tr>
    </table>
    <br />
    &nbsp;&nbsp;<br />
    <br />
    <br />
    <br />
    <br />
    <br />
</asp:Content>

