using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MySql.Data.MySqlClient;
using System.Web.Configuration;
using System.Configuration;
using System.Collections;
public partial class book_change : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["AdminName"] == null)
        {
            Response.Redirect("login.aspx");
        }
        string bookid = Request.QueryString["id"];
        string mysql = "SELECT * FROM system_book WHERE bookid = '" + bookid + "'";
        MySqlDataReader reader = SqlHelper.GetExecuteReader(mysql);
        GridView1.DataSource = reader;
        GridView1.DataBind();
        reader.Close();
        SqlHelper.Closeconn();
        getdate();
        if (!IsPostBack)
        {
            this.TextBox1.Visible = false;
            this.DropDownList2.Visible = false;
            this.DropDownList3.Visible = false;
            this.DropDownList4.Visible = false;
            this.DropDownList5.Visible = false;
            this.Label1.Visible = false;
            this.Label2.Visible = false;
            this.Label3.Visible = false;
        }
    }
    protected void getdate()
    {
        DateTime tnow = DateTime.Now;//现在时间   
        ArrayList alyear = new ArrayList();
        int i;
        for (i = 1980; i <= 2018; i++)
            alyear.Add(i);
        ArrayList almonth = new ArrayList();
        for (i = 1; i <= 12; i++)
            almonth.Add(i);
        ArrayList alday = new ArrayList();
        for (i = 1; i <= 31; i++)
            alday.Add(i);
        if (!this.IsPostBack)
        {
            DropDownList2.DataSource = alyear;
            DropDownList2.DataBind();
            DropDownList2.SelectedValue = tnow.Year.ToString();
            DropDownList3.DataSource = almonth;
            DropDownList3.DataBind();
            DropDownList3.SelectedValue = tnow.Month.ToString();
            DropDownList4.DataSource = alday;
            DropDownList4.DataBind();
            DropDownList4.SelectedValue = tnow.Day.ToString();

        }  
    }
    protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
    protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (DropDownList1.SelectedItem.Text == "书名")
        {
            this.TextBox1.Visible = true;
            this.DropDownList2.Visible = false;
            this.DropDownList3.Visible = false;
            this.DropDownList4.Visible = false;
            this.Label1.Visible = false;
            this.Label2.Visible = false;
            this.Label3.Visible = false;
            this.DropDownList5.Visible = false;
        }
        else if (DropDownList1.SelectedItem.Text == "书籍分类")
        {
            this.DropDownList5.Visible = true;
            this.DropDownList2.Visible = false;
            this.TextBox1.Visible = false;
            this.DropDownList3.Visible = false;
            this.DropDownList4.Visible = false;
            this.Label1.Visible = false;
            this.Label2.Visible = false;
            this.Label3.Visible = false;
            string mysql = "SELECT bookstyle FROM book_style";
            MySqlDataReader reader = SqlHelper.GetExecuteReader(mysql);
            DropDownList5.DataSource = reader;
            DropDownList5.DataTextField = "bookstyle";
            DropDownList5.DataValueField = "bookstyle";
            DropDownList5.DataBind();
            SqlHelper.Closeconn();
        }
        else if (DropDownList1.SelectedItem.Text == "书籍作者")
        {
            this.TextBox1.Visible = true;
            this.DropDownList2.Visible = false;
            this.DropDownList3.Visible = false;
            this.DropDownList4.Visible = false;
            this.Label1.Visible = false;
            this.Label2.Visible = false;
            this.Label3.Visible = false;
            this.DropDownList5.Visible = false;
        }
        else if (DropDownList1.SelectedItem.Text == "出版社")
        {
            this.TextBox1.Visible = true;
            this.DropDownList2.Visible = false;
            this.DropDownList3.Visible = false;
            this.DropDownList4.Visible = false;
            this.Label1.Visible = false;
            this.Label2.Visible = false;
            this.Label3.Visible = false;
            this.DropDownList5.Visible = false;
        }
        else if (DropDownList1.SelectedItem.Text == "出版时间")
        {

            this.DropDownList2.Visible = true;
            this.DropDownList3.Visible = true;
            this.DropDownList4.Visible = true;
            this.TextBox1.Visible = false;
            this.Label1.Visible = true;
            this.Label2.Visible = true;
            this.Label3.Visible = true;
            this.DropDownList5.Visible = false;

        }
       }
    protected void TextBox1_TextChanged(object sender, EventArgs e)
    {

    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        string bookid = Request.QueryString["id"];
        
        if (DropDownList1.SelectedItem.Text == "书名")
        {
            string mysql = "UPDATE system_book SET bookname = '" + TextBox1.Text + "'WHERE bookid = '"+bookid+"'";
            int count = SqlHelper.GetExecuteNonQuery(mysql);
            if(count > 0)
            {
                Response.Write("<script langauge=javascript>alert('成功')</script>");
                
            }
            else
            {
                Response.Write("<script langauge=javascript>alert('失败')</script>");
             
            }
        }
        else if (DropDownList1.SelectedItem.Text == "书籍分类")
        {
            string mysql = "UPDATE system_book SET bookstyle = '" + DropDownList5.SelectedValue.ToString() + "'WHERE bookid = '"+bookid+"'";
            int count = SqlHelper.GetExecuteNonQuery(mysql);
            if(count > 0)
            {
                Response.Write("<script langauge=javascript>alert('成功')</script>");
            }
            else
            {
                Response.Write("<script langauge=javascript>alert('失败')</script>");
            }
        }
        else if (DropDownList1.SelectedItem.Text == "书籍作者")
        {
            string mysql = "UPDATE system_book SET bookauther = '" + TextBox1.Text + "'WHERE bookid = '" + bookid + "'";
            int count = SqlHelper.GetExecuteNonQuery(mysql);
            if (count > 0)
            {
                Response.Write("<script langauge=javascript>alert('成功')</script>");
            }
            else
            {
                Response.Write("<script langauge=javascript>alert('失败')</script>");
            }
        }
        else if (DropDownList1.SelectedItem.Text == "出版社")
        {
            string mysql = "UPDATE system_book SET bookpub = '" + TextBox1.Text + "'WHERE bookid = '" + bookid + "'";
            int count = SqlHelper.GetExecuteNonQuery(mysql);
            if (count > 0)
            {
                Response.Write("<script langauge=javascript>alert('成功')</script>");
            }
            else
            {
                Response.Write("<script langauge=javascript>alert('失败')</script>");
            }
        }
        else if (DropDownList1.SelectedItem.Text == "出版时间")
        {
            string time = "" + DropDownList2.SelectedValue + "-" + DropDownList3.SelectedValue + "-" + DropDownList4.SelectedValue + "";
            string mysql = "UPDATE system_book SET bookpubdate = '" +time+ "'WHERE bookid = '" + bookid + "'";
            int count = SqlHelper.GetExecuteNonQuery(mysql);
            if (count > 0)
            {
                Response.Write("<script langauge=javascript>alert('成功')</script>");
            }
            else
            {
                Response.Write("<script langauge=javascript>alert('失败')</script>");
            }
        }
        TextBox1.Text = "";
        
    }

    protected void Button2_Click(object sender, EventArgs e)
    {
        Response.Redirect("book_count.aspx");
    }
}