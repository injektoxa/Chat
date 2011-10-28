<%@ Page Title="" Language="C#" MasterPageFile="~/Chat.Master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="Chat.Presentation.UI.Login" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
<div align="center">  
<H2> <asp:Label ID="RoomNameLbl" runat="server" /> </H2>
 </div>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server"> 
    <asp:PlaceHolder ID="MessageControlHolder" runat="server" />
</asp:Content>
