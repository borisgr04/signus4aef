<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="Contperi.aspx.vb" Inherits="DatosBasicos_Cont_Peri_Contperi" title="Untitled Page" %>
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
&nbsp;<asp:Label id="Tit" runat="server" Width="286px" CssClass="Titulo" Text="PERIODOS CONTABLES"></asp:Label><BR /><asp:Label id="MsgResult" runat="server"></asp:Label>&nbsp;&nbsp;&nbsp;<BR />&nbsp;<asp:GridView id="GridView1" runat="server" Width="500px" ForeColor="#333333" EmptyDataText="No se encontraron Registros en la Base de Datos" OnSelectedIndexChanged="GridView1_SelectedIndexChanged" AutoGenerateColumns="False" DataKeyNames="COPE_AÑO,COPE_MES" OnRowCommand="GridView1_RowCommand" ShowFooter="True" CellPadding="4" GridLines="None" DataSourceID="Objcont" AllowPaging="True" OnRowDataBound="GridView1_RowDataBound1" AllowSorting="True">
<RowStyle BackColor="#F7F6F3" ForeColor="#333333"></RowStyle>
<Columns>
<asp:TemplateField HeaderText="A&#241;o Contable" SortExpression="COPE_A&#209;O"><FooterTemplate>
<asp:LinkButton id="lnkNuevo" runat="server" Text="Nuevo Registro" CommandName="Nuevo" CausesValidation="False"></asp:LinkButton> 
</FooterTemplate>
<ItemTemplate>
<asp:Label id="LbCod" runat="server" Text='<%# Bind("COPE_AÑO") %>'></asp:Label> 
</ItemTemplate>
</asp:TemplateField>
<asp:TemplateField HeaderText="Mes" SortExpression="COPE_MES"><ItemTemplate>
<asp:Label id="Lbcimp" runat="server" Text='<%# Bind("COPE_MES") %>'></asp:Label> 
</ItemTemplate>
</asp:TemplateField>
<asp:TemplateField HeaderText="Estado" SortExpression="COPE_ESTA"><ItemTemplate>
<asp:Label id="Lbabim" runat="server" Text='<%# Bind("COPE_ESTA") %>'></asp:Label> 

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
</asp:GridView> <asp:ObjectDataSource id="Objcont" runat="server" SelectMethod="GetRecords" TypeName="Cont_Peri"></asp:ObjectDataSource><!-- <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White"></FooterStyle>-->&nbsp; <asp:HiddenField id="Oper" runat="server"></asp:HiddenField>&nbsp;<asp:HiddenField id="HdPk1" runat="server"></asp:HiddenField>&nbsp;&nbsp;<BR />&nbsp;&nbsp;<asp:HiddenField id="Hdpk2" runat="server"></asp:HiddenField><BR />
</contenttemplate>
    </asp:UpdatePanel>&nbsp;
    &nbsp;&nbsp;&nbsp;&nbsp;<asp:UpdatePanel id="UpdatePanel2"
        runat="server"><contenttemplate>
<!-- Mensaje de Salida--><BR /><asp:Button style="DISPLAY: none" id="hiddenTargetControlForModalPopup2" runat="server"></asp:Button> <ajaxToolkit:ModalPopupExtender id="ModalPopupTer" runat="server" TargetControlID="hiddenTargetControlForModalPopup2" RepositionMode="RepositionOnWindowScroll" BehaviorID="programmaticModalPopupBehavior2" BackgroundCssClass="modalBackground" DropShadow="True" PopupControlID="programmaticPopup2" PopupDragHandleControlID="programmaticPopupDragHandle2">
            </ajaxToolkit:ModalPopupExtender>&nbsp;&nbsp; <asp:Panel id="programmaticPopup2" runat="server" Width="660px" Height="400px" CssClass="ModalPanel2"><asp:Panel id="programmaticPopupDragHandle2" runat="Server" Width="655px" Height="30px" CssClass="BarTitleModal2"><DIV style="PADDING-RIGHT: 5px; PADDING-LEFT: 5px; PADDING-BOTTOM: 5px; VERTICAL-ALIGN: middle; PADDING-TOP: 5px"><DIV style="FLOAT: left">Cont_Peri</DIV><DIV style="FLOAT: right"><INPUT id="BtnCerrar" type=button value="X" /></DIV></DIV></asp:Panel>&nbsp;<TABLE><TBODY><TR><TD colSpan=3><asp:Label id="SubT" runat="server" Text="Nuevo" CssClass="SubTitulo"></asp:Label></TD></TR><TR><TD colSpan=3><asp:ValidationSummary id="ValidationSummary1" runat="server"></asp:ValidationSummary></TD></TR><TR><TD style="WIDTH: 98px"><asp:Label id="Label4" runat="server" Width="143px" Text="Año Contable"></asp:Label></TD><TD style="WIDTH: 100px"><asp:TextBox id="TxtañoNew" runat="server"></asp:TextBox></TD><TD style="WIDTH: 100px"><asp:RequiredFieldValidator id="RequiredFieldValidator1" runat="server" ErrorMessage="Digite  Año Contable" ControlToValidate="TxtañoNew">*</asp:RequiredFieldValidator></TD></TR><TR><TD style="WIDTH: 98px; HEIGHT: 23px"><asp:Label id="Label1" runat="server" Width="126px" Text="Mes"></asp:Label></TD><TD style="WIDTH: 100px; HEIGHT: 23px"><asp:TextBox id="txtmesNew" runat="server"></asp:TextBox></TD><TD style="WIDTH: 100px; HEIGHT: 23px"><asp:RequiredFieldValidator id="RequiredFieldValidator3" runat="server" ErrorMessage="Digite Mes" ControlToValidate="txtmesNew">*</asp:RequiredFieldValidator></TD></TR><TR><TD style="WIDTH: 98px; HEIGHT: 18px"><asp:Label id="Label2" runat="server" Width="117px" Text="Estado"></asp:Label></TD><TD style="WIDTH: 100px; HEIGHT: 18px"><asp:TextBox id="txtestaNew" runat="server"></asp:TextBox></TD><TD style="WIDTH: 100px; HEIGHT: 18px"><asp:RequiredFieldValidator id="RequiredFieldValidator4" runat="server" ErrorMessage="Digite Estado" ControlToValidate="txtestaNew">*</asp:RequiredFieldValidator></TD></TR><TR><TD style="WIDTH: 98px; HEIGHT: 19px"></TD><TD style="WIDTH: 100px; HEIGHT: 19px"></TD><TD style="WIDTH: 100px; HEIGHT: 19px"></TD></TR><TR><TD style="WIDTH: 98px"></TD><TD style="WIDTH: 100px"></TD><TD style="WIDTH: 100px"></TD></TR><TR><TD style="WIDTH: 98px"></TD><TD style="WIDTH: 100px"></TD><TD style="WIDTH: 100px"></TD></TR><TR><TD style="WIDTH: 98px"></TD><TD style="WIDTH: 100px"></TD><TD style="WIDTH: 100px"></TD></TR><TR><TD style="TEXT-ALIGN: center" colSpan=3><asp:Button id="BtnGuardar" onclick="BtnGuardar_Click" runat="server" Text="Guardar"></asp:Button>&nbsp;<asp:Button id="BtnEliminar" onclick="BtnEliminar_Click" runat="server" Text="Eliminar"></asp:Button>&nbsp; <INPUT id="BtnCancelar" type=button value="Cancelar" /> </TD></TR></TBODY></TABLE>&nbsp; </asp:Panel>&nbsp;&nbsp; 
</contenttemplate>
    </asp:UpdatePanel><br />
</div>


</asp:Content>

