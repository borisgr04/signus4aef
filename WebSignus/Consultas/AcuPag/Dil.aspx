<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="Dil.aspx.vb" Inherits="Procesos_AcPa_Dil" title="Consulta de Acuerdos de Pagos" %>
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
    
    <asp:UpdatePanel id="UpdatePanel1" runat="server">
        <contenttemplate>
<asp:Label id="MsgResult" runat="server" __designer:wfdid="w2"></asp:Label><BR />
<TABLE width=600 __designer:dtid="844424930131979">
<TBODY><TR __designer:dtid="844424930131980">
<TD style="HEIGHT: 13px" class="TDNegroFila" __designer:dtid="844424930131981">
<asp:Label id="Label10" runat="server" Font-Bold="True" __designer:dtid="844424930131982" __designer:wfdid="w2" Text="AGENTE RECAUDADOR"></asp:Label>&nbsp;&nbsp; 
<asp:Button style="DISPLAY: none" id="button" onclick="button_Click" runat="server" __designer:dtid="3096246218653697" __designer:wfdid="w3"></asp:Button>
</TD>
</TR>
<TR __designer:dtid="844424930131984"><TD style="HEIGHT: 169px" __designer:dtid="844424930131985">
<TABLE width="100%" __designer:dtid="844424930131986">
<TBODY>
<TR onmouseover="Resaltar_On(this);" onmouseout="Resaltar_Off(this);" __designer:dtid="844424930131987">
<TD style="WIDTH: 25px; HEIGHT: 15px" __designer:dtid="844424930131988">
<asp:Label id="Label45" runat="server" Width="135px" Font-Bold="True" __designer:dtid="844424930131989" __designer:wfdid="w4" Text="IDENTIFICACIÓN" CssClass="TitDecl">
</asp:Label></TD><TD style="WIDTH: 71px; HEIGHT: 25px" __designer:dtid="844424930131990">&nbsp;
<asp:Label id="Label2" runat="server" Font-Bold="True" __designer:dtid="844424930131991" __designer:wfdid="w5" Text="DV" CssClass="TitDecl">
</asp:Label>
</TD>
<TD style="WIDTH: 131px; HEIGHT: 15px" __designer:dtid="844424930131992">
<asp:Label id="Label11" runat="server" Font-Bold="True" __designer:dtid="844424930131993" __designer:wfdid="w6" Text="RAZON SOCIAL" CssClass="TitDecl"></asp:Label>
</TD>
<TD style="WIDTH: 253px; HEIGHT: 15px" __designer:dtid="844424930131994" 
        align="right">
    <asp:LinkButton ID="lbVolver" runat="server">Volver</asp:LinkButton>
