<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="Parametros.aspx.vb" Inherits="DatosBasicos_Parametros_Parametros" title="Untitled Page" UICulture="auto" Culture="auto" %>
<asp:Content ID="Content1" ContentPlaceHolderID="SampleContent" Runat="Server">
 <script type='text/javascript'>
        // Add click handlers for buttons to show and hide modal popup on pageLoad
        function pageLoad() {
            //$addHandler($get("showModalPopupClientButton"), 'click', showModalPopupViaClient);
            //$addHandler($get("hideModalPopupViaClientButton"), 'click', hideModalPopupViaClient);        
            $addHandler($get("BtnCerrar"), 'click', CerrarModalTercero);        
            $addHandler($get("BtnClosePar"), 'click', CerrarModalparametros);        
            
        }
        
         function CerrarModalTercero(ev) {
            ev.preventDefault();        
            var modalPopupBehavior2 = $find('programmaticModalPopupBehavior2');
            modalPopupBehavior2.hide();
            
        }function CerrarModalparametros(ev) {
            ev.preventDefault();        
            var modalPopupBehavior3 = $find('programmaticModalPopupBehavior3');
            modalPopupBehavior3.hide();
        }
        function esDigito(sChr){
var sCod = sChr.charCodeAt(0);
return ((sCod > 47) && (sCod < 58));
}

function valSep(oTxt){
var bOk = false;
bOk = bOk || ((oTxt.value.charAt(2) == "-") && (oTxt.value.charAt(5) == "-"));
bOk = bOk || ((oTxt.value.charAt(2) == "/") && (oTxt.value.charAt(5) == "/"));
return bOk;
}

function finMes(oTxt){
var nMes = parseInt(oTxt.value.substr(3, 2), 10);
var nRes = 0;
switch (nMes){
case 1: nRes = 31; break;
case 2: nRes = 29; break;
case 3: nRes = 31; break;
case 4: nRes = 30; break;
case 5: nRes = 31; break;
case 6: nRes = 30; break;
case 7: nRes = 31; break;
case 8: nRes = 31; break;
case 9: nRes = 30; break;
case 10: nRes = 31; break;
case 11: nRes = 30; break;
case 12: nRes = 31; break;
}
return nRes;
}

function valDia(oTxt){
var bOk = false;
var nDia = parseInt(oTxt.value.substr(0, 2), 10);
bOk = bOk || ((nDia >= 1) && (nDia <= finMes(oTxt)));
return bOk;
}

function valMes(oTxt){
var bOk = false;
var nMes = parseInt(oTxt.value.substr(3, 2), 10);
bOk = bOk || ((nMes >= 1) && (nMes <= 12));
return bOk;
}

function valAno(oTxt){
var bOk = true;
var nAno = oTxt.value.substr(6);
bOk = bOk && ((nAno.length == 2) || (nAno.length == 4));
if (bOk){
for (var i = 0; i < nAno.length; i++){
bOk = bOk && esDigito(nAno.charAt(i));
}
}
return bOk;
}

function valFecha(oTxt){
var bOk = true;
if (oTxt.value != ""){
bOk = bOk && (valAno(oTxt));
bOk = bOk && (valMes(oTxt));
bOk = bOk && (valDia(oTxt));
bOk = bOk && (valSep(oTxt));
if (!bOk){
/*alert("Fecha inválida");*/
}
}
return bOk;
}

function ValIsFecha (source, arguments){
      
         if(valFecha(document.aspnetForm.<%=Me.Txtfecini.ClientID%>)==true  &&  valFecha(document.aspnetForm.<%=Me.TxtFecFin.ClientID%>)==true) 
          {
            arguments.IsValid=true;
            return;
           }
           else
           {
             arguments.IsValid=false; 
              /*alert("fecha_ Invalida");*/
              return;
            }
          }
function BtnCerrar_onclick() {

}

