<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="SelDec.aspx.vb" 
Inherits="Declaraciones_Diligenciar_SelDec" title="Untitled Page" EnableEventValidation="false" %>
<%@ Register Src="../../CtrlUsr/Terceros/ConsultaTer.ascx" TagName="ConsultaTer" TagPrefix="uc1" %>
<%@ Register src="../../CtrlUsr/Liq/Vh_CU_ConLiq.ascx" tagname="Vh_CU_ConLiq" tagprefix="uc1" %>
<%@ Register src="../../CtrlUsr/Terceros/Con_Tercero.ascx" tagname="Con_Tercero" tagprefix="uc2" %>

<asp:Content ID="Content1" ContentPlaceHolderID="SampleContent" Runat="Server">
    <ajaxToolkit:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server"
     EnablePageMethods="true" 
     AsyncPostBackTimeout="3600"
     >
    </ajaxToolkit:ToolkitScriptManager>
    <script src="../../js/jsUpdateProgress.js" type="text/javascript"></script>
    <script type="text/javascript" language="javascript">
        var ModalProgress = '<%= ModalProgress.ClientID %>';         
    </script>
  <%--  <script type="text/javascript">
        function llamar() {
            PageMethods.Saludame($get("nombre").value, OnOK);
        }
        function OnOK(msg) {
            var etiqueta = $get("LabeltIMER");  
            etiqueta.innerHTML += msg + "<br />";
        }
     </script>--%>

<div class="demoarea">
 
<asp:Label ID="LBTITULO" runat="server" CssClass="Titulo">DILIGENCIAR DECLARACIÓN PRIVADA</asp:Label>&nbsp;&nbsp;<div class="DecHeader">
        <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional"   >
            <ContentTemplate>
