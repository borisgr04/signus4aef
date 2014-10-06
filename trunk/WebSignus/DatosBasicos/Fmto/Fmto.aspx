<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="Fmto.aspx.vb" Inherits="DatosBasicos_Fmto_Fmto" title="Untitled Page" %>
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
&nbsp;<asp:Label id="Tit" runat="server" Width="286px" Text="Fmto" CssClass="Titulo"></asp:Label><BR /><asp:Label id="MsgResult" runat="server"></asp:Label>&nbsp;&nbsp;&nbsp;<BR /><asp:GridView id="GridView1" runat="server" Width="100%" ForeColor="#333333" EmptyDataText="No se encontraron Registros en la Base de Datos" OnSelectedIndexChanged="GridView1_SelectedIndexChanged" AutoGenerateColumns="False" DataKeyNames="FMTO_CODI" OnRowCommand="GridView1_RowCommand" ShowFooter="True" CellPadding="4" GridLines="None" DataSourceID="Objforma" AllowPaging="True" OnRowDataBound="GridView1_RowDataBound1" AllowSorting="True" PageSize="20">
<RowStyle BackColor="#F7F6F3" ForeColor="#333333"></RowStyle>
<Columns>
<asp:TemplateField HeaderText="C&#243;digo de la Tabla" SortExpression="FMTO_CODI"><FooterTemplate>
<asp:LinkButton id="lnkNuevo" runat="server" Text="Nuevo Registro" CausesValidation="False" CommandName="Nuevo" __designer:wfdid="w16"></asp:LinkButton> 
</FooterTemplate>
<ItemTemplate>
<asp:Label id="LbCodi" runat="server" Text='<%# Bind("FMTO_CODI") %>' __designer:wfdid="w14"></asp:Label> 
</ItemTemplate>
</asp:TemplateField>
<asp:TemplateField HeaderText="Nombre de la Tabla" SortExpression="FMTO_NOMB"><ItemTemplate>
<asp:Label id="Lbnomb" runat="server" Text='<%# Bind("FMTO_NOMB") %>' __designer:wfdid="w17"></asp:Label> 
</ItemTemplate>
</asp:TemplateField>
<asp:TemplateField HeaderText="Formatos Descripcion" SortExpression="FMTO_DESC"><ItemTemplate>
<asp:Label id="Lbdesc" runat="server" Text='<%# Bind("FMTO_DESC") %>' __designer:wfdid="w18"></asp:Label> 
</ItemTemplate>
</asp:TemplateField>
<asp:TemplateField HeaderText="Clase de Declaracion" SortExpression="FMTO_CDEC"><ItemTemplate>
<asp:Label id="Lbcdec" runat="server" Text='<%# Bind("FMTO_CDEC") %>' __designer:wfdid="w19"></asp:Label> 
</ItemTemplate>
</asp:TemplateField>
<asp:TemplateField HeaderText="Estado del Formato" SortExpression="FMTO_EST"><ItemTemplate>
<asp:Label id="Lbest" runat="server" Text='<%# Bind("FMTO_EST") %>' __designer:wfdid="w20"></asp:Label> 
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
</asp:GridView> <asp:ObjectDataSource id="Objforma" runat="server" TypeName="Fmtos" SelectMethod="GetRecords"></asp:ObjectDataSource><!-- <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White"></FooterStyle>-->&nbsp; <asp:HiddenField id="Oper" runat="server"></asp:HiddenField>&nbsp;<asp:HiddenField id="HdPk1" runat="server"></asp:HiddenField>&nbsp;&nbsp;<BR />&nbsp;&nbsp;<BR />
</contenttemplate>
    </asp:UpdatePanel>&nbsp;
    &nbsp;&nbsp;&nbsp;&nbsp;<asp:UpdatePanel id="UpdatePanel2"
        runat="server"><contenttemplate>
