<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="MisDatos.aspx.vb" Inherits="DatosBasicos_MisDatos_MisDatos" title="Untitled Page" %>
<%@ Register src="../../CtrlUsr/AyudaIzq/ctrAyudIzql.ascx" tagname="ctrAyudIzql" tagprefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="SampleContent" Runat="Server">
<script type="text/javascript">
            function ColocarNit(){
                document.aspnetForm.<%=Me.TxtDVER.ClientID%>.value="";
                document.aspnetForm.<%=Me.TxtUsu.ClientID%>.value=document.aspnetForm.<%=Me.TxtNit.ClientID%>.value;
                if(document.aspnetForm.<%=Me.CbTdoc.ClientID%>.value=="NI")
                {
                    var dv=calcularDV(document.aspnetForm.<%=Me.TxtNit.ClientID%>.value);
                    document.aspnetForm.<%=Me.TxtDVER.ClientID%>.value=dv;
                    document.aspnetForm.<%=Me.TxtCed.ClientID%>.value=""
                    document.aspnetForm.<%=Me.TxtUsu.ClientID%>.value=document.aspnetForm.<%=Me.TxtUsu.ClientID%>.value+"-"+dv;
                }    
                else
                {
                document.aspnetForm.<%=Me.TxtCed.ClientID%>.value=document.aspnetForm.<%=Me.TxtNit.ClientID%>.value;
                document.aspnetForm.<%=Me.TxtRep.ClientID%>.value=document.aspnetForm.<%=Me.TxtNom.ClientID%>.value;    
                }
            }
            
            function zero_fill(i_valor, num_ceros) {
        relleno = ""
        i = 1
        salir = 0
        while ( ! salir ) {
        total_caracteres = i_valor.length + i
        if ( i > num_ceros || total_caracteres > num_ceros )
        salir = 1
        else
        relleno = relleno + "0"
        i++
        }

        i_valor = relleno + i_valor
        return i_valor
        }

        function calcularDV(i_rut) {
        var pesos = new Array(71,67,59,53,47,43,41,37,29,23,19,17,13,7,3); 
        rut_fmt = zero_fill(i_rut, 15)
        suma = 0
        for ( i=0; i<=14; i++ ) 
        suma += rut_fmt.substring(i, i+1) * pesos[i]
        resto = suma % 11
        if ( resto == 0 || resto == 1 )
        digitov = resto
        else
        digitov = 11 - resto

        return(digitov)
        }
</script>
<div class="demoarea">
    <ajaxToolkit:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server">
    </ajaxToolkit:ToolkitScriptManager>
    <asp:Label ID="Tit" runat="server" CssClass="Titulo" 
        Text="ACTUALIZACIÓN DE DATOS"></asp:Label>
    <asp:UpdatePanel id="UpdatePanel3" runat="server">
        <contenttemplate>
