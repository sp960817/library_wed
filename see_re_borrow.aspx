<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="see_re_borrow.aspx.cs" Inherits="see_re_borrow" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <asp:GridView ID="GridView1" runat="server" DataKeyNames="借阅ID" 
    onselectedindexchanging="GridView1_SelectedIndexChanging" BackColor="White" 
    BorderColor="#999999" BorderStyle="None" BorderWidth="1px" CellPadding="3" 
        GridLines="Vertical" AllowPaging="True" 
        onpageindexchanging="GridView1_PageIndexChanging" 
        onrowdeleting="GridView1_RowDeleting" 
    >
        <AlternatingRowStyle BackColor="#DCDCDC" />
        <Columns>
            <asp:CommandField SelectText="借阅" ShowSelectButton="True" />
            <asp:CommandField ShowDeleteButton="True" />
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
    </asp:Content>

