<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="LoginControl.ascx.cs"
    Inherits="Chat.Presentation.Controls.View.Impl.LoginControl" %>
<div class="login">
    <asp:Label ID="loginLbl" runat="server" Text="Login:"></asp:Label>
    <br />
    <asp:TextBox ID="LoginTb" runat="server"></asp:TextBox>
    <br>
    <asp:Label ID="PasswordLbl" runat="server" Text="Password:"></asp:Label>
    <br />
    <asp:TextBox ID="PasswordTb" runat="server"></asp:TextBox>
    <br>
    <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" />
    <br />
    <a href="Register.aspx">Sign up</a>
</div>
