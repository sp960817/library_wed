using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MySql.Data.MySqlClient;
public partial class see_book : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["AdminName"] == null)
        {
            Response.Redirect("login.aspx");
        }
        string id = Request.QueryString["id"];
        string mysql = "SELECT bookrecommend FROM system_book WHERE bookid = '" + id + "'";
        MySqlDataReader dr = SqlHelper.GetExecuteReader(mysql);
        if (dr.Read())
        {
            Label1.Text = dr["bookrecommend"].ToString();
            dr.Close();
            SqlHelper.Closeconn();
        }
        else
        {
            Response.Write("<script langauge=javascript>alert('失败')</script>");
            dr.Close();
            SqlHelper.Closeconn();

        }
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        Response.Redirect("book_count.aspx");
    }
}