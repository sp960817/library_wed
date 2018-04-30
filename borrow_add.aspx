<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="borrow_add.aspx.cs" Inherits="borrow_add" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <table>
     <tr>
            <td>
                  <h3>添加借阅信息</h3>
            </td>
        </tr>
         <tr>
            <td>
                 借阅的读者ID<asp:TextBox ID="TextBox2" runat="server"></asp:TextBox>
    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" 
        ControlToValidate="TextBox1" ErrorMessage="必填项" ValidationGroup="1"></asp:RequiredFieldValidator>
            </td>
        </tr>
         <tr>
            <td>
                 借阅的书籍ID<asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
        ControlToValidate="TextBox2" ErrorMessage="必填项" ValidationGroup="1"></asp:RequiredFieldValidator>
            </td>
        </tr>
         <tr>
            <td>
                借阅时间<asp:DropDownList ID="DropDownList1" runat="server">
    </asp:DropDownList>
    年<asp:DropDownList ID="DropDownList2" runat="server">
    </asp:DropDownList>
    月<asp:DropDownList ID="DropDownList3" runat="server">
    </asp:DropDownList>
    日
            </td>
        </tr>
         <tr>
            <td>
                 <asp:Button ID="Button1" runat="server" onclick="Button1_Click" Text="确定" 
        ValidationGroup="1" />
    &nbsp;&nbsp;
    <asp:Button ID="Button2" runat="server" Text="返回" onclick="Button2_Click" />
            </td>
        </tr>
</table>
</asp:Content>

