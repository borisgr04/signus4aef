<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="Formayud.aspx.vb" Inherits="DatosBasicos_Form_Ayud_Formayud" title="Untitled Page" %>
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
    <asp:UpdatePanel id="UpdatePanel1" runat="server" UpdateMode="Conditional">
        <contenttemplate>
&nbsp;<asp:Label id="Tit" runat="server" Width="481px" Text="Configuración de Instructivos de Ayuda  para Formularios" CssClass="Titulo" __designer:wfdid="w29"></asp:Label><BR />
<HR />
&nbsp;<BR /><asp:Label id="MsgResult" runat="server" __designer:wfdid="w30"></asp:Label><BR /><TABLE><TBODY><TR><TD style="WIDTH: 100px"><asp:Label id="Label5" runat="server" __designer:wfdid="w31">Clase de Declaración</asp:Label></TD><TD style="WIDTH: 100px"></TD><TD style="WIDTH: 100px"></TD></TR><TR><TD style="WIDTH: 100px; HEIGHT: 21px"><asp:DropDownList id="CmbCdec" runat="server" Width="285px" __designer:dtid="281474976710693" __designer:wfdid="w32" DataSourceID="ObjClaseDec" AutoPostBack="True" DataTextField="cld_nom" DataValueField="cld_cod">
                    </asp:DropDownList></TD><TD style="WIDTH: 100px; HEIGHT: 21px"></TD><TD style="WIDTH: 100px; HEIGHT: 21px"></TD></TR><TR><TD style="WIDTH: 100px"><asp:Label id="Label6" runat="server" __designer:wfdid="w33">Formulario de Declaración</asp:Label></TD><TD style="WIDTH: 100px"></TD><TD style="WIDTH: 100px"></TD></TR><TR><TD style="WIDTH: 100px; HEIGHT: 21px"><asp:DropDownList id="CboFode" runat="server" Width="285px" __designer:dtid="281474976710693" __designer:wfdid="w34" DataSourceID="ObjFode" AutoPostBack="True" DataTextField="Fode_CNom" DataValueField="Fode_Codi"></asp:DropDownList></TD><TD style="WIDTH: 100px; HEIGHT: 21px"><asp:Button id="BtnAct" onclick="BtnAct_Click" runat="server" Text="Actualizar" __designer:wfdid="w35"></asp:Button></TD><TD style="WIDTH: 100px; HEIGHT: 21px"></TD></TR></TBODY></TABLE>&nbsp; <BR /><asp:LinkButton id="lnkNuevo" onclick="lnkNuevo_Click" runat="server" Text="Nuevo Registro" __designer:wfdid="w36" CausesValidation="False" CommandName="Nuevo"></asp:LinkButton><BR /><asp:GridView id="GridView1" runat="server" Width="100%" ForeColor="#333333" __designer:wfdid="w37" DataSourceID="Objform" PageSize="20" AllowPaging="True" GridLines="None" CellPadding="4" ShowFooter="True" OnRowCommand="GridView1_RowCommand" DataKeyNames="FOAY_CODI" AutoGenerateColumns="False" OnSelectedIndexChanged="GridView1_SelectedIndexChanged" EmptyDataText="No se encontraron Registros en la Base de Datos" OnRowDataBound="GridView1_RowDataBound1" AllowSorting="True">
