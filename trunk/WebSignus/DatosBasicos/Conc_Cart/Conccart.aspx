<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="Conccart.aspx.vb" Inherits="DatosBasicos_Conc_Cart_Conccart" title="Untitled Page" %>
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
&nbsp;<asp:Label id="Tit" runat="server" Width="286px" CssClass="Titulo" Text="Conceptos de Cartera"></asp:Label><BR /><asp:Label id="MsgResult" runat="server"></asp:Label>&nbsp;&nbsp;<BR /><asp:GridView id="GridView1" runat="server" Width="100%" ForeColor="#333333" PageSize="20" AllowSorting="True" OnRowDataBound="GridView1_RowDataBound1" AllowPaging="True" DataSourceID="Objcon" GridLines="None" CellPadding="4" ShowFooter="True" OnRowCommand="GridView1_RowCommand" DataKeyNames="CCAR_COD" AutoGenerateColumns="False" OnSelectedIndexChanged="GridView1_SelectedIndexChanged" EmptyDataText="No se encontraron Registros en la Base de Datos">
<RowStyle BackColor="#F7F6F3" ForeColor="#333333"></RowStyle>
<Columns>
<asp:TemplateField HeaderText="C&#243;digo" SortExpression="CCAR_COD"><FooterTemplate>
<asp:LinkButton id="lnkNuevo" runat="server" Text="Nuevo Registro" CommandName="Nuevo" CausesValidation="False" __designer:wfdid="w27"></asp:LinkButton> 
</FooterTemplate>
<ItemTemplate>
<asp:Label id="LbCod" runat="server" Text='<%# Bind("CCAR_COD") %>' __designer:wfdid="w26"></asp:Label> 
</ItemTemplate>
</asp:TemplateField>
<asp:TemplateField HeaderText="Abreviatura del Concepto" SortExpression="CCAR_AVCO"><ItemTemplate>
<asp:Label id="Lbavco" runat="server" Text='<%# Bind("CCAR_AVCO") %>' __designer:wfdid="w22"></asp:Label> 
</ItemTemplate>
</asp:TemplateField>
<asp:TemplateField HeaderText="Nombre del Concepto" SortExpression="CCAR_NOM"><ItemTemplate>
<asp:Label id="LbNom" runat="server" Text='<%# Bind("CCAR_NOM") %>' __designer:wfdid="w23"></asp:Label> 
</ItemTemplate>
</asp:TemplateField>
<asp:TemplateField HeaderText="Tipo de Concepto" SortExpression="CCAR_TICO"><ItemTemplate>
<asp:Label id="Lbtico" runat="server" Text='<%# Bind("CCAR_TICO") %>' __designer:wfdid="w24"></asp:Label> 
</ItemTemplate>
</asp:TemplateField>
<asp:TemplateField HeaderText="Clase de Declaracion" SortExpression="CCAR_CDEC"><ItemTemplate>
<asp:Label id="Lbcdec" runat="server" Text='<%# Bind("CCAR_CDEC") %>' __designer:wfdid="w25"></asp:Label> 
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
</asp:GridView> <asp:ObjectDataSource id="Objcon" runat="server" TypeName="Conc_Cart" SelectMethod="GetRecords"></asp:ObjectDataSource><!-- <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White"></FooterStyle>-->&nbsp; <asp:HiddenField id="Oper" runat="server"></asp:HiddenField>&nbsp;<asp:HiddenField id="HdPk1" runat="server"></asp:HiddenField>&nbsp;&nbsp;<BR />&nbsp;&nbsp;<BR />
</contenttemplate>
    </asp:UpdatePanel>&nbsp;
    &nbsp;&nbsp;&nbsp;&nbsp;<asp:UpdatePanel id="UpdatePanel2"
        runat="server"><contenttemplate>
