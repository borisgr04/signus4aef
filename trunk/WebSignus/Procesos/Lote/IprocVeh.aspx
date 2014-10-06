<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="IprocVeh.aspx.vb" Inherits="Procesos_Lote_IprocVeh" title="Iniciar Proceso - Vehiculo " %>
<%@ Register Src="../../CtrlUsr/Terceros/Con_Tercero.ascx" TagName="CtrlConTercero" TagPrefix="uc2" %>
<asp:Content ID="Content1" ContentPlaceHolderID="SampleContent" Runat="Server">
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
                <asp:Label id="Label10" runat="server" Font-Bold="True" Text="INICIAR NUEVO PROCESO" ></asp:Label> 
                    &nbsp;- VEHICULOS</td> 
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
                     <asp:DropDownList ID="cmbImpuesto" runat="server" 
                         DataSourceID="odsImpuesto" DataTextField="CLD_NOM" DataValueField="CLD_COD" 
                         style="width:100%" Enabled="False">
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
                         style="width:100%">
                     </asp:DropDownList>
                 </td>
                 <td>
                     Vigencia Final</td>
                 <td colspan="2">
                     <asp:DropDownList ID="cmbVigencia1" runat="server" DataSourceID="odsVigencias" 
                         DataTextField="CAL_VIG" DataValueField="CAL_VIG" style="width:100%">
                     </asp:DropDownList>
                 </td>
                 <td>
                     <asp:Label ID="ltramite" runat="server" Visible="False"></asp:Label>
                 </td>
             </tr>
             <tr>
                 <td>
                     <asp:CheckBox ID="chMunicipoOp" Text="Municipio de Operacion" runat="server" />
                 </td>
                 <td colspan="2">
                     <asp:DropDownList ID="cmbMunOper" runat="server" DataSourceID="odsMunicipios" 
                         DataTextField="MUN_NOM" DataValueField="MUN_COD" 
                         style="width:100%">
                     </asp:DropDownList>
                 </td>
                 <td>
                     &nbsp;</td>
                 <td>
                     &nbsp;</td>
                 <td>
                     &nbsp;</td>
             </tr>
             <tr>
                 <td>
                     <asp:CheckBox ID="chMunicipioMat" runat="server" Text="Matriculados en" />
                 </td>
                 <td colspan="2">
                     <asp:DropDownList ID="cmbMunMat" runat="server" DataSourceID="odsMunicipios" 
                         DataTextField="MUN_NOM" DataValueField="MUN_COD" Width="100%">
                     </asp:DropDownList>
                 </td>
                 <td>
                     &nbsp;</td>
                 <td>
                     &nbsp;</td>
                 <td>
                     &nbsp;</td>
             </tr>
             <tr>
                <td>
                    <asp:CheckBox ID="chTercero" runat="server" Text="Contribuyente" />
                </td>
                 <td >
                     <asp:TextBox ID="tbNit" runat="server" Enabled="False" Width="135px" ></asp:TextBox>
                     
                 </td>
                 <td colspan="4">
                 <asp:TextBox ID="tbDv" runat="server" Enabled="False" Width="17px">
                     </asp:TextBox>
                     <asp:TextBox ID="tbNomTercero" runat="server" Enabled="False" Width="220px">
                     </asp:TextBox>
                     <asp:LinkButton ID="btBuscaTer" runat="server" CausesValidation="False" 
                         ToolTip="Buscar Contribuyente">&nbsp;...&nbsp;</asp:LinkButton>
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
                 <td>
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
                     <asp:BoundField DataField="TER_NOM" HeaderText="Contribuyente">
                         <HeaderStyle HorizontalAlign="Left" />
                         <ItemStyle Width="300px" />
                     </asp:BoundField>
                     <asp:BoundField HeaderText="Placa" DataField="PLACA">
                         <HeaderStyle HorizontalAlign="Left" />
                         <ItemStyle Width="80px" />
                     </asp:BoundField>
                     <asp:BoundField HeaderText="Vigencia" DataField="CAL_VIG">
                         <HeaderStyle HorizontalAlign="Left" />
                         <ItemStyle Width="80px" />
                     </asp:BoundField>
                     <asp:BoundField HeaderText="Clase Vehiculo" DataField="CLASE">
                         <HeaderStyle HorizontalAlign="Left" />
                         <ItemStyle Width="130px" />
                     </asp:BoundField>
                     <asp:BoundField HeaderText="Marca" DataField="MARCA">
                         <HeaderStyle HorizontalAlign="Left" />
                         <ItemStyle Width="170px" />
                     </asp:BoundField>
                     <asp:BoundField HeaderText="Linea" DataField="LINEA">
                         <HeaderStyle HorizontalAlign="Left" />
                         <ItemStyle Width="170px" />
                     </asp:BoundField>
                     <asp:BoundField HeaderText="Modelo" DataField="MODELO">
                         <HeaderStyle HorizontalAlign="Left" />
                         <ItemStyle Width="80px" />
                     </asp:BoundField>
                 </Columns>
             </asp:GridView>   
         </div>
        </asp:Panel>
     </contenttemplate>
     </asp:UpdatePanel>
         <asp:UpdatePanel ID="upModalTercero" runat="server" UpdateMode="Conditional" >
    <ContentTemplate>
        <ajaxToolkit:ModalPopupExtender id="ModalPopupConTercero" runat="server" 
            TargetControlID="btn_Target" 
            CancelControlID="btCerrarConTercero"
            PopupControlID="pConsTer"
            PopupDragHandleControlID="pConsTer2"
            DropShadow ="true"
            BackgroundCssClass="modalBackground">
        </ajaxToolkit:ModalPopupExtender> 
        <asp:Panel id="pConsTer" runat="server" Width="650px" Height="229%" CssClass="ModalPanel2">
            <asp:Panel id="pConsTer2" runat="Server" Height="30px" CssClass="BarTitleModal2">
                <div style="padding-right: 5px; padding-left: 5px; padding-bottom: 5px; vertical-align: middle;
                         padding-top: 5px">
                    <div style="FLOAT: left">Consulta de Terceros</DIV>
                    <div style="float: right">
                        <asp:Button ID="btCerrarConTercero" runat="server" Text="X" /> 
                    </div> 
                </div>
            </asp:Panel>
             <uc2:CtrlConTercero id="CtrlConTercero2" runat="server">
            </uc2:CtrlConTercero><br /><br /><br />
            <asp:Button style="display:none" id="btn_Target" runat ="server"></asp:Button>
        </asp:Panel> 
    </ContentTemplate>
    </asp:UpdatePanel>
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

