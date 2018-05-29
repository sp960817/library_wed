using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MySql.Data.MySqlClient;
using System.Configuration;
using System.Web.Configuration;
using System.Data;
public partial class book_count : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["AdminName"] == null)
        {
            Response.Redirect("login.aspx");
        }
        if (!IsPostBack)
        {
            string mysql = "SELECT bookid AS 书籍ID,bookname AS 书籍名称,bookstyle AS 书籍分类,bookauther AS 作者,bookstock AS 库存,bookpub AS 出版社,DATE_FORMAT(bookpubdate,'%Y-%m-%d  ') AS 出版时间,booklv AS 推荐等级 FROM system_book";
            Show(mysql);
        }
        
    }
    protected void GridView1_SelectedIndexChanging(object sender, GridViewSelectEventArgs e)
    {
        string id = GridView1.DataKeys[e.NewSelectedIndex].Values[0].ToString();
        Response.Redirect("choose_book.aspx?id="+id+"");
        
    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        Button btn = sender as Button;
        GridViewRow row = btn.Parent.Parent as GridViewRow;
        string a = row.Cells[0].ToString();//获得第一个单元格的值   
        string b = this.GridView1.DataKeys[row.DataItemIndex].Values[0].ToString();//获得DataKeys的值   
        SqlHelper.Closeconn();
        Response.Redirect("see_book.aspx?id=" + b + "");
    }

    protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
    private void Show(string mysql) 
    {
        DataSet ds = SqlHelper.GetDataSet(mysql);
        GridView1.DataSource = ds;
        GridView1.DataKeyNames = new string[] { "书籍ID" };
        GridView1.DataBind();
    }
    protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        GridView1.PageIndex = e.NewPageIndex;
        string mysql = "SELECT bookid AS 书籍ID,bookname AS 书籍名称,bookstyle AS 书籍分类,bookauther AS 作者,bookstock AS 库存,bookpub AS 出版社,DATE_FORMAT(bookpubdate,'%Y-%m-%d  ') AS 出版时间,booklv AS 推荐等级 FROM system_book";
        Show(mysql);
    }
}