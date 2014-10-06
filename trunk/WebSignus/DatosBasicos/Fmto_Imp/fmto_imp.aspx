<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="fmto_imp.aspx.vb" Inherits="DatosBasicos_Fmto_Imp_fmto_imp" title="Untitled Page" %>
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
&nbsp;<asp:Label id="Tit" runat="server" Width="286px" CssClass="Titulo" 
                Text="FORMATO DE VALIDACIÓN"></asp:Label><BR /><asp:Label id="Label5" runat="server" Text="Código Fmto" __designer:wfdid="w3"></asp:Label><BR /><asp:TextBox id="TxtFiltro" runat="server" __designer:wfdid="w2"></asp:TextBox> <asp:Button id="BtnFiltrar" runat="server" Text="+ Filtro" __designer:wfdid="w5" OnClick="BtnFiltrar_Click"></asp:Button> <asp:Button id="BtnQFiltrar" runat="server" Text=" - Filtro" __designer:wfdid="w6" OnClick="BtnQFiltrar_Click"></asp:Button><BR /><asp:Label id="MsgResult" runat="server"></asp:Label>&nbsp;&nbsp;&nbsp;<BR /><asp:GridView id="GridView1" runat="server" Width="100%" ForeColor="#333333" OnSelectedIndexChanged="GridView1_SelectedIndexChanged1" PageSize="20" AllowSorting="True" OnRowDataBound="GridView1_RowDataBound1" AllowPaging="True" DataSourceID="Objfmto" GridLines="None" CellPadding="4" ShowFooter="True" OnRowCommand="GridView1_RowCommand" DataKeyNames="FMIM_CODI,FMIM_INDX" AutoGenerateColumns="False" EmptyDataText="No se encontraron Registros en la Base de Datos">
<RowStyle BackColor="#F7F6F3" ForeColor="#333333"></RowStyle>
<Columns>
<asp:TemplateField HeaderText="Nombre del Campo" SortExpression="FMIM_CAMP"><FooterTemplate>
<asp:LinkButton id="lnkNuevo" runat="server" Text="Nuevo Registro" CausesValidation="False" CommandName="Nuevo" __designer:wfdid="w6"></asp:LinkButton> 
</FooterTemplate>
<ItemTemplate>
<asp:Label id="LbCamp" runat="server" Text='<%# Bind("FMIM_CAMP") %>' __designer:wfdid="w4"></asp:Label> 
</ItemTemplate>
</asp:TemplateField>
<asp:TemplateField HeaderText="Tipo de Dato" SortExpression="FMIM_TIDA"><ItemTemplate>
<asp:Label id="Lbtida" runat="server" Text='<%# Bind("FMIM_TIDA") %>' __designer:wfdid="w7"></asp:Label> 
</ItemTemplate>
</asp:TemplateField>
<asp:TemplateField HeaderText="Codigo del Formato" SortExpression="FMIM_CODI"><ItemTemplate>
<asp:Label id="Lbcodi" runat="server" Text='<%# Bind("FMIM_CODI") %>' __designer:wfdid="w8"></asp:Label> 
</ItemTemplate>
    <ItemStyle HorizontalAlign="Center" />
</asp:TemplateField>
<asp:TemplateField HeaderText="Indice" SortExpression="FMIM_INDX"><ItemTemplate>
<asp:Label id="Lbindx" runat="server" Text='<%# Bind("FMIM_INDX") %>' __designer:wfdid="w9"></asp:Label> 
</ItemTemplate>
</asp:TemplateField>
<asp:TemplateField HeaderText="Longitud de Caracteres" SortExpression="FMIM_LONG"><ItemTemplate>
<asp:Label id="Lblong" runat="server" Text='<%# Bind("FMIM_LONG") %>' __designer:wfdid="w10"></asp:Label> 
</ItemTemplate>
    <ItemStyle HorizontalAlign="Center" />
</asp:TemplateField>
    <asp:BoundField DataField="FmIm_Est" HeaderText="Estado" />
