<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="Ingresos.aspx.vb" Inherits="Informes_Ingresos" title="Untitled Page"
UICulture="auto" Culture="auto" %>
<%@ Register assembly="Microsoft.ReportViewer.WebForms, Version=10.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a" namespace="Microsoft.Reporting.WebForms" tagprefix="rsweb" %>
<%--<%@ Register Assembly="Microsoft.ReportViewer.WebForms, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a"
    Namespace="Microsoft.Reporting.WebForms" TagPrefix="rsweb" %>--%>
<asp:Content ID="Content1" ContentPlaceHolderID="SampleContent" Runat="Server">
    <ajaxToolkit:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server" EnableScriptGlobalization="true"  
        EnableScriptLocalization="true">
    </ajaxToolkit:ToolkitScriptManager>
     <div class="demoarea">
        &nbsp;<asp:Label ID="Tit" runat="server" CssClass="Titulo" Text="Consulta de Ingresos"></asp:Label>
        &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
        &nbsp; &nbsp; &nbsp;&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;&nbsp;<p>
             &nbsp;<asp:UpdatePanel id="UpdatePanel1" runat="server" UpdateMode="Conditional">
            <contenttemplate>
&nbsp; <asp:Label id="MsgResult" runat="server" __designer:wfdid="w1"></asp:Label> <TABLE style="WIDTH: 441px; HEIGHT: 57px" id="Table2"><TBODY><TR><TD style="WIDTH: 72px; TEXT-ALIGN: right"></TD><TD style="WIDTH: 85px"></TD><TD colSpan=3></TD></TR><TR><TD style="WIDTH: 72px; HEIGHT: 7px; TEXT-ALIGN: right">
                    <asp:CheckBox id="CBFEC" runat="server" __designer:wfdid="w16" 
                        OnCheckedChanged="CBFEC_CheckedChanged" TextAlign="Left"></asp:CheckBox></TD><TD style="WIDTH: 85px; HEIGHT: 7px; TEXT-ALIGN: right"><asp:Label id="Label10" runat="server" Width="74px" Text="Fecha_Inicial" __designer:wfdid="w17"></asp:Label></TD><TD style="WIDTH: 76px; HEIGHT: 7px"><asp:TextBox id="TFI" runat="server" Width="95px" __designer:wfdid="w18"></asp:TextBox></TD><TD style="WIDTH: 95px; HEIGHT: 7px; TEXT-ALIGN: right"><asp:Label id="Label11" runat="server" Width="74px" Text="Fecha_Final" __designer:wfdid="w19"></asp:Label></TD><TD style="WIDTH: 95px; HEIGHT: 7px; TEXT-ALIGN: right"><asp:TextBox id="TFF" runat="server" Width="95px" __designer:wfdid="w20"></asp:TextBox></TD></TR><TR><TD style="WIDTH: 72px; HEIGHT: 7px; TEXT-ALIGN: right">
                    <asp:CheckBox id="CBCLA" runat="server" Width="73px" __designer:wfdid="w2" 
                        OnCheckedChanged="CBCLA_CheckedChanged" TextAlign="Left" AutoPostBack="True"></asp:CheckBox></TD><TD style="WIDTH: 85px; HEIGHT: 7px; TEXT-ALIGN: right"><asp:Label id="Label2" runat="server" Width="96px" Text="Clase Declaracion" __designer:wfdid="w3"></asp:Label></TD><TD style="HEIGHT: 7px; TEXT-ALIGN: left" colSpan=3><asp:DropDownList id="CMBCLADEC" runat="server" Width="253px" __designer:wfdid="w37" AutoPostBack="True" DataValueField="cld_cod" DataTextField="cld_nom" DataSourceID="ObjClaseDec"></asp:DropDownList></TD></TR><TR><TD style="WIDTH: 72px; HEIGHT: 7px; TEXT-ALIGN: right">
                    <asp:CheckBox id="CBMPIO" runat="server" Width="73px" __designer:wfdid="w5" 
                        TextAlign="Left"></asp:CheckBox></TD><TD style="WIDTH: 85px; HEIGHT: 7px; TEXT-ALIGN: right">&nbsp;<asp:Label id="Label6" runat="server" Width="74px" Text="Municipio" __designer:wfdid="w6"></asp:Label></TD><TD style="HEIGHT: 7px; TEXT-ALIGN: left" colSpan=3><asp:DropDownList id="CMBMPIO" runat="server" Width="252px" __designer:wfdid="w39" AutoPostBack="True" DataValueField="MUN_COD" DataTextField="MUN_NOM" DataSourceID="ObjMUN"></asp:DropDownList></TD></TR><TR><TD style="WIDTH: 72px; HEIGHT: 33px; TEXT-ALIGN: right">
                    <asp:CheckBox id="CBANO" runat="server" __designer:wfdid="w11" TextAlign="Left"></asp:CheckBox></TD><TD style="WIDTH: 85px; HEIGHT: 33px; TEXT-ALIGN: right">&nbsp; <asp:Label id="Label1" runat="server" Width="74px" Text="Año Gravable" __designer:wfdid="w12"></asp:Label></TD><TD style="WIDTH: 76px; HEIGHT: 33px"><asp:DropDownList id="CMBANO" runat="server" Width="95px" __designer:wfdid="w13" DataValueField="CAL_VIG" DataTextField="CAL_VIG" DataSourceID="ObjCalVigencias"></asp:DropDownList></TD><TD style="WIDTH: 95px; HEIGHT: 33px; TEXT-ALIGN: right"><asp:Label id="Label3" runat="server" Width="94px" Text="Periodo Gravable" __designer:wfdid="w14"></asp:Label></TD><TD style="WIDTH: 95px; HEIGHT: 33px; TEXT-ALIGN: right"><asp:DropDownList id="CMBPER" runat="server" Width="102px" __designer:wfdid="w15" DataValueField="CAL_PER" DataTextField="CAL_DES" DataSourceID="ObjCal"></asp:DropDownList></TD></TR><TR><TD style="WIDTH: 72px; HEIGHT: 24px; TEXT-ALIGN: right">
                    <asp:CheckBox id="CBCTA" runat="server" __designer:wfdid="w21" TextAlign="Left"></asp:CheckBox></TD><TD style="WIDTH: 85px; HEIGHT: 24px; TEXT-ALIGN: right">&nbsp; <asp:Label id="Label9" runat="server" Width="41px" Text="Banco" __designer:wfdid="w22"></asp:Label>&nbsp;</TD><TD style="WIDTH: 76px; HEIGHT: 24px"><asp:DropDownList id="CMBBCO" runat="server" Width="173px" __designer:wfdid="w23" AutoPostBack="True" DataValueField="BAN_COD" DataTextField="BAN_NOM" DataSourceID="ObjBco"></asp:DropDownList></TD><TD style="WIDTH: 95px; HEIGHT: 24px; TEXT-ALIGN: right"><asp:Label id="Label8" runat="server" Width="74px" Text="Nro Cta" __designer:wfdid="w24"></asp:Label></TD><TD style="WIDTH: 95px; HEIGHT: 24px"><asp:DropDownList id="CMBCTA" runat="server" Width="100px" __designer:wfdid="w25" DataValueField="CTA_NRO" DataTextField="CTA_NRO" DataSourceID="ObjCtabBco"></asp:DropDownList></TD></TR><TR><TD style="WIDTH: 72px; HEIGHT: 24px; TEXT-ALIGN: right">
                    <asp:CheckBox id="CBCON" runat="server" Width="73px" __designer:wfdid="w26" 
                        TextAlign="Left"></asp:CheckBox></TD><TD style="WIDTH: 85px; HEIGHT: 24px; TEXT-ALIGN: right">&nbsp; <asp:Label id="lcon" runat="server" Width="41px" Text="Conceptos" __designer:wfdid="w27"></asp:Label></TD><TD style="HEIGHT: 24px; TEXT-ALIGN: left" colSpan=3><asp:DropDownList id="CMBCON" runat="server" Width="246px" __designer:wfdid="w28" DataValueField="CCAR_COD" DataTextField="CCAR_NOM" DataSourceID="ObjConc"></asp:DropDownList></TD></TR><TR><TD style="WIDTH: 72px; HEIGHT: 24px; TEXT-ALIGN: right"></TD><TD style="HEIGHT: 24px" colSpan=2><ajaxToolkit:CalendarExtender id="CalendarExtender1" runat="server" __designer:dtid="562949953421321" __designer:wfdid="w34" TargetControlID="TFI"></ajaxToolkit:CalendarExtender></TD><TD style="WIDTH: 95px; HEIGHT: 24px"><asp:ImageButton id="BtnBuscar" onclick="BtnBuscar_Click" runat="server" AlternateText="Buscar" ImageUrl="~/images/Operaciones/search2.png" __designer:wfdid="w29" ToolTip="Buscar"></asp:ImageButton></TD><TD style="WIDTH: 95px; HEIGHT: 24px"><asp:ImageButton id="Btncancel" onclick="Btncancel_Click" runat="server" AlternateText="Cancelar" ImageUrl="~/images/Operaciones/Deshacer.png" __designer:wfdid="w30" ToolTip="Cancelar"></asp:ImageButton></TD></TR><TR><TD style="WIDTH: 72px; HEIGHT: 24px; TEXT-ALIGN: right"></TD><TD style="HEIGHT: 24px" colSpan=2><ajaxToolkit:CalendarExtender id="CalendarExtender2" runat="server" __designer:dtid="562949953421321" __designer:wfdid="w35" TargetControlID="TFF"></ajaxToolkit:CalendarExtender></TD><TD style="WIDTH: 95px; HEIGHT: 24px"><asp:Label id="Label4" runat="server" Width="49px" Text="Buscar" __designer:wfdid="w31"></asp:Label></TD><TD style="WIDTH: 95px; HEIGHT: 24px"><asp:Label id="Label5" runat="server" Width="49px" Text="Cancelar" __designer:wfdid="w32"></asp:Label></TD></TR><TR><TD style="WIDTH: 72px; HEIGHT: 24px; TEXT-ALIGN: right">&nbsp;</TD><TD style="HEIGHT: 24px" colSpan=2><asp:ObjectDataSource id="ObjCtabBco" runat="server" TypeName="Informes" SelectMethod="GetCta" OldValuesParameterFormatString="original_{0}" __designer:wfdid="w33"><SelectParameters>
