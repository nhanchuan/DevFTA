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

public partial class Admin_Pages_MainMenu : BasePage
{
    MainMenuBLL mainmenu;
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
                this.load_gwMenuItems();
            }
        }
    }

    private void load_gwMenuItems()
    {
        mainmenu = new MainMenuBLL();
        gwMenuItems.DataSource = mainmenu.ListMenuItems();
        gwMenuItems.DataBind();
    }
    protected void btnAddMenuItem_Click(object sender, EventArgs e)
    {
        try
        {

            mainmenu = new MainMenuBLL();
            if (mainmenu.NewMainMenu(txtItemname.Text, txtPermalink.Text, mainmenu.MaxItemindex() + 1, chkStatus.Checked))
            {
                Response.Redirect(Request.Url.AbsoluteUri);
            }
            else
            {
                this.AlertPageValid(true, "False to connect server !", alertPageValid, lblPageValid);
                return;
            }

        }
        catch (Exception ex)
        {
            this.AlertPageValid(true, ex.ToString(), alertPageValid, lblPageValid);
        }
    }

    protected void gwMenuItems_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        try
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                LinkButton del = e.Row.FindControl("linkBtnDel") as LinkButton;
                del.Attributes.Add("onclick", "return confirm('Are you sure you want to delete this ?')");
            }
        }
        catch (Exception ex)
        {
            Response.Write("<script>alert('" + ex.ToString() + "')</script>");
        }
    }

    protected void gwMenuItems_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {

    }

    protected void gwMenuItems_SelectedIndexChanged(object sender, EventArgs e)
    {

    }

    protected void chkShow_CheckedChanged(object sender, EventArgs e)
    {
        try
        {
            mainmenu = new MainMenuBLL();

        }
        catch (Exception)
        {
            this.AlertPageValid(true, ex.ToString(), alertPageValid, lblPageValid);
        }
    }
}