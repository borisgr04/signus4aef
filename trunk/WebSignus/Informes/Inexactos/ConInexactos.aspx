<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="ConInexactos.aspx.vb" Inherits="Informes_Inexactos_ConInexactos" title="Untitled Page" %>
<asp:Content ID="Content1" ContentPlaceHolderID="SampleContent" Runat="Server">
<script type='text/javascript'>
// Add click handlers for buttons to show and hide modal popup on pageLoad
        function pageLoad() {
            //$addHandler($get("showModalPopupClientButton"), 'click', showModalPopupViaClient);
            //$addHandler($get("hideModalPopupViaClientButton"), 'click', hideModalPopupViaClient);        
            $addHandler($get("BtnCerrar"), 'click', CerrarModalTercero);        
            $addHandler($get("BtnCancelar"), 'click', CerrarModalTercero);        
        }
         function CerrarModalTercero(ev) {
            ev.preventDefault();        
            var modalPopupBehavior2 = $find('programmaticModalPopupBehavior2');
            modalPopupBehavior2.hide();
        }
        
          function CerrarModalEliminar(ev) {
            ev.preventDefault();        
            var modalPopupBehavior2 = $find('programmaticModalPopupBehavior');
            modalPopupBehavior2.hide();
        }
        
        </script>


<div class="demoarea">
    <ajaxToolkit:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server" EnableScriptGlobalization="true"
        EnableScriptLocalization="true">
    </ajaxToolkit:ToolkitScriptManager>
    <asp:Label ID="Tit" runat="server" CssClass="Titulo" Text="CONSULTA DE INEXACTOS"></asp:Label>&nbsp;
    <br />
    <asp:UpdatePanel id="UpdatePanel1" runat="server">
        <contenttemplate>
<TABLE><TBODY><TR><TD style="WIDTH: 100px">Clase de Declaración</TD><TD style="WIDTH: 100px"></TD><TD style="WIDTH: 100px">Estado de Revisión</TD></TR><TR><TD colSpan=2><asp:DropDownList id="CMBCLADEC" runat="server" Width="253px" AutoPostBack="True" DataSourceID="ObjClaseDec" DataTextField="cld_nom" DataValueField="cld_cod"></asp:DropDownList></TD><TD style="WIDTH: 100px"><asp:DropDownList id="CboEstFis" runat="server" AutoPostBack="True" OnSelectedIndexChanged="CboEstFis_SelectedIndexChanged"><asp:ListItem Value="IX">IX - Inexacta</asp:ListItem>
<asp:ListItem Value="EX">EX - Exacta</asp:ListItem>
<asp:ListItem Value="IR">IR - Inexacta Revisada</asp:ListItem>
<asp:ListItem Value="ER">ER - Exacta Revisada</asp:ListItem>
</asp:DropDownList></TD></TR><TR><TD colSpan=2><asp:Label id="MsgResult" runat="server" __designer:wfdid="w27"></asp:Label></TD><TD style="WIDTH: 100px"></TD></TR></TBODY></TABLE> <asp:GridView id="GridView1" runat="server" __designer:dtid="844424930131973" DataSourceID="ObjInex" AutoGenerateColumns="False" __designer:wfdid="w26" AllowSorting="True" DataKeyNames="Dec_Cod" OnRowDataBound="GridView1_RowDataBound" OnSelectedIndexChanged="GridView1_SelectedIndexChanged" OnRowCommand="GridView1_RowCommand"><Columns __designer:dtid="844424930131974">
<asp:BoundField DataField="Dec_Nro" HeaderText="Nro" __designer:dtid="844424930131975"></asp:BoundField>
<asp:BoundField DataField="Dec_Nit" HeaderText="Nit" __designer:dtid="844424930131976"></asp:BoundField>
<asp:BoundField DataField="Dec_RazSoc" HeaderText="Agente Recaudador" __designer:dtid="844424930131977"></asp:BoundField>
<asp:BoundField DataField="Dec_Ano" HeaderText="A&#241;o Gravable" __designer:dtid="844424930131978"></asp:BoundField>
<asp:BoundField DataField="Dec_Per" HeaderText="Periodo Gravable" __designer:dtid="844424930131979"></asp:BoundField>
<asp:BoundField DataField="Dec_Cod" HeaderText="N&#176; Formulario" SortExpression="Dec_Cod" __designer:dtid="844424930131980"></asp:BoundField>
<asp:BoundField DataField="SAldo_dif" DataFormatString="${0:#,###}" HeaderText="Saldo Diferencia" SortExpression="SAldo_dif" __designer:dtid="844424930131981">
<ItemStyle HorizontalAlign="Right"></ItemStyle>
</asp:BoundField>
<asp:ButtonField CommandName="Editar" ImageUrl="~/images/Operaciones/Edit2.png" Text="Editar" ButtonType="Image" __designer:dtid="844424930131982"></asp:ButtonField>
<asp:CommandField SelectImageUrl="~/images/Operaciones/Select.png" ShowSelectButton="True" ButtonType="Image" __designer:dtid="844424930131983"></asp:CommandField>
</Columns>
</asp:GridView><BR /><asp:GridView id="GridView2" runat="server" Width="100%" DataSourceID="ObjInexD" AutoGenerateColumns="False" __designer:wfdid="w1" OnRowDataBound="GridView2_RowDataBound" Caption="DETALLE"><Columns>
<asp:BoundField DataField="CODE_CODI" HeaderText="ID" SortExpression="CODE_CODI"></asp:BoundField>
<asp:BoundField DataField="CODE_NOMB" HeaderText="CONCEPTO" SortExpression="CODE_NOMB"></asp:BoundField>
<asp:TemplateField HeaderText="1.BASE GRAVABLE" SortExpression="CODE_VABA"><EditItemTemplate>
<asp:TextBox runat="server" Text='<%# Bind("CODE_VABA") %>' id="TextBox1"></asp:TextBox>
</EditItemTemplate>
<ItemTemplate>
<asp:Label id="Label1" runat="server" __designer:wfdid="w6" Text='<%# Bind("CODE_VABA", "${0:#,###}") %>'></asp:Label>
</ItemTemplate>

