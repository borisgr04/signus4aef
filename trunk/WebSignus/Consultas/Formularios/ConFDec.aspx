<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="ConFDec.aspx.vb" Inherits="Consultas_Formularios_ConFDec" title="Untitled Page" StylesheetTheme="BlueTheme" EnableEventValidation="false" %>
<%@ Register Src="../../CtrlUsr/Terceros/ConsultaTer.ascx" TagName="ConsultaTer" TagPrefix="uc1" %>
<%@ Register Assembly="Microsoft.ReportViewer.WebForms, Version=10.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a"
    Namespace="Microsoft.Reporting.WebForms" TagPrefix="rsweb" %>

<asp:Content ID="Content1" ContentPlaceHolderID="SampleContent" Runat="Server">
    <ajaxToolkit:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server" EnablePageMethods="true">
    </ajaxToolkit:ToolkitScriptManager>
    
    <script type='text/javascript'>
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
                document.aspnetForm.<%=Me.Nit.ClientID%>.value=ced;
                document.aspnetForm.<%=Me.DV.ClientID%>.value=dv;
                document.aspnetForm.<%=Me.Agente.ClientID%>.value=rsocial;
            }
            var modalPopupBehavior = $find('programmaticModalPopupBehavior');
            modalPopupBehavior.hide();
            __doPostBack("<%= button.ClientID %>","");
            __doPostBack("<%= CbCdec.ClientID %>","");
            UpdateCombo();
            
        }
        
        function UpdateCombo()
        {
             var no =document.getElementById("<%= CbCdec.ClientID %>").options.length;
            if (no==1)  __doPostBack("<%= CbCdec.ClientID %>","");
            
            
        }
        
        function MostrarNit()
        {
        __doPostBack("<%= BuscarNit.ClientID %>","");
        }
        

    </script>
