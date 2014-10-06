<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="Vh_Vehiculo.aspx.vb" Inherits="Vehiculos_DatosBasicos_Vh_Vehiculo" title="Administrador de Vehiculos" %>
<%@ Register Src="../../CtrlUsr/Terceros/Con_Tercero.ascx" TagName="CtrlConTercero" TagPrefix="uc2" %>
<%@ Register Src="~/CtrlUsr/Vehiculo/Ctrl_VhMarca.ascx" TagName="CtrlConVhMarca" TagPrefix="uc4" %>
<%@ Register Src="~/CtrlUsr/Vehiculo/Ctrl_VhLinea.ascx" TagName="CtrlConVhLinea" TagPrefix="uc5" %>
<%@ Register Src="~/CtrlUsr/Vehiculo/Ctrl_VhColor.ascx" TagName="CtrlConVhColor" TagPrefix="uc6" %>
<%@ Register Src="~/CtrlUsr/Vehiculo/Ctrl_VhCarroceria.ascx" TagName="CtrlConVhCarroceria" TagPrefix="uc7" %>
<%@ Register Src="~/CtrlUsr/Vehiculo/Ctrl_VhInstituto.ascx" TagName="CtrlConVhInstituto" TagPrefix="uc8" %>
<%@ Register Src="~/CtrlUsr/Vehiculo/Ctrl_VhAseguradora.ascx" TagName="CtrlConVhAseguradora" TagPrefix="uc9" %>
<asp:Content ID="Content1" ContentPlaceHolderID="SampleContent" Runat="Server">
    <ajaxToolkit:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server" AsyncPostBackTimeout="600" EnableScriptGlobalization="true" >
</ajaxToolkit:ToolkitScriptManager>
<asp:UpdatePanel ID="UpdatePanel1" runat="server">
<ContentTemplate>

