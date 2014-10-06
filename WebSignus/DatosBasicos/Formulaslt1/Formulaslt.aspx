<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="Formulaslt.aspx.vb" Inherits="DatosBasicos_Formulaslt1_Formulaslt" title="Untitled Page" %>
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
            <asp:Label id="Tit" runat="server" Width="286px" 
                Text="Configuración de Tarifas" CssClass="Titulo" 
                __designer:wfdid="w202"></asp:Label>
            <br />
    &nbsp; &nbsp;
            <asp:HyperLink ID="HyperLink1" runat="server" 
                NavigateUrl="~/DatosBasicos/Formulaslt1/ProbarTarifa.aspx" 
                ToolTip="Opción para probar el cálculo de tarifas en tiempo de ejecución">Probar 
            Tarifas</asp:HyperLink>
    <br />
    <asp:UpdatePanel id="UpdatePanel1" runat="server">
        <contenttemplate>
&nbsp;<BR /><asp:Label id="MsgResult" runat="server" __designer:wfdid="w203"></asp:Label>&nbsp;&nbsp;&nbsp;<BR />&nbsp;<asp:GridView id="GridView1" runat="server" Width="902px" ForeColor="#333333" EmptyDataText="No se encontraron Registros en la Base de Datos" OnSelectedIndexChanged="GridView1_SelectedIndexChanged" AutoGenerateColumns="False" DataKeyNames="FORM_CODI,FORM_CIMP" OnRowCommand="GridView1_RowCommand" ShowFooter="True" CellPadding="4" GridLines="None" DataSourceID="Objform" AllowPaging="True" OnRowDataBound="GridView1_RowDataBound1" AllowSorting="True" __designer:wfdid="w204">
<RowStyle BackColor="#F7F6F3" ForeColor="#333333"></RowStyle>
<Columns>
<asp:TemplateField HeaderText="C&#243;digo " SortExpression="FORM_CODI"><FooterTemplate>
<asp:LinkButton id="lnkNuevo" runat="server" Text="Nuevo Registro" CausesValidation="False" CommandName="Nuevo" __designer:wfdid="w12"></asp:LinkButton> 
</FooterTemplate>
<ItemTemplate>
<asp:Label id="LbCodi" runat="server" Text='<%# Bind("FORM_CODI") %>' __designer:wfdid="w60"></asp:Label> 
</ItemTemplate>
</asp:TemplateField>
<asp:BoundField DataField="CLIM_NOMB" HeaderText="Clase"></asp:BoundField>
<asp:TemplateField HeaderText="Cod Imp." SortExpression="FORM_CIMP"><ItemTemplate>
<asp:Label id="Lbcimp" runat="server" Text='<%# Bind("FORM_CIMP") %>' __designer:wfdid="w61"></asp:Label> 
</ItemTemplate>
</asp:TemplateField>
<asp:BoundField DataField="Imp_Nom" HeaderText="Impuesto" SortExpression="Imp_Nom"></asp:BoundField>
<asp:TemplateField HeaderText="Formula" SortExpression="FORM_FORM" Visible="False"><ItemTemplate>
<asp:Label id="Lbform" runat="server" Text='<%# Bind("FORM_FORM") %>' __designer:wfdid="w16"></asp:Label> 
</ItemTemplate>
</asp:TemplateField>
<asp:BoundField DataField="Uni_Nom" HeaderText="Medida">
<ItemStyle Width="50px"></ItemStyle>
</asp:BoundField>
<asp:TemplateField HeaderText="Fecha Inicial" SortExpression="FORM_FEIN"><EditItemTemplate>
<asp:TextBox runat="server" Text='<%# Bind("FORM_FEIN") %>' id="TextBox1"></asp:TextBox>
</EditItemTemplate>
<ItemTemplate>
<asp:Label runat="server" Text='<%# Bind("FORM_FEIN", "{0:d}") %>' id="Label1"></asp:Label>
</ItemTemplate>
</asp:TemplateField>
<asp:TemplateField HeaderText="Fecha Final" SortExpression="FORM_FEFI"><EditItemTemplate>
<asp:TextBox runat="server" Text='<%# Bind("FORM_FEFI") %>' id="TextBox2"></asp:TextBox>
</EditItemTemplate>
<ItemTemplate>
<asp:Label runat="server" Text='<%# Bind("FORM_FEFI", "{0:d}") %>' id="Label2"></asp:Label>
</ItemTemplate>
</asp:TemplateField>
<asp:TemplateField HeaderText="Norma que Reglamenta la Formula" SortExpression="FORM_NORM"><ItemTemplate>
<asp:Label id="Lbnorm" runat="server" Text='<%# Bind("FORM_NORM") %>' __designer:wfdid="w17"></asp:Label> 
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
</asp:GridView> <asp:ObjectDataSource id="Objform" runat="server" SelectMethod="GetRecords" TypeName="Formulaslt1" __designer:wfdid="w205"></asp:ObjectDataSource><!-- <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White"></FooterStyle>-->&nbsp; <asp:HiddenField id="Oper" runat="server" __designer:wfdid="w206"></asp:HiddenField>&nbsp;<asp:HiddenField id="HdPk1" runat="server" __designer:wfdid="w207"></asp:HiddenField>&nbsp;&nbsp;&nbsp;&nbsp;<asp:HiddenField id="Hdpk2" runat="server" __designer:wfdid="w208"></asp:HiddenField><BR />
</contenttemplate>
        <triggers>
