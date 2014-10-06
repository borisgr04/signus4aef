<%@ Control Language="VB" AutoEventWireup="false" CodeFile="CrearTer.ascx.vb" Inherits="CtrlUsr_Terceros_CrearTer" %>
<asp:UpdatePanel ID="UpdatePanel1" runat="server">


    <ContentTemplate>
    <script type="text/javascript">
            Sys.WebForms.PageRequestManager.getInstance().add_initializeRequest(IniciaRequest);
            Sys.WebForms.PageRequestManager.getInstance().add_beginRequest(BeginRequest);
            Sys.WebForms.PageRequestManager.getInstance().add_pageLoaded(EndRequest);
            Sys.WebForms.PageRequestManager.getInstance().add_endRequest(FinRequest);
             
            var _Instance = Sys.WebForms.PageRequestManager.getInstance();
            
            function ColocarRep(){
            document.aspnetForm.<%=Me.TxtRep.ClientID%>.value=document.aspnetForm.<%=Me.TxtNom.ClientID%>.value;
            }
            
            function ColocarNit(){
            
                document.aspnetForm.<%=Me.TxtDVER.ClientID%>.value="";
                document.aspnetForm.<%=Me.Hidenusu.ClientID%>.value=document.aspnetForm.<%=Me.TxtNit.ClientID%>.value;
                document.aspnetForm.<%=Me.TxtCed.ClientID%>.value=document.aspnetForm.<%=Me.TxtNit.ClientID%>.value;
                if(document.aspnetForm.<%=Me.CbTdoc.ClientID%>.value=="NI")
                {
                    var dv=calcularDV(document.aspnetForm.<%=Me.TxtNit.ClientID%>.value);
                    document.aspnetForm.<%=Me.TxtDVER.ClientID%>.value=dv;
                    document.aspnetForm.<%=Me.TxtCed.ClientID%>.value="";
                    document.aspnetForm.<%=Me.Hidenusu.ClientID%>.value=document.aspnetForm.<%=Me.Hidenusu.ClientID%>.value+"-"+dv;
                }
                
                
            }

            function IniciaRequest(sender,arg)
            {

            // INICIALIZACION DEL REQUEST
                if (_Instance.get_isInAsyncPostBack()) 
                    {
                        //window.alert("Existe un proceso en marcha. Espere<"+sender._postBackSettings.sourceElement.id);
                        window.alert("Existe un proceso en marcha. Espere");
                        arg.set_cancel(true);
                    }
              
             // RATON A PENSAR
                switch(sender._postBackSettings.sourceElement.id)
                {
                //window.alert(sender._postBackSettings.sourceElement.id);
                case '<%=Me.BtnSave.ClientID%>':
                    $get('<%=Me.UpdatePanel1.ClientID%>').style.cursor = 'wait';
                }
                
                // DESHABILITA CONTROL QUE HA INICIADO EL REQUEST
                $get(sender._postBackSettings.sourceElement.id).disabled = true;
            }

            function BeginRequest(sender,art)
            {
            // COMIENZO DEL REQUEST
                //document.getElementById("Progreso").style.visibility = 'visible';
            }  
    
            function EndRequest(sender,art)    
            // FIN DEL REQUEST
            {
                //document.getElementById("Progreso").style.visibility = 'hidden';
            }
            
            function FinRequest(sender,arg)
            // FIN DE REQUEST
            {
             $get('<%=Me.UpdatePanel1.ClientID%>').style.cursor = 'auto';
            // RATON NORMAL
                if((sender._postBackSettings.sourceElement.id!="<%=Me.BtnCancel.ClientID%>") && (sender._postBackSettings.sourceElement.id!="<%=Me.BtnSave.ClientID%>"))
                {
                    switch(sender._postBackSettings.sourceElement.id)
                    {
                    case '<%=Me.BtnSave.ClientID%>':
                        $get('<%=Me.UpdatePanel1.ClientID%>').style.cursor = 'auto';
                    }
                    // HABILITA CONTROL QUE HA INICIO EL REQUEST
                    $get(sender._postBackSettings.sourceElement.id).disabled = false;
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
        <table style="width: 641px">
            <tr>
                <td colspan="6">
                    &nbsp;&nbsp;<br />
                    <asp:Label ID="Tit" runat="server" CssClass="Titulo" Text="TERCEROS"></asp:Label><br />
                    <asp:Label ID="MsgResult" runat="server"></asp:Label>
                    <asp:HiddenField ID="Hidenusu" runat="server" />
                    &nbsp;
                    <asp:HiddenField ID="HideTTER" runat="server" />
                    <br />
                    <asp:HiddenField ID="HidTUs" runat="server" />
                    <br />
                    <asp:ValidationSummary ID="ValidationSummary1" runat="server" Height="80px" ValidationGroup="Guardar"
                        Width="230px" />
                    <asp:Label ID="SubT" runat="server" CssClass="SubTitulo" Text="Nuevo"></asp:Label></td>
            </tr>
            <tr>
                <td style="width: 108px">
                    Tipo Documento</td>
                <td style="width: 60px">
                    <asp:DropDownList ID="CbTdoc" runat="server" DataSourceID="ObjTipDoc" DataTextField="TDOC_NOM"
                        DataValueField="TDOC_COD" Width="210px">
                    </asp:DropDownList></td>
                <td style="width: 46px">
                    Numero de Identificacion</td>
                <td colspan="2">
                    <asp:TextBox ID="TxtNit" runat="server" Width="152px"></asp:TextBox><asp:RequiredFieldValidator
                        ID="RequiredFieldValidator1" runat="server" ControlToValidate="TxtNit" ErrorMessage="Nit, Campo Requerido"
                        SetFocusOnError="True" ValidationGroup="Guardar">*</asp:RequiredFieldValidator>
                </td>
                <td style="width: 100px">
                    <asp:TextBox ID="TxtDver" runat="server" Enabled="False" Rows="1" Width="20px"></asp:TextBox></td>
            </tr>
            <tr>
                <td style="width: 108px">
                    Nombre</td>
                <td colspan="5">
                    <asp:TextBox ID="TxtNom" runat="server" ValidationGroup="EditNew" Width="516px"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td style="width: 108px">
                    Municipios</td>
                <td style="width: 60px">
                    <asp:DropDownList ID="CbMun" runat="server" DataSourceID="ObjMUN" DataTextField="MUN_NOM"
                        DataValueField="MUN_COD" Width="214px">
                    </asp:DropDownList></td>
                <td style="width: 46px">
                    Dirección</td>
                <td colspan="3">
                    <asp:TextBox ID="TxtDir" runat="server" Width="210px"></asp:TextBox></td>
            </tr>
            <tr>
                <td style="width: 108px">
                    E-Mail</td>
                <td style="width: 60px">
                    <asp:TextBox ID="TxtEma" runat="server" ValidationGroup="Guardar" Width="145px"></asp:TextBox><asp:RegularExpressionValidator
                        ID="RegularExpressionValidator1" runat="server" ControlToValidate="TxtEma" ErrorMessage="Email Incorrecto"
                        SetFocusOnError="True" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"
                        ValidationGroup="Guardar">*</asp:RegularExpressionValidator>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="TxtEma"
                        ErrorMessage="Email, Campo Requerido" SetFocusOnError="True" ValidationGroup="Guardar">*</asp:RequiredFieldValidator></td>
                <td style="width: 46px; color: #000000">
                    Teléfono</td>
                <td colspan="3">
                    <asp:TextBox ID="TxtTel" runat="server" Width="209px"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td style="width: 108px">
                    Estado</td>
                <td style="width: 60px">
                    <asp:DropDownList ID="CbEst" runat="server" Width="210px">
                        <asp:ListItem Value="AC">Activo</asp:ListItem>
                        <asp:ListItem Value="IN">Inactivo</asp:ListItem>
                    </asp:DropDownList></td>
                <td style="width: 46px">
                    Cedula<br />
                    Representante</td>
                <td colspan="3">
                    <asp:TextBox ID="TxtCed" runat="server" Width="184px"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="TxtCed"
                        ErrorMessage="Cedula del Representante Legal, Requerida" ValidationGroup="Guardar">*</asp:RequiredFieldValidator></td>
            </tr>
            <tr>
                <td style="width: 108px; height: 38px">
                    Nombre<br />
                    Representante</td>
                <td colspan="5" style="height: 38px">
                    <asp:TextBox ID="TxtRep" runat="server" Width="444px"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="TxtNom"
                        ErrorMessage="Nombre del Representante Legal, Requerida, Campo Requerido" ValidationGroup="Guardar">*</asp:RequiredFieldValidator></td>
            </tr>
            <tr>
                <td style="width: 108px">
                    <asp:Label ID="Label1" runat="server" Text="Usuario" Visible="False"></asp:Label></td>
                <td style="width: 60px">
                    <asp:TextBox ID="TxtUsu" runat="server" Enabled="False" Width="211px" Visible="False"></asp:TextBox></td>
                <td style="width: 46px">
                    <asp:Label ID="Label2" runat="server" Text="Tipo Usuario" Visible="False"></asp:Label></td>
                <td colspan="3">
                    <asp:DropDownList ID="CbTUsu" runat="server" DataSourceID="ObjTusua" DataTextField="TUS_NOM"
                        DataValueField="TUS_COD" Width="214px" Visible="False">
                    </asp:DropDownList></td>
            </tr>
            <tr>
                <td style="width: 108px">
                    <asp:Label ID="Label3" runat="server" Text="Tipo Terceros" Visible="False"></asp:Label></td>
                <td colspan="5">
                    <asp:DropDownList ID="CbTTcer" runat="server" DataSourceID="ObjTTer" DataTextField="TAG_NOM"
                        DataValueField="TAG_COD" Width="522px" Visible="False">
                    </asp:DropDownList></td>
            </tr>
            <tr>
                <td style="width: 108px">
                    Observación</td>
                <td colspan="5">
                    <asp:TextBox ID="TxtObs" runat="server" Height="65px" MaxLength="200" TextMode="MultiLine"
                        Width="513px"></asp:TextBox></td>
            </tr>
            <tr>
                <td colspan="4" style="text-align: center">
                    <div id="Guardar">
                            <asp:ImageButton ID="BtnSave"
                            runat="server" ImageUrl="~/images/Operaciones/save.png" OnClick="Btnsave_Click"
                            ValidationGroup="Guardar" /></div>
                </td>
                <td colspan="1" style="width: 192px; text-align: center">
                    <div id="Cancelar">
                        &nbsp;<asp:ImageButton ID="BtnCancel" runat="server" CausesValidation="False" ImageUrl="~/images/Operaciones/undo.png"
                            OnClick="BtnCancel_Click" />
                        &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
                        &nbsp; &nbsp; &nbsp; &nbsp;&nbsp;</div>
                </td>
                <td colspan="1" style="text-align: center">
                </td>
            </tr>
        </table>
        <asp:ObjectDataSource ID="ObjMUN" runat="server" SelectMethod="GetRecords" TypeName="Municipios">
        </asp:ObjectDataSource>
        <asp:ObjectDataSource ID="ObjTTer" runat="server" SelectMethod="GetRecords" TypeName="TTerc">
        </asp:ObjectDataSource>
        <asp:ObjectDataSource ID="ObjTipDoc" runat="server" SelectMethod="GetRecords" TypeName="TipCod">
        </asp:ObjectDataSource>
        <asp:ObjectDataSource ID="ObjTusua" runat="server" SelectMethod="GetRecords" TypeName="TipUsu">
        </asp:ObjectDataSource>
        &nbsp;&nbsp;
        <ajaxToolkit:TextBoxWatermarkExtender ID="TextBoxWatermarkExtender1" runat="server"
            TargetControlID="TxtObs" WatermarkCssClass="watermarked" WatermarkText="Maximo 200 Caracteres">
        </ajaxToolkit:TextBoxWatermarkExtender>
    </ContentTemplate>
</asp:UpdatePanel>
