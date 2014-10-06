<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="Signatarios.aspx.vb" Inherits="DatosBasicos_AgentesR_Signatarios" title="Untitled Page" %>
<%@ Register src="../../CtrlUsr/AyudaIzq/ctrAyudIzql.ascx" tagname="ctrAyudIzql" tagprefix="uc1" %>
<%@ Register Src="../../CtrlUsr/Terceros/CrearTer.ascx" TagName="CrearTer" TagPrefix="uc2" %>
<%@ Register Src="../../CtrlUsr/Terceros/ConsultaTer.ascx" TagName="ConsultaTer" TagPrefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="SampleContent" Runat="Server">

  <script type='text/javascript'>
  
  // Add click handlers for buttons to show and hide modal popup on pageLoad
        function pageLoad() {
            $addHandler($get("BtnCerrar"), 'click', CerrarModalTercero);        
            $addHandler($get("BtnCerrarAR"), 'click', hideModalPopupViaClient);        
            $addHandler($get("BtnCloseTer"), 'click', CerrarCrearTerc);        
            
        }

       function CerrarModalTercero(ev) {
            ev.preventDefault();        
            var modalPopupBehavior2 = $find('programmaticModalPopupBehavior2');
            modalPopupBehavior2.hide();
            var modalPopupBehavior = $find('programmaticModalPopupBehavior');
           modalPopupBehavior.hide();
        }
        
        function CerrarCrearTerc(ev)
        {
        
        var modalPopupBehavior3 = $find('programmaticModalPopupBehavior3');
            modalPopupBehavior3.hide();
        
        }    
        function CerrarTercero()
        {
           var modalPopupBehavior2 = $find('programmaticModalPopupBehavior2');
            modalPopupBehavior2.hide();
           
            var modalPopupBehavior = $find('programmaticModalPopupBehavior');
           modalPopupBehavior.hide();
        }

   function ValTipoPD (source, arguments){
       if (document.aspnetForm.<%=Me.CbTFIRMANTE_PD.ClientID%>.value=='00')
        {
        arguments.IsValid=false; 
        return;
        }
        arguments.IsValid=true;
    }
    
    function ValTipoRF (source, arguments){
       if (document.aspnetForm.<%=Me.CbTFIRMANTE_RF.ClientID%>.value=='00')
        {
        arguments.IsValid=false; 
        return;
        }
        arguments.IsValid=true;
    }
        
        function showModalPopupViaClient(ev) {
            ev.preventDefault();
            var modalPopupBehavior = $find('programmaticModalPopupBehavior');
            modalPopupBehavior.show();
        }
        
        function hideModalPopupViaClient(ev) {
            ev.preventDefault();        
            var modalPopupBehavior = $find('programmaticModalPopupBehavior');
            modalPopupBehavior.hide();
        }  
         function enviar(tdoc,ced,dv,rsocial,tip_ter)
        {
           
           if(tip_ter=='AR'){
               document.aspnetForm.<%=Me.Nit.ClientID%>.value=ced;
                document.aspnetForm.<%=Me.DV.ClientID%>.value=dv;
                document.aspnetForm.<%=Me.Agente.ClientID%>.value=rsocial;
                __doPostBack("<%= button.ClientID %>","");
           }     
           //else {alert(document.aspnetForm.<%=Me.HdTipo.ClientID%>.value);
               if(tip_ter=='PD'){
                    document.aspnetForm.<%=Me.TXTTIPDOC_PD.ClientID%>.value=tdoc;
                    document.aspnetForm.<%=Me.TXTNRODOC_PD.ClientID%>.value=ced;
                    //document.getElementById('x').innerHTML=ced;
                    document.aspnetForm.<%=Me.TXTDV_PD.ClientID%>.value=dv;
                    document.aspnetForm.<%=Me.TXTRAZSOC_PD.ClientID%>.value=rsocial;
                }
             //   if(document.aspnetForm.<%=Me.HdTipo.ClientID%>.value=='RF'){
                if(tip_ter=='RF'){
                     document.aspnetForm.<%=Me.TXTTIPDOC_RF.ClientID%>.value=tdoc;
                     document.aspnetForm.<%=Me.TXTNRODOC_RF.ClientID%>.value=ced;
                     document.aspnetForm.<%=Me.TXTDV_RF.ClientID%>.value=dv;
                     document.aspnetForm.<%=Me.TXTRAZSOC_RF.ClientID%>.value=rsocial;
                }
           //}     
           var modalPopupBehavior = $find('programmaticModalPopupBehavior');
           modalPopupBehavior.hide();
           var modalPopupBehavior2 = $find('programmaticModalPopupBehavior2');
           modalPopupBehavior2.hide();
         }

    </script>

 <div class="demoarea">
 <uc1:ctrAyudIzql ID="ctrAyudIzql1" runat="server" 
        Mensaje="&lt;b&gt;Mantega esta información actualizada&lt;/b&gt;.&lt;br&gt;Por favor actualize la Información de las personas naturales que firmaran el formulario de Declaración Privada.&lt;br&gt; &lt;b&gt;1) Declarante &lt;br/&gt; 2) Contador o Reviso Fiscal&lt;/b&gt;" />
         <asp:Label ID="LBTITULO" runat="server" CssClass="Titulo" Text="Signatarios "></asp:Label> 
     <ajaxToolkit:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server">
   </ajaxToolkit:ToolkitScriptManager>
   <asp:UpdatePanel id="UpdatePanel1" runat="server">
   <contenttemplate>
