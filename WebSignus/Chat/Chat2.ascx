<%@ Control Language="C#" AutoEventWireup="true" CodeFile="Chat2.ascx.cs" Inherits="UserControls_Chat_Chat2" %>
<%@ Register Assembly="Chat" Namespace="Subgurim.Chat" TagPrefix="cc1" %>
    
    
    <cc1:SubgurimChatManager ID="SubgurimChatManager1" runat="server" />
    <style>
    .sc_chat_container
    {
        height: 300px;
        width: 200px;
        font-family: arial;
        border: solid 1px black;
        padding: 2px;
        font-size: 11px;
        background-color: #ffffff;
        
        text-align: left;
    }
    
    .sc_chat_container input
    {
        margin: 0px;
        border: 1px groove #bbbbbb;    
    }
    
    .sc_chat_box
    {
        height: 260px;
    }  
    
    .sc_options_box
    {

    }
        
    .sc_msg
    {
        padding-left: 3px;
        padding-right: 3px;
        padding-top: 1px;
        padding-bottom: 1px;
    }    
    
    .sc_alt
    {
        padding-top: 0px;
        padding-bottom: 0px;
        background-color: #dedede;
    }    
    
    .sc_Author
    {
        font-weight: bold;
    }  
       
    .sc_chat_message
    {
        width: 140px;
        margin:0px;
    }    
       
    .sc_chat_send
    {
        width: 50px;
        text-align:center;
    }    

    </style>

    <div class="sc_chat_container">
        <div class="sc_chat_box" style="overflow: scroll;" id="chat">
            <span id="sc_loading" style="text-decoration:blink; font-weight:bold;">Loading...</span>
        </div>
        <div class="sc_options_box">
            <div>
                <input type="text" size="15" id="username" class="sc_chat_username" value="<%= nombreUsuario() %>" onfocus="this.focus();this.select();" />
            </div>
            <div>
                <input type="text" size="15" id="message" class="sc_chat_message" onkeypress="return sc_KeyPress(this, event);" />
                <input type="button" value="Enviar" onclick="insertarMensaje()" class="sc_chat_send" />
            </div>
        </div>
    </div>
