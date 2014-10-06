<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="CrearPerfil.aspx.vb" Inherits="Seguridad_Perfiles_crearPerfil" title="Untitled Page" %>
<asp:Content ID="Content1" ContentPlaceHolderID="SampleContent" Runat="Server">

<div class="demoarea">
    &nbsp;<ajaxToolkit:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server">
    </ajaxToolkit:ToolkitScriptManager>
    <asp:UpdatePanel id="UpdatePanel1" runat="server" UpdateMode="Conditional">
        <contenttemplate>
&nbsp;<asp:HyperLink id="HyperLink1" runat="server" NavigateUrl="~/Seguridad/Perfiles/ModPerfil.aspx" __designer:wfdid="w17">Administrar Perfiles</asp:HyperLink>&nbsp; <TABLE style="WIDTH: 600px"><TBODY><TR><TD class="Titulos" colSpan=2><asp:Label id="msgResult" runat="server" Width="90%" Visible="False" Text="Label" Height="30px"></asp:Label></TD></TR><TR><TD class="Titulos" colSpan=2>REGISTRO DE PERFIL</TD></TR><TR><TD colSpan=2></TD></TR><TR><TD style="TEXT-ALIGN: left" colSpan=2><asp:TreeView id="Tvw" runat="server" ShowCheckBoxes="Root" ShowLines="True"></asp:TreeView></TD></TR><TR><TD style="WIDTH: 100px"><asp:TextBox id="TxtNomPer" runat="server"></asp:TextBox></TD><TD style="WIDTH: 100px"><asp:Button id="BtnAgregar" onclick="BtnAgregar_Click" runat="server" Text="Agregar"></asp:Button> </TD></TR><TR><TD style="WIDTH: 100px"></TD><TD style="WIDTH: 100px"></TD></TR></TBODY></TABLE>
</contenttemplate>
        <triggers>
<asp:AsyncPostBackTrigger ControlID="BtnAgregar" EventName="Click"></asp:AsyncPostBackTrigger>
</triggers>
    </asp:UpdatePanel>&nbsp;&nbsp;<br />
    <asp:UpdateProgress id="UpdateProgress1" runat="server" AssociatedUpdatePanelID="UpdatePanel1">
        <progresstemplate>
                <div class="Loading">
                    <img alt="" src="../../images/loading.gif" title="" />
                    Cargando …
                </div>
            </progresstemplate>
    </asp:UpdateProgress>
    <br />
    </div>
</asp:Content>

