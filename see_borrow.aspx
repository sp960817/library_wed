<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="see_borrow.aspx.cs" Inherits="see_borrow" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <asp:GridView ID="GridView1" runat="server" BackColor="White" 
        BorderColor="#999999" BorderStyle="None" BorderWidth="1px" CellPadding="3" 
        GridLines="Vertical" DataKeyNames="借阅ID" 
        onselectedindexchanging="GridView1_SelectedIndexChanging" 
        onrowdeleting="GridView1_RowDeleting" AllowPaging="True" 
        onpageindexchanging="GridView1_PageIndexChanging">
        <AlternatingRowStyle BackColor="#DCDCDC" />
        <Columns>
            <asp:CommandField SelectText="归还" ShowSelectButton="True" />
            <asp:CommandField DeleteText="书籍丢失" ShowDeleteButton="True" />
        </Columns>
        <FooterStyle BackColor="#CCCCCC" ForeColor="Black" />
        <HeaderStyle BackColor="#000084" Font-Bold="True" ForeColor="White" />
        <PagerStyle BackColor="#999999" ForeColor="Black" HorizontalAlign="Center" />
        <RowStyle BackColor="#EEEEEE" ForeColor="Black" />
        <SelectedRowStyle BackColor="#008A8C" Font-Bold="True" ForeColor="White" />
        <SortedAscendingCellStyle BackColor="#F1F1F1" />
        <SortedAscendingHeaderStyle BackColor="#0000A9" />
        <SortedDescendingCellStyle BackColor="#CAC9C9" />
        <SortedDescendingHeaderStyle BackColor="#000065" />
</asp:GridView>
<asp:Label ID="Label1" runat="server" Text="Label"></asp:Label>
</asp:Content>