<asp:Label id="MsgResult" runat="server" __designer:wfdid="w13"></asp:Label> <asp:HiddenField id="Cla_Dec" runat="server" __designer:wfdid="w14" Value="01"></asp:HiddenField> <asp:ValidationSummary id="ValidationSummary1" runat="server" Width="673px" Height="57px" __designer:wfdid="w15" DisplayMode="List" ValidationGroup="Guardar"></asp:ValidationSummary>&nbsp; <BR /><TABLE width=600 __designer:dtid="844424930131979"><TBODY><TR __designer:dtid="844424930131980"><TD style="HEIGHT: 13px" class="TDNegroFila" __designer:dtid="844424930131981"><asp:Label id="Label10" runat="server" Font-Bold="True" __designer:dtid="844424930131982" Text="AGENTE RECAUDADOR" __designer:wfdid="w16"></asp:Label>&nbsp;&nbsp; <asp:Button style="DISPLAY: none" id="button" onclick="button_Click" runat="server" __designer:dtid="3096246218653697" __designer:wfdid="w17"></asp:Button></TD></TR><TR __designer:dtid="844424930131984"><TD __designer:dtid="844424930131985"><TABLE width="100%" __designer:dtid="844424930131986"><TBODY><TR onmouseover="Resaltar_On(this);" onmouseout="Resaltar_Off(this);" __designer:dtid="844424930131987"><TD style="WIDTH: 51px; HEIGHT: 15px" __designer:dtid="844424930131990">
           <asp:Label ID="Label45" runat="server" __designer:dtid="844424930131989" 
               __designer:wfdid="w18" CssClass="TitDecl" Font-Bold="True" 
               Text="IDENTIFICACIÓN" Width="115px"></asp:Label>
           </TD>
           <td __designer:dtid="844424930131990" style="WIDTH: 51px; HEIGHT: 15px">
               &nbsp;<asp:Label ID="Label5" runat="server" __designer:dtid="844424930131991" 
                   __designer:wfdid="w19" CssClass="TitDecl" Font-Bold="True" Text="DV"></asp:Label>
           </td>
           <td __designer:dtid="844424930131990" style="WIDTH: 51px; HEIGHT: 15px">
               &nbsp;</td>
           <TD style="WIDTH: 131px; HEIGHT: 15px" __designer:dtid="844424930131992"><asp:Label id="Label11" runat="server" Font-Bold="True" __designer:dtid="844424930131993" Text="RAZON SOCIAL" CssClass="TitDecl" __designer:wfdid="w20"></asp:Label></TD><TD style="WIDTH: 253px; HEIGHT: 15px" __designer:dtid="844424930131994"></TD></TR><TR onmouseover="Resaltar_On(this);" onmouseout="Resaltar_Off(this);" __designer:dtid="844424930131995"><TD style="WIDTH: 51px; HEIGHT: 19px" __designer:dtid="844424930131998">
           <asp:TextBox id="Nit" runat="server" __designer:dtid="844424930131997" 
               __designer:wfdid="w21" Enabled="False"></asp:TextBox></TD>
           <td __designer:dtid="844424930131998" style="WIDTH: 51px; HEIGHT: 19px">
               -<asp:TextBox ID="Dv" runat="server" __designer:dtid="844424930131999" 
                   __designer:wfdid="w22" Enabled="False" Width="17px"></asp:TextBox>
               &nbsp;</td>
           <td __designer:dtid="844424930131998" style="WIDTH: 51px; HEIGHT: 19px">
               <asp:Button ID="BtnBuscAR" runat="server" __designer:wfdid="w23" accessKey="B" 
                   onclick="BtnBuscar_Click" Text="..." ToolTip="Buscar Agente Recaudador" 
                   UseSubmitBehavior="False" />
           </td>
           <TD style="HEIGHT: 19px" colSpan=2 __designer:dtid="844424930132000"><asp:TextBox id="Agente" runat="server" Width="332px" __designer:dtid="844424930132001" __designer:wfdid="w24" Enabled="False"></asp:TextBox></TD></TR></TBODY></TABLE></TD></TR></TBODY></TABLE>&nbsp;<asp:MultiView id="MultiView1" runat="server" __designer:wfdid="w70" ActiveViewIndex="0"><asp:View id="View1" runat="server" __designer:wfdid="w113">
       <table style="width: 100%">
           <tr>
               <td style="width: 44px">
                   <asp:ImageButton ID="BtnEdit" runat="server" __designer:wfdid="w6" 
                       ImageUrl="~/images/Operaciones/Edit2.png" onclick="BtnEdit_Click1" />
               </td>
               <td>
                   &nbsp;</td>
           </tr>
           <tr>
               <td style="width: 44px">
                   Editar</td>
               <td>
                   &nbsp;</td>
           </tr>
       </table>
       <BR /><BR />
       &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<asp:FormView id="FormView1" runat="server" __designer:wfdid="w115" 
           DataSourceID="ObjSign" 
           EmptyDataText="Por favor haga click en editar para asignar los Signartarios de su Entidad."><ItemTemplate>
