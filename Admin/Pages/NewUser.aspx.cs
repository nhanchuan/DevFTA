using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using DataAccessLayer;
using BusinessLogicLayer;

public partial class Admin_Pages_NewUser : BasePage
{
    UserAdminBLL useradmin;
    UserAdminProfileBLL useradminprofile;
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
            }
        }
    }
    
    protected void btnNewUser_Click(object sender, EventArgs e)
    {
        try
        {
            useradmin = new UserAdminBLL();
            useradminprofile = new UserAdminProfileBLL();
            string Uname = txtUsername.Text;
            string Uemail = txtEmail.Text;
            string Fname = txtFirstname.Text;
            string Lname = txtLastname.Text;
            string Upassword = txtPrePassword.Text;

            List<UserAdmin> lst1 = useradmin.ListUserWithName(Uname);
            UserAdmin ad1 = lst1.FirstOrDefault();
            List<UserAdmin> lst2 = useradmin.ListUserWithEmail(Uemail);
            UserAdmin ad2 = lst2.FirstOrDefault();

            if (ad1 != null)
            {
                this.AlertPageValid(true, "The username already exists !", alertPageValid, lblPageValid);
            }
            else
            {
                if(ad2!=null)
                {
                    this.AlertPageValid(true, "The E-mail already exists !", alertPageValid, lblPageValid);
                }
                else
                {
                    bool bol1 = this.useradmin.NewUserAdmin(Uname, Uemail, CreateSHAHash(Upassword, SaltPassword()));
                    bool bol2 = this.useradminprofile.CreateUserAdminProfile(Fname, Lname, useradmin.GetUserIDWithName(Uname));

                    if (bol1 || bol2)
                    {
                        Response.Write("<script>alert('Thêm người dùng thành công !')</script>");
                    }
                    else
                    {
                        this.AlertPageValid(true, "Thêm người dùng thất bại. Lỗi kết nối CSDL !", alertPageValid, lblPageValid);
                    }
                }
            }
        }
        catch (Exception ex)
        {
            this.AlertPageValid(true, ex.ToString(), alertPageValid, lblPageValid);
        }
    }
}