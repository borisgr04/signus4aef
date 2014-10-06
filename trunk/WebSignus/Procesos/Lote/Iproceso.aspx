<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="Iproceso.aspx.vb" Inherits="Procesos_Lote_Lote" title="Nuevo Proceso por Lote" %>
<%@ Register Src="../../CtrlUsr/Terceros/ConsultaTer.ascx" TagName="ConsultaTer" TagPrefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="SampleContent" Runat="Server">

    <script type='text/javascript'>
  
  // Add click handlers for buttons to show and hide modal popup on pageLoad
        function pageLoad() {
            $addHandler($get("BtnCerrar"), 'click', CerrarModalTercero);        
        }

       function CerrarModalTercero(ev) {
            ev.preventDefault();        
            var modalPopupBehavior2 = $find('programmaticModalPopupBehavior2');
            modalPopupBehavior2.hide();
        }
        
        function CerrarTercero()
        {
           var modalPopupBehavior2 = $find('programmaticModalPopupBehavior2');
            modalPopupBehavior2.hide();
        }



    function cancelClick() {
        var label = $get('ctl00_SampleContent_LbRpt');
        label.innerHTML = 'You hit cancel in the Confirm dialog on ' + (new Date()).localeFormat("T") + '.';
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
                document.aspnetForm.<%=Me.NIT.ClientID%>.value=ced;
                //document.getElementById('x').innerHTML=ced;
                document.aspnetForm.<%=Me.DV.ClientID%>.value=dv;
                document.aspnetForm.<%=Me.AGENTE.ClientID%>.value=rsocial;
            }
            CerrarTercero()
        } 
  
    </script>    
    <ajaxToolkit:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server" AsyncPostBackTimeout="600">
    </ajaxToolkit:ToolkitScriptManager>
    <div class="demoarea">
    <asp:UpdatePanel id="UpdatePanel1" runat="server">
     <contenttemplate>
         <asp:Label ID="MsgResult" runat="server" Width="90%"></asp:Label>
         <table style="width:700px;">
             <tr>
                 <td colspan="6">
                     &nbsp;</td>
             </tr>
             <tr>
                 <td colspan="6">
                     
                 </td>
             </tr>
             <tr class="TbDecl">
                <td colspan="3">
                <asp:Label id="Label10" runat="server" Font-Bold="True" Text="INICIAR NUEVO PROCESO - ESTAMPILLAS DEPARTAMENTALES" ></asp:Label> 
                </td> 
                 <td colspan="3">
                     PROCESO No.
                     <asp:Label ID="lNumProceso" runat="server" Text="" Font-Bold="True" Visible="false" ></asp:Label>
                 </td>
             </tr>
             <tr>
                 <td style="width:100px">
                     Proceso
                 </td>
                 <td style="width:140px">
                     <asp:DropDownList ID="cmbProceso" runat="server" style="width:100%" 
                         DataSourceID="odsProcesos" DataTextField="PROC_NOMB" DataValueField="PROC_CODI" 
                      >
                     </asp:DropDownList>
                 </td>
                 <td style="width:100px">
                     &nbsp;Impuesto
                 </td>
                 <td colspan="2">
                     <asp:DropDownList ID="cmbImpuesto" runat="server" AutoPostBack="True" 
                         DataSourceID="odsImpuesto" DataTextField="CLD_NOM" DataValueField="CLD_COD" 
                         style="width:100%">
                     </asp:DropDownList>
                 </td>
                 <td style="width:160px">
                     &nbsp;</td>
             </tr>
             <tr>
                 <td>
                     Vigencia Inicial</td>
                 <td>
                     <asp:DropDownList ID="cmbVigencia" runat="server" 
                         DataSourceID="odsVigencias" DataTextField="CAL_VIG" DataValueField="CAL_VIG" 
                         style="width:100%" AutoPostBack="True">
                     </asp:DropDownList>
                 </td>
                 <td>
                     Periodo Inicial </td>
                 <td>
                     <asp:DropDownList ID="cmbPeriodo" runat="server" DataSourceID="odsPeriodo" 
                         DataTextField="cal_des" DataValueField="cal_per" style="width:100%">
                     </asp:DropDownList>
                 </td>
                 <td>
                     &nbsp;</td>
                 <td>
                     <asp:Label ID="ltramite" runat="server" Visible="False"></asp:Label>
                 </td>
             </tr>
             <tr>
                 <td>
                     Vigencia Final</td>
                 <td>
                     <asp:DropDownList ID="cmbVigencia1" runat="server" 
                         DataSourceID="odsVigencias" DataTextField="CAL_VIG" DataValueField="CAL_VIG" 
                         style="width:100%" AutoPostBack="True">
                     </asp:DropDownList>
                 </td>
                 <td>
                     Periodo Final</td>
                 <td>
                     <asp:DropDownList ID="cmbPeriodo1" runat="server" DataSourceID="odsPeriodo1" 
                         DataTextField="cal_des" DataValueField="cal_per" style="width:100%">
                     </asp:DropDownList>
                 </td>
                 <td>
                     &nbsp;</td>
                 <td>
                 </td>
             </tr>
             <tr>
                 <td>
                     <asp:CheckBox ID="chMunicipo" Text="Municipio" runat="server" />
                 </td>
                 <td>
                     <asp:DropDownList ID="cmbMunicipio" runat="server" DataSourceID="odsMunicipios" 
                         DataTextField="MUN_NOM" DataValueField="MUN_COD" Height="16px" 
                         style="width:100%">
                     </asp:DropDownList>
                 </td>
                 <td>
                     &nbsp;</td>
                 <td>
                     &nbsp;</td>
                 <td>
                     &nbsp;</td>
                 <td>
                     &nbsp;</td>
             </tr>
             <tr>
                 <td>
                     <asp:CheckBox ID="CBTPAR" runat="server" Text="Tipo Agente" />
                 </td>
                 <td colspan="3">
                     <asp:DropDownList ID="CbTTcer" runat="server" DataSourceID="ObjTTer" 
                         DataTextField="TAG_NOM" DataValueField="TAG_COD" Width="180px">
                     </asp:DropDownList>
                 </td>
                 <td>
                     &nbsp;</td>
                 <td>
                     &nbsp;</td>
             </tr>
             <tr>
                <td>
                    <asp:CheckBox ID="chTercero" runat="server" Text="Entidad" />
                </td>
                 <td >
                     <asp:TextBox ID="Nit" runat="server" Enabled="False" Width="100%" ></asp:TextBox>
                     
                 </td>
                 <td colspan="4">
                 <asp:TextBox ID="Dv" runat="server" Enabled="False" Width="17px">
                     </asp:TextBox>
                     <asp:Button ID="BtnBuscDP" runat="server" accessKey="B" 
                         onclick="BtnBuscar_Click" Text="..." ToolTip="Buscar Agente Recaudador" 
                         UseSubmitBehavior="False" Width="17px" CausesValidation="False" />
                     <asp:TextBox ID="Agente" runat="server" Enabled="False" Width="220px">
                     </asp:TextBox>
                  </td>
             </tr>
             <tr>
                 <td>
                     Auto de Apertura No.</td>
                 <td>
                     <asp:TextBox ID="tbConsecutivo" runat="server"></asp:TextBox>
                     <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
                         ControlToValidate="tbConsecutivo" ErrorMessage="*"></asp:RequiredFieldValidator>
                 </td>
                 <td>
                     &nbsp;</td>
                 <td colspan="2">
                     &nbsp;</td>
                 <td>
                     &nbsp;</td>
             </tr>
         </table>
         <table>    
             <tr>
                 <td>
                     &nbsp;</td>
                 <td>
                     &nbsp;</td>
                 <td>
                     &nbsp;</td>
                 <td>
                     &nbsp;</td>
                 <td>
                     &nbsp;</td>
             </tr>
             <tr>
                 <td align="center" style="width:80px">
                     <asp:ImageButton ID="btBuscar" runat="server" AlternateText="Buscar" 
                         CausesValidation="False" ImageUrl="~/images/Operaciones/search2.png" />
                 </td>
                 <td align="center" style="width:80px">
                     <asp:ImageButton ID="BtIniciar" runat="server" 
                         ImageUrl="~/images/Operaciones/save.png" />
                 </td>
                 <td align="center" style="width:80px">
                     <asp:ImageButton ID="btDescargar" runat="server" 
                         ImageUrl="~/images/Operaciones/word.png" CausesValidation="False" />
                 </td>
                 <td align="center" style="width:120px">
                     <asp:ImageButton ID="btSgteTram" runat="server" 
                         ImageUrl="~/images/Operaciones/list2.png" CausesValidation="False" />
                 </td>
                 <td align="center" style="width:80px">
                    <asp:ImageButton ID="btExpedientes" runat="server" 
                         ImageUrl="~/images/imagev2/blog-post-accept-icon.png" 
                         CausesValidation="False" />
                 </td>
             </tr>
             <tr>
                <td align="center">
                    1. Buscar
                </td>
                <td align="center">
                    2. Generar</td>
                 <td align="center">
                     3. Descargar</td>
                 <td align="center">
                     4. Siguiente Tramite</td>
                 <td align="center">
                     5. Expedientes</td>
             </tr>
             <tr>
                 <td colspan="2">
                     &nbsp;</td>
                 <td>
                     &nbsp;</td>
                 <td>
                     &nbsp;</td>
                 <td>
                     &nbsp;</td>
             </tr>
         </table>
         <table style="width:700px;">
             <tr class="TbDecl">
                 <td colspan="6">
                 <asp:Label id="lTitulo" text="" runat="server" ></asp:Label>
                 </td>
             </tr>
             <tr>
                <td>
                    <asp:CheckBox ID="chTodos" runat="server" AutoPostBack="True" 
                        Text="Seleccionar Todos" Visible="False" />
                </td>
             </tr>
         </table> 
         <asp:Panel  id="pConsulta" runat="server" Visible="true" ScrollBars="Auto" Width="100%" Height="530px">
         <div style="width:100%">
             <asp:Label ID="lmensaje" runat="server" Text=""></asp:Label>
             <div style="float:left;width:65%">
              <asp:GridView ID="gvConsulta" runat="server" 
                 AutoGenerateColumns="False" DataKeyNames="TER_NIT" PageSize="20">
                 <Columns>
                     <asp:TemplateField>
                         <ItemTemplate>
                             <asp:CheckBox ID="CheckBox1" runat="server" />
                         </ItemTemplate>
                     </asp:TemplateField>
                     <asp:BoundField DataField="TER_NIT" HeaderText="Nit">
                         <HeaderStyle HorizontalAlign="Left" />
                         <ItemStyle Width="100px" />
                     </asp:BoundField>
                     <asp:BoundField DataField="TER_NOM" HeaderText="Agente Recaudador">
                         <HeaderStyle HorizontalAlign="Left" />
                         <ItemStyle Width="300px" />
                     </asp:BoundField>
                     <asp:CommandField SelectText="Periodos" ShowSelectButton="True" />
                 </Columns>
             </asp:GridView>   
             </div>
             <div style="float:right;width:30%">
              <asp:DataList ID="dlDetalle" runat="server" DataSourceID="odsDetalle" 
                    CellPadding="4" ForeColor="#333333" Visible="False">
             <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                 <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                 <AlternatingItemStyle BackColor="White" ForeColor="#284775" />
                 <ItemStyle BackColor="#F7F6F3" ForeColor="#333333" />
                 <SelectedItemStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
             <HeaderTemplate>
                <table style="width:100%">
                     <tr>
                        <td style="width:80px">
                            Periodo
                        </td> 
                        <td style="width:100px">
                            Vigencia                        
                        </td>
                      </tr> 
                </table> 
             </HeaderTemplate>
             <ItemTemplate>
                <table>
                     <tr>
                        <td style="width:80px">
                            <asp:Label ID="lPeriodo" runat="server" Text='<%# Bind("CAL_DES") %>'></asp:Label> 
                        </td>
                        <td style="width:100px">
                            <asp:Label ID="lVigencia" runat="server" Text='<%# Bind("CAL_VIG") %>'></asp:Label> 
                        </td>
                    </tr>
                </table>
             </ItemTemplate>
             </asp:DataList>
             </div>
            
         </div>
        </asp:Panel>
     </contenttemplate>
     </asp:UpdatePanel>
    <asp:UpdatePanel id="UpdatePanel2" runat="server" UpdateMode="Conditional">
    <contenttemplate>
    <!-- Mensaje de Salida-->
    <asp:Button style="DISPLAY: none" id="hiddenTargetControlForModalPopup2" runat="server">
    </asp:Button> 
    <ajaxToolkit:ModalPopupExtender id="ModalPopupTer" runat="server" BackgroundCssClass="modalBackground" BehaviorID="programmaticModalPopupBehavior2" DropShadow="True" PopupControlID="programmaticPopup2" PopupDragHandleControlID="programmaticPopupDragHandle2" RepositionMode="RepositionOnWindowScroll" TargetControlID="hiddenTargetControlForModalPopup2">
    </ajaxToolkit:ModalPopupExtender> 
    <asp:Panel id="programmaticPopup2" runat="server" Width="625px" Height="229%" CssClass="ModalPanel2"><asp:Panel id="programmaticPopupDragHandle2" runat="Server" Height="30px" CssClass="BarTitleModal2">
        <div style="padding-right: 5px; padding-left: 5px; padding-bottom: 5px; vertical-align: middle;
                             padding-top: 5px">
            <div style="float: left">
                Buscar Tercero
            </div>
            <div style="float: right">
                <input id="BtnCerrar" type="button" value="X" onclick="javascript:CerrarTercero();" />
            </div>
        </div>
    </asp:Panel> &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
    <BR/>&nbsp; &nbsp; &nbsp;&nbsp; 
    <uc1:ConsultaTer id="ConsultaTer1" runat="server" ret="AR" Tipo="AR">
    </uc1:ConsultaTer> <BR /><BR /><BR />
    </asp:Panel> 
    </contenttemplate>
    <triggers>
        <asp:AsyncPostBackTrigger ControlID="BtnBuscDP" EventName="Click"></asp:AsyncPostBackTrigger>
    </triggers>
    </asp:UpdatePanel>
        <asp:ObjectDataSource ID="odsDetalle" runat="server" 
            SelectMethod="GetPeriodosAdeudadosSinExpediente" TypeName="Expe_Apg" 
            OldValuesParameterFormatString="original_{0}">
            <SelectParameters>
                <asp:ControlParameter ControlID="cmbPeriodo" DefaultValue="00" Name="Per_Ini" 
                    PropertyName="SelectedValue" Type="String" />
                <asp:ControlParameter ControlID="cmbPeriodo1" DefaultValue="00" Name="Per_Fin" 
                    PropertyName="SelectedValue" Type="String" />
                <asp:ControlParameter ControlID="cmbVigencia" DefaultValue="" Name="Vig_Ini" 
                    PropertyName="SelectedValue" Type="String" />
                <asp:ControlParameter ControlID="cmbVigencia1" Name="Vig_Fin" 
                    PropertyName="SelectedValue" Type="String" />
                <asp:ControlParameter ControlID="cmbImpuesto" Name="Impuesto" 
                    PropertyName="SelectedValue" Type="String" DefaultValue="" />
                <asp:ControlParameter ControlID="gvConsulta" DefaultValue="0" Name="Nit" 
                    PropertyName="SelectedValue" Type="String" />
                <asp:Parameter DefaultValue="" Name="CodMpio" Type="String" />
            </SelectParameters>
        </asp:ObjectDataSource>
    <asp:ObjectDataSource ID="odsProcesos" runat="server" SelectMethod="GetProcesoHabilitados" TypeName="Procesos"></asp:ObjectDataSource>
    <asp:ObjectDataSource ID="odsTramites" runat="server" SelectMethod="GetPorProc" 
            TypeName="Tramites" OldValuesParameterFormatString="original_{0}">
        <SelectParameters>
        <asp:ControlParameter ControlID="cmbProceso" Name="TRAM_PROC" PropertyName="SelectedValue"
          Type="String" />
        </SelectParameters>
    </asp:ObjectDataSource>
    <asp:ObjectDataSource ID="odsMunicipios" runat="server" SelectMethod="GetRecords" TypeName="Municipios"></asp:ObjectDataSource>
    <asp:ObjectDataSource ID="odsVigencias" runat="server" SelectMethod="GetVigencias" TypeName="Calendario">
    <SelectParameters>
        <asp:ControlParameter ControlID="cmbImpuesto" Name="Cla_Dec" PropertyName="SelectedValue"
          Type="String" />
        </SelectParameters>
    </asp:ObjectDataSource>
    <asp:ObjectDataSource ID="odsImpuesto" runat="server" SelectMethod="GetcargarTipoDecla" TypeName="Informes"></asp:ObjectDataSource>
    <asp:ObjectDataSource ID="odsPeriodo" runat="server" 
        SelectMethod="GetPorClaseDec" TypeName="Calendario" 
            OldValuesParameterFormatString="original_{0}">
        <SelectParameters>
            <asp:ControlParameter ControlID="cmbImpuesto" Name="Cla_Dec" PropertyName="SelectedValue"
                Type="String" />
            <asp:ControlParameter ControlID="cmbVigencia" Name="Vigencia" PropertyName="SelectedValue"
                Type="String" />
        </SelectParameters>
    </asp:ObjectDataSource>
        <asp:ObjectDataSource ID="odsPeriodo1" runat="server" 
        SelectMethod="GetPorClaseDec" TypeName="Calendario" 
            OldValuesParameterFormatString="original_{0}">
        <SelectParameters>
            <asp:ControlParameter ControlID="cmbImpuesto" Name="Cla_Dec" PropertyName="SelectedValue"
                Type="String" />
            <asp:ControlParameter ControlID="cmbVigencia1" Name="Vigencia" PropertyName="SelectedValue"
                Type="String" />
        </SelectParameters>
    </asp:ObjectDataSource>

             <asp:ObjectDataSource id="ObjTTer" runat="server" TypeName="TTerc" 
                 SelectMethod="GetRecords"></asp:ObjectDataSource> 

    <asp:UpdateProgress ID="UpdateProgress1" runat="server" AssociatedUpdatePanelID="UpdatePanel1">
            <ProgressTemplate>
                <div class="Loading">
                    <img alt="" src="../../images/loading.gif" title="" />
                    Espere por Favor...
                </div>
            </ProgressTemplate>
        </asp:UpdateProgress>    
</div>
</asp:Content>

