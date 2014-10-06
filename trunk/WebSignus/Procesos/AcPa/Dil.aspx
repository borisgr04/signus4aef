<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="Dil.aspx.vb" Inherits="Procesos_AcPa_Dil" title="Acuerdos de Pago" %>
<%@ Register Src="../../CtrlUsr/Terceros/ConsultaTer.ascx" TagName="ConsultaTer" TagPrefix="uc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="SampleContent" Runat="Server">
  <script type='text/javascript'>
  
  // Add click handlers for buttons to show and hide modal popup on pageLoad
        function pageLoad() {
            $addHandler($get("BtnCerrar"), 'click', CerrarModalTercero);        
        }

       function CerrarModalTercero(ev) {
            ev.preventDefault();        
            var modalPopupBehavior2 = $find('programmaticModalPopupBehavior2');
            modalPopupBehavior2.hide();
        }
        
        function CerrarTercero()
        {
           var modalPopupBehavior2 = $find('programmaticModalPopupBehavior2');
            modalPopupBehavior2.hide();
        }

  function enviar(tdoc,ced,dv,rsocial,tip_ter)
        {
            if(tip_ter=='AR'){
                document.aspnetForm.<%=Me.NIT.ClientID%>.value=ced;
                //document.getElementById('x').innerHTML=ced;
                document.aspnetForm.<%=Me.DV.ClientID%>.value=dv;
                document.aspnetForm.<%=Me.AGENTE.ClientID%>.value=rsocial;
            }
            var modalPopupBehavior = $find('programmaticModalPopupBehavior2');
            modalPopupBehavior.hide();
            __doPostBack("<%= button.ClientID %>","");
            __doPostBack("<%= CbCdec.ClientID %>","");
            
        }

    function cancelClick() {
        var label = $get('ctl00_SampleContent_LbRpt');
        label.innerHTML = 'You hit cancel in the Confirm dialog on ' + (new Date()).localeFormat("T") + '.';
    }
        // Add click handlers for buttons to show and hide modal popup on pageLoad
        function pageLoad() {
            //$addHandler($get("showModalPopupClientButton"), 'click', showModalPopupViaClient);
            //$addHandler($get("hideModalPopupViaClientButton"), 'click', hideModalPopupViaClient);        
        }
        
        function showModalPopupViaClient(ev) {
            ev.preventDefault();
            var modalPopupBehavior = $find('programmaticModalPopupBehavior');
            modalPopupBehavior.show();
        }
        
        function hideModalPopupViaClient(ev) {
            ev.preventDefault();        
            var modalPopupBehavior = $find('programmaticModalPopupBehavior');
            modalPopupBehavior.hide();
        }
        
         
       function UpdateCombo()
        {
             var no =document.getElementById("<%= CbCdec.ClientID %>").options.length;
            if (no==1)  __doPostBack("<%= CbCdec.ClientID %>","");
            
            
        }

    </script>

<div class="demoarea">
    <ajaxToolkit:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server" EnablePageMethods="true">
    </ajaxToolkit:ToolkitScriptManager>
    <asp:Label ID="Tit" runat="server" CssClass="Titulo" Text="ACUERDOS DE PAGO"></asp:Label>
    
    <asp:UpdatePanel id="UpdatePanel1" runat="server">
        <contenttemplate>