<div class="demoarea">
        
    <asp:Label ID="Tit" runat="server" CssClass="Titulo" Text="Consulta de Formularios de Declaración"
        Width="455px"></asp:Label><br />
    <asp:UpdatePanel id="UpdatePanel1" runat="server"><contenttemplate>
    
    <div style="z-index: 101; left: 0px; visibility: hidden; overflow: auto; width: 100px;
            position: absolute; top: 0px; height: 100px">
            <rsweb:ReportViewer ID="ReportViewer1" runat="server" AsyncRendering="False" Font-Names="Verdana"
                Font-Size="8pt" Height="100%" SizeToReportContent="True" Width="800px">
                <LocalReport OnSubreportProcessing="ReportViewer1_SubreportProcessing" ReportPath="">
                </LocalReport>
            </rsweb:ReportViewer>
        </div>

        <TABLE __designer:dtid="844424930131979" width="600">
            <tbody>
                <tr __designer:dtid="844424930131980">
                    <td __designer:dtid="844424930131981" class="TDNegroFila" style="HEIGHT: 13px">
                        <asp:Label ID="Label10" runat="server" __designer:dtid="844424930131982" 
                            __designer:wfdid="w76" Font-Bold="True" Text="AGENTE RECAUDADOR"></asp:Label>
                        &nbsp;&nbsp;
                        <asp:Button ID="button" runat="server" __designer:dtid="3096246218653697" 
                            __designer:wfdid="w77" onclick="button_Click" style="DISPLAY: none" />
                        <asp:Button ID="BuscarNit" runat="server" __designer:dtid="3096246218653697" 
                            __designer:wfdid="w87" onclick="BuscarNit_Click1" style="DISPLAY: none" />
                    </td>
                </tr>
                <tr __designer:dtid="844424930131984">
                    <td __designer:dtid="844424930131985">
                        <table __designer:dtid="844424930131986" width="100%">
                            <tbody>
                                <tr __designer:dtid="844424930131987" onmouseout="Resaltar_Off(this);" 
                                    onmouseover="Resaltar_On(this);">
                                    <td __designer:dtid="844424930131990" style="WIDTH: 51px; HEIGHT: 15px">
                                        <asp:Label ID="Label15" runat="server" __designer:dtid="844424930131991" 
                                            __designer:wfdid="w79" CssClass="TitDecl" Font-Bold="True" 
                                            Text="IDENTIFICACIÓN"></asp:Label>
                                    </td>
                                    <td __designer:dtid="844424930131990" style="WIDTH: 51px; HEIGHT: 15px">
                                        &nbsp;<asp:Label ID="Label2" runat="server" __designer:dtid="844424930131991" 
                                            __designer:wfdid="w79" CssClass="TitDecl" Font-Bold="True" Text="DV"></asp:Label>
                                    </td>
                                    <td __designer:dtid="844424930131990" style="WIDTH: 51px; HEIGHT: 15px">
                                        &nbsp;</td>
                                    <td __designer:dtid="844424930131992" style="WIDTH: 131px; HEIGHT: 15px">
                                        <asp:Label ID="Label11ra" runat="server" __designer:dtid="844424930131993" 
                                            __designer:wfdid="w14" CssClass="TitDecl" Font-Bold="True" Text="RAZON SOCIAL"></asp:Label>
                                    </td>
                                    <td __designer:dtid="844424930131994" style="WIDTH: 253px; HEIGHT: 15px">
                                    </td>
                                </tr>
                                <tr onmouseout="Resaltar_Off(this);" onmouseover="Resaltar_On(this);" 
                                    valign="middle">
                                    <td __designer:dtid="844424930131998" style="WIDTH: 51px; HEIGHT: 19px" 
                                        valign="middle">
                                        <asp:TextBox ID="Nit" runat="server" __designer:dtid="844424930131997" 
                                            __designer:wfdid="w81" Enabled="False"></asp:TextBox>
                                    </td>
                                    <td __designer:dtid="844424930131998" style="WIDTH: 51px; HEIGHT: 19px" 
                                        valign="middle">
                                        -<asp:TextBox ID="Dv" runat="server" __designer:dtid="844424930131999" 
                                            __designer:wfdid="w82" Enabled="False" Width="17px"></asp:TextBox>
                                        &nbsp;</td>
                                    <td __designer:dtid="844424930131998" style="HEIGHT: 19px; width: 51px;" 
                                        valign="middle">
                                        <asp:Button ID="BtnBuscDP" runat="server" __designer:wfdid="w83" accessKey="B" 
                                            onclick="BtnBuscar_Click" Text="..." ToolTip="Buscar Agente Recaudador" 
                                            UseSubmitBehavior="False" />
                                    </td>
                                    <td __designer:dtid="844424930132000" colspan="2" style="HEIGHT: 19px">
                                        <asp:TextBox ID="Agente" runat="server" __designer:dtid="844424930132001" 
                                            __designer:wfdid="w84" Enabled="False" Width="332px"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr onmouseout="Resaltar_Off(this);" onmouseover="Resaltar_On(this);">
                                    <td colspan="5" style="HEIGHT: 19px">
                                        &nbsp;</td>
                                </tr>
                                <tr __designer:dtid="844424930132002" onmouseout="Resaltar_On(this);" 
                                    onmouseover="Resaltar_On(this);">
                                    <td __designer:dtid="844424930132003" colspan="5" style="HEIGHT: 19px">
                                        <asp:Label ID="Label1x" runat="server" __designer:dtid="844424930132004" 
                                            __designer:wfdid="w18" CssClass="TitDecl" Font-Bold="True" 
                                            Text="SELECCIONE LA CLASE DE DECLARACION" Width="261px"></asp:Label>
                                        <asp:DropDownList ID="CbCdec" runat="server" __designer:dtid="844424930132007" 
                                            __designer:wfdid="w86" AutoPostBack="True" DataSourceID="ObjCDec" 
                                            DataTextField="CLD_NOM" DataValueField="CLD_COD" 
                                            OnSelectedIndexChanged="CbCdec_SelectedIndexChanged">
                                        </asp:DropDownList>
                                    </td>
                                </tr>
                            </tbody>
                        </table>
                        <asp:ObjectDataSource ID="ObjCalVigencias" runat="server" 
                            __designer:dtid="7318349394477076" __designer:wfdid="w43" 
                            OldValuesParameterFormatString="original_{0}" SelectMethod="GetVigencias" 
                            TypeName="Calendario">
                            <SelectParameters __designer:dtid="7318349394477077">
                                <asp:ControlParameter ControlID="CbCdec" DefaultValue="" Name="Cla_Dec" 
                                    PropertyName="SelectedValue" Type="String" />
                            </SelectParameters>
                        </asp:ObjectDataSource>
                        <asp:ObjectDataSource ID="ObjCal" runat="server" 
                            __designer:dtid="7318349394477079" __designer:wfdid="w44" 
                            OldValuesParameterFormatString="original_{0}" SelectMethod="GetPorClaseDec" 
                            TypeName="Calendario">
                            <SelectParameters __designer:dtid="7318349394477080">
                                <asp:ControlParameter ControlID="CbCdec" DefaultValue="" Name="Cla_Dec" 
                                    PropertyName="SelectedValue" Type="String" />
                                <asp:ControlParameter __designer:dtid="7318349394477082" 
                                    ControlID="CboVigencia" Name="Vigencia" PropertyName="SelectedValue" 
                                    Type="String" />
                            </SelectParameters>
                        </asp:ObjectDataSource>
                    </td>
                </tr>
                <tr>
                    <td>
                    </td>
                </tr>
            </tbody>
        </TABLE>
