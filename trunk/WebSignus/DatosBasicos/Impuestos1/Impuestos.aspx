<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="Impuestos.aspx.vb" Inherits="DatosBasicos_Impuestos1_Impuestos" title="Untitled Page" %>
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
&nbsp;<asp:Label id="Tit" runat="server" Width="286px" CssClass="Titulo" Text="Impuestos"></asp:Label><BR /><asp:Label id="MsgResult" runat="server"></asp:Label>&nbsp;&nbsp;&nbsp;<BR /><asp:GridView id="GridView1" runat="server" Width="100%" ForeColor="#333333" PageSize="20" AllowSorting="True" OnRowDataBound="GridView1_RowDataBound1" AllowPaging="True" DataSourceID="Objimpu" GridLines="None" CellPadding="4" ShowFooter="True" OnRowCommand="GridView1_RowCommand" DataKeyNames="IMP_COD" AutoGenerateColumns="False" OnSelectedIndexChanged="GridView1_SelectedIndexChanged1" EmptyDataText="No se encontraron Registros en la Base de Datos">
<RowStyle BackColor="#F7F6F3" ForeColor="#333333"></RowStyle>
<Columns>
<asp:TemplateField HeaderText="C&#243;digo del Impuesto" SortExpression="IMP_COD"><FooterTemplate>
<asp:LinkButton id="lnkNuevo" runat="server" Text="Nuevo Registro" __designer:wfdid="w128" CausesValidation="False" CommandName="Nuevo"></asp:LinkButton> 
</FooterTemplate>
<ItemTemplate>
<asp:Label id="LbCod" runat="server" Text='<%# Bind("IMP_COD") %>' __designer:wfdid="w126"></asp:Label> 
</ItemTemplate>
</asp:TemplateField>
<asp:TemplateField HeaderText="Nombre del Impuesto" SortExpression="IMP_NOM"><ItemTemplate>
<asp:Label id="LbNom" runat="server" Text='<%# Bind("IMP_NOM") %>' __designer:wfdid="w129"></asp:Label> 
</ItemTemplate>
</asp:TemplateField>
<asp:TemplateField HeaderText="Observacion" SortExpression="IMP_OBS"><ItemTemplate>
<asp:Label id="Lbobs" runat="server" Text='<%# Bind("IMP_OBS") %>' __designer:wfdid="w130"></asp:Label> 
</ItemTemplate>
</asp:TemplateField>
<asp:TemplateField HeaderText="Norma" SortExpression="IMP_NOR"><ItemTemplate>
<asp:Label id="Lbnorm" runat="server" Text='<%# Bind("IMP_NOR") %>' __designer:wfdid="w131"></asp:Label> 
</ItemTemplate>
</asp:TemplateField>
<asp:TemplateField HeaderText="Clase de Declaracion" SortExpression="IMP_CLA"><ItemTemplate>
<asp:Label id="Lbcla" runat="server" Text='<%# Bind("IMP_CLA") %>' __designer:wfdid="w132"></asp:Label> 
</ItemTemplate>
</asp:TemplateField>
<asp:TemplateField HeaderText="Unidad" SortExpression="IMP_UNI"><ItemTemplate>
<asp:Label id="Lbuni" runat="server" Text='<%# Bind("IMP_UNI") %>' __designer:wfdid="w133"></asp:Label> 
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
</asp:GridView> <asp:ObjectDataSource id="Objimpu" runat="server" TypeName="Impuestos1" SelectMethod="GetRecords"></asp:ObjectDataSource><!-- <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White"></FooterStyle>-->&nbsp; <asp:HiddenField id="Oper" runat="server"></asp:HiddenField> <asp:ObjectDataSource id="ObjClaImp" runat="server" TypeName="Clase_Impto" SelectMethod="GetRecords" __designer:wfdid="w123"></asp:ObjectDataSource>&nbsp;<asp:HiddenField id="HdPk1" runat="server"></asp:HiddenField>&nbsp;&nbsp;<asp:ObjectDataSource id="ObjUnidades" runat="server" TypeName="Unidades" SelectMethod="GetRecords" __designer:wfdid="w124"></asp:ObjectDataSource><BR />&nbsp;&nbsp;<BR />
</contenttemplate>
    </asp:UpdatePanel>&nbsp;
    &nbsp;&nbsp;&nbsp;&nbsp;<asp:UpdatePanel id="UpdatePanel2"
        runat="server"><contenttemplate>
