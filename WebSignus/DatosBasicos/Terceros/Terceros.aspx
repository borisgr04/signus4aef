<%@ Page Language="VB" 
MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="Terceros.aspx.vb" 
Inherits="DatosBasicos_Terceros_Terceros" title="Untitled Page" EnableEventValidation="true"   %>


<asp:Content ID="Content1" ContentPlaceHolderID="SampleContent" Runat="Server"><div class="demoarea">
    <div class="demoarea">
<ajaxToolkit:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server" EnableScriptGlobalization="true"
            EnableScriptLocalization="true" EnablePartialRendering="true">
        </ajaxToolkit:ToolkitScriptManager>
                
         <script type="text/javascript">
            Sys.WebForms.PageRequestManager.getInstance().add_initializeRequest(IniciaRequest);
            Sys.WebForms.PageRequestManager.getInstance().add_beginRequest(BeginRequest);
            Sys.WebForms.PageRequestManager.getInstance().add_pageLoaded(EndRequest);
            Sys.WebForms.PageRequestManager.getInstance().add_endRequest(FinRequest);
             
            var _Instance = Sys.WebForms.PageRequestManager.getInstance();
            
            function ColocarNit(){
            
                document.aspnetForm.<%=Me.TxtDVER.ClientID%>.value="";
                document.aspnetForm.<%=Me.TxtUsu.ClientID%>.value=document.aspnetForm.<%=Me.TxtNit.ClientID%>.value;
                document.aspnetForm.<%=Me.TxtCed.ClientID%>.value=document.aspnetForm.<%=Me.TxtNit.ClientID%>.value;
                if(document.aspnetForm.<%=Me.CbTdoc.ClientID%>.value=="NI")
                {
                    var dv=calcularDV(document.aspnetForm.<%=Me.TxtNit.ClientID%>.value);
                    document.aspnetForm.<%=Me.TxtDVER.ClientID%>.value=dv;
                    document.aspnetForm.<%=Me.TxtCed.ClientID%>.value=""
                    document.aspnetForm.<%=Me.TxtUsu.ClientID%>.value=document.aspnetForm.<%=Me.TxtUsu.ClientID%>.value;
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
                case 'ctl00_SampleContent_BtnSave':
                    $get('ctl00_SampleContent_UpdatePanel1').style.cursor = 'wait';
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
             $get('ctl00_SampleContent_UpdatePanel1').style.cursor = 'auto';
            // RATON NORMAL
                if((sender._postBackSettings.sourceElement.id!="ctl00_SampleContent_BtnCancel") && (sender._postBackSettings.sourceElement.id!="ctl00_SampleContent_BtnSave"))
                {
                    switch(sender._postBackSettings.sourceElement.id)
                    {
                    case 'ctl00_SampleContent_BtnSave':
                        $get('ctl00_SampleContent_UpdatePanel1').style.cursor = 'auto';
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

        
        


       
        
       <br />
         <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional">
        <ContentTemplate>
         &nbsp;<asp:Label id="Tit" runat="server" CssClass="Titulo" Text="TERCEROS"></asp:Label>&nbsp; <BR />
         <asp:Label id="MsgResult" runat="server"></asp:Label>&nbsp; 
         <BR />
         <asp:ValidationSummary id="ValidationSummary1" runat="server" Width="543px" Height="80px" ValidationGroup="Guardar"></asp:ValidationSummary> 
         <asp:Label id="SubT" runat="server" CssClass="SubTitulo" Text="Nuevo"></asp:Label>
         <BR />
         <asp:MultiView id="MultiView1" runat="server" ActiveViewIndex="1">
         <asp:View id="View1" runat="server">
             <table style="WIDTH: 641px">
             <tr>
                     <td>
                         Tipo Documento</td>
                     <td>
                         <asp:DropDownList ID="CbTdoc" runat="server" DataSourceID="ObjTipDoc" 
                         DataTextField="TDOC_NOM" DataValueField="TDOC_COD" Width="150px"></asp:DropDownList>
                     </td>
                     <td>
                         Numero de Identificacion
                     </td>
                     <td>
                     <asp:TextBox ID="TxtNit" runat="server" Width="152px"></asp:TextBox>
                         <asp:TextBox ID="TxtDver" runat="server" Enabled="False" Rows="1" Width="20px"></asp:TextBox>
                         <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
                             ControlToValidate="TxtNit" ErrorMessage="Nit, Campo Requerido" 
                             SetFocusOnError="True" ValidationGroup="Guardar">*</asp:RequiredFieldValidator>
                     </td>
                     <td>
                         &nbsp;</td>
                     <td>
                         &nbsp;</td>
                 </tr>
                 <tr>
                     <td>Nombre</td>
                     <td colspan="5">
                         <asp:TextBox ID="TxtNom" runat="server" ValidationGroup="EditNew" Width="516px"></asp:TextBox> 
                     </td>
                 </tr>
                 <tr>
                     <td>
                         Municipios
                     </td>
                     <td>
                         <asp:DropDownList ID="CbMun" runat="server" DataSourceID="ObjMUN" 
                         DataTextField="MUN_NOM" DataValueField="MUN_COD" Width="214px"></asp:DropDownList>
                     </td>
                     <td>
                         Dirección
                     </td>
                     <td colspan="2">
                         <asp:TextBox ID="TxtDir" runat="server" Width="210px"></asp:TextBox>
                     </td>
                     <td>
                         &nbsp;</td>
                 </tr>
                 <tr>
                     <td>
                         Teléfono</td>
                     <td>
                         <asp:TextBox ID="TxtTel" runat="server" Width="209px"></asp:TextBox> 
                     </td>
                     <td>
                         E-mail</td>
                     <td colspan="2">
                         <asp:TextBox ID="TxtEma" runat="server" ValidationGroup="Guardar" Width="210px"></asp:TextBox>
                     </td>
                     <td>
                         <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" 
                             ControlToValidate="TxtEma" ErrorMessage="Email, Campo Requerido" 
                             SetFocusOnError="True" ValidationGroup="Guardar">*</asp:RequiredFieldValidator>
                         <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" 
                             ControlToValidate="TxtEma" ErrorMessage="Email Incorrecto" 
                             SetFocusOnError="True" 
                             ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" 
                             ValidationGroup="Guardar">*</asp:RegularExpressionValidator>
                     </td>
                 </tr>
                 <tr>
                     <td>
                         Estado</td>
                     <td>
                         <asp:DropDownList ID="CbEst" runat="server" Width="210px">
                             <asp:ListItem Value="AC">Activo</asp:ListItem>
                             <asp:ListItem Value="IN">Inactivo</asp:ListItem>
                         </asp:DropDownList>

                     </td>
                     <td>
                         Tipo Tercero</td>
                         
                     <td>
                         <asp:DropDownList ID="CbTTcer" runat="server" DataSourceID="ObjTTer" 
                             DataTextField="TAG_NOM" DataValueField="TAG_COD" Width="180px">
                         </asp:DropDownList>
                     </td>
                     <td>
                         &nbsp;</td>
                     <td>
                         &nbsp;</td>
                 </tr>
                 <tr>
                     <td>
                         Cedula<br />
                         Representante </td>
                     <td>
                         <asp:TextBox ID="TxtCed" runat="server" Width="184px"></asp:TextBox>
                         <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" 
                             ControlToValidate="TxtCed" 
                             ErrorMessage="Cedula del Representante Legal, Requerida" 
                             ValidationGroup="Guardar">*</asp:RequiredFieldValidator>
                     </td>
                     <td>
                         Lugar expedicion</td>
                     <td>
                         <asp:TextBox ID="txLugarExp" runat="server" Width="184px"></asp:TextBox>
                     </td>
                     <td>
                         <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" 
                             
                             ErrorMessage="Falta Lugar de Expedicion de la Cedula del Representante Legal" 
                             ControlToValidate="txLugarExp" ValidationGroup="Guardar">*</asp:RequiredFieldValidator>
                     </td>
                     <td>
                         &nbsp;</td>
                 </tr>
                 <tr>
                     <td>
                         Nombre<br />
                         Representante</td>
                     <td colspan="3">
                        <asp:TextBox ID="TxtRep" runat="server" Width="444px"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" 
                        ControlToValidate="TxtNom" 
                        ErrorMessage="Nombre del Representante Legal, Requerida, Campo Requerido" 
                        ValidationGroup="Guardar">*</asp:RequiredFieldValidator>
                     </td>
                     <td>
                         &nbsp;</td>
                     <td>
                         &nbsp;</td>
                 </tr>
                 <tr>
                     <td>
                         Usuario</td>
                     <td>
                         <asp:TextBox ID="TxtUsu" runat="server" Enabled="False" Width="211px"></asp:TextBox>
                     </td>
                     <td>
                         Tipo Usuario</td>
                     <td>
                         <asp:DropDownList ID="CbTUsu" runat="server" DataSourceID="ObjTusua" 
                             DataTextField="TUS_NOM" DataValueField="TUS_COD" Width="214px">
                         </asp:DropDownList>
                     </td>
                     <td>
                         &nbsp;</td>
                     <td>
                         &nbsp;</td>
                 </tr>
                 <tr>
                     <td>
                         Observación</td>
                     <td>
                         &nbsp;</td>
                     <td>
                         &nbsp;</td>
                     <td>
                         &nbsp;</td>
                     <td>
                         &nbsp;</td>
                     <td>
                         &nbsp;</td>
                 </tr>
                 <tr>
                     <td colspan="6">
                         <asp:TextBox ID="TxtObs" runat="server" Height="65px" MaxLength="200" 
                             TextMode="MultiLine" Width="513px"></asp:TextBox>
                     </td>
                 </tr>
                 <tr>
                     <td>
                         &nbsp;</td>
                     <td>
                         &nbsp;</td>
                     <td>
                         <asp:ImageButton ID="BtnSave" runat="server" 
                             ImageUrl="~/images/Operaciones/save.png" onclick="Btnsave_Click" 
                             ValidationGroup="Guardar" />
                     </td>
                     <td>
                         <asp:ImageButton ID="BtnCancel" runat="server" CausesValidation="False" 
                             ImageUrl="~/images/Operaciones/undo.png" onclick="BtnCancel_Click" />
                     </td>
                     <td>
                         &nbsp;</td>
                     <td>
                         &nbsp;</td>
                 </tr>
                 <tr>
                     <td>
                         &nbsp;</td>
                     <td>
                         &nbsp;</td>
                     <td>
                         Guardar</td>
                     <td>
                         Cancelar</td>
                     <td>
                         &nbsp;</td>
                     <td>
                         &nbsp;</td>
                 </tr>
             </table>
             <asp:ObjectDataSource id="ObjMUN" runat="server" TypeName="Municipios" SelectMethod="GetRecords"></asp:ObjectDataSource> <asp:ObjectDataSource id="ObjTTer" runat="server" TypeName="TTerc" SelectMethod="GetRecords"></asp:ObjectDataSource> <asp:ObjectDataSource id="ObjTipDoc" runat="server" TypeName="TipCod" SelectMethod="GetRecords"></asp:ObjectDataSource> <asp:ObjectDataSource id="ObjTusua" runat="server" TypeName="TipUsu" SelectMethod="GetRecords"></asp:ObjectDataSource>&nbsp;&nbsp; <ajaxToolkit:TextBoxWatermarkExtender id="TextBoxWatermarkExtender1" watermarkText="Maximo 200 Caracteres" runat="server" TargetControlID="TxtObs" WatermarkCssClass="watermarked"></ajaxToolkit:TextBoxWatermarkExtender></asp:View>&nbsp;&nbsp; <asp:View id="View2" runat="server"></asp:View></asp:MultiView> <TABLE style="WIDTH: 573px; HEIGHT: 10px"><TBODY><TR><TD style="WIDTH: 100px">Nit/Nombre</TD><TD style="WIDTH: 290px" colSpan=1><asp:TextBox id="TxtFilNom" runat="server" Width="277px"> 
</asp:TextBox> </TD><TD style="WIDTH: 53px" colSpan=1><asp:ImageButton accessKey="b" id="BtnBuscar" onclick="BtnBuscar_Click" runat="server" AlternateText="Buscar" ImageUrl="~/images/Operaciones/search2.png" CausesValidation="False" CommandName="Buscar"></asp:ImageButton></TD><TD style="WIDTH: 49px" colSpan=5>&nbsp;<asp:ImageButton id="BtnAgregar" onclick="BtnAgregar_Click" runat="server" ImageUrl="~/images/Operaciones/New1.png" CausesValidation="False" CommandName="Nuevo"></asp:ImageButton></TD></TR><TR><TD style="WIDTH: 100px"></TD><TD style="WIDTH: 290px" colSpan=1></TD><TD style="WIDTH: 53px" colSpan=1>Buscar</TD><TD style="WIDTH: 49px" colSpan=5>Nuevo</TD></TR></TBODY></TABLE>&nbsp; <ajaxToolkit:AutoCompleteExtender id="autoComplete1" runat="server" TargetControlID="TxtFilNom" BehaviorID="AutoCompleteEx" CompletionInterval="1000" CompletionListCssClass="autocomplete_completionListElement" CompletionListHighlightedItemCssClass="autocomplete_highlightedListItem" CompletionListItemCssClass="autocomplete_listitem" CompletionSetCount="20" DelimiterCharacters=";, :" EnableCaching="true" MinimumPrefixLength="1" ServicePath="AutoComplete.asmx" ServiceMethod="GetTerceros">
        <Animations>
                    <OnShow>
                        <Sequence>
                            
                            <OpacityAction Opacity="0" />
                            <HideAction Visible="true" />
                            
                            
                            <ScriptAction Script="
                                // Cache the size and setup the initial size
                                var behavior = $find('AutoCompleteEx');
                                if (!behavior._height) {
                                    var target = behavior.get_completionList();
                                    behavior._height = target.offsetHeight - 2;
                                    target.style.height = '0px';
                                }" />
                            
                            
                            <Parallel Duration=".4">
                                <FadeIn />
                                <Length PropertyKey="height" StartValue="0" EndValueScript="$find('AutoCompleteEx')._height" />
                            </Parallel>
                        </Sequence>
                    </OnShow>
                    <OnHide>
                        
                        <Parallel Duration=".4">
                            <FadeOut />
                            <Length PropertyKey="height" StartValueScript="$find('AutoCompleteEx')._height" EndValue="0" />
                        </Parallel>
                    </OnHide></Animations>
    </ajaxToolkit:AutoCompleteExtender><BR />&nbsp; <DIV id="Div1"><asp:GridView id="GridView1" runat="server" DataSourceID="ObjTerceros" OnRowCommand="GridView1_RowCommand" OnRowDataBound="GridView1_RowDataBound" ShowFooter="True" DataKeyNames="ter_nit" AutoGenerateColumns="False" AllowPaging="True" OnSelectedIndexChanged="GridView1_SelectedIndexChanged"><Columns>
<asp:TemplateField HeaderText="Consecutivo" SortExpression="TER_CONS"><ItemTemplate>
<asp:Label id="LbCod" runat="server" Text='<%# Bind("TER_CONS") %>'></asp:Label> 
</ItemTemplate>
</asp:TemplateField>
<asp:TemplateField HeaderText="tipo Doc" SortExpression="TER_TDOC"><ItemTemplate>
                                <asp:Label ID="LbNom" runat="server" Text='<%# Bind("TER_TDOC") %>'></asp:Label>
                            
</ItemTemplate>
</asp:TemplateField>
<asp:TemplateField HeaderText="Nit" SortExpression="TER_NIT"><ItemTemplate>
                                <asp:Label ID="LbUni1" runat="server" Text='<%# Bind("TER_NIT") %>'></asp:Label>
                            
</ItemTemplate>
</asp:TemplateField>
<asp:TemplateField HeaderText="Nombre" SortExpression="TER_NOM"><ItemTemplate>
                                <asp:Label ID="LbUni2" runat="server" Text='<%# Bind("TER_NOM") %>'></asp:Label>
                            
</ItemTemplate>
</asp:TemplateField>
<asp:TemplateField HeaderText="Municipio" SortExpression="TER_MPIO"><ItemTemplate>
                                <asp:Label ID="LbBar" runat="server" Text='<%# Bind("TER_MPIO") %>'></asp:Label>
                            
</ItemTemplate>
</asp:TemplateField>
<asp:TemplateField HeaderText="Telefono" SortExpression="TER_TEL"><ItemTemplate>
                                <asp:Label ID="LbNor" runat="server" Text='<%# Bind("TER_TEL") %>'></asp:Label>
                            
</ItemTemplate>
</asp:TemplateField>
<asp:TemplateField HeaderText="Observaci&#243;n" SortExpression="TER_OBS"><ItemTemplate>
                                <asp:Label ID="LbObs" runat="server" Text='<%# Bind("TER_OBS") %>'></asp:Label>
                            
</ItemTemplate>
</asp:TemplateField>
<asp:TemplateField><ItemTemplate>
        <asp:ImageButton CommandName="Editar" CommandArgument='<%#Convert.ToInt32(DataBinder.Eval(Container, "DataItemIndex"))%>'
        id="BtnEdit" runat="server" ImageUrl="~/images/Operaciones/Edit2.png" tooltip="Editar"></asp:ImageButton>
    
</ItemTemplate>
</asp:TemplateField>
<asp:TemplateField><ItemTemplate>
        <asp:ImageButton CommandName="Eliminar" CommandArgument='<%#Convert.ToInt32(DataBinder.Eval(Container, "DataItemIndex"))%>'
        id="BtnElim" runat="server" ImageUrl="~/images/Operaciones/Delete2.png" tooltip="Eliminar"></asp:ImageButton>
    
</ItemTemplate>
</asp:TemplateField>
<asp:TemplateField><ItemTemplate>
        <asp:ImageButton CommandName="Seleccionar" CommandArgument='<%#Convert.ToInt32(DataBinder.Eval(Container, "DataItemIndex"))%>' 
        id="BtnSel" runat="server" ImageUrl="~/images/Operaciones/Select.png" tooltip="Seleccionar"></asp:ImageButton>
    
</ItemTemplate>
</asp:TemplateField>
</Columns>
<EmptyDataTemplate>
<BR /><asp:Label id="Label1" runat="server" Text="No se encontraron registros" CssClass="NoData" Width="166px"></asp:Label>
</EmptyDataTemplate>
</asp:GridView></DIV><BR /><DIV id="GRID"><asp:ObjectDataSource id="ObjTerceros" runat="server" TypeName="Signus.Terceros" SelectMethod="GetRecords" OldValuesParameterFormatString="original_{0}"><SelectParameters>
<asp:ControlParameter ControlID="TxtFilNom" PropertyName="Text" Name="busc" Type="String"></asp:ControlParameter>
</SelectParameters>
</asp:ObjectDataSource> </DIV>&nbsp;&nbsp;&nbsp;<asp:HiddenField id="Oper" runat="server"></asp:HiddenField> <asp:HiddenField id="HOldNit" runat="server"></asp:HiddenField> <asp:HiddenField id="HoldTDoc" runat="server"></asp:HiddenField> <asp:HiddenField id="HoldDVer" runat="server"></asp:HiddenField><BR />&nbsp; <BR />
</ContentTemplate>
            <Triggers>
                <asp:AsyncPostBackTrigger ControlID="BtnAgregar" EventName="Click" />
                <asp:AsyncPostBackTrigger ControlID="BtnBuscar" EventName="Click" />
                <asp:AsyncPostBackTrigger ControlID="BtnCancel" EventName="Click" />
                <asp:AsyncPostBackTrigger ControlID="BtnSave" EventName="Click" />
                <asp:AsyncPostBackTrigger ControlID="GridView1" EventName="RowCommand" />
            </Triggers>

        </asp:UpdatePanel>
        &nbsp;<br />
        <br />
        &nbsp;
        <asp:UpdateProgress ID="UpdateProgress1" runat="server" AssociatedUpdatePanelID="UpdatePanel1">
        <ProgressTemplate>
            <div class="Loading">
            <img src="../../images/loading.gif" alt="" title="" /> Cargando …
            </div>
        </ProgressTemplate>
        </asp:UpdateProgress>
    </div>
    &nbsp;</div>
</asp:Content>

