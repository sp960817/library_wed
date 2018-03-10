<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="admin.aspx.cs" Inherits="admin" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    欢迎 
    <asp:Label ID="Label3" runat="server" Text="Label"></asp:Label>
    老师 登陆，现在时间是<asp:Label ID="Label1" runat="server" Text="Label"></asp:Label>
    。<br />
    <asp:Label ID="Label2" runat="server" Text="Label"></asp:Label>
</asp:Content>

