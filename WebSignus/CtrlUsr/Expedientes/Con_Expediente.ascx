<%@ Control Language="VB" AutoEventWireup="false" CodeFile="Con_Expediente.ascx.vb" Inherits="CtrlUsr_Expedientes_Con_Expediente" %>
<div style="padding: 10px; margin: 10px">        
        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
    <ContentTemplate>
        <table style="width:100%;">
            <tr>
                <td style="width:100px">
                    Proceso No.</td>
                <td style="width:300px">
                    <asp:TextBox ID="tbNumProceso" runat="server" Width="150px"></asp:TextBox>
                </td>
                <td>
                    <asp:TextBox ID="tbProceso" runat="server" Visible="False"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td style="width:100px">
                    Expediente No.</td>
                <td style="width:300px">
                    <asp:TextBox ID="tbNumExpe" runat="server" AutoPostBack="True"></asp:TextBox>
                </td>
                <td>
                    &nbsp;</td>
            </tr>
            <tr>
                <td>
                    Nit/Nombre</td>
                <td>
                    <asp:TextBox ID="tbNit" runat="server" Width="300px"></asp:TextBox>
                </td>
                <td>
                    <asp:TextBox ID="tbTramite" runat="server" Visible="False"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:CheckBox ID="chProceso" runat="server" Text="Proceso" />
                </td>
                <td>
                    <asp:DropDownList ID="cmbProceso" runat="server" Width="150px"  
                        DataSourceID="odsProcesos" DataTextField="PROC_NOMB" 
                        DataValueField="PROC_CODI" AutoPostBack="True">
                    </asp:DropDownList>
                </td>
                <td>
                    <asp:ImageButton ID="BtnBuscar" runat="server" AccessKey="b" 
                        AlternateText="Buscar" CausesValidation="False" CommandName="Buscar" 
                        ImageUrl="~/images/Operaciones/search2.png" />
                </td>
            </tr>
            <tr>
                <td>
                    <asp:CheckBox ID="chTramite" runat="server" Text="Tramite" />
                </td>
                <td>
                    <asp:DropDownList ID="cmbTramite" runat="server" Width="300px" 
                        DataSourceID="odsTramites" DataTextField="TRAM_NOMB" 
                        DataValueField="TRAM_CODI">
                    </asp:DropDownList>
                </td>
                <td>
                    Buscar</td>
            </tr>
        </table>
        <asp:GridView ID="gvConsulta" runat="server" AllowPaging="True" 
            AutoGenerateColumns="False" DataKeyNames="EXPE_NUME" 
            DataSourceID="odsExpedientes" OnRowCommand="gvConsulta_RowCommand" 
            OnRowDataBound="gvConsulta_RowDataBound" 
            OnSelectedIndexChanged="gvConsulta_SelectedIndexChanged" PageSize="7" 
            ShowFooter="True">
            <Columns>
                <asp:TemplateField HeaderText="No. Expediente" SortExpression="EXPE_NUME">
                    <ItemTemplate>
                        <asp:Label ID="LExpediente" runat="server" Text='<%# Bind("EXPE_NUME") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Nit" SortExpression="EXPE_NIT">
                    <ItemTemplate>
                        <asp:Label ID="LNit" runat="server" Text='<%# Bind("EXPE_NIT") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Agente Retenedor" SortExpression="TER_NOM">
                    <ItemTemplate>
                        <asp:Label ID="LAgente" runat="server" Text='<%# Bind("TER_NOM") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Tramite Actual" SortExpression="TRAM_NOMB">
                    <ItemTemplate>
                        <asp:Label ID="LTramite" runat="server" Text='<%# Bind("TRAM_NOMB") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Proceso" SortExpression="PROC_NOMB">
                    <ItemTemplate>
                        <asp:Label ID="LProceso" runat="server" Text='<%# Bind("PROC_NOMB") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="No. Proceso" SortExpression="EXPE_NPRO">
                    <ItemTemplate>
                        <asp:Label ID="LNProceso" runat="server" Text='<%# Bind("EXPE_NPRO") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Municipio" SortExpression="MUN_NOM">
                    <ItemTemplate>
                        <asp:Label ID="LMunicipio" runat="server" Text='<%# Bind("MUN_NOM") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField>
                    <ItemStyle HorizontalAlign="Center" Width="16px" />
                    <ItemTemplate>
                        <img alt="Enviar" 
                            onclick='javascript:enviarExpediente(&#039;<%# Eval("EXPE_NUME") %>&#039;);' 
                            onmouseout="this.style.cursor = 'auto'" 
                            onmouseover="this.style.cursor = 'hand'" 
                            src="../../images/Operaciones/Select.png" title="Seleccionar Expediente" />
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
            <EmptyDataTemplate>
                <br />
                <asp:Label ID="Label1" runat="server" CssClass="NoData" 
                    Text="No se encontraron registros" Width="166px"></asp:Label>
            </EmptyDataTemplate>
        </asp:GridView>
        </ContentTemplate> 
        </asp:UpdatePanel>
</div> 
&nbsp; &nbsp;&nbsp;
<asp:ObjectDataSource ID="odsExpedientes" runat="server" 
    SelectMethod="GetExpediente" TypeName="Expedientes" 
    OldValuesParameterFormatString="original_{0}"> 
    <SelectParameters>
        <asp:ControlParameter ControlID="tbNumExpe" Name="numExpe" PropertyName="Text" 
            Type="String" />
        <asp:ControlParameter ControlID="tbNumProceso"
            Name="numProceso" PropertyName="Text" Type="String" />
        <asp:ControlParameter ControlID="tbNit"
            Name="NitoNombre" PropertyName="Text" Type="String" />
        <asp:ControlParameter ControlID="tbProceso" Name="proceso" PropertyName="Text" 
            Type="String" />
        <asp:ControlParameter ControlID="tbTramite" Name="tramite" PropertyName="Text" 
            Type="String" />
    </SelectParameters>
</asp:ObjectDataSource>
<asp:ObjectDataSource ID="odsProcesos" runat="server" 
    SelectMethod="GetProcesoHabilitados" TypeName="Procesos" 
    OldValuesParameterFormatString="original_{0}">
</asp:ObjectDataSource>
<asp:ObjectDataSource ID="odsTramites" runat="server" SelectMethod="GetPorProc" 
TypeName="Tramites" OldValuesParameterFormatString="original_{0}">
        <SelectParameters>
        <asp:ControlParameter ControlID="cmbProceso" Name="TRAM_PROC" PropertyName="SelectedValue"
          Type="String" DefaultValue="0101" />
        </SelectParameters>
 </asp:ObjectDataSource>
    
