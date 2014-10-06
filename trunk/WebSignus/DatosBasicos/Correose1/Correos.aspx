<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="Correos.aspx.vb" Inherits="DatosBasicos_Correose1_Correos" title="Untitled Page" %>
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
    &nbsp; &nbsp;&nbsp; &nbsp;
    <br />
    <asp:UpdatePanel id="UpdatePanel1" runat="server">
        <contenttemplate>
&nbsp;<asp:Label id="Tit" runat="server" Width="286px" Text="Correose" CssClass="Titulo"></asp:Label><BR /><asp:Label id="MsgResult" runat="server"></asp:Label>&nbsp;&nbsp;&nbsp;<BR />&nbsp; <asp:GridView id="GridView1" runat="server" Width="626px" ForeColor="#333333" OnRowDataBound="GridView1_RowDataBound1" AllowPaging="True" DataSourceID="Objcorreo" GridLines="None" CellPadding="4" ShowFooter="True" OnRowCommand="GridView1_RowCommand" DataKeyNames="CORR_CODI" AutoGenerateColumns="False" OnSelectedIndexChanged="GridView1_SelectedIndexChanged" EmptyDataText="No se encontraron Registros en la Base de Datos" AllowSorting="True" PageSize="20" __designer:wfdid="w2">
<RowStyle BackColor="#F7F6F3" ForeColor="#333333"></RowStyle>
<Columns>
<asp:TemplateField HeaderText="Codigo del Correo" SortExpression="CORR_CODI"><FooterTemplate>
<asp:LinkButton id="lnkNuevo" runat="server" Text="Nuevo Registro" __designer:wfdid="w3" CommandName="Nuevo" CausesValidation="False"></asp:LinkButton> 
</FooterTemplate>
<ItemTemplate>
<asp:Label id="LbCodi" runat="server" Text='<%# Bind("CORR_CODI") %>' __designer:wfdid="w19"></asp:Label> 
</ItemTemplate>
</asp:TemplateField>
<asp:TemplateField HeaderText="Nombre del Correo  " SortExpression="CORR_NOMB"><ItemTemplate>
<asp:Label id="Lbnomb" runat="server" Text='<%# Bind("CORR_NOMB") %>' __designer:wfdid="w4"></asp:Label> 
</ItemTemplate>
</asp:TemplateField>
<asp:TemplateField HeaderText="Nombre del Modulo" SortExpression="CORR_DATO"><ItemTemplate>
<asp:Label id="Lbdato" runat="server" Text='<%# Bind("CORR_DATO") %>' __designer:wfdid="w5"></asp:Label> 
</ItemTemplate>
</asp:TemplateField>
<asp:TemplateField HeaderText="Cuerpo del Correo" SortExpression="CORR_BODY"><ItemTemplate>
<asp:Label id="Lbbody" runat="server" Text='<%# Bind("CORR_BODY") %>' __designer:wfdid="w6"></asp:Label> 

</ItemTemplate>
</asp:TemplateField>
<asp:TemplateField HeaderText="Campos de la Vista" SortExpression="CORR_CAMP"><ItemTemplate>
<asp:Label id="Lbcamp" runat="server" Text='<%# Bind("CORR_CAMP") %>' __designer:wfdid="w20"></asp:Label> 
</ItemTemplate>
</asp:TemplateField>
<asp:TemplateField HeaderText="Nombre de la Vista" SortExpression="CORR_VISTA"><ItemTemplate>
<asp:Label id="Lbvista" runat="server" Text='<%# Bind("CORR_VISTA") %>' __designer:wfdid="w21"></asp:Label> 
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
</asp:GridView> <asp:ObjectDataSource id="Objcorreo" runat="server" TypeName="Correose" SelectMethod="GetRecords"></asp:ObjectDataSource><!-- <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White"></FooterStyle>-->&nbsp; <asp:HiddenField id="Oper" runat="server"></asp:HiddenField>&nbsp;<asp:HiddenField id="HdPk1" runat="server"></asp:HiddenField>&nbsp;&nbsp;<BR />&nbsp;&nbsp;<BR />
</contenttemplate>
    </asp:UpdatePanel>&nbsp;
    &nbsp;&nbsp;&nbsp;&nbsp;<asp:UpdatePanel id="UpdatePanel2"
        runat="server"><contenttemplate>
