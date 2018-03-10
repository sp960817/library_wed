using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class _Default : System.Web.UI.Page
{
    protected string  id()
    {
        string b = Request.QueryString["id"];
        return b;
    }
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["AdminName"] == null)
        {
            Response.Redirect("login.aspx");
        }
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        string mysql = "UPDATE system_readers SET readerpw = '" + TextBox1.Text + "' WHERE readerid= '" + id() + "'";
        int count = SqlHelper.GetExecuteNonQuery(mysql);
        if (count > 0)
        {
            Response.Write("<script langauge=javascript>alert('更改成功')</script>");
        }
        else 
        {
            Response.Write("<script langauge=javascript>alert('更改失败')</script>");
        }
    }
    protected void Button2_Click(object sender, EventArgs e)
    {
        Response.Redirect("readers_count");
    }
}