<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="Dist_Cart.aspx.vb" Inherits="DatosBasicos_Dist_Cart_Dist_Cart" title="Untitled Page" %>
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
    &nbsp; &nbsp;
    <br />
    <asp:UpdatePanel id="UpdatePanel1" runat="server">
        <contenttemplate>
&nbsp;<asp:Label id="Tit" runat="server" Width="286px" CssClass="Titulo" Text="Distribuir Cartera"></asp:Label><BR /><asp:Label id="MsgResult" runat="server"></asp:Label>&nbsp;&nbsp;&nbsp;<BR />&nbsp;<asp:GridView id="GridView1" runat="server" Width="633px" ForeColor="#333333" EmptyDataText="No se encontraron Registros en la Base de Datos" OnSelectedIndexChanged="GridView1_SelectedIndexChanged" AutoGenerateColumns="False" DataKeyNames="DICA_CDEC,DICA_CODD,DICA_CODC" OnRowCommand="GridView1_RowCommand" ShowFooter="True" CellPadding="4" GridLines="None" DataSourceID="Objdist" AllowPaging="True" OnRowDataBound="GridView1_RowDataBound1" AllowSorting="True">
<RowStyle BackColor="#F7F6F3" ForeColor="#333333"></RowStyle>
<Columns>
<asp:TemplateField HeaderText="Clase de Declaraci&#243;n" SortExpression="DICA_CDEC"><FooterTemplate>
<asp:LinkButton id="lnkNuevo" runat="server" Text="Nuevo Registro" __designer:wfdid="w5" CommandName="Nuevo" CausesValidation="False"></asp:LinkButton> 
</FooterTemplate>
<ItemTemplate>
<asp:Label id="Lbcdec" runat="server" Text='<%# Bind("DICA_CDEC") %>' __designer:wfdid="w3"></asp:Label> 
</ItemTemplate>
</asp:TemplateField>
<asp:TemplateField HeaderText="Codigo del Concepto" SortExpression="DICA_CODD"><ItemTemplate>
<asp:Label id="Lbcodd" runat="server" Text='<%# Bind("DICA_CODD") %>' __designer:wfdid="w6"></asp:Label> 
</ItemTemplate>
</asp:TemplateField>
<asp:TemplateField HeaderText="Codigo de la Cartera" SortExpression="DICA_CODC"><ItemTemplate>
<asp:Label id="Lbcodc" runat="server" Text='<%# Bind("DICA_CODC") %>' __designer:wfdid="w7"></asp:Label> 
</ItemTemplate>
</asp:TemplateField>
<asp:TemplateField HeaderText="Codigo del Formulario" SortExpression="DICA_FDCO"><ItemTemplate>
<asp:Label id="Lbfdco" runat="server" Text='<%# Bind("DICA_FDCO") %>' __designer:wfdid="w8"></asp:Label> 
</ItemTemplate>
</asp:TemplateField>
<asp:TemplateField HeaderText="Orden de Distribuci&#243;n" SortExpression="DICA_ORDE"><ItemTemplate>
<asp:Label id="Lborde" runat="server" Text='<%# Bind("DICA_ORDE") %>' __designer:wfdid="w9"></asp:Label> 
</ItemTemplate>
</asp:TemplateField>
<asp:ButtonField CommandName="Eliminar" ImageUrl="~/images/Operaciones/delete2.png" Text="Eliminar" ButtonType="Image"></asp:ButtonField>
<asp:ButtonField CommandName="Editar" ImageUrl="~/images/Operaciones/Edit2.png" Text="Editar" ButtonType="Image"></asp:ButtonField>
<asp:CommandField SelectImageUrl="~/images/Operaciones/Select.png" ShowSelectButton="True" ButtonType="Image"></asp:CommandField>
</Columns>

<FooterStyle BackColor="White" Font-Bold="True" ForeColor="#5D7B9D"></FooterStyle>

<PagerStyle HorizontalAlign="Center" BackColor="#284775" ForeColor="White"></PagerStyle>

<SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333"></SelectedRowStyle>

<HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White"></HeaderStyle>

<EditRowStyle BackColor="#999999"></EditRowStyle>

<AlternatingRowStyle BackColor="White" ForeColor="#284775"></AlternatingRowStyle>
</asp:GridView> <asp:ObjectDataSource id="Objdist" runat="server" SelectMethod="GetRecords" TypeName="Dist_cart"></asp:ObjectDataSource><!-- <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White"></FooterStyle>-->&nbsp; <asp:HiddenField id="Oper" runat="server"></asp:HiddenField>&nbsp;<asp:HiddenField id="Hdpk2" runat="server"></asp:HiddenField> <asp:HiddenField id="HdPk1" runat="server"></asp:HiddenField>&nbsp;&nbsp;&nbsp;&nbsp;<asp:HiddenField id="Hdpk3" runat="server"></asp:HiddenField><BR />
</contenttemplate>
    </asp:UpdatePanel>&nbsp;
    &nbsp;&nbsp;&nbsp;&nbsp;<asp:UpdatePanel id="UpdatePanel2"
        runat="server"><contenttemplate>
