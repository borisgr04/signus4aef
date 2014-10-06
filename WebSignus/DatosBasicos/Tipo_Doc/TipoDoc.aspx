<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="TipoDoc.aspx.vb" Inherits="DatosBasicos_Tipo_Doc_TipoDoc" title="Untitled Page" %>
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
&nbsp;<asp:Label id="Tit" runat="server" Width="286px" Text="Tipos de Documentos" CssClass="Titulo"></asp:Label><BR /><asp:Label id="MsgResult" runat="server"></asp:Label>&nbsp;&nbsp;&nbsp;<BR />&nbsp;

            <asp:GridView id="GridView1" runat="server" Width="258px" ForeColor="#333333" OnRowDataBound="GridView1_RowDataBound1" AllowPaging="True" DataSourceID="Objdoc" GridLines="None" CellPadding="4" ShowFooter="True" OnRowCommand="GridView1_RowCommand" DataKeyNames="TIDO_CODI" AutoGenerateColumns="False" OnSelectedIndexChanged="GridView1_SelectedIndexChanged" EmptyDataText="No se encontraron Registros en la Base de Datos" AllowSorting="True">
<RowStyle BackColor="#F7F6F3" ForeColor="#333333"></RowStyle>
<Columns>
<asp:TemplateField HeaderText="C&#243;digo" SortExpression="TIDO_CODI"><FooterTemplate>
<asp:LinkButton id="lnkNuevo" runat="server" Text="Nuevo Registro" CommandName="Nuevo" CausesValidation="False"></asp:LinkButton> 
</FooterTemplate>
<ItemTemplate>
<asp:Label id="LbCod" runat="server" Text='<%# Bind("TIDO_CODI") %>'></asp:Label> 
</ItemTemplate>
</asp:TemplateField>
<asp:TemplateField HeaderText="Nombre" SortExpression="TIDO_NOMB"><ItemTemplate>
<asp:Label id="LbNom" runat="server" Text='<%# Bind("TIDO_NOMB") %>'></asp:Label> 
</ItemTemplate>
</asp:TemplateField>
<asp:TemplateField HeaderText="Estado" SortExpression="TIDO_EST"><ItemTemplate>
<asp:Label id="LbEst" runat="server" Text='<%# Bind("TIDO_EST") %>'></asp:Label> 
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
</asp:GridView>&nbsp;<!-- <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White"></FooterStyle>-->&nbsp; <asp:ObjectDataSource id="Objdoc" runat="server" __designer:wfdid="w7" TypeName="Tipo_Doc" SelectMethod="GetRecords"></asp:ObjectDataSource> <asp:HiddenField id="Oper" runat="server"></asp:HiddenField>&nbsp;&nbsp;&nbsp;<BR />&nbsp;&nbsp;<asp:HiddenField id="HdPk1CODI" runat="server" __designer:wfdid="w8"></asp:HiddenField><BR />
</contenttemplate>
    </asp:UpdatePanel>&nbsp;
    &nbsp;&nbsp;&nbsp;&nbsp;

    <asp:UpdatePanel id="UpdatePanel2" runat="server" ChildrenAsTriggers="true">
        <contenttemplate>
        <!-- Mensaje de Salida-->
        <BR />
        <asp:Button style="DISPLAY: none" id="hiddenTargetControlForModalPopup2" runat="server"></asp:Button> 
        <ajaxToolkit:ModalPopupExtender id="ModalPopupTer" runat="server" PopupDragHandleControlID="programmaticPopupDragHandle2" PopupControlID="programmaticPopup2" DropShadow="True" BackgroundCssClass="modalBackground" BehaviorID="programmaticModalPopupBehavior2" RepositionMode="RepositionOnWindowScroll" TargetControlID="hiddenTargetControlForModalPopup2">
        </ajaxToolkit:ModalPopupExtender>&nbsp;&nbsp; 
        <asp:Panel id="programmaticPopup2" runat="server" Width="660px" Height="400px" CssClass="ModalPanel2">
        <asp:Panel id="programmaticPopupDragHandle2" runat="Server" Width="655px" Height="30px" CssClass="BarTitleModal2">
        <DIV style="PADDING-RIGHT: 5px; PADDING-LEFT: 5px; PADDING-BOTTOM: 5px; VERTICAL-ALIGN: middle; PADDING-TOP: 5px">
        <DIV style="FLOAT: left">Tipos de Documentos</DIV>
        <DIV style="FLOAT: right"><INPUT id="BtnCerrar" type=button value="X" /></DIV></DIV>
        </asp:Panel>&nbsp;
        <TABLE>
        <TBODY>
        <TR>
            <TD colSpan=3>
                <asp:Label id="SubT" runat="server" CssClass="SubTitulo" Text="Nuevo"></asp:Label>
            </TD>
         </TR>
         <TR>
            <TD colSpan=3><asp:ValidationSummary id="ValidationSummary1" runat="server"></asp:ValidationSummary>
            </TD>
         </TR>
         <TR>
            <TD style="WIDTH: 98px">Código</TD>
            <TD style="WIDTH: 100px">
                <asp:TextBox ID="TxtCodiNew" runat="server" 
                    __designer:wfdid="w1"></asp:TextBox>
            </TD>
            <TD style="WIDTH: 100px">
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
                    __designer:wfdid="w9" ControlToValidate="TxtCodiNew" 
                    ErrorMessage="Digite el Còdigo">*</asp:RequiredFieldValidator>
            </TD>
         </TR>
         <TR>
            <TD style="WIDTH: 98px; HEIGHT: 23px">
            Nombre
            </TD>
            <TD style="WIDTH: 100px; HEIGHT: 23px">
                <asp:TextBox 
                    ID="TxtNomNew" runat="server" __designer:wfdid="w2" TextMode="MultiLine" 
                    Width="229px"></asp:TextBox>
            </TD>
            <TD style="WIDTH: 100px; HEIGHT: 23px">
                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" 
                    __designer:wfdid="w10" ControlToValidate="TxtNomNew" 
                    ErrorMessage="Digite Nombre">*</asp:RequiredFieldValidator>
            </TD>
        </TR>
        <TR>
            <TD style="WIDTH: 98px">Responsable</TD>
            <TD style="WIDTH: 100px">
                <asp:TextBox ID="tbResponsable" runat="server" Width="200px"></asp:TextBox>
            </TD>
            <td></td>
        </TR>
            <TR><TD style="WIDTH: 98px; height: 18px;">
            <asp:Label ID="Label1" runat="server" __designer:wfdid="w4" Text="Estado"></asp:Label></TD>
            <TD style="WIDTH: 100px; height: 18px;">
                <asp:DropDownList ID="CboEst" runat="server" __designer:wfdid="w5">
                    <asp:ListItem Value="AC">Activo</asp:ListItem>
