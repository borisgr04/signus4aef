<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="NExpe.aspx.vb" Inherits="Procesos_Exp_NExpe" title="Nuevo Expediente" %>
<%@ Register Src="../../CtrlUsr/Terceros/Con_Tercero.ascx" TagName="CtrlConTercero" TagPrefix="uc2" %>
<asp:Content ID="Content1" ContentPlaceHolderID="SampleContent" Runat="Server">
    <ajaxToolkit:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server" AsyncPostBackTimeout="600">
    </ajaxToolkit:ToolkitScriptManager>
    <div class="demoarea">
    <asp:UpdatePanel id="UpdatePanel1" runat="server">
    <contenttemplate>
    <asp:Label ID="MsgResult" runat="server" Height="100%" Width="90%"></asp:Label>
    <table style="width:620px;">
        <tr>
            <td colspan="4">
                
                &nbsp;</td>
        </tr>
        <tr>
            <td colspan="4">
                &nbsp;</td>
        </tr>
        <tr>
            <td colspan="4">
                <asp:Label ID="lbTituExpe" runat="server" Text="Expediente: " Visible="false"></asp:Label>
                <asp:LinkButton ID="lbtTramite" runat="server" Visible="false"></asp:LinkButton>
            </td>
        </tr>
        <tr class="TbDecl">
            <td colspan="3">
                <asp:Label ID="Label10" runat="server" Font-Bold="True" 
                    Text="CREAR EXPEDIENTES"></asp:Label>
            </td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td style="width:100px">
                <asp:Label ID="Label52" runat="server" Text="No. Expediente"></asp:Label>
            </td>
            <td style="width:100px">
                <asp:TextBox ID="tbNumExp" runat="server" style="width:100px" Enabled="False"></asp:TextBox>
            </td>
            <td style="width:100px">
                &nbsp;</td>
            <td style="width:220px">
                &nbsp;</td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="Label54" runat="server" Text="Proceso"></asp:Label>
            </td>
            <td colspan="2">
                     <asp:DropDownList ID="cmbProceso" runat="server" style="width:100%" 
                         DataSourceID="odsProcesos" DataTextField="PROC_NOMB" 
                         DataValueField="PROC_CODI" 
                      >
                     </asp:DropDownList>
                 </td>
            <td>
                <asp:Label ID="lcodTramite" runat="server" CssClass="TitDecl" Visible="False"></asp:Label>
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="Label11" runat="server" Text="Razon Social"></asp:Label>
            </td>
            <td>
                <asp:TextBox ID="Nit" runat="server" Enabled="False" Width="100px" 
                    AutoPostBack="True" ></asp:TextBox>
            </td>
            <td colspan="2" align="left">
                <asp:TextBox ID="Dv" runat="server" Enabled="False" Width="17px"></asp:TextBox>
                <asp:Button ID="BtnBuscDP" runat="server" accessKey="B" Text="..." ToolTip="Buscar Agente Recaudador" 
                     UseSubmitBehavior="False" Width="17px" CausesValidation="False" />
                <asp:TextBox ID="Agente" runat="server" Width="280px" 
                    Enabled="False"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" 
                    ControlToValidate="Nit" ErrorMessage="*"></asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="Label53" runat="server" Text="Impuesto"></asp:Label>
            </td>
            <td colspan="2">
                <asp:DropDownList ID="cmbImpuesto" runat="server" 
                    DataSourceID="odsImpuesto" DataTextField="CLD_NOM" DataValueField="CLD_COD" 
                    style="width:100%" AutoPostBack="True">
                </asp:DropDownList>
            </td>
            <td>
                <asp:Button ID="Button1" runat="server" Text="..." CausesValidation="False" />
            </td>
        </tr>
        
        <tr>
            <td>
                Vigencia Inicial</td>
            <td>
                     <asp:DropDownList ID="cmbVigencia" runat="server" 
                         DataSourceID="odsVigencias" DataTextField="CAL_VIG" DataValueField="CAL_VIG" 
                         style="width:100px">
                     </asp:DropDownList>
                 </td>
            <td>
                Vigencia Final</td>
            <td>
                     <asp:DropDownList ID="cmbVigencia1" runat="server" 
                         DataSourceID="odsVigencias" DataTextField="CAL_VIG" DataValueField="CAL_VIG" 
                         style="width:100px">
                     </asp:DropDownList>
                 </td>
        </tr>
        <tr>
            <td>
                Inicio Actividad</td>
            <td>
                <asp:TextBox ID="tbIniAct" runat="server"  Width="100px" Enabled="False"></asp:TextBox>
            </td>
            <td>
                Auto de Apertura No.</td>
            <td>
                <asp:TextBox ID="tbConsecutivo" runat="server" Width="80px"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
                    ControlToValidate="tbConsecutivo" ErrorMessage="*"></asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
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
                &nbsp;</td>
            <td>
                <asp:ImageButton ID="btActualizar" runat="server" 
                    ImageUrl="~/images/Operaciones/search2.png" CausesValidation="False" />
            </td>
            <td>
                <asp:ImageButton ID="btGuardar" runat="server" 
                    ImageUrl="~/images/Operaciones/save.png" />
            </td>
            <td>
                <asp:ImageButton ID="btExpedientes" runat="server" 
                         ImageUrl="~/images/imagev2/blog-post-accept-icon.png" 
                         CausesValidation="False" />
            </td>
        </tr>
        <tr>
            <td>
                &nbsp;</td>
            <td>
                Buscar</td>
            <td>
                Guardar</td>
            <td>
                Expediente</td>
        </tr>
        <tr class="TbDecl">
            <td colspan="4">
                <asp:Label ID="Label1" runat="server" Font-Bold="True" 
                            Text="PERIODOS ADEUDADOS"></asp:Label>
            </td>
        </tr>
        <tr>
            <td colspan="4">
                &nbsp;</td>
        </tr>
    </table>
    <asp:Panel  id="pConsulta" runat="server" Visible="true" ScrollBars="Auto" Width="100%" Height="300px">
        <div style="width:100%">
            <asp:GridView ID="gvPeriodos" runat="server" 
                 AutoGenerateColumns="False" DataKeyNames="CAL_PER,CAL_VIG" 
                PageSize="20">
                 <Columns>
                     <asp:TemplateField>
                         <ItemTemplate>
                             <asp:CheckBox ID="CheckBox1" runat="server" />
                         </ItemTemplate>
                     </asp:TemplateField>
                     <asp:BoundField DataField="CAL_DES" HeaderText="PERIODO" />
                     <asp:BoundField DataField="CAL_VIG" HeaderText="VIGENCIA" />
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
    <asp:ObjectDataSource ID="odsVigencias" runat="server" SelectMethod="GetVigencias" 
            TypeName="Calendario" OldValuesParameterFormatString="original_{0}">
    <SelectParameters>
    <asp:ControlParameter ControlID="cmbImpuesto" Name="Cla_Dec" PropertyName="SelectedValue"
          Type="String" />
        </SelectParameters>
    </asp:ObjectDataSource>
    <asp:ObjectDataSource ID="odsImpuesto" runat="server" SelectMethod="GetCDEC_PorNit" 
            TypeName="CDeclaraciones" OldValuesParameterFormatString="original_{0}">
        <SelectParameters>
            <asp:ControlParameter ControlID="Nit" Name="Nit" PropertyName="Text" 
                Type="String" />
        </SelectParameters>
    </asp:ObjectDataSource>
    <asp:UpdateProgress ID="UpdateProgress1" runat="server" AssociatedUpdatePanelID="UpdatePanel1">
            <ProgressTemplate>
                <div class="Loading">
                    <img alt="" src="../../images/loading.gif" title="" />
                    Cargando …
                </div>
            </ProgressTemplate>
    </asp:UpdateProgress>  
   
</div>
</asp:Content>

