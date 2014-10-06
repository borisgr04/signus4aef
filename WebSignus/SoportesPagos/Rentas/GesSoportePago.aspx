<%@ Page Title="" Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="GesSoportePago.aspx.vb" Inherits="SoportesPagos_Rentas_GesSoportePago" %>

<asp:Content ID="Content1" ContentPlaceHolderID="SampleContent" Runat="Server">

    <div class="demoarea">
        <asp:Label ID="LBTITULO" runat="server" CssClass="Titulo">GESTIÓN DE SOPORTES DE PAGO</asp:Label>&nbsp;
        <br />
        <br />
        <asp:Button ID="BtnSoporte" runat="server" Text="Ver Soporte" />
        &nbsp;<asp:Button ID="BtnAplicar" runat="server" Text="Aplicar Pago" />
        <br />
        <asp:Label ID="msgResult" runat="server" SkinID="MsgResult" Width="90%" Height="30px"></asp:Label>
        <br />
    <asp:GridView ID="grdPagos_Sop" runat="server" AutoGenerateColumns="False" DataSourceID="ObjPagosSop" DataKeyNames="PAG_NDOC">
        <Columns>
            <asp:BoundField DataField="PAG_NDOC" HeaderText="N° Declaración" SortExpression="PAG_NDOC" />
            <asp:BoundField DataField="PAG_TOT" HeaderText="Valor Pagado" SortExpression="PAG_TOT" />
            <asp:BoundField DataField="PAG_FPAG" HeaderText="Fecha de Pago" SortExpression="PAG_FPAG" />
            <asp:BoundField DataField="PAG_EST" HeaderText="Estado" SortExpression="PAG_EST" />
            <asp:BoundField DataField="PAG_CTAB" HeaderText="Cuenta Bancaria" SortExpression="PAG_CTAB" />
            <asp:BoundField DataField="PAG_NIT" HeaderText="Nit" SortExpression="PAG_NIT" />
            <asp:BoundField DataField="PAG_TIP" HeaderText="Medio de Pago" SortExpression="PAG_TIP" />
            <asp:CommandField ShowSelectButton="True" />
        </Columns>
        </asp:GridView>
        <asp:ObjectDataSource ID="ObjPagosSop" runat="server" SelectMethod="GetPendientes" TypeName="BLL.AplicarSoportePagoBLL">
        </asp:ObjectDataSource>
        <asp:HiddenField ID="HiddenField1" runat="server" />
    </div>
    
</asp:Content>

