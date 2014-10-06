<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" 
AutoEventWireup="false" CodeFile="AplicarPago.aspx.vb" Inherits="Declaraciones_AplicarP_AplicarPago"
 title="Untitled Page" UICulture="auto" Culture="auto"   %>
<%@ Register Src="../../CtrlUsr/Terceros/Con_Banco.ascx" TagName="Con_Banco" TagPrefix="uc1" %>
<%@ Register Assembly="eWorld.UI, Version=2.0.6.2393, Culture=neutral, PublicKeyToken=24d65337282035f2"
    Namespace="eWorld.UI" TagPrefix="ew" %>
<%@ Register Assembly="Microsoft.ReportViewer.WebForms, Version=10.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a"
    Namespace="Microsoft.Reporting.WebForms" TagPrefix="rsweb" %>
<asp:Content ID="Content1" ContentPlaceHolderID="SampleContent" Runat="Server">
    &nbsp; &nbsp;&nbsp; &nbsp;&nbsp; &nbsp;<div class="demoarea">
                <asp:Label ID="Tit" runat="server" CssClass="Titulo" Text="APLICACÍON DE PAGOS"></asp:Label><br />
                <asp:Label ID="MsgResult" runat="server"></asp:Label>
                <ajaxToolkit:ToolkitScriptManager ID="ScriptManager1" runat="Server" EnableScriptGlobalization="true" 
        EnableScriptLocalization="true">
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
            if(tip_ter=='PD'){
               
            }
            var modalPopupBehavior = $find('programmaticModalPopupBehavior');
            modalPopupBehavior.hide();
            
        }
        function enviarCta(cta_nro,cta_baco,ban_nom)
        {
            
                document.aspnetForm.<%=Me.TxtCta.ClientID%>.value=cta_nro;
                document.aspnetForm.<%=Me.TxtBanCod.ClientID%>.value=cta_baco;
                document.aspnetForm.<%=Me.TxtBanco.ClientID%>.value=ban_nom;
                
                //document.aspnetForm.<%=Me.DV.ClientID%>.value=dv;
                //document.aspnetForm.<%=Me.Agente.ClientID%>.value=rsocial;
            
            var modalPopupBehavior = $find('programmaticModalPopupBehavior');
            modalPopupBehavior.hide();
        }


    </script>
                <table>
                    <tr>
                        <td style="width: 111px">
                            N° Recibo Oficial</td>
                        <td style="width: 100px">
                    <asp:TextBox ID="TxtNro" runat="server"></asp:TextBox></td>
                        <td style="width: 45px">
                            <asp:ImageButton ID="ImageButton1" runat="server" ImageUrl="~/images/Operaciones/search2.png" AlternateText="Buscar" ToolTip="Buscar" /></td>
                        <td style="width: 50px">
                            <asp:ImageButton ID="BtnCancelar" runat="server" ImageUrl="~/images/Operaciones/Deshacer.png" ToolTip="Cancelar" AlternateText="Cancelar" /></td>
                    </tr>
                    <tr>
                        <td style="width: 111px">
                            </td>
                        <td style="width: 100px">
                            </td>
                        <td style="width: 45px">
                            Buscar</td>
                        <td style="width: 50px">
                            Cancelar</td>
                    </tr>
                </table>
        &nbsp;
        <br />
        <asp:HiddenField ID="HdTDOC" runat="server" />
                <asp:MultiView ID="MultiView2" runat="server">
                    <asp:View ID="View2" runat="server">
                <table style="width: 624px; height: 265px;">
                    <tr>
                        <td colspan="4">
                            &nbsp;
                            <asp:Label ID="Label2" runat="server" CssClass="SubTitulo">INFORMACION GENERAL DE LA DECLARACION</asp:Label>
                            <hr style="width: 611px" /></td>
                        <td colspan="1">
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 100px; height: 14px">
                            <asp:Label ID="lbTRec" runat="server" CssClass="TitDecl" Font-Bold="True" Text="Documento a Pagar"
                                Width="111px"></asp:Label></td>
                        <td colspan="2" style="height: 14px">
                            <asp:Label ID="lbTRecib" runat="server"></asp:Label></td>
                        <td style="width: 589px; height: 14px">
                        </td>
                        <td style="width: 589px; height: 14px">
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 100px; height: 14px">
                            <asp:Label ID="Label14" runat="server" CssClass="TitDecl" Font-Bold="True" Text="N° Documento"
                                Width="111px"></asp:Label></td>
                        <td style="width: 362px; height: 14px">
                            <asp:Label ID="LbNdoc" runat="server"></asp:Label></td>
                        <td style="width: 144px; height: 14px">
                        </td>
                        <td style="width: 589px; height: 14px">
                        </td>
                        <td style="width: 589px; height: 14px">
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 100px; height: 14px">
                            <asp:Label ID="Label20" runat="server" CssClass="TitDecl" Text="Razon Social" Width="98px" Font-Bold="True"></asp:Label></td>
                        <td colspan="3" style="height: 14px">
                            <asp:Label ID="Agente" runat="server" Width="337px"></asp:Label></td>
                        <td style="width: 589px; height: 14px">
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 100px; height: 14px;">
                            <asp:Label ID="Label24" runat="server" CssClass="TitDecl" Text="Tipo de Documento" Width="111px" Font-Bold="True"></asp:Label></td>
                        <td style="width: 362px; height: 14px;">
                            <asp:Label ID="TIP_DOC_IDE" runat="server"></asp:Label></td>
                        <td style="width: 144px; height: 14px;">
                            <asp:Label ID="Label26" runat="server" CssClass="TitDecl" Text="Identificaión" Font-Bold="True"></asp:Label></td>
                        <td style="width: 589px; height: 14px;">
                            <asp:Label ID="Identificaciòn" runat="server"></asp:Label>
                            -<asp:Label ID="DV" runat="server"></asp:Label></td>
                        <td style="width: 589px; height: 14px">
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 100px; height: 20px;">
                            <asp:Label ID="Label4" runat="server" CssClass="TitDecl" Font-Bold="True">Tipo de Agente</asp:Label></td>
                        <td colspan="3" style="height: 20px">
                            <asp:Label ID="LBTIPODEC" runat="server" Width="327px"></asp:Label></td>
                        <td colspan="1" style="height: 20px">
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 100px">
                            <asp:Label ID="Label6" runat="server" CssClass="TitDecl" Text="Clase Declaración"
                                Width="110px" Font-Bold="True"></asp:Label></td>
                        <td colspan="3">
                            <asp:DropDownList ID="CmbClDec" runat="server" DataSourceID="ObjClaseDec" DataTextField="cld_nom"
                                DataValueField="cld_cod" Width="401px" Enabled="False">
                            </asp:DropDownList></td>
                        <td colspan="1">
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 100px; height: 20px">
                            <asp:Label ID="Label7" runat="server" CssClass="TitDecl" Text="Periodo Gravable"
                                Width="110px" Font-Bold="True"></asp:Label></td>
                        <td style="width: 362px; height: 20px">
                            <asp:Label ID="LDEC_PER" runat="server"></asp:Label></td>
                        <td style="width: 144px; height: 20px">
                            <asp:Label ID="Label8" runat="server" CssClass="TitDecl" Text="Año Gravable" Width="110px" Font-Bold="True"></asp:Label></td>
                        <td style="width: 589px; height: 20px">
                            <asp:Label ID="LDEC_ANO" runat="server"></asp:Label></td>
                        <td style="width: 589px; height: 20px">
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 100px">
                            <asp:Label ID="Label1" runat="server" CssClass="TitDecl" Font-Bold="True" Width="142px">Valor a Pagar Impuestos</asp:Label></td>
                        <td colspan="2">
                            <ew:NumericBox ID="TxtValImp" runat="server" AutoFormatCurrency="True" CssClass="TxtMostrarLb_Der "
                                ReadOnly="True" Width="160px"></ew:NumericBox></td>
                        <td style="width: 589px; text-align: left;">
                            </td>
                        <td style="width: 589px; text-align: left">
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 100px">
                            <asp:Label ID="Label3" runat="server" CssClass="TitDecl" Font-Bold="True" Width="147px">Valor a Pagar Sanciones</asp:Label></td>
                        <td colspan="2">
                            <ew:NumericBox ID="TxtValSan" runat="server" AutoFormatCurrency="True" CssClass="TxtMostrarLb_Der"
                                ReadOnly="True" Width="160px"></ew:NumericBox></td>
                        <td style="width: 589px; text-align: left">
                            <ew:NumericBox ID="NumericBox2" runat="server" AutoFormatCurrency="True" CssClass="TxtMostrarLb"
                                ReadOnly="True" Width="160px"></ew:NumericBox></td>
                        <td style="width: 589px; text-align: left">
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 100px">
                            <asp:Label ID="Label12" runat="server" CssClass="TitDecl" Font-Bold="True">Interes de Mora</asp:Label></td>
                        <td colspan="2">
                            <ew:NumericBox ID="TxtIntMora" runat="server" AutoFormatCurrency="True" CssClass="TxtMostrarLb_Der"
                                ReadOnly="True" Width="160px"></ew:NumericBox></td>
                        <td style="width: 589px; text-align: left">
                        </td>
                        <td style="width: 589px; text-align: left">
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 100px">
                            <asp:Label ID="Label13" runat="server" CssClass="TitDecl" Font-Bold="True" Width="100px">Total a Pagar</asp:Label></td>
                        <td colspan="2">
                            <ew:NumericBox ID="txtTotPag" runat="server" AutoFormatCurrency="True" CssClass="TxtMostrarLb_Der "
                                ReadOnly="True" Width="160px"></ew:NumericBox></td>
                        <td style="width: 589px; text-align: left">
                        </td>
                        <td style="width: 589px; text-align: left">
                        </td>
                    </tr>
                    <tr>
                        <td colspan="4">
                            <asp:LinkButton ID="BtnDetalleHide" runat="server" Width="241px">Ocultar Detalles de Declaracion</asp:LinkButton><br />
                            <asp:LinkButton ID="BtnDetalleShow" runat="server" Width="166px">Ver Detalles De Declaracion</asp:LinkButton></td>
                        <td colspan="1">
                        </td>
                    </tr>
                </table>
                        &nbsp;
                <asp:MultiView ID="MultiView1" runat="server">
                    <asp:View ID="View1" runat="server">
                    <rsweb:reportviewer id="ReportViewer1" runat="server" asyncrendering="False" font-names="Verdana"
                        font-size="8pt" height="100%" sizetoreportcontent="True" width="800px">
                        <LOCALREPORT ReportPath="" OnSubreportProcessing="ReportViewer1_SubreportProcessing" /></rsweb:reportviewer>
                    </asp:View>
                </asp:MultiView>
                        <table>
                            <tr>
                                <td style="width: 173px">
                                    <asp:Label ID="Label10" runat="server" Font-Bold="True" Text="Cuenta Bancaria" Width="145px"></asp:Label></td>
                                <td style="width: 370px">
                                    <asp:TextBox ID="TxtCta" runat="server"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="ReqFielFecPre" runat="server" ControlToValidate="TFec_pre"
                                        ErrorMessage="Digite la Fecha en qe se Presentó la Declaracion" ValidationGroup="Radicar">*</asp:RequiredFieldValidator>
                                    <asp:LinkButton ID="BtnBuscDP" runat="server">...</asp:LinkButton>
                                </td>
                                <td style="width: 57px">
                            <asp:Button ID="BtRadicar" runat="server" Text="Aplicar Pago" ValidationGroup="Radicar" /></td>
                            </tr>
                            <tr>
                                <td style="width: 173px">
                                    <asp:Label ID="Label11" runat="server" Font-Bold="True" Text="Banco" Width="145px"></asp:Label></td>
                                <td style="width: 370px">
                                    <asp:TextBox ID="TxtBanCod" runat="server" Width="21px"></asp:TextBox>
                                    <asp:TextBox ID="TxtBanco" runat="server" Width="276px"></asp:TextBox></td>
                                <td style="width: 57px">
                                </td>
                            </tr>
                            <tr>
                                <td style="width: 173px">
                <asp:Label ID="Label5" runat="server" Text="Fecha de Presentación" Width="145px" Font-Bold="True"></asp:Label></td>
                                <td style="width: 370px">
                                    <asp:TextBox ID="TFec_pre" runat="server"></asp:TextBox></td>
                                <td style="width: 57px">
                                </td>
                            </tr>
                        </table>
                        <ajaxToolkit:CalendarExtender
                                            ID="CalendarExtender1" runat="server" TargetControlID="TFec_pre">
                                        </ajaxToolkit:CalendarExtender>
                                    <ajaxToolkit:ValidatorCalloutExtender ID="ValidatorCalloutExtender1" runat="server"
                                        TargetControlID="ReqFielFecPre">
                                    </ajaxToolkit:ValidatorCalloutExtender>
                    </asp:View>
                </asp:MultiView><br />
                <asp:UpdatePanel id="UpdatePanel2" runat="server" UpdateMode="Conditional">
                    <contenttemplate>
