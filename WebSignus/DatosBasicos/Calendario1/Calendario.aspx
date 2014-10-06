<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="Calendario.aspx.vb" Inherits="DatosBasicos_Calendario1_Calendario" title="" %>
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
    &nbsp;<br />
    <asp:UpdatePanel id="UpdatePanel1" runat="server" UpdateMode="Conditional">
        <contenttemplate>
<asp:Label id="Tit" runat="server" Width="286px" CssClass="Titulo" Text="Calendario Tributario" __designer:wfdid="w360"></asp:Label> <BR />
            <asp:Label id="MsgResult" runat="server" __designer:wfdid="w361"></asp:Label><asp:TextBox id="TxtCDec" runat="server" Width="71px" __designer:wfdid="w362" Visible="False"></asp:TextBox> <TABLE><TBODY><TR><TD style="WIDTH: 100px">Clase Declaración</TD><TD style="WIDTH: 100px">Año Gravable</TD><TD style="WIDTH: 100px">Periodo Gravable</TD><TD style="WIDTH: 100px">
                <asp:Label ID="Label8" runat="server" __designer:wfdid="w414" 
                    Text="N° de Registros a mostrar"></asp:Label>
                </TD>
                <td style="WIDTH: 100px">
                    &nbsp;</td>
                <TD style="WIDTH: 100px"></TD>
                <td style="WIDTH: 100px">
                    &nbsp;</td>
                </TR><TR><TD style="WIDTH: 100px"><asp:DropDownList id="CMBCLADEC" runat="server" Width="253px" __designer:wfdid="w4" DataSourceID="ObjClaseDec" DataValueField="cld_cod" DataTextField="cld_nom" AutoPostBack="True"></asp:DropDownList></TD><TD style="WIDTH: 100px"><asp:TextBox id="TxtA" runat="server" Width="71px" __designer:wfdid="w363"></asp:TextBox></TD><TD style="WIDTH: 100px"><asp:TextBox id="TxtP" runat="server" Width="82px" __designer:wfdid="w364"></asp:TextBox></TD><TD style="WIDTH: 100px">
                    <asp:TextBox ID="TxtNReg" runat="server" __designer:wfdid="w412" Width="82px"></asp:TextBox>
                    </TD>
                    <td style="WIDTH: 100px">
                        <asp:Button ID="BtnFiltrar" runat="server" __designer:dtid="1970324836974596" 
                            __designer:wfdid="w365" onclick="BtnFiltrar_Click" Text="Filtrar" 
                            Width="71px" />
                    </td>
                    <TD style="WIDTH: 100px">
                        <asp:Button ID="BtnQuitarF" runat="server" __designer:wfdid="w366" 
                            onclick="BtnQuitarF_Click" Text="Quitar Filtro" />
                    </TD>
                    <td style="WIDTH: 100px">
                        <asp:Button ID="BtnNReg" runat="server" __designer:wfdid="w415" 
                            onclick="BtnNReg_Click" Text="Actualizar" />
                    </td>
                </TR><TR><TD style="HEIGHT: 19px" colSpan=2>&nbsp;</TD><TD style="WIDTH: 100px; HEIGHT: 19px">
                    &nbsp;</TD><TD style="WIDTH: 100px; HEIGHT: 19px">&nbsp;</TD>
                    <td style="WIDTH: 100px; HEIGHT: 19px">
                        &nbsp;</td>
                    <TD style="WIDTH: 100px; HEIGHT: 19px"></TD>
                    <td style="WIDTH: 100px; HEIGHT: 19px">
                        &nbsp;</td>
                </TR></TBODY></TABLE><BR /><asp:GridView id="GridView1" runat="server" Width="822px" ForeColor="#333333" __designer:wfdid="w321" EmptyDataText="No se encontraron Registros en la Base de Datos" OnSelectedIndexChanged="GridView1_SelectedIndexChanged" AutoGenerateColumns="False" DataKeyNames="CAL_PER,CAL_VIG,CAL_CLA" OnRowCommand="GridView1_RowCommand" ShowFooter="True" CellPadding="4" GridLines="None" DataSourceID="Objcale" AllowPaging="True" OnRowDataBound="GridView1_RowDataBound1" AllowSorting="True" PageSize="12">