<div class="demoarea" >
    <asp:Label ID="MsgResult" runat="server"  Width="90%"></asp:Label>
    <table style="width:900px;">
        <tr class="TbDecl">
            <td colspan="5" >
                <asp:Label ID="lTransaccion" runat="server" Text=""></asp:Label></td>
        </tr>
        <tr>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
            <td align="right">
                Estado del Vehiculo:</td>
            <td>
                <asp:Label ID="lestado" runat="server"></asp:Label>
            </td>
        </tr>
        <tr class="TbDecl">
            <td colspan="5">
                DATOS DEL PROPIETARIO</td>
        </tr>
        <tr>
            <td style="width:160px">
                Nit</td>
            <td style="width:300px">
                Razon Social</td>
            <td style="width:120px">
                Dirección</td>
            <td style="width:120px">
                &nbsp;</td>
            <td style="width:200px">
                Municipio</td>
        </tr>
        <tr>
            <td>
                <asp:TextBox ID="tbNit" runat="server" Width="90px" Enabled="False"></asp:TextBox>
                <asp:TextBox ID="tbDv" runat="server" Width="20px" Enabled="False"></asp:TextBox>
                <asp:LinkButton ID="btBuscaTer" runat="server" ToolTip="Buscar Propietario" 
                    Enabled="False" CausesValidation="False">...</asp:LinkButton>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server" 
                    ErrorMessage="*" ControlToValidate="tbNit"></asp:RequiredFieldValidator>
            </td>
            <td>
                <asp:TextBox ID="tbRazonSocial" runat="server" Width="300px" ReadOnly="True" 
                    Enabled="False"></asp:TextBox>
            </td>
            <td colspan="2">
                <asp:TextBox ID="tbDireccion" runat="server" Width="240" ReadOnly="True" 
                    Enabled="False"></asp:TextBox>
            </td>
            <td>
                <asp:TextBox ID="tbMunicipio" runat="server" Enabled="False" Width="100%"></asp:TextBox>
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
            <td>
                &nbsp;</td>
        </tr>
        <tr class="TbDecl">
            <td colspan="5">
                DATOS DEL VEHICULO</td>
        </tr>
        </table>
    <table style="width:900px;">
        <tr>
            <td style="width:150px">
                Placa</td>
            <td style="width:150px;">
                Clase</td>
            <td style="width:150px">
                Marca</td>
            <td style="width:150px">
                &nbsp;</td>
            <td style="width:150px">
                Linea</td>
            <td style="width:150px">
                &nbsp;</td>
        </tr>
        <tr>
            <td>
                <asp:TextBox ID="tbPlaca" runat="server" Width="120px" AutoPostBack="True" 
                    Enabled="False"></asp:TextBox>
                <asp:LinkButton ID="btBuscaPlaca" runat="server" Enabled="False" 
                    CausesValidation="False">...</asp:LinkButton>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
                    ErrorMessage="*" ControlToValidate="tbPlaca"></asp:RequiredFieldValidator>
            </td>
            <td>
                <asp:DropDownList ID="cmbClase" runat="server" Width="140px" 
                    DataSourceID="odsClase" DataTextField="VCL_CLASE" 
                    DataValueField="VCL_CLASE" Enabled="False">
                </asp:DropDownList>
            </td>
            <td colspan="2">
                <asp:TextBox ID="tbMarca" runat="server" Width="270px" Enabled="False"></asp:TextBox>
                <asp:LinkButton ID="btBuscaMarca" runat="server" Enabled="False" 
                    CausesValidation="False">...</asp:LinkButton>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" 
                    ErrorMessage="*" ControlToValidate="tbMarca"></asp:RequiredFieldValidator>
            </td>
            <td colspan="2">
                <asp:TextBox ID="tbLinea" runat="server" Width="270px" Enabled="False"></asp:TextBox>
                <asp:LinkButton ID="btBuscaLinea" runat="server" Enabled="False" 
                    CausesValidation="False">...</asp:LinkButton>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" 
                    ErrorMessage="*" ControlToValidate="tbLinea"></asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td>
                Modelo</td>
            <td>
               Cilindraje</td>
            <td>
                Pasajeros</td>
            <td>
                Tonelaje</td>
            <td>
                Carroceria</td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td>
                <asp:TextBox ID="tbModelo" runat="server" Width="140px" Enabled="False"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" 
                    ErrorMessage="*" ControlToValidate="tbModelo"></asp:RequiredFieldValidator>
            </td>
            <td>
                <asp:TextBox ID="tbCilindraje" runat="server" Width="140px"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" 
                    ErrorMessage="*" ControlToValidate="tbCilindraje"></asp:RequiredFieldValidator>
            </td>
            <td>
                <asp:TextBox ID="tbPasajeros" runat="server" Width="140px" Enabled="False"></asp:TextBox>
            </td>
            <td>
                <asp:TextBox ID="tbTonelaje" runat="server" Width="140px" Enabled="False"></asp:TextBox>
            </td>
            <td colspan="2">
                <asp:TextBox ID="tbCarroceria" runat="server" Width="270px" Enabled="False"></asp:TextBox>
                <asp:LinkButton ID="btBuscaCarroceria" runat="server" Enabled="False">...</asp:LinkButton>
            </td>
        </tr>
        <tr>
            <td>
                Color</td>
            <td>
                &nbsp;</td>
            <td>
                Motor No.</td>
            <td>
                Chasis</td>
            <td>
                Blindado</td>
            <td>
                Clasico</td>
        </tr>
        <tr>
            <td colspan="2">
                <asp:TextBox ID="tbColor" runat="server" Width="270px" Enabled="False"></asp:TextBox>
                <asp:LinkButton ID="btBuscaColor" runat="server" Enabled="False" 
                    CausesValidation="False">...</asp:LinkButton>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" 
                    ErrorMessage="*" ControlToValidate="tbColor"></asp:RequiredFieldValidator>
            </td>
            <td>
                <asp:TextBox ID="tbMotor" runat="server" Width="140px" Enabled="False"></asp:TextBox>
            </td>
            <td>
                <asp:TextBox ID="tbChasis" runat="server" Width="140px" Enabled="False"></asp:TextBox>
            </td>
            <td>
                <asp:DropDownList ID="cmbBlindado" runat="server" Width="140px" Enabled="False">
                    <asp:ListItem>NO</asp:ListItem>
                    <asp:ListItem>SI</asp:ListItem>
                </asp:DropDownList>
            </td>
            <td>
                <asp:DropDownList ID="cmbClasico" runat="server" Width="140px" Enabled="False">
                    <asp:ListItem>NO</asp:ListItem>
                    <asp:ListItem>SI</asp:ListItem>
                </asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td>
                Fecha de Compra</td>
            <td>
                Valor Factura</td>
            <td>
                Importado</td>
            <td>
                Uso</td>
            <td>
                Categoria</td>
            <td>
                Fecha Expiracion T.P.</td>
        </tr>
        <tr>
            <td>
                <asp:TextBox ID="tbFechaCompra" runat="server" Width="140px" Enabled="False"></asp:TextBox>
            </td>
            <td>
                <asp:TextBox ID="tbValorCompra" runat="server" Width="140px" Enabled="False"></asp:TextBox>
            </td>
            <td>
                <asp:DropDownList ID="cmbImportado" runat="server" Width="140px" 
                    Enabled="False">
                    <asp:ListItem>NO</asp:ListItem>
                    <asp:ListItem>SI</asp:ListItem>
                </asp:DropDownList>
            </td>
            <td>
                <asp:DropDownList ID="cmbUso" runat="server" Width="140px" 
                    DataSourceID="odsUso" DataTextField="VUSO_USO" DataValueField="VUSO_USO" 
                    Enabled="False">
                </asp:DropDownList>
            </td>
            <td>
                <asp:DropDownList ID="cmbCategoria" runat="server"  Width="140px" 
                    DataSourceID="odsCategoria" DataTextField="VCAT_CATEGORIA" 
                    DataValueField="VCAT_CATEGORIA" Enabled="False">
                </asp:DropDownList>
            </td>
            <td>
                <asp:TextBox ID="tbFecExpTP" runat="server" Width="140px" Enabled="False"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>
                Fecha de Matricula</td>
            <td>
                Tipo de Matricula</td>
            <td>
                Departamento</td>
            <td>
                Municipio</td>
            <td>
                Departamento Operación</td>
            <td>
                Municipio de Operación</td>
        </tr>
        <tr>
            <td>
                <asp:TextBox ID="tbFechaMatricula" runat="server" Width="140px" Enabled="False"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" 
                    ErrorMessage="*" ControlToValidate="tbFechaMatricula"></asp:RequiredFieldValidator>
            </td>
            <td>
                <asp:DropDownList ID="cmbTipoMat" runat="server" Width="140px" 
                    DataSourceID="odsTipoMatricula" DataTextField="VTM_MATRICULA" 
                    DataValueField="VTM_CODIGO" Enabled="False">
                </asp:DropDownList>
            </td>
            <td>
                <asp:DropDownList ID="cmbDptoMat" runat="server" Width="140px" 
                    DataSourceID="odsDpto" DataTextField="NOM_DEPTO" 
                    DataValueField="COD_DEPTO" AutoPostBack="True" Enabled="False">
                </asp:DropDownList>
            </td>
            <td>
                <asp:DropDownList ID="cmbMunMat" runat="server" Width="140px" 
                    DataSourceID="odsMunicipioMat" DataTextField="MUN_NOM" 
                    DataValueField="MUN_COD" Enabled="False">
                </asp:DropDownList>
            </td>
            <td>
                <asp:DropDownList ID="cmbDptoOper" runat="server" Width="140px" 
                    DataSourceID="odsDpto" DataTextField="NOM_DEPTO" 
                    DataValueField="COD_DEPTO" AutoPostBack="True" Enabled="False">
                </asp:DropDownList>
            </td>
            <td>
                <asp:DropDownList ID="cmbMunOper" runat="server" Width="140px" 
                    DataSourceID="odsMunicipioOper" DataTextField="MUN_NOM" 
                    DataValueField="MUN_COD" Enabled="False">
                </asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td>
                Instituto de Transito</td>
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
            <td colspan="2">
                <asp:TextBox ID="tbInstituto" runat="server" Enabled="False" Width="270px"></asp:TextBox>
                <asp:LinkButton ID="btBuscarInstituto" runat="server" Enabled="False" 
                    CausesValidation="False">...</asp:LinkButton>
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
        <tr class="TbDecl">
            <td colspan="6">
                INFORMACION DE LA ASEGURADORA</td>
        </tr>
    </table>

    <ajaxToolkit:AlwaysVisibleControlExtender ID="avBotones" runat="server" 
        ScrollEffectDuration=".1" HorizontalSide="Center" HorizontalOffset="10" VerticalOffset="1" 
        TargetControlID="pBotones" VerticalSide="Bottom">
    </ajaxToolkit:AlwaysVisibleControlExtender> 
    <ajaxToolkit:CalendarExtender
       ID="cFecCompra" runat="server" TargetControlID="tbFechaCompra" 
       Format="dd/MM/yyyy" >
    </ajaxToolkit:CalendarExtender>
    <ajaxToolkit:CalendarExtender
       ID="cFecMatricula" runat="server" TargetControlID="tbFechaMatricula" 
       Format="dd/MM/yyyy" >
    </ajaxToolkit:CalendarExtender>    
    <ajaxToolkit:CalendarExtender
       ID="cFecExpira" runat="server" TargetControlID="tbFecExpTP" 
       Format="dd/MM/yyyy" >
    </ajaxToolkit:CalendarExtender>    
        
    <table style="width: 600px;">
        <tr>
            <td>
                Aseguradora</td>
            <td>
                Poliza No.</td>
            <td>
               Fecha de Vencimiento</td>
        </tr>
        <tr>
            <td>
                <asp:TextBox ID="tbNomAseguradora" runat="server" Width="250px" Enabled="False"></asp:TextBox>
                <asp:LinkButton ID="btBuscaAseguradora" runat="server" Enabled="False">...</asp:LinkButton>
            </td>
            <td>
                <asp:TextBox ID="tbNumPoliza" runat="server" Width="150px" Enabled="False"></asp:TextBox>
            </td>
            <td>
                <asp:TextBox ID="tbFecVenc" runat="server"  Width="150px" Enabled="False"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>
                &nbsp;
            </td>
            <td>
                &nbsp;
            </td>
            <td>
                &nbsp;

            </td>
        </tr>
    </table>
    <ajaxToolkit:CalendarExtender
       ID="cFecVen" runat="server" TargetControlID="tbFecVenc" 
       Format="dd/MM/yyyy" >
    </ajaxToolkit:CalendarExtender> 
    <asp:GridView ID="gvConsulta" runat="server" DataSourceID="odsVehAseg" 
        AllowPaging="True" AutoGenerateColumns="False">
        <Columns>
            <asp:BoundField DataField="NOM_ASEG" HeaderText="Aseguradora">
                <HeaderStyle HorizontalAlign="Left" />
                <ItemStyle Width="350px" />
            </asp:BoundField>
            <asp:BoundField DataField="NRO_POLIZA" HeaderText="No. Poliza">
                <HeaderStyle HorizontalAlign="Left" />
                <ItemStyle Width="100px" />
            </asp:BoundField>
            <asp:BoundField DataField="VENCIMIENTO" DataFormatString="{0:d}" 
                HeaderText="Vencimiento">
                <HeaderStyle HorizontalAlign="Left" />
                <ItemStyle Width="100px" />
            </asp:BoundField>
        </Columns>
    </asp:GridView>
    <div style="width: 317px; height: 210px">
    <asp:Panel ID= "pBotones" runat="server" BackColor="White" 
        BorderColor="#336699" BorderStyle="Solid" BorderWidth="1px">
        <table style="width: 500px;">
        <tr>
            <td>
                &nbsp;
                <asp:ImageButton ID="btMatricular" runat="server" CausesValidation="False" 
                    ImageUrl="~/images/Operaciones/Matricular.png" />
            </td>
            <td>
                &nbsp;
                <asp:ImageButton ID="btTraslado" runat="server" CausesValidation="False" 
                    ImageUrl="~/images/Operaciones/Traslado.png" />
            </td>
            <td>
                &nbsp;
                <asp:ImageButton ID="btModificar" runat="server" CausesValidation="False" 
                    ImageUrl="~/images/Operaciones/modificacion.png" />
            </td>
            <td>
                <asp:ImageButton ID="btGuardar" runat="server" Enabled="False" 
                    ImageUrl="~/images/Operaciones/save.png" />
            </td>
            <td>
                <asp:ImageButton ID="btCancelar" runat="server" CausesValidation="False" 
                    Enabled="False" ImageUrl="~/images/Operaciones/Deshacer.png" />
            </td>
        </tr>
            <tr>
                <td>
                    &nbsp; Matricular</td>
                <td>
                    &nbsp; Traslado</td>
                <td>
                    &nbsp; Modificacion</td>
                <td>
                    Guardar</td>
                <td>
                    Cancelar</td>
            </tr>
    </table>
    </asp:Panel>
    </div>
    <asp:ObjectDataSource ID="odsVehAseg" runat="server" 
        OldValuesParameterFormatString="original_{0}" SelectMethod="GetPorPlaca" 
        TypeName="Vh_Aseg_Parque">
        <SelectParameters>
            <asp:ControlParameter ControlID="tbPlaca" Name="PLACA" PropertyName="Text" 
                Type="String" />
        </SelectParameters>
    </asp:ObjectDataSource>
    <asp:HiddenField ID="hfCodInstTran" runat="server" />
    <asp:ObjectDataSource ID="odsDpto" runat="server" 
        OldValuesParameterFormatString="original_{0}" SelectMethod="GetRecords" 
        TypeName="Departamentos">
    </asp:ObjectDataSource>
    <asp:ObjectDataSource ID="odsMunicipioMat" runat="server" 
        OldValuesParameterFormatString="original_{0}" SelectMethod="GetPorDpto" 
        TypeName="Municipios">
        <SelectParameters>
            <asp:ControlParameter ControlID="cmbDptoMat" Name="DpCo" 
                PropertyName="SelectedValue" Type="String" />
        </SelectParameters>
    </asp:ObjectDataSource>
    <asp:ObjectDataSource ID="odsMunicipioOper" runat="server" 
        OldValuesParameterFormatString="original_{0}" SelectMethod="GetPorDpto" 
        TypeName="Municipios">
        <SelectParameters>
            <asp:ControlParameter ControlID="cmbDptoOper" Name="DpCo" 
                PropertyName="SelectedValue" Type="String" />
        </SelectParameters>
    </asp:ObjectDataSource>
    <asp:ObjectDataSource ID="odsClase" runat="server" 
        OldValuesParameterFormatString="original_{0}" SelectMethod="GetRecords" 
        TypeName="Vh_Clase">
    </asp:ObjectDataSource>
    <asp:ObjectDataSource ID="odsCategoria" runat="server" 
        OldValuesParameterFormatString="original_{0}" SelectMethod="GetRecords" 
        TypeName="Vh_Categoria">
    </asp:ObjectDataSource>
    <asp:ObjectDataSource ID="odsUso" runat="server" 
        OldValuesParameterFormatString="original_{0}" SelectMethod="GetRecords" 
        TypeName="Vh_Uso">
    </asp:ObjectDataSource>
    <asp:ObjectDataSource ID="odsTipoMatricula" runat="server"
     OldValuesParameterFormatString="original_{0}" SelectMethod="GetRecords" 
        TypeName="Vh_TipoMatricula">
    </asp:ObjectDataSource>
    <asp:HiddenField ID="hfIdMarca" runat="server" />
    <asp:HiddenField ID="hfTransaccion" runat="server" />
    <asp:HiddenField ID="hfCodAseg" runat="server" />
    <asp:HiddenField ID="hfEstadoVeh" runat="server" />
