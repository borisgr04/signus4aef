<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="No_Declarantes.aspx.vb" Inherits="Informes_No_Declarantes" title="Untitled Page" %>
<%@ Register Assembly="Microsoft.ReportViewer.WebForms, Version=10.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a"
    Namespace="Microsoft.Reporting.WebForms" TagPrefix="rsweb" %>

<asp:Content ID="Content1" ContentPlaceHolderID="SampleContent" Runat="Server">

<div class="demoarea">


    <asp:ScriptManager id="ScriptManager1" runat="server" 
        EnableScriptGlobalization="True" EnableScriptLocalization="True">
            </asp:ScriptManager>
    <p>
                    &nbsp;<asp:Label ID="Tit" runat="server" CssClass="Titulo" 
                        Text="CONSULTA DE DECLARACIONES"></asp:Label>
        &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;&nbsp;&nbsp;
        &nbsp; &nbsp; &nbsp; &nbsp;&nbsp;</p>
    <p>
        
            <asp:UpdatePanel id="UpdatePanel1" runat="server" UpdateMode="Conditional">
                <contenttemplate>
&nbsp; <asp:Label id="MsgResult" runat="server"></asp:Label> 
                    <TABLE style="WIDTH: 645px; HEIGHT: 57px" id="Table2"><TBODY>
                    <TR>
                        <TD style="TEXT-ALIGN: left; font-weight: 700; background-color: #F2F2F2;" 
                            colspan="5">CLASE DE DECLARACION</TD></TR>
                            <TR>
                            <TD style="WIDTH: 119px; HEIGHT: 7px; TEXT-ALIGN: left">
                                <asp:CheckBox ID="CBCLA" runat="server" AutoPostBack="True" Checked="True" 
                                    Text="Clase de Declaración" />
                            </TD><TD style="HEIGHT: 7px" colspan="4">
                                <asp:DropDownList ID="CMBCLADEC" runat="server" AutoPostBack="True" 
                                    DataSourceID="ObjClaseDec" DataTextField="cld_nom" DataValueField="cld_cod" 
                                    Width="253px">
                                </asp:DropDownList>
                            </TD></TR>
                        <TR>
                        <TD style="TEXT-ALIGN: left; font-weight: 700; background-color: #F2F2F2;" 
                            colspan="5">MUNICIPIO</TD></TR>
                        <tr>
                            <td style="WIDTH: 119px; HEIGHT: 7px; TEXT-ALIGN: left">
                                <asp:CheckBox ID="CboMun" runat="server" Text="Municipio" />
                            </td>
                            <td colspan="4" style="HEIGHT: 7px">
                                <asp:DropDownList ID="CMBMPIO" runat="server" __designer:wfdid="w39" 
                                    AutoPostBack="True" DataSourceID="ObjMUN" DataTextField="MUN_NOM" 
                                    DataValueField="MUN_COD" Width="252px">
                                </asp:DropDownList>
                            </td>
                        </tr>
                        <tr>
                            <td colspan="5" 
                                style="HEIGHT: 7px; TEXT-ALIGN: left; font-weight: 700; background-color: #F0F0F0;">
                                <asp:RadioButtonList ID="Tipo_Grupo" runat="server" 
                                    RepeatDirection="Horizontal">
                                    <asp:ListItem Selected="True" Value="D">FECHA DE DECLARACIÓN</asp:ListItem>
                                    <asp:ListItem Value="I">FECHA DE PAGO</asp:ListItem>
                                </asp:RadioButtonList>
                            </td>
                        </tr>
                        <tr>
                            <td style="WIDTH: 119px; HEIGHT: 7px; TEXT-ALIGN: left">
                                <asp:CheckBox ID="CBFEC" runat="server" Text="Fecha Inicial" />
                            </td>
                            <td colspan="2" style="WIDTH: 76px; HEIGHT: 7px">
                                <asp:TextBox ID="TFI" runat="server" Width="95px"></asp:TextBox>
                            </td>
                            <td style="WIDTH: 95px; HEIGHT: 7px; TEXT-ALIGN: right">
                                <asp:Label ID="Label11" runat="server" Text="Fecha_Final" Width="74px"></asp:Label>
                            </td>
                            <td style="WIDTH: 95px; HEIGHT: 7px; TEXT-ALIGN: right">
                                <asp:TextBox ID="TFF" runat="server" Width="95px"></asp:TextBox>
                            </td>
                        </tr>
                        <TR><TD style="HEIGHT: 33px; TEXT-ALIGN: left; background-color: #F0F0F0; font-weight: 700;" 
                                colspan="5">
                            ESTADO</TD></TR>
                        <tr>
                            <td style="WIDTH: 119px; HEIGHT: 7px; TEXT-ALIGN: left">
                                <asp:CheckBox ID="CBEst" runat="server" Text="Estado" />
                            </td>
                            <td colspan="2" style="WIDTH: 76px; HEIGHT: 7px">
                                <asp:DropDownList ID="CboEst" runat="server">
                                    <asp:ListItem Value="DC">Diligenciadas</asp:ListItem>
                                    <asp:ListItem Value="PR">Pagadas y Presentadas</asp:ListItem>
                                </asp:DropDownList>
                            </td>
                            <td style="WIDTH: 95px; HEIGHT: 7px; TEXT-ALIGN: right">
                                &nbsp;</td>
                            <td style="WIDTH: 95px; HEIGHT: 7px; TEXT-ALIGN: right">
                                &nbsp;</td>
                        </tr>
                        
                        <tr>
                            <td colspan="5" 
                                style="HEIGHT: 33px; TEXT-ALIGN: left; background-color: #F0F0F0; font-weight: 700;">
                                AÑO Y PERIODO DE DECLARACIÓN</td>
                        </tr>
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
                                <asp:Label ID="Label8" runat="server" Text="N° Cuenta" Width="74px"></asp:Label>
                            </td>
                            <td style="WIDTH: 95px; HEIGHT: 24px">
                                <asp:DropDownList ID="CMBCTA" runat="server" DataSourceID="ObjCtabBco" 
                                    DataTextField="CTA_NRO" DataValueField="CTA_NRO" Width="100px">
                                </asp:DropDownList>
                            </td>
                        </tr>
                        <TR><TD style="WIDTH: 119px; HEIGHT: 24px; TEXT-ALIGN: right"></TD>
                            <TD style="WIDTH: 76px; HEIGHT: 24px; text-align: center;">
                                <asp:ImageButton ID="BtnBuscar" runat="server" AlternateText="Buscar" 
                                    ImageUrl="~/images/Operaciones/search2.png" onclick="BtnBuscar_Click" 
                                    ToolTip="Buscar" />
                            </TD><TD style="WIDTH: 76px; HEIGHT: 24px; text-align: center;">
                                <asp:ImageButton ID="Btncancel" runat="server" AlternateText="Cancelar" 
                                    ImageUrl="~/images/Operaciones/Deshacer.png" ToolTip="Cancelar" />
                            </TD><TD style="WIDTH: 95px; HEIGHT: 24px">
                                &nbsp;</TD>
                            <td style="WIDTH: 95px; HEIGHT: 24px">
                                &nbsp;</td>
                        </TR><TR><TD style="WIDTH: 119px; HEIGHT: 24px; TEXT-ALIGN: right"></TD>
                            <TD style="WIDTH: 76px; HEIGHT: 24px; text-align: center;">
                                <asp:Label ID="Label4" runat="server" Text="Buscar" Width="49px"></asp:Label>
                            </TD>
                            <td style="WIDTH: 76px; HEIGHT: 24px; text-align: center;">
                                <asp:Label ID="Label5" runat="server" Text="Cancelar" Width="49px"></asp:Label>
                            </td>
                            <TD style="WIDTH: 95px; HEIGHT: 24px">&nbsp;</TD><TD style="WIDTH: 95px; HEIGHT: 24px">
                            &nbsp;</TD></TR></TBODY></TABLE><asp:ObjectDataSource id="ObjCtabBco" runat="server" TypeName="Informes" SelectMethod="GetCta" OldValuesParameterFormatString="original_{0}"><SelectParameters>
