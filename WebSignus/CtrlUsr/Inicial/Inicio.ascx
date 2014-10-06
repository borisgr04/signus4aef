<%@ Control Language="VB" AutoEventWireup="false" CodeFile="Inicio.ascx.vb" Inherits="CtrlUsr_Inicial_Inicio" %>
<style type="text/css">
    .style1
    {
        width: 100%;
    }
    .TdIzq
    {
        width: 50px;
    }
    .class1 A:link 
    {
        text-decoration: none;
         color:Blue }
   .class1 A:link 
    {
         color:Blue }

    .class1 A:visited {text-decoration: none;color:Blue}
    .class1 A:active {text-decoration: none;color:Blue}
    .class1 A:hover {text-decoration: underline; color: red;color:Blue}
    
    .Hl {text-decoration: underline; color: red;color:Blue}

</style>
<p>
    <table class="style1">
        <tr>
            <td colspan="2">
    <b>PASOS PARA DILIGENCIAR FORMULARIO DE DECLARACIÓN</b>.</td>
        </tr>
        <tr>
            <td class="TdIzq" rowspan="2">
                <asp:Image ID="Image5" runat="server" 
                    ImageUrl="~/images/imagev2/Refresh_32x32.png" />
            </td>
            <td>
            <span class=class1>
                  <asp:HyperLink ID="HyperLink1" runat="server" 
                    NavigateUrl="~/DatosBasicos/MisDatos/MisDatos.aspx" CssClass="class1">1. ACTUALIZACIÓN DE LOS DATOS DE LA ENTIDAD.</asp:HyperLink>
                </span>
             </td>
        </tr>
        <tr>
            <td>
                Por favor mantenga actualizado los datos de su Entidad, Representante Legal, y 
                es muy importante el Email, donde se enviará información importante.</td>
        </tr>
        <tr>
            <td class="TdIzq">
                &nbsp;</td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td class="TdIzq" rowspan="2">
                <asp:Image ID="Image3" runat="server" 
                    ImageUrl="~/images/imagev2/signatarios.png" />
            </td>
            <td>
            <span class=class1>
                  <asp:HyperLink ID="HyperLink2" runat="server" 
                    NavigateUrl="~/DatosBasicos/AgentesR/Signatarios.aspx" CssClass="class1">2. ACTUALIZACIÓN DEL DECLARANTE Y CONTADOR O REVISOR FISCAL.</asp:HyperLink>
                </span>    
            </td>
        </tr>
        <tr>
            <td>
                Para declarar es obligación registrar al Declarante (Tesorero, Pagador o 
                Secretario de Hacienda) y al Contador o Revisor fiscal.</td>
        </tr>
        <tr>
            <td class="TdIzq">
                &nbsp;</td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td class="TdIzq" rowspan="2" valign="top">
                <asp:Image ID="Image1" runat="server" ImageUrl="~/images/imagev2/cargar1.png" />
            </td>
            <td>
            <span class="class1">
                  <asp:HyperLink ID="HyperLink3" runat="server" 
                    NavigateUrl="~/MediosM/Declaraciones/Validador.aspx" CssClass="class1">3. CARGAR Y VÁLIDAR MEDIOS MAGNÉTICOS.</asp:HyperLink>
                </span>
            </td>
        </tr>
        <tr>
            <td>
                Por favor descargue el formato que genera el archivo plano de acuerdo a la 
                declaración a diligenciar.
                Estampillas
                , Degüello, Registro. 
                <asp:HyperLink ID="HyperLink7" runat="server"  NavigateUrl="~/Formatos_Excel_Declaraciones/Formatos/fmt_declaraciones.xlsm"> Descargue aquí </asp:HyperLink>
                <asp:HyperLink ID="HyperLink8" runat="server"  NavigateUrl="~/Formatos_Excel_Declaraciones/Formatos/fmt_declaraciones.xls"> Descargue aquí Versión 2003</asp:HyperLink>
                <br />
                <div>
                <b>Video Tutorial Estampillas Vigencias Anteriores</b><br />
                <iframe src="https://skydrive.live.com/embed?cid=67F8F29659AF4B82&resid=67F8F29659AF4B82%21128&authkey=ACPNjRgo0vQpYB0" width="100" height="50" frameborder="0" scrolling="no"></iframe>
                <br /><b>Video Tutorial de Estampillas 2013 en Adelante</b><br />
                <iframe src="https://skydrive.live.com/embed?cid=67F8F29659AF4B82&resid=67F8F29659AF4B82%21119&authkey=ADppxh0MlYYP42s" width="100" height="50" frameborder="0" scrolling="no"></iframe>
                <br /><b>Video Tutorial Impuesto de Degüello de Ganado Mayor</b><br />
                <iframe src="https://skydrive.live.com/embed?cid=67F8F29659AF4B82&resid=67F8F29659AF4B82%21137&authkey=AF-o7LkejvZMpb8" width="100" height="50" frameborder="0" scrolling="no"></iframe>
                </div>
             </td>

        </tr>
        <tr>
            <td class="TdIzq">
                &nbsp;</td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td class="TdIzq" rowspan="2">
                <asp:Image ID="Image4" runat="server" 
                    ImageUrl="~/images/imagev2/diligenciar.png" />
            </td>
            <td>
                <span class=class1>
                  <asp:HyperLink ID="HyperLink4" runat="server" 
                    NavigateUrl="~/Declaraciones/Diligenciar/SelDec.aspx" CssClass="class1">4. DILIGENCIAR FORMULARIO DE DECLARACIÓN EN LINEA.</asp:HyperLink>
                </span>        </td>
        </tr>
        <tr>
            <td>
                Después de válidar su reporte de información mensual, por favor diligencia su 
                formulario de declaración, este debe ser impreso y firmado por las personas 
                correspondientes.</td>
        </tr>
        <tr>
            <td class="TdIzq">
                &nbsp;</td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td class="TdIzq" rowspan="2">
                <asp:Image ID="Image6" runat="server" 
                    ImageUrl="~/images/imagev2/Money-icon.png" />
            </td>
            <td>
                <span class=class1>
                  <asp:HyperLink ID="HyperLink5" runat="server" 
                    NavigateUrl="" CssClass="class1">5. REALIZAR EL PAGO EN LA ENTIDAD BANCARIA CORRESPONDIENTE.</asp:HyperLink>
                </span>
            </td>
        </tr>
        <tr>
            <td>
                Por favor realizar el pago en la entidad bancaria correspondiente dentro de los 
                dias de pago oportuno, para no generar el cobro de Sanciones e Intereses de 
                Mora.</td>
        </tr>
        <tr>
            <td class="TdIzq">
                &nbsp;</td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td class="TdIzq" rowspan="2">
                <asp:Image ID="Image2" runat="server" 
                    ImageUrl="~/images/imagev2/presentar.png" />
            </td>
            <td>

<span class=class1>
                <asp:HyperLink ID="HyperLink6" runat="server" 
                    NavigateUrl="" CssClass="class1">6. PRESENTAR LA DECLARACIÓN FIRMADA AUTOGRAFAMENTE Y EL PAGO EN LA OFICINA DE RENTAS.</asp:HyperLink>
                </span>

            </td>
        </tr>
        <tr>
            <td>

                Envie el formulario diligenciado y firmado de forma correcta a la Oficina de 
                Rentas de la Gobernación del Departamento del Cesar, dentro de los primeros 5 
                dias hábiles de cada mes para Estampillas y Registro. 
            </td>
        </tr>
        <tr>
            <td class="TdIzq">
                &nbsp;</td>
            <td>

                &nbsp;</td>
        </tr>
    </table>
</p>