<TABLE width="100%" __designer:dtid="3659174697238547"><TBODY><TR onmouseover="Resaltar_On(this);" onmouseout="Resaltar_Off(this);" __designer:dtid="3659174697238548"><TD style="HEIGHT: 20px" colSpan=17 __designer:dtid="3659174697238549">
            <asp:Label id="Label7" runat="server" Font-Bold="True" Text="DECLARANTE" __designer:dtid="3659174697238550" CssClass="TitDecl" __designer:wfdid="w181"></asp:Label></TD></TR>
        <TR onmouseover="Resaltar_On(this);" onmouseout="Resaltar_Off(this);" __designer:dtid="3659174697238551">
            <TD style="WIDTH: 30px; HEIGHT: 20px" __designer:dtid="3659174697238552"></TD><TD style="WIDTH: 100px; HEIGHT: 20px" __designer:dtid="3659174697238553">
                <asp:Label id="Label31" runat="server" Text="TIPO DOCUMENTO" __designer:dtid="3659174697238554" CssClass="TitDecl" __designer:wfdid="w182" Width="111px"></asp:Label></TD>
            <TD style="WIDTH: 83px; HEIGHT: 20px" __designer:dtid="3659174697238555"><asp:Label id="Label32" runat="server" Text="IDENTIFICACIÓN" __designer:dtid="3659174697238556" CssClass="TitDecl" __designer:wfdid="w183"></asp:Label></TD>
            <TD style="WIDTH: 25px" __designer:dtid="3659174697238557"></TD><TD style="WIDTH: 25px" __designer:dtid="3659174697238558"></TD>
            <TD style="WIDTH: 345px; HEIGHT: 20px" colSpan=12 __designer:dtid="3659174697238559">&nbsp;<asp:Label id="Label35" runat="server" Text="APELLIDOS Y NOMBRES" __designer:dtid="3659174697238560" CssClass="TitDecl" __designer:wfdid="w184"></asp:Label></TD></TR>
        <TR onmouseover="Resaltar_On(this);" onmouseout="Resaltar_Off(this);" ><TD style="HEIGHT: 7px" ></TD>
            <TD style="HEIGHT: 7px" ><asp:TextBox ID="TXTTIPDOC_PD" runat="server" 
        __designer:dtid="3659174697238564" __designer:wfdid="w185" Enabled="False" 
        Text='<%# Eval("DEC_TDOC") %>' Width="34px"></asp:TextBox> </TD>
            <TD style="WIDTH: 83px; HEIGHT: 7px" __designer:dtid="3659174697238565"><asp:TextBox id="TXTNRODOC_PD" runat="server" Text='<%# Eval("DEC_NIT") %>' __designer:dtid="3659174697238566" __designer:wfdid="w186" Width="94px" Enabled="False"></asp:TextBox> </TD>
            <TD style="WIDTH: 25px; HEIGHT: 7px" __designer:dtid="3659174697238567">&nbsp;</TD><TD style="WIDTH: 25px; HEIGHT: 7px" __designer:dtid="3659174697238568">&nbsp;</TD>
            <TD style="WIDTH: 345px; HEIGHT: 7px" colSpan=12 __designer:dtid="3659174697238569">
                <asp:TextBox id="TXTRAZSOC_PD" runat="server" Text='<%# Eval("DEC_NOM") %>' __designer:dtid="3659174697238570" __designer:wfdid="w187" Width="336px" Enabled="False"></asp:TextBox></TD></TR>
        <TR onmouseover="Resaltar_On(this);" onmouseout="Resaltar_Off(this);" __designer:dtid="3659174697238571"><TD colSpan=17 __designer:dtid="3659174697238572">
                <asp:Label id="Label9" runat="server" Font-Bold="True" Text="CONTADOR O REVISOR FISCAL" __designer:dtid="3659174697238573" CssClass="TitDecl" __designer:wfdid="w188"></asp:Label></TD></TR>
        <TR onmouseover="Resaltar_On(this);" onmouseout="Resaltar_Off(this);" __designer:dtid="3659174697238574">
            <TD style="HEIGHT: 15px" __designer:dtid="3659174697238575"></TD><TD style="HEIGHT: 15px" __designer:dtid="3659174697238576">
                <asp:Label id="Label44" runat="server" Text="TIPO DOCUMENTO" __designer:dtid="3659174697238577" CssClass="TitDecl" __designer:wfdid="w189" Width="111px"></asp:Label></TD>
            <TD style="WIDTH: 83px; HEIGHT: 15px" __designer:dtid="3659174697238578"><asp:Label id="Label3" runat="server" Text="IDENTIFICACIÓN" __designer:dtid="3659174697238579" CssClass="TitDecl" __designer:wfdid="w190"></asp:Label></TD>
            <TD style="WIDTH: 25px; HEIGHT: 15px" __designer:dtid="3659174697238580"></TD><TD style="WIDTH: 25px; HEIGHT: 15px" __designer:dtid="3659174697238581"></TD>
            <TD style="WIDTH: 345px; HEIGHT: 15px" colSpan=12 __designer:dtid="3659174697238582">
                <asp:Label id="Label48" runat="server" Text="APELLIDOS Y NOMBRES" __designer:dtid="3659174697238583" CssClass="TitDecl" __designer:wfdid="w191"></asp:Label></TD></TR>
        <TR onmouseover="Resaltar_On(this);" onmouseout="Resaltar_Off(this);" __designer:dtid="3659174697238584">
            <TD style="HEIGHT: 15px" __designer:dtid="3659174697238585"></TD><TD style="HEIGHT: 15px" __designer:dtid="3659174697238586">
                <asp:TextBox id="TXTTIPDOC_RF" runat="server" Text='<%# Eval("REV_TDOC") %>' __designer:dtid="3659174697238587" __designer:wfdid="w192" Width="34px" Enabled="False"></asp:TextBox></TD>
            <TD style="WIDTH: 83px; HEIGHT: 15px" __designer:dtid="3659174697238588"><asp:TextBox id="TXTNRODOC_RF" runat="server" Text='<%# Eval("REV_NIT") %>' __designer:dtid="3659174697238589" __designer:wfdid="w193" Width="90px" Enabled="False"></asp:TextBox></TD>
            <TD style="WIDTH: 25px; HEIGHT: 15px" __designer:dtid="3659174697238590"></TD><TD style="WIDTH: 25px; HEIGHT: 15px" __designer:dtid="3659174697238591"></TD>
            <TD style="WIDTH: 345px; HEIGHT: 15px" colSpan=12 __designer:dtid="3659174697238592">
                <asp:TextBox id="TXTRAZSOC_RF" runat="server" Text='<%# Eval("REV_NOM") %>' __designer:dtid="3659174697238593" __designer:wfdid="w194" Width="323px" Enabled="False"></asp:TextBox></TD></TR>
        <TR onmouseover="Resaltar_On(this);" onmouseout="Resaltar_Off(this);" __designer:dtid="3659174697238594">
            <TD style="HEIGHT: 8px" __designer:dtid="3659174697238595"></TD><TD style="HEIGHT: 8px" colSpan=2 __designer:dtid="3659174697238596">
                <asp:TextBox id="RFoCT" runat="server" Text='<%# RvoCT(Eval("REV_TREV")) %>' __designer:dtid="3659174697238597" __designer:wfdid="w195" Width="100%" Enabled="False"></asp:TextBox></TD>
            <TD style="WIDTH: 25px; HEIGHT: 8px" __designer:dtid="3659174697238598"></TD><TD style="WIDTH: 25px; HEIGHT: 8px" __designer:dtid="3659174697238599">
                <asp:Label id="Label4" runat="server" Text="TP" __designer:dtid="3659174697238600" CssClass="TitDecl" __designer:wfdid="w196" Width="17px"></asp:Label></TD>
            <TD style="WIDTH: 345px; HEIGHT: 8px" colSpan=12 __designer:dtid="3659174697238601">
                <asp:TextBox id="TXTTRAPRO_RF" runat="server" Text='<%# Eval("REV_TAR_PRO") %>' __designer:dtid="3659174697238602" __designer:wfdid="w197" Width="90%" Enabled="False"></asp:TextBox></TD></TR></TBODY></TABLE>
