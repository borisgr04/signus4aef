<%@ Page Title="" Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="RegSoportePago.aspx.vb" Inherits="SoportesPagos_Agentes_RegSoportePago" %>

<asp:Content ID="Content1" ContentPlaceHolderID="SampleContent" Runat="Server">

    <div class="demoarea">
        <ajaxToolkit:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server" EnablePageMethods="true" EnableScriptGlobalization="True" EnableScriptLocalization="True">
    </ajaxToolkit:ToolkitScriptManager>
        <asp:Label ID="LBTITULO" runat="server" CssClass="Titulo">REGISTRO DE SOPORTES DE PAGO</asp:Label>&nbsp;

        <table style="width: 100%">
            
            <tr>
                <td colspan="2">
                    <asp:Label ID="msgResult" runat="server" SkinID="MsgResult" Width="90%" Height="30px"></asp:Label>
                </td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td>N° Declaración</td>
                <td>
                    <asp:TextBox ID="txtNDec" runat="server"></asp:TextBox>
                </td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td>Valor Pagado</td>
                <td>
                    <asp:TextBox ID="txtValPag" runat="server"></asp:TextBox>
                </td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td>Fecha de Pago</td>
                <td>
                    <asp:TextBox ID="txtFecPag" runat="server"></asp:TextBox>
                    <ajaxToolkit:CalendarExtender id="CalendarExtender1" runat="server"  TargetControlID="txtFecPag" >
                </ajaxToolkit:CalendarExtender> 
                </td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td>Cuenta Bancaria</td>
                <td>
                    <asp:DropDownList ID="CboCuentaBancaria" runat="server" DataSourceID="ObjCuentas" DataTextField="CTA_NRO" DataValueField="CTA_NRO">
                    </asp:DropDownList>
                    <asp:ObjectDataSource ID="ObjCuentas" runat="server" SelectMethod="GetCuentas" TypeName="BLL.Pagos_SopBLL"></asp:ObjectDataSource>
                </td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td>Medio de Pago</td>
                <td>
                    <asp:RadioButtonList ID="rblMedioPago" runat="server" RepeatDirection="Horizontal">
                        <asp:ListItem Value="T">Transferencia</asp:ListItem>
                        <asp:ListItem Value="C">Consignación</asp:ListItem>
                    </asp:RadioButtonList>
                </td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td>Documento Soporte</td>
                <td>
                    <asp:FileUpload ID="fupSoporte" runat="server" />
                </td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td>&nbsp;</td>
                <td>
                    <asp:Button ID="BtnGuardar" runat="server" Text="Guardar" />
                &nbsp;
                    <asp:Button ID="BtnVolver" runat="server" Text="Volver " />
                </td>
                <td>&nbsp;</td>
            </tr>
        </table>

    </div>

</asp:Content>

