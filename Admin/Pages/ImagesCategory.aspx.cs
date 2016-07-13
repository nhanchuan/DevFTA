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
                btnfixImagesCT.Attributes.Add("class", "btn btn-default disabled");
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

    protected void gwImagesCategory_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        try
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                LinkButton del = e.Row.FindControl("linkBtnDelPostItem") as LinkButton;
                del.Attributes.Add("onclick", "return confirm('Are you sure you want to delete this ?')");
            }
        }
        catch (Exception ex)
        {
            Response.Write("<script>alert('" + ex.ToString() + "')</script>");
        }
    }

    protected void gwImagesCategory_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        try
        {
            imagestype = new ImagesTypeBLL();
            if (imagestype.DeleteImagesType(Convert.ToInt32((gwImagesCategory.Rows[e.RowIndex].FindControl("lblImagesTypeID") as Label).Text)))
            {
                Response.Redirect(Request.Url.AbsoluteUri);
            }
            else
            {
                this.AlertPageValid(true, "Không thể kết nối với CSDL !", alertPageValid, lblPageValid);
            }
        }
        catch (Exception ex)
        {
            this.AlertPageValid(true, ex.ToString(), alertPageValid, lblPageValid);
        }
    }

    protected void gwImagesCategory_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            imagestype = new ImagesTypeBLL();
            int typeID = Convert.ToInt32((gwImagesCategory.SelectedRow.FindControl("lblImagesTypeID") as Label).Text);
            List<ImagesType> lst = imagestype.ListWithID(typeID);
            ImagesType type = lst.FirstOrDefault();
            if (type != null)
            {
                txtEditImagesCategory.Text = type.Name;
                btnfixImagesCT.Attributes.Add("class", "btn btn-default");
            }
            else
            {
                txtEditImagesCategory.Text = "";
            }
        }
        catch (Exception ex)
        {
            this.AlertPageValid(true, ex.ToString(), alertPageValid, lblPageValid);
        }
    }

    protected void btnsave_Click(object sender, EventArgs e)
    {
        try
        {
            imagestype = new ImagesTypeBLL();
            int typeID = Convert.ToInt32((gwImagesCategory.SelectedRow.FindControl("lblImagesTypeID") as Label).Text);
            if (imagestype.UpdateImagesType(typeID, txtEditImagesCategory.Text))
            {
                Response.Redirect(Request.Url.AbsoluteUri);
            }
            else
            {
                this.AlertPageValid(true, "Không thể kết nối với CSDL !", alertPageValid, lblPageValid);
            }
        }
        catch (Exception ex)
        {
            this.AlertPageValid(true, ex.ToString(), alertPageValid, lblPageValid);
        }
    }
}