<asp:ControlParameter ControlID="CMBBCO" PropertyName="SelectedValue" Name="CTA_BACO" Type="String"></asp:ControlParameter>
</SelectParameters>
</asp:ObjectDataSource></TD><TD style="WIDTH: 95px; HEIGHT: 24px"></TD><TD style="WIDTH: 95px; HEIGHT: 24px"></TD></TR></TBODY></TABLE>
</contenttemplate>
            <triggers>
<asp:AsyncPostBackTrigger ControlID="CMBCLADEC" EventName="SelectedIndexChanged"></asp:AsyncPostBackTrigger>
<asp:AsyncPostBackTrigger ControlID="CMBANO" EventName="SelectedIndexChanged"></asp:AsyncPostBackTrigger>
<asp:AsyncPostBackTrigger ControlID="CMBMPIO" EventName="SelectedIndexChanged"></asp:AsyncPostBackTrigger>
<asp:AsyncPostBackTrigger ControlID="CMBBCO" EventName="SelectedIndexChanged"></asp:AsyncPostBackTrigger>
<asp:AsyncPostBackTrigger ControlID="CMBCTA" EventName="SelectedIndexChanged"></asp:AsyncPostBackTrigger>
<asp:AsyncPostBackTrigger ControlID="CBCLA" EventName="CheckedChanged"></asp:AsyncPostBackTrigger>
<asp:PostBackTrigger ControlID="BtnBuscar"></asp:PostBackTrigger>
<asp:PostBackTrigger ControlID="Btncancel"></asp:PostBackTrigger>
</triggers>
        </asp:UpdatePanel>&nbsp;</p>
         
        &nbsp;&nbsp;<p>
        <asp:MultiView ID="MultiView1" runat="server">
            <asp:View ID="View1" runat="server">
                <rsweb:reportviewer ID="Rptview" runat="server" Font-Names="Verdana" Font-Size="8pt"
                    Height="282px" Width="703px">
                  </rsweb:reportViewer>
                &nbsp; &nbsp; &nbsp;
                &nbsp; &nbsp;&nbsp;&nbsp;
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
        <asp:UpdateProgress id="UpdateProgress1" runat="server" AssociatedUpdatePanelID="UpdatePanel1">
            <progresstemplate>
<DIV class="Loading"><IMG title="" alt="" src="../images/loading.gif" /> Cargando … </DIV>
</progresstemplate>
        </asp:UpdateProgress></p>
        </div>
</asp:Content>

