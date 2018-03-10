<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="ChangePw.aspx.cs" Inherits="_Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    要更改的密码<asp:TextBox ID="TextBox1" runat="server" TextMode="Password"></asp:TextBox>
    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
        ControlToValidate="TextBox1" ErrorMessage="不能为空" ValidationGroup="1"></asp:RequiredFieldValidator>
    <br />
    再输入一遍<asp:TextBox ID="TextBox2" runat="server" TextMode="Password"></asp:TextBox>
    <asp:CompareValidator ID="CompareValidator1" runat="server" 
        ControlToCompare="TextBox1" ControlToValidate="TextBox2" 
        ErrorMessage="两次密码不同" ValidationGroup="1"></asp:CompareValidator>
    <br />
    <asp:Button ID="Button1" runat="server" onclick="Button1_Click" Text="更改" 
        ValidationGroup="1" />
    &nbsp;&nbsp;
    <asp:Button ID="Button2" runat="server" onclick="Button2_Click" Text="取消" />
</asp:Content>

