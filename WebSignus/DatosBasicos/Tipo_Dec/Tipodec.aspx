<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="Tipodec.aspx.vb" Inherits="DatosBasicos_Tipo_Dec_Tipodec" title="Untitled Page" %>
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
&nbsp;<asp:Label id="Tit" runat="server" Width="286px" Text="Tipo_Dec" CssClass="Titulo"></asp:Label><BR /><asp:Label id="MsgResult" runat="server"></asp:Label>&nbsp;&nbsp;&nbsp;<BR />&nbsp;<asp:GridView id="GridView1" runat="server" Width="633px" ForeColor="#333333" EmptyDataText="No se encontraron Registros en la Base de Datos" OnSelectedIndexChanged="GridView1_SelectedIndexChanged" AutoGenerateColumns="False" DataKeyNames="TDEC_COD,TDEC_CDEC" OnRowCommand="GridView1_RowCommand" ShowFooter="True" CellPadding="4" GridLines="None" DataSourceID="Objtdec" AllowPaging="True" OnRowDataBound="GridView1_RowDataBound1" AllowSorting="True">
<RowStyle BackColor="#F7F6F3" ForeColor="#333333"></RowStyle>
<Columns>
<asp:TemplateField HeaderText="Codigo de Declaracion" SortExpression="TDEC_COD"><FooterTemplate>
<asp:LinkButton id="lnkNuevo" runat="server" Text="Nuevo Registro" __designer:wfdid="w3" CommandName="Nuevo" CausesValidation="False"></asp:LinkButton> 
</FooterTemplate>
<ItemTemplate>
<asp:Label id="Lbcod" runat="server" Text='<%# Bind("TDEC_COD") %>' __designer:wfdid="w1"></asp:Label> 
</ItemTemplate>
</asp:TemplateField>
<asp:TemplateField HeaderText="Nombre de Declaracion" SortExpression="TDEC_NOM"><ItemTemplate>
<asp:Label id="Lbnom" runat="server" Text='<%# Bind("TDEC_NOM") %>' __designer:wfdid="w4"></asp:Label> 
</ItemTemplate>
</asp:TemplateField>
<asp:TemplateField HeaderText="Fecha Inicial" SortExpression="TDEC_FIN"><ItemTemplate>
<asp:Label id="Lbfecini" runat="server" Text='<%# Bind("TDEC_FIN") %>' __designer:wfdid="w5"></asp:Label> 
</ItemTemplate>
</asp:TemplateField>
<asp:TemplateField HeaderText="Fecha Final" SortExpression="TDEC_FFI"><ItemTemplate>
<asp:Label id="Lbfini" runat="server" Text='<%# Bind("TDEC_FFI") %>' __designer:wfdid="w6"></asp:Label> 
</ItemTemplate>
</asp:TemplateField>
<asp:TemplateField HeaderText="Clase de Declaracion" SortExpression="TDEC_CDEC"><ItemTemplate>
<asp:Label id="Lbcdec" runat="server" Text='<%# Bind("TDEC_CDEC") %>' __designer:wfdid="w7"></asp:Label> 
</ItemTemplate>
</asp:TemplateField>
<asp:TemplateField HeaderText="Tipo de Declaracion" SortExpression="TDEC_CODI"><ItemTemplate>
<asp:Label id="Lbcodi" runat="server" Text='<%# Bind("TDEC_CODI") %>' __designer:wfdid="w8"></asp:Label> 
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
</asp:GridView> <asp:ObjectDataSource id="Objtdec" runat="server" SelectMethod="GetRecords" TypeName="Tipo_Dec"></asp:ObjectDataSource><!-- <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White"></FooterStyle>-->&nbsp; <asp:HiddenField id="Oper" runat="server"></asp:HiddenField>&nbsp;<asp:HiddenField id="Hdpk2" runat="server"></asp:HiddenField> <asp:HiddenField id="HdPk1" runat="server"></asp:HiddenField>&nbsp;&nbsp;&nbsp;&nbsp;<BR />
</contenttemplate>
    </asp:UpdatePanel>&nbsp;
    &nbsp;&nbsp;&nbsp;&nbsp;<asp:UpdatePanel id="UpdatePanel2"
        runat="server"><contenttemplate>
