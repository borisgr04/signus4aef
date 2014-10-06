<%@ Page Language="VB" AutoEventWireup="false" CodeFile="upload.aspx.vb" Inherits="MediosM_Declaraciones_upload" title="Untitled Page" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
    <title>Modal Dialog Progress</title>
    <style type="text/css">
        .modalBackground
        {
            background-color:#e6e6e6;
            filter:alpha(opacity=60);
            opacity:0.60;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <asp:ScriptManager ID="ScriptManager1" runat="server" EnablePageMethods="true">
        </asp:ScriptManager>
        <fieldset>
            <legend>UpdatePanel</legend>
            <div>
                <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                    <ContentTemplate>
                        <asp:Label ID="lblDate1" runat="server"></asp:Label>
                        <asp:Button ID="btnDate1" runat="server" Text="Get Date" OnClick="btnDate1_Click" />
                    </ContentTemplate>
                </asp:UpdatePanel>
            </div>
        </fieldset>
        <fieldset>
            <legend>PageMethods</legend>
            <div>
                <asp:Label ID="lblDate2" runat="server"></asp:Label>
                <asp:Button ID="btnDate2" runat="server" Text="Get Date" OnClientClick="return btnDate2_Click()" />
            </div>
        </fieldset>
        <asp:Panel ID="pnlProgress" runat="server" style="background-color:#ffffff;display:none;width:400px">
            <div style="padding:8px">
                <table border="0" cellpadding="2" cellspacing="0" style="width:100%">
                    <tbody>
                        <tr>
                            <td style="width:50%"></td>
                            <td style="text-align:right">
                                <img alt="" src="../../images/loading2.gif" />
                            </td>
                            <td style="text-align:left;white-space:nowrap">
                                <span style="font-size:larger">Loading, Please wait ...</span>
                            </td>
                            <td style="width:50%"></td>
                        </tr>
                    </tbody>
                </table>
            </div>
        </asp:Panel>
        <ajaxToolKit:ModalPopupExtender ID="mpeProgress" runat="server" TargetControlID="pnlProgress" PopupControlID="pnlProgress" BackgroundCssClass="modalBackground" DropShadow="true" />
    </form>
    <script type="text/javascript">

        Sys.Net.WebRequestManager.add_invokingRequest(onInvoke);
        Sys.Net.WebRequestManager.add_completedRequest(onComplete);

        function onInvoke(sender, args)
        {
            $find('<%= mpeProgress.ClientID %>').show();
        }

        function onComplete(sender, args)
        {
            $find('<%= mpeProgress.ClientID %>').hide();
        }

        function btnDate2_Click()
        {
            PageMethods.GetDate (
                                    function(result)
                                    {
                                        var lbl = $get('<%= lblDate2.ClientID %>');

                                        if (document.all)
                                        {
                                            lbl.innerText = result;
                                        }
                                        else
                                        {
                                            lbl.textContent = result;
                                        }
                                    }
                                );

            return false;
        }

        function pageUnload()
        {
            Sys.Net.WebRequestManager.remove_invokingRequest(onInvoke);
            Sys.Net.WebRequestManager.remove_completedRequest(onComplete);
        }

    </script>
</body>
</html>