<!-- Mensaje de Salida--><asp:Button style="DISPLAY: none" id="hiddenTargetControlForModalPopup" runat="server"></asp:Button> <ajaxToolkit:ModalPopupExtender id="ModalPopup" runat="server" TargetControlID="hiddenTargetControlForModalPopup" RepositionMode="RepositionOnWindowScroll" PopupDragHandleControlID="programmaticPopupDragHandle" PopupControlID="programmaticPopup" DropShadow="True" BehaviorID="programmaticModalPopupBehavior" BackgroundCssClass="modalBackground">
            </ajaxToolkit:ModalPopupExtender> <asp:Panel id="programmaticPopup" runat="server" Width="625px" Height="229%" CssClass="ModalPanel2"><asp:Panel id="programmaticPopupDragHandle" runat="Server" Height="30px" CssClass="BarTitleModal2"><DIV style="PADDING-RIGHT: 5px; PADDING-LEFT: 5px; PADDING-BOTTOM: 5px; VERTICAL-ALIGN: middle; PADDING-TOP: 5px"><DIV style="FLOAT: left">Impuestos Web</DIV></DIV></asp:Panel>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<BR />&nbsp; &nbsp; &nbsp;&nbsp; <uc1:Con_Banco id="Con_Banco1" runat="server"></uc1:Con_Banco><BR /><BR /><BR /></asp:Panel> 