<TABLE><TBODY><TR><TD style="WIDTH: 100px"><asp:Label id="Label14" runat="server" Width="91px" Font-Bold="True" Text="AÑO GRAVABLE" CssClass="TitDecl"></asp:Label></TD><TD style="WIDTH: 100px"><asp:Label id="Label13" runat="server" Width="133px" Font-Bold="True" Text="PERIODO GRAVABLE" CssClass="TitDecl"></asp:Label></TD><TD style="WIDTH: 100px"><asp:Label id="Label1" runat="server" Width="91px" Font-Bold="True" Text="ESTADO" CssClass="TitDecl"></asp:Label></TD><TD style="WIDTH: 100px"></TD><TD style="WIDTH: 100px"></TD><TD style="WIDTH: 100px"></TD></TR><TR><TD style="WIDTH: 100px"><asp:DropDownList id="CboVigencia" runat="server" DataValueField="cal_vig" DataTextField="cal_vig" DataSourceID="ObjCalVigencias" AutoPostBack="True">
    </asp:DropDownList></TD><TD style="WIDTH: 100px"><asp:DropDownList id="Periodo" runat="server" DataValueField="cal_per" DataTextField="cal_des" DataSourceID="ObjCal" AutoPostBack="True">
        </asp:DropDownList></TD><TD style="WIDTH: 100px"><asp:DropDownList id="CboEst" runat="server" AutoPostBack="True">
        <asp:ListItem Value="DC">Diligenciadas</asp:ListItem>
        <asp:ListItem Value="PR">Presentadas y Pagadas</asp:ListItem>
        <%--<asp:ListItem Value="NP">No Presentadas</asp:ListItem>--%>
        <%--<asp:ListItem Value="DF">Diligenciadas</asp:ListItem>--%>
        <asp:ListItem Value="AN">Anuladas</asp:ListItem>
        
    </asp:DropDownList></TD><TD style="WIDTH: 100px"><asp:Button id="BtnActualizar" runat="server" Width="111px" Text="Actualizar"></asp:Button></TD><TD style="WIDTH: 100px"><asp:Button id="BtnGenerarPDF" onclick="BtnGenerarPDF_Click" runat="server" Width="100px" Text="Generar PDF" __designer:wfdid="w93"></asp:Button></TD><TD style="WIDTH: 100px"><asp:Button id="BtnAnular" runat="server" Width="115px" Text="Anular" __designer:wfdid="w94"></asp:Button></TD></TR><TR><TD style="WIDTH: 100px"></TD><TD style="WIDTH: 100px"></TD><TD style="WIDTH: 100px"></TD><TD style="WIDTH: 100px"></TD><TD style="WIDTH: 100px"></TD><TD style="WIDTH: 100px"></TD></TR><TR><TD style="WIDTH: 100px"></TD><TD style="WIDTH: 100px"></TD><TD style="WIDTH: 100px"></TD><TD style="WIDTH: 100px"></TD><TD style="WIDTH: 100px"></TD><TD style="WIDTH: 100px"></TD></TR><TR><TD style="WIDTH: 100px"></TD><TD style="WIDTH: 100px"></TD><TD style="WIDTH: 100px"></TD><TD style="WIDTH: 100px"></TD><TD style="WIDTH: 100px"></TD><TD style="WIDTH: 100px"></TD></TR><TR><TD colSpan=4><asp:Label id="MsgResult" runat="server"></asp:Label></TD><TD colSpan=1></TD><TD colSpan=1></TD></TR></TBODY></TABLE><asp:GridView id="grDec" runat="server" Width="100%" DataSourceID="ObjDecl" OnSelectedIndexChanged="grDec_SelectedIndexChanged" AllowSorting="True" AllowPaging="True" DataKeyNames="Dec_Cod" AutoGenerateColumns="False"><Columns>
<asp:BoundField DataField="Dec_Cod" DataFormatString="{0:c}" HeaderText="Formulario N&#176;"></asp:BoundField>
        <asp:BoundField DataField="DEC_DOAD" HeaderText="Documento" />
