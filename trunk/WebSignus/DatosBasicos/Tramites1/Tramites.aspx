<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="Tramites.aspx.vb" Inherits="DatosBasicos_Tramites1_Tramites" title="Untitled Page" %>
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
&nbsp;<asp:Label id="Tit" runat="server" Width="286px" Text="Tramites" CssClass="Titulo"></asp:Label><BR /><asp:Label id="MsgResult" runat="server"></asp:Label>&nbsp;&nbsp;&nbsp;<BR />&nbsp;<asp:GridView id="GridView1" runat="server" Width="258px" ForeColor="#333333" OnRowDataBound="GridView1_RowDataBound1" AllowPaging="True" DataSourceID="Objtram" GridLines="None" CellPadding="4" ShowFooter="True" OnRowCommand="GridView1_RowCommand" DataKeyNames="TRAM_CODI" AutoGenerateColumns="False" OnSelectedIndexChanged="GridView1_SelectedIndexChanged" EmptyDataText="No se encontraron Registros en la Base de Datos" AllowSorting="True" PageSize="20">
<RowStyle BackColor="#F7F6F3" ForeColor="#333333"></RowStyle>
<Columns>
<asp:TemplateField HeaderText="C&#243;digo" SortExpression="TRAM_CODI"><FooterTemplate>
<asp:LinkButton id="lnkNuevo" runat="server" Text="Nuevo Registro" CausesValidation="False" CommandName="Nuevo" __designer:wfdid="w28"></asp:LinkButton> 
</FooterTemplate>
<ItemTemplate>
<asp:Label id="LbCodi" runat="server" Text='<%# Bind("TRAM_CODI") %>' __designer:wfdid="w27"></asp:Label> 
</ItemTemplate>
</asp:TemplateField>
<asp:TemplateField HeaderText="Nombre del Tramite  " SortExpression="TRAM_NOMB"><ItemTemplate>
<asp:Label id="Lbnomb" runat="server" Text='<%# Bind("TRAM_NOMB") %>' __designer:wfdid="w29"></asp:Label> 
</ItemTemplate>
</asp:TemplateField>
<asp:TemplateField HeaderText="Genera Sancion" SortExpression="TRAM_GSAN"><ItemTemplate>
<asp:Label id="Lbgsan" runat="server" Text='<%# Bind("TRAM_GSAN") %>' __designer:wfdid="w31"></asp:Label> 
</ItemTemplate>
</asp:TemplateField>
<asp:TemplateField HeaderText="Codigo de la Sancion" SortExpression="TRAM_COSA"><ItemTemplate>
<asp:Label id="Lbcosa" runat="server" Text='<%# Bind("TRAM_COSA") %>' __designer:wfdid="w32"></asp:Label> 
</ItemTemplate>
</asp:TemplateField>
    <asp:BoundField DataField="TIDO_NOMB" HeaderText="Documento" />
    <asp:BoundField DataField="TRAM_DIAS" HeaderText="Dias" />
    <asp:BoundField DataField="TRAM_TIPO" HeaderText="Clase" />
<asp:TemplateField HeaderText="Plantilla" SortExpression="TRAM_PLAN"><ItemTemplate>
<asp:Label id="Lbplan" runat="server" Text='<%# Bind("TRAM_PLAN") %>' __designer:wfdid="w33"></asp:Label> 
</ItemTemplate>
</asp:TemplateField>
<asp:TemplateField HeaderText="Proceso" SortExpression="PROC_NOMB"><ItemTemplate>
<asp:Label id="Lbproc" runat="server" Text='<%# Bind("PROC_NOMB") %>' __designer:wfdid="w34"></asp:Label> 
</ItemTemplate>
</asp:TemplateField>
<asp:TemplateField HeaderText="Responsable" SortExpression="TPRO_NOMB"><ItemTemplate>
<asp:Label id="Lbresp" runat="server" Text='<%# Bind("TPRO_NOMB") %>' __designer:wfdid="w26"></asp:Label> 
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
</asp:GridView> <asp:ObjectDataSource id="Objtram" runat="server" TypeName="Tramites" SelectMethod="GetRecords"></asp:ObjectDataSource><!-- <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White"></FooterStyle>-->&nbsp; <asp:HiddenField id="Oper" runat="server"></asp:HiddenField>&nbsp;<asp:HiddenField id="HdPk1" runat="server"></asp:HiddenField>&nbsp;&nbsp;<BR />&nbsp;&nbsp;<BR />
</contenttemplate>
    </asp:UpdatePanel>&nbsp;
    &nbsp;&nbsp;&nbsp;&nbsp;<asp:UpdatePanel id="UpdatePanel2"
        runat="server"><contenttemplate>