<!-- Mensaje de Salida--><BR /><asp:Button style="DISPLAY: none" id="hiddenTargetControlForModalPopup2" runat="server"></asp:Button>&nbsp; <ajaxToolkit:ModalPopupExtender id="ModalPopupTer" runat="server" PopupDragHandleControlID="programmaticPopupDragHandle2" PopupControlID="programmaticPopup2" DropShadow="True" BackgroundCssClass="modalBackground" BehaviorID="programmaticModalPopupBehavior2" RepositionMode="RepositionOnWindowScroll" TargetControlID="hiddenTargetControlForModalPopup2">
            </ajaxToolkit:ModalPopupExtender>&nbsp;&nbsp; <asp:Panel id="programmaticPopup2" runat="server" Width="496px" Height="363px" CssClass="ModalPanel2"><asp:Panel id="programmaticPopupDragHandle2" runat="Server" Width="483px" Height="30px" CssClass="BarTitleModal2"><DIV style="PADDING-RIGHT: 5px; PADDING-LEFT: 5px; PADDING-BOTTOM: 5px; VERTICAL-ALIGN: middle; PADDING-TOP: 5px"><DIV style="FLOAT: left">Impuestos</DIV><DIV style="FLOAT: right"><INPUT id="BtnCerrar" type=button value="X" /></DIV></DIV></asp:Panel>&nbsp;<TABLE><TBODY><TR><TD colSpan=3><asp:Label id="SubT" runat="server" CssClass="SubTitulo" Text="Nuevo"></asp:Label></TD></TR><TR><TD colSpan=3><asp:ValidationSummary id="ValidationSummary1" runat="server"></asp:ValidationSummary></TD></TR><TR><TD style="WIDTH: 98px">Código</TD><TD style="WIDTH: 100px"><asp:TextBox id="TxtCodNew" runat="server" __designer:wfdid="w108"></asp:TextBox></TD><TD style="WIDTH: 100px"></TD></TR><TR><TD style="WIDTH: 98px; HEIGHT: 23px"><asp:Label id="Label5" runat="server" Text="Nombre" __designer:wfdid="w120"></asp:Label></TD><TD style="WIDTH: 100px; HEIGHT: 23px"><asp:TextBox id="TxtNomNew" runat="server" Width="229px" __designer:wfdid="w109"></asp:TextBox></TD><TD style="WIDTH: 100px; HEIGHT: 23px"></TD></TR><TR><TD style="WIDTH: 98px; HEIGHT: 18px"><asp:Label id="Label4" runat="server" Text="Observacion" __designer:wfdid="w119"></asp:Label></TD><TD style="WIDTH: 100px; HEIGHT: 18px"><asp:TextBox id="TxtObsNew" runat="server" __designer:wfdid="w113" TextMode="MultiLine"></asp:TextBox></TD><TD style="WIDTH: 100px; HEIGHT: 18px"></TD></TR><TR><TD style="WIDTH: 98px; HEIGHT: 19px"><asp:Label id="Label3" runat="server" Text="Norma" __designer:wfdid="w118"></asp:Label></TD><TD style="WIDTH: 100px; HEIGHT: 19px"><asp:TextBox id="TxtNorNew" runat="server" Width="272px" __designer:wfdid="w112" TextMode="MultiLine"></asp:TextBox></TD><TD style="WIDTH: 100px; HEIGHT: 19px"></TD></TR><TR><TD style="WIDTH: 98px"><asp:Label id="Label2" runat="server" Text="Clase de Impuesto" __designer:wfdid="w117"></asp:Label></TD><TD style="WIDTH: 100px"><asp:DropDownList id="CmbClase" runat="server" DataSourceID="ObjClaImp" DataValueField="CLIM_CODI" DataTextField="CLIM_NOMB" __designer:wfdid="w115"></asp:DropDownList></TD><TD style="WIDTH: 100px"></TD></TR><TR><TD style="WIDTH: 98px"><asp:Label id="Label1" runat="server" Text="Unidad" __designer:wfdid="w116"></asp:Label></TD><TD style="WIDTH: 100px"><asp:DropDownList id="CboUniNew" runat="server" DataSourceID="ObjUnidades" DataValueField="uni_Cod" DataTextField="Uni_Nom" __designer:wfdid="w110"></asp:DropDownList></TD><TD style="WIDTH: 100px"></TD></TR><TR><TD style="WIDTH: 98px; HEIGHT: 18px"></TD><TD style="WIDTH: 100px; HEIGHT: 18px"></TD><TD style="WIDTH: 100px; HEIGHT: 18px"></TD></TR><TR><TD style="TEXT-ALIGN: center" colSpan=3><asp:Button id="BtnGuardar" onclick="BtnGuardar_Click" runat="server" Text="Guardar" __designer:wfdid="w121"></asp:Button>&nbsp; <asp:Button id="BtnEliminar" onclick="BtnEliminar_Click" runat="server" Text="Eliminar" __designer:wfdid="w122"></asp:Button>&nbsp; <INPUT id="BtnCancelar" type=button value="Cancelar" /></TD></TR></TBODY></TABLE>&nbsp; </asp:Panel>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 
</contenttemplate>
    </asp:UpdatePanel>&nbsp; &nbsp;
    <asp:ObjectDataSource ID="ObjTiCo" runat="server" OldValuesParameterFormatString="original_{0}"
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