</div>    
</ContentTemplate></asp:UpdatePanel>
 
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

<asp:UpdatePanel ID="upModalVhMarca" runat="server" UpdateMode="Conditional" >
    <ContentTemplate>
        <ajaxToolkit:ModalPopupExtender id="ModalPopupConVhMarca" runat="server" 
            TargetControlID="btn_Target_vhMarca" 
            CancelControlID="btCerrarConVhMarca"
            PopupControlID="pConsVhMarca"
            PopupDragHandleControlID="pConsVhMarca2"
            DropShadow ="true"
            BackgroundCssClass="modalBackground">
        </ajaxToolkit:ModalPopupExtender> 
        <asp:Panel id="pConsVhMarca" runat="server" Width="650px" Height="229%" CssClass="ModalPanel2">
            <asp:Panel id="pConsVhMarca2" runat="Server" Height="30px" CssClass="BarTitleModal2">
                <div style="padding-right: 5px; padding-left: 5px; padding-bottom: 5px; vertical-align: middle;
                         padding-top: 5px">
                    <div style="FLOAT: left">Consulta de Marcas</DIV>
                    <div style="float: right">
                        <asp:Button ID="btCerrarConVhMarca" runat="server" Text="X" /> 
                    </div> 
                </div>
            </asp:Panel>
             <uc4:CtrlConVhMarca id="CtrlConVhMarca1" runat="server">
            </uc4:CtrlConVhMarca><br /><br /><br />
            <asp:Button style="display:none" id="btn_Target_vhMarca" runat ="server"></asp:Button>
        </asp:Panel> 
    </ContentTemplate>
