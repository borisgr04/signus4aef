<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="Vigencias.aspx.vb" Inherits="DatosBasicos_Vigencias_Vigencias" title="Untitled Page" %>
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
&nbsp;<asp:Label id="Tit" runat="server" Width="286px" Text="Vigencias" CssClass="Titulo"></asp:Label><BR /><asp:Label id="MsgResult" runat="server"></asp:Label>&nbsp;&nbsp;&nbsp;<BR /><asp:GridView id="GridView1" runat="server" Width="508px" ForeColor="#333333" OnRowDataBound="GridView1_RowDataBound1" AllowPaging="True" DataSourceID="ObjVig" GridLines="None" CellPadding="4" ShowFooter="True" OnRowCommand="GridView1_RowCommand" DataKeyNames="Vig_Cod" AutoGenerateColumns="False" OnSelectedIndexChanged="GridView1_SelectedIndexChanged" EmptyDataText="No se encontraron Registros en la Base de Datos" AllowSorting="True">
<RowStyle BackColor="#F7F6F3" ForeColor="#333333"></RowStyle>
<Columns>
<asp:TemplateField HeaderText="Vigencia" SortExpression="Vig_Cod"><EditItemTemplate>
<asp:TextBox id="TextBox1" runat="server" Text='<%# Bind("Vig_Cod") %>' __designer:wfdid="w13"></asp:TextBox>
</EditItemTemplate>
<FooterTemplate>
<asp:LinkButton id="lnkNuevo" runat="server" Text="Nuevo Registro" __designer:wfdid="w14" CommandName="Nuevo" CausesValidation="False"></asp:LinkButton>
</FooterTemplate>
<ItemTemplate>
<asp:Label id="Label1" runat="server" Text='<%# Bind("Vig_Cod") %>' __designer:wfdid="w12"></asp:Label>
</ItemTemplate>
</asp:TemplateField>
<asp:BoundField DataField="Vig_est" HeaderText="Estado" SortExpression="Vig_est"></asp:BoundField>
<asp:BoundField DataField="Vig_Fini" HeaderText="Fecha Creaci&#243;n" SortExpression="Vig_Fini"></asp:BoundField>
<asp:BoundField DataField="Vig_FFin" HeaderText="Fecha Cierre" SortExpression="Vig_FFin"></asp:BoundField>
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
</asp:GridView>&nbsp;<!-- <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White"></FooterStyle>-->&nbsp; <asp:ObjectDataSource id="ObjVig" runat="server" TypeName="Vigencias" SelectMethod="GetRecords"></asp:ObjectDataSource> <asp:HiddenField id="Oper" runat="server"></asp:HiddenField>&nbsp;&nbsp;&nbsp;<BR />&nbsp;&nbsp;<asp:HiddenField id="HdPk1CODI" runat="server"></asp:HiddenField><BR />
</contenttemplate>
    </asp:UpdatePanel>&nbsp;
    &nbsp;&nbsp;&nbsp;&nbsp;<asp:UpdatePanel id="UpdatePanel2"
        runat="server"><contenttemplate>
