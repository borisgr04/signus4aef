<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="Menu.aspx.vb" Inherits="DatosBasicos_Menu1_Menu" title="Untitled Page" %>
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
    &nbsp; &nbsp;&nbsp;&nbsp;
    <br />
    <asp:UpdatePanel id="UpdatePanel1" runat="server" UpdateMode="Conditional">
        <contenttemplate>
&nbsp;<asp:Label id="Tit" runat="server" Width="286px" CssClass="Titulo" Text="Menu"></asp:Label>
            <br />
            <asp:Label id="MsgResult" runat="server"></asp:Label>
            <br />
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<asp:Button ID="BtnRoles" runat="server" 
                Text="Generar Roles" />
            &nbsp;&nbsp;<asp:Button ID="BtnFiltrar" runat="server" Text="Filtrar" />
            <asp:GridView id="GridView1" runat="server" Width="258px" ForeColor="#333333" PageSize="20" AllowSorting="True" EmptyDataText="No se encontraron Registros en la Base de Datos" OnSelectedIndexChanged="GridView1_SelectedIndexChanged" AutoGenerateColumns="False" DataKeyNames="MENUID" OnRowCommand="GridView1_RowCommand" ShowFooter="True" CellPadding="4" GridLines="None" DataSourceID="Objmenu" AllowPaging="True" OnRowDataBound="GridView1_RowDataBound1">
