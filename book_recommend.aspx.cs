using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MySql.Data.MySqlClient;
using System.Web.Configuration;
using System.Configuration;
public partial class book_recommend : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["AdminName"] == null)
        {
            Response.Redirect("login.aspx");
        }
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        string mysql = "SELECT * FROM system_book WHERE bookid = " + TextBox1.Text + "";
        string mysql1 = "UPDATE system_book SET bookrecommend='" + TextBox2.Text + "',booklv = "+DropDownList1.Text+" WHERE bookid=" + TextBox1.Text + "";
        using(MySqlDataReader dr = SqlHelper.GetExecuteReader(mysql))
            if (dr.Read())
          {
              SqlHelper.Closeconn(); 
              dr.Close();
              int count =SqlHelper.GetExecuteNonQuery(mysql1);
              if (count > 0)
              {
                  Response.Write("<script langauge=javascript>alert('成功')</script>");
              }
              else
                  Response.Write("<script langauge=javascript>alert('失败')</script>");
             
          }
           else
            {
                Response.Write("<script langauge=javascript>alert('失败')</script>");
                dr.Close();
                SqlHelper.Closeconn();
            }
        
    }
    protected void Button2_Click(object sender, EventArgs e)
    {
        Response.Redirect("admin.aspx");
    }
}