<!-- Mensaje de Salida--><BR /><asp:Button style="DISPLAY: none" id="hiddenTargetControlForModalPopup2" runat="server"></asp:Button> <ajaxToolkit:ModalPopupExtender id="ModalPopupTer" runat="server" PopupDragHandleControlID="programmaticPopupDragHandle2" PopupControlID="programmaticPopup2" DropShadow="True" BackgroundCssClass="modalBackground" BehaviorID="programmaticModalPopupBehavior2" RepositionMode="RepositionOnWindowScroll" TargetControlID="hiddenTargetControlForModalPopup2">
            </ajaxToolkit:ModalPopupExtender>&nbsp;&nbsp; <asp:Panel id="programmaticPopup2" runat="server" Width="660px" Height="500px" CssClass="ModalPanel2"><asp:Panel id="programmaticPopupDragHandle2" runat="Server" Width="655px" Height="30px" CssClass="BarTitleModal2"><DIV style="PADDING-RIGHT: 5px; PADDING-LEFT: 5px; PADDING-BOTTOM: 5px; VERTICAL-ALIGN: middle; PADDING-TOP: 5px"><DIV style="FLOAT: left">Tramites</DIV><DIV style="FLOAT: right"><INPUT id="BtnCerrar" type=button value="X" /></DIV></DIV></asp:Panel>
                &nbsp;<TABLE><TBODY>
        <TR><TD colSpan=3>
            <asp:Label id="SubT" runat="server" Text="Nuevo" CssClass="SubTitulo"></asp:Label></TD></TR><TR>
            <TD colSpan=3><asp:ValidationSummary id="ValidationSummary1" runat="server">
                    </asp:ValidationSummary></TD></TR>
        <TR><TD style="WIDTH: 98px">Código</TD>
            <TD style="WIDTH: 100px"><asp:TextBox ID="TxtCodiNew" runat="server"></asp:TextBox></TD>
            <TD style="WIDTH: 100px">
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
                    ControlToValidate="TxtCodiNew" ErrorMessage="Digite un Codigo">*</asp:RequiredFieldValidator></TD></TR>
        <TR><TD style="WIDTH: 98px; HEIGHT: 23px"><asp:Label id="Label1" runat="server" Width="126px" Text="Nombre del Tramite"></asp:Label></TD>
            <TD style="WIDTH: 100px; HEIGHT: 23px">
                <asp:TextBox ID="txtnombNew" runat="server" TextMode="MultiLine" Width="243px"></asp:TextBox></TD>
            <TD style="WIDTH: 100px; HEIGHT: 23px">
                <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" 
                    ControlToValidate="txtnombNew" ErrorMessage="Digite un Nombre">*</asp:RequiredFieldValidator></TD></TR>
        <TR><TD style="WIDTH: 98px; HEIGHT: 18px"><asp:Label id="Label2" runat="server" Width="117px" Text="Responsable"></asp:Label></TD>
            <TD style="WIDTH: 100px; HEIGHT: 18px">
                <asp:TextBox ID="txtrespNew" runat="server"></asp:TextBox></TD>
            <TD style="WIDTH: 100px; HEIGHT: 18px">
                <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" 
                    ControlToValidate="txtrespNew" ErrorMessage="Digite Responsable">*</asp:RequiredFieldValidator></TD></TR>
        <TR><TD style="WIDTH: 98px; HEIGHT: 19px"><asp:Label id="Label3" runat="server" Text="Genera Sancion"></asp:Label></TD>
            <TD style="WIDTH: 100px; HEIGHT: 19px">
                <asp:TextBox ID="txtgsanNew" runat="server"></asp:TextBox></TD>
            <TD style="WIDTH: 100px; HEIGHT: 19px">
                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" 
                    ControlToValidate="txtgsanNew" ErrorMessage="Digite Sancion">*</asp:RequiredFieldValidator></TD></TR>
        <TR>
            <td style="WIDTH: 98px">
            <asp:Label ID="Label4" runat="server" Text="Codigo de la Sancion" Width="109px"></asp:Label></td><TD style="WIDTH: 100px">
                <asp:TextBox ID="txtcosaNew" runat="server"></asp:TextBox></TD>
            <td style="WIDTH: 100px">
                <asp:RequiredFieldValidator ID="RequiredFieldValidator13" runat="server" 
                    ControlToValidate="txtcosaNew" ErrorMessage="*"></asp:RequiredFieldValidator>
            </td></TR>
        <tr><td style="WIDTH: 98px">
            <asp:Label ID="Label5" runat="server" __designer:wfdid="w20" Text="Plantilla" 
                Width="109px"></asp:Label></td>
            <td style="WIDTH: 100px">
                <asp:TextBox ID="txtplanNew" runat="server" __designer:wfdid="w18"></asp:TextBox></td>
            <td style="WIDTH: 100px">
                &#160;</td></tr>
        <tr><td style="WIDTH: 98px">
            Tipo de Proceso</td>
            <td style="WIDTH: 100px">
                <asp:DropDownList ID="cmbTipoProc" runat="server" DataSourceID="odsTipoProceso" 
                    DataTextField="TPRO_NOMB" DataValueField="TPRO_CODI">
                </asp:DropDownList>
            </td>
            <td style="WIDTH: 100px">
                &#160;</td></tr>
        <TR><TD style="WIDTH: 98px">
            <asp:Label id="Label6" runat="server" Width="109px" Text="Proceso del Tramite" 
                        __designer:wfdid="w21"></asp:Label></TD>
            <TD style="WIDTH: 100px">
                <asp:DropDownList ID="cmbProceso" runat="server" DataSourceID="odsProcesos" 
                        DataTextField="PROC_NOMB" DataValueField="PROC_CODI">
                    </asp:DropDownList>
            </TD>
            <TD style="WIDTH: 100px">
                <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" 
                    __designer:wfdid="w23" ControlToValidate="cmbProceso" 
                    ErrorMessage="Escoja un Tramite">*</asp:RequiredFieldValidator></TD></TR>
        <TR><TD style="WIDTH: 98px">Tipo de 
            Documento</TD>
            <TD style="WIDTH: 100px">
                <asp:DropDownList ID="cmbTipoDoc" runat="server" DataSourceID="odsTipoDoc" 
                        DataTextField="TIDO_NOMB" DataValueField="TIDO_CODI" Width="220px">
                    </asp:DropDownList>
            </TD><td style="WIDTH: 100px">
                <asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server" 
                            ControlToValidate="cmbTipoDoc" ErrorMessage="Escoja un Tipo de Documento">*</asp:RequiredFieldValidator>
            </td>
            </TR>
        <TR>
            <TD style="WIDTH: 100px">Generar Consecutivo</TD>
            <td style="WIDTH: 100px">
                <asp:DropDownList ID="cmbManual" runat="server">
                    <asp:ListItem Value="S">Si</asp:ListItem>
                    <asp:ListItem Value="N">No</asp:ListItem>
                </asp:DropDownList>
            </td>
            <TD style="WIDTH: 100px">
                <asp:RequiredFieldValidator ID="RequiredFieldValidator9" runat="server" 
                        ControlToValidate="cmbManual" ErrorMessage="Consecutivo Manual">*</asp:RequiredFieldValidator>
            </TD></TR>
        <tr>
            <td style="WIDTH: 98px">Dias de duración</td>
            <td style="WIDTH: 100px">
            <asp:TextBox ID="tbDiasTramite" runat="server"></asp:TextBox>
            </td><td style="WIDTH: 100px">
                <asp:RequiredFieldValidator ID="RequiredFieldValidator10" runat="server" 
                    ControlToValidate="tbDiasTramite" 
                    ErrorMessage="Escriba los dias de duracion del tramite">*</asp:RequiredFieldValidator>
            </td></tr>
        <tr>
            <td style="WIDTH: 98px">Tipo Calendario</td>
            <td style="WIDTH: 100px">
                <asp:DropDownList ID="cmbCalendario" runat="server">
                    <asp:ListItem Value="C">Calendario</asp:ListItem>
                    <asp:ListItem Value="H">Habiles</asp:ListItem>
                </asp:DropDownList>
            </td><td style="WIDTH: 100px">
                <asp:RequiredFieldValidator ID="RequiredFieldValidator11" runat="server" 
                    ControlToValidate="cmbCalendario" 
                    ErrorMessage="Escoja el Tipo de Calendario">*</asp:RequiredFieldValidator>
            </td></tr>
        <tr>
            <td style="WIDTH: 98px">Fecha de Recibido</td>
            <td style="WIDTH: 100px">
                <asp:DropDownList ID="cmbFechaRec" runat="server">
                    <asp:ListItem Value="S">Si</asp:ListItem>
                    <asp:ListItem Value="N">No</asp:ListItem>
                </asp:DropDownList>
            </td><td style="WIDTH: 100px">
                <asp:RequiredFieldValidator ID="RequiredFieldValidator12" runat="server" 
                    ControlToValidate="cmbFechaRec" ErrorMessage="Tramite debe ser recibido">*</asp:RequiredFieldValidator>
            </td></tr>
        <tr>
            <td style="WIDTH: 98px">&#160;</td>
            <td style="WIDTH: 100px">&#160;</td>
            <td style="WIDTH: 100px">&#160;</td></tr>
        <TR>
            <TD style="text-align: center;" colspan="3">
                <asp:Button ID="BtnGuardar" runat="server" Text="Guardar"></asp:Button>&#160;<asp:Button 
                        ID="BtnEliminar" runat="server" onclick="BtnEliminar_Click" Text="Eliminar">
                    </asp:Button>&#160; <input id="BtnCancelar" type="button" value="Cancelar" /> </TD></TR></TBODY></TABLE>
                &nbsp;
                <asp:ObjectDataSource ID="odsTipoProceso" runat="server" 
                    OldValuesParameterFormatString="original_{0}" SelectMethod="GetRecords" 
                    TypeName="tipo_proceso"></asp:ObjectDataSource>
                <asp:ObjectDataSource ID="odsProcesos" runat="server" 
                    OldValuesParameterFormatString="original_{0}" 
                    SelectMethod="GetProcesoHabilitados" TypeName="Procesos">
                </asp:ObjectDataSource>
                <asp:ObjectDataSource 
                    ID="odsTipoDoc" runat="server" 
                    OldValuesParameterFormatString="original_{0}" SelectMethod="GetRecords" 
                    TypeName="TIPO_DOC"></asp:ObjectDataSource>

            </asp:Panel>&nbsp;&nbsp; 
</contenttemplate>
    </asp:UpdatePanel><br />
</div>

</asp:Content>