&nbsp;<asp:Label id="MsgResult" runat="server" Width="90%" Height="30px" ></asp:Label>&nbsp; <br />
                <table >
                        <tr>
                            <td  class="TDNegroFila" style="HEIGHT: 13px">
                                <asp:Label ID="Label10" runat="server"  
                                     Font-Bold="True" Text="AGENTE RECAUDADOR"></asp:Label>
                                &nbsp;&nbsp;
                                <asp:Button ID="button" runat="server" 
                                     onclick="button_Click" style="DISPLAY: none" />
                            </td>
                        </tr>
                          <tr >
                                <td >
                                    <table  width="100%">
                                        <tbody>
                                            <tr >
                                                <td  style="WIDTH: 25px; HEIGHT: 15px">
                                                    &nbsp;</td>
                                                <td  style="WIDTH: 25px; HEIGHT: 15px">
                                                    <asp:Label ID="Label45" runat="server"  
                                                         CssClass="TitDecl" Font-Bold="True" 
                                                        Text="IDENTIFICACIÓN" Width="115px"></asp:Label>
                                                </td>
                                                <td style="WIDTH: 51px; HEIGHT: 15px" colspan="3">
                                                    &nbsp;<asp:Label ID="Label2" runat="server" 
                                                       CssClass="TitDecl" Font-Bold="True" Text="DV"></asp:Label>
                                                </td>
                                                <td style="WIDTH: 31px; HEIGHT: 15px" colspan="3">
                                                </td>
                                                <td style="WIDTH: 131px; HEIGHT: 15px" colspan="4">
                                                    <asp:Label ID="Label11" runat="server" 
                                                        CssClass="TitDecl" Font-Bold="True" Text="RAZON SOCIAL"></asp:Label>
                                                </td>
                                                <td style="WIDTH: 253px; HEIGHT: 15px">
                                                    &nbsp;</td>
                                                <td 
                                                    style="WIDTH: 253px; text-align: center;">
                                                    &nbsp;</td>
                                                <td style="WIDTH: 253px; text-align: center;">
                                                    &nbsp;</td>
                                                <td style="WIDTH: 253px; text-align: center;">
                                                    &nbsp;</td>
                                            </tr>
                                            <tr >
                                                <td style="HEIGHT: 19px; TEXT-ALIGN: left" 
                                                    valign="top">
                                                    <asp:CheckBox ID="ChkNit" runat="server" />
                                                </td>
                                                <td  style="HEIGHT: 19px; TEXT-ALIGN: right" 
                                                    valign="top">
                                                    <asp:TextBox ID="Nit" runat="server" 
                                                        AutoPostBack="True"></asp:TextBox>
                                                    &nbsp;
                                                </td>
                                                <td  style="WIDTH: 51px; HEIGHT: 19px" 
                                                    valign="top" colspan="3">
                                                    <asp:TextBox ID="Dv" runat="server"
                                                         Enabled="False" Width="17px"></asp:TextBox>
                                                    &nbsp;</td>
                                                <td style="WIDTH: 31px; HEIGHT: 19px" valign="top" colspan="3">
                                                    <asp:Button ID="BtnBuscDP" runat="server"  accessKey="B" 
                                                        onclick="BtnBuscar_Click" Text="..." ToolTip="Buscar Agente Recaudador" 
                                                        UseSubmitBehavior="False" />
                                                </td>
                                                <td  colspan="5" style="HEIGHT: 19px" 
                                                    valign="top">
                                                    <asp:TextBox ID="Agente" runat="server"  
                                                       Enabled="False" Width="332px"></asp:TextBox>
                                                </td>
                                                <td style="WIDTH: 253px; text-align: center;">
                                                    &nbsp;</td>
                                                <td style="WIDTH: 253px; text-align: center;">
                                                    &nbsp;</td>
                                                <td style="WIDTH: 253px; text-align: center;">
                                                    &nbsp;</td>
                                            </tr>
                                            <tr >
                                                <td  style="HEIGHT: 19px">
                                                    &nbsp;</td>
                                                <td  colspan="3" style="HEIGHT: 19px">
                                                    <asp:Label ID="Label46" runat="server" 
                                                        CssClass="TitDecl" Font-Bold="True" Text="PLACA" 
                                                        Width="115px"></asp:Label>
                                                </td>
                                                <td colspan="3" style="HEIGHT: 19px">
                                                    &nbsp;</td>
                                                <td colspan="3" style="HEIGHT: 19px">
                                                    <asp:Label ID="Label47" runat="server" CssClass="TitDecl" Font-Bold="True" 
                                                        Text="AÑO GRAVABLE" Width="115px"></asp:Label>
                                                </td>
                                                <td colspan="3" style="HEIGHT: 19px">
                                                    <asp:Label ID="Label48" runat="server" CssClass="TitDecl" Font-Bold="True" 
                                                        Text="N° GRUPO LIQUIDACION"></asp:Label>
                                                </td>
                                                <td style="HEIGHT: 19px; text-align: center;" colspan="2">
                                                    &nbsp;</td>
                                                <td style="HEIGHT: 19px; text-align: center;">
                                                    &nbsp;</td>
                                            </tr>
                                            <tr >
                                                <td style="HEIGHT: 19px">
                                                    <asp:CheckBox ID="ChkPlaca" runat="server" />
                                                </td>
                                                <td  colspan="3" style="HEIGHT: 19px">
                                                    <asp:TextBox ID="TxtPlaca" runat="server" 
                                                        ></asp:TextBox>
                                                </td>
                                                <td colspan="3" style="HEIGHT: 19px">
                                                    &nbsp;</td>
                                                <td colspan="3" style="HEIGHT: 19px">
                                                    <asp:DropDownList ID="CboVigencia" runat="server" AutoPostBack="True" 
                                                        DataSourceID="ObjCalVigencias" DataTextField="cal_vig" DataValueField="cal_vig">
                                                    </asp:DropDownList>
                                                </td>
                                                <td colspan="3" style="HEIGHT: 19px">
                                                    <asp:TextBox ID="TxtNro_LiqG" runat="server"></asp:TextBox>
                                                </td>
                                                <td  style="HEIGHT: 19px; text-align: center;" colspan="2">
                                                    &nbsp;</td>
                                                <td style="HEIGHT: 19px; text-align: center;">
                                                    &nbsp;</td>
                                            </tr>
                                            <tr >
                                                <td style="HEIGHT: 12px">
                                                    </td>
                                                <td colspan="12" style="HEIGHT: 12px">
                                                </td>
                                                <td style="HEIGHT: 12px" colspan="2">
                                                    </td>
                                                <td style="HEIGHT: 12px">
                                                    </td>
                                            </tr>
                                    </tbody>
                                    </table>
                                    <table  width="100%">
                                        <tbody>
                                            <tr >
                                                <td style="HEIGHT: 19px; width: 110px;">
                                                    <asp:ImageButton ID="BtnFiltrar" runat="server" Text="Filtrar" 
                                                        UseSubmitBehavior="False" ImageUrl="~/images/Operaciones/Matricular.png" />
                                                </td>
                                                <td style="HEIGHT: 19px; width: 110px;">
                                                    <asp:ImageButton ID="BtnLiquidarG" runat="server" Text="Liquidar" 
                                                        UseSubmitBehavior="False" ImageUrl="~/images/Operaciones/liquidar.png" />
                                                </td>
                                                <td style="HEIGHT: 19px; width: 120px;">
                                                    <asp:ImageButton ID="BtnLiquidarG0" runat="server" Text="Liquidar" 
                                                        UseSubmitBehavior="False" ImageUrl="~/images/Operaciones/grupal.png" />
                                                </td>
                                                <td style="HEIGHT: 19px; width: 120px;">
                                                    
                                                </td>
                                                <td style="HEIGHT: 19px; text-align: center; width: 120px;">
                                                    &nbsp;</td>
                                              
                                            </tr>
                                            <tr>
                                                <td style="HEIGHT: 19px">
                                                    1. Ver Vehiculos</td>
                                                <td style="HEIGHT: 19px">
                                                    Liquidacion Oficial</td>
                                                <td style="HEIGHT: 19px">
                                                    Liquidación Oficial Grupal</td>
                                                <td style="HEIGHT: 19px">
                                                    &nbsp;</td>
                                                <td style="HEIGHT: 19px; text-align: center;">
                                                    &nbsp;</td>
                                            </tr>
                                            <tr>
                                                <td style="HEIGHT: 19px">
                                                    &nbsp;</td>
                                                <td style="HEIGHT: 19px">
                                                    &nbsp;</td>
                                                <td style="HEIGHT: 19px">
                                                    &nbsp;</td>
                                                <td style="HEIGHT: 19px">
                                                    &nbsp;</td>
                                                <td style="HEIGHT: 19px; text-align: center;">
                                                    &nbsp;</td>
                                              
                                            </tr>
                                    </tbody>
                                    </table>   
                                    <table  width="100%">
                                        <tbody>                                                                             
                                            <tr class="TbDecl" >
                                                <td style="HEIGHT: 19px" colspan="13">
                                                    LISTADO DE VEHICULOS</td>
                                                <td style="HEIGHT: 19px" colspan="2">
                                                    &nbsp;</td>
                                                <td style="HEIGHT: 19px">
                                                    &nbsp;</td>
                                            </tr>
                                            <tr >
                                                <td style="HEIGHT: 19px" colspan="16">
                                                 <%--border-bottom-style: outset--%>
                                                    <asp:GridView ID="grdVeh" runat="server" AutoGenerateColumns="False" 
                                                        DataKeyNames="Placa,Dec_Cod" EnableModelValidation="True"  AllowSorting="True" 
                                                           AllowPaging="True" DataSourceID="ObjVhPA" CellPadding="4" 
                                                           ForeColor="#333333" GridLines="None" >
                                                        <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
                                                        <Columns>
                                                            <asp:BoundField DataField="Placa" HeaderText="Placa" SortExpression="Placa"  />
                                                            <asp:BoundField DataField="Clase" HeaderText="Clase" SortExpression="Clase" />
                                                            <asp:BoundField DataField="Marca" HeaderText="Marca" SortExpression="Marca" />
                                                            <asp:BoundField DataField="Linea" HeaderText="Linea" SortExpression="Linea" />
                                                            <asp:BoundField DataField="Modelo" HeaderText="Modelo"  
                                                                SortExpression="Modelo" />
                                                            <asp:BoundField DataField="Carroceria" HeaderText="Carroceria" 
                                                                SortExpression="Carroceria" />
                                                            <asp:BoundField DataField="Cilindraje" HeaderText="Cilindraje" 
                                                                SortExpression="Cilindraje" />
                                                            <asp:BoundField DataField="Nit" HeaderText="Nit" SortExpression="Nit" />
                                                            <asp:BoundField DataField="Ter_Nom" HeaderText="Propietario" 
                                                                SortExpression="Ter_Nom" />
                                                            <asp:ButtonField ButtonType="Image" CommandName="Seleccionar" 
                                                                ImageUrl="~/images/Operaciones/Select.png" Text="Seleccionar" />
                                                        </Columns>
                                                        <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                                                        <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
                                                        <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
                                                        <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                                                        <EditRowStyle BackColor="#999999" />
                                                        <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                                                    </asp:GridView>
                                                       <asp:ObjectDataSource ID="ObjPA" runat="server"></asp:ObjectDataSource>
                                                    <%--</div>--%>
                                                </td>
                                            </tr>
                                            <tr onmouseout="Resaltar_Off(this);" onmouseover="Resaltar_On(this);">
                                                <td colspan="15" style="HEIGHT: 19px">
                                                    <asp:GridView ID="GridLog" runat="server">
                                                    </asp:GridView>
                                                </td>
                                                <td style="HEIGHT: 19px">
                                                    &nbsp;</td>
                                            </tr>
                                            <tr >
                                                <td colspan="15" style="HEIGHT: 19px">
                                                    &nbsp;</td>
                                                <td style="HEIGHT: 19px">
                                                    &nbsp;</td>
                                            </tr>
                                            <tr >
                                                <td colspan="15" style="HEIGHT: 19px">
                                                    &nbsp;</td>
                                                <td style="HEIGHT: 19px">
                                                    &nbsp;</td>
                                            </tr>
                                        </tbody>
                                    </table>
                                </td>
                            </tr>
                    

                </TABLE>
                <asp:ObjectDataSource id="ObjCalVigencias" runat="server" 
                TypeName="Calendario" SelectMethod="GetVigencias" OldValuesParameterFormatString="original_{0}" >
                <SelectParameters>
                    <asp:Parameter DefaultValue="50" Name="Cla_Dec" Type="String" />