<RowStyle BackColor="#F7F6F3" ForeColor="#333333"></RowStyle>
<Columns>
<asp:TemplateField HeaderText="C&#243;digo" SortExpression="FOAY_CODI"><FooterTemplate>
&nbsp;
</FooterTemplate>
<ItemTemplate>
<asp:Label id="LbCodi" runat="server" Text='<%# Bind("FOAY_CODI") %>' __designer:wfdid="w11"></asp:Label> 
</ItemTemplate>
</asp:TemplateField>
<asp:TemplateField HeaderText="Numero del Renglon" SortExpression="FOAY_NREN"><ItemTemplate>
<asp:Label id="Lbnren" runat="server" Text='<%# Bind("FOAY_NREN") %>' __designer:wfdid="w29"></asp:Label> 
</ItemTemplate>
</asp:TemplateField>
<asp:TemplateField HeaderText="Codigo del Formulario" SortExpression="FOAY_FDCO"><ItemTemplate>
<asp:Label id="Lbfdco" runat="server" Text='<%# Bind("FOAY_FDCO") %>' __designer:wfdid="w30"></asp:Label> 
</ItemTemplate>
</asp:TemplateField>
<asp:TemplateField HeaderText="Titulo" SortExpression="FOAY_TITU"><ItemTemplate>
<asp:Label id="Lbtitu" runat="server" Text='<%# Bind("FOAY_TITU") %>' __designer:wfdid="w31"></asp:Label> 
</ItemTemplate>
</asp:TemplateField>
<asp:TemplateField HeaderText="Descripcion del Renglon" SortExpression="FOAY_DESC"><ItemTemplate>
<asp:Label id="Lbdesc" runat="server" Text='<%# Bind("FOAY_DESC") %>' __designer:wfdid="w32"></asp:Label> 
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
</asp:GridView> <asp:ObjectDataSource id="Objform" runat="server" __designer:wfdid="w38" TypeName="Form_Ayud" SelectMethod="GetPorFdCo"><SelectParameters>
<asp:ControlParameter ControlID="CboFode" PropertyName="SelectedValue" Name="FdCo"></asp:ControlParameter>
</SelectParameters>
</asp:ObjectDataSource><!-- <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White"></FooterStyle>--><asp:HiddenField id="Oper" runat="server" __designer:wfdid="w39"></asp:HiddenField><asp:HiddenField id="HdPk1" runat="server" __designer:wfdid="w40"></asp:HiddenField><asp:ObjectDataSource id="ObjClaseDec" runat="server" __designer:dtid="1125899906842634" __designer:wfdid="w41" TypeName="Informes" SelectMethod="GetcargarTipoDecla" OldValuesParameterFormatString="original_{0}"></asp:ObjectDataSource> <asp:ObjectDataSource id="ObjFode" runat="server" __designer:dtid="1125899906842634" __designer:wfdid="w42" TypeName="Formularios_Dec" SelectMethod="GetPorCDec" OldValuesParameterFormatString="original_{0}"><SelectParameters>
<asp:ControlParameter ControlID="CmbCdec" PropertyName="SelectedValue" Name="ClDec"></asp:ControlParameter>
</SelectParameters>
</asp:ObjectDataSource><BR />&nbsp;&nbsp;<BR />
</contenttemplate>
        <triggers>
<asp:AsyncPostBackTrigger ControlID="CmbCdec" EventName="SelectedIndexChanged"></asp:AsyncPostBackTrigger>
<asp:AsyncPostBackTrigger ControlID="CboFode" EventName="SelectedIndexChanged"></asp:AsyncPostBackTrigger>
</triggers>
    </asp:UpdatePanel>&nbsp;
    &nbsp;&nbsp;&nbsp;&nbsp;<asp:UpdatePanel id="UpdatePanel2"
        runat="server"><contenttemplate>
