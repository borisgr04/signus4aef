<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="Itram.aspx.vb" Inherits="Procesos_Lote_Itram" title="Imprimir por Proceso" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="SampleContent" Runat="Server">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
<div class="demoarea">
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
    <ContentTemplate>
        <asp:Label ID="MsgResult" runat="server" Width="90%"></asp:Label>
        <table style="width:500px;">
        <tr>
            <td colspan="3">
                &nbsp;</td>
        </tr>
            <tr>
                <td colspan="3">
                    &nbsp;</td>
            </tr>
            <tr class="TbDecl">
                <td colspan="3">
                    IMPRIMIR DOCUMENTOS&nbsp;</td>
            </tr>
        <tr>
            <td style="width:100px">
                Proceso No.</td>
            <td>
                <asp:TextBox ID="tbNumProc" runat="server"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
                    ControlToValidate="tbNumProc" ErrorMessage="*"></asp:RequiredFieldValidator>
                <asp:ImageButton ID="btBuscar" runat="server" 
                    ImageUrl="~/images/Operaciones/Search.png" CausesValidation="False" />
            </td>
            <td style="width:100px">
                        <asp:LinkButton ID="LinkButton1" runat="server" 
                            PostBackUrl="~/Procesos/Lote/Iproceso.aspx" CausesValidation="False">Volver</asp:LinkButton>
                                                </td>
        </tr>
        <tr>
            <td style="width:100px">
                <asp:Label ID="Label53" runat="server" Text="Impuesto"></asp:Label>
            </td>
            <td>
                <asp:TextBox ID="tbImpuesto" runat="server" Enabled="False" style="width:220px"></asp:TextBox>
            </td>
            <td style="width:100px">
                
                <asp:Label ID="lcodImpuesto" runat="server" CssClass="TitDecl" Visible="False"></asp:Label>
                
            </td>
        </tr>
        <tr>
            <td style="width:100px">
                <asp:Label ID="Label54" runat="server" Text="Tramite"></asp:Label>
            </td>
            <td>
                <asp:DropDownList ID="cmbTramite" runat="server" DataSourceID="odsTramite" 
                    DataTextField="TRAM_NOMB" DataValueField="PRLT_TRAM" Width="200px" 
                    AutoPostBack="True">
                </asp:DropDownList>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" 
                    ControlToValidate="tbImpuesto" ErrorMessage="*"></asp:RequiredFieldValidator>
            </td>
            <td style="width:100px">
                &nbsp;</td>
        </tr>
        <tr>
            <td style="width:100px">
                <asp:Label ID="Label55" runat="server" Text="Plantillas"></asp:Label>
            </td>
            <td>
                <asp:DropDownList ID="cmbPlantillas" runat="server" DataSourceID="odsPlantilla" 
                    DataTextField="NOM_PLA" DataValueField="IDE_PLA" Width="200px">
                </asp:DropDownList>
            </td>
            <td style="width:100px">
                &nbsp;</td>
        </tr>
            <tr>
                <td style="width:100px">
                    Formato</td>
                <td>
                    <asp:DropDownList ID="cmbFormato" runat="server">
                        <asp:ListItem Value=".pdf">PDF</asp:ListItem>
                        <asp:ListItem Value=".doc">Word</asp:ListItem>
                    </asp:DropDownList>
                </td>
                <td style="width:100px">
                    &nbsp;</td>
            </tr>
    </table>
    <asp:HiddenField ID="hfGenerar" runat="server" />
        <asp:Panel ID="pCtrlUsuario1" runat="server">
       <table style="width:479px;">
        <tr>
            <td align="center" style="width:50px;">
                &nbsp;</td>
            <td align="center" style="width:150px;">
                <asp:ImageButton ID="btAnular" runat="server" 
                    ImageUrl="~/images/Operaciones/delete2.png" />
            </td>
            <td align="center" style="width:210px;">
                <asp:ImageButton ID="btImprimir" runat="server" 
                    ImageUrl="~/images/Operaciones/word.png" />
            </td>
            <td  align="center" style="width:150px;">
                <asp:ImageButton ID="btRegenDoc" runat="server" 
                    ImageUrl="~/images/Operaciones/redo-icon.png" />
            </td>
        </tr>
        <tr>
            <td align="center">
                &nbsp;</td>
            <td align="center">
                Anular Documento</td>
            <td align="center" style="width: 210px">
                Descargar Documento</td>
            <td style="width:145px">
                Regenerar Documento</td>
        </tr>
    </table>   
    </asp:Panel> 
    <asp:ConfirmButtonExtender ID="cbe" runat="server"
        TargetControlID="btAnular"
        ConfirmText="Esta seguro de Anular el Documento generado?"
        />
    </ContentTemplate>
    </asp:UpdatePanel>
        
    <asp:ObjectDataSource ID="odsPlantilla" runat="server" SelectMethod="GetPorTramiteImpuesto" 
        TypeName="PPLANTILLAS" OldValuesParameterFormatString="original_{0}">
        <SelectParameters>
            <asp:ControlParameter ControlID="cmbTramite" Name="TRAM_CODI" 
                PropertyName="SelectedValue" Type="String" />
            <asp:ControlParameter ControlID="lcodImpuesto" Name="PLAN_CDEC" 
                PropertyName="Text" Type="String" />
        </SelectParameters>
    </asp:ObjectDataSource> 
    <asp:ObjectDataSource ID="odsTramite" runat="server" SelectMethod="GetPorNumero" 
        TypeName="Proc_Lote" OldValuesParameterFormatString="original_{0}">
        <SelectParameters>
            <asp:ControlParameter ControlID="tbNumProc" Name="PRLT_NUM" 
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

