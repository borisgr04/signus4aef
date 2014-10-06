<%@ Page Title="" Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="Vh_Progreso.aspx.vb" Inherits="Declaraciones_Vh_Diligenciar_Vh_Progreso" %>

<asp:Content ID="Content1" ContentPlaceHolderID="SampleContent" Runat="Server">
      <ajaxToolkit:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server" 
      EnablePageMethods="true" AsyncPostBackTimeOut="36000"  >
    </ajaxToolkit:ToolkitScriptManager>
   <script type="text/javascript" language="javascript">
       Sys.WebForms.PageRequestManager.getInstance().add_endRequest(EndRequestHandler);
       function EndRequestHandler(sender, args) {
           if (args.get_error() != undefined) {
               args.set_errorHandled(true);
               location.reload(true);
           }
       }  
    </script>
    <style type="text/css">
	.centrar
	{
		position: absolute;
		/*nos posicionamos en el centro del navegador*/
		top:50%;
		left:50%;
		/*determinamos una anchura*/
		width:500px;
		/*indicamos que el margen izquierdo, es la mitad de la anchura*/
		margin-left:-250px;
		/*determinamos una altura*/
		height:300px;
		/*indicamos que el margen superior, es la mitad de la altura*/
		margin-top:-150px;
		border:1px solid #808080;
		padding:5px;
	}
</style>
<div class="demoarea" style =" height:600px" >
      <asp:UpdatePanel ID="UpdTime" runat="server">
        <ContentTemplate>
            <div style="text-align:center;  " class="centrar">
                <div style=" position:relative; left:0px; top:0px;  border-style:solid; border-color:Black; border-width:thin;text-align:left;">
                <asp:label id="lblBarraProcentaje" runat="server" BackColor="CornflowerBlue" ForeColor="CornflowerBlue"  ></asp:label>
                </div>
                <div style=" position:relative; left:0px; top:-20px; z-index:101; ">
                <asp:label id="LbPorcentaje" runat="server" text="" style="width:500px; text-align:center; "></asp:label><br />
                </div>
                
                <asp:label id="LbEstado" runat="server" text="" style="width:500px; text-align:center; "></asp:label>
                <br />
                <asp:label id="Label1" runat="server" text="" style="width:500px; text-align:center;  font-weight:bold; " >Lote N°:</asp:label>
                <asp:label id="LbNro_LiqG" runat="server" text="" style="width:500px; text-align:center; "></asp:label>
                <br />
                <asp:Label ID="LabelTimer" runat="server" Text="Label"></asp:Label>
                <br />
                <img alt="" src="../../images/Progreso.gif" />
                <br /><br />
                <asp:Button ID="BtnParar" runat="server" Text="Suspender" />
                <br /><br />
                <asp:Label ID="MsgResult" runat="server" Width="70%"></asp:Label>

                    
            </div>
            
            <asp:Timer ID="Timer1" runat="server" Interval="1000"></asp:Timer>

        </ContentTemplate>
    </asp:UpdatePanel>
    </div>
</asp:Content>

