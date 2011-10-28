<%@ Page Title="" Language="C#" MasterPageFile="~/Chat.Master" AutoEventWireup="true"
    CodeBehind="CreateRoom.aspx.cs" Inherits="Chat.Presentation.UI.Create" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div align="center">
        <asp:Label ID="Label1" runat="server" Text="Name of the room: "></asp:Label>
        <asp:TextBox ID="RoomNameTb" runat="server"></asp:TextBox>
        <br />
        <br />
        <br />
        <asp:Button ID="CreateBtn" runat="server" Text="Create" onclick="Button1_Click" />
    </div>
</asp:Content>