</script>
        
        
<div class="demoarea">
    &nbsp;
    <ajaxToolkit:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server" EnableScriptGlobalization="true"
        EnableScriptLocalization="true">
    </ajaxToolkit:ToolkitScriptManager>
    <br />
    &nbsp;&nbsp;
    <asp:Label ID="Tit" runat="server" CssClass="Titulo" Text="CONFIGURACION DE PARAMETROS"
        Width="345px"></asp:Label>
    <asp:UpdatePanel id="UpdatePanel1" runat="server">
        <contenttemplate>
<asp:Label id="MsgResult" runat="server"></asp:Label> <BR /><asp:LinkButton id="Newpar" onclick="Newpar_Click" runat="server" __designer:wfdid="w36">Nuevo Parametro</asp:LinkButton><BR /><asp:GridView id="GridView1" runat="server" __designer:dtid="1125899906842632" __designer:wfdid="w11" AllowSorting="True" AutoGenerateColumns="False" DataKeyNames="Código" DataSourceID="ObjPar" OnRowCommand="GridView1_RowCommand" OnRowDataBound="GridView1_RowDataBound" OnSelectedIndexChanged="GridView1_SelectedIndexChanged" AllowPaging="True"><Columns __designer:dtid="1125899906842633">
<asp:BoundField DataField="C&#243;digo" HeaderText="C&#243;digo" SortExpression="C&#243;digo" __designer:dtid="1125899906842634"></asp:BoundField>
<asp:BoundField DataField="Nombre" HeaderText="Nombre" SortExpression="Nombre" __designer:dtid="1125899906842635"></asp:BoundField>
<asp:BoundField DataField="Tipo de Dato" HeaderText="Tipo de Dato" SortExpression="Tipo de Dato" __designer:dtid="1125899906842636"></asp:BoundField>
<asp:BoundField DataField="Estado" HeaderText="Estado" SortExpression="Estado" __designer:dtid="1125899906842637"></asp:BoundField>
<asp:BoundField DataField="Descripci&#243;n" HeaderText="Descripci&#243;n" SortExpression="Descripci&#243;n" __designer:dtid="1125899906842638"></asp:BoundField>
<asp:ButtonField CommandName="Eliminar" ImageUrl="~/images/Operaciones/delete2.png" Text="Eliminar" ButtonType="Image" __designer:dtid="1125899906842639"></asp:ButtonField>
<asp:ButtonField CommandName="Editar" ImageUrl="~/images/Operaciones/Edit2.png" Text="Editar" ButtonType="Image" __designer:dtid="1125899906842640"></asp:ButtonField>
<asp:CommandField SelectImageUrl="~/images/Operaciones/Select.png" SelectText="Seleccionar" ShowSelectButton="True" ButtonType="Image" __designer:dtid="1125899906842641"></asp:CommandField>
</Columns>
</asp:GridView> <asp:ObjectDataSource id="ObjPar" runat="server" SelectMethod="GetRecords" TypeName="Parametros">
    </asp:ObjectDataSource> <asp:HiddenField id="OperPar" runat="server" __designer:wfdid="w33"></asp:HiddenField> 
