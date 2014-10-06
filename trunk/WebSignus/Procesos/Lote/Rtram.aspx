<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="Rtram.aspx.vb" Inherits="Procesos_Lote_Rtram" title="Reasignar Tramite por Lote" %>
<asp:Content ID="Content1" ContentPlaceHolderID="SampleContent" Runat="Server">
   <div class="demoarea">
   <asp:Label ID="MsgResult" runat="server" Width="90%"></asp:Label>
    <table style="width: 560px;">
        <tr>
            <td colspan="3" style="text-align:right">
                 &nbsp;</td>
        </tr>
        <tr>
            <td colspan="3" style="text-align:right">
                 <asp:HyperLink ID="HyperLink1" runat="server" 
                     NavigateUrl="~/Procesos/Lote/Iproceso.aspx">Volver</asp:HyperLink>
            </td>
        </tr>
        <tr class="TbDecl">
            <td colspan="3">
                PASAR A SIGUIENTE TRAMITE
            </td>
        </tr>
        <tr>
            <td colspan="3">
                 
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="Label52" runat="server" Text="No. Proceso"></asp:Label>
            </td>
            <td>
                <asp:TextBox ID="tbNumProc" runat="server" style="width:100px"></asp:TextBox>
                   <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" 
                    ControlToValidate="tbNumProc" ErrorMessage="*"></asp:RequiredFieldValidator>
                   <asp:ImageButton ID="btBuscar" runat="server" 
                       ImageUrl="~/images/Operaciones/Search.png" CausesValidation="False" />
            </td>
            <td>
                <asp:Label ID="lcodTramite" runat="server" CssClass="TitDecl" Visible="False"></asp:Label>
            </td>
        </tr>
        <tr>
            <td >
                <asp:Label ID="Label54" runat="server" Text="Fecha"></asp:Label>
            </td>
            <td>
                        <asp:TextBox ID="tbFechaExp" runat="server" style="width:100px" ReadOnly="True" 
                            ForeColor="#000066"></asp:TextBox>
            </td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="Label53" runat="server" Text="Impuesto"></asp:Label>
            </td>
            <td>
                <asp:TextBox ID="tbImpuesto" runat="server" style="width:220px"></asp:TextBox>
            </td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="Label1" runat="server" Text="Tramite Actual"></asp:Label>
            </td>
            <td>
                <asp:TextBox ID="lTramite" runat="server" ReadOnly="True" Text="" Width="220px"></asp:TextBox>
            </td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="Label51" runat="server" Text="Tramite Siguiente"></asp:Label>
            </td>
            <td>
                <asp:DropDownList ID="cmbTramiteSgte" runat="server" Width="220px" 
                            DataSourceID="odsTramiteSgte" DataTextField="TRAM_PARA" 
                            DataValueField="TRRE_PARA">
                        </asp:DropDownList>
              
                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" 
                    ControlToValidate="cmbTramiteSgte" ErrorMessage="*"></asp:RequiredFieldValidator>
              
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
                    ErrorMessage="*" ControlToValidate="tbConsecutivo"></asp:RequiredFieldValidator>
            </td>
            <td>
                &nbsp;</td>
        </tr>
        </table>
    <asp:Panel ID="pCtrlUsuario1" runat="server">
        <table style="width: 560px;">
           <tr>
               <td>
                   &nbsp;
                   </td>
               <td>
                <asp:ImageButton ID="btReasignar" runat="server" 
                ImageUrl="~/images/Operaciones/save.png" />
               </td>
               <td>
                   <asp:ImageButton ID="btDescargar" runat="server" 
                       ImageUrl="~/images/Operaciones/word.png" />
               </td>
               <td>
                   &nbsp;
               </td>
               <td>
                   &nbsp;
               </td>
           </tr>
           <tr>
               <td>
                   &nbsp;</td>
               <td>
                   Guardar</td>
               <td>
                   Descargar</td>
               <td>
                   &nbsp;</td>
               <td>
                   &nbsp;</td>
           </tr>
           </table>
    </asp:Panel>     
    </div> 
            
    <asp:ObjectDataSource ID="odsTramiteSgte" runat="server" SelectMethod="GetTramiteRelacion" 
        TypeName="Expe_Tram" OldValuesParameterFormatString="original_{0}">
            <SelectParameters>
                <asp:ControlParameter ControlID="lcodTramite" Name="tramiteDesde" 
                    PropertyName="Text" Type="String" />
            </SelectParameters>
    </asp:ObjectDataSource>
</asp:Content>

