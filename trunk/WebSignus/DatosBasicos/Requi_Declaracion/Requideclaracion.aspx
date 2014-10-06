<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="Requideclaracion.aspx.vb" Inherits="DatosBasicos_Requi_Declaracion_Requideclaracion" title="Untitled Page" %>
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
&nbsp;<asp:Label id="Tit" runat="server" Width="441px" CssClass="Titulo" Text="REQUISITOS FORMALES PARA PRESENTAR DECLARACIONES"></asp:Label><BR /><asp:Label id="MsgResult" runat="server"></asp:Label>&nbsp;&nbsp;&nbsp;<BR />&nbsp;<asp:GridView 
                id="GridView1" runat="server" Width="633px" ForeColor="#333333" 
                EmptyDataText="No se encontraron Registros en la Base de Datos" 
                OnSelectedIndexChanged="GridView1_SelectedIndexChanged" 
                AutoGenerateColumns="False" DataKeyNames="REQ_COD,REQ_CLDEC" 
                OnRowCommand="GridView1_RowCommand" ShowFooter="True" CellPadding="4" 
                GridLines="None" DataSourceID="Objrequi" AllowPaging="True" 
                OnRowDataBound="GridView1_RowDataBound1" AllowSorting="True">
<RowStyle BackColor="#F7F6F3" ForeColor="#333333"></RowStyle>
<Columns>
<asp:TemplateField HeaderText="Clase Dec" SortExpression="REQ_CLDEC"><FooterTemplate>
<asp:LinkButton id="lnkNuevo" runat="server" Text="Nuevo Registro" CommandName="Nuevo" CausesValidation="False" __designer:wfdid="w4"></asp:LinkButton> 
</FooterTemplate>
<ItemTemplate>
<asp:Label id="LbCldec" runat="server" Text='<%# Bind("REQ_CLDEC") %>' __designer:wfdid="w34"></asp:Label> 
</ItemTemplate>
</asp:TemplateField>
<asp:TemplateField HeaderText="Codigo del Requisito" SortExpression="REQ_COD"><ItemTemplate>
<asp:Label id="Lbcod" runat="server" Text='<%# Bind("REQ_COD") %>' __designer:wfdid="w35"></asp:Label> 
</ItemTemplate>
</asp:TemplateField>
<asp:TemplateField HeaderText="Descripcion del Requisito" SortExpression="REQ_DESC"><ItemTemplate>
<asp:Label id="Lbdesc" runat="server" Text='<%# Bind("REQ_DESC") %>' __designer:wfdid="w6"></asp:Label> 
</ItemTemplate>
</asp:TemplateField>
<asp:TemplateField HeaderText="Fecha de inicio" SortExpression="REQ_FINI"><ItemTemplate>
<asp:Label id="Lbfini" runat="server" Text='<%# Bind("REQ_FINI","{0:d}") %>' __designer:wfdid="w7"></asp:Label> 
</ItemTemplate>
</asp:TemplateField>
<asp:TemplateField HeaderText="Fecha Final" SortExpression="REQ_FFIN"><ItemTemplate>
<asp:Label id="Lbffin" runat="server" Text='<%# Bind("REQ_FFIN","{0:d}") %>' __designer:wfdid="w8"></asp:Label> 
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
</asp:GridView> <asp:ObjectDataSource id="Objrequi" runat="server" SelectMethod="GetRecords" TypeName="Requi_Declaracion"></asp:ObjectDataSource><!-- <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White"></FooterStyle>-->&nbsp; <asp:HiddenField id="Oper" runat="server"></asp:HiddenField>&nbsp;<asp:HiddenField id="HdPk1" runat="server"></asp:HiddenField>
            <asp:HiddenField ID="HdPk2" runat="server" />
            &nbsp;&nbsp;&nbsp;&nbsp;<BR />
</contenttemplate>
    </asp:UpdatePanel>&nbsp;
    &nbsp;&nbsp;&nbsp;&nbsp;<asp:UpdatePanel id="UpdatePanel2"
        runat="server"><contenttemplate>
