using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MySql.Data.MySqlClient;
using System.Configuration;
using System.Web.Configuration;
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
            string mysql = "SELECT bookid AS 书籍ID,bookname AS 书籍名称,bookstyle AS 书籍分类,bookstock AS 库存,bookpub AS 出版社,bookpubdate AS 出版时间,isborrowed AS 是否被预约借阅,booklv AS 推荐等级 FROM system_book";
            //string mysql = "SELECT * FROM system_book";
            MySqlDataReader dr = SqlHelper.GetExecuteReader(mysql);
            GridView1.DataSource = dr;
            GridView1.DataBind();
            dr.Close();
            SqlHelper.Closeconn();
        }
        
    }
    protected void GridView1_SelectedIndexChanging(object sender, GridViewSelectEventArgs e)
    {
        string id = GridView1.DataKeys[e.NewSelectedIndex].Values[0].ToString();
        
      //  string id = GridView1.Rows[e.NewSelectedIndex].Cells[1].Text;
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
}