<!-- Mensaje de Salida--><BR /><asp:Button style="DISPLAY: none" id="hiddenTargetControlForModalPopup2" runat="server"></asp:Button> <ajaxToolkit:ModalPopupExtender id="ModalPopupTer" runat="server" TargetControlID="hiddenTargetControlForModalPopup2" RepositionMode="RepositionOnWindowScroll" BehaviorID="programmaticModalPopupBehavior2" BackgroundCssClass="modalBackground" DropShadow="True" PopupControlID="programmaticPopup2" PopupDragHandleControlID="programmaticPopupDragHandle2">
            </ajaxToolkit:ModalPopupExtender>&nbsp;&nbsp; <asp:Panel id="programmaticPopup2" runat="server" Width="492px" Height="327px" CssClass="ModalPanel2"><asp:Panel id="programmaticPopupDragHandle2" runat="Server" Width="483px" Height="30px" CssClass="BarTitleModal2" __designer:wfdid="w988"><DIV style="PADDING-RIGHT: 5px; PADDING-LEFT: 5px; PADDING-BOTTOM: 5px; VERTICAL-ALIGN: middle; PADDING-TOP: 5px"><DIV style="FLOAT: left">Tipo de Agente Recaudador</DIV><DIV style="FLOAT: right"><INPUT id="BtnCerrar" type=button value="X" /></DIV></DIV></asp:Panel>&nbsp;<TABLE><TBODY><TR><TD colSpan=3><asp:Label id="SubT" runat="server" Text="Nuevo" CssClass="SubTitulo" __designer:wfdid="w989"></asp:Label></TD></TR><TR><TD colSpan=3><asp:ValidationSummary id="ValidationSummary1" runat="server" __designer:wfdid="w990"></asp:ValidationSummary></TD></TR><TR><TD style="WIDTH: 98px">Código</TD><TD style="WIDTH: 100px"><asp:TextBox id="TxtCodNew" runat="server" __designer:wfdid="w991"></asp:TextBox></TD><TD style="WIDTH: 100px"><asp:RequiredFieldValidator id="RequiredFieldValidator1" runat="server" ErrorMessage="Digite un Codigo" ControlToValidate="TxtCodNew" __designer:wfdid="w992">*</asp:RequiredFieldValidator></TD></TR><TR><TD style="WIDTH: 98px; HEIGHT: 23px"><asp:Label id="Label1" runat="server" Width="126px" Text="Abreviatura del Concepto" __designer:wfdid="w993"></asp:Label></TD><TD style="WIDTH: 100px; HEIGHT: 23px"><asp:TextBox id="txtavcoNew" runat="server" Width="41px" __designer:wfdid="w994"></asp:TextBox></TD><TD style="WIDTH: 100px; HEIGHT: 23px"><asp:RequiredFieldValidator id="RequiredFieldValidator3" runat="server" ErrorMessage="Digite Abreviatura del Concepto" ControlToValidate="TxtavcoNew" __designer:wfdid="w995">*</asp:RequiredFieldValidator></TD></TR><TR><TD style="WIDTH: 98px; HEIGHT: 18px"><asp:Label id="Label2" runat="server" Width="117px" Text="Nombre del Concepto" __designer:wfdid="w996"></asp:Label></TD><TD style="WIDTH: 100px; HEIGHT: 18px"><asp:TextBox id="txtnomNew" runat="server" Width="240px" __designer:wfdid="w997"></asp:TextBox></TD><TD style="WIDTH: 100px; HEIGHT: 18px"><asp:RequiredFieldValidator id="RequiredFieldValidator4" runat="server" ErrorMessage="Digite un Nombre" ControlToValidate="txtnomNew" __designer:wfdid="w998">*</asp:RequiredFieldValidator></TD></TR><TR><TD style="WIDTH: 98px; HEIGHT: 19px"><asp:Label id="Label3" runat="server" Text="Tipo de Concepto" __designer:wfdid="w999"></asp:Label></TD><TD style="WIDTH: 100px; HEIGHT: 19px"><asp:DropDownList id="CboTico" runat="server" __designer:dtid="281474976710787" DataSourceID="ObjTiCo" __designer:wfdid="w1000" DataTextField="TCon_CNom" DataValueField="TCon_Cod"><asp:ListItem Value="C" __designer:dtid="281474976710788">Texto</asp:ListItem>
<asp:ListItem Value="N" __designer:dtid="281474976710789">N&#250;merico</asp:ListItem>
<asp:ListItem Value="D" __designer:dtid="281474976710790">Fecha</asp:ListItem>
</asp:DropDownList></TD><TD style="WIDTH: 100px; HEIGHT: 19px"></TD></TR><TR><TD style="WIDTH: 98px"><asp:Label id="Label4" runat="server" Width="109px" Text="Clase de Declaracion" __designer:wfdid="w1001"></asp:Label></TD><TD style="WIDTH: 100px"><asp:TextBox id="txtcdecNew" runat="server" __designer:wfdid="w1002"></asp:TextBox></TD><TD style="WIDTH: 100px"><asp:RequiredFieldValidator id="RequiredFieldValidator5" runat="server" ErrorMessage="Digite la Clase de Declaracion" ControlToValidate="txtcdecNew" __designer:wfdid="w1003">*</asp:RequiredFieldValidator></TD></TR><TR><TD style="WIDTH: 98px"></TD><TD style="WIDTH: 100px"></TD><TD style="WIDTH: 100px"></TD></TR><TR><TD style="WIDTH: 98px"></TD><TD style="WIDTH: 100px"></TD><TD style="WIDTH: 100px"></TD></TR><TR><TD style="TEXT-ALIGN: center" colSpan=3><asp:Button id="BtnGuardar" onclick="BtnGuardar_Click" runat="server" Text="Guardar" __designer:wfdid="w1004"></asp:Button>&nbsp;<asp:Button id="BtnEliminar" onclick="BtnEliminar_Click" runat="server" Text="Eliminar" __designer:wfdid="w1005"></asp:Button>&nbsp; <INPUT id="BtnCancelar" type=button value="Cancelar" /> </TD></TR></TBODY></TABLE>&nbsp; </asp:Panel>&nbsp;&nbsp; 
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

