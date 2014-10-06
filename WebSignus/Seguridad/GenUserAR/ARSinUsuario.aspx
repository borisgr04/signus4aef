<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="ARSinUsuario.aspx.vb" Inherits="Seguridad_GenUserAR_ARSinUsuario" title="Untitled Page" %>
<asp:Content ID="Content1" ContentPlaceHolderID="SampleContent" Runat="Server">
    <div class="demoarea">
    <ajaxToolkit:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server" EnableScriptGlobalization="true"
        EnableScriptLocalization="true" >
    </ajaxToolkit:ToolkitScriptManager>
    <asp:Label ID="Tit" runat="server" CssClass="Titulo" Text="AGENTER RECAUDADORES SIN USUARIO"
        Width="286px"></asp:Label><br />
    <%--<asp:UpdatePanel id="UpdatePanel1" runat="server">
        <contenttemplate>--%>
            &nbsp; 
            <asp:Button ID="BtnCrearUsua" runat="server" OnClick="BtnCrearUsua_Click" 
                Text="Crear Usuarios" />
            <BR /><BR /><asp:GridView id="GridView1" runat="server" AllowPaging="True" AutoGenerateColumns="False" DataKeyNames="ter_nit" DataSourceID="ObjTerceros" OnRowCommand="GridView1_RowCommand" OnRowDataBound="GridView1_RowDataBound" OnSelectedIndexChanged="GridView1_SelectedIndexChanged" ShowFooter="True"><Columns>
<asp:TemplateField HeaderText="Tipo Doc" SortExpression="TER_TDOC"><ItemTemplate>
<asp:Label id="LbNom" runat="server" Text='<%# Bind("TER_TDOC") %>'></asp:Label> 
</ItemTemplate>
</asp:TemplateField>
<asp:TemplateField HeaderText="N&#176; Identificaci&#243;n" SortExpression="TER_NIT"><ItemTemplate>
                        <asp:Label ID="LbUni1" runat="server" Text='<%# Bind("TER_NIT") %>'></asp:Label>
                    
</ItemTemplate>
</asp:TemplateField>
<asp:TemplateField HeaderText="Nombre" SortExpression="TER_NOM"><ItemTemplate>
                        <asp:Label ID="LbUni2" runat="server" Text='<%# Bind("TER_NOM") %>'></asp:Label>
                    
</ItemTemplate>
</asp:TemplateField>
<asp:TemplateField HeaderText="Municipio" SortExpression="TER_MPIO"><ItemTemplate>
                        <asp:Label ID="LbBar" runat="server" Text='<%# Bind("TER_MPIO") %>'></asp:Label>
                    
</ItemTemplate>
</asp:TemplateField>
<asp:TemplateField HeaderText="Telefono" SortExpression="TER_TEL"><ItemTemplate>
                        <asp:Label ID="LbNor" runat="server" Text='<%# Bind("TER_TEL") %>'></asp:Label>
                    
</ItemTemplate>
</asp:TemplateField>
<asp:TemplateField HeaderText="Observaci&#243;n" SortExpression="TER_OBS"><ItemTemplate>
                        <asp:Label ID="LbObs" runat="server" Text='<%# Bind("TER_OBS") %>'></asp:Label>
                    
</ItemTemplate>
</asp:TemplateField>
<asp:TemplateField>
<ItemStyle HorizontalAlign="Center" Width="16px"></ItemStyle>
</asp:TemplateField>
</Columns>
<EmptyDataTemplate>
                <br  />
                <asp:Label ID="Label1" runat="server" CssClass="NoData" Text="No se encontraron registros"
                    Width="166px"></asp:Label>
            
</EmptyDataTemplate>
</asp:GridView>Mostrar Por Pagina <asp:TextBox id="TxtPag" runat="server" Width="63px">10</asp:TextBox> <asp:Button id="BtnPag" onclick="BtnPag_Click" runat="server" Text="Paginar"></asp:Button>&nbsp;<BR /><asp:Label id="Tit2" runat="server" Width="286px" Text="LOGS.." CssClass="SubTitulo"></asp:Label>&nbsp; <BR /><asp:Label id="MsgResult" runat="server"></asp:Label>
<%--</contenttemplate>
        <Triggers>
            <asp:AsyncPostBackTrigger ControlID="BtnCrearUsua" EventName="Click" />
        </Triggers>
    </asp:UpdatePanel>&nbsp; &nbsp; &nbsp--%>;
    <asp:ObjectDataSource ID="ObjTerceros" runat="server" SelectMethod="GetAgentesSinUsuario"
        TypeName="Signus.Terceros"></asp:ObjectDataSource>
    <br />
    <%--<asp:UpdateProgress id="UpdateProgress1" runat="server" AssociatedUpdatePanelID="UpdatePanel1">
        <progresstemplate>
            <div class="Loading">
            <img src="../../images/loading.gif" alt="" title="" /> Cargando …
            </div>
        </progresstemplate>
    </asp:UpdateProgress>--%>
    <br />

</div>
</asp:Content>

