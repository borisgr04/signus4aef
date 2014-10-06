<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false"
    CodeFile="Omisos.aspx.vb" Inherits="Informes_Default" Title="Informe Omisos" %>

<%@ Register Assembly="Microsoft.ReportViewer.WebForms, Version=10.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a"
    Namespace="Microsoft.Reporting.WebForms" TagPrefix="rsweb" %>
<%@ Register Src="../../CtrlUsr/Terceros/ConsultaTer.ascx" TagName="ConsultaTer"
    TagPrefix="uc1" %>
<%@ Register Src="../../CtrlUsr/Terceros/Con_Tercero.ascx" TagName="Con_Tercero"
    TagPrefix="uc2" %>
<asp:Content ID="Content1" ContentPlaceHolderID="SampleContent" runat="Server">
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
    <div class="demoarea">
        <asp:ScriptManager ID="ScriptManager1" runat="server">
        </asp:ScriptManager>
        <asp:Label ID="mensaje" runat="server"></asp:Label>
        <p>
            <asp:Label ID="Tit" runat="server" CssClass="Titulo" Text="DECLARACIONES POR PERIODO"></asp:Label>
        </p>
        
          <%--<asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional">
                <ContentTemplate>--%>
                    <asp:Label ID="MsgResult" runat="server" ></asp:Label>
                    <table style="width: 521px; height: 34px" id="Table2">
                        <tbody>
                            <tr>
                                <td>
                                    <asp:Label ID="Label2" runat="server" Text="Tipo de Declaracion" Width="111px" ></asp:Label>
                                </td>
                                <td colspan="4">
                                    <asp:DropDownList ID="CMBCLADEC" runat="server" Width="343px" DataValueField="cld_cod"
                                        DataTextField="cld_nom" DataSourceID="ObjClaseDec" AutoPostBack="True" >
                                    </asp:DropDownList>
                                </td>
                                <td>
                                </td>
                                <td>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label ID="Label1" runat="server" Text="Año Gravable"></asp:Label>
                                </td>
                                <td colspan="4">
                                    <asp:DropDownList ID="CMBANO" runat="server" DataValueField="CAL_VIG" DataTextField="CAL_VIG"
                                        DataSourceID="ObjCalVigencias" AutoPostBack="True" >
                                    </asp:DropDownList>
                                </td>
                                <td>
                                </td>
                                <td>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:CheckBox ID="ChkTipAg" runat="server" Text="Tipo Agente" />
                                </td>
                                <td colspan="4">
                                    <asp:DropDownList ID="CbTTcer" runat="server" DataSourceID="ObjTTer" DataTextField="TAG_NOM"
                                        DataValueField="TAG_COD" Width="180px">
                                    </asp:DropDownList>
                                </td>
                                <td>
                                </td>
                                <td>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:CheckBox ID="ChkMun" runat="server" Text="Municipio" />
                                </td>
                                <td colspan="4">
                                    <asp:DropDownList ID="CMBMPIO" runat="server" DataSourceID="ObjMUN"
                                        DataTextField="MUN_NOM" DataValueField="MUN_COD" Width="172px">
                                    </asp:DropDownList>
                                </td>
                                <td style="width: 1330px">
                                    &nbsp;
                                </td>
                                <td style="width: 1330px">
                                    &nbsp;
                                </td>
                            </tr>
                            <tr>
                                <td style="width: 100px; height: 26px;">
                                    <asp:CheckBox ID="ChkEnt" runat="server" Text="Entidad" Visible="False" />
                                </td>
                                <td style="height: 26px;" colspan="6">
                                    <asp:TextBox ID="Nit" runat="server" Enabled="False" Width="20%" 
                                        Visible="False"></asp:TextBox>
                                    <asp:TextBox ID="Dv" runat="server" Enabled="False" Width="17px" 
                                        Visible="False"></asp:TextBox>
                                    <asp:Button ID="BtnBuscDP" runat="server" AccessKey="B" CausesValidation="False"
                                        OnClick="BtnBuscar_Click" Text="..." ToolTip="Buscar Agente Recaudador" UseSubmitBehavior="False"
                                        Width="17px" Visible="False" />
                                    &nbsp;<asp:TextBox ID="Agente" runat="server" Enabled="False" Width="220px" 
                                        Visible="False"></asp:TextBox>
                                    &nbsp;
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
                                <td>
                                    &nbsp;
                                </td>
                                <td>
                                    &nbsp;
                                </td>
                                <td>
                                    <asp:ImageButton ID="BtnBuscar" runat="server" AlternateText="Buscar" ImageUrl="~/images/Operaciones/search2.png"
                                        ToolTip="Buscar" />
                                </td>
                                <td>
                                    <asp:ImageButton ID="Btncancel" runat="server" AlternateText="Cancelar" ImageUrl="~/images/Operaciones/Deshacer.png"
                                        ToolTip="Cancelar" />
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
                                <td>
                                    &nbsp;
                                </td>
                                <td>
                                    &nbsp;
                                </td>
                                <td>
                                    <asp:Label ID="Label4" runat="server" Text="Buscar" Width="44px"></asp:Label>
                                </td>
                                <td>
                                    <asp:Label ID="Label5" runat="server"  Text="Cancelar" Width="53px"></asp:Label>
                                </td>
                            </tr>
                        </tbody>
                    </table>
                    
                    <%--<asp:GridView ID="GridView1" runat="server">
                    </asp:GridView>--%>

                <rsweb:ReportViewer ID="Rptview" runat="server" Font-Names="Verdana" Font-Size="8pt"
                        Height="358px" Width="930px" InteractiveDeviceInfos="(Colección)" 
                        WaitMessageFont-Names="Verdana" WaitMessageFont-Size="14pt" 
            Visible="False">
                    <LocalReport ReportPath="Report\Consultas\RptOmisos.rdlc">
                    </LocalReport>
                </rsweb:ReportViewer>

                    
                    <br />
                    
                    <br />
                    <br />
                    &nbsp;
           <%--     </ContentTemplate>
                <Triggers>
                    <asp:AsyncPostBackTrigger ControlID="CMBCLADEC" EventName="SelectedIndexChanged">
                    </asp:AsyncPostBackTrigger>
                    <asp:AsyncPostBackTrigger ControlID="CMBANO" EventName="SelectedIndexChanged"></asp:AsyncPostBackTrigger>
                    <asp:AsyncPostBackTrigger ControlID="CMBMPIO" EventName="SelectedIndexChanged"></asp:AsyncPostBackTrigger>
                    <asp:PostBackTrigger ControlID="Btncancel"></asp:PostBackTrigger>
                    <asp:PostBackTrigger ControlID="BtnBuscar"></asp:PostBackTrigger>
                </Triggers>
            </asp:UpdatePanel>--%>
            
            <asp:ObjectDataSource ID="ObjMUN" runat="server" SelectMethod="GetRecords" TypeName="Municipios">
            </asp:ObjectDataSource>
            <asp:ObjectDataSource ID="ObjCalVigencias" runat="server" OldValuesParameterFormatString="original_{0}"
                SelectMethod="GetVigencias" TypeName="Calendario">
                <SelectParameters>
                    <asp:ControlParameter ControlID="CMBCLADEC" Name="Cla_Dec" PropertyName="SelectedValue"
                        Type="String" />
                </SelectParameters>
            </asp:ObjectDataSource>
            <asp:ObjectDataSource ID="ObjClaseDec" runat="server" OldValuesParameterFormatString="original_{0}"
                SelectMethod="GetcargarTipoDecla" TypeName="Informes"></asp:ObjectDataSource>
            <asp:ObjectDataSource ID="ObjTTer" runat="server" TypeName="TTerc" SelectMethod="GetRecords">
            </asp:ObjectDataSource>
            
            <asp:UpdatePanel ID="UpdatePanel2" runat="server" UpdateMode="Conditional">
                <ContentTemplate>
                    <!-- Mensaje de Salida-->
                    <asp:Button ID="hiddenTargetControlForModalPopup2" runat="server" Style="display: none" />
                    <ajaxToolkit:ModalPopupExtender ID="ModalPopupTer" runat="server" BackgroundCssClass="modalBackground"
                        BehaviorID="programmaticModalPopupBehavior2" DropShadow="True" PopupControlID="programmaticPopup2"
                        PopupDragHandleControlID="programmaticPopupDragHandle2" RepositionMode="RepositionOnWindowScroll"
                        TargetControlID="hiddenTargetControlForModalPopup2">
                    </ajaxToolkit:ModalPopupExtender>
                    <asp:Panel ID="programmaticPopup2" runat="server" CssClass="ModalPanel2" Height="229%"
                        Width="625px">
                        <asp:Panel ID="programmaticPopupDragHandle2" runat="Server" CssClass="BarTitleModal2"
                            Height="30px">
                            <div style="padding-right: 5px; padding-left: 5px; padding-bottom: 5px; vertical-align: middle;
                                padding-top: 5px">
                                <div style="float: left">
                                    Buscar Tercero
                                </div>
                                <div style="float: right">
                                    <input id="BtnCerrar" type="button" value="X" onclick="javascript:CerrarTercero();" />
                                </div>
                            </div>
                        </asp:Panel>
                        &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
                        <br />
                        &nbsp; &nbsp; &nbsp;&nbsp;
                        <uc1:ConsultaTer ID="ConsultaTer1" runat="server" Ret="AR" Tipo="AR" />
                        <br />
                        <br />
                        <br />
                    </asp:Panel>
                </ContentTemplate>
                <Triggers>
                    <asp:AsyncPostBackTrigger ControlID="BtnBuscDP" EventName="Click" />
                </Triggers>
            </asp:UpdatePanel>
            
<%--
            <asp:UpdateProgress ID="UpdateProgress1" runat="server" AssociatedUpdatePanelID="UpdatePanel1">
                    <ProgressTemplate>
                        <div class="Loading">
                            <img alt="" src="../images/loading.gif" title="" />
                            Cargando …
                        </div>
                        <br />
                    </ProgressTemplate>
                </asp:UpdateProgress>--%>
            
    </div>
</asp:Content>
