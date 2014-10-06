<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="cargar_pagos.aspx.vb" Inherits="Declaraciones_Cargar_pagos_cargar_pagos" title="Página sin título" %>

<asp:Content ID="Content1" ContentPlaceHolderID="SampleContent" Runat="Server">

<div class="demoarea">
    <table style="width:100%;">
        <tr>
            <td style="width: 111px">
                &nbsp;</td>
            <td colspan="3">
 
<asp:Label ID="LBTITULO" runat="server" CssClass="Titulo">CARGUE DE PAGOS ASOBANCARIA 2001</asp:Label>
            </td>
        </tr>
        <tr>
            <td style="width: 111px">
                &nbsp;</td>
            <td style="width: 199px">
                &nbsp;</td>
            <td style="width: 37px">
                &nbsp;</td>
            <td>
                        &nbsp;</td>
        </tr>
        <tr>
            <td style="width: 111px">
                Seleccione Archivo</td>
            <td style="width: 199px">
    <asp:FileUpload ID="FileUpload1" runat="server" Height="18px" Width="287px" />
            </td>
            <td style="width: 37px">
    <asp:ImageButton ID="ImageButton1" runat="server" 
        ImageUrl="~/images/Operaciones/pagos.png" ToolTip="Cargar Pago" 
        Width="32px" />
            </td>
            <td>
                        <asp:ImageButton ID="BtnIExcel" runat="server" Height="32px" 
                            ImageUrl="~/images/imagev2/excel2007.gif" ToolTip="Click, para exportar Logs " 
                            Width="32px" />
            </td>
        </tr>
        <tr>
            <td style="width: 111px">
                Observaciones</td>
            <td style="width: 199px">
                &nbsp;</td>
            <td style="width: 37px">
                &nbsp;</td>
            <td>
                        &nbsp;</td>
        </tr>
        <tr>
            <td colspan="3">
                <asp:TextBox ID="TxtObs" runat="server" Height="74px" TextMode="MultiLine" 
                    Width="100%"></asp:TextBox>
            </td>
            <td>
                &nbsp;</td>
        </tr>
    </table>
    <br />
    <br />
    <asp:Label ID="Label1" runat="server" Visible="False"></asp:Label>
    <br />
    <br />
    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" 
        CellPadding="4" ForeColor="#333333" GridLines="None" Width="707px" 
        CssClass="demoarea">
        <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
        <Columns>
            <asp:BoundField HeaderText="Formulario" DataField="N_FORMULARIO" />
            <asp:BoundField DataFormatString="{0:c3}" HeaderText="Valor Liquidacion" 
                DataField="VR_DECLARACION" />
            <asp:BoundField HeaderText="Observacion" DataField="OBSERVACION" />
        </Columns>
        <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
        <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
        <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
        <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
        <EditRowStyle BackColor="#999999" />
        <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
    </asp:GridView>
    </div>
</asp:Content>