<asp:ButtonField CommandName="Editar" ImageUrl="~/images/Operaciones/Edit2.png" Text="Editar" ButtonType="Image"></asp:ButtonField>
<asp:ButtonField CommandName="Eliminar" ImageUrl="~/images/Operaciones/delete2.png" Text="Eliminar" ButtonType="Image"></asp:ButtonField>
<asp:CommandField SelectImageUrl="~/images/Operaciones/Select.png" ShowSelectButton="True" ButtonType="Image"></asp:CommandField>
</Columns>

<FooterStyle BackColor="White" Font-Bold="True" ForeColor="#5D7B9D"></FooterStyle>

<PagerStyle HorizontalAlign="Center" BackColor="#284775" ForeColor="White"></PagerStyle>

<SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333"></SelectedRowStyle>

<HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White"></HeaderStyle>

<EditRowStyle BackColor="#999999"></EditRowStyle>

<AlternatingRowStyle BackColor="White" ForeColor="#284775"></AlternatingRowStyle>
</asp:GridView> <asp:ObjectDataSource id="Objfmto" runat="server" TypeName="FMTO_IMP" SelectMethod="GetRecords"><SelectParameters>
<asp:ControlParameter ControlID="HdFiltro" PropertyName="Value" Name="Filtro"></asp:ControlParameter>
</SelectParameters>
</asp:ObjectDataSource><!-- <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White"></FooterStyle>-->&nbsp; <asp:HiddenField id="Oper" runat="server"></asp:HiddenField> <asp:HiddenField id="HdFiltro" runat="server" __designer:wfdid="w4"></asp:HiddenField>&nbsp;<asp:HiddenField id="Hdpk2" runat="server" __designer:wfdid="w3"></asp:HiddenField> <asp:HiddenField id="HdPk1" runat="server"></asp:HiddenField>&nbsp;&nbsp;<BR />&nbsp;&nbsp;<BR />
</contenttemplate>
    </asp:UpdatePanel>&nbsp;
    &nbsp;&nbsp;&nbsp;&nbsp;<asp:UpdatePanel id="UpdatePanel2"
        runat="server"><contenttemplate>
<!-- Mensaje de Salida--><BR /><asp:Button style="DISPLAY: none" id="hiddenTargetControlForModalPopup2" runat="server"></asp:Button> <ajaxToolkit:ModalPopupExtender id="ModalPopupTer" runat="server" TargetControlID="hiddenTargetControlForModalPopup2" RepositionMode="RepositionOnWindowScroll" BehaviorID="programmaticModalPopupBehavior2" BackgroundCssClass="modalBackground" DropShadow="True" PopupControlID="programmaticPopup2" PopupDragHandleControlID="programmaticPopupDragHandle2">
            </ajaxToolkit:ModalPopupExtender>&nbsp;&nbsp; <asp:Panel id="programmaticPopup2" runat="server" Width="492px" Height="327px" CssClass="ModalPanel2"><asp:Panel id="programmaticPopupDragHandle2" runat="Server" Width="483px" Height="30px" CssClass="BarTitleModal2"><DIV style="PADDING-RIGHT: 5px; PADDING-LEFT: 5px; PADDING-BOTTOM: 5px; VERTICAL-ALIGN: middle; PADDING-TOP: 5px"><DIV style="FLOAT: left">Edición</DIV>
                    <DIV style="FLOAT: right"><INPUT id="BtnCerrar" type=button value="X" /></DIV></DIV></asp:Panel>&nbsp;<TABLE><TBODY>
        <TR>
            <TD colSpan=3><asp:ValidationSummary id="ValidationSummary1" runat="server"></asp:ValidationSummary></TD></TR><TR><TD colSpan=3>
            <asp:Label id="SubT" runat="server" Text="Nuevo" CssClass="SubTitulo"></asp:Label></TD></TR>
        <TR><TD style="WIDTH: 98px; HEIGHT: 23px"><asp:Label id="Label1" runat="server" Width="126px" Text="Tipo de Dato"></asp:Label></TD>
            <TD style="WIDTH: 100px; HEIGHT: 23px">
                <asp:DropDownList ID="Cbotida" runat="server" __designer:wfdid="w2">
                    <asp:ListItem 
                        Value="N">Numérico</asp:ListItem>