<RowStyle BackColor="#F7F6F3" ForeColor="#333333"></RowStyle>
<Columns>
<asp:TemplateField HeaderText="MENUID" SortExpression="MENUID"><FooterTemplate>
<asp:LinkButton id="lnkNuevo" runat="server" Text="Nuevo Registro" __designer:wfdid="w110" CausesValidation="False" CommandName="Nuevo"></asp:LinkButton> 
</FooterTemplate>
<HeaderTemplate>
<TABLE __designer:dtid="5066549580791840"><TBODY><TR __designer:dtid="5066549580791841"><TD style="WIDTH: 73px" __designer:dtid="5066549580791842"><asp:Label id="Label10" runat="server" Text="MenúID" __designer:wfdid="w108" ToolTip="Nombre del Concepto o Renglon"></asp:Label></TD></TR><TR __designer:dtid="5066549580791843"><TD style="WIDTH: 73px" __designer:dtid="5066549580791844"><asp:TextBox id="TxtMenuID" runat="server" Width="68px" __designer:dtid="5066549580791845" __designer:wfdid="w109"></asp:TextBox> </TD></TR></TBODY></TABLE>
</HeaderTemplate>
<ItemTemplate>
<asp:Label id="Lbmenuid" runat="server" Text='<%# Bind("MENUID") %>' __designer:wfdid="w11"></asp:Label> 
</ItemTemplate>
</asp:TemplateField>
<asp:TemplateField HeaderText="TITULO " SortExpression="TITULO"><ItemTemplate>
<asp:Label id="Lbtitulo" runat="server" Text='<%# Bind("TITULO") %>' __designer:wfdid="w7"></asp:Label> 
</ItemTemplate>
</asp:TemplateField>
<asp:TemplateField HeaderText="PADREID" SortExpression="PADREID"><HeaderTemplate>
<TABLE __designer:dtid="5066549580791852"><TBODY><TR __designer:dtid="5066549580791853"><TD style="WIDTH: 30px" colSpan=1 __designer:dtid="5066549580791854"><asp:Label id="LbPadreID" runat="server" Width="51px" __designer:dtid="5066549580791855" Text="PadreID" __designer:wfdid="w9" ToolTip="PadreID"></asp:Label></TD></TR><TR __designer:dtid="5066549580791856"><TD style="WIDTH: 30px" __designer:dtid="5066549580791857"><asp:DropDownList id="CboPadreID" runat="server" Width="54px" DataSourceID="Objmenu" __designer:wfdid="w10" DataTextField="MenuID" DataValueField="MenuId" AppendDataBoundItems="True"><asp:ListItem></asp:ListItem>
</asp:DropDownList></TD></TR></TBODY></TABLE>
</HeaderTemplate>
<ItemTemplate>
<asp:Label id="Lbpadreid" runat="server" Text='<%# Bind("PADREID") %>' __designer:wfdid="w8"></asp:Label> 
</ItemTemplate>
</asp:TemplateField>
<asp:TemplateField HeaderText="POS." SortExpression="POSICION"><ItemTemplate>
<asp:Label id="Lbposicion" runat="server" Text='<%# Bind("POSICION") %>' __designer:wfdid="w10"></asp:Label> 
</ItemTemplate>
</asp:TemplateField>
<asp:TemplateField HeaderText="ICONO" SortExpression="ICONO"><ItemTemplate>
<asp:Label id="Lbicono" runat="server" Text='<%# Bind("ICONO") %>' __designer:wfdid="w11"></asp:Label> 
</ItemTemplate>
</asp:TemplateField>
<asp:TemplateField HeaderText="HAB." SortExpression="HABILITADO"><ItemTemplate>
<asp:Label id="Lbhabilitado" runat="server" Text='<%# Bind("HABILITADO") %>' __designer:wfdid="w12"></asp:Label> 
</ItemTemplate>
</asp:TemplateField>
<asp:TemplateField HeaderText="URL" SortExpression="URL"><ItemTemplate>
<asp:Label id="Lburl" runat="server" Text='<%# Bind("URL") %>' __designer:wfdid="w13"></asp:Label> 
</ItemTemplate>
</asp:TemplateField>
<asp:TemplateField HeaderText="MODULO" SortExpression="MODULO"><ItemTemplate>
<asp:Label id="Lbmodulo" runat="server" Text='<%# Bind("MODULO") %>' __designer:wfdid="w14"></asp:Label> 
</ItemTemplate>
</asp:TemplateField>
<asp:TemplateField HeaderText="ROLES" SortExpression="ROLES"><HeaderTemplate>
<TABLE __designer:dtid="5066549580791937"><TBODY><TR __designer:dtid="5066549580791938"><TD style="HEIGHT: 24px" colSpan=3><asp:Label id="Label14" runat="server" Width="49px" Height="15px" Text="ROLES" __designer:wfdid="w3"></asp:Label></TD></TR><TR __designer:dtid="5066549580791941"><TD __designer:dtid="5066549580791942"><asp:TextBox id="txtRoles" runat="server" Width="37px" __designer:wfdid="w4"></asp:TextBox></TD><TD style="WIDTH: 6px" __designer:dtid="5066549580791944"><asp:Button id="Button1" onclick="btnFiltrar_Click" runat="server" __designer:dtid="5066549580791900" Text="+" __designer:wfdid="w5"></asp:Button></TD><TD style="WIDTH: 6px"><asp:Button id="Filtrar" onclick="btnQFiltrar_Click" runat="server" __designer:dtid="5066549580791902" Text="-" __designer:wfdid="w6" ToolTip="Quitar Filtro"></asp:Button></TD></TR></TBODY></TABLE>
</HeaderTemplate>
<ItemTemplate>
<asp:Label id="Lbroles" runat="server" Text='<%# Bind("ROLES") %>' __designer:wfdid="w2"></asp:Label> 
</ItemTemplate>
</asp:TemplateField>
<asp:TemplateField HeaderText="DESTINO" SortExpression="TARGET" Visible="False"><ItemTemplate>
<asp:Label id="Lbdestino" runat="server" Text='<%# Bind("TARGET") %>' __designer:wfdid="w16"></asp:Label> 
</ItemTemplate>
</asp:TemplateField>
<asp:TemplateField HeaderText="PRINCIPAL" SortExpression="PPAL" Visible="False"><ItemTemplate>
<asp:Label id="Lbprincipal" runat="server" Text='<%# Bind("PPAL") %>' __designer:wfdid="w17"></asp:Label> 
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
</asp:GridView>&nbsp;<!-- <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White"></FooterStyle>-->&nbsp; <asp:HiddenField id="Oper" runat="server"></asp:HiddenField> <asp:HiddenField id="FValores" runat="server" __designer:wfdid="w111"></asp:HiddenField>&nbsp;<asp:HiddenField id="HdPk1" runat="server"></asp:HiddenField>&nbsp;&nbsp;<BR />&nbsp;&nbsp;
<asp:ObjectDataSource id="Objmenu" runat="server" __designer:wfdid="w112" SelectMethod="GetOpciones" TypeName="Menudatos"><SelectParameters>
<asp:ControlParameter ControlID="FValores" PropertyName="Value" Name="Filtro"></asp:ControlParameter>
</SelectParameters>
</asp:ObjectDataSource> <asp:ObjectDataSource id="ObjPMenu" runat="server" __designer:wfdid="w113" SelectMethod="GetOpciones" TypeName="Menudatos"></asp:ObjectDataSource>&nbsp; <BR />
</contenttemplate>
        <Triggers>
            <asp:AsyncPostBackTrigger ControlID="BtnFiltrar" EventName="Click" />
            <asp:AsyncPostBackTrigger ControlID="BtnRoles" EventName="Click" />
        </Triggers>
    </asp:UpdatePanel>&nbsp;
    &nbsp;&nbsp;&nbsp;&nbsp;<asp:UpdatePanel id="UpdatePanel2" 
        runat="server"><contenttemplate>
