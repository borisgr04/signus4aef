<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="m.aspx.vb" Inherits="Report_ImgD_m" title="Untitled Page" %>

<%@ Register Assembly="Microsoft.ReportViewer.WebForms, Version=10.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a"
    Namespace="Microsoft.Reporting.WebForms" TagPrefix="rsweb" %>
<asp:Content ID="Content1" ContentPlaceHolderID="SampleContent" Runat="Server">
    &nbsp;&nbsp;<rsweb:ReportViewer ID="ReportViewer1" runat="server" Font-Names="Verdana"
        Font-Size="8pt" Height="400px" Width="738px">
        <LocalReport ReportPath="Report\ImgD\Matrix.rdlc">
            <DataSources>
                <rsweb:ReportDataSource DataSourceId="ObjectDataSource1" Name="DsTer_TERCEROS" />
            </DataSources>
        </LocalReport>
    </rsweb:ReportViewer>
    <asp:ObjectDataSource ID="ObjectDataSource1" runat="server" SelectMethod="GetData"
        TypeName="DsTerTableAdapters.TERCEROSTableAdapter"></asp:ObjectDataSource>
    <br />
    <br />
    <rsweb:ReportViewer ID="ReportViewer2" runat="server" Font-Names="Verdana" Font-Size="8pt"
        Height="400px" Width="400px">
        <LocalReport ReportPath="Report\ImgD\Matrix2.rdlc">
            <DataSources>
                <rsweb:ReportDataSource DataSourceId="ObjectDataSource1" Name="DsTer_TERCEROS" />
                <rsweb:ReportDataSource DataSourceId="ObjectDataSource2" Name="DsDecl_VDECLARACION" />
            </DataSources>
        </LocalReport>
    </rsweb:ReportViewer>
    <asp:ObjectDataSource ID="ObjectDataSource2" runat="server" SelectMethod="GetData"
        TypeName="DsDeclTableAdapters.VDECLARACIONTableAdapter"></asp:ObjectDataSource>
    &nbsp;
</asp:Content>