<asp:AsyncPostBackTrigger ControlID="GridView1" EventName="SelectedIndexChanged"></asp:AsyncPostBackTrigger>
<asp:AsyncPostBackTrigger ControlID="GridView1" EventName="Sorting"></asp:AsyncPostBackTrigger>
</triggers>
    </asp:UpdatePanel>&nbsp;
    &nbsp;&nbsp;&nbsp;&nbsp;<asp:UpdatePanel id="UpdatePanel2"
        runat="server"><contenttemplate>
<!-- Mensaje de Salida--><BR /><asp:Button style="DISPLAY: none" id="hiddenTargetControlForModalPopup2" runat="server" __designer:wfdid="w175"></asp:Button> <ajaxToolkit:ModalPopupExtender id="ModalPopupTer" runat="server" TargetControlID="hiddenTargetControlForModalPopup2" RepositionMode="RepositionOnWindowScroll" BehaviorID="programmaticModalPopupBehavior2" BackgroundCssClass="modalBackground" DropShadow="True" PopupControlID="programmaticPopup2" PopupDragHandleControlID="programmaticPopupDragHandle2" __designer:wfdid="w176">
            </ajaxToolkit:ModalPopupExtender>&nbsp;&nbsp; <asp:Panel id="programmaticPopup2" runat="server" Width="645px" Height="469px" CssClass="ModalPanel2" __designer:wfdid="w177"><asp:Panel id="programmaticPopupDragHandle2" runat="Server" Width="641px" Height="30px" CssClass="BarTitleModal2" __designer:wfdid="w178"><DIV style="PADDING-RIGHT: 5px; PADDING-LEFT: 5px; PADDING-BOTTOM: 5px; VERTICAL-ALIGN: middle; PADDING-TOP: 5px"><DIV style="FLOAT: left">Formulaslt</DIV><DIV style="FLOAT: right"><INPUT id="BtnCerrar" type=button value="X" /></DIV></DIV></asp:Panel>&nbsp;<TABLE style="WIDTH: 642px; HEIGHT: 269px"><TBODY><TR><TD colSpan=3><asp:Label id="SubT" runat="server" Text="Nuevo" CssClass="SubTitulo" __designer:wfdid="w179"></asp:Label></TD></TR><TR><TD colSpan=3><asp:ValidationSummary id="ValidationSummary1" runat="server" __designer:wfdid="w180"></asp:ValidationSummary></TD></TR><TR><TD style="WIDTH: 98px"><asp:Label id="Label1" runat="server" Width="126px" Text="Codigo del Impuesto" __designer:wfdid="w181"></asp:Label></TD><TD style="WIDTH: 100px"><asp:DropDownList id="CboImpto" runat="server" DataSourceID="ObjImp" __designer:wfdid="w182" DataValueField="IMP_COD" DataTextField="IMP_CNOM"></asp:DropDownList></TD><TD style="WIDTH: 100px"></TD></TR><TR><TD style="WIDTH: 98px; HEIGHT: 23px">&nbsp;<asp:Label id="Label4" runat="server" Width="143px" Text="Codigo de la Formula" __designer:wfdid="w183"></asp:Label></TD><TD style="WIDTH: 100px; HEIGHT: 23px"><asp:TextBox id="TxtcodiNew" runat="server" __designer:wfdid="w184"></asp:TextBox></TD><TD style="WIDTH: 100px; HEIGHT: 23px"><asp:RequiredFieldValidator id="RequiredFieldValidator1" runat="server" ErrorMessage="Digite Codigo de la Formula" ControlToValidate="TxtcodiNew" __designer:wfdid="w185">*</asp:RequiredFieldValidator></TD></TR><TR><TD style="WIDTH: 98px; HEIGHT: 18px"><asp:Label id="Label2" runat="server" Width="117px" Text="Fecha Inicial" __designer:wfdid="w186"></asp:Label></TD><TD style="WIDTH: 100px; HEIGHT: 18px"><asp:TextBox id="TxtFecIni" runat="server" __designer:wfdid="w187"></asp:TextBox></TD><TD style="WIDTH: 100px; HEIGHT: 18px"><asp:RequiredFieldValidator id="RequiredFieldValidator4" runat="server" ErrorMessage="Digite Fecha de Inicio" ControlToValidate="TxtFecIni" __designer:wfdid="w188">*</asp:RequiredFieldValidator></TD></TR><TR><TD style="WIDTH: 98px; HEIGHT: 19px"><asp:Label id="Label3" runat="server" Text="Fecha Final" __designer:wfdid="w189"></asp:Label></TD><TD style="WIDTH: 100px; HEIGHT: 19px"><asp:TextBox id="TxtFecFin" runat="server" __designer:wfdid="w190"></asp:TextBox></TD><TD style="WIDTH: 100px; HEIGHT: 19px"><asp:RequiredFieldValidator id="RequiredFieldValidator2" runat="server" ErrorMessage="Digite Fecha Final" ControlToValidate="TxtFecFin" __designer:wfdid="w191">*</asp:RequiredFieldValidator></TD></TR><TR><TD style="WIDTH: 98px; HEIGHT: 149px"><asp:Label id="Label5" runat="server" Text="Formula" __designer:wfdid="w192"></asp:Label></TD><TD style="WIDTH: 100px; HEIGHT: 149px"><asp:TextBox id="txtformNew" runat="server" Width="432px" Height="140px" __designer:wfdid="w193" TextMode="MultiLine"></asp:TextBox></TD><TD style="WIDTH: 100px; HEIGHT: 149px"><asp:RequiredFieldValidator id="RequiredFieldValidator5" runat="server" ErrorMessage="Digite Formula" ControlToValidate="txtformNew" __designer:wfdid="w194">*</asp:RequiredFieldValidator></TD></TR><TR><TD style="WIDTH: 98px; HEIGHT: 22px"><asp:Label id="Label6" runat="server" Width="172px" Text="Norma que Reglamenta la Formula" __designer:wfdid="w195"></asp:Label></TD><TD style="WIDTH: 100px; HEIGHT: 22px"><asp:TextBox id="txtnormNew" runat="server" Width="429px" __designer:wfdid="w196" TextMode="MultiLine"></asp:TextBox></TD><TD style="WIDTH: 100px; HEIGHT: 22px"><asp:RequiredFieldValidator id="RequiredFieldValidator6" runat="server" ErrorMessage="Digite Norma" ControlToValidate="txtnormNew" __designer:wfdid="w197">*</asp:RequiredFieldValidator></TD></TR><TR><TD style="WIDTH: 98px"></TD><TD style="WIDTH: 100px"></TD><TD style="WIDTH: 100px"></TD></TR><TR><TD style="WIDTH: 98px"></TD><TD style="WIDTH: 100px"></TD><TD style="WIDTH: 100px"></TD></TR><TR><TD style="HEIGHT: 22px; TEXT-ALIGN: center" colSpan=3><asp:Button id="BtnGuardar" onclick="BtnGuardar_Click" runat="server" Text="Guardar" __designer:wfdid="w198"></asp:Button>&nbsp;<asp:Button id="BtnEliminar" onclick="BtnEliminar_Click" runat="server" Text="Eliminar" __designer:wfdid="w199"></asp:Button>&nbsp; <INPUT id="BtnCancelar" type=button value="Cancelar" /> </TD></TR></TBODY></TABLE>&nbsp; <ajaxToolkit:CalendarExtender id="CalendarExtender3" runat="server" TargetControlID="TxtFecIni" __designer:wfdid="w200"></ajaxToolkit:CalendarExtender> <ajaxToolkit:CalendarExtender id="CalendarExtender4" runat="server" TargetControlID="TxtFecFin" __designer:wfdid="w201"></ajaxToolkit:CalendarExtender></asp:Panel>&nbsp;&nbsp; 
</contenttemplate>
    </asp:UpdatePanel><asp:ObjectDataSource ID="ObjImp" runat="server" SelectMethod="GetRecords"
        TypeName="Impuestos"></asp:ObjectDataSource>
            <br />
</div>

</asp:Content>

