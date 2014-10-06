<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="Ctabanco.aspx.vb" Inherits="DatosBasicos_Cta_Banco_Ctabanco" title="Untitled Page" %>
<asp:Content ID="Content1" ContentPlaceHolderID="SampleContent" Runat="Server">
    <script type='text/javascript'>
        // Add click handlers for buttons to show and hide modal popup on pageLoad
        function pageLoad() {
            //$addHandler($get("showModalPopupClientButton"), 'click', showModalPopupViaClient);
            //$addHandler($get("hideModalPopupViaClientButton"), 'click', hideModalPopupViaClient);        
            $addHandler($get("BtnCerrar"), 'click', CerrarModalTercero);        
        }
         function CerrarModalTercero(ev) {
            ev.preventDefault();        
            var modalPopupBehavior2 = $find('programmaticModalPopupBehavior2');
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
&nbsp;<asp:Label id="Tit" runat="server" Text="Cta_Banco" CssClass="Titulo"></asp:Label><BR /><asp:Label id="MsgResult" runat="server"></asp:Label><BR />&nbsp;&nbsp;<asp:GridView id="GridView1" runat="server" ForeColor="#333333" OnSelectedIndexChanged="GridView1_SelectedIndexChanged" AutoGenerateColumns="False" DataKeyNames="CTA_BACO,CTA_NRO" OnRowCommand="GridView1_RowCommand" ShowFooter="True" CellPadding="4" GridLines="None" DataSourceID="Objbanc" AllowPaging="True" __designer:wfdid="w84" OnRowDataBound="GridView1_RowDataBound1">
<RowStyle BackColor="#F7F6F3" ForeColor="#333333"></RowStyle>
<Columns>
<asp:TemplateField HeaderText="C&#243;digo" SortExpression="CTA_BACO"><FooterTemplate>
<asp:LinkButton ID="lnkNuevo" runat="server" CausesValidation="False" CommandName="Nuevo"
                            Text="Nuevo Registro"></asp:LinkButton>
</FooterTemplate>
<ItemTemplate>
<asp:Label id="LbCod" runat="server" Text='<%# Bind("CTA_BACO") %>'></asp:Label> 
</ItemTemplate>
</asp:TemplateField>
<asp:TemplateField HeaderText="Nro de Cuenta" SortExpression="CTA_NRO"><ItemTemplate>
                   <asp:Label ID="LbNom" runat="server" Text='<%# Bind("CTA_NRO") %>'></asp:Label>
                
</ItemTemplate>
</asp:TemplateField>
<asp:TemplateField HeaderText="Tipo de Cuenta" SortExpression="CTA_TIP"><ItemTemplate>
                   <asp:Label ID="LbNom2" runat="server" Text='<%# Bind("CTA_TIP") %>'></asp:Label>
                                

 
</ItemTemplate>
</asp:TemplateField>
<asp:TemplateField HeaderText="Codigo de Barra" SortExpression="CTA_CODBAR"><ItemTemplate>
                   <asp:Label ID="LbNom3" runat="server" Text='<%# Bind("CTA_CODBAR") %>'></asp:Label>
                               
   
</ItemTemplate>
</asp:TemplateField>
<asp:TemplateField HeaderText="Estado de la Cuenta" SortExpression="CTA_EST"><ItemTemplate>
                   <asp:Label ID="LbNom4" runat="server" Text='<%# Bind("CTA_EST") %>'></asp:Label>
                               
  
</ItemTemplate>
</asp:TemplateField>
<asp:TemplateField HeaderText="Nombre de la Cuenta" SortExpression="CTA_DESC"><ItemTemplate>
                   <asp:Label ID="LbNom5" runat="server" Text='<%# Bind("CTA_DESC") %>'></asp:Label>
  
  
  
</ItemTemplate>
</asp:TemplateField>
<asp:TemplateField HeaderText="Sucursal de la Cuenta" SortExpression="CTA_SUC"><ItemTemplate>
                   <asp:Label ID="LbNom6" runat="server" Text='<%# Bind("CTA_SUC") %>'></asp:Label>
   
  
                                              
</ItemTemplate>
</asp:TemplateField>
<asp:ButtonField CommandName="Eliminar" ImageUrl="~/images/Operaciones/delete2.png" Text="Eliminar" ButtonType="Image"></asp:ButtonField>
<asp:ButtonField CommandName="Editar" ImageUrl="~/images/Operaciones/Edit2.png" Text="Editar" ButtonType="Image"></asp:ButtonField>
</Columns>

<FooterStyle BackColor="White" Font-Bold="True" ForeColor="#5D7B9D"></FooterStyle>

<PagerStyle HorizontalAlign="Center" BackColor="#284775" ForeColor="White"></PagerStyle>

<SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333"></SelectedRowStyle>

<HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White"></HeaderStyle>

<EditRowStyle BackColor="#999999"></EditRowStyle>

<AlternatingRowStyle BackColor="White" ForeColor="#284775"></AlternatingRowStyle>
</asp:GridView>&nbsp;<BR /><BR /><BR /><!-- <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White"></FooterStyle>-->&nbsp; <asp:HiddenField id="Oper" runat="server"></asp:HiddenField>&nbsp; <asp:HiddenField id="HdPk1" runat="server" __designer:wfdid="w22"></asp:HiddenField> <asp:ObjectDataSource id="Objbanc" runat="server" SelectMethod="GetRecords" TypeName="Cta_Banco"></asp:ObjectDataSource><BR /><asp:HiddenField id="HdPk2" runat="server" __designer:wfdid="w1"></asp:HiddenField> <asp:ObjectDataSource id="ObjBancos" runat="server" SelectMethod="GetRecords" TypeName="Bancos" __designer:wfdid="w17"></asp:ObjectDataSource>&nbsp;<BR />&nbsp;&nbsp;<BR />
</contenttemplate>
    </asp:UpdatePanel>&nbsp;
    &nbsp;&nbsp;&nbsp;&nbsp;<asp:UpdatePanel id="UpdatePanel2"
        runat="server"><contenttemplate>
<!-- Mensaje de Salida--><BR /><asp:Button style="DISPLAY: none" id="hiddenTargetControlForModalPopup2" runat="server"></asp:Button> <ajaxToolkit:ModalPopupExtender id="ModalPopupTer" runat="server" TargetControlID="hiddenTargetControlForModalPopup2" RepositionMode="RepositionOnWindowScroll" BehaviorID="programmaticModalPopupBehavior2" BackgroundCssClass="modalBackground" DropShadow="True" PopupControlID="programmaticPopup2" PopupDragHandleControlID="programmaticPopupDragHandle2">
            </ajaxToolkit:ModalPopupExtender>&nbsp;&nbsp; <asp:Panel id="programmaticPopup2" runat="server" Width="660px" Height="400px" CssClass="ModalPanel2"><asp:Panel id="programmaticPopupDragHandle2" runat="Server" Width="655px" Height="30px" CssClass="BarTitleModal2"><DIV style="PADDING-RIGHT: 5px; PADDING-LEFT: 5px; PADDING-BOTTOM: 5px; VERTICAL-ALIGN: middle; PADDING-TOP: 5px"><DIV style="FLOAT: left">Cuentas Bancarias</DIV><DIV style="FLOAT: right"><INPUT id="BtnCerrar" type=button value="X" /></DIV></DIV></asp:Panel>&nbsp;<TABLE><TBODY><TR><TD colSpan=3><asp:Label id="SubT" runat="server" Text="Nuevo" CssClass="SubTitulo"></asp:Label></TD></TR><TR><TD style="HEIGHT: 19px" colSpan=3><asp:ValidationSummary id="ValidationSummary1" runat="server"></asp:ValidationSummary></TD></TR><TR><TD style="WIDTH: 98px; HEIGHT: 21px">Banco</TD><TD style="WIDTH: 100px; HEIGHT: 21px"><asp:DropDownList id="CboBanco" runat="server" DataSourceID="ObjBancos" DataTextField="Ban_CNom" DataValueField="Ban_Cod"></asp:DropDownList></TD><TD style="WIDTH: 100px; HEIGHT: 21px"></TD></TR><TR><TD style="WIDTH: 98px">Nro de la Cuenta</TD><TD style="WIDTH: 100px"><asp:TextBox id="TxtnroNew" runat="server" Width="229px"></asp:TextBox></TD><TD style="WIDTH: 100px"><asp:RequiredFieldValidator id="RequiredFieldValidator1" runat="server" __designer:wfdid="w85" ControlToValidate="TxtnroNew" ErrorMessage="Digite un Numero de Cuenta">*</asp:RequiredFieldValidator></TD></TR><TR><TD style="WIDTH: 98px; HEIGHT: 23px"><asp:Label id="Label4" runat="server" Width="101px" Text="Nombre de la Cuenta"></asp:Label></TD><TD style="WIDTH: 100px; HEIGHT: 23px"><asp:TextBox id="txtdescNew" runat="server"></asp:TextBox></TD><TD style="WIDTH: 100px; HEIGHT: 23px"></TD></TR><TR><TD style="WIDTH: 98px; HEIGHT: 23px"><asp:Label id="Label1" runat="server" Text="Tipo de Cuenta"></asp:Label></TD><TD style="WIDTH: 100px; HEIGHT: 23px"><asp:DropDownList id="Cbocuenta" runat="server" DataSourceID="Objcuenta" __designer:wfdid="w81" DataTextField="TCTA_NOMB" DataValueField="TCTA_CODI"></asp:DropDownList></TD><TD style="WIDTH: 100px; HEIGHT: 23px"></TD></TR><TR><TD style="WIDTH: 98px"><asp:Label id="Label2" runat="server" Text="Codigo de Barra"></asp:Label></TD><TD style="WIDTH: 100px"><asp:TextBox id="txtcodbarNew" runat="server"></asp:TextBox></TD><TD style="WIDTH: 100px"></TD></TR><TR><TD style="WIDTH: 98px"><asp:Label id="Label3" runat="server" Text="Estado de la Cuenta"></asp:Label></TD><TD style="WIDTH: 100px"><asp:DropDownList id="Cboest" runat="server" __designer:wfdid="w91"><asp:ListItem Value="AC">Activo</asp:ListItem>
<asp:ListItem Value="IN">Inactivo</asp:ListItem>
</asp:DropDownList></TD><TD style="WIDTH: 100px"></TD></TR><TR><TD style="WIDTH: 98px"><asp:Label id="Label5" runat="server" Width="105px" Text="Sucursal de la Cuenta"></asp:Label></TD><TD style="WIDTH: 100px"><asp:TextBox id="txtsucNew" runat="server"></asp:TextBox></TD><TD style="WIDTH: 100px"><asp:RequiredFieldValidator id="RequiredFieldValidator4" runat="server" __designer:wfdid="w88" ControlToValidate="txtdescNew" ErrorMessage="Digite el Nombre de la Cuenta">*</asp:RequiredFieldValidator></TD></TR><TR><TD style="WIDTH: 98px"></TD><TD style="WIDTH: 100px"></TD><TD style="WIDTH: 100px"></TD></TR><TR><TD style="WIDTH: 98px; HEIGHT: 23px"></TD><TD style="WIDTH: 100px; HEIGHT: 23px"></TD><TD style="WIDTH: 100px; HEIGHT: 23px"></TD></TR><TR><TD style="WIDTH: 98px"><asp:ObjectDataSource id="Objcuenta" runat="server" SelectMethod="GetRecords" TypeName="Tipo_Cuenta" __designer:wfdid="w82"></asp:ObjectDataSource></TD><TD style="WIDTH: 100px"></TD><TD style="WIDTH: 100px"></TD></TR><TR><TD style="HEIGHT: 22px; TEXT-ALIGN: center" colSpan=3><asp:Button id="BtnGuardar" onclick="BtnGuardar_Click" runat="server" Text="Guardar" __designer:wfdid="w80"></asp:Button>&nbsp;<asp:Button id="BtnCancelar" onclick="BtnCancelar_Click" runat="server" Text="Cancelar"></asp:Button>&nbsp; </TD></TR></TBODY></TABLE></asp:Panel>&nbsp;&nbsp; 
</contenttemplate>
    </asp:UpdatePanel><br />
</div>

</asp:Content>

