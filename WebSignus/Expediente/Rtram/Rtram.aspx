<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="Rtram.aspx.vb" Inherits="Expediente_Rtram_Rtram" title="Pasar a Siguiente Tramite" %>

<%@ Register Assembly="eWorld.UI, Version=2.0.6.2393, Culture=neutral, PublicKeyToken=24d65337282035f2"
    Namespace="eWorld.UI" TagPrefix="ew" %>

<asp:Content ID="Content1" ContentPlaceHolderID="SampleContent" Runat="Server">
    <div class="demoarea">
     <asp:Label ID="MsgResult" runat="server" Width="90%"></asp:Label>
    <table style="width:700px;">
        <tr>
            <td colspan="3" style="text-align:right">
                 &nbsp;</td>
        </tr>
        <tr class="TbDecl">
            <td colspan="3">
                PASAR A SIGUIENTE TRAMITE
            </td>
        </tr>
        <tr>
            <td colspan="3" align="right">
                
                <asp:LinkButton ID="LinkButton1" runat="server" CausesValidation="False">Volver</asp:LinkButton>
                
            </td>
        </tr>
        <tr>
            <td style="width:100px">
                <asp:Label ID="Label52" runat="server" Text="No. Expediente"></asp:Label>
            </td>
            <td>
                <asp:TextBox ID="tbNumExp" runat="server" style="width:100px" Enabled="False"></asp:TextBox>
            </td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="Label54" runat="server" Text="Fecha"></asp:Label>
            </td>
            <td>
                        <asp:TextBox ID="tbFechaExp" runat="server" style="width:100px" ReadOnly="True" 
                            ForeColor="#000066" Enabled="False"></asp:TextBox>
            </td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td >
                <asp:Label ID="Label53" runat="server" Text="Impuesto"></asp:Label>
            </td>
            <td>
                <asp:TextBox ID="tbImpuesto" runat="server" style="width:220px" Enabled="False"></asp:TextBox>
                -<asp:TextBox ID="lcodImpuesto" runat="server" Enabled="False" Width="16px"></asp:TextBox>
            </td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td>
                Nit</td>
            <td>
                <asp:TextBox ID="tbNit" runat="server" style="width:220px" Enabled="False"></asp:TextBox>
            </td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="Label11" runat="server" Text="Razon Social"></asp:Label>
            </td>
            <td>
                <asp:TextBox ID="lAgente" runat="server" Width="450px" ReadOnly="True" 
                    Enabled="False"></asp:TextBox>
            </td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="Label1" runat="server" Text="Tramite Actual"></asp:Label>
            </td>
            <td>
                <asp:TextBox ID="lTramite" runat="server" ReadOnly="True" Text="" Width="450px" 
                    Enabled="False"></asp:TextBox>
            </td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="Label51" runat="server" Text="Tramite Siguiente"></asp:Label>
            </td>
            <td>
                <asp:DropDownList ID="cmbTramiteSgte" runat="server" Width="450px" 
                            DataSourceID="odsTramiteSgte" DataTextField="TRAM_PARA" 
                            DataValueField="TRRE_PARA" AutoPostBack="True">
                        </asp:DropDownList>
              
            </td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td>
                        Consecutivo</td>
            <td>
                <asp:TextBox ID="tbConsecutivo" runat="server"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
                    ErrorMessage="*" ControlToValidate="tbConsecutivo"></asp:RequiredFieldValidator></td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td align="center" colspan="3">
                <asp:MultiView ID="MultiView1" runat="server">
                    <asp:View ID="View1" runat="server">
                        <asp:ObjectDataSource ID="ObjRsancion" runat="server" 
                            OldValuesParameterFormatString="original_{0}" SelectMethod="Get_PerSancion" 
                            TypeName="sancion">
                            <SelectParameters>
                                <asp:ControlParameter ControlID="tbNumExp" DefaultValue="" 
                                    Name="NroExpe" PropertyName="Text" Type="String" />
                                <asp:ControlParameter ControlID="tbNit" DefaultValue="" Name="Nit" 
                                    PropertyName="Text" Type="String" />
                            </SelectParameters>
                        </asp:ObjectDataSource>
                        <asp:DataList ID="DataList1" runat="server">
                            <HeaderTemplate>
                                <table>
                                    <tr>
                                        <td style="width: 476px; text-align: center">
                                            Aplicar sanción
                                        </td>
                                    </tr>
                                </table>
                            </HeaderTemplate>
                            <HeaderStyle BackColor="Silver" BorderColor="Gray" Font-Bold="True" />
                            <ItemTemplate>
                                <table>
                                    <tbody>
                                        <tr>
                                            <td style="width: 100px">
                                                <asp:Label ID="LbAgrav" runat="server" Text='<%# bind("EXAP_AGRA") %>' 
                                                    Width="25px"></asp:Label>
                                            </td>
                                            <td style="width: 100px">
                                                <asp:Label ID="lbPerGrav" runat="server" Text='<%# bind("EXAP_PGRA") %>' 
                                                    Width="25px"></asp:Label>
                                            </td>
                                            <td style="width: 100px">
                                                <asp:Label ID="lbValDec" runat="server" 
                                                    Text='<%# bind("code_valdec","{0:c}") %>' Width="87px"></asp:Label>
                                            </td>
                                            <td style="width: 100px">
                                                <%--<asp:TextBox ID="txValIngr0" runat="server" 
                                                    Text='<%# bind("Exap_ValIng","{0:c}") %>' Width="87px" Enabled= '<%#IIF(Eval("code_valdec")=0,True,False)%>' ></asp:TextBox>--%>
                                                <ew:numericbox id="txValIngr" runat="server" autoformatcurrency="True" cssclass="TxtNum" Text="$0" 
                                                         decimalsign="," groupingseparator="." Visible='<%#IIF(Eval("code_valdec")=0,True,False)%>'></ew:numericbox>
                                            </td>
                                            
                                        </tr>
                                    </tbody>
                                </table>
                            </ItemTemplate>
                        </asp:DataList>
                        <br />
                        <br />
                        <br />
                        <br />
                        Considerandos<br />
                        <asp:TextBox ID="TxtConsiderandos" runat="server" Height="215px" TextMode="MultiLine" 
                            Width="590px"></asp:TextBox>
                    </asp:View>
                </asp:MultiView>
            </td>
        </tr>
        <tr>
            <td align="center" colspan="3">
                <asp:ImageButton ID="btReasignar" runat="server" 
                ImageUrl="~/images/Operaciones/save.png" />
                <asp:Label ID="lcodTramite" runat="server" CssClass="TitDecl" Visible="False"></asp:Label>
            </td>
        </tr>
    </table> 
    </div> 
            
    <asp:ObjectDataSource ID="odsTramiteSgte" runat="server" SelectMethod="GetTramiteRelacion" 
        TypeName="Expe_Tram" OldValuesParameterFormatString="original_{0}">
            <SelectParameters>
                <asp:ControlParameter ControlID="lcodTramite" Name="tramiteDesde" 
                    PropertyName="Text" Type="String" />
            </SelectParameters>
    </asp:ObjectDataSource>

</asp:Content>

