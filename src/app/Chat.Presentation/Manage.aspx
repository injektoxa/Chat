<%@ Page Title="" Language="C#" MasterPageFile="~/Chat.Master" AutoEventWireup="true" CodeBehind="Manage.aspx.cs" Inherits="Chat.Presentation.UI.Manage" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<%--   <div align="center">
    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" 
        DataSourceID="SqlDataSource1" 
        EmptyDataText="There are no data records to display." Height="16px" 
        Width="319px" BackColor="White" BorderColor="#3366CC" BorderStyle="None" 
           BorderWidth="1px" CellPadding="4">
        <Columns>
            <asp:BoundField DataField="Name" HeaderText="Name" SortExpression="Name" />
            <asp:BoundField DataField="Password" HeaderText="Password" 
                SortExpression="Password" />
        </Columns>
        <FooterStyle BackColor="#99CCCC" ForeColor="#003399" />
        <HeaderStyle BackColor="#003399" Font-Bold="True" ForeColor="#CCCCFF" />
        <PagerStyle BackColor="#99CCCC" ForeColor="#003399" HorizontalAlign="Left" />
        <RowStyle BackColor="White" ForeColor="#003399" />
        <SelectedRowStyle BackColor="#009999" Font-Bold="True" ForeColor="#CCFF99" />
        <SortedAscendingCellStyle BackColor="#EDF6F6" />
        <SortedAscendingHeaderStyle BackColor="#0D4AC4" />
        <SortedDescendingCellStyle BackColor="#D6DFDF" />
        <SortedDescendingHeaderStyle BackColor="#002876" />
    </asp:GridView>
    <asp:SqlDataSource ID="SqlDataSource1" runat="server" 
        ConnectionString="<%$ ConnectionStrings:TestDBConnectionString1 %>" 
        ProviderName="<%$ ConnectionStrings:TestDBConnectionString1.ProviderName %>" 
        SelectCommand="SELECT [Name], [Password] FROM [Users] WHERE ([Id] = @Id)">
        <SelectParameters>
            <asp:SessionParameter Name="Id" SessionField="userId" Type="Int32" />
        </SelectParameters>
    </asp:SqlDataSource>
    </div>--%>

</asp:Content>