<!-- Mensaje de Salida--><BR /><asp:Button style="DISPLAY: none" id="hiddenTargetControlForModalPopup2" runat="server"></asp:Button> <ajaxToolkit:ModalPopupExtender id="ModalPopupTer" runat="server" TargetControlID="hiddenTargetControlForModalPopup2" RepositionMode="RepositionOnWindowScroll" BehaviorID="programmaticModalPopupBehavior2" BackgroundCssClass="modalBackground" DropShadow="True" PopupControlID="programmaticPopup2" PopupDragHandleControlID="programmaticPopupDragHandle2">
            </ajaxToolkit:ModalPopupExtender>&nbsp;&nbsp; <asp:Panel id="programmaticPopup2" runat="server" Width="529px" Height="400px" CssClass="ModalPanel2"><asp:Panel id="programmaticPopupDragHandle2" runat="Server" Width="523px" Height="30px" CssClass="BarTitleModal2"><DIV style="PADDING-RIGHT: 5px; PADDING-LEFT: 5px; PADDING-BOTTOM: 5px; VERTICAL-ALIGN: middle; PADDING-TOP: 5px"><DIV style="FLOAT: left">Vigencias</DIV><DIV style="FLOAT: right"><INPUT id="BtnCerrar" type=button value="X" /></DIV></DIV></asp:Panel>&nbsp;<TABLE><TBODY><TR><TD colSpan=3><asp:Label id="SubT" runat="server" Text="Nuevo" CssClass="SubTitulo"></asp:Label></TD></TR><TR><TD colSpan=3><asp:ValidationSummary id="ValidationSummary1" runat="server"></asp:ValidationSummary></TD></TR><TR><TD style="WIDTH: 98px"><asp:Label id="Label2" runat="server" Text="Año - Vigencia" __designer:wfdid="w3"></asp:Label></TD><TD style="WIDTH: 101px"><asp:TextBox id="TxtCodiNew" runat="server" Enabled="False"></asp:TextBox></TD><TD style="WIDTH: 100px"><asp:RequiredFieldValidator id="RequiredFieldValidator1" runat="server" ErrorMessage="Digite el Còdigo" ControlToValidate="TxtCodiNew">*</asp:RequiredFieldValidator></TD></TR><TR><TD style="WIDTH: 98px; HEIGHT: 23px"><asp:Label id="Label1" runat="server" Text="Estado"></asp:Label></TD><TD style="WIDTH: 101px; HEIGHT: 23px"><asp:DropDownList id="CboEst" runat="server"><asp:ListItem Value="AC">Activo</asp:ListItem>
<asp:ListItem Value="IN">Inactivo</asp:ListItem>
<asp:ListItem Value="CE">Cerrado</asp:ListItem>
</asp:DropDownList></TD><TD style="WIDTH: 100px; HEIGHT: 23px"></TD></TR><TR><TD style="WIDTH: 98px; HEIGHT: 18px"><asp:Label id="Label4" runat="server" Text="Fecha Creación" __designer:wfdid="w5"></asp:Label></TD><TD style="WIDTH: 101px; HEIGHT: 18px"><asp:TextBox id="txtfini" runat="server" Width="237px" __designer:wfdid="w1" Enabled="False"></asp:TextBox></TD><TD style="WIDTH: 100px; HEIGHT: 18px"></TD></TR><TR><TD style="WIDTH: 98px; HEIGHT: 19px"><asp:Label id="lbfin" runat="server" Text="Fecha de Cierre" __designer:wfdid="w4"></asp:Label></TD><TD style="WIDTH: 101px; HEIGHT: 19px"><asp:TextBox id="txtFFin" runat="server" Width="237px" __designer:wfdid="w2" Enabled="False"></asp:TextBox></TD><TD style="WIDTH: 100px; HEIGHT: 19px"></TD></TR><TR><TD style="WIDTH: 98px"></TD><TD style="WIDTH: 101px"></TD><TD style="WIDTH: 100px"></TD></TR><TR><TD style="WIDTH: 98px"></TD><TD style="WIDTH: 101px"></TD><TD style="WIDTH: 100px"></TD></TR><TR><TD style="WIDTH: 98px"></TD><TD style="WIDTH: 101px"></TD><TD style="WIDTH: 100px"></TD></TR><TR><TD style="WIDTH: 98px"></TD><TD style="WIDTH: 101px"></TD><TD style="WIDTH: 100px"></TD></TR><TR><TD style="WIDTH: 98px"></TD><TD style="WIDTH: 101px"></TD><TD style="WIDTH: 100px"></TD></TR><TR><TD style="TEXT-ALIGN: center" colSpan=3><asp:Button id="BtnGuardar" onclick="BtnGuardar_Click" runat="server" Text="Guardar"></asp:Button>&nbsp;<asp:Button id="BtnEliminar" onclick="BtnEliminar_Click" runat="server" Text="Eliminar"></asp:Button>&nbsp; <INPUT id="BtnCancelar" type=button value="Cancelar" /> </TD></TR></TBODY></TABLE>&nbsp; </asp:Panel>&nbsp;&nbsp; 
</contenttemplate>
    </asp:UpdatePanel><br />
</div>

</asp:Content>