<HeaderStyle Wrap="False"></HeaderStyle>

<ItemStyle HorizontalAlign="Right"></ItemStyle>
</asp:TemplateField>
<asp:BoundField DataField="CODE_TARI" HeaderText="2.TARIFA" SortExpression="CODE_TARI">
<ItemStyle HorizontalAlign="Right"></ItemStyle>
</asp:BoundField>
<asp:BoundField DataField="CODE_VADE" DataFormatString="${0:#,###}" HeaderText="3.VALOR" SortExpression="CODE_VADE">
<ItemStyle HorizontalAlign="Right"></ItemStyle>
</asp:BoundField>
<asp:BoundField DataField="CODE_VBCA" DataFormatString="${0:#,###}" HeaderText="4. BG. (A)" SortExpression="CODE_VBCA">
<ItemStyle HorizontalAlign="Right" BorderColor="Black" ForeColor="#C00000"></ItemStyle>
</asp:BoundField>
<asp:BoundField DataField="CODE_TACA" HeaderText="5.Tar (A)" SortExpression="CODE_TACA">
<ItemStyle HorizontalAlign="Right" ForeColor="#C00000"></ItemStyle>
</asp:BoundField>
<asp:BoundField DataField="CODE_VACA" DataFormatString="${0:#,###}" HeaderText="6.Valor (A)" SortExpression="CODE_VACA">
<ItemStyle HorizontalAlign="Right" ForeColor="#C00000"></ItemStyle>
</asp:BoundField>
<asp:BoundField DataField="DIF_VABA" DataFormatString="${0:#,###}" HeaderText="7.Dif. BG (4-1)" SortExpression="DIF_VABA">
<ItemStyle HorizontalAlign="Right" Font-Bold="True" ForeColor="#004000"></ItemStyle>
</asp:BoundField>
<asp:BoundField DataField="DIF_TARI" HeaderText="8.Dif. Tar.(5-2)" SortExpression="DIF_TARI">
<ItemStyle HorizontalAlign="Right" Font-Bold="True" ForeColor="#004000"></ItemStyle>
</asp:BoundField>
<asp:BoundField DataField="DIF_VADE" DataFormatString="${0:#,###}" HeaderText="9.Dif. Valor(6-3)" SortExpression="DIF_VADE">
<ItemStyle HorizontalAlign="Right" Font-Bold="True" ForeColor="#004000"></ItemStyle>
</asp:BoundField>
</Columns>
</asp:GridView>&nbsp;&nbsp;&nbsp; <asp:ObjectDataSource id="ObjInexD" runat="server" __designer:dtid="844424930131975" TypeName="Informes" SelectMethod="GetDecInexactasD" __designer:wfdid="w3"><SelectParameters __designer:dtid="844424930131976">
<asp:ControlParameter ControlID="GridView1" PropertyName="SelectedValue" Name="Dec_Cod"></asp:ControlParameter>
</SelectParameters>
</asp:ObjectDataSource><BR />
</contenttemplate>
    </asp:UpdatePanel>&nbsp;<br />
    &nbsp;<asp:UpdatePanel id="UpdatePanel2" runat="server"><contenttemplate>