</SelectParameters>
</asp:ObjectDataSource> <asp:ObjectDataSource id="ObjCal" runat="server" 
                     TypeName="Calendario" 
                    SelectMethod="GetPorClaseDec" 
                    OldValuesParameterFormatString="original_{0}"><SelectParameters>
                        <asp:Parameter DefaultValue="50" Name="Cla_Dec" Type="String" />
                        <asp:ControlParameter ControlID="CboVigencia" DefaultValue="" Name="Vigencia" 
                            PropertyName="SelectedValue" Type="String" />
</SelectParameters>
</asp:ObjectDataSource> 
                <asp:HiddenField ID="HdTAG" runat="server"/>
                <asp:HiddenField id="HdAR" runat="server" ></asp:HiddenField> 
                <asp:ObjectDataSource id="ObjTDec" runat="server" 
                     TypeName="Tipo_Dec" 
                    SelectMethod="GetPorClaseDec" 
                    OldValuesParameterFormatString="original_{0}"><SelectParameters >
                        <asp:Parameter DefaultValue="50" Name="Cla_Dec" Type="String" />
</SelectParameters>
</asp:ObjectDataSource> 
                <asp:ObjectDataSource ID="ObjVhPA" runat="server" 
                    OldValuesParameterFormatString="original_{0}" SelectMethod="GetRecords" 
                    TypeName="Vh_Parque_Automotor">
                    <SelectParameters>
                        <asp:SessionParameter Name="sFiltro" SessionField="sFiltro" Type="String" />
                        <%--<asp:SessionParameter Name="Nro_LiqG" SessionField="Nro_LiqG" Type="String" />--%>
                    </SelectParameters>
                </asp:ObjectDataSource>
