<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="UserTram.aspx.vb" Inherits="Seguridad_UserTram_UserTram" title="Asignacion de Tramites a Usuarios" %>
<%@ Register Src="~/CtrlUsr/Tramites/Con_tramite.ascx" TagName="CtrlConsTramite" TagPrefix="uc2" %>
<%@ Register Src="../../CtrlUsr/Terceros/Con_Tercero.ascx" TagName="CtrlConTercero" TagPrefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="SampleContent" Runat="Server">

<asp:ScriptManager ID="ScriptManager1" runat="server">
</asp:ScriptManager>
<div class="demoarea">

    <asp:UpdatePanel ID="UpdatePanel3" runat="server">
    <ContentTemplate>
        <asp:Label id="MsgResult" runat="server" Width="90%" ></asp:Label>
        <br />
        <asp:MultiView ID="MultiView1" runat="server" ActiveViewIndex="1">
            <asp:View ID="View1" runat="server"> 
            <asp:UpdatePanel ID="UpdatePanel1" runat="server">
            <ContentTemplate>
            <table style="width:800px;">
            <tr>
            <td colspan="3">&#160;
            </td>
            </tr>
            <tr class="TbDecl">
            <td colspan="3">Asignacion de Tramite al Usuario</td>
            </tr>
            <tr>
            <td style="width:110px">Usuario</td>
            <td style="width:110px"></td>
            <td style="width:110px"></td>
            </tr><tr>
            <td>
            <asp:TextBox ID="Nit" runat="server" Enabled="False" Width="100%" AutoPostBack="True" ></asp:TextBox></td>
            <td colspan="2">
            <asp:TextBox ID="Dv" runat="server" Enabled="False" Width="17px"> </asp:TextBox>
            <asp:Button ID="BtnBuscDP" runat="server" accessKey="B" Text="..." ToolTip="Buscar Agente Recaudador" 
                                 UseSubmitBehavior="False" Width="17px" CausesValidation="False" /><asp:TextBox ID="Agente" runat="server" Enabled="False" Width="220px"> </asp:TextBox></td></tr><tr><td colspan="2">&#160;</td><td>&#160;</td></tr></table><asp:GridView ID="gvTramites" runat="server" AutoGenerateColumns="False" 
                        DataKeyNames="TRAM_CODI" DataSourceID="ObjectDataSource1"><Columns><asp:BoundField DataField="TRAM_NOMB" HeaderText="Tramites" ><ItemStyle Width="350px" /></asp:BoundField><asp:TemplateField><ItemTemplate><asp:CheckBox ID="CheckBox1" runat="server" /></ItemTemplate></asp:TemplateField></Columns></asp:GridView><table style="width:400px;"><tr><td>&#160;</td><td align="center"><asp:ImageButton ID="btGuardar" runat="server" 
                                    ImageUrl="~/images/Operaciones/save.png" />&nbsp;&nbsp; <asp:ImageButton ID="btCancelar" runat="server" 
                                    ImageUrl="~/images/Operaciones/Deshacer.png" /></td><td>&#160;</td></tr></table><asp:ObjectDataSource ID="ObjectDataSource1" runat="server" 
                        OldValuesParameterFormatString="original_{0}" SelectMethod="GetRecords" 
                        TypeName="Tramites"></asp:ObjectDataSource></ContentTemplate></asp:UpdatePanel>
            </asp:View>
            <asp:View ID="View2" runat="server">
                <table style="width:580px;">
                    <tr>
                    <td colspan="3">
                            &nbsp;</td>
                    </tr> 
                    <tr class="TbDecl">
                        <td colspan="3">
                            ASIGNACION DE PERMISOS DE LA SECCION DE TRAMITES A USUARIOS</td>
                    </tr>
                    <tr>
                        <td colspan="3">
                            &nbsp;</td>
                    <tr>
                        <td>
                            &nbsp;
                            <asp:Button ID="btPermiso" runat="server" Text="Asignar Permiso" />
                        </td>
                        <td>
                            &nbsp;
                        </td>
                        <td>
                            &nbsp;
                        </td>
                    </tr>
                    <tr>
                        <td colspan="3">
                            &nbsp;</td>
                    </tr>
                    <tr class="TbDecl">
                        <td colspan="3">
                           Usuarios y Tamites Asignados</td>
                    </tr>
                    <tr>
                        <td colspan="3">
                            <asp:GridView ID="gvConsulta" runat="server" AllowPaging="True" DataKeyNames="TRTE_NIT, TRTE_TRAM" 
                                AutoGenerateColumns="False" DataSourceID="odsTramTer">
                                <Columns>
                                    <asp:BoundField DataField="TRTE_NIT" HeaderText="Nit"><HeaderStyle HorizontalAlign="Left" /><ItemStyle Width="110px" /></asp:BoundField>
                                    <asp:BoundField DataField="TER_NOM" HeaderText="Nombre"><HeaderStyle HorizontalAlign="Left" /><ItemStyle Width="210px" /></asp:BoundField>
                                    <asp:BoundField DataField="TRAM_NOMB" HeaderText="Tramite"><HeaderStyle HorizontalAlign="Left" /><ItemStyle Width="220px" /></asp:BoundField>
                                    <asp:CommandField ButtonType="Image" 
                                        SelectImageUrl="~/images/Operaciones/delete2.png" ShowSelectButton="True" />
                                </Columns>
                            </asp:GridView>
                        </td>
                    </tr>
                </table>
                <asp:ObjectDataSource ID="odsTramTer" runat="server" SelectMethod="GetRecords" 
                TypeName="Tram_Ter" OldValuesParameterFormatString="original_{0}">
                </asp:ObjectDataSource>
            </asp:View>
        </asp:MultiView>
    </ContentTemplate>
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
             <uc1:CtrlConTercero id="CtrlConTercero2" runat="server">
            </uc1:CtrlConTercero><br /><br /><br />
            <asp:Button style="display:none" id="btn_Target" runat ="server"></asp:Button>
        </asp:Panel> 
    </ContentTemplate>
    </asp:UpdatePanel>
</div>
</asp:Content>