<!-- Mensaje de Salida--><BR /><asp:Button style="DISPLAY: none" id="hiddenTargetControlForModalPopup2" runat="server"></asp:Button> <ajaxToolkit:ModalPopupExtender id="ModalPopupTer" runat="server" PopupDragHandleControlID="programmaticPopupDragHandle2" PopupControlID="programmaticPopup2" DropShadow="True" BackgroundCssClass="modalBackground" BehaviorID="programmaticModalPopupBehavior2" RepositionMode="RepositionOnWindowScroll" TargetControlID="hiddenTargetControlForModalPopup2">
            </ajaxToolkit:ModalPopupExtender>&nbsp;&nbsp; <asp:Panel id="programmaticPopup2" runat="server" Width="473px" Height="317px" CssClass="ModalPanel2"><asp:Panel id="programmaticPopupDragHandle2" runat="Server" Width="472px" Height="30px" CssClass="BarTitleModal2"><DIV style="PADDING-RIGHT: 5px; PADDING-LEFT: 5px; PADDING-BOTTOM: 5px; VERTICAL-ALIGN: middle; PADDING-TOP: 5px"><DIV style="FLOAT: left">Revisión de Declaraciones</DIV><DIV style="FLOAT: right"><INPUT id="BtnCerrar" type=button value="X" /></DIV></DIV></asp:Panel>&nbsp;<TABLE><TBODY><TR><TD colSpan=3><asp:Label id="SubT" runat="server" CssClass="SubTitulo" Text="Nuevo"></asp:Label></TD></TR><TR><TD colSpan=3><asp:ValidationSummary id="ValidationSummary1" runat="server"></asp:ValidationSummary></TD></TR><TR><TD style="WIDTH: 98px">Código</TD><TD style="WIDTH: 100px"><asp:TextBox id="TxtCodNew" runat="server" Enabled="False"></asp:TextBox></TD><TD style="WIDTH: 100px"></TD></TR><TR><TD style="WIDTH: 98px">Estado</TD><TD style="WIDTH: 100px"><asp:DropDownList id="CboEst" runat="server"><asp:ListItem Value="IR">IR - Inexacta Revisada</asp:ListItem>
<asp:ListItem Value="ER">ER - Exacta Revisada</asp:ListItem>
<asp:ListItem Value="IX">IX - Inexacta</asp:ListItem>
<asp:ListItem Value="EX">EX - Exacta</asp:ListItem>
</asp:DropDownList></TD><TD style="WIDTH: 100px"></TD></TR><TR><TD style="WIDTH: 98px"></TD><TD style="WIDTH: 100px"></TD><TD style="WIDTH: 100px"></TD></TR><TR><TD style="WIDTH: 98px"></TD><TD style="WIDTH: 100px"></TD><TD style="WIDTH: 100px"></TD></TR><TR><TD style="WIDTH: 98px"></TD><TD style="WIDTH: 100px"></TD><TD style="WIDTH: 100px"></TD></TR><TR><TD style="TEXT-ALIGN: center" colSpan=3><asp:Button id="BtnGuardar" onclick="BtnGuardar_Click" runat="server" Text="Guardar"></asp:Button> &nbsp; <INPUT id="BtnCancelar" type=button value="Cancelar" /> </TD></TR></TBODY></TABLE>&nbsp; </asp:Panel>&nbsp;&nbsp; 
</contenttemplate>
    </asp:UpdatePanel><asp:ObjectDataSource ID="ObjInex" runat="server" SelectMethod="GetDecInexactas"
        TypeName="Informes">
        <SelectParameters>
            <asp:ControlParameter ControlID="CMBCLADEC" Name="Cla_Dec" PropertyName="SelectedValue" />
            <asp:ControlParameter ControlID="CboEstFis" Name="Est_Fis" PropertyName="SelectedValue" />
        </SelectParameters>
    </asp:ObjectDataSource>
    <br />
    &nbsp;<br />
    <br />
    <asp:ObjectDataSource ID="ObjClaseDec" runat="server" OldValuesParameterFormatString="original_{0}"
        SelectMethod="GetcargarTipoDecla" TypeName="Informes"></asp:ObjectDataSource>
</div>
</asp:Content>

