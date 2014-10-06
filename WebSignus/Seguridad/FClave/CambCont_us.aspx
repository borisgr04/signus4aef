<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="CambCont_us.aspx.vb" Inherits="Seguridad_Usuarios_Cam_CambCont_us" title="Untitled Page" %>

<asp:Content ID="Content1" ContentPlaceHolderID="SampleContent" Runat="Server">
<div class="demoarea">
    <ajaxToolkit:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server">
    </ajaxToolkit:ToolkitScriptManager>
    &nbsp;
    <asp:Label ID="Tit" runat="server" CssClass="Titulo" Text="Forzar Cambio de Contraseña"></asp:Label>
    <br />
    <asp:Label ID="LMSgBox" runat="server"   Height="100%" Width="80%"></asp:Label><br />
    <asp:ValidationSummary ID="ValidationSummary1" runat="server" />
    &nbsp;<br />
    <table style="text-align: center">
        <tr>
            <td style="width: 20px; height: 22px">
            </td>
            <td style="width: 171px; height: 22px; text-align: right">
                Usuario &nbsp;</td>
            <td style="width: 183px; height: 22px">
                <asp:TextBox ID="Tus" runat="server"></asp:TextBox></td>
            <td style="width: 389px; height: 22px">
                <asp:RequiredFieldValidator ID="ReqUs" runat="server" ControlToValidate="Tus" ErrorMessage="Digite el Usuario"
                    ValidationGroup="Forzar">*</asp:RequiredFieldValidator></td>
        </tr>
        <tr>
            <td style="width: 20px; height: 23px">
            </td>
            <td style="width: 171px; height: 23px; text-align: right">
                Nuevo Contraseña
            </td>
            <td style="width: 183px; height: 23px">
                <asp:TextBox ID="Tcont" runat="server" TextMode="Password"></asp:TextBox></td>
            <td style="width: 389px; height: 23px; text-align: left;">
                <asp:RequiredFieldValidator ID="ReqNuev" runat="server" ControlToValidate="Tcont"
                    ErrorMessage="Digite la Comfirmacio0n de la Contraseña" ValidationGroup="Forzar">*</asp:RequiredFieldValidator>
                <asp:Label ID="TxtClave_HelpLabel" runat="server"></asp:Label></td>
        </tr>
        <tr>
            <td colspan="2" style="text-align: right">
                Confirmar Contraseña
            </td>
            <td style="width: 183px">
                <asp:TextBox ID="Tconf" runat="server" TextMode="Password"></asp:TextBox></td>
            <td style="width: 389px; text-align: left;">
                <asp:RequiredFieldValidator ID="ReqConf" runat="server" ControlToValidate="Tconf"
                    ErrorMessage="Digite el Usuario" ValidationGroup="Forzar">*</asp:RequiredFieldValidator><asp:Label
                        ID="TxtClave2_HelpLabel" runat="server"></asp:Label></td>
        </tr>
        <tr>
            <td style="width: 20px">
            </td>
            <td colspan="2" style="text-align: center">
                &nbsp;</td>
            <td style="width: 389px">
            </td>
        </tr>
        <tr>
            <td style="width: 20px; height: 19px">
            </td>
            <td colspan="2" style="height: 19px; text-align: center">
                <asp:Button ID="BTfor" runat="server" CausesValidation="False" OnClick="BTfor_Click"
                    Text="Forzar Cambio de Contraseña" ValidationGroup="Forzar" /></td>
            <td style="width: 389px; height: 19px">
            </td>
        </tr>
    </table>
    <ajaxToolkit:PasswordStrength ID="PasswordStrength2" runat="server" BarBorderCssClass="BarBorder_TextBox2"
        DisplayPosition="RightSide" HelpStatusLabelID="TxtClave_HelpLabel" MinimumNumericCharacters="1"
        MinimumSymbolCharacters="1" PreferredPasswordLength="8" RequiresUpperAndLowerCaseCharacters="false"
        StrengthIndicatorType="BarIndicator" StrengthStyles="BarIndicator_TextBox2_weak;BarIndicator_TextBox2_average;BarIndicator_TextBox2_good"
        TargetControlID="Tconf" TextStrengthDescriptions="Very Poor;Weak;Average;Strong;Excellent">
    </ajaxToolkit:PasswordStrength>
    <ajaxToolkit:PasswordStrength ID="PasswordStrength1" runat="server" BarBorderCssClass="BarBorder_TextBox2"
        DisplayPosition="RightSide" HelpStatusLabelID="TxtClave2_HelpLabel" MinimumNumericCharacters="1"
        MinimumSymbolCharacters="1" PreferredPasswordLength="8" RequiresUpperAndLowerCaseCharacters="true"
        StrengthIndicatorType="BarIndicator" StrengthStyles="BarIndicator_TextBox2_weak;BarIndicator_TextBox2_average;BarIndicator_TextBox2_good"
        TargetControlID="Tcont" TextStrengthDescriptions="Very Poor;Weak;Average;Strong;Excellent">
    </ajaxToolkit:PasswordStrength>
</div>
</asp:Content>