</TD>
</TR>
<TR onmouseover="Resaltar_On(this);" onmouseout="Resaltar_Off(this);" __designer:dtid="844424930131995">
<TD style="HEIGHT: 19px; TEXT-ALIGN: right" __designer:dtid="844424930131996">
<asp:TextBox id="Nit" runat="server" __designer:dtid="844424930131997" __designer:wfdid="w7" Enabled="False"></asp:TextBox>&nbsp; 
</TD>
<TD style="WIDTH: 51px; HEIGHT: 19px" __designer:dtid="844424930131998">-<asp:TextBox id="Dv" runat="server" Width="17px" __designer:dtid="844424930131999" __designer:wfdid="w8" Enabled="False"></asp:TextBox>&nbsp;<asp:Button accessKey="B" id="BtnBuscDP" onclick="BtnBuscar_Click" runat="server" __designer:wfdid="w9" Text="..." UseSubmitBehavior="False" ToolTip="Buscar Agente Recaudador"></asp:Button></TD><TD style="HEIGHT: 19px" colSpan=2 __designer:dtid="844424930132000"><asp:TextBox id="Agente" runat="server" Width="332px" __designer:dtid="844424930132001" __designer:wfdid="w10" Enabled="False"></asp:TextBox></TD></TR><TR onmouseover="Resaltar_On(this);" onmouseout="Resaltar_Off(this);"><TD style="HEIGHT: 19px" colSpan=4><asp:FormView id="FormView1" runat="server" __designer:wfdid="w20" DataSourceID="ObjTer"><ItemTemplate>
<TABLE width="100%" __designer:dtid="3659174697238547"><TBODY>
<TR onmouseover="Resaltar_On(this);" onmouseout="Resaltar_Off(this);" __designer:dtid="3659174697238548">
<TD style="HEIGHT: 20px" colSpan=15 __designer:dtid="3659174697238549"><asp:Label id="Label7" runat="server" Font-Bold="True" Text="REPRESENTANTE LEGAL" __designer:dtid="3659174697238550" __designer:wfdid="w21" CssClass="TitDecl"></asp:Label></TD></TR><TR onmouseover="Resaltar_On(this);" onmouseout="Resaltar_Off(this);" __designer:dtid="3659174697238551"><TD style="WIDTH: 83px; HEIGHT: 20px" __designer:dtid="3659174697238555"><asp:Label id="Label32" runat="server" Text="IDENTIFICACIÓN" __designer:dtid="3659174697238556" __designer:wfdid="w22" CssClass="TitDecl"></asp:Label></TD><TD style="WIDTH: 25px" __designer:dtid="3659174697238557"></TD><TD style="WIDTH: 25px" __designer:dtid="3659174697238558"></TD><TD style="WIDTH: 345px; HEIGHT: 20px" colSpan=12 __designer:dtid="3659174697238559">&nbsp;<asp:Label id="Label35" runat="server" Text="APELLIDOS Y NOMBRES" __designer:dtid="3659174697238560" __designer:wfdid="w23" CssClass="TitDecl"></asp:Label></TD></TR><TR onmouseover="Resaltar_On(this);" onmouseout="Resaltar_Off(this);" __designer:dtid="3659174697238561"><TD style="WIDTH: 83px; HEIGHT: 7px" __designer:dtid="3659174697238565"><asp:TextBox id="TXTNRODOC_PD" runat="server" Width="94px" Text='<%# Eval("TER_CED") %>' __designer:dtid="3659174697238566" __designer:wfdid="w24" Enabled="False"></asp:TextBox> </TD><TD style="WIDTH: 25px; HEIGHT: 7px" __designer:dtid="3659174697238567">&nbsp;</TD><TD style="WIDTH: 25px; HEIGHT: 7px" __designer:dtid="3659174697238568">&nbsp;</TD><TD style="WIDTH: 345px; HEIGHT: 7px" colSpan=12 __designer:dtid="3659174697238569"><asp:TextBox id="TXTRAZSOC_PD" runat="server" Width="336px" Text='<%# Eval("TER_REP") %>' __designer:dtid="3659174697238570" __designer:wfdid="w25" Enabled="False"></asp:TextBox></TD></TR></TBODY></TABLE>
</ItemTemplate>
<EmptyDataTemplate>
<asp:Label id="Label6" runat="server" Text="No tiene Siganatarios Asignados" CssClass="nodata" __designer:wfdid="w160"></asp:Label>
</EmptyDataTemplate>
</asp:FormView></TD></TR><TR onmouseover="Resaltar_On(this);" onmouseout="Resaltar_On(this);" __designer:dtid="844424930132002"><TD style="HEIGHT: 19px" colSpan=4 __designer:dtid="844424930132003"><asp:Label id="Label1" runat="server" Width="261px" Font-Bold="True" __designer:dtid="844424930132004" __designer:wfdid="w11" Text="SELECCIONE LA CLASE DE DECLARACION" CssClass="TitDecl"></asp:Label> <asp:DropDownList id="CbCdec" runat="server" __designer:dtid="844424930132007" __designer:wfdid="w12" DataSourceID="ObjCDec" OnSelectedIndexChanged="CbCdec_SelectedIndexChanged" AutoPostBack="True" DataTextField="CLD_NOM" DataValueField="CLD_COD"></asp:DropDownList></TD></TR></TBODY></TABLE></TD></TR></TBODY></TABLE><TABLE width="100%">
<TBODY><TR onmouseover="Resaltar_On(this);" class="TbDecl" onmouseout="Resaltar_Off(this);">
<TD style="WIDTH: 596px">ACUERDOS DE PAGO&nbsp;</TD></TR><TR>
    <TD style="WIDTH: 596px"><BR />
<asp:GridView id="GridView2" runat="server" DataSourceID="ObjAcuerdosP" OnSelectedIndexChanged="GridView2_SelectedIndexChanged" 
AutoGenerateColumns="False" AllowPaging="True" AllowSorting="True" DataKeyNames="NUMERO" 
                OnRowCommand="GridView2_RowCommand" Width="500px">
<Columns>
<asp:BoundField DataField="Clase_Dec" HeaderText="Declaracion" SortExpression="Clase_Dec">
    <HeaderStyle HorizontalAlign="Left" />
            </asp:BoundField>
<asp:BoundField DataField="NUMERO" HeaderText="No." SortExpression="NUMERO">
    <HeaderStyle HorizontalAlign="Left" />
            </asp:BoundField>
<asp:BoundField DataField="FECHA_REGISTRO" HeaderText="Fecha" 
                SortExpression="FECHA_REGISTRO" DataFormatString="{0:d}">
    <HeaderStyle HorizontalAlign="Left" />
            </asp:BoundField>
<asp:BoundField DataField="VALOR_" HeaderText="Valor" DataFormatString="{0:c}">
    <HeaderStyle HorizontalAlign="Right" />
    <ItemStyle HorizontalAlign="Right" />
            </asp:BoundField>