<TABLE style="WIDTH: 668px"><TBODY><TR><TD colSpan=7><asp:ValidationSummary id="ValidationSummary2" runat="server" Width="580px" Height="56px" ValidationGroup="Guardar"></asp:ValidationSummary><asp:Label id="MsgResult" runat="server" Width="90%" Height="30px"></asp:Label></TD>
    <td>
        &nbsp;</td>
    </TR><TR><TD style="WIDTH: 108px">Tipo Documento</TD><TD style="WIDTH: 60px"><asp:DropDownList id="CbTdoc" runat="server" Width="210px" DataSourceID="ObjTipDoc" DataValueField="TDOC_COD" DataTextField="TDOC_NOM"></asp:DropDownList></TD><TD style="WIDTH: 46px">
    Número&nbsp; Identificacion</TD><TD colSpan=3><asp:TextBox id="TxtNit" runat="server" Width="152px"></asp:TextBox><asp:RequiredFieldValidator id="RequiredFieldValidator1" runat="server" ValidationGroup="Guardar" ControlToValidate="TxtNit" ErrorMessage="Nit, Campo Requerido" SetFocusOnError="True">*</asp:RequiredFieldValidator> </TD><TD style="WIDTH: 100px"><asp:TextBox id="TxtDver" runat="server" Width="20px" Rows="1" Enabled="False"></asp:TextBox></TD>
        <td rowspan="11" style="WIDTH: 100px" valign="top">
            <uc1:ctrAyudIzql ID="ctrAyudIzql1" runat="server" 
                
                Mensaje="&lt;b&gt;Mantega esta información actualizada&lt;/b&gt;&lt;br/&gt;- Actualize todos los datos de su Entidad con frecuencia.&lt;br/&gt;Tenga en cuenta que el &lt;b&gt;Correo Electrónico&lt;/b&gt; se requiere al momento de Restaurar su contraseña, y por medio de este el sistema le enviará de información de interés oficial y actualzaciones." />
        </td>
    </TR><TR><TD style="WIDTH: 108px">Nombre</TD><TD colSpan=6><asp:TextBox id="TxtNom" runat="server" Width="516px" ValidationGroup="EditNew"></asp:TextBox> </TD></TR><TR><TD style="WIDTH: 108px">Municipios</TD><TD style="WIDTH: 60px"><asp:DropDownList id="CbMun" runat="server" Width="214px" DataSourceID="ObjMUN" DataValueField="MUN_COD" DataTextField="MUN_NOM"></asp:DropDownList></TD><TD style="WIDTH: 46px">Dirección</TD>
    <TD colSpan=4><asp:TextBox id="TxtDir" runat="server" Width="210px"></asp:TextBox></TD></TR><TR><TD style="WIDTH: 108px">E-Mail</TD><TD style="WIDTH: 60px"><asp:TextBox id="TxtEma" runat="server" Width="201px" ValidationGroup="Guardar"></asp:TextBox><asp:RegularExpressionValidator id="RegularExpressionValidator1" runat="server" ValidationGroup="Guardar" ControlToValidate="TxtEma" ErrorMessage="Email Incorrecto" SetFocusOnError="True" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*">*</asp:RegularExpressionValidator> <asp:RequiredFieldValidator id="RequiredFieldValidator2" runat="server" ValidationGroup="Guardar" ControlToValidate="TxtEma" ErrorMessage="Email, Campo Requerido" SetFocusOnError="True">*</asp:RequiredFieldValidator></TD><TD style="WIDTH: 46px">Teléfono</TD>
    <TD colSpan=4><asp:TextBox id="TxtTel" runat="server" Width="209px"></asp:TextBox> </TD></TR><TR><TD style="WIDTH: 108px">Estado</TD><TD style="WIDTH: 60px"><asp:DropDownList id="CbEst" runat="server" Width="210px" Enabled="False"><asp:ListItem Value="AC">Activo</asp:ListItem>
