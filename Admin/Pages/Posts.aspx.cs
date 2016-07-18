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

public partial class Admin_Pages_Posts : BasePage
{

    public int PageSize = 20;
    PostBLL posts;
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
                this.GetPostPageWise(1);
            }
        }
    }
    private void GetPostPageWise(int pageIndex)
    {
        gwPosts.DataSource = new PostBLL().GetPostsPageWise(pageIndex, PageSize);
        gwPosts.DataBind();
        this.PopulatePager(rptPager, new PostBLL().RecordCountPosts(), pageIndex, PageSize);
    }
    protected void Page_Changed(object sender, EventArgs e)
    {
        int pageIndex = int.Parse((sender as LinkButton).CommandArgument);
        this.GetPostPageWise(pageIndex);
    }

    protected void chkPostStatus_CheckedChanged(object sender, EventArgs e)
    {
        try
        {
            CheckBox chk = (sender as CheckBox);
            string key = chk.AccessKey;
            posts = new PostBLL();
            this.posts.UpdatePostStatus(Convert.ToInt32(key), chk.Checked);
        }
        catch (Exception ex)
        {
            this.AlertPageValid(true, ex.ToString(), alertPageValid, lblPageValid);
        }
    }

    protected void chkTopHot_CheckedChanged(object sender, EventArgs e)
    {
        try
        {
            CheckBox chk = (sender as CheckBox);
            string key = chk.AccessKey;
            posts = new PostBLL();
            this.posts.UpdatePostTopHot(Convert.ToInt32(key), chk.Checked);
        }
        catch (Exception ex)
        {
            this.AlertPageValid(true, ex.ToString(), alertPageValid, lblPageValid);
        }
    }

    protected void gwPosts_SelectedIndexChanged(object sender, EventArgs e)
    {

    }

    protected void gwPosts_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        try
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                LinkButton del = e.Row.FindControl("linkBtnDel") as LinkButton;
                del.Attributes.Add("onclick", "return confirm('Are you sure you want to delete this ?')");
            }
        }
        catch (Exception)
        {

        }
    }

    protected void gwPosts_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {

    }
}