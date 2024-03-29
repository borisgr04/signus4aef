<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="Tipocuenta.aspx.vb" Inherits="DatosBasicos_Tipo_Cuenta_Tipocuenta" title="Untitled Page" %>
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
&nbsp;<asp:Label id="Tit" runat="server" Width="286px" Text="Tipo_Cuenta" CssClass="Titulo"></asp:Label><BR /><asp:Label id="MsgResult" runat="server"></asp:Label>&nbsp;&nbsp;&nbsp;<BR />&nbsp;<asp:GridView id="GridView1" runat="server" Width="258px" ForeColor="#333333" OnRowDataBound="GridView1_RowDataBound1" AllowPaging="True" DataSourceID="Objcuent" GridLines="None" CellPadding="4" ShowFooter="True" OnRowCommand="GridView1_RowCommand" DataKeyNames="TCTA_CODI" AutoGenerateColumns="False" OnSelectedIndexChanged="GridView1_SelectedIndexChanged" EmptyDataText="No se encontraron Registros en la Base de Datos" AllowSorting="True">
<RowStyle BackColor="#F7F6F3" ForeColor="#333333"></RowStyle>
<Columns>
<asp:TemplateField HeaderText="C&#243;digo" SortExpression="TCTA_CODI"><FooterTemplate>
<asp:LinkButton id="lnkNuevo" runat="server" Text="Nuevo Registro" __designer:wfdid="w4" CommandName="Nuevo" CausesValidation="False"></asp:LinkButton> 
</FooterTemplate>
<ItemTemplate>
<asp:Label id="LbCodi" runat="server" Text='<%# Bind("TCTA_CODI") %>' __designer:wfdid="w1"></asp:Label> 
</ItemTemplate>
</asp:TemplateField>
<asp:TemplateField HeaderText="Nombre" SortExpression="TCTA_NOMB"><ItemTemplate>
<asp:Label id="LbNomb" runat="server" Text='<%# Bind("TCTA_NOMB") %>' __designer:wfdid="w5"></asp:Label> 
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
</asp:GridView> <asp:ObjectDataSource id="Objcuent" runat="server" TypeName="Tipo_Cuenta" SelectMethod="GetRecords"></asp:ObjectDataSource><!-- <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White"></FooterStyle>-->&nbsp; <asp:HiddenField id="Oper" runat="server"></asp:HiddenField>&nbsp;<asp:HiddenField id="HdPk1" runat="server"></asp:HiddenField>&nbsp;&nbsp;<BR />&nbsp;&nbsp;<BR />
</contenttemplate>
    </asp:UpdatePanel>&nbsp;
    &nbsp;&nbsp;&nbsp;&nbsp;<asp:UpdatePanel id="UpdatePanel2"
        runat="server"><contenttemplate>
<!-- Mensaje de Salida--><BR /><asp:Button style="DISPLAY: none" id="hiddenTargetControlForModalPopup2" runat="server"></asp:Button> <ajaxToolkit:ModalPopupExtender id="ModalPopupTer" runat="server" PopupDragHandleControlID="programmaticPopupDragHandle2" PopupControlID="programmaticPopup2" DropShadow="True" BackgroundCssClass="modalBackground" BehaviorID="programmaticModalPopupBehavior2" RepositionMode="RepositionOnWindowScroll" TargetControlID="hiddenTargetControlForModalPopup2">
            </ajaxToolkit:ModalPopupExtender>&nbsp;&nbsp; <asp:Panel id="programmaticPopup2" runat="server" Width="504px" Height="314px" CssClass="ModalPanel2"><asp:Panel id="programmaticPopupDragHandle2" runat="Server" Width="502px" Height="30px" CssClass="BarTitleModal2"><DIV style="PADDING-RIGHT: 5px; PADDING-LEFT: 5px; PADDING-BOTTOM: 5px; VERTICAL-ALIGN: middle; PADDING-TOP: 5px"><DIV style="FLOAT: left">Tipo Cuenta</DIV><DIV style="FLOAT: right"><INPUT id="BtnCerrar" type=button value="X" /></DIV></DIV></asp:Panel>&nbsp;<TABLE><TBODY><TR><TD colSpan=3><asp:Label id="SubT" runat="server" Text="Nuevo" CssClass="SubTitulo"></asp:Label></TD></TR><TR><TD colSpan=3><asp:ValidationSummary id="ValidationSummary1" runat="server"></asp:ValidationSummary></TD></TR><TR><TD style="WIDTH: 98px">C�digo</TD><TD style="WIDTH: 100px"><asp:TextBox id="TxtCodiNew" runat="server"></asp:TextBox></TD><TD style="WIDTH: 100px"><asp:RequiredFieldValidator id="RequiredFieldValidator1" runat="server" ControlToValidate="TxtCodiNew" ErrorMessage="Digite un Codigo">*</asp:RequiredFieldValidator></TD></TR><TR><TD style="WIDTH: 98px">Nombre </TD><TD style="WIDTH: 100px"><asp:TextBox id="TxtNombNew" runat="server" Width="229px"></asp:TextBox></TD><TD style="WIDTH: 100px"><asp:RequiredFieldValidator id="RequiredFieldValidator2" runat="server" ControlToValidate="TxtNombNew" ErrorMessage="Digite un Nombre">*</asp:RequiredFieldValidator></TD></TR><TR><TD style="WIDTH: 98px"></TD><TD style="WIDTH: 100px"></TD><TD style="WIDTH: 100px"></TD></TR><TR><TD style="WIDTH: 98px"></TD><TD style="WIDTH: 100px"></TD><TD style="WIDTH: 100px"></TD></TR><TR><TD style="WIDTH: 98px"></TD><TD style="WIDTH: 100px"></TD><TD style="WIDTH: 100px"></TD></TR><TR><TD style="TEXT-ALIGN: center" colSpan=3><asp:Button id="BtnGuardar" onclick="BtnGuardar_Click" runat="server" Text="Guardar"></asp:Button>&nbsp;<asp:Button id="BtnEliminar" onclick="BtnEliminar_Click" runat="server" Text="Eliminar"></asp:Button>&nbsp; <INPUT id="BtnCancelar" type=button value="Cancelar" /> </TD></TR></TBODY></TABLE>&nbsp; </asp:Panel>&nbsp;&nbsp; 
</contenttemplate>
    </asp:UpdatePanel><br />
</div>

</asp:Content>

