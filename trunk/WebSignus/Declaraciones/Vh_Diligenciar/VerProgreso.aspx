<%@ Page Language="VB" AutoEventWireup="false" CodeFile="VerProgreso.aspx.vb" Inherits="Declaraciones_Vh_Diligenciar_VerProgreso" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
   
</head>
<body>

    <form id="form1" runat="server">
    <div>
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

      <asp:UpdatePanel ID="UpdTime" runat="server">
        <ContentTemplate>
            <%--<DIV class="LoadingLiq">--%>
            <asp:Label ID="LabeltIMER" runat="server" Text="Label"></asp:Label>
            <%--</DIV>--%>
            <asp:Timer ID="Timer1" runat="server" Interval="1000">
            </asp:Timer>
            <asp:Label ID="MsgResult" runat="server" Width="100%"></asp:Label>
            <br />
            <asp:Button ID="BtnParar" runat="server" Text="Parar" />
        </ContentTemplate>
    </asp:UpdatePanel>
    </div>
    </form>
</body>
</html>
