<%@ Page Title="" Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="Vh_Log.aspx.vb" Inherits="Declaraciones_Vh_Diligenciar_Vh_Log" %>

<asp:Content ID="Content1" ContentPlaceHolderID="SampleContent" Runat="Server">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
<div class="demoarea">
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
    <ContentTemplate>
        <table style="width: 100%;">
            <tr>
                <td>
                    <strong>LISTADO DE IMPRESION</strong></td>
                <td>
                    &nbsp;</td>
                <td>
                    &nbsp;</td>
                <td style="text-align: right">
                    <asp:HyperLink ID="HyperLink1" runat="server" 
                        NavigateUrl="~/Declaraciones/Vh_Diligenciar/SelDec.aspx">Nueva Liquidación</asp:HyperLink>
                </td>
            </tr>
            <tr>
                <td colspan="4">
                    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" 
                        EnableModelValidation="True">
                        <Columns>
                            <asp:BoundField DataField="Nro_LiqG" HeaderText="Nro_LiqG" />
                            <asp:BoundField DataField="Desde" HeaderText="Desde" />
                            <asp:BoundField DataField="Hasta" HeaderText="Hasta" />
                            <asp:HyperLinkField DataNavigateUrlFields="Nro_LiqG,Desde,Hasta" 
                                DataNavigateUrlFormatString="~/ashx/RptForm_LG.aspx?Nro_LiqG={0}&amp;Desde={1}&amp;Hasta={2}" 
                                Text="Imprimir" />
                        </Columns>
                    </asp:GridView>
&nbsp;
                </td>
            </tr>
            <tr>
                <td colspan="2">
                    <strong>REGISTRO DE LOG DE LIQUIDACION</strong></td>
                <td colspan="2">
                    &nbsp;</td>
            </tr>
            <tr>
                <td colspan="2">
                    <asp:ImageButton ID="IBtnExportar" runat="server" 
                        ImageUrl="~/images/imagev2/excel2007.gif" />
                </td>
                <td colspan="2">
                    &nbsp;</td>
            </tr>
            <tr>
                <td colspan="2">
                    Exportar</td>
                <td colspan="2">
                    &nbsp;</td>
            </tr>
            <tr>
                <td colspan="4">
                    <asp:GridView ID="GridLog" runat="server" AutoGenerateColumns="False">
                        <Columns>
                            <asp:BoundField DataField="NRO_LIQG" HeaderText="Liq. Grupo" />
                            <asp:BoundField DataField="PLACA" HeaderText="Placa" />
                            <asp:BoundField DataField="OBSERVACION" HeaderText="Observacion" />
                            <asp:BoundField DataField="LIQUIDO" HeaderText="Liquido" />
                            <asp:BoundField DataField="CATEGORIA_LIQ" 
                                HeaderText="Categoria de Liquidacion" />
                            <asp:BoundField DataField="FECHA_REG" DataFormatString="{0:d}" 
                                HeaderText="Fecha de Registro" />
                        </Columns>
                    </asp:GridView>
                </td>
            </tr>
        </table>
        <br />
        <br />

    </ContentTemplate>
        <Triggers>
            <asp:PostBackTrigger ControlID="IBtnExportar" />
        </Triggers>
    </asp:UpdatePanel>
</div>
</asp:Content>

