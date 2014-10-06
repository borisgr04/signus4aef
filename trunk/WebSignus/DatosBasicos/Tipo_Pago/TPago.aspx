<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="TPago.aspx.vb" Inherits="DatosBasicos_TIPO_PAGO_TPago" title="Untitled Page" %>
<asp:Content ID="Content1" ContentPlaceHolderID="SampleContent" Runat="Server">
<div class="demoarea">
    <ajaxToolkit:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server" EnableScriptGlobalization="true"
        EnableScriptLocalization="true">
    </ajaxToolkit:ToolkitScriptManager>
    &nbsp;
    <br />
    <asp:UpdatePanel id="UpdatePanel1" runat="server">
        <contenttemplate>
&nbsp;<asp:Label id="Tit" runat="server" Text="TIPO_PAGO" CssClass="Titulo"></asp:Label><BR /><asp:Label id="MsgResult" runat="server"></asp:Label><BR />&nbsp;&nbsp; <BR /><BR /><asp:GridView id="GridView1" runat="server" ForeColor="#333333" AutoGenerateColumns="False" DataKeyNames="TPAG_COD" OnRowCommand="GridView1_RowCommand" ShowFooter="True" CellPadding="4" GridLines="None" DataSourceID="ObjTpag" AllowPaging="True">
<RowStyle BackColor="#F7F6F3" ForeColor="#333333"></RowStyle>
<Columns>
<asp:TemplateField HeaderText="C&#243;digo" SortExpression="TPAG_COD"><FooterTemplate>
<asp:LinkButton ID="lnkNuevo" runat="server" CausesValidation="False" CommandName="Nuevo"
                            Text="Nuevo Registro"></asp:LinkButton>
</FooterTemplate>
<ItemTemplate>
<asp:Label id="LbCod" runat="server" Text='<%# Bind("TPAG_COD") %>'></asp:Label> 
</ItemTemplate>
</asp:TemplateField>
<asp:TemplateField HeaderText="Nombre" SortExpression="TPAG_NOM"><ItemTemplate>
                   <asp:Label ID="LbNom" runat="server" Text='<%# Bind("TPAG_NOM") %>'></asp:Label>
                
</ItemTemplate>
</asp:TemplateField>
<asp:ButtonField CommandName="Editar" Text="Editar"></asp:ButtonField>
<asp:ButtonField CommandName="Eliminar" Text="Eliminar"></asp:ButtonField>
</Columns>

<FooterStyle BackColor="White" Font-Bold="True" ForeColor="#5D7B9D"></FooterStyle>

<PagerStyle HorizontalAlign="Center" BackColor="#284775" ForeColor="White"></PagerStyle>

<SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333"></SelectedRowStyle>

<HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White"></HeaderStyle>

<EditRowStyle BackColor="#999999"></EditRowStyle>

<AlternatingRowStyle BackColor="White" ForeColor="#284775"></AlternatingRowStyle>
</asp:GridView><BR /><!-- <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White"></FooterStyle>-->&nbsp;<asp:ObjectDataSource id="ObjTpag" runat="server" SelectMethod="GetRecords" TypeName="TIPO_PAGO" OldValuesParameterFormatString="original_{0}"></asp:ObjectDataSource> <asp:HiddenField id="Oper" runat="server"></asp:HiddenField> <asp:HiddenField id="HdPk1" runat="server"></asp:HiddenField><BR /><asp:MultiView id="MultiView1" runat="server"><asp:View id="View1" runat="server"><TABLE><TBODY><TR><TD colSpan=3><asp:Label id="SubT" runat="server" Text="Nuevo" CssClass="SubTitulo"></asp:Label> </TD></TR><TR><TD colSpan=3><asp:ValidationSummary id="ValidationSummary1" runat="server" __designer:wfdid="w33"></asp:ValidationSummary></TD></TR><TR><TD style="WIDTH: 98px">Código</TD><TD style="WIDTH: 100px"><asp:TextBox id="TxtCodNew" runat="server"></asp:TextBox></TD><TD style="WIDTH: 100px"><asp:RequiredFieldValidator id="RequiredFieldValidator1" runat="server" ErrorMessage="Digite Código" __designer:wfdid="w31" ControlToValidate="TxtCodNew">*</asp:RequiredFieldValidator></TD></TR><TR><TD style="WIDTH: 98px">Nombre </TD><TD style="WIDTH: 100px"><asp:TextBox id="TxtNomNew" runat="server" Width="229px"></asp:TextBox></TD><TD style="WIDTH: 100px"><asp:RequiredFieldValidator id="RequiredFieldValidator2" runat="server" ErrorMessage="Digite Nombre" __designer:wfdid="w32" ControlToValidate="TxtNomNew">*</asp:RequiredFieldValidator></TD></TR><TR><TD style="WIDTH: 98px"></TD><TD style="WIDTH: 100px"></TD><TD style="WIDTH: 100px"></TD></TR><TR><TD style="WIDTH: 98px"></TD><TD style="WIDTH: 100px"></TD><TD style="WIDTH: 100px"></TD></TR><TR><TD style="WIDTH: 98px"></TD><TD style="WIDTH: 100px"></TD><TD style="WIDTH: 100px"></TD></TR><TR><TD style="TEXT-ALIGN: center" colSpan=3><asp:Button id="BtnGuardar" onclick="BtnGuardar_Click" runat="server" Text="Guardar"></asp:Button><asp:Button id="BtnCancelar" onclick="BtnCancelar_Click" runat="server" Text="Cancelar"></asp:Button></TD></TR></TBODY></TABLE>&nbsp; </asp:View>&nbsp; </asp:MultiView>&nbsp; <BR />
</contenttemplate>
    </asp:UpdatePanel>&nbsp;
    &nbsp;&nbsp;&nbsp;<br />
</div>
</asp:Content>