<!-- Mensaje de Salida--><BR /><asp:Button style="DISPLAY: none" id="hiddenTargetControlForModalPopup2" runat="server"></asp:Button> <ajaxToolkit:ModalPopupExtender id="ModalPopupTer" runat="server" PopupDragHandleControlID="programmaticPopupDragHandle2" PopupControlID="programmaticPopup2" DropShadow="True" BackgroundCssClass="modalBackground" BehaviorID="programmaticModalPopupBehavior2" RepositionMode="RepositionOnWindowScroll" TargetControlID="hiddenTargetControlForModalPopup2">
            </ajaxToolkit:ModalPopupExtender>&nbsp;&nbsp; <asp:Panel id="programmaticPopup2" runat="server" Width="660px" Height="400px" CssClass="ModalPanel2"><asp:Panel id="programmaticPopupDragHandle2" runat="Server" Width="655px" Height="30px" CssClass="BarTitleModal2"><DIV style="PADDING-RIGHT: 5px; PADDING-LEFT: 5px; PADDING-BOTTOM: 5px; VERTICAL-ALIGN: middle; PADDING-TOP: 5px"><DIV style="FLOAT: left">Formulario de Ayuda</DIV><DIV style="FLOAT: right"><INPUT id="BtnCerrar" type=button value="X" /></DIV></DIV></asp:Panel>&nbsp;<TABLE><TBODY><TR><TD colSpan=3><asp:Label id="SubT" runat="server" CssClass="SubTitulo" Text="Nuevo"></asp:Label></TD></TR><TR><TD colSpan=3><asp:ValidationSummary id="ValidationSummary1" runat="server"></asp:ValidationSummary></TD></TR><TR><TD style="WIDTH: 98px">Código</TD><TD style="WIDTH: 100px"><asp:TextBox id="TxtCodiNew" runat="server" Enabled="False"></asp:TextBox></TD><TD style="WIDTH: 100px"></TD></TR><TR><TD style="WIDTH: 98px; HEIGHT: 23px"><asp:Label id="Label2" runat="server" Width="117px" Text="Codigo del Formulario"></asp:Label></TD><TD style="WIDTH: 100px; HEIGHT: 23px"><asp:TextBox id="txtfdcoNew" runat="server" Enabled="False"></asp:TextBox> </TD><TD style="WIDTH: 100px; HEIGHT: 23px"><asp:RequiredFieldValidator id="RequiredFieldValidator3" runat="server" ControlToValidate="txtnrenNew" ErrorMessage="Digite Abreviatura del Concepto">*</asp:RequiredFieldValidator></TD></TR><TR><TD style="WIDTH: 98px; HEIGHT: 18px"><asp:Label id="Label1" runat="server" Width="126px" Text="Numero del Renglon"></asp:Label></TD><TD style="WIDTH: 100px; HEIGHT: 18px"><asp:TextBox id="txtnrenNew" runat="server"></asp:TextBox></TD><TD style="WIDTH: 100px; HEIGHT: 18px"><asp:RequiredFieldValidator id="RequiredFieldValidator4" runat="server" ControlToValidate="txtfdcoNew" ErrorMessage="Digite un Nombre">*</asp:RequiredFieldValidator></TD></TR><TR><TD style="WIDTH: 98px; HEIGHT: 19px"><asp:Label id="Label3" runat="server" Text="Titulo"></asp:Label></TD><TD style="WIDTH: 100px; HEIGHT: 19px"><asp:TextBox id="txttituNew" runat="server" Width="319px"></asp:TextBox></TD><TD style="WIDTH: 100px; HEIGHT: 19px"><asp:RequiredFieldValidator id="RequiredFieldValidator2" runat="server" ControlToValidate="txttituNew" ErrorMessage="Digite Tipo de Concepto">*</asp:RequiredFieldValidator></TD></TR><TR><TD style="WIDTH: 98px" vAlign=top><asp:Label id="Label4" runat="server" Width="109px" Text="Descripion del Renglon"></asp:Label></TD><TD style="WIDTH: 100px"><asp:TextBox id="txtdescNew" runat="server" Width="395px" Height="127px" TextMode="MultiLine"></asp:TextBox></TD><TD style="WIDTH: 100px"><asp:RequiredFieldValidator id="RequiredFieldValidator5" runat="server" ControlToValidate="txtdescNew" ErrorMessage="Digite la Clase de Declaracion">*</asp:RequiredFieldValidator></TD></TR><TR><TD style="WIDTH: 98px"></TD><TD style="WIDTH: 100px"></TD><TD style="WIDTH: 100px"></TD></TR><TR><TD style="WIDTH: 98px"></TD><TD style="WIDTH: 100px"></TD><TD style="WIDTH: 100px"></TD></TR><TR><TD style="TEXT-ALIGN: center" colSpan=3><asp:Button id="BtnGuardar" onclick="BtnGuardar_Click" runat="server" Text="Guardar"></asp:Button>&nbsp;<asp:Button id="BtnEliminar" onclick="BtnEliminar_Click" runat="server" Text="Eliminar"></asp:Button>&nbsp; <INPUT id="BtnCancelar" type=button value="Cancelar" /> </TD></TR></TBODY></TABLE>&nbsp; </asp:Panel>&nbsp;&nbsp; 
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

