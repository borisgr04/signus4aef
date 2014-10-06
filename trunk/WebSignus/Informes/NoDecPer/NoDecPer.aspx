<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="NoDecPer.aspx.vb" Inherits="Informes_Default" title="Untitled Page" %>
<%@ Register Assembly="Microsoft.ReportViewer.WebForms, Version=10.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a"
    Namespace="Microsoft.Reporting.WebForms" TagPrefix="rsweb" %>

<asp:Content ID="Content1" ContentPlaceHolderID="SampleContent" Runat="Server">
    <div class="demoarea">
<asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <asp:Label ID="mensaje" runat="server"></asp:Label>
    <p>
        &nbsp;<asp:Label ID="Tit" runat="server" CssClass="Titulo" 
            Text="DECLARACIONES POR PERIODO"></asp:Label>
        &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;&nbsp;</p>
    <p>
        <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional">
            <ContentTemplate>
&nbsp;<asp:Label id="MsgResult" runat="server" __designer:wfdid="w95"></asp:Label> <TABLE style="WIDTH: 521px; HEIGHT: 34px" id="Table2"><TBODY><TR><TD style="WIDTH: 100px"><asp:Label id="Label2" runat="server" Text="Tipo de Declaracion" Width="111px" __designer:wfdid="w96"></asp:Label></TD><TD colSpan=3><asp:DropDownList id="CMBCLADEC" runat="server" Width="343px" DataValueField="cld_cod" DataTextField="cld_nom" DataSourceID="ObjClaseDec" AutoPostBack="True" __designer:wfdid="w97"></asp:DropDownList></TD><TD style="WIDTH: 111px"><asp:ImageButton id="BtnBuscar" onclick="BtnBuscar_Click" runat="server" AlternateText="Buscar" ImageUrl="~/images/Operaciones/search2.png" ToolTip="Buscar" __designer:wfdid="w98"></asp:ImageButton></TD><TD style="WIDTH: 1330px"><asp:ImageButton id="Btncancel" onclick="Btncancel_Click" runat="server" AlternateText="Cancelar" ImageUrl="~/images/Operaciones/Deshacer.png" ToolTip="Cancelar" __designer:wfdid="w99"></asp:ImageButton></TD></TR><TR><TD style="WIDTH: 100px"><asp:Label id="Label1" runat="server" Text="A�o Gravable" Width="74px" __designer:wfdid="w100"></asp:Label></TD><TD style="WIDTH: 100px">&nbsp;<asp:DropDownList id="CMBANO" runat="server" DataValueField="CAL_VIG" DataTextField="CAL_VIG" DataSourceID="ObjCalVigencias" AutoPostBack="True" __designer:wfdid="w101"></asp:DropDownList></TD><TD style="WIDTH: 100px">
                    <asp:CheckBox ID="ChkMun" runat="server" Text="Municipio" />
                    </TD><TD style="WIDTH: 101px"><asp:DropDownList id="CMBMPIO" runat="server" 
                            Width="172px" DataValueField="MUN_COD" DataTextField="MUN_NOM" 
                            DataSourceID="ObjMUN" __designer:wfdid="w103"></asp:DropDownList></TD><TD style="WIDTH: 111px"><asp:Label id="Label4" runat="server" Text="Buscar" Width="44px" __designer:wfdid="w104"></asp:Label></TD><TD style="WIDTH: 1330px"><asp:Label id="Label5" runat="server" Text="Cancelar" Width="53px" __designer:wfdid="w105"></asp:Label></TD></TR>
                    <tr>
                        <td style="WIDTH: 100px">
                            <asp:CheckBox ID="ChkEstado" runat="server" Text="Estado" />
                        </td>
                        <td style="WIDTH: 100px">
                            <asp:DropDownList ID="CboEst" runat="server">
                                <asp:ListItem Value="DC">Diligenciadas</asp:ListItem>
                                <asp:ListItem Value="PR">Presentadas y Pagadas</asp:ListItem>
                            </asp:DropDownList>
                        </td>
                        <td style="WIDTH: 100px">
                            &nbsp;</td>
                        <td style="WIDTH: 101px">
                            &nbsp;</td>
                        <td style="WIDTH: 111px">
                            &nbsp;</td>
                        <td style="WIDTH: 1330px">
                            &nbsp;</td>
                    </tr>
                    </TBODY></TABLE>
</ContentTemplate>
            <Triggers>
<asp:AsyncPostBackTrigger ControlID="CMBCLADEC" EventName="SelectedIndexChanged"></asp:AsyncPostBackTrigger>
<asp:AsyncPostBackTrigger ControlID="CMBANO" EventName="SelectedIndexChanged"></asp:AsyncPostBackTrigger>
<asp:AsyncPostBackTrigger ControlID="CMBMPIO" EventName="SelectedIndexChanged"></asp:AsyncPostBackTrigger>
<asp:PostBackTrigger ControlID="Btncancel"></asp:PostBackTrigger>
<asp:PostBackTrigger ControlID="BtnBuscar"></asp:PostBackTrigger>
</Triggers>
        </asp:UpdatePanel>&nbsp;</p>
    <p>
        &nbsp;</p>

        <asp:MultiView ID="MultiView1" runat="server">
            <asp:View ID="View1" runat="server">
                <rsweb:reportviewer id="Rptview" runat="server" font-names="Verdana" font-size="8pt"
                    height="547px" width="746px">
<LocalReport ReportPath="Report\Consultas\NoDecPerV.rdlc">
   
    
</LocalReport>
</rsweb:reportviewer>
        
            </asp:View>
        </asp:MultiView>
        <rsweb:reportviewer id="RptDecxPer" 
            runat="server" font-names="Verdana" font-size="8pt"
                    height="547px" width="900px">
        </rsweb:reportviewer>
        
        <rsweb:reportviewer id="RptDecxPer_24" 
            runat="server" font-names="Verdana" font-size="8pt"
                    height="547px" width="900px">
        </rsweb:reportviewer>
                
        <p>
                <asp:ObjectDataSource ID="ObjMUN" runat="server" SelectMethod="GetRecords" TypeName="Municipios">
        </asp:ObjectDataSource>
        <asp:ObjectDataSource ID="ObjCalVigencias" runat="server" OldValuesParameterFormatString="original_{0}"
            SelectMethod="GetVigencias" TypeName="Calendario">
            <SelectParameters>
                <asp:ControlParameter ControlID="CMBCLADEC" Name="Cla_Dec" PropertyName="SelectedValue"
                    Type="String" />
            </SelectParameters>
        </asp:ObjectDataSource>
        <asp:ObjectDataSource ID="ObjClaseDec" runat="server" OldValuesParameterFormatString="original_{0}"
            SelectMethod="GetcargarTipoDecla" TypeName="Informes"></asp:ObjectDataSource>
        <asp:UpdateProgress ID="UpdateProgress1" runat="server" AssociatedUpdatePanelID="UpdatePanel1">
            <ProgressTemplate>
                <div class="Loading">
                    <img alt="" src="../images/loading.gif" title="" />
                    Cargando �
                </div>
            </ProgressTemplate>
        </asp:UpdateProgress></p>
        </div>
</asp:Content>

