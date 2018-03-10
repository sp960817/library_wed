<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="book_add.aspx.cs" Inherits="book_add" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <style type="text/css">
    .style5
    {
        width: 100%;
    }
    .style6
    {
        height: 31px;
    }
    .style7
    {
        width: 542px;
    }
    .style8
    {
        height: 31px;
        width: 542px;
    }
    .style9
    {
        width: 542px;
        height: 40px;
    }
    .style10
    {
        height: 40px;
    }
    .style11
    {
        width: 542px;
        height: 78px;
    }
    .style12
    {
        height: 78px;
    }
</style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <p>
        &nbsp;</p>
    <table class="style5">
        <tr>
            <td class="style11">
        请填写需要添加的书籍信息（*为必填项）</td>
            <td class="style12">
            </td>
        </tr>
        <tr>
            <td class="style8">
    书籍名称*<asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
            </td>
            <td class="style6">
    书籍分类*<asp:DropDownList ID="DropDownList1" runat="server" >
    </asp:DropDownList>
    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
    ControlToValidate="TextBox1" ErrorMessage="必填项" ValidationGroup="1"></asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td class="style7">
    书籍作者<asp:TextBox ID="TextBox2" runat="server"></asp:TextBox>
    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" 
    ControlToValidate="DropDownList1" ErrorMessage="必填项" ValidationGroup="1"></asp:RequiredFieldValidator>
            </td>
            <td>
    库存*<asp:TextBox ID="TextBox3" runat="server"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" 
    ControlToValidate="TextBox3" ErrorMessage="必填项" ValidationGroup="1"></asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td class="style7">
    出版社<asp:TextBox ID="TextBox4" runat="server"></asp:TextBox>
            </td>
            <td>
    出版时间<asp:DropDownList ID="DropDownList2" runat="server" AutoPostBack="True" >
    </asp:DropDownList>
    年<asp:DropDownList ID="DropDownList3" runat="server" AutoPostBack="True"   >
    </asp:DropDownList>
    月<asp:DropDownList ID="DropDownList4" runat="server" AutoPostBack="True">
    </asp:DropDownList>
    日</td>
        </tr>
        <tr>
            <td class="style9">
            </td>
            <td class="style10">
            </td>
        </tr>
        <tr>
            <td class="style7">
        <asp:Button ID="Button1" runat="server" onclick="Button1_Click" Text="添加" 
            ValidationGroup="1" />
        &nbsp;&nbsp;&nbsp;&nbsp;
        <asp:Button ID="Button2" runat="server" Text="返回" onclick="Button2_Click" />
            </td>
            <td>
                &nbsp;</td>
        </tr>
</table>
    <br />
    <p>
        &nbsp;</p>
</asp:Content>

