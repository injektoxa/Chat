<%@ Page Title="" Language="C#" MasterPageFile="~/Chat.Master" AutoEventWireup="true"
    CodeBehind="Rooms.aspx.cs" Inherits="Chat.Presentation.UI.WebForm1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:Panel ID="panelRoom" align="center" runat="server">
        <% foreach (var room in Rooms)
           {
               Response.Write("<a href = \"Login.aspx?roomId=" + room.Key + "\" value=" + room.Value + ">" + room.Value + "</a>");
               Response.Write("<BR/>");
           }
        %>
    </asp:Panel>
</asp:Content>