<!-- Mensaje de Salida--><BR /><asp:Button style="DISPLAY: none" id="hiddenTargetControlForModalPopup2" runat="server"></asp:Button> <ajaxToolkit:ModalPopupExtender id="ModalPopupTer" runat="server" TargetControlID="hiddenTargetControlForModalPopup2" RepositionMode="RepositionOnWindowScroll" BehaviorID="programmaticModalPopupBehavior2" BackgroundCssClass="modalBackground" DropShadow="True" PopupControlID="programmaticPopup2" PopupDragHandleControlID="programmaticPopupDragHandle2">
            </ajaxToolkit:ModalPopupExtender>&nbsp;&nbsp; <asp:Panel id="programmaticPopup2" runat="server" Width="567px" Height="449px" CssClass="ModalPanel2"><asp:Panel id="programmaticPopupDragHandle2" runat="Server" Width="569px" Height="30px" CssClass="BarTitleModal2"><DIV style="PADDING-RIGHT: 5px; PADDING-LEFT: 5px; PADDING-BOTTOM: 5px; VERTICAL-ALIGN: middle; PADDING-TOP: 5px"><DIV style="FLOAT: left">Tipo_Dec</DIV><DIV style="FLOAT: right"><INPUT id="BtnCerrar" type=button value="X" /></DIV></DIV></asp:Panel>&nbsp;<TABLE style="WIDTH: 637px; HEIGHT: 359px"><TBODY><TR><TD colSpan=3><asp:Label id="SubT" runat="server" Text="Nuevo" CssClass="SubTitulo"></asp:Label></TD></TR><TR><TD colSpan=3><asp:ValidationSummary id="ValidationSummary1" runat="server"></asp:ValidationSummary></TD></TR><TR><TD style="WIDTH: 98px; HEIGHT: 10px; TEXT-ALIGN: justify"><asp:Label id="Label4" runat="server" Width="143px" Text="Tipo de Declaracion"></asp:Label></TD><TD style="WIDTH: 200px; HEIGHT: 10px"><asp:TextBox id="TxtcodNew" runat="server"></asp:TextBox></TD><TD style="WIDTH: 100px; HEIGHT: 10px"><asp:RequiredFieldValidator id="RequiredFieldValidator1" runat="server" ErrorMessage="Digite Periodo a Declarar" ControlToValidate="TxtcodNew">*</asp:RequiredFieldValidator></TD></TR><TR><TD style="WIDTH: 98px; HEIGHT: 13px; TEXT-ALIGN: justify"><asp:Label id="Label1" runat="server" Width="153px" Text="Nombre del Tipo de Declaracion"></asp:Label></TD><TD style="WIDTH: 200px; HEIGHT: 13px"><asp:TextBox id="txtnomNew" runat="server"></asp:TextBox></TD><TD style="WIDTH: 100px; HEIGHT: 13px"><asp:RequiredFieldValidator id="RequiredFieldValidator3" runat="server" ErrorMessage="Digite el Nombre de Declaracin" ControlToValidate="txtnomNew">*</asp:RequiredFieldValidator></TD></TR><TR><TD style="WIDTH: 98px; HEIGHT: 6px"><asp:Label id="Label2" runat="server" Width="156px" Text="Fecha Inicial"></asp:Label></TD><TD style="WIDTH: 200px; HEIGHT: 6px"><asp:TextBox id="txtfecini" runat="server"></asp:TextBox></TD><TD style="WIDTH: 100px; HEIGHT: 6px"><asp:RequiredFieldValidator id="RequiredFieldValidator4" runat="server" ErrorMessage="Digite Fecha de Inicio" ControlToValidate="txtfecini">*</asp:RequiredFieldValidator></TD></TR><TR><TD style="WIDTH: 98px; HEIGHT: 7px"><asp:Label id="Label3" runat="server" Text="Fecha Final"></asp:Label></TD><TD style="WIDTH: 200px; HEIGHT: 7px; TEXT-ALIGN: left"><asp:TextBox id="Txtfecfin" runat="server"></asp:TextBox></TD><TD style="WIDTH: 100px; HEIGHT: 7px"><asp:RequiredFieldValidator id="RequiredFieldValidator2" runat="server" ErrorMessage="Digite Fecha Final" ControlToValidate="Txtfecfin">*</asp:RequiredFieldValidator></TD></TR><TR><TD style="WIDTH: 98px; HEIGHT: 5px"><asp:Label id="Label5" runat="server" Width="163px" Text="Clase de Declaraciòn"></asp:Label></TD><TD style="WIDTH: 200px; HEIGHT: 5px"><asp:TextBox id="txtcdecNew" runat="server"></asp:TextBox></TD><TD style="WIDTH: 100px; HEIGHT: 5px"><asp:RequiredFieldValidator id="RequiredFieldValidator5" runat="server" ErrorMessage="Digite la Clase de Declaracion" ControlToValidate="txtcdecNew">*</asp:RequiredFieldValidator></TD></TR><TR><TD style="WIDTH: 98px"><asp:Label id="Label6" runat="server" Width="162px" Text="Tipo de Declaraciòn"></asp:Label></TD><TD style="WIDTH: 200px"><asp:TextBox id="txtcodiNew" runat="server"></asp:TextBox></TD><TD style="WIDTH: 100px"><asp:RequiredFieldValidator id="RequiredFieldValidator6" runat="server" ErrorMessage="Digite el Tipo de Declaracion" ControlToValidate="txtcodiNew">*</asp:RequiredFieldValidator></TD></TR><TR><TD style="WIDTH: 98px; HEIGHT: 21px"></TD><TD style="WIDTH: 200px; HEIGHT: 21px"></TD><TD style="WIDTH: 100px; HEIGHT: 21px"></TD></TR><TR><TD style="WIDTH: 98px"></TD><TD style="WIDTH: 200px"></TD><TD style="WIDTH: 100px"></TD></TR><TR><TD style="HEIGHT: 21px; TEXT-ALIGN: left" colSpan=3>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; <asp:Button id="BtnGuardar" onclick="BtnGuardar_Click" runat="server" Text="Guardar"></asp:Button>&nbsp;<asp:Button id="BtnEliminar" onclick="BtnEliminar_Click" runat="server" Text="Eliminar"></asp:Button>&nbsp; <INPUT id="BtnCancelar" type=button value="Cancelar" /> </TD></TR></TBODY></TABLE>&nbsp; <ajaxToolkit:CalendarExtender id="CalendarExtender3" runat="server" TargetControlID="TxtFecIni"></ajaxToolkit:CalendarExtender> <ajaxToolkit:CalendarExtender id="CalendarExtender4" runat="server" TargetControlID="TxtFecFin"></ajaxToolkit:CalendarExtender></asp:Panel>&nbsp;&nbsp; 
</contenttemplate>
    </asp:UpdatePanel><br />
</div>


</asp:Content>

