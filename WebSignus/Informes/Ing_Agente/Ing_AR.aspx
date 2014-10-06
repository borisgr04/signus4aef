<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="Ing_AR.aspx.vb" Inherits="Ing_AR" title="Untitled Page"  enableEventValidation="False"%>

<%@ Register Src="../../CtrlUsr/Terceros/ConsultaTer.ascx" TagName="ConsultaTer" TagPrefix="uc1" %>
<%@ Register Assembly="ControlesWeb" Namespace="ControlesWeb" TagPrefix="cc1" %>


<%@ Register assembly="Microsoft.ReportViewer.WebForms, Version=10.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a" namespace="Microsoft.Reporting.WebForms" tagprefix="rsweb" %>


<asp:Content ID="Content1" ContentPlaceHolderID="SampleContent" Runat="Server">
<script type='text/javascript'>

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
      
         if(valFecha(document.aspnetForm.<%=Me.TFI.ClientID%>)==true  &&  valFecha(document.aspnetForm.<%=Me.TFF.ClientID%>)==true) 
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



    function cancelClick() {
        var label = $get('ctl00_SampleContent_LbRpt');
        //label.innerHTML = 'You hit cancel in the Confirm dialog on ' + (new Date()).localeFormat("T") + '.';
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
        
         function enviar(tdoc,ced,dv,rsocial,tip_ter)
        {
            if(tip_ter=='AR'){
                document.aspnetForm.<%=Me.TNit.ClientID%>.value=ced;
                document.aspnetForm.<%=Me.TNom.ClientID%>.value=rsocial;
               
            }
            var modalPopupBehavior = $find('programmaticModalPopupBehavior');
            modalPopupBehavior.hide();
            //__doPostBack("= button.ClientID %>","");
            //__doPostBack("= CbCdec.ClientID %>","");
            
            
        }
        
        function UpdateCombo()
        {
          //   var no =document.getElementById(" CbCdec.ClientID %>").options.length;
        //    if (no==1)  __doPostBack("= CbCdec.ClientID %>","");
            
            
        }

    </script>
<div class="demoarea">
    <ajaxToolkit:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server" EnablePageMethods="true" EnableScriptGlobalization="True" EnableScriptLocalization="True">
    </ajaxToolkit:ToolkitScriptManager>
    &nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<br />
    
    
    
    
    <asp:Label ID="Tit" runat="server" CssClass="Titulo" Text="Consulta de Ingresos"></asp:Label><p>
            &nbsp; &nbsp;<asp:ValidationSummary ID="ValidationSummary1" runat="server" BackColor="SeaShell" BorderColor="SeaShell" BorderStyle="Solid" BorderWidth="1px" ForeColor="Maroon" Height="52px" Width="579px" />
            <p>
            &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
            &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;&nbsp;</p>
        <p>
            &nbsp;<asp:UpdatePanel id="UpdatePanel1" runat="server" UpdateMode="Conditional">
                <contenttemplate>
&nbsp; <asp:Label id="MsgResult" runat="server" __designer:wfdid="w182"></asp:Label>&nbsp;<BR /><TABLE style="WIDTH: 441px; HEIGHT: 57px" id="Table2"><TBODY><TR><TD style="WIDTH: 72px; HEIGHT: 7px; TEXT-ALIGN: right">
                        <asp:CheckBox ID="CBFEC" runat="server" __designer:wfdid="w192" 
                            AutoPostBack="True" TextAlign="Left" Width="73px" />
                        </TD><TD style="WIDTH: 83px; HEIGHT: 7px; TEXT-ALIGN: right"><asp:Label id="Label10" runat="server" Text="Fecha_Inicial" Width="74px" __designer:wfdid="w186"></asp:Label></TD><TD style="WIDTH: 65px; HEIGHT: 7px"><asp:TextBox id="TFI" runat="server" Width="113px" __designer:wfdid="w187"></asp:TextBox>&nbsp;</TD>
                        <TD style="WIDTH: 95px; HEIGHT: 7px; TEXT-ALIGN: right" colspan="2">&nbsp;</TD><TD style="WIDTH: 95px; HEIGHT: 7px; TEXT-ALIGN: right"><asp:Label id="Label11" runat="server" Text="Fecha_Final" Width="74px" __designer:wfdid="w190"></asp:Label></TD><TD style="WIDTH: 95px; HEIGHT: 7px; TEXT-ALIGN: right"><asp:TextBox id="TFF" runat="server" Width="95px" __designer:wfdid="w191"></asp:TextBox></TD></TR><TR><TD style="WIDTH: 72px; HEIGHT: 7px; TEXT-ALIGN: right">
                        <asp:CheckBox id="CBCLA" runat="server" Width="73px" TextAlign="Left" 
                            AutoPostBack="True" __designer:wfdid="w192"></asp:CheckBox></TD><TD style="WIDTH: 83px; HEIGHT: 7px; TEXT-ALIGN: right"><asp:Label id="Label2" runat="server" Text="Clase Declaracion" Width="96px" __designer:wfdid="w193"></asp:Label></TD>
                        <TD style="HEIGHT: 7px; TEXT-ALIGN: left" colSpan=5><asp:DropDownList id="CMBCLADEC" runat="server" Width="285px" AutoPostBack="True" DataValueField="cld_cod" DataTextField="cld_nom" DataSourceID="ObjClaseDec" __designer:wfdid="w194"></asp:DropDownList></TD></TR><TR><TD style="WIDTH: 72px; HEIGHT: 7px; TEXT-ALIGN: right">
                        <asp:CheckBox id="CBCON" runat="server" Width="73px" TextAlign="Left" 
                            __designer:wfdid="w195"></asp:CheckBox></TD><TD style="WIDTH: 83px; HEIGHT: 7px; TEXT-ALIGN: right"><asp:Label id="lcon" runat="server" Height="17px" Text="Conceptos" Width="41px" __designer:wfdid="w196"></asp:Label></TD>
                        <TD style="HEIGHT: 7px; TEXT-ALIGN: left" colSpan=5><asp:DropDownList id="CMBCON" runat="server" Width="289px" DataValueField="CCAR_COD" DataTextField="CCAR_NOM" DataSourceID="ObjConc" __designer:wfdid="w197"></asp:DropDownList></TD></TR><TR><TD style="WIDTH: 72px; HEIGHT: 33px; TEXT-ALIGN: right">
                        <asp:CheckBox id="CBANO" runat="server" TextAlign="Left" 
                            __designer:wfdid="w198"></asp:CheckBox></TD><TD style="WIDTH: 83px; HEIGHT: 33px; TEXT-ALIGN: right">&nbsp; <asp:Label id="Label1" runat="server" Text="Año Gravable" Width="74px" __designer:wfdid="w199"></asp:Label></TD><TD style="WIDTH: 65px; HEIGHT: 33px"><asp:DropDownList id="CMBANO" runat="server" Width="95px" DataValueField="CAL_VIG" DataTextField="CAL_VIG" DataSourceID="ObjCalVigencias" __designer:wfdid="w200"></asp:DropDownList></TD>
                        <TD style="WIDTH: 95px; HEIGHT: 33px; TEXT-ALIGN: right" colspan="2">
                            <asp:CheckBox id="CBPER" runat="server" Width="73px" TextAlign="Left" 
                                __designer:wfdid="w201"></asp:CheckBox></TD><TD style="WIDTH: 95px; HEIGHT: 33px; TEXT-ALIGN: right"><asp:Label id="Label3" runat="server" Text="Periodo Gravable" Width="94px" __designer:wfdid="w202"></asp:Label></TD><TD style="WIDTH: 95px; HEIGHT: 33px; TEXT-ALIGN: right"><asp:DropDownList id="CMBPER" runat="server" Width="102px" DataValueField="CAL_PER" DataTextField="CAL_DES" DataSourceID="ObjCal" __designer:wfdid="w203"></asp:DropDownList></TD></TR><TR>
                        <TD style="HEIGHT: 33px; TEXT-ALIGN: right">
                            <asp:CheckBox ID="CBAR" runat="server" __designer:wfdid="w192" 
                                AutoPostBack="True" TextAlign="Left" Width="73px" />
                        </TD>
                        <td style="HEIGHT: 33px; TEXT-ALIGN: right">
                            <asp:Label ID="Label6" runat="server" __designer:wfdid="w228" 
                                Text="Agente Recaudador"></asp:Label>
                        </td>
                        <TD style="WIDTH: 65px; HEIGHT: 33px"><asp:TextBox id="TNIT" runat="server" __designer:wfdid="w205"></asp:TextBox></TD><TD style="WIDTH: 95px; HEIGHT: 33px; TEXT-ALIGN: left">&nbsp;<asp:LinkButton id="LinkButton1" onclick="LinkButton1_Click" runat="server" __designer:wfdid="w206">...</asp:LinkButton> </TD>
                        <td colspan="3" style="HEIGHT: 33px; TEXT-ALIGN: left">
                            <asp:TextBox ID="TNom" runat="server" Width="190px" Enabled="False"></asp:TextBox>
                        </td>
                        </TR><TR><TD style="WIDTH: 72px; HEIGHT: 24px; TEXT-ALIGN: right"></TD><TD style="WIDTH: 83px; HEIGHT: 24px; TEXT-ALIGN: right"></TD><TD style="WIDTH: 65px; HEIGHT: 24px">
                            <asp:ImageButton ID="BtnBuscar" runat="server" __designer:wfdid="w207" 
                                AlternateText="Buscar" ImageUrl="~/images/Operaciones/search2.png" 
                                onclick="BtnBuscar_Click" ToolTip="Buscar" ValidationGroup="Buscar" />
                            </TD><TD style="WIDTH: 95px; HEIGHT: 24px" colspan="2">
                                <asp:ImageButton ID="Btncancel" runat="server" __designer:wfdid="w208" 
                                    AlternateText="Cancelar" ImageUrl="~/images/Operaciones/Deshacer.png" 
                                    ToolTip="Cancelar" />
                            </TD><TD style="WIDTH: 95px; HEIGHT: 24px">&nbsp;</TD><TD style="WIDTH: 95px; HEIGHT: 24px">
                            &nbsp;</TD></TR><TR><TD style="WIDTH: 72px; HEIGHT: 24px; TEXT-ALIGN: right">&nbsp;</TD><TD style="WIDTH: 83px; HEIGHT: 24px; TEXT-ALIGN: right"></TD><TD style="WIDTH: 65px; HEIGHT: 24px">
                            <asp:Label ID="Label4" runat="server" __designer:wfdid="w209" Height="23px" 
                                Text="Buscar" Width="49px"></asp:Label>
                            </TD><TD style="WIDTH: 95px; HEIGHT: 24px" colspan="2">
                                <asp:Label ID="Label5" runat="server" __designer:wfdid="w210" Height="17px" 
                                    Text="Cancelar" Width="49px"></asp:Label>
                            </TD><TD style="WIDTH: 95px; HEIGHT: 24px">&nbsp;</TD><TD style="WIDTH: 95px; HEIGHT: 24px">
                            &nbsp;</TD></TR></TBODY></TABLE>&nbsp; 
                    <asp:HiddenField ID="HiddenField1" runat="server" />
                    <BR /><ajaxToolkit:CalendarExtender id="CalendarExtender1" runat="server" TargetControlID="TFI" __designer:wfdid="w211"></ajaxToolkit:CalendarExtender><ajaxToolkit:CalendarExtender id="CalendarExtender2" runat="server" TargetControlID="TFF" __designer:wfdid="w212"></ajaxToolkit:CalendarExtender> 
                            
</contenttemplate>
                <triggers>
<asp:AsyncPostBackTrigger ControlID="CMBCLADEC" EventName="SelectedIndexChanged"></asp:AsyncPostBackTrigger>
<asp:AsyncPostBackTrigger ControlID="CMBANO" EventName="SelectedIndexChanged"></asp:AsyncPostBackTrigger>
<asp:AsyncPostBackTrigger ControlID="CBCLA" EventName="CheckedChanged"></asp:AsyncPostBackTrigger>
<asp:PostBackTrigger ControlID="BtnBuscar"></asp:PostBackTrigger>
<asp:PostBackTrigger ControlID="Btncancel"></asp:PostBackTrigger>
</triggers>
            </asp:UpdatePanel>&nbsp; &nbsp;&nbsp;
        </p>
        <rsweb:ReportViewer ID="ReportViewer1" runat="server" Font-Names="Verdana" 
        Font-Size="8pt" InteractiveDeviceInfos="(Colección)" 
        WaitMessageFont-Names="Verdana" WaitMessageFont-Size="14pt" Width="100%">
            <LocalReport ReportPath="Report\Consultas\RptIngAgen2012.rdlc">
                <DataSources>
                    <rsweb:ReportDataSource DataSourceId="ObjectDataSource1" Name="DataSet1" />
                </DataSources>
            </LocalReport>
    </rsweb:ReportViewer>
    <asp:ObjectDataSource ID="ObjectDataSource1" runat="server" 
        OldValuesParameterFormatString="original_{0}" SelectMethod="Get_Ing_Agen" 
        TypeName="Informes">
        <SelectParameters>
            <asp:ControlParameter ControlID="HiddenField1" Name="Filtro" 
                PropertyName="Value" Type="String" />
        </SelectParameters>
    </asp:ObjectDataSource>
        <p>
            &nbsp; &nbsp; &nbsp;&nbsp;
            <asp:ObjectDataSource ID="ObjCalVigencias" runat="server" OldValuesParameterFormatString="original_{0}"
                SelectMethod="GetVigencias" TypeName="Calendario">
                <SelectParameters>
                    <asp:ControlParameter ControlID="CMBCLADEC" Name="Cla_Dec" PropertyName="SelectedValue"
                        Type="String" />
                </SelectParameters>
            </asp:ObjectDataSource>
            <asp:ObjectDataSource ID="ObjCal" runat="server" OldValuesParameterFormatString="original_{0}"
                SelectMethod="GetPErClaseDec" TypeName="Informes">
                <SelectParameters>
                    <asp:ControlParameter ControlID="CMBCLADEC" Name="Cla_Dec" PropertyName="SelectedValue"
                        Type="String" />
                    <asp:ControlParameter ControlID="CMBANO" Name="Vigencia" PropertyName="SelectedValue"
                        Type="String" />
                </SelectParameters>
            </asp:ObjectDataSource>
            <asp:ObjectDataSource ID="ObjClaseDec" runat="server" OldValuesParameterFormatString="original_{0}"
                SelectMethod="GetcargarTipoDecla" TypeName="Informes"></asp:ObjectDataSource>
            <asp:ObjectDataSource ID="ObjConc" runat="server" OldValuesParameterFormatString="original_{0}"
                SelectMethod="GetConceptos" TypeName="Informes"></asp:ObjectDataSource>
            &nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<br />
            &nbsp;<asp:UpdatePanel id="UpdatePanel2" runat="server" UpdateMode="Conditional">
        <contenttemplate>
<!-- Mensaje de Salida--><asp:Button style="DISPLAY: none" id="hiddenTargetControlForModalPopup" runat="server" __designer:wfdid="w221"></asp:Button> <ajaxToolkit:ModalPopupExtender id="ModalPopup" runat="server" BackgroundCssClass="modalBackground" BehaviorID="programmaticModalPopupBehavior" DropShadow="True" PopupControlID="programmaticPopup" PopupDragHandleControlID="programmaticPopupDragHandle" RepositionMode="RepositionOnWindowScroll" TargetControlID="hiddenTargetControlForModalPopup" __designer:wfdid="w222">
            </ajaxToolkit:ModalPopupExtender> <asp:Panel id="programmaticPopup" runat="server" Height="229%" Width="625px" CssClass="ModalPanel2" __designer:wfdid="w223"><asp:Panel id="programmaticPopupDragHandle" runat="Server" Height="30px" CssClass="BarTitleModal2" __designer:wfdid="w224">
                    <div style="padding: 5px; vertical-align: middle;">
                        <div style="float: left;">
                            Buscar Agente Recaudador
                        </div>
                    </div>
                </asp:Panel> &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;<BR />&nbsp; &nbsp; &nbsp;&nbsp; 
                <uc1:consultater id="ConsultaTer1" runat="server" ret="AR" tipo="AR" 
                    __designer:wfdid="w225"></uc1:consultater> <BR /><BR /><BR /></asp:Panel> 
</contenttemplate>
        <triggers>
<asp:AsyncPostBackTrigger ControlID="LinkButton1" EventName="Click"></asp:AsyncPostBackTrigger>
</triggers>
    </asp:UpdatePanel>
    </p>
</div>
</asp:Content>