<table width="600">
    <tr>
        <td style="HEIGHT: 13px" class="TDNegroFila">
            <asp:Label id="MsgResult" runat="server" Height="20px"></asp:Label>
        </td>
    </tr>
    <tr>
        <td  align="right">
            <asp:Label ID="lbNumAcuerdo" runat="server" Text="" Font-Bold="true"></asp:Label>
        </td>
    </tr>
    <tr>
        <td class="TbDecl" style="HEIGHT: 13px">
            <asp:Label ID="ltituloExpe" runat="server" Font-Bold="True" Text="EXPEDIENTE"></asp:Label>
            &nbsp;&nbsp;
            <asp:LinkButton ID="lbNumExpe" runat="server"></asp:LinkButton>
        </td>
    </tr>
    <tr>
        <td class="TDNegroFila" style="HEIGHT: 13px">
            &nbsp;</td>
    </tr>
    <tr>
        <td class="TDNegroFila" style="HEIGHT: 13px">
            <asp:Label ID="Label10" runat="server" Font-Bold="True" 
                Text="AGENTE RECAUDADOR"></asp:Label>
            &nbsp;&nbsp;
            <asp:Button ID="button" runat="server" onclick="button_Click" 
                style="DISPLAY: none" />
        </td>
    </tr>
    <tr><td style="HEIGHT: 169px">
    
    <table width="100%">
        <tr onmouseover="Resaltar_On(this);" onmouseout="Resaltar_Off(this);">
            <td style="WIDTH: 51px; HEIGHT: 15px">
                <asp:Label ID="Label45" runat="server" CssClass="TitDecl" Font-Bold="True" Text="IDENTIFICACIÓN" Width="115px"></asp:Label>
            </td>
            <td style="WIDTH: 51px; HEIGHT: 15px">
                &nbsp;<asp:Label ID="Label2" runat="server" CssClass="TitDecl" Font-Bold="True" Text="DV"></asp:Label>
    </td>
    <TD style="WIDTH: 51px; HEIGHT: 15px"></TD><TD style="WIDTH: 131px; HEIGHT: 15px" __designer:dtid="844424930131992"><asp:Label id="Label11" runat="server" Font-Bold="True" __designer:dtid="844424930131993" __designer:wfdid="w6" Text="RAZON SOCIAL" CssClass="TitDecl"></asp:Label></TD><TD style="WIDTH: 253px; HEIGHT: 15px" __designer:dtid="844424930131994"></TD></TR><TR onmouseover="Resaltar_On(this);" onmouseout="Resaltar_Off(this);" __designer:dtid="844424930131995"><TD style="WIDTH: 51px; HEIGHT: 19px" __designer:dtid="844424930131998">
    <asp:TextBox id="Nit" runat="server" __designer:dtid="844424930131997" 
        __designer:wfdid="w7" Enabled="False"></asp:TextBox></TD>
    <td __designer:dtid="844424930131998" style="WIDTH: 51px; HEIGHT: 19px">
        <asp:TextBox ID="Dv" runat="server" __designer:dtid="844424930131999" 
            __designer:wfdid="w8" Enabled="False" Width="17px"></asp:TextBox>
        &nbsp;</td>
    <TD style="WIDTH: 51px; HEIGHT: 19px"><asp:Button accessKey="B" id="BtnBuscDP" onclick="BtnBuscar_Click" runat="server" __designer:wfdid="w9" Text="..." UseSubmitBehavior="False" ToolTip="Buscar Agente Recaudador"></asp:Button></TD><TD style="HEIGHT: 19px" colSpan=2 __designer:dtid="844424930132000"><asp:TextBox id="Agente" runat="server" Width="332px" __designer:dtid="844424930132001" __designer:wfdid="w10" Enabled="False"></asp:TextBox></TD></TR><TR onmouseover="Resaltar_On(this);" onmouseout="Resaltar_Off(this);"><TD style="HEIGHT: 19px" colSpan=5>
    <asp:FormView id="FormView1" runat="server" DataSourceID="ObjTer">
    <ItemTemplate>
        <TABLE width="100%">
        <TBODY>
            <TR onmouseover="Resaltar_On(this);" onmouseout="Resaltar_Off(this);">
                <TD  colSpan="4">
                    <asp:Label id="Label7" runat="server" Font-Bold="True" Text="REPRESENTANTE LEGAL" CssClass="TitDecl"></asp:Label>
                </TD>
            </TR>
            <TR onmouseover="Resaltar_On(this);" onmouseout="Resaltar_Off(this);">
                <TD style="WIDTH: 83px;" >
                    <asp:Label id="Label32" runat="server" Text="IDENTIFICACIÓN" CssClass="TitDecl"></asp:Label>
                </TD>
                <TD style="WIDTH: 25px">
                </TD>
                <TD style="WIDTH: 25px">
                </TD>
                <TD style="WIDTH: 345px">&nbsp;
                    <asp:Label id="Label35" runat="server" Text="APELLIDOS Y NOMBRES" CssClass="TitDecl"></asp:Label>
                </TD>
            </TR>
            <TR onmouseover="Resaltar_On(this);" onmouseout="Resaltar_Off(this);" >
                <TD style="WIDTH: 83px">
                    <asp:TextBox id="TXTNRODOC_PD" runat="server" Width="94px"  Text='<%# Eval("TER_CED") %>' Enabled="False"></asp:TextBox> 
                </TD>
                <TD style="WIDTH: 25px">
                </TD>
                <TD style="WIDTH: 25px">&nbsp;
                </TD>
                <TD style="WIDTH: 345px">
                    <asp:TextBox id="TXTRAZSOC_PD" runat="server" Width="336px" Text='<%# Eval("TER_REP") %>' Enabled="False"></asp:TextBox></TD></TR>
            <tr onmouseout="Resaltar_Off(this);" onmouseover="Resaltar_On(this);">
                <td colspan="4">
                    LUGAR DE EXPEDICIÓN</td>
            </tr>
            <tr onmouseout="Resaltar_Off(this);" onmouseover="Resaltar_On(this);">
                <td colspan="4">
                    <asp:TextBox ID="tbLugarExp" runat="server" Width="336px" Text='<%# Eval("TER_REP_EXP") %>' Enabled="False"></asp:TextBox>
                </td>
            </tr>
            </TBODY></TABLE>
            </ItemTemplate>
            <EmptyDataTemplate>
                <asp:Label id="Label6" runat="server" __designer:wfdid="w160" CssClass="nodata"></asp:Label> 
            </EmptyDataTemplate>
        </asp:FormView>
        </TD>
        </TR>
        <TR onmouseover="Resaltar_On(this);" onmouseout="Resaltar_On(this);" __designer:dtid="844424930132002"><TD style="HEIGHT: 19px" colSpan=5 __designer:dtid="844424930132003"><asp:Label id="Label1" runat="server" Width="261px" Font-Bold="True" __designer:dtid="844424930132004" __designer:wfdid="w11" Text="SELECCIONE LA CLASE DE DECLARACION" CssClass="TitDecl"></asp:Label> <asp:DropDownList id="CbCdec" runat="server" __designer:dtid="844424930132007" __designer:wfdid="w12" DataSourceID="ObjCDec" OnSelectedIndexChanged="CbCdec_SelectedIndexChanged" AutoPostBack="True" DataTextField="CLD_NOM" DataValueField="CLD_COD"></asp:DropDownList></TD></TR>
    </TBODY>
    </TABLE>
    </TD></TR></TBODY></TABLE>
 <table width="100%">
 <tr onmouseover="Resaltar_On(this);" class="TbDecl" onmouseout="Resaltar_Off(this);">
    <td colspan="6">ACUERDO DE PAGO&nbsp;</td>
 </tr>
 </table>
 <asp:MultiView id="MultiView1" runat="server" ActiveViewIndex="1">
 <asp:View id="View2" runat="server">
 <br/>
 <table width="90%">
 <tr>
    <td colspan="4">
        <asp:Label id="lbprogra" runat="server" Font-Bold="True" Text="PROGRAMACIÓN DE PAGOS"></asp:Label> 
    </td>
    <td colspan="1"></td>
    <td colspan="1"></td>
 </tr>
 <tr>
    <td colspan="5">&nbsp; 
        <asp:ValidationSummary id="ValidationSummary1" runat="server"></asp:ValidationSummary>
    </td>
    <td colspan="1"></td>
 </tr>
 <tr>
    <td style="WIDTH: 100px">
        <asp:Label ID="Label3" runat="server" Text="Fecha Acuerdo De Pago" 
            Width="128px"></asp:Label>
    </td>
    <td style="WIDTH: 100px">
        <asp:Label ID="Label6" runat="server" Text="Deuda Seleccionada" Width="128px"></asp:Label>
     </td>
    <td style="WIDTH: 146px">
        &nbsp;</td>
    <td style="WIDTH: 146px"></td>
    <td style="WIDTH: 146px"></td>
    <td style="WIDTH: 146px"></td>
  </tr>
  <tr>
    <td style="WIDTH: 100px">
        <asp:TextBox ID="txtFec" runat="server"></asp:TextBox>
    </td>
    <td>
        <asp:TextBox ID="TxtDeuSel" runat="server" ReadOnly="True" Width="150px">
        </asp:TextBox>
    </td>
    <td style="WIDTH: 146px">
        <asp:Button ID="BtnDeuda" runat="server" onclick="BtnDeuda_Click" 
            Text="Deuda..." />
    </td>
    <td style="WIDTH: 146px">&nbsp;</td>
    <td style="WIDTH: 146px"></td>
    <td style="WIDTH: 146px"></td>
  </tr>
  <tr>
    <td style="WIDTH: 100px">
        <asp:RadioButton id="OptPorc" runat="server" Text="% Cuota Inicial" GroupName="CInicial"></asp:RadioButton>
    </td>
    <td style="WIDTH: 100px">
        <asp:RadioButton ID="OptValor" runat="server" GroupName="CInicial" 
            Text="Valor Cuota Inicial" Width="150px" />
      </td>
    <td style="WIDTH: 146px">
        <asp:Label ID="Label5" runat="server" Text="Numero de Cuotas"></asp:Label>
      </td>
    <td style="WIDTH: 146px" >
        &nbsp;</td>
    <td colspan=2>
        &nbsp;</td>
 </tr>
 <tr>
    <td style="WIDTH: 100px"><asp:TextBox id="TxtPor" runat="server" Width="56px"></asp:TextBox>
    </td>
    <td>
        $<asp:TextBox id="TxtCuotaI" runat="server" Width="140px"></asp:TextBox>
    </TD>
    <td style="WIDTH: 146px">
        
        <asp:TextBox ID="TxtNCuotas" runat="server"></asp:TextBox>
        
    </td>
    <td style="WIDTH: 146px" align="center">
        <asp:ImageButton ID="CmdProgramar" runat="server" 
            ImageUrl="~/images/Operaciones/build-file.png" 
            ToolTip="Reprogramar Cuotas" CausesValidation="False" />
     </td>
    <td align="center">
        <asp:ImageButton ID="BtnGuardar" runat="server" 
            ImageUrl="~/images/Operaciones/save.png" />
    </td>
     <td>
         &nbsp;</td>
 </tr>
 <tr>
    <td style="WIDTH: 100px">
        <asp:Label id="Label67" runat="server" Width="128px" Text="GARANTIA"></asp:Label>
    </td>
    <td style="WIDTH: 100px"></td>
    <td style="WIDTH: 146px"></td>
    <td style="WIDTH: 146px" align="center">Reprogramar cuotas</td>
    <td style="WIDTH: 146px" align="center">Guardar Acuerdo</td>
    <td style="WIDTH: 146px"></td>
  </tr>
  <tr>
    <td colspan="5">
        <asp:TextBox id="TxtGar" runat="server" Width="537px" TextMode="MultiLine"></asp:TextBox>
        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
            ControlToValidate="TxtGar" ErrorMessage="Especifique la Garantía">*</asp:RequiredFieldValidator>
    </td>
    <td style="WIDTH: 146px; TEXT-ALIGN: left">
        &nbsp;</td>
    </tr><tr>
    <td colSpan=6>&nbsp;</td>
  </tr>
