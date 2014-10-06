<%@ Control Language="VB" AutoEventWireup="false" CodeFile="Anu_Expediente.ascx.vb" Inherits="CtrlUsr_Expedientes_Anu_Expediente" %>
<div style="padding: 10px; margin: 10px">
<asp:UpdatePanel ID="UpdatePanel1" runat="server">
<ContentTemplate>
    &nbsp;&nbsp;<asp:Label ID="MsgResult" runat="server" SkinID="MsgResult" Width="85%"></asp:Label>
    <table style="width: 430px;">
        <tr>
            <td style="width:130px">
                &nbsp;</td>
            <td style="width:150px">
                &nbsp;</td>
            <td style="width:150px">
                &nbsp;</td>
        </tr>
        <tr>
            <td style="width:130px">
                Fecha Anulación</td>
            <td style="width:150px">
                <asp:TextBox ID="tbFecha" runat="server"></asp:TextBox>
            </td>
            <td style="width:150px">
                &nbsp;
            </td>
        </tr>
        <tr>
            <td>
                Observación</td>
            <td colspan="2">
                <asp:TextBox ID="tbObservacion" runat="server" TextMode="MultiLine" 
                    Width="100%"></asp:TextBox>
                &nbsp;
            </td>
        </tr>
        <tr>
            <td>
                &nbsp;
            </td>
            <td>
                &nbsp;
                <asp:ImageButton ID="btGuardar" runat="server" 
                    ImageUrl="~/images/Operaciones/save.png" />
            </td>
            <td>
                &nbsp;
            </td>
        </tr>
    </table>
    <asp:HiddenField ID="HFNumExpe" runat="server" />   
    <asp:HiddenField ID="HFID" runat="server" />
    <asp:HiddenField ID="HFPeriodo" runat="server" />
    <asp:HiddenField ID="HFVigencia" runat="server" />
    <asp:HiddenField ID="HFTabla" runat="server" />
    <ajaxToolkit:CalendarExtender 
       ID="cFecha" runat="server" TargetControlID="tbFecha" 
       Format="dd/MM/yyyy" >
    </ajaxToolkit:CalendarExtender>
</ContentTemplate>    
</asp:UpdatePanel>
</div> 
