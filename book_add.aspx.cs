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
public partial class book_add : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["AdminName"] == null)
        {
            Response.Redirect("login.aspx");
        }
        if (!IsPostBack)
        {
        MySqlDataReader reader = SqlHelper.GetExecuteReader("SELECT bookstyle FROM book_style");
        DropDownList1.DataSource = reader;
        DropDownList1.DataTextField = "bookstyle";
        DropDownList1.DataValueField = "bookstyle";
        DropDownList1.DataBind();
        SqlHelper.Closeconn();
        DropDownList1.Items.Insert(0, new ListItem("<-- 请选择 -->", "0"));
       }
          ////////////////////////////
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
                    DropDownList4.SelectedValue = tnow.Day.ToString() ;
                    
                }  
        }  
  
  
    
    

    

    protected void Button1_Click(object sender, EventArgs e)
    {
        string bookstyle = DropDownList1.SelectedValue;
        string time = "" + DropDownList2.SelectedValue + "-" + DropDownList3.SelectedValue + "-" + DropDownList4.SelectedValue + "";
        string mysql = "INSERT INTO system_book (bookname,bookstyle,bookauther,bookstock,bookpub,bookpubdate,isborrowed) VALUES ('" + TextBox1.Text + "','"  + bookstyle + "','" + TextBox2.Text + "','" + TextBox3.Text + "','" + TextBox4.Text + "',' " + time + " ','1')";
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
    protected void Button2_Click(object sender, EventArgs e)
    {
        Response.Redirect("admin.aspx");
    }
}