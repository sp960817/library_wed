using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MySql.Data.MySqlClient;
public partial class see_return : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["AdminName"] == null)
        {
            Response.Redirect("login.aspx");
        }
        if (!IsPostBack)
        {
            string mysql = "SELECT id AS 归还ID,bookid AS 书籍ID,bookname AS 书籍名称,readerid AS 读者ID,returndate AS 归还日期 FROM return_record ORDER BY returndate ASC";
            SqlHelper.Show(GridView1, mysql);
        }
    }

    protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        GridView1.PageIndex = e.NewPageIndex;
        string mysql = "SELECT id AS 归还ID,bookid AS 书籍ID,bookname AS 书籍名称,readerid AS 读者ID,returndate AS 归还日期 FROM return_record ORDER BY returndate ASC";
        SqlHelper.Show(GridView1, mysql);
    }
}