</contenttemplate>
                    <triggers>
<asp:AsyncPostBackTrigger ControlID="BtnBuscDP" EventName="Click"></asp:AsyncPostBackTrigger>
</triggers>
                </asp:UpdatePanel>
                <asp:ObjectDataSource ID="ObjClaseDec" runat="server" OldValuesParameterFormatString="original_{0}"
                    SelectMethod="GetRecords" TypeName="Cargar_ClaseDec"></asp:ObjectDataSource>
                <asp:ObjectDataSource ID="ObjVigencia" runat="server" OldValuesParameterFormatString="original_{0}"
                    SelectMethod="GetRecords" TypeName="Cargar_Periodo"></asp:ObjectDataSource>
                <asp:ObjectDataSource ID="ObjRequisitos" runat="server" OldValuesParameterFormatString="original_{0}"
                    SelectMethod="GetRecords" TypeName="Cargar_Req"></asp:ObjectDataSource><asp:ObjectDataSource ID="ObjRequisitos2" runat="server" OldValuesParameterFormatString="original_{0}"
                    SelectMethod="GetRecords" TypeName="Cargar_Req">
                        <SelectParameters>
                            <asp:ControlParameter ControlID="CmbClDec" Name="ClDec" PropertyName="SelectedValue"
                                Type="String" />
                            <asp:ControlParameter ControlID="LDEC_ANO" Name="Agravable" PropertyName="Text" Type="String" />
                            <asp:ControlParameter ControlID="LDEC_PER" Name="Pgravable" PropertyName="Text" Type="String" />
                        </SelectParameters>
                    </asp:ObjectDataSource>
                <br />
                
                <br />
                &nbsp; &nbsp;&nbsp;<asp:HiddenField ID="HdRof" runat="server" />
    </div>
</asp:Content>