<HR />
&nbsp;<asp:Label id="Label1" runat="server" Width="134px" Font-Bold="True" Text="LISTA DE VALORES" __designer:dtid="844424930132004" CssClass="TitDecl" __designer:wfdid="w18"></asp:Label><BR /><asp:LinkButton id="LinkButton1" onclick="LinkButton1_Click" runat="server" __designer:wfdid="w3">Nuevo Valor por Periodo</asp:LinkButton><BR /><asp:GridView id="GridView2" runat="server" Width="643px" __designer:dtid="1125899906842642" __designer:wfdid="w12" AutoGenerateColumns="False" DataKeyNames="PALI_PLCO,PALI_COID" DataSourceID="ObjValores" OnRowCommand="GridView2_RowCommand" OnRowDataBound="GridView2_RowDataBound" AllowPaging="True">
        <Columns __designer:dtid="1125899906842643">
            <asp:TemplateField __designer:dtid="1125899906842644" HeaderText="C&#243;digo del Parametro" SortExpression="PALI_PLCO">
                <EditItemTemplate __designer:dtid="1125899906842645">
                    <asp:TextBox __designer:dtid="1125899906842646" ID="TextBox1" runat="server" Text='<%# Bind("PALI_PLCO") %>'></asp:TextBox>
                </EditItemTemplate>
                <ItemTemplate __designer:dtid="1125899906842647">
                    <asp:Label __designer:dtid="1125899906842648" ID="Label1" runat="server" Text='<%# Bind("PALI_PLCO") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField __designer:dtid="1125899906842649" HeaderText="Item" SortExpression="PALI_COID">
                <EditItemTemplate __designer:dtid="1125899906842650">
                    <asp:TextBox __designer:dtid="1125899906842651" ID="TextBox2" runat="server" Text='<%# Bind("PALI_COID") %>'></asp:TextBox>
                </EditItemTemplate>
                <HeaderTemplate __designer:dtid="1125899906842652">
                    <table __designer:dtid="1125899906842653">
                        <tr __designer:dtid="1125899906842654">
                            <td __designer:dtid="1125899906842655" colspan="1">
                                Item&nbsp;</td>
                        </tr>
                        <tr __designer:dtid="1125899906842656">
                            <td __designer:dtid="1125899906842657">
                                <asp:TextBox __designer:dtid="1125899906842658" ID="TxtItem" runat="server" Width="49px"></asp:TextBox>
                            </td>
                        </tr>
                    </table>
                </HeaderTemplate>
                <ItemTemplate __designer:dtid="1125899906842659">
                    <asp:Label __designer:dtid="1125899906842660" ID="Label2" runat="server" Text='<%# Bind("PALI_COID") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField __designer:dtid="1125899906842661" HeaderText="Fecha Inicial" SortExpression="PALI_FEIN">
                <EditItemTemplate __designer:dtid="1125899906842662">
                    <asp:TextBox __designer:dtid="1125899906842663" ID="TextBox3" runat="server" Text='<%# Bind("PALI_FEIN") %>'></asp:TextBox>
                </EditItemTemplate>
                <HeaderTemplate __designer:dtid="1125899906842664">
                    <table __designer:dtid="1125899906842665">
                        <tr __designer:dtid="1125899906842666">
                            <td __designer:dtid="1125899906842667" colspan="1">
                                Fecha Inicial
                            </td>
                        </tr>
                        <tr __designer:dtid="1125899906842668">
                            <td __designer:dtid="1125899906842669">
                                <asp:TextBox __designer:dtid="1125899906842670" ID="TxtFeIn" runat="server"></asp:TextBox>
                            </td>
                        </tr>
                    </table>
                </HeaderTemplate>
                <ItemTemplate __designer:dtid="1125899906842671">
                    <asp:Label __designer:dtid="1125899906842672" ID="Label3" runat="server" Text='<%# Bind("PALI_FEIN", "{0:d}") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField __designer:dtid="1125899906842673" HeaderText="Fecha Final" SortExpression="PALI_FEFI">
                <EditItemTemplate __designer:dtid="1125899906842674">
                    <asp:TextBox __designer:dtid="1125899906842675" ID="TextBox4" runat="server" Text='<%# Bind("PALI_FEFI") %>'></asp:TextBox>
                </EditItemTemplate>
                <HeaderTemplate __designer:dtid="1125899906842676">
                    <table __designer:dtid="1125899906842677">
                        <tr __designer:dtid="1125899906842678">
                            <td __designer:dtid="1125899906842679" colspan="1">
                                Fecha Final</td>
                        </tr>
                        <tr __designer:dtid="1125899906842680">
                            <td __designer:dtid="1125899906842681" style="width: 125px">
                                <asp:TextBox __designer:dtid="1125899906842682" ID="TxtFeFi" runat="server"></asp:TextBox>
                            </td>
                        </tr>
                    </table>
                </HeaderTemplate>
                <ItemTemplate __designer:dtid="1125899906842683">
                    <asp:Label __designer:dtid="1125899906842684" ID="Label4" runat="server" Text='<%# Bind("PALI_FEFI", "{0:d}") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField __designer:dtid="1125899906842685" HeaderText="Valor" SortExpression="PALI_VALO">
                <EditItemTemplate __designer:dtid="1125899906842686">
                    <asp:TextBox __designer:dtid="1125899906842687" ID="TextBox5" runat="server" Text='<%# Bind("PALI_VALO") %>'></asp:TextBox>
                </EditItemTemplate>
                <HeaderTemplate __designer:dtid="1125899906842688">
                    <table __designer:dtid="1125899906842689">
                        <tr __designer:dtid="1125899906842690">
                            <td __designer:dtid="1125899906842691" colspan="2">
                                Valor</td>
                        </tr>
                        <tr __designer:dtid="1125899906842692">
                            <td __designer:dtid="1125899906842693">
                                <asp:TextBox __designer:dtid="1125899906842694" ID="TxtValo" runat="server"></asp:TextBox>
                            </td>
                            <td __designer:dtid="1125899906842695" style="width: 6px">
                                &nbsp;</td>
                        </tr>
                    </table>
                </HeaderTemplate>
                <ItemTemplate __designer:dtid="1125899906842696">
                    <asp:Label __designer:dtid="1125899906842697" ID="Label5" runat="server" Text='<%# Bind("PALI_VALO") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField __designer:dtid="1125899906842698" HeaderText="Clase de Impuesto" SortExpression="Par_Dec">
                <EditItemTemplate __designer:dtid="1125899906842699">
                    <asp:TextBox __designer:dtid="1125899906842700" ID="TextBox6" runat="server" Text='<%# Bind("Par_Dec") %>'></asp:TextBox>
                </EditItemTemplate>
                <HeaderTemplate __designer:dtid="1125899906842701">
                    <table __designer:dtid="1125899906842702">
                        <tr __designer:dtid="1125899906842703">
                            <td __designer:dtid="1125899906842704" colspan="1">
                                Clase</td>
                            <td __designer:dtid="1125899906842705" colspan="1" style="width: 3px">
                            </td>
                            <td __designer:dtid="1125899906842706" colspan="1">
                            </td>
                        </tr>
                        <tr __designer:dtid="1125899906842707">
                            <td __designer:dtid="1125899906842708">
                                <asp:TextBox __designer:dtid="1125899906842709" ID="TxtDec" runat="server" ValidationGroup="00 -> Todos" Width="48px"></asp:TextBox>
                            </td>
                            <td __designer:dtid="1125899906842710" style="width: 3px">
                                <asp:Button __designer:dtid="1125899906842711" ID="Button1" runat="server" OnClick="btnFiltrar_Click" Text="+"  /></td>
                            <td __designer:dtid="1125899906842712">
                                <asp:Button __designer:dtid="1125899906842713" ID="Filtrar" runat="server" OnClick="btnQFiltrar_Click" Text="-" ToolTip="Quitar Filtro"  /></td>
                        </tr>
                    </table>
                </HeaderTemplate>
                <ItemTemplate __designer:dtid="1125899906842714">
                    <asp:Label __designer:dtid="1125899906842715" ID="Label6" runat="server" Text='<%# Bind("Par_Dec") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField __designer:dtid="1125899906842716" HeaderText="Valor N&#250;mero" SortExpression="Pali_Vanu" Visible="False">
                <EditItemTemplate __designer:dtid="1125899906842717">
                    <asp:TextBox __designer:dtid="1125899906842718" ID="TextBox7" runat="server" Text='<%# Bind("Pali_vanu") %>'></asp:TextBox>
                </EditItemTemplate>
                <ItemTemplate __designer:dtid="1125899906842719">
                    <asp:Label __designer:dtid="1125899906842720" ID="Label7" runat="server" Text='<%# Bind("Pali_vanu", "{0:c}") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField __designer:dtid="1125899906842721" HeaderText="Valor Dato" SortExpression="Pali_Vada" Visible="False">
                <EditItemTemplate __designer:dtid="1125899906842722">
                    <asp:TextBox __designer:dtid="1125899906842723" ID="TextBox8" runat="server" Text='<%# Bind("Pali_Vada") %>'></asp:TextBox>
                </EditItemTemplate>
                <ItemTemplate __designer:dtid="1125899906842724">
                    <asp:Label __designer:dtid="1125899906842725" ID="Label8" runat="server" Text='<%# Bind("Pali_Vada", "{0:d}") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField __designer:dtid="1125899906842726" HeaderText="Usuario App" SortExpression="Pali_UsAp" Visible="False">
                <EditItemTemplate __designer:dtid="1125899906842727">
                    <asp:TextBox __designer:dtid="1125899906842728" ID="TextBox9" runat="server" Text='<%# Bind("Pali_UsAp") %>'></asp:TextBox>
                </EditItemTemplate>
                <ItemTemplate __designer:dtid="1125899906842729">
                    <asp:Label __designer:dtid="1125899906842730" ID="Label9" runat="server" Text='<%# Bind("Pali_UsAp") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField __designer:dtid="1125899906842731" HeaderText="Fecha Registro Sistema" SortExpression="PALI_FREG"
                Visible="False">
                <EditItemTemplate __designer:dtid="1125899906842732">
                    <asp:TextBox __designer:dtid="1125899906842733" ID="TextBox10" runat="server" Text='<%# Bind("PALI_FREG") %>'></asp:TextBox>
                </EditItemTemplate>
                <ItemTemplate __designer:dtid="1125899906842734">
                    <asp:Label __designer:dtid="1125899906842735" ID="Label10" runat="server" Text='<%# Bind("PALI_FREG") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField __designer:dtid="1125899906842736" HeaderText="Usuario BD" SortExpression="PALI_USBD" Visible="False">
                <EditItemTemplate __designer:dtid="1125899906842737">
                    <asp:TextBox __designer:dtid="1125899906842738" ID="TextBox11" runat="server" Text='<%# Bind("PALI_USBD") %>'></asp:TextBox>
                </EditItemTemplate>
                <ItemTemplate __designer:dtid="1125899906842739">
                    <asp:Label __designer:dtid="1125899906842740" ID="Label11" runat="server" Text='<%# Bind("PALI_USBD") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField __designer:dtid="1125899906842741" HeaderText="Fecha Novedad" SortExpression="PALI_FNOV" Visible="False">
                <EditItemTemplate __designer:dtid="1125899906842742">
                    <asp:TextBox __designer:dtid="1125899906842743" ID="TextBox12" runat="server" Text='<%# Bind("PALI_FNOV") %>'></asp:TextBox>
                </EditItemTemplate>
                <ItemTemplate __designer:dtid="1125899906842744">
                    <asp:Label __designer:dtid="1125899906842745" ID="Label12" runat="server" Text='<%# Bind("PALI_FNOV") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:ButtonField __designer:dtid="1125899906842746" ButtonType="Image" CommandName="Eliminar" ImageUrl="~/images/Operaciones/delete2.png"
                Text="Eliminar" ></asp:ButtonField>
            <asp:ButtonField __designer:dtid="1125899906842747" ButtonType="Image" CommandName="Editar" ImageUrl="~/images/Operaciones/Edit2.png"
                Text="Editar" ></asp:ButtonField>
            <asp:CommandField __designer:dtid="1125899906842748" ButtonType="Image" SelectImageUrl="~/images/Operaciones/Select.png"
                ShowSelectButton="True" ></asp:CommandField>
        </Columns>
    </asp:GridView><asp:HiddenField id="Oper" runat="server"></asp:HiddenField> <asp:HiddenField id="FValores" runat="server" __designer:wfdid="w46"></asp:HiddenField> <asp:ObjectDataSource id="ObjValores" runat="server" SelectMethod="GetValores" TypeName="Parametros" OldValuesParameterFormatString="original_{0}"><SelectParameters>
