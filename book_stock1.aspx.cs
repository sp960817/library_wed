using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using System.Web.Configuration;
using MySql.Data.MySqlClient;
public partial class book_stock1 : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["AdminName"] == null)
        {
            Response.Redirect("login.aspx");
        }
        if (!IsPostBack)
        {
            this.Label1.Text = Request.QueryString["id"];
            string mysql = "SELECT bookstock FROM system_book WHERE bookid = '" + Label1.Text + "'";
            MySqlDataReader dr = SqlHelper.GetExecuteReader(mysql);
            if (dr.Read())
            {
                this.Label2.Text = dr["bookstock"].ToString();
                dr.Close();
                SqlHelper.Closeconn();
            }
            else
            {
                dr.Close();
                SqlHelper.Closeconn();
            }
        }
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        string mysql = "UPDATE system_book SET bookstock = '" + TextBox1.Text + "' WHERE bookid ='" + Label1.Text + "'";
        int count = SqlHelper.GetExecuteNonQuery(mysql);
        if (count > 0)
        {
            Response.Write("<script langauge=javascript>alert('成功')</script>");
            string mysql1 = "SELECT bookstock FROM system_book WHERE bookid = '" + Label1.Text + "'";
            MySqlDataReader dr = SqlHelper.GetExecuteReader(mysql1);
            if (dr.Read())
            {
                this.Label2.Text = dr["bookstock"].ToString();
                dr.Close();
                SqlHelper.Closeconn();
            }
            else
            {
                dr.Close();
                SqlHelper.Closeconn();
            }
        }
        else
        {
            Response.Write("<script langauge=javascript>alert('失败')</script>");
        }
    }
    protected void Button2_Click(object sender, EventArgs e)
    {
        Response.Redirect("book_count.aspx");
    }
}