using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using DataAccessLayer;
using BusinessLogicLayer;

public partial class Pages_PostItem : System.Web.UI.Page
{
    PostBLL posts;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            this.loadPostInfor();
        }
    }
    private void loadPostInfor()
    {
        posts = new PostBLL();
        string ID = RouteData.Values["PostId"].ToString();
        Post pt = posts.ListPosByID(Convert.ToInt32(ID)).FirstOrDefault();
        lblPostTitle.Text = pt.TitleVN;
        lblcontent.Text = pt.PostContentVN;
    }
}