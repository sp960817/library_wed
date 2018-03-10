using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MySql.Data.MySqlClient;
using System.Web.Configuration;
using System.Configuration;
public partial class book_recommend1 : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["AdminName"] == null)
        {
            Response.Redirect("login.aspx");
        }
        if(!IsPostBack)
        this.Label2.Text = Request.QueryString["id"];
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        string mysql = "UPDATE system_book SET bookrecommend = '" + TextBox2.Text + "'  WHERE bookid = " + Label2.Text + "";
        SqlHelper.GetExecuteNonQuery(mysql);
        Response.Write("<script langauge=javascript>alert('成功')</script>");
        
    }
    protected void Button2_Click(object sender, EventArgs e)
    {
        Response.Redirect("book_count.aspx");
    }
}