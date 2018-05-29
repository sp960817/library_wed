using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MySql.Data.MySqlClient;
using System.Configuration;
using System.Web.Configuration;
public partial class reader_count : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["AdminName"] == null)
        {
            Response.Redirect("login.aspx");
        }
        if (!IsPostBack)
        {
            string mysql = "SELECT readerid AS 读者ID,readername AS 姓名 FROM system_readers";
            // string mysql = "SELECT * FROM system_readers";
            MySqlDataReader dr = SqlHelper.GetExecuteReader(mysql);
            GridView1.DataSource = dr;
            GridView1.DataBind();
            dr.Close();
            SqlHelper.Closeconn();

        }
    }


    protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        string id = this.GridView1.DataKeys[e.RowIndex].Values[0].ToString();
        string mysql = "DELETE FROM system_readers WHERE readerid = '" + id + "'";
        int count = SqlHelper.GetExecuteNonQuery(mysql);
        if (count > 0)
        {
            Response.Write("<script langauge=javascript>alert('删除成功')</script>");
            string mysql1 = "SELECT readerid AS 读者ID,readerpw AS 密码,readername AS 姓名 FROM system_readers";
            MySqlDataReader dr = SqlHelper.GetExecuteReader(mysql1);
            GridView1.DataSource = dr;
            GridView1.DataBind();
            dr.Close();
            SqlHelper.Closeconn();
        }
        else
        {
            Response.Write("<script langauge=javascript>alert('失败')</script>");
        }
        
    }
    protected void GridView1_RowEditing(object sender, GridViewEditEventArgs e)
    {
        string id = this.GridView1.DataKeys[e.NewEditIndex].Values[0].ToString();
        Response.Write("<script language='javascript'>window.open('ChangePw.aspx?id="+ id +"');</script>");
    }
}