<asp:ListItem Value="IN">Inactivo</asp:ListItem>
                </asp:DropDownList></TD><td style="WIDTH: 100px; height: 18px;"></td></TR>
        <TR><TD style="WIDTH: 98px; ">
            <asp:Label ID="lbFirma" runat="server" Text="Firma digital"></asp:Label>
            </TD>
            <TD style="WIDTH: 100px; ">
            <asp:FileUpload ID="FuFirma" runat="server" />
            </TD>
            <TD style="WIDTH: 100px; height: 18px;"></TD>
            </TR>
        <TR><td colspan="2">
                <asp:Label ID="lbFirma1" runat="server"></asp:Label>
            </td>
            <td style="WIDTH: 100px">&#160;</td></TR>
        <TR>
            <td colspan="2">
                <asp:Image ID="Image1"  runat="server"   BorderColor="#CCCCCC" BorderStyle="Solid" 
                    BorderWidth="1px" Width="330px"  Height= "52px" />
            </td>
            <TD style="WIDTH: 100px"></TD></TR>
            <tr>
            <td style="text-align: center;" colspan="3">
                <asp:Button ID="BtnGuardar" runat="server" Text="Guardar"></asp:Button>&#160;<asp:Button 
                    ID="BtnEliminar" runat="server" onclick="BtnEliminar_Click" Text="Eliminar">
                </asp:Button>&#160; <input id="BtnCancelar" type="button" value="Cancelar" /> </td></tr></TBODY>
        </TABLE>&nbsp;</asp:Panel>&nbsp;&nbsp; 
        </contenttemplate>
        <Triggers>
            <asp:PostBackTrigger ControlID="BtnGuardar"/>
        </Triggers>
    </asp:UpdatePanel><br />
</div>

</asp:Content>

