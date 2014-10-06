<%@ Page Title="" Language="VB" EnableEventValidation="false" MasterPageFile="~/MasterPage.master"
    AutoEventWireup="false" CodeFile="IngPorValor.aspx.vb" Inherits="Report_PorValor_IngPorValor" %>

<asp:Content ID="Content1" ContentPlaceHolderID="SampleContent" runat="Server">
    <div class="demoarea">
        <ajaxToolkit:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server" EnableScriptGlobalization="true"
            EnableScriptLocalization="true">
        </ajaxToolkit:ToolkitScriptManager>
        <asp:Label ID="Tit" runat="server" CssClass="Titulo" Text="Consulta de Ingresos "
            Font-Bold="True"></asp:Label>
        <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional">
            <ContentTemplate>
                &nbsp;
                <asp:Label ID="MsgResult" runat="server"></asp:Label>
                <table style="width: 645px; height: 57px" id="Table2">
                    <tbody>
                        <tr>
                            <td style="text-align: left; font-weight: 700; background-color: #F2F2F2;" colspan="6">
                                CLASE DE DECLARACION
                            </td>
                        </tr>
                        <tr>
                            <td style="width: 119px; height: 7px; text-align: left">
                                <asp:CheckBox ID="CBCLA" runat="server" AutoPostBack="True" Checked="True" Text="Clase de Declaración" />
                            </td>
                            <td style="height: 7px" colspan="5">
                                <asp:DropDownList ID="CMBCLADEC" runat="server" AutoPostBack="True" DataSourceID="ObjClaseDec"
                                    DataTextField="cld_nom" DataValueField="cld_cod" Width="253px">
                                </asp:DropDownList>
                            </td>
                        </tr>
                        <tr>
                            <td colspan="6" style="height: 7px; text-align: left; font-weight: 700; background-color: #F0F0F0;">
                                FECHA DEL INGRESO
                            </td>
                        </tr>
                        <tr>
                            <td style="width: 119px; height: 7px; text-align: left">
                                <asp:CheckBox ID="CBFEC" runat="server" Text="Fecha Inicial" />
                            </td>
                            <td colspan="3" style="width: 76px; height: 7px">
                                <asp:TextBox ID="TFI" runat="server" Width="95px"></asp:TextBox>
                                <asp:CustomValidator ID="ValCutFI" runat="server" ClientValidationFunction="ValIsFecha"
                                    ControlToValidate="TFI" ErrorMessage="Digite Una Fecha Correcta" Height="14px"
                                    Width="15px">*</asp:CustomValidator>
                            </td>
                            <td style="width: 95px; height: 7px; text-align: right">
                                <asp:Label ID="Label11" runat="server" Text="Fecha_Final" Width="74px"></asp:Label>
                            </td>
                            <td style="width: 95px; height: 7px; text-align: right">
                                <asp:TextBox ID="TFF" runat="server" Width="95px"></asp:TextBox>
                                <asp:CustomValidator ID="ValCutFF" runat="server" ClientValidationFunction="ValIsFecha"
                                    ControlToValidate="TFF" ErrorMessage="Digite Una Fecha Correcta" Height="14px"
                                    ValidationGroup="Buscar" Width="15px">*</asp:CustomValidator>
                            </td>
                        </tr>
                        <tr>
                            <td style="height: 7px; text-align: left; font-weight: 700; background-color: #F0F0F0;"
                                colspan="6">
                                AÑO Y PERIODO DE DECLARACIÓN &nbsp;
                            </td>
                        </tr>
                        <tr>
                            <td style="width: 119px; height: 33px; text-align: left">
                                <asp:CheckBox ID="CBANO" runat="server" Text="Año" />
                                &nbsp;
                            </td>
                            <td colspan="3" style="width: 76px; height: 33px">
                                <asp:DropDownList ID="CMBANO" runat="server" DataSourceID="ObjCalVigencias" DataTextField="CAL_VIG"
                                    DataValueField="CAL_VIG" Width="95px">
                                </asp:DropDownList>
                            </td>
                            <td style="width: 95px; height: 33px; text-align: right">
                                <asp:CheckBox ID="cbMes" runat="server" Text="Periodo" Width="73px" />
                            </td>
                            <td style="width: 95px; height: 33px; text-align: right">
                                <asp:DropDownList ID="CMBPER" runat="server" DataSourceID="ObjCal" DataTextField="CAL_DES"
                                    DataValueField="CAL_PER" Width="102px">
                                </asp:DropDownList>
                            </td>
                        </tr>
                        <tr>
                            <td style="height: 24px; text-align: left; font-weight: 700; background-color: #F0F0F0;"
                                colspan="6">
                                <asp:CheckBox ID="CBCTA" runat="server" Text="ENTIDAD BANCARIA" />
                            </td>
                        </tr>
                        <tr>
                            <td style="width: 119px; height: 24px; text-align: left">
                                Banco&nbsp; &nbsp;
                            </td>
                            <td colspan="3" style="width: 76px; height: 24px">
                                <asp:DropDownList ID="CMBBCO" runat="server" AutoPostBack="True" DataSourceID="ObjBco"
                                    DataTextField="BAN_NOM" DataValueField="BAN_COD" Width="173px">
                                </asp:DropDownList>
                            </td>
                            <td style="width: 95px; height: 24px; text-align: right">
                                <asp:Label ID="Label8" runat="server" Text="Nro Cta" Width="74px"></asp:Label>
                            </td>
                            <td style="width: 95px; height: 24px">
                                <asp:DropDownList ID="CMBCTA" runat="server" DataSourceID="ObjCtabBco" DataTextField="CTA_NRO"
                                    DataValueField="CTA_NRO" Width="100px">
                                </asp:DropDownList>
                            </td>
                        </tr>
                        <tr>
                            <td style="height: 24px; text-align: left; font-weight: 700; background-color: #F0F0F0;"
                                colspan="6">
                                <asp:CheckBox ID="CBCON" runat="server" Text="CONCEPTO DE RECAUDO" />
                            </td>
                        </tr>
                        <tr>
                            <td style="width: 119px; height: 24px; text-align: right">
                                &nbsp;
                            </td>
                            <td colspan="5" style="height: 24px; text-align: left">
                                <asp:DropDownList ID="CMBCON" runat="server" DataSourceID="ObjConc" DataTextField="CCAR_NOM"
                                    DataValueField="CCAR_COD" Width="246px">
                                </asp:DropDownList>
                            </td>
                        </tr>
                        <tr>
                            <td style="height: 24px; text-align: left; font-weight: 700; background-color: #F0F0F0;"
                                colspan="6">
                                <asp:CheckBox ID="CBTPAR" runat="server" Text="TIPO DE AGENTE RECAUDADOR" />
                            </td>
                        </tr>
                        <tr>
                            <td style="text-align: center" colspan="6">
                                <asp:DropDownList ID="CbTTcer" runat="server" DataSourceID="ObjTTer" DataTextField="TAG_NOM"
                                    DataValueField="TAG_COD" Width="180px">
                                </asp:DropDownList>
                            </td>
                        </tr>
                        <tr>
                            <td colspan="6" style="height: 24px; text-align: left; font-weight: 700; background-color: #F0F0F0;">
                                <asp:CheckBox ID="CHKMUN" runat="server" Text="MUNICIPIO" />
                            </td>
                        </tr>
                        <tr>
                            <td colspan="6" style="text-align: center">
                                <asp:DropDownList ID="CbMun" runat="server" DataSourceID="ObjMUN" DataTextField="MUN_NOM"
                                    DataValueField="MUN_COD" Width="214px">
                                </asp:DropDownList>
                            </td>
                        </tr>
                        <tr>
                            <td colspan="6" style="height: 24px; text-align: left; font-weight: 700; background-color: #F0F0F0;">
                                <asp:CheckBox ID="CHKValor" runat="server" Text="Rango de Valores" />
                            </td>
                        </tr>
                        <tr>
                            <td colspan="3" style="text-align: center">
                                Valor Inicial
                                <asp:TextBox ID="TxtValorI" runat="server"></asp:TextBox>
                            </td>
                            <td colspan="3" style="text-align: center">
                                Valor Final<asp:TextBox ID="TxtValorF" runat="server"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td style="width: 119px; height: 24px; text-align: right">
                                &nbsp;
                            </td>
                            <td style="width: 76px; height: 24px;" colspan="3">
                                &nbsp;
                            </td>
                            <td style="width: 95px; height: 24px;">
                                &nbsp;
                            </td>
                            <td style="width: 95px; height: 24px">
                                &nbsp;
                            </td>
                        </tr>
                        <tr>
                            <td style="width: 119px; height: 24px; text-align: right">
                            </td>
                            <td style="width: 76px; height: 24px; text-align: center;">
                                <asp:ImageButton ID="BtnBuscar" runat="server" AlternateText="Buscar" ImageUrl="~/images/Operaciones/search2.png"
                                    OnClick="BtnBuscar_Click" ToolTip="Buscar" />
                            </td>
                            <td style="width: 76px; height: 24px; text-align: center;" colspan="2">
                                <asp:ImageButton ID="Btncancel" runat="server" AlternateText="Cancelar" ImageUrl="~/images/Operaciones/Deshacer.png"
                                    ToolTip="Cancelar" />
                            </td>
                            <td style="width: 95px; height: 24px">
                                &nbsp;
                            </td>
                            <td style="width: 95px; height: 24px">
                                &nbsp;
                            </td>
                        </tr>
                        <tr>
                            <td style="width: 119px; height: 24px; text-align: right">
                            </td>
                            <td style="width: 76px; height: 24px; text-align: center;">
                                <asp:Label ID="Label4" runat="server" Text="Buscar" Width="49px"></asp:Label>
                            </td>
                            <td style="width: 76px; height: 24px; text-align: center;" colspan="2">
                                <asp:Label ID="Label5" runat="server" Text="Cancelar" Width="49px"></asp:Label>
                            </td>
                            <td style="width: 95px; height: 24px">
                                &nbsp;
                            </td>
                            <td style="width: 95px; height: 24px">
                                &nbsp;
                            </td>
                        </tr>
                    </tbody>
                </table>
                <asp:ObjectDataSource ID="ObjCtabBco" runat="server" TypeName="Informes" SelectMethod="GetCta"
                    OldValuesParameterFormatString="original_{0}">
                    <SelectParameters>
                        <asp:ControlParameter ControlID="CMBBCO" PropertyName="SelectedValue" Name="CTA_BACO"
                            Type="String"></asp:ControlParameter>
                    </SelectParameters>
                </asp:ObjectDataSource>
                <div style="width: 800px; height: 400px; overflow: auto">
                    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" DataKeyNames="mov_ndoc,mov_tdoc">
                        <Columns>
                            <asp:BoundField DataField="mov_fmov" HeaderText="FECHA" />
                            <asp:BoundField DataField="mov_ndoc" HeaderText="N° Declaración" />
                            <asp:BoundField DataField="mov_nit" HeaderText="Nit" />
                            <asp:BoundField DataField="ter_nom" HeaderText="Agente Recaudador" />
                            <asp:BoundField DataField="valor" DataFormatString="{0:c}" HeaderText="Valor">
                                <ItemStyle HorizontalAlign="Right" Width="100px" />
                            </asp:BoundField>
                            <asp:BoundField DataField="Est_Dec" HeaderText="Estado Declaración" />
                            <asp:BoundField DataField="ccar_nom" HeaderText="Concepto" />
                            <asp:BoundField DataField="mov_per" HeaderText="Periodo" />
                            <asp:BoundField DataField="CLD_NOM" HeaderText="Clase De Declaración" />
                            <asp:BoundField DataField="MUN_NOM" HeaderText="Municipio" />
                        </Columns>
                    </asp:GridView>
                </div>
                <ajaxToolkit:CalendarExtender ID="CalendarExtender1" runat="server" TargetControlID="TFI">
                </ajaxToolkit:CalendarExtender>
                <ajaxToolkit:CalendarExtender ID="CalendarExtender2" runat="server" TargetControlID="TFF">
                </ajaxToolkit:CalendarExtender>
                <ajaxToolkit:ValidatorCalloutExtender ID="ValCutFIalCAlExtFI" runat="server" __designer:wfdid="w2"
                    TargetControlID="ValCutFI">
                </ajaxToolkit:ValidatorCalloutExtender>
                <ajaxToolkit:ValidatorCalloutExtender ID="ValCutFIalCAlExtFF" runat="server" __designer:wfdid="w4"
                    TargetControlID="ValCutFF">
                </ajaxToolkit:ValidatorCalloutExtender>
            </ContentTemplate>
            <Triggers>
                <asp:AsyncPostBackTrigger ControlID="CMBCLADEC" EventName="SelectedIndexChanged">
                </asp:AsyncPostBackTrigger>
                <asp:AsyncPostBackTrigger ControlID="CMBANO" EventName="SelectedIndexChanged"></asp:AsyncPostBackTrigger>
                <asp:AsyncPostBackTrigger ControlID="CMBBCO" EventName="SelectedIndexChanged"></asp:AsyncPostBackTrigger>
                <asp:AsyncPostBackTrigger ControlID="CMBCTA" EventName="SelectedIndexChanged"></asp:AsyncPostBackTrigger>
                <asp:AsyncPostBackTrigger ControlID="CBCLA" EventName="CheckedChanged"></asp:AsyncPostBackTrigger>
                <asp:PostBackTrigger ControlID="BtnBuscar"></asp:PostBackTrigger>
                <asp:PostBackTrigger ControlID="Btncancel"></asp:PostBackTrigger>
            </Triggers>
        </asp:UpdatePanel>
    </div>
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
    <asp:ObjectDataSource ID="ObjTTer" runat="server" TypeName="TTerc" SelectMethod="GetRecords">
    </asp:ObjectDataSource>
    <asp:UpdateProgress ID="UpdateProgress1" runat="server" AssociatedUpdatePanelID="UpdatePanel1">
        <ProgressTemplate>
            <div class="Loading">
                <img title="" alt="" src="../images/loading.gif" />
                Cargando …
            </div>
        </ProgressTemplate>
    </asp:UpdateProgress>
</asp:Content>
