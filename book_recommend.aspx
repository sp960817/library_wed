<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="book_recommend.aspx.cs" Inherits="book_recommend" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <table>
    <tr>
        <td colspan="2" class="tdleft">
             您要写推荐语的id是<asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
             <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" 
            ControlToValidate="TextBox1" ErrorMessage="ID不能为空"></asp:RequiredFieldValidator>

        </td>
    </tr>
    <tr>
        <td>
        推荐语：
        </td >
        <td>
        <asp:TextBox ID="TextBox2" runat="server" Height="317px" Width="600px"></asp:TextBox>
        
        </td>
    </tr>
    <tr>
        <td>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" 
            ControlToValidate="TextBox2" ErrorMessage="内容不能为空" ValidationGroup="1"></asp:RequiredFieldValidator>
        </td>
    </tr>
    <tr>
        <td>
             推荐等级<asp:DropDownList ID="DropDownList1" runat="server">
            <asp:ListItem>1</asp:ListItem>
            <asp:ListItem>2</asp:ListItem>
            <asp:ListItem>3</asp:ListItem>
            <asp:ListItem Value="4"></asp:ListItem>
            <asp:ListItem>5</asp:ListItem>
        </asp:DropDownList>
        </td>
    </tr>
    <tr>
        <td>
             <asp:Button ID="Button3" runat="server" onclick="Button1_Click" Text="确认" 
            ValidationGroup="1" />
        <asp:Button ID="Button4" runat="server" onclick="Button2_Click" Text="返回" />
        </td>
    </tr>
</table>
</asp:Content>

