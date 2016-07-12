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

public partial class Admin_Login : BasePage
{
    UserAdminBLL useradmin;
    UserAdminProfileBLL useradminprofile;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!this.IsPostBack)
        {
            if (Request.Cookies["UserFTAAdminName"] != null && Request.Cookies["PasswordFTAAdmin"] != null)
            {
                txtusername.Value = Request.Cookies["UserAdminName"].Value;
                //txtpasswords.Attributes["value"] = Request.Cookies["PasswordAdmin"].Value;
                //txtpasswords.Attributes.Add("value", Request.Cookies["PasswordAdmin"].Value);
                txtpasswords.Attributes["value"] = Request.Cookies["PasswordFTAAdmin"].Value;
                lblalertlogin.Text = "";
            }
        }
    }
    public void check_rememberUser()
    {
        if (chkRememberMe.Checked)
        {
            Response.Cookies["UserFTAAdminName"].Expires = DateTime.Now.AddDays(30);
            Response.Cookies["PasswordFTAAdmin"].Expires = DateTime.Now.AddDays(30);
        }
        else
        {
            Response.Cookies["UserFTAAdminName"].Expires = DateTime.Now.AddDays(-1);
            Response.Cookies["PasswordFTAAdmin"].Expires = DateTime.Now.AddDays(-1);

        }
        Response.Cookies["UserFTAAdminName"].Value = txtusername.Value.Trim();
        Response.Cookies["PasswordFTAAdmin"].Value = txtpasswords.Text.Trim();
    }
    protected Boolean check_login(string key, string password)
    {
        useradmin = new UserAdminBLL();
        List<UserAdmin> lst = useradmin.login_Adminform(key, password);
        UserAdmin user = lst.FirstOrDefault();
        if (user != null)
        {
            Session.SetCurrentUser(user);
            return true;
        }
        return false;
    }
    protected Boolean checkUserStaus(int adminid)
    {
        useradminprofile = new UserAdminProfileBLL();
        List<UserAdminProfile> lst = useradminprofile.ListAdminPrifileWithUID(adminid);
        UserAdminProfile pro = lst.FirstOrDefault();
        return pro.ProfileStatus;
    }
    public Boolean checkUriLogin() //Kiem tra session Url co phai trang login ko ? Neu dung return True | return False
    {
        string url = Session.GetCurrentURL();
        if (string.IsNullOrWhiteSpace(url))
        {
            return false;
        }
        return true;
    }
    protected void btnLogin_ServerClick(object sender, EventArgs e)
    {
        try
        {
            if (string.IsNullOrWhiteSpace(txtusername.Value) || string.IsNullOrWhiteSpace(txtpasswords.Text))
            {
                alertlogin.Attributes.Remove("class");
                alertlogin.Attributes.Add("class", "alert alert-danger");
                lblalertlogin.Text = "Enter any username and password. !";
            }
            else
            {
                if (check_login(txtusername.Value, CreateSHAHash(txtpasswords.Text, SaltPassword())))
                {
                    this.check_rememberUser();
                    if (checkUserStaus(Session.GetCurrentUser().ID))
                    {
                        if (checkUriLogin() == false)
                        {
                            Response.Redirect("/Admin/Default.aspx");
                        }
                        else
                        {
                            Response.Redirect(Session.GetCurrentURL());
                        }
                    }
                    else
                    {
                        alertlogin.Attributes.Remove("class");
                        alertlogin.Attributes.Add("class", "alert alert-danger");
                        lblalertlogin.Text = "Account is disabled !";
                    }
                }
                else
                {
                    alertlogin.Attributes.Remove("class");
                    alertlogin.Attributes.Add("class", "alert alert-danger");
                    lblalertlogin.Text = "Incorrect username or password !";
                }
            }
            
        }
        catch (Exception)
        {
            throw;
        }
    }
}