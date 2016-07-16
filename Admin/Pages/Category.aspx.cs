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
using System.IO;
using System.Drawing.Imaging;
using System.Drawing;

public partial class Admin_Pages_Category : BasePage
{
    public int PageSize = 30;
    CategoryBLL category;
    ImagesBLL images;
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
                this.GetPostCategoryPageWise(1);
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
            category = new CategoryBLL();
            images = new ImagesBLL();

            string titleVN = txtCategoryNameVN.Text;
            string titleEN = txtCategoryNameEN.Text;
            int Parent = Convert.ToInt32(dlParent.SelectedValue);
            //ItemIndex
            int itemindex = (Convert.ToInt32(dlParent.SelectedValue) == 0) ? category.MaxItemindexWithParentNull() + 1 : category.MaxItemindexWithParent(Convert.ToInt32(dlParent.SelectedValue)) + 1;
            string permlink = txtPermalink.Text;
            string seotitle = txtSeoTitle.Text;
            //Images
            List<Images> lstI = images.ListWithImagesName(txtImageTemp.Text);
            Images img = lstI.FirstOrDefault();
            int ImgID = (img == null) ? 0 : img.ID;
            //Create By
            string metatile = txtMetaTitle.Text;
            string metakeyword = txtMetaKeywords.Text;
            string metadecription = txtMetaDescriptions.Text;
            Boolean showonhome = (chkShowOnHome.Checked == true) ? true : false;
            if (category.NewCategory(titleVN, titleEN, Parent, itemindex, permlink, seotitle, ImgID, Session.GetCurrentUser().ID, Convert.ToDateTime("12/12/1900"), 0, metatile, metakeyword, metadecription, true, showonhome))
            {
                Response.Redirect(Request.Url.AbsoluteUri);
            }
            else
            {
                this.AlertPageValid(true, "False to create category . Error to connect server !", alertPageValid, lblPageValid);
            }

        }
        catch (Exception ex)
        {
            this.AlertPageValid(true, ex.ToString(), alertPageValid, lblPageValid);
        }
    }
    protected void btnuploadImg_Click(object sender, EventArgs e)
    {
        try
        {
            images = new ImagesBLL();
            string dateString = DateTime.Now.ToString("MM-dd-yyyy");
            string dirFullPath = HttpContext.Current.Server.MapPath("../../images/Uploads/" + dateString + "/");

            if (!Directory.Exists(dirFullPath))   // CHECK IF THE FOLDER EXISTS. IF NOT, CREATE A NEW FOLDER.
            {
                Directory.CreateDirectory(dirFullPath);
            }
            string fileName = Path.GetFileName(fileUploadImgCategory.PostedFile.FileName);
            ImageCodecInfo jgpEncoder = null;
            string str_image = "";
            string fileExtension = "";
            if (!string.IsNullOrEmpty(fileName))
            {
                fileExtension = Path.GetExtension(fileName);
                str_image = dateString + "-" + RandomName + fileExtension;
                string pathToSave = HttpContext.Current.Server.MapPath("../../images/Uploads/" + dateString + "/") + str_image;
                //file.SaveAs(pathToSave);
                System.Drawing.Image image = System.Drawing.Image.FromStream(fileUploadImgCategory.FileContent);
                if (image.RawFormat.Guid == System.Drawing.Imaging.ImageFormat.Gif.Guid)
                    jgpEncoder = GetEncoder(ImageFormat.Gif);
                else if (image.RawFormat.Guid == System.Drawing.Imaging.ImageFormat.Jpeg.Guid)
                    jgpEncoder = GetEncoder(ImageFormat.Jpeg);
                else if (image.RawFormat.Guid == System.Drawing.Imaging.ImageFormat.Bmp.Guid)
                    jgpEncoder = GetEncoder(ImageFormat.Bmp);
                else if (image.RawFormat.Guid == System.Drawing.Imaging.ImageFormat.Png.Guid)
                    jgpEncoder = GetEncoder(ImageFormat.Png);
                else
                    throw new System.ArgumentException("Invalid File Type");
                Bitmap bmp1 = new Bitmap(fileUploadImgCategory.FileContent);
                Encoder myEncoder = Encoder.Quality;
                EncoderParameters myEncoderParameters = new EncoderParameters(1);
                EncoderParameter myEncoderParameter = new EncoderParameter(myEncoder, 30L);
                myEncoderParameters.Param[0] = myEncoderParameter;
                bmp1.Save(pathToSave, jgpEncoder, myEncoderParameters);

                this.images.NewImages(str_image, "images/Uploads/" + dateString + "/" + str_image, Session.GetCurrentUser().ID);
                txtImageTemp.Text = str_image;
                ImgPostCategory.Src = "../../images/Uploads/" + dateString + "/" + str_image;
                //Response.Redirect(Request.Url.AbsoluteUri);

            }
            else
            {
                Response.Write("<script>alert('Upload Image False !')</script>");
                return;
            }
        }
        catch (Exception ex)
        {
            this.AlertPageValid(true, ex.ToString(), alertPageValid, lblPageValid);
        }
    }
    private void GetPostCategoryPageWise(int pageIndex)
    {
        category = new CategoryBLL();
        int recordCount = 0;
        gwCategory.DataSource = category.GetCategoryPageWise(pageIndex, PageSize);
        recordCount = category.CountRecordPostCategory();
        gwCategory.DataBind();
        this.PopulatePager(recordCount, pageIndex);
    }
    private void PopulatePager(int recordCount, int currentPage)
    {
        List<ListItem> pages = new List<ListItem>();
        int startIndex, endIndex;
        int pagerSpan = 5;

        //Calculate the Start and End Index of pages to be displayed.
        double dblPageCount = (double)((decimal)recordCount / Convert.ToDecimal(PageSize));
        int pageCount = (int)Math.Ceiling(dblPageCount);
        startIndex = currentPage > 1 && currentPage + pagerSpan - 1 < pagerSpan ? currentPage : 1;
        endIndex = pageCount > pagerSpan ? pagerSpan : pageCount;
        if (currentPage > pagerSpan % 2)
        {
            if (currentPage == 2)
            {
                endIndex = 5;
            }
            else
            {
                endIndex = currentPage + 2;
            }
        }
        else
        {
            endIndex = (pagerSpan - currentPage) + 1;
        }

        if (endIndex - (pagerSpan - 1) > startIndex)
        {
            startIndex = endIndex - (pagerSpan - 1);
        }

        if (endIndex > pageCount)
        {
            endIndex = pageCount;
            startIndex = ((endIndex - pagerSpan) + 1) > 0 ? (endIndex - pagerSpan) + 1 : 1;
        }

        //Add the First Page Button.
        if (currentPage > 1)
        {
            pages.Add(new ListItem("First", "1"));
        }

        //Add the Previous Button.
        if (currentPage > 1)
        {
            pages.Add(new ListItem("<<", (currentPage - 1).ToString()));
        }

        for (int i = startIndex; i <= endIndex; i++)
        {
            pages.Add(new ListItem(i.ToString(), i.ToString(), i != currentPage));
        }

        //Add the Next Button.
        if (currentPage < pageCount)
        {
            pages.Add(new ListItem(">>", (currentPage + 1).ToString()));
        }

        //Add the Last Button.
        if (currentPage != pageCount)
        {
            pages.Add(new ListItem("Last", pageCount.ToString()));
        }
        rptPager.DataSource = pages;
        rptPager.DataBind();
    }
    protected void Page_Changed(object sender, EventArgs e)
    {
        int pageIndex = int.Parse((sender as LinkButton).CommandArgument);
        this.GetPostCategoryPageWise(pageIndex);
        //Session["pageIndexadmin_Category"] = pageIndex.ToString();
        //rptPager.Visible = true;
       
    }
    protected void gwCategory_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
    protected void gwCategory_RowDataBound(object sender, GridViewRowEventArgs e)
    {

    }
    protected void gwCategory_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {

    }
}