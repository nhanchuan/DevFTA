using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Admin_AdminMasterPage : System.Web.UI.MasterPage
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void btnlogout_ServerClick(object sender, EventArgs e)
    {
        Session.SetCurrentUser(null);
        Response.Redirect("http://" + Request.Url.Authority + "/Admin/Login.aspx");

    }
}