<!-- Mensaje de Salida--><asp:Button style="DISPLAY: none" id="hiddenTargetControlForModalPopup2" runat="server"></asp:Button> <ajaxToolkit:ModalPopupExtender id="ModalPopupTer" runat="server" PopupDragHandleControlID="programmaticPopupDragHandle2" PopupControlID="programmaticPopup2" DropShadow="True" BackgroundCssClass="modalBackground" BehaviorID="programmaticModalPopupBehavior2" RepositionMode="RepositionOnWindowScroll" TargetControlID="hiddenTargetControlForModalPopup2">
            </ajaxToolkit:ModalPopupExtender>&nbsp;<asp:Panel id="programmaticPopup2" 
                runat="server" Width="641px" Height="499px" CssClass="ModalPanel2" 
                Visible="true"><asp:Panel id="programmaticPopupDragHandle2" runat="Server" Width="639px" Height="30px" CssClass="BarTitleModal2"><DIV style="PADDING-RIGHT: 5px; PADDING-LEFT: 5px; PADDING-BOTTOM: 5px; VERTICAL-ALIGN: middle; PADDING-TOP: 5px"><DIV style="FLOAT: left">
                Menu</DIV><DIV style="FLOAT: right"><INPUT id="BtnCerrar" type=button value="X" /></DIV></DIV></asp:Panel>
                &nbsp;<TABLE><TBODY>
        <TR><TD colSpan=3><asp:Label id="SubT" runat="server" Text="Nuevo" CssClass="SubTitulo"></asp:Label></TD></TR><TR>
            <TD colSpan=3><asp:ValidationSummary id="ValidationSummary1" runat="server"></asp:ValidationSummary></TD></TR>
        <TR><TD style="WIDTH: 98px; HEIGHT: 21px">MENUID</TD><TD style="WIDTH: 100px; HEIGHT: 21px"><asp:TextBox id="TxtMenuidNew" runat="server"></asp:TextBox></TD><TD style="WIDTH: 20px; HEIGHT: 21px"><asp:RequiredFieldValidator id="RequiredFieldValidator1" runat="server" ControlToValidate="TxtMenuidNew" ErrorMessage="Digite un Codigo">*</asp:RequiredFieldValidator></TD></TR>
        <TR><TD style="WIDTH: 98px; HEIGHT: 23px"><asp:Label id="Label1" runat="server" Width="126px" Text="TITULO"></asp:Label></TD><TD style="WIDTH: 100px; HEIGHT: 23px"><asp:TextBox id="txtTituloNew" runat="server" Width="227px"></asp:TextBox></TD><TD style="WIDTH: 20px; HEIGHT: 23px"><asp:RequiredFieldValidator id="RequiredFieldValidator3" runat="server" ControlToValidate="txtTituloNew" ErrorMessage="Digite un Nombre">*</asp:RequiredFieldValidator></TD></TR>
        <TR><TD style="WIDTH: 98px; HEIGHT: 18px"><asp:Label id="Label2" runat="server" Width="117px" Text="DESCRIPCION"></asp:Label></TD><TD style="WIDTH: 100px; HEIGHT: 18px"><asp:TextBox id="txtDescripcionNew" runat="server" Width="228px" TextMode="MultiLine"></asp:TextBox></TD><TD style="WIDTH: 20px; HEIGHT: 18px"><asp:RequiredFieldValidator id="RequiredFieldValidator4" runat="server" ControlToValidate="txtDescripcionNew" ErrorMessage="Digite Responsable">*</asp:RequiredFieldValidator></TD></TR>
        <TR><TD style="WIDTH: 98px; HEIGHT: 19px"><asp:Label id="Label3" runat="server" Text="PADREID"></asp:Label></TD><TD style="WIDTH: 100px; HEIGHT: 19px">
                <asp:DropDownList id="cbpadreid" runat="server" Width="166px" DataSourceID="Objmenu" DataValueField="MenuId" DataTextField="CTitulo">
                    </asp:DropDownList></TD><TD style="WIDTH: 20px; HEIGHT: 19px"></TD></TR><TR>
            <TD style="WIDTH: 98px"><asp:Label id="Label4" runat="server" Width="109px" Text="POSICION"></asp:Label></TD>
            <TD style="WIDTH: 100px"><asp:TextBox id="txtPosicionNew" runat="server"></asp:TextBox></TD>
            <TD style="WIDTH: 20px"><asp:RequiredFieldValidator id="RequiredFieldValidator5" runat="server" ControlToValidate="txtPosicionNew" ErrorMessage="Digite Codigo de la Sancion">*</asp:RequiredFieldValidator></TD></TR>
        <TR><TD style="WIDTH: 98px"><asp:Label id="Label5" runat="server" Width="109px" Text="ICONO"></asp:Label></TD><TD style="WIDTH: 100px"><asp:TextBox id="txtIconoNew" runat="server"></asp:TextBox></TD><TD style="WIDTH: 20px"></TD></TR><TR>
            <TD style="WIDTH: 98px; HEIGHT: 22px"><asp:Label id="Label6" runat="server" Width="109px" Text="HABILITADO"></asp:Label></TD>
            <TD style="WIDTH: 100px; HEIGHT: 22px"><asp:DropDownList id="CbHabilitado" runat="server" __designer:wfdid="w23"><asp:ListItem Value="1">Si</asp:ListItem>