</asp:UpdatePanel>

<asp:UpdatePanel ID="upModalVhLinea" runat="server" UpdateMode="Conditional" >
    <ContentTemplate>
        <ajaxToolkit:ModalPopupExtender id="ModalPopupConVhLinea" runat="server" 
            TargetControlID="btn_Target_vhLinea" 
            CancelControlID="btCerrarConVhLinea"
            PopupControlID="pConsVhLinea"
            PopupDragHandleControlID="pConsVhLinea2"
            DropShadow ="true"
            BackgroundCssClass="modalBackground">
        </ajaxToolkit:ModalPopupExtender> 
        <asp:Panel id="pConsVhLinea" runat="server" Width="650px" Height="229%" CssClass="ModalPanel2">
            <asp:Panel id="pConsVhLinea2" runat="Server" Height="30px" CssClass="BarTitleModal2">
                <div style="padding-right: 5px; padding-left: 5px; padding-bottom: 5px; vertical-align: middle;
                         padding-top: 5px">
                    <div style="FLOAT: left">Consulta de Lineas</DIV>
                    <div style="float: right">
                        <asp:Button ID="btCerrarConVhLinea" runat="server" Text="X" /> 
                    </div> 
                </div>
            </asp:Panel>
            <uc5:CtrlConVhLinea id="CtrlConVhLinea1" runat="server">
            </uc5:CtrlConVhLinea><br /><br /><br />
            <asp:Button style="display:none" id="btn_Target_vhLinea" runat ="server"></asp:Button>
        </asp:Panel> 
    </ContentTemplate>
