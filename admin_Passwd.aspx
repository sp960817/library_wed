<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="admin_Passwd.aspx.cs" Inherits="admin_Passwd" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <style type="text/css">
        .style8
        {
            width: 464px;
        }
        .style9
        {
            text-align: center;
        }
        .style10
        {
            width: 464px;
            height: 20px;
        }
        .style11
        {
            height: 20px;
        }
        .style12
        {
            height: 20px;
            width: 319px;
        }
        .style13
        {
            width: 319px;
        }
        .style14
        {
            width: 464px;
            height: 23px;
        }
        .style15
        {
            width: 319px;
            height: 23px;
        }
        .style16
        {
            height: 23px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <table style="text-align: center" " class="style7">
        <tr>
            <td  colspan="3" dir="rtl">
               <h3> 修改登录密码</h3></td>
        </tr>
        <tr>
            <td  dir="rtl">
                请输入密码</td>
            <td >
                <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
            </td>
            <td >
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
                    ControlToValidate="TextBox1" Display="Dynamic" ErrorMessage="必须输入密码" 
                    ForeColor="Red"></asp:RequiredFieldValidator>
                <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" 
                    ControlToValidate="TextBox1" Display="Dynamic" ErrorMessage="只能输入数字或字母" 
                    ForeColor="Red" ValidationExpression="[A-Za-z0-9]+$"></asp:RegularExpressionValidator>
            </td>
        </tr>
        <tr>
            <td  dir="rtl">
                再次输入密码</td>
            <td >
                <asp:TextBox ID="TextBox2" runat="server"></asp:TextBox>
            </td>
            <td >
                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" 
                    ControlToValidate="TextBox2" Display="Dynamic" ErrorMessage="必须输入密码" 
                    ForeColor="Red"></asp:RequiredFieldValidator>
                <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" 
                    ControlToValidate="TextBox2" Display="Dynamic" ErrorMessage="只能输入数字或字母" 
                    ForeColor="Red" ValidationExpression="[A-Za-z0-9]+$"></asp:RegularExpressionValidator>
            </td>
        </tr>
        <tr>
            <td  dir="rtl">
                &nbsp;</td>
            <td >
                <asp:Button ID="Button1" runat="server" onclick="Button1_Click" Text="修改" />
                <asp:Button ID="Button2" runat="server" Text="返回" />
            </td>
        </tr>
    </table>
</asp:Content>

