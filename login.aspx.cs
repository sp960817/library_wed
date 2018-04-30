using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MySql.Data.MySqlClient;
using System.Web.Security;
using System.Data;
public partial class login : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        TextBox1.Focus();
    }

    private int ExistAdmin(string adminName, string adminPassword)
    {
        string sqlStr = "select count(*) from Admin where AdminName =@AdminName and AdminPassword=@AdminPassword";
        MySqlParameter[] paras = new MySqlParameter[]
        {
            new MySqlParameter("@AdminName", MySqlDbType.VarChar, 50),
            new MySqlParameter("@AdminPassword", MySqlDbType.VarChar, 50)
        };
        paras[0].Value = adminName; //获取管理员名
        //paras[1].Value = adminPassword;//获取密码，如果不采用MD5，则去掉本行注释，给下行加上注释
        paras[1].Value = FormsAuthentication.HashPasswordForStoringInConfigFile(adminPassword, "MD5");//去掉注释则实现MD5，给上面一行加上注释
        int i = Convert.ToInt32(SqlHelper.GetExecuteScalar(sqlStr, paras));//把object类型转换为int
        return i;
    }


    private string GetAdminRealName(string adminName)
    {
        string sqlstr = "SELECT AdminRealName From Admin WHERE AdminName = @AdminName";
        MySqlParameter paras = new MySqlParameter("@AdminName", MySqlDbType.VarChar);
        paras.Value = adminName;
        MySqlDataReader dr = SqlHelper.GetDataReader(sqlstr, paras);
        if (dr.Read())
        {
            string AdminRealName = dr["AdminRealName"].ToString();
            dr.Close();
            SqlHelper.Closeconn();
            return AdminRealName;
        }
        else
        {
            dr.Close();
            SqlHelper.Closeconn();
            return "没有信息";
        }
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        if (Session["CheckCode"].ToString().ToLower().Equals(TextBox3.Text.ToString().ToLower()))
        {
            string adminName = TextBox1.Text.Trim();
            string adminPassword = TextBox2.Text.Trim();
            if (ExistAdmin(adminName, adminPassword) > 0)
            {
                Session["AdminName"] = adminName;
                Session["AdminRealName"] = GetAdminRealName(adminName);
                Response.Redirect("admin.aspx");//重定向到后台主程序
            }
            else
            {
                SqlHelper.MsgBox("密码或管理员名错误！", Page);//调用自定义类中的方法
            }
        }
        else
        {
            SqlHelper.MsgBox("验证码错误！", Page);//调用自定义类中的方法
        }
    }
    protected void Button2_Click(object sender, EventArgs e)
    {
        TextBox1.Text = null;
        TextBox2.Text = null;
        TextBox3.Text = null;
        TextBox1.Focus();
    }
}