</table>
    <asp:GridView id="GridView1" runat="server" Width="380px" Height="192px" __designer:dtid="1688849860263980" __designer:wfdid="w40" AutoGenerateColumns="False" GridLines="Vertical"><Columns __designer:dtid="1688849860263981">
    <asp:BoundField DataField="NCuotas" HeaderText="N&#176; Cuota" __designer:dtid="1688849860263982">
        <HeaderStyle HorizontalAlign="Left" />
        </asp:BoundField>
    <asp:BoundField DataField="fecha_pago" DataFormatString="{0:d}" HeaderText="Fecha de Pago" __designer:dtid="1688849860263983">
        <HeaderStyle HorizontalAlign="Left" />
        </asp:BoundField>
    <asp:BoundField DataField="Valor_cuota" DataFormatString="{0:c}" HeaderText="Valor Cuota" __designer:dtid="1688849860263984">
        <HeaderStyle HorizontalAlign="Right" />
        <ItemStyle HorizontalAlign="Right" />
        </asp:BoundField>
    </Columns>
    </asp:GridView>
</asp:View>
<asp:View id="View1" runat="server">
    <asp:Label id="LbI" runat="server" Font-Bold="True" Text="SELECCIONE CARTERA POR PERIODOS GRAVABLES"></asp:Label>&nbsp;
    <br />&nbsp;
    <asp:DataList id="DataList1" runat="server" ForeColor="#333333" DataSourceID="ObjCartera" OnSelectedIndexChanged="DataList1_SelectedIndexChanged" GridLines="Both" CellPadding="4" OnItemDataBound="DataList1_ItemDataBound">
    <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White"></FooterStyle>
    <AlternatingItemStyle BackColor="White" ForeColor="#284775"></AlternatingItemStyle>
    <ItemStyle BackColor="#F7F6F3" ForeColor="#333333"></ItemStyle>
    <SelectedItemStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333"></SelectedItemStyle>
    <HeaderTemplate>
    <table>
    <tr>
        <td style="WIDTH: 100px">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; </td>
        <td style="WIDTH: 100px">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; </td>
        <td style="WIDTH: 100px">Año Gravable</td>
        <td style="WIDTH: 100px">Periodo Gravable</td>
        <td style="WIDTH: 100px">Saldo</td>
        <td style="WIDTH: 100px">Documento</td>
        <td style="WIDTH: 100px">N° Documento</td>
    </tr>
    </table>
    </HeaderTemplate>
    <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White"></HeaderStyle>
    <FooterTemplate>
        <table>
        <tr>
            <td style="WIDTH: 100px"></td>
            <td style="WIDTH: 100px">&nbsp;</td>
            <td style="WIDTH: 100px"></td>
            <td style="WIDTH: 100px"></td>
            <td style="WIDTH: 95px">
                <asp:Label id="LbTSaldo" runat="server"></asp:Label>
            </td>
            <td style="WIDTH: 100px"></td>
            <td style="WIDTH: 100px"></td>
        </tr>
        </table>
    </FooterTemplate>
    <ItemTemplate>
        <asp:Panel id="POrderHeader" runat="server">
        <table>
        <tr>
            <td style="WIDTH: 100px">
                <asp:Image id="imgplus" runat="server" ImageUrl="~/images/expand.jpg"></asp:Image>
            </td>
            <td style="WIDTH: 100px"><asp:CheckBox id="ChkSel" runat="server"></asp:CheckBox> 
            </td>
            <td style="WIDTH: 100px"><asp:Label id="lbAño" runat="server" Text='<%# Bind("car_ano") %>'></asp:Label>
            </td>
            <td style="WIDTH: 100px"><asp:Label id="LbPer" runat="server" Text='<%# Bind("car_per") %>'></asp:Label>
            </td>
            <td style="WIDTH: 95px"><asp:Label id="LbSaldo" runat="server" Text='<%# Bind("saldo_a_cargo") %>'></asp:Label>
            </td>
            <td style="WIDTH: 100px"><asp:Label id="LbTDOC" runat="server" Text='<%# Bind("car_tdoc") %>'></asp:Label>
            </td>
            <td style="WIDTH: 100px"><asp:Label id="LbNDoc" runat="server" Text='<%# Bind("car_dcod") %>'></asp:Label>
            </td>
        </tr>
        </table>
        </asp:Panel>
        <br />
        <asp:Panel style="MARGIN-LEFT: 20px; MARGIN-RIGHT: 20px" id="OrdersDetailPanel" runat="server">
        <asp:GridView id="grDetalle" runat="server" CssClass="grid" DataSourceID="ObjCarteraD" AutoGenerateColumns="False" EnableViewState="False" OnRowDataBound="grDetalle_RowDataBound">
            <Columns>
            <asp:BoundField DataField="CAR_CoCa" DataFormatString="{0:n}" HeaderText="C&#243;digo">
            <ItemStyle Width="50px"></ItemStyle>
            </asp:BoundField>
            <asp:BoundField DataField="CCAR_NOm" HeaderText="Concepto"></asp:BoundField>
            <asp:BoundField DataField="Saldo_a_cargo" HeaderText="Saldo a Cargo" 
                    DataFormatString="{0:c}">
                <ItemStyle HorizontalAlign="Right" />
                </asp:BoundField>
            <asp:BoundField DataField="Saldo_a_favor" HeaderText="Saldo a Favor" 
                    DataFormatString="{0:c}">
                <ItemStyle HorizontalAlign="Right" />
                </asp:BoundField>
            <asp:BoundField DataField="Car_FNov" HeaderText="Fecha Liquidaci&#243;n" 
                    DataFormatString="{0:d}">
                <ItemStyle HorizontalAlign="Right" />
                </asp:BoundField>
            </Columns>
        </asp:GridView>
        </asp:Panel>&nbsp; 
        <asp:HiddenField id="HdSaldo" runat="server" Value='<%# Bind("saldo_a_cargo") %>'></asp:HiddenField> 
        <asp:ObjectDataSource id="ObjCarteraD" runat="server" TypeName="AcuerdosP" SelectMethod="GetCarteraD" OldValuesParameterFormatString="original_{0}">
        <SelectParameters>
            <asp:ControlParameter ControlID="CbCdec" PropertyName="SelectedValue" Name="Car_Cdec" Type="String"></asp:ControlParameter>
            <asp:ControlParameter ControlID="Nit" PropertyName="Text" Name="Car_Nit"></asp:ControlParameter>
            <asp:ControlParameter ControlID="lbA&#241;o" PropertyName="Text" Name="Car_ano"></asp:ControlParameter>
            <asp:ControlParameter ControlID="LbPer" PropertyName="Text" Name="Car_Per"></asp:ControlParameter>
        </SelectParameters>
        </asp:ObjectDataSource> 
        <ajaxToolkit:CollapsiblePanelExtender id="cpe" runat="Server" TargetControlID="OrdersDetailPanel" ExpandDirection="Vertical" CollapsedImage="~/images/expand.jpg" ExpandedImage="~/images/collapse.jpg" ImageControlID="imgplus" ScrollContents="false" AutoExpand="False" AutoCollapse="False" CollapseControlID="POrderHeader" ExpandControlID="POrderHeader" Collapsed="True" CollapsedSize="0"></ajaxToolkit:CollapsiblePanelExtender> 
    </ItemTemplate>
