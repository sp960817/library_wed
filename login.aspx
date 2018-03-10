<%@ Page Language="C#" AutoEventWireup="true" CodeFile="login.aspx.cs" Inherits="login" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        .style1
        {
            text-align: center;
        }
        .style2
        {
            width: 100%;
        }
        .style3
        {
            width: 796px;
        }
        .style4
        {
            width: 796px;
            text-align: right;
        }
        .style5
        {
            text-align: left;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
        <h1 class="style1">
            <asp:Image ID="Image1" runat="server" Height="184px" ImageUrl="~/image/9.PNG" 
                Width="1149px" />
        </h1>
        <table class="style2">
            <tr>
                <td class="style4">
        用户名</td>
                <td class="style5">
                    <asp:TextBox ID="TextBox1" runat="server" BorderColor="#27B3FE" 
                        BorderStyle="Solid" BorderWidth="1px" Width="150px"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
            ControlToValidate="TextBox1" ErrorMessage="用户名为空"></asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td class="style4">
        密码</td>
                <td class="style5">
                    <asp:TextBox ID="TextBox2" runat="server" TextMode="Password" 
                        BorderColor="#27B3FE" BorderStyle="Solid" BorderWidth="1px" Width="150px"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" 
            ControlToValidate="TextBox2" ErrorMessage="密码为空"></asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td class="style4">
        验证码</td>
                <td class="style5">
                    <asp:TextBox ID="TextBox3" runat="server" BorderColor="#27B3FE" 
                        BorderStyle="Solid" BorderWidth="1px" Height="20px" Width="70px"></asp:TextBox>
                    &nbsp;<img alt="看不清，请单击我！" src="ValidateCode.aspx" style="cursor: hand; width: 52px;
                                    height: 14px; float: left;" onclick="this.src=this.src+'?'" /></td>
            </tr>
            <tr>
                <td class="style3">
                    &nbsp;</td>
                <td class="style5">
                    <asp:Button ID="Button1" runat="server" onclick="Button1_Click" Text="登陆" />
                    <asp:Button ID="Button2" runat="server" onclick="Button2_Click" Text="重置" />
                </td>
            </tr>
        </table>
    
    </div>
    </form>
</body>
</html>