</asp:UpdatePanel>

<asp:UpdatePanel ID="upModalVhColor" runat="server" UpdateMode="Conditional" >
    <ContentTemplate>
        <ajaxToolkit:ModalPopupExtender id="ModalPopupVhColor" runat="server" 
            TargetControlID="btn_Target_vhColor" 
            CancelControlID="btCerrarConVhColor"
            PopupControlID="pConsVhColor"
            PopupDragHandleControlID="pConsVhColor2"
            DropShadow ="true"
            BackgroundCssClass="modalBackground">
        </ajaxToolkit:ModalPopupExtender> 
        <asp:Panel id="pConsVhColor" runat="server" Width="650px" Height="229%" CssClass="ModalPanel2">
            <asp:Panel id="pConsVhColor2" runat="Server" Height="30px" CssClass="BarTitleModal2">
                <div style="padding-right: 5px; padding-left: 5px; padding-bottom: 5px; vertical-align: middle;
                         padding-top: 5px">
                    <div style="FLOAT: left">Consulta de Color</DIV>
                    <div style="float: right">
                        <asp:Button ID="btCerrarConVhColor" runat="server" Text="X" /> 
                    </div> 
                </div>
            </asp:Panel>
            <uc6:CtrlConVhColor id="CtrlConVhColor1" runat="server">
            </uc6:CtrlConVhColor><br /><br /><br />
            <asp:Button style="display:none" id="btn_Target_vhColor" runat ="server"></asp:Button>
        </asp:Panel> 
    </ContentTemplate>
