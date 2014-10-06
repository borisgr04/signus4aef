<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="Anu_Acuerdos.aspx.vb" Inherits="Procesos_Anulaciones_Acuerdos_Anu_Acuerdos" title="Anulaciones de Acuerdos de Pagos" %>

<asp:Content ID="Content1" ContentPlaceHolderID="SampleContent" Runat="Server">
<div class="demoarea">
<asp:Label ID="LBTITULO" runat="server" CssClass="Titulo">ANULACION DE ACUERDOS DE PAGO(ACUERDO/PAGO DE CUOTAS) </asp:Label>
<br />
<asp:Label ID="MsgResult" runat="server" Width="90%"></asp:Label>
 <table >
        <tr>
            <td style="width: 130px">
                &nbsp;</td>
            <td style="width: 200px">
                &nbsp;</td>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td >
                <asp:Label ID="Label2" runat="server" Text="SOPORTE N°"></asp:Label>
            </td>
            <td >
                <asp:TextBox ID="TxtNSop" runat="server" AutoPostBack="True"></asp:TextBox>
            </td>
            <td>
                <asp:Button ID="BtnBuscar" runat="server" Text="Buscar" />
            </td>
            <td>
                <asp:Button ID="BtnAnular" runat="server" Text="Anular" Enabled="False" 
                    EnableTheming="True" />
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="Label1" runat="server" Text="TIPO DE ANULACIÓN"></asp:Label>
            </td>
            <td >
                <asp:DropDownList ID="CboTAnu" runat="server">
                    <asp:ListItem Value="APAP">ANULAR PAGO DE CUOTA ACUERDO</asp:ListItem>
                    <asp:ListItem Value="AAP">ANULAR ACUERDO DE PAGO</asp:ListItem>
                </asp:DropDownList>
            </td>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td>
                ESTADO</td>
            <td >
                <asp:DropDownList ID="cmbEstado" runat="server" Enabled="False">
                    <asp:ListItem Value="AN">ANULADO</asp:ListItem>
                    <asp:ListItem Value="AC">ACTIVO</asp:ListItem>
                    <asp:ListItem Value="DF">DEFINITIVO</asp:ListItem>
                    <asp:ListItem Value="PR">PRESENTADO</asp:ListItem>
                </asp:DropDownList>
            </td>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td>
                AGENTE RETENEDOR</td>
            <td>
                <asp:TextBox ID="tbAgente" runat="server" Width="250px" Enabled="False"></asp:TextBox>
            </td>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td>
                FECHA</td>
            <td >
                <asp:TextBox ID="tbFecha" runat="server" Enabled="False"></asp:TextBox>
            </td>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="Label3" runat="server" Text="OBSERVACIÓN"></asp:Label>
            </td>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td colspan="4">
                <asp:TextBox ID="TxtObs" runat="server" Height="126px" TextMode="MultiLine" 
                    Width="485px"></asp:TextBox>
            </td>
        </tr>
 </table>
</div>
</asp:Content>