<asp:ListItem Value="IN">Inactivo</asp:ListItem>
</asp:DropDownList></TD><TD style="WIDTH: 46px">Cedula<BR />Representante</TD>
    <TD colSpan=4><asp:TextBox id="TxtCed" runat="server" Width="184px"></asp:TextBox> <asp:RequiredFieldValidator id="RequiredFieldValidator3" runat="server" ValidationGroup="Guardar" ControlToValidate="TxtCed" ErrorMessage="Cedula del Representante Legal, Requerida">*</asp:RequiredFieldValidator></TD></TR><TR><TD style="WIDTH: 108px; HEIGHT: 38px">Nombre<BR />Representante</TD>
    <TD style="HEIGHT: 38px" colSpan=6><asp:TextBox id="TxtRep" runat="server" Width="444px"></asp:TextBox> <asp:RequiredFieldValidator id="RequiredFieldValidator4" runat="server" ValidationGroup="Guardar" ControlToValidate="TxtNom" ErrorMessage="Nombre del Representante Legal, Requerida, Campo Requerido">*</asp:RequiredFieldValidator></TD></TR><TR><TD style="WIDTH: 108px">Usuario</TD><TD style="WIDTH: 60px"><asp:TextBox id="TxtUsu" runat="server" Width="211px" Enabled="False"></asp:TextBox></TD><TD style="WIDTH: 46px">Tipo Usuario</TD>
    <TD colSpan=4><asp:DropDownList id="CbTUsu" runat="server" Width="214px" DataSourceID="ObjTusua" DataValueField="TUS_COD" DataTextField="TUS_NOM" Enabled="False"></asp:DropDownList></TD></TR><TR><TD style="WIDTH: 108px">Tipo Terceros</TD>
    <TD colSpan=6><asp:DropDownList id="CbTTcer" runat="server" Width="522px" DataSourceID="ObjTTer" DataValueField="TAG_COD" DataTextField="TAG_NOM"></asp:DropDownList></TD></TR><TR><TD style="WIDTH: 108px">Observación</TD>
    <TD colSpan=6><asp:TextBox id="TxtObs" runat="server" Width="513px" Height="65px" TextMode="MultiLine" MaxLength="200"></asp:TextBox></TD></TR><TR>
    <TD style="TEXT-ALIGN: center" colSpan=2>

        &nbsp;</TD>
    <td colspan="2" style="TEXT-ALIGN: center">
        <asp:ImageButton ID="BtnSave" runat="server" 
            ImageUrl="~/images/Operaciones/save.png" onclick="Btnsave_Click" 
            ValidationGroup="Guardar" />
    </td>
    <TD style="WIDTH: 192px; TEXT-ALIGN: center">
<asp:ImageButton id="BtnCancel" onclick="BtnCancel_Click" runat="server" ImageUrl="~/images/Operaciones/undo.png" CausesValidation="False"></asp:ImageButton>
</TD>
    <td style="WIDTH: 192px; TEXT-ALIGN: center">
        &nbsp;</td>
    <TD style="TEXT-ALIGN: center" colSpan=1></TD></TR>
    <tr>
        <td colspan="2" style="TEXT-ALIGN: center">
            &nbsp;</td>
        <td colspan="2" style="TEXT-ALIGN: center">
            Guardar</td>
        <td style="WIDTH: 192px; TEXT-ALIGN: center">
            Cancelar</td>
        <td style="WIDTH: 192px; TEXT-ALIGN: center">
            &nbsp;</td>
        <td colspan="1" style="TEXT-ALIGN: center">
            &nbsp;</td>
    </tr>
    </TBODY></TABLE><asp:ObjectDataSource id="ObjMUN" runat="server" TypeName="Municipios" SelectMethod="GetRecords"></asp:ObjectDataSource> <asp:ObjectDataSource id="ObjTipDoc" runat="server" TypeName="TipCod" SelectMethod="GetRecords"></asp:ObjectDataSource> <ajaxToolkit:TextBoxWatermarkExtender id="TextBoxWatermarkExtender1" watermarkText="Maximo 200 Caracteres" runat="server" WatermarkCssClass="watermarked" TargetControlID="TxtObs"></ajaxToolkit:TextBoxWatermarkExtender> <asp:HiddenField id="HOldNit" runat="server"></asp:HiddenField><asp:HiddenField id="HOldTDoc" runat="server"></asp:HiddenField><asp:HiddenField id="HOldDVer" runat="server"></asp:HiddenField><asp:ObjectDataSource id="ObjectDataSource1" runat="server" TypeName="Municipios" SelectMethod="GetRecords"></asp:ObjectDataSource><asp:ObjectDataSource id="ObjTTer" runat="server" TypeName="TTerc" SelectMethod="GetRecords"></asp:ObjectDataSource><asp:ObjectDataSource id="ObjectDataSource2" runat="server" TypeName="TipCod" SelectMethod="GetRecords"></asp:ObjectDataSource> <asp:ObjectDataSource id="ObjTusua" runat="server" TypeName="TipUsu" SelectMethod="GetRecords"></asp:ObjectDataSource>
</contenttemplate>
    </asp:UpdatePanel>
    
 

</div>
</asp:Content>