<RowStyle BackColor="#F7F6F3" ForeColor="#333333"></RowStyle>
<Columns>
<asp:TemplateField HeaderText="Clase de Declaracion" SortExpression="CAL_CLA"><FooterTemplate>
<asp:LinkButton id="lnkNuevo" runat="server" Text="Nuevo Registro" __designer:wfdid="w6" CommandName="Nuevo" CausesValidation="False"></asp:LinkButton> 
</FooterTemplate>
<ItemTemplate>
<asp:Label id="Lbcla" runat="server" Text='<%# Bind("CAL_CLA") %>' __designer:wfdid="w409"></asp:Label> 
</ItemTemplate>
</asp:TemplateField>
<asp:TemplateField HeaderText="Clase Declaraci&#243;n" SortExpression="CLD_NOM"><ItemTemplate>
<asp:Label id="LbNomC" runat="server" Text='<%# Bind("CLD_NOM") %>'></asp:Label> 
</ItemTemplate>
</asp:TemplateField>
<asp:TemplateField HeaderText="A&#241;o Gravable" SortExpression="CAL_VIG"><ItemTemplate>
<asp:Label id="Lbvig" runat="server" Text='<%# Bind("CAL_VIG") %>' __designer:wfdid="w16"></asp:Label> 
</ItemTemplate>
</asp:TemplateField>
<asp:TemplateField HeaderText="Periodo Gravable" SortExpression="CAL_PER"><ItemTemplate>
<asp:Label id="Lbper" runat="server" Text='<%# Bind("CAL_PER") %>' __designer:wfdid="w3"></asp:Label> 
</ItemTemplate>
</asp:TemplateField>
<asp:TemplateField HeaderText="Descripcion del Periodo" SortExpression="CAL_DES"><ItemTemplate>
<asp:Label id="Lbdes" runat="server" Text='<%# Bind("CAL_DES") %>' __designer:wfdid="w20"></asp:Label> 
</ItemTemplate>
</asp:TemplateField>
<asp:TemplateField HeaderText="Fecha de Inicio" SortExpression="CAL_FINI"><ItemTemplate>
<asp:Label id="Lbfecini" runat="server" Text='<%# Bind("CAL_FINI","{0:d}") %>' __designer:wfdid="w17"></asp:Label> 
</ItemTemplate>
</asp:TemplateField>
<asp:TemplateField HeaderText="Fecha Final" SortExpression="CAL_FFIN"><ItemTemplate>
<asp:Label id="Lbfini" runat="server" Text='<%# Bind("CAL_FFIN","{0:d}") %>' __designer:wfdid="w29"></asp:Label> 
</ItemTemplate>
</asp:TemplateField>
<asp:BoundField DataField="Cal_FVen" HeaderText="Fecha Vencimiento" SortExpression="Cal_FVen"></asp:BoundField>
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
</asp:GridView> <asp:ObjectDataSource id="Objcale" runat="server" __designer:wfdid="w368" SelectMethod="GetRecords" TypeName="Calendario1"><SelectParameters>
<asp:ControlParameter ControlID="FValores" PropertyName="Value" Name="Filtro"></asp:ControlParameter>
</SelectParameters>
</asp:ObjectDataSource><!-- <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White"></FooterStyle>-->&nbsp; <asp:HiddenField id="Oper" runat="server" __designer:wfdid="w369"></asp:HiddenField><asp:ObjectDataSource id="ObjClaseDec" runat="server" __designer:dtid="1688849860263961" __designer:wfdid="w6" SelectMethod="GetcargarTipoDecla" TypeName="Informes" OldValuesParameterFormatString="original_{0}"></asp:ObjectDataSource> <asp:HiddenField id="FValores" runat="server" __designer:wfdid="w370"></asp:HiddenField>&nbsp;<asp:HiddenField id="Hdpk2" runat="server" __designer:wfdid="w371"></asp:HiddenField> <asp:HiddenField id="HdPk1" runat="server" __designer:wfdid="w372"></asp:HiddenField>&nbsp;&nbsp;&nbsp;&nbsp;<asp:HiddenField id="Hdpk3" runat="server" __designer:wfdid="w373"></asp:HiddenField><BR /><asp:Button style="DISPLAY: none" id="hiddenTargetControlForModalPopup2" runat="server" __designer:wfdid="w374"></asp:Button> <ajaxToolkit:ModalPopupExtender id="ModalPopupTer" runat="server" __designer:wfdid="w375" PopupDragHandleControlID="programmaticPopupDragHandle2" PopupControlID="programmaticPopup2" DropShadow="True" BackgroundCssClass="modalBackground" BehaviorID="programmaticModalPopupBehavior2" RepositionMode="RepositionOnWindowScroll" TargetControlID="hiddenTargetControlForModalPopup2">
            </ajaxToolkit:ModalPopupExtender>&nbsp;&nbsp; <asp:Panel id="programmaticPopup2" runat="server" Width="660px" Height="464px" CssClass="ModalPanel2" __designer:wfdid="w376"><asp:Panel id="programmaticPopupDragHandle2" runat="Server" Width="538px" Height="30px" CssClass="BarTitleModal2" __designer:wfdid="w377"><DIV style="PADDING-RIGHT: 5px; PADDING-LEFT: 5px; PADDING-BOTTOM: 5px; VERTICAL-ALIGN: middle; PADDING-TOP: 5px"><DIV style="FLOAT: left">Calendario tributario</DIV><DIV style="FLOAT: right"><INPUT id="BtnCerrar" type=button value="X" /></DIV></DIV></asp:Panel>&nbsp;<TABLE style="WIDTH: 637px; HEIGHT: 359px"><TBODY><TR><TD colSpan=3><asp:Label id="SubT" runat="server" CssClass="SubTitulo" Text="Nuevo" __designer:wfdid="w378"></asp:Label></TD></TR><TR><TD colSpan=3><asp:ValidationSummary id="ValidationSummary1" runat="server" __designer:wfdid="w379"></asp:ValidationSummary></TD></TR><TR><TD style="WIDTH: 98px; HEIGHT: 10px; TEXT-ALIGN: justify"><asp:Label id="Label5" runat="server" Width="163px" Text="Clase de Declaración" __designer:wfdid="w380"></asp:Label></TD><TD style="WIDTH: 96px; HEIGHT: 10px"><asp:TextBox id="txtclaNew" runat="server" __designer:wfdid="w381"></asp:TextBox></TD><TD style="WIDTH: 100px; HEIGHT: 10px"><asp:RequiredFieldValidator id="RequiredFieldValidator5" runat="server" Width="1px" __designer:wfdid="w382" ControlToValidate="txtclaNew" ErrorMessage="Digite Clase de Declaracion">*</asp:RequiredFieldValidator></TD></TR><TR><TD style="WIDTH: 98px; HEIGHT: 10px; TEXT-ALIGN: justify"><asp:Label id="Label1" runat="server" Width="126px" Text="Año Gravable" __designer:wfdid="w383"></asp:Label></TD><TD style="WIDTH: 96px; HEIGHT: 10px"><asp:TextBox id="txtvigNew" runat="server" __designer:wfdid="w384"></asp:TextBox></TD><TD style="WIDTH: 100px; HEIGHT: 10px"><asp:RequiredFieldValidator id="RequiredFieldValidator3" runat="server" __designer:wfdid="w385" ControlToValidate="txtvigNew" ErrorMessage="Digite Vigencia del Periodo">*</asp:RequiredFieldValidator> </TD></TR><TR><TD style="WIDTH: 98px; HEIGHT: 13px; TEXT-ALIGN: justify"><asp:Label id="Label4" runat="server" Width="143px" Text="Periodo Gravable" __designer:wfdid="w386"></asp:Label></TD><TD style="WIDTH: 96px; HEIGHT: 13px"><asp:TextBox id="TxtperNew" runat="server" __designer:wfdid="w387"></asp:TextBox></TD><TD style="WIDTH: 100px; HEIGHT: 13px"><asp:RequiredFieldValidator id="RequiredFieldValidator1" runat="server" __designer:wfdid="w388" ControlToValidate="TxtperNew" ErrorMessage="Digite Periodo a Declarar">*</asp:RequiredFieldValidator></TD></TR><TR><TD style="WIDTH: 98px; HEIGHT: 6px"><asp:Label id="Label6" runat="server" Width="162px" Text="Descripcion del Periodo" __designer:wfdid="w389"></asp:Label></TD><TD style="WIDTH: 96px; HEIGHT: 6px"><asp:TextBox id="txtdesNew" runat="server" __designer:wfdid="w390"></asp:TextBox></TD><TD style="WIDTH: 100px; HEIGHT: 6px"><asp:RequiredFieldValidator id="RequiredFieldValidator6" runat="server" __designer:wfdid="w391" ControlToValidate="txtdesNew" ErrorMessage="Digite la Descripcion del Periodo">*</asp:RequiredFieldValidator></TD></TR><TR><TD style="WIDTH: 98px; HEIGHT: 6px"><asp:Label id="Label2" runat="server" Width="75px" Text="Fecha de Inicio" __designer:wfdid="w392"></asp:Label></TD><TD style="WIDTH: 96px; HEIGHT: 6px"><asp:TextBox id="txtfecini" runat="server" __designer:wfdid="w393"></asp:TextBox></TD><TD style="WIDTH: 100px; HEIGHT: 6px"><asp:RequiredFieldValidator id="RequiredFieldValidator4" runat="server" __designer:wfdid="w394" ControlToValidate="txtfecini" ErrorMessage="Digite Fecha de Inicio">*</asp:RequiredFieldValidator></TD></TR><TR><TD style="WIDTH: 98px; HEIGHT: 7px"><asp:Label id="Label3" runat="server" Width="78px" Text="Fecha Final" __designer:wfdid="w395"></asp:Label></TD><TD style="WIDTH: 96px; HEIGHT: 7px; TEXT-ALIGN: left"><asp:TextBox id="Txtfecfin" runat="server" __designer:wfdid="w396"></asp:TextBox></TD><TD style="WIDTH: 100px; HEIGHT: 7px"><asp:RequiredFieldValidator id="RequiredFieldValidator2" runat="server" __designer:wfdid="w397" ControlToValidate="Txtfecfin" ErrorMessage="Digite Fecha Final">*</asp:RequiredFieldValidator></TD></TR><TR><TD style="WIDTH: 98px; HEIGHT: 5px"><asp:Label id="Label7" runat="server" Width="78px" Text="Fecha Vencimiento" __designer:wfdid="w398"></asp:Label></TD><TD style="WIDTH: 96px; HEIGHT: 5px"><asp:TextBox id="TxtFVen" runat="server" __designer:wfdid="w399"></asp:TextBox></TD><TD style="WIDTH: 100px; HEIGHT: 5px"><asp:RequiredFieldValidator id="RequiredFieldValidator7" runat="server" __designer:wfdid="w400" ControlToValidate="TxtFVen" ErrorMessage="Digite Fecha Limite de Declaración del Periodo">*</asp:RequiredFieldValidator></TD></TR><TR><TD style="WIDTH: 98px"></TD><TD style="WIDTH: 96px"></TD><TD style="WIDTH: 100px"></TD></TR><TR><TD style="WIDTH: 98px; HEIGHT: 21px"></TD><TD style="WIDTH: 96px; HEIGHT: 21px"></TD><TD style="WIDTH: 100px; HEIGHT: 21px"></TD></TR><TR><TD style="WIDTH: 98px"></TD><TD style="WIDTH: 96px"></TD><TD style="WIDTH: 100px"></TD></TR><TR><TD style="HEIGHT: 21px; TEXT-ALIGN: center" colSpan=3><asp:Button id="BtnGuardar" onclick="BtnGuardar_Click" runat="server" Text="Guardar" __designer:wfdid="w401"></asp:Button>&nbsp;<asp:Button id="BtnEliminar" onclick="BtnEliminar_Click" runat="server" Text="Eliminar" __designer:wfdid="w402"></asp:Button>&nbsp; <INPUT id="BtnCancelar" type=button value="Cancelar" /> </TD></TR></TBODY></TABLE>&nbsp; <ajaxToolkit:CalendarExtender id="CalendarExtender3" runat="server" __designer:wfdid="w403" TargetControlID="TxtFecIni"></ajaxToolkit:CalendarExtender> <ajaxToolkit:CalendarExtender id="CalendarExtender4" runat="server" __designer:wfdid="w404" TargetControlID="TxtFecFin"></ajaxToolkit:CalendarExtender> <ajaxToolkit:CalendarExtender id="CalendarExtender1" runat="server" __designer:wfdid="w405" TargetControlID="TXTFVEN"></ajaxToolkit:CalendarExtender></asp:Panel>&nbsp;&nbsp; <BR />
</contenttemplate>
        <triggers>
<asp:AsyncPostBackTrigger ControlID="BtnFiltrar" EventName="Click"></asp:AsyncPostBackTrigger>
</triggers>
    </asp:UpdatePanel>&nbsp;
    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<br />
    <asp:UpdateProgress id="UpdateProgress1" runat="server" AssociatedUpdatePanelID="UpdatePanel1">
        <progresstemplate>
            <div class="Loading">
            <img src="../../images/loading.gif" alt="" title="" /> Cargando …
            </div>
        </progresstemplate>
    </asp:UpdateProgress><br />
</div>

</asp:Content>

