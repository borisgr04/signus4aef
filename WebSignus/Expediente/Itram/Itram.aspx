<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="Itram.aspx.vb" Inherits="Expediente_Itram_Itram" title="Imprimir Documentos" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="SampleContent" Runat="Server">
    <asp:ScriptManager ID="ScriptManager1" runat="server" AsyncPostBackTimeout="600">
    </asp:ScriptManager>
<div class="demoarea">
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
    <ContentTemplate>
     <asp:Label ID="MsgResult" runat="server" Width="90%"></asp:Label>
        <table style="width:700px;">
        <tr>
            <td colspan="5">
                &nbsp;</td>
        </tr>
            <tr class="TbDecl">
                <td colspan="5">
                    <asp:Label ID="Label10" runat="server" Font-Bold="True" 
                        Text="IMPRIMIR DOCUMENTOS"></asp:Label>
                </td>
            </tr>
        <tr>
            <td colspan="5">
           
            </td>
        </tr>
        <tr>
            <td style="width:100px">
                Expediente</td>
            <td colspan="3">
                <asp:TextBox ID="tbNumExp" Enabled="false" runat="server"></asp:TextBox>
            </td>
            <td style="width:100px">
                        <asp:LinkButton ID="LinkButton1" runat="server">Volver</asp:LinkButton>
                                                </td>
        </tr>
        <tr>
            <td style="width:100px">
                <asp:Label ID="Label11" runat="server" Text="Razon Social"></asp:Label>
            </td>
            <td colspan="4">
                <asp:TextBox ID="lAgente" runat="server" Enabled="False" ReadOnly="True" 
                Width="350px"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td style="width:100px">
                <asp:Label ID="Label53" runat="server" Text="Impuesto"></asp:Label>
            </td>
            <td colspan="3">
                <asp:TextBox ID="tbImpuesto" runat="server" Enabled="False" style="width:220px"></asp:TextBox>
            </td>
            <td style="width:100px">
                <asp:Label ID="lExpeTramID" runat="server" CssClass="TitDecl" Visible="False"></asp:Label>
            </td>
        </tr>
        <tr>
            <td style="width:100px">
                <asp:Label ID="Label54" runat="server" Text="Tramite Actual"></asp:Label>
            </td>
            <td colspan="3">
                <asp:TextBox ID="lTramite" runat="server" Enabled="False" ReadOnly="True" 
                Text="" Width="450px"></asp:TextBox>
            </td>
            <td style="width:100px">
                <asp:Label ID="lcodTramite" runat="server" CssClass="TitDecl" Visible="False"></asp:Label>
            </td>
        </tr>
        <tr>
            <td style="width:100px">
                <asp:Label ID="Label55" runat="server" Text="Plantillas"></asp:Label>
            </td>
            <td colspan="3">
                <asp:DropDownList ID="cmbPlantillas" runat="server" DataSourceID="odsPlantilla" 
                    DataTextField="NOM_PLA" DataValueField="IDE_PLA" Width="400px">
                </asp:DropDownList>
            </td>
            <td style="width:100px">
                &nbsp;</td>
        </tr>
            <tr>
                <td style="width:100px">
                    Formato&nbsp;</td>
                <td colspan="3">
                    <asp:DropDownList ID="cmbFormato" runat="server">
                        <asp:ListItem Value=".pdf">PDF</asp:ListItem>
                        <asp:ListItem Value=".doc">Word</asp:ListItem>
                    </asp:DropDownList>
                </td>
                <td style="width:100px">
                    <asp:Label ID="lcodImpuesto" runat="server" CssClass="TitDecl" Visible="False"></asp:Label>
                </td>
            </tr>
            <tr>
                <td style="width:100px">
                    Informacion Adicional</td>
                <td colspan="4">
                    <asp:TextBox ID="tbObservacion" runat="server" TextMode="MultiLine" 
                        Width="550px"></asp:TextBox>
                </td>
            </tr>
        <tr>
            <td align="center">
                &nbsp;</td>
            <td align="center">
                <asp:ImageButton ID="btImprimir" runat="server" 
                    ImageUrl="~/images/Operaciones/word.png" />
            </td>
            <td align="center">
                <asp:ImageButton ID="btRImprimir" runat="server" 
                    ImageUrl="~/images/Operaciones/redo-icon.png" />
            </td>
            <td align="center">
                <asp:ImageButton ID="btAnular" runat="server" 
                    ImageUrl="~/images/Operaciones/delete2.png" />
            </td>
            <td style="width:100px">
                &nbsp;</td>
        </tr>
        <tr>
            <td align="center">
                &nbsp;</td>
            <td align="center">
                Descargar Documento</td>
            <td align="center">
                Regenerar Documentos</td>
            <td align="center">
                Anular Documento</td>
            <td style="width:100px">
                &nbsp;</td>
        </tr>
    </table>
        <asp:HiddenField ID="hfGenerar" runat="server" />
        <asp:HiddenField ID="hfNit" runat="server" />
        <asp:ConfirmButtonExtender ID="cbe" runat="server"
        TargetControlID="btAnular"
        ConfirmText="Esta seguro de Anular el Documento generado?"
        />
    </ContentTemplate>
        <Triggers>
            <asp:PostBackTrigger ControlID="btRImprimir" />
        </Triggers>
    </asp:UpdatePanel>
    <asp:ObjectDataSource ID="odsPlantilla" runat="server" SelectMethod="GetPorTramiteImpuesto" 
        TypeName="PPLANTILLAS" OldValuesParameterFormatString="original_{0}">
        <SelectParameters>
            <asp:ControlParameter ControlID="lcodTramite" Name="TRAM_CODI" 
                PropertyName="Text" Type="String" />
            <asp:ControlParameter ControlID="lcodImpuesto" Name="PLAN_CDEC" 
                PropertyName="Text" Type="String" />
        </SelectParameters>
    </asp:ObjectDataSource> 
    <asp:UpdateProgress ID="UpdateProgress1" runat="server" AssociatedUpdatePanelID="UpdatePanel1">
      <ProgressTemplate>
            <div class="Loading">
                <img alt="" src="../../images/loading.gif" title="" />
                  Generando Documento …
             </div>
       </ProgressTemplate>
    </asp:UpdateProgress>    
</div>
</asp:Content>