</ItemTemplate>
<EmptyDataTemplate>
<asp:Label id="Label6" runat="server" 
        Text="&lt;b&gt;No tiene Signatarios Asignados&lt;b&gt;.&lt;br&gt; Haga Click en &lt;b&gt;Editar&lt;/b&gt; para actualizar la Información." 
        CssClass="NotOk" __designer:wfdid="w160" Height="40px"></asp:Label>
</EmptyDataTemplate>
           <EditRowStyle CssClass="NotOk" />
</asp:FormView></asp:View> <asp:View id="View2" runat="server" __designer:wfdid="w116"><TABLE><TBODY>
            <TR><td style="WIDTH: 49px">&#160;</td>
                <td style="WIDTH: 49px">
                    <asp:ImageButton ID="BtnSave3" runat="server" __designer:wfdid="w8" 
                        ImageUrl="~/images/Operaciones/save.png" onclick="BtnSave3_Click1" 
                        ValidationGroup="Guardar">
                    </asp:ImageButton></td>
                <td style="WIDTH: 25px">
                    &#160;</td>
                <td style="WIDTH: 49px">
                <asp:ImageButton ID="BtnCancelar2" runat="server" __designer:wfdid="w9" 
                        ImageUrl="~/images/Operaciones/undo.png" onclick="BtnCancelar2_Click">
                    </asp:ImageButton></td>
                <td style="WIDTH: 100px; text-align: center;">
        <asp:ImageButton ID="BtnNuevo" runat="server" __designer:wfdid="w10" 
                        ImageUrl="~/images/Operaciones/New1.png">
                    </asp:ImageButton></td>
    <td style="WIDTH: 49px">&#160;</td>
    <td style="WIDTH: 49px">&#160;</td>
            <td style="WIDTH: 25px">&#160;</td>
            <td style="WIDTH: 49px">
                &#160;</td>
    <td style="WIDTH: 100px; text-align: center;">
        &#160;</td></TR>
            <tr><td style="WIDTH: 49px">&#160;
                &#160;</td>
                <td style="WIDTH: 49px">
                <asp:LinkButton ID="BtnSave" runat="server" __designer:wfdid="w158" 
                        onclick="BtnSave_Click" ValidationGroup="Guardar">Guardar</asp:LinkButton></td>
                <td style="WIDTH: 25px">
        &#160;</td>
                <td style="WIDTH: 49px">
                    <asp:LinkButton ID="BtnCancelar" runat="server" __designer:wfdid="w117" 
                        onclick="BtnCancelar_Click">Cancelar</asp:LinkButton></td>
                <td style="WIDTH: 100px"><asp:LinkButton ID="BtnNuev" runat="server" 
                        __designer:wfdid="w156" onclick="LinkButton1_Click1" Width="110px">Crear Nuevo Tercero</asp:LinkButton></td>
    <td style="WIDTH: 49px"></td>
    <td style="WIDTH: 49px">&#160;</td>
            <td style="WIDTH: 25px">&#160;</td>
            <td style="WIDTH: 49px">
                &#160;</td>
    <td style="WIDTH: 100px; text-align: center;">
        &#160;</td></tr></TBODY></TABLE>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; <BR /><TABLE width="100%" border=0><TBODY><TR>
            <TD onmouseover="Resaltar_On(this);" class="TbDecl" 
                   onmouseout="Resaltar_Off(this);">&nbsp;<asp:Label id="Label29" runat="server" Text="DATOS DE PERSONA DECLARANTE" __designer:wfdid="w118"></asp:Label></TD></TR>
            <TR><TD style="HEIGHT: 78px">
                <TABLE width="100%"><TBODY>
                    <TR onmouseover="Resaltar_On(this);" onmouseout="Resaltar_Off(this);">
                        <TD style="WIDTH: 94px; HEIGHT: 20px">
                            <asp:Label id="Label31" runat="server" Width="111px" Text="TIPO DOCUMENTO" CssClass="TitDecl" __designer:wfdid="w119"></asp:Label></TD>
                        <td style="WIDTH: 100px; HEIGHT: 20px">
                            <asp:Label ID="Label32" runat="server" __designer:wfdid="w120" 
                                CssClass="TitDecl" Text="IDENTIFICACIÓN"></asp:Label>
                        </td>
                        <TD style="WIDTH: 25px"><asp:Label id="Label33" runat="server" Text="DV" CssClass="TitDecl" __designer:wfdid="w121"></asp:Label></TD>
                        <TD style="WIDTH: 30px">&nbsp;</TD>
                        <td style="width: 30px;"></td>
                        <TD style="HEIGHT: 20px">
                            &nbsp;<asp:Label id="Label35" runat="server" Width="88px" Text="RAZON SOCIAL" CssClass="TitDecl" __designer:wfdid="w122"></asp:Label>
                        </TD>
                    </TR>
                    <TR onmouseover="Resaltar_On(this);" onmouseout="Resaltar_Off(this);">
                        <TD style="WIDTH: 94px; ">
                        <asp:TextBox ID="TXTTIPDOC_PD" runat="server" 
                                Enabled="False" Width="34px" __designer:wfdid="w123"></asp:TextBox>
                             </TD>
                        <TD><asp:TextBox ID="TXTNRODOC_PD" runat="server" Width="94px" Enabled="False"></asp:TextBox></TD>
                        <td style="WIDTH: 25px; ">
                            
                            <asp:TextBox ID="TXTDV_PD" runat="server" __designer:wfdid="w125" Width="12px" 
                                Enabled="False" EnableTheming="True"></asp:TextBox> </td>
                        <td style="WIDTH: 30px; ">
                            <asp:RequiredFieldValidator 
                                ID="ValReqPerDec" runat="server" __designer:wfdid="w127" 
                                ControlToValidate="TXTNRODOC_PD" 
                                ErrorMessage="Seleccione la Persona Declarnte Haciendo Clik al Hipervinculo" 
                                ValidationGroup="Guardar">*</asp:RequiredFieldValidator></td>
                        <TD style="width: 30px;">
                            <asp:Button ID="BtnBuscDP" runat="server" __designer:wfdid="w11" 
                   accessKey="B" onclick="BtnBuscDP_Click" Text="..." 
                   ToolTip="Buscar Responsable de la Declaración" UseSubmitBehavior="False" />
                        </TD>
                        <TD>
                            <asp:TextBox ID="TXTRAZSOC_PD" runat="server" 
                   __designer:wfdid="w128" Enabled="False" Width="336px"></asp:TextBox>
                        </TD>
                    </TR>
                    <TR onmouseover="Resaltar_On(this);" onmouseout="Resaltar_Off(this);">
                        <TD 
                   style="HEIGHT: 11px" colspan="2">
                            <asp:Label ID="Label6" runat="server" __designer:wfdid="w129" 
                   CssClass="TitDecl" Font-Bold="False" Text="TIPO DE FIRMANTE" Width="110px"></asp:Label></TD>
                        <TD 
                   style="HEIGHT: 11px; width: 25px;"></TD>
                        <TD 
                   style="HEIGHT: 11px; width: 30px;"></TD>
                        <TD style="WIDTH: 30px; HEIGHT: 11px"></TD>
                        <TD style="height: 11px;">
                        </TD>
                    </TR>
                    <TR onmouseover="Resaltar_On(this);" onmouseout="Resaltar_Off(this);">
                        <TD colspan="2">
                            <asp:DropDownList ID="CbTFIRMANTE_PD" runat="server" 
                   __designer:wfdid="w130" Height="20px" Width="191px">
                                <asp:ListItem Value="00">Seleccione una Opcion</asp:ListItem>
