<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="ConSaldoFavor.aspx.vb" Inherits="Consultas_ConSaldoFavor" Title="Untitled Page" StylesheetTheme="BlueTheme" EnableEventValidation="false" %>

<%@ Register Src="../../CtrlUsr/Terceros/ConsultaTer.ascx" TagName="ConsultaTer" TagPrefix="uc1" %>
<%@ Register Assembly="Microsoft.ReportViewer.WebForms, Version=10.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a"
    Namespace="Microsoft.Reporting.WebForms" TagPrefix="rsweb" %>

<asp:Content ID="Content1" ContentPlaceHolderID="SampleContent" runat="Server">
    <ajaxToolkit:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server" EnablePageMethods="true">
    </ajaxToolkit:ToolkitScriptManager>

    <script type='text/javascript'>
        function cancelClick() {
            var label = $get('ctl00_SampleContent_LbRpt');
        
            /*
        function showModalPopupViaClient(ev) {
            ev.preventDefault();
            var modalPopupBehavior = $find('programmaticModalPopupBehavior');
            modalPopupBehavior.show();
        }
        
        function hideModalPopupViaClient(ev) {
            ev.preventDefault();        
            var modalPopupBehavior = $find('programmaticModalPopupBehavior');
            modalPopupBehavior.hide();
        }*/
            /*
            function enviar(tdoc,ced,dv,rsocial,tip_ter)
            {
                if(tip_ter=='AR'){
                    document.aspnetForm.%=Me.Nit.ClientID%>.value=ced;
                    document.aspnetForm.%=Me.DV.ClientID%>.value=dv;
                    document.aspnetForm.%=Me.Agente.ClientID%>.value=rsocial;
                }
                var modalPopupBehavior = $find('programmaticModalPopupBehavior');
                modalPopupBehavior.hide();
                __doPostBack("%= button.ClientID %>","");
                __doPostBack("%= CbCdec.ClientID %>","");
                 UpdateCombo();
             }
            */
            function UpdateCombo()
            {
                var no =document.getElementById("<%= CbCdec.ClientID %>").options.length;
             if (no==1)  __doPostBack("<%= CbCdec.ClientID %>","");
            
            
         }
            /*
            function MostrarNit()
            {
                __doPostBack("%= BuscarNit.ClientID %>","");
            }
            */

    </script>
    <div class="demoarea">

        <asp:Label ID="Tit" runat="server" CssClass="Titulo" Text="Consulta de Formularios de Declaración"
            Width="455px"></asp:Label><br />
        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
            <ContentTemplate>

                <div style="z-index: 101; left: 0px; visibility: hidden; overflow: auto; width: 100px; position: absolute; top: 0px; height: 100px">
                    <rsweb:ReportViewer ID="ReportViewer1" runat="server" AsyncRendering="False" Font-Names="Verdana"
                        Font-Size="8pt" Height="100%" SizeToReportContent="True" Width="800px">
                        <LocalReport OnSubreportProcessing="ReportViewer1_SubreportProcessing" ReportPath="">
                        </LocalReport>
                    </rsweb:ReportViewer>
                </div>

                <table width="600">
                    <tbody>
                        <%--<tr>
                            <td class="TDNegroFila" style="HEIGHT: 13px">
                                <asp:Label ID="Label10" runat="server"
                                    Font-Bold="True" Text="AGENTE RECAUDADOR"></asp:Label>
                                &nbsp;&nbsp;
                        <asp:Button ID="button" runat="server"
                            OnClick="button_Click" Style="DISPLAY: none" />
                                <asp:Button ID="BuscarNit" runat="server"
                                    OnClick="BuscarNit_Click1" Style="DISPLAY: none" />
                            </td>
                        </tr>

                      --%>  <tr>
                            <td>
                                <table width="100%">
                                    <tbody>

                                        <%--                                        <tr onmouseout="Resaltar_Off(this);"
                                            onmouseover="Resaltar_On(this);">
                                            <td style="WIDTH: 51px; HEIGHT: 15px">
                                                <asp:Label ID="Label15" runat="server"
                                                    CssClass="TitDecl" Font-Bold="True"
                                                    Text="IDENTIFICACIÓN"></asp:Label>
                                            </td>
                                            <td style="WIDTH: 51px; HEIGHT: 15px">&nbsp;<asp:Label ID="Label2" runat="server"
                                                CssClass="TitDecl" Font-Bold="True" Text="DV"></asp:Label>
                                            </td>
                                            <td style="WIDTH: 51px; HEIGHT: 15px">&nbsp;</td>
                                            <td style="WIDTH: 131px; HEIGHT: 15px">
                                                <asp:Label ID="Label11ra" runat="server"
                                                    CssClass="TitDecl" Font-Bold="True" Text="RAZON SOCIAL"></asp:Label>
                                            </td>
                                            <td style="WIDTH: 253px; HEIGHT: 15px"></td>
                                        </tr>
                                        <tr onmouseout="Resaltar_Off(this);" onmouseover="Resaltar_On(this);"
                                            valign="middle">
                                            <td style="WIDTH: 51px; HEIGHT: 19px"
                                                valign="middle">
                                                <asp:TextBox ID="Nit" runat="server"
                                                    Enabled="False"></asp:TextBox>
                                            </td>
                                            <td style="WIDTH: 51px; HEIGHT: 19px"
                                                valign="middle">-<asp:TextBox ID="Dv" runat="server"
                                                    Enabled="False" Width="17px"></asp:TextBox>
                                                &nbsp;</td>
                                            <td style="HEIGHT: 19px; width: 51px;"
                                                valign="middle">
                                                <asp:Button ID="BtnBuscDP" runat="server" AccessKey="B"
                                                    OnClick="BtnBuscar_Click" Text="..." ToolTip="Buscar Agente Recaudador"
                                                    UseSubmitBehavior="False" />
                                            </td>
                                            <td colspan="2" style="HEIGHT: 19px">
                                                <asp:TextBox ID="Agente" runat="server" 
                                                    Enabled="False" Width="332px"></asp:TextBox>
                                            </td>
                                        </tr>
                                        --%>
                                        <tr onmouseout="Resaltar_Off(this);" onmouseover="Resaltar_On(this);">
                                            <td colspan="5" style="HEIGHT: 19px">&nbsp;</td>
                                        </tr>
                                        <tr onmouseout="Resaltar_On(this);"
                                            onmouseover="Resaltar_On(this);">
                                            <td colspan="5" style="HEIGHT: 19px">
                                                <asp:Label ID="Label1x" runat="server"
                                                    CssClass="TitDecl" Font-Bold="True"
                                                    Text="SELECCIONE LA CLASE DE DECLARACION" Width="261px"></asp:Label>
                                                <asp:DropDownList ID="CbCdec" runat="server"
                                                    AutoPostBack="True" DataSourceID="ObjCDec"
                                                    DataTextField="CLD_NOM" DataValueField="CLD_COD"
                                                    OnSelectedIndexChanged="CbCdec_SelectedIndexChanged">
                                                </asp:DropDownList>
                                            </td>
                                        </tr>
                                    </tbody>
                                </table>
                                <asp:ObjectDataSource ID="ObjCalVigencias" runat="server"
                                    OldValuesParameterFormatString="original_{0}" SelectMethod="GetVigencias"
                                    TypeName="Calendario">
                                    <SelectParameters>
                                        <asp:ControlParameter ControlID="CbCdec" DefaultValue="" Name="Cla_Dec"
                                            PropertyName="SelectedValue" Type="String" />
                                    </SelectParameters>
                                </asp:ObjectDataSource>
                                <asp:ObjectDataSource ID="ObjCal" runat="server"
                                    OldValuesParameterFormatString="original_{0}" SelectMethod="GetPorClaseDec"
                                    TypeName="Calendario">
                                    <SelectParameters>
                                        <asp:ControlParameter ControlID="CbCdec" DefaultValue="" Name="Cla_Dec"
                                            PropertyName="SelectedValue" Type="String" />
                                        <asp:ControlParameter
                                            ControlID="CboVigencia" Name="Vigencia" PropertyName="SelectedValue"
                                            Type="String" />
                                    </SelectParameters>
                                </asp:ObjectDataSource>
                            </td>
                        </tr>
                        <tr>
                            <td></td>
                        </tr>
                    </tbody>
                </table>
                <table>
                    <tbody>
                        <tr>
                            <td style="WIDTH: 100px">
                                <asp:Label ID="Label14" runat="server" Width="91px" Font-Bold="True" Text="AÑO GRAVABLE" CssClass="TitDecl"></asp:Label></td>
                            <td style="WIDTH: 100px">
                                <asp:Label ID="Label13" runat="server" Width="133px" Font-Bold="True" Text="PERIODO GRAVABLE" CssClass="TitDecl"></asp:Label></td>
                            <td style="WIDTH: 100px">
                                &nbsp;</td>
                            <td style="WIDTH: 100px"></td>
                            <td style="WIDTH: 100px"></td>
                            <td style="WIDTH: 100px"></td>
                        </tr>
                        <tr>
                            <td style="WIDTH: 100px">
                                <asp:DropDownList ID="CboVigencia" runat="server" DataValueField="cal_vig" DataTextField="cal_vig" DataSourceID="ObjCalVigencias" AutoPostBack="True">
                                </asp:DropDownList></td>
                            <td style="WIDTH: 100px">
                                <asp:DropDownList ID="Periodo" runat="server" DataValueField="cal_per" DataTextField="cal_des" DataSourceID="ObjCal" AutoPostBack="True">
                                </asp:DropDownList></td>
                            <td style="WIDTH: 100px">
                                &nbsp;</td>
                            <td style="WIDTH: 100px">
                                <asp:Button ID="BtnActualizar" runat="server" Width="111px" Text="Actualizar"></asp:Button></td>
                            <td style="WIDTH: 100px">
                                <asp:Button ID="BtnGenerarPDF" OnClick="BtnGenerarPDF_Click" runat="server" Width="100px" Text="Generar PDF" __designer:wfdid="w93"></asp:Button></td>
                            <td style="WIDTH: 100px">
                                &nbsp;</td>
                        </tr>
                        <tr>
                            <td style="WIDTH: 100px"></td>
                            <td style="WIDTH: 100px"></td>
                            <td style="WIDTH: 100px"></td>
                            <td style="WIDTH: 100px"></td>
                            <td style="WIDTH: 100px"></td>
                            <td style="WIDTH: 100px"></td>
                        </tr>
                        <tr>
                            <td style="WIDTH: 100px"></td>
                            <td style="WIDTH: 100px"></td>
                            <td style="WIDTH: 100px"></td>
                            <td style="WIDTH: 100px"></td>
                            <td style="WIDTH: 100px"></td>
                            <td style="WIDTH: 100px"></td>
                        </tr>
                        <tr>
                            <td style="WIDTH: 100px"></td>
                            <td style="WIDTH: 100px"></td>
                            <td style="WIDTH: 100px"></td>
                            <td style="WIDTH: 100px"></td>
                            <td style="WIDTH: 100px"></td>
                            <td style="WIDTH: 100px"></td>
                        </tr>
                        <tr>
                            <td colspan="4">
                                <asp:Label ID="MsgResult" runat="server"></asp:Label></td>
                            <td colspan="1"></td>
                            <td colspan="1"></td>
                        </tr>
                    </tbody>
                </table>
                <%--DataSourceID="ObjDecl" --%>

                <br />
                <table style="width: 100%">
                    <tr>
                        <td valign="top">
                            <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" DataKeyNames="Formulario" DataSourceID="ObjConSaldoFavor">
                                <Columns>
                                    <asp:BoundField DataField="Formulario" HeaderText="Formulario" SortExpression="Formulario" />
                                    <asp:BoundField DataField="AgenteRecaudador" HeaderText="AgenteRecaudador" SortExpression="AgenteRecaudador" />
                                    <asp:BoundField DataField="PGravable" HeaderText="PGravable" SortExpression="PGravable" />
                                    <asp:BoundField DataField="AGravable" HeaderText="AGravable" SortExpression="AGravable" />
                                    <asp:BoundField DataField="SaldoFavor" HeaderText="SaldoFavor" SortExpression="SaldoFavor" DataFormatString="{0:c}" />
                                    <asp:BoundField DataField="TotalAPagar" HeaderText="TotalAPagar" SortExpression="TotalAPagar" DataFormatString="{0:c}" />
                                    <asp:BoundField DataField="Estado" HeaderText="Estado" SortExpression="Estado" />
                                    <asp:CommandField ShowSelectButton="True" />
                                </Columns>
                            </asp:GridView>
                        </td>
                        <td valign="top">
                            <asp:GridView ID="GridView2" runat="server" AutoGenerateColumns="False" DataSourceID="ObjDetalle">
                                <Columns>
                                    <asp:BoundField DataField="Concepto" HeaderText="Concepto" SortExpression="Concepto">
                                        <ItemStyle Width="40%" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="Valor" HeaderText="Valor" SortExpression="Valor" DataFormatString="{0:C}">
                                        <ItemStyle HorizontalAlign="Right" />
                                    </asp:BoundField>
                                </Columns>
                            </asp:GridView>
                            <asp:ObjectDataSource ID="ObjDetalle" runat="server" SelectMethod="ConRenglones" TypeName="BLL.ConSaldoFavor">
                                <SelectParameters>
                                    <asp:ControlParameter ControlID="GridView1" Name="cod_dec" PropertyName="SelectedValue" Type="String" />
                                </SelectParameters>
                            </asp:ObjectDataSource>
                        </td>
                    </tr>
                    <tr>
                        <td>&nbsp;</td>
                        <td>&nbsp;</td>
                    </tr>
                </table>
                <asp:ObjectDataSource ID="ObjConSaldoFavor" runat="server" SelectMethod="DecConSaldoFavor" TypeName="BLL.ConSaldoFavor" OldValuesParameterFormatString="original_{0}">
                    <SelectParameters>
                        <asp:ControlParameter ControlID="CbCdec" Name="cdec" PropertyName="SelectedValue" Type="String" />
                        <asp:ControlParameter ControlID="CboVigencia" Name="year" PropertyName="SelectedValue" Type="String" />
                        <asp:ControlParameter ControlID="Periodo" Name="periodo" PropertyName="SelectedValue" Type="String" />
                    </SelectParameters>
                </asp:ObjectDataSource>
                <br />

            </ContentTemplate>
            <Triggers>
                <asp:PostBackTrigger ControlID="BtnGenerarPDF" />
            </Triggers>
        </asp:UpdatePanel>
        &nbsp; &nbsp;<br />

        <asp:ObjectDataSource ID="ObjCDec" runat="server" OldValuesParameterFormatString="original_{0}"
            SelectMethod="GetCDEC" TypeName="CDeclaraciones"></asp:ObjectDataSource>



        &nbsp;&nbsp;
    <asp:HiddenField ID="HdUser" runat="server" />
        <asp:HiddenField ID="HdTipoUser" runat="server" />
        <asp:HiddenField ID="Oper" runat="server" />
        <br />
        <br />
        <asp:UpdatePanel ID="UpdatePanel2" runat="server" UpdateMode="Conditional">
            <ContentTemplate>
                <!-- Mensaje de Salida-->
                <asp:Button Style="DISPLAY: none" ID="hiddenTargetControlForModalPopup" runat="server"></asp:Button>
                <ajaxToolkit:ModalPopupExtender ID="ModalPopup" runat="server" BackgroundCssClass="modalBackground" BehaviorID="programmaticModalPopupBehavior" DropShadow="True" PopupControlID="programmaticPopup" PopupDragHandleControlID="programmaticPopupDragHandle" RepositionMode="RepositionOnWindowScroll" TargetControlID="hiddenTargetControlForModalPopup">
                </ajaxToolkit:ModalPopupExtender>
                <asp:Panel ID="programmaticPopup" runat="server" Width="625px" Height="229%" CssClass="ModalPanel2">
                    <asp:Panel ID="programmaticPopupDragHandle" runat="Server" Height="30px" CssClass="BarTitleModal2">
                        <div style="padding: 5px; vertical-align: middle;">
                            <div style="float: left;">
                                Buscar Agente Recaudador
                            </div>
                        </div>
                    </asp:Panel>
                    &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;<br />
                    &nbsp; &nbsp; &nbsp;&nbsp;
                    <uc1:ConsultaTer ID="ConsultaTer1" runat="server" Ret="AR" Tipo="AR"></uc1:ConsultaTer>
                    <br />
                    <br />
                    <br />
                </asp:Panel>
            </ContentTemplate>
            <Triggers>
                <%--<asp:AsyncPostBackTrigger ControlID="BtnBuscDP" EventName="Click"></asp:AsyncPostBackTrigger>--%>
            </Triggers>
        </asp:UpdatePanel>
        <asp:UpdateProgress ID="UpdateProgress1" runat="server" AssociatedUpdatePanelID="UpdatePanel1">
            <ProgressTemplate>
                <div class="Loading">
                    <img alt="" src="../../images/loading.gif" title="" />
                    Cargando …
                </div>
            </ProgressTemplate>
        </asp:UpdateProgress>
        <br />
    </div>
</asp:Content>

