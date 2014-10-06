<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="Bancos.aspx.vb" Inherits="DatosBasicos_Bancos_Bancos" title="Untitled Page" %>
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
&nbsp;<asp:Label id="Tit" runat="server" Width="286px" Text="Bancos" CssClass="Titulo"></asp:Label><BR /><asp:Label id="MsgResult" runat="server"></asp:Label><BR />&nbsp;&nbsp;&nbsp;<asp:GridView id="GridView1" runat="server" ForeColor="#333333" OnSelectedIndexChanged="GridView1_SelectedIndexChanged" AutoGenerateColumns="False" DataKeyNames="BAN_COD" OnRowCommand="GridView1_RowCommand" ShowFooter="True" CellPadding="4" GridLines="None" DataSourceID="Objban" AllowPaging="True" OnRowDataBound="GridView1_RowDataBound" AllowSorting="True">
<RowStyle BackColor="#F7F6F3" ForeColor="#333333"></RowStyle>
<Columns>
<asp:TemplateField HeaderText="C&#243;digo del Banco" SortExpression="BAN_COD"><FooterTemplate>
<asp:LinkButton id="lnkNuevo" runat="server" Text="Nuevo Registro" CommandName="Nuevo" CausesValidation="False"></asp:LinkButton> 
</FooterTemplate>
<ItemTemplate>
<asp:Label id="LbCod" runat="server" Text='<%# Bind("BAN_COD") %>'></asp:Label> 
</ItemTemplate>
</asp:TemplateField>
<asp:TemplateField HeaderText="Nombre del Banco" SortExpression="BAN_NOM"><ItemTemplate>
<asp:Label id="LbNom" runat="server" Text='<%# Bind("BAN_NOM") %>'></asp:Label> 
</ItemTemplate>
</asp:TemplateField>
<asp:TemplateField HeaderText="Estado" SortExpression="BAN_EST"><ItemTemplate>
<asp:Label id="LbEst" runat="server" Text='<%# Bind("BAN_EST") %>'></asp:Label> 
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
</asp:GridView><BR /><asp:ObjectDataSource id="Objban" runat="server" SelectMethod="GetRecords" TypeName="Bancos1"></asp:ObjectDataSource><BR /><BR /><!-- <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White"></FooterStyle>-->&nbsp; <asp:HiddenField id="Oper" runat="server"></asp:HiddenField>&nbsp;<asp:HiddenField id="HdPk1cod" runat="server"></asp:HiddenField>&nbsp;&nbsp;<BR />&nbsp;&nbsp;<BR />
</contenttemplate>
    </asp:UpdatePanel>&nbsp;
    &nbsp;&nbsp;&nbsp;&nbsp; &nbsp;<asp:UpdatePanel id="UpdatePanel2"
        runat="server"><contenttemplate>
<!-- Mensaje de Salida--><BR /><asp:Button style="DISPLAY: none" id="hiddenTargetControlForModalPopup2" runat="server"></asp:Button> <ajaxToolkit:ModalPopupExtender id="ModalPopupTer" runat="server" PopupDragHandleControlID="programmaticPopupDragHandle2" PopupControlID="programmaticPopup2" DropShadow="True" BackgroundCssClass="modalBackground" BehaviorID="programmaticModalPopupBehavior2" RepositionMode="RepositionOnWindowScroll" TargetControlID="hiddenTargetControlForModalPopup2">
            </ajaxToolkit:ModalPopupExtender>&nbsp;&nbsp; <asp:Panel id="programmaticPopup2" runat="server" Width="488px" Height="282px" CssClass="ModalPanel2"><asp:Panel id="programmaticPopupDragHandle2" runat="Server" Width="483px" Height="30px" CssClass="BarTitleModal2"><DIV style="PADDING-RIGHT: 5px; PADDING-LEFT: 5px; PADDING-BOTTOM: 5px; VERTICAL-ALIGN: middle; PADDING-TOP: 5px"><DIV style="FLOAT: left">Bancos</DIV><DIV style="FLOAT: right"><INPUT id="BtnCerrar" type=button value="X" /></DIV></DIV></asp:Panel>&nbsp;<TABLE><TBODY><TR><TD colSpan=3><asp:Label id="SubT" runat="server" CssClass="SubTitulo" Text="Nuevo"></asp:Label> </TD></TR><TR><TD colSpan=3><asp:ValidationSummary id="ValidationSummary1" runat="server"></asp:ValidationSummary></TD></TR><TR><TD style="WIDTH: 98px">Código</TD><TD style="WIDTH: 100px"><asp:TextBox id="TxtCodNew" runat="server"></asp:TextBox></TD><TD style="WIDTH: 100px"><asp:RequiredFieldValidator id="RequiredFieldValidator1" runat="server" ControlToValidate="TxtCodNew" ErrorMessage="Digite un Codigo">*</asp:RequiredFieldValidator></TD></TR><TR><TD style="WIDTH: 98px; HEIGHT: 23px">Nombre </TD><TD style="WIDTH: 100px; HEIGHT: 23px"><asp:TextBox id="TxtNomNew" runat="server" Width="229px"></asp:TextBox></TD><TD style="WIDTH: 100px; HEIGHT: 23px"><asp:RequiredFieldValidator id="RequiredFieldValidator2" runat="server" ControlToValidate="TxtNomNew" ErrorMessage="Digite un Nombre">*</asp:RequiredFieldValidator></TD></TR><TR><TD style="WIDTH: 98px"><asp:Label id="Label1" runat="server" Text="Estados"></asp:Label></TD><TD style="WIDTH: 100px"><asp:DropDownList id="Cboest" runat="server"><asp:ListItem Value="AC">Activo</asp:ListItem>
<asp:ListItem Value="IN">Inactivo</asp:ListItem>
</asp:DropDownList></TD><TD style="WIDTH: 100px"></TD></TR><TR><TD style="WIDTH: 98px"></TD><TD style="WIDTH: 100px"></TD><TD style="WIDTH: 100px"></TD></TR><TR><TD style="WIDTH: 98px"></TD><TD style="WIDTH: 100px"></TD><TD style="WIDTH: 100px"></TD></TR><TR><TD style="TEXT-ALIGN: center" colSpan=3><asp:Button id="BtnGuardar" onclick="BtnGuardar_Click" runat="server" Text="Guardar"></asp:Button>&nbsp;&nbsp;&nbsp;<asp:Button id="BtnEliminar" onclick="BtnEliminar_Click" runat="server" Text="Eliminar"></asp:Button>&nbsp;&nbsp;&nbsp;<INPUT id="BtnCancelar" type=button value="Cancelar" /> </TD></TR></TBODY></TABLE></asp:Panel>&nbsp;&nbsp; 
</contenttemplate>
    </asp:UpdatePanel><asp:UpdateProgress id="UpdateProgress1" runat="server" AssociatedUpdatePanelID="UpdatePanel1">
        <progresstemplate>
            <div class="Loading">
            <img src="../../images/loading.gif" alt="" title="" /> Cargando …
            </div>
        </progresstemplate>
    </asp:UpdateProgress><br />
</div>

</asp:Content>

