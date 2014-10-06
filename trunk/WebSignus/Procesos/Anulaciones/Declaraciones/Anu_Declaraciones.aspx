<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="Anu_Declaraciones.aspx.vb" Inherits="Procesos_Anulaciones_Declaraciones_Anu_Declaraciones" title="Página sin título" %>

<%@ Register assembly="eWorld.UI, Version=2.0.6.2393, Culture=neutral, PublicKeyToken=24d65337282035f2" namespace="eWorld.UI" tagprefix="ew" %>

<%@ Register src="../../../CtrlUsr/Liq/CU_ConLiq.ascx" tagname="CU_ConLiq" tagprefix="uc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="SampleContent" Runat="Server">
   
<div class="demoarea">
<asp:Label ID="LBTITULO" runat="server" CssClass="Titulo">ANULACION DE DECLARACION(LIQUDIACIONES/PAGOS) </asp:Label>
<br />
<asp:Label ID="MsgResult" runat="server"></asp:Label>
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
                <asp:Button ID="BtnAnular" runat="server" Text="Anular" />
            </td>
        </tr>
        <tr>
            <td style="width: 201px">
                
            </td>
            <td style="width: 173px">
                &nbsp;</td>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td style="width: 201px">
                <asp:Label ID="Label1" runat="server" Text="TIPO DE ANULACIÓN"></asp:Label>
            </td>
            <td style="width: 173px">
                <asp:DropDownList ID="CboTAnu" runat="server">
                    <asp:ListItem Value="ALIQ">ANULAR LIQUIDACION</asp:ListItem>
                    <asp:ListItem Value="APDE">ANULAR PAGO DE LIQUIDACION</asp:ListItem>
                </asp:DropDownList>
            </td>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td style="width: 201px">
                <asp:Label ID="Label3" runat="server" Text="OBSERVACIÓN"></asp:Label>
            </td>
            <td style="width: 173px">
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
                
                <uc1:CU_ConLiq ID="CU_ConLiq1" runat="server" />
                
                </div>
                        </asp:Content>

