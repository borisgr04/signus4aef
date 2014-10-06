<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="IngxImp.aspx.vb" Inherits="Informes_IngxImp" title="IngxImp"  UICulture="auto" Culture="auto"%>
<%@ Register Assembly="Microsoft.ReportViewer.WebForms, Version=10.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a"
    Namespace="Microsoft.Reporting.WebForms" TagPrefix="rsweb" %>
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


/*function ValIsFecha (source, arguments){
       if (document.aspnetForm.<%=Me.TFI.ClientID%>.value=='')
        {
          arguments.IsValid=false; 
          return;
        }
        else{
          var validar=''
          validar=ValFecha2(document.aspnetForm.<%=Me.TFI.ClientID%>.value);
          if (validar)
           {
              arguments.IsValid=false; 
              return;
           }
          arguments.IsValid=true;
        }
        alert(valida)
        }*/
        
       
</script>

<div class="demoarea"> 
    <div class="demoarea">
        <ajaxToolkit:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server" EnableScriptGlobalization="true"
            EnableScriptLocalization="true">
        </ajaxToolkit:ToolkitScriptManager>
                    <asp:Label ID="Tit" runat="server" CssClass="Titulo" 
            Text="Consulta de Ingresos " Font-Bold="True"></asp:Label>
        
            <asp:UpdatePanel id="UpdatePanel1" runat="server" UpdateMode="Conditional">
                <contenttemplate>
