<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="ProbarTarifa.aspx.vb" Inherits="DatosBasicos_Formulaslt1_ProbarTarifa" title="Página sin título" %>

<asp:Content ID="Content1" ContentPlaceHolderID="SampleContent" Runat="Server">
<div class="demoarea">
    <table style="width: 100%">
        <tr>
            <td style="width: 178px; font-weight: 700">
                PRUEBA DE TARIFAS</td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td style="width: 178px">
                Clase Declaracion</td>
            <td>
                <asp:TextBox ID="TxtClaDec" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td style="width: 178px">
                Tipo de Agente</td>
            <td>
                <asp:TextBox ID="TxtTipoAgente" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td style="width: 178px">
                Tipo de Acto</td>
            <td>
                <asp:TextBox ID="TxtTipoActo" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td style="width: 178px">
                Impuesto</td>
            <td>
                <asp:TextBox ID="TxtImpto" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td style="width: 178px">
                fecha</td>
            <td>
                <asp:TextBox ID="TxtFecha" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td style="width: 178px">
                Parametros Generado</td>
            <td>
                <asp:TextBox ID="TxtParametros" runat="server" TextMode="MultiLine" 
                    Width="287px"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td style="width: 178px">
                Tarifa Calculada</td>
            <td>
                <asp:TextBox ID="TxtTarifa" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td style="width: 178px">
                &nbsp;</td>
            <td>
    <asp:Button ID="BtnAceptar" runat="server" Text="Calcular Tarifa" />
            </td>
        </tr>
    </table>
</div>
</asp:Content>

