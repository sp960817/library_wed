using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MySql.Data.MySqlClient;
using System.Configuration;
using System.Web.Configuration;
public partial class book_stock_bookname : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["AdminName"] == null)
        {
            Response.Redirect("login.aspx");
        }
    }
    protected void LinkButton1_Click(object sender, EventArgs e)
    {
        string mysql = "SELECT bookstock FROM system_book WHERE bookname = '"+TextBox1.Text+"'";
        MySqlDataReader dr = SqlHelper.GetExecuteReader(mysql);
        dr.Read();
        Label1.Text = dr.GetString(0);
        SqlHelper.Closeconn();

        
        
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        string mysql = "UPDATE system_book SET bookstock = '"+TextBox2.Text+"' WHERE bookname ='"+ TextBox1.Text +"'";
        int count = SqlHelper.GetExecuteNonQuery(mysql);
        if (count > 0)
        {
            Response.Write("<script langauge=javascript>alert('成功')</script>");
            
        }
        else
        {
            Response.Write("<script langauge=javascript>alert('失败')</script>");

        }
    }
    protected void Button2_Click(object sender, EventArgs e)
    {
        Response.Redirect("admin.aspx");
    }
}