</asp:UpdatePanel>

<asp:UpdatePanel ID="upModalVhCarroceria" runat="server" UpdateMode="Conditional" >
    <ContentTemplate>
        <ajaxToolkit:ModalPopupExtender id="ModalPopupVhCarroceria" runat="server" 
            TargetControlID="btn_Target_VhCarroceria" 
            CancelControlID="btCerrarConVhCarroceria"
            PopupControlID="pConsVhCarroceria"
            PopupDragHandleControlID="pConsVhCarroceria2"
            DropShadow ="true"
            BackgroundCssClass="modalBackground">
        </ajaxToolkit:ModalPopupExtender> 
        <asp:Panel id="pConsVhCarroceria" runat="server" Width="650px" Height="229%" CssClass="ModalPanel2">
            <asp:Panel id="pConsVhCarroceria2" runat="Server" Height="30px" CssClass="BarTitleModal2">
                <div style="padding-right: 5px; padding-left: 5px; padding-bottom: 5px; vertical-align: middle;
                         padding-top: 5px">
                    <div style="FLOAT: left">Consulta de Carroceria</DIV>
                    <div style="float: right">
                        <asp:Button ID="btCerrarConVhCarroceria" runat="server" Text="X" /> 
                    </div> 
                </div>
            </asp:Panel>
            <uc7:CtrlConVhCarroceria id="CtrlConVhCarroceria1" runat="server">
            </uc7:CtrlConVhCarroceria><br /><br /><br />
            <asp:Button style="display:none" id="btn_Target_VhCarroceria" runat ="server"></asp:Button>
        </asp:Panel> 
    </ContentTemplate>