<asp:ListItem Value="0">No</asp:ListItem>

                    </asp:DropDownList></TD><TD style="WIDTH: 20px; HEIGHT: 22px"></TD></TR><TR>
            <TD style="WIDTH: 98px"><asp:Label id="Label7" runat="server" Text="URL"></asp:Label></TD>
            <TD style="WIDTH: 100px"><asp:TextBox id="txtUrlNew" runat="server" Width="272px"></asp:TextBox></TD>
            <TD style="WIDTH: 20px"><asp:RequiredFieldValidator id="RequiredFieldValidator8" runat="server" ControlToValidate="txtModuloNew" ErrorMessage="*">*</asp:RequiredFieldValidator></TD></TR>
        <TR><TD style="WIDTH: 98px"><asp:Label id="Label8" runat="server" Text="MODULO"></asp:Label></TD><TD style="WIDTH: 100px"><asp:TextBox id="txtModuloNew" runat="server"></asp:TextBox></TD><TD style="WIDTH: 20px"><asp:RequiredFieldValidator id="RequiredFieldValidator9" runat="server" ControlToValidate="txtRolesNew">*</asp:RequiredFieldValidator></TD></TR>
        <TR><TD style="WIDTH: 98px"><asp:Label id="Label9" runat="server" Text="ROLES"></asp:Label></TD><TD style="WIDTH: 100px"><asp:TextBox id="txtRolesNew" runat="server"></asp:TextBox></TD><TD style="WIDTH: 20px"><asp:RequiredFieldValidator id="RequiredFieldValidator10" runat="server" ControlToValidate="txtRolesNew" ErrorMessage="*">*</asp:RequiredFieldValidator></TD></TR>
        <TR><TD style="WIDTH: 98px"><asp:Label id="Label10" runat="server" Text="TARGET"></asp:Label></TD><TD style="WIDTH: 100px"><asp:TextBox id="txtTargetNew" runat="server"></asp:TextBox></TD><TD style="WIDTH: 20px"></TD></TR>
        <TR><TD style="WIDTH: 98px"><asp:Label id="Label11" runat="server" Text="PPAL"></asp:Label></TD><TD style="WIDTH: 100px"><asp:TextBox id="txtPpalNew" runat="server"></asp:TextBox></TD><TD style="WIDTH: 20px"><asp:RequiredFieldValidator id="RequiredFieldValidator12" runat="server" ControlToValidate="txtPpalNew" ErrorMessage="RequiredFieldValidator">*</asp:RequiredFieldValidator></TD></TR>
        <TR><TD style="WIDTH: 98px; HEIGHT: 18px"></TD><TD style="WIDTH: 100px; HEIGHT: 18px"></TD><TD style="WIDTH: 20px; HEIGHT: 18px"></TD></TR><TR>
            <TD style="WIDTH: 98px; HEIGHT: 18px"></TD>
            <TD style="WIDTH: 100px; HEIGHT: 18px"></TD>
            <TD style="WIDTH: 20px; HEIGHT: 18px"></TD></TR>
        <TR><TD style="TEXT-ALIGN: center" colSpan=3><asp:Button id="BtnGuardar" onclick="BtnGuardar_Click" runat="server" Text="Guardar"></asp:Button>&#160;<asp:Button id="BtnEliminar" onclick="BtnEliminar_Click" runat="server" Text="Eliminar"></asp:Button>&#160; <INPUT id="BtnCancelar" type=button value="Cancelar" /> </TD></TR></TBODY></TABLE>
                &nbsp;&nbsp;</asp:Panel>&nbsp;&nbsp; 
</contenttemplate>
    </asp:UpdatePanel><br />
    
    <asp:UpdateProgress id="UpdateProgress1" runat="server" AssociatedUpdatePanelID="UpdatePanel1">
        <progresstemplate>
<DIV class="Loading"><IMG title="" alt="" src="../../images/loading.gif" /> Cargando … </DIV>
</progresstemplate>
    </asp:UpdateProgress>
</div>

</asp:Content>

