using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Configuration;
using System.Web.Configuration;
using MySql.Data.MySqlClient;
using System.Data;
using System.Web.UI;
using System.Text;
/// <summary>
///SqlHelper 的摘要说明
/// </summary>
public class SqlHelper
{
    private static MySqlConnection conn = new MySqlConnection();
    private static MySqlCommand cmd = new MySqlCommand();
    private static void Openconn()
    {
        if (conn.State == ConnectionState.Closed)
        {
            string constr = ConfigurationManager.ConnectionStrings["DBL"].ConnectionString.ToString();
            conn.ConnectionString = constr;
            cmd.Connection = conn;
            conn.Open();
        }
    }
    public static void Closeconn()
    {
        if (conn.State == ConnectionState.Open)
        {
            conn.Close();
        }
    }
    public static int GetExecuteNonQuery(string mysql)
    {
        Openconn();
        cmd.CommandType = CommandType.Text;
        cmd.CommandText = mysql;
        int result = cmd.ExecuteNonQuery();
        Closeconn();
        return result;
    }
    public static int GetExecuteNonQuery(string mysql, params MySqlParameter[] values)
    {
        Openconn();
        cmd.CommandType = CommandType.Text;
        cmd.CommandText = mysql;
        cmd.Parameters.AddRange(values);
        int result = cmd.ExecuteNonQuery();
        Closeconn();
        cmd.Parameters.Clear();
        return result;
    }
    public static MySqlDataReader GetExecuteReader(string mysql)
    {
        Openconn();
        cmd.CommandType = CommandType.Text;
        cmd.CommandText = mysql;
        MySqlDataReader reader = cmd.ExecuteReader();
        return reader;
    }
	public SqlHelper()
	{
		
	}
    public static void MsgBox(string message, Page page) //显示对话框
    {
        String csname = "PopupScript";//定义客户端脚本的名
        Type cstype = page.GetType();//定义客户端脚本的类型
        ClientScriptManager cs = page.ClientScript;//创建一个ClientScriptManager类
        if (!cs.IsStartupScriptRegistered(cstype, csname))//如果脚本没有注册
        {
            String cstext = "alert('" + page.Server.HtmlEncode(message) + "');";
            cs.RegisterStartupScript(cstype, csname, cstext, true);
        }
    }
    public static object GetExecuteScalar(string sqlStr, params MySqlParameter[] values)
    {
        Openconn();
        cmd.CommandType = CommandType.Text;
        cmd.CommandText = sqlStr;
        cmd.Parameters.Clear();
        cmd.Parameters.AddRange(values);
        object result = cmd.ExecuteScalar();
        Closeconn();
        cmd.Parameters.Clear();
        return result;
    }
    public static MySqlDataReader GetDataReader(string sqlStr, params MySqlParameter[] values)
    {
        Openconn();
        cmd.CommandType = CommandType.Text;
        cmd.CommandText = sqlStr;
        cmd.Parameters.AddRange(values);
        MySqlDataReader reader = cmd.ExecuteReader();
        //这里不能关闭连接CloseConnection()，要在调用中关闭
        cmd.Parameters.Clear();
        return reader;
    }
}