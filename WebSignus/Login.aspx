<%@ Page Language="VB" AutoEventWireup="false" CodeFile="Login.aspx.vb" Inherits="Login" %>

<%@ Register Assembly="eWorld.UI, Version=2.0.6.2393, Culture=neutral, PublicKeyToken=24d65337282035f2"
    Namespace="eWorld.UI" TagPrefix="ew" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
    <title>Signus.. Departamento del Cesar - Sistema de Declaraciones en Linea</title>
    <link type="text/css" media="all" href="imgLogin/estiloLogin.css" rel="Stylesheet" />

    <script language="javascript" type="text/javascript">
            function alCargar() {
                var txtUserName = document.getElementById("txtUserName");
                if (txtUserName) {
                    document.getElementById("txtUserName").focus();
                }
            }
    </script>
</head>
<body onload="alCargar()">
    <form id="form1" runat="server">
    <div class="logosignus"></div>
    <br />
    <div class="arab"><img src="imgLogin/arab1.png"  /></div>
     <div class="usuario"> <img src="imgLogin/Usuario.png" alt="Usuario" 
                   style="height: 246px; width: 230px"/></div>
                   
                   <div class="acceso">
                   
                   <table  class="tablitas" >
          
          <tr>
          <td><label>Usuario:</label> </td>
          <td>
              <asp:TextBox ID="txtUserName" runat="server" ClientIDMode="Static"></asp:TextBox></td>

          </tr>
            <tr>
          <td><label>Contraseña:</label> </td>
          <td><asp:TextBox ID="TxtClave" runat="server" TextMode="Password"></asp:TextBox></td>

          </tr>
         
            <tr>
          <td>&nbsp;</td>
          <td>
              <asp:Label ID="MsgResult" runat="server" ForeColor="#CC3300"></asp:Label>
                </td>

          </tr>
         
            <tr>
          <td>&nbsp;</td>
          <td>
              <asp:Button ID="BtnIniciarSesion" runat="server" Text="Iniciar Sesión" />
                </td>

          </tr>
         
          </table>
    </div>
   <div class="logoemp"></div><div class="logoempresa"></div>
    </form>
</body>
</html>

