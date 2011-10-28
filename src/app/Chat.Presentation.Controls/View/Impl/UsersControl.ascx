<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="UsersControl.ascx.cs" Inherits="Chat.Presentation.Controls.View.Impl.DeletUserFromRoomControl" %>

<div class= "userPanelControl" id="UserControlDiv" >
<%
 Menu();
%>
<asp:checkboxlist ID ="check1" runat="server">
</asp:checkboxlist> 
    <asp:Button ID="DeleteBtn" runat="server" Text="Delete" 
        onclick="DeleteBtn_Click" />
</div>

  