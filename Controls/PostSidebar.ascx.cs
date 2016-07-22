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


public partial class Controls_PostSidebar : System.Web.UI.UserControl
{
    CategoryBLL category;
    protected void Page_Load(object sender, EventArgs e)
    {
        if(!IsPostBack)
        {
            this.load_category();
        }
    }
    private void load_category()
    {
        category = new CategoryBLL();
        rptcategory.DataSource = category.getCategoryWithParentNull();
        rptcategory.DataBind();
    }
}