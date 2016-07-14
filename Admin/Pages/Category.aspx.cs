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

public partial class Admin_Pages_Category : BasePage
{
    CategoryBLL category;
    protected void Page_Load(object sender, EventArgs e)
    {
        this.setcurenturl();
        if (!IsPostBack)
        {
            if (Session.GetCurrentUser() == null)
            {
                Response.Redirect("http://" + Request.Url.Authority + "/Admin/Login.aspx");
            }
            else
            {
                this.AlertPageValid(false, "", alertPageValid, lblPageValid);
                this.load_dlParent();
            }
        }
    }
    private void load_dlParent()
    {
        category = new CategoryBLL();
        this.load_DropdownList(dlParent, category.CategoryParent(), "ParentNameCategory", "ID");
        dlParent.DataBind();
        dlParent.Items.Insert(0, new ListItem("-- Trống --", "0"));
    }
    protected void btnSaveNewCategory_Click(object sender, EventArgs e)
    {
        try
        {

        }
        catch (Exception ex)
        {
            this.AlertPageValid(true, ex.ToString(), alertPageValid, lblPageValid);
        }
    }
}