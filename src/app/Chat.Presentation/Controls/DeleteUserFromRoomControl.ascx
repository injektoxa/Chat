<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="DeleteUserFromRoomControl.ascx.cs" Inherits="Chat.Presentation.Controls.View.Impl.DeletUserFromRoomControl" %>
<br/>
<% for (int i = 0; i < 10; i++)
   {
       Response.Write("<input type=\"checkbox\" name=\"ch\"> Name <br/>");
   } %>
   <button id = "button1">Delete</button>