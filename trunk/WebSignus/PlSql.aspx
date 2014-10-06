<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="PlSql.aspx.vb" Inherits="PlSql" title="Untitled Page" %>
<asp:Content ID="Content1" ContentPlaceHolderID="SampleContent" Runat="Server">
<br />
<div class="demoarea">
    <table>
        <tr>
            <td style="width: 1627px">
    <asp:Label ID="Label1" runat="server" Text="Valor Base"></asp:Label>
    <asp:TextBox ID="ValorBase" runat="server"></asp:TextBox>
    <asp:Label ID="Label2" runat="server" Text="Cantidad"></asp:Label>
    <asp:TextBox ID="Cantidad" runat="server"></asp:TextBox>
    &nbsp;&nbsp;
            </td>
            <td>
            </td>
            <td style="width: 389px">
                Clase de Impuesto
                <asp:DropDownList ID="CmbClase" runat="server" AutoPostBack="True" DataSourceID="ObjClaImp"
                    DataTextField="CLIM_NOMB" DataValueField="CLIM_CODI" OnSelectedIndexChanged="CmbClase_SelectedIndexChanged">
                </asp:DropDownList><br />
                Seleccione de Impuesto&nbsp;
                <asp:DropDownList ID="CboImpto" runat="server" AutoPostBack="True" DataSourceID="ObjImp"
                    DataTextField="IMP_NOM" DataValueField="IMP_COD" OnSelectedIndexChanged="CboImpto_SelectedIndexChanged">
                </asp:DropDownList>&nbsp;<asp:Button ID="Button1" runat="server" Text="Consultar Parametros" /></td>
        </tr>
        <tr>
            <td style="width: 1627px; height: 397px">
    <asp:TextBox ID="Formula" runat="server" Height="483px" TextMode="MultiLine" Width="98%"></asp:TextBox></td>
            <td style="height: 397px">
            </td>
            <td style="width: 389px; height: 397px" valign="top">
                &nbsp;<asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" DataKeyNames="PAR_COD"
                    DataSourceID="SqlPar_Imp">
                    <Columns>
                        <asp:BoundField DataField="PAR_CIM" HeaderText="PAR_CIM" SortExpression="PAR_CIM" />
                        <asp:BoundField DataField="PAR_COD" HeaderText="PAR_COD" ReadOnly="True" SortExpression="PAR_COD" />
                        <asp:BoundField DataField="PAR_NOM" HeaderText="PAR_NOM" SortExpression="PAR_NOM" />
                        <asp:BoundField DataField="PAR_TID" HeaderText="PAR_TID" SortExpression="PAR_TID" />
                    </Columns>
                </asp:GridView>
                <br />
                <asp:Button ID="BtnGen" runat="server" Text="Generar_Formula" />
                <asp:Button ID="BtnFormula" runat="server" Text="Formula" />
                <br />
                <asp:TextBox ID="F2" runat="server" Height="197px" TextMode="MultiLine" Width="289px"></asp:TextBox></td>
        </tr>
        <tr>
            <td style="width: 1627px">
            </td>
            <td>
            </td>
            <td style="width: 389px">
            </td>
        </tr>
        <tr>
            <td style="width: 1627px">
    <asp:Button ID="Ejecutar" runat="server" Text="Ejecutar" /></td>
            <td>
            </td>
            <td style="width: 389px">
            </td>
        </tr>
        <tr>
            <td style="width: 1627px">
                <br />
    <asp:Label ID="Label3" runat="server" Text="Resultado"></asp:Label>
    <asp:TextBox ID="Resultado" runat="server"></asp:TextBox>
            </td>
            <td>
            </td>
            <td style="width: 389px">
            </td>
        </tr>
    </table>
    <br />
    <br />
    <br />
    &nbsp;<asp:SqlDataSource ID="SqlPar_Imp" runat="server" ConnectionString="<%$ ConnectionStrings:ConnectionString %>"
        ProviderName="<%$ ConnectionStrings:ConnectionString.ProviderName %>" SelectCommand="select * from Par_imp where par_cim=:cim">
        <SelectParameters>
            <asp:ControlParameter ControlID="CboImpto" Name="cim" PropertyName="SelectedValue" />
        </SelectParameters>
    </asp:SqlDataSource>
    <asp:ObjectDataSource ID="ObjImp" runat="server" SelectMethod="GetByCLASE" TypeName="Impuestos">
        <SelectParameters>
            <asp:ControlParameter ControlID="CmbClase" Name="IMP_CLA" PropertyName="SelectedValue" />
        </SelectParameters>
    </asp:ObjectDataSource>
    <asp:ObjectDataSource ID="ObjClaImp" runat="server" SelectMethod="GetRecords" TypeName="Clase_Impto">
    </asp:ObjectDataSource>
    </div>
</asp:Content>

