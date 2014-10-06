<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false"
    CodeFile="FoDe.aspx.vb" Inherits="DatosBasicos_FoDe_FoDe" Title="Untitled Page"
    UICulture="auto" Culture="auto" %>

<asp:Content ID="Content1" ContentPlaceHolderID="SampleContent" runat="Server">
    <script type='text/javascript'>
        // Add click handlers for buttons to show and hide modal popup on pageLoad
        function pageLoad() {
            $addHandler($get("BtnCerrar"), 'click', CerrarModalTercero);        
            $addHandler($get("BtnCancelar1"), 'click', CerrarModalTercero);        
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
      
         if(valFecha(document.aspnetForm.<%=Me.TxtfeIn.ClientID%>)==true  &&  valFecha(document.aspnetForm.<%=Me.TxtFeFi.ClientID%>)==true) 
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
        <asp:Label ID="Tit" runat="server" CssClass="Titulo" Text="Configuración de Formularios de Declaración"
            Width="423px"></asp:Label>
        <hr />
        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
            <ContentTemplate>
                <asp:Label ID="MsgResult" runat="server"></asp:Label>&nbsp;<br />
                <asp:LinkButton ID="Newpar" OnClick="Newpar_Click" runat="server" 
                    >Nuevo Formulario</asp:LinkButton>&nbsp;
                <asp:GridView ID="GridView1" runat="server" 
                    AllowSorting="True" AutoGenerateColumns="False" DataKeyNames="Fode_Codi" DataSourceID="ObjFoDe"
                    OnRowCommand="GridView1_RowCommand" OnRowDataBound="GridView1_RowDataBound" OnSelectedIndexChanged="GridView1_SelectedIndexChanged">
                    <Columns>
                        <asp:BoundField DataField="Fode_Codi" HeaderText="C&#243;digo" SortExpression="Fode_Codi">
                        </asp:BoundField>
                        <asp:BoundField DataField="Fode_Cdec" HeaderText="C&#243;digo de Clase" SortExpression="Fode_Cdec">
                        </asp:BoundField>
                        <asp:BoundField DataField="Cld_Nom" HeaderText="Clase" SortExpression="Cld_Nom">
                        </asp:BoundField>
                        <asp:BoundField DataField="Fode_FeIn" DataFormatString="{0:d}" HeaderText="Fecha Inicial"
                            SortExpression="Fode_FeIn"></asp:BoundField>
                        <asp:BoundField DataField="Fode_FeFi" DataFormatString="{0:d}" HeaderText="Fecha Final"
                            SortExpression="Fode_FeFi"></asp:BoundField>
                        <asp:BoundField DataField="Fode_FoWe" HeaderText="Web" SortExpression="Fode_FoWe">
                        </asp:BoundField>
                        <asp:BoundField DataField="Fode_Rpte" HeaderText="Reporte"></asp:BoundField>
                        <asp:ButtonField ButtonType="Image" CommandName="Eliminar" ImageUrl="~/images/Operaciones/delete2.png"
                            Text="Eliminar"></asp:ButtonField>
                        <asp:ButtonField __designer:dtid="281474976710674" ButtonType="Image" CommandName="Editar"
                            ImageUrl="~/images/Operaciones/Edit2.png" Text="Editar"></asp:ButtonField>
                        <asp:CommandField __designer:dtid="281474976710675" ButtonType="Image" SelectImageUrl="~/images/Operaciones/Select.png"
                            SelectText="Seleccionar" ShowSelectButton="True"></asp:CommandField>
                    </Columns>
                </asp:GridView>
                <hr />
                <asp:Label ID="Label1" runat="server" Width="254px" Font-Bold="True" 
                    Text="RENGLONES DEL FORMULARIO" CssClass="TitDecl" ></asp:Label>
                <br />
                <asp:LinkButton ID="LinkButton1" OnClick="LinkButton1_Click" runat="server" >Nuevo Renglón</asp:LinkButton>
                <asp:GridView ID="GridView2" runat="server" Width="700px" 
                     AutoGenerateColumns="False" DataKeyNames="CoCd_Codi,Cocd_FdCo"
                    DataSourceID="ObjValores" OnRowCommand="GridView2_RowCommand" OnRowDataBound="GridView2_RowDataBound"
                    OnSelectedIndexChanged="GridView2_SelectedIndexChanged">
                    <Columns >
                        <asp:TemplateField HeaderText="C&#243;digo" SortExpression="COCD_CODI" >
                            
                            <HeaderTemplate >
                                <asp:Label ID="LbCod1" runat="server" >ID</asp:Label>
                            </HeaderTemplate>
                            <ItemTemplate >
                                <asp:Label ID="LbCod" runat="server" Text='<%# Bind("COCD_CODI") %>' ></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Concepto" SortExpression="COCD_NOMB" >
                            <HeaderTemplate >
                                <table >
                                    <tbody>
                                        <tr >
                                            <td >
                                                <asp:Label ID="Label10" runat="server" Text="Concepto"  ToolTip="Nombre del Concepto o Renglon"></asp:Label>
                                            </td>
                                        </tr>
                                        <tr >
                                            <td >
                                                <asp:TextBox ID="TxtNomb" runat="server" Width="211px" __designer:dtid="5066549580791845"
                                                   ></asp:TextBox>
                                            </td>
                                        </tr>
                                    </tbody>
                                </table>
                            </HeaderTemplate>
                            <ItemTemplate >
                                <asp:Label ID="Label2" runat="server" Text='<%# Bind("CoCd_Nomb") %>' 
                                    ></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="TiCo" SortExpression="CoCd_TiCo" >
                            <EditItemTemplate >
                                <asp:TextBox ID="TextBox3" runat="server" Text='<%# Bind("PALI_FEIN") %>' ></asp:TextBox>
                            </EditItemTemplate>
                            <HeaderTemplate >
                                <table >
                                    <tbody>
                                        <tr >
                                            <td style="width: 30px" colspan="1" >
                                                <asp:Label ID="Label13" runat="server" Width="51px" Text="TICO" ToolTip="Tipo Concepto"></asp:Label>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="width: 30px" >
                                                <asp:DropDownList ID="CboTico" runat="server" Width="56px" 
                                                     DataSourceID="ObjTiCo" DataValueField="TCon_Cod" DataTextField="TCon_Cod"
                                                    AppendDataBoundItems="True">
                                                    <asp:ListItem></asp:ListItem>
                                                </asp:DropDownList>
                                            </td>
                                        </tr>
                                    </tbody>
                                </table>
                            </HeaderTemplate>
                            <ItemTemplate >
                                <asp:Label ID="Label3" runat="server" Text='<%# Bind("CoCd_Tico") %>' ></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Impto" SortExpression="CoCd_Impto" >
                            <HeaderTemplate >
                                <table >
                                    <tbody>
                                        <tr >
                                            <td style="width: 59px" colspan="1" >
                                                <asp:Label ID="Label11" runat="server" Text="Impto" __designer:wfdid="w15" ToolTip="Impuesto Asociado"></asp:Label>
                                            </td>
                                        </tr>
                                        <tr >
                                            <td style="width: 59px">
                                                <asp:DropDownList ID="CboImpto" runat="server" Width="63px" 
                                                    OnSelectedIndexChanged="CboImpto_SelectedIndexChanged" DataSourceID="ObjImpto"
                                                    DataValueField="Imp_Cod" DataTextField="Imp_Cod" AppendDataBoundItems="True">
                                                    <asp:ListItem></asp:ListItem>
                                                </asp:DropDownList>
                                            </td>
                                        </tr>
                                    </tbody>
                                </table>
                            </HeaderTemplate>
                            <ItemTemplate >
                                <asp:Label ID="Label4" runat="server" Text='<%# Bind("CoCd_Impto") %>' ></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Seccion" >
                            <EditItemTemplate >
                                <asp:TextBox ID="TextBox5" runat="server" Text='<%# Bind("PALI_VALO") %>' 
                                    ></asp:TextBox>
                            </EditItemTemplate>
                            <HeaderTemplate >
                                <table >
                                    <tbody>
                                        <tr >
                                            <td style="width: 57px" colspan="1" >
                                                <asp:Label ID="Label12" runat="server" Text="Sección"  ToolTip="Sección en el Fomulario"></asp:Label>
                                            </td>
                                        </tr>
                                        <tr >
                                            <td style="width: 57px" >
                                                <asp:DropDownList ID="CboSeco" runat="server" Width="58px" 
                                                    DataSourceID="ObjSeccion" DataValueField="Secc_Codi" DataTextField="Secc_Codi">
                                                    <asp:ListItem Value="C" >Texto</asp:ListItem>
                                                    <asp:ListItem Value="N" >N&#250;merico</asp:ListItem>
                                                    <asp:ListItem Value="D" >Fecha</asp:ListItem>
                                                </asp:DropDownList>
                                            </td>
                                        </tr>
                                    </tbody>
                                </table>
                            </HeaderTemplate>
                            <ItemTemplate >
                                <asp:Label ID="Label5" runat="server" Text='<%# Bind("CoCd_Seco") %>' 
                                    ></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Cart" SortExpression="CoCd_Cart" >
                            <EditItemTemplate >
                                <asp:TextBox ID="TextBox6" runat="server" Text='<%# Bind("Par_Dec") %>' 
                                    ></asp:TextBox>
                            </EditItemTemplate>
                            <HeaderTemplate >
                                <table >
                                    <tbody>
                                        <tr >
                                            <td colspan="1">
                                                <asp:Label ID="Label16" runat="server" Text="Mov_Car"  ToolTip="Genera Movimiento Cartera"></asp:Label>
                                            </td>
                                        </tr>
                                        <tr >
                                            <td >
                                                <asp:DropDownList ID="CboCart" runat="server" >
                                                    <asp:ListItem></asp:ListItem>
                                                    <asp:ListItem Value="S" >SI</asp:ListItem>
                                                    <asp:ListItem Value="N" >NO</asp:ListItem>
                                                </asp:DropDownList>
                                            </td>
                                        </tr>
                                    </tbody>
                                </table>
                            </HeaderTemplate>
                            <ItemTemplate >
                                <asp:Label ID="Label6" runat="server" Text='<%# Bind("CoCd_Cart") %>' ></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="ISVb" SortExpression="CoCd_IsVb" >
                            <EditItemTemplate >
                                <asp:TextBox ID="TextBox7" runat="server" Text='<%# Bind("Pali_vanu") %>' ></asp:TextBox>
                            </EditItemTemplate>
                            <HeaderTemplate >
                                <table >
                                    <tbody>
                                        <tr >
                                            <td colspan="1" >
                                            <br />
                                                <asp:Label ID="Label17" runat="server" Text="VB"  ToolTip="Muestra  Valor Base"></asp:Label>
                                            </td>
                                        </tr>
                                        <tr >
                                            <td >
                                                <asp:DropDownList ID="CboIsVb1" runat="server" 
                                                    >
                                                    <asp:ListItem></asp:ListItem>
                                                    <asp:ListItem Value="S" >SI</asp:ListItem>
                                                    <asp:ListItem Value="N" >NO</asp:ListItem>
                                                </asp:DropDownList>
                                                &nbsp;
                                            </td>
                                        </tr>
                                    </tbody>
                                </table>
                            </HeaderTemplate>
                            <ItemTemplate >
                                <asp:Label ID="Label7" runat="server" Text='<%# Bind("CoCd_IsVb") %>' 
                                    ></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="CCart" SortExpression="CoCd_CCart" >
                            <EditItemTemplate >
                                <asp:TextBox ID="TextBox8" runat="server" Text='<%# Bind("Pali_Vada") %>' ></asp:TextBox>
                            </EditItemTemplate>
                            <HeaderTemplate >
                                <table >
                                    <tbody>
                                        <tr >
                                            <td colspan="1" >
                                                <asp:Label ID="Label15" runat="server" Width="73px" Height="14px" Text="Codi_Cart"
                                                     ToolTip="Código Cartera"></asp:Label>
                                            </td>
                                        </tr>
                                        <tr >
                                            <td >
                                                <asp:DropDownList ID="CboCCar1" runat="server"  DataSourceID="ObjCCart"
                                                    DataValueField="CCar_Cod" DataTextField="CCar_Cod" AppendDataBoundItems="True">
                                                    <asp:ListItem></asp:ListItem>
                                                </asp:DropDownList>
                                            </td>
                                        </tr>
                                    </tbody>
                                </table>
                            </HeaderTemplate>
                            <ItemTemplate >
                                <asp:Label ID="Label8" runat="server" Text='<%# Bind("CoCd_CCar") %>' 
                                    ></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="CTar" SortExpression="CoCd_CTar" >
                            <EditItemTemplate >
                                <asp:TextBox ID="TextBox9" runat="server" Text='<%# Bind("Pali_UsAp") %>' 
                                    ></asp:TextBox>
                            </EditItemTemplate>
                            <HeaderTemplate >
                                <table >
                                    <tbody>
                                        <tr>
                                            <td style="height: 24px" colspan="3">
                                                <asp:Label ID="Label14" runat="server" Width="49px" Height="15px" Text="Calcular"
                                                     ToolTip="Calcular Impuesto automáticamente en Formulario"></asp:Label>
                                            </td>
                                        </tr>
                                        <tr >
                                            <td >
                                                <asp:DropDownList ID="CboCTar1" runat="server" >
                                                    <asp:ListItem></asp:ListItem>
                                                    <asp:ListItem Value="S" >SI</asp:ListItem>
                                                    <asp:ListItem Value="N" >NO</asp:ListItem>
                                                </asp:DropDownList>
                                            </td>
                                            <td style="width: 6px" >
                                                <asp:Button ID="Button1" OnClick="btnFiltrar_Click" runat="server" Text="+" ></asp:Button>
                                            </td>
                                            <td style="width: 6px">
                                                <asp:Button ID="Filtrar" OnClick="btnQFiltrar_Click" runat="server" Text="-"  ToolTip="Quitar Filtro"></asp:Button>
                                            </td>
                                        </tr>
                                    </tbody>
                                </table>
                            </HeaderTemplate>
                            <ItemTemplate >
                                <asp:Label ID="Label9" runat="server" Text='<%# Bind("CoCd_CTar") %>' ></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:ButtonField CommandName="Eliminar" ImageUrl="~/images/Operaciones/delete2.png"
                            Text="Eliminar" ButtonType="Image" ></asp:ButtonField>
                        <asp:ButtonField CommandName="Editar" ImageUrl="~/images/Operaciones/Edit2.png" Text="Editar"
                            ButtonType="Image" ></asp:ButtonField>
                        <asp:CommandField SelectImageUrl="~/images/Operaciones/Select.png" ShowSelectButton="True"
                            ButtonType="Image" ></asp:CommandField>
                    </Columns>
                </asp:GridView>
                <br />
                <asp:ObjectDataSource ID="ObjFoDe" runat="server" 
                    TypeName="Formularios_Dec" SelectMethod="GetRecords" >
                </asp:ObjectDataSource>
                <asp:HiddenField ID="OperFoDe" runat="server" ></asp:HiddenField>
                <br />
                <asp:HiddenField ID="HdPk1" runat="server" ></asp:HiddenField>
                <asp:HiddenField ID="HdPk2" runat="server" ></asp:HiddenField>
                <asp:HiddenField ID="Oper" runat="server" ></asp:HiddenField>
                <asp:HiddenField ID="FValores" runat="server" ></asp:HiddenField>
                <asp:ObjectDataSource ID="ObjValores" runat="server" TypeName="Conc_Cdec" SelectMethod="GetConceptos"
                    OldValuesParameterFormatString="original_{0}" >
                    <SelectParameters>
                        <asp:ControlParameter ControlID="GridView1" PropertyName="SelectedValue" Name="Conc_FoDe"
                            Type="String"></asp:ControlParameter>
                        <asp:ControlParameter ControlID="FValores" PropertyName="Value" Name="Filtro" Type="String">
                        </asp:ControlParameter>
                    </SelectParameters>
                </asp:ObjectDataSource>
                &nbsp;&nbsp;
            </ContentTemplate>
        </asp:UpdatePanel>
        &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;&nbsp; &nbsp;&nbsp; &nbsp;&nbsp;
        &nbsp;&nbsp; &nbsp; &nbsp;&nbsp;
        <asp:UpdatePanel ID="UpdatePanel2" runat="server">
            <ContentTemplate>
                <!-- Mensaje de Salida-->
                <br />
                <asp:Button Style="display: none" ID="hiddenTargetControlForModalPopup2" runat="server">
                </asp:Button>
                <ajaxToolkit:ModalPopupExtender ID="ModalPopupTer" runat="server" TargetControlID="hiddenTargetControlForModalPopup2"
                    RepositionMode="RepositionOnWindowScroll" BehaviorID="programmaticModalPopupBehavior2"
                    BackgroundCssClass="modalBackground" DropShadow="True" PopupControlID="programmaticPopup2"
                    PopupDragHandleControlID="programmaticPopupDragHandle2">
                </ajaxToolkit:ModalPopupExtender>
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                <asp:Panel ID="programmaticPopup2" runat="server" Width="708px" Height="600px" CssClass="ModalPanel2">
                    <asp:Panel ID="programmaticPopupDragHandle2" runat="Server" Width="706px" Height="30px"
                        CssClass="BarTitleModal2">
                        <div style="padding-right: 5px; padding-left: 5px; padding-bottom: 5px; vertical-align: middle;
                            padding-top: 5px">
                            <div style="float: left">
                                Formularios de&nbsp; Liquidación</div>
                            <div style="float: right">
                                <input id="BtnCerrar" onclick="return BtnCerrar_onclick()" type="button" value="X" /></div>
                        </div>
                    </asp:Panel>
                    <table style="width: 467px" align="center">
                        <tbody>
                            <tr>
                                <td style="height: 33px" colspan="3">
                                    <asp:Label ID="TitFode" runat="server" Text="Nuevo Registro.." CssClass="Titulo"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td colspan="3">
                                    <asp:ValidationSummary ID="ValidationSummary1" runat="server" ValidationGroup="Guardar">
                                    </asp:ValidationSummary>
                                </td>
                            </tr>
                            <tr>
                                <td style="width: 271px">
                                    Código
                                </td>
                                <td style="width: 102px">
                                    <asp:TextBox ID="TxtCodi" runat="server" Width="114px" Enabled="False"></asp:TextBox>
                                </td>
                                <td style="width: 14190px" __designer:dtid="281474976710689">
                                </td>
                            </tr>
                            <tr>
                                <td style="width: 271px">
                                    Clase
                                </td>
                                <td style="width: 102px">
                                    <asp:DropDownList ID="CmbCdec" runat="server" Width="285px" DataSourceID="ObjClaseDec"
                                        DataTextField="cld_nom" DataValueField="cld_cod">
                                    </asp:DropDownList>
                                </td>
                                <td style="width: 14190px">
                                </td>
                            </tr>
                            <tr>
                                <td style="width: 271px; height: 20px">
                                    Ruta Web
                                </td>
                                <td style="width: 102px; height: 20px">
                                    <asp:TextBox ID="TxtFoWe" runat="server" Width="211px"></asp:TextBox>
                                </td>
                                <td style="width: 14190px; height: 20px">
                                    <asp:RequiredFieldValidator ID="RqCod" runat="server" ValidationGroup="GuardarFD"
                                        ControlToValidate="TxtFoWe" ErrorMessage="Especifique Ruta de Página Web">*</asp:RequiredFieldValidator>
                                </td>
                            </tr>
                            <tr>
                                <td style="width: 271px">
                                    Ruta Reporte
                                </td>
                                <td style="width: 102px">
                                    <asp:TextBox ID="TxtRpte" runat="server" Width="211px"></asp:TextBox>
                                </td>
                                <td style="width: 14190px">
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ValidationGroup="GuardarFD"
                                        ControlToValidate="TxtFoWe" ErrorMessage="Especifique Ruta de Reporte RDLC">*</asp:RequiredFieldValidator>
                                </td>
                            </tr>
                            <tr>
                                <td style="width: 271px; height: 21px">
                                    Fecha Inicial
                                </td>
                                <td style="width: 102px; height: 21px">
                                    <asp:TextBox ID="TxtFeIn" runat="server"></asp:TextBox>
                                </td>
                                <td style="width: 14190px; height: 21px">
                                    <asp:CustomValidator ID="CusValFini" runat="server" ValidationGroup="GuardarFD" ControlToValidate="TxtFeIn"
                                        ErrorMessage="Digite Una Fecha Inicial Valida" ClientValidationFunction="ValIsFecha">*</asp:CustomValidator>
                                </td>
                            </tr>
                            <tr>
                                <td style="width: 271px">
                                    Fecha Final
                                </td>
                                <td style="width: 102px">
                                    <asp:TextBox ID="TxtFeFi" runat="server"></asp:TextBox>
                                </td>
                                <td>
                                    <asp:CompareValidator ID="CompareValidator1" runat="server" ValidationGroup="GuardarFD"
                                        ControlToValidate="TxtFeFi" ErrorMessage="La Fecha Inicial debe ser menor que la Final"
                                        Operator="GreaterThanEqual" ControlToCompare="TxtFeIn" SetFocusOnError="True">*</asp:CompareValidator>
                                    <asp:CustomValidator ID="CusValFfin" runat="server" ValidationGroup="GuardarFD" ControlToValidate="TxtFeFi"
                                        ErrorMessage="Digite Una Fecha Final Valida" ClientValidationFunction="ValIsFecha">*</asp:CustomValidator>
                                </td>
                            </tr>
                            <tr>
                                <td style="width: 271px; height: 21px">
                                    Estado
                                </td>
                                <td style="width: 102px; height: 21px">
                                    <asp:DropDownList ID="CboEsta" runat="server">
                                        <asp:ListItem Value="AC">Activo</asp:ListItem>
                                        <asp:ListItem Value="IN">Inactivo</asp:ListItem>
                                    </asp:DropDownList>
                                </td>
                                <td style="width: 14190px; height: 21px">
                                </td>
                            </tr>
                            <tr>
                                <td style="width: 271px" valign="top">
                                    Operaciones
                                    <br />
                                    Liquidación Privada<br />
                                    (Explorador)<br />
                                    JavaScript
                                </td>
                                <td style="width: 102px">
                                    <asp:TextBox ID="TxtOpeLP" runat="server" Width="430px" Height="96px" TextMode="MultiLine"></asp:TextBox>
                                </td>
                                <td style="width: 14190px" valign="top">
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ValidationGroup="GuardarFD"
                                        ControlToValidate="TxtOpeLP" ErrorMessage="Digite Operaciones Sección LP (Liquidación Privada)- Lng: JavaScript">*</asp:RequiredFieldValidator>
                                </td>
                            </tr>
                            <tr>
                                <td style="width: 271px; height: 36px" valign="top">
                                    Operaciones Liquidación Oficial(Explorador)<br />
                                    JavaScript
                                </td>
                                <td style="width: 102px; height: 36px">
                                    <asp:TextBox ID="TxtOpeVP" runat="server" Width="428px" Height="96px" TextMode="MultiLine"></asp:TextBox>
                                </td>
                                <td style="width: 14190px; height: 36px" valign="top">
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ValidationGroup="GuardarFD"
                                        ControlToValidate="TxtOpeVP" ErrorMessage="Digite Operaciones Sección VP (Valor a Pagar)- Lng: JavaScript">*</asp:RequiredFieldValidator>
                                </td>
                            </tr>
                            <tr>
                                <td style="width: 271px; height: 39px" valign="top">
                                    Observación
                                </td>
                                <td style="width: 102px; height: 39px">
                                    <asp:TextBox ID="TxtObs" runat="server" Width="428px" Height="43px" TextMode="MultiLine"></asp:TextBox>
                                </td>
                                <td style="width: 14190px; height: 39px" valign="top">
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ValidationGroup="GuardarFD"
                                        ControlToValidate="TxtObs" ErrorMessage="Digite Observación">*</asp:RequiredFieldValidator>
                                </td>
                            </tr>
                            <tr>
                                <td style="height: 38px; text-align: center" colspan="3">
                                    <asp:Button ID="BtnGuardar" OnClick="BtnGuardar_Click" runat="server" Text="Guardar"
                                        ValidationGroup="GuardarFD" UseSubmitBehavior="False"></asp:Button>
                                    <input id="BtnCancelar1" type="button" value="Cancelar" />
                                </td>
                            </tr>
                        </tbody>
                    </table>
                </asp:Panel>
                <ajaxToolkit:CalendarExtender ID="CalendarExtender1" runat="server" TargetControlID="TxtFeIn">
                </ajaxToolkit:CalendarExtender>
                <ajaxToolkit:CalendarExtender ID="CalendarExtender2" runat="server" TargetControlID="TxtFeFi">
                </ajaxToolkit:CalendarExtender>
            </ContentTemplate>
        </asp:UpdatePanel>
        <asp:ObjectDataSource ID="ObjClaseDec" runat="server" OldValuesParameterFormatString="original_{0}"
            SelectMethod="GetcargarTipoDecla" TypeName="Informes"></asp:ObjectDataSource>
        &nbsp;&nbsp;<br />
        <br />
        <br />
        <asp:UpdatePanel ID="UpdatePanel3" runat="server">
            <ContentTemplate>
                <br />
                <asp:Button Style="display: none" ID="hiddenTargetControlForModalPopup3" runat="server">
                </asp:Button>
                <ajaxToolkit:ModalPopupExtender ID="ModalPopupTer3" runat="server" TargetControlID="hiddenTargetControlForModalPopup3"
                    RepositionMode="RepositionOnWindowScroll" BehaviorID="programmaticModalPopupBehavior3"
                    BackgroundCssClass="modalBackground" DropShadow="True" PopupControlID="programmaticPopup3"
                    PopupDragHandleControlID="programmaticPopupDragHandle3">
                </ajaxToolkit:ModalPopupExtender>
                &nbsp;&nbsp;
                <asp:Panel ID="programmaticPopup3" runat="server" Width="765px" Height="600px" CssClass="ModalPanel2">
                    <asp:Panel ID="programmaticPopupDragHandle3" runat="Server" Width="761px" Height="30px"
                        CssClass="BarTitleModal2">
                        <div style="padding-right: 5px; padding-left: 5px; padding-bottom: 5px; vertical-align: middle;
                            padding-top: 5px">
                            <div style="float: left">
                                Conceptos/Renglones de Liquidación&nbsp;</div>
                            <div style="float: right">
                                <input id="BtnClosePar" type="button" value="X" /></div>
                        </div>
                    </asp:Panel>
                    <br />
                    <table style="width: 566px">
                        <tbody>
                            <tr>
                                <td colspan="3">
                                    <asp:Label ID="TitConc" runat="server" Text="Nuevo Registro" CssClass="Titulo"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td style="width: 100px">
                                    Clase
                                </td>
                                <td style="width: 114px">
                                    <asp:DropDownList ID="CmbCdec2" runat="server" Width="285px" DataSourceID="ObjClaseDec"
                                        Enabled="False" DataTextField="cld_nom" DataValueField="cld_cod">
                                    </asp:DropDownList>
                                </td>
                                <td style="width: 100px">
                                </td>
                            </tr>
                            <tr>
                                <td style="width: 100px">
                                    Código
                                </td>
                                <td style="width: 114px">
                                    <asp:TextBox ID="TxtCodC" runat="server"></asp:TextBox>
                                </td>
                                <td style="width: 100px">
                                </td>
                            </tr>
                            <tr style="color: #000000">
                                <td style="width: 100px">
                                    Renglon/Concepto
                                </td>
                                <td style="width: 114px">
                                    <asp:TextBox ID="TxtConc" runat="server" Width="299px"></asp:TextBox>
                                </td>
                                <td style="width: 100px">
                                </td>
                            </tr>
                            <tr>
                                <td style="width: 100px; text-align: left">
                                    Tipo de Concepto
                                </td>
                                <td style="width: 114px; text-align: left">
                                    <asp:DropDownList ID="CboTico" runat="server" DataSourceID="ObjTiCo" DataTextField="TCon_CNom"
                                        DataValueField="TCon_Cod">
                                        <asp:ListItem Value="C">Texto</asp:ListItem>
                                        <asp:ListItem Value="N">N&#250;merico</asp:ListItem>
                                        <asp:ListItem Value="D">Fecha</asp:ListItem>
                                    </asp:DropDownList>
                                </td>
                                <td style="width: 100px">
                                </td>
                            </tr>
                            <tr>
                                <td style="width: 100px; height: 20px">
                                    Impuesto
                                </td>
                                <td style="width: 114px; height: 20px; text-align: left">
                                    <asp:DropDownList ID="CboImpto" runat="server">
                                        <asp:ListItem></asp:ListItem>
                                    </asp:DropDownList>
                                </td>
                                <td style="width: 100px; height: 20px">
                                    ,
                                </td>
                            </tr>
                            <tr __designer:dtid="281474976710800">
                                <td style="width: 100px">
                                    Sección Formulario
                                </td>
                                <td style="width: 114px; text-align: left">
                                    <asp:DropDownList ID="CboSeco" runat="server" DataSourceID="ObjSeccion" DataTextField="Secc_Nomb"
                                        DataValueField="Secc_Codi">
                                        <asp:ListItem Value="C">Texto</asp:ListItem>
                                        <asp:ListItem Value="N">N&#250;merico</asp:ListItem>
                                        <asp:ListItem Value="D">Fecha</asp:ListItem>
                                    </asp:DropDownList>
                                </td>
                                <td style="width: 100px">
                                </td>
                            </tr>
                            <tr __designer:dtid="281474976710808">
                                <td style="width: 100px">
                                    Mostrar Valor Base
                                </td>
                                <td style="width: 114px; text-align: left">
                                    <asp:DropDownList ID="CboIsVb" runat="server">
                                        <asp:ListItem Value="S">SI</asp:ListItem>
                                        <asp:ListItem Value="N">NO</asp:ListItem>
                                    </asp:DropDownList>
                                </td>
                                <td style="width: 100px">
                                </td>
                            </tr>
                            <tr>
                                <td style="width: 100px">
                                    Afecta Cartera
                                </td>
                                <td style="width: 114px; text-align: left">
                                    <asp:DropDownList ID="CboCart" runat="server">
                                        <asp:ListItem Value="S">SI</asp:ListItem>
                                        <asp:ListItem Value="N">NO</asp:ListItem>
                                    </asp:DropDownList>
                                </td>
                                <td style="width: 100px">
                                </td>
                            </tr>
                            <tr __designer:dtid="281474976710822">
                                <td style="width: 100px">
                                    Concepto de Cartera
                                </td>
                                <td style="width: 114px; text-align: left">
                                    <asp:DropDownList ID="CboCCar" runat="server">
                                    </asp:DropDownList>
                                </td>
                                <td style="width: 100px">
                                </td>
                            </tr>
                            <tr>
                                <td style="width: 100px">
                                    Calcular Impuesto Automáticamente
                                </td>
                                <td style="width: 114px">
                                    <asp:DropDownList ID="CboCTar" runat="server">
                                        <asp:ListItem Value="S">SI</asp:ListItem>
                                        <asp:ListItem Value="N">NO</asp:ListItem>
                                    </asp:DropDownList>
                                </td>
                                <td style="width: 100px">
                                </td>
                            </tr>
                            <tr __designer:dtid="281474976710836">
                                <td style="width: 100px">
                                    Sumatoria
                                </td>
                                <td style="width: 114px">
                                    <asp:DropDownList ID="CboSum" runat="server">
                                        <asp:ListItem Value="S">SI</asp:ListItem>
                                        <asp:ListItem Value="N">NO</asp:ListItem>
                                    </asp:DropDownList>
                                </td>
                                <td style="width: 100px">
                                </td>
                            </tr>
                            <tr>
                                <td style="width: 100px">
                                    Tipo de Movimiento
                                </td>
                                <td style="width: 114px">
                                    <asp:DropDownList ID="CboTMOV" runat="server" DataSourceID="ObjTMOV" DataTextField="TMOV_NOM"
                                        DataValueField="TMOV_COD" AppendDataBoundItems="True">
                                        <asp:ListItem></asp:ListItem>
                                    </asp:DropDownList>
                                </td>
                                <td style="width: 100px">
                                </td>
                            </tr>
                            <tr>
                                <td style="width: 100px">
                                    Abreviatura Valor Base
                                </td>
                                <td style="width: 114px">
                                    <asp:TextBox ID="TxtABVB" runat="server"></asp:TextBox>
                                </td>
                                <td style="width: 100px">
                                </td>
                            </tr>
                            <tr>
                                <td style="width: 100px">
                                    Abreviatura Valor Renglon
                                </td>
                                <td style="width: 114px">
                                    <asp:TextBox ID="TxtABVD" runat="server"></asp:TextBox>
                                </td>
                                <td style="width: 100px">
                                </td>
                            </tr>
                            <tr>
                                <td style="width: 100px">
                                    Base Redondeo Valor Base
                                </td>
                                <td style="width: 114px">
                                    <asp:TextBox ID="TxtREVB" runat="server"></asp:TextBox>
                                </td>
                                <td style="width: 100px">
                                </td>
                            </tr>
                            <tr>
                                <td style="height: 22px; text-align: center" colspan="3">
                                    &nbsp;<asp:Button ID="BtnGuardarN" OnClick="BtnGuardarN_Click" runat="server" Text="Guardar"
                                        __designer:wfdid="w53" ValidationGroup="Guardar2"></asp:Button>
                                    <asp:Button ID="BtnCancel" OnClick="BtnCancel_Click" runat="server" Text="Cancelar"
                                        __designer:wfdid="w54"></asp:Button>
                                </td>
                            </tr>
                            <tr>
                                <td style="text-align: center" colspan="3">
                                </td>
                            </tr>
                        </tbody>
                    </table>
                    <br />
                    <br />
                </asp:Panel>
            </ContentTemplate>
        </asp:UpdatePanel>
        &nbsp;<asp:ObjectDataSource ID="ObjTiCo" runat="server" OldValuesParameterFormatString="original_{0}"
            SelectMethod="GetRecords" TypeName="Tipo_Conceptos"></asp:ObjectDataSource>
        <asp:ObjectDataSource ID="ObjImpto" runat="server" OldValuesParameterFormatString="original_{0}"
            SelectMethod="GetByCLASE" TypeName="Impuestos">
            <SelectParameters>
                <asp:ControlParameter ControlID="CmbCdec2" Name="Imp_Cla" PropertyName="SelectedValue" />
            </SelectParameters>
        </asp:ObjectDataSource>
        <asp:ObjectDataSource ID="ObjCCart" runat="server" OldValuesParameterFormatString="original_{0}"
            SelectMethod="GetRecords" TypeName="Conc_Cart"></asp:ObjectDataSource>
        <asp:ObjectDataSource ID="ObjSeccion" runat="server" OldValuesParameterFormatString="original_{0}"
            SelectMethod="GetRecords" TypeName="Secciones"></asp:ObjectDataSource>
        <asp:ObjectDataSource ID="ObjTMOV" runat="server" OldValuesParameterFormatString="original_{0}"
            SelectMethod="GetRecords" TypeName="Tipo_Mov"></asp:ObjectDataSource>
        &nbsp;<br />
        &nbsp;
        <br />
        <asp:UpdateProgress ID="UpdateProgress1" runat="server" AssociatedUpdatePanelID="UpdatePanel1">
            <ProgressTemplate>
                <div class="Loading">
                    <img src="../../images/loading.gif" alt="" title="" />
                    Cargando …
                </div>
            </ProgressTemplate>
        </asp:UpdateProgress>
        <br />
    </div>
</asp:Content>
