using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using System.Web.Configuration;
using MySql.Data.MySqlClient;
public partial class choose : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["AdminName"] == null)
        {
            Response.Redirect("login.aspx");
        }
        if (!IsPostBack)
        {
            Button4.Attributes.Add("onclick", "return confirm('确定删除？')");
        }

    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        string id = Request.QueryString["id"];
        Response.Redirect("book_stock1.aspx?id="+id+"");
    }
    protected void Button2_Click(object sender, EventArgs e)
    {
        string id = Request.QueryString["id"];
        Response.Redirect("book_recommend1.aspx?id=" + id + "");
    }
    protected void Button4_Click(object sender, EventArgs e)
    {
        string delete = Request.QueryString["id"];
        string mysql = "DELETE FROM system_book WHERE bookid = '" + delete + "'";
        SqlHelper.GetExecuteNonQuery(mysql);
        Response.Write("<script>alert('成功');location='book_count.aspx'</script>");
    }
    protected void Button3_Click(object sender, EventArgs e)
    {
        string id = Request.QueryString["id"];
        Response.Redirect("book_change.aspx?id=" + id + "");
    }
}