<!-- Mensaje de Salida--><BR /><asp:Button style="DISPLAY: none" id="hiddenTargetControlForModalPopup2" runat="server"></asp:Button> <ajaxToolkit:ModalPopupExtender id="ModalPopupTer" runat="server" PopupDragHandleControlID="programmaticPopupDragHandle2" PopupControlID="programmaticPopup2" DropShadow="True" BackgroundCssClass="modalBackground" BehaviorID="programmaticModalPopupBehavior2" RepositionMode="RepositionOnWindowScroll" TargetControlID="hiddenTargetControlForModalPopup2">
            </ajaxToolkit:ModalPopupExtender>&nbsp;&nbsp; <asp:Panel id="programmaticPopup2" runat="server" Width="644px" Height="471px" CssClass="ModalPanel2"><asp:Panel id="programmaticPopupDragHandle2" runat="Server" Width="641px" Height="30px" CssClass="BarTitleModal2"><DIV style="PADDING-RIGHT: 5px; PADDING-LEFT: 5px; PADDING-BOTTOM: 5px; VERTICAL-ALIGN: middle; PADDING-TOP: 5px"><DIV style="FLOAT: left">Calendario</DIV><DIV style="FLOAT: right"><INPUT id="BtnCerrar" type=button value="X" /></DIV></DIV></asp:Panel>&nbsp;<TABLE style="WIDTH: 637px; HEIGHT: 359px"><TBODY><TR><TD colSpan=3><asp:Label id="SubT" runat="server" CssClass="SubTitulo" Text="Nuevo"></asp:Label></TD></TR><TR><TD colSpan=3><asp:ValidationSummary id="ValidationSummary1" runat="server"></asp:ValidationSummary></TD></TR><TR><TD style="WIDTH: 98px; HEIGHT: 10px; TEXT-ALIGN: justify"><asp:Label id="Label4" runat="server" Width="143px" Text="Tipo de Impuesto"></asp:Label></TD><TD style="WIDTH: 100px; HEIGHT: 10px"><asp:TextBox id="TxtcdecNew" runat="server"></asp:TextBox></TD><TD style="WIDTH: 100px; HEIGHT: 10px"><asp:RequiredFieldValidator id="RequiredFieldValidator1" runat="server" ControlToValidate="TxtcdecNew" ErrorMessage="Digite la Clase de Declaración">*</asp:RequiredFieldValidator></TD></TR><TR><TD style="WIDTH: 98px; HEIGHT: 13px; TEXT-ALIGN: justify"><asp:Label id="Label1" runat="server" Width="126px" Text="Codigo del Requisito"></asp:Label></TD><TD style="WIDTH: 100px; HEIGHT: 13px"><asp:TextBox id="txtcoddNew" runat="server"></asp:TextBox></TD><TD style="WIDTH: 100px; HEIGHT: 13px"><asp:RequiredFieldValidator id="RequiredFieldValidator3" runat="server" ControlToValidate="txtcoddNew" ErrorMessage="Digite el Codigo del Concepto">*</asp:RequiredFieldValidator></TD></TR><TR><TD style="WIDTH: 98px; HEIGHT: 6px"><asp:Label id="Label2" runat="server" Width="156px" Text="Fecha de Inicio"></asp:Label></TD><TD style="WIDTH: 100px; HEIGHT: 6px"><asp:TextBox id="txtcodcNew" runat="server"></asp:TextBox></TD><TD style="WIDTH: 100px; HEIGHT: 6px"><asp:RequiredFieldValidator id="RequiredFieldValidator4" runat="server" ControlToValidate="txtcodcNew" ErrorMessage="Digite el Codigo de la Cartera">*</asp:RequiredFieldValidator></TD></TR><TR><TD style="WIDTH: 98px; HEIGHT: 7px"><asp:Label id="Label3" runat="server" Text="Fecha Final"></asp:Label></TD><TD style="WIDTH: 100px; HEIGHT: 7px; TEXT-ALIGN: left"><asp:TextBox id="TxtfdcoNew" runat="server"></asp:TextBox></TD><TD style="WIDTH: 100px; HEIGHT: 7px"><asp:RequiredFieldValidator id="RequiredFieldValidator2" runat="server" ControlToValidate="TxtfdcoNew" ErrorMessage="Digite el Codigo del Formulario">*</asp:RequiredFieldValidator></TD></TR><TR><TD style="WIDTH: 98px; HEIGHT: 5px"><asp:Label id="Label5" runat="server" Width="163px" Text="Descripcion del Requisito"></asp:Label></TD><TD style="WIDTH: 100px; HEIGHT: 5px"><asp:TextBox id="txtordeNew" runat="server"></asp:TextBox></TD><TD style="WIDTH: 100px; HEIGHT: 5px"><asp:RequiredFieldValidator id="RequiredFieldValidator5" runat="server" ControlToValidate="txtordeNew" ErrorMessage="Digite la Orden de Distribución">*</asp:RequiredFieldValidator></TD></TR><TR><TD style="WIDTH: 98px"></TD><TD style="WIDTH: 100px"></TD><TD style="WIDTH: 100px"></TD></TR><TR><TD style="WIDTH: 98px; HEIGHT: 21px"></TD><TD style="WIDTH: 100px; HEIGHT: 21px"></TD><TD style="WIDTH: 100px; HEIGHT: 21px"></TD></TR><TR><TD style="WIDTH: 98px"></TD><TD style="WIDTH: 100px"></TD><TD style="WIDTH: 100px"></TD></TR><TR><TD style="HEIGHT: 21px; TEXT-ALIGN: center" colSpan=3><asp:Button id="BtnGuardar" onclick="BtnGuardar_Click" runat="server" Text="Guardar"></asp:Button>&nbsp;<asp:Button id="BtnEliminar" onclick="BtnEliminar_Click" runat="server" Text="Eliminar"></asp:Button>&nbsp; <INPUT id="BtnCancelar" type=button value="Cancelar" /> </TD></TR></TBODY></TABLE>&nbsp;&nbsp; </asp:Panel>&nbsp;&nbsp; 
</contenttemplate>
    </asp:UpdatePanel><br />
</div>

</asp:Content>