<asp:ControlParameter ControlID="GridView1" PropertyName="SelectedValue" Name="PALI_PLCO" Type="String"></asp:ControlParameter>
<asp:ControlParameter ControlID="FValores" PropertyName="Value" Name="Filtro" Type="String"></asp:ControlParameter>
</SelectParameters>
</asp:ObjectDataSource>&nbsp;<BR />
</contenttemplate>
    </asp:UpdatePanel>&nbsp; &nbsp;
    <asp:UpdatePanel id="UpdatePanel2" runat="server"><contenttemplate>
<!-- Mensaje de Salida--><BR /><asp:Button style="DISPLAY: none" id="hiddenTargetControlForModalPopup2" runat="server" __designer:wfdid="w74"></asp:Button> <ajaxToolkit:ModalPopupExtender id="ModalPopupTer" runat="server" __designer:wfdid="w75" TargetControlID="hiddenTargetControlForModalPopup2" RepositionMode="RepositionOnWindowScroll" BehaviorID="programmaticModalPopupBehavior2" BackgroundCssClass="modalBackground" DropShadow="True" PopupControlID="programmaticPopup2" PopupDragHandleControlID="programmaticPopupDragHandle2">
            </ajaxToolkit:ModalPopupExtender> <asp:Panel id="programmaticPopup2" runat="server" Width="347px" Height="380%" CssClass="ModalPanel2" __designer:wfdid="w76"><asp:Panel id="programmaticPopupDragHandle2" runat="Server" Width="341px" Height="30px" CssClass="BarTitleModal2" __designer:wfdid="w77"><DIV style="PADDING-RIGHT: 5px; PADDING-LEFT: 5px; PADDING-BOTTOM: 5px; VERTICAL-ALIGN: middle; PADDING-TOP: 5px"><DIV style="FLOAT: left">Valor&nbsp; por Periodo de Fecha</DIV><DIV style="FLOAT: right"><INPUT id="BtnCerrar" onclick="return BtnCerrar_onclick()" type=button value="X" /></DIV></DIV></asp:Panel><TABLE style="WIDTH: 351px"><TBODY><TR><TD style="HEIGHT: 33px" colSpan=3><asp:Label id="TituloPoup" runat="server" Text="Nuevo Registro" CssClass="SubTitulo" __designer:wfdid="w92">
            </asp:Label><BR /></TD></TR><TR><TD colSpan=3><asp:ValidationSummary id="ValidationSummary1" runat="server" __designer:dtid="562949953421322" __designer:wfdid="w1" ValidationGroup="Guardar">
            </asp:ValidationSummary></TD></TR><TR><TD style="WIDTH: 100px">Codigo del Parametro</TD><TD style="WIDTH: 102px"><asp:TextBox id="TxtPcod" runat="server" __designer:wfdid="w79" ReadOnly="True"></asp:TextBox></TD><TD style="WIDTH: 100px"></TD></TR><TR><TD style="WIDTH: 100px; HEIGHT: 20px">Código</TD><TD style="WIDTH: 102px; HEIGHT: 20px"><asp:TextBox id="Txtcod" runat="server" __designer:wfdid="w1"></asp:TextBox></TD><TD style="WIDTH: 100px; HEIGHT: 20px"></TD></TR><TR><TD style="WIDTH: 100px">Fecha de Inicio</TD><TD style="WIDTH: 102px"><asp:TextBox id="TxtFecIni" runat="server" __designer:wfdid="w81"></asp:TextBox></TD><TD style="WIDTH: 100px">&nbsp;<asp:CustomValidator id="CusValFini" runat="server" __designer:wfdid="w3" ValidationGroup="Guardar" ClientValidationFunction="ValIsFecha" ControlToValidate="TxtFecIni" ErrorMessage="Digite Una Fecha Inicial Valida">*</asp:CustomValidator></TD></TR><TR><TD style="WIDTH: 100px; HEIGHT: 21px">Fecha de Fin</TD><TD style="WIDTH: 102px; HEIGHT: 21px"><asp:TextBox id="TxtFecFin" runat="server" __designer:wfdid="w82"></asp:TextBox></TD><TD style="WIDTH: 100px; HEIGHT: 21px"><asp:CustomValidator id="CusValFfin" runat="server" __designer:wfdid="w5" ValidationGroup="Guardar" ClientValidationFunction="ValIsFecha" ControlToValidate="TxtFecFin" ErrorMessage="Digite Una Fecha Final Valida">*</asp:CustomValidator> <asp:CompareValidator id="CompareValidator1" runat="server" __designer:wfdid="w6" ValidationGroup="Guardar" ControlToValidate="TxtFecFin" ErrorMessage="La Fecha Inicial debe ser menor que la Final" Operator="GreaterThanEqual" ControlToCompare="TxtFecIni" SetFocusOnError="True">*</asp:CompareValidator></TD></TR><TR><TD style="WIDTH: 100px">Valor</TD><TD style="WIDTH: 102px"><asp:TextBox id="TxtVal" runat="server" __designer:wfdid="w83"></asp:TextBox></TD><TD style="WIDTH: 100px"></TD></TR><TR><TD style="WIDTH: 100px; HEIGHT: 23px">Par Declaracion</TD><TD style="WIDTH: 102px; HEIGHT: 23px"><asp:TextBox id="TxtPDec" runat="server" __designer:wfdid="w84"></asp:TextBox></TD><TD style="WIDTH: 100px; HEIGHT: 23px"></TD></TR><TR><TD style="HEIGHT: 85px; TEXT-ALIGN: center" colSpan=3><asp:Button id="BtnGuardar" onclick="BtnGuardar_Click" runat="server" Text="Guardar" __designer:wfdid="w85" ValidationGroup="Guardar"></asp:Button> <asp:Button id="BtnCancelar" runat="server" Text="Cancelar" __designer:wfdid="w86"></asp:Button></TD></TR></TBODY></TABLE><BR /><BR /><BR /></asp:Panel>&nbsp;&nbsp; <ajaxToolkit:CalendarExtender id="CalendarExtender2" runat="server" __designer:wfdid="w104" TargetControlID="TxtFecFin"> </ajaxToolkit:CalendarExtender> <ajaxToolkit:CalendarExtender id="CalendarExtender1" runat="server" __designer:wfdid="w103" TargetControlID="TxtFecIni">  </ajaxToolkit:CalendarExtender>