<asp:ListItem Value="PA">Pagador</asp:ListItem>
<asp:ListItem Value="SE">Secretaria</asp:ListItem>
<asp:ListItem Value="TE">Tesorero</asp:ListItem>
<asp:ListItem Value="RL">Representante Legal</asp:ListItem>

               </asp:DropDownList></TD><TD style="WIDTH: 25px; ">
                            <asp:CustomValidator ID="ValTipFir_PD" runat="server" 
                   __designer:wfdid="w131" ClientValidationFunction="ValTipoPD" 
                   ControlToValidate="CbTFIRMANTE_PD" 
                   ErrorMessage="Seleccione el Tipo de Firmante" ValidationGroup="Guardar">*</asp:CustomValidator></TD>
                        <TD style="HEIGHT: 28px; width: 30px;">
                            <asp:ImageButton ID="ImageButton1" runat="server" 
                   ImageUrl="~/images/Operaciones/Edit2.png" Width="32px" />
                        </TD>
                        <td style="HEIGHT: 28px; width: 30px;"></td>
                        <TD style="HEIGHT: 28px">
                        </TD>
                    </TR>
                    <tr onmouseout="Resaltar_Off(this);" onmouseover="Resaltar_On(this);">
                        <td colspan="2">
                            &#160;</td><td style="WIDTH: 25px; ">
                            &#160;</td>
                        <td style="HEIGHT: 28px; width: 30px;">
                            Editar</td>
                        <td style="HEIGHT: 28px; width: 30px;">&#160;</td>
                        <td style="HEIGHT: 28px">
                            &#160;</td>
                    </tr></TBODY></TABLE>&nbsp;&nbsp; </TD></TR></TBODY></TABLE><BR /><TABLE width="100%" border=0><TBODY><TR>
            <TD onmouseover="Resaltar_On(this);" class="TbDecl" 
                   onmouseout="Resaltar_Off(this);">&nbsp; 
                <asp:Label id="Label42" runat="server" Text="DATOS CONTADOR O REVISOR FISCAL" __designer:wfdid="w132"></asp:Label> 
                <asp:Button id="btnBorrarRF" onclick="btnBorrarRF_Click" runat="server" 
                   Text="Borrar" __designer:wfdid="w13"></asp:Button></TD></TR>
            <TR><TD><TABLE width="100%"><TBODY>
                    <TR onmouseover="Resaltar_On(this);" onmouseout="Resaltar_Off(this);"><TD style="WIDTH: 100px; HEIGHT: 20px">
                            <asp:Label id="Label44" runat="server" Width="97px" 
                   Text="TIPO DOCUMENTO" CssClass="TitDecl" __designer:wfdid="w133"></asp:Label></TD>
                        <TD style="WIDTH: 47px; HEIGHT: 20px"><asp:Label id="Label2" runat="server" Text="IDENTIFICACIÓN" CssClass="TitDecl" __designer:wfdid="w134"></asp:Label></TD><TD style="WIDTH: 33px"><asp:Label id="Label46" runat="server" Text="DV" CssClass="TitDecl" __designer:wfdid="w135"></asp:Label></TD>
                        <TD style="WIDTH: 24px"></TD>
                        <TD style="WIDTH: 363px; HEIGHT: 20px">&nbsp;<asp:Label id="Label48" runat="server" Width="86px" Text="RAZON SOCIAL" CssClass="TitDecl" __designer:wfdid="w136"></asp:Label></TD></TR>
                    <TR onmouseover="Resaltar_On(this);" onmouseout="Resaltar_Off(this);"><TD style="WIDTH: 100px; HEIGHT: 20px"><asp:TextBox id="TXTTIPDOC_RF" runat="server" Width="34px" __designer:wfdid="w137" Enabled="False"></asp:TextBox></TD>
                        <TD style="WIDTH: 47px; HEIGHT: 20px">
                            <asp:TextBox id="TXTNRODOC_RF" runat="server" Width="90px" __designer:wfdid="w138" Enabled="False"></asp:TextBox></TD>
                        <TD style="WIDTH: 33px">
                            <asp:TextBox id="TXTDV_RF" runat="server" Width="16px" 
                   __designer:wfdid="w139" Enabled="False"></asp:TextBox> 
                        </TD>
                        <TD style="WIDTH: 24px"><asp:Button accessKey="B" id="BtnBuscRF" onclick="BtnBuscRF_Click" runat="server" Text="..." __designer:wfdid="w12" ToolTip="Buscar Responsable de la Declaración" UseSubmitBehavior="False"></asp:Button></TD>
                        <TD style="WIDTH: 363px; HEIGHT: 20px">
                            <asp:TextBox id="TXTRAZSOC_RF" runat="server" Width="323px" __designer:wfdid="w142" Enabled="False"></asp:TextBox></TD></TR>
                    <TR onmouseover="Resaltar_On(this);" onmouseout="Resaltar_Off(this);"><TD style="HEIGHT: 20px" colSpan=2>
                            <asp:Label id="Label1" runat="server" Width="150px" Font-Bold="False" Text="No TARJETA PROFESIONAL" CssClass="TitDecl" __designer:wfdid="w143"></asp:Label></TD>
                        <TD style="WIDTH: 33px"></TD><TD style="WIDTH: 24px"></TD>
                        <TD 
                   style="WIDTH: 363px; HEIGHT: 20px"><asp:Label id="Label3" runat="server" Width="114px" Font-Bold="False" Text="TIPO DE SIGNATARIO" CssClass="TitDecl" __designer:wfdid="w144"></asp:Label></TD></TR>
                    <TR onmouseover="Resaltar_On(this);" onmouseout="Resaltar_Off(this);"><TD style="HEIGHT: 26px" colSpan=2>
                            <asp:TextBox id="TXTTRAPRO_RF" runat="server" Width="137px" __designer:wfdid="w145"></asp:TextBox> </TD>
                        <TD style="WIDTH: 33px; HEIGHT: 26px">
                            &#160;</TD>
                        <TD style="WIDTH: 24px; HEIGHT: 26px">
                            <asp:ImageButton ID="ImgEditCT" runat="server" 
                   ImageUrl="~/images/Operaciones/Edit2.png" Width="32px" />
                        </TD>
                        <TD style="WIDTH: 363px; HEIGHT: 26px">
                            <asp:DropDownList id="CbTFIRMANTE_RF" runat="server" Width="158px" __designer:wfdid="w147"><asp:ListItem Value="00">Seleccione una Opcion</asp:ListItem>
        <asp:ListItem Value="RF">Revisor Fiscal</asp:ListItem>
        <asp:ListItem Value="CO">Contador</asp:ListItem>
        
               </asp:DropDownList> </TD></TR>
                    <tr onmouseout="Resaltar_Off(this);" onmouseover="Resaltar_On(this);">
                        <td colspan="2" style="HEIGHT: 26px">
                            &#160;</td>
                        <td style="WIDTH: 33px; HEIGHT: 26px">
                            &#160;</td>
                        <td style="WIDTH: 24px; HEIGHT: 26px">
                            Editar</td>
                        <td style="WIDTH: 363px; HEIGHT: 26px">
                            &#160;</td></tr><TR onmouseover="Resaltar_On(this);" onmouseout="Resaltar_Off(this);">
                        <TD style="HEIGHT: 26px; TEXT-ALIGN: center" colSpan=5></TD></TR>
                    <tr onmouseout="Resaltar_Off(this);" onmouseover="Resaltar_On(this);">
                        <td colspan="5" style="HEIGHT: 26px; TEXT-ALIGN: center">&#160;</td></tr>
                    <tr onmouseout="Resaltar_Off(this);" onmouseover="Resaltar_On(this);">
                        <td colspan="5" style="HEIGHT: 26px; TEXT-ALIGN: center">&#160;</td></tr></TBODY></TABLE>
                <ajaxToolkit:ValidatorCalloutExtender id="ValCallPD" runat="server" __designer:wfdid="w151" TargetControlID="ValReqPerDec"></ajaxToolkit:ValidatorCalloutExtender> 
                <ajaxToolkit:ValidatorCalloutExtender id="ValTipoFirmPD" runat="server" __designer:wfdid="w152" TargetControlID="ValTipFir_PD"></ajaxToolkit:ValidatorCalloutExtender> </TD></TR></TBODY></TABLE></asp:View></asp:MultiView><BR />&nbsp;&nbsp; <BR /><asp:HiddenField id="Tip_Us" runat="server" __designer:dtid="562949953421321" __designer:wfdid="w61"></asp:HiddenField> <asp:HiddenField id="OldDver" runat="server" __designer:dtid="562949953421325" __designer:wfdid="w62"></asp:HiddenField> <asp:HiddenField id="OldNit" runat="server" __designer:dtid="562949953421326" __designer:wfdid="w63"></asp:HiddenField> <asp:HiddenField id="Operacion" runat="server" __designer:dtid="562949953421324" __designer:wfdid="w64"></asp:HiddenField><BR /><asp:ObjectDataSource id="ObjSign" runat="server" __designer:dtid="2251799813685260" TypeName="Signatario" SelectMethod="GetRecords" __designer:wfdid="w69" OldValuesParameterFormatString="original_{0}">
        <SelectParameters __designer:dtid="2251799813685261">
            <asp:ControlParameter __designer:dtid="2251799813685262" ControlID="Nit" Name="Nit" PropertyName="Text" Type="String"  />
        </SelectParameters>
    </asp:ObjectDataSource> 