&nbsp; <asp:Label id="MsgResult" runat="server"></asp:Label> 
                    <TABLE style="WIDTH: 645px; HEIGHT: 57px" id="Table2"><TBODY><TR>
                        <TD style="TEXT-ALIGN: left; font-weight: 700; background-color: #F2F2F2;" 
                            colspan="5">CLASE DE DECLARACION</TD></TR><TR>
                            <TD style="WIDTH: 119px; HEIGHT: 7px; TEXT-ALIGN: left">
                                <asp:CheckBox ID="CBCLA" runat="server" AutoPostBack="True" Checked="True" 
                                    Text="Clase de Declaración" />
                            </TD><TD style="HEIGHT: 7px" colspan="4">
                                <asp:DropDownList ID="CMBCLADEC" runat="server" AutoPostBack="True" 
                                    DataSourceID="ObjClaseDec" DataTextField="cld_nom" DataValueField="cld_cod" 
                                    Width="253px">
                                </asp:DropDownList>
                            </TD></TR>
                        <tr>
                            <td colspan="5" 
                                style="HEIGHT: 7px; TEXT-ALIGN: left; font-weight: 700; background-color: #F0F0F0;">
                                FECHA DEL INGRESO</td>
                        </tr>
                        <tr>
                            <td style="WIDTH: 119px; HEIGHT: 7px; TEXT-ALIGN: left">
                                <asp:CheckBox ID="CBFEC" runat="server" Text="Fecha Inicial" />
                            </td>
                            <td colspan="2" style="WIDTH: 76px; HEIGHT: 7px">
                                <asp:TextBox ID="TFI" runat="server" Width="95px"></asp:TextBox>
                                <asp:CustomValidator ID="ValCutFI" runat="server" 
                                    ClientValidationFunction="ValIsFecha" ControlToValidate="TFI" 
                                    ErrorMessage="Digite Una Fecha Correcta" Height="14px" Width="15px">*</asp:CustomValidator>
                            </td>
                            <td style="WIDTH: 95px; HEIGHT: 7px; TEXT-ALIGN: right">
                                <asp:Label ID="Label11" runat="server" Text="Fecha_Final" Width="74px"></asp:Label>
                            </td>
                            <td style="WIDTH: 95px; HEIGHT: 7px; TEXT-ALIGN: right">
                                <asp:TextBox ID="TFF" runat="server" Width="95px"></asp:TextBox>
                                <asp:CustomValidator ID="ValCutFF" runat="server" 
                                    ClientValidationFunction="ValIsFecha" ControlToValidate="TFF" 
                                    ErrorMessage="Digite Una Fecha Correcta" Height="14px" ValidationGroup="Buscar" 
                                    Width="15px">*</asp:CustomValidator>
                            </td>
                        </tr>
                        <TR><TD style="HEIGHT: 33px; TEXT-ALIGN: center; background-color: #F0F0F0;" 
                                colspan="5">
                            <asp:RadioButtonList ID="Tipo_Grupo" runat="server" 
                                RepeatDirection="Horizontal">
                                <asp:ListItem Value="D">AGRUPAR POR AÑO Y PERIODO DE DECLARACION</asp:ListItem>
                                <asp:ListItem Value="I" Selected="True">AGRUPAR POR AÑO Y PERIODO DE INGRESO</asp:ListItem>
                            </asp:RadioButtonList>
                            </TD></TR>
                        <tr>
                            <td style="WIDTH: 119px; HEIGHT: 33px; TEXT-ALIGN: left">
                                <asp:CheckBox ID="CBANO" runat="server" Text="Año" />
                                &nbsp;
                            </td>
                            <td colspan="2" style="WIDTH: 76px; HEIGHT: 33px">
                                <asp:DropDownList ID="CMBANO" runat="server" DataSourceID="ObjCalVigencias" 
                                    DataTextField="CAL_VIG" DataValueField="CAL_VIG" Width="95px">
                                </asp:DropDownList>
                            </td>
                            <td style="WIDTH: 95px; HEIGHT: 33px; TEXT-ALIGN: right">
                                <asp:CheckBox ID="cbMes" runat="server" Text="Periodo" 
                                    Width="73px" />
                            </td>
                            <td style="WIDTH: 95px; HEIGHT: 33px; TEXT-ALIGN: right">
                                <asp:DropDownList ID="CMBPER" runat="server" DataSourceID="ObjCal" 
                                    DataTextField="CAL_DES" DataValueField="CAL_PER" Width="102px">
                                </asp:DropDownList>
                            </td>
                        </tr>
                        <TR><TD style="HEIGHT: 24px; TEXT-ALIGN: left; font-weight: 700; background-color: #F0F0F0;" 
                                colspan="5">
                            <asp:CheckBox ID="CBCTA" runat="server" 
                                Text="ENTIDAD BANCARIA" />
                            </TD></TR>
                        <tr>
                            <td style="WIDTH: 119px; HEIGHT: 24px; TEXT-ALIGN: left">
                                Banco&nbsp; &nbsp;</td>
                            <td colspan="2" style="WIDTH: 76px; HEIGHT: 24px">
                                <asp:DropDownList ID="CMBBCO" runat="server" AutoPostBack="True" 
                                    DataSourceID="ObjBco" DataTextField="BAN_NOM" DataValueField="BAN_COD" 
                                    Width="173px">
                                </asp:DropDownList>
                            </td>
                            <td style="WIDTH: 95px; HEIGHT: 24px; TEXT-ALIGN: right">
                                <asp:Label ID="Label8" runat="server" Text="Nro Cta" Width="74px"></asp:Label>
                            </td>
                            <td style="WIDTH: 95px; HEIGHT: 24px">
                                <asp:DropDownList ID="CMBCTA" runat="server" DataSourceID="ObjCtabBco" 
                                    DataTextField="CTA_NRO" DataValueField="CTA_NRO" Width="100px">
                                </asp:DropDownList>
                            </td>
                        </tr>
                        <TR><TD style="HEIGHT: 24px; TEXT-ALIGN: left; font-weight: 700; background-color: #F0F0F0;" 
                                colspan="5">
                            <asp:CheckBox ID="CBCON" runat="server" 
                                Text="CONCEPTO DE RECAUDO" />
                            </TD></TR>
                        <tr>
                            <td style="WIDTH: 119px; HEIGHT: 24px; TEXT-ALIGN: right">
                                &nbsp;
                            </td>
                            <td colspan="4" style="HEIGHT: 24px; TEXT-ALIGN: left">
                                <asp:DropDownList ID="CMBCON" runat="server" DataSourceID="ObjConc" 
                                    DataTextField="CCAR_NOM" DataValueField="CCAR_COD" Width="246px">
                                </asp:DropDownList>
                            </td>
                        </tr>
                        <TR><TD style="HEIGHT: 24px; TEXT-ALIGN: left; font-weight: 700; background-color: #F0F0F0;" 
                                colspan="5">
                            <asp:CheckBox ID="CBTPAR" runat="server" Text="TIPO DE AGENTE RECAUDADOR" />
                            </TD>
                            </TR><TR>
                        <TD style="TEXT-ALIGN: center" colspan="5">
                            <asp:DropDownList ID="CbTTcer" runat="server" DataSourceID="ObjTTer" 
                                DataTextField="TAG_NOM" DataValueField="TAG_COD" Width="180px">
                            </asp:DropDownList>
                            </TD>
                        </TR>
                        <tr>
                            <td colspan="5" 
                                style="HEIGHT: 24px; TEXT-ALIGN: left; font-weight: 700; background-color: #F0F0F0;">
                                <asp:CheckBox ID="CHKMUN" runat="server" Text="MUNICIPIO" />
                            </td>
                        </tr>
                        <tr>
                            <td colspan="5" style="TEXT-ALIGN: center">
                                <asp:DropDownList ID="CbMun" runat="server" DataSourceID="ObjMUN" 
                                    DataTextField="MUN_NOM" DataValueField="MUN_COD" Width="214px">
                                </asp:DropDownList>
                            </td>
                        </tr>
                        <tr>
                            <td style="WIDTH: 119px; HEIGHT: 24px; TEXT-ALIGN: right">
                                &nbsp;</td>
                            <td colspan="2" style="WIDTH: 76px; HEIGHT: 24px">
                                &nbsp;</td>
                            <td style="WIDTH: 95px; HEIGHT: 24px">
                                &nbsp;</td>
                            <td style="WIDTH: 95px; HEIGHT: 24px">
                                &nbsp;</td>
                        </tr>
                        <TR><TD style="WIDTH: 119px; HEIGHT: 24px; TEXT-ALIGN: right"></TD>
                            <TD style="WIDTH: 76px; HEIGHT: 24px; text-align: center;">
                                <asp:ImageButton ID="BtnBuscar" runat="server" AlternateText="Buscar" 
                                    ImageUrl="~/images/Operaciones/search2.png" onclick="BtnBuscar_Click" 
                                    ToolTip="Buscar" />
                            </TD>
                            <td style="WIDTH: 76px; HEIGHT: 24px; text-align: center;">
                                <asp:ImageButton ID="Btncancel" runat="server" AlternateText="Cancelar" 
                                    ImageUrl="~/images/Operaciones/Deshacer.png" ToolTip="Cancelar" />
                            </td>
                            <TD style="WIDTH: 95px; HEIGHT: 24px">&nbsp;</TD><TD style="WIDTH: 95px; HEIGHT: 24px">
                            &nbsp;</TD></TR>
                        <tr>
                            <td style="WIDTH: 119px; HEIGHT: 24px; TEXT-ALIGN: right">
                            </td>
                            <td style="WIDTH: 76px; HEIGHT: 24px; text-align: center;">
                                <asp:Label ID="Label4" runat="server" Text="Buscar" Width="49px"></asp:Label>
                            </td>
                            <td style="WIDTH: 76px; HEIGHT: 24px; text-align: center;">
                                <asp:Label ID="Label5" runat="server" Text="Cancelar" Width="49px"></asp:Label>
                            </td>
                            <td style="WIDTH: 95px; HEIGHT: 24px">
                                &nbsp;</td>
                            <td style="WIDTH: 95px; HEIGHT: 24px">
                                &nbsp;</td>
                        </tr>
                        </TBODY></TABLE><asp:ObjectDataSource id="ObjCtabBco" runat="server" TypeName="Informes" SelectMethod="GetCta" OldValuesParameterFormatString="original_{0}"><SelectParameters>
