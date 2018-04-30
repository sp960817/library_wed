<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="book_change.aspx.cs" Inherits="book_change" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <style type="text/css">
    .style5
    {
        width: 100%;
    }
</style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
        <asp:GridView ID="GridView1" runat="server" 
            onselectedindexchanged="GridView1_SelectedIndexChanged" BackColor="White" 
            BorderColor="#999999" BorderStyle="None" BorderWidth="1px" CellPadding="3" 
            GridLines="Vertical">
            <AlternatingRowStyle BackColor="#DCDCDC" />
            <FooterStyle BackColor="#CCCCCC" ForeColor="Black" />
            <HeaderStyle BackColor="#000084" Font-Bold="True" ForeColor="White" />
            <PagerStyle BackColor="#999999" ForeColor="Black" HorizontalAlign="Center" />
            <RowStyle BackColor="#EEEEEE" ForeColor="Black" />
            <SelectedRowStyle BackColor="#008A8C" Font-Bold="True" ForeColor="White" />
            <SortedAscendingCellStyle BackColor="#F1F1F1" />
            <SortedAscendingHeaderStyle BackColor="#0000A9" />
            <SortedDescendingCellStyle BackColor="#CAC9C9" />
            <SortedDescendingHeaderStyle BackColor="#000065" />
        </asp:GridView>
  
        <table class="style5">
            <tr>
                <td class="style6">
        想更改书籍的什么项目<asp:DropDownList ID="DropDownList1" runat="server" 
            AutoPostBack="True" onselectedindexchanged="DropDownList1_SelectedIndexChanged">
            <asp:ListItem>——请选择——</asp:ListItem>
            <asp:ListItem Value="bookname">书名</asp:ListItem>
            <asp:ListItem Value="bookstyle">书籍分类</asp:ListItem>
            <asp:ListItem Value="bookauther">书籍作者</asp:ListItem>
            <asp:ListItem Value="bookpub">出版社</asp:ListItem>
            <asp:ListItem Value="bookpubdate">出版时间</asp:ListItem>
        </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td class="style7">
                    更改为<asp:TextBox ID="TextBox1" runat="server" 
            ontextchanged="TextBox1_TextChanged"></asp:TextBox>
        <asp:DropDownList ID="DropDownList5" runat="server">
        </asp:DropDownList>
        <asp:DropDownList ID="DropDownList2" runat="server">
        </asp:DropDownList>
        <asp:Label ID="Label1" runat="server" Text="年"></asp:Label>
        <asp:DropDownList ID="DropDownList3" runat="server">
        </asp:DropDownList>
        <asp:Label ID="Label2" runat="server" Text="月"></asp:Label>
        <asp:DropDownList ID="DropDownList4" runat="server">
        </asp:DropDownList>
        <asp:Label ID="Label3" runat="server" Text="日"></asp:Label>
                </td>
            </tr>
            <tr>
                <td>
        <asp:Button ID="Button1" runat="server" onclick="Button1_Click" Text="确定" />
        &nbsp;&nbsp;&nbsp;
        <asp:Button ID="Button2" runat="server" onclick="Button2_Click" Text="返回" />
                </td>
            </tr>
        </table>
</asp:Content>

