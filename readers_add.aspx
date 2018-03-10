<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="readers_add.aspx.cs" Inherits="readers_add" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    读者ID<asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
    ControlToValidate="TextBox1" ErrorMessage="不能为空" ValidationGroup="1"></asp:RequiredFieldValidator>
<br />
密码<asp:TextBox ID="TextBox2" runat="server" TextMode="Password"></asp:TextBox>
    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" 
    ControlToValidate="TextBox2" ErrorMessage="不能为空" ValidationGroup="1"></asp:RequiredFieldValidator>
<br />
姓名<asp:TextBox ID="TextBox3" runat="server"></asp:TextBox>
    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" 
    ControlToValidate="TextBox3" ErrorMessage="不能为空" ValidationGroup="1"></asp:RequiredFieldValidator>
<br />
    <asp:Button ID="Button1" runat="server" Text="添加" onclick="Button1_Click" 
        ValidationGroup="1" />
    &nbsp;&nbsp;
    <asp:Button ID="Button2" runat="server" Text="返回" onclick="Button2_Click" 
        Height="27px" Width="55px" />
</asp:Content>

