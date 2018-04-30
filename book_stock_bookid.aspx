<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="book_stock_bookid.aspx.cs" Inherits="boook_stock_bookid" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <table>
        <tr>
        <td class="tdleft">
             您要更改库存的书籍ID是<asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
        ControlToValidate="TextBox1" ErrorMessage="不能为空" ValidationGroup="1"></asp:RequiredFieldValidator>
        </td>
        </tr>
        <tr>
            <td class="tdleft">
                    <asp:LinkButton ID="LinkButton1" runat="server" onclick="LinkButton1_Click" 
        ValidationGroup="ValidataGroup1">查看当前库存</asp:LinkButton>
    <asp:Label ID="Label1" runat="server"></asp:Label>
            </td>
        </tr>
         <tr>
            <td class="tdleft">
                 库存更改为<asp:TextBox ID="TextBox2" runat="server"></asp:TextBox>
    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" 
        ControlToValidate="TextBox2" ErrorMessage="不能为空" ValidationGroup="1"></asp:RequiredFieldValidator>
    <asp:RangeValidator ID="RangeValidator1" runat="server" 
        ControlToValidate="TextBox2" ErrorMessage="必须为数字" MaximumValue="255555555" 
        MinimumValue="0" Type="Integer" ValidationGroup="1"></asp:RangeValidator>
            </td>
        </tr>
         <tr>
            <td>
                 <asp:Button ID="Button1" runat="server" onclick="Button1_Click" Text="更改" 
        ValidationGroup="1" />
    &nbsp;&nbsp;
    <asp:Button ID="Button2" runat="server" onclick="Button2_Click" Text="返回" />
            </td>
        </tr>
    </table>
</asp:Content>

