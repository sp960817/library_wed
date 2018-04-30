using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class MasterPage : System.Web.UI.MasterPage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        string name = Session["AdminRealName"].ToString();
        lblAdminName.Text = name;
    }
    protected void lbtnExit_Click(object sender, EventArgs e)
    {
        Response.Redirect("login.aspx");
    }
    protected void TreeView1_SelectedNodeChanged(object sender, EventArgs e)
    {

    }
}
