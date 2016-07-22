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
    public int PageSize = 15;
    CategoryBLL category;
    Post_Category_RelationshipsBLL post_category_relationships;
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
                btnEditCategory.Attributes.Add("class", "btn btn-circle btn-icon-only btn-default disabled");
                btnchangeLBImageCT.Attributes.Add("class", "btn btn-circle btn-icon-only btn-default disabled");
                this.load_dlParent();
                this.GetPostCategoryPageWise(1);
                this.GetImagesPageWise(1);
                this.GetImagesCTPageWise(1);
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
        this.PopulatePager(rptPager, recordCount, pageIndex, PageSize);
    }
    protected void Page_Changed(object sender, EventArgs e)
    {
        int pageIndex = int.Parse((sender as LinkButton).CommandArgument);
        this.GetPostCategoryPageWise(pageIndex);
        //Session["pageIndexadmin_Category"] = pageIndex.ToString();
        //rptPager.Visible = true;

    }
    protected void load_dlEditParent()
    {
        category = new CategoryBLL();
        string ctId = (gwCategory.SelectedRow.FindControl("lblCategoryID") as Label).Text;
        this.load_DropdownList(dlEParent, category.getTBSubtractCategory(int.Parse(ctId)), "NameVN", "ID");
        dlEParent.Items.Insert(0, new ListItem("--Trống--", "0"));
    }
    protected void gwCategory_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {

            btnEditCategory.Attributes.Add("class", "btn btn-circle btn-icon-only btn-default");
            btnchangeLBImageCT.Attributes.Add("class", "btn btn-circle btn-icon-only btn-default");
            this.load_dlEditParent();
            category = new CategoryBLL();
            int ID = Convert.ToInt32((gwCategory.SelectedRow.FindControl("lblCategoryID") as Label).Text);
            Category cat = category.ListCategoryWithID(ID).FirstOrDefault();
            txtENameVN.Text = cat.NameVN;
            txtENameEN.Text = cat.NameEN;
            txtEPermalink.Text = cat.Permalink;
            txtESeoTitle.Text = cat.SeoTitle;
            txtEMetaTitle.Text = cat.MetaTitle;
            txtEMetaKeywords.Text = cat.MetaKeywords;
            txtEMetaDescriptions.Text = cat.MetaDescriptions;
            dlEParent.Items.FindByValue(cat.Parent.ToString()).Selected = true;
            chkUpdateStatus.Checked = cat.CategoryStatus;
            chkShowHome.Checked = cat.ShowOnHome;
            images = new ImagesBLL();
            Images img = images.ListWithID(cat.CateogryImage).FirstOrDefault();
            ImageUpdate.ImageUrl = (img == null) ? "#" : "../../" + img.ImagesUrl;
        }
        catch (Exception ex)
        {
            this.AlertPageValid(true, ex.ToString(), alertPageValid, lblPageValid);
        }
    }
    protected void gwCategory_RowDataBound(object sender, GridViewRowEventArgs e)
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
    protected void gwCategory_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        try
        {
            category = new CategoryBLL();
            post_category_relationships = new Post_Category_RelationshipsBLL();
            int ctID = Convert.ToInt32((gwCategory.Rows[e.RowIndex].FindControl("lblCategoryID") as Label).Text);
            if (this.post_category_relationships.DeleteWithCategoryID(ctID))
            {
                if(this.category.UpdateParent(ctID,0))
                {
                    if (this.category.Delete(ctID))
                    {
                        this.GetPostCategoryPageWise(1);
                    }
                    else
                    {
                        this.AlertPageValid(true, "False to connect server !", alertPageValid, lblPageValid);
                    }
                }
            }
        }
        catch (Exception ex)
        {
            this.AlertPageValid(true, ex.ToString(), alertPageValid, lblPageValid);
        }
    }

    private int UpdateImgUpload()
    {
        images = new ImagesBLL();
        string dateString = DateTime.Now.ToString("MM-dd-yyyy");
        string dirFullPath = HttpContext.Current.Server.MapPath("../../images/Uploads/" + dateString + "/");

        if (!Directory.Exists(dirFullPath))   // CHECK IF THE FOLDER EXISTS. IF NOT, CREATE A NEW FOLDER.
        {
            Directory.CreateDirectory(dirFullPath);
        }
        string fileName = Path.GetFileName(FileUploadUpdateImg.PostedFile.FileName);
        ImageCodecInfo jgpEncoder = null;
        string str_image = "";
        string fileExtension = "";
        if (!string.IsNullOrEmpty(fileName))
        {
            fileExtension = Path.GetExtension(fileName);
            str_image = dateString + "-" + RandomName + fileExtension;
            string pathToSave = HttpContext.Current.Server.MapPath("../../images/Uploads/" + dateString + "/") + str_image;
            //file.SaveAs(pathToSave);
            System.Drawing.Image image = System.Drawing.Image.FromStream(FileUploadUpdateImg.FileContent);
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
            Bitmap bmp1 = new Bitmap(FileUploadUpdateImg.FileContent);
            Encoder myEncoder = Encoder.Quality;
            EncoderParameters myEncoderParameters = new EncoderParameters(1);
            EncoderParameter myEncoderParameter = new EncoderParameter(myEncoder, 30L);
            myEncoderParameters.Param[0] = myEncoderParameter;
            bmp1.Save(pathToSave, jgpEncoder, myEncoderParameters);
            this.images.NewImages(str_image, "images/Uploads/" + dateString + "/" + str_image, Session.GetCurrentUser().ID);
        }
        return (images.ListWithImagesName(str_image).FirstOrDefault() == null) ? 0 : images.ListWithImagesName(str_image).FirstOrDefault().ID;
    }
    protected void btnUpdateCategory_Click(object sender, EventArgs e)
    {
        try
        {
            category = new CategoryBLL();
            int ID = Convert.ToInt32((gwCategory.SelectedRow.FindControl("lblCategoryID") as Label).Text);
            Category cat = category.ListCategoryWithID(ID).FirstOrDefault();
            if (category.UpdateCategory(ID, txtENameVN.Text, txtENameEN.Text, Convert.ToInt32(dlEParent.SelectedValue), txtEPermalink.Text, txtESeoTitle.Text, (UpdateImgUpload() == 0) ? cat.CateogryImage : UpdateImgUpload(), DateTime.Now, Session.GetCurrentUser().ID, txtEMetaTitle.Text, txtEMetaKeywords.Text, txtEMetaDescriptions.Text, chkUpdateStatus.Checked, chkShowHome.Checked))
            {
                this.GetPostCategoryPageWise(1);
            }
            else
            {
                this.AlertPageValid(true, "Connect to Server False !", alertPageValid, lblPageValid);
            }
            //this.AlertPageValid(true, UpdateImgUpload().ToString(), alertPageValid, lblPageValid);
        }
        catch (Exception ex)
        {
            this.AlertPageValid(true, ex.ToLogString(), alertPageValid, lblPageValid);
        }
    }
    //Load Images
    private void GetImagesPageWise(int pageIndex)
    {
        try
        {
            images = new ImagesBLL();
            int Size = 15;
            int recordCount = 0;
            rpLstImg.DataSource = images.GetImagesPageWise(pageIndex, Size);
            recordCount = images.RecordCountImages();
            rpLstImg.DataBind();
            this.PopulatePager(rptPaginationImg, recordCount, pageIndex, Size);
        }
        catch (Exception ex)
        {
            this.AlertPageValid(true, ex.ToString(), alertPageValid, lblPageValid);
        }
    }
    protected void Img_Page_Changed(object sender, EventArgs e)
    {
        int pageIndex = int.Parse((sender as LinkButton).CommandArgument);
        this.GetImagesPageWise(pageIndex);
        string script = "window.onload = function() { callmodalCtImages(); };";
        ClientScript.RegisterStartupScript(this.GetType(), "callmodalCtImages", script, true);
    }
    protected void btnchangeImgPost_Click(object sender, EventArgs e)
    {
        try
        {
            string http = "http://" + Request.Url.Authority + "/";
            txtImageTemp.Text = HiddenimgSelect.Value.Remove(0, HiddenimgSelect.Value.LastIndexOf("/") + 1);
            ImgPostCategory.Src = "../../" + HiddenimgSelect.Value.Remove(0, http.Length);
            
        }
        catch (Exception ex)
        {
            this.AlertPageValid(true, ex.ToString(), alertPageValid, lblPageValid);
        }
    }
    private void GetImagesCTPageWise(int pageIndex)
    {
        try
        {
            images = new ImagesBLL();
            int Size = 15;
            int recordCount = 0;
            rpChangeCTImage.DataSource = images.GetImagesPageWise(pageIndex, Size);
            recordCount = images.RecordCountImages();
            rpChangeCTImage.DataBind();
            this.PopulatePager(rptchangeImgCTPages, recordCount, pageIndex, Size);
        }
        catch (Exception ex)
        {
            this.AlertPageValid(true, ex.ToString(), alertPageValid, lblPageValid);
        }
    }
    protected void ImgCT_Page_Changed(object sender, EventArgs e)
    {
        int pageIndex = int.Parse((sender as LinkButton).CommandArgument);
        this.GetImagesCTPageWise(pageIndex);
        string script = "window.onload = function() { callmodalLBCtImages(); };";
        ClientScript.RegisterStartupScript(this.GetType(), "callmodalLBCtImages", script, true);
    }
    protected void btnChangeCTImages_Click(object sender, EventArgs e)
    {
        try
        {
            category = new CategoryBLL();
            images = new ImagesBLL();
            int ctID = Convert.ToInt32((gwCategory.SelectedRow.FindControl("lblCategoryID") as Label).Text);
            string http = "http://" + Request.Url.Authority + "/";
            string ImgNAme = HidImgUrlCT.Value.Remove(0, HidImgUrlCT.Value.LastIndexOf("/") + 1);
            Images img = images.ListWithImagesName(ImgNAme).FirstOrDefault();
            if (category.UpdateImage(ctID, img.ID))
            {
                this.GetPostCategoryPageWise(1);
            }
        }
        catch (Exception ex)
        {
            this.AlertPageValid(true, ex.ToString(), alertPageValid, lblPageValid);
        }
    }
}