</ContentTemplate>
            <Triggers>
<asp:AsyncPostBackTrigger ControlID="CboVigencia" EventName="SelectedIndexChanged"></asp:AsyncPostBackTrigger>
<asp:AsyncPostBackTrigger ControlID="Button" EventName="Click"></asp:AsyncPostBackTrigger>
<%--               <asp:PostBackTrigger ControlID="BtnExportLog" />--%>
                
</Triggers>
        </asp:UpdatePanel>&nbsp;
    </div>
    
    &nbsp;&nbsp;<asp:HiddenField ID="Cla_Dec" runat="server" Value="01" />
    <asp:ObjectDataSource ID="ObjCDec" runat="server" OldValuesParameterFormatString="original_{0}"
        SelectMethod="GetCDEC_PorNit" TypeName="CDeclaraciones">
        <SelectParameters>
            <asp:ControlParameter ControlID="Nit" Name="Nit" PropertyName="Text" Type="String" />
        </SelectParameters>
    </asp:ObjectDataSource>
    <asp:UpdatePanel id="UpdatePanel2" runat="server" UpdateMode="Conditional">
        <contenttemplate>
<!-- Mensaje de Salida--><asp:Button style="DISPLAY: none" id="hiddenTargetControlForModalPopup" runat="server"></asp:Button>
 <ajaxToolkit:ModalPopupExtender id="ModalPopup" runat="server" BackgroundCssClass="modalBackground" BehaviorID="programmaticModalPopupBehavior" DropShadow="True" PopupControlID="programmaticPopup" PopupDragHandleControlID="programmaticPopupDragHandle" RepositionMode="RepositionOnWindowScroll" TargetControlID="hiddenTargetControlForModalPopup">
            </ajaxToolkit:ModalPopupExtender> <asp:Panel id="programmaticPopup" runat="server" Width="625px" Height="229%" 
            CssClass="ModalPanel2"><asp:Panel id="programmaticPopupDragHandle" runat="Server" 
            Width="615px" Height="30px" CssClass="BarTitleModal2">
            <DIV style="PADDING-RIGHT: 5px; PADDING-LEFT: 5px; PADDING-BOTTOM: 5px; VERTICAL-ALIGN: middle; PADDING-TOP: 5px">
            <DIV style="FLOAT: left">Buscar Agente Recaudador </DIV> <DIV style="FLOAT: right" >
            <INPUT id="hideModalPopupViaClientButton" type=button value="X" /></DIV></DIV></asp:Panel>
             
                <uc2:Con_Tercero ID="Con_Tercero1" runat="server" />
                <BR /><BR /><BR /></asp:Panel> 
