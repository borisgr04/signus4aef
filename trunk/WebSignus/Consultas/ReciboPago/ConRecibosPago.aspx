<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="ConRecibosPago.aspx.vb" Inherits="Consultas_ReciboPago_ConRecibosPago" title="Consulta de Recibos de Pagos" %>
<%@ Register Src="../../CtrlUsr/Terceros/Con_Tercero.ascx" TagName="CtrlConTercero" TagPrefix="uc2" %>
<asp:Content ID="Content1" ContentPlaceHolderID="SampleContent" Runat="Server">
<div class="demoarea">
    <asp:ScriptManager ID="ScriptManager1" runat="server" EnableScriptGlobalization="true">
    </asp:ScriptManager>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
    <ContentTemplate>
    <table style="width:800px;">
        <tr>
            <td class="TbDecl" colspan="3">
                CONSULTA DE RECIBOS DE PAGOS</td>
        </tr>
        <tr>
            <td style="width:380px">
                &nbsp;</td>
            <td style="width:200">
                &nbsp;</td>
            <td align="right">
                <asp:LinkButton ID="lbVolver" runat="server">Volver</asp:LinkButton>
            </td>
        </tr>
        <tr>
            <td>
                Agente Retenedor</td>
            <td>
                <asp:CheckBox ID="cbEstado" runat="server" Text="Estado" />
            </td>
            <td>
                <asp:CheckBox ID="cbSoporte" runat="server" Text="Soporte" />
            </td>
        </tr>
        <tr>
            <td>
                <asp:TextBox ID="tbNit" runat="server" Enabled="False"></asp:TextBox>
                <asp:TextBox ID="tbTercero" runat="server" Width="220px" Enabled="False"></asp:TextBox>
                <asp:LinkButton ID="lbTercero" runat="server">...</asp:LinkButton>
            </td>
            <td>
                <asp:DropDownList ID="cmbEstado" runat="server" Width="150px">
                    <asp:ListItem Value="DF">Sin Pago</asp:ListItem>
                    <asp:ListItem Value="PR">Pagado</asp:ListItem>
                </asp:DropDownList>
            </td>
            <td>
                <asp:DropDownList ID="cmbSoporte" runat="server">
                    <asp:ListItem Value="DELP">Declaracion</asp:ListItem>
                    <asp:ListItem Value="ACPA">Acuerdo de Pago</asp:ListItem>
                </asp:DropDownList>
                <asp:TextBox ID="tbNumeroDoc" runat="server" Width="130px"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td style="height: 25px">
                <asp:CheckBox ID="cbRangoFecha" runat="server" Text="Rango de Fecha" />
            </td>
            <td style="height: 25px">
                <asp:CheckBox ID="cbNoRecibo" runat="server" Text="Numero Recibo" />
            </td>
            <td style="height: 25px">
                </td>
        </tr>
        <tr>
            <td>
                <asp:TextBox ID="tbFechaIni" runat="server" Width="150px"></asp:TextBox>
                <asp:TextBox ID="tbFechaFin" runat="server" Width="150px"></asp:TextBox>
            </td>
            <td>
                <asp:TextBox ID="tbNumRecibo" runat="server" Width="150px"></asp:TextBox>
            </td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td>
                <asp:ImageButton ID="btConsultar" runat="server" 
                    ImageUrl="~/images/Operaciones/search2.png" />
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                <asp:ImageButton ID="btExportar" runat="server" Height="48px" 
                    ImageUrl="~/images/imagev2/excel2007.gif" Width="48px" />
            </td>
            <td>
                &nbsp;</td>
            <td>

            </td>
        </tr>
        <tr>
            <td>
                Buscar &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Exportar</td>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
        </tr>
    </table>
        <asp:GridView ID="gvConsulta" runat="server" AutoGenerateColumns="False" Width="800px">
            <Columns>
                <asp:BoundField DataField="ROF_COD" HeaderText="Recibo No." >
                    <HeaderStyle HorizontalAlign="Left" />
                </asp:BoundField>
                <asp:BoundField DataField="ROF_FREG" DataFormatString="{0:d}" 
                    HeaderText="Fecha">
                    <HeaderStyle HorizontalAlign="Left" />
                </asp:BoundField>
                <asp:BoundField DataField="ROF_TDOC" HeaderText="Tipo Soporte">
                    <HeaderStyle HorizontalAlign="Left" />
                </asp:BoundField>
                <asp:BoundField DataField="ROF_DECC" HeaderText="Soporte No.">
                    <HeaderStyle HorizontalAlign="Left" />
                </asp:BoundField>
                <asp:BoundField DataField="ROF_VPA" DataFormatString="{0:c}" 
                    HeaderText="Valor Impuesto">
                    <HeaderStyle HorizontalAlign="Right" />
                    <ItemStyle HorizontalAlign="Right" />
                </asp:BoundField>
                <asp:BoundField DataField="ROF_SAN" DataFormatString="{0:c}" 
                    HeaderText="Valor Sancion">
                    <HeaderStyle HorizontalAlign="Right" />
                    <ItemStyle HorizontalAlign="Right" />
                </asp:BoundField>
                <asp:BoundField DataField="ROF_INT" DataFormatString="{0:c}" 
                    HeaderText="Valor Interes">
                    <HeaderStyle HorizontalAlign="Right" />
                    <ItemStyle HorizontalAlign="Right" />
                </asp:BoundField>
                <asp:BoundField DataField="ROF_TPAG" DataFormatString="{0:c}" 
                    HeaderText="Total Pagar">
                    <HeaderStyle HorizontalAlign="Right" />
                    <ItemStyle HorizontalAlign="Right" />
                </asp:BoundField>
                <asp:BoundField DataField="ROF_EST" HeaderText="Estado">
                    <HeaderStyle HorizontalAlign="Right" />
                    <ItemStyle HorizontalAlign="Right" />
                </asp:BoundField>
            </Columns>
        </asp:GridView>
        
    <ajaxToolkit:CalendarExtender
       ID="cFechaIni" runat="server" TargetControlID="tbFechaIni" 
       Format="dd/MM/yyyy" >
    </ajaxToolkit:CalendarExtender>
    <ajaxToolkit:CalendarExtender ID="cFechaFin" runat="server"
        TargetControlID="tbFechaFin" 
        Format="dd/MM/yyyy" >
    </ajaxToolkit:CalendarExtender> 
            
    </ContentTemplate>
        <Triggers>
            <asp:PostBackTrigger ControlID="btExportar" />
        </Triggers>
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
    
</div>
</asp:Content>

