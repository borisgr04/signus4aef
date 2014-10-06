<%@ Control Language="VB" AutoEventWireup="false" CodeFile="Vh_CU_ConLiq.ascx.vb" Inherits="CtrlUsr_Vh_Liq_CU_ConLiq" %>
<style type="text/css">
    .style1
    {
        height: 14px;
        width: 116px;
    }
    .style2
    {
        height: 20px;
        width: 116px;
    }
    .style3
    {
        width: 116px;
    }
</style>
<asp:Label ID="MsgResult" runat="server"></asp:Label>

<asp:Panel ID="Pn1" runat="server" Visible="True">
<table style="width: 624px; height: 265px;">
    <tr>
        <td colspan="4">
            &nbsp;
            <asp:Label ID="Label2" runat="server" CssClass="SubTitulo">INFORMACION GENERAL 
            DE LA LIQUIDACIÓN</asp:Label>
            <hr style="width: 611px" />
        </td>
    </tr>
    <tr>
        <td class="style1">
            <asp:Label ID="Label24" runat="server" CssClass="TitDecl" Font-Bold="True" 
                Text="Tipo de Documento" Width="111px"></asp:Label>
        </td>
        <td style="width: 239px; height: 14px;">
            <asp:Label ID="TIP_DOC_IDE" runat="server"></asp:Label>
        </td>
        <td style="width: 144px; height: 14px;">
            <asp:Label ID="Label26" runat="server" CssClass="TitDecl" Font-Bold="True" 
                Text="Identificaión"></asp:Label>
        </td>
        <td style="width: 589px; height: 14px;">
            <asp:Label ID="Identificaciòn" runat="server"></asp:Label>
            -<asp:Label ID="DV" runat="server"></asp:Label>
        </td>
    </tr>
    <tr>
        <td class="style2">
            <asp:Label ID="Label4" runat="server" CssClass="TitDecl" Font-Bold="True">Tipo 
            de Agente</asp:Label>
        </td>
        <td colspan="3" style="height: 20px">
            <asp:Label ID="LBTIPODEC" runat="server" Width="327px"></asp:Label>
        </td>
    </tr>
    <tr>
        <td class="style3">
            <asp:Label ID="Label20" runat="server" CssClass="TitDecl" Font-Bold="True" 
                Text="Razon Social" Width="98px"></asp:Label>
        </td>
        <td colspan="3">
            <asp:Label ID="Agente" runat="server" Width="337px"></asp:Label>
        </td>
    </tr>
    <tr>
        <td class="style3">
            <asp:Label ID="Label6" runat="server" CssClass="TitDecl" Font-Bold="True" 
                Text="Clase Declaración" Width="110px"></asp:Label>
        </td>
        <td colspan="3">
            <asp:Label ID="Cla_Dec" runat="server" Width="337px"></asp:Label>
        </td>
    </tr>
    <tr>
        <td class="style2">
            <asp:Label ID="Label7" runat="server" CssClass="TitDecl" Font-Bold="True" 
                Text="Periodo Gravable" Width="110px"></asp:Label>
        </td>
        <td style="width: 239px; height: 20px">
            <asp:Label ID="LDEC_PER" runat="server"></asp:Label>
        </td>
        <td style="width: 144px; height: 20px">
            <asp:Label ID="Label8" runat="server" CssClass="TitDecl" Font-Bold="True" 
                Text="Año Gravable" Width="110px"></asp:Label>
        </td>
        <td style="width: 589px; height: 20px">
            <asp:Label ID="LDEC_ANO" runat="server"></asp:Label>
        </td>
    </tr>
    <tr>
    <td>
    <asp:Label ID="Label1" runat="server" CssClass="TitDecl" Font-Bold="True" 
                Text="Estado" Width="110px"></asp:Label>
    </td>
    <td>
        <asp:DropDownList ID="CboEstado" runat="server" Enabled=false>
        <asp:ListItem Text="Diligenciada" Value="DC"></asp:ListItem>
        <asp:ListItem Text="Anulada" Value="AN"></asp:ListItem>
        <asp:ListItem Text="Presentada y Pagada" Value="PR"></asp:ListItem>
        <asp:ListItem Text="Corregida" Value="CR"></asp:ListItem>
        
        </asp:DropDownList>
    </td>
    </tr>
    <tr>
    <td>
        <asp:ImageButton ID="LnkDec" runat="server" ImageUrl="~/images/2011/pdf.png" Width="48" Height="48" ToolTip="Ver Formularios"  />
    
    </td>
    </tr>
    <tr>
    
        <td colspan="4" style="text-align: left">
            <asp:Label ID="Label27" runat="server" CssClass="SubTitulo">DETALLE DE 
            LIQUIDACIÓN</asp:Label>
            <hr style="width: 611px" />
         
        </td>
    </tr>
</table>
    
   <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" 
                DataSourceID="ObjectDataSource1" ShowHeader="False">
                <Columns>
                    <asp:BoundField DataField="Code_Nomb" HeaderText="Descripción">
                        <ItemStyle Width="40%" />
                    </asp:BoundField>
                    <asp:BoundField DataField="Code_Vade" DataFormatString="{0:c}" 
                        HeaderText="Valor">
                        <ItemStyle HorizontalAlign="Right" Width="70%" />
                    </asp:BoundField>
                </Columns>
            </asp:GridView>
            <asp:ObjectDataSource ID="ObjectDataSource1" runat="server" 
                OldValuesParameterFormatString="original_{0}" SelectMethod="GetLiqConcep" 
                TypeName="CDeclaraciones">
                <SelectParameters>
                    <asp:ControlParameter ControlID="HdLiq" Name="CODE_DCOD" PropertyName="Value" 
                        Type="String" />
                </SelectParameters>
            </asp:ObjectDataSource>
            <asp:HiddenField ID="HdLiq" runat="server" />
</asp:Panel>