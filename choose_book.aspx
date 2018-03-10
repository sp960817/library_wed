<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="choose_book.aspx.cs" Inherits="choose" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <asp:Button ID="Button1" runat="server" onclick="Button1_Click" Text="库存管理" />
    &nbsp;<asp:Button ID="Button2" runat="server" onclick="Button2_Click" Text="书籍推荐" />
    &nbsp;<asp:Button ID="Button3" runat="server" Text="书籍信息更改" onclick="Button3_Click" />
    &nbsp;<asp:Button ID="Button4" runat="server" onclick="Button4_Click" Text="删除书籍" />
</asp:Content>