</asp:DataList> 
    <table style="width:400px;">
        <tr>
            <td>
                &nbsp;
            </td>
            <td>
                &nbsp;
            </td>
            <td>
                &nbsp;
            </td>
        </tr>
        <tr>
            <td align="center">
                &nbsp;
                <asp:ImageButton ID="BtnRLIM" runat="server" 
                    ImageUrl="~/images/Operaciones/cartera1.png" ToolTip="Reliquidar Intereses" />
            </td>
            <td align="center">
                &nbsp;
                <asp:ImageButton ID="BtnProgramar" runat="server" Enabled="False" 
                    ImageUrl="~/images/Operaciones/money.png" ToolTip="Programar Pagos" />
            </td>
            <td>
                &nbsp;
            </td>
        </tr>
        <tr>
            <td align="center">
                &nbsp; 1. Reliquidar Intereses
            </td>
            <td align="center">
                &nbsp; 2. Programar Pagos
            </td>
            <td>
                &nbsp;
            </td>
        </tr>
    </table>
</asp:View>
</asp:MultiView>
<br />
</contenttemplate>
</asp:UpdatePanel>&nbsp;&nbsp;<br />
<br />
<br />
<br />
    &nbsp;<asp:ObjectDataSource ID="ObjCartera" runat="server" OldValuesParameterFormatString="original_{0}"
        SelectMethod="GetCartera" TypeName="AcuerdosP">
        <SelectParameters>
            <asp:ControlParameter ControlID="CbCdec" Name="Car_Cdec" PropertyName="SelectedValue"
                Type="String" />
            <asp:ControlParameter ControlID="Nit" Name="Car_Nit" PropertyName="Text" />
        </SelectParameters>
    </asp:ObjectDataSource>
    <asp:ObjectDataSource ID="ObjTer" runat="server" OldValuesParameterFormatString="original_{0}"
        SelectMethod="GetByIde" TypeName="Signus.Terceros">
        <SelectParameters>
            <asp:ControlParameter ControlID="Nit" Name="IDE" PropertyName="Text" Type="String" />
        </SelectParameters>
    </asp:ObjectDataSource>
    <br />
    <br />
                    <asp:UpdatePanel id="UpdatePanel2" runat="server" UpdateMode="Conditional">
        <contenttemplate>