<asp:ControlParameter ControlID="CMBBCO" PropertyName="SelectedValue" Name="CTA_BACO" Type="String"></asp:ControlParameter>
</SelectParameters>
</asp:ObjectDataSource><ajaxToolkit:CalendarExtender id="CalendarExtender1" runat="server" TargetControlID="TFI"></ajaxToolkit:CalendarExtender><ajaxToolkit:CalendarExtender id="CalendarExtender2" runat="server" TargetControlID="TFF"></ajaxToolkit:CalendarExtender> <ajaxToolkit:ValidatorCalloutExtender id="ValCutFIalCAlExtFI" runat="server" __designer:wfdid="w2" TargetControlID="ValCutFI"></ajaxToolkit:ValidatorCalloutExtender> <ajaxToolkit:ValidatorCalloutExtender id="ValCutFIalCAlExtFF" runat="server" __designer:wfdid="w4" TargetControlID="ValCutFF"></ajaxToolkit:ValidatorCalloutExtender> 
</contenttemplate>
                <triggers>
<asp:AsyncPostBackTrigger ControlID="CMBCLADEC" EventName="SelectedIndexChanged"></asp:AsyncPostBackTrigger>
<asp:AsyncPostBackTrigger ControlID="CMBANO" EventName="SelectedIndexChanged"></asp:AsyncPostBackTrigger>
<asp:AsyncPostBackTrigger ControlID="CMBBCO" EventName="SelectedIndexChanged"></asp:AsyncPostBackTrigger>
<asp:AsyncPostBackTrigger ControlID="CMBCTA" EventName="SelectedIndexChanged"></asp:AsyncPostBackTrigger>
<asp:AsyncPostBackTrigger ControlID="CBCLA" EventName="CheckedChanged"></asp:AsyncPostBackTrigger>
<asp:PostBackTrigger ControlID="BtnBuscar"></asp:PostBackTrigger>
<asp:PostBackTrigger ControlID="Btncancel"></asp:PostBackTrigger>
</triggers>
            </asp:UpdatePanel>&nbsp; &nbsp;
        <p>
            <asp:MultiView ID="MultiView1" runat="server">
                <asp:View ID="View1" runat="server">
                    <rsweb:ReportViewer ID="Rptview" runat="server" Font-Names="Verdana" Font-Size="8pt"
                        Height="434px" Width="697px">
                        <%--<LocalReport ReportPath="Report\Consultas\RptMovIng.rdlc">
                         </LocalReport>--%>
                    </rsweb:ReportViewer>
                    &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;&nbsp;
                </asp:View>
            </asp:MultiView>
            &nbsp;&nbsp; &nbsp;&nbsp;
            <asp:ObjectDataSource ID="ObjMUN" runat="server" SelectMethod="GetRecords" TypeName="Municipios">
            </asp:ObjectDataSource>
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
            &nbsp;<asp:ObjectDataSource ID="ObjConc" runat="server" OldValuesParameterFormatString="original_{0}"
                SelectMethod="GetConceptos" TypeName="Informes"></asp:ObjectDataSource>
            <asp:ObjectDataSource ID="ObjBco" runat="server" OldValuesParameterFormatString="original_{0}"
                SelectMethod="GetBancos" TypeName="Informes"></asp:ObjectDataSource>
             <asp:ObjectDataSource id="ObjTTer" runat="server" TypeName="TTerc" 
                 SelectMethod="GetRecords"></asp:ObjectDataSource> 
            <asp:UpdateProgress id="UpdateProgress1" runat="server" AssociatedUpdatePanelID="UpdatePanel1">
                <progresstemplate>
<DIV class="Loading"><IMG title="" alt="" src="../images/loading.gif" /> Cargando … </DIV>
</progresstemplate>
            </asp:UpdateProgress></p>
    </div>
</div>
</asp:Content>