<!-- Mensaje de Salida--><BR /><asp:Button style="DISPLAY: none" id="hiddenTargetControlForModalPopup2" runat="server"></asp:Button> <ajaxToolkit:ModalPopupExtender id="ModalPopupTer" runat="server" PopupDragHandleControlID="programmaticPopupDragHandle2" PopupControlID="programmaticPopup2" DropShadow="True" BackgroundCssClass="modalBackground" BehaviorID="programmaticModalPopupBehavior2" RepositionMode="RepositionOnWindowScroll" TargetControlID="hiddenTargetControlForModalPopup2">
            </ajaxToolkit:ModalPopupExtender>&nbsp;&nbsp; <asp:Panel id="programmaticPopup2" runat="server" Width="638px" Height="489px" CssClass="ModalPanel2"><asp:Panel id="programmaticPopupDragHandle2" runat="Server" Width="641px" Height="30px" CssClass="BarTitleModal2"><DIV style="PADDING-RIGHT: 5px; PADDING-LEFT: 5px; PADDING-BOTTOM: 5px; VERTICAL-ALIGN: middle; PADDING-TOP: 5px"><DIV style="FLOAT: left">Requisitos&#160; 
                        de Declaracion</DIV><DIV style="FLOAT: right">
                        <INPUT id="BtnCerrar" type=button value="X" /></DIV></DIV></asp:Panel>&nbsp;<TABLE style="WIDTH: 637px; HEIGHT: 359px"><TBODY><TR><TD colSpan=3><asp:Label id="SubT" runat="server" Text="Nuevo" CssClass="SubTitulo"></asp:Label></TD></TR>
        <TR><TD colSpan=3>
            <asp:ValidationSummary id="ValidationSummary1" runat="server">
                     </asp:ValidationSummary></TD></TR>
        <TR>
            <TD style="WIDTH: 98px; HEIGHT: 10px; TEXT-ALIGN: justify"><asp:Label id="Label4" 
                         runat="server" Width="143px" Text="Clase Declaración"></asp:Label></TD>
            <TD style="WIDTH: 100px; HEIGHT: 10px">
                <asp:TextBox ID="TxtcldecNew" runat="server"></asp:TextBox></TD>
            <TD style="WIDTH: 100px; HEIGHT: 10px">
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
                         ControlToValidate="TxtcldecNew" ErrorMessage="Digite Tipo de Impuesto">*</asp:RequiredFieldValidator></TD></TR>
        <TR>
            <TD style="WIDTH: 98px; HEIGHT: 13px; TEXT-ALIGN: justify"><asp:Label id="Label1" runat="server" Width="126px" Text="Codigo del Requisito"></asp:Label></TD>
            <TD style="WIDTH: 100px; HEIGHT: 13px">
                <asp:TextBox ID="txtcodNew" runat="server"></asp:TextBox></TD>
            <TD style="WIDTH: 100px; HEIGHT: 13px">
                <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" 
                         ControlToValidate="txtcodNew" ErrorMessage="Digite Codigo del Requisito">*</asp:RequiredFieldValidator></TD></TR>
        <TR><TD style="WIDTH: 98px; HEIGHT: 6px"><asp:Label id="Label2" runat="server" Width="156px" Text="Descripcion del Requisito"></asp:Label></TD>
            <TD style="WIDTH: 100px; HEIGHT: 6px">
                <asp:TextBox ID="TxtdescNew" runat="server" Height="56px" TextMode="MultiLine" 
                         Width="322px"></asp:TextBox></TD>
            <TD style="WIDTH: 100px; HEIGHT: 6px">
                <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" 
                         ControlToValidate="TxtdescNew" 
                         ErrorMessage="Digite la Descripcion del Requisito">*</asp:RequiredFieldValidator></TD></TR>
        <TR><TD style="WIDTH: 98px; HEIGHT: 7px"><asp:Label id="Label3" runat="server" Text="Fecha de Inicio"></asp:Label></TD>
            <TD style="WIDTH: 100px; HEIGHT: 7px; TEXT-ALIGN: left">
                <asp:TextBox id="TxtFecini" runat="server"></asp:TextBox></TD>
            <TD style="WIDTH: 100px; HEIGHT: 7px">
                <asp:RequiredFieldValidator id="RequiredFieldValidator2" runat="server" ControlToValidate="TxtFecini" ErrorMessage="Digite Fecha Inicial">*</asp:RequiredFieldValidator></TD></TR>
        <TR><TD style="WIDTH: 98px; HEIGHT: 5px"><asp:Label id="Label5" runat="server" Text="Fecha Final"></asp:Label></TD>
            <TD style="WIDTH: 100px; HEIGHT: 5px">
                <asp:TextBox ID="txtfecfin" runat="server" __designer:wfdid="w1"></asp:TextBox></TD>
            <TD style="WIDTH: 100px; HEIGHT: 5px">
                <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" 
                         ControlToValidate="txtfecfin" ErrorMessage="Digite Fecha Final">*</asp:RequiredFieldValidator></TD></TR>
        <TR><TD style="WIDTH: 98px"></TD>
            <TD style="WIDTH: 100px"></TD><TD style="WIDTH: 100px"></TD></TR><TR>
            <TD style="WIDTH: 98px; HEIGHT: 21px"></TD>
            <TD style="WIDTH: 100px; HEIGHT: 21px"></TD>
            <TD style="WIDTH: 100px; HEIGHT: 21px"></TD></TR>
        <TR><TD style="WIDTH: 98px"></TD>
            <TD style="WIDTH: 100px"></TD><TD style="WIDTH: 100px"></TD></TR><TR>
            <TD style="HEIGHT: 21px; TEXT-ALIGN: center" colSpan=3>
                <asp:Button id="BtnGuardar" onclick="BtnGuardar_Click" runat="server" Text="Guardar"></asp:Button>&nbsp;<asp:Button id="BtnEliminar" onclick="BtnEliminar_Click" runat="server" Text="Eliminar"></asp:Button>&nbsp; <INPUT id="BtnCancelar" type=button value="Cancelar" /> </TD></TR></TBODY></TABLE>&nbsp; <ajaxToolkit:CalendarExtender id="CalendarExtender3" runat="server" TargetControlID="TxtFecIni"></ajaxToolkit:CalendarExtender> <ajaxToolkit:CalendarExtender id="CalendarExtender4" runat="server" TargetControlID="TxtFecFin"></ajaxToolkit:CalendarExtender></asp:Panel>&nbsp;&nbsp; 
</contenttemplate>
    </asp:UpdatePanel><br />
</div>

</asp:Content>

