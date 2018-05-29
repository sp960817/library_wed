using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MySql.Data.MySqlClient;
public partial class see_re_borrow : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["AdminName"] == null)
        {
            Response.Redirect("login.aspx");
        }
        if (!IsPostBack)
        {
            string mysql = "SELECT id AS 借阅ID,bookid AS 书籍ID,bookname AS 书籍名称,readerid AS 读者ID,,DATE_FORMAT(re_borrowdate,'%Y-%m-%d  ') AS 预约借阅日期 FROM re_borrow_record";
            SqlHelper.Show(GridView1, mysql);
            GridView1.DataKeyNames = new string[] { "借阅ID" };
           
        }
    }

    protected void GridView1_SelectedIndexChanging(object sender, GridViewSelectEventArgs e)
    {
        string id = GridView1.DataKeys[e.NewSelectedIndex].Values[0].ToString();
        string mysql = "SELECT * FROM re_borrow_record WHERE id = '" + id + "'";
        MySqlDataReader dr = SqlHelper.GetExecuteReader(mysql);
        if (dr.Read())
        {
            int bookid = Convert.ToInt32(dr["bookid"]);
            string bookname = dr["bookname"].ToString();
            string readerid = dr["readerid"].ToString();
            DateTime now = DateTime.Now;
            string date = "" + now.Year.ToString() + "-" + now.Month.ToString() + "-" + now.Day.ToString() + "";
            dr.Close();
            SqlHelper.Closeconn();
            string mysql1 = "INSERT INTO borrow_record (bookid,bookname,readerid,borrowdate) VALUES ('" + bookid + "','" + bookname + "','" + readerid + "','" + date + "')";
            int count = SqlHelper.GetExecuteNonQuery(mysql1);
            if (count > 0)
            {
                string mysql2 = "DELETE FROM re_borrow_record WHERE id = '" + id + "'";
                int count1 = SqlHelper.GetExecuteNonQuery(mysql2);
                if (count1 > 0)
                {
                    Response.Write("<script langauge=javascript>alert('借阅成功')</script>");
                    string mysql3 = "SELECT id AS 借阅ID,bookid AS 书籍ID,bookname AS 书籍名称,readerid AS 读者ID,DATE_FORMAT(re_borrowdate,'%Y-%m-%d  ') AS 预约借阅日期 FROM re_borrow_record";
                    /*MySqlDataReader dr1 = SqlHelper.GetExecuteReader(mysql3);
                    GridView1.DataSource = dr1;
                    GridView1.DataBind();
                    dr.Close();*/
                    SqlHelper.Show(GridView1, mysql3);
                }
                else
                {
                    Response.Write("<script langauge=javascript>alert('失败')</script>");
                }
            }
        }
        else
        {
            Response.Write("<script langauge=javascript>alert('失败')</script>");
            SqlHelper.Closeconn();
        }

    }
    protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        GridView1.PageIndex = e.NewPageIndex;
        string mysql = "SELECT id AS 借阅ID,bookid AS 书籍ID,bookname AS 书籍名称,readerid AS 读者ID,re_borrowdate AS 预约借阅日期 FROM re_borrow_record";
        SqlHelper.Show(GridView1, mysql);
    }
    protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        string id = GridView1.DataKeys[e.RowIndex].Value.ToString();
        string mysql = "DELETE  FROM re_borrow_record WHERE id = '" + id + "'";
        int dl = SqlHelper.GetExecuteNonQuery(mysql);
        if (dl > 0)
        {
            string mysql2 = "SELECT id AS 借阅ID,bookid AS 书籍ID,bookname AS 书籍名称,readerid AS 读者ID,re_borrowdate AS 预约借阅日期 FROM re_borrow_record";
            SqlHelper.Show(GridView1, mysql2);
            SqlHelper.MsgBox("删除成功", Page);
            SqlHelper.Closeconn();
        }
        else
        {
            SqlHelper.MsgBox("删除失败", Page);
            SqlHelper.Closeconn();
        }
    }
}