</contenttemplate>
        <triggers>
<asp:AsyncPostBackTrigger ControlID="BtnBuscDP" EventName="Click"></asp:AsyncPostBackTrigger>

</triggers>
    </asp:UpdatePanel><br />
    
    <asp:Panel ID="panelUpdateProgress" runat="server" CssClass="updateProgress">
    <br />
        <asp:Label ID="LbLote" runat="server" Text="ESPERE UN MOMENTO" Font-Bold="true" ></asp:Label>
    <br />
        <asp:UpdateProgress id="UpdateProgress1" runat="server" DisplayAfter="0" AssociatedUpdatePanelID="UpdatePanel1">
            <progresstemplate>
                <div style="position: relative; top: 30%; text-align: center;">
						<img src="../../images/Vh_loading.gif" style="vertical-align: middle" alt="Procesando" />
						Procesando ...
			    </div>
            </progresstemplate>
        </asp:UpdateProgress>
        <asp:Button ID="BtnVerProgreso" runat="server" Text="Ver Progreso" visible="false"  />    
        <asp:Button ID="BtnParar" runat="server" Text="Suspender" visible="false" />            
    </asp:Panel>
    <ajaxToolkit:ModalPopupExtender ID="ModalProgress" runat="server" TargetControlID="panelUpdateProgress"
			BackgroundCssClass="modalBackground" PopupControlID="panelUpdateProgress" />
    <br />
    <asp:UpdatePanel ID="UpdTime" runat="server">
        <ContentTemplate>
            
            <asp:Label ID="LabeltIMER" runat="server" Text="Label">Cargando Progreso</asp:Label>
            
            <asp:Timer ID="Timer1" runat="server" Interval="1000">
            </asp:Timer>

        </ContentTemplate>
    </asp:UpdatePanel>
</div>
</asp:Content>

