<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="Change.aspx.vb" Inherits="Seguridad_PassWord_Change" title="Untitled Page" %>
<%@ Register src="../../CtrlUsr/AyudaIzq/ctrAyudIzql.ascx" tagname="ctrAyudIzql" tagprefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="SampleContent" Runat="Server">
<div class="demoarea" >
    <asp:Label ID="LbTitulo" runat="server" 
                            CssClass="Titulo">CAMBIO DE CONTRASEÑA</asp:Label>
    <uc1:ctrAyudIzql ID="ctrAyudIzql1" runat="server" 
        Mensaje="&lt;br&gt;&lt;b&gt;      Importante!&lt;/b&gt;&lt;br/&gt;&lt;br&gt; &lt;b&gt;Cignus&lt;/b&gt; por Seguridad exige una contraseña segura.&lt;br/&gt; -&lt;b&gt; Caracteres Mínimos&lt;/b&gt; (6) seis - Letras o Números &lt;br/&gt;-&lt;b&gt; Caracteres Especiales Requeridos&lt;/b&gt; 1 (uno) Ejemplo @ ! . ' * + &lt;br/&gt;- &lt;b&gt;Cambie su Contraseña &lt;/b&gt; de manera periodica." />
    <asp:ChangePassword ID="ChangePassword1" runat="server"
        ChangePasswordButtonText="Cambiar Contraseña" ChangePasswordFailureText="Contraseña Incorrecta o Nueva Contraseña Inválida.Caracteres Mínimos: {0}. Caractéres especiales Requeridos: {1}."
        ChangePasswordTitleText="Cambie su Contraseña" ConfirmNewPasswordLabelText="Confirme Nueva Contraseña:"
        ConfirmPasswordCompareErrorMessage="La Contraseña Confirmada debe ser Igual a la Nueva Contrasela."
        
        ConfirmPasswordRequiredErrorMessage="Confirmar Nueva Contraseña esRequerida." 
        NewPasswordLabelText="Nueva Contraseña:" NewPasswordRegularExpressionErrorMessage="Por favor digite una Contrasela diferente."
        NewPasswordRequiredErrorMessage="Nueva Contraseña es requerida ."
        PasswordRequiredErrorMessage="Contraseña es requerida." SuccessText="Tu Contraseña ha sido cambiada!. No la Olvides"
        SuccessTitleText="Cambio de Contraseña Terminado" Height="99px" 
        Width="343px">
        <ChangePasswordTemplate>
                        <table cellpadding="5px" >
                            <tr>
                                <td align="right">
                                    &nbsp;</td>
                                <td>
                                    &nbsp;</td>
                            </tr>
                            <tr>
                                <td align="right">
                                    <asp:Label ID="Label2" runat="server" AssociatedControlID="CurrentPassword">Nombre de Usuario</asp:Label>
                                </td>
                                <td>
                                    <asp:LoginName ID="LoginName3" runat="server" />
                                </td>
                            </tr>
                            <tr>
                                <td align="right">
                                    <asp:Label ID="CurrentPasswordLabel" runat="server" AssociatedControlID="CurrentPassword">Contraseña Actual:</asp:Label></td>
                                <td>
                                    <asp:TextBox ID="CurrentPassword" runat="server" TextMode="Password"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="CurrentPasswordRequired" runat="server" ControlToValidate="CurrentPassword"
                                        ErrorMessage="Contraseña es requerida." ToolTip="Contraseña es requerida." ValidationGroup="ChangePassword1">*</asp:RequiredFieldValidator>
                                </td>
                            </tr>
                            <tr>
                                <td align="right">
                                    &nbsp;</td>
                                <td>
                                    &nbsp;</td>
                            </tr>
                            <tr>
                                <td align="right">
                                    <asp:Label ID="NewPasswordLabel" runat="server" AssociatedControlID="NewPassword">Nueva Contraseña:</asp:Label></td>
                                <td>
                                    <asp:TextBox ID="NewPassword" runat="server" TextMode="Password"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="NewPasswordRequired" runat="server" ControlToValidate="NewPassword"
                                        ErrorMessage="Nueva Contraseña es requerida ." ToolTip="Nueva Contraseña es requerida ."
                                        ValidationGroup="ChangePassword1">*</asp:RequiredFieldValidator>
                                </td>
                            </tr>
                            <tr>
                                <td align="right">
                                    <asp:Label ID="ConfirmNewPasswordLabel" runat="server" AssociatedControlID="ConfirmNewPassword">Confirme Nueva Contraseña:</asp:Label></td>
                                <td>
                                    <asp:TextBox ID="ConfirmNewPassword" runat="server" TextMode="Password"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="ConfirmNewPasswordRequired" runat="server" ControlToValidate="ConfirmNewPassword"
                                        ErrorMessage="Confirmar Nueva Contraseña esRequerida." ToolTip="Confirmar Nueva Contraseña esRequerida."
                                        ValidationGroup="ChangePassword1">*</asp:RequiredFieldValidator>
                                </td>
                            </tr>
                            <tr>
                                <td align="center" colspan="2">
                                    <asp:CompareValidator ID="NewPasswordCompare" runat="server" ControlToCompare="NewPassword"
                                        ControlToValidate="ConfirmNewPassword" Display="Dynamic" ErrorMessage="La Contraseña Confirmada debe ser Igual a la Nueva Contrasela."
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
                                        Text="Cambiar Contraseña" ValidationGroup="ChangePassword1" />
                                </td>
                                <td>
                                    <asp:Button ID="CancelPushButton" runat="server" CausesValidation="False" CommandName="Cancel"
                                        Text="Cancelar" Width="129px" />
                                </td>
                            </tr>
                        </table>
                        <asp:Label ID="Label1" runat="server" AssociatedControlID="CurrentPassword" 
                            CssClass="Titulo"></asp:Label>
            
        </ChangePasswordTemplate>
        <SuccessTemplate>
            <table border="0" cellpadding="1" cellspacing="0" 
                style="border-collapse:collapse;">
                <tr>
                    <td>
                        <table border="0" cellpadding="0" style="height:99px;width:343px;">
                            <tr>
                                <td align="center">
                                    <asp:Label ID="Label4" runat="server" 
                                        Text="&lt;b&gt;Cambio de Contraseña Terminado&lt;/b&gt;"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td style="text-align: center">
                                    <asp:Label ID="Label3" runat="server" 
                                        Text="&lt;b&gt;Tu Contraseña ha sido cambiada!. No la Olvides&lt;/b&gt;"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td align="right">
                                    <asp:Button ID="ContinuePushButton" runat="server" CausesValidation="False" 
                                        CommandName="Continue" Text="Continuar" 
                                        onclick="ContinuePushButton_Click" />
                                </td>
                            </tr>
                        </table>
                    </td>
                </tr>
            </table>
        </SuccessTemplate>
    </asp:ChangePassword>
    &nbsp;<br />
    &nbsp;</div>
</asp:Content>

