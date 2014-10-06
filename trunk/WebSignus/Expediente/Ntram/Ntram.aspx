<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false"
    CodeFile="Ntram.aspx.vb" Inherits="Expediente_Ntram_Ntram" Title="Notificacion de Envios" %>

<%@ Register Src="../../CtrlUsr/Expedientes/Anu_Expediente.ascx" TagName="CtrlAnulaExpeTram"
    TagPrefix="uc3" %>
<asp:Content ID="Content1" ContentPlaceHolderID="SampleContent" runat="Server">
    <div class="demoarea">
        <asp:ScriptManager ID="ScriptManager1" runat="server" EnableScriptGlobalization="true">
        </asp:ScriptManager>
        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
            <ContentTemplate>
                <asp:Label ID="MsgResult" runat="server" SkinID="MsgResult" Width="90%"></asp:Label>
                <table style="width: 500px;">
                    <tr>
                        <td colspan="4">
                            &nbsp;
                        </td>
                    </tr>
                    <tr class="TbDecl">
                        <td colspan="4">
                            Registro de Entrega&nbsp;de Notificaciones
                        </td>
                    </tr>
                    <tr>
                        <td colspan="4">
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 100px">
                            Expediente
                        </td>
                        <td colspan="2">
                            <asp:TextBox ID="tbNumExp" Enabled="false" runat="server"></asp:TextBox>
                        </td>
                        <td style="width: 100px">
                            <asp:LinkButton ID="LinkButton1" runat="server">Volver</asp:LinkButton>
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 100px">
                            <asp:Label ID="Label11" runat="server" Text="Razon Social"></asp:Label>
                        </td>
                        <td colspan="3">
                            <asp:TextBox ID="lAgente" runat="server" Enabled="False" ReadOnly="True" Width="360px"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 100px">
                            <asp:Label ID="Label53" runat="server" Text="Impuesto"></asp:Label>
                        </td>
                        <td colspan="2">
                            <asp:TextBox ID="tbImpuesto" runat="server" Enabled="False" Style="width: 220px"></asp:TextBox>
                        </td>
                        <td style="width: 100px">
                            &nbsp;
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 100px">
                            <asp:Label ID="Label54" runat="server" Text="Tramite Actual"></asp:Label>
                        </td>
                        <td colspan="2">
                            <asp:TextBox ID="lTramite" runat="server" Enabled="False" ReadOnly="True" Text=""
                                Width="220px"></asp:TextBox>
                        </td>
                        <td style="width: 100px">
                            &nbsp;
                        </td>
                    </tr>
                </table>
                
                <table>
                    <tr class="TbDecl">
                        <td colspan="4">
                            Información de la Notificación&nbsp;</td>
                    </tr>
                    <tr>
                        <td style="width: 100px">
                            Notificación
                        </td>
                        <td colspan="2">
                            <asp:DropDownList ID="cmbNotificacion" runat="server" AutoPostBack="True" 
                                DataSourceID="odsNotificacion" DataTextField="DESCRIPCION" 
                                DataValueField="COD_NOTIFICACION" Width="200px">
                            </asp:DropDownList>
                        </td>
                        <td style="width: 100px">
                            &nbsp;
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 100px">
                            Finalizado&nbsp;
                        </td>
                        <td style="width: 10px">
                            <asp:DropDownList ID="cmbFinalizado" runat="server">
                                <asp:ListItem Value="N">NO</asp:ListItem>
                                <asp:ListItem Value="S">SI</asp:ListItem>
                            </asp:DropDownList>
                        </td>
                        <td>
                            &nbsp;
                        </td>
                        <td>
                            &nbsp;
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 100px">
                            Fecha Envio
                        </td>
                        <td style="width: 10px">
                            <asp:TextBox ID="tbFecEnvio" runat="server" Width="100px"></asp:TextBox>
                        </td>
                        <td style="width: 100px">
                            <asp:Label ID="Label1" runat="server" Text="Fecha de Recibido"></asp:Label>
                        </td>
                        <td>
                            <asp:TextBox ID="tbFechaRecibido" runat="server" Width="100px"></asp:TextBox>
                        </td>
                    </tr>
                </table>
                <asp:MultiView ID="MultiView1" runat="server">
                    <asp:View ID="View1" runat="server">
                        <asp:Panel ID="PCorreo" runat="server" Visible="True">
                            <table style="width: 500px;">
                                <tr>
                                    <td>
                                        <asp:Label ID="Label2" runat="server" Text="No.  De Guía"></asp:Label>
                                    </td>
                                    <td>
                                        <asp:Label ID="Label4" runat="server" Text="Empresa Mensajeria"></asp:Label>
                                    </td>
                                    <td>
                                        &nbsp;
                                    </td>
                                </tr>
                                <tr>
                                    <td style="width: 150px">
                                        <asp:TextBox ID="tbNumguia" runat="server" Width="150px"></asp:TextBox>
                                    </td>
                                    <td style="width: 150px">
                                        <asp:DropDownList ID="cmbEmpresa" runat="server" DataSourceID="odsEmpresa" DataTextField="DESCRIPCION"
                                            DataValueField="COD_EMME" Width="200px">
                                        </asp:DropDownList>
                                    </td>
                                    <td style="width: 200px">
                                        &nbsp;
                                    </td>
                                </tr>
                            </table>
                        </asp:Panel>
                    </asp:View>
                    <asp:View ID="View2" runat="server">
                        <asp:Panel ID="PPeriodico" runat="server">
                            <table style="width: 500px;">
                                <tr>
                                    <td>
                                        <asp:Label ID="Label6" runat="server" Text="Periodico"></asp:Label>
                                    </td>
                                    <td>
                                        &nbsp;
                                    </td>
                                    <td>
                                        &nbsp;
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="2">
                                        <asp:TextBox ID="tbPeriodico" runat="server" Width="250px"></asp:TextBox>
                                    </td>
                                    <td>
                                        &nbsp;
                                    </td>
                                </tr>
                            </table>
                        </asp:Panel>
                    </asp:View>
                </asp:MultiView>
                <asp:Panel ID="pComun" runat="server">
                    <asp:Label ID="Label3" runat="server" Text="Observacion"></asp:Label>
                    <br />
                    <asp:TextBox ID="tbObservacion" runat="server" TextMode="MultiLine" MaxLength="200"
                        Width="500px"></asp:TextBox>
                    <br />
                    <div style="text-align: center" align="center">
                    </div>
                </asp:Panel>
                <table>
                    <tr class="TbDecl">
                        <td colspan="4">
                            Información de Respuesta de Notificación &nbsp;
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 106px">
                            No de Folios
                        </td>
                        <td colspan="3">
                            &nbsp;
                            <asp:TextBox ID="tbNFolios" runat="server" Width="43px">1</asp:TextBox>
                            &nbsp;
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 106px">
                            <asp:Label ID="Label7" runat="server" Text="Respuesta"></asp:Label>
                        </td>
                        <td colspan="3">
                            &nbsp; &nbsp;
                            <asp:DropDownList ID="CmbRtaNotif" runat="server">
                                <asp:ListItem Value="No">No</asp:ListItem>
                                <asp:ListItem Value="Si">Si</asp:ListItem>
                            </asp:DropDownList>
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 106px">
                            &nbsp;</td>
                        <td style="width: 273px">
                            &nbsp;</td>
                        <td style="width: 77px">
                            <asp:ImageButton ID="BtnSave" runat="server" 
                                ImageUrl="~/images/Operaciones/save.png" />
                        </td>
                        <td style="width: 200px">
                            <asp:ImageButton ID="BtnCancel" runat="server" CausesValidation="False" 
                                ImageUrl="~/images/Operaciones/undo.png" onclick="BtnCancel_Click" />
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 106px">
                            &nbsp;</td>
                        <td>
                            &nbsp;</td>
                        <td>
                            Guardar</td>
                        <td>
                            Volver</td>
                    </tr>
                </table>
                <asp:Panel ID="pNotificaciones" runat="server">
                    <table style="width: 500px;">
                        <tr>
                            <td>
                                &nbsp;</td>
                        </tr>
                        <tr>
                            <td>
                                <asp:GridView ID="GridView1" runat="server" AllowPaging="True" AutoGenerateColumns="False"
                                    DataKeyNames="EXNF_ID" DataSourceID="odsEntregas">
                                    <Columns>
                                        <asp:BoundField DataField="TRAM_NOMB" HeaderText="Tramite">
                                            <HeaderStyle HorizontalAlign="Left" />
                                            <ItemStyle Width="120px" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="FINALIZADO" HeaderText="Finalizado">
                                            <ItemStyle HorizontalAlign="Left" Width="50px" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="EXNF_FENV" DataFormatString="{0:d}" HeaderText="Enviado">
                                            <HeaderStyle HorizontalAlign="Left" />
                                            <ItemStyle HorizontalAlign="Left" Width="100px" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="EXNF_FREB" DataFormatString="{0:d}" HeaderText="Recibido">
                                            <HeaderStyle HorizontalAlign="Left" />
                                            <ItemStyle HorizontalAlign="Left" Width="100px" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="DESCRIPCION" HeaderText="Notificado">
                                            <HeaderStyle HorizontalAlign="Left" />
                                            <ItemStyle HorizontalAlign="Left" Width="130px" />
                                        </asp:BoundField>
                                        <asp:ButtonField ButtonType="Image" CommandName="Eliminar" ImageUrl="~/images/Operaciones/delete2.png"
                                            Text="Eliminar" />
                                        <asp:CommandField SelectText="Detalle" ShowSelectButton="True" />
                                    </Columns>
                                </asp:GridView>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                &nbsp; &nbsp; &nbsp;
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:DetailsView ID="dvEntregas" runat="server" AutoGenerateRows="False" DataSourceID="odsEntregaDetalle"
                                    Height="50px" Width="500px" CellPadding="4" ForeColor="#333333" GridLines="None">
                                    <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                                    <CommandRowStyle BackColor="#E2DED6" Font-Bold="True" />
                                    <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
                                    <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
                                    <Fields>
                                        <asp:BoundField DataField="EXTR_GUIA" HeaderText="No. Guia" />
                                        <asp:BoundField DataField="EMPRESA_MENSAJERIA" HeaderText="Empresa de Mensajeria">
                                            <HeaderStyle Width="120px" />
                                            <ItemStyle Width="300px" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="EXNF_MEDIO" HeaderText="Periodico">
                                            <ItemStyle Width="300px" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="EXNF_OBS" HeaderText="Observación">
                                            <ItemStyle Width="300px" />
                                        </asp:BoundField>
                                    </Fields>
                                    <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                                    <EditRowStyle BackColor="#999999" />
                                    <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                                </asp:DetailsView>
                            </td>
                        </tr>
                    </table>
                </asp:Panel>
                <ajaxToolkit:CalendarExtender ID="cFecRecibido" runat="server" TargetControlID="tbFechaRecibido"
                    Format="dd/MM/yyyy">
                </ajaxToolkit:CalendarExtender>
                <ajaxToolkit:CalendarExtender ID="cFecEnvio" runat="server" TargetControlID="tbFecEnvio"
                    Format="dd/MM/yyyy">
                </ajaxToolkit:CalendarExtender>
                <asp:HiddenField ID="HFTramiteActual" runat="server" />
            </ContentTemplate>
        </asp:UpdatePanel>
        <asp:UpdatePanel ID="upAnularTram" runat="server" UpdateMode="Conditional">
            <ContentTemplate>
                <ajaxToolkit:ModalPopupExtender ID="ModalPopupAnular" runat="server" TargetControlID="btn_Target"
                    PopupControlID="pAnularExpeTram" PopupDragHandleControlID="pAnularExpeTram2"
                    DropShadow="true" BackgroundCssClass="modalBackground">
                </ajaxToolkit:ModalPopupExtender>
                <asp:Panel ID="pAnularExpeTram" runat="server" Width="450px" Height="229%" CssClass="ModalPanel2">
                    <asp:Panel ID="pAnularExpeTram2" runat="Server" Height="30px" CssClass="BarTitleModal2">
                        <div style="padding-right: 5px; padding-left: 5px; padding-bottom: 5px; vertical-align: middle;
                            padding-top: 5px">
                            <div style="float: left">
                                Anular Tramite de Expediente</div>
                            <div style="float: right">
                                <asp:Button ID="btCerrarAnular" runat="server" Text="X" />
                            </div>
                        </div>
                    </asp:Panel>
                    <uc3:CtrlAnulaExpeTram ID="CtrlAnulaExpeTram2" runat="server"></uc3:CtrlAnulaExpeTram>
                    <br />
                    <br />
                    <br />
                    <asp:Button Style="display: none" ID="btn_Target" runat="server"></asp:Button>
                </asp:Panel>
            </ContentTemplate>
        </asp:UpdatePanel>
        <asp:ObjectDataSource ID="odsNotificacion" SelectMethod="GetRecords" TypeName="Notificacion"
            runat="server" OldValuesParameterFormatString="original_{0}"></asp:ObjectDataSource>
        <asp:ObjectDataSource ID="odsEmpresa" runat="server" SelectMethod="GetRecords" TypeName="Emp_Mensajeria"
            OldValuesParameterFormatString="original_{0}"></asp:ObjectDataSource>
        <asp:ObjectDataSource ID="odsEntregas" runat="server" SelectMethod="GetPorExpediente"
            TypeName="Expe_Notif" OldValuesParameterFormatString="original_{0}">
            <SelectParameters>
                <asp:ControlParameter ControlID="tbNumExp" Name="EXTR_NUME" PropertyName="Text" Type="String" />
            </SelectParameters>
        </asp:ObjectDataSource>
        <asp:ObjectDataSource ID="odsEntregaDetalle" runat="server" SelectMethod="GetPorId"
            TypeName="Expe_Notif" OldValuesParameterFormatString="original_{0}">
            <SelectParameters>
                <asp:ControlParameter ControlID="GridView1" Name="EXNF_ID" PropertyName="SelectedValue"
                    Type="String" />
            </SelectParameters>
        </asp:ObjectDataSource>
    </div>
</asp:Content>
