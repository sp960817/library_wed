using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text;
using MySql.Data.MySqlClient;
public partial class admin : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["AdminName"] == null)
        {
            Response.Redirect("login.aspx");
        }
        if (!IsPostBack)
        {
            string name = Session["AdminRealName"].ToString();
            Label3.Text = name;
            Label2.Visible = false;
            Label1.Text = DateTime.Now.ToString();
            Gt();
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
            Label2.Visible = true;
            Label2.Text = "借阅ID为" + sb.ToString() + "的信息已经超过两个月，需要处理";
            dr.Close();
            SqlHelper.Closeconn();
        }
        else
        {
            dr.Close();
            SqlHelper.Closeconn();
            Label2.Visible = false;
        }
    }
}