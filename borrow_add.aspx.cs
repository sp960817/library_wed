using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using System.Web.Configuration;
using MySql.Data.MySqlClient;
using System.Data;
using System.Collections;
public partial class borrow_add : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["AdminName"] == null)
        {
            Response.Redirect("login.aspx");
        }
        if (!IsPostBack)
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
                DropDownList1.DataSource = alyear;
                DropDownList1.DataBind();
                DropDownList1.SelectedValue = tnow.Year.ToString();
                DropDownList2.DataSource = almonth;
                DropDownList2.DataBind();
                DropDownList2.SelectedValue = tnow.Month.ToString();
                DropDownList3.DataSource = alday;
                DropDownList3.DataBind();
                DropDownList3.SelectedValue = tnow.Day.ToString();

            }
        }
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        string date = ""+DropDownList1.Text+"-"+DropDownList2.Text+"-"+DropDownList3.Text+"";
        string findbookname = "SELECT bookname FROM system_book WHERE bookid = '" + TextBox1.Text + "'";
        MySqlDataReader dr = SqlHelper.GetExecuteReader(findbookname);
        if (dr.Read())
        {
            string bookname = dr["bookname"].ToString();
            dr.Close();
            SqlHelper.Closeconn();
            string findreadierid = "SELECT * FROM system_readers WHERE readerid='" + TextBox2.Text + "';UPDATE system_book SET bookstock = bookstock-1 WHERE bookid = '" + TextBox1.Text + "'";
            MySqlDataReader dr1 = SqlHelper.GetExecuteReader(findreadierid);
            if (dr1.Read())
            {
                dr1.Close();
                SqlHelper.Closeconn();
                string mysql = "INSERT borrow_record (bookid,bookname,readerid,borrowdate)VALUES('" + TextBox1.Text + "','" + bookname + "','" + TextBox2.Text + "','" + date + "')";
                int count = SqlHelper.GetExecuteNonQuery(mysql);
                if (count > 0)
                {
                    Response.Write("<script langauge=javascript>alert('成功')</script>");

                }
               
            }
            else
            {
                dr.Close();
                SqlHelper.Closeconn();
                Response.Write("<script langauge=javascript>alert('读者ID有错误')</script>");
            }
            
           
        }
        else
        {
            dr.Close();
            SqlHelper.Closeconn();
            Response.Write("<script langauge=javascript>alert('书籍ID有错误')</script>");
        }
        
        
    }
    protected void Button2_Click(object sender, EventArgs e)
    {
        Response.Redirect("admin.aspx");
    }
}