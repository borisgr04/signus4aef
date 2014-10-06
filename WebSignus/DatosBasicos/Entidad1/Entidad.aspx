<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="Entidad.aspx.vb" Inherits="DatosBasicos_Entidad1_Entidad" title="Untitled Page" %>
<asp:Content ID="Content1" ContentPlaceHolderID="SampleContent" Runat="Server">
<script language="javascript" type="text/javascript">
// <!CDATA[

function Button1_onclick() {

}

// ]]>
</script>


<div class="demoarea">
    &nbsp; &nbsp;&nbsp;
    <br />
    <table>
        <tr>
            <td colspan="3">
                <asp:Label ID="Label11" runat="server" CssClass="Titulo">Datos de la Entidad</asp:Label></td>
        </tr>
        <tr>
            <td colspan="3">
                <asp:Label ID="MsgResult" runat="server"></asp:Label></td>
        </tr>
        <tr>
            <td style="width: 98px">
                <asp:Label ID="Label4" runat="server" Text="Nit de la Entidad" Width="143px"></asp:Label></td>
            <td style="width: 95px">
                <asp:TextBox ID="TxtnitNew" runat="server" Width="214px"></asp:TextBox></td>
            <td style="width: 100px">
            </td>
        </tr>
        <tr>
            <td style="width: 98px; height: 23px">
                <asp:Label ID="Label1" runat="server" Text="Nombre de la Entidad" Width="126px"></asp:Label></td>
            <td style="width: 95px; height: 23px">
                <asp:TextBox ID="txtnomNew" runat="server" Width="214px"></asp:TextBox></td>
            <td style="width: 100px; height: 23px">
            </td>
        </tr>
        <tr>
            <td style="width: 98px; height: 18px">
                <asp:Label ID="Label2" runat="server" Text="Direccion de la Entidad" Width="117px"></asp:Label></td>
            <td style="width: 95px; height: 18px">
                <asp:TextBox ID="txtdirNew" runat="server" Width="215px"></asp:TextBox></td>
            <td style="width: 100px; height: 18px">
            </td>
        </tr>
        <tr>
            <td style="width: 98px; height: 19px">
                <asp:Label ID="Label3" runat="server" Text="Telefono de la Entidad" Width="151px"></asp:Label></td>
            <td style="width: 95px; height: 19px">
                <asp:TextBox ID="txttelNew" runat="server" Width="216px"></asp:TextBox></td>
            <td style="width: 100px; height: 19px">
            </td>
        </tr>
        <tr>
            <td style="width: 98px">
                <asp:Label ID="Label5" runat="server" Text="Email de la Entidad"></asp:Label></td>
            <td style="width: 95px">
                <asp:TextBox ID="txtemailNew" runat="server" Width="216px"></asp:TextBox></td>
            <td style="width: 100px">
                <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="txtemailNew"
                    ErrorMessage="Email No Vàlido" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*">*</asp:RegularExpressionValidator></td>
        </tr>
        <tr>
            <td style="width: 98px; height: 19px">
                <asp:Label ID="Label6" runat="server" Text="Departamento"></asp:Label></td>
            <td style="width: 95px; height: 19px">
                <asp:TextBox ID="txtdptoNew" runat="server" Width="215px"></asp:TextBox></td>
            <td style="width: 100px; height: 19px">
            </td>
        </tr>
        <tr>
            <td style="width: 98px; height: 17px">
                <asp:Label ID="Label7" runat="server" Text="Municipio de la Entidad" Width="145px"></asp:Label></td>
            <td style="width: 95px; height: 17px">
                <asp:TextBox ID="txtmpioNew" runat="server" Width="213px"></asp:TextBox></td>
            <td style="width: 100px; height: 17px">
            </td>
        </tr>
        <tr>
            <td style="width: 98px; height: 19px">
                <asp:Label ID="Label8" runat="server" Text="Cedula del Responsable" Width="145px"></asp:Label></td>
            <td style="width: 95px; height: 19px">
                <asp:TextBox ID="txtcedresNew" runat="server" Width="213px"></asp:TextBox></td>
            <td style="width: 100px; height: 19px">
            </td>
        </tr>
        <tr>
            <td style="width: 98px; height: 18px">
                <asp:Label ID="Label9" runat="server" Text="Nombre del Responsable" Width="133px"></asp:Label></td>
            <td style="width: 95px; height: 18px">
                <asp:TextBox ID="txtnomresNew" runat="server" Width="214px"></asp:TextBox></td>
            <td style="width: 100px; height: 18px">
            </td>
        </tr>
        <tr>
            <td style="width: 98px; height: 19px">
                <asp:Label ID="Label10" runat="server" Text="Logo de la Entidad"></asp:Label></td>
            <td style="width: 95px; height: 19px">
                <asp:TextBox ID="txtlogoNew" runat="server" Width="213px"></asp:TextBox></td>
            <td style="width: 100px; height: 19px">
            </td>
        </tr>
        <tr>
            <td style="width: 98px; height: 19px">
            </td>
            <td style="width: 95px; height: 19px">
            </td>
            <td style="width: 100px; height: 19px">
            </td>
        </tr>
        <tr>
            <td style="width: 98px; height: 19px">
                <asp:HiddenField ID="nit" runat="server" />
            </td>
            <td style="width: 95px; height: 19px">
                <asp:HiddenField ID="Oper" runat="server" />
            </td>
            <td style="width: 100px; height: 19px">
            </td>
        </tr>
        <tr>
            <td colspan="3" style="height: 22px; text-align: center">
                <asp:Button ID="BtnGuardar" runat="server" OnClick="BtnGuardar_Click" Text="Actualizar" />
                &nbsp;&nbsp;&nbsp;
            </td>
        </tr>
    </table>
    &nbsp;&nbsp;<br />
    &nbsp;&nbsp;<br />
    &nbsp; &nbsp;
    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<br />
</div>



</asp:Content>

