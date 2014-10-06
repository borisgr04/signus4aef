<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="conNotificacion.aspx.vb" Inherits="Consultas_Expedientes_conNotificacion" title="Consulta de Notificaciones" %>
<%@ Register Src="../../CtrlUsr/Terceros/Con_Tercero.ascx" TagName="CtrlConTercero" TagPrefix="uc2" %>
<%@ Register Src="~/CtrlUsr/Tramites/Con_tramite.ascx" TagName="CtrlConsTramite" TagPrefix="uc3" %>

<asp:Content ID="Content1" ContentPlaceHolderID="SampleContent" Runat="Server">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
<div class="demoarea">
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
    <ContentTemplate>
    <table style="width: 700px;">
        <tr>
            <td colspan="3" class="TbDecl">
                CONSULTA &nbsp;DE NOTIFICACIONES</td>
        </tr>
        <tr>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td>
                <asp:CheckBox ID="cbDocumento" runat="server" Text="Tramite" />
            </td>
            <td>
                <asp:CheckBox ID="cbExpediente" runat="server" Text="Expedientes" />
            </td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td>
                
                <asp:TextBox ID="tbTramite" runat="server" Width="300px" Enabled="False"></asp:TextBox>
                <asp:LinkButton ID="lbTramite" runat="server">...</asp:LinkButton>
            </td>
            <td>
                
                <asp:TextBox ID="tbExpeIni" runat="server" Width="150px" AutoPostBack="True"></asp:TextBox>
            </td>
            <td>
                <asp:TextBox ID="tbExpeFin" runat="server" Width="150px"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>
                <asp:CheckBox ID="cbTercero" runat="server" Text="Agente Recaudador" />
            </td>
            <td>
                <asp:CheckBox ID="cbEntregado" runat="server" Text="Entregado" />
            </td>
            <td rowspan="2">
                <asp:ImageButton ID="btBuscar" runat="server" 
                    ImageUrl="~/images/Operaciones/search2.png" />
                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                <asp:ImageButton ID="btExcel" runat="server" Height="34px" 
                    ImageUrl="~/images/imagev2/excel2007.gif" Width="34px" />
            </td>
        </tr>
        <tr>
            <td>
                
                <asp:TextBox ID="tbTercero" runat="server" Width="250px" Enabled="False"></asp:TextBox>
                <asp:LinkButton ID="lbTercero" runat="server">...</asp:LinkButton>
            </td>
            <td>
                <asp:DropDownList ID="cmbfinalizado" runat="server">
                    <asp:ListItem Value="SI">Si</asp:ListItem>
                    <asp:ListItem Value="NO">No</asp:ListItem>
                </asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
            <td>
                Buscar&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Exportar</td>
        </tr>
    </table>
        <asp:GridView ID="gvConsulta" runat="server" AutoGenerateColumns="False">
            <Columns>
                <asp:BoundField DataField="EXTR_NUME" HeaderText="Expediente">
                    <HeaderStyle HorizontalAlign="Left" />
                    <ItemStyle Width="100px" />
                </asp:BoundField>
                <asp:BoundField DataField="TER_NIT" HeaderText="Identificación">
                    <HeaderStyle HorizontalAlign="Left" />
                    <ItemStyle Width="100px" />
                </asp:BoundField>
                <asp:BoundField DataField="TER_NOM" HeaderText="Agente Retenedor">
                    <HeaderStyle HorizontalAlign="Left" />
                    <ItemStyle Width="200px" />
                </asp:BoundField>
                <asp:BoundField DataField="TRAM_NOMB" HeaderText="Documento">
                    <HeaderStyle HorizontalAlign="Left" />
                    <ItemStyle Width="200px" />
                </asp:BoundField>
                <asp:BoundField DataField="FINALIZADO" HeaderText="Finalizado">
                    <HeaderStyle HorizontalAlign="Left" />
                    <ItemStyle Width="100px" />
                </asp:BoundField>
                <asp:BoundField DataField="DESCRIPCION" HeaderText="Medio de Entrega">
                    <HeaderStyle HorizontalAlign="Left" />
                    <ItemStyle Width="200px" />
                </asp:BoundField>
                <asp:BoundField DataField="EXNF_FREB" DataFormatString="{0:d}" 
                    HeaderText="Fecha de Recibido">
                    <HeaderStyle HorizontalAlign="Left" />
                    <ItemStyle Width="100px" />
                </asp:BoundField>
            </Columns>
        </asp:GridView>
        <asp:HiddenField ID="hfTramite" runat="server" />
        <asp:HiddenField ID="hfTercero" runat="server" />
    </ContentTemplate>
        <Triggers>
            <asp:PostBackTrigger ControlID="btExcel" />
        </Triggers>
    </asp:UpdatePanel>
</div>
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
   
    <asp:UpdatePanel ID="upModalContramite" runat="server" UpdateMode="Conditional" >
    <ContentTemplate>
        <ajaxToolkit:ModalPopupExtender id="ModalPopupConTramite" runat="server" 
            TargetControlID="btn_Target_tramite" 
            PopupControlID="pConsTram"
            PopupDragHandleControlID="pConsTram2"
            DropShadow ="true"
            BackgroundCssClass="modalBackground">
        </ajaxToolkit:ModalPopupExtender> 
        <asp:Panel id="pConsTram" runat="server" Width="450px" Height="229%" CssClass="ModalPanel2">
            <asp:Panel id="pConsTram2" runat="Server" Height="30px" CssClass="BarTitleModal2">
                <div style="padding-right: 5px; padding-left: 5px; padding-bottom: 5px; vertical-align: middle;
                         padding-top: 5px">
                    <div style="FLOAT: left">Consulta de Tramites</DIV>
                    <div style="float: right">
                        <asp:Button ID="btCerrarConTramite" runat="server" Text="X" /> 
                    </div> 
                </div>
            </asp:Panel>
             <uc3:CtrlConsTramite id="CtrlConsTramite2" runat="server">
            </uc3:CtrlConsTramite><br /><br /><br />
            <asp:Button style="display:none" id="btn_target_tramite" runat ="server"></asp:Button>
        </asp:Panel> 
    </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>