<!-- Mensaje de Salida--><asp:Button style="DISPLAY: none" id="hiddenTargetControlForModalPopup2" runat="server"></asp:Button> <ajaxToolkit:ModalPopupExtender id="ModalPopupTer" runat="server" BackgroundCssClass="modalBackground" BehaviorID="programmaticModalPopupBehavior2" DropShadow="True" PopupControlID="programmaticPopup2" PopupDragHandleControlID="programmaticPopupDragHandle2" RepositionMode="RepositionOnWindowScroll" TargetControlID="hiddenTargetControlForModalPopup2">
             </ajaxToolkit:ModalPopupExtender> <asp:Panel id="programmaticPopup2" runat="server" Width="625px" Height="229%" CssClass="ModalPanel2"><asp:Panel id="programmaticPopupDragHandle2" runat="Server" Height="30px" CssClass="BarTitleModal2">
                     <div style="padding-right: 5px; padding-left: 5px; padding-bottom: 5px; vertical-align: middle;
                         padding-top: 5px">
                         <div style="float: left">
                             Buscar Tercero</div>
                         <div style="float: right">
                             <input id="BtnCerrar" type="button" value="X" onclick="javascript:CerrarTercero();" /></div>
                     </div>
                 </asp:Panel> &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;<BR />&nbsp; &nbsp; &nbsp;&nbsp; <uc1:ConsultaTer id="ConsultaTer1" runat="server" ret="AR" Tipo="AR"></uc1:ConsultaTer> <BR /><BR /><BR /></asp:Panel> 