<!-- Mensaje de Salida--><BR /><asp:Button style="DISPLAY: none" id="hiddenTargetControlForModalPopup2" runat="server"></asp:Button> <ajaxToolkit:ModalPopupExtender id="ModalPopupTer" runat="server" PopupDragHandleControlID="programmaticPopupDragHandle2" PopupControlID="programmaticPopup2" DropShadow="True" BackgroundCssClass="modalBackground" BehaviorID="programmaticModalPopupBehavior2" RepositionMode="RepositionOnWindowScroll" TargetControlID="hiddenTargetControlForModalPopup2">
            </ajaxToolkit:ModalPopupExtender>&nbsp;&nbsp; <asp:Panel id="programmaticPopup2" runat="server" Width="492px" Height="327px" CssClass="ModalPanel2"><asp:Panel id="programmaticPopupDragHandle2" runat="Server" Width="483px" Height="30px" CssClass="BarTitleModal2"><DIV style="PADDING-RIGHT: 5px; PADDING-LEFT: 5px; PADDING-BOTTOM: 5px; VERTICAL-ALIGN: middle; PADDING-TOP: 5px"><DIV style="FLOAT: left">Fmtos</DIV><DIV style="FLOAT: right"><INPUT id="BtnCerrar" type=button value="X" /></DIV></DIV></asp:Panel>&nbsp;<TABLE><TBODY><TR><TD colSpan=3><asp:Label id="SubT" runat="server" CssClass="SubTitulo" Text="Nuevo"></asp:Label></TD></TR><TR><TD colSpan=3><asp:ValidationSummary id="ValidationSummary1" runat="server"></asp:ValidationSummary></TD></TR><TR><TD style="WIDTH: 98px">Código de la Tabla</TD><TD style="WIDTH: 100px"><asp:TextBox id="TxtCodiNew" runat="server"></asp:TextBox></TD><TD style="WIDTH: 100px"><asp:RequiredFieldValidator id="RequiredFieldValidator1" runat="server" ControlToValidate="TxtCodiNew" ErrorMessage="Digite Codigo de la Tabla">*</asp:RequiredFieldValidator></TD></TR><TR><TD style="WIDTH: 98px; HEIGHT: 23px"><asp:Label id="Label1" runat="server" Width="126px" Text="Nombre de la Tabla"></asp:Label></TD><TD style="WIDTH: 100px; HEIGHT: 23px"><asp:TextBox id="txtnombNew" runat="server" Width="177px"></asp:TextBox></TD><TD style="WIDTH: 100px; HEIGHT: 23px"><asp:RequiredFieldValidator id="RequiredFieldValidator3" runat="server" ControlToValidate="txtnombNew" ErrorMessage="Digite Nombre de la Tabla">*</asp:RequiredFieldValidator></TD></TR><TR><TD style="WIDTH: 98px; HEIGHT: 18px"><asp:Label id="Label2" runat="server" Width="117px" Text="Formatos Descripcion"></asp:Label></TD><TD style="WIDTH: 100px; HEIGHT: 18px"><asp:TextBox id="txtdescNew" runat="server" Width="240px"></asp:TextBox></TD><TD style="WIDTH: 100px; HEIGHT: 18px"><asp:RequiredFieldValidator id="RequiredFieldValidator4" runat="server" ControlToValidate="txtdescNew" ErrorMessage="Digite Formatos Descripcion">*</asp:RequiredFieldValidator></TD></TR><TR><TD style="WIDTH: 98px; HEIGHT: 19px"><asp:Label id="Label3" runat="server" Width="137px" Text="Clase de Declaracion"></asp:Label></TD><TD style="WIDTH: 100px; HEIGHT: 19px"><asp:TextBox id="txtcdecNew" runat="server" __designer:wfdid="w12"></asp:TextBox></TD><TD style="WIDTH: 100px; HEIGHT: 19px"><asp:RequiredFieldValidator id="RequiredFieldValidator2" runat="server" ControlToValidate="txtcdecNew" ErrorMessage="Digite la Clase de Declaracion" __designer:wfdid="w13">*</asp:RequiredFieldValidator></TD></TR><TR><TD style="WIDTH: 98px; HEIGHT: 22px"><asp:Label id="Label4" runat="server" Width="109px" Text="Estado del Formato"></asp:Label></TD><TD style="WIDTH: 100px; HEIGHT: 22px"><asp:DropDownList id="cboest" runat="server" __designer:wfdid="w1"><asp:ListItem Value="AC">Activo</asp:ListItem>
<asp:ListItem Value="IN">Inactivo</asp:ListItem>
</asp:DropDownList></TD><TD style="WIDTH: 100px; HEIGHT: 22px"></TD></TR><TR><TD style="WIDTH: 98px"></TD><TD style="WIDTH: 100px"></TD><TD style="WIDTH: 100px"></TD></TR><TR><TD style="WIDTH: 98px"></TD><TD style="WIDTH: 100px"></TD><TD style="WIDTH: 100px"></TD></TR><TR><TD style="TEXT-ALIGN: center" colSpan=3><asp:Button id="BtnGuardar" onclick="BtnGuardar_Click" runat="server" Text="Guardar"></asp:Button>&nbsp;<asp:Button id="BtnEliminar" onclick="BtnEliminar_Click" runat="server" Text="Eliminar"></asp:Button>&nbsp; <INPUT id="BtnCancelar" type=button value="Cancelar" /> </TD></TR></TBODY></TABLE>&nbsp; </asp:Panel>&nbsp;&nbsp; 
</contenttemplate>
    </asp:UpdatePanel><asp:ObjectDataSource ID="ObjTiCo" runat="server" OldValuesParameterFormatString="original_{0}"
        SelectMethod="GetRecords" TypeName="Tipo_Conceptos"></asp:ObjectDataSource>
    <asp:UpdateProgress id="UpdateProgress1" runat="server" AssociatedUpdatePanelID="UpdatePanel1">
        <progresstemplate>
            <div class="Loading">
            <img src="../../images/loading.gif" alt="" title="" /> Cargando …
            </div>
        </progresstemplate>
    </asp:UpdateProgress>
    <br />
</div>

</asp:Content>

