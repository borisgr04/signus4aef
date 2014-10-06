<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="PorNFormulario.aspx.vb" Inherits="Consultas_PorNFormulario_PorNFormulario" title="Página sin título" %>

<%@ Register src="../../CtrlUsr/Liq/CU_ConLiq.ascx" tagname="CU_ConLiq" tagprefix="uc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="SampleContent" Runat="Server">
    <div class="demoarea">
        <br />
 
<asp:Label ID="LBTITULO" runat="server" CssClass="Titulo">CONSULTA POR NÚMERO DE FORMULARIO</asp:Label>
    <table >
        <tr>
            <td style="width: 201px">
                &nbsp;</td>
            <td style="width: 173px">
                &nbsp;</td>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td style="width: 201px">
                <asp:Label ID="Label2" runat="server" Text="N° LIQUIDACIÓN"></asp:Label>
            </td>
            <td style="width: 173px">
                <asp:TextBox ID="TxtNLiq" runat="server" AutoPostBack="True"></asp:TextBox>
            </td>
            <td>
                <asp:Button ID="BtnBuscar" runat="server" Text="Buscar" />
            </td>
            <td>
                &nbsp;</td>
        </tr>
                
        </table>
    <br />
    <uc1:CU_ConLiq ID="CU_ConLiq1" runat="server" />
    
</div>
</asp:Content>

