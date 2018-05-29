using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MySql.Data.MySqlClient;
using System.Text;
public partial class see_borrow : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["AdminName"] == null)
        {
            Response.Redirect("login.aspx");
        }
        if (!IsPostBack)
        {
            Label1.Visible = false;
            string mysql = "SELECT id AS 借阅ID,bookid AS 书籍ID,bookname AS 书籍名称,readerid AS 读者ID,DATE_FORMAT(borrowdate,'%Y-%m-%d  ') AS 借阅日期,isreturn AS 是否归还 FROM borrow_record ORDER BY isreturn ASC";
            SqlHelper.Show(GridView1, mysql);
            Gt();
        }
       
    }
    protected void GridView1_SelectedIndexChanging(object sender, GridViewSelectEventArgs e)
    {
        string id = GridView1.DataKeys[e.NewSelectedIndex].Values[0].ToString();
        string mysql = "SELECT * FROM borrow_record WHERE id =' " + id + " '";
        MySqlDataReader dr = SqlHelper.GetExecuteReader(mysql);
        if (dr.Read())
        {
            string isr = dr["isreturn"].ToString();
            int bookid = Convert.ToInt32(dr["bookid"]);
            string bookname = dr["bookname"].ToString();
            string readerid = dr["readerid"].ToString();
            SqlHelper.Closeconn();
            DateTime now = DateTime.Now;
            string date = "" + now.Year.ToString() + "-" + now.Month.ToString() + "-" + now.Day.ToString() + "";
            if (isr == "是")
            {
                Response.Write("<script>alert('已经是归还状态');</script>");
            }
            else
            {
                string mysql1 = "UPDATE borrow_record SET isreturn ='是' WHERE id = '" + id + "';INSERT return_record (bookid,bookname,readerid,returndate)VALUES('"+bookid+"','"+bookname+"','"+readerid+"','"+date+"')";
                int count = SqlHelper.GetExecuteNonQuery(mysql1);
                if (count > 0)
                {
                    string mysql2 = "UPDATE system_book SET bookstock = bookstock+1 WHERE bookid = '" + bookid + "'";
                    SqlHelper.GetExecuteNonQuery(mysql2);
                    Response.Write("<script>alert('归还成功');</script>");
                    string mysql11 = "SELECT id AS 借阅ID,bookid AS 书籍ID,bookname AS 书籍名称,readerid AS 读者ID,,DATE_FORMAT(borrowdate,'%Y-%m-%d  ') AS 借阅日期,isreturn AS 是否归还 FROM borrow_record ORDER BY isreturn ASC";
                    SqlHelper.Show(GridView1, mysql11);
                    Gt();
                }
                else
                {
                    Response.Write("<script>alert('归还失败');</script>");
                }
            }
        }
        else
        {
            SqlHelper.Closeconn();
            Response.Write("<script>alert('已经是归还状态');location='book_count.aspx'</script>");
        }
    }
    private void Gt()
    {
        DateTime now = DateTime.Now;
        string mysql = "SELECT id FROM borrow_record WHERE TIMESTAMPDIFF(day,borrowdate,'" + now.ToShortDateString().ToString() + "')>60 AND isreturn = '否'";
        MySqlDataReader dr = SqlHelper.GetExecuteReader(mysql);
        StringBuilder sb = new StringBuilder();
        if (dr.HasRows)
        {
            while (dr.Read())
            {
                for (int i = 0; i < dr.FieldCount; i++) //逐个字段的遍历
                {
                    sb.AppendFormat("{0} ", dr[i]);//字段之间用 |连接
                }
            }
            Label1.Visible = true;
            Label1.Text = "借阅ID为" + sb.ToString() + "的信息已经超过两个月，需要处理";
            dr.Close();
            SqlHelper.Closeconn();
        }
        else
        {
            dr.Close();
            SqlHelper.Closeconn();
            Label1.Visible = false;
        }
    }
    protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        string mysql = "DELETE FROM borrow_record WHERE id = '"+GridView1.DataKeys[e.RowIndex].Values[0].ToString()+"' ";
        int count = SqlHelper.GetExecuteNonQuery(mysql);
        if (count > 0)
        {
            Response.Write("<script langauge=javascript>alert('删除成功')</script>");
            string mysql11 = "SELECT id AS 借阅ID,bookid AS 书籍ID,bookname AS 书籍名称,readerid AS 读者ID,borrowdate AS 借阅日期,isreturn AS 是否归还 FROM borrow_record ORDER BY isreturn ASC";
            SqlHelper.Show(GridView1, mysql11);
            Gt();
        }
        else
        {
            Response.Write("<script langauge=javascript>alert('失败')</script>");
        }
    }

    protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        GridView1.PageIndex = e.NewPageIndex;
        string mysql = "SELECT id AS 借阅ID,bookid AS 书籍ID,bookname AS 书籍名称,readerid AS 读者ID,borrowdate AS 借阅日期,isreturn AS 是否归还 FROM borrow_record ORDER BY isreturn ASC";
        SqlHelper.Show(GridView1, mysql);
    }

}