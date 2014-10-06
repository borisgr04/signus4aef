<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="Atram.aspx.vb" Inherits="Expediente_Atram_Atram" title="Abrir Expediente" %>
<%@ Register Src="../../CtrlUsr/Expedientes/Con_Expediente.ascx" TagName="ConsultaExpediente" TagPrefix="uc2" %>
<%@ Register Src="../../CtrlUsr/Expedientes/Anu_Expediente.ascx" TagName="CtrlAnulaExpeTram" TagPrefix="uc3" %>
<%@ Register Src="../../CtrlUsr/Expedientes/Anu_Expediente.ascx" TagName="CtrlAnulaApg" TagPrefix="uc4" %>
<asp:Content ID="Content1" ContentPlaceHolderID="SampleContent" Runat="Server">

    <script type='text/javascript'>
        
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

      function enviarExpediente(numExpediente)
        {
            document.aspnetForm.<%=Me.tbNumExp.ClientID%>.value=numExpediente ;
            var modalPopupBehavior = $find('programmaticModalPopupBehavior');
            modalPopupBehavior.hide();
            __doPostBack("<%= button.ClientID %>","");
        }

        function CerrarExpedienteModal()
        {
           var modalPopupBehavior = $find('programmaticModalPopupBehavior');
            modalPopupBehavior.hide();
        }
        
                       
        function pageLoad() {
            $addHandler($get("BtnCerrar"), 'click', CerrarExpedienteModal);        
        }
        function cancelClick() {
         
        }
        function cerrar(){ 
            var ventana = window.self; 
            ventana.opener = window.self; 
            ventana.close(); 
        } 
 </script>
    <asp:ScriptManager ID="ScriptManager1" runat="server" EnableScriptGlobalization="true">
    </asp:ScriptManager>
    <div class="demoarea">
        <asp:UpdatePanel ID="upMexpediente" runat="server">
        <ContentTemplate>
        <asp:Label ID="MsgResult" runat="server" Width="95%"></asp:Label>
            <table style="width: 100%;">
                <tr>
                    <td colspan="6">
                        &nbsp;</td>
                </tr>
                <tr class="TbDecl">
                    <td colspan="6">
                        <asp:Label ID="Label10" runat="server" Font-Bold="True" 
                            Text="DATOS GENERALES DEL EXPEDIENTE"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td style="width:100px">
                        <asp:Label ID="Label46" runat="server" CssClass="TitDecl" Font-Bold="True" 
                            Text="EXPEDIENTE No." ></asp:Label>
                    </td>
                    <td>
                        <asp:TextBox ID="tbNumExp" runat="server" style="width:100px" 
                            AutoPostBack="True"></asp:TextBox>
                        <asp:Button ID="btBuscarExp" runat="server" Text="..." style="width:30px"/>
                    </td>
                    <td>
                    &nbsp;
                        </td>
                    <td>
                        &nbsp;</td>
                    <td>
                        <asp:Label ID="lcodTramite" runat="server" CssClass="TitDecl" Visible="False"></asp:Label>
                    </td>
                    <td>
                        <asp:Label ID="lcodImpuesto" runat="server" CssClass="TitDecl" Visible="False"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="Label2" runat="server" CssClass="TitDecl" Font-Bold="True" 
                            Text="IMPUESTO"></asp:Label>
                    </td>
                    <td style="width:340px">
                        <asp:TextBox ID="tbImpuesto" runat="server" style="width:340px"></asp:TextBox>
                    </td>
                    <td style="width:50px">
                        <asp:Label ID="Label47" runat="server" CssClass="TitDecl" Font-Bold="True" 
                            Text="FECHA"></asp:Label>
                    </td>
                    <td>
                        <asp:TextBox ID="tbFechaExp" runat="server" ReadOnly="True" 
                            style="width:100px"></asp:TextBox>
                    </td>
                    <td>
                        <asp:Label ID="lIdExpeTram" runat="server" CssClass="TitDecl" Visible="False"></asp:Label>
                    </td>
                    <td>
                        &nbsp;</td>
                </tr>
                </table>
                <table style="width: 100%;">
                <tr class="TbDecl">
                    <td colspan="6">
                        <asp:Label ID="Label5" runat="server" Font-Bold="True" 
                            Text="AGENTE RETENEDOR"></asp:Label>
                        &nbsp;O CONTRIBUYENTE</td>
                </tr>
                <tr>
                    <td style ="width:175px">
                        <asp:Label ID="Label45" runat="server" CssClass="TitDecl" Font-Bold="True" 
                            Text="IDENTIFICACIÓN"></asp:Label>
                    </td>
                    <td style ="width:135px">
                        <asp:Label ID="Label11" runat="server" CssClass="TitDecl" Font-Bold="True" 
                            Text="RAZON SOCIAL"></asp:Label>
                    </td>
                    <td style ="width:135px">
                        &nbsp;</td>
                    <td style ="width:135px">
                        &nbsp;</td>
                    <td style ="width:135px">
                        <asp:Label ID="Label1" runat="server" CssClass="TitDecl" Font-Bold="True" 
                            Text="MUNICIPIO"></asp:Label>
                    </td>
                    <td style ="width:135px">
                        &nbsp;</td>
                </tr>
                <tr>
                    <td>
                        <asp:Button style="DISPLAY: none" id="button" runat="server" >
                        </asp:Button> 
                        <asp:TextBox ID="lNit" runat="server" ReadOnly="True" Width="87px"></asp:TextBox>
                        <asp:TextBox ID="lDV" runat="server" ReadOnly="True" Width="23px"></asp:TextBox>
                    </td>
                    <td colspan="3">
                        <asp:TextBox ID="lAgente" runat="server" ReadOnly="True" Width="520px"></asp:TextBox>
                    </td>
                    <td colspan="2">
                        <asp:TextBox ID="lMunicipio" runat="server" ReadOnly="True" Width="270px"></asp:TextBox>
                    </td>
                </tr>
                    <tr>
                        <td>
                            <asp:Label ID="Label49" runat="server" CssClass="TitDecl" Font-Bold="True" 
                                Text="REPRESENTANTE LEGAL"></asp:Label>
                        </td>
                        <td colspan="2">
                            <asp:TextBox ID="lRepLegal" runat="server" ReadOnly="True" Width="360px"></asp:TextBox>
                        </td>
                        <td>
                            &nbsp;</td>
                        <td>
                            &nbsp;</td>
                        <td>
                            &nbsp;</td>
                    </tr>
                <tr class="TbDecl">
                    <td colspan="6">
                        <asp:Label ID="Label8" runat="server" Font-Bold="True" 
                            Text="ESTADO ACTUAL DEL EXPEDIENTE"></asp:Label>
                    </td>
                </tr>
                </table>
            <table style="width: 100%">    
                <tr>
                    <td>
                        <asp:Label ID="Label6" runat="server" CssClass="TitDecl" Font-Bold="True" 
                            Text="PROCESO"></asp:Label>
                    </td>
                    <td>
                        <asp:Label ID="Label7" runat="server" CssClass="TitDecl" Font-Bold="True" 
                            Text="No."></asp:Label>
                    </td>
                    <td>
                        <asp:Label ID="Label4" runat="server" CssClass="TitDecl" Font-Bold="True" 
                            Text="TRAMITE ACTUAL"></asp:Label>
                    </td>
                    <td>
                        <asp:Label ID="Label50" runat="server" CssClass="TitDecl" Font-Bold="True" 
                            Text="FECHA VENCIMIENTO"></asp:Label>
                    </td>
                    <td>
                        <asp:Label ID="Label51" runat="server" CssClass="TitDecl" Font-Bold="True" 
                            Text="No. DEL DOCUMENTO"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td style="width:110px">
                        <asp:TextBox ID="lProceso" runat="server" ReadOnly="True" Text="" Width="110px"></asp:TextBox>
                    </td>
                    <td style="width:50px">
                        <asp:TextBox ID="lNumProc" runat="server" ReadOnly="True" Text="" Width="50px"></asp:TextBox>
                    </td>
                    <td style="width:340px">
                        <asp:TextBox ID="lTramite" runat="server" ReadOnly="True" Text="" Width="340px"></asp:TextBox>
                    </td>
                    <td style="width:130px">
                        <asp:TextBox ID="tbFechaExpira" runat="server" ReadOnly="True" style="width:130px"></asp:TextBox>
                    </td>
                    <td style="width:130px">
                        <asp:TextBox ID="tbConsecutivo" runat="server" style="width:130px"></asp:TextBox>
                    </td>
                </tr>
                </table>
            
            <asp:Panel ID="pCtrlUsuario1" runat="server">
            <table style="width: 800px;">
                <tr>
                    <td style="width:100px">
                        &nbsp;</td>
                    <td style="width:100px">
                        &nbsp;</td>
                    <td style="width:100px">
                        &nbsp;</td>
                    <td style="width:100px">
                        &nbsp;</td>
                    <td style="width:100px">
                        &nbsp;</td>
                    <td style="width:100px">
                        &nbsp;</td>
                    <td style="width:100px">
                        &nbsp;</td>
                    <td style="width:100px">
                        &nbsp;</td>
                </tr>
                <tr>
                    <td colspan="2" align="center">
                        <asp:ImageButton ID="btSgteTram" runat="server" 
                            ImageUrl="~/images/Operaciones/list2.png" />
                    </td>
                    <td colspan="2" align="center">
                        <asp:ImageButton ID="btRadicado" runat="server" 
                            ImageUrl="~/images/Operaciones/mail4.png" />
                    </td>
                    <td colspan="2" align="center">
                        <asp:ImageButton ID="btGenDoc" runat="server" 
                            ImageUrl="~/images/Operaciones/word.png" />
                    </td>
                    <td align="center" colspan="2">
                        <asp:ImageButton ID="btAcuerdo" runat="server" 
                            ImageUrl="~/images/Operaciones/cartera1.png" />
                    </td>
                </tr>
                <tr>
                    <td colspan="2" align="center">
                        Parsar a Siguiente Tramite</td>
                    <td colspan="2" align="center">
                        Notificacion de Envios
                    </td>
                    <td colspan="2" align="center">
                        Imprimir Documento Actual</td>
                    <td align="center" colspan="2">
                        Acuerdo de Pago </td>
                </tr>
            </table>  
            </asp:Panel>
            
            <table style="width: 100%;">
                <tr>
                    <td>
                        &nbsp;</td>
                </tr>
                <tr class="TbDecl">
                    <td>
                        <asp:Label ID="Label48" runat="server" Font-Bold="True" Text="PERIODOS ADEUDADOS"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td>
                        &nbsp;</td>
                </tr>
            </table>     
        </ContentTemplate>
        </asp:UpdatePanel>
       
        <asp:UpdatePanel ID="upPeriodos" runat="server">
        <ContentTemplate>
            <asp:Panel ID="pPeriodos" runat="server">
                 <asp:Panel ID="pCtrlUsuario2" runat="server">
                     <asp:GridView ID="gvPeriodos" runat="server" AllowPaging="True" 
                         AutoGenerateColumns="False" DataKeyNames="EXAP_AGRA,EXAP_PGRA" 
                         DataSourceID="odsPeriodos" PageSize="12" ShowFooter="True" Width="850px">
                         <Columns>
                             <asp:BoundField DataField="EXAP_SUIM" HeaderText="Vehiculo">
                                 <HeaderStyle HorizontalAlign="Left" />
                                 <ItemStyle HorizontalAlign="Left" />
                             </asp:BoundField>
                             <asp:BoundField DataField="EXAP_AGRA" HeaderText="Año Gravable">
                                 <HeaderStyle HorizontalAlign="Left" />
                             </asp:BoundField>
                             <asp:BoundField DataField="CAL_DES" HeaderText="Periodo Gravable">
                                 <HeaderStyle HorizontalAlign="Left" />
                             </asp:BoundField>
                             <asp:BoundField DataField="CAR_TDOC" HeaderText="Tipo Formulario">
                                 <HeaderStyle HorizontalAlign="Left" />
                             </asp:BoundField>
                             <asp:BoundField DataField="CAR_DCOD" HeaderText="Formulario No.">
                                 <HeaderStyle HorizontalAlign="Left" />
                             </asp:BoundField>
                             <asp:BoundField DataField="CAR_ACPA" HeaderText="Acuerdo de Pago No.">
                                 <HeaderStyle HorizontalAlign="Left" />
                             </asp:BoundField>
                             <asp:BoundField DataField="SALDO" DataFormatString="{0:c}" 
                                 HeaderText="Saldo de Cartera">
                                 <HeaderStyle HorizontalAlign="Left" />
                                 <ItemStyle HorizontalAlign="Right" />
                             </asp:BoundField>
                             <asp:BoundField DataField="CAR_EST" HeaderText="Estado">
                                 <HeaderStyle HorizontalAlign="Left" />
                             </asp:BoundField>
                             <asp:TemplateField>
                                 <ItemTemplate>
                                     <asp:ImageButton ID="btEliminar" runat="server" 
                                         CommandArgument="<%# CType(Container,GridViewRow).RowIndex %>" 
                                         CommandName="Eliminar" ImageUrl="~/images/Operaciones/delete2.png" />
                                 </ItemTemplate>
                             </asp:TemplateField>
                             <asp:CommandField SelectText="Liquidar" ShowSelectButton="True" />
                         </Columns>
                     </asp:GridView>
                 </asp:Panel> 
             </asp:Panel> 
            
        </ContentTemplate>
        </asp:UpdatePanel>  

        <asp:UpdatePanel ID="upTramites" runat="server">
        <ContentTemplate>
            <table style="width: 100%;">
                <tr>
                    <td>
                        
                        &nbsp;</td>
                </tr>
                <tr class="TbDecl">
                    <td>
                        <asp:Label ID="Label3" runat="server" Font-Bold="True" 
                            Text="TRAMITES EFECTUADOS"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td>
                        &nbsp;</td>
                </tr>
            </table>
            <asp:Panel ID="pTramite" runat="server">
            <asp:GridView ID="gvTramites" runat="server" AutoGenerateColumns="False" 
                DataKeyNames="EXTR_ID" DataSourceID="odsExpTram" Width="100%">
                <Columns>
                    <asp:BoundField DataField="EXTR_ID" Visible="False" />
                    <asp:BoundField DataField="EXTR_FELA" DataFormatString="{0:d}" 
                        HeaderText="Fecha Elaboracion">
                        <HeaderStyle HorizontalAlign="Left" />
                        <ItemStyle Width="90px" />
                    </asp:BoundField>
                    <asp:BoundField DataField="TRAM_ANTERIOR" HeaderText="Tramite Anterior">
                        <HeaderStyle HorizontalAlign="Left" />
                    </asp:BoundField>
                    <asp:BoundField DataField="TRAM_ACTUAL" HeaderText="Tramite Actual">
                        <HeaderStyle HorizontalAlign="Left" />
                    </asp:BoundField>
                    <asp:BoundField DataField="EXTR_DONU" HeaderText="No. Documento">
                        <HeaderStyle HorizontalAlign="Left" />
                        <ItemStyle Width="90px" />
                    </asp:BoundField>
                    <asp:BoundField DataField="NOMB_NOTIF" HeaderText="Notificacion">
                        <HeaderStyle HorizontalAlign="Left" />
                    </asp:BoundField>
                    <asp:BoundField DataField="EXPE_FREB" DataFormatString="{0:d}" 
                        HeaderText="Fecha Recibido">
                        <HeaderStyle HorizontalAlign="Left" />
                        <ItemStyle Width="90px" />
                    </asp:BoundField>
                    <asp:BoundField DataField="EXPE_FEXP" DataFormatString="{0:d}" 
                        HeaderText="Fecha Vencimiento" >
                        <HeaderStyle HorizontalAlign="Left" />
                        <ItemStyle Width="90px" />
                    </asp:BoundField>
                     <asp:TemplateField>
                         <ItemTemplate>
                             <asp:ImageButton ID="btEliminar" runat="server" CommandName="Eliminar" 
                             CommandArgument="<%# CType(Container,GridViewRow).RowIndex %>"
                             ImageUrl="~/images/Operaciones/delete2.png"/>
                         </ItemTemplate>
                         <ItemStyle Width="15px" />
                     </asp:TemplateField>
                     
                    <asp:CommandField ButtonType="Image" 
                        SelectImageUrl="~/images/Operaciones/word1.png" SelectText="Documento" 
                        ShowSelectButton="True" >
                        <ItemStyle Width="15px" />
                    </asp:CommandField>
                </Columns>
            </asp:GridView>
            </asp:Panel>
        </ContentTemplate>
        </asp:UpdatePanel>
        
        <asp:UpdatePanel id="UpdatePanel2" runat="server" UpdateMode="Conditional">
        <contenttemplate>
        <!-- Expediente Modal-->
        <asp:Button style="DISPLAY: none" id="hiddenTargetControlForModalPopup" runat="server">
        </asp:Button> 
        <ajaxToolkit:ModalPopupExtender id="ModalPopup" runat="server" 
            TargetControlID="hiddenTargetControlForModalPopup" 
            RepositionMode="RepositionOnWindowScroll" 
            PopupDragHandleControlID="programmaticPopupDragHandle" 
            PopupControlID="programmaticPopup" DropShadow="True" 
            BehaviorID="programmaticModalPopupBehavior" BackgroundCssClass="modalBackground">
        </ajaxToolkit:ModalPopupExtender> 
        <asp:Panel id="programmaticPopup" runat="server" Width="750px" Height="229%" CssClass="ModalPanel2">
            <asp:Panel id="programmaticPopupDragHandle" runat="Server" Height="30px" CssClass="BarTitleModal2">
                <div style="padding-right: 5px; padding-left: 5px; padding-bottom: 5px; vertical-align: middle;
                         padding-top: 5px">
                    <div style="FLOAT: left">Buscar Expedientes</DIV>
                    <div style="float: right">
                        <input id="BtnCerrar" type="button" value="X" onclick="javascript:CerrarExpedienteModal();" />
                     </div> 
                </div>
            </asp:Panel>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <br />&nbsp; &nbsp; &nbsp;&nbsp; 
            
            <uc2:ConsultaExpediente id="ConsultaExpediente1" runat="server">
            </uc2:ConsultaExpediente><br /><br /><br />
        </asp:Panel> 
        </contenttemplate> 
        <triggers>
            <asp:AsyncPostBackTrigger ControlID="btBuscarExp" EventName="Click"></asp:AsyncPostBackTrigger>
        </triggers>
        </asp:UpdatePanel>
        
        <asp:UpdatePanel ID="upAnularTram" runat="server" UpdateMode="Conditional" >
        <ContentTemplate>
        <ajaxToolkit:ModalPopupExtender id="ModalPopupAnular" runat="server" 
            TargetControlID="btn_Target" 
            PopupControlID="pAnularExpeTram"
            PopupDragHandleControlID="pAnularExpeTram2"
            DropShadow ="true"
            BackgroundCssClass="modalBackground">
        </ajaxToolkit:ModalPopupExtender> 
        <asp:Panel id="pAnularExpeTram" runat="server" Width="450px" Height="239%" CssClass="ModalPanel2">
            <asp:Panel id="pAnularExpeTram2" runat="Server" Height="30px" CssClass="BarTitleModal2">
                <div style="padding-right: 5px; padding-left: 5px; padding-bottom: 5px; vertical-align: middle;
                         padding-top: 5px">
                    <div style="FLOAT: left">Anular Tramite de Expediente</DIV>
                    <div style="float: right">
                        <asp:Button ID="btCerrarAnular" runat="server" Text="X" /> 
                    </div> 
                </div>
            </asp:Panel>
             <uc3:CtrlAnulaExpeTram id="CtrlAnulaExpeTram2" runat="server">
            </uc3:CtrlAnulaExpeTram><br /><br /><br />
            <asp:Button style="display:none" id="btn_Target" runat ="server"></asp:Button>
        </asp:Panel> 
        </ContentTemplate>
        </asp:UpdatePanel> 
        
        <asp:UpdatePanel ID="UpAnulaApg" runat="server" UpdateMode="Conditional" >
        <ContentTemplate>
        <ajaxToolkit:ModalPopupExtender id="ModalPopupAnulaApg" runat="server" 
            TargetControlID="btn_Target_AnulaApg" 
            PopupControlID="pAnulaApg"
            PopupDragHandleControlID="pAnulaApg2"
            DropShadow ="true"
            BackgroundCssClass="modalBackground">
        </ajaxToolkit:ModalPopupExtender> 
        <asp:Panel id="pAnulaApg" runat="server" Width="450px" Height="239%" CssClass="ModalPanel2">
            <asp:Panel id="pAnulaApg2" runat="Server" Height="30px" CssClass="BarTitleModal2">
                <div style="padding-right: 5px; padding-left: 5px; padding-bottom: 5px; vertical-align: middle;
                         padding-top: 5px">
                    <div style="FLOAT: left">Anular Año y Perido Gravable del Expediente</DIV>
                    <div style="float: right">
                        <asp:Button ID="btCerrarAnulaApg" runat="server" Text="X" /> 
                    </div> 
                </div>
            </asp:Panel>
             <uc4:CtrlAnulaApg id="CtrlAnulaApg1" runat="server">
            </uc4:CtrlAnulaApg><br /><br /><br />
            <asp:Button style="display:none" id="btn_Target_AnulaApg" runat ="server"></asp:Button>
        </asp:Panel> 
        </ContentTemplate>
        </asp:UpdatePanel> 
    </div>
        <asp:ObjectDataSource ID="odsPeriodos" runat="server" SelectMethod="GetSaldoPorPeriodo" 
        TypeName="Expe_Apg" OldValuesParameterFormatString="original_{0}">
        <SelectParameters>
            <asp:ControlParameter ControlID="lNit" Name="Nit" 
                PropertyName="Text" Type="String" />
            <asp:ControlParameter ControlID="lcodImpuesto" Name="Impuesto" 
                PropertyName="Text" Type="String" />
            <asp:ControlParameter ControlID="tbNumExp" Name="numExpediente" 
                PropertyName="Text" Type="String" />
        </SelectParameters>
    </asp:ObjectDataSource>
        <asp:ObjectDataSource ID="odsExpTram" runat="server" SelectMethod="GetPorNumExpe" 
        TypeName="Expe_Tram" OldValuesParameterFormatString="original_{0}">
            <SelectParameters>
                <asp:ControlParameter ControlID="tbNumExp" Name="numExpediente" 
                    PropertyName="Text" Type="String" />
            </SelectParameters>
    </asp:ObjectDataSource>
        <asp:UpdateProgress ID="UpdateProgress1" runat="server" AssociatedUpdatePanelID="upMexpediente">
            <ProgressTemplate>
                <div class="Loading">
                    <img alt="" src="../../images/loading.gif" title="" />
                    Cargando …
                </div>
            </ProgressTemplate>
    </asp:UpdateProgress>  
</asp:Content>