</contenttemplate>
    </asp:UpdatePanel><br />
    <br />
    <asp:UpdatePanel id="UpdatePanel3" runat="server"><contenttemplate>
<BR /><asp:Button style="DISPLAY: none" id="hiddenTargetControlForModalPopup3" runat="server" __designer:wfdid="w74"></asp:Button> <ajaxToolkit:ModalPopupExtender id="ModalPopupTer3" runat="server" __designer:wfdid="w75" TargetControlID="hiddenTargetControlForModalPopup3" RepositionMode="RepositionOnWindowScroll" BehaviorID="programmaticModalPopupBehavior3" BackgroundCssClass="modalBackground" DropShadow="True" PopupControlID="programmaticPopup3" PopupDragHandleControlID="programmaticPopupDragHandle3"></ajaxToolkit:ModalPopupExtender> <asp:Panel id="programmaticPopup3" runat="server" Width="347px" Height="468%" CssClass="ModalPanel2"><asp:Panel id="programmaticPopupDragHandle3" runat="Server" Height="30px" CssClass="BarTitleModal2"><DIV style="PADDING-RIGHT: 5px; PADDING-LEFT: 5px; PADDING-BOTTOM: 5px; VERTICAL-ALIGN: middle; PADDING-TOP: 5px"><DIV style="FLOAT: left">COnfiguración de Parametros </DIV><DIV style="FLOAT: right"><INPUT id="BtnClosePar" type=button value="X" /></DIV></DIV></asp:Panel> <BR /><TABLE><TBODY><TR><TD colSpan=3><asp:Label id="LbTiTpop2" runat="server" Text="Nuevo Registro" CssClass="SubTitulo" __designer:wfdid="w85"></asp:Label></TD></TR><TR><TD style="WIDTH: 100px">Código</TD><TD style="WIDTH: 100px"><asp:TextBox id="TxtCodP" runat="server" __designer:wfdid="w86"></asp:TextBox></TD><TD style="WIDTH: 100px"><asp:RequiredFieldValidator id="Valcod" runat="server" __designer:wfdid="w87" ValidationGroup="Guardar2" ControlToValidate="TxtCodP" ErrorMessage="Digite el Codigo del Parámetro">*</asp:RequiredFieldValidator></TD></TR><TR style="COLOR: #000000"><TD style="WIDTH: 100px">Nombre</TD><TD style="WIDTH: 100px"><asp:TextBox id="TxtNomP" runat="server" __designer:wfdid="w88"></asp:TextBox></TD><TD style="WIDTH: 100px"><asp:RequiredFieldValidator id="ValNom" runat="server" __designer:wfdid="w89" ValidationGroup="Guardar2" ControlToValidate="TxtNomP" ErrorMessage="Digite el Nombre del Parámetro">*</asp:RequiredFieldValidator></TD></TR><TR><TD style="WIDTH: 100px">Tipo de Dato</TD><TD style="WIDTH: 100px"><asp:DropDownList id="CboTD" runat="server" __designer:wfdid="w37"><asp:ListItem Value="C">Texto</asp:ListItem>
<asp:ListItem Value="N">N&#250;merico</asp:ListItem>
<asp:ListItem Value="D">Fecha</asp:ListItem>
</asp:DropDownList></TD><TD style="WIDTH: 100px"></TD></TR><TR><TD style="WIDTH: 100px">Estado</TD><TD style="WIDTH: 100px"><asp:DropDownList id="CboEst" runat="server" __designer:wfdid="w38"><asp:ListItem Value="AC">ACTIVO</asp:ListItem>
<asp:ListItem Value="IN">INACTIVO</asp:ListItem>
</asp:DropDownList></TD><TD style="WIDTH: 100px"></TD></TR><TR><TD style="WIDTH: 100px">Descripción</TD><TD style="WIDTH: 100px"><asp:TextBox id="TxtDescP" runat="server" Width="224px" Height="58px" __designer:wfdid="w94" TextMode="MultiLine"></asp:TextBox></TD><TD style="WIDTH: 100px"><asp:RequiredFieldValidator id="VAlDesc" runat="server" __designer:wfdid="w95" ValidationGroup="Guardar2" ControlToValidate="TxtDescP" ErrorMessage="Digite una descripcion del Parametro ">*</asp:RequiredFieldValidator></TD></TR><TR><TD style="TEXT-ALIGN: center" colSpan=3><asp:Button id="BtnGuardarN" onclick="BtnGuardarN_Click" runat="server" Text="Guardar" __designer:wfdid="w96" ValidationGroup="Guardar2"></asp:Button> <asp:Button id="BtnCancel" runat="server" Text="Cancelar" __designer:wfdid="w97"></asp:Button></TD></TR></TBODY></TABLE><BR /><BR /></asp:Panel>&nbsp; 
</contenttemplate>
    </asp:UpdatePanel><asp:UpdateProgress id="UpdateProgress1" runat="server" AssociatedUpdatePanelID="UpdatePanel1">
        <progresstemplate>
            <div class="Loading">
            <img src="../../images/loading.gif" alt="" title="" /> Cargando …
            </div>
        </progresstemplate>
    </asp:UpdateProgress>
    <br />
    &nbsp;
    <br />
    <br />
</div>
</asp:Content>

