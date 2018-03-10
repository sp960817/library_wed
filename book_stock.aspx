<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="book_stock.aspx.cs" Inherits="book_stock" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <p>
    <asp:Button ID="Button1" runat="server" onclick="Button1_Click" 
        Text="按照书籍名更改库存" />
    &nbsp;&nbsp;
    <asp:Button ID="Button2" runat="server" onclick="Button2_Click" 
        Text="按照ID更改库存" />
</p>
<p>
    &nbsp;</p>
<p>
    &nbsp;</p>
</asp:Content>