<!-- Mensaje de Salida--><BR /><asp:Button style="DISPLAY: none" id="hiddenTargetControlForModalPopup2" runat="server"></asp:Button> <ajaxToolkit:ModalPopupExtender id="ModalPopupTer" runat="server" TargetControlID="hiddenTargetControlForModalPopup2" RepositionMode="RepositionOnWindowScroll" BehaviorID="programmaticModalPopupBehavior2" BackgroundCssClass="modalBackground" DropShadow="True" PopupControlID="programmaticPopup2" PopupDragHandleControlID="programmaticPopupDragHandle2">
            </ajaxToolkit:ModalPopupExtender>&nbsp;&nbsp; <asp:Panel id="programmaticPopup2" runat="server" Width="503px" Height="580px" CssClass="ModalPanel2"><asp:Panel id="programmaticPopupDragHandle2" runat="Server" Width="496px" Height="30px" CssClass="BarTitleModal2"><DIV style="PADDING-RIGHT: 5px; PADDING-LEFT: 5px; PADDING-BOTTOM: 5px; VERTICAL-ALIGN: middle; PADDING-TOP: 5px"><DIV style="FLOAT: left">Correos</DIV><DIV style="FLOAT: right"><INPUT id="BtnCerrar" type=button value="X" /></DIV></DIV></asp:Panel>&nbsp;<TABLE><TBODY><TR><TD colSpan=3><asp:Label id="SubT" runat="server" CssClass="SubTitulo" Text="Nuevo"></asp:Label></TD></TR><TR><TD colSpan=3><asp:ValidationSummary id="ValidationSummary1" runat="server"></asp:ValidationSummary></TD></TR><TR><TD style="WIDTH: 98px">Codigo del Correo</TD><TD style="WIDTH: 100px"><asp:TextBox id="TxtcodiNew" runat="server"></asp:TextBox></TD><TD style="WIDTH: 100px"><asp:RequiredFieldValidator id="RequiredFieldValidator1" runat="server" ErrorMessage="Digite  Codigo de Correo" ControlToValidate="TxtcodiNew">*</asp:RequiredFieldValidator></TD></TR><TR><TD style="WIDTH: 98px; HEIGHT: 23px"><asp:Label id="Label1" runat="server" Width="126px" Text="Nombre del Correo"></asp:Label></TD><TD style="WIDTH: 100px; HEIGHT: 23px"><asp:TextBox id="txtnombNew" runat="server"></asp:TextBox></TD><TD style="WIDTH: 100px; HEIGHT: 23px"><asp:RequiredFieldValidator id="RequiredFieldValidator3" runat="server" ErrorMessage="Digite  Nombre del Correo" ControlToValidate="txtnombNew">*</asp:RequiredFieldValidator></TD></TR><TR><TD style="WIDTH: 98px; HEIGHT: 18px"><asp:Label id="Label2" runat="server" Width="117px" Text="Nombre del Modulo"></asp:Label></TD><TD style="WIDTH: 100px; HEIGHT: 18px"><asp:TextBox id="txtdatoNew" runat="server"></asp:TextBox></TD><TD style="WIDTH: 100px; HEIGHT: 18px"><asp:RequiredFieldValidator id="RequiredFieldValidator4" runat="server" ErrorMessage="Digite Nombre del Modulo" ControlToValidate="txtdatoNew">*</asp:RequiredFieldValidator></TD></TR><TR><TD style="WIDTH: 98px; HEIGHT: 19px" vAlign=top><asp:Label id="Label3" runat="server" Text="Cuerpo del Correo"></asp:Label></TD><TD style="WIDTH: 100px; HEIGHT: 19px"><asp:TextBox id="txtbodyNew" runat="server" Width="317px" Height="245px" TextMode="MultiLine"></asp:TextBox></TD><TD style="WIDTH: 100px; HEIGHT: 19px"><asp:RequiredFieldValidator id="RequiredFieldValidator2" runat="server" ErrorMessage="Digite Cuerpo deL Correo" ControlToValidate="txtbodyNew">*</asp:RequiredFieldValidator></TD></TR><TR><TD style="WIDTH: 98px; HEIGHT: 19px"><asp:Label id="Label4" runat="server" Text="Campos de la Vista" __designer:wfdid="w13"></asp:Label></TD><TD style="WIDTH: 100px; HEIGHT: 19px"><asp:TextBox id="txtcampNew" runat="server" __designer:wfdid="w14"></asp:TextBox></TD><TD style="WIDTH: 100px; HEIGHT: 19px"><asp:RequiredFieldValidator id="RequiredFieldValidator5" runat="server" ErrorMessage="Digite el Campo de la Vista" ControlToValidate="txtcampNew" __designer:wfdid="w17">*</asp:RequiredFieldValidator></TD></TR><TR><TD style="WIDTH: 98px; HEIGHT: 19px"><asp:Label id="Label5" runat="server" Text="Nombre de la Vista" __designer:wfdid="w13"></asp:Label></TD><TD style="WIDTH: 100px; HEIGHT: 19px"><asp:TextBox id="txtvistaNew" runat="server" __designer:wfdid="w16"></asp:TextBox></TD><TD style="WIDTH: 100px; HEIGHT: 19px"><asp:RequiredFieldValidator id="RequiredFieldValidator6" runat="server" ErrorMessage="Digite el Nombre de la Vista" ControlToValidate="txtvistaNew" __designer:wfdid="w18">*</asp:RequiredFieldValidator></TD></TR><TR><TD style="WIDTH: 98px; HEIGHT: 19px"></TD><TD style="WIDTH: 100px; HEIGHT: 19px"></TD><TD style="WIDTH: 100px; HEIGHT: 19px"></TD></TR><TR><TD style="WIDTH: 98px"></TD><TD style="WIDTH: 100px"></TD><TD style="WIDTH: 100px"></TD></TR><TR><TD style="TEXT-ALIGN: center" colSpan=3><asp:Button id="BtnGuardar" onclick="BtnGuardar_Click" runat="server" Text="Guardar"></asp:Button>&nbsp;<asp:Button id="BtnEliminar" onclick="BtnEliminar_Click" runat="server" Text="Eliminar"></asp:Button>&nbsp; <INPUT id="BtnCancelar" type=button value="Cancelar" /> </TD></TR></TBODY></TABLE>&nbsp; </asp:Panel>&nbsp;&nbsp; 
</contenttemplate>
    </asp:UpdatePanel><br />
</div>

</asp:Content>