</contenttemplate>
   </asp:UpdatePanel>
      <br />
   <asp:ObjectDataSource ID="ObjTDeclarante" runat="server" SelectMethod="GetRecords"
      TypeName="TDeclarante">
   </asp:ObjectDataSource>
     &nbsp; &nbsp;
     <br />
     <asp:UpdatePanel ID="UpdatePanel2" runat="server" UpdateMode="Conditional">
         <ContentTemplate>
<!-- Mensaje de Salida--><asp:Button style="DISPLAY: none" id="hiddenTargetControlForModalPopup2" runat="server" __designer:wfdid="w8"></asp:Button> <asp:HiddenField id="HdTipo" runat="server" __designer:wfdid="w9"></asp:HiddenField> <ajaxToolkit:ModalPopupExtender id="ModalPopupTer" runat="server" __designer:wfdid="w10" TargetControlID="hiddenTargetControlForModalPopup2" BackgroundCssClass="modalBackground" BehaviorID="programmaticModalPopupBehavior2" DropShadow="True" PopupControlID="programmaticPopup2" PopupDragHandleControlID="programmaticPopupDragHandle2" RepositionMode="RepositionOnWindowScroll">
             </ajaxToolkit:ModalPopupExtender> <asp:Panel id="programmaticPopup2" runat="server" Width="625px" Height="229%" CssClass="ModalPanel2" __designer:wfdid="w11"><asp:Panel id="programmaticPopupDragHandle2" runat="Server" Height="30px" CssClass="BarTitleModal2" __designer:wfdid="w12">
                     <div style="padding-right: 5px; padding-left: 5px; padding-bottom: 5px; vertical-align: middle;
                         padding-top: 5px">
                         <div style="float: left">
                             Buscar Tercero</div>
                         <div style="float: right">
                             <input id="BtnCerrar" type="button" value="X" onclick="javascript:CerrarTercero();" /></div>
                     </div>
                 </asp:Panel> &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;<asp:Label ID="Label49" 
                     runat="server" Visible="False"></asp:Label>
                 <BR />&nbsp; &nbsp; &nbsp;&nbsp; <uc1:ConsultaTer id="ConsultaTer1" runat="server" __designer:wfdid="w13" ret="PD" Tipo="OT"></uc1:ConsultaTer> <BR /><BR /><BR /></asp:Panel> 