<asp:ControlParameter ControlID="CMBBCO" PropertyName="SelectedValue" Name="CTA_BACO" Type="String"></asp:ControlParameter>
</SelectParameters>
</asp:ObjectDataSource><ajaxToolkit:CalendarExtender id="CalendarExtender1" runat="server" TargetControlID="TFI"></ajaxToolkit:CalendarExtender><ajaxToolkit:CalendarExtender id="CalendarExtender2" runat="server" TargetControlID="TFF"></ajaxToolkit:CalendarExtender> 

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
            </asp:UpdatePanel></p>
    <p>
        <asp:MultiView ID="MultiView1" runat="server" Visible="False">
            <asp:View ID="View1" runat="server">
                <rsweb:ReportViewer ID="Rptview" runat="server" Font-Names="Verdana" 
                    Font-Size="8pt" Height="282px" Width="703px">
                    <%--<LocalReport ReportPath="Report\Consultas\NO_Declarante.rdlc">
                    </LocalReport>--%>
                </rsweb:ReportViewer>
            </asp:View>
        </asp:MultiView>
        &nbsp;&nbsp;
                
            &nbsp;<rsweb:ReportViewer ID="ReportViewer1" runat="server" Width="900px">
             <%--<LocalReport ReportPath="Report\Consultas\RptDecPer.rdlc"> 
             
                    </LocalReport>--%>
                    
        </rsweb:ReportViewer>
        
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
        SelectMethod="GetPorClaseDec" TypeName="Calendario">
        <SelectParameters>
            <asp:ControlParameter ControlID="CMBCLADEC" Name="Cla_Dec" PropertyName="SelectedValue"
                Type="String" />
            <asp:ControlParameter ControlID="CMBANO" Name="Vigencia" PropertyName="SelectedValue"
                Type="String" />
        </SelectParameters>
    </asp:ObjectDataSource>
    <asp:ObjectDataSource ID="ObjClaseDec" runat="server" OldValuesParameterFormatString="original_{0}"
        SelectMethod="GetcargarTipoDecla" TypeName="Informes"></asp:ObjectDataSource>
            <asp:ObjectDataSource ID="ObjBco" runat="server" OldValuesParameterFormatString="original_{0}"
                SelectMethod="GetBancos" TypeName="Informes"></asp:ObjectDataSource>
    <asp:UpdateProgress id="UpdateProgress1" runat="server" AssociatedUpdatePanelID="UpdatePanel1"><progresstemplate>
<DIV class="Loading"><IMG title="" alt="" src="../images/loading.gif" /> Cargando … </DIV>
</progresstemplate>
        </asp:UpdateProgress></p>
    </div>
</asp:Content>

