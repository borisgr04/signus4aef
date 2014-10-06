<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="VerRptDec.aspx.vb" Inherits="Consultas_Declaraciones_VerRptDec" title="Untitled Page" %>
<%@ Register Assembly="Microsoft.ReportViewer.WebForms, Version=10.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a"
    Namespace="Microsoft.Reporting.WebForms" TagPrefix="rsweb" %>
<asp:Content ID="Content1" ContentPlaceHolderID="SampleContent" Runat="Server">
<div class="demoarea">
    <asp:Label ID="MsgResult" runat="server"></asp:Label><br />
    <br />
    <rsweb:ReportViewer ID="ReportViewer1" runat="server" AsyncRendering="False" Font-Names="Verdana"
        Font-Size="8pt" Height="100%" SizeToReportContent="True" Width="800px">
        <LocalReport OnSubreportProcessing="ReportViewer1_SubreportProcessing" ReportPath="">
        </LocalReport>
    </rsweb:ReportViewer>
    &nbsp;</div>
</asp:Content>