<asp:ListItem Value="C">Caracter</asp:ListItem>
<asp:ListItem Value="D">Fecha</asp:ListItem>

                    </asp:DropDownList></TD><TD style="WIDTH: 100px; HEIGHT: 23px"></TD></TR>
        <TR><TD style="WIDTH: 98px; HEIGHT: 23px">Nombre del Campo</TD>
            <TD style="WIDTH: 100px; HEIGHT: 23px">
                <asp:TextBox ID="TxtCampNew" runat="server"></asp:TextBox></TD>
            <TD style="WIDTH: 100px; HEIGHT: 23px">
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
                    ControlToValidate="TxtCampNew" ErrorMessage="Digite el Nombre del Campo">*</asp:RequiredFieldValidator></TD></TR><TR><TD style="WIDTH: 98px; HEIGHT: 19px"><asp:Label id="Label3" runat="server" Text="Indice"></asp:Label></TD>
            <TD style="WIDTH: 100px; HEIGHT: 19px">
                <asp:TextBox ID="txtindxNew" runat="server" __designer:wfdid="w1"></asp:TextBox></TD>
            <TD style="WIDTH: 100px; HEIGHT: 19px">
                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" 
                    __designer:wfdid="w2" ControlToValidate="txtindxNew" 
                    ErrorMessage="Digite el Indice">*</asp:RequiredFieldValidator></TD></TR>
        <TR>
            <TD style="WIDTH: 98px; HEIGHT: 18px"><asp:Label id="Label2" runat="server" Width="117px" Text="Codigo del Formato"></asp:Label></TD>
            <TD style="WIDTH: 100px; HEIGHT: 18px">
                <asp:TextBox ID="txtcodiNew" runat="server" Width="240px"></asp:TextBox></TD>
            <TD style="WIDTH: 100px; HEIGHT: 18px">
                <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" 
                    ControlToValidate="txtcodiNew" ErrorMessage="Digite Codigo del Formato">*</asp:RequiredFieldValidator></TD></TR>
        <TR><TD style="WIDTH: 98px">
            <asp:Label ID="Label6" runat="server" Text="Estado"></asp:Label>
            </TD>
            <TD style="WIDTH: 100px">
                <asp:DropDownList ID="CboEst" runat="server">
                    <asp:ListItem Value="AC">ACTIVO</asp:ListItem>
                    <asp:ListItem Value="IN">INACTIVO</asp:ListItem>
                    </asp:DropDownList>
            </TD><TD style="WIDTH: 100px"></TD></TR>
        <TR><TD style="WIDTH: 98px">
            <asp:Label id="Label4" runat="server" Width="109px" Text="Longitud de Caracteres" 
                    Height="34px"></asp:Label></TD>
            <TD style="WIDTH: 100px"><asp:TextBox ID="txtlongNew" runat="server"></asp:TextBox></TD>
            <TD style="WIDTH: 100px">
                <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" 
                    ControlToValidate="txtlongNew" ErrorMessage="Digite la Longitud de Caracteres">*</asp:RequiredFieldValidator></TD></TR>
        <TR>
            <TD style="WIDTH: 98px"></TD><TD style="WIDTH: 100px"></TD><TD style="WIDTH: 100px"></TD></TR>
        <TR><TD style="TEXT-ALIGN: center" colSpan=3><asp:Button id="BtnGuardar" onclick="BtnGuardar_Click" runat="server" Text="Guardar">
                    </asp:Button>&nbsp;<asp:Button id="BtnEliminar" onclick="BtnEliminar_Click" runat="server" Text="Eliminar">
                    </asp:Button>&nbsp; <INPUT id="BtnCancelar" type=button value="Cancelar" /> </TD></TR></TBODY></TABLE>&nbsp;</asp:Panel>&nbsp;&nbsp; 
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