<asp:CommandField ShowSelectButton="True" SelectText=""></asp:CommandField>
<asp:ButtonField CommandName="VerCuotas" Text="Ver Cuotas"></asp:ButtonField>
<asp:ButtonField CommandName="VerDetalle" Text="Ver Detalles"></asp:ButtonField>
</Columns>
</asp:GridView><BR /><asp:MultiView id="MultiView1" runat="server" __designer:wfdid="w54"><asp:View id="View1" runat="server" __designer:wfdid="w55">
<asp:DetailsView id="dvAP" runat="server" Width="586px" Height="69px" ForeColor="#333333" 
                __designer:wfdid="w50" DataSourceID="ObjAcuerdosP" CellPadding="4" 
                HeaderText="ACUERDOS DE PAGO" AllowPaging="True" 
                EmptyDataText="NO TIENE ACUERDOS DE PAGOS REGISTRADOS" DataKeyNames="NUMERO" 
                AutoGenerateRows="False">
<FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White"></FooterStyle>

<CommandRowStyle BackColor="#E2DED6" Font-Bold="True"></CommandRowStyle>

<RowStyle BackColor="#F7F6F3" ForeColor="#333333"></RowStyle>

<FieldHeaderStyle BackColor="#E9ECF1" Font-Bold="True"></FieldHeaderStyle>

<PagerStyle HorizontalAlign="Center" BackColor="#284775" ForeColor="White"></PagerStyle>

    <Fields>
        <asp:BoundField DataField="NUMERO" HeaderText="Acuerdo No." />
        <asp:BoundField DataField="REPRESENTANTE_LEGAL" 
            HeaderText="Representante Legal" />
        <asp:BoundField DataField="NIT_REP_LEGAL" HeaderText="Cedula" />
        <asp:BoundField DataField="LUGAR_EXPEDICION" HeaderText="Lugar de Expedicion" />
        <asp:BoundField DataField="GARANTIA" HeaderText="Garantia" />
        <asp:BoundField DataField="NUM_CUOTAS" HeaderText="Numero de Cuotas" />
        <asp:BoundField DataField="PORCENTAJE_CUO_INI" 
            HeaderText="Porcentaje Cuota Inical" />
        <asp:BoundField DataField="VALOR_CUOTA_INI" HeaderText="Valor Cuota Incial" />
    </Fields>

<HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White"></HeaderStyle>

<EditRowStyle BackColor="#999999"></EditRowStyle>

<AlternatingRowStyle BackColor="White" ForeColor="#284775"></AlternatingRowStyle>
</asp:DetailsView></asp:View> <asp:View id="View2" runat="server" __designer:wfdid="w56">
<asp:GridView id="GridView1" runat="server" __designer:wfdid="w51" DataSourceID="ObjCuotas" Width="400px"
                    AutoGenerateColumns="False">
    <Columns>
        <asp:BoundField DataField="CUAP_CUNU" HeaderText="Cuota No." />
        <asp:BoundField DataField="CUAP_FEPA" DataFormatString="{0:d}" 
            HeaderText="Fecha de Pago" />
        <asp:BoundField DataField="CUAP_VALO" DataFormatString="{0:c}" 
            HeaderText="Valor" />
        <asp:BoundField DataField="CUAP_PAGO" HeaderText="Pagado" />
        <asp:BoundField DataField="CUAP_SALDO" DataFormatString="{0:c}" 
            HeaderText="Saldo" />
    </Columns>
                </asp:GridView></asp:View></asp:MultiView>&nbsp;&nbsp; <asp:ObjectDataSource id="ObjCuotas" runat="server" __designer:dtid="2814749767106569" TypeName="AcuerdosP" SelectMethod="GetCuotas" OldValuesParameterFormatString="original_{0}" __designer:wfdid="w52"><SelectParameters __designer:dtid="2814749767106570">
<asp:ControlParameter ControlID="GridView2" PropertyName="SelectedValue" Name="cuap_apnu"></asp:ControlParameter>
</SelectParameters>
</asp:ObjectDataSource></TD></TR></TBODY></TABLE>
</contenttemplate>
                    </asp:UpdatePanel>&nbsp;&nbsp;<br />
    <br />
    <br />
    <asp:ObjectDataSource ID="ObjAcuerdosP" runat="server" OldValuesParameterFormatString="original_{0}"
        SelectMethod="GetAcuerdosP" TypeName="AcuerdosP">
        <SelectParameters>
            <asp:ControlParameter ControlID="CbCdec" Name="Car_Cdec" PropertyName="SelectedValue"
                Type="String" />
            <asp:ControlParameter ControlID="Nit" Name="Car_Nit" PropertyName="Text" />
        </SelectParameters>
    </asp:ObjectDataSource>
    <asp:ObjectDataSource ID="ObjCartera" runat="server" OldValuesParameterFormatString="original_{0}"
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
    </asp:UpdatePanel>
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

