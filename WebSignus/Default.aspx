<%@ Page Title="" Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="Default.aspx.vb" Inherits="_Default" %>

<%@ Register src="CtrlUsr/Inicial/Inicio.ascx" tagname="Inicio" tagprefix="uc1" %>
<%@ Register src="CtrlUsr/AyudaIzq/ctrAyudIzql.ascx" tagname="ctrAyudIzql" tagprefix="uc2" %>
<%@ Register src="CtrlUsr/AyudaIzq/ctrAyudIzqlC.ascx" tagname="ctrAyudIzqlC" tagprefix="uc3" %>

<asp:Content ID="Content1" ContentPlaceHolderID="SampleContent" Runat="Server">
    <div class="demoarea" style="text-align: left">
  <h3>
      <asp:ScriptManager id="ScriptManager1" runat="server">
      </asp:ScriptManager>
    <asp:Image ID="Image3" runat="server"  ImageUrl="~/images/Login/Img_gob.jpg" 
          Height="50px" Width="137px"
         />&nbsp;INSTRUCCIONES A SEGUIR ...</h3>
        <h3>
        &nbsp;&nbsp;</h3>
    
     
         <table style="width: 100%">
             <tr>
             <td>
            <asp:Panel ID="PnlCartera" runat="server">
                 <img src='/images/Operaciones/cartera.png' alt="Cartera" /><asp:Label ID="lb1" CssClass="SubTitulo" runat="server" Text="  Valor de la Cartera">  </asp:Label> 
                <asp:Label ID="lbCartera" runat="server" Text="$$$">  </asp:Label> 
             </asp:Panel>
             </td>
             </tr>
             <tr>
                 <td rowspan="5">
                     <uc1:Inicio ID="Inicio1" runat="server" />
                 </td>
                 <td valign="top">
                 <uc3:ctrayudizqlc ID="ctrAyudIzqlC1" runat="server" alt="" 
                         Mensaje="&lt;b&gt; Pagos por Transferencia &lt;/b&gt; &lt;br/&gt;En caso de Hacer pagos por transferencia por favor reportarlo via Correo Electrónico o Telefónicamente,Para que este se vea reflejado en el <b>Sistema</b> y en su  <a href='Consultas/CuentaCorriente/ConCartera.aspx'><b>Cartera</b> </a> " />
                 </td>
             </tr>
             
             <tr>
                 <td valign="top">
                     <uc2:ctrayudizql ID="ctrAyudIzql2" runat="server" 
                         
                         
                         
                         Mensaje="&lt;b&gt; Sanciones e Intereses &lt;/b&gt; &lt;br/&gt;Recuerde realizar mensualmente el reporte de información en medios magneticos, presentar la declaración y pagar de forma Oportuna. Sanción por Extemporaneidad anterior al Emplazamiento 3% mes o Fracción hasta el 70%. Sanción por Extemporaneidad posterior al Emplazamiento 5% mes o Fracción hasta el 100%.Aplica Sanción Minina." />
                 </td>
             </tr>
             <tr>
                 <td>
                     <uc2:ctrAyudIzql ID="ctrAyudIzql1" runat="server" 
                         
                         Mensaje="&lt;b&gt; Señor Agente Recaudador &lt;/b&gt; &lt;br/&gt; Siga las Intrucciones para diligenciar su declaración de forma Correcta.&lt;br/&gt; Cualquier Inquietud enviarla al correo &lt;b&gt;informatica@gobcesar.gov.co&lt;/b&gt;" />
                 </td>
             </tr>
             <tr>
                 <td>
                     &nbsp;</td>
             </tr>
             <tr>
                 <td>
                     &nbsp;</td>
             </tr>
             <tr>
                 <td>
                     &nbsp;</td>
             </tr>
             <tr>
                 <td>
                     &nbsp;</td>
                 <td>
                     &nbsp;</td>
             </tr>
         </table>
     
    
    <br />
    <br />
    <br />
    <br />
    <br />
    <br />
    <br />
    <br />
    <br />
                     
</div>    

</asp:Content>

