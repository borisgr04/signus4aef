<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false"
    CodeFile="AsigCDec.aspx.vb" Inherits="DatosBasicos_AsigCDec_AsigCDec" Title="Asignación de Declaraciones a Agente Recaudador" %>

<%@ Register Src="../../CtrlUsr/Terceros/ConsultaTer.ascx" TagName="ConsultaTer"
    TagPrefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="SampleContent" runat="Server">
    <script type='text/javascript'>
  
  // Add click handlers for buttons to show and hide modal popup on pageLoad
       


   

    function cancelClick() {
        var label = $get('ctl00_SampleContent_LbRpt');
        label.innerHTML = 'You hit cancel in the Confirm dialog on ' + (new Date()).localeFormat("T") + '.';
    }
        // Add click handlers for buttons to show and hide modal popup on pageLoad

        
     
        
         function enviar(tdoc,ced,dv,rsocial,tip_ter)
        {
           if(tip_ter=='AR'){
              document.aspnetForm.<%=Me.Nit.ClientID%>.value=ced;
              document.aspnetForm.<%=Me.Agente.ClientID%>.value=rsocial;
              document.aspnetForm.<%=Me.dv.ClientID%>.value=dv;
              __doPostBack("<%= button2.ClientID %>","");
           }
          
           var modalPopupBehavior = $find('programmaticModalPopupBehavior');
           modalPopupBehavior.hide();
          
         }

    </script>
    <div class="demoarea">
        <ajaxToolkit:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server" EnablePageMethods="true"
            EnableScriptGlobalization="True" EnableScriptLocalization="True">
        </ajaxToolkit:ToolkitScriptManager>
        <asp:Label ID="Tit" runat="server" CssClass="Titulo" Text="Asignación de Declaraciones a Agentes Recaudadores"></asp:Label><p>
            &nbsp;<asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional">
                <ContentTemplate>
                    &nbsp;
                    <asp:Label ID="MsgResult" runat="server" Width="60px" Height="4px" ></asp:Label>&nbsp;<br />
                    &nbsp; &nbsp;&nbsp; &nbsp;
                    <table style="width: 30%; height: 50px">
                        <tbody>
                            <tr onmouseover="Resaltar_On(this);" onmouseout="Resaltar_Off(this);">
                                <td style="height: 20px" colspan="16">
                                    <asp:Label ID="Label10" runat="server" Font-Bold="True" 
                                        Text="AGENTE RECAUDADOR" ></asp:Label>
                                    &nbsp;
                                </td>
                            </tr>
                            <tr onmouseover="Resaltar_On(this);" onmouseout="Resaltar_Off(this);">
                                <td style="width: 90px; height: 22px">
                                    &nbsp;
                                    <asp:Label ID="Label26" runat="server" Width="103px" Height="15px" Font-Bold="True"
                                        Text="NIT" CssClass="TitDecl" ></asp:Label>
                                </td>
                                <td style="width: 34px; height: 22px; text-align: left">
                                    <asp:Label ID="Label25" runat="server" Width="45px" Font-Bold="True" Text="DV" CssClass="TitDecl"
                                        >
                                    </asp:Label>
                                </td>
                                <td style="width: 34px; height: 22px; text-align: left">
                                </td>
                                <td style="width: 65px; height: 22px" colspan="12">
                                    &nbsp;
                                    <asp:Label ID="Label20" runat="server" Width="198px" Font-Bold="True" Text="RAZON SOCIAL"
                                        CssClass="TitDecl" ></asp:Label>
                                </td>
                                <td style="width: 3px; height: 22px" colspan="1">
                                </td>
                            </tr>
                            <tr onmouseover="Resaltar_On(this);" onmouseout="Resaltar_Off(this);">
                                <td style="width: 110px; height: 11px; text-align: right">
                                    <asp:TextBox ID="Nit" runat="server" Width="90px" Height="13px" ></asp:TextBox>&nbsp;
                                </td>
                                <td style="width: 34px; height: 11px">
                                    -<asp:TextBox ID="DV" runat="server" Width="20px" Height="13px"
                                        Enabled="False"></asp:TextBox>
                                </td>
                                <td style="width: 34px; height: 11px">
                                    <asp:LinkButton ID="BtnTipUs" OnClick="BtnTipUs_Click" runat="server" 
                                        > ...</asp:LinkButton>
                                </td>
                                <td style="width: 65px; height: 11px" colspan="12">
                                    <asp:TextBox ID="Agente" runat="server" Width="200px" Height="13px" 
                                        Enabled="False"></asp:TextBox>
                                </td>
                                <td style="width: 3px; height: 11px" colspan="1">
                                    <asp:RadioButton ID="RdNit" runat="server" Width="58px" 
                                        GroupName="Opcion"></asp:RadioButton>
                                </td>
                            </tr>
                            <tr onmouseover="Resaltar_On(this);" onmouseout="Resaltar_Off(this);">
                                <td style="width: 90px; height: 11px; text-align: left">
                                    <asp:Label ID="Label1" runat="server" Width="100px" Font-Bold="True" Text="TIPO DE AGENTE"
                                        CssClass="TitDecl" ></asp:Label>
                                </td>
                                <td style="height: 11px" colspan="14">
                                    <asp:DropDownList ID="CbTTcer" runat="server" Width="255px" 
                                        DataValueField="TAG_COD" DataTextField="TAG_NOM" DataSourceID="ObjTTer">
                                    </asp:DropDownList>
                                </td>
                                <td style="width: 3px; height: 11px" colspan="1">
                                    <asp:RadioButton ID="RDtAg" runat="server" Width="60px"  GroupName="Opcion">
                                    </asp:RadioButton>
                                </td>
                            </tr>
                            <tr onmouseover="Resaltar_On(this);" onmouseout="Resaltar_Off(this);">
                                <td style="height: 20px" colspan="15">
                                    &nbsp;
                                    <asp:Button Style="display: none" ID="Button2" OnClick="Button2_Click" runat="server"
                                        Width="48px" Text="Button" ></asp:Button>
                                </td>
                                <td style="width: 3px; height: 20px" colspan="1">
                                    <asp:Button ID="Button1" runat="server" Text="Guardar"></asp:Button>
                                </td>
                            </tr>
                            <tr onmouseover="Resaltar_On(this);" onmouseout="Resaltar_Off(this);">
                                <td style="height: 20px" colspan="15">
                                    &nbsp;
                                </td>
                                <td style="width: 3px; height: 20px" colspan="1">
                                </td>
                            </tr>
                        </tbody>
                    </table>
                    <asp:ObjectDataSource ID="ObjTTer" runat="server"  OldValuesParameterFormatString="original_{0}"
                        SelectMethod="GetRecords" TypeName="TTerc"></asp:ObjectDataSource>
                    <asp:DataList ID="DataList1" runat="server" 
                        DataSourceID="ObjClaseDec" OnItemDataBound="DataList1_ItemDataBound">
                        <HeaderTemplate>
                            <table>
                                <tr>
                                    <td style="width: 476px; text-align: center">
                                        CLASE DE DECLARACION
                                    </td>
                                </tr>
                            </table>
                        </HeaderTemplate>
                        <HeaderStyle BackColor="Silver" BorderColor="Gray" Font-Bold="True"></HeaderStyle>
                        <ItemTemplate>
                            <table>
                                <tbody>
                                    <tr>
                                        <td style="width: 100px">
                                            <asp:Label ID="Asg_Cod" runat="server" Width="51px" Text='<%# bind("CLD_COD") %>'></asp:Label>
                                        </td>
                                        <td style="width: 100px">
                                            <asp:Label ID="Asg_Nom" runat="server" Width="219px" Text='<%# bind("CLD_NOM") %>'></asp:Label>
                                        </td>
                                        <td style="width: 100px">
                                            <asp:TextBox ID="Asg_FecIni" Width="87px" runat="server" Text='<%# bind("TEDE_FINI", "{0:d}") %>'></asp:TextBox>
                                            <ajaxToolkit:CalendarExtender ID="CalendarExtender1" runat="server" TargetControlID="Asg_FecIni"
                                                Format="dd/MM/yyyy">
                                            </ajaxToolkit:CalendarExtender>
                                        </td>
                                        <td style="width: 100px">
                                            <asp:TextBox ID="Asg_FecFin" Width="87px" runat="server" Text='<%# bind("TEDE_FFIN", "{0:d}") %>'></asp:TextBox>
                                            <ajaxToolkit:CalendarExtender ID="CalendarExtender2" runat="server" TargetControlID="Asg_FecFin"
                                                Format="dd/MM/yyyy">
                                            </ajaxToolkit:CalendarExtender>
                                        </td>
                                        <td style="width: 100px" >
                                            <asp:CheckBox ID="ASg_est" runat="server" Width="77px" 
                                                ></asp:CheckBox>
                                        </td>
                                    </tr>
                                </tbody>
                            </table>
                        </ItemTemplate>
                    </asp:DataList>
                    <asp:ObjectDataSource ID="ObjClaseDec" runat="server"
                        OldValuesParameterFormatString="original_{0}" SelectMethod="COnsultarAsig"
                        TypeName="AsigCDec">
                        <SelectParameters>
                            <asp:ControlParameter ControlID="Nit" PropertyName="Text" Name="TEDE_TNIT" Type="String">
                            </asp:ControlParameter>
                        </SelectParameters>
                    </asp:ObjectDataSource>
                </ContentTemplate>
                <Triggers>
                    <asp:AsyncPostBackTrigger ControlID="BtnTipUs" EventName="Click"></asp:AsyncPostBackTrigger>
                    <asp:AsyncPostBackTrigger ControlID="Button2" EventName="Click"></asp:AsyncPostBackTrigger>
                </Triggers>
            </asp:UpdatePanel>
            &nbsp; &nbsp;&nbsp;
        </p>
        <p>
            &nbsp;&nbsp;</p>
        <p>
            &nbsp;</p>
        <p>
            &nbsp; &nbsp; &nbsp; &nbsp;&nbsp; &nbsp; &nbsp;&nbsp;&nbsp; &nbsp; &nbsp; &nbsp;
            &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp; &nbsp; &nbsp;
            &nbsp; &nbsp; &nbsp;&nbsp;&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
            &nbsp; &nbsp;
            <asp:UpdatePanel ID="UpdatePanel4" runat="server" UpdateMode="Conditional">
                <ContentTemplate>
                    <!-- Mensaje de Salida-->
                    <asp:Button Style="display: none" ID="hiddenTargetControlForModalPopup" runat="server">
                    </asp:Button>
                    <ajaxToolkit:ModalPopupExtender ID="ModalPopup" runat="server" TargetControlID="hiddenTargetControlForModalPopup"
                        RepositionMode="RepositionOnWindowScroll" PopupDragHandleControlID="programmaticPopupDragHandle"
                        PopupControlID="programmaticPopup" DropShadow="True" BehaviorID="programmaticModalPopupBehavior"
                        BackgroundCssClass="modalBackground">
                    </ajaxToolkit:ModalPopupExtender>
                    &nbsp;
                    <asp:Panel ID="programmaticPopup" runat="server" Width="625px" Height="229%" CssClass="ModalPanel2">
                        <asp:Panel ID="programmaticPopupDragHandle" runat="Server" Height="30px" CssClass="BarTitleModal2">
                            <div style="padding-right: 5px; padding-left: 5px; padding-bottom: 5px; vertical-align: middle;
                                padding-top: 5px">
                                <div style="float: left">
                                    Buscar Agente Recaudador
                                </div>
                                <div style="float: right">
                                    <input id="hideModalPopupViaClientButton" type="button" value="X" /></div>
                            </div>
                        </asp:Panel>
                        &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;<br />
                        &nbsp; &nbsp; &nbsp;&nbsp;
                        <uc1:ConsultaTer ID="ConsultaTer" runat="server" Ret="AR" Tipo="AR"></uc1:ConsultaTer>
                        <br />
                        <br />
                        <br />
                    </asp:Panel>
                </ContentTemplate>
                <Triggers>
                    <asp:AsyncPostBackTrigger ControlID="BtnTipUs" EventName="Click"></asp:AsyncPostBackTrigger>
                </Triggers>
            </asp:UpdatePanel>
            &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;&nbsp;<br />
            &nbsp;</p>
    </div>
</asp:Content>