</asp:UpdatePanel>

<asp:UpdatePanel ID="upModalVhInstituto" runat="server" UpdateMode="Conditional" >
    <ContentTemplate>
        <ajaxToolkit:ModalPopupExtender id="modalPopupConVhInstituto" runat="server" 
            TargetControlID="btn_Target_VhInstituto" 
            CancelControlID="btCerrarConVhInstituto"
            PopupControlID="pConsVhInstituto"
            PopupDragHandleControlID="pConsVhInstituto2"
            DropShadow ="true"
            BackgroundCssClass="modalBackground">
        </ajaxToolkit:ModalPopupExtender> 
        <asp:Panel id="pConsVhInstituto" runat="server" Width="650px" Height="229%" CssClass="ModalPanel2">
            <asp:Panel id="pConsVhInstituto2" runat="Server" Height="30px" CssClass="BarTitleModal2">
                <div style="padding-right: 5px; padding-left: 5px; padding-bottom: 5px; vertical-align: middle;
                         padding-top: 5px">
                    <div style="FLOAT: left">Consulta de Institutos de Transito</DIV>
                    <div style="float: right">
                        <asp:Button ID="btCerrarConVhInstituto" runat="server" Text="X" /> 
                    </div> 
                </div>
            </asp:Panel>
            <uc8:CtrlConVhInstituto id="CtrlConVhInstituto1" runat="server">
            </uc8:CtrlConVhInstituto><br /><br /><br />
            <asp:Button style="display:none" id="btn_Target_VhInstituto" runat ="server"></asp:Button>
        </asp:Panel> 
    </ContentTemplate>
</asp:UpdatePanel>

<asp:UpdatePanel ID="upModalVhAseguradora" runat="server" UpdateMode="Conditional" >
    <ContentTemplate>
        <ajaxToolkit:ModalPopupExtender id="ModalPopupConVhAseguradora" runat="server" 
            TargetControlID="btn_Target_VhAseguradora" 
            CancelControlID="btCerrarConVhAseguradora"
            PopupControlID="pConsVhAseguradora"
            PopupDragHandleControlID="pConsVhAseguradora2"
            DropShadow ="true"
            BackgroundCssClass="modalBackground">
        </ajaxToolkit:ModalPopupExtender> 
        <asp:Panel id="pConsVhAseguradora" runat="server" Width="650px" Height="229%" CssClass="ModalPanel2">
            <asp:Panel id="pConsVhAseguradora2" runat="Server" Height="30px" CssClass="BarTitleModal2">
                <div style="padding-right: 5px; padding-left: 5px; padding-bottom: 5px; vertical-align: middle;
                         padding-top: 5px">
                    <div style="FLOAT: left">Consulta de Aseguradoras</DIV>
                    <div style="float: right">
                        <asp:Button ID="btCerrarConVhAseguradora" runat="server" Text="X" /> 
                    </div> 
                </div>
            </asp:Panel>
            <uc9:CtrlConVhAseguradora id="CtrlConVhAseguradora1" runat="server">
            </uc9:CtrlConVhAseguradora><br /><br /><br />
            <asp:Button style="display:none" id="btn_Target_VhAseguradora" runat ="server"></asp:Button>
        </asp:Panel> 
    </ContentTemplate>
</asp:UpdatePanel>


<asp:UpdateProgress ID="UpdateProgress1" runat="server" AssociatedUpdatePanelID="UpdatePanel1">
<ProgressTemplate>
<div class="Loading">
   <img alt="" src="../../images/loading.gif" title="" />
     Espere por Favor...
</div>
</ProgressTemplate>
</asp:UpdateProgress>    
</asp:Content>

