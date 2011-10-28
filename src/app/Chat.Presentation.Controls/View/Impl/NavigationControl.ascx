<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="NavigationControl.ascx.cs" Inherits="Chat.Presentation.Controls.View.Impl.NavigationControl" %>

<% if (Session["userRole"] == "0")
   {
       NavigationPanel.Visible = false;
   } 
   %>

<asp:panel ID="NavigationPanel" runat="server">
 <div class= "logo" id="div1" >
 <a href="Login.aspx">Main</a> 
 <br/>
<a href="Login.aspx?leave=true">Leave chat</a> 
<br/>
<a href="Rooms.aspx">All chats</a>
<br/>
<a href="CreateRoom.aspx">Create chat</a>
<br/>
<a href="Manage.aspx">Manage own profile</a>
</div>
</asp:panel>