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

public partial class Admin_Pages_ImagesCategory : BasePage
{
    ImagesTypeBLL imagestype;
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
                this.load_gwImagesCategory();
            }
        }
    }
    private void load_gwImagesCategory()
    {
        imagestype = new ImagesTypeBLL();
        gwImagesCategory.DataSource = imagestype.ListAllItem();
        gwImagesCategory.DataBind();
    }
    protected void btnAddImgCategory_Click(object sender, EventArgs e)
    {
        imagestype = new ImagesTypeBLL();
        try
        {
            List<ImagesType> lst = imagestype.ListWithName(txtImgCategory.Text);
            ImagesType imt = lst.FirstOrDefault();
            if(imt!=null)
            {
                this.AlertPageValid(true, txtImgCategory.Text + " đã tồn tại, vui lòng nhập tên khác 1", alertPageValid, lblPageValid);
            }
            else
            {
                if(imagestype.NewImagesType(txtImgCategory.Text))
                {
                    Response.Redirect(Request.Url.AbsoluteUri);
                }
                else
                {
                    this.AlertPageValid(true, "Không thể kết nối với CSDL !", alertPageValid, lblPageValid);
                }
            }
        }
        catch (Exception ex)
        {
            this.AlertPageValid(true, ex.ToString(), alertPageValid, lblPageValid);
        }
    }
}