<asp:BoundField DataField="TDec_Nom" HeaderText="Tipo Dec."></asp:BoundField>
<asp:BoundField DataField="Dec_Ano" DataFormatString="{0:c}" HeaderText="A&#241;o Gravable"></asp:BoundField>
<asp:BoundField DataField="Dec_Per" HeaderText="Periodo Gravable"></asp:BoundField>
<asp:BoundField DataField="Impuesto" DataFormatString="{0:c}" HeaderText="Valor Impuesto">
<ItemStyle HorizontalAlign="Right"></ItemStyle>
</asp:BoundField>
<asp:BoundField DataField="Sancion" DataFormatString="{0:c}" HeaderText="Valor Sanci&#243;n">
<ItemStyle HorizontalAlign="Right"></ItemStyle>
</asp:BoundField>
<asp:BoundField DataField="Declarado" DataFormatString="{0:c}" HeaderText="Total Declarado">
<ItemStyle HorizontalAlign="Right"></ItemStyle>
</asp:BoundField>
<asp:CommandField SelectImageUrl="~/images/Operaciones/Select.png" ShowSelectButton="True" ButtonType="Image"></asp:CommandField>
</Columns>
</asp:GridView> 

</contenttemplate>     
        <Triggers>
            <asp:PostBackTrigger ControlID="BtnGenerarPDF" />
        </Triggers>
    </asp:UpdatePanel>
&nbsp; &nbsp;<br />

    <asp:ObjectDataSource ID="ObjCDec" runat="server" OldValuesParameterFormatString="original_{0}"
        SelectMethod="GetCDEC_PorNit" TypeName="CDeclaraciones">
        <SelectParameters>
            <asp:ControlParameter ControlID="Nit" Name="Nit" PropertyName="Text" Type="String" />
        </SelectParameters>
    </asp:ObjectDataSource>
    <asp:ObjectDataSource ID="ObjDecl" runat="server" OldValuesParameterFormatString="original_{0}"
        SelectMethod="GetDecPorEst" TypeName="CDeclaraciones">
        <SelectParameters>
            <asp:ControlParameter ControlID="Nit" Name="Dec_Nit" PropertyName="Text" Type="String" />
            <asp:ControlParameter ControlID="CboVigencia" Name="dec_a&#241;o" PropertyName="SelectedValue"
                Type="String" />
            <asp:ControlParameter ControlID="CboEst" Name="dec_est" PropertyName="SelectedValue"
                Type="String" />
            <asp:ControlParameter ControlID="CbCdec" Name="dec_cdec" PropertyName="SelectedValue" />
        </SelectParameters>
    </asp:ObjectDataSource>
    &nbsp;&nbsp;
    <asp:HiddenField ID="HdUser" runat="server" />
    <asp:HiddenField ID="HdTipoUser" runat="server" />
    <asp:HiddenField ID="Oper" runat="server" />
    <br />
    <br />
    <asp:UpdatePanel id="UpdatePanel2" runat="server" UpdateMode="Conditional">
        <contenttemplate>
<!-- Mensaje de Salida--><asp:Button style="DISPLAY: none" id="hiddenTargetControlForModalPopup" runat="server"></asp:Button> <ajaxToolkit:ModalPopupExtender id="ModalPopup" runat="server" BackgroundCssClass="modalBackground" BehaviorID="programmaticModalPopupBehavior" DropShadow="True" PopupControlID="programmaticPopup" PopupDragHandleControlID="programmaticPopupDragHandle" RepositionMode="RepositionOnWindowScroll" TargetControlID="hiddenTargetControlForModalPopup">
            </ajaxToolkit:ModalPopupExtender> <asp:Panel id="programmaticPopup" runat="server" Width="625px" Height="229%" CssClass="ModalPanel2"><asp:Panel id="programmaticPopupDragHandle" runat="Server" Height="30px" CssClass="BarTitleModal2">
                    <div style="padding: 5px; vertical-align: middle;">
                        <div style="float: left;">
                            Buscar Agente Recaudador
                        </div>
                    </div>
                </asp:Panel> &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;<BR />&nbsp; &nbsp; &nbsp;&nbsp; <uc1:consultater id="ConsultaTer1" runat="server" ret="AR" tipo="AR"></uc1:consultater> <BR /><BR /><BR /></asp:Panel> 
</contenttemplate>
        <triggers>
<asp:AsyncPostBackTrigger ControlID="BtnBuscDP" EventName="Click"></asp:AsyncPostBackTrigger>
</triggers>
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

