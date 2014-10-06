<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="SubirPlantilla.aspx.vb" Inherits="DatosBasicos_Plantillas_SubirPlantilla" title="Subir Plantillas" %>

<asp:Content ID="Content1" ContentPlaceHolderID="SampleContent" Runat="Server">
<div class="demoarea">
<asp:Label ID="MsgResult" runat="server" Width="90%"></asp:Label>
    <table style="width: 600px;">
        <tr>
            <td style="width:80px">
                &nbsp;</td>
            <td>
                &nbsp;</td>
        </tr>
        <tr class="TbDecl">
            <td colspan="2">
                ACTUALIZAR PLANTILLA PARA DOCUMENTOS DE TRAMITES&nbsp;</td>
        </tr>
        <tr>
            <td style="width:80px">
                &nbsp;</td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td style="width:80px">
                &nbsp;
                Documento
            </td>
            <td>
                <asp:FileUpload ID="FuArchivo" runat="server" />
            </td>
        </tr>
        <tr>
            <td>
                &nbsp; 
                Plantilla</td>
            <td>
                <asp:DropDownList ID="cmbPlantilla" runat="server" Width="250px" 
                    DataSourceID="odsPlantilla" DataTextField="NOM_PLA" DataValueField="IDE_PLA">
                </asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td>
                &nbsp;
            </td>
            <td>
                <asp:Button ID="btSubir" runat="server" Text="Subir" />
            </td>
        </tr>

    </table>
    <asp:ObjectDataSource ID="odsPlantilla" runat="server" SelectMethod="GetRecords" 
        TypeName="Pplantillas" OldValuesParameterFormatString="original_{0}">
    </asp:ObjectDataSource>
</div>
</asp:Content>

