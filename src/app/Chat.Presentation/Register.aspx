<%@ Page Title="" Language="C#" MasterPageFile="~/Chat.Master" AutoEventWireup="true"
    CodeBehind="Register.aspx.cs" Inherits="Chat.Presentation.UI.Register" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div align="center">
        Name:&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:TextBox ID="NameTB" runat="server"></asp:TextBox>
        <br />
        Password:&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:TextBox ID="PasswordTB" runat="server"></asp:TextBox>
        <br />
        Confirm password:
        <asp:TextBox ID="ConfirmTB" runat="server"></asp:TextBox>
        <br />
        <asp:Button ID="Button1" runat="server" Text="Sign up" OnClick="Button1_Click" />
    </div>
</asp:Content>