</ContentTemplate>
         <Triggers>
<asp:AsyncPostBackTrigger ControlID="BtnBuscDP" EventName="Click"></asp:AsyncPostBackTrigger>
<asp:AsyncPostBackTrigger ControlID="BtnBuscRF" EventName="Click"></asp:AsyncPostBackTrigger>
</Triggers>
     </asp:UpdatePanel>
     &nbsp; &nbsp;&nbsp;
     <asp:UpdatePanel id="UpdatePanel3" runat="server">
         <contenttemplate>
<BR />&nbsp;<BR />&nbsp;<asp:Button style="DISPLAY: none" id="hiddenTargetControlForModalPopup3" runat="server"></asp:Button> <ajaxToolkit:ModalPopupExtender id="ModalPopupTer3" runat="server" TargetControlID="hiddenTargetControlForModalPopup3" BackgroundCssClass="modalBackground" BehaviorID="programmaticModalPopupBehavior3" DropShadow="True" PopupControlID="programmaticPopup3" PopupDragHandleControlID="programmaticPopupDragHandle3" RepositionMode="RepositionOnWindowScroll"></ajaxToolkit:ModalPopupExtender> <asp:Panel id="programmaticPopup3" runat="server" Width="659px" Height="789%" CssClass="ModalPanel2"><asp:Panel id="programmaticPopupDragHandle3" runat="Server" Height="30px" CssClass="BarTitleModal2"><DIV style="PADDING-RIGHT: 5px; PADDING-LEFT: 5px; PADDING-BOTTOM: 5px; VERTICAL-ALIGN: middle; PADDING-TOP: 5px"><DIV style="FLOAT: left">Crear Tercero</DIV><DIV style="FLOAT: right"><INPUT id="BtnCloseTer" type=button value="X" /></DIV></DIV></asp:Panel> <TABLE style="WIDTH: 641px"><TBODY>
                     <TR><TD colSpan=7>&nbsp;<asp:Label id="Label4" runat="server" Text="Nuevo Registro" CssClass="SubTitulo">
            </asp:Label> <asp:ValidationSummary id="ValidationSummary2" runat="server" Width="580px" Height="56px" ValidationGroup="Guardar">
                     </asp:ValidationSummary></TD></TR>
                     <TR><TD style="WIDTH: 108px">Tipo Documento</TD>
                         <TD style="WIDTH: 6px"><asp:DropDownList id="CbTdoc" runat="server" Width="210px" DataSourceID="ObjTipDoc" DataTextField="TDOC_NOM" DataValueField="TDOC_COD">
                     </asp:DropDownList></TD>
                         <TD style="WIDTH: 46px">Numero de Identificacion</TD>
                         <TD colspan="3">
                             <asp:TextBox ID="TxtNit" runat="server" 
                 Width="152px"></asp:TextBox>
                             <asp:RequiredFieldValidator ID="RequiredFieldValidator1" 
                 runat="server" ControlToValidate="TxtNit" ErrorMessage="Nit, Campo Requerido" 
                 SetFocusOnError="True" ValidationGroup="GuarSig">*</asp:RequiredFieldValidator> </TD>
                         <TD style="WIDTH: 70px"></TD></TR>
                     <TR><TD style="WIDTH: 108px">Nombre</TD>
                         <TD colspan="6">
                             <asp:TextBox ID="TxtNom" runat="server" 
                 ValidationGroup="EditNew" Width="516px"></asp:TextBox> </TD></TR>
                     <TR><TD style="WIDTH: 108px">Municipios</TD>
                         <TD style="WIDTH: 6px"><asp:DropDownList id="CbMun" runat="server" Width="214px" DataSourceID="ObjMUN" DataTextField="MUN_NOM" DataValueField="MUN_COD">
                     </asp:DropDownList></TD>
                         <TD style="WIDTH: 46px">Dirección</TD><TD colspan="4">
                         <asp:TextBox 
                 ID="TxtDir" runat="server" Width="210px"></asp:TextBox></TD></TR>
                     <TR><TD style="WIDTH: 108px">E-Mail</TD>
                         <TD style="WIDTH: 6px"><asp:TextBox id="TxtEma" runat="server" Width="145px" ValidationGroup="Guardar"></asp:TextBox>
                             <asp:RegularExpressionValidator id="RegularExpressionValidator1" runat="server" ValidationGroup="GuarSig" ControlToValidate="TxtEma" ErrorMessage="Email Incorrecto" SetFocusOnError="True" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*">*</asp:RegularExpressionValidator> 
                             <asp:RequiredFieldValidator id="RequiredFieldValidator2" runat="server" ValidationGroup="GuarSig" ControlToValidate="TxtEma" ErrorMessage="Email, Campo Requerido" SetFocusOnError="True">*</asp:RequiredFieldValidator></TD>
                         <TD style="WIDTH: 46px">Teléfono</TD><TD colspan="4">
                         <asp:TextBox 
                 ID="TxtTel" runat="server" Width="209px"></asp:TextBox> </TD></TR>
                     <TR><TD style="WIDTH: 108px">Observación</TD>
                         <TD colspan="6">
                             <asp:TextBox ID="TxtObs" runat="server" 
                 Height="65px" MaxLength="200" TextMode="MultiLine" Width="513px"></asp:TextBox></TD></TR>
                     <TR><TD style="TEXT-ALIGN: center" colSpan=2>&#160;</TD>
                         <TD style="TEXT-ALIGN: center" colSpan=2>
                             <asp:ImageButton 
                 ID="BtnSave2" runat="server" ImageUrl="~/images/Operaciones/save.png" 
                 OnClick="BtnSave2_Click" ValidationGroup="GuarSig">
                     </asp:ImageButton></TD>
                         <TD style="WIDTH: 192px; TEXT-ALIGN: center">
                             <asp:ImageButton ID="BtnCancel" runat="server" 
                                     CausesValidation="False" ImageUrl="~/images/Operaciones/undo.png">
                                 </asp:ImageButton> </TD>
                         <td style="WIDTH: 192px; TEXT-ALIGN: center">
                             &#160;</td>
                         <td colspan="1" style="WIDTH: 70px; TEXT-ALIGN: center"></td></TR>
                     <tr>
                         <td colspan="2" style="TEXT-ALIGN: center">&#160;&#160;&#160;&#160; </td>
                         <td colspan="2" style="TEXT-ALIGN: center">Guardar</td>
                         <td 
                             style="WIDTH: 192px; TEXT-ALIGN: center">Cancelar</td>
                         <td style="WIDTH: 192px; TEXT-ALIGN: center"></td>
                         <td colspan="1" style="WIDTH: 70px; TEXT-ALIGN: center">&#160;&#160;</td></tr></TBODY></TABLE><BR /><BR /><BR /><asp:ObjectDataSource id="ObjMUN" runat="server" TypeName="Municipios" SelectMethod="GetRecords"></asp:ObjectDataSource>
             <asp:HiddenField ID="Oper" runat="server" />
             <asp:HiddenField ID="PK" runat="server" />
             <asp:ObjectDataSource id="ObjTipDoc" runat="server" TypeName="TipCod" SelectMethod="GetRecords"></asp:ObjectDataSource><ajaxToolkit:TextBoxWatermarkExtender id="TextBoxWatermarkExtender1" watermarkText="Maximo 200 Caracteres" runat="server" TargetControlID="TxtObs" WatermarkCssClass="watermarked"></ajaxToolkit:TextBoxWatermarkExtender></asp:Panel>&nbsp; 