</contenttemplate>
        <triggers>
<asp:AsyncPostBackTrigger ControlID="BtnBuscDP" EventName="Click"></asp:AsyncPostBackTrigger>
</triggers>
    </asp:UpdatePanel><br />
    <asp:UpdateProgress id="UpdateProgress1" runat="server" AssociatedUpdatePanelID="UpdatePanel1">
        <progresstemplate>
<DIV class="Loading"><IMG title="" alt="" src="../../images/loading.gif" /> &nbsp;Cargando 
    … </DIV>
</progresstemplate>
    </asp:UpdateProgress>
                    </div>
    
    <asp:ObjectDataSource ID="ObjCalVigencias" runat="server" OldValuesParameterFormatString="original_{0}"
        SelectMethod="GetVigencias" TypeName="Calendario">
        <SelectParameters>
            <asp:ControlParameter ControlID="CbCdec" Name="Cla_Dec" PropertyName="SelectedValue"
                Type="String" />
        </SelectParameters>
    </asp:ObjectDataSource>
    &nbsp;

<asp:HiddenField ID="Cla_Dec" runat="server" Value="01" /><asp:HiddenField ID="HdFODE" runat="server" Value="01" />
    <asp:HiddenField ID="HdTAG" runat="server" Value="01" />

    <asp:ObjectDataSource ID="ObjCDec" runat="server" OldValuesParameterFormatString="original_{0}"
        SelectMethod="GetCDEC_PorNit" TypeName="CDeclaraciones">
        <SelectParameters>
            <asp:ControlParameter ControlID="Nit" Name="Nit" PropertyName="Text" Type="String" />
        </SelectParameters>
    </asp:ObjectDataSource>
</asp:Content>

