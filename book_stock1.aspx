<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="book_stock1.aspx.cs" Inherits="book_stock1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <table>
         <tr>
            <td class="tdleft">
                  您要编辑库存的图书ID是<asp:Label ID="Label1" runat="server" Text="Label"></asp:Label>
&nbsp;库存为<asp:Label ID="Label2" runat="server" Text="Label"></asp:Label>
            </td>
        </tr>
         <tr>
            <td>
                 库存更改为<asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
        ErrorMessage="不能为空" ValidationGroup="1" ControlToValidate="TextBox1"></asp:RequiredFieldValidator>
    <asp:RangeValidator ID="RangeValidator1" runat="server" 
        ControlToValidate="TextBox1" ErrorMessage="必须为数字" MaximumValue="2555555555" 
        MinimumValue="0" ValidationGroup="1"></asp:RangeValidator>
            </td>
        </tr>
         <tr>
            <td>
                <asp:Button ID="Button1" runat="server" onclick="Button1_Click" Text="确定" 
        ValidationGroup="1" />
    &nbsp;&nbsp;
    <asp:Button ID="Button2" runat="server" onclick="Button2_Click" Text="返回" />
            </td>
        </tr>
    </table>

</asp:Content>