</contenttemplate>
     </asp:UpdatePanel><asp:UpdatePanel id="UpdatePanel4" runat="server" UpdateMode="Conditional"><contenttemplate>
<!-- Mensaje de Salida--><asp:Button style="DISPLAY: none" id="hiddenTargetControlForModalPopup" runat="server"></asp:Button> <ajaxToolkit:ModalPopupExtender id="ModalPopup" runat="server" TargetControlID="hiddenTargetControlForModalPopup" BackgroundCssClass="modalBackground" BehaviorID="programmaticModalPopupBehavior" DropShadow="True" PopupControlID="programmaticPopup" PopupDragHandleControlID="programmaticPopupDragHandle" RepositionMode="RepositionOnWindowScroll">
            </ajaxToolkit:ModalPopupExtender>&nbsp; <asp:Panel id="programmaticPopup" runat="server" Width="625px" Height="229%" __designer:dtid="3096224743817236" CssClass="ModalPanel2" __designer:wfdid="w150"><asp:Panel id="programmaticPopupDragHandle" runat="Server" Height="30px" __designer:dtid="3096224743817237" CssClass="BarTitleModal2" __designer:wfdid="w151"><DIV style="PADDING-RIGHT: 5px; PADDING-LEFT: 5px; PADDING-BOTTOM: 5px; VERTICAL-ALIGN: middle; PADDING-TOP: 5px" __designer:dtid="3096224743817238"><DIV style="FLOAT: left" __designer:dtid="3096224743817239">Buscar Agente Recaudador </DIV><DIV style="FLOAT: right" __designer:dtid="3096224743817240"><INPUT id="BtnCerrarAR" type=button value="X" __designer:dtid="3096224743817241" /></DIV></DIV></asp:Panel> &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;<BR __designer:dtid="3096224743817242" />&nbsp; &nbsp; &nbsp;&nbsp; <uc1:ConsultaTer id="ConsultaTer" runat="server" __designer:dtid="3096224743817243" __designer:wfdid="w152" Tipo="AR" Ret="AR"></uc1:ConsultaTer> <BR __designer:dtid="3096224743817244" /><BR __designer:dtid="3096224743817245" /><BR __designer:dtid="3096224743817246" /></asp:Panel> 
</contenttemplate>
         <triggers>
<asp:AsyncPostBackTrigger ControlID="BtnBuscDP" EventName="Click"></asp:AsyncPostBackTrigger>
</triggers>
     </asp:UpdatePanel>&nbsp;
     <br />
</div>
</asp:Content>

